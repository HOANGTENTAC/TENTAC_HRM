using System;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using TENTAC_HRM.Consts;
using TENTAC_HRM.Custom;

namespace TENTAC_HRM.Forms.NghiPhep
{
    public partial class uc_annual_leave : UserControl
    {
        DataSet dataTable = new DataSet();
        DataProvider provider = new DataProvider();
        public int[] idPermision { get; set; }
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
        //private void load_column_dgv()
        //{
        //    this.dgv_annual_leave.AddSpanHeader(0, 2, "");
        //    this.dgv_annual_leave.AddSpanHeader(2, 5, "Thông tin nhân viên");
        //    this.dgv_annual_leave.AddSpanHeader(7, 5, "Phép năm");
        //    this.dgv_annual_leave.AddSpanHeader(12, 12, "Tháng");
        //    this.dgv_annual_leave.AddSpanHeader(24, 2, "Tổng cộng");
        //}
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
            //LoadDGV();
        }

        public void load_data(int pageIndex, bool pageclick = false)
        {
            string sql = string.Format("select ROW_NUMBER() OVER(ORDER BY a.MaNhanVien ASC)AS rownumber,* Into ##tblTemp from fn_PhepNam({0}) a where 1=1", cbo_year.SelectedValue.ToString());
            if (!string.IsNullOrEmpty(txt_search.Texts))
            {
                sql = sql + string.Format(" and HoTen like N''%{0}%'' or DonVi like N''%{0}%'' or ChucVu like N''%{0}%'' or MaNhanVien like ''%{0}%''", txt_search.Texts);
            }
            if (LoginInfo.UserCd.ToUpper() != "ADMIN" && LoginInfo.UserCd.ToUpper() != "HR")
            {
                sql += $" and (ReportTo = ''{LoginInfo.UserCd}'' or MaNhanVien = ''{LoginInfo.UserCd}'') ";
            }
            dataTable = SQLHelper.ExecuteDs("getnhanvienpaging " + pageIndex + "," + PageSize + ",N'" + sql + "'");
            int recordCount = Convert.ToInt32(dataTable.Tables[0].Rows[0][0].ToString());
            this.HienThiThanhDieuHuong(recordCount, pageIndex);
            dgv_annual_leave.DataSource = dataTable.Tables[1].Rows.Cast<DataRow>().OrderBy(x => x["MaNhanVien"].ToString()).CopyToDataTable();

            //if (pageclick == false)
            //{
            //    this.HienThiThanhDieuHuong(recordCount, pageIndex);
            //}
            //load_column_dgv();
        }
        //public void LoadDGV()
        //{
        //    dgv_annual_leave.DataSource = dataTable.Tables[1].Rows.Cast<DataRow>().OrderBy(x => x["MaChamCong"].ToString()).CopyToDataTable();
        //}
        private void HienThiThanhDieuHuong(int recordCount, int currentPage)
        {
            pageCount = provider.HienThiThanhDieuHuong(recordCount, currentPage, PageSize, pnlDieuHuong, Page_Click);
            lb_totalsize.Text = "1/" + pageCount;
        }
        //Viết sự kiện khi kích trên nút phân trang
        private void Page_Click(object sender, EventArgs e)
        {
            DevComponents.DotNetBar.ButtonX btnPager = (sender as DevComponents.DotNetBar.ButtonX);
            this.load_data(int.Parse(btnPager.Name), true);
            //LoadDGV();
            lb_totalsize.Text = int.Parse(btnPager.Name) + "/" + pageCount.ToString();
            //foreach(Control button in pnlDieuHuong.Controls)
            //{
            //    button.Enabled = true;
            //    if (button.Name == btnPager.Name && button.Text != ">>")
            //    {
            //        button.Enabled = false;
            //    }
            //    if(button.Text == ">>")
            //    {
            //        button.Name = (int.Parse(btnPager.Name) + 1).ToString();
            //    }
            //    if (btnPager.Name == pageCount.ToString())
            //    {
            //        if (button.Text == ">>")
            //        {
            //            button.Enabled = false;
            //        }
            //    }
            //}
        }
        private void btn_edit_Click(object sender, EventArgs e)
        {
            if (dgv_annual_leave.Rows.Count > 0)
            {
                frm_nghiphepnam frm = new frm_nghiphepnam(this);
                frm.year = int.Parse(cbo_year.SelectedValue.ToString());
                frm._MaNhanVien = dgv_annual_leave.CurrentRow.Cells["MaNhanVien"].Value.ToString();
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
            //LoadDGV();
        }

        private void cbo_year_SelectionChangeCommitted(object sender, EventArgs e)
        {
            load_data(1); 
            //LoadDGV();
        }

        private void txt_search__TextChanged(object sender, EventArgs e)
        {
            load_data(1);
            //LoadDGV();
        }

        private void dgv_annual_leave_RowPostPaint(object sender, DataGridViewRowPostPaintEventArgs e)
        {
            var grid = sender as DataGridView;
            var rowIdx = (e.RowIndex + 1).ToString();
            var centerFormat = new StringFormat
            {
                Alignment = StringAlignment.Center,
                LineAlignment = StringAlignment.Center
            };
            var textSize = TextRenderer.MeasureText(rowIdx, Font);
            var headerBounds =
                new Rectangle(e.RowBounds.Left, e.RowBounds.Top, grid.RowHeadersWidth, e.RowBounds.Height);
            e.Graphics.DrawString(rowIdx, Font, SystemBrushes.ControlText, headerBounds, centerFormat);
        }

        private void dgv_annual_leave_CellContentDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            
        }

        private void dgv_annual_leave_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            switch (dgv_annual_leave.CurrentCell.OwningColumn.Name)
            {
                case "Th1":
                case "Th2":
                case "Th3":
                case "Th4":
                case "Th5":
                case "Th6":
                case "Th7":
                case "Th8":
                case "Th9":
                case "Th10":
                case "Th11":
                case "Th12":
                case "PhepDaDung":
                    Frm_NghiPhep user = new Frm_NghiPhep(idPermision);
                    user._manhanvien = dgv_annual_leave.CurrentRow.Cells["MaNhanVien"].Value.ToString();
                    user._year = cbo_year.Text;
                    user._month = dgv_annual_leave.CurrentCell.OwningColumn.Name.Replace("Th", "");
                    user._trangthai = "199";
                    if (dgv_annual_leave.CurrentCell.OwningColumn.Name == "PhepDaDung")
                    {
                        user._month = "";
                        user._xemtong = true;
                    }
                    user.ShowDialog();
                    break;
                case "show_col":
                    Frm_XemPhepNam frm_XemPhepNam = new Frm_XemPhepNam();
                    frm_XemPhepNam._manhanvien = dgv_annual_leave.CurrentRow.Cells["MaNhanVien"].Value.ToString();
                    frm_XemPhepNam._year = cbo_year.Text;
                    frm_XemPhepNam.ShowDialog();
                    break;
                default:
                    break;
            }
        }
    }
}
