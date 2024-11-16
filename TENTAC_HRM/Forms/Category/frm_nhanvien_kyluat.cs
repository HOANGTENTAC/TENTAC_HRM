using System;
using System.Data;
using System.Windows.Forms;
using TENTAC_HRM.Custom;
using TENTAC_HRM.Model;
using TENTAC_HRM.Forms.User_control;
using TENTAC_HRM.Forms.Main;

namespace TENTAC_HRM.Forms.Category
{
    public partial class frm_nhanvien_kyluat : Form
    {
        public bool edit { get; set; }
        public string _ma_nhan_vien { get; set; }
        public int _id_qt_kyluat { get; set; }
        DataProvider provider = new DataProvider();
        Kyluat_model model = new Kyluat_model();
        frm_personnel _Personnel;
        uc_quatrinh_lamviec _quatrinh;

        string _SoQuyetDinh, _NoiDung, _LyDo, _NguoiTao, _NguoiCapNhat;
        DateTime? _NgayKyLuat;
        int? _HinhThuc;
        public frm_nhanvien_kyluat(Form form, UserControl user)
        {
            InitializeComponent();
            _quatrinh = (uc_quatrinh_lamviec)user;
            _Personnel = (frm_personnel)form;
        }

        private void frm_nhanvien_kyluat_Load(object sender, EventArgs e)
        {
            load_nhanvien();
            load_hinhThuc();
            if (edit == true)
            {
                load_data();
            }
        }
        private void load_data()
        {
            string sql = string.Format("select * from tbl_QTKyluat where Id='{0}'", _id_qt_kyluat);
            DataTable dt = SQLHelper.ExecuteDt(sql);
            if (dt.Rows.Count > 0)
            {
                dtp_NgayKyLuat.Text = dt.Rows[0]["NgayKyLuat"].ToString();
                txt_SoQuyetDinh.Text = dt.Rows[0]["SoQuyetDinh"].ToString();
                cbo_HinhThuc.SelectedValue = dt.Rows[0]["HinhThuc"].ToString();
                txt_LyDo.Text = dt.Rows[0]["LyDo"].ToString();
                txt_NoiDung.Text = dt.Rows[0]["NoiDung"].ToString();
            }
        }
        private void LoadNull()
        {
            txt_SoQuyetDinh.Text = string.Empty;
            dtp_NgayKyLuat.Text = string.Empty;
            cbo_HinhThuc.SelectedValue = "0";
            txt_LyDo.Text = string.Empty;
            txt_NoiDung.Text = string.Empty;
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
            cbo_HinhThuc.DataSource = provider.load_all_type(186);
            cbo_HinhThuc.DisplayMember = "name";
            cbo_HinhThuc.ValueMember = "id";
        }

        private void btn_save_Click(object sender, EventArgs e)
        {
            set_value_text();
            if (edit == true)
            {
                update_date();
            }
            else
            {
                insert_data();
            }
            if (_quatrinh != null)
            {
                _quatrinh.Load_kyluat();
            }
            else
            {
                _Personnel.Load_kyluat();
            }
        }
        private void set_value_text()
        {
            //model.So_quyet_dinh = txt_soquyetdinh.Text;
            //model.Ngay_ky_luat = DateTime.Parse(dtp_kyluat.Text.ToString()).ToString("yyyy/MM/dd");
            //model.Noi_dung = txt_noidung.Text;
            //model.Hinh_thuc = txt_hinhthuc.Text;
            //model.So_tien = txt_sotien.Text;
            //model.Ly_do = txt_lydo.Text;
            //model.Id_cap = int.Parse(cbo_cap.SelectedValue.ToString());
            //model.Id_nguoi_ky = 0;
            //model.Id_nguoi_tao = SQLHelper.sIdUser;

            _NgayKyLuat = string.IsNullOrEmpty(dtp_NgayKyLuat.Text) ? (DateTime?)null : DateTime.Parse(dtp_NgayKyLuat.Text);
            _SoQuyetDinh = txt_SoQuyetDinh.Text.Trim();
            _NoiDung = txt_NoiDung.Text.Trim();
            _HinhThuc = Convert.ToInt32(cbo_HinhThuc.SelectedValue);
            _LyDo = txt_LyDo.Text.Trim();
            _NguoiTao = SQLHelper.sUser;
            _NguoiCapNhat = SQLHelper.sUser;
        }

        private void insert_data()
        {
            try
            {
                //string sql = string.Format("insert into hrm_qt_kyluat(ma_nhan_vien,ngay_ky_luat,so_quyet_dinh,noi_dung,hinh_thuc," +
                //"so_tien,ly_do,id_cap,id_nguoi_ky,ngay_tao,id_nguoi_tao) " +
                //"values('{0}','{1}','{2}',N'{3}',N'{4}','{5}',N'{6}','{7}','{8}',GETDATE(),'{9}')",
                //_ma_nhan_vien, model.Ngay_ky_luat, model.So_quyet_dinh, model.Noi_dung, model.Hinh_thuc,
                //model.So_tien, model.Ly_do, model.Id_cap, model.Id_nguoi_ky, model.Id_nguoi_tao);
                string sql = string.Empty;
                sql = $@"Insert into tbl_QTKyluat(MaNhanVien, NgayKyLuat, SoQuyetDinh, NoiDung, HinhThuc, LyDo, NgayTao, NguoiTao, del_flg)
                    values({SQLHelper.rpStr(_ma_nhan_vien)}, {SQLHelper.rpDT(_NgayKyLuat)}, {SQLHelper.rpStr(_SoQuyetDinh)}, 
                    {SQLHelper.rpStr(_NoiDung)}, {SQLHelper.rpI(_HinhThuc)}, {SQLHelper.rpStr(_LyDo)}, '{DateTime.Now}', 
                    {SQLHelper.rpStr(_NguoiTao)}, 0)";

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
                //string sql = string.Format("update hrm_qt_kyluat set ngay_ky_luat = '{1}',so_quyet_dinh = '{2}',noi_dung = N'{3}',hinh_thuc = N'{4}'," +
                //    "so_tien = '{5}',ly_do = N'{6}',id_cap = '{7}',id_nguoi_ky= '{8}',ngay_cap_nhat = GETDATE() " +
                //    "where id_qt_kyluat= {0}",
                //_id_qt_kyluat, model.Ngay_ky_luat, model.So_quyet_dinh, model.Noi_dung, model.Hinh_thuc,
                //model.So_tien, model.Ly_do, model.Id_cap, model.Id_nguoi_ky);
                string sql = string.Empty;
                sql = $@"Update tbl_QTKyluat Set NgayKyLuat = {SQLHelper.rpDT(_NgayKyLuat)}, SoQuyetDinh = {SQLHelper.rpStr(_SoQuyetDinh)}, 
                        NoiDung = {SQLHelper.rpStr(_NoiDung)}, HinhThuc = {SQLHelper.rpI(_HinhThuc)}, LyDo = {SQLHelper.rpStr(_LyDo)}, 
                        NgayCapNhat = '{DateTime.Now}', NguoiCapNhat = {SQLHelper.rpStr(_NguoiCapNhat)}
                        Where Id = {_id_qt_kyluat}";

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

        private void txt_sotien_KeyPress(object sender, KeyPressEventArgs e)
        {
            event_keypress(e);
        }

        private void btn_close_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
