using System;
using System.Data;
using System.Net;
using System.Windows.Forms;
using TENTAC_HRM.Bll.MayChamCong;
using TENTAC_HRM.BLL.QuanLyNhanVienBLL;
using TENTAC_HRM.Common;
using TENTAC_HRM.Custom;
using TENTAC_HRM.Models.QuanLyNhanVienModel;
using zkemkeeper;

namespace TENTAC_HRM.Forms.MayChamCong
{
    public partial class uc_TaiNhanVienLenMayChamCong2 : UserControl
    {
        DataProvider provider = new DataProvider();
        private NhanVienBLL _nhanVienBLL = new NhanVienBLL();
        private KhuVucBLL _khuVucBLL = new KhuVucBLL();
        private KhuVucModel _khuVucDTO = new KhuVucModel();
        private NhanVienModel _nhanVienDTO = new NhanVienModel();
        private CongTyBLL _congTyBLL = new CongTyBLL();
        private CongTyModel _congTyDTO = new CongTyModel();
        private MayChamCongBLL _mayChamCongBLL = new MayChamCongBLL();
        private PhongBanBLL _phongBanBLL = new PhongBanBLL();
        private PhongBanModel _phongBanDTO = new PhongBanModel();
        private ChucVuModel _chucVuDTO = new ChucVuModel();
        private ChucVuBLL _chucVuBLL = new ChucVuBLL();
        public CZKEMClass axCZKEM1 = new CZKEMClass();

        private string sMaPhongBanTreeView;
        private string sMaCongTyTreeView;
        private string sMaKhuVucTreeView;
        private string sMaChucVuTreeView;
        private string _tenNode;
        public bool _bIsConnected;

        public int _iMachineNumber;

        private string sTenMay;

        private string sKieuKetNoi;

        private string sDiaChiIP;

        private string sPort;

        private string sDiaChiWeb;

        private string sSuDungWeb;

        private string sSerial;

        private string sSoDangKy;

        private string sTrangThai;

        private string sMaMCC;

        private string sIDMCC;

        private string sCongCom;

        private string sTocDoTruyen;

        private string sNgayDangKyTenMien;

        private int _kiemTraManHinh = 0;

        private string _loaiManHinh;

        private string _phienBanVanTay = "";

        private int iSoDuLieu;

        private string sdwSerialNumber;

        private int a;

        private int b;

        private int c;

        private int _ketQua;

        private string _a;

        private string _b;

        private string _c;

        private TemplateBLL _templateBLL = new TemplateBLL();

