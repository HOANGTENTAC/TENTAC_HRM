using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using TENTAC_HRM.Models.BaoBieuModel;
using TENTAC_HRM.Common;

namespace TENTAC_HRM.BLL.BaoBieuBLL
{
    internal class ChiTietCongTruLuongBLL : Provider
    {
        public void ChiTietCongTruLuongInsert(ChiTietCongTruLuongModel _chiTietCongTruLuongDTO)
        {
            string sql = $@"insert into MITACOSQL.dbo.[ChiTietCongTruLuong](MaChamCong,ChiTietPhuCapCom,ChiTietPhuCapKhac,ChiTietTamUngLuong,ChiTietViPham,ChiTietThuong)  
                            values('{_chiTietCongTruLuongDTO.MaChamCong}','{_chiTietCongTruLuongDTO.ChiTietPhuCapCom}',
                                    '{_chiTietCongTruLuongDTO.ChiTietPhuCapKhac}','{_chiTietCongTruLuongDTO.ChiTietTamUngLuong}',
                                    '{_chiTietCongTruLuongDTO.ChiTietViPham}','{_chiTietCongTruLuongDTO.ChiTietThuong}')";
            SQLHelper.ExecuteSql(sql);
        }

        public void ChiTietCongTruLuongDelete()
        {
            SQLHelper.ExecuteSql("TRUNCATE TABLE MITACOSQL.dbo.[ChiTietCongTruLuong]");
        }

        public DataTable ChiTietCongTruLuongGetByMaChamCong(int machamcong)
        {
            return SQLHelper.ExecuteDt($"select * from MITACOSQL.dbo.[ChiTietCongTruLuong] where MaChamCong = '{machamcong}'");
        }
    }
}
