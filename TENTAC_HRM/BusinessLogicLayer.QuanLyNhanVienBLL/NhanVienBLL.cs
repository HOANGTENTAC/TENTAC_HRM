using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using TENTAC_HRM.Common;
using TENTAC_HRM.DataTransferObject.QuanLyNhanVienDTO;
using TENTAC_HRM.Model;

namespace TENTAC_HRM.BusinessLogicLayer.QuanLyNhanVienBLL
{
    internal class NhanVienBLL : Provider
    {
        public DataTable NhanVienGetByMaChamCong(string machamcong)
        {
            return SQLHelper.ExecuteDt($"select * from MITACOSQL.dbo.[NHANVIEN] where ('{machamcong}'= dbo.[NHANVIEN].MaChamCong)");
        }
        public DataTable getNhanVienCoTrongCSDL()
        {
            return SQLHelper.ExecuteDt("SELECT MaNhanVien,TenNhanVien,MaChamCong,TenChamCong,MaThe FROM MITACOSQL.dbo.[NHANVIEN]");
        }
        public DataTable GetAllNhanVien()
        {
            return SQLHelper.ExecuteDt("select * from hrm_nhan_vien");
        }
        public DataTable TaiNhanVienLenMayChamCong()
        {
            string sql = "SELECT manhanvien,hoten,machamcong,tenchamcong,mathe FROM dbo.tbl_NhanVien";
            return SQLHelper.ExecuteDt(sql);
        }
        public DataTable NhanVienSearchTaiNhanVienLenMCC(Nhanvien_model model)
        {
            string sql = "select manhanvien,hoten,machamcong,tenchamcong,mathe " +
                "from  dbo.tbl_NhanVien " +
                "where hoten like '%"+model.Ma_so_value +"%' or manhanvien like '%"+model.Ho_ten_value +"%'";
            return SQLHelper.ExecuteDt(sql);
        }
        public void Insert_NhanVienFromDevice(Nhanvien_model _nhanVienDTO)
        {
            List<SqlParameter> _sqlParameter = new List<SqlParameter>();
            _sqlParameter.Add(new SqlParameter("@MaNhanVien", _nhanVienDTO.Ma_so_value));
            _sqlParameter.Add(new SqlParameter("@TenNhanVien", _nhanVienDTO.Ten_value));
            _sqlParameter.Add(new SqlParameter("@HoTen", _nhanVienDTO.Ho_ten_value));
            _sqlParameter.Add(new SqlParameter("@HoLot", _nhanVienDTO.Ho_lot_value));
            _sqlParameter.Add(new SqlParameter("@MaChamCong", _nhanVienDTO.Ma_Cham_Cong));
            _sqlParameter.Add(new SqlParameter("@TenChamCong", _nhanVienDTO.Ten_Cham_Cong));
            _sqlParameter.Add(new SqlParameter("@MaThe", _nhanVienDTO.Ma_The));
            _sqlParameter.Add(new SqlParameter("@GioiTinh", _nhanVienDTO.Gioi_tinh_value));
            _sqlParameter.Add(new SqlParameter("@NgaySinh", _nhanVienDTO.Ngay_sinh_value));
            _sqlParameter.Add(new SqlParameter("@CCCD", _nhanVienDTO.Cccd_value));
            _sqlParameter.Add(new SqlParameter("@DienThoaiDD", _nhanVienDTO.Sdt_value));
            _sqlParameter.Add(new SqlParameter("@Email", _nhanVienDTO.Email_value));
            Procedure("nhanvien_add_tumaychamcong", _sqlParameter);
        }
        public DataTable NhanViengetFromTreeview(NhanVienDTO _nhanVienDTO)
        {
            string sql = $@"select * from  MITACOSQL.dbo.[NhanVien] 
                where (MITACOSQL.dbo.[NhanVien].MaCongTy = '{_nhanVienDTO.MaCongTy}') 
                or (MITACOSQL.dbo.[NhanVien].MaKhuVuc = '{_nhanVienDTO.MaKhuVuc}') 
                or (MITACOSQL.dbo.[NhanVien].MaPhongBan = '{_nhanVienDTO.MaPhongBan}')
                or (MITACOSQL.dbo.[NhanVien].MaChucVu = '{_nhanVienDTO.MaChucVu}') ";
            return SQLHelper.ExecuteDt(sql);
        }        
        public DataTable NhanVienSearch(NhanVienDTO _nhanVienDTO)
        {
            string sql = "select * " +
                "from  MITACOSQL.dbo.[NHANVIEN] " +
                $"where (TenNhanVien like '%{_nhanVienDTO.TenNhanVien}%' or MaNhanVien like '%{_nhanVienDTO.MaNhanVien}%'  ) and MaPhongBan is not null";
            return SQLHelper.ExecuteDt(sql);
        }
        public void InsertNhanVienFromDevice(NhanVienDTO _nhanVienDTO)
        {
            List<SqlParameter> _sqlParameter = new List<SqlParameter>();
            _sqlParameter.Add(new SqlParameter("@MaNhanVien", _nhanVienDTO.MaNhanVien));
            _sqlParameter.Add(new SqlParameter("@TenNhanVien", _nhanVienDTO.TenNhanVien));
            _sqlParameter.Add(new SqlParameter("@MaChamCong", _nhanVienDTO.MaChamCong));
            _sqlParameter.Add(new SqlParameter("@TenChamCong", _nhanVienDTO.TenChamCong));
            _sqlParameter.Add(new SqlParameter("@MaThe", _nhanVienDTO.MaThe));
            _sqlParameter.Add(new SqlParameter("@UserPassWord", _nhanVienDTO.UserPassWord));
            _sqlParameter.Add(new SqlParameter("@PhanQuyen", _nhanVienDTO.PhanQuyen));
            _sqlParameter.Add(new SqlParameter("@UserEnable", _nhanVienDTO.UserEnable));
            _sqlParameter.Add(new SqlParameter("@GioiTinh", _nhanVienDTO.GioiTinh));
            _sqlParameter.Add(new SqlParameter("@NgayVaoLamViec", _nhanVienDTO.NgayVaoLamViec));
            _sqlParameter.Add(new SqlParameter("@ChucVu", _nhanVienDTO.ChucVu));
            _sqlParameter.Add(new SqlParameter("@NgaySinh", _nhanVienDTO.NgaySinh));
            _sqlParameter.Add(new SqlParameter("@NoiSinh", _nhanVienDTO.NoiSinh));
            _sqlParameter.Add(new SqlParameter("@ThoiHanHopDong", _nhanVienDTO.ThoiHanHopDong));
            _sqlParameter.Add(new SqlParameter("@LoaiNhanVien", _nhanVienDTO.LoaiNhanVien));
            _sqlParameter.Add(new SqlParameter("@CMND", _nhanVienDTO.CMND));
            _sqlParameter.Add(new SqlParameter("@DienThoaiLienHe", _nhanVienDTO.DienThoaiLienHe));
            _sqlParameter.Add(new SqlParameter("@Email", _nhanVienDTO.Email));
            _sqlParameter.Add(new SqlParameter("@NgayPhep", _nhanVienDTO.NgayPhep));
            _sqlParameter.Add(new SqlParameter("@TienLuong", _nhanVienDTO.TienLuong));
            _sqlParameter.Add(new SqlParameter("@LuongHopDong", _nhanVienDTO.LuongHopDong));
            _sqlParameter.Add(new SqlParameter("@DanToc", _nhanVienDTO.DanToc));
            _sqlParameter.Add(new SqlParameter("@QuocTich", _nhanVienDTO.QuocTich));
            _sqlParameter.Add(new SqlParameter("@Skype", _nhanVienDTO.Skype));
            _sqlParameter.Add(new SqlParameter("@Yahoo", _nhanVienDTO.Yahoo));
            _sqlParameter.Add(new SqlParameter("@Facebook", _nhanVienDTO.Facebook));
            _sqlParameter.Add(new SqlParameter("@PassWord", _nhanVienDTO.PassWord));
            _sqlParameter.Add(new SqlParameter("@DangThamGiaBaoHiem", _nhanVienDTO.DangThamGiaBaoHiem));
            _sqlParameter.Add(new SqlParameter("@NghiViecTamThoi", _nhanVienDTO.NghiViecTamThoi));
            _sqlParameter.Add(new SqlParameter("@TinhLuongTheo", _nhanVienDTO.TinhLuongTheo));
            _sqlParameter.Add(new SqlParameter("@SanPhamOrCongDoan", _nhanVienDTO.SanPhamOrCongDoan));
            _sqlParameter.Add(new SqlParameter("@NhanVienMoi", _nhanVienDTO.NhanVienMoi));
            Procedure("NHANVIEN_add_TuMayChamCong", _sqlParameter);
        }
        public void NhanVienUpdateToanBoNhanVien(NhanVienDTO _nhanVienDTO)
        {
            List<SqlParameter> _sqlParameter = new List<SqlParameter>();
            _sqlParameter.Add(new SqlParameter("@MaChamCong", _nhanVienDTO.MaChamCong));
            _sqlParameter.Add(new SqlParameter("@MaThe", _nhanVienDTO.MaThe));
            _sqlParameter.Add(new SqlParameter("@UserPassWord", _nhanVienDTO.UserPassWord));
            _sqlParameter.Add(new SqlParameter("@PhanQuyen", _nhanVienDTO.PhanQuyen));
            Procedure("NHANVIEN_updateToanBoNhanVien", _sqlParameter);
        }
        public DataTable NhanVienSearchTinhCong(string search)
        {
            return SQLHelper.ExecuteDt($"select * from MITACOSQL.dbo.[NHANVIEN] where TenNhanVien like '%{search}%' or MaNhanVien like '%{search}%'");
        }
    }
}
