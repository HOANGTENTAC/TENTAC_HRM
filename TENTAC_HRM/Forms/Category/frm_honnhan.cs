using System;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Windows.Forms;
using TENTAC_HRM.Custom;

namespace TENTAC_HRM.Forms.Category
{
    public partial class frm_honnhan : Form
    {
        Byte[] b = null;
        OpenFileDialog open = new OpenFileDialog();
        DataProvider provider = new DataProvider();
        byte[] pic_mattruoc;
        byte[] pic_matsau;
        string sogiaychungnhan_value, ngaydangky_value, noidangky_value, nguoitao_value;
        public bool edit { get; set; }
        public string _ma_nhan_vien { get; set; }
        public frm_honnhan()
        {
            InitializeComponent();
        }

        private void frm_honnhan_Load(object sender, EventArgs e)
        {
            load_data();
            load_nhanvien();
        }
        private void load_nhanvien()
        {
            cbo_nhanvien.DataSource = provider.load_nhanvien();
            cbo_nhanvien.DisplayMember = "name";
            cbo_nhanvien.ValueMember = "value";
            cbo_nhanvien.SelectedValue = _ma_nhan_vien;
        }
        private void load_data()
        {
            string sql = string.Format("select * from nhanvien_honnhan where ma_nhan_vien = '{0}' and del_flg = 0 ", _ma_nhan_vien);
            DataTable dt = new DataTable();
            dt = SQLHelper.ExecuteDt(sql);
            if (dt.Rows.Count > 0)
            {
                edit = true;
                btn_luu.Text = "Cập nhật";
                btn_delete.Visible = true;
                txt_sogiay_chungnhan.Text = dt.Rows[0]["so_giay_chung_nhan"].ToString();
                dtp_ngaydk.Text = dt.Rows[0]["ngay_dang_ky"].ToString();
                txt_noidk.Text = dt.Rows[0]["noi_dang_ky"].ToString();
                if (!string.IsNullOrEmpty(dt.Rows[0]["mat_truoc"].ToString()))
                {
                    Byte[] byteanh_nv = new Byte[0];
                    byteanh_nv = (Byte[])(dt.Rows[0]["mat_truoc"]);
                    MemoryStream stmBLOBData = new MemoryStream(byteanh_nv);
                    pb_mattruoc.Image = Image.FromStream(stmBLOBData);
                }
                if (!string.IsNullOrEmpty(dt.Rows[0]["mat_sau"].ToString()))
                {
                    Byte[] byteanh_nv = new Byte[0];
                    byteanh_nv = (Byte[])(dt.Rows[0]["mat_sau"]);
                    MemoryStream stmBLOBData = new MemoryStream(byteanh_nv);
                    pb_matsau.Image = Image.FromStream(stmBLOBData);
                }
            }
            else
            {
                edit = false;
                btn_luu.Text = "Lưu";
                btn_delete.Visible = false;
            }
        }

        private void btn_close_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btn_luu_Click(object sender, EventArgs e)
        {
            set_value_text();
            if (edit == true)
            {
                Update_data();
            }
            else
            {
                save_data();
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
                pb_mattruoc.Image = Image.FromFile(open.FileName);
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
                pb_matsau.Image = Image.FromFile(open.FileName);
            }
        }

