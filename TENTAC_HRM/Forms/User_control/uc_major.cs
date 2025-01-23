using NPOI.HSSF.UserModel;
using NPOI.SS.UserModel;
using NPOI.XSSF.UserModel;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.IO;
using System.Windows.Forms;
using TENTAC_HRM.Common;
using TENTAC_HRM.Consts;
using TENTAC_HRM.Custom;
using TENTAC_HRM.Forms.Mst_Add_Data;

namespace TENTAC_HRM.Forms.User_control
{
    public partial class uc_major : UserControl
    {
        public static uc_major _instance;

        private static MstMaTuDong autoCodeGenerator = new MstMaTuDong();
        public static uc_major Instance
        {
            get
            {
                if (_instance == null)
                    _instance = new uc_major();
                return _instance;
            }
        }
        public uc_major()
        {
            InitializeComponent();
            LoadData();
        }
        public void LoadData()
        {
            string sql = "select Id, MaChuyenNganh, TenChuyenNganh, MoTa, NgayTao, NguoiTao, NgayCapNhat, NguoiCapNhat from mst_ChuyenNganh where del_flg = 0 order by MaChuyenNganh";
            DataTable dt = new DataTable();
            dt = SQLHelper.ExecuteDt(sql);
            dgv_major.DataSource = dt;
        }
        private void btn_delete_Click(object sender, EventArgs e)
        {
            try
            {
                DialogResult result = RJMessageBox.Show("Bạn có chắc chắn muốn xoá các mục đã chọn không?",
                                               "Xác nhận",
                                               MessageBoxButtons.YesNo,
                                               MessageBoxIcon.Question);

                if (result != DialogResult.Yes)
                {
                    return;
                }
                dgv_major.EndEdit();
                List<string> updateQueries = new List<string>();

                for (int i = 0; i < dgv_major.Rows.Count; i++)
                {
                    DataGridViewRow row = dgv_major.Rows[i];

                    bool isChecked = row.Cells["check"].Value != DBNull.Value && row.Cells["check"].Value != null && Convert.ToBoolean(row.Cells["check"].Value);

                    if (isChecked)
                    {
                        string MaNgoaiNgu = row.Cells["MaChuyenNganh"].Value?.ToString();
                        if (!string.IsNullOrEmpty(MaNgoaiNgu))
                        {
                            updateQueries.Add($@"UPDATE mst_ChuyenNganh SET del_flg = 1 WHERE MaChuyenNganh = N'{MaNgoaiNgu}'");
                        }
                    }
                }

                if (updateQueries.Count > 0)
                {
                    foreach (string sql in updateQueries)
                    {
                        SQLHelper.ExecuteSql(sql);
                    }

                    RJMessageBox.Show("Cập nhật thành công.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    RJMessageBox.Show("Cập nhật thất bại.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                LoadData();
            }
            catch (Exception ex)
            {
                RJMessageBox.Show(ex.Message, "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void btn_export_Click(object sender, EventArgs e)
        {
            try
            {
                Cursor.Current = Cursors.WaitCursor;
                string desktopPath = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);
                string fileName = $"MstChuyenNganh_{DateTime.Now:yyyyMMdd}.xlsx";
                string filePath = Path.Combine(desktopPath, fileName);

                KillExcelProcesses(fileName);

                var workbook = new NPOI.XSSF.UserModel.XSSFWorkbook();
                var worksheet = workbook.CreateSheet("ChuyenNganh");

                var headerRow = worksheet.CreateRow(0);
                headerRow.CreateCell(0).SetCellValue("Mã Chuyên Ngành");
                headerRow.CreateCell(1).SetCellValue("Tên Chuyên Ngành");
                headerRow.CreateCell(2).SetCellValue("Mô Tả");
                headerRow.CreateCell(3).SetCellValue("Ngày Tạo");
                headerRow.CreateCell(4).SetCellValue("Người Tạo");
                headerRow.CreateCell(5).SetCellValue("Ngày Cập Nhật");
                headerRow.CreateCell(6).SetCellValue("Người Cập Nhật");

                int row = 1;
                foreach (DataGridViewRow dgvRow in dgv_major.Rows)
                {
                    if (!dgvRow.IsNewRow)
                    {
                        IRow dataRow = worksheet.CreateRow(row);
                        dataRow.CreateCell(0).SetCellValue(dgvRow.Cells["MaChuyenNganh"].Value?.ToString() ?? "");
                        dataRow.CreateCell(1).SetCellValue(dgvRow.Cells["TenChuyenNganh"].Value?.ToString() ?? "");
                        dataRow.CreateCell(2).SetCellValue(dgvRow.Cells["MoTa"].Value?.ToString() ?? "");
                        dataRow.CreateCell(3).SetCellValue(dgvRow.Cells["NgayTao"].Value?.ToString() ?? "");
                        dataRow.CreateCell(4).SetCellValue(dgvRow.Cells["NguoiTao"].Value?.ToString() ?? "");
                        dataRow.CreateCell(5).SetCellValue(dgvRow.Cells["NgayCapNhat"].Value?.ToString() ?? "");
                        dataRow.CreateCell(6).SetCellValue(dgvRow.Cells["NguoiCapNhat"].Value?.ToString() ?? "");
                        row++;
                    }
                }

                for (int i = 0; i < 7; i++)
                {
                    worksheet.AutoSizeColumn(i);
                }

                using (var fileStream = new FileStream(filePath, FileMode.Create, FileAccess.Write))
                {
                    workbook.Write(fileStream);
                }
                workbook.Close();
                Cursor.Current = Cursors.Default;
                RJMessageBox.Show("Xuất dữ liệu thành công! File đã được lưu vào Desktop.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                RJMessageBox.Show(ex.Message, "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void btn_import_Click(object sender, EventArgs e)
        {
            try
            {
                OpenFileDialog openFileDialog = new OpenFileDialog
                {
                    Filter = "Excel Files|*.xls;*.xlsx;*.xlsm",
                    Title = "Chọn file Excel để nhập dữ liệu"
                };

                if (openFileDialog.ShowDialog() == DialogResult.OK)
                {
                    string fileName = Path.GetFileName(openFileDialog.FileName);
                    if (!fileName.StartsWith("MstChuyenNganh_"))
                    {
                        RJMessageBox.Show("Tên file không hợp lệ. Vui lòng chọn file có tên bắt đầu bằng 'MstChuyenNganh_'.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }
                    Cursor.Current = Cursors.WaitCursor;
                    using (var fs = new FileStream(openFileDialog.FileName, FileMode.Open, FileAccess.Read))
                    {
                        IWorkbook workbook = openFileDialog.FileName.EndsWith(".xlsx") ? (IWorkbook)new XSSFWorkbook(fs) : new HSSFWorkbook(fs);
                        ISheet sheet = workbook.GetSheetAt(0);

                        if (sheet.SheetName != "ChuyenNganh")
                        {
                            RJMessageBox.Show("Tên sheet không hợp lệ. Vui lòng chọn file có sheet tên là 'ChuyenNganh'.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            return;
                        }
                        int res = 0;
                        for (int row = 1; row <= sheet.LastRowNum; row++)
                        {
                            IRow currentRow = sheet.GetRow(row);
                            string _MaChuyenNganh = currentRow.GetCell(0)?.ToString() ?? "";
                            string _TenChuyenNganh = currentRow.GetCell(1)?.ToString() ?? "";
                            string _MoTa = currentRow.GetCell(2)?.ToString() ?? "";

                            string checkQuery = $@"SELECT COUNT(*) FROM mst_ChuyenNganh WHERE MaChuyenNganh = {SQLHelper.rpStr(_MaChuyenNganh)} AND del_flg = 0";

                            int count = (int)SQLHelper.ExecuteScalarSql(checkQuery);

                            if (count > 0)
                            {
                                string sqlUpdate = $@"UPDATE mst_ChuyenNganh
                                SET 
                                    TenChuyenNganh = {SQLHelper.rpStr(_TenChuyenNganh)},
                                    MoTa = {SQLHelper.rpStr(_MoTa)},
                                    NgayCapNhat = '{DateTime.Now}',
                                    NguoiCapNhat = {SQLHelper.rpStr(LoginInfo.UserCd)}
                                WHERE 
                                    MaChuyenNganh = {SQLHelper.rpStr(_MaChuyenNganh)} AND del_flg = 0";
                                res += SQLHelper.ExecuteSql(sqlUpdate);
                            }
                            else
                            {
                                string newMaChuyenNganh = autoCodeGenerator.GenerateNextCode("mst_ChuyenNganh", "CN", "MaChuyenNganh");

                                string sqlInsert = $@"INSERT INTO mst_ChuyenNganh(MaChuyenNganh, TenChuyenNganh, MoTa, NgayTao, NguoiTao, NgayCapNhat, NguoiCapNhat, del_flg)
                                    VALUES({SQLHelper.rpStr(newMaChuyenNganh)}, {SQLHelper.rpStr(_TenChuyenNganh)}, {SQLHelper.rpStr(_MoTa)}, 
                                    '{DateTime.Now}', {SQLHelper.rpStr(LoginInfo.UserCd)}, '{DateTime.Now}', {SQLHelper.rpStr(LoginInfo.UserCd)}, 0)";

                                res += SQLHelper.ExecuteSql(sqlInsert);
                            }
                        }

                        if (res > 0)
                        {
                            RJMessageBox.Show("Cập nhật dữ liệu thành công.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                    }
                    Cursor.Current = Cursors.Default;
                }
                LoadData();
            }
            catch (Exception ex)
            {
                RJMessageBox.Show(ex.Message, "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void btn_close_Click(object sender, EventArgs e)
        {
            Control x = this.Parent;
            x.Controls.Remove(this);
        }
        private void btn_add_Click(object sender, EventArgs e)
        {
            frmMstChuyenNganh frmMstChuyenNganh = new frmMstChuyenNganh(this);
            frmMstChuyenNganh._Edit = false;
            frmMstChuyenNganh.ShowDialog();
        }
        private void KillExcelProcesses(string fileName)
        {
            string fileNameWithoutExtension = Path.GetFileNameWithoutExtension(fileName);

            var excelProcesses = System.Diagnostics.Process.GetProcessesByName("EXCEL");

            foreach (var process in excelProcesses)
            {
                try
                {
                    var openedFiles = process.MainWindowTitle;
                    if (openedFiles.Contains(fileNameWithoutExtension))
                    {
                        process.Kill();
                    }
                }
                catch (Exception ex)
                {
                    RJMessageBox.Show(ex.Message, "Không thể đóng tiến trình Excel", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }
        private void dgv_major_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0 && e.ColumnIndex == dgv_major.Columns["edit_column"].Index)
            {
                string MaChuyenNganh = dgv_major.CurrentRow.Cells["MaChuyenNganh"].Value.ToString();
                frmMstChuyenNganh frmMstChuyenNganh = new frmMstChuyenNganh(this);
                frmMstChuyenNganh._MaChuyenNganh = MaChuyenNganh;
                frmMstChuyenNganh._Edit = true;
                frmMstChuyenNganh.ShowDialog();
            }
        }
    }
}