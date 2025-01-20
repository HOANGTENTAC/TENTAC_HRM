using System;
using System.Data;
using System.Net;
using System.Windows.Forms;
using TENTAC_HRM.Bll.MayChamCong;
using TENTAC_HRM.Custom;
using TENTAC_HRM.Models.MayChamCongModel;
using zkemkeeper;

namespace TENTAC_HRM.Forms.MayChamCong
{
    public partial class frm_DangKyMayChamCong : Form
    {
        public CZKEMClass axCZKEM1 = new CZKEMClass();
        private bool bIsConnected = false;

        private int iMachineNumber = 1;

        private MayChamCongModel _mayChamCongDTO = new MayChamCongModel();

        private MayChamCongBLL _mayChamCongBLL = new MayChamCongBLL();

        private int iNgonNgu;

        private string sSuDungWeb;

        private string sMaMayChamCong;

        private int a;

        private int b;

        private int c;

        private int _ketQua;

        private string _a;

        private string _b;

        private string _c;
        public int[] idPermision { get; set; }
        public frm_DangKyMayChamCong(int[] permissions = null)
        {
            InitializeComponent();
            idPermision = permissions;
        }

        private void frmDangKyMayChamCong_Load(object sender, EventArgs e)
        {
            comboBoxMayChamcong.DataSource = _mayChamCongBLL.GETDANHSACHMCC();
            comboBoxMayChamcong.DisplayMember = "TenMCC";
            comboBoxMayChamcong.ValueMember = "MaMCC";
        }

        private void ActiveKey()
        {
            _a = txtSerial.Text.Substring(0, 2);
            int i = txtSerial.Text.Length - 4;
            _b = txtSerial.Text.Substring(i);
            int j = txtSerial.Text.Length - 2;
            _c = txtSerial.Text.Substring(j);
            a = Convert.ToInt32(_a);
            b = Convert.ToInt32(_b);
            c = Convert.ToInt32(_c);
            _ketQua = a + b + c + 240789 - c;
        }
        private void frmDangKyMayChamCong_FormClosing(object sender, FormClosingEventArgs e)
        {
            axCZKEM1.Disconnect();
        }

        [Obsolete]
        private void btnKetNoi_Click(object sender, EventArgs e)
        {
            if (lbKieuKetNoiThongTin.Text == "TCP/IP")
            {
                if (sSuDungWeb == "False")
                {
                    bIsConnected = axCZKEM1.Connect_Net(lbDiaChiIPThongTin.Text, Convert.ToInt32(lbPortThongTin.Text));
                    if (bIsConnected)
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
                    }
                    else
                    {
                        RJMessageBox.Show("Không kết nối được với máy " + comboBoxMayChamcong.Text);
                    }
                }
                else
                {
                    IPHostEntry hostname = Dns.GetHostByName(lbDiaChiWebThongTin.Text);
                    IPAddress[] ip = hostname.AddressList;
                    string _IpWeb = ip[0].ToString();
                    Cursor = Cursors.WaitCursor;
                    bIsConnected = axCZKEM1.Connect_Net(_IpWeb, Convert.ToInt32(lbPortThongTin.Text));
                    if (bIsConnected)
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
                    }
                    else
                    {
                        RJMessageBox.Show("Không kết nối được với máy " + comboBoxMayChamcong.Text);
                    }
                }
            }
            if (lbKieuKetNoiThongTin.Text == "RS232/484")
            {
                RJMessageBox.Show("RS232/484");
            }
            else
            {
                if (!(lbKieuKetNoiThongTin.Text == "USB"))
                {
                    return;
                }
                iMachineNumber = 1;
                bIsConnected = axCZKEM1.Connect_USB(iMachineNumber);
                if (bIsConnected)
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
                    RJMessageBox.Show("Không kết nối được với máy " + comboBoxMayChamcong.Text);
                }
                Cursor = Cursors.Default;
            }
        }

        private void btnDangKy_Click(object sender, EventArgs e)
        {
            int _soDangKy;
            if (iNgonNgu == 0)
            {
                if (txtSerial.Text.Trim() == "")
                {
                    RJMessageBox.Show("Bạn chưa kết nối để có số serial", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Hand);
                    return;
                }
                ActiveKey();
                _soDangKy = int.Parse(txtDangKy.Text);
                if (_soDangKy != _ketQua)
                {
                    RJMessageBox.Show("Sai số đăng ký");
                    return;
                }
                RJMessageBox.Show("Đăng ký thành công");
                axCZKEM1.Disconnect();
                _mayChamCongDTO.MaMCC = sMaMayChamCong;
                _mayChamCongDTO.Serial = txtSerial.Text;
                _mayChamCongDTO.SoDangKy = txtDangKy.Text;
                _mayChamCongBLL.SUAACTIVEKEY(_mayChamCongDTO);
            }
            if (iNgonNgu != 1)
            {
                return;
            }
            if (txtSerial.Text.Trim() == "")
            {
                RJMessageBox.Show("You are not connected to the serial number", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Hand);
                return;
            }
            ActiveKey();
            _soDangKy = int.Parse(txtDangKy.Text);
            if (_soDangKy == _ketQua)
            {
                RJMessageBox.Show("Successfully Registered");
                axCZKEM1.Disconnect();
                _mayChamCongDTO.MaMCC = sMaMayChamCong;
                _mayChamCongDTO.Serial = txtSerial.Text;
                _mayChamCongDTO.SoDangKy = txtDangKy.Text;
                _mayChamCongBLL.SUAACTIVEKEY(_mayChamCongDTO);
            }
            else
            {
                RJMessageBox.Show("False registration numbers");
            }
        }
        private void comboBoxMayChamcong_SelectedIndexChanged(object sender, EventArgs e)
        {
            DataTable dtgetThongTin = new DataTable();
            _mayChamCongDTO.TenMCC = comboBoxMayChamcong.Text;
            dtgetThongTin = _mayChamCongBLL.MayChamCongGetAllByTenMCC(_mayChamCongDTO);
            for (int i = 0; i < dtgetThongTin.Rows.Count; i++)
            {
                sMaMayChamCong = dtgetThongTin.Rows[i]["MaMCC"].ToString();
                lbIDMayThongTin.Text = dtgetThongTin.Rows[i]["IDMCC"].ToString();
                lbKieuKetNoiThongTin.Text = dtgetThongTin.Rows[i]["KieuKetNoi"].ToString();
                lbDiaChiIPThongTin.Text = dtgetThongTin.Rows[i]["DiaChiIP"].ToString();
                lbPortThongTin.Text = dtgetThongTin.Rows[i]["Port"].ToString();
                lbCongCOMThongTin.Text = dtgetThongTin.Rows[i]["CongCOM"].ToString();
                lbTocDoTruyenThongTin.Text = dtgetThongTin.Rows[i]["TocDoTruyen"].ToString();
                lbDiaChiWebThongTin.Text = dtgetThongTin.Rows[i]["DiaChiWeb"].ToString();
                sSuDungWeb = dtgetThongTin.Rows[i]["SuDungWeb"].ToString();
                if (sSuDungWeb == "True")
                {
                    lbKetNoiTuXaThongTin.Text = "Có";
                }
                else
                {
                    lbKetNoiTuXaThongTin.Text = "Không";
                }
            }
        }
    }
}
