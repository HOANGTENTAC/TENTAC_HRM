using System;
using System.Data;
using System.IO;
using System.Net;
using System.Windows.Forms;
using TENTAC_HRM.BusinessLogicLayer.ChamCongBLL;
using TENTAC_HRM.BusinessLogicLayer.CommonBLL;
using TENTAC_HRM.BusinessLogicLayer.MayChamCong;
using TENTAC_HRM.BusinessLogicLayer.QuanLyNhanVienBLL;
using TENTAC_HRM.Common;
using TENTAC_HRM.DataTransferObject.MayChamCong;
using TENTAC_HRM.DataTransferObject.QuanLyNhanVienDTO;
using TENTAC_HRM.Model;
using zkemkeeper;

namespace TENTAC_HRM.Forms.MayChamCong
{
    public partial class frm_TaiNhanVien : Form
    {
        public CZKEMClass axCZKEM1 = new CZKEMClass();
        public bool _bIsConnected;
        public int _iMachineNumber = 1;
        public int iDemKhuonMat;
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
        private NhanVienBLL _nhanVienBLL = new NhanVienBLL();
        private CommonBLL _commonBLL = new CommonBLL();
        private Common_model _commonDTO = new Common_model();
        private CommonKhuonMatBLL _commonKhuonMatBLL = new CommonKhuonMatBLL();
        private CommonKhuonMat_model _commonKhuonMatDTO = new CommonKhuonMat_model();
        private TemplateCapNhatVanTay_model _templateCapNhatVanTayDTO = new TemplateCapNhatVanTay_model();
        private TemplateCapNhatVanTayBLL _templateCapNhatVanTayBLL = new TemplateCapNhatVanTayBLL();
        private NhanVienDTO _nhanVienDTO = new NhanVienDTO();
        private NhanVienUpdateDTO _nhanVienUpdateDTO = new NhanVienUpdateDTO();
        private NhanVienUpdateBLL _nhanVienUpdateBLL = new NhanVienUpdateBLL();
        private SapXepLichTrinhChoNhanVienBLL _sapXepLichTrinhChoNhanVienBLL = new SapXepLichTrinhChoNhanVienBLL();
        private LichTrinhVaoRaBLL _lichTrinhVaoRaBLL = new LichTrinhVaoRaBLL();
        private LichTrinhChoCaLamViecBLL _lichTrinhChoCaLamViecBLL = new LichTrinhChoCaLamViecBLL();
        private int _kiemTraManHinh;
        private string _loaiManHinh;
        private string sMaNhanVien_NhanVienMoi;
        private string sMaThe_NhanVienMoi;
        private int iSoDuLieu;
        private string sMaNhanVien_CapNhatNhanVien;
        private string sMaThe_CapNhatNhanVien;
        private string _phienBanVanTay = "";
        private TemplateBLL _templateBLL = new TemplateBLL();
        private Template_model _templateDTO = new Template_model();
        private string vtMaNhanVien;
        private string vtMaChamCong;
        private string vtFingerID;
        private string vtFingerTemplate;
        private string vtFingerVersion;
        private int iMachineNumber = 1;
        private int soVanTay;
        private int _value;
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
        private string sdwSerialNumber;
        private string _SDK;
        private string _ketQua;
        private string sTruyenVaoSerial = "";
        private string sKetQuaSerial = "";
        private int a;
        private int b;
        private int c;
        private string _a;
        private string _b;
        private string _c;
        public int[] idPermision { get; set; }
        public frm_TaiNhanVien(int[] permissions = null)
        {
            idPermision = permissions;
            InitializeComponent();
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

        private void duyetNhanVienTuMayChamCong_NhanVienMoi()
        {
            DGVNhanVienDaCoTrenMay.Rows.Clear();
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
                DGVNhanVienMoi.Rows.Clear();
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
                    _nhanVienDTO.MaChamCong = sdwEnrollNumber2;
                    dtDuyetTimNhanVien2 = _nhanVienBLL.NhanVienGetByMaChamCong(sdwEnrollNumber2);
                    if (dtDuyetTimNhanVien2.Rows.Count == 0)
                    {
                        int j = DGVNhanVienMoi.Rows.Add();
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
                        DGVNhanVienMoi.Rows[j].Cells[1].Value = sMaNhanVien_NhanVienMoi;
                        DGVNhanVienMoi.Rows[j].Cells[3].Value = sdwEnrollNumber2;
                        if (sName2 == null || sName2 == "")
                        {
                            DGVNhanVienMoi.Rows[j].Cells[2].Value = sdwEnrollNumber2;
                            DGVNhanVienMoi.Rows[j].Cells[4].Value = sdwEnrollNumber2;
                        }
                        else
                        {
                            DGVNhanVienMoi.Rows[j].Cells[2].Value = sName2;
                            DGVNhanVienMoi.Rows[j].Cells[4].Value = sName2;
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
                        DGVNhanVienMoi.Rows[j].Cells[5].Value = sMaThe_NhanVienMoi;
                        DGVNhanVienMoi.Rows[j].Cells[6].Value = sPassword2;
                        DGVNhanVienMoi.Rows[j].Cells[7].Value = iPrivilege2;
                        DGVNhanVienMoi.Rows[j].Cells[8].Value = bEnabled2;
                        if (checkBoxTaiVanTay.Checked)
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
                        if (checkBoxTaiKhuonMat.Checked && axCZKEM1.GetUserFaceStr(_iMachineNumber, sdwEnrollNumber2, iFaceIndex, ref sTmpData2, ref iLength))
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
                        int idem2 = DGVNhanVienDaCoTrenMay.Rows.Add();
                        for (int itDuyetTimNhanVien2 = 0; itDuyetTimNhanVien2 < dtDuyetTimNhanVien2.Rows.Count; itDuyetTimNhanVien2++)
                        {
                            DGVNhanVienDaCoTrenMay.Rows[idem2].Cells[1].Value = dtDuyetTimNhanVien2.Rows[itDuyetTimNhanVien2]["MaNhanVien"].ToString();
                            DGVNhanVienDaCoTrenMay.Rows[idem2].Cells[2].Value = dtDuyetTimNhanVien2.Rows[itDuyetTimNhanVien2]["TenNhanVien"].ToString();
                            DGVNhanVienDaCoTrenMay.Rows[idem2].Cells[3].Value = dtDuyetTimNhanVien2.Rows[itDuyetTimNhanVien2]["MaChamCong"].ToString();
                            DGVNhanVienDaCoTrenMay.Rows[idem2].Cells[4].Value = dtDuyetTimNhanVien2.Rows[itDuyetTimNhanVien2]["TenChamCong"].ToString();
                            DGVNhanVienDaCoTrenMay.Rows[idem2].Cells[5].Value = dtDuyetTimNhanVien2.Rows[itDuyetTimNhanVien2]["MaThe"].ToString();
                        }
                    }
                }
                axCZKEM1.EnableDevice(_iMachineNumber, bFlag: true);
                return;
            }
            DGVNhanVienMoi.Rows.Clear();
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
                _nhanVienDTO.MaChamCong = idwEnrollNumber.ToString();
                dtDuyetTimNhanVien = _nhanVienBLL.NhanVienGetByMaChamCong(idwEnrollNumber.ToString());
                if (dtDuyetTimNhanVien.Rows.Count == 0)
                {
                    int i = DGVNhanVienMoi.Rows.Add();
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
                    DGVNhanVienMoi.Rows[i].Cells[1].Value = sMaNhanVien_NhanVienMoi;
                    DGVNhanVienMoi.Rows[i].Cells[3].Value = idwEnrollNumber;
                    if (sName == null || sName == "")
                    {
                        DGVNhanVienMoi.Rows[i].Cells[2].Value = idwEnrollNumber;
                        DGVNhanVienMoi.Rows[i].Cells[4].Value = idwEnrollNumber;
                    }
                    else
                    {
                        DGVNhanVienMoi.Rows[i].Cells[2].Value = sName;
                        DGVNhanVienMoi.Rows[i].Cells[4].Value = sName;
                    }
                    axCZKEM1.GetStrCardNumber(out sCardnumber);
                    if (sCardnumber.Length == 0)
                    {
                        DGVNhanVienMoi.Rows[i].Cells[5].Value = "0000000000";
                    }
                    if (sCardnumber.Length == 1)
                    {
                        DGVNhanVienMoi.Rows[i].Cells[5].Value = "000000000" + sCardnumber;
                    }
                    if (sCardnumber.Length == 2)
                    {
                        DGVNhanVienMoi.Rows[i].Cells[5].Value = "00000000" + sCardnumber;
                    }
                    if (sCardnumber.Length == 3)
                    {
                        DGVNhanVienMoi.Rows[i].Cells[5].Value = "0000000" + sCardnumber;
                    }
                    if (sCardnumber.Length == 4)
                    {
                        DGVNhanVienMoi.Rows[i].Cells[5].Value = "000000" + sCardnumber;
                    }
                    if (sCardnumber.Length == 5)
                    {
                        DGVNhanVienMoi.Rows[i].Cells[5].Value = "00000" + sCardnumber;
                    }
                    if (sCardnumber.Length == 6)
                    {
                        DGVNhanVienMoi.Rows[i].Cells[5].Value = "0000" + sCardnumber;
                    }
                    if (sCardnumber.Length == 7)
                    {
                        DGVNhanVienMoi.Rows[i].Cells[5].Value = "000" + sCardnumber;
                    }
                    if (sCardnumber.Length == 8)
                    {
                        DGVNhanVienMoi.Rows[i].Cells[5].Value = "00" + sCardnumber;
                    }
                    if (sCardnumber.Length == 9)
                    {
                        DGVNhanVienMoi.Rows[i].Cells[5].Value = "0" + sCardnumber;
                    }
                    if (sCardnumber.Length == 10)
                    {
                        DGVNhanVienMoi.Rows[i].Cells[5].Value = sCardnumber;
                    }
                    DGVNhanVienMoi.Rows[i].Cells[6].Value = sPassword;
                    DGVNhanVienMoi.Rows[i].Cells[7].Value = iPrivilege;
                    DGVNhanVienMoi.Rows[i].Cells[8].Value = bEnabled;
                    if (checkBoxTaiVanTay.Checked)
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
                    int idem = DGVNhanVienDaCoTrenMay.Rows.Add();
                    for (int itDuyetTimNhanVien = 0; itDuyetTimNhanVien < dtDuyetTimNhanVien.Rows.Count; itDuyetTimNhanVien++)
                    {
                        DGVNhanVienDaCoTrenMay.Rows[idem].Cells[1].Value = dtDuyetTimNhanVien.Rows[itDuyetTimNhanVien]["MaNhanVien"].ToString();
                        DGVNhanVienDaCoTrenMay.Rows[idem].Cells[2].Value = dtDuyetTimNhanVien.Rows[itDuyetTimNhanVien]["TenNhanVien"].ToString();
                        DGVNhanVienDaCoTrenMay.Rows[idem].Cells[3].Value = dtDuyetTimNhanVien.Rows[itDuyetTimNhanVien]["MaChamCong"].ToString();
                        DGVNhanVienDaCoTrenMay.Rows[idem].Cells[4].Value = dtDuyetTimNhanVien.Rows[itDuyetTimNhanVien]["TenChamCong"].ToString();
                        DGVNhanVienDaCoTrenMay.Rows[idem].Cells[5].Value = dtDuyetTimNhanVien.Rows[itDuyetTimNhanVien]["MaThe"].ToString();
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
            DGVNhanVienDaCoTrenMay.Rows.Clear();
            int dem = -1;
            int test = iSoDuLieu;
            if (_loaiManHinh == "0")
            {
                int iFaceIndex = 50;
                int iLength = 0;
                string sTmpData2 = "";
                int iTmpLength2 = 0;
                int iFlag2 = 0;
                DGVNhanVienMoi.Rows.Clear();
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
                        _commonKhuonMatDTO.MaChamCong = Convert.ToInt32(sdwEnrollNumber);
                        dtKhuonMat1 = _commonKhuonMatBLL.SelectTemplateVirtualByMaChamCong(sdwEnrollNumber);
                        if (dtKhuonMat1.Rows.Count == 0)
                        {
                            _commonKhuonMatDTO.MaChamCong = Convert.ToInt32(sdwEnrollNumber);
                            _commonKhuonMatDTO.FaceIDVirtual = iFaceIndex;
                            _commonKhuonMatDTO.FaceTemplateVirtual = sTmpData2;
                            _commonKhuonMatBLL.InsertFaceVirtual(_commonKhuonMatDTO);
                        }
                    }
                    if (axCZKEM1.GetStrCardNumber(out sCardnumber2))
                    {
                        _nhanVienUpdateDTO.MaChamCong = Convert.ToInt32(sdwEnrollNumber);
                        _nhanVienUpdateDTO.MaThe = sCardnumber2;
                        _nhanVienUpdateDTO.UserPassWord = sPassword2;
                        _nhanVienUpdateDTO.PhanQuyen = iPrivilege2;
                        _nhanVienUpdateBLL.NhanVienUpdateInsert(_nhanVienUpdateDTO);
                    }
                    DataTable dtDuyetTimNhanVien2 = new DataTable();
                    _nhanVienDTO.MaChamCong = sdwEnrollNumber;
                    dtDuyetTimNhanVien2 = _nhanVienBLL.NhanVienGetByMaChamCong(sdwEnrollNumber);
                    if (dtDuyetTimNhanVien2.Rows.Count == 0)
                    {
                        int j = DGVNhanVienMoi.Rows.Add();
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
                        DGVNhanVienMoi.Rows[j].Cells[1].Value = sMaNhanVien_CapNhatNhanVien;
                        DGVNhanVienMoi.Rows[j].Cells[3].Value = sdwEnrollNumber;
                        if (sName2 == null || sName2 == "")
                        {
                            DGVNhanVienMoi.Rows[j].Cells[2].Value = sdwEnrollNumber;
                            DGVNhanVienMoi.Rows[j].Cells[4].Value = sdwEnrollNumber;
                        }
                        else
                        {
                            DGVNhanVienMoi.Rows[j].Cells[2].Value = sName2;
                            DGVNhanVienMoi.Rows[j].Cells[4].Value = sName2;
                        }
                        axCZKEM1.GetStrCardNumber(out sCardnumber2);
                        if (sCardnumber2.Length == 0)
                        {
                            DGVNhanVienMoi.Rows[j].Cells[5].Value = "0000000000";
                        }
                        if (sCardnumber2.Length == 1)
                        {
                            DGVNhanVienMoi.Rows[j].Cells[5].Value = "000000000" + sCardnumber2;
                        }
                        if (sCardnumber2.Length == 2)
                        {
                            DGVNhanVienMoi.Rows[j].Cells[5].Value = "00000000" + sCardnumber2;
                        }
                        if (sCardnumber2.Length == 3)
                        {
                            DGVNhanVienMoi.Rows[j].Cells[5].Value = "0000000" + sCardnumber2;
                        }
                        if (sCardnumber2.Length == 4)
                        {
                            DGVNhanVienMoi.Rows[j].Cells[5].Value = "000000" + sCardnumber2;
                        }
                        if (sCardnumber2.Length == 5)
                        {
                            DGVNhanVienMoi.Rows[j].Cells[5].Value = "00000" + sCardnumber2;
                        }
                        if (sCardnumber2.Length == 6)
                        {
                            DGVNhanVienMoi.Rows[j].Cells[5].Value = "0000" + sCardnumber2;
                        }
                        if (sCardnumber2.Length == 7)
                        {
                            DGVNhanVienMoi.Rows[j].Cells[5].Value = "000" + sCardnumber2;
                        }
                        if (sCardnumber2.Length == 8)
                        {
                            DGVNhanVienMoi.Rows[j].Cells[5].Value = "00" + sCardnumber2;
                        }
                        if (sCardnumber2.Length == 9)
                        {
                            DGVNhanVienMoi.Rows[j].Cells[5].Value = "0" + sCardnumber2;
                        }
                        if (sCardnumber2.Length == 10)
                        {
                            DGVNhanVienMoi.Rows[j].Cells[5].Value = sCardnumber2;
                        }
                        DGVNhanVienMoi.Rows[j].Cells[6].Value = sPassword2;
                        DGVNhanVienMoi.Rows[j].Cells[7].Value = iPrivilege2;
                        DGVNhanVienMoi.Rows[j].Cells[8].Value = bEnabled2;
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
                        int idem2 = DGVNhanVienDaCoTrenMay.Rows.Add();
                        for (int itDuyetTimNhanVien2 = 0; itDuyetTimNhanVien2 < dtDuyetTimNhanVien2.Rows.Count; itDuyetTimNhanVien2++)
                        {
                            DGVNhanVienDaCoTrenMay.Rows[idem2].Cells[1].Value = dtDuyetTimNhanVien2.Rows[itDuyetTimNhanVien2]["MaNhanVien"].ToString();
                            DGVNhanVienDaCoTrenMay.Rows[idem2].Cells[2].Value = dtDuyetTimNhanVien2.Rows[itDuyetTimNhanVien2]["TenNhanVien"].ToString();
                            DGVNhanVienDaCoTrenMay.Rows[idem2].Cells[3].Value = dtDuyetTimNhanVien2.Rows[itDuyetTimNhanVien2]["MaChamCong"].ToString();
                            DGVNhanVienDaCoTrenMay.Rows[idem2].Cells[4].Value = dtDuyetTimNhanVien2.Rows[itDuyetTimNhanVien2]["TenChamCong"].ToString();
                            DGVNhanVienDaCoTrenMay.Rows[idem2].Cells[5].Value = dtDuyetTimNhanVien2.Rows[itDuyetTimNhanVien2]["MaThe"].ToString();
                        }
                    }
                }
                listBoxThongTin.Items.Add("Đã cập nhật vân tay xong");
                if (checkBoxTaiKhuonMat.Checked)
                {
                    listBoxThongTin.Items.Add("Đã cập nhật khuôn mặt xong");
                }
                axCZKEM1.EnableDevice(_iMachineNumber, bFlag: true);
                return;
            }
            string sTmpData = "";
            int iTmpLength = 0;
            int iFlag = 0;
            DGVNhanVienMoi.Rows.Clear();
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
                if (axCZKEM1.GetStrCardNumber(out sCardnumber))
                {
                    _nhanVienUpdateDTO.MaChamCong = idwEnrollNumber;
                    _nhanVienUpdateDTO.MaThe = sCardnumber;
                    _nhanVienUpdateDTO.UserPassWord = sPassword;
                    _nhanVienUpdateDTO.PhanQuyen = iPrivilege;
                    _nhanVienUpdateBLL.NhanVienUpdateInsert(_nhanVienUpdateDTO);
                }
                DataTable dtDuyetTimNhanVien = new DataTable();
                _nhanVienDTO.MaChamCong = idwEnrollNumber.ToString();
                dtDuyetTimNhanVien = _nhanVienBLL.NhanVienGetByMaChamCong(idwEnrollNumber.ToString());
                if (dtDuyetTimNhanVien.Rows.Count == 0)
                {
                    int i = DGVNhanVienMoi.Rows.Add();
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
                    DGVNhanVienMoi.Rows[i].Cells[1].Value = sMaNhanVien_CapNhatNhanVien;
                    DGVNhanVienMoi.Rows[i].Cells[3].Value = idwEnrollNumber;
                    if (sName == null || sName == "")
                    {
                        DGVNhanVienMoi.Rows[i].Cells[2].Value = idwEnrollNumber;
                        DGVNhanVienMoi.Rows[i].Cells[4].Value = idwEnrollNumber;
                    }
                    else
                    {
                        DGVNhanVienMoi.Rows[i].Cells[2].Value = sName;
                        DGVNhanVienMoi.Rows[i].Cells[4].Value = sName;
                    }
                    axCZKEM1.GetStrCardNumber(out sCardnumber);
                    if (sCardnumber.Length == 0)
                    {
                        DGVNhanVienMoi.Rows[i].Cells[5].Value = "0000000000";
                    }
                    if (sCardnumber.Length == 1)
                    {
                        DGVNhanVienMoi.Rows[i].Cells[5].Value = "000000000" + sCardnumber;
                    }
                    if (sCardnumber.Length == 2)
                    {
                        DGVNhanVienMoi.Rows[i].Cells[5].Value = "00000000" + sCardnumber;
                    }
                    if (sCardnumber.Length == 3)
                    {
                        DGVNhanVienMoi.Rows[i].Cells[5].Value = "0000000" + sCardnumber;
                    }
                    if (sCardnumber.Length == 4)
                    {
                        DGVNhanVienMoi.Rows[i].Cells[5].Value = "000000" + sCardnumber;
                    }
                    if (sCardnumber.Length == 5)
                    {
                        DGVNhanVienMoi.Rows[i].Cells[5].Value = "00000" + sCardnumber;
                    }
                    if (sCardnumber.Length == 6)
                    {
                        DGVNhanVienMoi.Rows[i].Cells[5].Value = "0000" + sCardnumber;
                    }
                    if (sCardnumber.Length == 7)
                    {
                        DGVNhanVienMoi.Rows[i].Cells[5].Value = "000" + sCardnumber;
                    }
                    if (sCardnumber.Length == 8)
                    {
                        DGVNhanVienMoi.Rows[i].Cells[5].Value = "00" + sCardnumber;
                    }
                    if (sCardnumber.Length == 9)
                    {
                        DGVNhanVienMoi.Rows[i].Cells[5].Value = "0" + sCardnumber;
                    }
                    if (sCardnumber.Length == 10)
                    {
                        DGVNhanVienMoi.Rows[i].Cells[5].Value = sCardnumber;
                    }
                    DGVNhanVienMoi.Rows[i].Cells[6].Value = sPassword;
                    DGVNhanVienMoi.Rows[i].Cells[7].Value = iPrivilege;
                    DGVNhanVienMoi.Rows[i].Cells[8].Value = bEnabled;
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
                    int idem = DGVNhanVienDaCoTrenMay.Rows.Add();
                    for (int itDuyetTimNhanVien = 0; itDuyetTimNhanVien < dtDuyetTimNhanVien.Rows.Count; itDuyetTimNhanVien++)
                    {
                        DGVNhanVienDaCoTrenMay.Rows[idem].Cells[1].Value = dtDuyetTimNhanVien.Rows[itDuyetTimNhanVien]["MaNhanVien"].ToString();
                        DGVNhanVienDaCoTrenMay.Rows[idem].Cells[2].Value = dtDuyetTimNhanVien.Rows[itDuyetTimNhanVien]["TenNhanVien"].ToString();
                        DGVNhanVienDaCoTrenMay.Rows[idem].Cells[3].Value = dtDuyetTimNhanVien.Rows[itDuyetTimNhanVien]["MaChamCong"].ToString();
                        DGVNhanVienDaCoTrenMay.Rows[idem].Cells[4].Value = dtDuyetTimNhanVien.Rows[itDuyetTimNhanVien]["TenChamCong"].ToString();
                        DGVNhanVienDaCoTrenMay.Rows[idem].Cells[5].Value = dtDuyetTimNhanVien.Rows[itDuyetTimNhanVien]["MaThe"].ToString();
                    }
                }
            }
            axCZKEM1.EnableDevice(_iMachineNumber, bFlag: true);
        }

