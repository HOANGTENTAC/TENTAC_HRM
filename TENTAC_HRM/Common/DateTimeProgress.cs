namespace TENTAC_HRM.Common
{
    internal class DateTimeProgress
    {
        public static string XuatThu(int thu)
        {
            string resual = "";
            switch (thu)
            {
                case 0:
                    resual = "Chủ nhật";
                    break;
                case 1:
                    resual = "Thứ hai";
                    break;
                case 2:
                    resual = "Thứ ba";
                    break;
                case 3:
                    resual = "Thứ tư";
                    break;
                case 4:
                    resual = "Thứ năm";
                    break;
                case 5:
                    resual = "Thứ sáu";
                    break;
                case 6:
                    resual = "Thứ bảy";
                    break;
                default:
                    resual = "Không xác định được";
                    break;

            }
            return resual;
        }

        public static string XuatThuQuaDem(int thuQuaDem)
        {
            string resual = "";
            switch (thuQuaDem)
            {
                case 0:
                    resual = "Thứ bảy";
                    break;
                case 1:
                    resual = "Chủ nhật";
                    break;
                case 2:
                    resual = "Thứ hai";
                    break;
                case 3:
                    resual = "Thứ ba";
                    break;
                case 4:
                    resual = "Thứ tư";
                    break;
                case 5:
                    resual = "Thứ năm";
                    break;
                case 6:
                    resual = "Thứ sáu";
                    break;
                default:
                    resual = "Không xác định được";
                    break;
            }
            return resual;
        }

        public static string XuatIDThu(int IDthu)
        {
            string resual = "";
            switch (IDthu)
            {
                case 0:
                    resual = "0";
                    break;
                case 1:
                    resual = "1";
                    break;
                case 2:
                    resual = "2";
                    break;
                case 3:
                    resual = "3";
                    break;
                case 4:
                    resual = "4";
                    break;
                case 5:
                    resual = "5";
                    break;
                case 6:
                    resual = "6";
                    break;
                default:
                    resual = "Không xác định được";
                    break;
            }
            return resual;
        }

        public static string XuatThuTinhCong(int thuTinhCong)
        {
            string resual = "";
            switch (thuTinhCong)
            {
                case 0:
                    resual = "CN";
                    break;
                case 1:
                    resual = "Hai";
                    break;
                case 2:
                    resual = "Ba";
                    break;
                case 3:
                    resual = "Tư";
                    break;
                case 4:
                    resual = "Năm";
                    break;
                case 5:
                    resual = "Sáu";
                    break;
                case 6:
                    resual = "Bảy";
                    break;
                default:
                    resual = "Không xác định được";
                    break;
            }
            return resual;
        }

        public static string XuatThuEnglish(int thuEnglish)
        {
            string resual = "";
            switch (thuEnglish)
            {
                case 0:
                    resual = "Sunday";
                    break;
                case 1:
                    resual = "Monday";
                    break;
                case 2:
                    resual = "Tuesday";
                    break;
                case 3:
                    resual = "Wednesday";
                    break;
                case 4:
                    resual = "Thursday";
                    break;
                case 5:
                    resual = "Friday";
                    break;
                case 6:
                    resual = "Saturday";
                    break;
                default:
                    resual = "Unknow";
                    break;
            }
            return resual;
        }

        public static string XuatThuChinese(int thuChinese)
        {
            string resual = "";
            switch (thuChinese)
            {
                case 0:
                    resual = "星期日";
                    break;
                case 1:
                    resual = "第二";
                    break;
                case 2:
                    resual = "星期二";
                    break;
                case 3:
                    resual = "星期三";
                    break;
                case 4:
                    resual = "星期四";
                    break;
                case 5:
                    resual = "星期五";
                    break;
                case 6:
                    resual = "星期六";
                    break;
                default:
                    resual = "未知";
                    break;
            }
            return resual;
        }

        public static string XuatThuJapan(int thuJapan)
        {
            string resual = "";
            switch (thuJapan)
            {
                case 0:
                    resual = "日曜日";
                    break;
                case 1:
                    resual = "月曜日";
                    break;
                case 2:
                    resual = "火曜日";
                    break;
                case 3:
                    resual = "水曜日";
                    break;
                case 4:
                    resual = "木曜日";
                    break;
                case 5:
                    resual = "金曜日";
                    break;
                case 6:
                    resual = "土曜日";
                    break;
                default:
                    resual = "不明";
                    break;
            }
            return resual;
        }

        public static string XuatThuKorea(int thuKorea)
        {
            string resual = "";
            switch (thuKorea)
            {
                case 0:
                    resual = "일요일";
                    break;
                case 1:
                    resual = "월요일";
                    break;
                case 2:
                    resual = "화요일";
                    break;
                case 3:
                    resual = "수요일";
                    break;
                case 4:
                    resual = "목요일";
                    break;
                case 5:
                    resual = "금요일";
                    break;
                case 6:
                    resual = "토요일";
                    break;
                default:
                    resual = "Không xác định được";
                    break;
            }
            return resual;
        }

        public static string NhanCaTheoTuan(int _nhanCaTheoTuan)
        {
            string resual = "";
            switch (_nhanCaTheoTuan)
            {
                case 0:
                    resual = "0";
                    break;
                case 1:
                    resual = "1";
                    break;
                case 2:
                    resual = "2";
                    break;
                case 3:
                    resual = "3";
                    break;
                case 4:
                    resual = "4";
                    break;
                case 5:
                    resual = "5";
                    break;
                case 6:
                    resual = "6";
                    break;
                default:
                    resual = "Không xác định được";
                    break;
            }
            return resual;
        }

        public static string Test(int test)
        {
            string resual = "";
            switch (test)
            {
                case 0:
                    resual = "0";
                    break;
                case 1:
                    resual = "1";
                    break;
                case 2:
                    resual = "2";
                    break;
                case 3:
                    resual = "3";
                    break;
                case 4:
                    resual = "4";
                    break;
                case 5:
                    resual = "5";
                    break;
                case 6:
                    resual = "6";
                    break;
                default:
                    resual = "Không xác định được";
                    break;
            }
            return resual;
        }

        public static string XuatThuReport(int iXuatThuReport)
        {
            string resual = "";
            switch (iXuatThuReport)
            {
                case 0:
                    resual = "CN";
                    break;
                case 1:
                    resual = "T.2";
                    break;
                case 2:
                    resual = "T.3";
                    break;
                case 3:
                    resual = "T.4";
                    break;
                case 4:
                    resual = "T.5";
                    break;
                case 5:
                    resual = "T.6";
                    break;
                case 6:
                    resual = "T.7";
                    break;
                default:
                    resual = "Không xác định được";
                    break;
            }
            return resual;
        }

        public static string XuatThangEnglish(int iXuatThangEnglish)
        {
            string resual = "";
            switch (iXuatThangEnglish)
            {
                case 1:
                    resual = "January";
                    break;
                case 2:
                    resual = "February";
                    break;
                case 3:
                    resual = "March";
                    break;
                case 4:
                    resual = "April";
                    break;
                case 5:
                    resual = "May";
                    break;
                case 6:
                    resual = "June";
                    break;
                case 7:
                    resual = "July";
                    break;
                case 8:
                    resual = "August";
                    break;
                case 9:
                    resual = "September";
                    break;
                case 10:
                    resual = "October";
                    break;
                case 11:
                    resual = "November";
                    break;
                case 12:
                    resual = "December";
                    break;
                default:
                    resual = "Không xác định";
                    break;
            }
            return resual;
        }
    }
}
