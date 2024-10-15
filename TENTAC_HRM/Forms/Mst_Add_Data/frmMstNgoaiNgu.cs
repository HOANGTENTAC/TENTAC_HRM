using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Windows.Forms;
using TENTAC_HRM.Common;
using TENTAC_HRM.Custom;
using TENTAC_HRM.Forms.User_control;

namespace TENTAC_HRM.Forms.Mst_Add_Data
{
    public partial class frmMstNgoaiNgu : Form
    {
        private MstMaTuDong autoCodeGenerator;
        private uc_foreign_languages uc_foreign_languages;
        public frmMstNgoaiNgu(string maNgoaiNgu, string tenNgoaiNgu, string moTa, bool addNew, uc_foreign_languages _uc_foreign_languages)
        {
            InitializeComponent();
            autoCodeGenerator = new MstMaTuDong();
            if (addNew == false)
            {
                txtMaNgoaiNgu.Text = maNgoaiNgu;
                txtTenNgoaiNgu.Text = tenNgoaiNgu;
                txtMota.Text = moTa;
            }
            else
            {
                txtMaNgoaiNgu.Text = autoCodeGenerator.GenerateNextCode("mst_NgoaiNgu", "NN", "MaNgoaiNgu");
            }
            uc_foreign_languages = _uc_foreign_languages;
        }
        private void btn_save_Click(object sender, EventArgs e)
        {
            try
            {
                string MaNgoaiNgu = txtMaNgoaiNgu.Text.Trim().ToUpper().ToString();
                string TenNgoaiNgu = txtTenNgoaiNgu.Text.Trim().ToString();
                string Mota = txtMota.Text.Trim().ToString();
                string sql = string.Empty;
                if (string.IsNullOrEmpty(TenNgoaiNgu))
                {
                    RJMessageBox.Show("Bạn chưa nhập tên ngoại ngữ.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                sql = @"IF EXISTS (SELECT 1 FROM mst_NgoaiNgu WHERE MaNgoaiNgu = @MaNgoaiNgu AND DelFlg = 0)
                        BEGIN
                            UPDATE mst_NgoaiNgu
                            SET 
                                TenNgoaiNgu = @TenNgoaiNgu,
                                MoTa = @MoTa,
                                NgayCapNhat = @NgayCapNhat,
                                NguoiCapNhat = @NguoiCapNhat
                            WHERE 
                                MaNgoaiNgu = @MaNgoaiNgu AND DelFlg = 0;
                        END
                        ELSE
                        BEGIN
                            INSERT INTO mst_NgoaiNgu(MaNgoaiNgu, TenNgoaiNgu, MoTa, NgayTao, NguoiTao, NgayCapNhat, NguoiCapNhat, DelFlg)
                            VALUES(@MaNgoaiNgu, @TenNgoaiNgu, @MoTa, @NgayTao, @NguoiTao, @NgayCapNhat, @NguoiCapNhat, 0);
                        END";

                var parameters = new List<SqlParameter>
                {
                    new SqlParameter("@MaNgoaiNgu", MaNgoaiNgu),
                    new SqlParameter("@TenNgoaiNgu", TenNgoaiNgu),
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
                uc_foreign_languages.load_dataNgoaiNgu();
                load_null();
            }
            catch (Exception ex)
            {
                RJMessageBox.Show(ex.Message, "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void load_null()
        {
            txtMaNgoaiNgu.Text = autoCodeGenerator.GenerateNextCode("mst_NgoaiNgu", "NN", "MaNgoaiNgu");
            txtTenNgoaiNgu.Text = string.Empty;
            txtMota.Text = string.Empty;
        }
        private void btn_cancel_Click(object sender, EventArgs e)
        {
            load_null();
        }
    }
}
