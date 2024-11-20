using NPOI.HSSF.Util;
using NPOI.SS.UserModel;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Windows.Forms;
using TENTAC_HRM.BusinessLogicLayer.QuanLyNhanVienBLL;
using TENTAC_HRM.Common;
using TENTAC_HRM.Custom;
using TENTAC_HRM.DataTransferObject.QuanLyNhanVienDTO;
using HorizontalAlignment = NPOI.SS.UserModel.HorizontalAlignment;

namespace TENTAC_HRM.Forms.ChamCong
{
    public partial class uc_TinhTangCa : UserControl
    {
        private KhuVucDTO _khuVucDTO = new KhuVucDTO();
        private CongTyDTO _congTyDTO = new CongTyDTO();
        private ChucVuDTO _chucVuDTO = new ChucVuDTO();
        private NhanVienDTO _nhanVienDTO = new NhanVienDTO();
        private PhongBanDTO _phongBanDTO = new PhongBanDTO();

        private CongTyBLL _congTyBLL = new CongTyBLL();
        private KhuVucBLL _khuVucBLL = new KhuVucBLL();
        private PhongBanBLL _phongBanBLL = new PhongBanBLL();
        private ChucVuBLL _chucVuBLL = new ChucVuBLL();
        private NhanVienBLL _nhanVienBLL = new NhanVienBLL();

        DataTable dt_ngaynghi = new DataTable();
        DataTable _hoanchinh = new DataTable();
        DataTable _thoivu = new DataTable();
        DataTable _quagio_tangca = new DataTable();

        private string sMaPhongBanTreeView;
        private string sMaCongTyTreeView;
        private string sMaKhuVucTreeView;
        private string sMaChucVuTreeView;
        private string _tenNode;
        public uc_TinhTangCa()
        {
            InitializeComponent();
        }

        private void uc_TinhTangCa_Load(object sender, EventArgs e)
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


            DGVNhanVien.Columns.Insert(0, new DataGridViewCheckBoxColumn());
            DGVNhanVien.Columns[0].Width = 30;
            loadTreeView();

