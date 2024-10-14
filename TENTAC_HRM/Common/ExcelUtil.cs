using NPOI.HSSF.UserModel;
using NPOI.HSSF.Util;
using NPOI.SS.UserModel;
using NPOI.SS.Util;
using NPOI.XSSF.UserModel;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text.RegularExpressions;

namespace TENTAC_HRM.Common
{
    public class ExcelUtil
    {
        /// <summary>
        /// ***************************************************************<br />
        /// 引数のパスをもとにインスタンスを生成する<br />
        /// 存在していないパスが指定された場合は新規ブック作成と捉え処理する<br />
        /// ***************************************************************<br />
        /// </summary>
        /// <param name="path">エクセルファイルのフルパス</param>
        /// <returns>XlsWorkBookオブジェクト</returns>
        public static XlsWorkBook Open(string path)
        {
            return new XlsWorkBook(path);
        }

        /// <summary>
        /// ***************************************************************<br />
        /// 新規のブックとしてファイルを出力する<br />
        /// ***************************************************************<br />
        /// </summary>
        /// <param name="path">出力するエクセルファイルのフルパス</param>
        /// <param name="list">エクセルに書き込むデータ</param>
        /// <remarks>引数listはList<List<string>>の形式</remarks>
        public static void Export(string path, List<List<string>> list)
        {
            if (File.Exists(path))
            {
                File.Delete(path);
            }

            var book = new XlsWorkBook(path);
            var sheet = book.Sheet(0);

            // セルスタイル タイトル
            ICellStyle cellStyleH = book.GetAllSideBorderCellStyle();
            cellStyleH.VerticalAlignment = VerticalAlignment.Center;
            cellStyleH.FillForegroundColor = HSSFColor.Yellow.Index;
            cellStyleH.FillPattern = FillPattern.SolidForeground;

            // セルスタイル ボディ
            ICellStyle cellStyleB = book.GetAllSideBorderCellStyle();
            cellStyleB.VerticalAlignment = VerticalAlignment.Center;

            int colCount = 0;
            int i = 0;
            foreach (var record in list)
            {
                int i2 = 0;
                foreach (var value in record)
                {
                    sheet.Cell(i, i2).SetValue(value);

                    if (i == 0)
                    {
                        // カラム数を記憶
                        colCount = i2;

                        // セルにスタイルを反映
                        sheet.Cell(i, i2).SetStyle(cellStyleH);
                    }
                    else
                    {
                        // セルにスタイルを反映
                        sheet.Cell(i, i2).SetStyle(cellStyleB);
                    }

                    i2++;
                }
                i++;
            }

            // 列幅を調整
            for (int colIndex = 0; colIndex <= colCount; colIndex++)
            {
                sheet.AutoSizeColumn(colIndex, 8000);
            }

            book.Save();
        }
    }

    /// <summary>
    /// ***************************************************************<br />
    /// Excelワークブック<br />
    /// ***************************************************************<br />
    /// </summary>
    public class XlsWorkBook : IDisposable
    {
        private string _path;
        public IWorkbook _workbook = null;

        /// <summary>
        /// コンストラクタ
        /// </summary>
        /// <param name="path">ファイルパス</param>
        public XlsWorkBook(string path)
        {
            _path = path;

            var extension = Path.GetExtension(_path).ToLower();

            if (File.Exists(_path))
            {
                using (var fs = File.OpenRead(path))
                {
                    if (extension == ".xls")
                    {
                        _workbook = new HSSFWorkbook(fs);
                    }
                    else
                    {
                        _workbook = new XSSFWorkbook(fs);
                    }
                }
            }
            else
            {
                if (extension == ".xls")
                {
                    _workbook = new HSSFWorkbook();
                }
                else
                {
                    _workbook = new XSSFWorkbook();
                }
                _workbook.CreateSheet("Sheet1");
            }
        }
        /// <summary>
        /// multiple sheet
        /// </summary>
        /// <param name="path"></param>
        /// <param name="number_page"></param>
        public XlsWorkBook(string path, int number_page = 0, int copy_page = 0)
        {
            _path = path;

            var extension = Path.GetExtension(_path).ToLower();

            if (File.Exists(_path))
            {
                using (var fs = File.OpenRead(path))
                {
                    if (extension == ".xls")
                    {
                        _workbook = new HSSFWorkbook(fs);
                    }
                    else
                    {
                        _workbook = new XSSFWorkbook(fs);
                    }
                }
                if (copy_page > 0)
                {
                    XSSFWorkbook workbookMerged = new XSSFWorkbook();
                    for (int i = 1; i <= copy_page; i++)
                    {
                        ISheet cloneSheet = _workbook.CloneSheet(0);
                        //PrintSetup.Scale = 80;
                        //XSSFSheet sheet = _workbook.GetSheetAt(0) as XSSFSheet;
                        //sheet.CopyTo(_workbook,sheet.SheetName + i, true, false);
                    }
                }
            }
            else
            {
                if (extension == ".xls")
                {
                    _workbook = new HSSFWorkbook();
                }
                else
                {
                    _workbook = new XSSFWorkbook();
                }
                for (int i = 1; i <= number_page; i++)
                {
                    _workbook.CreateSheet("Sheet" + i);
                }
            }
        }

        public void SetActiveSheet(int sheeet)
        {
            _workbook.SetActiveSheet(sheeet);
        }
        public void SetSelectedTab(int sheeet)
        {
            _workbook.SetSelectedTab(sheeet);
        }
        /// <summary>
        /// ***************************************************************<br />
        /// IWorkbookを開放します。<br />
        /// ***************************************************************<br />
        /// </summary>
        public void Dispose()
        {
            if (_workbook != null)
            {
                _workbook.Close();
                _workbook = null;
            }
        }

        /// <summary>
        /// ***************************************************************<br />
        /// Excelシートを取得します。<br />
        /// ***************************************************************<br />
        /// </summary>
        /// <param name="index">シート番号</param>
        /// <returns>XlsWorkSheet</returns>
        public XlsWorkSheet Sheet(int index)
        {
            return new XlsWorkSheet(_workbook.GetSheetAt(index) ?? _workbook.CreateSheet());
        }

        /// <summary>
        /// ***************************************************************<br />
        /// Excelシートを取得します。<br />
        /// ***************************************************************<br />
        /// </summary>
        /// <param name="sheetName"></param>
        /// <returns></returns>
        public XlsWorkSheet Sheet(string sheetName)
        {
            return new XlsWorkSheet(_workbook.GetSheet(sheetName) ?? _workbook.CreateSheet());
        }

