namespace TENTAC_HRM.Models
{
    class NhanvienTaisanModel
    {
        public int id_nhanvien_taisan { get; set; }
        public int id_nhanvien { get; set; }
        public string so_phieu { get; set; }
        public string ngay_vao_so { get; set; }
        public string tu_ngay { get; set; }
        public string den_ngay { get; set; }
        public int trang_thai { get; set; }
        public int quy_trinh { get; set; }
        public int kho { get; set; }
        public int ke { get; set; }
        public string dien_giai { get; set; }
        public string ghi_chu { get; set; }
        public string ma_donvi { get; set; }
        public string ma_khuvuc { get; set; }
        public string ma_phongban { get; set; }
        public string ma_chucvu { get; set; }
        public string thanh_phan1 { get; set; }
        public string chuc_vu1 { get; set; }
        public string dai_dien1 { get; set; }
        public string thanh_phan2 { get; set; }
        public string chuc_vu2 { get; set; }
        public string dai_dien2 { get; set; }
        public string thanh_phan3 { get; set; }
        public string chuc_vu3 { get; set; }
        public string dai_dien3 { get; set; }
        public string thanh_phan4 { get; set; }
        public string chuc_vu4 { get; set; }
        public string dai_dien4 { get; set; }
        public string thanh_phan5 { get; set; }
        public string chuc_vu5 { get; set; }
        public string dai_dien5 { get; set; }
        public bool del_flg { get; set; }
        public int id_nguoitao { get; set; }
    }
}
