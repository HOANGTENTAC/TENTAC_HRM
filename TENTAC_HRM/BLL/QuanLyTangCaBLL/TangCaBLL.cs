using System;
using System.Data;

namespace TENTAC_HRM.BLL.QuanLyTangCaBLL
{
    internal class TangCaBLL
    {
        public DataTable GetTangCaByMaChamCong(string MaChamCong, string NgayTangCa)
        {
            string sql = $"select * from MITACOSQL.dbo.DangKyTangCa where MaChamCong = '{MaChamCong}' and NgayTangCa = '{NgayTangCa}'";
            return SQLHelper.ExecuteDt(sql);
        }
    }
}
