using ComponentFactory.Krypton.Toolkit;
using System;
using System.Data;
using System.Globalization;
using System.Windows.Forms;
using TENTAC_HRM.Custom;

namespace TENTAC_HRM.Cham_Cong
{
    public partial class frm_nghiphepnam : KryptonForm
    {
        public int year { get; set; }
        public string _ma_nhanvien { get; set; }
        uc_annual_leave annual_leave = new uc_annual_leave();
        public frm_nghiphepnam(uc_annual_leave _annual_leave)
        {
            InitializeComponent();
            annual_leave = _annual_leave;
        }

        private void frm_nghiphepnam_Load(object sender, EventArgs e)
        {
            string sql = string.Format("select ho_ten from hrm_nhan_vien where ma_nhan_vien = '{0}'", _ma_nhanvien);
            DataTable dt = new DataTable();
            dt = SQLHelper.ExecuteDt(sql);
            if (dt.Rows.Count > 0)
            {
                lb_ten_nhanvien.Text = dt.Rows[0][0].ToString();
            }
            txt_nam_nghiphep.Text = year.ToString();
            load_data();
        }
        private void load_data()
        {
            string sql = string.Format("select * from tas_ngay_phep_nam where ma_nhan_vien = '{0}' and nam = '{1}'", _ma_nhanvien, year);
            DataTable dt = new DataTable();
            dt = SQLHelper.ExecuteDt(sql);
            if(dt.Rows.Count > 0)
            {
                txt_phep_qd.Text = dt.Rows[0]["tong_ngay_qd"].ToString();
                txt_tong_ngayphep.Text = dt.Rows[0]["tong_ngay_phep"].ToString();
                txt_tong_ngayton.Text = dt.Rows[0]["tong_ngay_ton"].ToString();
                txt_phep_dochai.Text = dt.Rows[0]["phep_doc_hai"].ToString();
                txt_phep_thamnien.Text = dt.Rows[0]["phep_tham_nien"].ToString();
            }
        }
        private void txt_phep_qd_Leave(object sender, EventArgs e)
        {
            decimal phep_qd = decimal.Parse(txt_phep_qd.Text);
            txt_phep_qd.Text = phep_qd.ToString("N1", CultureInfo.InvariantCulture);
        }

        private void txt_tong_ngayphep_Leave(object sender, EventArgs e)
        {
            txt_tong_ngayphep.Text = decimal.Parse(txt_tong_ngayphep.Text).ToString("N1", CultureInfo.InvariantCulture);
        }

        private void txt_tong_ngayton_Leave(object sender, EventArgs e)
        {
            txt_tong_ngayton.Text = decimal.Parse(txt_tong_ngayton.Text).ToString("N1", CultureInfo.InvariantCulture);
        }

        private void btn_save_Click(object sender, EventArgs e)
        {
            try
            {
                string sql = string.Format("select * from tas_ngay_phep_nam where ma_nhan_vien = '{0}' and nam = {1}", _ma_nhanvien, txt_nam_nghiphep.Text);
                DataTable dt = new DataTable();
                dt = SQLHelper.ExecuteDt(sql);
                if (dt.Rows.Count > 0)
                {
                    string sql_update = string.Format("update tas_ngay_phep_nam set tong_ngay_qd = '{2}',tong_ngay_phep = '{3}',tong_ngay_ton = '{4}',ngay_cap_nhat = GETDATE(),phep_tham_nien = '{5}', phep_doc_hai = '{6}' " +
                        "where ma_nhan_vien = '{0}' and nam = {1}", _ma_nhanvien, txt_nam_nghiphep.Text,
                        txt_phep_qd.Text, txt_tong_ngayphep.Text, txt_tong_ngayton.Text,txt_phep_thamnien.Text,txt_phep_dochai.Text);
                    if (SQLHelper.ExecuteSql(sql_update) == 1)
                    {
                        RJMessageBox.Show("Cập nhật thành công", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
                else
                {
                    string sql_insert = string.Format("insert into tas_ngay_phep_nam(ma_nhan_vien,nam,tong_ngay_qd,tong_ngay_phep,tong_ngay_ton,id_nguoi_tao,phep_tham_nien,phep_doc_hai) " +
                        "values('{0}','{1}','{2}','{3}','{4}','{5}','{6}','{7}')",
                        _ma_nhanvien, txt_nam_nghiphep.Text, txt_phep_qd.Text, txt_tong_ngayphep.Text, txt_tong_ngayton.Text, SQLHelper.sIdUser, txt_phep_thamnien.Text,txt_phep_dochai.Text);
                    if (SQLHelper.ExecuteSql(sql_insert) == 1)
                    {
                        RJMessageBox.Show("Cập nhật thành công", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
                annual_leave.load_data(1);
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
