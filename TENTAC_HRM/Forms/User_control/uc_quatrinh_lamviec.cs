using System;
using System.Data;
using System.Drawing;
using System.IO;
using System.Windows.Forms;
using TENTAC_HRM.Forms.Category;
using TENTAC_HRM.Custom;

namespace TENTAC_HRM.Forms.User_control
{
    public partial class uc_quatrinh_lamviec : UserControl
    {
        DataProvider provider = new DataProvider();
        public string _ma_nhan_vien;
        public static uc_quatrinh_lamviec _instance;
        public static uc_quatrinh_lamviec Instance
        {
            get
            {
                _instance = new uc_quatrinh_lamviec();
                return _instance;
            }
        }
        ToolStripControlHost dtp_den_ngay = new ToolStripControlHost(new DateTimePicker());
        ToolStripControlHost dtp_tu_ngay = new ToolStripControlHost(new DateTimePicker());
        ToolStripControlHost denngay = new ToolStripControlHost(new Label());
        ToolStripControlHost tungay = new ToolStripControlHost(new Label());
        public uc_quatrinh_lamviec()
        {
            InitializeComponent();
            // add item to toolstrip
            ((DateTimePicker)dtp_tu_ngay.Control).CustomFormat = "yyyy/MM/dd";
            ((DateTimePicker)dtp_tu_ngay.Control).Format = DateTimePickerFormat.Custom;
            ((DateTimePicker)dtp_den_ngay.Control).CustomFormat = "yyyy/MM/dd";
            ((DateTimePicker)dtp_den_ngay.Control).Format = DateTimePickerFormat.Custom;
            ((Label)denngay.Control).TextAlign = ContentAlignment.MiddleCenter;
            ((Label)tungay.Control).TextAlign = ContentAlignment.MiddleCenter;
            tungay.Text = "Từ ngày";
            denngay.Text = "Đến ngày";
            dtp_tu_ngay.Width = 100;
            dtp_den_ngay.Width = 100;
            tungay.Visible = false;
            denngay.Visible = false;
            dtp_den_ngay.Visible = false;
            dtp_tu_ngay.Visible = false;
            toolStrip1.Items.Add(tungay);
            toolStrip1.Items.Add(dtp_tu_ngay);
            toolStrip1.Items.Add(denngay);
            toolStrip1.Items.Add(dtp_den_ngay);
            cbo_nhanvien.ComboBox.SelectionChangeCommitted += cbo_nhanvien_SelectionChangeCommitted;
            cbo_hienthi.ComboBox.SelectionChangeCommitted += cbo_hienthi_SelectionChangeCommitted;
        }
        private void cbo_hienthi_SelectionChangeCommitted(object sender, EventArgs e)
        {
            if (cbo_hienthi.ComboBox.SelectedValue.ToString() == "1")
            {
                tungay.Visible = true;
                denngay.Visible = true;
                dtp_tu_ngay.Visible = true;
                dtp_den_ngay.Visible = true;
            }
            else
            {
                tungay.Visible = false;
                denngay.Visible = false;
                dtp_tu_ngay.Visible = false;
                dtp_den_ngay.Visible = false;
            }
        }

        private void cbo_nhanvien_SelectionChangeCommitted(object sender, EventArgs e)
        {
            _ma_nhan_vien = cbo_nhanvien.ComboBox.SelectedValue.ToString();
            load_data();
        }

        private void uc_staff_allowance_Load(object sender, EventArgs e)
        {
            load_hienthi();
            load_nhanvien();
        }
        private void load_hienthi()
        {
            DataTable datatable = new DataTable();
            datatable.Columns.Add("value");
            datatable.Columns.Add("name");
            datatable.Rows.Add("0", "Tất cả");
            datatable.Rows.Add("1", "Theo thời gian");
            cbo_hienthi.ComboBox.DataSource = datatable;
            cbo_hienthi.ComboBox.DisplayMember = "name";
            cbo_hienthi.ComboBox.ValueMember = "value";
        }
        private void load_nhanvien()
        {
            cbo_nhanvien.ComboBox.DataSource = provider.load_nhanvien();
            cbo_nhanvien.ComboBox.DisplayMember = "name";
            cbo_nhanvien.ComboBox.ValueMember = "value";
        }

