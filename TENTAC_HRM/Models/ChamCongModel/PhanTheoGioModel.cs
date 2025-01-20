using System;

namespace TENTAC_HRM.Models.ChamCongModel
{
    internal class PhanTheoGioModel
    {
        private int _ID;

        private string _MaLichTrinhVaoRa;

        private string _TenLichTrinhVaoRa;

        private DateTime _BatDauVao;

        private DateTime _KetThucVao;

        private DateTime _BatDauRa;

        private DateTime _KetThucRa;

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

        public string MaLichTrinhVaoRa
        {
            get
            {
                return this._MaLichTrinhVaoRa;
            }
            set
            {
                this._MaLichTrinhVaoRa = value;
            }
        }

        public string TenLichTrinhVaoRa
        {
            get
            {
                return this._TenLichTrinhVaoRa;
            }
            set
            {
                this._TenLichTrinhVaoRa = value;
            }
        }

        public DateTime BatDauVao
        {
            get
            {
                return this._BatDauVao;
            }
            set
            {
                this._BatDauVao = value;
            }
        }

        public DateTime KetThucVao
        {
            get
            {
                return this._KetThucVao;
            }
            set
            {
                this._KetThucVao = value;
            }
        }

        public DateTime BatDauRa
        {
            get
            {
                return this._BatDauRa;
            }
            set
            {
                this._BatDauRa = value;
            }
        }

        public DateTime KetThucRa
        {
            get
            {
                return this._KetThucRa;
            }
            set
            {
                this._KetThucRa = value;
            }
        }
    }
}
