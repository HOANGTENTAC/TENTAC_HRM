using System;
using System.Collections.Generic;
using System.Data;
using System.Windows.Forms;
using TENTAC_HRM.Common;
using TENTAC_HRM.Custom;
using TENTAC_HRM.Forms.Mst_Add_Data;

namespace TENTAC_HRM.Forms.User_control
{
    public partial class uc_education_level : UserControl
    {
        public static uc_education_level _instance;

        private static MstMaTuDong autoCodeGenerator = new MstMaTuDong();
        public static uc_education_level Instance
        {
            get
            {
                if (_instance == null)
                    _instance = new uc_education_level();
                return _instance;
            }
        }
        public uc_education_level()
        {
            InitializeComponent();
            load_data();
        }
        public void load_data()
        {
            string sql = "select Id, MaBac, TenBac, MoTa, NgayCapNhat, NguoiCapNhat from mst_BacDaoTao where DelFlg = 0 order by MaBac";
            DataTable dt = new DataTable();
            dt = SQLHelper.ExecuteDt(sql);
            dgv_education_level.DataSource = dt;
        }
        private void btn_delete_Click(object sender, EventArgs e)
        {
            try
            {
                dgv_education_level.EndEdit();
                List<string> updateQueries = new List<string>();

                for (int i = 0; i < dgv_education_level.Rows.Count; i++)
                {
                    DataGridViewRow row = dgv_education_level.Rows[i];

                    bool isChecked = row.Cells["check"].Value != DBNull.Value && row.Cells["check"].Value != null && Convert.ToBoolean(row.Cells["check"].Value);

                    if (isChecked)
                    {
                        string MaBac = row.Cells["MaBac"].Value?.ToString();
                        if (!string.IsNullOrEmpty(MaBac))
                        {
                            updateQueries.Add($@"UPDATE mst_BacDaoTao SET DelFlg = 1 WHERE MaBac = N'{MaBac}'");
                        }
                    }
                }

                if (updateQueries.Count > 0)
                {
                    foreach (string sql in updateQueries)
                    {
                        SQLHelper.ExecuteSql(sql);
                    }

                    RJMessageBox.Show("Cập nhật thành công.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    RJMessageBox.Show("Cập nhật thất bại.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                load_data();
            }
            catch (Exception ex)
            {
                RJMessageBox.Show(ex.Message, "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void btn_close_Click(object sender, EventArgs e)
        {
            Control x = this.Parent;
            x.Controls.Remove(this);
        }
        private void btn_add_Click(object sender, EventArgs e)
        {
            frmMstBacDaoTao frmMstBacDaoTao = new frmMstBacDaoTao(null, null, null, true, this);
            frmMstBacDaoTao.ShowDialog();
        }
        private void dgv_education_level_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0 && e.ColumnIndex == dgv_education_level.Columns["edit_column"].Index)
            {
                string MaBac = dgv_education_level.CurrentRow.Cells["MaBac"].Value.ToString();
                string TenBac = dgv_education_level.CurrentRow.Cells["TenBac"].Value.ToString();
                string MoTa = dgv_education_level.CurrentRow.Cells["MoTa"].Value.ToString();
                frmMstBacDaoTao frmMstBacDaoTao = new frmMstBacDaoTao(MaBac, TenBac, MoTa, false, this);
                frmMstBacDaoTao.ShowDialog();
            }
        }
    }
}
