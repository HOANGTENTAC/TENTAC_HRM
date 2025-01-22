using System;
using System.Data;
using System.Windows.Forms;
using TENTAC_HRM.BLL.BLL.ChamCongBLL;
using TENTAC_HRM.Common;
using TENTAC_HRM.Custom;
using TENTAC_HRM.Models.ChamCongModel;

namespace TENTAC_HRM.Forms.ChamCong
{
    public partial class uc_CaLamViec : UserControl
    {
        private MaTuDong _maTuDong = new MaTuDong();

        private string sMaCaLamViec;

        private string sTongGioNghiTrua;

        private string sTongGioTrongCaLamViec;

        private CaLamViecBLL _caLamViecBLL = new CaLamViecBLL();

        private CaLamViecModel _caLamViecDTO = new CaLamViecModel();

        private int kiemtra;

        private string sXemCaDem;

        private string sTinhBuTru;

        private string sTruGioDiTre;

        private string sTruGioVeSom;

        private string sBatDauTinhDiTre;

        private string sBatDauTinhVeSom;

        private string sXemCaNayLaTangCa;

        private string sXemCuoiTuanLaTangCa;

        private string sXemNgayLeLaTangCa;

        private string sTangCaTruocGioLamViec;

        private string sTangCaSauGioLamViec;

        private string sTongGioLamDatDen;

        private float fTongGioLamViec;
        public uc_CaLamViec()
        {
            InitializeComponent();
        }

