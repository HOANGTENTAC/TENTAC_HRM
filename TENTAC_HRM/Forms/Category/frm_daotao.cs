using ComponentFactory.Krypton.Toolkit;
using System;
using System.Data;
using System.Windows.Forms;
using TENTAC_HRM.Custom;
using TENTAC_HRM.Forms.Main;
using TENTAC_HRM.Forms.User_control;

namespace TENTAC_HRM.Forms.Category
{
    public partial class frm_daotao : KryptonForm
    {
        DataProvider provider = new DataProvider();
        public string _MaNhanVien { get; set; }
        public bool _edit { get; set; }
        public int _IdDaoTao;
        frm_personnel _personnel;
        uc_quatrinh_lamviec _quatrinh;
        string _SoQuyetDinh, _NoiDung, _NguoiTao, _NguoiCapNhat;
        DateTime? _TuNgay, _DenNgay;
        int? _HinhThuc;
        public frm_daotao(Form form, UserControl user)
        {
            InitializeComponent();
            _quatrinh = (uc_quatrinh_lamviec)user;
            _personnel = (frm_personnel)form;
        }
        private void LoadComboboxNhanVien()
        {
            cbo_NhanVien.DataSource = provider.load_nhanvien();
            cbo_NhanVien.DisplayMember = "name";
            cbo_NhanVien.ValueMember = "value";
            cbo_NhanVien.SelectedValue = _MaNhanVien;
        }
        private void LoadComboboxHinhThucDT()
        {
            cbo_HinhThuc.DataSource = provider.load_all_type(191);
            cbo_HinhThuc.DisplayMember = "name";
            cbo_HinhThuc.ValueMember = "id";
        }
        private void frm_daotao_Load(object sender, EventArgs e)
        {
            LoadComboboxNhanVien();
            LoadComboboxHinhThucDT();
            if (_edit == true)
            {
                string sql = string.Format("select * from tbl_QTDaoTao where Id = '{0}'", _IdDaoTao);
                DataTable dt = new DataTable();
                dt = SQLHelper.ExecuteDt(sql);
                if (dt.Rows.Count > 0)
                {
                    _MaNhanVien = dt.Rows[0]["MaNhanVien"].ToString();
                    txt_SoQuyetDinh.Text = dt.Rows[0]["SoQuyetDinh"].ToString();
                    dtp_TuNgay.Text = dt.Rows[0]["TuNgay"].ToString();
                    dtp_DenNgay.Text = dt.Rows[0]["DenNgay"].ToString();
                    cbo_HinhThuc.SelectedValue = dt.Rows[0]["HinhThuc"];
                    txt_NoiDung.Text = dt.Rows[0]["NoiDung"].ToString();
                }
            }
        }
        private void btn_save_Click(object sender, EventArgs e)
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
            if (_personnel != null)
            {
                _personnel.LoadNhanVienDaoTao();
            }
            else
            {
                _quatrinh.load_daotao();
            }
            LoadNull();
        }
        private void LoadNull()
        {
            txt_SoQuyetDinh.Text = string.Empty;
            dtp_TuNgay.Text = string.Empty;
            dtp_DenNgay.Text = string.Empty;
            cbo_HinhThuc.SelectedValue = "0";
            txt_NoiDung.Text = string.Empty;
        }
        private void InsertData()
        {
            try
            {
                string sql = string.Empty;
                sql = $@"Insert into tbl_QTDaoTao(MaNhanVien, TuNgay, DenNgay, SoQuyetDinh, NoiDung, HinhThuc, NgayTao, NguoiTao, del_flg)
                        Values({SQLHelper.rpStr(_MaNhanVien)}, {SQLHelper.rpDT(_TuNgay)}, {SQLHelper.rpDT(_DenNgay)}, 
                        {SQLHelper.rpStr(_SoQuyetDinh)}, {SQLHelper.rpStr(_NoiDung)}, {SQLHelper.rpI(_HinhThuc)}, 
                        '{DateTime.Now}', {SQLHelper.rpStr(_NguoiTao)}, 0)";
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
                sql = $@"Update tbl_QTDaoTao Set TuNgay = {SQLHelper.rpDT(_TuNgay)}, DenNgay = {SQLHelper.rpDT(_DenNgay)},
                SoQuyetDinh = {SQLHelper.rpStr(_SoQuyetDinh)}, NoiDung ={SQLHelper.rpStr(_NoiDung)}, HinhThuc = {SQLHelper.rpI(_HinhThuc)},
                NgayCapNhat = '{DateTime.Now}', NguoiCapNhat = {SQLHelper.rpStr(_NguoiCapNhat)}
                Where Id = {SQLHelper.rpI(_IdDaoTao)}";

                if (SQLHelper.ExecuteSql(sql) == 1)
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
        private void btn_close_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        private void SetValues()
        {
            _TuNgay = string.IsNullOrEmpty(dtp_TuNgay.Text) ? (DateTime?)null : DateTime.Parse(dtp_TuNgay.Text);
            _DenNgay = string.IsNullOrEmpty(dtp_DenNgay.Text) ? (DateTime?)null : DateTime.Parse(dtp_DenNgay.Text);
            _SoQuyetDinh = txt_SoQuyetDinh.Text.Trim();
            _HinhThuc = Convert.ToInt32(cbo_HinhThuc.SelectedValue);
            _NoiDung = txt_NoiDung.Text.Trim();
            _NguoiTao = SQLHelper.sUser;
            _NguoiCapNhat = SQLHelper.sUser;
        }
    }
}