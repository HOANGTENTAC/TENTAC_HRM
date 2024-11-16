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
using TENTAC_HRM.Custom;
using TENTAC_HRM.Forms.Mst_Add_Data;

namespace TENTAC_HRM.Forms.User_control
{
    public partial class uc_certificate : UserControl
    {
        public static uc_certificate _instance;
        private static MstMaTuDong autoCodeGenerator = new MstMaTuDong();
        public static uc_certificate Instance
        {
            get
            {
                if (_instance == null)
                    _instance = new uc_certificate();
                return _instance;
            }
        }
        public uc_certificate()
        {
            InitializeComponent();
            load_data();
        }
        public void load_data()
        {
            string sql = "select Id, MaChungChi,TenChungChi, MoTa, NgayTao, NguoiTao, NgayCapNhat, NguoiCapNhat from mst_ChungChi where DelFlg = 0 order by MaChungChi";
            DataTable dt = new DataTable();
            dt = SQLHelper.ExecuteDt(sql);
            dgv_certificate.DataSource = dt;
        }
        private void uc_certificate_Load(object sender, EventArgs e)
        {
            //pl_nation.Width = 0;
            load_data();
        }
        private void btn_delete_Click(object sender, EventArgs e)
        {
            try
            {
                dgv_certificate.EndEdit();
                List<string> updateQueries = new List<string>();

                for (int i = 0; i < dgv_certificate.Rows.Count; i++)
                {
                    DataGridViewRow row = dgv_certificate.Rows[i];

                    bool isChecked = row.Cells["check"].Value != DBNull.Value && row.Cells["check"].Value != null && Convert.ToBoolean(row.Cells["check"].Value);

                    if (isChecked)
                    {
                        string MaChungChi = row.Cells["MaChungChi"].Value?.ToString();
                        if (!string.IsNullOrEmpty(MaChungChi))
                        {
                            updateQueries.Add($@"UPDATE mst_ChungChi SET DelFlg = 1 WHERE MaChungChi = N'{MaChungChi}'");
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
                load_data();
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
                string fileName = $"MstChungChi_{DateTime.Now.ToString("yyyyMMdd")}.xlsx";
                string filePath = Path.Combine(desktopPath, fileName);

                IWorkbook workbook = new XSSFWorkbook();
                ISheet worksheet = workbook.CreateSheet("ChungChi");

                IRow headerRow = worksheet.CreateRow(0);
                headerRow.CreateCell(0).SetCellValue("Mã Chứng Chỉ");
                headerRow.CreateCell(1).SetCellValue("Tên Chứng Chỉ");
                headerRow.CreateCell(2).SetCellValue("Mô Tả");
                headerRow.CreateCell(3).SetCellValue("Ngày Tạo");
                headerRow.CreateCell(4).SetCellValue("Người Tạo");
                headerRow.CreateCell(5).SetCellValue("Ngày Cập Nhật");
                headerRow.CreateCell(6).SetCellValue("Người Cập Nhật");

                int row = 1;
                foreach (DataGridViewRow dgvRow in dgv_certificate.Rows)
                {
                    if (!dgvRow.IsNewRow)
                    {
                        IRow dataRow = worksheet.CreateRow(row);
                        dataRow.CreateCell(0).SetCellValue(dgvRow.Cells["MaChungChi"].Value?.ToString() ?? "");
                        dataRow.CreateCell(1).SetCellValue(dgvRow.Cells["TenChungChi"].Value?.ToString() ?? "");
                        dataRow.CreateCell(2).SetCellValue(dgvRow.Cells["MoTa"].Value?.ToString() ?? "");
                        dataRow.CreateCell(3).SetCellValue(dgvRow.Cells["NgayTao"].Value?.ToString() ?? "");
                        dataRow.CreateCell(4).SetCellValue(dgvRow.Cells["NguoiTao"].Value?.ToString() ?? "");
                        dataRow.CreateCell(5).SetCellValue(dgvRow.Cells["NgayCapNhat"].Value?.ToString() ?? "");
                        dataRow.CreateCell(6).SetCellValue(dgvRow.Cells["NguoiCapNhat"].Value?.ToString() ?? "");
                        row++;
                    }
                }

                for (int i = 0; i <= 6; i++)
                {
                    worksheet.AutoSizeColumn(i);
                }

                using (var fileStream = new FileStream(filePath, FileMode.Create, FileAccess.Write))
                {
                    workbook.Write(fileStream);
                }
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
                    if (!fileName.StartsWith("MstChungChi_"))
                    {
                        RJMessageBox.Show("Tên file không hợp lệ. Vui lòng chọn file có tên bắt đầu bằng 'MstChungChi_'.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }
                    KillExcelProcesses(fileName);
                    Cursor.Current = Cursors.WaitCursor;
                    using (var fs = new FileStream(openFileDialog.FileName, FileMode.Open, FileAccess.Read))
                    {
                        IWorkbook workbook = openFileDialog.FileName.EndsWith(".xlsx") ? (IWorkbook)new XSSFWorkbook(fs) : new HSSFWorkbook(fs);
                        ISheet sheet = workbook.GetSheetAt(0);

                        if (sheet.SheetName != "ChungChi")
                        {
                            RJMessageBox.Show("Tên sheet không hợp lệ. Vui lòng chọn file có sheet tên là 'ChungChi'.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            return;
                        }
                        int res = 0;

                        for (int row = 1; row <= sheet.LastRowNum; row++)
                        {
                            IRow currentRow = sheet.GetRow(row);
                            if (currentRow == null) continue;

                            string maChungChi = currentRow.GetCell(0)?.ToString() ?? "";
                            string tenChungChi = currentRow.GetCell(1)?.ToString() ?? "";
                            string moTa = currentRow.GetCell(2)?.ToString() ?? "";

                            string checkQuery = "SELECT COUNT(*) FROM mst_ChungChi WHERE MaChungChi = @MaChungChi AND DelFlg = 0";
                            var checkParams = new List<SqlParameter> { new SqlParameter("@MaChungChi", maChungChi) };
                            int count = (int)SQLHelper.ExecuteScalarSql(checkQuery, checkParams.ToArray());

                            if (count > 0)
                            {
                                string sqlUpdate = @"UPDATE mst_ChungChi SET TenChungChi = @TenChungChi, MoTa = @MoTa, NgayCapNhat = @NgayCapNhat, NguoiCapNhat = @NguoiCapNhat WHERE MaChungChi = @MaChungChi AND DelFlg = 0";
                                var updateParams = new List<SqlParameter>
                                {
                                    new SqlParameter("@MaChungChi", maChungChi),
                                    new SqlParameter("@TenChungChi", tenChungChi),
                                    new SqlParameter("@MoTa", moTa),
                                    new SqlParameter("@NgayCapNhat", DateTime.Now),
                                    new SqlParameter("@NguoiCapNhat", SQLHelper.sUser)
                                };
                                res += SQLHelper.ExecuteSql(sqlUpdate, updateParams.ToArray());
                            }
                            else
                            {
                                string newMaChungChi = autoCodeGenerator.GenerateNextCode("mst_ChungChi", "CC", "MaChungChi");
                                string sqlInsert = @"INSERT INTO mst_ChungChi(MaChungChi, TenChungChi, MoTa, NgayTao, NguoiTao, NgayCapNhat, NguoiCapNhat, DelFlg) VALUES(@MaChungChi, @TenChungChi, @MoTa, @NgayTao, @NguoiTao, @NgayCapNhat, @NguoiCapNhat, 0)";

                                var insertParams = new List<SqlParameter>
                                {
                                    new SqlParameter("@MaChungChi", newMaChungChi),
                                    new SqlParameter("@TenChungChi", tenChungChi),
                                    new SqlParameter("@MoTa", moTa),
                                    new SqlParameter("@NgayTao", DateTime.Now),
                                    new SqlParameter("@NguoiTao", SQLHelper.sUser),
                                    new SqlParameter("@NgayCapNhat", DateTime.Now),
                                    new SqlParameter("@NguoiCapNhat", SQLHelper.sUser)
                                };
                                res += SQLHelper.ExecuteSql(sqlInsert, insertParams.ToArray());
                            }
                        }
                        if (res > 0)
                        {
                            RJMessageBox.Show("Cập nhật dữ liệu thành công.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                    }
                    Cursor.Current = Cursors.Default;
                }
                load_data();
            }
            catch (Exception ex)
            {
                RJMessageBox.Show(ex.Message, "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void dgv_certificate_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0 && e.ColumnIndex == dgv_certificate.Columns["edit_column"].Index)
            {
                string MaChungChi = dgv_certificate.CurrentRow.Cells["MaChungChi"].Value.ToString();
                string TenChungChi = dgv_certificate.CurrentRow.Cells["TenChungChi"].Value.ToString();
                string MoTa = dgv_certificate.CurrentRow.Cells["MoTa"].Value.ToString();
                frmMstChungChi frmMstChungChi = new frmMstChungChi(MaChungChi, TenChungChi, MoTa, false, this);
                frmMstChungChi.ShowDialog();
            }
        }
        private void btn_close_Click(object sender, EventArgs e)
        {
            Control x = this.Parent;
            x.Controls.Remove(this);
        }
        private void btn_add_Click(object sender, EventArgs e)
        {
            frmMstChungChi frmMstChungChi = new frmMstChungChi(null, null, null, true, this);
            frmMstChungChi.ShowDialog();
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
    }
}