        private void phienBanVanTay()
        {
            axCZKEM1.GetSysOption(1, "~ZKFPVersion", out _phienBanVanTay);
        }

        private void btnTaiVe_Click(object sender, EventArgs e)
        {
            if (radioNhanVienMoi.Checked)
            {
                luuNhanVienMoi();
            }
            if (radioToanBoNhanVien.Checked)
            {
                CapNhatChoNhanVienDaCoTrenPhanMem();
                listBoxThongTin.Items.Add("Đã cập nhật vân tay xong");
                if (checkBoxTaiKhuonMat.Checked)
                {
                    listBoxThongTin.Items.Add("Đã cập nhật khuôn mặt xong");
                }
            }
        }

        private void luuNhanVienMoi()
        {
            int DemNhanVien_LuuVanTay = 0;
            int DemVanTay_LuuVanTay = 0;
            bool KTGT = true;
            for (int row = 0; row < DGVNhanVienMoi.Rows.Count; row++)
            {
                if (!Convert.ToBoolean(DGVNhanVienMoi[0, row].Value))
                {
                    continue;
                }
                row.ToString();
                string sMaNhanVien = DGVNhanVienMoi.Rows[row].Cells[1].Value.ToString();
                string sTenNhanVien = DGVNhanVienMoi.Rows[row].Cells[2].Value.ToString();
                string sMaChamCong = DGVNhanVienMoi.Rows[row].Cells[3].Value.ToString();
                string sTenChamCong = DGVNhanVienMoi.Rows[row].Cells[4].Value.ToString();
                string sMaThe = DGVNhanVienMoi.Rows[row].Cells[5].Value.ToString();
                string sMatKhau = DGVNhanVienMoi.Rows[row].Cells[6].Value.ToString();
                string sPhanQuyen = DGVNhanVienMoi.Rows[row].Cells[7].Value.ToString();
                string sEnable = DGVNhanVienMoi.Rows[row].Cells[8].Value.ToString();
                _nhanVienDTO.MaNhanVien = sMaNhanVien;
                _nhanVienDTO.TenNhanVien = sTenNhanVien;
                _nhanVienDTO.MaChamCong = sMaChamCong;
                _nhanVienDTO.TenChamCong = sTenChamCong;
                if (sMaThe.Length == 0)
                {
                    _nhanVienDTO.MaThe = "0000000000";
                }
                if (sMaThe.Length == 1)
                {
                    _nhanVienDTO.MaThe = "000000000" + sMaThe;
                }
                if (sMaThe.Length == 2)
                {
                    _nhanVienDTO.MaThe = "00000000" + sMaThe;
                }
                if (sMaThe.Length == 3)
                {
                    _nhanVienDTO.MaThe = "0000000" + sMaThe;
                }
                if (sMaThe.Length == 4)
                {
                    _nhanVienDTO.MaThe = "000000" + sMaThe;
                }
                if (sMaThe.Length == 5)
                {
                    _nhanVienDTO.MaThe = "00000" + sMaThe;
                }
                if (sMaThe.Length == 6)
                {
                    _nhanVienDTO.MaThe = "0000" + sMaThe;
                }
                if (sMaThe.Length == 7)
                {
                    _nhanVienDTO.MaThe = "000" + sMaThe;
                }
                if (sMaThe.Length == 8)
                {
                    _nhanVienDTO.MaThe = "00" + sMaThe;
                }
                if (sMaThe.Length == 9)
                {
                    _nhanVienDTO.MaThe = "0" + sMaThe;
                }
                if (sMaThe.Length == 10)
                {
                    _nhanVienDTO.MaThe = sMaThe;
                }
                _nhanVienDTO.UserPassWord = sMatKhau;
                _nhanVienDTO.PhanQuyen = Convert.ToInt32(sPhanQuyen);
                _nhanVienDTO.UserEnable = sEnable;
                _nhanVienDTO.GioiTinh = Convert.ToBoolean(KTGT);
                _nhanVienDTO.NgayVaoLamViec = DateTime.Now;
                _nhanVienDTO.ChucVu = "";
                _nhanVienDTO.NgaySinh = DateTime.Now;
                _nhanVienDTO.NoiSinh = "";
                _nhanVienDTO.ThoiHanHopDong = 0f;
                _nhanVienDTO.LoaiNhanVien = "";
                _nhanVienDTO.CMND = 0;
                _nhanVienDTO.DienThoaiLienHe = "";
                _nhanVienDTO.Email = "";
                _nhanVienDTO.NgayPhep = 12f;
                _nhanVienDTO.TienLuong = "";
                _nhanVienDTO.LuongHopDong = "";
                _nhanVienDTO.DanToc = "";
                _nhanVienDTO.QuocTich = "";
                _nhanVienDTO.Skype = "";
                _nhanVienDTO.Yahoo = "";
                _nhanVienDTO.Facebook = "";
                _nhanVienDTO.PassWord = "";
                _nhanVienDTO.NhanVienMoi = true;
                _nhanVienBLL.InsertNhanVienFromDevice(_nhanVienDTO);
                string sMaLichTrinhVaoRa = "";
                DataTable dtLichTrinhVaoRa = new DataTable();
                dtLichTrinhVaoRa = _lichTrinhVaoRaBLL.GETDANHSACH_LICHTRINHVAORA();
                if (dtLichTrinhVaoRa.Rows.Count != 0)
                {
                    sMaLichTrinhVaoRa = dtLichTrinhVaoRa.Rows[0]["MaLichTrinhVaoRa"].ToString();
                }
                string sMaLichTrinhCaLamViec = "";
                DataTable dtLichTrinhCaLamViec = new DataTable();
                dtLichTrinhCaLamViec = _lichTrinhChoCaLamViecBLL.GET_DANHSACH_LICHTRINHCHOCALAMVIEC();
                if (dtLichTrinhCaLamViec.Rows.Count != 0)
                {
                    sMaLichTrinhCaLamViec = dtLichTrinhCaLamViec.Rows[0]["MaLichTrinhCaLamViec"].ToString();
                }
                //if (sMaLichTrinhVaoRa != "" && sMaLichTrinhCaLamViec != "")
                //{
                //    _sapXepLichTrinhChoNhanVienDTO.MaChamCong = Convert.ToInt32(DGVNhanVienMoi.Rows[row].Cells[3].Value.ToString());
                //    _sapXepLichTrinhChoNhanVienDTO.MaLichTrinhVaoRa = "LTVR00001";
                //    _sapXepLichTrinhChoNhanVienDTO.MaLichTrinhCaLamViec = "LTCLV00001";
                //    _sapXepLichTrinhChoNhanVienBLL.Insert_SapXepLichTrinhChoNhanVien(_sapXepLichTrinhChoNhanVienDTO);
                //}
                if (checkBoxTaiVanTay.Checked)
                {
                    DataTable selectVT = new DataTable();
                    _commonDTO.MaChamCong = Convert.ToInt32(sMaChamCong);
                    selectVT = _commonBLL.SelectTemplateVirtualByMaChamCong(Convert.ToInt32(sMaChamCong));
                    for (int selectLuuVT = 0; selectLuuVT < selectVT.Rows.Count; selectLuuVT++)
                    {
                        _templateDTO.MaChamCong = Convert.ToInt32(selectVT.Rows[selectLuuVT]["MaChamCong"].ToString());
                        _templateDTO.FingerID = Convert.ToInt32(selectVT.Rows[selectLuuVT]["FingerIDVirtual"].ToString());
                        _templateDTO.Flag = Convert.ToInt32(selectVT.Rows[selectLuuVT]["FlagVirtual"].ToString());
                        _templateDTO.FingerTemplate = selectVT.Rows[selectLuuVT]["FingerTemplateVirtual"].ToString();
                        _templateDTO.FingerVersion = selectVT.Rows[selectLuuVT]["FingerVersionVirtual"].ToString();
                        _templateBLL.ThemTemplate(_templateDTO);
                        DemVanTay_LuuVanTay++;
                    }
                }
                DemNhanVien_LuuVanTay++;
                btnTaiVe.Text = "Tải về: " + DemNhanVien_LuuVanTay;
                Application.DoEvents();
            }
            if (checkBoxTaiKhuonMat.Checked)
            {
                listBoxThongTin.Items.Add("Số khuôn mặt vừa tải: " + iDemKhuonMat);
            }
            listBoxThongTin.Items.Add("Số nhân viên vừa tải: " + DemNhanVien_LuuVanTay);
            listBoxThongTin.Items.Add("Số vân tay: " + DemVanTay_LuuVanTay);
            _commonBLL.DeleteALLTemplateVirtual();
        }

