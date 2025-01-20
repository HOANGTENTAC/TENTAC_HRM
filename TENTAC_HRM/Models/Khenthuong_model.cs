namespace TENTAC_HRM.Models
{
    class Khenthuong_model
    {
        public int Id_khenthuong { get; set; }
        public int Id_nhanvien { get; set; }
        public string Ngay_khen_thuong { get; set; }
        public string So_quyet_dinh { get; set; }
        public string Noi_dung { get; set; }
        public string Hinh_thuc { get; set; }
        public string So_tien { get; set; }
        public string Ly_do { get; set; }
        public int Id_cap { get; set; }
        public int Id_nguoi_ky { get; set; }
        public string Id_nguoi_tao { get; set; }
    }
}
