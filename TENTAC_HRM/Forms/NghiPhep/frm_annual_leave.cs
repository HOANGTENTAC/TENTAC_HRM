using System;
using System.Data;
using System.Windows.Forms;
using TENTAC_HRM.Custom;

namespace TENTAC_HRM.Forms.Cham_Cong
{
    public partial class frm_annual_leave : Form
    {
        public bool edit { get; set; }
        public string _ma_nhan_vien { get; set; }
        public string _id_nghi_phep_value { get; set; }
        DataProvider provider = new DataProvider();
        uc_nghiphep uc_nghiphep = new uc_nghiphep();
        public frm_annual_leave(uc_nghiphep _uc_nghiphep)
        {
            InitializeComponent();
            this.uc_nghiphep = _uc_nghiphep;
        }

        private void frm_annual_leave_Load(object sender, EventArgs e)
        {
            dtp_tungay.Text = DateTime.Now.ToString("yyyy/MM/dd 07:50");
            dtp_denngay.Text = DateTime.Now.ToString("yyyy/MM/dd 16:30");
            load_nhanvien();
            load_loaiphep();
            if (edit == true)
            {
                load_data();
                cbo_nhanvien.Enabled = false;
                cbo_nhanvien.SelectedValue = _ma_nhan_vien;
            }
        }
        private void load_data()
        {
            string sql = string.Format("select * from tas_nghi_phep_nam where id_nghi_phep = {0}", _id_nghi_phep_value);
            DataTable dataTable = new DataTable();
            dataTable = SQLHelper.ExecuteDt(sql);
            if (dataTable.Rows.Count > 0)
            {
                cbo_loaiphep.SelectedValue = dataTable.Rows[0]["id_loai_phep_nghi"].ToString();
                dtp_tungay.Text = dataTable.Rows[0]["ngay_nghi"].ToString();
                dtp_denngay.Text = dataTable.Rows[0]["den_ngay"].ToString();
                txt_noidung.Text = dataTable.Rows[0]["ghi_chu"].ToString();
                chk_quanly.Checked = bool.Parse(dataTable.Rows[0]["chk_quanly"].ToString());
                chk_nhansu.Checked = bool.Parse(dataTable.Rows[0]["chk_nhansu"].ToString());
            }
        }
        private void load_nhanvien()
        {
            cbo_nhanvien.DataSource = provider.load_nhanvien();
            cbo_nhanvien.DisplayMember = "name";
            cbo_nhanvien.ValueMember = "value";
        }
        private void load_loaiphep()
        {
            cbo_loaiphep.DataSource = provider.load_loaiphep();
            cbo_loaiphep.DisplayMember = "name";
            cbo_loaiphep.ValueMember = "id";
        }

        private void btn_close_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        decimal songay = 0;
        private void btn_save_Click(object sender, EventArgs e)
        {
            TimeSpan t = DateTime.Parse(dtp_denngay.Text) - DateTime.Parse(dtp_tungay.Text);

            if ((int)t.Days >= 0)
            {
                songay = (int)t.Days + 1;
            }
            else if ((int)t.Hours <= 4)
            {
                songay = decimal.Parse("0.5");
            }
            if (edit == true)
            {
                update_data();
            }
            else
            {
                save_data();
            }
            uc_nghiphep.load_data();
        }

        private void save_data()
        {
            try
            {
                string sql = string.Format("insert into tas_nghi_phep_nam(ma_nhan_vien,id_loai_phep_nghi,ngay_nghi,den_ngay,ghi_chu,so_ngay,id_nguoi_tao,nam) " +
                    "values('{0}','{1}','{2}','{3}','{4}','{5}','{6}','{7}')", cbo_nhanvien.SelectedValue.ToString(), cbo_loaiphep.SelectedValue.ToString(),
                    DateTime.Parse(dtp_tungay.Text).ToString("yyyy/MM/dd HH:mm"), DateTime.Parse(dtp_denngay.Text).ToString("yyyy/MM/dd HH:mm"),
                    txt_noidung.Text, songay, SQLHelper.sIdUser,DateTime.Parse(dtp_tungay.Text).Year);
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
                string sql = string.Format("update tas_nghi_phep_nam set id_loai_phep_nghi = '{1}',ngay_nghi='{2}'," +
                    "den_ngay ='{3}',ghi_chu='{4}',so_ngay='{5}',ngay_cap_nhat = GETDATE(),nam = '{6}',id_nguoi_tao = '{7}' " +
                    "where id_nghi_phep = '{0}'", _id_nghi_phep_value, cbo_loaiphep.SelectedValue.ToString(),
                    DateTime.Parse(dtp_tungay.Text).ToString("yyyy/MM/dd HH:mm"), DateTime.Parse(dtp_denngay.Text).ToString("yyyy/MM/dd HH:mm"),
                    txt_noidung.Text, songay, DateTime.Parse(dtp_tungay.Text).Year, SQLHelper.sIdUser);
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
