using iTextSharp.text;
using iTextSharp.text.pdf;
using iTextSharp.tool.xml;
using MailKit.Net.Smtp;
using MimeKit;
using NPOI.SS.UserModel;
using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Windows.Forms;
using TENTAC_HRM.Common;
using TENTAC_HRM.Custom;
using TENTAC_HRM.Models.CommonModel;
using Excel = Microsoft.Office.Interop.Excel;
using Font = iTextSharp.text.Font;
using Image = iTextSharp.text.Image;

namespace TENTAC_HRM.Forms.Luong
{
    public partial class frm_GuiBangLuongEmail : Form
    {
        public frm_GuiBangLuongEmail(int[] permissions = null)
        {
            InitializeComponent();
        }

        private void frm_GuiBangLuongEmail_Load(object sender, EventArgs e)
        {
            BindGrid();
        }
        CheckBox headerCheckBox = new CheckBox();
        string filepaths = "";
        private ISheet xlSheet = null;
        private void BindGrid()
        {
            //Find the Location of Header Cell.
            Point headerCellLocation = this.DGV_NhanVien.GetCellDisplayRectangle(0, -1, true).Location;

            //Place the Header CheckBox in the Location of the Header Cell.
            headerCheckBox.Location = new Point(headerCellLocation.X + 8, headerCellLocation.Y + 2);
            headerCheckBox.BackColor = System.Drawing.Color.Transparent;
            headerCheckBox.Size = new Size(18, 18);

            //Assign Click event to the Header CheckBox.
            headerCheckBox.Click += new EventHandler(HeaderCheckBox_Clicked);
            DGV_NhanVien.Controls.Add(headerCheckBox);
        }
        private void HeaderCheckBox_Clicked(object sender, EventArgs e)
        {
            //Necessary to end the edit mode of the Cell.
            DGV_NhanVien.EndEdit();

            //Loop and check and uncheck all row CheckBoxes based on Header Cell CheckBox.
            foreach (DataGridViewRow row in DGV_NhanVien.Rows)
            {
                DataGridViewCheckBoxCell checkBox = (row.Cells["col_check"] as DataGridViewCheckBoxCell);
                checkBox.Value = headerCheckBox.Checked;
            }
        }
        private void Btn_ImportExcel_Click(object sender, EventArgs e)
        {
            try
            {
                OpenFileDialog file = new OpenFileDialog();
                file.InitialDirectory = PathModel.ExcelPathValue;
                if (file.ShowDialog() == DialogResult.OK)
                {
                    filepaths = file.FileName;
                    var fileExt = Path.GetExtension(file.FileName);
                    if (fileExt.CompareTo(".xls") == 0 || fileExt.CompareTo(".xlsx") == 0)
                    {
                        Cursor.Current = Cursors.WaitCursor;
                        IWorkbook xlBook = null;
                        try
                        {
                            using (FileStream inputStream = new FileStream(file.FileName, FileMode.Open, FileAccess.Read))
                            {
                                xlBook = WorkbookFactory.Create(inputStream);
                            }
                        }
                        catch (Exception ex)
                        {
                            throw new Exception("File " + file.FileName + " đang mở vui lòng đóng file vào thao tác lại!", ex);
                        }
                        int countsheet = 0;
                        for (int i = 0; i < xlBook.NumberOfSheets; i++)
                        {
                            if (xlBook.IsSheetHidden(i))
                            {
                                continue;
                            }
                            else
                            {
                                countsheet++;
                            }

                            if (countsheet == 2)
                            {
                                this.xlSheet = xlBook.GetSheetAt(i);
                                int row = 8;
                                List<NhanVienModel> list = new List<NhanVienModel>();
                                for (int j = 8; j <= row + 1000; j++)
                                {
                                    string ma_nhanvien = Range("B" + j);
                                    if (string.IsNullOrEmpty(ma_nhanvien))
                                    {
                                        break;
                                    }

                                    list.Add(new NhanVienModel()
                                    {
                                        col_check = false,
                                        MaNhanVien = ma_nhanvien.ToString(),
                                        TenNhanVien = Range("E" + j).ToString(),
                                        PhongBan = Range("C" + j).ToString(),
                                        Email = Range("BG" + j).ToString()
                                    });
                                }
                                DGV_NhanVien.DataSource = list;
                                Lbl_Count.Text = list.Count.ToString() + " Dòng";
                            }
                        }
                        Cursor.Current = Cursors.Default;
                    }
                }
            }
            catch (Exception)
            {

                throw;
            }
        }
        private string Range(string zahyo)
        {
            return XlsCommon.GetCellValue(zahyo, xlSheet);
        }