        public static uc_TaiNhanVienLenMayChamCong2 _instance;
        public static uc_TaiNhanVienLenMayChamCong2 Instance
        {
            get
            {
                //if (_instance == null)
                _instance = new uc_TaiNhanVienLenMayChamCong2();
                return _instance;
            }
        }
        public uc_TaiNhanVienLenMayChamCong2()
        {
            InitializeComponent();
        }
        private void phienBanVanTay()
        {
            if (!axCZKEM1.GetSysOption(1, "~ZKFPVersion", out _phienBanVanTay))
            {
            }
        }
        private void uc_TaiNhanVienLenMayChamCong2_Load(object sender, EventArgs e)
        {
            int demNhanVien = 0;
            load_treeview();
            dgv_MayChamCong.DataSource = _mayChamCongBLL.GETDANHSACHMCC();
            dgv_nhanvien.Columns.Insert(0, new DataGridViewCheckBoxColumn());
            dgv_MayChamCong.Columns.Insert(0, new DataGridViewCheckBoxColumn());
            dgv_nhanvien.Columns[0].Width = 30;
            dgv_MayChamCong.Columns[0].Width = 30;
            btn_ChonTatCa_Click(sender, e);
            chk_NguoiDung.Checked = true;
            DataTable dtNhanVien = new DataTable();
            dtNhanVien = _nhanVienBLL.TaiNhanVienLenMayChamCong();
            for (int iNhanVien = 0; iNhanVien < dtNhanVien.Rows.Count; iNhanVien++)
            {
                int addNhanVien = dgv_nhanvien.Rows.Add();
                dgv_nhanvien.Rows[addNhanVien].Cells[1].Value = dtNhanVien.Rows[iNhanVien]["MaNhanVien"].ToString();
                dgv_nhanvien.Rows[addNhanVien].Cells[2].Value = dtNhanVien.Rows[iNhanVien]["TenNhanVien"].ToString();
                dgv_nhanvien.Rows[addNhanVien].Cells[3].Value = dtNhanVien.Rows[iNhanVien]["MaChamCong"].ToString();
                dgv_nhanvien.Rows[addNhanVien].Cells[4].Value = dtNhanVien.Rows[iNhanVien]["TenChamCong"].ToString();
                dgv_nhanvien.Rows[addNhanVien].Cells[5].Value = dtNhanVien.Rows[iNhanVien]["MaThe"].ToString();
                demNhanVien++;
            }
        }
        private void kiemTraLoaiMay()
        {
            if (axCZKEM1.IsTFTMachine(_kiemTraManHinh))
            {
                _loaiManHinh = _kiemTraManHinh.ToString();
            }
            else
            {
                _loaiManHinh = "N/A";
            }
        }
        private void load_treeview()
        {
            DataTable dtCongTy = _congTyBLL.showThongTinCongTy(_congTyDTO);
            for (int i = 0; i < dtCongTy.Rows.Count; i++)
            {
                TreeNode treeCongTy = new TreeNode()
                {
                    Text = dtCongTy.Rows[i][1].ToString(),
                    Tag = dtCongTy.Rows[i][0].ToString()
                };
                trv_sodoquanly.Nodes.Add(treeCongTy);
                _khuVucDTO.MaCongTy = dtCongTy.Rows[i]["MaCongTy"].ToString();
                DataTable dtKhuVuc = _khuVucBLL.GETKHUVUCTREEVIEW(_khuVucDTO);
                for (int j = 0; j < dtKhuVuc.Rows.Count; j++)
                {
                    TreeNode treeKhuVuc = new TreeNode()
                    {
                        Text = dtKhuVuc.Rows[j][2].ToString(),
                        Tag = dtKhuVuc.Rows[j][0].ToString()
                    };
                    trv_sodoquanly.Nodes[i + 0].Nodes.Add(treeKhuVuc);
                    _phongBanDTO.MaKhuVuc = dtKhuVuc.Rows[j]["MaKhuVuc"].ToString();
                    DataTable dtPhongBan = _phongBanBLL.GETPHONGBANTREEVIEW(_phongBanDTO);

                    for (int z = 0; z < dtPhongBan.Rows.Count; z++)
                    {
                        TreeNode treePhongBan = new TreeNode()
                        {
                            Text = dtPhongBan.Rows[z][3].ToString(),
                            Tag = dtPhongBan.Rows[z][0].ToString()
                        };

                        trv_sodoquanly.Nodes[i + 0].Nodes[j].Nodes.Add(treePhongBan);
                        _chucVuDTO.MaPhongBan = dtPhongBan.Rows[z]["MaPhongBan"].ToString();
                        DataTable dtChucVu = _chucVuBLL.GETCHUCVUTREEVIEW(_chucVuDTO);
                        for (int v = 0; v < dtChucVu.Rows.Count; v++)
                        {
                            TreeNode treeChucVu = new TreeNode()
                            {
                                Text = dtChucVu.Rows[v][4].ToString(),
                                Tag = dtChucVu.Rows[v][0].ToString()
                            };

                            trv_sodoquanly.Nodes[i + 0].Nodes[j].Nodes[z].Nodes.Add(treeChucVu);
                            _chucVuDTO.MaChucVu = dtChucVu.Rows[v]["MaChucVu"].ToString();
                        }
                    }
                }
            }
        }

        private void btn_ChonTatCa_Click(object sender, EventArgs e)
        {
            bool _selectAll = false;
            _selectAll = !_selectAll;
            if (_selectAll)
            {
                for (int i = 0; i < dgv_nhanvien.Rows.Count; i++)
                {
                    dgv_nhanvien.Rows[i].Cells[0].Value = _selectAll;
                }
            }
        }

        private void btn_BoChonTatCa_Click(object sender, EventArgs e)
        {
            bool _selectAll = true;
            _selectAll = !_selectAll;
            if (!_selectAll)
            {
                for (int i = 0; i < dgv_nhanvien.Rows.Count; i++)
                {
                    dgv_nhanvien.Rows[i].Cells[0].Value = _selectAll;
                }
            }
        }

