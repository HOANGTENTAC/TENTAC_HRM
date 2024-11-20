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
        public DataTable NhanVienGetByMaChamCong(string ma_cham_cong)
        {
            List<SqlParameter> _sqlParameter = new List<SqlParameter>();
            _sqlParameter.Add(new SqlParameter("@MaChamCong", ma_cham_cong));
            return executeNonQuerya("nhanvien_getbymachamcong", _sqlParameter);
        }
        public DataTable getNhanVienCoTrongCSDL()
        {
            List<SqlParameter> _sqlParameter = new List<SqlParameter>();
            DataTable tb = new DataTable();
            return executeNonQuerya("NHANVIEN_getall_1", _sqlParameter);
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
            string sql = "select * from  MITACOSQL.dbo.[NhanVien] " +
                $"where (MITACOSQL.dbo.[NhanVien].MaCongTy = '{_nhanVienDTO.MaCongTy}') " +
                $"or (MITACOSQL.dbo.[NhanVien].MaKhuVuc = '{_nhanVienDTO.MaKhuVuc}') " +
                $"or (MITACOSQL.dbo.[NhanVien].MaPhongBan = '{_nhanVienDTO.MaPhongBan}') " +
                $"or (MITACOSQL.dbo.[NhanVien].MaChucVu = '{_nhanVienDTO.MaChucVu}')  ";
            return SQLHelper.ExecuteDt(sql);
        }        
        public DataTable NhanVienSearch(NhanVienDTO _nhanVienDTO)
        {
            string sql = "select * " +
                "from  MITACOSQL.dbo.[NHANVIEN] " +
                $"where (TenNhanVien like '%{_nhanVienDTO.TenNhanVien}%' or MaNhanVien like '%{_nhanVienDTO.MaNhanVien}%'  ) and MaPhongBan is not null";
            return SQLHelper.ExecuteDt(sql);
        }
    }
}
