using NPOI.HSSF.Util;
using System;
using System.Data;
using System.IO;
using System.Linq;
using System.Windows.Forms;
using TENTAC_HRM.Common;
using TENTAC_HRM.Consts;
using TENTAC_HRM.Custom;
using HorizontalAlignment = NPOI.SS.UserModel.HorizontalAlignment;

namespace TENTAC_HRM.Forms.NghiPhep
{
    public partial class Frm_NghiPhep : Form
    {
        readonly DataProvider provider = new DataProvider();
        public string Manhanvien { get; set; }
        public string Year { get; set; }
        public string Month { get; set; }
        public bool Xemtong { get; set; }
        public string Trangthai { get; set; }
        public int[] IdPermision { get; set; }
        public int IdTrangThaiPhieu { get; set; }

        public Frm_NghiPhep(int[] permissions = null)
        {
            IdPermision = permissions;
            InitializeComponent();
            cbo_trangthai.ComboBox.SelectionChangeCommitted += cbo_trangthai_SelectionChangeCommitted;
            cbo_year.ComboBox.SelectionChangeCommitted += cbo_year_SelectionChangeCommitted1;
            cbo_Thang.ComboBox.SelectionChangeCommitted += cbo_month_SelectionChangeCommitted1;
            //if (IdPermision.Contains(2) || LoginInfo.Group == "ADMIN")
            //{
            //    btn_add.Visible = true;
            //}
            //if (IdPermision.Contains(4) || LoginInfo.Group == "ADMIN")
            //{
            //    btn_delete.Visible = true;
            //}
            //if (IdPermision.Contains(3) || LoginInfo.Group == "ADMIN")
            //{
            //    edit_column.Visible = true;
            //}
        }

        private bool CheckReportTo()
        {
            bool flg = false;
            if (dgv_annual_leave.CurrentRow.Cells["NguoiXacNhan"].Value.ToString().Contains(SQLHelper.sUser) && dgv_annual_leave.CurrentRow.Cells["ReportToReportTo"].Value.ToString() != "")
            {
                IdTrangThaiPhieu = 197;
                flg = true;
            }
            else if (dgv_annual_leave.CurrentRow.Cells["ReportToReportTo"].Value.ToString().Contains(SQLHelper.sUser) && dgv_annual_leave.CurrentRow.Cells["NguoiXacNhan"].Value.ToString() != "")
            {
                IdTrangThaiPhieu = 199;
                flg = true;
            }
            else if (dgv_annual_leave.CurrentRow.Cells["ReportToReportTo"].Value.ToString() == "" && dgv_annual_leave.CurrentRow.Cells["NguoiXacNhan"].Value.ToString().Contains(SQLHelper.sUser))
            {
                IdTrangThaiPhieu = 199;
                flg = true;
            }
            return flg;
        }

        private void cbo_year_SelectionChangeCommitted1(object sender, EventArgs e)
        {
            Trangthai = "";
            Xemtong = false;
            Manhanvien = "";
            Year = "";
            Month = "";
            Load_data();
        }

        private void cbo_month_SelectionChangeCommitted1(object sender, EventArgs e)
        {
            Trangthai = "";
            Xemtong = false;
            Manhanvien = "";
            Year = "";
            Month = "";
            Load_data();
        }

        private void cbo_trangthai_SelectionChangeCommitted(object sender, EventArgs e)
        {
            Trangthai = "";
            Xemtong = false;
            Manhanvien = "";
            Year = "";
            Month = "";
            Load_data();
        }

        public void uc_nghiphep_Load(object sender, EventArgs e)
        {
            Load_trangthai();
            LoadMonth();
            Load_year();
            Load_data();
        }

        private void Load_trangthai()
        {
            DataTable datatable = provider.load_all_type(196);
            cbo_trangthai.ComboBox.DataSource = datatable;
            cbo_trangthai.ComboBox.DisplayMember = "name";
            cbo_trangthai.ComboBox.ValueMember = "id";
            cbo_trangthai.ComboBox.SelectedValue = !string.IsNullOrEmpty(Trangthai) ? int.Parse(Trangthai) : 0;
        }

        private void Load_year()
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
            cbo_year.ComboBox.SelectedValue = !string.IsNullOrEmpty(Year) ? int.Parse(Year) : DateTime.Now.Year;
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
            cbo_Thang.ComboBox.SelectedValue = !string.IsNullOrEmpty(Month) ? int.Parse(Month) : DateTime.Now.Month;
        }