        private void load_data()
        {
            string sql = string.Format("select a.ma_nhan_vien,ngay_sinh,gioi_tinh,dien_thoai_dd,email,b.dia_chi_full,a.hinh_anh " +
                "from hrm_nhan_vien a left join hrm_nhanvien_diachi b on a.ma_nhan_vien = b.ma_nhan_vien where a.ma_nhan_vien = '{0}'", cbo_nhanvien.ComboBox.SelectedValue.ToString());
            DataTable dt = new DataTable();
            dt = SQLHelper.ExecuteDt(sql);
            if (dt.Rows.Count > 0)
            {
                txt_ma_nhanvien.Text = dt.Rows[0]["ma_nhan_vien"].ToString();
                txt_ngaysinh.Text = DateTime.Parse(dt.Rows[0]["ngay_sinh"].ToString()).ToString("yyyy/MM/dd");
                chk_gioitinh.Checked = dt.Rows[0]["gioi_tinh"].ToString() == "True" ? true : false;
                txt_sdt.Text = dt.Rows[0]["dien_thoai_dd"].ToString();
                txt_email.Text = dt.Rows[0]["email"].ToString();
                txt_diachi.Text = dt.Rows[0]["dia_chi_full"].ToString();
                if (!string.IsNullOrEmpty(dt.Rows[0]["hinh_anh"].ToString()))
                {
                    Byte[] byteanh_nv = new Byte[0];
                    byteanh_nv = (Byte[])(dt.Rows[0]["hinh_anh"]);
                    MemoryStream stmBLOBData = new MemoryStream(byteanh_nv);
                    pb_avata.Image = Image.FromStream(stmBLOBData);
                }
                else
                {
                    pb_avata.Image = null;
                }
            }
            Load_congtac();
            Load_khenthuong();
            Load_kyluat();
            load_tainan();
            load_thaisan();
            load_danhgia();
            load_nghiviec();
            load_daotao();
        }
        public void load_nghiviec()
        {
            string sql = string.Format("select id_qt_nghiviec,tu_ngay,den_ngay,ngay_quyet_dinh,so_quyet_dinh,noi_dung,type_name as loai_nghi_viec " +
                "from hrm_qt_nghiviec a join sys_all_type b on a.loai_nghi_viec = b.type_id where a.ma_nhan_vien = '{0}'", txt_ma_nhanvien.Text);
            dgv_qt_nghiviec.DataSource = SQLHelper.ExecuteDt(sql);
        }
        public void load_daotao()
        {
            string sql = string.Format("select id_qt_daotao,tu_ngay,den_ngay,so_quyet_dinh,noi_dung,hinh_thuc from hrm_qt_daotao where ma_nhan_vien = '{0}'", txt_ma_nhanvien.Text);
            dgv_qt_daotao.DataSource = SQLHelper.ExecuteDt(sql);
        }
        public void load_danhgia()
        {
            string sql = string.Format("select id_qt_danhgia,ngay_danh_gia,noi_dung,diem_danh_gia,xep_loai from hrm_qt_danhgia where ma_nhan_vien = '{0}'", txt_ma_nhanvien.Text);
            dgv_qt_danhgia.DataSource = SQLHelper.ExecuteDt(sql);
        }
        public void load_thaisan()
        {
            string sql = string.Format("select tu_ngay,den_ngay,ghi_chu from hrm_nhanvien_thaisan where ma_nhan_vien = '{0}'", txt_ma_nhanvien.Text);
            dgv_thaisai.DataSource = SQLHelper.ExecuteDt(sql);
        }
        public void load_tainan()
        {
            string sql = string.Format("select a.id_qt_tainan,b.type_name as ten_tai_nan,c.type_name as muc_do,ngay_dien_ra,noi_dien_ra,noi_dung " +
                "from hrm_qt_tainan a " +
                "join sys_all_type b on a.id_ten_tai_nan = b.type_id " +
                "join sys_all_type c on a.id_muc_do = c.type_id " +
                "where ma_nhan_vien = '{0}' and a.del_flg = 0", txt_ma_nhanvien.Text);
            DataTable dt = new DataTable();
            dt = SQLHelper.ExecuteDt(sql);
            dgv_tainan.DataSource = dt;
        }
        public void Load_kyluat()
        {
            string sql = string.Format("select id_qt_kyluat,ngay_ky_luat as ngay_ky_luat_kl,so_quyet_dinh as so_quyet_dinh_kl," +
                "noi_dung as noi_dung_kl,hinh_thuc as hinh_thuc_kl, so_tien as so_tien_kl,ly_do as ly_do_kl " +
                "from hrm_qt_kyluat " +
                "where ma_nhan_vien = '{0}' and del_flg = 0", txt_ma_nhanvien.Text);
            DataTable dt = new DataTable();
            dt = SQLHelper.ExecuteDt(sql);
            dgv_kyluat.DataSource = dt;
        }
        public void Load_congtac()
        {
            string sql = string.Format("select id_qt_congtac,tu_ngay,den_ngay,so_quyet_dinh," +
                "dia_diem,noi_dung from hrm_qt_congtac where ma_nhan_vien = '{0}' and del_flg = 0", _ma_nhan_vien);
            DataTable dt = new DataTable();
            dt = SQLHelper.ExecuteDt(sql);
            dgv_congtac.DataSource = dt;
        }
        public void Load_khenthuong()
        {
            string sql = string.Format("select id_qt_khenthuong,ngay_khen_thuong as ngay_khen_thuong_kt,so_quyet_dinh as so_quyet_dinh_kt," +
                "noi_dung as noi_dung_kt,hinh_thuc as hinh_thuc_kt, so_tien as so_tien_kt,ly_do as ly_do_kt " +
                "from hrm_qt_khenthuong " +
                "where ma_nhan_vien = '{0}' and del_flg = 0", txt_ma_nhanvien.Text);
            DataTable dt = new DataTable();
            dt = SQLHelper.ExecuteDt(sql);
            dgv_khenthuong.DataSource = dt;
        }

