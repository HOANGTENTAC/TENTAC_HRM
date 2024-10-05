using System;
using System.Data;
using System.Windows.Forms;
using TENTAC_HRM.Custom;
using TENTAC_HRM.Model;
using TENTAC_HRM.User_control;

namespace TENTAC_HRM.Category
{
    public partial class frm_nhanvien_tainan : Form
    {
        public int id_ten_tai_nan_value, id_muc_do_value;
        public string ngay_dien_ra_value, noi_dien_ra_value, noi_dung_value, nguoi_tao_value, ten_tai_nan_value, muc_do_value;
        public bool edit { get; set; }
        public string _ma_nhan_vien { get; set; }
        public int _id_qt_tainan { get; set; }
        DataProvider provider = new DataProvider();
        Tainan_model model = new Tainan_model();
        frm_personnel _Personnel;
        uc_quatrinh_lamviec _quatrinh;
        public frm_nhanvien_tainan(Form form, UserControl user)
        {
            InitializeComponent();
            _quatrinh = (uc_quatrinh_lamviec)user;
            _Personnel = (frm_personnel)form;
        }

        private void btn_close_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btn_save_Click(object sender, EventArgs e)
        {
            set_value_text();
            if (edit == true)
            {
                update_date();
            }
            else
            {
                save_data();
            }

            if (_quatrinh != null)
            {
                _quatrinh.load_tainan();
            }
            else
            {
                _Personnel.load_tainan();
            }
        }

        private void frm_nhanvien_tainan_Load(object sender, EventArgs e)
        {
            load_nhanvien();
            Load_loatainan();
            load_mucdo_tainan();
            if (edit == true)
            {
                btn_save.Text = "Cập nhật";
                load_data();
            }
        }
        private void load_mucdo_tainan()
        {
            cbo_mucdo.DataSource = provider.load_all_type(156);
            cbo_mucdo.DisplayMember = "name";
            cbo_mucdo.ValueMember = "id";
        }
        private void Load_loatainan()
        {
            cbo_tentainan.DataSource = provider.load_all_type(150);
            cbo_tentainan.DisplayMember = "name";
            cbo_tentainan.ValueMember = "id";
        }
        private void load_nhanvien()
        {
            cbo_nhanvien.DataSource = provider.load_nhanvien();
            cbo_nhanvien.DisplayMember = "name";
            cbo_nhanvien.ValueMember = "value";
            cbo_nhanvien.SelectedValue = _ma_nhan_vien;
        }

        private void load_data()
        {
            string sql = string.Format("select * from hrm_qt_tainan where id_qt_tainan='{0}'", _id_qt_tainan);
            DataTable dt = SQLHelper.ExecuteDt(sql);
            if (dt.Rows.Count > 0)
            {
                cbo_tentainan.SelectedValue = dt.Rows[0]["id_ten_tai_nan"].ToString();
                cbo_mucdo.SelectedValue = dt.Rows[0]["id_muc_do"].ToString();
                dtp_ngaydienra.Text = dt.Rows[0]["ngay_dien_ra"].ToString();
                txt_noidienra.Text = dt.Rows[0]["noi_dien_ra"].ToString();
                txt_noidung.Text = dt.Rows[0]["noi_dung"].ToString();
            }
        }
        private void save_data()
        {
            try
            {
                string sql = string.Format("insert into hrm_qt_tainan(ma_nhan_vien,id_ten_tai_nan,id_muc_do,ngay_dien_ra,noi_dien_ra,noi_dung,ngay_tao,id_nguoi_tao) " +
                "values('{0}','{1}','{2}','{3}',N'{4}',N'{5}',GETDATE(),'{6}')",
                _ma_nhan_vien, id_ten_tai_nan_value, id_muc_do_value, ngay_dien_ra_value, noi_dien_ra_value, noi_dung_value, nguoi_tao_value);
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

        private void update_date()
        {
            try
            {
                string sql = string.Format("update hrm_qt_tainan set id_ten_tai_nan = '{1}',id_muc_do = '{2}'," +
                    "ngay_dien_ra = '{3}',noi_dien_ra = N'{4}',noi_dung = N'{5}',ngay_cap_nhat = GETDATE() " +
                    "where id_qt_tainan = {0}",
                    _id_qt_tainan, id_ten_tai_nan_value, id_muc_do_value, ngay_dien_ra_value, noi_dien_ra_value, noi_dung_value);
                if (SQLHelper.ExecuteSql(sql) == 1)
                {
                    RJMessageBox.Show("Cập nhật thành công", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (Exception ex)
            {
                RJMessageBox.Show(ex.Message, "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void set_value_text()
        {
            id_ten_tai_nan_value = int.Parse(cbo_tentainan.SelectedValue.ToString());
            id_muc_do_value = int.Parse(cbo_mucdo.SelectedValue.ToString());
            ngay_dien_ra_value = DateTime.Parse(dtp_ngaydienra.Text.ToString()).ToString("yyyy/MM/dd");
            noi_dien_ra_value = txt_noidienra.Text;
            noi_dung_value = txt_noidung.Text;
        }
    }
}
