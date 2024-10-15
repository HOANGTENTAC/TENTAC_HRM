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
using System.Windows.Media.Animation;
using TENTAC_HRM.Custom;
using TENTAC_HRM.Forms.User_control;
using TENTAC_HRM.Common;

namespace TENTAC_HRM.Forms.Mst_Add_Data
{
    public partial class frmMstDanToc : Form
    {
        private uc_nation uc_nation;
        private MstMaTuDong autoCodeGenerator;
        public frmMstDanToc(string maDanToc, string tenDanToc, string moTa, bool addNew, uc_nation _uc_nation)
        {
            InitializeComponent();
            autoCodeGenerator = new MstMaTuDong();
            if (addNew == false)
            {
                txtMaDanToc.Text = maDanToc;
                txtTenDanToc.Text = tenDanToc;
                txtMota.Text = moTa;
            }
            else
            {
                txtMaDanToc.Text = autoCodeGenerator.GenerateNextCode("mst_DanToc", "DT", "MaDanToc");
            }
            uc_nation = _uc_nation;
        }
        private void btn_save_Click(object sender, EventArgs e)
        {
            try
            {
                string MaDanToc = txtMaDanToc.Text.Trim().ToUpper().ToString();
                string TenDanToc = txtTenDanToc.Text.Trim().ToString();
                string Mota = txtMota.Text.Trim().ToString();
                string sql = string.Empty;
                if (string.IsNullOrEmpty(MaDanToc))
                {
                    RJMessageBox.Show("Bạn chưa nhập mã dân tộc.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                if (string.IsNullOrEmpty(TenDanToc))
                {
                    RJMessageBox.Show("Bạn chưa nhập tên dân tộc.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                sql = @"IF EXISTS (SELECT 1 FROM mst_DanToc WHERE MaDanToc = @MaDanToc AND DelFlg = 0)
                        BEGIN
                            UPDATE mst_DanToc
                            SET 
                                TenDanToc = @TenDanToc,
                                MoTa = @MoTa,
                                NgayCapNhat = @NgayCapNhat,
                                NguoiCapNhat = @NguoiCapNhat
                            WHERE 
                                MaDanToc = @MaDanToc AND DelFlg = 0;
                        END
                        ELSE
                        BEGIN
                            INSERT INTO mst_DanToc(MaDanToc, TenDanToc, MoTa, NgayTao, NguoiTao, NgayCapNhat, NguoiCapNhat, DelFlg)
                            VALUES(@MaDanToc, @TenDanToc, @MoTa, @NgayTao, @NguoiTao, @NgayCapNhat, @NguoiCapNhat, 0);
                        END";

                var parameters = new List<SqlParameter>
                {
                    new SqlParameter("@MaDanToc", MaDanToc),
                    new SqlParameter("@TenDanToc", TenDanToc),
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
                uc_nation.load_dataDanToc();
                load_null();
            }
            catch (Exception ex)
            {
                RJMessageBox.Show(ex.Message, "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void load_null()
        {
            txtMaDanToc.Text = autoCodeGenerator.GenerateNextCode("mst_DanToc", "DT", "MaDanToc");
            txtTenDanToc.Text = string.Empty;
            txtMota.Text = string.Empty;
        }
        private void btn_cancel_Click(object sender, EventArgs e)
        {
            load_null();
        }
    }
}
