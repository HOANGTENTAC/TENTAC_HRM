using NPOI.HSSF.Util;
using System;
using System.Data;
using System.IO;
using System.Linq;
using System.Windows.Forms;
using TENTAC_HRM.Common;
using TENTAC_HRM.Custom;
using HorizontalAlignment = NPOI.SS.UserModel.HorizontalAlignment;

namespace TENTAC_HRM.Forms.NghiPhep
{
    public partial class Frm_NghiPhep : Form
    {
        DataProvider provider = new DataProvider();
        public static Frm_NghiPhep _instance;
        public string _manhanvien { get; set; }
        public string _year { get; set; }
        public string _month { get; set; }
        public bool _xemtong { get; set; }
        public string _trangthai { get; set; }
        public int[] idPermision { get; set; }
        public int _idTrangThaiPhieu { get; set; }
        public static Frm_NghiPhep Instance(int[] permissions)
        {
            _instance = new Frm_NghiPhep(permissions);
            return _instance;
        }
        public Frm_NghiPhep(int[] permissions)
        {
            idPermision = permissions;
            InitializeComponent();
            //VisibleButton();
            cbo_trangthai.ComboBox.SelectionChangeCommitted += cbo_trangthai_SelectionChangeCommitted;
            cbo_year.ComboBox.SelectionChangeCommitted += cbo_year_SelectionChangeCommitted1;
            cbo_Thang.ComboBox.SelectionChangeCommitted += cbo_month_SelectionChangeCommitted1;
            //load_data();
            //if (LoginInfo.LoaiUser == "NhanVien")
            //{
            //    edit_column.Visible = true;
            //    edit_columnquanly.Visible = false;
            //}
            //else
            //{
            //    edit_column.Visible = false;
            //    edit_columnquanly.Visible = true;
            //}
        }
        private bool CheckReportTo()
        {
            bool flg = false;
            if (dgv_annual_leave.CurrentRow.Cells["NguoiXacNhan"].Value.ToString().Contains(SQLHelper.sUser) && dgv_annual_leave.CurrentRow.Cells["ReportToReportTo"].Value.ToString() != "")
            {
                _idTrangThaiPhieu = 197;
                flg = true;
            }
            else if (dgv_annual_leave.CurrentRow.Cells["ReportToReportTo"].Value.ToString().Contains(SQLHelper.sUser) && dgv_annual_leave.CurrentRow.Cells["NguoiXacNhan"].Value.ToString() != "")
            {
                _idTrangThaiPhieu = 199;
                flg = true;
            }
            else if (dgv_annual_leave.CurrentRow.Cells["ReportToReportTo"].Value.ToString() == "" && dgv_annual_leave.CurrentRow.Cells["NguoiXacNhan"].Value.ToString().Contains(SQLHelper.sUser))
            {
                _idTrangThaiPhieu = 199;
                flg = true;
            }
            return flg;
        }
        private void VisibleButton()
        {
            btn_add.Visible = idPermision.Contains(2) ? true : false;
            btn_delete.Visible = idPermision.Contains(4) ? true : false;
        }
        private void cbo_year_SelectionChangeCommitted1(object sender, EventArgs e)
        {
            _trangthai = "";
            _xemtong = false;
            _manhanvien = "";
            _year = "";
            _month = "";
            load_data();
        }
        private void cbo_month_SelectionChangeCommitted1(object sender, EventArgs e)
        {
            _trangthai = "";
            _xemtong = false;
            _manhanvien = "";
            _year = "";
            _month = "";
            load_data();
        }
        private void cbo_trangthai_SelectionChangeCommitted(object sender, EventArgs e)
        {
            _trangthai = "";
            _xemtong = false;
            _manhanvien = "";
            _year = "";
            _month = "";
            load_data();
        }

        public void uc_nghiphep_Load(object sender, EventArgs e)
        {
            load_trangthai();
            LoadMonth();
            load_year();
            load_data();
        }

        private void load_trangthai()
        {
            DataTable datatable = new DataTable();
            datatable = provider.load_all_type(196);
            cbo_trangthai.ComboBox.DataSource = datatable;
            cbo_trangthai.ComboBox.DisplayMember = "name";
            cbo_trangthai.ComboBox.ValueMember = "id";
            cbo_trangthai.ComboBox.SelectedValue = !string.IsNullOrEmpty(_trangthai) ? int.Parse(_trangthai) : 0;
        }

