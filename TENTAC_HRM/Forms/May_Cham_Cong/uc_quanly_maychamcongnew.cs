using System;
using System.Data;
using System.Net;
using System.Windows.Forms;
using TENTAC_HRM.BusinessLogicLayer.MayChamCong;
using TENTAC_HRM.Forms.ChamCong;
using TENTAC_HRM.Common;
using TENTAC_HRM.Custom;
using TENTAC_HRM.DataTransferObject.MayChamCong;
using zkemkeeper;

namespace TENTAC_HRM.Forms.May_Cham_Cong
{
    public partial class uc_quanly_maychamcongnew : UserControl
    {
        DataProvider provider = new DataProvider();
        public CZKEMClass axCZKEM1 = new CZKEMClass();

        private bool _bIsConnected = false;

        private int iMachineNumber = 1;

        private string hostCheckIp;

        private MayChamCongDTO _mayChamCongDTO = new MayChamCongDTO();

        private MayChamCongBLL _mayChamCongBLL = new MayChamCongBLL();

        private int kiemtra;

        private MaTuDong _maTuDong = new MaTuDong();

        private string sNgayDangKyTenMien;

        private string sSuDungWeb;

        private string sTrangThai;

        private string sTrangThaiMay;

        private string sMaMay;
        public static uc_quanly_maychamcongnew _instance;
        public static uc_quanly_maychamcongnew Instance
        {
            get
            {
                _instance = new uc_quanly_maychamcongnew();
                return _instance;
            }
        }
        public uc_quanly_maychamcongnew()
        {
            InitializeComponent();
        }

        private void uc_quanly_maychamcongnew_Load(object sender, EventArgs e)
        {
            loadDatagirdview();
            load_mcc();
        }
        private void loadDatagirdview()
        {
            DataTable dtMayChamCong = new DataTable();
            dtMayChamCong = _mayChamCongBLL.GETDANHSACHMCC();
            for (int iMayChamCong = 0; iMayChamCong < dtMayChamCong.Rows.Count; iMayChamCong++)
            {
                int addMayChamCong = DGVMayChamCong.Rows.Add();
                DGVMayChamCong.Rows[addMayChamCong].Cells[0].Value = dtMayChamCong.Rows[iMayChamCong]["MaMCC"].ToString();
                DGVMayChamCong.Rows[addMayChamCong].Cells[1].Value = dtMayChamCong.Rows[iMayChamCong]["TenMCC"].ToString();
                DGVMayChamCong.Rows[addMayChamCong].Cells[2].Value = dtMayChamCong.Rows[iMayChamCong]["IDMCC"].ToString();
                DGVMayChamCong.Rows[addMayChamCong].Cells[3].Value = dtMayChamCong.Rows[iMayChamCong]["KieuKetNoi"].ToString();
                DGVMayChamCong.Rows[addMayChamCong].Cells[4].Value = dtMayChamCong.Rows[iMayChamCong]["DiaChiIP"].ToString();
                DGVMayChamCong.Rows[addMayChamCong].Cells[5].Value = dtMayChamCong.Rows[iMayChamCong]["Port"].ToString();
                DGVMayChamCong.Rows[addMayChamCong].Cells[6].Value = dtMayChamCong.Rows[iMayChamCong]["CongCOM"].ToString();
                DGVMayChamCong.Rows[addMayChamCong].Cells[7].Value = dtMayChamCong.Rows[iMayChamCong]["TocDoTruyen"].ToString();
                DGVMayChamCong.Rows[addMayChamCong].Cells[8].Value = dtMayChamCong.Rows[iMayChamCong]["DiaChiWeb"].ToString();
                DGVMayChamCong.Rows[addMayChamCong].Cells[9].Value = dtMayChamCong.Rows[iMayChamCong]["NgayDangKyTenMien"].ToString();
                DGVMayChamCong.Rows[addMayChamCong].Cells[10].Value = dtMayChamCong.Rows[iMayChamCong]["SuDungWeb"].ToString();
                DGVMayChamCong.Rows[addMayChamCong].Cells[11].Value = dtMayChamCong.Rows[iMayChamCong]["Serial"].ToString();
                DGVMayChamCong.Rows[addMayChamCong].Cells[12].Value = dtMayChamCong.Rows[iMayChamCong]["SoDangKy"].ToString();
                DGVMayChamCong.Rows[addMayChamCong].Cells[13].Value = dtMayChamCong.Rows[iMayChamCong]["TrangThai"].ToString();
                DGVMayChamCong.Rows[addMayChamCong].Cells[14].Value = dtMayChamCong.Rows[iMayChamCong]["TrangThaiMay"].ToString();
            }
        }

