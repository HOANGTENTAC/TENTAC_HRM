using System;
using System.Data;

namespace TENTAC_HRM.BLL.ChamCongBLL
{
    internal class PhepNamBLL
    {
        public DataTable PhepNamGetTinhCong(int MaChamCong, DateTime Ngay)
        {
            return SQLHelper.ExecuteDt($"select * from MITACOSQL.dbo.[PHEPNAM] where MaChamCong = '{MaChamCong}' and Ngay = '{Ngay}'");
        }
    }
}
