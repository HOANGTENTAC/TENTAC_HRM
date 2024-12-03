using ComponentFactory.Krypton.Toolkit;
using System;
using System.Data;
using System.Windows.Forms;
using TENTAC_HRM.Custom;
using TENTAC_HRM.Forms.Main;
using TENTAC_HRM.Forms.User_control;

namespace TENTAC_HRM.Forms.Category
{
    public partial class frm_danhgia : KryptonForm
    {
        DataProvider provider = new DataProvider();
        public string _MaNhanVien { get; set; }
        public int _IdDanhGia;
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
        private void LoadComboboxNhanVien()
        {
            cbo_NhanVien.DataSource = provider.load_nhanvien();
            cbo_NhanVien.DisplayMember = "name";
            cbo_NhanVien.ValueMember = "value";
            cbo_NhanVien.SelectedValue = _MaNhanVien;
        }
        private void LoadComboboxXepLoai()
        {
            cbo_XepLoai.DataSource = provider.load_xeploai();
            cbo_XepLoai.DisplayMember = "name";
            cbo_XepLoai.ValueMember = "id";
        }
        private void LoadData()
        {
            string sql = string.Format("select * from tbl_QTDanhGia where Id = '{0}'", _IdDanhGia);
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
            LoadComboboxNhanVien();
            LoadComboboxXepLoai();
            if (_edit == true)
            {
                LoadData();
            }
        }
        private void LoadNull()
        {
            dtp_NgayDanhGia.Text = string.Empty;
            nr_DiemDanhGia.Value = 0;
            txt_NoiDung.Text = string.Empty;
        }
        public void InsertData()
        {
            try
            {
                string sql = string.Empty;
                sql = $@"Insert into tbl_QTDanhGia(MaNhanVien, NgayDanhGia, NoiDung, DiemDanhGia, XepLoai, NgayTao, NguoiTao, del_flg)
                        values({SQLHelper.rpStr(_MaNhanVien)}, {SQLHelper.rpDT(_NgayDanhGia)}, {SQLHelper.rpStr(_NoiDung)},
                        {SQLHelper.rpD(_DiemDanhGia)}, {SQLHelper.rpStr(_XepLoai)}, '{DateTime.Now}', {SQLHelper.rpStr(_NguoiTao)}, 0)";

                if (SQLHelper.ExecuteSql(sql) == 1)
                {
                    RJMessageBox.Show("Thêm thành công", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (Exception ex)
            {
                RJMessageBox.Show(ex.Message, "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        public void UpdateData()
        {
            try
            {
                string sql = string.Empty;
                sql = $@"Update tbl_QTDanhGia Set NgayDanhGia = {SQLHelper.rpDT(_NgayDanhGia)}, NoiDung = {SQLHelper.rpStr(_NoiDung)},
                DiemDanhGia = {SQLHelper.rpD(_DiemDanhGia)}, XepLoai = {SQLHelper.rpStr(_XepLoai)}, NgayCapNhat = '{DateTime.Now}', 
                NguoiCapNhat = {SQLHelper.rpStr(_NguoiCapNhat)}
                Where Id = {SQLHelper.rpI(_IdDanhGia)}";

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
        private void btn_save_Click(object sender, EventArgs e)
        {
            SetValues();
            SaveData();
            LoadNull();
        }
        private void SaveData()
        {
            if (_edit == true)
            {
                UpdateData();
            }
            else
            {
                InsertData();
            }
            _quatrinh.LoadQTDanhGia();
            LoadNull();
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
            SaveData();
            this.Close();
        }
    }
}