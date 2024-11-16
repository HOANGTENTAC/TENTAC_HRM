using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Text.RegularExpressions;
using System.Windows.Forms;

namespace TENTAC_HRM
{
    class DataProvider
    {
        public DataTable load_nhanvien()
        {
            string sql = "select MaNhanVien as value,TenNhanVien as name from MITACOSQL.dbo.NHANVIEN";
            DataTable dt = new DataTable();
            dt = SQLHelper.ExecuteDt(sql);
            dt.Rows.Add("0", "");
            return dt.Rows.Cast<DataRow>().OrderBy(x => x.Field<string>("value")).CopyToDataTable();
        }
        public DataTable load_gioitinh()
        {
            DataTable datatable = new DataTable();
            datatable.Columns.Add("id");
            datatable.Columns.Add("name");
            datatable.Rows.Add("0", "Nữ");
            datatable.Rows.Add("1", "Nam");
            return datatable;
        }
        public DataTable load_tinh()
        {
            string sql = "select Id,TenDiaChi from mst_DonViHanhChinh where LoaiDiaChi = 22";
            DataTable dt = new DataTable();
            dt = SQLHelper.ExecuteDt(sql);
            return dt;
        }
        public DataTable load_dantoc()
        {
            string sql = "SELECT MaDanToc as id, TenDanToc as name from mst_DanToc where del_flg = 0";
            DataTable dt = new DataTable();
            dt = SQLHelper.ExecuteDt(sql);
            dt.Rows.Add("0", "");
            return dt.Rows.Cast<DataRow>().OrderBy(x => x.Field<int>("MaDanToc")).CopyToDataTable();
        }
        /// <summary>
        /// 20 quoc gia
        /// 21 thành phố
        /// 22 tỉnh
        /// 23 thi xã
        /// 24 quan
        /// 25 huyen
        /// 26 phuong
        /// 27 thị trấn
        /// 28 xã
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public DataTable load_diachi(int id)
        {
            string sql = string.Format("select MaDiaChi as id, MaDiaChi + ' - ' + TenDiaChi as name from mst_DonViHanhChinh where delflg = 0 and LoaiDiaChi = '{0}'", id);
            DataTable dt = new DataTable();
            dt = SQLHelper.ExecuteDt(sql);
            dt.Rows.Add("0", "");
            return dt.Rows.Cast<DataRow>().OrderBy(x => x.Field<string>("id")).CopyToDataTable();
        }
        public DataTable LoadDiaChiNew(int id)
        {
            string sql = $@"select Id, TenDiaChi as Name from mst_DonViHanhChinh where delflg = 0 and LoaiDiaChi = {SQLHelper.rpI(id)}";
            DataTable dt = new DataTable();
            dt = SQLHelper.ExecuteDt(sql);
            dt.Rows.Add("0", "");
            return dt.Rows.Cast<DataRow>().OrderBy(x => x.Field<int>("id")).CopyToDataTable();
        }

