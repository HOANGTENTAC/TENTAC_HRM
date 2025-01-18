using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TENTAC_HRM.BaoBieuModel;
using TENTAC_HRM.Common;

namespace TENTAC_HRM.BusinessLogicLayer.BaoBieuBLL
{
    internal class TinhCongBLL : Provider
    {
        public void TinhCongInsert(TinhCongModel _tinhCongDTO)
        {
            List<SqlParameter> _sqlParameter;
            _sqlParameter = new List<SqlParameter>();
            _sqlParameter.Add(new SqlParameter("@MaNhanVien", _tinhCongDTO.MaNhanVien));
            _sqlParameter.Add(new SqlParameter("@TenNhanVien", _tinhCongDTO.TenNhanVien));
            _sqlParameter.Add(new SqlParameter("@MaChamCong", _tinhCongDTO.MaChamCong));
            _sqlParameter.Add(new SqlParameter("@Ngay", _tinhCongDTO.Ngay));
            _sqlParameter.Add(new SqlParameter("@Thu", _tinhCongDTO.Thu));
            _sqlParameter.Add(new SqlParameter("@Ca", _tinhCongDTO.Ca));
            _sqlParameter.Add(new SqlParameter("@GioVao", _tinhCongDTO.GioVao));
            _sqlParameter.Add(new SqlParameter("@GioRa", _tinhCongDTO.GioRa));
            _sqlParameter.Add(new SqlParameter("@Cong", _tinhCongDTO.Cong));
            _sqlParameter.Add(new SqlParameter("@Gio", _tinhCongDTO.Gio));
            _sqlParameter.Add(new SqlParameter("@Tre", _tinhCongDTO.Tre));
            _sqlParameter.Add(new SqlParameter("@VeSom", _tinhCongDTO.VeSom));
            _sqlParameter.Add(new SqlParameter("@VeTre", _tinhCongDTO.VeTre));
            _sqlParameter.Add(new SqlParameter("@TC1", _tinhCongDTO.TC1));
            _sqlParameter.Add(new SqlParameter("@TC2", _tinhCongDTO.TC2));
            _sqlParameter.Add(new SqlParameter("@TC3", _tinhCongDTO.TC3));
            _sqlParameter.Add(new SqlParameter("@TC4", _tinhCongDTO.TC4));
            _sqlParameter.Add(new SqlParameter("@TongGio", _tinhCongDTO.TongGio));
            _sqlParameter.Add(new SqlParameter("@DemCong", _tinhCongDTO.DemCong));
            _sqlParameter.Add(new SqlParameter("@KyHieu", _tinhCongDTO.KyHieu));
            _sqlParameter.Add(new SqlParameter("@KyHieuPhu", _tinhCongDTO.KyHieuPhu));
            _sqlParameter.Add(new SqlParameter("@PhongBan", _tinhCongDTO.PhongBan));
            base.Procedure("TinhCong_add", _sqlParameter);
        }

        public void TinhCongDelete(TinhCongModel _tinhCongDTO)
        {
            base.Procedure("TinhCong_delete", new List<SqlParameter>());
        }

        public DataTable TinhCongGetAll(TinhCongModel _tinhCongDTO)
        {
            return base.executeNonQuerya("TinhCong_getall", new List<SqlParameter>());
        }

        public DataTable TinhCongGetByMaChamCong(TinhCongModel _tinhCongDTO)
        {
            List<SqlParameter> _sqlParameter;
            _sqlParameter = new List<SqlParameter>();
            _sqlParameter.Add(new SqlParameter("@MaChamCong", _tinhCongDTO.MaChamCong));
            return base.executeNonQuerya("TinhCong_getByMaChamCong", _sqlParameter);
        }

        public DataTable TinhCongGetByMaChamCongAndKyHieuPhu(TinhCongModel _tinhCongDTO)
        {
            List<SqlParameter> _sqlParameter;
            _sqlParameter = new List<SqlParameter>();
            _sqlParameter.Add(new SqlParameter("@MaChamCong", _tinhCongDTO.MaChamCong));
            _sqlParameter.Add(new SqlParameter("@KyHieuPhu", _tinhCongDTO.KyHieuPhu));
            return base.executeNonQuerya("TinhCong_getByMaChamCongAndKyHieuPhu", _sqlParameter);
        }

        public DataTable TinhCongGetByMaChamCongAndLe(TinhCongModel _tinhCongDTO)
        {
            List<SqlParameter> _sqlParameter;
            _sqlParameter = new List<SqlParameter>();
            _sqlParameter.Add(new SqlParameter("@MaChamCong", _tinhCongDTO.MaChamCong));
            _sqlParameter.Add(new SqlParameter("@KyHieu", _tinhCongDTO.KyHieu));
            return base.executeNonQuerya("TinhCong_getByMaChamCongAndLe", _sqlParameter);
        }

