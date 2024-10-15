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
namespace TENTAC_HRM.Forms.User_control
{
    public partial class uc_staff_religion : UserControl
    {
        public static uc_staff_religion _instance;
        public static uc_staff_religion Instance
        {
            get
            {
                if (_instance == null)
                    _instance = new uc_staff_religion();
                return _instance;
            }
        }
        private static MstMaTuDong autoCodeGenerator = new MstMaTuDong();
        public uc_staff_religion()
        {
            InitializeComponent();
            load_dataTonGiao();
        }
        public void load_dataTonGiao()
        {
            string sql = "select Id, MaTonGiao, TenTonGiao, MoTa,NgayCapNhat, NguoiCapNhat from mst_TonGiao where DelFlg = 0";
            DataTable dt = new DataTable();
            dt = SQLHelper.ExecuteDt(sql);
            dgv_religion.DataSource = dt;
        }
        private void uc_staff_religion_Load(object sender, EventArgs e)
        {
            load_dataTonGiao();
        }
        private void btn_delete_Click(object sender, EventArgs e)
        {
            dgv_religion.EndEdit();
            try
            {
                List<string> updateQueries = new List<string>();

                for (int i = 0; i < dgv_religion.Rows.Count; i++)
                {
                    DataGridViewRow row = dgv_religion.Rows[i];

                    bool isChecked = row.Cells["check"].Value != DBNull.Value && row.Cells["check"].Value != null && Convert.ToBoolean(row.Cells["check"].Value);

                    if (isChecked)
                    {
                        string MaTonGiao = row.Cells["MaTonGiao"].Value?.ToString();
                        if (!string.IsNullOrEmpty(MaTonGiao))
                        {
                            updateQueries.Add($@"UPDATE mst_TonGiao SET DelFlg = 1 WHERE MaTonGiao = N'{MaTonGiao}'");
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
                load_dataTonGiao();
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
            //    string fileName = $"MstTonGiao_{DateTime.Now.ToString("yyyyMMdd")}.xlsx";
            //    string filePath = Path.Combine(desktopPath, fileName);

            //    KillExcelProcesses(fileName);

            //    Excel.Application excelApp = new Excel.Application();
            //    Excel.Workbook workbook = excelApp.Workbooks.Add(Type.Missing);
            //    Excel._Worksheet worksheet = workbook.Sheets[1];
            //    worksheet.Name = "sheet1";

            //    string query = "SELECT Id, MaTonGiao, TenTonGiao, MoTa, NgayTao, NguoiTao, NgayCapNhat, NguoiCapNhat, DelFlg FROM mst_TonGiao where DelFlg = 0";
            //    SqlDataReader reader = SQLHelper.ExecuteReader(query);

            //    worksheet.Cells[1, 1] = "MaTonGiao";
            //    worksheet.Cells[1, 2] = "TenTonGiao";
            //    worksheet.Cells[1, 3] = "MoTa";
            //    worksheet.Cells[1, 4] = "NgayTao";
            //    worksheet.Cells[1, 5] = "NguoiTao";
            //    worksheet.Cells[1, 6] = "NgayCapNhat";
            //    worksheet.Cells[1, 7] = "NguoiCapNhat";

            //    int row = 2;
            //    while (reader.Read())
            //    {
            //        worksheet.Cells[row, 1] = reader["MaTonGiao"].ToString();
            //        worksheet.Cells[row, 2] = reader["TenTonGiao"].ToString();
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
            //            string maTonGiao = range.Cells[row, 1].Value != null ? range.Cells[row, 1].Value.ToString() : "";
            //            string tenTonGiao = range.Cells[row, 2].Value != null ? range.Cells[row, 2].Value.ToString() : "";
            //            string moTa = range.Cells[row, 3].Value != null ? range.Cells[row, 3].Value.ToString() : "";

            //            string checkQuery = "SELECT COUNT(*) FROM mst_TonGiao WHERE MaTonGiao = @MaTonGiao AND DelFlg = 0";
            //            var checkParams = new List<SqlParameter>
            //        {
            //            new SqlParameter("@MaTonGiao", maTonGiao)
            //        };

            //            int count = (int)SQLHelper.ExecuteScalarSql(checkQuery, checkParams.ToArray());

            //            if (count > 0) 
            //            {
            //                string sqlUpdate = @"UPDATE mst_TonGiao
            //                        SET 
            //                            TenTonGiao = @TenTonGiao,
            //                            MoTa = @MoTa,
            //                            NgayCapNhat = @NgayCapNhat,
            //                            NguoiCapNhat = @NguoiCapNhat
            //                        WHERE 
            //                            MaTonGiao = @MaTonGiao AND DelFlg = 0";

            //                var updateParams = new List<SqlParameter>
            //            {
            //                new SqlParameter("@MaTonGiao", maTonGiao),
            //                new SqlParameter("@TenTonGiao", tenTonGiao),
            //                new SqlParameter("@MoTa", moTa),
            //                new SqlParameter("@NgayCapNhat", DateTime.Now),
            //                new SqlParameter("@NguoiCapNhat", SQLHelper.sUser)
            //            };
            //                res += SQLHelper.ExecuteSql(sqlUpdate, updateParams.ToArray());
            //            }
            //            else
            //            {
            //                string newMaTonGiao = autoCodeGenerator.GenerateNextCode("mst_TonGiao", "TG", "MaTonGiao");

            //                string sqlInsert = @"INSERT INTO mst_TonGiao(MaTonGiao, TenTonGiao, MoTa, NgayTao, NguoiTao, NgayCapNhat, NguoiCapNhat, DelFlg)
            //                        VALUES(@MaTonGiao, @TenTonGiao, @MoTa, @NgayTao, @NguoiTao, @NgayCapNhat, @NguoiCapNhat, 0)";

            //                var insertParams = new List<SqlParameter>
            //            {
            //                new SqlParameter("@MaTonGiao", newMaTonGiao),
            //                new SqlParameter("@TenTonGiao", tenTonGiao),
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
            //    load_dataTonGiao();
            //}
            //catch (Exception ex)
            //{
            //    RJMessageBox.Show(ex.Message, "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            //}
        }

        private void dgv_religion_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0 && e.ColumnIndex == dgv_religion.Columns["edit_column"].Index)
            {
                string MaTonGiao = dgv_religion.CurrentRow.Cells["MaTonGiao"].Value.ToString();
                string TenTonGiao = dgv_religion.CurrentRow.Cells["TenTonGiao"].Value.ToString();
                string MoTa = dgv_religion.CurrentRow.Cells["MoTa"].Value.ToString();
                frmMstTonGiao frmMstTonGiao = new frmMstTonGiao(MaTonGiao, TenTonGiao, MoTa, false, this);
                frmMstTonGiao.ShowDialog();
            }
        }

        private void btn_close_Click(object sender, EventArgs e)
        {
            Control x = this.Parent;
            x.Controls.Remove(this);
        }

        private void btn_add_Click(object sender, EventArgs e)
        {
            frmMstTonGiao frmMstTonGiao = new frmMstTonGiao(null, null, null, true, this);
            frmMstTonGiao.ShowDialog();
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
                    RJMessageBox.Show(ex.Message, "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }
    }
}
