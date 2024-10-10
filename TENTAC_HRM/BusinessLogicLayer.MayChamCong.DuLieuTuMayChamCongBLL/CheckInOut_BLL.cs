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
            _sqlParameter.Add(new SqlParameter("@MaChamCong", _checkInOutDTO.Ma_Cham_Cong));
            _sqlParameter.Add(new SqlParameter("@NgayCham", _checkInOutDTO.Ngay_Cham));
            _sqlParameter.Add(new SqlParameter("@GioCham", _checkInOutDTO.Gio_Cham));
            _sqlParameter.Add(new SqlParameter("@KieuCham", _checkInOutDTO.Kieu_Cham));
            _sqlParameter.Add(new SqlParameter("@NguonCham", _checkInOutDTO.Nguon_Cham));
            _sqlParameter.Add(new SqlParameter("@MaSoMay", _checkInOutDTO.MaSo_May));
            _sqlParameter.Add(new SqlParameter("@TenMay", _checkInOutDTO.Ten_May));
            Procedure("CheckInOut_add", _sqlParameter);
        }
        public DataTable CountAll_CheckInOut()
        {
            List<SqlParameter> _sqlParameter = new List<SqlParameter>();
            return executeNonQuerya("CheckInOut_count", _sqlParameter);
        }
    }
}
