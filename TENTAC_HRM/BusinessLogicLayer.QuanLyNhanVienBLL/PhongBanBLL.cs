using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TENTAC_HRM.Common;
using TENTAC_HRM.DataTransferObject.QuanLyNhanVienDTO;

namespace TENTAC_HRM.BusinessLogicLayer.QuanLyNhanVienBLL
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
