using NPOI.SS.UserModel;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Windows.Forms;
using TENTAC_HRM.Common;
using TENTAC_HRM.Custom;

namespace TENTAC_HRM.Forms.ChamCong
{
    public partial class frm_XoaGioTangCa : Form
    {
        public DataTable data { get; set; }
        public string year { get; set; }
        public string month { get; set; }
        public frm_XoaGioTangCa()
        {
            InitializeComponent();
        }

        private void frm_XoaGioTangCa_Load(object sender, EventArgs e)
        {
            List<int> dtyear = new List<int>();
            for (int i = 2016; i <= DateTime.Now.Year + 2; i++)
            {
                dtyear.Add(i);
            }
            cbo_year.DataSource = dtyear;
            cbo_year.Text = DateTime.Now.Year.ToString();
            List<int> dtmonth = new List<int>();
            for (int i = 1; i <= 12; i++)
            {
                dtmonth.Add(i);
            }
            cbo_month.DataSource = dtmonth;
            cbo_month.Text = DateTime.Now.Month.ToString();

            if (data != null)
            {
                cbo_year.Text = year;
                cbo_month.Text = month;
                dgv_data.Columns.Clear();
                DataGridViewTextBoxColumn macc = new DataGridViewTextBoxColumn();
                macc.HeaderText = "Mã CC";
                macc.Name = "MaChamCong";
                macc.DataPropertyName = "MaChamCong";
                macc.Width = 50;
                macc.Frozen = true;
                dgv_data.Columns.Add(macc);

                DataGridViewTextBoxColumn tennv = new DataGridViewTextBoxColumn();
                tennv.HeaderText = "Tên nhân viên";
                tennv.Name = "TenNhanVien";
                tennv.DataPropertyName = "TenNhanVien";
                tennv.Width = 150;
                tennv.Frozen = true;
                dgv_data.Columns.Add(tennv);

                DataGridViewTextBoxColumn tenpb = new DataGridViewTextBoxColumn();
                tenpb.HeaderText = "Tên Phòng ban";
                tenpb.Name = "TenPhongBan";
                tenpb.DataPropertyName = "TenPhongBan";
                tenpb.Width = 100;
                tenpb.Frozen = true;
                dgv_data.Columns.Add(tenpb);
                set_column_day();
                data.Columns.Remove("Tong");
                dgv_data.DataSource = data;
            }
        }