        private void uc_CaLamViec_Load(object sender, EventArgs e)
        {
            this.loadDataGirdView();
        }
        private void loadDataGirdView()
        {
            new DataTable();
            DataTable dt;
            dt = this._caLamViecBLL.getCaLamViec();
            for (int _i = 0; _i < dt.Rows.Count; _i++)
            {
                int i;
                i = this.DGVCaLamViec.Rows.Add();
                this.DGVCaLamViec.Rows[i].Cells[0].Value = dt.Rows[_i]["MaCaLamViec"].ToString();
                this.DGVCaLamViec.Rows[i].Cells[1].Value = dt.Rows[_i]["CaLamViec"].ToString();
                DateTime _gioVao;
                _gioVao = Convert.ToDateTime(dt.Rows[_i]["GioVaoLamViec"].ToString());
                this.DGVCaLamViec.Rows[i].Cells[2].Value = $"{_gioVao: HH:mm}";
                DateTime _gioRa;
                _gioRa = Convert.ToDateTime(dt.Rows[_i]["GioKetThucLamViec"].ToString());
                this.DGVCaLamViec.Rows[i].Cells[3].Value = $"{_gioRa: HH:mm}";
            }
        }
        private void loadControlDatetime()
        {
            DateTime dtTime;
            dtTime = default(DateTime);
            this.dateTimeGioVaoLamViec.Text = $"{dtTime: HH:mm}";
            this.dateTimeGioKetThucLamViec.Text = $"{dtTime: HH:mm}";
            this.dateTimeGioBatDauNghiTrua.Text = $"{dtTime: HH:mm}";
            this.dateTimeGioKetThucNghiTrua.Text = $"{dtTime: HH:mm}";
            this.dateTimeBatDauVao.Text = $"{dtTime: HH:mm}";
            this.dateTimeKetThucVao.Text = $"{dtTime: HH:mm}";
            this.dateTimeBatDauRa.Text = $"{dtTime: HH:mm}";
            this.dateTimeKetThucRa.Text = $"{dtTime: HH:mm}";
        }
        private void DGVCaLamViec_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            this.kiemtra = 0;
            this.sMaCaLamViec = this.DGVCaLamViec.CurrentRow.Cells[0].Value.ToString();
            new DataTable();
            DataTable dtCaLamViec;
            dtCaLamViec = this._caLamViecBLL.CaLamViecGetByMaCaLamViec(sMaCaLamViec);
            for (int i = 0; i < dtCaLamViec.Rows.Count; i++)
            {
                txt_MaCa.Text = dtCaLamViec.Rows[i]["MaCaLamViec"].ToString();
                this.txtCaLamViec.Text = dtCaLamViec.Rows[i]["CaLamViec"].ToString();
                this.dateTimeGioVaoLamViec.Text = dtCaLamViec.Rows[i]["GioVaoLamViec"].ToString();
                this.dateTimeGioKetThucLamViec.Text = dtCaLamViec.Rows[i]["GioKetThucLamViec"].ToString();
                this.dateTimeGioBatDauNghiTrua.Text = dtCaLamViec.Rows[i]["GioBatDauNghiTrua"].ToString();
                this.dateTimeGioKetThucNghiTrua.Text = dtCaLamViec.Rows[i]["GioKetThucNghiTrua"].ToString();
                this.txtTongGioNghiTrua.Text = dtCaLamViec.Rows[i]["TongGioNghiTrua"].ToString();
                this.txtTongGioTrongCaLamViec.Text = dtCaLamViec.Rows[i]["TongGioTrongCaLamViec"].ToString();
                this.txtCongTinh.Text = dtCaLamViec.Rows[i]["CongTinh"].ToString();
                this.dateTimeBatDauVao.Text = dtCaLamViec.Rows[i]["BatDauVao"].ToString();
                this.dateTimeKetThucVao.Text = dtCaLamViec.Rows[i]["KetThucVao"].ToString();
                this.dateTimeBatDauRa.Text = dtCaLamViec.Rows[i]["BatDauRa"].ToString();
                this.dateTimeKetThucRa.Text = dtCaLamViec.Rows[i]["KetThucRa"].ToString();
                this.txtKhongCoGioRa.Text = dtCaLamViec.Rows[i]["KhongCoGioRa"].ToString();
                this.txtKhongCoGioVao.Text = dtCaLamViec.Rows[i]["KhongCoGioVao"].ToString();
                this.sXemCaDem = dtCaLamViec.Rows[i]["XemCaDem"].ToString();
                if (this.sXemCaDem == "True")
                {
                    this.checkBoxXemCaDem.Checked = true;
                }
                else
                {
                    this.checkBoxXemCaDem.Checked = false;
                }
                this.sTinhBuTru = dtCaLamViec.Rows[i]["TinhBuTru"].ToString();
                if (this.sTinhBuTru == "True")
                {
                    this.checkBoxTinhBuTru.Checked = true;
                }
                else
                {
                    this.checkBoxTinhBuTru.Checked = false;
                }
                this.sTruGioDiTre = dtCaLamViec.Rows[i]["TruGioDiTre"].ToString();
                if (this.sTruGioDiTre == "True")
                {
                    this.checkBoxTruGioDiTre.Checked = true;
                }
                else
                {
                    this.checkBoxTruGioDiTre.Checked = false;
                }
                this.sTruGioVeSom = dtCaLamViec.Rows[i]["TruGioVeSom"].ToString();
                if (this.sTruGioVeSom == "True")
                {
                    this.checkBoxTruGioVeSom.Checked = true;
                }
                else
                {
                    this.checkBoxTruGioVeSom.Checked = false;
                }
                this.txtChoPhepDiTre.Text = dtCaLamViec.Rows[i]["ChoPhepDiTre"].ToString();
                this.sBatDauTinhDiTre = dtCaLamViec.Rows[i]["BatDauTinhDiTre"].ToString();
                if (this.sBatDauTinhDiTre == "True")
                {
                    this.checkBoxBatDauTinhDiTre.Checked = true;
                }
                else
                {
                    this.checkBoxBatDauTinhDiTre.Checked = false;
                }
                this.txtChoPhepVeSom.Text = dtCaLamViec.Rows[i]["ChoPhepVeSom"].ToString();
                this.sBatDauTinhVeSom = dtCaLamViec.Rows[i]["BatDauTinhVeSom"].ToString();
                if (this.sBatDauTinhVeSom == "True")
                {
                    this.checkBoxBatDauTinhVeSom.Checked = true;
                }
                else
                {
                    this.checkBoxBatDauTinhVeSom.Checked = false;
                }
                this.sXemCaNayLaTangCa = dtCaLamViec.Rows[i]["XemCaNayLaTangCa"].ToString();
                if (this.sXemCaNayLaTangCa == "True")
                {
                    this.checkBoxXemCaNayLaTangCa.Checked = true;
                }
                else
                {
                    this.checkBoxXemCaNayLaTangCa.Checked = false;
                }
                this.comboBoxTangCaHeSo.Text = dtCaLamViec.Rows[i]["TangCaMuc"].ToString();
                this.sXemCuoiTuanLaTangCa = dtCaLamViec.Rows[i]["XemCuoiTuanLaTangCa"].ToString();
                if (this.sXemCuoiTuanLaTangCa == "True")
                {
                    this.checkBoxXemCuoiTuanLaTangCa.Checked = true;
                }
                else
                {
                    this.checkBoxXemCuoiTuanLaTangCa.Checked = false;
                }
                this.comboBoxHeSoTangCaCuoiTuan.Text = dtCaLamViec.Rows[i]["TangCaCuoiTuanMuc"].ToString();
                this.sXemNgayLeLaTangCa = dtCaLamViec.Rows[i]["XemNgayLeLaTangCa"].ToString();
                if (this.sXemNgayLeLaTangCa == "True")
                {
                    this.checkBoxXemNgayLeLaTangCa.Checked = true;
                }
                else
                {
                    this.checkBoxXemNgayLeLaTangCa.Checked = false;
                }
                this.comboBoxHeSoTangCaNgayLe.Text = dtCaLamViec.Rows[i]["TangCaNgayLeMuc"].ToString();
                this.sTangCaTruocGioLamViec = dtCaLamViec.Rows[i]["TangCaTruocGioLamViec"].ToString();
                if (this.sTangCaTruocGioLamViec == "True")
                {
                    this.checkBoxTangCaTruocGioLamViec.Checked = true;
                }
                else
                {
                    this.checkBoxTangCaTruocGioLamViec.Checked = false;
                }
                this.txtPhutTangCaTruocGioLamViec.Text = dtCaLamViec.Rows[i]["SoPhutTangCaTruocGioLamViec"].ToString();
                this.sTangCaSauGioLamViec = dtCaLamViec.Rows[i]["TangCaSauGioLamViec"].ToString();
                if (this.sTangCaSauGioLamViec == "True")
                {
                    this.checkBoxTangCaSauGioLamViec.Checked = true;
                }
                else
                {
                    this.checkBoxTangCaSauGioLamViec.Checked = false;
                }
                this.txtPhutTangCaSauGioLamViec.Text = dtCaLamViec.Rows[i]["SoPhutTangCaSauGioLamViec"].ToString();
                this.sTongGioLamDatDen = dtCaLamViec.Rows[i]["TongGioLamDatDen"].ToString();
                if (this.sTongGioLamDatDen == "True")
                {
                    this.checkBoxTongGioLamDatDen.Checked = true;
                }
                else
                {
                    this.checkBoxTongGioLamDatDen.Checked = false;
                }
                this.txtTongGioLamDatDen.Text = dtCaLamViec.Rows[i]["SoPhutTongGioLamDatDen"].ToString();
                this.txtTangCaTruocGioLamViecDatDen.Text = dtCaLamViec.Rows[i]["TangCaTruocGioLamViecDatDen"].ToString();
                this.txtPhutTruTangCaTruoc.Text = dtCaLamViec.Rows[i]["PhutTruTangCaTruoc"].ToString();
                this.txtTangCaSauGioLamViecDatDen.Text = dtCaLamViec.Rows[i]["TangCaSauGioLamViecDatDen"].ToString();
                this.txtPhutTruTangCaSau.Text = dtCaLamViec.Rows[i]["PhutTruTangCaSau"].ToString();
                this.txtGioiHanTangCa1.Text = dtCaLamViec.Rows[i]["GioiHanTangCa1"].ToString();
                this.txtGioiHanTangCa2.Text = dtCaLamViec.Rows[i]["GioiHanTangCa2"].ToString();
                this.txtGioiHanTangCaMuc3.Text = dtCaLamViec.Rows[i]["GioiHanTangCa3"].ToString();
                this.txtGioiHanTangCaMuc4.Text = dtCaLamViec.Rows[i]["GioiHanTangCa4"].ToString();
            }
        }

