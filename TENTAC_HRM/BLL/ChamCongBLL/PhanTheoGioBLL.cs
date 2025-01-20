using System.Data;

namespace TENTAC_HRM.BLL.ChamCongBLL
{
    internal class PhanTheoGioBLL
    {
        public DataTable PhanTheoGioGetMaLichTrinhVaoRa(string MaLichTrinhVaoRa)
        {
            return SQLHelper.ExecuteDt($"select * from MITACOSQL.dbo.[PhanTheoGio] where MaLichTrinhVaoRa = '{MaLichTrinhVaoRa}'");
        }
    }
}