        private void Btn_SendMail_Click(object sender, EventArgs e)
        {
            if (DGV_NhanVien.Rows.Count > 0)
            {
                int count = 0;
                int countfalse = 0;
                string nhanvienloi = "";
                Cursor.Current = Cursors.WaitCursor;
                //var xlsBook = new XlsWorkBook(filepaths);

                Excel.Application oExcel = new Excel.Application();
                Excel.Workbook WB = oExcel.Workbooks.Open(filepaths);
                Excel.Worksheet wks = (Excel.Worksheet)WB.Worksheets["Form r1"];

                try
                {
                    var asm = Assembly.GetEntryAssembly();
                    string filepath = $@"{Path.GetDirectoryName(asm.Location)}\Template\PhieuLuong.html";
                    StreamReader read = new StreamReader(filepath, Encoding.Unicode);
                    string html_template = read.ReadToEnd();

                    var checkedRows = from DataGridViewRow r in DGV_NhanVien.Rows
                                      where Convert.ToBoolean(r.Cells["col_check"].Value) == true
                                      select r;

                    string fileMailInfo = $@"{Path.GetDirectoryName(asm.Location)}\Template\InfoMail.txt";
                    string infoFile = File.ReadAllText(fileMailInfo);
                    List<string> listInfo = new List<string>();
                    listInfo = infoFile.Split(';').ToList();
                    foreach (var item in checkedRows)
                    {
                        if (Convert.ToBoolean(item.Cells["col_check"].Value) == true && !string.IsNullOrEmpty(item.Cells["Email"].Value.ToString()))
                        {
                            SmtpClient client = new SmtpClient();
                            try
                            {
                                string html = html_template;
                                Byte[] bytes;
                                //var xlsSheet = xlsBook.Sheet(i);
                                //xlsSheet.Cell(3, 2).SetValue(item.Cells["MaNhanVien"].Value.ToString());

                                ((Excel.Range)wks.Cells[4, 3]).Value = item.Cells["MaNhanVien"].Value.ToString();

                                string Thang = ((Excel.Range)wks.Cells[2, 5]).Value;
                                //// Thong tin cong nhan vien
                                string MaNhanVien = Convert.ToString(((Excel.Range)wks.Cells[4, 3]).Value);
                                string BoPhan = Convert.ToString(((Excel.Range)wks.Cells[6, 3]).Value);
                                string HoTen = Convert.ToString(((Excel.Range)wks.Cells[5, 3]).Value);
                                string ChucVu = Convert.ToString(((Excel.Range)wks.Cells[7, 3]).Value);
                                string STK = Convert.ToString(((Excel.Range)wks.Cells[8, 3]).Value);
                                string NganHang = Convert.ToString(((Excel.Range)wks.Cells[4, 5]).Value);
                                string Email = Convert.ToString(((Excel.Range)wks.Cells[5, 5]).Value);
                                string NgayTraLuong = DateTime.Parse(((Excel.Range)wks.Cells[6, 5]).Value.ToString()).ToString();
                                string NgayPhepConLai = Convert.ToString(((Excel.Range)wks.Cells[7, 5]).Value);
                                // Luong theo hop dong lao dong
                                string LuongTheoHopDong = Convert.ToString(((Excel.Range)wks.Cells[9, 4]).Value);
                                string LuongCoBan = Convert.ToString(((Excel.Range)wks.Cells[10, 3]).Value);
                                string TC_TrachNhiem = Convert.ToString(((Excel.Range)wks.Cells[11, 3]).Value);
                                string TC_DocHai = Convert.ToString(((Excel.Range)wks.Cells[12, 3]).Value);
                                string TC_XeNang = Convert.ToString(((Excel.Range)wks.Cells[13, 3]).Value);
                                string TC_Nha = Convert.ToString(((Excel.Range)wks.Cells[14, 3]).Value);
                                string TC_DiLai = Convert.ToString(((Excel.Range)wks.Cells[10, 5]).Value);
                                string TC_ChuyenCan = Convert.ToString(((Excel.Range)wks.Cells[11, 3]).Value);
                                string TC_Khac = Convert.ToString(((Excel.Range)wks.Cells[12, 3]).Value);
                                // Tong thu nhap thuc te
                                string TongThuNhapThucTe = Convert.ToString(((Excel.Range)wks.Cells[15, 4]).Value);
                                string CongThuViec = Convert.ToString(((Excel.Range)wks.Cells[16, 3]).Value);
                                string LuongThuViec = Convert.ToString(((Excel.Range)wks.Cells[17, 3]).Value);
                                string CongLamChinhThuc = Convert.ToString(((Excel.Range)wks.Cells[18, 3]).Value);
                                string LuongChinhThuc = Convert.ToString(((Excel.Range)wks.Cells[19, 3]).Value);
                                string CaDem30 = Convert.ToString(((Excel.Range)wks.Cells[20, 3]).Value);
                                string TienCaDem = Convert.ToString(((Excel.Range)wks.Cells[21, 3]).Value);
                                string TangCa150 = Convert.ToString(((Excel.Range)wks.Cells[22, 3]).Value);
                                string TienTangCa150 = Convert.ToString(((Excel.Range)wks.Cells[23, 3]).Value);
                                string TangCa200 = Convert.ToString(((Excel.Range)wks.Cells[24, 3]).Value);
                                string TienTangCa200 = Convert.ToString(((Excel.Range)wks.Cells[25, 3]).Value);
                                string TangCa210 = Convert.ToString(((Excel.Range)wks.Cells[26, 3]).Value);
                                string TienTangCa210 = Convert.ToString(((Excel.Range)wks.Cells[27, 3]).Value);
                                string TangCa270 = Convert.ToString(((Excel.Range)wks.Cells[28, 3]).Value);
                                string TienTangCa270 = Convert.ToString(((Excel.Range)wks.Cells[29, 3]).Value);
                                string TangCa300 = Convert.ToString(((Excel.Range)wks.Cells[30, 3]).Value);
                                string TienTangCa300 = Convert.ToString(((Excel.Range)wks.Cells[31, 3]).Value);
                                string TC_TrachNhiem_TT = Convert.ToString(((Excel.Range)wks.Cells[16, 3]).Value);
                                string TC_DocHai_TT = Convert.ToString(((Excel.Range)wks.Cells[17, 3]).Value);
                                string TC_KyNang = Convert.ToString(((Excel.Range)wks.Cells[18, 3]).Value);
                                string TC_Nha_TT = Convert.ToString(((Excel.Range)wks.Cells[19, 3]).Value);
                                string TC_DiLai_TT = Convert.ToString(((Excel.Range)wks.Cells[20, 3]).Value);
                                string TC_ChuyenCan_TT = Convert.ToString(((Excel.Range)wks.Cells[21, 3]).Value);
                                string TC_PCCC = Convert.ToString(((Excel.Range)wks.Cells[22, 3]).Value);
                                string TC_GuiTre = Convert.ToString(((Excel.Range)wks.Cells[23, 3]).Value);
                                string TC_ATVSV = Convert.ToString(((Excel.Range)wks.Cells[24, 3]).Value);
                                string TC_PhuNu = Convert.ToString(((Excel.Range)wks.Cells[25, 3]).Value);
                                string TienTangCa = Convert.ToString(((Excel.Range)wks.Cells[26, 3]).Value);
                                string TC_Khac_TT = Convert.ToString(((Excel.Range)wks.Cells[27, 3]).Value);
                                string DieuChinh = Convert.ToString(((Excel.Range)wks.Cells[28, 3]).Value);
                                // cac khoan thu nhap khac
                                string SoNgayPhepThua = Convert.ToString(((Excel.Range)wks.Cells[33, 3]).Value);
                                string TienPhepThua = Convert.ToString(((Excel.Range)wks.Cells[34, 3]).Value);
                                // Tien thuong
                                string LuongCoBan_Thuong = Convert.ToString(((Excel.Range)wks.Cells[36, 3]).Value);
                                string TC_TinhThuong = Convert.ToString(((Excel.Range)wks.Cells[37, 3]).Value);
                                string CanCuTinhThuong = Convert.ToString(((Excel.Range)wks.Cells[38, 3]).Value);
                                string XepLoaiCuoiCung = Convert.ToString(((Excel.Range)wks.Cells[39, 3]).Value);
                                string TyLeThuong = Convert.ToString(((Excel.Range)wks.Cells[40, 3]).Value);
                                string HeSoTinh = Convert.ToString(((Excel.Range)wks.Cells[41, 3]).Value);
                                string SoTienThuong = Convert.ToString(((Excel.Range)wks.Cells[36, 5]).Value);
                                string NgayTraLuong_Thuong = Convert.ToString(((Excel.Range)wks.Cells[37, 5]).Value);
                                string Khac = Convert.ToString(((Excel.Range)wks.Cells[36, 5]).Value);
                                string GhiChu = Convert.ToString(((Excel.Range)wks.Cells[37, 5]).Value);
                                // tong cac khoan giam tru luong
                                string TongCacKhoanGiamTruLuong = Convert.ToString(((Excel.Range)wks.Cells[42, 4]).Value);
                                string BaoHiemBatBuoc = Convert.ToString(((Excel.Range)wks.Cells[43, 3]).Value);
                                string DoanPhi = Convert.ToString(((Excel.Range)wks.Cells[44, 3]).Value);
                                string ThueThuNhapCaNhan = Convert.ToString(((Excel.Range)wks.Cells[45, 3]).Value);
                                string TruKhac = Convert.ToString(((Excel.Range)wks.Cells[46, 3]).Value);
                                string QuyPCT = Convert.ToString(((Excel.Range)wks.Cells[43, 5]).Value);
                                // thu nhap thuc linh
                                string ThuNhapThucLinh = Convert.ToString(((Excel.Range)wks.Cells[47, 4]).Value);
                                string GhiChu_ThucLinh = Convert.ToString(((Excel.Range)wks.Cells[48, 3]).Value);

                                html = html.Replace("[Thang]", Thang)
                                    .Replace("[ID]", MaNhanVien)
                                    .Replace("[HoTen]", HoTen)
                                    .Replace("[BoPhan]", BoPhan)
                                    .Replace("[ChucVu]", ChucVu)
                                    .Replace("[STK]", STK)
                                    .Replace("[NganHang]", NganHang)
                                    .Replace("[Email]", Email)
                                    .Replace("[NgayTraLuong]", DateTime.Parse(NgayTraLuong).ToString("dd/MM/yyyy"))
                                    .Replace("[NgayPhepConLai]", NgayPhepConLai)

                                    .Replace("[LuongTheoHopDong]", string.IsNullOrEmpty(LuongTheoHopDong) ? "0" : decimal.Parse(LuongTheoHopDong).ToString("#,##0"))
                                    .Replace("[LuongCoban]", string.IsNullOrEmpty(LuongCoBan) ? "0" : decimal.Parse(LuongCoBan).ToString("#,##0"))
                                    .Replace("[TC_TrachNhiem]", string.IsNullOrEmpty(TC_TrachNhiem) ? "0" : decimal.Parse(TC_TrachNhiem).ToString("#,##0"))
                                    .Replace("[TCDocHai]", string.IsNullOrEmpty(TC_DocHai) ? "0" : decimal.Parse(TC_DocHai).ToString("#,##0"))
                                    .Replace("[TC_XeNang]", string.IsNullOrEmpty(TC_XeNang) ? "0" : decimal.Parse(TC_XeNang).ToString("#,##0"))
                                    .Replace("[TC_Nha]", string.IsNullOrEmpty(TC_Nha) ? "0" : decimal.Parse(TC_Nha).ToString("#,##0"))
                                    .Replace("[TC_DiLai]", string.IsNullOrEmpty(TC_DiLai) ? "0" : decimal.Parse(TC_DiLai).ToString("#,##0"))
                                    .Replace("[TC_ChuyenCan]", string.IsNullOrEmpty(TC_ChuyenCan) ? "0" : decimal.Parse(TC_ChuyenCan).ToString("#,##0"))
                                    .Replace("[TC_Khac]", TC_Khac == "0" || string.IsNullOrEmpty(TC_Khac) ? "--" : TC_Khac)

                                    .Replace("[TongThuNhapThucTe]", string.IsNullOrEmpty(TongThuNhapThucTe) ? "0" : decimal.Parse(TongThuNhapThucTe).ToString("#,##0"))
                                    .Replace("[CongThuViec]", string.IsNullOrEmpty(CongThuViec) ? "0.0" : decimal.Parse(CongThuViec).ToString("#.0"))
                                    .Replace("[LuongThuViec]", LuongThuViec)
                                    .Replace("[CongLamChinhThuc]", string.IsNullOrEmpty(CongLamChinhThuc) ? "0.0" : decimal.Parse(CongLamChinhThuc).ToString("#.0"))
                                    .Replace("[LuongChinhThuc]", string.IsNullOrEmpty(LuongChinhThuc) ? "0" : decimal.Parse(LuongChinhThuc).ToString("#,##0"))
                                    .Replace("[CaDem]", string.IsNullOrEmpty(CaDem30) ? "0.0" : decimal.Parse(CaDem30).ToString("#.0"))
                                    .Replace("[TienCaDem]", TienCaDem)
                                    .Replace("[TangCa150]", string.IsNullOrEmpty(TangCa150) ? "0.0" : decimal.Parse(TangCa150).ToString("#.0"))
                                    .Replace("[TienTangCa150]", TienTangCa150)
                                    .Replace("[TangCa200]", string.IsNullOrEmpty(TangCa200) ? "0.0" : decimal.Parse(TangCa200).ToString("#.0"))
                                    .Replace("[TienTangCa200]", TienTangCa200)
                                    .Replace("[TangCa210]", string.IsNullOrEmpty(TangCa210) ? "0.0" : decimal.Parse(TangCa210).ToString("#.0"))
                                    .Replace("[TienTangCa210]", TienTangCa210)
                                    .Replace("[TangCa270]", string.IsNullOrEmpty(TangCa270) ? "0.0" : decimal.Parse(TangCa270).ToString("#.0"))
                                    .Replace("[TienTangCa270]", TienTangCa270)
                                    .Replace("[TangCa300]", string.IsNullOrEmpty(TangCa300) ? "0.0" : decimal.Parse(TangCa300).ToString("#.0"))
                                    .Replace("[TienTangCa300]", TienTangCa300)
                                    .Replace("[TC_TrachNhiem_TT]", string.IsNullOrEmpty(TC_TrachNhiem_TT) ? "0" : decimal.Parse(TC_TrachNhiem_TT).ToString("#,##0"))
                                    .Replace("[TC_DocHai_TT]", string.IsNullOrEmpty(TC_DocHai_TT) ? "0" : decimal.Parse(TC_DocHai_TT).ToString("#,##0"))
                                    .Replace("[TC_KyNang]", string.IsNullOrEmpty(TC_KyNang) ? "0" : decimal.Parse(TC_KyNang).ToString("#,##0"))
                                    .Replace("[TC_Nha_TT]", string.IsNullOrEmpty(TC_Nha_TT) ? "0" : decimal.Parse(TC_Nha_TT).ToString("#,##0"))
                                    .Replace("[TC_DiLai_TT]", string.IsNullOrEmpty(TC_DiLai_TT) ? "0" : decimal.Parse(TC_DiLai_TT).ToString("#,##0"))
                                    .Replace("[TC_ChuyenCan_TT]", string.IsNullOrEmpty(TC_ChuyenCan_TT) ? "0" : decimal.Parse(TC_ChuyenCan_TT).ToString("#,##0"))
                                    .Replace("[TC_PCCC]", string.IsNullOrEmpty(TC_PCCC) ? "0" : decimal.Parse(TC_PCCC).ToString("#,##0"))
                                    .Replace("[TC_GuiTre]", string.IsNullOrEmpty(TC_GuiTre) ? "0" : decimal.Parse(TC_GuiTre).ToString("#,##0"))
                                    .Replace("[TC_ATVSV]", string.IsNullOrEmpty(TC_ATVSV) ? "0" : decimal.Parse(TC_ATVSV).ToString("#,##0"))
                                    .Replace("[TC_PhuNu]", string.IsNullOrEmpty(TC_PhuNu) ? "0" : decimal.Parse(TC_PhuNu).ToString("#,##0"))
                                    .Replace("[TienTangCa]", string.IsNullOrEmpty(TienTangCa) ? "0" : decimal.Parse(TienTangCa).ToString("#,##0"))
                                    .Replace("[TC_Khac_TT]", TC_Khac_TT == "0" || string.IsNullOrEmpty(TC_Khac_TT) ? "--" : decimal.Parse(TC_Khac_TT).ToString("#,##0"))
                                    .Replace("[DieuChinh]", string.IsNullOrEmpty(DieuChinh) ? "0" : decimal.Parse(DieuChinh).ToString("#,##0"))

                                    .Replace("[SoNgayPhepThua]", SoNgayPhepThua == "0" || string.IsNullOrEmpty(SoNgayPhepThua) ? "--" : decimal.Parse(SoNgayPhepThua).ToString("#.0"))
                                    .Replace("[TienPhepThua]", TienPhepThua == "0" || string.IsNullOrEmpty(TienPhepThua) ? "--" : decimal.Parse(TienPhepThua).ToString("#,##0"))

                                    .Replace("[LuongCoBan]", LuongCoBan_Thuong == "0" || string.IsNullOrEmpty(LuongCoBan_Thuong) ? "--" : decimal.Parse(LuongCoBan_Thuong).ToString("#,##0"))
                                    .Replace("[TC_TinhThuong]", TC_TinhThuong == "0" || string.IsNullOrEmpty(TC_TinhThuong) ? "--" : decimal.Parse(TC_TinhThuong).ToString("#,##0"))
                                    .Replace("[CanCuTinhThuong]", CanCuTinhThuong == "0" || string.IsNullOrEmpty(CanCuTinhThuong) ? "--" : decimal.Parse(CanCuTinhThuong).ToString("#,##0"))
                                    .Replace("[XepLoaiCuoiCung]", (XepLoaiCuoiCung == "0" || string.IsNullOrEmpty(XepLoaiCuoiCung) ? "--" : XepLoaiCuoiCung))
                                    .Replace("[TyLeThuong]", TyLeThuong == "0" || string.IsNullOrEmpty(TyLeThuong) ? "--" : decimal.Parse(TyLeThuong).ToString("#.00"))
                                    .Replace("[HeSoTinh]", HeSoTinh == "0" || string.IsNullOrEmpty(HeSoTinh) ? "--" : decimal.Parse(HeSoTinh).ToString("#.00"))
                                    .Replace("[SoTienThuong]", SoTienThuong == "0" || string.IsNullOrEmpty(SoTienThuong) ? "--" : decimal.Parse(SoTienThuong).ToString("#,##0"))
                                    .Replace("[NgayTraThuong]", NgayTraLuong_Thuong == "0" || string.IsNullOrEmpty(NgayTraLuong_Thuong) ? "--" : NgayTraLuong_Thuong)
                                    .Replace("[Khac]", Khac == "0" || string.IsNullOrEmpty(Khac) ? "--" : Khac)
                                    .Replace("[GhiChu]", GhiChu == "0" || string.IsNullOrEmpty(GhiChu) ? "--" : GhiChu)

                                    .Replace("[TongCacKhoanGiamTruLuong]", string.IsNullOrEmpty(TongCacKhoanGiamTruLuong) ? "0" : decimal.Parse(TongCacKhoanGiamTruLuong).ToString("#,##0"))
                                    .Replace("[BaoHiemBatBuoc]", string.IsNullOrEmpty(BaoHiemBatBuoc) ? "0" : decimal.Parse(BaoHiemBatBuoc).ToString("#,##0"))
                                    .Replace("[DoanPhi]", string.IsNullOrEmpty(DoanPhi) ? "0" : decimal.Parse(DoanPhi).ToString("#,##0"))
                                    .Replace("[TTNCN]", string.IsNullOrEmpty(ThueThuNhapCaNhan) ? "0" : decimal.Parse(ThueThuNhapCaNhan).ToString("#,##0"))
                                    .Replace("[QuyPCTT]", QuyPCT == "0" || string.IsNullOrEmpty(QuyPCT) ? "--" : decimal.Parse(QuyPCT).ToString("#,##0"))
                                    .Replace("[TruKhac]", TruKhac)

                                    .Replace("[ThuNhapThucLinh]", string.IsNullOrEmpty(ThuNhapThucLinh) ? "0" : decimal.Parse(ThuNhapThucLinh).ToString("#,##0"))
                                    .Replace("[GhiChu_ThucLinh]", (GhiChu_ThucLinh == "0" || string.IsNullOrEmpty(GhiChu_ThucLinh) ? "--" : GhiChu_ThucLinh));
                                nhanvienloi = MaNhanVien + " email : " + item.Cells["Email"].Value.ToString();
                                using (var memoryStream = new MemoryStream())
                                {
                                    var document = new Document(PageSize.A4, 20, 20, 20, 20);
                                    var writer = PdfWriter.GetInstance(document, memoryStream);
                                    document.Open();
                                    Image imghead = Image.GetInstance($@"{Path.GetDirectoryName(asm.Location)}\Template\Logo.png");
                                    imghead.ScaleToFit(140f, 100f);
                                    document.Add(imghead);
                                    //using (var cssMemoryStream = new MemoryStream(Encoding.UTF8.GetBytes(cssText)))
                                    //{
                                    using (var htmlMemoryStream = new MemoryStream(Encoding.UTF8.GetBytes(html.ToString())))
                                    {
                                        XMLWorkerHelper.GetInstance().ParseXHtml(writer, document, htmlMemoryStream, null, Encoding.UTF8, new UnicodeFontFactory());
                                    }
                                    //}
                                    document.Close();

                                    bytes = memoryStream.ToArray();
                                }

                                //var testFile = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.Desktop), MaNhanVien + "_" + HoTen + ".pdf");
                                var testFile = Path.Combine(Path.GetTempPath(), MaNhanVien + "_" + HoTen + ".pdf");
                                System.IO.File.WriteAllBytes(testFile, bytes);

                                //Send mail
                                string emailAddress = listInfo[0].Replace("EmailAddress: ", "").TrimStart();
                                string password = listInfo[1].Replace("Password: ", "").TrimStart();
                                MimeMessage message = new MimeMessage();
                                message.From.Add(new MailboxAddress("PHIEU LUONG", emailAddress));
                                //message.To.Add(MailboxAddress.Parse("toiluoncodon1996@gmail.com"));
                                message.To.Add(new MailboxAddress(HoTen, item.Cells["Email"].Value.ToString()));
                                message.Subject = listInfo[2].Replace("Subject: ", "").TrimStart();
                                var emailBody = new MimeKit.BodyBuilder
                                {
                                    TextBody = listInfo[3]
                                    .Replace("[HoTen]", HoTen)
                                    .Replace("TextBody:", "").TrimStart()
                                    .Replace("TuThang", "01/" + Thang)
                                    .Replace("DenThang", DateTime.Parse(Thang).AddMonths(1).AddDays(-1).ToString("dd/MM/yyyy")).TrimStart()
                                };
                                emailBody.Attachments.Add(testFile);
                                message.Body = emailBody.ToMessageBody();
                                client.Connect("smtp.gmail.com", 465, true);
                                client.Authenticate(emailAddress, password);
                                client.Send(message);
                                if (File.Exists(testFile))
                                {
                                    File.Delete(testFile);
                                }
                                count++;
                            }
                            catch (Exception ex)
                            {
                                countfalse++;
                                throw new Exception(ex.Message);
                            }
                            finally
                            {
                                client.Disconnect(true);
                                client.Dispose();
                            }
                        }
                    }
                    txt_noti.Text = "Số mail gửi thành công : " + count + Environment.NewLine +
                                    "Số mail gửi thất bại : 0 " + Environment.NewLine +
                                    "Tổng mail : " + DGV_NhanVien.Rows.Count;
                    nhanvienloi = "";
                    RJMessageBox.Show("Gửi mail thành công");
                    WB.Save();
                    WB.Close();
                }
                catch (Exception ex)
                {
                    WB.Save();
                    WB.Close();
                    txt_noti.Text = "Số mail gửi thành công : " + count + Environment.NewLine +
                    "Số mail gửi thất bại : 1" + Environment.NewLine +
                    "Thông tin : " + nhanvienloi + Environment.NewLine +
                    "Tổng mail : " + DGV_NhanVien.Rows.Count;
                    RJMessageBox.Show(ex.Message);
                }
                Cursor.Current = Cursors.Default;
            }
            else
            {
                RJMessageBox.Show("Chưa có danh sách để gửi mail");
            }
        }

