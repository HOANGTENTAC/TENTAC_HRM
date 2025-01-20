using System;

namespace TENTAC_HRM.Models.BaoBieuModel
{
    internal class ThuongModel
    {
        private int _IDThuong;

        private int _MaChamCong;

        private string _Thuong;

        private string _TienThuong;

        private DateTime _NgayThuong;

        public int IDThuong
        {
            get
            {
                return this._IDThuong;
            }
            set
            {
                this._IDThuong = value;
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

        public string Thuong
        {
            get
            {
                return this._Thuong;
            }
            set
            {
                this._Thuong = value;
            }
        }

        public string TienThuong
        {
            get
            {
                return this._TienThuong;
            }
            set
            {
                this._TienThuong = value;
            }
        }

        public DateTime NgayThuong
        {
            get
            {
                return this._NgayThuong;
            }
            set
            {
                this._NgayThuong = value;
            }
        }
    }
}
