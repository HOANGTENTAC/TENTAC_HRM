using System;

namespace TENTAC_HRM.Models.ChamCongModel
{
    internal class NgayLeModel
    {
        private string _MaNgayLe;

        private int _Thang;

        private int _Nam;

        private DateTime _Ngay;

        private string _TenNgayLe;

        private float _CongTinh;

        private float _Gio;

        private string _GhiChu;

        private float _HeSo;

        private bool _XacNhan;

        public string MaNgayLe
        {
            get
            {
                return this._MaNgayLe;
            }
            set
            {
                this._MaNgayLe = value;
            }
        }

        public int Thang
        {
            get
            {
                return this._Thang;
            }
            set
            {
                this._Thang = value;
            }
        }

        public int Nam
        {
            get
            {
                return this._Nam;
            }
            set
            {
                this._Nam = value;
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

        public string TenNgayLe
        {
            get
            {
                return this._TenNgayLe;
            }
            set
            {
                this._TenNgayLe = value;
            }
        }

        public float CongTinh
        {
            get
            {
                return this._CongTinh;
            }
            set
            {
                this._CongTinh = value;
            }
        }

        public float Gio
        {
            get
            {
                return this._Gio;
            }
            set
            {
                this._Gio = value;
            }
        }

        public string GhiChu
        {
            get
            {
                return this._GhiChu;
            }
            set
            {
                this._GhiChu = value;
            }
        }

        public float HeSo
        {
            get
            {
                return this._HeSo;
            }
            set
            {
                this._HeSo = value;
            }
        }

        public bool XacNhan
        {
            get
            {
                return this._XacNhan;
            }
            set
            {
                this._XacNhan = value;
            }
        }
    }
}
