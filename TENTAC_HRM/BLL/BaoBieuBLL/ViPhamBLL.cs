using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using TENTAC_HRM.Common;
using TENTAC_HRM.Models.BaoBieuModel;

namespace TENTAC_HRM.BLL.BaoBieuBLL
{
    internal class ViPhamBLL : Provider
    {
        public DataTable ViPhamGetMaChamCongAndNgayThang(ViPhamModel _viPhamDTO)
        {
            return SQLHelper.ExecuteDt($"select * from MITACOSQL.dbo.[ViPham] where MaChamCong = '{_viPhamDTO.MaChamCong}' and NgayThang = '{_viPhamDTO.NgayThang}'");
        }
    }
}
