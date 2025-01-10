using ComponentFactory.Krypton.Toolkit;
using System;
using System.Data;
using System.Windows.Forms;
using TENTAC_HRM.Custom;
using TENTAC_HRM.Forms.NhanSu;
using TENTAC_HRM.Forms.User_control;
using TENTAC_HRM.Model;

namespace TENTAC_HRM.Forms.Category
{
    public partial class frm_nhanvien_kyluat : KryptonForm
    {
        public bool edit { get; set; }
        public string _MaNhanVien { get; set; }
        public int _IdKyLuat { get; set; }
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
            LoadComboboxNhanVien();
            LoadComboboxHinhThuc();
            if (edit == true)
            {
                LoadData();
            }
        }
        private void LoadData()
        {
            string sql = string.Format("select * from tbl_QTKyluat where Id='{0}'", _IdKyLuat);
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
        private void LoadComboboxNhanVien()
        {
            cbo_NhanVien.DataSource = provider.load_nhanvien();
            cbo_NhanVien.DisplayMember = "name";
            cbo_NhanVien.ValueMember = "value";
            cbo_NhanVien.SelectedValue = _MaNhanVien;
        }
        private void LoadComboboxHinhThuc()
        {
            cbo_HinhThuc.DataSource = provider.load_all_type(186);
            cbo_HinhThuc.DisplayMember = "name";
            cbo_HinhThuc.ValueMember = "id";
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
            _quatrinh.LoadQTKyLuat();
            LoadNull();
        }
        private void SetValues()
        {
            _NgayKyLuat = string.IsNullOrEmpty(dtp_NgayKyLuat.Text) ? (DateTime?)null : DateTime.Parse(dtp_NgayKyLuat.Text);
            _SoQuyetDinh = txt_SoQuyetDinh.Text.Trim();
            _NoiDung = txt_NoiDung.Text.Trim();
            _HinhThuc = Convert.ToInt32(cbo_HinhThuc.SelectedValue);
            _LyDo = txt_LyDo.Text.Trim();
            _NguoiTao = SQLHelper.sUser;
            _NguoiCapNhat = SQLHelper.sUser;
        }
        private void InsertData()
        {
            try
            {
                string sql = string.Empty;
                sql = $@"Insert into tbl_QTKyluat(MaNhanVien, NgayKyLuat, SoQuyetDinh, NoiDung, HinhThuc, LyDo, NgayTao, NguoiTao, del_flg)
                    values({SQLHelper.rpStr(_MaNhanVien)}, {SQLHelper.rpDT(_NgayKyLuat)}, {SQLHelper.rpStr(_SoQuyetDinh)}, 
                    {SQLHelper.rpStr(_NoiDung)}, {SQLHelper.rpI(_HinhThuc)}, {SQLHelper.rpStr(_LyDo)}, '{DateTime.Now}', 
                    {SQLHelper.rpStr(_NguoiTao)}, 0)";

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
        private void UpdateData()
        {
            try
            {
                string sql = string.Empty;
                sql = $@"Update tbl_QTKyluat Set NgayKyLuat = {SQLHelper.rpDT(_NgayKyLuat)}, SoQuyetDinh = {SQLHelper.rpStr(_SoQuyetDinh)}, 
                        NoiDung = {SQLHelper.rpStr(_NoiDung)}, HinhThuc = {SQLHelper.rpI(_HinhThuc)}, LyDo = {SQLHelper.rpStr(_LyDo)}, 
                        NgayCapNhat = '{DateTime.Now}', NguoiCapNhat = {SQLHelper.rpStr(_NguoiCapNhat)}
                        Where Id = {_IdKyLuat}";

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