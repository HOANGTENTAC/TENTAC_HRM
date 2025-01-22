using System;
using System.Data;
using System.Net;
using System.Windows.Forms;
using TENTAC_HRM.BLL.QuanLyNhanVienBLL;
using TENTAC_HRM.Common;
using TENTAC_HRM.Models;
using TENTAC_HRM.Models.QuanLyNhanVienModel;
using zkemkeeper;

namespace TENTAC_HRM.Forms.MayChamCong
{
    public partial class uc_TaiNhanVienLenMayChamCong : UserControl
    {
        private CongTyModel _congTyDTO;

        private CongTyBLL _congTyBLL;

        private KhuVucBLL _khuVucBLL;

        private KhuVucModel _khuVucDTO;

        private PhongBanBLL _phongBanBLL;

        private PhongBanModel _phongBanDTO;

        private ChucVuModel _chucVuDTO;

        private ChucVuBLL _chucVuBLL;

        private NhanVienModel _nhanVienDTO;

        private NhanVienBLL _nhanVienBLL;

        public CZKEMClass axCZKEM1 = new CZKEMClass();

        public bool _bIsConnected;

        public int _iMachineNumber;

        public string _KieuKetNoi;

        public string _DiaChiIP;

        public string _Port;

        public string _DiaChiWeb;

        public string _SuDungWeb;

        public string _TenMay;

        public string _Serial;

        public string _SoDangKy;

        private bool _selectAll;

        private int _kiemTraManHinh;

        private string _loaiManHinh;

        private string _phienBanVanTay = "";

        private TemplateBLL _templateBLL = new TemplateBLL();

        private TemplateModel _templateDTO = new TemplateModel();
        public uc_TaiNhanVienLenMayChamCong()
        {
            this._congTyDTO = new CongTyModel();
            this._congTyBLL = new CongTyBLL();
            this._khuVucBLL = new KhuVucBLL();
            this._khuVucDTO = new KhuVucModel();
            this._phongBanBLL = new PhongBanBLL();
            this._phongBanDTO = new PhongBanModel();
            this._chucVuBLL = new ChucVuBLL();
            this._chucVuDTO = new ChucVuModel();
            this._nhanVienBLL = new NhanVienBLL();
            this._khuVucDTO = new KhuVucModel();
            InitializeComponent();
        }

        private void uc_TaiNhanVienLenMayChamCong_Load(object sender, EventArgs e)
        {
            this.loadTreeView();
            this.DGVNhanVien.DataSource = this._nhanVienBLL.TaiNhanVienLenMCC();
            this.DGVNhanVien.Columns.Insert(0, new DataGridViewCheckBoxColumn());
            for (int ts = 0; ts <= this.DGVNhanVien.Rows.Count; ts++)
            {
                this.lbTongSoNhanVien.Text = "Tổng số nhân viên: " + ts;
            }
            this.btnChuyenXuongNhanVien.Enabled = false;
        }
        private void loadTreeView()
        {
            DataTable dtCongTy;
            dtCongTy = this._congTyBLL.showThongTinCongTy(this._congTyDTO);
            for (int i = 0; i < dtCongTy.Rows.Count; i++)
            {
                TreeNode treeCongTy;
                treeCongTy = new TreeNode();
                treeCongTy.Text = dtCongTy.Rows[i][1].ToString();
                treeCongTy.Tag = dtCongTy.Rows[i][0].ToString();
                this.treeViewSoDoQuanLy.Nodes.Add(treeCongTy);
                this._khuVucDTO.MaCongTy = dtCongTy.Rows[i]["MaCongTy"].ToString();
                DataTable dtKhuVuc;
                dtKhuVuc = this._khuVucBLL.GETKHUVUCTREEVIEW(this._khuVucDTO);
                for (int j = 0; j < dtKhuVuc.Rows.Count; j++)
                {
                    TreeNode treeKhuVuc;
                    treeKhuVuc = new TreeNode();
                    treeKhuVuc.Text = dtKhuVuc.Rows[j][2].ToString();
                    treeKhuVuc.Tag = dtKhuVuc.Rows[j][0].ToString();
                    this.treeViewSoDoQuanLy.Nodes[i + 2].Nodes.Add(treeKhuVuc);
                    this._phongBanDTO.MaKhuVuc = dtKhuVuc.Rows[j]["MaKhuVuc"].ToString();
                    DataTable dtPhongBan;
                    dtPhongBan = this._phongBanBLL.GETPHONGBANTREEVIEW(this._phongBanDTO);
                    for (int z = 0; z < dtPhongBan.Rows.Count; z++)
                    {
                        TreeNode treePhongBan;
                        treePhongBan = new TreeNode();
                        treePhongBan.Text = dtPhongBan.Rows[z][3].ToString();
                        treePhongBan.Tag = dtPhongBan.Rows[z][0].ToString();
                        this.treeViewSoDoQuanLy.Nodes[i + 2].Nodes[j].Nodes.Add(treePhongBan);
                        this._chucVuDTO.MaPhongBan = dtPhongBan.Rows[z]["MaPhongBan"].ToString();
                        DataTable dtChucVu;
                        dtChucVu = this._chucVuBLL.GETCHUCVUTREEVIEW(this._chucVuDTO);
                        for (int v = 0; v < dtChucVu.Rows.Count; v++)
                        {
                            TreeNode treeChucVu;
                            treeChucVu = new TreeNode();
                            treeChucVu.Text = dtChucVu.Rows[v][4].ToString();
                            treeChucVu.Tag = dtChucVu.Rows[v][0].ToString();
                            this.treeViewSoDoQuanLy.Nodes[i + 2].Nodes[j].Nodes[z].Nodes.Add(treeChucVu);
                            this._chucVuDTO.MaChucVu = dtChucVu.Rows[v]["MaChucVu"].ToString();
                        }
                    }
                }
            }
        }

