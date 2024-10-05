using System;
using System.Data;
using System.Linq;
using System.Windows.Forms;
using TENTAC_HRM.Custom;

namespace TENTAC_HRM.Category
{
    public partial class frm_insurance : Form
    {
        string id_ma_nhan_vien;
        int active_value;
        string loaibaohiem_value;
        string sothe_value;
        string tungay_value;
        string denngay_value;
        string tinh_value;
        string noithuchien_value;
        string ghichu_value;
        string nguoitao_value;
        DataProvider provider = new DataProvider();
        public string _ma_nhan_vien { get; set; }
        public string id_baohiem_value { get; set; }
        public bool edit { get; set; } = false;
        frm_personnel personnel;
        public frm_insurance(frm_personnel _personnel)
        {
            InitializeComponent();
            personnel = _personnel;
        }

        private void btn_add_Click(object sender, EventArgs e)
        {
            btn_luu.Text = "Lưu";
            edit = false;
            pl_baohiem.Enabled = true;
            txt_sothe.Text = "";
            txt_noidangky.Text = "";
            txt_ghichu.Text = "";
            chk_active.Checked = false;
            cbo_loaibh.SelectedValue = 0;
            cbo_tinh.SelectedValue = 0;
        }

        private void btn_huy_Click(object sender, EventArgs e)
        {
            pl_baohiem.Enabled = false;
        }

        private void frm_insurance_Load(object sender, EventArgs e)
        {
            load_data();
            load_nhanvien();
            load_loaibaohiem();
            load_tinh();
            cbo_nhanvien.SelectedValue = _ma_nhan_vien;
        }

        private void load_loaibaohiem()
        {
            DataTable dt = new DataTable();
            dt = provider.load_all_type(50);
            cbo_loaibh.DataSource = dt;
            cbo_loaibh.DisplayMember = "name";
            cbo_loaibh.ValueMember = "id";
        }

        private void load_data()
        {
            string sql = string.Format("select a.id_bao_hiem,b.type_name,a.so_the,a.tu_ngay,a.den_ngay,c.ten_dia_chi,a.is_active " +
                "from hrm_nhanvien_baohiem a " +
                "left join sys_all_type b on b.type_id = a.loai_bao_hiem " +
                "left join hrm_dia_chi c on c.id_dia_chi = a.id_tinh and loai_dia_chi = 22 " +
                "where a.ma_nhan_vien = '{0}'", _ma_nhan_vien);
            DataTable dt = new DataTable();
            dt = SQLHelper.ExecuteDt(sql);
            dgv_baohiem.DataSource = dt;
        }
        private void load_nhanvien()
        {
            cbo_nhanvien.DataSource = provider.load_nhanvien();
            cbo_nhanvien.DisplayMember = "name";
            cbo_nhanvien.ValueMember = "value";
        }

        private void load_tinh()
        {
            DataTable dt = new DataTable();
            dt = provider.load_tinh();
            dt.Rows.Add("0", "");
            cbo_tinh.DataSource = dt.Rows.Cast<DataRow>().OrderBy(x => x.Field<int>("id_dia_chi")).CopyToDataTable();
            cbo_tinh.DisplayMember = "ten_dia_chi";
            cbo_tinh.ValueMember = "id_dia_chi";
        }