        private void CapNhatChoNhanVienDaCoTrenPhanMem()
        {
            for (int row = 0; row < DGVNhanVienDaCoTrenMay.Rows.Count; row++)
            {
                if (Convert.ToBoolean(DGVNhanVienDaCoTrenMay[0, row].Value))
                {
                    int iMaChamCongCapNhatVanTay = Convert.ToInt32(DGVNhanVienDaCoTrenMay.Rows[row].Cells[3].Value.ToString());
                    DataTable dtCapNhatVanTayChoNhanVien = new DataTable();
                    _templateCapNhatVanTayDTO.MaChamCong = iMaChamCongCapNhatVanTay;
                    dtCapNhatVanTayChoNhanVien = _templateCapNhatVanTayBLL.TemplateCapNhatVanTayGetByMaChamCong(iMaChamCongCapNhatVanTay);
                    for (int iCapNhatVanTayChoNhanVien = 0; iCapNhatVanTayChoNhanVien < dtCapNhatVanTayChoNhanVien.Rows.Count; iCapNhatVanTayChoNhanVien++)
                    {
                        _templateDTO.MaChamCong = Convert.ToInt32(dtCapNhatVanTayChoNhanVien.Rows[iCapNhatVanTayChoNhanVien]["MaChamCong"].ToString());
                        _templateDTO.FingerID = Convert.ToInt32(dtCapNhatVanTayChoNhanVien.Rows[iCapNhatVanTayChoNhanVien]["FingerIDCapNhatVanTay"].ToString());
                        _templateDTO.Flag = Convert.ToInt32(dtCapNhatVanTayChoNhanVien.Rows[iCapNhatVanTayChoNhanVien]["FlagCapNhatVanTay"].ToString());
                        _templateDTO.FingerTemplate = dtCapNhatVanTayChoNhanVien.Rows[iCapNhatVanTayChoNhanVien]["FingerTemplateCapNhatVanTay"].ToString();
                        _templateDTO.FingerVersion = dtCapNhatVanTayChoNhanVien.Rows[iCapNhatVanTayChoNhanVien]["FingerVersionCapNhatVanTay"].ToString();
                        _templateBLL.ThemTemplate(_templateDTO);
                    }
                    DataTable dtCaphatThongTinChoNhanVien = new DataTable();
                    _nhanVienUpdateDTO.MaChamCong = iMaChamCongCapNhatVanTay;
                    dtCaphatThongTinChoNhanVien = _nhanVienUpdateBLL.NhanVienUpdateGetByMaChamCong(_nhanVienUpdateDTO);
                    for (int iCapNhatThongTinChoNhanVien = 0; iCapNhatThongTinChoNhanVien < dtCaphatThongTinChoNhanVien.Rows.Count; iCapNhatThongTinChoNhanVien++)
                    {
                        _nhanVienDTO.MaChamCong = dtCaphatThongTinChoNhanVien.Rows[iCapNhatThongTinChoNhanVien]["MaChamCong"].ToString();
                        _nhanVienDTO.MaThe = dtCaphatThongTinChoNhanVien.Rows[iCapNhatThongTinChoNhanVien]["MaThe"].ToString();
                        _nhanVienDTO.UserPassWord = dtCaphatThongTinChoNhanVien.Rows[iCapNhatThongTinChoNhanVien]["UserPassWord"].ToString();
                        _nhanVienDTO.PhanQuyen = Convert.ToInt32(dtCaphatThongTinChoNhanVien.Rows[iCapNhatThongTinChoNhanVien]["PhanQuyen"].ToString());
                        _nhanVienBLL.NhanVienUpdateToanBoNhanVien(_nhanVienDTO);
                    }
                }
            }
        }