        /// <summary>
        /// ***************************************************************<br />
        /// シートをコピーします。<br />
        /// ***************************************************************<br />
        /// </summary>
        /// <param name="index">コピー対象のシート番号</param>
        public void CloneSheet(int index)
        {
            _workbook.CloneSheet(index);
        }

        /// <summary>
        /// ***************************************************************<br />
        /// シート名を設定します。<br />
        /// ***************************************************************<br />
        /// </summary>
        /// <param name="index">設定対象のシート番号</param>
        /// <param name="name">設定するシート名</param>
        public void SetSheetName(int index, string name)
        {
            _workbook.SetSheetName(index, name);
        }

        /// <summary>
        /// ***************************************************************<br />
        /// シート番号を取得します。<br />
        /// ***************************************************************<br />
        /// </summary>
        /// <param name="name">対象のシート名</param>
        public int GetSheetIndex(string name)
        {
            return _workbook.GetSheetIndex(name);
        }

        /// <summary>
        /// ***************************************************************<br />
        /// シート件数を取得します。<br />
        /// ***************************************************************<br />
        /// </summary>
        /// <returns></returns>
        public int NumberOfSheets()
        {
            return _workbook.NumberOfSheets;
        }

        /// <summary>
        /// ***************************************************************<br />
        /// 非表示シートであるか判定します。<br />
        /// ***************************************************************<br />
        /// </summary>
        /// <param name="index"></param>
        /// <returns></returns>
        public bool IsSheetHidden(int index)
        {
            return _workbook.IsSheetHidden(index) || _workbook.IsSheetVeryHidden(index);
        }

        /// <summary>
        /// ***************************************************************<br />
        /// シートが存在しているか判定します。<br />
        /// ***************************************************************<br />
        /// </summary>
        /// <param name="sheetName">シート名</param>
        /// <returns></returns>
        public bool SheetExists(string sheetName)
        {
            if (_workbook.NumberOfSheets != 0)
            {
                for (var i = 0; i < _workbook.NumberOfSheets; i++)
                {
                    if (_workbook.GetSheetName(i).Equals(sheetName))
                    {
                        return true;
                    }
                }
            }
            return false;
        }

        /// <summary>
        /// ***************************************************************<br />
        /// シート名を取得します。<br />
        /// ***************************************************************<br />
        /// </summary>
        /// <param name="index"></param>
        /// <returns></returns>
        public string GetSheetName(int index)
        {
            return _workbook.GetSheetName(index); ;
        }

        /// <summary>
        /// ***************************************************************<br />
        /// シートを削除します。<br />
        /// ***************************************************************<br />
        /// </summary>
        /// <param name="index">削除対象のシート番号</param>
        public void RemoveSheetAt(int index)
        {
            _workbook.RemoveSheetAt(index);
        }

        /// <summary>
        /// ***************************************************************<br />
        /// 四方罫線のセルスタイルを取得します。<br />
        /// ***************************************************************<br />
        /// </summary>
        /// <returns>ICellStyle</returns>
        public ICellStyle GetAllSideBorderCellStyle()
        {
            var style = _workbook.CreateCellStyle();
            style.BorderBottom = BorderStyle.Thin;
            style.BorderLeft = BorderStyle.Thin;
            style.BorderRight = BorderStyle.Thin;
            style.BorderTop = BorderStyle.Thin;

            var font = _workbook.CreateFont();
            font.FontName = "Meiryo UI";
            font.FontHeightInPoints = 10;

            style.SetFont(font);

            return style;
        }
        public ICellStyle GeCellStyleAlignment(HorizontalAlignment alignment, short color = -1, string font = null, int fontHeight = 10)
        {
            var style = _workbook.CreateCellStyle();
            if (color != -1)
            {
                style.FillPattern = FillPattern.SolidForeground;
                style.FillForegroundColor = color;
            }
            var fonts = _workbook.CreateFont();
            if (font != null)
            {
                if (font != null)
                {
                    fonts.FontName = font;
                }
            }
            fonts.FontHeightInPoints = fontHeight;
            style.SetFont(fonts);
            style.Alignment = alignment;
            style.BorderBottom = BorderStyle.Thin;
            style.BorderLeft = BorderStyle.Thin;
            style.BorderRight = BorderStyle.Thin;
            style.BorderTop = BorderStyle.Thin;
            return style;
        }

        public ICellStyle GetCellStyle_1(HorizontalAlignment alignment = HorizontalAlignment.Left, VerticalAlignment verticalAlignment = VerticalAlignment.Center, int fontHeight = 10, string fontName = "")
        {
            var style = _workbook.CreateCellStyle();
            style.Alignment = alignment;
            style.VerticalAlignment = verticalAlignment;
            var fonts = _workbook.CreateFont();
            fonts.FontHeightInPoints = fontHeight;
            if (fontName != "")
            {
                fonts.FontName = fontName;
            }
            style.SetFont(fonts);
            style.WrapText = true;
            return style;
        }

        public ICellStyle GetCellStyle(bool border = false, short color = -1,
            HorizontalAlignment alignment = HorizontalAlignment.Left,
            VerticalAlignment verticalAlignment = VerticalAlignment.Center,
            int text_control = -1, int fontHeight = 10, string fontName = "",
            bool isBold = false, bool IsItalic = false, bool isStrikeout = false, FontUnderlineType underline = FontUnderlineType.None,
            string formats = "")
        {
            // font
            var fonts = _workbook.CreateFont();
            if (isBold == true)
                fonts.IsBold = true;

            if (IsItalic == true)
                fonts.IsItalic = true;

            if (isStrikeout == true)
                fonts.IsStrikeout = true;

            fonts.Underline = underline;

            fonts.FontHeightInPoints = fontHeight;

            // fontName
            if (fontName != "")
            {
                fonts.FontName = fontName;
            }
            var style = _workbook.CreateCellStyle();
            style.Alignment = alignment;
            style.VerticalAlignment = verticalAlignment;
            //
            if (formats != "")
            {
                var format = _workbook.CreateDataFormat();
                style.DataFormat = format.GetFormat(formats);
            }

            // text control
            if (text_control == 0)
                style.WrapText = true;
            else if (text_control == 1)
                style.ShrinkToFit = true;

            style.SetFont(fonts);
            // border
            if (border)
            {
                style.BorderBottom = BorderStyle.Thin;
                style.BorderLeft = BorderStyle.Thin;
                style.BorderRight = BorderStyle.Thin;
                style.BorderTop = BorderStyle.Thin;
            }
            // color
            if (color != -1)
            {
                style.FillPattern = FillPattern.SolidForeground;
                style.FillForegroundColor = color;
            }
            return style;
        }

