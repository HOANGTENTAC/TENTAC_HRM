using System;
using System.Data;
using System.Windows.Forms;
using TENTAC_HRM.Custom;

namespace TENTAC_HRM.Chart_Management
{
    public partial class uc_phong_ban : UserControl
    {
        public bool edit;
        DataProvider provider = new DataProvider();
        public static uc_phong_ban _instance;
        public static uc_phong_ban Instance
        {
            get
            {
                if (_instance == null)
                    _instance = new uc_phong_ban();
                return _instance;
            }
        }
        public uc_phong_ban()
        {
            InitializeComponent();
        }

        private void uc_phong_ban_Load(object sender, System.EventArgs e)
        {
            load_khuvuc();
            load_data();
        }
        private void load_data()
        {
            string sql = "SELECT ma_phong_ban,ten_phong_ban,ma_phong_ban_root,dien_thoai " +
             "FROM phong_ban where id_loai_phong_ban = 3 and is_hoat_dong = 1 and del_flg = 0";
            DataTable dt = new DataTable();
            dt = SQLHelper.ExecuteDt(sql);
            dgv_phong_ban.DataSource = dt;
        }
        private void load_khuvuc()
        {
            cbo_khu_vuc.DataSource = provider.load_treeview(2);
            cbo_khu_vuc.DisplayMember = "name";
            cbo_khu_vuc.ValueMember = "id";

        }
        private void btn_add_Click(object sender, System.EventArgs e)
        {
            string sql = string.Format("select ma_phong_ban from phong_ban where ma_phong_ban = '{0}'",txt_ma_phong_ban.Text);
            DataTable dt = SQLHelper.ExecuteDt(sql);
            if(dt.Rows.Count > 0)
            {
                RJMessageBox.Show("Mã phòng ban " + dt.Rows[0]["ma_phong_ban"].ToString() + " đã tồn tại","Thông báo",MessageBoxButtons.OK,MessageBoxIcon.Warning);
            }
            else
            {
                insert_data();
                load_data();
            }
        }

        private void insert_data()
        {
            try
            {
                string sql = string.Format("insert phong_ban(ma_phong_ban,ten_phong_ban,id_loai_phong_ban,ma_phong_ban_root,is_hoat_dong,dien_thoai) " +
                    "values('{0}',N'{1}',3,'{2}',1,'{3}')", txt_ma_phong_ban.Text, txt_ten_phong_ban.Text, cbo_khu_vuc.SelectedValue.ToString(), txt_dien_thoai.Text);
                if (SQLHelper.ExecuteSql(sql) == 1)
                {
                    RJMessageBox.Show("Thêm thành công", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch(Exception ex)
            {
                RJMessageBox.Show(ex.Message, "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void update_data()
        {
            try
            {
                string sql = string.Format("update phong_ban set ma_phong_ban='{1}',ten_phong_ban = N'{2}',ma_phong_ban_root='{3}',dien_thoai = '{4}' " +
                    "where ma_phong_ban = '{0}'",txt_ma_phong_ban.Text,
                    txt_ma_phong_ban.Text,txt_ten_phong_ban.Text,cbo_khu_vuc.SelectedValue.ToString(),txt_dien_thoai.Text);
                if (SQLHelper.ExecuteSql(sql) == 1)
                {
                    RJMessageBox.Show("Cập nhật thành công", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch(Exception ex)
            {
                RJMessageBox.Show(ex.Message, "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void btn_update_Click(object sender, System.EventArgs e)
        {
            update_data();
            load_data();
        }

        private void btn_delete_Click(object sender, System.EventArgs e)
        {
            try
            {
                string sql = string.Format("update phong_ban set del_flg = 1 where ma_phong_ban = '{0}'", txt_ma_phong_ban.Text);
                if (SQLHelper.ExecuteSql(sql) == 1)
                {
                    RJMessageBox.Show("Xóa thành công", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    load_data();
                }
            }catch(Exception ex)
            {
                RJMessageBox.Show(ex.Message, "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void dgv_phong_ban_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dgv_phong_ban.CurrentCell.OwningColumn.Name == "edit_column")
            {
                edit = true;
                txt_ma_phong_ban.Text = dgv_phong_ban.CurrentRow.Cells["ma_phong_ban"].Value.ToString();
                txt_ten_phong_ban.Text = dgv_phong_ban.CurrentRow.Cells["ten_phong_ban"].Value.ToString();
                txt_dien_thoai.Text = dgv_phong_ban.CurrentRow.Cells["dien_thoai"].Value.ToString();
                cbo_khu_vuc.SelectedValue = dgv_phong_ban.CurrentRow.Cells["ma_phong_ban_root"].Value.ToString();
            }
        }
    }
}
