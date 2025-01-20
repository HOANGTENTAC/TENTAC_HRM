using System;

namespace TENTAC_HRM.Models.BaoBieuModel
{
    internal class ChiTietPhuCapNhanVienModel
    {
        private int _IDChiTietPhuCap;

        private int _MaChamCong;

        private string _MaPhuCap;

        private string _TenPhuCap;

        private string _SoTien;

        private DateTime _Ngay;

        private string _KyHieuPhuCap;

        public int IDChiTietPhuCap
        {
            get
            {
                return this._IDChiTietPhuCap;
            }
            set
            {
                this._IDChiTietPhuCap = value;
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

        public string MaPhuCap
        {
            get
            {
                return this._MaPhuCap;
            }
            set
            {
                this._MaPhuCap = value;
            }
        }

        public string TenPhuCap
        {
            get
            {
                return this._TenPhuCap;
            }
            set
            {
                this._TenPhuCap = value;
            }
        }

        public string SoTien
        {
            get
            {
                return this._SoTien;
            }
            set
            {
                this._SoTien = value;
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

        public string KyHieuPhuCap
        {
            get
            {
                return this._KyHieuPhuCap;
            }
            set
            {
                this._KyHieuPhuCap = value;
            }
        }
    }
}