        public ICellStyle GeCellStyleColor(short index, HorizontalAlignment alignment)
        {
            var evenStyle = _workbook.CreateCellStyle();
            evenStyle.FillPattern = FillPattern.SolidForeground;
            evenStyle.FillForegroundColor = index;
            evenStyle.Alignment = alignment;
            return evenStyle;
        }
        public ICellStyle GetAllSideBorderNumericCellStyle()
        {
            var style = _workbook.CreateCellStyle();
            style.BorderBottom = BorderStyle.Thin;
            style.BorderLeft = BorderStyle.Thin;
            style.BorderRight = BorderStyle.Thin;
            style.BorderTop = BorderStyle.Thin;
            style.Alignment = HorizontalAlignment.Right;

            var font = _workbook.CreateFont();
            font.FontName = "Meiryo UI";
            font.FontHeightInPoints = 10;

            style.SetFont(font);

            var format = _workbook.CreateDataFormat();
            style.DataFormat = format.GetFormat("0.00");

            return style;
        }
        public ICellStyle GetAllTextAlignmentCellStyle()
        {
            var style = _workbook.CreateCellStyle();
            style.Alignment = HorizontalAlignment.Center;

            return style;
        }
        /// <summary>
        /// ***************************************************************<br />
        /// 枠線のセルスタイルを取得します。<br />
        /// ***************************************************************<br />
        /// </summary>
        /// <returns>ICellStyle</returns>
        public ICellStyle GetFrameBorderCellStyle()
        {
            var style = _workbook.CreateCellStyle();
            style.BorderBottom = BorderStyle.Thin;
            style.BorderLeft = BorderStyle.Thin;
            style.BorderRight = BorderStyle.Thin;
            style.BorderTop = BorderStyle.Thin;

            return style;
        }

        /// <summary>
        /// ***************************************************************<br />
        /// フォント名・フォントサイズ・枠線有無を任意に指定しセルスタイルを取得します。<br />
        /// ***************************************************************<br />
        /// </summary>
        /// <param name="fontName">フォント名</param>
        /// <param name="fontHeightInPoints">フォントサイズ</param>
        /// <param name="frameBorderFlg">枠線有無</param>
        /// <returns>ICellStyle</returns>
        public ICellStyle GetFontCellStyle(string fontName, double fontHeightInPoints, bool frameBorderFlg)
        {
            var style = _workbook.CreateCellStyle();

            if (frameBorderFlg)
            {
                style = GetFrameBorderCellStyle();
            }

            var font = _workbook.CreateFont();
            font.FontName = fontName;
            font.FontHeightInPoints = fontHeightInPoints;

            style.SetFont(font);

            return style;
        }

        /// <summary>
        /// ***************************************************************<br />
        /// フォント名・フォントサイズ・枠線有無を任意に指定しセルスタイルを取得します。<br />
        /// ***************************************************************<br />
        /// </summary>
        /// <param name="fontName">フォント名</param>
        /// <param name="fontHeightInPoints">フォントサイズ</param>
        /// <param name="frameBorderFlg">枠線有無</param>
        /// <param name="formatStr">表示形式</param>
        /// <returns>ICellStyle</returns>
        public ICellStyle GetFontCellStyle(string fontName, double fontHeightInPoints, bool frameBorderFlg, string formatStr)
        {
            var style = GetFontCellStyle(fontName, fontHeightInPoints, frameBorderFlg);

            var format = _workbook.CreateDataFormat();
            style.DataFormat = format.GetFormat(formatStr);

            return style;
        }

        /// <summary>
        /// ***************************************************************<br />
        /// 印刷範囲を設定します。<br />
        /// ***************************************************************<br />
        /// </summary>
        /// <param name="sheetIndex">シート番号</param>
        /// <param name="reference">範囲アドレス</param>
        public void SetPrintArea(int sheetIndex, string reference)
        {
            _workbook.SetPrintArea(sheetIndex, reference);
        }

        /// <summary>
        /// ***************************************************************<br />
        /// 印刷範囲を設定します。<br />
        /// ***************************************************************<br />
        /// </summary>
        /// <param name="sheetIndex">シート番号</param>
        /// <param name="startColumn">開始列</param>
        /// <param name="endColumn">終了列</param>
        /// <param name="startRow">開始行</param>
        /// <param name="endRow">終了行</param>
        public void SetPrintArea(int sheetIndex, int startColumn, int endColumn, int startRow, int endRow)
        {
            _workbook.SetPrintArea(sheetIndex, startColumn, endColumn, startRow, endRow);
        }

        /// <summary>
        /// ***************************************************************<br />
        /// ブック内の全てのセルの数式を再計算します。<br />
        /// ***************************************************************<br />
        /// </summary>
        public void EvaluateAllFormulaCells()
        {
            HSSFFormulaEvaluator.EvaluateAllFormulaCells(_workbook);
        }

        /// <summary>
        /// ***************************************************************<br />
        /// Excelをメモリ上で保存します。<br />
        /// ***************************************************************<br />
        /// </summary>
        public void Save()
        {
            Save(_path);
        }

        /// <summary>
        /// ***************************************************************<br />
        /// Excelをメモリ上で保存します。<br />
        /// ***************************************************************<br />
        /// </summary>
        /// <param name="path">ファイルパス</param>
        public void Save(string path)
        {
            using (var fs = File.Create(path))
            {
                _workbook.Write(fs);
            }
        }

        /// <summary>
        /// ***************************************************************<br />
        /// Excelに画像を追加します。<br />
        /// ***************************************************************<br />
        /// </summary>
        /// <param name="bytes">バイト配列</param>
        /// <param name="type">PictureType</param>
        /// <returns>追加した画像番号</returns>
        public int AddPicture(byte[] bytes, PictureType type)
        {
            return _workbook.AddPicture(bytes, type);
        }

