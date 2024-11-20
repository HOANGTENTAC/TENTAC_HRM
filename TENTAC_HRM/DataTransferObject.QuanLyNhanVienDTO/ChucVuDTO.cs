namespace TENTAC_HRM.DataTransferObject.QuanLyNhanVienDTO
{
    internal class ChucVuDTO
    {
        private string _MaChucVu;

        private string _MaCongTy;

        private string _MaKhuVuc;

        private string _TenKhuVuc;

        private string _MaPhongBan;

        private string _TenPhongBan;

        private string _TenChucVu;

        public string MaChucVu
        {
            get
            {
                return _MaChucVu;
            }
            set
            {
                _MaChucVu = value;
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

        public string TenChucVu
        {
            get
            {
                return _TenChucVu;
            }
            set
            {
                _TenChucVu = value;
            }
        }

        public ChucVuDTO()
        {
        }

        public ChucVuDTO(string _MaChucVu, string _MaCongTy, string _MaKhuVuc, string _TenKhuVuc, string _MaPhongBan, string _TenPhongBan, string _TenChucVu)
        {
            MaChucVu = _MaChucVu;
            MaCongTy = _MaCongTy;
            MaKhuVuc = _MaKhuVuc;
            TenKhuVuc = _TenKhuVuc;
            MaPhongBan = _MaPhongBan;
            TenPhongBan = _TenPhongBan;
            TenChucVu = _TenChucVu;
        }
    }
}
