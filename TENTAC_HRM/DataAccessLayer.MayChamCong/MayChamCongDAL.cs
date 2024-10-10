using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using TENTAC_HRM.Common;
using TENTAC_HRM.DataTransferObject.MayChamCong;

namespace TENTAC_HRM.DataAccessLayer.MayChamCong
{
    internal class MayChamCongDAL : Provider
    {
        private DBHelper dbHelper;

        public MayChamCongDAL()
        {
            dbHelper = new DBHelper();
        }

        public void ThemMayChamCong(MayChamCongDTO _mayChamCongDTO)
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

        public DataTable LOADMAYCHAMCONG()
        {
            List<SqlParameter> _sqlParameter = new List<SqlParameter>();
            DataTable tb = new DataTable();
            return executeNonQuerya("maychamcong_getall", _sqlParameter);
        }

        public ArrayList SelectAllMCC()
        {
            SqlDataReader rd = dbHelper.ExecuteQuery("maychamcong_getall");
            ArrayList arrMCC = new ArrayList();
            while (rd.Read())
            {
                MayChamCongDTO _mayChamCongDTO = new MayChamCongDTO(rd.GetString(0), rd.GetString(1), rd.GetInt32(2), rd.GetString(3), rd.GetString(4), rd.GetInt32(5), rd.GetInt32(6), rd.GetString(7), rd.GetString(8), rd.GetDateTime(9), rd.GetBoolean(10), rd.GetString(11), rd.GetString(12), rd.GetBoolean(13), rd.GetInt32(14));
                arrMCC.Add(_mayChamCongDTO);
            }
            rd.Close();
            return arrMCC;
        }

        public void SuaMayChamCong(MayChamCongDTO _mayChamCongDTO)
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

        public void CapNhatActiveKey(MayChamCongDTO _mayChamCongDTO)
        {
            List<SqlParameter> _sqlParameter = new List<SqlParameter>();
            _sqlParameter.Add(new SqlParameter("@MaMCC", _mayChamCongDTO.MaMCC));
            _sqlParameter.Add(new SqlParameter("@Serial", _mayChamCongDTO.Serial));
            _sqlParameter.Add(new SqlParameter("@SoDangKy", _mayChamCongDTO.SoDangKy));
            Procedure("MAYCHAMCONG_activeKey", _sqlParameter);
        }

        public void DELELEMAYCHAMCONG(MayChamCongDTO _mayChamCongDTO)
        {
            List<SqlParameter> sqlpa = new List<SqlParameter>();
            sqlpa.Add(new SqlParameter("@MaMCC", _mayChamCongDTO.MaMCC));
            Procedure("MAYCHAMCONG_delete", sqlpa);
        }

        public DataTable MayChamCong_getLoad(MayChamCongDTO _mayChamCongDTO)
        {
            List<SqlParameter> _sqlParameter = new List<SqlParameter>();
            _sqlParameter.Add(new SqlParameter("@MaMCC", _mayChamCongDTO.MaMCC));
            return executeNonQuerya("MayChamCong_get", _sqlParameter);
        }

        public DataTable MayChamCong_getAllByTenMCC(MayChamCongDTO _mayChamCongDTO)
        {
            List<SqlParameter> _sqlParameter = new List<SqlParameter>();
            _sqlParameter.Add(new SqlParameter("@tenmcc", _mayChamCongDTO.TenMCC));
            return executeNonQuerya("maychamcong_getallbytenmcc", _sqlParameter);
        }
        public DataTable MayChamCong_getAllByMaMCC(MayChamCongDTO _mayChamCongDTO)
        {
            List<SqlParameter> _sqlParameter = new List<SqlParameter>();
            _sqlParameter.Add(new SqlParameter("@mamcc", _mayChamCongDTO.MaMCC));
            return executeNonQuerya("maychamcong_getallbymamcc", _sqlParameter);
        }
        public DataTable MayChamCong_getBySerial(MayChamCongDTO _mayChamCongDTO)
        {
            List<SqlParameter> _sqlParameter = new List<SqlParameter>();
            _sqlParameter.Add(new SqlParameter("@Serial", _mayChamCongDTO.Serial));
            return executeNonQuerya("MayChamCong_getBySerial", _sqlParameter);
        }
    }
}