        private void btn_Loc_Click(object sender, EventArgs e)
        {
            dgv_nhanvien.Rows.Clear();
            DataTable dtSearch = new DataTable();
            _nhanVienDTO.MaNhanVien = txt_TimMa.Text;
            _nhanVienDTO.TenNhanVien = txt_TimMa.Text;
            dtSearch = _nhanVienBLL.NhanVienSearchTaiNhanVienLenMCC(_nhanVienDTO);
            for (int iSearch = 0; iSearch < dtSearch.Rows.Count; iSearch++)
            {
                int addSearch = dgv_nhanvien.Rows.Add();
                dgv_nhanvien.Rows[addSearch].Cells[1].Value = dtSearch.Rows[iSearch]["MaNhanVien"].ToString();
                dgv_nhanvien.Rows[addSearch].Cells[2].Value = dtSearch.Rows[iSearch]["TenNhanVien"].ToString();
                dgv_nhanvien.Rows[addSearch].Cells[3].Value = dtSearch.Rows[iSearch]["MaChamCong"].ToString();
                dgv_nhanvien.Rows[addSearch].Cells[4].Value = dtSearch.Rows[iSearch]["TenChamCong"].ToString();
                dgv_nhanvien.Rows[addSearch].Cells[5].Value = dtSearch.Rows[iSearch]["MaThe"].ToString();
            }
        }

