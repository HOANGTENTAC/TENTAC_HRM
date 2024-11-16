using System;
using System.Collections.Generic;
using System.Data;
using System.Windows.Forms;
using TENTAC_HRM.Common;
using TENTAC_HRM.Custom;
using TENTAC_HRM.Forms.Mst_Add_Data;

namespace TENTAC_HRM.Forms.User_control
{
    public partial class uc_minimum_salary : UserControl
    {
        public static uc_minimum_salary _instance;

        private static MstMaTuDong autoCodeGenerator = new MstMaTuDong();
        public static uc_minimum_salary Instance
        {
            get
            {
                if (_instance == null)
                    _instance = new uc_minimum_salary();
                return _instance;
            }
        }
        public uc_minimum_salary()
        {
            InitializeComponent();
            load_data();
        }
        public void load_data()
        {
            string sql = "select Id, Vung, LuongToiThieuTheoThang, LuongToiThieuTheoGio, NgayTao, NguoiTao, NgayCapNhat, NguoiCapNhat from tbl_MucLuongToiThieu where DelFlg = 0 order by Vung";
            DataTable dt = new DataTable();
            dt = SQLHelper.ExecuteDt(sql);
            dgv_minium_salary.DataSource = dt;
        }
        private void btn_delete_Click(object sender, EventArgs e)
        {
            try
            {
                dgv_minium_salary.EndEdit();
                List<string> updateQueries = new List<string>();

                for (int i = 0; i < dgv_minium_salary.Rows.Count; i++)
                {
                    DataGridViewRow row = dgv_minium_salary.Rows[i];

                    bool isChecked = row.Cells["check"].Value != DBNull.Value && row.Cells["check"].Value != null && Convert.ToBoolean(row.Cells["check"].Value);

                    if (isChecked)
                    {
                        string Vung = row.Cells["Vung"].Value?.ToString();
                        if (!string.IsNullOrEmpty(Vung))
                        {
                            updateQueries.Add($@"UPDATE tbl_MucLuongToiThieu SET DelFlg = 1 WHERE Vung = N'{Vung}'");
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
        private void btn_add_Click(object sender, EventArgs e)
        {
            frmLuongToiThieu frmLuongToiThieu = new frmLuongToiThieu(null, null, null, true, this);
            frmLuongToiThieu.ShowDialog();
        }
        private void dgv_minium_salary_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0 && e.ColumnIndex == dgv_minium_salary.Columns["edit_column"].Index)
            {
                string Vung = dgv_minium_salary.CurrentRow.Cells["Vung"].Value.ToString();
                double? LuongToiThieuTheoThang = dgv_minium_salary.CurrentRow.Cells["LuongToiThieuTheoThang"].Value != null
                     ? Convert.ToDouble(dgv_minium_salary.CurrentRow.Cells["LuongToiThieuTheoThang"].Value)
                     : (double?)null;

                double? LuongToiThieuTheoGio = dgv_minium_salary.CurrentRow.Cells["LuongToiThieuTheoGio"].Value != null
                    ? Convert.ToDouble(dgv_minium_salary.CurrentRow.Cells["LuongToiThieuTheoGio"].Value)
                    : (double?)null;
                frmLuongToiThieu frmLuongToiThieu = new frmLuongToiThieu(Vung, LuongToiThieuTheoThang, LuongToiThieuTheoGio, false, this);
                frmLuongToiThieu.ShowDialog();
            }
        }
    }
}