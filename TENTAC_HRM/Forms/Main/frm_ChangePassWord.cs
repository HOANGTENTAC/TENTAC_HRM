using ComponentFactory.Krypton.Toolkit;
using System;
using System.Data;
using System.Text.RegularExpressions;
using System.Windows.Forms;
using TENTAC_HRM.Custom;

namespace TENTAC_HRM.Forms.Main
{
    public partial class frm_ChangePassWord : KryptonForm
    {
        DataProvider provider = new DataProvider();
        public string _userName { get; set; }
        public frm_ChangePassWord()
        {
            InitializeComponent();
        }

        private void btn_ShowPass_Click(object sender, EventArgs e)
        {
            if (txt_MatKhauMoi.UseSystemPasswordChar == true)
            {
                btn_ShowPass.Image = Properties.Resources.eye;
                btn_ShowPass1.Image = Properties.Resources.eye;
                txt_MatKhauMoi.UseSystemPasswordChar = false;
                txt_XacNhanMatKhau.UseSystemPasswordChar = false;
            }
            else
            {
                btn_ShowPass.Image = Properties.Resources.close_eye;
                btn_ShowPass1.Image = Properties.Resources.close_eye;
                txt_MatKhauMoi.UseSystemPasswordChar = true;
                txt_XacNhanMatKhau.UseSystemPasswordChar = true;
            }
        }

        private void frm_ChangePassWord_Load(object sender, EventArgs e)
        {
            txt_TenDangNhap.Text = _userName;
            string sql = $@"SELECT a.MaNhanVien,b.TenNhanVien
                            FROM mst_Users a
                            join MITACOSQL.dbo.NHANVIEN b on a.MaNhanVien = b.MaNhanVien
                            where a.MaNhanVien = '{_userName}'";
            DataTable dt = new DataTable();
            dt = SQLHelper.ExecuteDt(sql);
            if (dt.Rows.Count > 0)
            {
                txt_TenNguoiDung.Text = dt.Rows[0]["TenNhanVien"].ToString();
            }
            else
            {
                txt_TenNguoiDung.Text = _userName;
            }
        }

        private void btn_Save_Click(object sender, EventArgs e)
        {
            if(string.IsNullOrEmpty(txt_TenDangNhap.Text))
            {
                lb_Notifi.Visible = true;
                lb_Notifi.Text = "Tên đăng nhập không được để trống";
                return;
            }else if (string.IsNullOrEmpty(txt_MatKhauMoi.Text) || string.IsNullOrEmpty(txt_XacNhanMatKhau.Text))
            {
                lb_Notifi.Visible = true;
                lb_Notifi.Text = "Mật khẩu không được để trống";
                return;
            }
            else if (txt_MatKhauMoi.Text != txt_XacNhanMatKhau.Text)
            {
                lb_Notifi.Visible = true;
                lb_Notifi.Text = "Mật khẩu xác nhận không trùng khớp";
                return;
            }
            else if (CheckPass(txt_MatKhauMoi.Text) == false)
            {
                lb_Notifi.Visible = true;
                lb_Notifi.Text = "Mật khẩu không đủ mạnh";
                return;
            }
            else
            {
                string sql = $@"UPDATE mst_Users SET MatKhau = '{provider.Hash_md5(txt_MatKhauMoi.Text)}' WHERE MaNhanVien = '{txt_TenDangNhap.Text}'";
                SQLHelper.ExecuteSql(sql);
                RJMessageBox.Show("Đổi mật khẩu thành công", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.Close();
            }
        }
        private bool CheckPass(string pass)
        {
            bool result = false;
            if (pass.Length < 8)
            {
                result = false;
            }
            if (Regex.IsMatch(pass, @"[a-z]") &&
               Regex.IsMatch(pass, @"[A-Z]") &&
               Regex.IsMatch(pass, @"[0-9]") &&
               Regex.IsMatch(pass, @"[!@#$%^&*()-+?_~]"))
            {
                result = true;
            }
            return result;
        }
    }
}
