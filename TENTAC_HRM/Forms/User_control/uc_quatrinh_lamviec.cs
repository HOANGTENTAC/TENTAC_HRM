using Microsoft.Office.Interop.Excel;
using Microsoft.Win32;
using NPOI.SS.UserModel;
using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.IO;
using System.Runtime.InteropServices;
using System.Windows.Forms;
using TENTAC_HRM.Consts;
using TENTAC_HRM.Custom;
using TENTAC_HRM.Forms.Category;
using Application = Microsoft.Office.Interop.Excel.Application;
using DataTable = System.Data.DataTable;
using Label = System.Windows.Forms.Label;

namespace TENTAC_HRM.Forms.User_control
{
    public partial class uc_quatrinh_lamviec : UserControl
    {
        DataProvider provider = new DataProvider();
        public string maNhanVien;
        public static uc_quatrinh_lamviec _instance;
        public static uc_quatrinh_lamviec Instance(int[] idPermision)
        {
            if (_instance == null)
            {
                _instance = new uc_quatrinh_lamviec(idPermision);
            }
            return _instance;
        }
        ToolStripControlHost dtp_den_ngay = new ToolStripControlHost(new DateTimePicker());
        ToolStripControlHost dtp_tu_ngay = new ToolStripControlHost(new DateTimePicker());
        ToolStripControlHost denngay = new ToolStripControlHost(new Label());
        ToolStripControlHost tungay = new ToolStripControlHost(new Label());
        public uc_quatrinh_lamviec(int[] idPermision)
        {
            InitializeComponent();
            // add item to toolstrip
            ((DateTimePicker)dtp_tu_ngay.Control).CustomFormat = "yyyy/MM/dd";
            ((DateTimePicker)dtp_tu_ngay.Control).Format = DateTimePickerFormat.Custom;
            ((DateTimePicker)dtp_tu_ngay.Control).MaximumSize = new Size(100, 23);
            ((DateTimePicker)dtp_tu_ngay.Control).Width = 100;
            ((DateTimePicker)dtp_den_ngay.Control).CustomFormat = "yyyy/MM/dd";
            ((DateTimePicker)dtp_den_ngay.Control).Format = DateTimePickerFormat.Custom;
            ((DateTimePicker)dtp_den_ngay.Control).MaximumSize = new Size(100, 23);
            ((DateTimePicker)dtp_den_ngay.Control).Width = 100;
            ((Label)denngay.Control).TextAlign = ContentAlignment.MiddleCenter;
            ((Label)tungay.Control).TextAlign = ContentAlignment.MiddleCenter;
            tungay.Text = "Từ ngày";
            denngay.Text = "Đến ngày";
            tungay.Visible = false;
            denngay.Visible = false;
            dtp_den_ngay.Visible = false;
            dtp_tu_ngay.Visible = false;
            toolStrip1.Items.Add(tungay);
            toolStrip1.Items.Add(dtp_tu_ngay);
            toolStrip1.Items.Add(denngay);
            toolStrip1.Items.Add(dtp_den_ngay);
            cbo_PhongBan.ComboBox.SelectionChangeCommitted += cbo_PhongBan_SelectionChangeCommitted;
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

        private void cbo_PhongBan_SelectionChangeCommitted(object sender, EventArgs e)
        {
            LoadNhanVien();
        }

        private void LoadNhanVien()
        {
            string where = "";
            if (LoginInfo.Group != "ADMIN" && LoginInfo.Group != "HR")
            {
                where += $" and (nhanvienmoi.ReportTo = '{LoginInfo.UserCd}' or nhanvien.MaNhanVien = '{LoginInfo.UserCd}') ";
            }
            if (cbo_PhongBan.ComboBox.SelectedValue.ToString() != "0")
            {
                where += $" and nhanvien.MaPhongBan = '{cbo_PhongBan.ComboBox.SelectedValue.ToString()}'";
            }
            string sql = $@"select nhanvien.MaNhanVien,nhanvien.TenNhanVien 
                from MITACOSQL.dbo.NHANVIEN nhanvien 
                left join tbl_NhanVien nhanvienmoi on nhanvien.MaNhanVien = nhanvienmoi.MaNhanVien 
                where nhanvien.MaCongTy is not null " + where;
            dgv_NhanVien.DataSource = SQLHelper.ExecuteDt(sql);
        }

        private void uc_staff_allowance_Load(object sender, EventArgs e)
        {
            LoadComboboxHienThi();
            LoadComboboxPhongBan();
            LoadComboboxPrinters();
            LoadNhanVien();
        }
        private void LoadComboboxHienThi()
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
        private void LoadComboboxPhongBan()
        {
            DataTable dt = provider.LoadPhongBan();
            DataRow dr = dt.NewRow();
            dr["id"] = "0";
            dr["name"] = "";
            dt.Rows.InsertAt(dr, 0);
            cbo_PhongBan.ComboBox.DataSource = dt;
            cbo_PhongBan.ComboBox.DisplayMember = "name";
            cbo_PhongBan.ComboBox.ValueMember = "id";
        }
        private void LoadData()
        {
            string sql = string.Empty;
            sql = $@"select a.MaNhanVien, ngaysinh, GioiTinh, c.DienThoaiDD, email,b.DiaChi, a.HinhAnh 
                    from MITACOSQL.dbo.NHANVIEN a 
                    left join tbl_NhanVien c on a.MaNhanVien = c.MaNhanVien
                    left join tbl_NhanVienDiaChi b on a.MaNhanVien = b.MaNhanVien 
                    Where a.MaNhanVien = '{dgv_NhanVien.CurrentRow.Cells["MaNhanVien_NV"].Value.ToString()}' ";
            DataTable dt = new DataTable();
            dt = SQLHelper.ExecuteDt(sql);
            if (dt.Rows.Count > 0)
            {
                txt_MaNhanVien.Text = dt.Rows[0]["MaNhanVien"].ToString();
                dtp_NgaySinh.Text = DateTime.Parse(dt.Rows[0]["ngaysinh"].ToString()).ToString("yyyy/MM/dd");
                chk_GioiTinh.Checked = dt.Rows[0]["GioiTinh"].ToString() == "True" ? true : false;
                txt_SDT.Text = dt.Rows[0]["DienThoaiDD"].ToString();
                txt_Email.Text = dt.Rows[0]["email"].ToString();
                txt_DiaChi.Text = dt.Rows[0]["DiaChi"].ToString();
                if (!string.IsNullOrEmpty(dt.Rows[0]["HinhAnh"].ToString()))
                {
                    Byte[] byteanh_nv = new Byte[0];
                    byteanh_nv = (Byte[])(dt.Rows[0]["HinhAnh"]);
                    MemoryStream stmBLOBData = new MemoryStream(byteanh_nv);
                    pb_avata.Image = Image.FromStream(stmBLOBData);
                }
                else
                {
                    pb_avata.Image = null;
                }
            }
            maNhanVien = dgv_NhanVien.CurrentRow.Cells["MaNhanVien_NV"].Value.ToString();
            LoadQTCongTac();
            LoadQTKhenThuong();
            LoadQTKyLuat();
            LoadQTTaiNan();
            LoadQTThaiSan();
            LoadQTDanhGia();
            LoadQTNghiViec();
            LoadQTDaoTao();
        }
        public void LoadQTNghiViec()
        {
            string sql = string.Empty;
            sql = $@"Select Id, TuNgay, DenNgay, NgayQuyetDinh, SoQuyetDinh, NoiDung,TypeName as LoaiNghiViec from tbl_QTNghiViec a
                Left join sys_AllType b on a.LoaiNghiViec = b.TypeId
                Where a.MaNhanVien = {SQLHelper.rpStr(maNhanVien)} and a.del_flg = 0";
            dgv_qt_nghiviec.DataSource = SQLHelper.ExecuteDt(sql);
        }
        public void LoadQTDaoTao()
        {
            string sql = string.Empty;
            sql = $@"select Id, TuNgay, DenNgay, SoQuyetDinh, NoiDung, b.TypeName as HinhThuc from tbl_QTDaoTao a 
               left join sys_AllType b on a.HinhThuc = b.TypeId 
               where MaNhanVien = {SQLHelper.rpStr(maNhanVien)} and a.del_flg = 0";
            dgv_qt_daotao.DataSource = SQLHelper.ExecuteDt(sql);
        }
        public void LoadQTDanhGia()
        {
            string sql = string.Empty;
            sql = $@"Select Id, NgayDanhGia, NoiDung, DiemDanhGia, b.TypeName as XepLoai from tbl_QTDanhGia a 
                Left join sys_AllType b on a.XepLoai = b.TypeNameShort 
                Where a.MaNhanVien = {SQLHelper.rpStr(maNhanVien)} and a.del_flg = 0";
            dgv_qt_danhgia.DataSource = SQLHelper.ExecuteDt(sql);
        }
        public void LoadQTThaiSan()
        {
            string sql = string.Empty;
            sql = $@"select Id, TuNgay, DenNgay, GhiChu from tbl_NhanVienThaiSan
               where MaNhanVien = {SQLHelper.rpStr(maNhanVien)} and del_flg = 0";
            dgv_thaisai.DataSource = SQLHelper.ExecuteDt(sql);
        }
        public void LoadQTTaiNan()
        {
            string sql = string.Empty;
            sql = $@"select a.Id, b.TypeName as LoaiTaiNan, c.TypeName as MucDo, NgayDienRa, NoiDienRa, NoiDung from tbl_QTTaiNan a 
                 join sys_AllType b on a.Id_LoaiTaiNan = b.TypeId 
                 join sys_AllType c on a.Id_MucDo = c.TypeId 
                 where a.MaNhanVien = {SQLHelper.rpStr(maNhanVien)} and a.del_flg = 0";
            DataTable dt = new DataTable();
            dt = SQLHelper.ExecuteDt(sql);
            dgv_tainan.DataSource = dt;
        }
        public void LoadQTKyLuat()
        {
            string sql = string.Empty;
            sql = $@"select Id, NgayKyLuat, SoQuyetDinh, NoiDung, b.TypeName as HinhThuc, LyDo from tbl_QTKyLuat a 
                Left join sys_AllType b on a.HinhThuc = b.TypeId
                where a.MaNhanVien = {SQLHelper.rpStr(maNhanVien)} and a.del_flg = 0";
            DataTable dt = new DataTable();
            dt = SQLHelper.ExecuteDt(sql);
            dgv_kyluat.DataSource = dt;
        }
        public void LoadQTCongTac()
        {
            string sql = string.Empty;
            sql = $@"select Id, TuNgay, DenNgay, SoQuyetDinh, DiaDiem, NoiDung from tbl_QTCongTac 
             where MaNhanVien = {SQLHelper.rpStr(maNhanVien)} and del_flg = 0";
            DataTable dt = new DataTable();
            dt = SQLHelper.ExecuteDt(sql);
            dgv_congtac.DataSource = dt;
        }
        public void LoadQTKhenThuong()
        {
            string sql = string.Empty;
            sql = $@"select Id, NgayKhenThuong, SoQuyetDinh, NoiDung, b.TypeName as HinhThuc, FORMAT(SoTien,'N0') as SoTien, LyDo from tbl_QTKhenThuong a 
                 Left join sys_AllType b on a.HinhThuc = b.TypeId
                 where a.MaNhanVien = {SQLHelper.rpStr(maNhanVien)} and a.del_flg = 0";
            DataTable dt = new DataTable();
            dt = SQLHelper.ExecuteDt(sql);
            dgv_khenthuong.DataSource = dt;
        }

        private void btn_add_congtac_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(maNhanVien))
            {
                frm_congtac frm = new frm_congtac(null, this);
                frm._MaNhanVien = maNhanVien;
                frm.edit = false;
                frm.ShowDialog();
            }
        }
        private void dgv_congtac_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0 && e.ColumnIndex == dgv_congtac.Columns["edit_column_ct"].Index)
            {
                frm_congtac frm = new frm_congtac(null, this);
                frm._IdCongTac = int.Parse(dgv_congtac.CurrentRow.Cells["id_qt_congtac"].Value.ToString());
                frm._MaNhanVien = maNhanVien;
                frm.edit = true;
                frm.ShowDialog();
            }
        }
        private void dgv_khenthuong_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0 && e.ColumnIndex == dgv_khenthuong.Columns["edit_column_kt"].Index)
            {
                frm_khenthuong frm = new frm_khenthuong(null, this);
                frm._IdKhenThuong = int.Parse(dgv_khenthuong.CurrentRow.Cells["id_qt_khenthuong"].Value.ToString());
                frm._MaNhanVien = maNhanVien;
                frm.edit = true;
                frm.ShowDialog();
            }
        }
        private void btn_add_khenthuong_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(maNhanVien))
            {
                frm_khenthuong frm = new frm_khenthuong(null, this);
                frm._MaNhanVien = maNhanVien;
                frm.edit = false;
                frm.ShowDialog();
            }
        }
        private void dgv_kyluat_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0 && e.ColumnIndex == dgv_kyluat.Columns["edit_column_kl"].Index)
            {
                frm_nhanvien_kyluat frm = new frm_nhanvien_kyluat(null, this);
                frm._IdKyLuat = int.Parse(dgv_kyluat.CurrentRow.Cells["id_qt_kyluat"].Value.ToString());
                frm._MaNhanVien = maNhanVien;
                frm.edit = true;
                frm.ShowDialog();
            }
        }
        private void btn_add_kl_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(maNhanVien))
            {
                frm_nhanvien_kyluat frm = new frm_nhanvien_kyluat(null, this);
                frm._MaNhanVien = maNhanVien;
                frm.edit = false;
                frm.ShowDialog();
            }
        }
        private void btn_add_tainan_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(maNhanVien))
            {
                frm_nhanvien_tainan frm = new frm_nhanvien_tainan(null, this);
                frm._MaNhanVien = maNhanVien;
                frm.edit = false;
                frm.ShowDialog();
            }
        }
        private void dgv_tainan_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0 && e.ColumnIndex == dgv_tainan.Columns["edit_column_tn"].Index)
            {
                frm_nhanvien_tainan frm = new frm_nhanvien_tainan(null, this);
                frm._IdTaiNhan = int.Parse(dgv_tainan.CurrentRow.Cells["id_qt_tainan"].Value.ToString());
                frm._MaNhanVien = maNhanVien;
                frm.edit = true;
                frm.ShowDialog();
            }
        }
        private void btn_add_dg_Click(object sender, EventArgs e)
        {
            frm_danhgia frm = new frm_danhgia(null, this);
            frm._edit = false;
            frm._MaNhanVien = maNhanVien;
            frm.ShowDialog();
        }
        private void dgv_qt_danhgia_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0 && e.ColumnIndex == dgv_qt_danhgia.Columns["edit_column_danhgia"].Index)
            {
                frm_danhgia frm = new frm_danhgia(null, this);
                frm._IdDanhGia = int.Parse(dgv_qt_danhgia.CurrentRow.Cells["id_qt_danhgia"].Value.ToString());
                frm._MaNhanVien = maNhanVien;
                frm._edit = true;
                frm.ShowDialog();
            }
        }
        private void dgv_qt_daotao_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0 && e.ColumnIndex == dgv_qt_daotao.Columns["edit_column_daotao"].Index)
            {
                frm_daotao frm = new frm_daotao(null, this);
                frm._edit = true;
                frm._IdDaoTao = int.Parse(dgv_qt_daotao.CurrentRow.Cells["id_qt_daotao"].Value.ToString());
                frm._MaNhanVien = maNhanVien;
                frm.ShowDialog();
            }
        }
        private void btn_add_dt_Click(object sender, EventArgs e)
        {
            frm_daotao frm = new frm_daotao(null, this);
            frm._edit = false;
            frm._MaNhanVien = maNhanVien;
            frm.ShowDialog();
        }
        private void btn_add_nv_Click(object sender, EventArgs e)
        {
            frm_nghiviec frm = new frm_nghiviec(null, this);
            frm._MaNhanVien = maNhanVien;
            frm._edit = false;
            frm.ShowDialog();
        }
        private void dgv_qt_nghiviec_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0 && e.ColumnIndex == dgv_qt_nghiviec.Columns["edit_column_nghiviec"].Index)
            {
                frm_nghiviec frm = new frm_nghiviec(null, this);
                frm._edit = true;
                frm._IdNghiViec = int.Parse(dgv_qt_nghiviec.CurrentRow.Cells["id_qt_nghiviec"].Value.ToString());
                frm._MaNhanVien = maNhanVien;
                frm.ShowDialog();
            }
        }
        private void dgv_thaisai_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0 && e.ColumnIndex == dgv_thaisai.Columns["edit_column_ts"].Index)
            {
                frm_thaisan frm = new frm_thaisan(null, this);
                frm._MaNhanVien = maNhanVien;
                frm._IdThaiSan = int.Parse(dgv_thaisai.CurrentRow.Cells["id_qt_thaisan"].Value.ToString());
                frm.edit = true;
                frm.ShowDialog();
            }
        }
        private void btn_add_ts_Click(object sender, EventArgs e)
        {
            frm_thaisan frm = new frm_thaisan(null, this);
            frm._MaNhanVien = maNhanVien;
            frm.edit = false;
            frm.ShowDialog();
        }
        private void btn_refresh_ct_Click(object sender, EventArgs e)
        {
            LoadQTCongTac();
        }
        private void btn_refresh_kt_Click(object sender, EventArgs e)
        {
            LoadQTKhenThuong();
        }
        private void btn_refresh_kl_Click(object sender, EventArgs e)
        {
            LoadQTKyLuat();
        }
        private void btn_refresh_dg_Click(object sender, EventArgs e)
        {
            LoadQTDanhGia();
        }
        private void btn_refresh_dt_Click(object sender, EventArgs e)
        {
            LoadQTDaoTao();
        }
        private void btn_refresh_tn_Click(object sender, EventArgs e)
        {
            LoadQTTaiNan();
        }
        private void btn_refresh_nv_Click(object sender, EventArgs e)
        {
            LoadQTNghiViec();
        }
        private void btn_refresh_ts_Click(object sender, EventArgs e)
        {
            LoadQTThaiSan();
        }
        private void btn_delete_ct_Click(object sender, EventArgs e)
        {
            if (dgv_congtac.Rows.Count > 0)
            {
                DialogResult dialogResult = RJMessageBox.Show("Bạn có chắc muốn xóa dữ liệu này", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (dialogResult == DialogResult.Yes)
                {
                    delete_value("tbl_QTCongTac", "Id", dgv_congtac.CurrentRow.Cells["id_qt_congtac"].Value.ToString());
                    LoadQTCongTac();
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
                new System.Drawing.Rectangle(e.RowBounds.Left, e.RowBounds.Top, grid.RowHeadersWidth, e.RowBounds.Height);
            e.Graphics.DrawString(rowIdx, Font, SystemBrushes.ControlText, headerBounds, centerFormat);
        }
        private void btn_delete_kt_Click(object sender, EventArgs e)
        {
            if (dgv_khenthuong.Rows.Count > 0)
            {
                DialogResult dialogResult = RJMessageBox.Show("Bạn có chắc muốn xóa dữ liệu này", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (dialogResult == DialogResult.Yes)
                {
                    delete_value("tbl_QTKhenThuong", "Id", dgv_khenthuong.CurrentRow.Cells["id_qt_khenthuong"].Value.ToString());
                    LoadQTKhenThuong();
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
                    delete_value("tbl_QTKyluat", "Id", dgv_kyluat.CurrentRow.Cells["id_qt_kyluat"].Value.ToString());
                    LoadQTKyLuat();
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
                    delete_value("tbl_QTDanhGia", "id", dgv_qt_danhgia.CurrentRow.Cells["id_qt_danhgia"].Value.ToString());
                    LoadQTDanhGia();
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
                    delete_value("tbl_QTDaoTao", "id", dgv_qt_daotao.CurrentRow.Cells["id_qt_daotao"].Value.ToString());
                    LoadQTDaoTao();
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
                    delete_value("tbl_QTTaiNan", "id", dgv_tainan.CurrentRow.Cells["id_qt_tainan"].Value.ToString());
                    LoadQTTaiNan();
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
                    delete_value("tbl_QTNghiViec", "id", dgv_qt_nghiviec.CurrentRow.Cells["id_qt_nghiviec"].Value.ToString());
                    LoadQTNghiViec();
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
                    delete_value("tbl_NhanVienThaiSan", "id", dgv_thaisai.CurrentRow.Cells["id_qt_thaisan"].Value.ToString());
                    LoadQTThaiSan();
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
        private static ICellStyle CreateHeaderStyle(IWorkbook workbook)
        {
            var headerStyle = workbook.CreateCellStyle();
            headerStyle.BorderTop = NPOI.SS.UserModel.BorderStyle.Thin;
            headerStyle.BorderBottom = NPOI.SS.UserModel.BorderStyle.Thin;
            headerStyle.BorderLeft = NPOI.SS.UserModel.BorderStyle.Thin;
            headerStyle.BorderRight = NPOI.SS.UserModel.BorderStyle.Thin;
            headerStyle.FillForegroundColor = NPOI.HSSF.Util.HSSFColor.LightGreen.Index;
            headerStyle.FillPattern = FillPattern.SolidForeground;

            var headerFont = workbook.CreateFont();
            headerFont.IsBold = true;
            headerFont.FontHeightInPoints = 12;
            headerStyle.SetFont(headerFont);

            return headerStyle;
        }
        private static ICellStyle CreateDataStyle(IWorkbook workbook)
        {
            var dataStyle = workbook.CreateCellStyle();
            dataStyle.BorderTop = NPOI.SS.UserModel.BorderStyle.Thin;
            dataStyle.BorderBottom = NPOI.SS.UserModel.BorderStyle.Thin;
            dataStyle.BorderLeft = NPOI.SS.UserModel.BorderStyle.Thin;
            dataStyle.BorderRight = NPOI.SS.UserModel.BorderStyle.Thin;

            return dataStyle;
        }
        private static void WriteDataToSheet(ISheet worksheet, string[] headers, List<List<string>> data, ICellStyle headerStyle, ICellStyle dataStyle)
        {
            var headerRow = worksheet.CreateRow(0);
            for (int i = 0; i < headers.Length; i++)
            {
                var cell = headerRow.CreateCell(i);
                cell.SetCellValue(headers[i]);
                cell.CellStyle = headerStyle;
            }

            for (int rowIndex = 0; rowIndex < data.Count; rowIndex++)
            {
                var row = worksheet.CreateRow(rowIndex + 1);
                var rowData = data[rowIndex];
                for (int colIndex = 0; colIndex < rowData.Count; colIndex++)
                {
                    var cell = row.CreateCell(colIndex);
                    cell.SetCellValue(rowData[colIndex]);
                    cell.CellStyle = dataStyle;
                }
            }

            for (int i = 0; i < headers.Length; i++)
            {
                worksheet.AutoSizeColumn(i);
            }
        }
        private static void SaveWorkbook(IWorkbook workbook, string fileName)
        {
            string desktopPath = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);
            string filePath = Path.Combine(desktopPath, fileName);

            using (var fileStream = new FileStream(filePath, FileMode.Create, FileAccess.Write))
            {
                workbook.Write(fileStream);
            }
            workbook.Close();
        }
        private void btn_export_ct_Click(object sender, EventArgs e)
        {
            try
            {
                Cursor.Current = Cursors.WaitCursor;

                string[] headers = { "Từ ngày", "Đến ngày", "Số quyết định", "Địa điểm", "Nội dung" };
                var data = new List<List<string>>();
                foreach (DataGridViewRow dgvRow in dgv_congtac.Rows)
                {
                    if (!dgvRow.IsNewRow)
                    {
                        data.Add(new List<string>
                        {
                            DateTime.TryParse(dgvRow.Cells["TuNgayCT"].Value?.ToString(), out DateTime tuNgay)
                                ? tuNgay.ToString("yyyy/MM/dd") : "",
                            DateTime.TryParse(dgvRow.Cells["DenNgayCT"].Value?.ToString(), out DateTime denNgay)
                                ? denNgay.ToString("yyyy/MM/dd") : "",
                            dgvRow.Cells["SoQuyetDinhCT"].Value?.ToString() ?? "",
                            dgvRow.Cells["DiaDiemCT"].Value?.ToString() ?? "",
                            dgvRow.Cells["NoiDungCT"].Value?.ToString() ?? ""
                        });
                    }
                }

                var workbook = new NPOI.XSSF.UserModel.XSSFWorkbook();
                var worksheet = workbook.CreateSheet("QuaTrinhCongTac");

                var headerStyle = CreateHeaderStyle(workbook);
                var dataStyle = CreateDataStyle(workbook);

                WriteDataToSheet(worksheet, headers, data, headerStyle, dataStyle);

                SaveWorkbook(workbook, $"QuaTrinhCongTac{DateTime.Now:yyyyMMdd}.xlsx");

                Cursor.Current = Cursors.Default;
                RJMessageBox.Show("Xuất dữ liệu thành công! File đã được lưu vào Desktop.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                RJMessageBox.Show(ex.Message, "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void btn_export_kt_Click(object sender, EventArgs e)
        {
            try
            {
                Cursor.Current = Cursors.WaitCursor;

                string[] headers = { "Ngày khen thưởng", "Số quyết định", "Nội dung", "Hình thức", "Số tiền", "Lý do" };
                var data = new List<List<string>>();
                foreach (DataGridViewRow dgvRow in dgv_khenthuong.Rows)
                {
                    if (!dgvRow.IsNewRow)
                    {
                        data.Add(new List<string>
                        {
                            DateTime.TryParse(dgvRow.Cells["NgayKhenThuong"].Value?.ToString(), out DateTime ngayKhenThuong)
                                ? ngayKhenThuong.ToString("yyyy/MM/dd") : "",
                            dgvRow.Cells["SoQuyetDinhKT"].Value?.ToString() ?? "",
                            dgvRow.Cells["NoiDungKT"].Value?.ToString() ?? "",
                            dgvRow.Cells["HinhThucKT"].Value?.ToString() ?? "",
                            dgvRow.Cells["SoTienKT"].Value?.ToString() ?? "",
                            dgvRow.Cells["LyDoKT"].Value?.ToString() ?? ""
                        });
                    }
                }

                var workbook = new NPOI.XSSF.UserModel.XSSFWorkbook();
                var worksheet = workbook.CreateSheet("QuaTrinhKhenThuong");

                var headerStyle = CreateHeaderStyle(workbook);
                var dataStyle = CreateDataStyle(workbook);

                WriteDataToSheet(worksheet, headers, data, headerStyle, dataStyle);

                SaveWorkbook(workbook, $"QuaTrinhKhenThuong{DateTime.Now:yyyyMMdd}.xlsx");

                Cursor.Current = Cursors.Default;
                RJMessageBox.Show("Xuất dữ liệu thành công! File đã được lưu vào Desktop.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                RJMessageBox.Show(ex.Message, "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void btn_export_kl_Click(object sender, EventArgs e)
        {
            try
            {
                Cursor.Current = Cursors.WaitCursor;

                string[] headers = { "Ngày kỷ luật", "Số quyết định", "Nội dung", "Hình thức", "Lý do" };
                var data = new List<List<string>>();
                foreach (DataGridViewRow dgvRow in dgv_kyluat.Rows)
                {
                    if (!dgvRow.IsNewRow)
                    {
                        data.Add(new List<string>
                        {
                            DateTime.TryParse(dgvRow.Cells["NgayKyLuat"].Value?.ToString(), out DateTime ngayKyLuat)
                                ? ngayKyLuat.ToString("yyyy/MM/dd") : "",
                            dgvRow.Cells["SoQuyetDinhKL"].Value?.ToString() ?? "",
                            dgvRow.Cells["NoiDungKL"].Value?.ToString() ?? "",
                            dgvRow.Cells["HinhThucKL"].Value?.ToString() ?? "",
                            dgvRow.Cells["LyDoKL"].Value?.ToString() ?? ""
                        });
                    }
                }

                var workbook = new NPOI.XSSF.UserModel.XSSFWorkbook();
                var worksheet = workbook.CreateSheet("QuaTrinhKyLuat");

                var headerStyle = CreateHeaderStyle(workbook);
                var dataStyle = CreateDataStyle(workbook);

                WriteDataToSheet(worksheet, headers, data, headerStyle, dataStyle);

                SaveWorkbook(workbook, $"QuaTrinhKyLuat{DateTime.Now:yyyyMMdd}.xlsx");

                Cursor.Current = Cursors.Default;
                RJMessageBox.Show("Xuất dữ liệu thành công! File đã được lưu vào Desktop.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                RJMessageBox.Show(ex.Message, "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void btn_export_dg_Click(object sender, EventArgs e)
        {
            try
            {
                Cursor.Current = Cursors.WaitCursor;

                string[] headers = { "Ngày đánh giá", "Nội dung", "Điểm đánh giá", "Xếp loại" };
                var data = new List<List<string>>();
                foreach (DataGridViewRow dgvRow in dgv_qt_danhgia.Rows)
                {
                    if (!dgvRow.IsNewRow)
                    {
                        data.Add(new List<string>
                        {
                            DateTime.TryParse(dgvRow.Cells["NgayDanhGia"].Value?.ToString(), out DateTime ngayDanhGia)
                                ? ngayDanhGia.ToString("yyyy/MM/dd") : "",
                            dgvRow.Cells["NoiDungDG"].Value?.ToString() ?? "",
                            dgvRow.Cells["DiemDanhGia"].Value?.ToString() ?? "",
                            dgvRow.Cells["XepLoaiDG"].Value?.ToString() ?? ""
                        });
                    }
                }

                var workbook = new NPOI.XSSF.UserModel.XSSFWorkbook();
                var worksheet = workbook.CreateSheet("QuaTrinhDanhGia");

                var headerStyle = CreateHeaderStyle(workbook);
                var dataStyle = CreateDataStyle(workbook);

                WriteDataToSheet(worksheet, headers, data, headerStyle, dataStyle);

                SaveWorkbook(workbook, $"QuaTrinhDanhGia{DateTime.Now:yyyyMMdd}.xlsx");

                Cursor.Current = Cursors.Default;
                RJMessageBox.Show("Xuất dữ liệu thành công! File đã được lưu vào Desktop.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                RJMessageBox.Show(ex.Message, "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void btn_export_dt_Click(object sender, EventArgs e)
        {
            try
            {
                Cursor.Current = Cursors.WaitCursor;

                string[] headers = { "Từ ngày", "Đến ngày", "Số quyết định", "Nội dung", "Hình thức" };
                var data = new List<List<string>>();
                foreach (DataGridViewRow dgvRow in dgv_qt_daotao.Rows)
                {
                    if (!dgvRow.IsNewRow)
                    {
                        data.Add(new List<string>
                        {
                            DateTime.TryParse(dgvRow.Cells["TuNgayDT"].Value?.ToString(), out DateTime tuNgay)
                                ? tuNgay.ToString("yyyy/MM/dd") : "",
                            DateTime.TryParse(dgvRow.Cells["DenNgayDT"].Value?.ToString(), out DateTime denNgay)
                                ? denNgay.ToString("yyyy/MM/dd") : "",
                            dgvRow.Cells["SoQuyetDinhDT"].Value?.ToString() ?? "",
                            dgvRow.Cells["NoiDungDT"].Value?.ToString() ?? "",
                            dgvRow.Cells["HinhThucDT"].Value?.ToString() ?? ""
                        });
                    }
                }

                var workbook = new NPOI.XSSF.UserModel.XSSFWorkbook();
                var worksheet = workbook.CreateSheet("QuaTrinhDaoTao");

                var headerStyle = CreateHeaderStyle(workbook);
                var dataStyle = CreateDataStyle(workbook);

                WriteDataToSheet(worksheet, headers, data, headerStyle, dataStyle);

                SaveWorkbook(workbook, $"QuaTrinhDaoTao{DateTime.Now:yyyyMMdd}.xlsx");

                Cursor.Current = Cursors.Default;
                RJMessageBox.Show("Xuất dữ liệu thành công! File đã được lưu vào Desktop.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                RJMessageBox.Show(ex.Message, "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void btn_export_tn_Click(object sender, EventArgs e)
        {
            try
            {
                Cursor.Current = Cursors.WaitCursor;

                string[] headers = { "Loại tai nạn", "Mức độ", "Ngày diễn ra", "Nơi diễn ra", "Nội dung" };
                var data = new List<List<string>>();
                foreach (DataGridViewRow dgvRow in dgv_tainan.Rows)
                {
                    if (!dgvRow.IsNewRow)
                    {
                        data.Add(new List<string>
                        {
                            dgvRow.Cells["LoaiTaiNan"].Value?.ToString() ?? "",
                            dgvRow.Cells["MucDoTN"].Value?.ToString() ?? "",
                            DateTime.TryParse(dgvRow.Cells["NgayDienRaTN"].Value?.ToString(), out DateTime ngayDienRa)
                                ? ngayDienRa.ToString("yyyy/MM/dd") : "",
                            dgvRow.Cells["NoiDienRaTN"].Value?.ToString() ?? "",
                            dgvRow.Cells["NoiDungTN"].Value?.ToString() ?? ""
                        });
                    }
                }

                var workbook = new NPOI.XSSF.UserModel.XSSFWorkbook();
                var worksheet = workbook.CreateSheet("QuaTrinhTaiNan");

                var headerStyle = CreateHeaderStyle(workbook);
                var dataStyle = CreateDataStyle(workbook);

                WriteDataToSheet(worksheet, headers, data, headerStyle, dataStyle);

                SaveWorkbook(workbook, $"QuaTrinhTaiNan{DateTime.Now:yyyyMMdd}.xlsx");

                Cursor.Current = Cursors.Default;
                RJMessageBox.Show("Xuất dữ liệu thành công! File đã được lưu vào Desktop.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                RJMessageBox.Show(ex.Message, "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void btn_export_ts_Click(object sender, EventArgs e)
        {
            try
            {
                Cursor.Current = Cursors.WaitCursor;

                string[] headers = { "Từ ngày", "Đến ngày", "Ghi chú" };
                var data = new List<List<string>>();
                foreach (DataGridViewRow dgvRow in dgv_thaisai.Rows)
                {
                    if (!dgvRow.IsNewRow)
                    {
                        data.Add(new List<string>
                        {
                            DateTime.TryParse(dgvRow.Cells["TuNgayTS"].Value?.ToString(), out DateTime tuNgayTS)
                                ? tuNgayTS.ToString("yyyy/MM/dd") : "",
                            DateTime.TryParse(dgvRow.Cells["DenNgayTS"].Value?.ToString(), out DateTime denNgayTS)
                                ? denNgayTS.ToString("yyyy/MM/dd") : "",
                            dgvRow.Cells["GhiChuTS"].Value?.ToString() ?? ""
                        });
                    }
                }

                var workbook = new NPOI.XSSF.UserModel.XSSFWorkbook();
                var worksheet = workbook.CreateSheet("QuaTrinhThaiSan");

                var headerStyle = CreateHeaderStyle(workbook);
                var dataStyle = CreateDataStyle(workbook);

                WriteDataToSheet(worksheet, headers, data, headerStyle, dataStyle);

                SaveWorkbook(workbook, $"QuaTrinhThaiSan{DateTime.Now:yyyyMMdd}.xlsx");

                Cursor.Current = Cursors.Default;
                RJMessageBox.Show("Xuất dữ liệu thành công! File đã được lưu vào Desktop.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                RJMessageBox.Show(ex.Message, "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void btn_export_nv_Click(object sender, EventArgs e)
        {
            try
            {
                Cursor.Current = Cursors.WaitCursor;

                string[] headers = { "Từ ngày", "Đến ngày", "Ngày quyết định", "Số quyết định", "Nội dung", "Loại nghỉ việc" };
                var data = new List<List<string>>();
                foreach (DataGridViewRow dgvRow in dgv_qt_nghiviec.Rows)
                {
                    if (!dgvRow.IsNewRow)
                    {
                        data.Add(new List<string>
                        {
                            DateTime.TryParse(dgvRow.Cells["TuNgayNV"].Value?.ToString(), out DateTime tuNgay)
                                ? tuNgay.ToString("yyyy/MM/dd") : "",
                            DateTime.TryParse(dgvRow.Cells["DenNgayNV"].Value?.ToString(), out DateTime denNgay)
                                ? denNgay.ToString("yyyy/MM/dd") : "",
                            DateTime.TryParse(dgvRow.Cells["NgayQuyetDinhNV"].Value?.ToString(), out DateTime ngayQuyetDinh)
                                ? ngayQuyetDinh.ToString("yyyy/MM/dd") : "",
                            dgvRow.Cells["SoQuyetDinhNV"].Value?.ToString() ?? "",
                            dgvRow.Cells["NoiDungNV"].Value?.ToString() ?? "",
                            dgvRow.Cells["LoaiNghiViec"].Value?.ToString() ?? ""
                        });
                    }
                }

                var workbook = new NPOI.XSSF.UserModel.XSSFWorkbook();
                var worksheet = workbook.CreateSheet("QuaTrinhNghiViec");

                var headerStyle = CreateHeaderStyle(workbook);
                var dataStyle = CreateDataStyle(workbook);

                WriteDataToSheet(worksheet, headers, data, headerStyle, dataStyle);

                SaveWorkbook(workbook, $"QuaTrinhNghiViec{DateTime.Now:yyyyMMdd}.xlsx");

                Cursor.Current = Cursors.Default;
                RJMessageBox.Show("Xuất dữ liệu thành công! File đã được lưu vào Desktop.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                RJMessageBox.Show(ex.Message, "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private List<string> GetPrintersFromRegistry()
        {
            List<string> printers = new List<string>();

            string registryPath = @"SOFTWARE\Microsoft\Windows NT\CurrentVersion\Print\Printers";

            using (RegistryKey printersKey = Registry.LocalMachine.OpenSubKey(registryPath))
            {
                if (printersKey != null)
                {
                    string[] printerNames = printersKey.GetSubKeyNames();
                    foreach (var printerName in printerNames)
                    {
                        printers.Add(printerName);
                    }
                }
            }

            return printers;
        }
        private void LoadComboboxPrinters()
        {
            List<string> printers = GetPrintersFromRegistry();

            comboBoxCTPrinters.Items.Clear();
            foreach (string printer in printers)
            {
                comboBoxCTPrinters.Items.Add(printer);
            }

            comboBoxKTPrinters.Items.Clear();
            foreach (string printer in printers)
            {
                comboBoxKTPrinters.Items.Add(printer);
            }

            comboBoxKLPrinters.Items.Clear();
            foreach (string printer in printers)
            {
                comboBoxKLPrinters.Items.Add(printer);
            }

            comboBoxDGPrinters.Items.Clear();
            foreach (string printer in printers)
            {
                comboBoxDGPrinters.Items.Add(printer);
            }

            comboBoxDTPrinters.Items.Clear();
            foreach (string printer in printers)
            {
                comboBoxDTPrinters.Items.Add(printer);
            }

            comboBoxNVPrinters.Items.Clear();
            foreach (string printer in printers)
            {
                comboBoxNVPrinters.Items.Add(printer);
            }

            comboBoxTSPrinters.Items.Clear();
            foreach (string printer in printers)
            {
                comboBoxTSPrinters.Items.Add(printer);
            }

            comboBoxTNPrinters.Items.Clear();
            foreach (string printer in printers)
            {
                comboBoxTNPrinters.Items.Add(printer);
            }
        }
        private void btn_print_ct_Click(object sender, EventArgs e)
        {
            if (comboBoxCTPrinters.SelectedItem != null)
            {
                try
                {
                    string[] headers = { "Từ ngày", "Đến ngày", "Số quyết định", "Địa điểm", "Nội dung" };
                    var data = new List<List<string>>();
                    foreach (DataGridViewRow dgvRow in dgv_congtac.Rows)
                    {
                        if (!dgvRow.IsNewRow)
                        {
                            data.Add(new List<string>
                            {
                                DateTime.TryParse(dgvRow.Cells["TuNgayCT"].Value?.ToString(), out DateTime tuNgay)
                                    ? tuNgay.ToString("yyyy/MM/dd") : "",
                                DateTime.TryParse(dgvRow.Cells["DenNgayCT"].Value?.ToString(), out DateTime denNgay)
                                    ? denNgay.ToString("yyyy/MM/dd") : "",
                                dgvRow.Cells["SoQuyetDinhCT"].Value?.ToString() ?? "",
                                dgvRow.Cells["DiaDiemCT"].Value?.ToString() ?? "",
                                dgvRow.Cells["NoiDungCT"].Value?.ToString() ?? ""
                            });
                        }
                    }
                    var excelApp = new Application();
                    var workbooks = excelApp.Workbooks;
                    var workbook = workbooks.Add(XlWBATemplate.xlWBATWorksheet);
                    var worksheet = (Worksheet)workbook.Sheets[1];

                    string title = "Quá trình công tác " + maNhanVien;
                    worksheet.Cells[1, 1] = title;

                    var titleRange = worksheet.Range[worksheet.Cells[1, 1], worksheet.Cells[1, headers.Length]];
                    titleRange.Merge();
                    titleRange.HorizontalAlignment = XlHAlign.xlHAlignCenter;
                    titleRange.Font.Bold = true;
                    titleRange.Font.Size = 14;

                    for (int i = 0; i < headers.Length; i++)
                    {
                        worksheet.Cells[2, i + 1] = headers[i];
                    }

                    for (int i = 0; i < data.Count; i++)
                    {
                        for (int j = 0; j < data[i].Count; j++)
                        {
                            worksheet.Cells[i + 3, j + 1] = data[i][j];
                        }
                    }

                    var range = worksheet.Range[worksheet.Cells[2, 1], worksheet.Cells[data.Count + 2, headers.Length]];
                    range.Borders[XlBordersIndex.xlEdgeBottom].LineStyle = XlLineStyle.xlContinuous;
                    range.Borders[XlBordersIndex.xlEdgeTop].LineStyle = XlLineStyle.xlContinuous;
                    range.Borders[XlBordersIndex.xlEdgeLeft].LineStyle = XlLineStyle.xlContinuous;
                    range.Borders[XlBordersIndex.xlEdgeRight].LineStyle = XlLineStyle.xlContinuous;

                    range.Borders[XlBordersIndex.xlInsideHorizontal].LineStyle = XlLineStyle.xlContinuous;
                    range.Borders[XlBordersIndex.xlInsideVertical].LineStyle = XlLineStyle.xlContinuous;

                    worksheet.Columns.AutoFit();
                    worksheet.Rows.AutoFit();

                    worksheet.PageSetup.Orientation = XlPageOrientation.xlPortrait;
                    worksheet.PageSetup.PaperSize = XlPaperSize.xlPaperA4;

                    string selectedPrinter = comboBoxCTPrinters.SelectedItem.ToString();
                    excelApp.ActivePrinter = selectedPrinter;
                    worksheet.PrintOut();

                    //string pdfPath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.Desktop),
                    //            $"QuaTrinhCongTac_{DateTime.Now:yyyyMMddHHmmss}.pdf");
                    //worksheet.ExportAsFixedFormat(Microsoft.Office.Interop.Excel.XlFixedFormatType.xlTypePDF, pdfPath);

                    workbook.Close(false);
                    Marshal.ReleaseComObject(workbook);
                    Marshal.ReleaseComObject(workbooks);
                    Marshal.ReleaseComObject(excelApp);

                    RJMessageBox.Show("Dữ liệu đã được in thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                catch (Exception ex)
                {
                    RJMessageBox.Show("Lỗi khi in: " + ex.Message, "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }
        private void btn_print_kt_Click(object sender, EventArgs e)
        {
            if (comboBoxKTPrinters.SelectedItem != null)
            {
                try
                {
                    Cursor.Current = Cursors.WaitCursor;

                    string[] headers = { "Ngày khen thưởng", "Số quyết định", "Nội dung", "Hình thức", "Số tiền", "Lý do" };
                    var data = new List<List<string>>();

                    foreach (DataGridViewRow dgvRow in dgv_khenthuong.Rows)
                    {
                        if (!dgvRow.IsNewRow)
                        {
                            data.Add(new List<string>
                            {
                                DateTime.TryParse(dgvRow.Cells["NgayKhenThuong"].Value?.ToString(), out DateTime ngayKhenThuong)
                                    ? ngayKhenThuong.ToString("yyyy/MM/dd") : "",
                                dgvRow.Cells["SoQuyetDinhKT"].Value?.ToString() ?? "",
                                dgvRow.Cells["NoiDungKT"].Value?.ToString() ?? "",
                                dgvRow.Cells["HinhThucKT"].Value?.ToString() ?? "",
                                dgvRow.Cells["SoTienKT"].Value?.ToString() ?? "",
                                dgvRow.Cells["LyDoKT"].Value?.ToString() ?? ""
                            });
                        }
                    }

                    var excelApp = new Application();
                    var workbooks = excelApp.Workbooks;
                    var workbook = workbooks.Add(XlWBATemplate.xlWBATWorksheet);
                    var worksheet = (Worksheet)workbook.Sheets[1];

                    string title = "Quá trình khen thưởng " + maNhanVien;
                    worksheet.Cells[1, 1] = title;

                    var titleRange = worksheet.Range[worksheet.Cells[1, 1], worksheet.Cells[1, headers.Length]];
                    titleRange.Merge();
                    titleRange.HorizontalAlignment = XlHAlign.xlHAlignCenter;
                    titleRange.Font.Bold = true;
                    titleRange.Font.Size = 14;

                    for (int i = 0; i < headers.Length; i++)
                    {
                        worksheet.Cells[2, i + 1] = headers[i];
                    }

                    for (int i = 0; i < data.Count; i++)
                    {
                        for (int j = 0; j < data[i].Count; j++)
                        {
                            worksheet.Cells[i + 3, j + 1] = data[i][j];
                        }
                    }

                    var range = worksheet.Range[worksheet.Cells[2, 1], worksheet.Cells[data.Count + 2, headers.Length]];
                    range.Borders[XlBordersIndex.xlEdgeBottom].LineStyle = XlLineStyle.xlContinuous;
                    range.Borders[XlBordersIndex.xlEdgeTop].LineStyle = XlLineStyle.xlContinuous;
                    range.Borders[XlBordersIndex.xlEdgeLeft].LineStyle = XlLineStyle.xlContinuous;
                    range.Borders[XlBordersIndex.xlEdgeRight].LineStyle = XlLineStyle.xlContinuous;

                    range.Borders[XlBordersIndex.xlInsideHorizontal].LineStyle = XlLineStyle.xlContinuous;
                    range.Borders[XlBordersIndex.xlInsideVertical].LineStyle = XlLineStyle.xlContinuous;

                    worksheet.Columns.AutoFit();
                    worksheet.Rows.AutoFit();

                    worksheet.PageSetup.Orientation = XlPageOrientation.xlPortrait;
                    worksheet.PageSetup.PaperSize = XlPaperSize.xlPaperA4;

                    string selectedPrinter = comboBoxCTPrinters.SelectedItem.ToString();
                    excelApp.ActivePrinter = selectedPrinter;
                    worksheet.PrintOut();

                    //string pdfPath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.Desktop),
                    //            $"QuaTrinhKhenThuong{DateTime.Now:yyyyMMddHHmmss}.pdf");
                    //worksheet.ExportAsFixedFormat(Microsoft.Office.Interop.Excel.XlFixedFormatType.xlTypePDF, pdfPath);

                    workbook.Close(false);
                    Marshal.ReleaseComObject(workbook);
                    Marshal.ReleaseComObject(workbooks);
                    Marshal.ReleaseComObject(excelApp);

                    RJMessageBox.Show("Dữ liệu đã được in thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                catch (Exception ex)
                {
                    RJMessageBox.Show("Lỗi khi in: " + ex.Message, "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }
        private void btn_print_kl_Click(object sender, EventArgs e)
        {
            if (comboBoxKLPrinters.SelectedItem != null)
            {
                try
                {
                    Cursor.Current = Cursors.WaitCursor;

                    string[] headers = { "Ngày kỷ luật", "Số quyết định", "Nội dung", "Hình thức", "Lý do" };
                    var data = new List<List<string>>();

                    foreach (DataGridViewRow dgvRow in dgv_kyluat.Rows)
                    {
                        if (!dgvRow.IsNewRow)
                        {
                            data.Add(new List<string>
                            {
                                DateTime.TryParse(dgvRow.Cells["NgayKyLuat"].Value?.ToString(), out DateTime ngayKyLuat)
                                    ? ngayKyLuat.ToString("yyyy/MM/dd") : "",
                                dgvRow.Cells["SoQuyetDinhKL"].Value?.ToString() ?? "",
                                dgvRow.Cells["NoiDungKL"].Value?.ToString() ?? "",
                                dgvRow.Cells["HinhThucKL"].Value?.ToString() ?? "",
                                dgvRow.Cells["LyDoKL"].Value?.ToString() ?? ""
                            });
                        }
                    }

                    var excelApp = new Application();
                    var workbooks = excelApp.Workbooks;
                    var workbook = workbooks.Add(XlWBATemplate.xlWBATWorksheet);
                    var worksheet = (Worksheet)workbook.Sheets[1];

                    string title = "Quá trình kỷ luật " + maNhanVien;
                    worksheet.Cells[1, 1] = title;

                    var titleRange = worksheet.Range[worksheet.Cells[1, 1], worksheet.Cells[1, headers.Length]];
                    titleRange.Merge();
                    titleRange.HorizontalAlignment = XlHAlign.xlHAlignCenter;
                    titleRange.Font.Bold = true;
                    titleRange.Font.Size = 14;

                    for (int i = 0; i < headers.Length; i++)
                    {
                        worksheet.Cells[2, i + 1] = headers[i];
                    }

                    for (int i = 0; i < data.Count; i++)
                    {
                        for (int j = 0; j < data[i].Count; j++)
                        {
                            worksheet.Cells[i + 3, j + 1] = data[i][j];
                        }
                    }

                    var range = worksheet.Range[worksheet.Cells[2, 1], worksheet.Cells[data.Count + 2, headers.Length]];
                    range.Borders[XlBordersIndex.xlEdgeBottom].LineStyle = XlLineStyle.xlContinuous;
                    range.Borders[XlBordersIndex.xlEdgeTop].LineStyle = XlLineStyle.xlContinuous;
                    range.Borders[XlBordersIndex.xlEdgeLeft].LineStyle = XlLineStyle.xlContinuous;
                    range.Borders[XlBordersIndex.xlEdgeRight].LineStyle = XlLineStyle.xlContinuous;

                    range.Borders[XlBordersIndex.xlInsideHorizontal].LineStyle = XlLineStyle.xlContinuous;
                    range.Borders[XlBordersIndex.xlInsideVertical].LineStyle = XlLineStyle.xlContinuous;

                    worksheet.Columns.AutoFit();
                    worksheet.Rows.AutoFit();

                    worksheet.PageSetup.Orientation = XlPageOrientation.xlPortrait;
                    worksheet.PageSetup.PaperSize = XlPaperSize.xlPaperA4;

                    string selectedPrinter = comboBoxCTPrinters.SelectedItem.ToString();
                    excelApp.ActivePrinter = selectedPrinter;
                    worksheet.PrintOut();

                    //string pdfPath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.Desktop),
                    //            $"QuaTrinhKyLuat{DateTime.Now:yyyyMMddHHmmss}.pdf");
                    //worksheet.ExportAsFixedFormat(Microsoft.Office.Interop.Excel.XlFixedFormatType.xlTypePDF, pdfPath);

                    workbook.Close(false);
                    Marshal.ReleaseComObject(workbook);
                    Marshal.ReleaseComObject(workbooks);
                    Marshal.ReleaseComObject(excelApp);

                    RJMessageBox.Show("Dữ liệu đã được in thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                catch (Exception ex)
                {
                    RJMessageBox.Show("Lỗi khi in: " + ex.Message, "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }
        private void btn_print_dg_Click(object sender, EventArgs e)
        {
            if (comboBoxDGPrinters.SelectedItem != null)
            {
                try
                {
                    Cursor.Current = Cursors.WaitCursor;

                    string[] headers = { "Ngày đánh giá", "Nội dung", "Điểm đánh giá", "Xếp loại" };
                    var data = new List<List<string>>();

                    foreach (DataGridViewRow dgvRow in dgv_qt_danhgia.Rows)
                    {
                        if (!dgvRow.IsNewRow)
                        {
                            data.Add(new List<string>
                            {
                                DateTime.TryParse(dgvRow.Cells["NgayDanhGia"].Value?.ToString(), out DateTime ngayDanhGia)
                                    ? ngayDanhGia.ToString("yyyy/MM/dd") : "",
                                dgvRow.Cells["NoiDungDG"].Value?.ToString() ?? "",
                                dgvRow.Cells["DiemDanhGia"].Value?.ToString() ?? "",
                                dgvRow.Cells["XepLoaiDG"].Value?.ToString() ?? ""
                            });
                        }
                    }

                    var excelApp = new Application();
                    var workbooks = excelApp.Workbooks;
                    var workbook = workbooks.Add(XlWBATemplate.xlWBATWorksheet);
                    var worksheet = (Worksheet)workbook.Sheets[1];

                    string title = "Quá trình đánh giá " + maNhanVien;
                    worksheet.Cells[1, 1] = title;

                    var titleRange = worksheet.Range[worksheet.Cells[1, 1], worksheet.Cells[1, headers.Length]];
                    titleRange.Merge();
                    titleRange.HorizontalAlignment = XlHAlign.xlHAlignCenter;
                    titleRange.Font.Bold = true;
                    titleRange.Font.Size = 14;

                    for (int i = 0; i < headers.Length; i++)
                    {
                        worksheet.Cells[2, i + 1] = headers[i];
                    }

                    for (int i = 0; i < data.Count; i++)
                    {
                        for (int j = 0; j < data[i].Count; j++)
                        {
                            worksheet.Cells[i + 3, j + 1] = data[i][j];
                        }
                    }

                    var range = worksheet.Range[worksheet.Cells[2, 1], worksheet.Cells[data.Count + 2, headers.Length]];
                    range.Borders[XlBordersIndex.xlEdgeBottom].LineStyle = XlLineStyle.xlContinuous;
                    range.Borders[XlBordersIndex.xlEdgeTop].LineStyle = XlLineStyle.xlContinuous;
                    range.Borders[XlBordersIndex.xlEdgeLeft].LineStyle = XlLineStyle.xlContinuous;
                    range.Borders[XlBordersIndex.xlEdgeRight].LineStyle = XlLineStyle.xlContinuous;

                    range.Borders[XlBordersIndex.xlInsideHorizontal].LineStyle = XlLineStyle.xlContinuous;
                    range.Borders[XlBordersIndex.xlInsideVertical].LineStyle = XlLineStyle.xlContinuous;

                    worksheet.Columns.AutoFit();
                    worksheet.Rows.AutoFit();

                    worksheet.PageSetup.Orientation = XlPageOrientation.xlPortrait;
                    worksheet.PageSetup.PaperSize = XlPaperSize.xlPaperA4;

                    string selectedPrinter = comboBoxCTPrinters.SelectedItem.ToString();
                    excelApp.ActivePrinter = selectedPrinter;
                    worksheet.PrintOut();

                    //string pdfPath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.Desktop),
                    //            $"QuaTrinhDanhGia{DateTime.Now:yyyyMMddHHmmss}.pdf");
                    //worksheet.ExportAsFixedFormat(Microsoft.Office.Interop.Excel.XlFixedFormatType.xlTypePDF, pdfPath);

                    workbook.Close(false);
                    Marshal.ReleaseComObject(workbook);
                    Marshal.ReleaseComObject(workbooks);
                    Marshal.ReleaseComObject(excelApp);

                    RJMessageBox.Show("Dữ liệu đã được in thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                catch (Exception ex)
                {
                    RJMessageBox.Show("Lỗi khi in: " + ex.Message, "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }
        private void btn_print_dt_Click(object sender, EventArgs e)
        {
            if (comboBoxDTPrinters.SelectedItem != null)
            {
                try
                {
                    Cursor.Current = Cursors.WaitCursor;

                    string[] headers = { "Từ ngày", "Đến ngày", "Số quyết định", "Nội dung", "Hình thức" };
                    var data = new List<List<string>>();

                    foreach (DataGridViewRow dgvRow in dgv_qt_daotao.Rows)
                    {
                        if (!dgvRow.IsNewRow)
                        {
                            data.Add(new List<string>
                            {
                                DateTime.TryParse(dgvRow.Cells["TuNgayDT"].Value?.ToString(), out DateTime tuNgay)
                                    ? tuNgay.ToString("yyyy/MM/dd") : "",
                                DateTime.TryParse(dgvRow.Cells["DenNgayDT"].Value?.ToString(), out DateTime denNgay)
                                    ? denNgay.ToString("yyyy/MM/dd") : "",
                                dgvRow.Cells["SoQuyetDinhDT"].Value?.ToString() ?? "",
                                dgvRow.Cells["NoiDungDT"].Value?.ToString() ?? "",
                                dgvRow.Cells["HinhThucDT"].Value?.ToString() ?? ""
                            });
                        }
                    }

                    var excelApp = new Application();
                    var workbooks = excelApp.Workbooks;
                    var workbook = workbooks.Add(XlWBATemplate.xlWBATWorksheet);
                    var worksheet = (Worksheet)workbook.Sheets[1];

                    string title = "Quá trình đào tạo " + maNhanVien;
                    worksheet.Cells[1, 1] = title;

                    var titleRange = worksheet.Range[worksheet.Cells[1, 1], worksheet.Cells[1, headers.Length]];
                    titleRange.Merge();
                    titleRange.HorizontalAlignment = XlHAlign.xlHAlignCenter;
                    titleRange.Font.Bold = true;
                    titleRange.Font.Size = 14;

                    for (int i = 0; i < headers.Length; i++)
                    {
                        worksheet.Cells[2, i + 1] = headers[i];
                    }

                    for (int i = 0; i < data.Count; i++)
                    {
                        for (int j = 0; j < data[i].Count; j++)
                        {
                            worksheet.Cells[i + 3, j + 1] = data[i][j];
                        }
                    }

                    var range = worksheet.Range[worksheet.Cells[2, 1], worksheet.Cells[data.Count + 2, headers.Length]];
                    range.Borders[XlBordersIndex.xlEdgeBottom].LineStyle = XlLineStyle.xlContinuous;
                    range.Borders[XlBordersIndex.xlEdgeTop].LineStyle = XlLineStyle.xlContinuous;
                    range.Borders[XlBordersIndex.xlEdgeLeft].LineStyle = XlLineStyle.xlContinuous;
                    range.Borders[XlBordersIndex.xlEdgeRight].LineStyle = XlLineStyle.xlContinuous;

                    range.Borders[XlBordersIndex.xlInsideHorizontal].LineStyle = XlLineStyle.xlContinuous;
                    range.Borders[XlBordersIndex.xlInsideVertical].LineStyle = XlLineStyle.xlContinuous;

                    worksheet.Columns.AutoFit();
                    worksheet.Rows.AutoFit();

                    worksheet.PageSetup.Orientation = XlPageOrientation.xlPortrait;
                    worksheet.PageSetup.PaperSize = XlPaperSize.xlPaperA4;

                    string selectedPrinter = comboBoxCTPrinters.SelectedItem.ToString();
                    excelApp.ActivePrinter = selectedPrinter;
                    worksheet.PrintOut();

                    //string pdfPath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.Desktop),
                    //            $"QuaTrinhDaoTao{DateTime.Now:yyyyMMddHHmmss}.pdf");
                    //worksheet.ExportAsFixedFormat(Microsoft.Office.Interop.Excel.XlFixedFormatType.xlTypePDF, pdfPath);

                    workbook.Close(false);
                    Marshal.ReleaseComObject(workbook);
                    Marshal.ReleaseComObject(workbooks);
                    Marshal.ReleaseComObject(excelApp);

                    Cursor.Current = Cursors.Default;
                    RJMessageBox.Show("Dữ liệu đã được in thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                catch (Exception ex)
                {
                    Cursor.Current = Cursors.Default;
                    RJMessageBox.Show("Lỗi khi in: " + ex.Message, "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }
        private void btn_print_nv_Click(object sender, EventArgs e)
        {
            if (comboBoxNVPrinters.SelectedItem != null)
            {
                try
                {
                    Cursor.Current = Cursors.WaitCursor;

                    string[] headers = { "Từ ngày", "Đến ngày", "Ngày quyết định", "Số quyết định", "Nội dung", "Loại nghỉ việc" };
                    var data = new List<List<string>>();

                    foreach (DataGridViewRow dgvRow in dgv_qt_nghiviec.Rows)
                    {
                        if (!dgvRow.IsNewRow)
                        {
                            data.Add(new List<string>
                        {
                            DateTime.TryParse(dgvRow.Cells["TuNgayNV"].Value?.ToString(), out DateTime tuNgay)
                                ? tuNgay.ToString("yyyy/MM/dd") : "",
                            DateTime.TryParse(dgvRow.Cells["DenNgayNV"].Value?.ToString(), out DateTime denNgay)
                                ? denNgay.ToString("yyyy/MM/dd") : "",
                            DateTime.TryParse(dgvRow.Cells["NgayQuyetDinhNV"].Value?.ToString(), out DateTime ngayQuyetDinh)
                                ? ngayQuyetDinh.ToString("yyyy/MM/dd") : "",
                            dgvRow.Cells["SoQuyetDinhNV"].Value?.ToString() ?? "",
                            dgvRow.Cells["NoiDungNV"].Value?.ToString() ?? "",
                            dgvRow.Cells["LoaiNghiViec"].Value?.ToString() ?? ""
                        });
                        }
                    }

                    var excelApp = new Application();
                    var workbooks = excelApp.Workbooks;
                    var workbook = workbooks.Add(XlWBATemplate.xlWBATWorksheet);
                    var worksheet = (Worksheet)workbook.Sheets[1];

                    string title = "Quá trình nghỉ việc " + maNhanVien;
                    worksheet.Cells[1, 1] = title;

                    var titleRange = worksheet.Range[worksheet.Cells[1, 1], worksheet.Cells[1, headers.Length]];
                    titleRange.Merge();
                    titleRange.HorizontalAlignment = XlHAlign.xlHAlignCenter;
                    titleRange.Font.Bold = true;
                    titleRange.Font.Size = 14;

                    for (int i = 0; i < headers.Length; i++)
                    {
                        worksheet.Cells[2, i + 1] = headers[i];
                    }

                    for (int i = 0; i < data.Count; i++)
                    {
                        for (int j = 0; j < data[i].Count; j++)
                        {
                            worksheet.Cells[i + 3, j + 1] = data[i][j];
                        }
                    }

                    var range = worksheet.Range[worksheet.Cells[2, 1], worksheet.Cells[data.Count + 2, headers.Length]];
                    range.Borders[XlBordersIndex.xlEdgeBottom].LineStyle = XlLineStyle.xlContinuous;
                    range.Borders[XlBordersIndex.xlEdgeTop].LineStyle = XlLineStyle.xlContinuous;
                    range.Borders[XlBordersIndex.xlEdgeLeft].LineStyle = XlLineStyle.xlContinuous;
                    range.Borders[XlBordersIndex.xlEdgeRight].LineStyle = XlLineStyle.xlContinuous;

                    range.Borders[XlBordersIndex.xlInsideHorizontal].LineStyle = XlLineStyle.xlContinuous;
                    range.Borders[XlBordersIndex.xlInsideVertical].LineStyle = XlLineStyle.xlContinuous;

                    worksheet.Columns.AutoFit();
                    worksheet.Rows.AutoFit();

                    worksheet.PageSetup.Orientation = XlPageOrientation.xlPortrait;
                    worksheet.PageSetup.PaperSize = XlPaperSize.xlPaperA4;

                    string selectedPrinter = comboBoxCTPrinters.SelectedItem.ToString();
                    excelApp.ActivePrinter = selectedPrinter;
                    worksheet.PrintOut();

                    workbook.Close(false);
                    Marshal.ReleaseComObject(workbook);
                    Marshal.ReleaseComObject(workbooks);
                    Marshal.ReleaseComObject(excelApp);

                    Cursor.Current = Cursors.Default;
                    RJMessageBox.Show("Dữ liệu đã được in thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                catch (Exception ex)
                {
                    Cursor.Current = Cursors.Default;
                    RJMessageBox.Show("Lỗi khi in: " + ex.Message, "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }
        private void btn_print_ts_Click(object sender, EventArgs e)
        {
            if (comboBoxTSPrinters.SelectedItem != null)
            {
                try
                {
                    Cursor.Current = Cursors.WaitCursor;

                    string[] headers = { "Từ ngày", "Đến ngày", "Ghi chú" };
                    var data = new List<List<string>>();

                    foreach (DataGridViewRow dgvRow in dgv_thaisai.Rows)
                    {
                        if (!dgvRow.IsNewRow)
                        {
                            data.Add(new List<string>
                            {
                                DateTime.TryParse(dgvRow.Cells["TuNgayTS"].Value?.ToString(), out DateTime tuNgayTS)
                                    ? tuNgayTS.ToString("yyyy/MM/dd") : "",
                                DateTime.TryParse(dgvRow.Cells["DenNgayTS"].Value?.ToString(), out DateTime denNgayTS)
                                    ? denNgayTS.ToString("yyyy/MM/dd") : "",
                                dgvRow.Cells["GhiChuTS"].Value?.ToString() ?? ""
                            });
                        }
                    }

                    var excelApp = new Application();
                    var workbooks = excelApp.Workbooks;
                    var workbook = workbooks.Add(XlWBATemplate.xlWBATWorksheet);
                    var worksheet = (Worksheet)workbook.Sheets[1];

                    string title = "Quá trình thai sản " + maNhanVien;
                    worksheet.Cells[1, 1] = title;

                    var titleRange = worksheet.Range[worksheet.Cells[1, 1], worksheet.Cells[1, headers.Length]];
                    titleRange.Merge();
                    titleRange.HorizontalAlignment = XlHAlign.xlHAlignCenter;
                    titleRange.Font.Bold = true;
                    titleRange.Font.Size = 14;

                    for (int i = 0; i < headers.Length; i++)
                    {
                        worksheet.Cells[2, i + 1] = headers[i];
                    }

                    for (int i = 0; i < data.Count; i++)
                    {
                        for (int j = 0; j < data[i].Count; j++)
                        {
                            worksheet.Cells[i + 3, j + 1] = data[i][j];
                        }
                    }

                    var range = worksheet.Range[worksheet.Cells[2, 1], worksheet.Cells[data.Count + 2, headers.Length]];
                    range.Borders[XlBordersIndex.xlEdgeBottom].LineStyle = XlLineStyle.xlContinuous;
                    range.Borders[XlBordersIndex.xlEdgeTop].LineStyle = XlLineStyle.xlContinuous;
                    range.Borders[XlBordersIndex.xlEdgeLeft].LineStyle = XlLineStyle.xlContinuous;
                    range.Borders[XlBordersIndex.xlEdgeRight].LineStyle = XlLineStyle.xlContinuous;

                    range.Borders[XlBordersIndex.xlInsideHorizontal].LineStyle = XlLineStyle.xlContinuous;
                    range.Borders[XlBordersIndex.xlInsideVertical].LineStyle = XlLineStyle.xlContinuous;

                    worksheet.Columns.AutoFit();
                    worksheet.Rows.AutoFit();

                    worksheet.PageSetup.Orientation = XlPageOrientation.xlPortrait;
                    worksheet.PageSetup.PaperSize = XlPaperSize.xlPaperA4;

                    string selectedPrinter = comboBoxCTPrinters.SelectedItem.ToString();
                    excelApp.ActivePrinter = selectedPrinter;
                    worksheet.PrintOut();

                    //string pdfPath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.Desktop),
                    //            $"QuaTrinhThaiSan{DateTime.Now:yyyyMMddHHmmss}.pdf");
                    //worksheet.ExportAsFixedFormat(Microsoft.Office.Interop.Excel.XlFixedFormatType.xlTypePDF, pdfPath);

                    workbook.Close(false);
                    Marshal.ReleaseComObject(workbook);
                    Marshal.ReleaseComObject(workbooks);
                    Marshal.ReleaseComObject(excelApp);

                    Cursor.Current = Cursors.Default;
                    RJMessageBox.Show("Dữ liệu đã được in thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                catch (Exception ex)
                {
                    Cursor.Current = Cursors.Default;
                    RJMessageBox.Show("Lỗi khi in: " + ex.Message, "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }
        private void btn_print_tn_Click(object sender, EventArgs e)
        {
            if (comboBoxTNPrinters.SelectedItem != null)
            {
                try
                {
                    Cursor.Current = Cursors.WaitCursor;

                    string[] headers = { "Loại tai nạn", "Mức độ", "Ngày diễn ra", "Nơi diễn ra", "Nội dung" };
                    var data = new List<List<string>>();

                    foreach (DataGridViewRow dgvRow in dgv_tainan.Rows)
                    {
                        if (!dgvRow.IsNewRow)
                        {
                            data.Add(new List<string>
                            {
                                dgvRow.Cells["LoaiTaiNan"].Value?.ToString() ?? "",
                                dgvRow.Cells["MucDoTN"].Value?.ToString() ?? "",
                                DateTime.TryParse(dgvRow.Cells["NgayDienRaTN"].Value?.ToString(), out DateTime ngayDienRa)
                                    ? ngayDienRa.ToString("yyyy/MM/dd") : "",
                                dgvRow.Cells["NoiDienRaTN"].Value?.ToString() ?? "",
                                dgvRow.Cells["NoiDungTN"].Value?.ToString() ?? ""
                            });
                        }
                    }

                    var excelApp = new Application();
                    var workbooks = excelApp.Workbooks;
                    var workbook = workbooks.Add(XlWBATemplate.xlWBATWorksheet);
                    var worksheet = (Worksheet)workbook.Sheets[1];

                    string title = "Quá trình tai nạn " + maNhanVien;
                    worksheet.Cells[1, 1] = title;

                    var titleRange = worksheet.Range[worksheet.Cells[1, 1], worksheet.Cells[1, headers.Length]];
                    titleRange.Merge();
                    titleRange.HorizontalAlignment = XlHAlign.xlHAlignCenter;
                    titleRange.Font.Bold = true;
                    titleRange.Font.Size = 14;

                    for (int i = 0; i < headers.Length; i++)
                    {
                        worksheet.Cells[2, i + 1] = headers[i];
                    }

                    for (int i = 0; i < data.Count; i++)
                    {
                        for (int j = 0; j < data[i].Count; j++)
                        {
                            worksheet.Cells[i + 3, j + 1] = data[i][j];
                        }
                    }

                    var range = worksheet.Range[worksheet.Cells[2, 1], worksheet.Cells[data.Count + 2, headers.Length]];
                    range.Borders[XlBordersIndex.xlEdgeBottom].LineStyle = XlLineStyle.xlContinuous;
                    range.Borders[XlBordersIndex.xlEdgeTop].LineStyle = XlLineStyle.xlContinuous;
                    range.Borders[XlBordersIndex.xlEdgeLeft].LineStyle = XlLineStyle.xlContinuous;
                    range.Borders[XlBordersIndex.xlEdgeRight].LineStyle = XlLineStyle.xlContinuous;

                    range.Borders[XlBordersIndex.xlInsideHorizontal].LineStyle = XlLineStyle.xlContinuous;
                    range.Borders[XlBordersIndex.xlInsideVertical].LineStyle = XlLineStyle.xlContinuous;

                    worksheet.Columns.AutoFit();
                    worksheet.Rows.AutoFit();

                    worksheet.PageSetup.Orientation = XlPageOrientation.xlPortrait;
                    worksheet.PageSetup.PaperSize = XlPaperSize.xlPaperA4;

                    string selectedPrinter = comboBoxCTPrinters.SelectedItem.ToString();
                    excelApp.ActivePrinter = selectedPrinter;
                    worksheet.PrintOut();

                    //string pdfPath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.Desktop),
                    //            $"QuaTrinhTaiNan{DateTime.Now:yyyyMMddHHmmss}.pdf");
                    //worksheet.ExportAsFixedFormat(Microsoft.Office.Interop.Excel.XlFixedFormatType.xlTypePDF, pdfPath);

                    workbook.Close(false);
                    Marshal.ReleaseComObject(workbook);
                    Marshal.ReleaseComObject(workbooks);
                    Marshal.ReleaseComObject(excelApp);

                    Cursor.Current = Cursors.Default;
                    RJMessageBox.Show("Dữ liệu đã được in thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                catch (Exception ex)
                {
                    Cursor.Current = Cursors.Default;
                    RJMessageBox.Show("Lỗi khi in: " + ex.Message, "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void dgv_NhanVien_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            LoadData();
        }
    }
}