        [Obsolete]
        private void linkKiemTraSerial_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            if (comboboxKieuKetNoi.SelectedIndex == 0)
            {
                if (!checkBoxSuDungDiaChiWeb.Checked)
                {
                    _bIsConnected = axCZKEM1.Connect_Net(txtDiaChiIP.Text, Convert.ToInt32(txtPort.Text));
                    if (_bIsConnected)
                    {
                        iMachineNumber = 1;
                        axCZKEM1.RegEvent(iMachineNumber, 65535);
                        string sdwSerialNumber = "";
                        Cursor = Cursors.WaitCursor;
                        if (axCZKEM1.GetSerialNumber(iMachineNumber, out sdwSerialNumber))
                        {
                            txtSerial.Text = sdwSerialNumber;
                        }
                        Cursor = Cursors.Default;
                        axCZKEM1.Disconnect();
                    }
                    else
                    {
                        RJMessageBox.Show("Không kết nối được với máy ");
                        Cursor = Cursors.Default;
                    }
                }
                else
                {
                    IPHostEntry hostname = Dns.GetHostByName(txtDiaChiWeb.Text);
                    IPAddress[] ip = hostname.AddressList;
                    string _IpWeb = ip[0].ToString();
                    Cursor = Cursors.WaitCursor;
                    _bIsConnected = axCZKEM1.Connect_Net(_IpWeb, Convert.ToInt32(txtPort.Text));
                    if (_bIsConnected)
                    {
                        iMachineNumber = 1;
                        axCZKEM1.RegEvent(iMachineNumber, 65535);
                        string sdwSerialNumber = "";
                        Cursor = Cursors.WaitCursor;
                        if (axCZKEM1.GetSerialNumber(iMachineNumber, out sdwSerialNumber))
                        {
                            txtSerial.Text = sdwSerialNumber;
                        }
                        Cursor = Cursors.Default;
                        axCZKEM1.Disconnect();
                    }
                    else
                    {
                        RJMessageBox.Show("Không kết nối được với máy ");
                    }
                }
            }
            if (comboboxKieuKetNoi.SelectedIndex == 1)
            {
                RJMessageBox.Show("RS232/484");
            }
            else
            {
                if (comboboxKieuKetNoi.SelectedIndex != 2)
                {
                    return;
                }
                iMachineNumber = 1;
                _bIsConnected = axCZKEM1.Connect_USB(iMachineNumber);
                if (_bIsConnected)
                {
                    axCZKEM1.RegEvent(iMachineNumber, 65535);
                    string sdwSerialNumber = "";
                    Cursor = Cursors.WaitCursor;
                    if (axCZKEM1.GetSerialNumber(iMachineNumber, out sdwSerialNumber))
                    {
                        txtSerial.Text = sdwSerialNumber;
                    }
                }
                else
                {
                    RJMessageBox.Show("Không kết nối được với máy ");
                }
                Cursor = Cursors.Default;
                axCZKEM1.Disconnect();
            }
        }