        [Obsolete]
        private void btn_TaiLenMayChamCong_Click(object sender, EventArgs e)
        {
            for (int row = 0; row < dgv_MayChamCong.Rows.Count; row++)
            {
                if (!Convert.ToBoolean(dgv_MayChamCong[0, row].Value))
                {
                    continue;
                }
                sMaMCC = dgv_MayChamCong.Rows[row].Cells[1].Value.ToString();
                sTenMay = dgv_MayChamCong.Rows[row].Cells[2].Value.ToString();
                sIDMCC = dgv_MayChamCong.Rows[row].Cells[3].Value.ToString();
                sKieuKetNoi = dgv_MayChamCong.Rows[row].Cells[4].Value.ToString();
                sDiaChiIP = dgv_MayChamCong.Rows[row].Cells[5].Value.ToString();
                sPort = dgv_MayChamCong.Rows[row].Cells[6].Value.ToString();
                sCongCom = dgv_MayChamCong.Rows[row].Cells[7].Value.ToString();
                sTocDoTruyen = dgv_MayChamCong.Rows[row].Cells[8].Value.ToString();
                sDiaChiWeb = dgv_MayChamCong.Rows[row].Cells[9].Value.ToString();
                sNgayDangKyTenMien = dgv_MayChamCong.Rows[row].Cells[10].Value.ToString();
                sSuDungWeb = dgv_MayChamCong.Rows[row].Cells[11].Value.ToString();
                sSerial = dgv_MayChamCong.Rows[row].Cells[12].Value.ToString();
                sSoDangKy = dgv_MayChamCong.Rows[row].Cells[13].Value.ToString();
                if (sKieuKetNoi == "TCP/IP")
                {
                    if (sSuDungWeb == "False")
                    {
                        int idwErrorCode = 0;
                        Cursor = Cursors.WaitCursor;
                        _bIsConnected = axCZKEM1.Connect_Net(sDiaChiIP, Convert.ToInt32(sPort));
                        if (!_bIsConnected)
                        {
                            axCZKEM1.GetLastError(ref idwErrorCode);
                            listBoxThongBao.Items.Add("Không kết nối với " + sTenMay);
                            Application.DoEvents();
                            Cursor = Cursors.Default;
                        }
                        else
                        {
                            _iMachineNumber = 1;
                            axCZKEM1.RegEvent(_iMachineNumber, 65535);
                            sdwSerialNumber = "";
                            axCZKEM1.GetSerialNumber(_iMachineNumber, out sdwSerialNumber);
                            ActiveKey();
                            if (sSoDangKy == "" || sSoDangKy == null)
                            {
                                listBoxThongBao.Items.Add("Máy " + sTenMay + " chưa được đăng ký (" + DateTime.Now.ToLongTimeString() + ")");
                                axCZKEM1.Disconnect();
                                Cursor = Cursors.Default;
                                continue;
                            }
                            if (sSerial != "" && sSoDangKy != "")
                            {
                                if (sSerial != sdwSerialNumber)
                                {
                                    listBoxThongBao.Items.Add("Máy " + sTenMay + " chưa được đăng ký (" + DateTime.Now.ToLongTimeString() + ")");
                                    axCZKEM1.Disconnect();
                                    Cursor = Cursors.Default;
                                    continue;
                                }
                                if (sSoDangKy != _ketQua.ToString())
                                {
                                    listBoxThongBao.Items.Add("Máy " + sTenMay + " chưa được đăng ký (" + DateTime.Now.ToLongTimeString() + ")");
                                    axCZKEM1.Disconnect();
                                    Cursor = Cursors.Default;
                                    continue;
                                }
                            }
                            if (sTrangThai == "False")
                            {
                                listBoxThongBao.Items.Add("Máy " + sTenMay + " chưa được phép sử dụng (" + DateTime.Now.ToLongTimeString() + ")");
                                Cursor = Cursors.Default;
                                axCZKEM1.Disconnect();
                                break;
                            }
                            kiemTraLoaiMay();
                            phienBanVanTay();
                            listBoxThongBao.Items.Add("Đang tải dữ liệu lên: " + sTenMay + " (" + DateTime.Now.ToLongTimeString() + ")");
                            uploadNhanVien();
                            Cursor = Cursors.Default;
                            axCZKEM1.Disconnect();
                        }
                    }
                    else
                    {
                        IPHostEntry hostname = Dns.GetHostByName(sDiaChiWeb);
                        IPAddress[] ip = hostname.AddressList;
                        string _IpWeb = ip[0].ToString();
                        Cursor = Cursors.WaitCursor;
                        _bIsConnected = axCZKEM1.Connect_Net(_IpWeb, Convert.ToInt32(sPort));
                        if (!_bIsConnected)
                        {
                            listBoxThongBao.Items.Add("Không kết nối với " + sTenMay);
                            Application.DoEvents();
                            Cursor = Cursors.Default;
                        }
                        else
                        {
                            _iMachineNumber = 1;
                            axCZKEM1.RegEvent(_iMachineNumber, 65535);
                            sdwSerialNumber = "";
                            axCZKEM1.GetSerialNumber(_iMachineNumber, out sdwSerialNumber);
                            ActiveKey();
                            if (sSoDangKy == "" || sSoDangKy == null)
                            {
                                listBoxThongBao.Items.Add("Máy " + sTenMay + " chưa được đăng ký (" + DateTime.Now.ToLongTimeString() + ")");
                                axCZKEM1.Disconnect();
                                Cursor = Cursors.Default;
                                continue;
                            }
                            if (sSerial != "" && sSoDangKy != "")
                            {
                                if (sSerial != sdwSerialNumber)
                                {
                                    listBoxThongBao.Items.Add("Máy " + sTenMay + " chưa được đăng ký (" + DateTime.Now.ToLongTimeString() + ")");
                                    axCZKEM1.Disconnect();
                                    Cursor = Cursors.Default;
                                    continue;
                                }
                                if (sSoDangKy != _ketQua.ToString())
                                {
                                    listBoxThongBao.Items.Add("Máy " + sTenMay + " chưa được đăng ký (" + DateTime.Now.ToLongTimeString() + ")");
                                    axCZKEM1.Disconnect();
                                    Cursor = Cursors.Default;
                                    continue;
                                }
                            }
                            if (sTrangThai == "False")
                            {
                                listBoxThongBao.Items.Add("Máy " + sTenMay + " chưa được phép sử dụng (" + DateTime.Now.ToLongTimeString() + ")");
                                Cursor = Cursors.Default;
                                axCZKEM1.Disconnect();
                                break;
                            }
                            kiemTraLoaiMay();
                            phienBanVanTay();
                            listBoxThongBao.Items.Add("Đang tải dữ liệu lên: " + sTenMay + " (" + DateTime.Now.ToLongTimeString() + ")");
                            uploadNhanVien();
                            Cursor = Cursors.Default;
                            axCZKEM1.Disconnect();
                        }
                    }
                }
                if (sKieuKetNoi == "RS232/484")
                {
                    RJMessageBox.Show("Chưa phát triển cổng COM");
                }
                if (sKieuKetNoi == "USB")
                {
                    _iMachineNumber = 1;
                    Cursor = Cursors.WaitCursor;
                    _bIsConnected = axCZKEM1.Connect_USB(_iMachineNumber);
                    if (!_bIsConnected)
                    {
                        listBoxThongBao.Items.Add("Không kết nối với " + sTenMay);
                        Application.DoEvents();
                        Cursor = Cursors.Default;
                        continue;
                    }
                    axCZKEM1.RegEvent(_iMachineNumber, 65535);
                    kiemTraLoaiMay();
                    phienBanVanTay();
                    uploadNhanVien();
                    Cursor = Cursors.Default;
                    axCZKEM1.Disconnect();
                }
            }
        }

