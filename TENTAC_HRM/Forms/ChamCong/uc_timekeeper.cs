using System;
using System.Data;
using System.Drawing;
using System.Windows.Forms;
using TENTAC_HRM.Category;

namespace TENTAC_HRM.ChamCong
{
    public partial class uc_timekeeper : UserControl
    {
        DataProvider provider = new DataProvider();
        public static uc_timekeeper _instance;
        public static uc_timekeeper Instance
        {
            get
            {
                //if (_instance == null)
                _instance = new uc_timekeeper();
                return _instance;
            }
        }
        public uc_timekeeper()
        {
            InitializeComponent();
        }
        private void add_column_dgv()
        {
            //dgv_timekeeper.Columns[0].Name = "ma_nhan_vien";
            //dgv_timekeeper.Columns[0].HeaderText = "Mã nhân viên";
            dgv_timekeeper.Columns[0].Width = 120;
            dgv_timekeeper.Columns[0].Frozen = true;
            //dgv_timekeeper.Columns[1].Name = "ho_lot";
            //dgv_timekeeper.Columns[1].HeaderText = "Họ lót";
            dgv_timekeeper.Columns[1].Frozen = true;
            //dgv_timekeeper.Columns[2].Name = "ten";
            //dgv_timekeeper.Columns[2].HeaderText = "Tên";
            dgv_timekeeper.Columns[2].Frozen = true;
            dgv_timekeeper.Columns[2].Width = 60;

            DateTime dtResult = DateTime.Parse("2023/09/01");
            dtResult = dtResult.AddMonths(1);
            dtResult = dtResult.AddDays(-dtResult.Day);

            for (int i = 1; i <= dtResult.Day; i++)
            {
                DateTime date = new DateTime(dtResult.Year, dtResult.Month, i);
                dgv_timekeeper.Columns[i + 2].HeaderText = i.ToString() + Environment.NewLine + provider.getdayname(date.DayOfWeek);
                dgv_timekeeper.Columns[i + 2].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                dgv_timekeeper.Columns[i + 2].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
                dgv_timekeeper.Columns[i + 2].Width = 40;

                if (i % 2 == 0)
                {
                    dgv_timekeeper.Columns[i + 2].DefaultCellStyle.BackColor = Color.MistyRose;
                }
                else
                {
                    dgv_timekeeper.Columns[i + 2].DefaultCellStyle.BackColor = Color.Cornsilk;
                }
                if (date.DayOfWeek == DayOfWeek.Sunday)
                {
                    dgv_timekeeper.Columns[i + 2].DefaultCellStyle.BackColor = Color.Azure;
                }
            }
            if (dtResult.Day < 31)
            {
                for (int i = dtResult.Day + 1; i <= 31; i++)
                {
                    dgv_timekeeper.Columns[i + 2].Visible = false;
                }
            }
            //dgv_timekeeper.Columns[34].HeaderText = "Nghỉ KP";
            //dgv_timekeeper.Columns[34].Width = 50;
            //dgv_timekeeper.Columns[34].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            //dgv_timekeeper.Columns[34].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            //dgv_timekeeper.Columns[34].DefaultCellStyle.BackColor = Color.WhiteSmoke;
            //dgv_timekeeper.Columns[35].HeaderText = "Nghỉ CP";
            //dgv_timekeeper.Columns[35].Width = 50;
            //dgv_timekeeper.Columns[35].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            //dgv_timekeeper.Columns[35].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            //dgv_timekeeper.Columns[35].DefaultCellStyle.BackColor = Color.WhiteSmoke;
            //dgv_timekeeper.Columns[36].HeaderText = "Đi trễ";
            //dgv_timekeeper.Columns[36].Width = 50;
            //dgv_timekeeper.Columns[36].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            //dgv_timekeeper.Columns[36].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            //dgv_timekeeper.Columns[37].HeaderText = "Về sớm";
            //dgv_timekeeper.Columns[37].Width = 50;
            //dgv_timekeeper.Columns[37].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            //dgv_timekeeper.Columns[37].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            //dgv_timekeeper.Columns[38].HeaderText = "Tổng giờ";
            //dgv_timekeeper.Columns[38].Width = 50;
            //dgv_timekeeper.Columns[38].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            //dgv_timekeeper.Columns[38].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            //dgv_timekeeper.Columns[39].HeaderText = "Trực đêm";
            //dgv_timekeeper.Columns[39].Width = 50;
            //dgv_timekeeper.Columns[39].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            //dgv_timekeeper.Columns[39].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            //dgv_timekeeper.Columns[40].HeaderText = "Tăng cường";
            //dgv_timekeeper.Columns[40].Width = 50;
            //dgv_timekeeper.Columns[40].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            //dgv_timekeeper.Columns[40].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            //dgv_timekeeper.Columns[41].HeaderText = "Làm việc riêng";
            //dgv_timekeeper.Columns[41].Width = 89;
            //dgv_timekeeper.Columns[41].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            //dgv_timekeeper.Columns[41].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            //dgv_timekeeper.Columns[42].HeaderText = "Không chấm vào";
            //dgv_timekeeper.Columns[42].Width = 94;
            //dgv_timekeeper.Columns[42].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            //dgv_timekeeper.Columns[42].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            //dgv_timekeeper.Columns[43].HeaderText = "Không chấm ra";
            //dgv_timekeeper.Columns[43].Width = 70;
            //dgv_timekeeper.Columns[43].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            //dgv_timekeeper.Columns[43].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            //dgv_timekeeper.Columns[44].HeaderText = "Ngày công";
            //dgv_timekeeper.Columns[44].Width = 60;
            //dgv_timekeeper.Columns[44].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            //dgv_timekeeper.Columns[44].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            //dgv_timekeeper.Columns[45].HeaderText = "Nghỉ chế độ";
            //dgv_timekeeper.Columns[45].Width = 60;
            //dgv_timekeeper.Columns[45].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            //dgv_timekeeper.Columns[45].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            //dgv_timekeeper.Columns[46].HeaderText = "Nghỉ phép";
            //dgv_timekeeper.Columns[46].Width = 60;
            //dgv_timekeeper.Columns[46].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            //dgv_timekeeper.Columns[46].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            //dgv_timekeeper.Columns[47].HeaderText = "Nghỉ bù";
            //dgv_timekeeper.Columns[47].Width = 60;
            //dgv_timekeeper.Columns[47].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            //dgv_timekeeper.Columns[47].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            //dgv_timekeeper.Columns[48].HeaderText = "Tổng cộng";
            //dgv_timekeeper.Columns[48].Width = 60;
            //dgv_timekeeper.Columns[48].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            //dgv_timekeeper.Columns[48].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
        }
        private void load_data()
        {
            string sql = "hrm_bangchamcong_getlist '5A8DC6A9-08D7-480A-8C45-8D3450EB5377'";
            dgv_timekeeper.DataSource = SQLHelper.ExecuteDt(sql);
        }
        private void uc_timekeeper_Load(object sender, EventArgs e)
        {
            load_year();
            load_data();
            add_column_dgv();
            load_symbol();
        }
        private void load_year()
        {
            cbo_nam.ComboBox.DataSource = provider.load_year();
            cbo_nam.ComboBox.DisplayMember = "name";
            cbo_nam.ComboBox.ValueMember = "id";
        }

