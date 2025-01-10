using ComponentFactory.Krypton.Toolkit;
using System;
using System.Data;
using System.Linq;
using System.Windows.Forms;
using TENTAC_HRM.Custom;
using TENTAC_HRM.Forms.NhanSu;

namespace TENTAC_HRM.Forms.Category
{
    public partial class frm_certificate : KryptonForm
    {
        DataProvider provider = new DataProvider();
        public string _MaNhanVien { get; set; }
        public int _IdChungChi { get; set; }
        public bool edit { get; set; }
        frm_personnel _Personnel;
        string _MaChungChi, _TruongDaoTao, _XepLoai, _GhiChu, _NguoiTao = SQLHelper.sUser, _NguoiCapNhat = SQLHelper.sUser;
        DateTime? _NgayNhanBang;
        public frm_certificate(Form frm)
        {
            InitializeComponent();
            _Personnel = (frm_personnel)frm;
        }
        private void frm_certificate_Load(object sender, EventArgs e)
        {
            LoadComboboxNhanVien();
            LoadComboboxChungChi();
            LoadComboboxXepLoai();
            if (edit == true)
            {
                LoadData();
            }
        }
        private void LoadNull()
        {
            cbo_ChungChi.SelectedValue = string.Empty;
            txt_Truong.Text = string.Empty;
            dtp_NgayNhanBang.Text = string.Empty;
            txtGhiChu.Text = string.Empty;
        }
        private void LoadData()
        {
            string sql = string.Empty;
            sql = $@"Select * from tbl_NhanVienChungChi where Id = {SQLHelper.rpI(_IdChungChi)}";
            DataTable dt = SQLHelper.ExecuteDt(sql);
            if (dt.Rows.Count > 0)
            {
                cbo_ChungChi.SelectedValue = dt.Rows[0]["MaChungChi"].ToString();
                txt_Truong.Text = dt.Rows[0]["TruongDaoTao"].ToString();
                dtp_NgayNhanBang.Text = dt.Rows[0]["NgayNhanBang"].ToString();
                cbo_XepLoai.SelectedValue = dt.Rows[0]["XepLoai"].ToString();
                txtGhiChu.Text = dt.Rows[0]["GhiChu"].ToString();
            }
        }
        private void LoadComboboxChungChi()
        {
            string sql = string.Empty;
            sql = $@"Select MaChungChi, TenChungChi from mst_ChungChi";
            DataTable dt = SQLHelper.ExecuteDt(sql);
            dt = SQLHelper.ExecuteDt(sql);
            dt.Rows.Add("", "");
            cbo_ChungChi.DataSource = dt.Rows.Cast<DataRow>().OrderBy(x => x.Field<string>("MaChungChi")).CopyToDataTable();
            cbo_ChungChi.DisplayMember = "TenChungChi";
            cbo_ChungChi.ValueMember = "MaChungChi";
        }

        private void LoadComboboxXepLoai()
        {
            cbo_XepLoai.DataSource = provider.load_xeploai();
            cbo_XepLoai.DisplayMember = "name";
            cbo_XepLoai.ValueMember = "id";
        }
        private void LoadComboboxNhanVien()
        {
            cbo_NhanVien.DataSource = provider.load_nhanvien();
            cbo_NhanVien.DisplayMember = "name";
            cbo_NhanVien.ValueMember = "value";
            cbo_NhanVien.SelectedValue = _MaNhanVien;
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
            _Personnel.LoadNhanVienChungChi();
            LoadNull();
        }
        private void InsertData()
        {
            try
            {
                string sql = string.Empty;
                sql = $@"Insert into tbl_NhanVienChungChi(MaNhanVien, MaChungChi, TruongDaoTao, NgayNhanBang, XepLoai, GhiChu, NgayTao, NguoiTao, del_flg)
                values({SQLHelper.rpStr(_MaNhanVien)}, {SQLHelper.rpStr(_MaChungChi)}, {SQLHelper.rpStr(_TruongDaoTao)}, {SQLHelper.rpDT(_NgayNhanBang)},
                {SQLHelper.rpStr(_XepLoai)}, {SQLHelper.rpStr(_GhiChu)}, '{DateTime.Now}', {SQLHelper.rpStr(_NguoiTao)}, 0)";
                if (SQLHelper.ExecuteSql(sql) == 1)
                {
                    RJMessageBox.Show("Thêm thông tin thành công", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    RJMessageBox.Show("Thêm thông tin thất bại", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
                sql = $@"Update tbl_NhanVienChungChi Set TruongDaoTao = {SQLHelper.rpStr(_TruongDaoTao)}, 
                NgayNhanBang = {SQLHelper.rpDT(_NgayNhanBang)}, XepLoai = {SQLHelper.rpStr(_XepLoai)}, GhiChu = {SQLHelper.rpStr(_GhiChu)}, 
                NgayCapNhat = '{DateTime.Now}', NguoiCapNhat = {SQLHelper.rpStr(_NguoiCapNhat)}
                Where Id = {SQLHelper.rpI(_IdChungChi)}";
                if (SQLHelper.ExecuteSql(sql) == 1)
                {
                    RJMessageBox.Show("Cập nhật thành công", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    RJMessageBox.Show("Cập nhật thông tin thất bại", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                RJMessageBox.Show(ex.Message, "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void SetValues()
        {
            _MaChungChi = cbo_ChungChi.SelectedValue.ToString();
            _TruongDaoTao = txt_Truong.Text.Trim().ToString();
            _NgayNhanBang = string.IsNullOrEmpty(dtp_NgayNhanBang.Text) ? (DateTime?)null : DateTime.Parse(dtp_NgayNhanBang.Text);
            _XepLoai = cbo_XepLoai.SelectedValue.ToString();
            _GhiChu = txtGhiChu.Text.Trim().ToString();
        }
    }
}