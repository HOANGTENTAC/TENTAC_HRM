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
    internal class KhuVucBLL : Provider
    {
        private DBHelper dbHelper;
        public KhuVucBLL()
        {
            dbHelper = new DBHelper();
        }

        public DataTable GETKHUVUCTREEVIEW(KhuVucDTO _khuVucDTO)
        {
            string sql = $"select * from  DB_MITACOSQL.dbo.[KHUVUC] where MaCongTy='{_khuVucDTO.MaCongTy}'";
            return SQLHelper.ExecuteDt(sql);
        }

        public DataTable KhuVucgetTreeView(KhuVucDTO _khuVucDTO)
        {
            string sql = $"select * from  DB_MITACOSQL.dbo.[KhuVuc] where TenKhuVuc = '{_khuVucDTO.TenKhuVuc}'";
            return SQLHelper.ExecuteDt(sql);
        }
    }
}