        private void btn_close_Click(object sender, EventArgs e)
        {
            provider.btn_close(this.Parent);
        }

        private void btn_refresh_Click(object sender, EventArgs e)
        {
            load_data();
        }

        private void btn_edit_synbol_Click(object sender, EventArgs e)
        {
            frm_kyhieu_chamcong frm = new frm_kyhieu_chamcong();
            frm.ShowDialog();
        }

        public void load_symbol()
        {
            string sql = "select ma_kyhieu,ten_kyhieu from dic_kyhieu";
            DataTable dt = new DataTable();
            dt = SQLHelper.ExecuteDt(sql);
            if (dt.Rows.Count > 0)
            {
                int count = 0;
                int rowy = 0;
                int rowx = 0;
                foreach (DataRow item in dt.Rows)
                {

                    Label label = new Label();
                    label.Text = item["ten_kyhieu"].ToString();
                    label.Location = new Point(9 + rowx, 27 + rowy);
                    label.Size = new Size(125, 17);
                    label.TextAlign = ContentAlignment.MiddleLeft;
                    pl_symbol.Controls.Add(label);

                    Label label_ma = new Label();
                    label_ma.Text = ": " + item["ma_kyhieu"].ToString();
                    label_ma.Location = new Point(130 + rowx, 27 + rowy);
                    label_ma.Size = new Size(40, 17);
                    label_ma.TextAlign = ContentAlignment.MiddleLeft;
                    pl_symbol.Controls.Add(label_ma);

                    rowy = rowy + 20;
                    count++;

                    if (count >= 5)
                    {
                        rowx = rowx + 175;
                        rowy = 0;
                        count = 0;
                    }
                }
            }
        }
    }
}