        private void DGVNhanVien_CellPainting(object sender, DataGridViewCellPaintingEventArgs e)
        {
        }

        private void DGVNhanVien_ColumnHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
        }

        private void btnLoaiBoNhanVien_Click(object sender, EventArgs e)
        {
            int RowIndex;
            RowIndex = this.DGVNhanVienTaiLenMCC.CurrentRow.Index;
            this.DGVNhanVienTaiLenMCC.Rows.RemoveAt(RowIndex);
            for (int _nhanVienTaiLenMay = 0; _nhanVienTaiLenMay <= this.DGVNhanVienTaiLenMCC.Rows.Count; _nhanVienTaiLenMay++)
            {
                this.lbTongSoNhanVienTaiLenMay.Text = "Tổng số nhân viên: " + _nhanVienTaiLenMay;
            }
        }

        private void btnChonTatCaNhanVien_Click(object sender, EventArgs e)
        {
            this._selectAll = !this._selectAll;
            for (int i = 0; i < this.DGVNhanVien.Rows.Count; i++)
            {
                this.DGVNhanVien.Rows[i].Cells[0].Value = this._selectAll;
            }
            if (this._selectAll)
            {
                this.btnChuyenXuongNhanVien.Enabled = true;
            }
            else
            {
                this.btnChuyenXuongNhanVien.Enabled = false;
            }
        }

