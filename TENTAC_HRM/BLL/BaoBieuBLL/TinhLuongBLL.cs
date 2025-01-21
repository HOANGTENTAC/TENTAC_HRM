using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using TENTAC_HRM.Common;
using TENTAC_HRM.Models.BaoBieuModel;

namespace TENTAC_HRM.BLL.BaoBieuBLL
{
    internal class TinhLuongBLL : Provider
    {
        public void TinhLuongInsert(TinhLuongModel _tinhLuongDTO)
        {
            string sql = $@"insert into MITACOSQL.dbo.[TinhLuong](MaNhanVien, TenNhanVien, MaChamCong, LuongCoBanBaoHiem,  
                             LuongHopDong, NgayCongTinh, NgayCongLamDuoc, SoGioTangCa, LuongNgayCongLamDuoc,  
                             TienTangCa, PhuCapTienCom, PhuCapTienComTheoNgayCong, PhuCapKhac, Thuong,  
                             TongLuong, BHXH, BHYT, BHTN, TamUng,  
                             ViPham, TongTienTruVaoLuong, LuongThucLanh)  
                            values(  
                             '{_tinhLuongDTO.MaNhanVien}', N'{_tinhLuongDTO.TenNhanVien}', '{_tinhLuongDTO.MaChamCong}',
                             '{_tinhLuongDTO.LuongCoBanBaoHiem}', '{_tinhLuongDTO.LuongHopDong}', '{_tinhLuongDTO.NgayCongTinh}',
                             '{_tinhLuongDTO.NgayCongLamDuoc}', '{_tinhLuongDTO.SoGioTangCa}',  
                             '{_tinhLuongDTO.LuongNgayCongLamDuoc}', '{_tinhLuongDTO.TienTangCa}', '{_tinhLuongDTO.PhuCapTienCom}',  
                             '{_tinhLuongDTO.PhuCapTienComTheoNgayCong}', '{_tinhLuongDTO.PhuCapKhac}', '{_tinhLuongDTO.Thuong}',  
                             '{_tinhLuongDTO.TongLuong}', '{_tinhLuongDTO.BHXH}', '{_tinhLuongDTO.BHYT}',
                             '{_tinhLuongDTO.BHTN}', '{_tinhLuongDTO.TamUng}', '{_tinhLuongDTO.ViPham}',  
                             '{_tinhLuongDTO.TongTienTruVaoLuong}', '{_tinhLuongDTO.LuongThucLanh}')";
            SQLHelper.ExecuteSql(sql);
        }

        public void TinhLuongDelete()
        {
            SQLHelper.ExecuteSql("delete MITACOSQL.dbo.[TinhLuong]");
        }

        public DataTable TinhLuongSelectAll()
        {
            return SQLHelper.ExecuteDt("select * from MITACOSQL.dbo.[TinhLuong]");
        }
    }
}
