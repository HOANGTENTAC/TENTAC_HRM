using System.Data;
using TENTAC_HRM.Common;
using TENTAC_HRM.DataTransferObject.QuanLyNhanVienDTO;

namespace TENTAC_HRM.BusinessLogicLayer.QuanLyNhanVienBLL
{
    internal class ChucVuBLL : Provider
    {
        private DBHelper dbHelper;
        public ChucVuBLL()
        {
            dbHelper = new DBHelper();
        }
        public DataTable GETCHUCVUTREEVIEW(ChucVuDTO _chucVuDTO)
        {
            string sql = $"select * from  DB_MITACOSQL.dbo.[CHUCVU] where MaPhongBan='{_chucVuDTO.MaPhongBan}'";
            return SQLHelper.ExecuteDt(sql);
        }
        public DataTable ChucVugetTreeView(ChucVuDTO _chucVuDTO)
        {
            string sql = $"select * from  DB_MITACOSQL.dbo.[ChucVu] where TenChucVu = '{_chucVuDTO.TenKhuVuc}'";
            return SQLHelper.ExecuteDt(sql);
        }
    }
}
