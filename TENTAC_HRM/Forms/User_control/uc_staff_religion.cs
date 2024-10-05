using System;
using System.ComponentModel;
using System.Data;
using System.Windows.Forms;
using TENTAC_HRM.Custom;

namespace TENTAC_HRM.User_control
{
    public partial class uc_staff_religion : UserControl
    {
        string matongiao_value, tentongiao_value, thutu_value, mota_value, ngaytao_value, nguoitao_value, id_tongiao_value;
        public bool edit { get; set; }
        public static uc_staff_religion _instance;
        public static uc_staff_religion Instance
        {
            get
            {
                if (_instance == null)
                    _instance = new uc_staff_religion();
                return _instance;
            }
        }
        public uc_staff_religion()
        {
            InitializeComponent();
        }

        private void btn_add_Click(object sender, EventArgs e)
        {
            txt_ma.Text = "";
            txt_ten.Text = "";
            txt_thu_tu.Text = "";
            txt_mota.Text = "";
            panel2.Enabled = true;
            btn_save.Text = "Lưu";
            edit = false;
        }

        private void btn_close_Click(object sender, EventArgs e)
        {
            Control x = this.Parent;
            x.Controls.Remove(this);
        }

        private void btn_cancel_Click(object sender, EventArgs e)
        {
            panel2.Enabled = false;
        }

        private void dgv_religion_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dgv_religion.CurrentCell.OwningColumn.Name == "edit_column")
            {
                panel2.Enabled = true;
                btn_save.Text = "Cập nhật";
                edit = true;
                id_tongiao_value = dgv_religion.CurrentRow.Cells["id_ton_giao"].Value.ToString();
                txt_ma.Text = dgv_religion.CurrentRow.Cells["ma_ton_giao"].Value.ToString();
                txt_ten.Text = dgv_religion.CurrentRow.Cells["ten_ton_giao"].Value.ToString();
                txt_thu_tu.Text = dgv_religion.CurrentRow.Cells["thu_tu"].Value.ToString();
                txt_mota.Text = dgv_religion.CurrentRow.Cells["mo_ta"].Value.ToString();
            }
        }

        private void txt_ten_Validating(object sender, CancelEventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txt_ten.Text))
            {
                e.Cancel = true;
                txt_ten.Focus();
                errorProvider1.SetError(txt_ten, "Name should not be left blank!");
            }
            else
            {
                e.Cancel = false;
                errorProvider1.SetError(txt_ten, "");
            }
        }

        private void btn_save_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txt_ten.Text))
            {
                txt_ten.Focus();
                RJMessageBox.Show("Tên tôn giáo không được để trống", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                if (edit == true)
                {
                    update_data();
                }
                else
                {
                    add_data();
                }
                load_data();
            }
        }
        private void update_data()
        {
            try
            {
                set_value_text();
                string sql = string.Format("update hrm_ton_giao set ma_ton_giao = '{1}',ten_ton_giao = N'{2}', thu_tu = '{3}'" +
                    ", mo_ta = N'{4}',ngay_cap_nhat = GETDATE() " +
                    "where id_ton_giao = {0}", id_tongiao_value, matongiao_value, tentongiao_value, thutu_value, mota_value);
                if (SQLHelper.ExecuteSql(sql) == 1)
                {
                    RJMessageBox.Show("Cập nhật thành công", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (Exception ex)
            {
                RJMessageBox.Show(ex.Message, "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void add_data()
        {
            try
            {
                set_value_text();
                string sql = string.Format("insert into hrm_ton_giao(ma_ton_giao,ten_ton_giao,thu_tu,mo_ta,ngay_tao,id_nguoi_tao) " +
                    "values(N'{0}',N'{1}','{2}',N'{3}','{4}',{5})", matongiao_value, tentongiao_value, thutu_value, mota_value, ngaytao_value, nguoitao_value);
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
        private void set_value_text()
        {
            matongiao_value = txt_ma.Text;
            tentongiao_value = txt_ten.Text;
            thutu_value = txt_thu_tu.Text;
            mota_value = txt_mota.Text;
            ngaytao_value = DateTime.Now.ToString("yyyy/MM/dd");
            nguoitao_value = SQLHelper.sIdUser;
        }
        private void load_data()
        {
            string sql = "select id_ton_giao,ma_ton_giao,ten_ton_giao,thu_tu,mo_ta from hrm_ton_giao";
            DataTable dt = new DataTable();
            dt = SQLHelper.ExecuteDt(sql);
            dgv_religion.DataSource = dt;
        }

        private void uc_staff_religion_Load(object sender, EventArgs e)
        {
            load_data();
        }
    }
}