        /// <summary>
        /// ***************************************************************<br />
        /// Anchorを生成します。<br />
        /// ***************************************************************<br />
        /// </summary>
        /// <param name="type">AnchorType</param>
        /// <param name="row1">開始行番号</param>
        /// <param name="col1">開始列番号1</param>
        /// <param name="row2">終了行番号2</param>
        /// <param name="col2">終了列番号2</param>
        /// <param name="dx1">x軸オフセット（左方向）</param>
        /// <param name="dy1">y軸オフセット（上方向）</param>
        /// <param name="dx2">x軸オフセット（右方向）</param>
        /// <param name="dy2">y軸オフセット（下方向）</param>
        /// <returns></returns>
        public IClientAnchor CreateAnchor(AnchorType type, int row1, int col1, int row2, int col2, int dx1 = 0, int dy1 = 0, int dx2 = 0, int dy2 = 0)
        {
            var anchor = _workbook.GetCreationHelper().CreateClientAnchor();

            // AnchorTypeを設定
            anchor.AnchorType = type;

            // 位置の指定
            anchor.Row1 = row1;
            anchor.Col1 = col1;
            anchor.Row2 = row2;
            anchor.Col2 = col2;

            // オフセットの設定（ピクセルで設定）
            anchor.Dx1 = XSSFShape.EMU_PER_PIXEL * dx1;
            anchor.Dy1 = XSSFShape.EMU_PER_PIXEL * dy1;
            anchor.Dx2 = XSSFShape.EMU_PER_PIXEL * dx2;
            anchor.Dy2 = XSSFShape.EMU_PER_PIXEL * dy2;

            return anchor;
        }

        /// <summary>
        /// 定義された全ての名前を返します
        /// </summary>
        /// <returns></returns>
        public Dictionary<string, string> GetNumberOfNames()
        {
            var resDic = new Dictionary<string, string>();
            var lists = _workbook.GetAllNames();

            if (lists.Count == 0)
            {
                return resDic;
            }

            for (int i = 0; i < lists.Count; i++)
            {
                var name = lists[i].NameName.ToString();
                var nameArea = _workbook.GetName(name);

                var cellAddress = CellRangeAddress.ValueOf(nameArea.RefersToFormula);
                //var address = new NameArea();                
                //address.FirstRow = cellAddress.FirstRow;
                //address.FirstCol = cellAddress.FirstColumn;
                //address.LastRow = cellAddress.LastRow;
                //address.LastCol = cellAddress.LastColumn;

                resDic.Add(name, cellAddress.ToString());

            }
            return resDic;
        }

        public class NameArea
        {
            public int FirstRow { get; set; }
            public int FirstCol { get; set; }

            public int LastRow { get; set; }
            public int LastCol { get; set; }

        }
    }

    /// <summary>
    /// ***************************************************************<br />
    /// Excelシート<br />
    /// ***************************************************************<br />
    /// </summary>
    public class XlsWorkSheet
    {
        private ISheet _sheet = null;

        // 「ReplaceValue」「ReplaceOneValue」にて使用
        // ・true:対象範囲内の置換対象を全て置換
        // ・false:対象範囲内で最初に検出する置換対象1件のみを置換
        static private bool ALL_REPLACE_VALUE_FLG = true;

        /// <summary>
        /// ***************************************************************<br />
        /// コンストラクタ<br />
        /// ***************************************************************<br />
        /// </summary>
        /// <param name="sheet"></param>
        public XlsWorkSheet(ISheet sheet)
        {
            _sheet = sheet;
        }

        /// <summary>
        /// ***************************************************************<br />
        /// セルオブジェクトを取得します。<br />
        /// ***************************************************************<br />
        /// </summary>
        /// <param name="rowIndex">行番号</param>
        /// <param name="colIndex">列番号</param>
        /// <param name="allowEmptyFlg">true:ICellオブジェクトがNullまたは文字列が""の場合でもセルオブジェクトを返却する<br />
        ///                             false:ICellオブジェクトがNullまたは文字列が""の場合はNullを返却する</param>
        /// <returns>XlsCell</returns>
        public XlsCell Cell(int rowIndex, int colIndex, bool allowEmptyFlg = true)
        {
            var row = _sheet.GetRow(rowIndex) ?? _sheet.CreateRow(rowIndex);
            var cellObj = row.GetCell(colIndex);
            if (!allowEmptyFlg &&
                (cellObj == null || string.IsNullOrEmpty(cellObj.ToString())))
            {
                // allowEmptyFlg が false かつ ICellオブジェクトがNullまたは文字列が""の場合
                return null;
            }
            else
            {
                // 上記以外の場合
                return new XlsCell(cellObj ?? row.CreateCell(colIndex));
            }
        }

        public XlsCell Cell(string address)
        {
            // 列位置取得
            string colStr = Regex.Replace(address, @"[^A-Z]", "");
            int colIndex = 0;
            for (var i = 0; i < colStr.Length; i++)
            {
                colIndex = colIndex * 26 + (Microsoft.VisualBasic.Strings.Asc(colStr.Substring(i, 1).ToUpper()) - 64);
            }
            colIndex = colIndex - 1;

            // 行位置取得
            string rowStr = Regex.Replace(address, @"[^0-9]", "");
            int rowIndex = int.Parse(rowStr) - 1;

            var row = _sheet.GetRow(rowIndex) ?? _sheet.CreateRow(rowIndex);
            return new XlsCell(row.GetCell(colIndex) ?? row.CreateCell(colIndex));
        }

        /// <summary>
        /// ***************************************************************<br />
        /// 改ページを設定します。<br />
        /// ***************************************************************<br />
        /// </summary>
        /// <param name="rowIndex">行番号</param>
        /// <param name="colIndex">列番号</param>
        /// <param name="scale">印刷倍率</param>
        public void SetPrintLine(int rowIndex, int colIndex, short scale)
        {
            // 改ページ
            _sheet.SetRowBreak(rowIndex);
            _sheet.SetColumnBreak(colIndex);
            _sheet.FitToPage = false;
            // 印刷設定
            var printSetting = _sheet.PrintSetup;
            printSetting.Scale = scale;
            printSetting.PaperSize = (short)PaperSize.A4;
        }
        public void SetPrintScale(short scale)
        {
            _sheet.FitToPage = false;
            // 印刷設定
            var printSetting = _sheet.PrintSetup;
            printSetting.Scale = scale;
            printSetting.PaperSize = (short)PaperSize.A4;
        }
        /// <summary>
        /// ***************************************************************<br />
        /// 列幅を自動調節します。<br />
        /// ***************************************************************<br />
        /// </summary>
        /// <param name="colIndex">列番号</param>
        /// <param name="maxWidth">最大列幅、0は幅調整なし</param>
        public void AutoSizeColumn(int colIndex, int maxWidth = 0)
        {
            _sheet.AutoSizeColumn(colIndex);

            var columnWidth = _sheet.GetColumnWidth(colIndex);

            // 最大列幅を超えないように調整
            if (maxWidth > 0 && columnWidth > maxWidth)
            {
                columnWidth = maxWidth;
            }

            // POI独自の単位に基づく調節により、WPS観点だとうまく調節されていないことがあるため、
            // 自動調節後にセル幅を500加算する。
            _sheet.SetColumnWidth(colIndex, columnWidth + 500);
        }

