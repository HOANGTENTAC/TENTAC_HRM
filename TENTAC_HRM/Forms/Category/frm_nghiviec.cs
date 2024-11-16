using System;
using System.Data;
using System.Windows.Forms;
using TENTAC_HRM.Custom;
using TENTAC_HRM.Forms.Main;
using TENTAC_HRM.Forms.User_control;

namespace TENTAC_HRM.Forms.Category
{
    public partial class frm_nghiviec : Form
    {
        DataProvider provider = new DataProvider();
        public string _ma_nhan_vien { get; set; }
        public bool _edit { get; set; }
        public int _id_nghi_viec;
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
        private void load_nhanvien()
        {
            cbo_NhanVien.DataSource = provider.load_nhanvien();
            cbo_NhanVien.DisplayMember = "name";
            cbo_NhanVien.ValueMember = "value";
            cbo_NhanVien.SelectedValue = _ma_nhan_vien;
        }
        private void load_loainghiviec()
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
        //    string sql = string.Format("select Id_TrangThai from tbl_NhanVien where MaNhanVien = '{0}'", _ma_nhan_vien);
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
            if(Convert.ToString(cbo_LoaiNghiViec.SelectedValue) == "3")
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
            load_loainghiviec();
            if (_edit == true)
            {
                string sql = string.Format("select * from tbl_QTNghiViec where Id = '{0}'", _id_nghi_viec);
                DataTable dt = SQLHelper.ExecuteDt(sql);
                if (dt.Rows.Count > 0)
                {
                    _ma_nhan_vien = dt.Rows[0]["MaNhanVien"].ToString();
                    cbo_LoaiNghiViec.SelectedValue = dt.Rows[0]["LoaiNghiViec"].ToString();
                    txt_SoQuyetDinh.Text = dt.Rows[0]["SoQuyetDinh"].ToString();
                    dtp_NgayQuyetDinh.Text = dt.Rows[0]["NgayQuyetDinh"].ToString();
                    dtp_TuNgay.Text = dt.Rows[0]["TuNgay"].ToString();
                    dtp_DenNgay.Text = dt.Rows[0]["DenNgay"].ToString();
                    txt_NoiDung.Text = dt.Rows[0]["NoiDung"].ToString();
                }
            }

            load_nhanvien();
            //load_trangthai_congviec();
        }
        private void btn_save_Click(object sender, System.EventArgs e)
        {
            SetValues();
            if (_edit == true)
            {
                update_data();
            }
            else
            {
                insert_data();
            }
            if (_quatrinh != null)
            {
                _quatrinh.load_nghiviec();
            }
            else
            {
                _Personnel.load_nghiviec();
            }
        }

        private void insert_data()
        {
            try
            {
                string sql = string.Empty;
                sql = $@"Insert into tbl_QTNghiViec(MaNhanVien, TuNgay, DenNgay, NgayQuyetDinh, SoQuyetDinh, NoiDung, LoaiNghiViec, NgayTao, NguoiTao, del_flg)
                Values({SQLHelper.rpStr(_ma_nhan_vien)}, {SQLHelper.rpDT(_TuNgay)}, {SQLHelper.rpDT(_DenNgay)}, {SQLHelper.rpDT(_NgayQuyetDinh)},
                {SQLHelper.rpStr(_SoQuyetDinh)}, {SQLHelper.rpStr(_NoiDung)}, {SQLHelper.rpI(_LoaiNghiViec)}, '{DateTime.Now}', 
                {SQLHelper.rpStr(_NguoiTao)}, 0)";
                if (SQLHelper.ExecuteSql(sql) == 1)
                {
                    if (Convert.ToInt32(cbo_LoaiNghiViec.SelectedValue) != 0)
                    {
                        string sql_nhanvien = string.Empty;
                        sql_nhanvien = $@"Update tbl_NhanVien set Id_TrangThai = {SQLHelper.rpI(_LoaiNghiViec)} where MaNhanVien = {SQLHelper.rpStr(_ma_nhan_vien)}";
                        SQLHelper.ExecuteSql(sql_nhanvien);
                    }
                    RJMessageBox.Show("Thêm thành công", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
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
                string sql = string.Empty;
                sql = $@"Update tbl_QTNghiViec Set TuNgay = {SQLHelper.rpDT(_TuNgay)}, DenNgay = {SQLHelper.rpDT(_DenNgay)},
                NgayQuyetDinh = {SQLHelper.rpDT(_NgayQuyetDinh)}, SoQuyetDinh = {SQLHelper.rpStr(_SoQuyetDinh)}, NoiDung = {SQLHelper.rpStr(_NoiDung)},
                LoaiNghiViec = {SQLHelper.rpI(_LoaiNghiViec)}, NgayCapNhat = '{DateTime.Now}', NguoiCapNhat = {SQLHelper.rpStr(_NguoiCapNhat)}
                Where Id = {SQLHelper.rpI(_id_nghi_viec)}";
                if (SQLHelper.ExecuteSql(sql) == 1)
                {
                    if (Convert.ToInt32(cbo_LoaiNghiViec.SelectedValue) != 0)
                    {
                        string sql_nhanvien = string.Empty;
                        sql_nhanvien = $@"Update tbl_NhanVien set Id_TrangThai = {SQLHelper.rpI(_LoaiNghiViec)} where MaNhanVien = {SQLHelper.rpStr(_ma_nhan_vien)}";
                        SQLHelper.ExecuteSql(sql_nhanvien);
                    }
                    RJMessageBox.Show("Cập nhật thành công", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
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
