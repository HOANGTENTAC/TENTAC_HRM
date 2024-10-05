using System;
using System.Data;
using System.Windows.Forms;
using TENTAC_HRM.Custom;
using TENTAC_HRM.User_control;

namespace TENTAC_HRM.Category
{
    public partial class frm_congtac : Form
    {
        string tungay_value, denngay_value, soquyetdinh_value, noidung_value, dia_diem_value;
        DataProvider provider = new DataProvider();
        public bool edit { get; set; }
        public string _ma_nhan_vien;
        public int _id_congtac { get; set; }
        frm_personnel _Personnel;
        uc_quatrinh_lamviec _quatrinh;
        public frm_congtac(Form form,UserControl user)
        {
            InitializeComponent();
            _quatrinh = (uc_quatrinh_lamviec)user;
            _Personnel = (frm_personnel)form;
        }

        private void frm_congtac_Load(object sender, EventArgs e)
        {
            load_nhanvien();
            if(edit == true)
            {
                btn_save.Text = "Cập nhật";
                string sql = string.Format("select * from hrm_qt_congtac where id_qt_congtac = '{0}'",_id_congtac);
                DataTable dataTable = new DataTable();
                dataTable = SQLHelper.ExecuteDt(sql);
                if(dataTable.Rows.Count > 0)
                {
                    txt_dia_diem.Text = dataTable.Rows[0]["dia_diem"].ToString();
                    txt_soquyetdinh.Text = dataTable.Rows[0]["so_quyet_dinh"].ToString();
                    dtp_tungay.Text = dataTable.Rows[0]["tu_ngay"].ToString();
                    dtp_denngay.Text = dataTable.Rows[0]["den_ngay"].ToString();
                    txt_noidung.Text = dataTable.Rows[0]["noi_dung"].ToString();
                }
            }
        }

        private void btn_close_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void load_nhanvien()
        {
            cbo_nhanvien.DataSource = provider.load_nhanvien();
            cbo_nhanvien.DisplayMember = "name";
            cbo_nhanvien.ValueMember = "value";
            cbo_nhanvien.SelectedValue = _ma_nhan_vien;
        }
        private void update_data()
        {
            try
            {
                string sql = string.Format("update hrm_qt_congtac set tu_ngay = '{1}',den_ngay = '{2}',so_quyet_dinh = '{3}',noi_dung = N'{4}',ngay_cap_nhat = GETDATE(),dia_diem = N'{5}'" +
                    "where id_qt_congtac = {0}", _id_congtac, tungay_value, denngay_value, soquyetdinh_value, noidung_value, dia_diem_value);
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

        private void save_data()
        {
            try
            {
                string sql = string.Format("insert into hrm_qt_congtac(ma_nhan_vien,tu_ngay,den_ngay,so_quyet_dinh,noi_dung,id_nguoi_tao,dia_diem) " +
                    "values('{0}','{1}','{2}','{3}',N'{4}','{5}',N'{6}')",
                    _ma_nhan_vien, tungay_value, denngay_value, soquyetdinh_value, noidung_value, SQLHelper.sIdUser, dia_diem_value);
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
        private void set_value_text()
        {
            tungay_value = DateTime.Parse(dtp_tungay.Text).ToString("yyyy/MM/yy");
            denngay_value = DateTime.Parse(dtp_denngay.Text).ToString("yyyy/MM/yy");
            soquyetdinh_value = txt_soquyetdinh.Text.ToString();
            noidung_value = txt_noidung.Text.ToString();
            dia_diem_value = txt_dia_diem.Text.ToString();
        }
        private void btn_save_Click(object sender, EventArgs e)
        {
            set_value_text();
            if (edit == false)
            {
                save_data();
            }
            else
            {
                update_data();
            }

            if(_quatrinh != null)
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
