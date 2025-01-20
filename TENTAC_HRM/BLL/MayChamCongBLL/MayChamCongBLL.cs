using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using TENTAC_HRM.Common;
using TENTAC_HRM.Models.MayChamCongModel;

namespace TENTAC_HRM.Bll.MayChamCong
{
    internal class MayChamCongBLL : Provider
    {
        private DBHelper dbHelper;

        public MayChamCongBLL()
        {
            dbHelper = new DBHelper();
        }
        public void THEMMAYCHAMCONG(MayChamCongModel _mayChamCongDTO)
        {
            List<SqlParameter> _sqlParameter = new List<SqlParameter>();
            _sqlParameter.Add(new SqlParameter("@MaMCC", _mayChamCongDTO.MaMCC));
            _sqlParameter.Add(new SqlParameter("@TenMCC", _mayChamCongDTO.TenMCC));
            _sqlParameter.Add(new SqlParameter("@IDMCC", _mayChamCongDTO.IDMCC));
            _sqlParameter.Add(new SqlParameter("@KieuKetNoi", _mayChamCongDTO.KieuKetNoi));
            _sqlParameter.Add(new SqlParameter("@DiaChiIP", _mayChamCongDTO.DiaChiIP));
            _sqlParameter.Add(new SqlParameter("@Port", _mayChamCongDTO.Port));
            _sqlParameter.Add(new SqlParameter("@CongCOM", _mayChamCongDTO.CongCOM));
            _sqlParameter.Add(new SqlParameter("@TocDoTruyen", _mayChamCongDTO.TocDoTruyen));
            _sqlParameter.Add(new SqlParameter("@DiaChiWeb", _mayChamCongDTO.DiaChiWeb));
            _sqlParameter.Add(new SqlParameter("@NgayDangKyTenMien", _mayChamCongDTO.NgayDangKyTenMien));
            _sqlParameter.Add(new SqlParameter("@SuDungWeb", _mayChamCongDTO.SuDungWeb));
            _sqlParameter.Add(new SqlParameter("@Serial", _mayChamCongDTO.Serial));
            _sqlParameter.Add(new SqlParameter("@SoDangKy", _mayChamCongDTO.SoDangKy));
            _sqlParameter.Add(new SqlParameter("@TrangThai", _mayChamCongDTO.TrangThai));
            _sqlParameter.Add(new SqlParameter("@TrangThaiMay", _mayChamCongDTO.TrangThaiMay));
            Procedure("MAYCHAMCONG_add", _sqlParameter);
        }

        public DataTable GETDANHSACHMCC()
        {
            return SQLHelper.ExecuteDt("select * from  MITACOSQL.dbo.MAYCHAMCONG");
        }
        //public DataTable GETDANHSACHMCCComBobox()
        //{
        //    return SQLHelper.ExecuteDt("select MaMCC,TenMCC from  MITACOSQL.dbo.MAYCHAMCONG");
        //}
        public ArrayList GetAllMCC()
        {
            SqlDataReader rd = dbHelper.ExecuteQuery("select * from MITACOSQL.dbo.[MAYCHAMCONG]");
            ArrayList arrMCC = new ArrayList();
            while (rd.Read())
            {
                MayChamCongModel _mayChamCongDTO = new MayChamCongModel(rd.GetString(0), rd.GetString(1), rd.GetInt32(2), rd.GetString(3), rd.GetString(4), rd.GetInt32(5), rd.GetInt32(6), rd.GetString(7), rd.GetString(8), rd.GetDateTime(9), rd.GetBoolean(10), rd.GetString(11), rd.GetString(12), rd.GetBoolean(13), rd.GetInt32(14));
                arrMCC.Add(_mayChamCongDTO);
            }
            rd.Close();
            return arrMCC;
        }

        public void SUAMAYCHAMCONG(MayChamCongModel _mayChamCongDTO)
        {
            List<SqlParameter> _sqlParameter = new List<SqlParameter>();
            _sqlParameter.Add(new SqlParameter("@MaMCC", _mayChamCongDTO.MaMCC));
            _sqlParameter.Add(new SqlParameter("@TenMCC", _mayChamCongDTO.TenMCC));
            _sqlParameter.Add(new SqlParameter("@IDMCC", _mayChamCongDTO.IDMCC));
            _sqlParameter.Add(new SqlParameter("@KieuKetNoi", _mayChamCongDTO.KieuKetNoi));
            _sqlParameter.Add(new SqlParameter("@DiaChiIP", _mayChamCongDTO.DiaChiIP));
            _sqlParameter.Add(new SqlParameter("@Port", _mayChamCongDTO.Port));
            _sqlParameter.Add(new SqlParameter("@CongCOM", _mayChamCongDTO.CongCOM));
            _sqlParameter.Add(new SqlParameter("@TocDoTruyen", _mayChamCongDTO.TocDoTruyen));
            _sqlParameter.Add(new SqlParameter("@DiaChiWeb", _mayChamCongDTO.DiaChiWeb));
            _sqlParameter.Add(new SqlParameter("@SuDungWeb", _mayChamCongDTO.SuDungWeb));
            _sqlParameter.Add(new SqlParameter("@TrangThai", _mayChamCongDTO.TrangThai));
            _sqlParameter.Add(new SqlParameter("@TrangThaiMay", _mayChamCongDTO.TrangThaiMay));
            Procedure("MAYCHAMCONG_update", _sqlParameter);
        }

        public void SUAACTIVEKEY(MayChamCongModel _mayChamCongDTO)
        {
            List<SqlParameter> _sqlParameter = new List<SqlParameter>();
            _sqlParameter.Add(new SqlParameter("@MaMCC", _mayChamCongDTO.MaMCC));
            _sqlParameter.Add(new SqlParameter("@Serial", _mayChamCongDTO.Serial));
            _sqlParameter.Add(new SqlParameter("@SoDangKy", _mayChamCongDTO.SoDangKy));
            Procedure("MAYCHAMCONG_activeKey", _sqlParameter);
        }

        public void DELETEMAYCHAMCONG(MayChamCongModel _mayChamCongDTO)
        {
            List<SqlParameter> sqlpa = new List<SqlParameter>();
            sqlpa.Add(new SqlParameter("@MaMCC", _mayChamCongDTO.MaMCC));
            Procedure("MAYCHAMCONG_delete", sqlpa);
        }

        public DataTable MayChamCongGetLoad(string MaChamCong)
        {
            return SQLHelper.ExecuteDt($"select * from MITACOSQL.dbo.[MayChamCong] where MaMCC = '{MaChamCong}'");
        }

        public DataTable MayChamCongGetAllByTenMCC(MayChamCongModel _mayChamCongDTO)
        {
            return SQLHelper.ExecuteDt("select * from  MITACOSQL.dbo.MAYCHAMCONG where TenMCC = '" + _mayChamCongDTO.TenMCC + "'");
        }

        public DataTable MayChamCongGetBySerial(string Serial)
        {
            return SQLHelper.ExecuteDt($"select * from MITACOSQL.dbo.[MayChamCong] where Serial = '{Serial}'");
        }
    }
}
