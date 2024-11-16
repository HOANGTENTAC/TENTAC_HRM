using System;
using System.Data;
using System.Windows.Forms;
using TENTAC_HRM.Custom;
using TENTAC_HRM.Forms.Main;
using TENTAC_HRM.Forms.User_control;
using TENTAC_HRM.Model;

namespace TENTAC_HRM.Forms.Category
{
    public partial class frm_khenthuong : Form
    {
        public bool edit { get; set; }
        public string _ma_nhan_vien { get; set; }
        public int _id_khenthuong { get; set; }
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
            //set_value_text();
            SetValuesIndex();
            if (edit == true)
            {
                update_date();
            }
            else
            {
                insert_data();
            }

            if (_Personnel != null)
            {
                _Personnel.Load_khenthuong();
            }
            else
            {
                _quatrinh.Load_khenthuong();
            }
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
            load_nhanvien();
            load_hinhThuc();
            load_capkhenthuong();
            load_nguoiky();
            if (edit == true)
            {
                load_data();
            }
        }
        private void load_data()
        {
            string sql = string.Format("select * from tbl_QTKhenThuong where Id='{0}' and del_flg = 0", _id_khenthuong);
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
        private void load_nhanvien()
        {
            cbo_NhanVien.DataSource = provider.load_nhanvien();
            cbo_NhanVien.DisplayMember = "name";
            cbo_NhanVien.ValueMember = "value";
            cbo_NhanVien.SelectedValue = _ma_nhan_vien;
        }
        private void load_hinhThuc()
        {
            cbo_HinhThuc.DataSource = provider.load_all_type(179);
            cbo_HinhThuc.DisplayMember = "name";
            cbo_HinhThuc.ValueMember = "id";
        }
        private void load_nguoiky()
        {
            cbo_NguoiKy.DataSource = provider.load_nhanvien();
            cbo_NguoiKy.DisplayMember = "name";
            cbo_NguoiKy.ValueMember = "value";
        }
        private void load_capkhenthuong()
        {
            cbo_Cap.DataSource = provider.load_all_type(147);
            cbo_Cap.DisplayMember = "name";
            cbo_Cap.ValueMember = "id";
        }
        //private void set_value_text()
        //{
        //    model.So_quyet_dinh = txt_SoQuyetDinh.Text;
        //    model.Ngay_khen_thuong = DateTime.Parse(dtp_NgayKhenThuong.Text.ToString()).ToString("yyyy/MM/dd");
        //    model.Noi_dung = txt_NoiDung.Text;
        //    model.Hinh_thuc = txt_HinhThuc.Text;
        //    model.So_tien = txt_SoTien.Text;
        //    model.Ly_do = txt_LyDo.Text;
        //    model.Id_cap = int.Parse(cbo_Cap.SelectedValue.ToString());
        //    model.Id_nguoi_ky = 0;
        //    model.Id_nguoi_tao = SQLHelper.sIdUser;
        //}

        private void insert_data()
        {
            try
            {
                //    string sql = string.Format("insert into hrm_qt_khenthuong(ma_nhan_vien,ngay_khen_thuong,so_quyet_dinh,noi_dung,hinh_thuc," +
                //"so_tien,ly_do,id_cap,id_nguoi_ky,ngay_tao,id_nguoi_tao) " +
                //"values('{0}','{1}','{2}',N'{3}',N'{4}','{5}',N'{6}','{7}','{8}',GETDATE(),'{9}')",
                //_ma_nhan_vien, model.Ngay_khen_thuong, model.So_quyet_dinh, model.Noi_dung, model.Hinh_thuc,
                //model.So_tien, model.Ly_do, model.Id_cap, model.Id_nguoi_ky, model.Id_nguoi_tao);

                string sql = string.Empty;
                sql = $@"Insert into tbl_QTKhenThuong(MaNhanVien, NgayKhenThuong, SoQuyetDinh, NoiDung, HinhThuc, SoTien,
                        LyDo, Id_Cap, MaNhanVienKy, NgayTao, NguoiTao, del_flg)
                        values({SQLHelper.rpStr(_ma_nhan_vien)}, {SQLHelper.rpDT(_NgayKhenThuong)}, {SQLHelper.rpStr(_SoQuyetDinh)},
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

        private void update_date()
        {
            try
            {
                //string sql = string.Format("update hrm_qt_khenthuong set ngay_khen_thuong = '{1}',so_quyet_dinh = '{2}',noi_dung = N'{3}',hinh_thuc = N'{4}'," +
                //    "so_tien = '{5}',ly_do = N'{6}',id_cap = '{7}',id_nguoi_ky= '{8}',ngay_cap_nhat = GETDATE() " +
                //    "where id_qt_khenthuong= {0}",
                //_id_khenthuong, model.Ngay_khen_thuong, model.So_quyet_dinh, model.Noi_dung, model.Hinh_thuc,
                //model.So_tien, model.Ly_do, model.Id_cap, model.Id_nguoi_ky);

                string sql = string.Empty;
                sql = $@"Update tbl_QTKhenThuong Set NgayKhenThuong = {SQLHelper.rpDT(_NgayKhenThuong)}, SoQuyetDinh = {SQLHelper.rpStr(_SoQuyetDinh)}, 
                    NoiDung = {SQLHelper.rpStr(_NoiDung)}, HinhThuc = {SQLHelper.rpI(_HinhThuc)}, SoTien =  {SQLHelper.rpD(_SoTien)}, 
                    LyDo = {SQLHelper.rpStr(_LyDo)}, Id_Cap = {SQLHelper.rpI(_Cap)}, MaNhanVienKy = {SQLHelper.rpStr(_NguoiKy)}, 
                    NgayCapNhat = '{DateTime.Now}', NguoiCapNhat = {SQLHelper.rpStr(_NguoiCapNhat)}
                    Where Id = {_id_khenthuong}";
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
        private void SetValuesIndex()
        {
            _NgayKhenThuong = string.IsNullOrEmpty(dtp_NgayKhenThuong.Text) ? (DateTime?)null : DateTime.Parse(dtp_NgayKhenThuong.Text);
            _SoQuyetDinh = txt_SoQuyetDinh.Text.Trim();
            _NoiDung = txt_NoiDung.Text.Trim();
            _HinhThuc = Convert.ToInt32(cbo_HinhThuc.SelectedValue);
            _SoTien = string.IsNullOrWhiteSpace(txt_SoTien.Text.Trim()) ? (decimal?)null : Convert.ToDecimal(txt_SoTien.Text.Trim());
            _LyDo = txt_LyDo.Text.Trim();
            _Cap = Convert.ToInt32(cbo_Cap.SelectedValue);
            _NguoiKy = cbo_NguoiKy.SelectedValue.ToString();
            _NguoiTao = SQLHelper.sUser;
            _NguoiCapNhat = SQLHelper.sUser;
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
