using System;

namespace TENTAC_HRM.Models.ChamCongModel
{
    internal class PhepNamModel
    {
        private int _ID;

        private string _MaNhanVien;

        private string _TenNhanVien;

        private int _MaChamCong;

        private DateTime _Ngay;

        private string _DemCong;

        private int _DemGio;

        private float _Nghi;

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

        public string TenNhanVien
        {
            get
            {
                return this._TenNhanVien;
            }
            set
            {
                this._TenNhanVien = value;
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

        public string DemCong
        {
            get
            {
                return this._DemCong;
            }
            set
            {
                this._DemCong = value;
            }
        }

        public int DemGio
        {
            get
            {
                return this._DemGio;
            }
            set
            {
                this._DemGio = value;
            }
        }

        public float Nghi
        {
            get
            {
                return this._Nghi;
            }
            set
            {
                this._Nghi = value;
            }
        }
    }
}