        private void btn_add_congtac_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(_ma_nhan_vien))
            {
                frm_congtac frm = new frm_congtac(null, this);
                frm._ma_nhan_vien = _ma_nhan_vien;
                frm.edit = false;
                frm.ShowDialog();
            }
        }

        private void dgv_congtac_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dgv_congtac.CurrentCell.OwningColumn.Name == "edit_column_ct")
            {
                frm_congtac frm = new frm_congtac(null, this);
                frm._id_congtac = int.Parse(dgv_congtac.CurrentRow.Cells["id_qt_congtac"].Value.ToString());
                frm._ma_nhan_vien = _ma_nhan_vien;
                frm.edit = true;
                frm.ShowDialog();
            }
        }

        private void dgv_khenthuong_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dgv_khenthuong.CurrentCell.OwningColumn.Name == "edit_column_kt")
            {
                frm_khenthuong frm = new frm_khenthuong(null, this);
                frm._id_khenthuong = int.Parse(dgv_khenthuong.CurrentRow.Cells["id_qt_khenthuong"].Value.ToString());
                frm._ma_nhan_vien = _ma_nhan_vien;
                frm.edit = true;
                frm.ShowDialog();
            }
        }

        private void btn_add_khenthuong_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(_ma_nhan_vien))
            {
                frm_khenthuong frm = new frm_khenthuong(null, this);
                frm._ma_nhan_vien = _ma_nhan_vien;
                frm.edit = false;
                frm.ShowDialog();
            }
        }

        private void dgv_kyluat_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dgv_kyluat.CurrentCell.OwningColumn.Name == "edit_column_kl")
            {
                frm_nhanvien_kyluat frm = new frm_nhanvien_kyluat(null, this);
                frm._id_qt_kyluat = int.Parse(dgv_kyluat.CurrentRow.Cells["id_qt_kyluat"].Value.ToString());
                frm._ma_nhan_vien = _ma_nhan_vien;
                frm.edit = true;
                frm.ShowDialog();
            }
        }

        private void btn_add_kl_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(_ma_nhan_vien))
            {
                frm_nhanvien_kyluat frm = new frm_nhanvien_kyluat(null, this);
                frm._ma_nhan_vien = _ma_nhan_vien;
                frm.edit = false;
                frm.ShowDialog();
            }
        }

        private void btn_add_tainan_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(_ma_nhan_vien))
            {
                frm_nhanvien_tainan frm = new frm_nhanvien_tainan(null, this);
                frm._ma_nhan_vien = _ma_nhan_vien;
                frm.edit = false;
                frm.ShowDialog();
            }
        }

        private void dgv_tainan_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dgv_tainan.CurrentCell.OwningColumn.Name == "edit_column_tn")
            {
                frm_nhanvien_tainan frm = new frm_nhanvien_tainan(null, this);
                frm._id_qt_tainan = int.Parse(dgv_tainan.CurrentRow.Cells["id_qt_tainan"].Value.ToString());
                frm._ma_nhan_vien = _ma_nhan_vien;
                frm.edit = true;
                frm.ShowDialog();
            }
        }

        private void btn_add_dg_Click(object sender, EventArgs e)
        {
            frm_danhgia frm = new frm_danhgia(null, this);
            frm._edit = false;
            frm._ma_nhan_vien = _ma_nhan_vien;
            frm.ShowDialog();
        }

        private void dgv_qt_danhgia_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dgv_qt_danhgia.CurrentCell.OwningColumn.Name == "edit_column_danhgia")
            {
                frm_danhgia frm = new frm_danhgia(null, this);
                frm._id_danh_gia = int.Parse(dgv_qt_danhgia.CurrentRow.Cells["id_qt_danhgia"].Value.ToString());
                frm._ma_nhan_vien = _ma_nhan_vien;
                frm._edit = true;
                frm.ShowDialog();
            }
        }

        private void dgv_qt_daotao_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dgv_qt_daotao.CurrentCell.OwningColumn.Name == "edit_column_daotao")
            {
                frm_daotao frm = new frm_daotao(null, this);
                frm._edit = true;
                frm._id_dao_tao = int.Parse(dgv_qt_daotao.CurrentRow.Cells["id_qt_daotao"].Value.ToString());
                frm.ShowDialog();
            }
        }

        private void btn_add_dt_Click(object sender, EventArgs e)
        {
            frm_daotao frm = new frm_daotao(null, this);
            frm._edit = false;
            frm._ma_nhan_vien = _ma_nhan_vien;
            frm.ShowDialog();
        }

        private void btn_add_nv_Click(object sender, EventArgs e)
        {
            frm_nghiviec frm = new frm_nghiviec(null, this);
            frm._ma_nhan_vien = _ma_nhan_vien;
            frm._edit = false;
            frm.ShowDialog();
        }

        private void dgv_qt_nghiviec_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dgv_qt_nghiviec.CurrentCell.OwningColumn.Name == "edit_column_nghiviec")
            {
                frm_nghiviec frm = new frm_nghiviec(null, this);
                frm._edit = true;
                frm._id_nghi_viec = int.Parse(dgv_qt_nghiviec.CurrentRow.Cells["id_qt_nghiviec"].Value.ToString());
                frm.ShowDialog();
            }
        }

        private void dgv_thaisai_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dgv_thaisai.CurrentCell.OwningColumn.Name == "edit_column_ts")
            {
                frm_thaisan frm = new frm_thaisan(null, this);
                frm._ma_nhan_vien = _ma_nhan_vien;
                frm._id_thai_san = int.Parse(dgv_thaisai.CurrentRow.Cells["id_thai_san"].Value.ToString());
                frm.edit = true;
                frm.ShowDialog();
            }
        }

        private void btn_add_ts_Click(object sender, EventArgs e)
        {
            frm_thaisan frm = new frm_thaisan(null, this);
            frm._ma_nhan_vien = _ma_nhan_vien;
            frm.edit = false;
            frm.ShowDialog();
        }

        private void btn_refresh_ct_Click(object sender, EventArgs e)
        {
            Load_congtac();
        }

        private void btn_refresh_kt_Click(object sender, EventArgs e)
        {
            Load_khenthuong();
        }

        private void btn_refresh_kl_Click(object sender, EventArgs e)
        {
            Load_kyluat();
        }

        private void btn_refresh_dg_Click(object sender, EventArgs e)
        {
            load_danhgia();
        }

        private void btn_refresh_dt_Click(object sender, EventArgs e)
        {
            load_daotao();
        }

        private void btn_refresh_tn_Click(object sender, EventArgs e)
        {
            load_tainan();
        }

        private void btn_refresh_nv_Click(object sender, EventArgs e)
        {
            load_nghiviec();
        }

        private void btn_refresh_ts_Click(object sender, EventArgs e)
        {
            load_thaisan();
        }

        private void btn_delete_ct_Click(object sender, EventArgs e)
        {
            if (dgv_congtac.Rows.Count > 0)
            {
                DialogResult dialogResult = RJMessageBox.Show("Bạn có chắc muốn xóa dữ liệu này", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (dialogResult == DialogResult.Yes)
                {
                    delete_value("hrm_qt_congtac", "id_qt_congtac", dgv_congtac.CurrentRow.Cells["id_qt_congtac"].Value.ToString());
                    Load_congtac();
                }
            }
        }

        private void dgv_congtac_RowPostPaint(object sender, DataGridViewRowPostPaintEventArgs e)
        {
            RowNumber_DGV(sender, e);
        }
        private void RowNumber_DGV(object sender, DataGridViewRowPostPaintEventArgs e)
        {
            var grid = sender as DataGridView;
            var rowIdx = (e.RowIndex + 1).ToString();
            var centerFormat = new StringFormat
            {
                Alignment = StringAlignment.Center,
                LineAlignment = StringAlignment.Center
            };
            var textSize = TextRenderer.MeasureText(rowIdx, Font);
            if (grid.RowHeadersWidth < textSize.Width + 40) grid.RowHeadersWidth = textSize.Width + 40;
            var headerBounds =
                new Rectangle(e.RowBounds.Left, e.RowBounds.Top, grid.RowHeadersWidth, e.RowBounds.Height);
            e.Graphics.DrawString(rowIdx, Font, SystemBrushes.ControlText, headerBounds, centerFormat);
        }

        private void btn_delete_kt_Click(object sender, EventArgs e)
        {
            if (dgv_khenthuong.Rows.Count > 0)
            {
                DialogResult dialogResult = RJMessageBox.Show("Bạn có chắc muốn xóa dữ liệu này", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (dialogResult == DialogResult.Yes)
                {
                    delete_value("hrm_qt_khenthuong", "id_qt_khenthuong", dgv_khenthuong.CurrentRow.Cells["id_qt_khenthuong"].Value.ToString());
                    Load_khenthuong();
                }
            }
        }

        private void dgv_khenthuong_RowPostPaint(object sender, DataGridViewRowPostPaintEventArgs e)
        {
            RowNumber_DGV(sender, e);
        }

        private void btn_delete_kl_Click(object sender, EventArgs e)
        {
            if (dgv_kyluat.Rows.Count > 0)
            {
                DialogResult dialogResult = RJMessageBox.Show("Bạn có chắc muốn xóa dữ liệu này", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (dialogResult == DialogResult.Yes)
                {
                    delete_value("hrm_qt_kyluat", "id_qt_khenthuong", dgv_kyluat.CurrentRow.Cells["id_qt_kyluat"].Value.ToString());
                    Load_kyluat();
                }
            }
        }

        private void dgv_kyluat_RowPostPaint(object sender, DataGridViewRowPostPaintEventArgs e)
        {
            RowNumber_DGV(sender, e);
        }

        private void btn_delete_dg_Click(object sender, EventArgs e)
        {
            if (dgv_qt_danhgia.Rows.Count > 0)
            {
                DialogResult dialogResult = RJMessageBox.Show("Bạn có chắc muốn xóa dữ liệu này", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (dialogResult == DialogResult.Yes)
                {
                    delete_value("hrm_qt_danhgia", "id_qt_danhgia", dgv_qt_danhgia.CurrentRow.Cells["id_qt_danhgia"].Value.ToString());
                    load_danhgia();
                }
            }
        }

        private void dgv_qt_danhgia_RowPostPaint(object sender, DataGridViewRowPostPaintEventArgs e)
        {
            RowNumber_DGV(sender, e);
        }

        private void btn_delete_dt_Click(object sender, EventArgs e)
        {
            if (dgv_qt_daotao.Rows.Count > 0)
            {
                DialogResult dialogResult = RJMessageBox.Show("Bạn có chắc muốn xóa dữ liệu này", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (dialogResult == DialogResult.Yes)
                {
                    delete_value("hrm_qt_daotao", "id_qt_daotao", dgv_qt_daotao.CurrentRow.Cells["id_qt_daotao"].Value.ToString());
                    load_daotao();
                }
            }
        }

        private void dgv_qt_daotao_RowPostPaint(object sender, DataGridViewRowPostPaintEventArgs e)
        {
            RowNumber_DGV(sender, e);
        }

        private void btn_delete_tn_Click(object sender, EventArgs e)
        {
            if (dgv_tainan.Rows.Count > 0)
            {
                DialogResult dialogResult = RJMessageBox.Show("Bạn có chắc muốn xóa dữ liệu này", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (dialogResult == DialogResult.Yes)
                {
                    delete_value("hrm_qt_tainan", "id_qt_tainan", dgv_tainan.CurrentRow.Cells["id_qt_tainan"].Value.ToString());
                    load_tainan();
                }
            }
        }

        private void dgv_tainan_RowPostPaint(object sender, DataGridViewRowPostPaintEventArgs e)
        {
            RowNumber_DGV(sender, e);
        }

        private void btn_delete_nv_Click(object sender, EventArgs e)
        {
            if (dgv_qt_nghiviec.Rows.Count > 0)
            {
                DialogResult dialogResult = RJMessageBox.Show("Bạn có chắc muốn xóa dữ liệu này", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (dialogResult == DialogResult.Yes)
                {
                    delete_value("hrm_qt_nghiviec", "id_qt_nghiviec", dgv_qt_nghiviec.CurrentRow.Cells["id_qt_nghiviec"].Value.ToString());
                    load_nghiviec();
                }
            }
        }

        private void dgv_qt_nghiviec_RowPostPaint(object sender, DataGridViewRowPostPaintEventArgs e)
        {
            RowNumber_DGV(sender, e);
        }

        private void btn_delete_ts_Click(object sender, EventArgs e)
        {
            if (dgv_thaisai.Rows.Count > 0)
            {
                DialogResult dialogResult = RJMessageBox.Show("Bạn có chắc muốn xóa dữ liệu này", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (dialogResult == DialogResult.Yes)
                {
                    delete_value("hrm_nhanvien_thaisan", "id_thai_san", dgv_thaisai.CurrentRow.Cells["id_thai_san"].Value.ToString());
                    load_thaisan();
                }
            }
        }
        private void delete_value(string table, string column, string value)
        {
            try
            {
                string sql = string.Format("update " + table + " set del_flg = 1 where " + column + " = '{0}'", value);
                if (SQLHelper.ExecuteSql(sql) == 1)
                {
                    RJMessageBox.Show("Xóa thành công", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (Exception ex)
            {
                RJMessageBox.Show(ex.Message, "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void dgv_thaisai_RowPostPaint(object sender, DataGridViewRowPostPaintEventArgs e)
        {
            RowNumber_DGV(sender, e);
        }
    }
}
