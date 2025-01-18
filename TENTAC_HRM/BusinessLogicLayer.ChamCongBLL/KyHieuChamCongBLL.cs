using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TENTAC_HRM.Common;
using TENTAC_HRM.Models;

namespace TENTAC_HRM.BusinessLogicLayer.ChamCongBLL
{
    internal class KyHieuChamCongBLL : Provider
    {
        public void Insert_KyHieuChamCong(KyHieuChamCong_Model _kyHieuChamCongDTO)
        {
            List<SqlParameter> _sqlParameter;
            _sqlParameter = new List<SqlParameter>();
            _sqlParameter.Add(new SqlParameter("@MaKyHieu", _kyHieuChamCongDTO.MaKyHieu));
            _sqlParameter.Add(new SqlParameter("@DiTre", _kyHieuChamCongDTO.DiTre));
            _sqlParameter.Add(new SqlParameter("@VeSom", _kyHieuChamCongDTO.VeSom));
            _sqlParameter.Add(new SqlParameter("@DungGio", _kyHieuChamCongDTO.DungGio));
            _sqlParameter.Add(new SqlParameter("@TangCa", _kyHieuChamCongDTO.TangCa));
            _sqlParameter.Add(new SqlParameter("@ThieuGioVao", _kyHieuChamCongDTO.ThieuGioVao));
            _sqlParameter.Add(new SqlParameter("@ThieuGioRa", _kyHieuChamCongDTO.ThieuGioRa));
            _sqlParameter.Add(new SqlParameter("@Vang", _kyHieuChamCongDTO.Vang));
            _sqlParameter.Add(new SqlParameter("@ChuaXepCa", _kyHieuChamCongDTO.ChuaXepCa));
            _sqlParameter.Add(new SqlParameter("@PhepNam", _kyHieuChamCongDTO.PhepNam));
            _sqlParameter.Add(new SqlParameter("@Le", _kyHieuChamCongDTO.Le));
            _sqlParameter.Add(new SqlParameter("@CongTac", _kyHieuChamCongDTO.CongTac));
            _sqlParameter.Add(new SqlParameter("@VeTre", _kyHieuChamCongDTO.VeTre));
            _sqlParameter.Add(new SqlParameter("@CuoiTuan", _kyHieuChamCongDTO.CuoiTuan));
            base.Procedure("KYHIEUCHAMCONG_add", _sqlParameter);
        }

        public void Update_KyHieuChamCong(KyHieuChamCong_Model _kyHieuChamCongDTO)
        {
            List<SqlParameter> _sqlParameter;
            _sqlParameter = new List<SqlParameter>();
            _sqlParameter.Add(new SqlParameter("@MaKyHieu", _kyHieuChamCongDTO.MaKyHieu));
            _sqlParameter.Add(new SqlParameter("@DiTre", _kyHieuChamCongDTO.DiTre));
            _sqlParameter.Add(new SqlParameter("@VeSom", _kyHieuChamCongDTO.VeSom));
            _sqlParameter.Add(new SqlParameter("@DungGio", _kyHieuChamCongDTO.DungGio));
            _sqlParameter.Add(new SqlParameter("@TangCa", _kyHieuChamCongDTO.TangCa));
            _sqlParameter.Add(new SqlParameter("@ThieuGioVao", _kyHieuChamCongDTO.ThieuGioVao));
            _sqlParameter.Add(new SqlParameter("@ThieuGioRa", _kyHieuChamCongDTO.ThieuGioRa));
            _sqlParameter.Add(new SqlParameter("@Vang", _kyHieuChamCongDTO.Vang));
            _sqlParameter.Add(new SqlParameter("@ChuaXepCa", _kyHieuChamCongDTO.ChuaXepCa));
            _sqlParameter.Add(new SqlParameter("@PhepNam", _kyHieuChamCongDTO.PhepNam));
            _sqlParameter.Add(new SqlParameter("@Le", _kyHieuChamCongDTO.Le));
            _sqlParameter.Add(new SqlParameter("@CongTac", _kyHieuChamCongDTO.CongTac));
            _sqlParameter.Add(new SqlParameter("@VeTre", _kyHieuChamCongDTO.VeTre));
            _sqlParameter.Add(new SqlParameter("@CuoiTuan", _kyHieuChamCongDTO.CuoiTuan));
            base.Procedure("KYHIEUCHAMCONG_update", _sqlParameter);
        }

        public DataTable showKyHieuChamCong(KyHieuChamCong_Model _kyHieuChamCongDTO)
        {
            List<SqlParameter> _sqlParameter;
            _sqlParameter = new List<SqlParameter>();
            new DataTable();
            return base.executeNonQuerya("KYHIEUCHAMCONG_getall", _sqlParameter);
        }

        public DataTable showLoadKyHieuChamCong(KyHieuChamCong_Model _kyHieuChamCongDTO)
        {
            return SQLHelper.ExecuteDt($"select * from  MITACOSQL.dbo.[KYHIEUCHAMCONG] where MaKyHieu = '{_kyHieuChamCongDTO.MaKyHieu}'");
        }
    }
}