        /// <summary>
        /// ***************************************************************<br />
        /// シート内のセルを検索し、任意のセル値を置換する<br />
        /// ***************************************************************<br />
        /// </summary>
        /// <param name="oldValue">置換前の値</param>
        /// <param name="newValue">置換後の値</param>
        /// <param name="rowFrom">対象範囲_開始行index ※デフォルト:0（1行目）</param>
        /// <param name="rowTo">対象範囲_終了行index ※デフォルト:9999（10000行目）</param>
        /// <param name="colFrom">対象範囲_開始列index ※デフォルト:0（1列目）</param>
        /// <param name="colTo">対象範囲_終了列index ※デフォルト:49（50列目）</param>
        /// <remarks>
        /// 注意：<br />
        ///     １．本機能は、未入力セルに対する置換は行わない（「""⇒"入力"」のような置換は許可しない）<br />
        /// 　　２．性能劣化防止のため、置換対象範囲がある程度分かっている場合は引数で調整すること<br />
        /// 　　３．メモリ不足に陥る恐れがあるため、原則デフォルトの対象範囲を超えるような引数は設定しないこと<br />
        /// 　　　　⇒【OK】ReplaceValue("before", "after", 15, 10014, 5, 54);<br />
        /// 　　　　⇒【NG】ReplaceValue("before", "after", 10, 10014, 5, 59);
        /// </remarks>
        public void ReplaceValue(string oldValue, string newValue,
                                 int rowFrom = 0, int rowTo = 9999,
                                 int colFrom = 0, int colTo = 49)
        {
            var allReplaceValueFlg = ALL_REPLACE_VALUE_FLG;
            ALL_REPLACE_VALUE_FLG = true;

            if (string.IsNullOrEmpty(oldValue))
            {
                // 置換前の値が未設定の場合
                return;
            }

            for (int i = rowFrom; i <= rowTo; i++)
            {
                for (int j = colFrom; j <= colTo; j++)
                {
                    // セルオブジェクトがNullの場合はスキップ
                    var cellObj = Cell(i, j, false);
                    if (cellObj != null)
                    {
                        var cell = cellObj.GetValue();
                        if (cell == oldValue)
                        {
                            cellObj.SetValue(cell.Replace(oldValue, newValue));
                            if (!allReplaceValueFlg)
                            {
                                // 「ReplaceOneValue」から呼び出された場合
                                cellObj = null;
                                return;
                            }
                        }
                        cellObj = null;
                    }
                }
            }
        }

        /// <summary>
        /// ***************************************************************<br />
        /// シート内のセルを検索し、最初に検出した任意のセル値を置換する<br />
        /// ***************************************************************<br />
        /// </summary>
        /// <param name="oldValue">置換前の値</param>
        /// <param name="newValue">置換後の値</param>
        /// <param name="rowFrom">対象範囲_開始行index ※デフォルト:0（1行目）</param>
        /// <param name="rowTo">対象範囲_終了行index ※デフォルト:9999（10000行目）</param>
        /// <param name="colFrom">対象範囲_開始列index ※デフォルト:0（1列目）</param>
        /// <param name="colTo">対象範囲_終了列index ※デフォルト:49（50列目）</param>
        /// <remarks>
        /// 注意：<br />
        ///     １．本機能は、未入力セルに対する置換は行わない（「""⇒"入力"」のような置換は許可しない）<br />
        /// 　　２．性能劣化防止のため、置換対象範囲がある程度分かっている場合は引数で調整すること<br />
        /// 　　３．メモリ不足に陥る恐れがあるため、原則デフォルトの対象範囲を超えるような引数は設定しないこと<br />
        /// 　　　　⇒【OK】ReplaceValue("before", "after", 15, 10014, 5, 54);<br />
        /// 　　　　⇒【NG】ReplaceValue("before", "after", 10, 10014, 5, 59);
        /// </remarks>
        public void ReplaceOneValue(string oldValue, string newValue,
                                    int rowFrom = 0, int rowTo = 9999,
                                    int colFrom = 0, int colTo = 49)
        {
            ALL_REPLACE_VALUE_FLG = false;
            ReplaceValue(oldValue, newValue,
                         rowFrom, rowTo,
                         colFrom, colTo);
        }

        /// <summary>
        /// ***************************************************************<br />
        /// 任意のセルスタイルを複写する<br />
        /// ***************************************************************<br />
        /// </summary>
        /// <param name="copyFrom">コピー元セル</param>
        /// <param name="copyTo">コピー先セル</param>
        public void CopyCellStyle(XlsCell copyFrom, XlsCell copyTo)
        {
            copyTo.SetStyle(copyFrom.GetCellStyle());
        }

        /// <summary>
        /// ***************************************************************<br />
        /// 任意のセルを結合する<br />
        /// ***************************************************************<br />
        /// </summary>
        /// <param name="rowFrom">対象範囲_開始行index</param>
        /// <param name="rowTo">対象範囲_終了行index</param>
        /// <param name="colFrom">対象範囲_開始列index</param>
        /// <param name="colTo">対象範囲_終了列index</param>
        public void JoinCell(int rowFrom, int rowTo, int colFrom, int colTo)
        {
            _sheet.AddMergedRegion(new CellRangeAddress(rowFrom, rowTo, colFrom, colTo));
        }

        /// <summary>
        /// ***************************************************************<br />
        /// 非表示行の判定をする<br />
        /// ***************************************************************<br />
        /// </summary>
        /// <param name="rowIndex">行番号</param>
        /// <returns>true:非表示行 / false:表示行</returns>
        public bool IsZeroHeight(int rowIndex)
        {
            return _sheet.GetRow(rowIndex).ZeroHeight;
        }

        /// <summary>
        /// ***************************************************************<br />
        /// 用紙サイズの設定をする<br />
        /// ***************************************************************<br /> 
        /// </summary>
        /// <param name="paperSize">用紙サイズ</param>
        /// <remarks>A4: PaperSize.A4_TRANSVERSE_PAPERSIZE</remarks>
        public void SetPaperSize(short paperSize)
        {
            var printSetting = _sheet.PrintSetup;
            printSetting.PaperSize = paperSize;
        }

