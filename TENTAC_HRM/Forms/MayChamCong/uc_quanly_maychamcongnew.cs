using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;
using TENTAC_HRM.BusinessLogicLayer.MayChamCong;
using TENTAC_HRM.Common;
using TENTAC_HRM.Custom;
using TENTAC_HRM.DataTransferObject.MayChamCong;
using zkemkeeper;

namespace TENTAC_HRM.Forms.MayChamCong
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
            List<SqlParameter> _sqlParameter = new List<SqlParameter>();
            DataTable tb = new DataTable();
            dgv_MayChamCong.DataSource = SQLHelper.ExecuteDt("select * from  MITACOSQL.dbo.[MAYCHAMCONG]");
            stime_log.Text = DateTime.Now.ToString("yyyy/MM/dd" + " 07:50:00");
            etime_log.Text = DateTime.Now.ToString("yyyy/MM/dd" + " 16:30:00");
        }

        private void dgv_MayChamCong_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dgv_MayChamCong.CurrentCell.OwningColumn.Name == "chk_col")
            {
                foreach (DataGridViewRow item in dgv_MayChamCong.Rows)
                {
                    if (item.Cells[0].Value != null && item.Cells[0].Value.ToString() == "True")
                    {
                        item.Cells[0].Value = "False";
                    }
                }
                if (dgv_MayChamCong.CurrentRow.Cells[0].Value != null)
                {
                    if (dgv_MayChamCong.CurrentRow.Cells[0].Value.ToString() == "False" || string.IsNullOrEmpty(dgv_MayChamCong.CurrentRow.Cells[0].Value.ToString()))
                    {
                        dgv_MayChamCong.CurrentRow.Cells[0].Value = "True";
                    }
                    else
                    {
                        dgv_MayChamCong.CurrentRow.Cells[0].Value = "False";
                    }
                }
            }
        }

        private void btnKiemTraKetNoi_Click(object sender, EventArgs e)
        {
            if (dgv_MayChamCong.CurrentRow.Cells["KieuKetNoi"].Value.ToString() == "TCP/IP")
            {
                //if (!checkBoxSuDungDiaChiWeb.Checked)
                //{
                //int idwErrorCode = 0;
                _bIsConnected = false;
                Cursor = Cursors.WaitCursor;
                if (dgv_MayChamCong.CurrentRow.Cells[0].Value != null && dgv_MayChamCong.CurrentRow.Cells[0].Value.ToString() == "True")
                {
                    if (dgv_MayChamCong.CurrentRow.Cells[0].Value.ToString() == "True")
                    {
                        _bIsConnected = axCZKEM1.Connect_Net(dgv_MayChamCong.CurrentRow.Cells["DiaChiIP"].Value.ToString(), Convert.ToInt32(dgv_MayChamCong.CurrentRow.Cells["Port"].Value.ToString()));
                        thongTinMCC();
                    }
                    else
                    {
                        RJMessageBox.Show("Vui lòng chọn máy chấm công", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
                else
                {
                    RJMessageBox.Show("Vui lòng chọn máy chấm công", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }

                Cursor = Cursors.Default;
                axCZKEM1.Disconnect();
                //}
                //else
                //{
                //    IPHostEntry hostname = Dns.GetHostByName(txtDiaChiWeb.Text);
                //    IPAddress[] ip = hostname.AddressList;
                //    string _IpWeb = ip[0].ToString();
                //    Cursor = Cursors.WaitCursor;
                //    _bIsConnected = axCZKEM1.Connect_Net(_IpWeb, Convert.ToInt32(txtPort.Text));
                //    thongTinMCC();
                //    Cursor = Cursors.Default;
                //    axCZKEM1.Disconnect();
                //}
            }
            //if (comboboxKieuKetNoi.Text == "RS232/484")
            //{
            //}
            //if (comboboxKieuKetNoi.Text == "USB")
            //{
            //    Cursor = Cursors.WaitCursor;
            //    _bIsConnected = axCZKEM1.Connect_USB(iMachineNumber);
            //    thongTinMCC();
            //    Cursor = Cursors.Default;
            //    axCZKEM1.Disconnect();
            //}
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

        private void btnXoaDuLieuChamCong_Click(object sender, EventArgs e)
        {
            if (_bIsConnected)
            {
                capNhatKetNoi();
                if (RJMessageBox.Show("Bạn có đồng ý xóa dữ liệu chấm công không ? ", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1) == DialogResult.Yes && axCZKEM1.ClearGLog(iMachineNumber))
                {
                    axCZKEM1.RefreshData(iMachineNumber);
                    RJMessageBox.Show("Xóa dữ liệu vào ra thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                }
            }
            else
            {
                RJMessageBox.Show("Máy chấm công chưa được kết nối!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
            }
        }

        private void btnKhoiDongLaiMayChamCong_Click(object sender, EventArgs e)
        {
            int idwErrorCode = 0;
            Cursor = Cursors.WaitCursor;
            capNhatKetNoi();
            if (_bIsConnected)
            {
                if (axCZKEM1.RestartDevice(iMachineNumber))
                {
                    RJMessageBox.Show("Máy chấm công đang được khởi động lại", "Thông báo");
                }
                else
                {
                    axCZKEM1.GetLastError(ref idwErrorCode);
                    RJMessageBox.Show("Operation failed,ErrorCode=" + idwErrorCode, "Error");
                }
            }
            else
            {
                RJMessageBox.Show("Máy chấm công chưa được kết nối!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
            }

            Cursor = Cursors.Default;
        }
        private void capNhatKetNoi()
        {
            _bIsConnected = false;
            if (dgv_MayChamCong.CurrentRow.Cells[0].Value != null && dgv_MayChamCong.CurrentRow.Cells[0].Value.ToString() == "True")
            {
                _bIsConnected = axCZKEM1.Connect_Net(dgv_MayChamCong.CurrentRow.Cells["DiaChiIP"].Value.ToString(), Convert.ToInt32(dgv_MayChamCong.CurrentRow.Cells["Port"].Value.ToString()));
            }
        }

        private void btn_delAttLog_Click(object sender, EventArgs e)
        {
            try
            {
                if (DateTime.Parse(stime_log.Text) >= DateTime.Parse(etime_log.Text))
                {
                    RJMessageBox.Show("Xin chọn lại ngày!");
                    return;
                }
                this.capNhatKetNoi();
                if (_bIsConnected)
                {
                    if (RJMessageBox.Show($"Bạn có đồng ý xóa dữ liệu chấm công trên {dgv_MayChamCong.CurrentRow.Cells["TenMCC"].Value} không ? ", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1) == DialogResult.Yes)
                    {
                        string fromTime;
                        fromTime = DateTime.Parse(this.stime_log.Text).ToString("yyyy-MM-dd HH:mm:ss.000").Trim().ToString();
                        string toTime;
                        toTime = DateTime.Parse(this.etime_log.Text).ToString("yyyy-MM-dd HH:mm:ss.000").Trim().ToString();
                        this.axCZKEM1.DeleteAttlogBetweenTheDate(this.iMachineNumber, fromTime, toTime);
                        //this.axCZKEM1.RefreshData(this.iMachineNumber);
                        RJMessageBox.Show("Xóa dữ liệu vào ra thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                    }
                }
                else
                {
                    RJMessageBox.Show("Máy chấm công chưa được kết nối!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                }
            }
            catch (Exception ex)
            {
                RJMessageBox.Show(ex.Message, "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
            }
        }

        private void btn_xoadulieutheothoigian_Click(object sender, EventArgs e)
        {
            this.groupBox5.Visible = true;
            this.groupBox5.Enabled = true;
            this.stime_log.Enabled = true;
            this.etime_log.Enabled = true;
        }
    }
}
