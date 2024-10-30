using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TENTAC_HRM.Common;
using TENTAC_HRM.DataTransferObject.QuanLyNhanVienDTO;

namespace TENTAC_HRM.BusinessLogicLayer.QuanLyNhanVienBLL
{
    internal class CongTyBLL : Provider
    {
        private DBHelper dbHelper;

        public CongTyBLL()
        {
            dbHelper = new DBHelper();
        }

        public DataTable showThongTinCongTy(CongTyDTO _congTyDTO)
        {
            string sql = "select * from  DB_MITACOSQL.dbo.[CONGTY]";
            return SQLHelper.ExecuteDt(sql);
        }

        public DataTable CongTygetTreeView(CongTyDTO _congTyDTO)
        {
            string sql = $"select * from  DB_MITACOSQL.dbo.[CongTy] where TenCongTy = '{_congTyDTO.TenCongTy}'";
            return SQLHelper.ExecuteDt(sql);
        }
    }
}
