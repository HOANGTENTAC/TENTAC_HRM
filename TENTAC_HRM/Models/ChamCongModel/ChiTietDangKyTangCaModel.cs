using System;

namespace TENTAC_HRM.Models.ChamCongModel
{
    internal class ChiTietDangKyTangCaModel
    {
        private int _ID;

        private int _MaChamCong;

        private DateTime _Ngay;

        private string _TrangThai;

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

        public string TrangThai
        {
            get
            {
                return this._TrangThai;
            }
            set
            {
                this._TrangThai = value;
            }
        }
    }
}