            DataTable dt_luachontai = new DataTable();
            dt_luachontai.Columns.Add("Id");
            dt_luachontai.Columns.Add("Name");
            dt_luachontai.Rows.Add("0", "Chọn tất cả");
            dt_luachontai.Rows.Add("1", "Ngoài Thời Vụ");
            dt_luachontai.Rows.Add("2", "Chỉ Thời Vụ");
            cbo_LuaChonXuat.DataSource = dt_luachontai;
            cbo_LuaChonXuat.DisplayMember = "Name";
            cbo_LuaChonXuat.ValueMember = "Id";
        }
        private DataTable danhsachca()
        {
            string sql = $"select * from BangXepCa where Nam = '{cbo_year.SelectedValue}' and Thang = '{cbo_month.Text}'";
            DataTable data = new DataTable();
            data = SQLHelper.ExecuteDt(sql);
            return data;
        }
        public void tinhtangca_ngay()
        {
            Cursor.Current = Cursors.WaitCursor;
            try
            {
                _hoanchinh.Clear();
                _quagio_tangca.Clear();
                string sql = "SELECT [MaCaLamViec],[GioVaoLamViec],[GioKetThucLamViec] FROM [MITACOSQL].[dbo].[CaLamViecNew]";
                DataTable ca_lanviec = new DataTable();
                ca_lanviec = SQLHelper.ExecuteDt(sql);

                DataTable dt_dacbiet = new DataTable();
                dt_dacbiet.Columns.Add("MaChamCong");
                dt_dacbiet.Columns.Add("TenNhanVien");
                dt_dacbiet.Columns.Add("Ngay");
                dt_dacbiet.Columns.Add("LyDo");

                int _year = int.Parse(cbo_year.Text.ToString());
                int _month = int.Parse(cbo_month.Text.ToString());

                string sql_tangca = $"Select * From MITACOSQL.dbo.DangKyTangCa Where year(NgayTangCa) = '{_year}' and month(NgayTangCa) = '{_month}'";
                DataTable dt_tangca = new DataTable();
                dt_tangca = SQLHelper.ExecuteDt(sql_tangca);

                string sql_ngaynghi = $"select * from MITACOSQL.dbo.NgayNghi where nam = '{_year}' and thang = '{_month}'";
                dt_ngaynghi = SQLHelper.ExecuteDt(sql_ngaynghi);
                DataTable ds_ca = new DataTable();
                ds_ca = danhsachca();

                DateTime result = new DateTime(int.Parse(cbo_year.Text), int.Parse(cbo_month.Text), 1);
                DateTime result1 = new DateTime(int.Parse(cbo_year.Text), int.Parse(cbo_month.Text), DateTime.DaysInMonth(int.Parse(cbo_year.Text), int.Parse(cbo_month.Text)));

                string sql_database = "select * " +
                                        "from( select a.MaChamCong,NgayCham,GioCham,b.TenNhanVien,b.MaNhanVien,case when b.MaKhuVuc = 'KV00003' then N'Thai sản' else case when b.MaKhuVuc is null then N'Nghỉ việc' else pb.TenPhongBan end end as TenPhongBan " +
                                                "from MITACOSQL.dbo.CheckInOut a " +
                                                "join MITACOSQL.dbo.NHANVIEN b on a.MaChamCong = b.MaChamCong " +
                                                "left join MITACOSQL.dbo.PHONGBAN pb on b.MaPhongBan = pb.MaPhongBan" +
                                                ") a where MaNhanVien not like 'JP%' and MaNhanVien not like 'KC%' ";
                if (chk_dulieuchuaquachinhsua.Checked == true)
                {
                    sql_database = "select * from( " +
                                        "select a.MaChamCong,NgayCham,GioCham,b.TenNhanVien,b.MaNhanVien,case when b.MaKhuVuc = 'KV00003' then N'Thai sản' else case when b.MaKhuVuc is null then N'Nghỉ việc' else pb.TenPhongBan end end as TenPhongBan " +
                                        "from MITACOSQL.dbo.CheckInOut a " +
                                        "join MITACOSQL.dbo.NHANVIEN b on a.MaChamCong = b.MaChamCong " +
                                        "left join MITACOSQL.dbo.PHONGBAN pb on b.MaPhongBan = pb.MaPhongBan " +
                                        "where (update_flg = 0 or update_flg is null) " +
                                        "union " +
                                        "select a.MaChamCong,NgayCham,GioCham,b.TenNhanVien,b.MaNhanVien,case when b.MaKhuVuc = 'KV00003' then N'Thai sản' else case when b.MaKhuVuc is null then N'Nghỉ việc' else pb.TenPhongBan end end as TenPhongBan " +
                                        "from MITACOSQL.dbo.CheckInOutBackup a " +
                                        "join MITACOSQL.dbo.NHANVIEN b on a.MaChamCong = b.MaChamCong " +
                                        "left join MITACOSQL.dbo.PHONGBAN pb on b.MaPhongBan = pb.MaPhongBan " +
                                    ") a where MaNhanVien not like 'JP%' and MaNhanVien not like 'KC%' ";
                }
                string sql_selectall = sql_database +
                    $"and a.NgayCham between '{result.ToString("yyyy/MM/dd")}' and '{result1.AddDays(1).ToString("yyyy/MM/dd")}' " +
                    (!string.IsNullOrEmpty(txt_search.Text) ? " And a.MaNhanVien like '%" + txt_search.Text + "%'" : "") +
                    " order by a.MaChamCong desc,a.NgayCham";

                DataTable dt_sql_selectall = new DataTable();
                dt_sql_selectall = SQLHelper.ExecuteDt(sql_selectall);
                var list_machamcong = (from DataRow dr in dt_sql_selectall.Rows
                                       select new
                                       {
                                           MaChamCong = dr.Field<int>("MaChamCong").ToString(),
                                           TenNhanVien = dr.Field<string>("TenNhanVien"),
                                           MaNhanVien = dr.Field<string>("MaNhanVien"),
                                           TenPhongBan = dr.Field<string>("TenPhongBan"),
                                       }).Distinct().ToList();
                //TimeSpan giolam = new TimeSpan();
                DataTable dt1 = new DataTable();

                DataTable dt_new = new DataTable();
                for (int a = 0; a < list_machamcong.Count(); a++)
                {
                    decimal tong_gio = 0;
                    var list_nhanvien = dt_sql_selectall.Rows.Cast<DataRow>().Where(x => x.Field<int>("MaChamCong").ToString() == list_machamcong[a].MaChamCong).ToList();
                    var get_canhanvien = ds_ca.Rows.Cast<DataRow>().Where(x => x.Field<int>("MaChamCong").ToString() == list_machamcong[a].MaChamCong);
                    var ca_nv = get_canhanvien.Any() ? get_canhanvien.CopyToDataTable() : null;
                    if (ca_nv == null)
                        continue;
                    int days = DateTime.DaysInMonth(_year, _month);
                    var dsd = list_nhanvien.Select(x => x.Field<DateTime>("NgayCham")).Distinct().ToList();
                    string machamcong = list_nhanvien.Select(x => x.Field<int>("MaChamCong")).FirstOrDefault().ToString();

                    string[] col = new string[days + 4];
                    col[0] = list_machamcong[a].MaNhanVien;
                    col[1] = list_machamcong[a].TenNhanVien;
                    col[2] = list_machamcong[a].TenPhongBan;

                    string[] col_hoanchinh = new string[days + 4];
                    col_hoanchinh[0] = list_machamcong[a].MaNhanVien;
                    col_hoanchinh[1] = list_machamcong[a].TenNhanVien;
                    col_hoanchinh[2] = list_machamcong[a].TenPhongBan;

                    string[] col_quagio_tangca = new string[days + 4];
                    col_quagio_tangca[0] = list_machamcong[a].MaNhanVien;
                    col_quagio_tangca[1] = list_machamcong[a].TenNhanVien;
                    col_quagio_tangca[2] = list_machamcong[a].TenPhongBan;

                    decimal tonggiotangca_tuan = 0;
                    int tuan = 1;
                    int tuan_1 = 1;
                    decimal tong_thang = 0;
                    decimal tong_quagio = 0;
                    decimal tong_hoanchinh = 0;
                    //int demngaylamviec = 6;
                    for (int j = 1; j <= days; j++)
                    {
                        try
                        {
                            col_hoanchinh[2 + j] = "0";
                            col_quagio_tangca[2 + j] = "0";
                            DateTime result_tuan = new DateTime(int.Parse(cbo_year.Text), int.Parse(cbo_month.Text), j);
                            if (result_tuan.DayOfWeek == DayOfWeek.Monday)
                            {
                                tonggiotangca_tuan = 0;
                                tuan++;
                            }
                            if (DateTime.Parse(cbo_year.Text + "/" + cbo_month.Text.ToString().PadLeft(2, '0') + "/" + j.ToString().PadLeft(2, '0')) >= DateTime.Parse(DateTime.Now.ToString("yyyy/MM/dd")))
                                continue;
                            var ngaynghi = dt_ngaynghi.Rows.Cast<DataRow>().Select(x => x.Field<bool>("D" + j.ToString())).ToList();
                            //if (result_tuan.DayOfWeek == DayOfWeek.Saturday && ngaynghi[0] == true)
                            //{
                            //    demngaylamviec = 5;
                            //}
                            decimal so_gio = 0;
                            decimal so_phut = 0;
                            string ca = ca_nv.Rows.Cast<DataRow>().Select(x => x.Field<string>("D" + j)).FirstOrDefault().ToString();
                            var ca_nhanvien = ca_lanviec.Rows.Cast<DataRow>()
                                .Where(x => x.Field<string>("MaCaLamViec").Equals(ca == "" ? "HC" : ca))
                                .FirstOrDefault();

                            var month_new = _month < 10 ? "0" + _month.ToString() : _month.ToString();
                            var day_new = j.ToString().PadLeft(2, '0');
                            var ngaythangnam = _year + "/" + month_new + "/" + day_new;
                            List<DataRow> checkInOut_day = new List<DataRow>();
                            if (ca == "CA3")
                            {
                                checkInOut_day = list_nhanvien
                                    .Where(x => x.Field<DateTime>("GioCham") >= DateTime.Parse(_year.ToString() + "/" + month_new.ToString() + "/" + day_new.ToString() + " 16:00:00")
                                    && x.Field<DateTime>("GioCham") <= DateTime.Parse(_year.ToString() + "/" + month_new.ToString() + "/" + day_new.ToString() + " 08:00:00").AddDays(1)).ToList();
                            }
                            else
                            {
                                checkInOut_day = list_nhanvien.Where(x => x.Field<DateTime>("NgayCham").ToString() == DateTime.Parse(_year.ToString() + "/" + month_new.ToString() + "/" + day_new.ToString()).ToString()).ToList();
                            }

                            dt1 = checkInOut_day.Any() ? checkInOut_day.CopyToDataTable() : null;

                            var tangca_nhanvien = dt_tangca.Rows.Cast<DataRow>()
                                .Where(x => x.Field<int>("MaChamCong").ToString() == machamcong
                                && x.Field<DateTime>("NgayTangCa").ToString() == DateTime.Parse(_year.ToString() + "/" + month_new.ToString() + "/" + day_new.ToString()).ToString())
                                .OrderBy(x => x.Field<DateTime>("GioTangCa")).ToList();

                            if (dt1 != null)
                            {
                                if (tangca_nhanvien.Count == 0 && ca == "")
                                {
                                    if (ngaynghi[0] == false)
                                    {
                                        dt_dacbiet.Rows.Add(machamcong, list_nhanvien[0]["TenNhanVien"], DateTime.Parse(dt1.Rows.Cast<DataRow>().Min(x => x["GioCham"]).ToString()).ToString("yyyy/MM/dd HH:mm:ss"), "Nhân viên chưa đăng ký tăng ca");
                                    }
                                    continue;
                                }
                                else if (tangca_nhanvien.Count == 0 && (ca != "" || ca != "HC") && ngaynghi[0] == true)
                                {
                                    dt_dacbiet.Rows.Add(machamcong, list_nhanvien[0]["TenNhanVien"], DateTime.Parse(dt1.Rows.Cast<DataRow>().Min(x => x["GioCham"]).ToString()).ToString("yyyy/MM/dd HH:mm:ss"), "Nhân viên chưa đăng ký tăng ca");
                                    continue;
                                }

                                var min_giocham = DateTime.Parse(dt1.Rows.Cast<DataRow>().Min(x => x["GioCham"]).ToString()).ToString("yyyy/MM/dd HH:mm:00");
                                var giovao = TimeSpan.Parse(DateTime.Parse(min_giocham.ToString()).ToString("HH:mm:ss"));
                                var max_giocham = DateTime.Parse(dt1.Rows.Cast<DataRow>().Max(x => x["GioCham"]).ToString()).ToString("yyyy/MM/dd HH:mm:00");
                                var giora = TimeSpan.Parse(DateTime.Parse(max_giocham.ToString()).ToString("HH:mm:ss"));

                                bool thieugiovaoca3 = false;
                                // tăng ca
                                if (tangca_nhanvien.Count > 0)
                                {
                                    if (DateTime.Parse(min_giocham) > DateTime.Parse(_year.ToString() + "/" + month_new.ToString() + "/" + day_new.ToString() + " " + TimeSpan.Parse(DateTime.Parse(ca_nhanvien[1].ToString()).ToString("HH:mm:ss")))
                                        && ca == "CA3")
                                    {
                                        thieugiovaoca3 = true;
                                        dt_dacbiet.Rows.Add(machamcong, list_nhanvien[0]["TenNhanVien"], DateTime.Parse(dt1.Rows.Cast<DataRow>().Min(x => x["GioCham"]).ToString()).ToString("yyyy/MM/dd HH:mm:ss"), "Thiếu giờ vào");
                                        //min_giocham = tangca_nhanvien[0]["GioTangCa"].ToString();
                                        //giovao = TimeSpan.Parse(DateTime.Parse(min_giocham.ToString()).ToString("HH:mm:ss"));
                                    }

                                    if (tangca_nhanvien.Count == 2)
                                    {
                                        // ra sớm về muộn hơn so với giờ tăng ca
                                        if (dt1.Rows.Count > 1)
                                        {
                                            if (giovao > TimeSpan.Parse(DateTime.Parse(tangca_nhanvien[0]["GioTangCa"].ToString()).ToString("HH:mm:ss")).Add(TimeSpan.Parse("00:01:59")))
                                            {
                                                dt_dacbiet.Rows.Add(machamcong, list_nhanvien[0]["TenNhanVien"], min_giocham.ToString(), "Giờ vào muộn hơn giờ đăng ký tăng ca");
                                            }
                                            if (giora < TimeSpan.Parse(DateTime.Parse(tangca_nhanvien[1]["GioTangCa"].ToString()).ToString("HH:mm:ss")))
                                            {
                                                dt_dacbiet.Rows.Add(machamcong, list_nhanvien[0]["TenNhanVien"], max_giocham.ToString(), "Giờ ra sớm hơn giờ đăng ký tăng ca");
                                            }
                                        }

                                        // 2024/08/12
                                        if (
                                            //giovao > TimeSpan.Parse(DateTime.Parse(ca_nhanvien[2].ToString()).ToString("HH:mm:ss")) ||
                                            giovao <= TimeSpan.Parse(DateTime.Parse(tangca_nhanvien[0]["GioTangCa"].ToString()).ToString("HH:mm:ss")).Add(TimeSpan.Parse("00:01:59")))
                                        {
                                            min_giocham = tangca_nhanvien[0]["GioTangCa"].ToString();
                                        }
                                        if (
                                            //giora < TimeSpan.Parse(DateTime.Parse(ca_nhanvien[2].ToString()).ToString("HH:mm:ss")) ||
                                            giora >= TimeSpan.Parse(DateTime.Parse(tangca_nhanvien[1]["GioTangCa"].ToString()).ToString("HH:mm:ss")))
                                        {
                                            max_giocham = tangca_nhanvien[1]["GioTangCa"].ToString();
                                        }
                                    }
                                    else
                                    {

                                        string loaitangca = tangca_nhanvien[0]["LoaiTangCa"].ToString();
                                        if (loaitangca == "0")
                                        {
                                            // ra sớm về muộn hơn so với giờ tăng ca
                                            if (dt1.Rows.Count > 1)
                                            {
                                                if (giovao > TimeSpan.Parse(DateTime.Parse(tangca_nhanvien[0]["GioTangCa"].ToString()).ToString("HH:mm:ss")).Add(TimeSpan.Parse("00:01:59")))
                                                {
                                                    dt_dacbiet.Rows.Add(machamcong, list_nhanvien[0]["TenNhanVien"], min_giocham.ToString(), "Giờ vào muộn hơn giờ đăng ký tăng ca");
                                                }
                                            }
                                            //min_giocham = tangca_nhanvien[0]["GioTangCa"].ToString();
                                            // kiễm tra
                                            //if (
                                            //    //giovao > TimeSpan.Parse(DateTime.Parse(ca_nhanvien[1].ToString()).ToString("HH:mm:ss")) ||
                                            //    giovao <= TimeSpan.Parse(DateTime.Parse(tangca_nhanvien[0]["GioTangCa"].ToString()).ToString("HH:mm:ss")).Add(TimeSpan.Parse("00:01:59"))
                                            //    )
                                            //{
                                            //    min_giocham = tangca_nhanvien[0]["GioTangCa"].ToString();
                                            //}

                                            if (ca == "CA3")
                                            {
                                                if (giovao <= TimeSpan.Parse(DateTime.Parse(tangca_nhanvien[0]["GioTangCa"].ToString()).ToString("HH:mm:ss")).Add(TimeSpan.Parse("00:01:59"))
                                                    && giovao > TimeSpan.Parse("17:00:00"))
                                                {
                                                    min_giocham = tangca_nhanvien[0]["GioTangCa"].ToString();
                                                }

                                                if (thieugiovaoca3 == true)
                                                {
                                                    max_giocham = DateTime.Parse(max_giocham.ToString()).ToString("yyyy/MM/dd") + " " + DateTime.Parse(ca_nhanvien[2].ToString()).ToString("HH:mm:ss");
                                                }
                                                else
                                                {
                                                    max_giocham = DateTime.Parse(min_giocham.ToString()).AddDays(+1).ToString("yyyy/MM/dd") + " " + DateTime.Parse(ca_nhanvien[2].ToString()).ToString("HH:mm:ss");
                                                }
                                            }
                                            else
                                            {
                                                if (giovao <= TimeSpan.Parse(DateTime.Parse(tangca_nhanvien[0]["GioTangCa"].ToString()).ToString("HH:mm:ss")).Add(TimeSpan.Parse("00:01:59")))
                                                {
                                                    min_giocham = tangca_nhanvien[0]["GioTangCa"].ToString();
                                                }

                                                max_giocham = DateTime.Parse(min_giocham.ToString()).ToString("yyyy/MM/dd") + " " + DateTime.Parse(ca_nhanvien[2].ToString()).ToString("HH:mm:ss");
                                            }
                                        }
                                        else if (loaitangca == "1")
                                        {
                                            // ra sớm về muộn hơn so với giờ tăng ca
                                            if (dt1.Rows.Count > 1)
                                            {
                                                if (giora < TimeSpan.Parse(DateTime.Parse(tangca_nhanvien[0]["GioTangCa"].ToString()).ToString("HH:mm:ss")))
                                                {
                                                    dt_dacbiet.Rows.Add(machamcong, list_nhanvien[0]["TenNhanVien"], max_giocham.ToString(), "Giờ ra sớm hơn giờ đăng ký tăng ca");
                                                }
                                            }
                                            //max_giocham = tangca_nhanvien[0]["GioTangCa"].ToString();

                                            if (
                                                //giora < TimeSpan.Parse(DateTime.Parse(ca_nhanvien[2].ToString()).ToString("HH:mm:ss")) ||
                                                giora >= TimeSpan.Parse(DateTime.Parse(tangca_nhanvien[0]["GioTangCa"].ToString()).ToString("HH:mm:ss")))
                                            {
                                                max_giocham = tangca_nhanvien[0]["GioTangCa"].ToString();
                                            }
                                            if (ca == "CA3")
                                            {
                                                min_giocham = DateTime.Parse(min_giocham.ToString()).AddDays(+1).ToString("yyyy/MM/dd") + " " + DateTime.Parse(ca_nhanvien[1].ToString()).ToString("HH:mm:ss");
                                            }
                                            else
                                            {
                                                min_giocham = DateTime.Parse(min_giocham.ToString()).ToString("yyyy/MM/dd") + " " + DateTime.Parse(ca_nhanvien[1].ToString()).ToString("HH:mm:ss");
                                            }
                                        }
                                        // tăng ca ngày nghỉ
                                        else if (loaitangca == "2")
                                        {
                                            //if (ngaynghi[0] == true)
                                            //{
                                            if (giovao <= TimeSpan.Parse(DateTime.Parse(tangca_nhanvien[0]["GioBatDau"].ToString()).ToString("HH:mm:ss"))
                                                //|| giovao >= TimeSpan.Parse(DateTime.Parse(tangca_nhanvien[0]["GioKetThuc"].ToString()).ToString("HH:mm:ss"))
                                                )
                                            {
                                                min_giocham = DateTime.Parse(min_giocham.ToString()).ToString("yyyy/MM/dd") + " " + tangca_nhanvien[0]["GioBatDau"].ToString();
                                            }

                                            if ((giora >= TimeSpan.Parse(DateTime.Parse(tangca_nhanvien[0]["GioKetThuc"].ToString()).ToString("HH:mm:ss"))
                                                //|| giora <= TimeSpan.Parse(DateTime.Parse(tangca_nhanvien[0]["GioBatDau"].ToString()).ToString("HH:mm:ss"))
                                                ) && ca != "CA3")
                                            {
                                                max_giocham = DateTime.Parse(max_giocham.ToString()).ToString("yyyy/MM/dd") + " " + tangca_nhanvien[0]["GioKetThuc"].ToString();
                                            }
                                            else if ((giora >= TimeSpan.Parse(DateTime.Parse(tangca_nhanvien[0]["GioKetThuc"].ToString()).ToString("HH:mm:ss"))
                                                //|| giora <= TimeSpan.Parse(DateTime.Parse(tangca_nhanvien[0]["GioBatDau"].ToString()).ToString("HH:mm:ss"))
                                                ) && ca == "CA3")
                                            {
                                                max_giocham = DateTime.Parse(max_giocham.ToString()).ToString("yyyy/MM/dd") + " " + tangca_nhanvien[0]["GioKetThuc"].ToString();
                                            }
                                            //}
                                        }
                                    }
                                }
                                // không tăng ca
                                else
                                {
                                    // ra sớm về muộn hơn so với giờ làm
                                    //if (dt1.Rows.Count > 1)
                                    //{
                                    //    if (giovao > TimeSpan.Parse(DateTime.Parse(ca_nhanvien[1].ToString()).ToString("HH:mm:ss")))
                                    //    {
                                    //        dt_dacbiet.Rows.Add(machamcong, list_nhanvien[0]["TenNhanVien"], min_giocham.ToString(), "Vào muộn");
                                    //    }
                                    //    if (giora < TimeSpan.Parse(DateTime.Parse(ca_nhanvien[2].ToString()).ToString("HH:mm:ss")))
                                    //    {
                                    //        dt_dacbiet.Rows.Add(machamcong, list_nhanvien[0]["TenNhanVien"], max_giocham.ToString(), "Về sớm");
                                    //    }
                                    //}

                                    if (ca == "CA3")
                                    {
                                        min_giocham = DateTime.Parse(min_giocham.ToString()).ToString("yyyy/MM/dd") + " " + DateTime.Parse(ca_nhanvien[1].ToString()).ToString("HH:mm:ss");
                                        max_giocham = DateTime.Parse(min_giocham.ToString()).AddDays(+1).ToString("yyyy/MM/dd") + " " + DateTime.Parse(ca_nhanvien[2].ToString()).ToString("HH:mm:ss");
                                    }
                                    else
                                    {
                                        min_giocham = DateTime.Parse(min_giocham.ToString()).ToString("yyyy/MM/dd") + " " + DateTime.Parse(ca_nhanvien[1].ToString()).ToString("HH:mm:ss");
                                        max_giocham = DateTime.Parse(min_giocham.ToString()).ToString("yyyy/MM/dd") + " " + DateTime.Parse(ca_nhanvien[2].ToString()).ToString("HH:mm:ss");
                                    }
                                }
                                if (max_giocham != null && min_giocham != null)
                                {
                                    TimeSpan giolam = new TimeSpan();
                                    //if (TimeSpan.Parse(DateTime.Parse(max_giocham).ToString("HH:mm:00")) < TimeSpan.Parse(DateTime.Parse(min_giocham).ToString("HH:mm:00"))
                                    //    && ngaynghi[0] == true)
                                    //{
                                    //    giolam = DateTime.Parse(max_giocham.ToString()).AddDays(1).Subtract(DateTime.Parse(min_giocham.ToString()));
                                    //}
                                    //else
                                    //{
                                    //    giolam = DateTime.Parse(max_giocham.ToString()).Subtract(DateTime.Parse(min_giocham.ToString()));
                                    //}
                                    giolam = DateTime.Parse(max_giocham.ToString()).Subtract(DateTime.Parse(min_giocham.ToString()));
                                    if (ngaynghi[0] == true)
                                    {
                                        if (ca == "HC" || ca == "")
                                        {
                                            if (TimeSpan.Parse(DateTime.Parse(min_giocham).ToString("HH:mm:ss")) <= TimeSpan.Parse("11:50:00") && TimeSpan.Parse(DateTime.Parse(max_giocham).ToString("HH:mm:ss")) >= TimeSpan.Parse("12:40:00"))
                                            {
                                                so_gio = (decimal)(giolam.TotalHours - (TimeSpan.Parse("00:40:00")).TotalHours);
                                                so_phut = (decimal)(giolam.TotalMinutes - (TimeSpan.Parse("00:40:00")).TotalMinutes);
                                            }
                                            else
                                            {
                                                so_gio = (decimal)giolam.TotalHours;
                                                so_phut = (decimal)giolam.TotalMinutes;
                                            }
                                        }
                                        else
                                        {
                                            so_gio = (decimal)giolam.TotalHours;
                                            so_phut = (decimal)giolam.TotalMinutes;
                                        }
                                    }
                                    else
                                    {
                                        if (ca == "HC")
                                        {
                                            so_gio = (decimal)(giolam.TotalMinutes - (TimeSpan.Parse("00:40:00")).TotalMinutes - (TimeSpan.Parse("08:00:00")).TotalMinutes) / 60;
                                            so_phut = (decimal)(giolam.TotalMinutes - (TimeSpan.Parse("00:40:00")).TotalMinutes - (TimeSpan.Parse("08:00:00")).TotalMinutes);
                                        }
                                        else
                                        {
                                            so_gio = (decimal)(giolam.TotalHours - (TimeSpan.Parse("08:00:00")).TotalHours);
                                            so_phut = (decimal)(giolam.TotalMinutes - (TimeSpan.Parse("08:00:00")).TotalMinutes);
                                        }
                                    }
                                }
                            }
                            decimal fsdf = (so_gio - (int)so_gio) * 60;
                            double ds = 0;
                            // 15
                            if (fsdf >= 15 && fsdf < 30)
                            {
                                ds = (0.25);
                            }
                            // 30
                            else if (fsdf >= 30 && fsdf < 45)
                            {
                                ds = 0.5;
                            }
                            // 45
                            else if (fsdf >= 45 && fsdf < 60)
                            {
                                ds = 0.75;
                            }
                            // 60
                            //else if(fsdf > 52 && fsdf <= 60)
                            //{
                            //    ds = 1;
                            //}
                            decimal tonggio_le = ((int)so_gio) + (decimal)ds;
                            col[2 + j] = (tonggio_le).ToString();
                            //int tonggiotrongtuan = 0;
                            //if (demngaylamviec == 6)
                            //{
                            //    tonggiotrongtuan = 12;
                            //}
                            //else if (demngaylamviec == 5)
                            //{
                            //    tonggiotrongtuan = 20;
                            //}

                            if ((tonggiotangca_tuan + tonggio_le > 10 && tuan_1 == tuan) || ngaynghi[0] == true || tong_thang + tonggio_le > 40 || tonggio_le > 4)
                            {
                                col_hoanchinh[2 + j] = "0";
                                col_quagio_tangca[2 + j] = (tonggio_le).ToString();
                                tong_quagio = tong_quagio + tonggio_le;
                                tonggiotangca_tuan = tonggiotangca_tuan + tonggio_le;
                            }
                            else
                            {
                                tuan_1 = tuan;
                                col_quagio_tangca[2 + j] = "0";
                                col_hoanchinh[2 + j] = (tonggio_le).ToString();
                                tong_hoanchinh = tong_hoanchinh + tonggio_le;
                                tonggiotangca_tuan = tonggiotangca_tuan + tonggio_le;
                                tong_thang = tong_thang + tonggio_le;
                            }
                            tong_gio = tong_gio + tonggio_le;
                        }
                        catch (Exception ex)
                        {
                            RJMessageBox.Show(ex.Message, "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }

                    }
                    col[dgv_tangca.ColumnCount - 1] = tong_gio.ToString();
                    col_quagio_tangca[dgv_tangca.ColumnCount - 1] = tong_quagio.ToString();
                    col_hoanchinh[dgv_tangca.ColumnCount - 1] = tong_hoanchinh.ToString();
                    dgv_tangca.Rows.Add(col);
                    _hoanchinh.Rows.Add(col_hoanchinh);
                    _quagio_tangca.Rows.Add(col_quagio_tangca);
                }
                dgv_dacbiet.DataSource = dt_dacbiet;

                var _quagio_tangca_new = _quagio_tangca.Rows.Cast<DataRow>()
                    .Where(x => decimal.Parse(x.Field<string>("Tong").ToString()) > 0);
                _quagio_tangca = _quagio_tangca_new.Any() ? _quagio_tangca_new.CopyToDataTable() : null;
            }
            catch (Exception ex)
            {
                RJMessageBox.Show(ex.Message, "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            Cursor.Current = Cursors.Default;
        }
        // tính tang ca thoi vu
        public void tinhtangca_thoivu()
        {
            Cursor.Current = Cursors.WaitCursor;
            try
            {
                _thoivu.Clear();
                string sql = "SELECT [MaCaLamViec],[GioVaoLamViec],[GioKetThucLamViec] FROM [MITACOSQL].[dbo].[CaLamViecNew]";
                DataTable ca_lanviec = new DataTable();
                ca_lanviec = SQLHelper.ExecuteDt(sql);

                DataTable dt_dacbiet = new DataTable();
                dt_dacbiet.Columns.Add("MaChamCong");
                dt_dacbiet.Columns.Add("TenNhanVien");
                dt_dacbiet.Columns.Add("Ngay");
                dt_dacbiet.Columns.Add("LyDo");

                int _year = int.Parse(cbo_year.Text.ToString());
                int _month = int.Parse(cbo_month.Text.ToString());

                string sql_tangca = $"Select * From MITACOSQL.dbo.DangKyTangCa Where year(NgayTangCa) = '{_year}' and month(NgayTangCa) = '{_month}'";
                DataTable dt_tangca = new DataTable();
                dt_tangca = SQLHelper.ExecuteDt(sql_tangca);

                DataTable ds_ca = new DataTable();
                ds_ca = danhsachca();

                DateTime result = new DateTime(int.Parse(cbo_year.Text), int.Parse(cbo_month.Text), 1);
                DateTime result1 = new DateTime(int.Parse(cbo_year.Text), int.Parse(cbo_month.Text), DateTime.DaysInMonth(int.Parse(cbo_year.Text), int.Parse(cbo_month.Text)));

                string sql_database = "select * " +
                                        "from( select a.MaChamCong,NgayCham,GioCham,b.TenNhanVien,b.MaNhanVien,case when b.MaKhuVuc = 'KV00003' then N'Thai sản' else case when b.MaKhuVuc is null then N'Nghỉ việc' else pb.TenPhongBan end end as TenPhongBan " +
                                                "from MITACOSQL.dbo.CheckInOut a " +
                                                "join MITACOSQL.dbo.NHANVIEN b on a.MaChamCong = b.MaChamCong " +
                                                "left join MITACOSQL.dbo.PHONGBAN pb on b.MaPhongBan = pb.MaPhongBan" +
                                                ") a where MaNhanVien not like 'JP%' and MaNhanVien like 'KC%' ";
                if (chk_dulieuchuaquachinhsua.Checked == true)
                {
                    sql_database = "select * from( " +
                                        "select a.MaChamCong,NgayCham,GioCham,b.TenNhanVien,b.MaNhanVien,case when b.MaKhuVuc = 'KV00003' then N'Thai sản' else case when b.MaKhuVuc is null then N'Nghỉ việc' else pb.TenPhongBan end end as TenPhongBan " +
                                        "from MITACOSQL.dbo.CheckInOut a " +
                                        "join MITACOSQL.dbo.NHANVIEN b on a.MaChamCong = b.MaChamCong " +
                                        "left join MITACOSQL.dbo.PHONGBAN pb on b.MaPhongBan = pb.MaPhongBan " +
                                        "where (update_flg = 0 or update_flg is null) " +
                                        "union " +
                                        "select a.MaChamCong,NgayCham,GioCham,b.TenNhanVien,b.MaNhanVien,case when b.MaKhuVuc = 'KV00003' then N'Thai sản' else case when b.MaKhuVuc is null then N'Nghỉ việc' else pb.TenPhongBan end end as TenPhongBan " +
                                        "from MITACOSQL.dbo.CheckInOutBackup a " +
                                        "join MITACOSQL.dbo.NHANVIEN b on a.MaChamCong = b.MaChamCong " +
                                        "left join MITACOSQL.dbo.PHONGBAN pb on b.MaPhongBan = pb.MaPhongBan " +
                                    ") a where MaNhanVien not like 'JP%' and MaNhanVien like 'KC%' ";
                }
                string sql_selectall = sql_database +
                    $"and a.NgayCham between '{result.ToString("yyyy/MM/dd")}' and '{result1.AddDays(1).ToString("yyyy/MM/dd")}' " +
                    (!string.IsNullOrEmpty(txt_search.Text) ? " And a.MaNhanVien like '%" + txt_search.Text + "%'" : "") +
                    " order by a.MaChamCong desc,a.NgayCham";

                DataTable dt_sql_selectall = new DataTable();
                dt_sql_selectall = SQLHelper.ExecuteDt(sql_selectall);
                var list_machamcong = (from DataRow dr in dt_sql_selectall.Rows
                                       select new
                                       {
                                           MaChamCong = dr.Field<int>("MaChamCong").ToString(),
                                           TenNhanVien = dr.Field<string>("TenNhanVien"),
                                           MaNhanVien = dr.Field<string>("MaNhanVien"),
                                           TenPhongBan = dr.Field<string>("TenPhongBan"),
                                       }).Distinct().ToList();
                //TimeSpan giolam = new TimeSpan();
                DataTable dt1 = new DataTable();

                DataTable dt_new = new DataTable();
                for (int a = 0; a < list_machamcong.Count(); a++)
                {
                    decimal tong_gio = 0;
                    var list_nhanvien = dt_sql_selectall.Rows.Cast<DataRow>().Where(x => x.Field<int>("MaChamCong").ToString() == list_machamcong[a].MaChamCong).ToList();
                    var get_canhanvien = ds_ca.Rows.Cast<DataRow>().Where(x => x.Field<int>("MaChamCong").ToString() == list_machamcong[a].MaChamCong);
                    var ca_nv = get_canhanvien.Any() ? get_canhanvien.CopyToDataTable() : null;
                    if (ca_nv == null)
                        continue;
                    int days = DateTime.DaysInMonth(_year, _month);
                    var dsd = list_nhanvien.Select(x => x.Field<DateTime>("NgayCham")).Distinct().ToList();
                    string machamcong = list_nhanvien.Select(x => x.Field<int>("MaChamCong")).FirstOrDefault().ToString();

                    string[] col_thoivu = new string[days + 4];
                    col_thoivu[0] = list_machamcong[a].MaNhanVien;
                    col_thoivu[1] = list_machamcong[a].TenNhanVien;
                    col_thoivu[2] = list_machamcong[a].TenPhongBan;

                    decimal tonggiotangca_tuan = 0;
                    int tuan = 1;
                    int tuan_1 = 1;
                    decimal tong_thang = 0;
                    decimal tong_thoivu = 0;

                    for (int j = 1; j <= days; j++)
                    {
                        try
                        {
                            col_thoivu[2 + j] = "0";
                            DateTime result_tuan = new DateTime(int.Parse(cbo_year.Text), int.Parse(cbo_month.Text), j);
                            if (result_tuan.DayOfWeek == DayOfWeek.Monday)
                            {
                                tonggiotangca_tuan = 0;
                                tuan++;
                            }
                            if (DateTime.Parse(cbo_year.Text + "/" + cbo_month.Text.ToString().PadLeft(2, '0') + "/" + j.ToString().PadLeft(2, '0')) >= DateTime.Parse(DateTime.Now.ToString("yyyy/MM/dd")))
                                continue;

                            decimal so_gio = 0;
                            decimal so_phut = 0;
                            string ca = ca_nv.Rows.Cast<DataRow>().Select(x => x.Field<string>("D" + j)).FirstOrDefault().ToString();
                            var ca_nhanvien = ca_lanviec.Rows.Cast<DataRow>()
                                .Where(x => x.Field<string>("MaCaLamViec").Equals(ca == "" ? "HC" : ca))
                                .FirstOrDefault();

                            var month_new = _month < 10 ? "0" + _month.ToString() : _month.ToString();
                            var day_new = j.ToString().PadLeft(2, '0');
                            var ngaythangnam = _year + "/" + month_new + "/" + day_new;
                            List<DataRow> checkInOut_day = new List<DataRow>();
                            if (ca == "CA3")
                            {
                                checkInOut_day = list_nhanvien
                                    .Where(x => x.Field<DateTime>("GioCham") >= DateTime.Parse(_year.ToString() + "/" + month_new.ToString() + "/" + day_new.ToString() + " 16:00:00")
                                    && x.Field<DateTime>("GioCham") <= DateTime.Parse(_year.ToString() + "/" + month_new.ToString() + "/" + day_new.ToString() + " 08:00:00").AddDays(1)).ToList();
                            }
                            else
                            {
                                checkInOut_day = list_nhanvien.Where(x => x.Field<DateTime>("NgayCham").ToString() == DateTime.Parse(_year.ToString() + "/" + month_new.ToString() + "/" + day_new.ToString()).ToString()).ToList();
                            }

                            dt1 = checkInOut_day.Any() ? checkInOut_day.CopyToDataTable() : null;

                            var tangca_nhanvien = dt_tangca.Rows.Cast<DataRow>()
                                .Where(x => x.Field<int>("MaChamCong").ToString() == machamcong
                                && x.Field<DateTime>("NgayTangCa").ToString() == DateTime.Parse(_year.ToString() + "/" + month_new.ToString() + "/" + day_new.ToString()).ToString())
                                .OrderBy(x => x.Field<DateTime>("GioTangCa")).ToList();

                            if (dt1 != null)
                            {
                                var min_giocham = DateTime.Parse(dt1.Rows.Cast<DataRow>().Min(x => x["GioCham"]).ToString()).ToString("yyyy/MM/dd HH:mm:00");
                                var giovao = TimeSpan.Parse(DateTime.Parse(min_giocham.ToString()).ToString("HH:mm:ss"));
                                var max_giocham = DateTime.Parse(dt1.Rows.Cast<DataRow>().Max(x => x["GioCham"]).ToString()).ToString("yyyy/MM/dd HH:mm:00");
                                var giora = TimeSpan.Parse(DateTime.Parse(max_giocham.ToString()).ToString("HH:mm:ss"));

                                bool thieugiovaoca3 = false;
                                // tăng ca
                                if (tangca_nhanvien.Count > 0)
                                {
                                    if (DateTime.Parse(min_giocham) > DateTime.Parse(_year.ToString() + "/" + month_new.ToString() + "/" + day_new.ToString() + " " + TimeSpan.Parse(DateTime.Parse(ca_nhanvien[1].ToString()).ToString("HH:mm:ss")))
                                        && ca == "CA3")
                                    {
                                        thieugiovaoca3 = true;
                                        dt_dacbiet.Rows.Add(machamcong, list_nhanvien[0]["TenNhanVien"], DateTime.Parse(dt1.Rows.Cast<DataRow>().Min(x => x["GioCham"]).ToString()).ToString("yyyy/MM/dd HH:mm:ss"), "Thiếu giờ vào");
                                        //min_giocham = tangca_nhanvien[0]["GioTangCa"].ToString();
                                        //giovao = TimeSpan.Parse(DateTime.Parse(min_giocham.ToString()).ToString("HH:mm:ss"));
                                    }

                                    if (tangca_nhanvien.Count == 2)
                                    {
                                        // ra sớm về muộn hơn so với giờ tăng ca
                                        if (dt1.Rows.Count > 1)
                                        {
                                            if (giovao > TimeSpan.Parse(DateTime.Parse(tangca_nhanvien[0]["GioTangCa"].ToString()).ToString("HH:mm:ss")).Add(TimeSpan.Parse("00:01:59")))
                                            {
                                                dt_dacbiet.Rows.Add(machamcong, list_nhanvien[0]["TenNhanVien"], min_giocham.ToString(), "Giờ vào muộn hơn giờ đăng ký tăng ca");
                                            }
                                            if (giora < TimeSpan.Parse(DateTime.Parse(tangca_nhanvien[1]["GioTangCa"].ToString()).ToString("HH:mm:ss")))
                                            {
                                                dt_dacbiet.Rows.Add(machamcong, list_nhanvien[0]["TenNhanVien"], max_giocham.ToString(), "Giờ ra sớm hơn giờ đăng ký tăng ca");
                                            }
                                        }

                                        // 2024/08/12
                                        if (
                                            //giovao > TimeSpan.Parse(DateTime.Parse(ca_nhanvien[2].ToString()).ToString("HH:mm:ss")) ||
                                            giovao <= TimeSpan.Parse(DateTime.Parse(tangca_nhanvien[0]["GioTangCa"].ToString()).ToString("HH:mm:ss")).Add(TimeSpan.Parse("00:01:59")))
                                        {
                                            min_giocham = tangca_nhanvien[0]["GioTangCa"].ToString();
                                        }
                                        if (
                                            //giora < TimeSpan.Parse(DateTime.Parse(ca_nhanvien[2].ToString()).ToString("HH:mm:ss")) ||
                                            giora >= TimeSpan.Parse(DateTime.Parse(tangca_nhanvien[1]["GioTangCa"].ToString()).ToString("HH:mm:ss")))
                                        {
                                            max_giocham = tangca_nhanvien[1]["GioTangCa"].ToString();
                                        }
                                    }
                                    else
                                    {

                                        string loaitangca = tangca_nhanvien[0]["LoaiTangCa"].ToString();
                                        if (loaitangca == "0")
                                        {
                                            // ra sớm về muộn hơn so với giờ tăng ca
                                            if (dt1.Rows.Count > 1)
                                            {
                                                if (giovao > TimeSpan.Parse(DateTime.Parse(tangca_nhanvien[0]["GioTangCa"].ToString()).ToString("HH:mm:ss")).Add(TimeSpan.Parse("00:01:59")))
                                                {
                                                    dt_dacbiet.Rows.Add(machamcong, list_nhanvien[0]["TenNhanVien"], min_giocham.ToString(), "Giờ vào muộn hơn giờ đăng ký tăng ca");
                                                }
                                            }
                                            //min_giocham = tangca_nhanvien[0]["GioTangCa"].ToString();
                                            // kiễm tra
                                            //if (
                                            //    //giovao > TimeSpan.Parse(DateTime.Parse(ca_nhanvien[1].ToString()).ToString("HH:mm:ss")) ||
                                            //    giovao <= TimeSpan.Parse(DateTime.Parse(tangca_nhanvien[0]["GioTangCa"].ToString()).ToString("HH:mm:ss")).Add(TimeSpan.Parse("00:01:59"))
                                            //    )
                                            //{
                                            //    min_giocham = tangca_nhanvien[0]["GioTangCa"].ToString();
                                            //}

                                            if (ca == "CA3")
                                            {
                                                if (giovao <= TimeSpan.Parse(DateTime.Parse(tangca_nhanvien[0]["GioTangCa"].ToString()).ToString("HH:mm:ss")).Add(TimeSpan.Parse("00:01:59"))
                                                    && giovao > TimeSpan.Parse("17:00:00"))
                                                {
                                                    min_giocham = tangca_nhanvien[0]["GioTangCa"].ToString();
                                                }

                                                if (thieugiovaoca3 == true)
                                                {
                                                    max_giocham = DateTime.Parse(max_giocham.ToString()).ToString("yyyy/MM/dd") + " " + DateTime.Parse(ca_nhanvien[2].ToString()).ToString("HH:mm:ss");
                                                }
                                                else
                                                {
                                                    max_giocham = DateTime.Parse(min_giocham.ToString()).AddDays(+1).ToString("yyyy/MM/dd") + " " + DateTime.Parse(ca_nhanvien[2].ToString()).ToString("HH:mm:ss");
                                                }
                                            }
                                            else
                                            {
                                                if (giovao <= TimeSpan.Parse(DateTime.Parse(tangca_nhanvien[0]["GioTangCa"].ToString()).ToString("HH:mm:ss")).Add(TimeSpan.Parse("00:01:59")))
                                                {
                                                    min_giocham = tangca_nhanvien[0]["GioTangCa"].ToString();
                                                }

                                                max_giocham = DateTime.Parse(min_giocham.ToString()).ToString("yyyy/MM/dd") + " " + DateTime.Parse(ca_nhanvien[2].ToString()).ToString("HH:mm:ss");
                                            }
                                        }
                                        else if (loaitangca == "1")
                                        {
                                            // ra sớm về muộn hơn so với giờ tăng ca
                                            if (dt1.Rows.Count > 1)
                                            {
                                                if (giora < TimeSpan.Parse(DateTime.Parse(tangca_nhanvien[0]["GioTangCa"].ToString()).ToString("HH:mm:ss")))
                                                {
                                                    dt_dacbiet.Rows.Add(machamcong, list_nhanvien[0]["TenNhanVien"], max_giocham.ToString(), "Giờ ra sớm hơn giờ đăng ký tăng ca");
                                                }
                                            }
                                            //max_giocham = tangca_nhanvien[0]["GioTangCa"].ToString();

                                            if (
                                                //giora < TimeSpan.Parse(DateTime.Parse(ca_nhanvien[2].ToString()).ToString("HH:mm:ss")) ||
                                                giora >= TimeSpan.Parse(DateTime.Parse(tangca_nhanvien[0]["GioTangCa"].ToString()).ToString("HH:mm:ss")))
                                            {
                                                max_giocham = tangca_nhanvien[0]["GioTangCa"].ToString();
                                            }
                                            if (ca == "CA3")
                                            {
                                                min_giocham = DateTime.Parse(min_giocham.ToString()).AddDays(+1).ToString("yyyy/MM/dd") + " " + DateTime.Parse(ca_nhanvien[1].ToString()).ToString("HH:mm:ss");
                                            }
                                            else
                                            {
                                                min_giocham = DateTime.Parse(min_giocham.ToString()).ToString("yyyy/MM/dd") + " " + DateTime.Parse(ca_nhanvien[1].ToString()).ToString("HH:mm:ss");
                                            }
                                        }
                                        // tăng ca ngày nghỉ
                                        else if (loaitangca == "2")
                                        {
                                            //if (ngaynghi[0] == true)
                                            //{
                                            if (giovao <= TimeSpan.Parse(DateTime.Parse(tangca_nhanvien[0]["GioBatDau"].ToString()).ToString("HH:mm:ss"))
                                                //|| giovao >= TimeSpan.Parse(DateTime.Parse(tangca_nhanvien[0]["GioKetThuc"].ToString()).ToString("HH:mm:ss"))
                                                )
                                            {
                                                min_giocham = DateTime.Parse(min_giocham.ToString()).ToString("yyyy/MM/dd") + " " + tangca_nhanvien[0]["GioBatDau"].ToString();
                                            }

                                            if ((giora >= TimeSpan.Parse(DateTime.Parse(tangca_nhanvien[0]["GioKetThuc"].ToString()).ToString("HH:mm:ss"))
                                                //|| giora <= TimeSpan.Parse(DateTime.Parse(tangca_nhanvien[0]["GioBatDau"].ToString()).ToString("HH:mm:ss"))
                                                ) && ca != "CA3")
                                            {
                                                max_giocham = DateTime.Parse(max_giocham.ToString()).ToString("yyyy/MM/dd") + " " + tangca_nhanvien[0]["GioKetThuc"].ToString();
                                            }
                                            else if ((giora >= TimeSpan.Parse(DateTime.Parse(tangca_nhanvien[0]["GioKetThuc"].ToString()).ToString("HH:mm:ss"))
                                                //|| giora <= TimeSpan.Parse(DateTime.Parse(tangca_nhanvien[0]["GioBatDau"].ToString()).ToString("HH:mm:ss"))
                                                ) && ca == "CA3")
                                            {
                                                max_giocham = DateTime.Parse(max_giocham.ToString()).ToString("yyyy/MM/dd") + " " + tangca_nhanvien[0]["GioKetThuc"].ToString();
                                            }
                                            //}
                                        }
                                    }
                                }
                                // không tăng ca
                                else
                                {

                                    if (ca == "CA3")
                                    {
                                        min_giocham = DateTime.Parse(min_giocham.ToString()).ToString("yyyy/MM/dd") + " " + DateTime.Parse(ca_nhanvien[1].ToString()).ToString("HH:mm:ss");
                                        max_giocham = DateTime.Parse(min_giocham.ToString()).AddDays(+1).ToString("yyyy/MM/dd") + " " + DateTime.Parse(ca_nhanvien[2].ToString()).ToString("HH:mm:ss");
                                    }
                                    else
                                    {
                                        min_giocham = DateTime.Parse(min_giocham.ToString()).ToString("yyyy/MM/dd") + " " + DateTime.Parse(ca_nhanvien[1].ToString()).ToString("HH:mm:ss");
                                        max_giocham = DateTime.Parse(min_giocham.ToString()).ToString("yyyy/MM/dd") + " " + DateTime.Parse(ca_nhanvien[2].ToString()).ToString("HH:mm:ss");
                                    }
                                }
                                if (max_giocham != null && min_giocham != null)
                                {
                                    TimeSpan giolam = new TimeSpan();

                                    giolam = DateTime.Parse(max_giocham.ToString()).Subtract(DateTime.Parse(min_giocham.ToString()));
                                    if (ca == "HC" || ca == "")
                                    {
                                        so_gio = (decimal)(giolam.TotalMinutes - (TimeSpan.Parse("00:40:00")).TotalMinutes - (TimeSpan.Parse("08:00:00")).TotalMinutes) / 60;
                                        so_phut = (decimal)(giolam.TotalMinutes - (TimeSpan.Parse("00:40:00")).TotalMinutes - (TimeSpan.Parse("08:00:00")).TotalMinutes);
                                    }
                                    else
                                    {
                                        so_gio = (decimal)(giolam.TotalHours - (TimeSpan.Parse("08:00:00")).TotalHours);
                                        so_phut = (decimal)(giolam.TotalMinutes - (TimeSpan.Parse("08:00:00")).TotalMinutes);
                                    }
                                }
                            }
                            decimal fsdf = (so_gio - (int)so_gio) * 60;
                            double ds = 0;
                            // 15
                            if (fsdf >= 15 && fsdf < 30)
                            {
                                ds = (0.25);
                            }
                            // 30
                            else if (fsdf >= 30 && fsdf < 45)
                            {
                                ds = 0.5;
                            }
                            // 45
                            else if (fsdf >= 45 && fsdf < 60)
                            {
                                ds = 0.75;
                            }

                            decimal tonggio_le = ((int)so_gio) + (decimal)ds;
                            tuan_1 = tuan;
                            col_thoivu[2 + j] = (tonggio_le).ToString();
                            tong_thoivu = tong_thoivu + tonggio_le;
                            tonggiotangca_tuan = tonggiotangca_tuan + tonggio_le;
                            tong_thang = tong_thang + tonggio_le;
                            tong_gio = tong_gio + tonggio_le;
                        }
                        catch (Exception ex)
                        {
                            RJMessageBox.Show(ex.Message, "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }

                    }
                    col_thoivu[dgv_tangca.ColumnCount - 1] = tong_thoivu.ToString();
                    _thoivu.Rows.Add(col_thoivu);
                    dgv_tangca.Rows.Add(col_thoivu);
                }
                dgv_dacbiet.DataSource = dt_dacbiet;
            }
            catch (Exception ex)
            {
                RJMessageBox.Show(ex.Message, "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            Cursor.Current = Cursors.Default;
        }
        public void canbangthang(DataRow item, int j)
        {
            int datach = 0;
            for (int i = _hoanchinh.Columns.Count - 4; i >= 2; i--)
            {
                try
                {
                    if (decimal.Parse(item["Tong"].ToString()) > 40)
                    {
                        DateTime result_tuan = new DateTime(int.Parse(cbo_year.Text), int.Parse(cbo_month.Text), i);
                        if (decimal.Parse(item[i + 1].ToString()) > 0 && datach == 0)
                        {
                            _quagio_tangca.Rows[j][i + 1] = item[i + 1];
                            _quagio_tangca.Rows[j][_quagio_tangca.Columns.Count - 1] = decimal.Parse(_quagio_tangca.Rows[j][_quagio_tangca.Columns.Count - 1].ToString()) + decimal.Parse(item[i + 1].ToString());
                            item["Tong"] = decimal.Parse(item["Tong"].ToString()) - decimal.Parse(item[i + 1].ToString());
                            item[i + 1] = "0";
                            datach = 1;
                        }
                        if (result_tuan.DayOfWeek == DayOfWeek.Monday)
                        {
                            datach = 0;
                        }
                    }
                }
                catch (Exception ex)
                {
                    RJMessageBox.Show(ex.Message, "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            if (decimal.Parse(item["Tong"].ToString()) > 40)
            {
                canbangthang(item, j);
            }
        }
        static int GetWeekNumberOfMonth(DateTime date)
        {
            // One Solution
            //decimal numberofday = date.Day;
            //decimal d = (Math.Floor(numberofday / 7)) + 1;
            //if ((numberofday) % 7 == 0)
            //{
            //    return Convert.ToInt32((d)) - 1;
            //}
            //return Convert.ToInt32(d);

            date = date.Date;
            DateTime firstMonthDay = new DateTime(date.Year, date.Month, 1);
            DateTime firstMonthMonday = firstMonthDay.AddDays((DayOfWeek.Monday + 7 - firstMonthDay.DayOfWeek) % 7);
            if (firstMonthMonday > date)
            {
                firstMonthDay = firstMonthDay.AddMonths(-1);
                firstMonthMonday = firstMonthDay.AddDays((DayOfWeek.Monday + 7 - firstMonthDay.DayOfWeek) % 7);
            }
            return (date - firstMonthMonday).Days / 7 + 1;
        }
        public int dayofmonth(int Sthang, int Snam)
        {
            int th = Sthang;
            int nm = Snam;
            int songay = 0;

            if (th >= 1 && th <= 12)
            {
                switch (th)
                {
                    case 1:
                    case 3:
                    case 5:
                    case 7:
                    case 8:
                    case 10:
                    case 12: songay = 31; break;
                    case 4:
                    case 6:
                    case 9:
                    case 11: songay = 30; break;

                    case 2:
                        if (nm % 400 == 0 || (nm % 4 == 0 && nm % 100 != 0))    // nam nhuan
                            songay = 29;
                        else
                            songay = 28;
                        break;
                }
            }
            return songay;
        }
        public void load_GioChamCong()
        {
            if (DGVNhanVien.Rows.Count > 0)
            {
                int _year = int.Parse(cbo_year.Text.ToString());
                int _month = int.Parse(cbo_month.Text.ToString());
                int days = DateTime.DaysInMonth(_year, _month);

                string where = "";
                string str_month = (_month < 10 ? "0" + _month.ToString() : _month.ToString());
                where = $"and a.MaChamCong ='{DGVNhanVien.CurrentRow.Cells["MaChamCong"].Value}' " +
                $"and a.NgayCham between '{_year.ToString() + str_month + "01"}' and '{_year.ToString() + str_month + days.ToString()}' " +
                $"and a.NgayCham <> '{DateTime.Now.ToString("yyyy/MM/dd")}' ";
                //}
                string sql = $"SELECT a.ID,a.MaChamCong,b.TenNhanVien,a.NgayCham,a.GioCham,a.KieuCham," +
                    $"case when a.NguonCham = 0 then N'Mật mã' " +
                    $"when a.NguonCham = 1 then N'Vân tay' " +
                    $"when a.NguonCham = 4 then N'Thẻ từ' end NguonCham," +
                    $"a.MaSoMay,a.TenMay,b.MaNhanVien " +
                    $"FROM [MITACOSQL].[dbo].[CheckInOut] a " +
                    $"join [MITACOSQL].[dbo].NHANVIEN b on a.MaChamCong = b.MaChamCong " +
                    $"where 1=1 " + where +
                    $" order by a.NgayCham,a.GioCham";
                DataTable dt = new DataTable();
                dt = SQLHelper.ExecuteDt(sql);
                if (dt.Rows.Count > 0)
                {
                    dgvGioChamCong.DataSource = dt;
                }
                else
                {
                    if (dgvGioChamCong.Rows.Count > 0)
                    {
                        DataTable dt_clear = new DataTable();
                        dt = (DataTable)dgvGioChamCong.DataSource;
                        dt.Rows.Clear();
                    }
                }
            }
        }
        private void btn_TinhTangCa_Click(object sender, EventArgs e)
        {
            Cursor.Current = Cursors.WaitCursor;
            dgv_tangca.Columns.Clear();
            DataGridViewTextBoxColumn macc = new DataGridViewTextBoxColumn();
            macc.HeaderText = "Mã CC";
            macc.Name = "MaChamCong_TC";
            macc.DataPropertyName = "MaChamCong";
            macc.Width = 50;
            macc.Frozen = true;
            dgv_tangca.Columns.Add(macc);

            DataGridViewTextBoxColumn tennv = new DataGridViewTextBoxColumn();
            tennv.HeaderText = "Tên nhân viên";
            tennv.Name = "TenNhanVien_TC";
            tennv.DataPropertyName = "TenNhanVien";
            tennv.Width = 150;
            tennv.Frozen = true;
            dgv_tangca.Columns.Add(tennv);

            DataGridViewTextBoxColumn tenpb = new DataGridViewTextBoxColumn();
            tenpb.HeaderText = "Tên Phòng ban";
            tenpb.Name = "TenPhongBan";
            tenpb.DataPropertyName = "TenPhongBan";
            tenpb.Width = 100;
            tenpb.Frozen = true;
            dgv_tangca.Columns.Add(tenpb);

            _hoanchinh = new DataTable();
            _hoanchinh.Columns.Add("MaChamCong");
            _hoanchinh.Columns.Add("TenNhanVien");
            _hoanchinh.Columns.Add("TenPhongBan");

            _quagio_tangca = new DataTable();
            _quagio_tangca.Columns.Add("MaChamCong");
            _quagio_tangca.Columns.Add("TenNhanVien");
            _quagio_tangca.Columns.Add("TenPhongBan");

            _thoivu = new DataTable();
            _thoivu.Columns.Add("MaChamCong");
            _thoivu.Columns.Add("TenNhanVien");
            _thoivu.Columns.Add("TenPhongBan");

            //if (rdb_ngay.Checked == true)
            //{
            set_column_day();
            dgv_tangca.Rows.Clear();
            if (cbo_LuaChonXuat.SelectedValue.ToString() == "1")
            {
                tinhtangca_ngay();
            }
            else if (cbo_LuaChonXuat.SelectedValue.ToString() == "2")
            {
                tinhtangca_thoivu();
            }
            else
            {
                tinhtangca_ngay();
                tinhtangca_thoivu();
            }

            //}
            //else if (rdb_tuan.Checked == true)
            //{
            //    set_column_tuan();
            //    tinhtangca_tuan();
            //}
            //btn_save.Enabled = true;

            if (string.IsNullOrEmpty(txt_search.Text))
            {
                if (cbo_LuaChonXuat.SelectedValue.ToString() != "2")
                {
                    btn_save();
                }
            }
            Cursor.Current = Cursors.Default;
        }
        private void set_column_day()
        {
            int _year = int.Parse(cbo_year.Text.ToString());
            int _month = int.Parse(cbo_month.Text.ToString());
            int days = DateTime.DaysInMonth(_year, _month);

            for (int i = 1; i <= days; i++)
            {
                DataGridViewTextBoxColumn ngay = new DataGridViewTextBoxColumn();
                ngay.HeaderText = "Ngày " + i;
                ngay.Name = "Ngay" + i;
                ngay.DataPropertyName = "Ngay" + i;
                ngay.Width = 50;
                dgv_tangca.Columns.Add(ngay);

                _hoanchinh.Columns.Add("Ngay" + i);
                _quagio_tangca.Columns.Add("Ngay" + i);
                _thoivu.Columns.Add("Ngay" + i);
            }
            DataGridViewTextBoxColumn column_ngay = new DataGridViewTextBoxColumn();
            column_ngay.HeaderText = "Tổng ";
            column_ngay.Name = "Tong";
            column_ngay.DataPropertyName = "Tong";
            column_ngay.Width = 60;
            dgv_tangca.Columns.Add(column_ngay);
            _hoanchinh.Columns.Add("Tong");
            _quagio_tangca.Columns.Add("Tong");
            _thoivu.Columns.Add("Tong");
        }
        private void loadTreeView()
        {
            DataTable dtCongTy = _congTyBLL.showThongTinCongTy(_congTyDTO);
            for (int i = 0; i < dtCongTy.Rows.Count; i++)
            {
                TreeNode treeCongTy = new TreeNode();
                treeCongTy.Text = dtCongTy.Rows[i][1].ToString();
                treeCongTy.Tag = dtCongTy.Rows[i][0].ToString();
                trv_sodoquanly.Nodes.Add(treeCongTy);
                _khuVucDTO.MaCongTy = dtCongTy.Rows[i]["MaCongTy"].ToString();
                DataTable dtKhuVuc = _khuVucBLL.GETKHUVUCTREEVIEW(_khuVucDTO);
                for (int j = 0; j < dtKhuVuc.Rows.Count; j++)
                {
                    TreeNode treeKhuVuc = new TreeNode();
                    treeKhuVuc.Text = dtKhuVuc.Rows[j][2].ToString();
                    treeKhuVuc.Tag = dtKhuVuc.Rows[j][0].ToString();
                    trv_sodoquanly.Nodes[i + 0].Nodes.Add(treeKhuVuc);
                    _phongBanDTO.MaKhuVuc = dtKhuVuc.Rows[j]["MaKhuVuc"].ToString();
                    DataTable dtPhongBan = _phongBanBLL.GETPHONGBANTREEVIEW(_phongBanDTO);

                    for (int z = 0; z < dtPhongBan.Rows.Count; z++)
                    {
                        TreeNode treePhongBan = new TreeNode();
                        treePhongBan.Text = dtPhongBan.Rows[z][3].ToString();
                        treePhongBan.Tag = dtPhongBan.Rows[z][0].ToString();
                        trv_sodoquanly.Nodes[i + 0].Nodes[j].Nodes.Add(treePhongBan);
                        _chucVuDTO.MaPhongBan = dtPhongBan.Rows[z]["MaPhongBan"].ToString();
                        DataTable dtChucVu = _chucVuBLL.GETCHUCVUTREEVIEW(_chucVuDTO);
                        for (int v = 0; v < dtChucVu.Rows.Count; v++)
                        {
                            TreeNode treeChucVu = new TreeNode();
                            treeChucVu.Text = dtChucVu.Rows[v][4].ToString();
                            treeChucVu.Tag = dtChucVu.Rows[v][0].ToString();
                            trv_sodoquanly.Nodes[i + 0].Nodes[j].Nodes[z].Nodes.Add(treeChucVu);
                            _chucVuDTO.MaChucVu = dtChucVu.Rows[v]["MaChucVu"].ToString();
                        }
                    }
                }
            }
        }

        private void treeViewSoDoQuanLy_AfterSelect(object sender, TreeViewEventArgs e)
        {
            sMaCongTyTreeView = "";
            sMaKhuVucTreeView = "";
            sMaPhongBanTreeView = "";
            sMaChucVuTreeView = "";
            DGVNhanVien.Rows.Clear();
            if (trv_sodoquanly.SelectedNode.Tag.ToString() == "CT00001")
            {
                sMaCongTyTreeView = "CT00001";
            }
            _tenNode = trv_sodoquanly.SelectedNode.Text;
            DataTable dtTreeviewPhongBan = new DataTable();
            _phongBanDTO.TenPhongBan = _tenNode;
            dtTreeviewPhongBan = _phongBanBLL.PhongBanGetTreeView(_phongBanDTO);
            for (int iTreeviewPhongBan = 0; iTreeviewPhongBan < dtTreeviewPhongBan.Rows.Count; iTreeviewPhongBan++)
            {
                sMaPhongBanTreeView = dtTreeviewPhongBan.Rows[iTreeviewPhongBan]["MaPhongBan"].ToString();
            }
            DataTable dtTreeViewCongTy = new DataTable();
            _congTyDTO.TenCongTy = _tenNode;
            dtTreeViewCongTy = _congTyBLL.CongTygetTreeView(_congTyDTO);
            DataTable dtTreeViewKhuVuc = new DataTable();
            _khuVucDTO.TenKhuVuc = _tenNode;
            dtTreeViewKhuVuc = _khuVucBLL.KhuVucgetTreeView(_khuVucDTO);
            for (int iTreeviewKhuVuc = 0; iTreeviewKhuVuc < dtTreeViewKhuVuc.Rows.Count; iTreeviewKhuVuc++)
            {
                sMaKhuVucTreeView = dtTreeViewKhuVuc.Rows[iTreeviewKhuVuc]["MaKhuVuc"].ToString();
            }
            DataTable dtTreeViewChucVu = new DataTable();
            _chucVuDTO.TenChucVu = _tenNode;
            dtTreeViewChucVu = _chucVuBLL.ChucVugetTreeView(_chucVuDTO);
            for (int iTreeviewChucVu = 0; iTreeviewChucVu < dtTreeViewChucVu.Rows.Count; iTreeviewChucVu++)
            {
                sMaChucVuTreeView = dtTreeViewChucVu.Rows[iTreeviewChucVu]["MaChucVu"].ToString();
            }
            DataTable dtNhanVien = new DataTable();
            _nhanVienDTO.MaCongTy = sMaCongTyTreeView;
            _nhanVienDTO.MaKhuVuc = sMaKhuVucTreeView;
            _nhanVienDTO.MaPhongBan = sMaPhongBanTreeView;
            _nhanVienDTO.MaChucVu = sMaChucVuTreeView;
            dtNhanVien = _nhanVienBLL.NhanViengetFromTreeview(_nhanVienDTO);
            for (int iNhanVien = 0; iNhanVien < dtNhanVien.Rows.Count; iNhanVien++)
            {
                int addNhanVien = DGVNhanVien.Rows.Add();
                DGVNhanVien.Rows[addNhanVien].Cells[1].Value = dtNhanVien.Rows[iNhanVien]["MaNhanVien"].ToString();
                DGVNhanVien.Rows[addNhanVien].Cells[2].Value = dtNhanVien.Rows[iNhanVien]["TenNhanVien"].ToString();
                DGVNhanVien.Rows[addNhanVien].Cells[3].Value = dtNhanVien.Rows[iNhanVien]["MaChamCong"].ToString();
                DGVNhanVien.Rows[addNhanVien].Cells[4].Value = dtNhanVien.Rows[iNhanVien]["MaPhongBan"].ToString();
            }
            gbNhanVien.Text = "Nhân viên : " + dtNhanVien.Rows.Count;
        }

        private void DGVNhanVien_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            load_GioChamCong();
        }

        private void txt_search_nhanvien_TextChanged(object sender, EventArgs e)
        {
            DGVNhanVien.Rows.Clear();
            DataTable dtSearchNhanVien = new DataTable();
            _nhanVienDTO.TenNhanVien = txt_search_nhanvien.Text;
            _nhanVienDTO.MaNhanVien = txt_search_nhanvien.Text;
            dtSearchNhanVien = _nhanVienBLL.NhanVienSearch(_nhanVienDTO);
            for (int iSearchNhanVien = 0; iSearchNhanVien < dtSearchNhanVien.Rows.Count; iSearchNhanVien++)
            {
                int addSearchNhanVien = DGVNhanVien.Rows.Add();
                DGVNhanVien.Rows[addSearchNhanVien].Cells[1].Value = dtSearchNhanVien.Rows[iSearchNhanVien]["MaNhanVien"].ToString();
                DGVNhanVien.Rows[addSearchNhanVien].Cells[2].Value = dtSearchNhanVien.Rows[iSearchNhanVien]["TenNhanVien"].ToString();
                DGVNhanVien.Rows[addSearchNhanVien].Cells[3].Value = dtSearchNhanVien.Rows[iSearchNhanVien]["MaChamCong"].ToString();
                DGVNhanVien.Rows[addSearchNhanVien].Cells[4].Value = dtSearchNhanVien.Rows[iSearchNhanVien]["MaPhongBan"].ToString();
            }
            gbNhanVien.Text = "Nhân viên : " + dtSearchNhanVien.Rows.Count;
        }

        private void dgv_tangca_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (e.ColumnIndex > 2)
            {
                if (e.ColumnIndex < dgv_tangca.Columns.Count - 1)
                {
                    if (e.Value == null)
                    {
                        e.Value = 0;
                    }
                    if (decimal.Parse(e.Value.ToString()) < 0)
                    {
                        e.CellStyle.BackColor = Color.Red;
                    }
                }
            }
        }

        private void btn_excel_Click(object sender, EventArgs e)
        {
            Cursor.Current = Cursors.WaitCursor;
            if (cbo_LuaChonXuat.SelectedValue.ToString() == "1")
            {
                xuatExcelTong();
            }
            else if (cbo_LuaChonXuat.SelectedValue.ToString() == "2")
            {
                xuatExcelThoiVu();
            }
            else
            {
                xuatExcelTong();
                xuatExcelThoiVu();
            }
            Cursor.Current = Cursors.Default;
        }
        public void xuatExcelTong()
        {
            int ngaycuathang = new DateTime(int.Parse(cbo_year.Text), int.Parse(cbo_month.Text), 1).AddMonths(1).AddDays(-1).Day;
            var workPath = $@"{Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData)}\template_work_excel.xlsx";
            if (File.Exists(workPath))
            {
                File.Delete(workPath);
            }
            try
            {
                var xlsBook = new XlsWorkBook(workPath, 3);
                // テンプレートシートを読み込み
                var xlsSheet = xlsBook.Sheet(0);
                xlsSheet.SetLandscape(true);
                var style_color = xlsBook.GeCellStyleAlignment(HorizontalAlignment.Center, HSSFColor.Grey25Percent.Index);
                var style_color_LightOrange = xlsBook.GeCellStyleAlignment(HorizontalAlignment.Center, HSSFColor.LightOrange.Index);
                var style = xlsBook.GeCellStyleAlignment(HorizontalAlignment.Center);
                var style_red = xlsBook.GeCellStyleAlignment(HorizontalAlignment.Center, color: HSSFColor.Red.Index);
                var style_left = xlsBook.GeCellStyleAlignment(HorizontalAlignment.Left);
                var style_tongtuan = xlsBook.GeCellStyleAlignment(HorizontalAlignment.Center, HSSFColor.LightOrange.Index, "Arial Unicode MS");

                xlsSheet.SetColumnWidth(0, 900);
                xlsSheet.SetColumnWidth(1, 1800);
                xlsSheet.SetColumnWidth(2, 5000);
                xlsSheet.SetColumnWidth(3, 2500);

                xlsSheet.Cell(4, 0).SetValue("Stt");
                xlsSheet.Cell(4, 0).SetStyle(xlsBook.GetCellStyle(border: true, color: HSSFColor.BlueGrey.Index, alignment: HorizontalAlignment.Left, text_control: 0));
                xlsSheet.Cell(4, 1).SetValue("Mã VN");
                xlsSheet.Cell(4, 1).SetStyle(xlsBook.GetCellStyle(border: true, color: HSSFColor.BlueGrey.Index, alignment: HorizontalAlignment.Left, text_control: 0));
                xlsSheet.Cell(4, 2).SetValue("Tên nhân viên");
                xlsSheet.Cell(4, 2).SetStyle(xlsBook.GetCellStyle(border: true, color: HSSFColor.BlueGrey.Index, alignment: HorizontalAlignment.Left, text_control: 0));
                xlsSheet.Cell(4, 3).SetValue("Phòng ban");
                xlsSheet.Cell(4, 3).SetStyle(xlsBook.GetCellStyle(border: true, color: HSSFColor.BlueGrey.Index, alignment: HorizontalAlignment.Left, text_control: 0));
                //int column = 4;
                int column = 4;
                List<int> listtuan_hearder = new List<int>();
                int sotuan_h = 1;
                for (int i = 1; i <= dgv_tangca.Columns.Count - 4; i++)
                {
                    xlsSheet.SetColumnWidth(column, 1200);
                    xlsSheet.Cell(4, column).SetValue(i);
                    xlsSheet.Cell(4, column).SetStyle(xlsBook.GetCellStyle(border: true, color: HSSFColor.BlueGrey.Index, alignment: HorizontalAlignment.Center, text_control: 0));
                    DateTime result = new DateTime(int.Parse(cbo_year.Text), int.Parse(cbo_month.Text), i);
                    if (result.DayOfWeek == DayOfWeek.Sunday || ngaycuathang == i)
                    {
                        listtuan_hearder.Add(sotuan_h);
                        sotuan_h++;
                        xlsSheet.Cell(4, column).SetStyle(xlsBook.GetCellStyle(border: true, color: HSSFColor.Grey25Percent.Index, alignment: HorizontalAlignment.Center, text_control: 0));
                        xlsSheet.Cell(4, column + 1).SetValue("Lũy kế tuần");
                        xlsSheet.Cell(4, column + 1).SetStyle(style_tongtuan);
                        xlsSheet.SetColumnWidth(column + 1, 2800);
                        column++;
                    }
                    column++;
                }
                xlsSheet.SetColumnWidth(column, 1800);
                //xlsSheet.SetColumnWidth(column + 1, 1800);
                xlsSheet.Cell(4, column).SetValue("∑ Tháng");
                xlsSheet.Cell(4, column).SetStyle(style_tongtuan);
                for (int i = 0; i < listtuan_hearder.Count; i++)
                {
                    xlsSheet.Cell(4, column + (i + 1)).SetValue("∑ Tuần " + (i + 1));
                    xlsSheet.Cell(4, column + (i + 1)).SetStyle(xlsBook.GetCellStyle(border: true, color: HSSFColor.BlueGrey.Index, alignment: HorizontalAlignment.Center, text_control: 0));
                }

                // 明細情報を設定する
                var rowIndex = 5;
                int index = 1;
                foreach (DataGridViewRow item in dgv_tangca.Rows.Cast<DataGridViewRow>().Where(x => !x.Cells["MaChamCong_TC"].Value.ToString().Contains("KC")))
                {
                    // 明細情報を出力する
                    xlsSheet.Cell(rowIndex, 0).SetValue(index);
                    xlsSheet.Cell(rowIndex, 0).SetStyle(style_left);
                    xlsSheet.Cell(rowIndex, 1).SetValue(item.Cells["MaChamCong_TC"].Value.ToString());
                    xlsSheet.Cell(rowIndex, 1).SetStyle(style_left);
                    xlsSheet.Cell(rowIndex, 2).SetValue(item.Cells["TenNhanVien_TC"].Value.ToString());
                    xlsSheet.Cell(rowIndex, 2).SetStyle(style_left);
                    xlsSheet.Cell(rowIndex, 3).SetValue(item.Cells["TenPhongBan"].Value.ToString());
                    xlsSheet.Cell(rowIndex, 3).SetStyle(style_left);
                    int column1 = 4;
                    decimal tongtuan = 0;
                    decimal tongthang = 0;
                    List<Dictionary<int, string>> listtuan = new List<Dictionary<int, string>>();
                    int sotuan = 1;
                    decimal luyketuan = 0;
                    for (int i = 1; i <= dgv_tangca.Columns.Count - 4; i++)
                    {
                        decimal ngay = (item.Cells["Ngay" + i.ToString()].Value == null ? 0 : decimal.Parse(item.Cells["Ngay" + i.ToString()].Value.ToString()));
                        tongthang = tongthang + ngay;
                        tongtuan = tongtuan + ngay;
                        xlsSheet.Cell(rowIndex, column1).SetValue(double.Parse(ngay.ToString()));
                        if (ngay < 0)
                        {
                            xlsSheet.Cell(rowIndex, column1).SetStyle(style_red);
                        }
                        else
                        {
                            xlsSheet.Cell(rowIndex, column1).SetStyle(style);
                        }
                        DateTime result = new DateTime(int.Parse(cbo_year.Text), int.Parse(cbo_month.Text), i);
                        if (result.DayOfWeek == DayOfWeek.Sunday || ngaycuathang == i)
                        {
                            luyketuan = luyketuan + tongtuan;
                            var fd = new Dictionary<int, string>();
                            fd.Add(sotuan, tongtuan.ToString());
                            listtuan.Add(fd);
                            sotuan++;
                            xlsSheet.Cell(rowIndex, column1).SetStyle(style_color);
                            xlsSheet.Cell(rowIndex, column1 + 1).SetValue(double.Parse(luyketuan.ToString()));
                            //xlsSheet.Cell(rowIndex, column1 + 1).SetValue(double.Parse(tongtuan.ToString()));
                            xlsSheet.Cell(rowIndex, column1 + 1).SetStyle(style_color_LightOrange);
                            tongtuan = 0;
                            column1++;
                        }
                        column1++;
                    }
                    xlsSheet.Cell(rowIndex, column1).SetValue(double.Parse(tongthang.ToString()));
                    xlsSheet.Cell(rowIndex, column1).SetStyle(style_color_LightOrange);
                    for (int i = 0; i < listtuan.Count; i++)
                    {
                        xlsSheet.Cell(rowIndex, column1 + 1 + i).SetValue(double.Parse(listtuan[i].Values.ToList()[0].ToString()));
                        xlsSheet.Cell(rowIndex, column1 + 1 + i).SetStyle(style);
                    }
                    luyketuan = 0;
                    listtuan.Clear();
                    tongthang = 0;
                    tongtuan = 0;
                    index++;
                    rowIndex++;
                }
                // trang 2 hoan chinh
                var xlsSheet_hoanchinh = xlsBook.Sheet(1);
                xlsSheet_hoanchinh.SetLandscape(true);
                xlsSheet_hoanchinh.SetColumnWidth(0, 900);
                xlsSheet_hoanchinh.SetColumnWidth(1, 1800);
                xlsSheet_hoanchinh.SetColumnWidth(2, 5000);
                xlsSheet_hoanchinh.SetColumnWidth(3, 2500);
                xlsSheet_hoanchinh.Cell(4, 0).SetValue("Stt");
                xlsSheet_hoanchinh.Cell(4, 0).SetStyle(xlsBook.GetCellStyle(border: true, color: HSSFColor.BlueGrey.Index, alignment: HorizontalAlignment.Left, text_control: 0));
                xlsSheet_hoanchinh.Cell(4, 1).SetValue("Mã NV");
                xlsSheet_hoanchinh.Cell(4, 1).SetStyle(xlsBook.GetCellStyle(border: true, color: HSSFColor.BlueGrey.Index, alignment: HorizontalAlignment.Left, text_control: 0));
                xlsSheet_hoanchinh.Cell(4, 2).SetValue("Tên nhân viên");
                xlsSheet_hoanchinh.Cell(4, 2).SetStyle(xlsBook.GetCellStyle(border: true, color: HSSFColor.BlueGrey.Index, alignment: HorizontalAlignment.Left, text_control: 0));
                xlsSheet_hoanchinh.Cell(4, 3).SetValue("Phòng ban");
                xlsSheet_hoanchinh.Cell(4, 3).SetStyle(xlsBook.GetCellStyle(border: true, color: HSSFColor.BlueGrey.Index, alignment: HorizontalAlignment.Left, text_control: 0));
                int column_hoanchinh = 4;
                List<int> listtuan_hearder_2 = new List<int>();
                int sotuan_h_2 = 1;
                for (int i = 1; i <= _hoanchinh.Columns.Count - 4; i++)
                {
                    xlsSheet_hoanchinh.SetColumnWidth(column_hoanchinh, 1200);
                    xlsSheet_hoanchinh.Cell(4, column_hoanchinh).SetValue(i);
                    xlsSheet_hoanchinh.Cell(4, column_hoanchinh).SetStyle(xlsBook.GetCellStyle(border: true, color: HSSFColor.BlueGrey.Index, alignment: HorizontalAlignment.Center, text_control: 0));
                    DateTime result = new DateTime(int.Parse(cbo_year.Text), int.Parse(cbo_month.Text), i);
                    if (result.DayOfWeek == DayOfWeek.Sunday || ngaycuathang == i)
                    {
                        listtuan_hearder_2.Add(sotuan_h_2);
                        sotuan_h_2++;
                        xlsSheet_hoanchinh.Cell(4, column_hoanchinh).SetStyle(xlsBook.GetCellStyle(border: true, color: HSSFColor.Grey25Percent.Index, alignment: HorizontalAlignment.Center, text_control: 0));
                        xlsSheet_hoanchinh.Cell(4, column_hoanchinh + 1).SetValue("Lũy kế tuần");
                        xlsSheet_hoanchinh.SetColumnWidth(column_hoanchinh + 1, 2800);
                        xlsSheet_hoanchinh.Cell(4, column_hoanchinh + 1).SetStyle(style_tongtuan);
                        column_hoanchinh++;
                    }
                    column_hoanchinh++;
                }
                xlsSheet_hoanchinh.SetColumnWidth(column_hoanchinh, 1800);
                xlsSheet_hoanchinh.Cell(4, column_hoanchinh).SetValue("∑ Tháng");
                xlsSheet_hoanchinh.Cell(4, column_hoanchinh).SetStyle(style_tongtuan);
                for (int i = 0; i < listtuan_hearder_2.Count; i++)
                {
                    xlsSheet_hoanchinh.Cell(4, column_hoanchinh + (i + 1)).SetValue("∑ Tuần " + (i + 1));
                    xlsSheet_hoanchinh.Cell(4, column_hoanchinh + (i + 1)).SetStyle(xlsBook.GetCellStyle(border: true, color: HSSFColor.BlueGrey.Index, alignment: HorizontalAlignment.Center, text_control: 0));
                }
                // 明細情報を設定する
                var rowIndex_hoanchinh = 5;
                int index_hoanchinh = 1;
                //foreach (DataRow item in _hoanchinh.Rows)
                for (int j = 0; j < _hoanchinh.Rows.Count; j++)
                {
                    // 明細情報を出力する
                    xlsSheet_hoanchinh.Cell(rowIndex_hoanchinh, 0).SetValue(index_hoanchinh);
                    xlsSheet_hoanchinh.Cell(rowIndex_hoanchinh, 0).SetStyle(style_left);
                    xlsSheet_hoanchinh.Cell(rowIndex_hoanchinh, 1).SetValue(_hoanchinh.Rows[j]["MaChamCong"].ToString());
                    xlsSheet_hoanchinh.Cell(rowIndex_hoanchinh, 1).SetStyle(style_left);
                    xlsSheet_hoanchinh.Cell(rowIndex_hoanchinh, 2).SetValue(_hoanchinh.Rows[j]["TenNhanVien"].ToString());
                    xlsSheet_hoanchinh.Cell(rowIndex_hoanchinh, 2).SetStyle(style_left);
                    xlsSheet_hoanchinh.Cell(rowIndex_hoanchinh, 3).SetValue(_hoanchinh.Rows[j]["TenPhongBan"].ToString());
                    xlsSheet_hoanchinh.Cell(rowIndex_hoanchinh, 3).SetStyle(style_left);
                    int column1 = 4;
                    decimal tongtuan = 0;
                    decimal tongthang = 0;
                    List<Dictionary<int, string>> listtuan = new List<Dictionary<int, string>>();
                    int sotuan = 1;
                    decimal luyketuan = 0;
                    for (int i = 1; i <= _hoanchinh.Columns.Count - 4; i++)
                    {
                        decimal tangcangay = (string.IsNullOrEmpty(_hoanchinh.Rows[j]["Ngay" + i.ToString()].ToString()) ? 0 : decimal.Parse(_hoanchinh.Rows[j]["Ngay" + i.ToString()].ToString()));
                        tongthang = tongthang + tangcangay;
                        tongtuan = tongtuan + tangcangay;
                        xlsSheet_hoanchinh.Cell(rowIndex_hoanchinh, column1).SetValue(double.Parse(tangcangay.ToString()));
                        xlsSheet_hoanchinh.Cell(rowIndex_hoanchinh, column1).SetStyle(style);

                        if (_quagio_tangca != null)
                        {
                            var fd = _quagio_tangca.Rows.Cast<DataRow>().Where(x => x.Field<string>("MaChamCong") == _hoanchinh.Rows[j]["MaChamCong"].ToString()).FirstOrDefault();
                            if (fd != null)
                            {
                                if (decimal.Parse(fd[i + 2].ToString()) > 0)
                                {
                                    xlsSheet_hoanchinh.Cell(rowIndex_hoanchinh, column1).SetStyle(xlsBook.GeCellStyleAlignment(HorizontalAlignment.Center, HSSFColor.Yellow.Index));
                                }
                            }
                        }

                        DateTime result = new DateTime(int.Parse(cbo_year.Text), int.Parse(cbo_month.Text), i);
                        if (result.DayOfWeek == DayOfWeek.Sunday || ngaycuathang == i)
                        {
                            luyketuan = luyketuan + tongtuan;
                            var fd = new Dictionary<int, string>();
                            fd.Add(sotuan, tongtuan.ToString());
                            listtuan.Add(fd);
                            sotuan++;
                            xlsSheet_hoanchinh.Cell(rowIndex_hoanchinh, column1).SetStyle(style_color);
                            //xlsSheet_hoanchinh.Cell(rowIndex_hoanchinh, column1 + 1).SetValue(double.Parse(tongtuan.ToString()));
                            xlsSheet_hoanchinh.Cell(rowIndex_hoanchinh, column1 + 1).SetValue(double.Parse(luyketuan.ToString()));
                            xlsSheet_hoanchinh.Cell(rowIndex_hoanchinh, column1 + 1).SetStyle(style_color_LightOrange);
                            tongtuan = 0;
                            column1++;
                        }
                        column1++;
                    }
                    xlsSheet_hoanchinh.Cell(rowIndex_hoanchinh, column1).SetValue(double.Parse(tongthang.ToString()));
                    xlsSheet_hoanchinh.Cell(rowIndex_hoanchinh, column1).SetStyle(style_color_LightOrange);
                    for (int i = 0; i < listtuan.Count; i++)
                    {
                        xlsSheet_hoanchinh.Cell(rowIndex_hoanchinh, column1 + 1 + i).SetValue(double.Parse(listtuan[i].Values.ToList()[0].ToString()));
                        xlsSheet_hoanchinh.Cell(rowIndex_hoanchinh, column1 + 1 + i).SetStyle(style);
                    }
                    index_hoanchinh++;
                    rowIndex_hoanchinh++;
                    tongtuan = 0;
                    tongthang = 0;
                    luyketuan = 0;
                    listtuan.Clear();
                }
                // trang 3 qua gio
                if (_quagio_tangca != null)
                {
                    var xlsSheet_quagio = xlsBook.Sheet(2);
                    xlsSheet_quagio.SetLandscape(true);
                    xlsSheet_quagio.SetColumnWidth(0, 900);
                    xlsSheet_quagio.SetColumnWidth(1, 1800);
                    xlsSheet_quagio.SetColumnWidth(2, 5000);
                    xlsSheet_quagio.SetColumnWidth(3, 2500);
                    xlsSheet_quagio.Cell(4, 0).SetValue("Stt");
                    xlsSheet_quagio.Cell(4, 0).SetStyle(xlsBook.GetCellStyle(border: true, color: HSSFColor.BlueGrey.Index, alignment: HorizontalAlignment.Left, text_control: 0));
                    xlsSheet_quagio.Cell(4, 1).SetValue("Mã NV");
                    xlsSheet_quagio.Cell(4, 1).SetStyle(xlsBook.GetCellStyle(border: true, color: HSSFColor.BlueGrey.Index, alignment: HorizontalAlignment.Left, text_control: 0));
                    xlsSheet_quagio.Cell(4, 2).SetValue("Tên nhân viên");
                    xlsSheet_quagio.Cell(4, 2).SetStyle(xlsBook.GetCellStyle(border: true, color: HSSFColor.BlueGrey.Index, alignment: HorizontalAlignment.Left, text_control: 0));
                    xlsSheet_quagio.Cell(4, 3).SetValue("Phòng ban");
                    xlsSheet_quagio.Cell(4, 3).SetStyle(xlsBook.GetCellStyle(border: true, color: HSSFColor.BlueGrey.Index, alignment: HorizontalAlignment.Left, text_control: 0));
                    int column_quagio = 4;
                    List<int> listtuan_hearder_3 = new List<int>();
                    int sotuan_h_3 = 1;
                    for (int i = 1; i <= _quagio_tangca.Columns.Count - 4; i++)
                    {
                        xlsSheet_quagio.SetColumnWidth(column_quagio, 1200);
                        xlsSheet_quagio.Cell(4, column_quagio).SetValue(i);
                        xlsSheet_quagio.Cell(4, column_quagio).SetStyle(xlsBook.GetCellStyle(border: true, color: HSSFColor.BlueGrey.Index, alignment: HorizontalAlignment.Center, text_control: 0));
                        DateTime result = new DateTime(int.Parse(cbo_year.Text), int.Parse(cbo_month.Text), i);
                        if (result.DayOfWeek == DayOfWeek.Sunday || ngaycuathang == i)
                        {
                            listtuan_hearder_3.Add(sotuan_h_3);
                            sotuan_h_3++;
                            xlsSheet_quagio.Cell(4, column_quagio).SetStyle(xlsBook.GetCellStyle(border: true, color: IndexedColors.Grey25Percent.Index, alignment: HorizontalAlignment.Center, text_control: 0));
                            xlsSheet_quagio.Cell(4, column_quagio + 1).SetValue("Lũy kế tuần");
                            xlsSheet_quagio.SetColumnWidth(column_quagio + 1, 2800);
                            xlsSheet_quagio.Cell(4, column_quagio + 1).SetStyle(style_tongtuan);
                            column_quagio++;
                        }
                        column_quagio++;
                    }
                    xlsSheet_quagio.SetColumnWidth(column_quagio, 1800);
                    xlsSheet_quagio.Cell(4, column_quagio).SetValue("∑ Tháng");
                    xlsSheet_quagio.Cell(4, column_quagio).SetStyle(style_tongtuan);
                    for (int i = 0; i < listtuan_hearder_3.Count; i++)
                    {
                        xlsSheet_quagio.Cell(4, column_quagio + (i + 1)).SetValue("∑ Tuần " + (i + 1));
                        xlsSheet_quagio.Cell(4, column_quagio + (i + 1)).SetStyle(xlsBook.GetCellStyle(border: true, color: HSSFColor.BlueGrey.Index, alignment: HorizontalAlignment.Center, text_control: 0));
                    }

                    // 明細情報を設定する
                    var rowIndex_quagio = 5;
                    int index_quagio = 1;
                    foreach (DataRow item in _quagio_tangca.Rows)
                    {
                        // 明細情報を出力する
                        xlsSheet_quagio.Cell(rowIndex_quagio, 0).SetValue(index_quagio);
                        xlsSheet_quagio.Cell(rowIndex_quagio, 0).SetStyle(style_left);
                        xlsSheet_quagio.Cell(rowIndex_quagio, 1).SetValue(item["MaChamCong"].ToString());
                        xlsSheet_quagio.Cell(rowIndex_quagio, 1).SetStyle(style_left);
                        xlsSheet_quagio.Cell(rowIndex_quagio, 2).SetValue(item["TenNhanVien"].ToString());
                        xlsSheet_quagio.Cell(rowIndex_quagio, 2).SetStyle(style_left);
                        xlsSheet_quagio.Cell(rowIndex_quagio, 3).SetValue(item["TenPhongBan"].ToString());
                        xlsSheet_quagio.Cell(rowIndex_quagio, 3).SetStyle(style_left);
                        int column1 = 4;
                        decimal tongtuan = 0;
                        decimal tongthang = 0;
                        List<Dictionary<int, string>> listtuan = new List<Dictionary<int, string>>();
                        int sotuan = 1;
                        decimal luyketuan = 0;
                        for (int i = 1; i <= _quagio_tangca.Columns.Count - 4; i++)
                        {
                            decimal tangcangay = (item["Ngay" + i.ToString()] == null ? 0 : decimal.Parse(item["Ngay" + i.ToString()].ToString()));
                            tongthang = tongthang + tangcangay;
                            tongtuan = tongtuan + tangcangay;
                            xlsSheet_quagio.Cell(rowIndex_quagio, column1).SetValue(double.Parse(tangcangay.ToString()));
                            xlsSheet_quagio.Cell(rowIndex_quagio, column1).SetStyle(style);
                            DateTime result = new DateTime(int.Parse(cbo_year.Text), int.Parse(cbo_month.Text), i);
                            if (result.DayOfWeek == DayOfWeek.Sunday || ngaycuathang == i)
                            {
                                luyketuan = luyketuan + tongtuan;
                                var fd = new Dictionary<int, string>();
                                fd.Add(sotuan, tongtuan.ToString());
                                listtuan.Add(fd);
                                xlsSheet_quagio.Cell(rowIndex_quagio, column1).SetStyle(style_color);
                                //xlsSheet_quagio.Cell(rowIndex_quagio, column1 + 1).SetValue(double.Parse(tongtuan.ToString()));
                                xlsSheet_quagio.Cell(rowIndex_quagio, column1 + 1).SetValue(double.Parse(luyketuan.ToString()));
                                xlsSheet_quagio.Cell(rowIndex_quagio, column1 + 1).SetStyle(style_color_LightOrange);
                                tongtuan = 0;
                                column1++;
                            }
                            column1++;
                        }
                        xlsSheet_quagio.Cell(rowIndex_quagio, column1).SetValue(double.Parse(tongthang.ToString()));
                        xlsSheet_quagio.Cell(rowIndex_quagio, column1).SetStyle(style_color_LightOrange);
                        for (int i = 0; i < listtuan.Count; i++)
                        {
                            xlsSheet_quagio.Cell(rowIndex_quagio, column1 + 1 + i).SetValue(double.Parse(listtuan[i].Values.ToList()[0].ToString()));
                            xlsSheet_quagio.Cell(rowIndex_quagio, column1 + 1 + i).SetStyle(style);
                        }
                        tongthang = 0;
                        tongtuan = 0;
                        luyketuan = 0;
                        listtuan.Clear();
                        index_quagio++;
                        rowIndex_quagio++;
                    }
                }

                // シート名を設定する
                xlsBook.SetSheetName(0, "Tổng hợp");
                xlsBook.SetSheetName(1, "Hoàn chỉnh");
                xlsBook.SetSheetName(2, "Quá giờ");

                // 保存先フォルダ有無のチェック
                // ※保存先フォルダが存在しない場合、フォルダを作成する
                if (!Directory.Exists(Environment.GetFolderPath(Environment.SpecialFolder.Desktop))) Directory.CreateDirectory(Environment.GetFolderPath(Environment.SpecialFolder.Desktop));

                // 保存
                xlsBook.Save($@"{Environment.GetFolderPath(Environment.SpecialFolder.Desktop)}\DuLieuTangCaThang_" + cbo_month.Text + "_" + cbo_year.Text + ".xlsx");

                // ワークファイル削除
                File.Delete(workPath);

                RJMessageBox.Show("Xuất excel thành công \n" + $@"{Environment.GetFolderPath(Environment.SpecialFolder.Desktop)}\DuLieuTangCaThang_" + cbo_month.Text + "_" + cbo_year.Text + ".xlsx", "Thông báo");
            }
            catch (Exception ex)
            {
                RJMessageBox.Show(ex.Message, "Thông báo");
            }
            finally
            {
                // ワークファイル削除
                File.Delete(workPath);
            }
        }
        public void xuatExcelThoiVu()
        {
            int ngaycuathang = new DateTime(int.Parse(cbo_year.Text), int.Parse(cbo_month.Text), 1).AddMonths(1).AddDays(-1).Day;
            var workPath = $@"{Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData)}\template_work_excel_thoivu.xlsx";
            if (File.Exists(workPath))
            {
                File.Delete(workPath);
            }
            try
            {
                var xlsBook = new XlsWorkBook(workPath);
                // テンプレートシートを読み込み
                var xlsSheet = xlsBook.Sheet(0);
                xlsSheet.SetLandscape(true);
                var style_color = xlsBook.GeCellStyleAlignment(HorizontalAlignment.Center, HSSFColor.Grey25Percent.Index);
                var style_color_LightOrange = xlsBook.GeCellStyleAlignment(HorizontalAlignment.Center, HSSFColor.LightOrange.Index);
                var style = xlsBook.GeCellStyleAlignment(HorizontalAlignment.Center);
                var style_red = xlsBook.GeCellStyleAlignment(HorizontalAlignment.Center, color: HSSFColor.Red.Index);
                var style_left = xlsBook.GeCellStyleAlignment(HorizontalAlignment.Left);
                var style_tongtuan = xlsBook.GeCellStyleAlignment(HorizontalAlignment.Center, HSSFColor.LightOrange.Index, "Arial Unicode MS");

                xlsSheet.SetColumnWidth(0, 900);
                xlsSheet.SetColumnWidth(1, 1800);
                xlsSheet.SetColumnWidth(2, 5000);
                xlsSheet.SetColumnWidth(3, 2500);

                xlsSheet.Cell(4, 0).SetValue("Stt");
                xlsSheet.Cell(4, 0).SetStyle(xlsBook.GetCellStyle(border: true, color: HSSFColor.BlueGrey.Index, alignment: HorizontalAlignment.Left, text_control: 0));
                xlsSheet.Cell(4, 1).SetValue("Mã VN");
                xlsSheet.Cell(4, 1).SetStyle(xlsBook.GetCellStyle(border: true, color: HSSFColor.BlueGrey.Index, alignment: HorizontalAlignment.Left, text_control: 0));
                xlsSheet.Cell(4, 2).SetValue("Tên nhân viên");
                xlsSheet.Cell(4, 2).SetStyle(xlsBook.GetCellStyle(border: true, color: HSSFColor.BlueGrey.Index, alignment: HorizontalAlignment.Left, text_control: 0));
                xlsSheet.Cell(4, 3).SetValue("Phòng ban");
                xlsSheet.Cell(4, 3).SetStyle(xlsBook.GetCellStyle(border: true, color: HSSFColor.BlueGrey.Index, alignment: HorizontalAlignment.Left, text_control: 0));
                //int column = 4;
                int column = 4;
                List<int> listtuan_hearder = new List<int>();
                int sotuan_h = 1;
                for (int i = 1; i <= _thoivu.Columns.Count - 4; i++)
                {
                    xlsSheet.SetColumnWidth(column, 1200);
                    xlsSheet.Cell(4, column).SetValue(i);
                    xlsSheet.Cell(4, column).SetStyle(xlsBook.GetCellStyle(border: true, color: HSSFColor.BlueGrey.Index, alignment: HorizontalAlignment.Center, text_control: 0));
                    DateTime result = new DateTime(int.Parse(cbo_year.Text), int.Parse(cbo_month.Text), i);
                    if (result.DayOfWeek == DayOfWeek.Sunday || ngaycuathang == i)
                    {
                        listtuan_hearder.Add(sotuan_h);
                        sotuan_h++;
                        xlsSheet.Cell(4, column).SetStyle(xlsBook.GetCellStyle(border: true, color: HSSFColor.Grey25Percent.Index, alignment: HorizontalAlignment.Center, text_control: 0));
                        xlsSheet.Cell(4, column + 1).SetValue("Lũy kế tuần");
                        xlsSheet.Cell(4, column + 1).SetStyle(style_tongtuan);
                        xlsSheet.SetColumnWidth(column + 1, 2800);
                        column++;
                    }
                    column++;
                }
                xlsSheet.SetColumnWidth(column, 1800);
                xlsSheet.Cell(4, column).SetValue("∑ Tháng");
                xlsSheet.Cell(4, column).SetStyle(style_tongtuan);
                for (int i = 0; i < listtuan_hearder.Count; i++)
                {
                    xlsSheet.Cell(4, column + (i + 1)).SetValue("∑ Tuần " + (i + 1));
                    xlsSheet.Cell(4, column + (i + 1)).SetStyle(xlsBook.GetCellStyle(border: true, color: HSSFColor.BlueGrey.Index, alignment: HorizontalAlignment.Center, text_control: 0));
                }

                // 明細情報を設定する
                var rowIndex = 5;
                int index = 1;
                foreach (DataRow item in _thoivu.Rows)
                {
                    // 明細情報を出力する
                    xlsSheet.Cell(rowIndex, 0).SetValue(index);
                    xlsSheet.Cell(rowIndex, 0).SetStyle(style_left);
                    xlsSheet.Cell(rowIndex, 1).SetValue(item["MaChamCong"].ToString());
                    xlsSheet.Cell(rowIndex, 1).SetStyle(style_left);
                    xlsSheet.Cell(rowIndex, 2).SetValue(item["TenNhanVien"].ToString());
                    xlsSheet.Cell(rowIndex, 2).SetStyle(style_left);
                    xlsSheet.Cell(rowIndex, 3).SetValue(item["TenPhongBan"].ToString());
                    xlsSheet.Cell(rowIndex, 3).SetStyle(style_left);
                    int column1 = 4;
                    decimal tongtuan = 0;
                    decimal tongthang = 0;
                    List<Dictionary<int, string>> listtuan = new List<Dictionary<int, string>>();
                    int sotuan = 1;
                    decimal luyketuan = 0;
                    for (int i = 1; i <= _thoivu.Columns.Count - 4; i++)
                    {
                        decimal ngay = (item["Ngay" + i.ToString()] == null ? 0 : decimal.Parse(item["Ngay" + i.ToString()].ToString()));
                        tongthang = tongthang + ngay;
                        tongtuan = tongtuan + ngay;
                        xlsSheet.Cell(rowIndex, column1).SetValue(double.Parse(ngay.ToString()));
                        if (ngay < 0)
                        {
                            xlsSheet.Cell(rowIndex, column1).SetStyle(style_red);
                        }
                        else
                        {
                            xlsSheet.Cell(rowIndex, column1).SetStyle(style);
                        }
                        DateTime result = new DateTime(int.Parse(cbo_year.Text), int.Parse(cbo_month.Text), i);
                        if (result.DayOfWeek == DayOfWeek.Sunday || ngaycuathang == i)
                        {
                            luyketuan = luyketuan + tongtuan;
                            var fd = new Dictionary<int, string>();
                            fd.Add(sotuan, tongtuan.ToString());
                            listtuan.Add(fd);
                            sotuan++;
                            xlsSheet.Cell(rowIndex, column1).SetStyle(style_color);
                            xlsSheet.Cell(rowIndex, column1 + 1).SetValue(double.Parse(luyketuan.ToString()));
                            xlsSheet.Cell(rowIndex, column1 + 1).SetStyle(style_color_LightOrange);
                            tongtuan = 0;
                            column1++;
                        }
                        column1++;
                    }
                    xlsSheet.Cell(rowIndex, column1).SetValue(double.Parse(tongthang.ToString()));
                    xlsSheet.Cell(rowIndex, column1).SetStyle(style_color_LightOrange);
                    for (int i = 0; i < listtuan.Count; i++)
                    {
                        xlsSheet.Cell(rowIndex, column1 + 1 + i).SetValue(double.Parse(listtuan[i].Values.ToList()[0].ToString()));
                        xlsSheet.Cell(rowIndex, column1 + 1 + i).SetStyle(style);
                    }
                    luyketuan = 0;
                    listtuan.Clear();
                    tongthang = 0;
                    tongtuan = 0;
                    index++;
                    rowIndex++;
                }

                // シート名を設定する
                xlsBook.SetSheetName(0, "Tổng hợp");

                // 保存先フォルダ有無のチェック
                // ※保存先フォルダが存在しない場合、フォルダを作成する
                if (!Directory.Exists(Environment.GetFolderPath(Environment.SpecialFolder.Desktop))) Directory.CreateDirectory(Environment.GetFolderPath(Environment.SpecialFolder.Desktop));

                // 保存
                xlsBook.Save($@"{Environment.GetFolderPath(Environment.SpecialFolder.Desktop)}\DuLieuTangCaThang_" + cbo_month.Text + "_" + cbo_year.Text + "_ThoiVu.xlsx");

                // ワークファイル削除
                File.Delete(workPath);

                RJMessageBox.Show("Xuất excel thành công \n" + $@"{Environment.GetFolderPath(Environment.SpecialFolder.Desktop)}\DuLieuTangCaThang_" + cbo_month.Text + "_" + cbo_year.Text + "_ThoiVu.xlsx", "Thông báo");
            }
            catch (Exception ex)
            {
                RJMessageBox.Show(ex.Message, "Thông báo");
            }
            finally
            {
                // ワークファイル削除
                File.Delete(workPath);
            }
        }

        private void btn_excel_sai_Click(object sender, EventArgs e)
        {
            Cursor.Current = Cursors.WaitCursor;
            var workPath = $@"{Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData)}\template_work_excel_sai.xlsx";
            if (File.Exists(workPath))
            {
                File.Delete(workPath);
            }
            try
            {
                var xlsBook = new XlsWorkBook(workPath, 1);
                // テンプレートシートを読み込み
                var xlsSheet = xlsBook.Sheet(0);
                xlsSheet.SetLandscape(true);
                var style_color = xlsBook.GeCellStyleAlignment(HorizontalAlignment.Center, HSSFColor.Grey25Percent.Index);
                var style_color_LightOrange = xlsBook.GeCellStyleAlignment(HorizontalAlignment.Center, HSSFColor.LightOrange.Index);
                var style = xlsBook.GeCellStyleAlignment(HorizontalAlignment.Center);
                var style_left = xlsBook.GeCellStyleAlignment(HorizontalAlignment.Left);
                var style_tongtuan = xlsBook.GeCellStyleAlignment(HorizontalAlignment.Center, HSSFColor.LightOrange.Index, "Arial Unicode MS");


                xlsSheet.SetColumnWidth(0, 900);
                xlsSheet.SetColumnWidth(1, 1800);
                xlsSheet.SetColumnWidth(2, 5000);
                xlsSheet.SetColumnWidth(3, 5000);
                xlsSheet.SetColumnWidth(4, 5000);

                xlsSheet.Cell(0, 0).SetValue("Stt");
                xlsSheet.Cell(0, 0).SetStyle(xlsBook.GetCellStyle(border: true, color: HSSFColor.BlueGrey.Index, alignment: HorizontalAlignment.Left, text_control: 0));
                xlsSheet.Cell(0, 1).SetValue("Mã CC");
                xlsSheet.Cell(0, 1).SetStyle(xlsBook.GetCellStyle(border: true, color: HSSFColor.BlueGrey.Index, alignment: HorizontalAlignment.Left, text_control: 0));
                xlsSheet.Cell(0, 2).SetValue("Tên nhân viên");
                xlsSheet.Cell(0, 2).SetStyle(xlsBook.GetCellStyle(border: true, color: HSSFColor.BlueGrey.Index, alignment: HorizontalAlignment.Left, text_control: 0));
                xlsSheet.Cell(0, 3).SetValue("Ngày");
                xlsSheet.Cell(0, 3).SetStyle(xlsBook.GetCellStyle(border: true, color: HSSFColor.BlueGrey.Index, alignment: HorizontalAlignment.Left, text_control: 0));
                xlsSheet.Cell(0, 4).SetValue("Lý do");
                xlsSheet.Cell(0, 4).SetStyle(xlsBook.GetCellStyle(border: true, color: HSSFColor.BlueGrey.Index, alignment: HorizontalAlignment.Left, text_control: 0));
                // 明細情報を設定する
                var rowIndex = 1;
                int index = 1;
                foreach (DataGridViewRow item in dgv_dacbiet.Rows)
                {
                    // 明細情報を出力する
                    xlsSheet.Cell(rowIndex, 0).SetValue(index);
                    xlsSheet.Cell(rowIndex, 0).SetStyle(style_left);
                    xlsSheet.Cell(rowIndex, 1).SetValue(item.Cells["MaChamCong_l"].Value.ToString());
                    xlsSheet.Cell(rowIndex, 1).SetStyle(style_left);
                    xlsSheet.Cell(rowIndex, 2).SetValue(item.Cells["TenNhanVien_l"].Value.ToString());
                    xlsSheet.Cell(rowIndex, 2).SetStyle(style_left);
                    xlsSheet.Cell(rowIndex, 3).SetValue(item.Cells["Ngay"].Value.ToString());
                    xlsSheet.Cell(rowIndex, 3).SetStyle(style_left);
                    xlsSheet.Cell(rowIndex, 4).SetValue(item.Cells["LyDo_l"].Value.ToString());
                    xlsSheet.Cell(rowIndex, 4).SetStyle(style_left);
                    index++;
                    rowIndex++;
                }
                // 保存先フォルダ有無のチェック
                // ※保存先フォルダが存在しない場合、フォルダを作成する
                if (!Directory.Exists(Environment.GetFolderPath(Environment.SpecialFolder.Desktop))) Directory.CreateDirectory(Environment.GetFolderPath(Environment.SpecialFolder.Desktop));

                // 保存
                xlsBook.Save($@"{Environment.GetFolderPath(Environment.SpecialFolder.Desktop)}\ChamCongSai_" + cbo_month.Text + "_" + cbo_year.Text + ".xlsx");

                // ワークファイル削除
                File.Delete(workPath);

                RJMessageBox.Show("Xuất excel thành công \n" + $@"{Environment.GetFolderPath(Environment.SpecialFolder.Desktop)}\ChamCongSai" + cbo_month.Text + "_" + cbo_year.Text + ".xlsx", "Thông báo");
            }
            catch (Exception ex)
            {
                RJMessageBox.Show(ex.Message, "Thông báo");
            }
            finally
            {
                File.Delete(workPath);
            }
            Cursor.Current = Cursors.Default;
        }
        private void btn_save()
        {
            Cursor.Current = Cursors.WaitCursor;
            using (SqlConnection con = new SqlConnection(SQLHelper.GetSqlConnection()))
            {
                con.Open();
                List<string> sql_insert = new List<string>();
                var tran = con.BeginTransaction();
                try
                {
                    if (_quagio_tangca != null && _quagio_tangca.Rows.Count > 0)
                    {
                        string delete = $"delete QuaGioTangCa where Nam = {cbo_year.Text} and Thang = {cbo_month.Text};";
                        sql_insert.Add(delete);
                        foreach (DataRow item in _quagio_tangca.Rows)
                        {
                            string sql = "insert into MITACOSQL.dbo.QuaGioTangCa(Nam,Thang,MaNhanVien,D1,D2,D3,D4,D5,D6,D7,D8,D9,D10," +
                               "D11,D12,D13,D14,D15,D16,D17,D18,D19,D20," +
                               "D21,D22,D23,D24,D25,D26,D27,D28,D29,D30,D31)" +
                              "Values(" +
                              $"'{cbo_year.Text}','{cbo_month.Text}','{item["MaChamCong"].ToString()}'," +
                              $"'{item["Ngay1"]}','{item["Ngay2"]}','{item["Ngay3"]}','{item["Ngay4"]}','{item["Ngay5"]}'," +
                              $"'{item["Ngay6"]}','{item["Ngay7"]}','{item["Ngay8"]}','{item["Ngay9"]}','{item["Ngay10"]}'," +
                              $"'{item["Ngay11"]}','{item["Ngay12"]}','{item["Ngay13"]}','{item["Ngay14"]}','{item["Ngay15"]}'," +
                              $"'{item["Ngay16"]}','{item["Ngay17"]}','{item["Ngay18"]}','{item["Ngay19"]}','{item["Ngay20"]}'," +
                              $"'{item["Ngay21"]}','{item["Ngay22"]}','{item["Ngay23"]}','{item["Ngay24"]}','{item["Ngay25"]}'," +
                              $"'{item["Ngay26"]}','{item["Ngay27"]}','{item["Ngay28"]}'," +
                              $"'{(_quagio_tangca.Columns.Count > 32 ? decimal.Parse(item["Ngay29"].ToString()) : 0)}'," +
                              $"'{(_quagio_tangca.Columns.Count > 33 ? decimal.Parse(item["Ngay30"].ToString()) : 0)}'," +
                              $"'{(_quagio_tangca.Columns.Count > 34 ? decimal.Parse(item["Ngay31"].ToString()) : 0)}'" +
                              ");";
                            sql_insert.Add(sql);
                        }
                        string ex_sql = string.Join("\r\n", sql_insert.ToArray());
                        SqlCommand sqlCommand = new SqlCommand();
                        sqlCommand.Connection = con;
                        sqlCommand.Transaction = tran;
                        sqlCommand.CommandText = ex_sql;
                        sqlCommand.ExecuteNonQuery();
                        tran.Commit();
                        con.Close();
                        //RJMessageBox.Show("Lưu dữ liệu thành công", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
                catch (Exception ex)
                {
                    tran.Rollback();
                    RJMessageBox.Show(ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            Cursor.Current = Cursors.Default;
        }

        private void btn_ChinhGioTuDong_Click(object sender, EventArgs e)
        {
            frm_XoaGioTangCa frm = new frm_XoaGioTangCa();
            frm.data = _quagio_tangca;
            frm.year = cbo_year.Text;
            frm.month = cbo_month.Text;
            frm.ShowDialog();
        }

        private void dgv_tangca_RowPostPaint(object sender, DataGridViewRowPostPaintEventArgs e)
        {
            var grid = sender as DataGridView;
            var rowIdx = (e.RowIndex + 1).ToString();
            var centerFormat = new StringFormat
            {
                Alignment = StringAlignment.Center,
                LineAlignment = StringAlignment.Center
            };
            var textSize = TextRenderer.MeasureText(rowIdx, Font);
            //if (grid.RowHeadersWidth < textSize.Width + 10)
            //{
            //    grid.RowHeadersWidth = textSize.Width + 10;
            //}
            var headerBounds =
                new Rectangle(e.RowBounds.Left, e.RowBounds.Top, grid.RowHeadersWidth, e.RowBounds.Height);
            e.Graphics.DrawString(rowIdx, Font, SystemBrushes.ControlText, headerBounds, centerFormat);
        }
    }
}
