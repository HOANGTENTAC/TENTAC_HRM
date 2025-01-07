using System;
using System.Drawing;
using System.Windows.Forms;
using TENTAC_HRM.Properties;

namespace TENTAC_HRM.Forms.User_control
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
            string sql = "select MaNhanVien,TenNhanVien,case when nhanvien.MaKhuVuc = 'KV00003' then N'Thai sản' else TenPhongBan end TenPhongBan,convert(date,NgaySinh) NgaySinh " +
                "from MITACOSQL.dbo.NHANVIEN nhanvien " +
                "left join MITACOSQL.dbo.PHONGBAN phongban on nhanvien.MaPhongBan = phongban.MaPhongBan " +
                "where MONTH(NgaySinh) = MONTH(GETDATE()) and nhanvien.MaCongTy is not null " +
                "order by MaNhanVien";
            dgv_SinhNhat.DataSource = SQLHelper.ExecuteDt(sql);
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
    }
}
