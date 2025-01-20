using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using TENTAC_HRM.Models.BaoBieuModel;
using TENTAC_HRM.Common;

namespace TENTAC_HRM.BLL.BaoBieuBLL
{
    internal class ChiTietPhuCapNhanVienBLL : Provider
    {
        public void Insert_ChiTietPhuCapNhanVien(ChiTietPhuCapNhanVienModel _chiTietPhuCapNhanVienDTO)
        {
            List<SqlParameter> _sqlParameter;
            _sqlParameter = new List<SqlParameter>();
            _sqlParameter.Add(new SqlParameter("@MaChamCong", _chiTietPhuCapNhanVienDTO.MaChamCong));
            _sqlParameter.Add(new SqlParameter("@MaPhuCap", _chiTietPhuCapNhanVienDTO.MaPhuCap));
            _sqlParameter.Add(new SqlParameter("@TenPhuCap", _chiTietPhuCapNhanVienDTO.TenPhuCap));
            _sqlParameter.Add(new SqlParameter("@SoTien", _chiTietPhuCapNhanVienDTO.SoTien));
            _sqlParameter.Add(new SqlParameter("@Ngay", _chiTietPhuCapNhanVienDTO.Ngay));
            _sqlParameter.Add(new SqlParameter("@KyHieuPhuCap", _chiTietPhuCapNhanVienDTO.KyHieuPhuCap));
            base.Procedure("CHITIETPHUCAPNHANVIEN_add", _sqlParameter);
        }

        public DataTable loadChiTietPhuCapByMaChamCong(ChiTietPhuCapNhanVienModel _chiTietPhuCapNhanVienDTO)
        {
            List<SqlParameter> _sqlParameter;
            _sqlParameter = new List<SqlParameter>();
            _sqlParameter.Add(new SqlParameter("@MaChamCong", _chiTietPhuCapNhanVienDTO.MaChamCong));
            return base.executeNonQuerya("CHITIETPHUCAPNHANVIEN_SelectbyMaChamCong", _sqlParameter);
        }

        public DataTable SelectChiTietPhuCapNhanVienByMaChamCongThangNam(ChiTietPhuCapNhanVienModel _chiTietPhuCapNhanVienDTO)
        {
            List<SqlParameter> _sqlParameter;
            _sqlParameter = new List<SqlParameter>();
            _sqlParameter.Add(new SqlParameter("@MaChamCong", _chiTietPhuCapNhanVienDTO.MaChamCong));
            return base.executeNonQuerya("CHITIETPHUCAPNHANVIEN_SelectbyMaChamCongThangNam", _sqlParameter);
        }

        public void DeleteChiTietPhuCapNhanVien(ChiTietPhuCapNhanVienModel _chiTietPhuCapNhanVienDTO)
        {
            List<SqlParameter> _sqlParameter;
            _sqlParameter = new List<SqlParameter>();
            _sqlParameter.Add(new SqlParameter("@IDChiTietPhuCap", _chiTietPhuCapNhanVienDTO.IDChiTietPhuCap));
            base.Procedure("NHANVIEN_deleteChiTietPhuCapByMaChamCong", _sqlParameter);
        }

        public DataTable ChiTietPhuCapNhanVienGetByMaChamCongAndNgayAndKyHieuPhuCap(ChiTietPhuCapNhanVienModel _chiTietPhuCapNhanVienDTO)
        {
            List<SqlParameter> _sqlParameter;
            _sqlParameter = new List<SqlParameter>();
            _sqlParameter.Add(new SqlParameter("@MaChamCong", _chiTietPhuCapNhanVienDTO.MaChamCong));
            _sqlParameter.Add(new SqlParameter("@Ngay", _chiTietPhuCapNhanVienDTO.Ngay));
            _sqlParameter.Add(new SqlParameter("@KyHieuPhuCap", _chiTietPhuCapNhanVienDTO.KyHieuPhuCap));
            return base.executeNonQuerya("ChiTietPhuCapNhanVien_getByMaChamCongAndNgayAndKyHieuPhuCap", _sqlParameter);
        }
    }
}
