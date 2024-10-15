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
using TENTAC_HRM.User_control;

namespace TENTAC_HRM.Forms.Mst_Add_Data
{
    public partial class frmMstChungChi : Form
    {
        private uc_certificate uc_certificate;
        private MstMaTuDong autoCodeGenerator;
        public frmMstChungChi(string maChungChi, string tenChungChi, string moTa, bool addNew, uc_certificate _uc_certificate)
        {
            InitializeComponent();
            autoCodeGenerator = new MstMaTuDong();
            if (addNew == false)
            {
                txtMaChungChi.Text = maChungChi;
                txtTenChungChi.Text = tenChungChi;
                txtMota.Text = moTa;
            }
            else
            {
                txtMaChungChi.Text = autoCodeGenerator.GenerateNextCode("mst_ChungChi", "CC", "MaChungChi");
            }
            uc_certificate = _uc_certificate;
        }
        private void btn_save_Click(object sender, EventArgs e)
        {
            try
            {
                string MaChungChi = txtMaChungChi.Text.Trim().ToUpper().ToString();
                string TenChungChi = txtTenChungChi.Text.Trim().ToString();
                string Mota = txtMota.Text.Trim().ToString();
                string sql = string.Empty;
                if (string.IsNullOrEmpty(TenChungChi))
                {
                    RJMessageBox.Show("Bạn chưa nhập tên chứng chỉ.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                sql = @"IF EXISTS (SELECT 1 FROM mst_ChungChi WHERE MaChungChi = @MaChungChi AND DelFlg = 0)
                        BEGIN
                            UPDATE mst_ChungChi
                            SET 
                                TenChungChi = @TenChungChi,
                                MoTa = @MoTa,
                                NgayCapNhat = @NgayCapNhat,
                                NguoiCapNhat = @NguoiCapNhat
                            WHERE 
                                MaChungChi = @MaChungChi AND DelFlg = 0;
                        END
                        ELSE
                        BEGIN
                            INSERT INTO mst_ChungChi(MaChungChi, TenChungChi, MoTa, NgayTao, NguoiTao, NgayCapNhat, NguoiCapNhat, DelFlg)
                            VALUES(@MaChungChi, @TenChungChi, @MoTa, @NgayTao, @NguoiTao, @NgayCapNhat, @NguoiCapNhat, 0);
                        END";

                var parameters = new List<SqlParameter>
                {
                    new SqlParameter("@MaChungChi", MaChungChi),
                    new SqlParameter("@TenChungChi", TenChungChi),
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
                uc_certificate.load_dataChungChiNghe();
                load_null();
            }
            catch (Exception ex)
            {
                RJMessageBox.Show(ex.Message, "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void load_null()
        {
            txtMaChungChi.Text = autoCodeGenerator.GenerateNextCode("mst_ChungChi", "CC", "MaChungChi");
            txtTenChungChi.Text = string.Empty;
            txtMota.Text = string.Empty;
        }
        private void btn_cancel_Click(object sender, EventArgs e)
        {
            load_null();
        }
    }
}