        private void khaiBao()
        {
            this.sTongGioTrongCaLamViec = Convert.ToInt32((this.dateTimeGioKetThucLamViec.Value - this.dateTimeGioVaoLamViec.Value).TotalMinutes).ToString();
            string a;
            a = Math.Round(Convert.ToSingle(this.sTongGioTrongCaLamViec) / 60f, 3).ToString();
            if (Convert.ToSingle(a) < 0f)
            {
                this.txtTongGioTrongCaLamViec.Text = (24f + Convert.ToSingle(a)).ToString();
            }
            else
            {
                this.txtTongGioTrongCaLamViec.Text = a;
            }
        }

        private void dateTimeGioVaoLamViec_ValueChanged(object sender, EventArgs e)
        {
            this.sTongGioTrongCaLamViec = Convert.ToInt32((this.dateTimeGioKetThucLamViec.Value - this.dateTimeGioVaoLamViec.Value).TotalMinutes).ToString();
            string a;
            a = Math.Round(Convert.ToSingle(this.sTongGioTrongCaLamViec) / 60f, 3).ToString();
            this.sTongGioNghiTrua = Convert.ToInt32((this.dateTimeGioKetThucNghiTrua.Value - this.dateTimeGioBatDauNghiTrua.Value).TotalMinutes).ToString();
            this.txtTongGioNghiTrua.Text = Math.Round(Convert.ToSingle(this.sTongGioNghiTrua) / 60f, 3).ToString();
            if (Convert.ToSingle(a) < 0f)
            {
                this.txtTongGioTrongCaLamViec.Text = (24f + Convert.ToSingle(a) - Convert.ToSingle(this.txtTongGioNghiTrua.Text)).ToString();
            }
            else
            {
                this.txtTongGioTrongCaLamViec.Text = (Convert.ToSingle(a) - Convert.ToSingle(this.txtTongGioNghiTrua.Text)).ToString();
            }
        }

