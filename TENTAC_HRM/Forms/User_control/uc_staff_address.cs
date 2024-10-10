using System;
using System.Data;
using System.Linq;
using System.Windows.Forms;
using TENTAC_HRM.Custom;
using TENTAC_HRM.Model;

namespace TENTAC_HRM.User_control
{
    public partial class uc_staff_address : UserControl
    {
        Diachi_model model = new Diachi_model();
        DataProvider provider = new DataProvider();
        public bool edit { get; set; }
        public string _ma_nhan_vien = "0";
        public bool uc_controll = false;
        public static uc_staff_address _instance;
        public static uc_staff_address Instance
        {
            get
            {
                if (_instance == null)
                    _instance = new uc_staff_address();
                return _instance;
            }
        }
        public uc_staff_address()
        {
            InitializeComponent();
        }

        private void uc_staff_address_Load(object sender, EventArgs e)
        {
            if (uc_controll == true)
            {
                cbo_nhanvien.Enabled = true;
            }
            else
            {
                cbo_nhanvien.Enabled = false;
            }
            load_nhanvien();
            load_loai_dia_chi();
            load_quoc_gia();
            load_data();
        }
        private void load_nhanvien()
        {
            cbo_nhanvien.DataSource = provider.load_nhanvien();
            cbo_nhanvien.DisplayMember = "name";
            cbo_nhanvien.ValueMember = "value";
            if(!string.IsNullOrEmpty(_ma_nhan_vien))
                cbo_nhanvien.SelectedValue = _ma_nhan_vien;
        }
        private void load_loai_dia_chi()
        {
            cbo_loai_dia_chi.DataSource = provider.load_all_type(40);
            cbo_loai_dia_chi.DisplayMember = "name";
            cbo_loai_dia_chi.ValueMember = "id";
        }
        private void load_quoc_gia()
        {
            cbo_quoc_gia.DataSource = provider.load_diachi(20);
            cbo_quoc_gia.DisplayMember = "name";
            cbo_quoc_gia.ValueMember = "id";
        }
        private void cbo_tinh_SelectedValueChanged(object sender, EventArgs e)
        {
            DataRowView vrow = (DataRowView)cbo_tinh.SelectedItem;
            string row = vrow.Row.ItemArray[0].ToString();
            if (row != "")
            {
                string sql = string.Format("select id,tendiachi from mst_DonViHanhChinh where ParentId = {0}", row);
                DataTable dt = new DataTable();
                dt = SQLHelper.ExecuteDt(sql);
                dt.Rows.Add("0", "");
                cbo_quan.DataSource = dt.Rows.Cast<DataRow>().OrderBy(x => x.Field<int>("id")).CopyToDataTable();
                cbo_quan.DisplayMember = "tendiachi";
                cbo_quan.ValueMember = "id";
            }
        }

        private void cbo_quan_SelectedValueChanged(object sender, EventArgs e)
        {
            DataRowView vrow = (DataRowView)cbo_quan.SelectedItem;
            string row = vrow.Row.ItemArray[0].ToString();
            if (row != "")
            {
                string sql = string.Format("select id,tendiachi from mst_DonViHanhChinh where ParentId = {0}", row);
                DataTable dt = new DataTable();
                dt = SQLHelper.ExecuteDt(sql);
                dt.Rows.Add("0", "");
                cbo_phuong.DataSource = dt.Rows.Cast<DataRow>().OrderBy(x => x.Field<int>("id")).CopyToDataTable();
                cbo_phuong.DisplayMember = "tendiachi";
                cbo_phuong.ValueMember = "id";
            }
        }

