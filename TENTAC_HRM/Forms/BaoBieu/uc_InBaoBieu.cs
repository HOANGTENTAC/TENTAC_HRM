﻿using System;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Globalization;
using System.Runtime.InteropServices;
using System.Threading;
using System.Windows.Forms;
using TENTAC_HRM.Models.BaoBieuModel;
using TENTAC_HRM.BLL.BaoBieuBLL;
using TENTAC_HRM.BLL.ChamCongBLL;
using TENTAC_HRM.BLL.QuanLyNhanVienBLL;
using TENTAC_HRM.Models.ChamCongModel;
using TENTAC_HRM.Common;
using TENTAC_HRM.BLL.DuLieuMayChamCongBLL;
using TENTAC_HRM.Models.QuanLyNhanVienModel;
using TENTAC_HRM.Forms.Common;
using TENTAC_HRM.Models;
using Excel = Microsoft.Office.Interop.Excel;
using TENTAC_HRM.BLL.BLL.ChamCongBLL;
using System.Linq;
using TENTAC_HRM.BLL.QuanLyTangCaBLL;

namespace TENTAC_HRM.Forms.BaoBieu
{
    public partial class uc_InBaoBieu : UserControl
    {
        //private byte[] imageData;

        private ConvertMoney _convertMoney = new ConvertMoney();

        private CongTyBLL _congTyBLL = new CongTyBLL();

        private CongTyModel _congTyDTO = new CongTyModel();

        private KhuVucModel _khuVucDTO = new KhuVucModel();

        private KhuVucBLL _khuVucBLL = new KhuVucBLL();

        private PhongBanModel _phongBanDTO = new PhongBanModel();

        private PhongBanBLL _phongBanBLL = new PhongBanBLL();

        private ChucVuModel _chucVuDTO = new ChucVuModel();

        private ChucVuBLL _chucVuBLL = new ChucVuBLL();

        private NhanVienBLL _nhanVienBLL = new NhanVienBLL();

        private NhanVienModel _nhanVienDTO = new NhanVienModel();

        private KyHieuChamCongModel _kyHieuChamCongDTO = new KyHieuChamCongModel();

        private KyHieuChamCongBLL _kyHieuChamCongBLL = new KyHieuChamCongBLL();

        private Models.ChamCongModel.TuyChonModel _tuyChonDTO = new Models.ChamCongModel.TuyChonModel();

        private TuyChonBLL _tuyChonBLL = new TuyChonBLL();

        private ChiTietTamUngLuongModel _chiTietTamUngLuongDTO = new ChiTietTamUngLuongModel();

        private ChiTietTamUngLuongBLL _chiTietTamUngLuongBLL = new ChiTietTamUngLuongBLL();

        private ChiTietPhuCapNhanVienBLL _chiTietPhuCapNhanVienBLL = new ChiTietPhuCapNhanVienBLL();

        private ChiTietPhuCapNhanVienModel _chiTietPhuCapNhanVienDTO = new ChiTietPhuCapNhanVienModel();

        private ViPhamModel _viPhamDTO = new ViPhamModel();

        private ViPhamBLL _viPhamBLL = new ViPhamBLL();

        private ThuongModel _thuongDTO = new ThuongModel();

        private ThuongBLL _thuongBLL = new ThuongBLL();

        private NgayLeModel _ngayLeDTO = new NgayLeModel();

        private NgayLeBLL _ngayLeBLL = new NgayLeBLL();

        private ChiTietDiCongTacModel _chiTietDiCongTacDTO = new ChiTietDiCongTacModel();

        private ChiTietDiCongTacBLL _chiTietDiCongTacBLL = new ChiTietDiCongTacBLL();

        private PhepNamModel _phepNamDTO = new PhepNamModel();

        private PhepNamBLL _phepNamBLL = new PhepNamBLL();

        private KhaiBaoVangChoNhanVienModel _khaiBaoVangChoNhanVienDTO = new KhaiBaoVangChoNhanVienModel();

        private KhaiBaoVangChoNhanVienBLL _khaiBaoVangChoNhanVienBLL = new KhaiBaoVangChoNhanVienBLL();

        private CacLoaiVangModel _cacLoaiVangDTO = new CacLoaiVangModel();

        private CacLoaiVangBLL _cacLoaiVangBLL = new CacLoaiVangBLL();

        private SapXepLichTrinhChoNhanVienModel _sapxepLichTrinhChoNhanVienDTO = new SapXepLichTrinhChoNhanVienModel();

        private SapXepLichTrinhChoNhanVienBLL _sapXepLichTrinhChoNhanVienBLL = new SapXepLichTrinhChoNhanVienBLL();

        private Models.LichTrinhVaoRaModel _lichTrinhVaoRaDTO = new Models.LichTrinhVaoRaModel();

        private LichTrinhVaoRaBLL _lichTrinhVaoRaBLL = new LichTrinhVaoRaBLL();

        private CheckInOutModel _checkInOutDTO = new CheckInOutModel();

        private CheckInOut_BLL _checkInOutBLL = new CheckInOut_BLL();

        private ChiTietLichTrinhChoCaLamViecBLL _chiTietLichTrinhChoCaLamViecBLL = new ChiTietLichTrinhChoCaLamViecBLL();

        private ChiTietLichTrinhChoCaLamViecModel _chiTietLichTrinhChoCalamViecDTO = new ChiTietLichTrinhChoCaLamViecModel();

        private CaLamViecBLL _caLamViecBLL = new CaLamViecBLL();

        private CaLamViecModel _caLamViecDTO = new CaLamViecModel();

        private PhanTheoGioBLL _phanTheoGioBLL = new PhanTheoGioBLL();

        private PhanTheoGioModel _phanTheoGioDTO = new PhanTheoGioModel();
        private TangCaBLL _tangCaBLL = new TangCaBLL();
        private SqlConnection con;

        private SqlDataAdapter da;

        private SqlCommand cmd;

        private DataSet ds;

        protected static string strConnect;

        public string _sAn;

        private string sTenCongTyReport;

        private string sDiaChiCongTyReport;

        private NgayTinhCongBLL _ngayTinhCongBLL = new NgayTinhCongBLL();

        private NgayTinhCongModel _ngayTinhCongDTO = new NgayTinhCongModel();

        private string sTongNgayTinh;

        private string sMaChamCong;

        private string sMaNhanVien;

        private string sTenNhanVien;

        private string sGioVao;

        private string sGioRa;

        private string sMaKyHieu;

        private string sDungGio;

        private string sVang;

        private string sNgayVaoLamViec;

        private string sPhongBanTinhCong;

        private string sKHMaKyHieu;

        private string sKHDiTre;

        private string sKHVeSom;

        private string sKHDungGio;

        private string sKHTangCa;

        private string sKHThieuGioVao;

        private string sKHThieuGioRa;

        private string sKHVang;

        private string sKHChuaXepCa;

        private string sKHPhepNam;

        private string sKHLe;

        private string sKHCongTac;

        private string sKHVeTre;

        private string sKHCuoiTuan;

        private string sKiemTraMin;

        private string sKiemTraMax;

        private int iLuaChon;

        private int demNhanVienVangTinhCong;

        private int demNhanVienNghiLeTinhCong;

        private string sID;

        private string sMaLichTrinhCalamViec;

        private string sThu;

        private string sCaThu1;

        private string sCaThu2;

        private string sCaThu3;

        private string sCaThu4;

        private string sCaThu5;

        private string sCaThu6;

        private string sCaThu7;

        private string sCaThu8;

        private string sCaThu9;

        private string sCaThu10;

        private string sFiloTenCaLamViec;

        private string sFiloMaCaLamViec;

        private string sTuDongQuaDemMaCaLamViec;

        private string sTuDongQuaDemTenCaLamViec;

        private string sChonTuMayMaCaLamViec;

        private string sChonTuMayTenCaLamViec;

        private string sTheoIDMayMaCaLamViec;

        private string sTheoIDMayTenCaLamViec;

        private string sTinhTheoGioTenCaLamViec;

        private string sTinhTheoGioMaCaLamViec;

        private string sPhanTheoGioTenCaLamViec;

        private string sPhanTheoGioMaCaLamViec;

        private double dTongTienPhuCap;

        private double dTongTienPhuCapTienCom;

        private double dTongTienPhuCapKhac;

        private double dTongTienTamUng;

        private double dTongTienViPham;

        private double dTongTienThuong;

        private int iDemCuoiTuan;

        private TinhCongBLL _tinhCongBLL = new TinhCongBLL();

        private TinhCongModel _tinhCongDTO = new TinhCongModel();

        private TinhLuongModel _tinhLuongDTO = new TinhLuongModel();

        private TinhLuongBLL _tinhLuongBLL = new TinhLuongBLL();

        private ChiTietCongTruLuongModel _chiTietCongTruLuongDTO = new ChiTietCongTruLuongModel();

        private ChiTietCongTruLuongBLL _chiTietCongTruLuongBLL = new ChiTietCongTruLuongBLL();

        //private LichTrinhChoCaLamViecModel _lichTrinhChoCaLamViecDTO = new LichTrinhChoCaLamViecModel();

        private LichTrinhChoCaLamViecBLL _lichTrinhChoCaLamViecBLL = new LichTrinhChoCaLamViecBLL();

        private ChiTietDangKyTangCaBLL _chiTietDangKyTangCaBLL = new ChiTietDangKyTangCaBLL();

        private ChiTietDangKyTangCaModel _chiTietDangKyTangCaDTO = new ChiTietDangKyTangCaModel();

        public int iDemNhanVienDuocChon;

        private int iLamTronCong;

        private int iLamTronGio;

        private string sDinhDangThoiGian;

        private string sLuaChonKhaiBaoLuongBaoHiem;

        private double dTangCa1HeSo;

        private double dTangCa2HeSo;

        private double dTangCa3HeSo;

        private double dTangCa4HeSo;

        private double dSoTienKhaiBao;

        private double dTangCaChuNhatHeSo;

        private double dHeSoBaoHiemXaHoi;

        private double dHeSoBaoHiemYTe;

        private double dHeSoBaoHiemThatNghiep;

        private int iLamTronTuA;

        private int iLamTronDenA;

        private int iLamTronTuB;

        private int iLamTronDenB;

        private int iLamTronTuC;

        private int iLamTronDenC;

        private int iLamTronTuD;

        private int iLamTronDenD;

        private string sLamTronA;

        private string sLamTronB;

        private string sLamTronC;

        private string sLamTronD;

        private string sMaChamCongSuaXoaGioCham;

        private string sNgayChamSuaXoaGioCham;

        private string sGioChamSuaXoaGioCham;

        private string sKieuChamSuaXoaGioCham;

        private string sMaSoMaySuaXoaGioCham;

        private string sIDSuaXoaGioCham;

        private string _tenNode;

        private string sMaPhongBanTreeView;

        private string sMaCongTyTreeView;

        private string sMaKhuVucTreeView;

        private string sMaChucVuTreeView;

        private string sDanhSachNhanVienMoi;

        private string sNghiViecTamThoi;

        private int iChonLanXuat;

        private int demProcess = -1;

        private int testProcess;

        private string sTuNgayChiTietThoiGianLamViec;

        private string sDenNgayChiTietThoiGianLamViec;

        private string sMaChamCongThemGio;

        private DateTime dNgayChamCongThemGio = default(DateTime);

        private DateTime dGioChamVaoThemGio = default(DateTime);

        private DateTime dGioChamRaThemGio = default(DateTime);

        private DateTime dGioChamVaoThemGioCheck = default(DateTime);

        private DateTime dGioChamRaThemGioCheck = default(DateTime);

        private int iCheckTrongVao;

        private int iCheckTrongRa;

        private int iCheckCaDem;

        private DateTime dNgayCham = default(DateTime);

        private DateTime dGioCham = default(DateTime);

        private string sKieuChamSuaGio;

        private int iMaSoMaySuaGioA;

        private int sIDSuaGio;
        public int[] IdPermision { get; set; }
        public uc_InBaoBieu(int[] permissions = null)
        {
            IdPermision = permissions;
            InitializeComponent();
        }

        private void frmTinhCongVaInBaoBieu_Load(object sender, EventArgs e)
        {
            xuatThuTuNgay();
            xuatThuDenNgay();
            loadTreeView();
            DGVDanhSachNhanVien.Columns.Insert(0, new DataGridViewCheckBoxColumn());
            DGVDanhSachNhanVien.Columns[0].Width = 30;
            ngayTinhCong();
            loadControlTinhCong();
            loadControlTinhLuong();
            //loadTuyChon();
            //loadListViewBaoCao();
            loadThongTinCongTy();
        }

        private void loadThongTinCongTy()
        {
            new DataTable();
            _congTyDTO.MaCongTy = "CT00001";
            DataTable dtloadThongTinCongTy;
            dtloadThongTinCongTy = _congTyBLL.showThongTinCongTy(_congTyDTO);
            for (int iLoadThongTinCongTy = 0; iLoadThongTinCongTy < dtloadThongTinCongTy.Rows.Count; iLoadThongTinCongTy++)
            {
                sTenCongTyReport = dtloadThongTinCongTy.Rows[iLoadThongTinCongTy]["TenCongTy"].ToString();
                sDiaChiCongTyReport = dtloadThongTinCongTy.Rows[iLoadThongTinCongTy]["DiaChi"].ToString();
            }
            new DataTable();
            _kyHieuChamCongDTO.MaKyHieu = "KH00001";
            DataTable dtKyHieu;
            dtKyHieu = _kyHieuChamCongBLL.showLoadKyHieuChamCong(_kyHieuChamCongDTO);
            for (int _kyHieu = 0; _kyHieu < dtKyHieu.Rows.Count; _kyHieu++)
            {
                sKHDiTre = dtKyHieu.Rows[_kyHieu]["DiTre"].ToString();
                sKHVeSom = dtKyHieu.Rows[_kyHieu]["VeSom"].ToString();
                sKHDungGio = dtKyHieu.Rows[_kyHieu]["DungGio"].ToString();
                sKHTangCa = dtKyHieu.Rows[_kyHieu]["TangCa"].ToString();
                sKHThieuGioVao = dtKyHieu.Rows[_kyHieu]["ThieuGioVao"].ToString();
                sKHThieuGioRa = dtKyHieu.Rows[_kyHieu]["ThieuGioRa"].ToString();
                sKHVang = dtKyHieu.Rows[_kyHieu]["Vang"].ToString();
                sKHChuaXepCa = dtKyHieu.Rows[_kyHieu]["ChuaXepCa"].ToString();
                sKHPhepNam = dtKyHieu.Rows[_kyHieu]["PhepNam"].ToString();
                sKHLe = dtKyHieu.Rows[_kyHieu]["Le"].ToString();
                sKHCongTac = dtKyHieu.Rows[_kyHieu]["CongTac"].ToString();
                sKHVeTre = dtKyHieu.Rows[_kyHieu]["VeTre"].ToString();
                sKHCuoiTuan = dtKyHieu.Rows[_kyHieu]["CuoiTuan"].ToString();
            }
        }

        private void ngayTinhCong()
        {
            dateTimeTuNgay.Text = DateTime.Now.ToString();
            dateTimeDenNgay.Text = DateTime.Now.ToString();
        }

        private void loadTreeView()
        {
            DataTable dtCongTy = _congTyBLL.showThongTinCongTy(_congTyDTO);
            for (int i = 0; i < dtCongTy.Rows.Count; i++)
            {
                TreeNode treeCongTy = new TreeNode()
                {
                    Text = dtCongTy.Rows[i][1].ToString(),
                    Tag = dtCongTy.Rows[i][0].ToString()
                };
                treeViewSoDoQuanLy.Nodes.Add(treeCongTy);
                _khuVucDTO.MaCongTy = dtCongTy.Rows[i]["MaCongTy"].ToString();
                DataTable dtKhuVuc = _khuVucBLL.GETKHUVUCTREEVIEW(_khuVucDTO);
                for (int j = 0; j < dtKhuVuc.Rows.Count; j++)
                {
                    TreeNode treeKhuVuc = new TreeNode()
                    {
                        Text = dtKhuVuc.Rows[j][2].ToString(),
                        Tag = dtKhuVuc.Rows[j][0].ToString()
                    };
                    treeViewSoDoQuanLy.Nodes[i + 0].Nodes.Add(treeKhuVuc);
                    _phongBanDTO.MaKhuVuc = dtKhuVuc.Rows[j]["MaKhuVuc"].ToString();
                    DataTable dtPhongBan = _phongBanBLL.GETPHONGBANTREEVIEW(_phongBanDTO);

                    for (int z = 0; z < dtPhongBan.Rows.Count; z++)
                    {
                        TreeNode treePhongBan = new TreeNode()
                        {
                            Text = dtPhongBan.Rows[z][3].ToString(),
                            Tag = dtPhongBan.Rows[z][0].ToString()
                        };

                        treeViewSoDoQuanLy.Nodes[i + 0].Nodes[j].Nodes.Add(treePhongBan);
                        _chucVuDTO.MaPhongBan = dtPhongBan.Rows[z]["MaPhongBan"].ToString();
                        DataTable dtChucVu = _chucVuBLL.GETCHUCVUTREEVIEW(_chucVuDTO);
                        for (int v = 0; v < dtChucVu.Rows.Count; v++)
                        {
                            TreeNode treeChucVu = new TreeNode()
                            {
                                Text = dtChucVu.Rows[v][4].ToString(),
                                Tag = dtChucVu.Rows[v][0].ToString()
                            };

                            treeViewSoDoQuanLy.Nodes[i + 0].Nodes[j].Nodes[z].Nodes.Add(treeChucVu);
                            _chucVuDTO.MaChucVu = dtChucVu.Rows[v]["MaChucVu"].ToString();
                        }
                    }
                }
            }
        }

        private void MenuChonTatCa_Click(object sender, EventArgs e)
        {
            bool _selectAllNhanVien;
            _selectAllNhanVien = 0 == 0;
            if (_selectAllNhanVien)
            {
                for (int iNhanVienMoi = 0; iNhanVienMoi < DGVDanhSachNhanVien.Rows.Count; iNhanVienMoi++)
                {
                    DGVDanhSachNhanVien.Rows[iNhanVienMoi].Cells[0].Value = _selectAllNhanVien;
                }
            }
        }

        private void MenuBoChonTatCa_Click(object sender, EventArgs e)
        {
            bool _selectAllNhanVien;
            _selectAllNhanVien = 1 == 0;
            if (!_selectAllNhanVien)
            {
                for (int iNhanVienMoi = 0; iNhanVienMoi < DGVDanhSachNhanVien.Rows.Count; iNhanVienMoi++)
                {
                    DGVDanhSachNhanVien.Rows[iNhanVienMoi].Cells[0].Value = _selectAllNhanVien;
                }
            }
        }

        private void btnTinhToan_Click(object sender, EventArgs e)
        {
            this.iDemNhanVienDuocChon = 0;
            this.tabControl2.SelectedTabIndex = 0;
            this._tinhCongBLL.TinhCongDelete(this._tinhCongDTO);
            this._tinhLuongBLL.TinhLuongDelete();
            this._chiTietCongTruLuongBLL.ChiTietCongTruLuongDelete();
            DataTable dt_ca = SQLHelper.ExecuteDt($"select * from MITACOSQL.dbo.BangXepCa where Nam = '{dateTimeTuNgay.Value.Year}' and Thang = '{dateTimeTuNgay.Value.Month}'");
            int TestDemNhanVien;
            TestDemNhanVien = 0;
            for (int iTestDemNhanVien = 0; iTestDemNhanVien < this.DGVDanhSachNhanVien.Rows.Count; iTestDemNhanVien++)
            {
                if (Convert.ToBoolean(this.DGVDanhSachNhanVien[0, iTestDemNhanVien].Value))
                {
                    TestDemNhanVien++;
                    this.iDemNhanVienDuocChon++;
                }
            }
            this.loadTuyChon();
            new DataTable();
            this._kyHieuChamCongDTO.MaKyHieu = "KH00001";
            DataTable dtKyHieu;
            dtKyHieu = this._kyHieuChamCongBLL.showLoadKyHieuChamCong(this._kyHieuChamCongDTO);
            for (int _kyHieu = 0; _kyHieu < dtKyHieu.Rows.Count; _kyHieu++)
            {
                sKHDiTre = dtKyHieu.Rows[_kyHieu]["DiTre"].ToString();
                sKHVeSom = dtKyHieu.Rows[_kyHieu]["VeSom"].ToString();
                sKHDungGio = dtKyHieu.Rows[_kyHieu]["DungGio"].ToString();
                sKHTangCa = dtKyHieu.Rows[_kyHieu]["TangCa"].ToString();
                sKHThieuGioVao = dtKyHieu.Rows[_kyHieu]["ThieuGioVao"].ToString();
                sKHThieuGioRa = dtKyHieu.Rows[_kyHieu]["ThieuGioRa"].ToString();
                sKHVang = dtKyHieu.Rows[_kyHieu]["Vang"].ToString();
                sKHChuaXepCa = dtKyHieu.Rows[_kyHieu]["ChuaXepCa"].ToString();
                sKHPhepNam = dtKyHieu.Rows[_kyHieu]["PhepNam"].ToString();
                sKHLe = dtKyHieu.Rows[_kyHieu]["Le"].ToString();
                sKHCongTac = dtKyHieu.Rows[_kyHieu]["CongTac"].ToString();
                sKHVeTre = dtKyHieu.Rows[_kyHieu]["VeTre"].ToString();
                sKHCuoiTuan = dtKyHieu.Rows[_kyHieu]["CuoiTuan"].ToString();
            }
            new DataTable();
            DataTable _dtNgayTinhCong;
            _dtNgayTinhCong = this._ngayTinhCongBLL.showThongTinNgayTinhCong();
            if (_dtNgayTinhCong.Rows.Count == 0)
            {
                _ngayTinhCongDTO.ID = 1;
                _ngayTinhCongDTO.NgayBatDau = Convert.ToDateTime(this.dateTimeTuNgay.Value);
                _ngayTinhCongDTO.NgayKetThuc = Convert.ToDateTime(this.dateTimeDenNgay.Value);
                _ngayTinhCongBLL.Insert_NgayTinhCong(this._ngayTinhCongDTO);
            }
            if (_dtNgayTinhCong.Rows.Count == 1)
            {
                _ngayTinhCongDTO.ID = 1;
                _ngayTinhCongDTO.NgayBatDau = Convert.ToDateTime(this.dateTimeTuNgay.Value);
                _ngayTinhCongDTO.NgayKetThuc = Convert.ToDateTime(this.dateTimeDenNgay.Value);
                _ngayTinhCongBLL.Update_NgayTinhCong(this._ngayTinhCongDTO);
            }
            DGVChiTietLuong.Rows.Clear();
            DGVTinhCong.Rows.Clear();
            DGVSuaXoaGioCham.Rows.Clear();
            sTongNgayTinh = Convert.ToInt32((this.dateTimeDenNgay.Value - this.dateTimeTuNgay.Value).TotalDays).ToString();
            if (Convert.ToInt32(this.sTongNgayTinh) < 0)
            {
                MessageBox.Show("Xin chọn lại ngày");
                return;
            }
            frm_LoadTinhCong _loadTinhCong;
            _loadTinhCong = new frm_LoadTinhCong();
            _loadTinhCong.Show();
            int demNhanVienDuocChon;
            demNhanVienDuocChon = 0;
            int demProcess;
            demProcess = -1;
            int testProcess;
            testProcess = TestDemNhanVien;

            var DanhSachNhanVien_check = (from DataGridViewRow r in DGVDanhSachNhanVien.Rows
                                 where Convert.ToBoolean(r.Cells[0].Value) == true
                                 select r).ToList();

            for (int abc = 0; abc < DanhSachNhanVien_check.Count; abc++)
            {
                this.iDemCuoiTuan = 0;
                int dem;
                dem = 0;
                string sLTCCLVNhanVien;
                sLTCCLVNhanVien = "LTCLV00001";
                int iThoiGianNhoNhat;
                iThoiGianNhoNhat = 20;
                int iThoiGianLonNhat;
                iThoiGianLonNhat = 960;
                int iKhoangCachGiuaHaiCapVaoRa;
                iKhoangCachGiuaHaiCapVaoRa = 30;

                this.dTongTienPhuCap = 0.0;
                this.dTongTienPhuCapTienCom = 0.0;
                this.dTongTienPhuCapKhac = 0.0;
                this.dTongTienTamUng = 0.0;
                this.dTongTienViPham = 0.0;
                this.dTongTienThuong = 0.0;
                this.demNhanVienNghiLeTinhCong = 0;
                this.demNhanVienVangTinhCong = 0;
                this.sMaChamCong = DanhSachNhanVien_check[abc].Cells[3].Value.ToString();
                this.sMaNhanVien = DanhSachNhanVien_check[abc].Cells[1].Value.ToString();
                this.sTenNhanVien = DanhSachNhanVien_check[abc].Cells[2].Value.ToString();
                this.sPhongBanTinhCong = DanhSachNhanVien_check[abc].Cells[7].Value.ToString();
                _loadTinhCong.lbTenNhanVien.Text = "Nhân viên: " + this.sTenNhanVien;
                Application.DoEvents();
               
                this.sNgayVaoLamViec = DanhSachNhanVien_check[abc].Cells[4].Value.ToString();
                for (int _tongNgay = 0; _tongNgay <= Convert.ToInt32(this.sTongNgayTinh); _tongNgay++)
                {
                    int iTinhBuTru;
                    iTinhBuTru = 0;
                    int kiemTraVao;
                    kiemTraVao = 0;
                    int kiemTraRa;
                    kiemTraRa = 0;
                    int _nhanVien;
                    _nhanVien = this.DGVTinhCong.Rows.Add();
                    this.DGVTinhCong.Rows[_nhanVien].Cells["MaNhanVien"].Value = this.sMaNhanVien;
                    this.DGVTinhCong.Rows[_nhanVien].Cells["TenNhanVien"].Value = this.sTenNhanVien;
                    DateTime dt;
                    dt = this.dateTimeTuNgay.Value;
                    DateTime dtDinhDang;
                    dtDinhDang = Convert.ToDateTime(dt.AddDays(dem).ToString());
                    string sNgayChamChuKyThang;
                    sNgayChamChuKyThang = dtDinhDang.Day.ToString();
                    string sNgayCham;
                    sNgayCham = $"{dtDinhDang:yyyy/MM/dd}";
                    string sThu;
                    sThu = DateTimeProgress.Test((int)dt.AddDays(dem).DayOfWeek);
                    this.DGVTinhCong.Rows[_nhanVien].Cells["Ngay"].Value = $"{dtDinhDang:yyyy/MM/dd}";

                    int iKiemTraSapXepCa;
                    iKiemTraSapXepCa = 0;
                    string ca = dt_ca.Rows.Cast<DataRow>().Where(x => x["MaChamCong"].ToString() == int.Parse(sMaNhanVien.Remove(0, 2)).ToString()).Select(x => x["D" + dtDinhDang.Day].ToString()).FirstOrDefault();
                    int iKiemTraLanChamTuDongKhongQuaDemLichTrinhVaoRa;
                    iKiemTraLanChamTuDongKhongQuaDemLichTrinhVaoRa = 0;
                    int iKiemTraLanChamKhoangCachTuDongKhongQuaDemLichTrinhVaoRa;
                    iKiemTraLanChamKhoangCachTuDongKhongQuaDemLichTrinhVaoRa = 0;
                    int iKiemTraDuLieuTuDong;
                    iKiemTraDuLieuTuDong = 0;
                    int iKiemTraLanCham;
                    iKiemTraLanCham = 0;
                    int addTuDong;
                    addTuDong = 1;
                    DateTime dGioVaoTuDong;
                    dGioVaoTuDong = default(DateTime);
                    DateTime dGioRaTuDong;
                    dGioRaTuDong = default(DateTime);
                    DateTime dGioVaoTuDongKhongQuaDemLichTrinhVaoRa;
                    dGioVaoTuDongKhongQuaDemLichTrinhVaoRa = default(DateTime);
                    DateTime dGioRaTuDongKhongQuaDemLichTrinhVaoRa;
                    dGioRaTuDongKhongQuaDemLichTrinhVaoRa = default(DateTime);
                    new DataTable();
                    DataTable dtTuDong;
                    dtTuDong = this._checkInOutBLL.getCheckInOutByMaChamCongAndNgayCham(Convert.ToInt32(this.sMaChamCong), Convert.ToDateTime(Convert.ToDateTime(this.DGVTinhCong.Rows[_nhanVien].Cells["Ngay"].Value.ToString())));
                    for (int iTuDong = 0; iTuDong < dtTuDong.Rows.Count; iTuDong++)
                    {
                        iKiemTraLanChamTuDongKhongQuaDemLichTrinhVaoRa++;
                        if (iKiemTraLanChamTuDongKhongQuaDemLichTrinhVaoRa == 1)
                        {
                            dGioVaoTuDongKhongQuaDemLichTrinhVaoRa = Convert.ToDateTime(dtTuDong.Rows[iTuDong]["GioCham"].ToString());
                            if (dtTuDong.Rows.Count > 2 && iKiemTraLanChamKhoangCachTuDongKhongQuaDemLichTrinhVaoRa == 3)
                            {
                                if (Convert.ToInt32(Convert.ToInt32((dGioVaoTuDongKhongQuaDemLichTrinhVaoRa - dGioRaTuDongKhongQuaDemLichTrinhVaoRa).TotalMinutes).ToString()) < iKhoangCachGiuaHaiCapVaoRa)
                                {
                                    iKiemTraLanChamTuDongKhongQuaDemLichTrinhVaoRa = 0;
                                    continue;
                                }
                                iKiemTraLanChamTuDongKhongQuaDemLichTrinhVaoRa = 1;
                            }
                        }
                        if (iKiemTraLanChamTuDongKhongQuaDemLichTrinhVaoRa == 2)
                        {
                            dGioRaTuDongKhongQuaDemLichTrinhVaoRa = Convert.ToDateTime(dtTuDong.Rows[iTuDong]["GioCham"].ToString());
                            if (Convert.ToInt32(Convert.ToInt32((dGioRaTuDongKhongQuaDemLichTrinhVaoRa - dGioVaoTuDongKhongQuaDemLichTrinhVaoRa).TotalMinutes).ToString()) < iThoiGianNhoNhat)
                            {
                                iKiemTraLanChamTuDongKhongQuaDemLichTrinhVaoRa = 1;
                                continue;
                            }
                            iKiemTraLanChamTuDongKhongQuaDemLichTrinhVaoRa = 0;
                            iKiemTraLanChamKhoangCachTuDongKhongQuaDemLichTrinhVaoRa = 3;
                        }
                        iKiemTraDuLieuTuDong = 1;
                        iKiemTraLanCham++;
                        if (iKiemTraLanCham == 1)
                        {
                            dGioVaoTuDong = Convert.ToDateTime(dtTuDong.Rows[iTuDong]["GioCham"].ToString());
                            DGVTinhCong.Rows[_nhanVien].Cells["Vao"].Value = string.Format(this.sDinhDangThoiGian, dGioVaoTuDong);
                            DGVTinhCong.Rows[_nhanVien].Cells["MaNhanVien"].Value = this.sMaNhanVien;
                            DGVTinhCong.Rows[_nhanVien].Cells["TenNhanVien"].Value = this.sTenNhanVien;
                            DGVTinhCong.Rows[_nhanVien].Cells["Ngay"].Value = this.DGVTinhCong.Rows[_nhanVien].Cells["Ngay"].Value.ToString();
                            DGVTinhCong.Rows[_nhanVien].Cells["Thu"].Value = DateTimeProgress.XuatThuTinhCong((int)dt.AddDays(dem).DayOfWeek);

                            int cellChiTietLichTrinhChoCaLamViecTuDongKhongQuaDem;
                            cellChiTietLichTrinhChoCaLamViecTuDongKhongQuaDem = 3;
                            while (true)
                            {
                                if (cellChiTietLichTrinhChoCaLamViecTuDongKhongQuaDem < 13)
                                {
                                    kiemTraVao = 0;
                                    kiemTraRa = 0;
                                    new DataTable();
                                    DataTable dtTuDongQuaDemCa5;
                                    dtTuDongQuaDemCa5 = this._caLamViecBLL.CaLamViecGetByMaCaLamViec(ca);
                                    int iTuDongQuaDemCa5;
                                    iTuDongQuaDemCa5 = 0;
                                    while (iTuDongQuaDemCa5 < dtTuDongQuaDemCa5.Rows.Count)
                                    {
                                        this.sTuDongQuaDemTenCaLamViec = dtTuDongQuaDemCa5.Rows[iTuDongQuaDemCa5]["CaLamViec"].ToString();
                                        DateTime dBatDauVaoB5;
                                        dBatDauVaoB5 = Convert.ToDateTime(sNgayCham + " " + string.Format("{0:T}", Convert.ToDateTime(dtTuDongQuaDemCa5.Rows[iTuDongQuaDemCa5]["BatDauVao"].ToString())));
                                        DateTime dKetThucVaoB5;
                                        dKetThucVaoB5 = Convert.ToDateTime(sNgayCham + " " + string.Format("{0:T}", Convert.ToDateTime(dtTuDongQuaDemCa5.Rows[iTuDongQuaDemCa5]["KetThucVao"].ToString())));
                                        DateTime dBatDauRaB5;
                                        dBatDauRaB5 = Convert.ToDateTime(sNgayCham + " " + string.Format("{0:T}", Convert.ToDateTime(dtTuDongQuaDemCa5.Rows[iTuDongQuaDemCa5]["BatDauRa"].ToString())));
                                        DateTime dKetThucRaB5;
                                        dKetThucRaB5 = Convert.ToDateTime(sNgayCham + " " + string.Format("{0:T}", Convert.ToDateTime(dtTuDongQuaDemCa5.Rows[iTuDongQuaDemCa5]["KetThucRa"].ToString())));
                                        if (dGioVaoTuDong >= dBatDauVaoB5 && dGioVaoTuDong <= dKetThucVaoB5)
                                        {
                                            kiemTraVao++;
                                        }
                                        if (dGioVaoTuDong >= dBatDauRaB5 && dGioVaoTuDong <= dKetThucRaB5)
                                        {
                                            kiemTraRa++;
                                        }
                                        if ((kiemTraVao != 1 || kiemTraRa != 0) && (kiemTraVao != 0 || kiemTraRa != 1))
                                        {
                                            iTuDongQuaDemCa5++;
                                            continue;
                                        }
                                        goto IL_9714;
                                    }

                                    this.DGVTinhCong.Rows[_nhanVien].Cells["Ca"].Value = ca;
                                    this.DGVTinhCong.Rows[_nhanVien].Cells["Cong"].Value = "0";
                                    this.DGVTinhCong.Rows[_nhanVien].Cells["Gio"].Value = "0";
                                    this.DGVTinhCong.Rows[_nhanVien].Cells["Tre"].Value = "0";
                                    this.DGVTinhCong.Rows[_nhanVien].Cells["VeSom"].Value = "0";
                                    this.DGVTinhCong.Rows[_nhanVien].Cells["VeTre"].Value = "0";
                                    this.DGVTinhCong.Rows[_nhanVien].Cells["TC1"].Value = "0";
                                    this.DGVTinhCong.Rows[_nhanVien].Cells["TC2"].Value = "0";
                                    this.DGVTinhCong.Rows[_nhanVien].Cells["TC3"].Value = "0";
                                    this.DGVTinhCong.Rows[_nhanVien].Cells["TC4"].Value = "0";
                                    this.DGVTinhCong.Rows[_nhanVien].Cells["TongGio"].Value = "0";
                                    this.DGVTinhCong.Rows[_nhanVien].Cells["DemCong"].Value = "0";
                                    this.DGVTinhCong.Rows[_nhanVien].Cells["KyHieu"].Value = this.sKHVang;
                                    if (DateTimeProgress.XuatIDThu((int)dt.AddDays(dem).DayOfWeek) == "0")
                                    {
                                        this.DGVTinhCong.Rows[_nhanVien].Cells["IDThu"].Value = "CN";
                                    }
                                    else
                                    {
                                        this.DGVTinhCong.Rows[_nhanVien].Cells["IDThu"].Value = "NT";
                                    }
                                    this.DGVTinhCong.Rows[_nhanVien].Cells["MaChamCong"].Value = this.sMaChamCong;
                                    this.DGVTinhCong.Rows[_nhanVien].Cells["PhongBan"].Value = this.sPhongBanTinhCong;
                                    break;
                                }
                                goto IL_9714;
                            IL_9714:
                                this.DGVTinhCong.Rows[_nhanVien].Cells["Ca"].Value = this.sTuDongQuaDemTenCaLamViec;
                                new DataTable();
                                DataTable dtCaLamViecFiloChamMotLan;
                                dtCaLamViecFiloChamMotLan = this._caLamViecBLL.CaLamViecGetByMaCaLamViec(sTuDongQuaDemMaCaLamViec);
                                for (int iCaLamViecFiLoChamMotLan = 0; iCaLamViecFiLoChamMotLan < dtCaLamViecFiloChamMotLan.Rows.Count; iCaLamViecFiLoChamMotLan++)
                                {
                                    string sGiayGioVao13;
                                    sGiayGioVao13 = dGioVaoTuDong.Second.ToString();
                                    DateTime dGioVaoKhaiBaoFiloB;
                                    dGioVaoKhaiBaoFiloB = Convert.ToDateTime(sNgayCham + " " + string.Format("{0:T}", Convert.ToDateTime(dtCaLamViecFiloChamMotLan.Rows[iCaLamViecFiLoChamMotLan]["GioVaoLamViec"].ToString())).Replace("00 ", sGiayGioVao13 + " "));
                                    if (Convert.ToInt32(dtCaLamViecFiloChamMotLan.Rows[iCaLamViecFiLoChamMotLan]["KhongCoGioRa"].ToString()) == 0)
                                    {
                                        this.DGVTinhCong.Rows[_nhanVien].Cells["Cong"].Value = "0";
                                        this.DGVTinhCong.Rows[_nhanVien].Cells["Gio"].Value = "0";
                                        this.DGVTinhCong.Rows[_nhanVien].Cells["Tre"].Value = "0";
                                        this.DGVTinhCong.Rows[_nhanVien].Cells["TongGio"].Value = "0";
                                        this.DGVTinhCong.Rows[_nhanVien].Cells["DemCong"].Value = "0";
                                    }
                                    else if (kiemTraVao != 0)
                                    {
                                        string sTruGioDiTre11;
                                        sTruGioDiTre11 = dtCaLamViecFiloChamMotLan.Rows[iCaLamViecFiLoChamMotLan]["TruGioDiTre"].ToString();
                                        string sBatDauTinhDiTre11;
                                        sBatDauTinhDiTre11 = dtCaLamViecFiloChamMotLan.Rows[iCaLamViecFiLoChamMotLan]["BatDauTinhDiTre"].ToString();
                                        int iChoPhepDiTre8;
                                        iChoPhepDiTre8 = Convert.ToInt32(dtCaLamViecFiloChamMotLan.Rows[iCaLamViecFiLoChamMotLan]["ChoPhepDiTre"].ToString());
                                        string sPhutTre8;
                                        sPhutTre8 = Convert.ToInt32((dGioVaoTuDong - dGioVaoKhaiBaoFiloB).TotalMinutes).ToString();
                                        if (sTruGioDiTre11 == "True")
                                        {
                                            if (Convert.ToInt32(sPhutTre8) < 0)
                                            {
                                                this.DGVTinhCong.Rows[_nhanVien].Cells["Tre"].Value = "0";
                                            }
                                            else
                                            {
                                                int iPhutTre8;
                                                iPhutTre8 = Convert.ToInt32(sPhutTre8) - iChoPhepDiTre8;
                                                if (sBatDauTinhDiTre11 == "True")
                                                {
                                                    if (iPhutTre8 < 1)
                                                    {
                                                        this.DGVTinhCong.Rows[_nhanVien].Cells["Tre"].Value = "0";
                                                    }
                                                    else
                                                    {
                                                        this.DGVTinhCong.Rows[_nhanVien].Cells["Tre"].Value = iPhutTre8.ToString();
                                                    }
                                                }
                                                else if (iPhutTre8 < 1)
                                                {
                                                    this.DGVTinhCong.Rows[_nhanVien].Cells["Tre"].Value = "0";
                                                }
                                                else
                                                {
                                                    this.DGVTinhCong.Rows[_nhanVien].Cells["Tre"].Value = sPhutTre8;
                                                }
                                            }
                                        }
                                        else
                                        {
                                            this.DGVTinhCong.Rows[_nhanVien].Cells["Tre"].Value = "0";
                                        }
                                        double dGioChamMotLan;
                                        dGioChamMotLan = Math.Round((Convert.ToDouble(dtCaLamViecFiloChamMotLan.Rows[iCaLamViecFiLoChamMotLan]["KhongCoGioRa"].ToString()) - Convert.ToDouble(this.DGVTinhCong.Rows[_nhanVien].Cells[9].Value.ToString())) / 60.0, this.iLamTronGio);
                                        this.DGVTinhCong.Rows[_nhanVien].Cells["Gio"].Value = dGioChamMotLan.ToString();
                                        Math.Round(Convert.ToDouble(dtCaLamViecFiloChamMotLan.Rows[iCaLamViecFiLoChamMotLan]["KhongCoGioRa"].ToString()) / 60.0, 2);
                                        double dCongChamMotLan;
                                        dCongChamMotLan = Math.Round(dGioChamMotLan * Convert.ToDouble(dtCaLamViecFiloChamMotLan.Rows[iCaLamViecFiLoChamMotLan]["CongTinh"].ToString()) / Convert.ToDouble(dtCaLamViecFiloChamMotLan.Rows[iCaLamViecFiLoChamMotLan]["TongGioTrongCaLamViec"].ToString()), this.iLamTronCong);
                                        this.DGVTinhCong.Rows[_nhanVien].Cells["Cong"].Value = dCongChamMotLan.ToString();
                                    }
                                    if (Convert.ToInt32(dtCaLamViecFiloChamMotLan.Rows[iCaLamViecFiLoChamMotLan]["KhongCoGioVao"].ToString()) == 0)
                                    {
                                        this.DGVTinhCong.Rows[_nhanVien].Cells["Cong"].Value = "0";
                                        this.DGVTinhCong.Rows[_nhanVien].Cells["Gio"].Value = "0";
                                        this.DGVTinhCong.Rows[_nhanVien].Cells["Tre"].Value = "0";
                                        this.DGVTinhCong.Rows[_nhanVien].Cells["TongGio"].Value = "0";
                                        this.DGVTinhCong.Rows[_nhanVien].Cells["DemCong"].Value = "0";
                                    }
                                    else if (kiemTraRa != 0)
                                    {
                                        string sTruGioVeSom11;
                                        sTruGioVeSom11 = dtCaLamViecFiloChamMotLan.Rows[iCaLamViecFiLoChamMotLan]["TruGioVeSom"].ToString();
                                        string sBatDauTinhVeSom11;
                                        sBatDauTinhVeSom11 = dtCaLamViecFiloChamMotLan.Rows[iCaLamViecFiLoChamMotLan]["BatDauTinhVeSom"].ToString();
                                        int iChoPhepVeSom8;
                                        iChoPhepVeSom8 = Convert.ToInt32(dtCaLamViecFiloChamMotLan.Rows[iCaLamViecFiLoChamMotLan]["ChoPhepVeSom"].ToString());
                                        string sGiayGioRa14;
                                        sGiayGioRa14 = dGioVaoTuDong.Second.ToString();
                                        string sPhutVeSom8;
                                        sPhutVeSom8 = Convert.ToInt32((Convert.ToDateTime(sNgayCham + " " + string.Format("{0:T}", Convert.ToDateTime(dtCaLamViecFiloChamMotLan.Rows[iCaLamViecFiLoChamMotLan]["GioKetThucLamViec"].ToString())).Replace("00 ", sGiayGioRa14 + " ")) - dGioVaoTuDong).TotalMinutes).ToString();
                                        if (sTruGioVeSom11 == "True")
                                        {
                                            if (Convert.ToInt32(sPhutVeSom8) < 0)
                                            {
                                                this.DGVTinhCong.Rows[_nhanVien].Cells["VeSom"].Value = "0";
                                            }
                                            else
                                            {
                                                int iPhutVeSom8;
                                                iPhutVeSom8 = Convert.ToInt32(sPhutVeSom8) - iChoPhepVeSom8;
                                                if (iPhutVeSom8 < 1)
                                                {
                                                    this.DGVTinhCong.Rows[_nhanVien].Cells["VeSom"].Value = "0";
                                                }
                                                else if (sBatDauTinhVeSom11 == "True")
                                                {
                                                    this.DGVTinhCong.Rows[_nhanVien].Cells["VeSom"].Value = iPhutVeSom8.ToString();
                                                }
                                                else
                                                {
                                                    this.DGVTinhCong.Rows[_nhanVien].Cells["VeSom"].Value = sPhutVeSom8;
                                                }
                                            }
                                        }
                                        else
                                        {
                                            this.DGVTinhCong.Rows[_nhanVien].Cells["VeSom"].Value = "0";
                                        }
                                        double dGioChamMotLan2;
                                        dGioChamMotLan2 = Math.Round((Convert.ToDouble(dtCaLamViecFiloChamMotLan.Rows[iCaLamViecFiLoChamMotLan]["KhongCoGioVao"].ToString()) - Convert.ToDouble(this.DGVTinhCong.Rows[_nhanVien].Cells["VeSom"].Value.ToString())) / 60.0, this.iLamTronGio);
                                        this.DGVTinhCong.Rows[_nhanVien].Cells["Gio"].Value = dGioChamMotLan2.ToString();
                                        Math.Round(Convert.ToDouble(dtCaLamViecFiloChamMotLan.Rows[iCaLamViecFiLoChamMotLan]["KhongCoGioRa"].ToString()) / 60.0, 2);
                                        double dCongChamMotLan2;
                                        dCongChamMotLan2 = Math.Round(dGioChamMotLan2 * Convert.ToDouble(dtCaLamViecFiloChamMotLan.Rows[iCaLamViecFiLoChamMotLan]["CongTinh"].ToString()) / Convert.ToDouble(dtCaLamViecFiloChamMotLan.Rows[iCaLamViecFiLoChamMotLan]["TongGioTrongCaLamViec"].ToString()), this.iLamTronCong);
                                        this.DGVTinhCong.Rows[_nhanVien].Cells["Cong"].Value = dCongChamMotLan2.ToString();
                                    }
                                    this.DGVTinhCong.Rows[_nhanVien].Cells["VeSom"].Value = "0";
                                    this.DGVTinhCong.Rows[_nhanVien].Cells["VeTre"].Value = "0";
                                    this.DGVTinhCong.Rows[_nhanVien].Cells["TC1"].Value = "0";
                                    this.DGVTinhCong.Rows[_nhanVien].Cells["TC2"].Value = "0";
                                    this.DGVTinhCong.Rows[_nhanVien].Cells["TC3"].Value = "0";
                                    this.DGVTinhCong.Rows[_nhanVien].Cells["TC4"].Value = "0";
                                    this.DGVTinhCong.Rows[_nhanVien].Cells["TongGio"].Value = "0";
                                    this.DGVTinhCong.Rows[_nhanVien].Cells["DemCong"].Value = dtCaLamViecFiloChamMotLan.Rows[iCaLamViecFiLoChamMotLan]["CongTinh"].ToString();
                                    this.DGVTinhCong.Rows[_nhanVien].Cells["KyHieu"].Value = this.sKHThieuGioRa;
                                    if (DateTimeProgress.XuatIDThu((int)dt.AddDays(dem).DayOfWeek) == "0")
                                    {
                                        this.DGVTinhCong.Rows[_nhanVien].Cells["IDThu"].Value = "CN";
                                    }
                                    else
                                    {
                                        this.DGVTinhCong.Rows[_nhanVien].Cells["IDThu"].Value = "NT";
                                    }
                                    this.DGVTinhCong.Rows[_nhanVien].Cells["MaChamCong"].Value = this.sMaChamCong;
                                    this.DGVTinhCong.Rows[_nhanVien].Cells["PhongBan"].Value = this.sPhongBanTinhCong;
                                }
                                break;
                            }
                            _ = dtTuDong.Rows.Count;
                        }
                        if (iKiemTraLanCham == 2)
                        {
                            dGioRaTuDong = Convert.ToDateTime(dtTuDong.Rows[iTuDong]["GioCham"].ToString());
                            Convert.ToInt32((dGioRaTuDong - dGioVaoTuDong).TotalMinutes);
                            if (Convert.ToInt32(Convert.ToInt32((dGioRaTuDongKhongQuaDemLichTrinhVaoRa - dGioVaoTuDongKhongQuaDemLichTrinhVaoRa).TotalMinutes).ToString()) > iThoiGianLonNhat)
                            {
                                int addTuDongKhongQuaDemThoiGianLonNhat;
                                addTuDongKhongQuaDemThoiGianLonNhat = this.DGVTinhCong.Rows.Add();
                                this.DGVTinhCong.Rows[addTuDongKhongQuaDemThoiGianLonNhat].Cells["MaNhanVien"].Value = this.sMaNhanVien;
                                this.DGVTinhCong.Rows[addTuDongKhongQuaDemThoiGianLonNhat].Cells["TenNhanVien"].Value = this.sTenNhanVien;
                                this.DGVTinhCong.Rows[addTuDongKhongQuaDemThoiGianLonNhat].Cells["Ngay"].Value = this.DGVTinhCong.Rows[_nhanVien].Cells["Ngay"].Value.ToString();
                                this.DGVTinhCong.Rows[addTuDongKhongQuaDemThoiGianLonNhat].Cells["Thu"].Value = DateTimeProgress.XuatThuTinhCong((int)dt.AddDays(dem).DayOfWeek);
                                this.DGVTinhCong.Rows[addTuDongKhongQuaDemThoiGianLonNhat].Cells["Ca"].Value = ca;
                                this.DGVTinhCong.Rows[addTuDongKhongQuaDemThoiGianLonNhat].Cells["Ra"].Value = string.Format(this.sDinhDangThoiGian, dGioRaTuDong);
                                this.DGVTinhCong.Rows[addTuDongKhongQuaDemThoiGianLonNhat].Cells["Cong"].Value = "0";
                                this.DGVTinhCong.Rows[addTuDongKhongQuaDemThoiGianLonNhat].Cells["Gio"].Value = "0";
                                this.DGVTinhCong.Rows[addTuDongKhongQuaDemThoiGianLonNhat].Cells["Tre"].Value = "0";
                                this.DGVTinhCong.Rows[addTuDongKhongQuaDemThoiGianLonNhat].Cells["VeSom"].Value = "0";
                                this.DGVTinhCong.Rows[addTuDongKhongQuaDemThoiGianLonNhat].Cells["VeTre"].Value = "0";
                                this.DGVTinhCong.Rows[addTuDongKhongQuaDemThoiGianLonNhat].Cells["TC1"].Value = "0";
                                this.DGVTinhCong.Rows[addTuDongKhongQuaDemThoiGianLonNhat].Cells["TC2"].Value = "0";
                                this.DGVTinhCong.Rows[addTuDongKhongQuaDemThoiGianLonNhat].Cells["TC3"].Value = "0";
                                this.DGVTinhCong.Rows[addTuDongKhongQuaDemThoiGianLonNhat].Cells["TC4"].Value = "0";
                                this.DGVTinhCong.Rows[addTuDongKhongQuaDemThoiGianLonNhat].Cells["TongGio"].Value = "0";
                                this.DGVTinhCong.Rows[addTuDongKhongQuaDemThoiGianLonNhat].Cells["DemCong"].Value = "0";
                                this.DGVTinhCong.Rows[addTuDongKhongQuaDemThoiGianLonNhat].Cells["KyHieu"].Value = this.sKHVang;
                                if (DateTimeProgress.XuatIDThu((int)dt.AddDays(dem).DayOfWeek) == "0")
                                {
                                    this.DGVTinhCong.Rows[addTuDongKhongQuaDemThoiGianLonNhat].Cells["IDThu"].Value = "CN";
                                }
                                else
                                {
                                    this.DGVTinhCong.Rows[addTuDongKhongQuaDemThoiGianLonNhat].Cells["IDThu"].Value = "NT";
                                }
                                this.DGVTinhCong.Rows[addTuDongKhongQuaDemThoiGianLonNhat].Cells["MaChamCong"].Value = this.sMaChamCong;
                                this.DGVTinhCong.Rows[addTuDongKhongQuaDemThoiGianLonNhat].Cells["PhongBan"].Value = this.sPhongBanTinhCong;
                            }
                            else
                            {
                                this.DGVTinhCong.Rows[_nhanVien].Cells["Ra"].Value = string.Format(this.sDinhDangThoiGian, dGioRaTuDong);
                                int cellChiTietLichTrinhChoCaLamViecTuDongKhongQuaDem2;
                                cellChiTietLichTrinhChoCaLamViecTuDongKhongQuaDem2 = 3;
                                while (true)
                                {
                                    if (cellChiTietLichTrinhChoCaLamViecTuDongKhongQuaDem2 < 13)
                                    {
                                        this.DGVTinhCong.Rows[_nhanVien].Cells["Ca"].Value = ca;
                                        this.DGVTinhCong.Rows[_nhanVien].Cells["Cong"].Value = "0";
                                        this.DGVTinhCong.Rows[_nhanVien].Cells["Gio"].Value = "0";
                                        this.DGVTinhCong.Rows[_nhanVien].Cells["Tre"].Value = "0";
                                        this.DGVTinhCong.Rows[_nhanVien].Cells["VeSom"].Value = "0";
                                        this.DGVTinhCong.Rows[_nhanVien].Cells["VeTre"].Value = "0";
                                        this.DGVTinhCong.Rows[_nhanVien].Cells["TC1"].Value = "0";
                                        this.DGVTinhCong.Rows[_nhanVien].Cells["TC2"].Value = "0";
                                        this.DGVTinhCong.Rows[_nhanVien].Cells["TC3"].Value = "0";
                                        this.DGVTinhCong.Rows[_nhanVien].Cells["TC4"].Value = "0";
                                        this.DGVTinhCong.Rows[_nhanVien].Cells["TongGio"].Value = "0";
                                        this.DGVTinhCong.Rows[_nhanVien].Cells["DemCong"].Value = "0";
                                        this.DGVTinhCong.Rows[_nhanVien].Cells["KyHieu"].Value = this.sKHVang;

                                        kiemTraVao = 0;
                                        kiemTraRa = 0;
                                        new DataTable();
                                        DataTable dtTuDongQuaDemCa7;
                                        dtTuDongQuaDemCa7 = this._caLamViecBLL.CaLamViecGetByMaCaLamViec(ca);
                                        int iTuDongQuaDemCa7;
                                        iTuDongQuaDemCa7 = 0;
                                        while (iTuDongQuaDemCa7 < dtTuDongQuaDemCa7.Rows.Count)
                                        {
                                            string sGiayGioVao16;
                                            sGiayGioVao16 = dGioVaoTuDong.Second.ToString();
                                            string sGiayGioRa16;
                                            sGiayGioRa16 = dGioRaTuDong.Second.ToString();
                                            this.sTuDongQuaDemTenCaLamViec = dtTuDongQuaDemCa7.Rows[iTuDongQuaDemCa7]["CaLamViec"].ToString();
                                            DateTime dBatDauVaoB7;
                                            dBatDauVaoB7 = Convert.ToDateTime(sNgayCham + " " + string.Format("{0:T}", Convert.ToDateTime(dtTuDongQuaDemCa7.Rows[iTuDongQuaDemCa7]["GioVaoLamViec"].ToString())).Replace("00 ", sGiayGioVao16 + " "));
                                            DateTime dKetThucVaoB7;
                                            dKetThucVaoB7 = Convert.ToDateTime(sNgayCham + " " + string.Format("{0:T}", Convert.ToDateTime(dtTuDongQuaDemCa7.Rows[iTuDongQuaDemCa7]["GioKetThucLamViec"].ToString())).Replace("00 ", sGiayGioVao16 + " "));
                                            DateTime dBatDauRaB8;
                                            dBatDauRaB8 = Convert.ToDateTime(sNgayCham + " " + string.Format("{0:T}", Convert.ToDateTime(dtTuDongQuaDemCa7.Rows[iTuDongQuaDemCa7]["GioVaoLamViec"].ToString())).Replace("00 ", sGiayGioRa16 + " "));
                                            DateTime dKetThucRaB8;
                                            dKetThucRaB8 = Convert.ToDateTime(sNgayCham + " " + string.Format("{0:T}", Convert.ToDateTime(dtTuDongQuaDemCa7.Rows[iTuDongQuaDemCa7]["GioKetThucLamViec"].ToString())).Replace("00 ", sGiayGioRa16 + " "));
                                            if (dtTuDongQuaDemCa7.Rows[iTuDongQuaDemCa7]["TinhBuTru"].ToString() == "True")
                                            {
                                                iTinhBuTru++;
                                            }
                                            if (dGioVaoTuDong >= dBatDauVaoB7 && dGioVaoTuDong <= dKetThucVaoB7)
                                            {
                                                TimeSpan vaomuon = TimeSpan.Parse(dGioVaoTuDong.ToString("HH:mm:ss")).Subtract(TimeSpan.Parse(dBatDauVaoB7.ToString("HH:mm:ss")));
                                                DGVTinhCong.Rows[_nhanVien].Cells["Tre"].Value = (int)vaomuon.TotalMinutes;
                                                kiemTraVao++;
                                            }
                                            if (dGioRaTuDong >= dBatDauRaB8 && dGioRaTuDong <= dKetThucRaB8)
                                            {
                                                TimeSpan vaomuon = TimeSpan.Parse(dKetThucRaB8.ToString("HH:mm:ss")).Subtract(TimeSpan.Parse(dGioRaTuDong.ToString("HH:mm:ss")));
                                                DGVTinhCong.Rows[_nhanVien].Cells["VeSom"].Value = (int)vaomuon.TotalMinutes;
                                                kiemTraRa++;
                                            }
                                            if (kiemTraVao != 1 || kiemTraRa != 1)
                                            {
                                                iTuDongQuaDemCa7++;
                                                continue;
                                            }
                                            goto IL_af91;
                                        }

                                        if (DateTimeProgress.XuatIDThu((int)dt.AddDays(dem).DayOfWeek) == "0")
                                        {
                                            this.DGVTinhCong.Rows[_nhanVien].Cells["IDThu"].Value = "CN";
                                        }
                                        else
                                        {
                                            this.DGVTinhCong.Rows[_nhanVien].Cells["IDThu"].Value = "NT";
                                        }
                                        this.DGVTinhCong.Rows[_nhanVien].Cells["MaChamCong"].Value = this.sMaChamCong;
                                        this.DGVTinhCong.Rows[_nhanVien].Cells["PhongBan"].Value = this.sPhongBanTinhCong;
                                        break;
                                    }
                                    goto IL_af91;
                                IL_af91:
                                    this.DGVTinhCong.Rows[_nhanVien].Cells["Ca"].Value = ca;
                                    new DataTable();
                                    DataTable dtCaLamViecTuDongKhongQuaDem;
                                    dtCaLamViecTuDongKhongQuaDem = this._caLamViecBLL.CaLamViecGetByMaCaLamViec(ca);
                                    for (int iCaLamViecTuDongKhongQuaDem = 0; iCaLamViecTuDongKhongQuaDem < dtCaLamViecTuDongKhongQuaDem.Rows.Count; iCaLamViecTuDongKhongQuaDem++)
                                    {
                                        // tang ca
                                        DataTable tangca = _tangCaBLL.GetTangCaByMaChamCong(sMaChamCong, sNgayCham);
                                        if(tangca.Rows.Count > 0)
                                        {
                                            for(int i = 0; i < tangca.Rows.Count; i ++)
                                            {
                                                TimeSpan giolam = DateTime.Parse(tangca.Rows[i]["GioKetThuc"].ToString()).Subtract(DateTime.Parse(tangca.Rows[i]["GioBatDau"].ToString()));
                                                DGVTinhCong.Rows[_nhanVien].Cells["TC" + (i + 1)].Value = giolam.TotalHours;
                                                DGVTinhCong.Rows[_nhanVien].Cells["GioBatDau" + (i + 1)].Value = tangca.Rows[i]["GioBatDau"].ToString();
                                                DGVTinhCong.Rows[_nhanVien].Cells["GioKetThuc" + (i + 1)].Value = tangca.Rows[i]["GioKetThuc"].ToString();
                                            }
                                        }

                                        //string sGiayGioVao17;
                                        //sGiayGioVao17 = dGioVaoTuDong.Second.ToString();
                                        //string sGiayGioRa17;
                                        //sGiayGioRa17 = dGioRaTuDong.Second.ToString();
                                        //DateTime dGioVaoKhaiBaoTuDongKhongQuaDemB;
                                        //dGioVaoKhaiBaoTuDongKhongQuaDemB = Convert.ToDateTime(sNgayCham + " " + string.Format("{0:T}", Convert.ToDateTime(dtCaLamViecTuDongKhongQuaDem.Rows[iCaLamViecTuDongKhongQuaDem]["GioVaoLamViec"].ToString())).Replace("00 ", sGiayGioVao17 + " "));
                                        //DateTime dGioRaKhaiBaoTuDongKhongQuaDemB;
                                        //dGioRaKhaiBaoTuDongKhongQuaDemB = Convert.ToDateTime(sNgayCham + " " + string.Format("{0:T}", Convert.ToDateTime(dtCaLamViecTuDongKhongQuaDem.Rows[iCaLamViecTuDongKhongQuaDem]["GioKetThucLamViec"].ToString())).Replace("00 ", sGiayGioRa17 + " "));
                                        //string sXemCaNayLaTangCa4;
                                        //sXemCaNayLaTangCa4 = dtCaLamViecTuDongKhongQuaDem.Rows[iCaLamViecTuDongKhongQuaDem]["XemCaNayLaTangCa"].ToString();
                                        //int iTangCaMuc4;
                                        //iTangCaMuc4 = Convert.ToInt32(dtCaLamViecTuDongKhongQuaDem.Rows[iCaLamViecTuDongKhongQuaDem]["TangCaMuc"].ToString());
                                        //string sXemChuNhatLaTangCa;
                                        //sXemChuNhatLaTangCa = dtCaLamViecTuDongKhongQuaDem.Rows[iCaLamViecTuDongKhongQuaDem]["XemCuoiTuanLaTangCa"].ToString();
                                        //int iTangCaChuNhatMuc;
                                        //iTangCaChuNhatMuc = Convert.ToInt32(dtCaLamViecTuDongKhongQuaDem.Rows[iCaLamViecTuDongKhongQuaDem]["TangCaCuoiTuanMuc"].ToString());
                                        //if (sXemCaNayLaTangCa4 == "True")
                                        //{
                                        //    dtCaLamViecTuDongKhongQuaDem.Rows[iCaLamViecTuDongKhongQuaDem]["TruGioDiTre"].ToString();
                                        //    dtCaLamViecTuDongKhongQuaDem.Rows[iCaLamViecTuDongKhongQuaDem]["BatDauTinhDiTre"].ToString();
                                        //    Convert.ToInt32(dtCaLamViecTuDongKhongQuaDem.Rows[iCaLamViecTuDongKhongQuaDem]["ChoPhepDiTre"].ToString());
                                        //    string sPhutTre14;
                                        //    sPhutTre14 = Convert.ToInt32((dGioVaoTuDong - dGioVaoKhaiBaoTuDongKhongQuaDemB).TotalMinutes).ToString();
                                        //    if (Convert.ToInt32(sPhutTre14) < 0)
                                        //    {
                                        //        sPhutTre14 = "0";
                                        //    }
                                        //    dtCaLamViecTuDongKhongQuaDem.Rows[iCaLamViecTuDongKhongQuaDem]["TruGioVeSom"].ToString();
                                        //    dtCaLamViecTuDongKhongQuaDem.Rows[iCaLamViecTuDongKhongQuaDem]["BatDauTinhVeSom"].ToString();
                                        //    Convert.ToInt32(dtCaLamViecTuDongKhongQuaDem.Rows[iCaLamViecTuDongKhongQuaDem]["ChoPhepVeSom"].ToString());
                                        //    string sPhutVeSom14;
                                        //    sPhutVeSom14 = Convert.ToInt32((dGioRaKhaiBaoTuDongKhongQuaDemB - dGioRaTuDong).TotalMinutes).ToString();
                                        //    if (Convert.ToInt32(sPhutVeSom14) < 0)
                                        //    {
                                        //        sPhutVeSom14 = "0";
                                        //    }
                                        //    double dTongGioTangCaTuDongKhongQuaDem;
                                        //    dTongGioTangCaTuDongKhongQuaDem = Math.Round((Convert.ToDouble(dtCaLamViecTuDongKhongQuaDem.Rows[iCaLamViecTuDongKhongQuaDem]["TongGioTrongCaLamViec"]) * 60.0 - (Convert.ToDouble(sPhutTre14) + Convert.ToDouble(sPhutVeSom14))) / 60.0, this.iLamTronGio);
                                        //    if (iTangCaMuc4 == 1)
                                        //    {
                                        //        this.DGVTinhCong.Rows[_nhanVien].Cells["Cong"].Value = "0";
                                        //        this.DGVTinhCong.Rows[_nhanVien].Cells["Gio"].Value = "0";
                                        //        this.DGVTinhCong.Rows[_nhanVien].Cells[12].Value = dTongGioTangCaTuDongKhongQuaDem * this.dTangCa1HeSo;
                                        //        this.DGVTinhCong.Rows[_nhanVien].Cells["KyHieu"].Value = this.sKHDungGio;
                                        //    }
                                        //    if (iTangCaMuc4 == 2)
                                        //    {
                                        //        this.DGVTinhCong.Rows[_nhanVien].Cells["Cong"].Value = "0";
                                        //        this.DGVTinhCong.Rows[_nhanVien].Cells["Gio"].Value = "0";
                                        //        this.DGVTinhCong.Rows[_nhanVien].Cells[13].Value = dTongGioTangCaTuDongKhongQuaDem * this.dTangCa2HeSo;
                                        //        this.DGVTinhCong.Rows[_nhanVien].Cells["KyHieu"].Value = this.sKHDungGio;
                                        //    }
                                        //    if (iTangCaMuc4 == 3)
                                        //    {
                                        //        this.DGVTinhCong.Rows[_nhanVien].Cells["Cong"].Value = "0";
                                        //        this.DGVTinhCong.Rows[_nhanVien].Cells["Gio"].Value = "0";
                                        //        this.DGVTinhCong.Rows[_nhanVien].Cells[14].Value = dTongGioTangCaTuDongKhongQuaDem * this.dTangCa3HeSo;
                                        //        this.DGVTinhCong.Rows[_nhanVien].Cells["KyHieu"].Value = this.sKHDungGio;
                                        //    }
                                        //    if (iTangCaMuc4 == 4)
                                        //    {
                                        //        this.DGVTinhCong.Rows[_nhanVien].Cells["Cong"].Value = "0";
                                        //        this.DGVTinhCong.Rows[_nhanVien].Cells["Gio"].Value = "0";
                                        //        this.DGVTinhCong.Rows[_nhanVien].Cells[15].Value = dTongGioTangCaTuDongKhongQuaDem * this.dTangCa4HeSo;
                                        //        this.DGVTinhCong.Rows[_nhanVien].Cells["KyHieu"].Value = this.sKHDungGio;
                                        //    }
                                        //    continue;
                                        //}
                                        //if (DateTimeProgress.XuatIDThu((int)dt.AddDays(dem).DayOfWeek) == "0")
                                        //{
                                        //    if (sXemChuNhatLaTangCa == "True")
                                        //    {
                                        //        dtCaLamViecTuDongKhongQuaDem.Rows[iCaLamViecTuDongKhongQuaDem]["TruGioDiTre"].ToString();
                                        //        dtCaLamViecTuDongKhongQuaDem.Rows[iCaLamViecTuDongKhongQuaDem]["BatDauTinhDiTre"].ToString();
                                        //        Convert.ToInt32(dtCaLamViecTuDongKhongQuaDem.Rows[iCaLamViecTuDongKhongQuaDem]["ChoPhepDiTre"].ToString());
                                        //        string sPhutTre12;
                                        //        sPhutTre12 = Convert.ToInt32((dGioVaoTuDong - dGioVaoKhaiBaoTuDongKhongQuaDemB).TotalMinutes).ToString();
                                        //        if (Convert.ToInt32(sPhutTre12) < 0)
                                        //        {
                                        //            sPhutTre12 = "0";
                                        //        }
                                        //        dtCaLamViecTuDongKhongQuaDem.Rows[iCaLamViecTuDongKhongQuaDem]["TruGioVeSom"].ToString();
                                        //        dtCaLamViecTuDongKhongQuaDem.Rows[iCaLamViecTuDongKhongQuaDem]["BatDauTinhVeSom"].ToString();
                                        //        Convert.ToInt32(dtCaLamViecTuDongKhongQuaDem.Rows[iCaLamViecTuDongKhongQuaDem]["ChoPhepVeSom"].ToString());
                                        //        string sPhutVeSom13;
                                        //        sPhutVeSom13 = Convert.ToInt32((dGioRaKhaiBaoTuDongKhongQuaDemB - dGioRaTuDong).TotalMinutes).ToString();
                                        //        if (Convert.ToInt32(sPhutVeSom13) < 0)
                                        //        {
                                        //            sPhutVeSom13 = "0";
                                        //        }
                                        //        double dTongGioTangCaTuDongKhongQuaDemA;
                                        //        dTongGioTangCaTuDongKhongQuaDemA = Math.Round((Convert.ToDouble(dtCaLamViecTuDongKhongQuaDem.Rows[iCaLamViecTuDongKhongQuaDem]["TongGioTrongCaLamViec"]) * 60.0 - (Convert.ToDouble(sPhutTre12) + Convert.ToDouble(sPhutVeSom13))) / 60.0, this.iLamTronGio);
                                        //        if (iTangCaChuNhatMuc == 1)
                                        //        {
                                        //            if (dTongGioTangCaTuDongKhongQuaDemA <= 3.0)
                                        //            {
                                        //                this.DGVTinhCong.Rows[_nhanVien].Cells[12].Value = dTongGioTangCaTuDongKhongQuaDemA * this.dTangCaChuNhatHeSo;
                                        //            }
                                        //            else
                                        //            {
                                        //                this.DGVTinhCong.Rows[_nhanVien].Cells[12].Value = 3.0 * this.dTangCaChuNhatHeSo;
                                        //            }
                                        //            this.DGVTinhCong.Rows[_nhanVien].Cells["KyHieu"].Value = this.sKHDungGio;
                                        //        }
                                        //        if (iTangCaChuNhatMuc == 2)
                                        //        {
                                        //            this.DGVTinhCong.Rows[_nhanVien].Cells["Cong"].Value = "0";
                                        //            this.DGVTinhCong.Rows[_nhanVien].Cells["Gio"].Value = "0";
                                        //            this.DGVTinhCong.Rows[_nhanVien].Cells[13].Value = dTongGioTangCaTuDongKhongQuaDemA * this.dTangCaChuNhatHeSo;
                                        //            this.DGVTinhCong.Rows[_nhanVien].Cells["KyHieu"].Value = this.sKHDungGio;
                                        //        }
                                        //        if (iTangCaChuNhatMuc == 3)
                                        //        {
                                        //            this.DGVTinhCong.Rows[_nhanVien].Cells["Cong"].Value = "0";
                                        //            this.DGVTinhCong.Rows[_nhanVien].Cells["Gio"].Value = "0";
                                        //            this.DGVTinhCong.Rows[_nhanVien].Cells[14].Value = dTongGioTangCaTuDongKhongQuaDemA * this.dTangCaChuNhatHeSo;
                                        //            this.DGVTinhCong.Rows[_nhanVien].Cells["KyHieu"].Value = this.sKHDungGio;
                                        //        }
                                        //        if (iTangCaChuNhatMuc == 4)
                                        //        {
                                        //            this.DGVTinhCong.Rows[_nhanVien].Cells["Cong"].Value = "0";
                                        //            this.DGVTinhCong.Rows[_nhanVien].Cells["Gio"].Value = "0";
                                        //            this.DGVTinhCong.Rows[_nhanVien].Cells[15].Value = dTongGioTangCaTuDongKhongQuaDemA * this.dTangCaChuNhatHeSo;
                                        //            this.DGVTinhCong.Rows[_nhanVien].Cells["KyHieu"].Value = this.sKHDungGio;
                                        //        }
                                        //        continue;
                                        //    }
                                        //    string sTruGioDiTre14;
                                        //    sTruGioDiTre14 = dtCaLamViecTuDongKhongQuaDem.Rows[iCaLamViecTuDongKhongQuaDem]["TruGioDiTre"].ToString();
                                        //    string sBatDauTinhDiTre14;
                                        //    sBatDauTinhDiTre14 = dtCaLamViecTuDongKhongQuaDem.Rows[iCaLamViecTuDongKhongQuaDem]["BatDauTinhDiTre"].ToString();
                                        //    int iChoPhepDiTre11;
                                        //    iChoPhepDiTre11 = Convert.ToInt32(dtCaLamViecTuDongKhongQuaDem.Rows[iCaLamViecTuDongKhongQuaDem]["ChoPhepDiTre"].ToString());
                                        //    string sPhutTre11;
                                        //    sPhutTre11 = Convert.ToInt32((dGioVaoTuDong - dGioVaoKhaiBaoTuDongKhongQuaDemB).TotalMinutes).ToString();
                                        //    if (sTruGioDiTre14 == "True")
                                        //    {
                                        //        if (Convert.ToInt32(sPhutTre11) < 0)
                                        //        {
                                        //            this.DGVTinhCong.Rows[_nhanVien].Cells[9].Value = "0";
                                        //        }
                                        //        else
                                        //        {
                                        //            int iPhutTre11;
                                        //            iPhutTre11 = Convert.ToInt32(sPhutTre11) - iChoPhepDiTre11;
                                        //            if (sBatDauTinhDiTre14 == "True")
                                        //            {
                                        //                if (iPhutTre11 < 1)
                                        //                {
                                        //                    this.DGVTinhCong.Rows[_nhanVien].Cells[9].Value = "0";
                                        //                }
                                        //                else
                                        //                {
                                        //                    this.DGVTinhCong.Rows[_nhanVien].Cells[9].Value = iPhutTre11.ToString();
                                        //                }
                                        //            }
                                        //            else if (iPhutTre11 < 1)
                                        //            {
                                        //                this.DGVTinhCong.Rows[_nhanVien].Cells[9].Value = "0";
                                        //            }
                                        //            else
                                        //            {
                                        //                this.DGVTinhCong.Rows[_nhanVien].Cells[9].Value = sPhutTre11;
                                        //            }
                                        //        }
                                        //    }
                                        //    else
                                        //    {
                                        //        this.DGVTinhCong.Rows[_nhanVien].Cells[9].Value = "0";
                                        //    }
                                        //    string sTruGioVeSom14;
                                        //    sTruGioVeSom14 = dtCaLamViecTuDongKhongQuaDem.Rows[iCaLamViecTuDongKhongQuaDem]["TruGioVeSom"].ToString();
                                        //    string sBatDauTinhVeSom14;
                                        //    sBatDauTinhVeSom14 = dtCaLamViecTuDongKhongQuaDem.Rows[iCaLamViecTuDongKhongQuaDem]["BatDauTinhVeSom"].ToString();
                                        //    int iChoPhepVeSom11;
                                        //    iChoPhepVeSom11 = Convert.ToInt32(dtCaLamViecTuDongKhongQuaDem.Rows[iCaLamViecTuDongKhongQuaDem]["ChoPhepVeSom"].ToString());
                                        //    string sPhutVeSom11;
                                        //    sPhutVeSom11 = Convert.ToInt32((dGioRaKhaiBaoTuDongKhongQuaDemB - dGioRaTuDong).TotalMinutes).ToString();
                                        //    if (sTruGioVeSom14 == "True")
                                        //    {
                                        //        if (Convert.ToInt32(sPhutVeSom11) < 0)
                                        //        {
                                        //            this.DGVTinhCong.Rows[_nhanVien].Cells[10].Value = "0";
                                        //        }
                                        //        else
                                        //        {
                                        //            int iPhutVeSom11;
                                        //            iPhutVeSom11 = Convert.ToInt32(sPhutVeSom11) - iChoPhepVeSom11;
                                        //            if (iPhutVeSom11 < 1)
                                        //            {
                                        //                this.DGVTinhCong.Rows[_nhanVien].Cells[10].Value = "0";
                                        //            }
                                        //            else if (sBatDauTinhVeSom14 == "True")
                                        //            {
                                        //                this.DGVTinhCong.Rows[_nhanVien].Cells[10].Value = iPhutVeSom11.ToString();
                                        //            }
                                        //            else
                                        //            {
                                        //                this.DGVTinhCong.Rows[_nhanVien].Cells[10].Value = sPhutVeSom11;
                                        //            }
                                        //        }
                                        //    }
                                        //    else
                                        //    {
                                        //        this.DGVTinhCong.Rows[_nhanVien].Cells[10].Value = "0";
                                        //    }
                                        //    string sVeTre10;
                                        //    sVeTre10 = Convert.ToInt32((dGioRaTuDong - dGioRaKhaiBaoTuDongKhongQuaDemB).TotalMinutes).ToString();
                                        //    if (Convert.ToInt32(sVeTre10) > 0)
                                        //    {
                                        //        this.DGVTinhCong.Rows[_nhanVien].Cells[11].Value = sVeTre10;
                                        //    }
                                        //    else
                                        //    {
                                        //        this.DGVTinhCong.Rows[_nhanVien].Cells[11].Value = "0";
                                        //    }
                                        //    double dGio10;
                                        //    dGio10 = Math.Round(Convert.ToDouble(Convert.ToSingle(dtCaLamViecTuDongKhongQuaDem.Rows[iCaLamViecTuDongKhongQuaDem]["TongGioTrongCaLamViec"]) * 60f - (float)(Convert.ToInt32(this.DGVTinhCong.Rows[_nhanVien].Cells[9].Value.ToString()) + Convert.ToInt32(this.DGVTinhCong.Rows[_nhanVien].Cells[10].Value))) / 60.0, this.iLamTronGio);
                                        //    this.DGVTinhCong.Rows[_nhanVien].Cells["Gio"].Value = dGio10 * this.dTangCaChuNhatHeSo;
                                        //    double iGio10;
                                        //    iGio10 = Convert.ToDouble(dtCaLamViecTuDongKhongQuaDem.Rows[iCaLamViecTuDongKhongQuaDem]["TongGioTrongCaLamViec"].ToString());
                                        //    double dCong10;
                                        //    dCong10 = Math.Round(dGio10 * Convert.ToDouble(dtCaLamViecTuDongKhongQuaDem.Rows[iCaLamViecTuDongKhongQuaDem]["CongTinh"].ToString()) / iGio10, this.iLamTronCong);
                                        //    this.DGVTinhCong.Rows[_nhanVien].Cells["Cong"].Value = dCong10 * this.dTangCaChuNhatHeSo;
                                        //    double dTongGioThucTeTuDongKhongQuaDem2;
                                        //    dTongGioThucTeTuDongKhongQuaDem2 = Math.Round(Convert.ToDouble(Convert.ToInt32((dGioRaTuDong - dGioVaoTuDong).TotalMinutes).ToString()) / 60.0, this.iLamTronGio);
                                        //    this.DGVTinhCong.Rows[_nhanVien].Cells[16].Value = dTongGioThucTeTuDongKhongQuaDem2 * this.dTangCaChuNhatHeSo;
                                        //    this.DGVTinhCong.Rows[_nhanVien].Cells["DemCong"].Value = Convert.ToDouble(dtCaLamViecTuDongKhongQuaDem.Rows[iCaLamViecTuDongKhongQuaDem]["CongTinh"].ToString()) * this.dTangCaChuNhatHeSo;
                                        //    this.DGVTinhCong.Rows[_nhanVien].Cells["KyHieu"].Value = this.sKHDungGio;
                                        //    string sChoPhepTangCaTruocGioLamViecTuDongKhongQuaDem2;
                                        //    sChoPhepTangCaTruocGioLamViecTuDongKhongQuaDem2 = dtCaLamViecTuDongKhongQuaDem.Rows[iCaLamViecTuDongKhongQuaDem]["TangCaTruocGioLamViec"].ToString();
                                        //    int iPhutTangCaTruocGioLamViecTuDongKhongQuaDem2;
                                        //    iPhutTangCaTruocGioLamViecTuDongKhongQuaDem2 = Convert.ToInt32(dtCaLamViecTuDongKhongQuaDem.Rows[iCaLamViecTuDongKhongQuaDem]["SoPhutTangCaTruocGioLamViec"].ToString());
                                        //    int iPhutTangCaTruocGioLamViecDatDen13;
                                        //    iPhutTangCaTruocGioLamViecDatDen13 = Convert.ToInt32(dtCaLamViecTuDongKhongQuaDem.Rows[iCaLamViecTuDongKhongQuaDem]["TangCaTruocGioLamViecDatDen"].ToString());
                                        //    int iPhutTruTangCaTruoc13;
                                        //    iPhutTruTangCaTruoc13 = Convert.ToInt32(dtCaLamViecTuDongKhongQuaDem.Rows[iCaLamViecTuDongKhongQuaDem]["PhutTruTangCaTruoc"].ToString());
                                        //    string sChoPhepTangCaSauGioLamViecTuDongKhongQuaDem2;
                                        //    sChoPhepTangCaSauGioLamViecTuDongKhongQuaDem2 = dtCaLamViecTuDongKhongQuaDem.Rows[iCaLamViecTuDongKhongQuaDem]["TangCaSauGioLamViec"].ToString();
                                        //    int iPhutTangCaSauGioLamViecTuDongKhongQuaDem2;
                                        //    iPhutTangCaSauGioLamViecTuDongKhongQuaDem2 = Convert.ToInt32(dtCaLamViecTuDongKhongQuaDem.Rows[iCaLamViecTuDongKhongQuaDem]["SoPhutTangCaSauGioLamViec"].ToString());
                                        //    int iPhutTangCaSauGioLamViecDatDen13;
                                        //    iPhutTangCaSauGioLamViecDatDen13 = Convert.ToInt32(dtCaLamViecTuDongKhongQuaDem.Rows[iCaLamViecTuDongKhongQuaDem]["TangCaSauGioLamViecDatDen"].ToString());
                                        //    int iPhutTruTangCaSau13;
                                        //    iPhutTruTangCaSau13 = Convert.ToInt32(dtCaLamViecTuDongKhongQuaDem.Rows[iCaLamViecTuDongKhongQuaDem]["PhutTruTangCaSau"].ToString());
                                        //    int iGioiHanTC1TuDongKhongQuaDem2;
                                        //    iGioiHanTC1TuDongKhongQuaDem2 = Convert.ToInt32(dtCaLamViecTuDongKhongQuaDem.Rows[iCaLamViecTuDongKhongQuaDem]["GioiHanTangCa1"].ToString());
                                        //    int iGioiHanTC2TuDongKhongQuaDem2;
                                        //    iGioiHanTC2TuDongKhongQuaDem2 = Convert.ToInt32(dtCaLamViecTuDongKhongQuaDem.Rows[iCaLamViecTuDongKhongQuaDem]["GioiHanTangCa2"].ToString());
                                        //    int iGioiHanTC3TuDongKhongQuaDem2;
                                        //    iGioiHanTC3TuDongKhongQuaDem2 = Convert.ToInt32(dtCaLamViecTuDongKhongQuaDem.Rows[iCaLamViecTuDongKhongQuaDem]["GioiHanTangCa3"].ToString());
                                        //    int iGioiHanTC4TuDongKhongQuaDem2;
                                        //    iGioiHanTC4TuDongKhongQuaDem2 = Convert.ToInt32(dtCaLamViecTuDongKhongQuaDem.Rows[iCaLamViecTuDongKhongQuaDem]["GioiHanTangCa4"].ToString());
                                        //    int iTongGioTangCaSauTuDongKhongQuaDem2;
                                        //    iTongGioTangCaSauTuDongKhongQuaDem2 = 0;
                                        //    int iTongGioTangCaTruocTuDongKhongQuaDem2;
                                        //    iTongGioTangCaTruocTuDongKhongQuaDem2 = 0;
                                        //    if (sChoPhepTangCaTruocGioLamViecTuDongKhongQuaDem2 == "False" && sChoPhepTangCaSauGioLamViecTuDongKhongQuaDem2 == "False")
                                        //    {
                                        //        this.DGVTinhCong.Rows[_nhanVien].Cells[12].Value = "0";
                                        //        this.DGVTinhCong.Rows[_nhanVien].Cells[13].Value = "0";
                                        //        this.DGVTinhCong.Rows[_nhanVien].Cells[14].Value = "0";
                                        //        this.DGVTinhCong.Rows[_nhanVien].Cells[15].Value = "0";
                                        //    }
                                        //    else
                                        //    {
                                        //        if (sChoPhepTangCaTruocGioLamViecTuDongKhongQuaDem2 == "True")
                                        //        {
                                        //            int iThoiGianTruocGioLamTuDongKhongQuaDem2;
                                        //            iThoiGianTruocGioLamTuDongKhongQuaDem2 = Convert.ToInt32(Convert.ToInt32((dGioVaoKhaiBaoTuDongKhongQuaDemB - dGioVaoTuDong).TotalMinutes).ToString());
                                        //            if (iThoiGianTruocGioLamTuDongKhongQuaDem2 > 0 && iThoiGianTruocGioLamTuDongKhongQuaDem2 > iPhutTangCaTruocGioLamViecTuDongKhongQuaDem2 && iThoiGianTruocGioLamTuDongKhongQuaDem2 > iPhutTangCaTruocGioLamViecDatDen13)
                                        //            {
                                        //                iTongGioTangCaTruocTuDongKhongQuaDem2 = iThoiGianTruocGioLamTuDongKhongQuaDem2 - iPhutTruTangCaTruoc13;
                                        //            }
                                        //        }
                                        //        if (sChoPhepTangCaSauGioLamViecTuDongKhongQuaDem2 == "True")
                                        //        {
                                        //            int iThoiGianSauGioLamViecTuDongKhongQuaDem2;
                                        //            iThoiGianSauGioLamViecTuDongKhongQuaDem2 = Convert.ToInt32(Convert.ToInt32((dGioRaTuDong - dGioRaKhaiBaoTuDongKhongQuaDemB).TotalMinutes).ToString());
                                        //            if (iThoiGianSauGioLamViecTuDongKhongQuaDem2 > 0 && iThoiGianSauGioLamViecTuDongKhongQuaDem2 > iPhutTangCaSauGioLamViecTuDongKhongQuaDem2)
                                        //            {
                                        //                iTongGioTangCaSauTuDongKhongQuaDem2 = ((iThoiGianSauGioLamViecTuDongKhongQuaDem2 < iPhutTangCaSauGioLamViecDatDen13) ? iThoiGianSauGioLamViecTuDongKhongQuaDem2 : (iThoiGianSauGioLamViecTuDongKhongQuaDem2 - iPhutTruTangCaSau13));
                                        //            }
                                        //        }
                                        //    }
                                        //    double dTongThoiGianTangCaTuDongKhongQuaDem2;
                                        //    dTongThoiGianTangCaTuDongKhongQuaDem2 = Convert.ToDouble(iTongGioTangCaTruocTuDongKhongQuaDem2 + iTongGioTangCaSauTuDongKhongQuaDem2);
                                        //    if (dTongThoiGianTangCaTuDongKhongQuaDem2 > 0.0)
                                        //    {
                                        //        if (iGioiHanTC1TuDongKhongQuaDem2 == 0)
                                        //        {
                                        //            this.DGVTinhCong.Rows[_nhanVien].Cells[12].Value = Math.Round(dTongThoiGianTangCaTuDongKhongQuaDem2 * this.dTangCa1HeSo / 60.0, this.iLamTronGio);
                                        //            this.DGVTinhCong.Rows[_nhanVien].Cells[13].Value = "0";
                                        //            this.DGVTinhCong.Rows[_nhanVien].Cells[14].Value = "0";
                                        //            this.DGVTinhCong.Rows[_nhanVien].Cells[15].Value = "0";
                                        //        }
                                        //        if (iGioiHanTC1TuDongKhongQuaDem2 != 0 && iGioiHanTC2TuDongKhongQuaDem2 == 0)
                                        //        {
                                        //            if (dTongThoiGianTangCaTuDongKhongQuaDem2 < Convert.ToDouble(iGioiHanTC1TuDongKhongQuaDem2))
                                        //            {
                                        //                this.DGVTinhCong.Rows[_nhanVien].Cells[12].Value = Math.Round(dTongThoiGianTangCaTuDongKhongQuaDem2 * this.dTangCa1HeSo / 60.0, this.iLamTronGio);
                                        //                this.DGVTinhCong.Rows[_nhanVien].Cells[13].Value = "0";
                                        //                this.DGVTinhCong.Rows[_nhanVien].Cells[14].Value = "0";
                                        //                this.DGVTinhCong.Rows[_nhanVien].Cells[15].Value = "0";
                                        //            }
                                        //            else
                                        //            {
                                        //                this.DGVTinhCong.Rows[_nhanVien].Cells[12].Value = Math.Round(Convert.ToDouble(iGioiHanTC1TuDongKhongQuaDem2) / 60.0 * this.dTangCa1HeSo, this.iLamTronGio);
                                        //                if (dTongThoiGianTangCaTuDongKhongQuaDem2 - Convert.ToDouble(iGioiHanTC1TuDongKhongQuaDem2) > 0.0)
                                        //                {
                                        //                    this.DGVTinhCong.Rows[_nhanVien].Cells[13].Value = Math.Round((dTongThoiGianTangCaTuDongKhongQuaDem2 - Convert.ToDouble(iGioiHanTC1TuDongKhongQuaDem2)) * this.dTangCa2HeSo / 60.0, this.iLamTronGio);
                                        //                }
                                        //                this.DGVTinhCong.Rows[_nhanVien].Cells[14].Value = "0";
                                        //                this.DGVTinhCong.Rows[_nhanVien].Cells[15].Value = "0";
                                        //            }
                                        //        }
                                        //        if (iGioiHanTC1TuDongKhongQuaDem2 != 0 && iGioiHanTC2TuDongKhongQuaDem2 != 0 && iGioiHanTC3TuDongKhongQuaDem2 == 0)
                                        //        {
                                        //            if (dTongThoiGianTangCaTuDongKhongQuaDem2 < Convert.ToDouble(iGioiHanTC1TuDongKhongQuaDem2))
                                        //            {
                                        //                this.DGVTinhCong.Rows[_nhanVien].Cells[12].Value = Math.Round(dTongThoiGianTangCaTuDongKhongQuaDem2 * this.dTangCa1HeSo / 60.0, this.iLamTronGio);
                                        //                this.DGVTinhCong.Rows[_nhanVien].Cells[13].Value = "0";
                                        //                this.DGVTinhCong.Rows[_nhanVien].Cells[14].Value = "0";
                                        //                this.DGVTinhCong.Rows[_nhanVien].Cells[15].Value = "0";
                                        //            }
                                        //            else
                                        //            {
                                        //                this.DGVTinhCong.Rows[_nhanVien].Cells[12].Value = Math.Round(Convert.ToDouble(iGioiHanTC1TuDongKhongQuaDem2) * this.dTangCa1HeSo / 60.0, this.iLamTronGio);
                                        //                if (dTongThoiGianTangCaTuDongKhongQuaDem2 - Convert.ToDouble(iGioiHanTC1TuDongKhongQuaDem2) < Convert.ToDouble(iGioiHanTC2TuDongKhongQuaDem2))
                                        //                {
                                        //                    this.DGVTinhCong.Rows[_nhanVien].Cells[13].Value = Math.Round((dTongThoiGianTangCaTuDongKhongQuaDem2 - Convert.ToDouble(iGioiHanTC1TuDongKhongQuaDem2)) * this.dTangCa2HeSo / 60.0, this.iLamTronGio);
                                        //                    this.DGVTinhCong.Rows[_nhanVien].Cells[14].Value = "0";
                                        //                    this.DGVTinhCong.Rows[_nhanVien].Cells[15].Value = "0";
                                        //                }
                                        //                else
                                        //                {
                                        //                    this.DGVTinhCong.Rows[_nhanVien].Cells[12].Value = Math.Round(Convert.ToDouble(iGioiHanTC1TuDongKhongQuaDem2) * this.dTangCa1HeSo / 60.0, this.iLamTronGio);
                                        //                    this.DGVTinhCong.Rows[_nhanVien].Cells[13].Value = Math.Round(Convert.ToDouble(iGioiHanTC2TuDongKhongQuaDem2) * this.dTangCa2HeSo / 60.0, this.iLamTronGio);
                                        //                    this.DGVTinhCong.Rows[_nhanVien].Cells[14].Value = Math.Round((dTongThoiGianTangCaTuDongKhongQuaDem2 - Convert.ToDouble(iGioiHanTC1TuDongKhongQuaDem2) - Convert.ToDouble(iGioiHanTC2TuDongKhongQuaDem2)) * this.dTangCa3HeSo / 60.0, this.iLamTronGio);
                                        //                    this.DGVTinhCong.Rows[_nhanVien].Cells[15].Value = "0";
                                        //                }
                                        //            }
                                        //        }
                                        //        if (iGioiHanTC1TuDongKhongQuaDem2 != 0 && iGioiHanTC2TuDongKhongQuaDem2 != 0 && iGioiHanTC3TuDongKhongQuaDem2 != 0 && iGioiHanTC4TuDongKhongQuaDem2 != 0)
                                        //        {
                                        //        }
                                        //    }
                                        //    else
                                        //    {
                                        //        this.DGVTinhCong.Rows[_nhanVien].Cells[12].Value = "0";
                                        //        this.DGVTinhCong.Rows[_nhanVien].Cells[13].Value = "0";
                                        //        this.DGVTinhCong.Rows[_nhanVien].Cells[14].Value = "0";
                                        //        this.DGVTinhCong.Rows[_nhanVien].Cells[15].Value = "0";
                                        //    }
                                        //    continue;
                                        //}
                                        //string sTruGioDiTre12;
                                        //sTruGioDiTre12 = dtCaLamViecTuDongKhongQuaDem.Rows[iCaLamViecTuDongKhongQuaDem]["TruGioDiTre"].ToString();
                                        //string sBatDauTinhDiTre12;
                                        //sBatDauTinhDiTre12 = dtCaLamViecTuDongKhongQuaDem.Rows[iCaLamViecTuDongKhongQuaDem]["BatDauTinhDiTre"].ToString();
                                        //int iChoPhepDiTre9;
                                        //iChoPhepDiTre9 = Convert.ToInt32(dtCaLamViecTuDongKhongQuaDem.Rows[iCaLamViecTuDongKhongQuaDem]["ChoPhepDiTre"].ToString());
                                        //string sPhutTre9;
                                        //sPhutTre9 = Convert.ToInt32((dGioVaoTuDong - dGioVaoKhaiBaoTuDongKhongQuaDemB).TotalMinutes).ToString();
                                        //if (sTruGioDiTre12 == "True")
                                        //{
                                        //    if (Convert.ToInt32(sPhutTre9) < 0)
                                        //    {
                                        //        this.DGVTinhCong.Rows[_nhanVien].Cells[9].Value = "0";
                                        //    }
                                        //    else
                                        //    {
                                        //        int iPhutTre9;
                                        //        iPhutTre9 = Convert.ToInt32(sPhutTre9) - iChoPhepDiTre9;
                                        //        if (sBatDauTinhDiTre12 == "True")
                                        //        {
                                        //            if (iPhutTre9 < 1)
                                        //            {
                                        //                this.DGVTinhCong.Rows[_nhanVien].Cells[9].Value = "0";
                                        //            }
                                        //            else
                                        //            {
                                        //                this.DGVTinhCong.Rows[_nhanVien].Cells[5].Style.BackColor = Color.Lime;
                                        //                this.DGVTinhCong.Rows[_nhanVien].Cells[9].Value = iPhutTre9.ToString();
                                        //            }
                                        //        }
                                        //        else if (iPhutTre9 < 1)
                                        //        {
                                        //            this.DGVTinhCong.Rows[_nhanVien].Cells[9].Value = "0";
                                        //        }
                                        //        else
                                        //        {
                                        //            this.DGVTinhCong.Rows[_nhanVien].Cells[9].Value = sPhutTre9;
                                        //        }
                                        //    }
                                        //}
                                        //else
                                        //{
                                        //    this.DGVTinhCong.Rows[_nhanVien].Cells[9].Value = "0";
                                        //}
                                        //string sTruGioVeSom12;
                                        //sTruGioVeSom12 = dtCaLamViecTuDongKhongQuaDem.Rows[iCaLamViecTuDongKhongQuaDem]["TruGioVeSom"].ToString();
                                        //string sBatDauTinhVeSom12;
                                        //sBatDauTinhVeSom12 = dtCaLamViecTuDongKhongQuaDem.Rows[iCaLamViecTuDongKhongQuaDem]["BatDauTinhVeSom"].ToString();
                                        //int iChoPhepVeSom9;
                                        //iChoPhepVeSom9 = Convert.ToInt32(dtCaLamViecTuDongKhongQuaDem.Rows[iCaLamViecTuDongKhongQuaDem]["ChoPhepVeSom"].ToString());
                                        //string sPhutVeSom9;
                                        //sPhutVeSom9 = Convert.ToInt32((dGioRaKhaiBaoTuDongKhongQuaDemB - dGioRaTuDong).TotalMinutes).ToString();
                                        //if (sTruGioVeSom12 == "True")
                                        //{
                                        //    if (Convert.ToInt32(sPhutVeSom9) < 0)
                                        //    {
                                        //        this.DGVTinhCong.Rows[_nhanVien].Cells[10].Value = "0";
                                        //    }
                                        //    else
                                        //    {
                                        //        int iPhutVeSom9;
                                        //        iPhutVeSom9 = Convert.ToInt32(sPhutVeSom9) - iChoPhepVeSom9;
                                        //        if (iPhutVeSom9 < 1)
                                        //        {
                                        //            this.DGVTinhCong.Rows[_nhanVien].Cells[10].Value = "0";
                                        //        }
                                        //        else
                                        //        {
                                        //            this.DGVTinhCong.Rows[_nhanVien].Cells[6].Style.BackColor = Color.Yellow;
                                        //            if (sBatDauTinhVeSom12 == "True")
                                        //            {
                                        //                this.DGVTinhCong.Rows[_nhanVien].Cells[10].Value = iPhutVeSom9.ToString();
                                        //            }
                                        //            else
                                        //            {
                                        //                this.DGVTinhCong.Rows[_nhanVien].Cells[10].Value = sPhutVeSom9;
                                        //            }
                                        //        }
                                        //    }
                                        //}
                                        //else
                                        //{
                                        //    this.DGVTinhCong.Rows[_nhanVien].Cells[10].Value = "0";
                                        //}
                                        //string sVeTre8;
                                        //sVeTre8 = Convert.ToInt32((dGioRaTuDong - dGioRaKhaiBaoTuDongKhongQuaDemB).TotalMinutes).ToString();
                                        //if (Convert.ToInt32(sVeTre8) > 0)
                                        //{
                                        //    this.DGVTinhCong.Rows[_nhanVien].Cells[11].Value = sVeTre8;
                                        //}
                                        //else
                                        //{
                                        //    this.DGVTinhCong.Rows[_nhanVien].Cells[11].Value = "0";
                                        //}
                                        //double dGio8;
                                        //dGio8 = Math.Round(Convert.ToDouble(Convert.ToSingle(dtCaLamViecTuDongKhongQuaDem.Rows[iCaLamViecTuDongKhongQuaDem]["TongGioTrongCaLamViec"]) * 60f - (float)(Convert.ToInt32(this.DGVTinhCong.Rows[_nhanVien].Cells[9].Value.ToString()) + Convert.ToInt32(this.DGVTinhCong.Rows[_nhanVien].Cells[10].Value))) / 60.0, this.iLamTronGio);
                                        //double dTongGioTrongCa;
                                        //dTongGioTrongCa = Convert.ToDouble(dtCaLamViecTuDongKhongQuaDem.Rows[iCaLamViecTuDongKhongQuaDem]["TongGioTrongCaLamViec"].ToString());
                                        //if (iTinhBuTru != 0 && Convert.ToInt32(this.DGVTinhCong.Rows[_nhanVien].Cells[9].Value) > 0 && Convert.ToInt32(this.DGVTinhCong.Rows[_nhanVien].Cells[11].Value) > 0)
                                        //{
                                        //    int iVeTre;
                                        //    iVeTre = Convert.ToInt32(this.DGVTinhCong.Rows[_nhanVien].Cells[11].Value);
                                        //    dGio8 = Math.Round(dGio8 + Convert.ToDouble(iVeTre) / 60.0, 2);
                                        //    if (dGio8 > dTongGioTrongCa)
                                        //    {
                                        //        iVeTre -= Convert.ToInt32(this.DGVTinhCong.Rows[_nhanVien].Cells[9].Value);
                                        //        dGio8 = dTongGioTrongCa;
                                        //        this.DGVTinhCong.Rows[_nhanVien].Cells[11].Value = iVeTre;
                                        //        this.DGVTinhCong.Rows[_nhanVien].Cells["Gio"].Value = dGio8.ToString();
                                        //    }
                                        //    else
                                        //    {
                                        //        this.DGVTinhCong.Rows[_nhanVien].Cells["Gio"].Value = dGio8.ToString();
                                        //        this.DGVTinhCong.Rows[_nhanVien].Cells[9].Value = Convert.ToInt32(sPhutTre9) - iVeTre;
                                        //        this.DGVTinhCong.Rows[_nhanVien].Cells[11].Value = "0";
                                        //    }
                                        //}
                                        //else
                                        //{
                                        //    this.DGVTinhCong.Rows[_nhanVien].Cells["Gio"].Value = dGio8.ToString();
                                        //}
                                        //double iGio9;
                                        //iGio9 = Convert.ToDouble(dtCaLamViecTuDongKhongQuaDem.Rows[iCaLamViecTuDongKhongQuaDem]["TongGioTrongCaLamViec"].ToString());
                                        //double dCongTinh9;
                                        //dCongTinh9 = Convert.ToDouble(dtCaLamViecTuDongKhongQuaDem.Rows[iCaLamViecTuDongKhongQuaDem]["CongTinh"].ToString());
                                        //double dCong9;
                                        //dCong9 = Math.Round(dGio8 * dCongTinh9 / iGio9, this.iLamTronCong);
                                        //this.DGVTinhCong.Rows[_nhanVien].Cells["Cong"].Value = dCong9.ToString();
                                        //double dTongGioThucTeTuDongKhongQuaDem;
                                        //dTongGioThucTeTuDongKhongQuaDem = Math.Round(Convert.ToDouble(Convert.ToInt32((dGioRaTuDong - dGioVaoTuDong).TotalMinutes).ToString()) / 60.0, this.iLamTronGio);
                                        //this.DGVTinhCong.Rows[_nhanVien].Cells[16].Value = dTongGioThucTeTuDongKhongQuaDem.ToString();
                                        //this.DGVTinhCong.Rows[_nhanVien].Cells["DemCong"].Value = dtCaLamViecTuDongKhongQuaDem.Rows[iCaLamViecTuDongKhongQuaDem]["CongTinh"].ToString();
                                        //this.DGVTinhCong.Rows[_nhanVien].Cells["KyHieu"].Value = this.sKHDungGio;
                                        //string sChoPhepTangCaTruocGioLamViecTuDongKhongQuaDem;
                                        //sChoPhepTangCaTruocGioLamViecTuDongKhongQuaDem = dtCaLamViecTuDongKhongQuaDem.Rows[iCaLamViecTuDongKhongQuaDem]["TangCaTruocGioLamViec"].ToString();
                                        //int iPhutTangCaTruocGioLamViecTuDongKhongQuaDem;
                                        //iPhutTangCaTruocGioLamViecTuDongKhongQuaDem = Convert.ToInt32(dtCaLamViecTuDongKhongQuaDem.Rows[iCaLamViecTuDongKhongQuaDem]["SoPhutTangCaTruocGioLamViec"].ToString());
                                        //int iPhutTangCaTruocGioLamViecDatDen12;
                                        //iPhutTangCaTruocGioLamViecDatDen12 = Convert.ToInt32(dtCaLamViecTuDongKhongQuaDem.Rows[iCaLamViecTuDongKhongQuaDem]["TangCaTruocGioLamViecDatDen"].ToString());
                                        //int iPhutTruTangCaTruoc12;
                                        //iPhutTruTangCaTruoc12 = Convert.ToInt32(dtCaLamViecTuDongKhongQuaDem.Rows[iCaLamViecTuDongKhongQuaDem]["PhutTruTangCaTruoc"].ToString());
                                        //string sChoPhepTangCaSauGioLamViecTuDongKhongQuaDem;
                                        //sChoPhepTangCaSauGioLamViecTuDongKhongQuaDem = dtCaLamViecTuDongKhongQuaDem.Rows[iCaLamViecTuDongKhongQuaDem]["TangCaSauGioLamViec"].ToString();
                                        //int iPhutTangCaSauGioLamViecTuDongKhongQuaDem;
                                        //iPhutTangCaSauGioLamViecTuDongKhongQuaDem = Convert.ToInt32(dtCaLamViecTuDongKhongQuaDem.Rows[iCaLamViecTuDongKhongQuaDem]["SoPhutTangCaSauGioLamViec"].ToString());
                                        //int iPhutTangCaSauGioLamViecDatDen12;
                                        //iPhutTangCaSauGioLamViecDatDen12 = Convert.ToInt32(dtCaLamViecTuDongKhongQuaDem.Rows[iCaLamViecTuDongKhongQuaDem]["TangCaSauGioLamViecDatDen"].ToString());
                                        //int iPhutTruTangCaSau12;
                                        //iPhutTruTangCaSau12 = Convert.ToInt32(dtCaLamViecTuDongKhongQuaDem.Rows[iCaLamViecTuDongKhongQuaDem]["PhutTruTangCaSau"].ToString());
                                        //int iGioiHanTC1TuDongKhongQuaDem;
                                        //iGioiHanTC1TuDongKhongQuaDem = Convert.ToInt32(dtCaLamViecTuDongKhongQuaDem.Rows[iCaLamViecTuDongKhongQuaDem]["GioiHanTangCa1"].ToString());
                                        //int iGioiHanTC2TuDongKhongQuaDem;
                                        //iGioiHanTC2TuDongKhongQuaDem = Convert.ToInt32(dtCaLamViecTuDongKhongQuaDem.Rows[iCaLamViecTuDongKhongQuaDem]["GioiHanTangCa2"].ToString());
                                        //int iGioiHanTC3TuDongKhongQuaDem;
                                        //iGioiHanTC3TuDongKhongQuaDem = Convert.ToInt32(dtCaLamViecTuDongKhongQuaDem.Rows[iCaLamViecTuDongKhongQuaDem]["GioiHanTangCa3"].ToString());
                                        //int iGioiHanTC4TuDongKhongQuaDem;
                                        //iGioiHanTC4TuDongKhongQuaDem = Convert.ToInt32(dtCaLamViecTuDongKhongQuaDem.Rows[iCaLamViecTuDongKhongQuaDem]["GioiHanTangCa4"].ToString());
                                        //int iTongGioTangCaSauTuDongKhongQuaDem;
                                        //iTongGioTangCaSauTuDongKhongQuaDem = 0;
                                        //int iTongGioTangCaTruocTuDongKhongQuaDem;
                                        //iTongGioTangCaTruocTuDongKhongQuaDem = 0;
                                        //if (sChoPhepTangCaTruocGioLamViecTuDongKhongQuaDem == "False" && sChoPhepTangCaSauGioLamViecTuDongKhongQuaDem == "False")
                                        //{
                                        //    this.DGVTinhCong.Rows[_nhanVien].Cells[12].Value = "0";
                                        //    this.DGVTinhCong.Rows[_nhanVien].Cells[13].Value = "0";
                                        //    this.DGVTinhCong.Rows[_nhanVien].Cells[14].Value = "0";
                                        //    this.DGVTinhCong.Rows[_nhanVien].Cells[15].Value = "0";
                                        //}
                                        //else
                                        //{
                                        //    if (sChoPhepTangCaTruocGioLamViecTuDongKhongQuaDem == "True")
                                        //    {
                                        //        int iThoiGianTruocGioLamTuDongKhongQuaDem;
                                        //        iThoiGianTruocGioLamTuDongKhongQuaDem = Convert.ToInt32(Convert.ToInt32((dGioVaoKhaiBaoTuDongKhongQuaDemB - dGioVaoTuDong).TotalMinutes).ToString());
                                        //        if (iThoiGianTruocGioLamTuDongKhongQuaDem > 0 && iThoiGianTruocGioLamTuDongKhongQuaDem > iPhutTangCaTruocGioLamViecTuDongKhongQuaDem && iThoiGianTruocGioLamTuDongKhongQuaDem > iPhutTangCaTruocGioLamViecDatDen12)
                                        //        {
                                        //            iTongGioTangCaTruocTuDongKhongQuaDem = iThoiGianTruocGioLamTuDongKhongQuaDem - iPhutTruTangCaTruoc12;
                                        //        }
                                        //    }
                                        //    if (sChoPhepTangCaSauGioLamViecTuDongKhongQuaDem == "True")
                                        //    {
                                        //        int iThoiGianSauGioLamViecTuDongKhongQuaDem;
                                        //        iThoiGianSauGioLamViecTuDongKhongQuaDem = Convert.ToInt32(this.DGVTinhCong.Rows[_nhanVien].Cells[11].Value);
                                        //        if (iThoiGianSauGioLamViecTuDongKhongQuaDem > 0 && iThoiGianSauGioLamViecTuDongKhongQuaDem > iPhutTangCaSauGioLamViecTuDongKhongQuaDem)
                                        //        {
                                        //            iTongGioTangCaSauTuDongKhongQuaDem = ((iThoiGianSauGioLamViecTuDongKhongQuaDem < iPhutTangCaSauGioLamViecDatDen12) ? iThoiGianSauGioLamViecTuDongKhongQuaDem : (iThoiGianSauGioLamViecTuDongKhongQuaDem - iPhutTruTangCaSau12));
                                        //        }
                                        //    }
                                        //}
                                        //double dTongThoiGianTangCaTuDongKhongQuaDem;
                                        //dTongThoiGianTangCaTuDongKhongQuaDem = Convert.ToDouble(iTongGioTangCaTruocTuDongKhongQuaDem + iTongGioTangCaSauTuDongKhongQuaDem);
                                        //if (dTongThoiGianTangCaTuDongKhongQuaDem > 0.0)
                                        //{
                                        //    if (iGioiHanTC1TuDongKhongQuaDem == 0)
                                        //    {
                                        //        this.DGVTinhCong.Rows[_nhanVien].Cells[12].Value = Math.Round(dTongThoiGianTangCaTuDongKhongQuaDem * this.dTangCa1HeSo / 60.0, this.iLamTronGio);
                                        //        this.DGVTinhCong.Rows[_nhanVien].Cells[13].Value = "0";
                                        //        this.DGVTinhCong.Rows[_nhanVien].Cells[14].Value = "0";
                                        //        this.DGVTinhCong.Rows[_nhanVien].Cells[15].Value = "0";
                                        //    }
                                        //    if (iGioiHanTC1TuDongKhongQuaDem != 0 && iGioiHanTC2TuDongKhongQuaDem == 0)
                                        //    {
                                        //        if (dTongThoiGianTangCaTuDongKhongQuaDem < Convert.ToDouble(iGioiHanTC1TuDongKhongQuaDem))
                                        //        {
                                        //            this.DGVTinhCong.Rows[_nhanVien].Cells[12].Value = Math.Round(dTongThoiGianTangCaTuDongKhongQuaDem * this.dTangCa1HeSo / 60.0, this.iLamTronGio);
                                        //            this.DGVTinhCong.Rows[_nhanVien].Cells[13].Value = "0";
                                        //            this.DGVTinhCong.Rows[_nhanVien].Cells[14].Value = "0";
                                        //            this.DGVTinhCong.Rows[_nhanVien].Cells[15].Value = "0";
                                        //        }
                                        //        else
                                        //        {
                                        //            this.DGVTinhCong.Rows[_nhanVien].Cells[12].Value = Math.Round(Convert.ToDouble(iGioiHanTC1TuDongKhongQuaDem) / 60.0 * this.dTangCa1HeSo, this.iLamTronGio);
                                        //            if (dTongThoiGianTangCaTuDongKhongQuaDem - Convert.ToDouble(iGioiHanTC1TuDongKhongQuaDem) > 0.0)
                                        //            {
                                        //                this.DGVTinhCong.Rows[_nhanVien].Cells[13].Value = Math.Round((dTongThoiGianTangCaTuDongKhongQuaDem - Convert.ToDouble(iGioiHanTC1TuDongKhongQuaDem)) * this.dTangCa2HeSo / 60.0, this.iLamTronGio);
                                        //            }
                                        //            this.DGVTinhCong.Rows[_nhanVien].Cells[14].Value = "0";
                                        //            this.DGVTinhCong.Rows[_nhanVien].Cells[15].Value = "0";
                                        //        }
                                        //    }
                                        //    if (iGioiHanTC1TuDongKhongQuaDem != 0 && iGioiHanTC2TuDongKhongQuaDem != 0 && iGioiHanTC3TuDongKhongQuaDem == 0)
                                        //    {
                                        //        if (dTongThoiGianTangCaTuDongKhongQuaDem < Convert.ToDouble(iGioiHanTC1TuDongKhongQuaDem))
                                        //        {
                                        //            this.DGVTinhCong.Rows[_nhanVien].Cells[12].Value = Math.Round(dTongThoiGianTangCaTuDongKhongQuaDem * this.dTangCa1HeSo / 60.0, this.iLamTronGio);
                                        //            this.DGVTinhCong.Rows[_nhanVien].Cells[13].Value = "0";
                                        //            this.DGVTinhCong.Rows[_nhanVien].Cells[14].Value = "0";
                                        //            this.DGVTinhCong.Rows[_nhanVien].Cells[15].Value = "0";
                                        //        }
                                        //        else
                                        //        {
                                        //            this.DGVTinhCong.Rows[_nhanVien].Cells[12].Value = Math.Round(Convert.ToDouble(iGioiHanTC1TuDongKhongQuaDem) * this.dTangCa1HeSo / 60.0, this.iLamTronGio);
                                        //            if (dTongThoiGianTangCaTuDongKhongQuaDem - Convert.ToDouble(iGioiHanTC1TuDongKhongQuaDem) < Convert.ToDouble(iGioiHanTC2TuDongKhongQuaDem))
                                        //            {
                                        //                this.DGVTinhCong.Rows[_nhanVien].Cells[13].Value = Math.Round((dTongThoiGianTangCaTuDongKhongQuaDem - Convert.ToDouble(iGioiHanTC1TuDongKhongQuaDem)) * this.dTangCa2HeSo / 60.0, this.iLamTronGio);
                                        //                this.DGVTinhCong.Rows[_nhanVien].Cells[14].Value = "0";
                                        //                this.DGVTinhCong.Rows[_nhanVien].Cells[15].Value = "0";
                                        //            }
                                        //            else
                                        //            {
                                        //                this.DGVTinhCong.Rows[_nhanVien].Cells[12].Value = Math.Round(Convert.ToDouble(iGioiHanTC1TuDongKhongQuaDem) * this.dTangCa1HeSo / 60.0, this.iLamTronGio);
                                        //                this.DGVTinhCong.Rows[_nhanVien].Cells[13].Value = Math.Round(Convert.ToDouble(iGioiHanTC2TuDongKhongQuaDem) * this.dTangCa2HeSo / 60.0, this.iLamTronGio);
                                        //                this.DGVTinhCong.Rows[_nhanVien].Cells[14].Value = Math.Round((dTongThoiGianTangCaTuDongKhongQuaDem - Convert.ToDouble(iGioiHanTC1TuDongKhongQuaDem) - Convert.ToDouble(iGioiHanTC2TuDongKhongQuaDem)) * this.dTangCa3HeSo / 60.0, this.iLamTronGio);
                                        //                this.DGVTinhCong.Rows[_nhanVien].Cells[15].Value = "0";
                                        //            }
                                        //        }
                                        //    }
                                        //    if (iGioiHanTC1TuDongKhongQuaDem != 0 && iGioiHanTC2TuDongKhongQuaDem != 0 && iGioiHanTC3TuDongKhongQuaDem != 0 && iGioiHanTC4TuDongKhongQuaDem != 0)
                                        //    {
                                        //    }
                                        //}
                                        //else
                                        //{
                                        //    this.DGVTinhCong.Rows[_nhanVien].Cells[12].Value = "0";
                                        //    this.DGVTinhCong.Rows[_nhanVien].Cells[13].Value = "0";
                                        //    this.DGVTinhCong.Rows[_nhanVien].Cells[14].Value = "0";
                                        //    this.DGVTinhCong.Rows[_nhanVien].Cells[15].Value = "0";
                                        //}
                                    }
                                    if (DateTimeProgress.XuatIDThu((int)dt.AddDays(dem).DayOfWeek) == "0")
                                    {
                                        this.DGVTinhCong.Rows[_nhanVien].Cells["IDThu"].Value = "CN";
                                    }
                                    else
                                    {
                                        this.DGVTinhCong.Rows[_nhanVien].Cells["IDThu"].Value = "NT";
                                    }
                                    this.DGVTinhCong.Rows[_nhanVien].Cells["MaChamCong"].Value = this.sMaChamCong;
                                    this.DGVTinhCong.Rows[_nhanVien].Cells["PhongBan"].Value = this.sPhongBanTinhCong;
                                    break;
                                }
                            }
                        }
                        if (iKiemTraLanCham <= 2)
                        {
                            continue;
                        }
                        if (iKiemTraLanCham % 2 != 0)
                        {
                            addTuDong = this.DGVTinhCong.Rows.Add();
                            dGioVaoTuDong = Convert.ToDateTime(dtTuDong.Rows[iTuDong]["GioCham"].ToString());
                            this.DGVTinhCong.Rows[addTuDong].Cells["Vao"].Value = string.Format(this.sDinhDangThoiGian, dGioVaoTuDong);
                            this.DGVTinhCong.Rows[addTuDong].Cells["MaNhanVien"].Value = this.sMaNhanVien;
                            this.DGVTinhCong.Rows[addTuDong].Cells["TenNhanVien"].Value = this.sTenNhanVien;
                            this.DGVTinhCong.Rows[addTuDong].Cells["Ngay"].Value = this.DGVTinhCong.Rows[_nhanVien].Cells["Ngay"].Value.ToString();
                            this.DGVTinhCong.Rows[addTuDong].Cells["Thu"].Value = DateTimeProgress.XuatThuTinhCong((int)dt.AddDays(dem).DayOfWeek);
                            this.DGVTinhCong.Rows[addTuDong].Cells["Ca"].Value = ca;
                            this.DGVTinhCong.Rows[addTuDong].Cells["Cong"].Value = "0";
                            this.DGVTinhCong.Rows[addTuDong].Cells["Gio"].Value = "0";
                            this.DGVTinhCong.Rows[addTuDong].Cells["Tre"].Value = "0";
                            this.DGVTinhCong.Rows[addTuDong].Cells["VeSom"].Value = "0";
                            this.DGVTinhCong.Rows[addTuDong].Cells["VeTre"].Value = "0";
                            this.DGVTinhCong.Rows[addTuDong].Cells["TC1"].Value = "0";
                            this.DGVTinhCong.Rows[addTuDong].Cells["TC2"].Value = "0";
                            this.DGVTinhCong.Rows[addTuDong].Cells["TC3"].Value = "0";
                            this.DGVTinhCong.Rows[addTuDong].Cells["TC4"].Value = "0";
                            this.DGVTinhCong.Rows[addTuDong].Cells["TongGio"].Value = "0";
                            this.DGVTinhCong.Rows[addTuDong].Cells["DemCong"].Value = "0";
                            this.DGVTinhCong.Rows[addTuDong].Cells["KyHieu"].Value = this.sKHVang;
                            if (DateTimeProgress.XuatIDThu((int)dt.AddDays(dem).DayOfWeek) == "0")
                            {
                                this.DGVTinhCong.Rows[addTuDong].Cells["IDThu"].Value = "CN";
                            }
                            else
                            {
                                this.DGVTinhCong.Rows[addTuDong].Cells["IDThu"].Value = "NT";
                            }
                            this.DGVTinhCong.Rows[addTuDong].Cells["MaChamCong"].Value = this.sMaChamCong;
                            this.DGVTinhCong.Rows[addTuDong].Cells["PhongBan"].Value = this.sPhongBanTinhCong;
                            if (iKiemTraLanCham != dtTuDong.Rows.Count)
                            {
                                continue;
                            }
                            new DataTable();
                            for (int cellChiTietLichTrinhChoCaLamViecTuDongKhongQuaDem4 = 3; cellChiTietLichTrinhChoCaLamViecTuDongKhongQuaDem4 < 13; cellChiTietLichTrinhChoCaLamViecTuDongKhongQuaDem4++)
                            {
                                kiemTraVao = 0;
                                kiemTraRa = 0;
                                new DataTable();
                                DataTable dtTuDongQuaDemCa10;
                                dtTuDongQuaDemCa10 = this._caLamViecBLL.CaLamViecGetByMaCaLamViec(ca);
                                for (int iTuDongQuaDemCa10 = 0; iTuDongQuaDemCa10 < dtTuDongQuaDemCa10.Rows.Count; iTuDongQuaDemCa10++)
                                {
                                    this.sTuDongQuaDemTenCaLamViec = dtTuDongQuaDemCa10.Rows[iTuDongQuaDemCa10]["CaLamViec"].ToString();
                                    DateTime dBatDauVaoB10;
                                    dBatDauVaoB10 = Convert.ToDateTime(sNgayCham + " " + string.Format("{0:T}", Convert.ToDateTime(dtTuDongQuaDemCa10.Rows[iTuDongQuaDemCa10]["BatDauVao"].ToString())));
                                    DateTime dKetThucVaoB10;
                                    dKetThucVaoB10 = Convert.ToDateTime(sNgayCham + " " + string.Format("{0:T}", Convert.ToDateTime(dtTuDongQuaDemCa10.Rows[iTuDongQuaDemCa10]["KetThucVao"].ToString())));
                                    DateTime dBatDauRaB10;
                                    dBatDauRaB10 = Convert.ToDateTime(sNgayCham + " " + string.Format("{0:T}", Convert.ToDateTime(dtTuDongQuaDemCa10.Rows[iTuDongQuaDemCa10]["BatDauRa"].ToString())));
                                    DateTime dKetThucRaB10;
                                    dKetThucRaB10 = Convert.ToDateTime(sNgayCham + " " + string.Format("{0:T}", Convert.ToDateTime(dtTuDongQuaDemCa10.Rows[iTuDongQuaDemCa10]["KetThucRa"].ToString())));
                                    if (dGioVaoTuDong >= dBatDauVaoB10 && dGioVaoTuDong <= dKetThucVaoB10)
                                    {
                                        kiemTraVao++;
                                    }
                                    if (dGioRaTuDong >= dBatDauRaB10 && dGioRaTuDong <= dKetThucRaB10)
                                    {
                                        kiemTraRa++;
                                    }
                                    if (kiemTraVao == 1 && kiemTraRa == 0)
                                    {
                                        goto end_IL_eb5a;
                                    }
                                }
                                continue;
                            end_IL_eb5a:
                                break;
                            }
                            this.DGVTinhCong.Rows[addTuDong].Cells["Ca"].Value = this.sTuDongQuaDemTenCaLamViec;
                            this.DGVTinhCong.Rows[addTuDong].Cells["Cong"].Value = "0";
                            this.DGVTinhCong.Rows[addTuDong].Cells["Gio"].Value = "0";
                            this.DGVTinhCong.Rows[addTuDong].Cells["Tre"].Value = "0";
                            this.DGVTinhCong.Rows[addTuDong].Cells["VeSom"].Value = "0";
                            this.DGVTinhCong.Rows[addTuDong].Cells["VeTre"].Value = "0";
                            this.DGVTinhCong.Rows[addTuDong].Cells["TC1"].Value = "0";
                            this.DGVTinhCong.Rows[addTuDong].Cells["TC2"].Value = "0";
                            this.DGVTinhCong.Rows[addTuDong].Cells["TC3"].Value = "0";
                            this.DGVTinhCong.Rows[addTuDong].Cells["TC4"].Value = "0";
                            this.DGVTinhCong.Rows[addTuDong].Cells["TongGio"].Value = "0";
                            this.DGVTinhCong.Rows[addTuDong].Cells["DemCong"].Value = "0";
                            this.DGVTinhCong.Rows[addTuDong].Cells["KyHieu"].Value = this.sKHThieuGioRa;
                            if (DateTimeProgress.XuatIDThu((int)dt.AddDays(dem).DayOfWeek) == "0")
                            {
                                this.DGVTinhCong.Rows[addTuDong].Cells["IDThu"].Value = "CN";
                            }
                            else
                            {
                                this.DGVTinhCong.Rows[addTuDong].Cells["IDThu"].Value = "NT";
                            }
                            this.DGVTinhCong.Rows[addTuDong].Cells["MaChamCong"].Value = this.sMaChamCong;
                            this.DGVTinhCong.Rows[addTuDong].Cells["PhongBan"].Value = this.sPhongBanTinhCong;
                            continue;
                        }
                        dGioRaTuDong = Convert.ToDateTime(dtTuDong.Rows[iTuDong]["GioCham"].ToString());
                        Convert.ToInt32((dGioRaTuDong - dGioVaoTuDong).TotalMinutes);
                        if (Convert.ToInt32(Convert.ToInt32((dGioRaTuDongKhongQuaDemLichTrinhVaoRa - dGioVaoTuDongKhongQuaDemLichTrinhVaoRa).TotalMinutes).ToString()) > iThoiGianLonNhat)
                        {
                            int addTuDongKhongQuaDemThoiGianLonNhat2;
                            addTuDongKhongQuaDemThoiGianLonNhat2 = this.DGVTinhCong.Rows.Add();
                            this.DGVTinhCong.Rows[addTuDongKhongQuaDemThoiGianLonNhat2].Cells[0].Value = this.sMaNhanVien;
                            this.DGVTinhCong.Rows[addTuDongKhongQuaDemThoiGianLonNhat2].Cells[1].Value = this.sTenNhanVien;
                            this.DGVTinhCong.Rows[addTuDongKhongQuaDemThoiGianLonNhat2].Cells[2].Value = this.DGVTinhCong.Rows[_nhanVien].Cells["Ngay"].Value.ToString();
                            this.DGVTinhCong.Rows[addTuDongKhongQuaDemThoiGianLonNhat2].Cells[3].Value = DateTimeProgress.XuatThuTinhCong((int)dt.AddDays(dem).DayOfWeek);
                            this.DGVTinhCong.Rows[addTuDongKhongQuaDemThoiGianLonNhat2].Cells[4].Value = ca;
                            this.DGVTinhCong.Rows[addTuDongKhongQuaDemThoiGianLonNhat2].Cells[6].Value = string.Format(this.sDinhDangThoiGian, dGioRaTuDong);
                            this.DGVTinhCong.Rows[addTuDongKhongQuaDemThoiGianLonNhat2].Cells[7].Value = "0";
                            this.DGVTinhCong.Rows[addTuDongKhongQuaDemThoiGianLonNhat2].Cells[8].Value = "0";
                            this.DGVTinhCong.Rows[addTuDongKhongQuaDemThoiGianLonNhat2].Cells[9].Value = "0";
                            this.DGVTinhCong.Rows[addTuDongKhongQuaDemThoiGianLonNhat2].Cells[10].Value = "0";
                            this.DGVTinhCong.Rows[addTuDongKhongQuaDemThoiGianLonNhat2].Cells[11].Value = "0";
                            this.DGVTinhCong.Rows[addTuDongKhongQuaDemThoiGianLonNhat2].Cells[12].Value = "0";
                            this.DGVTinhCong.Rows[addTuDongKhongQuaDemThoiGianLonNhat2].Cells[13].Value = "0";
                            this.DGVTinhCong.Rows[addTuDongKhongQuaDemThoiGianLonNhat2].Cells[14].Value = "0";
                            this.DGVTinhCong.Rows[addTuDongKhongQuaDemThoiGianLonNhat2].Cells[15].Value = "0";
                            this.DGVTinhCong.Rows[addTuDongKhongQuaDemThoiGianLonNhat2].Cells[16].Value = "0";
                            this.DGVTinhCong.Rows[addTuDongKhongQuaDemThoiGianLonNhat2].Cells[17].Value = "0";
                            this.DGVTinhCong.Rows[addTuDongKhongQuaDemThoiGianLonNhat2].Cells[18].Value = this.sKHVang;
                            if (DateTimeProgress.XuatIDThu((int)dt.AddDays(dem).DayOfWeek) == "0")
                            {
                                this.DGVTinhCong.Rows[addTuDongKhongQuaDemThoiGianLonNhat2].Cells[19].Value = "CN";
                            }
                            else
                            {
                                this.DGVTinhCong.Rows[addTuDongKhongQuaDemThoiGianLonNhat2].Cells[19].Value = "NT";
                            }
                            this.DGVTinhCong.Rows[addTuDongKhongQuaDemThoiGianLonNhat2].Cells[20].Value = this.sMaChamCong;
                            this.DGVTinhCong.Rows[addTuDongKhongQuaDemThoiGianLonNhat2].Cells[21].Value = this.sPhongBanTinhCong;
                            continue;
                        }
                        this.DGVTinhCong.Rows[addTuDong].Cells[6].Value = string.Format(this.sDinhDangThoiGian, dGioRaTuDong);
                        int cellChiTietLichTrinhChoCaLamViecTuDongKhongQuaDem3;
                        cellChiTietLichTrinhChoCaLamViecTuDongKhongQuaDem3 = 3;
                        while (true)
                        {
                            if (cellChiTietLichTrinhChoCaLamViecTuDongKhongQuaDem3 < 13)
                            {
                                
                                new DataTable();
                                DataTable dtTuDongQuaDemCa9;
                                dtTuDongQuaDemCa9 = this._caLamViecBLL.CaLamViecGetByMaCaLamViec(sTuDongQuaDemMaCaLamViec);
                                int iTuDongQuaDemCa9;
                                iTuDongQuaDemCa9 = 0;
                                while (iTuDongQuaDemCa9 < dtTuDongQuaDemCa9.Rows.Count)
                                {
                                    kiemTraVao = 0;
                                    kiemTraRa = 0;
                                    string sGiayGioVao21;
                                    sGiayGioVao21 = dGioVaoTuDong.Second.ToString();
                                    string sGiayGioRa21;
                                    sGiayGioRa21 = dGioRaTuDong.Second.ToString();
                                    this.sTuDongQuaDemTenCaLamViec = dtTuDongQuaDemCa9.Rows[iTuDongQuaDemCa9]["CaLamViec"].ToString();
                                    DateTime dBatDauVaoB9;
                                    dBatDauVaoB9 = Convert.ToDateTime(sNgayCham + " " + string.Format("{0:T}", Convert.ToDateTime(dtTuDongQuaDemCa9.Rows[iTuDongQuaDemCa9]["BatDauVao"].ToString())).Replace("00 ", sGiayGioVao21 + " "));
                                    DateTime dKetThucVaoB9;
                                    dKetThucVaoB9 = Convert.ToDateTime(sNgayCham + " " + string.Format("{0:T}", Convert.ToDateTime(dtTuDongQuaDemCa9.Rows[iTuDongQuaDemCa9]["KetThucVao"].ToString())).Replace("00 ", sGiayGioVao21 + " "));
                                    DateTime dBatDauRaB9;
                                    dBatDauRaB9 = Convert.ToDateTime(sNgayCham + " " + string.Format("{0:T}", Convert.ToDateTime(dtTuDongQuaDemCa9.Rows[iTuDongQuaDemCa9]["BatDauRa"].ToString())).Replace("00 ", sGiayGioRa21 + " "));
                                    DateTime dKetThucRaB9;
                                    dKetThucRaB9 = Convert.ToDateTime(sNgayCham + " " + string.Format("{0:T}", Convert.ToDateTime(dtTuDongQuaDemCa9.Rows[iTuDongQuaDemCa9]["KetThucRa"].ToString())).Replace("00 ", sGiayGioRa21 + " "));
                                    if (dtTuDongQuaDemCa9.Rows[iTuDongQuaDemCa9]["TinhBuTru"].ToString() == "True")
                                    {
                                        iTinhBuTru++;
                                    }
                                    if (dGioVaoTuDong >= dBatDauVaoB9 && dGioVaoTuDong <= dKetThucVaoB9)
                                    {
                                        kiemTraVao++;
                                    }
                                    if (dGioRaTuDong >= dBatDauRaB9 && dGioRaTuDong <= dKetThucRaB9)
                                    {
                                        kiemTraRa++;
                                    }
                                    if (kiemTraVao != 1 || kiemTraRa != 1)
                                    {
                                        iTuDongQuaDemCa9++;
                                        continue;
                                    }
                                    goto IL_f776;
                                }

                                this.DGVTinhCong.Rows[addTuDong].Cells["Ca"].Value = ca;
                                this.DGVTinhCong.Rows[addTuDong].Cells["Cong"].Value = "0";
                                this.DGVTinhCong.Rows[addTuDong].Cells["Gio"].Value = "0";
                                this.DGVTinhCong.Rows[addTuDong].Cells["Tre"].Value = "0";
                                this.DGVTinhCong.Rows[addTuDong].Cells["VeSom"].Value = "0";
                                this.DGVTinhCong.Rows[addTuDong].Cells["VeTre"].Value = "0";
                                this.DGVTinhCong.Rows[addTuDong].Cells["TC1"].Value = "0";
                                this.DGVTinhCong.Rows[addTuDong].Cells["TC2"].Value = "0";
                                this.DGVTinhCong.Rows[addTuDong].Cells["TC3"].Value = "0";
                                this.DGVTinhCong.Rows[addTuDong].Cells["TC4"].Value = "0";
                                this.DGVTinhCong.Rows[addTuDong].Cells["TongGio"].Value = "0";
                                this.DGVTinhCong.Rows[addTuDong].Cells["DemCong"].Value = "0";
                                this.DGVTinhCong.Rows[addTuDong].Cells["KyHieu"].Value = this.sKHVang;
                                if (DateTimeProgress.XuatIDThu((int)dt.AddDays(dem).DayOfWeek) == "0")
                                {
                                    this.DGVTinhCong.Rows[addTuDong].Cells["IDThu"].Value = "CN";
                                }
                                else
                                {
                                    this.DGVTinhCong.Rows[addTuDong].Cells["IDThu"].Value = "NT";
                                }
                                this.DGVTinhCong.Rows[addTuDong].Cells["MaChamCong"].Value = this.sMaChamCong;
                                this.DGVTinhCong.Rows[addTuDong].Cells["PhongBan"].Value = this.sPhongBanTinhCong;
                                break;
                            }
                            goto IL_f776;
                        IL_f776:
                            this.DGVTinhCong.Rows[addTuDong].Cells["Ca"].Value = this.sTuDongQuaDemTenCaLamViec;
                            new DataTable();
                            DataTable dtCaLamViecTuDongKhongQuaDem2;
                            dtCaLamViecTuDongKhongQuaDem2 = this._caLamViecBLL.CaLamViecGetByMaCaLamViec(sTuDongQuaDemMaCaLamViec);
                            for (int iCaLamViecTuDongKhongQuaDem2 = 0; iCaLamViecTuDongKhongQuaDem2 < dtCaLamViecTuDongKhongQuaDem2.Rows.Count; iCaLamViecTuDongKhongQuaDem2++)
                            {
                                string sGiayGioVao22;
                                sGiayGioVao22 = dGioVaoTuDong.Second.ToString();
                                string sGiayGioRa22;
                                sGiayGioRa22 = dGioRaTuDong.Second.ToString();
                                DateTime dGioVaoKhaiBaoTuDongKhongQuaDemB2;
                                dGioVaoKhaiBaoTuDongKhongQuaDemB2 = Convert.ToDateTime(sNgayCham + " " + string.Format("{0:T}", Convert.ToDateTime(dtCaLamViecTuDongKhongQuaDem2.Rows[iCaLamViecTuDongKhongQuaDem2]["GioVaoLamViec"].ToString())).Replace("00 ", sGiayGioVao22 + " "));
                                DateTime dGioRaKhaiBaoTuDongKhongQuaDemB2;
                                dGioRaKhaiBaoTuDongKhongQuaDemB2 = Convert.ToDateTime(sNgayCham + " " + string.Format("{0:T}", Convert.ToDateTime(dtCaLamViecTuDongKhongQuaDem2.Rows[iCaLamViecTuDongKhongQuaDem2]["GioKetThucLamViec"].ToString())).Replace("00 ", sGiayGioRa22 + " "));
                                string sXemCaNayLaTangCa7;
                                sXemCaNayLaTangCa7 = dtCaLamViecTuDongKhongQuaDem2.Rows[iCaLamViecTuDongKhongQuaDem2]["XemCaNayLaTangCa"].ToString();
                                int iTangCaMuc7;
                                iTangCaMuc7 = Convert.ToInt32(dtCaLamViecTuDongKhongQuaDem2.Rows[iCaLamViecTuDongKhongQuaDem2]["TangCaMuc"].ToString());
                                string sXemChuNhatLaTangCa2;
                                sXemChuNhatLaTangCa2 = dtCaLamViecTuDongKhongQuaDem2.Rows[iCaLamViecTuDongKhongQuaDem2]["XemCuoiTuanLaTangCa"].ToString();
                                int iTangCaChuNhatMuc2;
                                iTangCaChuNhatMuc2 = Convert.ToInt32(dtCaLamViecTuDongKhongQuaDem2.Rows[iCaLamViecTuDongKhongQuaDem2]["TangCaCuoiTuanMuc"].ToString());
                                if (sXemCaNayLaTangCa7 == "True")
                                {
                                    dtCaLamViecTuDongKhongQuaDem2.Rows[iCaLamViecTuDongKhongQuaDem2]["TruGioDiTre"].ToString();
                                    dtCaLamViecTuDongKhongQuaDem2.Rows[iCaLamViecTuDongKhongQuaDem2]["BatDauTinhDiTre"].ToString();
                                    Convert.ToInt32(dtCaLamViecTuDongKhongQuaDem2.Rows[iCaLamViecTuDongKhongQuaDem2]["ChoPhepDiTre"].ToString());
                                    string sPhutTre23;
                                    sPhutTre23 = Convert.ToInt32((dGioVaoTuDong - dGioVaoKhaiBaoTuDongKhongQuaDemB2).TotalMinutes).ToString();
                                    if (Convert.ToInt32(sPhutTre23) < 0)
                                    {
                                        sPhutTre23 = "0";
                                    }
                                    dtCaLamViecTuDongKhongQuaDem2.Rows[iCaLamViecTuDongKhongQuaDem2]["TruGioVeSom"].ToString();
                                    dtCaLamViecTuDongKhongQuaDem2.Rows[iCaLamViecTuDongKhongQuaDem2]["BatDauTinhVeSom"].ToString();
                                    Convert.ToInt32(dtCaLamViecTuDongKhongQuaDem2.Rows[iCaLamViecTuDongKhongQuaDem2]["ChoPhepVeSom"].ToString());
                                    string sPhutVeSom24;
                                    sPhutVeSom24 = Convert.ToInt32((dGioRaKhaiBaoTuDongKhongQuaDemB2 - dGioRaTuDong).TotalMinutes).ToString();
                                    if (Convert.ToInt32(sPhutVeSom24) < 0)
                                    {
                                        sPhutVeSom24 = "0";
                                    }
                                    double dTongGioTangCaTuDongKhongQuaDem2;
                                    dTongGioTangCaTuDongKhongQuaDem2 = Math.Round((Convert.ToDouble(dtCaLamViecTuDongKhongQuaDem2.Rows[iCaLamViecTuDongKhongQuaDem2]["TongGioTrongCaLamViec"]) * 60.0 - (Convert.ToDouble(sPhutTre23) + Convert.ToDouble(sPhutVeSom24))) / 60.0, this.iLamTronGio);
                                    if (iTangCaMuc7 == 1)
                                    {
                                        this.DGVTinhCong.Rows[addTuDong].Cells["Cong"].Value = "0";
                                        this.DGVTinhCong.Rows[addTuDong].Cells["Gio"].Value = "0";
                                        this.DGVTinhCong.Rows[addTuDong].Cells["TC1"].Value = dTongGioTangCaTuDongKhongQuaDem2 * this.dTangCa1HeSo;
                                        this.DGVTinhCong.Rows[addTuDong].Cells["KyHieu"].Value = this.sKHDungGio;
                                    }
                                    if (iTangCaMuc7 == 2)
                                    {
                                        this.DGVTinhCong.Rows[addTuDong].Cells["Cong"].Value = "0";
                                        this.DGVTinhCong.Rows[addTuDong].Cells["Gio"].Value = "0";
                                        Math.Round(Convert.ToDouble(Convert.ToInt32((dGioRaTuDong - dGioVaoKhaiBaoTuDongKhongQuaDemB2).TotalMinutes).ToString()) / 60.0, this.iLamTronGio);
                                        this.DGVTinhCong.Rows[addTuDong].Cells["TC2"].Value = dTongGioTangCaTuDongKhongQuaDem2 * this.dTangCa2HeSo;
                                        this.DGVTinhCong.Rows[addTuDong].Cells["KyHieu"].Value = this.sKHDungGio;
                                    }
                                    if (iTangCaMuc7 == 3)
                                    {
                                        this.DGVTinhCong.Rows[addTuDong].Cells["Cong"].Value = "0";
                                        this.DGVTinhCong.Rows[addTuDong].Cells["Gio"].Value = "0";
                                        Math.Round(Convert.ToDouble(Convert.ToInt32((dGioRaTuDong - dGioVaoKhaiBaoTuDongKhongQuaDemB2).TotalMinutes).ToString()) / 60.0, this.iLamTronGio);
                                        this.DGVTinhCong.Rows[addTuDong].Cells["TC3"].Value = dTongGioTangCaTuDongKhongQuaDem2 * this.dTangCa3HeSo;
                                        this.DGVTinhCong.Rows[addTuDong].Cells["KyHieu"].Value = this.sKHDungGio;
                                    }
                                    if (iTangCaMuc7 == 4)
                                    {
                                        this.DGVTinhCong.Rows[addTuDong].Cells["Cong"].Value = "0";
                                        this.DGVTinhCong.Rows[addTuDong].Cells["Gio"].Value = "0";
                                        Math.Round(Convert.ToDouble(Convert.ToInt32((dGioRaTuDong - dGioVaoKhaiBaoTuDongKhongQuaDemB2).TotalMinutes).ToString()) / 60.0, this.iLamTronGio);
                                        this.DGVTinhCong.Rows[addTuDong].Cells["TC4"].Value = dTongGioTangCaTuDongKhongQuaDem2 * this.dTangCa4HeSo;
                                        this.DGVTinhCong.Rows[addTuDong].Cells["KyHieu"].Value = this.sKHDungGio;
                                    }
                                    continue;
                                }
                                if (DateTimeProgress.XuatIDThu((int)dt.AddDays(dem).DayOfWeek) == "0")
                                {
                                    if (sXemChuNhatLaTangCa2 == "True")
                                    {
                                        dtCaLamViecTuDongKhongQuaDem2.Rows[iCaLamViecTuDongKhongQuaDem2]["TruGioDiTre"].ToString();
                                        dtCaLamViecTuDongKhongQuaDem2.Rows[iCaLamViecTuDongKhongQuaDem2]["BatDauTinhDiTre"].ToString();
                                        Convert.ToInt32(dtCaLamViecTuDongKhongQuaDem2.Rows[iCaLamViecTuDongKhongQuaDem2]["ChoPhepDiTre"].ToString());
                                        string sPhutTre22;
                                        sPhutTre22 = Convert.ToInt32((dGioVaoTuDong - dGioVaoKhaiBaoTuDongKhongQuaDemB2).TotalMinutes).ToString();
                                        if (Convert.ToInt32(sPhutTre22) < 0)
                                        {
                                            sPhutTre22 = "0";
                                        }
                                        dtCaLamViecTuDongKhongQuaDem2.Rows[iCaLamViecTuDongKhongQuaDem2]["TruGioVeSom"].ToString();
                                        dtCaLamViecTuDongKhongQuaDem2.Rows[iCaLamViecTuDongKhongQuaDem2]["BatDauTinhVeSom"].ToString();
                                        Convert.ToInt32(dtCaLamViecTuDongKhongQuaDem2.Rows[iCaLamViecTuDongKhongQuaDem2]["ChoPhepVeSom"].ToString());
                                        string sPhutVeSom22;
                                        sPhutVeSom22 = Convert.ToInt32((dGioRaKhaiBaoTuDongKhongQuaDemB2 - dGioRaTuDong).TotalMinutes).ToString();
                                        if (Convert.ToInt32(sPhutVeSom22) < 0)
                                        {
                                            sPhutVeSom22 = "0";
                                        }
                                        double dTongGioTangCaTuDongKhongQuaDemA2;
                                        dTongGioTangCaTuDongKhongQuaDemA2 = Math.Round((Convert.ToDouble(dtCaLamViecTuDongKhongQuaDem2.Rows[iCaLamViecTuDongKhongQuaDem2]["TongGioTrongCaLamViec"]) * 60.0 - (Convert.ToDouble(sPhutTre22) + Convert.ToDouble(sPhutVeSom22))) / 60.0, this.iLamTronGio);
                                        if (iTangCaChuNhatMuc2 == 1)
                                        {
                                            this.DGVTinhCong.Rows[addTuDong].Cells["Cong"].Value = "0";
                                            this.DGVTinhCong.Rows[addTuDong].Cells["Gio"].Value = "0";
                                            if (dTongGioTangCaTuDongKhongQuaDemA2 <= 3.0)
                                            {
                                                this.DGVTinhCong.Rows[addTuDong].Cells["TC1"].Value = dTongGioTangCaTuDongKhongQuaDemA2 * this.dTangCaChuNhatHeSo;
                                            }
                                            else
                                            {
                                                this.DGVTinhCong.Rows[addTuDong].Cells["TC1"].Value = 3.0 * this.dTangCaChuNhatHeSo;
                                            }
                                            this.DGVTinhCong.Rows[addTuDong].Cells["KyHieu"].Value = this.sKHDungGio;
                                        }
                                        if (iTangCaChuNhatMuc2 == 2)
                                        {
                                            this.DGVTinhCong.Rows[addTuDong].Cells["Cong"].Value = "0";
                                            this.DGVTinhCong.Rows[addTuDong].Cells["Gio"].Value = "0";
                                            this.DGVTinhCong.Rows[addTuDong].Cells["TC2"].Value = dTongGioTangCaTuDongKhongQuaDemA2 * this.dTangCaChuNhatHeSo;
                                            this.DGVTinhCong.Rows[addTuDong].Cells["KyHieu"].Value = this.sKHDungGio;
                                        }
                                        if (iTangCaChuNhatMuc2 == 3)
                                        {
                                            this.DGVTinhCong.Rows[addTuDong].Cells["Cong"].Value = "0";
                                            this.DGVTinhCong.Rows[addTuDong].Cells["Gio"].Value = "0";
                                            this.DGVTinhCong.Rows[addTuDong].Cells["TC3"].Value = dTongGioTangCaTuDongKhongQuaDemA2 * this.dTangCaChuNhatHeSo;
                                            this.DGVTinhCong.Rows[addTuDong].Cells["KyHieu"].Value = this.sKHDungGio;
                                        }
                                        if (iTangCaChuNhatMuc2 == 4)
                                        {
                                            this.DGVTinhCong.Rows[addTuDong].Cells["Cong"].Value = "0";
                                            this.DGVTinhCong.Rows[addTuDong].Cells["Gio"].Value = "0";
                                            this.DGVTinhCong.Rows[addTuDong].Cells["TC4"].Value = dTongGioTangCaTuDongKhongQuaDemA2 * this.dTangCaChuNhatHeSo;
                                            this.DGVTinhCong.Rows[addTuDong].Cells["KyHieu"].Value = this.sKHDungGio;
                                        }
                                        continue;
                                    }
                                    string sTruGioDiTre17;
                                    sTruGioDiTre17 = dtCaLamViecTuDongKhongQuaDem2.Rows[iCaLamViecTuDongKhongQuaDem2]["TruGioDiTre"].ToString();
                                    string sBatDauTinhDiTre17;
                                    sBatDauTinhDiTre17 = dtCaLamViecTuDongKhongQuaDem2.Rows[iCaLamViecTuDongKhongQuaDem2]["BatDauTinhDiTre"].ToString();
                                    int iChoPhepDiTre14;
                                    iChoPhepDiTre14 = Convert.ToInt32(dtCaLamViecTuDongKhongQuaDem2.Rows[iCaLamViecTuDongKhongQuaDem2]["ChoPhepDiTre"].ToString());
                                    string sPhutTre19;
                                    sPhutTre19 = Convert.ToInt32((dGioVaoTuDong - dGioVaoKhaiBaoTuDongKhongQuaDemB2).TotalMinutes).ToString();
                                    if (sTruGioDiTre17 == "True")
                                    {
                                        if (Convert.ToInt32(sPhutTre19) < 0)
                                        {
                                            this.DGVTinhCong.Rows[addTuDong].Cells["Tre"].Value = "0";
                                        }
                                        else
                                        {
                                            int iPhutTre15;
                                            iPhutTre15 = Convert.ToInt32(sPhutTre19) - iChoPhepDiTre14;
                                            if (sBatDauTinhDiTre17 == "True")
                                            {
                                                if (iPhutTre15 < 1)
                                                {
                                                    this.DGVTinhCong.Rows[addTuDong].Cells["Tre"].Value = "0";
                                                }
                                                else
                                                {
                                                    this.DGVTinhCong.Rows[addTuDong].Cells["Tre"].Value = iPhutTre15.ToString();
                                                }
                                            }
                                            else if (iPhutTre15 < 1)
                                            {
                                                this.DGVTinhCong.Rows[addTuDong].Cells["Tre"].Value = "0";
                                            }
                                            else
                                            {
                                                this.DGVTinhCong.Rows[addTuDong].Cells["Tre"].Value = sPhutTre19;
                                            }
                                        }
                                    }
                                    else
                                    {
                                        this.DGVTinhCong.Rows[addTuDong].Cells["Tre"].Value = "0";
                                    }
                                    string sTruGioVeSom18;
                                    sTruGioVeSom18 = dtCaLamViecTuDongKhongQuaDem2.Rows[iCaLamViecTuDongKhongQuaDem2]["TruGioVeSom"].ToString();
                                    string sBatDauTinhVeSom18;
                                    sBatDauTinhVeSom18 = dtCaLamViecTuDongKhongQuaDem2.Rows[iCaLamViecTuDongKhongQuaDem2]["BatDauTinhVeSom"].ToString();
                                    int iChoPhepVeSom15;
                                    iChoPhepVeSom15 = Convert.ToInt32(dtCaLamViecTuDongKhongQuaDem2.Rows[iCaLamViecTuDongKhongQuaDem2]["ChoPhepVeSom"].ToString());
                                    string sPhutVeSom19;
                                    sPhutVeSom19 = Convert.ToInt32((dGioRaKhaiBaoTuDongKhongQuaDemB2 - dGioRaTuDong).TotalMinutes).ToString();
                                    if (sTruGioVeSom18 == "True")
                                    {
                                        if (Convert.ToInt32(sPhutVeSom19) < 0)
                                        {
                                            this.DGVTinhCong.Rows[addTuDong].Cells["VeSom"].Value = "0";
                                        }
                                        else
                                        {
                                            int iPhutVeSom15;
                                            iPhutVeSom15 = Convert.ToInt32(sPhutVeSom19) - iChoPhepVeSom15;
                                            if (iPhutVeSom15 < 1)
                                            {
                                                this.DGVTinhCong.Rows[addTuDong].Cells["VeSom"].Value = "0";
                                            }
                                            else if (sBatDauTinhVeSom18 == "True")
                                            {
                                                this.DGVTinhCong.Rows[addTuDong].Cells["VeSom"].Value = iPhutVeSom15.ToString();
                                            }
                                            else
                                            {
                                                this.DGVTinhCong.Rows[addTuDong].Cells["VeSom"].Value = sPhutVeSom19;
                                            }
                                        }
                                    }
                                    else
                                    {
                                        this.DGVTinhCong.Rows[addTuDong].Cells["VeSom"].Value = "0";
                                    }
                                    string sVeTre14;
                                    sVeTre14 = Convert.ToInt32((dGioRaTuDong - dGioRaKhaiBaoTuDongKhongQuaDemB2).TotalMinutes).ToString();
                                    if (Convert.ToInt32(sVeTre14) > 0)
                                    {
                                        this.DGVTinhCong.Rows[addTuDong].Cells["VeTre"].Value = sVeTre14;
                                    }
                                    else
                                    {
                                        this.DGVTinhCong.Rows[addTuDong].Cells["VeTre"].Value = "0";
                                    }
                                    double dGio15;
                                    dGio15 = Math.Round(Convert.ToDouble(Convert.ToSingle(dtCaLamViecTuDongKhongQuaDem2.Rows[iCaLamViecTuDongKhongQuaDem2]["TongGioTrongCaLamViec"]) * 60f - (float)(Convert.ToInt32(this.DGVTinhCong.Rows[addTuDong].Cells["Tre"].Value.ToString()) + Convert.ToInt32(this.DGVTinhCong.Rows[addTuDong].Cells["VeSom"].Value))) / 60.0, this.iLamTronGio);
                                    this.DGVTinhCong.Rows[addTuDong].Cells["Gio"].Value = dGio15 * this.dTangCaChuNhatHeSo;
                                    double iGio15;
                                    iGio15 = Convert.ToDouble(dtCaLamViecTuDongKhongQuaDem2.Rows[iCaLamViecTuDongKhongQuaDem2]["TongGioTrongCaLamViec"].ToString());
                                    double dCong15;
                                    dCong15 = Math.Round(dGio15 * Convert.ToDouble(dtCaLamViecTuDongKhongQuaDem2.Rows[iCaLamViecTuDongKhongQuaDem2]["CongTinh"].ToString()) / iGio15, this.iLamTronCong);
                                    this.DGVTinhCong.Rows[addTuDong].Cells["Cong"].Value = dCong15 * this.dTangCaChuNhatHeSo;
                                    double dTongGioThucTeTuDongKhongQuaDem4;
                                    dTongGioThucTeTuDongKhongQuaDem4 = Math.Round(Convert.ToDouble(Convert.ToInt32((dGioRaTuDong - dGioVaoTuDong).TotalMinutes).ToString()) / 60.0, this.iLamTronGio);
                                    this.DGVTinhCong.Rows[addTuDong].Cells["TongGio"].Value = dTongGioThucTeTuDongKhongQuaDem4 * this.dTangCaChuNhatHeSo;
                                    this.DGVTinhCong.Rows[addTuDong].Cells["DemCong"].Value = Convert.ToDouble(dtCaLamViecTuDongKhongQuaDem2.Rows[iCaLamViecTuDongKhongQuaDem2]["CongTinh"].ToString()) * this.dTangCaChuNhatHeSo;
                                    this.DGVTinhCong.Rows[addTuDong].Cells["KyHieu"].Value = this.sKHDungGio;
                                    string sChoPhepTangCaTruocGioLamViecTuDongKhongQuaDem4;
                                    sChoPhepTangCaTruocGioLamViecTuDongKhongQuaDem4 = dtCaLamViecTuDongKhongQuaDem2.Rows[iCaLamViecTuDongKhongQuaDem2]["TangCaTruocGioLamViec"].ToString();
                                    int iPhutTangCaTruocGioLamViecTuDongKhongQuaDem4;
                                    iPhutTangCaTruocGioLamViecTuDongKhongQuaDem4 = Convert.ToInt32(dtCaLamViecTuDongKhongQuaDem2.Rows[iCaLamViecTuDongKhongQuaDem2]["SoPhutTangCaTruocGioLamViec"].ToString());
                                    int iPhutTangCaTruocGioLamViecDatDen18;
                                    iPhutTangCaTruocGioLamViecDatDen18 = Convert.ToInt32(dtCaLamViecTuDongKhongQuaDem2.Rows[iCaLamViecTuDongKhongQuaDem2]["TangCaTruocGioLamViecDatDen"].ToString());
                                    int iPhutTruTangCaTruoc18;
                                    iPhutTruTangCaTruoc18 = Convert.ToInt32(dtCaLamViecTuDongKhongQuaDem2.Rows[iCaLamViecTuDongKhongQuaDem2]["PhutTruTangCaTruoc"].ToString());
                                    string sChoPhepTangCaSauGioLamViecTuDongKhongQuaDem4;
                                    sChoPhepTangCaSauGioLamViecTuDongKhongQuaDem4 = dtCaLamViecTuDongKhongQuaDem2.Rows[iCaLamViecTuDongKhongQuaDem2]["TangCaSauGioLamViec"].ToString();
                                    int iPhutTangCaSauGioLamViecTuDongKhongQuaDem4;
                                    iPhutTangCaSauGioLamViecTuDongKhongQuaDem4 = Convert.ToInt32(dtCaLamViecTuDongKhongQuaDem2.Rows[iCaLamViecTuDongKhongQuaDem2]["SoPhutTangCaSauGioLamViec"].ToString());
                                    int iPhutTangCaSauGioLamViecDatDen18;
                                    iPhutTangCaSauGioLamViecDatDen18 = Convert.ToInt32(dtCaLamViecTuDongKhongQuaDem2.Rows[iCaLamViecTuDongKhongQuaDem2]["TangCaSauGioLamViecDatDen"].ToString());
                                    int iPhutTruTangCaSau18;
                                    iPhutTruTangCaSau18 = Convert.ToInt32(dtCaLamViecTuDongKhongQuaDem2.Rows[iCaLamViecTuDongKhongQuaDem2]["PhutTruTangCaSau"].ToString());
                                    int iGioiHanTC1TuDongKhongQuaDem4;
                                    iGioiHanTC1TuDongKhongQuaDem4 = Convert.ToInt32(dtCaLamViecTuDongKhongQuaDem2.Rows[iCaLamViecTuDongKhongQuaDem2]["GioiHanTangCa1"].ToString());
                                    int iGioiHanTC2TuDongKhongQuaDem4;
                                    iGioiHanTC2TuDongKhongQuaDem4 = Convert.ToInt32(dtCaLamViecTuDongKhongQuaDem2.Rows[iCaLamViecTuDongKhongQuaDem2]["GioiHanTangCa2"].ToString());
                                    int iGioiHanTC3TuDongKhongQuaDem4;
                                    iGioiHanTC3TuDongKhongQuaDem4 = Convert.ToInt32(dtCaLamViecTuDongKhongQuaDem2.Rows[iCaLamViecTuDongKhongQuaDem2]["GioiHanTangCa3"].ToString());
                                    int iGioiHanTC4TuDongKhongQuaDem4;
                                    iGioiHanTC4TuDongKhongQuaDem4 = Convert.ToInt32(dtCaLamViecTuDongKhongQuaDem2.Rows[iCaLamViecTuDongKhongQuaDem2]["GioiHanTangCa4"].ToString());
                                    int iTongGioTangCaSauTuDongKhongQuaDem4;
                                    iTongGioTangCaSauTuDongKhongQuaDem4 = 0;
                                    int iTongGioTangCaTruocTuDongKhongQuaDem4;
                                    iTongGioTangCaTruocTuDongKhongQuaDem4 = 0;
                                    if (sChoPhepTangCaTruocGioLamViecTuDongKhongQuaDem4 == "False" && sChoPhepTangCaSauGioLamViecTuDongKhongQuaDem4 == "False")
                                    {
                                        this.DGVTinhCong.Rows[addTuDong].Cells["TC1"].Value = "0";
                                        this.DGVTinhCong.Rows[addTuDong].Cells["TC2"].Value = "0";
                                        this.DGVTinhCong.Rows[addTuDong].Cells["TC3"].Value = "0";
                                        this.DGVTinhCong.Rows[addTuDong].Cells["TC4"].Value = "0";
                                    }
                                    else
                                    {
                                        if (sChoPhepTangCaTruocGioLamViecTuDongKhongQuaDem4 == "True")
                                        {
                                            int iThoiGianTruocGioLamTuDongKhongQuaDem4;
                                            iThoiGianTruocGioLamTuDongKhongQuaDem4 = Convert.ToInt32(Convert.ToInt32((dGioVaoKhaiBaoTuDongKhongQuaDemB2 - dGioVaoTuDong).TotalMinutes).ToString());
                                            if (iThoiGianTruocGioLamTuDongKhongQuaDem4 > 0 && iThoiGianTruocGioLamTuDongKhongQuaDem4 > iPhutTangCaTruocGioLamViecTuDongKhongQuaDem4 && iThoiGianTruocGioLamTuDongKhongQuaDem4 > iPhutTangCaTruocGioLamViecDatDen18)
                                            {
                                                iTongGioTangCaTruocTuDongKhongQuaDem4 = iThoiGianTruocGioLamTuDongKhongQuaDem4 - iPhutTruTangCaTruoc18;
                                            }
                                        }
                                        if (sChoPhepTangCaSauGioLamViecTuDongKhongQuaDem4 == "True")
                                        {
                                            int iThoiGianSauGioLamViecTuDongKhongQuaDem4;
                                            iThoiGianSauGioLamViecTuDongKhongQuaDem4 = Convert.ToInt32(Convert.ToInt32((dGioRaTuDong - dGioRaKhaiBaoTuDongKhongQuaDemB2).TotalMinutes).ToString());
                                            if (iThoiGianSauGioLamViecTuDongKhongQuaDem4 > 0 && iThoiGianSauGioLamViecTuDongKhongQuaDem4 > iPhutTangCaSauGioLamViecTuDongKhongQuaDem4)
                                            {
                                                iTongGioTangCaSauTuDongKhongQuaDem4 = ((iThoiGianSauGioLamViecTuDongKhongQuaDem4 < iPhutTangCaSauGioLamViecDatDen18) ? iThoiGianSauGioLamViecTuDongKhongQuaDem4 : (iThoiGianSauGioLamViecTuDongKhongQuaDem4 - iPhutTruTangCaSau18));
                                            }
                                        }
                                    }
                                    double dTongThoiGianTangCaTuDongKhongQuaDem4;
                                    dTongThoiGianTangCaTuDongKhongQuaDem4 = Convert.ToDouble(iTongGioTangCaTruocTuDongKhongQuaDem4 + iTongGioTangCaSauTuDongKhongQuaDem4);
                                    if (dTongThoiGianTangCaTuDongKhongQuaDem4 > 0.0)
                                    {
                                        if (iGioiHanTC1TuDongKhongQuaDem4 == 0)
                                        {
                                            this.DGVTinhCong.Rows[addTuDong].Cells["TC1"].Value = Math.Round(dTongThoiGianTangCaTuDongKhongQuaDem4 * this.dTangCa1HeSo / 60.0, this.iLamTronGio);
                                            this.DGVTinhCong.Rows[addTuDong].Cells["TC2"].Value = "0";
                                            this.DGVTinhCong.Rows[addTuDong].Cells["TC3"].Value = "0";
                                            this.DGVTinhCong.Rows[addTuDong].Cells["TC4"].Value = "0";
                                        }
                                        if (iGioiHanTC1TuDongKhongQuaDem4 != 0 && iGioiHanTC2TuDongKhongQuaDem4 == 0)
                                        {
                                            if (dTongThoiGianTangCaTuDongKhongQuaDem4 < Convert.ToDouble(iGioiHanTC1TuDongKhongQuaDem4))
                                            {
                                                this.DGVTinhCong.Rows[addTuDong].Cells["TC1"].Value = Math.Round(dTongThoiGianTangCaTuDongKhongQuaDem4 * this.dTangCa1HeSo / 60.0, this.iLamTronGio);
                                                this.DGVTinhCong.Rows[addTuDong].Cells["TC2"].Value = "0";
                                                this.DGVTinhCong.Rows[addTuDong].Cells["TC3"].Value = "0";
                                                this.DGVTinhCong.Rows[addTuDong].Cells["TC4"].Value = "0";
                                            }
                                            else
                                            {
                                                this.DGVTinhCong.Rows[addTuDong].Cells["TC1"].Value = Math.Round(Convert.ToDouble(iGioiHanTC1TuDongKhongQuaDem4) / 60.0 * this.dTangCa1HeSo, this.iLamTronGio);
                                                if (dTongThoiGianTangCaTuDongKhongQuaDem4 - Convert.ToDouble(iGioiHanTC1TuDongKhongQuaDem4) > 0.0)
                                                {
                                                    this.DGVTinhCong.Rows[addTuDong].Cells["TC2"].Value = Math.Round((dTongThoiGianTangCaTuDongKhongQuaDem4 - Convert.ToDouble(iGioiHanTC1TuDongKhongQuaDem4)) * this.dTangCa2HeSo / 60.0, this.iLamTronGio);
                                                }
                                                this.DGVTinhCong.Rows[addTuDong].Cells["TC3"].Value = "0";
                                                this.DGVTinhCong.Rows[addTuDong].Cells["TC4"].Value = "0";
                                            }
                                        }
                                        if (iGioiHanTC1TuDongKhongQuaDem4 != 0 && iGioiHanTC2TuDongKhongQuaDem4 != 0 && iGioiHanTC3TuDongKhongQuaDem4 == 0)
                                        {
                                            if (dTongThoiGianTangCaTuDongKhongQuaDem4 < Convert.ToDouble(iGioiHanTC1TuDongKhongQuaDem4))
                                            {
                                                this.DGVTinhCong.Rows[addTuDong].Cells["TC1"].Value = Math.Round(dTongThoiGianTangCaTuDongKhongQuaDem4 * this.dTangCa1HeSo / 60.0, this.iLamTronGio);
                                                this.DGVTinhCong.Rows[addTuDong].Cells["TC2"].Value = "0";
                                                this.DGVTinhCong.Rows[addTuDong].Cells["TC3"].Value = "0";
                                                this.DGVTinhCong.Rows[addTuDong].Cells["TC4"].Value = "0";
                                            }
                                            else
                                            {
                                                this.DGVTinhCong.Rows[addTuDong].Cells["TC1"].Value = Math.Round(Convert.ToDouble(iGioiHanTC1TuDongKhongQuaDem4) * this.dTangCa1HeSo / 60.0, this.iLamTronGio);
                                                if (dTongThoiGianTangCaTuDongKhongQuaDem4 - Convert.ToDouble(iGioiHanTC1TuDongKhongQuaDem4) < Convert.ToDouble(iGioiHanTC2TuDongKhongQuaDem4))
                                                {
                                                    this.DGVTinhCong.Rows[addTuDong].Cells["TC2"].Value = Math.Round((dTongThoiGianTangCaTuDongKhongQuaDem4 - Convert.ToDouble(iGioiHanTC1TuDongKhongQuaDem4)) * this.dTangCa2HeSo / 60.0, this.iLamTronGio);
                                                    this.DGVTinhCong.Rows[addTuDong].Cells["TC3"].Value = "0";
                                                    this.DGVTinhCong.Rows[addTuDong].Cells["TC4"].Value = "0";
                                                }
                                                else
                                                {
                                                    this.DGVTinhCong.Rows[addTuDong].Cells["TC1"].Value = Math.Round(Convert.ToDouble(iGioiHanTC1TuDongKhongQuaDem4) * this.dTangCa1HeSo / 60.0, this.iLamTronGio);
                                                    this.DGVTinhCong.Rows[addTuDong].Cells["TC2"].Value = Math.Round(Convert.ToDouble(iGioiHanTC2TuDongKhongQuaDem4) * this.dTangCa2HeSo / 60.0, this.iLamTronGio);
                                                    this.DGVTinhCong.Rows[addTuDong].Cells["TC3"].Value = Math.Round((dTongThoiGianTangCaTuDongKhongQuaDem4 - Convert.ToDouble(iGioiHanTC1TuDongKhongQuaDem4) - Convert.ToDouble(iGioiHanTC2TuDongKhongQuaDem4)) * this.dTangCa3HeSo / 60.0, this.iLamTronGio);
                                                    this.DGVTinhCong.Rows[addTuDong].Cells["TC4"].Value = "0";
                                                }
                                            }
                                        }
                                        if (iGioiHanTC1TuDongKhongQuaDem4 != 0 && iGioiHanTC2TuDongKhongQuaDem4 != 0 && iGioiHanTC3TuDongKhongQuaDem4 != 0 && iGioiHanTC4TuDongKhongQuaDem4 != 0)
                                        {
                                        }
                                    }
                                    else
                                    {
                                        this.DGVTinhCong.Rows[addTuDong].Cells["TC1"].Value = "0";
                                        this.DGVTinhCong.Rows[addTuDong].Cells["TC2"].Value = "0";
                                        this.DGVTinhCong.Rows[addTuDong].Cells["TC3"].Value = "0";
                                        this.DGVTinhCong.Rows[addTuDong].Cells["TC4"].Value = "0";
                                    }
                                    continue;
                                }
                                string sTruGioDiTre16;
                                sTruGioDiTre16 = dtCaLamViecTuDongKhongQuaDem2.Rows[iCaLamViecTuDongKhongQuaDem2]["TruGioDiTre"].ToString();
                                string sBatDauTinhDiTre16;
                                sBatDauTinhDiTre16 = dtCaLamViecTuDongKhongQuaDem2.Rows[iCaLamViecTuDongKhongQuaDem2]["BatDauTinhDiTre"].ToString();
                                int iChoPhepDiTre13;
                                iChoPhepDiTre13 = Convert.ToInt32(dtCaLamViecTuDongKhongQuaDem2.Rows[iCaLamViecTuDongKhongQuaDem2]["ChoPhepDiTre"].ToString());
                                string sPhutTre15;
                                sPhutTre15 = Convert.ToInt32((dGioVaoTuDong - dGioVaoKhaiBaoTuDongKhongQuaDemB2).TotalMinutes).ToString();
                                if (sTruGioDiTre16 == "True")
                                {
                                    if (Convert.ToInt32(sPhutTre15) < 0)
                                    {
                                        this.DGVTinhCong.Rows[addTuDong].Cells["Tre"].Value = "0";
                                    }
                                    else
                                    {
                                        int iPhutTre13;
                                        iPhutTre13 = Convert.ToInt32(sPhutTre15) - iChoPhepDiTre13;
                                        if (sBatDauTinhDiTre16 == "True")
                                        {
                                            if (iPhutTre13 < 1)
                                            {
                                                this.DGVTinhCong.Rows[addTuDong].Cells["Tre"].Value = "0";
                                            }
                                            else
                                            {
                                                this.DGVTinhCong.Rows[_nhanVien].Cells[5].Style.BackColor = Color.Lime;
                                                this.DGVTinhCong.Rows[addTuDong].Cells["Tre"].Value = iPhutTre13.ToString();
                                            }
                                        }
                                        else if (iPhutTre13 < 1)
                                        {
                                            this.DGVTinhCong.Rows[addTuDong].Cells["Tre"].Value = "0";
                                        }
                                        else
                                        {
                                            this.DGVTinhCong.Rows[addTuDong].Cells["Tre"].Value = sPhutTre15;
                                        }
                                    }
                                }
                                else
                                {
                                    this.DGVTinhCong.Rows[addTuDong].Cells["Tre"].Value = "0";
                                }
                                string sTruGioVeSom16;
                                sTruGioVeSom16 = dtCaLamViecTuDongKhongQuaDem2.Rows[iCaLamViecTuDongKhongQuaDem2]["TruGioVeSom"].ToString();
                                string sBatDauTinhVeSom16;
                                sBatDauTinhVeSom16 = dtCaLamViecTuDongKhongQuaDem2.Rows[iCaLamViecTuDongKhongQuaDem2]["BatDauTinhVeSom"].ToString();
                                int iChoPhepVeSom13;
                                iChoPhepVeSom13 = Convert.ToInt32(dtCaLamViecTuDongKhongQuaDem2.Rows[iCaLamViecTuDongKhongQuaDem2]["ChoPhepVeSom"].ToString());
                                string sPhutVeSom15;
                                sPhutVeSom15 = Convert.ToInt32((dGioRaKhaiBaoTuDongKhongQuaDemB2 - dGioRaTuDong).TotalMinutes).ToString();
                                if (sTruGioVeSom16 == "True")
                                {
                                    if (Convert.ToInt32(sPhutVeSom15) < 0)
                                    {
                                        this.DGVTinhCong.Rows[addTuDong].Cells["VeSom"].Value = "0";
                                    }
                                    else
                                    {
                                        int iPhutVeSom13;
                                        iPhutVeSom13 = Convert.ToInt32(sPhutVeSom15) - iChoPhepVeSom13;
                                        if (iPhutVeSom13 < 1)
                                        {
                                            this.DGVTinhCong.Rows[addTuDong].Cells["VeSom"].Value = "0";
                                        }
                                        else
                                        {
                                            this.DGVTinhCong.Rows[_nhanVien].Cells[6].Style.BackColor = Color.Yellow;
                                            if (sBatDauTinhVeSom16 == "True")
                                            {
                                                this.DGVTinhCong.Rows[addTuDong].Cells["VeSom"].Value = iPhutVeSom13.ToString();
                                            }
                                            else
                                            {
                                                this.DGVTinhCong.Rows[addTuDong].Cells["VeSom"].Value = sPhutVeSom15;
                                            }
                                        }
                                    }
                                }
                                else
                                {
                                    this.DGVTinhCong.Rows[addTuDong].Cells["VeSom"].Value = "0";
                                }
                                string sVeTre12;
                                sVeTre12 = Convert.ToInt32((dGioRaTuDong - dGioRaKhaiBaoTuDongKhongQuaDemB2).TotalMinutes).ToString();
                                if (Convert.ToInt32(sVeTre12) > 0)
                                {
                                    this.DGVTinhCong.Rows[addTuDong].Cells["VeTre"].Value = sVeTre12;
                                }
                                else
                                {
                                    this.DGVTinhCong.Rows[addTuDong].Cells["VeTre"].Value = "0";
                                }
                                double dGio12;
                                dGio12 = Math.Round(Convert.ToDouble(Convert.ToSingle(dtCaLamViecTuDongKhongQuaDem2.Rows[iCaLamViecTuDongKhongQuaDem2]["TongGioTrongCaLamViec"]) * 60f - (float)(Convert.ToInt32(this.DGVTinhCong.Rows[addTuDong].Cells["Tre"].Value.ToString()) + Convert.ToInt32(this.DGVTinhCong.Rows[addTuDong].Cells["VeSom"].Value))) / 60.0, this.iLamTronGio);
                                double dTongGioTrongCa2;
                                dTongGioTrongCa2 = Convert.ToDouble(dtCaLamViecTuDongKhongQuaDem2.Rows[iCaLamViecTuDongKhongQuaDem2]["TongGioTrongCaLamViec"].ToString());
                                if (iTinhBuTru != 0 && Convert.ToInt32(this.DGVTinhCong.Rows[_nhanVien].Cells["Tre"].Value) > 0 && Convert.ToInt32(this.DGVTinhCong.Rows[_nhanVien].Cells["VeTre"].Value) > 0)
                                {
                                    int iVeTre2;
                                    iVeTre2 = Convert.ToInt32(this.DGVTinhCong.Rows[addTuDong].Cells["VeTre"].Value);
                                    dGio12 = Math.Round(dGio12 + Convert.ToDouble(iVeTre2) / 60.0, 2);
                                    if (dGio12 > dTongGioTrongCa2)
                                    {
                                        iVeTre2 -= Convert.ToInt32(this.DGVTinhCong.Rows[addTuDong].Cells["Tre"].Value);
                                        dGio12 = dTongGioTrongCa2;
                                        this.DGVTinhCong.Rows[addTuDong].Cells["VeTre"].Value = iVeTre2;
                                        this.DGVTinhCong.Rows[addTuDong].Cells["Gio"].Value = dGio12.ToString();
                                    }
                                    else
                                    {
                                        this.DGVTinhCong.Rows[addTuDong].Cells["Gio"].Value = dGio12.ToString();
                                        this.DGVTinhCong.Rows[addTuDong].Cells["Tre"].Value = Convert.ToInt32(sPhutTre15) - iVeTre2;
                                        this.DGVTinhCong.Rows[addTuDong].Cells["VeTre"].Value = "0";
                                    }
                                }
                                else
                                {
                                    this.DGVTinhCong.Rows[addTuDong].Cells["Gio"].Value = dGio12.ToString();
                                }
                                double iGio12;
                                iGio12 = Convert.ToDouble(dtCaLamViecTuDongKhongQuaDem2.Rows[iCaLamViecTuDongKhongQuaDem2]["TongGioTrongCaLamViec"].ToString());
                                double dCongTinh11;
                                dCongTinh11 = Convert.ToDouble(dtCaLamViecTuDongKhongQuaDem2.Rows[iCaLamViecTuDongKhongQuaDem2]["CongTinh"].ToString());
                                double dCong12;
                                dCong12 = Math.Round(dGio12 * dCongTinh11 / iGio12, this.iLamTronCong);
                                this.DGVTinhCong.Rows[addTuDong].Cells["Cong"].Value = dCong12.ToString();
                                double dTongGioThucTeTuDongKhongQuaDem3;
                                dTongGioThucTeTuDongKhongQuaDem3 = Math.Round(Convert.ToDouble(Convert.ToInt32((dGioRaTuDong - dGioVaoTuDong).TotalMinutes).ToString()) / 60.0, this.iLamTronGio);
                                this.DGVTinhCong.Rows[addTuDong].Cells["TongGio"].Value = dTongGioThucTeTuDongKhongQuaDem3.ToString();
                                this.DGVTinhCong.Rows[addTuDong].Cells["DemCong"].Value = dtCaLamViecTuDongKhongQuaDem2.Rows[iCaLamViecTuDongKhongQuaDem2]["CongTinh"].ToString();
                                this.DGVTinhCong.Rows[addTuDong].Cells["KyHieu"].Value = this.sKHDungGio;
                                string sChoPhepTangCaTruocGioLamViecTuDongKhongQuaDem3;
                                sChoPhepTangCaTruocGioLamViecTuDongKhongQuaDem3 = dtCaLamViecTuDongKhongQuaDem2.Rows[iCaLamViecTuDongKhongQuaDem2]["TangCaTruocGioLamViec"].ToString();
                                int iPhutTangCaTruocGioLamViecTuDongKhongQuaDem3;
                                iPhutTangCaTruocGioLamViecTuDongKhongQuaDem3 = Convert.ToInt32(dtCaLamViecTuDongKhongQuaDem2.Rows[iCaLamViecTuDongKhongQuaDem2]["SoPhutTangCaTruocGioLamViec"].ToString());
                                int iPhutTangCaTruocGioLamViecDatDen15;
                                iPhutTangCaTruocGioLamViecDatDen15 = Convert.ToInt32(dtCaLamViecTuDongKhongQuaDem2.Rows[iCaLamViecTuDongKhongQuaDem2]["TangCaTruocGioLamViecDatDen"].ToString());
                                int iPhutTruTangCaTruoc15;
                                iPhutTruTangCaTruoc15 = Convert.ToInt32(dtCaLamViecTuDongKhongQuaDem2.Rows[iCaLamViecTuDongKhongQuaDem2]["PhutTruTangCaTruoc"].ToString());
                                string sChoPhepTangCaSauGioLamViecTuDongKhongQuaDem3;
                                sChoPhepTangCaSauGioLamViecTuDongKhongQuaDem3 = dtCaLamViecTuDongKhongQuaDem2.Rows[iCaLamViecTuDongKhongQuaDem2]["TangCaSauGioLamViec"].ToString();
                                int iPhutTangCaSauGioLamViecTuDongKhongQuaDem3;
                                iPhutTangCaSauGioLamViecTuDongKhongQuaDem3 = Convert.ToInt32(dtCaLamViecTuDongKhongQuaDem2.Rows[iCaLamViecTuDongKhongQuaDem2]["SoPhutTangCaSauGioLamViec"].ToString());
                                int iPhutTangCaSauGioLamViecDatDen15;
                                iPhutTangCaSauGioLamViecDatDen15 = Convert.ToInt32(dtCaLamViecTuDongKhongQuaDem2.Rows[iCaLamViecTuDongKhongQuaDem2]["TangCaSauGioLamViecDatDen"].ToString());
                                int iPhutTruTangCaSau15;
                                iPhutTruTangCaSau15 = Convert.ToInt32(dtCaLamViecTuDongKhongQuaDem2.Rows[iCaLamViecTuDongKhongQuaDem2]["PhutTruTangCaSau"].ToString());
                                int iGioiHanTC1TuDongKhongQuaDem3;
                                iGioiHanTC1TuDongKhongQuaDem3 = Convert.ToInt32(dtCaLamViecTuDongKhongQuaDem2.Rows[iCaLamViecTuDongKhongQuaDem2]["GioiHanTangCa1"].ToString());
                                int iGioiHanTC2TuDongKhongQuaDem3;
                                iGioiHanTC2TuDongKhongQuaDem3 = Convert.ToInt32(dtCaLamViecTuDongKhongQuaDem2.Rows[iCaLamViecTuDongKhongQuaDem2]["GioiHanTangCa2"].ToString());
                                int iGioiHanTC3TuDongKhongQuaDem3;
                                iGioiHanTC3TuDongKhongQuaDem3 = Convert.ToInt32(dtCaLamViecTuDongKhongQuaDem2.Rows[iCaLamViecTuDongKhongQuaDem2]["GioiHanTangCa3"].ToString());
                                int iGioiHanTC4TuDongKhongQuaDem3;
                                iGioiHanTC4TuDongKhongQuaDem3 = Convert.ToInt32(dtCaLamViecTuDongKhongQuaDem2.Rows[iCaLamViecTuDongKhongQuaDem2]["GioiHanTangCa4"].ToString());
                                int iTongGioTangCaSauTuDongKhongQuaDem3;
                                iTongGioTangCaSauTuDongKhongQuaDem3 = 0;
                                int iTongGioTangCaTruocTuDongKhongQuaDem3;
                                iTongGioTangCaTruocTuDongKhongQuaDem3 = 0;
                                if (sChoPhepTangCaTruocGioLamViecTuDongKhongQuaDem3 == "False" && sChoPhepTangCaSauGioLamViecTuDongKhongQuaDem3 == "False")
                                {
                                    this.DGVTinhCong.Rows[addTuDong].Cells["TC1"].Value = "0";
                                    this.DGVTinhCong.Rows[addTuDong].Cells["TC2"].Value = "0";
                                    this.DGVTinhCong.Rows[addTuDong].Cells["TC3"].Value = "0";
                                    this.DGVTinhCong.Rows[addTuDong].Cells["TC4"].Value = "0";
                                }
                                else
                                {
                                    if (sChoPhepTangCaTruocGioLamViecTuDongKhongQuaDem3 == "True")
                                    {
                                        int iThoiGianTruocGioLamTuDongKhongQuaDem3;
                                        iThoiGianTruocGioLamTuDongKhongQuaDem3 = Convert.ToInt32(Convert.ToInt32((dGioVaoKhaiBaoTuDongKhongQuaDemB2 - dGioVaoTuDong).TotalMinutes).ToString());
                                        if (iThoiGianTruocGioLamTuDongKhongQuaDem3 > 0 && iThoiGianTruocGioLamTuDongKhongQuaDem3 > iPhutTangCaTruocGioLamViecTuDongKhongQuaDem3 && iThoiGianTruocGioLamTuDongKhongQuaDem3 > iPhutTangCaTruocGioLamViecDatDen15)
                                        {
                                            iTongGioTangCaTruocTuDongKhongQuaDem3 = iThoiGianTruocGioLamTuDongKhongQuaDem3 - iPhutTruTangCaTruoc15;
                                        }
                                    }
                                    if (sChoPhepTangCaSauGioLamViecTuDongKhongQuaDem3 == "True")
                                    {
                                        int iThoiGianSauGioLamViecTuDongKhongQuaDem3;
                                        iThoiGianSauGioLamViecTuDongKhongQuaDem3 = Convert.ToInt32(this.DGVTinhCong.Rows[addTuDong].Cells["VeTre"].Value);
                                        if (iThoiGianSauGioLamViecTuDongKhongQuaDem3 > 0 && iThoiGianSauGioLamViecTuDongKhongQuaDem3 > iPhutTangCaSauGioLamViecTuDongKhongQuaDem3)
                                        {
                                            iTongGioTangCaSauTuDongKhongQuaDem3 = ((iThoiGianSauGioLamViecTuDongKhongQuaDem3 < iPhutTangCaSauGioLamViecDatDen15) ? iThoiGianSauGioLamViecTuDongKhongQuaDem3 : (iThoiGianSauGioLamViecTuDongKhongQuaDem3 - iPhutTruTangCaSau15));
                                        }
                                    }
                                }
                                double dTongThoiGianTangCaTuDongKhongQuaDem3;
                                dTongThoiGianTangCaTuDongKhongQuaDem3 = Convert.ToDouble(iTongGioTangCaTruocTuDongKhongQuaDem3 + iTongGioTangCaSauTuDongKhongQuaDem3);
                                if (dTongThoiGianTangCaTuDongKhongQuaDem3 > 0.0)
                                {
                                    if (iGioiHanTC1TuDongKhongQuaDem3 == 0)
                                    {
                                        this.DGVTinhCong.Rows[addTuDong].Cells["TC1"].Value = Math.Round(dTongThoiGianTangCaTuDongKhongQuaDem3 * this.dTangCa1HeSo / 60.0, this.iLamTronGio);
                                        this.DGVTinhCong.Rows[addTuDong].Cells["TC2"].Value = "0";
                                        this.DGVTinhCong.Rows[addTuDong].Cells["TC3"].Value = "0";
                                        this.DGVTinhCong.Rows[addTuDong].Cells["TC4"].Value = "0";
                                    }
                                    if (iGioiHanTC1TuDongKhongQuaDem3 != 0 && iGioiHanTC2TuDongKhongQuaDem3 == 0)
                                    {
                                        if (dTongThoiGianTangCaTuDongKhongQuaDem3 < Convert.ToDouble(iGioiHanTC1TuDongKhongQuaDem3))
                                        {
                                            this.DGVTinhCong.Rows[addTuDong].Cells["TC1"].Value = Math.Round(dTongThoiGianTangCaTuDongKhongQuaDem3 * this.dTangCa1HeSo / 60.0, this.iLamTronGio);
                                            this.DGVTinhCong.Rows[addTuDong].Cells["TC2"].Value = "0";
                                            this.DGVTinhCong.Rows[addTuDong].Cells["TC3"].Value = "0";
                                            this.DGVTinhCong.Rows[addTuDong].Cells["TC4"].Value = "0";
                                        }
                                        else
                                        {
                                            this.DGVTinhCong.Rows[addTuDong].Cells["TC1"].Value = Math.Round(Convert.ToDouble(iGioiHanTC1TuDongKhongQuaDem3) / 60.0 * this.dTangCa1HeSo, this.iLamTronGio);
                                            if (dTongThoiGianTangCaTuDongKhongQuaDem3 - Convert.ToDouble(iGioiHanTC1TuDongKhongQuaDem3) > 0.0)
                                            {
                                                this.DGVTinhCong.Rows[addTuDong].Cells["TC2"].Value = Math.Round((dTongThoiGianTangCaTuDongKhongQuaDem3 - Convert.ToDouble(iGioiHanTC1TuDongKhongQuaDem3)) * this.dTangCa2HeSo / 60.0, this.iLamTronGio);
                                            }
                                            this.DGVTinhCong.Rows[addTuDong].Cells["TC3"].Value = "0";
                                            this.DGVTinhCong.Rows[addTuDong].Cells["TC4"].Value = "0";
                                        }
                                    }
                                    if (iGioiHanTC1TuDongKhongQuaDem3 != 0 && iGioiHanTC2TuDongKhongQuaDem3 != 0 && iGioiHanTC3TuDongKhongQuaDem3 == 0)
                                    {
                                        if (dTongThoiGianTangCaTuDongKhongQuaDem3 < Convert.ToDouble(iGioiHanTC1TuDongKhongQuaDem3))
                                        {
                                            this.DGVTinhCong.Rows[addTuDong].Cells["TC1"].Value = Math.Round(dTongThoiGianTangCaTuDongKhongQuaDem3 * this.dTangCa1HeSo / 60.0, this.iLamTronGio);
                                            this.DGVTinhCong.Rows[addTuDong].Cells["TC2"].Value = "0";
                                            this.DGVTinhCong.Rows[addTuDong].Cells["TC3"].Value = "0";
                                            this.DGVTinhCong.Rows[addTuDong].Cells["TC4"].Value = "0";
                                        }
                                        else
                                        {
                                            this.DGVTinhCong.Rows[addTuDong].Cells["TC1"].Value = Math.Round(Convert.ToDouble(iGioiHanTC1TuDongKhongQuaDem3) * this.dTangCa1HeSo / 60.0, this.iLamTronGio);
                                            if (dTongThoiGianTangCaTuDongKhongQuaDem3 - Convert.ToDouble(iGioiHanTC1TuDongKhongQuaDem3) < Convert.ToDouble(iGioiHanTC2TuDongKhongQuaDem3))
                                            {
                                                this.DGVTinhCong.Rows[addTuDong].Cells["TC2"].Value = Math.Round((dTongThoiGianTangCaTuDongKhongQuaDem3 - Convert.ToDouble(iGioiHanTC1TuDongKhongQuaDem3)) * this.dTangCa2HeSo / 60.0, this.iLamTronGio);
                                                this.DGVTinhCong.Rows[addTuDong].Cells["TC3"].Value = "0";
                                                this.DGVTinhCong.Rows[addTuDong].Cells["TC4"].Value = "0";
                                            }
                                            else
                                            {
                                                this.DGVTinhCong.Rows[addTuDong].Cells["TC1"].Value = Math.Round(Convert.ToDouble(iGioiHanTC1TuDongKhongQuaDem3) * this.dTangCa1HeSo / 60.0, this.iLamTronGio);
                                                this.DGVTinhCong.Rows[addTuDong].Cells["TC2"].Value = Math.Round(Convert.ToDouble(iGioiHanTC2TuDongKhongQuaDem3) * this.dTangCa2HeSo / 60.0, this.iLamTronGio);
                                                this.DGVTinhCong.Rows[addTuDong].Cells["TC3"].Value = Math.Round((dTongThoiGianTangCaTuDongKhongQuaDem3 - Convert.ToDouble(iGioiHanTC1TuDongKhongQuaDem3) - Convert.ToDouble(iGioiHanTC2TuDongKhongQuaDem3)) * this.dTangCa3HeSo / 60.0, this.iLamTronGio);
                                                this.DGVTinhCong.Rows[addTuDong].Cells["TC4"].Value = "0";
                                            }
                                        }
                                    }
                                    if (iGioiHanTC1TuDongKhongQuaDem3 != 0 && iGioiHanTC2TuDongKhongQuaDem3 != 0 && iGioiHanTC3TuDongKhongQuaDem3 != 0 && iGioiHanTC4TuDongKhongQuaDem3 != 0)
                                    {
                                    }
                                }
                                else
                                {
                                    this.DGVTinhCong.Rows[addTuDong].Cells["TC1"].Value = "0";
                                    this.DGVTinhCong.Rows[addTuDong].Cells["TC2"].Value = "0";
                                    this.DGVTinhCong.Rows[addTuDong].Cells["TC3"].Value = "0";
                                    this.DGVTinhCong.Rows[addTuDong].Cells["TC4"].Value = "0";
                                }
                            }
                            if (DateTimeProgress.XuatIDThu((int)dt.AddDays(dem).DayOfWeek) == "0")
                            {
                                this.DGVTinhCong.Rows[addTuDong].Cells["IDThu"].Value = "CN";
                            }
                            else
                            {
                                this.DGVTinhCong.Rows[addTuDong].Cells["IDThu"].Value = "NT";
                            }
                            this.DGVTinhCong.Rows[addTuDong].Cells["MaChamCong"].Value = this.sMaChamCong;
                            this.DGVTinhCong.Rows[addTuDong].Cells["PhongBan"].Value = this.sPhongBanTinhCong;
                            break;
                        }
                    }
                    if (iKiemTraDuLieuTuDong == 0)
                    {
                        this.DGVTinhCong.Rows[_nhanVien].Cells["Cong"].Value = "0";
                        this.DGVTinhCong.Rows[_nhanVien].Cells["Gio"].Value = "0";
                        this.DGVTinhCong.Rows[_nhanVien].Cells["TongGio"].Value = "0";
                        this.DGVTinhCong.Rows[_nhanVien].Cells["DemCong"].Value = "0";
                        this.DGVTinhCong.Rows[_nhanVien].Cells["KyHieu"].Value = this.sKHVang;
                        if (DateTimeProgress.XuatIDThu((int)dt.AddDays(dem).DayOfWeek) == "0")
                        {
                            this.DGVTinhCong.Rows[_nhanVien].Cells["IDThu"].Value = "CN";
                        }
                        else
                        {
                            this.DGVTinhCong.Rows[_nhanVien].Cells["IDThu"].Value = "NT";
                        }
                        this.DGVTinhCong.Rows[_nhanVien].Cells["MaChamCong"].Value = this.sMaChamCong;
                        this.DGVTinhCong.Rows[_nhanVien].Cells["PhongBan"].Value = this.sPhongBanTinhCong;
                    }
                    if (iKiemTraSapXepCa == 0)
                    {
                        new DataTable();
                        DataTable dtKiemTraChamCong;
                        dtKiemTraChamCong = this._checkInOutBLL.getCheckInOutByMaChamCongAndNgayCham(Convert.ToInt32(this.sMaChamCong), Convert.ToDateTime(this.DGVTinhCong.Rows[_nhanVien].Cells["Ngay"].Value.ToString()));
                        int iKiemTraNghi;
                        iKiemTraNghi = 0;
                        new DataTable();
                        DataTable dtNgayLe;
                        dtNgayLe = this._ngayLeBLL.NgayLeGetTinhCong(Convert.ToDateTime(this.DGVTinhCong.Rows[_nhanVien].Cells["Ngay"].Value.ToString()));
                        for (int iNgayLe = 0; iNgayLe < dtNgayLe.Rows.Count; iNgayLe++)
                        {
                            if (dtKiemTraChamCong.Rows.Count == 0)
                            {
                                double fCongTinh;
                                fCongTinh = Convert.ToDouble(dtNgayLe.Rows[iNgayLe]["CongTinh"].ToString());
                                double fGio;
                                fGio = Convert.ToDouble(dtNgayLe.Rows[iNgayLe]["Gio"].ToString());
                                if (dtNgayLe.Rows[iNgayLe]["XacNhan"].ToString() == "True")
                                {
                                    this.DGVTinhCong.Rows[_nhanVien].Cells["MaNhanVien"].Value = this.sMaNhanVien;
                                    this.DGVTinhCong.Rows[_nhanVien].Cells["TenNhanVien"].Value = this.sTenNhanVien;
                                    this.DGVTinhCong.Rows[_nhanVien].Cells["Ngay"].Value = $"{Convert.ToDateTime(dt.AddDays(dem).ToString()):d}";
                                    this.DGVTinhCong.Rows[_nhanVien].Cells["Thu"].Value = DateTimeProgress.XuatThuTinhCong((int)dt.AddDays(dem).DayOfWeek);
                                    this.DGVTinhCong.Rows[_nhanVien].Cells["Cong"].Value = fCongTinh;
                                    this.DGVTinhCong.Rows[_nhanVien].Cells["Gio"].Value = fGio;
                                    this.DGVTinhCong.Rows[_nhanVien].Cells["DemCong"].Value = "";
                                    this.DGVTinhCong.Rows[_nhanVien].Cells["KyHieu"].Value = this.sKHLe;
                                    this.DGVTinhCong.Rows[_nhanVien].Cells["MaChamCong"].Value = this.sMaChamCong;
                                    iKiemTraNghi++;
                                }
                                continue;
                            }
                            double fCongTinh2;
                            fCongTinh2 = Convert.ToDouble(dtNgayLe.Rows[iNgayLe]["CongTinh"].ToString());
                            double fGio2;
                            fGio2 = Convert.ToDouble(dtNgayLe.Rows[iNgayLe]["Gio"].ToString());
                            if (dtNgayLe.Rows[iNgayLe]["XacNhan"].ToString() == "True")
                            {
                                int addNgayLe;
                                addNgayLe = this.DGVTinhCong.Rows.Add();
                                this.DGVTinhCong.Rows[addNgayLe].Cells["MaNhanVien"].Value = this.sMaNhanVien;
                                this.DGVTinhCong.Rows[addNgayLe].Cells["TenNhanVien"].Value = this.sTenNhanVien;
                                this.DGVTinhCong.Rows[addNgayLe].Cells["Ngay"].Value = $"{Convert.ToDateTime(dt.AddDays(dem).ToString()):d}";
                                this.DGVTinhCong.Rows[addNgayLe].Cells["Thu"].Value = DateTimeProgress.XuatThuTinhCong((int)dt.AddDays(dem).DayOfWeek);
                                this.DGVTinhCong.Rows[addNgayLe].Cells["Cong"].Value = fCongTinh2;
                                this.DGVTinhCong.Rows[addNgayLe].Cells["Gio"].Value = fGio2;
                                this.DGVTinhCong.Rows[addNgayLe].Cells["DemCong"].Value = "";
                                this.DGVTinhCong.Rows[addNgayLe].Cells["KyHieu"].Value = this.sKHLe;
                                this.DGVTinhCong.Rows[addNgayLe].Cells["MaChamCong"].Value = this.sMaChamCong;
                                iKiemTraNghi++;
                            }
                        }
                        new DataTable();
                        DataTable dtCongTac;
                        dtCongTac = this._chiTietDiCongTacBLL.ChiTietDiCongTacGetTinhCong(Convert.ToInt32(this.sMaChamCong), Convert.ToDateTime(this.DGVTinhCong.Rows[_nhanVien].Cells["Ngay"].Value.ToString()));
                        for (int iCongTac = 0; iCongTac < dtCongTac.Rows.Count; iCongTac++)
                        {
                            if (dtKiemTraChamCong.Rows.Count == 0 && iKiemTraNghi == 0)
                            {
                                this.DGVTinhCong.Rows[_nhanVien].Cells["MaNhanVien"].Value = this.sMaNhanVien;
                                this.DGVTinhCong.Rows[_nhanVien].Cells["TenNhanVien"].Value = this.sTenNhanVien;
                                this.DGVTinhCong.Rows[_nhanVien].Cells["Ngay"].Value = $"{Convert.ToDateTime(dt.AddDays(dem).ToString()):d}";
                                this.DGVTinhCong.Rows[_nhanVien].Cells["Thu"].Value = DateTimeProgress.XuatThuTinhCong((int)dt.AddDays(dem).DayOfWeek);
                                this.DGVTinhCong.Rows[_nhanVien].Cells["Vao"].Value = string.Format("{0:HH:mm}", Convert.ToDateTime(dtCongTac.Rows[iCongTac]["GioDi"].ToString()));
                                this.DGVTinhCong.Rows[_nhanVien].Cells["Ra"].Value = string.Format("{0:HH:mm}", Convert.ToDateTime(dtCongTac.Rows[iCongTac]["GioVe"].ToString()));
                                this.DGVTinhCong.Rows[_nhanVien].Cells["Cong"].Value = Math.Round(Convert.ToDouble(dtCongTac.Rows[iCongTac]["CongTinhCongTac"].ToString()), this.iLamTronCong);
                                this.DGVTinhCong.Rows[_nhanVien].Cells["Gio"].Value = Math.Round(Convert.ToDouble(dtCongTac.Rows[iCongTac]["TongGioCongTac"].ToString()), this.iLamTronGio);
                                this.DGVTinhCong.Rows[_nhanVien].Cells["DemCong"].Value = "";
                                this.DGVTinhCong.Rows[_nhanVien].Cells["KyHieu"].Value = this.sKHCongTac;
                                this.DGVTinhCong.Rows[_nhanVien].Cells["MaChamCong"].Value = this.sMaChamCong;
                                iKiemTraNghi++;
                            }
                            else
                            {
                                int addCongTac;
                                addCongTac = this.DGVTinhCong.Rows.Add();
                                this.DGVTinhCong.Rows[addCongTac].Cells["MaNhanVien"].Value = this.sMaNhanVien;
                                this.DGVTinhCong.Rows[addCongTac].Cells["TenNhanVien"].Value = this.sTenNhanVien;
                                this.DGVTinhCong.Rows[addCongTac].Cells["Ngay"].Value = $"{Convert.ToDateTime(dt.AddDays(dem).ToString()):d}";
                                this.DGVTinhCong.Rows[addCongTac].Cells["Thu"].Value = DateTimeProgress.XuatThuTinhCong((int)dt.AddDays(dem).DayOfWeek);
                                this.DGVTinhCong.Rows[addCongTac].Cells["Vao"].Value = string.Format("{0:HH:mm}", Convert.ToDateTime(dtCongTac.Rows[iCongTac]["GioDi"].ToString()));
                                this.DGVTinhCong.Rows[addCongTac].Cells["Ra"].Value = string.Format("{0:HH:mm}", Convert.ToDateTime(dtCongTac.Rows[iCongTac]["GioVe"].ToString()));
                                this.DGVTinhCong.Rows[addCongTac].Cells["Cong"].Value = Math.Round(Convert.ToDouble(dtCongTac.Rows[iCongTac]["CongTinhCongTac"].ToString()), this.iLamTronCong);
                                this.DGVTinhCong.Rows[addCongTac].Cells["Gio"].Value = Math.Round(Convert.ToDouble(dtCongTac.Rows[iCongTac]["TongGioCongTac"].ToString()), this.iLamTronGio);
                                this.DGVTinhCong.Rows[addCongTac].Cells["DemCong"].Value = "";
                                this.DGVTinhCong.Rows[addCongTac].Cells["KyHieu"].Value = this.sKHCongTac;
                                this.DGVTinhCong.Rows[addCongTac].Cells["MaChamCong"].Value = this.sMaChamCong;
                                iKiemTraNghi++;
                            }
                        }
                        new DataTable();
                        DataTable dtPhepNam;
                        dtPhepNam = this._phepNamBLL.PhepNamGetTinhCong(Convert.ToInt32(this.sMaChamCong), Convert.ToDateTime(this.DGVTinhCong.Rows[_nhanVien].Cells["Ngay"].Value.ToString()));
                        for (int iPhepNam = 0; iPhepNam < dtPhepNam.Rows.Count; iPhepNam++)
                        {
                            if (dtKiemTraChamCong.Rows.Count == 0 && iKiemTraNghi == 0)
                            {
                                this.DGVTinhCong.Rows[_nhanVien].Cells["MaNhanVien"].Value = this.sMaNhanVien;
                                this.DGVTinhCong.Rows[_nhanVien].Cells["TenNhanVien"].Value = this.sTenNhanVien;
                                this.DGVTinhCong.Rows[_nhanVien].Cells["Ngay"].Value = $"{Convert.ToDateTime(dt.AddDays(dem).ToString()):d}";
                                this.DGVTinhCong.Rows[_nhanVien].Cells["Thu"].Value = DateTimeProgress.XuatThuTinhCong((int)dt.AddDays(dem).DayOfWeek);
                                this.DGVTinhCong.Rows[_nhanVien].Cells["Cong"].Value = dtPhepNam.Rows[iPhepNam]["DemCong"].ToString();
                                this.DGVTinhCong.Rows[_nhanVien].Cells["Gio"].Value = dtPhepNam.Rows[iPhepNam]["DemGio"].ToString();
                                this.DGVTinhCong.Rows[_nhanVien].Cells["DemCong"].Value = "";
                                this.DGVTinhCong.Rows[_nhanVien].Cells["KyHieu"].Value = this.sKHPhepNam;
                                this.DGVTinhCong.Rows[_nhanVien].Cells["MaChamCong"].Value = this.sMaChamCong;
                                iKiemTraNghi++;
                            }
                            else
                            {
                                int addPhepNam;
                                addPhepNam = this.DGVTinhCong.Rows.Add();
                                this.DGVTinhCong.Rows[addPhepNam].Cells["MaNhanVien"].Value = this.sMaNhanVien;
                                this.DGVTinhCong.Rows[addPhepNam].Cells["TenNhanVien"].Value = this.sTenNhanVien;
                                this.DGVTinhCong.Rows[addPhepNam].Cells["Ngay"].Value = $"{Convert.ToDateTime(dt.AddDays(dem).ToString()):d}";
                                this.DGVTinhCong.Rows[addPhepNam].Cells["Thu"].Value = DateTimeProgress.XuatThuTinhCong((int)dt.AddDays(dem).DayOfWeek);
                                this.DGVTinhCong.Rows[addPhepNam].Cells["Cong"].Value = dtPhepNam.Rows[iPhepNam]["DemCong"].ToString();
                                this.DGVTinhCong.Rows[addPhepNam].Cells["Gio"].Value = dtPhepNam.Rows[iPhepNam]["DemGio"].ToString();
                                this.DGVTinhCong.Rows[addPhepNam].Cells["DemCong"].Value = "";
                                this.DGVTinhCong.Rows[addPhepNam].Cells["KyHieu"].Value = this.sKHPhepNam;
                                this.DGVTinhCong.Rows[addPhepNam].Cells["MaChamCong"].Value = this.sMaChamCong;
                                iKiemTraNghi++;
                            }
                        }
                        new DataTable();
                        this._khaiBaoVangChoNhanVienDTO.MaChamCong = Convert.ToInt32(this.sMaChamCong);
                        DateTime NgayThang = Convert.ToDateTime(this.DGVTinhCong.Rows[_nhanVien].Cells["Ngay"].Value.ToString());
                        DataTable dtNhanVienVang;
                        dtNhanVienVang = this._khaiBaoVangChoNhanVienBLL.CacLoaiVangGetTinhCong(Convert.ToInt32(this.sMaChamCong), NgayThang);
                        for (int iLoaiVangNhanVien = 0; iLoaiVangNhanVien < dtNhanVienVang.Rows.Count; iLoaiVangNhanVien++)
                        {
                            if (dtKiemTraChamCong.Rows.Count == 0 && iKiemTraNghi == 0)
                            {
                                this.DGVTinhCong.Rows[_nhanVien].Cells["MaNhanVien"].Value = this.sMaNhanVien;
                                this.DGVTinhCong.Rows[_nhanVien].Cells["TenNhanVien"].Value = this.sTenNhanVien;
                                this.DGVTinhCong.Rows[_nhanVien].Cells["Ngay"].Value = $"{Convert.ToDateTime(dt.AddDays(dem).ToString()):d}";
                                this.DGVTinhCong.Rows[_nhanVien].Cells["Thu"].Value = DateTimeProgress.XuatThuTinhCong((int)dt.AddDays(dem).DayOfWeek);
                                if (dtNhanVienVang.Rows[iLoaiVangNhanVien]["DuocHuongLuong"].ToString() == "True")
                                {
                                    this.DGVTinhCong.Rows[_nhanVien].Cells["Cong"].Value = dtNhanVienVang.Rows[iLoaiVangNhanVien]["NgayCong"].ToString();
                                    this.DGVTinhCong.Rows[_nhanVien].Cells["Gio"].Value = dtNhanVienVang.Rows[iLoaiVangNhanVien]["TongPhut"].ToString();
                                }
                                else
                                {
                                    this.DGVTinhCong.Rows[_nhanVien].Cells["Cong"].Value = "0";
                                    this.DGVTinhCong.Rows[_nhanVien].Cells["Gio"].Value = 0;
                                }
                                string sMaCacLoaiVang;
                                sMaCacLoaiVang = dtNhanVienVang.Rows[iLoaiVangNhanVien]["MaCacLoaiVang"].ToString();
                                new DataTable();
                                DataTable dtCacLoaiVang;
                                dtCacLoaiVang = this._cacLoaiVangBLL.CacLoaiVangGetByMaCacLoaiVang(sMaCacLoaiVang);
                                for (int iCacLoaiVang = 0; iCacLoaiVang < dtCacLoaiVang.Rows.Count; iCacLoaiVang++)
                                {
                                    this.DGVTinhCong.Rows[_nhanVien].Cells["KyHieu"].Value = dtCacLoaiVang.Rows[iCacLoaiVang]["KyHieu"].ToString();
                                }
                                this.DGVTinhCong.Rows[_nhanVien].Cells["MaChamCong"].Value = this.sMaChamCong;
                                iKiemTraNghi++;
                                continue;
                            }
                            int addCacLoaiVang;
                            addCacLoaiVang = this.DGVTinhCong.Rows.Add();
                            this.DGVTinhCong.Rows[addCacLoaiVang].Cells["MaNhanVien"].Value = this.sMaNhanVien;
                            this.DGVTinhCong.Rows[addCacLoaiVang].Cells["TenNhanVien"].Value = this.sTenNhanVien;
                            this.DGVTinhCong.Rows[addCacLoaiVang].Cells["Ngay"].Value = $"{Convert.ToDateTime(dt.AddDays(dem).ToString()):d}";
                            this.DGVTinhCong.Rows[addCacLoaiVang].Cells["Thu"].Value = DateTimeProgress.XuatThuTinhCong((int)dt.AddDays(dem).DayOfWeek);
                            if (dtNhanVienVang.Rows[iLoaiVangNhanVien]["DuocHuongLuong"].ToString() == "True")
                            {
                                this.DGVTinhCong.Rows[addCacLoaiVang].Cells["Cong"].Value = dtNhanVienVang.Rows[iLoaiVangNhanVien]["NgayCong"].ToString();
                                this.DGVTinhCong.Rows[addCacLoaiVang].Cells["Gio"].Value = dtNhanVienVang.Rows[iLoaiVangNhanVien]["TongPhut"].ToString();
                            }
                            else
                            {
                                this.DGVTinhCong.Rows[addCacLoaiVang].Cells["Cong"].Value = "0";
                                this.DGVTinhCong.Rows[addCacLoaiVang].Cells["Gio"].Value = 0;
                            }
                            string sMaCacLoaiVang2;
                            sMaCacLoaiVang2 = dtNhanVienVang.Rows[iLoaiVangNhanVien]["MaCacLoaiVang"].ToString();
                            new DataTable();
                            DataTable dtCacLoaiVang2;
                            dtCacLoaiVang2 = this._cacLoaiVangBLL.CacLoaiVangGetByMaCacLoaiVang(sMaCacLoaiVang2);
                            for (int iCacLoaiVang2 = 0; iCacLoaiVang2 < dtCacLoaiVang2.Rows.Count; iCacLoaiVang2++)
                            {
                                this.DGVTinhCong.Rows[addCacLoaiVang].Cells["KyHieu"].Value = dtCacLoaiVang2.Rows[iCacLoaiVang2]["KyHieu"].ToString();
                            }
                            this.DGVTinhCong.Rows[addCacLoaiVang].Cells["MaChamCong"].Value = this.sMaChamCong;
                            iKiemTraNghi++;
                        }
                    }
                    this.DGVTinhCong.Rows[_nhanVien].Cells["Thu"].Value = DateTimeProgress.XuatThuTinhCong((int)dt.AddDays(dem).DayOfWeek);
                    if (this.sGioVao != null)
                    {
                        _ = this.sGioRa;
                    }
                    dem++;
                    if (this.checkBoxCoTinhLuong.Checked)
                    {
                        new DataTable();
                        this._chiTietPhuCapNhanVienDTO.MaChamCong = Convert.ToInt32(this.sMaChamCong);
                        this._chiTietPhuCapNhanVienDTO.Ngay = Convert.ToDateTime(this.DGVTinhCong.Rows[_nhanVien].Cells["Ngay"].Value.ToString());
                        this._chiTietPhuCapNhanVienDTO.KyHieuPhuCap = "PCTC";
                        DataTable dtChiTietPhuCapTienCom;
                        dtChiTietPhuCapTienCom = this._chiTietPhuCapNhanVienBLL.ChiTietPhuCapNhanVienGetByMaChamCongAndNgayAndKyHieuPhuCap(this._chiTietPhuCapNhanVienDTO);
                        for (int iChiTietPhuCapTienCom = 0; iChiTietPhuCapTienCom < dtChiTietPhuCapTienCom.Rows.Count; iChiTietPhuCapTienCom++)
                        {
                            this.dTongTienPhuCapTienCom += Convert.ToDouble(dtChiTietPhuCapTienCom.Rows[iChiTietPhuCapTienCom]["SoTien"].ToString());
                        }
                        new DataTable();
                        this._chiTietPhuCapNhanVienDTO.MaChamCong = Convert.ToInt32(this.sMaChamCong);
                        this._chiTietPhuCapNhanVienDTO.Ngay = Convert.ToDateTime(this.DGVTinhCong.Rows[_nhanVien].Cells["Ngay"].Value.ToString());
                        this._chiTietPhuCapNhanVienDTO.KyHieuPhuCap = "PCK";
                        DataTable dtChiTietPhuCapKhac;
                        dtChiTietPhuCapKhac = this._chiTietPhuCapNhanVienBLL.ChiTietPhuCapNhanVienGetByMaChamCongAndNgayAndKyHieuPhuCap(this._chiTietPhuCapNhanVienDTO);
                        for (int iChiTietPhuCapKhac = 0; iChiTietPhuCapKhac < dtChiTietPhuCapKhac.Rows.Count; iChiTietPhuCapKhac++)
                        {
                            this.dTongTienPhuCapKhac += Convert.ToDouble(dtChiTietPhuCapKhac.Rows[iChiTietPhuCapKhac]["SoTien"].ToString());
                        }
                        new DataTable();
                        this._chiTietTamUngLuongDTO.MaChamCong = Convert.ToInt32(this.sMaChamCong);
                        this._chiTietTamUngLuongDTO.NgayTamUng = Convert.ToDateTime(this.DGVTinhCong.Rows[_nhanVien].Cells["Ngay"].Value.ToString());
                        DataTable dtChiTietTamUngLuong;
                        dtChiTietTamUngLuong = this._chiTietTamUngLuongBLL.ChiTietTamUngLuongGetMaChamCongAndNgayTamUng(this._chiTietTamUngLuongDTO);
                        for (int iChiTietTamUngLuong = 0; iChiTietTamUngLuong < dtChiTietTamUngLuong.Rows.Count; iChiTietTamUngLuong++)
                        {
                            this.dTongTienTamUng += Convert.ToDouble(dtChiTietTamUngLuong.Rows[iChiTietTamUngLuong]["SoTien"].ToString());
                        }
                        new DataTable();
                        this._viPhamDTO.MaChamCong = Convert.ToInt32(this.sMaChamCong);
                        this._viPhamDTO.NgayThang = Convert.ToDateTime(this.DGVTinhCong.Rows[_nhanVien].Cells["Ngay"].Value.ToString());
                        DataTable dtChiTietViPham;
                        dtChiTietViPham = this._viPhamBLL.ViPhamGetMaChamCongAndNgayThang(this._viPhamDTO);
                        for (int iChiTietViPham = 0; iChiTietViPham < dtChiTietViPham.Rows.Count; iChiTietViPham++)
                        {
                            this.dTongTienViPham += Convert.ToDouble(dtChiTietViPham.Rows[iChiTietViPham]["TienPhat"].ToString());
                        }
                        new DataTable();
                        this._thuongDTO.MaChamCong = Convert.ToInt32(this.sMaChamCong);
                        this._thuongDTO.NgayThuong = Convert.ToDateTime(this.DGVTinhCong.Rows[_nhanVien].Cells["Ngay"].Value.ToString());
                        DataTable dtChiTietThuong;
                        dtChiTietThuong = this._thuongBLL.ThuongGetByMaChamCongAndNgayThuong(this._thuongDTO);
                        for (int iChiTietThuong = 0; iChiTietThuong < dtChiTietThuong.Rows.Count; iChiTietThuong++)
                        {
                            this.dTongTienThuong += Convert.ToDouble(dtChiTietThuong.Rows[iChiTietThuong]["TienThuong"].ToString());
                        }
                    }
                }
                demNhanVienDuocChon++;
                if (this.checkBoxCoTinhLuong.Checked)
                {
                    this._chiTietCongTruLuongDTO.MaChamCong = Convert.ToInt32(this.sMaChamCong);
                    this._chiTietCongTruLuongDTO.ChiTietPhuCapCom = this.dTongTienPhuCapTienCom.ToString();
                    this._chiTietCongTruLuongDTO.ChiTietPhuCapKhac = this.dTongTienPhuCapKhac.ToString();
                    this._chiTietCongTruLuongDTO.ChiTietTamUngLuong = this.dTongTienTamUng.ToString();
                    this._chiTietCongTruLuongDTO.ChiTietViPham = this.dTongTienViPham.ToString();
                    this._chiTietCongTruLuongDTO.ChiTietThuong = this.dTongTienThuong.ToString();
                    this._chiTietCongTruLuongBLL.ChiTietCongTruLuongInsert(this._chiTietCongTruLuongDTO);
                }
                _loadTinhCong.progressBarX1.Maximum = TestDemNhanVien;
                testProcess--;
                demProcess++;
                _loadTinhCong.progressBarX1.Text = (demProcess + 1) * 100 / TestDemNhanVien + "%";
                _loadTinhCong.lbDangTinh.Text = "Đang tính công";
                System.Windows.Forms.Application.DoEvents();
                if (TestDemNhanVien >= 0)
                {
                    _loadTinhCong.progressBarX1.Value = TestDemNhanVien - testProcess;
                }
            }
            if (demNhanVienDuocChon == 0)
            {
                _loadTinhCong.Close();
                MessageBox.Show("Bạn chưa chọn nhân viên để tính công");
                return;
            }
            this.lbNhanVienDuocChon.Text = "Tổng số nhân viên chọn tính công: " + demNhanVienDuocChon;
            this.lbTongSoDongTinhCong.Text = "Tổng số dòng tính công: " + this.DGVTinhCong.Rows.Count;
            this.lbTongSoNgayTinhCong.Text = "Tổng số ngày tính công: " + (Convert.ToInt32(this.sTongNgayTinh) + 1);
            this.Cursor = Cursors.Default;
            for (int iLuuTinhCong = 0; iLuuTinhCong < this.DGVTinhCong.Rows.Count; iLuuTinhCong++)
            {
                _loadTinhCong.lbDangTinh.Text = "Đang lưu tính công";
                Application.DoEvents();
                this._tinhCongDTO.MaNhanVien = this.DGVTinhCong.Rows[iLuuTinhCong].Cells["MaNhanVien"].Value.ToString();
                this._tinhCongDTO.TenNhanVien = this.DGVTinhCong.Rows[iLuuTinhCong].Cells["TenNhanVien"].Value.ToString();
                this._tinhCongDTO.Ngay = DateTime.Parse(this.DGVTinhCong.Rows[iLuuTinhCong].Cells["Ngay"].Value.ToString());
                this._tinhCongDTO.Thu = this.DGVTinhCong.Rows[iLuuTinhCong].Cells["Thu"].Value.ToString();
                if (this.DGVTinhCong.Rows[iLuuTinhCong].Cells["Ca"].Value == null)
                {
                    this._tinhCongDTO.Ca = "***";
                }
                else
                {
                    this._tinhCongDTO.Ca = this.DGVTinhCong.Rows[iLuuTinhCong].Cells["Ca"].Value.ToString();
                }
                if (this.DGVTinhCong.Rows[iLuuTinhCong].Cells["Vao"].Value == null)
                {
                    this._tinhCongDTO.GioVao = "";
                }
                else
                {
                    this._tinhCongDTO.GioVao = this.DGVTinhCong.Rows[iLuuTinhCong].Cells["Vao"].Value.ToString();
                }
                if (this.DGVTinhCong.Rows[iLuuTinhCong].Cells["Ra"].Value == null)
                {
                    this._tinhCongDTO.GioRa = "";
                }
                else
                {
                    this._tinhCongDTO.GioRa = this.DGVTinhCong.Rows[iLuuTinhCong].Cells["Ra"].Value.ToString();
                }
                if (this.DGVTinhCong.Rows[iLuuTinhCong].Cells["Cong"].Value == null)
                {
                    this._tinhCongDTO.Cong = "";
                }
                else
                {
                    this._tinhCongDTO.Cong = this.DGVTinhCong.Rows[iLuuTinhCong].Cells["Cong"].Value.ToString();
                }
                if (this.DGVTinhCong.Rows[iLuuTinhCong].Cells["Gio"].Value == null)
                {
                    this._tinhCongDTO.Gio = "";
                }
                else
                {
                    this._tinhCongDTO.Gio = this.DGVTinhCong.Rows[iLuuTinhCong].Cells["Gio"].Value.ToString();
                }
                if (this.DGVTinhCong.Rows[iLuuTinhCong].Cells["Tre"].Value == null)
                {
                    this._tinhCongDTO.Tre = 0;
                }
                else
                {
                    this._tinhCongDTO.Tre = Convert.ToInt32(this.DGVTinhCong.Rows[iLuuTinhCong].Cells["Tre"].Value.ToString());
                }
                if (this.DGVTinhCong.Rows[iLuuTinhCong].Cells["VeSom"].Value == null)
                {
                    this._tinhCongDTO.VeSom = 0;
                }
                else
                {
                    this._tinhCongDTO.VeSom = Convert.ToInt32(this.DGVTinhCong.Rows[iLuuTinhCong].Cells["VeSom"].Value.ToString());
                }
                if (this.DGVTinhCong.Rows[iLuuTinhCong].Cells["VeTre"].Value == null)
                {
                    this._tinhCongDTO.VeTre = 0;
                }
                else
                {
                    this._tinhCongDTO.VeTre = Convert.ToInt32(this.DGVTinhCong.Rows[iLuuTinhCong].Cells["VeTre"].Value.ToString());
                }
                if (this.DGVTinhCong.Rows[iLuuTinhCong].Cells["TC1"].Value == null)
                {
                    this._tinhCongDTO.TC1 = "0";
                }
                else
                {
                    this._tinhCongDTO.TC1 = this.DGVTinhCong.Rows[iLuuTinhCong].Cells["TC1"].Value.ToString();
                }
                if (this.DGVTinhCong.Rows[iLuuTinhCong].Cells["TC2"].Value == null)
                {
                    this._tinhCongDTO.TC2 = "0";
                }
                else
                {
                    this._tinhCongDTO.TC2 = this.DGVTinhCong.Rows[iLuuTinhCong].Cells["TC2"].Value.ToString();
                }
                if (this.DGVTinhCong.Rows[iLuuTinhCong].Cells["TC3"].Value == null)
                {
                    this._tinhCongDTO.TC3 = "0";
                }
                else
                {
                    this._tinhCongDTO.TC3 = this.DGVTinhCong.Rows[iLuuTinhCong].Cells["TC3"].Value.ToString();
                }
                if (this.DGVTinhCong.Rows[iLuuTinhCong].Cells["TC4"].Value == null)
                {
                    this._tinhCongDTO.TC4 = "0";
                }
                else
                {
                    this._tinhCongDTO.TC4 = this.DGVTinhCong.Rows[iLuuTinhCong].Cells["TC4"].Value.ToString();
                }
                if (this.DGVTinhCong.Rows[iLuuTinhCong].Cells["TongGio"].Value == null)
                {
                    this._tinhCongDTO.TongGio = "0";
                }
                else
                {
                    this._tinhCongDTO.TongGio = this.DGVTinhCong.Rows[iLuuTinhCong].Cells["TongGio"].Value.ToString();
                }
                if (this.DGVTinhCong.Rows[iLuuTinhCong].Cells["DemCong"].Value == null)
                {
                    this._tinhCongDTO.DemCong = "0";
                }
                else
                {
                    this._tinhCongDTO.DemCong = this.DGVTinhCong.Rows[iLuuTinhCong].Cells["DemCong"].Value.ToString();
                }
                if (this.DGVTinhCong.Rows[iLuuTinhCong].Cells["KyHieu"].Value == null)
                {
                    this._tinhCongDTO.KyHieu = "";
                }
                else
                {
                    this._tinhCongDTO.KyHieu = this.DGVTinhCong.Rows[iLuuTinhCong].Cells["KyHieu"].Value.ToString();
                }
                if (this.DGVTinhCong.Rows[iLuuTinhCong].Cells["MaChamCong"].Value == null)
                {
                    this._tinhCongDTO.MaChamCong = 0;
                }
                else
                {
                    this._tinhCongDTO.MaChamCong = Convert.ToInt32(this.DGVTinhCong.Rows[iLuuTinhCong].Cells["MaChamCong"].Value.ToString());
                }
                if (this.DGVTinhCong.Rows[iLuuTinhCong].Cells["IDThu"].Value == null)
                {
                    this._tinhCongDTO.KyHieuPhu = "";
                }
                else
                {
                    this._tinhCongDTO.KyHieuPhu = this.DGVTinhCong.Rows[iLuuTinhCong].Cells["IDThu"].Value.ToString();
                }
                if (this.DGVTinhCong.Rows[iLuuTinhCong].Cells["PhongBan"].Value == null)
                {
                    this._tinhCongDTO.PhongBan = "";
                }
                else
                {
                    this._tinhCongDTO.PhongBan = this.DGVTinhCong.Rows[iLuuTinhCong].Cells["PhongBan"].Value.ToString();
                }
                this._tinhCongBLL.TinhCongInsert(this._tinhCongDTO);
            }
            if (this.checkBoxCoTinhLuong.Checked)
            {
                _loadTinhCong.lbDangTinh.Text = "Đang tính lương";
                System.Windows.Forms.Application.DoEvents();
                int iMaChamCongTinhCongTinhLuong;
                iMaChamCongTinhCongTinhLuong = 0;
                new DataTable();
                this._tinhCongDTO.Ngay = Convert.ToDateTime(this.dateTimeTuNgay.Text);
                DataTable dtTinhCongTinhLuong;
                dtTinhCongTinhLuong = this._tinhCongBLL.TinhCongGetNgay(this._tinhCongDTO);
                for (int iTinhCongTinhLuong = 0; iTinhCongTinhLuong < dtTinhCongTinhLuong.Rows.Count; iTinhCongTinhLuong++)
                {
                    string sDangKyThamGiaBaoHiem;
                    sDangKyThamGiaBaoHiem = "";
                    int iMaChamCongTinhCongTinhLuongKiemTra;
                    iMaChamCongTinhCongTinhLuongKiemTra = Convert.ToInt32(dtTinhCongTinhLuong.Rows[iTinhCongTinhLuong]["MaChamCong"].ToString());
                    if (iMaChamCongTinhCongTinhLuong != iMaChamCongTinhCongTinhLuongKiemTra)
                    {
                        iMaChamCongTinhCongTinhLuong = Convert.ToInt32(dtTinhCongTinhLuong.Rows[iTinhCongTinhLuong]["MaChamCong"].ToString());
                        int addLuongNhanVien;
                        addLuongNhanVien = this.DGVChiTietLuong.Rows.Add();
                        this.DGVChiTietLuong.Rows[addLuongNhanVien].Cells[0].Value = dtTinhCongTinhLuong.Rows[iTinhCongTinhLuong]["MaNhanVien"].ToString();
                        this.DGVChiTietLuong.Rows[addLuongNhanVien].Cells[1].Value = dtTinhCongTinhLuong.Rows[iTinhCongTinhLuong]["TenNhanVien"].ToString();
                        this.DGVChiTietLuong.Rows[addLuongNhanVien].Cells[2].Value = iMaChamCongTinhCongTinhLuong;
                        double dTienLuongHopDongNhanVien;
                        dTienLuongHopDongNhanVien = 0.0;
                        new DataTable();
                        DataTable dtNhanVienGetTinhLuong;
                        dtNhanVienGetTinhLuong = this._nhanVienBLL.NhanVienGetByMaChamCong(iMaChamCongTinhCongTinhLuong.ToString());
                        for (int iNhanVienGetTinhLuong = 0; iNhanVienGetTinhLuong < dtNhanVienGetTinhLuong.Rows.Count; iNhanVienGetTinhLuong++)
                        {
                            double dTienLuongNhanVien;
                            dTienLuongNhanVien = Convert.ToDouble(dtNhanVienGetTinhLuong.Rows[iNhanVienGetTinhLuong]["TienLuong"].ToString());
                            this.DGVChiTietLuong.Rows[addLuongNhanVien].Cells[3].Value = this._convertMoney.chendau(Convert.ToInt32(dTienLuongNhanVien).ToString());
                            dTienLuongHopDongNhanVien = Convert.ToDouble(dtNhanVienGetTinhLuong.Rows[iNhanVienGetTinhLuong]["LuongHopDong"].ToString());
                            this.DGVChiTietLuong.Rows[addLuongNhanVien].Cells[4].Value = this._convertMoney.chendau(Convert.ToInt32(dTienLuongHopDongNhanVien).ToString());
                            this.DGVChiTietLuong.Rows[addLuongNhanVien].Cells[5].Value = this.txtNgayCongTinh.Text;
                            sDangKyThamGiaBaoHiem = dtNhanVienGetTinhLuong.Rows[iNhanVienGetTinhLuong]["DangThamGiaBaoHiem"].ToString();
                        }
                        double dTongCongLamDuocTinhLuong;
                        dTongCongLamDuocTinhLuong = 0.0;
                        double dTongTangCaLamDuocTinhLuong;
                        dTongTangCaLamDuocTinhLuong = 0.0;
                        new DataTable();
                        this._tinhCongDTO.MaChamCong = iMaChamCongTinhCongTinhLuong;
                        DataTable dtNhanVienChiTietTinhLuong;
                        dtNhanVienChiTietTinhLuong = this._tinhCongBLL.TinhCongGetByMaChamCong(this._tinhCongDTO);
                        for (int iNhanVienChiTietTinhLuong = 0; iNhanVienChiTietTinhLuong < dtNhanVienChiTietTinhLuong.Rows.Count; iNhanVienChiTietTinhLuong++)
                        {
                            dTongCongLamDuocTinhLuong += Convert.ToDouble(dtNhanVienChiTietTinhLuong.Rows[iNhanVienChiTietTinhLuong]["Cong"].ToString());
                            dTongTangCaLamDuocTinhLuong += Convert.ToDouble(dtNhanVienChiTietTinhLuong.Rows[iNhanVienChiTietTinhLuong]["TC1"].ToString()) + Convert.ToDouble(dtNhanVienChiTietTinhLuong.Rows[iNhanVienChiTietTinhLuong]["TC2"].ToString()) + Convert.ToDouble(dtNhanVienChiTietTinhLuong.Rows[iNhanVienChiTietTinhLuong]["TC3"].ToString()) + Convert.ToDouble(dtNhanVienChiTietTinhLuong.Rows[iNhanVienChiTietTinhLuong]["TC4"].ToString());
                        }
                        this.DGVChiTietLuong.Rows[addLuongNhanVien].Cells[6].Value = dTongCongLamDuocTinhLuong.ToString();
                        this.DGVChiTietLuong.Rows[addLuongNhanVien].Cells[7].Value = dTongTangCaLamDuocTinhLuong.ToString();
                        double dLuongTheoNgayCongLamDuoc;
                        dLuongTheoNgayCongLamDuoc = Math.Round(Convert.ToDouble(this._convertMoney.loaidau(this.DGVChiTietLuong.Rows[addLuongNhanVien].Cells[4].Value.ToString())) / Convert.ToDouble(this.txtNgayCongTinh.Text), 0) * dTongCongLamDuocTinhLuong;
                        this.DGVChiTietLuong.Rows[addLuongNhanVien].Cells[8].Value = this._convertMoney.chendau(Convert.ToInt32(dLuongTheoNgayCongLamDuoc).ToString());
                        double dTienTangCaLamDuoc;
                        dTienTangCaLamDuoc = Math.Round(Math.Round(dTienLuongHopDongNhanVien / Convert.ToDouble(this.txtNgayCongTinh.Text), 0) / 8.0, 0) * dTongTangCaLamDuocTinhLuong;
                        this.DGVChiTietLuong.Rows[addLuongNhanVien].Cells[9].Value = this._convertMoney.chendau(Convert.ToInt32(dTienTangCaLamDuoc).ToString());
                        double dTongTienPhuCapComTinhLuong;
                        dTongTienPhuCapComTinhLuong = 0.0;
                        double dTongTienPhuCapKhacTinhLuong;
                        dTongTienPhuCapKhacTinhLuong = 0.0;
                        double dTongTienTamUngTinhLuong;
                        dTongTienTamUngTinhLuong = 0.0;
                        double dTongTienViPhamTinhLuong;
                        dTongTienViPhamTinhLuong = 0.0;
                        double dTongTienThuongTinhLuong;
                        dTongTienThuongTinhLuong = 0.0;
                        new DataTable();
                        this._chiTietCongTruLuongDTO.MaChamCong = iMaChamCongTinhCongTinhLuong;
                        DataTable dtCongTruLuongPhuCapTienCom;
                        dtCongTruLuongPhuCapTienCom = this._chiTietCongTruLuongBLL.ChiTietCongTruLuongGetByMaChamCong(iMaChamCongTinhCongTinhLuong);
                        for (int iCongTruLuongPhuCapTienCom = 0; iCongTruLuongPhuCapTienCom < dtCongTruLuongPhuCapTienCom.Rows.Count; iCongTruLuongPhuCapTienCom++)
                        {
                            this.DGVChiTietLuong.Rows[addLuongNhanVien].Cells[10].Value = this._convertMoney.chendau(Convert.ToInt32(dtCongTruLuongPhuCapTienCom.Rows[iCongTruLuongPhuCapTienCom]["ChiTietPhuCapCom"]).ToString());
                            dTongTienPhuCapComTinhLuong = Math.Round(Convert.ToDouble(dtCongTruLuongPhuCapTienCom.Rows[iCongTruLuongPhuCapTienCom]["ChiTietPhuCapCom"].ToString()) / Convert.ToDouble(this.txtNgayCongTinh.Text), 0) * dTongCongLamDuocTinhLuong;
                            this.DGVChiTietLuong.Rows[addLuongNhanVien].Cells[11].Value = this._convertMoney.chendau(Convert.ToInt32(dTongTienPhuCapComTinhLuong).ToString());
                            dTongTienPhuCapKhacTinhLuong = Convert.ToDouble(dtCongTruLuongPhuCapTienCom.Rows[iCongTruLuongPhuCapTienCom]["ChiTietPhuCapKhac"].ToString());
                            this.DGVChiTietLuong.Rows[addLuongNhanVien].Cells[12].Value = this._convertMoney.chendau(Convert.ToInt32(dTongTienPhuCapKhacTinhLuong).ToString());
                            dTongTienTamUngTinhLuong = Convert.ToDouble(dtCongTruLuongPhuCapTienCom.Rows[iCongTruLuongPhuCapTienCom]["ChiTietTamUngLuong"].ToString());
                            this.DGVChiTietLuong.Rows[addLuongNhanVien].Cells[18].Value = this._convertMoney.chendau(Convert.ToInt32(dTongTienTamUngTinhLuong).ToString());
                            dTongTienViPhamTinhLuong = Convert.ToDouble(dtCongTruLuongPhuCapTienCom.Rows[iCongTruLuongPhuCapTienCom]["ChiTietViPham"].ToString());
                            this.DGVChiTietLuong.Rows[addLuongNhanVien].Cells[19].Value = this._convertMoney.chendau(Convert.ToInt32(dTongTienViPhamTinhLuong).ToString());
                            dTongTienThuongTinhLuong = Convert.ToDouble(dtCongTruLuongPhuCapTienCom.Rows[iCongTruLuongPhuCapTienCom]["ChiTietThuong"].ToString());
                            this.DGVChiTietLuong.Rows[addLuongNhanVien].Cells[13].Value = this._convertMoney.chendau(Convert.ToInt32(dTongTienThuongTinhLuong).ToString());
                        }
                        double dTongLuongTinhLuong;
                        dTongLuongTinhLuong = dLuongTheoNgayCongLamDuoc + dTongTienPhuCapComTinhLuong + dTongTienPhuCapKhacTinhLuong + dTienTangCaLamDuoc + dTongTienThuongTinhLuong;
                        this.DGVChiTietLuong.Rows[addLuongNhanVien].Cells[14].Value = this._convertMoney.chendau(Convert.ToInt32(dTongLuongTinhLuong).ToString());
                        double dTienBaoHiemXaHoi;
                        dTienBaoHiemXaHoi = 0.0;
                        double dTienBaoHiemyTe;
                        dTienBaoHiemyTe = 0.0;
                        double dTienBaoHiemThatNghiep;
                        dTienBaoHiemThatNghiep = 0.0;
                        if (sDangKyThamGiaBaoHiem == "True")
                        {
                            dTienBaoHiemXaHoi = Math.Round(Convert.ToDouble(this._convertMoney.loaidau(this.DGVChiTietLuong.Rows[addLuongNhanVien].Cells[3].Value.ToString())) * this.dHeSoBaoHiemXaHoi / 100.0);
                            this.DGVChiTietLuong.Rows[addLuongNhanVien].Cells[15].Value = this._convertMoney.chendau(Convert.ToInt32(dTienBaoHiemXaHoi).ToString());
                            dTienBaoHiemyTe = Math.Round(Convert.ToDouble(this._convertMoney.loaidau(this.DGVChiTietLuong.Rows[addLuongNhanVien].Cells[3].Value.ToString())) * this.dHeSoBaoHiemYTe / 100.0);
                            this.DGVChiTietLuong.Rows[addLuongNhanVien].Cells[16].Value = this._convertMoney.chendau(Convert.ToInt32(dTienBaoHiemyTe).ToString());
                            dTienBaoHiemThatNghiep = Math.Round(Convert.ToDouble(this._convertMoney.loaidau(this.DGVChiTietLuong.Rows[addLuongNhanVien].Cells[3].Value.ToString())) * this.dHeSoBaoHiemThatNghiep / 100.0);
                            this.DGVChiTietLuong.Rows[addLuongNhanVien].Cells[17].Value = this._convertMoney.chendau(Convert.ToInt32(dTienBaoHiemThatNghiep).ToString());
                        }
                        else
                        {
                            this.DGVChiTietLuong.Rows[addLuongNhanVien].Cells[15].Value = this._convertMoney.chendau(Convert.ToInt32(dTienBaoHiemXaHoi).ToString());
                            this.DGVChiTietLuong.Rows[addLuongNhanVien].Cells[16].Value = this._convertMoney.chendau(Convert.ToInt32(dTienBaoHiemyTe).ToString());
                            this.DGVChiTietLuong.Rows[addLuongNhanVien].Cells[17].Value = this._convertMoney.chendau(Convert.ToInt32(dTienBaoHiemThatNghiep).ToString());
                        }
                        double dTongTienTruVaoLuong;
                        dTongTienTruVaoLuong = dTienBaoHiemXaHoi + dTienBaoHiemyTe + dTienBaoHiemThatNghiep + dTongTienTamUngTinhLuong + dTongTienViPhamTinhLuong;
                        this.DGVChiTietLuong.Rows[addLuongNhanVien].Cells[20].Value = this._convertMoney.chendau(Convert.ToInt32(dTongTienTruVaoLuong).ToString());
                        this.DGVChiTietLuong.Rows[addLuongNhanVien].Cells[21].Value = this._convertMoney.chendau(Convert.ToInt32(dTongLuongTinhLuong - dTongTienTruVaoLuong).ToString());
                    }
                }
            }
            if (this.checkBoxCoTinhLuong.Checked)
            {
                for (int iLuuTinhLuong = 0; iLuuTinhLuong < this.DGVChiTietLuong.Rows.Count; iLuuTinhLuong++)
                {
                    this._tinhLuongDTO.MaNhanVien = this.DGVChiTietLuong.Rows[iLuuTinhLuong].Cells[0].Value.ToString();
                    this._tinhLuongDTO.TenNhanVien = this.DGVChiTietLuong.Rows[iLuuTinhLuong].Cells[1].Value.ToString();
                    this._tinhLuongDTO.MaChamCong = Convert.ToInt32(this.DGVChiTietLuong.Rows[iLuuTinhLuong].Cells[2].Value.ToString());
                    this._tinhLuongDTO.LuongCoBanBaoHiem = this._convertMoney.loaidau(this.DGVChiTietLuong.Rows[iLuuTinhLuong].Cells[3].Value.ToString());
                    this._tinhLuongDTO.LuongHopDong = this._convertMoney.loaidau(this.DGVChiTietLuong.Rows[iLuuTinhLuong].Cells[4].Value.ToString());
                    this._tinhLuongDTO.NgayCongTinh = this.DGVChiTietLuong.Rows[iLuuTinhLuong].Cells[5].Value.ToString();
                    this._tinhLuongDTO.NgayCongLamDuoc = this.DGVChiTietLuong.Rows[iLuuTinhLuong].Cells[6].Value.ToString();
                    this._tinhLuongDTO.SoGioTangCa = this.DGVChiTietLuong.Rows[iLuuTinhLuong].Cells[7].Value.ToString();
                    this._tinhLuongDTO.LuongNgayCongLamDuoc = this._convertMoney.loaidau(this.DGVChiTietLuong.Rows[iLuuTinhLuong].Cells[8].Value.ToString());
                    this._tinhLuongDTO.TienTangCa = this._convertMoney.loaidau(this.DGVChiTietLuong.Rows[iLuuTinhLuong].Cells[9].Value.ToString());
                    this._tinhLuongDTO.PhuCapTienCom = this._convertMoney.loaidau(this.DGVChiTietLuong.Rows[iLuuTinhLuong].Cells[10].Value.ToString());
                    this._tinhLuongDTO.PhuCapTienComTheoNgayCong = this._convertMoney.loaidau(this.DGVChiTietLuong.Rows[iLuuTinhLuong].Cells[11].Value.ToString());
                    this._tinhLuongDTO.PhuCapKhac = this._convertMoney.loaidau(this.DGVChiTietLuong.Rows[iLuuTinhLuong].Cells[12].Value.ToString());
                    this._tinhLuongDTO.Thuong = this._convertMoney.loaidau(this.DGVChiTietLuong.Rows[iLuuTinhLuong].Cells[13].Value.ToString());
                    this._tinhLuongDTO.TongLuong = this._convertMoney.loaidau(this.DGVChiTietLuong.Rows[iLuuTinhLuong].Cells[14].Value.ToString());
                    this._tinhLuongDTO.BHXH = this._convertMoney.loaidau(this.DGVChiTietLuong.Rows[iLuuTinhLuong].Cells[15].Value.ToString());
                    this._tinhLuongDTO.BHYT = this._convertMoney.loaidau(this.DGVChiTietLuong.Rows[iLuuTinhLuong].Cells[16].Value.ToString());
                    this._tinhLuongDTO.BHTN = this._convertMoney.loaidau(this.DGVChiTietLuong.Rows[iLuuTinhLuong].Cells[17].Value.ToString());
                    this._tinhLuongDTO.TamUng = this._convertMoney.loaidau(this.DGVChiTietLuong.Rows[iLuuTinhLuong].Cells[18].Value.ToString());
                    this._tinhLuongDTO.ViPham = this._convertMoney.loaidau(this.DGVChiTietLuong.Rows[iLuuTinhLuong].Cells[19].Value.ToString());
                    this._tinhLuongDTO.TongTienTruVaoLuong = this._convertMoney.loaidau(this.DGVChiTietLuong.Rows[iLuuTinhLuong].Cells[20].Value.ToString());
                    this._tinhLuongDTO.LuongThucLanh = this._convertMoney.loaidau(this.DGVChiTietLuong.Rows[iLuuTinhLuong].Cells[21].Value.ToString());
                    this._tinhLuongBLL.TinhLuongInsert(this._tinhLuongDTO);
                }
            }
            _loadTinhCong.Close();
        }

        private void dateTimeTuNgay_ValueChanged(object sender, EventArgs e)
        {
            xuatThuTuNgay();
        }

        private void dateTimeDenNgay_ValueChanged(object sender, EventArgs e)
        {
            xuatThuDenNgay();
        }

        private void xuatThuTuNgay()
        {
            DateTime thuA2;
            thuA2 = dateTimeTuNgay.Value;
            lbThuA.Text = DateTimeProgress.XuatThu((int)thuA2.DayOfWeek);
            if (lbThuA.Text == "Chủ nhật")
            {
                lbThuA.ForeColor = Color.Red;
            }
            else
            {
                lbThuA.ForeColor = Color.Blue;
            }
        }

        private void xuatThuDenNgay()
        {
            DateTime thuB2;
            thuB2 = dateTimeDenNgay.Value;
            lbThuB.Text = DateTimeProgress.XuatThu((int)thuB2.DayOfWeek);
            if (lbThuB.Text == "Chủ nhật")
            {
                lbThuB.ForeColor = Color.Red;
            }
            else
            {
                lbThuB.ForeColor = Color.Blue;
            }
        }

        private void loadControlTinhCong()
        {
            DGVTinhCong.Columns["Cong"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            DGVTinhCong.Columns["Gio"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            DGVTinhCong.Columns["Tre"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            DGVTinhCong.Columns["VeSom"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            DGVTinhCong.Columns["VeTre"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            DGVTinhCong.Columns["TC1"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            DGVTinhCong.Columns["TC2"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            DGVTinhCong.Columns["TC3"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            DGVTinhCong.Columns["TC4"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            DGVTinhCong.Columns["TongGio"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            DGVTinhCong.Columns["DemCong"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            DGVTinhCong.Columns["KyHieu"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
        }

        private void loadControlTinhLuong()
        {
            DGVChiTietLuong.Columns[3].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            DGVChiTietLuong.Columns[4].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            DGVChiTietLuong.Columns[5].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            DGVChiTietLuong.Columns[6].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            DGVChiTietLuong.Columns[7].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            DGVChiTietLuong.Columns[8].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            DGVChiTietLuong.Columns[9].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            DGVChiTietLuong.Columns[10].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            DGVChiTietLuong.Columns[11].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            DGVChiTietLuong.Columns[12].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            DGVChiTietLuong.Columns[13].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            DGVChiTietLuong.Columns[14].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            DGVChiTietLuong.Columns[15].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            DGVChiTietLuong.Columns[16].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            DGVChiTietLuong.Columns[17].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            DGVChiTietLuong.Columns[18].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            DGVChiTietLuong.Columns[19].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            DGVChiTietLuong.Columns[20].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            DGVChiTietLuong.Columns[21].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            checkBoxCoTinhLuong.Checked = false;
            txtNgayCongTinh.Enabled = false;
        }

        private void loadTuyChon()
        {
            new DataTable();
            _tuyChonDTO.MaTuyChinh = "TC00001";
            DataTable dtLoadTuyChon;
            dtLoadTuyChon = _tuyChonBLL.showLoadTuyChon("TC00001");
            for (int iLoadTuyChon = 0; iLoadTuyChon < dtLoadTuyChon.Rows.Count; iLoadTuyChon++)
            {
                iLamTronCong = Convert.ToInt32(dtLoadTuyChon.Rows[iLoadTuyChon]["LamTronCong"].ToString());
                iLamTronGio = Convert.ToInt32(dtLoadTuyChon.Rows[iLoadTuyChon]["LamTronGio"].ToString());
                sDinhDangThoiGian = dtLoadTuyChon.Rows[iLoadTuyChon]["DinhDangThoiGian"].ToString();
                dTangCa1HeSo = Convert.ToDouble(dtLoadTuyChon.Rows[iLoadTuyChon]["TC1HeSo"].ToString());
                dTangCa2HeSo = Convert.ToDouble(dtLoadTuyChon.Rows[iLoadTuyChon]["TC2HeSo"].ToString());
                dTangCa3HeSo = Convert.ToDouble(dtLoadTuyChon.Rows[iLoadTuyChon]["TC3HeSo"].ToString());
                dTangCa4HeSo = Convert.ToDouble(dtLoadTuyChon.Rows[iLoadTuyChon]["TC4HeSo"].ToString());
                dTangCaChuNhatHeSo = Convert.ToDouble(dtLoadTuyChon.Rows[iLoadTuyChon]["ChuNhatHeSo"].ToString());
                sLuaChonKhaiBaoLuongBaoHiem = dtLoadTuyChon.Rows[iLoadTuyChon]["LuaChonKhaiBaoLuong"].ToString();
                dSoTienKhaiBao = Convert.ToDouble(dtLoadTuyChon.Rows[iLoadTuyChon]["SoTienKhaiBao"].ToString());
                dHeSoBaoHiemXaHoi = Convert.ToDouble(dtLoadTuyChon.Rows[iLoadTuyChon]["BaoHiemXaHoi"].ToString());
                dHeSoBaoHiemYTe = Convert.ToDouble(dtLoadTuyChon.Rows[iLoadTuyChon]["BaoHiemYTe"].ToString());
                dHeSoBaoHiemThatNghiep = Convert.ToDouble(dtLoadTuyChon.Rows[iLoadTuyChon]["BaoHiemThatNghiep"].ToString());
                iLamTronTuA = Convert.ToInt32(dtLoadTuyChon.Rows[iLoadTuyChon]["LTTuA"].ToString());
                iLamTronDenA = Convert.ToInt32(dtLoadTuyChon.Rows[iLoadTuyChon]["LTDenA"].ToString());
                sLamTronA = dtLoadTuyChon.Rows[iLoadTuyChon]["LTA"].ToString();
                iLamTronTuB = Convert.ToInt32(dtLoadTuyChon.Rows[iLoadTuyChon]["LTTuB"].ToString());
                iLamTronDenB = Convert.ToInt32(dtLoadTuyChon.Rows[iLoadTuyChon]["LTDenB"].ToString());
                sLamTronB = dtLoadTuyChon.Rows[iLoadTuyChon]["LTB"].ToString();
                iLamTronTuC = Convert.ToInt32(dtLoadTuyChon.Rows[iLoadTuyChon]["LTTuC"].ToString());
                iLamTronDenC = Convert.ToInt32(dtLoadTuyChon.Rows[iLoadTuyChon]["LTDenC"].ToString());
                sLamTronC = dtLoadTuyChon.Rows[iLoadTuyChon]["LTC"].ToString();
                iLamTronTuD = Convert.ToInt32(dtLoadTuyChon.Rows[iLoadTuyChon]["LTTuD"].ToString());
                iLamTronDenD = Convert.ToInt32(dtLoadTuyChon.Rows[iLoadTuyChon]["LTDenD"].ToString());
                sLamTronD = dtLoadTuyChon.Rows[iLoadTuyChon]["LTD"].ToString();
            }
        }

        private void load_NhanVienCoChamCong()
        {
            string sql = "select b.* from " +
                $"(select distinct MaChamCong from CheckInOut where NgayCham >= '{DateTime.Parse(dateTimeTuNgay.Text).ToString("yyyy/MM/dd")}' " +
                $"and NgayCham <= '{DateTime.Parse(dateTimeDenNgay.Text).ToString("yyyy/MM/dd")}') a " +
                $"join NHANVIEN b on a.MaChamCong = b.MaChamCong ";

            DataTable dt_nhavien = new DataTable();
            dt_nhavien = SQLHelper.ExecuteDt(sql);
            DGVDanhSachNhanVien.Rows.Clear();
            for (int iNhanVien = 0; iNhanVien < dt_nhavien.Rows.Count; iNhanVien++)
            {
                int addNhanVien = DGVDanhSachNhanVien.Rows.Add();
                DGVDanhSachNhanVien.Rows[addNhanVien].Cells[1].Value = dt_nhavien.Rows[iNhanVien]["MaNhanVien"].ToString();
                DGVDanhSachNhanVien.Rows[addNhanVien].Cells[2].Value = dt_nhavien.Rows[iNhanVien]["TenNhanVien"].ToString();
                DGVDanhSachNhanVien.Rows[addNhanVien].Cells[3].Value = dt_nhavien.Rows[iNhanVien]["MaChamCong"].ToString();
                DGVDanhSachNhanVien.Rows[addNhanVien].Cells[4].Value = dt_nhavien.Rows[iNhanVien]["MaPhongBan"].ToString();
            }
        }
        private void treeViewSoDoQuanLy_AfterSelect(object sender, TreeViewEventArgs e)
        {
            if (treeViewSoDoQuanLy.SelectedNode.Tag.ToString() == "CoChamCong")
            {
                load_NhanVienCoChamCong();
            }
            else
            {
                sMaCongTyTreeView = "";
                sMaKhuVucTreeView = "";
                sMaPhongBanTreeView = "";
                sMaChucVuTreeView = "";
                DGVDanhSachNhanVien.Rows.Clear();
                _tenNode = treeViewSoDoQuanLy.SelectedNode.Text;
                DataTable dtTreeviewPhongBan = new DataTable();
                _phongBanDTO.TenPhongBan = _tenNode;
                dtTreeviewPhongBan = _phongBanBLL.PhongBanGetTreeView(_phongBanDTO);
                for (int iTreeviewPhongBan = 0; iTreeviewPhongBan < dtTreeviewPhongBan.Rows.Count; iTreeviewPhongBan++)
                {
                    sMaPhongBanTreeView = dtTreeviewPhongBan.Rows[iTreeviewPhongBan]["MaPhongBan"].ToString();
                }
                DataTable dtTreeViewCongTy = new DataTable();
                _congTyDTO.TenCongTy = _tenNode;
                dtTreeViewCongTy = _congTyBLL.CongTygetTreeView(_congTyDTO);
                DataTable dtTreeViewKhuVuc = new DataTable();
                _khuVucDTO.TenKhuVuc = _tenNode;
                dtTreeViewKhuVuc = _khuVucBLL.KhuVucgetTreeView(_khuVucDTO);
                for (int iTreeviewKhuVuc = 0; iTreeviewKhuVuc < dtTreeViewKhuVuc.Rows.Count; iTreeviewKhuVuc++)
                {
                    sMaKhuVucTreeView = dtTreeViewKhuVuc.Rows[iTreeviewKhuVuc]["MaKhuVuc"].ToString();
                }
                DataTable dtTreeViewChucVu = new DataTable();
                _chucVuDTO.TenChucVu = _tenNode;
                dtTreeViewChucVu = _chucVuBLL.ChucVugetTreeView(_chucVuDTO);
                for (int iTreeviewChucVu = 0; iTreeviewChucVu < dtTreeViewChucVu.Rows.Count; iTreeviewChucVu++)
                {
                    sMaChucVuTreeView = dtTreeViewChucVu.Rows[iTreeviewChucVu]["MaChucVu"].ToString();
                }
                DataTable dtNhanVien = new DataTable();
                _nhanVienDTO.MaCongTy = sMaCongTyTreeView;
                _nhanVienDTO.MaKhuVuc = sMaKhuVucTreeView;
                _nhanVienDTO.MaPhongBan = sMaPhongBanTreeView;
                _nhanVienDTO.MaChucVu = sMaChucVuTreeView;
                dtNhanVien = _nhanVienBLL.NhanViengetFromTreeview(_nhanVienDTO);
                for (int iNhanVien = 0; iNhanVien < dtNhanVien.Rows.Count; iNhanVien++)
                {
                    int addNhanVien = DGVDanhSachNhanVien.Rows.Add();
                    DGVDanhSachNhanVien.Rows[addNhanVien].Cells[1].Value = dtNhanVien.Rows[iNhanVien]["MaNhanVien"].ToString();
                    DGVDanhSachNhanVien.Rows[addNhanVien].Cells[2].Value = dtNhanVien.Rows[iNhanVien]["TenNhanVien"].ToString();
                    DGVDanhSachNhanVien.Rows[addNhanVien].Cells[3].Value = dtNhanVien.Rows[iNhanVien]["MaChamCong"].ToString();
                    DGVDanhSachNhanVien.Rows[addNhanVien].Cells[4].Value = dtNhanVien.Rows[iNhanVien]["MaPhongBan"].ToString();
                }
            }
        }

        private void navigationPane1_Load(object sender, EventArgs e)
        {
            navigationPane1.TitlePanel.Text = "Sơ Đồ Công Ty";
            buttonItem1.Text = "Sơ Đồ Công Ty";
        }

        private static void setListview(ListView sListView, string sCaption, byte sIcon, ImageList sImageList)
        {
            sListView.Width = 250;
            sListView.LargeImageList = sImageList;
            sListView.SmallImageList = sImageList;
            sListView.Items.Add(new ListViewItem(sCaption, sIcon));
        }

        //private void loadListViewBaoCao()
        //{
        //    setListview(listViewBaoCao, "Chi tiết từng người từng ngày", 0, imageBaoCao);
        //    setListview(listViewBaoCao, "Chi tiết thời gian làm việc", 1, imageBaoCao);
        //    setListview(listViewBaoCao, "Chi tiết giờ và tăng ca kèm kí hiệu", 2, imageBaoCao);
        //    setListview(listViewBaoCao, "Xuất lưới", 3, imageBaoCao);
        //    setListview(listViewBaoCao, "Thống kê tháng (ký hiệu)", 4, imageBaoCao);
        //    setListview(listViewBaoCao, "Thống kê tháng (công)", 5, imageBaoCao);
        //    setListview(listViewBaoCao, "Thống kê tháng (giờ)", 6, imageBaoCao);
        //    setListview(listViewBaoCao, "Thống kê tháng (giờ và tăng ca)", 9, imageBaoCao);
        //    setListview(listViewBaoCao, "Bảng Lương Tổng Hợp", 7, imageBaoCao);
        //    setListview(listViewBaoCao, "Bảng lương từng nhân viên", 8, imageBaoCao);
        //    setListview(listViewBaoCao, "Tổng Hợp Tháng", 10, imageBaoCao);
        //}

        private void listViewBaoCao_Click(object sender, EventArgs e)
        {
            switch (listViewBaoCao.Items[listViewBaoCao.FocusedItem.Index].ImageIndex.ToString())
            {
                case "0":
                    ChiTietTungNguoiTungNgay_Click(sender, e);
                    break;
                case "1":
                    ChiTietThoiGianLamViec_Click(sender, e);
                    break;
                case "2":
                    ThongKeThangCongPB_Click(sender, e);
                    break;
                case "3":
                    XuatLuoi_Click(sender, e);
                    break;
                case "4":
                    ThongKeThangKyHieu_Click(sender, e);
                    break;
                case "5":
                    ThongKeThangCong_Click(sender, e);
                    break;
                case "6":
                    ThongKeThangGio_Click(sender, e);
                    break;
                case "7":
                    TienLuong_Click(sender, e);
                    break;
                case "8":
                    BangLuongTungNhanVien_Click(sender, e);
                    break;
                case "9":
                    ThongKeGioVaTC_Click(sender, e);
                    break;
                case "10":
                    TongHop_Click(sender, e);
                    break;
            }
        }

        private void BangLuongTungNhanVien_Click(object sender, EventArgs e)
        {
            //BangLuongTungNhanVienExport();
        }

        private void TienLuong_Click(object sender, EventArgs e)
        {
            //TienLuongExport();
        }

        private void ThongKeThangGio_Click(object sender, EventArgs e)
        {
            ThongKeThangGio();
        }

        private void ChiTietTungNguoiTungNgay_Click(object sender, EventArgs e)
        {
            ExportExcelChiTietTungNguoiTungNgay();
        }

        private void TongHop_Click(object sender, EventArgs e)
        {
            ExportTongHop();
        }

        private void ThongKeThangCong_Click(object sender, EventArgs e)
        {
            ExportExcelThongKeThangCong();
        }

        private void ThongKeGioVaTC_Click(object sender, EventArgs e)
        {
            ThongKeGioVaTC();
        }

        private void ThongKeThangCongPB_Click(object sender, EventArgs e)
        {
            ThongKeChiTietGioVaTC();
        }

        private void ChiTietThoiGianLamViec_Click(object sender, EventArgs e)
        {
            //frmChonLanXuat _chonLanXuat;
            //_chonLanXuat = new frmChonLanXuat();
            //_chonLanXuat.ShowDialog();
            //iChonLanXuat = _chonLanXuat._iChonLanXuat;
            //if (iChonLanXuat != 0)
            //{
            //    ExportExcelChiTietThoiGianLamViec();
            //}
        }

        private void ThongKeThangKyHieu_Click(object sender, EventArgs e)
        {
            ExportThongKeThang_KyHieu();
        }

        private void ThongKeChiTietGioVaTC()
        {
            Thread.CurrentThread.CurrentCulture = new CultureInfo("en-US");
            Excel.Application xla_ChiTietThoiGianLamViec;
            xla_ChiTietThoiGianLamViec = new Excel.Application();
            xla_ChiTietThoiGianLamViec.Workbooks.Add(Excel.XlSheetType.xlWorksheet);
            _ = xla_ChiTietThoiGianLamViec.ActiveSheet;
            Excel.Worksheet ws_ChiTietThoiGianLamViec;
            ws_ChiTietThoiGianLamViec = xla_ChiTietThoiGianLamViec.Worksheets.get_Item((object)1);
            DateTime dNgayTinh;
            dNgayTinh = Convert.ToDateTime(dateTimeTuNgay.Text);
            DateTime dNgayBatDauTinhCong;
            dNgayBatDauTinhCong = new DateTime(dNgayTinh.Year, dNgayTinh.Month, dNgayTinh.Day, 0, 0, 0);
            bool failed;
            failed = false;
            do
            {
                try
                {
                    Excel.Range excelChiTietThoiGianLamViec_CongTyHeader;
                    excelChiTietThoiGianLamViec_CongTyHeader = (ws_ChiTietThoiGianLamViec).get_Range((object)"A1", (object)"BT1");
                    excelChiTietThoiGianLamViec_CongTyHeader.Cells[1, 1] = sTenCongTyReport;
                    excelChiTietThoiGianLamViec_CongTyHeader.get_Range((object)"A1", (object)"BT1").Merge(true);
                    Excel.Range excelChiTietThoiGianLamViec_DiaChiHeader;
                    excelChiTietThoiGianLamViec_DiaChiHeader = (ws_ChiTietThoiGianLamViec).get_Range((object)"A2", (object)"BT2");
                    excelChiTietThoiGianLamViec_DiaChiHeader.Cells[1, 1] = sDiaChiCongTyReport;
                    excelChiTietThoiGianLamViec_DiaChiHeader.get_Range((object)"A1", (object)"BT1").Merge(true);
                    Excel.Range excelChiTietThoiGianLamViec_DinhDangCongTyHeader;
                    excelChiTietThoiGianLamViec_DinhDangCongTyHeader = (ws_ChiTietThoiGianLamViec).get_Range((object)"A1", (object)"BT2");
                    excelChiTietThoiGianLamViec_DinhDangCongTyHeader.Font.Name = "Times New Roman";
                    excelChiTietThoiGianLamViec_DinhDangCongTyHeader.Font.Size = "11";
                    new DataTable();
                    DataTable dtNgayTinhCongChiTietThoiGianLamViec;
                    dtNgayTinhCongChiTietThoiGianLamViec = _ngayTinhCongBLL.showThongTinNgayTinhCong();
                    for (int iNgayTinhCongChiTietThoiGianLamViec = 0; iNgayTinhCongChiTietThoiGianLamViec < dtNgayTinhCongChiTietThoiGianLamViec.Rows.Count; iNgayTinhCongChiTietThoiGianLamViec++)
                    {
                        sTuNgayChiTietThoiGianLamViec = string.Format("{0:d}", Convert.ToDateTime(dtNgayTinhCongChiTietThoiGianLamViec.Rows[iNgayTinhCongChiTietThoiGianLamViec]["NgayBatDau"].ToString()));
                        sDenNgayChiTietThoiGianLamViec = string.Format("{0:d}", Convert.ToDateTime(dtNgayTinhCongChiTietThoiGianLamViec.Rows[iNgayTinhCongChiTietThoiGianLamViec]["NgayKetThuc"].ToString()));
                    }
                    Excel.Range excelChiTietThoiGianLamViec_TieuDeHeader;
                    excelChiTietThoiGianLamViec_TieuDeHeader = (ws_ChiTietThoiGianLamViec).get_Range((object)"A4", (object)"BU4");
                    excelChiTietThoiGianLamViec_TieuDeHeader.Cells[1, 1] = "BẢNG CHẤM CÔNG CHI TIẾT TỪ NGÀY " + sTuNgayChiTietThoiGianLamViec + " ĐẾN NGÀY " + sDenNgayChiTietThoiGianLamViec + " (MONTHLY REPORT)";
                    excelChiTietThoiGianLamViec_TieuDeHeader.get_Range((object)"A1", (object)"BU1").Merge(true);
                    excelChiTietThoiGianLamViec_TieuDeHeader.Font.Name = "Times New Roman";
                    excelChiTietThoiGianLamViec_TieuDeHeader.Font.Size = "14";
                    excelChiTietThoiGianLamViec_TieuDeHeader.Font.Bold = true;
                    excelChiTietThoiGianLamViec_TieuDeHeader.RowHeight = 18;
                    excelChiTietThoiGianLamViec_TieuDeHeader.HorizontalAlignment = Excel.Constants.xlCenter;
                    Excel.Range excelChiTietThoiGianLamViec_STTHeader;
                    excelChiTietThoiGianLamViec_STTHeader = (ws_ChiTietThoiGianLamViec).get_Range((object)"A6", (object)"A8");
                    excelChiTietThoiGianLamViec_STTHeader.Cells[1, 1] = "STT";
                    excelChiTietThoiGianLamViec_STTHeader.get_Range((object)"A1", (object)"A3").MergeCells = true;
                    excelChiTietThoiGianLamViec_STTHeader.VerticalAlignment = HorizontalAlignment.Center;
                    excelChiTietThoiGianLamViec_STTHeader.ColumnWidth = 4;
                    Excel.Range excelChiTietThoiGianLamViec_MaNhanVienHeader;
                    excelChiTietThoiGianLamViec_MaNhanVienHeader = (ws_ChiTietThoiGianLamViec).get_Range((object)"B6", (object)"B8");
                    excelChiTietThoiGianLamViec_MaNhanVienHeader.Cells[1, 1] = "MÃ NHÂN VIÊN";
                    excelChiTietThoiGianLamViec_MaNhanVienHeader.get_Range((object)"A1", (object)"A3").MergeCells = true;
                    excelChiTietThoiGianLamViec_MaNhanVienHeader.VerticalAlignment = HorizontalAlignment.Center;
                    excelChiTietThoiGianLamViec_MaNhanVienHeader.ColumnWidth = 14;
                    Excel.Range excelChiTietThoiGianLamViec_TenNhanVienHeader;
                    excelChiTietThoiGianLamViec_TenNhanVienHeader = (ws_ChiTietThoiGianLamViec).get_Range((object)"C6", (object)"C8");
                    excelChiTietThoiGianLamViec_TenNhanVienHeader.Cells[1, 1] = "TÊN NHÂN VIÊN";
                    excelChiTietThoiGianLamViec_TenNhanVienHeader.get_Range((object)"A1", (object)"A3").MergeCells = true;
                    excelChiTietThoiGianLamViec_TenNhanVienHeader.VerticalAlignment = HorizontalAlignment.Center;
                    excelChiTietThoiGianLamViec_TenNhanVienHeader.ColumnWidth = 14;
                    Excel.Range excelChiTietThoiGianLamViec_PhongBanHeader;
                    excelChiTietThoiGianLamViec_PhongBanHeader = (ws_ChiTietThoiGianLamViec).get_Range((object)"D6", (object)"D8");
                    excelChiTietThoiGianLamViec_PhongBanHeader.Cells[1, 1] = "PHÒNG BAN";
                    excelChiTietThoiGianLamViec_PhongBanHeader.get_Range((object)"A1", (object)"A3").MergeCells = true;
                    excelChiTietThoiGianLamViec_PhongBanHeader.VerticalAlignment = HorizontalAlignment.Center;
                    excelChiTietThoiGianLamViec_PhongBanHeader.ColumnWidth = 11;
                    Excel.Range excelChiTietThoiGianLamViec_NgayTrongThangHeader;
                    excelChiTietThoiGianLamViec_NgayTrongThangHeader = (ws_ChiTietThoiGianLamViec).get_Range((object)"E6", (object)"BN6");
                    excelChiTietThoiGianLamViec_NgayTrongThangHeader.Cells[1, 1] = "NGÀY TRONG THÁNG (DAYS IN MONTH)";
                    excelChiTietThoiGianLamViec_NgayTrongThangHeader.get_Range((object)"A1", (object)"BJ1").Merge(true);
                    int ColunmNgayChiTietThoiGianLamViec;
                    ColunmNgayChiTietThoiGianLamViec = 1;
                    int iTangHangO;
                    iTangHangO = 8;
                    int iTangCotO;
                    iTangCotO = 5;
                    for (int iChiTietThoiGianLamViec2 = 0; iChiTietThoiGianLamViec2 < 31; iChiTietThoiGianLamViec2++)
                    {
                        int iNgayChamChiTietThoiGianLamViec;
                        iNgayChamChiTietThoiGianLamViec = Convert.ToInt32(Convert.ToDateTime(dateTimeTuNgay.Value.AddDays(iChiTietThoiGianLamViec2).ToString()).Day);
                        Excel.Range excelChiTietThoiGianLamViec_Ngay;
                        excelChiTietThoiGianLamViec_Ngay = (ws_ChiTietThoiGianLamViec).get_Range((object)"E7", (object)"BN8");
                        excelChiTietThoiGianLamViec_Ngay.Cells[1, ColunmNgayChiTietThoiGianLamViec + iChiTietThoiGianLamViec2] = iNgayChamChiTietThoiGianLamViec;
                        if (iChiTietThoiGianLamViec2 == 0)
                        {
                            excelChiTietThoiGianLamViec_Ngay.get_Range((object)"A1", (object)"B1").Merge(true);
                        }
                        if (iChiTietThoiGianLamViec2 == 1)
                        {
                            excelChiTietThoiGianLamViec_Ngay.get_Range((object)"C1", (object)"D1").Merge(true);
                        }
                        if (iChiTietThoiGianLamViec2 == 2)
                        {
                            excelChiTietThoiGianLamViec_Ngay.get_Range((object)"E1", (object)"F1").Merge(true);
                        }
                        if (iChiTietThoiGianLamViec2 == 3)
                        {
                            excelChiTietThoiGianLamViec_Ngay.get_Range((object)"G1", (object)"H1").Merge(true);
                        }
                        if (iChiTietThoiGianLamViec2 == 4)
                        {
                            excelChiTietThoiGianLamViec_Ngay.get_Range((object)"I1", (object)"J1").Merge(true);
                        }
                        if (iChiTietThoiGianLamViec2 == 5)
                        {
                            excelChiTietThoiGianLamViec_Ngay.get_Range((object)"K1", (object)"L1").Merge(true);
                        }
                        if (iChiTietThoiGianLamViec2 == 6)
                        {
                            excelChiTietThoiGianLamViec_Ngay.get_Range((object)"K1", (object)"L1").Merge(true);
                        }
                        if (iChiTietThoiGianLamViec2 == 7)
                        {
                            excelChiTietThoiGianLamViec_Ngay.get_Range((object)"M1", (object)"N1").Merge(true);
                        }
                        if (iChiTietThoiGianLamViec2 == 8)
                        {
                            excelChiTietThoiGianLamViec_Ngay.get_Range((object)"O1", (object)"P1").Merge(true);
                        }
                        if (iChiTietThoiGianLamViec2 == 9)
                        {
                            excelChiTietThoiGianLamViec_Ngay.get_Range((object)"Q1", (object)"R1").Merge(true);
                        }
                        if (iChiTietThoiGianLamViec2 == 10)
                        {
                            excelChiTietThoiGianLamViec_Ngay.get_Range((object)"S1", (object)"T1").Merge(true);
                        }
                        if (iChiTietThoiGianLamViec2 == 11)
                        {
                            excelChiTietThoiGianLamViec_Ngay.get_Range((object)"U1", (object)"V1").Merge(true);
                        }
                        if (iChiTietThoiGianLamViec2 == 12)
                        {
                            excelChiTietThoiGianLamViec_Ngay.get_Range((object)"W1", (object)"X1").Merge(true);
                        }
                        if (iChiTietThoiGianLamViec2 == 13)
                        {
                            excelChiTietThoiGianLamViec_Ngay.get_Range((object)"Y1", (object)"Z1").Merge(true);
                        }
                        if (iChiTietThoiGianLamViec2 == 14)
                        {
                            excelChiTietThoiGianLamViec_Ngay.get_Range((object)"AA1", (object)"AB1").Merge(true);
                        }
                        if (iChiTietThoiGianLamViec2 == 15)
                        {
                            excelChiTietThoiGianLamViec_Ngay.get_Range((object)"AC1", (object)"AD1").Merge(true);
                        }
                        if (iChiTietThoiGianLamViec2 == 16)
                        {
                            excelChiTietThoiGianLamViec_Ngay.get_Range((object)"AE1", (object)"AF1").Merge(true);
                        }
                        if (iChiTietThoiGianLamViec2 == 17)
                        {
                            excelChiTietThoiGianLamViec_Ngay.get_Range((object)"AG1", (object)"AH1").Merge(true);
                        }
                        if (iChiTietThoiGianLamViec2 == 18)
                        {
                            excelChiTietThoiGianLamViec_Ngay.get_Range((object)"AI1", (object)"AJ1").Merge(true);
                        }
                        if (iChiTietThoiGianLamViec2 == 19)
                        {
                            excelChiTietThoiGianLamViec_Ngay.get_Range((object)"AK1", (object)"AL1").Merge(true);
                        }
                        if (iChiTietThoiGianLamViec2 == 20)
                        {
                            excelChiTietThoiGianLamViec_Ngay.get_Range((object)"AM1", (object)"AN1").Merge(true);
                        }
                        if (iChiTietThoiGianLamViec2 == 21)
                        {
                            excelChiTietThoiGianLamViec_Ngay.get_Range((object)"AO1", (object)"AP1").Merge(true);
                        }
                        if (iChiTietThoiGianLamViec2 == 22)
                        {
                            excelChiTietThoiGianLamViec_Ngay.get_Range((object)"AQ1", (object)"AR1").Merge(true);
                        }
                        if (iChiTietThoiGianLamViec2 == 23)
                        {
                            excelChiTietThoiGianLamViec_Ngay.get_Range((object)"AS1", (object)"AT1").Merge(true);
                        }
                        if (iChiTietThoiGianLamViec2 == 24)
                        {
                            excelChiTietThoiGianLamViec_Ngay.get_Range((object)"AU1", (object)"AV1").Merge(true);
                        }
                        if (iChiTietThoiGianLamViec2 == 25)
                        {
                            excelChiTietThoiGianLamViec_Ngay.get_Range((object)"AW1", (object)"AX1").Merge(true);
                        }
                        if (iChiTietThoiGianLamViec2 == 26)
                        {
                            excelChiTietThoiGianLamViec_Ngay.get_Range((object)"AY1", (object)"AZ1").Merge(true);
                        }
                        if (iChiTietThoiGianLamViec2 == 27)
                        {
                            excelChiTietThoiGianLamViec_Ngay.get_Range((object)"BA1", (object)"BB1").Merge(true);
                        }
                        if (iChiTietThoiGianLamViec2 == 28)
                        {
                            excelChiTietThoiGianLamViec_Ngay.get_Range((object)"BC1", (object)"BD1").Merge(true);
                        }
                        if (iChiTietThoiGianLamViec2 == 29)
                        {
                            excelChiTietThoiGianLamViec_Ngay.get_Range((object)"BE1", (object)"BF1").Merge(true);
                        }
                        if (iChiTietThoiGianLamViec2 == 30)
                        {
                            excelChiTietThoiGianLamViec_Ngay.get_Range((object)"BG1", (object)"BH1").Merge(true);
                        }
                        excelChiTietThoiGianLamViec_Ngay.get_Range((object)"BI1", (object)"BJ1").Merge(true);
                        excelChiTietThoiGianLamViec_Ngay.Cells[2, ColunmNgayChiTietThoiGianLamViec + iChiTietThoiGianLamViec2] = "N";
                        excelChiTietThoiGianLamViec_Ngay.Cells[2, ColunmNgayChiTietThoiGianLamViec + iChiTietThoiGianLamViec2 + 1] = "O";
                        (ws_ChiTietThoiGianLamViec).get_Range(ws_ChiTietThoiGianLamViec.Cells[iTangHangO, iTangCotO], ws_ChiTietThoiGianLamViec.Cells[iTangHangO, iTangCotO]).Interior.Color = ColorTranslator.ToOle(Color.Red);
                        (ws_ChiTietThoiGianLamViec).get_Range(ws_ChiTietThoiGianLamViec.Cells[iTangHangO, iTangCotO + 1], ws_ChiTietThoiGianLamViec.Cells[iTangHangO, iTangCotO + 1]).Interior.Color = ColorTranslator.ToOle(Color.Yellow);
                        ColunmNgayChiTietThoiGianLamViec++;
                        iTangCotO = iTangCotO + 1 + 1;
                        excelChiTietThoiGianLamViec_Ngay.ColumnWidth = 4;
                    }
                    Excel.Range excelChiTietThoiGianLamViec_TongGioCongHeader;
                    excelChiTietThoiGianLamViec_TongGioCongHeader = (ws_ChiTietThoiGianLamViec).get_Range((object)"BO6", (object)"BO8");
                    excelChiTietThoiGianLamViec_TongGioCongHeader.Cells[1, 1] = "Ngày công \n (Work Day)";
                    excelChiTietThoiGianLamViec_TongGioCongHeader.get_Range((object)"A1", (object)"A3").MergeCells = true;
                    excelChiTietThoiGianLamViec_TongGioCongHeader.ColumnWidth = 10;
                    excelChiTietThoiGianLamViec_TongGioCongHeader.VerticalAlignment = HorizontalAlignment.Center;
                    excelChiTietThoiGianLamViec_TongGioCongHeader.WrapText = true;
                    Excel.Range excelChiTietThoiGianLamViec_TongNgayHeader;
                    excelChiTietThoiGianLamViec_TongNgayHeader = (ws_ChiTietThoiGianLamViec).get_Range((object)"BP6", (object)"BP8");
                    excelChiTietThoiGianLamViec_TongNgayHeader.Cells[1, 1] = "Phép năm \n (Annual Leave) ";
                    excelChiTietThoiGianLamViec_TongNgayHeader.get_Range((object)"A1", (object)"A3").MergeCells = true;
                    excelChiTietThoiGianLamViec_TongNgayHeader.ColumnWidth = 10;
                    excelChiTietThoiGianLamViec_TongNgayHeader.VerticalAlignment = HorizontalAlignment.Center;
                    excelChiTietThoiGianLamViec_TongNgayHeader.WrapText = true;
                    Excel.Range excelChiTietThoiGianLamViec_TongGioTangCaHeader;
                    excelChiTietThoiGianLamViec_TongGioTangCaHeader = (ws_ChiTietThoiGianLamViec).get_Range((object)"BQ6", (object)"BQ8");
                    excelChiTietThoiGianLamViec_TongGioTangCaHeader.Cells[1, 1] = "Ngày lễ \n (Vacation holidays)";
                    excelChiTietThoiGianLamViec_TongGioTangCaHeader.get_Range((object)"A1", (object)"A3").MergeCells = true;
                    excelChiTietThoiGianLamViec_TongGioTangCaHeader.ColumnWidth = 10;
                    excelChiTietThoiGianLamViec_TongGioTangCaHeader.VerticalAlignment = HorizontalAlignment.Center;
                    excelChiTietThoiGianLamViec_TongGioTangCaHeader.WrapText = true;
                    Excel.Range excelChiTietThoiGianLamViec_TongPhutTreHeader;
                    excelChiTietThoiGianLamViec_TongPhutTreHeader = (ws_ChiTietThoiGianLamViec).get_Range((object)"BR6", (object)"BR8");
                    excelChiTietThoiGianLamViec_TongPhutTreHeader.Cells[1, 1] = "T.Ca x1.5 \n (OV level 1)";
                    excelChiTietThoiGianLamViec_TongPhutTreHeader.get_Range((object)"A1", (object)"A3").MergeCells = true;
                    excelChiTietThoiGianLamViec_TongPhutTreHeader.ColumnWidth = 10;
                    excelChiTietThoiGianLamViec_TongPhutTreHeader.VerticalAlignment = HorizontalAlignment.Center;
                    excelChiTietThoiGianLamViec_TongPhutTreHeader.WrapText = true;
                    Excel.Range excelChiTietThoiGianLamViec_TongPhutSomHeader;
                    excelChiTietThoiGianLamViec_TongPhutSomHeader = (ws_ChiTietThoiGianLamViec).get_Range((object)"BS6", (object)"BS8");
                    excelChiTietThoiGianLamViec_TongPhutSomHeader.Cells[1, 1] = "T.Ca x2 (OV level 2)";
                    excelChiTietThoiGianLamViec_TongPhutSomHeader.get_Range((object)"A1", (object)"A3").MergeCells = true;
                    excelChiTietThoiGianLamViec_TongPhutSomHeader.ColumnWidth = 10;
                    excelChiTietThoiGianLamViec_TongPhutSomHeader.VerticalAlignment = HorizontalAlignment.Center;
                    excelChiTietThoiGianLamViec_TongPhutSomHeader.WrapText = true;
                    Excel.Range excelChiTietThoiGianLamViec_TongPhutSomHeader2;
                    excelChiTietThoiGianLamViec_TongPhutSomHeader2 = (ws_ChiTietThoiGianLamViec).get_Range((object)"BT6", (object)"BT8");
                    excelChiTietThoiGianLamViec_TongPhutSomHeader2.Cells[1, 1] = "Ký Nhận \n (Confirm)";
                    excelChiTietThoiGianLamViec_TongPhutSomHeader2.get_Range((object)"A1", (object)"A3").MergeCells = true;
                    excelChiTietThoiGianLamViec_TongPhutSomHeader2.ColumnWidth = 10;
                    excelChiTietThoiGianLamViec_TongPhutSomHeader2.VerticalAlignment = HorizontalAlignment.Center;
                    excelChiTietThoiGianLamViec_TongPhutSomHeader2.WrapText = true;
                    Excel.Range excelChiTietThoiGianLamViec_DinhDangHeader;
                    excelChiTietThoiGianLamViec_DinhDangHeader = (ws_ChiTietThoiGianLamViec).get_Range((object)"A6", (object)"BT8");
                    excelChiTietThoiGianLamViec_DinhDangHeader.Font.Name = "Times New Roman";
                    excelChiTietThoiGianLamViec_DinhDangHeader.Font.Size = "10";
                    excelChiTietThoiGianLamViec_DinhDangHeader.Font.Bold = true;
                    excelChiTietThoiGianLamViec_DinhDangHeader.HorizontalAlignment = Excel.Constants.xlCenter;
                    excelChiTietThoiGianLamViec_DinhDangHeader.Borders.LineStyle = Excel.Constants.xlBoth;
                    (ws_ChiTietThoiGianLamViec).get_Range((object)"A6", (object)"BT7").Interior.Color = ColorTranslator.ToOle(Color.LightGreen);
                    xla_ChiTietThoiGianLamViec.Visible = true;
                    int iTangHang;
                    iTangHang = 9;
                    int iDemNhanVienChiTietThoiGianLamViec;
                    iDemNhanVienChiTietThoiGianLamViec = 0;
                    int iDemSTTChiTietThoiGianLamViec;
                    iDemSTTChiTietThoiGianLamViec = 0;
                    int iTongDongChiTietThoiGianLamViec;
                    iTongDongChiTietThoiGianLamViec = 9;
                    new DataTable();
                    _tinhCongDTO.Ngay = dNgayBatDauTinhCong;
                    int iMaChamCongChiTietThoiGianLamViec;
                    iMaChamCongChiTietThoiGianLamViec = 0;
                    DataTable dtNhanVienChiTietThoiGianLamViec;
                    dtNhanVienChiTietThoiGianLamViec = _tinhCongBLL.TinhCongGetNgay(_tinhCongDTO);
                    for (int iNhanVienChiTietThoiGianLamViec = 0; iNhanVienChiTietThoiGianLamViec < dtNhanVienChiTietThoiGianLamViec.Rows.Count; iNhanVienChiTietThoiGianLamViec++)
                    {
                        if (Convert.ToInt32(dtNhanVienChiTietThoiGianLamViec.Rows[iNhanVienChiTietThoiGianLamViec]["MaChamCong"].ToString()) == iMaChamCongChiTietThoiGianLamViec)
                        {
                            continue;
                        }
                        iDemSTTChiTietThoiGianLamViec++;
                        iMaChamCongChiTietThoiGianLamViec = Convert.ToInt32(dtNhanVienChiTietThoiGianLamViec.Rows[iNhanVienChiTietThoiGianLamViec]["MaChamCong"].ToString());
                        string sMaNhanVienChiTietThoiGianLamViec;
                        sMaNhanVienChiTietThoiGianLamViec = dtNhanVienChiTietThoiGianLamViec.Rows[iNhanVienChiTietThoiGianLamViec]["MaNhanVien"].ToString();
                        string sTenNhanVienChiTietThoiGianLamViec;
                        sTenNhanVienChiTietThoiGianLamViec = dtNhanVienChiTietThoiGianLamViec.Rows[iNhanVienChiTietThoiGianLamViec]["TenNhanVien"].ToString();
                        Excel.Range excelChiTietThoiGianLamViec_STTDuLieu;
                        excelChiTietThoiGianLamViec_STTDuLieu = (ws_ChiTietThoiGianLamViec).get_Range((object)("A" + (iTongDongChiTietThoiGianLamViec + iDemNhanVienChiTietThoiGianLamViec)), (object)("A" + (iTongDongChiTietThoiGianLamViec + iDemNhanVienChiTietThoiGianLamViec)));
                        excelChiTietThoiGianLamViec_STTDuLieu.Cells[1, 1] = iDemSTTChiTietThoiGianLamViec;
                        excelChiTietThoiGianLamViec_STTDuLieu.Select();
                        Excel.Range excelChiTietThoiGianLamViec_MaNhanVienDuLieu;
                        excelChiTietThoiGianLamViec_MaNhanVienDuLieu = (ws_ChiTietThoiGianLamViec).get_Range((object)("B" + (iTongDongChiTietThoiGianLamViec + iDemNhanVienChiTietThoiGianLamViec)), (object)("B" + (iTongDongChiTietThoiGianLamViec + iDemNhanVienChiTietThoiGianLamViec)));
                        excelChiTietThoiGianLamViec_MaNhanVienDuLieu.get_Range((object)"A1", (object)"A2").NumberFormat = "@";
                        excelChiTietThoiGianLamViec_MaNhanVienDuLieu.Cells[1, 1] = sMaNhanVienChiTietThoiGianLamViec;
                        (ws_ChiTietThoiGianLamViec).get_Range((object)("C" + (iTongDongChiTietThoiGianLamViec + iDemNhanVienChiTietThoiGianLamViec)), (object)("C" + (iTongDongChiTietThoiGianLamViec + iDemNhanVienChiTietThoiGianLamViec))).Cells[1, 1] = sTenNhanVienChiTietThoiGianLamViec;
                        string sTenPhongBan;
                        sTenPhongBan = "";
                        new DataTable();
                        _phongBanDTO.MaPhongBan = dtNhanVienChiTietThoiGianLamViec.Rows[iNhanVienChiTietThoiGianLamViec]["PhongBan"].ToString();
                        DataTable dtPhongBan;
                        dtPhongBan = _phongBanBLL.getTenPhongBanByMaPhongBan(_phongBanDTO);
                        for (int iPhongBan = 0; iPhongBan < dtPhongBan.Rows.Count; iPhongBan++)
                        {
                            sTenPhongBan = dtPhongBan.Rows[iPhongBan]["TenPhongBan"].ToString();
                        }
                        Excel.Range excelChiTietThoiGianLamViec_PhongBanDuLieu;
                        excelChiTietThoiGianLamViec_PhongBanDuLieu = (ws_ChiTietThoiGianLamViec).get_Range((object)("D" + (iTongDongChiTietThoiGianLamViec + iDemNhanVienChiTietThoiGianLamViec)), (object)("D" + (iTongDongChiTietThoiGianLamViec + iDemNhanVienChiTietThoiGianLamViec)));
                        if (sTenPhongBan == "")
                        {
                            excelChiTietThoiGianLamViec_PhongBanDuLieu.Cells[1, 1] = "------";
                        }
                        else
                        {
                            excelChiTietThoiGianLamViec_PhongBanDuLieu.Cells[1, 1] = sTenPhongBan;
                        }
                        int iDemNgayChiTietThoiGianLamViec;
                        iDemNgayChiTietThoiGianLamViec = 0;
                        int iCotGioVao;
                        iCotGioVao = 1;
                        int iCotGioRa;
                        iCotGioRa = 2;
                        int iTangCot;
                        iTangCot = 5;
                        for (int iGioChamChiTietThoiGianLamViec = 0; iGioChamChiTietThoiGianLamViec < 31; iGioChamChiTietThoiGianLamViec++)
                        {
                            DateTime dNgayChiTietThoiGianLamViec;
                            dNgayChiTietThoiGianLamViec = Convert.ToDateTime(dNgayBatDauTinhCong.AddDays(iDemNgayChiTietThoiGianLamViec).ToString());
                            new DataTable();
                            _tinhCongDTO.MaChamCong = iMaChamCongChiTietThoiGianLamViec;
                            _tinhCongDTO.Ngay = dNgayChiTietThoiGianLamViec;
                            DataTable dtDuLieuGioChiTietThoiGianLamViec;
                            dtDuLieuGioChiTietThoiGianLamViec = _tinhCongBLL.TinhCongGetMaChamCongAndNgay(_tinhCongDTO);
                            int iDuLieuGioChiTietThoiGianLamViec;
                            iDuLieuGioChiTietThoiGianLamViec = 0;
                            if (iDuLieuGioChiTietThoiGianLamViec < dtDuLieuGioChiTietThoiGianLamViec.Rows.Count)
                            {
                                string sThu;
                                sThu = dtDuLieuGioChiTietThoiGianLamViec.Rows[iDuLieuGioChiTietThoiGianLamViec]["Thu"].ToString();
                                string sGioVaoChiTietThoiGianLamViec;
                                sGioVaoChiTietThoiGianLamViec = dtDuLieuGioChiTietThoiGianLamViec.Rows[iDuLieuGioChiTietThoiGianLamViec]["GioVao"].ToString();
                                string sGioRaChiTietThoiGianLamViec;
                                sGioRaChiTietThoiGianLamViec = dtDuLieuGioChiTietThoiGianLamViec.Rows[iDuLieuGioChiTietThoiGianLamViec]["GioRa"].ToString();
                                double dGioTungNgayChiTietThoiGianLamViec;
                                dGioTungNgayChiTietThoiGianLamViec = Convert.ToDouble(dtDuLieuGioChiTietThoiGianLamViec.Rows[iDuLieuGioChiTietThoiGianLamViec]["Gio"].ToString());
                                double dTongGioTangCaNgayChiTietThoiGianLamViec;
                                dTongGioTangCaNgayChiTietThoiGianLamViec = Convert.ToDouble(dtDuLieuGioChiTietThoiGianLamViec.Rows[iDuLieuGioChiTietThoiGianLamViec]["TC1"]) + Convert.ToDouble(dtDuLieuGioChiTietThoiGianLamViec.Rows[iDuLieuGioChiTietThoiGianLamViec]["TC2"]);
                                string sKyHieu;
                                sKyHieu = dtDuLieuGioChiTietThoiGianLamViec.Rows[iDuLieuGioChiTietThoiGianLamViec]["KyHieu"].ToString();
                                if (sGioVaoChiTietThoiGianLamViec != "")
                                {
                                    DateTime dGioVao;
                                    dGioVao = Convert.ToDateTime(sGioVaoChiTietThoiGianLamViec);
                                    _ = dGioVao.Hour + ":" + dGioVao.Minute;
                                }
                                if (sGioRaChiTietThoiGianLamViec != "")
                                {
                                    DateTime dGioRa;
                                    dGioRa = Convert.ToDateTime(sGioRaChiTietThoiGianLamViec);
                                    _ = dGioRa.Hour + ":" + dGioRa.Minute;
                                }
                                Excel.Range excelChiTietThoiGianLamViec_GioVaoDuLieu;
                                excelChiTietThoiGianLamViec_GioVaoDuLieu = (ws_ChiTietThoiGianLamViec).get_Range((object)("E" + (iTongDongChiTietThoiGianLamViec + iDemNhanVienChiTietThoiGianLamViec)), (object)("BN" + (iTongDongChiTietThoiGianLamViec + iDemNhanVienChiTietThoiGianLamViec)));
                                excelChiTietThoiGianLamViec_GioVaoDuLieu.Cells[1, iCotGioVao] = dGioTungNgayChiTietThoiGianLamViec;
                                Excel.Range excelChiTietThoiGianLamViec_GioRaDuLieu;
                                excelChiTietThoiGianLamViec_GioRaDuLieu = (ws_ChiTietThoiGianLamViec).get_Range((object)("E" + (iTongDongChiTietThoiGianLamViec + iDemNhanVienChiTietThoiGianLamViec)), (object)("BN" + (iTongDongChiTietThoiGianLamViec + iDemNhanVienChiTietThoiGianLamViec)));
                                excelChiTietThoiGianLamViec_GioRaDuLieu.Cells[1, iCotGioRa] = dTongGioTangCaNgayChiTietThoiGianLamViec;
                                if (dTongGioTangCaNgayChiTietThoiGianLamViec > 0.0)
                                {
                                    excelChiTietThoiGianLamViec_GioRaDuLieu.Cells[1, iCotGioRa] = dTongGioTangCaNgayChiTietThoiGianLamViec;
                                }
                                else
                                {
                                    excelChiTietThoiGianLamViec_GioRaDuLieu.Cells[1, iCotGioRa] = "";
                                }
                                if (sKyHieu != "X" && sKyHieu != "V")
                                {
                                    excelChiTietThoiGianLamViec_GioVaoDuLieu.Cells[1, iCotGioVao] = sKyHieu;
                                    excelChiTietThoiGianLamViec_GioRaDuLieu.Cells[1, iCotGioRa] = "";
                                }
                                else
                                {
                                    if (sKyHieu == "V" && dTongGioTangCaNgayChiTietThoiGianLamViec > 0.0)
                                    {
                                        excelChiTietThoiGianLamViec_GioVaoDuLieu.Cells[1, iCotGioVao] = "";
                                        excelChiTietThoiGianLamViec_GioRaDuLieu.Cells[1, iCotGioRa] = dTongGioTangCaNgayChiTietThoiGianLamViec;
                                    }
                                    if (sKyHieu == "V" && dTongGioTangCaNgayChiTietThoiGianLamViec == 0.0)
                                    {
                                        if (sThu == "CN")
                                        {
                                            excelChiTietThoiGianLamViec_GioVaoDuLieu.Cells[1, iCotGioVao] = "";
                                            excelChiTietThoiGianLamViec_GioRaDuLieu.Cells[1, iCotGioRa] = "";
                                        }
                                        else
                                        {
                                            excelChiTietThoiGianLamViec_GioVaoDuLieu.Cells[1, iCotGioVao] = "KP";
                                            excelChiTietThoiGianLamViec_GioRaDuLieu.Cells[1, iCotGioRa] = "";
                                        }
                                    }
                                }
                                if (sThu == "CN")
                                {
                                    Excel.Range fuckVisual4;
                                    fuckVisual4 = (ws_ChiTietThoiGianLamViec).get_Range(ws_ChiTietThoiGianLamViec.Cells[iTangHang, iTangCot], ws_ChiTietThoiGianLamViec.Cells[iTangHang, iTangCot]);
                                    Excel.Range fuckVisual5;
                                    fuckVisual5 = (ws_ChiTietThoiGianLamViec).get_Range(ws_ChiTietThoiGianLamViec.Cells[iTangHang, iTangCot + 1], ws_ChiTietThoiGianLamViec.Cells[iTangHang, iTangCot + 1]);
                                    fuckVisual4.Interior.Color = ColorTranslator.ToOle(Color.Aqua);
                                    fuckVisual5.Interior.Color = ColorTranslator.ToOle(Color.Aqua);
                                }
                            }
                            iCotGioVao = iCotGioVao + 1 + 1;
                            iCotGioRa = iCotGioRa + 1 + 1;
                            iDemNgayChiTietThoiGianLamViec++;
                            iTangCot = iTangCot + 1 + 1;
                        }
                        int iDemPhepNamThongKeThangKyHieu;
                        iDemPhepNamThongKeThangKyHieu = 0;
                        int iDemLe;
                        iDemLe = 0;
                        int iDemCN;
                        iDemCN = 0;
                        double dTongGio;
                        dTongGio = 0.0;
                        double dTongNgayCongThongKeThangKyHieu;
                        dTongNgayCongThongKeThangKyHieu = 0.0;
                        double dTongGioTC1ThongKeThangKyHieu;
                        dTongGioTC1ThongKeThangKyHieu = 0.0;
                        double dTongGioTC2ThongKeThangKyHieu;
                        dTongGioTC2ThongKeThangKyHieu = 0.0;
                        new DataTable();
                        _tinhCongDTO.MaChamCong = iMaChamCongChiTietThoiGianLamViec;
                        DataTable dtChiTietThoiGianLamViec;
                        dtChiTietThoiGianLamViec = _tinhCongBLL.TinhCongGetByMaChamCong(_tinhCongDTO);
                        for (int iChiTietThoiGianLamViec = 0; iChiTietThoiGianLamViec < dtChiTietThoiGianLamViec.Rows.Count; iChiTietThoiGianLamViec++)
                        {
                            if (dtChiTietThoiGianLamViec.Rows[iChiTietThoiGianLamViec]["Gio"].ToString() != "")
                            {
                                dTongGio += Convert.ToDouble(dtChiTietThoiGianLamViec.Rows[iChiTietThoiGianLamViec]["Gio"].ToString());
                            }
                            if (dtChiTietThoiGianLamViec.Rows[iChiTietThoiGianLamViec]["Cong"].ToString() != "")
                            {
                                dTongNgayCongThongKeThangKyHieu += Convert.ToDouble(dtChiTietThoiGianLamViec.Rows[iChiTietThoiGianLamViec]["Cong"].ToString());
                            }
                            if (dtChiTietThoiGianLamViec.Rows[iChiTietThoiGianLamViec]["TC1"].ToString() != "")
                            {
                                dTongGioTC1ThongKeThangKyHieu += Convert.ToDouble(dtChiTietThoiGianLamViec.Rows[iChiTietThoiGianLamViec]["TC1"].ToString());
                            }
                            if (dtChiTietThoiGianLamViec.Rows[iChiTietThoiGianLamViec]["TC2"].ToString() != "")
                            {
                                dTongGioTC2ThongKeThangKyHieu += Convert.ToDouble(dtChiTietThoiGianLamViec.Rows[iChiTietThoiGianLamViec]["TC2"].ToString());
                            }
                            string sKyHieuDuLieuThongKeThang;
                            sKyHieuDuLieuThongKeThang = dtChiTietThoiGianLamViec.Rows[iChiTietThoiGianLamViec]["KyHieu"].ToString();
                            if (sKyHieuDuLieuThongKeThang == sKHPhepNam)
                            {
                                iDemPhepNamThongKeThangKyHieu++;
                            }
                            if (sKyHieuDuLieuThongKeThang == "L")
                            {
                                iDemLe++;
                            }
                            if (dtChiTietThoiGianLamViec.Rows[iChiTietThoiGianLamViec]["KyHieuPhu"].ToString() == "CN")
                            {
                                iDemCN++;
                            }
                        }
                        (ws_ChiTietThoiGianLamViec).get_Range((object)("BO" + (iTongDongChiTietThoiGianLamViec + iDemNhanVienChiTietThoiGianLamViec)), (object)("BO" + (iTongDongChiTietThoiGianLamViec + iDemNhanVienChiTietThoiGianLamViec) + 1)).Cells[1, 1] = dTongNgayCongThongKeThangKyHieu;
                        (ws_ChiTietThoiGianLamViec).get_Range((object)("BP" + (iTongDongChiTietThoiGianLamViec + iDemNhanVienChiTietThoiGianLamViec)), (object)("BP" + (iTongDongChiTietThoiGianLamViec + iDemNhanVienChiTietThoiGianLamViec) + 1)).Cells[1, 1] = iDemPhepNamThongKeThangKyHieu;
                        (ws_ChiTietThoiGianLamViec).get_Range((object)("BQ" + (iTongDongChiTietThoiGianLamViec + iDemNhanVienChiTietThoiGianLamViec)), (object)("BQ" + (iTongDongChiTietThoiGianLamViec + iDemNhanVienChiTietThoiGianLamViec) + 1)).Cells[1, 1] = iDemLe;
                        (ws_ChiTietThoiGianLamViec).get_Range((object)("BR" + (iTongDongChiTietThoiGianLamViec + iDemNhanVienChiTietThoiGianLamViec)), (object)("BR" + (iTongDongChiTietThoiGianLamViec + iDemNhanVienChiTietThoiGianLamViec) + 1)).Cells[1, 1] = dTongGioTC1ThongKeThangKyHieu;
                        (ws_ChiTietThoiGianLamViec).get_Range((object)("BS" + (iTongDongChiTietThoiGianLamViec + iDemNhanVienChiTietThoiGianLamViec)), (object)("BS" + (iTongDongChiTietThoiGianLamViec + iDemNhanVienChiTietThoiGianLamViec) + 1)).Cells[1, 1] = dTongGioTC2ThongKeThangKyHieu;
                        (ws_ChiTietThoiGianLamViec).get_Range((object)("BT" + (iTongDongChiTietThoiGianLamViec + iDemNhanVienChiTietThoiGianLamViec)), (object)("BT" + (iTongDongChiTietThoiGianLamViec + iDemNhanVienChiTietThoiGianLamViec) + 1)).Cells[1, 1] = "";
                        iDemNhanVienChiTietThoiGianLamViec++;
                        iTangHang++;
                    }
                    Excel.Range excelChiTietThoiGianLamViec_DinhDangDuLieu;
                    excelChiTietThoiGianLamViec_DinhDangDuLieu = (ws_ChiTietThoiGianLamViec).get_Range((object)"A9", (object)("BT" + (iTongDongChiTietThoiGianLamViec + iDemNhanVienChiTietThoiGianLamViec - 1)));
                    excelChiTietThoiGianLamViec_DinhDangDuLieu.Font.Name = "Times New Roman";
                    excelChiTietThoiGianLamViec_DinhDangDuLieu.Font.Size = "8";
                    excelChiTietThoiGianLamViec_DinhDangDuLieu.HorizontalAlignment = Excel.Constants.xlCenter;
                    excelChiTietThoiGianLamViec_DinhDangDuLieu.Borders.LineStyle = Excel.Constants.xlBoth;
                    Excel.Range excelThongKeThangKyHieu_PhongBan11111;
                    excelThongKeThangKyHieu_PhongBan11111 = (ws_ChiTietThoiGianLamViec).get_Range((object)("E" + (iTongDongChiTietThoiGianLamViec + iDemNhanVienChiTietThoiGianLamViec + 2)), (object)("E" + (iTongDongChiTietThoiGianLamViec + iDemNhanVienChiTietThoiGianLamViec) + 2));
                    excelThongKeThangKyHieu_PhongBan11111.Cells[1, 1] = "Ghi Chú: N: Tổng giờ làm được trong ca";
                    excelThongKeThangKyHieu_PhongBan11111.Font.Name = "Times New Roman";
                    excelThongKeThangKyHieu_PhongBan11111.Font.Size = "10";
                    excelThongKeThangKyHieu_PhongBan11111.Font.Bold = true;
                    Excel.Range excelThongKeThangKyHieu_PhongBan11112;
                    excelThongKeThangKyHieu_PhongBan11112 = (ws_ChiTietThoiGianLamViec).get_Range((object)("E" + (iTongDongChiTietThoiGianLamViec + iDemNhanVienChiTietThoiGianLamViec + 3)), (object)("E" + (iTongDongChiTietThoiGianLamViec + iDemNhanVienChiTietThoiGianLamViec) + 3));
                    excelThongKeThangKyHieu_PhongBan11112.Cells[1, 1] = "O:Tổng giờ tăng ca làm được";
                    excelThongKeThangKyHieu_PhongBan11112.Font.Name = "Times New Roman";
                    excelThongKeThangKyHieu_PhongBan11112.Font.Size = "10";
                    excelThongKeThangKyHieu_PhongBan11112.Font.Bold = true;
                    Excel.Range excelThongKeThangKyHieu_PhongBan11113;
                    excelThongKeThangKyHieu_PhongBan11113 = (ws_ChiTietThoiGianLamViec).get_Range((object)("E" + (iTongDongChiTietThoiGianLamViec + iDemNhanVienChiTietThoiGianLamViec + 4)), (object)("E" + (iTongDongChiTietThoiGianLamViec + iDemNhanVienChiTietThoiGianLamViec) + 4));
                    excelThongKeThangKyHieu_PhongBan11113.Cells[1, 1] = "KP:Nghỉ ko phép";
                    excelThongKeThangKyHieu_PhongBan11113.Font.Name = "Times New Roman";
                    excelThongKeThangKyHieu_PhongBan11113.Font.Size = "10";
                    excelThongKeThangKyHieu_PhongBan11113.Font.Bold = true;
                    Excel.Range excelThongKeThangKyHieu_PhongBan11114;
                    excelThongKeThangKyHieu_PhongBan11114 = (ws_ChiTietThoiGianLamViec).get_Range((object)("E" + (iTongDongChiTietThoiGianLamViec + iDemNhanVienChiTietThoiGianLamViec + 5)), (object)("E" + (iTongDongChiTietThoiGianLamViec + iDemNhanVienChiTietThoiGianLamViec) + 5));
                    excelThongKeThangKyHieu_PhongBan11114.Cells[1, 1] = "Các loại phép được khai báo từ phần mềm: P,PB,R,PN,OM,TS,CO";
                    excelThongKeThangKyHieu_PhongBan11114.Font.Name = "Times New Roman";
                    excelThongKeThangKyHieu_PhongBan11114.Font.Size = "10";
                    excelThongKeThangKyHieu_PhongBan11114.Font.Bold = true;
                }
                catch (COMException)
                {
                    failed = true;
                }
                Thread.Sleep(10);
            }
            while (failed);
        }

        private void ThongKeGioVaTC()
        {
            DateTime dNgayTinh;
            dNgayTinh = Convert.ToDateTime(dateTimeTuNgay.Text);
            DateTime dNgayBatDauTinhCong;
            dNgayBatDauTinhCong = new DateTime(dNgayTinh.Year, dNgayTinh.Month, dNgayTinh.Day, 0, 0, 0);
            _ = Thread.CurrentThread.CurrentCulture;
            Thread.CurrentThread.CurrentCulture = new CultureInfo("en-US");
            Excel.Application xla_ThongKeThang_KyHieu;
            xla_ThongKeThang_KyHieu = new Excel.Application();
            xla_ThongKeThang_KyHieu.Workbooks.Add(Excel.XlSheetType.xlWorksheet);
            _ = xla_ThongKeThang_KyHieu.ActiveSheet;
            Excel.Worksheet ws_ThongKeThang_KyHieu;
            ws_ThongKeThang_KyHieu = xla_ThongKeThang_KyHieu.Worksheets.get_Item((object)1);
            bool failed;
            failed = false;
            do
            {
                try
                {
                    Excel.Range excelThongKeThangKyHieu_TenCongTy;
                    excelThongKeThangKyHieu_TenCongTy = (ws_ThongKeThang_KyHieu).get_Range((object)"A1", (object)"AT1");
                    excelThongKeThangKyHieu_TenCongTy.Select();
                    excelThongKeThangKyHieu_TenCongTy.Cells[1, 1] = "Công ty: " + sTenCongTyReport;
                    excelThongKeThangKyHieu_TenCongTy.get_Range((object)"A1", (object)"AT1").Merge(true);
                    Excel.Range excelThongKeThangKyHieu_DiaChiCongTy;
                    excelThongKeThangKyHieu_DiaChiCongTy = (ws_ThongKeThang_KyHieu).get_Range((object)"A2", (object)"AT2");
                    excelThongKeThangKyHieu_DiaChiCongTy.Cells[1, 1] = "Địa chỉ: " + sDiaChiCongTyReport;
                    excelThongKeThangKyHieu_DiaChiCongTy.get_Range((object)"A1", (object)"AT1").Merge(true);
                    Excel.Range excelThongKeThangKyHieu_TieuDe;
                    excelThongKeThangKyHieu_TieuDe = (ws_ThongKeThang_KyHieu).get_Range((object)"A4", (object)"AT4");
                    excelThongKeThangKyHieu_TieuDe.Cells[1, 1] = "BẢNG THỐNG KÊ CHẤM CÔNG CHI TIẾT TỪ NGÀY " + dateTimeTuNgay.Text + " ĐẾN NGÀY  " + dateTimeDenNgay.Text;
                    excelThongKeThangKyHieu_TieuDe.get_Range((object)"A1", (object)"AT1").Merge(true);
                    excelThongKeThangKyHieu_TieuDe.Font.Name = "Times New Roman";
                    excelThongKeThangKyHieu_TieuDe.Font.Size = "16";
                    excelThongKeThangKyHieu_TieuDe.Font.Bold = true;
                    excelThongKeThangKyHieu_TieuDe.RowHeight = "24";
                    excelThongKeThangKyHieu_TieuDe.HorizontalAlignment = Excel.Constants.xlCenter;
                    Excel.Range excelThongKeThangKyHieu_STT;
                    excelThongKeThangKyHieu_STT = (ws_ThongKeThang_KyHieu).get_Range((object)"A5", (object)"A6");
                    excelThongKeThangKyHieu_STT.Cells[1, 1] = "STT";
                    excelThongKeThangKyHieu_STT.get_Range((object)"A1", (object)"A2").MergeCells = true;
                    excelThongKeThangKyHieu_STT.ColumnWidth = 4;
                    Excel.Range excelThongKeThangKyHieu_PhongBan;
                    excelThongKeThangKyHieu_PhongBan = (ws_ThongKeThang_KyHieu).get_Range((object)"B5", (object)"B6");
                    excelThongKeThangKyHieu_PhongBan.Cells[1, 1] = "MÃ NHÂN VIÊN";
                    excelThongKeThangKyHieu_PhongBan.get_Range((object)"A1", (object)"A2").MergeCells = true;
                    excelThongKeThangKyHieu_PhongBan.ColumnWidth = 13;
                    Excel.Range excelThongKeThangKyHieu_MaSoNhanVien;
                    excelThongKeThangKyHieu_MaSoNhanVien = (ws_ThongKeThang_KyHieu).get_Range((object)"C5", (object)"C6");
                    excelThongKeThangKyHieu_MaSoNhanVien.Cells[1, 1] = "TÊN NHÂN VIÊN";
                    excelThongKeThangKyHieu_MaSoNhanVien.get_Range((object)"A1", (object)"A2").MergeCells = true;
                    excelThongKeThangKyHieu_MaSoNhanVien.ColumnWidth = 13;
                    Excel.Range excelThongKeThangKyHieu_TenNhanVien;
                    excelThongKeThangKyHieu_TenNhanVien = (ws_ThongKeThang_KyHieu).get_Range((object)"D5", (object)"D6");
                    excelThongKeThangKyHieu_TenNhanVien.Cells[1, 1] = "PHÒNG BAN";
                    excelThongKeThangKyHieu_TenNhanVien.get_Range((object)"A1", (object)"A2").MergeCells = true;
                    excelThongKeThangKyHieu_TenNhanVien.ColumnWidth = 11;
                    int ColunmNgay;
                    ColunmNgay = 6;
                    for (int iThongKe_KyHieu = 0; iThongKe_KyHieu < 31; iThongKe_KyHieu++)
                    {
                        DateTime dtNgayChamThongKeKyHieu;
                        dtNgayChamThongKeKyHieu = dateTimeTuNgay.Value;
                        int iNgayChamThongKeKyHieu;
                        iNgayChamThongKeKyHieu = Convert.ToInt32(Convert.ToDateTime(dtNgayChamThongKeKyHieu.AddDays(iThongKe_KyHieu).ToString()).Day);
                        Excel.Range excelThongKeThangKyHieu_Ngay;
                        excelThongKeThangKyHieu_Ngay = (ws_ThongKeThang_KyHieu).get_Range((object)"F5", (object)"AJ6");
                        xla_ThongKeThang_KyHieu.Cells[5, ColunmNgay] = iNgayChamThongKeKyHieu;
                        xla_ThongKeThang_KyHieu.Cells[6, ColunmNgay] = DateTimeProgress.XuatThuReport((int)dtNgayChamThongKeKyHieu.AddDays(iThongKe_KyHieu).DayOfWeek);
                        ColunmNgay++;
                        excelThongKeThangKyHieu_Ngay.ColumnWidth = 5;
                    }
                    Excel.Range excelThongKeThangKyHieu_NgayCong;
                    excelThongKeThangKyHieu_NgayCong = (ws_ThongKeThang_KyHieu).get_Range((object)"AK5", (object)"AK6");
                    excelThongKeThangKyHieu_NgayCong.Cells[1, 1] = "GIỜ CÔNG";
                    excelThongKeThangKyHieu_NgayCong.get_Range((object)"A1", (object)"A2").MergeCells = true;
                    Excel.Range excelThongKeThangKyHieu_TangCa;
                    excelThongKeThangKyHieu_TangCa = (ws_ThongKeThang_KyHieu).get_Range((object)"AL5", (object)"AO5");
                    excelThongKeThangKyHieu_TangCa.Cells[1, 1] = "TĂNG CA";
                    excelThongKeThangKyHieu_TangCa.get_Range((object)"A1", (object)"D1").Merge(true);
                    int ColumTangCa;
                    ColumTangCa = 38;
                    for (int iThongKeKyHieu_TangCa = 1; iThongKeKyHieu_TangCa < 5; iThongKeKyHieu_TangCa++)
                    {
                        Excel.Range excelThongKeThangKyHieu_ChiTietTangCa;
                        excelThongKeThangKyHieu_ChiTietTangCa = (ws_ThongKeThang_KyHieu).get_Range((object)"AL6", (object)"AO6");
                        xla_ThongKeThang_KyHieu.Cells[6, ColumTangCa] = "TC " + iThongKeKyHieu_TangCa;
                        ColumTangCa++;
                        excelThongKeThangKyHieu_ChiTietTangCa.ColumnWidth = 5;
                    }
                    Excel.Range excelThongKeThangKyHieu_Vang;
                    excelThongKeThangKyHieu_Vang = (ws_ThongKeThang_KyHieu).get_Range((object)"AP5", (object)"AP6");
                    excelThongKeThangKyHieu_Vang.Cells[1, 1] = "V";
                    excelThongKeThangKyHieu_Vang.get_Range((object)"A1", (object)"A2").MergeCells = true;
                    excelThongKeThangKyHieu_Vang.ColumnWidth = 5;
                    Excel.Range excelThongKeThangKyHieu_PhepNam;
                    excelThongKeThangKyHieu_PhepNam = (ws_ThongKeThang_KyHieu).get_Range((object)"AQ5", (object)"AQ6");
                    excelThongKeThangKyHieu_PhepNam.Cells[1, 1] = "PN";
                    excelThongKeThangKyHieu_PhepNam.get_Range((object)"A1", (object)"A2").MergeCells = true;
                    excelThongKeThangKyHieu_PhepNam.ColumnWidth = 5;
                    Excel.Range excelThongKeThangKyHieu_CheDo;
                    excelThongKeThangKyHieu_CheDo = (ws_ThongKeThang_KyHieu).get_Range((object)"AR5", (object)"AR6");
                    excelThongKeThangKyHieu_CheDo.Cells[1, 1] = "CĐ";
                    excelThongKeThangKyHieu_CheDo.get_Range((object)"A1", (object)"A2").MergeCells = true;
                    excelThongKeThangKyHieu_CheDo.ColumnWidth = 5;
                    Excel.Range excelThongKeThangKyHieu_Tre;
                    excelThongKeThangKyHieu_Tre = (ws_ThongKeThang_KyHieu).get_Range((object)"AS5", (object)"AS6");
                    excelThongKeThangKyHieu_Tre.Cells[1, 1] = "Trễ";
                    excelThongKeThangKyHieu_Tre.get_Range((object)"A1", (object)"A2").MergeCells = true;
                    excelThongKeThangKyHieu_Tre.ColumnWidth = 5;
                    Excel.Range excelThongKeThangKyHieu_Som;
                    excelThongKeThangKyHieu_Som = (ws_ThongKeThang_KyHieu).get_Range((object)"AT5", (object)"AT6");
                    excelThongKeThangKyHieu_Som.Cells[1, 1] = "Sớm";
                    excelThongKeThangKyHieu_Som.get_Range((object)"A1", (object)"A2").MergeCells = true;
                    excelThongKeThangKyHieu_Som.ColumnWidth = 5;
                    Excel.Range excelThongKeThangKyHieu_Total;
                    excelThongKeThangKyHieu_Total = (ws_ThongKeThang_KyHieu).get_Range((object)"A5", (object)"AT6");
                    excelThongKeThangKyHieu_Total.Font.Name = "Times New Roman";
                    excelThongKeThangKyHieu_Total.Font.Size = "10";
                    excelThongKeThangKyHieu_Total.Font.Bold = true;
                    excelThongKeThangKyHieu_Total.HorizontalAlignment = Excel.Constants.xlCenter;
                    excelThongKeThangKyHieu_Total.Interior.ColorIndex = 33;
                    xla_ThongKeThang_KyHieu.Visible = true;
                    int iDemDongThongKeThangKyHieu;
                    iDemDongThongKeThangKyHieu = 7;
                    int iDemTangCa;
                    iDemTangCa = 8;
                    new DataTable();
                    DataTable dtNgayTinhCongThongKeThangKyHieu;
                    dtNgayTinhCongThongKeThangKyHieu = _ngayTinhCongBLL.showThongTinNgayTinhCong();
                    for (int iNgayTinhCongThongKeThangKyHieu = 0; iNgayTinhCongThongKeThangKyHieu < dtNgayTinhCongThongKeThangKyHieu.Rows.Count; iNgayTinhCongThongKeThangKyHieu++)
                    {
                        int iSTTThongKeThangKyHieu;
                        iSTTThongKeThangKyHieu = 1;
                        int iMaChamCongThongKeThangKyHieu;
                        iMaChamCongThongKeThangKyHieu = 0;
                        DateTime dNgayBatDauTinhCongThongKeThangKyHieu;
                        dNgayBatDauTinhCongThongKeThangKyHieu = Convert.ToDateTime(dtNgayTinhCongThongKeThangKyHieu.Rows[iNgayTinhCongThongKeThangKyHieu]["NgayBatDau"].ToString());
                        int iTongNgayTinhCongThongKeThangKyHieu;
                        iTongNgayTinhCongThongKeThangKyHieu = Convert.ToInt32((Convert.ToDateTime(dtNgayTinhCongThongKeThangKyHieu.Rows[iNgayTinhCongThongKeThangKyHieu]["NgayKetThuc"].ToString()) - dNgayBatDauTinhCongThongKeThangKyHieu).TotalDays);
                        new DataTable();
                        _tinhCongDTO.Ngay = dNgayBatDauTinhCong;
                        DataTable dtTinhCongThongKeThangKyHieu;
                        dtTinhCongThongKeThangKyHieu = _tinhCongBLL.TinhCongGetNgay(_tinhCongDTO);
                        for (int iTinhCongThongKeThangKyHieu = 0; iTinhCongThongKeThangKyHieu < dtTinhCongThongKeThangKyHieu.Rows.Count; iTinhCongThongKeThangKyHieu++)
                        {
                            int iDemCotThongKeThangKyHieu;
                            iDemCotThongKeThangKyHieu = 1;
                            if (Convert.ToInt32(dtTinhCongThongKeThangKyHieu.Rows[iTinhCongThongKeThangKyHieu]["MaChamCong"].ToString()) == iMaChamCongThongKeThangKyHieu)
                            {
                                continue;
                            }
                            iMaChamCongThongKeThangKyHieu = Convert.ToInt32(dtTinhCongThongKeThangKyHieu.Rows[iTinhCongThongKeThangKyHieu]["MaChamCong"].ToString());
                            Excel.Range excelThongKeThangKyHieu_STTDuLieu;
                            excelThongKeThangKyHieu_STTDuLieu = (ws_ThongKeThang_KyHieu).get_Range((object)("A" + iDemDongThongKeThangKyHieu), (object)("A" + iDemDongThongKeThangKyHieu));
                            excelThongKeThangKyHieu_STTDuLieu.Cells[1, 1] = iSTTThongKeThangKyHieu.ToString();
                            excelThongKeThangKyHieu_STTDuLieu.get_Range((object)"A1", (object)"A2").MergeCells = true;
                            excelThongKeThangKyHieu_STTDuLieu.Select();
                            string sTenPhongBan;
                            sTenPhongBan = "";
                            new DataTable();
                            _phongBanDTO.MaPhongBan = dtTinhCongThongKeThangKyHieu.Rows[iTinhCongThongKeThangKyHieu]["PhongBan"].ToString();
                            DataTable dtPhongBan;
                            dtPhongBan = _phongBanBLL.getTenPhongBanByMaPhongBan(_phongBanDTO);
                            for (int iPhongBan = 0; iPhongBan < dtPhongBan.Rows.Count; iPhongBan++)
                            {
                                sTenPhongBan = dtPhongBan.Rows[iPhongBan]["TenPhongBan"].ToString();
                            }
                            Excel.Range excelThongKeThangKyHieu_PhongBanDuLieu;
                            excelThongKeThangKyHieu_PhongBanDuLieu = (ws_ThongKeThang_KyHieu).get_Range((object)("D" + iDemDongThongKeThangKyHieu), (object)("D" + iDemDongThongKeThangKyHieu));
                            excelThongKeThangKyHieu_PhongBanDuLieu.get_Range((object)"A1", (object)"A2").MergeCells = true;
                            if (sTenPhongBan == "")
                            {
                                excelThongKeThangKyHieu_PhongBanDuLieu.Cells[1, 1] = "------";
                            }
                            else
                            {
                                excelThongKeThangKyHieu_PhongBanDuLieu.Cells[1, 1] = sTenPhongBan;
                            }
                            Excel.Range excelThongKeThangKyHieu_PhongBan2DuLieu;
                            excelThongKeThangKyHieu_PhongBan2DuLieu = (ws_ThongKeThang_KyHieu).get_Range((object)("D" + iDemTangCa), (object)("D" + iDemTangCa));
                            if (sTenPhongBan == "")
                            {
                                excelThongKeThangKyHieu_PhongBan2DuLieu.Cells[1, 1] = "------";
                            }
                            else
                            {
                                excelThongKeThangKyHieu_PhongBan2DuLieu.Cells[1, 1] = sTenPhongBan;
                            }
                            Excel.Range excelThongKeThangKyHieu_MaNhanVienDuLieu;
                            excelThongKeThangKyHieu_MaNhanVienDuLieu = (ws_ThongKeThang_KyHieu).get_Range((object)("B" + iDemDongThongKeThangKyHieu), (object)("B" + iDemDongThongKeThangKyHieu));
                            excelThongKeThangKyHieu_MaNhanVienDuLieu.get_Range((object)"A1", (object)"A1").NumberFormat = "@";
                            excelThongKeThangKyHieu_MaNhanVienDuLieu.get_Range((object)"A1", (object)"A2").MergeCells = true;
                            excelThongKeThangKyHieu_MaNhanVienDuLieu.Cells[1, 1] = dtTinhCongThongKeThangKyHieu.Rows[iTinhCongThongKeThangKyHieu]["MaNhanVien"].ToString();
                            Excel.Range excelThongKeThangKyHieu_TenNhanVienDuLieu;
                            excelThongKeThangKyHieu_TenNhanVienDuLieu = (ws_ThongKeThang_KyHieu).get_Range((object)("C" + iDemDongThongKeThangKyHieu), (object)("C" + iDemDongThongKeThangKyHieu));
                            excelThongKeThangKyHieu_TenNhanVienDuLieu.Cells[1, 1] = dtTinhCongThongKeThangKyHieu.Rows[iTinhCongThongKeThangKyHieu]["TenNhanVien"].ToString();
                            excelThongKeThangKyHieu_TenNhanVienDuLieu.get_Range((object)"A1", (object)"A2").MergeCells = true;
                            (ws_ThongKeThang_KyHieu).get_Range((object)("E" + iDemDongThongKeThangKyHieu), (object)("E" + iDemDongThongKeThangKyHieu))[1, 1] = "HC";
                            (ws_ThongKeThang_KyHieu).get_Range((object)("E" + iDemTangCa), (object)("E" + iDemTangCa))[1, 1] = "TC";
                            string sGio;
                            sGio = "";
                            double dTangCa;
                            dTangCa = 0.0;
                            double dTangCa2;
                            dTangCa2 = 0.0;
                            for (int iThongKeThangKyHieu_NgayDuLieu = 0; iThongKeThangKyHieu_NgayDuLieu <= iTongNgayTinhCongThongKeThangKyHieu; iThongKeThangKyHieu_NgayDuLieu++)
                            {
                                DateTime dNgayChamThongKeKyHieu;
                                dNgayChamThongKeKyHieu = Convert.ToDateTime(dNgayBatDauTinhCong.AddDays(iThongKeThangKyHieu_NgayDuLieu).ToString());
                                new DataTable();
                                _tinhCongDTO.MaChamCong = iMaChamCongThongKeThangKyHieu;
                                _tinhCongDTO.Ngay = dNgayChamThongKeKyHieu;
                                DataTable dtDuLieuNgayThongKeThangKyHieu;
                                dtDuLieuNgayThongKeThangKyHieu = _tinhCongBLL.TinhCongGetMaChamCongAndNgayGioVaTC(_tinhCongDTO);
                                for (int iDuLieuNgayThongKeThangKyHieu = 0; iDuLieuNgayThongKeThangKyHieu < dtDuLieuNgayThongKeThangKyHieu.Rows.Count; iDuLieuNgayThongKeThangKyHieu++)
                                {
                                    dTangCa = Convert.ToDouble(dtDuLieuNgayThongKeThangKyHieu.Rows[iDuLieuNgayThongKeThangKyHieu]["TC1"].ToString());
                                    dTangCa2 = Convert.ToDouble(dtDuLieuNgayThongKeThangKyHieu.Rows[iDuLieuNgayThongKeThangKyHieu]["TC2"].ToString());
                                    sGio = dtDuLieuNgayThongKeThangKyHieu.Rows[iDuLieuNgayThongKeThangKyHieu]["Gio"].ToString();
                                }
                                (ws_ThongKeThang_KyHieu).get_Range((object)("F" + iDemDongThongKeThangKyHieu), (object)("AJ" + iDemDongThongKeThangKyHieu)).Cells[1, iDemCotThongKeThangKyHieu] = sGio;
                                (ws_ThongKeThang_KyHieu).get_Range((object)("F" + iDemTangCa), (object)("AJ" + iDemTangCa)).Cells[1, iDemCotThongKeThangKyHieu] = dTangCa + dTangCa2;
                                iDemCotThongKeThangKyHieu++;
                            }
                            double dTongGio;
                            dTongGio = 0.0;
                            double dTongNgayCongThongKeThangKyHieu;
                            dTongNgayCongThongKeThangKyHieu = 0.0;
                            double dTongGioTC1ThongKeThangKyHieu;
                            dTongGioTC1ThongKeThangKyHieu = 0.0;
                            double dTongGioTC2ThongKeThangKyHieu;
                            dTongGioTC2ThongKeThangKyHieu = 0.0;
                            double dTongGioTC3ThongKeThangKyHieu;
                            dTongGioTC3ThongKeThangKyHieu = 0.0;
                            double dTongGioTC4ThongKeThangKyHieu;
                            dTongGioTC4ThongKeThangKyHieu = 0.0;
                            double dTongTreThongKeThangKyHieu;
                            dTongTreThongKeThangKyHieu = 0.0;
                            double dTongVeSomThongKeThangKyHieu;
                            dTongVeSomThongKeThangKyHieu = 0.0;
                            int iDemPhepNamThongKeThangKyHieu;
                            iDemPhepNamThongKeThangKyHieu = 0;
                            int iDemVangThongKeThangKyHieu;
                            iDemVangThongKeThangKyHieu = 0;
                            new DataTable();
                            _tinhCongDTO.MaChamCong = iMaChamCongThongKeThangKyHieu;
                            DataTable dtDuLieuTongThongKeThangKyHieu;
                            dtDuLieuTongThongKeThangKyHieu = _tinhCongBLL.TinhCongGetByMaChamCong(_tinhCongDTO);
                            for (int iDuLieuTongThongKeThangKyHieu = 0; iDuLieuTongThongKeThangKyHieu < dtDuLieuTongThongKeThangKyHieu.Rows.Count; iDuLieuTongThongKeThangKyHieu++)
                            {
                                dTongGio += Convert.ToDouble(dtDuLieuTongThongKeThangKyHieu.Rows[iDuLieuTongThongKeThangKyHieu]["Gio"].ToString());
                                dTongNgayCongThongKeThangKyHieu += Convert.ToDouble(dtDuLieuTongThongKeThangKyHieu.Rows[iDuLieuTongThongKeThangKyHieu]["Cong"].ToString());
                                dTongGioTC1ThongKeThangKyHieu += Convert.ToDouble(dtDuLieuTongThongKeThangKyHieu.Rows[iDuLieuTongThongKeThangKyHieu]["TC1"].ToString());
                                dTongGioTC2ThongKeThangKyHieu += Convert.ToDouble(dtDuLieuTongThongKeThangKyHieu.Rows[iDuLieuTongThongKeThangKyHieu]["TC2"].ToString());
                                dTongGioTC3ThongKeThangKyHieu += Convert.ToDouble(dtDuLieuTongThongKeThangKyHieu.Rows[iDuLieuTongThongKeThangKyHieu]["TC3"].ToString());
                                dTongGioTC4ThongKeThangKyHieu += Convert.ToDouble(dtDuLieuTongThongKeThangKyHieu.Rows[iDuLieuTongThongKeThangKyHieu]["TC4"].ToString());
                                dTongTreThongKeThangKyHieu += Convert.ToDouble(dtDuLieuTongThongKeThangKyHieu.Rows[iDuLieuTongThongKeThangKyHieu]["Tre"].ToString());
                                dTongVeSomThongKeThangKyHieu += Convert.ToDouble(dtDuLieuTongThongKeThangKyHieu.Rows[iDuLieuTongThongKeThangKyHieu]["VeSom"].ToString());
                                string sKyHieuDuLieuThongKeThang;
                                sKyHieuDuLieuThongKeThang = dtDuLieuTongThongKeThangKyHieu.Rows[iDuLieuTongThongKeThangKyHieu]["KyHieu"].ToString();
                                string sThuTotal;
                                sThuTotal = dtDuLieuTongThongKeThangKyHieu.Rows[iDuLieuTongThongKeThangKyHieu]["Thu"].ToString();
                                if (sKyHieuDuLieuThongKeThang == sKHPhepNam)
                                {
                                    iDemPhepNamThongKeThangKyHieu++;
                                }
                                if (sKyHieuDuLieuThongKeThang == sKHVang && sThuTotal != "CN")
                                {
                                    iDemVangThongKeThangKyHieu++;
                                }
                            }
                            Excel.Range excelThongKeThangKyHieu_TongNgayCongDuLieu;
                            excelThongKeThangKyHieu_TongNgayCongDuLieu = (ws_ThongKeThang_KyHieu).get_Range((object)("AK" + iDemDongThongKeThangKyHieu), (object)("AK" + iDemDongThongKeThangKyHieu));
                            excelThongKeThangKyHieu_TongNgayCongDuLieu.Cells[1, 1] = dTongGio.ToString();
                            excelThongKeThangKyHieu_TongNgayCongDuLieu.get_Range((object)"A1", (object)"A2").MergeCells = true;
                            Excel.Range excelThongKeThangKyHieu_TC1DuLieu;
                            excelThongKeThangKyHieu_TC1DuLieu = (ws_ThongKeThang_KyHieu).get_Range((object)("AL" + iDemDongThongKeThangKyHieu), (object)("AL" + iDemDongThongKeThangKyHieu));
                            excelThongKeThangKyHieu_TC1DuLieu.Cells[1, 1] = dTongGioTC1ThongKeThangKyHieu.ToString();
                            excelThongKeThangKyHieu_TC1DuLieu.get_Range((object)"A1", (object)"A2").MergeCells = true;
                            Excel.Range excelThongKeThangKyHieu_TC2DuLieu;
                            excelThongKeThangKyHieu_TC2DuLieu = (ws_ThongKeThang_KyHieu).get_Range((object)("AM" + iDemDongThongKeThangKyHieu), (object)("AM" + iDemDongThongKeThangKyHieu));
                            excelThongKeThangKyHieu_TC2DuLieu.Cells[1, 1] = dTongGioTC2ThongKeThangKyHieu.ToString();
                            excelThongKeThangKyHieu_TC2DuLieu.get_Range((object)"A1", (object)"A2").MergeCells = true;
                            Excel.Range excelThongKeThangKyHieu_TC3DuLieu;
                            excelThongKeThangKyHieu_TC3DuLieu = (ws_ThongKeThang_KyHieu).get_Range((object)("AN" + iDemDongThongKeThangKyHieu), (object)("AN" + iDemDongThongKeThangKyHieu));
                            excelThongKeThangKyHieu_TC3DuLieu.Cells[1, 1] = dTongGioTC3ThongKeThangKyHieu.ToString();
                            excelThongKeThangKyHieu_TC3DuLieu.get_Range((object)"A1", (object)"A2").MergeCells = true;
                            Excel.Range excelThongKeThangKyHieu_TC4DuLieu;
                            excelThongKeThangKyHieu_TC4DuLieu = (ws_ThongKeThang_KyHieu).get_Range((object)("AO" + iDemDongThongKeThangKyHieu), (object)("AO" + iDemDongThongKeThangKyHieu));
                            excelThongKeThangKyHieu_TC4DuLieu.Cells[1, 1] = dTongGioTC4ThongKeThangKyHieu.ToString();
                            excelThongKeThangKyHieu_TC4DuLieu.get_Range((object)"A1", (object)"A2").MergeCells = true;
                            Excel.Range excelThongKeThangKyHieu_VangDuLieu;
                            excelThongKeThangKyHieu_VangDuLieu = (ws_ThongKeThang_KyHieu).get_Range((object)("AP" + iDemDongThongKeThangKyHieu), (object)("AP" + iDemDongThongKeThangKyHieu));
                            excelThongKeThangKyHieu_VangDuLieu.Cells[1, 1] = iDemVangThongKeThangKyHieu.ToString();
                            excelThongKeThangKyHieu_VangDuLieu.get_Range((object)"A1", (object)"A2").MergeCells = true;
                            Excel.Range excelThongKeThangKyHieu_PhepNamDuLieu;
                            excelThongKeThangKyHieu_PhepNamDuLieu = (ws_ThongKeThang_KyHieu).get_Range((object)("AQ" + iDemDongThongKeThangKyHieu), (object)("AQ" + iDemDongThongKeThangKyHieu));
                            excelThongKeThangKyHieu_PhepNamDuLieu.Cells[1, 1] = iDemPhepNamThongKeThangKyHieu.ToString();
                            excelThongKeThangKyHieu_PhepNamDuLieu.get_Range((object)"A1", (object)"A2").MergeCells = true;
                            Excel.Range excelThongKeThangKyHieu_TreDuLieu;
                            excelThongKeThangKyHieu_TreDuLieu = (ws_ThongKeThang_KyHieu).get_Range((object)("AS" + iDemDongThongKeThangKyHieu), (object)("AS" + iDemDongThongKeThangKyHieu));
                            excelThongKeThangKyHieu_TreDuLieu.Cells[1, 1] = dTongTreThongKeThangKyHieu.ToString();
                            excelThongKeThangKyHieu_TreDuLieu.get_Range((object)"A1", (object)"A2").MergeCells = true;
                            (ws_ThongKeThang_KyHieu).get_Range((object)("AR" + iDemDongThongKeThangKyHieu), (object)("AR" + iDemDongThongKeThangKyHieu)).get_Range((object)"A1", (object)"A2").MergeCells = true;
                            Excel.Range excelThongKeThangKyHieu_VeSomDuLieu;
                            excelThongKeThangKyHieu_VeSomDuLieu = (ws_ThongKeThang_KyHieu).get_Range((object)("AT" + iDemDongThongKeThangKyHieu), (object)("AT" + iDemDongThongKeThangKyHieu));
                            excelThongKeThangKyHieu_VeSomDuLieu.Cells[1, 1] = dTongVeSomThongKeThangKyHieu.ToString();
                            excelThongKeThangKyHieu_VeSomDuLieu.get_Range((object)"A1", (object)"A2").MergeCells = true;
                            iDemTangCa = iDemTangCa + 1 + 1;
                            iDemDongThongKeThangKyHieu = iDemDongThongKeThangKyHieu + 1 + 1;
                            iSTTThongKeThangKyHieu++;
                        }
                    }
                    Excel.Range excelThongKeThangKyHieu_DinhDangDuLieu;
                    excelThongKeThangKyHieu_DinhDangDuLieu = (ws_ThongKeThang_KyHieu).get_Range((object)"A7", (object)("AT" + (iDemDongThongKeThangKyHieu - 1)));
                    excelThongKeThangKyHieu_DinhDangDuLieu.Font.Name = "Times New Roman";
                    excelThongKeThangKyHieu_DinhDangDuLieu.Font.Size = "8";
                    excelThongKeThangKyHieu_DinhDangDuLieu.HorizontalAlignment = Excel.Constants.xlCenter;
                    (ws_ThongKeThang_KyHieu).get_Range((object)"A4", (object)("AT" + (iDemDongThongKeThangKyHieu - 1))).Borders.LineStyle = Excel.Constants.xlBoth;
                }
                catch (COMException)
                {
                    failed = true;
                }
                Thread.Sleep(10);
            }
            while (failed);
        }

        private void ExportThongKeThang_KyHieu()
        {
            _ = Thread.CurrentThread.CurrentCulture;
            Thread.CurrentThread.CurrentCulture = new CultureInfo("en-US");
            Excel.Application xla_ThongKeThang_KyHieu;
            xla_ThongKeThang_KyHieu = new Excel.Application();
            xla_ThongKeThang_KyHieu.Workbooks.Add(Excel.XlSheetType.xlWorksheet);
            _ = xla_ThongKeThang_KyHieu.ActiveSheet;
            Excel.Worksheet ws_ThongKeThang_KyHieu;
            ws_ThongKeThang_KyHieu = xla_ThongKeThang_KyHieu.Worksheets.get_Item((object)1);
            DateTime dNgayTinh;
            dNgayTinh = Convert.ToDateTime(dateTimeTuNgay.Text);
            DateTime dNgayBatDauTinhCong;
            dNgayBatDauTinhCong = new DateTime(dNgayTinh.Year, dNgayTinh.Month, dNgayTinh.Day, 0, 0, 0);
            bool failed;
            do
            {
                try
                {
                    Excel.Range excelThongKeThangKyHieu_TenCongTy;
                    excelThongKeThangKyHieu_TenCongTy = (ws_ThongKeThang_KyHieu).get_Range((object)"A1", (object)"AT1");
                    excelThongKeThangKyHieu_TenCongTy.Select();
                    excelThongKeThangKyHieu_TenCongTy.Cells[1, 1] = "Công ty: " + sTenCongTyReport;
                    excelThongKeThangKyHieu_TenCongTy.get_Range((object)"A1", (object)"AT1").Merge(true);
                    Excel.Range excelThongKeThangKyHieu_DiaChiCongTy;
                    excelThongKeThangKyHieu_DiaChiCongTy = (ws_ThongKeThang_KyHieu).get_Range((object)"A2", (object)"AT2");
                    excelThongKeThangKyHieu_DiaChiCongTy.Cells[1, 1] = "Địa chỉ: " + sDiaChiCongTyReport;
                    excelThongKeThangKyHieu_DiaChiCongTy.get_Range((object)"A1", (object)"AT1").Merge(true);
                    Excel.Range excelThongKeThangKyHieu_TieuDe;
                    excelThongKeThangKyHieu_TieuDe = (ws_ThongKeThang_KyHieu).get_Range((object)"A4", (object)"AT4");
                    excelThongKeThangKyHieu_TieuDe.Cells[1, 1] = "BẢNG THỐNG KÊ CHẤM CÔNG (KÝ HIỆU)";
                    excelThongKeThangKyHieu_TieuDe.get_Range((object)"A1", (object)"AT1").Merge(true);
                    excelThongKeThangKyHieu_TieuDe.Font.Name = "Times New Roman";
                    excelThongKeThangKyHieu_TieuDe.Font.Size = "16";
                    excelThongKeThangKyHieu_TieuDe.Font.Bold = true;
                    excelThongKeThangKyHieu_TieuDe.RowHeight = "24";
                    excelThongKeThangKyHieu_TieuDe.HorizontalAlignment = Excel.Constants.xlCenter;
                    Excel.Range excelThongKeThangKyHieu_STT;
                    excelThongKeThangKyHieu_STT = (ws_ThongKeThang_KyHieu).get_Range((object)"A5", (object)"A6");
                    excelThongKeThangKyHieu_STT.Cells[1, 1] = "STT";
                    excelThongKeThangKyHieu_STT.get_Range((object)"A1", (object)"A2").MergeCells = true;
                    excelThongKeThangKyHieu_STT.ColumnWidth = 5;
                    Excel.Range excelThongKeThangKyHieu_PhongBan;
                    excelThongKeThangKyHieu_PhongBan = (ws_ThongKeThang_KyHieu).get_Range((object)"B5", (object)"B6");
                    excelThongKeThangKyHieu_PhongBan.Cells[1, 1] = "PHÒNG BAN";
                    excelThongKeThangKyHieu_PhongBan.get_Range((object)"A1", (object)"A2").MergeCells = true;
                    excelThongKeThangKyHieu_PhongBan.ColumnWidth = 13;
                    Excel.Range excelThongKeThangKyHieu_MaSoNhanVien;
                    excelThongKeThangKyHieu_MaSoNhanVien = (ws_ThongKeThang_KyHieu).get_Range((object)"C5", (object)"C6");
                    excelThongKeThangKyHieu_MaSoNhanVien.Cells[1, 1] = "MSNV";
                    excelThongKeThangKyHieu_MaSoNhanVien.get_Range((object)"A1", (object)"A2").MergeCells = true;
                    excelThongKeThangKyHieu_MaSoNhanVien.ColumnWidth = 6;
                    Excel.Range excelThongKeThangKyHieu_TenNhanVien;
                    excelThongKeThangKyHieu_TenNhanVien = (ws_ThongKeThang_KyHieu).get_Range((object)"D5", (object)"D6");
                    excelThongKeThangKyHieu_TenNhanVien.Cells[1, 1] = "TÊN NHÂN VIÊN";
                    excelThongKeThangKyHieu_TenNhanVien.get_Range((object)"A1", (object)"A2").MergeCells = true;
                    excelThongKeThangKyHieu_TenNhanVien.ColumnWidth = 14;
                    Excel.Range excelThongKeThangKyHieu_NgayVaoLamViec;
                    excelThongKeThangKyHieu_NgayVaoLamViec = (ws_ThongKeThang_KyHieu).get_Range((object)"E5", (object)"E6");
                    excelThongKeThangKyHieu_NgayVaoLamViec.Cells[1, 1] = "NGÀY VÀO LÀM";
                    excelThongKeThangKyHieu_NgayVaoLamViec.get_Range((object)"A1", (object)"A2").MergeCells = true;
                    excelThongKeThangKyHieu_NgayVaoLamViec.ColumnWidth = 14;
                    int ColunmNgay;
                    ColunmNgay = 6;
                    for (int iThongKe_KyHieu = 0; iThongKe_KyHieu < 31; iThongKe_KyHieu++)
                    {
                        DateTime dtNgayChamThongKeKyHieu;
                        dtNgayChamThongKeKyHieu = dateTimeTuNgay.Value;
                        int iNgayChamThongKeKyHieu;
                        iNgayChamThongKeKyHieu = Convert.ToInt32(Convert.ToDateTime(dtNgayChamThongKeKyHieu.AddDays(iThongKe_KyHieu).ToString()).Day);
                        Excel.Range excelThongKeThangKyHieu_Ngay;
                        excelThongKeThangKyHieu_Ngay = (ws_ThongKeThang_KyHieu).get_Range((object)"F5", (object)"AJ6");
                        xla_ThongKeThang_KyHieu.Cells[5, ColunmNgay] = iNgayChamThongKeKyHieu;
                        xla_ThongKeThang_KyHieu.Cells[6, ColunmNgay] = DateTimeProgress.XuatThuReport((int)dtNgayChamThongKeKyHieu.AddDays(iThongKe_KyHieu).DayOfWeek);
                        ColunmNgay++;
                        excelThongKeThangKyHieu_Ngay.ColumnWidth = 5;
                    }
                    Excel.Range excelThongKeThangKyHieu_NgayCong;
                    excelThongKeThangKyHieu_NgayCong = (ws_ThongKeThang_KyHieu).get_Range((object)"AK5", (object)"AK6");
                    excelThongKeThangKyHieu_NgayCong.Cells[1, 1] = "Ngày công";
                    excelThongKeThangKyHieu_NgayCong.get_Range((object)"A1", (object)"A2").MergeCells = true;
                    Excel.Range excelThongKeThangKyHieu_TangCa;
                    excelThongKeThangKyHieu_TangCa = (ws_ThongKeThang_KyHieu).get_Range((object)"AL5", (object)"AO5");
                    excelThongKeThangKyHieu_TangCa.Cells[1, 1] = "Tăng ca";
                    excelThongKeThangKyHieu_TangCa.get_Range((object)"A1", (object)"D1").Merge(true);
                    int ColumTangCa;
                    ColumTangCa = 38;
                    for (int iThongKeKyHieu_TangCa = 1; iThongKeKyHieu_TangCa < 5; iThongKeKyHieu_TangCa++)
                    {
                        Excel.Range excelThongKeThangKyHieu_ChiTietTangCa;
                        excelThongKeThangKyHieu_ChiTietTangCa = (ws_ThongKeThang_KyHieu).get_Range((object)"AL6", (object)"AO6");
                        xla_ThongKeThang_KyHieu.Cells[6, ColumTangCa] = "TC " + iThongKeKyHieu_TangCa;
                        ColumTangCa++;
                        excelThongKeThangKyHieu_ChiTietTangCa.ColumnWidth = 5;
                    }
                    Excel.Range excelThongKeThangKyHieu_Vang;
                    excelThongKeThangKyHieu_Vang = (ws_ThongKeThang_KyHieu).get_Range((object)"AP5", (object)"AP6");
                    excelThongKeThangKyHieu_Vang.Cells[1, 1] = "V";
                    excelThongKeThangKyHieu_Vang.get_Range((object)"A1", (object)"A2").MergeCells = true;
                    excelThongKeThangKyHieu_Vang.ColumnWidth = 5;
                    Excel.Range excelThongKeThangKyHieu_PhepNam;
                    excelThongKeThangKyHieu_PhepNam = (ws_ThongKeThang_KyHieu).get_Range((object)"AQ5", (object)"AQ6");
                    excelThongKeThangKyHieu_PhepNam.Cells[1, 1] = "PN";
                    excelThongKeThangKyHieu_PhepNam.get_Range((object)"A1", (object)"A2").MergeCells = true;
                    excelThongKeThangKyHieu_PhepNam.ColumnWidth = 5;
                    Excel.Range excelThongKeThangKyHieu_CheDo;
                    excelThongKeThangKyHieu_CheDo = (ws_ThongKeThang_KyHieu).get_Range((object)"AR5", (object)"AR6");
                    excelThongKeThangKyHieu_CheDo.Cells[1, 1] = "CĐ";
                    excelThongKeThangKyHieu_CheDo.get_Range((object)"A1", (object)"A2").MergeCells = true;
                    excelThongKeThangKyHieu_CheDo.ColumnWidth = 5;
                    Excel.Range excelThongKeThangKyHieu_Tre;
                    excelThongKeThangKyHieu_Tre = (ws_ThongKeThang_KyHieu).get_Range((object)"AS5", (object)"AS6");
                    excelThongKeThangKyHieu_Tre.Cells[1, 1] = "Trễ";
                    excelThongKeThangKyHieu_Tre.get_Range((object)"A1", (object)"A2").MergeCells = true;
                    excelThongKeThangKyHieu_Tre.ColumnWidth = 5;
                    Excel.Range excelThongKeThangKyHieu_Som;
                    excelThongKeThangKyHieu_Som = (ws_ThongKeThang_KyHieu).get_Range((object)"AT5", (object)"AT6");
                    excelThongKeThangKyHieu_Som.Cells[1, 1] = "Sớm";
                    excelThongKeThangKyHieu_Som.get_Range((object)"A1", (object)"A2").MergeCells = true;
                    excelThongKeThangKyHieu_Som.ColumnWidth = 5;
                    Excel.Range excelThongKeThangKyHieu_Total;
                    excelThongKeThangKyHieu_Total = (ws_ThongKeThang_KyHieu).get_Range((object)"A5", (object)"AT6");
                    excelThongKeThangKyHieu_Total.Font.Name = "Times New Roman";
                    excelThongKeThangKyHieu_Total.Font.Size = "10";
                    excelThongKeThangKyHieu_Total.Font.Bold = true;
                    excelThongKeThangKyHieu_Total.HorizontalAlignment = Excel.Constants.xlCenter;
                    xla_ThongKeThang_KyHieu.Visible = true;
                    int iDemDongThongKeThangKyHieu;
                    iDemDongThongKeThangKyHieu = 7;
                    new DataTable();
                    DataTable dtNgayTinhCongThongKeThangKyHieu;
                    dtNgayTinhCongThongKeThangKyHieu = _ngayTinhCongBLL.showThongTinNgayTinhCong();
                    for (int iNgayTinhCongThongKeThangKyHieu = 0; iNgayTinhCongThongKeThangKyHieu < dtNgayTinhCongThongKeThangKyHieu.Rows.Count; iNgayTinhCongThongKeThangKyHieu++)
                    {
                        int iSTTThongKeThangKyHieu;
                        iSTTThongKeThangKyHieu = 1;
                        int iMaChamCongThongKeThangKyHieu;
                        iMaChamCongThongKeThangKyHieu = 0;
                        DateTime dNgayBatDauTinhCongThongKeThangKyHieu;
                        dNgayBatDauTinhCongThongKeThangKyHieu = Convert.ToDateTime(dtNgayTinhCongThongKeThangKyHieu.Rows[iNgayTinhCongThongKeThangKyHieu]["NgayBatDau"].ToString());
                        int iTongNgayTinhCongThongKeThangKyHieu;
                        iTongNgayTinhCongThongKeThangKyHieu = Convert.ToInt32((Convert.ToDateTime(dtNgayTinhCongThongKeThangKyHieu.Rows[iNgayTinhCongThongKeThangKyHieu]["NgayKetThuc"].ToString()) - dNgayBatDauTinhCongThongKeThangKyHieu).TotalDays);
                        new DataTable();
                        _tinhCongDTO.Ngay = dNgayBatDauTinhCong;
                        DataTable dtTinhCongThongKeThangKyHieu;
                        dtTinhCongThongKeThangKyHieu = _tinhCongBLL.TinhCongGetNgay(_tinhCongDTO);
                        for (int iTinhCongThongKeThangKyHieu = 0; iTinhCongThongKeThangKyHieu < dtTinhCongThongKeThangKyHieu.Rows.Count; iTinhCongThongKeThangKyHieu++)
                        {
                            int iDemCotThongKeThangKyHieu;
                            iDemCotThongKeThangKyHieu = 1;
                            if (Convert.ToInt32(dtTinhCongThongKeThangKyHieu.Rows[iTinhCongThongKeThangKyHieu]["MaChamCong"].ToString()) == iMaChamCongThongKeThangKyHieu)
                            {
                                continue;
                            }
                            iMaChamCongThongKeThangKyHieu = Convert.ToInt32(dtTinhCongThongKeThangKyHieu.Rows[iTinhCongThongKeThangKyHieu]["MaChamCong"].ToString());
                            Excel.Range excelThongKeThangKyHieu_STTDuLieu;
                            excelThongKeThangKyHieu_STTDuLieu = (ws_ThongKeThang_KyHieu).get_Range((object)("A" + iDemDongThongKeThangKyHieu), (object)("A" + iDemDongThongKeThangKyHieu));
                            excelThongKeThangKyHieu_STTDuLieu.Cells[1, 1] = iSTTThongKeThangKyHieu.ToString();
                            excelThongKeThangKyHieu_STTDuLieu.Select();
                            string sTenPhongBan;
                            sTenPhongBan = "";
                            new DataTable();
                            _phongBanDTO.MaPhongBan = dtTinhCongThongKeThangKyHieu.Rows[iTinhCongThongKeThangKyHieu]["PhongBan"].ToString();
                            DataTable dtPhongBan;
                            dtPhongBan = _phongBanBLL.getTenPhongBanByMaPhongBan(_phongBanDTO);
                            for (int iPhongBan = 0; iPhongBan < dtPhongBan.Rows.Count; iPhongBan++)
                            {
                                sTenPhongBan = dtPhongBan.Rows[iPhongBan]["TenPhongBan"].ToString();
                            }
                            Excel.Range excelThongKeThangKyHieu_PhongBanDuLieu;
                            excelThongKeThangKyHieu_PhongBanDuLieu = (ws_ThongKeThang_KyHieu).get_Range((object)("B" + iDemDongThongKeThangKyHieu), (object)("B" + iDemDongThongKeThangKyHieu));
                            if (sTenPhongBan == "")
                            {
                                excelThongKeThangKyHieu_PhongBanDuLieu.Cells[1, 1] = "------";
                            }
                            else
                            {
                                excelThongKeThangKyHieu_PhongBanDuLieu.Cells[1, 1] = sTenPhongBan;
                            }
                            Excel.Range excelThongKeThangKyHieu_MaNhanVienDuLieu;
                            excelThongKeThangKyHieu_MaNhanVienDuLieu = (ws_ThongKeThang_KyHieu).get_Range((object)("C" + iDemDongThongKeThangKyHieu), (object)("C" + iDemDongThongKeThangKyHieu));
                            excelThongKeThangKyHieu_MaNhanVienDuLieu.get_Range((object)"A1", (object)"A1").NumberFormat = "@";
                            excelThongKeThangKyHieu_MaNhanVienDuLieu.Cells[1, 1] = dtTinhCongThongKeThangKyHieu.Rows[iTinhCongThongKeThangKyHieu]["MaNhanVien"].ToString();
                            (ws_ThongKeThang_KyHieu).get_Range((object)("D" + iDemDongThongKeThangKyHieu), (object)("D" + iDemDongThongKeThangKyHieu)).Cells[1, 1] = dtTinhCongThongKeThangKyHieu.Rows[iTinhCongThongKeThangKyHieu]["TenNhanVien"].ToString();
                            for (int iThongKeThangKyHieu_NgayDuLieu = 0; iThongKeThangKyHieu_NgayDuLieu <= iTongNgayTinhCongThongKeThangKyHieu; iThongKeThangKyHieu_NgayDuLieu++)
                            {
                                string sDuLieuThongKeThangKyHieu;
                                sDuLieuThongKeThangKyHieu = "";
                                DateTime dNgayChamThongKeKyHieu;
                                dNgayChamThongKeKyHieu = Convert.ToDateTime(dNgayBatDauTinhCongThongKeThangKyHieu.AddDays(iThongKeThangKyHieu_NgayDuLieu).ToString());
                                new DataTable();
                                _tinhCongDTO.MaChamCong = iMaChamCongThongKeThangKyHieu;
                                _tinhCongDTO.Ngay = dNgayChamThongKeKyHieu;
                                DataTable dtDuLieuNgayThongKeThangKyHieu;
                                dtDuLieuNgayThongKeThangKyHieu = _tinhCongBLL.TinhCongGetMaChamCongAndNgay(_tinhCongDTO);
                                for (int iDuLieuNgayThongKeThangKyHieu = 0; iDuLieuNgayThongKeThangKyHieu < dtDuLieuNgayThongKeThangKyHieu.Rows.Count; iDuLieuNgayThongKeThangKyHieu++)
                                {
                                    string sThu;
                                    sThu = dtDuLieuNgayThongKeThangKyHieu.Rows[iDuLieuNgayThongKeThangKyHieu]["Thu"].ToString();
                                    double dCong;
                                    dCong = Convert.ToDouble(dtDuLieuNgayThongKeThangKyHieu.Rows[iDuLieuNgayThongKeThangKyHieu]["Cong"].ToString());
                                    sDuLieuThongKeThangKyHieu = ((!(sThu == "CN")) ? (sDuLieuThongKeThangKyHieu + dtDuLieuNgayThongKeThangKyHieu.Rows[iDuLieuNgayThongKeThangKyHieu]["KyHieu"].ToString()) : ((!(dCong > 0.0)) ? "" : (sDuLieuThongKeThangKyHieu + dtDuLieuNgayThongKeThangKyHieu.Rows[iDuLieuNgayThongKeThangKyHieu]["KyHieu"].ToString())));
                                }
                                (ws_ThongKeThang_KyHieu).get_Range((object)("F" + iDemDongThongKeThangKyHieu), (object)("AJ" + iDemDongThongKeThangKyHieu)).Cells[1, iDemCotThongKeThangKyHieu] = sDuLieuThongKeThangKyHieu;
                                iDemCotThongKeThangKyHieu++;
                            }
                            double dTongNgayCongThongKeThangKyHieu;
                            dTongNgayCongThongKeThangKyHieu = 0.0;
                            double dTongGioTC1ThongKeThangKyHieu;
                            dTongGioTC1ThongKeThangKyHieu = 0.0;
                            double dTongGioTC2ThongKeThangKyHieu;
                            dTongGioTC2ThongKeThangKyHieu = 0.0;
                            double dTongGioTC3ThongKeThangKyHieu;
                            dTongGioTC3ThongKeThangKyHieu = 0.0;
                            double dTongGioTC4ThongKeThangKyHieu;
                            dTongGioTC4ThongKeThangKyHieu = 0.0;
                            double dTongTreThongKeThangKyHieu;
                            dTongTreThongKeThangKyHieu = 0.0;
                            double dTongVeSomThongKeThangKyHieu;
                            dTongVeSomThongKeThangKyHieu = 0.0;
                            int iDemPhepNamThongKeThangKyHieu;
                            iDemPhepNamThongKeThangKyHieu = 0;
                            int iDemVangThongKeThangKyHieu;
                            iDemVangThongKeThangKyHieu = 0;
                            new DataTable();
                            _tinhCongDTO.MaChamCong = iMaChamCongThongKeThangKyHieu;
                            DataTable dtDuLieuTongThongKeThangKyHieu;
                            dtDuLieuTongThongKeThangKyHieu = _tinhCongBLL.TinhCongGetByMaChamCong(_tinhCongDTO);
                            for (int iDuLieuTongThongKeThangKyHieu = 0; iDuLieuTongThongKeThangKyHieu < dtDuLieuTongThongKeThangKyHieu.Rows.Count; iDuLieuTongThongKeThangKyHieu++)
                            {
                                dTongNgayCongThongKeThangKyHieu += Convert.ToDouble(dtDuLieuTongThongKeThangKyHieu.Rows[iDuLieuTongThongKeThangKyHieu]["Cong"].ToString());
                                dTongGioTC1ThongKeThangKyHieu += Convert.ToDouble(dtDuLieuTongThongKeThangKyHieu.Rows[iDuLieuTongThongKeThangKyHieu]["TC1"].ToString());
                                dTongGioTC2ThongKeThangKyHieu += Convert.ToDouble(dtDuLieuTongThongKeThangKyHieu.Rows[iDuLieuTongThongKeThangKyHieu]["TC2"].ToString());
                                dTongGioTC3ThongKeThangKyHieu += Convert.ToDouble(dtDuLieuTongThongKeThangKyHieu.Rows[iDuLieuTongThongKeThangKyHieu]["TC3"].ToString());
                                dTongGioTC4ThongKeThangKyHieu += Convert.ToDouble(dtDuLieuTongThongKeThangKyHieu.Rows[iDuLieuTongThongKeThangKyHieu]["TC4"].ToString());
                                dTongTreThongKeThangKyHieu += Convert.ToDouble(dtDuLieuTongThongKeThangKyHieu.Rows[iDuLieuTongThongKeThangKyHieu]["Tre"].ToString());
                                dTongVeSomThongKeThangKyHieu += Convert.ToDouble(dtDuLieuTongThongKeThangKyHieu.Rows[iDuLieuTongThongKeThangKyHieu]["VeSom"].ToString());
                                string sKyHieuDuLieuThongKeThang;
                                sKyHieuDuLieuThongKeThang = dtDuLieuTongThongKeThangKyHieu.Rows[iDuLieuTongThongKeThangKyHieu]["KyHieu"].ToString();
                                string sThuTotal;
                                sThuTotal = dtDuLieuTongThongKeThangKyHieu.Rows[iDuLieuTongThongKeThangKyHieu]["Thu"].ToString();
                                if (sKyHieuDuLieuThongKeThang == sKHPhepNam)
                                {
                                    iDemPhepNamThongKeThangKyHieu++;
                                }
                                if (sKyHieuDuLieuThongKeThang == sKHVang && sThuTotal != "CN")
                                {
                                    iDemVangThongKeThangKyHieu++;
                                }
                            }
                            (ws_ThongKeThang_KyHieu).get_Range((object)("AK" + iDemDongThongKeThangKyHieu), (object)("AK" + iDemDongThongKeThangKyHieu)).Cells[1, 1] = dTongNgayCongThongKeThangKyHieu.ToString();
                            (ws_ThongKeThang_KyHieu).get_Range((object)("AL" + iDemDongThongKeThangKyHieu), (object)("AL" + iDemDongThongKeThangKyHieu)).Cells[1, 1] = dTongGioTC1ThongKeThangKyHieu.ToString();
                            (ws_ThongKeThang_KyHieu).get_Range((object)("AM" + iDemDongThongKeThangKyHieu), (object)("AM" + iDemDongThongKeThangKyHieu)).Cells[1, 1] = dTongGioTC2ThongKeThangKyHieu.ToString();
                            (ws_ThongKeThang_KyHieu).get_Range((object)("AN" + iDemDongThongKeThangKyHieu), (object)("AN" + iDemDongThongKeThangKyHieu)).Cells[1, 1] = dTongGioTC3ThongKeThangKyHieu.ToString();
                            (ws_ThongKeThang_KyHieu).get_Range((object)("AO" + iDemDongThongKeThangKyHieu), (object)("AO" + iDemDongThongKeThangKyHieu)).Cells[1, 1] = dTongGioTC4ThongKeThangKyHieu.ToString();
                            (ws_ThongKeThang_KyHieu).get_Range((object)("AP" + iDemDongThongKeThangKyHieu), (object)("AP" + iDemDongThongKeThangKyHieu)).Cells[1, 1] = iDemVangThongKeThangKyHieu.ToString();
                            (ws_ThongKeThang_KyHieu).get_Range((object)("AQ" + iDemDongThongKeThangKyHieu), (object)("AQ" + iDemDongThongKeThangKyHieu)).Cells[1, 1] = iDemPhepNamThongKeThangKyHieu.ToString();
                            (ws_ThongKeThang_KyHieu).get_Range((object)("AS" + iDemDongThongKeThangKyHieu), (object)("AS" + iDemDongThongKeThangKyHieu)).Cells[1, 1] = dTongTreThongKeThangKyHieu.ToString();
                            (ws_ThongKeThang_KyHieu).get_Range((object)("AT" + iDemDongThongKeThangKyHieu), (object)("AT" + iDemDongThongKeThangKyHieu)).Cells[1, 1] = dTongVeSomThongKeThangKyHieu.ToString();
                            iDemDongThongKeThangKyHieu++;
                            iSTTThongKeThangKyHieu++;
                        }
                    }
                    Excel.Range excelThongKeThangKyHieu_DinhDangDuLieu;
                    excelThongKeThangKyHieu_DinhDangDuLieu = (ws_ThongKeThang_KyHieu).get_Range((object)"A7", (object)("AT" + (iDemDongThongKeThangKyHieu - 1)));
                    excelThongKeThangKyHieu_DinhDangDuLieu.Font.Name = "Times New Roman";
                    excelThongKeThangKyHieu_DinhDangDuLieu.Font.Size = "8";
                    excelThongKeThangKyHieu_DinhDangDuLieu.HorizontalAlignment = Excel.Constants.xlCenter;
                    (ws_ThongKeThang_KyHieu).get_Range((object)"A4", (object)("AT" + (iDemDongThongKeThangKyHieu - 1))).Borders.LineStyle = Excel.Constants.xlBoth;
                    failed = false;
                }
                catch (COMException)
                {
                    failed = true;
                }
                Thread.Sleep(10);
            }
            while (failed);
        }

        private void ExportExcelChiTietTungNguoiTungNgay()
        {
            DateTime dNgayTinh;
            dNgayTinh = Convert.ToDateTime(dateTimeTuNgay.Text);
            DateTime dNgayBatDauTinhCong;
            dNgayBatDauTinhCong = new DateTime(dNgayTinh.Year, dNgayTinh.Month, dNgayTinh.Day, 0, 0, 0);
            _ = Thread.CurrentThread.CurrentCulture;
            Thread.CurrentThread.CurrentCulture = new CultureInfo("en-US");
            int iTongNgayChamChiTietTungNguoiTungNgay;
            iTongNgayChamChiTietTungNguoiTungNgay = Convert.ToInt32(Convert.ToInt32((dateTimeDenNgay.Value - dateTimeTuNgay.Value).TotalDays).ToString()) + 1;
            int iTongDong;
            iTongDong = iTongNgayChamChiTietTungNguoiTungNgay + 9;
            Excel.Application xla_ChiTietTungNguoiTungNgay;
            xla_ChiTietTungNguoiTungNgay = new Excel.Application();
            xla_ChiTietTungNguoiTungNgay.Workbooks.Add(Excel.XlSheetType.xlWorksheet);
            _ = xla_ChiTietTungNguoiTungNgay.ActiveSheet;
            Excel.Worksheet ws_ChiTietTungNguoiTungNgay;
            ws_ChiTietTungNguoiTungNgay = xla_ChiTietTungNguoiTungNgay.Worksheets.get_Item((object)1);
            xla_ChiTietTungNguoiTungNgay.Visible = true;
            int demNhanVien;
            demNhanVien = 0;
            new DataTable();
            DataTable dtNgayTinhCongChiTietTungNguoiTungNgay;
            dtNgayTinhCongChiTietTungNguoiTungNgay = _ngayTinhCongBLL.showThongTinNgayTinhCong();
            for (int iNgayTinhCongChiTietTungNguoiTungNgay = 0; iNgayTinhCongChiTietTungNguoiTungNgay < dtNgayTinhCongChiTietTungNguoiTungNgay.Rows.Count; iNgayTinhCongChiTietTungNguoiTungNgay++)
            {
                Convert.ToDateTime(dtNgayTinhCongChiTietTungNguoiTungNgay.Rows[iNgayTinhCongChiTietTungNguoiTungNgay]["NgayBatDau"].ToString());
                new DataTable();
                _tinhCongDTO.Ngay = dNgayBatDauTinhCong;
                DataTable dtNhanVienChiTietTungNguoiTung;
                dtNhanVienChiTietTungNguoiTung = _tinhCongBLL.TinhCongGetNgay(_tinhCongDTO);
                int iMaChamCongChiTietTungNguoiTungNgay;
                iMaChamCongChiTietTungNguoiTungNgay = 0;
                for (int iNhanVienChiTietTungNguoiTungNgay = 0; iNhanVienChiTietTungNguoiTungNgay < dtNhanVienChiTietTungNguoiTung.Rows.Count; iNhanVienChiTietTungNguoiTungNgay++)
                {
                    string sTenPhongBanChiTietTungNguoiTungNgay;
                    sTenPhongBanChiTietTungNguoiTungNgay = "--------";
                    if (Convert.ToInt32(dtNhanVienChiTietTungNguoiTung.Rows[iNhanVienChiTietTungNguoiTungNgay]["MaChamCong"].ToString()) == iMaChamCongChiTietTungNguoiTungNgay)
                    {
                        continue;
                    }
                    iMaChamCongChiTietTungNguoiTungNgay = Convert.ToInt32(dtNhanVienChiTietTungNguoiTung.Rows[iNhanVienChiTietTungNguoiTungNgay]["MaChamCong"].ToString());
                    string sMaPhongBanChiTietTungNguoiTungNgay;
                    sMaPhongBanChiTietTungNguoiTungNgay = dtNhanVienChiTietTungNguoiTung.Rows[iNhanVienChiTietTungNguoiTungNgay]["PhongBan"].ToString();
                    new DataTable();
                    _phongBanDTO.MaPhongBan = sMaPhongBanChiTietTungNguoiTungNgay;
                    DataTable dtPhongBanChiTietTungNguoiTungNgay;
                    dtPhongBanChiTietTungNguoiTungNgay = _phongBanBLL.getTenPhongBanByMaPhongBan(_phongBanDTO);
                    for (int iPhongBanChiTietTungNguoiTungNgay = 0; iPhongBanChiTietTungNguoiTungNgay < dtPhongBanChiTietTungNguoiTungNgay.Rows.Count; iPhongBanChiTietTungNguoiTungNgay++)
                    {
                        sTenPhongBanChiTietTungNguoiTungNgay = dtPhongBanChiTietTungNguoiTungNgay.Rows[iPhongBanChiTietTungNguoiTungNgay]["TenPhongBan"].ToString();
                    }
                    Excel.Range excelChiTietTungNguoiTungNgay_TieuDe;
                    excelChiTietTungNguoiTungNgay_TieuDe = (ws_ChiTietTungNguoiTungNgay).get_Range((object)("A" + (iTongDong * demNhanVien + 1)), (object)("P" + (iTongDong * demNhanVien + 1)));
                    excelChiTietTungNguoiTungNgay_TieuDe.Select();
                    excelChiTietTungNguoiTungNgay_TieuDe.Cells[1, 1] = "BẢNG CHI TIẾT CHẤM CÔNG";
                    excelChiTietTungNguoiTungNgay_TieuDe.get_Range((object)"A1", (object)"P1").Merge(true);
                    excelChiTietTungNguoiTungNgay_TieuDe.Font.Name = "Times New Roman";
                    excelChiTietTungNguoiTungNgay_TieuDe.Font.Size = "18";
                    excelChiTietTungNguoiTungNgay_TieuDe.Font.Bold = true;
                    excelChiTietTungNguoiTungNgay_TieuDe.RowHeight = "23";
                    excelChiTietTungNguoiTungNgay_TieuDe.HorizontalAlignment = Excel.Constants.xlCenter;
                    Excel.Range excelChiTietTungNguoiTungNgay_Header;
                    excelChiTietTungNguoiTungNgay_Header = (ws_ChiTietTungNguoiTungNgay).get_Range((object)("A" + (iTongDong * demNhanVien + 2)), (object)("P" + (iTongDong * demNhanVien + 2)));
                    excelChiTietTungNguoiTungNgay_Header.Select();
                    excelChiTietTungNguoiTungNgay_Header.Cells[1, 1] = string.Concat("Mã nhân viên: ", dtNhanVienChiTietTungNguoiTung.Rows[iNhanVienChiTietTungNguoiTungNgay]["MaNhanVien"].ToString(), "         Tên nhân viên: ", dtNhanVienChiTietTungNguoiTung.Rows[iNhanVienChiTietTungNguoiTungNgay]["TenNhanVien"], "         Phòng ban: ", sTenPhongBanChiTietTungNguoiTungNgay);
                    excelChiTietTungNguoiTungNgay_Header.Font.Size = "14";
                    excelChiTietTungNguoiTungNgay_Header.Font.Bold = true;
                    excelChiTietTungNguoiTungNgay_Header.RowHeight = "18";
                    excelChiTietTungNguoiTungNgay_Header.Font.Name = "Times New Roman";
                    excelChiTietTungNguoiTungNgay_Header.Interior.ColorIndex = 6;
                    excelChiTietTungNguoiTungNgay_Header.get_Range((object)"A1", (object)"P1").Merge(true);
                    Excel.Range excelChiTietTungNguoiTungNgay_TongGioHeader;
                    excelChiTietTungNguoiTungNgay_TongGioHeader = (ws_ChiTietTungNguoiTungNgay).get_Range((object)("A" + (iTongDong * demNhanVien + 3)), (object)("B" + (iTongDong * demNhanVien + 3)));
                    excelChiTietTungNguoiTungNgay_TongGioHeader.Cells[1, 1] = "Tổng giờ";
                    excelChiTietTungNguoiTungNgay_TongGioHeader.get_Range((object)"A1", (object)"B1").Merge(true);
                    Excel.Range excelChiTietTungNguoiTungNgay_SoLanTreHeader;
                    excelChiTietTungNguoiTungNgay_SoLanTreHeader = (ws_ChiTietTungNguoiTungNgay).get_Range((object)("F" + (iTongDong * demNhanVien + 3)), (object)("G" + (iTongDong * demNhanVien + 3)));
                    excelChiTietTungNguoiTungNgay_SoLanTreHeader.Cells[1, 1] = "Số lần trễ";
                    excelChiTietTungNguoiTungNgay_SoLanTreHeader.get_Range((object)"A1", (object)"B1").Merge(true);
                    Excel.Range excelChiTietTungNguoiTungNgay_SoPhutTreHeader;
                    excelChiTietTungNguoiTungNgay_SoPhutTreHeader = (ws_ChiTietTungNguoiTungNgay).get_Range((object)("J" + (iTongDong * demNhanVien + 3)), (object)("K" + (iTongDong * demNhanVien + 3)));
                    excelChiTietTungNguoiTungNgay_SoPhutTreHeader.Cells[1, 1] = "Số phút trễ";
                    excelChiTietTungNguoiTungNgay_SoPhutTreHeader.get_Range((object)"A1", (object)"B1").Merge(true);
                    Excel.Range excelChiTietTungNguoiTungNgay_TangCaNgayLeHeader;
                    excelChiTietTungNguoiTungNgay_TangCaNgayLeHeader = (ws_ChiTietTungNguoiTungNgay).get_Range((object)("N" + (iTongDong * demNhanVien + 3)), (object)("O" + (iTongDong * demNhanVien + 3)));
                    excelChiTietTungNguoiTungNgay_TangCaNgayLeHeader.Cells[1, 1] = "Tăng ca ngày lễ";
                    excelChiTietTungNguoiTungNgay_TangCaNgayLeHeader.get_Range((object)"A1", (object)"B1").Merge(true);
                    Excel.Range excelChiTietTungNguoiTungNgay_TongCongHeader;
                    excelChiTietTungNguoiTungNgay_TongCongHeader = (ws_ChiTietTungNguoiTungNgay).get_Range((object)("A" + (iTongDong * demNhanVien + 4)), (object)("B" + (iTongDong * demNhanVien + 4)));
                    excelChiTietTungNguoiTungNgay_TongCongHeader.Cells[1, 1] = "Tổng công";
                    excelChiTietTungNguoiTungNgay_TongCongHeader.get_Range((object)"A1", (object)"B1").Merge(true);
                    Excel.Range excelChiTietTungNguoiTungNgay_SoLanSomHeader;
                    excelChiTietTungNguoiTungNgay_SoLanSomHeader = (ws_ChiTietTungNguoiTungNgay).get_Range((object)("F" + (iTongDong * demNhanVien + 4)), (object)("G" + (iTongDong * demNhanVien + 4)));
                    excelChiTietTungNguoiTungNgay_SoLanSomHeader.Cells[1, 1] = "Số lần sớm";
                    excelChiTietTungNguoiTungNgay_SoLanSomHeader.get_Range((object)"A1", (object)"B1").Merge(true);
                    Excel.Range excelChiTietTungNguoiTungNgay_SoPhutSomHeader;
                    excelChiTietTungNguoiTungNgay_SoPhutSomHeader = (ws_ChiTietTungNguoiTungNgay).get_Range((object)("J" + (iTongDong * demNhanVien + 4)), (object)("K" + (iTongDong * demNhanVien + 4)));
                    excelChiTietTungNguoiTungNgay_SoPhutSomHeader.Cells[1, 1] = "Số phút sớm";
                    excelChiTietTungNguoiTungNgay_SoPhutSomHeader.get_Range((object)"A1", (object)"B1").Merge(true);
                    Excel.Range excelChiTietTungNguoiTungNgay_TangCaHeader;
                    excelChiTietTungNguoiTungNgay_TangCaHeader = (ws_ChiTietTungNguoiTungNgay).get_Range((object)("A" + (iTongDong * demNhanVien + 5)), (object)("B" + (iTongDong * demNhanVien + 5)));
                    excelChiTietTungNguoiTungNgay_TangCaHeader.Cells[1, 1] = "Tăng ca";
                    excelChiTietTungNguoiTungNgay_TangCaHeader.get_Range((object)"A1", (object)"B1").Merge(true);
                    Excel.Range excelChiTietTungNguoiTungNgay_VangKhongPhepHeader;
                    excelChiTietTungNguoiTungNgay_VangKhongPhepHeader = (ws_ChiTietTungNguoiTungNgay).get_Range((object)("F" + (iTongDong * demNhanVien + 5)), (object)("G" + (iTongDong * demNhanVien + 5)));
                    excelChiTietTungNguoiTungNgay_VangKhongPhepHeader.Cells[1, 1] = "Vắng KP";
                    excelChiTietTungNguoiTungNgay_VangKhongPhepHeader.get_Range((object)"A1", (object)"B1").Merge(true);
                    Excel.Range excelChiTietTungNguoiTungNgay_VangCoPhepHeader;
                    excelChiTietTungNguoiTungNgay_VangCoPhepHeader = (ws_ChiTietTungNguoiTungNgay).get_Range((object)("J" + (iTongDong * demNhanVien + 5)), (object)("K" + (iTongDong * demNhanVien + 5)));
                    excelChiTietTungNguoiTungNgay_VangCoPhepHeader.Cells[1, 1] = "Vắng CP";
                    excelChiTietTungNguoiTungNgay_VangCoPhepHeader.get_Range((object)"A1", (object)"B1").Merge(true);
                    (ws_ChiTietTungNguoiTungNgay).get_Range((object)("E" + (iTongDong * demNhanVien + 3)), (object)("E" + (iTongDong * demNhanVien + 5))).get_Range((object)"A1", (object)"A3").MergeCells = true;
                    (ws_ChiTietTungNguoiTungNgay).get_Range((object)("I" + (iTongDong * demNhanVien + 3)), (object)("I" + (iTongDong * demNhanVien + 5))).get_Range((object)"A1", (object)"A3").MergeCells = true;
                    (ws_ChiTietTungNguoiTungNgay).get_Range((object)("M" + (iTongDong * demNhanVien + 3)), (object)("M" + (iTongDong * demNhanVien + 5))).get_Range((object)"A1", (object)"A3").MergeCells = true;
                    double dTongGioChiTietTungNguoiTungNgay;
                    dTongGioChiTietTungNguoiTungNgay = 0.0;
                    double dTongCongChiTietTungNguoiTungNgay;
                    dTongCongChiTietTungNguoiTungNgay = 0.0;
                    int iSoLanTreChiTietTungNguoiTungNgay;
                    iSoLanTreChiTietTungNguoiTungNgay = 0;
                    int iSoLanVeSomChiTietTungNguoiTungNgay;
                    iSoLanVeSomChiTietTungNguoiTungNgay = 0;
                    int iSoPhutTreChiTietTungNguoiTungNgay;
                    iSoPhutTreChiTietTungNguoiTungNgay = 0;
                    int iSoPhutVeSomChiTietTungNguoiTungNgay;
                    iSoPhutVeSomChiTietTungNguoiTungNgay = 0;
                    double dTongTangCaNgayThuong;
                    dTongTangCaNgayThuong = 0.0;
                    double dTongTangCaNgayChuNhat;
                    dTongTangCaNgayChuNhat = 0.0;
                    int iDemNVProCess;
                    iDemNVProCess = 0;
                    new DataTable();
                    _tinhCongDTO.MaChamCong = iMaChamCongChiTietTungNguoiTungNgay;
                    DataTable dtDuLieuHeader;
                    dtDuLieuHeader = _tinhCongBLL.TinhCongGetByMaChamCong(_tinhCongDTO);
                    for (int iDuLieuHeader = 0; iDuLieuHeader < dtDuLieuHeader.Rows.Count; iDuLieuHeader++)
                    {
                        dTongGioChiTietTungNguoiTungNgay += Convert.ToDouble(dtDuLieuHeader.Rows[iDuLieuHeader]["Gio"].ToString());
                        dTongCongChiTietTungNguoiTungNgay += Convert.ToDouble(dtDuLieuHeader.Rows[iDuLieuHeader]["Cong"].ToString());
                        iSoPhutTreChiTietTungNguoiTungNgay += Convert.ToInt32(dtDuLieuHeader.Rows[iDuLieuHeader]["Tre"].ToString());
                        iSoPhutVeSomChiTietTungNguoiTungNgay += Convert.ToInt32(dtDuLieuHeader.Rows[iDuLieuHeader]["VeSom"].ToString());
                        if (Convert.ToInt32(dtDuLieuHeader.Rows[iDuLieuHeader]["Tre"].ToString()) != 0)
                        {
                            iSoLanTreChiTietTungNguoiTungNgay++;
                        }
                        if (Convert.ToInt32(dtDuLieuHeader.Rows[iDuLieuHeader]["VeSom"].ToString()) != 0)
                        {
                            iSoLanVeSomChiTietTungNguoiTungNgay++;
                        }
                    }
                    Excel.Range excelChiTietTungNguoiTungNgay_TongGioDuLieuHeader;
                    excelChiTietTungNguoiTungNgay_TongGioDuLieuHeader = (ws_ChiTietTungNguoiTungNgay).get_Range((object)("C" + (iTongDong * demNhanVien + 3)), (object)("D" + (iTongDong * demNhanVien + 3)));
                    excelChiTietTungNguoiTungNgay_TongGioDuLieuHeader.Cells[1, 1] = dTongGioChiTietTungNguoiTungNgay;
                    excelChiTietTungNguoiTungNgay_TongGioDuLieuHeader.get_Range((object)"A1", (object)"B1").Merge(true);
                    Excel.Range excelChiTietTungNguoiTungNgay_TongCongDuLieuHeader;
                    excelChiTietTungNguoiTungNgay_TongCongDuLieuHeader = (ws_ChiTietTungNguoiTungNgay).get_Range((object)("C" + (iTongDong * demNhanVien + 4)), (object)("D" + (iTongDong * demNhanVien + 4)));
                    excelChiTietTungNguoiTungNgay_TongCongDuLieuHeader.Cells[1, 1] = dTongCongChiTietTungNguoiTungNgay;
                    excelChiTietTungNguoiTungNgay_TongCongDuLieuHeader.get_Range((object)"A1", (object)"B1").Merge(true);
                    new DataTable();
                    _tinhCongDTO.MaChamCong = iMaChamCongChiTietTungNguoiTungNgay;
                    _tinhCongDTO.KyHieuPhu = "NT";
                    DataTable dtGioCongNgayThuong;
                    dtGioCongNgayThuong = _tinhCongBLL.TinhCongGetByMaChamCongAndKyHieuPhu(_tinhCongDTO);
                    for (int iGioCongNgayThuong = 0; iGioCongNgayThuong < dtGioCongNgayThuong.Rows.Count; iGioCongNgayThuong++)
                    {
                        dTongTangCaNgayThuong += Convert.ToDouble(dtGioCongNgayThuong.Rows[iGioCongNgayThuong]["TC1"].ToString()) + Convert.ToDouble(dtGioCongNgayThuong.Rows[iGioCongNgayThuong]["TC2"].ToString()) + Convert.ToDouble(dtGioCongNgayThuong.Rows[iGioCongNgayThuong]["TC3"].ToString()) + Convert.ToDouble(dtGioCongNgayThuong.Rows[iGioCongNgayThuong]["TC4"].ToString());
                    }
                    (ws_ChiTietTungNguoiTungNgay).get_Range((object)("C" + (iTongDong * demNhanVien + 5)), (object)("C" + (iTongDong * demNhanVien + 5))).Cells[1, 1] = dTongTangCaNgayThuong;
                    new DataTable();
                    _tinhCongDTO.MaChamCong = iMaChamCongChiTietTungNguoiTungNgay;
                    _tinhCongDTO.KyHieuPhu = "CN";
                    DataTable dtGioCongNgayChuNhat;
                    dtGioCongNgayChuNhat = _tinhCongBLL.TinhCongGetByMaChamCongAndKyHieuPhu(_tinhCongDTO);
                    for (int iGioCongNgayChuNhat = 0; iGioCongNgayChuNhat < dtGioCongNgayChuNhat.Rows.Count; iGioCongNgayChuNhat++)
                    {
                        dTongTangCaNgayChuNhat += Convert.ToDouble(dtGioCongNgayChuNhat.Rows[iGioCongNgayChuNhat]["TC1"].ToString()) + Convert.ToDouble(dtGioCongNgayChuNhat.Rows[iGioCongNgayChuNhat]["TC2"].ToString()) + Convert.ToDouble(dtGioCongNgayChuNhat.Rows[iGioCongNgayChuNhat]["TC3"].ToString()) + Convert.ToDouble(dtGioCongNgayChuNhat.Rows[iGioCongNgayChuNhat]["TC4"].ToString());
                    }
                    (ws_ChiTietTungNguoiTungNgay).get_Range((object)("D" + (iTongDong * demNhanVien + 5)), (object)("D" + (iTongDong * demNhanVien + 5))).Cells[1, 1] = dTongTangCaNgayChuNhat;
                    int iDemVangKhongPhepChiTietTungNguoiTungNgay;
                    iDemVangKhongPhepChiTietTungNguoiTungNgay = 0;
                    double iDemVangCoPhepChiTietTungNguoiTungNgay;
                    iDemVangCoPhepChiTietTungNguoiTungNgay = 0.0;
                    new DataTable();
                    _tinhCongDTO.MaChamCong = iMaChamCongChiTietTungNguoiTungNgay;
                    DataTable dtVangChiTietTungNguoiTungNgay;
                    dtVangChiTietTungNguoiTungNgay = _tinhCongBLL.TinhCongGetByMaChamCong(_tinhCongDTO);
                    for (int iVangChiTietTungNguoiTungNgay = 0; iVangChiTietTungNguoiTungNgay < dtVangChiTietTungNguoiTungNgay.Rows.Count; iVangChiTietTungNguoiTungNgay++)
                    {
                        string sThu2;
                        sThu2 = dtVangChiTietTungNguoiTungNgay.Rows[iVangChiTietTungNguoiTungNgay]["Thu"].ToString();
                        if (dtVangChiTietTungNguoiTungNgay.Rows[iVangChiTietTungNguoiTungNgay]["KyHieu"].ToString() == sKHVang && sThu2 != "CN")
                        {
                            iDemVangKhongPhepChiTietTungNguoiTungNgay++;
                        }
                        if (dtVangChiTietTungNguoiTungNgay.Rows[iVangChiTietTungNguoiTungNgay]["KyHieu"].ToString() == "CP")
                        {
                            iDemVangCoPhepChiTietTungNguoiTungNgay += Convert.ToDouble(dtVangChiTietTungNguoiTungNgay.Rows[iVangChiTietTungNguoiTungNgay]["Cong"].ToString());
                        }
                    }
                    (ws_ChiTietTungNguoiTungNgay).get_Range((object)("H" + (iTongDong * demNhanVien + 5)), (object)("H" + (iTongDong * demNhanVien + 5))).Cells[1, 1] = iDemVangKhongPhepChiTietTungNguoiTungNgay;
                    (ws_ChiTietTungNguoiTungNgay).get_Range((object)("L" + (iTongDong * demNhanVien + 5)), (object)("L" + (iTongDong * demNhanVien + 5))).Cells[1, 1] = iDemVangCoPhepChiTietTungNguoiTungNgay;
                    (ws_ChiTietTungNguoiTungNgay).get_Range((object)("H" + (iTongDong * demNhanVien + 3)), (object)("H" + (iTongDong * demNhanVien + 3))).Cells[1, 1] = iSoLanTreChiTietTungNguoiTungNgay;
                    (ws_ChiTietTungNguoiTungNgay).get_Range((object)("H" + (iTongDong * demNhanVien + 4)), (object)("H" + (iTongDong * demNhanVien + 4))).Cells[1, 1] = iSoLanVeSomChiTietTungNguoiTungNgay;
                    (ws_ChiTietTungNguoiTungNgay).get_Range((object)("L" + (iTongDong * demNhanVien + 3)), (object)("L" + (iTongDong * demNhanVien + 3))).Cells[1, 1] = iSoPhutTreChiTietTungNguoiTungNgay;
                    (ws_ChiTietTungNguoiTungNgay).get_Range((object)("L" + (iTongDong * demNhanVien + 4)), (object)("L" + (iTongDong * demNhanVien + 4))).Cells[1, 1] = iSoPhutVeSomChiTietTungNguoiTungNgay;
                    Excel.Range excelChiTietTungNguoiTungNgay_ChiTietHeader;
                    excelChiTietTungNguoiTungNgay_ChiTietHeader = (ws_ChiTietTungNguoiTungNgay).get_Range((object)("A" + (iTongDong * demNhanVien + 6)), (object)("P" + (iTongDong * demNhanVien + 6)));
                    excelChiTietTungNguoiTungNgay_ChiTietHeader.Cells[1, 1] = "Chi tiết";
                    excelChiTietTungNguoiTungNgay_ChiTietHeader.get_Range((object)"A1", (object)"P1").Merge(true);
                    Excel.Range excelChiTietTungNguoiTungNgay_NgayHeader;
                    excelChiTietTungNguoiTungNgay_NgayHeader = (ws_ChiTietTungNguoiTungNgay).get_Range((object)("A" + (iTongDong * demNhanVien + 7)), (object)("A" + (iTongDong * demNhanVien + 8)));
                    excelChiTietTungNguoiTungNgay_NgayHeader.Cells[1, 1] = "Ngày";
                    excelChiTietTungNguoiTungNgay_NgayHeader.get_Range((object)"A1", (object)"A2").MergeCells = true;
                    excelChiTietTungNguoiTungNgay_NgayHeader.ColumnWidth = 10;
                    Excel.Range excelChiTietTungNguoiTungNgay_ThuHeader;
                    excelChiTietTungNguoiTungNgay_ThuHeader = (ws_ChiTietTungNguoiTungNgay).get_Range((object)("B" + (iTongDong * demNhanVien + 7)), (object)("B" + (iTongDong * demNhanVien + 8)));
                    excelChiTietTungNguoiTungNgay_ThuHeader.Cells[1, 1] = "Thứ";
                    excelChiTietTungNguoiTungNgay_ThuHeader.get_Range((object)"A1", (object)"A2").MergeCells = true;
                    Excel.Range excelChiTietTungNguoiTungNgay_TreHeader;
                    excelChiTietTungNguoiTungNgay_TreHeader = (ws_ChiTietTungNguoiTungNgay).get_Range((object)("I" + (iTongDong * demNhanVien + 7)), (object)("I" + (iTongDong * demNhanVien + 8)));
                    excelChiTietTungNguoiTungNgay_TreHeader.Cells[1, 1] = "Trễ";
                    excelChiTietTungNguoiTungNgay_TreHeader.get_Range((object)"A1", (object)"A2").MergeCells = true;
                    Excel.Range excelChiTietTungNguoiTungNgay_SomHeader;
                    excelChiTietTungNguoiTungNgay_SomHeader = (ws_ChiTietTungNguoiTungNgay).get_Range((object)("J" + (iTongDong * demNhanVien + 7)), (object)("J" + (iTongDong * demNhanVien + 8)));
                    excelChiTietTungNguoiTungNgay_SomHeader.Cells[1, 1] = "Sớm";
                    excelChiTietTungNguoiTungNgay_SomHeader.get_Range((object)"A1", (object)"A2").MergeCells = true;
                    Excel.Range excelChiTietTungNguoiTungNgay_VeTreHeader;
                    excelChiTietTungNguoiTungNgay_VeTreHeader = (ws_ChiTietTungNguoiTungNgay).get_Range((object)("K" + (iTongDong * demNhanVien + 7)), (object)("K" + (iTongDong * demNhanVien + 8)));
                    excelChiTietTungNguoiTungNgay_VeTreHeader.Cells[1, 1] = "Về trễ";
                    excelChiTietTungNguoiTungNgay_VeTreHeader.get_Range((object)"A1", (object)"A2").MergeCells = true;
                    Excel.Range excelChiTietTungNguoiTungNgay_GioHeader;
                    excelChiTietTungNguoiTungNgay_GioHeader = (ws_ChiTietTungNguoiTungNgay).get_Range((object)("L" + (iTongDong * demNhanVien + 7)), (object)("L" + (iTongDong * demNhanVien + 8)));
                    excelChiTietTungNguoiTungNgay_GioHeader.Cells[1, 1] = "Giờ";
                    excelChiTietTungNguoiTungNgay_GioHeader.get_Range((object)"A1", (object)"A2").MergeCells = true;
                    Excel.Range excelChiTietTungNguoiTungNgay_CongHeader;
                    excelChiTietTungNguoiTungNgay_CongHeader = (ws_ChiTietTungNguoiTungNgay).get_Range((object)("M" + (iTongDong * demNhanVien + 7)), (object)("M" + (iTongDong * demNhanVien + 8)));
                    excelChiTietTungNguoiTungNgay_CongHeader.Cells[1, 1] = "Công";
                    excelChiTietTungNguoiTungNgay_CongHeader.get_Range((object)"A1", (object)"A2").MergeCells = true;
                    Excel.Range excelChiTietTungNguoiTungNgay_TangCa1Header;
                    excelChiTietTungNguoiTungNgay_TangCa1Header = (ws_ChiTietTungNguoiTungNgay).get_Range((object)("N" + (iTongDong * demNhanVien + 7)), (object)("N" + (iTongDong * demNhanVien + 8)));
                    excelChiTietTungNguoiTungNgay_TangCa1Header.Cells[1, 1] = "T.Ca1";
                    excelChiTietTungNguoiTungNgay_TangCa1Header.get_Range((object)"A1", (object)"A2").MergeCells = true;
                    Excel.Range excelChiTietTungNguoiTungNgay_TangCa2Header;
                    excelChiTietTungNguoiTungNgay_TangCa2Header = (ws_ChiTietTungNguoiTungNgay).get_Range((object)("O" + (iTongDong * demNhanVien + 7)), (object)("O" + (iTongDong * demNhanVien + 8)));
                    excelChiTietTungNguoiTungNgay_TangCa2Header.Cells[1, 1] = "T.Ca2";
                    excelChiTietTungNguoiTungNgay_TangCa2Header.get_Range((object)"A1", (object)"A2").MergeCells = true;
                    Excel.Range excelChiTietTungNguoiTungNgay_KyHieuHeader;
                    excelChiTietTungNguoiTungNgay_KyHieuHeader = (ws_ChiTietTungNguoiTungNgay).get_Range((object)("P" + (iTongDong * demNhanVien + 7)), (object)("P" + (iTongDong * demNhanVien + 8)));
                    excelChiTietTungNguoiTungNgay_KyHieuHeader.Cells[1, 1] = "Ký hiệu";
                    excelChiTietTungNguoiTungNgay_KyHieuHeader.get_Range((object)"A1", (object)"A2").MergeCells = true;
                    Excel.Range excelChiTietTungNguoiTungNgay_1Header;
                    excelChiTietTungNguoiTungNgay_1Header = (ws_ChiTietTungNguoiTungNgay).get_Range((object)("C" + (iTongDong * demNhanVien + 7)), (object)("D" + (iTongDong * demNhanVien + 7)));
                    excelChiTietTungNguoiTungNgay_1Header.Cells[1, 1] = "1";
                    excelChiTietTungNguoiTungNgay_1Header.get_Range((object)"A1", (object)"B1").Merge(true);
                    Excel.Range excelChiTietTungNguoiTungNgay_2Header;
                    excelChiTietTungNguoiTungNgay_2Header = (ws_ChiTietTungNguoiTungNgay).get_Range((object)("E" + (iTongDong * demNhanVien + 7)), (object)("F" + (iTongDong * demNhanVien + 7)));
                    excelChiTietTungNguoiTungNgay_2Header.Cells[1, 1] = "2";
                    excelChiTietTungNguoiTungNgay_2Header.get_Range((object)"A1", (object)"B1").Merge(true);
                    Excel.Range excelChiTietTungNguoiTungNgay_3Header;
                    excelChiTietTungNguoiTungNgay_3Header = (ws_ChiTietTungNguoiTungNgay).get_Range((object)("G" + (iTongDong * demNhanVien + 7)), (object)("H" + (iTongDong * demNhanVien + 7)));
                    excelChiTietTungNguoiTungNgay_3Header.Cells[1, 1] = "3";
                    excelChiTietTungNguoiTungNgay_3Header.get_Range((object)"A1", (object)"B1").Merge(true);
                    (ws_ChiTietTungNguoiTungNgay).get_Range((object)("C" + (iTongDong * demNhanVien + 8)), (object)("C" + (iTongDong * demNhanVien + 8))).Cells[1, 1] = "Vào";
                    (ws_ChiTietTungNguoiTungNgay).get_Range((object)("D" + (iTongDong * demNhanVien + 8)), (object)("D" + (iTongDong * demNhanVien + 8))).Cells[1, 1] = "Ra";
                    (ws_ChiTietTungNguoiTungNgay).get_Range((object)("E" + (iTongDong * demNhanVien + 8)), (object)("E" + (iTongDong * demNhanVien + 8))).Cells[1, 1] = "Vào";
                    (ws_ChiTietTungNguoiTungNgay).get_Range((object)("F" + (iTongDong * demNhanVien + 8)), (object)("F" + (iTongDong * demNhanVien + 8))).Cells[1, 1] = "Ra";
                    (ws_ChiTietTungNguoiTungNgay).get_Range((object)("G" + (iTongDong * demNhanVien + 8)), (object)("G" + (iTongDong * demNhanVien + 8))).Cells[1, 1] = "Vào";
                    (ws_ChiTietTungNguoiTungNgay).get_Range((object)("H" + (iTongDong * demNhanVien + 8)), (object)("H" + (iTongDong * demNhanVien + 8))).Cells[1, 1] = "Ra";
                    Excel.Range excelChiTietTungNguoiTungNgay_DinhDangHeader;
                    excelChiTietTungNguoiTungNgay_DinhDangHeader = (ws_ChiTietTungNguoiTungNgay).get_Range((object)("A" + (iTongDong * demNhanVien + 3)), (object)("P" + (iTongDong * demNhanVien + 8)));
                    excelChiTietTungNguoiTungNgay_DinhDangHeader.Font.Name = "Times New Roman";
                    excelChiTietTungNguoiTungNgay_DinhDangHeader.Font.Size = "11";
                    excelChiTietTungNguoiTungNgay_DinhDangHeader.Font.Bold = true;
                    int demNgay;
                    demNgay = 9;
                    for (int _tongNgay = 0; _tongNgay < iTongNgayChamChiTietTungNguoiTungNgay; _tongNgay++)
                    {
                        DateTime dNgayChamChiTietTungNguoiTungNgay;
                        dNgayChamChiTietTungNguoiTungNgay = dateTimeTuNgay.Value;
                        DateTime dNgayChamDuLieu;
                        dNgayChamDuLieu = Convert.ToDateTime(dNgayBatDauTinhCong.AddDays(_tongNgay).ToString());
                        Excel.Range excelChiTietTungNguoiTungNgay_NgayDuLieu;
                        excelChiTietTungNguoiTungNgay_NgayDuLieu = (ws_ChiTietTungNguoiTungNgay).get_Range((object)("A" + (iTongDong * demNhanVien + demNgay)), (object)("A" + (iTongDong * demNhanVien + demNgay)));
                        excelChiTietTungNguoiTungNgay_NgayDuLieu.Cells[1, 1] = dNgayChamDuLieu;
                        excelChiTietTungNguoiTungNgay_NgayDuLieu.get_Range((object)"A1", (object)"A1").Merge(true);
                        (ws_ChiTietTungNguoiTungNgay).get_Range((object)("B" + (iTongDong * demNhanVien + demNgay)), (object)("B" + (iTongDong * demNhanVien + demNgay))).Cells[1, 1] = DateTimeProgress.XuatThuTinhCong((int)dNgayChamChiTietTungNguoiTungNgay.AddDays(_tongNgay).DayOfWeek);
                        string sThu;
                        sThu = "";
                        int iDemSoLanChamChiTietTungNguoiTungNgay;
                        iDemSoLanChamChiTietTungNguoiTungNgay = 0;
                        int iTreChiTietTungNguoiTungNgay;
                        iTreChiTietTungNguoiTungNgay = 0;
                        int iVeSomChiTietTungNguoiTungNgay;
                        iVeSomChiTietTungNguoiTungNgay = 0;
                        int iVeTreChiTietTungNguoiTungNgay;
                        iVeTreChiTietTungNguoiTungNgay = 0;
                        double dGioChiTietTungNguoiTungNgay;
                        dGioChiTietTungNguoiTungNgay = 0.0;
                        double dCongChiTietTungNguoiTungNgay;
                        dCongChiTietTungNguoiTungNgay = 0.0;
                        double dTC1ChiTietTungNguoiTungNgay;
                        dTC1ChiTietTungNguoiTungNgay = 0.0;
                        double dTC2ChiTietTungNguoiTungNgay;
                        dTC2ChiTietTungNguoiTungNgay = 0.0;
                        string sGioVao;
                        sGioVao = "";
                        string sGioRa;
                        sGioRa = "";
                        new DataTable();
                        _tinhCongDTO.MaChamCong = iMaChamCongChiTietTungNguoiTungNgay;
                        _tinhCongDTO.Ngay = dNgayChamDuLieu;
                        DataTable dtLoadGioChamCongChiTietTungNguoiTungNgay;
                        dtLoadGioChamCongChiTietTungNguoiTungNgay = _tinhCongBLL.TinhCongGetMaChamCongAndNgayChiTietTungNguoiTungNgay(_tinhCongDTO);
                        for (int iLoadGioChamCongChiTietTungNguoiTungNgay = 0; iLoadGioChamCongChiTietTungNguoiTungNgay < dtLoadGioChamCongChiTietTungNguoiTungNgay.Rows.Count; iLoadGioChamCongChiTietTungNguoiTungNgay++)
                        {
                            sThu = dtLoadGioChamCongChiTietTungNguoiTungNgay.Rows[iLoadGioChamCongChiTietTungNguoiTungNgay]["Thu"].ToString();
                            string sGioVaoChiTietTungNguoiTungNgay;
                            sGioVaoChiTietTungNguoiTungNgay = dtLoadGioChamCongChiTietTungNguoiTungNgay.Rows[iLoadGioChamCongChiTietTungNguoiTungNgay]["GioVao"].ToString();
                            string sGioRaChiTietTungNguoiTungNgay;
                            sGioRaChiTietTungNguoiTungNgay = dtLoadGioChamCongChiTietTungNguoiTungNgay.Rows[iLoadGioChamCongChiTietTungNguoiTungNgay]["GioRa"].ToString();
                            if (sGioVaoChiTietTungNguoiTungNgay != "")
                            {
                                DateTime dGioVao;
                                dGioVao = Convert.ToDateTime(sGioVaoChiTietTungNguoiTungNgay);
                                sGioVao = dGioVao.Hour + ":" + dGioVao.Minute;
                            }
                            if (sGioRaChiTietTungNguoiTungNgay != "")
                            {
                                DateTime dGioRa;
                                dGioRa = Convert.ToDateTime(sGioRaChiTietTungNguoiTungNgay);
                                sGioRa = dGioRa.Hour + ":" + dGioRa.Minute;
                            }
                            iDemSoLanChamChiTietTungNguoiTungNgay++;
                            if (iDemSoLanChamChiTietTungNguoiTungNgay == 1)
                            {
                                (ws_ChiTietTungNguoiTungNgay).get_Range((object)("C" + (iTongDong * demNhanVien + demNgay)), (object)("C" + (iTongDong * demNhanVien + demNgay))).Cells[1, 1] = sGioVao;
                                (ws_ChiTietTungNguoiTungNgay).get_Range((object)("D" + (iTongDong * demNhanVien + demNgay)), (object)("D" + (iTongDong * demNhanVien + demNgay))).Cells[1, 1] = sGioRa;
                            }
                            if (iDemSoLanChamChiTietTungNguoiTungNgay == 2)
                            {
                                (ws_ChiTietTungNguoiTungNgay).get_Range((object)("E" + (iTongDong * demNhanVien + demNgay)), (object)("E" + (iTongDong * demNhanVien + demNgay))).Cells[1, 1] = sGioVao;
                                (ws_ChiTietTungNguoiTungNgay).get_Range((object)("F" + (iTongDong * demNhanVien + demNgay)), (object)("F" + (iTongDong * demNhanVien + demNgay))).Cells[1, 1] = sGioRa;
                            }
                            if (iDemSoLanChamChiTietTungNguoiTungNgay == 3)
                            {
                                (ws_ChiTietTungNguoiTungNgay).get_Range((object)("G" + (iTongDong * demNhanVien + demNgay)), (object)("G" + (iTongDong * demNhanVien + demNgay))).Cells[1, 1] = sGioVao;
                                (ws_ChiTietTungNguoiTungNgay).get_Range((object)("H" + (iTongDong * demNhanVien + demNgay)), (object)("H" + (iTongDong * demNhanVien + demNgay))).Cells[1, 1] = sGioRa;
                            }
                            iTreChiTietTungNguoiTungNgay += Convert.ToInt32(dtLoadGioChamCongChiTietTungNguoiTungNgay.Rows[iLoadGioChamCongChiTietTungNguoiTungNgay]["Tre"].ToString());
                            iVeSomChiTietTungNguoiTungNgay += Convert.ToInt32(dtLoadGioChamCongChiTietTungNguoiTungNgay.Rows[iLoadGioChamCongChiTietTungNguoiTungNgay]["VeSom"].ToString());
                            iVeTreChiTietTungNguoiTungNgay += Convert.ToInt32(dtLoadGioChamCongChiTietTungNguoiTungNgay.Rows[iLoadGioChamCongChiTietTungNguoiTungNgay]["VeTre"].ToString());
                            dGioChiTietTungNguoiTungNgay += Convert.ToDouble(dtLoadGioChamCongChiTietTungNguoiTungNgay.Rows[iLoadGioChamCongChiTietTungNguoiTungNgay]["Gio"].ToString());
                            dCongChiTietTungNguoiTungNgay += Convert.ToDouble(dtLoadGioChamCongChiTietTungNguoiTungNgay.Rows[iLoadGioChamCongChiTietTungNguoiTungNgay]["Cong"].ToString());
                            dTC1ChiTietTungNguoiTungNgay += Convert.ToDouble(dtLoadGioChamCongChiTietTungNguoiTungNgay.Rows[iLoadGioChamCongChiTietTungNguoiTungNgay]["TC1"].ToString());
                            dTC2ChiTietTungNguoiTungNgay += Convert.ToDouble(dtLoadGioChamCongChiTietTungNguoiTungNgay.Rows[iLoadGioChamCongChiTietTungNguoiTungNgay]["TC2"].ToString());
                            (ws_ChiTietTungNguoiTungNgay).get_Range((object)("P" + (iTongDong * demNhanVien + demNgay)), (object)("P" + (iTongDong * demNhanVien + demNgay))).Cells[1, 1] = dtLoadGioChamCongChiTietTungNguoiTungNgay.Rows[iLoadGioChamCongChiTietTungNguoiTungNgay]["KyHieu"].ToString();
                            sGioVao = "";
                            sGioRa = "";
                        }
                        (ws_ChiTietTungNguoiTungNgay).get_Range((object)("I" + (iTongDong * demNhanVien + demNgay)), (object)("I" + (iTongDong * demNhanVien + demNgay))).Cells[1, 1] = iTreChiTietTungNguoiTungNgay;
                        (ws_ChiTietTungNguoiTungNgay).get_Range((object)("J" + (iTongDong * demNhanVien + demNgay)), (object)("J" + (iTongDong * demNhanVien + demNgay))).Cells[1, 1] = iVeSomChiTietTungNguoiTungNgay;
                        (ws_ChiTietTungNguoiTungNgay).get_Range((object)("K" + (iTongDong * demNhanVien + demNgay)), (object)("K" + (iTongDong * demNhanVien + demNgay))).Cells[1, 1] = iVeTreChiTietTungNguoiTungNgay;
                        (ws_ChiTietTungNguoiTungNgay).get_Range((object)("L" + (iTongDong * demNhanVien + demNgay)), (object)("L" + (iTongDong * demNhanVien + demNgay))).Cells[1, 1] = dGioChiTietTungNguoiTungNgay;
                        (ws_ChiTietTungNguoiTungNgay).get_Range((object)("M" + (iTongDong * demNhanVien + demNgay)), (object)("M" + (iTongDong * demNhanVien + demNgay))).Cells[1, 1] = dCongChiTietTungNguoiTungNgay;
                        (ws_ChiTietTungNguoiTungNgay).get_Range((object)("N" + (iTongDong * demNhanVien + demNgay)), (object)("N" + (iTongDong * demNhanVien + demNgay))).Cells[1, 1] = dTC1ChiTietTungNguoiTungNgay;
                        (ws_ChiTietTungNguoiTungNgay).get_Range((object)("O" + (iTongDong * demNhanVien + demNgay)), (object)("O" + (iTongDong * demNhanVien + demNgay))).Cells[1, 1] = dTC2ChiTietTungNguoiTungNgay;
                        Excel.Range excelChiTietTungNguoiTungNgay_DinhDangDuLieu;
                        excelChiTietTungNguoiTungNgay_DinhDangDuLieu = (ws_ChiTietTungNguoiTungNgay).get_Range((object)("A" + (iTongDong * demNhanVien + demNgay)), (object)("P" + (iTongDong * demNhanVien + demNgay)));
                        if (sThu == "CN")
                        {
                            excelChiTietTungNguoiTungNgay_DinhDangDuLieu.Interior.Color = ColorTranslator.ToOle(Color.Aqua);
                        }
                        iDemNVProCess++;
                        demNgay++;
                    }
                    Excel.Range excelChiTietTungNguoiTungNgay_DinhDangDuLieuDuLieu;
                    excelChiTietTungNguoiTungNgay_DinhDangDuLieuDuLieu = (ws_ChiTietTungNguoiTungNgay).get_Range((object)("A" + (iTongDong * demNhanVien + demNgay)), (object)("A" + (iTongDong * demNhanVien + demNgay)));
                    excelChiTietTungNguoiTungNgay_DinhDangDuLieuDuLieu.Font.Name = "Times New Roman";
                    excelChiTietTungNguoiTungNgay_DinhDangDuLieuDuLieu.Font.Size = "10";
                    excelChiTietTungNguoiTungNgay_DinhDangDuLieuDuLieu.HorizontalAlignment = Excel.Constants.xlCenter;
                    Excel.Range excelChiTietTungNguoiTungNgay_DinhDangDuLieuHeader;
                    excelChiTietTungNguoiTungNgay_DinhDangDuLieuHeader = (ws_ChiTietTungNguoiTungNgay).get_Range((object)("A" + (iTongDong * demNhanVien + 6)), (object)("R" + (iTongDong * demNhanVien + demNgay - 1)));
                    excelChiTietTungNguoiTungNgay_DinhDangDuLieuHeader.HorizontalAlignment = Excel.Constants.xlCenter;
                    excelChiTietTungNguoiTungNgay_DinhDangDuLieuHeader.Font.Name = "Times New Roman";
                    excelChiTietTungNguoiTungNgay_DinhDangDuLieuHeader.Font.Size = "11";
                    (ws_ChiTietTungNguoiTungNgay).get_Range((object)("A" + (iTongDong * demNhanVien + 1)), (object)("P" + (iTongDong * demNhanVien + demNgay - 1))).Borders.LineStyle = Excel.Constants.xlBoth;
                    demNhanVien++;
                }
            }
            ws_ChiTietTungNguoiTungNgay.PageSetup.Orientation = Excel.XlPageOrientation.xlLandscape;
            ws_ChiTietTungNguoiTungNgay.PageSetup.PaperSize = Excel.XlPaperSize.xlPaperA4;
            ws_ChiTietTungNguoiTungNgay.PageSetup.LeftMargin = 13.0;
            ws_ChiTietTungNguoiTungNgay.PageSetup.RightMargin = 0.0;
            ws_ChiTietTungNguoiTungNgay.PageSetup.BottomMargin = 0.0;
            ws_ChiTietTungNguoiTungNgay.PageSetup.TopMargin = 0.0;
            ws_ChiTietTungNguoiTungNgay.PageSetup.Zoom = 92;
        }

        private void ExportExcelThongKeThangCong()
        {
            testProcess = iDemNhanVienDuocChon;
            demProcess = -1;
            DateTime dNgayTinh;
            dNgayTinh = Convert.ToDateTime(dateTimeTuNgay.Text);
            DateTime dNgayBatDauTinhCong;
            dNgayBatDauTinhCong = new DateTime(dNgayTinh.Year, dNgayTinh.Month, dNgayTinh.Day, 0, 0, 0);
            _ = Thread.CurrentThread.CurrentCulture;
            Thread.CurrentThread.CurrentCulture = new CultureInfo("en-US");
            Excel.Application xla_ThongKeThangCong;
            xla_ThongKeThangCong = new Excel.Application();
            xla_ThongKeThangCong.Workbooks.Add(Excel.XlSheetType.xlWorksheet);
            _ = xla_ThongKeThangCong.ActiveSheet;
            Excel.Worksheet ws_ThongKeThangCong;
            ws_ThongKeThangCong = xla_ThongKeThangCong.Worksheets.get_Item((object)1);
            bool failed;
            do
            {
                try
                {
                    Excel.Range excelThongKeThangCong_CongTyHeader;
                    excelThongKeThangCong_CongTyHeader = (ws_ThongKeThangCong).get_Range((object)"A1", (object)"AT1");
                    excelThongKeThangCong_CongTyHeader.Cells[1, 1] = sTenCongTyReport;
                    excelThongKeThangCong_CongTyHeader.get_Range((object)"A1", (object)"AT1").Merge(true);
                    Excel.Range excelThongKeThangCong_DiaChiHeader;
                    excelThongKeThangCong_DiaChiHeader = (ws_ThongKeThangCong).get_Range((object)"A2", (object)"AT2");
                    excelThongKeThangCong_DiaChiHeader.Cells[1, 1] = sDiaChiCongTyReport;
                    excelThongKeThangCong_DiaChiHeader.get_Range((object)"A1", (object)"AT1").Merge(true);
                    Excel.Range excelThongKeThangCong_DinhDangCongTy;
                    excelThongKeThangCong_DinhDangCongTy = (ws_ThongKeThangCong).get_Range((object)"A1", (object)"AT2");
                    excelThongKeThangCong_DinhDangCongTy.Font.Name = "Times New Roman";
                    excelThongKeThangCong_DinhDangCongTy.Font.Size = "10";
                    excelThongKeThangCong_DinhDangCongTy.Font.Bold = true;
                    Excel.Range excelThongKeThangCong_TieuDeHeader;
                    excelThongKeThangCong_TieuDeHeader = (ws_ThongKeThangCong).get_Range((object)"A4", (object)"AT4");
                    excelThongKeThangCong_TieuDeHeader.Cells[1, 1] = "BẢNG CHẤM CÔNG";
                    excelThongKeThangCong_TieuDeHeader.get_Range((object)"A1", (object)"AT1").Merge(true);
                    excelThongKeThangCong_TieuDeHeader.Font.Name = "Times New Roman";
                    excelThongKeThangCong_TieuDeHeader.Font.Size = "14";
                    excelThongKeThangCong_TieuDeHeader.Font.Bold = true;
                    excelThongKeThangCong_TieuDeHeader.HorizontalAlignment = Excel.Constants.xlCenter;
                    Excel.Range excelThongKeThangCong_TuNgayDenNgayHeader;
                    excelThongKeThangCong_TuNgayDenNgayHeader = (ws_ThongKeThangCong).get_Range((object)"A5", (object)"AS5");
                    excelThongKeThangCong_TuNgayDenNgayHeader.Cells[1, 1] = "Từ ngày " + dateTimeTuNgay.Text + " đến ngày " + dateTimeDenNgay.Text;
                    excelThongKeThangCong_TuNgayDenNgayHeader.get_Range((object)"A1", (object)"AT1").Merge(true);
                    excelThongKeThangCong_TuNgayDenNgayHeader.Font.Name = "Times New Roman";
                    excelThongKeThangCong_TuNgayDenNgayHeader.Font.Size = "10";
                    excelThongKeThangCong_TuNgayDenNgayHeader.Font.Bold = true;
                    excelThongKeThangCong_TuNgayDenNgayHeader.HorizontalAlignment = Excel.Constants.xlCenter;
                    Excel.Range excelThongKeThangCong_STTHeader;
                    excelThongKeThangCong_STTHeader = (ws_ThongKeThangCong).get_Range((object)"A7", (object)"A9");
                    excelThongKeThangCong_STTHeader.Cells[1, 1] = "STT";
                    excelThongKeThangCong_STTHeader.get_Range((object)"A1", (object)"A3").MergeCells = true;
                    Excel.Range excelThongKeThangCong_MaNhanVienHeader;
                    excelThongKeThangCong_MaNhanVienHeader = (ws_ThongKeThangCong).get_Range((object)"B7", (object)"B9");
                    excelThongKeThangCong_MaNhanVienHeader.Cells[1, 1] = "MÃ NHÂN VIÊN";
                    excelThongKeThangCong_MaNhanVienHeader.get_Range((object)"A1", (object)"A3").MergeCells = true;
                    excelThongKeThangCong_MaNhanVienHeader.ColumnWidth = 15;
                    Excel.Range excelThongKeThangCong_HoTenHeader;
                    excelThongKeThangCong_HoTenHeader = (ws_ThongKeThangCong).get_Range((object)"C7", (object)"C9");
                    excelThongKeThangCong_HoTenHeader.Cells[1, 1] = "HỌ TÊN";
                    excelThongKeThangCong_HoTenHeader.get_Range((object)"A1", (object)"A3").MergeCells = true;
                    excelThongKeThangCong_HoTenHeader.ColumnWidth = 17;
                    Excel.Range excelThongKeThangCong_PhongBanHeader;
                    excelThongKeThangCong_PhongBanHeader = (ws_ThongKeThangCong).get_Range((object)"D7", (object)"D9");
                    excelThongKeThangCong_PhongBanHeader.Cells[1, 1] = "PHÒNG BAN";
                    excelThongKeThangCong_PhongBanHeader.get_Range((object)"A1", (object)"A3").MergeCells = true;
                    excelThongKeThangCong_PhongBanHeader.ColumnWidth = 13;
                    Excel.Range excelThongKeThangCong_ChucVuHeader;
                    excelThongKeThangCong_ChucVuHeader = (ws_ThongKeThangCong).get_Range((object)"E7", (object)"E9");
                    excelThongKeThangCong_ChucVuHeader.Cells[1, 1] = "NGÀY VÀO LÀM";
                    excelThongKeThangCong_ChucVuHeader.get_Range((object)"A1", (object)"A3").MergeCells = true;
                    excelThongKeThangCong_ChucVuHeader.ColumnWidth = 15;
                    Excel.Range excelThongKeThangCong_SoNgayLamViecHeader;
                    excelThongKeThangCong_SoNgayLamViecHeader = (ws_ThongKeThangCong).get_Range((object)"F7", (object)"AJ7");
                    excelThongKeThangCong_SoNgayLamViecHeader.Cells[1, 1] = "SỐ NGÀY LÀM VIỆC TRONG THÁNG";
                    excelThongKeThangCong_SoNgayLamViecHeader.get_Range((object)"A1", (object)"AE1").Merge(true);
                    xla_ThongKeThangCong.Visible = true;
                    int ColunmNgay;
                    ColunmNgay = 6;
                    for (int iThongKeThang_Cong2 = 0; iThongKeThang_Cong2 < 31; iThongKeThang_Cong2++)
                    {
                        DateTime dtNgayChamThongKeThangCong;
                        dtNgayChamThongKeThangCong = dateTimeTuNgay.Value;
                        int iNgayChamThongKeThangCong;
                        iNgayChamThongKeThangCong = Convert.ToInt32(Convert.ToDateTime(dtNgayChamThongKeThangCong.AddDays(iThongKeThang_Cong2).ToString()).Day);
                        Excel.Range excelThongKeThangCong_Ngay;
                        excelThongKeThangCong_Ngay = (ws_ThongKeThangCong).get_Range((object)"F8", (object)"AJ9");
                        xla_ThongKeThangCong.Cells[8, ColunmNgay] = iNgayChamThongKeThangCong;
                        DateTimeProgress.XuatThuReport((int)dtNgayChamThongKeThangCong.AddDays(iThongKeThang_Cong2).DayOfWeek);
                        xla_ThongKeThangCong.Cells[9, ColunmNgay] = DateTimeProgress.XuatThuReport((int)dtNgayChamThongKeThangCong.AddDays(iThongKeThang_Cong2).DayOfWeek);
                        ColunmNgay++;
                        excelThongKeThangCong_Ngay.ColumnWidth = 5;
                    }
                    Excel.Range excelThongKeThangCong_TongNgayCongHeader;
                    excelThongKeThangCong_TongNgayCongHeader = (ws_ThongKeThangCong).get_Range((object)"AK7", (object)"AK9");
                    excelThongKeThangCong_TongNgayCongHeader.Cells[1, 1] = "TỔNG NGÀY CÔNG";
                    excelThongKeThangCong_TongNgayCongHeader.get_Range((object)"A1", (object)"A3").MergeCells = true;
                    excelThongKeThangCong_TongNgayCongHeader.ColumnWidth = 17;
                    Excel.Range excelThongKeThangCong_TangCaHeader;
                    excelThongKeThangCong_TangCaHeader = (ws_ThongKeThangCong).get_Range((object)"AL7", (object)"AM8");
                    excelThongKeThangCong_TangCaHeader.Cells[1, 1] = "TĂNG CA";
                    excelThongKeThangCong_TangCaHeader.get_Range((object)"A1", (object)"B2").MergeCells = true;
                    Excel.Range excelThongKeThangCong_BTTangCaHeader;
                    excelThongKeThangCong_BTTangCaHeader = (ws_ThongKeThangCong).get_Range((object)"AL9", (object)"AL9");
                    excelThongKeThangCong_BTTangCaHeader.Cells[1, 1] = "BT";
                    excelThongKeThangCong_BTTangCaHeader.get_Range((object)"A1", (object)"A1").MergeCells = true;
                    Excel.Range excelThongKeThangCong_CNTangCaHeader;
                    excelThongKeThangCong_CNTangCaHeader = (ws_ThongKeThangCong).get_Range((object)"AM9", (object)"AM9");
                    excelThongKeThangCong_CNTangCaHeader.Cells[1, 1] = "CN";
                    excelThongKeThangCong_CNTangCaHeader.get_Range((object)"A1", (object)"A1").MergeCells = true;
                    Excel.Range excelThongKeThangCong_SoPhutHeader;
                    excelThongKeThangCong_SoPhutHeader = (ws_ThongKeThangCong).get_Range((object)"AN7", (object)"AP8");
                    excelThongKeThangCong_SoPhutHeader.Cells[1, 1] = "SỐ PHÚT";
                    excelThongKeThangCong_SoPhutHeader.get_Range((object)"A1", (object)"C2").MergeCells = true;
                    (ws_ThongKeThangCong).get_Range((object)"AN9", (object)"AN9").Cells[1, 1] = "Trễ";
                    (ws_ThongKeThangCong).get_Range((object)"AO9", (object)"AO9").Cells[1, 1] = "Sớm";
                    (ws_ThongKeThangCong).get_Range((object)"AP9", (object)"AP9").Cells[1, 1] = "TC";
                    Excel.Range excelThongKeThangCong_NghiHeader;
                    excelThongKeThangCong_NghiHeader = (ws_ThongKeThangCong).get_Range((object)"AQ7", (object)"AT8");
                    excelThongKeThangCong_NghiHeader.Cells[1, 1] = "NGHỈ";
                    excelThongKeThangCong_NghiHeader.get_Range((object)"A1", (object)"D2").MergeCells = true;
                    (ws_ThongKeThangCong).get_Range((object)"AQ9", (object)"AQ9").Cells[1, 1] = "Phép";
                    (ws_ThongKeThangCong).get_Range((object)"AR9", (object)"AR9").Cells[1, 1] = "Lễ";
                    Excel.Range excelThongKeThangCong_NghiCoLuongNghiHeader;
                    excelThongKeThangCong_NghiCoLuongNghiHeader = (ws_ThongKeThangCong).get_Range((object)"AS9", (object)"AS9");
                    excelThongKeThangCong_NghiCoLuongNghiHeader.Cells[1, 1] = "N.Có Lương";
                    excelThongKeThangCong_NghiCoLuongNghiHeader.ColumnWidth = 11;
                    Excel.Range excelThongKeThangCong_NghiKhongLuongNghiHeader;
                    excelThongKeThangCong_NghiKhongLuongNghiHeader = (ws_ThongKeThangCong).get_Range((object)"AT9", (object)"AT9");
                    excelThongKeThangCong_NghiKhongLuongNghiHeader.Cells[1, 1] = "N.Không Lương";
                    excelThongKeThangCong_NghiKhongLuongNghiHeader.ColumnWidth = 14;
                    int iTangHang;
                    iTangHang = 9;
                    int iDemDongThongKeThangCong;
                    iDemDongThongKeThangCong = 10;
                    int iDemSTTThongKeThangCong;
                    iDemSTTThongKeThangCong = 1;
                    new DataTable();
                    DataTable dtNgayTinhCongThongKeThangCong;
                    dtNgayTinhCongThongKeThangCong = _ngayTinhCongBLL.showThongTinNgayTinhCong();
                    for (int iNgayTinhCongThongKeThangCong = 0; iNgayTinhCongThongKeThangCong < dtNgayTinhCongThongKeThangCong.Rows.Count; iNgayTinhCongThongKeThangCong++)
                    {
                        Convert.ToDateTime(dtNgayTinhCongThongKeThangCong.Rows[iNgayTinhCongThongKeThangCong]["NgayBatDau"].ToString());
                        new DataTable();
                        _tinhCongDTO.Ngay = dNgayBatDauTinhCong;
                        DataTable dtNhanVienThongKeThangCong;
                        dtNhanVienThongKeThangCong = _tinhCongBLL.TinhCongGetNgay(_tinhCongDTO);
                        int iMaChamCongThongKeThangCong;
                        iMaChamCongThongKeThangCong = 0;
                        for (int iNhanVienThongKeThangCong = 0; iNhanVienThongKeThangCong < dtNhanVienThongKeThangCong.Rows.Count; iNhanVienThongKeThangCong++)
                        {
                            if (Convert.ToInt32(dtNhanVienThongKeThangCong.Rows[iNhanVienThongKeThangCong]["MaChamCong"].ToString()) == iMaChamCongThongKeThangCong)
                            {
                                continue;
                            }
                            iMaChamCongThongKeThangCong = Convert.ToInt32(dtNhanVienThongKeThangCong.Rows[iNhanVienThongKeThangCong]["MaChamCong"].ToString());
                            string sMaNhanVienThongKeThangCong;
                            sMaNhanVienThongKeThangCong = dtNhanVienThongKeThangCong.Rows[iNhanVienThongKeThangCong]["MaNhanVien"].ToString();
                            string sTenNhanVienThongKeThangCong;
                            sTenNhanVienThongKeThangCong = dtNhanVienThongKeThangCong.Rows[iNhanVienThongKeThangCong]["TenNhanVien"].ToString();
                            string sMaPhongBanThongKeThangCong;
                            sMaPhongBanThongKeThangCong = dtNhanVienThongKeThangCong.Rows[iNhanVienThongKeThangCong]["PhongBan"].ToString();
                            Excel.Range excelThongKeThangCongSTTDuLieu;
                            excelThongKeThangCongSTTDuLieu = (ws_ThongKeThangCong).get_Range((object)("A" + iDemDongThongKeThangCong), (object)("A" + iDemDongThongKeThangCong));
                            excelThongKeThangCongSTTDuLieu.Cells[1, 1] = iDemSTTThongKeThangCong;
                            excelThongKeThangCongSTTDuLieu.Select();
                            Excel.Range excelThongKeThangCongMaNhanVienDuLieu;
                            excelThongKeThangCongMaNhanVienDuLieu = (ws_ThongKeThangCong).get_Range((object)("B" + iDemDongThongKeThangCong), (object)("B" + iDemDongThongKeThangCong));
                            excelThongKeThangCongMaNhanVienDuLieu.get_Range((object)"A1", (object)"A1").NumberFormat = "@";
                            excelThongKeThangCongMaNhanVienDuLieu.Cells[1, 1] = sMaNhanVienThongKeThangCong;
                            (ws_ThongKeThangCong).get_Range((object)("C" + iDemDongThongKeThangCong), (object)("C" + iDemDongThongKeThangCong)).Cells[1, 1] = sTenNhanVienThongKeThangCong;
                            int iDemPhongBanThongKeThangCong;
                            iDemPhongBanThongKeThangCong = 0;
                            string sTenPhongBanThongKeThangCong;
                            sTenPhongBanThongKeThangCong = "";
                            new DataTable();
                            _phongBanDTO.MaPhongBan = sMaPhongBanThongKeThangCong;
                            DataTable dtPhongBanThongKeThangCong;
                            dtPhongBanThongKeThangCong = _phongBanBLL.getTenPhongBanByMaPhongBan(_phongBanDTO);
                            for (int iPhongBanThongKeThangCong = 0; iPhongBanThongKeThangCong < dtPhongBanThongKeThangCong.Rows.Count; iPhongBanThongKeThangCong++)
                            {
                                iDemPhongBanThongKeThangCong = 1;
                                sTenPhongBanThongKeThangCong = dtPhongBanThongKeThangCong.Rows[iPhongBanThongKeThangCong]["TenPhongBan"].ToString();
                            }
                            Excel.Range excelThongKeThangCongPhongBanDuLieu;
                            excelThongKeThangCongPhongBanDuLieu = (ws_ThongKeThangCong).get_Range((object)("D" + iDemDongThongKeThangCong), (object)("D" + iDemDongThongKeThangCong));
                            if (iDemPhongBanThongKeThangCong == 1)
                            {
                                excelThongKeThangCongPhongBanDuLieu.Cells[1, 1] = sTenPhongBanThongKeThangCong;
                            }
                            else
                            {
                                excelThongKeThangCongPhongBanDuLieu.Cells[1, 1] = "-------";
                            }
                            new DataTable();
                            _nhanVienDTO.MaChamCong = iMaChamCongThongKeThangCong.ToString();
                            DataTable dtNhanVien;
                            dtNhanVien = _nhanVienBLL.NhanVienGetByMaChamCong(iMaChamCongThongKeThangCong.ToString());
                            for (int iNhanVien = 0; iNhanVien < dtNhanVien.Rows.Count; iNhanVien++)
                            {
                                string sNgayVaoLamViec;
                                sNgayVaoLamViec = dtNhanVien.Rows[iNhanVien]["NgayVaoLamViec"].ToString();
                                Excel.Range excelThongKeThangCongChucVuDuLieu;
                                excelThongKeThangCongChucVuDuLieu = (ws_ThongKeThangCong).get_Range((object)("E" + iDemDongThongKeThangCong), (object)("E" + iDemDongThongKeThangCong));
                                if (sNgayVaoLamViec != "")
                                {
                                    try
                                    {
                                        DateTime dNgayVaoLamViecExportDanhSachNhanVien;
                                        dNgayVaoLamViecExportDanhSachNhanVien = Convert.ToDateTime(sNgayVaoLamViec);
                                        excelThongKeThangCongChucVuDuLieu.get_Range((object)"A1", (object)"A1").NumberFormat = "@";
                                        excelThongKeThangCongChucVuDuLieu.Cells[1, 1] = $"{dNgayVaoLamViecExportDanhSachNhanVien:d}";
                                    }
                                    catch
                                    {
                                        excelThongKeThangCongChucVuDuLieu.Cells[1, 1] = $"{DateTime.Now:d}";
                                    }
                                }
                                else
                                {
                                    excelThongKeThangCongChucVuDuLieu.Cells[1, 1] = "-------";
                                }
                            }
                            int ColunmNgayCong;
                            ColunmNgayCong = 6;
                            int iTangCot;
                            iTangCot = 5;
                            int iColumnThongKeThangCong;
                            iColumnThongKeThangCong = 1;
                            for (int iThongKeThang_Cong = 0; iThongKeThang_Cong < 31; iThongKeThang_Cong++)
                            {
                                string sThu;
                                sThu = "";
                                double dNgayCongThongKeThang;
                                dNgayCongThongKeThang = 0.0;
                                _ = dateTimeTuNgay.Value;
                                DateTime dNgayCongThongKeThangCong;
                                dNgayCongThongKeThangCong = Convert.ToDateTime(dNgayBatDauTinhCong.AddDays(iThongKeThang_Cong).ToString());
                                new DataTable();
                                _tinhCongDTO.MaChamCong = iMaChamCongThongKeThangCong;
                                _tinhCongDTO.Ngay = dNgayCongThongKeThangCong;
                                DataTable dtCongHangNgayThongKeThangCong;
                                dtCongHangNgayThongKeThangCong = _tinhCongBLL.TinhCongGetMaChamCongAndNgayThongKeCong(_tinhCongDTO);
                                for (int iCongHangNgayThongKeThangCong = 0; iCongHangNgayThongKeThangCong < dtCongHangNgayThongKeThangCong.Rows.Count; iCongHangNgayThongKeThangCong++)
                                {
                                    dNgayCongThongKeThang += Convert.ToDouble(dtCongHangNgayThongKeThangCong.Rows[iCongHangNgayThongKeThangCong]["Cong"].ToString());
                                    sThu = dtCongHangNgayThongKeThangCong.Rows[iCongHangNgayThongKeThangCong]["Thu"].ToString();
                                }
                                Excel.Range excelThongKeThangCongCongHangNgayDuLieu;
                                excelThongKeThangCongCongHangNgayDuLieu = (ws_ThongKeThangCong).get_Range((object)("F" + iDemDongThongKeThangCong), (object)("AJ" + iDemDongThongKeThangCong));
                                if (dNgayCongThongKeThang > 0.0)
                                {
                                    excelThongKeThangCongCongHangNgayDuLieu.Cells[1, iColumnThongKeThangCong] = dNgayCongThongKeThang;
                                }
                                else
                                {
                                    excelThongKeThangCongCongHangNgayDuLieu.Cells[1, iColumnThongKeThangCong] = "";
                                }
                                if (sThu == "CN")
                                {
                                    (ws_ThongKeThangCong).get_Range(ws_ThongKeThangCong.Cells[iTangHang + 1, iTangCot + 1], ws_ThongKeThangCong.Cells[iTangHang, iTangCot + 1]).Interior.Color = ColorTranslator.ToOle(Color.PaleGoldenrod);
                                }
                                iTangCot++;
                                ColunmNgayCong++;
                                iColumnThongKeThangCong++;
                            }
                            double dTangCaThongKeThangCongNgayThuong;
                            dTangCaThongKeThangCongNgayThuong = 0.0;
                            new DataTable();
                            _tinhCongDTO.MaChamCong = iMaChamCongThongKeThangCong;
                            _tinhCongDTO.KyHieuPhu = "NT";
                            DataTable dtThongKeThangCongTangCaNgayThuong;
                            dtThongKeThangCongTangCaNgayThuong = _tinhCongBLL.TinhCongGetByMaChamCongAndKyHieuPhu(_tinhCongDTO);
                            for (int iTangCaNgayThuong = 0; iTangCaNgayThuong < dtThongKeThangCongTangCaNgayThuong.Rows.Count; iTangCaNgayThuong++)
                            {
                                dTangCaThongKeThangCongNgayThuong += Convert.ToDouble(dtThongKeThangCongTangCaNgayThuong.Rows[iTangCaNgayThuong]["TC1"].ToString()) + Convert.ToDouble(dtThongKeThangCongTangCaNgayThuong.Rows[iTangCaNgayThuong]["TC2"].ToString()) + Convert.ToDouble(dtThongKeThangCongTangCaNgayThuong.Rows[iTangCaNgayThuong]["TC3"].ToString()) + Convert.ToDouble(dtThongKeThangCongTangCaNgayThuong.Rows[iTangCaNgayThuong]["TC4"].ToString());
                            }
                            (ws_ThongKeThangCong).get_Range((object)("AL" + iDemDongThongKeThangCong), (object)("AL" + iDemDongThongKeThangCong)).Cells[1, 1] = dTangCaThongKeThangCongNgayThuong;
                            double dTangCaThongKeThangCongChuNhat;
                            dTangCaThongKeThangCongChuNhat = 0.0;
                            new DataTable();
                            _tinhCongDTO.MaChamCong = iMaChamCongThongKeThangCong;
                            _tinhCongDTO.KyHieuPhu = "CN";
                            DataTable dtThongKeThangCongTangCaChuNhat;
                            dtThongKeThangCongTangCaChuNhat = _tinhCongBLL.TinhCongGetByMaChamCongAndKyHieuPhu(_tinhCongDTO);
                            for (int iTangCaChuNhat = 0; iTangCaChuNhat < dtThongKeThangCongTangCaChuNhat.Rows.Count; iTangCaChuNhat++)
                            {
                                dTangCaThongKeThangCongChuNhat += Convert.ToDouble(dtThongKeThangCongTangCaChuNhat.Rows[iTangCaChuNhat]["TC1"].ToString()) + Convert.ToDouble(dtThongKeThangCongTangCaChuNhat.Rows[iTangCaChuNhat]["TC2"].ToString()) + Convert.ToDouble(dtThongKeThangCongTangCaChuNhat.Rows[iTangCaChuNhat]["TC3"].ToString()) + Convert.ToDouble(dtThongKeThangCongTangCaChuNhat.Rows[iTangCaChuNhat]["TC4"].ToString());
                            }
                            (ws_ThongKeThangCong).get_Range((object)("AM" + iDemDongThongKeThangCong), (object)("AM" + iDemDongThongKeThangCong)).Cells[1, 1] = dTangCaThongKeThangCongChuNhat;
                            int iTreThongKeThangCong;
                            iTreThongKeThangCong = 0;
                            int iVeSomThongKeThangCong;
                            iVeSomThongKeThangCong = 0;
                            int iDemNghiKhongLuongThongKeThangCong;
                            iDemNghiKhongLuongThongKeThangCong = 0;
                            int iDemNghiCoLuongThongKeThangCong;
                            iDemNghiCoLuongThongKeThangCong = 0;
                            int iDemPhepThongKeThangCong;
                            iDemPhepThongKeThangCong = 0;
                            int iDemNgayLeThongKeThangCong;
                            iDemNgayLeThongKeThangCong = 0;
                            double dTongCongThongKeThangCong;
                            dTongCongThongKeThangCong = 0.0;
                            new DataTable();
                            _tinhCongDTO.MaChamCong = iMaChamCongThongKeThangCong;
                            DataTable dtTreSomThongKeThangCong;
                            dtTreSomThongKeThangCong = _tinhCongBLL.TinhCongGetByMaChamCong(_tinhCongDTO);
                            for (int iTreSomThongKeThangCong = 0; iTreSomThongKeThangCong < dtTreSomThongKeThangCong.Rows.Count; iTreSomThongKeThangCong++)
                            {
                                iTreThongKeThangCong += Convert.ToInt32(dtTreSomThongKeThangCong.Rows[iTreSomThongKeThangCong]["Tre"].ToString());
                                iVeSomThongKeThangCong += Convert.ToInt32(dtTreSomThongKeThangCong.Rows[iTreSomThongKeThangCong]["VeSom"].ToString());
                                dTongCongThongKeThangCong += Convert.ToDouble(dtTreSomThongKeThangCong.Rows[iTreSomThongKeThangCong]["Cong"].ToString());
                                if (dtTreSomThongKeThangCong.Rows[iTreSomThongKeThangCong]["Cong"].ToString() == "0")
                                {
                                    iDemNghiKhongLuongThongKeThangCong++;
                                }
                                if (dtTreSomThongKeThangCong.Rows[iTreSomThongKeThangCong]["Cong"].ToString() != "0" && dtTreSomThongKeThangCong.Rows[iTreSomThongKeThangCong]["KyHieu"].ToString() != "X")
                                {
                                    iDemNghiCoLuongThongKeThangCong++;
                                }
                                if (dtTreSomThongKeThangCong.Rows[iTreSomThongKeThangCong]["Cong"].ToString() != "0" && dtTreSomThongKeThangCong.Rows[iTreSomThongKeThangCong]["KyHieu"].ToString() == sKHLe)
                                {
                                    iDemNgayLeThongKeThangCong++;
                                }
                                if (dtTreSomThongKeThangCong.Rows[iTreSomThongKeThangCong]["Cong"].ToString() != "0" && dtTreSomThongKeThangCong.Rows[iTreSomThongKeThangCong]["KyHieu"].ToString() == sKHPhepNam)
                                {
                                    iDemPhepThongKeThangCong++;
                                }
                            }
                            (ws_ThongKeThangCong).get_Range((object)("AN" + iDemDongThongKeThangCong), (object)("AN" + iDemDongThongKeThangCong)).Cells[1, 1] = iTreThongKeThangCong;
                            (ws_ThongKeThangCong).get_Range((object)("AO" + iDemDongThongKeThangCong), (object)("AO" + iDemDongThongKeThangCong)).Cells[1, 1] = iVeSomThongKeThangCong;
                            (ws_ThongKeThangCong).get_Range((object)("AP" + iDemDongThongKeThangCong), (object)("AP" + iDemDongThongKeThangCong)).Cells[1, 1] = (iTreThongKeThangCong + iVeSomThongKeThangCong).ToString();
                            (ws_ThongKeThangCong).get_Range((object)("AK" + iDemDongThongKeThangCong), (object)("AK" + iDemDongThongKeThangCong)).Cells[1, 1] = dTongCongThongKeThangCong;
                            (ws_ThongKeThangCong).get_Range((object)("AT" + iDemDongThongKeThangCong), (object)("AT" + iDemDongThongKeThangCong)).Cells[1, 1] = iDemNghiKhongLuongThongKeThangCong;
                            (ws_ThongKeThangCong).get_Range((object)("AS" + iDemDongThongKeThangCong), (object)("AS" + iDemDongThongKeThangCong)).Cells[1, 1] = iDemNghiCoLuongThongKeThangCong;
                            iDemDongThongKeThangCong++;
                            iDemSTTThongKeThangCong++;
                            iTangHang++;
                        }
                    }
                    Excel.Range excelThongKeThangCong_DinhDangHeader;
                    excelThongKeThangCong_DinhDangHeader = (ws_ThongKeThangCong).get_Range((object)"A7", (object)"AT9");
                    excelThongKeThangCong_DinhDangHeader.Font.Name = "Times New Roman";
                    excelThongKeThangCong_DinhDangHeader.Font.Size = "10";
                    excelThongKeThangCong_DinhDangHeader.Font.Bold = true;
                    excelThongKeThangCong_DinhDangHeader.Interior.ColorIndex = 33;
                    excelThongKeThangCong_DinhDangHeader.HorizontalAlignment = Excel.Constants.xlCenter;
                    excelThongKeThangCong_DinhDangHeader.Borders.LineStyle = Excel.Constants.xlBoth;
                    Excel.Range excelThongKeThangCong_DinhDangDuLieu;
                    excelThongKeThangCong_DinhDangDuLieu = (ws_ThongKeThangCong).get_Range((object)"A10", (object)("AT" + (iDemDongThongKeThangCong - 1)));
                    excelThongKeThangCong_DinhDangDuLieu.Font.Name = "Times New Roman";
                    excelThongKeThangCong_DinhDangDuLieu.Font.Size = "10";
                    excelThongKeThangCong_DinhDangDuLieu.HorizontalAlignment = Excel.Constants.xlCenter;
                    excelThongKeThangCong_DinhDangDuLieu.Borders.LineStyle = Excel.Constants.xlBoth;
                    failed = false;
                }
                catch (COMException)
                {
                    failed = true;
                }
                Thread.Sleep(10);
            }
            while (failed);
        }

        private void ExportTongHop()
        {
            testProcess = iDemNhanVienDuocChon;
            demProcess = -1;
            DateTime dNgayTinh;
            dNgayTinh = Convert.ToDateTime(dateTimeTuNgay.Text);
            DateTime dNgayBatDauTinhCong;
            dNgayBatDauTinhCong = new DateTime(dNgayTinh.Year, dNgayTinh.Month, dNgayTinh.Day, 0, 0, 0);
            _ = Thread.CurrentThread.CurrentCulture;
            Thread.CurrentThread.CurrentCulture = new CultureInfo("en-US");
            Excel.Application xla_TongHop;
            xla_TongHop = new Excel.Application();
            xla_TongHop.Workbooks.Add(Excel.XlSheetType.xlWorksheet);
            _ = xla_TongHop.ActiveSheet;
            Excel.Worksheet ws_TongHop;
            ws_TongHop = xla_TongHop.Worksheets.get_Item((object)1);
            xla_TongHop.Visible = true;
            bool failed;
            do
            {
                try
                {
                    Excel.Range excelTenCongTy;
                    excelTenCongTy = (ws_TongHop).get_Range((object)"A1", (object)"P1");
                    excelTenCongTy.Select();
                    excelTenCongTy.Cells[1, 1] = "Công ty: " + sTenCongTyReport;
                    excelTenCongTy.get_Range((object)"A1", (object)"P1").Merge(true);
                    Excel.Range excelDiaChiCongTy;
                    excelDiaChiCongTy = (ws_TongHop).get_Range((object)"A2", (object)"P2");
                    excelDiaChiCongTy.Cells[1, 1] = "Địa chỉ: " + sDiaChiCongTyReport;
                    excelDiaChiCongTy.get_Range((object)"A1", (object)"P1").Merge(true);
                    Excel.Range excelTieuDeTongHop;
                    excelTieuDeTongHop = (ws_TongHop).get_Range((object)"A4", (object)"P4");
                    excelTieuDeTongHop.Cells[1, 1] = "BẢNG TỔNG HỢP CHẤM CÔNG";
                    excelTieuDeTongHop.get_Range((object)"A1", (object)"P1").Merge(true);
                    excelTieuDeTongHop.Font.Name = "Times New Roman";
                    excelTieuDeTongHop.Font.Size = "18";
                    excelTieuDeTongHop.Font.Bold = true;
                    excelTieuDeTongHop.RowHeight = "24";
                    excelTieuDeTongHop.HorizontalAlignment = Excel.Constants.xlCenter;
                    Excel.Range excelTuNgayDenNgayTongHop;
                    excelTuNgayDenNgayTongHop = (ws_TongHop).get_Range((object)"A5", (object)"P5");
                    excelTuNgayDenNgayTongHop.Cells[1, 1] = "Từ ngày " + dateTimeTuNgay.Text + " đến ngày " + dateTimeDenNgay.Text;
                    excelTuNgayDenNgayTongHop.get_Range((object)"A1", (object)"P1").Merge(true);
                    excelTuNgayDenNgayTongHop.HorizontalAlignment = Excel.Constants.xlCenter;
                    Excel.Range excelSTTTongHop;
                    excelSTTTongHop = (ws_TongHop).get_Range((object)"A7", (object)"A9");
                    excelSTTTongHop.Cells[1, 1] = "STT";
                    excelSTTTongHop.get_Range((object)"A1", (object)"A3").MergeCells = true;
                    Excel.Range excelMaSoTongHop;
                    excelMaSoTongHop = (ws_TongHop).get_Range((object)"B7", (object)"B9");
                    excelMaSoTongHop.Cells[1, 1] = "Mã số";
                    excelMaSoTongHop.get_Range((object)"A1", (object)"A3").MergeCells = true;
                    Excel.Range excelHoVaTenTongHop;
                    excelHoVaTenTongHop = (ws_TongHop).get_Range((object)"C7", (object)"C9");
                    excelHoVaTenTongHop.Cells[1, 1] = "Họ và tên";
                    excelHoVaTenTongHop.get_Range((object)"A1", (object)"A3").MergeCells = true;
                    Excel.Range excelPhongBanTongHop;
                    excelPhongBanTongHop = (ws_TongHop).get_Range((object)"D7", (object)"D9");
                    excelPhongBanTongHop.Cells[1, 1] = "Phòng ban";
                    excelPhongBanTongHop.get_Range((object)"A1", (object)"A3").MergeCells = true;
                    Excel.Range excelQuyRaCongTongHop;
                    excelQuyRaCongTongHop = (ws_TongHop).get_Range((object)"E7", (object)"L7");
                    excelQuyRaCongTongHop.Cells[1, 1] = "QUY RA CÔNG";
                    excelQuyRaCongTongHop.get_Range((object)"A1", (object)"H1").Merge(true);
                    excelQuyRaCongTongHop.HorizontalAlignment = Excel.Constants.xlCenter;
                    Excel.Range excelGioCongTongHop;
                    excelGioCongTongHop = (ws_TongHop).get_Range((object)"E8", (object)"F8");
                    excelGioCongTongHop.Cells[1, 1] = "Giờ công";
                    excelGioCongTongHop.get_Range((object)"A1", (object)"B1").Merge(true);
                    Excel.Range excelNgayCongTongHop;
                    excelNgayCongTongHop = (ws_TongHop).get_Range((object)"G8", (object)"H8");
                    excelNgayCongTongHop.Cells[1, 1] = "Ngày công";
                    excelNgayCongTongHop.get_Range((object)"A1", (object)"B1").Merge(true);
                    Excel.Range excelTangCaTongHop;
                    excelTangCaTongHop = (ws_TongHop).get_Range((object)"I8", (object)"J8");
                    excelTangCaTongHop.Cells[1, 1] = "Tăng ca";
                    excelTangCaTongHop.get_Range((object)"A1", (object)"B1").Merge(true);
                    Excel.Range excelPhutTongHop;
                    excelPhutTongHop = (ws_TongHop).get_Range((object)"K8", (object)"L8");
                    excelPhutTongHop.Cells[1, 1] = "Số lần";
                    excelPhutTongHop.get_Range((object)"A1", (object)"B1").Merge(true);
                    (ws_TongHop).get_Range((object)"E9", (object)"E9").Cells[1, 1] = "BT";
                    Excel.Range excelCNGioCongTongHop;
                    excelCNGioCongTongHop = (ws_TongHop).get_Range((object)"F9", (object)"F9");
                    excelCNGioCongTongHop.Cells[1, 1] = "CN";
                    excelCNGioCongTongHop.Font.ColorIndex = 3;
                    (ws_TongHop).get_Range((object)"G9", (object)"G9").Cells[1, 1] = "BT";
                    Excel.Range excelCNNgayCongTongHop;
                    excelCNNgayCongTongHop = (ws_TongHop).get_Range((object)"H9", (object)"H9");
                    excelCNNgayCongTongHop.Cells[1, 1] = "CN";
                    excelCNNgayCongTongHop.Font.ColorIndex = 3;
                    (ws_TongHop).get_Range((object)"I9", (object)"I9").Cells[1, 1] = "BT";
                    Excel.Range excelCNTangCaTongHop;
                    excelCNTangCaTongHop = (ws_TongHop).get_Range((object)"J9", (object)"J9");
                    excelCNTangCaTongHop.Cells[1, 1] = "CN";
                    excelCNTangCaTongHop.Font.ColorIndex = 3;
                    (ws_TongHop).get_Range((object)"K9", (object)"K9").Cells[1, 1] = "Trễ";
                    (ws_TongHop).get_Range((object)"L9", (object)"L9").Cells[1, 1] = "Sớm";
                    Excel.Range excelNghiTongHop;
                    excelNghiTongHop = (ws_TongHop).get_Range((object)"M7", (object)"P7");
                    excelNghiTongHop.Cells[1, 1] = "NGHỈ";
                    excelNghiTongHop.get_Range((object)"A1", (object)"D1").Merge(true);
                    excelNghiTongHop.HorizontalAlignment = Excel.Constants.xlCenter;
                    Excel.Range excelPhepTongHop;
                    excelPhepTongHop = (ws_TongHop).get_Range((object)"M8", (object)"M9");
                    excelPhepTongHop.Cells[1, 1] = "PHÉP";
                    excelPhepTongHop.get_Range((object)"A1", (object)"A2").MergeCells = true;
                    excelPhepTongHop.get_Range((object)"A1", (object)"A2").Orientation = 90;
                    Excel.Range excelLeTongHop;
                    excelLeTongHop = (ws_TongHop).get_Range((object)"N8", (object)"N9");
                    excelLeTongHop.Cells[1, 1] = "LỄ";
                    excelLeTongHop.get_Range((object)"A1", (object)"A2").MergeCells = true;
                    excelLeTongHop.get_Range((object)"A1", (object)"A2").Orientation = 90;
                    Excel.Range excelNghiCoLuongTongHop;
                    excelNghiCoLuongTongHop = (ws_TongHop).get_Range((object)"O8", (object)"O9");
                    excelNghiCoLuongTongHop.Cells[1, 1] = "N.CÓ LƯƠNG";
                    excelNghiCoLuongTongHop.get_Range((object)"A1", (object)"A2").MergeCells = true;
                    excelNghiCoLuongTongHop.get_Range((object)"A1", (object)"A2").Orientation = 90;
                    Excel.Range excelNghiKhongLuongTongHop;
                    excelNghiKhongLuongTongHop = (ws_TongHop).get_Range((object)"P8", (object)"P9");
                    excelNghiKhongLuongTongHop.Cells[1, 1] = "N.KHÔNG LƯƠNG";
                    excelNghiKhongLuongTongHop.get_Range((object)"A1", (object)"A2").MergeCells = true;
                    excelNghiKhongLuongTongHop.get_Range((object)"A1", (object)"A2").Orientation = 90;
                    (ws_TongHop).get_Range((object)"A8", (object)"P8").get_Range((object)"A1", (object)"A1").RowHeight = 40;
                    (ws_TongHop).get_Range((object)"A9", (object)"P9").get_Range((object)"A1", (object)"A1").RowHeight = 50;
                    int demNhanVienExportTongHop;
                    demNhanVienExportTongHop = 10;
                    int dem;
                    dem = 1;
                    new DataTable();
                    DataTable dtNgayTinhCongTongHop;
                    dtNgayTinhCongTongHop = _ngayTinhCongBLL.showThongTinNgayTinhCong();
                    for (int iNgayTinhCongTongHop = 0; iNgayTinhCongTongHop < dtNgayTinhCongTongHop.Rows.Count; iNgayTinhCongTongHop++)
                    {
                        Convert.ToDateTime(dtNgayTinhCongTongHop.Rows[iNgayTinhCongTongHop]["NgayBatDau"].ToString());
                        new DataTable();
                        _tinhCongDTO.Ngay = dNgayBatDauTinhCong;
                        DataTable dtTinhCongTongHop;
                        dtTinhCongTongHop = _tinhCongBLL.TinhCongGetNgay(_tinhCongDTO);
                        int iMaChamCongTongHop;
                        iMaChamCongTongHop = 0;
                        for (int iTinhCongTongHop = 0; iTinhCongTongHop < dtTinhCongTongHop.Rows.Count; iTinhCongTongHop++)
                        {
                            if (Convert.ToInt32(dtTinhCongTongHop.Rows[iTinhCongTongHop]["MaChamCong"].ToString()) == iMaChamCongTongHop)
                            {
                                continue;
                            }
                            string sTenPhongBanTongHop;
                            sTenPhongBanTongHop = "";
                            int iDemNgayThuong;
                            iDemNgayThuong = 0;
                            int iDemNgayChuNhat;
                            iDemNgayChuNhat = 0;
                            double dTongGioNgayThuong;
                            dTongGioNgayThuong = 0.0;
                            double dTongGioNgayChuNhat;
                            dTongGioNgayChuNhat = 0.0;
                            double dTongCongNgayThuong;
                            dTongCongNgayThuong = 0.0;
                            double dTongCongNgayChuNhat;
                            dTongCongNgayChuNhat = 0.0;
                            double dTongTangCaNgayThuong;
                            dTongTangCaNgayThuong = 0.0;
                            double dTongTangCaNgayChuNhat;
                            dTongTangCaNgayChuNhat = 0.0;
                            int iDemNgayLeTongHop;
                            iDemNgayLeTongHop = 0;
                            double iDemPhepNamTongHop;
                            iDemPhepNamTongHop = 0.0;
                            int iDemNghiKhongLuongTongHop;
                            iDemNghiKhongLuongTongHop = 0;
                            int iTongDiTreTongHop;
                            iTongDiTreTongHop = 0;
                            int iTongVeSomTongHop;
                            iTongVeSomTongHop = 0;
                            iMaChamCongTongHop = Convert.ToInt32(dtTinhCongTongHop.Rows[iTinhCongTongHop]["MaChamCong"].ToString());
                            string sMaNhanVienTongHop;
                            sMaNhanVienTongHop = dtTinhCongTongHop.Rows[iTinhCongTongHop]["MaNhanVien"].ToString();
                            string sTenNhanVienTongHop;
                            sTenNhanVienTongHop = dtTinhCongTongHop.Rows[iTinhCongTongHop]["TenNhanVien"].ToString();
                            string sMaPhongBanTongHop;
                            sMaPhongBanTongHop = dtTinhCongTongHop.Rows[iTinhCongTongHop]["PhongBan"].ToString();
                            Excel.Range excelSTTDuLieuTongHop;
                            excelSTTDuLieuTongHop = (ws_TongHop).get_Range((object)("A" + demNhanVienExportTongHop), (object)("A" + demNhanVienExportTongHop));
                            excelSTTDuLieuTongHop.Cells[1, 1] = dem;
                            excelSTTDuLieuTongHop.Select();
                            Excel.Range excelMaNhanVienDuLieuTongHop;
                            excelMaNhanVienDuLieuTongHop = (ws_TongHop).get_Range((object)("B" + demNhanVienExportTongHop), (object)("B" + demNhanVienExportTongHop));
                            excelMaNhanVienDuLieuTongHop.get_Range((object)"A1", (object)"A1").NumberFormat = "@";
                            excelMaNhanVienDuLieuTongHop.Cells[1, 1] = sMaNhanVienTongHop;
                            (ws_TongHop).get_Range((object)("C" + demNhanVienExportTongHop), (object)("C" + demNhanVienExportTongHop)).Cells[1, 1] = sTenNhanVienTongHop;
                            new DataTable();
                            _phongBanDTO.MaPhongBan = sMaPhongBanTongHop;
                            DataTable dtPhongBanTongHop;
                            dtPhongBanTongHop = _phongBanBLL.getTenPhongBanByMaPhongBan(_phongBanDTO);
                            for (int iPhongBanTongHop = 0; iPhongBanTongHop < dtPhongBanTongHop.Rows.Count; iPhongBanTongHop++)
                            {
                                sTenPhongBanTongHop = dtPhongBanTongHop.Rows[iPhongBanTongHop]["TenPhongBan"].ToString();
                            }
                            if (sMaPhongBanTongHop == "")
                            {
                                (ws_TongHop).get_Range((object)("D" + demNhanVienExportTongHop), (object)("D" + demNhanVienExportTongHop)).Cells[1, 1] = "------";
                            }
                            else
                            {
                                (ws_TongHop).get_Range((object)("D" + demNhanVienExportTongHop), (object)("D" + demNhanVienExportTongHop)).Cells[1, 1] = sTenPhongBanTongHop;
                            }
                            new DataTable();
                            _tinhCongDTO.MaChamCong = iMaChamCongTongHop;
                            DataTable dtNhanVienTongHop;
                            dtNhanVienTongHop = _tinhCongBLL.TinhCongGetByMaChamCong(_tinhCongDTO);
                            for (int iNhanVienTongHop = 0; iNhanVienTongHop < dtNhanVienTongHop.Rows.Count; iNhanVienTongHop++)
                            {
                                int iDiTre;
                                iDiTre = Convert.ToInt32(dtNhanVienTongHop.Rows[iNhanVienTongHop]["Tre"].ToString());
                                int iVeSom;
                                iVeSom = Convert.ToInt32(dtNhanVienTongHop.Rows[iNhanVienTongHop]["VeSom"].ToString());
                                if (iDiTre > 0)
                                {
                                    iTongDiTreTongHop++;
                                }
                                if (iVeSom > 0)
                                {
                                    iTongVeSomTongHop++;
                                }
                            }
                            new DataTable();
                            _tinhCongDTO.MaChamCong = iMaChamCongTongHop;
                            _tinhCongDTO.KyHieuPhu = "NT";
                            DataTable dtGioCongNgayThuong;
                            dtGioCongNgayThuong = _tinhCongBLL.TinhCongGetByMaChamCongAndKyHieuPhu(_tinhCongDTO);
                            for (int iGioCongNgayThuong = 0; iGioCongNgayThuong < dtGioCongNgayThuong.Rows.Count; iGioCongNgayThuong++)
                            {
                                iDemNgayThuong++;
                                dTongGioNgayThuong += Convert.ToDouble(dtGioCongNgayThuong.Rows[iGioCongNgayThuong]["Gio"].ToString());
                                dTongCongNgayThuong += Convert.ToDouble(dtGioCongNgayThuong.Rows[iGioCongNgayThuong]["Cong"].ToString());
                                dTongTangCaNgayThuong += Convert.ToDouble(dtGioCongNgayThuong.Rows[iGioCongNgayThuong]["TC1"].ToString()) + Convert.ToDouble(dtGioCongNgayThuong.Rows[iGioCongNgayThuong]["TC2"].ToString()) + Convert.ToDouble(dtGioCongNgayThuong.Rows[iGioCongNgayThuong]["TC3"].ToString()) + Convert.ToDouble(dtGioCongNgayThuong.Rows[iGioCongNgayThuong]["TC4"].ToString());
                            }
                            (ws_TongHop).get_Range((object)("E" + demNhanVienExportTongHop), (object)("E" + demNhanVienExportTongHop)).Cells[1, 1] = dTongGioNgayThuong;
                            (ws_TongHop).get_Range((object)("G" + demNhanVienExportTongHop), (object)("G" + demNhanVienExportTongHop)).Cells[1, 1] = dTongCongNgayThuong;
                            (ws_TongHop).get_Range((object)("I" + demNhanVienExportTongHop), (object)("I" + demNhanVienExportTongHop)).Cells[1, 1] = dTongTangCaNgayThuong;
                            new DataTable();
                            _tinhCongDTO.MaChamCong = iMaChamCongTongHop;
                            _tinhCongDTO.KyHieuPhu = "CN";
                            DataTable dtGioCongNgayChuNhat;
                            dtGioCongNgayChuNhat = _tinhCongBLL.TinhCongGetByMaChamCongAndKyHieuPhu(_tinhCongDTO);
                            for (int iGioCongNgayChuNhat = 0; iGioCongNgayChuNhat < dtGioCongNgayChuNhat.Rows.Count; iGioCongNgayChuNhat++)
                            {
                                iDemNgayChuNhat++;
                                dTongGioNgayChuNhat += Convert.ToDouble(dtGioCongNgayChuNhat.Rows[iGioCongNgayChuNhat]["Gio"].ToString());
                                dTongCongNgayChuNhat += Convert.ToDouble(dtGioCongNgayChuNhat.Rows[iGioCongNgayChuNhat]["Cong"].ToString());
                                dTongTangCaNgayChuNhat += Convert.ToDouble(dtGioCongNgayChuNhat.Rows[iGioCongNgayChuNhat]["TC1"].ToString()) + Convert.ToDouble(dtGioCongNgayChuNhat.Rows[iGioCongNgayChuNhat]["TC2"].ToString()) + Convert.ToDouble(dtGioCongNgayChuNhat.Rows[iGioCongNgayChuNhat]["TC3"].ToString()) + Convert.ToDouble(dtGioCongNgayChuNhat.Rows[iGioCongNgayChuNhat]["TC4"].ToString());
                            }
                            (ws_TongHop).get_Range((object)("F" + demNhanVienExportTongHop), (object)("F" + demNhanVienExportTongHop)).Cells[1, 1] = dTongGioNgayChuNhat;
                            (ws_TongHop).get_Range((object)("H" + demNhanVienExportTongHop), (object)("H" + demNhanVienExportTongHop)).Cells[1, 1] = dTongCongNgayChuNhat;
                            (ws_TongHop).get_Range((object)("J" + demNhanVienExportTongHop), (object)("J" + demNhanVienExportTongHop)).Cells[1, 1] = dTongTangCaNgayChuNhat;
                            (ws_TongHop).get_Range((object)("K" + demNhanVienExportTongHop), (object)("K" + demNhanVienExportTongHop)).Cells[1, 1] = iTongDiTreTongHop;
                            (ws_TongHop).get_Range((object)("L" + demNhanVienExportTongHop), (object)("L" + demNhanVienExportTongHop)).Cells[1, 1] = iTongVeSomTongHop;
                            new DataTable();
                            _tinhCongDTO.MaChamCong = iMaChamCongTongHop;
                            _tinhCongDTO.KyHieu = sKHLe;
                            DataTable dtNgayLeTongHop;
                            dtNgayLeTongHop = _tinhCongBLL.TinhCongGetByMaChamCongAndLe(_tinhCongDTO);
                            for (int iNgayLeTongHop = 0; iNgayLeTongHop < dtNgayLeTongHop.Rows.Count; iNgayLeTongHop++)
                            {
                                iDemNgayLeTongHop++;
                            }
                            (ws_TongHop).get_Range((object)("N" + demNhanVienExportTongHop), (object)("N" + demNhanVienExportTongHop)).Cells[1, 1] = iDemNgayLeTongHop;
                            new DataTable();
                            _tinhCongDTO.MaChamCong = iMaChamCongTongHop;
                            _tinhCongDTO.KyHieu = sKHPhepNam;
                            DataTable dtPhepNamTongHop;
                            dtPhepNamTongHop = _tinhCongBLL.TinhCongGetByMaChamCongAndLe(_tinhCongDTO);
                            for (int iPhepNamTongHop = 0; iPhepNamTongHop < dtPhepNamTongHop.Rows.Count; iPhepNamTongHop++)
                            {
                                iDemPhepNamTongHop += Convert.ToDouble(dtPhepNamTongHop.Rows[iPhepNamTongHop]["Cong"].ToString());
                            }
                            (ws_TongHop).get_Range((object)("M" + demNhanVienExportTongHop), (object)("M" + demNhanVienExportTongHop)).Cells[1, 1] = iDemPhepNamTongHop;
                            new DataTable();
                            _tinhCongDTO.MaChamCong = iMaChamCongTongHop;
                            _tinhCongDTO.KyHieu = sKHVang;
                            DataTable dtNghiKhongLuongTongHop;
                            dtNghiKhongLuongTongHop = _tinhCongBLL.TinhCongGetByMaChamCongAndLe(_tinhCongDTO);
                            for (int iNghiKhongLuongTongHop = 0; iNghiKhongLuongTongHop < dtNghiKhongLuongTongHop.Rows.Count; iNghiKhongLuongTongHop++)
                            {
                                if (dtNghiKhongLuongTongHop.Rows[iNghiKhongLuongTongHop]["Thu"].ToString() != "CN")
                                {
                                    iDemNghiKhongLuongTongHop++;
                                }
                            }
                            (ws_TongHop).get_Range((object)("P" + demNhanVienExportTongHop), (object)("P" + demNhanVienExportTongHop)).Cells[1, 1] = iDemNghiKhongLuongTongHop;
                            dem++;
                            demNhanVienExportTongHop++;
                        }
                    }
                    Excel.Range excelTruongBoPhanTongHop;
                    excelTruongBoPhanTongHop = (ws_TongHop).get_Range((object)("B" + (demNhanVienExportTongHop + 2)), (object)("D" + (demNhanVienExportTongHop + 2)));
                    excelTruongBoPhanTongHop.Cells[1, 1] = "Trưởng bộ phận";
                    excelTruongBoPhanTongHop.Font.Name = "Times New Roman";
                    excelTruongBoPhanTongHop.Font.Size = "10";
                    excelTruongBoPhanTongHop.get_Range((object)"A1", (object)"C1").Merge(true);
                    excelTruongBoPhanTongHop.HorizontalAlignment = Excel.Constants.xlCenter;
                    Excel.Range excelNguoiLapBieuTongHop;
                    excelNguoiLapBieuTongHop = (ws_TongHop).get_Range((object)("K" + (demNhanVienExportTongHop + 2)), (object)("N" + (demNhanVienExportTongHop + 2)));
                    excelNguoiLapBieuTongHop.Cells[1, 1] = "Người lập biểu";
                    excelNguoiLapBieuTongHop.Font.Name = "Times New Roman";
                    excelNguoiLapBieuTongHop.Font.Size = "10";
                    excelNguoiLapBieuTongHop.get_Range((object)"A1", (object)"D1").Merge(true);
                    excelNguoiLapBieuTongHop.HorizontalAlignment = Excel.Constants.xlCenter;
                    (ws_TongHop).get_Range((object)"A7", (object)"P9").Interior.ColorIndex = 15;
                    Excel.Range excelVienTongHop;
                    excelVienTongHop = (ws_TongHop).get_Range((object)"A7", (object)("P" + (demNhanVienExportTongHop - 1)));
                    excelVienTongHop.Borders.LineStyle = Excel.Constants.xlBoth;
                    excelVienTongHop.HorizontalAlignment = Excel.Constants.xlCenter;
                    Excel.Range excelChuDamTongHop;
                    excelChuDamTongHop = (ws_TongHop).get_Range((object)"A7", (object)"P9");
                    excelChuDamTongHop.HorizontalAlignment = Excel.Constants.xlCenter;
                    excelChuDamTongHop.Font.Bold = true;
                    excelVienTongHop.Font.Name = "Times New Roman";
                    excelVienTongHop.Font.Size = "10";
                    for (int iAuto = 0; iAuto < 4; iAuto++)
                    {
                        ((Excel.Range)ws_TongHop.Cells[1, 1 + iAuto]).EntireColumn.AutoFit();
                    }
                    failed = false;
                }
                catch (COMException)
                {
                    failed = true;
                }
                Thread.Sleep(10);
            }
            while (failed);
        }

        private void ExportExcelChiTietThoiGianLamViec()
        {
            _ = Thread.CurrentThread.CurrentCulture;
            Thread.CurrentThread.CurrentCulture = new CultureInfo("en-US");
            Excel.Application xla_ChiTietThoiGianLamViec;
            xla_ChiTietThoiGianLamViec = new Excel.Application();
            xla_ChiTietThoiGianLamViec.Workbooks.Add(Excel.XlSheetType.xlWorksheet);
            _ = xla_ChiTietThoiGianLamViec.ActiveSheet;
            Excel.Worksheet ws_ChiTietThoiGianLamViec;
            ws_ChiTietThoiGianLamViec = xla_ChiTietThoiGianLamViec.Worksheets.get_Item((object)1);
            DateTime dNgayTinh;
            dNgayTinh = Convert.ToDateTime(dateTimeTuNgay.Text);
            DateTime dNgayBatDauTinhCong;
            dNgayBatDauTinhCong = new DateTime(dNgayTinh.Year, dNgayTinh.Month, dNgayTinh.Day, 0, 0, 0);
            bool failed;
            do
            {
                try
                {
                    Excel.Range excelChiTietThoiGianLamViec_CongTyHeader;
                    excelChiTietThoiGianLamViec_CongTyHeader = (ws_ChiTietThoiGianLamViec).get_Range((object)"A1", (object)"BT1");
                    excelChiTietThoiGianLamViec_CongTyHeader.Cells[1, 1] = sTenCongTyReport;
                    excelChiTietThoiGianLamViec_CongTyHeader.get_Range((object)"A1", (object)"BS1").Merge(true);
                    Excel.Range excelChiTietThoiGianLamViec_DiaChiHeader;
                    excelChiTietThoiGianLamViec_DiaChiHeader = (ws_ChiTietThoiGianLamViec).get_Range((object)"A2", (object)"BT2");
                    excelChiTietThoiGianLamViec_DiaChiHeader.Cells[1, 1] = sDiaChiCongTyReport;
                    excelChiTietThoiGianLamViec_DiaChiHeader.get_Range((object)"A1", (object)"BS1").Merge(true);
                    Excel.Range excelChiTietThoiGianLamViec_DinhDangCongTyHeader;
                    excelChiTietThoiGianLamViec_DinhDangCongTyHeader = (ws_ChiTietThoiGianLamViec).get_Range((object)"A1", (object)"BT2");
                    excelChiTietThoiGianLamViec_DinhDangCongTyHeader.Font.Name = "Times New Roman";
                    excelChiTietThoiGianLamViec_DinhDangCongTyHeader.Font.Size = "11";
                    DateTime dTuNgayChiTietThoiGianLamViec;
                    dTuNgayChiTietThoiGianLamViec = default(DateTime);
                    new DataTable();
                    DataTable dtNgayTinhCongChiTietThoiGianLamViec;
                    dtNgayTinhCongChiTietThoiGianLamViec = _ngayTinhCongBLL.showThongTinNgayTinhCong();
                    for (int iNgayTinhCongChiTietThoiGianLamViec = 0; iNgayTinhCongChiTietThoiGianLamViec < dtNgayTinhCongChiTietThoiGianLamViec.Rows.Count; iNgayTinhCongChiTietThoiGianLamViec++)
                    {
                        dTuNgayChiTietThoiGianLamViec = Convert.ToDateTime(dtNgayTinhCongChiTietThoiGianLamViec.Rows[iNgayTinhCongChiTietThoiGianLamViec]["NgayBatDau"].ToString());
                        sTuNgayChiTietThoiGianLamViec = $"{dTuNgayChiTietThoiGianLamViec:d}";
                        sDenNgayChiTietThoiGianLamViec = string.Format("{0:d}", Convert.ToDateTime(dtNgayTinhCongChiTietThoiGianLamViec.Rows[iNgayTinhCongChiTietThoiGianLamViec]["NgayKetThuc"].ToString()));
                    }
                    Excel.Range excelChiTietThoiGianLamViec_TieuDeHeader;
                    excelChiTietThoiGianLamViec_TieuDeHeader = (ws_ChiTietThoiGianLamViec).get_Range((object)"A4", (object)"BT4");
                    excelChiTietThoiGianLamViec_TieuDeHeader.Cells[1, 1] = "BẢNG CHẤM CÔNG CHI TIẾT TỪ NGÀY " + sTuNgayChiTietThoiGianLamViec + " ĐẾN NGÀY " + sDenNgayChiTietThoiGianLamViec;
                    excelChiTietThoiGianLamViec_TieuDeHeader.get_Range((object)"A1", (object)"BS1").Merge(true);
                    excelChiTietThoiGianLamViec_TieuDeHeader.Font.Name = "Times New Roman";
                    excelChiTietThoiGianLamViec_TieuDeHeader.Font.Size = "14";
                    excelChiTietThoiGianLamViec_TieuDeHeader.Font.Bold = true;
                    excelChiTietThoiGianLamViec_TieuDeHeader.RowHeight = 18;
                    excelChiTietThoiGianLamViec_TieuDeHeader.HorizontalAlignment = Excel.Constants.xlCenter;
                    Excel.Range excelChiTietThoiGianLamViec_STTHeader;
                    excelChiTietThoiGianLamViec_STTHeader = (ws_ChiTietThoiGianLamViec).get_Range((object)"A6", (object)"A8");
                    excelChiTietThoiGianLamViec_STTHeader.Cells[1, 1] = "STT";
                    excelChiTietThoiGianLamViec_STTHeader.get_Range((object)"A1", (object)"A3").MergeCells = true;
                    excelChiTietThoiGianLamViec_STTHeader.VerticalAlignment = HorizontalAlignment.Center;
                    excelChiTietThoiGianLamViec_STTHeader.ColumnWidth = 4;
                    Excel.Range excelChiTietThoiGianLamViec_MaNhanVienHeader;
                    excelChiTietThoiGianLamViec_MaNhanVienHeader = (ws_ChiTietThoiGianLamViec).get_Range((object)"B6", (object)"B8");
                    excelChiTietThoiGianLamViec_MaNhanVienHeader.Cells[1, 1] = "MÃ NHÂN VIÊN";
                    excelChiTietThoiGianLamViec_MaNhanVienHeader.get_Range((object)"A1", (object)"A3").MergeCells = true;
                    excelChiTietThoiGianLamViec_MaNhanVienHeader.VerticalAlignment = HorizontalAlignment.Center;
                    excelChiTietThoiGianLamViec_MaNhanVienHeader.ColumnWidth = 14;
                    Excel.Range excelChiTietThoiGianLamViec_TenNhanVienHeader;
                    excelChiTietThoiGianLamViec_TenNhanVienHeader = (ws_ChiTietThoiGianLamViec).get_Range((object)"C6", (object)"C8");
                    excelChiTietThoiGianLamViec_TenNhanVienHeader.Cells[1, 1] = "TÊN NHÂN VIÊN";
                    excelChiTietThoiGianLamViec_TenNhanVienHeader.get_Range((object)"A1", (object)"A3").MergeCells = true;
                    excelChiTietThoiGianLamViec_TenNhanVienHeader.VerticalAlignment = HorizontalAlignment.Center;
                    excelChiTietThoiGianLamViec_TenNhanVienHeader.ColumnWidth = 14;
                    Excel.Range excelChiTietThoiGianLamViec_PhongBanHeader;
                    excelChiTietThoiGianLamViec_PhongBanHeader = (ws_ChiTietThoiGianLamViec).get_Range((object)"D6", (object)"D8");
                    excelChiTietThoiGianLamViec_PhongBanHeader.Cells[1, 1] = "PHÒNG BAN";
                    excelChiTietThoiGianLamViec_PhongBanHeader.get_Range((object)"A1", (object)"A3").MergeCells = true;
                    excelChiTietThoiGianLamViec_PhongBanHeader.VerticalAlignment = HorizontalAlignment.Center;
                    excelChiTietThoiGianLamViec_PhongBanHeader.ColumnWidth = 11;
                    Excel.Range excelChiTietThoiGianLamViec_NgayTrongThangHeader;
                    excelChiTietThoiGianLamViec_NgayTrongThangHeader = (ws_ChiTietThoiGianLamViec).get_Range((object)"E6", (object)"BN6");
                    excelChiTietThoiGianLamViec_NgayTrongThangHeader.Cells[1, 1] = "NGÀY TRONG THÁNG";
                    excelChiTietThoiGianLamViec_NgayTrongThangHeader.get_Range((object)"A1", (object)"BJ1").Merge(true);
                    int ColunmNgayChiTietThoiGianLamViec;
                    ColunmNgayChiTietThoiGianLamViec = 1;
                    for (int iChiTietThoiGianLamViec3 = 0; iChiTietThoiGianLamViec3 < 31; iChiTietThoiGianLamViec3++)
                    {
                        DateTime dNgayChamChiTietThoiGianLamViec;
                        dNgayChamChiTietThoiGianLamViec = dateTimeTuNgay.Value;
                        int iNgayChamChiTietThoiGianLamViec;
                        iNgayChamChiTietThoiGianLamViec = Convert.ToInt32(Convert.ToDateTime(dNgayChamChiTietThoiGianLamViec.AddDays(iChiTietThoiGianLamViec3).ToString()).Day);
                        Excel.Range excelChiTietThoiGianLamViec_Ngay;
                        excelChiTietThoiGianLamViec_Ngay = (ws_ChiTietThoiGianLamViec).get_Range((object)"E7", (object)"BN8");
                        excelChiTietThoiGianLamViec_Ngay.Cells[1, ColunmNgayChiTietThoiGianLamViec + iChiTietThoiGianLamViec3] = iNgayChamChiTietThoiGianLamViec;
                        if (iChiTietThoiGianLamViec3 == 0)
                        {
                            excelChiTietThoiGianLamViec_Ngay.get_Range((object)"A1", (object)"B1").Merge(true);
                        }
                        if (iChiTietThoiGianLamViec3 == 1)
                        {
                            excelChiTietThoiGianLamViec_Ngay.get_Range((object)"C1", (object)"D1").Merge(true);
                        }
                        if (iChiTietThoiGianLamViec3 == 2)
                        {
                            excelChiTietThoiGianLamViec_Ngay.get_Range((object)"E1", (object)"F1").Merge(true);
                        }
                        if (iChiTietThoiGianLamViec3 == 3)
                        {
                            excelChiTietThoiGianLamViec_Ngay.get_Range((object)"G1", (object)"H1").Merge(true);
                        }
                        if (iChiTietThoiGianLamViec3 == 4)
                        {
                            excelChiTietThoiGianLamViec_Ngay.get_Range((object)"I1", (object)"J1").Merge(true);
                        }
                        if (iChiTietThoiGianLamViec3 == 5)
                        {
                            excelChiTietThoiGianLamViec_Ngay.get_Range((object)"K1", (object)"L1").Merge(true);
                        }
                        if (iChiTietThoiGianLamViec3 == 6)
                        {
                            excelChiTietThoiGianLamViec_Ngay.get_Range((object)"K1", (object)"L1").Merge(true);
                        }
                        if (iChiTietThoiGianLamViec3 == 7)
                        {
                            excelChiTietThoiGianLamViec_Ngay.get_Range((object)"M1", (object)"N1").Merge(true);
                        }
                        if (iChiTietThoiGianLamViec3 == 8)
                        {
                            excelChiTietThoiGianLamViec_Ngay.get_Range((object)"O1", (object)"P1").Merge(true);
                        }
                        if (iChiTietThoiGianLamViec3 == 9)
                        {
                            excelChiTietThoiGianLamViec_Ngay.get_Range((object)"Q1", (object)"R1").Merge(true);
                        }
                        if (iChiTietThoiGianLamViec3 == 10)
                        {
                            excelChiTietThoiGianLamViec_Ngay.get_Range((object)"S1", (object)"T1").Merge(true);
                        }
                        if (iChiTietThoiGianLamViec3 == 11)
                        {
                            excelChiTietThoiGianLamViec_Ngay.get_Range((object)"U1", (object)"V1").Merge(true);
                        }
                        if (iChiTietThoiGianLamViec3 == 12)
                        {
                            excelChiTietThoiGianLamViec_Ngay.get_Range((object)"W1", (object)"X1").Merge(true);
                        }
                        if (iChiTietThoiGianLamViec3 == 13)
                        {
                            excelChiTietThoiGianLamViec_Ngay.get_Range((object)"Y1", (object)"Z1").Merge(true);
                        }
                        if (iChiTietThoiGianLamViec3 == 14)
                        {
                            excelChiTietThoiGianLamViec_Ngay.get_Range((object)"AA1", (object)"AB1").Merge(true);
                        }
                        if (iChiTietThoiGianLamViec3 == 15)
                        {
                            excelChiTietThoiGianLamViec_Ngay.get_Range((object)"AC1", (object)"AD1").Merge(true);
                        }
                        if (iChiTietThoiGianLamViec3 == 16)
                        {
                            excelChiTietThoiGianLamViec_Ngay.get_Range((object)"AE1", (object)"AF1").Merge(true);
                        }
                        if (iChiTietThoiGianLamViec3 == 17)
                        {
                            excelChiTietThoiGianLamViec_Ngay.get_Range((object)"AG1", (object)"AH1").Merge(true);
                        }
                        if (iChiTietThoiGianLamViec3 == 18)
                        {
                            excelChiTietThoiGianLamViec_Ngay.get_Range((object)"AI1", (object)"AJ1").Merge(true);
                        }
                        if (iChiTietThoiGianLamViec3 == 19)
                        {
                            excelChiTietThoiGianLamViec_Ngay.get_Range((object)"AK1", (object)"AL1").Merge(true);
                        }
                        if (iChiTietThoiGianLamViec3 == 20)
                        {
                            excelChiTietThoiGianLamViec_Ngay.get_Range((object)"AM1", (object)"AN1").Merge(true);
                        }
                        if (iChiTietThoiGianLamViec3 == 21)
                        {
                            excelChiTietThoiGianLamViec_Ngay.get_Range((object)"AO1", (object)"AP1").Merge(true);
                        }
                        if (iChiTietThoiGianLamViec3 == 22)
                        {
                            excelChiTietThoiGianLamViec_Ngay.get_Range((object)"AQ1", (object)"AR1").Merge(true);
                        }
                        if (iChiTietThoiGianLamViec3 == 23)
                        {
                            excelChiTietThoiGianLamViec_Ngay.get_Range((object)"AS1", (object)"AT1").Merge(true);
                        }
                        if (iChiTietThoiGianLamViec3 == 24)
                        {
                            excelChiTietThoiGianLamViec_Ngay.get_Range((object)"AU1", (object)"AV1").Merge(true);
                        }
                        if (iChiTietThoiGianLamViec3 == 25)
                        {
                            excelChiTietThoiGianLamViec_Ngay.get_Range((object)"AW1", (object)"AX1").Merge(true);
                        }
                        if (iChiTietThoiGianLamViec3 == 26)
                        {
                            excelChiTietThoiGianLamViec_Ngay.get_Range((object)"AY1", (object)"AZ1").Merge(true);
                        }
                        if (iChiTietThoiGianLamViec3 == 27)
                        {
                            excelChiTietThoiGianLamViec_Ngay.get_Range((object)"BA1", (object)"BB1").Merge(true);
                        }
                        if (iChiTietThoiGianLamViec3 == 28)
                        {
                            excelChiTietThoiGianLamViec_Ngay.get_Range((object)"BC1", (object)"BD1").Merge(true);
                        }
                        if (iChiTietThoiGianLamViec3 == 29)
                        {
                            excelChiTietThoiGianLamViec_Ngay.get_Range((object)"BE1", (object)"BF1").Merge(true);
                        }
                        if (iChiTietThoiGianLamViec3 == 30)
                        {
                            excelChiTietThoiGianLamViec_Ngay.get_Range((object)"BG1", (object)"BH1").Merge(true);
                        }
                        excelChiTietThoiGianLamViec_Ngay.get_Range((object)"BI1", (object)"BJ1").Merge(true);
                        excelChiTietThoiGianLamViec_Ngay.Cells[2, ColunmNgayChiTietThoiGianLamViec + iChiTietThoiGianLamViec3] = DateTimeProgress.XuatThuReport((int)dNgayChamChiTietThoiGianLamViec.AddDays(iChiTietThoiGianLamViec3).DayOfWeek);
                        if (iChiTietThoiGianLamViec3 == 0)
                        {
                            excelChiTietThoiGianLamViec_Ngay.get_Range((object)"A2", (object)"B2").Merge(true);
                        }
                        if (iChiTietThoiGianLamViec3 == 1)
                        {
                            excelChiTietThoiGianLamViec_Ngay.get_Range((object)"C2", (object)"D2").Merge(true);
                        }
                        if (iChiTietThoiGianLamViec3 == 2)
                        {
                            excelChiTietThoiGianLamViec_Ngay.get_Range((object)"E2", (object)"F2").Merge(true);
                        }
                        if (iChiTietThoiGianLamViec3 == 3)
                        {
                            excelChiTietThoiGianLamViec_Ngay.get_Range((object)"G2", (object)"H2").Merge(true);
                        }
                        if (iChiTietThoiGianLamViec3 == 4)
                        {
                            excelChiTietThoiGianLamViec_Ngay.get_Range((object)"I2", (object)"J2").Merge(true);
                        }
                        if (iChiTietThoiGianLamViec3 == 5)
                        {
                            excelChiTietThoiGianLamViec_Ngay.get_Range((object)"K2", (object)"L2").Merge(true);
                        }
                        if (iChiTietThoiGianLamViec3 == 6)
                        {
                            excelChiTietThoiGianLamViec_Ngay.get_Range((object)"K2", (object)"L2").Merge(true);
                        }
                        if (iChiTietThoiGianLamViec3 == 7)
                        {
                            excelChiTietThoiGianLamViec_Ngay.get_Range((object)"M2", (object)"N2").Merge(true);
                        }
                        if (iChiTietThoiGianLamViec3 == 8)
                        {
                            excelChiTietThoiGianLamViec_Ngay.get_Range((object)"O2", (object)"P2").Merge(true);
                        }
                        if (iChiTietThoiGianLamViec3 == 9)
                        {
                            excelChiTietThoiGianLamViec_Ngay.get_Range((object)"Q2", (object)"R2").Merge(true);
                        }
                        if (iChiTietThoiGianLamViec3 == 10)
                        {
                            excelChiTietThoiGianLamViec_Ngay.get_Range((object)"S2", (object)"T2").Merge(true);
                        }
                        if (iChiTietThoiGianLamViec3 == 11)
                        {
                            excelChiTietThoiGianLamViec_Ngay.get_Range((object)"U2", (object)"V2").Merge(true);
                        }
                        if (iChiTietThoiGianLamViec3 == 12)
                        {
                            excelChiTietThoiGianLamViec_Ngay.get_Range((object)"W2", (object)"X2").Merge(true);
                        }
                        if (iChiTietThoiGianLamViec3 == 13)
                        {
                            excelChiTietThoiGianLamViec_Ngay.get_Range((object)"Y2", (object)"Z2").Merge(true);
                        }
                        if (iChiTietThoiGianLamViec3 == 14)
                        {
                            excelChiTietThoiGianLamViec_Ngay.get_Range((object)"AA2", (object)"AB2").Merge(true);
                        }
                        if (iChiTietThoiGianLamViec3 == 15)
                        {
                            excelChiTietThoiGianLamViec_Ngay.get_Range((object)"AC2", (object)"AD2").Merge(true);
                        }
                        if (iChiTietThoiGianLamViec3 == 16)
                        {
                            excelChiTietThoiGianLamViec_Ngay.get_Range((object)"AE2", (object)"AF2").Merge(true);
                        }
                        if (iChiTietThoiGianLamViec3 == 17)
                        {
                            excelChiTietThoiGianLamViec_Ngay.get_Range((object)"AG2", (object)"AH2").Merge(true);
                        }
                        if (iChiTietThoiGianLamViec3 == 18)
                        {
                            excelChiTietThoiGianLamViec_Ngay.get_Range((object)"AI2", (object)"AJ2").Merge(true);
                        }
                        if (iChiTietThoiGianLamViec3 == 19)
                        {
                            excelChiTietThoiGianLamViec_Ngay.get_Range((object)"AK2", (object)"AL2").Merge(true);
                        }
                        if (iChiTietThoiGianLamViec3 == 20)
                        {
                            excelChiTietThoiGianLamViec_Ngay.get_Range((object)"AM2", (object)"AN2").Merge(true);
                        }
                        if (iChiTietThoiGianLamViec3 == 21)
                        {
                            excelChiTietThoiGianLamViec_Ngay.get_Range((object)"AO2", (object)"AP2").Merge(true);
                        }
                        if (iChiTietThoiGianLamViec3 == 22)
                        {
                            excelChiTietThoiGianLamViec_Ngay.get_Range((object)"AQ2", (object)"AR2").Merge(true);
                        }
                        if (iChiTietThoiGianLamViec3 == 23)
                        {
                            excelChiTietThoiGianLamViec_Ngay.get_Range((object)"AS2", (object)"AT2").Merge(true);
                        }
                        if (iChiTietThoiGianLamViec3 == 24)
                        {
                            excelChiTietThoiGianLamViec_Ngay.get_Range((object)"AU2", (object)"AV2").Merge(true);
                        }
                        if (iChiTietThoiGianLamViec3 == 25)
                        {
                            excelChiTietThoiGianLamViec_Ngay.get_Range((object)"AW2", (object)"AX2").Merge(true);
                        }
                        if (iChiTietThoiGianLamViec3 == 26)
                        {
                            excelChiTietThoiGianLamViec_Ngay.get_Range((object)"AY2", (object)"AZ2").Merge(true);
                        }
                        if (iChiTietThoiGianLamViec3 == 27)
                        {
                            excelChiTietThoiGianLamViec_Ngay.get_Range((object)"BA2", (object)"BB2").Merge(true);
                        }
                        if (iChiTietThoiGianLamViec3 == 28)
                        {
                            excelChiTietThoiGianLamViec_Ngay.get_Range((object)"BC2", (object)"BD2").Merge(true);
                        }
                        if (iChiTietThoiGianLamViec3 == 29)
                        {
                            excelChiTietThoiGianLamViec_Ngay.get_Range((object)"BE2", (object)"BF2").Merge(true);
                        }
                        if (iChiTietThoiGianLamViec3 == 30)
                        {
                            excelChiTietThoiGianLamViec_Ngay.get_Range((object)"BG2", (object)"BH2").Merge(true);
                        }
                        excelChiTietThoiGianLamViec_Ngay.get_Range((object)"BI2", (object)"BJ2").Merge(true);
                        ColunmNgayChiTietThoiGianLamViec++;
                        excelChiTietThoiGianLamViec_Ngay.ColumnWidth = 4;
                    }
                    Excel.Range excelChiTietThoiGianLamViec_TongGioCongHeader;
                    excelChiTietThoiGianLamViec_TongGioCongHeader = (ws_ChiTietThoiGianLamViec).get_Range((object)"BO6", (object)"BO8");
                    excelChiTietThoiGianLamViec_TongGioCongHeader.Cells[1, 1] = "TỔNG GIỜ CÔNG";
                    excelChiTietThoiGianLamViec_TongGioCongHeader.get_Range((object)"A1", (object)"A3").MergeCells = true;
                    excelChiTietThoiGianLamViec_TongGioCongHeader.ColumnWidth = 10;
                    excelChiTietThoiGianLamViec_TongGioCongHeader.VerticalAlignment = HorizontalAlignment.Center;
                    excelChiTietThoiGianLamViec_TongGioCongHeader.WrapText = true;
                    Excel.Range excelChiTietThoiGianLamViec_TongNgayHeader;
                    excelChiTietThoiGianLamViec_TongNgayHeader = (ws_ChiTietThoiGianLamViec).get_Range((object)"BP6", (object)"BP8");
                    excelChiTietThoiGianLamViec_TongNgayHeader.Cells[1, 1] = "TỔNG NGÀY";
                    excelChiTietThoiGianLamViec_TongNgayHeader.get_Range((object)"A1", (object)"A3").MergeCells = true;
                    excelChiTietThoiGianLamViec_TongNgayHeader.ColumnWidth = 10;
                    excelChiTietThoiGianLamViec_TongNgayHeader.VerticalAlignment = HorizontalAlignment.Center;
                    excelChiTietThoiGianLamViec_TongNgayHeader.WrapText = true;
                    Excel.Range excelChiTietThoiGianLamViec_TongGioTangCaHeader;
                    excelChiTietThoiGianLamViec_TongGioTangCaHeader = (ws_ChiTietThoiGianLamViec).get_Range((object)"BQ6", (object)"BQ8");
                    excelChiTietThoiGianLamViec_TongGioTangCaHeader.Cells[1, 1] = "TỔNG GIỜ TĂNG CA";
                    excelChiTietThoiGianLamViec_TongGioTangCaHeader.get_Range((object)"A1", (object)"A3").MergeCells = true;
                    excelChiTietThoiGianLamViec_TongGioTangCaHeader.ColumnWidth = 10;
                    excelChiTietThoiGianLamViec_TongGioTangCaHeader.VerticalAlignment = HorizontalAlignment.Center;
                    excelChiTietThoiGianLamViec_TongGioTangCaHeader.WrapText = true;
                    Excel.Range excelChiTietThoiGianLamViec_TongPhutTreHeader;
                    excelChiTietThoiGianLamViec_TongPhutTreHeader = (ws_ChiTietThoiGianLamViec).get_Range((object)"BR6", (object)"BR8");
                    excelChiTietThoiGianLamViec_TongPhutTreHeader.Cells[1, 1] = "TỔNG PHÚT TRỄ";
                    excelChiTietThoiGianLamViec_TongPhutTreHeader.get_Range((object)"A1", (object)"A3").MergeCells = true;
                    excelChiTietThoiGianLamViec_TongPhutTreHeader.ColumnWidth = 10;
                    excelChiTietThoiGianLamViec_TongPhutTreHeader.VerticalAlignment = HorizontalAlignment.Center;
                    excelChiTietThoiGianLamViec_TongPhutTreHeader.WrapText = true;
                    Excel.Range excelChiTietThoiGianLamViec_TongPhutSomHeader;
                    excelChiTietThoiGianLamViec_TongPhutSomHeader = (ws_ChiTietThoiGianLamViec).get_Range((object)"BS6", (object)"BS8");
                    excelChiTietThoiGianLamViec_TongPhutSomHeader.Cells[1, 1] = "TỔNG PHÚT SỚM";
                    excelChiTietThoiGianLamViec_TongPhutSomHeader.get_Range((object)"A1", (object)"A3").MergeCells = true;
                    excelChiTietThoiGianLamViec_TongPhutSomHeader.ColumnWidth = 10;
                    excelChiTietThoiGianLamViec_TongPhutSomHeader.VerticalAlignment = HorizontalAlignment.Center;
                    excelChiTietThoiGianLamViec_TongPhutSomHeader.WrapText = true;
                    Excel.Range excelChiTietThoiGianLamViec_DinhDangHeader;
                    excelChiTietThoiGianLamViec_DinhDangHeader = (ws_ChiTietThoiGianLamViec).get_Range((object)"A6", (object)"BS8");
                    excelChiTietThoiGianLamViec_DinhDangHeader.Font.Name = "Times New Roman";
                    excelChiTietThoiGianLamViec_DinhDangHeader.Font.Size = "10";
                    excelChiTietThoiGianLamViec_DinhDangHeader.Font.Bold = true;
                    excelChiTietThoiGianLamViec_DinhDangHeader.HorizontalAlignment = Excel.Constants.xlCenter;
                    excelChiTietThoiGianLamViec_DinhDangHeader.Borders.LineStyle = Excel.Constants.xlBoth;
                    excelChiTietThoiGianLamViec_DinhDangHeader.Interior.Color = ColorTranslator.ToOle(Color.Aqua);
                    xla_ChiTietThoiGianLamViec.Visible = true;
                    if (iChonLanXuat == 1)
                    {
                        int iTangHang;
                        iTangHang = 9;
                        int iDemNhanVienChiTietThoiGianLamViec3;
                        iDemNhanVienChiTietThoiGianLamViec3 = 0;
                        int iDemSTTChiTietThoiGianLamViec3;
                        iDemSTTChiTietThoiGianLamViec3 = 0;
                        int iTongDongChiTietThoiGianLamViec3;
                        iTongDongChiTietThoiGianLamViec3 = 9;
                        new DataTable();
                        _tinhCongDTO.Ngay = dNgayBatDauTinhCong;
                        int iMaChamCongChiTietThoiGianLamViec3;
                        iMaChamCongChiTietThoiGianLamViec3 = 0;
                        DataTable dtNhanVienChiTietThoiGianLamViec3;
                        dtNhanVienChiTietThoiGianLamViec3 = _tinhCongBLL.TinhCongGetNgay(_tinhCongDTO);
                        for (int iNhanVienChiTietThoiGianLamViec3 = 0; iNhanVienChiTietThoiGianLamViec3 < dtNhanVienChiTietThoiGianLamViec3.Rows.Count; iNhanVienChiTietThoiGianLamViec3++)
                        {
                            if (Convert.ToInt32(dtNhanVienChiTietThoiGianLamViec3.Rows[iNhanVienChiTietThoiGianLamViec3]["MaChamCong"].ToString()) == iMaChamCongChiTietThoiGianLamViec3)
                            {
                                continue;
                            }
                            iDemSTTChiTietThoiGianLamViec3++;
                            iMaChamCongChiTietThoiGianLamViec3 = Convert.ToInt32(dtNhanVienChiTietThoiGianLamViec3.Rows[iNhanVienChiTietThoiGianLamViec3]["MaChamCong"].ToString());
                            string sMaNhanVienChiTietThoiGianLamViec3;
                            sMaNhanVienChiTietThoiGianLamViec3 = dtNhanVienChiTietThoiGianLamViec3.Rows[iNhanVienChiTietThoiGianLamViec3]["MaNhanVien"].ToString();
                            string sTenNhanVienChiTietThoiGianLamViec3;
                            sTenNhanVienChiTietThoiGianLamViec3 = dtNhanVienChiTietThoiGianLamViec3.Rows[iNhanVienChiTietThoiGianLamViec3]["TenNhanVien"].ToString();
                            Excel.Range excelChiTietThoiGianLamViec_STTDuLieu3;
                            excelChiTietThoiGianLamViec_STTDuLieu3 = (ws_ChiTietThoiGianLamViec).get_Range((object)("A" + (iTongDongChiTietThoiGianLamViec3 + iDemNhanVienChiTietThoiGianLamViec3 * 2)), (object)("A" + (iTongDongChiTietThoiGianLamViec3 + iDemNhanVienChiTietThoiGianLamViec3 * 2)));
                            excelChiTietThoiGianLamViec_STTDuLieu3.Cells[1, 1] = iDemSTTChiTietThoiGianLamViec3;
                            excelChiTietThoiGianLamViec_STTDuLieu3.get_Range((object)"A1", (object)"A2").MergeCells = true;
                            excelChiTietThoiGianLamViec_STTDuLieu3.Select();
                            Excel.Range excelChiTietThoiGianLamViec_MaNhanVienDuLieu3;
                            excelChiTietThoiGianLamViec_MaNhanVienDuLieu3 = (ws_ChiTietThoiGianLamViec).get_Range((object)("B" + (iTongDongChiTietThoiGianLamViec3 + iDemNhanVienChiTietThoiGianLamViec3 * 2)), (object)("B" + (iTongDongChiTietThoiGianLamViec3 + iDemNhanVienChiTietThoiGianLamViec3 * 2)));
                            excelChiTietThoiGianLamViec_MaNhanVienDuLieu3.get_Range((object)"A1", (object)"A2").NumberFormat = "@";
                            excelChiTietThoiGianLamViec_MaNhanVienDuLieu3.get_Range((object)"A1", (object)"A2").MergeCells = true;
                            excelChiTietThoiGianLamViec_MaNhanVienDuLieu3.Cells[1, 1] = sMaNhanVienChiTietThoiGianLamViec3;
                            Excel.Range excelChiTietThoiGianLamViec_TenNhanVienDuLieu3;
                            excelChiTietThoiGianLamViec_TenNhanVienDuLieu3 = (ws_ChiTietThoiGianLamViec).get_Range((object)("C" + (iTongDongChiTietThoiGianLamViec3 + iDemNhanVienChiTietThoiGianLamViec3 * 2)), (object)("C" + (iTongDongChiTietThoiGianLamViec3 + iDemNhanVienChiTietThoiGianLamViec3 * 2)));
                            excelChiTietThoiGianLamViec_TenNhanVienDuLieu3.Cells[1, 1] = sTenNhanVienChiTietThoiGianLamViec3;
                            excelChiTietThoiGianLamViec_TenNhanVienDuLieu3.get_Range((object)"A1", (object)"A2").MergeCells = true;
                            string sTenPhongBan3;
                            sTenPhongBan3 = "";
                            new DataTable();
                            _phongBanDTO.MaPhongBan = dtNhanVienChiTietThoiGianLamViec3.Rows[iNhanVienChiTietThoiGianLamViec3]["PhongBan"].ToString();
                            DataTable dtPhongBan3;
                            dtPhongBan3 = _phongBanBLL.getTenPhongBanByMaPhongBan(_phongBanDTO);
                            for (int iPhongBan3 = 0; iPhongBan3 < dtPhongBan3.Rows.Count; iPhongBan3++)
                            {
                                sTenPhongBan3 = dtPhongBan3.Rows[iPhongBan3]["TenPhongBan"].ToString();
                            }
                            Excel.Range excelChiTietThoiGianLamViec_PhongBanDuLieu3;
                            excelChiTietThoiGianLamViec_PhongBanDuLieu3 = (ws_ChiTietThoiGianLamViec).get_Range((object)("D" + (iTongDongChiTietThoiGianLamViec3 + iDemNhanVienChiTietThoiGianLamViec3 * 2)), (object)("D" + (iTongDongChiTietThoiGianLamViec3 + iDemNhanVienChiTietThoiGianLamViec3 * 2)));
                            excelChiTietThoiGianLamViec_PhongBanDuLieu3.get_Range((object)"A1", (object)"A2").MergeCells = true;
                            if (sTenPhongBan3 == "")
                            {
                                excelChiTietThoiGianLamViec_PhongBanDuLieu3.Cells[1, 1] = "------";
                            }
                            else
                            {
                                excelChiTietThoiGianLamViec_PhongBanDuLieu3.Cells[1, 1] = sTenPhongBan3;
                            }
                            int iDemNgayChiTietThoiGianLamViec3;
                            iDemNgayChiTietThoiGianLamViec3 = 0;
                            int iCotGioVao3;
                            iCotGioVao3 = 1;
                            int iCotGioRa3;
                            iCotGioRa3 = 2;
                            int iTangCot;
                            iTangCot = 5;
                            for (int iGioChamChiTietThoiGianLamViec3 = 0; iGioChamChiTietThoiGianLamViec3 < 31; iGioChamChiTietThoiGianLamViec3++)
                            {
                                string sGioVao2;
                                sGioVao2 = "";
                                string sGioRa2;
                                sGioRa2 = "";
                                DateTime dNgayChiTietThoiGianLamViec3;
                                dNgayChiTietThoiGianLamViec3 = Convert.ToDateTime(dNgayBatDauTinhCong.AddDays(iDemNgayChiTietThoiGianLamViec3).ToString());
                                new DataTable();
                                _tinhCongDTO.MaChamCong = iMaChamCongChiTietThoiGianLamViec3;
                                _tinhCongDTO.Ngay = dNgayChiTietThoiGianLamViec3;
                                DataTable dtDuLieuGioChiTietThoiGianLamViec3;
                                dtDuLieuGioChiTietThoiGianLamViec3 = _tinhCongBLL.TinhCongGetMaChamCongAndNgayChiTietThoiGian(_tinhCongDTO);
                                int iDuLieuGioChiTietThoiGianLamViec3;
                                iDuLieuGioChiTietThoiGianLamViec3 = 0;
                                if (iDuLieuGioChiTietThoiGianLamViec3 < dtDuLieuGioChiTietThoiGianLamViec3.Rows.Count)
                                {
                                    string sThu;
                                    sThu = dtDuLieuGioChiTietThoiGianLamViec3.Rows[iDuLieuGioChiTietThoiGianLamViec3]["Thu"].ToString();
                                    string sGioVaoChiTietThoiGianLamViec3;
                                    sGioVaoChiTietThoiGianLamViec3 = dtDuLieuGioChiTietThoiGianLamViec3.Rows[iDuLieuGioChiTietThoiGianLamViec3]["GioVao"].ToString();
                                    string sGioRaChiTietThoiGianLamViec3;
                                    sGioRaChiTietThoiGianLamViec3 = dtDuLieuGioChiTietThoiGianLamViec3.Rows[iDuLieuGioChiTietThoiGianLamViec3]["GioRa"].ToString();
                                    double dGioTungNgayChiTietThoiGianLamViec3;
                                    dGioTungNgayChiTietThoiGianLamViec3 = Convert.ToDouble(dtDuLieuGioChiTietThoiGianLamViec3.Rows[iDuLieuGioChiTietThoiGianLamViec3]["Gio"].ToString());
                                    double dTongGioTangCaNgayChiTietThoiGianLamViec3;
                                    dTongGioTangCaNgayChiTietThoiGianLamViec3 = Convert.ToDouble(dtDuLieuGioChiTietThoiGianLamViec3.Rows[iDuLieuGioChiTietThoiGianLamViec3]["TC1"]) + Convert.ToDouble(dtDuLieuGioChiTietThoiGianLamViec3.Rows[iDuLieuGioChiTietThoiGianLamViec3]["TC2"]);
                                    if (sGioVaoChiTietThoiGianLamViec3 != "")
                                    {
                                        DateTime dGioVao3;
                                        dGioVao3 = Convert.ToDateTime(sGioVaoChiTietThoiGianLamViec3);
                                        sGioVao2 = dGioVao3.Hour + ":" + dGioVao3.Minute;
                                    }
                                    if (sGioRaChiTietThoiGianLamViec3 != "")
                                    {
                                        DateTime dGioRa3;
                                        dGioRa3 = Convert.ToDateTime(sGioRaChiTietThoiGianLamViec3);
                                        sGioRa2 = dGioRa3.Hour + ":" + dGioRa3.Minute;
                                    }
                                    (ws_ChiTietThoiGianLamViec).get_Range((object)("E" + (iTongDongChiTietThoiGianLamViec3 + iDemNhanVienChiTietThoiGianLamViec3 * 2)), (object)("BN" + (iTongDongChiTietThoiGianLamViec3 + iDemNhanVienChiTietThoiGianLamViec3 * 2))).Cells[1, iCotGioVao3] = sGioVao2;
                                    (ws_ChiTietThoiGianLamViec).get_Range((object)("E" + (iTongDongChiTietThoiGianLamViec3 + iDemNhanVienChiTietThoiGianLamViec3 * 2)), (object)("BN" + (iTongDongChiTietThoiGianLamViec3 + iDemNhanVienChiTietThoiGianLamViec3 * 2))).Cells[1, iCotGioRa3] = sGioRa2;
                                    (ws_ChiTietThoiGianLamViec).get_Range((object)("E" + (iTongDongChiTietThoiGianLamViec3 + iDemNhanVienChiTietThoiGianLamViec3 * 2 + 1)), (object)("BN" + (iTongDongChiTietThoiGianLamViec3 + iDemNhanVienChiTietThoiGianLamViec3 * 2 + 1))).Cells[1, iCotGioVao3] = dGioTungNgayChiTietThoiGianLamViec3;
                                    (ws_ChiTietThoiGianLamViec).get_Range((object)("E" + (iTongDongChiTietThoiGianLamViec3 + iDemNhanVienChiTietThoiGianLamViec3 * 2 + 1)), (object)("BN" + (iTongDongChiTietThoiGianLamViec3 + iDemNhanVienChiTietThoiGianLamViec3 * 2 + 1))).Cells[1, iCotGioRa3] = dTongGioTangCaNgayChiTietThoiGianLamViec3;
                                    if (sThu == "CN")
                                    {
                                        Excel.Range fuckVisual5;
                                        fuckVisual5 = (ws_ChiTietThoiGianLamViec).get_Range(ws_ChiTietThoiGianLamViec.Cells[iTangHang - 1, iTangCot], ws_ChiTietThoiGianLamViec.Cells[iTangHang, iTangCot + 1]);
                                        Excel.Range fuckVisual6;
                                        fuckVisual6 = (ws_ChiTietThoiGianLamViec).get_Range(ws_ChiTietThoiGianLamViec.Cells[iTangHang - 2, iTangCot], ws_ChiTietThoiGianLamViec.Cells[iTangHang, iTangCot + 1]);
                                        Excel.Range fuckVisual3;
                                        fuckVisual3 = (ws_ChiTietThoiGianLamViec).get_Range(ws_ChiTietThoiGianLamViec.Cells[iTangHang + 1, iTangCot], ws_ChiTietThoiGianLamViec.Cells[iTangHang, iTangCot + 1]);
                                        Excel.Range fuckVisual4;
                                        fuckVisual4 = (ws_ChiTietThoiGianLamViec).get_Range(ws_ChiTietThoiGianLamViec.Cells[iTangHang + 1, iTangCot + 1], ws_ChiTietThoiGianLamViec.Cells[iTangHang, iTangCot + 1]);
                                        fuckVisual3.Interior.Color = ColorTranslator.ToOle(Color.PaleGoldenrod);
                                        fuckVisual4.Interior.Color = ColorTranslator.ToOle(Color.PaleGoldenrod);
                                        fuckVisual5.Interior.Color = ColorTranslator.ToOle(Color.PaleGoldenrod);
                                        fuckVisual6.Interior.Color = ColorTranslator.ToOle(Color.PaleGoldenrod);
                                    }
                                }
                                iCotGioVao3 = iCotGioVao3 + 1 + 1;
                                iCotGioRa3 = iCotGioRa3 + 1 + 1;
                                iDemNgayChiTietThoiGianLamViec3++;
                                iTangCot = iTangCot + 1 + 1;
                            }
                            double dTongGioChiTietThoiGianLamViec3;
                            dTongGioChiTietThoiGianLamViec3 = 0.0;
                            double dTongCongChiTietThoiGianLamViec3;
                            dTongCongChiTietThoiGianLamViec3 = 0.0;
                            double dTongTangCaChiTietThoiGianLamViec3;
                            dTongTangCaChiTietThoiGianLamViec3 = 0.0;
                            int iTongPhutTreChiTietThoiGianLamViec3;
                            iTongPhutTreChiTietThoiGianLamViec3 = 0;
                            int iTongPhutSomChiTietThoiGianLamViec3;
                            iTongPhutSomChiTietThoiGianLamViec3 = 0;
                            new DataTable();
                            _tinhCongDTO.MaChamCong = iMaChamCongChiTietThoiGianLamViec3;
                            DataTable dtChiTietThoiGianLamViec3;
                            dtChiTietThoiGianLamViec3 = _tinhCongBLL.TinhCongGetByMaChamCong(_tinhCongDTO);
                            for (int iChiTietThoiGianLamViec4 = 0; iChiTietThoiGianLamViec4 < dtChiTietThoiGianLamViec3.Rows.Count; iChiTietThoiGianLamViec4++)
                            {
                                dTongGioChiTietThoiGianLamViec3 += Convert.ToDouble(dtChiTietThoiGianLamViec3.Rows[iChiTietThoiGianLamViec4]["Gio"].ToString());
                                dTongCongChiTietThoiGianLamViec3 += Convert.ToDouble(dtChiTietThoiGianLamViec3.Rows[iChiTietThoiGianLamViec4]["Cong"].ToString());
                                dTongTangCaChiTietThoiGianLamViec3 += Convert.ToDouble(dtChiTietThoiGianLamViec3.Rows[iChiTietThoiGianLamViec4]["TC1"].ToString()) + Convert.ToDouble(dtChiTietThoiGianLamViec3.Rows[iChiTietThoiGianLamViec4]["TC2"].ToString()) + Convert.ToDouble(dtChiTietThoiGianLamViec3.Rows[iChiTietThoiGianLamViec4]["TC3"].ToString()) + Convert.ToDouble(dtChiTietThoiGianLamViec3.Rows[iChiTietThoiGianLamViec4]["TC4"].ToString());
                                iTongPhutTreChiTietThoiGianLamViec3 += Convert.ToInt32(dtChiTietThoiGianLamViec3.Rows[iChiTietThoiGianLamViec4]["Tre"].ToString());
                                iTongPhutSomChiTietThoiGianLamViec3 += Convert.ToInt32(dtChiTietThoiGianLamViec3.Rows[iChiTietThoiGianLamViec4]["VeSom"].ToString());
                            }
                            Excel.Range excelChiTietThoiGianLamViec_TongGioDuLieu3;
                            excelChiTietThoiGianLamViec_TongGioDuLieu3 = (ws_ChiTietThoiGianLamViec).get_Range((object)("BO" + (iTongDongChiTietThoiGianLamViec3 + iDemNhanVienChiTietThoiGianLamViec3 * 2)), (object)("BO" + (iTongDongChiTietThoiGianLamViec3 + iDemNhanVienChiTietThoiGianLamViec3 * 2) + 1));
                            excelChiTietThoiGianLamViec_TongGioDuLieu3.Cells[1, 1] = dTongGioChiTietThoiGianLamViec3;
                            excelChiTietThoiGianLamViec_TongGioDuLieu3.get_Range((object)"A1", (object)"A2").MergeCells = true;
                            Excel.Range excelChiTietThoiGianLamViec_TongCongDuLieu3;
                            excelChiTietThoiGianLamViec_TongCongDuLieu3 = (ws_ChiTietThoiGianLamViec).get_Range((object)("BP" + (iTongDongChiTietThoiGianLamViec3 + iDemNhanVienChiTietThoiGianLamViec3 * 2)), (object)("BP" + (iTongDongChiTietThoiGianLamViec3 + iDemNhanVienChiTietThoiGianLamViec3 * 2) + 1));
                            excelChiTietThoiGianLamViec_TongCongDuLieu3.Cells[1, 1] = dTongCongChiTietThoiGianLamViec3;
                            excelChiTietThoiGianLamViec_TongCongDuLieu3.get_Range((object)"A1", (object)"A2").MergeCells = true;
                            Excel.Range excelChiTietThoiGianLamViec_TongTangCaDuLieu3;
                            excelChiTietThoiGianLamViec_TongTangCaDuLieu3 = (ws_ChiTietThoiGianLamViec).get_Range((object)("BQ" + (iTongDongChiTietThoiGianLamViec3 + iDemNhanVienChiTietThoiGianLamViec3 * 2)), (object)("BQ" + (iTongDongChiTietThoiGianLamViec3 + iDemNhanVienChiTietThoiGianLamViec3 * 2) + 1));
                            excelChiTietThoiGianLamViec_TongTangCaDuLieu3.Cells[1, 1] = dTongTangCaChiTietThoiGianLamViec3;
                            excelChiTietThoiGianLamViec_TongTangCaDuLieu3.get_Range((object)"A1", (object)"A2").MergeCells = true;
                            Excel.Range excelChiTietThoiGianLamViec_TongPhutTreDuLieu3;
                            excelChiTietThoiGianLamViec_TongPhutTreDuLieu3 = (ws_ChiTietThoiGianLamViec).get_Range((object)("BR" + (iTongDongChiTietThoiGianLamViec3 + iDemNhanVienChiTietThoiGianLamViec3 * 2)), (object)("BR" + (iTongDongChiTietThoiGianLamViec3 + iDemNhanVienChiTietThoiGianLamViec3 * 2) + 1));
                            excelChiTietThoiGianLamViec_TongPhutTreDuLieu3.Cells[1, 1] = iTongPhutTreChiTietThoiGianLamViec3;
                            excelChiTietThoiGianLamViec_TongPhutTreDuLieu3.get_Range((object)"A1", (object)"A2").MergeCells = true;
                            Excel.Range excelChiTietThoiGianLamViec_TongPhutSomDuLieu3;
                            excelChiTietThoiGianLamViec_TongPhutSomDuLieu3 = (ws_ChiTietThoiGianLamViec).get_Range((object)("BS" + (iTongDongChiTietThoiGianLamViec3 + iDemNhanVienChiTietThoiGianLamViec3 * 2)), (object)("BS" + (iTongDongChiTietThoiGianLamViec3 + iDemNhanVienChiTietThoiGianLamViec3 * 2) + 1));
                            excelChiTietThoiGianLamViec_TongPhutSomDuLieu3.Cells[1, 1] = iTongPhutSomChiTietThoiGianLamViec3;
                            excelChiTietThoiGianLamViec_TongPhutSomDuLieu3.get_Range((object)"A1", (object)"A2").MergeCells = true;
                            iDemNhanVienChiTietThoiGianLamViec3++;
                            iTangHang = iTangHang + 1 + 1;
                        }
                        ws_ChiTietThoiGianLamViec.PageSetup.Orientation = Excel.XlPageOrientation.xlLandscape;
                        ws_ChiTietThoiGianLamViec.PageSetup.PaperSize = Excel.XlPaperSize.xlPaperA4;
                        ws_ChiTietThoiGianLamViec.PageSetup.LeftMargin = 13.0;
                        ws_ChiTietThoiGianLamViec.PageSetup.RightMargin = 0.0;
                        ws_ChiTietThoiGianLamViec.PageSetup.BottomMargin = 0.0;
                        ws_ChiTietThoiGianLamViec.PageSetup.TopMargin = 0.0;
                        ws_ChiTietThoiGianLamViec.PageSetup.Zoom = 46;
                        Excel.Range excelChiTietThoiGianLamViec_DinhDangDuLieu3;
                        excelChiTietThoiGianLamViec_DinhDangDuLieu3 = (ws_ChiTietThoiGianLamViec).get_Range((object)"A9", (object)("BS" + (iTongDongChiTietThoiGianLamViec3 + iDemNhanVienChiTietThoiGianLamViec3 * 2 - 1)));
                        excelChiTietThoiGianLamViec_DinhDangDuLieu3.Font.Name = "Times New Roman";
                        excelChiTietThoiGianLamViec_DinhDangDuLieu3.Font.Size = "8";
                        excelChiTietThoiGianLamViec_DinhDangDuLieu3.HorizontalAlignment = Excel.Constants.xlCenter;
                        excelChiTietThoiGianLamViec_DinhDangDuLieu3.Borders.LineStyle = Excel.Constants.xlBoth;
                    }
                    if (iChonLanXuat == 2)
                    {
                        int iDemNhanVienChiTietThoiGianLamViec2;
                        iDemNhanVienChiTietThoiGianLamViec2 = 0;
                        int iDemSTTChiTietThoiGianLamViec2;
                        iDemSTTChiTietThoiGianLamViec2 = 0;
                        int iTongDongChiTietThoiGianLamViec2;
                        iTongDongChiTietThoiGianLamViec2 = 9;
                        new DataTable();
                        _tinhCongDTO.Ngay = dTuNgayChiTietThoiGianLamViec;
                        int iMaChamCongChiTietThoiGianLamViec2;
                        iMaChamCongChiTietThoiGianLamViec2 = 0;
                        DataTable dtNhanVienChiTietThoiGianLamViec2;
                        dtNhanVienChiTietThoiGianLamViec2 = _tinhCongBLL.TinhCongGetNgay(_tinhCongDTO);
                        for (int iNhanVienChiTietThoiGianLamViec2 = 0; iNhanVienChiTietThoiGianLamViec2 < dtNhanVienChiTietThoiGianLamViec2.Rows.Count; iNhanVienChiTietThoiGianLamViec2++)
                        {
                            if (Convert.ToInt32(dtNhanVienChiTietThoiGianLamViec2.Rows[iNhanVienChiTietThoiGianLamViec2]["MaChamCong"].ToString()) == iMaChamCongChiTietThoiGianLamViec2)
                            {
                                continue;
                            }
                            iDemSTTChiTietThoiGianLamViec2++;
                            iMaChamCongChiTietThoiGianLamViec2 = Convert.ToInt32(dtNhanVienChiTietThoiGianLamViec2.Rows[iNhanVienChiTietThoiGianLamViec2]["MaChamCong"].ToString());
                            string sMaNhanVienChiTietThoiGianLamViec2;
                            sMaNhanVienChiTietThoiGianLamViec2 = dtNhanVienChiTietThoiGianLamViec2.Rows[iNhanVienChiTietThoiGianLamViec2]["MaNhanVien"].ToString();
                            string sTenNhanVienChiTietThoiGianLamViec2;
                            sTenNhanVienChiTietThoiGianLamViec2 = dtNhanVienChiTietThoiGianLamViec2.Rows[iNhanVienChiTietThoiGianLamViec2]["TenNhanVien"].ToString();
                            Excel.Range excelChiTietThoiGianLamViec_STTDuLieu2;
                            excelChiTietThoiGianLamViec_STTDuLieu2 = (ws_ChiTietThoiGianLamViec).get_Range((object)("A" + (iTongDongChiTietThoiGianLamViec2 + iDemNhanVienChiTietThoiGianLamViec2 * 3)), (object)("A" + (iTongDongChiTietThoiGianLamViec2 + iDemNhanVienChiTietThoiGianLamViec2 * 3)));
                            excelChiTietThoiGianLamViec_STTDuLieu2.get_Range((object)"A1", (object)"A3").MergeCells = true;
                            excelChiTietThoiGianLamViec_STTDuLieu2.Cells[1, 1] = iDemSTTChiTietThoiGianLamViec2.ToString();
                            excelChiTietThoiGianLamViec_STTDuLieu2.Select();
                            Excel.Range excelChiTietThoiGianLamViec_MaNhanVienDuLieu2;
                            excelChiTietThoiGianLamViec_MaNhanVienDuLieu2 = (ws_ChiTietThoiGianLamViec).get_Range((object)("B" + (iTongDongChiTietThoiGianLamViec2 + iDemNhanVienChiTietThoiGianLamViec2 * 3)), (object)("B" + (iTongDongChiTietThoiGianLamViec2 + iDemNhanVienChiTietThoiGianLamViec2 * 3)));
                            excelChiTietThoiGianLamViec_MaNhanVienDuLieu2.get_Range((object)"A1", (object)"A1").NumberFormat = "@";
                            excelChiTietThoiGianLamViec_MaNhanVienDuLieu2.get_Range((object)"A1", (object)"A3").MergeCells = true;
                            excelChiTietThoiGianLamViec_MaNhanVienDuLieu2.Cells[1, 1] = sMaNhanVienChiTietThoiGianLamViec2;
                            Excel.Range excelChiTietThoiGianLamViec_TenNhanVienDuLieu2;
                            excelChiTietThoiGianLamViec_TenNhanVienDuLieu2 = (ws_ChiTietThoiGianLamViec).get_Range((object)("C" + (iTongDongChiTietThoiGianLamViec2 + iDemNhanVienChiTietThoiGianLamViec2 * 3)), (object)("C" + (iTongDongChiTietThoiGianLamViec2 + iDemNhanVienChiTietThoiGianLamViec2 * 3)));
                            excelChiTietThoiGianLamViec_TenNhanVienDuLieu2.get_Range((object)"A1", (object)"A3").MergeCells = true;
                            excelChiTietThoiGianLamViec_TenNhanVienDuLieu2.Cells[1, 1] = sTenNhanVienChiTietThoiGianLamViec2;
                            string sTenPhongBan2;
                            sTenPhongBan2 = "";
                            new DataTable();
                            _phongBanDTO.MaPhongBan = dtNhanVienChiTietThoiGianLamViec2.Rows[iNhanVienChiTietThoiGianLamViec2]["PhongBan"].ToString();
                            DataTable dtPhongBan2;
                            dtPhongBan2 = _phongBanBLL.getTenPhongBanByMaPhongBan(_phongBanDTO);
                            for (int iPhongBan2 = 0; iPhongBan2 < dtPhongBan2.Rows.Count; iPhongBan2++)
                            {
                                sTenPhongBan2 = dtPhongBan2.Rows[iPhongBan2]["TenPhongBan"].ToString();
                            }
                            Excel.Range excelChiTietThoiGianLamViec_PhongBanDuLieu2;
                            excelChiTietThoiGianLamViec_PhongBanDuLieu2 = (ws_ChiTietThoiGianLamViec).get_Range((object)("D" + (iTongDongChiTietThoiGianLamViec2 + iDemNhanVienChiTietThoiGianLamViec2 * 3)), (object)("D" + (iTongDongChiTietThoiGianLamViec2 + iDemNhanVienChiTietThoiGianLamViec2 * 3)));
                            excelChiTietThoiGianLamViec_PhongBanDuLieu2.get_Range((object)"A1", (object)"A3").MergeCells = true;
                            if (sTenPhongBan2 == "")
                            {
                                excelChiTietThoiGianLamViec_PhongBanDuLieu2.Cells[1, 1] = "------";
                            }
                            else
                            {
                                excelChiTietThoiGianLamViec_PhongBanDuLieu2.Cells[1, 1] = sTenPhongBan2;
                            }
                            int iDemNgayChiTietThoiGianLamViec2;
                            iDemNgayChiTietThoiGianLamViec2 = 0;
                            int iCotGioVao2;
                            iCotGioVao2 = 1;
                            int iCotGioRa2;
                            iCotGioRa2 = 2;
                            for (int iGioChamChiTietThoiGianLamViec2 = 0; iGioChamChiTietThoiGianLamViec2 < 31; iGioChamChiTietThoiGianLamViec2++)
                            {
                                int iDemLanCham4LanChiTietThoiGianLamViec2;
                                iDemLanCham4LanChiTietThoiGianLamViec2 = 0;
                                double dGioTungNgayChiTietThoiGianLamViec2;
                                dGioTungNgayChiTietThoiGianLamViec2 = 0.0;
                                double dTongGioTangCaNgayChiTietThoiGianLamViec2;
                                dTongGioTangCaNgayChiTietThoiGianLamViec2 = 0.0;
                                DateTime dNgayChiTietThoiGianLamViec2;
                                dNgayChiTietThoiGianLamViec2 = Convert.ToDateTime(dNgayBatDauTinhCong.AddDays(iDemNgayChiTietThoiGianLamViec2).ToString());
                                new DataTable();
                                _tinhCongDTO.MaChamCong = iMaChamCongChiTietThoiGianLamViec2;
                                _tinhCongDTO.Ngay = dNgayChiTietThoiGianLamViec2;
                                DataTable dtDuLieuGioChiTietThoiGianLamViec2;
                                dtDuLieuGioChiTietThoiGianLamViec2 = _tinhCongBLL.TinhCongGetMaChamCongAndNgayChiTietThoiGian(_tinhCongDTO);
                                for (int iDuLieuGioChiTietThoiGianLamViec2 = 0; iDuLieuGioChiTietThoiGianLamViec2 < dtDuLieuGioChiTietThoiGianLamViec2.Rows.Count; iDuLieuGioChiTietThoiGianLamViec2++)
                                {
                                    if (iDemLanCham4LanChiTietThoiGianLamViec2 == 2)
                                    {
                                        break;
                                    }
                                    string sGioVao3;
                                    sGioVao3 = "";
                                    string sGioRa3;
                                    sGioRa3 = "";
                                    string sGioVaoChiTietThoiGianLamViec2;
                                    sGioVaoChiTietThoiGianLamViec2 = dtDuLieuGioChiTietThoiGianLamViec2.Rows[iDuLieuGioChiTietThoiGianLamViec2]["GioVao"].ToString();
                                    string sGioRaChiTietThoiGianLamViec2;
                                    sGioRaChiTietThoiGianLamViec2 = dtDuLieuGioChiTietThoiGianLamViec2.Rows[iDuLieuGioChiTietThoiGianLamViec2]["GioRa"].ToString();
                                    dGioTungNgayChiTietThoiGianLamViec2 += Convert.ToDouble(dtDuLieuGioChiTietThoiGianLamViec2.Rows[iDuLieuGioChiTietThoiGianLamViec2]["Gio"].ToString());
                                    dTongGioTangCaNgayChiTietThoiGianLamViec2 += Convert.ToDouble(dtDuLieuGioChiTietThoiGianLamViec2.Rows[iDuLieuGioChiTietThoiGianLamViec2]["TC1"]) + Convert.ToDouble(dtDuLieuGioChiTietThoiGianLamViec2.Rows[iDuLieuGioChiTietThoiGianLamViec2]["TC2"]);
                                    if (sGioVaoChiTietThoiGianLamViec2 != "")
                                    {
                                        DateTime dGioVao2;
                                        dGioVao2 = Convert.ToDateTime(sGioVaoChiTietThoiGianLamViec2);
                                        sGioVao3 = dGioVao2.Hour + ":" + dGioVao2.Minute;
                                    }
                                    if (sGioRaChiTietThoiGianLamViec2 != "")
                                    {
                                        DateTime dGioRa2;
                                        dGioRa2 = Convert.ToDateTime(sGioRaChiTietThoiGianLamViec2);
                                        sGioRa3 = dGioRa2.Hour + ":" + dGioRa2.Minute;
                                    }
                                    if (iDemLanCham4LanChiTietThoiGianLamViec2 == 0)
                                    {
                                        (ws_ChiTietThoiGianLamViec).get_Range((object)("E" + (iTongDongChiTietThoiGianLamViec2 + iDemNhanVienChiTietThoiGianLamViec2 * 3)), (object)("BN" + (iTongDongChiTietThoiGianLamViec2 + iDemNhanVienChiTietThoiGianLamViec2 * 3))).Cells[1, iCotGioVao2] = sGioVao3;
                                        (ws_ChiTietThoiGianLamViec).get_Range((object)("E" + (iTongDongChiTietThoiGianLamViec2 + iDemNhanVienChiTietThoiGianLamViec2 * 3)), (object)("BN" + (iTongDongChiTietThoiGianLamViec2 + iDemNhanVienChiTietThoiGianLamViec2 * 3))).Cells[1, iCotGioRa2] = sGioRa3;
                                    }
                                    if (iDemLanCham4LanChiTietThoiGianLamViec2 == 1)
                                    {
                                        (ws_ChiTietThoiGianLamViec).get_Range((object)("E" + (iTongDongChiTietThoiGianLamViec2 + iDemNhanVienChiTietThoiGianLamViec2 * 3 + 1)), (object)("BN" + (iTongDongChiTietThoiGianLamViec2 + iDemNhanVienChiTietThoiGianLamViec2 * 3 + 1))).Cells[1, iCotGioVao2] = sGioVao3;
                                        (ws_ChiTietThoiGianLamViec).get_Range((object)("E" + (iTongDongChiTietThoiGianLamViec2 + iDemNhanVienChiTietThoiGianLamViec2 * 3 + 1)), (object)("BN" + (iTongDongChiTietThoiGianLamViec2 + iDemNhanVienChiTietThoiGianLamViec2 * 3 + 1))).Cells[1, iCotGioRa2] = sGioRa3;
                                    }
                                    iDemLanCham4LanChiTietThoiGianLamViec2++;
                                }
                                (ws_ChiTietThoiGianLamViec).get_Range((object)("E" + (iTongDongChiTietThoiGianLamViec2 + iDemNhanVienChiTietThoiGianLamViec2 * 3 + 2)), (object)("BN" + (iTongDongChiTietThoiGianLamViec2 + iDemNhanVienChiTietThoiGianLamViec2 * 3 + 2))).Cells[1, iCotGioVao2] = dGioTungNgayChiTietThoiGianLamViec2;
                                (ws_ChiTietThoiGianLamViec).get_Range((object)("E" + (iTongDongChiTietThoiGianLamViec2 + iDemNhanVienChiTietThoiGianLamViec2 * 3 + 2)), (object)("BN" + (iTongDongChiTietThoiGianLamViec2 + iDemNhanVienChiTietThoiGianLamViec2 * 3 + 2))).Cells[1, iCotGioRa2] = dTongGioTangCaNgayChiTietThoiGianLamViec2;
                                iCotGioVao2 = iCotGioVao2 + 1 + 1;
                                iCotGioRa2 = iCotGioRa2 + 1 + 1;
                                iDemNgayChiTietThoiGianLamViec2++;
                            }
                            double dTongGioChiTietThoiGianLamViec2;
                            dTongGioChiTietThoiGianLamViec2 = 0.0;
                            double dTongCongChiTietThoiGianLamViec2;
                            dTongCongChiTietThoiGianLamViec2 = 0.0;
                            double dTongTangCaChiTietThoiGianLamViec2;
                            dTongTangCaChiTietThoiGianLamViec2 = 0.0;
                            int iTongPhutTreChiTietThoiGianLamViec2;
                            iTongPhutTreChiTietThoiGianLamViec2 = 0;
                            int iTongPhutSomChiTietThoiGianLamViec2;
                            iTongPhutSomChiTietThoiGianLamViec2 = 0;
                            new DataTable();
                            _tinhCongDTO.MaChamCong = iMaChamCongChiTietThoiGianLamViec2;
                            DataTable dtChiTietThoiGianLamViec2;
                            dtChiTietThoiGianLamViec2 = _tinhCongBLL.TinhCongGetByMaChamCong(_tinhCongDTO);
                            for (int iChiTietThoiGianLamViec2 = 0; iChiTietThoiGianLamViec2 < dtChiTietThoiGianLamViec2.Rows.Count; iChiTietThoiGianLamViec2++)
                            {
                                dTongGioChiTietThoiGianLamViec2 += Convert.ToDouble(dtChiTietThoiGianLamViec2.Rows[iChiTietThoiGianLamViec2]["Gio"].ToString());
                                dTongCongChiTietThoiGianLamViec2 += Convert.ToDouble(dtChiTietThoiGianLamViec2.Rows[iChiTietThoiGianLamViec2]["Cong"].ToString());
                                dTongTangCaChiTietThoiGianLamViec2 += Convert.ToDouble(dtChiTietThoiGianLamViec2.Rows[iChiTietThoiGianLamViec2]["TC1"].ToString()) + Convert.ToDouble(dtChiTietThoiGianLamViec2.Rows[iChiTietThoiGianLamViec2]["TC2"].ToString()) + Convert.ToDouble(dtChiTietThoiGianLamViec2.Rows[iChiTietThoiGianLamViec2]["TC3"].ToString()) + Convert.ToDouble(dtChiTietThoiGianLamViec2.Rows[iChiTietThoiGianLamViec2]["TC4"].ToString());
                                iTongPhutTreChiTietThoiGianLamViec2 += Convert.ToInt32(dtChiTietThoiGianLamViec2.Rows[iChiTietThoiGianLamViec2]["Tre"].ToString());
                                iTongPhutSomChiTietThoiGianLamViec2 += Convert.ToInt32(dtChiTietThoiGianLamViec2.Rows[iChiTietThoiGianLamViec2]["VeSom"].ToString());
                            }
                            Excel.Range excelChiTietThoiGianLamViec_TongGioDuLieu2;
                            excelChiTietThoiGianLamViec_TongGioDuLieu2 = (ws_ChiTietThoiGianLamViec).get_Range((object)("BO" + (iTongDongChiTietThoiGianLamViec2 + iDemNhanVienChiTietThoiGianLamViec2 * 3)), (object)("BO" + (iTongDongChiTietThoiGianLamViec2 + iDemNhanVienChiTietThoiGianLamViec2 * 3) + 2));
                            excelChiTietThoiGianLamViec_TongGioDuLieu2.Cells[1, 1] = dTongGioChiTietThoiGianLamViec2;
                            excelChiTietThoiGianLamViec_TongGioDuLieu2.get_Range((object)"A1", (object)"A3").MergeCells = true;
                            Excel.Range excelChiTietThoiGianLamViec_TongCongDuLieu2;
                            excelChiTietThoiGianLamViec_TongCongDuLieu2 = (ws_ChiTietThoiGianLamViec).get_Range((object)("BP" + (iTongDongChiTietThoiGianLamViec2 + iDemNhanVienChiTietThoiGianLamViec2 * 3)), (object)("BP" + (iTongDongChiTietThoiGianLamViec2 + iDemNhanVienChiTietThoiGianLamViec2 * 3) + 2));
                            excelChiTietThoiGianLamViec_TongCongDuLieu2.Cells[1, 1] = dTongCongChiTietThoiGianLamViec2;
                            excelChiTietThoiGianLamViec_TongCongDuLieu2.get_Range((object)"A1", (object)"A3").MergeCells = true;
                            Excel.Range excelChiTietThoiGianLamViec_TongTangCaDuLieu2;
                            excelChiTietThoiGianLamViec_TongTangCaDuLieu2 = (ws_ChiTietThoiGianLamViec).get_Range((object)("BQ" + (iTongDongChiTietThoiGianLamViec2 + iDemNhanVienChiTietThoiGianLamViec2 * 3)), (object)("BQ" + (iTongDongChiTietThoiGianLamViec2 + iDemNhanVienChiTietThoiGianLamViec2 * 3) + 2));
                            excelChiTietThoiGianLamViec_TongTangCaDuLieu2.Cells[1, 1] = dTongTangCaChiTietThoiGianLamViec2;
                            excelChiTietThoiGianLamViec_TongTangCaDuLieu2.get_Range((object)"A1", (object)"A3").MergeCells = true;
                            Excel.Range excelChiTietThoiGianLamViec_TongPhutTreDuLieu2;
                            excelChiTietThoiGianLamViec_TongPhutTreDuLieu2 = (ws_ChiTietThoiGianLamViec).get_Range((object)("BR" + (iTongDongChiTietThoiGianLamViec2 + iDemNhanVienChiTietThoiGianLamViec2 * 3)), (object)("BR" + (iTongDongChiTietThoiGianLamViec2 + iDemNhanVienChiTietThoiGianLamViec2 * 3) + 2));
                            excelChiTietThoiGianLamViec_TongPhutTreDuLieu2.Cells[1, 1] = iTongPhutTreChiTietThoiGianLamViec2;
                            excelChiTietThoiGianLamViec_TongPhutTreDuLieu2.get_Range((object)"A1", (object)"A3").MergeCells = true;
                            Excel.Range excelChiTietThoiGianLamViec_TongPhutSomDuLieu2;
                            excelChiTietThoiGianLamViec_TongPhutSomDuLieu2 = (ws_ChiTietThoiGianLamViec).get_Range((object)("BS" + (iTongDongChiTietThoiGianLamViec2 + iDemNhanVienChiTietThoiGianLamViec2 * 3)), (object)("BS" + (iTongDongChiTietThoiGianLamViec2 + iDemNhanVienChiTietThoiGianLamViec2 * 3) + 2));
                            excelChiTietThoiGianLamViec_TongPhutSomDuLieu2.Cells[1, 1] = iTongPhutSomChiTietThoiGianLamViec2;
                            excelChiTietThoiGianLamViec_TongPhutSomDuLieu2.get_Range((object)"A1", (object)"A3").MergeCells = true;
                            iDemNhanVienChiTietThoiGianLamViec2++;
                        }
                        ws_ChiTietThoiGianLamViec.PageSetup.Orientation = Excel.XlPageOrientation.xlLandscape;
                        ws_ChiTietThoiGianLamViec.PageSetup.PaperSize = Excel.XlPaperSize.xlPaperA4;
                        ws_ChiTietThoiGianLamViec.PageSetup.LeftMargin = 13.0;
                        ws_ChiTietThoiGianLamViec.PageSetup.RightMargin = 0.0;
                        ws_ChiTietThoiGianLamViec.PageSetup.BottomMargin = 0.0;
                        ws_ChiTietThoiGianLamViec.PageSetup.TopMargin = 0.0;
                        ws_ChiTietThoiGianLamViec.PageSetup.Zoom = 46;
                        Excel.Range excelChiTietThoiGianLamViec_DinhDangDuLieu2;
                        excelChiTietThoiGianLamViec_DinhDangDuLieu2 = (ws_ChiTietThoiGianLamViec).get_Range((object)"A9", (object)("BS" + (iTongDongChiTietThoiGianLamViec2 + iDemNhanVienChiTietThoiGianLamViec2 * 3 - 1)));
                        excelChiTietThoiGianLamViec_DinhDangDuLieu2.Font.Name = "Times New Roman";
                        excelChiTietThoiGianLamViec_DinhDangDuLieu2.Font.Size = "8";
                        excelChiTietThoiGianLamViec_DinhDangDuLieu2.HorizontalAlignment = Excel.Constants.xlCenter;
                        excelChiTietThoiGianLamViec_DinhDangDuLieu2.Borders.LineStyle = Excel.Constants.xlBoth;
                    }
                    if (iChonLanXuat == 3)
                    {
                        int iDemNhanVienChiTietThoiGianLamViec;
                        iDemNhanVienChiTietThoiGianLamViec = 0;
                        int iDemSTTChiTietThoiGianLamViec;
                        iDemSTTChiTietThoiGianLamViec = 0;
                        int iTongDongChiTietThoiGianLamViec;
                        iTongDongChiTietThoiGianLamViec = 9;
                        new DataTable();
                        _tinhCongDTO.Ngay = dTuNgayChiTietThoiGianLamViec;
                        int iMaChamCongChiTietThoiGianLamViec;
                        iMaChamCongChiTietThoiGianLamViec = 0;
                        DataTable dtNhanVienChiTietThoiGianLamViec;
                        dtNhanVienChiTietThoiGianLamViec = _tinhCongBLL.TinhCongGetNgay(_tinhCongDTO);
                        for (int iNhanVienChiTietThoiGianLamViec = 0; iNhanVienChiTietThoiGianLamViec < dtNhanVienChiTietThoiGianLamViec.Rows.Count; iNhanVienChiTietThoiGianLamViec++)
                        {
                            if (Convert.ToInt32(dtNhanVienChiTietThoiGianLamViec.Rows[iNhanVienChiTietThoiGianLamViec]["MaChamCong"].ToString()) == iMaChamCongChiTietThoiGianLamViec)
                            {
                                continue;
                            }
                            iDemSTTChiTietThoiGianLamViec++;
                            iMaChamCongChiTietThoiGianLamViec = Convert.ToInt32(dtNhanVienChiTietThoiGianLamViec.Rows[iNhanVienChiTietThoiGianLamViec]["MaChamCong"].ToString());
                            string sMaNhanVienChiTietThoiGianLamViec;
                            sMaNhanVienChiTietThoiGianLamViec = dtNhanVienChiTietThoiGianLamViec.Rows[iNhanVienChiTietThoiGianLamViec]["MaNhanVien"].ToString();
                            string sTenNhanVienChiTietThoiGianLamViec;
                            sTenNhanVienChiTietThoiGianLamViec = dtNhanVienChiTietThoiGianLamViec.Rows[iNhanVienChiTietThoiGianLamViec]["TenNhanVien"].ToString();
                            Excel.Range excelChiTietThoiGianLamViec_STTDuLieu;
                            excelChiTietThoiGianLamViec_STTDuLieu = (ws_ChiTietThoiGianLamViec).get_Range((object)("A" + (iTongDongChiTietThoiGianLamViec + iDemNhanVienChiTietThoiGianLamViec * 4)), (object)("A" + (iTongDongChiTietThoiGianLamViec + iDemNhanVienChiTietThoiGianLamViec * 4)));
                            excelChiTietThoiGianLamViec_STTDuLieu.Cells[1, 1] = iDemSTTChiTietThoiGianLamViec.ToString();
                            excelChiTietThoiGianLamViec_STTDuLieu.get_Range((object)"A1", (object)"A4").MergeCells = true;
                            excelChiTietThoiGianLamViec_STTDuLieu.Select();
                            Excel.Range excelChiTietThoiGianLamViec_MaNhanVienDuLieu;
                            excelChiTietThoiGianLamViec_MaNhanVienDuLieu = (ws_ChiTietThoiGianLamViec).get_Range((object)("B" + (iTongDongChiTietThoiGianLamViec + iDemNhanVienChiTietThoiGianLamViec * 4)), (object)("B" + (iTongDongChiTietThoiGianLamViec + iDemNhanVienChiTietThoiGianLamViec * 4)));
                            excelChiTietThoiGianLamViec_MaNhanVienDuLieu.get_Range((object)"A1", (object)"A1").NumberFormat = "@";
                            excelChiTietThoiGianLamViec_MaNhanVienDuLieu.Cells[1, 1] = "'" + sMaNhanVienChiTietThoiGianLamViec;
                            excelChiTietThoiGianLamViec_MaNhanVienDuLieu.get_Range((object)"A1", (object)"A4").MergeCells = true;
                            Excel.Range excelChiTietThoiGianLamViec_TenNhanVienDuLieu;
                            excelChiTietThoiGianLamViec_TenNhanVienDuLieu = (ws_ChiTietThoiGianLamViec).get_Range((object)("C" + (iTongDongChiTietThoiGianLamViec + iDemNhanVienChiTietThoiGianLamViec * 4)), (object)("C" + (iTongDongChiTietThoiGianLamViec + iDemNhanVienChiTietThoiGianLamViec * 4)));
                            excelChiTietThoiGianLamViec_TenNhanVienDuLieu.Cells[1, 1] = sTenNhanVienChiTietThoiGianLamViec;
                            excelChiTietThoiGianLamViec_TenNhanVienDuLieu.get_Range((object)"A1", (object)"A4").MergeCells = true;
                            string sTenPhongBan;
                            sTenPhongBan = "";
                            new DataTable();
                            _phongBanDTO.MaPhongBan = dtNhanVienChiTietThoiGianLamViec.Rows[iNhanVienChiTietThoiGianLamViec]["PhongBan"].ToString();
                            DataTable dtPhongBan;
                            dtPhongBan = _phongBanBLL.getTenPhongBanByMaPhongBan(_phongBanDTO);
                            for (int iPhongBan = 0; iPhongBan < dtPhongBan.Rows.Count; iPhongBan++)
                            {
                                sTenPhongBan = dtPhongBan.Rows[iPhongBan]["TenPhongBan"].ToString();
                            }
                            Excel.Range excelChiTietThoiGianLamViec_PhongBanDuLieu;
                            excelChiTietThoiGianLamViec_PhongBanDuLieu = (ws_ChiTietThoiGianLamViec).get_Range((object)("D" + (iTongDongChiTietThoiGianLamViec + iDemNhanVienChiTietThoiGianLamViec * 4)), (object)("D" + (iTongDongChiTietThoiGianLamViec + iDemNhanVienChiTietThoiGianLamViec * 4)));
                            excelChiTietThoiGianLamViec_PhongBanDuLieu.get_Range((object)"A1", (object)"A4").MergeCells = true;
                            if (sTenPhongBan == "")
                            {
                                excelChiTietThoiGianLamViec_PhongBanDuLieu.Cells[1, 1] = "------";
                            }
                            else
                            {
                                excelChiTietThoiGianLamViec_PhongBanDuLieu.Cells[1, 1] = sTenPhongBan;
                            }
                            int iDemNgayChiTietThoiGianLamViec;
                            iDemNgayChiTietThoiGianLamViec = 0;
                            int iCotGioVao;
                            iCotGioVao = 1;
                            int iCotGioRa;
                            iCotGioRa = 2;
                            for (int iGioChamChiTietThoiGianLamViec = 0; iGioChamChiTietThoiGianLamViec < 31; iGioChamChiTietThoiGianLamViec++)
                            {
                                int iDemLanCham4LanChiTietThoiGianLamViec;
                                iDemLanCham4LanChiTietThoiGianLamViec = 0;
                                double dGioTungNgayChiTietThoiGianLamViec;
                                dGioTungNgayChiTietThoiGianLamViec = 0.0;
                                double dTongGioTangCaNgayChiTietThoiGianLamViec;
                                dTongGioTangCaNgayChiTietThoiGianLamViec = 0.0;
                                DateTime dNgayChiTietThoiGianLamViec;
                                dNgayChiTietThoiGianLamViec = Convert.ToDateTime(dNgayBatDauTinhCong.AddDays(iDemNgayChiTietThoiGianLamViec).ToString());
                                new DataTable();
                                _tinhCongDTO.MaChamCong = iMaChamCongChiTietThoiGianLamViec;
                                _tinhCongDTO.Ngay = dNgayChiTietThoiGianLamViec;
                                DataTable dtDuLieuGioChiTietThoiGianLamViec;
                                dtDuLieuGioChiTietThoiGianLamViec = _tinhCongBLL.TinhCongGetMaChamCongAndNgayChiTietThoiGian(_tinhCongDTO);
                                for (int iDuLieuGioChiTietThoiGianLamViec = 0; iDuLieuGioChiTietThoiGianLamViec < dtDuLieuGioChiTietThoiGianLamViec.Rows.Count; iDuLieuGioChiTietThoiGianLamViec++)
                                {
                                    if (iDemLanCham4LanChiTietThoiGianLamViec == 3)
                                    {
                                        break;
                                    }
                                    string sGioVao4;
                                    sGioVao4 = "";
                                    string sGioRa4;
                                    sGioRa4 = "";
                                    string sGioVaoChiTietThoiGianLamViec;
                                    sGioVaoChiTietThoiGianLamViec = dtDuLieuGioChiTietThoiGianLamViec.Rows[iDuLieuGioChiTietThoiGianLamViec]["GioVao"].ToString();
                                    string sGioRaChiTietThoiGianLamViec;
                                    sGioRaChiTietThoiGianLamViec = dtDuLieuGioChiTietThoiGianLamViec.Rows[iDuLieuGioChiTietThoiGianLamViec]["GioRa"].ToString();
                                    dGioTungNgayChiTietThoiGianLamViec += Convert.ToDouble(dtDuLieuGioChiTietThoiGianLamViec.Rows[iDuLieuGioChiTietThoiGianLamViec]["Gio"].ToString());
                                    dTongGioTangCaNgayChiTietThoiGianLamViec += Convert.ToDouble(dtDuLieuGioChiTietThoiGianLamViec.Rows[iDuLieuGioChiTietThoiGianLamViec]["TC1"]) + Convert.ToDouble(dtDuLieuGioChiTietThoiGianLamViec.Rows[iDuLieuGioChiTietThoiGianLamViec]["TC2"]);
                                    if (sGioVaoChiTietThoiGianLamViec != "")
                                    {
                                        DateTime dGioVao;
                                        dGioVao = Convert.ToDateTime(sGioVaoChiTietThoiGianLamViec);
                                        sGioVao4 = dGioVao.Hour + ":" + dGioVao.Minute;
                                    }
                                    if (sGioRaChiTietThoiGianLamViec != "")
                                    {
                                        DateTime dGioRa;
                                        dGioRa = Convert.ToDateTime(sGioRaChiTietThoiGianLamViec);
                                        sGioRa4 = dGioRa.Hour + ":" + dGioRa.Minute;
                                    }
                                    if (iDemLanCham4LanChiTietThoiGianLamViec == 0)
                                    {
                                        (ws_ChiTietThoiGianLamViec).get_Range((object)("E" + (iTongDongChiTietThoiGianLamViec + iDemNhanVienChiTietThoiGianLamViec * 4)), (object)("BN" + (iTongDongChiTietThoiGianLamViec + iDemNhanVienChiTietThoiGianLamViec * 4))).Cells[1, iCotGioVao] = sGioVao4;
                                        (ws_ChiTietThoiGianLamViec).get_Range((object)("E" + (iTongDongChiTietThoiGianLamViec + iDemNhanVienChiTietThoiGianLamViec * 4)), (object)("BN" + (iTongDongChiTietThoiGianLamViec + iDemNhanVienChiTietThoiGianLamViec * 4))).Cells[1, iCotGioRa] = sGioRa4;
                                    }
                                    if (iDemLanCham4LanChiTietThoiGianLamViec == 1)
                                    {
                                        (ws_ChiTietThoiGianLamViec).get_Range((object)("E" + (iTongDongChiTietThoiGianLamViec + iDemNhanVienChiTietThoiGianLamViec * 4 + 1)), (object)("BN" + (iTongDongChiTietThoiGianLamViec + iDemNhanVienChiTietThoiGianLamViec * 4 + 1))).Cells[1, iCotGioVao] = sGioVao4;
                                        (ws_ChiTietThoiGianLamViec).get_Range((object)("E" + (iTongDongChiTietThoiGianLamViec + iDemNhanVienChiTietThoiGianLamViec * 4 + 1)), (object)("BN" + (iTongDongChiTietThoiGianLamViec + iDemNhanVienChiTietThoiGianLamViec * 4 + 1))).Cells[1, iCotGioRa] = sGioRa4;
                                        sGioRa4 = "";
                                    }
                                    if (iDemLanCham4LanChiTietThoiGianLamViec == 2)
                                    {
                                        (ws_ChiTietThoiGianLamViec).get_Range((object)("E" + (iTongDongChiTietThoiGianLamViec + iDemNhanVienChiTietThoiGianLamViec * 4 + 2)), (object)("BN" + (iTongDongChiTietThoiGianLamViec + iDemNhanVienChiTietThoiGianLamViec * 4 + 2))).Cells[1, iCotGioVao] = sGioVao4;
                                        (ws_ChiTietThoiGianLamViec).get_Range((object)("E" + (iTongDongChiTietThoiGianLamViec + iDemNhanVienChiTietThoiGianLamViec * 4 + 2)), (object)("BN" + (iTongDongChiTietThoiGianLamViec + iDemNhanVienChiTietThoiGianLamViec * 4 + 2))).Cells[1, iCotGioRa] = sGioRa4;
                                    }
                                    iDemLanCham4LanChiTietThoiGianLamViec++;
                                }
                                (ws_ChiTietThoiGianLamViec).get_Range((object)("E" + (iTongDongChiTietThoiGianLamViec + iDemNhanVienChiTietThoiGianLamViec * 4 + 3)), (object)("BN" + (iTongDongChiTietThoiGianLamViec + iDemNhanVienChiTietThoiGianLamViec * 4 + 3))).Cells[1, iCotGioVao] = dGioTungNgayChiTietThoiGianLamViec;
                                (ws_ChiTietThoiGianLamViec).get_Range((object)("E" + (iTongDongChiTietThoiGianLamViec + iDemNhanVienChiTietThoiGianLamViec * 4 + 3)), (object)("BN" + (iTongDongChiTietThoiGianLamViec + iDemNhanVienChiTietThoiGianLamViec * 4 + 3))).Cells[1, iCotGioRa] = dTongGioTangCaNgayChiTietThoiGianLamViec;
                                iCotGioVao = iCotGioVao + 1 + 1;
                                iCotGioRa = iCotGioRa + 1 + 1;
                                iDemNgayChiTietThoiGianLamViec++;
                            }
                            double dTongGioChiTietThoiGianLamViec;
                            dTongGioChiTietThoiGianLamViec = 0.0;
                            double dTongCongChiTietThoiGianLamViec;
                            dTongCongChiTietThoiGianLamViec = 0.0;
                            double dTongTangCaChiTietThoiGianLamViec;
                            dTongTangCaChiTietThoiGianLamViec = 0.0;
                            int iTongPhutTreChiTietThoiGianLamViec;
                            iTongPhutTreChiTietThoiGianLamViec = 0;
                            int iTongPhutSomChiTietThoiGianLamViec;
                            iTongPhutSomChiTietThoiGianLamViec = 0;
                            new DataTable();
                            _tinhCongDTO.MaChamCong = iMaChamCongChiTietThoiGianLamViec;
                            DataTable dtChiTietThoiGianLamViec;
                            dtChiTietThoiGianLamViec = _tinhCongBLL.TinhCongGetByMaChamCong(_tinhCongDTO);
                            for (int iChiTietThoiGianLamViec = 0; iChiTietThoiGianLamViec < dtChiTietThoiGianLamViec.Rows.Count; iChiTietThoiGianLamViec++)
                            {
                                dTongGioChiTietThoiGianLamViec += Convert.ToDouble(dtChiTietThoiGianLamViec.Rows[iChiTietThoiGianLamViec]["Gio"].ToString());
                                dTongCongChiTietThoiGianLamViec += Convert.ToDouble(dtChiTietThoiGianLamViec.Rows[iChiTietThoiGianLamViec]["Cong"].ToString());
                                dTongTangCaChiTietThoiGianLamViec += Convert.ToDouble(dtChiTietThoiGianLamViec.Rows[iChiTietThoiGianLamViec]["TC1"].ToString()) + Convert.ToDouble(dtChiTietThoiGianLamViec.Rows[iChiTietThoiGianLamViec]["TC2"].ToString()) + Convert.ToDouble(dtChiTietThoiGianLamViec.Rows[iChiTietThoiGianLamViec]["TC3"].ToString()) + Convert.ToDouble(dtChiTietThoiGianLamViec.Rows[iChiTietThoiGianLamViec]["TC4"].ToString());
                                iTongPhutTreChiTietThoiGianLamViec += Convert.ToInt32(dtChiTietThoiGianLamViec.Rows[iChiTietThoiGianLamViec]["Tre"].ToString());
                                iTongPhutSomChiTietThoiGianLamViec += Convert.ToInt32(dtChiTietThoiGianLamViec.Rows[iChiTietThoiGianLamViec]["VeSom"].ToString());
                            }
                            Excel.Range excelChiTietThoiGianLamViec_TongGioDuLieu;
                            excelChiTietThoiGianLamViec_TongGioDuLieu = (ws_ChiTietThoiGianLamViec).get_Range((object)("BO" + (iTongDongChiTietThoiGianLamViec + iDemNhanVienChiTietThoiGianLamViec * 4)), (object)("BO" + (iTongDongChiTietThoiGianLamViec + iDemNhanVienChiTietThoiGianLamViec * 4) + 3));
                            excelChiTietThoiGianLamViec_TongGioDuLieu.Cells[1, 1] = dTongGioChiTietThoiGianLamViec;
                            excelChiTietThoiGianLamViec_TongGioDuLieu.get_Range((object)"A1", (object)"A4").MergeCells = true;
                            Excel.Range excelChiTietThoiGianLamViec_TongCongDuLieu;
                            excelChiTietThoiGianLamViec_TongCongDuLieu = (ws_ChiTietThoiGianLamViec).get_Range((object)("BP" + (iTongDongChiTietThoiGianLamViec + iDemNhanVienChiTietThoiGianLamViec * 4)), (object)("BP" + (iTongDongChiTietThoiGianLamViec + iDemNhanVienChiTietThoiGianLamViec * 4) + 3));
                            excelChiTietThoiGianLamViec_TongCongDuLieu.Cells[1, 1] = dTongCongChiTietThoiGianLamViec;
                            excelChiTietThoiGianLamViec_TongCongDuLieu.get_Range((object)"A1", (object)"A4").MergeCells = true;
                            Excel.Range excelChiTietThoiGianLamViec_TongTangCaDuLieu;
                            excelChiTietThoiGianLamViec_TongTangCaDuLieu = (ws_ChiTietThoiGianLamViec).get_Range((object)("BQ" + (iTongDongChiTietThoiGianLamViec + iDemNhanVienChiTietThoiGianLamViec * 4)), (object)("BQ" + (iTongDongChiTietThoiGianLamViec + iDemNhanVienChiTietThoiGianLamViec * 4) + 3));
                            excelChiTietThoiGianLamViec_TongTangCaDuLieu.Cells[1, 1] = dTongTangCaChiTietThoiGianLamViec;
                            excelChiTietThoiGianLamViec_TongTangCaDuLieu.get_Range((object)"A1", (object)"A4").MergeCells = true;
                            Excel.Range excelChiTietThoiGianLamViec_TongPhutTreDuLieu;
                            excelChiTietThoiGianLamViec_TongPhutTreDuLieu = (ws_ChiTietThoiGianLamViec).get_Range((object)("BR" + (iTongDongChiTietThoiGianLamViec + iDemNhanVienChiTietThoiGianLamViec * 4)), (object)("BR" + (iTongDongChiTietThoiGianLamViec + iDemNhanVienChiTietThoiGianLamViec * 4) + 3));
                            excelChiTietThoiGianLamViec_TongPhutTreDuLieu.Cells[1, 1] = iTongPhutTreChiTietThoiGianLamViec;
                            excelChiTietThoiGianLamViec_TongPhutTreDuLieu.get_Range((object)"A1", (object)"A4").MergeCells = true;
                            Excel.Range excelChiTietThoiGianLamViec_TongPhutSomDuLieu;
                            excelChiTietThoiGianLamViec_TongPhutSomDuLieu = (ws_ChiTietThoiGianLamViec).get_Range((object)("BS" + (iTongDongChiTietThoiGianLamViec + iDemNhanVienChiTietThoiGianLamViec * 4)), (object)("BS" + (iTongDongChiTietThoiGianLamViec + iDemNhanVienChiTietThoiGianLamViec * 4) + 3));
                            excelChiTietThoiGianLamViec_TongPhutSomDuLieu.Cells[1, 1] = iTongPhutSomChiTietThoiGianLamViec;
                            excelChiTietThoiGianLamViec_TongPhutSomDuLieu.get_Range((object)"A1", (object)"A4").MergeCells = true;
                            iDemNhanVienChiTietThoiGianLamViec++;
                        }
                        Excel.Range excelChiTietThoiGianLamViec_DinhDangDuLieu;
                        excelChiTietThoiGianLamViec_DinhDangDuLieu = (ws_ChiTietThoiGianLamViec).get_Range((object)"A9", (object)("BS" + (iTongDongChiTietThoiGianLamViec + iDemNhanVienChiTietThoiGianLamViec * 4 - 1)));
                        excelChiTietThoiGianLamViec_DinhDangDuLieu.Font.Name = "Times New Roman";
                        excelChiTietThoiGianLamViec_DinhDangDuLieu.Font.Size = "8";
                        excelChiTietThoiGianLamViec_DinhDangDuLieu.HorizontalAlignment = Excel.Constants.xlCenter;
                        excelChiTietThoiGianLamViec_DinhDangDuLieu.Borders.LineStyle = Excel.Constants.xlBoth;
                    }
                    failed = false;
                }
                catch (COMException)
                {
                    failed = true;
                }
                Thread.Sleep(10);
            }
            while (failed);
        }

        private void XuatLuoi_Click(object sender, EventArgs e)
        {
            testProcess = iDemNhanVienDuocChon;
            demProcess = -1;
            _ = Thread.CurrentThread.CurrentCulture;
            Thread.CurrentThread.CurrentCulture = new CultureInfo("en-US");
            Excel.Application xla_XuatLuoi;
            xla_XuatLuoi = new Excel.Application();
            xla_XuatLuoi.Workbooks.Add(Excel.XlSheetType.xlWorksheet);
            _ = xla_XuatLuoi.ActiveSheet;
            Excel.Worksheet ws_XuatLuoi;
            ws_XuatLuoi = xla_XuatLuoi.Worksheets.get_Item((object)1);
            Excel.Range excelTieuDeXuatLuoi;
            excelTieuDeXuatLuoi = (ws_XuatLuoi).get_Range((object)"A2", (object)"O2");
            excelTieuDeXuatLuoi.Select();
            excelTieuDeXuatLuoi.Cells[1, 1] = "CHI TIẾT CHẤM CÔNG";
            excelTieuDeXuatLuoi.get_Range((object)"A1", (object)"O1").Merge(true);
            excelTieuDeXuatLuoi.Font.Name = "Times New Roman";
            excelTieuDeXuatLuoi.Font.Size = "18";
            excelTieuDeXuatLuoi.Font.Bold = true;
            excelTieuDeXuatLuoi.RowHeight = "24";
            excelTieuDeXuatLuoi.Interior.Color = ColorTranslator.ToOle(Color.BlanchedAlmond);
            excelTieuDeXuatLuoi.HorizontalAlignment = Excel.Constants.xlCenter;
            (ws_XuatLuoi).get_Range((object)"A3", (object)"A3").Cells[1, 1] = "STT";
            Excel.Range excelMaNhanVienHeader;
            excelMaNhanVienHeader = (ws_XuatLuoi).get_Range((object)"B3", (object)"B3");
            excelMaNhanVienHeader.Cells[1, 1] = "Mã nhân viên";
            excelMaNhanVienHeader.ColumnWidth = 12;
            Excel.Range excelTenNhanVienHeader;
            excelTenNhanVienHeader = (ws_XuatLuoi).get_Range((object)"C3", (object)"C3");
            excelTenNhanVienHeader.Cells[1, 1] = "Tên nhân viên";
            excelTenNhanVienHeader.ColumnWidth = 12;
            (ws_XuatLuoi).get_Range((object)"D3", (object)"D3").Cells[1, 1] = "Phòng ban";
            (ws_XuatLuoi).get_Range((object)"E3", (object)"E3").Cells[1, 1] = "Ngày";
            (ws_XuatLuoi).get_Range((object)"F3", (object)"F3").Cells[1, 1] = "Thứ";
            (ws_XuatLuoi).get_Range((object)"G3", (object)"G3").Cells[1, 1] = "Giờ vào";
            (ws_XuatLuoi).get_Range((object)"H3", (object)"H3").Cells[1, 1] = "Giờ ra";
            (ws_XuatLuoi).get_Range((object)"I3", (object)"I3").Cells[1, 1] = "Trễ";
            (ws_XuatLuoi).get_Range((object)"J3", (object)"J3").Cells[1, 1] = "Sớm";
            (ws_XuatLuoi).get_Range((object)"K3", (object)"K3").Cells[1, 1] = "Công";
            (ws_XuatLuoi).get_Range((object)"L3", (object)"L3").Cells[1, 1] = "Tổng giờ";
            (ws_XuatLuoi).get_Range((object)"M3", (object)"M3").Cells[1, 1] = "Tăng ca";
            Excel.Range excelTongToanBoHeader;
            excelTongToanBoHeader = (ws_XuatLuoi).get_Range((object)"N3", (object)"N3");
            excelTongToanBoHeader.Cells[1, 1] = "Tổng toàn bộ";
            excelTongToanBoHeader.ColumnWidth = 5;
            (ws_XuatLuoi).get_Range((object)"O3", (object)"O3").Cells[1, 1] = "Ca";
            Excel.Range excelDinhDangCaHeader;
            excelDinhDangCaHeader = (ws_XuatLuoi).get_Range((object)"A3", (object)"O3");
            excelDinhDangCaHeader.Font.Name = "Times New Roman";
            excelDinhDangCaHeader.Interior.Color = ColorTranslator.ToOle(Color.BlanchedAlmond);
            excelDinhDangCaHeader.Font.Size = "11";
            excelDinhDangCaHeader.Font.Bold = true;
            excelDinhDangCaHeader.RowHeight = "24";
            excelDinhDangCaHeader.HorizontalAlignment = Excel.Constants.xlCenter;
            xla_XuatLuoi.Visible = true;
            int iDemDong;
            iDemDong = 3;
            int iSTT;
            iSTT = 0;
            new DataTable();
            DataTable dtXuatLuoi;
            dtXuatLuoi = _tinhCongBLL.TinhCongGetAll(_tinhCongDTO);
            for (int iXuatLuoi = 0; iXuatLuoi < dtXuatLuoi.Rows.Count; iXuatLuoi++)
            {
                iDemDong++;
                iSTT++;
                Excel.Range excelSTTDuLieu;
                excelSTTDuLieu = (ws_XuatLuoi).get_Range((object)("A" + iDemDong), (object)("A" + iDemDong));
                excelSTTDuLieu.Cells[1, 1] = iSTT;
                excelSTTDuLieu.Select();
                Excel.Range excelMaNhanVienDuLieu;
                excelMaNhanVienDuLieu = (ws_XuatLuoi).get_Range((object)("B" + iDemDong), (object)("B" + iDemDong));
                excelMaNhanVienDuLieu.get_Range((object)"A1", (object)"A1").NumberFormat = "@";
                excelMaNhanVienDuLieu.Cells[1, 1] = dtXuatLuoi.Rows[iXuatLuoi]["MaNhanVien"].ToString();
                (ws_XuatLuoi).get_Range((object)("C" + iDemDong), (object)("C" + iDemDong)).Cells[1, 1] = dtXuatLuoi.Rows[iXuatLuoi]["TenNhanVien"].ToString();
                string sTenPhongBanXuatLuoi;
                sTenPhongBanXuatLuoi = "";
                int iDemPhongBanXuatLuoi;
                iDemPhongBanXuatLuoi = 0;
                new DataTable();
                _phongBanDTO.MaPhongBan = dtXuatLuoi.Rows[iXuatLuoi]["PhongBan"].ToString();
                DataTable dtPhongBanXuatLuoi;
                dtPhongBanXuatLuoi = _phongBanBLL.getTenPhongBanByMaPhongBan(_phongBanDTO);
                for (int iPhongBanXuatLuoi = 0; iPhongBanXuatLuoi < dtPhongBanXuatLuoi.Rows.Count; iPhongBanXuatLuoi++)
                {
                    sTenPhongBanXuatLuoi = dtPhongBanXuatLuoi.Rows[iPhongBanXuatLuoi]["TenPhongBan"].ToString();
                    iDemPhongBanXuatLuoi = 1;
                }
                Excel.Range excelPhongBanDuLieu;
                excelPhongBanDuLieu = (ws_XuatLuoi).get_Range((object)("D" + iDemDong), (object)("D" + iDemDong));
                if (iDemPhongBanXuatLuoi == 1)
                {
                    excelPhongBanDuLieu.Cells[1, 1] = sTenPhongBanXuatLuoi;
                }
                else
                {
                    excelPhongBanDuLieu.Cells[1, 1] = "";
                }
                DateTime dNgayXuatLuoi;
                dNgayXuatLuoi = Convert.ToDateTime(dtXuatLuoi.Rows[iXuatLuoi]["Ngay"].ToString());
                (ws_XuatLuoi).get_Range((object)("E" + iDemDong), (object)("E" + iDemDong)).Cells[1, 1] = dNgayXuatLuoi;
                (ws_XuatLuoi).get_Range((object)("F" + iDemDong), (object)("F" + iDemDong)).Cells[1, 1] = dtXuatLuoi.Rows[iXuatLuoi]["Thu"].ToString();
                string sGioVaoXuatLuoi;
                sGioVaoXuatLuoi = dtXuatLuoi.Rows[iXuatLuoi]["GioVao"].ToString();
                Excel.Range excelGioVaoDuLieu;
                excelGioVaoDuLieu = (ws_XuatLuoi).get_Range((object)("G" + iDemDong), (object)("G" + iDemDong));
                if (sGioVaoXuatLuoi == "")
                {
                    excelGioVaoDuLieu.Cells[1, 1] = "";
                }
                else
                {
                    DateTime dGioVao;
                    dGioVao = Convert.ToDateTime(sGioVaoXuatLuoi);
                    string sGioVao;
                    sGioVao = dGioVao.Hour + ":" + dGioVao.Minute;
                    excelGioVaoDuLieu.Cells[1, 1] = sGioVao;
                }
                string sGioRaXuatLuoi;
                sGioRaXuatLuoi = dtXuatLuoi.Rows[iXuatLuoi]["GioRa"].ToString();
                Excel.Range excelGioRaDuLieu;
                excelGioRaDuLieu = (ws_XuatLuoi).get_Range((object)("H" + iDemDong), (object)("H" + iDemDong));
                if (sGioRaXuatLuoi == "")
                {
                    excelGioRaDuLieu.Cells[1, 1] = "";
                }
                else
                {
                    DateTime dGioRa;
                    dGioRa = Convert.ToDateTime(sGioRaXuatLuoi);
                    string sGioRa;
                    sGioRa = dGioRa.Hour + ":" + dGioRa.Minute;
                    excelGioRaDuLieu.Cells[1, 1] = sGioRa;
                }
                int iDiTre;
                iDiTre = Convert.ToInt32(dtXuatLuoi.Rows[iXuatLuoi]["Tre"].ToString());
                (ws_XuatLuoi).get_Range((object)("I" + iDemDong), (object)("I" + iDemDong)).Cells[1, 1] = iDiTre;
                int iVeSom;
                iVeSom = Convert.ToInt32(dtXuatLuoi.Rows[iXuatLuoi]["VeSom"].ToString());
                (ws_XuatLuoi).get_Range((object)("J" + iDemDong), (object)("J" + iDemDong)).Cells[1, 1] = iVeSom;
                double dCong;
                dCong = Convert.ToDouble(dtXuatLuoi.Rows[iXuatLuoi]["Cong"].ToString());
                (ws_XuatLuoi).get_Range((object)("K" + iDemDong), (object)("K" + iDemDong)).Cells[1, 1] = dCong;
                double dGio;
                dGio = Convert.ToDouble(dtXuatLuoi.Rows[iXuatLuoi]["Gio"].ToString());
                (ws_XuatLuoi).get_Range((object)("L" + iDemDong), (object)("L" + iDemDong)).Cells[1, 1] = dGio;
                (ws_XuatLuoi).get_Range((object)("M" + iDemDong), (object)("M" + iDemDong)).Cells[1, 1] = Convert.ToDouble(dtXuatLuoi.Rows[iXuatLuoi]["TC1"].ToString()) + Convert.ToDouble(dtXuatLuoi.Rows[iXuatLuoi]["TC2"].ToString()) + Convert.ToDouble(dtXuatLuoi.Rows[iXuatLuoi]["TC3"].ToString()) + Convert.ToDouble(dtXuatLuoi.Rows[iXuatLuoi]["TC4"].ToString());
                double dTongGio;
                dTongGio = Convert.ToDouble(dtXuatLuoi.Rows[iXuatLuoi]["TongGio"].ToString());
                (ws_XuatLuoi).get_Range((object)("N" + iDemDong), (object)("N" + iDemDong)).Cells[1, 1] = dTongGio;
                string sCaXuatLuoi;
                sCaXuatLuoi = dtXuatLuoi.Rows[iXuatLuoi]["Ca"].ToString();
                Excel.Range excelCaDuLieu;
                excelCaDuLieu = (ws_XuatLuoi).get_Range((object)("O" + iDemDong), (object)("O" + iDemDong));
                if (sCaXuatLuoi == "***")
                {
                    excelCaDuLieu.Cells[1, 1] = dtXuatLuoi.Rows[iXuatLuoi]["KyHieu"].ToString();
                }
                else
                {
                    excelCaDuLieu.Cells[1, 1] = sCaXuatLuoi;
                }
                Excel.Range excelDinhDangDuLieu;
                excelDinhDangDuLieu = (ws_XuatLuoi).get_Range((object)("A" + iDemDong), (object)("O" + iDemDong));
                if (dtXuatLuoi.Rows[iXuatLuoi]["Thu"].ToString() == "CN")
                {
                    excelDinhDangDuLieu.Interior.Color = ColorTranslator.ToOle(Color.Aqua);
                }
            }
            Excel.Range excelVienXuatLuoi;
            excelVienXuatLuoi = (ws_XuatLuoi).get_Range((object)"A2", (object)("O" + iDemDong));
            excelVienXuatLuoi.Borders.LineStyle = Excel.Constants.xlBoth;
            excelVienXuatLuoi.Font.Name = "Times New Roman";
            excelVienXuatLuoi.Font.Size = "12";
        }

        private void ThongKeThangGio()
        {
            DateTime dNgayTinh;
            dNgayTinh = Convert.ToDateTime(dateTimeTuNgay.Text);
            DateTime dNgayBatDauTinhCong;
            dNgayBatDauTinhCong = new DateTime(dNgayTinh.Year, dNgayTinh.Month, dNgayTinh.Day, 0, 0, 0);
            _ = Thread.CurrentThread.CurrentCulture;
            Thread.CurrentThread.CurrentCulture = new CultureInfo("en-US");
            Excel.Application xla_ThongKeThang_Gio;
            xla_ThongKeThang_Gio = new Excel.Application();
            xla_ThongKeThang_Gio.Workbooks.Add(Excel.XlSheetType.xlWorksheet);
            _ = xla_ThongKeThang_Gio.ActiveSheet;
            Excel.Worksheet ws_ThongKeThang_Gio;
            ws_ThongKeThang_Gio = xla_ThongKeThang_Gio.Worksheets.get_Item((object)1);
            bool failed;
            do
            {
                try
                {
                    Excel.Range excelThongKeThangGio_TenCongTy;
                    excelThongKeThangGio_TenCongTy = (ws_ThongKeThang_Gio).get_Range((object)"A1", (object)"AT1");
                    excelThongKeThangGio_TenCongTy.Select();
                    excelThongKeThangGio_TenCongTy.Cells[1, 1] = "Công ty: " + sTenCongTyReport;
                    excelThongKeThangGio_TenCongTy.get_Range((object)"A1", (object)"AT1").Merge(true);
                    Excel.Range excelThongKeThangGio_DiaChiCongTy;
                    excelThongKeThangGio_DiaChiCongTy = (ws_ThongKeThang_Gio).get_Range((object)"A2", (object)"AT2");
                    excelThongKeThangGio_DiaChiCongTy.Cells[1, 1] = "Địa chỉ: " + sDiaChiCongTyReport;
                    excelThongKeThangGio_DiaChiCongTy.get_Range((object)"A1", (object)"AT1").Merge(true);
                    Excel.Range excelThongKeThangGio_TieuDe;
                    excelThongKeThangGio_TieuDe = (ws_ThongKeThang_Gio).get_Range((object)"A4", (object)"AT4");
                    excelThongKeThangGio_TieuDe.Cells[1, 1] = "BẢNG THỐNG KÊ CHẤM CÔNG (GIỜ)";
                    excelThongKeThangGio_TieuDe.get_Range((object)"A1", (object)"AT1").Merge(true);
                    excelThongKeThangGio_TieuDe.Font.Name = "Times New Roman";
                    excelThongKeThangGio_TieuDe.Font.Size = "16";
                    excelThongKeThangGio_TieuDe.Font.Bold = true;
                    excelThongKeThangGio_TieuDe.RowHeight = "24";
                    excelThongKeThangGio_TieuDe.HorizontalAlignment = Excel.Constants.xlCenter;
                    Excel.Range excelThongKeThangGio_STT;
                    excelThongKeThangGio_STT = (ws_ThongKeThang_Gio).get_Range((object)"A5", (object)"A6");
                    excelThongKeThangGio_STT.Cells[1, 1] = "STT";
                    excelThongKeThangGio_STT.get_Range((object)"A1", (object)"A2").MergeCells = true;
                    excelThongKeThangGio_STT.ColumnWidth = 5;
                    Excel.Range excelThongKeThangGio_PhongBan;
                    excelThongKeThangGio_PhongBan = (ws_ThongKeThang_Gio).get_Range((object)"B5", (object)"B6");
                    excelThongKeThangGio_PhongBan.Cells[1, 1] = "PHÒNG BAN";
                    excelThongKeThangGio_PhongBan.get_Range((object)"A1", (object)"A2").MergeCells = true;
                    excelThongKeThangGio_PhongBan.ColumnWidth = 12;
                    Excel.Range excelThongKeThangGio_MaSoNhanVien;
                    excelThongKeThangGio_MaSoNhanVien = (ws_ThongKeThang_Gio).get_Range((object)"C5", (object)"C6");
                    excelThongKeThangGio_MaSoNhanVien.Cells[1, 1] = "MSNV";
                    excelThongKeThangGio_MaSoNhanVien.get_Range((object)"A1", (object)"A2").MergeCells = true;
                    excelThongKeThangGio_MaSoNhanVien.ColumnWidth = 7;
                    Excel.Range excelThongKeThangGio_TenNhanVien;
                    excelThongKeThangGio_TenNhanVien = (ws_ThongKeThang_Gio).get_Range((object)"D5", (object)"D6");
                    excelThongKeThangGio_TenNhanVien.Cells[1, 1] = "TÊN NHÂN VIÊN";
                    excelThongKeThangGio_TenNhanVien.get_Range((object)"A1", (object)"A2").MergeCells = true;
                    excelThongKeThangGio_TenNhanVien.ColumnWidth = 14;
                    Excel.Range excelThongKeThangGio_NgayVaoLamViec;
                    excelThongKeThangGio_NgayVaoLamViec = (ws_ThongKeThang_Gio).get_Range((object)"E5", (object)"E6");
                    excelThongKeThangGio_NgayVaoLamViec.Cells[1, 1] = "NGÀY VÀO LÀM";
                    excelThongKeThangGio_NgayVaoLamViec.get_Range((object)"A1", (object)"A2").MergeCells = true;
                    excelThongKeThangGio_NgayVaoLamViec.ColumnWidth = 14;
                    int iTangCot;
                    iTangCot = 5;
                    int ColunmNgay;
                    ColunmNgay = 1;
                    for (int iThongKe_Gio = 0; iThongKe_Gio < 31; iThongKe_Gio++)
                    {
                        DateTime dtNgayChamThongKeGio;
                        dtNgayChamThongKeGio = dateTimeTuNgay.Value;
                        int iNgayChamThongKeGio;
                        iNgayChamThongKeGio = Convert.ToInt32(Convert.ToDateTime(dtNgayChamThongKeGio.AddDays(iThongKe_Gio).ToString()).Day);
                        Excel.Range excelThongKeThangGio_Ngay;
                        excelThongKeThangGio_Ngay = (ws_ThongKeThang_Gio).get_Range((object)"F5", (object)"AJ6");
                        excelThongKeThangGio_Ngay.Cells[1, ColunmNgay] = iNgayChamThongKeGio;
                        excelThongKeThangGio_Ngay.Cells[2, ColunmNgay] = DateTimeProgress.XuatThuReport((int)dtNgayChamThongKeGio.AddDays(iThongKe_Gio).DayOfWeek);
                        ColunmNgay++;
                        excelThongKeThangGio_Ngay.ColumnWidth = 5;
                    }
                    Excel.Range excelThongKeThangGio_NgayCong;
                    excelThongKeThangGio_NgayCong = (ws_ThongKeThang_Gio).get_Range((object)"AK5", (object)"AK6");
                    excelThongKeThangGio_NgayCong.Cells[1, 1] = "Giờ công";
                    excelThongKeThangGio_NgayCong.get_Range((object)"A1", (object)"A2").MergeCells = true;
                    Excel.Range excelThongKeThangGio_TangCa;
                    excelThongKeThangGio_TangCa = (ws_ThongKeThang_Gio).get_Range((object)"AL5", (object)"AO5");
                    excelThongKeThangGio_TangCa.Cells[1, 1] = "Tăng ca";
                    excelThongKeThangGio_TangCa.get_Range((object)"A1", (object)"D1").Merge(true);
                    int ColumTangCa;
                    ColumTangCa = 1;
                    for (int iThongKeGio_TangCa = 1; iThongKeGio_TangCa < 5; iThongKeGio_TangCa++)
                    {
                        Excel.Range excelThongKeThangGio_ChiTietTangCa;
                        excelThongKeThangGio_ChiTietTangCa = (ws_ThongKeThang_Gio).get_Range((object)"AL6", (object)"AO6");
                        excelThongKeThangGio_ChiTietTangCa.Cells[1, ColumTangCa] = "TC " + iThongKeGio_TangCa;
                        ColumTangCa++;
                        excelThongKeThangGio_ChiTietTangCa.ColumnWidth = 5;
                    }
                    Excel.Range excelThongKeThangGio_Vang;
                    excelThongKeThangGio_Vang = (ws_ThongKeThang_Gio).get_Range((object)"AP5", (object)"AP6");
                    excelThongKeThangGio_Vang.Cells[1, 1] = "V";
                    excelThongKeThangGio_Vang.get_Range((object)"A1", (object)"A2").MergeCells = true;
                    excelThongKeThangGio_Vang.ColumnWidth = 5;
                    Excel.Range excelThongKeThangGio_PhepNam;
                    excelThongKeThangGio_PhepNam = (ws_ThongKeThang_Gio).get_Range((object)"AQ5", (object)"AQ6");
                    excelThongKeThangGio_PhepNam.Cells[1, 1] = "PN";
                    excelThongKeThangGio_PhepNam.get_Range((object)"A1", (object)"A2").MergeCells = true;
                    excelThongKeThangGio_PhepNam.ColumnWidth = 5;
                    Excel.Range excelThongKeThangGio_CheDo;
                    excelThongKeThangGio_CheDo = (ws_ThongKeThang_Gio).get_Range((object)"AR5", (object)"AR6");
                    excelThongKeThangGio_CheDo.Cells[1, 1] = "CĐ";
                    excelThongKeThangGio_CheDo.get_Range((object)"A1", (object)"A2").MergeCells = true;
                    excelThongKeThangGio_CheDo.ColumnWidth = 5;
                    Excel.Range excelThongKeThangGio_Tre;
                    excelThongKeThangGio_Tre = (ws_ThongKeThang_Gio).get_Range((object)"AS5", (object)"AS6");
                    excelThongKeThangGio_Tre.Cells[1, 1] = "Trễ";
                    excelThongKeThangGio_Tre.get_Range((object)"A1", (object)"A2").MergeCells = true;
                    excelThongKeThangGio_Tre.ColumnWidth = 5;
                    Excel.Range excelThongKeThangGio_Som;
                    excelThongKeThangGio_Som = (ws_ThongKeThang_Gio).get_Range((object)"AT5", (object)"AT6");
                    excelThongKeThangGio_Som.Cells[1, 1] = "Sớm";
                    excelThongKeThangGio_Som.get_Range((object)"A1", (object)"A2").MergeCells = true;
                    excelThongKeThangGio_Som.ColumnWidth = 5;
                    Excel.Range excelThongKeThangGio_Total;
                    excelThongKeThangGio_Total = (ws_ThongKeThang_Gio).get_Range((object)"A5", (object)"AT6");
                    excelThongKeThangGio_Total.Font.Name = "Times New Roman";
                    excelThongKeThangGio_Total.Font.Size = "10";
                    excelThongKeThangGio_Total.Font.Bold = true;
                    excelThongKeThangGio_Total.Interior.Color = ColorTranslator.ToOle(Color.Aqua);
                    excelThongKeThangGio_Total.HorizontalAlignment = Excel.Constants.xlCenter;
                    xla_ThongKeThang_Gio.Visible = true;
                    int iDemDongThongKeThangGio;
                    iDemDongThongKeThangGio = 7;
                    new DataTable();
                    DataTable dtNgayTinhCongThongKeThangGio;
                    dtNgayTinhCongThongKeThangGio = _ngayTinhCongBLL.showThongTinNgayTinhCong();
                    for (int iNgayTinhCongThongKeThangGio = 0; iNgayTinhCongThongKeThangGio < dtNgayTinhCongThongKeThangGio.Rows.Count; iNgayTinhCongThongKeThangGio++)
                    {
                        int iTangHang;
                        iTangHang = 7;
                        int iSTTThongKeThangGio;
                        iSTTThongKeThangGio = 1;
                        int iMaChamCongThongKeThangGio;
                        iMaChamCongThongKeThangGio = 0;
                        DateTime dNgayBatDauTinhCongThongKeThangGio;
                        dNgayBatDauTinhCongThongKeThangGio = Convert.ToDateTime(dtNgayTinhCongThongKeThangGio.Rows[iNgayTinhCongThongKeThangGio]["NgayBatDau"].ToString());
                        int iTongNgayTinhCongThongKeThangGio;
                        iTongNgayTinhCongThongKeThangGio = Convert.ToInt32((Convert.ToDateTime(dtNgayTinhCongThongKeThangGio.Rows[iNgayTinhCongThongKeThangGio]["NgayKetThuc"].ToString()) - dNgayBatDauTinhCongThongKeThangGio).TotalDays);
                        new DataTable();
                        _tinhCongDTO.Ngay = dNgayBatDauTinhCong;
                        DataTable dtTinhCongThongKeThangGio;
                        dtTinhCongThongKeThangGio = _tinhCongBLL.TinhCongGetNgay(_tinhCongDTO);
                        for (int iTinhCongThongKeThangGio = 0; iTinhCongThongKeThangGio < dtTinhCongThongKeThangGio.Rows.Count; iTinhCongThongKeThangGio++)
                        {
                            int iDemCotThongKeThangGio;
                            iDemCotThongKeThangGio = 1;
                            if (Convert.ToInt32(dtTinhCongThongKeThangGio.Rows[iTinhCongThongKeThangGio]["MaChamCong"].ToString()) == iMaChamCongThongKeThangGio)
                            {
                                continue;
                            }
                            iMaChamCongThongKeThangGio = Convert.ToInt32(dtTinhCongThongKeThangGio.Rows[iTinhCongThongKeThangGio]["MaChamCong"].ToString());
                            Excel.Range excelThongKeThangGio_STTDuLieu;
                            excelThongKeThangGio_STTDuLieu = (ws_ThongKeThang_Gio).get_Range((object)("A" + iDemDongThongKeThangGio), (object)("A" + iDemDongThongKeThangGio));
                            excelThongKeThangGio_STTDuLieu.Cells[1, 1] = iSTTThongKeThangGio;
                            excelThongKeThangGio_STTDuLieu.Select();
                            Excel.Range excelThongKeThangGio_MaNhanVienDuLieu;
                            excelThongKeThangGio_MaNhanVienDuLieu = (ws_ThongKeThang_Gio).get_Range((object)("C" + iDemDongThongKeThangGio), (object)("C" + iDemDongThongKeThangGio));
                            excelThongKeThangGio_MaNhanVienDuLieu.get_Range((object)"A1", (object)"A1").NumberFormat = "@";
                            excelThongKeThangGio_MaNhanVienDuLieu.Cells[1, 1] = dtTinhCongThongKeThangGio.Rows[iTinhCongThongKeThangGio]["MaNhanVien"].ToString();
                            (ws_ThongKeThang_Gio).get_Range((object)("D" + iDemDongThongKeThangGio), (object)("D" + iDemDongThongKeThangGio)).Cells[1, 1] = dtTinhCongThongKeThangGio.Rows[iTinhCongThongKeThangGio]["TenNhanVien"].ToString();
                            string sTenPhongBan;
                            sTenPhongBan = "";
                            new DataTable();
                            _phongBanDTO.MaPhongBan = dtTinhCongThongKeThangGio.Rows[iTinhCongThongKeThangGio]["PhongBan"].ToString();
                            DataTable dtPhongBan;
                            dtPhongBan = _phongBanBLL.getTenPhongBanByMaPhongBan(_phongBanDTO);
                            for (int iPhongBan = 0; iPhongBan < dtPhongBan.Rows.Count; iPhongBan++)
                            {
                                sTenPhongBan = dtPhongBan.Rows[iPhongBan]["TenPhongBan"].ToString();
                            }
                            Excel.Range excelThongKeThangGio_PhongBanDuLieu;
                            excelThongKeThangGio_PhongBanDuLieu = (ws_ThongKeThang_Gio).get_Range((object)("B" + iDemDongThongKeThangGio), (object)("B" + iDemDongThongKeThangGio));
                            if (sTenPhongBan == "")
                            {
                                excelThongKeThangGio_PhongBanDuLieu.Cells[1, 1] = "-----";
                            }
                            else
                            {
                                excelThongKeThangGio_PhongBanDuLieu.Cells[1, 1] = sTenPhongBan;
                            }
                            new DataTable();
                            _nhanVienDTO.MaChamCong = iMaChamCongThongKeThangGio.ToString();
                            DataTable dtNhanVien;
                            dtNhanVien = _nhanVienBLL.NhanVienGetByMaChamCong(iMaChamCongThongKeThangGio.ToString());
                            for (int iNhanVien = 0; iNhanVien < dtNhanVien.Rows.Count; iNhanVien++)
                            {
                                string sNgayVaoLam;
                                sNgayVaoLam = string.Format("{0:d}", Convert.ToDateTime(dtNhanVien.Rows[iNhanVien]["NgayVaoLamViec"].ToString()));
                                (ws_ThongKeThang_Gio).get_Range((object)("E" + iDemDongThongKeThangGio), (object)("E" + iDemDongThongKeThangGio)).Cells[1, 1] = sNgayVaoLam;
                            }
                            for (int iThongKeThangGio_NgayDuLieu = 0; iThongKeThangGio_NgayDuLieu <= iTongNgayTinhCongThongKeThangGio; iThongKeThangGio_NgayDuLieu++)
                            {
                                string sKyHieu;
                                sKyHieu = "";
                                string sKyHieuPhu;
                                sKyHieuPhu = "";
                                double dGioHangNgay;
                                dGioHangNgay = 0.0;
                                double dDuLieuThongKeThangGio;
                                dDuLieuThongKeThangGio = 0.0;
                                DateTime dNgayChamThongKeGio;
                                dNgayChamThongKeGio = Convert.ToDateTime(dNgayBatDauTinhCong.AddDays(iThongKeThangGio_NgayDuLieu).ToString());
                                new DataTable();
                                _tinhCongDTO.MaChamCong = iMaChamCongThongKeThangGio;
                                _tinhCongDTO.Ngay = dNgayChamThongKeGio;
                                DataTable dtDuLieuNgayThongKeThangGio;
                                dtDuLieuNgayThongKeThangGio = _tinhCongBLL.TinhCongGetMaChamCongAndNgayThongKeGio(_tinhCongDTO);
                                for (int iDuLieuNgayThongKeThangGio = 0; iDuLieuNgayThongKeThangGio < dtDuLieuNgayThongKeThangGio.Rows.Count; iDuLieuNgayThongKeThangGio++)
                                {
                                    dtDuLieuNgayThongKeThangGio.Rows[iDuLieuNgayThongKeThangGio]["Thu"].ToString();
                                    sKyHieu = dtDuLieuNgayThongKeThangGio.Rows[iDuLieuNgayThongKeThangGio]["KyHieu"].ToString();
                                    sKyHieuPhu = dtDuLieuNgayThongKeThangGio.Rows[iDuLieuNgayThongKeThangGio]["KyHieuPhu"].ToString();
                                    dDuLieuThongKeThangGio += Convert.ToDouble(dtDuLieuNgayThongKeThangGio.Rows[iDuLieuNgayThongKeThangGio]["Gio"].ToString());
                                }
                                Excel.Range excelThongKeThangGio_GioDuLieu;
                                excelThongKeThangGio_GioDuLieu = (ws_ThongKeThang_Gio).get_Range((object)("F" + iDemDongThongKeThangGio), (object)("AJ" + iDemDongThongKeThangGio));
                                excelThongKeThangGio_GioDuLieu.Cells[1, iDemCotThongKeThangGio] = dGioHangNgay;
                                if (sKyHieu == sKHVang)
                                {
                                    if (sKyHieuPhu != "CN")
                                    {
                                        excelThongKeThangGio_GioDuLieu.Cells[1, iDemCotThongKeThangGio] = sKHVang;
                                    }
                                    else
                                    {
                                        excelThongKeThangGio_GioDuLieu.Cells[1, iDemCotThongKeThangGio] = "";
                                    }
                                }
                                else if (sKyHieu == sKHDungGio)
                                {
                                    excelThongKeThangGio_GioDuLieu.Cells[1, iDemCotThongKeThangGio] = dDuLieuThongKeThangGio;
                                }
                                else
                                {
                                    excelThongKeThangGio_GioDuLieu.Cells[1, iDemCotThongKeThangGio] = sKyHieu;
                                }
                                iTangCot++;
                                iDemCotThongKeThangGio++;
                            }
                            double dTongNgayCongThongKeThangGio;
                            dTongNgayCongThongKeThangGio = 0.0;
                            double dTongGioTC1ThongKeThangGio;
                            dTongGioTC1ThongKeThangGio = 0.0;
                            double dTongGioTC2ThongKeThangGio;
                            dTongGioTC2ThongKeThangGio = 0.0;
                            double dTongGioTC3ThongKeThangGio;
                            dTongGioTC3ThongKeThangGio = 0.0;
                            double dTongGioTC4ThongKeThangGio;
                            dTongGioTC4ThongKeThangGio = 0.0;
                            double dTongTreThongKeThangGio;
                            dTongTreThongKeThangGio = 0.0;
                            double dTongVeSomThongKeThangGio;
                            dTongVeSomThongKeThangGio = 0.0;
                            double iDemPhepNamThongKeThangGio;
                            iDemPhepNamThongKeThangGio = 0.0;
                            double dTongGioNghiCheDo;
                            dTongGioNghiCheDo = 0.0;
                            double iDemVangThongKeThangGio;
                            iDemVangThongKeThangGio = 0.0;
                            new DataTable();
                            _tinhCongDTO.MaChamCong = iMaChamCongThongKeThangGio;
                            DataTable dtDuLieuTongThongKeThangGio;
                            dtDuLieuTongThongKeThangGio = _tinhCongBLL.TinhCongGetByMaChamCong(_tinhCongDTO);
                            for (int iDuLieuTongThongKeThangGio = 0; iDuLieuTongThongKeThangGio < dtDuLieuTongThongKeThangGio.Rows.Count; iDuLieuTongThongKeThangGio++)
                            {
                                if (dtDuLieuTongThongKeThangGio.Rows[iDuLieuTongThongKeThangGio]["KyHieu"].ToString() == sKHDungGio)
                                {
                                    dTongNgayCongThongKeThangGio += Convert.ToDouble(dtDuLieuTongThongKeThangGio.Rows[iDuLieuTongThongKeThangGio]["Gio"].ToString());
                                }
                                dTongGioTC1ThongKeThangGio += Convert.ToDouble(dtDuLieuTongThongKeThangGio.Rows[iDuLieuTongThongKeThangGio]["TC1"].ToString());
                                dTongGioTC2ThongKeThangGio += Convert.ToDouble(dtDuLieuTongThongKeThangGio.Rows[iDuLieuTongThongKeThangGio]["TC2"].ToString());
                                dTongGioTC3ThongKeThangGio += Convert.ToDouble(dtDuLieuTongThongKeThangGio.Rows[iDuLieuTongThongKeThangGio]["TC3"].ToString());
                                dTongGioTC4ThongKeThangGio += Convert.ToDouble(dtDuLieuTongThongKeThangGio.Rows[iDuLieuTongThongKeThangGio]["TC4"].ToString());
                                dTongTreThongKeThangGio += Convert.ToDouble(dtDuLieuTongThongKeThangGio.Rows[iDuLieuTongThongKeThangGio]["Tre"].ToString());
                                dTongVeSomThongKeThangGio += Convert.ToDouble(dtDuLieuTongThongKeThangGio.Rows[iDuLieuTongThongKeThangGio]["VeSom"].ToString());
                                string sKyHieuDuLieuThongKeThang;
                                sKyHieuDuLieuThongKeThang = dtDuLieuTongThongKeThangGio.Rows[iDuLieuTongThongKeThangGio]["KyHieu"].ToString();
                                if (sKyHieuDuLieuThongKeThang == sKHPhepNam)
                                {
                                    iDemPhepNamThongKeThangGio += Convert.ToDouble(dtDuLieuTongThongKeThangGio.Rows[iDuLieuTongThongKeThangGio]["Gio"].ToString());
                                }
                                if (sKyHieuDuLieuThongKeThang == sKHVang)
                                {
                                    iDemVangThongKeThangGio += 1.0;
                                }
                                if (sKyHieuDuLieuThongKeThang != sKHVang && sKyHieuDuLieuThongKeThang != sKHDungGio && sKyHieuDuLieuThongKeThang != sKHPhepNam && sKyHieuDuLieuThongKeThang != sKHLe)
                                {
                                    dTongGioNghiCheDo += Convert.ToDouble(dtDuLieuTongThongKeThangGio.Rows[iDuLieuTongThongKeThangGio]["Gio"].ToString());
                                }
                            }
                            (ws_ThongKeThang_Gio).get_Range((object)("AK" + iDemDongThongKeThangGio), (object)("AK" + iDemDongThongKeThangGio)).Cells[1, 1] = dTongNgayCongThongKeThangGio;
                            (ws_ThongKeThang_Gio).get_Range((object)("AL" + iDemDongThongKeThangGio), (object)("AL" + iDemDongThongKeThangGio)).Cells[1, 1] = dTongGioTC1ThongKeThangGio;
                            (ws_ThongKeThang_Gio).get_Range((object)("AM" + iDemDongThongKeThangGio), (object)("AM" + iDemDongThongKeThangGio)).Cells[1, 1] = dTongGioTC2ThongKeThangGio;
                            (ws_ThongKeThang_Gio).get_Range((object)("AN" + iDemDongThongKeThangGio), (object)("AN" + iDemDongThongKeThangGio)).Cells[1, 1] = dTongGioTC3ThongKeThangGio;
                            (ws_ThongKeThang_Gio).get_Range((object)("AO" + iDemDongThongKeThangGio), (object)("AO" + iDemDongThongKeThangGio)).Cells[1, 1] = dTongGioTC4ThongKeThangGio;
                            (ws_ThongKeThang_Gio).get_Range((object)("AP" + iDemDongThongKeThangGio), (object)("AP" + iDemDongThongKeThangGio)).Cells[1, 1] = iDemVangThongKeThangGio * 8.0;
                            (ws_ThongKeThang_Gio).get_Range((object)("AQ" + iDemDongThongKeThangGio), (object)("AQ" + iDemDongThongKeThangGio)).Cells[1, 1] = iDemPhepNamThongKeThangGio;
                            (ws_ThongKeThang_Gio).get_Range((object)("AR" + iDemDongThongKeThangGio), (object)("AR" + iDemDongThongKeThangGio)).Cells[1, 1] = dTongGioNghiCheDo;
                            (ws_ThongKeThang_Gio).get_Range((object)("AS" + iDemDongThongKeThangGio), (object)("AS" + iDemDongThongKeThangGio)).Cells[1, 1] = dTongTreThongKeThangGio;
                            (ws_ThongKeThang_Gio).get_Range((object)("AT" + iDemDongThongKeThangGio), (object)("AT" + iDemDongThongKeThangGio)).Cells[1, 1] = dTongVeSomThongKeThangGio;
                            iTangHang++;
                            iDemDongThongKeThangGio++;
                            iSTTThongKeThangGio++;
                        }
                    }
                    Excel.Range excelThongKeThangGio_DinhDangDuLieu;
                    excelThongKeThangGio_DinhDangDuLieu = (ws_ThongKeThang_Gio).get_Range((object)"A7", (object)("AT" + (iDemDongThongKeThangGio - 1)));
                    excelThongKeThangGio_DinhDangDuLieu.Font.Name = "Times New Roman";
                    excelThongKeThangGio_DinhDangDuLieu.Font.Size = "8";
                    excelThongKeThangGio_DinhDangDuLieu.HorizontalAlignment = Excel.Constants.xlCenter;
                    (ws_ThongKeThang_Gio).get_Range((object)"A4", (object)("AT" + (iDemDongThongKeThangGio - 1))).Borders.LineStyle = Excel.Constants.xlBoth;
                    failed = false;
                }
                catch (COMException)
                {
                    failed = true;
                }
                Thread.Sleep(10);
            }
            while (failed);
        }

        public DataTable GetDataTable(DataGridView dgvtemp)
        {
            DataTable DTT;
            DTT = new DataTable();
            while (DTT.Rows.Count < dgvtemp.Rows.Count - 1)
            {
                DTT.Rows.Add();
            }
            for (int i = 0; i < dgvtemp.Columns.Count; i++)
            {
                DTT.Columns.Add(dgvtemp.Columns[i].Name.ToString());
                for (int j = 0; j < dgvtemp.Rows.Count - 1; j++)
                {
                    DTT.Rows[j][i] = DGVTinhCong[i, j].Value.ToString();
                }
            }
            return DTT;
        }

        private void txtTimKiem_TextChanged(object sender, EventArgs e)
        {
            if (txtTimKiem.Text != "")
            {
                DGVDanhSachNhanVien.Rows.Clear();
                new DataTable();
                _nhanVienDTO.MaNhanVien = txtTimKiem.Text;
                _nhanVienDTO.TenNhanVien = txtTimKiem.Text;
                DataTable dtSearchNhanVienTinhCong;
                dtSearchNhanVienTinhCong = _nhanVienBLL.NhanVienSearchTinhCong(txtTimKiem.Text);
                for (int iSearchNhanVienTinhCong = 0; iSearchNhanVienTinhCong < dtSearchNhanVienTinhCong.Rows.Count; iSearchNhanVienTinhCong++)
                {
                    int addSerchTinhCong;
                    addSerchTinhCong = DGVDanhSachNhanVien.Rows.Add();
                    DGVDanhSachNhanVien.Rows[addSerchTinhCong].Cells[1].Value = dtSearchNhanVienTinhCong.Rows[iSearchNhanVienTinhCong]["MaNhanVien"].ToString();
                    DGVDanhSachNhanVien.Rows[addSerchTinhCong].Cells[2].Value = dtSearchNhanVienTinhCong.Rows[iSearchNhanVienTinhCong]["TenNhanVien"].ToString();
                    DGVDanhSachNhanVien.Rows[addSerchTinhCong].Cells[3].Value = dtSearchNhanVienTinhCong.Rows[iSearchNhanVienTinhCong]["MaChamCong"].ToString();
                    DGVDanhSachNhanVien.Rows[addSerchTinhCong].Cells[4].Value = dtSearchNhanVienTinhCong.Rows[iSearchNhanVienTinhCong]["NgayVaoLamViec"].ToString();
                    DGVDanhSachNhanVien.Rows[addSerchTinhCong].Cells[5].Value = _convertMoney.chendau(Convert.ToInt32(dtSearchNhanVienTinhCong.Rows[iSearchNhanVienTinhCong]["TienLuong"]).ToString());
                    DGVDanhSachNhanVien.Rows[addSerchTinhCong].Cells[6].Value = dtSearchNhanVienTinhCong.Rows[iSearchNhanVienTinhCong]["DangThamGiaBaoHiem"].ToString();
                    DGVDanhSachNhanVien.Rows[addSerchTinhCong].Cells[7].Value = dtSearchNhanVienTinhCong.Rows[iSearchNhanVienTinhCong]["MaPhongBan"].ToString();
                    DGVDanhSachNhanVien.Rows[addSerchTinhCong].Cells[8].Value = _convertMoney.chendau(Convert.ToInt32(dtSearchNhanVienTinhCong.Rows[iSearchNhanVienTinhCong]["LuongHopDong"]).ToString());
                }
            }
        }

        private void checkBoxCoTinhLuong_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBoxCoTinhLuong.Checked)
            {
                txtNgayCongTinh.Enabled = true;
            }
            else
            {
                txtNgayCongTinh.Enabled = false;
            }
        }

        private void DGVTinhCong_CellClick(object sender, DataGridViewCellEventArgs e)
        {
        }

        private void tabControl2_Click(object sender, EventArgs e)
        {
        }

        private void ThemGioToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void XoaGioToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void SuaGioToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }
        private void DGVSuaXoaGioCham_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            this.sMaChamCongSuaXoaGioCham = this.DGVSuaXoaGioCham.CurrentRow.Cells[0].Value.ToString();
            this.sNgayChamSuaXoaGioCham = this.DGVSuaXoaGioCham.CurrentRow.Cells[1].Value.ToString();
            this.sGioChamSuaXoaGioCham = this.DGVSuaXoaGioCham.CurrentRow.Cells[2].Value.ToString();
            this.sKieuChamSuaXoaGioCham = this.DGVSuaXoaGioCham.CurrentRow.Cells[3].Value.ToString();
            this.sMaSoMaySuaXoaGioCham = this.DGVSuaXoaGioCham.CurrentRow.Cells[5].Value.ToString();
            this.sIDSuaXoaGioCham = this.DGVSuaXoaGioCham.CurrentRow.Cells[7].Value.ToString();
        }
        private void btnXoa_Click(object sender, EventArgs e)
        {
            //this._checkInOutDTO.ID = Convert.ToInt32(this.sIDSuaXoaGioCham);
            //this._checkInOutBLL.CheckInOutDeleteGioCham(this._checkInOutDTO);
            //MessageBox.Show("Bạn hãy tính công lại");
        }
        private void btnSua_Click(object sender, EventArgs e)
        {
            //frmSuaXoaGioCham _suaXoaGioCham;
            //_suaXoaGioCham = new frmSuaXoaGioCham();
            //_suaXoaGioCham._MaChamCong = this.sMaChamCongSuaXoaGioCham;
            //_suaXoaGioCham._NgayCham = this.sNgayChamSuaXoaGioCham;
            //_suaXoaGioCham._GioCham = this.sGioChamSuaXoaGioCham;
            //_suaXoaGioCham._KieuCham = this.sKieuChamSuaXoaGioCham;
            //_suaXoaGioCham._MaSoMay = this.sMaSoMaySuaXoaGioCham;
            //_suaXoaGioCham._ID = this.sIDSuaXoaGioCham;
            //_suaXoaGioCham.ShowDialog();
        }
        private void button1_Click(object sender, EventArgs e)
        {
            //if (this.sMaChamCongThemGio == "" || this.sMaChamCongThemGio == null)
            //{
            //    MessageBox.Show("Chưa chọn nhân viên");
            //    return;
            //}
            //frmThemGioNhanh _themgionhanh;
            //_themgionhanh = new frmThemGioNhanh();
            //_themgionhanh._MaChamCong = this.sMaChamCongThemGio;
            //_themgionhanh._dNgayCham = this.dNgayChamCongThemGio;
            //_themgionhanh.ShowDialog();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            //if (this.sMaChamCongThemGio == "" || this.sMaChamCongThemGio == null)
            //{
            //    MessageBox.Show("Chưa chọn nhân viên");
            //    return;
            //}
            //frmXoaGio _frmXoaGio;
            //_frmXoaGio = new frmXoaGio();
            //_frmXoaGio.dXoaGioChamVao = this.dGioChamVaoThemGioCheck;
            //_frmXoaGio.dXoaGioChamRa = this.dGioChamRaThemGioCheck;
            //_frmXoaGio.sMaChamCongXoaGio = this.sMaChamCongThemGio;
            //_frmXoaGio.iCheckVao = this.iCheckTrongVao;
            //_frmXoaGio.iCheckRa = this.iCheckTrongRa;
            //_frmXoaGio.Show();
        }

        private void btnSuaGio_Click(object sender, EventArgs e)
        {

        }
    }
}
