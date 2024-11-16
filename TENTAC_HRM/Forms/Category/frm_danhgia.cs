using System;
using System.Data;
using System.Windows.Forms;
using TENTAC_HRM.Custom;
using TENTAC_HRM.Forms.Main;
using TENTAC_HRM.Forms.User_control;

namespace TENTAC_HRM.Forms.Category
{
    public partial class frm_danhgia : Form
    {
        DataProvider provider = new DataProvider();
        public string _ma_nhan_vien { get; set; }
        public int _id_danh_gia;
        public bool _edit { get; set; }
        frm_personnel _personnel;
        uc_quatrinh_lamviec _quatrinh;
        string _NoiDung, _XepLoai, _NguoiTao, _NguoiCapNhat;
        decimal _DiemDanhGia;
        DateTime? _NgayDanhGia;

        public frm_danhgia(Form form, UserControl user)
        {
            InitializeComponent();
            _quatrinh = (uc_quatrinh_lamviec)user;
            _personnel = (frm_personnel)form;
        }
        private void load_nhanvien()
        {
            cbo_NhanVien.DataSource = provider.load_nhanvien();
            cbo_NhanVien.DisplayMember = "name";
            cbo_NhanVien.ValueMember = "value";
            cbo_NhanVien.SelectedValue = _ma_nhan_vien;
        }
        private void load_xeploai()
        {
            cbo_XepLoai.DataSource = provider.load_xeploai();
            cbo_XepLoai.DisplayMember = "name";
            cbo_XepLoai.ValueMember = "id";
        }
        private void load_data()
        {
            string sql = string.Format("select * from tbl_QTDanhGia where Id = '{0}'", _id_danh_gia);
            DataTable dataTable = new DataTable();
            dataTable = SQLHelper.ExecuteDt(sql);
            if (dataTable.Rows.Count > 0)
            {
                dtp_NgayDanhGia.Text = dataTable.Rows[0]["NgayDanhGia"].ToString();
                nr_DiemDanhGia.Value = decimal.Parse(dataTable.Rows[0]["DiemDanhGia"].ToString());
                cbo_XepLoai.SelectedValue = dataTable.Rows[0]["XepLoai"].ToString();
                txt_NoiDung.Text = dataTable.Rows[0]["NoiDung"].ToString();
            }
        }
        private void frm_danhgia_Load(object sender, EventArgs e)
        {
            load_nhanvien();
            load_xeploai();
            if (_edit == true)
            {
                load_data();
            }
        }
        private void LoadNull()
        {
            dtp_NgayDanhGia.Text = string.Empty;
            nr_DiemDanhGia.Value = 0;
            txt_NoiDung.Text = string.Empty;
        }
        public void insert_data()
        {
            try
            {
                string sql = string.Empty;
                sql = $@"Insert into tbl_QTDanhGia(MaNhanVien, NgayDanhGia, NoiDung, DiemDanhGia, XepLoai, NgayTao, NguoiTao, del_flg)
                        values({SQLHelper.rpStr(_ma_nhan_vien)}, {SQLHelper.rpDT(_NgayDanhGia)}, {SQLHelper.rpStr(_NoiDung)},
                        {SQLHelper.rpD(_DiemDanhGia)}, {SQLHelper.rpStr(_XepLoai)}, '{DateTime.Now}', {SQLHelper.rpStr(_NguoiTao)}, 0)";

                if (SQLHelper.ExecuteSql(sql) == 1)
                {
                    RJMessageBox.Show("Thêm thành công", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    _personnel.load_danhgia();
                    LoadNull();
                }
            }
            catch (Exception ex)
            {
                RJMessageBox.Show(ex.Message, "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        public void update_data()
        {
            try
            {
                string sql = string.Empty;
                sql = $@"Update tbl_QTDanhGia Set NgayDanhGia = {SQLHelper.rpDT(_NgayDanhGia)}, NoiDung = {SQLHelper.rpStr(_NoiDung)},
                DiemDanhGia = {SQLHelper.rpD(_DiemDanhGia)}, XepLoai = {SQLHelper.rpStr(_XepLoai)}, NgayCapNhat = '{DateTime.Now}', 
                NguoiCapNhat = {SQLHelper.rpStr(_NguoiCapNhat)}
                Where Id = {SQLHelper.rpI(_id_danh_gia)}";

                if (SQLHelper.ExecuteSql(sql) == 1)
                {
                    RJMessageBox.Show("cập nhật thành công", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    _personnel.load_danhgia();
                    LoadNull();
                }
            }
            catch (Exception ex)
            {
                RJMessageBox.Show(ex.Message, "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void btn_save_Click(object sender, EventArgs e)
        {
            SetValues();
            save_data();
            load_null();
        }
        private void save_data()
        {
            if (_edit == true)
            {
                update_data();
            }
            else
            {
                insert_data();
            }
            if (_quatrinh != null)
            {
                _quatrinh.load_danhgia();
            }
            else
            {
                _personnel.load_danhgia();
            }
        }
        private void SetValues()
        {
            _NgayDanhGia = string.IsNullOrEmpty(dtp_NgayDanhGia.Text) ? (DateTime?)null : DateTime.Parse(dtp_NgayDanhGia.Text);
            _NoiDung = txt_NoiDung.Text.Trim();
            _DiemDanhGia = Convert.ToDecimal(nr_DiemDanhGia.Value);
            _XepLoai = cbo_XepLoai.SelectedValue.ToString();
        }
        private void btn_close_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btn_save_exit_Click(object sender, EventArgs e)
        {
            save_data();
            this.Close();
        }
        private void load_null()
        {
            txt_NoiDung.Text = string.Empty;
            nr_DiemDanhGia.Value = 0;
            dtp_NgayDanhGia.Text = string.Empty;
        }
    }
}
