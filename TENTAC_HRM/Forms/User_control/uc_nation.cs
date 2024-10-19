using NPOI.HSSF.UserModel;
using NPOI.SS.UserModel;
using NPOI.XSSF.UserModel;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.IO;
using System.Windows.Forms;
using TENTAC_HRM.Common;
using TENTAC_HRM.Custom;
using TENTAC_HRM.Forms.Mst_Add_Data;

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
            //dgv_nation.EnableHeadersVisualStyles = false;

            //dgv_nation.EnableHeadersVisualStyles = false; // Tắt visual styles
            //dgv_nation.CellPainting += gridView_CellPainting; // Đăng ký sự kiện vẽ tiêu đề

            string sql = "select Id, MaDanToc,TenDanToc, MoTa, NgayCapNhat, NguoiCapNhat from mst_DanToc where DelFlg = 0 order by MaDanToc";
            DataTable dt = new DataTable();
            dt = SQLHelper.ExecuteDt(sql);
            dgv_nation.DataSource = dt;
        }
        //private void gridView_CellPainting(object sender, DataGridViewCellPaintingEventArgs e)
        //{
        //    if (e.RowIndex == -1 && e.ColumnIndex >= 0)
        //    {
        //        e.Graphics.FillRectangle(new SolidBrush(Color.FromArgb(81, 124, 255)), e.CellBounds); // Nền tiêu đề
        //        e.Graphics.DrawRectangle(Pens.Gainsboro, e.CellBounds); // Đường viền

        //        Font headerFont = new Font(Font.FontFamily, 11); // Font in đậm
        //        TextRenderer.DrawText(e.Graphics, e.FormattedValue.ToString(), headerFont, e.CellBounds, Color.White, TextFormatFlags.HorizontalCenter | TextFormatFlags.VerticalCenter);

        //        e.Handled = true;
        //    }
        //}
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
            try
            {
                string desktopPath = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);
                string fileName = $"MstDanToc_{DateTime.Now.ToString("yyyyMMdd")}.xlsx";
                string filePath = Path.Combine(desktopPath, fileName);

                KillExcelProcesses(fileName); 

                IWorkbook workbook = new XSSFWorkbook();
                ISheet worksheet = workbook.CreateSheet("DanToc");

                IRow headerRow = worksheet.CreateRow(0);
                headerRow.CreateCell(0).SetCellValue("Mã Dân Tộc");
                headerRow.CreateCell(1).SetCellValue("Tên Dân Tộc");
                headerRow.CreateCell(2).SetCellValue("Mô Tả");
                headerRow.CreateCell(3).SetCellValue("Ngày Tạo");
                headerRow.CreateCell(4).SetCellValue("Người Tạo");
                headerRow.CreateCell(5).SetCellValue("Ngày Cập Nhật");
                headerRow.CreateCell(6).SetCellValue("Người Cập Nhật");

                string query = "SELECT Id, MaDanToc, TenDanToc, MoTa, NgayTao, NguoiTao, NgayCapNhat, NguoiCapNhat, DelFlg FROM mst_DanToc WHERE DelFlg = 0";
                SqlDataReader reader = SQLHelper.ExecuteReader(query);

                int row = 1;
                while (reader.Read())
                {
                    IRow dataRow = worksheet.CreateRow(row);
                    dataRow.CreateCell(0).SetCellValue(reader["MaDanToc"].ToString());
                    dataRow.CreateCell(1).SetCellValue(reader["TenDanToc"].ToString());
                    dataRow.CreateCell(2).SetCellValue(reader["MoTa"] != DBNull.Value ? reader["MoTa"].ToString() : "");
                    dataRow.CreateCell(3).SetCellValue(reader["NgayTao"] != DBNull.Value ? reader["NgayTao"].ToString() : "");
                    dataRow.CreateCell(4).SetCellValue(reader["NguoiTao"].ToString());
                    dataRow.CreateCell(5).SetCellValue(reader["NgayCapNhat"] != DBNull.Value ? reader["NgayCapNhat"].ToString() : "");
                    dataRow.CreateCell(6).SetCellValue(reader["NguoiCapNhat"].ToString());
                    row++;
                }
                reader.Close();

                for (int i = 0; i < 7; i++)
                {
                    worksheet.AutoSizeColumn(i);
                }

                using (FileStream stream = new FileStream(filePath, FileMode.Create, FileAccess.Write))
                {
                    workbook.Write(stream);
                }

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
                    if (!fileName.StartsWith("MstDanToc_"))
                    {
                        RJMessageBox.Show("Tên file không hợp lệ. Vui lòng chọn file có tên bắt đầu bằng 'MstDanToc_'.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }

                    KillExcelProcesses(Path.GetFileName(openFileDialog.FileName));

                    using (FileStream fs = new FileStream(openFileDialog.FileName, FileMode.Open, FileAccess.Read))
                    {

                        IWorkbook workbook = openFileDialog.FileName.EndsWith(".xlsx") ? (IWorkbook)new XSSFWorkbook(fs) : new HSSFWorkbook(fs);
                        ISheet sheet = workbook.GetSheetAt(0);

                        if (sheet.SheetName != "DanToc")
                        {
                            RJMessageBox.Show("Tên sheet không hợp lệ. Vui lòng chọn file có sheet tên là 'DanToc'.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            return;
                        }
                        int res = 0;

                        for (int row = 1; row <= sheet.LastRowNum; row++)
                        {
                            IRow currentRow = sheet.GetRow(row);
                            if (currentRow == null) continue;

                            string maDanToc = currentRow.GetCell(0)?.ToString() ?? "";
                            string tenDanToc = currentRow.GetCell(1)?.ToString() ?? "";
                            string moTa = currentRow.GetCell(2)?.ToString() ?? "";

                            string checkQuery = "SELECT COUNT(*) FROM mst_DanToc WHERE MaDanToc = @MaDanToc AND DelFlg = 0";
                            var checkParams = new List<SqlParameter>
                            {
                                new SqlParameter("@MaDanToc", maDanToc)
                            };

                            int count = (int)SQLHelper.ExecuteScalarSql(checkQuery, checkParams.ToArray());

                            if (count > 0)
                            {
                                string sqlUpdate = @"UPDATE mst_DanToc
                                        SET 
                                            TenDanToc = @TenDanToc,
                                            MoTa = @MoTa,
                                            NgayCapNhat = @NgayCapNhat,
                                            NguoiCapNhat = @NguoiCapNhat
                                        WHERE 
                                            MaDanToc = @MaDanToc AND DelFlg = 0";

                                var updateParams = new List<SqlParameter>
                                {
                                    new SqlParameter("@MaDanToc", maDanToc),
                                    new SqlParameter("@TenDanToc", tenDanToc),
                                    new SqlParameter("@MoTa", moTa),
                                    new SqlParameter("@NgayCapNhat", DateTime.Now),
                                    new SqlParameter("@NguoiCapNhat", SQLHelper.sUser)
                                };
                                res += SQLHelper.ExecuteSql(sqlUpdate, updateParams.ToArray());
                            }
                            else
                            {
                                string newMaDanToc = autoCodeGenerator.GenerateNextCode("mst_DanToc", "DT", "MaDanToc");

                                string sqlInsert = @"INSERT INTO mst_DanToc(MaDanToc, TenDanToc, MoTa, NgayTao, NguoiTao, NgayCapNhat, NguoiCapNhat, DelFlg)
                                        VALUES(@MaDanToc, @TenDanToc, @MoTa, @NgayTao, @NguoiTao, @NgayCapNhat, @NguoiCapNhat, 0)";

                                var insertParams = new List<SqlParameter>
                                {
                                    new SqlParameter("@MaDanToc", newMaDanToc),
                                    new SqlParameter("@TenDanToc", tenDanToc),
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
                }
                load_dataDanToc();
            }
            catch (Exception ex)
            {
                RJMessageBox.Show(ex.Message, "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
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