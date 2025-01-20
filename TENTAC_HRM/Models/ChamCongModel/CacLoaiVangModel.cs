namespace TENTAC_HRM.Models.ChamCongModel
{
    internal class CacLoaiVangModel
    {
        private string _MaCacLoaiVang;

        private string _MoTa;

        private string _KyHieu;

        private bool _SuDung;

        public string MaCacLoaiVang
        {
            get
            {
                return this._MaCacLoaiVang;
            }
            set
            {
                this._MaCacLoaiVang = value;
            }
        }

        public string MoTa
        {
            get
            {
                return this._MoTa;
            }
            set
            {
                this._MoTa = value;
            }
        }

        public string KyHieu
        {
            get
            {
                return this._KyHieu;
            }
            set
            {
                this._KyHieu = value;
            }
        }

        public bool SuDung
        {
            get
            {
                return this._SuDung;
            }
            set
            {
                this._SuDung = value;
            }
        }

        public CacLoaiVangModel()
        {
        }

        public CacLoaiVangModel(string _MaCacLoaiVang, string _MoTa, string _KyHieu, bool _SuDung)
        {
            this.MaCacLoaiVang = _MaCacLoaiVang;
            this.MoTa = _MoTa;
            this.KyHieu = _KyHieu;
            this.SuDung = _SuDung;
        }
    }
}
