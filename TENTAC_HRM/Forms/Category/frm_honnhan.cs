using ComponentFactory.Krypton.Toolkit;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.IO;
using System.Windows.Forms;
using TENTAC_HRM.Consts;
using TENTAC_HRM.Custom;
using DataTable = System.Data.DataTable;

namespace TENTAC_HRM.Forms.Category
{
    public partial class frm_honnhan : KryptonForm
    {
        Byte[] b = null;
        OpenFileDialog open = new OpenFileDialog();
        DataProvider provider = new DataProvider();
        byte[] pic_mattruoc;
        byte[] pic_matsau;
        string _SoGiayChungNhan, _NoiDangKy, _NguoiTao, _NguoiCapNhat;
        DateTime? _NgayDangKy;
        public bool edit { get; set; }
        public string _MaNhanVien { get; set; }
        public frm_honnhan()
        {
            InitializeComponent();
        }
        private void frm_honnhan_Load(object sender, EventArgs e)
        {
            LoadComboboxNhanVien();
            if(edit == true)
            {
                LoadData();
            }
        }
        private void LoadComboboxNhanVien()
        {
            cbo_NhanVien.DataSource = provider.load_nhanvien();
            cbo_NhanVien.DisplayMember = "name";
            cbo_NhanVien.ValueMember = "value";
            cbo_NhanVien.SelectedValue = _MaNhanVien;
        }
        private void LoadData()
        {
            string sql = string.Format("select * from tbl_NhanVienHonNhan where MaNhanVien = '{0}' and del_flg = 0 ", _MaNhanVien);
            DataTable dt = new DataTable();
            dt = SQLHelper.ExecuteDt(sql);
            if (dt.Rows.Count > 0)
            {
                edit = true;
                btn_delete.Visible = true;
                txt_SoGiayChungNhan.Text = dt.Rows[0]["SoGiayChungNhan"].ToString();
                dtp_NgayDK.Text = dt.Rows[0]["NgayDangKy"].ToString();
                txt_NoiDK.Text = dt.Rows[0]["NoiDangKy"].ToString();
                if (!string.IsNullOrEmpty(dt.Rows[0]["MatTruoc"].ToString()))
                {
                    Byte[] byteanh_nv = new Byte[0];
                    byteanh_nv = (Byte[])(dt.Rows[0]["MatTruoc"]);
                    MemoryStream stmBLOBData = new MemoryStream(byteanh_nv);
                    pb_MatTruoc.Image = Image.FromStream(stmBLOBData);
                }
                if (!string.IsNullOrEmpty(dt.Rows[0]["MatSau"].ToString()))
                {
                    Byte[] byteanh_nv = new Byte[0];
                    byteanh_nv = (Byte[])(dt.Rows[0]["MatSau"]);
                    MemoryStream stmBLOBData = new MemoryStream(byteanh_nv);
                    pb_MatSau.Image = Image.FromStream(stmBLOBData);
                }
            }
            else
            {
                edit = false;
                btn_delete.Visible = false;
            }
        }
        private void LoadNull()
        {
            txt_NoiDK.Text = string.Empty;
            txt_SoGiayChungNhan.Text = string.Empty;
            dtp_NgayDK.Text = string.Empty;
            pb_MatSau.Image = null;
            pb_MatTruoc.Image = null;
        }
        private void btn_close_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        private void btn_luu_Click(object sender, EventArgs e)
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
        }
        private void pb_mattruoc_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            //OpenFileDialog open = new OpenFileDialog();
            open.Filter = "Image Files(*.jpg; *.jpeg; *.gif; *.bmp; *.png)|*.jpg; *.jpeg; *.gif; *.bmp; *.png" +
                        "|All Files (*.*)|*.*";
            if (open.ShowDialog() == DialogResult.OK)
            {
                FileStream Fs = default(FileStream);
                Fs = File.Open(open.FileName, FileMode.OpenOrCreate);
                b = new Byte[Fs.Length];
                Fs.Read(b, 0, b.Length);
                Fs.Close();
                pb_MatTruoc.Image = Image.FromFile(open.FileName);
            }
        }
        private void pb_matsau_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            //OpenFileDialog open = new OpenFileDialog();
            open.Filter = "Image Files(*.jpg; *.jpeg; *.gif; *.bmp; *.png)|*.jpg; *.jpeg; *.gif; *.bmp; *.png" +
                        "|All Files (*.*)|*.*";
            if (open.ShowDialog() == DialogResult.OK)
            {
                FileStream Fs = default(FileStream);
                Fs = File.Open(open.FileName, FileMode.OpenOrCreate);
                b = new Byte[Fs.Length];
                Fs.Read(b, 0, b.Length);
                Fs.Close();
                pb_MatSau.Image = Image.FromFile(open.FileName);
            }
        }
        private void btn_delete_Click(object sender, EventArgs e)
        {
            try
            {
                DialogResult result = RJMessageBox.Show("Bạn có chác muốn xóa?", "Thông báo", MessageBoxButtons.YesNo);
                if (result == DialogResult.Yes)
                {
                    string sql = string.Format("update tbl_NhanVienHonNhan set del_flg = 1 where MaNhanVien = '{0}'", _MaNhanVien);
                    if (SQLHelper.ExecuteSql(sql) == 1)
                    {
                        RJMessageBox.Show("Xóa thành công", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        LoadNull();
                    }
                }
            }
            catch (Exception ex)
            {
                RJMessageBox.Show(ex.Message, "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void btn_delete_pt1_Click(object sender, EventArgs e)
        {
            pb_MatTruoc.Image = null;
        }
        private void btn_delete_pt2_Click(object sender, EventArgs e)
        {
            pb_MatSau.Image = null;
        }
        private void frm_honnhan_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
            {
                this.Close();
            }
        }
        private void btn_update_pt1_Click(object sender, EventArgs e)
        {
            open.Filter = "Image Files(*.jpg; *.jpeg; *.gif; *.bmp; *.png)|*.jpg; *.jpeg; *.gif; *.bmp; *.png" +
                        "|All Files (*.*)|*.*";
            if (open.ShowDialog() == DialogResult.OK)
            {
                FileStream Fs = default(FileStream);
                Fs = File.Open(open.FileName, FileMode.OpenOrCreate);
                b = new Byte[Fs.Length];
                Fs.Read(b, 0, b.Length);
                Fs.Close();
                pb_MatTruoc.Image = Image.FromFile(open.FileName);
            }
        }
        private void btn_update_pt2_Click(object sender, EventArgs e)
        {
            open.Filter = "Image Files(*.jpg; *.jpeg; *.gif; *.bmp; *.png)|*.jpg; *.jpeg; *.gif; *.bmp; *.png" +
                        "|All Files (*.*)|*.*";
            if (open.ShowDialog() == DialogResult.OK)
            {
                FileStream Fs = default(FileStream);
                Fs = File.Open(open.FileName, FileMode.OpenOrCreate);
                b = new Byte[Fs.Length];
                Fs.Read(b, 0, b.Length);
                Fs.Close();
                pb_MatSau.Image = Image.FromFile(open.FileName);
            }
        }
        private void UpdateData()
        {
            try
            {
                string sql = string.Empty;
                sql = $@"Update tbl_NhanVienHonNhan 
                        Set SoGiayChungNhan = @SoGiayChungNhan, NgayDangKy = @NgayDangKy, NoiDangKy = @NoiDangKy, MatTruoc = @MatTruoc,
                        MatSau = @MatSau, NgayCapNhat = @NgayCapNhat, NguoiCapNhat = @NguoiCapNhat
                    Where MaNhanVien = @MaNhanVien and del_flg = @DelFlg";
                var parameters = new List<SqlParameter>
                    {
                        new SqlParameter("@MaNhanVien", _MaNhanVien),
                        new SqlParameter("@SoGiayChungNhan", _SoGiayChungNhan ?? (object)DBNull.Value),
                        new SqlParameter("@NgayDangKy", _NgayDangKy ?? (object)DBNull.Value),
                        new SqlParameter("@NoiDangKy", _NoiDangKy ?? (object)DBNull.Value),
                        new SqlParameter("@MatTruoc", SqlDbType.Image){Value = (object)(SQLHelper.ConvertImageToByteArray(pb_MatTruoc.Image) ?? (object)DBNull.Value)},
                        new SqlParameter("@MatSau", SqlDbType.Image){Value = (object)(SQLHelper.ConvertImageToByteArray(pb_MatSau.Image) ?? (object)DBNull.Value)},
                        new SqlParameter("@NgayCapNhat", DateTime.Now),
                        new SqlParameter("@NguoiCapNhat", _NguoiCapNhat ?? (object)DBNull.Value),
                        new SqlParameter("@DelFlg", SqlDbType.Int) { Value = 0 }
                    };
                int res = SQLHelper.ExecuteSql(sql, parameters.ToArray());
                if (res > 0)
                {
                    RJMessageBox.Show("Cập nhật thông tin thành công", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    RJMessageBox.Show("Cập nhật thông tin thất bại", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }
            }
            catch (Exception ex)
            {
                RJMessageBox.Show(ex.Message, "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void InsertData()
        {
            try
            {
                string sql = @"INSERT INTO tbl_NhanVienHonNhan (MaNhanVien, SoGiayChungNhan, NgayDangKy, NoiDangKy, MatTruoc, MatSau, NgayTao, NguoiTao, del_flg)
                VALUES (@MaNhanVien, @SoGiayChungNhan, @NgayDangKy, @NoiDangKy, @MatTruoc, @MatSau, @NgayTao, @NguoiTao, @DelFlg)";
                var parameters = new List<SqlParameter>
                    {
                        new SqlParameter("@MaNhanVien", _MaNhanVien),
                        new SqlParameter("@SoGiayChungNhan", _SoGiayChungNhan ?? (object)DBNull.Value),
                        new SqlParameter("@NgayDangKy", _NgayDangKy ?? (object)DBNull.Value),
                        new SqlParameter("@NoiDangKy", _NoiDangKy ?? (object)DBNull.Value),
                        new SqlParameter("@MatTruoc", SqlDbType.Image){Value = (object)(SQLHelper.ConvertImageToByteArray(pb_MatTruoc.Image) ?? (object)DBNull.Value)},
                        new SqlParameter("@MatSau", SqlDbType.Image){Value = (object)(SQLHelper.ConvertImageToByteArray(pb_MatSau.Image) ?? (object)DBNull.Value)},
                        new SqlParameter("@NgayTao", DateTime.Now),
                        new SqlParameter("@NguoiTao", _NguoiTao ?? (object)DBNull.Value),
                        new SqlParameter("@DelFlg", SqlDbType.Int) { Value = 0 }
                    };
                int res = SQLHelper.ExecuteSql(sql, parameters.ToArray());
                if (res > 0)
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
        private void SetValues()
        {
            _SoGiayChungNhan = txt_SoGiayChungNhan.Text.Trim();
            _NgayDangKy = string.IsNullOrEmpty(dtp_NgayDK.Text) ? (DateTime?)null : Convert.ToDateTime(dtp_NgayDK.Text);
            _NoiDangKy = txt_NoiDK.Text.Trim();
            _NguoiTao = LoginInfo.UserCd;
            _NguoiCapNhat = LoginInfo.UserCd;

            //pic_mattruoc = null;
            //if (pb_MatTruoc.Image != null)
            //{
            //    MemoryStream ms;
            //    ms = new MemoryStream();
            //    pb_MatTruoc.Image.Save(ms, ImageFormat.Png);
            //    pic_mattruoc = new byte[ms.Length];
            //    ms.Position = 0;
            //    ms.Read(pic_mattruoc, 0, pic_mattruoc.Length);
            //}
            //pic_matsau = null;
            //if (pb_MatSau.Image != null)
            //{
            //    MemoryStream ms;
            //    ms = new MemoryStream();
            //    pb_MatSau.Image.Save(ms, ImageFormat.Png);
            //    pic_matsau = new byte[ms.Length];
            //    ms.Position = 0;
            //    ms.Read(pic_matsau, 0, pic_matsau.Length);
            //}
        }
    }
}