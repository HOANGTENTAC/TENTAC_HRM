using ComponentFactory.Krypton.Toolkit;
using System;
using System.Data;
using System.Linq;
using System.Windows.Forms;
using TENTAC_HRM.Consts;
using TENTAC_HRM.Custom;
using TENTAC_HRM.Forms.NhanSu;

namespace TENTAC_HRM.Forms.Category
{
    public partial class frm_language : KryptonForm
    {
        DataProvider provider = new DataProvider();
        public string _MaNhanVien { get; set; }
        public int _IdNgoaiNgu { get; set; }
        public bool edit { get; set; }
        frm_personnel _Personnel;
        string _MaNgoaiNgu, _TruongDaoTao, _XepLoai, _GhiChu, _NguoiTao, _NguoiCapNhat;
        DateTime? ngayNhanBang;
        public frm_language(Form frm)
        {
            InitializeComponent();
            _Personnel = (frm_personnel)frm;
        }
        private void btn_close_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        private void btn_save_Click(object sender, EventArgs e)
        {
            if (edit == true)
            {
                UpdateData();
            }
            else
            {
                InsertData();
            }
            _Personnel.LoadNhanVienNgoaiNgu();
            LoadNull();
        }
        private void frm_language_Load(object sender, EventArgs e)
        {
            LoadComboboxNhanVien();
            LoadComboboxXepLoai();
            LoadComboboxNgoaiNgu();
            if (edit == true)
            {
                LoadData();
            }
        }
        private void LoadComboboxNgoaiNgu()
        {
            string sql = string.Empty;
            sql = $@"select MaNgoaiNgu, TenNgoaiNgu from mst_NgoaiNgu";
            DataTable dt = new DataTable();
            dt = SQLHelper.ExecuteDt(sql);
            dt.Rows.Add("", "");
            cbo_NgoaiNgu.DataSource = dt.Rows.Cast<DataRow>().OrderBy(x => x.Field<string>("MaNgoaiNgu")).CopyToDataTable();
            cbo_NgoaiNgu.DisplayMember = "TenNgoaiNgu";
            cbo_NgoaiNgu.ValueMember = "MaNgoaiNgu";
        }
        private void LoadComboboxXepLoai()
        {
            cbo_XepLoai.DataSource = provider.load_xeploai();
            cbo_XepLoai.DisplayMember = "name";
            cbo_XepLoai.ValueMember = "id";
        }
        private void LoadData()
        {
            string sql = string.Empty;
            sql = $@"select * from tbl_NhanVienNgoaiNgu where Id = {SQLHelper.rpI(_IdNgoaiNgu)}";
            DataTable dt = SQLHelper.ExecuteDt(sql);
            if (dt.Rows.Count > 0)
            {
                cbo_NgoaiNgu.SelectedValue = dt.Rows[0]["MaNgoaiNgu"].ToString();
                txt_Truong.Text = dt.Rows[0]["TruongDaoTao"].ToString();
                dtp_NgayNhanBang.Text = dt.Rows[0]["NgayNhanBang"].ToString();
                cbo_XepLoai.SelectedValue = dt.Rows[0]["XepLoai"].ToString();
                txtGhiChu.Text = dt.Rows[0]["GhiChu"].ToString();
            }
        }
        private void LoadNull()
        {
            cbo_NgoaiNgu.SelectedValue = string.Empty;
            txt_Truong.Text = string.Empty;
            dtp_NgayNhanBang.Text= string.Empty;
            cbo_XepLoai.SelectedIndex = 0;
            txtGhiChu.Text= string.Empty;
        }
        private void LoadComboboxNhanVien()
        {
            cbo_NhanVien.DataSource = provider.load_nhanvien();
            cbo_NhanVien.DisplayMember = "name";
            cbo_NhanVien.ValueMember = "value";
            cbo_NhanVien.SelectedValue = _MaNhanVien;
        }
        private void InsertData()
        {
            try
            {
                if (cbo_NgoaiNgu.SelectedIndex == 0)
                {
                    RJMessageBox.Show("Vui lòng chọn Ngoại Ngữ", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    cbo_NgoaiNgu.Focus();
                    return;
                }
                SetValues();
                string sql = string.Empty;
                sql = $@"Insert into tbl_NhanVienNgoaiNgu(MaNhanVien, MaNgoaiNgu, TruongDaoTao, NgayNhanBang, XepLoai, GhiChu,
                    NgayTao, NguoiTao, del_flg)
                    values({SQLHelper.rpStr(_MaNhanVien)}, {SQLHelper.rpStr(_MaNgoaiNgu)}, {SQLHelper.rpStr(_TruongDaoTao)},
                    {SQLHelper.rpDT(ngayNhanBang)}, {SQLHelper.rpStr(_XepLoai)}, {SQLHelper.rpStr(_GhiChu)}, '{DateTime.Now}', 
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
                SetValues();
                string sql = string.Empty;
                sql = $@"Update tbl_NhanVienNgoaiNgu set TruongDaoTao = {SQLHelper.rpStr(_TruongDaoTao)}, 
                        NgayNhanBang = {SQLHelper.rpDT(ngayNhanBang)}, XepLoai = {SQLHelper.rpStr(_XepLoai)}, 
                        GhiChu = {SQLHelper.rpStr(_GhiChu)}, NgayCapNhat = '{DateTime.Now}', 
                        NguoiCapNhat = {SQLHelper.rpStr(_NguoiCapNhat)}
                        Where Id = {SQLHelper.rpI(_IdNgoaiNgu)}";

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
        private void SetValues()
        {
            _MaNgoaiNgu = cbo_NgoaiNgu.SelectedValue.ToString();
            _TruongDaoTao = txt_Truong.Text.Trim().ToString();
            ngayNhanBang = string.IsNullOrEmpty(dtp_NgayNhanBang.Text) ? (DateTime?)null : DateTime.Parse(dtp_NgayNhanBang.Text);
            _XepLoai = cbo_XepLoai.SelectedValue.ToString();
            _GhiChu = txtGhiChu.Text;
            _NguoiTao = LoginInfo.UserCd;
            _NguoiCapNhat = LoginInfo.UserCd;
        }
    }
}