        /// <summary>
        /// ***************************************************************<br />
        /// 用紙を横向きに指定する<br />
        /// ***************************************************************<br /> 
        /// </summary>
        /// <param name="landscapeFlag">用紙横向き true:横向き false:縦向き</param>
        /// <remarks>true: 横向き　false:縦向き（デフォルト）</remarks>
        public void SetLandscape(bool landscapeFlag)
        {
            var printSetting = _sheet.PrintSetup;
            printSetting.Landscape = landscapeFlag;
        }

        /// <summary>
        /// ***************************************************************<br />
        /// 印刷タイトルの設定をする<br />
        /// ***************************************************************<br /> 
        /// </summary>
        /// <param name="firstRow">行タイトル開始行</param>
        /// <param name="lastRow">行タイトル終了行</param>
        /// <param name="firstCol">列タイトル開始列</param>
        /// <param name="lastCol">列タイトル終了列</param>
        /// <remarks>行タイトルの場合は　fistCol=-1, lastCol =-1 を設定します</remarks>
        public void SetRepeatingRows(int firstRow, int lastRow, int firstCol, int lastCol)
        {
            _sheet.RepeatingRows = new NPOI.SS.Util.CellRangeAddress(firstRow, lastRow, firstCol, lastCol);
        }

        /// <summary>
        /// ***************************************************************<br />
        /// 余白の設定をする<br />
        /// ***************************************************************<br /> 
        /// </summary>
        /// <param name="top">上余白</param>
        /// <param name="bottom">下余白</param>
        /// <param name="left">左余白</param>
        /// <param name="right">右余白</param>        
        public void SetMargin(double top, double bottom, double left, double right)
        {
            _sheet.SetMargin(MarginType.TopMargin, top);
            _sheet.SetMargin(MarginType.BottomMargin, bottom);
            _sheet.SetMargin(MarginType.LeftMargin, left);
            _sheet.SetMargin(MarginType.RightMargin, right);
        }

        /// <summary>
        /// ***************************************************************<br />
        /// 1ページの幅に全てをおさめる設定をする<br />
        /// ***************************************************************<br /> 
        /// </summary>        
        /// <param name="fit">true: 1ページにおさめる　false:おさめない</param>
        /// <remarks>true: 1ページにおさめる　false:おさめない</remarks>
        public void SetFitToPage(bool fit)
        {
            _sheet.FitToPage = fit;
        }

        /// <summary>
        /// ***************************************************************<br />
        /// 列幅を設定する<br />
        /// ***************************************************************<br />  
        /// </summary>
        /// <param name="colIndex">列番号</param>
        /// <param name="width">列幅</param>
        public void SetColumnWidth(int colIndex, int width)
        {
            _sheet.SetColumnWidth(colIndex, width);
        }

        /// <summary>
        /// ***************************************************************<br />
        /// ウィンドウ枠を分割固定する（行または列）<br />
        /// ***************************************************************<br />  
        /// </summary>
        /// <param name="colSplit">分割列</param>
        /// <param name="rowSplit">分割行</param>
        /// <param name="leftmostColumn">スクロール位置列</param>
        /// <param name="topRow">スクロール位置行</param>
        /// <remarks>先頭行で固定 : 0,1,0,1　先頭列で固定: 1,0,1,0 </remarks>
        public void CreateFreezePane(int colSplit, int rowSplit, int leftmostColumn, int topRow)
        {
            _sheet.CreateFreezePane(colSplit, rowSplit, leftmostColumn, topRow);
        }

        /// <summary>
        /// ***************************************************************<br />
        /// ウィンドウ枠を分割固定する（セル位置）<br />
        /// ***************************************************************<br />  
        /// </summary>
        /// <param name="colSplit">分割列</param>
        /// <param name="rowSplit">分割行</param>        
        /// <remarks>3列目2行目で固定 : 3, 2</remarks>
        public void CreateFreezePane(int colSplit, int rowSplit)
        {
            _sheet.CreateFreezePane(colSplit, rowSplit);
        }

        /// <summary>
        /// ***************************************************************<br />
        /// オートフィルタを設定する<br />
        /// ***************************************************************<br />   
        /// </summary>
        /// <param name="firstRow">対象開始行</param>
        /// <param name="lastRow">対象終了行</param>
        /// <param name="firstCol">対象開始列</param>
        /// <param name="lastCol">対象終了列</param>
        public void SetAutoFilter(int firstRow, int lastRow, int firstCol, int lastCol)
        {
            _sheet.SetAutoFilter(new CellRangeAddress(firstRow, lastRow, firstCol, lastCol));
        }

        /// <summary>
        /// ***************************************************************<br />
        /// 左側ヘッダーを設定する<br />
        /// ***************************************************************<br />   
        /// </summary>
        /// <param name="value">設定値</param>
        public void SetHeaderLeft(string value)
        {
            _sheet.Header.Left = value;
        }

        /// <summary>
        /// ***************************************************************<br />
        /// 中央部ヘッダーを設定する<br />
        /// ***************************************************************<br />   
        /// </summary>
        /// <param name="value">設定値</param>
        public void SetHeaderCenter(string value)
        {
            _sheet.Header.Center = value;
        }

        /// <summary>
        /// ***************************************************************<br />
        /// 右側ヘッダーを設定する<br />
        /// ***************************************************************<br />   
        /// </summary>
        /// <param name="value">設定値</param>
        public void SetHeaderRight(string value)
        {
            _sheet.Header.Right = value;
        }

        /// <summary>
        /// ***************************************************************<br />
        /// 左側フッターを設定する<br />
        /// ***************************************************************<br />   
        /// </summary>
        /// <param name="value">設定値</param>
        public void SetFooterLeft(string value)
        {
            _sheet.Footer.Left = value;
        }

        /// <summary>
        /// ***************************************************************<br />
        /// 中央部フッターを設定する<br />
        /// ***************************************************************<br />   
        /// </summary>
        /// <param name="value">設定値</param>
        public void SetFooterCenter(string value)
        {
            _sheet.Footer.Center = value;
        }
        /// <summary>
        /// ***************************************************************<br />
        /// 右側フッターを設定する<br />
        /// ***************************************************************<br />   
        /// </summary>
        /// <param name="value">設定値</param>
        public void SetFooterRight(string value)
        {
            _sheet.Footer.Right = value;
        }

        /// <summary>
        /// ***************************************************************<br />
        /// ページ番号を取得します。<br />
        /// ヘッダーフッター設定値用（返却値："&P"）<br />
        /// ***************************************************************<br />
        /// </summary>
        /// <returns>string</returns>
        public string GetPage()
        {
            return HeaderFooter.Page;
        }

