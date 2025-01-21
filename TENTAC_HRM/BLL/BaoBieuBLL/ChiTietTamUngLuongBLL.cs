using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using TENTAC_HRM.Common;
using TENTAC_HRM.Models.BaoBieuModel;

namespace TENTAC_HRM.BLL.BaoBieuBLL
{
    internal class ChiTietTamUngLuongBLL : Provider
    {
        public DataTable ChiTietTamUngLuongGetMaChamCongAndNgayTamUng(ChiTietTamUngLuongModel _chiTietTamUngLuongDTO)
        {
            return SQLHelper.ExecuteDt($"select * from MITACOSQL.dbo.[ChiTietTamUngLuong] where MaChamCong = '{_chiTietTamUngLuongDTO.MaChamCong}' and NgayTamUng = '{_chiTietTamUngLuongDTO.NgayTamUng}'");
        }
    }
}