        private void btn_luu_Click(object sender, EventArgs e)
        {
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
                set_value_text();
                string sql = string.Format("update hrm_nhanvien_baohiem set is_active = {1},loai_bao_hiem = {2},so_the = N'{3}',tu_ngay = '{4}'," +
                    "den_ngay = '{5}',id_tinh = {6},noi_thuc_hien = N'{7}',ghi_chu = N'{8}',ngay_cap_nhat = GETDATE() " +
                    "where id_bao_hiem = {0}", id_baohiem_value,
                    active_value, loaibaohiem_value, sothe_value, tungay_value,
                    denngay_value, tinh_value, noithuchien_value, ghichu_value);
                if (SQLHelper.ExecuteSql(sql) == 1)
                {
                    if (chk_active.Checked == true)
                    {
                        string sql_check = string.Format("select * from hrm_nhanvien_baohiem where is_active = 1 and loai_bao_hiem = {0} and id_bao_hiem <> {1}", loaibaohiem_value, id_baohiem_value);
                        DataTable dt = SQLHelper.ExecuteDt(sql_check);
                        if (dt.Rows.Count > 0)
                        {
                            string update_sql = string.Format("update hrm_nhanvien_baohiem set is_active = 0 where is_active = 1 and loai_bao_hiem = {0} and id_bao_hiem <> {1}", loaibaohiem_value, id_baohiem_value);
                            SQLHelper.ExecuteSql(update_sql);
                        }
                    }
                    RJMessageBox.Show("Cập nhật thành công", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    load_data();
                    personnel.load_baohiem();
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
                set_value_text();
                string sql = string.Format("insert into hrm_nhanvien_baohiem(ma_nhan_vien,is_active,loai_bao_hiem,so_the," +
                    "tu_ngay,den_ngay,id_tinh,noi_thuc_hien,ghi_chu,id_nguoi_tao) " +
                    "values('{0}',{1},{2},'{3}','{4}','{5}',{6},N'{7}',N'{8}','{9}')",
                    id_ma_nhan_vien, active_value, loaibaohiem_value, sothe_value,
                    tungay_value, denngay_value, tinh_value, noithuchien_value, ghichu_value, nguoitao_value);
                int id = SQLHelper.ExecuteScalarSql(sql);
                if (chk_active.Checked == true)
                {
                    string sql_check = string.Format("select * from hrm_nhanvien_baohiem where loai_bao_hiem = {0} and id_bao_hiem <> {1}", loaibaohiem_value, id);
                    DataTable dt = SQLHelper.ExecuteDt(sql_check);
                    if (dt.Rows.Count > 0)
                    {
                        string update_sql = string.Format("update hrm_nhanvien_baohiem set is_active = 0 where loai_bao_hiem = {0} and id_bao_hiem <> {1}", loaibaohiem_value, id);
                        SQLHelper.ExecuteSql(update_sql);
                    }
                }
                RJMessageBox.Show("Thêm thành công", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                load_data();
                personnel.load_baohiem();
            }
            catch (Exception ex)
            {
                RJMessageBox.Show(ex.Message, "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void set_value_text()
        {
            id_ma_nhan_vien = cbo_nhanvien.SelectedValue.ToString();
            active_value = (chk_active.Checked == true ? 1 : 0);
            loaibaohiem_value = cbo_loaibh.SelectedValue.ToString();
            sothe_value = txt_sothe.Text;
            tungay_value = DateTime.Parse(dtp_tungay.Text.ToString()).ToString("yyyy/MM/dd");
            denngay_value = DateTime.Parse(dtp_denngay.Text).ToString("yyyy/MM/dd");
            tinh_value = cbo_tinh.SelectedValue.ToString().ToString();
            noithuchien_value = txt_noidangky.Text;
            ghichu_value = txt_ghichu.Text;
            nguoitao_value = SQLHelper.sIdUser;
        }

        private void btn_close_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void dgv_baohiem_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dgv_baohiem.CurrentCell.OwningColumn.Name == "edit_column")
            {
                id_baohiem_value = dgv_baohiem.CurrentRow.Cells["id_bao_hiem"].Value.ToString();
                btn_luu.Text = "Cập nhật";
                edit = true;
                pl_baohiem.Enabled = true;
                string sql = string.Format("select loai_bao_hiem,so_the,tu_ngay,den_ngay,id_tinh,noi_thuc_hien,ghi_chu,is_active from hrm_nhanvien_baohiem where id_bao_hiem = {0}", dgv_baohiem.Rows[dgv_baohiem.CurrentRow.Index].Cells["id_bao_hiem"].Value.ToString());
                DataTable dt = new DataTable();
                dt = SQLHelper.ExecuteDt(sql);
                cbo_loaibh.SelectedValue = dt.Rows[0]["loai_bao_hiem"].ToString();
                txt_sothe.Text = dt.Rows[0]["so_the"].ToString();
                dtp_tungay.Text = dt.Rows[0]["tu_ngay"].ToString();
                dtp_denngay.Text = dt.Rows[0]["den_ngay"].ToString();
                cbo_tinh.SelectedValue = dt.Rows[0]["id_tinh"].ToString();
                txt_noidangky.Text = dt.Rows[0]["noi_thuc_hien"].ToString();
                txt_ghichu.Text = dt.Rows[0]["ghi_chu"].ToString();
                chk_active.Checked = (dt.Rows[0]["is_active"].ToString() == "False" ? false : true);
            }
        }

        private void frm_insurance_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
            {
                this.Close();
            }
        }

        private void btn_delete_Click(object sender, EventArgs e)
        {
            try
            {
                DialogResult result = RJMessageBox.Show("Bạn có chác muốn xóa?", "Thông báo", MessageBoxButtons.YesNo);
                if (result == DialogResult.Yes)
                {
                    string sql = string.Format("update hrm_nhanvien_baohiem set del_flg = 1 where id_bao_hiem = '{0}'", dgv_baohiem.CurrentRow.Cells["id_bao_hiem"].Value);
                    if (SQLHelper.ExecuteSql(sql) == 1)
                    {
                        RJMessageBox.Show("Xóa thành công", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
            }
            catch (Exception ex)
            {
                RJMessageBox.Show(ex.Message, "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
