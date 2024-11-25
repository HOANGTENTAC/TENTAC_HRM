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
            LoadData();
        }
        public void LoadData()
        {
            string sql = "select Id, MaBac, TenBac, MoTa, NgayTao, NguoiTao, NgayCapNhat, NguoiCapNhat from mst_BacDaoTao where del_flg = 0 order by MaBac";
            DataTable dt = new DataTable();
            dt = SQLHelper.ExecuteDt(sql);
            dgv_education_level.DataSource = dt;
        }
        private void btn_delete_Click(object sender, EventArgs e)
        {
            try
            {
                DialogResult result = RJMessageBox.Show("Bạn có chắc chắn muốn xoá các mục đã chọn không?",
                                                "Xác nhận",
                                                MessageBoxButtons.YesNo,
                                                MessageBoxIcon.Question);

                if (result != DialogResult.Yes)
                {
                    return;
                }
                dgv_education_level.EndEdit();
                List<string> updateQueries = new List<string>();

                for (int i = 0; i < dgv_education_level.Rows.Count; i++)
                {
                    DataGridViewRow row = dgv_education_level.Rows[i];

                    bool isChecked = row.Cells["check"].Value != DBNull.Value && row.Cells["check"].Value != null && Convert.ToBoolean(row.Cells["check"].Value);

                    if (isChecked)
                    {
                        int IDMaBac = int.Parse(row.Cells["Id"].Value.ToString());
                        updateQueries.Add($@"UPDATE mst_BacDaoTao SET del_flg = 1 WHERE Id = {SQLHelper.rpI(IDMaBac)}");
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
                LoadData();
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
            frmMstBacDaoTao frmMstBacDaoTao = new frmMstBacDaoTao(this);
            frmMstBacDaoTao._Edit = false;
            frmMstBacDaoTao.ShowDialog();
        }
        private void dgv_education_level_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0 && e.ColumnIndex == dgv_education_level.Columns["edit_column"].Index)
            {
                int IdMaBac = int.Parse(dgv_education_level.CurrentRow.Cells["Id"].Value.ToString());
                frmMstBacDaoTao frmMstBacDaoTao = new frmMstBacDaoTao(this);
                frmMstBacDaoTao._IDTrinhDo = IdMaBac;
                frmMstBacDaoTao._Edit = true;
                frmMstBacDaoTao.ShowDialog();
            }
        }
    }
}
