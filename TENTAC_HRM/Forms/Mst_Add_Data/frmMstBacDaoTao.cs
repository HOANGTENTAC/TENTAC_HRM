using ComponentFactory.Krypton.Toolkit;
using NPOI.SS.Formula.Functions;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;
using TENTAC_HRM.Common;
using TENTAC_HRM.Custom;
using TENTAC_HRM.Forms.User_control;
using static NPOI.POIFS.Crypt.CryptoFunctions;

namespace TENTAC_HRM.Forms.Mst_Add_Data
{
    public partial class frmMstBacDaoTao : KryptonForm
    {
        private uc_education_level _uc_education_level;
        private MstMaTuDong autoCodeGenerator;
        public int _IDTrinhDo { get; set; }
        public bool _Edit { get; set; }
        string _MaBac, _TenBac, _GhiChu, _NguoiTao, _NguoiCapNhat;
        public frmMstBacDaoTao(UserControl userControl)
        {
            InitializeComponent();
            autoCodeGenerator = new MstMaTuDong();
            _uc_education_level = (uc_education_level)userControl;
        }
        private void frmMstBacDaoTao_Load(object sender, EventArgs e)
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
            SetValues();
            if (_Edit == true)
            {
                UpdateData();
            }
            else
            {
                InsertData();
            }
            _uc_education_level.LoadData();
            LoadNull();
        }
        private void LoadData()
        {
            labelX1.Text = "Cập Nhật Thông Tin Bậc Đào Tạo";
            string sql = string.Empty;
            sql = $@"Select Id, MaBac, TenBac, MoTa, del_flg from mst_BacDaoTao Where Id = {SQLHelper.rpI(_IDTrinhDo)} and del_flg =0";
            DataTable dt = new DataTable();
            dt = SQLHelper.ExecuteDt(sql);
            if (dt.Rows.Count > 0)
            {
                txtMaTrinhDo.Text = dt.Rows[0]["MaBac"].ToString();
                txtTenTrinhDo.Text = dt.Rows[0]["TenBac"].ToString();
                txtMoTa.Text = dt.Rows[0]["MoTa"].ToString();
            }
        }
        private void LoadNull()
        {
            txtMaTrinhDo.Text = autoCodeGenerator.GenerateNextCode("mst_BacDaoTao", "TD", "MaBac");
            txtTenTrinhDo.Text = string.Empty;
            txtMoTa.Text = string.Empty;
        }
        private void SetValues()
        {
            _MaBac = txtMaTrinhDo.Text.Trim().ToUpper().ToString();
            _TenBac = txtTenTrinhDo.Text.Trim().ToString();
            _GhiChu = txtMoTa.Text.Trim().ToString();
            _NguoiTao = SQLHelper.sUser;
            _NguoiCapNhat = SQLHelper.sUser;
        }
        private void InsertData()
        {
            try
            {
                string sql = string.Empty;
                sql = $@"Insert into mst_BacDaoTao(MaBac, TenBac, MoTa, NgayTao, NguoiTao, NgayCapNhat, NguoiCapNhat, del_flg)
                Values({SQLHelper.rpStr(_MaBac)}, {SQLHelper.rpStr(_TenBac)}, {SQLHelper.rpStr(_GhiChu)}, '{DateTime.Now}',
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
                sql = $@"Update mst_BacDaoTao Set MaBac = {SQLHelper.rpStr(_MaBac)}, TenBac = {SQLHelper.rpStr(_TenBac)},
                MoTa = {SQLHelper.rpStr(_GhiChu)}, NgayCapNhat = '{DateTime.Now}', NguoiCapNhat = {SQLHelper.rpStr(_NguoiCapNhat)}
                Where Id = {SQLHelper.rpI(_IDTrinhDo)} and del_flg = 0";
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