        public DataTable TinhCongGetNgayAndPhongBan(TinhCongModel _tinhCongDTO)
        {
            List<SqlParameter> _sqlParameter;
            _sqlParameter = new List<SqlParameter>();
            _sqlParameter.Add(new SqlParameter("@Ngay", _tinhCongDTO.Ngay));
            _sqlParameter.Add(new SqlParameter("@PhongBan", _tinhCongDTO.PhongBan));
            return base.executeNonQuerya("TinhCong_getByNgayAndPhongBan", _sqlParameter);
        }

        public DataTable TinhCongGetNgay(TinhCongModel _tinhCongDTO)
        {
            List<SqlParameter> _sqlParameter;
            _sqlParameter = new List<SqlParameter>();
            _sqlParameter.Add(new SqlParameter("@Ngay", _tinhCongDTO.Ngay));
            return base.executeNonQuerya("TinhCong_getByNgay", _sqlParameter);
        }

        public DataTable TinhCongGetMaChamCongAndNgay(TinhCongModel _tinhCongDTO)
        {
            List<SqlParameter> _sqlParameter;
            _sqlParameter = new List<SqlParameter>();
            _sqlParameter.Add(new SqlParameter("@MaChamCong", _tinhCongDTO.MaChamCong));
            _sqlParameter.Add(new SqlParameter("@Ngay", _tinhCongDTO.Ngay));
            return base.executeNonQuerya("TinhCong_getByMaChamCongAndNgay", _sqlParameter);
        }

        public DataTable TinhCongGetMaChamCongAndNgayChiTietTungNguoiTungNgay(TinhCongModel _tinhCongDTO)
        {
            List<SqlParameter> _sqlParameter;
            _sqlParameter = new List<SqlParameter>();
            _sqlParameter.Add(new SqlParameter("@MaChamCong", _tinhCongDTO.MaChamCong));
            _sqlParameter.Add(new SqlParameter("@Ngay", _tinhCongDTO.Ngay));
            return base.executeNonQuerya("TinhCong_getByMaChamCongAndNgayChiTietTungNguoiTungNgay", _sqlParameter);
        }

        public DataTable TinhCongGetMaChamCongAndNgayThongKeCong(TinhCongModel _tinhCongDTO)
        {
            List<SqlParameter> _sqlParameter;
            _sqlParameter = new List<SqlParameter>();
            _sqlParameter.Add(new SqlParameter("@MaChamCong", _tinhCongDTO.MaChamCong));
            _sqlParameter.Add(new SqlParameter("@Ngay", _tinhCongDTO.Ngay));
            return base.executeNonQuerya("TinhCong_getByMaChamCongAndNgayThongKeCong", _sqlParameter);
        }

        public DataTable TinhCongGetMaChamCongAndNgayChiTietThoiGian(TinhCongModel _tinhCongDTO)
        {
            List<SqlParameter> _sqlParameter;
            _sqlParameter = new List<SqlParameter>();
            _sqlParameter.Add(new SqlParameter("@MaChamCong", _tinhCongDTO.MaChamCong));
            _sqlParameter.Add(new SqlParameter("@Ngay", _tinhCongDTO.Ngay));
            return base.executeNonQuerya("TinhCong_getByMaChamCongAndNgayChiTietThoiGian", _sqlParameter);
        }

        public DataTable TinhCongGetMaChamCongAndNgayGioVaTC(TinhCongModel _tinhCongDTO)
        {
            List<SqlParameter> _sqlParameter;
            _sqlParameter = new List<SqlParameter>();
            _sqlParameter.Add(new SqlParameter("@MaChamCong", _tinhCongDTO.MaChamCong));
            _sqlParameter.Add(new SqlParameter("@Ngay", _tinhCongDTO.Ngay));
            return base.executeNonQuerya("TinhCong_getByMaChamCongAndNgayGioVaTC", _sqlParameter);
        }

        public DataTable TinhCongGetMaChamCongAndNgayThongKeGio(TinhCongModel _tinhCongDTO)
        {
            List<SqlParameter> _sqlParameter;
            _sqlParameter = new List<SqlParameter>();
            _sqlParameter.Add(new SqlParameter("@MaChamCong", _tinhCongDTO.MaChamCong));
            _sqlParameter.Add(new SqlParameter("@Ngay", _tinhCongDTO.Ngay));
            return base.executeNonQuerya("TinhCong_getByMaChamCongAndNgayThongKeGio", _sqlParameter);
        }
    }
}
