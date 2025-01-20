namespace TENTAC_HRM.Models.QuanLyNhanVienModel
{
    internal class KhuVucDTO
    {
        private string _MaKhuVuc;

        private string _MaCongTy;

        private string _TenKhuVuc;

        private string _DiaChiKhuVuc;

        private string _NguoiLienHe;

        private string _DienThoaiLienHe;

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

        public string DiaChiKhuVuc
        {
            get
            {
                return _DiaChiKhuVuc;
            }
            set
            {
                _DiaChiKhuVuc = value;
            }
        }

        public string NguoiLienHe
        {
            get
            {
                return _NguoiLienHe;
            }
            set
            {
                _NguoiLienHe = value;
            }
        }

        public string DienThoaiLienHe
        {
            get
            {
                return _DienThoaiLienHe;
            }
            set
            {
                _DienThoaiLienHe = value;
            }
        }

        public KhuVucDTO()
        {
        }

        public KhuVucDTO(string _MaKhuVuc, string _MaCongTy, string _TenKhuVuc, string _DiaChiKhuVuc, string _NguoiLienHe, string _DienThoaiLienHe)
        {
            MaKhuVuc = _MaKhuVuc;
            MaCongTy = _MaCongTy;
            TenKhuVuc = _TenKhuVuc;
            DiaChiKhuVuc = _DiaChiKhuVuc;
            NguoiLienHe = _NguoiLienHe;
            DienThoaiLienHe = _DienThoaiLienHe;
        }
    }
}
