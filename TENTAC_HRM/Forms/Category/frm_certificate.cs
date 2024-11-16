using System;
using System.Data;
using System.Linq;
using System.Windows.Forms;
using TENTAC_HRM.Custom;
using TENTAC_HRM.Forms.Main;

namespace TENTAC_HRM.Forms.Category
{
    public partial class frm_certificate : Form
    {
        DataProvider provider = new DataProvider();
        public string _ma_nhanvien { get; set; } = "0";
        public int _id_chungchi { get; set; }
        public bool edit { get; set; }
        frm_personnel _Personnel;
        string maChungChi, truongDaoTao, xepLoai, ghiChu, nguoiTao = SQLHelper.sUser, nguoiCapNhat = SQLHelper.sUser;
        DateTime? ngayNhanBang;
        public frm_certificate(Form frm)
        {
            InitializeComponent();
            _Personnel = (frm_personnel)frm;
        }
        private void frm_certificate_Load(object sender, EventArgs e)
        {
            load_nhanvien();
            load_cboChungChi();
            load_xeploai();
            if(edit == true)
            {
                load_data();
            }
        }
        private void LoadNull()
        {
            cbo_ChungChi.SelectedValue = string.Empty;
            txt_Truong.Text = string.Empty;
            dtp_NgayNhanBang.Text = string.Empty;
            txtGhiChu.Text = string.Empty;
        }
        private void load_data()
        {
            string sql = string.Empty;
            sql = $@"Select * from tbl_NhanVienChungChi where Id = {SQLHelper.rpI(_id_chungchi)}";
            DataTable dt = SQLHelper.ExecuteDt(sql);
            if(dt.Rows.Count > 0)
            {
                cbo_ChungChi.SelectedValue = dt.Rows[0]["MaChungChi"].ToString();
                txt_Truong.Text = dt.Rows[0]["TruongDaoTao"].ToString();
                dtp_NgayNhanBang.Text = dt.Rows[0]["NgayNhanBang"].ToString();
                cbo_XepLoai.SelectedValue = dt.Rows[0]["XepLoai"].ToString();
                txtGhiChu.Text = dt.Rows[0]["GhiChu"].ToString();
            }
        }
        private void load_cboChungChi()
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

        private void load_xeploai()
        {
            cbo_XepLoai.DataSource = provider.load_xeploai();
            cbo_XepLoai.DisplayMember = "name";
            cbo_XepLoai.ValueMember = "id";
        }
        private void load_nhanvien()
        {
            cbo_NhanVien.DataSource = provider.load_nhanvien();
            cbo_NhanVien.DisplayMember = "name";
            cbo_NhanVien.ValueMember = "value";
            cbo_NhanVien.SelectedValue = _ma_nhanvien;
        }
        private void btn_close_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btn_save_Click(object sender, EventArgs e)
        {
            if(edit == true)
            {
                update_data();
            }
            else
            {
                insert_data();
            }
            //_Personnel.load_tinhoc();
        }
        private void insert_data()
        {
            try
            {
                //string sql = string.Format("insert into tbl_NhanVienChungChi(MaNhanVien, MaChungChi, truong_dao_tao,nam_nhan_bang,xep_loai,id_nguoi_tao) " +
                //    "values('{0}',N'{1}',N'{2}','{3}',N'{4}','{5}')",
                //    cbo_nhanvien.SelectedValue.ToString(), txt_tinhoc.Text, txt_truong.Text, DateTime.Parse(dtp_nam.Text).ToString("yyyy/MM/dd"), cbo_xeploai.SelectedValue.ToString(), SQLHelper.sIdUser);
                set_textvalue();
                string sql = string.Empty;
                sql = $@"Insert into tbl_NhanVienChungChi(MaNhanVien, MaChungChi, TruongDaoTao, NgayNhanBang, XepLoai, GhiChu, NgayTao, NguoiTao, del_flg)
                values({SQLHelper.rpStr(_ma_nhanvien)}, {SQLHelper.rpStr(maChungChi)}, {SQLHelper.rpStr(truongDaoTao)}, {SQLHelper.rpDT(ngayNhanBang)},
                {SQLHelper.rpStr(xepLoai)}, {SQLHelper.rpStr(ghiChu)}, '{DateTime.Now}', {SQLHelper.rpStr(nguoiTao)}, 0)";
                if (SQLHelper.ExecuteSql(sql) == 1)
                {
                    RJMessageBox.Show("Thêm thành công", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    _Personnel.load_chungchi();
                    LoadNull();
                }
            }
            catch(Exception ex)
            {
                RJMessageBox.Show(ex.Message, "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void update_data()
        {
            try
            {
                //string sql = string.Format("update tin_hoc set tin_hoc = N'{1}', truong_dao_tao = N'{2}',nam_nhan_bang='{3}',xep_loai= N'{4}',ngay_cap_nhat = GETDATE(),id_nguoi_tao = '{5}' " +
                //    "where id_tin_hoc = '{0}'",_id_tinhoc,
                //    txt_tinhoc.Text,txt_truong.Text,DateTime.Parse(dtp_nam.Text).ToString("yyyy/MM/dd"),cbo_xeploai.SelectedValue.ToString(), SQLHelper.sIdUser);
                set_textvalue();
                string sql = string.Empty;
                sql = $@"Update tbl_NhanVienChungChi Set TruongDaoTao = {SQLHelper.rpStr(truongDaoTao)}, 
                NgayNhanBang = {SQLHelper.rpDT(ngayNhanBang)}, XepLoai = {SQLHelper.rpStr(xepLoai)}, GhiChu = {SQLHelper.rpStr(ghiChu)}, 
                NgayCapNhat = '{DateTime.Now}', NguoiCapNhat = {SQLHelper.rpStr(nguoiCapNhat)}
                Where Id = {SQLHelper.rpI(_id_chungchi)}";
                if(SQLHelper.ExecuteSql(sql) ==1 )
                {
                    RJMessageBox.Show("Cập nhật thành công", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    _Personnel.load_chungchi();
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
            maChungChi = cbo_ChungChi.SelectedValue.ToString();
            truongDaoTao = txt_Truong.Text.Trim().ToString();
            ngayNhanBang = string.IsNullOrEmpty(dtp_NgayNhanBang.Text) ? (DateTime?)null : DateTime.Parse(dtp_NgayNhanBang.Text);
            xepLoai = cbo_XepLoai.SelectedValue.ToString();
            ghiChu = txtGhiChu.Text.Trim().ToString();
        }
    }
}
