namespace TENTAC_HRM.Models.ChamCongModel
{
    internal class SapXepLichTrinhChoNhanVienModel
    {
        private int _MaChamCong;

        private string _MaLichTrinhVaoRa;

        private string _MaLichTrinhCaLamViec;

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

        public string MaLichTrinhCaLamViec
        {
            get
            {
                return this._MaLichTrinhCaLamViec;
            }
            set
            {
                this._MaLichTrinhCaLamViec = value;
            }
        }
    }
}
