using System;
using System.Windows.Forms;
using TENTAC_HRM.Forms.User_control;

namespace TENTAC_HRM.Forms.Main
{
    public partial class frm_main_uc : Form
    {
        public UserControl userControl;
        public frm_personnel form = null;
        public uc_nhan_su uc_nhansu = null;
        public string name_frm;
        public string title_frm;
        public string _ma_nhan_vien { get; set; }
        public string type { get; set; }
        public frm_main_uc(Form _frm = null, UserControl _userControl = null)
        {
            InitializeComponent();
            if(_frm != null)
            {
                form = (frm_personnel)_frm;
            }
            else
            {
                uc_nhansu = (uc_nhan_su)_userControl;
            }
        }

        private void uc_staff_address_saveClick(object sender, EventArgs e)
        {
            if (form != null)
                form.load_diachi();
            else
                uc_nhansu.load_diachi(_ma_nhan_vien);
        }
        private void OnUCButtonClicked(object sender, EventArgs e)
        {
            this.Close();
        }
        private void frm_main_uc_Load(object sender, EventArgs e)
        {
            this.Text = title_frm;
            switch (type)
            {
                case "address":
                    userControl = uc_staff_address.Instance;
                    uc_staff_address.Instance._ma_nhan_vien = _ma_nhan_vien;
                    uc_staff_address.Instance.uc_controll = false;
                    uc_staff_address.Instance.btn_save.Click += uc_staff_address_saveClick;
                    break;
                case "religion":
                    userControl = uc_staff_religion.Instance;
                    break;
                case "nation":
                    userControl = uc_nation.Instance;
                    break;
                //case "nationality":
                //    userControl = uc_nationality.Instance;
                //    break;
                case "nationality":
                    userControl = uc_dvhc.Instance;
                    break;
            }

            if (!pl_main.Controls.Contains(userControl))
            {
                pl_main.Controls.Add(userControl);
                userControl.Dock = DockStyle.Fill;
                userControl.BringToFront();
            }
            else
            {
                userControl.BringToFront();
            }
        }
        private void frm_main_uc_Resize(object sender, EventArgs e)
        {
            //AdjustForm();
        }

        private void frm_main_uc_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
            {
                this.Close();
            }
        }
        //
        //protected override void WndProc(ref Message m)
        //{
        //    const int WM_PAINT = 0x0083;
        //    if (m.Msg == WM_PAINT && m.WParam.ToInt32() == 1)
        //    {
        //        return;
        //    }
        //    base.WndProc(ref m);
        //}
        //private int borderSize = 0;
        //private void AdjustForm()
        //{
        //    switch (this.WindowState)
        //    {
        //        case FormWindowState.Minimized:
        //            this.Padding = new Padding(0,8,8,0);
        //            break;
        //        case FormWindowState.Normal:
        //            if (this.Padding.Top != borderSize)
        //                this.Padding = new Padding(borderSize);
        //            break;
        //    }
        //}
    }
}
