using System;
using System.Data;
using System.Windows.Forms;
using TENTAC_HRM.Custom;

namespace TENTAC_HRM.Forms.NghiPhep
{
    public partial class uc_nghiphep : UserControl
    {
        public static uc_nghiphep _instance;
        public static uc_nghiphep Instance
        {
            get
            {
                _instance = new uc_nghiphep();
                return _instance;
            }
        }
        public uc_nghiphep()
        {
            InitializeComponent();
            cbo_trangthai.ComboBox.SelectionChangeCommitted += cbo_trangthai_SelectionChangeCommitted;
            cbo_year.ComboBox.SelectionChangeCommitted += cbo_year_SelectionChangeCommitted1;
        }

        private void cbo_year_SelectionChangeCommitted1(object sender, EventArgs e)
        {
            load_data();
        }

        private void cbo_trangthai_SelectionChangeCommitted(object sender, EventArgs e)
        {
            load_data();
        }

        private void uc_nghiphep_Load(object sender, EventArgs e)
        {
            load_trangthai();
            load_year();
            load_data();
        }

        private void load_trangthai()
        {
            DataTable datatable = new DataTable();
            datatable.Columns.Add("id");
            datatable.Columns.Add("name");
            datatable.Rows.Add("1", "Chưa duyệt");
            datatable.Rows.Add("2", "Chờ duyệt");
            datatable.Rows.Add("3", "Đã duyệt");
            cbo_trangthai.ComboBox.DataSource = datatable;
            cbo_trangthai.ComboBox.DisplayMember = "name";
            cbo_trangthai.ComboBox.ValueMember = "id";
        }

        private void load_year()
        {
            DataTable datatable = new DataTable();
            datatable.Columns.Add("id");
            datatable.Columns.Add("name");
            for (int i = 2010; i < DateTime.Now.Year + 2; i++)
            {
                datatable.Rows.Add(i, i);
            }
            cbo_year.ComboBox.DataSource = datatable;
            cbo_year.ComboBox.DisplayMember = "name";
            cbo_year.ComboBox.ValueMember = "id";
            cbo_year.ComboBox.SelectedValue = DateTime.Now.Year;
        }
        public void load_data()
        {
            string sql = string.Format("select f.id_nghi_phep,a.manhanvien,a.hoten,d.tenkhuvuc as don_vi,c.chucvu as chuc_vu," +
                        "e.typename as trang_thai,f.ngay_nghi,f.den_ngay,g.ten_nghi_phep as loai_phep,f.ghi_chu as noi_dung " +
                        "from tbl_nhanvien a " +
                        "join nhanvien_phongban b on a.manhanvien = b.ma_nhan_vien and is_active = 1 " +
                        "join mst_ChucVu c on c.MachucVu = b.machucvu " +
                        "join mst_KhuVuc d on d.maphongban = b.maphongban " +
                        "join sys_alltype e on a.id_trangthai = e.typeid " +
                        "join tas_nghi_phep_nam f on f.ma_nhan_vien = a.manhanvien " +
                        "join tas_nghi_phep g on g.id_nghi_phep = f.id_loai_phep_nghi " +
                        "where f.nam = '{0}' and f.del_flg = 0",cbo_year.ComboBox.SelectedValue.ToString());

            if (cbo_trangthai.ComboBox.SelectedValue.ToString() == "1")
            {
                sql = sql + " and chk_quanly = 0 and chk_nhansu = 0";
            }
            else if (cbo_trangthai.ComboBox.SelectedValue.ToString() == "2")
            {
                sql = sql + " and chk_quanly = 1 and chk_nhansu = 0";
            }
            else if (cbo_trangthai.ComboBox.SelectedValue.ToString() == "3")
            {
                sql = sql + " and chk_quanly = 1 and chk_nhansu = 1";
            }

            dgv_annual_leave.DataSource = SQLHelper.ExecuteDt(sql);
        }

        private void btn_add_Click(object sender, EventArgs e)
        {
            frm_annual_leave frm = new frm_annual_leave(this);
            frm.edit = false;
            frm.ShowDialog();
        }

        private void dgv_annual_leave_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dgv_annual_leave.CurrentCell.OwningColumn.Name == "edit_column")
            {
                frm_annual_leave frm = new frm_annual_leave(this);
                frm.edit = true;
                frm._id_nghi_phep_value = dgv_annual_leave.CurrentRow.Cells["id_nghi_phep"].Value.ToString();
                frm._ma_nhan_vien = dgv_annual_leave.CurrentRow.Cells["ma_nhan_vien"].Value.ToString();
                frm.ShowDialog();
            }
        }

        private void btn_close_Click(object sender, EventArgs e)
        {
            Control x = this.Parent;
            TabControl tab = (TabControl)x.Parent.Parent;
            tab.TabPages.Remove(tab.SelectedTab);
        }

        private void btn_delete_Click(object sender, EventArgs e)
        {
            try
            {
                DialogResult result = RJMessageBox.Show("Bạn có chác muốn xóa?", "Thông báo", MessageBoxButtons.YesNo);
                if (result == DialogResult.Yes)
                {
                    string sql = string.Format("update tas_nghi_phep_nam set del_flg = 1 and id_nguoi_tao = '{1}' where id_nghi_phep = '{0}'", dgv_annual_leave.CurrentRow.Cells["id_nghi_phep"].Value, SQLHelper.sIdUser);
                    if (SQLHelper.ExecuteSql(sql) == 1)
                    {
                        RJMessageBox.Show("Xóa thành công", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
            }
            catch(Exception ex) 
            {
                RJMessageBox.Show(ex.Message, "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
