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
    public partial class frmMstChucVu : KryptonForm
    {
        private uc_position _uc_position;
        private MstMaTuDong autoCodeGenerator;
        public string _MaChucVu { get; set; }
        public bool _Edit { get; set; }
        string _TenChucVu, _MoTa, _NguoiTao, _NguoiCapNhat;
        public frmMstChucVu(UserControl userControl)
        {
            InitializeComponent();
            autoCodeGenerator = new MstMaTuDong();
            _uc_position = (uc_position)userControl;
        }
        private void LoadData()
        {
            labelX1.Text = "Cập Nhật Thông Tin Chức Vụ";
            string sql = string.Empty;
            sql = $@"Select MaChucVu, TenChucVu, MoTa, del_flg from mst_ChucVu Where MaChucVu = {SQLHelper.rpStr(_MaChucVu)} and del_flg = 0";
            DataTable dt = new DataTable();
            dt = SQLHelper.ExecuteDt(sql);
            if (dt.Rows.Count > 0)
            {
                txtMaChucVu.Text = dt.Rows[0]["MaChucVu"].ToString();
                txtTenChucVu.Text = dt.Rows[0]["TenChucVu"].ToString();
                txtMoTa.Text = dt.Rows[0]["MoTa"].ToString();
            }
        }

        private void frmMstChucVu_Load(object sender, EventArgs e)
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
                if (_Edit == true)
                {
                    UpdateData();
                }
                else
                {
                    InsertData();
                }
                _uc_position.LoadData();
                LoadNull();
            }
            catch (Exception ex)
            {
                RJMessageBox.Show(ex.Message, "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void LoadNull()
        {
            txtMaChucVu.Text = autoCodeGenerator.GenerateNextMaChucVu();
            txtTenChucVu.Text = string.Empty;
            txtMoTa.Text = string.Empty;
        }
        private void SetValues()
        {
            _MaChucVu = txtMaChucVu.Text.Trim().ToString();
            _TenChucVu = txtTenChucVu.Text.Trim().ToString();
            _MoTa = txtMoTa.Text.Trim().ToString();
            _NguoiTao = SQLHelper.sUser;
            _NguoiCapNhat = SQLHelper.sUser;
        }
        private void InsertData()
        {
            try
            {
                string sql = string.Empty;
                sql = $@"Insert into mst_ChucVu(MaChucVu, TenChucVu, MoTa, NgayTao, NguoiTao, NgayCapNhat, NguoiCapNhat, del_flg)
                Values({SQLHelper.rpStr(_MaChucVu)}, {SQLHelper.rpStr(_TenChucVu)}, {SQLHelper.rpStr(_MoTa)}, '{DateTime.Now}',
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
                sql = $@"Update mst_ChucVu Set MaChucVu = {SQLHelper.rpStr(_MaChucVu)}, TenChucVu = {SQLHelper.rpStr(_TenChucVu)},
                MoTa = {SQLHelper.rpStr(_MoTa)}, NgayCapNhat = '{DateTime.Now}', NguoiCapNhat = {SQLHelper.rpStr(_NguoiCapNhat)}
                Where MaChucVu = {SQLHelper.rpStr(_MaChucVu)} and del_flg = 0";
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
