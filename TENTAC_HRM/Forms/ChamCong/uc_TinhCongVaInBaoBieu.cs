using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Printing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using TENTAC_HRM.BusinessLogicLayer.BaoBieuBLL;
using TENTAC_HRM.BusinessLogicLayer.ChamCongBLL;
using TENTAC_HRM.Common;
using TENTAC_HRM.Model;

namespace TENTAC_HRM.Forms.ChamCong
{
    public partial class uc_TinhCongVaInBaoBieu : UserControl
    {
        private TuyChonBLL _tuyChonBLL = new TuyChonBLL();
        private TuyChon_model _tuyChonDTO = new TuyChon_model();
        private NgayTinhCong_model _ngayTinhCongDTO = new NgayTinhCong_model();
        private NgayTinhCongBLL _ngayTinhCongBLL = new NgayTinhCongBLL();
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

        private int iLuaChon = 0;

        private int demNhanVienVangTinhCong = 0;

        private int demNhanVienNghiLeTinhCong = 0;

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

        private double dTongTienPhuCap = 0.0;

        private double dTongTienPhuCapTienCom = 0.0;

        private double dTongTienPhuCapKhac = 0.0;

        private double dTongTienTamUng = 0.0;

        private double dTongTienViPham = 0.0;

        private double dTongTienThuong = 0.0;

        private int iDemCuoiTuan = 0;

        private string sLoadCaLamViec;

        private string sMaCaLamViec;

        private string sCaLamViec;

        private int iLamTronCong;

        private int iLamTronGio;

        private string sDinhDangThoiGian;

        private string sLuaChonKhaiBaoLuongBaoHiem;

        private double dTangCa1HeSo;

        private double dTangCa2HeSo;

        private double dTangCa3HeSo;

        private double dTangCa4HeSo;

        private double dSoTienKhaiBao;

        private double dHeSoBaoHiemXaHoi;

        private double dHeSoBaoHiemYTe;

        private double dHeSoBaoHiemThatNghiep;

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

        string treeview_select = "";

        private string sTuNgayChiTietThoiGianLamViec;

        private string sDenNgayChiTietThoiGianLamViec;

        public static uc_TinhCongVaInBaoBieu _instance;
        public static uc_TinhCongVaInBaoBieu Instance
        {
            get
            {
                if (_instance == null)
                    _instance = new uc_TinhCongVaInBaoBieu();
                return _instance;
            }
        }
        public uc_TinhCongVaInBaoBieu()
        {
            InitializeComponent();
        }

