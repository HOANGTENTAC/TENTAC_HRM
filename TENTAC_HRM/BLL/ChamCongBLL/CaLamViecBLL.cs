using System.Data;
using TENTAC_HRM.Common;
using TENTAC_HRM.Models.ChamCongModel;

namespace TENTAC_HRM.BLL.BLL.ChamCongBLL
{
    internal class CaLamViecBLL : Provider
    {
        public DataTable getMaByTenCaLamViec(string CaLamViec)
        {
            return SQLHelper.ExecuteDt($"select * from MITACOSQL.dbo.[CaLamViecNew] where CaLamViec = '{CaLamViec}'");
        }

        public DataTable CaLamViecGetByMaCaLamViec(string MaCaLamViec)
        {
            return SQLHelper.ExecuteDt($"select * from MITACOSQL.dbo.[CaLamViecNew] where MaCaLamViec = '{MaCaLamViec}'");
        }

        public DataTable getCaLamViec()
        {
            return SQLHelper.ExecuteDt("select MaCaLamViec,CaLamViec,GioVaoLamViec,GioKetThucLamViec from MITACOSQL.dbo.[CaLamViecNew]");
        }

        public void InsertCaLamViec(CaLamViecModel _caLamViecDTO)
        {
            string sql = $@"insert into MITACOSQL.dbo.[CaLamViecNew](MaCaLamViec,CaLamViec,GioVaoLamViec,GioKetThucLamViec,GioBatDauNghiTrua,
	                            GioKetThucNghiTrua,TongGioNghiTrua,TongGioTrongCaLamViec,CongTinh,BatDauVao,KetThucVao,BatDauRa,KetThucRa,
	                            KhongCoGioRa,KhongCoGioVao,XemCaDem,TinhBuTru,TruGioDiTre,TruGioVeSom,ChoPhepDiTre,BatDauTinhDiTre,
	                            ChoPhepVeSom,BatDauTinhVeSom,XemCaNayLaTangCa,TangCaMuc,XemCuoiTuanLaTangCa,TangCaCuoiTuanMuc,XemNgayLeLaTangCa,
	                            TangCaNgayLeMuc,TangCaTruocGioLamViec,SoPhutTangCaTruocGioLamViec,TangCaSauGioLamViec,
	                            SoPhutTangCaSauGioLamViec,TongGioLamDatDen,SoPhutTongGioLamDatDen,TangCaTruocGioLamViecDatDen,
	                            PhutTruTangCaTruoc,TangCaSauGioLamViecDatDen,PhutTruTangCaSau,GioiHanTangCa1,
	                            GioiHanTangCa2,GioiHanTangCa3,GioiHanTangCa4)
                            values('{_caLamViecDTO.MaCaLamViec}','{_caLamViecDTO.CaLamViec}','{_caLamViecDTO.GioVaoLamViec}','{_caLamViecDTO.GioKetThucLamViec}',
                                '{_caLamViecDTO.GioBatDauNghiTrua}','{_caLamViecDTO.GioKetThucNghiTrua}','{_caLamViecDTO.TongGioNghiTrua}','{_caLamViecDTO.TongGioTrongCaLamViec}',
                                '{_caLamViecDTO.CongTinh}','{_caLamViecDTO.BatDauVao}','{_caLamViecDTO.KetThucVao}','{_caLamViecDTO.BatDauRa}',
                                '{_caLamViecDTO.KetThucRa}','{_caLamViecDTO.KhongCoGioRa}','{_caLamViecDTO.KhongCoGioVao}','{_caLamViecDTO.XemCaDem}',
                                '{_caLamViecDTO.TinhBuTru}','{_caLamViecDTO.TruGioDiTre}','{_caLamViecDTO.TruGioVeSom}','{_caLamViecDTO.ChoPhepDiTre}',
                                '{_caLamViecDTO.BatDauTinhDiTre}','{_caLamViecDTO.ChoPhepVeSom}','{_caLamViecDTO.BatDauTinhVeSom}','{_caLamViecDTO.XemCaNayLaTangCa}',
                                '{_caLamViecDTO.TangCaMuc}','{_caLamViecDTO.XemCuoiTuanLaTangCa}','{_caLamViecDTO.TangCaCuoiTuanMuc}','{_caLamViecDTO.XemNgayLeLaTangCa}',
                                '{_caLamViecDTO.TangCaNgayLeMuc}','{_caLamViecDTO.TangCaTruocGioLamViec}','{_caLamViecDTO.SoPhutTangCaTruocGioLamViec}','{_caLamViecDTO.TangCaSauGioLamViec}',
                                '{_caLamViecDTO.SoPhutTangCaSauGioLamViec}','{_caLamViecDTO.TongGioLamDatDen}','{_caLamViecDTO.SoPhutTongGioLamDatDen}','{_caLamViecDTO.TangCaTruocGioLamViecDatDen}',
                                '{_caLamViecDTO.PhutTruTangCaTruoc}','{_caLamViecDTO.TangCaSauGioLamViecDatDen}','{_caLamViecDTO.PhutTruTangCaSau}','{_caLamViecDTO.GioiHanTangCa1}',
                                '{_caLamViecDTO.GioiHanTangCa2}','{_caLamViecDTO.GioiHanTangCa3}','{_caLamViecDTO.GioiHanTangCa4}')";
            SQLHelper.ExecuteSql(sql);
        }
        public void UpdateCaLamViec(CaLamViecModel _caLamViecDTO)
        {
            string sql = $@"update MITACOSQL.dbo.[CaLamViecNew] set MaCaLamViec='{_caLamViecDTO.MaCaLamViec}',CaLamViec='{_caLamViecDTO.CaLamViec}',GioVaoLamViec='{_caLamViecDTO.GioVaoLamViec}',
                            GioKetThucLamViec='{_caLamViecDTO.GioKetThucLamViec}',GioBatDauNghiTrua='{_caLamViecDTO.GioBatDauNghiTrua}',GioKetThucNghiTrua='{_caLamViecDTO.GioKetThucNghiTrua}',
                            TongGioNghiTrua='{_caLamViecDTO.TongGioNghiTrua}',TongGioTrongCaLamViec='{_caLamViecDTO.TongGioTrongCaLamViec}',CongTinh='{_caLamViecDTO.CongTinh}',
                            BatDauVao='{_caLamViecDTO.BatDauVao}',KetThucVao='{_caLamViecDTO.KetThucVao}',BatDauRa='{_caLamViecDTO.BatDauRa}',KetThucRa='{_caLamViecDTO.KetThucRa}',
                            KhongCoGioRa='{_caLamViecDTO.KhongCoGioRa}',KhongCoGioVao='{_caLamViecDTO.KhongCoGioVao}',XemCaDem='{_caLamViecDTO.XemCaDem}',TinhBuTru='{_caLamViecDTO.TinhBuTru}',
                            TruGioDiTre='{_caLamViecDTO.TruGioDiTre}',TruGioVeSom='{_caLamViecDTO.TruGioVeSom}',ChoPhepDiTre='{_caLamViecDTO.ChoPhepDiTre}',BatDauTinhDiTre='{_caLamViecDTO.BatDauTinhDiTre}',
                            ChoPhepVeSom='{_caLamViecDTO.ChoPhepVeSom}',BatDauTinhVeSom='{_caLamViecDTO.BatDauTinhVeSom}',XemCaNayLaTangCa='{_caLamViecDTO.XemCaNayLaTangCa}',
                            TangCaMuc='{_caLamViecDTO.TangCaMuc}',XemCuoiTuanLaTangCa='{_caLamViecDTO.XemCuoiTuanLaTangCa}',TangCaCuoiTuanMuc='{_caLamViecDTO.TangCaCuoiTuanMuc}',
                            XemNgayLeLaTangCa='{_caLamViecDTO.XemNgayLeLaTangCa}',TangCaNgayLeMuc='{_caLamViecDTO.TangCaNgayLeMuc}',TangCaTruocGioLamViec='{_caLamViecDTO.TangCaTruocGioLamViec}',
                            SoPhutTangCaTruocGioLamViec='{_caLamViecDTO.SoPhutTangCaTruocGioLamViec}',TangCaSauGioLamViec='{_caLamViecDTO.TangCaSauGioLamViec}',
                            SoPhutTangCaSauGioLamViec='{_caLamViecDTO.SoPhutTangCaSauGioLamViec}',TongGioLamDatDen='{_caLamViecDTO.TongGioLamDatDen}',
                            SoPhutTongGioLamDatDen='{_caLamViecDTO.SoPhutTongGioLamDatDen}',TangCaTruocGioLamViecDatDen='{_caLamViecDTO.TangCaTruocGioLamViecDatDen}',
                            PhutTruTangCaTruoc='{_caLamViecDTO.PhutTruTangCaTruoc}',TangCaSauGioLamViecDatDen='{_caLamViecDTO.TangCaSauGioLamViecDatDen}',
                            PhutTruTangCaSau='{_caLamViecDTO.PhutTruTangCaSau}',GioiHanTangCa1='{_caLamViecDTO.GioiHanTangCa1}',GioiHanTangCa2='{_caLamViecDTO.GioiHanTangCa2}',
                            GioiHanTangCa3='{_caLamViecDTO.GioiHanTangCa3}',GioiHanTangCa4='{_caLamViecDTO.GioiHanTangCa4}'
                            where MaCaLamViec = '{_caLamViecDTO.MaCaLamViec}'";
            SQLHelper.ExecuteSql(sql);
        }
        public void DeleteCaLamViec(string MaCaLamViec)
        {
            SQLHelper.ExecuteSql($"delete MITACOSQL.dbo.[CaLamViecNew] where MaCaLamViec = '{MaCaLamViec}'");
        }
    }
}
