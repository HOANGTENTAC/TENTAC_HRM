using System.Collections.Generic;

namespace TENTAC_HRM.Consts
{
    public class AppConsts
    {
    }
    public class LoginInfo
    {
        public static string UserCd { get; set; }
        public static string ChucVu { get; set; }
        public static string UserName { get; set; }
        public static string LoaiUser { get; set; }
        public static string MaChamCong { get; set; }
        public static List<QuyenSuDung> QuyenSuDungs { get; set; }
    }
    public class QuyenSuDung
    {
        public bool Show { get; set; }
        public bool Create { get; set; }
        public bool Update { get; set; }
        public bool Delete { get; set; }
        public bool Import { get; set; }
        public string Export { get; set; }
    }
}
