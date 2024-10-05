using System;
using System.Data;
using System.Net;
using System.Windows.Forms;
using TENTAC_HRM.BusinessLogicLayer.MayChamCong;
using TENTAC_HRM.BusinessLogicLayer.QuanLyNhanVienBLL;
using TENTAC_HRM.Custom;
using TENTAC_HRM.DataAccessLayer.MayChamCong.DuLieuMayChamCongDAL;
using TENTAC_HRM.Model;
using zkemkeeper;

namespace TENTAC_HRM.May_Cham_Cong
{
    public partial class uc_taitudong : UserControl
    {
        DataProvider provider = new DataProvider();
        public CZKEMClass axCZKEM1 = new CZKEMClass();

        public bool bIsConnected;

        public int iMachineNumber;

        private NhanVien_BLL _nhanVienBLL = new NhanVien_BLL();

        private MayChamCongBLL _mayChamCongBLL = new MayChamCongBLL();

        private CheckInOut_model _checkInOut_model = new CheckInOut_model();

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

        private int _ketQua;

        private string _a;

        private string _b;

        private string _c;

        private string sdwSerialNumber;

        private int iValue = 0;
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
            DGVMayChamCong.Columns.Insert(0, new DataGridViewCheckBoxColumn());
            DGVMayChamCong.Columns[0].Width = 30;
            loadMayChamCong();
            dateTimeTuNgay.Text = DateTime.Now.ToShortDateString();
            dateTimeDenNgay.Text = DateTime.Now.ToShortDateString();
            cbo_LuaChonTai.SelectedIndex = 0;
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