        private void cbo_quoc_gia_SelectedValueChanged(object sender, EventArgs e)
        {
            DataRowView vrow = (DataRowView)cbo_quoc_gia.SelectedItem;
            string row = vrow.Row.ItemArray[0].ToString();
            if (row != "")
            {
                string sql = string.Format("select id,tendiachi from mst_DonViHanhChinh where ParentId = {0}", row);
                DataTable dt = new DataTable();
                dt = SQLHelper.ExecuteDt(sql);
                dt.Rows.Add("0", "");
                cbo_tinh.DataSource = dt.Rows.Cast<DataRow>().OrderBy(x => x.Field<int>("id")).CopyToDataTable();
                cbo_tinh.DisplayMember = "tendiachi";
                cbo_tinh.ValueMember = "id";
            }
        }
        private void btn_add_Click(object sender, EventArgs e)
        {
            //cbo_nhanvien.Enabled = true;
            chk_dang_hieu_luc.Checked = false;
            btn_save.Text = "Lưu";
            edit = false;
            cbo_quoc_gia.SelectedValue = 0;
            cbo_loai_dia_chi.Enabled = true;
            pl_address.Enabled = true;
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
        private void check_active(int id)
        {
            try
            {
                if (chk_dang_hieu_luc.Checked == true)
                {
                    string sql = string.Format("select * from tbl_NhanVienDiaChi where manhanvien = '{0}' and loaidiachi = {1} and id <> {2} and is_active = 1",
                            model.Ma_nhan_vien, model.Loai_dichi_value, id);
                    DataTable dt = new DataTable();
                    dt = SQLHelper.ExecuteDt(sql);
                    if (dt.Rows.Count > 0)
                    {
                        string sql_update = string.Format("update tbl_NhanVienDiaChi set isactive = 0 where id <> {0} and loaidiachi = {1} and manhanvien = '{2}'",
                            id, model.Loai_dichi_value, model.Ma_nhan_vien);
                        SQLHelper.ExecuteSql(sql_update);
                    }
                }
            }
            catch (Exception ex)
            {
                RJMessageBox.Show(ex.Message, "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void update_data()
        {
            try
            {
                string sql = string.Format("update tbl_NhanVienDiaChi set isactive = {1},id_quocgia = {2},id_tinh = {3},id_huyen = {4}," +
                    "id_xa = {5},thontosonha = N'{6}', diachi = N'{7}', diachifull = N'{8}',ngaycapnhat = GETDATE() " +
                    "where id = {0}", model.Id_diachi_value,
                    model.Active_value, model.Quocgia_value, model.Tinh_value, model.Huyen_value,
                    model.Xa_value, model.Thon_to_value, model.Dia_chi_value, model.Dia_chi_full_value);
                if (SQLHelper.ExecuteSql(sql) == 1)
                {
                    RJMessageBox.Show("Thêm thành công", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    check_active(model.Id_diachi_value);
                    load_data();
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
                string sql = string.Format("insert into tbl_NhanVienDiaChi(manhanvien,isactive,loaidiachi,id_quocgia,id_tinh," +
                            "id_huyen,id_xa,thontosonha,diachi,diachifull) " +
                            "values('{0}',{1},{2},{3},{4},{5},{6},N'{7}',N'{8}',N'{9}')",
                            model.Ma_nhan_vien, model.Active_value, model.Loai_dichi_value, model.Quocgia_value, model.Tinh_value,
                            model.Huyen_value, model.Xa_value, model.Thon_to_value, model.Dia_chi_value, model.Dia_chi_full_value);
                int id_new = SQLHelper.ExecuteScalarSql(sql);
                if (id_new != 0)
                {
                    RJMessageBox.Show("Thêm thành công", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    check_active(id_new);
                    load_data();
                }
            }
            catch (Exception ex)
            {
                RJMessageBox.Show(ex.Message, "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void set_value_text()
        {
            model.Ma_nhan_vien = cbo_nhanvien.SelectedValue.ToString();
            model.Active_value = chk_dang_hieu_luc.Checked == true ? 1 : 0;
            model.Loai_dichi_value = cbo_loai_dia_chi.SelectedValue.ToString();
            model.Quocgia_value = cbo_quoc_gia.SelectedValue.ToString();
            model.Tinh_value = cbo_tinh.SelectedValue.ToString();
            model.Huyen_value = cbo_quan.SelectedValue.ToString();
            model.Xa_value = cbo_phuong.SelectedValue.ToString();
            model.Thon_to_value = txt_so_nha.Text;
            model.Dia_chi_value = cbo_phuong.Text.ToString() + ", " + cbo_quan.Text.ToString() + ", " + cbo_tinh.Text.ToString() + ", " + cbo_quoc_gia.Text.ToString();
            model.Dia_chi_full_value = (string.IsNullOrEmpty(model.Thon_to_value) ? "" : model.Thon_to_value + ", ") + cbo_phuong.Text.ToString() + ", " + cbo_quan.Text.ToString() + ", " + cbo_tinh.Text.ToString() + ", " + cbo_quoc_gia.Text.ToString();
        }
        public void load_data()
        {
            string sql = string.Format("select c.manhanvien,c.TenNhanVien,c.TenNhanVien,a.id,b.typename,a.diachi,a.isactive " +
                "from tbl_NhanVienDiaChi a " +
                "join sys_alltype b on a.loaidiachi = b.typeid " +
                "join MITACOSQL.dbo.NHANVIEN c on c.manhanvien = a.manhanvien ");
            //"where a.ma_nhan_vien = '{0}'", cbo_nhanvien.SelectedValue.ToString());
            DataTable dataTable = new DataTable();
            dataTable = SQLHelper.ExecuteDt(sql);
            dgv_nhanvien_diachi.DataSource = dataTable;
        }

        private void dgv_nhanvien_diachi_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dgv_nhanvien_diachi.CurrentCell.OwningColumn.Name == "edit_column")
            {
                cbo_nhanvien.Enabled = false;
                btn_save.Text = "Cập nhật";
                cbo_loai_dia_chi.Enabled = false;
                model.Id_diachi_value = int.Parse(dgv_nhanvien_diachi.CurrentRow.Cells["id"].Value.ToString());
                edit = true;
                string sql = string.Format("select * from tbl_NhanVienDiaChi where id = {0}", model.Id_diachi_value);
                DataTable dataTable = new DataTable();
                dataTable = SQLHelper.ExecuteDt(sql);
                cbo_nhanvien.SelectedValue = dataTable.Rows[0]["manhanvien"].ToString();
                cbo_loai_dia_chi.SelectedValue = dataTable.Rows[0]["loaidiachi"].ToString();
                cbo_quoc_gia.SelectedValue = dataTable.Rows[0]["id_quocgia"].ToString();
                cbo_tinh.SelectedValue = dataTable.Rows[0]["id_tinh"].ToString();
                cbo_quan.SelectedValue = dataTable.Rows[0]["id_huyen"].ToString();
                cbo_phuong.SelectedValue = dataTable.Rows[0]["id_xa"].ToString();
                txt_so_nha.Text = dataTable.Rows[0]["thontosonha"].ToString();
                chk_dang_hieu_luc.Checked = (dataTable.Rows[0]["isactive"].ToString() == "False" ? false : true);
                pl_address.Enabled = true;
            }
        }

        private void btn_cancel_Click(object sender, EventArgs e)
        {
            pl_address.Enabled = false;
        }

        private void cbo_nhanvien_SelectedValueChanged(object sender, EventArgs e)
        {
            //DataRowView vrow = (DataRowView)cbo_nhanvien.SelectedItem;
            //string row = vrow.Row.ItemArray[0].ToString();
            //if (row != "0")
            //{
            //    string sql = string.Format("select c.ma_nhan_vien,c.ho_lot,c.ten,a.id_dia_chi,b.type_name,a.dia_chi,a.is_active " +
            //                            "from hrm_nhanvien_diachi a " +
            //                            "join sys_all_type b on a.loai_dia_chi = b.type_id " +
            //                            "join hrm_nhan_vien c on c.ma_nhan_vien = a.ma_nhan_vien " +
            //                            "where a.ma_nhan_vien = '{0}'", row);
            //    DataTable dataTable = new DataTable();
            //    dataTable = SQLHelper.ExecuteDt(sql);
            //    dgv_nhanvien_diachi.DataSource = dataTable;
            //}
        }
    }
}