        private void dateTimeGioKetThucLamViec_ValueChanged(object sender, EventArgs e)
        {
            this.sTongGioTrongCaLamViec = Convert.ToInt32((this.dateTimeGioKetThucLamViec.Value - this.dateTimeGioVaoLamViec.Value).TotalMinutes).ToString();
            string a;
            a = Math.Round(Convert.ToSingle(this.sTongGioTrongCaLamViec) / 60f, 3).ToString();
            this.sTongGioNghiTrua = Convert.ToInt32((this.dateTimeGioKetThucNghiTrua.Value - this.dateTimeGioBatDauNghiTrua.Value).TotalMinutes).ToString();
            this.txtTongGioNghiTrua.Text = Math.Round(Convert.ToSingle(this.sTongGioNghiTrua) / 60f, 3).ToString();
            if (Convert.ToSingle(a) < 0f)
            {
                double dXetCa2;
                dXetCa2 = (this.dateTimeGioKetThucLamViec.Value - this.dateTimeGioVaoLamViec.Value).TotalHours;
                try
                {
                    if (dXetCa2 > 0.0)
                    {
                        this.checkBoxXemCaDem.Checked = false;
                        this.dateTimeBatDauVao.Value = new DateTime(this.dateTimeGioVaoLamViec.Value.Year, this.dateTimeGioVaoLamViec.Value.Month, this.dateTimeGioVaoLamViec.Value.Day, this.dateTimeGioVaoLamViec.Value.Hour - 3, 0, 0);
                        this.dateTimeKetThucVao.Value = new DateTime(this.dateTimeGioVaoLamViec.Value.Year, this.dateTimeGioVaoLamViec.Value.Month, this.dateTimeGioVaoLamViec.Value.Day, (this.dateTimeGioVaoLamViec.Value.Hour + this.dateTimeGioKetThucLamViec.Value.Hour) / 2, 0, 0);
                        this.dateTimeBatDauRa.Value = new DateTime(this.dateTimeGioVaoLamViec.Value.Year, this.dateTimeGioVaoLamViec.Value.Month, this.dateTimeGioVaoLamViec.Value.Day, (this.dateTimeGioVaoLamViec.Value.Hour + this.dateTimeGioKetThucLamViec.Value.Hour) / 2, 1, 0);
                        this.dateTimeKetThucRa.Value = new DateTime(this.dateTimeGioVaoLamViec.Value.Year, this.dateTimeGioVaoLamViec.Value.Month, this.dateTimeGioVaoLamViec.Value.Day, this.dateTimeGioKetThucLamViec.Value.Hour + 3, 0, 0);
                    }
                    else
                    {
                        this.checkBoxXemCaDem.Checked = true;
                        this.dateTimeBatDauVao.Value = new DateTime(this.dateTimeGioVaoLamViec.Value.Year, this.dateTimeGioVaoLamViec.Value.Month, this.dateTimeGioVaoLamViec.Value.Day, this.dateTimeGioVaoLamViec.Value.Hour - 3, 0, 0);
                        this.dateTimeKetThucVao.Value = new DateTime(this.dateTimeGioVaoLamViec.Value.Year, this.dateTimeGioVaoLamViec.Value.Month, this.dateTimeGioVaoLamViec.Value.Day, 23, 59, 0);
                        this.dateTimeBatDauRa.Value = new DateTime(this.dateTimeGioVaoLamViec.Value.Year, this.dateTimeGioVaoLamViec.Value.Month, this.dateTimeGioVaoLamViec.Value.Day, 0, 1, 0);
                        this.dateTimeKetThucRa.Value = new DateTime(this.dateTimeGioVaoLamViec.Value.Year, this.dateTimeGioVaoLamViec.Value.Month, this.dateTimeGioVaoLamViec.Value.Day, this.dateTimeGioKetThucLamViec.Value.Hour + 3, 0, 0);
                    }
                }
                catch
                {
                }
                this.txtTongGioTrongCaLamViec.Text = (24f + Convert.ToSingle(a) - Convert.ToSingle(this.txtTongGioNghiTrua.Text)).ToString();
                return;
            }
            double dXetCa;
            dXetCa = (this.dateTimeGioKetThucLamViec.Value - this.dateTimeGioVaoLamViec.Value).TotalHours;
            try
            {
                if (dXetCa > 0.0)
                {
                    this.checkBoxXemCaDem.Checked = false;
                    this.dateTimeBatDauVao.Value = new DateTime(this.dateTimeGioVaoLamViec.Value.Year, this.dateTimeGioVaoLamViec.Value.Month, this.dateTimeGioVaoLamViec.Value.Day, this.dateTimeGioVaoLamViec.Value.Hour - 3, 0, 0);
                    this.dateTimeKetThucVao.Value = new DateTime(this.dateTimeGioVaoLamViec.Value.Year, this.dateTimeGioVaoLamViec.Value.Month, this.dateTimeGioVaoLamViec.Value.Day, (this.dateTimeGioVaoLamViec.Value.Hour + this.dateTimeGioKetThucLamViec.Value.Hour) / 2, 0, 0);
                    this.dateTimeBatDauRa.Value = new DateTime(this.dateTimeGioVaoLamViec.Value.Year, this.dateTimeGioVaoLamViec.Value.Month, this.dateTimeGioVaoLamViec.Value.Day, (this.dateTimeGioVaoLamViec.Value.Hour + this.dateTimeGioKetThucLamViec.Value.Hour) / 2, 1, 0);
                    this.dateTimeKetThucRa.Value = new DateTime(this.dateTimeGioVaoLamViec.Value.Year, this.dateTimeGioVaoLamViec.Value.Month, this.dateTimeGioVaoLamViec.Value.Day, this.dateTimeGioKetThucLamViec.Value.Hour + 3, 0, 0);
                }
                else
                {
                    this.checkBoxXemCaDem.Checked = true;
                    this.dateTimeBatDauVao.Value = new DateTime(this.dateTimeGioVaoLamViec.Value.Year, this.dateTimeGioVaoLamViec.Value.Month, this.dateTimeGioVaoLamViec.Value.Day, this.dateTimeGioVaoLamViec.Value.Hour - 3, 0, 0);
                    this.dateTimeKetThucVao.Value = new DateTime(this.dateTimeGioVaoLamViec.Value.Year, this.dateTimeGioVaoLamViec.Value.Month, this.dateTimeGioVaoLamViec.Value.Day, 23, 59, 0);
                    this.dateTimeBatDauRa.Value = new DateTime(this.dateTimeGioVaoLamViec.Value.Year, this.dateTimeGioVaoLamViec.Value.Month, this.dateTimeGioVaoLamViec.Value.Day, 0, 1, 0);
                    this.dateTimeKetThucRa.Value = new DateTime(this.dateTimeGioVaoLamViec.Value.Year, this.dateTimeGioVaoLamViec.Value.Month, this.dateTimeGioVaoLamViec.Value.Day, this.dateTimeGioKetThucLamViec.Value.Hour + 3, 0, 0);
                }
            }
            catch
            {
            }
            this.txtTongGioTrongCaLamViec.Text = (Convert.ToSingle(a) - Convert.ToSingle(this.txtTongGioNghiTrua.Text)).ToString();
        }

