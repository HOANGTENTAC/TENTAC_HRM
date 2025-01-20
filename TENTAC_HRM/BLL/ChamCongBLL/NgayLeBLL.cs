using System;
using System.Data;

namespace TENTAC_HRM.BLL.ChamCongBLL
{
    internal class NgayLeBLL
    {
        public DataTable NgayLeGetTinhCong(DateTime Ngay)
        {
            return SQLHelper.ExecuteDt($"select * from MITACOSQL.dbo.[NgayLe] where Ngay = '{Ngay}'");
        }
    }
}
