using System;
using System.Collections.Generic;
using System.Data;
using System.Net;
using System.Windows.Forms;
using TENTAC_HRM.BusinessLogicLayer.MayChamCong;
using TENTAC_HRM.BusinessLogicLayer.QuanLyNhanVienBLL;
using TENTAC_HRM.Custom;
using TENTAC_HRM.DataAccessLayer.MayChamCong.DuLieuMayChamCongDAL;
using TENTAC_HRM.DataTransferObject.MayChamCong;
using TENTAC_HRM.Model;
using zkemkeeper;

namespace TENTAC_HRM.Forms.May_Cham_Cong
{
    public partial class uc_taitudong : UserControl
    {
        DataProvider provider = new DataProvider();
        public CZKEMClass axCZKEM1 = new CZKEMClass();

        public bool bIsConnected;

        public int iMachineNumber;

        private NhanVienBLL _nhanVienBLL = new NhanVienBLL();
        private Nhanvien_model _nhanVienDTO = new Nhanvien_model();
        private MayChamCongBLL _mayChamCongBLL = new MayChamCongBLL();
        private MayChamCongDTO _mayChamCongDTO = new MayChamCongDTO();
        private CheckInOut_model _checkInOutDTO = new CheckInOut_model();

        private CheckInOut_BLL _checkInOutBLL = new CheckInOut_BLL();

        private string sMaMayChamCong;

        private string sTenMayChamCong;

        private string sIDMayChamCong;

        private string sKieuKetNoi;

        private string sDiaChiIP;

        private string sPort;

        private string sCongCOM;

        private string sTocDoTruyen;

        private string sDiaChiWeb;

        private string sSuDungWeb;

        private string sTrangThai;

        private string sSerial;

        private string sSoDangKy;

        private int _kiemTraManHinh = 0;

        private string _loaiManHinh;

        private int a;

        private int b;

        private int c;

        private string _ketQua;

        private string _a;
        private int iTongCount;
        private string _b;
        private int iDemLanTaiTheoThoiGian;
        private string _c;
        private int iChonCachTai;
        private string sdwSerialNumber;
        private string sVersion;
        private double dYearVersion;
        private int iValue = 0;
        private int iDemLanTaiDauTien;
        public static uc_taitudong _instance;
        public static uc_taitudong Instance
        {
            get
            {
                _instance = new uc_taitudong();
                return _instance;
            }
        }
        public uc_taitudong()
        {
            InitializeComponent();
        }

