using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using TENTAC_HRM.Models.ChamCongModel;
using TENTAC_HRM.Common;

namespace TENTAC_HRM.BLL.ChamCongBLL
{
    internal class SapXepLichTrinhChoNhanVienBLL : Provider
    {
        public void Insert_SapXepLichTrinhChoNhanVien(SapXepLichTrinhChoNhanVienModel _sapXepLichTrinhChoNhanVienDTO)
        {
            List<SqlParameter> _sqlParameter = new List<SqlParameter>();
            _sqlParameter.Add(new SqlParameter("@MaChamCong", _sapXepLichTrinhChoNhanVienDTO.MaChamCong));
            _sqlParameter.Add(new SqlParameter("@MaLichTrinhVaoRa", _sapXepLichTrinhChoNhanVienDTO.MaLichTrinhVaoRa));
            _sqlParameter.Add(new SqlParameter("@MaLichTrinhCaLamViec", _sapXepLichTrinhChoNhanVienDTO.MaLichTrinhCaLamViec));
            Procedure("ChiTietLichTrinhChoCaLamViec_NhanVien_add", _sqlParameter);
        }

        public DataTable get_SapXepLichTrinhChoNhanVienByMaChamCong(int machamcong)
        {
            return SQLHelper.ExecuteDt($"select * from MITACOSQL.dbo.[ChiTietLichTrinhChoCaLamViec] where MaChamCong = '{machamcong}'");
        }

        public void DeleteSapXepLichTrinhChoNhanVien(int machamcong)
        {
            SQLHelper.ExecuteSql($"delete MITACOSQL.dbo.[ChiTietLichTrinhChoCaLamViec] where MaChamCong = '{machamcong}'");
        }

        public void DeleteSapXepLichTrinhChoNhanVienByMaChamCong(int machamcong)
        {
            SQLHelper.ExecuteSql($"delete MITACOSQL.dbo.[ChiTietLichTrinhChoCaLamViec] where MaChamCong = '{machamcong}'");
        }

        public void DeleteAllSapXepLichTrinhChoNhanVien()
        {
            SQLHelper.ExecuteSql("delete MITACOSQL.dbo.[ChiTietLichTrinhChoCaLamViec]");
        }

        public DataTable SapXepLichTrinhChoNhanVienGetLichTrinhCaLamViec(string MaLichTrinhCaLamViec)
        {
            return SQLHelper.ExecuteDt($"select * from MITACOSQL.dbo.ChiTietLichTrinhChoCaLamViec where MaLichTrinhCaLamViec='{MaLichTrinhCaLamViec}'");
        }

        public DataTable SapXepLichTrinhChoNhanVienGetLichTrinhVaoRa(string MaLichTrinhVaoRa)
        {
            return SQLHelper.ExecuteDt($"select * from MITACOSQL.dbo.ChiTietLichTrinhChoCaLamViec where MaLichTrinhVaoRa='{MaLichTrinhVaoRa}'");
        }
    }
}
