using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Windows.Forms;
using TENTAC_HRM.Common;
using TENTAC_HRM.Custom;
using TENTAC_HRM.Forms.User_control;

namespace TENTAC_HRM.Forms.Mst_Add_Data
{
    public partial class frmLuongToiThieu : Form
    {
        private uc_minimum_salary uc_minimum_salary;
        private MstMaTuDong autoCodeGenerator;
        public frmLuongToiThieu(string vung, double? mucLuongToiThieuTheoThang, double? MucLuongToiThieuTheoGio, bool addNew, uc_minimum_salary _uc_minimum_salary)
        {
            InitializeComponent();
            autoCodeGenerator = new MstMaTuDong();
            if (addNew == false)
            {
                labelX1.Text = "Cập Nhật Thông Tin Vùng";
                txtTenVung.Text = vung;
                txtLuongToiThieuTheoThang.Text = mucLuongToiThieuTheoThang.ToString();
                txtLuongToiThieuTheoGio.Text = MucLuongToiThieuTheoGio.ToString();
            }
            uc_minimum_salary = _uc_minimum_salary;
        }
        private void btn_save_Click(object sender, EventArgs e)
        {
            try
            {
                string Vung = txtTenVung.Text.Trim().ToString();
                double? LuongToiThieuTheoThang = string.IsNullOrWhiteSpace(txtLuongToiThieuTheoThang.Text.Trim()) 
                    ? (double?)null 
                    : Convert.ToDouble(txtLuongToiThieuTheoThang.Text.Trim());

                double? LuongToiThieuTheoGio = string.IsNullOrWhiteSpace(txtLuongToiThieuTheoGio.Text.Trim()) 
                    ? (double?)null 
                    : Convert.ToDouble(txtLuongToiThieuTheoGio.Text.Trim());
                string sql = string.Empty;

                sql = @"IF EXISTS (SELECT 1 FROM tbl_MucLuongToiThieu WHERE Vung = @Vung AND DelFlg = 0)
                        BEGIN
                            UPDATE tbl_MucLuongToiThieu
                            SET 
                                LuongToiThieuTheoThang = @LuongToiThieuTheoThang,
                                LuongToiThieuTheoGio = @LuongToiThieuTheoGio,
                                NgayCapNhat = @NgayCapNhat,
                                NguoiCapNhat = @NguoiCapNhat
                            WHERE 
                                Vung = @Vung AND DelFlg = 0;
                        END
                        ELSE
                        BEGIN
                            INSERT INTO tbl_MucLuongToiThieu(Vung, LuongToiThieuTheoThang, LuongToiThieuTheoGio, NgayTao, NguoiTao, NgayCapNhat, NguoiCapNhat, DelFlg)
                            VALUES(@Vung, @LuongToiThieuTheoThang, @LuongToiThieuTheoGio, @NgayTao, @NguoiTao, @NgayCapNhat, @NguoiCapNhat, 0);
                        END";

                var parameters = new List<SqlParameter>
                {
                    new SqlParameter("@Vung", Vung),
                    new SqlParameter("@LuongToiThieuTheoThang", LuongToiThieuTheoThang),
                    new SqlParameter("@LuongToiThieuTheoGio", LuongToiThieuTheoGio),
                    new SqlParameter("@NgayTao", DateTime.Now),
                    new SqlParameter("@NguoiTao", SQLHelper.sUser),
                    new SqlParameter("@NgayCapNhat", DateTime.Now),
                    new SqlParameter("@NguoiCapNhat", SQLHelper.sUser)
                };

                int res = SQLHelper.ExecuteSql(sql, parameters.ToArray());
                if (res > 0)
                {
                    RJMessageBox.Show("Cập nhật thành công.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    RJMessageBox.Show("Cập nhật thất bại.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                uc_minimum_salary.load_data();
                load_null();
            }
            catch (Exception ex)
            {
                RJMessageBox.Show(ex.Message, "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void load_null()
        {
            txtLuongToiThieuTheoGio.Text =string.Empty;
            txtLuongToiThieuTheoThang.Text = string.Empty;
            txtTenVung.Text = string.Empty;
        }
        private void btn_cancel_Click(object sender, EventArgs e)
        {
            //load_null();
            if (this.Parent != null)
            {
                Control x = this.Parent;
                x.Controls.Remove(this);
            }
            else
            {
                this.Close();
            }
        }
        private void textBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && e.KeyChar != '.')
            {
                e.Handled = true;
            }
            if (e.KeyChar == '.' && (txtLuongToiThieuTheoGio.Text.Contains(".") || txtLuongToiThieuTheoThang.Text.Contains(".")))
            {
                e.Handled = true;
            }
        }
        private void btn_close_Click(object sender, EventArgs e)
        {
            if (this.Parent != null) 
            {
                Control x = this.Parent;
                x.Controls.Remove(this); 
            }
            else
            {
                this.Close();
            }
        }
    }
}