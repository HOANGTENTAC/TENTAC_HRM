namespace TENTAC_HRM.Models.QuanLyNhanVienModel
{
    internal class PhongBanModel
    {
        private string _MaPhongBan;

        private string _MaCongTy;

        private string _MaKhuVuc;

        private string _TenKhuVuc;

        private string _TenPhongBan;

        private string _SoTienSanLuong;

        public string MaPhongBan
        {
            get
            {
                return _MaPhongBan;
            }
            set
            {
                _MaPhongBan = value;
            }
        }

        public string MaCongTy
        {
            get
            {
                return _MaCongTy;
            }
            set
            {
                _MaCongTy = value;
            }
        }

        public string MaKhuVuc
        {
            get
            {
                return _MaKhuVuc;
            }
            set
            {
                _MaKhuVuc = value;
            }
        }

        public string TenKhuVuc
        {
            get
            {
                return _TenKhuVuc;
            }
            set
            {
                _TenKhuVuc = value;
            }
        }

        public string TenPhongBan
        {
            get
            {
                return _TenPhongBan;
            }
            set
            {
                _TenPhongBan = value;
            }
        }

        public string SoTienSanLuong
        {
            get
            {
                return _SoTienSanLuong;
            }
            set
            {
                _SoTienSanLuong = value;
            }
        }

        public PhongBanModel()
        {
        }

        public PhongBanModel(string _MaPhongBan, string _MaCongTy, string _TenKhuVuc, string _TenPhongBan, string _MaKhuVuc)
        {
            MaPhongBan = _MaPhongBan;
            MaCongTy = _MaCongTy;
            TenKhuVuc = _TenKhuVuc;
            TenPhongBan = _TenPhongBan;
            MaKhuVuc = _MaKhuVuc;
        }

        public PhongBanModel(string _MaPhongBan, string _MaCongTy, string _MaKhuVuc, string _TenPhongBan)
        {
            MaPhongBan = _MaPhongBan;
            this._MaCongTy = _MaCongTy;
            MaKhuVuc = _MaKhuVuc;
            TenPhongBan = _TenPhongBan;
        }
    }
}
