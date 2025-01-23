using ComponentFactory.Krypton.Toolkit;
using System;
using System.Data;
using System.Globalization;
using System.Windows.Forms;
using TENTAC_HRM.Consts;
using TENTAC_HRM.Custom;

namespace TENTAC_HRM.Forms.NghiPhep
{
    public partial class frm_nghiphepnam : KryptonForm
    {
        public int year { get; set; }
        public string _MaNhanVien { get; set; }
        uc_annual_leave annual_leave = new uc_annual_leave();
        public frm_nghiphepnam(uc_annual_leave _annual_leave)
        {
            InitializeComponent();
            annual_leave = _annual_leave;
        }

        private void frm_nghiphepnam_Load(object sender, EventArgs e)
        {
            string sql = string.Format("select TenNhanVien from MITACOSQL.dbo.NHANVIEN where MaNhanVien = '{0}'", _MaNhanVien);
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
            string sql = string.Format("select * from tbl_NgayPhepNam where MaNhanVien = '{0}' and Nam = '{1}'", _MaNhanVien, year);
            DataTable dt = new DataTable();
            dt = SQLHelper.ExecuteDt(sql);
            if (dt.Rows.Count > 0)
            {
                txt_phep_qd.Text = dt.Rows[0]["TongNgayQD"].ToString();
                txt_tong_ngayphep.Text = dt.Rows[0]["PhepCongDon"].ToString();
                txt_tong_ngayton.Text = dt.Rows[0]["TongNgayTon"].ToString();
                txt_phep_dochai.Text = dt.Rows[0]["PhepDocHai"].ToString();
                txt_phep_thamnien.Text = dt.Rows[0]["PhepThamNien"].ToString();
                txt_PhepTrongNam.Text = dt.Rows[0]["TongNgayPhep"].ToString();
            }
        }
        private void txt_phep_qd_Leave(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txt_phep_qd.Text))
            {
                txt_phep_qd.Text = "0";
            }
            //decimal phep_qd = decimal.Parse(txt_phep_qd.Text);
            txt_phep_qd.Text = decimal.Parse(txt_phep_qd.Text).ToString("N1", CultureInfo.InvariantCulture);
        }

        private void txt_tong_ngayphep_Leave(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txt_tong_ngayphep.Text))
            {
                txt_tong_ngayphep.Text = "0";
            }
            txt_tong_ngayphep.Text = decimal.Parse(txt_tong_ngayphep.Text).ToString("N1", CultureInfo.InvariantCulture);
        }

        private void txt_tong_ngayton_Leave(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txt_tong_ngayton.Text))
            {
                txt_tong_ngayton.Text = "0";
            }
            txt_tong_ngayton.Text = decimal.Parse(txt_tong_ngayton.Text).ToString("N1", CultureInfo.InvariantCulture);
        }

        private void btn_save_Click(object sender, EventArgs e)
        {
            try
            {
                string sql = string.Format("select * from tbl_NgayPhepNam where MaNhanVien = '{0}' and Nam = {1}", _MaNhanVien, txt_nam_nghiphep.Text);
                DataTable dt = new DataTable();
                dt = SQLHelper.ExecuteDt(sql);

                decimal tongphep = decimal.Parse(txt_tong_ngayphep.Text) +
                   decimal.Parse(txt_phep_dochai.Text) +
                   decimal.Parse(txt_phep_thamnien.Text) +
                   decimal.Parse(txt_tong_ngayton.Text);

                if (dt.Rows.Count > 0)
                {
                    string sql_update = string.Format("update tbl_NgayPhepNam set TongNgayQD = '{2}',TongNgayPhep = '{3}',TongNgayTon = '{4}',NgayCapNhat = GETDATE(),PhepThamNien = '{5}', PhepDocHai = '{6}', PhepCongDon = '{7}' " +
                        "where MaNhanVien = '{0}' and Nam = {1}", _MaNhanVien, txt_nam_nghiphep.Text,
                        txt_phep_qd.Text, tongphep, txt_tong_ngayton.Text, txt_phep_thamnien.Text, txt_phep_dochai.Text, txt_tong_ngayphep.Text);
                    if (SQLHelper.ExecuteSql(sql_update) == 1)
                    {
                        RJMessageBox.Show("Cập nhật thành công", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
                else
                {
                    string sql_insert = string.Format("insert into tbl_NgayPhepNam(MaNhanVien,Nam,TongNgayQD,TongNgayPhep,TongNgayTon,NguoiTao,PhepThamNien,PhepDocHai,PhepCongDon) " +
                        "values('{0}','{1}','{2}','{3}','{4}','{5}','{6}','{7}',{8})",
                        _MaNhanVien, txt_nam_nghiphep.Text, txt_phep_qd.Text, tongphep, txt_tong_ngayton.Text, LoginInfo.UserCd, txt_phep_thamnien.Text, txt_phep_dochai.Text, txt_tong_ngayphep.Text);
                    if (SQLHelper.ExecuteSql(sql_insert) == 1)
                    {
                        RJMessageBox.Show("Cập nhật thành công", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
                annual_leave.Load_data(1);
                //annual_leave.LoadDGV();
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

        private void txt_phep_thamnien_Leave(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txt_phep_thamnien.Text))
            {
                txt_phep_thamnien.Text = "0";
            }
            txt_phep_thamnien.Text = decimal.Parse(txt_phep_thamnien.Text).ToString("N1", CultureInfo.InvariantCulture);
        }

        private void txt_phep_dochai_Leave(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txt_phep_dochai.Text))
            {
                txt_phep_dochai.Text = "0";
            }
            txt_phep_dochai.Text = decimal.Parse(txt_phep_dochai.Text).ToString("N1", CultureInfo.InvariantCulture);
        }

        private void txt_phep_dochai_TextChanged(object sender, EventArgs e)
        {
            TongPhepTrongNam();
        }

        private void txt_phep_thamnien_TextChanged(object sender, EventArgs e)
        {
            TongPhepTrongNam();
        }

        private void txt_tong_ngayphep_TextChanged(object sender, EventArgs e)
        {
            TongPhepTrongNam();
        }

        private void txt_tong_ngayton_TextChanged(object sender, EventArgs e)
        {
            TongPhepTrongNam();
        }

        private void TongPhepTrongNam()
        {
            decimal tongphep = decimal.Parse(string.IsNullOrEmpty(txt_tong_ngayphep.Text) ? "0" : txt_tong_ngayphep.Text) +
                   decimal.Parse(string.IsNullOrEmpty(txt_phep_dochai.Text) ? "0" : txt_phep_dochai.Text) +
                   decimal.Parse(string.IsNullOrEmpty(txt_phep_thamnien.Text) ? "0" : txt_phep_thamnien.Text) +
                   decimal.Parse(string.IsNullOrEmpty(txt_tong_ngayton.Text) ? "0" : txt_tong_ngayton.Text);
            txt_PhepTrongNam.Text = tongphep.ToString("N1", CultureInfo.InvariantCulture);
        }
    }
}
