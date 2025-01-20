using System.Data;

namespace TENTAC_HRM.BLL.BLL.ChamCongBLL
{
    internal class CaLamViecBLL
    {
        public DataTable getMaByTenCaLamViec(string CaLamViec)
        {
            return SQLHelper.ExecuteDt($"select * from MITACOSQL.dbo.[CaLamViecNew] where CaLamViec = '{CaLamViec}'");
        }

        public DataTable CaLamViecGetByMaCaLamViec(string MaCaLamViec)
        {
            return SQLHelper.ExecuteDt($"select * from MITACOSQL.dbo.[CaLamViecNew] where MaCaLamViec = '{MaCaLamViec}'");
        }
    }
}
