using System.Data;

namespace TENTAC_HRM.BLL.ChamCongBLL
{
    internal class CacLoaiVangBLL
    {
        public DataTable CacLoaiVangGetByMaCacLoaiVang(string MaCacLoaiVang)
        {
            return SQLHelper.ExecuteDt($"select * from MITACOSQL.dbo.[CacLoaiVang] where MaCacLoaiVang = '{MaCacLoaiVang}'");
        }
    }
}
