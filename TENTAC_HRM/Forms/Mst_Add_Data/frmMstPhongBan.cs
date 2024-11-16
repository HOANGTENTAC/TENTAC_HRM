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
    public partial class frmMstPhongBan : Form
    {
        private uc_departments uc_departments;
        private MstMaTuDong autoCodeGenerator;
        public frmMstPhongBan(string maPhongBan, string maCongTy, string maKhuVuc, string tenPhongBan, bool addNew, uc_departments _uc_departments)
        {
            InitializeComponent();
            load_cong_ty();
            autoCodeGenerator = new MstMaTuDong();
            if (addNew == false)
            {
                labelX1.Text = "Cập Nhật Thông Tin Phòng Ban";
                txtMaPhongBan.Text = maPhongBan;
                txtTenPhongBan.Text = tenPhongBan;
                cbMaCongTy.SelectedValue = maCongTy;
                cbMaKhuVuc.SelectedValue = maKhuVuc;
            }
            else
            {
                load_null();
            }
            uc_departments = _uc_departments;
          
        }
        private void load_cong_ty()
        {
            string sql = @"select MaCongTy, TenCongTy from MITACOSQL.dbo.CONGTY";
            DataTable DT = SQLHelper.ExecuteDt(sql);

            DataRow row = DT.NewRow();
            row["MaCongTy"] = DBNull.Value;
            row["TenCongTy"] = "---Chọn Công Ty---";
            DT.Rows.InsertAt(row, 0);

            cbMaCongTy.DataSource = DT;
            cbMaCongTy.DisplayMember = "TenCongTy";
            cbMaCongTy.ValueMember = "MaCongTy";
        }
        private void load_khu_vuc(string maCongTy)
        {
            string sql = $@"select MaKhuVuc, TenKhuVuc, MaCongTy from MITACOSQL.dbo.KHUVUC where MaCongTy = '{maCongTy}'";
            DataTable DT = SQLHelper.ExecuteDt(sql);

            DataRow row = DT.NewRow();
            row["MaKhuVuc"] = DBNull.Value;
            row["TenKhuVuc"] = "---Chọn Khu Vực---";
            DT.Rows.InsertAt(row, 0);

            cbMaKhuVuc.DataSource = DT;
            cbMaKhuVuc.DisplayMember = "TenKhuVuc";
            cbMaKhuVuc.ValueMember = "MaKhuVuc";
        }
        private void btn_save_Click(object sender, EventArgs e)
        {
            try
            {
                string MaPhongBan = txtMaPhongBan.Text.Trim().ToUpper().ToString();
                string MaCongTy = cbMaCongTy.SelectedValue.ToString();
                string MaKhuVuc = cbMaKhuVuc.SelectedValue.ToString();
                string TenPhongBan = txtTenPhongBan.Text.Trim().ToUpper().ToString();
                string sql = string.Empty;
                if (string.IsNullOrEmpty(TenPhongBan))
                {
                    RJMessageBox.Show("Bạn chưa nhập tên phòng ban.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                sql = @"IF EXISTS (SELECT 1 FROM MITACOSQL.dbo.PHONGBAN WHERE MaPhongBan = @MaPhongBan)
                        BEGIN
                            UPDATE MITACOSQL.dbo.PHONGBAN
                            SET 
                                MaCongTy = @MaCongTy,
                                MaKhuVuc = @MaKhuVuc,
                                TenPhongBan = @TenPhongBan
                            WHERE 
                                MaPhongBan = @MaPhongBan;
                        END
                        ELSE
                        BEGIN
                            INSERT INTO MITACOSQL.dbo.PHONGBAN(MaPhongBan, MaCongTy, MaKhuVuc, TenPhongBan)
                            VALUES(@MaPhongBan, @MaCongTy, @MaKhuVuc, @TenPhongBan);
                        END";

                var parameters = new List<SqlParameter>
                {
                    new SqlParameter("@MaPhongBan", MaPhongBan),
                    new SqlParameter("@MaCongTy", MaCongTy),
                    new SqlParameter("@MaKhuVuc", MaKhuVuc),
                    new SqlParameter("@TenPhongBan", TenPhongBan)
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
                uc_departments.load_data();
                load_null();
            }
            catch (Exception ex)
            {
                RJMessageBox.Show(ex.Message, "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void load_null()
        {
            txtMaPhongBan.Text = autoCodeGenerator.GenerateNextMaPhongBan();
            cbMaCongTy.SelectedIndex = 0;
            cbMaKhuVuc.SelectedIndex = 0;
            txtTenPhongBan.Text = string.Empty;
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

        private void cbMaCongTy_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cbMaCongTy.SelectedIndex != 0)
            {
                cbMaKhuVuc.Enabled = true;
                string MaCongTy = cbMaCongTy.SelectedValue.ToString();
                load_khu_vuc(MaCongTy);
            }
            else 
            {
                cbMaKhuVuc.Enabled = false;
            }
        }
    }
}
