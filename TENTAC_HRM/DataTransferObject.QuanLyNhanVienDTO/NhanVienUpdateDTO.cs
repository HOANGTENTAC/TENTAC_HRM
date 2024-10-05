namespace TENTAC_HRM.DataTransferObject.QuanLyNhanVienDTO
{
    internal class NhanVienUpdateDTO
    {
        private int _MaChamCong;

        private string _MaThe;

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
    }
}
