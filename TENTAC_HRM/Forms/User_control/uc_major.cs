using DevComponents.DotNetBar.Controls;
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
using Excel = Microsoft.Office.Interop.Excel;

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
            load_dataChuyenNganh();
        }
        public void load_dataChuyenNganh()
        {
            string sql = "select Id, MaChuyenNganh, TenChuyenNganh, MoTa, NgayCapNhat, NguoiCapNhat from mst_ChuyenNganh where DelFlg = 0 order by MaChuyenNganh";
            DataTable dt = new DataTable();
            dt = SQLHelper.ExecuteDt(sql);
            dgv_major.DataSource = dt;
        }
        private void btn_delete_Click(object sender, EventArgs e)
        {
            try
            {
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
                            updateQueries.Add($@"UPDATE mst_ChuyenNganh SET DelFlg = 1 WHERE MaChuyenNganh = N'{MaNgoaiNgu}'");
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
                load_dataChuyenNganh();
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
                string desktopPath = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);
                string fileName = $"MstChuyenNganh_{DateTime.Now.ToString("yyyyMMdd")}.xlsx";
                string filePath = Path.Combine(desktopPath, fileName);

                KillExcelProcesses(fileName);

                Excel.Application excelApp = new Excel.Application();
                Excel.Workbook workbook = excelApp.Workbooks.Add(Type.Missing);
                Excel._Worksheet worksheet = workbook.Sheets[1];
                worksheet.Name = "sheet1";

                string query = "SELECT Id, MaChuyenNganh, TenChuyenNganh, MoTa, NgayTao, NguoiTao, NgayCapNhat, NguoiCapNhat, DelFlg FROM mst_ChuyenNganh where DelFlg = 0";
                SqlDataReader reader = SQLHelper.ExecuteReader(query);

                // Tiêu đề
                worksheet.Cells[1, 1] = "MaChuyenNganh";
                worksheet.Cells[1, 2] = "TenChuyenNganh";
                worksheet.Cells[1, 3] = "MoTa";
                worksheet.Cells[1, 4] = "NgayTao";
                worksheet.Cells[1, 5] = "NguoiTao";
                worksheet.Cells[1, 6] = "NgayCapNhat";
                worksheet.Cells[1, 7] = "NguoiCapNhat";

                int row = 2;
                while (reader.Read())
                {
                    worksheet.Cells[row, 1] = reader["MaChuyenNganh"].ToString();
                    worksheet.Cells[row, 2] = reader["TenChuyenNganh"].ToString();
                    worksheet.Cells[row, 3] = reader["MoTa"] != DBNull.Value ? reader["MoTa"].ToString() : "";
                    worksheet.Cells[row, 4] = reader["NgayTao"] != DBNull.Value ? reader["NgayTao"].ToString() : "";
                    worksheet.Cells[row, 5] = reader["NguoiTao"].ToString();
                    worksheet.Cells[row, 6] = reader["NgayCapNhat"] != DBNull.Value ? reader["NgayCapNhat"].ToString() : "";
                    worksheet.Cells[row, 7] = reader["NguoiCapNhat"].ToString();
                    row++;
                }
                reader.Close();
                for (int i = 1; i <= 7; i++)
                {
                    worksheet.Columns[i].AutoFit();
                }
                workbook.SaveAs(filePath);
                workbook.Close(false);
                excelApp.Quit();
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
                    KillExcelProcesses(Path.GetFileName(openFileDialog.FileName));

                    Excel.Application excelApp = new Excel.Application();
                    Excel.Workbook workbook = excelApp.Workbooks.Open(openFileDialog.FileName);
                    Excel._Worksheet worksheet = workbook.Sheets[1];
                    Excel.Range range = worksheet.UsedRange;

                    int res = 0;
                    for (int row = 2; row <= range.Rows.Count; row++)
                    {
                        string maChuyenNganh = range.Cells[row, 1].Value != null ? range.Cells[row, 1].Value.ToString() : "";
                        string tenChuyenNganh = range.Cells[row, 2].Value != null ? range.Cells[row, 2].Value.ToString() : "";
                        string moTa = range.Cells[row, 3].Value != null ? range.Cells[row, 3].Value.ToString() : "";

                        string checkQuery = "SELECT COUNT(*) FROM mst_ChuyenNganh WHERE MaChuyenNganh = @MaChuyenNganh AND DelFlg = 0";
                        var checkParams = new List<SqlParameter>
                        {
                            new SqlParameter("@MaChuyenNganh", maChuyenNganh)
                        };

                        int count = (int)SQLHelper.ExecuteScalarSql(checkQuery, checkParams.ToArray());

                        if (count > 0)
                        {
                            string sqlUpdate = @"UPDATE mst_ChuyenNganh
                                    SET 
                                        TenChuyenNganh = @TenChuyenNganh,
                                        MoTa = @MoTa,
                                        NgayCapNhat = @NgayCapNhat,
                                        NguoiCapNhat = @NguoiCapNhat
                                    WHERE 
                                        MaChuyenNganh = @MaChuyenNganh AND DelFlg = 0";

                            var updateParams = new List<SqlParameter>
                            {
                                new SqlParameter("@MaChuyenNganh", maChuyenNganh),
                                new SqlParameter("@TenChuyenNganh", tenChuyenNganh),
                                new SqlParameter("@MoTa", moTa),
                                new SqlParameter("@NgayCapNhat", DateTime.Now),
                                new SqlParameter("@NguoiCapNhat", SQLHelper.sUser)
                            };
                            res += SQLHelper.ExecuteSql(sqlUpdate, updateParams.ToArray());
                        }
                        else
                        {
                            string newMaChuyenNganh = autoCodeGenerator.GenerateNextCode("mst_ChuyenNganh", "CN", "MaChuyenNganh");

                            string sqlInsert = @"INSERT INTO mst_ChuyenNganh(MaChuyenNganh, TenChuyenNganh, MoTa, NgayTao, NguoiTao, NgayCapNhat, NguoiCapNhat, DelFlg)
                                    VALUES(@MaChuyenNganh, @TenChuyenNganh, @MoTa, @NgayTao, @NguoiTao, @NgayCapNhat, @NguoiCapNhat, 0)";

                            var insertParams = new List<SqlParameter>
                            {
                                new SqlParameter("@MaChuyenNganh", newMaChuyenNganh),
                                new SqlParameter("@TenChuyenNganh", tenChuyenNganh),
                                new SqlParameter("@MoTa", moTa),
                                new SqlParameter("@NgayTao", DateTime.Now),
                                new SqlParameter("@NguoiTao", SQLHelper.sUser),
                                new SqlParameter("@NgayCapNhat", DateTime.Now),
                                new SqlParameter("@NguoiCapNhat", SQLHelper.sUser)
                            };
                            res += SQLHelper.ExecuteSql(sqlInsert, insertParams.ToArray());
                        }
                    }

                    workbook.Close(false);
                    excelApp.Quit();
                    if (res > 0)
                    {
                        RJMessageBox.Show("Cập nhật dữ liệu thành công.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
                load_dataChuyenNganh();
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
            frmMstChuyenNganh frmMstChuyenNganh = new frmMstChuyenNganh(null, null, null, true, this);
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
                string TenChuyenNganh = dgv_major.CurrentRow.Cells["TenChuyenNganh"].Value.ToString();
                string MoTa = dgv_major.CurrentRow.Cells["MoTa"].Value.ToString();
                frmMstChuyenNganh frmMstChuyenNganh = new frmMstChuyenNganh(MaChuyenNganh, TenChuyenNganh, MoTa, false, this);
                frmMstChuyenNganh.ShowDialog();
            }
        }
    }
}