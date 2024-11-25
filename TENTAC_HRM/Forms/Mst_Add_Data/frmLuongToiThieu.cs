using ComponentFactory.Krypton.Toolkit;
using iTextSharp.text.xml;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Globalization;
using System.Web.UI.WebControls.WebParts;
using System.Windows.Forms;
using TENTAC_HRM.Common;
using TENTAC_HRM.Custom;
using TENTAC_HRM.Forms.User_control;

namespace TENTAC_HRM.Forms.Mst_Add_Data
{
    public partial class frmLuongToiThieu : KryptonForm
    {
        private uc_minimum_salary _uc_minimum_salary;
        private MstMaTuDong autoCodeGenerator;
        public int _IDVung { get; set; }
        public bool _Edit { get; set; }
        string _Vung, _GhiChu, _NamHienHanh, _NguoiTao, _NguoiCapNhat;
        decimal? _LuongToiThieuTheoThang, _LuongToiThieuTheoGio;
        public frmLuongToiThieu(UserControl userControl)
        {
            InitializeComponent();
            _uc_minimum_salary = (uc_minimum_salary)userControl;
            load_comboBoxYear();
        }
        private void txt_mucluong_Leave(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(txtLuongToiThieuTheoGio.Text))
            {
                txtLuongToiThieuTheoGio.Text = decimal.Parse(txtLuongToiThieuTheoGio.Text).ToString("N0", CultureInfo.InvariantCulture);
            }
            if (!string.IsNullOrEmpty(txtLuongToiThieuTheoThang.Text))
            {
                txtLuongToiThieuTheoThang.Text = decimal.Parse(txtLuongToiThieuTheoThang.Text).ToString("N0", CultureInfo.InvariantCulture);
            }
        }
        private void LoadData()
        {
            labelX1.Text = "Cập Nhật Thông Tin Vùng";
            string sql = string.Empty;
            sql = $@"Select Id, Vung, LuongToiThieuTheoThang, LuongToiThieuTheoGio, NamHienHanh, GhiChu from tbl_MucLuongToiThieu where ID = {SQLHelper.rpI(_IDVung)} and del_flg = 0";
            DataTable dt = new DataTable();
            dt = SQLHelper.ExecuteDt(sql);
            if (dt.Rows.Count > 0)
            {
                txtTenVung.Text = dt.Rows[0]["Vung"].ToString();
                txtLuongToiThieuTheoThang.Text = string.IsNullOrEmpty(dt.Rows[0]["LuongToiThieuTheoThang"].ToString()) ? "" : ((decimal)dt.Rows[0]["LuongToiThieuTheoThang"]).ToString("N0", CultureInfo.InvariantCulture);
                txtLuongToiThieuTheoGio.Text = string.IsNullOrEmpty(dt.Rows[0]["LuongToiThieuTheoGio"].ToString()) ? "" : ((decimal)dt.Rows[0]["LuongToiThieuTheoThang"]).ToString("N0", CultureInfo.InvariantCulture);
                cbo_NamHienHanh.Text = dt.Rows[0]["NamHienHanh"].ToString();
                txtGhiChu.Text = dt.Rows[0]["GhiChu"].ToString();
            }
        }
        private void btn_save_Click(object sender, EventArgs e)
        {
            SetValues();
            if(_Edit == true)
            {
               UpdateData();
            }
            else
            {
                InsertData();
            }
            _uc_minimum_salary.LoadData();
            LoadNull();
        }

        private void frmLuongToiThieu_Load(object sender, EventArgs e)
        {
            if (_Edit == true)
            {
                LoadData();
            }
            else
            {
                LoadNull();
            }
        }
        private void load_comboBoxYear()
        {
            for (int year = DateTime.Now.Year; year >= 2007; year--)
            {
                cbo_NamHienHanh.Items.Add(year);
            }
        }
        private void LoadNull()
        {
            txtLuongToiThieuTheoGio.Text = string.Empty;
            txtLuongToiThieuTheoThang.Text = string.Empty;
            txtTenVung.Text = string.Empty;
            txtGhiChu.Text = string.Empty;
            cbo_NamHienHanh.Text = string.Empty;
        }
        private void SetValues()
        {
            _Vung = txtTenVung.Text.Trim().ToString();
            _LuongToiThieuTheoGio = string.IsNullOrEmpty(txtLuongToiThieuTheoGio.Text.Trim()) ? (decimal?)null : decimal.Parse(txtLuongToiThieuTheoGio.Text.Trim());
            _LuongToiThieuTheoThang = string.IsNullOrEmpty(txtLuongToiThieuTheoThang.Text.Trim()) ? (decimal?)null : decimal.Parse(txtLuongToiThieuTheoThang.Text.Trim());
            _NamHienHanh = cbo_NamHienHanh.Text.ToString();
            _GhiChu = txtGhiChu.Text.Trim().ToString();
            _NguoiTao = SQLHelper.sUser;
            _NguoiCapNhat = SQLHelper.sUser;
        }
        private void InsertData()
        {
            try
            {
                string sql = string.Empty;
                sql = $@"Insert into tbl_MucLuongToiThieu(Vung, LuongToiThieuTheoThang, LuongToiThieuTheoGio, NamHienHanh, GhiChu, NguoiTao,
                NgayTao, NguoiCapNhat, NgayCapNhat, del_flg)
                Values({SQLHelper.rpStr(_Vung)}, {SQLHelper.rpD(_LuongToiThieuTheoThang)}, {SQLHelper.rpD(_LuongToiThieuTheoGio)}, 
                {SQLHelper.rpStr(_NamHienHanh)}, {SQLHelper.rpStr(_GhiChu)}, {SQLHelper.rpStr(_NguoiTao)}, '{DateTime.Now}',
                {SQLHelper.rpStr(_NguoiCapNhat)}, '{DateTime.Now}', 0)";
                int res = SQLHelper.ExecuteSql(sql);
                if (res > 0)
                {
                    RJMessageBox.Show("Thêm dữ liệu thành công.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    RJMessageBox.Show("Thêm dữ liệu thất bại.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                RJMessageBox.Show(ex.Message, "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void UpdateData()
        {
            try
            {
                string sql = string.Empty;
                sql = $@"Update tbl_MucLuongToiThieu Set Vung = {SQLHelper.rpStr(_Vung)}, LuongToiThieuTheoThang = {SQLHelper.rpD(_LuongToiThieuTheoThang)},
                LuongToiThieuTheoGio = {SQLHelper.rpD(_LuongToiThieuTheoGio)}, NamHienHanh = {SQLHelper.rpStr(_NamHienHanh)}, GhiChu = {SQLHelper.rpStr(_GhiChu)},
                NgayCapNhat = '{DateTime.Now}', NguoiCapNhat = {SQLHelper.rpStr(_NguoiCapNhat)}
                Where Id = {SQLHelper.rpI(_IDVung)} and del_flg = 0";
                int res = SQLHelper.ExecuteSql(sql);
                if (res > 0)
                {
                    RJMessageBox.Show("Cập nhật dữ liệu thành công.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    RJMessageBox.Show("Cập nhật dữ liệu thất bại.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                RJMessageBox.Show(ex.Message, "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void btn_cancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        private void textBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && e.KeyChar != '.')
            {
                e.Handled = true;
            }
            if (e.KeyChar == '.' && (txtLuongToiThieuTheoGio.Text.Contains(".") || txtLuongToiThieuTheoThang.Text.Contains(".")))
            {
                e.Handled = true;
            }
        }
        private void btn_close_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}