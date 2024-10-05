using System;
using System.Data;
using System.Windows.Forms;
using TENTAC_HRM.Custom;

namespace TENTAC_HRM.User_control
{
    public partial class uc_nation : UserControl
    {
        string madantoc_value, tendantoc_value, thutu_value, mota_value, nguoitao_value, id_dantoc_value;
        public bool edit { get; set; }
        public static uc_nation _instance;
        public static uc_nation Instance
        {
            get
            {
                if (_instance == null)
                    _instance = new uc_nation();
                return _instance;
            }
        }
        public uc_nation()
        {
            InitializeComponent();
        }
        private void load_data()
        {
            string sql = "select id_dan_toc,ma_dan_toc,ten_dan_toc,thu_tu,mo_ta from hrm_dan_toc";
            DataTable dt = new DataTable();
            dt = SQLHelper.ExecuteDt(sql);
            dgv_nation.DataSource = dt;
        }

        private void uc_nation_Load(object sender, EventArgs e)
        {
            //pl_nation.Width = 0;
            load_data();
        }

        private void dgv_nation_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dgv_nation.CurrentCell.OwningColumn.Name == "edit_column")
            {
                btn_save.Text = "Cập nhật";
                id_dantoc_value = dgv_nation.CurrentRow.Cells["id_dan_toc"].Value.ToString();
                edit = true;
                txt_ma_dan_toc.Text = dgv_nation.CurrentRow.Cells["ma_dan_toc"].Value.ToString();
                txt_dan_toc.Text = dgv_nation.CurrentRow.Cells["ten_dan_toc"].Value.ToString();
                txt_thu_tu.Text = dgv_nation.CurrentRow.Cells["thu_tu"].Value.ToString();
                txt_mo_ta.Text = dgv_nation.CurrentRow.Cells["mo_ta"].Value.ToString();
                pl_nation.Enabled = true;
            }
        }
        private void btn_cancel_Click(object sender, EventArgs e)
        {
            pl_nation.Enabled = false;
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
        }

        private void update_data()
        {
            try
            {
                string sql = string.Format("update hrm_dan_toc set ma_dan_toc = '{1}',ten_dan_toc = N'{2}',thu_tu = '{3}',mo_ta = '{4}',ngay_cap_nhat = GETDATE() " +
                    "where id_dan_toc = {0}", id_dantoc_value, madantoc_value, tendantoc_value, thutu_value, mota_value);
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

        private void save_data()
        {
            try
            {
                string sql = string.Format("insert into hrm_dan_toc(ma_dan_toc,ten_dan_toc,thu_tu,mo_ta,ngay_tao,id_nguoi_tao) " +
                            "values('{0}',N'{1}','{2}',N'{3}',GETDATE(),'{5}')", madantoc_value, tendantoc_value, thutu_value, mota_value, nguoitao_value);
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
            madantoc_value = txt_ma_dan_toc.Text;
            tendantoc_value = txt_dan_toc.Text;
            thutu_value = txt_thu_tu.Text;
            mota_value = txt_mo_ta.Text;
            nguoitao_value = SQLHelper.sIdUser;
        }

        private void btn_close_Click(object sender, EventArgs e)
        {
            Control x = this.Parent;
            x.Controls.Remove(this);
        }

        private void btn_add_Click(object sender, EventArgs e)
        {
            txt_ma_dan_toc.Text = "";
            txt_dan_toc.Text = "";
            txt_mo_ta.Text = "";
            txt_thu_tu.Text = "";
            btn_save.Text = "Lưu";
            edit = false;
            pl_nation.Enabled = true;
        }
    }
}