        [Obsolete]
        private void btn_TaiDuLieu_Click(object sender, EventArgs e)
        {
            DGVGioTai.Rows.Clear();
            for (int iChonMayChamCong = 0; iChonMayChamCong < DGVMayChamCong.Rows.Count; iChonMayChamCong++)
            {
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
                                iMachineNumber = 1;
                                axCZKEM1.RegEvent(iMachineNumber, 65535);
                                sdwSerialNumber = "";
                                axCZKEM1.GetSerialNumber(iMachineNumber, out sdwSerialNumber);
                                ActiveKey();
                                if (sSoDangKy == "" || sSoDangKy == null)
                                {
                                    ListBoxThongBao.Items.Add(sTenMayChamCong + " chưa được đăng ký");
                                    Application.DoEvents();
                                    axCZKEM1.Disconnect();
                                    Cursor = Cursors.Default;
                                    continue;
                                }
                                if (sSerial != "" && sSoDangKy != "")
                                {
                                    if (sSerial != sdwSerialNumber)
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
                                iMachineNumber = 1;
                                axCZKEM1.RegEvent(iMachineNumber, 65535);
                                sdwSerialNumber = "";
                                axCZKEM1.GetSerialNumber(iMachineNumber, out sdwSerialNumber);
                                ActiveKey();
                                if (sSoDangKy == "" || sSoDangKy == null)
                                {
                                    ListBoxThongBao.Items.Add(sTenMayChamCong + " chưa được đăng ký");
                                    Application.DoEvents();
                                    axCZKEM1.Disconnect();
                                    Cursor = Cursors.Default;
                                    continue;
                                }
                                if (sSerial != "" && sSoDangKy != "")
                                {
                                    if (sSerial != sdwSerialNumber)
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
                    if (sKieuKetNoi == "RS232/484")
                    {
                    }
                    if (!(sKieuKetNoi == "USB"))
                    {
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
            if (axCZKEM1.GetDeviceStatus(iMachineNumber, 6, ref iValue))
            {
            }
            int dem = -1;
            int test = iValue;
            int idwErrorCode;
            int idwVerifyMode;
            int idwInOutMode;
            int idwYear;
            int idwMonth;
            int idwDay;
            int idwHour;
            int idwMinute;
            int idwSecond;
            if (_loaiManHinh == "0")
            {
                string sdwEnrollNumber = "";
                idwVerifyMode = 0;
                idwInOutMode = 0;
                idwYear = 0;
                idwMonth = 0;
                idwDay = 0;
                idwHour = 0;
                idwMinute = 0;
                idwSecond = 0;
                int idwWorkcode = 0;
                idwErrorCode = 0;
                axCZKEM1.EnableDevice(iMachineNumber, bFlag: false);
                if (cbo_LuaChonTai.SelectedIndex == 0)
                {
                    if (axCZKEM1.ReadGeneralLogData(iMachineNumber))
                    {
                        while (axCZKEM1.SSR_GetGeneralLogData(iMachineNumber, out sdwEnrollNumber, out idwVerifyMode, out idwInOutMode, out idwYear, out idwMonth, out idwDay, out idwHour, out idwMinute, out idwSecond, ref idwWorkcode))
                        {
                            int addGioChamCong = DGVGioTai.Rows.Add();
                            DGVGioTai.Rows[addGioChamCong].Cells[0].Value = sdwEnrollNumber;
                            DGVGioTai.Rows[addGioChamCong].Cells[1].Value = idwDay + "/" + idwMonth + "/" + idwYear;
                            DGVGioTai.Rows[addGioChamCong].Cells[2].Value = idwDay + "/" + idwMonth + "/" + idwYear + " " + idwHour + ":" + idwMinute + ":" + idwSecond;
                            DGVGioTai.Rows[addGioChamCong].Cells[3].Value = idwInOutMode.ToString();
                            DGVGioTai.Rows[addGioChamCong].Cells[4].Value = idwVerifyMode.ToString();
                            DGVGioTai.Rows[addGioChamCong].Cells[5].Value = sIDMayChamCong;
                            DGVGioTai.Rows[addGioChamCong].Cells[6].Value = sTenMayChamCong;
                            DataTable dtKiemTraNhanVien = new DataTable();
                            dtKiemTraNhanVien = _nhanVienBLL.NhanVienGetByMaChamCong(sdwEnrollNumber);
                            if (dtKiemTraNhanVien.Rows.Count > 0)
                            {
                                _checkInOut_model.Ma_Cham_Cong = Convert.ToInt32(DGVGioTai.Rows[addGioChamCong].Cells[0].Value.ToString());
                                _checkInOut_model.Ngay_Cham = Convert.ToDateTime(DGVGioTai.Rows[addGioChamCong].Cells[1].Value.ToString());
                                _checkInOut_model.Gio_Cham = Convert.ToDateTime(DGVGioTai.Rows[addGioChamCong].Cells[2].Value.ToString());
                                _checkInOut_model.Kieu_Cham = DGVGioTai.Rows[addGioChamCong].Cells[3].Value.ToString();
                                _checkInOut_model.Nguon_Cham = DGVGioTai.Rows[addGioChamCong].Cells[4].Value.ToString();
                                _checkInOut_model.MaSo_May = Convert.ToInt32(DGVGioTai.Rows[addGioChamCong].Cells[5].Value.ToString());
                                _checkInOut_model.Ten_May = DGVGioTai.Rows[addGioChamCong].Cells[6].Value.ToString();
                                _checkInOutBLL.Insert_CheckinOut(_checkInOut_model);
                            }
                            progressBarTaiDuLieu.Maximum = iValue;
                            test--;
                            dem++;
                            progressBarTaiDuLieu.Text = (dem + 1) * 100 / iValue + "%";
                            Application.DoEvents();
                            if (iValue < 0)
                            {
                            }
                            if (iValue >= 0)
                            {
                                progressBarTaiDuLieu.Value = iValue - test;
                            }
                        }
                    }
                    else
                    {
                        Cursor = Cursors.Default;
                        axCZKEM1.GetLastError(ref idwErrorCode);
                        if (idwErrorCode != 0)
                        {
                            RJMessageBox.Show("Reading data from terminal failed,ErrorCode: " + idwErrorCode, "Error");
                        }
                        else
                        {
                            RJMessageBox.Show("Không có dữ liệu trên máy chấm công", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                        }
                    }
                }
                if (cbo_LuaChonTai.SelectedIndex == 1)
                {
                    int iDemNgayTai = 0;
                    int iKiemTra = 0;
                    string sTongNgayTai = Convert.ToInt32((dateTimeDenNgay.Value - dateTimeTuNgay.Value).TotalDays).ToString();
                    if (Convert.ToInt32(sTongNgayTai) < 0)
                    {
                        RJMessageBox.Show("Xin chọn lại ngày");
                        return;
                    }
                    if (axCZKEM1.ReadGeneralLogData(iMachineNumber))
                    {
                        while (axCZKEM1.SSR_GetGeneralLogData(iMachineNumber, out sdwEnrollNumber, out idwVerifyMode, out idwInOutMode, out idwYear, out idwMonth, out idwDay, out idwHour, out idwMinute, out idwSecond, ref idwWorkcode))
                        {
                            iDemNgayTai = 0;
                            DateTime dKiemTraThoiGianTai = Convert.ToDateTime(idwDay + "/" + idwMonth + "/" + idwYear);
                            for (int _tongNgayTai = 0; _tongNgayTai <= Convert.ToInt32(sTongNgayTai); _tongNgayTai++)
                            {
                                iKiemTra = 0;
                                DateTime dNgayTai = Convert.ToDateTime(dateTimeTuNgay.Value.AddDays(iDemNgayTai).ToString());
                                if (dNgayTai == dKiemTraThoiGianTai)
                                {
                                    iKiemTra = 1;
                                    break;
                                }
                                iDemNgayTai++;
                            }
                            if (iKiemTra == 1)
                            {
                                int addGioChamCong = DGVGioTai.Rows.Add();
                                DGVGioTai.Rows[addGioChamCong].Cells[0].Value = sdwEnrollNumber;
                                DGVGioTai.Rows[addGioChamCong].Cells[1].Value = idwDay + "/" + idwMonth + "/" + idwYear;
                                DGVGioTai.Rows[addGioChamCong].Cells[2].Value = idwDay + "/" + idwMonth + "/" + idwYear + " " + idwHour + ":" + idwMinute + ":" + idwSecond;
                                DGVGioTai.Rows[addGioChamCong].Cells[3].Value = idwInOutMode.ToString();
                                DGVGioTai.Rows[addGioChamCong].Cells[4].Value = idwVerifyMode.ToString();
                                DGVGioTai.Rows[addGioChamCong].Cells[5].Value = sIDMayChamCong;
                                DGVGioTai.Rows[addGioChamCong].Cells[6].Value = sTenMayChamCong;
                                DataTable dtKiemTraNhanVien = new DataTable();
                                dtKiemTraNhanVien = _nhanVienBLL.NhanVienGetByMaChamCong(sdwEnrollNumber);
                                if (dtKiemTraNhanVien.Rows.Count > 0)
                                {
                                    _checkInOut_model.Ma_Cham_Cong = Convert.ToInt32(DGVGioTai.Rows[addGioChamCong].Cells[0].Value.ToString());
                                    _checkInOut_model.Ngay_Cham = Convert.ToDateTime(DGVGioTai.Rows[addGioChamCong].Cells[1].Value.ToString());
                                    _checkInOut_model.Gio_Cham = Convert.ToDateTime(DGVGioTai.Rows[addGioChamCong].Cells[2].Value.ToString());
                                    _checkInOut_model.Kieu_Cham = DGVGioTai.Rows[addGioChamCong].Cells[3].Value.ToString();
                                    _checkInOut_model.Nguon_Cham = DGVGioTai.Rows[addGioChamCong].Cells[4].Value.ToString();
                                    _checkInOut_model.MaSo_May = Convert.ToInt32(DGVGioTai.Rows[addGioChamCong].Cells[5].Value.ToString());
                                    _checkInOut_model.Ten_May = DGVGioTai.Rows[addGioChamCong].Cells[6].Value.ToString();
                                    _checkInOutBLL.Insert_CheckinOut(_checkInOut_model);
                                }
                                progressBarTaiDuLieu.Maximum = iValue;
                                test--;
                                dem++;
                                progressBarTaiDuLieu.Text = (dem + 1) * 100 / iValue + "%";
                                Application.DoEvents();
                                if (iValue < 0)
                                {
                                }
                                if (iValue >= 0)
                                {
                                    progressBarTaiDuLieu.Value = iValue - test;
                                }
                            }
                        }
                    }
                    else
                    {
                        Cursor = Cursors.Default;
                        axCZKEM1.GetLastError(ref idwErrorCode);
                        if (idwErrorCode != 0)
                        {
                            RJMessageBox.Show("Reading data from terminal failed,ErrorCode: " + idwErrorCode, "Error");
                        }
                        else
                        {
                            RJMessageBox.Show("Không có dữ liệu trên máy chấm công", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                        }
                    }
                }
                axCZKEM1.EnableDevice(iMachineNumber, bFlag: true);
                return;
            }
            idwErrorCode = 0;
            int idwEnrollNumber = 0;
            idwVerifyMode = 0;
            idwInOutMode = 0;
            idwYear = 0;
            idwMonth = 0;
            idwDay = 0;
            idwHour = 0;
            idwMinute = 0;
            idwSecond = 0;
            int idwWorkCode = 0;
            int idwReserved = 0;
            Cursor = Cursors.WaitCursor;
            axCZKEM1.EnableDevice(iMachineNumber, bFlag: false);
            if (cbo_LuaChonTai.SelectedIndex != 0)
            {
                return;
            }
            if (axCZKEM1.ReadGeneralLogData(iMachineNumber))
            {
                while (axCZKEM1.GetGeneralExtLogData(iMachineNumber, ref idwEnrollNumber, ref idwVerifyMode, ref idwInOutMode, ref idwYear, ref idwMonth, ref idwDay, ref idwHour, ref idwMinute, ref idwSecond, ref idwWorkCode, ref idwReserved))
                {
                    int addGioChamCong = DGVGioTai.Rows.Add();
                    DGVGioTai.Rows[addGioChamCong].Cells[0].Value = idwEnrollNumber.ToString();
                    DGVGioTai.Rows[addGioChamCong].Cells[1].Value = idwDay + "/" + idwMonth + "/" + idwYear;
                    DGVGioTai.Rows[addGioChamCong].Cells[2].Value = idwDay + "/" + idwMonth + "/" + idwYear + " " + idwHour + ":" + idwMinute + ":" + idwSecond;
                    DGVGioTai.Rows[addGioChamCong].Cells[3].Value = idwInOutMode.ToString();
                    DGVGioTai.Rows[addGioChamCong].Cells[4].Value = idwVerifyMode.ToString();
                    DGVGioTai.Rows[addGioChamCong].Cells[5].Value = sIDMayChamCong;
                    DGVGioTai.Rows[addGioChamCong].Cells[6].Value = sTenMayChamCong;
                    DataTable dtKiemTraNhanVien = new DataTable();
                    dtKiemTraNhanVien = _nhanVienBLL.NhanVienGetByMaChamCong(idwEnrollNumber.ToString());
                    if (dtKiemTraNhanVien.Rows.Count > 0)
                    {
                        _checkInOut_model.Ma_Cham_Cong = Convert.ToInt32(DGVGioTai.Rows[addGioChamCong].Cells[0].Value.ToString());
                        _checkInOut_model.Ngay_Cham = Convert.ToDateTime(DGVGioTai.Rows[addGioChamCong].Cells[1].Value.ToString());
                        _checkInOut_model.Gio_Cham = Convert.ToDateTime(DGVGioTai.Rows[addGioChamCong].Cells[2].Value.ToString());
                        _checkInOut_model.Kieu_Cham = DGVGioTai.Rows[addGioChamCong].Cells[3].Value.ToString();
                        _checkInOut_model.Nguon_Cham = DGVGioTai.Rows[addGioChamCong].Cells[4].Value.ToString();
                        _checkInOut_model.MaSo_May = Convert.ToInt32(DGVGioTai.Rows[addGioChamCong].Cells[5].Value.ToString());
                        _checkInOut_model.Ten_May = DGVGioTai.Rows[addGioChamCong].Cells[6].Value.ToString();
                        _checkInOutBLL.Insert_CheckinOut(_checkInOut_model);
                    }
                    progressBarTaiDuLieu.Maximum = iValue;
                    test--;
                    dem++;
                    progressBarTaiDuLieu.Text = (dem + 1) * 100 / iValue + "%";
                    Application.DoEvents();
                    if (iValue < 0)
                    {
                    }
                    if (iValue >= 0)
                    {
                        progressBarTaiDuLieu.Value = iValue - test;
                    }
                }
            }
            else
            {
                Cursor = Cursors.Default;
                axCZKEM1.GetLastError(ref idwErrorCode);
                if (idwErrorCode != 0)
                {
                    RJMessageBox.Show("Reading data from terminal failed,ErrorCode: " + idwErrorCode, "Error");
                }
                else
                {
                    RJMessageBox.Show("No data from terminal returns!", "Error");
                }
            }
            axCZKEM1.EnableDevice(iMachineNumber, bFlag: true);
            Cursor = Cursors.Default;
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

        private void cbo_LuaChonTai_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cbo_LuaChonTai.SelectedIndex == 0)
            {
                dateTimeTuNgay.Enabled = false;
                dateTimeDenNgay.Enabled = false;
            }
            if (cbo_LuaChonTai.SelectedIndex == 1)
            {
                dateTimeTuNgay.Enabled = true;
                dateTimeDenNgay.Enabled = true;
            }
        }

        private void btn_close_Click(object sender, EventArgs e)
        {
            provider.btn_close(this.Parent);
        }
    }
}
