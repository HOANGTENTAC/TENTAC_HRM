using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using TENTAC_HRM.Models.BaoBieuModel;
using TENTAC_HRM.Common;

namespace TENTAC_HRM.BLL.BaoBieuBLL
{
    internal class ChiTietCongTruLuongBLL : Provider
    {
        public void ChiTietCongTruLuongInsert(ChiTietCongTruLuongModel _chiTietCongTruLuongDTO)
        {
            List<SqlParameter> _sqlParameter;
            _sqlParameter = new List<SqlParameter>();
            _sqlParameter.Add(new SqlParameter("@MaChamCong", _chiTietCongTruLuongDTO.MaChamCong));
            _sqlParameter.Add(new SqlParameter("@ChiTietPhuCapCom", _chiTietCongTruLuongDTO.ChiTietPhuCapCom));
            _sqlParameter.Add(new SqlParameter("@ChiTietPhuCapKhac", _chiTietCongTruLuongDTO.ChiTietPhuCapKhac));
            _sqlParameter.Add(new SqlParameter("@ChiTietTamUngLuong", _chiTietCongTruLuongDTO.ChiTietTamUngLuong));
            _sqlParameter.Add(new SqlParameter("@ChiTietViPham", _chiTietCongTruLuongDTO.ChiTietViPham));
            _sqlParameter.Add(new SqlParameter("@ChiTietThuong", _chiTietCongTruLuongDTO.ChiTietThuong));
            base.Procedure("ChiTietCongTruLuong_add", _sqlParameter);
        }

        public void ChiTietCongTruLuongDelete()
        {
            SQLHelper.ExecuteSql("TRUNCATE TABLE  MITACOSQL.dbo.[ChiTietCongTruLuong]");
        }

        public DataTable ChiTietCongTruLuongGetByMaChamCong(int machamcong)
        {
            return SQLHelper.ExecuteDt($"select * from  MITACOSQL.dbo.[ChiTietCongTruLuong] where MaChamCong = '{machamcong}'");
        }
    }
}
