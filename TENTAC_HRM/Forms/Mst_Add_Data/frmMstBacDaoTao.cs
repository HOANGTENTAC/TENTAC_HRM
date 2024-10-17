using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Windows.Forms;
using TENTAC_HRM.Common;
using TENTAC_HRM.Custom;
using TENTAC_HRM.Forms.User_control;

namespace TENTAC_HRM.Forms.Mst_Add_Data
{
    public partial class frmMstBacDaoTao : Form
    {
        private uc_education_level uc_education_level;
        private MstMaTuDong autoCodeGenerator;
        public frmMstBacDaoTao(string maTrinhDo, string tenTrinhDo, string moTa, bool addNew, uc_education_level _uc_education_level)
        {
            InitializeComponent();

            autoCodeGenerator = new MstMaTuDong();
            if (addNew == false)
            {
                txtMaTrinhDo.Text = maTrinhDo;
                txtTenTrinhDo.Text = tenTrinhDo;
                txtMota.Text = moTa;
            }
            else
            {
                txtMaTrinhDo.Text = autoCodeGenerator.GenerateNextCode("mst_BacDaoTao", "TD", "MaBac");
            }
            uc_education_level = _uc_education_level;
        }
        private void btn_save_Click(object sender, EventArgs e)
        {
            try
            {
                string MaBac = txtMaTrinhDo.Text.Trim().ToUpper().ToString();
                string TenBac = txtTenTrinhDo.Text.Trim().ToString();
                string Mota = txtMota.Text.Trim().ToString();
                string sql = string.Empty;
                if (string.IsNullOrEmpty(TenBac))
                {
                    RJMessageBox.Show("Bạn chưa nhập tên trình độ.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                sql = @"IF EXISTS (SELECT 1 FROM mst_BacDaoTao WHERE MaBac = @MaBac AND DelFlg = 0)
                        BEGIN
                            UPDATE mst_BacDaoTao
                            SET 
                                TenBac = @TenBac,
                                MoTa = @MoTa,
                                NgayCapNhat = @NgayCapNhat,
                                NguoiCapNhat = @NguoiCapNhat
                            WHERE 
                                MaBac = @MaBac AND DelFlg = 0;
                        END
                        ELSE
                        BEGIN
                            INSERT INTO mst_BacDaoTao(MaBac, TenBac, MoTa, NgayTao, NguoiTao, NgayCapNhat, NguoiCapNhat, DelFlg)
                            VALUES(@MaBac, @TenBac, @MoTa, @NgayTao, @NguoiTao, @NgayCapNhat, @NguoiCapNhat, 0);
                        END";

                var parameters = new List<SqlParameter>
                {
                    new SqlParameter("@MaBac", MaBac),
                    new SqlParameter("@TenBac", TenBac),
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
                uc_education_level.load_data();
                load_null();
            }
            catch (Exception ex)
            {
                RJMessageBox.Show(ex.Message, "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void load_null()
        {
            txtMaTrinhDo.Text = autoCodeGenerator.GenerateNextCode("mst_BacDaoTao", "TD", "MaBac");
            txtTenTrinhDo.Text = string.Empty;
            txtMota.Text = string.Empty;
        }
        private void btn_cancel_Click(object sender, EventArgs e)
        {
            load_null();
        }
    }
}
