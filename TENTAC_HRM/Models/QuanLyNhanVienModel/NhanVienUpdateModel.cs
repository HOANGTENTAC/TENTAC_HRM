namespace TENTAC_HRM.Models.QuanLyNhanVienModel
{
    internal class NhanVienUpdateModel
    {
        private int _MaChamCong;

        private string _MaThe;

        private string _UserPassWord;

        private int _PhanQuyen;
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

        public string MaThe
        {
            get
            {
                return _MaThe;
            }
            set
            {
                _MaThe = value;
            }
        }
        public string UserPassWord
        {
            get
            {
                return _UserPassWord;
            }
            set
            {
                _UserPassWord = value;
            }
        }

        public int PhanQuyen
        {
            get
            {
                return _PhanQuyen;
            }
            set
            {
                _PhanQuyen = value;
            }
        }
    }
}
