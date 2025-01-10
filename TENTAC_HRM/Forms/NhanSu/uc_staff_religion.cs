using NPOI.SS.UserModel;
using NPOI.XSSF.UserModel;
using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Windows.Forms;
using TENTAC_HRM.Common;
using TENTAC_HRM.Custom;
using TENTAC_HRM.Forms.Mst_Add_Data;
namespace TENTAC_HRM.Forms.NhanSu
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
            LoadData();
        }
        public void LoadData()
        {
            string sql = "select Id, MaTonGiao, TenTonGiao, MoTa, NgayTao, NguoiTao, NgayCapNhat, NguoiCapNhat from mst_TonGiao where del_flg = 0";
            DataTable dt = new DataTable();
            dt = SQLHelper.ExecuteDt(sql);
            dgv_religion.DataSource = dt;
        }
        private void uc_staff_religion_Load(object sender, EventArgs e)
        {
            LoadData();
        }
        private void btn_delete_Click(object sender, EventArgs e)
        {
            DialogResult result = RJMessageBox.Show("Bạn có chắc chắn muốn xoá các mục đã chọn không?",
                                                "Xác nhận",
                                                MessageBoxButtons.YesNo,
                                                MessageBoxIcon.Question);

            if (result != DialogResult.Yes)
            {
                return;
            }
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
                            updateQueries.Add($@"UPDATE mst_TonGiao SET del_flg = 1 WHERE MaTonGiao = N'{MaTonGiao}'");
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
                string desktopPath = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);
                string fileName = $"MstTonGiao_{DateTime.Now:yyyyMMdd}.xlsx";
                string filePath = Path.Combine(desktopPath, fileName);

                IWorkbook workbook = new XSSFWorkbook();
                ISheet worksheet = workbook.CreateSheet("TonGiao");

                IRow headerRow = worksheet.CreateRow(0);
                headerRow.CreateCell(0).SetCellValue("Mã Tôn Giáo");
                headerRow.CreateCell(1).SetCellValue("Tên Tôn Giáo");
                headerRow.CreateCell(2).SetCellValue("Mô Tả");
                headerRow.CreateCell(3).SetCellValue("Ngày Tạo");
                headerRow.CreateCell(4).SetCellValue("Người Tạo");
                headerRow.CreateCell(5).SetCellValue("Ngày Cập Nhật");
                headerRow.CreateCell(6).SetCellValue("Người Cập Nhật");

                int row = 1;
                foreach (DataGridViewRow dgvRow in dgv_religion.Rows)
                {
                    if (!dgvRow.IsNewRow)
                    {
                        IRow dataRow = worksheet.CreateRow(row);
                        dataRow.CreateCell(0).SetCellValue(dgvRow.Cells["MaTonGiao"].Value?.ToString() ?? "");
                        dataRow.CreateCell(1).SetCellValue(dgvRow.Cells["TenTonGiao"].Value?.ToString() ?? "");
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

                workbook.Dispose();

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
                    if (!fileName.StartsWith("MstTonGiao_"))
                    {
                        RJMessageBox.Show("Tên file không hợp lệ. Vui lòng chọn file có tên bắt đầu bằng 'MstTonGiao_'.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }

                    KillExcelProcesses(Path.GetFileName(openFileDialog.FileName));

                    using (FileStream fs = new FileStream(openFileDialog.FileName, FileMode.Open, FileAccess.Read))
                    {
                        IWorkbook workbook = new XSSFWorkbook(fs);
                        ISheet sheet = workbook.GetSheetAt(0);

                        if (sheet.SheetName != "TonGiao")
                        {
                            RJMessageBox.Show("Tên sheet không hợp lệ. Vui lòng chọn file có sheet tên là 'TonGiao'.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            return;
                        }
                        int res = 0;

                        for (int row = 1; row <= sheet.LastRowNum; row++)
                        {
                            IRow dataRow = sheet.GetRow(row);
                            if (dataRow == null) continue;

                            string _MaTonGiao = dataRow.GetCell(0)?.ToString() ?? "";
                            string _TenTonGiao = dataRow.GetCell(1)?.ToString() ?? "";
                            string _MoTa = dataRow.GetCell(2)?.ToString() ?? "";

                            string checkQuery = $@"SELECT COUNT(*) FROM mst_TonGiao WHERE MaTonGiao = {SQLHelper.rpStr(_MaTonGiao)} AND del_flg = 0";

                            int count = (int)SQLHelper.ExecuteScalarSql(checkQuery);

                            if (count > 0)
                            {
                                string sqlUpdate = $@"UPDATE mst_TonGiao
                                        SET 
                                            TenTonGiao = {SQLHelper.rpStr(_TenTonGiao)},
                                            MoTa = {SQLHelper.rpStr(_MoTa)},
                                            NgayCapNhat = '{DateTime.Now}',
                                            NguoiCapNhat = {SQLHelper.rpStr(SQLHelper.sUser)}
                                        WHERE 
                                            MaTonGiao = {SQLHelper.rpStr(_MaTonGiao)} AND del_flg = 0";

                                res += SQLHelper.ExecuteSql(sqlUpdate);
                            }
                            else
                            {
                                string newMaTonGiao = autoCodeGenerator.GenerateNextCode("mst_TonGiao", "TG", "MaTonGiao");

                                string sqlInsert = $@"INSERT INTO mst_TonGiao(MaTonGiao, TenTonGiao, MoTa, NgayTao, NguoiTao, NgayCapNhat, NguoiCapNhat, del_flg)
                                        VALUES({SQLHelper.rpStr(newMaTonGiao)}, {SQLHelper.rpStr(_TenTonGiao)}, {SQLHelper.rpStr(_MoTa)}, '{DateTime.Now}',
                                        {SQLHelper.rpStr(SQLHelper.sUser)}, '{DateTime.Now}', {SQLHelper.rpStr(SQLHelper.sUser)}, 0)";

                                res += SQLHelper.ExecuteSql(sqlInsert);
                            }
                        }

                        if (res > 0)
                        {
                            RJMessageBox.Show("Cập nhật dữ liệu thành công.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                    }
                    LoadData();
                }
            }
            catch (Exception ex)
            {
                RJMessageBox.Show(ex.Message, "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void dgv_religion_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0 && e.ColumnIndex == dgv_religion.Columns["edit_column"].Index)
            {
                string MaTonGiao = dgv_religion.CurrentRow.Cells["MaTonGiao"].Value.ToString();
                frmMstTonGiao frmMstTonGiao = new frmMstTonGiao(this);
                frmMstTonGiao._MaTonGiao = MaTonGiao;
                frmMstTonGiao._Edit = true;
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
            frmMstTonGiao frmMstTonGiao = new frmMstTonGiao(this);
            frmMstTonGiao._Edit = false;
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