        private void frmTaiNhanVien_Load(object sender, EventArgs e)
        {
            radioNhanVienMoi.Checked = true;
            DGVNhanVienDaCoTrenMay.Columns.Insert(0, new DataGridViewCheckBoxColumn());
            DGVNhanVienMoi.Columns.Insert(0, new DataGridViewCheckBoxColumn());
            DGVNhanVienMoi.Columns[0].Width = 30;
            DGVNhanVienDaCoTrenMay.Columns[0].Width = 30;
            radioXoaNhanVien.Checked = true;
            checkBoxTaiVanTay.Checked = true;
            DataTable dtLoadMayChamCong = new DataTable();
            dtLoadMayChamCong = _mayChamCongBLL.GETDANHSACHMCC();
            comboBoxChonMayChamCong.DataSource = _mayChamCongBLL.GETDANHSACHMCC();
            if (dtLoadMayChamCong.Rows.Count > 0)
            {
                comboBoxChonMayChamCong.DisplayMember = "TenMCC";
                comboBoxChonMayChamCong.ValueMember = "MaMCC";
            }
        }

        private void demNhanVien()
        {
            int iNhanVienDaCoTrenMayTinh = 0;
            int iNhanVienMoiChuaCoTrenMayTinh = 0;
            for (int dem = 1; dem <= DGVNhanVienDaCoTrenMay.Rows.Count; dem++)
            {
                iNhanVienDaCoTrenMayTinh++;
            }
            expandablePanel1.TitleText = "Nhân viên đã có trên máy tính: " + iNhanVienDaCoTrenMayTinh + " nhân viên";
            for (int dem2 = 1; dem2 <= DGVNhanVienMoi.Rows.Count; dem2++)
            {
                iNhanVienMoiChuaCoTrenMayTinh++;
            }
            expandablePanel2.TitleText = "Nhân viên mới: " + iNhanVienMoiChuaCoTrenMayTinh + " nhân viên";
        }

