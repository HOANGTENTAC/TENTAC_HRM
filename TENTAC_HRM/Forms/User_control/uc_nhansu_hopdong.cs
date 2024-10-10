using System;
using System.Data;
using System.Drawing;
using System.Windows.Forms;
using TENTAC_HRM.Category;

namespace TENTAC_HRM.User_control
{
    public partial class uc_nhansu_hopdong : UserControl
    {
        DataProvider provider = new DataProvider();
        int pageCount = 0;
        int PageSize = 50;
        public static uc_nhansu_hopdong _instance;
        public static uc_nhansu_hopdong Instance
        {
            get
            {
                _instance = new uc_nhansu_hopdong();
                return _instance;
            }
        }
        public uc_nhansu_hopdong()
        {
            InitializeComponent();
            cbo_loai_hopdong.ComboBox.SelectionChangeCommitted += cbo_loai_hopdong_SelectionChangeCommitted;
        }

        private void cbo_loai_hopdong_SelectionChangeCommitted(object sender, EventArgs e)
        {
            load_data(1);
        }

        private void uc_nhansu_hopdong_Load(object sender, EventArgs e)
        {
            load_loaihopdong();
            load_data(1);
        }
        private void load_loaihopdong()
        {
            cbo_loai_hopdong.ComboBox.DataSource = provider.load_loaihopdong();
            cbo_loai_hopdong.ComboBox.DisplayMember = "name";
            cbo_loai_hopdong.ComboBox.ValueMember = "id";
        }
        public void load_data(int pageIndex)
        {
            DataRowView vrow = (DataRowView)cbo_loai_hopdong.SelectedItem;
            string row = vrow.Row.ItemArray[0].ToString();

            string sql = "select rownumber,Id,manhanvien,sohopdong,holot,ten,loaihopdong,thoigian,ngayky,tungay,denngay,nguoiky,ghichu,id_loaihopdong into ##tblTemp from view_nhanvien_hopdong";
            if (row != "0")
            {
                sql = sql + string.Format(" where id_loaihopdong = {0}", row);
            }
            DataSet dt = new DataSet();
            dt = SQLHelper.ExecuteDs("getnhanvienpaging " + pageIndex + "," + PageSize + ",N'" + sql + "'");
            dgv_nhanvien_hopdong.DataSource = dt.Tables[1];
            int recordCount = Convert.ToInt32(dt.Tables[0].Rows[0][0].ToString());
            this.HienThiThanhDieuHuong(recordCount, pageIndex);
        }
        private void HienThiThanhDieuHuong(int recordCount, int currentPage)
        {
            pageCount = provider.HienThiThanhDieuHuong(recordCount, currentPage, PageSize, pnlDieuHuong, Page_Click);
            lb_totalsize.Text = "1/" + pageCount;
        }
        private void Page_Click(object sender, EventArgs e)
        {
            Button btnPager = (sender as Button);
            this.load_data(int.Parse(btnPager.Name));
            lb_totalsize.Text = int.Parse(btnPager.Name) + "/" + pageCount.ToString();
        }

        private void btn_close_Click(object sender, EventArgs e)
        {
            provider.btn_close(this.Parent);
        }

        private void btn_add_Click(object sender, EventArgs e)
        {
            frm_contract frm = new frm_contract(null,this);
            frm.edit = false;
            frm.ShowDialog();
        }

        private void btn_refresh_Click(object sender, EventArgs e)
        {
            load_data(1);
        }

        private void btn_edit_Click(object sender, EventArgs e)
        {
            frm_contract frm = new frm_contract(null, this);
            frm.edit = true;
            frm._ma_nhan_vien = dgv_nhanvien_hopdong.CurrentRow.Cells["ma_nhan_vien"].Value.ToString();
            frm._id_hopdong = int.Parse(dgv_nhanvien_hopdong.CurrentRow.Cells["id_hop_dong"].Value.ToString());
            frm.ShowDialog();
        }

        private void dgv_nhanvien_hopdong_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dgv_nhanvien_hopdong.CurrentCell.OwningColumn.Name == "edit_column")
            {
                frm_contract frm = new frm_contract(null, this);
                frm.edit = true;
                frm._ma_nhan_vien = dgv_nhanvien_hopdong.CurrentRow.Cells["ma_nhan_vien"].Value.ToString();
                frm._id_hopdong = int.Parse(dgv_nhanvien_hopdong.CurrentRow.Cells["id_hop_dong"].Value.ToString());
                frm.ShowDialog();
            }
        }

        private void dgv_nhanvien_hopdong_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            DataGridViewRow row = dgv_nhanvien_hopdong.Rows[e.RowIndex];
            if (row.Cells["id_loai_hop_dong"].Value.ToString() == "1")
            {
                row.DefaultCellStyle.ForeColor = Color.Green;
            }
            else
            {
                DateTime startdate = DateTime.Parse(row.Cells["den_ngay"].Value.ToString());
                DateTime enddate = DateTime.Now;
                if ((startdate - enddate).TotalDays < 10)
                {
                    row.DefaultCellStyle.ForeColor = Color.Red;
                }
                else
                {
                    row.DefaultCellStyle.ForeColor = Color.Green;
                }
            }
        }
    }
}
