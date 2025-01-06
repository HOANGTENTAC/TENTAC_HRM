using ComponentFactory.Krypton.Toolkit;
using System;
using System.Drawing.Drawing2D;
using System.Drawing;
using System.Runtime.InteropServices;
using System.Windows.Forms;
using TENTAC_HRM.Custom;
using System.Data;
using TENTAC_HRM.Consts;

namespace TENTAC_HRM.Forms.Main
{
    public partial class frm_login : KryptonForm
    {
        DataProvider provider = new DataProvider();

        [DllImport("Gdi32.dll", EntryPoint = "CreateRoundRectRgn")]
        private static extern IntPtr CreateRoundRectRgn
        (
            int nLeftRect,
            int nTopRect,
            int nRightRect,
            int nBottomRect,
            int nWidthEllipse,
            int nHeightEllipse
        );
        public frm_login()
        {
            InitializeComponent();
            init_data();
            //this.FormBorderStyle = FormBorderStyle.None;
            Region = System.Drawing.Region.FromHrgn(CreateRoundRectRgn(0, 0, Width, Height, 20, 20));
        }
        private void btn_show_pass_Click(object sender, EventArgs e)
        {
            if (txt_password.PasswordChar == false)
            {
                btn_show_pass.Image = Properties.Resources.close_eye;
                txt_password.PasswordChar = true;
            }
            else
            {
                btn_show_pass.Image = Properties.Resources.eye;
                txt_password.PasswordChar = false;
            }
        }
        private void txtUser_TextChanged(object sender, EventArgs e)
        {
            TextBox textBox = sender as TextBox;
            if (textBox != null)
            {
                int selectionStart = textBox.SelectionStart;
                textBox.Text = textBox.Text.ToUpper();
                textBox.SelectionStart = selectionStart;
            }
        }
        private void btn_login_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txt_user.Texts))
            {
                RJMessageBox.Show("Tên đăng nhập không được để trống", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            if (string.IsNullOrEmpty(txt_password.Texts))
            {
                RJMessageBox.Show("Mật khẩu không được để trống", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (provider.check_login(txt_user.Texts.Trim().ToUpper(), txt_password.Texts))
            {
                save_data();
                frm_home frm = new frm_home();
                this.Hide();
                frm.Show(); 
                frm.FormClosed += (s, args) => this.Close(); 
            }
            else
            {
                lb_error.Visible = true;
            }
        }

        private void init_data()
        {
            if (Properties.Settings.Default.UserName != string.Empty)
            {
                if (Properties.Settings.Default.Reme == "yes")
                {
                    string pass = Properties.Settings.Default.PassWord;
                    txt_user.Texts = Properties.Settings.Default.UserName;
                    txt_password.Texts = pass;
                    chk_remember_me.Checked = true;
                }
                else
                {
                    txt_user.Texts = Properties.Settings.Default.UserName;
                }
            }
        }

        private void save_data()
        {
            string sql = "";
            if (txt_user.Texts.ToUpper() != "ADMIN" && txt_user.Texts != "HR")
            {
                sql = $"select * from MITACOSQL.dbo.NhanVien where MaChamCong = '{int.Parse(txt_user.Texts.Remove(0, 2))}'";
                DataTable dt = new DataTable();
                dt = SQLHelper.ExecuteDt(sql);

                LoginInfo.UserCd = txt_user.Texts;
                LoginInfo.ChucVu = dt != null || dt.Rows.Count > 0 ? dt.Rows[0]["MaChucVu"].ToString(): "";
                LoginInfo.LoaiUser = "NhanVien";
                LoginInfo.MaPhongBan = dt.Rows[0]["MaPhongBan"].ToString();
                LoginInfo.MaChamCong = dt != null || dt.Rows.Count > 0 ? dt.Rows[0]["MaChamCong"].ToString() : "";
            }
            else
            {
                LoginInfo.UserCd = txt_user.Texts;
                LoginInfo.ChucVu = "";
                LoginInfo.LoaiUser = "NhanVien";
            }


            if (chk_remember_me.Checked)
            {
                Properties.Settings.Default.UserName = txt_user.Texts;
                Properties.Settings.Default.PassWord = txt_password.Texts;
                Properties.Settings.Default.Reme = "yes";
                Properties.Settings.Default.Save();
            }
            else
            {
                Properties.Settings.Default.UserName = txt_user.Texts;
                Properties.Settings.Default.PassWord = "";
                Properties.Settings.Default.Reme = "no";
                Properties.Settings.Default.Save();
            }
        }

        private void btn_close_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void txt_user_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13)
            {
                txt_password.Focus();
            }
        }

        private void txt_password_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13)
            {
                btn_login.PerformClick();
            }
        }

        private void btn_exit_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}