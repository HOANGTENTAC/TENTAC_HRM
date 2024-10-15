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
using System.Net.Mail;
using System.Reflection;
using System.Text;
using System.Windows.Forms;
using TENTAC_HRM.Common;
using TENTAC_HRM.Custom;
using Font = iTextSharp.text.Font;
using Image = iTextSharp.text.Image;

namespace TENTAC_HRM.Forms.Luong
{
    public partial class frm_GuiBangLuongEmail : Form
    {
        public frm_GuiBangLuongEmail()
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
                        this.xlSheet = xlBook.GetSheetAt(1);
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
            int count = 0;
            int countfalse = 0;
            string nhanvienloi = "";
            Cursor.Current = Cursors.WaitCursor;
            MailKit.Net.Smtp.SmtpClient client = new MailKit.Net.Smtp.SmtpClient();
            var xlsBook = new XlsWorkBook(filepaths);
            try
            {
                var asm = Assembly.GetEntryAssembly();
                string filepath = $@"{Path.GetDirectoryName(asm.Location)}\Template\PhieuLuong.html";
                StreamReader read = new StreamReader(filepath, Encoding.Unicode);
                string html_template = read.ReadToEnd();

                var checkedRows = from DataGridViewRow r in DGV_NhanVien.Rows
                                  where Convert.ToBoolean(r.Cells[0].Value) == true
                                  select r;

                string fileMailInfo = $@"{Path.GetDirectoryName(asm.Location)}\Template\InfoMail.txt";
                string infoFile = File.ReadAllText(fileMailInfo);
                List<string> listInfo = new List<string>();
                listInfo = infoFile.Split(';').ToList();
                foreach (var item in checkedRows)
                {
                    if (Convert.ToBoolean(item.Cells["col_check"].Value) == true && !string.IsNullOrEmpty(item.Cells["Email"].Value.ToString()))
                    {
                        try
                        {
                            string html = html_template;
                            Byte[] bytes;
                            var xlsSheet = xlsBook.Sheet(0);
                            xlsSheet.Cell(3, 2).SetValue(item.Cells["MaNhanVien"].Value.ToString());
                            string Thang = xlsSheet.Cell(1, 4).GetValue();
                            // Thong tin cong nhan vien
                            string MaNhanVien = xlsSheet.Cell(3, 2).GetValue();
                            string HoTen = xlsSheet.Cell(4, 2).GetValue();
                            string BoPhan = xlsSheet.Cell(5, 2).GetValue();
                            string ChucVu = xlsSheet.Cell(6, 2).GetValue();
                            string STK = xlsSheet.Cell(7, 2).GetValue();
                            string NganHang = xlsSheet.Cell(3, 4).GetValue();
                            string Email = xlsSheet.Cell(4, 4).GetValue();
                            string NgayTraLuong = xlsSheet.Cell(5, 4).GetValue();
                            string NgayPhepConLai = xlsSheet.Cell(6, 4).GetValue();
                            // Luong theo hop dong lao dong
                            string LuongTheoHopDong = xlsSheet.Cell(8, 3).GetValue();
                            string LuongCoBan = xlsSheet.Cell(9, 2).GetValue();
                            string TC_TrachNhiem = xlsSheet.Cell(10, 2).GetValue();
                            string TC_DocHai = xlsSheet.Cell(11, 2).GetValue();
                            string TC_XeNang = xlsSheet.Cell(12, 2).GetValue();
                            string TC_Nha = xlsSheet.Cell(13, 2).GetValue();
                            string TC_DiLai = xlsSheet.Cell(9, 4).GetValue();
                            string TC_ChuyenCan = xlsSheet.Cell(10, 4).GetValue();
                            string TC_Khac = xlsSheet.Cell(11, 4).GetValue();
                            // Tong thu nhap thuc te
                            string TongThuNhapThucTe = xlsSheet.Cell(14, 3).GetValue();
                            string CongThuViec = xlsSheet.Cell(15, 2).GetValue();
                            string LuongThuViec = xlsSheet.Cell(16, 2).GetValue();
                            string CongLamChinhThuc = xlsSheet.Cell(17, 2).GetValue();
                            string LuongChinhThuc = xlsSheet.Cell(18, 2).GetValue();
                            string CaDem30 = xlsSheet.Cell(19, 2).GetValue();
                            string TienCaDem = xlsSheet.Cell(20, 2).GetValue();
                            string TangCa150 = xlsSheet.Cell(21, 2).GetValue();
                            string TienTangCa150 = xlsSheet.Cell(22, 2).GetValue();
                            string TangCa200 = xlsSheet.Cell(23, 2).GetValue();
                            string TienTangCa200 = xlsSheet.Cell(24, 2).GetValue();
                            string TangCa210 = xlsSheet.Cell(25, 2).GetValue();
                            string TienTangCa210 = xlsSheet.Cell(26, 2).GetValue();
                            string TangCa270 = xlsSheet.Cell(27, 2).GetValue();
                            string TienTangCa270 = xlsSheet.Cell(28, 2).GetValue();
                            string TangCa300 = xlsSheet.Cell(29, 2).GetValue();
                            string TienTangCa300 = xlsSheet.Cell(30, 2).GetValue();
                            string TC_TrachNhiem_TT = xlsSheet.Cell(15, 4).GetValue();
                            string TC_DocHai_TT = xlsSheet.Cell(16, 4).GetValue();
                            string TC_KyNang = xlsSheet.Cell(17, 4).GetValue();
                            string TC_Nha_TT = xlsSheet.Cell(18, 4).GetValue();
                            string TC_DiLai_TT = xlsSheet.Cell(19, 4).GetValue();
                            string TC_ChuyenCan_TT = xlsSheet.Cell(20, 4).GetValue();
                            string TC_PCCC = xlsSheet.Cell(21, 4).GetValue();
                            string TC_GuiTre = xlsSheet.Cell(22, 4).GetValue();
                            string TC_ATVSV = xlsSheet.Cell(23, 4).GetValue();
                            string TC_PhuNu = xlsSheet.Cell(24, 4).GetValue();
                            string TienTangCa = xlsSheet.Cell(25, 4).GetValue();
                            string TC_Khac_TT = xlsSheet.Cell(26, 4).GetValue();
                            string DieuChinh = xlsSheet.Cell(27, 4).GetValue();
                            // cac khoan thu nhap khac
                            string SoNgayPhepThua = xlsSheet.Cell(32, 2).GetValue();
                            string TienPhepThua = xlsSheet.Cell(33, 2).GetValue();
                            // Tien thuong
                            string LuongCoBan_Thuong = xlsSheet.Cell(35, 2).GetValue();
                            string TC_TinhThuong = xlsSheet.Cell(36, 2).GetValue();
                            string CanCuTinhThuong = xlsSheet.Cell(37, 2).GetValue();
                            string XepLoaiCuoiCung = xlsSheet.Cell(38, 2).GetValue();
                            string TyLeThuong = xlsSheet.Cell(39, 2).GetValue();
                            string HeSoTinh = xlsSheet.Cell(40, 2).GetValue();
                            string SoTienThuong = xlsSheet.Cell(35, 4).GetValue();
                            string NgayTraLuong_Thuong = xlsSheet.Cell(36, 4).GetValue();
                            string Khac = xlsSheet.Cell(37, 4).GetValue();
                            string GhiChu = xlsSheet.Cell(38, 4).GetValue();
                            // tong cac khoan giam tru luong
                            string TongCacKhoanGiamTruLuong = xlsSheet.Cell(41, 3).GetValue();
                            string BaoHiemBatBuoc = xlsSheet.Cell(42, 2).GetValue();
                            string DoanPhi = xlsSheet.Cell(43, 2).GetValue();
                            string ThueThuNhapCaNhan = xlsSheet.Cell(44, 2).GetValue();
                            string TruKhac = xlsSheet.Cell(45, 2).GetValue();
                            string QuyPCT = xlsSheet.Cell(42, 4).GetValue();
                            // thu nhap thuc linh
                            string ThuNhapThucLinh = xlsSheet.Cell(46, 3).GetValue();
                            string GhiChu_ThucLinh = xlsSheet.Cell(47, 2).GetValue();

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

                                .Replace("[LuongTheoHopDong]", string.IsNullOrEmpty(LuongTheoHopDong) ? "0" : int.Parse(LuongTheoHopDong).ToString("#,##0"))
                                .Replace("[LuongCoban]", string.IsNullOrEmpty(LuongCoBan) ? "0" : int.Parse(LuongCoBan).ToString("#,##0"))
                                .Replace("[TC_TrachNhiem]", string.IsNullOrEmpty(TC_TrachNhiem) ? "0" : int.Parse(TC_TrachNhiem).ToString("#,##0"))
                                .Replace("[TCDocHai]", string.IsNullOrEmpty(TC_DocHai) ? "0" : int.Parse(TC_DocHai).ToString("#,##0"))
                                .Replace("[TC_XeNang]", string.IsNullOrEmpty(TC_XeNang) ? "0" : int.Parse(TC_XeNang).ToString("#,##0"))
                                .Replace("[TC_Nha]", string.IsNullOrEmpty(TC_Nha) ? "0" : int.Parse(TC_Nha).ToString("#,##0"))
                                .Replace("[TC_DiLai]", string.IsNullOrEmpty(TC_DiLai) ? "0" : int.Parse(TC_DiLai).ToString("#,##0"))
                                .Replace("[TC_ChuyenCan]", string.IsNullOrEmpty(TC_ChuyenCan) ? "0" : int.Parse(TC_ChuyenCan).ToString("#,##0"))
                                .Replace("[TC_Khac]", TC_Khac == "0" || string.IsNullOrEmpty(TC_Khac) ? "--" : TC_Khac)

                                .Replace("[TongThuNhapThucTe]", string.IsNullOrEmpty(TongThuNhapThucTe) ? "0" : int.Parse(TongThuNhapThucTe).ToString("#,##0"))
                                .Replace("[CongThuViec]", string.IsNullOrEmpty(CongThuViec) ? "0.0" : int.Parse(CongThuViec).ToString("#.0"))
                                .Replace("[LuongThuViec]", LuongThuViec)
                                .Replace("[CongLamChinhThuc]", string.IsNullOrEmpty(CongLamChinhThuc) ? "0.0" : int.Parse(CongLamChinhThuc).ToString("#.0"))
                                .Replace("[LuongChinhThuc]", string.IsNullOrEmpty(LuongChinhThuc) ? "0" : int.Parse(LuongChinhThuc).ToString("#,##0"))
                                .Replace("[CaDem]", string.IsNullOrEmpty(CaDem30) ? "0.0" : int.Parse(CaDem30).ToString("#.0"))
                                .Replace("[TienCaDem]", TienCaDem)
                                .Replace("[TangCa150]", string.IsNullOrEmpty(TangCa150) ? "0.0" : int.Parse(TangCa150).ToString("#.0"))
                                .Replace("[TienTangCa150]", TienTangCa150)
                                .Replace("[TangCa200]", string.IsNullOrEmpty(TangCa200) ? "0.0" : int.Parse(TangCa200).ToString("#.0"))
                                .Replace("[TienTangCa200]", TienTangCa200)
                                .Replace("[TangCa210]", string.IsNullOrEmpty(TangCa210) ? "0.0" : int.Parse(TangCa210).ToString("#.0"))
                                .Replace("[TienTangCa210]", TienTangCa210)
                                .Replace("[TangCa270]", string.IsNullOrEmpty(TangCa270) ? "0.0" : int.Parse(TangCa270).ToString("#.0"))
                                .Replace("[TienTangCa270]", TienTangCa270)
                                .Replace("[TangCa300]", string.IsNullOrEmpty(TangCa300) ? "0.0" : int.Parse(TangCa300).ToString("#.0"))
                                .Replace("[TienTangCa300]", TienTangCa300)
                                .Replace("[TC_TrachNhiem_TT]", string.IsNullOrEmpty(TC_TrachNhiem_TT) ? "0" : int.Parse(TC_TrachNhiem_TT).ToString("#,##0"))
                                .Replace("[TC_DocHai_TT]", string.IsNullOrEmpty(TC_DocHai_TT) ? "0" : int.Parse(TC_DocHai_TT).ToString("#,##0"))
                                .Replace("[TC_KyNang]", string.IsNullOrEmpty(TC_KyNang) ? "0" : int.Parse(TC_KyNang).ToString("#,##0"))
                                .Replace("[TC_Nha_TT]", string.IsNullOrEmpty(TC_Nha_TT) ? "0" : int.Parse(TC_Nha_TT).ToString("#,##0"))
                                .Replace("[TC_DiLai_TT]", string.IsNullOrEmpty(TC_DiLai_TT) ? "0" : int.Parse(TC_DiLai_TT).ToString("#,##0"))
                                .Replace("[TC_ChuyenCan_TT]", string.IsNullOrEmpty(TC_ChuyenCan_TT) ? "0" : int.Parse(TC_ChuyenCan_TT).ToString("#,##0"))
                                .Replace("[TC_PCCC]", string.IsNullOrEmpty(TC_PCCC) ? "0" : int.Parse(TC_PCCC).ToString("#,##0"))
                                .Replace("[TC_GuiTre]", string.IsNullOrEmpty(TC_GuiTre) ? "0" : int.Parse(TC_GuiTre).ToString("#,##0"))
                                .Replace("[TC_ATVSV]", string.IsNullOrEmpty(TC_ATVSV) ? "0" : int.Parse(TC_ATVSV).ToString("#,##0"))
                                .Replace("[TC_PhuNu]", string.IsNullOrEmpty(TC_PhuNu) ? "0" : int.Parse(TC_PhuNu).ToString("#,##0"))
                                .Replace("[TienTangCa]", string.IsNullOrEmpty(TienTangCa) ? "0" : int.Parse(TienTangCa).ToString("#,##0"))
                                .Replace("[TC_Khac_TT]", TC_Khac_TT == "0" || string.IsNullOrEmpty(TC_Khac_TT) ? "--" : int.Parse(TC_Khac_TT).ToString("#,##0"))
                                .Replace("[DieuChinh]", string.IsNullOrEmpty(DieuChinh) ? "0" : int.Parse(DieuChinh).ToString("#,##0"))

                                .Replace("[SoNgayPhepThua]", SoNgayPhepThua == "0" || string.IsNullOrEmpty(SoNgayPhepThua) ? "--" : int.Parse(SoNgayPhepThua).ToString("#.0"))
                                .Replace("[TienPhepThua]", TienPhepThua == "0" || string.IsNullOrEmpty(TienPhepThua) ? "--" : int.Parse(TienPhepThua).ToString("#,##0"))

                                .Replace("[LuongCoBan]", LuongCoBan_Thuong == "0" || string.IsNullOrEmpty(LuongCoBan_Thuong) ? "--" : int.Parse(LuongCoBan_Thuong).ToString("#,##0"))
                                .Replace("[TC_TinhThuong]", TC_TinhThuong == "0" || string.IsNullOrEmpty(TC_TinhThuong) ? "--" : int.Parse(TC_TinhThuong).ToString("#,##0"))
                                .Replace("[CanCuTinhThuong]", CanCuTinhThuong == "0" || string.IsNullOrEmpty(CanCuTinhThuong) ? "--" : int.Parse(CanCuTinhThuong).ToString("#,##0"))
                                .Replace("[XepLoaiCuoiCung]", (XepLoaiCuoiCung == "0" || string.IsNullOrEmpty(XepLoaiCuoiCung) ? "--" : XepLoaiCuoiCung))
                                .Replace("[TyLeThuong]", TyLeThuong == "0" || string.IsNullOrEmpty(TyLeThuong) ? "--" : int.Parse(TyLeThuong).ToString("#.00"))
                                .Replace("[HeSoTinh]", HeSoTinh == "0" || string.IsNullOrEmpty(HeSoTinh) ? "--" : int.Parse(HeSoTinh).ToString("#.00"))
                                .Replace("[SoTienThuong]", SoTienThuong == "0" || string.IsNullOrEmpty(SoTienThuong) ? "--" : int.Parse(SoTienThuong).ToString("#,##0"))
                                .Replace("[NgayTraLuong_Thuong]", NgayTraLuong_Thuong == "0" || string.IsNullOrEmpty(NgayTraLuong_Thuong) ? "--" : NgayTraLuong_Thuong)
                                .Replace("[Khac]", Khac == "0" || string.IsNullOrEmpty(Khac) ? "--" : Khac)
                                .Replace("[GhiChu]", GhiChu == "0" || string.IsNullOrEmpty(GhiChu) ? "--" : GhiChu)

                                .Replace("[TongCacKhoanGiamTruLuong]", string.IsNullOrEmpty(TongCacKhoanGiamTruLuong) ? "0" : int.Parse(TongCacKhoanGiamTruLuong).ToString("#,##0"))
                                .Replace("[BaoHiemBatBuoc]", string.IsNullOrEmpty(BaoHiemBatBuoc) ? "0" : int.Parse(BaoHiemBatBuoc).ToString("#,##0"))
                                .Replace("[DoanPhi]", string.IsNullOrEmpty(DoanPhi) ? "0" : int.Parse(DoanPhi).ToString("#,##0"))
                                .Replace("[TTNCN]", string.IsNullOrEmpty(ThueThuNhapCaNhan) ? "0" : int.Parse(ThueThuNhapCaNhan).ToString("#,##0"))
                                .Replace("[QuyPCTT]", QuyPCT == "0" || string.IsNullOrEmpty(QuyPCT) ? "--" : int.Parse(QuyPCT).ToString("#,##0"))
                                .Replace("[TruKhac]", TruKhac)

                                .Replace("[ThuNhapThucLinh]", string.IsNullOrEmpty(ThuNhapThucLinh) ? "0" : int.Parse(ThuNhapThucLinh).ToString("#,##0"))
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

                            // Send mail
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
                    }
                }
                txt_noti.Text = "Số mail gửi thành cong : " + count + Environment.NewLine +
                                "Số mail gửi thất bại : 0 " + Environment.NewLine +
                                "Tổng mail : " + DGV_NhanVien.Rows.Count;
                nhanvienloi = "";
                RJMessageBox.Show("Gửi mail thành công");
            }
            catch (Exception ex)
            {
                txt_noti.Text = "Số mail gửi thành cong : " + count + Environment.NewLine +
                "Số mail gửi thất bại : 1" +
                "Thông tin : " + nhanvienloi +
                "Tổng mail : " + DGV_NhanVien.Rows.Count;
                RJMessageBox.Show(ex.Message);
            }
            finally
            {
                xlsBook.Save();
                xlsBook.Dispose();
                client.Disconnect(true);
                client.Dispose();
            }
            Cursor.Current = Cursors.Default;
        }