        private void uc_TinhCongVaInBaoBieu_Load(object sender, EventArgs e)
        {
            xuatThuTuNgay();
            xuatThuDenNgay();
            load_treeview();
            panel6.Hide();
            dgv_danhsach_nhanvien.Columns.Insert(0, new DataGridViewCheckBoxColumn());
            dgv_danhsach_nhanvien.Columns[0].Width = 30;
            ngayTinhCong();
            loadControlTinhCong();
            loadControlTinhLuong();
            loadTuyChon();
            loadListViewBaoCao();
            loadThongTinCongTy();
            load_nhanvien();
        }
        private void load_treeview()
        {
            string sql_nv_nghiviec_dv = "select ma_phong_ban,ten_phong_ban from phong_ban where id_loai_phong_ban = 2";
            DataTable dt_nv_nghiviec_dv = new DataTable();
            dt_nv_nghiviec_dv = SQLHelper.ExecuteDt(sql_nv_nghiviec_dv);
            for (int i = 0; i < dt_nv_nghiviec_dv.Rows.Count; i++)
            {
                TreeNode treenv_nghiviec_dv = new TreeNode();
                treenv_nghiviec_dv.Text = dt_nv_nghiviec_dv.Rows[i][1].ToString();
                treenv_nghiviec_dv.Tag = dt_nv_nghiviec_dv.Rows[i][0].ToString();
                trv_sodoquanly.Nodes[1].Nodes.Add(treenv_nghiviec_dv);

                string sql_phongban_nghiviec = string.Format("select ma_phong_ban,ten_phong_ban from phong_ban where ma_phong_ban_root = '{0}'", dt_nv_nghiviec_dv.Rows[i]["ma_phong_ban"].ToString());
                DataTable dt_phongban_nghiviec = new DataTable();
                dt_phongban_nghiviec = SQLHelper.ExecuteDt(sql_phongban_nghiviec);
                for (int j = 0; j < dt_phongban_nghiviec.Rows.Count; j++)
                {
                    TreeNode treephongban_nghiviec = new TreeNode();
                    treephongban_nghiviec.Text = dt_phongban_nghiviec.Rows[j][1].ToString();
                    treephongban_nghiviec.Tag = dt_phongban_nghiviec.Rows[j][0].ToString();
                    trv_sodoquanly.Nodes[1].Nodes[i].Nodes.Add(treephongban_nghiviec);
                }
            }
            string sql = "select ma_phong_ban,ten_phong_ban from phong_ban where id_loai_phong_ban = 1";
            DataTable dt_cty = new DataTable();
            dt_cty = SQLHelper.ExecuteDt(sql);
            for (int i = 0; i < dt_cty.Rows.Count; i++)
            {
                TreeNode treeCongTy = new TreeNode();
                treeCongTy.Text = dt_cty.Rows[i][1].ToString();
                treeCongTy.Tag = "ma_cty_" + dt_cty.Rows[i][0].ToString();
                trv_sodoquanly.Nodes.Add(treeCongTy);
                string sql_khuvuc = string.Format("select ma_phong_ban,ten_phong_ban from phong_ban where ma_phong_ban_root = '{0}'", dt_cty.Rows[i]["ma_phong_ban"].ToString());
                DataTable dt_khuvuc = new DataTable();
                dt_khuvuc = SQLHelper.ExecuteDt(sql_khuvuc);
                for (int j = 0; j < dt_khuvuc.Rows.Count; j++)
                {
                    TreeNode treekhuvuc = new TreeNode();
                    treekhuvuc.Text = dt_khuvuc.Rows[j][1].ToString();
                    treekhuvuc.Tag = "ma_khuvuc_" + dt_khuvuc.Rows[j][0].ToString();
                    trv_sodoquanly.Nodes[i + 2].Nodes.Add(treekhuvuc);

                    string sql_phongban = string.Format("select ma_phong_ban,ten_phong_ban from phong_ban where ma_phong_ban_root = '{0}'", dt_khuvuc.Rows[j]["ma_phong_ban"].ToString());
                    DataTable dt_phongban = new DataTable();
                    dt_phongban = SQLHelper.ExecuteDt(sql_phongban);
                    for (int z = 0; z < dt_phongban.Rows.Count; z++)
                    {
                        TreeNode treephongban = new TreeNode();
                        treephongban.Text = dt_phongban.Rows[z][1].ToString();
                        treephongban.Tag = dt_phongban.Rows[z][0].ToString();
                        trv_sodoquanly.Nodes[i + 2].Nodes[j].Nodes.Add(treephongban);
                    }
                }
            }
        }
        public void load_nhanvien()
        {
            string sql = "select ma_nhan_vien,ho_ten,ma_cham_cong from view_hoso_nhansu where 1=1";
            if (!string.IsNullOrEmpty(txt_tinkiem.Texts))
            {
                sql = sql + string.Format(" and ho_ten like N'%{0}%' or ma_nhan_vien like '%{0}%'", txt_tinkiem.Texts);
            }

            if (treeview_select != "")
            {
                if (treeview_select == "nv_nv")
                {

                }
                else if (treeview_select == "nv_moi")
                {
                    sql = sql + " and ma_phong_ban is null";
                }
                else if (treeview_select.Contains("id_cty"))
                {
                    sql = sql + string.Format(" and ma_cong_ty = '{0}'", treeview_select.Remove(0, 7));
                }
                else if (treeview_select.Contains("id_khuvuc"))
                {
                    sql = sql + string.Format(" and ma_khu_vuc = '{0}'", treeview_select.Remove(0, 10));
                }
                else
                {
                    sql = sql + string.Format(" and ma_phong_ban = '{0}'", treeview_select);
                }
            }
            DataTable dt = new DataTable();
            dt = SQLHelper.ExecuteDt(sql);
            dgv_danhsach_nhanvien.DataSource = dt;
        }
        private void xuatThuTuNgay()
        {
            DateTime thuA = DateTime.Now;
            thuA = dtp_tungay.Value;
            lb_thu_a.Text = DateTimeProgress.XuatThu((int)thuA.DayOfWeek);
            if (lb_thu_a.Text == "Chủ nhật")
            {
                lb_thu_a.ForeColor = Color.Red;
            }
            else
            {
                lb_thu_a.ForeColor = Color.Blue;
            }
        }
        private void xuatThuDenNgay()
        {
            DateTime thuB = DateTime.Now;
            thuB = dtp_denngay.Value;
            lb_thu_b.Text = DateTimeProgress.XuatThu((int)thuB.DayOfWeek);
            if (lb_thu_b.Text == "Chủ nhật")
            {
                lb_thu_b.ForeColor = Color.Red;
            }
            else
            {
                lb_thu_b.ForeColor = Color.Blue;
            }
        }
        private void ngayTinhCong()
        {
            System.Data.DataTable _dtLoadNgayTinhCong = new System.Data.DataTable();
            _dtLoadNgayTinhCong = _ngayTinhCongBLL.showThongTinNgayTinhCong();
            if (_dtLoadNgayTinhCong.Rows.Count == 0)
            {
                dtp_tungay.Text = DateTime.Now.ToString();
                dtp_denngay.Text = DateTime.Now.ToString();
                return;
            }
            //_ngayTinhCongDTO.ID = 1;
            _dtLoadNgayTinhCong = _ngayTinhCongBLL.showLoadNgayTinhCong(1);
            for (int i = 0; i < _dtLoadNgayTinhCong.Rows.Count; i++)
            {
                dtp_tungay.Text = _dtLoadNgayTinhCong.Rows[i]["NgayBatDau"].ToString();
                dtp_denngay.Text = _dtLoadNgayTinhCong.Rows[i]["NgayKetThuc"].ToString();
            }
        }
        private void loadControlTinhCong()
        {
            dgv_tinhcong.Columns[7].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            dgv_tinhcong.Columns[8].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            dgv_tinhcong.Columns[9].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            dgv_tinhcong.Columns[10].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            dgv_tinhcong.Columns[11].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            dgv_tinhcong.Columns[12].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            dgv_tinhcong.Columns[13].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            dgv_tinhcong.Columns[14].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            dgv_tinhcong.Columns[15].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            dgv_tinhcong.Columns[16].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            dgv_tinhcong.Columns[17].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            dgv_tinhcong.Columns[18].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
        }

