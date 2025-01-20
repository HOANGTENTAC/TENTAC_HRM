using System.Data;
using TENTAC_HRM.Common;
using TENTAC_HRM.Models.QuanLyNhanVienModel;

namespace TENTAC_HRM.BLL.QuanLyNhanVienBLL
{
    internal class PhongBanBLL : Provider
    {
        public DataTable GETPHONGBANTREEVIEW(PhongBanDTO _phongBanDTO)
        {
            string sql = $"select * from  MITACOSQL.dbo.[PHONGBAN] where MaKhuVuc='{_phongBanDTO.MaKhuVuc}' ";
            return SQLHelper.ExecuteDt(sql);
        }

        public DataTable PhongBanGetTreeView(PhongBanDTO _phongBanDTO)
        {
            string sql = $"select * from MITACOSQL.dbo.[PhongBan] where TenPhongBan = '{_phongBanDTO.TenPhongBan}'";
            return SQLHelper.ExecuteDt(sql);
        }
        public DataTable getTenPhongBanByMaPhongBan(PhongBanDTO _phongBanDTO)
        {
            string sql = $"select * from MITACOSQL.dbo.[PHONGBAN] where MaPhongBan = '{_phongBanDTO.MaPhongBan}'";
            return SQLHelper.ExecuteDt(sql);
        }
    }
}
