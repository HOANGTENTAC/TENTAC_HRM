using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using TENTAC_HRM.Common;
using TENTAC_HRM.Models.ChamCongModel;

namespace TENTAC_HRM.BLL.DuLieuMayChamCongBLL
{
    internal class CheckInOut_BLL : Provider
    {
        public void Insert_CheckinOut(CheckInOutModel _checkInOutDTO)
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
        public void CheckInOut_ThemGio(CheckInOutModel _checkInOutDTO)
        {
            List<SqlParameter> _sqlParameter;
            _sqlParameter = new List<SqlParameter>();
            _sqlParameter.Add(new SqlParameter("@MaChamCong", _checkInOutDTO.MaChamCong));
            _sqlParameter.Add(new SqlParameter("@NgayCham", _checkInOutDTO.NgayCham));
            _sqlParameter.Add(new SqlParameter("@GioCham", _checkInOutDTO.GioCham));
            _sqlParameter.Add(new SqlParameter("@KieuCham", _checkInOutDTO.KieuCham));
            _sqlParameter.Add(new SqlParameter("@NguonCham", _checkInOutDTO.NguonCham));
            _sqlParameter.Add(new SqlParameter("@MaSoMay", _checkInOutDTO.MaSoMay));
            _sqlParameter.Add(new SqlParameter("@TenMay", _checkInOutDTO.TenMay));
            base.Procedure("CheckInOut_ThemGio", _sqlParameter);
        }
        public DataTable getCheckInOutByMaChamCongAndNgayCham(int MaChamCong, DateTime NgayCham)
        {
            return SQLHelper.ExecuteDt($"select * from MITACOSQL.dbo.[CheckInOut] where MaChamCong = '{MaChamCong}' and NgayCham = '{NgayCham}' order by GioCham");
        }

        public DataTable CountAllCheckInOut()
        {
            return SQLHelper.ExecuteDt("select count (*) from MITACOSQL.dbo.CheckInOut");
        }
    }
}
