using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using TENTAC_HRM.Common;
using TENTAC_HRM.Custom;
using TENTAC_HRM.Forms.User_control;

namespace TENTAC_HRM.Forms.Mst_Add_Data
{
    public partial class frmMstLoaiPhep : Form
    {
        private uc_leave_type uc_leave_type;
        private MstMaTuDong autoCodeGenerator;
        public frmMstLoaiPhep(string maLoaiPhep, string tenLoaiPhep, string kyHieu, bool tinhCong, double? soCong, bool addNew, uc_leave_type _uc_leave_type)
        {
            InitializeComponent();
            autoCodeGenerator = new MstMaTuDong();
            if (addNew == false)
            {
                txtMaLoaiPhep.Text = maLoaiPhep;
                txtTenLoaiPhep.Text = tenLoaiPhep;
                txtKyHieu.Text = kyHieu;
                txtSoCong.Text = soCong.ToString();
                chkTinhCong.Checked = tinhCong;
            }
            else
            {
                txtMaLoaiPhep.Text = autoCodeGenerator.GenerateNextCode("mst_LoaiPhep", "LP", "MaLoaiPhep");
            }
         
            uc_leave_type = _uc_leave_type;

            if (chkTinhCong.Checked == true)
            {
                txtSoCong.Enabled = true;
            }
            else
            {
                txtSoCong.Enabled = false;
            }
        }
        private void btn_save_Click(object sender, EventArgs e)
        {
            try
            {
                string MaLoaiPhep = txtMaLoaiPhep.Text.Trim().ToUpper().ToString();
                string TenLoaiPhep = txtTenLoaiPhep.Text.Trim().ToString();
                string KyHieu = txtKyHieu.Text.Trim().ToString();
                bool TinhCong = chkTinhCong.Checked;
                double SoCong = Convert.ToDouble(txtSoCong.Text.Trim().ToString());
                string sql = string.Empty;
                if (string.IsNullOrEmpty(TenLoaiPhep))
                {
                    RJMessageBox.Show("Bạn chưa nhập tên loại phép.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                sql = @"IF EXISTS (SELECT 1 FROM mst_LoaiPhep WHERE MaLoaiPhep = @MaLoaiPhep AND DelFlg = 0)
                        BEGIN
                            UPDATE mst_LoaiPhep
                            SET 
                                TenLoaiPhep = @TenLoaiPhep,
                                KyHieu = @KyHieu,
                                TinhCong = @TinhCong,
                                SoCong = @SoCong,
                                NgayCapNhat = @NgayCapNhat,
                                NguoiCapNhat = @NguoiCapNhat
                            WHERE 
                                MaLoaiPhep = @MaLoaiPhep AND DelFlg = 0;
                        END
                        ELSE
                        BEGIN
                            INSERT INTO mst_LoaiPhep(MaLoaiPhep, TenLoaiPhep, KyHieu, TinhCong, SoCong, NgayTao, NguoiTao, NgayCapNhat, NguoiCapNhat, DelFlg)
                            VALUES(@MaLoaiPhep, @TenLoaiPhep, @KyHieu, @TinhCong, @SoCong, @NgayTao ,@NguoiTao, @NgayCapNhat, @NguoiCapNhat, 0);
                        END";

                var parameters = new List<SqlParameter>
                {
                    new SqlParameter("@MaLoaiPhep", MaLoaiPhep),
                    new SqlParameter("@TenLoaiPhep", TenLoaiPhep),
                    new SqlParameter("@KyHieu", KyHieu),
                    new SqlParameter("@TinhCong", TinhCong),
                    new SqlParameter("@SoCong", SoCong),
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
                uc_leave_type.load_LoaiPhep();
                load_null();
            }
            catch (Exception ex)
            {
                RJMessageBox.Show(ex.Message, "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void load_null()
        {
            txtMaLoaiPhep.Text = autoCodeGenerator.GenerateNextCode("mst_LoaiPhep", "LP", "MaLoaiPhep");
            txtTenLoaiPhep.Text = string.Empty;
            txtKyHieu.Text = string.Empty;
            txtSoCong.Text = string.Empty;
            chkTinhCong.Checked = false;
        }
        private void btn_cancel_Click(object sender, EventArgs e)
        {
            load_null();
        }

        private void chkTinhCong_CheckedChanged(object sender, EventArgs e)
        {
            if (chkTinhCong.Checked == true)
            {
                txtSoCong.Enabled = true;
            }
            else
            {
                txtSoCong.Enabled = false;
            }
        }
        private void textBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && e.KeyChar != '.')
            {
                e.Handled = true;
            }
            if (e.KeyChar == '.' && txtSoCong.Text.Contains("."))
            {
                e.Handled = true;
            }
        }
    }
}