        private void load_year()
        {
            DataTable datatable = new DataTable();
            datatable.Columns.Add("id");
            datatable.Columns.Add("name");
            for (int i = 2010; i < DateTime.Now.Year + 2; i++)
            {
                datatable.Rows.Add(i, i);
            }
            cbo_year.ComboBox.DataSource = datatable;
            cbo_year.ComboBox.DisplayMember = "name";
            cbo_year.ComboBox.ValueMember = "id";
            cbo_year.ComboBox.SelectedValue = !string.IsNullOrEmpty(_year) ? int.Parse(_year) : DateTime.Now.Year;
        }
        private void LoadMonth()
        {
            DataTable datatable = new DataTable();
            datatable.Columns.Add("id");
            datatable.Columns.Add("name");
            for (int i = 1; i <= 12; i++)
            {
                datatable.Rows.Add(i, i);
            }
            cbo_Thang.ComboBox.DataSource = datatable;
            cbo_Thang.ComboBox.DisplayMember = "name";
            cbo_Thang.ComboBox.ValueMember = "id";
            cbo_Thang.ComboBox.SelectedValue = !string.IsNullOrEmpty(_month) ? int.Parse(_month) : DateTime.Now.Month;
        }
        public void load_data()
        {
            //if (!string.IsNullOrEmpty(_trangthai))
            //{
            //    cbo_trangthai.ComboBox.SelectedIndex = 2;
            //}
            if (_xemtong == true)
            {
                chk_TheoNam.Checked = true;
            }
            if (_manhanvien != "")
            {
                txt_search.Text = _manhanvien;
            }
            //if (!string.IsNullOrEmpty(_year))
            //{
            //    cbo_year.ComboBox.SelectedValue = _year;
            //}
            //if (!string.IsNullOrEmpty(_month))
            //{
            //    cbo_Thang.ComboBox.SelectedValue = _month;
            //}
            //string sql = "select f.id,a.MaNhanVien,a.TenNhanVien,d.TenKhuVuc,c.TenChucVu," +
            //            "e.typename as TrangThai,f.NgayNghi," +
            //            "case when f.NuaNgay = 0 then N'1 ngày' else case when f.NuaNgay = 1 then N'Nghỉ buổi sáng' else N'Nghỉ buổi chiều' end end NuaNgay," +
            //            "g.LoaiPhep,f.GhiChu,f.SoNgay,a.MaChucVu, h.TypeName as TrangThaiPhieu " +
            //            "from MITACOSQL.dbo.NhanVien a " +
            //            "join tbl_NhanVien b on a.MaNhanVien = b.MaNhanVien " +
            //            //"join nhanvien_phongban b on a.manhanvien = b.ma_nhan_vien and is_active = 1 " +
            //            "join MITACOSQL.dbo.CHUCVU c on c.MachucVu = a.MaChucVu " +
            //            "join MITACOSQL.dbo.KHUVUC d on d.MaKhuVuc = a.MaKhuVuc " +
            //            "join sys_AllType e on b.id_trangthai = e.typeid " +
            //            "join tbl_NghiPhepNam f on f.MaChamCong = a.MaChamCong " +
            //            "join mst_LoaiPhep g on g.MaLoaiPhep = f.LoaiPhepNghi " +
            //            "left join sys_AllType h on f.Id_TrangThai = h.TypeId " +
            //            $"where f.nam = '{cbo_year.ComboBox.SelectedValue.ToString()}' and f.del_flg = 0 ";
            //if (txt_search.Text != "")
            //{
            //    sql += $" and a.MaNhanVien = '{txt_search.Text}'";
            //}
            //else if (cbo_trangthai.ComboBox.SelectedValue.ToString() == "2")
            //{
            //    sql = sql + " and chk_quanly = 1 and chk_nhansu = 0";
            //}
            //else if (cbo_trangthai.ComboBox.SelectedValue.ToString() == "3")
            //{
            //    sql = sql + " and chk_quanly = 1 and chk_nhansu = 1";
            //}

            string search = "";
            if (!string.IsNullOrEmpty(txt_search.Text))
            {
                search += $" and (MaNhanVien like '%{txt_search.Text}%' or TenNhanVien like '%{txt_search.Text}%') ";
            }
            if (cbo_trangthai.ComboBox.SelectedValue.ToString() != "0")
            {
                search += $" and IDTrangThai = '{cbo_trangthai.ComboBox.SelectedValue}' ";
            }
            //_trangthai = cbo_trangthai.SelectedIndex > 0 ? cbo_trangthai.ComboBox.SelectedValue.ToString() : "0";
            //_year = string.IsNullOrEmpty(cbo_year.Text) ? DateTime.Now.Year.ToString() : cbo_year.Text;
            //_month = string.IsNullOrEmpty(cbo_Thang.Text) ? DateTime.Now.Month.ToString() : cbo_Thang.Text;
            string sql = string.Empty;
            sql = $@"WITH CTE_NhanVien AS (
                    SELECT f.id, a.MaNhanVien, a.TenNhanVien, d.TenKhuVuc, c.TenChucVu, e.typename AS TrangThai, f.NgayNghi,
                        CASE 
                            WHEN f.NuaNgay = 0 THEN N'1 ngày' 
                            ELSE 
                                CASE 
                                    WHEN f.NuaNgay = 1 THEN N'Nghỉ buổi sáng' 
                                    ELSE N'Nghỉ buổi chiều' 
                                END 
                        END AS NuaNgay,
                        g.KyHieu, f.GhiChu, f.SoNgay, a.MaChucVu, h.TypeId AS IDTrangThai, h.TypeName AS TrangThaiPhieu, f.NguoiXacNhan, i.ReportTo as ReportToReportTo
                    FROM MITACOSQL.dbo.NhanVien a
                    JOIN tbl_NhanVien b ON a.MaNhanVien = b.MaNhanVien
                    LEFT JOIN MITACOSQL.dbo.CHUCVU c ON c.MachucVu = a.MaChucVu
                    JOIN MITACOSQL.dbo.KHUVUC d ON d.MaKhuVuc = a.MaKhuVuc
                    JOIN sys_AllType e ON b.id_trangthai = e.typeid
                    JOIN tbl_NghiPhepNam f ON f.MaNhanVien = a.MaNhanVien
                    JOIN mst_LoaiPhep g ON g.MaLoaiPhep = f.LoaiPhepNghi
                    LEFT JOIN tbl_NhanVien i ON f.MaNhanVien = i.MaNhanVien
                    LEFT JOIN sys_AllType h ON f.Id_TrangThai = h.TypeId
                    WHERE f.nam = {cbo_year.Text} AND f.del_flg = 0 " +
                    (chk_TheoNam.Checked == false ? $" and month(f.NgayNghi) = {cbo_Thang.Text} " : "") +
                $@")
                SELECT Id, MaNhanVien, TenNhanVien, TenKhuVuc, TenChucVu, TrangThai, NgayNghi, NuaNgay, KyHieu, SoNgay, MaChucVu,
                IDTrangThai, TrangThaiPhieu, NguoiXacNhan, ReportToReportTo
                FROM CTE_NhanVien
                WHERE (MaNhanVien = {SQLHelper.rpStr(SQLHelper.sUser)} OR NguoiXacNhan = {SQLHelper.rpStr(SQLHelper.sUser)} OR ReportToReportTo = {SQLHelper.rpStr(SQLHelper.sUser)}) " +
                search;
            dgv_annual_leave.DataSource = SQLHelper.ExecuteDt(sql);
        }

