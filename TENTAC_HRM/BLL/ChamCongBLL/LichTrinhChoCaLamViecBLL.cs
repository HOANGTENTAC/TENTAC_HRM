using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using TENTAC_HRM.Models.ChamCongModel;
using TENTAC_HRM.Common;

namespace TENTAC_HRM.BLL.ChamCongBLL
{
    internal class LichTrinhChoCaLamViecBLL : Provider
    {
        private DBHelper dbHelper;

        public LichTrinhChoCaLamViecBLL()
        {
            this.dbHelper = new DBHelper();
        }
        public void THEMLICHTRINHCHOCALAMVIEC(LichTrinhChoCaLamViecModel _lichTrinhChoCaLamViecDTO)
        {
            List<SqlParameter> _sqlParameter;
            _sqlParameter = new List<SqlParameter>();
            _sqlParameter.Add(new SqlParameter("@MaLichTrinhCaLamViec", _lichTrinhChoCaLamViecDTO.MaLichTrinhCaLamViec));
            _sqlParameter.Add(new SqlParameter("@TenLichTrinhCaLamViec", _lichTrinhChoCaLamViecDTO.TenLichTrinhCaLamViec));
            _sqlParameter.Add(new SqlParameter("@ChuKy", _lichTrinhChoCaLamViecDTO.ChuKy));
            base.Procedure("LICHTRINHCHOCALAMVIEC_add", _sqlParameter);
        }

        public DataTable GET_DANHSACH_LICHTRINHCHOCALAMVIEC()
        {
            return SQLHelper.ExecuteDt("select * from  MITACOSQL.dbo.lichtrinh_chocalamviec");
        }

        public ArrayList load_LichTrinhChoCaLamViecLenComboBox()
        {
            SqlDataReader rd;
            rd = this.dbHelper.ExecuteQuery("select * from MITACOSQL.dbo.[LICHTRINHCHOCALAMVIEC]");
            ArrayList arrLichTrinhChoCaLamViec;
            arrLichTrinhChoCaLamViec = new ArrayList();
            while (rd.Read())
            {
                arrLichTrinhChoCaLamViec.Add(new LichTrinhChoCaLamViecModel(rd.GetString(0), rd.GetString(1)));
            }
            rd.Close();
            return arrLichTrinhChoCaLamViec;
        }

        public void SUA_LICHTRINHCHOCALAMVIEC(LichTrinhChoCaLamViecModel _lichTrinhChoCaLamViecDTO)
        {
            List<SqlParameter> _sqlParameter;
            _sqlParameter = new List<SqlParameter>();
            _sqlParameter.Add(new SqlParameter("@MaLichTrinhCaLamViec", _lichTrinhChoCaLamViecDTO.MaLichTrinhCaLamViec));
            _sqlParameter.Add(new SqlParameter("@TenLichTrinhCaLamViec", _lichTrinhChoCaLamViecDTO.TenLichTrinhCaLamViec));
            _sqlParameter.Add(new SqlParameter("@ChuKy", _lichTrinhChoCaLamViecDTO.ChuKy));
            base.Procedure("LICHTRINHCHOCALAMVIEC_update", _sqlParameter);
        }

        public DataTable get_LichTrinhChoCaLamViecByMaLichTrinhCaLamViec(string MaLichTrinhCaLamViec)
        {
            return SQLHelper.ExecuteDt($"select * from MITACOSQL.dbo.[LICHTRINHCHOCALAMVIEC] where MaLichTrinhCaLamViec = '{MaLichTrinhCaLamViec}'");
        }

        public void LichTrinhChoCaLamViecDelete(string MaLichTrinhCaLamViec)
        {
            SQLHelper.ExecuteSql($"delete MITACOSQL.dbo.[LichTrinhChoCaLamViec] where MaLichTrinhCaLamViec = '{MaLichTrinhCaLamViec}'");
        }
    }
}
