using ComponentFactory.Krypton.Toolkit;
using System;
using System.Data;
using System.Globalization;
using System.Windows.Forms;
using TENTAC_HRM.Custom;
using TENTAC_HRM.Forms.Main;
using TENTAC_HRM.Forms.NhanSu;

namespace TENTAC_HRM.Forms.Category
{
    public partial class frm_staff_allowance : KryptonForm
    {
        string _GhiChu, _NguoiTao, _NguoiCapNhat;
        int _LoaiPhuCap, _Active;
        decimal? _MucPhuCap;
        DateTime? _TuNgay, _DenNgay;
        public bool edit { get; set; }
        public string _MaNhanVien { get; set; }
        public int _IdPhuCap { get; set; }
        DataProvider provider = new DataProvider();
        frm_personnel frm_personnel;
        public frm_staff_allowance(frm_personnel personnel)
        {
            InitializeComponent();
            frm_personnel = personnel;
        }
        private void Textbox_KeyPress(object sender, KeyPressEventArgs e)
        {
            event_keypress(e);
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
        private void txt_MucPhuCap_Leave(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(txt_MucPhuCap.Text))
            {
                txt_MucPhuCap.Text = decimal.Parse(txt_MucPhuCap.Text).ToString("N0", CultureInfo.InvariantCulture);
            }
        }
        private void frm_allowance_Load(object sender, EventArgs e)
        {
            LoadComboboxNhanVien();
            LoadComboboxLoaiPhuCap();
            if (edit == true)
            {
                LoadData();
            }
            else
            {
                LoadNull();
            }
        }
        private void LoadData()
        {
            string sql = string.Empty;
            sql = $@"Select IsActive, Id_LoaiPhuCap, TuNgay, DenNgay,FORMAT(MucPhuCap,'N0') as MucPhuCap, GhiChu, del_flg from tbl_NhanVienPhuCap 
            where Id = {SQLHelper.rpI(_IdPhuCap)} and del_flg = 0";
            DataTable dt = new DataTable();
            dt = SQLHelper.ExecuteDt(sql);
            if (dt.Rows.Count > 0)
            {
                cbo_LoaiPhuCap.SelectedValue = dt.Rows[0]["Id_LoaiPhuCap"].ToString();
                txt_MucPhuCap.Text = dt.Rows[0]["MucPhuCap"].ToString();
                dtp_TuNgay.Text = dt.Rows[0]["TuNgay"].ToString();
                dtp_DenNgay.Text = dt.Rows[0]["DenNgay"].ToString();
                txt_GhiChu.Text = dt.Rows[0]["GhiChu"].ToString();
                chk_HieuLuc.Checked = bool.Parse(dt.Rows[0]["IsActive"].ToString());
            }
        }
        private void LoadNull()
        {
            cbo_LoaiPhuCap.SelectedIndex = 0;
            chk_HieuLuc.Checked = false;
            txt_MucPhuCap.Text = string.Empty;
            dtp_TuNgay.Text = string.Empty;
            dtp_DenNgay.Text = string.Empty;
            txt_GhiChu.Text = string.Empty;
        }
        private void LoadComboboxNhanVien()
        {
            cbo_NhanVien.DataSource = provider.load_nhanvien();
            cbo_NhanVien.DisplayMember = "name";
            cbo_NhanVien.ValueMember = "value";
            cbo_NhanVien.SelectedValue = _MaNhanVien;
        }
        private void LoadComboboxLoaiPhuCap()
        {
            cbo_LoaiPhuCap.DataSource = provider.load_loaiphucap();
            cbo_LoaiPhuCap.DisplayMember = "TenLoaiPhuCap";
            cbo_LoaiPhuCap.ValueMember = "Id";
        }
        private void btn_close_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        private void frm_allowance_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
            {
                this.Close();
            }
        }
        private void SetValues()
        {
            _MaNhanVien = cbo_NhanVien.SelectedValue.ToString();
            _LoaiPhuCap = int.Parse(cbo_LoaiPhuCap.SelectedValue.ToString());
            _MucPhuCap = string.IsNullOrEmpty(txt_MucPhuCap.Text.Trim()) ? (decimal?)null : decimal.Parse(txt_MucPhuCap.Text.Trim());
            _TuNgay = string.IsNullOrEmpty(dtp_TuNgay.Text) ? (DateTime?)null : DateTime.Parse(dtp_TuNgay.Text.ToString());
            _DenNgay = string.IsNullOrEmpty(dtp_DenNgay.Text) ? (DateTime?)null : DateTime.Parse(dtp_DenNgay.Text.ToString());
            _Active = chk_HieuLuc.Checked == true ? 1 : 0;
            _GhiChu = txt_GhiChu.Text.Trim().ToString();
            _NguoiTao = SQLHelper.sUser;
            _NguoiCapNhat = SQLHelper.sUser;
        }
        private void InsertData()
        {
            try
            {
                string sql = string.Empty;
                sql = $@"Insert into tbl_NhanVienPhuCap(MaNhanVien, IsActive, Id_LoaiPhuCap, TuNgay, DenNgay, MucPhuCap, GhiChu, NgayTao, 
                NguoiTao, del_flg)
                Values({SQLHelper.rpStr(_MaNhanVien)}, {SQLHelper.rpI(_Active)}, {SQLHelper.rpI(_LoaiPhuCap)}, {SQLHelper.rpDT(_TuNgay)},
                {SQLHelper.rpDT(_DenNgay)}, {SQLHelper.rpD(_MucPhuCap)}, {SQLHelper.rpStr(_GhiChu)}, '{DateTime.Now}', {SQLHelper.rpStr(_NguoiTao)}, 0)";
                int IDPhuCapNew = SQLHelper.ExecuteScalarSql(sql);
                if(IDPhuCapNew > 0)
                {
                    RJMessageBox.Show("Thêm thông tin thất bại.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                else
                {
                    if (chk_HieuLuc.Checked == true)
                    {
                        string sql_check = $@"select * from tbl_NhanVienPhuCap where Id_LoaiPhuCap = {SQLHelper.rpI(_LoaiPhuCap)} 
                        and MaNhanVien = {SQLHelper.rpStr(_MaNhanVien)} and Id <> {SQLHelper.rpI(IDPhuCapNew)} and del_flg = 0";
                        DataTable dt = SQLHelper.ExecuteDt(sql_check);
                        if (dt.Rows.Count > 0)
                        {
                            string update_sql = $@"update tbl_NhanVienPhuCap set IsActive = 0 where Id_LoaiPhuCap = {SQLHelper.rpI(_LoaiPhuCap)} 
                            and MaNhanVien = {SQLHelper.rpStr(_MaNhanVien)} and Id <> {SQLHelper.rpI(IDPhuCapNew)} and del_flg = 0";
                            SQLHelper.ExecuteSql(update_sql);
                        }
                    }
                    RJMessageBox.Show("Thêm thông tin thành công.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (Exception ex)
            {
                RJMessageBox.Show(ex.Message, "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        public void UpdateData()
        {
            try
            {
                string sql = string.Empty;
                sql = $@"Update tbl_NhanVienPhuCap Set IsActive = {SQLHelper.rpI(_Active)}, Id_LoaiPhuCap = {SQLHelper.rpI(_LoaiPhuCap)},
                TuNgay = {SQLHelper.rpDT(_TuNgay)}, DenNgay = {SQLHelper.rpDT(_DenNgay)}, MucPhuCap = {SQLHelper.rpD(_MucPhuCap)},
                GhiChu = {SQLHelper.rpStr(_GhiChu)}, NgayCapNhat = '{DateTime.Now}', NguoiCapNhat = {SQLHelper.rpStr(_NguoiCapNhat)}
                Where Id = {SQLHelper.rpI(_IdPhuCap)} and del_flg = 0";
                int res = SQLHelper.ExecuteSql(sql);
                if (res > 0)
                {
                    if (chk_HieuLuc.Checked == true)
                    {
                        string sql_check = $@"select * from tbl_NhanVienPhuCap where Id_LoaiPhuCap = {SQLHelper.rpI(_LoaiPhuCap)} 
                        and Id <> {SQLHelper.rpI(_IdPhuCap)} and del_flg = 0 and MaNhanVien = {SQLHelper.rpStr(_MaNhanVien)}";
                        DataTable dt = SQLHelper.ExecuteDt(sql_check);
                        if (dt.Rows.Count > 0)
                        {
                            string update_sql = $@"update tbl_NhanVienPhuCap set IsActive = 0 where Id_LoaiPhuCap = {SQLHelper.rpI(_LoaiPhuCap)} 
                            and Id <> {SQLHelper.rpI(_IdPhuCap)} and del_flg = 0 and MaNhanVien = {SQLHelper.rpStr(_MaNhanVien)}";
                            SQLHelper.ExecuteSql(update_sql);
                        }
                    }
                    RJMessageBox.Show("Cập nhật thông tin thành công.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
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
            LoadNull();
            frm_personnel.LoadNhanVienPhuCap();
        }
    }
}