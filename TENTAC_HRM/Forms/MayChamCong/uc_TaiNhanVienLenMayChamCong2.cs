using System;
using System.Data;
using System.Net;
using System.Windows.Forms;
using TENTAC_HRM.BusinessLogicLayer.MayChamCong;
using TENTAC_HRM.BusinessLogicLayer.QuanLyNhanVienBLL;
using TENTAC_HRM.Common;
using TENTAC_HRM.Custom;
using TENTAC_HRM.Model;
using zkemkeeper;

namespace TENTAC_HRM.Forms.MayChamCong
{
    public partial class uc_TaiNhanVienLenMayChamCong2 : UserControl
    {
        DataProvider provider = new DataProvider();
        private NhanVienBLL _nhanVienBLL = new NhanVienBLL();

        private Nhanvien_model _nhanVienDTO = new Nhanvien_model();

        private MayChamCongBLL _mayChamCongBLL = new MayChamCongBLL();

        public CZKEMClass axCZKEM1 = new CZKEMClass();

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
                dgv_nhanvien.Rows[addNhanVien].Cells[1].Value = dtNhanVien.Rows[iNhanVien]["ma_nhan_vien"].ToString();
                dgv_nhanvien.Rows[addNhanVien].Cells[2].Value = dtNhanVien.Rows[iNhanVien]["ho_ten"].ToString();
                dgv_nhanvien.Rows[addNhanVien].Cells[3].Value = dtNhanVien.Rows[iNhanVien]["ma_cham_cong"].ToString();
                dgv_nhanvien.Rows[addNhanVien].Cells[4].Value = dtNhanVien.Rows[iNhanVien]["ten_cham_cong"].ToString();
                dgv_nhanvien.Rows[addNhanVien].Cells[5].Value = dtNhanVien.Rows[iNhanVien]["ma_the"].ToString();
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
            _nhanVienDTO.Ma_so_value = txt_TimMa.Text;
            _nhanVienDTO.Ho_ten_value = txt_TimMa.Text;
            dtSearch = _nhanVienBLL.NhanVienSearchTaiNhanVienLenMCC(_nhanVienDTO);
            for (int iSearch = 0; iSearch < dtSearch.Rows.Count; iSearch++)
            {
                int addSearch = dgv_nhanvien.Rows.Add();
                dgv_nhanvien.Rows[addSearch].Cells[1].Value = dtSearch.Rows[iSearch]["ma_nhan_vien"].ToString();
                dgv_nhanvien.Rows[addSearch].Cells[2].Value = dtSearch.Rows[iSearch]["ho_ten"].ToString();
                dgv_nhanvien.Rows[addSearch].Cells[3].Value = dtSearch.Rows[iSearch]["ma_cham_cong"].ToString();
                dgv_nhanvien.Rows[addSearch].Cells[4].Value = dtSearch.Rows[iSearch]["ten_cham_cong"].ToString();
                dgv_nhanvien.Rows[addSearch].Cells[5].Value = dtSearch.Rows[iSearch]["ma_the"].ToString();
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
            _nhanVienDTO.Ma_so_value = txt_TimMa.Texts;
            _nhanVienDTO.Ho_ten_value = txt_TimMa.Texts;
            dtSearch = _nhanVienBLL.NhanVienSearchTaiNhanVienLenMCC(_nhanVienDTO);
            for (int iSearch = 0; iSearch < dtSearch.Rows.Count; iSearch++)
            {
                int addSearch = dgv_nhanvien.Rows.Add();
                dgv_nhanvien.Rows[addSearch].Cells[1].Value = dtSearch.Rows[iSearch]["ma_nhan_vien"].ToString();
                dgv_nhanvien.Rows[addSearch].Cells[2].Value = dtSearch.Rows[iSearch]["ho_ten"].ToString();
                dgv_nhanvien.Rows[addSearch].Cells[3].Value = dtSearch.Rows[iSearch]["ma_cham_cong"].ToString();
                dgv_nhanvien.Rows[addSearch].Cells[4].Value = dtSearch.Rows[iSearch]["ten_cham_cong"].ToString();
                dgv_nhanvien.Rows[addSearch].Cells[5].Value = dtSearch.Rows[iSearch]["ma_the"].ToString();
                demNhanVien++;
            }
        }

        private void trv_sodoquanly_AfterSelect(object sender, TreeViewEventArgs e)
        {
            string treeview_select = e.Node.Tag.ToString();
            string sql = "select * from view_hoso_nhansu where 1=1";
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
                    sql = sql + string.Format(" and ma_cong_ty = {0}", treeview_select.Remove(0, 7));
                }
                else if (treeview_select.Contains("id_khuvuc"))
                {
                    sql = sql + string.Format(" and ma_khu_vuc = {0}", treeview_select.Remove(0, 10));
                }
                else
                {
                    sql = sql + string.Format(" and ma_phong_ban = {0}", treeview_select);
                }
            }
            DataTable dt = new DataTable();
            dt = SQLHelper.ExecuteDt(sql);
            dgv_nhanvien.DataSource = dt;
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
