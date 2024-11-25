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
    public partial class frmMstLoaiPhep : KryptonForm
    {
        private uc_leave_type uc_leave_type;
        private MstMaTuDong autoCodeGenerator;
        public string _MaLoaiPhep;
        public bool _Edit;
        string _TenLoaiPhep, _KyHieu, _MoTa, _NguoiTao, _NguoiCapNhat;
        double _SoCong = 0;
        public frmMstLoaiPhep(uc_leave_type _uc_leave_type)
        {
            InitializeComponent();
            autoCodeGenerator = new MstMaTuDong();
            uc_leave_type = _uc_leave_type;
        }
        private void frmMstLoaiPhep_Load(object sender, EventArgs e)
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
            labelX1.Text = "Cập Nhật Thông Tin Loại Phép";
            string sql = string.Empty;
            sql = $@"Select MaLoaiPhep, TenLoaiPhep, KyHieu, SoCong, MoTa, del_flg from mst_LoaiPhep where MaLoaiPhep = {SQLHelper.rpStr(_MaLoaiPhep)} and del_flg = 0";
            DataTable dt = SQLHelper.ExecuteDt(sql);
            if (dt.Rows.Count > 0)
            {
                txtMaLoaiPhep.Text = dt.Rows[0]["MaLoaiPhep"].ToString();
                txtTenLoaiPhep.Text = dt.Rows[0]["TenLoaiPhep"].ToString();
                txtKyHieu.Text = dt.Rows[0]["KyHieu"].ToString();
                txtSoNgayCong.Text = dt.Rows[0]["SoCong"].ToString();
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
            uc_leave_type.LoadData();
            LoadNull();
        }
        private void LoadNull()
        {
            txtMaLoaiPhep.Text = autoCodeGenerator.GenerateNextCode("mst_LoaiPhep", "LP", "MaLoaiPhep");
            txtTenLoaiPhep.Text = string.Empty;
            txtKyHieu.Text = string.Empty;
            txtSoNgayCong.Text = "0";
            txtMoTa.Text = string.Empty;
        }
        private void SetValues()
        {
            _MaLoaiPhep = txtMaLoaiPhep.Text.Trim().ToString();
            _TenLoaiPhep = txtTenLoaiPhep.Text.Trim().ToString();
            _KyHieu = txtKyHieu.Text.Trim().ToString();
            _SoCong = string.IsNullOrEmpty(txtSoNgayCong.Text.Trim()) ? 0 : double.Parse(txtSoNgayCong.Text.Trim());
            _MoTa = txtMoTa.Text.Trim().ToString();
            _NguoiTao = SQLHelper.sUser;
            _NguoiCapNhat = SQLHelper.sUser;
        }
        private void InsertData()
        {
            try
            {
                string sql = string.Empty;
                sql = $@"Insert into mst_LoaiPhep(MaLoaiPhep, TenLoaiPhep, KyHieu, SoCong, MoTa, NgayTao, NguoiTao, NgayCapNhat, NguoiCapNhat, del_flg)
                Values({SQLHelper.rpStr(_MaLoaiPhep)}, {SQLHelper.rpStr(_TenLoaiPhep)}, {SQLHelper.rpStr(_KyHieu)}, {SQLHelper.rpDouble(_SoCong)}, 
                {SQLHelper.rpStr(_MoTa)}, '{DateTime.Now}', {SQLHelper.rpStr(_NguoiTao)}, '{DateTime.Now}', {SQLHelper.rpStr(_NguoiCapNhat)}, 0)";
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
                sql = $@"Update mst_LoaiPhep Set TenLoaiPhep = {SQLHelper.rpStr(_TenLoaiPhep)}, KyHieu = {SQLHelper.rpStr(_KyHieu)},
                SoCong = {SQLHelper.rpDouble(_SoCong)}, MoTa = {SQLHelper.rpStr(_MoTa)}, NgayCapNhat = '{DateTime.Now}', 
                NguoiCapNhat = {SQLHelper.rpStr(_NguoiCapNhat)}
                Where MaLoaiPhep = {SQLHelper.rpStr(_MaLoaiPhep)} and del_flg = 0";
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
            if (e.KeyChar == '.' && txtSoNgayCong.Text.Contains("."))
            {
                e.Handled = true;
            }
        }
    }
}