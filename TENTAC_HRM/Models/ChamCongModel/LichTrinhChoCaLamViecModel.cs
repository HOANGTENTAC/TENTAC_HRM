namespace TENTAC_HRM.Models.ChamCongModel
{
    internal class LichTrinhChoCaLamViecModel
    {
        private string _MaLichTrinhCaLamViec;

        private string _TenLichTrinhCaLamViec;

        private int _ChuKy;

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

        public string TenLichTrinhCaLamViec
        {
            get
            {
                return this._TenLichTrinhCaLamViec;
            }
            set
            {
                this._TenLichTrinhCaLamViec = value;
            }
        }

        public int ChuKy
        {
            get
            {
                return this._ChuKy;
            }
            set
            {
                this._ChuKy = value;
            }
        }

        public LichTrinhChoCaLamViecModel()
        {
        }

        public LichTrinhChoCaLamViecModel(string _MaLichTrinhCaLamViec, string _TenLichTrinhCaLamViec)
        {
            this.MaLichTrinhCaLamViec = _MaLichTrinhCaLamViec;
            this.TenLichTrinhCaLamViec = _TenLichTrinhCaLamViec;
        }
    }
}