        private void Btn_Setting_Click(object sender, EventArgs e)
        {
            frm_Setting frm = new frm_Setting();
            frm.ShowDialog();
        }

        private void btn_TestMail_Click(object sender, EventArgs e)
        {
            Cursor.Current = Cursors.WaitCursor;
            SmtpClient client = new SmtpClient();
            try
            {
                var asm = Assembly.GetEntryAssembly();
                string filepath = $@"{Path.GetDirectoryName(asm.Location)}\Template\PhieuLuong.html";
                StreamReader read = new StreamReader(filepath, Encoding.Unicode);
                string html_template = read.ReadToEnd();

                string fileMailInfo = $@"{Path.GetDirectoryName(asm.Location)}\Template\InfoMail.txt";
                string infoFile = File.ReadAllText(fileMailInfo);
                List<string> listInfo = new List<string>();
                listInfo = infoFile.Split(';').ToList();

                try
                {
                    string html = html_template;
                    Byte[] bytes;

                    html = html.Replace("[HoTen]", "Mail Test");

                    using (var memoryStream = new MemoryStream())
                    {
                        var document = new Document(PageSize.A4, 20, 20, 20, 20);
                        var writer = PdfWriter.GetInstance(document, memoryStream);
                        document.Open();
                        Image imghead = Image.GetInstance($@"{Path.GetDirectoryName(asm.Location)}\Template\Logo.png");
                        imghead.ScaleToFit(140f, 100f);
                        document.Add(imghead);
                        //using (var cssMemoryStream = new MemoryStream(Encoding.UTF8.GetBytes(cssText)))
                        //{
                        using (var htmlMemoryStream = new MemoryStream(Encoding.UTF8.GetBytes(html.ToString())))
                        {
                            XMLWorkerHelper.GetInstance().ParseXHtml(writer, document, htmlMemoryStream, null, Encoding.UTF8, new UnicodeFontFactory());
                        }
                        //}
                        document.Close();

                        bytes = memoryStream.ToArray();
                    }

                    //var testFile = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.Desktop), MaNhanVien + "_" + HoTen + ".pdf");
                    var testFile = Path.Combine(Path.GetTempPath(), "MailTest.pdf");
                    System.IO.File.WriteAllBytes(testFile, bytes);

                    // Send mail
                    string emailTest = listInfo[4].Replace("EmailTest: ", "").TrimStart();
                    string emailAddress = listInfo[0].Replace("EmailAddress: ", "").TrimStart();
                    string password = listInfo[1].Replace("Password: ", "").TrimStart();
                    MimeMessage message = new MimeMessage();
                    message.From.Add(new MailboxAddress("PHIEU LUONG", emailAddress));
                    message.To.Add(new MailboxAddress("Test", emailTest));
                    message.Subject = listInfo[2].Replace("Subject: ", "").TrimStart();
                    var emailBody = new MimeKit.BodyBuilder
                    {
                        TextBody = listInfo[3]
                        .Replace("[HoTen]", "")
                        .Replace("TextBody:", "").TrimStart()
                        .Replace("TuThang", "01/" + DateTime.Now.Month + "/" + DateTime.Now.Year)
                        .Replace("DenThang", DateTime.Parse("01/" + DateTime.Now.Month + "/" + DateTime.Now.Year).AddMonths(1).AddDays(-1).ToString("dd/MM/yyyy")).TrimStart() + Environment.NewLine + "MailTest"
                    };
                    emailBody.Attachments.Add(testFile);
                    message.Body = emailBody.ToMessageBody();
                    client.Connect("smtp.gmail.com", 465, true);
                    client.Authenticate(emailAddress, password);
                    client.Send(message);
                    if (File.Exists(testFile))
                    {
                        File.Delete(testFile);
                    }
                }
                catch (Exception ex)
                {

                    throw new Exception(ex.Message);
                }

                RJMessageBox.Show("Gửi mail thành công");
            }
            catch (Exception ex)
            {
                RJMessageBox.Show(ex.Message);
            }
            finally
            {
                client.Disconnect(true);
                client.Dispose();
            }
            Cursor.Current = Cursors.Default;
        }

