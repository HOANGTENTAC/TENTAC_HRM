using ComponentFactory.Krypton.Toolkit;
using System;
using System.Data;
using System.Globalization;
using System.Windows.Forms;
using TENTAC_HRM.Consts;
using TENTAC_HRM.Custom;
using TENTAC_HRM.Forms.NhanSu;

namespace TENTAC_HRM.Forms.Category
{
    public partial class frm_wage : KryptonForm
    {
        string _ThueTNCN, _GhiChu;
        int active_value, _DongBHXH, _DongBHYT, _DongBHTN, _MienThue, _ThueCoDinh, _CongDoan, _IDLuong;
        decimal _MucLuong, _LuongBHXH;
        DateTime? _TuNgay, _DenNgay;
        public bool edit { get; set; }
        public string _MaNhanVien { get; set; }
        private void txt_mucluong_Leave(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(txt_MucLuong.Text))
            {
                txt_MucLuong.Text = decimal.Parse(txt_MucLuong.Text).ToString("N0", CultureInfo.InvariantCulture);
            }
        }

        DataProvider provider = new DataProvider();

        private void btn_delete_Click(object sender, EventArgs e)
        {
            try
            {
                DialogResult d = RJMessageBox.Show("Bạn có chắc muốn xóa", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Information);
                if (d == DialogResult.Yes)
                {
                    string sql = string.Format("update hrm_nhavien_luong set del_flg = 1 where id_luong = '{0}'", dgv_Luong.CurrentRow.Cells["id_luong"].Value);
                    if (SQLHelper.ExecuteSql(sql) == 1)
                    {
                        RJMessageBox.Show("Xóa dữ liệu thành công", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
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
            LoadComboboxNhanVien();
            LoadData();
        }
        private void LoadData()
        {
            string sql = string.Format("select Id, TuNgay, DenNgay,FORMAT(MucLuong,'N0') as MucLuong, IsActive, PT_ThueTNCN from tbl_NhanVienLuong where MaNhanVien = '{0}'", cbo_NhanVien.SelectedValue.ToString());
            DataTable dt = new DataTable();
            dt = SQLHelper.ExecuteDt(sql);
            dgv_Luong.DataSource = dt;
        }
        private void event_keypress(KeyPressEventArgs e)
        {
            if (!provider.IsValidNumber(e.KeyChar))
            {
                e.Handled = true;
                return;
            }
            base.OnKeyPress(e);
        }
        private void LoadComboboxNhanVien()
        {
            cbo_NhanVien.DataSource = provider.load_nhanvien();
            cbo_NhanVien.DisplayMember = "name";
            cbo_NhanVien.ValueMember = "value";
            cbo_NhanVien.SelectedValue = _MaNhanVien;
        }
        private void LoadNull()
        {
            edit = false;
            txt_MucLuong.Text = string.Empty;
            chk_HieuLuc.Checked = false;
            chk_BHXH.Checked = false;
            chk_BHYT.Checked = false;
            chk_BHTN.Checked = false;
            chk_PhiCD.Checked = false;
            chk_MienThue.Checked = false;
            chk_ThueTheoThuNhapCD.Checked = false;
            txt_PhiThuNhapCaNhan.Text = string.Empty;
            txt_GhiChu.Text = string.Empty;
            dtp_TuNgay.Text = string.Empty;
            dtp_DenNgay.Text = string.Empty;
        }
        private void btn_save_Click(object sender, EventArgs e)
        {
            SetValues();
            if (edit == true)
            {
                UpdateData();
            }
            else
            {
                InsertData();
            }
            LoadData();
            personnel.LoadNhanVienLuong();
            LoadNull();
        }
        private void SetValues()
        {
            _MaNhanVien = cbo_NhanVien.SelectedValue.ToString();
            active_value = chk_HieuLuc.Checked == true ? 1 : 0;
            _TuNgay = string.IsNullOrEmpty(dtp_TuNgay.Text) ? (DateTime?)null : DateTime.Parse(dtp_TuNgay.Text);
            _DenNgay = string.IsNullOrEmpty(dtp_DenNgay.Text) ? (DateTime?)null : DateTime.Parse(dtp_DenNgay.Text);
            _MucLuong = decimal.Parse(txt_MucLuong.Text.ToString());
            _LuongBHXH = 0;
            _DongBHXH = chk_BHXH.Checked == true ? 1 : 0;
            _DongBHYT = chk_BHYT.Checked == true ? 1 : 0;
            _DongBHTN = chk_BHTN.Checked == true ? 1 : 0;
            _MienThue = chk_MienThue.Checked == true ? 1 : 0;
            _ThueCoDinh = chk_ThueTheoThuNhapCD.Checked == true ? 1 : 0;
            _ThueTNCN = txt_PhiThuNhapCaNhan.Text.ToString();
            _GhiChu = txt_GhiChu.Text.ToString();
            _CongDoan = chk_PhiCD.Checked == true ? 1 : 0;
        }
        private void UpdateData()
        {
            try
            {
                string sql = string.Empty;
                sql = $@"Update tbl_NhanVienLuong Set IsActive = {SQLHelper.rpI(active_value)}, TuNgay = {SQLHelper.rpDT(_TuNgay)},
                DenNgay = {SQLHelper.rpDT(_DenNgay)}, MucLuong = {SQLHelper.rpD(_MucLuong)}, Is_DongBHXH = {SQLHelper.rpI(_DongBHXH)},
                Is_DongBHYT = {SQLHelper.rpI(_DongBHYT)}, Is_DongBHTN = {SQLHelper.rpI(_DongBHTN)}, Is_MienThue = {SQLHelper.rpI(_MienThue)},
                Is_ThueCoDinh = {SQLHelper.rpI(_ThueCoDinh)}, PT_ThueTNCN = {SQLHelper.rpStr(_ThueTNCN)}, GhiChu = {SQLHelper.rpStr(_GhiChu)},
                Is_DongKPCD = {SQLHelper.rpI(_CongDoan)}, NgayCapNhat = '{DateTime.Now}', NguoiCapNhat = {SQLHelper.rpStr(LoginInfo.UserCd)}
                Where ID = {SQLHelper.rpI(Convert.ToInt32(_IDLuong))}";

                if (SQLHelper.ExecuteSql(sql) > 0)
                {
                    if (chk_HieuLuc.Checked == true)
                    {
                        string sql_check = $@"select * from tbl_NhanVienLuong where MaNhanVien = {SQLHelper.rpStr(_MaNhanVien)} and Id <> {SQLHelper.rpI(_IDLuong)} and del_flg = 0";
                        DataTable dt = SQLHelper.ExecuteDt(sql_check);
                        if (dt.Rows.Count > 0)
                        {
                            string update_sql = $@"update tbl_NhanVienLuong set IsActive = 0 where MaNhanVien = {SQLHelper.rpStr(_MaNhanVien)} and Id <> {SQLHelper.rpI(_IDLuong)} and del_flg = 0";
                            SQLHelper.ExecuteSql(update_sql);
                        }
                    }
                    RJMessageBox.Show("Cập nhật thông tin thành công", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    RJMessageBox.Show("Cập nhật thông tin thất bại.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
            }
            catch (Exception ex)
            {
                RJMessageBox.Show(ex.Message, "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void InsertData()
        {
            try
            {
                string sql = string.Empty;
                sql = $@"Insert into tbl_NhanVienLuong(MaNhanVien, IsActive, TuNgay, DenNgay, MucLuong, LuongBHXH, Is_DongBHXH, 
                Is_DongBHYT, Is_DongBHTN, Is_DongKPCD, Is_MienThue, Is_ThueCoDinh, PT_ThueTNCN, GhiChu, NgayTao, NguoiTao, del_flg)
                Values ({SQLHelper.rpStr(_MaNhanVien)}, {SQLHelper.rpI(active_value)}, {SQLHelper.rpDT(_TuNgay)}, {SQLHelper.rpDT(_DenNgay)},
                {SQLHelper.rpD(_MucLuong)}, {SQLHelper.rpD(_LuongBHXH)}, {SQLHelper.rpI(_DongBHXH)}, {SQLHelper.rpI(_DongBHYT)},
                {SQLHelper.rpI(_DongBHTN)}, {SQLHelper.rpI(_CongDoan)}, {SQLHelper.rpI(_MienThue)}, {SQLHelper.rpI(_ThueCoDinh)},
                {SQLHelper.rpStr(_ThueTNCN)}, {SQLHelper.rpStr(_GhiChu)}, '{DateTime.Now}', {SQLHelper.rpStr(LoginInfo.UserCd)}, 0)";

                int IDNew = SQLHelper.ExecuteScalarSql(sql);
                if (IDNew != 0)
                {
                    if (chk_HieuLuc.Checked == true)
                    {
                        string sql_check = $@"select * from tbl_NhanVienLuong where MaNhanVien = {SQLHelper.rpStr(_MaNhanVien)} and Id <> {SQLHelper.rpI(IDNew)} and del_flg = 0";
                        DataTable dt = SQLHelper.ExecuteDt(sql_check);
                        if (dt.Rows.Count > 0)
                        {
                            string update_sql = $@"update tbl_NhanVienLuong set IsActive = 0 where MaNhanVien = {SQLHelper.rpStr(_MaNhanVien)} and Id <> {SQLHelper.rpI(IDNew)} and del_flg = 0";
                            SQLHelper.ExecuteSql(update_sql);
                        }
                    }
                    RJMessageBox.Show("Thêm thông tin thành công", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    RJMessageBox.Show("Thêm thông tin thất bại.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
            }
            catch (Exception ex)
            {
                RJMessageBox.Show(ex.Message, "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void btn_clear_Click(object sender, EventArgs e)
        {
            LoadNull();
        }
        private void btn_close_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btn_add_Click(object sender, EventArgs e)
        {
            //edit = false;
            //btn_save.Text = "Thêm";
            //gb_nhanvien.Enabled = true;
            //gb_thongtin.Enabled = true;
            //txt_mucluong.Text = "";
            //chk_bhxh.Checked = false;
            //chk_bhyt.Checked = false;
            //chk_bhtn.Checked = false;
            //chk_cd.Checked = false;
            //chk_miendongthue.Checked = false;
            //chk_tinhthuetheo_pt_codinh.Checked = false;
            //txt_thue.Text = "";
            //txt_ghichu.Text = "";
            //chk_active.Checked = false;
            //dtp_tungay.Text = DateTime.Now.ToString();
            //dtp_denngay.Text = DateTime.Now.ToString();
        }

        private void dgv_luong_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dgv_Luong.CurrentCell.OwningColumn.Name == "edit_column")
            {
                edit = true;
                _IDLuong = int.Parse(dgv_Luong.CurrentRow.Cells["ID"].Value.ToString());
                string sql = string.Format("select * from tbl_NhanVienLuong where ID = {0}", _IDLuong);
                DataTable dataTable = new DataTable();
                dataTable = SQLHelper.ExecuteDt(sql);
                if (dataTable.Rows.Count > 0)
                {
                    txt_MucLuong.Text = decimal.Parse(dataTable.Rows[0]["MucLuong"].ToString()).ToString("N0", CultureInfo.InvariantCulture);
                    chk_BHXH.Checked = dataTable.Rows[0]["Is_DongBHXH"].ToString() == "True" ? true : false;
                    chk_BHYT.Checked = dataTable.Rows[0]["Is_DongBHYT"].ToString() == "True" ? true : false;
                    chk_BHTN.Checked = dataTable.Rows[0]["Is_DongBHTN"].ToString() == "True" ? true : false;
                    chk_PhiCD.Checked = dataTable.Rows[0]["Is_DongKPCD"].ToString() == "True" ? true : false;
                    chk_MienThue.Checked = dataTable.Rows[0]["Is_MienThue"].ToString() == "True" ? true : false;
                    chk_ThueTheoThuNhapCD.Checked = dataTable.Rows[0]["Is_ThueCoDinh"].ToString() == "True" ? true : false;
                    txt_PhiThuNhapCaNhan.Text = dataTable.Rows[0]["PT_ThueTNCN"].ToString();
                    dtp_TuNgay.Text = dataTable.Rows[0]["TuNgay"].ToString();
                    dtp_DenNgay.Text = dataTable.Rows[0]["DenNgay"].ToString();
                    txt_GhiChu.Text = dataTable.Rows[0]["GhiChu"].ToString();
                    chk_HieuLuc.Checked = dataTable.Rows[0]["IsActive"].ToString() == "True" ? true : false;
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
        private void Textbox_KeyPress(object sender, KeyPressEventArgs e)
        {
            event_keypress(e);
        }
    }
}