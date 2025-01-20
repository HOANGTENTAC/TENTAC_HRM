using System;
using System.Data;
using TENTAC_HRM.Common;

namespace TENTAC_HRM.BLL.ChamCongBLL
{
    internal class ChiTietDiCongTacBLL : Provider
    {
        public DataTable ChiTietDiCongTacGetTinhCong(int MaChamCong, DateTime Ngay)
        {
            return SQLHelper.ExecuteDt($"select * from MITACOSQL.dbo.[ChiTietDiCongTac] where MaChamCong = '{MaChamCong}' and Ngay = '{Ngay}'");
        }
    }
}
