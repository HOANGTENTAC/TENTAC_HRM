using NPOI.SS.UserModel;
using NPOI.SS.Util;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace TENTAC_HRM.Common
{
    class XlsCommon
    {

        /// <summary>
        /// Excelの文字列でのセル座標からセルの値を取得する
        /// </summary>
        /// <param name="zahyo">A1、AB10など</param>
        /// <param name="sheet">シートオブジェクト</param>
        /// <returns>セルの値を文字列で返す</returns>
        public static string GetCellValue(string zahyo, ISheet sheet)
        {
            var reference = new CellReference(zahyo);

            // 行を取得
            var row = sheet.GetRow(reference.Row);
            if (row == null)
            {
                return "";
            }

            // セルを取得
            ICell cell = row.GetCell(reference.Col);
            if (cell == null)
            {
                return "";
            }

            // セルの値を取得
            string value = "";
            switch (cell.CellType)
            {
                case CellType.String:
                    value = cell.StringCellValue;
                    break;
                case CellType.Numeric:
                    value = cell.NumericCellValue.ToString();
                    break;
                case CellType.Boolean:
                    value = cell.BooleanCellValue.ToString();
                    break;
            }

            return value;
        }

        public static string GetCellValue(string zahyo, ISheet sheet, string type)
        {
            var reference = new CellReference(zahyo);

            // 行を取得
            var row = sheet.GetRow(reference.Row);
            if (row == null)
            {
                return "";
            }

            // セルを取得
            ICell cell = row.GetCell(reference.Col);
            if (cell == null)
            {
                return "";
            }

            // セルの値を取得
            string value = "";
            switch (type)
            {
                case "string":
                    value = cell.StringCellValue;
                    break;
                case "numeric":
                    value = cell.NumericCellValue.ToString();
                    break;
                case "boolean":
                    value = cell.BooleanCellValue.ToString();
                    break;
                case "time":
                    value = cell.DateCellValue.ToString();
                    break;
            }

            return value;
        }

        /// <summary>
        /// 数値でのセル座標からセルの値を取得する
        /// </summary>
        /// <param name="gyo"></param>
        /// <param name="retsu"></param>
        /// <param name="sheet"></param>
        /// <returns></returns>
        public static string GetCellValue(int gyo, int retsu, ISheet sheet)
        {
            gyo--;
            retsu--;

            // インデックス指定でセル情報を取得（インデックスは0始まり）
            ICell cell = sheet.GetRow(gyo).GetCell(retsu);
            if (cell == null)
            {
                return "";
            }

            string value = "";
            // セルの値を取得
            switch (cell.CellType)
            {
                case CellType.String:
                    value = cell.StringCellValue;
                    break;
                case CellType.Numeric:
                    value = cell.NumericCellValue.ToString();
                    break;
                case CellType.Boolean:
                    value = cell.BooleanCellValue.ToString();
                    break;
            }

            return value;
        }

        /// <summary>
        /// Excelのセル座標から日付形式の値をyyyy/MM/dd形式で取得する
        /// </summary>
        /// <param name="zahyo">A1、AB10など</param>
        /// <param name="sheet"></param>
        /// <returns></returns>
        public static string GetDateCellValue(string zahyo, ISheet sheet)
        {
            var reference = new CellReference(zahyo);

            // 行を取得
            var row = sheet.GetRow(reference.Row);
            if (row == null)
            {
                return "";
            }

            // セルを取得
            ICell cell = row.GetCell(reference.Col);
            if (cell == null)
            {
                return "";
            }

            // セルの値を取得
            if (cell.CellType == CellType.Numeric)
            {
                if (DateUtil.IsCellDateFormatted(cell))
                {
                    // 日付型
                    return DateTime.Parse(cell.DateCellValue.ToString()).ToString("yyyy/MM/dd");
                }
                else
                {
                    // 数値型
                    double value = cell.NumericCellValue;
                    try
                    {
                        // シリアル値を日付型に変換
                        DateTime dt = DateTime.FromOADate(value);
                        return dt.ToString("yyyy/MM/dd");
                    }
                    catch
                    {
                        return "";
                    }
                }
            }

            // 2022/06/24 yyyy/mm/ddに変換できなかった場合は空を返すように変更
            return "";
        }


        /// <summary>
        /// AからZのインデックスを返す。
        /// 例えば、引数がAの時は1、Bの時は2、AAの時は27となる。
        /// 引数が不正な場合は-1を返す。
        /// </summary>
        /// <param name="name">アルファベット。半角大文字のみ有効</param>
        /// <returns>インデックス</returns>
        public static int ToAlphabetIndex(string alphabet)
        {
            if (string.IsNullOrEmpty(alphabet))
            {
                return -1;
            }

            if (new Regex("^[A-Z]+$").IsMatch(alphabet))
            {
                int index = 0;
                for (int i = 0; i < alphabet.Length; i++)
                {
                    // ASCIIではAは10進数で65
                    int num = Convert.ToChar(alphabet[alphabet.Length - i - 1]) - 65;
                    // A-Zの変換が0-25になっているため1を足して、A-Zが1-26になるようにする
                    num++;

                    index += (int)(num * Math.Pow(26, i));
                }
                return index;
            }

            return -1;
        }

        /// <summary>
        /// シート内の結合セルの座標を数値で取得しモデルに格納する
        /// </summary>
        /// <param name="sheet"></param>
        public static void GetMergeCellIndex(ISheet sheet)
        {
            XlsValueModel.mergeCells = new Dictionary<Dictionary<int, int>, Dictionary<int, int>>();

            CellRangeAddress[][] mergedRanges = new CellRangeAddress[1][];
            for (int m = 0; m < sheet.NumMergedRegions; m++)
            {
                CellRangeAddress cellRangeAddress = sheet.GetMergedRegion(m);

                int firstRow = cellRangeAddress.FirstRow;
                int firstColumn = cellRangeAddress.FirstColumn;
                var first = new Dictionary<int, int>() { { firstRow, firstColumn } };

                int lastRow = cellRangeAddress.LastRow;
                int lastColumn = cellRangeAddress.LastColumn;
                var last = new Dictionary<int, int>() { { lastRow, lastColumn } };

                XlsValueModel.mergeCells.Add(first, last);
            }
        }

        /// <summary>
        /// 指定の座標からいくつセルが結合されているかを取得する
        /// </summary>
        /// <param name="gyo"></param>
        /// <param name="retsu"></param>
        /// <param name="isColumn"></param>
        /// <returns></returns>
        public static int MergeCellCount(int gyo, int retsu, bool isColumn = false)
        {
            // 不正な座標
            if (retsu < 1 || gyo < 1)
            {
                return 0;
            }

            // インデックスを合わせるためにデクリメント
            gyo--;
            retsu--;

            foreach (var zahyoSet in XlsValueModel.mergeCells)
            {
                foreach (var start in zahyoSet.Key)
                {
                    foreach (var last in zahyoSet.Value)
                    {
                        if (gyo >= start.Key && retsu >= start.Value &&
                            gyo <= last.Key && retsu <= last.Value)
                        {
                            if (isColumn)
                            {
                                return last.Value - retsu + 1;
                            }
                            else
                            {
                                return last.Key - gyo + 1;
                            }
                        }
                    }
                }
            }

            // 結合セルではない場合は1を返す
            return 1;
        }
    }
}
