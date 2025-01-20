using System;

namespace TENTAC_HRM.Models.BaoBieuModel
{
    internal class ChiTietTamUngLuongModel
    {
        private int _IDTamUngLuong;

        private int _MaChamCong;

        private string _SoTien;

        private string _LyDo;

        private DateTime _NgayTamUng;

        private int _Thang;

        private int _Nam;

        public int IDTamUngLuong
        {
            get
            {
                return this._IDTamUngLuong;
            }
            set
            {
                this._IDTamUngLuong = value;
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

        public DateTime NgayTamUng
        {
            get
            {
                return this._NgayTamUng;
            }
            set
            {
                this._NgayTamUng = value;
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
