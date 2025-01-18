using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using TENTAC_HRM.Common;
using TENTAC_HRM.Model;

namespace TENTAC_HRM.DataAccessLayer.MayChamCong.DuLieuMayChamCongDAL
{
    internal class CheckInOut_BLL : Provider
    {
        public void Insert_CheckinOut(CheckInOut_model _checkInOutDTO)
        {
            List<SqlParameter> _sqlParameter = new List<SqlParameter>();
            _sqlParameter.Add(new SqlParameter("@MaChamCong", _checkInOutDTO.MaChamCong));
            _sqlParameter.Add(new SqlParameter("@NgayCham", _checkInOutDTO.NgayCham));
            _sqlParameter.Add(new SqlParameter("@GioCham", _checkInOutDTO.GioCham));
            _sqlParameter.Add(new SqlParameter("@KieuCham", _checkInOutDTO.KieuCham));
            _sqlParameter.Add(new SqlParameter("@NguonCham", _checkInOutDTO.NguonCham));
            _sqlParameter.Add(new SqlParameter("@MaSoMay", _checkInOutDTO.MaSoMay));
            _sqlParameter.Add(new SqlParameter("@TenMay", _checkInOutDTO.TenMay));
            Procedure("CheckInOut_add", _sqlParameter);
        }
        public DataTable CountAll_CheckInOut()
        {
            List<SqlParameter> _sqlParameter = new List<SqlParameter>();
            return executeNonQuerya("CheckInOut_count", _sqlParameter);
        }
        public DataTable CountAllCheckInOut(CheckInOut_model _checkInOutDTO)
        {
            List<SqlParameter> _sqlParameter = new List<SqlParameter>();
            return executeNonQuerya("CheckInOut_count", _sqlParameter);
        }
    }
}
