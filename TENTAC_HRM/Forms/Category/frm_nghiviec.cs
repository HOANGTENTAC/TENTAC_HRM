using ComponentFactory.Krypton.Toolkit;
using System;
using System.Data;
using System.Windows.Forms;
using TENTAC_HRM.Custom;
using TENTAC_HRM.Forms.Main;
using TENTAC_HRM.Forms.User_control;

namespace TENTAC_HRM.Forms.Category
{
    public partial class frm_nghiviec : KryptonForm
    {
        DataProvider provider = new DataProvider();
        public string _MaNhanVien { get; set; }
        public bool _edit { get; set; }
        public int _IdNghiViec;
        frm_personnel _Personnel;
        uc_quatrinh_lamviec _quatrinh;
        DateTime? _TuNgay, _DenNgay, _NgayQuyetDinh;
        string _SoQuyetDinh, _NoiDung, _NguoiTao, _NguoiCapNhat;
        int? _LoaiNghiViec;
        public frm_nghiviec(Form form, UserControl user)
        {
            InitializeComponent();
            _quatrinh = (uc_quatrinh_lamviec)user;
            _Personnel = (frm_personnel)form;
            LoadNull();
        }
        private void LoadComboboxNhanVien()
        {
            cbo_NhanVien.DataSource = provider.load_nhanvien();
            cbo_NhanVien.DisplayMember = "name";
            cbo_NhanVien.ValueMember = "value";
            cbo_NhanVien.SelectedValue = _MaNhanVien;
        }
        private void LoadComboboxLoaiNghiViec()
        {
            cbo_LoaiNghiViec.DataSource = provider.load_loainghiviec();
            cbo_LoaiNghiViec.DisplayMember = "name";
            cbo_LoaiNghiViec.ValueMember = "id";
        }
        private void LoadNull()
        {
            dtp_TuNgay.Enabled = false;
            dtp_DenNgay.Enabled = false;
            dtp_TuNgay.Text = string.Empty;
            dtp_DenNgay.Text = string.Empty;
        }

