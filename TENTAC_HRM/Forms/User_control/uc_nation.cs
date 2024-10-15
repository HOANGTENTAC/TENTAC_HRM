﻿using DevComponents.DotNetBar.Controls;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity.Core.Common.CommandTrees.ExpressionBuilder;
using System.Data.SqlClient;
using System.IO;
using System.Windows.Forms;
using TENTAC_HRM.Common;
using TENTAC_HRM.Custom;
using TENTAC_HRM.Forms.Mst_Add_Data;
//using Excel = Microsoft.Office.Interop.Excel;

namespace TENTAC_HRM.Forms.User_control
{
    public partial class uc_nation : UserControl
    {
        public static uc_nation _instance;
        private static MstMaTuDong autoCodeGenerator = new MstMaTuDong();
        public static uc_nation Instance
        {
            get
            {
                if (_instance == null)
                    _instance = new uc_nation();
                return _instance;
            }
        }
        public uc_nation()
        {
            InitializeComponent();
            load_dataDanToc();
        }
        public void load_dataDanToc()
        {
            string sql = "select Id, MaDanToc,TenDanToc, MoTa, NgayCapNhat, NguoiCapNhat from mst_DanToc where DelFlg = 0 order by MaDanToc";
            DataTable dt = new DataTable();
            dt = SQLHelper.ExecuteDt(sql);
            dgv_nation.DataSource = dt;
        }
        private void uc_nation_Load(object sender, EventArgs e)
        {
            //pl_nation.Width = 0;
            load_dataDanToc();
        }
        private void btn_delete_Click(object sender, EventArgs e)
        {
            try
            {
                dgv_nation.EndEdit();
                List<string> updateQueries = new List<string>();

                for (int i = 0; i < dgv_nation.Rows.Count; i++)
                {
                    DataGridViewRow row = dgv_nation.Rows[i];

                    bool isChecked = row.Cells["check"].Value != DBNull.Value && row.Cells["check"].Value != null && Convert.ToBoolean(row.Cells["check"].Value);

                    if (isChecked)
                    {
                        string MaDanToc = row.Cells["MaDanToc"].Value?.ToString();
                        if (!string.IsNullOrEmpty(MaDanToc))
                        {
                            updateQueries.Add($@"UPDATE mst_DanToc SET DelFlg = 1 WHERE MaDanToc = N'{MaDanToc}'");
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
                load_dataDanToc();
            }
            catch(Exception ex)
            {
                RJMessageBox.Show(ex.Message, "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void btn_export_Click(object sender, EventArgs e)
        {
            //try
            //{
            //    string desktopPath = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);
            //    string fileName = $"MstDanToc_{DateTime.Now.ToString("yyyyMMdd")}.xlsx";
            //    string filePath = Path.Combine(desktopPath, fileName);

            //    KillExcelProcesses(fileName);

            //    Excel.Application excelApp = new Excel.Application();
            //    Excel.Workbook workbook = excelApp.Workbooks.Add(Type.Missing);
            //    Excel._Worksheet worksheet = workbook.Sheets[1];
            //    worksheet.Name = "sheet1";

            //    string query = "SELECT Id, MaDanToc, TenDanToc, MoTa, NgayTao, NguoiTao, NgayCapNhat, NguoiCapNhat, DelFlg FROM mst_DanToc where DelFlg = 0";
            //    SqlDataReader reader = SQLHelper.ExecuteReader(query);

            //    // Tiêu đề
            //    worksheet.Cells[1, 1] = "MaDanToc";
            //    worksheet.Cells[1, 2] = "TenDanToc";
            //    worksheet.Cells[1, 3] = "MoTa";
            //    worksheet.Cells[1, 4] = "NgayTao";
            //    worksheet.Cells[1, 5] = "NguoiTao";
            //    worksheet.Cells[1, 6] = "NgayCapNhat";
            //    worksheet.Cells[1, 7] = "NguoiCapNhat";

            //    int row = 2;
            //    while (reader.Read())
            //    {
            //        worksheet.Cells[row, 1] = reader["MaDanToc"].ToString();
            //        worksheet.Cells[row, 2] = reader["TenDanToc"].ToString();
            //        worksheet.Cells[row, 3] = reader["MoTa"] != DBNull.Value ? reader["MoTa"].ToString() : "";
            //        worksheet.Cells[row, 4] = reader["NgayTao"] != DBNull.Value ? reader["NgayTao"].ToString() : "";
            //        worksheet.Cells[row, 5] = reader["NguoiTao"].ToString();
            //        worksheet.Cells[row, 6] = reader["NgayCapNhat"] != DBNull.Value ? reader["NgayCapNhat"].ToString() : "";
            //        worksheet.Cells[row, 7] = reader["NguoiCapNhat"].ToString();
            //        row++;
            //    }
            //    reader.Close();
            //    for (int i = 1; i <= 7; i++)
            //    {
            //        worksheet.Columns[i].AutoFit();
            //    }
            //    workbook.SaveAs(filePath);
            //    workbook.Close(false);
            //    excelApp.Quit();
            //    RJMessageBox.Show("Xuất dữ liệu thành công! File đã được lưu vào Desktop.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);

            //}
            //catch (Exception ex)
            //{
            //    RJMessageBox.Show(ex.Message, "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            //}
        }
        private void btn_import_Click(object sender, EventArgs e)
        {
            //try
            //{
            //    OpenFileDialog openFileDialog = new OpenFileDialog
            //    {
            //        Filter = "Excel Files|*.xls;*.xlsx;*.xlsm",
            //        Title = "Chọn file Excel để nhập dữ liệu"
            //    };

            //    if (openFileDialog.ShowDialog() == DialogResult.OK)
            //    {
            //        KillExcelProcesses(Path.GetFileName(openFileDialog.FileName));

            //        Excel.Application excelApp = new Excel.Application();
            //        Excel.Workbook workbook = excelApp.Workbooks.Open(openFileDialog.FileName);
            //        Excel._Worksheet worksheet = workbook.Sheets[1];
            //        Excel.Range range = worksheet.UsedRange;

            //        int res = 0;
            //        for (int row = 2; row <= range.Rows.Count; row++)
            //        {
            //            string maDanToc = range.Cells[row, 1].Value != null ? range.Cells[row, 1].Value.ToString() : "";
            //            string tenDanToc = range.Cells[row, 2].Value != null ? range.Cells[row, 2].Value.ToString() : "";
            //            string moTa = range.Cells[row, 3].Value != null ? range.Cells[row, 3].Value.ToString() : "";

            //            string checkQuery = "SELECT COUNT(*) FROM mst_DanToc WHERE MaDanToc = @MaDanToc AND DelFlg = 0";
            //            var checkParams = new List<SqlParameter>
            //        {
            //            new SqlParameter("@MaDanToc", maDanToc)
            //        };

            //            int count = (int)SQLHelper.ExecuteScalarSql(checkQuery, checkParams.ToArray());

            //            if (count > 0) // Nếu mã dân tộc tồn tại, cập nhật dữ liệu
            //            {
            //                string sqlUpdate = @"UPDATE mst_DanToc
            //                        SET 
            //                            TenDanToc = @TenDanToc,
            //                            MoTa = @MoTa,
            //                            NgayCapNhat = @NgayCapNhat,
            //                            NguoiCapNhat = @NguoiCapNhat
            //                        WHERE 
            //                            MaDanToc = @MaDanToc AND DelFlg = 0";

            //                var updateParams = new List<SqlParameter>
            //            {
            //                new SqlParameter("@MaDanToc", maDanToc),
            //                new SqlParameter("@TenDanToc", tenDanToc),
            //                new SqlParameter("@MoTa", moTa),
            //                new SqlParameter("@NgayCapNhat", DateTime.Now),
            //                new SqlParameter("@NguoiCapNhat", SQLHelper.sUser)
            //            };
            //                res += SQLHelper.ExecuteSql(sqlUpdate, updateParams.ToArray());
            //            }
            //            else 
            //            {
            //                string newMaDanToc = autoCodeGenerator.GenerateNextCode("mst_DanToc", "DT", "MaDanToc");

            //                string sqlInsert = @"INSERT INTO mst_DanToc(MaDanToc, TenDanToc, MoTa, NgayTao, NguoiTao, NgayCapNhat, NguoiCapNhat, DelFlg)
            //                        VALUES(@MaDanToc, @TenDanToc, @MoTa, @NgayTao, @NguoiTao, @NgayCapNhat, @NguoiCapNhat, 0)";

            //                var insertParams = new List<SqlParameter>
            //            {
            //                new SqlParameter("@MaDanToc", newMaDanToc),
            //                new SqlParameter("@TenDanToc", tenDanToc),
            //                new SqlParameter("@MoTa", moTa),
            //                new SqlParameter("@NgayTao", DateTime.Now),
            //                new SqlParameter("@NguoiTao", SQLHelper.sUser),
            //                new SqlParameter("@NgayCapNhat", DateTime.Now),
            //                new SqlParameter("@NguoiCapNhat", SQLHelper.sUser)
            //            };
            //                res += SQLHelper.ExecuteSql(sqlInsert, insertParams.ToArray());
            //            }
            //        }

            //        workbook.Close(false);
            //        excelApp.Quit();
            //        if (res > 0)
            //        {
            //            RJMessageBox.Show("Cập nhật dữ liệu thành công.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            //        }
            //    }
            //    load_dataDanToc();
            //}
            //catch(Exception ex)
            //{
            //    RJMessageBox.Show(ex.Message, "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            //}
        }
        private void dgv_nation_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0 && e.ColumnIndex == dgv_nation.Columns["edit_column"].Index)
            {
                string MaDanToc = dgv_nation.CurrentRow.Cells["MaDanToc"].Value.ToString();
                string TenDanToc = dgv_nation.CurrentRow.Cells["TenDanToc"].Value.ToString();
                string MoTa = dgv_nation.CurrentRow.Cells["MoTa"].Value.ToString();
                frmMstDanToc frmMstDanToc = new frmMstDanToc(MaDanToc, TenDanToc, MoTa, false, this);
                frmMstDanToc.ShowDialog();
            }
        }
        private void btn_close_Click(object sender, EventArgs e)
        {
            Control x = this.Parent;
            x.Controls.Remove(this);
        }
        private void btn_add_Click(object sender, EventArgs e)
        {
            frmMstDanToc frmMstDanToc = new frmMstDanToc(null, null, null, true, this);
            frmMstDanToc.ShowDialog();
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