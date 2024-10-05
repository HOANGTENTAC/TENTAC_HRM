using System;
using System.Data;
using System.Drawing;
using System.Windows.Forms;

namespace TENTAC_HRM.ChamCong
{
    public partial class uc_bangxepca : UserControl
    {
        DataTable dt_bangchamcong = new DataTable();
        DateTime dtResult;
        DataProvider provider = new DataProvider();
        public static uc_bangxepca _instance;
        public static uc_bangxepca Instance
        {
            get
            {
                _instance = new uc_bangxepca();
                return _instance;
            }
        }
        public uc_bangxepca()
        {
            InitializeComponent();
            cbo_month.ComboBox.SelectionChangeCommitted += cbo_month_SelectionChangeCommitted;
            cbo_year.ComboBox.SelectionChangeCommitted += cbo_year_SelectionChangeCommitted;
        }

        private void cbo_month_SelectionChangeCommitted(object sender, EventArgs e)
        {
            load_bangcong();
            load_data();
        }
        private void cbo_year_SelectionChangeCommitted(object sender, EventArgs e)
        {
            load_bangcong();
            load_data();
        }

        private void uc_bangxepca_Load(object sender, EventArgs e)
        {
            load_year();
            load_ca();
            cbo_month.ComboBox.SelectedItem = DateTime.Now.Month.ToString();
            add_column();
            load_bangcong();
            load_data();
        }
        private void load_bangcong()
        {
            string sql = string.Format("select bangchamcong_id from hrm_danhsach_bangchamcong where thang = '{0}' and nam = '{1}'", cbo_month.ComboBox.SelectedItem, cbo_year.ComboBox.SelectedValue.ToString());
            dt_bangchamcong = SQLHelper.ExecuteDt(sql);
        }
        private void load_ca()
        {
            string sql = "select ma_ca,ten_ca from dic_calamviec";
            DataTable dataTable = new DataTable();
            dataTable = SQLHelper.ExecuteDt(sql);
            ten_ca.DataSource = dataTable;
            ten_ca.DisplayMember = "ten_ca";
            ten_ca.ValueMember = "ma_ca";
        }
        private void load_data()
        {
            DataTable dataTable = (DataTable)dgv_xepca.DataSource;
            if (dataTable != null)
            {
                dataTable.Clear();
            }

            if (dt_bangchamcong.Rows.Count > 0)
            {
                string sql = string.Format("hrm_bangxepca_getlist '{0}'", dt_bangchamcong.Rows[0][0].ToString());

                dataTable = SQLHelper.ExecuteDt(sql);
                dgv_xepca.DataSource = dataTable;
            }
            txt_tenbang_xepca.Text = "Tháng " + cbo_month.ComboBox.SelectedIndex.ToString() + " - " + cbo_year.ComboBox.SelectedValue.ToString();
        }

        private void load_year()
        {
            cbo_year.ComboBox.DataSource = provider.load_year();
            cbo_year.ComboBox.DisplayMember = "name";
            cbo_year.ComboBox.ValueMember = "id";
            cbo_year.ComboBox.SelectedValue = DateTime.Now.Year.ToString();
        }
        private void add_column()
        {
            dtResult = DateTime.Parse(cbo_year.ComboBox.SelectedValue.ToString() + "/" + cbo_month.ComboBox.SelectedItem.ToString() + "/01");
            dtResult = dtResult.AddMonths(1);
            dtResult = dtResult.AddDays(-dtResult.Day);

            for (int i = 1; i <= dtResult.Day; i++)
            {
                DateTime date = new DateTime(dtResult.Year, dtResult.Month, i);
                dgv_xepca.Columns[i + 6].HeaderText = i.ToString() + Environment.NewLine + provider.getdayname(date.DayOfWeek);
                dgv_xepca.Columns[i + 6].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                dgv_xepca.Columns[i + 6].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
                dgv_xepca.Columns[i + 6].Width = 40;

                if (i % 2 == 0)
                {
                    dgv_xepca.Columns[i + 6].DefaultCellStyle.BackColor = Color.MistyRose;
                }
                else
                {
                    dgv_xepca.Columns[i + 6].DefaultCellStyle.BackColor = Color.Cornsilk;
                }
                if (date.DayOfWeek == DayOfWeek.Sunday)
                {
                    dgv_xepca.Columns[i + 6].DefaultCellStyle.BackColor = Color.Azure;
                }
            }
            if (dtResult.Day < 31)
            {
                for (int i = dtResult.Day + 1; i <= 31; i++)
                {
                    dgv_xepca.Columns[i + 6].Visible = false;
                }
            }
        }

        private void btn_close_Click(object sender, EventArgs e)
        {
            provider.btn_close(this.Parent);
        }

        private void dgv_xepca_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dgv_xepca.CurrentCell.OwningColumn.Name == "tat_ca")
            {
                if (dgv_xepca.CurrentRow.Cells["tat_ca"].Value.ToString() == "False")
                {
                    dgv_xepca.CurrentRow.Cells["tat_ca"].Value = true;
                    for (int i = 1; i <= dtResult.Day; i++)
                    {
                        dgv_xepca.CurrentRow.Cells["d" + i].Value = true;
                    }
                }
                else
                {
                    dgv_xepca.CurrentRow.Cells["tat_ca"].Value = false;
                    for (int i = 1; i <= dtResult.Day; i++)
                    {
                        dgv_xepca.CurrentRow.Cells["d" + i].Value = false;
                    }
                }
            }
        }

        private void btn_calamviec_Click(object sender, EventArgs e)
        {
            frm_calamviec frm = new frm_calamviec();
            frm.ShowDialog();
        }

        private void toolStripButton5_Click(object sender, EventArgs e)
        {

        }
    }
}