        private void btnChuyenXuongNhanVien_Click(object sender, EventArgs e)
        {
            new DataGridView();
            for (int row = 0; row < this.DGVNhanVien.Rows.Count; row++)
            {
                if (Convert.ToBoolean(this.DGVNhanVien[0, row].Value))
                {
                    string sChonTatCa;
                    sChonTatCa = row.ToString();
                    string sMaNhanVien;
                    sMaNhanVien = this.DGVNhanVien.Rows[row].Cells[1].Value.ToString();
                    string sTenNhanVien;
                    sTenNhanVien = this.DGVNhanVien.Rows[row].Cells[2].Value.ToString();
                    string sMaChamCong;
                    sMaChamCong = this.DGVNhanVien.Rows[row].Cells[3].Value.ToString();
                    string sTenChamCong;
                    sTenChamCong = this.DGVNhanVien.Rows[row].Cells[4].Value.ToString();
                    string sMaThe;
                    sMaThe = this.DGVNhanVien.Rows[row].Cells[5].Value.ToString();
                    string sChoPhep;
                    sChoPhep = this.DGVNhanVien.Rows[row].Cells[6].Value.ToString();
                    string sPhanQuyen;
                    sPhanQuyen = this.DGVNhanVien.Rows[row].Cells[7].Value.ToString();
                    string sMatKhau;
                    sMatKhau = this.DGVNhanVien.Rows[row].Cells[8].Value.ToString();
                    string sEnable;
                    sEnable = this.DGVNhanVien.Rows[row].Cells[9].Value.ToString();
                    int i;
                    i = this.DGVNhanVienTaiLenMCC.Rows.Add();
                    this.DGVNhanVienTaiLenMCC.Rows[i].Cells[0].Value = sChonTatCa;
                    this.DGVNhanVienTaiLenMCC.Rows[i].Cells[1].Value = sMaNhanVien;
                    this.DGVNhanVienTaiLenMCC.Rows[i].Cells[2].Value = sTenNhanVien;
                    this.DGVNhanVienTaiLenMCC.Rows[i].Cells[3].Value = sMaChamCong;
                    this.DGVNhanVienTaiLenMCC.Rows[i].Cells[4].Value = sTenChamCong;
                    this.DGVNhanVienTaiLenMCC.Rows[i].Cells[5].Value = sMaThe;
                    this.DGVNhanVienTaiLenMCC.Rows[i].Cells[6].Value = sChoPhep;
                    this.DGVNhanVienTaiLenMCC.Rows[i].Cells[7].Value = sPhanQuyen;
                    this.DGVNhanVienTaiLenMCC.Rows[i].Cells[8].Value = sMatKhau;
                    this.DGVNhanVienTaiLenMCC.Rows[i].Cells[9].Value = sEnable;
                    for (int _nhanVienTaiLenMay = 0; _nhanVienTaiLenMay <= this.DGVNhanVienTaiLenMCC.Rows.Count; _nhanVienTaiLenMay++)
                    {
                        this.lbTongSoNhanVienTaiLenMay.Text = "Tổng số nhân viên: " + _nhanVienTaiLenMay;
                    }
                }
            }
        }

        private void btnLoaiBoTatCaNhanVien_Click(object sender, EventArgs e)
        {
            this.DGVNhanVienTaiLenMCC.Rows.Clear();
        }

        private void btnTaiNhanVienLenMayChamCong_Click(object sender, EventArgs e)
        {
            if (this._KieuKetNoi == "TCP/IP")
            {
                if (this._SuDungWeb == "False")
                {
                    this.Cursor = Cursors.WaitCursor;
                    this._bIsConnected = this.axCZKEM1.Connect_Net(this._DiaChiIP, Convert.ToInt32(this._Port));
                    this.kiemTraLoaiMay();
                    this.phienBanVanTay();
                    this.taiNhanVienLenMayChamCong();
                    this.Cursor = Cursors.Default;
                }
                else
                {
                    string _IpWeb;
                    _IpWeb = Dns.GetHostByName(this._DiaChiWeb).AddressList[0].ToString();
                    this.Cursor = Cursors.WaitCursor;
                    this._bIsConnected = this.axCZKEM1.Connect_Net(_IpWeb, Convert.ToInt32(this._Port));
                    this.kiemTraLoaiMay();
                    this.phienBanVanTay();
                    this.Cursor = Cursors.Default;
                }
            }
            if (this._KieuKetNoi == "RS232/484")
            {
                MessageBox.Show("Chưa phát triển cổng COM");
            }
            if (this._KieuKetNoi == "USB")
            {
                this._iMachineNumber = 1;
                this.Cursor = Cursors.WaitCursor;
                this._bIsConnected = this.axCZKEM1.Connect_USB(this._iMachineNumber);
                if (this._bIsConnected)
                {
                    this.axCZKEM1.RegEvent(this._iMachineNumber, 65535);
                }
                this.kiemTraLoaiMay();
                this.phienBanVanTay();
                this.Cursor = Cursors.Default;
            }
        }