        /// <summary>
        /// ***************************************************************<br />
        /// 総ページ数を取得します。<br />
        /// ヘッダーフッター設定値用（返却値："&N"）<br />
        /// ***************************************************************<br />
        /// </summary>
        /// <returns>string</returns>
        public string GetNumPages()
        {
            return HeaderFooter.NumPages;
        }

        /// <summary>
        /// ***************************************************************<br />
        /// 行の可視を切り替えます。
        /// ***************************************************************<br />
        /// </summary>
        /// <param name="rowIndex">対象行Index</param>
        /// <param name="visible">表示：true,非表示：false</param>
        public void ChangeRowVisible(int rowIndex, bool visible)
        {
            var row = _sheet.GetRow(rowIndex) ?? _sheet.CreateRow(rowIndex);
            row.Hidden = !(visible);
        }

        /// <summary>
        /// ***************************************************************<br />
        /// 行の改ページを挿入します。
        /// ***************************************************************<br />
        /// </summary>
        /// <param name="rowIndex">対象行Index</param>
        public void InsertRowBreak(int rowIndex)
        {
            _sheet.SetRowBreak(rowIndex);
        }

        /// <summary>
        /// ***************************************************************<br />
        /// 列の改ページを挿入します。
        /// ***************************************************************<br />
        /// </summary>
        /// <param name="colIndex">対象列Index</param>
        public void InsertColumnBreak(int colIndex)
        {
            _sheet.SetColumnBreak(colIndex);
        }

        /// <summary>
        /// ***************************************************************<br />
        /// シートの最終行インデックスを取得します
        /// ***************************************************************<br />
        /// </summary>
        /// <returns></returns>
        public int GetLastRowNum()
        {
            return _sheet.LastRowNum;
        }

        /// <summary>
        /// ***************************************************************<br />
        /// シートの最大列インデックスを取得します
        /// ***************************************************************<br />
        /// </summary>
        /// <returns></returns>
        public int GetLastCellNum()
        {
            int maxCol = 0;

            for (int i = 0; i <= _sheet.LastRowNum; i++)
            {
                var row = _sheet.GetRow(i) ?? _sheet.CreateRow(i);

                // 非表示の行は対象外
                if (row.ZeroHeight == false)
                {
                    if (maxCol < row.LastCellNum)
                    {
                        maxCol = row.LastCellNum;
                    }
                }
            }

            // LastCellNumは実際の最大数に1が加わっているので引く
            if (maxCol > 0)
            {
                maxCol--;
            }
            return maxCol;
        }

        /// <summary>
        /// ***************************************************************<br />
        /// シート名を取得します
        /// ***************************************************************<br />
        /// </summary>
        /// <returns></returns>
        public string SheetName()
        {
            return _sheet.SheetName;
        }

        /// <summary>
        /// ***************************************************************<br />
        /// ファイルを開くと時に数式を再計算させます。<br />
        /// ***************************************************************<br />
        /// </summary>
        public void ForceFormulaRecalculation()
        {
            _sheet.ForceFormulaRecalculation = true;
        }

        /// <summary>
        /// ***************************************************************<br />
        /// シートに画像を貼り付けます。<br />
        /// ***************************************************************<br />
        /// </summary>
        /// <param name="anchor">IClientAnchor</param>
        /// <param name="index">画像番号</param>
        public void DrawImage(IClientAnchor anchor, int index)
        {
            var patriarch = _sheet.CreateDrawingPatriarch();
            patriarch.CreatePicture(anchor, index);
        }

        /// <summary>
        /// ***************************************************************<br />
        /// シートに結合セルを作成します。<br />
        /// ***************************************************************<br />
        /// </summary>
        /// <param name="firstRow">開始行番号</param>
        /// <param name="lastRow">終了行番号</param>
        /// <param name="firstCol">開始列番号</param>
        /// <param name="lastCol">終了列番号</param>
        public void AddMergedRegion(int firstRow, int lastRow, int firstCol, int lastCol)
        {
            _sheet.AddMergedRegion(new CellRangeAddress(firstRow, lastRow, firstCol, lastCol));
        }

        public void RemoveRow(int row)
        {
            var row1 = _sheet.GetRow(row);
            _sheet.RemoveRow(row1);
        }

        public void CreateRow(int row)
        {
            _sheet.CreateRow(row);
        }
        public void ShiftRow(int row, short heght = 450)
        {
            var newRow = _sheet.GetRow(row);
            var newRow1 = _sheet.GetRow(11);
            if (newRow != null)
            {
                _sheet.ShiftRows(row, _sheet.LastRowNum, 1);
                newRow.Height = heght;
            }
            else
            {
                newRow = _sheet.CreateRow(row);
                newRow.Height = heght;
            }
            newRow1.CopyRowTo(row);
        }

        public void HeightRow(int row, short heght = 450)
        {
            var newRow = _sheet.GetRow(row);
            if (newRow != null)
            {
                _sheet.GetRow(row).Height = heght;
            }
            else
            {
                newRow = _sheet.CreateRow(row);
                newRow.Height = heght;
            }
        }
    }

    /// <summary>
    /// ***************************************************************<br />
    /// Excelセル<br />
    /// ***************************************************************<br />
    /// </summary>
    public class XlsCell
    {
        private ICell _cell = null;

        /// <summary>
        /// ***************************************************************<br />
        /// コンストラクタ<br />
        /// ***************************************************************<br />
        /// </summary>
        /// <param name="cell"></param>
        public XlsCell(ICell cell)
        {
            _cell = cell;
        }

        /// <summary>
        /// ***************************************************************<br />
        /// セルに値を設定します。（string）<br />
        /// ***************************************************************<br />
        /// </summary>
        /// <param name="value">設定値</param>
        public void SetValue(string value)
        {
            _cell.SetCellValue(value);
        }

        /// <summary>
        /// ***************************************************************<br />
        /// セルに値を設定します。（int）<br />
        /// ***************************************************************<br />
        /// </summary>
        /// <param name="value">設定値</param>
        public void SetValue(int value)
        {
            _cell.SetCellValue(value);
        }

        /// <summary>
        /// ***************************************************************<br />
        /// セルに値を設定します。（double）<br />
        /// ***************************************************************<br />
        /// </summary>
        /// <param name="value">設定値</param>
        public void SetValue(double value)
        {
            _cell.SetCellValue(value);
        }

        /// <summary>
        /// ***************************************************************<br />
        /// セルに数式を設定します。<br />
        /// ***************************************************************<br />
        /// </summary>
        /// <param name="formula">設定値</param>
        public void SetFormula(string formula)
        {
            _cell.SetCellFormula(formula);
        }

