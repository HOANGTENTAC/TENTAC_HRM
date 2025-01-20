using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using TENTAC_HRM.Models.ChamCongModel;
using TENTAC_HRM.Common;

namespace TENTAC_HRM.BLL.ChamCongBLL
{
    internal class ChiTietDangKyTangCaBLL : Provider
    {
        public void InsertChiTietDangKyTangCa(ChiTietDangKyTangCaModel _chiTietDangKyTangCaDTO)
        {
            List<SqlParameter> _sqlParameter;
            _sqlParameter = new List<SqlParameter>();
            _sqlParameter.Add(new SqlParameter("@MaChamCong", _chiTietDangKyTangCaDTO.MaChamCong));
            _sqlParameter.Add(new SqlParameter("@Ngay", _chiTietDangKyTangCaDTO.Ngay));
            _sqlParameter.Add(new SqlParameter("@TrangThai", _chiTietDangKyTangCaDTO.TrangThai));
            base.Procedure("ChiTietDangKyTangCa_add", _sqlParameter);
        }

        public void ChiTietDangKyTangCaDelete(int id)
        {
            SQLHelper.ExecuteSql($"delete MITACOSQL.dbo.[ChiTietDangKyTangCa] where ID = '{id}'");
        }

        public void ChiTietDangKyTangCaDeleteAll(int MaChamCong)
        {
            SQLHelper.ExecuteSql($"delete MITACOSQL.dbo.[ChiTietDangKyTangCa] where MaChamCong = '{MaChamCong}'");
        }

        public DataTable ChiTietDangKyTangCaGetByMaChamCong(int MaChamCong)
        {
            return SQLHelper.ExecuteDt($"select * from MITACOSQL.dbo.[ChiTietDangKyTangCa] where MaChamCong = '{MaChamCong}' order by Ngay");
        }

        public void DeleteChiTietDangKyTangCaByMaChamCong(int MaChamCong)
        {
            SQLHelper.ExecuteSql($"delete MITACOSQL.dbo.[ChiTietDangKyTangCa] where MaChamCong = '{MaChamCong}'");
        }

        public DataTable ChiTietDangKyTangCaGetByMaChamCongAndNgay(int MaChamCong, DateTime Ngay)
        {
            return SQLHelper.ExecuteDt($"select * from MITACOSQL.dbo.[ChiTietDangKyTangCa] where MaChamCong = '{MaChamCong}' and Ngay= '{Ngay}'");
        }
    }
}