        /// <summary>
        /// 1 trạng thái công việc
        /// 10 tình trạng hôn nhân
        /// 40 loại địa chỉ
        /// 50 loại bảo hiểm
        /// 70 loại đào tạo
        /// 80 quan hệ gia đình
        /// 147 cấp khen thưởng
        /// 151 loại tai nạn
        /// 156 mức độ tai nạn
        /// 164 Hiện trạng tài sản
        /// 170 Trạng thái tài sản
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public DataTable load_all_type(int id)
        {
            string sql = string.Format("select TypeId as id,case when TypeNameShort is null then '' else TypeNameShort + ' ' end + TypeName as name " +
                "from sys_AllType where TypeType = {0}", id);
            DataTable dt = new DataTable();
            dt = SQLHelper.ExecuteDt(sql);
            dt.Rows.Add("0", "");
            return dt.Rows.Cast<DataRow>().OrderBy(x => x.Field<int>("id")).CopyToDataTable();
        }
        public DataTable load_loainghiviec()
        {
            string sql = string.Format("select TypeId as id,TypeName as name from sys_AllType where TypeType = 1 and TypeNameShort = 'NGV'");
            DataTable dt = new DataTable();
            dt = SQLHelper.ExecuteDt(sql);
            dt.Rows.Add("0", "");
            return dt.Rows.Cast<DataRow>().OrderBy(x => x.Field<int>("id")).CopyToDataTable();
        }
        public DataTable load_loaiphep()
        {
            string sql = string.Format("SELECT id_nghi_phep as id,ten_nghi_phep as name,ky_hieu FROM tas_nghi_phep");
            DataTable dt = new DataTable();
            dt = SQLHelper.ExecuteDt(sql);
            dt.Rows.Add("0", "");
            return dt.Rows.Cast<DataRow>().OrderBy(x => x.Field<int>("id")).CopyToDataTable();
        }
        public DataTable load_loaiphucap()
        {
            string sql = "select id_loai_phu_cap,ten_loai_phu_cap from hrm_loai_phu_cap";
            DataTable dt = new DataTable();
            dt = SQLHelper.ExecuteDt(sql);
            dt.Rows.Add("0", "");
            return dt.Rows.Cast<DataRow>().OrderBy(x => x.Field<int>("id_loai_phu_cap")).CopyToDataTable();
        }
        public DataTable load_loaihopdong()
        {
            string sql = "select id_loai_hop_dong as id,ten_ngan + ' - ' + ten_loai_hop_dong as name from hrm_loai_hop_dong";
            DataTable dt = new DataTable();
            dt = SQLHelper.ExecuteDt(sql);
            dt.Rows.Add("0", "");
            return dt.Rows.Cast<DataRow>().OrderBy(x => x.Field<int>("id")).CopyToDataTable();
        }
        public DataTable load_report_to()
        {
            string sql = "select a.MaNhanVien as id, a.TenNhanVien as name, b.TenChucVu " +
                "from MITACOSQL.dbo.NHANVIEN a " +
                "left join MITACOSQL.dbo.ChucVu b on b.MaChucVu = a.MaChucVu";
            DataTable dt = new DataTable();
            dt = SQLHelper.ExecuteDt(sql);
            dt.Rows.Add("0", "");
            return dt.Rows.Cast<DataRow>().OrderBy(x => x.Field<string>("id")).CopyToDataTable();
        }
        /// <summary>
        /// 1 cty
        /// 2 khu vuc
        /// 3 phong ban
        /// 4 chức vụ
        /// </summary>
        /// <param name="type"></param>
        /// <returns></returns>
        public DataTable load_treeview(int type)
        {
            string sql = string.Format("select ma_phong_ban as id,ten_phong_ban as name from phong_ban where id_loai_phong_ban = {0}", type);
            DataTable dt = new DataTable();
            dt = SQLHelper.ExecuteDt(sql);
            return dt;
        }
        public DataTable load_chuc_vu()
        {
            string sql = string.Format("select ma_chuc_vu as id,ten_chuc_vu as name from chuc_vu");
            DataTable dt = new DataTable();
            dt = SQLHelper.ExecuteDt(sql);
            return dt;
        }
        public DataTable load_xeploai()
        {
            string sql = string.Format("select TypeNameShort as id, TypeName as name from sys_AllType where TypeType = '174'");
            DataTable dt = new DataTable();
            dt = SQLHelper.ExecuteDt(sql);
            return dt;
        }
        public string viet_hoa_chu_cai_dau(string ky_tu)
        {
            char[] charArray = ky_tu.ToCharArray();
            bool foundSpace = true;
            for (int i = 0; i < charArray.Length; i++)
            {
                //sử dụng phương thức IsLetter() để kiểm tra từng phần tử có phải là một chữ cái
                if (Char.IsLetter(charArray[i]))
                {
                    if (foundSpace)
                    {
                        //nếu phải thì sử dụng phương thức ToUpper() để in hoa ký tự đầu
                        charArray[i] = Char.ToUpper(charArray[i]);
                        foundSpace = false;
                    }
                    else
                    {
                        charArray[i] = Char.ToLower(charArray[i]);
                    }
                }
                else
                {
                    foundSpace = true;
                }
            }
            return new string(charArray);
        }
        /// <summary>
        /// Remove VietName Tone
        /// </summary>
        /// <param name="text"></param>
        /// <returns></returns>
        public string RemoveVietnameseTone(string text)
        {
            string result = text.ToLower();
            result = Regex.Replace(result, "à|á|ạ|ả|ã|â|ầ|ấ|ậ|ẩ|ẫ|ă|ằ|ắ|ặ|ẳ|ẵ|/g", "a");
            result = Regex.Replace(result, "è|é|ẹ|ẻ|ẽ|ê|ề|ế|ệ|ể|ễ|/g", "e");
            result = Regex.Replace(result, "ì|í|ị|ỉ|ĩ|/g", "i");
            result = Regex.Replace(result, "ò|ó|ọ|ỏ|õ|ô|ồ|ố|ộ|ổ|ỗ|ơ|ờ|ớ|ợ|ở|ỡ|/g", "o");
            result = Regex.Replace(result, "ù|ú|ụ|ủ|ũ|ư|ừ|ứ|ự|ử|ữ|/g", "u");
            result = Regex.Replace(result, "ỳ|ý|ỵ|ỷ|ỹ|/g", "y");
            result = Regex.Replace(result, "đ", "d");
            return result;
        }
        /// <summary>
        /// only mumber and .
        /// </summary>
        /// <param name="c"></param>
        /// <returns></returns>
        public virtual bool IsValidChar(char c)
        {
            return (c >= '0' && c <= '9') || (c == '.') || (c == (char)Keys.Back);
        }
        /// <summary>
        /// only number
        /// </summary>
        /// <param name="c"></param>
        /// <returns></returns>
        public virtual bool IsValidNumber(char c)
        {
            return (c >= '0' && c <= '9') || (c == (char)Keys.Back) || (c == (char)Keys.Delete);
        }
        /// <summary>
        /// get name from full name
        /// </summary>
        /// <param name="value"></param>
        /// <param name="type"></param>
        /// <returns></returns>
        public string cat_ho_ten(string value, int type)
        {
            string ht = value;
            //int len = ht.Length;
            int i = ht.LastIndexOf(" ");
            int j = ht.IndexOf(" ");
            string TenLot = ht.Substring(j + 1, i - j - 1);
            string Ten = ht.Substring(i + 1);
            string Ho = ht.Substring(0, j);
            string HoVaTen = Ho + " " + TenLot;
            if(type == 1)
            {
                return TenLot;
            }else if(type == 2)
            {
                return Ten;
            }else if(type == 3)
            {
                return Ho + " " + TenLot;
            }
            else
            {
                return Ho;
            }
        }
        /// <summary>
        /// create page datagridview
        /// </summary>
        /// <param name="recordCount"></param>
        /// <param name="currentPage"></param>
        /// <param name="PageSize"></param>
        /// <param name="pnlDieuHuong"></param>
        /// <param name="Page_Click"></param>
        /// <returns></returns>
        public int HienThiThanhDieuHuong(int recordCount, int currentPage, int PageSize, System.Windows.Forms.Panel pnlDieuHuong, EventHandler Page_Click)
        {
            //Sử dụng đối tượng List để chứa danh sách các trang
            List<Page> pages = new List<Page>();
            int startIndex, endIndex;
            int pagerSpan = 5;

            //Tính toán để hiển thị các trang.
            double dblPageCount = (double)((decimal)recordCount / Convert.ToDecimal(PageSize));
            int pageCount = (int)Math.Ceiling(dblPageCount);
            startIndex = currentPage > 1 && currentPage + pagerSpan - 1 < pagerSpan ? currentPage : 1; endIndex = pageCount > pagerSpan ? pagerSpan : pageCount;
            if (currentPage > pagerSpan % 2)
            {
                if (currentPage == 2)
                {
                    endIndex = 5;
                }
                else
                {
                    endIndex = currentPage + 2;
                }
            }
            else
            {
                endIndex = (pagerSpan - currentPage) + 1;
            }

            if (endIndex - (pagerSpan - 1) > startIndex)
            {
                startIndex = endIndex - (pagerSpan - 1);
            }

            if (endIndex > pageCount)
            {
                endIndex = pageCount;
                startIndex = ((endIndex - pagerSpan) + 1) > 0 ? (endIndex - pagerSpan) + 1 : 1;
            }

            //Add nút trang đầu.
            if (currentPage >= 1)
            {
                pages.Add(new Page { Text = "Trang đầu", Value = "1" });
            }

            //Add nút < 1)
            if (currentPage - 1 < 1)
            {
                pages.Add(new Page { Text = "<<", Value = "1" });
            }
            else
            {
                pages.Add(new Page { Text = "<<", Value = (currentPage - 1).ToString() });
            }

            for (int i = startIndex; i <= endIndex; i++) { pages.Add(new Page { Text = i.ToString(), Value = i.ToString(), Selected = i == currentPage }); } //Add nút >>.
            if (currentPage < pageCount)
            {
                pages.Add(new Page { Text = ">>", Value = (currentPage + 1).ToString() });
            }

            //Add nút Trang cuối.
            if (currentPage != pageCount)
            {
                pages.Add(new Page { Text = "Trang cuối", Value = pageCount.ToString() });
            }

            //Xóa các nút trên trang.
            pnlDieuHuong.Controls.Clear();

            //Lặp và add các Buttons cho trang.
            int count = 0;
            int x = 0;
            foreach (Page page in pages)
            {
                DevComponents.DotNetBar.ButtonX btnPage = new DevComponents.DotNetBar.ButtonX();
                if (count == 0 || count == pages.Count - 1)
                {
                    btnPage.Location = new System.Drawing.Point(x, 0);
                    btnPage.Size = new System.Drawing.Size(100, 25);
                    x = x + 100;
                }
                else
                {
                    btnPage.Location = new System.Drawing.Point(x, 0);
                    btnPage.Size = new System.Drawing.Size(50, 25);
                    x = x + 50;
                }
                btnPage.Name = page.Value;
                btnPage.Text = page.Text;
                btnPage.Enabled = !page.Selected;
                btnPage.Click += new System.EventHandler(Page_Click);
                pnlDieuHuong.Controls.Add(btnPage);
                count++;
            }
            return pageCount;
        }
        public class Page
        {
            public string Text { get; set; }
            public string Value { get; set; }
            public bool Selected { get; set; }
        }
        /// <summary>
        /// close tabpage
        /// </summary>
        /// <param name="control"></param>
        public void btn_close(Control control)
        {
            Control x = control;
            if (x is Panel)
            {
                Control y = x.Parent;
                if (y is TabPage)
                {
                    Control z = y.Parent;
                    if (z is TabControl)
                    {
                        TabControl tab = (TabControl)z;
                        tab.TabPages.Remove(tab.SelectedTab);
                    }
                }
                else if (y is TabControl)
                {
                    TabControl tab = (TabControl)y;
                    tab.TabPages.Remove(tab.SelectedTab);
                }
            }
        }
        public string getdayname(DayOfWeek value)
        {
            string resual = "";
            switch (value)
            {
                case DayOfWeek.Monday:
                    resual = "Mon";
                    break;
                case DayOfWeek.Tuesday:
                    resual = "Tue";
                    break;
                case DayOfWeek.Wednesday:
                    resual = "Wed";
                    break;
                case DayOfWeek.Thursday:
                    resual = "Thu";
                    break;
                case DayOfWeek.Friday:
                    resual = "Fri";
                    break;
                case DayOfWeek.Saturday:
                    resual = "Sat";
                    break;
                case DayOfWeek.Sunday:
                    resual = "Sun";
                    break;
            }
            return resual;
        }
        public DataTable load_year()
        {
            DataTable dt = new DataTable();
            dt.Columns.Add("id");
            dt.Columns.Add("name");
            for (int i = 2020; i <= DateTime.Now.Year + 2; i++)
            {
                dt.Rows.Add(i, i);
            }
            return dt;
        }

