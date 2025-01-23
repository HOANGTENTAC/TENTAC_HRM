using ComponentFactory.Krypton.Toolkit;
using System;
using System.Data;
using System.Globalization;
using System.Windows.Forms;
using TENTAC_HRM.Consts;
using TENTAC_HRM.Custom;
using TENTAC_HRM.Forms.NhanSu;
using TENTAC_HRM.Forms.User_control;

namespace TENTAC_HRM.Forms.Category
{
    public partial class frm_khenthuong : KryptonForm
    {
        public bool edit { get; set; }
        public string _MaNhanVien { get; set; }
        public int _IdKhenThuong { get; set; }
        DataProvider provider = new DataProvider();
        //Khenthuong_model model = new Khenthuong_model();
        frm_personnel _Personnel;
        uc_quatrinh_lamviec _quatrinh;
        string _SoQuyetDinh, _NoiDung, _LyDo, _NguoiKy, _NguoiTao, _NguoiCapNhat;
        DateTime? _NgayKhenThuong;
        decimal? _SoTien;
        int _Cap, _HinhThuc;
        public frm_khenthuong(Form form, UserControl user)
        {
            InitializeComponent();
            _quatrinh = (uc_quatrinh_lamviec)user;
            _Personnel = (frm_personnel)form;
        }
        private void btn_cancel_Click(object sender, EventArgs e)
        {
            this.Close();
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
            _quatrinh.LoadQTKhenThuong();
            LoadNull();
        }
        private void LoadNull()
        {
            txt_SoQuyetDinh.Text = string.Empty;
            dtp_NgayKhenThuong.Text = string.Empty;
            cbo_HinhThuc.SelectedValue = "0";
            cbo_Cap.SelectedValue = "0";
            txt_LyDo.Text = string.Empty;
            txt_SoTien.Text = string.Empty;
            cbo_NguoiKy.SelectedValue = "0";
            txt_NoiDung.Text = string.Empty;
        }
        private void frm_khenthuong_Load(object sender, EventArgs e)
        {
            LoadComboboxNhanVien();
            LoadComboboxHinhThuc();
            LoadComboboxCapKhenThuong();
            LoadComboboxNguoiKy();
            if (edit == true)
            {
                LoadData();
            }
        }
        private void txt_SoTien_Leave(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(txt_SoTien.Text))
            {
                txt_SoTien.Text = decimal.Parse(txt_SoTien.Text).ToString("N0", CultureInfo.InvariantCulture);
            }
        }
        private void LoadData()
        {
            string sql = string.Format("select Id, NgayKhenThuong, SoQuyetDinh, NoiDung, HinhThuc, FORMAT(SoTien,'N0') as SoTien, " +
                "LyDo, MaNhanVienKy, Id_Cap from tbl_QTKhenThuong " +
                "where Id='{0}' and del_flg = 0", _IdKhenThuong);
            DataTable dt = SQLHelper.ExecuteDt(sql);
            if (dt.Rows.Count > 0)
            {
                txt_SoQuyetDinh.Text = dt.Rows[0]["SoQuyetDinh"].ToString();
                dtp_NgayKhenThuong.Text = dt.Rows[0]["NgayKhenThuong"].ToString();
                cbo_HinhThuc.SelectedValue = dt.Rows[0]["HinhThuc"];
                cbo_Cap.SelectedValue = dt.Rows[0]["Id_Cap"].ToString();
                txt_LyDo.Text = dt.Rows[0]["LyDo"].ToString();
                txt_SoTien.Text = dt.Rows[0]["SoTien"].ToString();
                cbo_NguoiKy.SelectedValue = dt.Rows[0]["MaNhanVienKy"].ToString();
                txt_NoiDung.Text = dt.Rows[0]["NoiDung"].ToString();
            }
        }
        private void LoadComboboxNhanVien()
        {
            cbo_NhanVien.DataSource = provider.load_nhanvien();
            cbo_NhanVien.DisplayMember = "name";
            cbo_NhanVien.ValueMember = "value";
            cbo_NhanVien.SelectedValue = _MaNhanVien;
        }
        private void LoadComboboxHinhThuc()
        {
            cbo_HinhThuc.DataSource = provider.load_all_type(179);
            cbo_HinhThuc.DisplayMember = "name";
            cbo_HinhThuc.ValueMember = "id";
        }
        private void LoadComboboxNguoiKy()
        {
            cbo_NguoiKy.DataSource = provider.load_nhanvien();
            cbo_NguoiKy.DisplayMember = "name";
            cbo_NguoiKy.ValueMember = "value";
        }
        private void LoadComboboxCapKhenThuong()
        {
            cbo_Cap.DataSource = provider.load_all_type(147);
            cbo_Cap.DisplayMember = "name";
            cbo_Cap.ValueMember = "id";
        }
        private void InsertData()
        {
            try
            {
                string sql = string.Empty;
                sql = $@"Insert into tbl_QTKhenThuong(MaNhanVien, NgayKhenThuong, SoQuyetDinh, NoiDung, HinhThuc, SoTien,
                        LyDo, Id_Cap, MaNhanVienKy, NgayTao, NguoiTao, del_flg)
                        values({SQLHelper.rpStr(_MaNhanVien)}, {SQLHelper.rpDT(_NgayKhenThuong)}, {SQLHelper.rpStr(_SoQuyetDinh)},
                        {SQLHelper.rpStr(_NoiDung)}, {SQLHelper.rpI(_HinhThuc)}, {SQLHelper.rpD(_SoTien)}, {SQLHelper.rpStr(_LyDo)},
                        {SQLHelper.rpI(_Cap)}, {SQLHelper.rpStr(_NguoiKy)}, '{DateTime.Now}', {SQLHelper.rpStr(_NguoiTao)}, 0)";

                if (SQLHelper.ExecuteSql(sql) == 1)
                {
                    RJMessageBox.Show("Thêm thành công", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    LoadNull();
                }
            }
            catch (Exception ex)
            {
                RJMessageBox.Show(ex.Message, "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void UpdateData()
        {
            try
            {
                string sql = string.Empty;
                sql = $@"Update tbl_QTKhenThuong Set NgayKhenThuong = {SQLHelper.rpDT(_NgayKhenThuong)}, SoQuyetDinh = {SQLHelper.rpStr(_SoQuyetDinh)}, 
                    NoiDung = {SQLHelper.rpStr(_NoiDung)}, HinhThuc = {SQLHelper.rpI(_HinhThuc)}, SoTien =  {SQLHelper.rpD(_SoTien)}, 
                    LyDo = {SQLHelper.rpStr(_LyDo)}, Id_Cap = {SQLHelper.rpI(_Cap)}, MaNhanVienKy = {SQLHelper.rpStr(_NguoiKy)}, 
                    NgayCapNhat = '{DateTime.Now}', NguoiCapNhat = {SQLHelper.rpStr(_NguoiCapNhat)}
                    Where Id = {_IdKhenThuong}";
                if (SQLHelper.ExecuteSql(sql) == 1)
                {
                    RJMessageBox.Show("Cập nhật thành công", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    LoadNull();
                }
            }
            catch (Exception ex)
            {
                RJMessageBox.Show(ex.Message, "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
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
        private void SetValues()
        {
            _NgayKhenThuong = string.IsNullOrEmpty(dtp_NgayKhenThuong.Text) ? (DateTime?)null : DateTime.Parse(dtp_NgayKhenThuong.Text);
            _SoQuyetDinh = txt_SoQuyetDinh.Text.Trim();
            _NoiDung = txt_NoiDung.Text.Trim();
            _HinhThuc = Convert.ToInt32(cbo_HinhThuc.SelectedValue);
            _SoTien = string.IsNullOrWhiteSpace(txt_SoTien.Text.Trim()) ? (decimal?)null : Convert.ToDecimal(txt_SoTien.Text.Trim());
            _LyDo = txt_LyDo.Text.Trim();
            _Cap = Convert.ToInt32(cbo_Cap.SelectedValue);
            _NguoiKy = cbo_NguoiKy.SelectedValue.ToString();
            _NguoiTao = LoginInfo.UserCd;
            _NguoiCapNhat = LoginInfo.UserCd;
        }
        private bool validateForm()
        {
            if (string.IsNullOrEmpty(dtp_NgayKhenThuong.Value.ToString()))
            {
                RJMessageBox.Show("Vui lòng chọn ngày khen thưởng.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                dtp_NgayKhenThuong.Focus();
                return false;
            }
            if (cbo_HinhThuc.SelectedIndex == 0)
            {
                RJMessageBox.Show("Vui lòng chọn hình thức khen thưởng.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                cbo_HinhThuc.Focus();
                return false;
            }
            return true;
        }
        private void txt_sotien_KeyPress(object sender, KeyPressEventArgs e)
        {
            event_keypress(e);
        }
    }
}