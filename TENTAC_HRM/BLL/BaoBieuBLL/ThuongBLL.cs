using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using TENTAC_HRM.Common;
using TENTAC_HRM.Models.BaoBieuModel;

namespace TENTAC_HRM.BLL.BaoBieuBLL
{
    internal class ThuongBLL : Provider
    {
        public void ThuongInsert(ThuongModel _thuongDTO)
        {
            List<SqlParameter> _sqlParameter;
            _sqlParameter = new List<SqlParameter>();
            _sqlParameter.Add(new SqlParameter("@MaChamCong", _thuongDTO.MaChamCong));
            _sqlParameter.Add(new SqlParameter("@Thuong", _thuongDTO.Thuong));
            _sqlParameter.Add(new SqlParameter("@TienThuong", _thuongDTO.TienThuong));
            _sqlParameter.Add(new SqlParameter("@NgayThuong", _thuongDTO.NgayThuong));
            base.Procedure("ChiTietThuongNhanVien_add", _sqlParameter);
        }

        public void ThuongDeleteByMaChamCong(ThuongModel _thuongDTO)
        {
            List<SqlParameter> _sqlParameter;
            _sqlParameter = new List<SqlParameter>();
            _sqlParameter.Add(new SqlParameter("@MaChamCong", _thuongDTO.MaChamCong));
            base.Procedure("ChiTietThuongNhanVien_deleteByMaChamCong", _sqlParameter);
        }

        public void ThuongDeleteByIDThuong(ThuongModel _thuongDTO)
        {
            List<SqlParameter> _sqlParameter;
            _sqlParameter = new List<SqlParameter>();
            _sqlParameter.Add(new SqlParameter("@IDThuong", _thuongDTO.IDThuong));
            base.Procedure("ChiTietThuongNhanVien_deleteByIDThuong", _sqlParameter);
        }

        public DataTable ThuongGetByMaChamCongAndNgayThuong(ThuongModel _thuongDTO)
        {
            List<SqlParameter> _sqlParameter;
            _sqlParameter = new List<SqlParameter>();
            _sqlParameter.Add(new SqlParameter("@MaChamCong", _thuongDTO.MaChamCong));
            _sqlParameter.Add(new SqlParameter("@NgayThuong", _thuongDTO.NgayThuong));
            return base.executeNonQuerya("ChiTietThuongNhanVien_getMaChamCongAndNgayThuong", _sqlParameter);
        }

        public DataTable ThuongGetByMaChamCong(ThuongModel _thuongDTO)
        {
            List<SqlParameter> _sqlParameter;
            _sqlParameter = new List<SqlParameter>();
            _sqlParameter.Add(new SqlParameter("@MaChamCong", _thuongDTO.MaChamCong));
            return base.executeNonQuerya("ChiTietThuongNhanVien_getByMaChamCong", _sqlParameter);
        }
    }
}
