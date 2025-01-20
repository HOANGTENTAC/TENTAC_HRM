using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using TENTAC_HRM.Common;
using TENTAC_HRM.Models.BaoBieuModel;

namespace TENTAC_HRM.BLL.BaoBieuBLL
{
    internal class ChiTietTamUngLuongBLL : Provider
    {
        public void Insert_ChiTietTamUngLuong(ChiTietTamUngLuongModel _chiTietTamUngLuongDTO)
        {
            List<SqlParameter> _sqlParameter;
            _sqlParameter = new List<SqlParameter>();
            _sqlParameter.Add(new SqlParameter("@MaChamCong", _chiTietTamUngLuongDTO.MaChamCong));
            _sqlParameter.Add(new SqlParameter("@SoTien", _chiTietTamUngLuongDTO.SoTien));
            _sqlParameter.Add(new SqlParameter("@LyDo", _chiTietTamUngLuongDTO.LyDo));
            _sqlParameter.Add(new SqlParameter("@NgayTamUng", _chiTietTamUngLuongDTO.NgayTamUng));
            base.Procedure("CHITIETTAMUNGLUONG_add", _sqlParameter);
        }

        public DataTable loadChiTietTamUngLuongByMaChamCong(ChiTietTamUngLuongModel _chiTietTamUngLuongDTO)
        {
            List<SqlParameter> _sqlParameter;
            _sqlParameter = new List<SqlParameter>();
            _sqlParameter.Add(new SqlParameter("@MaChamCong", _chiTietTamUngLuongDTO.MaChamCong));
            return base.executeNonQuerya("CHITIETTAMUNGLUONG_SelectbyMaChamCong", _sqlParameter);
        }

        public DataTable SelectChiTietTamUngLuongByMaChamCongThangNam(ChiTietTamUngLuongModel _chiTietTamUngLuongDTO)
        {
            List<SqlParameter> _sqlParameter;
            _sqlParameter = new List<SqlParameter>();
            _sqlParameter.Add(new SqlParameter("@MaChamCong", _chiTietTamUngLuongDTO.MaChamCong));
            return base.executeNonQuerya("CHITIETTAMUNGLUONG_SelectbyMaChamCongThangNam", _sqlParameter);
        }

        public void DeleteChiTietTamUngLuong(ChiTietTamUngLuongModel _chiTietTamUngLuongDTO)
        {
            List<SqlParameter> _sqlParameter;
            _sqlParameter = new List<SqlParameter>();
            _sqlParameter.Add(new SqlParameter("@MaChamCong", _chiTietTamUngLuongDTO.MaChamCong));
            base.Procedure("NHANVIEN_deleteChiTietTamUngLuongByMaChamCong", _sqlParameter);
        }

        public DataTable ChiTietTamUngLuongGetMaChamCongAndNgayTamUng(ChiTietTamUngLuongModel _chiTietTamUngLuongDTO)
        {
            List<SqlParameter> _sqlParameter;
            _sqlParameter = new List<SqlParameter>();
            _sqlParameter.Add(new SqlParameter("@MaChamCong", _chiTietTamUngLuongDTO.MaChamCong));
            _sqlParameter.Add(new SqlParameter("@NgayTamUng", _chiTietTamUngLuongDTO.NgayTamUng));
            return base.executeNonQuerya("ChiTietTamUngLuong_getMaChamCongAndNgayTamUng", _sqlParameter);
        }

        public void ChiTietTamUngLuongUpdate(ChiTietTamUngLuongModel _chiTietTamUngLuongDTO)
        {
            List<SqlParameter> _sqlParameter;
            _sqlParameter = new List<SqlParameter>();
            _sqlParameter.Add(new SqlParameter("@MaChamCong", _chiTietTamUngLuongDTO.MaChamCong));
            _sqlParameter.Add(new SqlParameter("@SoTien", _chiTietTamUngLuongDTO.SoTien));
            _sqlParameter.Add(new SqlParameter("@LyDo", _chiTietTamUngLuongDTO.LyDo));
            _sqlParameter.Add(new SqlParameter("@NgayTamUng", _chiTietTamUngLuongDTO.NgayTamUng));
            base.Procedure("ChiTietTamUngLuong_update", _sqlParameter);
        }

        public void ChiTietTamUngLuongDelete(ChiTietTamUngLuongModel _chiTietTamUngLuongDTO)
        {
            List<SqlParameter> _sqlParameter;
            _sqlParameter = new List<SqlParameter>();
            _sqlParameter.Add(new SqlParameter("@IDTamUngLuong", _chiTietTamUngLuongDTO.IDTamUngLuong));
            base.Procedure("ChiTietTamUngLuong_delete", _sqlParameter);
        }
    }
}
