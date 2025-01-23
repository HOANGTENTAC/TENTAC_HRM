using ComponentFactory.Krypton.Toolkit;
using System;
using System.Data;
using System.Windows.Forms;
using TENTAC_HRM.Common;
using TENTAC_HRM.Consts;
using TENTAC_HRM.Custom;
using TENTAC_HRM.Forms.NhanSu;

namespace TENTAC_HRM.Forms.Mst_Add_Data
{
    public partial class frmMstTonGiao : KryptonForm
    {
        private uc_staff_religion uc_staff_religion;
        private static MstMaTuDong autoCodeGenerator = new MstMaTuDong();
        public string _MaTonGiao { get; set; }
        public bool _Edit { get; set; }
        private string _TenTonGiao, _MoTa, _NguoiTao, _NguoiCapNhat;
        public frmMstTonGiao(uc_staff_religion _uc_staff_religion)
        {
            InitializeComponent();

            autoCodeGenerator = new MstMaTuDong();
            uc_staff_religion = _uc_staff_religion;
        }
        private void frmMstTonGiao_Load(object sender, EventArgs e)
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
            labelX1.Text = "Cập Nhật Thông Tin Tôn Giáo";
            string sql = string.Empty;
            sql = $@"Select MaTonGiao, TenTonGiao, MoTa, del_flg from [TENTAC_HRM].[dbo].[mst_TonGiao] where MaTonGiao = {SQLHelper.rpStr(_MaTonGiao)} and del_flg = 0";
            DataTable dt = SQLHelper.ExecuteDt(sql);
            if (dt.Rows.Count > 0)
            {
                txtMaTonGiao.Text = dt.Rows[0]["MaTonGiao"].ToString();
                txtTenTonGiao.Text = dt.Rows[0]["TenTonGiao"].ToString();
                txtMoTa.Text = dt.Rows[0]["MoTa"].ToString();
            }
        }
        private void LoadNull()
        {
            txtMaTonGiao.Text = autoCodeGenerator.GenerateNextCode("mst_TonGiao", "TG", "MaTonGiao");
            txtTenTonGiao.Text = string.Empty;
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
            uc_staff_religion.LoadData();
            LoadNull();
        }
        private void SetValues()
        {
            _MaTonGiao = txtMaTonGiao.Text.Trim().ToString();
            _TenTonGiao = txtTenTonGiao.Text.Trim().ToString();
            _MoTa = txtMoTa.Text.Trim().ToString();
            _NguoiTao = LoginInfo.UserCd;
            _NguoiCapNhat = LoginInfo.UserCd;
        }
        private void InsertData()
        {
            try
            {
                string sql = string.Empty;
                sql = $@"Insert into mst_TonGiao(MaTonGiao, TenTonGiao, MoTa, NgayTao, NguoiTao, NgayCapNhat, NguoiCapNhat, del_flg)
                Values({SQLHelper.rpStr(_MaTonGiao)}, {SQLHelper.rpStr(_TenTonGiao)}, {SQLHelper.rpStr(_MoTa)}, '{DateTime.Now}', 
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
                sql = $@"Update mst_TonGiao Set MaTonGiao = {SQLHelper.rpStr(_MaTonGiao)}, TenTonGiao = {SQLHelper.rpStr(_TenTonGiao)},
                MoTa = {SQLHelper.rpStr(_MoTa)}, NgayCapNhat = '{DateTime.Now}', NguoiCapNhat = {SQLHelper.rpStr(_NguoiCapNhat)}
                Where MaTonGiao = {SQLHelper.rpStr(_MaTonGiao)} and del_flg = 0";
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