        private void loadControlTinhLuong()
        {
            dgv_chitiet_luong.Columns[3].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            dgv_chitiet_luong.Columns[4].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            dgv_chitiet_luong.Columns[5].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            dgv_chitiet_luong.Columns[6].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            dgv_chitiet_luong.Columns[7].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            dgv_chitiet_luong.Columns[8].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            dgv_chitiet_luong.Columns[9].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            dgv_chitiet_luong.Columns[10].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            dgv_chitiet_luong.Columns[11].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            dgv_chitiet_luong.Columns[12].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            dgv_chitiet_luong.Columns[13].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            dgv_chitiet_luong.Columns[14].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            dgv_chitiet_luong.Columns[15].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            dgv_chitiet_luong.Columns[16].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            dgv_chitiet_luong.Columns[17].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            dgv_chitiet_luong.Columns[18].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            dgv_chitiet_luong.Columns[19].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            dgv_chitiet_luong.Columns[20].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            dgv_chitiet_luong.Columns[21].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            chk_cotinhluong.Checked = false;
            txt_ngaycong.Enabled = false;
        }

        private void loadTuyChon()
        {
            System.Data.DataTable dtLoadTuyChon = new System.Data.DataTable();
            //_tuyChonDTO.MaTuyChinh = "TC00001";
            dtLoadTuyChon = _tuyChonBLL.showLoadTuyChon("TC00001");
            for (int iLoadTuyChon = 0; iLoadTuyChon < dtLoadTuyChon.Rows.Count; iLoadTuyChon++)
            {
                iLamTronCong = Convert.ToInt32(dtLoadTuyChon.Rows[iLoadTuyChon]["lamtroncong"].ToString());
                iLamTronGio = Convert.ToInt32(dtLoadTuyChon.Rows[iLoadTuyChon]["lamtrongio"].ToString());
                sDinhDangThoiGian = dtLoadTuyChon.Rows[iLoadTuyChon]["dinhdang_thoigian"].ToString();
                dTangCa1HeSo = Convert.ToDouble(dtLoadTuyChon.Rows[iLoadTuyChon]["tc1_heso"].ToString());
                dTangCa2HeSo = Convert.ToDouble(dtLoadTuyChon.Rows[iLoadTuyChon]["tc2_heso"].ToString());
                dTangCa3HeSo = Convert.ToDouble(dtLoadTuyChon.Rows[iLoadTuyChon]["tc3_heso"].ToString());
                dTangCa4HeSo = Convert.ToDouble(dtLoadTuyChon.Rows[iLoadTuyChon]["tc4_heso"].ToString());
                sLuaChonKhaiBaoLuongBaoHiem = dtLoadTuyChon.Rows[iLoadTuyChon]["luachon_khaibaoluong"].ToString();
                dSoTienKhaiBao = Convert.ToDouble(dtLoadTuyChon.Rows[iLoadTuyChon]["sotien_khaibao"].ToString());
                dHeSoBaoHiemXaHoi = Convert.ToDouble(dtLoadTuyChon.Rows[iLoadTuyChon]["baohiem_xahoi"].ToString());
                dHeSoBaoHiemYTe = Convert.ToDouble(dtLoadTuyChon.Rows[iLoadTuyChon]["baohiem_yte"].ToString());
                dHeSoBaoHiemThatNghiep = Convert.ToDouble(dtLoadTuyChon.Rows[iLoadTuyChon]["baohiem_thatnghiep"].ToString());
            }
        }
        private void loadListViewBaoCao()
        {
            setListview(listViewBaoCao, "Chi tiết từng người từng ngày", 0, imageBaoCao);
            setListview(listViewBaoCao, "Chi tiết thời gian làm việc", 1, imageBaoCao);
            setListview(listViewBaoCao, "Tổng hợp", 2, imageBaoCao);
            setListview(listViewBaoCao, "Xuất lưới", 3, imageBaoCao);
            setListview(listViewBaoCao, "Thống kê tháng (ký hiệu)", 4, imageBaoCao);
            setListview(listViewBaoCao, "Thống kê tháng (công)", 5, imageBaoCao);
            setListview(listViewBaoCao, "Thống kê tháng (giờ)", 6, imageBaoCao);
            setListview(listViewBaoCao, "Tiền lương", 7, imageBaoCao);
            setListview(listViewBaoCao, "Bảng lương từng nhân viên", 8, imageBaoCao);
        }
        private static void setListview(ListView sListView, string sCaption, byte sIcon, ImageList sImageList)
        {
            sListView.Width = 250;
            sListView.LargeImageList = sImageList;
            sListView.SmallImageList = sImageList;
            sListView.Items.Add(new ListViewItem(sCaption, sIcon));
        }
        private void loadThongTinCongTy()
        {
            //System.Data.DataTable dtloadThongTinCongTy = new System.Data.DataTable();
            //_congTyDTO.MaCongTy = "CT00001";
            //dtloadThongTinCongTy = _congTyBLL.showLoadCongTy(_congTyDTO);
            //for (int iLoadThongTinCongTy = 0; iLoadThongTinCongTy < dtloadThongTinCongTy.Rows.Count; iLoadThongTinCongTy++)
            //{
            //    sTenCongTyReport = dtloadThongTinCongTy.Rows[iLoadThongTinCongTy]["TenCongTy"].ToString();
            //    sDiaChiCongTyReport = dtloadThongTinCongTy.Rows[iLoadThongTinCongTy]["DiaChi"].ToString();
            //}
            //System.Data.DataTable dtKyHieu = new System.Data.DataTable();
            //_kyHieuChamCongDTO.MaKyHieu = "KH00001";
            //dtKyHieu = _kyHieuChamCongBLL.showLoadKyHieuChamCong(_kyHieuChamCongDTO);
            //for (int _kyHieu = 0; _kyHieu < dtKyHieu.Rows.Count; _kyHieu++)
            //{
            //    sKHDiTre = dtKyHieu.Rows[_kyHieu]["DiTre"].ToString();
            //    sKHVeSom = dtKyHieu.Rows[_kyHieu]["VeSom"].ToString();
            //    sKHDungGio = dtKyHieu.Rows[_kyHieu]["DungGio"].ToString();
            //    sKHTangCa = dtKyHieu.Rows[_kyHieu]["TangCa"].ToString();
            //    sKHThieuGioVao = dtKyHieu.Rows[_kyHieu]["ThieuGioVao"].ToString();
            //    sKHThieuGioRa = dtKyHieu.Rows[_kyHieu]["ThieuGioRa"].ToString();
            //    sKHVang = dtKyHieu.Rows[_kyHieu]["Vang"].ToString();
            //    sKHChuaXepCa = dtKyHieu.Rows[_kyHieu]["ChuaXepCa"].ToString();
            //    sKHPhepNam = dtKyHieu.Rows[_kyHieu]["PhepNam"].ToString();
            //    sKHLe = dtKyHieu.Rows[_kyHieu]["Le"].ToString();
            //    sKHCongTac = dtKyHieu.Rows[_kyHieu]["CongTac"].ToString();
            //    sKHVeTre = dtKyHieu.Rows[_kyHieu]["VeTre"].ToString();
            //    sKHCuoiTuan = dtKyHieu.Rows[_kyHieu]["CuoiTuan"].ToString();
            //}
        }

