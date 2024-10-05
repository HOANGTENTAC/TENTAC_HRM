using System;
using System.Data;
using System.Windows.Forms;
using TENTAC_HRM.Custom;
using TENTAC_HRM.User_control;

namespace TENTAC_HRM.Category
{
    public partial class frm_daotao : Form
    {
        DataProvider provider = new DataProvider();
        public string _ma_nhan_vien { get; set; }
        public bool _edit { get; set; }
        public int _id_dao_tao;
        frm_personnel _personnel;
        uc_quatrinh_lamviec _quatrinh;
        public frm_daotao(Form form, UserControl user)
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
        private void frm_daotao_Load(object sender, EventArgs e)
        {
            if(_edit == true)
            {
                string sql = string.Format("select * from hrm_qt_daotao where id_qt_daotao = '{0}'",_id_dao_tao);
                DataTable dt= new DataTable();
                dt = SQLHelper.ExecuteDt(sql);
                if(dt.Rows.Count > 0)
                {
                    _ma_nhan_vien = dt.Rows[0]["ma_nhan_vien"].ToString();
                    txt_so_qd.Text = dt.Rows[0]["so_quyet_dinh"].ToString();
                    dtp_tu_ngay.Text = dt.Rows[0]["tu_ngay"].ToString();
                    dtp_den_ngay.Text = dt.Rows[0]["den_ngay"].ToString();
                    txt_hinh_thuc.Text = dt.Rows[0]["hinh_thuc"].ToString();
                    txt_noi_dung.Text = dt.Rows[0]["noi_dung"].ToString();
                }
            }
            load_nhanvien();
        }

        private void btn_save_Click(object sender, EventArgs e)
        {
            if(_edit == true)
            {
                Update_data();
            }
            else
            {
                insert_data();
            }
            if (_quatrinh != null)
            {
                _quatrinh.load_daotao();
            }
            else
            {
                _personnel.load_daotao();
            }
        }

        private void insert_data()
        {
            try
            {
                string sql = string.Format("insert into hrm_qt_daotao(ma_nhan_vien,tu_ngay,den_ngay,so_quyet_dinh,noi_dung,hinh_thuc,id_nguoi_tao) " +
                    "values('{0}','{1}','{2}','{3}',N'{4}',N'{5}','{6}')",
                    cbo_nhanvien.SelectedValue.ToString(),DateTime.Parse(dtp_tu_ngay.Text).ToString("yyyy/MM/dd"),
                    DateTime.Parse(dtp_den_ngay.Text).ToString("yyyy/MM/dd"), txt_so_qd.Text,txt_noi_dung.Text,txt_hinh_thuc.Text,SQLHelper.sIdUser);
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

        private void Update_data()
        {
            try
            {
                string sql = string.Format("update hrm_qt_daotao set tu_ngay ='{1}', den_ngay = '{2}', so_quyet_dinh = '{3}',noi_dung = N'{4}', hinh_thuc=N'{5}',ngay_cap_nhat = GETDATE() " +
                    "where id_qt_daotao = '{0}'",_id_dao_tao, DateTime.Parse(dtp_tu_ngay.Text).ToString("yyyy/MM/dd"), DateTime.Parse(dtp_den_ngay.Text).ToString("yyyy/MM/dd"), txt_so_qd.Text,txt_noi_dung.Text,txt_hinh_thuc.Text);
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

        private void btn_close_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
