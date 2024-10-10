using System;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using TENTAC_HRM.Custom;
using TENTAC_HRM.Forms.NghiPhep;

namespace TENTAC_HRM.ChamCong
{
    public partial class uc_bangxepca : UserControl
    {
        CheckBox headerCheckBox = new CheckBox();
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
            cbo_phongban.ComboBox.SelectionChangeCommitted += cbo_phongban_SelectionChangeCommitted;
        }

        private void cbo_phongban_SelectionChangeCommitted(object sender, EventArgs e)
        {
            load_bangxepca();
        }

        private void BindGrid()
        {
            //Find the Location of Header Cell.
            Point headerCellLocation = this.dgv_xepca.GetCellDisplayRectangle(1, -1, true).Location;

            //Place the Header CheckBox in the Location of the Header Cell.
            headerCheckBox.Location = new Point(headerCellLocation.X + 8, headerCellLocation.Y + 15);
            headerCheckBox.BackColor = Color.Transparent;
            headerCheckBox.Size = new Size(18, 18);

            //Assign Click event to the Header CheckBox.
            headerCheckBox.Click += new EventHandler(HeaderCheckBox_Clicked);
            dgv_xepca.Controls.Add(headerCheckBox);
        }
        private void HeaderCheckBox_Clicked(object sender, EventArgs e)
        {
            //Necessary to end the edit mode of the Cell.
            dgv_xepca.EndEdit();

            //Loop and check and uncheck all row CheckBoxes based on Header Cell CheckBox.
            foreach (DataGridViewRow row in dgv_xepca.Rows)
            {
                DataGridViewCheckBoxCell checkBox = (row.Cells["chk_col"] as DataGridViewCheckBoxCell);
                checkBox.Value = headerCheckBox.Checked;
            }
        }
        private void cbo_month_SelectionChangeCommitted(object sender, EventArgs e)
        {
            load_bangxepca();
        }
        private void cbo_year_SelectionChangeCommitted(object sender, EventArgs e)
        {
            load_bangxepca();
        }

