using System;
using System.Data;
using System.Windows.Forms;
using TENTAC_HRM.Custom;

namespace TENTAC_HRM.Forms.NghiPhep
{
    public partial class uc_annual_leave : UserControl
    {
        DataProvider provider = new DataProvider();
        int PageSize = 50;
        int pageCount = 0;
        public static uc_annual_leave _instance;
        public static uc_annual_leave Instance
        {
            get
            {
                _instance = new uc_annual_leave();
                return _instance;
            }
        }
        public uc_annual_leave()
        {
            InitializeComponent();
        }
        private void load_column_dgv()
        {
            this.dgv_annual_leave.AddSpanHeader(0, 2, "");
            this.dgv_annual_leave.AddSpanHeader(2, 5, "Thông tin nhân viên");
            this.dgv_annual_leave.AddSpanHeader(7, 5, "Phép năm");
            this.dgv_annual_leave.AddSpanHeader(12, 12, "Tháng");
            this.dgv_annual_leave.AddSpanHeader(24, 2, "Tổng cộng");
        }
        private void uc_annual_leave_Load(object sender, EventArgs e)
        {
            ToolTip ToolTip1 = new ToolTip();
            ToolTip1.SetToolTip(this.btn_edit, "Sửa");
            ToolTip1.SetToolTip(this.btn_refresh, "Refresh");

            DataTable datatable = new DataTable();
            datatable.Columns.Add("id");
            datatable.Columns.Add("name");
            for (int i = 2010; i < DateTime.Now.Year + 2; i++)
            {
                datatable.Rows.Add(i, i);
            }
            cbo_year.DataSource = datatable;
            cbo_year.DisplayMember = "name";
            cbo_year.ValueMember = "id";
            cbo_year.SelectedValue = DateTime.Now.Year;
            load_data(1);
        }

        public void load_data(int pageIndex)
        {
            DataSet dataTable = new DataSet();
            string sql = string.Format("select ROW_NUMBER() OVER(ORDER BY a.ma_nhan_vien ASC)AS rownumber,* Into ##tblTemp from phep_nam({0}) a where 1=1", cbo_year.SelectedValue.ToString());
            if (!string.IsNullOrEmpty(txt_search.Texts))
            {
                sql = sql + string.Format(" and ho_ten like N''%{0}%'' or don_vi like N''%{0}%'' or chuc_vu like N''%{0}%''", txt_search.Texts);
            }

            dataTable = SQLHelper.ExecuteDs("getnhanvienpaging " + pageIndex + "," + PageSize + ",N'" + sql + "'");
            dgv_annual_leave.DataSource = dataTable.Tables[1];
            int recordCount = Convert.ToInt32(dataTable.Tables[0].Rows[0][0].ToString());
            this.HienThiThanhDieuHuong(recordCount, pageIndex);
            load_column_dgv();
        }
        private void HienThiThanhDieuHuong(int recordCount, int currentPage)
        {
            pageCount = provider.HienThiThanhDieuHuong(recordCount, currentPage, PageSize, pnlDieuHuong, Page_Click);
            lb_totalsize.Text = "1/" + pageCount;
        }
        //Viết sự kiện khi kích trên nút phân trang
        private void Page_Click(object sender, EventArgs e)
        {
            Button btnPager = (sender as Button);
            this.load_data(int.Parse(btnPager.Name));
            lb_totalsize.Text = int.Parse(btnPager.Name) + "/" + pageCount.ToString();
        }
        private void btn_edit_Click(object sender, EventArgs e)
        {
            if (dgv_annual_leave.Rows.Count > 0)
            {
                frm_nghiphepnam frm = new frm_nghiphepnam(this);
                frm.year = int.Parse(cbo_year.SelectedValue.ToString());
                frm._ma_nhanvien = dgv_annual_leave.CurrentRow.Cells["ma_nhan_vien"].Value.ToString();
                frm.ShowDialog();
            }
            else
            {
                RJMessageBox.Show("Chưa có dữ liệu", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void btn_refresh_Click(object sender, EventArgs e)
        {
            load_data(1);
        }

        private void btn_close_Click(object sender, EventArgs e)
        {
            provider.btn_close(this.Parent);
        }

        private void cbo_year_SelectionChangeCommitted(object sender, EventArgs e)
        {
            load_data(1);
        }

        private void txt_search__TextChanged(object sender, EventArgs e)
        {
            load_data(1);
        }
    }
}
