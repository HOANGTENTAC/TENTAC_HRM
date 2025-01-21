using System;
using System.Data;

namespace TENTAC_HRM.BLL.ChamCongBLL
{
    internal class KhaiBaoVangChoNhanVienBLL
    {
        public DataTable CacLoaiVangGetTinhCong(int MaChamCong, DateTime NgayThang)
        {
            return SQLHelper.ExecuteDt($"select * from MITACOSQL.dbo.[KhaiBaoVangChoNhanVien] where MaChamCong = '{MaChamCong}' and NgayThang = '{NgayThang}'");
        }
    }
}