        private void thongTinMCC()
        {
            int _value = 0;
            string _phienBanVanTay = "";
            string sPlatform = "";
            if (axCZKEM1.GetDeviceStatus(1, 1, ref _value))
            {
                txtNhanVienQuanLy.Text = _value.ToString();
            }
            if (axCZKEM1.GetDeviceStatus(1, 2, ref _value))
            {
                txtTongSoNhanVien.Text = _value.ToString();
            }
            if (axCZKEM1.GetDeviceStatus(1, 3, ref _value))
            {
                txtTongSoVanTay.Text = _value.ToString();
            }
            if (axCZKEM1.GetDeviceStatus(1, 4, ref _value))
            {
                txtTongSoMatMa.Text = _value.ToString();
            }
            if (axCZKEM1.GetDeviceStatus(1, 5, ref _value))
            {
                txtTongSoRecordQuanLy.Text = _value.ToString();
            }
            if (axCZKEM1.GetDeviceStatus(1, 6, ref _value))
            {
                txtTongSoDuLieuChamCong.Text = _value.ToString();
            }
            if (axCZKEM1.GetDeviceStatus(1, 7, ref _value))
            {
                txtVanTay.Text = _value.ToString();
            }
            if (axCZKEM1.GetDeviceStatus(1, 8, ref _value))
            {
                txtNhanVien.Text = _value.ToString();
            }
            if (axCZKEM1.GetDeviceStatus(1, 9, ref _value))
            {
                txtDuLieuChamCong.Text = _value.ToString();
            }
            if (axCZKEM1.GetDeviceStatus(1, 21, ref _value))
            {
                txtTongSoKhuonMat.Text = _value.ToString();
            }
            if (axCZKEM1.GetDeviceStatus(1, 22, ref _value))
            {
                txtKhuonMat.Text = _value.ToString();
            }
            if (axCZKEM1.GetSysOption(1, "~ZKFPVersion", out _phienBanVanTay))
            {
                txtThuatToanVanTay.Text = _phienBanVanTay;
            }
            if (axCZKEM1.GetPlatform(iMachineNumber, ref sPlatform))
            {
                txtLoaiZEM.Text = sPlatform;
            }
            int idwYear = 0;
            int idwMonth = 0;
            int idwDay = 0;
            int idwHour = 0;
            int idwMinute = 0;
            int idwSecond = 0;
            if (axCZKEM1.GetDeviceTime(iMachineNumber, ref idwYear, ref idwMonth, ref idwDay, ref idwHour, ref idwMinute, ref idwSecond))
            {
                DateTime dtThoiGian = Convert.ToDateTime(idwYear + "-" + idwMonth + "-" + idwDay + " " + idwHour + ":" + idwMinute + ":" + idwSecond);
                txtThoiGian.Text = dtThoiGian.ToString();
            }
        }
        [Obsolete]
        private void capNhatKetNoi()
        {
            if (comboboxKieuKetNoi.Text == "TCP/IP")
            {
                if (!checkBoxSuDungDiaChiWeb.Checked)
                {
                    _bIsConnected = axCZKEM1.Connect_Net(txtDiaChiIP.Text, Convert.ToInt32(txtPort.Text));
                }
                else
                {
                    IPHostEntry hostname = Dns.GetHostByName(txtDiaChiWeb.Text);
                    IPAddress[] ip = hostname.AddressList;
                    string _IpWeb = ip[0].ToString();
                    _bIsConnected = axCZKEM1.Connect_Net(_IpWeb, Convert.ToInt32(txtPort.Text));
                }
            }
            if (comboboxKieuKetNoi.Text == "RS232/484")
            {
            }
            if (!(comboboxKieuKetNoi.Text == "USB"))
            {
            }
        }

        private void btnThemMoi_Click(object sender, EventArgs e)
        {
            kiemtra = 1;
            txtMaMay.Text = _maTuDong.sTuDongDienMCC(txtMaMay.Text);
            txtTenMay.Text = "Máy " + txtMaMay.Text;
            txtIDMay.Text = "1";
            comboboxKieuKetNoi.SelectedIndex = 0;
            txtDiaChiIP.Text = "192.168.1.201";
            txtPort.Text = "4370";
            comboBoxCongCom.SelectedIndex = 0;
            comboBoxTocDoTruyen.SelectedIndex = 4;
            comboBoxTrangThaiMay.SelectedIndex = 0;
            txtDiaChiWeb.Text = "google.com.vn";
            checkBoxSuDungDiaChiWeb.Checked = false;
            txtSerial.Text = string.Empty;
            checkTrangThaiSuDung.Checked = true;
            txtDiaChiWeb.Enabled = false;
        }

