using ComponentFactory.Krypton.Toolkit;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using TENTAC_HRM.Common;
using TENTAC_HRM.Custom;
using TENTAC_HRM.Forms.User_control;

namespace TENTAC_HRM.Forms.Mst_Add_Data
{
    public partial class frmMstPhongBan : KryptonForm
    {
        private uc_departments uc_departments;
        private MstMaTuDong autoCodeGenerator;
        public string _MaPhongBan { get; set; }
        public bool _Edit { get; set; }
        private string _TenPhongBan, _CongTy, _KhuVuc, _NguoiTao, _NguoiCapNhat;
        public frmMstPhongBan(uc_departments _uc_departments)
        {
            InitializeComponent();
            autoCodeGenerator = new MstMaTuDong();

            uc_departments = _uc_departments;
        }
        private void frmMstPhongBan_Load(object sender, EventArgs e)
        {
            LoadCongTy();
            LoadKhuVuc(null);
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
            labelX1.Text = "Cập Nhật Thông Tin Phòng Ban";
            string sql = string.Empty;
            sql = $@"Select MaPhongBan, MaCongTy, MaKhuVuc, TenPhongBan from [MITACOSQL].[dbo].[PHONGBAN] where MaPhongBan = {SQLHelper.rpStr(_MaPhongBan)}";
            DataTable dt = SQLHelper.ExecuteDt(sql);
            if (dt.Rows.Count > 0)
            {
                txtMaPhongBan.Text = dt.Rows[0]["MaPhongBan"].ToString();
                txtTenPhongBan.Text = dt.Rows[0]["TenPhongBan"].ToString();
                cbMaCongTy.SelectedValue = dt.Rows[0]["MaCongTy"].ToString();
                cbMaKhuVuc.SelectedValue = dt.Rows[0]["MaKhuVuc"].ToString();
            }
        }
        private void LoadCongTy()
        {
            string sql = @"select MaCongTy, TenCongTy from MITACOSQL.dbo.CONGTY";
            DataTable DT = SQLHelper.ExecuteDt(sql);

            DataRow row = DT.NewRow();
            row["MaCongTy"] = DBNull.Value;
            row["TenCongTy"] = "";
            DT.Rows.InsertAt(row, 0);

            cbMaCongTy.DataSource = DT;
            cbMaCongTy.DisplayMember = "TenCongTy";
            cbMaCongTy.ValueMember = "MaCongTy";
        }
        private void LoadKhuVuc(string maCongTy)
        {
            string sql = $@"select MaKhuVuc, TenKhuVuc, MaCongTy from MITACOSQL.dbo.KHUVUC where MaCongTy = {SQLHelper.rpStr(maCongTy)}";
            DataTable DT = SQLHelper.ExecuteDt(sql);

            DataRow row = DT.NewRow();
            row["MaKhuVuc"] = DBNull.Value;
            row["TenKhuVuc"] = "";
            DT.Rows.InsertAt(row, 0);

            cbMaKhuVuc.DataSource = DT;
            cbMaKhuVuc.DisplayMember = "TenKhuVuc";
            cbMaKhuVuc.ValueMember = "MaKhuVuc";
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
            uc_departments.LoadData();
            LoadNull();
        }
        private void LoadNull()
        {
            txtMaPhongBan.Text = autoCodeGenerator.GenerateNextMaPhongBan();
            cbMaCongTy.SelectedIndex = 0;
            cbMaKhuVuc.SelectedIndex = 0;
            txtTenPhongBan.Text = string.Empty;
        }
        private void SetValues()
        {
            _MaPhongBan = txtMaPhongBan.Text.Trim().ToString();
            _TenPhongBan = txtTenPhongBan.Text.Trim().ToString();
            _CongTy = cbMaCongTy.SelectedValue.ToString();
            _KhuVuc = cbMaKhuVuc.SelectedValue.ToString();
            _NguoiTao = SQLHelper.sUser;
            _NguoiCapNhat = SQLHelper.sUser;
        }
        private void InsertData()
        {
            try
            {
                string sql = string.Empty;
                sql = $@"Insert into [MITACOSQL].[dbo].[PHONGBAN](MaPhongBan, MaCongTy, MaKhuVuc, TenPhongBan)
                Values({SQLHelper.rpStr(_MaPhongBan)}, {SQLHelper.rpStr(_CongTy)}, {SQLHelper.rpStr(_KhuVuc)}, {SQLHelper.rpStr(_TenPhongBan)})";
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
                sql = $@"Update [MITACOSQL].[dbo].[PHONGBAN] Set MaPhongBan = {SQLHelper.rpStr(_MaPhongBan)}, MaCongTy = {SQLHelper.rpStr(_CongTy)},
                MaKhuVuc = {SQLHelper.rpStr(_KhuVuc)}, TenPhongBan = {SQLHelper.rpStr(_TenPhongBan)}
                Where MaPhongBan = {SQLHelper.rpStr(_MaPhongBan)}";
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

        private void cbMaCongTy_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cbMaCongTy.SelectedIndex != 0)
            {
                cbMaKhuVuc.Enabled = true;
                string MaCongTy = cbMaCongTy.SelectedValue.ToString();
                LoadKhuVuc(MaCongTy);
            }
            else
            {
                cbMaKhuVuc.Enabled = false;
            }
        }
    }
}
