using System.ComponentModel;

namespace TENTAC_HRM.Model
{
    class Tainan_model
    {
        public int id_qt_tainan { get; set; }
        [DisplayName("Ngày diễn ra")]
        public string ngay_dien_ra { get; set; }
        [DisplayName("Nơi diễn ra")]
        public string noi_dien_ra { get; set; }
        [DisplayName("Nội dung")]
        public string noi_dung { get; set; }
        [DisplayName("Người tạo")]
        public string nguoi_tao { get; set; }
        [DisplayName("Tên tai nạn")]
        public string ten_tai_nan { get; set; }
        [DisplayName("mức độ")]
        public string muc_do { get; set; }
    }
}