        private void trv_sodoquanly_AfterSelect(object sender, TreeViewEventArgs e)
        {
            treeview_select = e.Node.Tag.ToString();
            load_nhanvien();
        }

        private void txt_tinkiem__TextChanged(object sender, EventArgs e)
        {
            load_nhanvien();
        }

        private void chk_cotinhluong_CheckedChanged(object sender, EventArgs e)
        {
            if (chk_cotinhluong.Checked)
            {
                txt_ngaycong.Enabled = true;
            }
            else
            {
                txt_ngaycong.Enabled = false;
            }
        }

        private void MenuChonTatCa_Click(object sender, EventArgs e)
        {
            bool _selectAllNhanVien = false;
            _selectAllNhanVien = !_selectAllNhanVien;
            if (_selectAllNhanVien)
            {
                for (int iNhanVienMoi = 0; iNhanVienMoi < dgv_danhsach_nhanvien.Rows.Count; iNhanVienMoi++)
                {
                    dgv_danhsach_nhanvien.Rows[iNhanVienMoi].Cells[0].Value = _selectAllNhanVien;
                }
            }
        }

        private void MenuBoChonTatCa_Click(object sender, EventArgs e)
        {
            bool _selectAllNhanVien = true;
            _selectAllNhanVien = !_selectAllNhanVien;
            if (!_selectAllNhanVien)
            {
                for (int iNhanVienMoi = 0; iNhanVienMoi < dgv_danhsach_nhanvien.Rows.Count; iNhanVienMoi++)
                {
                    dgv_danhsach_nhanvien.Rows[iNhanVienMoi].Cells[0].Value = _selectAllNhanVien;
                }
            }
        }

