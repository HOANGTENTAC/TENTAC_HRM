namespace TENTAC_HRM.Models.BaoBieuModel
{
    internal class ChiTietCongTruLuongModel
    {
        private int _MaChamCong;

        private string _ChiTietPhuCapCom;

        private string _ChiTietPhuCapKhac;

        private string _ChiTietTamUngLuong;

        private string _ChiTietViPham;

        private string _ChiTietThuong;

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

        public string ChiTietPhuCapCom
        {
            get
            {
                return this._ChiTietPhuCapCom;
            }
            set
            {
                this._ChiTietPhuCapCom = value;
            }
        }

        public string ChiTietPhuCapKhac
        {
            get
            {
                return this._ChiTietPhuCapKhac;
            }
            set
            {
                this._ChiTietPhuCapKhac = value;
            }
        }

        public string ChiTietTamUngLuong
        {
            get
            {
                return this._ChiTietTamUngLuong;
            }
            set
            {
                this._ChiTietTamUngLuong = value;
            }
        }

        public string ChiTietViPham
        {
            get
            {
                return this._ChiTietViPham;
            }
            set
            {
                this._ChiTietViPham = value;
            }
        }

        public string ChiTietThuong
        {
            get
            {
                return this._ChiTietThuong;
            }
            set
            {
                this._ChiTietThuong = value;
            }
        }
    }
}
