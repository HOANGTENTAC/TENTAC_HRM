using System.Data;
using TENTAC_HRM.Common;
using TENTAC_HRM.Models.QuanLyNhanVienModel;

namespace TENTAC_HRM.BLL.QuanLyNhanVienBLL
{
    internal class CongTyBLL : Provider
    {
        private DBHelper dbHelper;

        public CongTyBLL()
        {
            dbHelper = new DBHelper();
        }

        public DataTable showThongTinCongTy(CongTyModel _congTyDTO)
        {
            string sql = "select * from MITACOSQL.dbo.[CONGTY]";
            return SQLHelper.ExecuteDt(sql);
        }

        public DataTable CongTygetTreeView(CongTyModel _congTyDTO)
        {
            string sql = $"select * from MITACOSQL.dbo.[CongTy] where TenCongTy = '{_congTyDTO.TenCongTy}'";
            return SQLHelper.ExecuteDt(sql);
        }
    }
}