        private void dtp_tungay_ValueChanged(object sender, EventArgs e)
        {
            xuatThuTuNgay();
        }

        private void dtp_denngay_ValueChanged(object sender, EventArgs e)
        {
            xuatThuDenNgay();
        }

        private void dgv_sua_xoa_giocham_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            sMaChamCongSuaXoaGioCham = dgv_sua_xoa_giocham.CurrentRow.Cells[0].Value.ToString();
            sNgayChamSuaXoaGioCham = dgv_sua_xoa_giocham.CurrentRow.Cells[1].Value.ToString();
            sGioChamSuaXoaGioCham = dgv_sua_xoa_giocham.CurrentRow.Cells[2].Value.ToString();
            sKieuChamSuaXoaGioCham = dgv_sua_xoa_giocham.CurrentRow.Cells[3].Value.ToString();
            sMaSoMaySuaXoaGioCham = dgv_sua_xoa_giocham.CurrentRow.Cells[5].Value.ToString();
            sIDSuaXoaGioCham = dgv_sua_xoa_giocham.CurrentRow.Cells[7].Value.ToString();
        }

        private void listViewBaoCao_Click(object sender, EventArgs e)
        {
            //switch (listViewBaoCao.Items[listViewBaoCao.FocusedItem.Index].ImageIndex.ToString())
            //{
            //    case "0":
            //        ChiTietTungNguoiTungNgay_Click(sender, e);
            //        break;
            //    case "1":
            //        ChiTietThoiGianLamViec_Click(sender, e);
            //        break;
            //    case "2":
            //        TongHop_Click(sender, e);
            //        break;
            //    case "3":
            //        XuatLuoi_Click(sender, e);
            //        break;
            //    case "4":
            //        ThongKeThangKyHieu_Click(sender, e);
            //        break;
            //    case "5":
            //        ThongKeThangCong_Click(sender, e);
            //        break;
            //    case "6":
            //        ThongKeThangGio_Click(sender, e);
            //        break;
            //    case "7":
            //        TienLuong_Click(sender, e);
            //        break;
            //    case "8":
            //        BangLuongTungNhanVien_Click(sender, e);
            //        break;
            //}
        }
    }
}
