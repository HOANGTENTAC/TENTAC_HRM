using System;
using System.Data;
using System.Windows.Forms;
using TENTAC_HRM.Custom;
using TENTAC_HRM.Forms.Main;

namespace TENTAC_HRM.Forms.Category
{
    public partial class frm_staff_allowance : Form
    {
        string loaiphucap_value, mucphucap_value, tungay_value, denngay_value, ghichu_value, nguoitao_value;
        bool active_value;
        public bool edit { get; set; }
        public string _ma_nhan_vien { get; set; }
        public string _id_phucap { get; set; }
        DataProvider provider = new DataProvider();
        frm_personnel frm_personnel;
        public frm_staff_allowance(frm_personnel frm_)
        {
            InitializeComponent();
            frm_personnel = frm_;
        }

        private void frm_allowance_Load(object sender, EventArgs e)
        {
            load_nhanvien();
            load_loaiphucap();
            if(edit == true)
            {
                load_data();
            }
        }
        private void load_data()
        {
            btn_save.Text = "Cập nhật";
            edit = true;
            string sql = string.Format("select * from hrm_nhanvien_phucap where id_phu_cap = {0}", _id_phucap);
            DataTable dt = new DataTable();
            dt = SQLHelper.ExecuteDt(sql);
            if (dt.Rows.Count > 0)
            {
                cbo_loaiphucap.SelectedValue = dt.Rows[0]["id_loai_phu_cap"].ToString();
                txt_mucphucap.Text = dt.Rows[0]["muc_phu_cap"].ToString();
                dtp_tungay.Text = dt.Rows[0]["tu_ngay"].ToString();
                dtp_denngay.Text = dt.Rows[0]["den_ngay"].ToString();
                txt_ghichu.Text = dt.Rows[0]["ghi_chu"].ToString();
                chk_active.Checked = bool.Parse(dt.Rows[0]["is_active"].ToString());
            }
        }
        private void load_nhanvien()
        {
            cbo_nhanvien.DataSource = provider.load_nhanvien();
            cbo_nhanvien.DisplayMember = "name";
            cbo_nhanvien.ValueMember = "value";
            cbo_nhanvien.SelectedValue = _ma_nhan_vien;
        }
        private void load_loaiphucap()
        {
            cbo_loaiphucap.DataSource = provider.load_loaiphucap();
            cbo_loaiphucap.DisplayMember = "ten_loai_phu_cap";
            cbo_loaiphucap.ValueMember = "id_loai_phu_cap";
        }

        private void btn_close_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void frm_allowance_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
            {
                this.Close();
            }
        }
        private void set_text_value()
        {
            _ma_nhan_vien = cbo_nhanvien.SelectedValue.ToString();
            loaiphucap_value = cbo_loaiphucap.SelectedValue.ToString();
            mucphucap_value = txt_mucphucap.Text.ToString();
            tungay_value = DateTime.Parse(dtp_tungay.Text).ToString("yyyy/MM/dd");
            denngay_value = DateTime.Parse(dtp_denngay.Text).ToString("yyyy/MM/dd");
            active_value = chk_active.Checked;
            ghichu_value = txt_ghichu.Text.ToString();
            nguoitao_value = SQLHelper.sIdUser;
        }

        private void save_data()
        {
            try
            {
                string sql = string.Format("insert into hrm_nhanvien_phucap(ma_nhan_vien,is_active,id_loai_phu_cap,tu_ngay," +
                         "den_ngay,muc_phu_cap,ghi_chu,ngay_tao,id_nguoi_tao) " +
                         "values('{0}','{1}',{2},'{3}','{4}','{5}',N'{6}',GETDATE(),'{7}')", _ma_nhan_vien, active_value, loaiphucap_value, tungay_value
                         , denngay_value, mucphucap_value, ghichu_value, nguoitao_value);
                int id_new = SQLHelper.ExecuteScalarSql(sql);
                if (id_new != 0)
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
                string sql = string.Format("update hrm_nhanvien_phucap set is_active = '{2}',id_loai_phu_cap = {3},tu_ngay = '{4}',den_ngay = '{5}'," +
                    "muc_phu_cap = '{6}',ghi_chu = N'{7}',ngay_cap_nhat = GETDATE() " +
                    "where id_phu_cap = {0} and ma_nhan_vien = '{1}'", _id_phucap, _ma_nhan_vien,
                    active_value, loaiphucap_value, tungay_value, denngay_value,
                    mucphucap_value, ghichu_value);
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
        private void btn_save_Click(object sender, EventArgs e)
        {
            if (cbo_loaiphucap.Text == "" || string.IsNullOrEmpty(txt_mucphucap.Text))
            {
                if (cbo_loaiphucap.Text == "")
                {
                    cbo_loaiphucap.Focus();
                }
                else
                {
                    txt_mucphucap.Focus();
                }
                RJMessageBox.Show("Loại phụ cấp hoặc mức phụ cấp không được để rỗng", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else
            {
                set_text_value();
                if (edit == true)
                {
                    update_data();
                }
                else
                {
                    save_data();
                }
                frm_personnel.load_phucap();
            }
        }
    }
}
