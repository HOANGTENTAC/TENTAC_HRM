using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using TENTAC_HRM.Common;
using TENTAC_HRM.Model;

namespace TENTAC_HRM.BusinessLogicLayer.ChamCongBLL
{
    internal class LichTrinhVaoRaBLL : Provider
    {
        public void THEM_LICHTRINHVAORA(LichTrinhVaoRa_model _lichTrinhVaoRaDTO)
        {
            List<SqlParameter> _sqlParameter = new List<SqlParameter>();
            _sqlParameter.Add(new SqlParameter("@MaLichTrinhVaoRa", _lichTrinhVaoRaDTO.MaLichTrinhVaoRa));
            _sqlParameter.Add(new SqlParameter("@TenLichTrinhVaoRa", _lichTrinhVaoRaDTO.TenLichTrinhVaoRa));
            _sqlParameter.Add(new SqlParameter("@ChonLichTrinhVaoRa", _lichTrinhVaoRaDTO.ChonLichTrinhVaoRa));
            _sqlParameter.Add(new SqlParameter("@MotLanChamCong", _lichTrinhVaoRaDTO.MotLanChamCong));
            _sqlParameter.Add(new SqlParameter("@LoaiBoGio", _lichTrinhVaoRaDTO.LoaiBoGio));
            _sqlParameter.Add(new SqlParameter("@TuGio", _lichTrinhVaoRaDTO.TuGio));
            _sqlParameter.Add(new SqlParameter("@DenGio", _lichTrinhVaoRaDTO.DenGio));
            _sqlParameter.Add(new SqlParameter("@ThoiGianNhoNhat", _lichTrinhVaoRaDTO.ThoiGianNhoNhat));
            _sqlParameter.Add(new SqlParameter("@ThoiGianLonNhat", _lichTrinhVaoRaDTO.ThoiGianLonNhat));
            _sqlParameter.Add(new SqlParameter("@KhoangCachGiuaHaiCapVaoRa", _lichTrinhVaoRaDTO.KhoangCachGiuaHaiCapVaoRa));
            Procedure("LICHTRINHVAORA_add", _sqlParameter);
        }
        public DataTable GETDANHSACH_LICHTRINHVAORA()
        {
            return SQLHelper.ExecuteDt("select * from lichtrinh_vaora");
        }
    }
}