        private void dateTimeGioBatDauNghiTrua_ValueChanged(object sender, EventArgs e)
        {
            this.khaiBao();
            this.sTongGioNghiTrua = Convert.ToInt32((this.dateTimeGioKetThucNghiTrua.Value - this.dateTimeGioBatDauNghiTrua.Value).TotalMinutes).ToString();
            this.txtTongGioNghiTrua.Text = Math.Round(Convert.ToSingle(this.sTongGioNghiTrua) / 60f, 3).ToString();
            this.fTongGioLamViec = Convert.ToSingle(this.txtTongGioTrongCaLamViec.Text) - Convert.ToSingle(this.txtTongGioNghiTrua.Text);
            this.txtTongGioTrongCaLamViec.Text = this.fTongGioLamViec.ToString();
        }

        private void dateTimeGioKetThucNghiTrua_ValueChanged(object sender, EventArgs e)
        {
            this.khaiBao();
            this.sTongGioNghiTrua = Convert.ToInt32((this.dateTimeGioKetThucNghiTrua.Value - this.dateTimeGioBatDauNghiTrua.Value).TotalMinutes).ToString();
            this.txtTongGioNghiTrua.Text = Math.Round(Convert.ToSingle(this.sTongGioNghiTrua) / 60f, 3).ToString();
            this.fTongGioLamViec = Convert.ToSingle(this.txtTongGioTrongCaLamViec.Text) - Convert.ToSingle(this.txtTongGioNghiTrua.Text);
            this.txtTongGioTrongCaLamViec.Text = this.fTongGioLamViec.ToString();
        }

        private void btnThemMoi_Click(object sender, EventArgs e)
        {
            this.kiemtra = 1;
            this.sMaCaLamViec = this._maTuDong.sTuDongDienCaLamViec(this.sMaCaLamViec);
            this.txtCaLamViec.Text = string.Empty;
            this.txtCaLamViec.Focus();
            this.loadControlDatetime();
            this.txtCongTinh.Text = "1";
            this.txtKhongCoGioRa.Text = "0";
            this.txtKhongCoGioVao.Text = "0";
            this.checkBoxTruGioDiTre.Checked = true;
            this.checkBoxTruGioVeSom.Checked = true;
            this.txtChoPhepDiTre.Text = "0";
            this.txtChoPhepVeSom.Text = "0";
            this.checkBoxBatDauTinhDiTre.Checked = true;
            this.checkBoxBatDauTinhVeSom.Checked = true;
            this.txtPhutTangCaTruocGioLamViec.Text = "0";
            this.txtPhutTangCaSauGioLamViec.Text = "0";
            this.txtTongGioLamDatDen.Text = "8";
            this.txtTangCaTruocGioLamViecDatDen.Text = "0";
            this.txtTangCaSauGioLamViecDatDen.Text = "0";
            this.txtPhutTruTangCaTruoc.Text = "0";
            this.txtPhutTruTangCaSau.Text = "0";
            this.txtGioiHanTangCa1.Text = "0";
            this.txtGioiHanTangCa2.Text = "0";
            this.txtGioiHanTangCaMuc3.Text = "0";
            this.txtGioiHanTangCaMuc4.Text = "0";
            this.comboBoxTangCaHeSo.SelectedIndex = 0;
            this.comboBoxHeSoTangCaCuoiTuan.SelectedIndex = 0;
            this.comboBoxHeSoTangCaNgayLe.SelectedIndex = 0;
            this.txtTongGioNghiTrua.Text = Math.Round(Convert.ToDouble(Convert.ToInt32((this.dateTimeGioKetThucNghiTrua.Value - this.dateTimeGioBatDauNghiTrua.Value).TotalMinutes).ToString()) / 60.0, 1).ToString();
            this.txtTongGioTrongCaLamViec.Text = Math.Round(Convert.ToDouble(Convert.ToInt32((this.dateTimeGioKetThucLamViec.Value - this.dateTimeGioVaoLamViec.Value).TotalMinutes).ToString()) / 60.0, 1).ToString();
        }

