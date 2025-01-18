using System;

namespace TENTAC_HRM.BaoBieuModel
{
    internal class ViPhamModel
    {
        private int _IDViPham;

        private int _MaChamCong;

        private string _ViPham;

        private string _TienPhat;

        private DateTime _NgayThang;

        private int _Ngay;

        private int _Thang;

        private int _Nam;

        public int IDViPham
        {
            get
            {
                return this._IDViPham;
            }
            set
            {
                this._IDViPham = value;
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

        public string ViPham
        {
            get
            {
                return this._ViPham;
            }
            set
            {
                this._ViPham = value;
            }
        }

        public string TienPhat
        {
            get
            {
                return this._TienPhat;
            }
            set
            {
                this._TienPhat = value;
            }
        }

        public DateTime NgayThang
        {
            get
            {
                return this._NgayThang;
            }
            set
            {
                this._NgayThang = value;
            }
        }

        public int Ngay
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
    }
}
