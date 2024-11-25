using System;
using System.Windows.Forms;
using TENTAC_HRM.Custom;
using TENTAC_HRM.Forms.User_control;
using TENTAC_HRM.Common;
using ComponentFactory.Krypton.Toolkit;
using System.Data;

namespace TENTAC_HRM.Forms.Mst_Add_Data
{
    public partial class frmMstDanToc : KryptonForm
    {
        private uc_nation uc_nation;
        private MstMaTuDong autoCodeGenerator;
        public string _MaDanToc { get; set; }
        public bool _Edit { get; set; }
        string _TenDanToc, _MoTa, _NguoiTao, _NguoiCapNhat;
        public frmMstDanToc(uc_nation _uc_nation)
        {
            InitializeComponent();
            autoCodeGenerator = new MstMaTuDong();
            uc_nation = _uc_nation;
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
            LoadNull();
            uc_nation.LoadData();
        }

        private void frmMstDanToc_Load(object sender, EventArgs e)
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
            labelX1.Text = "Cập Nhật Thông Tin Dân Tộc";
            string sql = string.Empty;
            sql = $@"Select MaDanToc, TenDanToc, MoTa, del_flg from mst_DanToc where MaDanToc = {SQLHelper.rpStr(_MaDanToc)}";
            DataTable dt = SQLHelper.ExecuteDt(sql);
            if (dt.Rows.Count > 0)
            {
                txtMaDanToc.Text = dt.Rows[0]["MaDanToc"].ToString();
                txtTenDanToc.Text = dt.Rows[0]["TenDanToc"].ToString();
                txtMoTa.Text = dt.Rows[0]["MoTa"].ToString();
            }
        }
        private void LoadNull()
        {
            txtMaDanToc.Text = autoCodeGenerator.GenerateNextCode("mst_DanToc", "DT", "MaDanToc");
            txtTenDanToc.Text = string.Empty;
            txtMoTa.Text = string.Empty;
        }
        private void SetValues()
        {
            _MaDanToc = txtMaDanToc.Text.Trim().ToString();
            _TenDanToc = txtTenDanToc.Text.Trim().ToString();
            _MoTa = txtMoTa.Text.Trim().ToString();
            _NguoiTao = SQLHelper.sUser;
            _NguoiCapNhat = SQLHelper.sUser;
        }
        private void InsertData()
        {
            try
            {
                string sql = string.Empty;
                sql = $@"Insert into mst_DanToc(MaDanToc, TenDanToc, MoTa, NgayTao, NguoiTao, NgayCapNhat, NguoiCapNhat, del_flg)
                Values({SQLHelper.rpStr(_MaDanToc)}, {SQLHelper.rpStr(_TenDanToc)}, {SQLHelper.rpStr(_MoTa)}, '{DateTime.Now}', 
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
                sql = $@"Update mst_DanToc Set MaDanToc = {SQLHelper.rpStr(_MaDanToc)}, TenDanToc = {SQLHelper.rpStr(_TenDanToc)},
                MoTa = {SQLHelper.rpStr(_MoTa)}, NgayCapNhat = '{DateTime.Now}', NguoiCapNhat = {SQLHelper.rpStr(_NguoiCapNhat)}
                Where MaDanToc = {SQLHelper.rpStr(_MaDanToc)} and del_flg = 0";
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