        private void taiNhanVienLenMayChamCong()
        {
            if (this._loaiManHinh == "0")
            {
                int idwErrorCode;
                idwErrorCode = 0;
                int iPrivilege;
                iPrivilege = 0;
                bool bEnabled;
                bEnabled = false;
                int iFlag;
                iFlag = 1;
                int iUpdateFlag;
                iUpdateFlag = 1;
                this.axCZKEM1.EnableDevice(this._iMachineNumber, bFlag: false);
                this.Cursor = Cursors.WaitCursor;
                if (this.axCZKEM1.BeginBatchUpdate(this._iMachineNumber, iUpdateFlag))
                {
                    string sLastEnrollNumber;
                    sLastEnrollNumber = "";
                    for (int i = 0; i < this.DGVNhanVienTaiLenMCC.Rows.Count; i++)
                    {
                        string sMaChamCong;
                        sMaChamCong = this.DGVNhanVienTaiLenMCC.Rows[i].Cells[3].Value.ToString();
                        string sName;
                        sName = this.DGVNhanVienTaiLenMCC.Rows[i].Cells[4].Value.ToString();
                        string sPassword;
                        sPassword = this.DGVNhanVienTaiLenMCC.Rows[i].Cells[8].Value.ToString();
                        this.DGVNhanVienTaiLenMCC.Rows[i].Cells[9].Value.ToString();
                        this._templateDTO.MaChamCong = Convert.ToInt32(sMaChamCong);
                        new DataTable();
                        DataTable dtVanTay;
                        dtVanTay = this._nhanVienBLL.getTemplateNhanVien(Convert.ToInt32(sMaChamCong));
                        for (int t = 0; t < dtVanTay.Rows.Count; t++)
                        {
                            string sdwEnrollNumber;
                            sdwEnrollNumber = dtVanTay.Rows[t]["MaChamCong"].ToString();
                            int idwFingerIndex;
                            idwFingerIndex = Convert.ToInt32(dtVanTay.Rows[t]["FingerID"].ToString());
                            string sTmpData;
                            sTmpData = dtVanTay.Rows[t]["FingerTemplate"].ToString();
                            if (sdwEnrollNumber != sLastEnrollNumber)
                            {
                                if (!this.axCZKEM1.SSR_SetUserInfo(this._iMachineNumber, sdwEnrollNumber, sName, sPassword, iPrivilege, bEnabled))
                                {
                                    this.axCZKEM1.GetLastError(ref idwErrorCode);
                                    MessageBox.Show("Operation failed,ErrorCode=" + idwErrorCode, "Error");
                                    this.Cursor = Cursors.Default;
                                    this.axCZKEM1.EnableDevice(this._iMachineNumber, bFlag: true);
                                    return;
                                }
                                this.axCZKEM1.SetUserTmpExStr(this._iMachineNumber, sdwEnrollNumber, idwFingerIndex, iFlag, sTmpData);
                            }
                            else
                            {
                                this.axCZKEM1.SetUserTmpExStr(this._iMachineNumber, sdwEnrollNumber, idwFingerIndex, iFlag, sTmpData);
                            }
                            sLastEnrollNumber = sdwEnrollNumber;
                        }
                        this.lbThongTinTaiNhanVien.Text = "Tổng số nhân viên vừa tải: " + i + 1;
                    }
                }
                this.axCZKEM1.BatchUpdate(this._iMachineNumber);
                this.axCZKEM1.RefreshData(this._iMachineNumber);
                this.Cursor = Cursors.Default;
                this.axCZKEM1.EnableDevice(this._iMachineNumber, bFlag: true);
            }
            else
            {
                MessageBox.Show("Màn hình trắng đen");
            }
        }

        private void kiemTraLoaiMay()
        {
            if (this.axCZKEM1.IsTFTMachine(this._kiemTraManHinh))
            {
                this._loaiManHinh = this._kiemTraManHinh.ToString();
            }
            else
            {
                this._loaiManHinh = "N/A";
            }
        }

        private void phienBanVanTay()
        {
            this.axCZKEM1.GetSysOption(1, "~ZKFPVersion", out this._phienBanVanTay);
        }

        private void buttonX1_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < this.DGVNhanVienTaiLenMCC.Rows.Count; i++)
            {
                string sMaChamCong;
                sMaChamCong = this.DGVNhanVienTaiLenMCC.Rows[i].Cells[3].Value.ToString();
                this._templateDTO.MaChamCong = Convert.ToInt32(sMaChamCong);
                new DataTable();
                DataTable dtVanTay;
                dtVanTay = this._nhanVienBLL.getTemplateNhanVien(Convert.ToInt32(sMaChamCong));
                for (int t = 0; t < dtVanTay.Rows.Count; t++)
                {
                    dtVanTay.Rows[t]["MaChamCong"].ToString();
                    dtVanTay.Rows[t]["FingerID"].ToString();
                    dtVanTay.Rows[t]["FingerTemplate"].ToString();
                }
            }
        }

        private void buttonX2_Click(object sender, EventArgs e)
        {
        }
    }
}
