using System;

namespace TENTAC_HRM.Model
{
    internal class CheckInOut_model
    {
        public int ID { get; set; }

        public int Ma_Cham_Cong { get; set; }

        public DateTime Ngay_Cham { get; set; }

        public DateTime Gio_Cham { get; set; }

        public string Kieu_Cham { get; set; }

        public string Nguon_Cham { get; set; }

        public int MaSo_May { get; set; }

        public string Ten_May { get; set; }
    }
}
