using System;

namespace TENTAC_HRM.DataTransferObject.MayChamCong
{
    internal class MayChamCongDTO
    {
        private string _MaMCC;

        private string _TenMCC;

        private int _IDMCC;

        private string _KieuKetNoi;

        private string _DiaChiIP;

        private int _Port;

        private int _CongCOM;

        private string _TocDoTruyen;

        private string _DiaChiWeb;

        private DateTime _NgayDangKyTenMien;

        private bool _SuDungWeb;

        private string _Serial;

        private string _SoDangKy;

        private bool _TrangThai;

        private string _TinhTrang;

        private int _TrangThaiMay;

        public string MaMCC
        {
            get
            {
                return _MaMCC;
            }
            set
            {
                _MaMCC = value;
            }
        }

        public string TenMCC
        {
            get
            {
                return _TenMCC;
            }
            set
            {
                _TenMCC = value;
            }
        }

        public int IDMCC
        {
            get
            {
                return _IDMCC;
            }
            set
            {
                _IDMCC = value;
            }
        }

        public string KieuKetNoi
        {
            get
            {
                return _KieuKetNoi;
            }
            set
            {
                _KieuKetNoi = value;
            }
        }

        public string DiaChiIP
        {
            get
            {
                return _DiaChiIP;
            }
            set
            {
                _DiaChiIP = value;
            }
        }

        public int Port
        {
            get
            {
                return _Port;
            }
            set
            {
                _Port = value;
            }
        }

        public int CongCOM
        {
            get
            {
                return _CongCOM;
            }
            set
            {
                _CongCOM = value;
            }
        }

        public string TocDoTruyen
        {
            get
            {
                return _TocDoTruyen;
            }
            set
            {
                _TocDoTruyen = value;
            }
        }

        public string DiaChiWeb
        {
            get
            {
                return _DiaChiWeb;
            }
            set
            {
                _DiaChiWeb = value;
            }
        }

        public DateTime NgayDangKyTenMien
        {
            get
            {
                return _NgayDangKyTenMien;
            }
            set
            {
                _NgayDangKyTenMien = value;
            }
        }

        public bool SuDungWeb
        {
            get
            {
                return _SuDungWeb;
            }
            set
            {
                _SuDungWeb = value;
            }
        }

        public string Serial
        {
            get
            {
                return _Serial;
            }
            set
            {
                _Serial = value;
            }
        }

        public string SoDangKy
        {
            get
            {
                return _SoDangKy;
            }
            set
            {
                _SoDangKy = value;
            }
        }

        public bool TrangThai
        {
            get
            {
                return _TrangThai;
            }
            set
            {
                _TrangThai = value;
            }
        }

        public string TinhTrang
        {
            get
            {
                return _TinhTrang;
            }
            set
            {
                _TinhTrang = value;
            }
        }

        public int TrangThaiMay
        {
            get
            {
                return _TrangThaiMay;
            }
            set
            {
                _TrangThaiMay = value;
            }
        }

        public MayChamCongDTO()
        {
        }

        public MayChamCongDTO(string _MaMCC, string _TenMCC, int _IDMCC, string _KieuKetNoi, string _DiaChiIP, int _Port, int _CongCOM, string _TocDoTruyen, string _DiaChiWeb, DateTime _NgayDangKyTenMien, bool _SuDungWeb, string _Serial, string _SoDangKy, bool _TrangThai, int _TrangThaiMay)
        {
            MaMCC = _MaMCC;
            TenMCC = _TenMCC;
            IDMCC = _IDMCC;
            KieuKetNoi = _KieuKetNoi;
            DiaChiIP = _DiaChiIP;
            Port = _Port;
            CongCOM = _CongCOM;
            TocDoTruyen = _TocDoTruyen;
            DiaChiWeb = _DiaChiWeb;
            NgayDangKyTenMien = _NgayDangKyTenMien;
            SuDungWeb = _SuDungWeb;
            Serial = _Serial;
            SoDangKy = _SoDangKy;
            TrangThai = _TrangThai;
            TrangThaiMay = _TrangThaiMay;
        }
    }
}