        public bool check_login(string user_name,string pass_word)
        {
            bool resual = false;
            string sql = "select * from sys_user where username = '"+ user_name + "' and active = 1";
            DataTable dt = SQLHelper.ExecuteDt(sql);
            if(dt.Rows.Count > 0)
            {
                bool isPasswordMatch = BCrypt.Net.BCrypt.Verify(pass_word, dt.Rows[0]["password"].ToString());
                if(isPasswordMatch)
                {
                    resual = true;
                    SQLHelper.sUser = user_name;
                    SQLHelper.sIdUser = dt.Rows[0]["userid"].ToString();
                }
            }
            else
            {
                resual = false;
            }
            return resual;
        }
        public string Hash_md5(string text)
        {
            MD5 md5 = MD5.Create();
            byte[] hash = md5.ComputeHash(Encoding.UTF8.GetBytes(text));
            StringBuilder hashSb = new StringBuilder();
            foreach (byte b in hash)
            {
                hashSb.Append(b.ToString("X2"));
            }
            return hashSb.ToString();
        }
        public string Hash_sha(string text)
        {
            SHA1Managed sha1 = new SHA1Managed();
            byte[] hash = sha1.ComputeHash(Encoding.UTF8.GetBytes(text));
            StringBuilder hashSb = new StringBuilder();
            foreach (byte b in hash)
            {
                hashSb.Append(b.ToString("X2"));
            }
            return hashSb.ToString();
        }
    }
}