        private void btnLuu_Click(object sender, EventArgs e)
        {
            DGVMayChamCong.Rows.Clear();
            bool bSuDungWeb = (checkBoxSuDungDiaChiWeb.Checked ? true : false);
            bool bTrangThai = (checkTrangThaiSuDung.Checked ? true : false);
            if (kiemtra == 0)
            {
                _mayChamCongDTO.MaMCC = txtMaMay.Text;
                _mayChamCongDTO.TenMCC = txtTenMay.Text;
                _mayChamCongDTO.IDMCC = Convert.ToInt32(txtIDMay.Text);
                _mayChamCongDTO.KieuKetNoi = comboboxKieuKetNoi.Text;
                _mayChamCongDTO.DiaChiIP = txtDiaChiIP.Text;
                _mayChamCongDTO.Port = Convert.ToInt32(txtPort.Text);
                _mayChamCongDTO.CongCOM = Convert.ToInt32(comboBoxCongCom.Text);
                _mayChamCongDTO.TocDoTruyen = comboBoxTocDoTruyen.Text;
                if (comboBoxTrangThaiMay.SelectedIndex == 0)
                {
                    _mayChamCongDTO.TrangThaiMay = 1;
                }
                else
                {
                    _mayChamCongDTO.TrangThaiMay = 2;
                }
                _mayChamCongDTO.DiaChiWeb = txtDiaChiWeb.Text;
                _mayChamCongDTO.SuDungWeb = bSuDungWeb;
                _mayChamCongDTO.TrangThai = bTrangThai;
                _mayChamCongBLL.SUAMAYCHAMCONG(_mayChamCongDTO);
                loadDatagirdview();
                return;
            }
            _mayChamCongDTO.MaMCC = txtMaMay.Text;
            _mayChamCongDTO.TenMCC = txtTenMay.Text;
            _mayChamCongDTO.IDMCC = Convert.ToInt32(txtIDMay.Text);
            _mayChamCongDTO.KieuKetNoi = comboboxKieuKetNoi.Text;
            _mayChamCongDTO.DiaChiIP = txtDiaChiIP.Text;
            _mayChamCongDTO.Port = Convert.ToInt32(txtPort.Text);
            _mayChamCongDTO.CongCOM = Convert.ToInt32(comboBoxCongCom.Text);
            _mayChamCongDTO.TocDoTruyen = comboBoxTocDoTruyen.Text;
            if (comboBoxTrangThaiMay.SelectedIndex == 0)
            {
                _mayChamCongDTO.TrangThaiMay = 1;
            }
            else
            {
                _mayChamCongDTO.TrangThaiMay = 2;
            }
            _mayChamCongDTO.DiaChiWeb = txtDiaChiWeb.Text;
            _mayChamCongDTO.SuDungWeb = bSuDungWeb;
            _mayChamCongDTO.Serial = "";
            _mayChamCongDTO.SoDangKy = "";
            _mayChamCongDTO.TrangThai = bTrangThai;
            _mayChamCongDTO.NgayDangKyTenMien = Convert.ToDateTime(DateTime.Now.ToString());
            _mayChamCongBLL.THEMMAYCHAMCONG(_mayChamCongDTO);
            loadDatagirdview();
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            if (sMaMay == "" || sMaMay == null)
            {
                RJMessageBox.Show("Bạn chưa chọn máy chấm công cần xóa");
                return;
            }
            _mayChamCongDTO.MaMCC = sMaMay;
            _mayChamCongBLL.DELETEMAYCHAMCONG(_mayChamCongDTO);
            DGVMayChamCong.Rows.Clear();
            loadDatagirdview();
        }