        public void Load_data()
        {
            if (!string.IsNullOrEmpty(Trangthai))
            {
                cbo_trangthai.ComboBox.SelectedValue = int.Parse(Trangthai);
            }
            if (Xemtong == true)
            {
                chk_TheoNam.Checked = true;
            }
            if (Manhanvien != "")
            {
                txt_search.Text = Manhanvien;
            }
            if (!string.IsNullOrEmpty(Year))
            {
                cbo_year.ComboBox.Text = Year;
            }
            if (!string.IsNullOrEmpty(Month))
            {
                cbo_Thang.ComboBox.Text = Month;
            }

            string search = "";
            if (!string.IsNullOrEmpty(txt_search.Text))
            {
                search += $" and (MaNhanVien like '%{txt_search.Text}%' or TenNhanVien like '%{txt_search.Text}%') ";
            }
            if (cbo_trangthai.ComboBox.SelectedValue != null && cbo_trangthai.ComboBox.SelectedValue.ToString() != "0")
            {
                search += $" and IDTrangThai = '{cbo_trangthai.ComboBox.SelectedValue}' ";
            }
            if (LoginInfo.Group != "ADMIN" && LoginInfo.Group != "HR")
            {
                search += $" and (MaNhanVien = {SQLHelper.rpStr(SQLHelper.sUser)} OR NguoiXacNhan = {SQLHelper.rpStr(SQLHelper.sUser)} OR ReportToReportTo = {SQLHelper.rpStr(SQLHelper.sUser)}) ";
            }

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
                            g.KyHieu, f.GhiChu, f.SoNgay, a.MaChucVu, h.TypeId AS IDTrangThai, h.TypeName AS TrangThaiPhieu, f.NguoiXacNhan, i.ReportTo as ReportToReportTo,f.LyDoNguoiXacNhan
                        FROM MITACOSQL.dbo.NhanVien a
                        JOIN tbl_NhanVien b ON a.MaNhanVien = b.MaNhanVien
                        LEFT JOIN MITACOSQL.dbo.CHUCVU c ON c.MachucVu = a.MaChucVu
                        JOIN MITACOSQL.dbo.KHUVUC d ON d.MaKhuVuc = a.MaKhuVuc
                        JOIN sys_AllType e ON b.id_trangthai = e.typeid
                        JOIN tbl_NghiPhepNam f ON f.MaNhanVien = a.MaNhanVien
                        JOIN mst_LoaiPhep g ON g.MaLoaiPhep = f.LoaiPhepNghi
                        LEFT JOIN tbl_NhanVien i ON f.MaNhanVien = i.MaNhanVien
                        LEFT JOIN sys_AllType h ON f.Id_TrangThai = h.TypeId
                        WHERE f.nam = '{cbo_year.Text}' AND f.del_flg = 0 " +
                    (chk_TheoNam.Checked == false ? $" and month(f.NgayNghi) = '{cbo_Thang.Text}' " : "") +
                $@")
                    SELECT Id, MaNhanVien, TenNhanVien, TenKhuVuc, TenChucVu, TrangThai, NgayNghi, NuaNgay, KyHieu, SoNgay, MaChucVu,
                    IDTrangThai, TrangThaiPhieu, NguoiXacNhan, ReportToReportTo,GhiChu,LyDoNguoiXacNhan
                    FROM CTE_NhanVien
                    WHERE 1=1 " +
                search;

            dgv_annual_leave.DataSource = SQLHelper.ExecuteDt(sql);
        }

        private void btn_add_Click(object sender, EventArgs e)
        {
            using (frm_annual_leave frm = new frm_annual_leave(this))
            {
                frm.edit = false;
                frm.ShowDialog();
            }
        }

        private void dgv_annual_leave_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dgv_annual_leave.CurrentCell.OwningColumn.Name == "edit_column")
            {
                if (dgv_annual_leave.CurrentRow.Cells["IDTrangThaiP"].Value.ToString().Contains("199"))
                {
                    return;
                }
                if (dgv_annual_leave.CurrentRow.Cells["NguoiXacNhan"].Value.ToString() == LoginInfo.ReportTo ||
                   LoginInfo.ReportTo != "")
                {
                    return;
                }
                if (!CheckReportTo())
                {
                    using (frm_annual_leave frm = new frm_annual_leave(this))
                    {
                        frm.edit = true;
                        frm._id_nghi_phep_value = int.Parse(dgv_annual_leave.CurrentRow.Cells["id"].Value.ToString());
                        frm._ma_nhan_vien = dgv_annual_leave.CurrentRow.Cells["MaNhanVien"].Value.ToString();
                        frm._id_trangthai = int.Parse(dgv_annual_leave.CurrentRow.Cells["IDTrangThaiP"].Value.ToString());
                        frm.ShowDialog();
                    }
                }
                else
                {
                    using (frm_QuanLyXacNhan frm = new frm_QuanLyXacNhan())
                    {
                        frm._id = int.Parse(dgv_annual_leave.CurrentRow.Cells["id"].Value.ToString());
                        frm._idTrangThai = IdTrangThaiPhieu;
                        frm._year = cbo_year.ComboBox.SelectedValue.ToString();
                        frm.ShowDialog();
                    }
                }
            }
        }

        private void btn_delete_Click(object sender, EventArgs e)
        {
            try
            {
                if (dgv_annual_leave.CurrentRow.Cells["NguoiXacNhan"].Value.ToString() != LoginInfo.ReportTo)
                {
                    DialogResult result = RJMessageBox.Show("Bạn có chác muốn xóa?", "Thông báo", MessageBoxButtons.YesNo);
                    if (result == DialogResult.Yes)
                    {
                        string sql = string.Format("update tbl_NghiPhepNam set del_flg = 1 , NguoiTao = '{1}' where id = '{0}'", dgv_annual_leave.CurrentRow.Cells["id"].Value, SQLHelper.sIdUser);
                        if (SQLHelper.ExecuteSql(sql) == 1)
                        {
                            Load_data();
                            RJMessageBox.Show("Xóa thành công", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                    }
                }
                else
                {
                    RJMessageBox.Show("Phiếu này đã được duyệt, bạn không thể xóa");
                }
            }
            catch (Exception ex)
            {
                RJMessageBox.Show(ex.Message, "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btn_Search_Click(object sender, EventArgs e)
        {
            Trangthai = "";
            Xemtong = false;
            Manhanvien = "";
            Year = "";
            Month = "";
            Load_data();
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
