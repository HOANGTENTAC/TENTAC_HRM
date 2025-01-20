using System;

namespace TENTAC_HRM.Models.ChamCongModel
{
    internal class KhaiBaoVangChoNhanVienModel
    {
        private int _ID;

        private int _MaChamCong;

        private int _Nam;

        private int _Thang;

        private DateTime _NgayThang;

        private string _MaCacLoaiVang;

        private string _ApDung;

        private int _TongPhut;

        private string _NgayCong;

        private string _GhiChu;

        private bool _DuocHuongLuong;

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

        public string MaCacLoaiVang
        {
            get
            {
                return this._MaCacLoaiVang;
            }
            set
            {
                this._MaCacLoaiVang = value;
            }
        }

        public string ApDung
        {
            get
            {
                return this._ApDung;
            }
            set
            {
                this._ApDung = value;
            }
        }

        public int TongPhut
        {
            get
            {
                return this._TongPhut;
            }
            set
            {
                this._TongPhut = value;
            }
        }

        public string NgayCong
        {
            get
            {
                return this._NgayCong;
            }
            set
            {
                this._NgayCong = value;
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

        public bool DuocHuongLuong
        {
            get
            {
                return this._DuocHuongLuong;
            }
            set
            {
                this._DuocHuongLuong = value;
            }
        }
    }
}