        private void Btn_Setting_Click(object sender, EventArgs e)
        {
            frm_Setting frm = new frm_Setting();
            frm.ShowDialog();
        }

        private void btn_TestMail_Click(object sender, EventArgs e)
        {
            Cursor.Current = Cursors.WaitCursor;
            MailKit.Net.Smtp.SmtpClient client = new MailKit.Net.Smtp.SmtpClient();
            var xlsBook = new XlsWorkBook(filepaths);
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
                    var xlsSheet = xlsBook.Sheet(0);
                    xlsSheet.Cell(3, 2).SetValue(DGV_NhanVien.Rows[0].Cells["MaNhanVien"].Value.ToString());
                    string Thang = xlsSheet.Cell(1, 4).GetValue();
                    // Thong tin cong nhan vien
                    string MaNhanVien = xlsSheet.Cell(3, 2).GetValue();
                    string HoTen = xlsSheet.Cell(4, 2).GetValue();
                    string BoPhan = xlsSheet.Cell(5, 2).GetValue();
                    string ChucVu = xlsSheet.Cell(6, 2).GetValue();
                    string STK = xlsSheet.Cell(7, 2).GetValue();
                    string NganHang = xlsSheet.Cell(3, 4).GetValue();
                    string Email = xlsSheet.Cell(4, 4).GetValue();
                    string NgayTraLuong = xlsSheet.Cell(5, 4).GetValue();
                    string NgayPhepConLai = xlsSheet.Cell(6, 4).GetValue();
                    // Luong theo hop dong lao dong
                    string LuongTheoHopDong = xlsSheet.Cell(8, 3).GetValue();
                    string LuongCoBan = xlsSheet.Cell(9, 2).GetValue();
                    string TC_TrachNhiem = xlsSheet.Cell(10, 2).GetValue();
                    string TC_DocHai = xlsSheet.Cell(11, 2).GetValue();
                    string TC_XeNang = xlsSheet.Cell(12, 2).GetValue();
                    string TC_Nha = xlsSheet.Cell(13, 2).GetValue();
                    string TC_DiLai = xlsSheet.Cell(9, 4).GetValue();
                    string TC_ChuyenCan = xlsSheet.Cell(10, 4).GetValue();
                    string TC_Khac = xlsSheet.Cell(11, 4).GetValue();
                    // Tong thu nhap thuc te
                    string TongThuNhapThucTe = xlsSheet.Cell(14, 3).GetValue();
                    string CongThuViec = xlsSheet.Cell(15, 2).GetValue();
                    string LuongThuViec = xlsSheet.Cell(16, 2).GetValue();
                    string CongLamChinhThuc = xlsSheet.Cell(17, 2).GetValue();
                    string LuongChinhThuc = xlsSheet.Cell(18, 2).GetValue();
                    string CaDem30 = xlsSheet.Cell(19, 2).GetValue();
                    string TienCaDem = xlsSheet.Cell(20, 2).GetValue();
                    string TangCa150 = xlsSheet.Cell(21, 2).GetValue();
                    string TienTangCa150 = xlsSheet.Cell(22, 2).GetValue();
                    string TangCa200 = xlsSheet.Cell(23, 2).GetValue();
                    string TienTangCa200 = xlsSheet.Cell(24, 2).GetValue();
                    string TangCa210 = xlsSheet.Cell(25, 2).GetValue();
                    string TienTangCa210 = xlsSheet.Cell(26, 2).GetValue();
                    string TangCa270 = xlsSheet.Cell(27, 2).GetValue();
                    string TienTangCa270 = xlsSheet.Cell(28, 2).GetValue();
                    string TangCa300 = xlsSheet.Cell(29, 2).GetValue();
                    string TienTangCa300 = xlsSheet.Cell(30, 2).GetValue();
                    string TC_TrachNhiem_TT = xlsSheet.Cell(15, 4).GetValue();
                    string TC_DocHai_TT = xlsSheet.Cell(16, 4).GetValue();
                    string TC_KyNang = xlsSheet.Cell(17, 4).GetValue();
                    string TC_Nha_TT = xlsSheet.Cell(18, 4).GetValue();
                    string TC_DiLai_TT = xlsSheet.Cell(19, 4).GetValue();
                    string TC_ChuyenCan_TT = xlsSheet.Cell(20, 4).GetValue();
                    string TC_PCCC = xlsSheet.Cell(21, 4).GetValue();
                    string TC_GuiTre = xlsSheet.Cell(22, 4).GetValue();
                    string TC_ATVSV = xlsSheet.Cell(23, 4).GetValue();
                    string TC_PhuNu = xlsSheet.Cell(24, 4).GetValue();
                    string TienTangCa = xlsSheet.Cell(25, 4).GetValue();
                    string TC_Khac_TT = xlsSheet.Cell(26, 4).GetValue();
                    string DieuChinh = xlsSheet.Cell(27, 4).GetValue();
                    // cac khoan thu nhap khac
                    string SoNgayPhepThua = xlsSheet.Cell(32, 2).GetValue();
                    string TienPhepThua = xlsSheet.Cell(33, 2).GetValue();
                    // Tien thuong
                    string LuongCoBan_Thuong = xlsSheet.Cell(35, 2).GetValue();
                    string TC_TinhThuong = xlsSheet.Cell(36, 2).GetValue();
                    string CanCuTinhThuong = xlsSheet.Cell(37, 2).GetValue();
                    string XepLoaiCuoiCung = xlsSheet.Cell(38, 2).GetValue();
                    string TyLeThuong = xlsSheet.Cell(39, 2).GetValue();
                    string HeSoTinh = xlsSheet.Cell(40, 2).GetValue();
                    string SoTienThuong = xlsSheet.Cell(35, 4).GetValue();
                    string NgayTraLuong_Thuong = xlsSheet.Cell(36, 4).GetValue();
                    string Khac = xlsSheet.Cell(37, 4).GetValue();
                    string GhiChu = xlsSheet.Cell(38, 4).GetValue();
                    // tong cac khoan giam tru luong
                    string TongCacKhoanGiamTruLuong = xlsSheet.Cell(41, 3).GetValue();
                    string BaoHiemBatBuoc = xlsSheet.Cell(42, 2).GetValue();
                    string DoanPhi = xlsSheet.Cell(43, 2).GetValue();
                    string ThueThuNhapCaNhan = xlsSheet.Cell(44, 2).GetValue();
                    string TruKhac = xlsSheet.Cell(45, 2).GetValue();
                    string QuyPCT = xlsSheet.Cell(42, 4).GetValue();
                    // thu nhap thuc linh
                    string ThuNhapThucLinh = xlsSheet.Cell(46, 3).GetValue();
                    string GhiChu_ThucLinh = xlsSheet.Cell(47, 2).GetValue();

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

                        .Replace("[LuongTheoHopDong]", string.IsNullOrEmpty(LuongTheoHopDong) ? "0" : int.Parse(LuongTheoHopDong).ToString("#,##0"))
                        .Replace("[LuongCoban]", string.IsNullOrEmpty(LuongCoBan) ? "0" : int.Parse(LuongCoBan).ToString("#,##0"))
                        .Replace("[TC_TrachNhiem]", string.IsNullOrEmpty(TC_TrachNhiem) ? "0" : int.Parse(TC_TrachNhiem).ToString("#,##0"))
                        .Replace("[TCDocHai]", string.IsNullOrEmpty(TC_DocHai) ? "0" : int.Parse(TC_DocHai).ToString("#,##0"))
                        .Replace("[TC_XeNang]", string.IsNullOrEmpty(TC_XeNang) ? "0" : int.Parse(TC_XeNang).ToString("#,##0"))
                        .Replace("[TC_Nha]", string.IsNullOrEmpty(TC_Nha) ? "0" : int.Parse(TC_Nha).ToString("#,##0"))
                        .Replace("[TC_DiLai]", string.IsNullOrEmpty(TC_DiLai) ? "0" : int.Parse(TC_DiLai).ToString("#,##0"))
                        .Replace("[TC_ChuyenCan]", string.IsNullOrEmpty(TC_ChuyenCan) ? "0" : int.Parse(TC_ChuyenCan).ToString("#,##0"))
                        .Replace("[TC_Khac]", TC_Khac == "0" || string.IsNullOrEmpty(TC_Khac) ? "--" : TC_Khac)

                        .Replace("[TongThuNhapThucTe]", string.IsNullOrEmpty(TongThuNhapThucTe) ? "0" : int.Parse(TongThuNhapThucTe).ToString("#,##0"))
                        .Replace("[CongThuViec]", string.IsNullOrEmpty(CongThuViec) ? "0.0" : int.Parse(CongThuViec).ToString("#.0"))
                        .Replace("[LuongThuViec]", LuongThuViec)
                        .Replace("[CongLamChinhThuc]", string.IsNullOrEmpty(CongLamChinhThuc) ? "0.0" : int.Parse(CongLamChinhThuc).ToString("#.0"))
                        .Replace("[LuongChinhThuc]", string.IsNullOrEmpty(LuongChinhThuc) ? "0" : int.Parse(LuongChinhThuc).ToString("#,##0"))
                        .Replace("[CaDem]", string.IsNullOrEmpty(CaDem30) ? "0.0" : int.Parse(CaDem30).ToString("#.0"))
                        .Replace("[TienCaDem]", TienCaDem)
                        .Replace("[TangCa150]", string.IsNullOrEmpty(TangCa150) ? "0.0" : int.Parse(TangCa150).ToString("#.0"))
                        .Replace("[TienTangCa150]", TienTangCa150)
                        .Replace("[TangCa200]", string.IsNullOrEmpty(TangCa200) ? "0.0" : int.Parse(TangCa200).ToString("#.0"))
                        .Replace("[TienTangCa200]", TienTangCa200)
                        .Replace("[TangCa210]", string.IsNullOrEmpty(TangCa210) ? "0.0" : int.Parse(TangCa210).ToString("#.0"))
                        .Replace("[TienTangCa210]", TienTangCa210)
                        .Replace("[TangCa270]", string.IsNullOrEmpty(TangCa270) ? "0.0" : int.Parse(TangCa270).ToString("#.0"))
                        .Replace("[TienTangCa270]", TienTangCa270)
                        .Replace("[TangCa300]", string.IsNullOrEmpty(TangCa300) ? "0.0" : int.Parse(TangCa300).ToString("#.0"))
                        .Replace("[TienTangCa300]", TienTangCa300)
                        .Replace("[TC_TrachNhiem_TT]", string.IsNullOrEmpty(TC_TrachNhiem_TT) ? "0" : int.Parse(TC_TrachNhiem_TT).ToString("#,##0"))
                        .Replace("[TC_DocHai_TT]", string.IsNullOrEmpty(TC_DocHai_TT) ? "0" : int.Parse(TC_DocHai_TT).ToString("#,##0"))
                        .Replace("[TC_KyNang]", string.IsNullOrEmpty(TC_KyNang) ? "0" : int.Parse(TC_KyNang).ToString("#,##0"))
                        .Replace("[TC_Nha_TT]", string.IsNullOrEmpty(TC_Nha_TT) ? "0" : int.Parse(TC_Nha_TT).ToString("#,##0"))
                        .Replace("[TC_DiLai_TT]", string.IsNullOrEmpty(TC_DiLai_TT) ? "0" : int.Parse(TC_DiLai_TT).ToString("#,##0"))
                        .Replace("[TC_ChuyenCan_TT]", string.IsNullOrEmpty(TC_ChuyenCan_TT) ? "0" : int.Parse(TC_ChuyenCan_TT).ToString("#,##0"))
                        .Replace("[TC_PCCC]", string.IsNullOrEmpty(TC_PCCC) ? "0" : int.Parse(TC_PCCC).ToString("#,##0"))
                        .Replace("[TC_GuiTre]", string.IsNullOrEmpty(TC_GuiTre) ? "0" : int.Parse(TC_GuiTre).ToString("#,##0"))
                        .Replace("[TC_ATVSV]", string.IsNullOrEmpty(TC_ATVSV) ? "0" : int.Parse(TC_ATVSV).ToString("#,##0"))
                        .Replace("[TC_PhuNu]", string.IsNullOrEmpty(TC_PhuNu) ? "0" : int.Parse(TC_PhuNu).ToString("#,##0"))
                        .Replace("[TienTangCa]", string.IsNullOrEmpty(TienTangCa) ? "0" : int.Parse(TienTangCa).ToString("#,##0"))
                        .Replace("[TC_Khac_TT]", TC_Khac_TT == "0" || string.IsNullOrEmpty(TC_Khac_TT) ? "--" : int.Parse(TC_Khac_TT).ToString("#,##0"))
                        .Replace("[DieuChinh]", string.IsNullOrEmpty(DieuChinh) ? "0" : int.Parse(DieuChinh).ToString("#,##0"))

                        .Replace("[SoNgayPhepThua]", SoNgayPhepThua == "0" || string.IsNullOrEmpty(SoNgayPhepThua) ? "--" : int.Parse(SoNgayPhepThua).ToString("#.0"))
                        .Replace("[TienPhepThua]", TienPhepThua == "0" || string.IsNullOrEmpty(TienPhepThua) ? "--" : int.Parse(TienPhepThua).ToString("#,##0"))

                        .Replace("[LuongCoBan]", LuongCoBan_Thuong == "0" || string.IsNullOrEmpty(LuongCoBan_Thuong) ? "--" : int.Parse(LuongCoBan_Thuong).ToString("#,##0"))
                        .Replace("[TC_TinhThuong]", TC_TinhThuong == "0" || string.IsNullOrEmpty(TC_TinhThuong) ? "--" : int.Parse(TC_TinhThuong).ToString("#,##0"))
                        .Replace("[CanCuTinhThuong]", CanCuTinhThuong == "0" || string.IsNullOrEmpty(CanCuTinhThuong) ? "--" : int.Parse(CanCuTinhThuong).ToString("#,##0"))
                        .Replace("[XepLoaiCuoiCung]", (XepLoaiCuoiCung == "0" || string.IsNullOrEmpty(XepLoaiCuoiCung) ? "--" : XepLoaiCuoiCung))
                        .Replace("[TyLeThuong]", TyLeThuong == "0" || string.IsNullOrEmpty(TyLeThuong) ? "--" : int.Parse(TyLeThuong).ToString("#.00"))
                        .Replace("[HeSoTinh]", HeSoTinh == "0" || string.IsNullOrEmpty(HeSoTinh) ? "--" : int.Parse(HeSoTinh).ToString("#.00"))
                        .Replace("[SoTienThuong]", SoTienThuong == "0" || string.IsNullOrEmpty(SoTienThuong) ? "--" : int.Parse(SoTienThuong).ToString("#,##0"))
                        .Replace("[NgayTraLuong_Thuong]", NgayTraLuong_Thuong == "0" || string.IsNullOrEmpty(NgayTraLuong_Thuong) ? "--" : NgayTraLuong_Thuong)
                        .Replace("[Khac]", Khac == "0" || string.IsNullOrEmpty(Khac) ? "--" : Khac)
                        .Replace("[GhiChu]", GhiChu == "0" || string.IsNullOrEmpty(GhiChu) ? "--" : GhiChu)

                        .Replace("[TongCacKhoanGiamTruLuong]", string.IsNullOrEmpty(TongCacKhoanGiamTruLuong) ? "0" : int.Parse(TongCacKhoanGiamTruLuong).ToString("#,##0"))
                        .Replace("[BaoHiemBatBuoc]", string.IsNullOrEmpty(BaoHiemBatBuoc) ? "0" : int.Parse(BaoHiemBatBuoc).ToString("#,##0"))
                        .Replace("[DoanPhi]", string.IsNullOrEmpty(DoanPhi) ? "0" : int.Parse(DoanPhi).ToString("#,##0"))
                        .Replace("[TTNCN]", string.IsNullOrEmpty(ThueThuNhapCaNhan) ? "0" : int.Parse(ThueThuNhapCaNhan).ToString("#,##0"))
                        .Replace("[QuyPCTT]", QuyPCT == "0" || string.IsNullOrEmpty(QuyPCT) ? "--" : int.Parse(QuyPCT).ToString("#,##0"))
                        .Replace("[TruKhac]", TruKhac)

                        .Replace("[ThuNhapThucLinh]", string.IsNullOrEmpty(ThuNhapThucLinh) ? "0" : int.Parse(ThuNhapThucLinh).ToString("#,##0"))
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

                    // Send mail
                    string emailTest = listInfo[4].Replace("EmailTest: ", "").TrimStart();
                    string emailAddress = listInfo[0].Replace("EmailAddress: ", "").TrimStart();
                    string password = listInfo[1].Replace("Password: ", "").TrimStart();
                    MimeMessage message = new MimeMessage();
                    message.From.Add(new MailboxAddress("PHIEU LUONG", emailAddress));
                    message.To.Add(new MailboxAddress(HoTen, emailTest));
                    message.Subject = listInfo[2].Replace("Subject: ", "").TrimStart();
                    var emailBody = new MimeKit.BodyBuilder
                    {
                        TextBody = listInfo[3]
                        .Replace("[HoTen]", HoTen)
                        .Replace("TextBody:", "").TrimStart()
                        .Replace("TuThang", "01/" + Thang)
                        .Replace("DenThang", DateTime.Parse(Thang).AddMonths(1).AddDays(-1).ToString("dd/MM/yyyy")).TrimStart() + Environment.NewLine + "MailTest"
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
                xlsBook.Save();
                xlsBook.Dispose();
                client.Disconnect(true);
                client.Dispose();
            }
            Cursor.Current = Cursors.Default;
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
          "arialuni.ttf");

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
