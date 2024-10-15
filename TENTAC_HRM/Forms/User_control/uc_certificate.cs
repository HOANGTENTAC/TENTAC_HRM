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
using TENTAC_HRM.User_control;
using Excel = Microsoft.Office.Interop.Excel;
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
            load_dataChungChiNghe();
        }
        public void load_dataChungChiNghe()
        {
            string sql = "select Id, MaChungChi,TenChungChi, MoTa, NgayCapNhat, NguoiCapNhat from mst_ChungChi where DelFlg = 0 order by MaChungChi";
            DataTable dt = new DataTable();
            dt = SQLHelper.ExecuteDt(sql);
            dgv_certificate.DataSource = dt;
        }
        private void uc_certificate_Load(object sender, EventArgs e)
        {
            //pl_nation.Width = 0;
            load_dataChungChiNghe();
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
                load_dataChungChiNghe();
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
                string fileName = $"MstChungChi_{DateTime.Now.ToString("yyyyMMdd")}.xlsx";
                string filePath = Path.Combine(desktopPath, fileName);

                KillExcelProcesses(fileName);

                Excel.Application excelApp = new Excel.Application();
                Excel.Workbook workbook = excelApp.Workbooks.Add(Type.Missing);
                Excel._Worksheet worksheet = workbook.Sheets[1];
                worksheet.Name = "sheet1";

                string query = "SELECT Id, MaChungChi, TenChungChi, MoTa, NgayTao, NguoiTao, NgayCapNhat, NguoiCapNhat, DelFlg FROM mst_ChungChi where DelFlg = 0";
                SqlDataReader reader = SQLHelper.ExecuteReader(query);

                // Tiêu đề
                worksheet.Cells[1, 1] = "MaChungChi";
                worksheet.Cells[1, 2] = "TenChungChi";
                worksheet.Cells[1, 3] = "MoTa";
                worksheet.Cells[1, 4] = "NgayTao";
                worksheet.Cells[1, 5] = "NguoiTao";
                worksheet.Cells[1, 6] = "NgayCapNhat";
                worksheet.Cells[1, 7] = "NguoiCapNhat";

                int row = 2;
                while (reader.Read())
                {
                    worksheet.Cells[row, 1] = reader["MaChungChi"].ToString();
                    worksheet.Cells[row, 2] = reader["TenChungChi"].ToString();
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
                        string maChungChi = range.Cells[row, 1].Value != null ? range.Cells[row, 1].Value.ToString() : "";
                        string tenChungChi = range.Cells[row, 2].Value != null ? range.Cells[row, 2].Value.ToString() : "";
                        string moTa = range.Cells[row, 3].Value != null ? range.Cells[row, 3].Value.ToString() : "";

                        string checkQuery = "SELECT COUNT(*) FROM mst_ChungChi WHERE MaChungChi = @MaChungChi AND DelFlg = 0";
                        var checkParams = new List<SqlParameter>
                    {
                        new SqlParameter("@MaChungChi", maChungChi)
                    };

                        int count = (int)SQLHelper.ExecuteScalarSql(checkQuery, checkParams.ToArray());

                        if (count > 0)
                        {
                            string sqlUpdate = @"UPDATE mst_ChungChi
                                    SET 
                                        TenChungChi = @TenChungChi,
                                        MoTa = @MoTa,
                                        NgayCapNhat = @NgayCapNhat,
                                        NguoiCapNhat = @NguoiCapNhat
                                    WHERE 
                                        MaChungChi = @MaChungChi AND DelFlg = 0";

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

                            string sqlInsert = @"INSERT INTO mst_ChungChi(MaChungChi, TenChungChi, MoTa, NgayTao, NguoiTao, NgayCapNhat, NguoiCapNhat, DelFlg)
                                    VALUES(@MaChungChi, @TenChungChi, @MoTa, @NgayTao, @NguoiTao, @NgayCapNhat, @NguoiCapNhat, 0)";

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

                    workbook.Close(false);
                    excelApp.Quit();
                    if (res > 0)
                    {
                        RJMessageBox.Show("Cập nhật dữ liệu thành công.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
                load_dataChungChiNghe();
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
