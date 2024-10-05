using System;
using System.Data;
using System.Windows.Forms;
using TENTAC_HRM.Custom;

namespace TENTAC_HRM.Chart_Management
{
    public partial class uc_chuc_vu : UserControl
    {
        DataProvider provider = new DataProvider();
        public static uc_chuc_vu _instance;
        public static uc_chuc_vu Instance
        {
            get
            {
                if (_instance == null)
                    _instance = new uc_chuc_vu();
                return _instance;
            }
        }
        public uc_chuc_vu()
        {
            InitializeComponent();
        }

        private void uc_chuc_vu_Load(object sender, System.EventArgs e)
        {
            load_khuvuc();
        }
        private void load_data()
        {
            string sql = string.Format("select b.ma_phong_ban,b.ten_phong_ban,a.ma_phong_ban as phong_ban,c.ma_phong_ban as khu_vuc " +
                         "from phong_ban a " +
                         "join phong_ban b on b.ma_phong_ban_root = a.ma_phong_ban " +
                         "join phong_ban c on c.ma_phong_ban = a.ma_phong_ban_root " +
                         "where a.ma_phong_ban = '{0}'", cbo_phong_ban.SelectedValue.ToString());
            DataTable dt = SQLHelper.ExecuteDt(sql);
            dgv_chucvu.DataSource = dt;
        }
        private void load_khuvuc()
        {
            cbo_khu_vuc.DataSource = provider.load_treeview(2);
            cbo_khu_vuc.DisplayMember = "name";
            cbo_khu_vuc.ValueMember = "id";
        }
        private void btn_add_Click(object sender, System.EventArgs e)
        {
            string sql = string.Format("select ma_phong_ban from phong_ban where ma_phong_ban = '{0}'", txt_ma_chuc_vu.Text);
            DataTable dt = SQLHelper.ExecuteDt(sql);
            if (dt.Rows.Count > 0)
            {
                RJMessageBox.Show("Mã phòng ban " + dt.Rows[0]["ma_phong_ban"].ToString() + " đã tồn tại", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else
            {
                insert_data();
                load_data();
            }
        }

        private void btn_update_Click(object sender, System.EventArgs e)
        {
            update_data();
            load_data();
        }
        private void insert_data()
        {
            try
            {
                string sql = string.Format("insert phong_ban(ma_phong_ban,ten_phong_ban,id_loai_phong_ban,ma_phong_ban_root,is_hoat_dong) " +
                    "values('{0}',N'{1}',4,'{2}',1)", txt_ma_chuc_vu.Text, txt_ten_chuc_vu.Text, cbo_phong_ban.SelectedValue.ToString());
                if (SQLHelper.ExecuteSql(sql) == 1)
                {
                    RJMessageBox.Show("Thêm thành công", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (Exception ex)
            {
                RJMessageBox.Show(ex.Message, "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void update_data()
        {
            try
            {
                string sql = string.Format("update phong_ban set ma_phong_ban='{1}',ten_phong_ban = N'{2}',ma_phong_ban_root='{3}' " +
                    "where ma_phong_ban = '{0}'", txt_ma_chuc_vu.Text,
                    txt_ma_chuc_vu.Text, txt_ten_chuc_vu.Text, cbo_phong_ban.SelectedValue.ToString());
                if (SQLHelper.ExecuteSql(sql) == 1)
                {
                    RJMessageBox.Show("Cập nhật thành công", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (Exception ex)
            {
                RJMessageBox.Show(ex.Message, "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }
        private void btn_delete_Click(object sender, System.EventArgs e)
        {
            try
            {
                string sql = string.Format("update phong_ban set del_flg = 1 where ma_phong_ban = '{0}'", txt_ma_chuc_vu.Text);
                if (SQLHelper.ExecuteSql(sql) == 1)
                {
                    RJMessageBox.Show("Xóa thành công", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    load_data();
                }
            }
            catch (Exception ex)
            {
                RJMessageBox.Show(ex.Message, "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void dgv_chucvu_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dgv_chucvu.CurrentCell.OwningColumn.Name == "edit_column")
            {
                txt_ma_chuc_vu.Text = dgv_chucvu.CurrentRow.Cells["ma_phong_ban"].Value.ToString();
                txt_ten_chuc_vu.Text = dgv_chucvu.CurrentRow.Cells["ten_phong_ban"].Value.ToString();
                cbo_khu_vuc.SelectedValue = dgv_chucvu.CurrentRow.Cells["khu_vuc"].Value.ToString();
                cbo_phong_ban.SelectedValue = dgv_chucvu.CurrentRow.Cells["phong_ban"].Value.ToString();
            }
        }

        private void cbo_khu_vuc_SelectedValueChanged(object sender, EventArgs e)
        {
            DataRowView vrow = (DataRowView)cbo_khu_vuc.SelectedItem;
            string row = vrow.Row.ItemArray[0].ToString();
            if (row != "")
            {
                string sql = string.Format("select ma_phong_ban as id,ten_phong_ban as name from phong_ban where ma_phong_ban_root = '{0}'", row);
                DataTable dt = new DataTable();
                dt = SQLHelper.ExecuteDt(sql);
                cbo_phong_ban.DataSource = dt;
                cbo_phong_ban.DisplayMember = "name";
                cbo_phong_ban.ValueMember = "id";
            }
        }

        private void cbo_phong_ban_SelectedValueChanged(object sender, EventArgs e)
        {
            DataRowView vrow = (DataRowView)cbo_phong_ban.SelectedItem;
            string row = vrow.Row.ItemArray[0].ToString();
            if (row != "")
            {
                string sql = string.Format("select b.ma_phong_ban,b.ten_phong_ban,a.ma_phong_ban as phong_ban,c.ma_phong_ban as khu_vuc " +
                             "from phong_ban a " +
                             "join phong_ban b on b.ma_phong_ban_root = a.ma_phong_ban " +
                             "join phong_ban c on c.ma_phong_ban = a.ma_phong_ban_root " +
                             "where a.ma_phong_ban = '{0}'", row);
                DataTable dt = SQLHelper.ExecuteDt(sql);
                dgv_chucvu.DataSource = dt;
            }
        }
    }
}
