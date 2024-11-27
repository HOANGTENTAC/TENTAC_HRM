using ComponentFactory.Krypton.Toolkit;
using System;
using System.Data;
using System.Linq;
using System.Windows.Forms;
using TENTAC_HRM.Custom;
using TENTAC_HRM.Forms.Main;

namespace TENTAC_HRM.Forms.Category
{
    public partial class frm_pecialize : KryptonForm
    {
        frm_personnel personnel;
        public int _IdDaoTao { get; set; }
        public string _MaNhanVien { get; set; }
        public bool edit { get; set; }
        DataProvider provider = new DataProvider();
        int _Active, _HeDaoTao;
        string _LoaiDaoTao, _BacDaoTao, _NganhDaoTao, _TruongDaoTao, _XepLoai, _GhiChu, _NguoiTao = SQLHelper.sUser, _NguoiCapNhat = SQLHelper.sUser;
        DateTime? TuNam_value, DenNam_value, NgayNhanBang_value;
        public frm_pecialize(frm_personnel _personnel)
        {
            InitializeComponent();
            personnel = _personnel;
        }
        private void frm_train_Load(object sender, EventArgs e)
        {
            LoadComboboxNhanVien();
            LoadComboboxBacDaoTao();
            LoadComboboxNganhDaoTao();
            LoadComboboxHeDaoTao();
            LoadComboboxXepLoai();
            if (edit == true)
            {
                LoadData();
            }
        }
        private void LoadNull()
        {
            cbo_BacDaoTao.SelectedValue = string.Empty;
            cbo_HeDaoTao.SelectedValue = "0";
            cbo_NganhDaoTao.SelectedValue = string.Empty;
            txt_truongdaotao.Text = string.Empty;
            dtp_TuNam.Text = string.Empty;
            dtp_DenNam.Text = string.Empty;
            dtp_NamNhanBang.Text = string.Empty;
            chk_active.Checked = false;
            cbo_XepLoai.SelectedIndex = 0;
            txt_ghichu.Text = string.Empty;
        }
        private void LoadData()
        {
            string sql = string.Format("select * from tbl_NhanVienDaoTao where Id = {0}", _IdDaoTao);
            DataTable dt = new DataTable();
            dt = SQLHelper.ExecuteDt(sql);
            if (dt.Rows.Count > 0)
            {
                //cbo_LoaiDaoTao.SelectedValue = dt.Rows[0]["LoaiDaoTao"];
                cbo_BacDaoTao.SelectedValue = dt.Rows[0]["MaBacDaoTao"].ToString();
                cbo_HeDaoTao.SelectedValue = dt.Rows[0]["Id_HeDaoTao"];
                cbo_NganhDaoTao.SelectedValue = dt.Rows[0]["MaNganhDaoTao"].ToString();
                dtp_TuNam.Text = dt.Rows[0]["TuNgay"].ToString();
                dtp_DenNam.Text = dt.Rows[0]["DenNgay"].ToString();
                dtp_NamNhanBang.Text = dt.Rows[0]["NgayNhanBang"].ToString();
                txt_truongdaotao.Text = dt.Rows[0]["TruongDaoTao"].ToString();
                cbo_XepLoai.SelectedValue = dt.Rows[0]["XepLoaiBang"];
                txt_ghichu.Text = dt.Rows[0]["GhiChu"].ToString();
                chk_active.Checked = bool.Parse(dt.Rows[0]["IsActive"].ToString());
            }
        }
        private void LoadComboboxNhanVien()
        {
            cbo_NhanVien.DataSource = provider.load_nhanvien();
            cbo_NhanVien.DisplayMember = "name";
            cbo_NhanVien.ValueMember = "value";
            cbo_NhanVien.SelectedValue = _MaNhanVien;
        }
        private void LoadComboboxHeDaoTao()
        {
            string sql = "select Id, TenHe from mst_HeDaoTao";
            DataTable dt = new DataTable();
            dt = SQLHelper.ExecuteDt(sql);
            dt.Rows.Add(0, "");
            cbo_HeDaoTao.DataSource = dt.Rows.Cast<DataRow>().OrderBy(x => x.Field<int>("Id")).CopyToDataTable();
            cbo_HeDaoTao.DisplayMember = "TenHe";
            cbo_HeDaoTao.ValueMember = "Id";
        }
        private void LoadComboboxNganhDaoTao()
        {
            string sql = "select MaChuyenNganh, TenChuyenNganh from mst_ChuyenNganh";
            DataTable dt = new DataTable();
            dt = SQLHelper.ExecuteDt(sql);
            dt.Rows.Add("", "");
            cbo_NganhDaoTao.DataSource = dt.Rows.Cast<DataRow>().OrderBy(x => x.Field<string>("MaChuyenNganh")).CopyToDataTable();
            cbo_NganhDaoTao.DisplayMember = "TenChuyenNganh";
            cbo_NganhDaoTao.ValueMember = "MaChuyenNganh";
        }
        private void LoadComboboxBacDaoTao()
        {
            string sql = "select MaBac,TenBac from mst_BacDaoTao";
            DataTable dt = new DataTable();
            dt = SQLHelper.ExecuteDt(sql);
            dt.Rows.Add("", "");
            cbo_BacDaoTao.DataSource = dt.Rows.Cast<DataRow>().OrderBy(x => x.Field<string>("MaBac")).CopyToDataTable();
            cbo_BacDaoTao.DisplayMember = "TenBac";
            cbo_BacDaoTao.ValueMember = "MaBac";
        }
        private void LoadComboboxXepLoai()
        {
            cbo_XepLoai.DataSource = provider.load_xeploai();
            cbo_XepLoai.DisplayMember = "name";
            cbo_XepLoai.ValueMember = "id";
        }

