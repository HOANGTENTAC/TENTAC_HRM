using System;
using System.Data;
using System.Windows.Forms;
using TENTAC_HRM.Custom;
using TENTAC_HRM.Model;
using TENTAC_HRM.User_control;

namespace TENTAC_HRM.Category
{
    public partial class frm_nhanvien_kyluat : Form
    {
        public bool edit { get; set; }
        public string _ma_nhan_vien { get; set; }
        public int _id_qt_kyluat { get; set; }
        DataProvider provider = new DataProvider();
        Kyluat_model model = new Kyluat_model();
        frm_personnel _Personnel;
        uc_quatrinh_lamviec _quatrinh;
        public frm_nhanvien_kyluat(Form form, UserControl user)
        {
            InitializeComponent();
            _quatrinh = (uc_quatrinh_lamviec)user;
            _Personnel = (frm_personnel)form;
        }

        private void frm_nhanvien_kyluat_Load(object sender, EventArgs e)
        {
            load_nhanvien();
            load_capkyluat();
            if(edit == true)
            {
                btn_save.Text = "Cập nhật";
                load_data();
            }
        }
        private void load_capkyluat()
        {
            cbo_cap.DataSource = provider.load_all_type(147);
            cbo_cap.DisplayMember = "name";
            cbo_cap.ValueMember = "id";
        }
        private void load_data()
        {
            string sql = string.Format("select * from hrm_qt_kyluat where id_qt_kyluat='{0}'",_id_qt_kyluat);
            DataTable dt = SQLHelper.ExecuteDt(sql);
            if(dt.Rows.Count > 0)
            {
                txt_soquyetdinh.Text = dt.Rows[0]["so_quyet_dinh"].ToString();
                dtp_kyluat.Text = dt.Rows[0]["ngay_ky_luat"].ToString();
                txt_hinhthuc.Text = dt.Rows[0]["hinh_thuc"].ToString();
                cbo_cap.SelectedValue = dt.Rows[0]["id_cap"].ToString();
                txt_lydo.Text = dt.Rows[0]["ly_do"].ToString();
                txt_sotien.Text = dt.Rows[0]["so_tien"].ToString();
                //cbo_nguoiky.SelectedValue = dt.Rows[0]["id_nguoi_ky"].ToString();
                txt_noidung.Text = dt.Rows[0]["noi_dung"].ToString();
            }
        }
        private void load_nhanvien()
        {
            cbo_nhanvien.DataSource = provider.load_nhanvien();
            cbo_nhanvien.DisplayMember = "name";
            cbo_nhanvien.ValueMember = "value";
            cbo_nhanvien.SelectedValue = _ma_nhan_vien;
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
                _quatrinh.Load_kyluat();
            }
            else
            {
                _Personnel.Load_kyluat();
            }
        }
        private void set_value_text()
        {
            model.So_quyet_dinh = txt_soquyetdinh.Text;
            model.Ngay_ky_luat = DateTime.Parse(dtp_kyluat.Text.ToString()).ToString("yyyy/MM/dd");
            model.Noi_dung = txt_noidung.Text;
            model.Hinh_thuc = txt_hinhthuc.Text;
            model.So_tien = txt_sotien.Text;
            model.Ly_do = txt_lydo.Text;
            model.Id_cap = int.Parse(cbo_cap.SelectedValue.ToString());
            model.Id_nguoi_ky = 0;
            model.Id_nguoi_tao = SQLHelper.sIdUser;
        }

        private void save_data()
        {
            try
            {
                string sql = string.Format("insert into hrm_qt_kyluat(ma_nhan_vien,ngay_ky_luat,so_quyet_dinh,noi_dung,hinh_thuc," +
                "so_tien,ly_do,id_cap,id_nguoi_ky,ngay_tao,id_nguoi_tao) " +
                "values('{0}','{1}','{2}',N'{3}',N'{4}','{5}',N'{6}','{7}','{8}',GETDATE(),'{9}')",
                _ma_nhan_vien, model.Ngay_ky_luat, model.So_quyet_dinh, model.Noi_dung, model.Hinh_thuc,
                model.So_tien, model.Ly_do, model.Id_cap, model.Id_nguoi_ky, model.Id_nguoi_tao);
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
                string sql = string.Format("update hrm_qt_kyluat set ngay_ky_luat = '{1}',so_quyet_dinh = '{2}',noi_dung = N'{3}',hinh_thuc = N'{4}'," +
                    "so_tien = '{5}',ly_do = N'{6}',id_cap = '{7}',id_nguoi_ky= '{8}',ngay_cap_nhat = GETDATE() " +
                    "where id_qt_kyluat= {0}",
                _id_qt_kyluat, model.Ngay_ky_luat, model.So_quyet_dinh, model.Noi_dung, model.Hinh_thuc,
                model.So_tien, model.Ly_do, model.Id_cap, model.Id_nguoi_ky);
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
        private void event_keypress(KeyPressEventArgs e)
        {
            if (!provider.IsValidNumber(e.KeyChar))
            {
                e.Handled = true;
                return;
            }
            base.OnKeyPress(e);
        }

        private void txt_sotien_KeyPress(object sender, KeyPressEventArgs e)
        {
            event_keypress(e);
        }

        private void btn_close_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
