using System;
using System.ComponentModel.DataAnnotations;
using System.Data;
using System.Linq;
using System.Windows.Forms;
using TENTAC_HRM.Custom;
using TENTAC_HRM.Forms.Main;

namespace TENTAC_HRM.Forms.Category
{
    public partial class frm_language : Form
    {
        DataProvider provider = new DataProvider();
        public string _ma_nhanvien { get; set; }
        public int _id_ngoaingu { get; set; }
        public bool edit { get; set; }
        frm_personnel _Personnel;

        string maNgoaiNgu, truongDaoTao, xepLoai, ghiChu, nguoiTao, nguoiCapNhat;
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
                update_data();
            }
            else
            {
                insert_data();
            }
            //_Personnel.load_ngoaingu();
        }

        private void frm_language_Load(object sender, EventArgs e)
        {
            load_nhanvien();
            load_xeploai();
            load_NgoaiNgu();
            if (edit == true)
            {
                load_data();
            }
        }
        private void load_NgoaiNgu()
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
        private void load_xeploai()
        {
            cbo_XepLoai.DataSource = provider.load_xeploai();
            cbo_XepLoai.DisplayMember = "name";
            cbo_XepLoai.ValueMember = "id";
        }
        private void load_data()
        {
            string sql = string.Empty;
            sql = $@"select * from tbl_NhanVienNgoaiNgu where Id = {SQLHelper.rpI(_id_ngoaingu)}";
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
        private void load_nhanvien()
        {
            cbo_NhanVien.DataSource = provider.load_nhanvien();
            cbo_NhanVien.DisplayMember = "name";
            cbo_NhanVien.ValueMember = "value";
            cbo_NhanVien.SelectedValue = _ma_nhanvien;
        }
        private void load_XepLoai()
        {
            cbo_XepLoai.DataSource = provider.load_xeploai();
            cbo_XepLoai.DisplayMember = "name";
            cbo_XepLoai.ValueMember = "id";
        }
        private void insert_data()
        {
            try
            {
                if (cbo_NgoaiNgu.SelectedIndex == 0)
                {
                    RJMessageBox.Show("Vui lòng chọn Ngoại Ngữ", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    cbo_NgoaiNgu.Focus();
                    return;
                }
                set_textvalue();
                string sql = string.Empty;
                sql = $@"Insert into tbl_NhanVienNgoaiNgu(MaNhanVien, MaNgoaiNgu, TruongDaoTao, NgayNhanBang, XepLoai, GhiChu,
                    NgayTao, NguoiTao, del_flg)
                    values({SQLHelper.rpStr(_ma_nhanvien)}, {SQLHelper.rpStr(maNgoaiNgu)}, {SQLHelper.rpStr(truongDaoTao)},
                    {SQLHelper.rpDT(ngayNhanBang)}, {SQLHelper.rpStr(xepLoai)}, {SQLHelper.rpStr(ghiChu)}, '{DateTime.Now}', 
                    {SQLHelper.rpStr(nguoiTao)}, 0)";

                if (SQLHelper.ExecuteSql(sql) == 1)
                {
                    RJMessageBox.Show("Thêm thành công", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    _Personnel.load_ngoaingu();
                    LoadNull();
                }
            }
            catch (Exception ex)
            {
                RJMessageBox.Show(ex.Message, "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void update_data()
        {
            try
            {
                set_textvalue();
                string sql = string.Empty;
                sql = $@"Update tbl_NhanVienNgoaiNgu set TruongDaoTao = {SQLHelper.rpStr(truongDaoTao)}, 
                        NgayNhanBang = {SQLHelper.rpDT(ngayNhanBang)}, XepLoai = {SQLHelper.rpStr(xepLoai)}, 
                        GhiChu = {SQLHelper.rpStr(ghiChu)}, NgayCapNhat = '{DateTime.Now}', 
                        NguoiCapNhat = {SQLHelper.rpStr(nguoiCapNhat)}
                        Where Id = {SQLHelper.rpI(_id_ngoaingu)}";

                if (SQLHelper.ExecuteSql(sql) == 1)
                {
                    RJMessageBox.Show("Cập nhật thành công", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    _Personnel.load_ngoaingu();
                    LoadNull();
                }
            }
            catch (Exception ex)
            {
                RJMessageBox.Show(ex.Message, "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void set_textvalue()
        {
            maNgoaiNgu = cbo_NgoaiNgu.SelectedValue.ToString();
            truongDaoTao = txt_Truong.Text.Trim().ToString();
            ngayNhanBang = string.IsNullOrEmpty(dtp_NgayNhanBang.Text) ? (DateTime?)null : DateTime.Parse(dtp_NgayNhanBang.Text);
            xepLoai = cbo_XepLoai.SelectedValue.ToString();
            ghiChu = txtGhiChu.Text;
            nguoiTao = SQLHelper.sUser;
            nguoiCapNhat = SQLHelper.sUser;
        }
    }
}