        //private void load_loaidaotao()
        //{
        //    cbo_LoaiDaoTao.DataSource = provider.load_all_type(70);
        //    cbo_LoaiDaoTao.DisplayMember = "name";
        //    cbo_LoaiDaoTao.ValueMember = "id";
        //}

        private void btn_save_add_Click(object sender, EventArgs e)
        {
            if (edit == true)
            {
                UpdateData();
            }
            else
            {
                InsertData();
            }
            LoadNull();
            personnel.LoadNhanVienChuyenMon();
        }
        private void UpdateData()
        {
            try
            {
                SetValues();
                string sql = string.Empty;
                sql = $@"Update tbl_NhanVienDaoTao 
                    set MaBacDaoTao = {SQLHelper.rpStr(_BacDaoTao)}, Id_HeDaoTao = {SQLHelper.rpI(_HeDaoTao)}, 
                    MaNganhDaoTao = {SQLHelper.rpStr(_NganhDaoTao)}, TruongDaoTao = {SQLHelper.rpStr(_TruongDaoTao)},
                    TuNgay = {SQLHelper.rpDT(TuNam_value)}, DenNgay = {SQLHelper.rpDT(DenNam_value)}, NgayNhanBang = {SQLHelper.rpDT(NgayNhanBang_value)}, 
                    XepLoaiBang = {SQLHelper.rpStr(_XepLoai)}, GhiChu = {SQLHelper.rpStr(_GhiChu)},
                    NgayCapNhat = '{DateTime.Now}', NguoiCapNhat = {SQLHelper.rpStr(_NguoiCapNhat)}
                    where Id = {SQLHelper.rpI(_IdDaoTao)}";
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
        private void btn_save_close_Click(object sender, EventArgs e)
        {
            if (edit == true)
            {
                UpdateData();
            }
            else
            {
                InsertData();
            }
            LoadNull();
            personnel.LoadNhanVienChuyenMon();
            this.Close();
        }
        private void InsertData()
        {
            try
            {
                SetValues();
                string sql = string.Empty;
                sql = $@"insert into tbl_NhanVienDaoTao(MaNhanVien, IsActive, MaBacDaoTao, Id_HeDaoTao, 
                    MaNganhDaoTao, TruongDaoTao, TuNgay, DenNgay, NgayNhanBang, XepLoaiBang, GhiChu, NgayTao, NguoiTao) 
                    values ({SQLHelper.rpStr(_MaNhanVien)}, {SQLHelper.rpI(_Active)}, {SQLHelper.rpStr(_BacDaoTao)},
                    {SQLHelper.rpI(_HeDaoTao)}, {SQLHelper.rpStr(_NganhDaoTao)}, {SQLHelper.rpStr(_TruongDaoTao)}, 
                    {SQLHelper.rpDT(TuNam_value)}, {SQLHelper.rpDT(DenNam_value)},{SQLHelper.rpDT(NgayNhanBang_value)}, 
                    {SQLHelper.rpStr(_XepLoai)}, {SQLHelper.rpStr(_GhiChu)}, '{DateTime.Now}', {SQLHelper.rpStr(_NguoiTao)})";
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
        private void btn_close_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        private void SetValues()
        {
            _Active = (chk_active.Checked == true ? 1 : 0);
            //_LoaiDaoTao = cbo_LoaiDaoTao.SelectedValue.ToString();
            _BacDaoTao = cbo_BacDaoTao.SelectedValue.ToString();
            _HeDaoTao = Convert.ToInt32(cbo_HeDaoTao.SelectedValue);
            _NganhDaoTao = cbo_NganhDaoTao.SelectedValue?.ToString() ?? "";
            _TruongDaoTao = txt_truongdaotao.Text;
            TuNam_value = string.IsNullOrEmpty(dtp_TuNam.Text) ? (DateTime?)null : DateTime.Parse(dtp_TuNam.Text);
            DenNam_value = string.IsNullOrEmpty(dtp_DenNam.Text) ? (DateTime?)null : DateTime.Parse(dtp_DenNam.Text);
            NgayNhanBang_value = string.IsNullOrEmpty(dtp_NamNhanBang.Text) ? (DateTime?)null : DateTime.Parse(dtp_NamNhanBang.Text);
            _XepLoai = cbo_XepLoai.SelectedValue.ToString();
            _GhiChu = txt_ghichu.Text;
            _NguoiTao = SQLHelper.sUser;
            _NguoiCapNhat = SQLHelper.sUser;
        }
        private void frm_pecialize_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
            {
                this.Close();
            }
        }
    }
}
