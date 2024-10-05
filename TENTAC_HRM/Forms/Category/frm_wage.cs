using System;
using System.Data;
using System.Globalization;
using System.Windows.Forms;
using TENTAC_HRM.Custom;

namespace TENTAC_HRM.Category
{
    public partial class frm_wage : Form
    {
        string id_luong_value,thue_tncn_value,ghichu_value,tungay_value,denngay_value,luong_bhxh_value;
        int active_value,dong_bhxh_value,dong_bhyt_value,dong_bhtn_value,mienthue_value,thuecodinh_value,congdoan_value;
        decimal mucluong_value;
        public bool edit { get; set; }
        public string _ma_nhan_vien { get; set; }

        private void txt_mucluong_Leave(object sender, EventArgs e)
        {
            txt_mucluong.Text = decimal.Parse(txt_mucluong.Text).ToString("N2", CultureInfo.InvariantCulture);
        }

        DataProvider provider = new DataProvider();

        private void btn_delete_Click(object sender, EventArgs e)
        {
            try
            {
                DialogResult d = RJMessageBox.Show("Bạn có chắc muốn xóa", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Information);
                if (d == DialogResult.Yes)
                {
                    string sql = string.Format("update hrm_nhavien_luong set del_flg = 1 where id_luong = '{0}'", dgv_luong.CurrentRow.Cells["id_luong"].Value);
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

        frm_personnel personnel;
        public frm_wage(frm_personnel _frm)
        {
            InitializeComponent();
            personnel = _frm;
        }

        private void frm_wage_Load(object sender, EventArgs e)
        {
            load_nhanvien();
            Load_data();
        }

        private void Load_data()
        {
            string sql = string.Format("select id_luong,tu_ngay,den_ngay,FORMAT(muc_luong,'N2') as muc_luong,is_active from hrm_nhavien_luong where ma_nhan_vien = '{0}'", cbo_nhanvien.SelectedValue.ToString());
            DataTable dt = new DataTable();
            dt = SQLHelper.ExecuteDt(sql);
            dgv_luong.DataSource = dt;
        }

        private void load_nhanvien()
        {
            cbo_nhanvien.DataSource = provider.load_nhanvien();
            cbo_nhanvien.DisplayMember = "name";
            cbo_nhanvien.ValueMember = "value";
            cbo_nhanvien.SelectedValue = _ma_nhan_vien;
        }

        private void btn_save_Click(object sender, EventArgs e)
        {
            try
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
            catch (Exception ex)
            {
                RJMessageBox.Show(ex.Message, "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void set_value_text()
        {
            _ma_nhan_vien = cbo_nhanvien.SelectedValue.ToString();
            active_value = chk_active.Checked == true ? 1 : 0;
            tungay_value = DateTime.Parse(dtp_tungay.Text.ToString()).ToString("yyyy/MM/dd");
            denngay_value = DateTime.Parse(dtp_denngay.Text.ToString()).ToString("yyyy/MM/dd");
            mucluong_value = decimal.Parse(txt_mucluong.Text.ToString());
            luong_bhxh_value = "0";
            dong_bhxh_value = chk_bhxh.Checked == true ? 1 : 0;
            dong_bhyt_value = chk_bhyt.Checked == true ? 1 : 0;
            dong_bhtn_value = chk_bhtn.Checked == true ? 1 : 0;
            mienthue_value = chk_miendongthue.Checked == true ? 1 : 0;
            thuecodinh_value = chk_tinhthuetheo_pt_codinh.Checked == true ? 1 : 0;
            thue_tncn_value = txt_thue.Text.ToString();
            ghichu_value = txt_ghichu.Text.ToString();
            congdoan_value = chk_cd.Checked == true ? 1 : 0;
        }
        private void update_data()
        {
            try
            {
                string sql = string.Format("update hrm_nhavien_luong set is_active = {1},tu_ngay = '{2}',den_ngay = '{3}', muc_luong = '{4}'," +
                    "luong_bhxh = '{5}',is_dong_bhxh = {6},is_dong_bhyt = {7},is_dong_bhtn = {8}, is_mien_thue = {9}," +
                    "is_thue_co_dinh = {10},pt_thue_tncn = '{11}',ghi_chu = N'{12}',is_dong_kpcd = {13},ngay_cap_nhat = GETDATE() " +
                    "where id_luong = {0}", id_luong_value,
                    active_value, tungay_value, denngay_value, mucluong_value,
                    luong_bhxh_value, dong_bhxh_value, dong_bhyt_value, dong_bhtn_value, mienthue_value,
                    thuecodinh_value, thue_tncn_value, ghichu_value, congdoan_value);
                if (SQLHelper.ExecuteSql(sql) == 1)
                {
                    RJMessageBox.Show("Thêm thành công", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    Load_data();
                    personnel.load_luong();
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
                string sql = string.Format("insert into hrm_nhavien_luong(ma_nhan_vien,is_active,tu_ngay,den_ngay,muc_luong,luong_bhxh," +
                "is_dong_bhxh,is_dong_bhyt,is_dong_bhtn,is_mien_thue,is_thue_co_dinh,pt_thue_tncn,ghi_chu,is_dong_kpcd,id_nguoi_tao) " +
                "values('{0}',{1},'{2}','{3}','{4}','{5}'," +
                "{6},{7},{8},{9},{10},'{11}',N'{12}',{13},'{14}')",
                _ma_nhan_vien, active_value, tungay_value, denngay_value, mucluong_value, luong_bhxh_value,
                dong_bhxh_value, dong_bhyt_value, dong_bhtn_value, mienthue_value, thuecodinh_value, thue_tncn_value, ghichu_value, congdoan_value, SQLHelper.sIdUser);
                if (SQLHelper.ExecuteSql(sql) == 1)
                {
                    RJMessageBox.Show("Thêm thành công", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    Load_data();
                    personnel.load_luong();
                }
            }
            catch (Exception ex)
            {
                RJMessageBox.Show(ex.Message, "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void btn_close_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btn_add_Click(object sender, EventArgs e)
        {
            edit = false;
            btn_save.Text = "Thêm";
            gb_nhanvien.Enabled = true;
            gb_thongtin.Enabled = true;
            txt_mucluong.Text = "";
            chk_bhxh.Checked = false;
            chk_bhyt.Checked = false;
            chk_bhtn.Checked = false;
            chk_cd.Checked = false;
            chk_miendongthue.Checked = false;
            chk_tinhthuetheo_pt_codinh.Checked = false;
            txt_thue.Text = "";
            txt_ghichu.Text = "";
            chk_active.Checked = false;
            dtp_tungay.Text = DateTime.Now.ToString();
            dtp_denngay.Text = DateTime.Now.ToString();
        }

        private void dgv_luong_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dgv_luong.CurrentCell.OwningColumn.Name == "edit_column")
            {
                edit = true;
                btn_save.Text = "Cập nhật";
                id_luong_value = dgv_luong.CurrentRow.Cells["id_luong"].Value.ToString();
                gb_nhanvien.Enabled = true;
                gb_thongtin.Enabled = true;
                string sql = string.Format("select * from hrm_nhavien_luong where id_luong = {0}", id_luong_value);
                DataTable dataTable = new DataTable();
                dataTable = SQLHelper.ExecuteDt(sql);
                if (dataTable.Rows.Count > 0)
                {
                    txt_mucluong.Text = decimal.Parse(dataTable.Rows[0]["muc_luong"].ToString()).ToString("N2", CultureInfo.InvariantCulture);
                    chk_bhxh.Checked = dataTable.Rows[0]["is_dong_bhxh"].ToString() == "True" ? true : false;
                    chk_bhyt.Checked = dataTable.Rows[0]["is_dong_bhyt"].ToString() == "True" ? true : false;
                    chk_bhtn.Checked = dataTable.Rows[0]["is_dong_bhtn"].ToString() == "True" ? true : false;
                    chk_cd.Checked = dataTable.Rows[0]["is_dong_kpcd"].ToString() == "True" ? true : false;
                    chk_miendongthue.Checked = dataTable.Rows[0]["is_mien_thue"].ToString() == "True" ? true : false;
                    chk_tinhthuetheo_pt_codinh.Checked = dataTable.Rows[0]["is_thue_co_dinh"].ToString() == "True" ? true : false;
                    txt_thue.Text = dataTable.Rows[0]["pt_thue_tncn"].ToString();
                    dtp_tungay.Text = dataTable.Rows[0]["tu_ngay"].ToString();
                    dtp_denngay.Text = dataTable.Rows[0]["den_ngay"].ToString();
                    txt_ghichu.Text = dataTable.Rows[0]["ghi_chu"].ToString();
                    chk_active.Checked = dataTable.Rows[0]["is_active"].ToString() == "True" ? true : false;
                }
            }
        }

        private void frm_wage_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
            {
                this.Close();
            }
        }
    }
}
