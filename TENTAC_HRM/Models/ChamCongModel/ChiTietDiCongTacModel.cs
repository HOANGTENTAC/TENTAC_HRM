using System;

namespace TENTAC_HRM.Models.ChamCongModel
{
    internal class ChiTietDiCongTacModel
    {
        private int _ID;

        private string _MaNhanVien;

        private int _MaChamCong;

        private DateTime _Ngay;

        private DateTime _GioDi;

        private DateTime _GioVe;

        private decimal _TongGioCongTac;

        private decimal _CongTinhCongTac;

        private string _LyDo;

        public int ID
        {
            get
            {
                return this._ID;
            }
            set
            {
                this._ID = value;
            }
        }

        public string MaNhanVien
        {
            get
            {
                return this._MaNhanVien;
            }
            set
            {
                this._MaNhanVien = value;
            }
        }

        public int MaChamCong
        {
            get
            {
                return this._MaChamCong;
            }
            set
            {
                this._MaChamCong = value;
            }
        }

        public DateTime Ngay
        {
            get
            {
                return this._Ngay;
            }
            set
            {
                this._Ngay = value;
            }
        }

        public DateTime GioDi
        {
            get
            {
                return this._GioDi;
            }
            set
            {
                this._GioDi = value;
            }
        }

        public DateTime GioVe
        {
            get
            {
                return this._GioVe;
            }
            set
            {
                this._GioVe = value;
            }
        }

        public decimal TongGioCongTac
        {
            get
            {
                return this._TongGioCongTac;
            }
            set
            {
                this._TongGioCongTac = value;
            }
        }

        public decimal CongTinhCongTac
        {
            get
            {
                return this._CongTinhCongTac;
            }
            set
            {
                this._CongTinhCongTac = value;
            }
        }

        public string LyDo
        {
            get
            {
                return this._LyDo;
            }
            set
            {
                this._LyDo = value;
            }
        }
    }
}
