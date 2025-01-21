using System.Data;
using TENTAC_HRM.Common;
using TENTAC_HRM.Models.BaoBieuModel;

namespace TENTAC_HRM.BLL.BaoBieuBLL
{
    internal class ThuongBLL : Provider
    {
        public DataTable ThuongGetByMaChamCongAndNgayThuong(ThuongModel _thuongDTO)
        {
            return SQLHelper.ExecuteDt($"select * from MITACOSQL.dbo.[ChiTietThuongNhanVien] where MaChamCong = '{_thuongDTO.MaChamCong}' and NgayThuong = '{_thuongDTO.NgayThuong}'");
        }
    }
}
