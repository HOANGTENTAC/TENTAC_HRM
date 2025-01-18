using System;

namespace TENTAC_HRM.Model
{
    internal class CheckInOut_model
    {
        public int ID { get; set; }

        public int MaChamCong { get; set; }

        public DateTime NgayCham { get; set; }

        public DateTime GioCham { get; set; }

        public string KieuCham { get; set; }

        public string NguonCham { get; set; }

        public int MaSoMay { get; set; }

        public string TenMay { get; set; }
    }
}
