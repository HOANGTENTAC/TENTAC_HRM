using ComponentFactory.Krypton.Toolkit;
using System;
using System.Data;
using System.Windows.Forms;
using TENTAC_HRM.Custom;
using TENTAC_HRM.Forms.Main;
using TENTAC_HRM.Forms.User_control;

namespace TENTAC_HRM.Forms.Category
{
    public partial class frm_congtac : KryptonForm
    {
        string _SoQuyetDinh, _NoiDung, _DiaDiem, _NguoiTao, _NguoiCapNhat;
        DateTime? _TuNgay, _DenNgay;
        DataProvider provider = new DataProvider();
        public bool edit { get; set; }
        public string _MaNhanVien;
        public int _IdCongTac { get; set; }
        frm_personnel _Personnel;
        uc_quatrinh_lamviec _quatrinh;
        public frm_congtac(Form form, UserControl user)
        {
            InitializeComponent();
            _quatrinh = (uc_quatrinh_lamviec)user;
            _Personnel = (frm_personnel)form;
        }
        private void frm_congtac_Load(object sender, EventArgs e)
        {
            LoadComboboxNhanVien();
            if (edit == true)
            {
                string sql = string.Format("select * from tbl_QTCongTac where Id = '{0}'", _IdCongTac);
                DataTable dataTable = new DataTable();
                dataTable = SQLHelper.ExecuteDt(sql);
                if (dataTable.Rows.Count > 0)
                {
                    txt_DiaDiem.Text = dataTable.Rows[0]["DiaDiem"].ToString();
                    txt_SoQuyetDinh.Text = dataTable.Rows[0]["SoQuyetDinh"].ToString();
                    dtp_TuNgay.Text = dataTable.Rows[0]["TuNgay"].ToString();
                    dtp_DenNgay.Text = dataTable.Rows[0]["DenNgay"].ToString();
                    txt_NoiDung.Text = dataTable.Rows[0]["NoiDung"].ToString();
                }
            }
        }
        private void LoadNull()
        {
            txt_DiaDiem.Text = string.Empty;
            txt_SoQuyetDinh.Text = string.Empty;
            dtp_TuNgay.Text = string.Empty;
            dtp_DenNgay.Text = string.Empty;
            txt_NoiDung.Text = string.Empty;
        }
        private void btn_close_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        private void LoadComboboxNhanVien()
        {
            cbo_NhanVien.DataSource = provider.load_nhanvien();
            cbo_NhanVien.DisplayMember = "name";
            cbo_NhanVien.ValueMember = "value";
            cbo_NhanVien.SelectedValue = _MaNhanVien;
        }
        private void UpdateData()
        {
            try
            {
                string sql = string.Empty;
                sql = $@"Update tbl_QTCongTac Set TuNgay = {SQLHelper.rpDT(_TuNgay)}, DenNgay = {SQLHelper.rpDT(_DenNgay)},
                    SoQuyetDinh = {SQLHelper.rpStr(_SoQuyetDinh)}, DiaDiem = {SQLHelper.rpStr(_DiaDiem)}, 
                    NoiDung = {SQLHelper.rpStr(_NoiDung)}, NgayCapNhat = '{DateTime.Now}', NguoiCapNhat = {SQLHelper.rpStr(_NguoiCapNhat)}
                    Where Id = {_IdCongTac}";
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
        private void InsertData()
        {
            try
            {
                string sql = string.Empty;
                sql = $@"Insert tbl_QTCongTac(MaNhanVien, TuNgay, DenNgay, SoQuyetDinh, DiaDiem, NoiDung, NgayTao, NguoiTao, del_flg)
                values({SQLHelper.rpStr(_MaNhanVien)}, {SQLHelper.rpDT(_TuNgay)}, {SQLHelper.rpDT(_DenNgay)}, 
                {SQLHelper.rpStr(_SoQuyetDinh)}, {SQLHelper.rpStr(_DiaDiem)}, {SQLHelper.rpStr(_NoiDung)}, 
                '{DateTime.Now}', {SQLHelper.rpStr(_NguoiTao)}, 0)";
                if (SQLHelper.ExecuteSql(sql) == 1)
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
        private void SetValues()
        {
            _TuNgay = string.IsNullOrEmpty(dtp_TuNgay.Text) ? (DateTime?)null : DateTime.Parse(dtp_TuNgay.Text);
            _DenNgay = string.IsNullOrEmpty(dtp_DenNgay.Text) ? (DateTime?)null : DateTime.Parse(dtp_DenNgay.Text);
            _SoQuyetDinh = txt_SoQuyetDinh.Text.ToString();
            _NoiDung = txt_NoiDung.Text.ToString();
            _DiaDiem = txt_DiaDiem.Text.ToString();
            _NguoiTao = SQLHelper.sUser;
            _NguoiCapNhat = SQLHelper.sUser;
        }
        private bool validateForm()
        {
            if (string.IsNullOrEmpty(dtp_TuNgay.Value.ToString()))
            {
                RJMessageBox.Show("Vui lòng chọn từ ngày.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                dtp_TuNgay.Focus();
                return false;
            }
            if (string.IsNullOrEmpty(dtp_DenNgay.Value.ToString()))
            {
                RJMessageBox.Show("Vui lòng chọn đến ngày.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                dtp_DenNgay.Focus();
                return false;
            }
            if (string.IsNullOrEmpty(txt_SoQuyetDinh.Text.ToString()))
            {
                RJMessageBox.Show("Vui lòng nhập số quyết định.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txt_SoQuyetDinh.Focus();
                return false;
            }
            return true;
        }
        private void btn_save_Click(object sender, EventArgs e)
        {
            SetValues();
            if (edit == false)
            {
                InsertData();
            }
            else
            {
                UpdateData();
            }
            LoadNull();
            _quatrinh.LoadQTCongTac();
        }
    }
}