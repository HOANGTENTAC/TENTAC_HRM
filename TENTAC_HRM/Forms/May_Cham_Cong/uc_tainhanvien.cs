using System;
using System.Data;
using System.Net;
using System.Windows.Forms;
using TENTAC_HRM.BusinessLogicLayer.CommonBLL;
using TENTAC_HRM.BusinessLogicLayer.MayChamCong;
using TENTAC_HRM.BusinessLogicLayer.QuanLyNhanVienBLL;
using TENTAC_HRM.Common;
using TENTAC_HRM.Custom;
using TENTAC_HRM.DataTransferObject.MayChamCong;
using TENTAC_HRM.Model;
using zkemkeeper;

namespace TENTAC_HRM.Forms.May_Cham_Cong
{
    public partial class uc_tainhanvien : UserControl
    {
        DataProvider provider = new DataProvider();
        public CZKEMClass axCZKEM1 = new CZKEMClass();
        public int iDemKhuonMat;
        public bool _bIsConnected;

        public int _iMachineNumber = 1;

        public string _KieuKetNoi;

        public string _DiaChiIP;

        public string _Port;

        public string _DiaChiWeb;

        public string _SuDungWeb;

        public string _TenMay;

        public string _Serial;

        public string _SoDangKy;

        private MayChamCongBLL _mayChamCongBLL = new MayChamCongBLL();

        private MayChamCongDTO _mayChamCongDTO = new MayChamCongDTO();

        private NhanVien_BLL _nhanVienBLL = new NhanVien_BLL();

        private CommonBLL _commonBLL = new CommonBLL();

        private Common_model _commonDTO = new Common_model();

        private TemplateCapNhatVanTay_model _templateCapNhatVanTayDTO = new TemplateCapNhatVanTay_model();

        private TemplateCapNhatVanTayBLL _templateCapNhatVanTayBLL = new TemplateCapNhatVanTayBLL();

        private Nhanvien_model _nhanVienDTO = new Nhanvien_model();

        private CommonKhuonMat_model _commonKhuonMatDTO = new CommonKhuonMat_model();

        private CommonKhuonMatBLL _commonKhuonMatBLL = new CommonKhuonMatBLL();

        private int _kiemTraManHinh = 0;

        private string _loaiManHinh;

        private string sMaNhanVien_CapNhatNhanVien;

        private string sMaNhanVien_NhanVienMoi;

        private string sMaThe_NhanVienMoi;

        private int iSoDuLieu;

        private string _phienBanVanTay = "";

        private TemplateBLL _templateBLL = new TemplateBLL();

        private Template_model _templateDTO = new Template_model();

        private int _value = 0;

        private string sTenMay;

        private string sKieuKetNoi;

        private string sDiaChiIP;

        private string sPort;

        private string sDiaChiWeb;

        private string sSuDungWeb;

        private string sSerial;

        private string sSoDangKy;

        private string sTrangThai;

        private string sdwSerialNumber;

        private int iMachineNumber = 1;

        private int a;

        private int b;

        private int c;

        private int _ketQua;

        private string _a;

        private string _b;

        private string _c;
        public static uc_tainhanvien _instance;
        public static uc_tainhanvien Instance
        {
            get
            {
                _instance = new uc_tainhanvien();
                return _instance;
            }
        }
        public uc_tainhanvien()
        {
            InitializeComponent();
        }

        private void uc_tainhannien_Load(object sender, EventArgs e)
        {
            rdb_NhanVienMoi.Checked = true;
            dgv_NhanVienDaCoTrenMay.Columns.Insert(0, new DataGridViewCheckBoxColumn());
            dgv_NhanVienMoi.Columns.Insert(0, new DataGridViewCheckBoxColumn());
            dgv_NhanVienMoi.Columns[0].Width = 30;
            dgv_NhanVienDaCoTrenMay.Columns[0].Width = 30;
            rdb_XoaNhanVien.Checked = true;
            chk_TaiVanTay.Checked = true;
            DataTable dtLoadMayChamCong = new DataTable();
            dtLoadMayChamCong = _mayChamCongBLL.GETDANHSACHMCC();
            cbo_ChonMayChamCong.DataSource = _mayChamCongBLL.GETDANHSACHMCC();
            if (dtLoadMayChamCong.Rows.Count > 0)
            {
                cbo_ChonMayChamCong.DisplayMember = "TenMCC";
                cbo_ChonMayChamCong.ValueMember = "MaMCC";
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
                _loaiManHinh = "1";
            }
        }

        private void phienBanVanTay()
        {
            if (!axCZKEM1.GetSysOption(1, "~ZKFPVersion", out _phienBanVanTay))
            {
            }
        }

        private void demNhanVien()
        {
            int iNhanVienDaCoTrenMayTinh = 0;
            int iNhanVienMoiChuaCoTrenMayTinh = 0;
            for (int dem = 1; dem <= dgv_NhanVienDaCoTrenMay.Rows.Count; dem++)
            {
                iNhanVienDaCoTrenMayTinh++;
            }
            expandablePanel1.Text = "Nhân viên đã có trên máy tính: " + iNhanVienDaCoTrenMayTinh + " nhân viên";
            for (int dem2 = 1; dem2 <= dgv_NhanVienMoi.Rows.Count; dem2++)
            {
                iNhanVienMoiChuaCoTrenMayTinh++;
            }
            expandablePanel2.Text = "Nhân viên mới: " + iNhanVienMoiChuaCoTrenMayTinh + " nhân viên";
        }