        private void uc_taitudong_Load(object sender, EventArgs e)
        {
            DateTime dTuNgayTai = new DateTime(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day, 1, 0, 0);
            DateTime dDenNgayTai = new DateTime(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day, 23, 59, 0);
            etime_log.Value = dDenNgayTai;
            stime_log.Value = dTuNgayTai;
            DGVMayChamCong.Columns.Insert(0, new DataGridViewCheckBoxColumn());
            DGVMayChamCong.Columns[0].Width = 30;
            loadMayChamCong();
            comboBoxLuaChonTai.SelectedIndex = 0;
        }
        private void loadMayChamCong()
        {
            DataTable dtMayChamCong = new DataTable();
            dtMayChamCong = _mayChamCongBLL.GETDANHSACHMCC();
            for (int iMayChamCong = 0; iMayChamCong < dtMayChamCong.Rows.Count; iMayChamCong++)
            {
                int addMayChamCong = DGVMayChamCong.Rows.Add();
                DGVMayChamCong.Rows[addMayChamCong].Cells[1].Value = dtMayChamCong.Rows[iMayChamCong]["MaMCC"].ToString();
                DGVMayChamCong.Rows[addMayChamCong].Cells[2].Value = dtMayChamCong.Rows[iMayChamCong]["TenMCC"].ToString();
                DGVMayChamCong.Rows[addMayChamCong].Cells[3].Value = dtMayChamCong.Rows[iMayChamCong]["IDMCC"].ToString();
                DGVMayChamCong.Rows[addMayChamCong].Cells[4].Value = dtMayChamCong.Rows[iMayChamCong]["KieuKetNoi"].ToString();
                DGVMayChamCong.Rows[addMayChamCong].Cells[5].Value = dtMayChamCong.Rows[iMayChamCong]["DiaChiIP"].ToString();
                DGVMayChamCong.Rows[addMayChamCong].Cells[6].Value = dtMayChamCong.Rows[iMayChamCong]["Port"].ToString();
                DGVMayChamCong.Rows[addMayChamCong].Cells[7].Value = dtMayChamCong.Rows[iMayChamCong]["CongCOM"].ToString();
                DGVMayChamCong.Rows[addMayChamCong].Cells[8].Value = dtMayChamCong.Rows[iMayChamCong]["TocDoTruyen"].ToString();
                DGVMayChamCong.Rows[addMayChamCong].Cells[9].Value = dtMayChamCong.Rows[iMayChamCong]["DiaChiWeb"].ToString();
                DGVMayChamCong.Rows[addMayChamCong].Cells[10].Value = dtMayChamCong.Rows[iMayChamCong]["SuDungWeb"].ToString();
                DGVMayChamCong.Rows[addMayChamCong].Cells[11].Value = dtMayChamCong.Rows[iMayChamCong]["TrangThai"].ToString();
                DGVMayChamCong.Rows[addMayChamCong].Cells[12].Value = dtMayChamCong.Rows[iMayChamCong]["Serial"].ToString();
                DGVMayChamCong.Rows[addMayChamCong].Cells[13].Value = dtMayChamCong.Rows[iMayChamCong]["SoDangKy"].ToString();
            }
        }
        private void ChonTatCaMenu_Click(object sender, EventArgs e)
        {
            bool _selectAllMayChamCong = false;
            _selectAllMayChamCong = !_selectAllMayChamCong;
            if (_selectAllMayChamCong)
            {
                for (int iMayChamCong = 0; iMayChamCong < DGVMayChamCong.Rows.Count; iMayChamCong++)
                {
                    DGVMayChamCong.Rows[iMayChamCong].Cells[0].Value = _selectAllMayChamCong;
                }
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
        private void BoChonTatCaMenu_Click(object sender, EventArgs e)
        {
            bool _selectAllMayChamCong = true;
            _selectAllMayChamCong = !_selectAllMayChamCong;
            if (!_selectAllMayChamCong)
            {
                for (int iMayChamCong = 0; iMayChamCong < DGVMayChamCong.Rows.Count; iMayChamCong++)
                {
                    DGVMayChamCong.Rows[iMayChamCong].Cells[0].Value = _selectAllMayChamCong;
                }
            }
        }

        private void TaiLaiDanhSachMayChamCongMenu_Click(object sender, EventArgs e)
        {
            DGVMayChamCong.Rows.Clear();
            loadMayChamCong();
        }

        private void btn_close_Click(object sender, EventArgs e)
        {
            provider.btn_close(this.Parent);
        }

        private void btnTaiDuLieu_Click(object sender, EventArgs e)
        {
            iDemLanTaiDauTien = 0;
            DataTable dtMayChamCong = new DataTable();
            dtMayChamCong = _mayChamCongBLL.GETDANHSACHMCC();
            for (int iMayChamCong = 0; iMayChamCong < dtMayChamCong.Rows.Count; iMayChamCong++)
            {
                sSerial = dtMayChamCong.Rows[iMayChamCong]["Serial"].ToString();
                DataTable dtCheckMCC = new DataTable();
                _mayChamCongDTO.Serial = sSerial;
                dtCheckMCC = _mayChamCongBLL.MayChamCongGetBySerial(_mayChamCongDTO);
                if (dtCheckMCC.Rows.Count >= 2 && dtMayChamCong.Rows[iMayChamCong]["Serial"].ToString() != "")
                {
                    MessageBox.Show("Máy chấm công trùng serial, Không được phép tải");
                    return;
                }
            }
            DGVGioTai.Rows.Clear();
            List<string> danhsachmachamcongcanlay = new List<string>();
            for (int iChonMayChamCong = 0; iChonMayChamCong < DGVMayChamCong.Rows.Count; iChonMayChamCong++)
            {
                if (Convert.ToBoolean(DGVMayChamCong[0, iChonMayChamCong].Value))
                {
                    danhsachmachamcongcanlay.Add(DGVMayChamCong.Rows[iChonMayChamCong].Cells[3].Value.ToString());
                }
            }
            if (comboBoxLuaChonTai.SelectedIndex == 1 && chk_xoagio.Checked == true && danhsachmachamcongcanlay.Count > 0)
            {
                string sql = $"delete tbl_CheckInOut " +
                    $"where NgayCham >= '{Convert.ToDateTime(stime_log.Text).ToString("yyyy/MM/dd 00:00:00")}' " +
                    $"and NgayCham <= '{Convert.ToDateTime(etime_log.Text).ToString("yyyy/MM/dd 00:00:00")}' " +
                    $"and MaSoMay in ('{string.Join("','", danhsachmachamcongcanlay)}')";
                SQLHelper.ExecuteSql(sql);
            }
            for (int iChonMayChamCong = 0; iChonMayChamCong < DGVMayChamCong.Rows.Count; iChonMayChamCong++)
            {
                sdwSerialNumber = "";
                if (!Convert.ToBoolean(DGVMayChamCong[0, iChonMayChamCong].Value))
                {
                    continue;
                }
                sMaMayChamCong = DGVMayChamCong.Rows[iChonMayChamCong].Cells[1].Value.ToString();
                sTenMayChamCong = DGVMayChamCong.Rows[iChonMayChamCong].Cells[2].Value.ToString();
                ListBoxThongBao.Items.Add("Đang gọi " + sTenMayChamCong);
                Application.DoEvents();
                sIDMayChamCong = DGVMayChamCong.Rows[iChonMayChamCong].Cells[3].Value.ToString();
                sKieuKetNoi = DGVMayChamCong.Rows[iChonMayChamCong].Cells[4].Value.ToString();
                sDiaChiIP = DGVMayChamCong.Rows[iChonMayChamCong].Cells[5].Value.ToString();
                sPort = DGVMayChamCong.Rows[iChonMayChamCong].Cells[6].Value.ToString();
                sCongCOM = DGVMayChamCong.Rows[iChonMayChamCong].Cells[7].Value.ToString();
                sTocDoTruyen = DGVMayChamCong.Rows[iChonMayChamCong].Cells[8].Value.ToString();
                sDiaChiWeb = DGVMayChamCong.Rows[iChonMayChamCong].Cells[9].Value.ToString();
                sSuDungWeb = DGVMayChamCong.Rows[iChonMayChamCong].Cells[10].Value.ToString();
                sTrangThai = DGVMayChamCong.Rows[iChonMayChamCong].Cells[11].Value.ToString();
                sSerial = DGVMayChamCong.Rows[iChonMayChamCong].Cells[12].Value.ToString();
                sSoDangKy = DGVMayChamCong.Rows[iChonMayChamCong].Cells[13].Value.ToString();
                if (sTrangThai == "True")
                {
                    if (sKieuKetNoi == "TCP/IP")
                    {
                        if (sSuDungWeb == "False")
                        {
                            int idwErrorCode = 0;
                            Cursor = Cursors.WaitCursor;
                            bIsConnected = axCZKEM1.Connect_Net(sDiaChiIP, Convert.ToInt32(sPort));
                            if (!bIsConnected)
                            {
                                axCZKEM1.GetLastError(ref idwErrorCode);
                                ListBoxThongBao.Items.Add("Không kết nối được với " + sTenMayChamCong);
                                Application.DoEvents();
                                Cursor = Cursors.Default;
                            }
                            else
                            {
                                if (axCZKEM1.GetSerialNumber(iMachineNumber, out sdwSerialNumber))
                                {
                                    sSerial = sdwSerialNumber;
                                }
                                _ketQua = "";
                                if (sSoDangKy == "" || sSoDangKy == null)
                                {
                                    ListBoxThongBao.Items.Add(sTenMayChamCong + " chưa được đăng ký");
                                    Application.DoEvents();
                                    axCZKEM1.Disconnect();
                                    Cursor = Cursors.Default;
                                    continue;
                                }
                                if (sSoDangKy != _ketQua.ToString())
                                {
                                    ListBoxThongBao.Items.Add(sTenMayChamCong + " chưa được đăng ký");
                                    Application.DoEvents();
                                    axCZKEM1.Disconnect();
                                    Cursor = Cursors.Default;
                                    continue;
                                }
                                ListBoxThongBao.Items.Add("Đang kết nối với " + sTenMayChamCong);
                                Application.DoEvents();
                                kiemTraLoaiMay();
                                TaiDuLieuChamCong();
                                axCZKEM1.Disconnect();
                                Cursor = Cursors.Default;
                                ListBoxThongBao.Items.Add("Tải " + sTenMayChamCong + " hoàn thành");
                            }
                        }
                        else
                        {
                            IPHostEntry hostname = Dns.GetHostByName(sDiaChiWeb);
                            IPAddress[] ip = hostname.AddressList;
                            string _IpWeb = ip[0].ToString();
                            Cursor = Cursors.WaitCursor;
                            bIsConnected = axCZKEM1.Connect_Net(_IpWeb, Convert.ToInt32(sPort));
                            if (!bIsConnected)
                            {
                                ListBoxThongBao.Items.Add("Không kết nối được với " + sTenMayChamCong);
                                Application.DoEvents();
                                Cursor = Cursors.Default;
                            }
                            else
                            {
                                if (axCZKEM1.GetSerialNumber(iMachineNumber, out sdwSerialNumber))
                                {
                                    sSerial = sdwSerialNumber;
                                }
                                if (sSoDangKy == "" || sSoDangKy == null)
                                {
                                    ListBoxThongBao.Items.Add(sTenMayChamCong + " chưa được đăng ký");
                                    Application.DoEvents();
                                    axCZKEM1.Disconnect();
                                    Cursor = Cursors.Default;
                                    continue;
                                }
                                if (sSoDangKy != _ketQua.ToString())
                                {
                                    ListBoxThongBao.Items.Add(sTenMayChamCong + " chưa được đăng ký");
                                    Application.DoEvents();
                                    axCZKEM1.Disconnect();
                                    Cursor = Cursors.Default;
                                    continue;
                                }
                                ListBoxThongBao.Items.Add("Đang kết nối với " + sTenMayChamCong);
                                Application.DoEvents();
                                kiemTraLoaiMay();
                                TaiDuLieuChamCong();
                                axCZKEM1.Disconnect();
                                Cursor = Cursors.Default;
                                ListBoxThongBao.Items.Add("Tải " + sTenMayChamCong + " hoàn thành");
                            }
                        }
                    }
                    _ = sKieuKetNoi == "RS232/484";
                    if (sKieuKetNoi == "USB")
                    {
                        int _iMachineNumber = 1;
                        Cursor = Cursors.WaitCursor;
                        bIsConnected = axCZKEM1.Connect_USB(_iMachineNumber);
                        if (!bIsConnected)
                        {
                            MessageBox.Show("Không kết nối được với " + sTenMayChamCong);
                            Cursor = Cursors.Default;
                            break;
                        }
                        axCZKEM1.RegEvent(_iMachineNumber, 65535);
                        ListBoxThongBao.Items.Add("Đang kết nối với " + sTenMayChamCong);
                        Application.DoEvents();
                        kiemTraLoaiMay();
                        TaiDuLieuChamCong();
                        axCZKEM1.Disconnect();
                        Cursor = Cursors.Default;
                        ListBoxThongBao.Items.Add("Tải " + sTenMayChamCong + " hoàn thành");
                    }
                }
                else
                {
                    ListBoxThongBao.Items.Add(sTenMayChamCong + " chưa cho phép sử dụng");
                    Application.DoEvents();
                }
                progressBarTaiDuLieu.Value = 0;
                progressBarTaiDuLieu.Text = "0%";
            }
        }
        private void TaiDuLieuChamCong()
        {
            try
            {
                axCZKEM1.GetDeviceStatus(iMachineNumber, 6, ref iValue);
                try
                {
                    if (axCZKEM1.GetFirmwareVersion(iMachineNumber, ref sVersion))
                    {
                        dYearVersion = Convert.ToDouble(sVersion.Substring(16));
                    }
                }
                catch
                {
                }
                if (iDemLanTaiDauTien == 0)
                {
                    iChonCachTai = comboBoxLuaChonTai.SelectedIndex;
                }
                int dem = -1;
                int test = iValue;
                if (_loaiManHinh == "0")
                {
                    string sdwEnrollNumber = "";
                    int idwVerifyMode = 0;
                    int idwInOutMode = 0;
                    int idwYear = 0;
                    int idwMonth2 = 0;
                    int idwDay2 = 0;
                    int idwHour2 = 0;
                    int idwMinute2 = 0;
                    int idwSecond2 = 0;
                    int idwWorkcode = 0;
                    int idwErrorCode2 = 0;
                    int iCount1 = 0;
                    axCZKEM1.EnableDevice(iMachineNumber, bFlag: false);
                    if (comboBoxLuaChonTai.SelectedIndex == 2)
                    {
                        int i3 = 0;
                        DataTable dtCheckInOut8 = new DataTable();
                        dtCheckInOut8 = _checkInOutBLL.CountAll_CheckInOut();
                        try
                        {
                            iCount1 = Convert.ToInt32(dtCheckInOut8.Rows[i3]["Column1"].ToString());
                        }
                        catch
                        {
                        }
                        if (axCZKEM1.ReadGeneralLogData(iMachineNumber))
                        {
                            while (axCZKEM1.SSR_GetGeneralLogData(iMachineNumber, out sdwEnrollNumber, out idwVerifyMode, out idwInOutMode, out idwYear, out idwMonth2, out idwDay2, out idwHour2, out idwMinute2, out idwSecond2, ref idwWorkcode))
                            {
                                if (sdwEnrollNumber == "Ec925")
                                {
                                    continue;
                                }
                                DateTime dNgayCham11 = default(DateTime);
                                DateTime dGioCham12 = default(DateTime);
                                try
                                {
                                    dNgayCham11 = new DateTime(idwYear, idwMonth2, idwDay2, 0, 0, 0);
                                    dGioCham12 = new DateTime(idwYear, idwMonth2, idwDay2, idwHour2, idwMinute2, idwSecond2);
                                }
                                catch
                                {
                                }
                                if (iDemLanTaiTheoThoiGian != 0)
                                {
                                    DateTime dNgayKiemTra6 = new DateTime(idwYear, idwMonth2, idwDay2);
                                    DateTime dTuNgay6 = Convert.ToDateTime(stime_log.Text);
                                    DateTime dDenNgay6 = Convert.ToDateTime(etime_log.Text);
                                    DateTime dTuNgay14 = new DateTime(dTuNgay6.Year, dTuNgay6.Month, dTuNgay6.Day, 0, 0, 0);
                                    DateTime DenNgay7 = new DateTime(dDenNgay6.Year, dDenNgay6.Month, dDenNgay6.Day, 0, 0, 0);
                                    if (dNgayKiemTra6 >= dTuNgay14 && dNgayKiemTra6 <= DenNgay7)
                                    {
                                        dNgayCham11 = new DateTime(idwYear, idwMonth2, idwDay2, 0, 0, 0);
                                        dGioCham12 = new DateTime(idwYear, idwMonth2, idwDay2, idwHour2, idwMinute2, idwSecond2);
                                        int addGioChamCong12 = DGVGioTai.Rows.Add();
                                        DGVGioTai.Rows[addGioChamCong12].Cells[0].Value = sdwEnrollNumber;
                                        DGVGioTai.Rows[addGioChamCong12].Cells[1].Value = dNgayCham11.ToString("yyyy/MM/dd");
                                        DGVGioTai.Rows[addGioChamCong12].Cells[2].Value = dGioCham12.ToString("yyyy/MM/dd HH:mm:ss");
                                        DGVGioTai.Rows[addGioChamCong12].Cells[3].Value = idwInOutMode.ToString();
                                        DGVGioTai.Rows[addGioChamCong12].Cells[4].Value = idwVerifyMode.ToString();
                                        DGVGioTai.Rows[addGioChamCong12].Cells[5].Value = sIDMayChamCong;
                                        DGVGioTai.Rows[addGioChamCong12].Cells[6].Value = sTenMayChamCong;
                                        DataTable dtKiemTraNhanVien12 = new DataTable();
                                        _nhanVienDTO.Ma_Cham_Cong = sdwEnrollNumber;
                                        dtKiemTraNhanVien12 = _nhanVienBLL.NhanVienGetByMaChamCong(_nhanVienDTO.Ma_Cham_Cong);
                                        if (dtKiemTraNhanVien12.Rows.Count == 1)
                                        {
                                            _checkInOutDTO.Ma_Cham_Cong = Convert.ToInt32(DGVGioTai.Rows[addGioChamCong12].Cells[0].Value.ToString());
                                            _checkInOutDTO.Ngay_Cham = Convert.ToDateTime(DGVGioTai.Rows[addGioChamCong12].Cells[1].Value.ToString());
                                            _checkInOutDTO.Gio_Cham = Convert.ToDateTime(DGVGioTai.Rows[addGioChamCong12].Cells[2].Value.ToString());
                                            _checkInOutDTO.Kieu_Cham = DGVGioTai.Rows[addGioChamCong12].Cells[3].Value.ToString();
                                            _checkInOutDTO.Nguon_Cham = DGVGioTai.Rows[addGioChamCong12].Cells[4].Value.ToString();
                                            _checkInOutDTO.MaSo_May = Convert.ToInt32(DGVGioTai.Rows[addGioChamCong12].Cells[5].Value.ToString());
                                            _checkInOutDTO.Ten_May = DGVGioTai.Rows[addGioChamCong12].Cells[6].Value.ToString();
                                            _checkInOutBLL.Insert_CheckinOut(_checkInOutDTO);
                                        }
                                    }
                                }
                                else
                                {
                                    int addGioChamCong13 = DGVGioTai.Rows.Add();
                                    DGVGioTai.Rows[addGioChamCong13].Cells[0].Value = sdwEnrollNumber;
                                    DGVGioTai.Rows[addGioChamCong13].Cells[1].Value = dNgayCham11.ToString("yyyy/MM/dd");
                                    DGVGioTai.Rows[addGioChamCong13].Cells[2].Value = dGioCham12.ToString("yyyy/MM/dd HH:mm:ss");
                                    DGVGioTai.Rows[addGioChamCong13].Cells[3].Value = idwInOutMode.ToString();
                                    DGVGioTai.Rows[addGioChamCong13].Cells[4].Value = idwVerifyMode.ToString();
                                    DGVGioTai.Rows[addGioChamCong13].Cells[5].Value = sIDMayChamCong;
                                    DGVGioTai.Rows[addGioChamCong13].Cells[6].Value = sTenMayChamCong;
                                    DataTable dtKiemTraNhanVien13 = new DataTable();
                                    _nhanVienDTO.Ma_Cham_Cong = sdwEnrollNumber;
                                    dtKiemTraNhanVien13 = _nhanVienBLL.NhanVienGetByMaChamCong(_nhanVienDTO.Ma_Cham_Cong);
                                    if (dtKiemTraNhanVien13.Rows.Count == 1)
                                    {
                                        _checkInOutDTO.Ma_Cham_Cong = Convert.ToInt32(DGVGioTai.Rows[addGioChamCong13].Cells[0].Value.ToString());
                                        _checkInOutDTO.Ngay_Cham = Convert.ToDateTime(DGVGioTai.Rows[addGioChamCong13].Cells[1].Value.ToString());
                                        _checkInOutDTO.Gio_Cham = Convert.ToDateTime(DGVGioTai.Rows[addGioChamCong13].Cells[2].Value.ToString());
                                        _checkInOutDTO.Kieu_Cham = DGVGioTai.Rows[addGioChamCong13].Cells[3].Value.ToString();
                                        _checkInOutDTO.Nguon_Cham = DGVGioTai.Rows[addGioChamCong13].Cells[4].Value.ToString();
                                        _checkInOutDTO.MaSo_May = Convert.ToInt32(DGVGioTai.Rows[addGioChamCong13].Cells[5].Value.ToString());
                                        _checkInOutDTO.Ten_May = DGVGioTai.Rows[addGioChamCong13].Cells[6].Value.ToString();
                                        _checkInOutBLL.Insert_CheckinOut(_checkInOutDTO);
                                    }
                                }
                                progressBarTaiDuLieu.Maximum = iValue;
                                test--;
                                dem++;
                                progressBarTaiDuLieu.Text = (dem + 1) * 100 / iValue + "%";
                                Application.DoEvents();
                                _ = iValue;
                                _ = 0;
                                if (iValue >= 0)
                                {
                                    progressBarTaiDuLieu.Value = iValue - test;
                                }
                            }
                            int i13 = 0;
                            int iCount10 = 0;
                            DataTable dtCheckInOut19 = new DataTable();
                            dtCheckInOut19 = _checkInOutBLL.CountAll_CheckInOut();
                            try
                            {
                                iCount10 = Convert.ToInt32(dtCheckInOut19.Rows[i13]["Column1"].ToString());
                            }
                            catch
                            {
                            }
                            iTongCount += iCount10 - iCount1;
                            btnTaiDuLieu.Text = "Dữ Liệu mới: " + iTongCount;
                        }
                        else
                        {
                            Cursor = Cursors.Default;
                            axCZKEM1.GetLastError(ref idwErrorCode2);
                            if (dYearVersion < 2018.0)
                            {
                                comboBoxLuaChonTai.SelectedIndex = 1;
                                DataTable dtCheckInOut10 = new DataTable();
                                dtCheckInOut10 = _checkInOutBLL.CountAll_CheckInOut();
                                try
                                {
                                    iCount1 = Convert.ToInt32(dtCheckInOut10.Rows[i3]["Column1"].ToString());
                                }
                                catch
                                {
                                }
                                if (axCZKEM1.ReadGeneralLogData(iMachineNumber))
                                {
                                    while (axCZKEM1.SSR_GetGeneralLogData(iMachineNumber, out sdwEnrollNumber, out idwVerifyMode, out idwInOutMode, out idwYear, out idwMonth2, out idwDay2, out idwHour2, out idwMinute2, out idwSecond2, ref idwWorkcode))
                                    {
                                        if (sdwEnrollNumber == "Ec925")
                                        {
                                            continue;
                                        }
                                        DateTime dNgayCham12 = default(DateTime);
                                        DateTime dGioCham11 = default(DateTime);
                                        try
                                        {
                                            dNgayCham12 = new DateTime(idwYear, idwMonth2, idwDay2, 0, 0, 0);
                                            dGioCham11 = new DateTime(idwYear, idwMonth2, idwDay2, idwHour2, idwMinute2, idwSecond2);
                                        }
                                        catch
                                        {
                                        }
                                        DateTime dNgayKiemTra7 = new DateTime(idwYear, idwMonth2, idwDay2);
                                        DateTime dTuNgay7 = Convert.ToDateTime(stime_log.Text);
                                        DateTime dDenNgay7 = Convert.ToDateTime(etime_log.Text);
                                        DateTime dTuNgay13 = new DateTime(dTuNgay7.Year, dTuNgay7.Month, dTuNgay7.Day, 0, 0, 0);
                                        DateTime DenNgay6 = new DateTime(dDenNgay7.Year, dDenNgay7.Month, dDenNgay7.Day, 0, 0, 0);
                                        if (dNgayKiemTra7 >= dTuNgay13 && dNgayKiemTra7 <= DenNgay6)
                                        {
                                            dNgayCham12 = new DateTime(idwYear, idwMonth2, idwDay2, 0, 0, 0);
                                            dGioCham11 = new DateTime(idwYear, idwMonth2, idwDay2, idwHour2, idwMinute2, idwSecond2);
                                            int addGioChamCong11 = DGVGioTai.Rows.Add();
                                            DGVGioTai.Rows[addGioChamCong11].Cells[0].Value = sdwEnrollNumber;
                                            DGVGioTai.Rows[addGioChamCong11].Cells[1].Value = dNgayCham12.ToString("yyyy/MM/dd");
                                            DGVGioTai.Rows[addGioChamCong11].Cells[2].Value = dGioCham11.ToString("yyyy/MM/dd HH:mm:ss");
                                            DGVGioTai.Rows[addGioChamCong11].Cells[3].Value = idwInOutMode.ToString();
                                            DGVGioTai.Rows[addGioChamCong11].Cells[4].Value = idwVerifyMode.ToString();
                                            DGVGioTai.Rows[addGioChamCong11].Cells[5].Value = sIDMayChamCong;
                                            DGVGioTai.Rows[addGioChamCong11].Cells[6].Value = sTenMayChamCong;
                                            DataTable dtKiemTraNhanVien11 = new DataTable();
                                            _nhanVienDTO.Ma_Cham_Cong = sdwEnrollNumber;
                                            dtKiemTraNhanVien11 = _nhanVienBLL.NhanVienGetByMaChamCong(_nhanVienDTO.Ma_Cham_Cong);
                                            if (dtKiemTraNhanVien11.Rows.Count == 1)
                                            {
                                                _checkInOutDTO.Ma_Cham_Cong = Convert.ToInt32(DGVGioTai.Rows[addGioChamCong11].Cells[0].Value.ToString());
                                                _checkInOutDTO.Ngay_Cham = Convert.ToDateTime(DGVGioTai.Rows[addGioChamCong11].Cells[1].Value.ToString());
                                                _checkInOutDTO.Gio_Cham = Convert.ToDateTime(DGVGioTai.Rows[addGioChamCong11].Cells[2].Value.ToString());
                                                _checkInOutDTO.Kieu_Cham = DGVGioTai.Rows[addGioChamCong11].Cells[3].Value.ToString();
                                                _checkInOutDTO.Nguon_Cham = DGVGioTai.Rows[addGioChamCong11].Cells[4].Value.ToString();
                                                _checkInOutDTO.MaSo_May = Convert.ToInt32(DGVGioTai.Rows[addGioChamCong11].Cells[5].Value.ToString());
                                                _checkInOutDTO.Ten_May = DGVGioTai.Rows[addGioChamCong11].Cells[6].Value.ToString();
                                                _checkInOutBLL.Insert_CheckinOut(_checkInOutDTO);
                                            }
                                        }
                                        progressBarTaiDuLieu.Maximum = iValue;
                                        test--;
                                        dem++;
                                        progressBarTaiDuLieu.Text = (dem + 1) * 100 / iValue + "%";
                                        Application.DoEvents();
                                        _ = iValue;
                                        _ = 0;
                                        if (iValue >= 0)
                                        {
                                            progressBarTaiDuLieu.Value = iValue - test;
                                        }
                                    }
                                    int i14 = 0;
                                    int iCount11 = 0;
                                    DataTable dtCheckInOut20 = new DataTable();
                                    dtCheckInOut20 = _checkInOutBLL.CountAll_CheckInOut();
                                    try
                                    {
                                        iCount11 = Convert.ToInt32(dtCheckInOut20.Rows[i14]["Column1"].ToString());
                                    }
                                    catch
                                    {
                                    }
                                    iTongCount += iCount11 - iCount1;
                                    btnTaiDuLieu.Text = "Dữ Liệu mới: " + iTongCount;
                                }
                                comboBoxLuaChonTai.SelectedIndex = 1;
                            }
                            else if (idwErrorCode2 != 0)
                            {
                                MessageBox.Show("Reading data from terminal failed,ErrorCode: " + idwErrorCode2 + "\n Vui Lòng chọn cách tải khác", "Error");
                            }
                            else
                            {
                                MessageBox.Show("Không có dữ liệu trên máy chấm công", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                            }
                        }
                    }
                    if (comboBoxLuaChonTai.SelectedIndex == 1)
                    {
                        string sTongNgayTai2 = Convert.ToInt32((etime_log.Value - stime_log.Value).TotalDays).ToString();
                        if (Convert.ToInt32(sTongNgayTai2) < 0)
                        {
                            MessageBox.Show("Xin chọn lại ngày");
                            return;
                        }
                        try
                        {
                            if (axCZKEM1.ReadTimeGLogData(iMachineNumber, stime_log.Text.Trim(), etime_log.Text.Trim()))
                            {
                                int i4 = 0;
                                DataTable dtCheckInOut9 = new DataTable();
                                dtCheckInOut9 = _checkInOutBLL.CountAll_CheckInOut();
                                iCount1 = Convert.ToInt32(dtCheckInOut9.Rows[i4]["Column1"].ToString());
                                while (axCZKEM1.SSR_GetGeneralLogData(iMachineNumber, out sdwEnrollNumber, out idwVerifyMode, out idwInOutMode, out idwYear, out idwMonth2, out idwDay2, out idwHour2, out idwMinute2, out idwSecond2, ref idwWorkcode))
                                {
                                    new DateTime(idwYear, idwMonth2, idwDay2);
                                    DateTime dNgayCham10 = new DateTime(idwYear, idwMonth2, idwDay2, 0, 0, 0);
                                    DateTime dGioCham10 = new DateTime(idwYear, idwMonth2, idwDay2, idwHour2, idwMinute2, idwSecond2);
                                    int addGioChamCong10 = DGVGioTai.Rows.Add();
                                    DGVGioTai.Rows[addGioChamCong10].Cells[0].Value = sdwEnrollNumber;
                                    DGVGioTai.Rows[addGioChamCong10].Cells[1].Value = dNgayCham10.ToString("yyyy/MM/dd");
                                    DGVGioTai.Rows[addGioChamCong10].Cells[2].Value = dGioCham10.ToString("yyyy/MM/dd HH:mm:ss");
                                    DGVGioTai.Rows[addGioChamCong10].Cells[3].Value = idwInOutMode.ToString();
                                    DGVGioTai.Rows[addGioChamCong10].Cells[4].Value = idwVerifyMode.ToString();
                                    DGVGioTai.Rows[addGioChamCong10].Cells[5].Value = sIDMayChamCong;
                                    DGVGioTai.Rows[addGioChamCong10].Cells[6].Value = sTenMayChamCong;
                                    DataTable dtKiemTraNhanVien10 = new DataTable();
                                    _nhanVienDTO.Ma_Cham_Cong = sdwEnrollNumber;
                                    dtKiemTraNhanVien10 = _nhanVienBLL.NhanVienGetByMaChamCong(_nhanVienDTO.Ma_Cham_Cong);
                                    if (dtKiemTraNhanVien10.Rows.Count == 1)
                                    {
                                        _checkInOutDTO.Ma_Cham_Cong = Convert.ToInt32(DGVGioTai.Rows[addGioChamCong10].Cells[0].Value.ToString());
                                        _checkInOutDTO.Ngay_Cham = Convert.ToDateTime(DGVGioTai.Rows[addGioChamCong10].Cells[1].Value.ToString());
                                        _checkInOutDTO.Gio_Cham = Convert.ToDateTime(DGVGioTai.Rows[addGioChamCong10].Cells[2].Value.ToString());
                                        _checkInOutDTO.Kieu_Cham = DGVGioTai.Rows[addGioChamCong10].Cells[3].Value.ToString();
                                        _checkInOutDTO.Nguon_Cham = DGVGioTai.Rows[addGioChamCong10].Cells[4].Value.ToString();
                                        _checkInOutDTO.MaSo_May = Convert.ToInt32(DGVGioTai.Rows[addGioChamCong10].Cells[5].Value.ToString());
                                        _checkInOutDTO.Ten_May = DGVGioTai.Rows[addGioChamCong10].Cells[6].Value.ToString();
                                        _checkInOutBLL.Insert_CheckinOut(_checkInOutDTO);
                                    }
                                    progressBarTaiDuLieu.Maximum = iValue;
                                    test--;
                                    dem++;
                                    progressBarTaiDuLieu.Text = (dem + 1) * 100 / iValue + "%";
                                    Application.DoEvents();
                                    _ = iValue;
                                    _ = 0;
                                    if (iValue >= 0)
                                    {
                                        progressBarTaiDuLieu.Value = iValue - test;
                                    }
                                }
                                int i12 = 0;
                                DataTable dtCheckInOut18 = new DataTable();
                                dtCheckInOut18 = _checkInOutBLL.CountAll_CheckInOut();
                                int iCount9 = Convert.ToInt32(dtCheckInOut18.Rows[i12]["Column1"].ToString());
                                btnTaiDuLieu.Text = "Dữ Liệu mới: " + (iCount9 - iCount1);
                            }
                            else if (dYearVersion >= 2017.0)
                            {
                                comboBoxLuaChonTai.SelectedIndex = 1;
                                int i2 = 0;
                                DataTable dtCheckInOut7 = new DataTable();
                                dtCheckInOut7 = _checkInOutBLL.CountAll_CheckInOut();
                                try
                                {
                                    iCount1 = Convert.ToInt32(dtCheckInOut7.Rows[i2]["Column1"].ToString());
                                }
                                catch
                                {
                                }
                                if (axCZKEM1.ReadGeneralLogData(iMachineNumber))
                                {
                                    while (axCZKEM1.SSR_GetGeneralLogData(iMachineNumber, out sdwEnrollNumber, out idwVerifyMode, out idwInOutMode, out idwYear, out idwMonth2, out idwDay2, out idwHour2, out idwMinute2, out idwSecond2, ref idwWorkcode))
                                    {
                                        if (sdwEnrollNumber == "Ec925")
                                        {
                                            continue;
                                        }
                                        DateTime dNgayCham9 = default(DateTime);
                                        DateTime dGioCham9 = default(DateTime);
                                        try
                                        {
                                            dNgayCham9 = new DateTime(idwYear, idwMonth2, idwDay2, 0, 0, 0);
                                            dGioCham9 = new DateTime(idwYear, idwMonth2, idwDay2, idwHour2, idwMinute2, idwSecond2);
                                        }
                                        catch
                                        {
                                        }
                                        DateTime dNgayKiemTra5 = new DateTime(idwYear, idwMonth2, idwDay2);
                                        DateTime dTuNgay5 = Convert.ToDateTime(stime_log.Text);
                                        DateTime dDenNgay5 = Convert.ToDateTime(etime_log.Text);
                                        DateTime dTuNgay12 = new DateTime(dTuNgay5.Year, dTuNgay5.Month, dTuNgay5.Day, 0, 0, 0);
                                        DateTime DenNgay5 = new DateTime(dDenNgay5.Year, dDenNgay5.Month, dDenNgay5.Day, 0, 0, 0);
                                        if (dNgayKiemTra5 >= dTuNgay12 && dNgayKiemTra5 <= DenNgay5)
                                        {
                                            dNgayCham9 = new DateTime(idwYear, idwMonth2, idwDay2, 0, 0, 0);
                                            dGioCham9 = new DateTime(idwYear, idwMonth2, idwDay2, idwHour2, idwMinute2, idwSecond2);
                                            int addGioChamCong9 = DGVGioTai.Rows.Add();
                                            DGVGioTai.Rows[addGioChamCong9].Cells[0].Value = sdwEnrollNumber;
                                            DGVGioTai.Rows[addGioChamCong9].Cells[1].Value = dNgayCham9.ToString("yyyy/MM/dd");
                                            DGVGioTai.Rows[addGioChamCong9].Cells[2].Value = dGioCham9.ToString("yyyy/MM/dd HH:mm:ss");
                                            DGVGioTai.Rows[addGioChamCong9].Cells[3].Value = idwInOutMode.ToString();
                                            DGVGioTai.Rows[addGioChamCong9].Cells[4].Value = idwVerifyMode.ToString();
                                            DGVGioTai.Rows[addGioChamCong9].Cells[5].Value = sIDMayChamCong;
                                            DGVGioTai.Rows[addGioChamCong9].Cells[6].Value = sTenMayChamCong;
                                            DataTable dtKiemTraNhanVien9 = new DataTable();
                                            _nhanVienDTO.Ma_Cham_Cong = sdwEnrollNumber;
                                            dtKiemTraNhanVien9 = _nhanVienBLL.NhanVienGetByMaChamCong(_nhanVienDTO.Ma_Cham_Cong);
                                            if (dtKiemTraNhanVien9.Rows.Count == 1)
                                            {
                                                _checkInOutDTO.Ma_Cham_Cong = Convert.ToInt32(DGVGioTai.Rows[addGioChamCong9].Cells[0].Value.ToString());
                                                _checkInOutDTO.Ngay_Cham = Convert.ToDateTime(DGVGioTai.Rows[addGioChamCong9].Cells[1].Value.ToString());
                                                _checkInOutDTO.Gio_Cham = Convert.ToDateTime(DGVGioTai.Rows[addGioChamCong9].Cells[2].Value.ToString());
                                                _checkInOutDTO.Kieu_Cham = DGVGioTai.Rows[addGioChamCong9].Cells[3].Value.ToString();
                                                _checkInOutDTO.Nguon_Cham = DGVGioTai.Rows[addGioChamCong9].Cells[4].Value.ToString();
                                                _checkInOutDTO.MaSo_May = Convert.ToInt32(DGVGioTai.Rows[addGioChamCong9].Cells[5].Value.ToString());
                                                _checkInOutDTO.Ten_May = DGVGioTai.Rows[addGioChamCong9].Cells[6].Value.ToString();
                                                _checkInOutBLL.Insert_CheckinOut(_checkInOutDTO);
                                            }
                                        }
                                        progressBarTaiDuLieu.Maximum = iValue;
                                        test--;
                                        dem++;
                                        progressBarTaiDuLieu.Text = (dem + 1) * 100 / iValue + "%";
                                        Application.DoEvents();
                                        _ = iValue;
                                        _ = 0;
                                        if (iValue >= 0)
                                        {
                                            progressBarTaiDuLieu.Value = iValue - test;
                                        }
                                    }
                                    int i11 = 0;
                                    int iCount8 = 0;
                                    DataTable dtCheckInOut17 = new DataTable();
                                    dtCheckInOut17 = _checkInOutBLL.CountAll_CheckInOut();
                                    try
                                    {
                                        iCount8 = Convert.ToInt32(dtCheckInOut17.Rows[i11]["Column1"].ToString());
                                    }
                                    catch
                                    {
                                    }
                                    iTongCount += iCount8 - iCount1;
                                    btnTaiDuLieu.Text = "Dữ Liệu mới: " + iTongCount;
                                }
                            }
                            else
                            {
                                if (dYearVersion < 2018.0)
                                {
                                    comboBoxLuaChonTai.SelectedIndex = 1;
                                    int n = 0;
                                    DataTable dtCheckInOut6 = new DataTable();
                                    dtCheckInOut6 = _checkInOutBLL.CountAll_CheckInOut();
                                    try
                                    {
                                        iCount1 = Convert.ToInt32(dtCheckInOut6.Rows[n]["Column1"].ToString());
                                    }
                                    catch
                                    {
                                    }
                                    if (axCZKEM1.ReadGeneralLogData(iMachineNumber))
                                    {
                                        while (axCZKEM1.SSR_GetGeneralLogData(iMachineNumber, out sdwEnrollNumber, out idwVerifyMode, out idwInOutMode, out idwYear, out idwMonth2, out idwDay2, out idwHour2, out idwMinute2, out idwSecond2, ref idwWorkcode))
                                        {
                                            if (sdwEnrollNumber == "Ec925")
                                            {
                                                continue;
                                            }
                                            DateTime dNgayCham8 = default(DateTime);
                                            DateTime dGioCham8 = default(DateTime);
                                            try
                                            {
                                                dNgayCham8 = new DateTime(idwYear, idwMonth2, idwDay2, 0, 0, 0);
                                                dGioCham8 = new DateTime(idwYear, idwMonth2, idwDay2, idwHour2, idwMinute2, idwSecond2);
                                            }
                                            catch
                                            {
                                            }
                                            DateTime dNgayKiemTra4 = new DateTime(idwYear, idwMonth2, idwDay2);
                                            DateTime dTuNgay4 = Convert.ToDateTime(stime_log.Text);
                                            DateTime dDenNgay4 = Convert.ToDateTime(etime_log.Text);
                                            DateTime dTuNgay11 = new DateTime(dTuNgay4.Year, dTuNgay4.Month, dTuNgay4.Day, 0, 0, 0);
                                            DateTime DenNgay4 = new DateTime(dDenNgay4.Year, dDenNgay4.Month, dDenNgay4.Day, 0, 0, 0);
                                            if (dNgayKiemTra4 >= dTuNgay11 && dNgayKiemTra4 <= DenNgay4)
                                            {
                                                dNgayCham8 = new DateTime(idwYear, idwMonth2, idwDay2, 0, 0, 0);
                                                dGioCham8 = new DateTime(idwYear, idwMonth2, idwDay2, idwHour2, idwMinute2, idwSecond2);
                                                int addGioChamCong8 = DGVGioTai.Rows.Add();
                                                DGVGioTai.Rows[addGioChamCong8].Cells[0].Value = sdwEnrollNumber;
                                                DGVGioTai.Rows[addGioChamCong8].Cells[1].Value = dNgayCham8.ToString("yyyy/MM/dd");
                                                DGVGioTai.Rows[addGioChamCong8].Cells[2].Value = dGioCham8.ToString("yyyy/MM/dd HH:mm:ss");
                                                DGVGioTai.Rows[addGioChamCong8].Cells[3].Value = idwInOutMode.ToString();
                                                DGVGioTai.Rows[addGioChamCong8].Cells[4].Value = idwVerifyMode.ToString();
                                                DGVGioTai.Rows[addGioChamCong8].Cells[5].Value = sIDMayChamCong;
                                                DGVGioTai.Rows[addGioChamCong8].Cells[6].Value = sTenMayChamCong;
                                                DataTable dtKiemTraNhanVien8 = new DataTable();
                                                _nhanVienDTO.Ma_Cham_Cong = sdwEnrollNumber;
                                                dtKiemTraNhanVien8 = _nhanVienBLL.NhanVienGetByMaChamCong(_nhanVienDTO.Ma_Cham_Cong);
                                                if (dtKiemTraNhanVien8.Rows.Count == 1)
                                                {
                                                    _checkInOutDTO.Ma_Cham_Cong = Convert.ToInt32(DGVGioTai.Rows[addGioChamCong8].Cells[0].Value.ToString());
                                                    _checkInOutDTO.Ngay_Cham = Convert.ToDateTime(DGVGioTai.Rows[addGioChamCong8].Cells[1].Value.ToString());
                                                    _checkInOutDTO.Gio_Cham = Convert.ToDateTime(DGVGioTai.Rows[addGioChamCong8].Cells[2].Value.ToString());
                                                    _checkInOutDTO.Kieu_Cham = DGVGioTai.Rows[addGioChamCong8].Cells[3].Value.ToString();
                                                    _checkInOutDTO.Nguon_Cham = DGVGioTai.Rows[addGioChamCong8].Cells[4].Value.ToString();
                                                    _checkInOutDTO.MaSo_May = Convert.ToInt32(DGVGioTai.Rows[addGioChamCong8].Cells[5].Value.ToString());
                                                    _checkInOutDTO.Ten_May = DGVGioTai.Rows[addGioChamCong8].Cells[6].Value.ToString();
                                                    _checkInOutBLL.Insert_CheckinOut(_checkInOutDTO);
                                                }
                                            }
                                            progressBarTaiDuLieu.Maximum = iValue;
                                            test--;
                                            dem++;
                                            progressBarTaiDuLieu.Text = (dem + 1) * 100 / iValue + "%";
                                            Application.DoEvents();
                                            _ = iValue;
                                            _ = 0;
                                            if (iValue >= 0)
                                            {
                                                progressBarTaiDuLieu.Value = iValue - test;
                                            }
                                        }
                                        int i10 = 0;
                                        int iCount7 = 0;
                                        DataTable dtCheckInOut16 = new DataTable();
                                        dtCheckInOut16 = _checkInOutBLL.CountAll_CheckInOut();
                                        try
                                        {
                                            iCount7 = Convert.ToInt32(dtCheckInOut16.Rows[i10]["Column1"].ToString());
                                        }
                                        catch
                                        {
                                        }
                                        iTongCount += iCount7 - iCount1;
                                        btnTaiDuLieu.Text = "Dữ Liệu mới: " + iTongCount;
                                    }
                                    comboBoxLuaChonTai.SelectedIndex = 1;
                                }
                                Cursor = Cursors.Default;
                                //axCZKEM1.GetLastError(ref idwErrorCode2);
                                //if (idwErrorCode2 != 0)
                                //{
                                //    MessageBox.Show("Reading data from terminal failed,ErrorCode: " + idwErrorCode2 + "\n Vui Lòng chọn cách tải khác", "Error");
                                //}
                                //else if (dYearVersion < 2018.0)
                                //{
                                //    comboBoxLuaChonTai.SelectedIndex = 1;
                                //    int m = 0;
                                //    DataTable dtCheckInOut5 = new DataTable();
                                //    dtCheckInOut5 = _checkInOutBLL.CountAllCheckInOut(_checkInOutDTO);
                                //    try
                                //    {
                                //        iCount1 = Convert.ToInt32(dtCheckInOut5.Rows[m]["Column1"].ToString());
                                //    }
                                //    catch
                                //    {
                                //    }
                                //    if (axCZKEM1.ReadGeneralLogData(iMachineNumber))
                                //    {
                                //        while (axCZKEM1.SSR_GetGeneralLogData(iMachineNumber, out sdwEnrollNumber, out idwVerifyMode, out idwInOutMode, out idwYear, out idwMonth2, out idwDay2, out idwHour2, out idwMinute2, out idwSecond2, ref idwWorkcode))
                                //        {
                                //            if (sdwEnrollNumber == "Ec925")
                                //            {
                                //                continue;
                                //            }
                                //            DateTime dNgayCham7 = default(DateTime);
                                //            DateTime dGioCham7 = default(DateTime);
                                //            try
                                //            {
                                //                dNgayCham7 = new DateTime(idwYear, idwMonth2, idwDay2, 0, 0, 0);
                                //                dGioCham7 = new DateTime(idwYear, idwMonth2, idwDay2, idwHour2, idwMinute2, idwSecond2);
                                //            }
                                //            catch
                                //            {
                                //            }
                                //            DateTime dNgayKiemTra3 = new DateTime(idwYear, idwMonth2, idwDay2);
                                //            DateTime dTuNgay3 = Convert.ToDateTime(stime_log.Text);
                                //            DateTime dDenNgay3 = Convert.ToDateTime(etime_log.Text);
                                //            DateTime dTuNgay10 = new DateTime(dTuNgay3.Year, dTuNgay3.Month, dTuNgay3.Day, 0, 0, 0);
                                //            DateTime DenNgay3 = new DateTime(dDenNgay3.Year, dDenNgay3.Month, dDenNgay3.Day, 0, 0, 0);
                                //            if (dNgayKiemTra3 >= dTuNgay10 && dNgayKiemTra3 <= DenNgay3)
                                //            {
                                //                dNgayCham7 = new DateTime(idwYear, idwMonth2, idwDay2, 0, 0, 0);
                                //                dGioCham7 = new DateTime(idwYear, idwMonth2, idwDay2, idwHour2, idwMinute2, idwSecond2);
                                //                int addGioChamCong7 = DGVGioTai.Rows.Add();
                                //                DGVGioTai.Rows[addGioChamCong7].Cells[0].Value = sdwEnrollNumber;
                                //                DGVGioTai.Rows[addGioChamCong7].Cells[1].Value = dNgayCham7.ToString();
                                //                DGVGioTai.Rows[addGioChamCong7].Cells[2].Value = dGioCham7.ToString();
                                //                DGVGioTai.Rows[addGioChamCong7].Cells[3].Value = idwInOutMode.ToString();
                                //                DGVGioTai.Rows[addGioChamCong7].Cells[4].Value = idwVerifyMode.ToString();
                                //                DGVGioTai.Rows[addGioChamCong7].Cells[5].Value = sIDMayChamCong;
                                //                DGVGioTai.Rows[addGioChamCong7].Cells[6].Value = sTenMayChamCong;
                                //                DataTable dtKiemTraNhanVien7 = new DataTable();
                                //                _nhanVienDTO.MaChamCong = sdwEnrollNumber;
                                //                dtKiemTraNhanVien7 = _nhanVienBLL.NhanVienGetByMaChamCong(_nhanVienDTO);
                                //                if (dtKiemTraNhanVien7.Rows.Count == 1)
                                //                {
                                //                    _checkInOutDTO.MaChamCong = Convert.ToInt32(DGVGioTai.Rows[addGioChamCong7].Cells[0].Value.ToString());
                                //                    _checkInOutDTO.NgayCham = Convert.ToDateTime(DGVGioTai.Rows[addGioChamCong7].Cells[1].Value.ToString());
                                //                    _checkInOutDTO.GioCham = Convert.ToDateTime(DGVGioTai.Rows[addGioChamCong7].Cells[2].Value.ToString());
                                //                    _checkInOutDTO.KieuCham = DGVGioTai.Rows[addGioChamCong7].Cells[3].Value.ToString();
                                //                    _checkInOutDTO.NguonCham = DGVGioTai.Rows[addGioChamCong7].Cells[4].Value.ToString();
                                //                    _checkInOutDTO.MaSoMay = Convert.ToInt32(DGVGioTai.Rows[addGioChamCong7].Cells[5].Value.ToString());
                                //                    _checkInOutDTO.TenMay = DGVGioTai.Rows[addGioChamCong7].Cells[6].Value.ToString();
                                //                    _checkInOutBLL.Insert_CheckinOut(_checkInOutDTO);
                                //                }
                                //            }
                                //            progressBarTaiDuLieu.Maximum = iValue;
                                //            test--;
                                //            dem++;
                                //            progressBarTaiDuLieu.Text = (dem + 1) * 100 / iValue + "%";
                                //            Application.DoEvents();
                                //            _ = iValue;
                                //            _ = 0;
                                //            if (iValue >= 0)
                                //            {
                                //                progressBarTaiDuLieu.Value = iValue - test;
                                //            }
                                //        }
                                //        int i9 = 0;
                                //        int iCount6 = 0;
                                //        DataTable dtCheckInOut15 = new DataTable();
                                //        dtCheckInOut15 = _checkInOutBLL.CountAllCheckInOut(_checkInOutDTO);
                                //        try
                                //        {
                                //            iCount6 = Convert.ToInt32(dtCheckInOut15.Rows[i9]["Column1"].ToString());
                                //        }
                                //        catch
                                //        {
                                //        }
                                //        iTongCount += iCount6 - iCount1;
                                //        btnTaiDuLieu.Text = "Dữ Liệu mới: " + iTongCount;
                                //    }
                                //    comboBoxLuaChonTai.SelectedIndex = 1;
                                //}
                                //else
                                //{
                                //    MessageBox.Show("Không có dữ liệu trên máy chấm công", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                                //}
                            }
                        }
                        catch
                        {
                            comboBoxLuaChonTai.SelectedIndex = 1;
                            int l = 0;
                            DataTable dtCheckInOut4 = new DataTable();
                            dtCheckInOut4 = _checkInOutBLL.CountAll_CheckInOut();
                            try
                            {
                                iCount1 = Convert.ToInt32(dtCheckInOut4.Rows[l]["Column1"].ToString());
                            }
                            catch
                            {
                            }
                            if (axCZKEM1.ReadGeneralLogData(iMachineNumber))
                            {
                                while (axCZKEM1.SSR_GetGeneralLogData(iMachineNumber, out sdwEnrollNumber, out idwVerifyMode, out idwInOutMode, out idwYear, out idwMonth2, out idwDay2, out idwHour2, out idwMinute2, out idwSecond2, ref idwWorkcode))
                                {
                                    if (sdwEnrollNumber == "Ec925")
                                    {
                                        continue;
                                    }
                                    DateTime dNgayCham6 = default(DateTime);
                                    DateTime dGioCham6 = default(DateTime);
                                    try
                                    {
                                        dNgayCham6 = new DateTime(idwYear, idwMonth2, idwDay2, 0, 0, 0);
                                        dGioCham6 = new DateTime(idwYear, idwMonth2, idwDay2, idwHour2, idwMinute2, idwSecond2);
                                    }
                                    catch
                                    {
                                    }
                                    DateTime dNgayKiemTra2 = new DateTime(idwYear, idwMonth2, idwDay2);
                                    DateTime dTuNgay2 = Convert.ToDateTime(stime_log.Text);
                                    DateTime dDenNgay2 = Convert.ToDateTime(etime_log.Text);
                                    DateTime dTuNgay9 = new DateTime(dTuNgay2.Year, dTuNgay2.Month, dTuNgay2.Day, 0, 0, 0);
                                    DateTime DenNgay2 = new DateTime(dDenNgay2.Year, dDenNgay2.Month, dDenNgay2.Day, 0, 0, 0);
                                    if (dNgayKiemTra2 >= dTuNgay9 && dNgayKiemTra2 <= DenNgay2)
                                    {
                                        dNgayCham6 = new DateTime(idwYear, idwMonth2, idwDay2, 0, 0, 0);
                                        dGioCham6 = new DateTime(idwYear, idwMonth2, idwDay2, idwHour2, idwMinute2, idwSecond2);
                                        int addGioChamCong6 = DGVGioTai.Rows.Add();
                                        DGVGioTai.Rows[addGioChamCong6].Cells[0].Value = sdwEnrollNumber;
                                        DGVGioTai.Rows[addGioChamCong6].Cells[1].Value = dNgayCham6.ToString();
                                        DGVGioTai.Rows[addGioChamCong6].Cells[2].Value = dGioCham6.ToString();
                                        DGVGioTai.Rows[addGioChamCong6].Cells[3].Value = idwInOutMode.ToString();
                                        DGVGioTai.Rows[addGioChamCong6].Cells[4].Value = idwVerifyMode.ToString();
                                        DGVGioTai.Rows[addGioChamCong6].Cells[5].Value = sIDMayChamCong;
                                        DGVGioTai.Rows[addGioChamCong6].Cells[6].Value = sTenMayChamCong;
                                        DataTable dtKiemTraNhanVien6 = new DataTable();
                                        _nhanVienDTO.Ma_Cham_Cong = sdwEnrollNumber;
                                        dtKiemTraNhanVien6 = _nhanVienBLL.NhanVienGetByMaChamCong(_nhanVienDTO.Ma_Cham_Cong);
                                        if (dtKiemTraNhanVien6.Rows.Count == 1)
                                        {
                                            _checkInOutDTO.Ma_Cham_Cong = Convert.ToInt32(DGVGioTai.Rows[addGioChamCong6].Cells[0].Value.ToString());
                                            _checkInOutDTO.Ngay_Cham = Convert.ToDateTime(DGVGioTai.Rows[addGioChamCong6].Cells[1].Value.ToString());
                                            _checkInOutDTO.Gio_Cham = Convert.ToDateTime(DGVGioTai.Rows[addGioChamCong6].Cells[2].Value.ToString());
                                            _checkInOutDTO.Kieu_Cham = DGVGioTai.Rows[addGioChamCong6].Cells[3].Value.ToString();
                                            _checkInOutDTO.Nguon_Cham = DGVGioTai.Rows[addGioChamCong6].Cells[4].Value.ToString();
                                            _checkInOutDTO.MaSo_May = Convert.ToInt32(DGVGioTai.Rows[addGioChamCong6].Cells[5].Value.ToString());
                                            _checkInOutDTO.Ten_May = DGVGioTai.Rows[addGioChamCong6].Cells[6].Value.ToString();
                                            _checkInOutBLL.Insert_CheckinOut(_checkInOutDTO);
                                        }
                                    }
                                    progressBarTaiDuLieu.Maximum = iValue;
                                    test--;
                                    dem++;
                                    progressBarTaiDuLieu.Text = (dem + 1) * 100 / iValue + "%";
                                    Application.DoEvents();
                                    _ = iValue;
                                    _ = 0;
                                    if (iValue >= 0)
                                    {
                                        progressBarTaiDuLieu.Value = iValue - test;
                                    }
                                }
                                int i8 = 0;
                                int iCount5 = 0;
                                DataTable dtCheckInOut14 = new DataTable();
                                dtCheckInOut14 = _checkInOutBLL.CountAll_CheckInOut();
                                try
                                {
                                    iCount5 = Convert.ToInt32(dtCheckInOut14.Rows[i8]["Column1"].ToString());
                                }
                                catch
                                {
                                }
                                iTongCount += iCount5 - iCount1;
                                btnTaiDuLieu.Text = "Dữ Liệu mới: " + iTongCount;
                            }
                            comboBoxLuaChonTai.SelectedIndex = 1;
                        }
                    }
                    if (comboBoxLuaChonTai.SelectedIndex == 0)
                    {
                        if (axCZKEM1.ReadNewGLogData(iMachineNumber))
                        {
                            int k = 0;
                            DataTable dtCheckInOut3 = new DataTable();
                            dtCheckInOut3 = _checkInOutBLL.CountAll_CheckInOut();
                            iCount1 = Convert.ToInt32(dtCheckInOut3.Rows[k]["Column1"].ToString());
                            while (axCZKEM1.SSR_GetGeneralLogData(iMachineNumber, out sdwEnrollNumber, out idwVerifyMode, out idwInOutMode, out idwYear, out idwMonth2, out idwDay2, out idwHour2, out idwMinute2, out idwSecond2, ref idwWorkcode))
                            {
                                new DateTime(idwYear, idwMonth2, idwDay2);
                                DateTime dNgayCham5 = new DateTime(idwYear, idwMonth2, idwDay2, 0, 0, 0);
                                DateTime dGioCham5 = new DateTime(idwYear, idwMonth2, idwDay2, idwHour2, idwMinute2, idwSecond2);
                                int addGioChamCong5 = DGVGioTai.Rows.Add();
                                DGVGioTai.Rows[addGioChamCong5].Cells[0].Value = sdwEnrollNumber;
                                DGVGioTai.Rows[addGioChamCong5].Cells[1].Value = dNgayCham5.ToString();
                                DGVGioTai.Rows[addGioChamCong5].Cells[2].Value = dGioCham5.ToString();
                                DGVGioTai.Rows[addGioChamCong5].Cells[3].Value = idwInOutMode.ToString();
                                DGVGioTai.Rows[addGioChamCong5].Cells[4].Value = idwVerifyMode.ToString();
                                DGVGioTai.Rows[addGioChamCong5].Cells[5].Value = sIDMayChamCong;
                                DGVGioTai.Rows[addGioChamCong5].Cells[6].Value = sTenMayChamCong;
                                DataTable dtKiemTraNhanVien5 = new DataTable();
                                _nhanVienDTO.Ma_Cham_Cong = sdwEnrollNumber;
                                dtKiemTraNhanVien5 = _nhanVienBLL.NhanVienGetByMaChamCong(_nhanVienDTO.Ma_Cham_Cong);
                                if (dtKiemTraNhanVien5.Rows.Count == 1)
                                {
                                    _checkInOutDTO.Ma_Cham_Cong = Convert.ToInt32(DGVGioTai.Rows[addGioChamCong5].Cells[0].Value.ToString());
                                    _checkInOutDTO.Ngay_Cham = Convert.ToDateTime(DGVGioTai.Rows[addGioChamCong5].Cells[1].Value.ToString());
                                    _checkInOutDTO.Gio_Cham = Convert.ToDateTime(DGVGioTai.Rows[addGioChamCong5].Cells[2].Value.ToString());
                                    _checkInOutDTO.Kieu_Cham = DGVGioTai.Rows[addGioChamCong5].Cells[3].Value.ToString();
                                    _checkInOutDTO.Nguon_Cham = DGVGioTai.Rows[addGioChamCong5].Cells[4].Value.ToString();
                                    _checkInOutDTO.MaSo_May = Convert.ToInt32(DGVGioTai.Rows[addGioChamCong5].Cells[5].Value.ToString());
                                    _checkInOutDTO.Ten_May = DGVGioTai.Rows[addGioChamCong5].Cells[6].Value.ToString();
                                    _checkInOutBLL.Insert_CheckinOut(_checkInOutDTO);
                                }
                                progressBarTaiDuLieu.Maximum = iValue;
                                test--;
                                dem++;
                                progressBarTaiDuLieu.Text = (dem + 1) * 100 / iValue + "%";
                                Application.DoEvents();
                                _ = iValue;
                                _ = 0;
                                if (iValue >= 0)
                                {
                                    progressBarTaiDuLieu.Value = iValue - test;
                                }
                            }
                            int i7 = 0;
                            DataTable dtCheckInOut13 = new DataTable();
                            dtCheckInOut13 = _checkInOutBLL.CountAll_CheckInOut();
                            int iCount4 = Convert.ToInt32(dtCheckInOut13.Rows[i7]["Column1"].ToString());
                            btnTaiDuLieu.Text = "Dữ Liệu mới: " + (iCount4 - iCount1);
                        }
                        else if (dYearVersion >= 2017.0)
                        {
                            comboBoxLuaChonTai.SelectedIndex = 2;
                            int j = 0;
                            DataTable dtCheckInOut2 = new DataTable();
                            dtCheckInOut2 = _checkInOutBLL.CountAll_CheckInOut();
                            try
                            {
                                iCount1 = Convert.ToInt32(dtCheckInOut2.Rows[j]["Column1"].ToString());
                            }
                            catch
                            {
                            }
                            if (axCZKEM1.ReadGeneralLogData(iMachineNumber))
                            {
                                while (axCZKEM1.SSR_GetGeneralLogData(iMachineNumber, out sdwEnrollNumber, out idwVerifyMode, out idwInOutMode, out idwYear, out idwMonth2, out idwDay2, out idwHour2, out idwMinute2, out idwSecond2, ref idwWorkcode))
                                {
                                    if (!(sdwEnrollNumber == "Ec925"))
                                    {
                                        DateTime dNgayCham4 = default(DateTime);
                                        DateTime dGioCham4 = default(DateTime);
                                        try
                                        {
                                            dNgayCham4 = new DateTime(idwYear, idwMonth2, idwDay2, 0, 0, 0);
                                            dGioCham4 = new DateTime(idwYear, idwMonth2, idwDay2, idwHour2, idwMinute2, idwSecond2);
                                        }
                                        catch
                                        {
                                        }
                                        int addGioChamCong4 = DGVGioTai.Rows.Add();
                                        DGVGioTai.Rows[addGioChamCong4].Cells[0].Value = sdwEnrollNumber;
                                        DGVGioTai.Rows[addGioChamCong4].Cells[1].Value = dNgayCham4.ToString();
                                        DGVGioTai.Rows[addGioChamCong4].Cells[2].Value = dGioCham4.ToString();
                                        DGVGioTai.Rows[addGioChamCong4].Cells[3].Value = idwInOutMode.ToString();
                                        DGVGioTai.Rows[addGioChamCong4].Cells[4].Value = idwVerifyMode.ToString();
                                        DGVGioTai.Rows[addGioChamCong4].Cells[5].Value = sIDMayChamCong;
                                        DGVGioTai.Rows[addGioChamCong4].Cells[6].Value = sTenMayChamCong;
                                        DataTable dtKiemTraNhanVien4 = new DataTable();
                                        _nhanVienDTO.Ma_Cham_Cong = sdwEnrollNumber;
                                        dtKiemTraNhanVien4 = _nhanVienBLL.NhanVienGetByMaChamCong(_nhanVienDTO.Ma_Cham_Cong);
                                        if (dtKiemTraNhanVien4.Rows.Count == 1)
                                        {
                                            _checkInOutDTO.Ma_Cham_Cong = Convert.ToInt32(DGVGioTai.Rows[addGioChamCong4].Cells[0].Value.ToString());
                                            _checkInOutDTO.Ngay_Cham = Convert.ToDateTime(DGVGioTai.Rows[addGioChamCong4].Cells[1].Value.ToString());
                                            _checkInOutDTO.Gio_Cham = Convert.ToDateTime(DGVGioTai.Rows[addGioChamCong4].Cells[2].Value.ToString());
                                            _checkInOutDTO.Kieu_Cham = DGVGioTai.Rows[addGioChamCong4].Cells[3].Value.ToString();
                                            _checkInOutDTO.Nguon_Cham = DGVGioTai.Rows[addGioChamCong4].Cells[4].Value.ToString();
                                            _checkInOutDTO.MaSo_May = Convert.ToInt32(DGVGioTai.Rows[addGioChamCong4].Cells[5].Value.ToString());
                                            _checkInOutDTO.Ten_May = DGVGioTai.Rows[addGioChamCong4].Cells[6].Value.ToString();
                                            _checkInOutBLL.Insert_CheckinOut(_checkInOutDTO);
                                        }
                                        progressBarTaiDuLieu.Maximum = iValue;
                                        test--;
                                        dem++;
                                        progressBarTaiDuLieu.Text = (dem + 1) * 100 / iValue + "%";
                                        Application.DoEvents();
                                        _ = iValue;
                                        _ = 0;
                                        if (iValue >= 0)
                                        {
                                            progressBarTaiDuLieu.Value = iValue - test;
                                        }
                                    }
                                }
                                int i6 = 0;
                                int iCount3 = 0;
                                DataTable dtCheckInOut12 = new DataTable();
                                dtCheckInOut12 = _checkInOutBLL.CountAll_CheckInOut();
                                try
                                {
                                    iCount3 = Convert.ToInt32(dtCheckInOut12.Rows[i6]["Column1"].ToString());
                                }
                                catch
                                {
                                }
                                iTongCount += iCount3 - iCount1;
                                btnTaiDuLieu.Text = "Dữ Liệu mới: " + iTongCount;
                            }
                        }
                        else
                        {
                            Cursor = Cursors.Default;
                            axCZKEM1.GetLastError(ref idwErrorCode2);
                            if (dYearVersion < 2017.0)
                            {
                                comboBoxLuaChonTai.SelectedIndex = 1;
                                int i = 0;
                                DataTable dtCheckInOut = new DataTable();
                                dtCheckInOut = _checkInOutBLL.CountAll_CheckInOut();
                                try
                                {
                                    iCount1 = Convert.ToInt32(dtCheckInOut.Rows[i]["Column1"].ToString());
                                }
                                catch
                                {
                                }
                                if (axCZKEM1.ReadGeneralLogData(iMachineNumber))
                                {
                                    while (axCZKEM1.SSR_GetGeneralLogData(iMachineNumber, out sdwEnrollNumber, out idwVerifyMode, out idwInOutMode, out idwYear, out idwMonth2, out idwDay2, out idwHour2, out idwMinute2, out idwSecond2, ref idwWorkcode))
                                    {
                                        if (sdwEnrollNumber == "Ec925")
                                        {
                                            continue;
                                        }
                                        DateTime dNgayCham3 = default(DateTime);
                                        DateTime dGioCham3 = default(DateTime);
                                        try
                                        {
                                            dNgayCham3 = new DateTime(idwYear, idwMonth2, idwDay2, 0, 0, 0);
                                            dGioCham3 = new DateTime(idwYear, idwMonth2, idwDay2, idwHour2, idwMinute2, idwSecond2);
                                        }
                                        catch
                                        {
                                        }
                                        DateTime dNgayKiemTra = new DateTime(idwYear, idwMonth2, idwDay2);
                                        DateTime dTuNgay = Convert.ToDateTime(stime_log.Text);
                                        DateTime dDenNgay = Convert.ToDateTime(etime_log.Text);
                                        DateTime dTuNgay8 = new DateTime(dTuNgay.Year, dTuNgay.Month, dTuNgay.Day, 0, 0, 0);
                                        DateTime DenNgay1 = new DateTime(dDenNgay.Year, dDenNgay.Month, dDenNgay.Day, 0, 0, 0);
                                        if (dNgayKiemTra >= dTuNgay8 && dNgayKiemTra <= DenNgay1)
                                        {
                                            dNgayCham3 = new DateTime(idwYear, idwMonth2, idwDay2, 0, 0, 0);
                                            dGioCham3 = new DateTime(idwYear, idwMonth2, idwDay2, idwHour2, idwMinute2, idwSecond2);
                                            int addGioChamCong3 = DGVGioTai.Rows.Add();
                                            DGVGioTai.Rows[addGioChamCong3].Cells[0].Value = sdwEnrollNumber;
                                            DGVGioTai.Rows[addGioChamCong3].Cells[1].Value = dNgayCham3.ToString();
                                            DGVGioTai.Rows[addGioChamCong3].Cells[2].Value = dGioCham3.ToString();
                                            DGVGioTai.Rows[addGioChamCong3].Cells[3].Value = idwInOutMode.ToString();
                                            DGVGioTai.Rows[addGioChamCong3].Cells[4].Value = idwVerifyMode.ToString();
                                            DGVGioTai.Rows[addGioChamCong3].Cells[5].Value = sIDMayChamCong;
                                            DGVGioTai.Rows[addGioChamCong3].Cells[6].Value = sTenMayChamCong;
                                            DataTable dtKiemTraNhanVien3 = new DataTable();
                                            _nhanVienDTO.Ma_Cham_Cong = sdwEnrollNumber;
                                            dtKiemTraNhanVien3 = _nhanVienBLL.NhanVienGetByMaChamCong(_nhanVienDTO.Ma_Cham_Cong);
                                            if (dtKiemTraNhanVien3.Rows.Count == 1)
                                            {
                                                _checkInOutDTO.Ma_Cham_Cong = Convert.ToInt32(DGVGioTai.Rows[addGioChamCong3].Cells[0].Value.ToString());
                                                _checkInOutDTO.Ngay_Cham = Convert.ToDateTime(DGVGioTai.Rows[addGioChamCong3].Cells[1].Value.ToString());
                                                _checkInOutDTO.Gio_Cham = Convert.ToDateTime(DGVGioTai.Rows[addGioChamCong3].Cells[2].Value.ToString());
                                                _checkInOutDTO.Kieu_Cham = DGVGioTai.Rows[addGioChamCong3].Cells[3].Value.ToString();
                                                _checkInOutDTO.Nguon_Cham = DGVGioTai.Rows[addGioChamCong3].Cells[4].Value.ToString();
                                                _checkInOutDTO.MaSo_May = Convert.ToInt32(DGVGioTai.Rows[addGioChamCong3].Cells[5].Value.ToString());
                                                _checkInOutDTO.Ten_May = DGVGioTai.Rows[addGioChamCong3].Cells[6].Value.ToString();
                                                _checkInOutBLL.Insert_CheckinOut(_checkInOutDTO);
                                            }
                                        }
                                        progressBarTaiDuLieu.Maximum = iValue;
                                        test--;
                                        dem++;
                                        progressBarTaiDuLieu.Text = (dem + 1) * 100 / iValue + "%";
                                        Application.DoEvents();
                                        _ = iValue;
                                        _ = 0;
                                        if (iValue >= 0)
                                        {
                                            progressBarTaiDuLieu.Value = iValue - test;
                                        }
                                    }
                                    int i5 = 0;
                                    int iCount2 = 0;
                                    DataTable dtCheckInOut11 = new DataTable();
                                    dtCheckInOut11 = _checkInOutBLL.CountAll_CheckInOut();
                                    try
                                    {
                                        iCount2 = Convert.ToInt32(dtCheckInOut11.Rows[i5]["Column1"].ToString());
                                    }
                                    catch
                                    {
                                    }
                                    iTongCount += iCount2 - iCount1;
                                    btnTaiDuLieu.Text = "Dữ Liệu mới: " + iTongCount;
                                }
                                comboBoxLuaChonTai.SelectedIndex = 2;
                            }
                            else if (idwErrorCode2 != 0)
                            {
                                MessageBox.Show("Reading data from terminal failed,ErrorCode: " + idwErrorCode2 + "\n Vui Lòng chọn cách tải khác", "Error");
                            }
                        }
                    }
                    axCZKEM1.EnableDevice(iMachineNumber, bFlag: true);
                    iDemLanTaiDauTien++;
                    if (iDemLanTaiDauTien > 2)
                    {
                        comboBoxLuaChonTai.SelectedIndex = iChonCachTai;
                    }
                    return;
                }


                ////////////////////////////////////////////////////////////////////////////////
                //comboBoxLuaChonTai.SelectedIndex = 2;
                //int idwErrorCode = 0;
                //int idwEnrollNumber = 0;
                //int idwVerifyMode2 = 0;
                //int idwInOutMode2 = 0;
                //int idwYear2 = 0;
                //int idwMonth = 0;
                //int idwDay = 0;
                //int idwHour = 0;
                //int idwMinute = 0;
                //int idwSecond = 0;
                //int idwWorkCode = 0;
                //int idwReserved = 0;
                //Cursor = Cursors.WaitCursor;
                //axCZKEM1.EnableDevice(iMachineNumber, bFlag: false);
                //if (comboBoxLuaChonTai.SelectedIndex == 2 || comboBoxLuaChonTai.SelectedIndex == 0)
                //{
                //    if (axCZKEM1.ReadGeneralLogData(iMachineNumber))
                //    {
                //        while (axCZKEM1.GetGeneralExtLogData(iMachineNumber, ref idwEnrollNumber, ref idwVerifyMode2, ref idwInOutMode2, ref idwYear2, ref idwMonth, ref idwDay, ref idwHour, ref idwMinute, ref idwSecond, ref idwWorkCode, ref idwReserved))
                //        {
                //            DateTime dNgayCham2 = new DateTime(idwYear2, idwMonth, idwDay, 0, 0, 0);
                //            DateTime dGioCham2 = new DateTime(idwYear2, idwMonth, idwDay, idwHour, idwMinute, idwSecond);
                //            int DemKiemTraNhanVien2 = 0;
                //            int addGioChamCong2 = DGVGioTai.Rows.Add();
                //            DGVGioTai.Rows[addGioChamCong2].Cells[0].Value = idwEnrollNumber.ToString();
                //            DGVGioTai.Rows[addGioChamCong2].Cells[1].Value = dNgayCham2.ToString();
                //            DGVGioTai.Rows[addGioChamCong2].Cells[2].Value = dGioCham2.ToString();
                //            DGVGioTai.Rows[addGioChamCong2].Cells[3].Value = idwInOutMode2.ToString();
                //            DGVGioTai.Rows[addGioChamCong2].Cells[4].Value = idwVerifyMode2.ToString();
                //            DGVGioTai.Rows[addGioChamCong2].Cells[5].Value = sIDMayChamCong;
                //            DGVGioTai.Rows[addGioChamCong2].Cells[6].Value = sTenMayChamCong;
                //            DataTable dtKiemTraNhanVien2 = new DataTable();
                //            _nhanVienDTO.MaChamCong = idwEnrollNumber.ToString();
                //            dtKiemTraNhanVien2 = _nhanVienBLL.NhanVienGetByMaChamCong(_nhanVienDTO);
                //            for (int iKiemTraNhanVien2 = 0; iKiemTraNhanVien2 < dtKiemTraNhanVien2.Rows.Count; iKiemTraNhanVien2++)
                //            {
                //                DemKiemTraNhanVien2 = 1;
                //            }
                //            if (DemKiemTraNhanVien2 == 1)
                //            {
                //                _checkInOutDTO.MaChamCong = Convert.ToInt32(DGVGioTai.Rows[addGioChamCong2].Cells[0].Value.ToString());
                //                _checkInOutDTO.NgayCham = Convert.ToDateTime(DGVGioTai.Rows[addGioChamCong2].Cells[1].Value.ToString());
                //                _checkInOutDTO.GioCham = Convert.ToDateTime(DGVGioTai.Rows[addGioChamCong2].Cells[2].Value.ToString());
                //                _checkInOutDTO.KieuCham = DGVGioTai.Rows[addGioChamCong2].Cells[3].Value.ToString();
                //                _checkInOutDTO.NguonCham = DGVGioTai.Rows[addGioChamCong2].Cells[4].Value.ToString();
                //                _checkInOutDTO.MaSoMay = Convert.ToInt32(DGVGioTai.Rows[addGioChamCong2].Cells[5].Value.ToString());
                //                _checkInOutDTO.TenMay = DGVGioTai.Rows[addGioChamCong2].Cells[6].Value.ToString();
                //                _checkInOutBLL.Insert_CheckinOut(_checkInOutDTO);
                //            }
                //            progressBarTaiDuLieu.Maximum = iValue;
                //            test--;
                //            dem++;
                //            progressBarTaiDuLieu.Text = (dem + 1) * 100 / iValue + "%";
                //            Application.DoEvents();
                //            _ = iValue;
                //            _ = 0;
                //            if (iValue >= 0)
                //            {
                //                progressBarTaiDuLieu.Value = iValue - test;
                //            }
                //        }
                //    }
                //    else
                //    {
                //        Cursor = Cursors.Default;
                //        axCZKEM1.GetLastError(ref idwErrorCode);
                //        if (idwErrorCode != 0)
                //        {
                //            MessageBox.Show("Reading data from terminal failed,ErrorCode: " + idwErrorCode, "Error");
                //        }
                //        else
                //        {
                //            MessageBox.Show("No data from terminal returns!", "Error");
                //        }
                //    }
                //    axCZKEM1.EnableDevice(iMachineNumber, bFlag: true);
                //    Cursor = Cursors.Default;
                //}
                //if (comboBoxLuaChonTai.SelectedIndex != 1)
                //{
                //    return;
                //}
                //int iDemNgayTai = 0;
                //int iKiemTra = 0;
                //string sTongNgayTai = Convert.ToInt32((etime_log.Value - etime_log.Value).TotalDays).ToString();
                //if (Convert.ToInt32(sTongNgayTai) < 0)
                //{
                //    MessageBox.Show("Xin chọn lại ngày");
                //    return;
                //}
                //if (axCZKEM1.ReadGeneralLogData(iMachineNumber))
                //{
                //    while (axCZKEM1.GetGeneralExtLogData(iMachineNumber, ref idwEnrollNumber, ref idwVerifyMode2, ref idwInOutMode2, ref idwYear2, ref idwMonth, ref idwDay, ref idwHour, ref idwMinute, ref idwSecond, ref idwWorkCode, ref idwReserved))
                //    {
                //        iDemNgayTai = 0;
                //        DateTime dKiemTraThoiGianTai = new DateTime(idwYear2, idwMonth, idwDay, 0, 0, 0);
                //        for (int _tongNgayTai = 0; _tongNgayTai <= Convert.ToInt32(sTongNgayTai); _tongNgayTai++)
                //        {
                //            iKiemTra = 0;
                //            DateTime dt = default(DateTime);
                //            DateTime dNgayTai = Convert.ToDateTime(etime_log.Value.AddDays(iDemNgayTai).ToString());
                //            if (dNgayTai == dKiemTraThoiGianTai)
                //            {
                //                iKiemTra = 1;
                //                break;
                //            }
                //            iDemNgayTai++;
                //        }
                //        if (iKiemTra == 1)
                //        {
                //            DateTime dNgayCham = new DateTime(idwYear2, idwMonth, idwDay);
                //            DateTime dGioCham = new DateTime(idwYear2, idwMonth, idwDay, idwHour, idwMinute, idwSecond);
                //            int DemKiemTraNhanVien = 0;
                //            int addGioChamCong = DGVGioTai.Rows.Add();
                //            DGVGioTai.Rows[addGioChamCong].Cells[0].Value = idwEnrollNumber.ToString();
                //            DGVGioTai.Rows[addGioChamCong].Cells[1].Value = dNgayCham.ToString();
                //            DGVGioTai.Rows[addGioChamCong].Cells[2].Value = dGioCham.ToString();
                //            DGVGioTai.Rows[addGioChamCong].Cells[3].Value = idwInOutMode2.ToString();
                //            DGVGioTai.Rows[addGioChamCong].Cells[4].Value = idwVerifyMode2.ToString();
                //            DGVGioTai.Rows[addGioChamCong].Cells[5].Value = sIDMayChamCong;
                //            DGVGioTai.Rows[addGioChamCong].Cells[6].Value = sTenMayChamCong;
                //            DataTable dtKiemTraNhanVien = new DataTable();
                //            _nhanVienDTO.MaChamCong = idwEnrollNumber.ToString();
                //            dtKiemTraNhanVien = _nhanVienBLL.NhanVienGetByMaChamCong(_nhanVienDTO);
                //            for (int iKiemTraNhanVien = 0; iKiemTraNhanVien < dtKiemTraNhanVien.Rows.Count; iKiemTraNhanVien++)
                //            {
                //                DemKiemTraNhanVien = 1;
                //            }
                //            if (DemKiemTraNhanVien == 1)
                //            {
                //                _checkInOutDTO.MaChamCong = Convert.ToInt32(DGVGioTai.Rows[addGioChamCong].Cells[0].Value.ToString());
                //                _checkInOutDTO.NgayCham = Convert.ToDateTime(DGVGioTai.Rows[addGioChamCong].Cells[1].Value.ToString());
                //                _checkInOutDTO.GioCham = Convert.ToDateTime(DGVGioTai.Rows[addGioChamCong].Cells[2].Value.ToString());
                //                _checkInOutDTO.KieuCham = DGVGioTai.Rows[addGioChamCong].Cells[3].Value.ToString();
                //                _checkInOutDTO.NguonCham = DGVGioTai.Rows[addGioChamCong].Cells[4].Value.ToString();
                //                _checkInOutDTO.MaSoMay = Convert.ToInt32(DGVGioTai.Rows[addGioChamCong].Cells[5].Value.ToString());
                //                _checkInOutDTO.TenMay = DGVGioTai.Rows[addGioChamCong].Cells[6].Value.ToString();
                //                _checkInOutBLL.Insert_CheckinOut(_checkInOutDTO);
                //            }
                //            progressBarTaiDuLieu.Maximum = iValue;
                //            test--;
                //            dem++;
                //            progressBarTaiDuLieu.Text = (dem + 1) * 100 / iValue + "%";
                //            Application.DoEvents();
                //            _ = iValue;
                //            _ = 0;
                //            if (iValue >= 0)
                //            {
                //                progressBarTaiDuLieu.Value = iValue - test;
                //            }
                //        }
                //    }
                //}
                //else
                //{
                //    Cursor = Cursors.Default;
                //    axCZKEM1.GetLastError(ref idwErrorCode);
                //    if (idwErrorCode != 0)
                //    {
                //        MessageBox.Show("Reading data from terminal failed,ErrorCode: " + idwErrorCode, "Error");
                //    }
                //    else
                //    {
                //        MessageBox.Show("Không có dữ liệu trên máy chấm công", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                //    }
                //}
                //axCZKEM1.EnableDevice(iMachineNumber, bFlag: true);
                //Cursor = Cursors.Default;
            }
            catch (Exception ex)
            {
                RJMessageBox.Show(ex.Message, "Thông báo");
            }

        }

        private void comboBoxLuaChonTai_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBoxLuaChonTai.SelectedIndex == 0 || comboBoxLuaChonTai.SelectedIndex == 2)
            {
                chk_xoagio.Enabled = false;
                etime_log.Enabled = false;
                stime_log.Enabled = false;
            }
            if (comboBoxLuaChonTai.SelectedIndex == 1)
            {
                chk_xoagio.Enabled = true;
                etime_log.Enabled = true;
                stime_log.Enabled = true;
            }
        }
    }
}
