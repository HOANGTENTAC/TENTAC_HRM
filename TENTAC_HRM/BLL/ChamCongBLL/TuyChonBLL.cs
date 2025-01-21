using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using TENTAC_HRM.Models;

namespace TENTAC_HRM.BLL.ChamCongBLL
{
    internal class TuyChonBLL
    {
        public void THEMTUYCHON(TuyChonModel _tuyChonDTO)
        {
            List<SqlParameter> _sqlParameter = new List<SqlParameter>();
            _sqlParameter.Add(new SqlParameter("@MaTuyChinh", _tuyChonDTO.MaTuyChinh));
            _sqlParameter.Add(new SqlParameter("@ChuNhatHeSo", _tuyChonDTO.ChuNhatHeSo));
            _sqlParameter.Add(new SqlParameter("@ThuBayHeSo", _tuyChonDTO.ThuBayHeSo));
            _sqlParameter.Add(new SqlParameter("@NgayLeHeSo", _tuyChonDTO.NgayLeHeSo));
            _sqlParameter.Add(new SqlParameter("@CaDemHeSo", _tuyChonDTO.CaDemHeSo));
            _sqlParameter.Add(new SqlParameter("@TC1HeSo", _tuyChonDTO.TC1HeSo));
            _sqlParameter.Add(new SqlParameter("@TC2HeSo", _tuyChonDTO.TC2HeSo));
            _sqlParameter.Add(new SqlParameter("@TC3HeSo", _tuyChonDTO.TC3HeSo));
            _sqlParameter.Add(new SqlParameter("@TC4HeSo", _tuyChonDTO.TC4HeSo));
            _sqlParameter.Add(new SqlParameter("@GiamDoc", _tuyChonDTO.GiamDoc));
            _sqlParameter.Add(new SqlParameter("@KeToanTruong", _tuyChonDTO.KeToanTruong));
            _sqlParameter.Add(new SqlParameter("@ThuQuy", _tuyChonDTO.ThuQuy));
            _sqlParameter.Add(new SqlParameter("@NguoiLapPhieu", _tuyChonDTO.NguoiLapPhieu));
            _sqlParameter.Add(new SqlParameter("@SoTien", _tuyChonDTO.SoTien));
            _sqlParameter.Add(new SqlParameter("@SoQuyetDinh", _tuyChonDTO.SoQuyetDinh));
            _sqlParameter.Add(new SqlParameter("@NgayApDung", _tuyChonDTO.NgayApDung));
            _sqlParameter.Add(new SqlParameter("@NguoiRaQuyetDinh", _tuyChonDTO.NguoiRaQuyetDinh));
            _sqlParameter.Add(new SqlParameter("@LTTuA", _tuyChonDTO.LTTuA));
            _sqlParameter.Add(new SqlParameter("@LTDenA", _tuyChonDTO.LTDenA));
            _sqlParameter.Add(new SqlParameter("@LTA", _tuyChonDTO.LTA));
            _sqlParameter.Add(new SqlParameter("@LTTuB", _tuyChonDTO.LTTuB));
            _sqlParameter.Add(new SqlParameter("@LTDenB", _tuyChonDTO.LTDenB));
            _sqlParameter.Add(new SqlParameter("@LTB", _tuyChonDTO.LTB));
            _sqlParameter.Add(new SqlParameter("@LTTuC", _tuyChonDTO.LTTuC));
            _sqlParameter.Add(new SqlParameter("@LTDenC", _tuyChonDTO.LTDenC));
            _sqlParameter.Add(new SqlParameter("@LTC", _tuyChonDTO.LTC));
            _sqlParameter.Add(new SqlParameter("@LTTuD", _tuyChonDTO.LTTuD));
            _sqlParameter.Add(new SqlParameter("@LTDenD", _tuyChonDTO.LTDenD));
            _sqlParameter.Add(new SqlParameter("@LTD", _tuyChonDTO.LTD));
            _sqlParameter.Add(new SqlParameter("@LamTronCong", _tuyChonDTO.LamTronCong));
            _sqlParameter.Add(new SqlParameter("@LamTronGio", _tuyChonDTO.LamTronGio));
            _sqlParameter.Add(new SqlParameter("@BaoHiemXaHoi", _tuyChonDTO.BaoHiemXaHoi));
            _sqlParameter.Add(new SqlParameter("@BaoHiemYTe", _tuyChonDTO.BaoHiemYTe));
            _sqlParameter.Add(new SqlParameter("@BaoHiemThatNghiep", _tuyChonDTO.BaoHiemThatNghiep));
            _sqlParameter.Add(new SqlParameter("@LuaChonKhaiBaoLuong", _tuyChonDTO.LuaChonKhaiBaoLuong));
            _sqlParameter.Add(new SqlParameter("@SoTienKhaiBao", _tuyChonDTO.SoTienKhaiBao));
            _sqlParameter.Add(new SqlParameter("@TienTangCa", _tuyChonDTO.TienTangCa));
            _sqlParameter.Add(new SqlParameter("@TienTheoNgayCong", _tuyChonDTO.TienTheoNgayCong));
            _sqlParameter.Add(new SqlParameter("@TienTheoSanLuong", _tuyChonDTO.TienTheoSanLuong));
            _sqlParameter.Add(new SqlParameter("@TienSanLuong", _tuyChonDTO.TienSanLuong));
            _sqlParameter.Add(new SqlParameter("@TienCongDoan", _tuyChonDTO.TienCongDoan));
            _sqlParameter.Add(new SqlParameter("@DinhDangThoiGian", _tuyChonDTO.DinhDangThoiGian));
            _sqlParameter.Add(new SqlParameter("@ThongBaoHetHanHopDong", _tuyChonDTO.ThongBaoHetHanHopDong));
            SQLHelper.Procedure("TUYCHON_add", _sqlParameter);
        }