        private void uc_bangxepca_Load(object sender, EventArgs e)
        {
            calamviec();
            load_year();
            cbo_month.ComboBox.SelectedItem = DateTime.Now.Month.ToString();
            add_column();
            load_bangxepca();
            load_phongban();
            BindGrid();
        }
        private void calamviec()
        {
            string sql = "SELECT [MaCaLamViec],[CaLamViec] FROM MITACOSQL.dbo.CaLamViecNew";
            DataTable dataTable = new DataTable();
            dataTable = SQLHelper.ExecuteDt(sql);
            dataTable.Rows.Add("", "");

            for (int i = 1; i <= 31; i++)
            {
                ((DataGridViewComboBoxColumn)dgv_xepca.Columns["d" + i.ToString()]).DataSource = dataTable;
                ((DataGridViewComboBoxColumn)dgv_xepca.Columns["d" + i.ToString()]).DisplayMember = "CaLamViec";
                ((DataGridViewComboBoxColumn)dgv_xepca.Columns["d" + i.ToString()]).ValueMember = "MaCaLamViec";
                ((DataGridViewComboBoxColumn)dgv_xepca.Columns["d" + i.ToString()]).DisplayStyle = DataGridViewComboBoxDisplayStyle.Nothing;
            }
        }
        private void load_phongban()
        {
            string sql = "SELECT [MaPhongBan],[TenPhongBan] FROM MITACOSQL.dbo.PHONGBAN";
            DataTable dt = new DataTable();
            dt = SQLHelper.ExecuteDt(sql);
            dt.Rows.Add("0", "Chọn tất cả");
            dt = dt.Rows.Cast<DataRow>().OrderBy(x => x.Field<string>("MaPhongBan")).CopyToDataTable();
            cbo_phongban.ComboBox.DataSource = dt;
            cbo_phongban.ComboBox.DisplayMember = "TenPhongBan";
            cbo_phongban.ComboBox.ValueMember = "MaPhongBan";
        }
        private void load_bangxepca()
        {
            headerCheckBox.Checked = false;
            string where = "";
            if (!string.IsNullOrEmpty(txt_search.TextBox.Text))
            {
                where = where + $" and nv.MaNhanVien like '%{txt_search.TextBox.Text}%' or nv.TenNhanVien like '%{txt_search.TextBox.Text}%' ";
            }
            if (cbo_phongban.ComboBox.SelectedValue != null)
            {
                if (cbo_phongban.ComboBox.SelectedValue.ToString() != "0")
                {
                    where = where + $" and nv.MaPhongBan = '{cbo_phongban.ComboBox.SelectedValue}'";
                }
            }
            string sql = "select hts.id,'false' chk_col,hts.MaChamCong,nv.HoTen," +
                "hts.d1,hts.d2,hts.d3,hts.d4,hts.d5,hts.d6,hts.d7,hts.d8,hts.d9,hts.d10," +
                "hts.d11,hts.d12,hts.d13,hts.d14,hts.d15,hts.d16,hts.d17,hts.d18,hts.d19,hts.d20," +
                "hts.d21,hts.d22,hts.d23,hts.d24,hts.d25,hts.d26,hts.d27,hts.d28,hts.d29,hts.d30," +
                "hts.d31 " +
                "from MITACOSQL.dbo.BangXepCa hts " +
                "inner join tbl_NhanVien nv on hts.MaChamCong=nv.machamcong " +
                $"where hts.Nam = '{cbo_year.ComboBox.SelectedValue}' and hts.Thang = '{cbo_month.Text}'" + where;
            DataTable dt = new DataTable();
            dt = SQLHelper.ExecuteDt(sql);
            dgv_xepca.DataSource = dt;
            lb_count_nv.Text = "Nhân viên : " + dt.Rows.Count;

            int hc = 0;
            int ca1 = 0;
            int ca2 = 0;
            int ca3 = 0;
            foreach (DataRow item in dt.Rows)
            {
                int counthc = 0;
                int countca1 = 0;
                int countca2 = 0;
                int countca3 = 0;

                for (int i = 4; i < dt.Columns.Count; i++)
                {
                    if (item[i].ToString() == "HC" && counthc == 0)
                    {
                        counthc = 1;
                        hc++;
                    }
                    if (item[i].ToString() == "CA1" && countca1 == 0)
                    {
                        countca1 = 1;
                        ca1++;
                    }
                    if (item[i].ToString() == "CA2" && countca2 == 0)
                    {
                        countca2 = 1;
                        ca2++;
                    }
                    if (item[i].ToString() == "CA3" && countca3 == 0)
                    {
                        countca3 = 1;
                        ca3++;
                    }
                }
            }
            txt_info.Text = "ca HC: " + hc.ToString() + " nhân viên | " +
                "ca 1   : " + ca1.ToString() + " nhân viên | " +
                "ca 2   : " + ca2.ToString() + " nhân viên | " +
                "ca 3   : " + ca3.ToString() + " nhân viên";
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
                dgv_xepca.Columns[i + 3].HeaderText = i.ToString() + Environment.NewLine + provider.getdayname(date.DayOfWeek);
                dgv_xepca.Columns[i + 3].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                dgv_xepca.Columns[i + 3].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
                dgv_xepca.Columns[i + 3].Width = 50;

                //if (i % 2 == 0)
                //{
                //    dgv_xepca.Columns[i + 3].DefaultCellStyle.BackColor = Color.MistyRose;
                //}
                //else
                //{
                //    dgv_xepca.Columns[i + 3].DefaultCellStyle.BackColor = Color.Cornsilk;
                //}
                //if (date.DayOfWeek == DayOfWeek.Sunday)
                //{
                //    dgv_xepca.Columns[i + 3].DefaultCellStyle.BackColor = Color.Azure;
                //}
                dgv_xepca.Columns[i + 3].DefaultCellStyle.BackColor = Color.Cornsilk;
                if (date.DayOfWeek == DayOfWeek.Sunday)
                {
                    dgv_xepca.Columns[i + 3].DefaultCellStyle.BackColor = Color.SlateGray;
                }
                else if (date.DayOfWeek == DayOfWeek.Saturday)
                {
                    dgv_xepca.Columns[i + 3].DefaultCellStyle.BackColor = Color.LightSalmon;
                }
            }
            if (dtResult.Day < 31)
            {
                for (int i = dtResult.Day + 1; i <= 31; i++)
                {
                    dgv_xepca.Columns[i + 6].Visible = false;
                }
            }
            else
            {
                dgv_xepca.Columns["d28"].Visible = true;
                dgv_xepca.Columns["d29"].Visible = true;
                dgv_xepca.Columns["d30"].Visible = true;
                dgv_xepca.Columns["d31"].Visible = true;
            }
        }

        private void btn_close_Click(object sender, EventArgs e)
        {
            provider.btn_close(this.Parent);
        }

        private void dgv_xepca_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
        }

        private void btn_calamviec_Click(object sender, EventArgs e)
        {
            frm_calamviec frm = new frm_calamviec();
            frm.ShowDialog();
        }

        private void toolStripButton5_Click(object sender, EventArgs e)
        {
            Frm_NgayNghi frm = new Frm_NgayNghi();
            frm.ShowDialog();
        }

        private void btn_refresh_Click(object sender, EventArgs e)
        {
            Cursor.Current = Cursors.WaitCursor;
            try
            {
                var mess = RJMessageBox.Show("Nạp lại sẽ mất hết dữ liệu trong tháng bạn có chắc muốn nạp lại dữ liệu?", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                if (mess == DialogResult.Yes)
                {
                    string month = (int.Parse(cbo_month.ComboBox.Text) < 10 ? "0" + cbo_month.ComboBox.Text : cbo_month.ComboBox.Text);
                    string sql = $"proc_BangXepCaThang {cbo_year.ComboBox.Text}, {month}";
                    SQLHelper.ExecuteSql(sql);
                    RJMessageBox.Show("Nạp lại dữ liệu thành công", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    load_bangxepca();
                }
            }
            catch (Exception ex)
            {
                RJMessageBox.Show(ex.Message, "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            Cursor.Current = Cursors.Default;
        }
    }
}