        private void btnDuyetTuMayChamCongNew_Click(object sender, EventArgs e)
        {
            sdwSerialNumber = "";
            _commonBLL.DeleteALLTemplateVirtual();
            _templateCapNhatVanTayBLL.TemplateCapNhatVanTayDeleteAll();
            _nhanVienUpdateBLL.NhanVienUpdateDeleteAll(_nhanVienUpdateDTO);
            if (comboBoxChonMayChamCong.SelectedIndex == -1)
            {
                MessageBox.Show("Bạn chưa chọn máy chấm công", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Hand);
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
                        MessageBox.Show("Không kết nối được với " + sTenMay);
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
                        MessageBox.Show("Máy chấm công này chưa được đăng ký, xin vui lòng liên hệ với nhà cung cấp", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Hand);
                        axCZKEM1.Disconnect();
                        Cursor = Cursors.Default;
                        Close();
                        frm_DangKyMayChamCong _dangKyMayChamCong3 = new frm_DangKyMayChamCong();
                        _dangKyMayChamCong3.ShowDialog();
                        return;
                    }
                    if (sSoDangKy.Trim() != _ketQua.ToString())
                    {
                        MessageBox.Show("Máy chấm công này chưa được đăng ký, xin vui lòng liên hệ với nhà cung cấp", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Hand);
                        axCZKEM1.Disconnect();
                        Cursor = Cursors.Default;
                        Close();
                        frm_DangKyMayChamCong _dangKyMayChamCong4 = new frm_DangKyMayChamCong();
                        _dangKyMayChamCong4.ShowDialog();
                        return;
                    }
                    if (axCZKEM1.GetDeviceStatus(1, 2, ref _value))
                    {
                        iSoDuLieu = _value;
                    }
                    kiemTraLoaiMay();
                    phienBanVanTay();
                    if (radioNhanVienMoi.Checked)
                    {
                        duyetNhanVienTuMayChamCong_NhanVienMoi();
                    }
                    if (radioToanBoNhanVien.Checked)
                    {
                        duyetNhanVienTuMayChamCong_ToanBoNhanVien();
                    }
                    btnChonTatCa2_Click(sender, e);
                    axCZKEM1.Disconnect();
                    Cursor = Cursors.Default;
                    if (sTrangThai == "False")
                    {
                        MessageBox.Show("Máy chấm công này chưa cho phép sử dụng");
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
                        MessageBox.Show("Máy chấm công này chưa được đăng ký, xin vui lòng liên hệ với nhà cung cấp", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Hand);
                        axCZKEM1.Disconnect();
                        Cursor = Cursors.Default;
                        Close();
                        frm_DangKyMayChamCong _dangKyMayChamCong = new frm_DangKyMayChamCong();
                        _dangKyMayChamCong.ShowDialog();
                        return;
                    }
                    if (sSoDangKy.Trim() != _ketQua.ToString())
                    {
                        MessageBox.Show("Máy chấm công này chưa được đăng ký, xin vui lòng liên hệ với nhà cung cấp", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Hand);
                        axCZKEM1.Disconnect();
                        Cursor = Cursors.Default;
                        Close();
                        frm_DangKyMayChamCong _dangKyMayChamCong2 = new frm_DangKyMayChamCong();
                        _dangKyMayChamCong2.ShowDialog();
                        return;
                    }
                    if (axCZKEM1.GetDeviceStatus(1, 2, ref _value))
                    {
                        iSoDuLieu = _value;
                    }
                    kiemTraLoaiMay();
                    phienBanVanTay();
                    if (radioNhanVienMoi.Checked)
                    {
                        duyetNhanVienTuMayChamCong_NhanVienMoi();
                    }
                    if (radioToanBoNhanVien.Checked)
                    {
                        duyetNhanVienTuMayChamCong_ToanBoNhanVien();
                    }
                    btnChonTatCa2_Click(sender, e);
                    axCZKEM1.Disconnect();
                    Cursor = Cursors.Default;
                    if (sTrangThai == "False")
                    {
                        MessageBox.Show("Máy chấm công này chưa cho phép sử dụng");
                        Cursor = Cursors.Default;
                        axCZKEM1.Disconnect();
                        return;
                    }
                    if (!_bIsConnected)
                    {
                        MessageBox.Show("Không kết nối được với " + sTenMay);
                        Cursor = Cursors.Default;
                        return;
                    }
                }
            }
            if (sKieuKetNoi == "RS232/484")
            {
                MessageBox.Show("Chưa phát triển cổng COM");
            }
            if (sKieuKetNoi == "USB")
            {
                _iMachineNumber = 1;
                Cursor = Cursors.WaitCursor;
                _bIsConnected = axCZKEM1.Connect_USB(_iMachineNumber);
                if (!_bIsConnected)
                {
                    MessageBox.Show("Không kết nối được với " + sTenMay);
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
                if (checkBoxTaiVanTay.Checked)
                {
                    duyetNhanVienTuMayChamCong_NhanVienMoi();
                }
                else
                {
                    duyetNhanVienTuMayChamCong_ToanBoNhanVien();
                }
                btnChonTatCa2_Click(sender, e);
                axCZKEM1.Disconnect();
                Cursor = Cursors.Default;
            }
            demNhanVien();
        }

        private void ActiveKey()
        {
            int iChieuDaiChuoi = sSerial.Trim().Length;
            for (int iLayChuoi = 0; iLayChuoi < iChieuDaiChuoi; iLayChuoi++)
            {
                sTruyenVaoSerial = sSerial.Substring(iLayChuoi, 1);
                if (sTruyenVaoSerial == "0" || sTruyenVaoSerial == "1" || sTruyenVaoSerial == "2" || sTruyenVaoSerial == "3" || sTruyenVaoSerial == "4" || sTruyenVaoSerial == "5" || sTruyenVaoSerial == "6" || sTruyenVaoSerial == "7" || sTruyenVaoSerial == "8" || sTruyenVaoSerial == "9")
                {
                    sKetQuaSerial += sTruyenVaoSerial;
                }
            }
            try
            {
                _a = sSerial.Substring(0, 2);
                if (_a == "OV" || _a == "OG" || _a == "AF" || _a == "A8" || _a == "A2" || _a == "TA" || _a == "A0")
                {
                    _a = "94";
                }
                int i = sSerial.Length - 4;
                _b = sSerial.Substring(i);
                int j = sSerial.Length - 2;
                _c = sSerial.Substring(j);
                try
                {
                    a = Convert.ToInt32(_a);
                }
                catch
                {
                    a = 90;
                }
                b = Convert.ToInt32(_b);
                c = Convert.ToInt32(_c);
            }
            catch
            {
            }
            double dSDK = (double)((a + b + c) * 2 - c) / 1.5;
            _SDK = ((Convert.ToInt32(dSDK) + 19 + 11) * 1994).ToString();
            int abc = Convert.ToInt32(_SDK);
            if (abc < 0)
            {
                abc -= abc * 2;
            }
            int iTongSo = 0;
            try
            {
                Convert.ToInt32(sSerial.Substring(5, 2));
                int iSo1 = Convert.ToInt32(sSerial.Substring(5, 1));
                int iSo2 = Convert.ToInt32(sSerial.Substring(6, 1));
                iTongSo = iSo1 + iSo2;
            }
            catch
            {
            }
            if (iTongSo > 7)
            {
                string txtabc = "MT" + abc;
                _ketQua = txtabc.ToString();
            }
            else
            {
                _ketQua = abc.ToString();
            }
        }

        private void btnChonTatCa1_Click(object sender, EventArgs e)
        {
            bool _selectAll = false;
            _selectAll = !_selectAll;
            if (_selectAll)
            {
                for (int i = 0; i < DGVNhanVienDaCoTrenMay.Rows.Count; i++)
                {
                    DGVNhanVienDaCoTrenMay.Rows[i].Cells[0].Value = _selectAll;
                }
            }
        }

        private void btnBoChonTatCa1_Click(object sender, EventArgs e)
        {
            bool _selectAll = true;
            _selectAll = !_selectAll;
            if (!_selectAll)
            {
                for (int i = 0; i < DGVNhanVienDaCoTrenMay.Rows.Count; i++)
                {
                    DGVNhanVienDaCoTrenMay.Rows[i].Cells[0].Value = _selectAll;
                }
            }
        }

        private void btnChonTatCa2_Click(object sender, EventArgs e)
        {
            bool _selectAllNhanVienMoi = false;
            _selectAllNhanVienMoi = !_selectAllNhanVienMoi;
            if (_selectAllNhanVienMoi)
            {
                for (int iNhanVienMoi = 0; iNhanVienMoi < DGVNhanVienMoi.Rows.Count; iNhanVienMoi++)
                {
                    DGVNhanVienMoi.Rows[iNhanVienMoi].Cells[0].Value = _selectAllNhanVienMoi;
                }
            }
        }

        private void btnBoChon2_Click(object sender, EventArgs e)
        {
            bool _selectAllNhanVienMoi = true;
            _selectAllNhanVienMoi = !_selectAllNhanVienMoi;
            if (!_selectAllNhanVienMoi)
            {
                for (int iNhanVienMoi = 0; iNhanVienMoi < DGVNhanVienMoi.Rows.Count; iNhanVienMoi++)
                {
                    DGVNhanVienMoi.Rows[iNhanVienMoi].Cells[0].Value = _selectAllNhanVienMoi;
                }
            }
        }

        private void btnXoaNhanVienTrenMay_Click(object sender, EventArgs e)
        {
            if (sKieuKetNoi == "TCP/IP" && sSuDungWeb == "False")
            {
                Cursor = Cursors.WaitCursor;
                _bIsConnected = axCZKEM1.Connect_Net(sDiaChiIP, Convert.ToInt32(sPort));
                if (!_bIsConnected)
                {
                    MessageBox.Show("Không kết nối được với " + sTenMay);
                    Cursor = Cursors.Default;
                }
                else if (sTrangThai == "False")
                {
                    MessageBox.Show("Máy chấm công này chưa cho phép sử dụng");
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
            _ = radioXoaVanTay.Checked;
            _ = radioXoaKhuonMat.Checked;
            _ = radioXoaMatMa.Checked;
            if (!radioXoaNhanVien.Checked)
            {
                return;
            }
            if (!_bIsConnected)
            {
                MessageBox.Show("Please connect the device first!", "Error");
                return;
            }
            for (int _xoaNhanVien = 0; _xoaNhanVien < DGVNhanVienDaCoTrenMay.Rows.Count; _xoaNhanVien++)
            {
                if (Convert.ToBoolean(DGVNhanVienDaCoTrenMay[0, _xoaNhanVien].Value))
                {
                    string sMaChamCongXoaNhanVien = DGVNhanVienDaCoTrenMay.Rows[_xoaNhanVien].Cells[3].Value.ToString();
                    string sUserID = sMaChamCongXoaNhanVien;
                    int iBackupNumber = 0;
                    Cursor = Cursors.WaitCursor;
                    if (axCZKEM1.SSR_DeleteEnrollData(_iMachineNumber, sUserID, iBackupNumber))
                    {
                        axCZKEM1.RefreshData(_iMachineNumber);
                        MessageBox.Show("DeleteEnrollData,UserID=" + sUserID + " BackupNumber=" + iBackupNumber, "Success");
                    }
                    else
                    {
                        axCZKEM1.GetLastError(ref idwErrorCode);
                    }
                    Cursor = Cursors.Default;
                }
            }
            MessageBox.Show("Xóa thành công");
        }

        private void comboBoxChonMayChamCong_SelectedIndexChanged(object sender, EventArgs e)
        {
            expandablePanel1.TitleText = "Nhân viên đã tải về từ " + comboBoxChonMayChamCong.Text;
            DataTable dtChonMayChamCong = new DataTable();
            _mayChamCongDTO.TenMCC = comboBoxChonMayChamCong.Text;
            dtChonMayChamCong = _mayChamCongBLL.MayChamCongGetAllByTenMCC(_mayChamCongDTO);
            for (int iChonMayChamCong = 0; iChonMayChamCong < dtChonMayChamCong.Rows.Count; iChonMayChamCong++)
            {
                sTenMay = comboBoxChonMayChamCong.Text;
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

        private void btnChonDuongDan_Click(object sender, EventArgs e)
        {
            OpenFileDialog _open = new OpenFileDialog();
            _open.Filter = "All files (*.*)|*.*";
            _open.Title = "Open file [MITACO]";
            _open.ShowDialog();
            string sDuongDan = Path.GetPathRoot(_open.FileName);
            txtDuongDanAnh.Text = sDuongDan;
        }
        private void frm_TaiNhanVien_Load(object sender, EventArgs e)
        {
            radioNhanVienMoi.Checked = true;
            DGVNhanVienDaCoTrenMay.Columns.Insert(0, new DataGridViewCheckBoxColumn());
            DGVNhanVienMoi.Columns.Insert(0, new DataGridViewCheckBoxColumn());
            DGVNhanVienMoi.Columns[0].Width = 30;
            DGVNhanVienDaCoTrenMay.Columns[0].Width = 30;
            radioXoaNhanVien.Checked = true;
            checkBoxTaiVanTay.Checked = true;
            DataTable dtLoadMayChamCong = new DataTable();
            dtLoadMayChamCong = _mayChamCongBLL.GETDANHSACHMCC();
            comboBoxChonMayChamCong.DataSource = _mayChamCongBLL.GETDANHSACHMCC();
            if (dtLoadMayChamCong.Rows.Count > 0)
            {
                comboBoxChonMayChamCong.DisplayMember = "TenMCC";
                comboBoxChonMayChamCong.ValueMember = "MaMCC";
            }
        }
    }
}