        public void CAPNHATTUYCHON(TuyChonModel _tuyChonDTO)
        {
            List<SqlParameter> _sqlParameter = new List<SqlParameter>();
            _sqlParameter.Add(new SqlParameter("@MaTuyChinh", _tuyChonDTO.MaTuyChinh));
            _sqlParameter.Add(new SqlParameter("@ChuNhatHeSo", _tuyChonDTO.ChuNhatHeSo));
            _sqlParameter.Add(new SqlParameter("@ThuBayHeSo", _tuyChonDTO.ThuBayHeSo));
            _sqlParameter.Add(new SqlParameter("@NgayLeHeSo", _tuyChonDTO.NgayLeHeSo));
            _sqlParameter.Add(new SqlParameter("@CaDemHeSo", _tuyChonDTO.CaDemHeSo));
            _sqlParameter.Add(new SqlParameter("@TC1HeSo", _tuyChonDTO.TC1HeSo));
            _sqlParameter.Add(new SqlParameter("@TC2HeSo", _tuyChonDTO.TC2HeSo));
            _sqlParameter.Add(new SqlParameter("@TC3HeSo", _tuyChonDTO.TC3HeSo));
            _sqlParameter.Add(new SqlParameter("@TC4HeSo", _tuyChonDTO.TC4HeSo));
            _sqlParameter.Add(new SqlParameter("@GiamDoc", _tuyChonDTO.GiamDoc));
            _sqlParameter.Add(new SqlParameter("@KeToanTruong", _tuyChonDTO.KeToanTruong));
            _sqlParameter.Add(new SqlParameter("@ThuQuy", _tuyChonDTO.ThuQuy));
            _sqlParameter.Add(new SqlParameter("@NguoiLapPhieu", _tuyChonDTO.NguoiLapPhieu));
            _sqlParameter.Add(new SqlParameter("@SoTien", _tuyChonDTO.SoTien));
            _sqlParameter.Add(new SqlParameter("@SoQuyetDinh", _tuyChonDTO.SoQuyetDinh));
            _sqlParameter.Add(new SqlParameter("@NgayApDung", _tuyChonDTO.NgayApDung));
            _sqlParameter.Add(new SqlParameter("@NguoiRaQuyetDinh", _tuyChonDTO.NguoiRaQuyetDinh));
            _sqlParameter.Add(new SqlParameter("@LTTuA", _tuyChonDTO.LTTuA));
            _sqlParameter.Add(new SqlParameter("@LTDenA", _tuyChonDTO.LTDenA));
            _sqlParameter.Add(new SqlParameter("@LTA", _tuyChonDTO.LTA));
            _sqlParameter.Add(new SqlParameter("@LTTuB", _tuyChonDTO.LTTuB));
            _sqlParameter.Add(new SqlParameter("@LTDenB", _tuyChonDTO.LTDenB));
            _sqlParameter.Add(new SqlParameter("@LTB", _tuyChonDTO.LTB));
            _sqlParameter.Add(new SqlParameter("@LTTuC", _tuyChonDTO.LTTuC));
            _sqlParameter.Add(new SqlParameter("@LTDenC", _tuyChonDTO.LTDenC));
            _sqlParameter.Add(new SqlParameter("@LTC", _tuyChonDTO.LTC));
            _sqlParameter.Add(new SqlParameter("@LTTuD", _tuyChonDTO.LTTuD));
            _sqlParameter.Add(new SqlParameter("@LTDenD", _tuyChonDTO.LTDenD));
            _sqlParameter.Add(new SqlParameter("@LTD", _tuyChonDTO.LTD));
            _sqlParameter.Add(new SqlParameter("@LamTronCong", _tuyChonDTO.LamTronCong));
            _sqlParameter.Add(new SqlParameter("@LamTronGio", _tuyChonDTO.LamTronGio));
            _sqlParameter.Add(new SqlParameter("@BaoHiemXaHoi", _tuyChonDTO.BaoHiemXaHoi));
            _sqlParameter.Add(new SqlParameter("@BaoHiemYTe", _tuyChonDTO.BaoHiemYTe));
            _sqlParameter.Add(new SqlParameter("@BaoHiemThatNghiep", _tuyChonDTO.BaoHiemThatNghiep));
            _sqlParameter.Add(new SqlParameter("@LuaChonKhaiBaoLuong", _tuyChonDTO.LuaChonKhaiBaoLuong));
            _sqlParameter.Add(new SqlParameter("@SoTienKhaiBao", _tuyChonDTO.SoTienKhaiBao));
            _sqlParameter.Add(new SqlParameter("@TienTangCa", _tuyChonDTO.TienTangCa));
            _sqlParameter.Add(new SqlParameter("@TienTheoNgayCong", _tuyChonDTO.TienTheoNgayCong));
            _sqlParameter.Add(new SqlParameter("@TienTheoSanLuong", _tuyChonDTO.TienTheoSanLuong));
            _sqlParameter.Add(new SqlParameter("@TienSanLuong", _tuyChonDTO.TienSanLuong));
            _sqlParameter.Add(new SqlParameter("@TienCongDoan", _tuyChonDTO.TienCongDoan));
            _sqlParameter.Add(new SqlParameter("@DinhDangThoiGian", _tuyChonDTO.DinhDangThoiGian));
            _sqlParameter.Add(new SqlParameter("@ThongBaoHetHanHopDong", _tuyChonDTO.ThongBaoHetHanHopDong));
            SQLHelper.Procedure("TUYCHON_update", _sqlParameter);

            //NhatKyDTO _nhatKyDTO = new NhatKyDTO(frmClassico.MaNguoiDung, DateTime.Now.ToString(), "Tùy chọn", "Cập nhật", DateTime.Now.ToString());
            //_nguoiDungBLL.SetSystemLog(_nhatKyDTO);
        }

        public DataTable showThongTinTuyChon()
        {
            return SQLHelper.ExecuteDt("select * MITACOSQL.from dbo.tuychon");
        }

        public DataTable showLoadTuyChon(string matuychinh)
        {
            //NhatKyDTO _nhatKyDTO = new NhatKyDTO(frmClassico.MaNguoiDung, DateTime.Now.ToString(), "Tùy chọn", "Xem", DateTime.Now.ToString());
            //_nguoiDungBLL.SetSystemLog(_nhatKyDTO);
            string sql = "select * from MITACOSQL.dbo.[tuychon] where MaTuyChinh = '" + matuychinh + "'";
            return SQLHelper.ExecuteDt(sql);
        }
    }
}