        private void ActiveKey()
        {
            _a = sdwSerialNumber.Substring(0, 2);
            int i = sdwSerialNumber.Length - 4;
            _b = sdwSerialNumber.Substring(i);
            int j = sdwSerialNumber.Length - 2;
            _c = sdwSerialNumber.Substring(j);
            a = Convert.ToInt32(_a);
            b = Convert.ToInt32(_b);
            c = Convert.ToInt32(_c);
            _ketQua = a + b + c + 240789 - c;
        }

        private void uploadNhanVien()
        {
            iSoDuLieu = dgv_NhanVienTaiLenMayChamCong.RowCount;
            int dem = -1;
            int test = iSoDuLieu;
            int idwErrorCode = 0;
            string sdwEnrollNumber = "";
            string sName = "";
            int idwFingerIndex = 0;
            string sTmpData = "";
            int iPrivilege = 0;
            string sPassword = "";
            int iFlag = 0;
            string sEnabled = "";
            bool bEnabled = false;
            int demVT = 0;
            int demKM = 0;
            int demNV = 0;
            Cursor = Cursors.WaitCursor;
            axCZKEM1.EnableDevice(_iMachineNumber, bFlag: false);
            for (int i = 0; i < dgv_NhanVienTaiLenMayChamCong.Rows.Count; i++)
            {
                Application.DoEvents();
                DataTable _selectVanTay = new DataTable();
                _selectVanTay = _templateBLL.SelectTemplateByMaChamCongUpToDevice(Convert.ToInt32(dgv_NhanVienTaiLenMayChamCong.Rows[i].Cells[2].Value.ToString()));
                sdwEnrollNumber = dgv_NhanVienTaiLenMayChamCong.Rows[i].Cells[2].Value.ToString();
                if (chk_NguoiDung.Checked)
                {
                    sdwEnrollNumber = dgv_NhanVienTaiLenMayChamCong.Rows[i].Cells[2].Value.ToString();
                    sName = dgv_NhanVienTaiLenMayChamCong.Rows[i].Cells[3].Value.ToString();
                    string sCardnumber = dgv_NhanVienTaiLenMayChamCong.Rows[i].Cells[4].Value.ToString();
                    sPassword = dgv_NhanVienTaiLenMayChamCong.Rows[i].Cells[5].Value.ToString();
                    iPrivilege = Convert.ToInt32(dgv_NhanVienTaiLenMayChamCong.Rows[i].Cells[6].Value.ToString());
                    sEnabled = dgv_NhanVienTaiLenMayChamCong.Rows[i].Cells[7].Value.ToString();
                    bEnabled = ((sEnabled == "True") ? true : false);
                    axCZKEM1.SetStrCardNumber(sCardnumber);
                    if (!axCZKEM1.SSR_SetUserInfo(_iMachineNumber, sdwEnrollNumber, sName, sPassword, iPrivilege, bEnabled))
                    {
                        axCZKEM1.GetLastError(ref idwErrorCode);
                        RJMessageBox.Show("Operation failed,ErrorCode=" + idwErrorCode, "Error");
                        Cursor = Cursors.Default;
                        axCZKEM1.EnableDevice(_iMachineNumber, bFlag: true);
                        return;
                    }
                    axCZKEM1.SetUserTmpExStr(_iMachineNumber, sdwEnrollNumber, idwFingerIndex, iFlag, sTmpData);
                }
                if (chk_VanTay.Checked)
                {
                    for (int vt = 0; vt < _selectVanTay.Rows.Count; vt++)
                    {
                        string tMaChamCong = _selectVanTay.Rows[vt]["ma_cham_cong"].ToString();
                        idwFingerIndex = Convert.ToInt32(_selectVanTay.Rows[vt]["finger_id"].ToString());
                        iFlag = Convert.ToInt32(_selectVanTay.Rows[vt]["flag"].ToString());
                        sTmpData = _selectVanTay.Rows[vt]["finger_template"].ToString();
                        string tFingerVersion = _selectVanTay.Rows[vt]["finger_version"].ToString();
                        sName = dgv_NhanVienTaiLenMayChamCong.Rows[i].Cells[3].Value.ToString();
                        string sCardnumber = dgv_NhanVienTaiLenMayChamCong.Rows[i].Cells[4].Value.ToString();
                        sPassword = dgv_NhanVienTaiLenMayChamCong.Rows[i].Cells[5].Value.ToString();
                        iPrivilege = Convert.ToInt32(dgv_NhanVienTaiLenMayChamCong.Rows[i].Cells[6].Value.ToString());
                        sEnabled = dgv_NhanVienTaiLenMayChamCong.Rows[i].Cells[7].Value.ToString();
                        bEnabled = ((sEnabled == "True") ? true : false);
                        axCZKEM1.SetStrCardNumber(sCardnumber);
                        if (axCZKEM1.SSR_SetUserInfo(_iMachineNumber, sdwEnrollNumber, sName, sPassword, iPrivilege, bEnabled))
                        {
                            axCZKEM1.SetUserTmpExStr(_iMachineNumber, sdwEnrollNumber, idwFingerIndex, iFlag, sTmpData);
                            demVT++;
                            continue;
                        }
                        axCZKEM1.GetLastError(ref idwErrorCode);
                        RJMessageBox.Show("Operation failed,ErrorCode=" + idwErrorCode, "Error");
                        Cursor = Cursors.Default;
                        axCZKEM1.EnableDevice(_iMachineNumber, bFlag: true);
                        return;
                    }
                }
                demNV++;
                if (chk_KhuonMat.Checked)
                {
                }
                progressBar1.Maximum = iSoDuLieu;
                test--;
                dem++;
                progressBar1.Text = (dem + 1) * 100 / iSoDuLieu + "%";
                if (iSoDuLieu < 0)
                {
                }
                if (iSoDuLieu >= 0)
                {
                    progressBar1.Value = iSoDuLieu - test;
                }
            }
            axCZKEM1.RefreshData(_iMachineNumber);
            Cursor = Cursors.Default;
            axCZKEM1.EnableDevice(_iMachineNumber, bFlag: true);
        }

