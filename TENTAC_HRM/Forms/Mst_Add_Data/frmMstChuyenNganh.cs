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
    public partial class frmMstChuyenNganh : Form
    {
        private uc_major uc_major;
        private MstMaTuDong autoCodeGenerator;
        public frmMstChuyenNganh(string maChuyenNganh, string tenChuyenNganh, string moTa, bool addNew, uc_major _uc_major)
        {
            InitializeComponent();
            autoCodeGenerator = new MstMaTuDong();
            if (addNew == false)
            {
                labelX1.Text = "Cập Nhật Thông Tin Chuyên Ngành";
                txtMaChuyenNganh.Text = maChuyenNganh;
                txtTenChuyenNganh.Text = tenChuyenNganh;
                txtMota.Text = moTa;
            }
            else
            {
                load_null();
            }
            uc_major = _uc_major;
        }
        private void btn_save_Click(object sender, EventArgs e)
        {
            try
            {
                string MaChuyenNganh = txtMaChuyenNganh.Text.Trim().ToUpper().ToString();
                string TenChuyenNganh = txtTenChuyenNganh.Text.Trim().ToString();
                string Mota = txtMota.Text.Trim().ToString();
                string sql = string.Empty;
                if (string.IsNullOrEmpty(TenChuyenNganh))
                {
                    RJMessageBox.Show("Bạn chưa nhập tên chứng chỉ.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                sql = @"IF EXISTS (SELECT 1 FROM mst_ChuyenNganh WHERE MaChuyenNganh = @MaChuyenNganh AND DelFlg = 0)
                        BEGIN
                            UPDATE mst_ChuyenNganh
                            SET 
                                TenChuyenNganh = @TenChuyenNganh,
                                MoTa = @MoTa,
                                NgayCapNhat = @NgayCapNhat,
                                NguoiCapNhat = @NguoiCapNhat
                            WHERE 
                                MaChuyenNganh = @MaChuyenNganh AND DelFlg = 0;
                        END
                        ELSE
                        BEGIN
                            INSERT INTO mst_ChuyenNganh(MaChuyenNganh, TenChuyenNganh, MoTa, NgayTao, NguoiTao, NgayCapNhat, NguoiCapNhat, DelFlg)
                            VALUES(@MaChuyenNganh, @TenChuyenNganh, @MoTa, @NgayTao, @NguoiTao, @NgayCapNhat, @NguoiCapNhat, 0);
                        END";

                var parameters = new List<SqlParameter>
                {
                    new SqlParameter("@MaChuyenNganh", MaChuyenNganh),
                    new SqlParameter("@TenChuyenNganh", TenChuyenNganh),
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
                uc_major.load_dataChuyenNganh();
                load_null();
            }
            catch (Exception ex)
            {
                RJMessageBox.Show(ex.Message, "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void load_null()
        {
            txtMaChuyenNganh.Text = autoCodeGenerator.GenerateNextCode("mst_ChuyenNganh", "CN", "MaChuyenNganh");
            txtTenChuyenNganh.Text = string.Empty;
            txtMota.Text = string.Empty;
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
    }
}
