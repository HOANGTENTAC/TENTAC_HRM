using System.Collections.Generic;
using System.Data.SqlClient;
using TENTAC_HRM.Common;
using TENTAC_HRM.Model;

namespace TENTAC_HRM.BusinessLogicLayer.ChamCongBLL
{
    internal class SapXepLichTrinhChoNhanVienBLL : Provider
    {
        public void Insert_SapXepLichTrinhChoNhanVien(SapXepLichTrinhChoNhanVien_model _sapXepLichTrinhChoNhanVienDTO)
        {
            List<SqlParameter> _sqlParameter = new List<SqlParameter>();
            _sqlParameter.Add(new SqlParameter("@MaChamCong", _sapXepLichTrinhChoNhanVienDTO.MaChamCong));
            _sqlParameter.Add(new SqlParameter("@MaLichTrinhVaoRa", _sapXepLichTrinhChoNhanVienDTO.MaLichTrinhVaoRa));
            _sqlParameter.Add(new SqlParameter("@MaLichTrinhCaLamViec", _sapXepLichTrinhChoNhanVienDTO.MaLichTrinhCaLamViec));
            Procedure("ChiTietLichTrinhChoCaLamViec_NhanVien_add", _sqlParameter);
        }
    }
}