        private void txt_TimMa_TextChanged(object sender, EventArgs e)
        {
            int demNhanVien = 0;
            dgv_nhanvien.Rows.Clear();
            DataTable dtSearch = new DataTable();
            _nhanVienDTO.MaNhanVien = txt_TimMa.Texts;
            _nhanVienDTO.TenNhanVien = txt_TimMa.Texts;
            dtSearch = _nhanVienBLL.NhanVienSearchTaiNhanVienLenMCC(_nhanVienDTO);
            for (int iSearch = 0; iSearch < dtSearch.Rows.Count; iSearch++)
            {
                int addSearch = dgv_nhanvien.Rows.Add();
                dgv_nhanvien.Rows[addSearch].Cells[1].Value = dtSearch.Rows[iSearch]["MaNhanVien"].ToString();
                dgv_nhanvien.Rows[addSearch].Cells[2].Value = dtSearch.Rows[iSearch]["TenNhanVien"].ToString();
                dgv_nhanvien.Rows[addSearch].Cells[3].Value = dtSearch.Rows[iSearch]["MaChamCong"].ToString();
                dgv_nhanvien.Rows[addSearch].Cells[4].Value = dtSearch.Rows[iSearch]["TenChamCong"].ToString();
                dgv_nhanvien.Rows[addSearch].Cells[5].Value = dtSearch.Rows[iSearch]["MaThe"].ToString();
                demNhanVien++;
            }
        }

