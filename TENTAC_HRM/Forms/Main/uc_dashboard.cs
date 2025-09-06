using NPOI.HSSF.Util;
using System;
using System.Data;
using System.Drawing;
using System.IO;
using System.Windows.Forms;
using TENTAC_HRM.Common;
using TENTAC_HRM.Custom;
using TENTAC_HRM.Properties;
using HorizontalAlignment = NPOI.SS.UserModel.HorizontalAlignment;

namespace TENTAC_HRM.Forms.Main
{
    public partial class uc_dashboard : UserControl
    {
        Label lb_menu;
        Panel panel = new Panel();
        private bool isCollapsed = false;
        DataProvider provider = new DataProvider();
        public static uc_dashboard _instance;
        public static uc_dashboard Instance
        {
            get
            {
                if (_instance == null)
                    _instance = new uc_dashboard();
                return _instance;
            }
        }
        public uc_dashboard()
        {
            InitializeComponent();
        }

        private void uc_dashboard_Load(object sender, EventArgs e)
        {
            LoadSinhNhat();
            LoadNhanVienMoi();
        }

        private void LoadNhanVienMoi()
        {
            string sql = $@"select manhanvien,TenNhanVien,ngayvaolamviec 
                        from MITACOSQL.dbo.NHANVIEN 
                        where datediff(day,ngayvaolamviec,GETDATE()) <= 30";
            DataTable dt = SQLHelper.ExecuteDt(sql);
            dgv_NhanVienMoi.DataSource = dt;
            grb_NhanVienMoi.Text = $"{dt.Rows.Count} Nhân viên mới";
        }
        public void LoadSinhNhat()
        {
            string sql = $@"select MaNhanVien,TenNhanVien,case when nhanvien.MaKhuVuc = 'KV00003' then N'Thai sản' else TenPhongBan end TenPhongBan,convert(date,NgaySinh) NgaySinh 
                        from MITACOSQL.dbo.NHANVIEN nhanvien 
                        left join MITACOSQL.dbo.PHONGBAN phongban on nhanvien.MaPhongBan = phongban.MaPhongBan 
                        where MONTH(NgaySinh) = MONTH(GETDATE()) and nhanvien.MaCongTy is not null 
                        order by MaNhanVien";
            DataTable dt = SQLHelper.ExecuteDt(sql);
            dgv_SinhNhat.DataSource = dt;
            grb_SinhNhat.Text = $"{dt.Rows.Count} Nhân viên có sinh nhật tháng này";
        }
        private void timer1_Tick(object sender, EventArgs e)
        {
            if (isCollapsed)
            {
                lb_menu.Image = Resources.up_arrow;
                panel.Height += 10;
                if (panel.Size == panel.MaximumSize)
                {
                    timer1.Stop();
                    isCollapsed = false;
                }
            }
            else
            {
                lb_menu.Image = Resources.dow_arrow;
                panel.Height -= 10;
                if (panel.Size == panel.MinimumSize)
                {
                    timer1.Stop();
                    isCollapsed = true;
                }
            }
        }

        private void dgv_SinhNhat_RowPostPaint(object sender, DataGridViewRowPostPaintEventArgs e)
        {
            var grid = sender as DataGridView;
            var rowIdx = (e.RowIndex + 1).ToString();
            var centerFormat = new StringFormat
            {
                Alignment = StringAlignment.Center,
                LineAlignment = StringAlignment.Center
            };
            var textSize = TextRenderer.MeasureText(rowIdx, Font);
            if (grid.RowHeadersWidth < textSize.Width + 20)
            {
                grid.RowHeadersWidth = textSize.Width + 20;
            }
            var headerBounds =
                new Rectangle(e.RowBounds.Left, e.RowBounds.Top, grid.RowHeadersWidth, e.RowBounds.Height);
            e.Graphics.DrawString(rowIdx, Font, SystemBrushes.ControlText, headerBounds, centerFormat);
        }