        //private void load_trangthai_congviec()
        //{
        //    string sql = string.Format("select Id_TrangThai from tbl_NhanVien where MaNhanVien = '{0}'", _MaNhanVien);
        //    DataTable dt = new DataTable();
        //    dt = SQLHelper.ExecuteDt(sql);
        //    cbo_TrangThaiNhanVien.DataSource = provider.load_all_type(1);
        //    cbo_TrangThaiNhanVien.DisplayMember = "name";
        //    cbo_TrangThaiNhanVien.ValueMember = "id";
        //    cbo_TrangThaiNhanVien.SelectedValue = dt.Rows[0][0].ToString();
        //}
        private void btn_close_Click(object sender, System.EventArgs e)
        {
            this.Close();
        }
        private void cbo_LoaiNghiViec_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (Convert.ToString(cbo_LoaiNghiViec.SelectedValue) == "3")
            {
                dtp_TuNgay.Enabled = true;
                dtp_DenNgay.Enabled = true;
                dtp_TuNgay.Value = DateTime.Now;
                dtp_DenNgay.Value = DateTime.Now;
            }
            else
            {
                LoadNull();
            }
        }
        private void frm_nghiviec_Load(object sender, System.EventArgs e)
        {
            LoadComboboxLoaiNghiViec();
            if (_edit == true)
            {
                string sql = string.Format("select * from tbl_QTNghiViec where Id = '{0}'", _IdNghiViec);
                DataTable dt = SQLHelper.ExecuteDt(sql);
                if (dt.Rows.Count > 0)
                {
                    _MaNhanVien = dt.Rows[0]["MaNhanVien"].ToString();
                    cbo_LoaiNghiViec.SelectedValue = dt.Rows[0]["LoaiNghiViec"].ToString();
                    txt_SoQuyetDinh.Text = dt.Rows[0]["SoQuyetDinh"].ToString();
                    dtp_NgayQuyetDinh.Text = dt.Rows[0]["NgayQuyetDinh"].ToString();
                    dtp_TuNgay.Text = dt.Rows[0]["TuNgay"].ToString();
                    dtp_DenNgay.Text = dt.Rows[0]["DenNgay"].ToString();
                    txt_NoiDung.Text = dt.Rows[0]["NoiDung"].ToString();
                }
            }
            LoadComboboxNhanVien();
        }
        private void btn_save_Click(object sender, System.EventArgs e)
        {
            SetValues();
            if (_edit == true)
            {
                UpdateData();
            }
            else
            {
                InsertData();
            }
            _quatrinh.LoadQTNghiViec();
        }
        private void InsertData()
        {
            try
            {
                string sql = string.Empty;
                sql = $@"Insert into tbl_QTNghiViec(MaNhanVien, TuNgay, DenNgay, NgayQuyetDinh, SoQuyetDinh, NoiDung, LoaiNghiViec, NgayTao, NguoiTao, del_flg)
                Values({SQLHelper.rpStr(_MaNhanVien)}, {SQLHelper.rpDT(_TuNgay)}, {SQLHelper.rpDT(_DenNgay)}, {SQLHelper.rpDT(_NgayQuyetDinh)},
                {SQLHelper.rpStr(_SoQuyetDinh)}, {SQLHelper.rpStr(_NoiDung)}, {SQLHelper.rpI(_LoaiNghiViec)}, '{DateTime.Now}', 
                {SQLHelper.rpStr(_NguoiTao)}, 0)";
                if (SQLHelper.ExecuteSql(sql) > 0)
                {
                    if (Convert.ToInt32(cbo_LoaiNghiViec.SelectedValue) != 0)
                    {
                        string sql_nhanvien = string.Empty;
                        sql_nhanvien = $@"Update tbl_NhanVien set Id_TrangThai = {SQLHelper.rpI(_LoaiNghiViec)} where MaNhanVien = {SQLHelper.rpStr(_MaNhanVien)}";
                        SQLHelper.ExecuteSql(sql_nhanvien);
                    }
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
        private void UpdateData()
        {
            try
            {
                string sql = string.Empty;
                sql = $@"Update tbl_QTNghiViec Set TuNgay = {SQLHelper.rpDT(_TuNgay)}, DenNgay = {SQLHelper.rpDT(_DenNgay)},
                NgayQuyetDinh = {SQLHelper.rpDT(_NgayQuyetDinh)}, SoQuyetDinh = {SQLHelper.rpStr(_SoQuyetDinh)}, NoiDung = {SQLHelper.rpStr(_NoiDung)},
                LoaiNghiViec = {SQLHelper.rpI(_LoaiNghiViec)}, NgayCapNhat = '{DateTime.Now}', NguoiCapNhat = {SQLHelper.rpStr(_NguoiCapNhat)}
                Where Id = {SQLHelper.rpI(_IdNghiViec)}";
                if (SQLHelper.ExecuteSql(sql) > 0)
                {
                    if (Convert.ToInt32(cbo_LoaiNghiViec.SelectedValue) != 0)
                    {
                        string sql_nhanvien = string.Empty;
                        sql_nhanvien = $@"Update tbl_NhanVien set Id_TrangThai = {SQLHelper.rpI(_LoaiNghiViec)} where MaNhanVien = {SQLHelper.rpStr(_MaNhanVien)}";
                        SQLHelper.ExecuteSql(sql_nhanvien);
                    }
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
            _TuNgay = string.IsNullOrEmpty(dtp_TuNgay.Text) ? (DateTime?)null : DateTime.Parse(dtp_TuNgay.Text);
            _DenNgay = string.IsNullOrEmpty(dtp_DenNgay.Text) ? (DateTime?)null : DateTime.Parse(dtp_DenNgay.Text);
            _NgayQuyetDinh = string.IsNullOrEmpty(dtp_NgayQuyetDinh.Text) ? (DateTime?)null : DateTime.Parse(dtp_NgayQuyetDinh.Text);
            _SoQuyetDinh = txt_SoQuyetDinh.Text.Trim();
            _NoiDung = txt_NoiDung.Text.Trim();
            _LoaiNghiViec = Convert.ToInt32(cbo_LoaiNghiViec.SelectedValue);
            _NguoiTao = SQLHelper.sUser;
            _NguoiCapNhat = SQLHelper.sUser;
        }
    }
}