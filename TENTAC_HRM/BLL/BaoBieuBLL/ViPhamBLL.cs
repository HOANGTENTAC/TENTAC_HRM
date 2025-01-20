using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using TENTAC_HRM.Common;
using TENTAC_HRM.Models.BaoBieuModel;

namespace TENTAC_HRM.BLL.BaoBieuBLL
{
    internal class ViPhamBLL : Provider
    {
        public void InsertViPham(ViPhamModel _viPhamDTO)
        {
            List<SqlParameter> _sqlParameter;
            _sqlParameter = new List<SqlParameter>();
            _sqlParameter.Add(new SqlParameter("@MaChamCong", _viPhamDTO.MaChamCong));
            _sqlParameter.Add(new SqlParameter("@ViPham", _viPhamDTO.ViPham));
            _sqlParameter.Add(new SqlParameter("@TienPhat", _viPhamDTO.TienPhat));
            _sqlParameter.Add(new SqlParameter("@NgayThang", _viPhamDTO.NgayThang));
            base.Procedure("ViPham_add", _sqlParameter);
        }

        public DataTable SelectViPhamByMaChamCongThangNam(ViPhamModel _viPhamDTO)
        {
            List<SqlParameter> _sqlParameter;
            _sqlParameter = new List<SqlParameter>();
            _sqlParameter.Add(new SqlParameter("@MaChamCong", _viPhamDTO.MaChamCong));
            _sqlParameter.Add(new SqlParameter("@Thang", _viPhamDTO.Thang));
            _sqlParameter.Add(new SqlParameter("@Nam", _viPhamDTO.Nam));
            return base.executeNonQuerya("ViPham_SelectbyMaChamCongThangNam", _sqlParameter);
        }

        public DataTable loadViPhamByMaChamCong(ViPhamModel _viPhamDTO)
        {
            List<SqlParameter> _sqlParameter;
            _sqlParameter = new List<SqlParameter>();
            _sqlParameter.Add(new SqlParameter("@MaChamCong", _viPhamDTO.MaChamCong));
            return base.executeNonQuerya("ViPham_SelectbyMaChamCong", _sqlParameter);
        }

        public void ViPhamDelete(ViPhamModel _viPhamDTO)
        {
            List<SqlParameter> _sqlParameter;
            _sqlParameter = new List<SqlParameter>();
            _sqlParameter.Add(new SqlParameter("@IDViPham", _viPhamDTO.IDViPham));
            base.Procedure("ViPham_Delete", _sqlParameter);
        }

        public DataTable ViPhamGetMaChamCongAndNgayThang(ViPhamModel _viPhamDTO)
        {
            List<SqlParameter> _sqlParameter;
            _sqlParameter = new List<SqlParameter>();
            _sqlParameter.Add(new SqlParameter("@MaChamCong", _viPhamDTO.MaChamCong));
            _sqlParameter.Add(new SqlParameter("@NgayThang", _viPhamDTO.NgayThang));
            return base.executeNonQuerya("ViPham_getMaChamCongAndNgayThang", _sqlParameter);
        }

        public void ViPhamDeleteByMaChamCong(ViPhamModel _viPhamDTO)
        {
            List<SqlParameter> _sqlParameter;
            _sqlParameter = new List<SqlParameter>();
            _sqlParameter.Add(new SqlParameter("@MaChamCong", _viPhamDTO.MaChamCong));
            base.Procedure("ViPham_DeleteByMaChamCong", _sqlParameter);
        }
    }
}
