using System;
using System.Data;
using System.Windows.Forms;
using TENTAC_HRM.Custom;
using TENTAC_HRM.Forms.Main;
using TENTAC_HRM.Forms.User_control;

namespace TENTAC_HRM.Forms.Category
{
    public partial class frm_congtac : Form
    {
        string soquyetdinh_value, noidung_value, dia_diem_value, nguoitao_value, nguoicapnhat_value;
        DateTime? tungay_value, denngay_value;
        DataProvider provider = new DataProvider();
        public bool edit { get; set; }
        public string _ma_nhan_vien;
        public int _id_congtac { get; set; }
        frm_personnel _Personnel;
        uc_quatrinh_lamviec _quatrinh;
        public frm_congtac(Form form, UserControl user)
        {
            InitializeComponent();
            _quatrinh = (uc_quatrinh_lamviec)user;
            _Personnel = (frm_personnel)form;
        }

        private void frm_congtac_Load(object sender, EventArgs e)
        {
            load_nhanvien();
            if (edit == true)
            {
                string sql = string.Format("select * from tbl_QTCongTac where Id = '{0}'", _id_congtac);
                DataTable dataTable = new DataTable();
                dataTable = SQLHelper.ExecuteDt(sql);
                if (dataTable.Rows.Count > 0)
                {
                    txt_DiaDiem.Text = dataTable.Rows[0]["DiaDiem"].ToString();
                    txt_SoQuyetDinh.Text = dataTable.Rows[0]["SoQuyetDinh"].ToString();
                    dtp_TuNgay.Text = dataTable.Rows[0]["TuNgay"].ToString();
                    dtp_DenNgay.Text = dataTable.Rows[0]["DenNgay"].ToString();
                    txt_NoiDung.Text = dataTable.Rows[0]["NoiDung"].ToString();
                }
            }
        }
        private void LoadNull()
        {
            txt_DiaDiem.Text = string.Empty;
            txt_SoQuyetDinh.Text= string.Empty;
            dtp_TuNgay.Text = string.Empty;
            dtp_DenNgay.Text= string.Empty;
            txt_NoiDung.Text= string.Empty;
        }
        private void btn_close_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void load_nhanvien()
        {
            cbo_NhanVien.DataSource = provider.load_nhanvien();
            cbo_NhanVien.DisplayMember = "name";
            cbo_NhanVien.ValueMember = "value";
            cbo_NhanVien.SelectedValue = _ma_nhan_vien;
        }
        private void update_data()
        {
            try
            {
                string sql = string.Empty;
                sql = $@"Update tbl_QTCongTac Set TuNgay = {SQLHelper.rpDT(tungay_value)}, DenNgay = {SQLHelper.rpDT(denngay_value)},
                    SoQuyetDinh = {SQLHelper.rpStr(soquyetdinh_value)}, DiaDiem = {SQLHelper.rpStr(dia_diem_value)}, 
                    NoiDung = {SQLHelper.rpStr(noidung_value)}, NgayCapNhat = '{DateTime.Now}', NguoiCapNhat = {SQLHelper.rpStr(nguoicapnhat_value)}
                    Where Id = {_id_congtac}";
                if (SQLHelper.ExecuteSql(sql) == 1)
                {
                    RJMessageBox.Show("Thêm thành công", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    _Personnel.Load_congtac();
                    LoadNull();
                }
            }
            catch (Exception ex)
            {
                RJMessageBox.Show(ex.Message, "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void insert_data()
        {
            try
            {
                string sql = string.Empty;
                sql = $@"Insert tbl_QTCongTac(MaNhanVien, TuNgay, DenNgay, SoQuyetDinh, DiaDiem, NoiDung, NgayTao, NguoiTao, del_flg)
                values({SQLHelper.rpStr(_ma_nhan_vien)}, {SQLHelper.rpDT(tungay_value)}, {SQLHelper.rpDT(denngay_value)}, 
                {SQLHelper.rpStr(soquyetdinh_value)}, {SQLHelper.rpStr(dia_diem_value)}, {SQLHelper.rpStr(noidung_value)}, 
                '{DateTime.Now}', {SQLHelper.rpStr(nguoitao_value)}, 0)";
                if (SQLHelper.ExecuteSql(sql) == 1)
                {
                    RJMessageBox.Show("Thêm thành công", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    _Personnel.Load_congtac();
                    LoadNull();
                }
            }
            catch (Exception ex)
            {
                RJMessageBox.Show(ex.Message, "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void set_value_text()
        {
            tungay_value = string.IsNullOrEmpty(dtp_TuNgay.Text) ? (DateTime?)null : DateTime.Parse(dtp_TuNgay.Text);
            denngay_value = string.IsNullOrEmpty(dtp_DenNgay.Text) ? (DateTime?)null : DateTime.Parse(dtp_DenNgay.Text);
            soquyetdinh_value = txt_SoQuyetDinh.Text.ToString();
            noidung_value = txt_NoiDung.Text.ToString();
            dia_diem_value = txt_DiaDiem.Text.ToString();
            nguoitao_value = SQLHelper.sUser;
            nguoicapnhat_value = SQLHelper.sUser;
        }
        private bool validateForm()
        {
            if (string.IsNullOrEmpty(dtp_TuNgay.Value.ToString()))
            {
                RJMessageBox.Show("Vui lòng chọn từ ngày.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                dtp_TuNgay.Focus();
                return false;
            }
            if (string.IsNullOrEmpty(dtp_DenNgay.Value.ToString()))
            {
                RJMessageBox.Show("Vui lòng chọn đến ngày.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                dtp_DenNgay.Focus();
                return false;
            }
            if (string.IsNullOrEmpty(txt_SoQuyetDinh.Text.ToString()))
            {
                RJMessageBox.Show("Vui lòng nhập số quyết định.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txt_SoQuyetDinh.Focus();
                return false;
            }
            return true;
        }
        private void btn_save_Click(object sender, EventArgs e)
        {
            set_value_text();
            if (edit == false)
            {
                insert_data();
            }
            else
            {
                update_data();
            }
            if (_quatrinh != null)
            {
                _quatrinh.Load_congtac();
            }
            else
            {
                _Personnel.Load_congtac();
            }
        }
    }
}
