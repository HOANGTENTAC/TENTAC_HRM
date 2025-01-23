using ComponentFactory.Krypton.Toolkit;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;
using TENTAC_HRM.Common;
using TENTAC_HRM.Consts;
using TENTAC_HRM.Custom;
using TENTAC_HRM.Forms.User_control;

namespace TENTAC_HRM.Forms.Mst_Add_Data
{
    public partial class frmMstChuyenNganh : KryptonForm
    {
        private uc_major _uc_major;
        private MstMaTuDong autoCodeGenerator;
        public string _MaChuyenNganh { get; set; }
        public bool _Edit { get; set; }
        string _TenChuyenNganh, _MoTa, _NguoiTao, _NguoiCapNhat;
        public frmMstChuyenNganh(UserControl userControl)
        {
            InitializeComponent();
            autoCodeGenerator = new MstMaTuDong();
           
            _uc_major = (uc_major)userControl;
        }
        private void frmMstChuyenNganh_Load(object sender, EventArgs e)
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
            labelX1.Text = "Cập Nhật Thông Tin Chuyên Ngành";
            string sql = string.Empty;
            sql = $@"Select MaChuyenNganh, TenChuyenNganh, MoTa, del_flg from mst_ChuyenNganh Where MaChuyenNganh = {SQLHelper.rpStr(_MaChuyenNganh)} and del_flg = 0";
            DataTable dt = new DataTable();
            dt = SQLHelper.ExecuteDt(sql);
            if (dt.Rows.Count > 0)
            {
                txtMaChuyenNganh.Text = dt.Rows[0]["MaChuyenNganh"].ToString();
                txtTenChuyenNganh.Text = dt.Rows[0]["TenChuyenNganh"].ToString();
                txtMoTa.Text = dt.Rows[0]["MoTa"].ToString();
            }
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
            _uc_major.LoadData();
            LoadNull();
        }
        private void SetValues()
        {
            _MaChuyenNganh = txtMaChuyenNganh.Text.Trim().ToString();
            _TenChuyenNganh = txtTenChuyenNganh.Text.Trim().ToString();
            _MoTa = txtMoTa.Text.Trim().ToString();
            _NguoiTao = LoginInfo.UserCd;
            _NguoiCapNhat = LoginInfo.UserCd;
        }
        private void InsertData()
        {
            try
            {
                string sql = string.Empty;
                sql = $@"Insert into mst_ChuyenNganh(MaChuyenNganh, TenChuyenNganh, MoTa, NgayTao, NguoiTao, NgayCapNhat, NguoiCapNhat, del_flg)
                Values({SQLHelper.rpStr(_MaChuyenNganh)}, {SQLHelper.rpStr(_TenChuyenNganh)}, {SQLHelper.rpStr(_MoTa)}, '{DateTime.Now}',
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
                sql = $@"Update mst_ChuyenNganh Set MaChuyenNganh = {SQLHelper.rpStr(_MaChuyenNganh)}, TenChuyenNganh = {SQLHelper.rpStr(_TenChuyenNganh)},
                MoTa = {SQLHelper.rpStr(_MoTa)}, NgayCapNhat = '{DateTime.Now}', NguoiCapNhat = {SQLHelper.rpStr(_NguoiCapNhat)}
                Where MaChuyenNganh = {SQLHelper.rpStr(_MaChuyenNganh)} and del_flg = 0";
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
        private void LoadNull()
        {
            txtMaChuyenNganh.Text = autoCodeGenerator.GenerateNextCode("mst_ChuyenNganh", "CN", "MaChuyenNganh");
            txtTenChuyenNganh.Text = string.Empty;
            txtMoTa.Text = string.Empty;
        }
        private void btn_cancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
