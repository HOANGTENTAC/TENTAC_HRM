using System;
using System.Data;
using System.Windows.Forms;
using TENTAC_HRM.Custom;
using TENTAC_HRM.Forms.Main;
using TENTAC_HRM.Forms.User_control;

namespace TENTAC_HRM.Forms.Category
{
    public partial class frm_nghiviec : Form
    {
        DataProvider provider = new DataProvider();
        public string _ma_nhan_vien { get; set; }
        public bool _edit { get; set; }
        public int _id_nghi_viec;
        frm_personnel _Personnel;
        uc_quatrinh_lamviec _quatrinh;
        public frm_nghiviec(Form form, UserControl user)
        {
            InitializeComponent();
            _quatrinh = (uc_quatrinh_lamviec)user;
            _Personnel = (frm_personnel)form;
        }
        private void load_nhanvien()
        {
            cbo_nhanvien.DataSource = provider.load_nhanvien();
            cbo_nhanvien.DisplayMember = "name";
            cbo_nhanvien.ValueMember = "value";
            cbo_nhanvien.SelectedValue = _ma_nhan_vien;
        }
        private void load_loainghiviec()
        {
            cbo_loai_nghiviec.DataSource = provider.load_loainghiviec();
            cbo_loai_nghiviec.DisplayMember = "name";
            cbo_loai_nghiviec.ValueMember = "id";
        }
        private void load_trangthai_congviec()
        {
            string sql = string.Format("select id_trang_thai from hrm_nhan_vien where ma_nhan_vien = '{0}'",_ma_nhan_vien);
            DataTable dt = new DataTable();
            dt = SQLHelper.ExecuteDt(sql);
            cbo_trangthai.DataSource = provider.load_all_type(1);
            cbo_trangthai.DisplayMember = "name";
            cbo_trangthai.ValueMember = "id";
            cbo_trangthai.SelectedValue = dt.Rows[0][0].ToString();
        }
        private void btn_close_Click(object sender, System.EventArgs e)
        {
            this.Close();
        }

        private void frm_nghiviec_Load(object sender, System.EventArgs e)
        {
            load_loainghiviec();
            if (_edit == true)
            {
                string sql = string.Format("select * from hrm_qt_nghiviec where id_qt_nghiviec = '{0}'", _id_nghi_viec);
                DataTable dt = SQLHelper.ExecuteDt(sql);
                if (dt.Rows.Count > 0)
                {
                    _ma_nhan_vien = dt.Rows[0]["ma_nhan_vien"].ToString();
                    cbo_loai_nghiviec.SelectedValue = dt.Rows[0]["loai_nghi_viec"].ToString();
                    txt_so_qd.Text = dt.Rows[0]["so_quyet_dinh"].ToString();
                    dtp_ngay_qt.Text = dt.Rows[0]["ngay_quyet_dinh"].ToString();
                    dtp_tungay.Text = dt.Rows[0]["tu_ngay"].ToString();
                    dtp_denngay.Text = dt.Rows[0]["den_ngay"].ToString();
                    txt_noidung.Text = dt.Rows[0]["noi_dung"].ToString();
                }
            }

            load_nhanvien();
            load_trangthai_congviec();
        }

        private void btn_save_Click(object sender, System.EventArgs e)
        {
            if(_edit == true)
            {
                update_data();
            }
            else
            {
                insert_data();
            }
            if (_quatrinh != null)
            {
                _quatrinh.load_nghiviec();
            }
            else
            {
                _Personnel.load_nghiviec();
            }
        }

        private void insert_data()
        {
            try
            {
                string sql = string.Format("insert into hrm_qt_nghiviec(ma_nhan_vien,tu_ngay,den_ngay,ngay_quyet_dinh,so_quyet_dinh,noi_dung,loai_nghi_viec,id_nguoi_tao) " +
                    "values('{0}','{1}','{2}','{3}','{4}',N'{5}','{6}','{7}')",
                    _ma_nhan_vien,dtp_tungay.Text,dtp_denngay.Text,dtp_ngay_qt.Text,txt_so_qd,txt_noidung.Text,cbo_loai_nghiviec.SelectedValue.ToString(),0);
                if(SQLHelper.ExecuteSql(sql) == 1)
                {
                    string sql_nhanvien = string.Format("update hrm_nhan_vien set id_trang_thai = '{0}' where ma_nhan_vien = '{1}'",cbo_trangthai.SelectedValue.ToString(),_ma_nhan_vien);
                    SQLHelper.ExecuteSql(sql_nhanvien);
                    RJMessageBox.Show("Thêm thành công", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }catch (Exception ex)
            {
                RJMessageBox.Show(ex.Message,"Thông báo",MessageBoxButtons.OK,MessageBoxIcon.Information);
            }
        }

        private void update_data()
        {
            try
            {
                string sql = string.Format("update hrm_qt_nghiviec set tu_ngay = '{1}',den_ngay = '{2}', ngay_quyet_dinh = '{3}', so_quyet_dinh = '{4}'," +
                    "noi_dung = N'{5}',loai_nghi_viec = '{6}',ngay_cap_nhat = GETDATE() where id_qt_nghiviec = '{0}'",
                    _id_nghi_viec,dtp_tungay.Text,dtp_denngay.Text,dtp_ngay_qt.Text,txt_so_qd.Text,txt_noidung.Text,cbo_loai_nghiviec.SelectedValue.ToString());
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
    }
}