        private void btnLuu_Click(object sender, EventArgs e)
        {
            if (this.kiemtra == 1)
            {
                try
                {
                    this._caLamViecDTO.MaCaLamViec = txt_MaCa.Text.Trim().ToUpper();
                    this._caLamViecDTO.CaLamViec = this.txtCaLamViec.Text;
                    this._caLamViecDTO.GioVaoLamViec = Convert.ToDateTime(this.dateTimeGioVaoLamViec.Text);
                    this._caLamViecDTO.GioKetThucLamViec = Convert.ToDateTime(this.dateTimeGioKetThucLamViec.Text);
                    this._caLamViecDTO.GioBatDauNghiTrua = Convert.ToDateTime(this.dateTimeGioBatDauNghiTrua.Text);
                    this._caLamViecDTO.GioKetThucNghiTrua = Convert.ToDateTime(this.dateTimeGioKetThucNghiTrua.Text);
                    this._caLamViecDTO.TongGioNghiTrua = Convert.ToSingle(this.txtTongGioNghiTrua.Text);
                    this._caLamViecDTO.TongGioTrongCaLamViec = Convert.ToSingle(this.txtTongGioTrongCaLamViec.Text);
                    this._caLamViecDTO.CongTinh = Convert.ToSingle(this.txtCongTinh.Text);
                    this._caLamViecDTO.BatDauVao = Convert.ToDateTime(this.dateTimeBatDauVao.Text);
                    this._caLamViecDTO.KetThucVao = Convert.ToDateTime(this.dateTimeKetThucVao.Text);
                    this._caLamViecDTO.BatDauRa = Convert.ToDateTime(this.dateTimeBatDauRa.Text);
                    this._caLamViecDTO.KetThucRa = Convert.ToDateTime(this.dateTimeKetThucRa.Text);
                    this._caLamViecDTO.KhongCoGioRa = Convert.ToInt32(this.txtKhongCoGioRa.Text);
                    this._caLamViecDTO.KhongCoGioVao = Convert.ToInt32(this.txtKhongCoGioVao.Text);
                    bool _XemCaDem;
                    _XemCaDem = (this.checkBoxXemCaDem.Checked ? true : false);
                    this._caLamViecDTO.XemCaDem = _XemCaDem;
                    bool _TinhBuTru;
                    _TinhBuTru = (this.checkBoxTinhBuTru.Checked ? true : false);
                    this._caLamViecDTO.TinhBuTru = _TinhBuTru;
                    bool _TruGioDiTre;
                    _TruGioDiTre = (this.checkBoxTruGioDiTre.Checked ? true : false);
                    this._caLamViecDTO.TruGioDiTre = _TruGioDiTre;
                    bool _TruGioVeSom;
                    _TruGioVeSom = (this.checkBoxTruGioVeSom.Checked ? true : false);
                    this._caLamViecDTO.TruGioVeSom = _TruGioVeSom;
                    this._caLamViecDTO.ChoPhepDiTre = Convert.ToInt32(this.txtChoPhepDiTre.Text);
                    this._caLamViecDTO.ChoPhepVeSom = Convert.ToInt32(this.txtChoPhepVeSom.Text);
                    bool _BatDauTinhDiTre;
                    _BatDauTinhDiTre = (this.checkBoxBatDauTinhDiTre.Checked ? true : false);
                    this._caLamViecDTO.BatDauTinhDiTre = _BatDauTinhDiTre;
                    bool _BatDauTinhVeSom;
                    _BatDauTinhVeSom = (this.checkBoxBatDauTinhVeSom.Checked ? true : false);
                    this._caLamViecDTO.BatDauTinhVeSom = _BatDauTinhVeSom;
                    bool _XemCaNayLaTangCa;
                    _XemCaNayLaTangCa = (this.checkBoxXemCaNayLaTangCa.Checked ? true : false);
                    this._caLamViecDTO.XemCaNayLaTangCa = _XemCaNayLaTangCa;
                    this._caLamViecDTO.TangCaMuc = Convert.ToInt32(this.comboBoxTangCaHeSo.Text);
                    bool _XemCuoiTuanLaTangCa;
                    _XemCuoiTuanLaTangCa = (this.checkBoxXemCuoiTuanLaTangCa.Checked ? true : false);
                    this._caLamViecDTO.XemCuoiTuanLaTangCa = _XemCuoiTuanLaTangCa;
                    this._caLamViecDTO.TangCaCuoiTuanMuc = Convert.ToInt32(this.comboBoxHeSoTangCaCuoiTuan.Text);
                    bool _XemNgayLeLaTangCa;
                    _XemNgayLeLaTangCa = (this.checkBoxXemNgayLeLaTangCa.Checked ? true : false);
                    this._caLamViecDTO.XemNgayLeLaTangCa = _XemNgayLeLaTangCa;
                    this._caLamViecDTO.TangCaNgayLeMuc = Convert.ToInt32(this.comboBoxHeSoTangCaNgayLe.Text);
                    bool _TangCaTruocGioLamViec;
                    _TangCaTruocGioLamViec = (this.checkBoxTangCaTruocGioLamViec.Checked ? true : false);
                    this._caLamViecDTO.TangCaTruocGioLamViec = _TangCaTruocGioLamViec;
                    this._caLamViecDTO.SoPhutTangCaTruocGioLamViec = Convert.ToInt32(this.txtPhutTangCaTruocGioLamViec.Text);
                    bool _TangCaSauGioLamViec;
                    _TangCaSauGioLamViec = (this.checkBoxTangCaSauGioLamViec.Checked ? true : false);
                    this._caLamViecDTO.TangCaSauGioLamViec = _TangCaSauGioLamViec;
                    this._caLamViecDTO.SoPhutTangCaSauGioLamViec = Convert.ToInt32(this.txtPhutTangCaSauGioLamViec.Text);
                    bool _TongGioLamDatDen;
                    _TongGioLamDatDen = (this.checkBoxTongGioLamDatDen.Checked ? true : false);
                    this._caLamViecDTO.TongGioLamDatDen = _TongGioLamDatDen;
                    this._caLamViecDTO.SoPhutTongGioLamDatDen = Convert.ToInt32(this.txtTongGioLamDatDen.Text);
                    this._caLamViecDTO.TangCaTruocGioLamViecDatDen = Convert.ToInt32(this.txtTangCaTruocGioLamViecDatDen.Text);
                    this._caLamViecDTO.PhutTruTangCaTruoc = Convert.ToInt32(this.txtPhutTruTangCaTruoc.Text);
                    this._caLamViecDTO.TangCaSauGioLamViecDatDen = Convert.ToInt32(this.txtTangCaSauGioLamViecDatDen.Text);
                    this._caLamViecDTO.PhutTruTangCaSau = Convert.ToInt32(this.txtPhutTruTangCaSau.Text);
                    this._caLamViecDTO.GioiHanTangCa1 = Convert.ToInt32(this.txtGioiHanTangCa1.Text);
                    this._caLamViecDTO.GioiHanTangCa2 = Convert.ToInt32(this.txtGioiHanTangCa2.Text);
                    this._caLamViecDTO.GioiHanTangCa3 = Convert.ToInt32(this.txtGioiHanTangCaMuc3.Text);
                    this._caLamViecDTO.GioiHanTangCa4 = Convert.ToInt32(this.txtGioiHanTangCaMuc4.Text);
                    this._caLamViecBLL.InsertCaLamViec(this._caLamViecDTO);
                    RJMessageBox.Show("Lưu thành công");
                    this.DGVCaLamViec.Rows.Clear();
                    this.loadDataGirdView();
                    return;
                }
                catch
                {
                    RJMessageBox.Show("Vui Lòng click thêm mới trước khi lưu ca làm việc", "Thông báo");
                    return;
                }
            }
            try
            {
                this._caLamViecDTO.MaCaLamViec = txt_MaCa.Text.Trim().ToUpper();
                this._caLamViecDTO.CaLamViec = this.txtCaLamViec.Text;
                this._caLamViecDTO.GioVaoLamViec = Convert.ToDateTime(this.dateTimeGioVaoLamViec.Text);
                this._caLamViecDTO.GioKetThucLamViec = Convert.ToDateTime(this.dateTimeGioKetThucLamViec.Text);
                this._caLamViecDTO.GioBatDauNghiTrua = Convert.ToDateTime(this.dateTimeGioBatDauNghiTrua.Text);
                this._caLamViecDTO.GioKetThucNghiTrua = Convert.ToDateTime(this.dateTimeGioKetThucNghiTrua.Text);
                this._caLamViecDTO.TongGioNghiTrua = Convert.ToSingle(this.txtTongGioNghiTrua.Text);
                this._caLamViecDTO.TongGioTrongCaLamViec = Convert.ToSingle(this.txtTongGioTrongCaLamViec.Text);
                this._caLamViecDTO.CongTinh = Convert.ToSingle(this.txtCongTinh.Text);
                this._caLamViecDTO.BatDauVao = Convert.ToDateTime(this.dateTimeBatDauVao.Text);
                this._caLamViecDTO.KetThucVao = Convert.ToDateTime(this.dateTimeKetThucVao.Text);
                this._caLamViecDTO.BatDauRa = Convert.ToDateTime(this.dateTimeBatDauRa.Text);
                this._caLamViecDTO.KetThucRa = Convert.ToDateTime(this.dateTimeKetThucRa.Text);
                this._caLamViecDTO.KhongCoGioRa = Convert.ToInt32(this.txtKhongCoGioRa.Text);
                this._caLamViecDTO.KhongCoGioVao = Convert.ToInt32(this.txtKhongCoGioVao.Text);
                bool _XemCaDem;
                _XemCaDem = (this.checkBoxXemCaDem.Checked ? true : false);
                this._caLamViecDTO.XemCaDem = _XemCaDem;
                bool _TinhBuTru;
                _TinhBuTru = (this.checkBoxTinhBuTru.Checked ? true : false);
                this._caLamViecDTO.TinhBuTru = _TinhBuTru;
                bool _TruGioDiTre;
                _TruGioDiTre = (this.checkBoxTruGioDiTre.Checked ? true : false);
                this._caLamViecDTO.TruGioDiTre = _TruGioDiTre;
                bool _TruGioVeSom;
                _TruGioVeSom = (this.checkBoxTruGioVeSom.Checked ? true : false);
                this._caLamViecDTO.TruGioVeSom = _TruGioVeSom;
                this._caLamViecDTO.ChoPhepDiTre = Convert.ToInt32(this.txtChoPhepDiTre.Text);
                this._caLamViecDTO.ChoPhepVeSom = Convert.ToInt32(this.txtChoPhepVeSom.Text);
                bool _BatDauTinhDiTre;
                _BatDauTinhDiTre = (this.checkBoxBatDauTinhDiTre.Checked ? true : false);
                this._caLamViecDTO.BatDauTinhDiTre = _BatDauTinhDiTre;
                bool _BatDauTinhVeSom;
                _BatDauTinhVeSom = (this.checkBoxBatDauTinhVeSom.Checked ? true : false);
                this._caLamViecDTO.BatDauTinhVeSom = _BatDauTinhVeSom;
                bool _XemCaNayLaTangCa;
                _XemCaNayLaTangCa = (this.checkBoxXemCaNayLaTangCa.Checked ? true : false);
                this._caLamViecDTO.XemCaNayLaTangCa = _XemCaNayLaTangCa;
                this._caLamViecDTO.TangCaMuc = Convert.ToInt32(this.comboBoxTangCaHeSo.Text);
                bool _XemCuoiTuanLaTangCa;
                _XemCuoiTuanLaTangCa = (this.checkBoxXemCuoiTuanLaTangCa.Checked ? true : false);
                this._caLamViecDTO.XemCuoiTuanLaTangCa = _XemCuoiTuanLaTangCa;
                this._caLamViecDTO.TangCaCuoiTuanMuc = Convert.ToInt32(this.comboBoxHeSoTangCaCuoiTuan.Text);
                bool _XemNgayLeLaTangCa;
                _XemNgayLeLaTangCa = (this.checkBoxXemNgayLeLaTangCa.Checked ? true : false);
                this._caLamViecDTO.XemNgayLeLaTangCa = _XemNgayLeLaTangCa;
                this._caLamViecDTO.TangCaNgayLeMuc = Convert.ToInt32(this.comboBoxHeSoTangCaNgayLe.Text);
                bool _TangCaTruocGioLamViec;
                _TangCaTruocGioLamViec = (this.checkBoxTangCaTruocGioLamViec.Checked ? true : false);
                this._caLamViecDTO.TangCaTruocGioLamViec = _TangCaTruocGioLamViec;
                this._caLamViecDTO.SoPhutTangCaTruocGioLamViec = Convert.ToInt32(this.txtPhutTangCaTruocGioLamViec.Text);
                bool _TangCaSauGioLamViec;
                _TangCaSauGioLamViec = (this.checkBoxTangCaSauGioLamViec.Checked ? true : false);
                this._caLamViecDTO.TangCaSauGioLamViec = _TangCaSauGioLamViec;
                this._caLamViecDTO.SoPhutTangCaSauGioLamViec = Convert.ToInt32(this.txtPhutTangCaSauGioLamViec.Text);
                bool _TongGioLamDatDen;
                _TongGioLamDatDen = (this.checkBoxTongGioLamDatDen.Checked ? true : false);
                this._caLamViecDTO.TongGioLamDatDen = _TongGioLamDatDen;
                this._caLamViecDTO.SoPhutTongGioLamDatDen = Convert.ToInt32(this.txtTongGioLamDatDen.Text);
                this._caLamViecDTO.TangCaTruocGioLamViecDatDen = Convert.ToInt32(this.txtTangCaTruocGioLamViecDatDen.Text);
                this._caLamViecDTO.PhutTruTangCaTruoc = Convert.ToInt32(this.txtPhutTruTangCaTruoc.Text);
                this._caLamViecDTO.TangCaSauGioLamViecDatDen = Convert.ToInt32(this.txtTangCaSauGioLamViecDatDen.Text);
                this._caLamViecDTO.PhutTruTangCaSau = Convert.ToInt32(this.txtPhutTruTangCaSau.Text);
                this._caLamViecDTO.GioiHanTangCa1 = Convert.ToInt32(this.txtGioiHanTangCa1.Text);
                this._caLamViecDTO.GioiHanTangCa2 = Convert.ToInt32(this.txtGioiHanTangCa2.Text);
                this._caLamViecDTO.GioiHanTangCa3 = Convert.ToInt32(this.txtGioiHanTangCaMuc3.Text);
                this._caLamViecDTO.GioiHanTangCa4 = Convert.ToInt32(this.txtGioiHanTangCaMuc4.Text);
                this._caLamViecBLL.UpdateCaLamViec(this._caLamViecDTO);
                RJMessageBox.Show("Sửa thành công");
                this.DGVCaLamViec.Rows.Clear();
                this.loadDataGirdView();
            }
            catch
            {
                RJMessageBox.Show("Chỉnh sửa sai thông tin, vui lòng nhập liệu lại", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Hand);
            }
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            if (this.sMaCaLamViec == "" || this.sMaCaLamViec == null)
            {
                RJMessageBox.Show("Bạn chưa chọn ca làm việc cần xóa", "Thông báo");
                return;
            }
            DialogResult result = RJMessageBox.Show("Bạn có chác muốn xóa?", "Thông báo", MessageBoxButtons.YesNo);
            if(result == DialogResult.Yes)
            {
                this._caLamViecBLL.DeleteCaLamViec(sMaCaLamViec);
                RJMessageBox.Show("Xóa thành công");
                this.DGVCaLamViec.Rows.Clear();
                this.loadDataGirdView();
            }
        }
    }
}