        [Obsolete]
        private void btnKiemTraKetNoi_Click(object sender, EventArgs e)
        {
            if (comboboxKieuKetNoi.Text == "TCP/IP")
            {
                if (!checkBoxSuDungDiaChiWeb.Checked)
                {
                    Cursor = Cursors.WaitCursor;
                    _bIsConnected = axCZKEM1.Connect_Net(txtDiaChiIP.Text, Convert.ToInt32(txtPort.Text));
                    thongTinMCC();
                    Cursor = Cursors.Default;
                    axCZKEM1.Disconnect();
                }
                else
                {
                    IPHostEntry hostname = Dns.GetHostByName(txtDiaChiWeb.Text);
                    IPAddress[] ip = hostname.AddressList;
                    string _IpWeb = ip[0].ToString();
                    Cursor = Cursors.WaitCursor;
                    _bIsConnected = axCZKEM1.Connect_Net(_IpWeb, Convert.ToInt32(txtPort.Text));
                    thongTinMCC();
                    Cursor = Cursors.Default;
                    axCZKEM1.Disconnect();
                }
            }
            if (comboboxKieuKetNoi.Text == "RS232/484")
            {
            }
            if (comboboxKieuKetNoi.Text == "USB")
            {
                Cursor = Cursors.WaitCursor;
                _bIsConnected = axCZKEM1.Connect_USB(iMachineNumber);
                thongTinMCC();
                Cursor = Cursors.Default;
                axCZKEM1.Disconnect();
            }
        }

        private void btnDangKyMayChamCong_Click(object sender, EventArgs e)
        {
            frmDangKyMayChamCong _dangKyMayChamCong = new frmDangKyMayChamCong();
            _dangKyMayChamCong.ShowDialog();
        }

