using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using TENTAC_HRM.Common;
using TENTAC_HRM.Models;
using TENTAC_HRM.Models.ChamCongModel;

namespace TENTAC_HRM.BLL.ChamCongBLL
{
    internal class LichTrinhVaoRaBLL : Provider
    {
        private DBHelper dbHelper;

        public LichTrinhVaoRaBLL()
        {
            this.dbHelper = new DBHelper();
        }
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
            return SQLHelper.ExecuteDt("select * from MITACOSQL.lichtrinh_vaora");
        }
        public ArrayList load_LichTrinhVaoRaLenComboBox()
        {
            SqlDataReader rd;
            rd = this.dbHelper.ExecuteQuery("select * from MITACOSQL.dbo.[LICHTRINHVAORA]");
            ArrayList arrLichTrinhVaoRa;
            arrLichTrinhVaoRa = new ArrayList();
            while (rd.Read())
            {
                arrLichTrinhVaoRa.Add(new LichTrinhVaoRaModel(rd.GetString(0), rd.GetString(1), rd.GetInt32(2), rd.GetBoolean(3), rd.GetBoolean(4), rd.GetDateTime(5), rd.GetDateTime(6), rd.GetInt32(7), rd.GetInt32(8), rd.GetInt32(9)));
            }
            rd.Close();
            return arrLichTrinhVaoRa;
        }

        public void SUA_LICHTRINHVAORA(LichTrinhVaoRaModel _lichTrinhVaoRaDTO)
        {
            List<SqlParameter> _sqlParameter;
            _sqlParameter = new List<SqlParameter>();
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
            base.Procedure("LICHTRINHVAORA_update", _sqlParameter);
        }

        public void DELETE_LICHTRINHVAORA(string MaLichTrinhVaoRa)
        {
            SQLHelper.ExecuteSql($"delete MITACOSQL.dbo.[LICHTRINHVAORA] where MaLichTrinhVaoRa = '{MaLichTrinhVaoRa}'");
        }

        public void DELETEALL_LICHTRINHVAORA(LichTrinhVaoRaModel _lichTrinhVaoRaDTO)
        {
            SQLHelper.ExecuteSql("delete MITACOSQL.dbo.[LICHTRINHVAORA]  ");
        }

        public DataTable get_LichTrinhVaoRaByMaLichTrinhVaoRa(string MaLichTrinhVaoRa)
        {
            return SQLHelper.ExecuteDt($"select * from MITACOSQL.dbo.[LICHTRINHVAORA] where MaLichTrinhVaoRa = '{MaLichTrinhVaoRa}'");
        }
    }
}
