using ComponentFactory.Krypton.Toolkit;
using System;
using System.Data;
using System.Windows.Forms;
using TENTAC_HRM.Consts;
using TENTAC_HRM.Custom;
using TENTAC_HRM.Forms.Main;
using TENTAC_HRM.Forms.NhanSu;
using TENTAC_HRM.Forms.User_control;

namespace TENTAC_HRM.Forms.Category
{
    public partial class frm_thaisan : KryptonForm
    {
        public bool edit;
        DataProvider provider = new DataProvider();
        public string _MaNhanVien { get; set; }
        public int _IdThaiSan { get; set; }
        frm_personnel _Personnel;
        uc_quatrinh_lamviec _quatrinh;
        string _GhiChu, _NguoiTao, _NguoiCapNhat;
        DateTime? _TuNgay, _DenNgay;
        public frm_thaisan(Form form, UserControl user)
        {
            InitializeComponent();
            _quatrinh = (uc_quatrinh_lamviec)user;
            _Personnel = (frm_personnel)form;
        }
        private void LoadComboboxNhanVien()
        {
            cbo_NhanVien.DataSource = provider.load_nhanvien();
            cbo_NhanVien.DisplayMember = "name";
            cbo_NhanVien.ValueMember = "value";
            cbo_NhanVien.SelectedValue = _MaNhanVien;
        }
        private void LoadNull()
        {
            dtp_TuNgay.Text = string.Empty;
            dtp_DenNgay.Text = string.Empty;
            txt_GhiChu.Text = string.Empty;
        }
        private void frm_thaisan_Load(object sender, EventArgs e)
        {
            LoadComboboxNhanVien();
            if (edit == true)
            {
                btn_save.Text = "Cập nhật";
                string sql = string.Format("select * from tbl_NhanVienThaiSan where Id='{0}'", _IdThaiSan);
                DataTable dt = SQLHelper.ExecuteDt(sql);
                if (dt.Rows.Count > 0)
                {
                    dtp_TuNgay.Text = dt.Rows[0]["TuNgay"].ToString();
                    dtp_DenNgay.Text = dt.Rows[0]["DenNgay"].ToString();
                    txt_GhiChu.Text = dt.Rows[0]["GhiChu"].ToString();
                }
            }
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
            _quatrinh.LoadQTThaiSan();
            LoadNull();
        }
        private void InsertData()
        {
            try
            {
                string sql = string.Empty;
                sql = $@"Insert into tbl_NhanVienThaiSan(MaNhanVien, TuNgay, DenNgay, GhiChu, NgayTao, NguoiTao, del_flg)
                values({SQLHelper.rpStr(_MaNhanVien)}, {SQLHelper.rpDT(_TuNgay)}, {SQLHelper.rpDT(_DenNgay)}, 
                {SQLHelper.rpStr(_GhiChu)}, '{DateTime.Now}', {SQLHelper.rpStr(_NguoiTao)}, 0)";
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
                sql = $@"Update tbl_NhanVienThaiSan Set TuNgay = {SQLHelper.rpDT(_TuNgay)}, DenNgay = {SQLHelper.rpDT(_DenNgay)},
                GhiChu = {SQLHelper.rpStr(_GhiChu)}, NgayCapNhat = '{DateTime.Now}', NguoiCapNhat = {SQLHelper.rpStr(_NguoiCapNhat)}
                Where Id = {SQLHelper.rpI(_IdThaiSan)}";
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
            _TuNgay = string.IsNullOrEmpty(dtp_TuNgay.Text) ? (DateTime?)null : DateTime.Parse(dtp_TuNgay.Text);
            _DenNgay = string.IsNullOrEmpty(dtp_DenNgay.Text) ? (DateTime?)null : DateTime.Parse(dtp_DenNgay.Text);
            _GhiChu = txt_GhiChu.Text.Trim();
            _NguoiTao = LoginInfo.UserCd;
            _NguoiCapNhat = LoginInfo.UserCd;
        }
        private void btn_close_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}