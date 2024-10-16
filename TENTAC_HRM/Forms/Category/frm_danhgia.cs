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
        public frm_danhgia(Form form, UserControl user)
        {
            InitializeComponent();
            _quatrinh = (uc_quatrinh_lamviec)user;
            _personnel = (frm_personnel)form;
        }
        private void load_nhanvien()
        {
            cbo_nhanvien.DataSource = provider.load_nhanvien();
            cbo_nhanvien.DisplayMember = "name";
            cbo_nhanvien.ValueMember = "value";
            cbo_nhanvien.SelectedValue = _ma_nhan_vien;
        }
        private void frm_danhgia_Load(object sender, EventArgs e)
        {
            if(_edit == true)
            {
                string sql = string.Format("select * from hrm_qt_danhgia where id_qt_danhgia = '{0}'",_id_danh_gia);
                DataTable dataTable = new DataTable();
                dataTable = SQLHelper.ExecuteDt(sql);
                if(dataTable.Rows.Count > 0)
                {
                    _ma_nhan_vien = dataTable.Rows[0]["ma_nhan_vien"].ToString();
                    dtp_ngay_danhgia.Text = dataTable.Rows[0]["ngay_danh_gia"].ToString();
                    nr_diem_danhgia.Value = decimal.Parse(dataTable.Rows[0]["diem_danh_gia"].ToString());
                    txt_xep_loai.Text = dataTable.Rows[0]["xep_loai"].ToString();
                    txt_noi_dung.Text = dataTable.Rows[0]["noi_dung"].ToString();
                }
            }
            load_nhanvien();
        }
        public void insert_data()
        {
            try
            {
                string sql = string.Format("insert into hrm_qt_danhgia(ma_nhan_vien,ngay_danh_gia,noi_dung,diem_danh_gia,xep_loai,id_nguoi_tao) " +
                "values('{0}','{1}',N'{2}','{3}',N'{4}','{5}')", cbo_nhanvien.SelectedValue.ToString(), DateTime.Parse(dtp_ngay_danhgia.Text).ToString("yyyy/MM/dd"), txt_noi_dung.Text, nr_diem_danhgia.Value, txt_xep_loai.Text, SQLHelper.sIdUser);
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
        public void update_data()
        {
            try
            {
                string sql = string.Format("update hrm_qt_danhgia set ngay_danh_gia = '{1}',noi_dung = N'{2}',diem_danh_gia = '{3}',xep_loai = N'{4}' " +
                    "where id_qt_danhgia = {0}", _id_danh_gia,
                    DateTime.Parse(dtp_ngay_danhgia.Text).ToString("yyyy/MM/dd"), txt_noi_dung.Text, nr_diem_danhgia.Value, txt_xep_loai.Text);
                if (SQLHelper.ExecuteSql(sql) == 1)
                {
                    RJMessageBox.Show("cập nhật thành công", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch(Exception ex)
            {
                RJMessageBox.Show(ex.Message, "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void btn_save_Click(object sender, EventArgs e)
        {
            save_data();
            dtp_ngay_danhgia.Text = DateTime.Now.ToString();
            nr_diem_danhgia.Value = 0;
            txt_xep_loai.Text = string.Empty;
            txt_noi_dung.Text = string.Empty;
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
        private void btn_close_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btn_save_exit_Click(object sender, EventArgs e)
        {
            save_data();
            this.Close();
        }
    }
}