        private void btn_import_Click(object sender, EventArgs e)
        {
            Cursor.Current = Cursors.WaitCursor;
            dgv_data.Columns.Clear();
            DataGridViewTextBoxColumn macc = new DataGridViewTextBoxColumn();
            macc.HeaderText = "Mã CC";
            macc.Name = "MaChamCong";
            macc.DataPropertyName = "MaChamCong";
            macc.Width = 50;
            macc.Frozen = true;
            dgv_data.Columns.Add(macc);

            DataGridViewTextBoxColumn tennv = new DataGridViewTextBoxColumn();
            tennv.HeaderText = "Tên nhân viên";
            tennv.Name = "TenNhanVien";
            tennv.DataPropertyName = "TenNhanVien";
            tennv.Width = 150;
            tennv.Frozen = true;
            dgv_data.Columns.Add(tennv);

            DataGridViewTextBoxColumn tenpb = new DataGridViewTextBoxColumn();
            tenpb.HeaderText = "Tên Phòng ban";
            tenpb.Name = "TenPhongBan";
            tenpb.DataPropertyName = "TenPhongBan";
            tenpb.Width = 100;
            tenpb.Frozen = true;
            dgv_data.Columns.Add(tenpb);
            set_column_day();
            Read_Excel();
        }
        int _year;
        int _month;
        private void set_column_day()
        {
            _year = int.Parse(cbo_year.Text.ToString());
            _month = int.Parse(cbo_month.Text.ToString());
            int days = DateTime.DaysInMonth(_year, _month);

            for (int i = 1; i <= days; i++)
            {
                DataGridViewTextBoxColumn ngay = new DataGridViewTextBoxColumn();
                ngay.HeaderText = "Ngày " + i;
                ngay.Name = "Ngay" + i;
                ngay.DataPropertyName = "Ngay" + i;
                ngay.Width = 50;
                dgv_data.Columns.Add(ngay);
            }
        }
        private ISheet xlSheet = null;
        private void Read_Excel()
        {
            OpenFileDialog file = new OpenFileDialog(); //open dialog to choose file
            if (file.ShowDialog() == DialogResult.OK) //if there is a file chosen by the user
            {

                string fileExt = Path.GetExtension(file.FileName); //get the file extension
                if (fileExt.CompareTo(".xls") == 0 || fileExt.CompareTo(".xlsx") == 0)
                {
                    IWorkbook xlBook = null;
                    using (FileStream inputStream = new FileStream(file.FileName, FileMode.Open, FileAccess.Read))
                    {
                        xlBook = WorkbookFactory.Create(inputStream);
                    }
                    for (int i = 0; i < xlBook.NumberOfSheets; i++)
                    {
                        this.xlSheet = xlBook.GetSheetAt(i);
                        if (xlBook.IsSheetHidden(i))
                        {
                            continue;
                        }
                        string ngay = Range("B5", "string").TrimEnd();
                        int days = DateTime.DaysInMonth(_year, _month);
                        string[] col = new string[days + 3];
                        for (int j = 4; j <= 1000; j++)
                        {
                            if (Range1("B" + j.ToString()) == "")
                            {
                                break;
                            }
                            if (xlSheet.GetRow(j - 1).Hidden == true)
                            {
                                continue;
                            }
                            for (int x = 2; x <= days + 4; x++)
                            {
                                col[x - 2] = Range1(columns(x) + j.ToString());
                            }
                            dgv_data.Rows.Add(col);

                        }
                        //set_column_day(ngay, ngay);
                    }
                }
            }
        }
        private string columns(int i)
        {
            switch (i)
            {
                case 1:
                    return "A";
                case 2:
                    return "B";
                case 3:
                    return "C";
                case 4:
                    return "D";
                case 5:
                    return "E";
                case 6:
                    return "F";
                case 7:
                    return "G";
                case 8:
                    return "H";
                case 9:
                    return "I";
                case 10:
                    return "J";
                case 11:
                    return "K";
                case 12:
                    return "L";
                case 13:
                    return "M";
                case 14:
                    return "N";
                case 15:
                    return "O";
                case 16:
                    return "p";
                case 17:
                    return "Q";
                case 18:
                    return "R";
                case 19:
                    return "S";
                case 20:
                    return "T";
                case 21:
                    return "U";
                case 22:
                    return "V";
                case 23:
                    return "W";
                case 24:
                    return "X";
                case 25:
                    return "Y";
                case 26:
                    return "Z";
                case 27:
                    return "AA";
                case 28:
                    return "AB";
                case 29:
                    return "AC";
                case 30:
                    return "AD";
                case 31:
                    return "AE";
                case 32:
                    return "AF";
                case 33:
                    return "AG";
                case 34:
                    return "AH";
                case 35:
                    return "AI";
                default:
                    return "";
            }
        }
        private string Range1(string zahyo)
        {
            return XlsCommon.GetCellValue(zahyo, xlSheet);
        }
        private string Range(string zahyo, string type)
        {
            return XlsCommon.GetCellValue(zahyo, xlSheet, type);
        }
        private DataTable danhsachca()
        {
            string sql = $"select * from BangXepCa where Nam = '{cbo_year.SelectedValue}' and Thang = '{cbo_month.Text}'";
            DataTable data = new DataTable();
            data = SQLHelper.ExecuteDt(sql);
            return data;
        }

