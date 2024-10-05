namespace TENTAC_HRM.Model
{
    internal class SapXepLichTrinhChoNhanVien_model
    {
        private int _MaChamCong;

        private string _MaLichTrinhVaoRa;

        private string _MaLichTrinhCaLamViec;

        public int MaChamCong
        {
            get
            {
                return _MaChamCong;
            }
            set
            {
                _MaChamCong = value;
            }
        }

        public string MaLichTrinhVaoRa
        {
            get
            {
                return _MaLichTrinhVaoRa;
            }
            set
            {
                _MaLichTrinhVaoRa = value;
            }
        }

        public string MaLichTrinhCaLamViec
        {
            get
            {
                return _MaLichTrinhCaLamViec;
            }
            set
            {
                _MaLichTrinhCaLamViec = value;
            }
        }
    }
}
