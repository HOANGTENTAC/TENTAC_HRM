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
    public partial class frmMstNgoaiNgu : KryptonForm
    {
        private MstMaTuDong autoCodeGenerator;
        private uc_foreign_languages uc_foreign_languages;
        public string _MaNgoaiNgu {  get; set; }
        public bool _Edit {  get; set; }
        private string _TenNgoaiNgu, _MoTa, _NguoiTao, _NguoiCapNhat;
        public frmMstNgoaiNgu(uc_foreign_languages _uc_foreign_languages)
        {
            InitializeComponent();
            autoCodeGenerator = new MstMaTuDong();
            uc_foreign_languages = _uc_foreign_languages;
        }
        private void frmMstNgoaiNgu_Load(object sender, EventArgs e)
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
        private void btn_save_Click(object sender, EventArgs e)
        {
            try
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
                uc_foreign_languages.load_data();
                LoadNull();
            }
            catch (Exception ex)
            {
                RJMessageBox.Show(ex.Message, "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void SetValues()
        {
            _MaNgoaiNgu = txtMaNgoaiNgu.Text.Trim().ToString();
            _TenNgoaiNgu = txtTenNgoaiNgu.Text.Trim().ToString();
            _MoTa = txtMoTa.Text.Trim().ToString();
            _NguoiTao = LoginInfo.UserCd;
            _NguoiCapNhat = LoginInfo.UserCd;
        }
        private void LoadData()
        {
            labelX1.Text = "Cập Nhật Thông Tin Ngoại Ngữ";
            string sql = string.Empty;
            sql = $@"Select MaNgoaiNgu, TenNgoaiNgu, MoTa from mst_NgoaiNgu Where MaNgoaiNgu = {SQLHelper.rpStr(_MaNgoaiNgu)} del_flg = 0";
            DataTable dt = SQLHelper.ExecuteDt(sql);
            if(dt.Rows.Count > 0)
            {
                txtMaNgoaiNgu.Text = dt.Rows[0]["MaNgoaiNgu"].ToString();
                txtTenNgoaiNgu.Text = dt.Rows[0]["TenNgoaiNgu"].ToString();
                txtMoTa.Text = dt.Rows[0]["MoTa"].ToString();
            }
        }
        private void LoadNull()
        {
            txtMaNgoaiNgu.Text = autoCodeGenerator.GenerateNextCode("mst_NgoaiNgu", "NN", "MaNgoaiNgu");
            txtTenNgoaiNgu.Text = string.Empty;
            txtMoTa.Text = string.Empty;
        }
        private void InsertData()
        {
            try
            {
                string sql = string.Empty;
                sql = $@"Insert into mst_NgoaiNgu(MaNgoaiNgu, TenNgoaiNgu, MoTa, NgayTao, NguoiTao, NgayCapNhat, NguoiCapNhat, del_flg)
                Values({SQLHelper.rpStr(_MaNgoaiNgu)}, {SQLHelper.rpStr(_TenNgoaiNgu)}, {SQLHelper.rpStr(_MoTa)}, '{DateTime.Now}', 
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
                sql = $@"Update mst_NgoaiNgu Set MaNgoaiNgu = {SQLHelper.rpStr(_MaNgoaiNgu)}, TenNgoaiNgu = {SQLHelper.rpStr(_TenNgoaiNgu)},
                MoTa = {SQLHelper.rpStr(_MoTa)}, NgayCapNhat = '{DateTime.Now}', NguoiCapNhat = {SQLHelper.rpStr(_NguoiCapNhat)}
                Where MaNgoaiNgu = {SQLHelper.rpStr(_MaNgoaiNgu)} and del_flg = 0";
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
