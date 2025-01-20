using System.Data;
using TENTAC_HRM.Common;
using TENTAC_HRM.Models.QuanLyNhanVienModel;

namespace TENTAC_HRM.BLL.QuanLyNhanVienBLL
{
    internal class KhuVucBLL : Provider
    {
        public DataTable GETKHUVUCTREEVIEW(KhuVucDTO _khuVucDTO)
        {
            string sql = $"select * from  MITACOSQL.dbo.[KHUVUC] where MaCongTy='{_khuVucDTO.MaCongTy}'";
            return SQLHelper.ExecuteDt(sql);
        }

        public DataTable KhuVucgetTreeView(KhuVucDTO _khuVucDTO)
        {
            string sql = $"select * from  MITACOSQL.dbo.[KhuVuc] where TenKhuVuc = '{_khuVucDTO.TenKhuVuc}'";
            return SQLHelper.ExecuteDt(sql);
        }
    }
}
