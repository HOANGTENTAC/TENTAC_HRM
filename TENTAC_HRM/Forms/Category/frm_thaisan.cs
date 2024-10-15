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
        public frm_thaisan(Form form, UserControl user)
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
        private void frm_thaisan_Load(object sender, EventArgs e)
        {
            load_nhanvien();
            if (edit == true)
            {
                btn_save.Text = "Cập nhật";
                string sql = string.Format("select * from hrm_nhanvien_thaisan where id_thai_san='{0}'",_id_thai_san);
                DataTable dt = SQLHelper.ExecuteDt(sql);
                if(dt.Rows.Count>0)
                {
                    dtp_tungay.Text = dt.Rows[0]["tu_ngay"].ToString();
                    dtp_denngay.Text = dt.Rows[0]["den_ngay"].ToString();
                    txt_ghichu.Text = dt.Rows[0]["ghi_chu"].ToString();
                }
            }
        }

        private void btn_save_Click(object sender, EventArgs e)
        {
            if(edit == true)
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
                string sql = string.Format("insert into hrm_nhanvien_thaisan(ma_nhan_vien,tu_ngay,den_ngay,ghi_chu,id_nguoi_tao) " +
                "values('{0}','{1}','{2}',N'{3}','{4}')", cbo_nhanvien.SelectedValue.ToString(), DateTime.Parse(dtp_tungay.Text).ToString("yyyy/MM/dd"), DateTime.Parse(dtp_denngay.Text).ToString("yyyy/MM/dd"), txt_ghichu.Text, SQLHelper.sIdUser);
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

        private void update_data()
        {
            try
            {
                string sql = string.Format("update hrm_nhanvien_thaisan set tu_ngay = '{1}', den_ngay = '{2}',ghi_chu = N'{3}' where id_thai_san = '{0}'",
                    _id_thai_san, DateTime.Parse(dtp_tungay.Text).ToString("yyyy/MM/dd"), DateTime.Parse(dtp_denngay.Text).ToString("yyyy/MM/dd"),txt_ghichu.Text);
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

        private void btn_close_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