        private void btn_save_Click(object sender, EventArgs e)
        {
            var diag = RJMessageBox.Show($"Bạn có chắc muốn xóa giờ chấm công tháng {cbo_month.Text} năm {cbo_year.Text}?", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
            if (diag == DialogResult.Yes)
            {
                Cursor.Current = Cursors.WaitCursor;
                DataTable dt = new DataTable();
                dt = danhsachca();

                DataTable dt_calamviec = new DataTable();
                string sql = "SELECT [MaCaLamViec],[GioVaoLamViec],[GioKetThucLamViec] FROM [MITACOSQL].[dbo].[CaLamViecNew]";
                dt_calamviec = SQLHelper.ExecuteDt(sql);

                string sql_checkinout = $"SELECT * FROM [MITACOSQL].[dbo].[CheckInOut] where MONTH(NgayCham) = {cbo_month.Text} and YEAR(NgayCham) = {cbo_year.Text}";
                //string sql_checkinout = $"SELECT * FROM [MITACOSQL].[dbo].[CheckInOut] where NgayCham >= '{cbo_year.Text + "/" + cbo_month.Text.PadLeft(2,'0') + "/01"}' and NgayCham <= '{DateTime.Parse(cbo_year.Text + "/" + cbo_month.Text.PadLeft(2, '0') + "/01").AddMonths(1).ToString("yyyy/MM/dd")}'";
                DataTable dt_checkinout = new DataTable();
                dt_checkinout = SQLHelper.ExecuteDt(sql_checkinout);

                string sql_dangkytangca = $"select * from DangKyTangCa where MONTH(NgayTangCa) = {cbo_month.Text} and YEAR(NgayTangCa) = {cbo_year.Text}";
                DataTable dt_dangkytangca = SQLHelper.ExecuteDt(sql_dangkytangca);

                string sql_bangsepca = $"SELECT * FROM [MITACOSQL].[dbo].[BangXepCa] where Nam = {cbo_year.Text} and Thang = {cbo_month.Text}";
                DataTable dt_banxepca = new DataTable();
                dt_banxepca = SQLHelper.ExecuteDt(sql_bangsepca);
                if (dt_banxepca == null)
                {
                    RJMessageBox.Show("Chưa đăng ký ca", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                string sql_ngaynghi = $"SELECT * FROM [MITACOSQL].[dbo].[NgayNghi]where Nam = {cbo_year.Text} and Thang = {cbo_month.Text}";
                DataTable dt_ngaynghi = new DataTable();
                dt_ngaynghi = SQLHelper.ExecuteDt(sql_ngaynghi);

                foreach (DataGridViewRow item in dgv_data.Rows)
                {
                    string machamcong = int.Parse(item.Cells["MaChamCong"].Value.ToString().Remove(0, 2)).ToString();
                    int day = 0;
                    var sqls = new List<string>();
                    try
                    {
                        for (int i = 3; i < dgv_data.Columns.Count; i++)
                        {
                            day++;
                            var sogiotangca = item.Cells[i].Value.ToString();
                            if (sogiotangca != "0" && sogiotangca != "")
                            {
                                string ngaycham = cbo_year.Text + "/" + cbo_month.Text.ToString().PadLeft(2, '0') + "/" + day.ToString().PadLeft(2, '0');
                                bool check = DataProvider.add_CheckInOut_Backup(int.Parse(machamcong), ngaycham);
                                if (check == true)
                                {
                                    SqlConnection cn = new SqlConnection(SQLHelper.GetSqlConnection());
                                    cn.Open();
                                    SqlTransaction tr = cn.BeginTransaction();
                                    try
                                    {
                                        sqls = new List<string>();

                                        string date = cbo_year.Text + "/" + cbo_month.Text.ToString().PadLeft(2, '0') + "/" + day.ToString().PadLeft(2, '0');

                                        var ca = dt_banxepca.Rows.Cast<DataRow>()
                                            .Where(x => x["MaChamCong"].ToString() == machamcong)
                                            .Select(y => y["D" + day.ToString()]).FirstOrDefault();

                                        var giochamcong = dt_checkinout.Rows.Cast<DataRow>()
                                            .Where(x => x["MaChamCong"].ToString() == machamcong
                                            && DateTime.Parse(x["NgayCham"].ToString()).ToString("yyyy/MM/dd") == DateTime.Parse(date).ToString("yyyy/MM/dd"))
                                            .OrderBy(x => x["ID"])
                                            .ToList();

                                        if (giochamcong.Count == 0)
                                        {
                                            continue;
                                        }

                                        var giolamviec = dt_calamviec.Rows.Cast<DataRow>()
                                            .Where(x => x["MaCaLamViec"].ToString() == (ca.ToString() == "" ? "HC" : ca.ToString())).FirstOrDefault();

                                        var giovao = false;
                                        var giora = false;

                                        Random TenBienRanDom = new Random();
                                        var sophut = TenBienRanDom.Next(1, 5);
                                        var sogiay = TenBienRanDom.Next(1, 59);
                                        var sophutra = TenBienRanDom.Next(2, 5);
                                        var giovaomoi = DateTime.Parse(giolamviec["GioVaoLamViec"].ToString()).Add(new TimeSpan(0, -sophut, -sogiay)).ToString("HH:mm:ss");
                                        var gioramoi = DateTime.Parse(giolamviec["GioKetThucLamViec"].ToString()).Add(new TimeSpan(0, +sophutra, +sogiay)).ToString("HH:mm:ss");

                                        var giovaotheoca = DateTime.Parse(ngaycham).ToString("yyyy/MM/dd " + DateTime.Parse(giolamviec["GioVaoLamViec"].ToString()).ToString("HH:mm:ss"));
                                        var gioratheoca = DateTime.Parse(ngaycham).ToString("yyyy/MM/dd " + DateTime.Parse(giolamviec["GioKetThucLamViec"].ToString()).ToString("HH:mm:ss"));

                                        var ngaygiovao_moi = DateTime.Parse(ngaycham).ToString("yyyy/MM/dd " + giovaomoi);
                                        var ngaygiora_moi = DateTime.Parse(ngaycham).ToString("yyyy/MM/dd " + gioramoi);

                                        // ngay nghi
                                        if (dt_ngaynghi.Rows.Cast<DataRow>().Select(x => x["D" + day.ToString()]).FirstOrDefault().ToString() == "True")
                                        {
                                            if (ca.ToString() == "CA3")
                                            {
                                                string xoa_giovaoca3 = $"delete CheckInOut " +
                                                    $"where MaChamCong = '{machamcong}' " +
                                                    $"and NgayCham >= '{DateTime.Parse(ngaycham).ToString("yyyy/MM/dd")}' " +
                                                    $"and NgayCham <= '{DateTime.Parse(ngaycham).AddDays(1).ToString("yyyy/MM/dd")}' " +
                                                    $"and GioCham >= '{DateTime.Parse(ngaycham).ToString("yyyy/MM/dd")} 16:00:00' " +
                                                    $"and GioCham <= '{DateTime.Parse(ngaycham).AddDays(1).ToString("yyyy/MM/dd")} 08:00:00'; ";
                                                sqls.Add(xoa_giovaoca3);
                                            }
                                            else
                                            {
                                                string delete_ngaychamcong = "delete CheckInOut " +
                                                    $"where MaChamCong = '{machamcong}' and " +
                                                    $"NgayCham = '{ngaycham}';";
                                                sqls.Add(delete_ngaychamcong);
                                            }
                                            giovao = false;
                                            giora = false;
                                        }
                                        // ngay thuong
                                        else
                                        {
                                            if (ca.ToString() == "CA3")
                                            {
                                                //string gioraca3 = DateTime.Parse(ngaycham).AddDays(1).ToString("yyyy/MM/dd");

                                                if (DateTime.Parse(giochamcong.Max(x => x["GioCham"]).ToString()) > DateTime.Parse(giovaotheoca).AddHours(-6))
                                                {
                                                    //giovao = giochamcong.Max(x => x["GioCham"]).ToString();
                                                    giovao = true;
                                                }
                                                else
                                                {
                                                    giovao = false;
                                                }

                                                string xoa_giovaoca3 = $"delete CheckInOut " +
                                                    $"where MaChamCong = '{machamcong}' " +
                                                    $"and NgayCham = '{DateTime.Parse(ngaycham).ToString("yyyy/MM/dd")}' " +
                                                    $"and GioCham >= '{DateTime.Parse(ngaycham).ToString("yyyy/MM/dd")} 16:00:00'; ";
                                                ngaygiora_moi = DateTime.Parse(ngaycham).AddDays(1).ToString("yyyy/MM/dd " + gioramoi);
                                                sqls.Add(xoa_giovaoca3);
                                                giora = false;

                                            }
                                            else if (ca.ToString() == "CA1")
                                            {
                                                giovao = false;
                                                if (DateTime.Parse(giochamcong.Max(x => x["GioCham"]).ToString()) > DateTime.Parse(gioratheoca))
                                                {
                                                    //giora = giochamcong.Max(x => x["GioCham"]).ToString();
                                                    giora = true;
                                                    string xoa_giora = $"delete CheckInOut " +
                                                    $"where MaChamCong = '{machamcong}' " +
                                                    $"and NgayCham = '{DateTime.Parse(ngaycham).ToString("yyyy/MM/dd")}' " +
                                                    $"and GioCham >= '{ngaycham + " " + DateTime.Parse(giolamviec["GioKetThucLamViec"].ToString()).ToString("HH:mm:ss")}';";
                                                    sqls.Add(xoa_giora);
                                                }
                                                else
                                                {
                                                    giora = false;
                                                }
                                            }
                                            else if (ca.ToString() == "CA2")
                                            {
                                                giora = false;
                                                if (DateTime.Parse(giochamcong.Min(x => x["GioCham"]).ToString()) < DateTime.Parse(giovaotheoca))
                                                {
                                                    giovao = true;
                                                    //giovao = giochamcong.Min(x => x["GioCham"]).ToString();
                                                    string xoa_giovao = $"delete CheckInOut " +
                                                    $"where MaChamCong = '{machamcong}' " +
                                                    $"and NgayCham = '{DateTime.Parse(ngaycham).ToString("yyyy/MM/dd")}' " +
                                                    $"and GioCham <= '{ngaycham + " " + DateTime.Parse(giolamviec["GioVaoLamViec"].ToString()).ToString("HH:mm:ss")}';";
                                                    sqls.Add(xoa_giovao);
                                                }
                                                else
                                                {
                                                    giovao = false;
                                                }
                                            }
                                            else
                                            {
                                                var fs = dt_dangkytangca.Rows.Cast<DataRow>()
                                                    .Where(x => x["MaChamCong"].ToString() == machamcong && DateTime.Parse(x["NgayTangCa"].ToString()).ToString("yyyy/MM/dd") == ngaycham).ToList();
                                                if (fs.Count > 1 && fs.Count > 0)
                                                {
                                                    string delete_ngaychamcong = "delete CheckInOut " +
                                                        $"where MaChamCong = '{machamcong}' and " +
                                                        $"NgayCham = '{ngaycham}';";
                                                    sqls.Add(delete_ngaychamcong);

                                                    if (DateTime.Parse(giochamcong.Min(x => x["GioCham"]).ToString()) < DateTime.Parse(giovaotheoca))
                                                    {
                                                        giovao = true;
                                                        //giovao = giochamcong.Min(x => x["GioCham"]).ToString();
                                                    }
                                                    else
                                                    {
                                                        giovao = false;
                                                    }

                                                    if (DateTime.Parse(giochamcong.Max(x => x["GioCham"]).ToString()) > DateTime.Parse(gioratheoca))
                                                    {
                                                        giora = true;
                                                        //giora = giochamcong.Max(x => x["GioCham"]).ToString();
                                                    }
                                                    else
                                                    {
                                                        giora = false;
                                                    }
                                                }
                                                else if (fs.Count == 1)
                                                {
                                                    if (fs[0]["LoaiTangCa"].ToString() == "0")
                                                    {
                                                        giora = false;
                                                        string delete_ngaychamcong = "delete CheckInOut " +
                                                        $"where MaChamCong = '{machamcong}' and " +
                                                        $"NgayCham = '{ngaycham}' " +
                                                        $"and GioCham <= '{ngaycham + " " + DateTime.Parse(giolamviec["GioVaoLamViec"].ToString()).ToString("HH:mm:ss")}';";
                                                        sqls.Add(delete_ngaychamcong);

                                                        if (DateTime.Parse(giochamcong.Min(x => x["GioCham"]).ToString()) < DateTime.Parse(giovaotheoca))
                                                        {
                                                            giovao = true;
                                                            //giovao = giochamcong.Min(x => x["GioCham"]).ToString();
                                                        }
                                                        else
                                                        {
                                                            giovao = false;
                                                        }
                                                    }
                                                    else if (fs[0]["LoaiTangCa"].ToString() == "1")
                                                    {
                                                        giovao = false;
                                                        string delete_ngaychamcong = "delete CheckInOut " +
                                                        $"where MaChamCong = '{machamcong}' and " +
                                                        $"NgayCham = '{ngaycham}' " +
                                                        $"and GioCham >= '{ngaycham + " " + DateTime.Parse(giolamviec["GioKetThucLamViec"].ToString()).ToString("HH:mm:ss")}';";
                                                        sqls.Add(delete_ngaychamcong);

                                                        if (DateTime.Parse(giochamcong.Max(x => x["GioCham"]).ToString()) > DateTime.Parse(gioratheoca))
                                                        {
                                                            giora = true;
                                                            //giora = giochamcong.Max(x => x["GioCham"]).ToString();
                                                        }
                                                        else
                                                        {
                                                            giora = false;
                                                        }
                                                    }
                                                }
                                            }
                                        }

                                        if (giovao == true)
                                        {
                                            var kieucham_vao = giochamcong.Select(x => x["KieuCham"]).FirstOrDefault();
                                            var nguoncham_vao = giochamcong.Select(x => x["NguonCham"]).FirstOrDefault();
                                            var masomay_vao = giochamcong.Select(x => x["MaSoMay"]).FirstOrDefault();
                                            var tenmay_vao = giochamcong.Select(x => x["TenMay"]).FirstOrDefault();
                                            string insert_ngaychamcong = "Insert Into CheckInOut(MaChamCong,NgayCham,GioCham,KieuCham,NguonCham,MaSoMay,TenMay,update_flg) " +
                                            $"values('{machamcong}','{ngaycham}','{ngaygiovao_moi}','{kieucham_vao}','{nguoncham_vao}','{masomay_vao}','{tenmay_vao}',1);";
                                            sqls.Add(insert_ngaychamcong);
                                        }
                                        if (giora == true)
                                        {
                                            var kieucham_ra = giochamcong.Select(x => x["KieuCham"]).LastOrDefault();
                                            var nguoncham_ra = giochamcong.Select(x => x["NguonCham"]).LastOrDefault();
                                            var masomay_ra = giochamcong.Select(x => x["MaSoMay"]).LastOrDefault();
                                            var tenmay_ra = giochamcong.Select(x => x["TenMay"]).LastOrDefault();
                                            string insert_ngaychamcong = "Insert Into CheckInOut(MaChamCong,NgayCham,GioCham,KieuCham,NguonCham,MaSoMay,TenMay,update_flg) " +
                                            $"values('{machamcong}','{ngaycham}','{ngaygiora_moi}','{kieucham_ra}','{nguoncham_ra}','{masomay_ra}','{tenmay_ra}',1);";
                                            sqls.Add(insert_ngaychamcong);
                                        }
                                        string sql_ex = string.Join("\r\n", sqls.ToArray());
                                        if (sql_ex != "")
                                        {
                                            SqlCommand sqlCommand = new SqlCommand();
                                            sqlCommand.Transaction = tr;
                                            sqlCommand.Connection = cn;
                                            sqlCommand.CommandText = sql_ex;
                                            sqlCommand.ExecuteNonQuery();
                                            tr.Commit();
                                        }
                                    }
                                    catch (Exception ex)
                                    {
                                        tr.Rollback();
                                        throw new Exception(ex.ToString());
                                    }
                                }
                                else
                                {
                                    RJMessageBox.Show("Sao lưu dữ liệu thất bại " + Environment.NewLine + " vui lòng liên hệ IT", "Thông báo");
                                    break;
                                }
                            }
                        }
                    }
                    catch (Exception ex)
                    {
                        RJMessageBox.Show(ex.Message, "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                RJMessageBox.Show("Cập nhật thành công", "Thông báo");
                Cursor.Current = Cursors.Default;
            }
        }

        private void dgv_data_RowPostPaint(object sender, DataGridViewRowPostPaintEventArgs e)
        {
            var grid = sender as DataGridView;
            var rowIdx = (e.RowIndex + 1).ToString();
            var centerFormat = new StringFormat
            {
                Alignment = StringAlignment.Center,
                LineAlignment = StringAlignment.Center
            };
            var textSize = TextRenderer.MeasureText(rowIdx, Font);
            if (grid.RowHeadersWidth < textSize.Width + 40) grid.RowHeadersWidth = textSize.Width + 40;
            var headerBounds =
                new Rectangle(e.RowBounds.Left, e.RowBounds.Top, grid.RowHeadersWidth, e.RowBounds.Height);
            e.Graphics.DrawString(rowIdx, Font, SystemBrushes.ControlText, headerBounds, centerFormat);
        }
    }
}
