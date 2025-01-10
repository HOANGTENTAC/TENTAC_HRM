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
    public partial class frm_nhanvien_tainan : KryptonForm
    {
        int _Id_LoaiTaiNan, _Id_MucDo;
        DateTime? _NgayDienRa;
        string _NoiDienRa, _NoiDung, _NguoiTao, _NguoiCapNhat;
        public bool edit { get; set; }
        public string _MaNhanVien { get; set; }
        public int _IdTaiNhan { get; set; }
        DataProvider provider = new DataProvider();
        Tainan_model model = new Tainan_model();
        frm_personnel _Personnel;
        uc_quatrinh_lamviec _quatrinh;
        public frm_nhanvien_tainan(Form form, UserControl user)
        {
            InitializeComponent();
            _quatrinh = (uc_quatrinh_lamviec)user;
            _Personnel = (frm_personnel)form;
        }

        private void btn_close_Click(object sender, EventArgs e)
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
            _quatrinh.LoadQTTaiNan();
            LoadNull();
        }
        private void frm_nhanvien_tainan_Load(object sender, EventArgs e)
        {
            LoadComboboxNhanVien();
            LoadComboboxLoaiTaiNan();
            LoadComboboxMucDoTaiNan();
            if (edit == true)
            {
                LoadData();
            }
        }
        private void LoadNull()
        {
            cbo_LoaiTaiNan.SelectedValue = "0";
            cbo_MucDo.SelectedValue = "0";
            txt_NoiDienRa.Text = string.Empty;
            dtp_NgayDienRa.Text = string.Empty;
            txt_NoiDung.Text = string.Empty;
        }
        private void LoadComboboxMucDoTaiNan()
        {
            cbo_MucDo.DataSource = provider.load_all_type(158);
            cbo_MucDo.DisplayMember = "name";
            cbo_MucDo.ValueMember = "id";
        }
        private void LoadComboboxLoaiTaiNan()
        {
            cbo_LoaiTaiNan.DataSource = provider.load_all_type(150);
            cbo_LoaiTaiNan.DisplayMember = "name";
            cbo_LoaiTaiNan.ValueMember = "id";
        }
        private void LoadComboboxNhanVien()
        {
            cbo_NhanVien.DataSource = provider.load_nhanvien();
            cbo_NhanVien.DisplayMember = "name";
            cbo_NhanVien.ValueMember = "value";
            cbo_NhanVien.SelectedValue = _MaNhanVien;
        }
        private void LoadData()
        {
            string sql = string.Format("select * from tbl_QTTaiNan where Id='{0}'", _IdTaiNhan);
            DataTable dt = SQLHelper.ExecuteDt(sql);
            if (dt.Rows.Count > 0)
            {
                cbo_LoaiTaiNan.SelectedValue = dt.Rows[0]["Id_LoaiTaiNan"].ToString();
                cbo_MucDo.SelectedValue = dt.Rows[0]["Id_MucDo"].ToString();
                dtp_NgayDienRa.Text = dt.Rows[0]["NgayDienRa"].ToString();
                txt_NoiDienRa.Text = dt.Rows[0]["NoiDienRa"].ToString();
                txt_NoiDung.Text = dt.Rows[0]["NoiDung"].ToString();
            }
        }
        private void InsertData()
        {
            try
            {
                string sql = string.Empty;
                sql = $@"Insert into tbl_QTTaiNan(MaNhanVien, Id_LoaiTaiNan, Id_MucDo, NgayDienRa, NoiDienRa, NoiDung, NgayTao, NguoiTao, del_flg)
                values ({SQLHelper.rpStr(_MaNhanVien)}, {SQLHelper.rpI(_Id_LoaiTaiNan)}, {SQLHelper.rpI(_Id_MucDo)}, {SQLHelper.rpDT(_NgayDienRa)},
                {SQLHelper.rpStr(_NoiDienRa)}, {SQLHelper.rpStr(_NoiDung)}, '{DateTime.Now}' ,{SQLHelper.rpStr(_NguoiTao)}, 0)";

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
                sql = $@"Update tbl_QTTaiNan Set Id_LoaiTaiNan = {SQLHelper.rpI(_Id_LoaiTaiNan)}, Id_MucDo = {SQLHelper.rpI(_Id_MucDo)},
                NgayDienRa = {SQLHelper.rpDT(_NgayDienRa)}, NoiDienRa = {SQLHelper.rpStr(_NoiDienRa)}, NoiDung = {SQLHelper.rpStr(_NoiDung)},
                NgayCapNhat = '{DateTime.Now}', NguoiCapNhat = {SQLHelper.rpStr(_NguoiCapNhat)}
                Where Id = {SQLHelper.rpI(_IdTaiNhan)}";

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
            _Id_LoaiTaiNan = Convert.ToInt32(cbo_LoaiTaiNan.SelectedValue);
            _Id_MucDo = Convert.ToInt32(cbo_MucDo.SelectedValue);
            _NgayDienRa = string.IsNullOrEmpty(dtp_NgayDienRa.Text) ? (DateTime?)null : DateTime.Parse(dtp_NgayDienRa.Text);
            _NoiDienRa = txt_NoiDienRa.Text.Trim();
            _NoiDung = txt_NoiDung.Text.Trim();
            _NguoiTao = SQLHelper.sUser;
            _NguoiCapNhat = SQLHelper.sUser;
        }
    }
}