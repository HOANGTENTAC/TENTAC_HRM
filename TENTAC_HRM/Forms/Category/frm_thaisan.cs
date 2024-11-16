using System;
using System.Data;
using System.Windows.Forms;
using TENTAC_HRM.Custom;
using TENTAC_HRM.Forms.Main;
using TENTAC_HRM.Forms.User_control;

namespace TENTAC_HRM.Forms.Category
{
    public partial class frm_thaisan : Form
    {
        public bool edit;
        DataProvider provider = new DataProvider();
        public string _ma_nhan_vien { get; set; }
        public int _id_thai_san { get; set; }
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
        private void load_nhanvien()
        {
            cbo_NhanVien.DataSource = provider.load_nhanvien();
            cbo_NhanVien.DisplayMember = "name";
            cbo_NhanVien.ValueMember = "value";
            cbo_NhanVien.SelectedValue = _ma_nhan_vien;
        }
        private void LoadNull()
        {
            dtp_TuNgay.Text = string.Empty;
            dtp_DenNgay.Text = string.Empty;
            txt_GhiChu.Text = string.Empty;
        }
        private void frm_thaisan_Load(object sender, EventArgs e)
        {
            load_nhanvien();
            if (edit == true)
            {
                btn_save.Text = "Cập nhật";
                string sql = string.Format("select * from tbl_NhanVienThaiSan where Id='{0}'", _id_thai_san);
                DataTable dt = SQLHelper.ExecuteDt(sql);
                if(dt.Rows.Count>0)
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
                update_data();
            }
            else
            {
                insert_data();
            }
            if (_quatrinh != null)
            {
                _quatrinh.load_thaisan();
            }
            else
            {
                _Personnel.load_thaisan();
            }
        }
        private void insert_data()
        {
            try
            {
                string sql = string.Empty;
                sql = $@"Insert into tbl_NhanVienThaiSan(MaNhanVien, TuNgay, DenNgay, GhiChu, NgayTao, NguoiTao, del_flg)
                values({SQLHelper.rpStr(_ma_nhan_vien)}, {SQLHelper.rpDT(_TuNgay)}, {SQLHelper.rpDT(_DenNgay)}, 
                {SQLHelper.rpStr(_GhiChu)}, '{DateTime.Now}', {SQLHelper.rpStr(_NguoiTao)}, 0)";
                if (SQLHelper.ExecuteSql(sql) == 1)
                {
                    RJMessageBox.Show("Thêm thành công", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    _Personnel.load_thaisan();
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
               string sql = string.Empty;
                sql = $@"Update tbl_NhanVienThaiSan Set TuNgay = {SQLHelper.rpDT(_TuNgay)}, DenNgay = {SQLHelper.rpDT(_DenNgay)},
                GhiChu = {SQLHelper.rpStr(_GhiChu)}, NgayCapNhat = '{DateTime.Now}', NguoiCapNhat = {SQLHelper.rpStr(_NguoiCapNhat)}
                Where Id = {SQLHelper.rpI(_id_thai_san)}";
                if (SQLHelper.ExecuteSql(sql) == 1)
                {
                    RJMessageBox.Show("Cập nhật thành công", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    _Personnel.load_thaisan();
                    LoadNull();
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
            _NguoiTao = SQLHelper.sUser;
            _NguoiCapNhat = SQLHelper.sUser;
        }
        private void btn_close_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
