using System;
using System.Data;
using System.Windows.Forms;
using TENTAC_HRM.Custom;

namespace TENTAC_HRM.Forms.Chart_Management
{
    public partial class uc_khu_vuc : UserControl
    {
        public static uc_khu_vuc _instance;
        public static uc_khu_vuc Instance
        {
            get
            {
                if (_instance == null)
                    _instance = new uc_khu_vuc();
                return _instance;
            }
        }
        public uc_khu_vuc()
        {
            InitializeComponent();
        }

        private void uc_khu_vuc_Load(object sender, System.EventArgs e)
        {
            load_khuvuc();
        }
        private void load_khuvuc()
        {
            string sql = "select ma_phong_ban,ten_phong_ban from phong_ban where id_loai_phong_ban = 2";
            DataTable dt = SQLHelper.ExecuteDt(sql);
            dgv_khu_vuc.DataSource = dt;
        }

        private void dgv_khu_vuc_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dgv_khu_vuc.CurrentCell.OwningColumn.Name == "edit_column")
            {
                txt_ma_khu_vuc.Text = dgv_khu_vuc.CurrentRow.Cells["ma_phong_ban"].Value.ToString();
                txt_ten_khu_vuc.Text = dgv_khu_vuc.CurrentRow.Cells["ten_phong_ban"].Value.ToString();
            }
        }

        private void btn_add_Click(object sender, System.EventArgs e)
        {
            insert_data();
            load_khuvuc();
        }

        private void btn_update_Click(object sender, System.EventArgs e)
        {
            update_data();
            load_khuvuc();
        }

        private void btn_delete_Click(object sender, System.EventArgs e)
        {
            try
            {
                string sql = string.Format("update phong_ban set del_flg = 1 where ma_phong_ban = '{0}'", txt_ma_khu_vuc.Text);
                if (SQLHelper.ExecuteSql(sql) == 1)
                {
                    RJMessageBox.Show("Xóa thành công", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    load_khuvuc();
                }
            }
            catch (Exception ex)
            {
                RJMessageBox.Show(ex.Message, "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void insert_data()
        {
            try
            {
                string sql = string.Format("insert phong_ban(ma_phong_ban,ten_phong_ban,id_loai_phong_ban,ma_phong_ban_root,is_hoat_dong) " +
                    "values('{0}',N'{1}',2,000,1)", txt_ma_khu_vuc.Text, txt_ten_khu_vuc.Text);
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
                string sql = string.Format("update phong_ban set ma_phong_ban='{1}',ten_phong_ban = N'{2}' " +
                    "where ma_phong_ban = '{0}'", txt_ma_khu_vuc.Text,
                    txt_ma_khu_vuc.Text, txt_ten_khu_vuc.Text);
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
    }
}
