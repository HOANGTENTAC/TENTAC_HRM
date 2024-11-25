using ComponentFactory.Krypton.Toolkit;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;
using TENTAC_HRM.Common;
using TENTAC_HRM.Custom;
using TENTAC_HRM.Forms.User_control;

namespace TENTAC_HRM.Forms.Mst_Add_Data
{
    public partial class frmMstChungChi : KryptonForm
    {
        private uc_certificate _uc_certificate;
        private MstMaTuDong autoCodeGenerator;
        public string _MaChungChi { get; set; }
        public bool _Edit { get; set; }
        string _TenChungChi, _MoTa, _NguoiTao, _NguoiCapNhat;
        public frmMstChungChi(UserControl userControl)
        {
            InitializeComponent();
            autoCodeGenerator = new MstMaTuDong();
            _uc_certificate = (uc_certificate)userControl;
        }
        private void frmMstChungChi_Load(object sender, EventArgs e)
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
        private void LoadData()
        {
            labelX1.Text = "Cập Nhật Thông Tin Chứng Chỉ";
            string sql = string.Empty;
            sql = $@"Select MaChungChi, TenChungChi, MoTa, del_flg from mst_ChungChi where MaChungChi = {SQLHelper.rpStr(_MaChungChi)} and del_flg = 0";
            DataTable dt = new DataTable();
            dt = SQLHelper.ExecuteDt(sql);
            if (dt.Rows.Count > 0)
            {
                txtMaChungChi.Text = dt.Rows[0]["MaChungChi"].ToString();
                txtTenChungChi.Text = dt.Rows[0]["TenChungChi"].ToString();
                txtMoTa.Text = dt.Rows[0]["MoTa"].ToString();
            }
        }
        private void LoadNull()
        {
            txtMaChungChi.Text = autoCodeGenerator.GenerateNextCode("mst_ChungChi", "CC", "MaChungChi");
            txtTenChungChi.Text = string.Empty;
            txtMoTa.Text = string.Empty;
        }
        private void btn_save_Click(object sender, EventArgs e)
        {
            SetValues();
            if (_Edit == true)
            {
                UpdateData();
            }
            else
            {
                InsertData();
            }
            _uc_certificate.LoadData();
            LoadNull();
        }
        private void SetValues()
        {
            _MaChungChi = txtMaChungChi.Text.Trim().ToString();
            _TenChungChi = txtTenChungChi.Text.Trim().ToString();
            _MoTa = txtMoTa.Text.Trim().ToString();
            _NguoiTao = SQLHelper.sUser;
            _NguoiCapNhat = SQLHelper.sUser;
        }
        private void InsertData()
        {
            try
            {
                string sql = string.Empty;
                sql = $@"Insert into mst_ChungChi(MaChungChi, TenChungChi, MoTa, NgayTao, NguoiTao, NgayCapNhat, NguoiCapNhat, del_flg)
                Values({SQLHelper.rpStr(_MaChungChi)}, {SQLHelper.rpStr(_TenChungChi)}, {SQLHelper.rpStr(_MoTa)},  '{DateTime.Now}',
                {SQLHelper.rpStr(_NguoiTao)}, '{DateTime.Now}', {SQLHelper.rpStr(_NguoiCapNhat)}, 0)";
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
                sql = $@"Update mst_ChungChi Set MaChungChi = {SQLHelper.rpStr(_MaChungChi)}, TenChungChi = {SQLHelper.rpStr(_TenChungChi)},
                MoTa = {SQLHelper.rpStr(_MoTa)}, NgayCapNhat = '{DateTime.Now}', NguoiCapNhat = {SQLHelper.rpStr(_NguoiCapNhat)}
                Where MaChungChi = {SQLHelper.rpStr(_MaChungChi)} and del_flg = 0";
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
    }
}
