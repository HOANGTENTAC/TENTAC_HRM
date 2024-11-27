using ComponentFactory.Krypton.Toolkit;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;
using TENTAC_HRM.Custom;
using TENTAC_HRM.Forms.Main;

namespace TENTAC_HRM.Forms.Category
{
    public partial class frm_relatives : KryptonForm
    {
        string _QuanHe, _HoTen, _NamSinh, _NgheNghiep, _NoiCuTru, _GhiChu,
            _MaSoThue, _CCCD, ks_so_value, ks_quyen_value, ks_quocgia_value, ks_tinh_value,
            ks_quan_value, ks_phuong_value, tuthang_value, denthang_value, _NguoiTao, _NguoiCapNhat,
            _DienThoai, _DiDong, _GioiTinh;
        DateTime? ngaysinh_value;
        int quoctich_value;
        private void txt_dien_thoai_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!IsValidNumber(e.KeyChar))
            {
                e.Handled = true;
                return;
            }
        }
        private void btn_save_close_Click(object sender, EventArgs e)
        {
            if (edit == true)
            {
                UpdateData();
            }
            else
            {
                InsertData();
            }
            personnel.LoadNhanVienNguoiThan();
            LoadNull();
            this.Close();
        }
        private void frm_relatives_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
            {
                this.Close();
            }
        }
        private void txt_di_dong_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!IsValidNumber(e.KeyChar))
            {
                e.Handled = true;
                return;
            }
        }
        private void txt_ma_so_thue_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!IsValidNumber(e.KeyChar))
            {
                e.Handled = true;
                return;
            }
        }
        private void txt_cccd_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!IsValidNumber(e.KeyChar))
            {
                e.Handled = true;
                return;
            }
        }
        protected virtual bool IsValidNumber(char c)
        {
            return (c >= '0' && c <= '9') || (c == (char)Keys.Back) || (c == (char)Keys.Delete);
        }
        private void txt_ho_ten_Leave(object sender, EventArgs e)
        {
            txt_ho_ten.Text = provider.viet_hoa_chu_cai_dau(txt_ho_ten.Text);
        }

        int is_phuthuoc_value;
        public string _ma_nhan_vien { get; set; }
        public string id_nguoithan_value { get; set; }
        public bool edit { get; set; }
        DataProvider provider = new DataProvider();
        frm_personnel personnel;
        public frm_relatives(frm_personnel _personnel)
        {
            InitializeComponent();
            this.personnel = _personnel;
        }
        private void LoadNull()
        {
            txt_ho_ten.Text = string.Empty;
            cbo_loai_quan_he.SelectedIndex = 0;
            chk_is_phu_thuoc.Checked = false;
            dtp_NgaySinh.Text = string.Empty;
            cbo_gioi_tinh.SelectedIndex = 0;
            txt_nghe_nghiep.Text = string.Empty;
            txt_dien_thoai.Text = string.Empty;
            txt_di_dong.Text = string.Empty;
            txt_ma_so_thue.Text = string.Empty;
            txt_cccd.Text = string.Empty;
            cbo_QuocTich.SelectedIndex = 0;
            txt_noi_cu_tru.Text = string.Empty;
            txt_ghi_chu.Text = string.Empty;
        }
        private void frm_relatives_Load(object sender, EventArgs e)
        {
            LoadComboboxQuanHe();
            LoadComboboxGioiTinh();
            LoadComboboxNhanVien();
            LoadComboboxQuocTich();
            if (edit == true)
            {
                LoadData();
            }
        }
        private void LoadComboboxNhanVien()
        {
            cbo_NhanVien.DataSource = provider.load_nhanvien();
            cbo_NhanVien.DisplayMember = "name";
            cbo_NhanVien.ValueMember = "value";
            cbo_NhanVien.SelectedValue = _ma_nhan_vien;
        }
        private void LoadData()
        {
            string sql = string.Format("select * from tbl_NhanVienNguoiThan where Id = {0}", id_nguoithan_value);
            DataTable dt = new DataTable();
            dt = SQLHelper.ExecuteDt(sql);
            if (dt.Rows.Count > 0)
            {
                cbo_loai_quan_he.SelectedValue = dt.Rows[0]["LoaiQuanHe"].ToString();
                txt_ho_ten.Text = dt.Rows[0]["HoTen"].ToString();
                dtp_NgaySinh.Text = dt.Rows[0]["NgaySinh"].ToString();
                txt_nghe_nghiep.Text = dt.Rows[0]["NgheNghiep"].ToString();
                txt_noi_cu_tru.Text = dt.Rows[0]["NoiCuTru"].ToString();
                txt_ghi_chu.Text = dt.Rows[0]["GhiChu"].ToString();
                chk_is_phu_thuoc.Checked = bool.Parse(dt.Rows[0]["IsPhuThuoc"].ToString());
                txt_ma_so_thue.Text = dt.Rows[0]["MaSoThue"].ToString();
                txt_cccd.Text = dt.Rows[0]["CCCD"].ToString();
                cbo_QuocTich.SelectedValue = dt.Rows[0]["Id_QuocTich"];
                txt_dien_thoai.Text = dt.Rows[0]["DienThoai"].ToString();
                txt_di_dong.Text = dt.Rows[0]["DiDong"].ToString();
                cbo_gioi_tinh.SelectedValue = (dt.Rows[0]["GioiTinh"].ToString() == "True" ? 1 : 0);
            }
        }
        private void LoadComboboxQuanHe()
        {
            cbo_loai_quan_he.DataSource = provider.load_all_type(80);
            cbo_loai_quan_he.DisplayMember = "name";
            cbo_loai_quan_he.ValueMember = "id";
        }
        private void LoadComboboxGioiTinh()
        {
            cbo_gioi_tinh.DataSource = provider.load_gioitinh();
            cbo_gioi_tinh.DisplayMember = "name";
            cbo_gioi_tinh.ValueMember = "id";

        }
        private void LoadComboboxQuocTich()
        {
            string sql = "select Id, TenDiaChi from mst_DonViHanhChinh where ParentId is null and del_flg = 0";
            DataTable dt = new DataTable();
            dt = SQLHelper.ExecuteDt(sql);
            cbo_QuocTich.DataSource = dt;
            cbo_QuocTich.DisplayMember = "TenDiaChi";
            cbo_QuocTich.ValueMember = "Id";
        }
        private void btn_close_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        private void btn_save_add_Click(object sender, EventArgs e)
        {
            if (edit == true)
            {
                UpdateData();
            }
            else
            {
                InsertData();
            }
            personnel.LoadNhanVienNguoiThan();
            LoadNull();
        }
        private void UpdateData()
        {
            try
            {
                SetValues();
                string sql = string.Empty;
                sql = $@"Update tbl_NhanVienNguoiThan Set LoaiQuanHe = {SQLHelper.rpStr(_QuanHe)}, HoTen = {SQLHelper.rpStr(_HoTen)}, 
                        NgheNghiep = {SQLHelper.rpStr(_NgheNghiep)}, DienThoai = {SQLHelper.rpStr(_DienThoai)}, 
                        DiDong = {SQLHelper.rpStr(_DiDong)},NoiCuTru = {SQLHelper.rpStr(_NoiCuTru)}, 
                        IsPhuThuoc = {SQLHelper.rpI(is_phuthuoc_value)}, NgaySinh = {SQLHelper.rpDT(ngaysinh_value)},
                        GioiTinh = {SQLHelper.rpStr(_GioiTinh)}, MaSoThue = {SQLHelper.rpStr(_MaSoThue)},
                        CCCD = {SQLHelper.rpStr(_CCCD)}, Id_QuocTich = {SQLHelper.rpI(quoctich_value)},
                        NgayCapNhat = '{DateTime.Now}', NguoiCapNhat = {SQLHelper.rpStr(_NguoiCapNhat)}
                        Where Id = {id_nguoithan_value}";
                if (SQLHelper.ExecuteSql(sql) > 0)
                {
                    RJMessageBox.Show("Thêm thông tin thành công", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    RJMessageBox.Show("Thêm thông tin thất bại", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
                SetValues();
                string sql = string.Empty;
                sql = $@"Insert into tbl_NhanVienNguoiThan(MaNhanVien, LoaiQuanHe, HoTen, NgheNghiep, DienThoai, DiDong, NoiCuTru, IsPhuThuoc,
                        NgaySinh, GioiTinh, MaSoThue, CCCD, Id_QuocTich, GhiChu, NgayTao, NguoiTao, del_flg)
                        Values({SQLHelper.rpStr(_ma_nhan_vien)}, {SQLHelper.rpStr(_QuanHe)}, {SQLHelper.rpStr(_HoTen)},
                        {SQLHelper.rpStr(_NgheNghiep)}, {SQLHelper.rpStr(_DienThoai)}, {SQLHelper.rpStr(_DiDong)},
                        {SQLHelper.rpStr(_NoiCuTru)}, {SQLHelper.rpI(is_phuthuoc_value)}, {SQLHelper.rpDT(ngaysinh_value)},
                        {SQLHelper.rpStr(_GioiTinh)}, {SQLHelper.rpStr(_MaSoThue)}, {SQLHelper.rpStr(_CCCD)}, 
                        {SQLHelper.rpI(quoctich_value)}, {SQLHelper.rpStr(_GhiChu)} ,'{DateTime.Now}', 
                        {SQLHelper.rpStr(_NguoiTao)}, 0)";

                if (SQLHelper.ExecuteSql(sql) > 0)
                {
                    RJMessageBox.Show("Cập nhật thông tin thành công", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    RJMessageBox.Show("Cập nhật thông tin thất bại", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
            }
            catch (Exception ex)
            {
                RJMessageBox.Show(ex.Message, "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void SetValues()
        {
            _QuanHe = cbo_loai_quan_he.SelectedValue.ToString();
            _HoTen = txt_ho_ten.Text;
            ngaysinh_value = string.IsNullOrEmpty(dtp_NgaySinh.Text) ? (DateTime?)null : DateTime.Parse(dtp_NgaySinh.Text);
            _NgheNghiep = txt_nghe_nghiep.Text.ToString();
            _NoiCuTru = txt_noi_cu_tru.Text.ToString();
            _GhiChu = txt_ghi_chu.Text.ToString();
            is_phuthuoc_value = (chk_is_phu_thuoc.Checked == true ? 1 : 0);
            _MaSoThue = txt_ma_so_thue.Text;
            _CCCD = txt_cccd.Text;
            quoctich_value = Convert.ToInt32(cbo_QuocTich.SelectedValue);
            _NguoiTao = SQLHelper.sUser;
            _DienThoai = txt_dien_thoai.Text;
            _DiDong = txt_di_dong.Text;
            _GioiTinh = cbo_gioi_tinh.SelectedValue.ToString();
            _NguoiCapNhat = SQLHelper.sUser;
        }
        private bool validateForm()
        {
            if (string.IsNullOrEmpty(txt_ho_ten.Text))
            {
                RJMessageBox.Show("Vui lòng nhập họ tên người thân.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txt_ho_ten.Focus();
                return false;
            }
            if (!IsPhoneNumberValid(txt_dien_thoai.Text.Trim()) && !string.IsNullOrEmpty(txt_dien_thoai.Text.Trim()))
            {
                RJMessageBox.Show("Số điện thoại không hợp lệ.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txt_dien_thoai.Focus();
                return false;
            }
            if (!IsPhoneNumberValid(txt_di_dong.Text.Trim()) && !string.IsNullOrEmpty(txt_di_dong.Text.Trim()))
            {
                RJMessageBox.Show("Số điện thoại di động không hợp lệ.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txt_di_dong.Focus();
                return false;
            }
            if (!IsValidCCCD(txt_cccd.Text.Trim()) && !string.IsNullOrEmpty(txt_cccd.Text.Trim()))
            {
                RJMessageBox.Show("CCCD không hợp lệ. Vui lòng nhập số gồm 12 chữ số.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txt_cccd.Focus();
                return false;
            }
            return true;
        }
        private bool IsValidCCCD(string cccd)
        {
            string pattern = @"^\d{12}$";
            return Regex.IsMatch(cccd, pattern);
        }
        private bool IsPhoneNumberValid(string phoneNumber)
        {
            // Biểu thức chính quy cho số điện thoại (chỉ cho phép số và có thể bắt đầu với 0)
            string pattern = @"^(0|\+84)([0-9]{9})$";
            Regex regex = new Regex(pattern);
            return regex.IsMatch(phoneNumber);
        }
    }
}