        private void DGV_NhanVien_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (DGV_NhanVien.CurrentCell.OwningColumn.Name == "show_col")
            {
                Cursor.Current = Cursors.WaitCursor;
                //var xlsBook = new XlsWorkBook(filepaths);
                Excel.Application oExcel = new Excel.Application();
                Excel.Workbook WB = oExcel.Workbooks.Open(filepaths);
                Excel.Worksheet wks = (Excel.Worksheet)WB.Worksheets["Form r1"];
                try
                {
                    var asm = Assembly.GetEntryAssembly();
                    string filepath = $@"{Path.GetDirectoryName(asm.Location)}\Template\PhieuLuong.html";
                    StreamReader read = new StreamReader(filepath, Encoding.Unicode);
                    string html_template = read.ReadToEnd();

                    string fileMailInfo = $@"{Path.GetDirectoryName(asm.Location)}\Template\InfoMail.txt";
                    string infoFile = File.ReadAllText(fileMailInfo);
                    List<string> listInfo = new List<string>();
                    listInfo = infoFile.Split(';').ToList();
                    try
                    {
                        string html = html_template;
                        Byte[] bytes;
                        //var xlsSheet = xlsBook.Sheet(i);
                        ((Excel.Range)wks.Cells[4, 3]).Value = DGV_NhanVien.CurrentRow.Cells["MaNhanVien"].Value.ToString();
                        //xlsSheet.Cell(3, 2).SetValue(DGV_NhanVien.CurrentRow.Cells["MaNhanVien"].Value.ToString());
                        string Thang = Convert.ToString(((Excel.Range)wks.Cells[2, 5]).Value);
                        //// Thong tin cong nhan vien
                        string MaNhanVien = Convert.ToString(((Excel.Range)wks.Cells[4, 3]).Value);
                        string BoPhan = Convert.ToString(((Excel.Range)wks.Cells[6, 3]).Value);
                        string HoTen = Convert.ToString(((Excel.Range)wks.Cells[5, 3]).Value);
                        string ChucVu = Convert.ToString(((Excel.Range)wks.Cells[7, 3]).Value);
                        string STK = Convert.ToString(((Excel.Range)wks.Cells[8, 3]).Value);
                        string NganHang = Convert.ToString(((Excel.Range)wks.Cells[4, 5]).Value);
                        string Email = Convert.ToString(((Excel.Range)wks.Cells[5, 5]).Value);
                        string NgayTraLuong = DateTime.Parse(((Excel.Range)wks.Cells[6, 5]).Value.ToString()).ToString();
                        string NgayPhepConLai = Convert.ToString(((Excel.Range)wks.Cells[7, 5]).Value);
                        // Luong theo hop dong lao dong
                        string LuongTheoHopDong = Convert.ToString(((Excel.Range)wks.Cells[9, 4]).Value);
                        string LuongCoBan = Convert.ToString(((Excel.Range)wks.Cells[10, 3]).Value);
                        string TC_TrachNhiem = Convert.ToString(((Excel.Range)wks.Cells[11, 3]).Value);
                        string TC_DocHai = Convert.ToString(((Excel.Range)wks.Cells[12, 3]).Value);
                        string TC_XeNang = Convert.ToString(((Excel.Range)wks.Cells[13, 3]).Value);
                        string TC_Nha = Convert.ToString(((Excel.Range)wks.Cells[14, 3]).Value);
                        string TC_DiLai = Convert.ToString(((Excel.Range)wks.Cells[10, 5]).Value);
                        string TC_ChuyenCan = Convert.ToString(((Excel.Range)wks.Cells[11, 3]).Value);
                        string TC_Khac = Convert.ToString(((Excel.Range)wks.Cells[12, 3]).Value);
                        // Tong thu nhap thuc te
                        string TongThuNhapThucTe = Convert.ToString(((Excel.Range)wks.Cells[15, 4]).Value);
                        string CongThuViec = Convert.ToString(((Excel.Range)wks.Cells[16, 3]).Value);
                        string LuongThuViec = Convert.ToString(((Excel.Range)wks.Cells[17, 3]).Value);
                        string CongLamChinhThuc = Convert.ToString(((Excel.Range)wks.Cells[18, 3]).Value);
                        string LuongChinhThuc = Convert.ToString(((Excel.Range)wks.Cells[19, 3]).Value);
                        string CaDem30 = Convert.ToString(((Excel.Range)wks.Cells[20, 3]).Value);
                        string TienCaDem = Convert.ToString(((Excel.Range)wks.Cells[21, 3]).Value);
                        string TangCa150 = Convert.ToString(((Excel.Range)wks.Cells[22, 3]).Value);
                        string TienTangCa150 = Convert.ToString(((Excel.Range)wks.Cells[23, 3]).Value);
                        string TangCa200 = Convert.ToString(((Excel.Range)wks.Cells[24, 3]).Value);
                        string TienTangCa200 = Convert.ToString(((Excel.Range)wks.Cells[25, 3]).Value);
                        string TangCa210 = Convert.ToString(((Excel.Range)wks.Cells[26, 3]).Value);
                        string TienTangCa210 = Convert.ToString(((Excel.Range)wks.Cells[27, 3]).Value);
                        string TangCa270 = Convert.ToString(((Excel.Range)wks.Cells[28, 3]).Value);
                        string TienTangCa270 = Convert.ToString(((Excel.Range)wks.Cells[29, 3]).Value);
                        string TangCa300 = Convert.ToString(((Excel.Range)wks.Cells[30, 3]).Value);
                        string TienTangCa300 = Convert.ToString(((Excel.Range)wks.Cells[31, 3]).Value);
                        string TC_TrachNhiem_TT = Convert.ToString(((Excel.Range)wks.Cells[16, 3]).Value);
                        string TC_DocHai_TT = Convert.ToString(((Excel.Range)wks.Cells[17, 3]).Value);
                        string TC_KyNang = Convert.ToString(((Excel.Range)wks.Cells[18, 3]).Value);
                        string TC_Nha_TT = Convert.ToString(((Excel.Range)wks.Cells[19, 3]).Value);
                        string TC_DiLai_TT = Convert.ToString(((Excel.Range)wks.Cells[20, 3]).Value);
                        string TC_ChuyenCan_TT = Convert.ToString(((Excel.Range)wks.Cells[21, 3]).Value);
                        string TC_PCCC = Convert.ToString(((Excel.Range)wks.Cells[22, 3]).Value);
                        string TC_GuiTre = Convert.ToString(((Excel.Range)wks.Cells[23, 3]).Value);
                        string TC_ATVSV = Convert.ToString(((Excel.Range)wks.Cells[24, 3]).Value);
                        string TC_PhuNu = Convert.ToString(((Excel.Range)wks.Cells[25, 3]).Value);
                        string TienTangCa = Convert.ToString(((Excel.Range)wks.Cells[26, 3]).Value);
                        string TC_Khac_TT = Convert.ToString(((Excel.Range)wks.Cells[27, 3]).Value);
                        string DieuChinh = Convert.ToString(((Excel.Range)wks.Cells[28, 3]).Value);
                        // cac khoan thu nhap khac
                        string SoNgayPhepThua = Convert.ToString(((Excel.Range)wks.Cells[33, 3]).Value);
                        string TienPhepThua = Convert.ToString(((Excel.Range)wks.Cells[34, 3]).Value);
                        // Tien thuong
                        string LuongCoBan_Thuong = Convert.ToString(((Excel.Range)wks.Cells[36, 3]).Value);
                        string TC_TinhThuong = Convert.ToString(((Excel.Range)wks.Cells[37, 3]).Value);
                        string CanCuTinhThuong = Convert.ToString(((Excel.Range)wks.Cells[38, 3]).Value);
                        string XepLoaiCuoiCung = Convert.ToString(((Excel.Range)wks.Cells[39, 3]).Value);
                        string TyLeThuong = Convert.ToString(((Excel.Range)wks.Cells[40, 3]).Value);
                        string HeSoTinh = Convert.ToString(((Excel.Range)wks.Cells[41, 3]).Value);
                        string SoTienThuong = Convert.ToString(((Excel.Range)wks.Cells[36, 5]).Value);
                        string NgayTraLuong_Thuong = Convert.ToString(((Excel.Range)wks.Cells[37, 5]).Value);
                        string Khac = Convert.ToString(((Excel.Range)wks.Cells[36, 5]).Value);
                        string GhiChu = Convert.ToString(((Excel.Range)wks.Cells[37, 5]).Value);
                        // tong cac khoan giam tru luong
                        string TongCacKhoanGiamTruLuong = Convert.ToString(((Excel.Range)wks.Cells[42, 4]).Value);
                        string BaoHiemBatBuoc = Convert.ToString(((Excel.Range)wks.Cells[43, 3]).Value);
                        string DoanPhi = Convert.ToString(((Excel.Range)wks.Cells[44, 3]).Value);
                        string ThueThuNhapCaNhan = Convert.ToString(((Excel.Range)wks.Cells[45, 3]).Value);
                        string TruKhac = Convert.ToString(((Excel.Range)wks.Cells[46, 3]).Value);
                        string QuyPCT = Convert.ToString(((Excel.Range)wks.Cells[43, 5]).Value);
                        // thu nhap thuc linh
                        string ThuNhapThucLinh = Convert.ToString(((Excel.Range)wks.Cells[47, 4]).Value);
                        string GhiChu_ThucLinh = Convert.ToString(((Excel.Range)wks.Cells[48, 3]).Value);

                        html = html.Replace("[Thang]", Thang)
                            .Replace("[ID]", MaNhanVien)
                            .Replace("[HoTen]", HoTen)
                            .Replace("[BoPhan]", BoPhan)
                            .Replace("[ChucVu]", ChucVu)
                            .Replace("[STK]", STK)
                            .Replace("[NganHang]", NganHang)
                            .Replace("[Email]", Email)
                            .Replace("[NgayTraLuong]", DateTime.Parse(NgayTraLuong).ToString("dd/MM/yyyy"))
                            .Replace("[NgayPhepConLai]", NgayPhepConLai)

                            .Replace("[LuongTheoHopDong]", string.IsNullOrEmpty(LuongTheoHopDong) ? "0" : decimal.Parse(LuongTheoHopDong).ToString("#,##0"))
                            .Replace("[LuongCoban]", string.IsNullOrEmpty(LuongCoBan) ? "0" : decimal.Parse(LuongCoBan).ToString("#,##0"))
                            .Replace("[TC_TrachNhiem]", string.IsNullOrEmpty(TC_TrachNhiem) ? "0" : decimal.Parse(TC_TrachNhiem).ToString("#,##0"))
                            .Replace("[TCDocHai]", string.IsNullOrEmpty(TC_DocHai) ? "0" : decimal.Parse(TC_DocHai).ToString("#,##0"))
                            .Replace("[TC_XeNang]", string.IsNullOrEmpty(TC_XeNang) ? "0" : decimal.Parse(TC_XeNang).ToString("#,##0"))
                            .Replace("[TC_Nha]", string.IsNullOrEmpty(TC_Nha) ? "0" : decimal.Parse(TC_Nha).ToString("#,##0"))
                            .Replace("[TC_DiLai]", string.IsNullOrEmpty(TC_DiLai) ? "0" : decimal.Parse(TC_DiLai).ToString("#,##0"))
                            .Replace("[TC_ChuyenCan]", string.IsNullOrEmpty(TC_ChuyenCan) ? "0" : decimal.Parse(TC_ChuyenCan).ToString("#,##0"))
                            .Replace("[TC_Khac]", TC_Khac == "0" || string.IsNullOrEmpty(TC_Khac) ? "--" : TC_Khac)

                            .Replace("[TongThuNhapThucTe]", string.IsNullOrEmpty(TongThuNhapThucTe) ? "0" : decimal.Parse(TongThuNhapThucTe).ToString("#,##0"))
                            .Replace("[CongThuViec]", string.IsNullOrEmpty(CongThuViec) ? "0.0" : decimal.Parse(CongThuViec).ToString("#.0"))
                            .Replace("[LuongThuViec]", LuongThuViec)
                            .Replace("[CongLamChinhThuc]", string.IsNullOrEmpty(CongLamChinhThuc) ? "0.0" : decimal.Parse(CongLamChinhThuc).ToString("#.0"))
                            .Replace("[LuongChinhThuc]", string.IsNullOrEmpty(LuongChinhThuc) ? "0" : decimal.Parse(LuongChinhThuc).ToString("#,##0"))
                            .Replace("[CaDem]", string.IsNullOrEmpty(CaDem30) ? "0.0" : decimal.Parse(CaDem30).ToString("#.0"))
                            .Replace("[TienCaDem]", TienCaDem)
                            .Replace("[TangCa150]", string.IsNullOrEmpty(TangCa150) ? "0.0" : decimal.Parse(TangCa150).ToString("#.0"))
                            .Replace("[TienTangCa150]", TienTangCa150)
                            .Replace("[TangCa200]", string.IsNullOrEmpty(TangCa200) ? "0.0" : decimal.Parse(TangCa200).ToString("#.0"))
                            .Replace("[TienTangCa200]", TienTangCa200)
                            .Replace("[TangCa210]", string.IsNullOrEmpty(TangCa210) ? "0.0" : decimal.Parse(TangCa210).ToString("#.0"))
                            .Replace("[TienTangCa210]", TienTangCa210)
                            .Replace("[TangCa270]", string.IsNullOrEmpty(TangCa270) ? "0.0" : decimal.Parse(TangCa270).ToString("#.0"))
                            .Replace("[TienTangCa270]", TienTangCa270)
                            .Replace("[TangCa300]", string.IsNullOrEmpty(TangCa300) ? "0.0" : decimal.Parse(TangCa300).ToString("#.0"))
                            .Replace("[TienTangCa300]", TienTangCa300)
                            .Replace("[TC_TrachNhiem_TT]", string.IsNullOrEmpty(TC_TrachNhiem_TT) ? "0" : decimal.Parse(TC_TrachNhiem_TT).ToString("#,##0"))
                            .Replace("[TC_DocHai_TT]", string.IsNullOrEmpty(TC_DocHai_TT) ? "0" : decimal.Parse(TC_DocHai_TT).ToString("#,##0"))
                            .Replace("[TC_KyNang]", string.IsNullOrEmpty(TC_KyNang) ? "0" : decimal.Parse(TC_KyNang).ToString("#,##0"))
                            .Replace("[TC_Nha_TT]", string.IsNullOrEmpty(TC_Nha_TT) ? "0" : decimal.Parse(TC_Nha_TT).ToString("#,##0"))
                            .Replace("[TC_DiLai_TT]", string.IsNullOrEmpty(TC_DiLai_TT) ? "0" : decimal.Parse(TC_DiLai_TT).ToString("#,##0"))
                            .Replace("[TC_ChuyenCan_TT]", string.IsNullOrEmpty(TC_ChuyenCan_TT) ? "0" : decimal.Parse(TC_ChuyenCan_TT).ToString("#,##0"))
                            .Replace("[TC_PCCC]", string.IsNullOrEmpty(TC_PCCC) ? "0" : decimal.Parse(TC_PCCC).ToString("#,##0"))
                            .Replace("[TC_GuiTre]", string.IsNullOrEmpty(TC_GuiTre) ? "0" : decimal.Parse(TC_GuiTre).ToString("#,##0"))
                            .Replace("[TC_ATVSV]", string.IsNullOrEmpty(TC_ATVSV) ? "0" : decimal.Parse(TC_ATVSV).ToString("#,##0"))
                            .Replace("[TC_PhuNu]", string.IsNullOrEmpty(TC_PhuNu) ? "0" : decimal.Parse(TC_PhuNu).ToString("#,##0"))
                            .Replace("[TienTangCa]", string.IsNullOrEmpty(TienTangCa) ? "0" : decimal.Parse(TienTangCa).ToString("#,##0"))
                            .Replace("[TC_Khac_TT]", TC_Khac_TT == "0" || string.IsNullOrEmpty(TC_Khac_TT) ? "--" : decimal.Parse(TC_Khac_TT).ToString("#,##0"))
                            .Replace("[DieuChinh]", string.IsNullOrEmpty(DieuChinh) ? "0" : decimal.Parse(DieuChinh).ToString("#,##0"))

                            .Replace("[SoNgayPhepThua]", SoNgayPhepThua == "0" || string.IsNullOrEmpty(SoNgayPhepThua) ? "--" : decimal.Parse(SoNgayPhepThua).ToString("#.0"))
                            .Replace("[TienPhepThua]", TienPhepThua == "0" || string.IsNullOrEmpty(TienPhepThua) ? "--" : decimal.Parse(TienPhepThua).ToString("#,##0"))

                            .Replace("[LuongCoBan]", LuongCoBan_Thuong == "0" || string.IsNullOrEmpty(LuongCoBan_Thuong) ? "--" : decimal.Parse(LuongCoBan_Thuong).ToString("#,##0"))
                            .Replace("[TC_TinhThuong]", TC_TinhThuong == "0" || string.IsNullOrEmpty(TC_TinhThuong) ? "--" : decimal.Parse(TC_TinhThuong).ToString("#,##0"))
                            .Replace("[CanCuTinhThuong]", CanCuTinhThuong == "0" || string.IsNullOrEmpty(CanCuTinhThuong) ? "--" : decimal.Parse(CanCuTinhThuong).ToString("#,##0"))
                            .Replace("[XepLoaiCuoiCung]", (XepLoaiCuoiCung == "0" || string.IsNullOrEmpty(XepLoaiCuoiCung) ? "--" : XepLoaiCuoiCung))
                            .Replace("[TyLeThuong]", TyLeThuong == "0" || string.IsNullOrEmpty(TyLeThuong) ? "--" : decimal.Parse(TyLeThuong).ToString("#.00"))
                            .Replace("[HeSoTinh]", HeSoTinh == "0" || string.IsNullOrEmpty(HeSoTinh) ? "--" : decimal.Parse(HeSoTinh).ToString("#.00"))
                            .Replace("[SoTienThuong]", SoTienThuong == "0" || string.IsNullOrEmpty(SoTienThuong) ? "--" : decimal.Parse(SoTienThuong).ToString("#,##0"))
                            .Replace("[NgayTraThuong]", NgayTraLuong_Thuong == "0" || string.IsNullOrEmpty(NgayTraLuong_Thuong) ? "--" : NgayTraLuong_Thuong)
                            .Replace("[Khac]", Khac == "0" || string.IsNullOrEmpty(Khac) ? "--" : Khac)
                            .Replace("[GhiChu]", GhiChu == "0" || string.IsNullOrEmpty(GhiChu) ? "--" : GhiChu)

                            .Replace("[TongCacKhoanGiamTruLuong]", string.IsNullOrEmpty(TongCacKhoanGiamTruLuong) ? "0" : decimal.Parse(TongCacKhoanGiamTruLuong).ToString("#,##0"))
                            .Replace("[BaoHiemBatBuoc]", string.IsNullOrEmpty(BaoHiemBatBuoc) ? "0" : decimal.Parse(BaoHiemBatBuoc).ToString("#,##0"))
                            .Replace("[DoanPhi]", string.IsNullOrEmpty(DoanPhi) ? "0" : decimal.Parse(DoanPhi).ToString("#,##0"))
                            .Replace("[TTNCN]", string.IsNullOrEmpty(ThueThuNhapCaNhan) ? "0" : decimal.Parse(ThueThuNhapCaNhan).ToString("#,##0"))
                            .Replace("[QuyPCTT]", QuyPCT == "0" || string.IsNullOrEmpty(QuyPCT) ? "--" : decimal.Parse(QuyPCT).ToString("#,##0"))
                            .Replace("[TruKhac]", TruKhac)

                            .Replace("[ThuNhapThucLinh]", string.IsNullOrEmpty(ThuNhapThucLinh) ? "0" : decimal.Parse(ThuNhapThucLinh).ToString("#,##0"))
                            .Replace("[GhiChu_ThucLinh]", (GhiChu_ThucLinh == "0" || string.IsNullOrEmpty(GhiChu_ThucLinh) ? "--" : GhiChu_ThucLinh));
                        using (var memoryStream = new MemoryStream())
                        {
                            var document = new Document(PageSize.A4, 20, 20, 20, 20);
                            var writer = PdfWriter.GetInstance(document, memoryStream);
                            document.Open();
                            Image imghead = Image.GetInstance($@"{Path.GetDirectoryName(asm.Location)}\Template\Logo.png");
                            imghead.ScaleToFit(140f, 100f);
                            document.Add(imghead);
                            //using (var cssMemoryStream = new MemoryStream(Encoding.UTF8.GetBytes(cssText)))
                            //{
                            using (var htmlMemoryStream = new MemoryStream(Encoding.UTF8.GetBytes(html.ToString())))
                            {
                                XMLWorkerHelper.GetInstance().ParseXHtml(writer, document, htmlMemoryStream, null, Encoding.UTF8, new UnicodeFontFactory());
                            }
                            //}
                            document.Close();

                            bytes = memoryStream.ToArray();
                        }

                        //var testFile = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.Desktop), MaNhanVien + "_" + HoTen + ".pdf");
                        var testFile = Path.Combine(Path.GetTempPath(), MaNhanVien + "_" + HoTen + ".pdf");
                        System.IO.File.WriteAllBytes(testFile, bytes);
                        System.Diagnostics.Process.Start(testFile);
                    }
                    catch (Exception ex)
                    {
                        throw new Exception(ex.Message);
                    }

                    WB.Save();
                    WB.Close();
                }
                catch (Exception ex)
                {
                    WB.Save();
                    WB.Close();
                    RJMessageBox.Show(ex.Message);
                }
                Cursor.Current = Cursors.Default;
            }
            else if (DGV_NhanVien.CurrentCell.OwningColumn.Name == "send_col")
            {
                Cursor.Current = Cursors.WaitCursor;
                //var xlsBook = new XlsWorkBook(filepaths);
                Excel.Application oExcel = new Excel.Application();
                Excel.Workbook WB = oExcel.Workbooks.Open(filepaths);
                Excel.Worksheet wks = (Excel.Worksheet)WB.Worksheets["Form r1"];
                try
                {
                    var asm = Assembly.GetEntryAssembly();
                    string filepath = $@"{Path.GetDirectoryName(asm.Location)}\Template\PhieuLuong.html";
                    StreamReader read = new StreamReader(filepath, Encoding.Unicode);
                    string html_template = read.ReadToEnd();

                    string fileMailInfo = $@"{Path.GetDirectoryName(asm.Location)}\Template\InfoMail.txt";
                    string infoFile = File.ReadAllText(fileMailInfo);
                    List<string> listInfo = new List<string>();
                    listInfo = infoFile.Split(';').ToList();

                    SmtpClient client = new SmtpClient();
                    try
                    {
                        string html = html_template;
                        Byte[] bytes;
                        //var xlsSheet = xlsBook.Sheet(i);
                        ((Excel.Range)wks.Cells[4, 3]).Value = DGV_NhanVien.CurrentRow.Cells["MaNhanVien"].Value.ToString();
                        //xlsSheet.Cell(3, 2).SetValue(DGV_NhanVien.CurrentRow.Cells["MaNhanVien"].Value.ToString());
                        string Thang = Convert.ToString(((Excel.Range)wks.Cells[2, 5]).Value);
                        // Thong tin cong nhan vien
                        string MaNhanVien = Convert.ToString(((Excel.Range)wks.Cells[4, 3]).Value);
                        string BoPhan = Convert.ToString(((Excel.Range)wks.Cells[6, 3]).Value);
                        string HoTen = Convert.ToString(((Excel.Range)wks.Cells[5, 3]).Value);
                        string ChucVu = Convert.ToString(((Excel.Range)wks.Cells[7, 3]).Value);
                        string STK = Convert.ToString(((Excel.Range)wks.Cells[8, 3]).Value);
                        string NganHang = Convert.ToString(((Excel.Range)wks.Cells[4, 5]).Value);
                        string Email = Convert.ToString(((Excel.Range)wks.Cells[5, 5]).Value);
                        string NgayTraLuong = DateTime.Parse(((Excel.Range)wks.Cells[6, 5]).Value.ToString()).ToString();
                        string NgayPhepConLai = Convert.ToString(((Excel.Range)wks.Cells[7, 5]).Value);
                        // Luong theo hop dong lao dong
                        string LuongTheoHopDong = Convert.ToString(((Excel.Range)wks.Cells[9, 4]).Value);
                        string LuongCoBan = Convert.ToString(((Excel.Range)wks.Cells[10, 3]).Value);
                        string TC_TrachNhiem = Convert.ToString(((Excel.Range)wks.Cells[11, 3]).Value);
                        string TC_DocHai = Convert.ToString(((Excel.Range)wks.Cells[12, 3]).Value);
                        string TC_XeNang = Convert.ToString(((Excel.Range)wks.Cells[13, 3]).Value);
                        string TC_Nha = Convert.ToString(((Excel.Range)wks.Cells[14, 3]).Value);
                        string TC_DiLai = Convert.ToString(((Excel.Range)wks.Cells[10, 5]).Value);
                        string TC_ChuyenCan = Convert.ToString(((Excel.Range)wks.Cells[11, 3]).Value);
                        string TC_Khac = Convert.ToString(((Excel.Range)wks.Cells[12, 3]).Value);
                        // Tong thu nhap thuc te
                        string TongThuNhapThucTe = Convert.ToString(((Excel.Range)wks.Cells[15, 4]).Value);
                        string CongThuViec = Convert.ToString(((Excel.Range)wks.Cells[16, 3]).Value);
                        string LuongThuViec = Convert.ToString(((Excel.Range)wks.Cells[17, 3]).Value);
                        string CongLamChinhThuc = Convert.ToString(((Excel.Range)wks.Cells[18, 3]).Value);
                        string LuongChinhThuc = Convert.ToString(((Excel.Range)wks.Cells[19, 3]).Value);
                        string CaDem30 = Convert.ToString(((Excel.Range)wks.Cells[20, 3]).Value);
                        string TienCaDem = Convert.ToString(((Excel.Range)wks.Cells[21, 3]).Value);
                        string TangCa150 = Convert.ToString(((Excel.Range)wks.Cells[22, 3]).Value);
                        string TienTangCa150 = Convert.ToString(((Excel.Range)wks.Cells[23, 3]).Value);
                        string TangCa200 = Convert.ToString(((Excel.Range)wks.Cells[24, 3]).Value);
                        string TienTangCa200 = Convert.ToString(((Excel.Range)wks.Cells[25, 3]).Value);
                        string TangCa210 = Convert.ToString(((Excel.Range)wks.Cells[26, 3]).Value);
                        string TienTangCa210 = Convert.ToString(((Excel.Range)wks.Cells[27, 3]).Value);
                        string TangCa270 = Convert.ToString(((Excel.Range)wks.Cells[28, 3]).Value);
                        string TienTangCa270 = Convert.ToString(((Excel.Range)wks.Cells[29, 3]).Value);
                        string TangCa300 = Convert.ToString(((Excel.Range)wks.Cells[30, 3]).Value);
                        string TienTangCa300 = Convert.ToString(((Excel.Range)wks.Cells[31, 3]).Value);
                        string TC_TrachNhiem_TT = Convert.ToString(((Excel.Range)wks.Cells[16, 3]).Value);
                        string TC_DocHai_TT = Convert.ToString(((Excel.Range)wks.Cells[17, 3]).Value);
                        string TC_KyNang = Convert.ToString(((Excel.Range)wks.Cells[18, 3]).Value);
                        string TC_Nha_TT = Convert.ToString(((Excel.Range)wks.Cells[19, 3]).Value);
                        string TC_DiLai_TT = Convert.ToString(((Excel.Range)wks.Cells[20, 3]).Value);
                        string TC_ChuyenCan_TT = Convert.ToString(((Excel.Range)wks.Cells[21, 3]).Value);
                        string TC_PCCC = Convert.ToString(((Excel.Range)wks.Cells[22, 3]).Value);
                        string TC_GuiTre = Convert.ToString(((Excel.Range)wks.Cells[23, 3]).Value);
                        string TC_ATVSV = Convert.ToString(((Excel.Range)wks.Cells[24, 3]).Value);
                        string TC_PhuNu = Convert.ToString(((Excel.Range)wks.Cells[25, 3]).Value);
                        string TienTangCa = Convert.ToString(((Excel.Range)wks.Cells[26, 3]).Value);
                        string TC_Khac_TT = Convert.ToString(((Excel.Range)wks.Cells[27, 3]).Value);
                        string DieuChinh = Convert.ToString(((Excel.Range)wks.Cells[28, 3]).Value);
                        // cac khoan thu nhap khac
                        string SoNgayPhepThua = Convert.ToString(((Excel.Range)wks.Cells[33, 3]).Value);
                        string TienPhepThua = Convert.ToString(((Excel.Range)wks.Cells[34, 3]).Value);
                        // Tien thuong
                        string LuongCoBan_Thuong = Convert.ToString(((Excel.Range)wks.Cells[36, 3]).Value);
                        string TC_TinhThuong = Convert.ToString(((Excel.Range)wks.Cells[37, 3]).Value);
                        string CanCuTinhThuong = Convert.ToString(((Excel.Range)wks.Cells[38, 3]).Value);
                        string XepLoaiCuoiCung = Convert.ToString(((Excel.Range)wks.Cells[39, 3]).Value);
                        string TyLeThuong = Convert.ToString(((Excel.Range)wks.Cells[40, 3]).Value);
                        string HeSoTinh = Convert.ToString(((Excel.Range)wks.Cells[41, 3]).Value);
                        string SoTienThuong = Convert.ToString(((Excel.Range)wks.Cells[36, 5]).Value);
                        string NgayTraLuong_Thuong = Convert.ToString(((Excel.Range)wks.Cells[37, 5]).Value);
                        string Khac = Convert.ToString(((Excel.Range)wks.Cells[36, 5]).Value);
                        string GhiChu = Convert.ToString(((Excel.Range)wks.Cells[37, 5]).Value);
                        // tong cac khoan giam tru luong
                        string TongCacKhoanGiamTruLuong = Convert.ToString(((Excel.Range)wks.Cells[42, 4]).Value);
                        string BaoHiemBatBuoc = Convert.ToString(((Excel.Range)wks.Cells[43, 3]).Value);
                        string DoanPhi = Convert.ToString(((Excel.Range)wks.Cells[44, 3]).Value);
                        string ThueThuNhapCaNhan = Convert.ToString(((Excel.Range)wks.Cells[45, 3]).Value);
                        string TruKhac = Convert.ToString(((Excel.Range)wks.Cells[46, 3]).Value);
                        string QuyPCT = Convert.ToString(((Excel.Range)wks.Cells[43, 5]).Value);
                        // thu nhap thuc linh
                        string ThuNhapThucLinh = Convert.ToString(((Excel.Range)wks.Cells[47, 4]).Value);
                        string GhiChu_ThucLinh = Convert.ToString(((Excel.Range)wks.Cells[48, 3]).Value);

                        html = html.Replace("[Thang]", Thang)
                            .Replace("[ID]", MaNhanVien)
                            .Replace("[HoTen]", HoTen)
                            .Replace("[BoPhan]", BoPhan)
                            .Replace("[ChucVu]", ChucVu)
                            .Replace("[STK]", STK)
                            .Replace("[NganHang]", NganHang)
                            .Replace("[Email]", Email)
                            .Replace("[NgayTraLuong]", DateTime.Parse(NgayTraLuong).ToString("dd/MM/yyyy"))
                            .Replace("[NgayPhepConLai]", NgayPhepConLai)

                            .Replace("[LuongTheoHopDong]", string.IsNullOrEmpty(LuongTheoHopDong) ? "0" : decimal.Parse(LuongTheoHopDong).ToString("#,##0"))
                            .Replace("[LuongCoban]", string.IsNullOrEmpty(LuongCoBan) ? "0" : decimal.Parse(LuongCoBan).ToString("#,##0"))
                            .Replace("[TC_TrachNhiem]", string.IsNullOrEmpty(TC_TrachNhiem) ? "0" : decimal.Parse(TC_TrachNhiem).ToString("#,##0"))
                            .Replace("[TCDocHai]", string.IsNullOrEmpty(TC_DocHai) ? "0" : decimal.Parse(TC_DocHai).ToString("#,##0"))
                            .Replace("[TC_XeNang]", string.IsNullOrEmpty(TC_XeNang) ? "0" : decimal.Parse(TC_XeNang).ToString("#,##0"))
                            .Replace("[TC_Nha]", string.IsNullOrEmpty(TC_Nha) ? "0" : decimal.Parse(TC_Nha).ToString("#,##0"))
                            .Replace("[TC_DiLai]", string.IsNullOrEmpty(TC_DiLai) ? "0" : decimal.Parse(TC_DiLai).ToString("#,##0"))
                            .Replace("[TC_ChuyenCan]", string.IsNullOrEmpty(TC_ChuyenCan) ? "0" : decimal.Parse(TC_ChuyenCan).ToString("#,##0"))
                            .Replace("[TC_Khac]", TC_Khac == "0" || string.IsNullOrEmpty(TC_Khac) ? "--" : TC_Khac)

                            .Replace("[TongThuNhapThucTe]", string.IsNullOrEmpty(TongThuNhapThucTe) ? "0" : decimal.Parse(TongThuNhapThucTe).ToString("#,##0"))
                            .Replace("[CongThuViec]", string.IsNullOrEmpty(CongThuViec) ? "0.0" : decimal.Parse(CongThuViec).ToString("#.0"))
                            .Replace("[LuongThuViec]", LuongThuViec)
                            .Replace("[CongLamChinhThuc]", string.IsNullOrEmpty(CongLamChinhThuc) ? "0.0" : decimal.Parse(CongLamChinhThuc).ToString("#.0"))
                            .Replace("[LuongChinhThuc]", string.IsNullOrEmpty(LuongChinhThuc) ? "0" : decimal.Parse(LuongChinhThuc).ToString("#,##0"))
                            .Replace("[CaDem]", string.IsNullOrEmpty(CaDem30) ? "0.0" : decimal.Parse(CaDem30).ToString("#.0"))
                            .Replace("[TienCaDem]", TienCaDem)
                            .Replace("[TangCa150]", string.IsNullOrEmpty(TangCa150) ? "0.0" : decimal.Parse(TangCa150).ToString("#.0"))
                            .Replace("[TienTangCa150]", TienTangCa150)
                            .Replace("[TangCa200]", string.IsNullOrEmpty(TangCa200) ? "0.0" : decimal.Parse(TangCa200).ToString("#.0"))
                            .Replace("[TienTangCa200]", TienTangCa200)
                            .Replace("[TangCa210]", string.IsNullOrEmpty(TangCa210) ? "0.0" : decimal.Parse(TangCa210).ToString("#.0"))
                            .Replace("[TienTangCa210]", TienTangCa210)
                            .Replace("[TangCa270]", string.IsNullOrEmpty(TangCa270) ? "0.0" : decimal.Parse(TangCa270).ToString("#.0"))
                            .Replace("[TienTangCa270]", TienTangCa270)
                            .Replace("[TangCa300]", string.IsNullOrEmpty(TangCa300) ? "0.0" : decimal.Parse(TangCa300).ToString("#.0"))
                            .Replace("[TienTangCa300]", TienTangCa300)
                            .Replace("[TC_TrachNhiem_TT]", string.IsNullOrEmpty(TC_TrachNhiem_TT) ? "0" : decimal.Parse(TC_TrachNhiem_TT).ToString("#,##0"))
                            .Replace("[TC_DocHai_TT]", string.IsNullOrEmpty(TC_DocHai_TT) ? "0" : decimal.Parse(TC_DocHai_TT).ToString("#,##0"))
                            .Replace("[TC_KyNang]", string.IsNullOrEmpty(TC_KyNang) ? "0" : decimal.Parse(TC_KyNang).ToString("#,##0"))
                            .Replace("[TC_Nha_TT]", string.IsNullOrEmpty(TC_Nha_TT) ? "0" : decimal.Parse(TC_Nha_TT).ToString("#,##0"))
                            .Replace("[TC_DiLai_TT]", string.IsNullOrEmpty(TC_DiLai_TT) ? "0" : decimal.Parse(TC_DiLai_TT).ToString("#,##0"))
                            .Replace("[TC_ChuyenCan_TT]", string.IsNullOrEmpty(TC_ChuyenCan_TT) ? "0" : decimal.Parse(TC_ChuyenCan_TT).ToString("#,##0"))
                            .Replace("[TC_PCCC]", string.IsNullOrEmpty(TC_PCCC) ? "0" : decimal.Parse(TC_PCCC).ToString("#,##0"))
                            .Replace("[TC_GuiTre]", string.IsNullOrEmpty(TC_GuiTre) ? "0" : decimal.Parse(TC_GuiTre).ToString("#,##0"))
                            .Replace("[TC_ATVSV]", string.IsNullOrEmpty(TC_ATVSV) ? "0" : decimal.Parse(TC_ATVSV).ToString("#,##0"))
                            .Replace("[TC_PhuNu]", string.IsNullOrEmpty(TC_PhuNu) ? "0" : decimal.Parse(TC_PhuNu).ToString("#,##0"))
                            .Replace("[TienTangCa]", string.IsNullOrEmpty(TienTangCa) ? "0" : decimal.Parse(TienTangCa).ToString("#,##0"))
                            .Replace("[TC_Khac_TT]", TC_Khac_TT == "0" || string.IsNullOrEmpty(TC_Khac_TT) ? "--" : decimal.Parse(TC_Khac_TT).ToString("#,##0"))
                            .Replace("[DieuChinh]", string.IsNullOrEmpty(DieuChinh) ? "0" : decimal.Parse(DieuChinh).ToString("#,##0"))

                            .Replace("[SoNgayPhepThua]", SoNgayPhepThua == "0" || string.IsNullOrEmpty(SoNgayPhepThua) ? "--" : decimal.Parse(SoNgayPhepThua).ToString("#.0"))
                            .Replace("[TienPhepThua]", TienPhepThua == "0" || string.IsNullOrEmpty(TienPhepThua) ? "--" : decimal.Parse(TienPhepThua).ToString("#,##0"))

                            .Replace("[LuongCoBan]", LuongCoBan_Thuong == "0" || string.IsNullOrEmpty(LuongCoBan_Thuong) ? "--" : decimal.Parse(LuongCoBan_Thuong).ToString("#,##0"))
                            .Replace("[TC_TinhThuong]", TC_TinhThuong == "0" || string.IsNullOrEmpty(TC_TinhThuong) ? "--" : decimal.Parse(TC_TinhThuong).ToString("#,##0"))
                            .Replace("[CanCuTinhThuong]", CanCuTinhThuong == "0" || string.IsNullOrEmpty(CanCuTinhThuong) ? "--" : decimal.Parse(CanCuTinhThuong).ToString("#,##0"))
                            .Replace("[XepLoaiCuoiCung]", (XepLoaiCuoiCung == "0" || string.IsNullOrEmpty(XepLoaiCuoiCung) ? "--" : XepLoaiCuoiCung))
                            .Replace("[TyLeThuong]", TyLeThuong == "0" || string.IsNullOrEmpty(TyLeThuong) ? "--" : decimal.Parse(TyLeThuong).ToString("#.00"))
                            .Replace("[HeSoTinh]", HeSoTinh == "0" || string.IsNullOrEmpty(HeSoTinh) ? "--" : decimal.Parse(HeSoTinh).ToString("#.00"))
                            .Replace("[SoTienThuong]", SoTienThuong == "0" || string.IsNullOrEmpty(SoTienThuong) ? "--" : decimal.Parse(SoTienThuong).ToString("#,##0"))
                            .Replace("[NgayTraThuong]", NgayTraLuong_Thuong == "0" || string.IsNullOrEmpty(NgayTraLuong_Thuong) ? "--" : NgayTraLuong_Thuong)
                            .Replace("[Khac]", Khac == "0" || string.IsNullOrEmpty(Khac) ? "--" : Khac)
                            .Replace("[GhiChu]", GhiChu == "0" || string.IsNullOrEmpty(GhiChu) ? "--" : GhiChu)

                            .Replace("[TongCacKhoanGiamTruLuong]", string.IsNullOrEmpty(TongCacKhoanGiamTruLuong) ? "0" : decimal.Parse(TongCacKhoanGiamTruLuong).ToString("#,##0"))
                            .Replace("[BaoHiemBatBuoc]", string.IsNullOrEmpty(BaoHiemBatBuoc) ? "0" : decimal.Parse(BaoHiemBatBuoc).ToString("#,##0"))
                            .Replace("[DoanPhi]", string.IsNullOrEmpty(DoanPhi) ? "0" : decimal.Parse(DoanPhi).ToString("#,##0"))
                            .Replace("[TTNCN]", string.IsNullOrEmpty(ThueThuNhapCaNhan) ? "0" : decimal.Parse(ThueThuNhapCaNhan).ToString("#,##0"))
                            .Replace("[QuyPCTT]", QuyPCT == "0" || string.IsNullOrEmpty(QuyPCT) ? "--" : decimal.Parse(QuyPCT).ToString("#,##0"))
                            .Replace("[TruKhac]", TruKhac)

                            .Replace("[ThuNhapThucLinh]", string.IsNullOrEmpty(ThuNhapThucLinh) ? "0" : decimal.Parse(ThuNhapThucLinh).ToString("#,##0"))
                            .Replace("[GhiChu_ThucLinh]", (GhiChu_ThucLinh == "0" || string.IsNullOrEmpty(GhiChu_ThucLinh) ? "--" : GhiChu_ThucLinh));

                        using (var memoryStream = new MemoryStream())
                        {
                            var document = new Document(PageSize.A4, 20, 20, 20, 20);
                            var writer = PdfWriter.GetInstance(document, memoryStream);
                            document.Open();
                            Image imghead = Image.GetInstance($@"{Path.GetDirectoryName(asm.Location)}\Template\Logo.png");
                            imghead.ScaleToFit(140f, 100f);
                            document.Add(imghead);
                            //using (var cssMemoryStream = new MemoryStream(Encoding.UTF8.GetBytes(cssText)))
                            //{
                            using (var htmlMemoryStream = new MemoryStream(Encoding.UTF8.GetBytes(html.ToString())))
                            {
                                XMLWorkerHelper.GetInstance().ParseXHtml(writer, document, htmlMemoryStream, null, Encoding.UTF8, new UnicodeFontFactory());
                            }
                            //}
                            document.Close();

                            bytes = memoryStream.ToArray();
                        }

                        //var testFile = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.Desktop), MaNhanVien + "_" + HoTen + ".pdf");
                        var testFile = Path.Combine(Path.GetTempPath(), MaNhanVien + "_" + HoTen + ".pdf");
                        System.IO.File.WriteAllBytes(testFile, bytes);

                        //Send mail
                        string emailAddress = listInfo[0].Replace("EmailAddress: ", "").TrimStart();
                        string password = listInfo[1].Replace("Password: ", "").TrimStart();
                        MimeMessage message = new MimeMessage();
                        message.From.Add(new MailboxAddress("PHIEU LUONG", emailAddress));
                        //message.To.Add(MailboxAddress.Parse("toiluoncodon1996@gmail.com"));
                        message.To.Add(new MailboxAddress(HoTen, DGV_NhanVien.CurrentRow.Cells["Email"].Value.ToString()));
                        message.Subject = listInfo[2].Replace("Subject: ", "").TrimStart();
                        var emailBody = new MimeKit.BodyBuilder
                        {
                            TextBody = listInfo[3]
                            .Replace("[HoTen]", HoTen)
                            .Replace("TextBody:", "").TrimStart()
                            .Replace("TuThang", "01/" + Thang)
                            .Replace("DenThang", DateTime.Parse(Thang).AddMonths(1).AddDays(-1).ToString("dd/MM/yyyy")).TrimStart()
                        };
                        emailBody.Attachments.Add(testFile);
                        message.Body = emailBody.ToMessageBody();
                        client.Connect("smtp.gmail.com", 465, true);
                        client.Authenticate(emailAddress, password);
                        client.Send(message);
                        if (File.Exists(testFile))
                        {
                            File.Delete(testFile);
                        }
                        WB.Save();
                        WB.Close();
                    }
                    catch (Exception ex)
                    {
                        WB.Save();
                        WB.Close();
                        throw new Exception(ex.Message);
                    }
                    finally
                    {
                        client.Disconnect(true);
                        client.Dispose();
                    }
                    txt_noti.Text = "Gửi mail thành công";
                    RJMessageBox.Show("Gửi mail thành công");
                }
                catch (Exception ex)
                {
                    WB.Save();
                    WB.Close();
                    txt_noti.Text = "Gửi mail lỗi";
                    RJMessageBox.Show(ex.Message);
                }
                Cursor.Current = Cursors.Default;
            }
        }
    }
    public class NhanVienModel
    {
        public bool col_check { get; set; }
        public string MaNhanVien { get; set; }
        public string TenNhanVien { get; set; }
        public string PhongBan { get; set; }
        public string Email { get; set; }
    }
    public class UnicodeFontFactory : FontFactoryImp
    {
        private static readonly string FontPath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.Fonts),
          "tahoma.ttf");

        private readonly BaseFont _baseFont;

        public UnicodeFontFactory()
        {
            _baseFont = BaseFont.CreateFont(FontPath, BaseFont.IDENTITY_H, BaseFont.EMBEDDED);

        }

        public override Font GetFont(string fontname, string encoding, bool embedded, float size, int style, BaseColor color,
          bool cached)
        {
            return new Font(_baseFont, size, style, color);
        }
    }
}
