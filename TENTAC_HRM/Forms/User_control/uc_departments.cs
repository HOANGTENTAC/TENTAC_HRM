﻿using NPOI.HSSF.UserModel;
using NPOI.SS.UserModel;
using NPOI.XSSF.UserModel;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using TENTAC_HRM.Common;
using TENTAC_HRM.Custom;
using TENTAC_HRM.Forms.Mst_Add_Data;

namespace TENTAC_HRM.Forms.User_control
{
    public partial class uc_departments : UserControl
    {
        public static uc_departments _instance;
        private static MstMaTuDong autoCodeGenerator = new MstMaTuDong();
        public static uc_departments Instance
        {
            get
            {
                if (_instance == null)
                    _instance = new uc_departments();
                return _instance;
            }
        }
        public uc_departments()
        {
            InitializeComponent();
            load_data();
        }
        public void load_data()
        {
            string sql = "select Id, MaPhongBan, MaCongTy, MaKhuVuc, TenPhongBan, NgayCapNhat, NguoiCapNhat from mst_PhongBan where DelFlg = 0 order by MaPhongBan";
            DataTable dt = new DataTable();
            dt = SQLHelper.ExecuteDt(sql);
            dgv_departments.DataSource = dt;
        }
        private void btn_delete_Click(object sender, EventArgs e)
        {
            try
            {
                dgv_departments.EndEdit();
                List<string> updateQueries = new List<string>();

                for (int i = 0; i < dgv_departments.Rows.Count; i++)
                {
                    DataGridViewRow row = dgv_departments.Rows[i];

                    bool isChecked = row.Cells["check"].Value != DBNull.Value && row.Cells["check"].Value != null && Convert.ToBoolean(row.Cells["check"].Value);

                    if (isChecked)
                    {
                        string MaPhongBan = row.Cells["MaPhongBan"].Value?.ToString();
                        if (!string.IsNullOrEmpty(MaPhongBan))
                        {
                            updateQueries.Add($@"UPDATE mst_PhongBan SET DelFlg = 1 WHERE MaPhongBan = N'{MaPhongBan}'");
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
                string fileName = $"MstPhongBan_{DateTime.Now.ToString("yyyyMMdd")}.xlsx";
                string filePath = Path.Combine(desktopPath, fileName);

                string query = "SELECT Id, MaPhongBan, MaCongTy, MaKhuVuc, TenPhongBan, NgayTao, NguoiTao, NgayCapNhat, NguoiCapNhat, DelFlg FROM mst_PhongBan WHERE DelFlg = 0";
                SqlDataReader reader = SQLHelper.ExecuteReader(query);

                IWorkbook workbook = new XSSFWorkbook();
                ISheet worksheet = workbook.CreateSheet("PhongBan");

                IRow headerRow = worksheet.CreateRow(0);
                headerRow.CreateCell(0).SetCellValue("Mã Phòng Ban");
                headerRow.CreateCell(1).SetCellValue("Mã Công Ty");
                headerRow.CreateCell(2).SetCellValue("Mã Khu Vục");
                headerRow.CreateCell(3).SetCellValue("Tên Phòng Ban");
                headerRow.CreateCell(4).SetCellValue("Ngày Tạo");
                headerRow.CreateCell(5).SetCellValue("Người Tạo");
                headerRow.CreateCell(6).SetCellValue("Ngày Cập Nhật");
                headerRow.CreateCell(7).SetCellValue("Người Cập Nhật");

                int row = 1;
                while (reader.Read())
                {
                    IRow dataRow = worksheet.CreateRow(row);
                    dataRow.CreateCell(0).SetCellValue(reader["MaPhongBan"].ToString());
                    dataRow.CreateCell(1).SetCellValue(reader["MaCongTy"].ToString());
                    dataRow.CreateCell(2).SetCellValue(reader["MaKhuVuc"].ToString());
                    dataRow.CreateCell(3).SetCellValue(reader["TenPhongBan"].ToString());
                    dataRow.CreateCell(4).SetCellValue(reader["NgayTao"] != DBNull.Value ? reader["NgayTao"].ToString() : "");
                    dataRow.CreateCell(5).SetCellValue(reader["NguoiTao"].ToString());
                    dataRow.CreateCell(6).SetCellValue(reader["NgayCapNhat"] != DBNull.Value ? reader["NgayCapNhat"].ToString() : "");
                    dataRow.CreateCell(7).SetCellValue(reader["NguoiCapNhat"].ToString());
                    row++;
                }
                reader.Close();

                for (int i = 0; i < 8; i++)
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
                    if (!fileName.StartsWith("MstPhongBan_"))
                    {
                        RJMessageBox.Show("Tên file không hợp lệ. Vui lòng chọn file có tên bắt đầu bằng 'MstPhongBan_'.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }
                    KillExcelProcesses(fileName);
                    Cursor.Current = Cursors.WaitCursor;
                    using (var fs = new FileStream(openFileDialog.FileName, FileMode.Open, FileAccess.Read))
                    {
                        IWorkbook workbook = openFileDialog.FileName.EndsWith(".xlsx") ? (IWorkbook)new XSSFWorkbook(fs) : new HSSFWorkbook(fs);
                        ISheet sheet = workbook.GetSheetAt(0);

                        if (sheet.SheetName != "PhongBan")
                        {
                            RJMessageBox.Show("Tên sheet không hợp lệ. Vui lòng chọn file có sheet tên là 'PhongBan'.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            return;
                        }
                        int res = 0;

                        for (int row = 1; row <= sheet.LastRowNum; row++)
                        {
                            IRow currentRow = sheet.GetRow(row);
                            if (currentRow == null) continue;

                            string maPhongBan = currentRow.GetCell(0)?.ToString() ?? "";
                            string maCongTy = currentRow.GetCell(1)?.ToString() ?? "";
                            string maKhuVuc = currentRow.GetCell(2)?.ToString() ?? "";
                            string tenPhongBan = currentRow.GetCell(3)?.ToString() ?? "";

                            string checkQuery = "SELECT COUNT(*) FROM mst_PhongBan WHERE MaPhongBan = @MaPhongBan AND DelFlg = 0";
                            var checkParams = new List<SqlParameter> { new SqlParameter("@MaPhongBan", maPhongBan) };
                            int count = (int)SQLHelper.ExecuteScalarSql(checkQuery, checkParams.ToArray());

                            if (count > 0)
                            {
                                string sqlUpdate = @"UPDATE mst_PhongBan SET MaCongTy = @MaCongTy, MaKhuVuc = @MaKhuVuc, 
                                                    TenPhongBan = @TenPhongBan, NgayCapNhat = @NgayCapNhat, NguoiCapNhat = @NguoiCapNhat 
                                                    WHERE MaPhongBan = @MaPhongBan AND DelFlg = 0";
                                var updateParams = new List<SqlParameter>
                                {
                                    new SqlParameter("@MaPhongBan", maPhongBan),
                                    new SqlParameter("@MaCongTy", maCongTy),
                                    new SqlParameter("@MaKhuVuc", maKhuVuc),
                                    new SqlParameter("@TenPhongBan", tenPhongBan),
                                    new SqlParameter("@NgayCapNhat", DateTime.Now),
                                    new SqlParameter("@NguoiCapNhat", SQLHelper.sUser)
                                };
                                res += SQLHelper.ExecuteSql(sqlUpdate, updateParams.ToArray());
                            }
                            else
                            {
                                string newMaPhongBan = autoCodeGenerator.GenerateNextMaPhongBan();
                                string sqlInsert = @"INSERT INTO mst_PhongBan(MaPhongBan, MaCongTy, MaKhuVuc, TenPhongBan, NgayTao, NguoiTao, NgayCapNhat, NguoiCapNhat, DelFlg) 
                                                VALUES(@MaPhongBan, @MaCongTy, @MaKhuVuc, @TenPhongBan, @NgayTao, @NguoiTao, @NgayCapNhat, @NguoiCapNhat, 0)";

                                var insertParams = new List<SqlParameter>
                                {
                                    new SqlParameter("@MaPhongBan", newMaPhongBan),
                                    new SqlParameter("@MaCongTy", maCongTy),
                                    new SqlParameter("@MaKhuVuc", maKhuVuc),
                                    new SqlParameter("@TenPhongBan", tenPhongBan),
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
        private void dgv_departments_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0 && e.ColumnIndex == dgv_departments.Columns["edit_column"].Index)
            {
                string MaPhongBan = dgv_departments.CurrentRow.Cells["MaPhongBan"].Value.ToString();
                string MaCongTy = dgv_departments.CurrentRow.Cells["MaCongTy"].Value.ToString();
                string MaKhuVuc = dgv_departments.CurrentRow.Cells["MaKhuVuc"].Value.ToString();
                string TenPhongBan = dgv_departments.CurrentRow.Cells["TenPhongBan"].Value.ToString();
                frmMstPhongBan frmMstPhongBan = new frmMstPhongBan(MaPhongBan, MaCongTy, MaKhuVuc, TenPhongBan, false, this);
                frmMstPhongBan.ShowDialog();
            }
        }
        private void btn_close_Click(object sender, EventArgs e)
        {
            Control x = this.Parent;
            x.Controls.Remove(this);
        }
        private void btn_add_Click(object sender, EventArgs e)
        {
            frmMstPhongBan frmMstPhongBan = new frmMstPhongBan(null, null, null, null, true, this);
            frmMstPhongBan.ShowDialog();
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
