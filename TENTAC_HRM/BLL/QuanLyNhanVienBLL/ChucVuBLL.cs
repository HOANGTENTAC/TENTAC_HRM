using System.Data;
using TENTAC_HRM.Common;
using TENTAC_HRM.Models.QuanLyNhanVienModel;

namespace TENTAC_HRM.BLL.QuanLyNhanVienBLL
{
    internal class ChucVuBLL : Provider
    {
        public DataTable GETCHUCVUTREEVIEW(ChucVuModel _chucVuDTO)
        {
            string sql = $"select * from MITACOSQL.dbo.[CHUCVU] where MaPhongBan='{_chucVuDTO.MaPhongBan}'";
            return SQLHelper.ExecuteDt(sql);
        }
        public DataTable ChucVugetTreeView(ChucVuModel _chucVuDTO)
        {
            string sql = $"select * from MITACOSQL.dbo.[ChucVu] where TenChucVu = '{_chucVuDTO.TenKhuVuc}'";
            return SQLHelper.ExecuteDt(sql);
        }
    }
}
