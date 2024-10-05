namespace TENTAC_HRM.Model
{
    internal class CommonKhuonMat_model
    {
        private int _MaChamCong;

        private int _FaceIDVirtual;

        private string _FaceTemplateVirtual;

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

        public int FaceIDVirtual
        {
            get
            {
                return _FaceIDVirtual;
            }
            set
            {
                _FaceIDVirtual = value;
            }
        }

        public string FaceTemplateVirtual
        {
            get
            {
                return _FaceTemplateVirtual;
            }
            set
            {
                _FaceTemplateVirtual = value;
            }
        }
    }
}
