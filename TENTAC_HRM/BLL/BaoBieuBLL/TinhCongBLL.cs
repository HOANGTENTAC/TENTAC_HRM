using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using TENTAC_HRM.Common;
using TENTAC_HRM.Models.BaoBieuModel;

namespace TENTAC_HRM.BLL.BaoBieuBLL
{
    internal class TinhCongBLL : Provider
    {
        public void TinhCongInsert(TinhCongModel _tinhCongDTO)
        {
            string sql = $@"insert into MITACOSQL.dbo.[TinhCong](  
                            MaNhanVien,TenNhanVien,MaChamCong,Ngay,Thu,Ca,GioVao,GioRa,Cong,Gio,Tre,VeSom,VeTre,TC1,TC2,TC3,TC4,TongGio,DemCong,KyHieu,KyHieuPhu,PhongBan)  
                            values(  
                            '{_tinhCongDTO.MaNhanVien}',
                            N'{_tinhCongDTO.TenNhanVien}',
                            '{_tinhCongDTO.MaChamCong}',
                            '{_tinhCongDTO.Ngay}',
                            '{_tinhCongDTO.Thu}',
                            '{_tinhCongDTO.Ca}',
                            '{_tinhCongDTO.GioVao}',
                            '{_tinhCongDTO.GioRa}',
                            '{_tinhCongDTO.Cong}',
                            '{_tinhCongDTO.Gio}',
                            '{_tinhCongDTO.Tre}',
                            '{_tinhCongDTO.VeSom}',
                            '{_tinhCongDTO.VeTre}',
                            '{_tinhCongDTO.TC1}',
                            '{_tinhCongDTO.TC2}',
                            '{_tinhCongDTO.TC3}',
                            '{_tinhCongDTO.TC4}',
                            '{_tinhCongDTO.TongGio}',
                            '{_tinhCongDTO.DemCong}',
                            '{_tinhCongDTO.KyHieu}',
                            '{_tinhCongDTO.KyHieuPhu}',
                            '{_tinhCongDTO.PhongBan}')";
            SQLHelper.ExecuteSql(sql);
        }

        public void TinhCongDelete(TinhCongModel _tinhCongDTO)
        {
            SQLHelper.ExecuteSql("TRUNCATE TABLE MITACOSQL.dbo.[TinhCong]");
        }

        public DataTable TinhCongGetAll(TinhCongModel _tinhCongDTO)
        {
            return SQLHelper.ExecuteDt("select * from MITACOSQL.dbo.[TinhCong]");
        }

        public DataTable TinhCongGetByMaChamCong(TinhCongModel _tinhCongDTO)
        {
            return SQLHelper.ExecuteDt($"select * from MITACOSQL.dbo.[TinhCong] where MaChamCong = '{_tinhCongDTO.MaChamCong}'");
        }

        public DataTable TinhCongGetByMaChamCongAndKyHieuPhu(TinhCongModel _tinhCongDTO)
        {
            return SQLHelper.ExecuteDt($"select * from MITACOSQL.dbo.[TinhCong] where MaChamCong = '{_tinhCongDTO.MaChamCong}' and KyHieuPhu = '{_tinhCongDTO.KyHieuPhu}'");
        }

        public DataTable TinhCongGetByMaChamCongAndLe(TinhCongModel _tinhCongDTO)
        {
            return SQLHelper.ExecuteDt($"select * from MITACOSQL.dbo.[TinhCong] where MaChamCong = '{_tinhCongDTO.MaChamCong}' and KyHieu = '{_tinhCongDTO.KyHieu}'");
        }

        public DataTable TinhCongGetNgayAndPhongBan(TinhCongModel _tinhCongDTO)
        {
            return SQLHelper.ExecuteDt($"select * from MITACOSQL.dbo.[TinhCong] where Ngay = '{_tinhCongDTO.Ngay}' and PhongBan = '{_tinhCongDTO.PhongBan}'");
        }

        public DataTable TinhCongGetNgay(TinhCongModel _tinhCongDTO)
        {
            return SQLHelper.ExecuteDt($"select * from MITACOSQL.dbo.[TinhCong] where Ngay = '{_tinhCongDTO.Ngay}'");
        }

        public DataTable TinhCongGetMaChamCongAndNgay(TinhCongModel _tinhCongDTO)
        {
            return SQLHelper.ExecuteDt($"select * from MITACOSQL.dbo.[TinhCong] where MaChamCong = '{_tinhCongDTO.MaChamCong}' and Ngay = '{_tinhCongDTO.Ngay}'");
        }

        public DataTable TinhCongGetMaChamCongAndNgayChiTietTungNguoiTungNgay(TinhCongModel _tinhCongDTO)
        {
            string sql = $@"select Thu,GioVao,GioRa,Tre,VeSom,VeTre,Gio,Cong,TC1,KyHieu,TC2 
			                from MITACOSQL.dbo.[TinhCong]
                            where MaChamCong = '{_tinhCongDTO.MaChamCong}' and Ngay = '{_tinhCongDTO.Ngay}'";
            return SQLHelper.ExecuteDt(sql);
        }

        public DataTable TinhCongGetMaChamCongAndNgayThongKeCong(TinhCongModel _tinhCongDTO)
        {
            return SQLHelper.ExecuteDt($"select Thu,Cong from MITACOSQL.dbo.[TinhCong] where MaChamCong = '{_tinhCongDTO.MaChamCong}' and Ngay = '{_tinhCongDTO.Ngay}'");
        }

        public DataTable TinhCongGetMaChamCongAndNgayChiTietThoiGian(TinhCongModel _tinhCongDTO)
        {
            return SQLHelper.ExecuteDt($"select Thu,GioVao,GioRa,Gio,TC1,TC2 from MITACOSQL.dbo.[TinhCong] where MaChamCong = '{_tinhCongDTO.MaChamCong}' and Ngay = '{_tinhCongDTO.Ngay}'");
        }

        public DataTable TinhCongGetMaChamCongAndNgayGioVaTC(TinhCongModel _tinhCongDTO)
        {
            return SQLHelper.ExecuteDt($"select Thu,GioVao,GioRa,Gio,TC1,TC2 from MITACOSQL.dbo.[TinhCong] where MaChamCong = '{_tinhCongDTO.MaChamCong}' and Ngay = '{_tinhCongDTO.Ngay}'");
        }

        public DataTable TinhCongGetMaChamCongAndNgayThongKeGio(TinhCongModel _tinhCongDTO)
        {
            return SQLHelper.ExecuteDt($"select Thu,KyHieu,KyHieuPhu,Gio from MITACOSQL.dbo.[TinhCong] where MaChamCong = '{_tinhCongDTO.MaChamCong}' and Ngay = '{_tinhCongDTO.Ngay}'");
        }
    }
}
