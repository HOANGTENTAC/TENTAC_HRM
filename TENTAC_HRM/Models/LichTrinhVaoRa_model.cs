using System;

namespace TENTAC_HRM.Model
{
    internal class LichTrinhVaoRa_model
    {
        private string _MaLichTrinhVaoRa;

        private string _TenLichTrinhVaoRa;

        private int _ChonLichTrinhVaoRa;

        private bool _MotLanChamCong;

        private bool _LoaiBoGio;

        private DateTime _TuGio;

        private DateTime _DenGio;

        private int _ThoiGianNhoNhat;

        private int _ThoiGianLonNhat;

        private int _KhoangCachGiuaHaiCapVaoRa;

        public string MaLichTrinhVaoRa
        {
            get
            {
                return _MaLichTrinhVaoRa;
            }
            set
            {
                _MaLichTrinhVaoRa = value;
            }
        }

        public string TenLichTrinhVaoRa
        {
            get
            {
                return _TenLichTrinhVaoRa;
            }
            set
            {
                _TenLichTrinhVaoRa = value;
            }
        }

        public int ChonLichTrinhVaoRa
        {
            get
            {
                return _ChonLichTrinhVaoRa;
            }
            set
            {
                _ChonLichTrinhVaoRa = value;
            }
        }

        public bool MotLanChamCong
        {
            get
            {
                return _MotLanChamCong;
            }
            set
            {
                _MotLanChamCong = value;
            }
        }

        public bool LoaiBoGio
        {
            get
            {
                return _LoaiBoGio;
            }
            set
            {
                _LoaiBoGio = value;
            }
        }

        public DateTime TuGio
        {
            get
            {
                return _TuGio;
            }
            set
            {
                _TuGio = value;
            }
        }

        public DateTime DenGio
        {
            get
            {
                return _DenGio;
            }
            set
            {
                _DenGio = value;
            }
        }

        public int ThoiGianNhoNhat
        {
            get
            {
                return _ThoiGianNhoNhat;
            }
            set
            {
                _ThoiGianNhoNhat = value;
            }
        }

        public int ThoiGianLonNhat
        {
            get
            {
                return _ThoiGianLonNhat;
            }
            set
            {
                _ThoiGianLonNhat = value;
            }
        }

        public int KhoangCachGiuaHaiCapVaoRa
        {
            get
            {
                return _KhoangCachGiuaHaiCapVaoRa;
            }
            set
            {
                _KhoangCachGiuaHaiCapVaoRa = value;
            }
        }

        public LichTrinhVaoRa_model()
        {
        }

        public LichTrinhVaoRa_model(string _MaLichTrinhVaoRa, string _TenLichTrinhVaoRa, int _ChonLichTrinhVaoRa, bool _MotLanChamCong, bool _LoaiBoGio, DateTime _TuGio, DateTime _DenGio, int _ThoiGianNhoNhat, int _ThoiGianLonNhat, int _KhoangCachGiuaHaiCapVaoRa)
        {
            MaLichTrinhVaoRa = _MaLichTrinhVaoRa;
            TenLichTrinhVaoRa = _TenLichTrinhVaoRa;
            ChonLichTrinhVaoRa = _ChonLichTrinhVaoRa;
            MotLanChamCong = _MotLanChamCong;
            LoaiBoGio = _LoaiBoGio;
            TuGio = _TuGio;
            DenGio = _DenGio;
            ThoiGianNhoNhat = _ThoiGianNhoNhat;
            ThoiGianLonNhat = _ThoiGianLonNhat;
            KhoangCachGiuaHaiCapVaoRa = _KhoangCachGiuaHaiCapVaoRa;
        }
    }
}
