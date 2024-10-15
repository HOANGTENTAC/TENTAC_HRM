using System;
using System.Data;
using System.Windows.Forms;
using TENTAC_HRM.Custom;

namespace TENTAC_HRM.Forms.User_control
{
    public partial class uc_nationality : UserControl
    {
        string madiachi_value, tendiachi_value, id_diachi_value;
        public bool edit { get; set; }
        public static uc_nationality _instance;
        public static uc_nationality Instance
        {
            get
            {
                if (_instance == null)
                    _instance = new uc_nationality();
                return _instance;
            }
        }
        public uc_nationality()
        {
            InitializeComponent();
        }

        private void uc_nationality_Load(object sender, EventArgs e)
        {
            load_quoctich();
            load_data();
        }

        private void load_data()
        {
            string sql = "select id_dia_chi,ma_dia_chi,ten_dia_chi from hrm_dia_chi where loai_dia_chi = 20";
            DataTable dt = new DataTable();
            dt = SQLHelper.ExecuteDt(sql);
            if (dt != null)
            {
                dgv_nationality.DataSource = dt;
            }
        }

        private void load_quoctich()
        {
            string sql = "select type_id,type_name from sys_all_type where type_id = 20";
            cbo_loaidichi.DataSource = SQLHelper.ExecuteDt(sql);
            cbo_loaidichi.DisplayMember = "type_name";
            cbo_loaidichi.ValueMember = "type_id";
        }

        private void btn_add_Click(object sender, EventArgs e)
        {
            pl_info.Enabled = true;
            btn_save.Text = "Lưu";
            edit = false;
        }

        private void dgv_nationality_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dgv_nationality.CurrentCell.OwningColumn.Name == "edit_column")
            {
                id_diachi_value = dgv_nationality.CurrentRow.Cells["id_dia_chi"].Value.ToString();
                btn_save.Text = "Cập nhật";
                edit = true;
                pl_info.Enabled = true;
                txt_madiachi.Text = dgv_nationality.CurrentRow.Cells["ma_dia_chi"].Value.ToString();
                txt_tendiachi.Text = dgv_nationality.CurrentRow.Cells["ten_dia_chi"].Value.ToString();
            }
        }

        private void btn_cancel_Click(object sender, EventArgs e)
        {
            pl_info.Enabled = false;
        }

        private void btn_save_Click(object sender, EventArgs e)
        {
            set_value_text();
            if (edit == true)
            {
                update_data();
            }
            else
            {
                save_data();
            }
            load_data();
        }

        private void set_value_text()
        {
            madiachi_value = txt_madiachi.Text;
            tendiachi_value = txt_tendiachi.Text;
        }

        private void update_data()
        {
            try
            {
                string sql = string.Format("update hrm_dia_chi set ma_dia_chi = {1},ten_dia_chi = {2} where id_dia_chi = {0}",
                                madiachi_value, tendiachi_value, id_diachi_value);
                if (SQLHelper.ExecuteSql(sql) == 1)
                {
                    RJMessageBox.Show("cập nhật thành công", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (Exception ex)
            {
                RJMessageBox.Show(ex.Message, "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void save_data()
        {
            try
            {
                string sql = string.Format("insert into hrm_dia_chi(ma_dia_chi,ten_dia_chi,loai_dia_chi) " +
                    "values('{0}',N'{1}',20)", madiachi_value, tendiachi_value);
                if (SQLHelper.ExecuteSql(sql) == 1)
                {
                    RJMessageBox.Show("Thêm thành công", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (Exception ex)
            {
                RJMessageBox.Show(ex.Message, "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
