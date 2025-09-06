using System;
using System.Data;
using System.Windows.Forms;
using TENTAC_HRM.Custom;

namespace TENTAC_HRM.Forms.Chart_Management
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
            dgv_phong_ban.DataSource = provider.LoadPhongBan();
        }
        private void load_khuvuc()
        {
            cbo_khu_vuc.DataSource = provider.LoadKhuVuc();
            cbo_khu_vuc.DisplayMember = "name";
            cbo_khu_vuc.ValueMember = "id";
        }
        private void btn_add_Click(object sender, System.EventArgs e)
        {
            string sql = string.Format("select MaPhongBan from MITACOSQL.dbo.PHONGBAN where MaPhongBan = '{0}'", txt_ma_phong_ban.Text);
            DataTable dt = SQLHelper.ExecuteDt(sql);
            if(dt.Rows.Count > 0)
            {
                RJMessageBox.Show("Mã phòng ban " + dt.Rows[0]["MaPhongBan"].ToString() + " đã tồn tại","Thông báo",MessageBoxButtons.OK,MessageBoxIcon.Warning);
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
                string sql = string.Format("insert MITACOSQL.dbo.PHONGBAN(MaPhongBan,TenPhongBan) " +
                    "values('{0}',N'{1}',3,'{2}',1,'{3}')", txt_ma_phong_ban.Text, txt_ten_phong_ban.Text, cbo_khu_vuc.SelectedValue.ToString());
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
                string sql = string.Format("update MITACOSQL.dbo.PHONGBAN set MaPhongBan='{1}',TenPhongBan = N'{2}' " +
                    "where ma_phong_ban = '{0}'",txt_ma_phong_ban.Text,
                    txt_ma_phong_ban.Text,txt_ten_phong_ban.Text,cbo_khu_vuc.SelectedValue.ToString());
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
                string sql = string.Format("Delete MITACOSQL.dbo.PHONGBAN where MaPhongBan = '{0}'", txt_ma_phong_ban.Text);
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
                txt_ma_phong_ban.Text = dgv_phong_ban.CurrentRow.Cells["MaPhongBan"].Value.ToString();
                txt_ten_phong_ban.Text = dgv_phong_ban.CurrentRow.Cells["TenPhongBan"].Value.ToString();
            }
        }
    }
}