        private void btn_delete_Click(object sender, EventArgs e)
        {
            try
            {
                DialogResult result = RJMessageBox.Show("Bạn có chác muốn xóa?", "Thông báo", MessageBoxButtons.YesNo);
                if (result == DialogResult.Yes)
                {
                    string sql = string.Format("update nhanvien_honnhan set del_flg = 1 where ma_nhan_vien = '{0}'", _ma_nhan_vien);
                    if (SQLHelper.ExecuteSql(sql) == 1)
                    {
                        RJMessageBox.Show("Xóa thành công", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
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
            pb_mattruoc.Image = null;
        }

        private void btn_delete_pt2_Click(object sender, EventArgs e)
        {
            pb_matsau.Image = null;
        }

        private void frm_honnhan_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
            {
                this.Close();
            }
        }

        private void Update_data()
        {
            try
            {
                string sql = "update nhanvien_honnhan set so_giay_chung_nhan = @sogiaychungnhan," +
                        "ngay_dang_ky = @ngaydangky,noi_dang_ky = @noidangky,mat_truoc = @mattruoc,mat_sau = @matsau,ngay_cap_nhat = GETDATE() " +
                        "where ma_nhan_vien = @ma_nhan_vien";
                SqlParameter[] param = new SqlParameter[]
                {
                new SqlParameter("@ma_nhan_vien", SqlDbType.Int) {Value = _ma_nhan_vien},
                new SqlParameter("@sogiaychungnhan", SqlDbType.VarChar) {Value = sogiaychungnhan_value},
                new SqlParameter("@ngaydangky", SqlDbType.Date) {Value = ngaydangky_value},
                new SqlParameter("@noidangky", SqlDbType.NVarChar) {Value = noidangky_value},
                new SqlParameter("@mattruoc", SqlDbType.Image) {Value = (pic_mattruoc == null ? (object)DBNull.Value : pic_mattruoc)},
                new SqlParameter("@matsau", SqlDbType.Image) {Value = (pic_matsau == null ? (object)DBNull.Value : pic_matsau)},
                };
                if (SQLHelper.ExecuteSql(sql, param) == 1)
                {
                    RJMessageBox.Show("Cập nhật thành công", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }

            }
            catch (Exception ex)
            {
                RJMessageBox.Show(ex.Message, "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }

        private void save_data()
        {
            try
            {
                string sql = "insert into nhanvien_honnhan(ma_nhan_vien,so_giay_chung_nhan,ngay_dang_ky,noi_dang_ky,mat_truoc,mat_sau,ngay_tao,id_nguoi_tao) " +
                    "values(@nhanvien,@sogiaychungnhan,@ngaydangky,@noidangky,@mattruoc,@matsau,GETDATE(),@nguoitao)";
                SqlParameter[] param = new SqlParameter[]
                {
                    new SqlParameter("@nhanvien", SqlDbType.Int) {Value = _ma_nhan_vien},
                    new SqlParameter("@sogiaychungnhan", SqlDbType.VarChar) {Value = sogiaychungnhan_value},
                    new SqlParameter("@ngaydangky", SqlDbType.Date) {Value = ngaydangky_value},
                    new SqlParameter("@noidangky", SqlDbType.NVarChar) {Value = noidangky_value},
                    new SqlParameter("@mattruoc", SqlDbType.Image) {Value = (pic_mattruoc == null ? (object)DBNull.Value : pic_mattruoc)},
                    new SqlParameter("@matsau", SqlDbType.Image) {Value = (pic_matsau == null ? (object)DBNull.Value : pic_matsau)},
                    new SqlParameter("@nguoitao", SqlDbType.VarChar) {Value = nguoitao_value},
                };
                if (SQLHelper.ExecuteSql(sql, param) == 1)
                {
                    RJMessageBox.Show("Cập nhật thành công", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }

            }
            catch (Exception ex)
            {
                RJMessageBox.Show(ex.Message, "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void set_value_text()
        {
            pic_mattruoc = null;
            if (pb_mattruoc.Image != null)
            {
                MemoryStream ms;
                ms = new MemoryStream();
                pb_mattruoc.Image.Save(ms, ImageFormat.Png);
                pic_mattruoc = new byte[ms.Length];
                ms.Position = 0;
                ms.Read(pic_mattruoc, 0, pic_mattruoc.Length);
            }
            pic_matsau = null;
            if (pb_matsau.Image != null)
            {
                MemoryStream ms;
                ms = new MemoryStream();
                pb_matsau.Image.Save(ms, ImageFormat.Png);
                pic_matsau = new byte[ms.Length];
                ms.Position = 0;
                ms.Read(pic_matsau, 0, pic_matsau.Length);
            }

            sogiaychungnhan_value = txt_sogiay_chungnhan.Text;
            ngaydangky_value = dtp_ngaydk.Value.ToString("yyyy/MM/dd");
            noidangky_value = txt_noidk.Text.ToString();
            nguoitao_value = SQLHelper.sIdUser;

        }
    }
}