        private void checkBoxSuDungDiaChiWeb_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBoxSuDungDiaChiWeb.Checked)
            {
                txtDiaChiWeb.Enabled = true;
            }
            else
            {
                txtDiaChiWeb.Enabled = false;
            }
        }
        [Obsolete]
        private void btnDongBoThoiGian_Click(object sender, EventArgs e)
        {
            Cursor = Cursors.WaitCursor;
            capNhatKetNoi();
            if (axCZKEM1.SetDeviceTime(iMachineNumber))
            {
                axCZKEM1.RefreshData(iMachineNumber);
                RJMessageBox.Show("Đồng bộ thời gian thành công", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
            }
            Cursor = Cursors.Default;
        }
        [Obsolete]
        private void btnXoaNhanVienQuanLy_Click(object sender, EventArgs e)
        {
            capNhatKetNoi();
            if (RJMessageBox.Show("Bạn có đồng ý xóa quyến quản lý trên máy chấm công không ? ", "Thông Báo", MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1) == DialogResult.Yes)
            {
                axCZKEM1.ClearAdministrators(1);
                RJMessageBox.Show("Xóa quản lý thành công", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
            }
        }
        [Obsolete]
        private void btnXoaDuLieuChamCong_Click(object sender, EventArgs e)
        {
            capNhatKetNoi();
            if (RJMessageBox.Show("Bạn có đồng ý xóa dữ liệu chấm công không ? ", "Thông Báo", MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1) == DialogResult.Yes && axCZKEM1.ClearGLog(iMachineNumber))
            {
                axCZKEM1.RefreshData(iMachineNumber);
                RJMessageBox.Show("Xóa dữ liệu vào ra thành công", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
            }
        }
        [Obsolete]
        private void btnXoaToanBoDuLieu_Click(object sender, EventArgs e)
        {
            capNhatKetNoi();
            if (RJMessageBox.Show("Bạn có đồng ý xóa toàn bộ dữ liệu không ? ", "Thông Báo", MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1) == DialogResult.Yes)
            {
                axCZKEM1.ClearKeeperData(1);
                RJMessageBox.Show("Xóa toàn bộ dữ liệu thành công thành công", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
            }
        }
        [Obsolete]
        private void btnKhoiDongLaiMayChamCong_Click(object sender, EventArgs e)
        {
            int idwErrorCode = 0;
            Cursor = Cursors.WaitCursor;
            capNhatKetNoi();
            if (axCZKEM1.RestartDevice(iMachineNumber))
            {
                RJMessageBox.Show("Máy chấm công đang được khởi động lại", "Thành công");
            }
            else
            {
                axCZKEM1.GetLastError(ref idwErrorCode);
                RJMessageBox.Show("Operation failed,ErrorCode=" + idwErrorCode, "Error");
            }
            Cursor = Cursors.Default;
        }

        [Obsolete]
        private void btnTatMayChamCong_Click(object sender, EventArgs e)
        {
            int idwErrorCode = 0;
            Cursor = Cursors.WaitCursor;
            capNhatKetNoi();
            if (axCZKEM1.PowerOffDevice(iMachineNumber))
            {
                RJMessageBox.Show("Máy chấm công đã được tắt", "Thành công");
            }
            else
            {
                axCZKEM1.GetLastError(ref idwErrorCode);
                RJMessageBox.Show("Operation failed,ErrorCode=" + idwErrorCode, "Error");
            }
            Cursor = Cursors.Default;
        }

        private void DGVMayChamCong_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            load_mcc();
        }
        private void load_mcc()
        {
            if (DGVMayChamCong.Rows.Count > 0)
            {
                kiemtra = 0;
                sMaMay = DGVMayChamCong.CurrentRow.Cells[0].Value.ToString();
                txtMaMay.Text = DGVMayChamCong.CurrentRow.Cells[0].Value.ToString();
                txtTenMay.Text = DGVMayChamCong.CurrentRow.Cells[1].Value.ToString();
                txtIDMay.Text = DGVMayChamCong.CurrentRow.Cells[2].Value.ToString();
                comboboxKieuKetNoi.Text = DGVMayChamCong.CurrentRow.Cells[3].Value.ToString();
                txtDiaChiIP.Text = DGVMayChamCong.CurrentRow.Cells[4].Value.ToString();
                txtPort.Text = DGVMayChamCong.CurrentRow.Cells[5].Value.ToString();
                comboBoxCongCom.Text = DGVMayChamCong.CurrentRow.Cells[6].Value.ToString();
                comboBoxTocDoTruyen.Text = DGVMayChamCong.CurrentRow.Cells[7].Value.ToString();
                txtDiaChiWeb.Text = DGVMayChamCong.CurrentRow.Cells[8].Value.ToString();
                sNgayDangKyTenMien = DGVMayChamCong.CurrentRow.Cells[9].Value.ToString();
                sSuDungWeb = DGVMayChamCong.CurrentRow.Cells[10].Value.ToString();
                if (sSuDungWeb == "True")
                {
                    checkBoxSuDungDiaChiWeb.Checked = true;
                    txtDiaChiWeb.Enabled = true;
                }
                else
                {
                    checkBoxSuDungDiaChiWeb.Checked = false;
                    txtDiaChiWeb.Enabled = false;
                }
                txtSerial.Text = DGVMayChamCong.CurrentRow.Cells[11].Value.ToString();
                sTrangThai = DGVMayChamCong.CurrentRow.Cells[13].Value.ToString();
                if (sTrangThai == "True")
                {
                    checkTrangThaiSuDung.Checked = true;
                }
                else
                {
                    checkTrangThaiSuDung.Checked = false;
                }
                sTrangThaiMay = DGVMayChamCong.CurrentRow.Cells[14].Value.ToString();
                if (sTrangThaiMay == "1")
                {
                    comboBoxTrangThaiMay.SelectedIndex = 0;
                }
                else
                {
                    comboBoxTrangThaiMay.SelectedIndex = 1;
                }
            }
        }
        private void btn_close_Click(object sender, EventArgs e)
        {
            provider.btn_close(this.Parent);
        }
    }
}