        private void btn_add_Click(object sender, EventArgs e)
        {
            frm_annual_leave frm = new frm_annual_leave(this.idPermision);
            frm.edit = false;
            frm.ShowDialog();
        }

        private void dgv_annual_leave_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dgv_annual_leave.CurrentCell.OwningColumn.Name == "edit_column")
            {
                if (dgv_annual_leave.CurrentRow.Cells["IDTrangThaiP"].Value.ToString().Contains("199"))
                {
                    return;
                }
                if (!CheckReportTo())
                {
                    frm_annual_leave frm = new frm_annual_leave(this.idPermision);
                    frm.edit = true;
                    frm._id_nghi_phep_value = int.Parse(dgv_annual_leave.CurrentRow.Cells["id"].Value.ToString());
                    frm._ma_nhan_vien = dgv_annual_leave.CurrentRow.Cells["MaNhanVien"].Value.ToString();
                    frm._id_trangthai = int.Parse(dgv_annual_leave.CurrentRow.Cells["IDTrangThaiP"].Value.ToString());
                    frm.ShowDialog();
                }
                else
                {
                    frm_QuanLyXacNhan frm = new frm_QuanLyXacNhan();
                    frm._id = int.Parse(dgv_annual_leave.CurrentRow.Cells["id"].Value.ToString());
                    frm._idTrangThai = _idTrangThaiPhieu;
                    frm._year = cbo_year.ComboBox.SelectedValue.ToString();
                    frm.ShowDialog();
                }
            }
        }
        private void btn_close_Click(object sender, EventArgs e)
        {
            Control x = this.Parent;
            TabControl tab = (TabControl)x.Parent.Parent;
            tab.TabPages.Remove(tab.SelectedTab);
        }
        private void btn_delete_Click(object sender, EventArgs e)
        {
            try
            {
                DialogResult result = RJMessageBox.Show("Bạn có chác muốn xóa?", "Thông báo", MessageBoxButtons.YesNo);
                if (result == DialogResult.Yes)
                {
                    string sql = string.Format("update tbl_NghiPhepNam set del_flg = 1 , NguoiTao = '{1}' where id = '{0}'", dgv_annual_leave.CurrentRow.Cells["id"].Value, SQLHelper.sIdUser);
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

        private void btn_Search_Click(object sender, EventArgs e)
        {
            _trangthai = "";
            _xemtong = false;
            _manhanvien = "";
            _year = "";
            _month = "";
            load_data();
        }

        private void btn_Excel_Click(object sender, EventArgs e)
        {
            Cursor.Current = Cursors.WaitCursor;
            var workPath = $@"{Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData)}\template_work_excel.xlsx";
            if (File.Exists(workPath))
            {
                File.Delete(workPath);
            }
            try
            {
                var xlsBook = new XlsWorkBook(workPath);
                var style_color = xlsBook.GeCellStyleAlignment(HorizontalAlignment.Left, HSSFColor.BlueGrey.Index, fontHeight: 11);
                var style_detal = xlsBook.GeCellStyleAlignment(HorizontalAlignment.Left, fontHeight: 11);
                var xlsSheet = xlsBook.Sheet(0);

                xlsSheet.SetColumnWidth(0, 900);
                xlsSheet.SetColumnWidth(1, 3000);
                xlsSheet.SetColumnWidth(2, 5000);
                xlsSheet.SetColumnWidth(3, 2500);
                xlsSheet.SetColumnWidth(4, 3000);
                xlsSheet.SetColumnWidth(5, 1800);
                xlsSheet.SetColumnWidth(6, 2200);

                xlsSheet.Cell(0, 0).SetValue("Stt");
                xlsSheet.Cell(0, 0).SetStyle(style_color);
                xlsSheet.Cell(0, 1).SetValue("Mã nhân viên");
                xlsSheet.Cell(0, 1).SetStyle(style_color);
                xlsSheet.Cell(0, 2).SetValue("Tên nhân viên");
                xlsSheet.Cell(0, 2).SetStyle(style_color);
                xlsSheet.Cell(0, 3).SetValue("Phòng ban");
                xlsSheet.Cell(0, 3).SetStyle(style_color);
                xlsSheet.Cell(0, 4).SetValue("Ngày nghỉ");
                xlsSheet.Cell(0, 4).SetStyle(style_color);
                xlsSheet.Cell(0, 5).SetValue("Số ngày");
                xlsSheet.Cell(0, 5).SetStyle(style_color);
                xlsSheet.Cell(0, 6).SetValue("Loại phép");
                xlsSheet.Cell(0, 6).SetStyle(style_color);

                int index = 1;
                foreach (DataGridViewRow item in dgv_annual_leave.Rows)
                {
                    xlsSheet.Cell(index, 0).SetValue(index);
                    xlsSheet.Cell(index, 0).SetStyle(style_detal);
                    xlsSheet.Cell(index, 1).SetValue(item.Cells["MaNhanVien"].Value.ToString());
                    xlsSheet.Cell(index, 1).SetStyle(style_detal);
                    xlsSheet.Cell(index, 2).SetValue(item.Cells["TenNhanVien"].Value.ToString());
                    xlsSheet.Cell(index, 2).SetStyle(style_detal);
                    xlsSheet.Cell(index, 3).SetValue(item.Cells["TenKhuVuc"].Value.ToString());
                    xlsSheet.Cell(index, 3).SetStyle(style_detal);
                    xlsSheet.Cell(index, 4).SetValue(DateTime.Parse(item.Cells["NgayNghi"].Value.ToString()).ToString("dd/MM/yyyy"));
                    xlsSheet.Cell(index, 4).SetStyle(style_detal);
                    xlsSheet.Cell(index, 5).SetValue(item.Cells["SoNgay"].Value.ToString());
                    xlsSheet.Cell(index, 5).SetStyle(style_detal);
                    xlsSheet.Cell(index, 6).SetValue(item.Cells["LoaiPhep"].Value.ToString());
                    xlsSheet.Cell(index, 6).SetStyle(style_detal);

                    index++;
                }
                xlsBook.SetSheetName(0, "Nghỉ phép");
                if (!Directory.Exists(Environment.GetFolderPath(Environment.SpecialFolder.Desktop))) Directory.CreateDirectory(Environment.GetFolderPath(Environment.SpecialFolder.Desktop));

                // 保存
                xlsBook.Save($@"{Environment.GetFolderPath(Environment.SpecialFolder.Desktop)}\DanhSachNghiPhepThang_" + cbo_Thang.ComboBox.Text + "_" + cbo_year.ComboBox.Text + ".xlsx");

                // ワークファイル削除
                File.Delete(workPath);

                RJMessageBox.Show("Xuất excel thành công \n" + $@"{Environment.GetFolderPath(Environment.SpecialFolder.Desktop)}\DanhSachNghiPhepThang_" + cbo_Thang.ComboBox.Text + "_" + cbo_year.ComboBox.Text + ".xlsx", "Thông báo");
            }
            catch (Exception ex)
            {
                RJMessageBox.Show(ex.Message, "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            Cursor.Current = Cursors.Default;
        }

        private void cbo_trangthai_SelectedIndexChanged(object sender, EventArgs e)
        {
            //load_data();
        }
    }
}
