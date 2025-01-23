using NPOI.HSSF.UserModel;
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
using TENTAC_HRM.Consts;
using TENTAC_HRM.Custom;
using TENTAC_HRM.Forms.Mst_Add_Data;

namespace TENTAC_HRM.Forms.User_control
{
    public partial class uc_position : UserControl
    {
        public static uc_position _instance;
        private static MstMaTuDong autoCodeGenerator = new MstMaTuDong();
        public static uc_position Instance
        {
            get
            {
                if (_instance == null)
                    _instance = new uc_position();
                return _instance;
            }
        }
        public uc_position()
        {
            InitializeComponent();
            LoadData();
        }
        public void LoadData()
        {
            string sql = "select MaChucVu, TenChucVu, MoTa, NgayTao, NguoiTao, NgayCapNhat, NguoiCapNhat from mst_ChucVu where del_flg = 0 order by MaChucVu";
            DataTable dt = new DataTable();
            dt = SQLHelper.ExecuteDt(sql);
            dgv_position.DataSource = dt;
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
                dgv_position.EndEdit();
                List<string> updateQueries = new List<string>();

                for (int i = 0; i < dgv_position.Rows.Count; i++)
                {
                    DataGridViewRow row = dgv_position.Rows[i];

                    bool isChecked = row.Cells["check"].Value != DBNull.Value && row.Cells["check"].Value != null && Convert.ToBoolean(row.Cells["check"].Value);

                    if (isChecked)
                    {
                        string MaChucVu = row.Cells["MaChucVu"].Value?.ToString();
                        if (!string.IsNullOrEmpty(MaChucVu))
                        {
                            updateQueries.Add($@"Update mst_ChucVu set del_flg = 1 WHERE MaChucVu = N'{MaChucVu}' and del_flg = 0");
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
                string fileName = $"MstChucVu_{DateTime.Now.ToString("yyyyMMdd")}.xlsx";
                string filePath = Path.Combine(desktopPath, fileName);


                IWorkbook workbook = new XSSFWorkbook();
                ISheet worksheet = workbook.CreateSheet("ChucVu");

                IRow headerRow = worksheet.CreateRow(0);
                headerRow.CreateCell(0).SetCellValue("Mã Chức Vụ");
                headerRow.CreateCell(1).SetCellValue("Tên Chức Vụ");
                headerRow.CreateCell(2).SetCellValue("Mô Tả");
                headerRow.CreateCell(3).SetCellValue("Ngày Tạo");
                headerRow.CreateCell(4).SetCellValue("Người Tạo");
                headerRow.CreateCell(5).SetCellValue("Ngày Cập Nhật");
                headerRow.CreateCell(6).SetCellValue("Người Cập Nhật");
                int row = 1;

                foreach (DataGridViewRow dgvRow in dgv_position.Rows)
                {
                    if (!dgvRow.IsNewRow)
                    {
                        IRow dataRow = worksheet.CreateRow(row);
                        dataRow.CreateCell(0).SetCellValue(dgvRow.Cells["MaChucVu"].Value?.ToString() ?? "");
                        dataRow.CreateCell(1).SetCellValue(dgvRow.Cells["TenChucVu"].Value?.ToString() ?? "");
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
                    if (!fileName.StartsWith("MstChucVu_"))
                    {
                        RJMessageBox.Show("Tên file không hợp lệ. Vui lòng chọn file có tên bắt đầu bằng 'MstChucVu_'.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }
                    KillExcelProcesses(fileName);
                    Cursor.Current = Cursors.WaitCursor;
                    using (var fs = new FileStream(openFileDialog.FileName, FileMode.Open, FileAccess.Read))
                    {
                        IWorkbook workbook = openFileDialog.FileName.EndsWith(".xlsx") ? (IWorkbook)new XSSFWorkbook(fs) : new HSSFWorkbook(fs);
                        ISheet sheet = workbook.GetSheetAt(0);

                        if (sheet.SheetName != "ChucVu")
                        {
                            RJMessageBox.Show("Tên sheet không hợp lệ. Vui lòng chọn file có sheet tên là 'ChucVu'.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            return;
                        }
                        int res = 0;

                        for (int row = 1; row <= sheet.LastRowNum; row++)
                        {
                            IRow currentRow = sheet.GetRow(row);
                            if (currentRow == null) continue;

                            string _MaChucVu = currentRow.GetCell(0)?.ToString() ?? "";
                            string _TenChucVu = currentRow.GetCell(1)?.ToString() ?? "";
                            string _MoTa = currentRow.GetCell(2)?.ToString() ?? "";

                            string checkQuery = $@"SELECT COUNT(*) FROM mst_ChucVu WHERE MaChucVu = {SQLHelper.rpStr(_MaChucVu)} and del_flg = 0";
                            int count = (int)SQLHelper.ExecuteScalarSql(checkQuery);

                            if (count > 0)
                            {
                                string sqlUpdate = $@"UPDATE mst_ChucVu 
                                    SET TenChucVu = {SQLHelper.rpStr(_TenChucVu)}, 
                                    MoTa = {SQLHelper.rpStr(_MoTa)},
                                    NgayCapNhat = '{DateTime.Now}',
                                    NguoiCapNhat = {SQLHelper.rpStr(LoginInfo.UserCd)}
                                    WHERE MaChucVu = {SQLHelper.rpStr(_MaChucVu)} and del_flg = 0";
                                res += SQLHelper.ExecuteSql(sqlUpdate);
                            }
                            else
                            {
                                string newMaChucVu = autoCodeGenerator.GenerateNextMaChucVu();
                                string sqlInsert = $@"INSERT INTO mst_ChucVu(MaChucVu, TenChucVu, MoTa, NgayTao, NguoiTao, NgayCapNhat, NguoiCapNhat, del_flg) 
                                                VALUES({SQLHelper.rpStr(newMaChucVu)}, {SQLHelper.rpStr(_TenChucVu)}, {SQLHelper.rpStr(_MoTa)}, '{DateTime.Now}',
                                                {SQLHelper.rpStr(LoginInfo.UserCd)}, '{DateTime.Now}', {SQLHelper.rpStr(LoginInfo.UserCd)}, 0)";
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
        private void dgv_position_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0 && e.ColumnIndex == dgv_position.Columns["edit_column"].Index)
            {
                string MaChucVu = dgv_position.CurrentRow.Cells["MaChucVu"].Value.ToString();
                frmMstChucVu frmMstChucVu = new frmMstChucVu(this);
                frmMstChucVu._MaChucVu = MaChucVu;
                frmMstChucVu._Edit = true;
                frmMstChucVu.ShowDialog();
            }
        }
        private void btn_close_Click(object sender, EventArgs e)
        {
            Control x = this.Parent;
            x.Controls.Remove(this);
        }
        private void btn_add_Click(object sender, EventArgs e)
        {
            frmMstChucVu frmMstChucVu = new frmMstChucVu(this);
            frmMstChucVu._Edit = false;
            frmMstChucVu.ShowDialog();
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
