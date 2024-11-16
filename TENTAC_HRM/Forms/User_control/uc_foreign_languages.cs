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
    public partial class uc_foreign_languages : UserControl
    {
        public static uc_foreign_languages _instance;

        private static MstMaTuDong autoCodeGenerator = new MstMaTuDong();

        public static uc_foreign_languages Instance
        {
            get
            {
                if (_instance == null)
                    _instance = new uc_foreign_languages();
                return _instance;
            }
        }
        public uc_foreign_languages()
        {
            InitializeComponent();
            load_data();
        }
        public void load_data()
        {
            string sql = "select Id, MaNgoaiNgu, TenNgoaiNgu, MoTa, NgayTao, NguoiTao, NgayCapNhat, NguoiCapNhat from mst_NgoaiNgu where DelFlg = 0 order by MaNgoaiNgu";
            DataTable dt = new DataTable();
            dt = SQLHelper.ExecuteDt(sql);
            dgv_foreign_languages.DataSource = dt;
        }
        private void btn_delete_Click(object sender, EventArgs e)
        {
            try
            {
                dgv_foreign_languages.EndEdit();
                List<string> updateQueries = new List<string>();

                for (int i = 0; i < dgv_foreign_languages.Rows.Count; i++)
                {
                    DataGridViewRow row = dgv_foreign_languages.Rows[i];

                    bool isChecked = row.Cells["check"].Value != DBNull.Value && row.Cells["check"].Value != null && Convert.ToBoolean(row.Cells["check"].Value);

                    if (isChecked)
                    {
                        string MaNgoaiNgu = row.Cells["MaNgoaiNgu"].Value?.ToString();
                        if (!string.IsNullOrEmpty(MaNgoaiNgu))
                        {
                            updateQueries.Add($@"UPDATE mst_NgoaiNgu SET DelFlg = 1 WHERE MaNgoaiNgu = N'{MaNgoaiNgu}'");
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
                string fileName = $"MstNgoaiNgu_{DateTime.Now.ToString("yyyyMMdd")}.xlsx";
                string filePath = Path.Combine(desktopPath, fileName);

                IWorkbook workbook = new XSSFWorkbook();
                ISheet worksheet = workbook.CreateSheet("NgoaiNgu");

                IRow headerRow = worksheet.CreateRow(0);
                headerRow.CreateCell(0).SetCellValue("Mã Ngoại Ngữ");
                headerRow.CreateCell(1).SetCellValue("Tên Ngoại Ngữ");
                headerRow.CreateCell(2).SetCellValue("Mô Tả");
                headerRow.CreateCell(3).SetCellValue("Ngày Tạo");
                headerRow.CreateCell(4).SetCellValue("Người Tạo");
                headerRow.CreateCell(5).SetCellValue("Ngày Cập Nhật");
                headerRow.CreateCell(6).SetCellValue("Người Cập Nhật");

                int row = 1;

                foreach (DataGridViewRow dgvRow in dgv_foreign_languages.Rows)
                {
                    if (!dgvRow.IsNewRow)
                    {
                        IRow dataRow = worksheet.CreateRow(row);
                        dataRow.CreateCell(0).SetCellValue(dgvRow.Cells["MaNgoaiNgu"].Value?.ToString() ?? "");
                        dataRow.CreateCell(1).SetCellValue(dgvRow.Cells["TenNgoaiNgu"].Value?.ToString() ?? "");
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

                using (FileStream stream = new FileStream(filePath, FileMode.Create, FileAccess.Write))
                {
                    workbook.Write(stream);
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
                    if (!fileName.StartsWith("MstNgoaiNgu_"))
                    {
                        RJMessageBox.Show("Tên file không hợp lệ. Vui lòng chọn file có tên bắt đầu bằng 'MstNgoaiNgu_'.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }

                    KillExcelProcesses(fileName);

                    using (FileStream fs = new FileStream(openFileDialog.FileName, FileMode.Open, FileAccess.Read))
                    {
                        IWorkbook workbook = openFileDialog.FileName.EndsWith(".xlsx") ? (IWorkbook)new XSSFWorkbook(fs) : new HSSFWorkbook(fs);
                        ISheet worksheet = workbook.GetSheetAt(0); 

                        if (worksheet.SheetName != "NgoaiNgu")
                        {
                            RJMessageBox.Show("Tên sheet không hợp lệ. Vui lòng chọn file có sheet tên là 'NgoaiNgu'.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            return; 
                        }

                        int res = 0;
                        for (int row = 1; row <= worksheet.LastRowNum; row++)
                        {
                            IRow dataRow = worksheet.GetRow(row);
                            if (dataRow == null) continue;

                            string maNgoaiNgu = dataRow.GetCell(0)?.ToString() ?? "";
                            string tenNgoaiNgu = dataRow.GetCell(1)?.ToString() ?? "";
                            string moTa = dataRow.GetCell(2)?.ToString() ?? "";

                            string checkQuery = "SELECT COUNT(*) FROM mst_NgoaiNgu WHERE MaNgoaiNgu = @MaNgoaiNgu AND DelFlg = 0";
                            var checkParams = new List<SqlParameter>
                            {
                                new SqlParameter("@MaNgoaiNgu", maNgoaiNgu)
                            };

                            int count = (int)SQLHelper.ExecuteScalarSql(checkQuery, checkParams.ToArray());

                            if (count > 0)
                            {
                                string sqlUpdate = @"UPDATE mst_NgoaiNgu
                                SET 
                                    TenNgoaiNgu = @TenNgoaiNgu,
                                    MoTa = @MoTa,
                                    NgayCapNhat = @NgayCapNhat,
                                    NguoiCapNhat = @NguoiCapNhat
                                WHERE 
                                    MaNgoaiNgu = @MaNgoaiNgu AND DelFlg = 0";

                                var updateParams = new List<SqlParameter>
                                {
                                    new SqlParameter("@MaNgoaiNgu", maNgoaiNgu),
                                    new SqlParameter("@TenNgoaiNgu", tenNgoaiNgu),
                                    new SqlParameter("@MoTa", moTa),
                                    new SqlParameter("@NgayCapNhat", DateTime.Now),
                                    new SqlParameter("@NguoiCapNhat", SQLHelper.sUser)
                                };
                                res += SQLHelper.ExecuteSql(sqlUpdate, updateParams.ToArray());
                            }
                            else
                            {
                                string newMaNgoaiNgu = autoCodeGenerator.GenerateNextCode("mst_NgoaiNgu", "NN", "MaNgoaiNgu");

                                string sqlInsert = @"INSERT INTO mst_NgoaiNgu(MaNgoaiNgu, TenNgoaiNgu, MoTa, NgayTao, NguoiTao, NgayCapNhat, NguoiCapNhat, DelFlg)
                                VALUES(@MaNgoaiNgu, @TenNgoaiNgu, @MoTa, @NgayTao, @NguoiTao, @NgayCapNhat, @NguoiCapNhat, 0)";

                                var insertParams = new List<SqlParameter>
                                {
                                    new SqlParameter("@MaNgoaiNgu", newMaNgoaiNgu),
                                    new SqlParameter("@TenNgoaiNgu", tenNgoaiNgu),
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
                    load_data();
                }
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
            frmMstNgoaiNgu frmMstNgoaiNgu = new frmMstNgoaiNgu(null, null, null, true, this);
            frmMstNgoaiNgu.ShowDialog();
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
        private void dgv_foreign_languages_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0 && e.ColumnIndex == dgv_foreign_languages.Columns["edit_column"].Index)
            {
                string MaNgoaiNgu = dgv_foreign_languages.CurrentRow.Cells["MaNgoaiNgu"].Value.ToString();
                string TenNgoaiNgu = dgv_foreign_languages.CurrentRow.Cells["TenNgoaiNgu"].Value.ToString();
                string MoTa = dgv_foreign_languages.CurrentRow.Cells["MoTa"].Value.ToString();
                frmMstNgoaiNgu frmMstNgoaiNgu = new frmMstNgoaiNgu(MaNgoaiNgu, TenNgoaiNgu, MoTa, false, this);
                frmMstNgoaiNgu.ShowDialog();
            }
        }
    }
}
