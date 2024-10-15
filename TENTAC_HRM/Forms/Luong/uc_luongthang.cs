using System;
using System.Drawing;
using System.Windows.Forms;

namespace TENTAC_HRM.Forms.Luong
{
    public partial class uc_luongthang : UserControl
    {
        DataProvider provider = new DataProvider();
        private bool isCollapsed = false;
        public static uc_luongthang _instance;
        public static uc_luongthang Instance
        {
            get
            {
                //if (_instance == null)
                _instance = new uc_luongthang();
                return _instance;
            }
        }
        public uc_luongthang()
        {
            InitializeComponent();
            add_group_header();
        }
        private void uc_luongthang_Load(object sender, EventArgs e)
        {
            pl_info.MaximumSize = new Size(this.Parent.Width, 211);
            pl_info.MinimumSize = new Size(this.Parent.Width, 30);

            for (int i = DateTime.Now.Year - 10; i <= DateTime.Now.Year + 2; i++)
            {
                cbo_year.Items.Add(i.ToString());
            }
            cbo_year.SelectedItem = DateTime.Now.Year.ToString();
            cbo_month.SelectedItem = DateTime.Now.Month.ToString();
        }
        private void add_group_header()
        {
            //this.dgv_bangluong.AddSpanHeader(0, 3, "Thông tin nhân viên");
            //this.dgv_bangluong.AddSpanHeader(3, 2, "Lương căn bản");
            //this.dgv_bangluong.AddSpanHeader(5, 2, "Lương đóng bảo hiểm");
            //this.dgv_bangluong.AddSpanHeader(7, 7, "Phụ cấp & tổng lương");
            //this.dgv_bangluong.AddSpanHeader(14, 4, "Giờ làm việc");
            //this.dgv_bangluong.AddSpanHeader(18, 3, "Ngày làm việc");
            //this.dgv_bangluong.AddSpanHeader(21, 9, "Tăng ca");
            //this.dgv_bangluong.AddSpanHeader(30, 3, "Công tác phí");
            //this.dgv_bangluong.AddSpanHeader(33, 1, "Tiền lương");
            //this.dgv_bangluong.AddSpanHeader(35, 4, "Bảo hiểm do người lao động đóng");
            //this.dgv_bangluong.AddSpanHeader(39, 5, "Bảo hiểm do người sử dụng lao động đóng");
            //this.dgv_bangluong.AddSpanHeader(44, 4, "Giảm trừ thuế");
            //this.dgv_bangluong.AddSpanHeader(48, 3, "Thuế thu nhập cá nhân");
            //this.dgv_bangluong.AddSpanHeader(51, 4, "Sau thuế");
            //this.dgv_bangluong.AddSpanHeader(55, 4, "Thực lãnh và thanh toán lương");

        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            if (isCollapsed)
            {
                btn_close_info.IconChar = FontAwesome.Sharp.IconChar.Xmark;
                pl_info.Height += 10;
                if (pl_info.Size == pl_info.MaximumSize)
                {
                    timer1.Stop();
                    isCollapsed = false;
                }
            }
            else
            {
                btn_close_info.IconChar = FontAwesome.Sharp.IconChar.UpRightFromSquare;
                pl_info.Height -= 10;
                if (pl_info.Size == pl_info.MinimumSize)
                {
                    timer1.Stop();
                    isCollapsed = true;
                }
            }
        }
        private void btn_close_info_Click(object sender, EventArgs e)
        {
            start_timer();
        }
        public void start_timer()
        {
            if (pl_info.Size == pl_info.MaximumSize)
            {
                isCollapsed = false;
            }
            else if (pl_info.Size == pl_info.MinimumSize)
            {
                isCollapsed = true;
            }
            timer1.Start();
        }

        private void btn_close_Click(object sender, EventArgs e)
        {
            provider.btn_close(this.Parent);
        }
    }
}