        [Obsolete]
        private void btn_DuyetTuMayChamCongNew_Click(object sender, EventArgs e)
        {
            sdwSerialNumber = "";
            _commonBLL.DeleteALLTemplateVirtual();
            _templateCapNhatVanTayBLL.TemplateCapNhatVanTayDeleteAll();
            if (cbo_ChonMayChamCong.SelectedIndex == -1)
            {
                RJMessageBox.Show("Bạn chưa chọn máy chấm công", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Hand);
                return;
            }
            if (sKieuKetNoi == "TCP/IP")
            {
                if (sSuDungWeb == "False")
                {
                    Cursor = Cursors.WaitCursor;
                    _bIsConnected = axCZKEM1.Connect_Net(sDiaChiIP, Convert.ToInt32(sPort));
                    if (!_bIsConnected)
                    {
                        RJMessageBox.Show("Không kết nối được với " + sTenMay);
                        Cursor = Cursors.Default;
                        return;
                    }
                    if (axCZKEM1.GetSerialNumber(iMachineNumber, out sdwSerialNumber))
                    {
                        sSerial = sdwSerialNumber;
                    }
                    ActiveKey();
                    if (sSoDangKy.Trim() == "" || sSoDangKy.Trim() == null)
                    {
                        RJMessageBox.Show("Máy chấm công này chưa được đăng ký, xin vui lòng liên hệ với nhà cung cấp", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Hand);
                        axCZKEM1.Disconnect();
                        Cursor = Cursors.Default;
                        provider.btn_close(this.Parent);
                        frmDangKyMayChamCong _dangKyMayChamCong3 = new frmDangKyMayChamCong();
                        _dangKyMayChamCong3.ShowDialog();
                        return;
                    }
                    if (sSoDangKy.Trim() != _ketQua.ToString())
                    {
                        RJMessageBox.Show("Máy chấm công này chưa được đăng ký, xin vui lòng liên hệ với nhà cung cấp", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Hand);
                        axCZKEM1.Disconnect();
                        Cursor = Cursors.Default;
                        provider.btn_close(this.Parent);
                        frmDangKyMayChamCong _dangKyMayChamCong4 = new frmDangKyMayChamCong();
                        _dangKyMayChamCong4.ShowDialog();
                        return;
                    }
                    if (axCZKEM1.GetDeviceStatus(1, 2, ref _value))
                    {
                        iSoDuLieu = _value;
                    }
                    kiemTraLoaiMay();
                    phienBanVanTay();
                    if (rdb_NhanVienMoi.Checked)
                    {
                        duyetNhanVienTuMayChamCong_NhanVienMoi();
                    }
                    if (rdb_ToanBoNhanVien.Checked)
                    {
                        duyetNhanVienTuMayChamCong_ToanBoNhanVien();
                    }
                    btn_ChonTatCa2_Click(sender, e);
                    axCZKEM1.Disconnect();
                    Cursor = Cursors.Default;
                    if (sTrangThai == "False")
                    {
                        RJMessageBox.Show("Máy chấm công này chưa cho phép sử dụng");
                        Cursor = Cursors.Default;
                        axCZKEM1.Disconnect();
                        return;
                    }
                }
                else
                {
                    IPHostEntry hostname = Dns.GetHostByName(sDiaChiWeb);
                    IPAddress[] ip = hostname.AddressList;
                    string _IpWeb = ip[0].ToString();
                    Cursor = Cursors.WaitCursor;
                    _bIsConnected = axCZKEM1.Connect_Net(_IpWeb, Convert.ToInt32(sPort));
                    if (axCZKEM1.GetSerialNumber(iMachineNumber, out sdwSerialNumber))
                    {
                        sSerial = sdwSerialNumber;
                    }
                    ActiveKey();
                    if (sSoDangKy.Trim() == "" || sSoDangKy.Trim() == null)
                    {
                        RJMessageBox.Show("Máy chấm công này chưa được đăng ký, xin vui lòng liên hệ với nhà cung cấp", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Hand);
                        axCZKEM1.Disconnect();
                        Cursor = Cursors.Default;
                        provider.btn_close(this.Parent);
                        frmDangKyMayChamCong _dangKyMayChamCong = new frmDangKyMayChamCong();
                        _dangKyMayChamCong.ShowDialog();
                        return;
                    }
                    if (sSoDangKy.Trim() != _ketQua.ToString())
                    {
                        RJMessageBox.Show("Máy chấm công này chưa được đăng ký, xin vui lòng liên hệ với nhà cung cấp", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Hand);
                        axCZKEM1.Disconnect();
                        Cursor = Cursors.Default;
                        provider.btn_close(this.Parent);
                        frmDangKyMayChamCong _dangKyMayChamCong2 = new frmDangKyMayChamCong();
                        _dangKyMayChamCong2.ShowDialog();
                        return;
                    }
                    if (axCZKEM1.GetDeviceStatus(1, 2, ref _value))
                    {
                        iSoDuLieu = _value;
                    }
                    kiemTraLoaiMay();
                    phienBanVanTay();
                    if (rdb_NhanVienMoi.Checked)
                    {
                        duyetNhanVienTuMayChamCong_NhanVienMoi();
                    }
                    if (rdb_ToanBoNhanVien.Checked)
                    {
                        duyetNhanVienTuMayChamCong_ToanBoNhanVien();
                    }
                    btn_ChonTatCa2_Click(sender, e);
                    axCZKEM1.Disconnect();
                    Cursor = Cursors.Default;
                    if (sTrangThai == "False")
                    {
                        RJMessageBox.Show("Máy chấm công này chưa cho phép sử dụng");
                        Cursor = Cursors.Default;
                        axCZKEM1.Disconnect();
                        return;
                    }
                    if (!_bIsConnected)
                    {
                        RJMessageBox.Show("Không kết nối được với " + sTenMay);
                        Cursor = Cursors.Default;
                        return;
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
                    RJMessageBox.Show("Không kết nối được với " + sTenMay);
                    Cursor = Cursors.Default;
                    return;
                }
                axCZKEM1.RegEvent(_iMachineNumber, 65535);
                if (axCZKEM1.GetDeviceStatus(1, 2, ref _value))
                {
                    iSoDuLieu = _value;
                }
                kiemTraLoaiMay();
                phienBanVanTay();
                if (chk_TaiVanTay.Checked)
                {
                    duyetNhanVienTuMayChamCong_NhanVienMoi();
                }
                else
                {
                    duyetNhanVienTuMayChamCong_ToanBoNhanVien();
                }
                btn_ChonTatCa2_Click(sender, e);
                axCZKEM1.Disconnect();
                Cursor = Cursors.Default;
            }
            demNhanVien();
        }
        private void duyetNhanVienTuMayChamCong_NhanVienMoi()
        {
            dgv_NhanVienDaCoTrenMay.Rows.Clear();
            iDemKhuonMat = 0;
            int dem = -1;
            int test = iSoDuLieu;
            if (_loaiManHinh == "0")
            {
                int iFaceIndex = 50;
                string sTmpData2 = "";
                int iTmpLength2 = 0;
                int iLength = 0;
                int iFlag2 = 0;
                dgv_NhanVienMoi.Rows.Clear();
                string sdwEnrollNumber2 = "";
                string sName2 = "";
                string sPassword2 = "";
                int iPrivilege2 = 0;
                bool bEnabled2 = false;
                string sCardnumber2 = "";
                axCZKEM1.EnableDevice(_iMachineNumber, bFlag: false);
                axCZKEM1.ReadAllUserID(_iMachineNumber);
                axCZKEM1.ReadAllTemplate(_iMachineNumber);
                while (axCZKEM1.SSR_GetAllUserInfo(_iMachineNumber, out sdwEnrollNumber2, out sName2, out sPassword2, out iPrivilege2, out bEnabled2))
                {
                    DataTable dtDuyetTimNhanVien2 = new DataTable();
                    _nhanVienDTO.Ma_Cham_Cong = sdwEnrollNumber2;
                    dtDuyetTimNhanVien2 = _nhanVienBLL.NhanVienGetByMaChamCong(sdwEnrollNumber2);
                    if (dtDuyetTimNhanVien2.Rows.Count == 0)
                    {
                        int j = dgv_NhanVienMoi.Rows.Add();
                        if (sdwEnrollNumber2.Length == 0)
                        {
                            sMaNhanVien_NhanVienMoi = "00000";
                        }
                        if (sdwEnrollNumber2.Length == 1)
                        {
                            sMaNhanVien_NhanVienMoi = "0000" + sdwEnrollNumber2;
                        }
                        if (sdwEnrollNumber2.Length == 2)
                        {
                            sMaNhanVien_NhanVienMoi = "000" + sdwEnrollNumber2;
                        }
                        if (sdwEnrollNumber2.Length == 3)
                        {
                            sMaNhanVien_NhanVienMoi = "00" + sdwEnrollNumber2;
                        }
                        if (sdwEnrollNumber2.Length == 4)
                        {
                            sMaNhanVien_NhanVienMoi = "0" + sdwEnrollNumber2;
                        }
                        if (sdwEnrollNumber2.Length > 4)
                        {
                            sMaNhanVien_NhanVienMoi = sdwEnrollNumber2;
                        }
                        dgv_NhanVienMoi.Rows[j].Cells[1].Value = sMaNhanVien_NhanVienMoi;
                        dgv_NhanVienMoi.Rows[j].Cells[3].Value = sdwEnrollNumber2;
                        if (sName2 == null || sName2 == "")
                        {
                            dgv_NhanVienMoi.Rows[j].Cells[2].Value = sdwEnrollNumber2;
                            dgv_NhanVienMoi.Rows[j].Cells[4].Value = sdwEnrollNumber2;
                        }
                        else
                        {
                            dgv_NhanVienMoi.Rows[j].Cells[2].Value = sName2;
                            dgv_NhanVienMoi.Rows[j].Cells[4].Value = sName2;
                        }
                        axCZKEM1.GetStrCardNumber(out sCardnumber2);
                        if (sCardnumber2.Length == 0)
                        {
                            sMaThe_NhanVienMoi = "0000000000";
                        }
                        if (sCardnumber2.Length == 1)
                        {
                            sMaThe_NhanVienMoi = "000000000" + sCardnumber2;
                        }
                        if (sCardnumber2.Length == 2)
                        {
                            sMaThe_NhanVienMoi = "00000000" + sCardnumber2;
                        }
                        if (sCardnumber2.Length == 3)
                        {
                            sMaThe_NhanVienMoi = "0000000" + sCardnumber2;
                        }
                        if (sCardnumber2.Length == 4)
                        {
                            sMaThe_NhanVienMoi = "000000" + sCardnumber2;
                        }
                        if (sCardnumber2.Length == 5)
                        {
                            sMaThe_NhanVienMoi = "00000" + sCardnumber2;
                        }
                        if (sCardnumber2.Length == 6)
                        {
                            sMaThe_NhanVienMoi = "0000" + sCardnumber2;
                        }
                        if (sCardnumber2.Length == 7)
                        {
                            sMaThe_NhanVienMoi = "000" + sCardnumber2;
                        }
                        if (sCardnumber2.Length == 8)
                        {
                            sMaThe_NhanVienMoi = "00" + sCardnumber2;
                        }
                        if (sCardnumber2.Length == 9)
                        {
                            sMaThe_NhanVienMoi = "0" + sCardnumber2;
                        }
                        if (sCardnumber2.Length == 10)
                        {
                            sMaThe_NhanVienMoi = sCardnumber2;
                        }
                        if (sCardnumber2.Trim() == "")
                        {
                            sMaThe_NhanVienMoi = "0000000000";
                        }
                        dgv_NhanVienMoi.Rows[j].Cells[5].Value = sMaThe_NhanVienMoi;
                        //dgv_NhanVienMoi.Rows[j].Cells[6].Value = sPassword2;
                        //dgv_NhanVienMoi.Rows[j].Cells[7].Value = iPrivilege2;
                        //dgv_NhanVienMoi.Rows[j].Cells[8].Value = bEnabled2;
                        if (chk_TaiVanTay.Checked)
                        {
                            for (int idwFingerIndex2 = 0; idwFingerIndex2 < 10; idwFingerIndex2++)
                            {
                                if (axCZKEM1.GetUserTmpExStr(_iMachineNumber, sdwEnrollNumber2, idwFingerIndex2, out iFlag2, out sTmpData2, out iTmpLength2))
                                {
                                    _commonDTO.MaChamCong = Convert.ToInt32(sdwEnrollNumber2);
                                    _commonDTO.FingerIDVirtual = idwFingerIndex2;
                                    _commonDTO.FlagVirtual = iFlag2;
                                    _commonDTO.FingerTemplateVirtual = sTmpData2;
                                    _commonDTO.FingerVersionVirtual = _phienBanVanTay;
                                    _commonBLL.InsertTemplateVirtual(_commonDTO);
                                }
                            }
                        }
                        if (chk_TaiKhuonMat.Checked && axCZKEM1.GetUserFaceStr(_iMachineNumber, sdwEnrollNumber2, iFaceIndex, ref sTmpData2, ref iLength))
                        {
                            _commonKhuonMatDTO.MaChamCong = Convert.ToInt32(sdwEnrollNumber2);
                            _commonKhuonMatDTO.FaceIDVirtual = iFaceIndex;
                            _commonKhuonMatDTO.FaceTemplateVirtual = sTmpData2;
                            _commonKhuonMatBLL.InsertFaceVirtual(_commonKhuonMatDTO);
                            iDemKhuonMat++;
                        }
                        progressBarChay.Maximum = iSoDuLieu;
                        test--;
                        dem++;
                        progressBarChay.Text = (dem + 1) * 100 / iSoDuLieu + "% trên tổng số nhân viên mới";
                        Application.DoEvents();
                        _ = iSoDuLieu;
                        _ = 0;
                        if (iSoDuLieu >= 0)
                        {
                            progressBarChay.Value = iSoDuLieu - test;
                        }
                    }
                    else
                    {
                        int idem2 = dgv_NhanVienDaCoTrenMay.Rows.Add();
                        for (int itDuyetTimNhanVien2 = 0; itDuyetTimNhanVien2 < dtDuyetTimNhanVien2.Rows.Count; itDuyetTimNhanVien2++)
                        {
                            dgv_NhanVienDaCoTrenMay.Rows[idem2].Cells[1].Value = dtDuyetTimNhanVien2.Rows[itDuyetTimNhanVien2]["ma_nhan_vien"].ToString();
                            dgv_NhanVienDaCoTrenMay.Rows[idem2].Cells[2].Value = dtDuyetTimNhanVien2.Rows[itDuyetTimNhanVien2]["ho_ten"].ToString();
                            dgv_NhanVienDaCoTrenMay.Rows[idem2].Cells[3].Value = dtDuyetTimNhanVien2.Rows[itDuyetTimNhanVien2]["ma_cham_cong"].ToString();
                            dgv_NhanVienDaCoTrenMay.Rows[idem2].Cells[4].Value = dtDuyetTimNhanVien2.Rows[itDuyetTimNhanVien2]["ten_cham_cong"].ToString();
                            dgv_NhanVienDaCoTrenMay.Rows[idem2].Cells[5].Value = dtDuyetTimNhanVien2.Rows[itDuyetTimNhanVien2]["ma_the"].ToString();
                        }
                    }
                }
                axCZKEM1.EnableDevice(_iMachineNumber, bFlag: true);
                return;
            }
            dgv_NhanVienMoi.Rows.Clear();
            string sdwEnrollNumber = "";
            int iFlag = 1;
            int idwEnrollNumber = 0;
            string sName = "";
            string sPassword = "";
            int iPrivilege = 0;
            bool bEnabled = false;
            string sTmpData = "";
            int iTmpLength = 0;
            string sCardnumber = "";
            Cursor = Cursors.WaitCursor;
            axCZKEM1.EnableDevice(_iMachineNumber, bFlag: false);
            axCZKEM1.ReadAllUserID(_iMachineNumber);
            axCZKEM1.ReadAllTemplate(_iMachineNumber);
            while (axCZKEM1.GetAllUserInfo(_iMachineNumber, ref idwEnrollNumber, ref sName, ref sPassword, ref iPrivilege, ref bEnabled))
            {
                DataTable dtDuyetTimNhanVien = new DataTable();
                _nhanVienDTO.Ma_Cham_Cong = idwEnrollNumber.ToString();
                dtDuyetTimNhanVien = _nhanVienBLL.NhanVienGetByMaChamCong(idwEnrollNumber.ToString());
                if (dtDuyetTimNhanVien.Rows.Count == 0)
                {
                    int i = dgv_NhanVienMoi.Rows.Add();
                    if (idwEnrollNumber.ToString().Length == 0)
                    {
                        sMaNhanVien_NhanVienMoi = "00000";
                    }
                    if (idwEnrollNumber.ToString().Length == 1)
                    {
                        sMaNhanVien_NhanVienMoi = "0000" + idwEnrollNumber;
                    }
                    if (idwEnrollNumber.ToString().Length == 2)
                    {
                        sMaNhanVien_NhanVienMoi = "000" + idwEnrollNumber;
                    }
                    if (idwEnrollNumber.ToString().Length == 3)
                    {
                        sMaNhanVien_NhanVienMoi = "00" + idwEnrollNumber;
                    }
                    if (idwEnrollNumber.ToString().Length == 4)
                    {
                        sMaNhanVien_NhanVienMoi = "0" + idwEnrollNumber;
                    }
                    if (idwEnrollNumber.ToString().Length > 4)
                    {
                        sMaNhanVien_NhanVienMoi = idwEnrollNumber.ToString();
                    }
                    dgv_NhanVienMoi.Rows[i].Cells[1].Value = sMaNhanVien_NhanVienMoi;
                    dgv_NhanVienMoi.Rows[i].Cells[3].Value = idwEnrollNumber;
                    if (sName == null || sName == "")
                    {
                        dgv_NhanVienMoi.Rows[i].Cells[2].Value = idwEnrollNumber;
                        dgv_NhanVienMoi.Rows[i].Cells[4].Value = idwEnrollNumber;
                    }
                    else
                    {
                        dgv_NhanVienMoi.Rows[i].Cells[2].Value = sName;
                        dgv_NhanVienMoi.Rows[i].Cells[4].Value = sName;
                    }
                    axCZKEM1.GetStrCardNumber(out sCardnumber);
                    if (sCardnumber.Length == 0)
                    {
                        dgv_NhanVienMoi.Rows[i].Cells[5].Value = "0000000000";
                    }
                    if (sCardnumber.Length == 1)
                    {
                        dgv_NhanVienMoi.Rows[i].Cells[5].Value = "000000000" + sCardnumber;
                    }
                    if (sCardnumber.Length == 2)
                    {
                        dgv_NhanVienMoi.Rows[i].Cells[5].Value = "00000000" + sCardnumber;
                    }
                    if (sCardnumber.Length == 3)
                    {
                        dgv_NhanVienMoi.Rows[i].Cells[5].Value = "0000000" + sCardnumber;
                    }
                    if (sCardnumber.Length == 4)
                    {
                        dgv_NhanVienMoi.Rows[i].Cells[5].Value = "000000" + sCardnumber;
                    }
                    if (sCardnumber.Length == 5)
                    {
                        dgv_NhanVienMoi.Rows[i].Cells[5].Value = "00000" + sCardnumber;
                    }
                    if (sCardnumber.Length == 6)
                    {
                        dgv_NhanVienMoi.Rows[i].Cells[5].Value = "0000" + sCardnumber;
                    }
                    if (sCardnumber.Length == 7)
                    {
                        dgv_NhanVienMoi.Rows[i].Cells[5].Value = "000" + sCardnumber;
                    }
                    if (sCardnumber.Length == 8)
                    {
                        dgv_NhanVienMoi.Rows[i].Cells[5].Value = "00" + sCardnumber;
                    }
                    if (sCardnumber.Length == 9)
                    {
                        dgv_NhanVienMoi.Rows[i].Cells[5].Value = "0" + sCardnumber;
                    }
                    if (sCardnumber.Length == 10)
                    {
                        dgv_NhanVienMoi.Rows[i].Cells[5].Value = sCardnumber;
                    }
                    //dgv_NhanVienMoi.Rows[i].Cells[6].Value = sPassword;
                    //dgv_NhanVienMoi.Rows[i].Cells[7].Value = iPrivilege;
                    //dgv_NhanVienMoi.Rows[i].Cells[8].Value = bEnabled;
                    if (chk_TaiVanTay.Checked)
                    {
                        sdwEnrollNumber = idwEnrollNumber.ToString();
                        for (int idwFingerIndex = 0; idwFingerIndex < 10; idwFingerIndex++)
                        {
                            if (axCZKEM1.GetUserTmpExStr(_iMachineNumber, sdwEnrollNumber, idwFingerIndex, out iFlag, out sTmpData, out iTmpLength))
                            {
                                _commonDTO.MaChamCong = Convert.ToInt32(sdwEnrollNumber);
                                _commonDTO.FingerIDVirtual = idwFingerIndex;
                                _commonDTO.FlagVirtual = iFlag;
                                _commonDTO.FingerTemplateVirtual = sTmpData;
                                _commonDTO.FingerVersionVirtual = _phienBanVanTay;
                                _commonBLL.InsertTemplateVirtual(_commonDTO);
                            }
                        }
                    }
                }
                else
                {
                    int idem = dgv_NhanVienDaCoTrenMay.Rows.Add();
                    for (int itDuyetTimNhanVien = 0; itDuyetTimNhanVien < dtDuyetTimNhanVien.Rows.Count; itDuyetTimNhanVien++)
                    {
                        dgv_NhanVienDaCoTrenMay.Rows[idem].Cells[1].Value = dtDuyetTimNhanVien.Rows[itDuyetTimNhanVien]["ma_nhan_vien"].ToString();
                        dgv_NhanVienDaCoTrenMay.Rows[idem].Cells[2].Value = dtDuyetTimNhanVien.Rows[itDuyetTimNhanVien]["ten_nhan_vien"].ToString();
                        dgv_NhanVienDaCoTrenMay.Rows[idem].Cells[3].Value = dtDuyetTimNhanVien.Rows[itDuyetTimNhanVien]["ma_cham_cong"].ToString();
                        dgv_NhanVienDaCoTrenMay.Rows[idem].Cells[4].Value = dtDuyetTimNhanVien.Rows[itDuyetTimNhanVien]["ten_cham_cong"].ToString();
                        dgv_NhanVienDaCoTrenMay.Rows[idem].Cells[5].Value = dtDuyetTimNhanVien.Rows[itDuyetTimNhanVien]["ma_the"].ToString();
                    }
                }
                progressBarChay.Maximum = iSoDuLieu;
                test--;
                dem++;
                progressBarChay.Text = (dem + 1) * 100 / iSoDuLieu + "%";
                Application.DoEvents();
                _ = iSoDuLieu;
                _ = 0;
                if (iSoDuLieu >= 0)
                {
                    progressBarChay.Value = iSoDuLieu - test;
                }
            }
            axCZKEM1.EnableDevice(_iMachineNumber, bFlag: true);
            Cursor = Cursors.Default;
        }
        private void duyetNhanVienTuMayChamCong_ToanBoNhanVien()
        {
            dgv_NhanVienDaCoTrenMay.Rows.Clear();
            int dem = -1;
            int test = iSoDuLieu;
            if (_loaiManHinh == "0")
            {
                int iFaceIndex = 50;
                int iLength = 0;
                string sTmpData2 = "";
                int iTmpLength2 = 0;
                int iFlag2 = 0;
                dgv_NhanVienMoi.Rows.Clear();
                string sdwEnrollNumber = "";
                string sName2 = "";
                string sPassword2 = "";
                int iPrivilege2 = 0;
                bool bEnabled2 = false;
                string sCardnumber2 = "";
                axCZKEM1.EnableDevice(_iMachineNumber, bFlag: false);
                axCZKEM1.ReadAllUserID(_iMachineNumber);
                axCZKEM1.ReadAllTemplate(_iMachineNumber);
                while (axCZKEM1.SSR_GetAllUserInfo(_iMachineNumber, out sdwEnrollNumber, out sName2, out sPassword2, out iPrivilege2, out bEnabled2))
                {
                    for (int idwFingerIndex2 = 0; idwFingerIndex2 < 10; idwFingerIndex2++)
                    {
                        if (axCZKEM1.GetUserTmpExStr(_iMachineNumber, sdwEnrollNumber, idwFingerIndex2, out iFlag2, out sTmpData2, out iTmpLength2))
                        {
                            _templateCapNhatVanTayDTO.MaChamCong = Convert.ToInt32(sdwEnrollNumber);
                            _templateCapNhatVanTayDTO.FingerIDCapNhatVanTay = idwFingerIndex2;
                            _templateCapNhatVanTayDTO.FlagCapNhatVanTay = iFlag2;
                            _templateCapNhatVanTayDTO.FingerTemplateCapNhatVanTay = sTmpData2;
                            _templateCapNhatVanTayDTO.FingerVersionCapNhatVanTay = _phienBanVanTay;
                            _templateCapNhatVanTayBLL.TemplateCapNhatVanTayInsert(_templateCapNhatVanTayDTO);
                        }
                    }
                    if (axCZKEM1.GetUserFaceStr(_iMachineNumber, sdwEnrollNumber, iFaceIndex, ref sTmpData2, ref iLength))
                    {
                        DataTable dtKhuonMat1 = new DataTable();
                        dtKhuonMat1 = _commonKhuonMatBLL.SelectTemplateVirtualByMaChamCong(sdwEnrollNumber);
                        if (dtKhuonMat1.Rows.Count == 0)
                        {
                            _commonKhuonMatDTO.MaChamCong = Convert.ToInt32(sdwEnrollNumber);
                            _commonKhuonMatDTO.FaceIDVirtual = iFaceIndex;
                            _commonKhuonMatDTO.FaceTemplateVirtual = sTmpData2;
                            _commonKhuonMatBLL.InsertFaceVirtual(_commonKhuonMatDTO);
                        }
                    }
                    //if (axCZKEM1.GetStrCardNumber(out sCardnumber2))
                    //{
                    //    _nhanVienUpdateDTO.MaChamCong = Convert.ToInt32(sdwEnrollNumber);
                    //    _nhanVienUpdateDTO.MaThe = sCardnumber2;
                    //    _nhanVienUpdateDTO.UserPassWord = sPassword2;
                    //    _nhanVienUpdateDTO.PhanQuyen = iPrivilege2;
                    //    _nhanVienUpdateBLL.NhanVienUpdateInsert(_nhanVienUpdateDTO);
                    //}
                    DataTable dtDuyetTimNhanVien2 = new DataTable();
                    dtDuyetTimNhanVien2 = _nhanVienBLL.NhanVienGetByMaChamCong(sdwEnrollNumber);
                    if (dtDuyetTimNhanVien2.Rows.Count == 0)
                    {
                        int j = dgv_NhanVienMoi.Rows.Add();
                        if (sdwEnrollNumber.Length == 0)
                        {
                            sMaNhanVien_CapNhatNhanVien = "00000";
                        }
                        if (sdwEnrollNumber.Length == 1)
                        {
                            sMaNhanVien_CapNhatNhanVien = "0000" + sdwEnrollNumber;
                        }
                        if (sdwEnrollNumber.Length == 2)
                        {
                            sMaNhanVien_CapNhatNhanVien = "000" + sdwEnrollNumber;
                        }
                        if (sdwEnrollNumber.Length == 3)
                        {
                            sMaNhanVien_CapNhatNhanVien = "00" + sdwEnrollNumber;
                        }
                        if (sdwEnrollNumber.Length == 4)
                        {
                            sMaNhanVien_CapNhatNhanVien = "0" + sdwEnrollNumber;
                        }
                        if (sdwEnrollNumber.Length > 4)
                        {
                            sMaNhanVien_CapNhatNhanVien = sdwEnrollNumber;
                        }
                        dgv_NhanVienMoi.Rows[j].Cells[1].Value = sMaNhanVien_CapNhatNhanVien;
                        dgv_NhanVienMoi.Rows[j].Cells[3].Value = sdwEnrollNumber;
                        if (sName2 == null || sName2 == "")
                        {
                            dgv_NhanVienMoi.Rows[j].Cells[2].Value = sdwEnrollNumber;
                            dgv_NhanVienMoi.Rows[j].Cells[4].Value = sdwEnrollNumber;
                        }
                        else
                        {
                            dgv_NhanVienMoi.Rows[j].Cells[2].Value = sName2;
                            dgv_NhanVienMoi.Rows[j].Cells[4].Value = sName2;
                        }
                        axCZKEM1.GetStrCardNumber(out sCardnumber2);
                        if (sCardnumber2.Length == 0)
                        {
                            dgv_NhanVienMoi.Rows[j].Cells[5].Value = "0000000000";
                        }
                        if (sCardnumber2.Length == 1)
                        {
                            dgv_NhanVienMoi.Rows[j].Cells[5].Value = "000000000" + sCardnumber2;
                        }
                        if (sCardnumber2.Length == 2)
                        {
                            dgv_NhanVienMoi.Rows[j].Cells[5].Value = "00000000" + sCardnumber2;
                        }
                        if (sCardnumber2.Length == 3)
                        {
                            dgv_NhanVienMoi.Rows[j].Cells[5].Value = "0000000" + sCardnumber2;
                        }
                        if (sCardnumber2.Length == 4)
                        {
                            dgv_NhanVienMoi.Rows[j].Cells[5].Value = "000000" + sCardnumber2;
                        }
                        if (sCardnumber2.Length == 5)
                        {
                            dgv_NhanVienMoi.Rows[j].Cells[5].Value = "00000" + sCardnumber2;
                        }
                        if (sCardnumber2.Length == 6)
                        {
                            dgv_NhanVienMoi.Rows[j].Cells[5].Value = "0000" + sCardnumber2;
                        }
                        if (sCardnumber2.Length == 7)
                        {
                            dgv_NhanVienMoi.Rows[j].Cells[5].Value = "000" + sCardnumber2;
                        }
                        if (sCardnumber2.Length == 8)
                        {
                            dgv_NhanVienMoi.Rows[j].Cells[5].Value = "00" + sCardnumber2;
                        }
                        if (sCardnumber2.Length == 9)
                        {
                            dgv_NhanVienMoi.Rows[j].Cells[5].Value = "0" + sCardnumber2;
                        }
                        if (sCardnumber2.Length == 10)
                        {
                            dgv_NhanVienMoi.Rows[j].Cells[5].Value = sCardnumber2;
                        }
                        //dgv_NhanVienMoi.Rows[j].Cells[6].Value = sPassword2;
                        //dgv_NhanVienMoi.Rows[j].Cells[7].Value = iPrivilege2;
                        //dgv_NhanVienMoi.Rows[j].Cells[8].Value = bEnabled2;
                        progressBarChay.Maximum = iSoDuLieu;
                        test--;
                        dem++;
                        progressBarChay.Text = (dem + 1) * 100 / iSoDuLieu + "%";
                        Application.DoEvents();
                        _ = iSoDuLieu;
                        _ = 0;
                        if (iSoDuLieu >= 0)
                        {
                            progressBarChay.Value = iSoDuLieu - test;
                        }
                    }
                    else
                    {
                        int idem2 = dgv_NhanVienDaCoTrenMay.Rows.Add();
                        for (int itDuyetTimNhanVien2 = 0; itDuyetTimNhanVien2 < dtDuyetTimNhanVien2.Rows.Count; itDuyetTimNhanVien2++)
                        {
                            dgv_NhanVienDaCoTrenMay.Rows[idem2].Cells[1].Value = dtDuyetTimNhanVien2.Rows[itDuyetTimNhanVien2]["ma_nhan_vien"].ToString();
                            dgv_NhanVienDaCoTrenMay.Rows[idem2].Cells[2].Value = dtDuyetTimNhanVien2.Rows[itDuyetTimNhanVien2]["ten_nhan_vien"].ToString();
                            dgv_NhanVienDaCoTrenMay.Rows[idem2].Cells[3].Value = dtDuyetTimNhanVien2.Rows[itDuyetTimNhanVien2]["ma_cham_cong"].ToString();
                            dgv_NhanVienDaCoTrenMay.Rows[idem2].Cells[4].Value = dtDuyetTimNhanVien2.Rows[itDuyetTimNhanVien2]["ten_cham_cong"].ToString();
                            dgv_NhanVienDaCoTrenMay.Rows[idem2].Cells[5].Value = dtDuyetTimNhanVien2.Rows[itDuyetTimNhanVien2]["ma_the"].ToString();
                        }
                    }
                }
                listBoxThongTin.Items.Add("Đã cập nhật vân tay xong");
                if (chk_TaiKhuonMat.Checked)
                {
                    listBoxThongTin.Items.Add("Đã cập nhật khuôn mặt xong");
                }
                axCZKEM1.EnableDevice(_iMachineNumber, bFlag: true);
                return;
            }
            string sTmpData = "";
            int iTmpLength = 0;
            int iFlag = 0;
            dgv_NhanVienMoi.Rows.Clear();
            string sCardnumber = "";
            int idwEnrollNumber = 0;
            string sName = "";
            string sPassword = "";
            int iPrivilege = 0;
            bool bEnabled = false;
            axCZKEM1.EnableDevice(_iMachineNumber, bFlag: false);
            axCZKEM1.ReadAllUserID(_iMachineNumber);
            axCZKEM1.ReadAllTemplate(_iMachineNumber);
            while (axCZKEM1.GetAllUserInfo(iMachineNumber, ref idwEnrollNumber, ref sName, ref sPassword, ref iPrivilege, ref bEnabled))
            {
                for (int idwFingerIndex = 0; idwFingerIndex < 10; idwFingerIndex++)
                {
                    if (axCZKEM1.GetUserTmpStr(iMachineNumber, idwEnrollNumber, idwFingerIndex, ref sTmpData, ref iTmpLength))
                    {
                        _templateCapNhatVanTayDTO.MaChamCong = idwEnrollNumber;
                        _templateCapNhatVanTayDTO.FingerIDCapNhatVanTay = idwFingerIndex;
                        _templateCapNhatVanTayDTO.FlagCapNhatVanTay = iFlag;
                        _templateCapNhatVanTayDTO.FingerTemplateCapNhatVanTay = sTmpData;
                        _templateCapNhatVanTayDTO.FingerVersionCapNhatVanTay = _phienBanVanTay;
                        _templateCapNhatVanTayBLL.TemplateCapNhatVanTayInsert(_templateCapNhatVanTayDTO);
                    }
                }
                //if (axCZKEM1.GetStrCardNumber(out sCardnumber))
                //{
                //    _nhanVienUpdateDTO.MaChamCong = idwEnrollNumber;
                //    _nhanVienUpdateDTO.MaThe = sCardnumber;
                //    _nhanVienUpdateDTO.UserPassWord = sPassword;
                //    _nhanVienUpdateDTO.PhanQuyen = iPrivilege;
                //    _nhanVienUpdateBLL.NhanVienUpdateInsert(_nhanVienUpdateDTO);
                //}
                DataTable dtDuyetTimNhanVien = new DataTable();
                dtDuyetTimNhanVien = _nhanVienBLL.NhanVienGetByMaChamCong(idwEnrollNumber.ToString());
                if (dtDuyetTimNhanVien.Rows.Count == 0)
                {
                    int i = dgv_NhanVienMoi.Rows.Add();
                    if (idwEnrollNumber.ToString().Length == 0)
                    {
                        sMaNhanVien_CapNhatNhanVien = "00000";
                    }
                    if (idwEnrollNumber.ToString().Length == 1)
                    {
                        sMaNhanVien_CapNhatNhanVien = "0000" + idwEnrollNumber;
                    }
                    if (idwEnrollNumber.ToString().Length == 2)
                    {
                        sMaNhanVien_CapNhatNhanVien = "000" + idwEnrollNumber;
                    }
                    if (idwEnrollNumber.ToString().Length == 3)
                    {
                        sMaNhanVien_CapNhatNhanVien = "00" + idwEnrollNumber;
                    }
                    if (idwEnrollNumber.ToString().Length == 4)
                    {
                        sMaNhanVien_CapNhatNhanVien = "0" + idwEnrollNumber;
                    }
                    if (idwEnrollNumber.ToString().Length > 4)
                    {
                        sMaNhanVien_CapNhatNhanVien = idwEnrollNumber.ToString();
                    }
                    dgv_NhanVienMoi.Rows[i].Cells[1].Value = sMaNhanVien_CapNhatNhanVien;
                    dgv_NhanVienMoi.Rows[i].Cells[3].Value = idwEnrollNumber;
                    if (sName == null || sName == "")
                    {
                        dgv_NhanVienMoi.Rows[i].Cells[2].Value = idwEnrollNumber;
                        dgv_NhanVienMoi.Rows[i].Cells[4].Value = idwEnrollNumber;
                    }
                    else
                    {
                        dgv_NhanVienMoi.Rows[i].Cells[2].Value = sName;
                        dgv_NhanVienMoi.Rows[i].Cells[4].Value = sName;
                    }
                    axCZKEM1.GetStrCardNumber(out sCardnumber);
                    if (sCardnumber.Length == 0)
                    {
                        dgv_NhanVienMoi.Rows[i].Cells[5].Value = "0000000000";
                    }
                    if (sCardnumber.Length == 1)
                    {
                        dgv_NhanVienMoi.Rows[i].Cells[5].Value = "000000000" + sCardnumber;
                    }
                    if (sCardnumber.Length == 2)
                    {
                        dgv_NhanVienMoi.Rows[i].Cells[5].Value = "00000000" + sCardnumber;
                    }
                    if (sCardnumber.Length == 3)
                    {
                        dgv_NhanVienMoi.Rows[i].Cells[5].Value = "0000000" + sCardnumber;
                    }
                    if (sCardnumber.Length == 4)
                    {
                        dgv_NhanVienMoi.Rows[i].Cells[5].Value = "000000" + sCardnumber;
                    }
                    if (sCardnumber.Length == 5)
                    {
                        dgv_NhanVienMoi.Rows[i].Cells[5].Value = "00000" + sCardnumber;
                    }
                    if (sCardnumber.Length == 6)
                    {
                        dgv_NhanVienMoi.Rows[i].Cells[5].Value = "0000" + sCardnumber;
                    }
                    if (sCardnumber.Length == 7)
                    {
                        dgv_NhanVienMoi.Rows[i].Cells[5].Value = "000" + sCardnumber;
                    }
                    if (sCardnumber.Length == 8)
                    {
                        dgv_NhanVienMoi.Rows[i].Cells[5].Value = "00" + sCardnumber;
                    }
                    if (sCardnumber.Length == 9)
                    {
                        dgv_NhanVienMoi.Rows[i].Cells[5].Value = "0" + sCardnumber;
                    }
                    if (sCardnumber.Length == 10)
                    {
                        dgv_NhanVienMoi.Rows[i].Cells[5].Value = sCardnumber;
                    }
                    //dgv_NhanVienMoi.Rows[i].Cells[6].Value = sPassword;
                    //dgv_NhanVienMoi.Rows[i].Cells[7].Value = iPrivilege;
                    //dgv_NhanVienMoi.Rows[i].Cells[8].Value = bEnabled;
                    progressBarChay.Maximum = iSoDuLieu;
                    test--;
                    dem++;
                    progressBarChay.Text = (dem + 1) * 100 / iSoDuLieu + "%";
                    Application.DoEvents();
                    _ = iSoDuLieu;
                    _ = 0;
                    if (iSoDuLieu >= 0)
                    {
                        progressBarChay.Value = iSoDuLieu - test;
                    }
                }
                else
                {
                    int idem = dgv_NhanVienDaCoTrenMay.Rows.Add();
                    for (int itDuyetTimNhanVien = 0; itDuyetTimNhanVien < dtDuyetTimNhanVien.Rows.Count; itDuyetTimNhanVien++)
                    {
                        dgv_NhanVienDaCoTrenMay.Rows[idem].Cells[1].Value = dtDuyetTimNhanVien.Rows[itDuyetTimNhanVien]["ma_nhan_vien"].ToString();
                        dgv_NhanVienDaCoTrenMay.Rows[idem].Cells[2].Value = dtDuyetTimNhanVien.Rows[itDuyetTimNhanVien]["ten_nhan_vien"].ToString();
                        dgv_NhanVienDaCoTrenMay.Rows[idem].Cells[3].Value = dtDuyetTimNhanVien.Rows[itDuyetTimNhanVien]["ma_cham_cong"].ToString();
                        dgv_NhanVienDaCoTrenMay.Rows[idem].Cells[4].Value = dtDuyetTimNhanVien.Rows[itDuyetTimNhanVien]["ten_cham_cong"].ToString();
                        dgv_NhanVienDaCoTrenMay.Rows[idem].Cells[5].Value = dtDuyetTimNhanVien.Rows[itDuyetTimNhanVien]["ma_the"].ToString();
                    }
                }
            }
            axCZKEM1.EnableDevice(_iMachineNumber, bFlag: true);
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

        private void btn_ChonTatCa1_Click(object sender, EventArgs e)
        {
            bool _selectAll = false;
            _selectAll = !_selectAll;
            if (_selectAll)
            {
                for (int i = 0; i < dgv_NhanVienDaCoTrenMay.Rows.Count; i++)
                {
                    dgv_NhanVienDaCoTrenMay.Rows[i].Cells[0].Value = _selectAll;
                }
            }
        }

        private void btn_BoChonTatCa1_Click(object sender, EventArgs e)
        {
            bool _selectAll = true;
            _selectAll = !_selectAll;
            if (!_selectAll)
            {
                for (int i = 0; i < dgv_NhanVienDaCoTrenMay.Rows.Count; i++)
                {
                    dgv_NhanVienDaCoTrenMay.Rows[i].Cells[0].Value = _selectAll;
                }
            }
        }

        private void btn_ChonTatCa2_Click(object sender, EventArgs e)
        {
            bool _selectAllNhanVienMoi = false;
            _selectAllNhanVienMoi = !_selectAllNhanVienMoi;
            if (_selectAllNhanVienMoi)
            {
                for (int iNhanVienMoi = 0; iNhanVienMoi < dgv_NhanVienMoi.Rows.Count; iNhanVienMoi++)
                {
                    dgv_NhanVienMoi.Rows[iNhanVienMoi].Cells[0].Value = _selectAllNhanVienMoi;
                }
            }
        }

        private void btn_BoChon2_Click(object sender, EventArgs e)
        {
            bool _selectAllNhanVienMoi = true;
            _selectAllNhanVienMoi = !_selectAllNhanVienMoi;
            if (!_selectAllNhanVienMoi)
            {
                for (int iNhanVienMoi = 0; iNhanVienMoi < dgv_NhanVienMoi.Rows.Count; iNhanVienMoi++)
                {
                    dgv_NhanVienMoi.Rows[iNhanVienMoi].Cells[0].Value = _selectAllNhanVienMoi;
                }
            }
        }

        private void btn_XoaNhanVienTrenMay_Click(object sender, EventArgs e)
        {
            if (sKieuKetNoi == "TCP/IP" && sSuDungWeb == "False")
            {
                Cursor = Cursors.WaitCursor;
                _bIsConnected = axCZKEM1.Connect_Net(sDiaChiIP, Convert.ToInt32(sPort));
                if (!_bIsConnected)
                {
                    RJMessageBox.Show("Không kết nối được với " + sTenMay);
                    Cursor = Cursors.Default;
                }
                else if (sTrangThai == "False")
                {
                    RJMessageBox.Show("Máy chấm công này chưa cho phép sử dụng");
                    Cursor = Cursors.Default;
                    axCZKEM1.Disconnect();
                }
                else
                {
                    kiemTraLoaiMay();
                    XoaNhanVienTrenMayChamCong();
                    Cursor = Cursors.Default;
                    axCZKEM1.Disconnect();
                }
            }
        }

        private void XoaNhanVienTrenMayChamCong()
        {
            int idwErrorCode = 0;
            _ = rdb_XoaVanTay.Checked;
            _ = rdb_XoaKhuonMat.Checked;
            _ = rdb_XoaMatMa.Checked;
            if (!rdb_XoaNhanVien.Checked)
            {
                return;
            }
            if (!_bIsConnected)
            {
                RJMessageBox.Show("Please connect the device first!", "Error");
                return;
            }
            for (int _xoaNhanVien = 0; _xoaNhanVien < dgv_NhanVienDaCoTrenMay.Rows.Count; _xoaNhanVien++)
            {
                if (Convert.ToBoolean(dgv_NhanVienDaCoTrenMay[0, _xoaNhanVien].Value))
                {
                    string sMaChamCongXoaNhanVien = dgv_NhanVienDaCoTrenMay.Rows[_xoaNhanVien].Cells[3].Value.ToString();
                    string sUserID = sMaChamCongXoaNhanVien;
                    int iBackupNumber = 0;
                    Cursor = Cursors.WaitCursor;
                    if (axCZKEM1.SSR_DeleteEnrollData(_iMachineNumber, sUserID, iBackupNumber))
                    {
                        axCZKEM1.RefreshData(_iMachineNumber);
                        RJMessageBox.Show("DeleteEnrollData,UserID=" + sUserID + " BackupNumber=" + iBackupNumber, "Success");
                    }
                    else
                    {
                        axCZKEM1.GetLastError(ref idwErrorCode);
                    }
                    Cursor = Cursors.Default;
                }
            }
            RJMessageBox.Show("Xóa thành công");
        }

        private void cbo_ChonMayChamCong_SelectedIndexChanged(object sender, EventArgs e)
        {
            DataTable dtChonMayChamCong = new DataTable();
            DataRowView vrow = (DataRowView)cbo_ChonMayChamCong.SelectedItem;
            string row = vrow.Row.ItemArray[1].ToString();
            if(row != "")
            {
                _mayChamCongDTO.TenMCC = row;
                dtChonMayChamCong = _mayChamCongBLL.MayChamCongGetAllByTenMCC(_mayChamCongDTO);
                for (int iChonMayChamCong = 0; iChonMayChamCong < dtChonMayChamCong.Rows.Count; iChonMayChamCong++)
                {
                    sTenMay = row;
                    sKieuKetNoi = dtChonMayChamCong.Rows[iChonMayChamCong]["KieuKetNoi"].ToString();
                    sDiaChiIP = dtChonMayChamCong.Rows[iChonMayChamCong]["DiaChiIP"].ToString();
                    sPort = dtChonMayChamCong.Rows[iChonMayChamCong]["Port"].ToString();
                    sDiaChiWeb = dtChonMayChamCong.Rows[iChonMayChamCong]["DiaChiWeb"].ToString();
                    sSuDungWeb = dtChonMayChamCong.Rows[iChonMayChamCong]["SuDungWeb"].ToString();
                    sSerial = dtChonMayChamCong.Rows[iChonMayChamCong]["Serial"].ToString();
                    sSoDangKy = dtChonMayChamCong.Rows[iChonMayChamCong]["SoDangKy"].ToString();
                    sTrangThai = dtChonMayChamCong.Rows[iChonMayChamCong]["TrangThai"].ToString();
                }
            }
        }

        private void btn_TaiVe_Click(object sender, EventArgs e)
        {
            if (rdb_NhanVienMoi.Checked)
            {
                luuNhanVienMoi();
            }
            if (rdb_ToanBoNhanVien.Checked)
            {
                CapNhatChoNhanVienDaCoTrenPhanMem();
                listBoxThongTin.Items.Add("Đã cập nhật vân tay xong");
                if (chk_TaiKhuonMat.Checked)
                {
                    listBoxThongTin.Items.Add("Đã cập nhật khuôn mặt xong");
                }
            }
        }
        private void CapNhatChoNhanVienDaCoTrenPhanMem()
        {
            for (int row = 0; row < dgv_NhanVienDaCoTrenMay.Rows.Count; row++)
            {
                if (Convert.ToBoolean(dgv_NhanVienDaCoTrenMay[0, row].Value))
                {
                    int iMaChamCongCapNhatVanTay = Convert.ToInt32(dgv_NhanVienDaCoTrenMay.Rows[row].Cells[3].Value.ToString());
                    DataTable dtCapNhatVanTayChoNhanVien = new DataTable();
                    _templateCapNhatVanTayDTO.MaChamCong = iMaChamCongCapNhatVanTay;
                    dtCapNhatVanTayChoNhanVien = _templateCapNhatVanTayBLL.TemplateCapNhatVanTayGetByMaChamCong(_templateCapNhatVanTayDTO.MaChamCong);
                    for (int iCapNhatVanTayChoNhanVien = 0; iCapNhatVanTayChoNhanVien < dtCapNhatVanTayChoNhanVien.Rows.Count; iCapNhatVanTayChoNhanVien++)
                    {
                        _templateDTO.MaChamCong = Convert.ToInt32(dtCapNhatVanTayChoNhanVien.Rows[iCapNhatVanTayChoNhanVien]["ma_cham_cong"].ToString());
                        _templateDTO.FingerID = Convert.ToInt32(dtCapNhatVanTayChoNhanVien.Rows[iCapNhatVanTayChoNhanVien]["fingerid_capnhatvantay"].ToString());
                        _templateDTO.Flag = Convert.ToInt32(dtCapNhatVanTayChoNhanVien.Rows[iCapNhatVanTayChoNhanVien]["flag_capnhatvantay"].ToString());
                        _templateDTO.FingerTemplate = dtCapNhatVanTayChoNhanVien.Rows[iCapNhatVanTayChoNhanVien]["fingertemplate_capnhatvantay"].ToString();
                        _templateDTO.FingerVersion = dtCapNhatVanTayChoNhanVien.Rows[iCapNhatVanTayChoNhanVien]["fingerversion_capnhatvantay"].ToString();
                        _templateBLL.ThemTemplate(_templateDTO);
                    }
                    // cập nhật toàn bộ nhân viên
                    //DataTable dtCaphatThongTinChoNhanVien = new DataTable();
                    //_nhanVienUpdateDTO.MaChamCong = iMaChamCongCapNhatVanTay;
                    //dtCaphatThongTinChoNhanVien = _nhanVienUpdateBLL.NhanVienUpdateGetByMaChamCong(_nhanVienUpdateDTO);
                    //for (int iCapNhatThongTinChoNhanVien = 0; iCapNhatThongTinChoNhanVien < dtCaphatThongTinChoNhanVien.Rows.Count; iCapNhatThongTinChoNhanVien++)
                    //{
                    //    _nhanVienDTO.Ma_Cham_Cong = dtCaphatThongTinChoNhanVien.Rows[iCapNhatThongTinChoNhanVien]["MaChamCong"].ToString();
                    //    _nhanVienDTO.Ma_The = dtCaphatThongTinChoNhanVien.Rows[iCapNhatThongTinChoNhanVien]["MaThe"].ToString();
                    //    _nhanVienBLL.NhanVienUpdateToanBoNhanVien(_nhanVienDTO);
                    //}
                }
            }
        }
        private void luuNhanVienMoi()
        {
            int DemNhanVien_LuuVanTay = 0;
            int DemVanTay_LuuVanTay = 0;
            int KTGT = 1;
            for (int row = 0; row < dgv_NhanVienMoi.Rows.Count; row++)
            {
                if (!Convert.ToBoolean(dgv_NhanVienMoi[0, row].Value))
                {
                    continue;
                }
                row.ToString();
                string sMaNhanVien = dgv_NhanVienMoi.Rows[row].Cells[1].Value.ToString();
                string sTenNhanVien = dgv_NhanVienMoi.Rows[row].Cells[2].Value.ToString();
                string sMaChamCong = dgv_NhanVienMoi.Rows[row].Cells[3].Value.ToString();
                string sTenChamCong = dgv_NhanVienMoi.Rows[row].Cells[4].Value.ToString();
                string sMaThe = dgv_NhanVienMoi.Rows[row].Cells[5].Value.ToString();
                string sMatKhau = dgv_NhanVienMoi.Rows[row].Cells[6].Value.ToString();
                string sPhanQuyen = dgv_NhanVienMoi.Rows[row].Cells[7].Value.ToString();
                string sEnable = dgv_NhanVienMoi.Rows[row].Cells[8].Value.ToString();
                _nhanVienDTO.Ma_so_value = sMaNhanVien;
                _nhanVienDTO.Ten_value = provider.cat_ho_ten(sTenNhanVien,2);
                _nhanVienDTO.Ho_lot_value = provider.cat_ho_ten(sTenNhanVien,3);
                _nhanVienDTO.Ho_ten_value = sTenNhanVien;
                _nhanVienDTO.Ma_Cham_Cong = sMaChamCong;
                _nhanVienDTO.Ten_Cham_Cong = sTenChamCong;
                if (sMaThe.Length == 0)
                {
                    _nhanVienDTO.Ma_The = "0000000000";
                }
                if (sMaThe.Length == 1)
                {
                    _nhanVienDTO.Ma_The = "000000000" + sMaThe;
                }
                if (sMaThe.Length == 2)
                {
                    _nhanVienDTO.Ma_The = "00000000" + sMaThe;
                }
                if (sMaThe.Length == 3)
                {
                    _nhanVienDTO.Ma_The = "0000000" + sMaThe;
                }
                if (sMaThe.Length == 4)
                {
                    _nhanVienDTO.Ma_The = "000000" + sMaThe;
                }
                if (sMaThe.Length == 5)
                {
                    _nhanVienDTO.Ma_The = "00000" + sMaThe;
                }
                if (sMaThe.Length == 6)
                {
                    _nhanVienDTO.Ma_The = "0000" + sMaThe;
                }
                if (sMaThe.Length == 7)
                {
                    _nhanVienDTO.Ma_The = "000" + sMaThe;
                }
                if (sMaThe.Length == 8)
                {
                    _nhanVienDTO.Ma_The = "00" + sMaThe;
                }
                if (sMaThe.Length == 9)
                {
                    _nhanVienDTO.Ma_The = "0" + sMaThe;
                }
                if (sMaThe.Length == 10)
                {
                    _nhanVienDTO.Ma_The = sMaThe;
                }
                _nhanVienDTO.Gioi_tinh_value = KTGT;
                _nhanVienDTO.Ngay_vao_lam_value = DateTime.Now;
                _nhanVienDTO.Ngay_sinh_value = DateTime.Now;
                _nhanVienDTO.Cccd_value = "";
                _nhanVienDTO.Sdt_value = "";
                _nhanVienDTO.Email_value = "";
                _nhanVienBLL.Insert_NhanVienFromDevice(_nhanVienDTO);
                //string sMaLichTrinhVaoRa = "";
                //DataTable dtLichTrinhVaoRa = new DataTable();
                //dtLichTrinhVaoRa = _lichTrinhVaoRaBLL.GETDANHSACH_LICHTRINHVAORA();
                //if (dtLichTrinhVaoRa.Rows.Count != 0)
                //{
                //    sMaLichTrinhVaoRa = dtLichTrinhVaoRa.Rows[0]["MaLichTrinhVaoRa"].ToString();
                //}
                //string sMaLichTrinhCaLamViec = "";
                //DataTable dtLichTrinhCaLamViec = new DataTable();
                //dtLichTrinhCaLamViec = _lichTrinhChoCaLamViecBLL.GET_DANHSACH_LICHTRINHCHOCALAMVIEC();
                //if (dtLichTrinhCaLamViec.Rows.Count != 0)
                //{
                //    sMaLichTrinhCaLamViec = dtLichTrinhCaLamViec.Rows[0]["MaLichTrinhCaLamViec"].ToString();
                //}
                //if (sMaLichTrinhVaoRa != "" && sMaLichTrinhCaLamViec != "")
                //{
                //    _sapXepLichTrinhChoNhanVienDTO.MaChamCong = Convert.ToInt32(dgv_NhanVienMoi.Rows[row].Cells[3].Value.ToString());
                //    _sapXepLichTrinhChoNhanVienDTO.MaLichTrinhVaoRa = "LTVR00001";
                //    _sapXepLichTrinhChoNhanVienDTO.MaLichTrinhCaLamViec = "LTCLV00001";
                //    _sapXepLichTrinhChoNhanVienBLL.Insert_SapXepLichTrinhChoNhanVien(_sapXepLichTrinhChoNhanVienDTO);
                //}
                if (chk_TaiVanTay.Checked)
                {
                    DataTable selectVT = new DataTable();
                    _commonDTO.MaChamCong = Convert.ToInt32(sMaChamCong);
                    selectVT = _commonBLL.SelectTemplateVirtualByMaChamCong(Convert.ToInt32(sMaChamCong));
                    for (int selectLuuVT = 0; selectLuuVT < selectVT.Rows.Count; selectLuuVT++)
                    {
                        _templateDTO.MaChamCong = Convert.ToInt32(selectVT.Rows[selectLuuVT]["ma_cham_cong"].ToString());
                        _templateDTO.FingerID = Convert.ToInt32(selectVT.Rows[selectLuuVT]["fingeridvirtual"].ToString());
                        _templateDTO.Flag = Convert.ToInt32(selectVT.Rows[selectLuuVT]["flagvirtual"].ToString());
                        _templateDTO.FingerTemplate = selectVT.Rows[selectLuuVT]["fingertemplatevirtual"].ToString();
                        _templateDTO.FingerVersion = selectVT.Rows[selectLuuVT]["fingerversionvirtual"].ToString();
                        _templateBLL.ThemTemplate(_templateDTO);
                        DemVanTay_LuuVanTay++;
                    }
                }
                DemNhanVien_LuuVanTay++;
                btn_TaiVe.Text = "Tải về: " + DemNhanVien_LuuVanTay;
                Application.DoEvents();
            }
            if (chk_TaiKhuonMat.Checked)
            {
                listBoxThongTin.Items.Add("Số khuôn mặt vừa tải: " + iDemKhuonMat);
            }
            listBoxThongTin.Items.Add("Số nhân viên vừa tải: " + DemNhanVien_LuuVanTay);
            listBoxThongTin.Items.Add("Số vân tay: " + DemVanTay_LuuVanTay);
            _commonBLL.DeleteALLTemplateVirtual();
        }
        private void btn_close_Click(object sender, EventArgs e)
        {
            provider.btn_close(this.Parent);
        }
    }
}