        /// <summary>
        /// ***************************************************************<br />
        /// セルにスタイルを設定します。<br />
        /// ***************************************************************<br />
        /// </summary>
        /// <param name="value">設定値</param>
        public void SetStyle(ICellStyle style)
        {
            _cell.CellStyle = style;
        }

        public void SetCellType()
        {
            _cell.SetCellType(CellType.Numeric);
        }
        /// <summary>
        /// ***************************************************************<br />
        /// セルのスタイルを取得します。<br />
        /// ***************************************************************<br />
        /// </summary>
        /// <returns>ICellStyle</returns>
        public ICellStyle GetCellStyle()
        {
            return _cell.CellStyle;
        }

        /// <summary>
        /// ***************************************************************<br />
        /// セルのタイプを取得します。<br />
        /// ***************************************************************<br />
        /// </summary>
        /// <returns>ICellStyle</returns>
        public CellType GetCellType()
        {
            return _cell.CellType;
        }

        /// <summary>
        /// ***************************************************************<br />
        /// セルの改行を有効にします。<br />
        /// ***************************************************************<br />
        /// </summary>
        public void EnableWrapText()
        {
            var style = _cell.CellStyle;
            style.WrapText = true;
        }

        /// <summary>
        /// ***************************************************************<br />
        /// セルから値を取得します。<br />
        /// ***************************************************************<br />
        /// </summary>
        /// <returns>設定値</returns>
        public string GetValue()
        {
            string value = string.Empty;
            if (_cell.CellType == CellType.Numeric)
            {
                if (DateUtil.IsCellDateFormatted(_cell))
                {
                    value = DateTime.Parse(_cell.DateCellValue.ToString()).ToString("yyyy/MM/dd");
                }
                else
                {
                    if (IsBuildinDateFormat(_cell.CellStyle.DataFormat))
                    {
                        value = DateTime.Parse(_cell.DateCellValue.ToString()).ToString(GetBuildinFormatString(_cell.CellStyle));
                    }
                    else
                    {
                        value = string.Format("{0}", _cell.NumericCellValue);
                    }
                }
            }
            else if (_cell.CellType == CellType.Formula)
            {
                value = GetStringFormulaValue();
            }
            else
            {
                value = _cell.StringCellValue;
            }
            return value;
        }


        /// <summary>
        /// FormatID に合わせて日付を返す
        /// </summary>
        /// <param name="style"></param>
        /// <returns></returns>
        private string GetBuildinFormatString(ICellStyle style)
        {
            // TODO　時間の設定

            switch (style.DataFormat)
            {
                case 14: return "yyyy/M/d"; //yyyy/m/d
                case 22: return "yyyy/M/d H:mm"; //yyyy/m/d h:mm
                case 30: return "M/d/yy";
                case 31: return "yyyy年M月d日";
                case 55: return "yyyy年M月"; //yyyy年m月
                case 56: return "M月d日"; //m月d日
                case 57: return "yyyy.M.d"; //[$-411]ge.m.d
                case 58: return "yyyy年M月d日"; //[$-411]ggge年m月d日
                default: return style.GetDataFormatString();
            }
        }

        /// <summary>
        /// フォーマットインデックスが日付型は Trueを返す　
        /// </summary>
        /// <param name="formatIndex"></param>
        /// <returns></returns>
        private bool IsBuildinDateFormat(int formatIndex)
            => ((30 <= formatIndex && formatIndex <= 31) || (55 <= formatIndex && formatIndex <= 58)) || DateUtil.IsInternalDateFormat(formatIndex);


        /// <summary>
        /// ***************************************************************<br />
        /// セルから表示通りの値を文字列として取得します。<br />
        /// ***************************************************************<br />
        /// </summary>
        /// <returns>設定値</returns>
        public string GetDispValue()
        {
            DataFormatter formatter = new DataFormatter();
            string value = formatter.FormatCellValue(_cell);
            // FormatCellValue は末尾に「_ 」が付与された文字列を返却することがあるため対処
            if (value.EndsWith("_ "))
            {
                value = value.Substring(0, value.Length - 2);
            }
            return value;
        }

        /// <summary>
        /// ***************************************************************<br />
        /// セルから表示形式を文字列として取得します。<br />
        /// ***************************************************************<br />
        /// </summary>
        /// <returns>設定値</returns>
        public string GetDataFormatValue()
        {
            var style = _cell.CellStyle;
            var value = style.GetDataFormatString();
            // GetDataFormatString は末尾に「_ 」が付与された文字列を返却することがあるため対処
            if (value.EndsWith("_ "))
            {
                value = value.Substring(0, value.Length - 2);
            }
            return value;
        }

        // セルの数式を計算し、Stringとして取得する例
        private string GetStringFormulaValue()
        {
            ISheet sheet = this._cell.Sheet;
            IWorkbook workbook = sheet.Workbook;
            IFormulaEvaluator formula = WorkbookFactory.CreateFormulaEvaluator(workbook);
            CellValue cellValue;
            try
            {
                try
                {
                    cellValue = formula.Evaluate(this._cell);
                }
                catch (NPOI.Util.RuntimeException)
                {
                    // NPOI.Util.RuntimeException（関数が解析できない等）が発生した場合
                    try
                    {
                        return _cell.StringCellValue;
                    }
                    catch (InvalidOperationException)
                    {
                        // InvalidOperationExceptionが発生した場合
                        if (DateUtil.IsCellDateFormatted(_cell))
                        {
                            return DateTime.Parse(_cell.DateCellValue.ToString()).ToString("yyyy/MM/dd HH:mm:ss");
                        }
                        else
                        {
                            return string.Format("{0}", _cell.NumericCellValue);
                        }
                    }
                }
            }
            catch (Exception)
            {
                // 例外発生時
                try
                {
                    var errorCode = _cell.ErrorCellValue;
                    var error = FormulaError.ForInt(errorCode);
                    return error.String;
                }
                catch (Exception)
                {
                    // 例外発生時
                    throw;
                }
            }

            switch (cellValue.CellType)
            {
                case CellType.String:
                    return cellValue.StringValue;
                case CellType.Numeric:
                    if (DateUtil.IsCellDateFormatted(this._cell))
                    {
                        return DateTime.Parse(_cell.DateCellValue.ToString()).ToString("yyyy/MM/dd HH:mm:ss");
                    }
                    else
                    {
                        return string.Format("{0}", this._cell.NumericCellValue);
                    }
                default:
                    break;
            }

            return "";
        }

    }
}
