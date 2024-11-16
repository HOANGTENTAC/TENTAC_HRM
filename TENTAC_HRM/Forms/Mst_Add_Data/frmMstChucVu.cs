using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Windows.Forms;
using TENTAC_HRM.Common;
using TENTAC_HRM.Custom;
using TENTAC_HRM.Forms.User_control;

namespace TENTAC_HRM.Forms.Mst_Add_Data
{
    public partial class frmMstChucVu : Form
    {
        private uc_position uc_position;
        private MstMaTuDong autoCodeGenerator;
        public frmMstChucVu(string maChucVu, string tenChucVu, string moTa, bool addNew, uc_position _uc_position)
        {
            InitializeComponent();
            autoCodeGenerator = new MstMaTuDong();
            if (addNew == false)
            {
                labelX1.Text = "Cập Nhật Thông Tin Chức Vụ";
                txtMaChucVu.Text = maChucVu;
                txtTenChucVu.Text = tenChucVu;
                txtMota.Text = moTa;
            }
            else
            {
                LoadNull();
            }
            uc_position = _uc_position;
        }
        private void btn_save_Click(object sender, EventArgs e)
        {
            try
            {
                string MaChucVu = txtMaChucVu.Text.Trim().ToUpper().ToString();
                string TenChucVu = txtTenChucVu.Text.Trim().ToString();
                string Mota = txtMota.Text.Trim().ToString();
                string sql = string.Empty;
                if (string.IsNullOrEmpty(TenChucVu))
                {
                    RJMessageBox.Show("Bạn chưa nhập tên chức vụ.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                sql = @"IF EXISTS (SELECT 1 FROM mst_ChucVu WHERE MaChucVu = @MaChucVu AND del_flg = 0)
                        BEGIN
                            UPDATE mst_ChucVu
                            SET 
                                TenChucVu = @TenChucVu,
                                MoTa = @MoTa,
                                NgayCapNhat = @NgayCapNhat,
                                NguoiCapNhat = @NguoiCapNhat
                            WHERE 
                                MaChucVu = @MaChucVu AND del_flg = 0;
                        END
                        ELSE
                        BEGIN
                            INSERT INTO mst_ChucVu(MaChucVu, TenChucVu, MoTa, NgayTao, NguoiTao, NgayCapNhat, NguoiCapNhat, del_flg)
                            VALUES(@MaChucVu, @TenChucVu, @MoTa, @NgayTao, @NguoiTao, @NgayCapNhat, @NguoiCapNhat, 0);
                        END";

                var parameters = new List<SqlParameter>
                {
                    new SqlParameter("@MaChucVu", MaChucVu),
                    new SqlParameter("@TenChucVu", TenChucVu),
                    new SqlParameter("@MoTa", Mota),
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
                uc_position.LoadData();
                LoadNull();
            }
            catch (Exception ex)
            {
                RJMessageBox.Show(ex.Message, "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void LoadNull()
        {
            txtMaChucVu.Text = autoCodeGenerator.GenerateNextMaChucVu();
            txtTenChucVu.Text = string.Empty;
            txtMota.Text = string.Empty;
        }
        private void btn_cancel_Click(object sender, EventArgs e)
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