        private void btn_ExportSinhNhat_Click(object sender, EventArgs e)
        {
            Cursor.Current = Cursors.WaitCursor;
            var workPath = $@"{Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData)}\template_work_excel.xlsx";
            if (File.Exists(workPath))
            {
                File.Delete(workPath);
            }
            try
            {
                var xlsBook = new XlsWorkBook(workPath);
                var style_color = xlsBook.GeCellStyleAlignment(HorizontalAlignment.Left, HSSFColor.BlueGrey.Index, fontHeight: 11);
                var style_detal = xlsBook.GeCellStyleAlignment(HorizontalAlignment.Left, fontHeight: 11);
                var xlsSheet = xlsBook.Sheet(0);

                xlsSheet.SetColumnWidth(0, 900);
                xlsSheet.SetColumnWidth(1, 3000);
                xlsSheet.SetColumnWidth(2, 5000);
                xlsSheet.SetColumnWidth(3, 2500);
                xlsSheet.SetColumnWidth(4, 3000);

                xlsSheet.Cell(0, 0).SetValue("Stt");
                xlsSheet.Cell(0, 0).SetStyle(style_color);
                xlsSheet.Cell(0, 1).SetValue("Mã nhân viên");
                xlsSheet.Cell(0, 1).SetStyle(style_color);
                xlsSheet.Cell(0, 2).SetValue("Tên nhân viên");
                xlsSheet.Cell(0, 2).SetStyle(style_color);
                xlsSheet.Cell(0, 3).SetValue("Phòng ban");
                xlsSheet.Cell(0, 3).SetStyle(style_color);
                xlsSheet.Cell(0, 4).SetValue("Ngày sinh");
                xlsSheet.Cell(0, 4).SetStyle(style_color);
                int index = 1;
                foreach (DataGridViewRow item in dgv_SinhNhat.Rows)
                {
                    xlsSheet.Cell(index, 0).SetValue(index);
                    xlsSheet.Cell(index, 0).SetStyle(style_detal);
                    xlsSheet.Cell(index, 1).SetValue(item.Cells["MaNhanVien"].Value.ToString());
                    xlsSheet.Cell(index, 1).SetStyle(style_detal);
                    xlsSheet.Cell(index, 2).SetValue(item.Cells["TenNhanVien"].Value.ToString());
                    xlsSheet.Cell(index, 2).SetStyle(style_detal);
                    xlsSheet.Cell(index, 3).SetValue(item.Cells["TenPhongBan"].Value.ToString());
                    xlsSheet.Cell(index, 3).SetStyle(style_detal);
                    xlsSheet.Cell(index, 4).SetValue(DateTime.Parse(item.Cells["NgaySinh"].Value.ToString()).ToString("dd/MM/yyyy"));
                    xlsSheet.Cell(index, 4).SetStyle(style_detal);

                    index++;
                }
                xlsBook.SetSheetName(0, "Sinh nhật tháng " + DateTime.Now.Month);
                if (!Directory.Exists(Environment.GetFolderPath(Environment.SpecialFolder.Desktop))) Directory.CreateDirectory(Environment.GetFolderPath(Environment.SpecialFolder.Desktop));

                // 保存
                xlsBook.Save($@"{Environment.GetFolderPath(Environment.SpecialFolder.Desktop)}\DanhSachSinhNhatThang_" + DateTime.Now.Month + "_" + DateTime.Now.Year + ".xlsx");

                // ワークファイル削除
                File.Delete(workPath);

                RJMessageBox.Show("Xuất excel thành công \n" + $@"{Environment.GetFolderPath(Environment.SpecialFolder.Desktop)}\DanhSachSinhNhatThang_" + DateTime.Now.Month + "_" + DateTime.Now.Year + ".xlsx", "Thông báo");
            }
            catch (Exception ex)
            {
                RJMessageBox.Show(ex.Message, "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            Cursor.Current = Cursors.Default;
        }
    }
}
