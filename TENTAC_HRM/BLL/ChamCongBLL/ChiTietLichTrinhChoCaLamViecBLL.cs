using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using TENTAC_HRM.Common;
using TENTAC_HRM.Models.ChamCongModel;

namespace TENTAC_HRM.BLL.ChamCongBLL
{
    internal class ChiTietLichTrinhChoCaLamViecBLL : Provider
    {
        public void InsertChiTietLichTrinhChoCaLamViec(ChiTietLichTrinhChoCaLamViecModel _chiTietLichTrinhChoCaLamViecDTO)
        {
            List<SqlParameter> _sqlParameter;
            _sqlParameter = new List<SqlParameter>();
            _sqlParameter.Add(new SqlParameter("@MaLichTrinhCaLamViec", _chiTietLichTrinhChoCaLamViecDTO.MaLichTrinhCaLamViec));
            _sqlParameter.Add(new SqlParameter("@Thu", _chiTietLichTrinhChoCaLamViecDTO.Thu));
            _sqlParameter.Add(new SqlParameter("@CaThu1", _chiTietLichTrinhChoCaLamViecDTO.CaThu1));
            _sqlParameter.Add(new SqlParameter("@CaThu2", _chiTietLichTrinhChoCaLamViecDTO.CaThu2));
            _sqlParameter.Add(new SqlParameter("@CaThu3", _chiTietLichTrinhChoCaLamViecDTO.CaThu3));
            _sqlParameter.Add(new SqlParameter("@CaThu4", _chiTietLichTrinhChoCaLamViecDTO.CaThu4));
            _sqlParameter.Add(new SqlParameter("@CaThu5", _chiTietLichTrinhChoCaLamViecDTO.CaThu5));
            _sqlParameter.Add(new SqlParameter("@CaThu6", _chiTietLichTrinhChoCaLamViecDTO.CaThu6));
            _sqlParameter.Add(new SqlParameter("@CaThu7", _chiTietLichTrinhChoCaLamViecDTO.CaThu7));
            _sqlParameter.Add(new SqlParameter("@CaThu8", _chiTietLichTrinhChoCaLamViecDTO.CaThu8));
            _sqlParameter.Add(new SqlParameter("@CaThu9", _chiTietLichTrinhChoCaLamViecDTO.CaThu9));
            _sqlParameter.Add(new SqlParameter("@CaThu10", _chiTietLichTrinhChoCaLamViecDTO.CaThu10));
            base.Procedure("ChiTietLichTrinhCaLamViec_add", _sqlParameter);
        }

        public void UpdateChiTietLichTrinhChoCaLamViec(ChiTietLichTrinhChoCaLamViecModel _chiTietLichTrinhChoCaLamViecDTO)
        {
            List<SqlParameter> _sqlParameter;
            _sqlParameter = new List<SqlParameter>();
            _sqlParameter.Add(new SqlParameter("@ID", _chiTietLichTrinhChoCaLamViecDTO.ID));
            _sqlParameter.Add(new SqlParameter("@MaLichTrinhCaLamViec", _chiTietLichTrinhChoCaLamViecDTO.MaLichTrinhCaLamViec));
            _sqlParameter.Add(new SqlParameter("@Thu", _chiTietLichTrinhChoCaLamViecDTO.Thu));
            _sqlParameter.Add(new SqlParameter("@CaThu1", _chiTietLichTrinhChoCaLamViecDTO.CaThu1));
            _sqlParameter.Add(new SqlParameter("@CaThu2", _chiTietLichTrinhChoCaLamViecDTO.CaThu2));
            _sqlParameter.Add(new SqlParameter("@CaThu3", _chiTietLichTrinhChoCaLamViecDTO.CaThu3));
            _sqlParameter.Add(new SqlParameter("@CaThu4", _chiTietLichTrinhChoCaLamViecDTO.CaThu4));
            _sqlParameter.Add(new SqlParameter("@CaThu5", _chiTietLichTrinhChoCaLamViecDTO.CaThu5));
            _sqlParameter.Add(new SqlParameter("@CaThu6", _chiTietLichTrinhChoCaLamViecDTO.CaThu6));
            _sqlParameter.Add(new SqlParameter("@CaThu7", _chiTietLichTrinhChoCaLamViecDTO.CaThu7));
            _sqlParameter.Add(new SqlParameter("@CaThu8", _chiTietLichTrinhChoCaLamViecDTO.CaThu8));
            _sqlParameter.Add(new SqlParameter("@CaThu9", _chiTietLichTrinhChoCaLamViecDTO.CaThu9));
            _sqlParameter.Add(new SqlParameter("@CaThu10", _chiTietLichTrinhChoCaLamViecDTO.CaThu10));
            base.Procedure("ChiTietLichTrinhCaLamViec_update", _sqlParameter);
        }

        public DataTable getChiTietLichTrinhChoCaLamViec(string MaLichTrinhCaLamViec)
        {
            return SQLHelper.ExecuteDt($"select * from MITACOSQL.dbo.[ChiTietLichTrinhCaLamViec] where MaLichTrinhCaLamViec = '{MaLichTrinhCaLamViec}'");
        }

        public void DeleteChiTietLichTrinhChoCaLamViec(string MaLichTrinhCaLamViec)
        {
            SQLHelper.ExecuteSql($"delete MITACOSQL.dbo.[ChiTietLichTrinhCaLamViec] where MaLichTrinhCaLamViec = '{MaLichTrinhCaLamViec}'");
        }

        public DataTable ChiTietLichTrinhChoCaLamViecgetByMaLichTrinhCalamViec(string MaLichTrinhCaLamViec)
        {
            return SQLHelper.ExecuteDt($"select * from MITACOSQL.dbo.ChiTietLichTrinhCaLamViec where MaLichTrinhCaLamViec='{MaLichTrinhCaLamViec}'");
        }

        public DataTable ChiTietLichTrinhChoCaLamViecNhanCa(ChiTietLichTrinhChoCaLamViecModel _chiTietLichTrinhChoCaLamViecDTO)
        {
            return SQLHelper.ExecuteDt($"select * from MITACOSQL.dbo.[ChiTietLichTrinhCaLamViec] where MaLichTrinhCaLamViec = '{_chiTietLichTrinhChoCaLamViecDTO.MaLichTrinhCaLamViec}' and Thu = '{_chiTietLichTrinhChoCaLamViecDTO.Thu}'");
        }

        public DataTable ChiTietLichTrinhChoCaLamViecGetID(int Id)
        {
            return SQLHelper.ExecuteDt($"select * from MITACOSQL.dbo.ChiTietLichTrinhCaLamViec where ID='{Id}'");
        }
    }
}
