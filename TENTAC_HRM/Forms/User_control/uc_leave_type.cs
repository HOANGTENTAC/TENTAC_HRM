using System;
using System.Collections.Generic;
using System.Data;
using System.Windows.Forms;
using TENTAC_HRM.Common;
using TENTAC_HRM.Custom;
using TENTAC_HRM.Forms.Mst_Add_Data;

namespace TENTAC_HRM.Forms.User_control
{
    public partial class uc_leave_type : UserControl
    {
        public static uc_leave_type _instance;
        private static MstMaTuDong autoCodeGenerator = new MstMaTuDong();
        public static uc_leave_type Instance
        {
            get
            {
                if (_instance == null)
                    _instance = new uc_leave_type();
                return _instance;
            }
        }
        public uc_leave_type()
        {
            InitializeComponent();
            LoadData();
        }
        public void LoadData()
        {
            string sql = "select Id, MaLoaiPhep, TenLoaiPhep, KyHieu, SoCong, MoTa, NgayCapNhat, NguoiCapNhat from mst_LoaiPhep where del_flg = 0 order by MaLoaiPhep";
            DataTable dt = new DataTable();
            dt = SQLHelper.ExecuteDt(sql);
            dgv_leave_type.DataSource = dt;
        }
        private void uc_leave_type_Load(object sender, EventArgs e)
        {
            //pl_nation.Width = 0;
            LoadData();
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
                dgv_leave_type.EndEdit();
                List<string> updateQueries = new List<string>();

                for (int i = 0; i < dgv_leave_type.Rows.Count; i++)
                {
                    DataGridViewRow row = dgv_leave_type.Rows[i];

                    bool isChecked = row.Cells["check"].Value != DBNull.Value && row.Cells["check"].Value != null && Convert.ToBoolean(row.Cells["check"].Value);

                    if (isChecked)
                    {
                        string MaLoaiPhep = row.Cells["MaLoaiPhep"].Value?.ToString();
                        if (!string.IsNullOrEmpty(MaLoaiPhep))
                        {
                            updateQueries.Add($@"UPDATE mst_LoaiPhep SET del_flg = 1 WHERE MaLoaiPhep = N'{MaLoaiPhep}'");
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
                LoadData();
            }
            catch (Exception ex)
            {
                RJMessageBox.Show(ex.Message, "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void dgv_leave_type_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0 && e.ColumnIndex == dgv_leave_type.Columns["edit_column"].Index)
            {
                string MaLoaiPhep = dgv_leave_type.CurrentRow.Cells["MaLoaiPhep"].Value.ToString();
                frmMstLoaiPhep frmMstLoaiPhep = new frmMstLoaiPhep(this);
                frmMstLoaiPhep._Edit = true;
                frmMstLoaiPhep._MaLoaiPhep = MaLoaiPhep;
                frmMstLoaiPhep.ShowDialog();
            }
        }
        private void btn_close_Click(object sender, EventArgs e)
        {
            Control x = this.Parent;
            x.Controls.Remove(this);
        }
        private void btn_add_Click(object sender, EventArgs e)
        {
            frmMstLoaiPhep frmMstLoaiPhep = new frmMstLoaiPhep(this);
            frmMstLoaiPhep._Edit = false;
            frmMstLoaiPhep.ShowDialog();
        }
    }
}
