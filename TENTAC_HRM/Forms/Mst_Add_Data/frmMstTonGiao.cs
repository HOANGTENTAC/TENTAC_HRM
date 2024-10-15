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
    public partial class frmMstTonGiao : Form
    {
        private uc_staff_religion uc_staff_religion;
        private static MstMaTuDong autoCodeGenerator = new MstMaTuDong();
        public frmMstTonGiao(string maTonGiao, string tenTonGiao, string moTa, bool addNew, uc_staff_religion _uc_staff_religion)
        {
            InitializeComponent();

            autoCodeGenerator = new MstMaTuDong();
            if (addNew == false)
            {
                txtMaTonGiao.Text = maTonGiao;
                txtTenTonGiao.Text = tenTonGiao;
                txtMota.Text = moTa;
            }
            else
            {
                txtMaTonGiao.Text = autoCodeGenerator.GenerateNextCode("mst_TonGiao", "TG", "MaTonGiao");
            }
            uc_staff_religion = _uc_staff_religion;
        }
        private void load_null()
        {
            txtMaTonGiao.Text = autoCodeGenerator.GenerateNextCode("mst_TonGiao", "TG", "MaTonGiao");
            txtTenTonGiao.Text = string.Empty;
            txtMota.Text = string.Empty;
        }
        private void btn_save_Click(object sender, EventArgs e)
        {
            try
            {
                string MaTonGiao = txtMaTonGiao.Text.Trim().ToUpper().ToString();
                string TenTonGiao = txtTenTonGiao.Text.Trim().ToString();
                string Mota = txtMota.Text.Trim().ToString();
                string sql = string.Empty;
                if (string.IsNullOrEmpty(MaTonGiao))
                {
                    RJMessageBox.Show("Bạn chưa nhập tên tôn giáo.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                sql = @"IF EXISTS (SELECT 1 FROM mst_TonGiao WHERE MaTonGiao = @MaTonGiao AND DelFlg = 0)
                        BEGIN
                            UPDATE mst_TonGiao
                            SET 
                                TenTonGiao = @TenTonGiao,
                                MoTa = @MoTa,
                                NgayCapNhat = @NgayCapNhat,
                                NguoiCapNhat = @NguoiCapNhat
                            WHERE 
                                MaTonGiao = @MaTonGiao AND DelFlg = 0;
                        END
                        ELSE
                        BEGIN
                            INSERT INTO mst_TonGiao(MaTonGiao, TenTonGiao, MoTa, NgayTao, NguoiTao, NgayCapNhat, NguoiCapNhat, DelFlg)
                            VALUES(@MaTonGiao, @TenTonGiao, @MoTa, @NgayTao, @NguoiTao, @NgayCapNhat, @NguoiCapNhat, 0);
                        END";

                var parameters = new List<SqlParameter>
                {
                    new SqlParameter("@MaTonGiao", MaTonGiao),
                    new SqlParameter("@TenTonGiao", TenTonGiao),
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
                uc_staff_religion.load_dataTonGiao();
                load_null();
            }
            catch (Exception ex)
            {
                RJMessageBox.Show(ex.Message, "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btn_cancel_Click(object sender, EventArgs e)
        {
            load_null();
        }
    }
}
