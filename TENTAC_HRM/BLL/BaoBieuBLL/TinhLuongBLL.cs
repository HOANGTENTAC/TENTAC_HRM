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
            List<SqlParameter> _sqlParameter;
            _sqlParameter = new List<SqlParameter>();
            _sqlParameter.Add(new SqlParameter("@MaNhanVien", _tinhLuongDTO.MaNhanVien));
            _sqlParameter.Add(new SqlParameter("@TenNhanVien", _tinhLuongDTO.TenNhanVien));
            _sqlParameter.Add(new SqlParameter("@MaChamCong", _tinhLuongDTO.MaChamCong));
            _sqlParameter.Add(new SqlParameter("@LuongCoBanBaoHiem", _tinhLuongDTO.LuongCoBanBaoHiem));
            _sqlParameter.Add(new SqlParameter("@LuongHopDong", _tinhLuongDTO.LuongHopDong));
            _sqlParameter.Add(new SqlParameter("@NgayCongTinh", _tinhLuongDTO.NgayCongTinh));
            _sqlParameter.Add(new SqlParameter("@NgayCongLamDuoc", _tinhLuongDTO.NgayCongLamDuoc));
            _sqlParameter.Add(new SqlParameter("@SoGioTangCa", _tinhLuongDTO.SoGioTangCa));
            _sqlParameter.Add(new SqlParameter("@LuongNgayCongLamDuoc", _tinhLuongDTO.LuongNgayCongLamDuoc));
            _sqlParameter.Add(new SqlParameter("@TienTangCa", _tinhLuongDTO.TienTangCa));
            _sqlParameter.Add(new SqlParameter("@PhuCapTienCom", _tinhLuongDTO.PhuCapTienCom));
            _sqlParameter.Add(new SqlParameter("@PhuCapTienComTheoNgayCong", _tinhLuongDTO.PhuCapTienComTheoNgayCong));
            _sqlParameter.Add(new SqlParameter("@PhuCapKhac", _tinhLuongDTO.PhuCapKhac));
            _sqlParameter.Add(new SqlParameter("@Thuong", _tinhLuongDTO.Thuong));
            _sqlParameter.Add(new SqlParameter("@TongLuong", _tinhLuongDTO.TongLuong));
            _sqlParameter.Add(new SqlParameter("@BHXH", _tinhLuongDTO.BHXH));
            _sqlParameter.Add(new SqlParameter("@BHYT", _tinhLuongDTO.BHYT));
            _sqlParameter.Add(new SqlParameter("@BHTN", _tinhLuongDTO.BHTN));
            _sqlParameter.Add(new SqlParameter("@TamUng", _tinhLuongDTO.TamUng));
            _sqlParameter.Add(new SqlParameter("@ViPham", _tinhLuongDTO.ViPham));
            _sqlParameter.Add(new SqlParameter("@TongTienTruVaoLuong", _tinhLuongDTO.TongTienTruVaoLuong));
            _sqlParameter.Add(new SqlParameter("@LuongThucLanh", _tinhLuongDTO.LuongThucLanh));
            base.Procedure("TinhLuong_add", _sqlParameter);
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