        private void trv_sodoquanly_AfterSelect(object sender, TreeViewEventArgs e)
        {
            sMaCongTyTreeView = "";
            sMaKhuVucTreeView = "";
            sMaPhongBanTreeView = "";
            sMaChucVuTreeView = "";
            dgv_nhanvien.Rows.Clear();
            _tenNode = trv_sodoquanly.SelectedNode.Text;
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
                int addNhanVien = dgv_nhanvien.Rows.Add();
                dgv_nhanvien.Rows[addNhanVien].Cells[1].Value = dtNhanVien.Rows[iNhanVien]["MaNhanVien"].ToString();
                dgv_nhanvien.Rows[addNhanVien].Cells[2].Value = dtNhanVien.Rows[iNhanVien]["TenNhanVien"].ToString();
                dgv_nhanvien.Rows[addNhanVien].Cells[3].Value = dtNhanVien.Rows[iNhanVien]["MaChamCong"].ToString();
                dgv_nhanvien.Rows[addNhanVien].Cells[4].Value = dtNhanVien.Rows[iNhanVien]["MaPhongBan"].ToString();
            }
        }

        private void btnChuyenXuong_Click(object sender, EventArgs e)
        {
            DataGridView _chuyenXuong = new DataGridView();
            for (int row = 0; row < dgv_nhanvien.Rows.Count; row++)
            {
                if (!Convert.ToBoolean(dgv_nhanvien[0, row].Value))
                {
                    continue;
                }
                int demKiemTra = 0;
                string sMaNhanVienChon = dgv_nhanvien.Rows[row].Cells[1].Value.ToString();
                for (int iKiemTraTonTai = 0; iKiemTraTonTai < dgv_NhanVienTaiLenMayChamCong.Rows.Count; iKiemTraTonTai++)
                {
                    string sMaNhanVienChuyenXuong = dgv_NhanVienTaiLenMayChamCong.Rows[iKiemTraTonTai].Cells[0].Value.ToString();
                    if (sMaNhanVienChuyenXuong == sMaNhanVienChon)
                    {
                        demKiemTra++;
                        break;
                    }
                }
                if (demKiemTra != 1)
                {
                    int addChuyenXuong = dgv_NhanVienTaiLenMayChamCong.Rows.Add();
                    dgv_NhanVienTaiLenMayChamCong.Rows[addChuyenXuong].Cells[0].Value = dgv_nhanvien.Rows[row].Cells[1].Value.ToString();
                    dgv_NhanVienTaiLenMayChamCong.Rows[addChuyenXuong].Cells[1].Value = dgv_nhanvien.Rows[row].Cells[2].Value.ToString();
                    dgv_NhanVienTaiLenMayChamCong.Rows[addChuyenXuong].Cells[2].Value = dgv_nhanvien.Rows[row].Cells[3].Value.ToString();
                    dgv_NhanVienTaiLenMayChamCong.Rows[addChuyenXuong].Cells[3].Value = dgv_nhanvien.Rows[row].Cells[4].Value.ToString();
                    dgv_NhanVienTaiLenMayChamCong.Rows[addChuyenXuong].Cells[4].Value = dgv_nhanvien.Rows[row].Cells[5].Value.ToString();
                }
            }
            groupBoxNhanVienTaiLenMay.Text = "Nhân viên tải lên máy: " + dgv_NhanVienTaiLenMayChamCong.Rows.Count + " nhân viên";
        }

        private void btnLoaiBo_Click(object sender, EventArgs e)
        {
            if (dgv_NhanVienTaiLenMayChamCong.Rows.Count != 0)
            {
                int RowIndex = dgv_NhanVienTaiLenMayChamCong.CurrentRow.Index;
                dgv_NhanVienTaiLenMayChamCong.Rows.RemoveAt(RowIndex);
            }
        }

        private void btnLoaiBoTatCa_Click(object sender, EventArgs e)
        {
            dgv_NhanVienTaiLenMayChamCong.Rows.Clear();
        }

        private void btn_close_Click(object sender, EventArgs e)
        {
            provider.btn_close(this.Parent);
        }
    }
}
