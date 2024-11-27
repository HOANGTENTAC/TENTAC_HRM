using ComponentFactory.Krypton.Toolkit;
using System;
using System.Data;
using System.Windows.Forms;
using TENTAC_HRM.Custom;
using TENTAC_HRM.Forms.Main;

namespace TENTAC_HRM.Forms.Category
{
    public partial class frm_story : KryptonForm
    {
        public string _MaNhanVien { get; set; }
        public string _IdTieuSu { get; set; }
        string _TuNam, _DenNam, _CongViec, _NguoiTao, _NguoiCapNhat;
        int quocgia_value;
        frm_personnel personnel;
        public bool edit { get; set; }
        public frm_story(frm_personnel _personnel)
        {
            InitializeComponent();
            personnel = _personnel;
        }
        private void frm_story_Load(object sender, EventArgs e)
        {
            LoadComboboxQuocGia();
            LoadComboboxYear();
            if (edit == true)
            {
                LoadData();
            }
        }
        protected virtual bool IsValidChar(char c)
        {
            return (c >= '0' && c <= '9') || (c == (char)Keys.Back) || (c == (char)Keys.Delete);
        }
        private void event_keypress(KeyPressEventArgs e)
        {
            if (!IsValidChar(e.KeyChar))
            {
                e.Handled = true;
                return;
            }
            base.OnKeyPress(e);
        }
        private void txt_tu_nam_KeyPress(object sender, KeyPressEventArgs e)
        {
            event_keypress(e);
        }
        private void frm_story_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
            {
                this.Close();
            }
        }
        private void LoadNull()
        {
            cbo_TuNam.Text = string.Empty;
            cbo_DenNam.Text = string.Empty;
            txt_cong_viec.Text = string.Empty;
            cbo_QuocGia.SelectedIndex = 0;
        }
        private void LoadData()
        {
            string sql = string.Format("select * from tbl_NhanVienTieuSu where Id = {0}", _IdTieuSu);
            DataTable dt = new DataTable();
            dt = SQLHelper.ExecuteDt(sql);
            if (dt.Rows.Count > 0)
            {
                cbo_TuNam.Text = dt.Rows[0]["TuNam"].ToString();
                cbo_DenNam.Text = dt.Rows[0]["DenNam"].ToString();
                txt_cong_viec.Text = dt.Rows[0]["CongViec"].ToString();
                cbo_QuocGia.SelectedValue = dt.Rows[0]["Id_QuocGia"].ToString();
            }
        }
        private void LoadComboboxYear()
        {
            for (int year = 1990; year <= DateTime.Now.Year; year++)
            {
                cbo_TuNam.Items.Add(year);
                cbo_DenNam.Items.Add(year);
            }
        }
        private void btn_save_close_Click(object sender, EventArgs e)
        {
            if (edit == true)
            {
                UpdateData();
            }
            else
            {
                InsertData();
            }
            personnel.LoadNhanVienTieuSu();
            LoadNull();
            this.Close();
        }
        private void LoadComboboxQuocGia()
        {
            string sql = "select Id, TenDiaChi from mst_DonViHanhChinh where ParentId is null and del_flg = 0";
            DataTable dt = new DataTable();
            dt = SQLHelper.ExecuteDt(sql);
            cbo_QuocGia.DataSource = dt;
            cbo_QuocGia.DisplayMember = "TenDiaChi";
            cbo_QuocGia.ValueMember = "Id";
        }
        private void btn_close_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btn_save_add_Click(object sender, EventArgs e)
        {
            SetValues();
            if (edit == true)
            {
                UpdateData();
            }
            else
            {
                InsertData();
            }
            personnel.LoadNhanVienTieuSu();
            LoadNull();
        }
        private void InsertData()
        {
            try
            {
                string sql = string.Empty;
                sql = $@"Insert into tbl_NhanVienTieuSu(MaNhanVien, TuNam, DenNam, CongViec, Id_QuocGia, NgayTao, NguoiTao, del_flg)
                    Values({SQLHelper.rpStr(_MaNhanVien)}, {SQLHelper.rpStr(_TuNam)}, {SQLHelper.rpStr(_DenNam)},
                    {SQLHelper.rpStr(_CongViec)}, {SQLHelper.rpI(quocgia_value)}, '{DateTime.Now}', {SQLHelper.rpStr(_NguoiTao)}, 0)";

                if (SQLHelper.ExecuteSql(sql) > 0)
                {
                    RJMessageBox.Show("Thêm thông tin thành công", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    RJMessageBox.Show("Thêm thông tin thất bại", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
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
                sql = $@"Update tbl_NhanVienTieuSu set TuNam = {SQLHelper.rpStr(_TuNam)}, 
                        DenNam = {SQLHelper.rpStr(_DenNam)}, CongViec = {SQLHelper.rpStr(_CongViec)},
                        Id_QuocGia = {SQLHelper.rpI(quocgia_value)}, NgayCapNhat = '{DateTime.Now}', 
                        NguoiCapNhat = {SQLHelper.rpStr(_NguoiCapNhat)}
                        Where Id = '{_IdTieuSu}'";
                if (SQLHelper.ExecuteSql(sql) > 0)
                {
                    RJMessageBox.Show("Cập nhật thông tin thành công", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    RJMessageBox.Show("Cập nhật thông tin thất bại", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
            }
            catch (Exception ex)
            {
                RJMessageBox.Show(ex.Message, "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void SetValues()
        {
            _TuNam = cbo_TuNam.Text;
            _DenNam = cbo_DenNam.Text;
            _CongViec = txt_cong_viec.Text;
            quocgia_value = Convert.ToInt32(cbo_QuocGia.SelectedValue);
            _NguoiTao = SQLHelper.sUser;
            _NguoiCapNhat = SQLHelper.sUser;
        }
    }
}