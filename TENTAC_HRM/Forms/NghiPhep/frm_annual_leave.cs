using ComponentFactory.Krypton.Toolkit;
using MathNet.Numerics.Distributions;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Windows.Forms;
using TENTAC_HRM.Consts;
using TENTAC_HRM.Custom;

namespace TENTAC_HRM.Forms.NghiPhep
{
    public partial class frm_annual_leave : KryptonForm
    {
        public bool edit { get; set; }
        public string _ma_nhan_vien { get; set; }
        public int _id_nghi_phep_value { get; set; }
        public int _id_trangthai { get; set; }
        public int[] idPermision { get; set; }
        DataProvider provider = new DataProvider();
        private Frm_NghiPhep uc_nghiphep;
        string _LoaiPhepNghi, _GhiChu;
        int _NuaNgay, _IdTrangThai, _Nam, _MaChamCong;
        decimal _SoNgay;
        DateTime _NgayNghi;
        public frm_annual_leave(int[] permissions)
        {
            InitializeComponent();
            idPermision = permissions;
            uc_nghiphep = new Frm_NghiPhep(idPermision);

            //if (LoginInfo.LoaiUser == "NhanVien")
            //{
            //    chk_ToTruong.Checked = false;
            //    chk_quanly.Checked = false;
            //    chk_nhansu.Checked = false;
            //}
            //else if (LoginInfo.LoaiUser == "ToTruong")
            //{
            //    chk_ToTruong.Checked = true;
            //    chk_quanly.Checked = false;
            //    chk_nhansu.Checked = false;
            //}
            //else if (LoginInfo.LoaiUser == "QuanLy")
            //{
            //    chk_ToTruong.Checked = false;
            //    chk_quanly.Checked = true;
            //    chk_nhansu.Checked = false;
            //}
            //else if (LoginInfo.LoaiUser == "HR" || LoginInfo.LoaiUser.ToUpper() == "ADMIN")
            //{
            //    chk_ToTruong.Checked = true;
            //    chk_quanly.Checked = true;
            //    chk_nhansu.Checked = true;
            //}
        }
        private void VisibleButton()
        {
            if (_id_trangthai == 199)
            {
                btn_send.Visible = false;
            }
        }
        private void frm_annual_leave_Load(object sender, EventArgs e)
        {
            VisibleButton();
            load_nhanvien();
            load_loaiphep();
            LoadComboboxYear();
            LoadComboboxMonth();
            if (edit == true)
            {
                load_data();
                cbo_NhanVien.Enabled = false;
                cbo_NhanVien.SelectedValue = _ma_nhan_vien;
            }
            LoadCheckList();
        }
        private void LoadComboboxYear()
        {
            List<int> dtyear = new List<int>();
            for (int i = 2016; i <= DateTime.Now.Year + 2; i++)
            {
                dtyear.Add(i);
            }
            cbo_Nam.DataSource = dtyear;
            cbo_Nam.Text = DateTime.Now.Year.ToString();
        }
        private void LoadComboboxMonth()
        {
            List<int> dtyear = new List<int>();
            for (int i = 1; i <= 12; i++)
            {
                dtyear.Add(i);
            }
            cbo_Thang.DataSource = dtyear;
            cbo_Thang.Text = DateTime.Now.Month.ToString();
        }
        private void load_data()
        {
            //string sql = string.Format("select * from tbl_NghiPhepNam where id = {0}", _id_nghi_phep_value);
            //DataTable dataTable = new DataTable();
            //dataTable = SQLHelper.ExecuteDt(sql);
            //if (dataTable.Rows.Count > 0)
            //{
            //    cbo_loaiphep.SelectedValue = dataTable.Rows[0]["LoaiPhepNghi"].ToString();
            //    txt_noidung.Text = dataTable.Rows[0]["GhiChu"].ToString();
            //    chk_ToTruong.Checked = bool.Parse(dataTable.Rows[0]["Chk_ToTruong"].ToString());
            //    chk_quanly.Checked = bool.Parse(dataTable.Rows[0]["Chk_QuanLy"].ToString());
            //    chk_nhansu.Checked = bool.Parse(dataTable.Rows[0]["Chk_NhanSu"].ToString());
            //}

            string sql = string.Empty;
            sql = $@"Select * from tbl_NghiPhepNam where id = {SQLHelper.rpI(_id_nghi_phep_value)} and del_flg = 0";
            DataTable dt = SQLHelper.ExecuteDt(sql);
            if (dt.Rows.Count > 0)
            {
                cbo_LoaiPhep.SelectedValue = dt.Rows[0]["LoaiPhepNghi"].ToString();
                txt_NoiDung.Text = dt.Rows[0]["GhiChu"].ToString();
            }
        }
        private void load_nhanvien()
        {
            //cbo_NhanVien.DataSource = provider.load_nhanvien(LoginInfo.MaChamCong);
            cbo_NhanVien.DataSource = provider.load_nhanvien_by_phongban(LoginInfo.MaPhongBan);
            cbo_NhanVien.DisplayMember = "name";
            cbo_NhanVien.ValueMember = "value";
        }
        private void load_loaiphep()
        {
            cbo_LoaiPhep.DataSource = provider.load_loaiphep();
            cbo_LoaiPhep.DisplayMember = "name";
            cbo_LoaiPhep.ValueMember = "id";
        }

        private void btn_close_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        decimal songay = 0;
        private void btn_send_Click(object sender, EventArgs e)
        {
            //TimeSpan t = DateTime.Parse(dtp_denngay.Value.ToString("yyyy/MM/dd HH:mm")) - DateTime.Parse(dtp_tungay.Value.ToString("yyyy/MM/dd HH:mm"));

            //if((int)t.Hours <= 4 && (int)t.Days == 0)
            //{
            //    songay = decimal.Parse("0.5");
            //}
            //else if((int)t.Hours <= 4 && (int)t.Days > 0)
            //{
            //    songay = (int)t.Days + decimal.Parse("0.5");
            //}
            //else
            //{
            //    songay = (int)t.Days + 1;
            //}
            if (!CheckValidate())
            {
                return;
            }
            SetValues();
            if (!CheckNumberLeave())
            {
                return;
            }
            if (edit == true)
            {
                UpdateData();
            }
            else
            {
                InsertData();
            }

            uc_nghiphep.load_data();
            this.Close();
        }
        private bool CheckValidate()
        {
            if (cbo_NhanVien.SelectedIndex == 0)
            {
                RJMessageBox.Show("Vui lòng chọn nhân viên.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            if (string.IsNullOrEmpty(cbo_LoaiPhep.SelectedValue.ToString()))
            {
                RJMessageBox.Show("Vui lòng chọn loại phép.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            return true;
        }
        private bool CheckNumberLeave()
        {
            if (_LoaiPhepNghi == "LP001")
            {
                decimal soPhepCoTheSuDung = TotalLeaveDays();
                if (soPhepCoTheSuDung - _SoNgay < 0)
                {
                    RJMessageBox.Show("Số phép năm của bạn không đủ, vui lòng chọn loại phép khác.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return false;
                }
            }
            return true;
        }
        private decimal TotalLeaveDays()
        {
            string sql = string.Empty;
            decimal res = 0;
            sql = $@"SELECT a.MaChamCong, a.TongNgayPhep, COALESCE(SUM(b.SoNgay), 0) AS TongNgayNghi, (a.TongNgayPhep - COALESCE(SUM(b.SoNgay), 0)) AS SoPhepSuDung
                    FROM  tbl_NgayPhepNam a
                    LEFT JOIN tbl_NghiPhepNam b ON a.MaChamCong = b.MaChamCong AND b.del_flg = 0  
                    AND YEAR(b.NgayNghi) = a.Nam and b.LoaiPhepNghi= 'LP001' and b.Id_TrangThai != 198 
                    WHERE a.MaChamCong = {SQLHelper.rpI(_MaChamCong)}  AND a.del_flg = 0 and a.Nam = {SQLHelper.rpI(_Nam)} 
                    GROUP BY a.MaChamCong, a.TongNgayPhep;";
            DataTable dt = SQLHelper.ExecuteDt(sql);
            if (dt.Rows.Count > 0)
            {
                res = string.IsNullOrEmpty(dt.Rows[0]["SoPhepSuDung"].ToString()) ? 0 : decimal.Parse(dt.Rows[0]["SoPhepSuDung"].ToString());
                txt_SoPhepNamTon.Text = res.ToString();
                return res;
            }
            txt_SoPhepNamTon.Text = res.ToString();
            return res;
        }
        private void SetValues()
        {
            _MaChamCong = Convert.ToInt32(cbo_NhanVien.SelectedValue.ToString().Substring(2));
            _Nam = int.Parse(cbo_Nam.Text);
            _LoaiPhepNghi = cbo_LoaiPhep.SelectedValue.ToString();
            foreach (var item in lv_Ngay.CheckedItems)
            {
                _NuaNgay = 0;
                if (chk_BuoiSang.Checked == true && chk_BuoiChieu.Checked == false)
                {
                    _NuaNgay = 1;
                }
                else if (chk_BuoiSang.Checked == false && chk_BuoiChieu.Checked == true)
                {
                    _NuaNgay = 2;
                }
                _NgayNghi = DateTime.ParseExact(cbo_Nam.Text + cbo_Thang.Text.PadLeft(2, '0') + item.ToString().PadLeft(2, '0'), "yyyyMMdd", System.Globalization.CultureInfo.InvariantCulture);
            }
            _GhiChu = txt_NoiDung.Text;
            _SoNgay = decimal.Parse(_NuaNgay != 0 ? "0.5" : "1");
            _IdTrangThai = CheckReportTo() == true ? 197 : 199;
        }
        private void InsertData()
        {
            try
            {
                //foreach (var item in lv_Ngay.CheckedItems)
                //{
                //    try
                //    {
                //        int nuangay = 0;
                //        if (chk_BuoiSang.Checked == true && chk_BuoiChieu.Checked == false)
                //        {
                //            nuangay = 1;
                //        }
                //        else if (chk_BuoiSang.Checked == false && chk_BuoiChieu.Checked == true)
                //        {
                //            nuangay = 2;
                //        }
                //        string sql = "insert into tbl_NghiPhepNam(MaChamCong,Nam,LoaiPhepNghi,NgayNghi,GhiChu,SoNgay,NguoiTao,NuaNgay,Chk_QuanLy,Chk_NhanSu,Chk_ToTruong) " +
                //                    $"values('{int.Parse(cbo_nhanvien.SelectedValue.ToString().Remove(0, 2))}'," +
                //                    $"'{cbo_Nam.Text}'," +
                //                    $"'{cbo_loaiphep.SelectedValue.ToString()}'," +
                //                    $"'{cbo_Nam.Text + cbo_Thang.Text.PadLeft(2, '0') + item.ToString().PadLeft(2, '0')}'," +
                //                    $"'{txt_noidung.Text}'," +
                //                    $"'{(nuangay != 0 ? "0.5" : "1")}'," +
                //                    $"'{SQLHelper.sIdUser}'," +
                //                    $"'{nuangay}'," +
                //                    $"'{(chk_ToTruong.Checked == true ? 1 : 0)}'," +
                //                    $"'{(chk_quanly.Checked == true ? 1 : 0)}'," +
                //                    $"'{(chk_nhansu.Checked == true ? 1 : 0)}')";
                //        SQLHelper.ExecuteSql(sql);
                //    }
                //    catch (Exception ex)
                //    {
                //        throw new Exception(ex.Message);
                //    }
                //}

                string sql = string.Empty;
                sql = $@"Insert into tbl_NghiPhepNam(MaChamCong, Nam, LoaiPhepNghi, NgayNghi, GhiChu, SoNgay, NuaNgay, NguoiXacNhan, 
                        Id_TrangThai, del_flg, NgayTao, NguoiTao)
                        Values({SQLHelper.rpI(_MaChamCong)}, {SQLHelper.rpI(_Nam)}, {SQLHelper.rpStr(_LoaiPhepNghi)}, {SQLHelper.rpDT(_NgayNghi)},
                        {SQLHelper.rpStr(_GhiChu)}, {SQLHelper.rpD(_SoNgay)}, {SQLHelper.rpI(_NuaNgay)}, {SQLHelper.rpStr(LoginInfo.ReportTo)}, 
                        {SQLHelper.rpI(_IdTrangThai)}, 0, '{DateTime.Now}', {SQLHelper.rpStr(SQLHelper.sUser)})";
                int res = SQLHelper.ExecuteSql(sql);
                if (res > 0)
                {
                    RJMessageBox.Show("Gửi đơn nghỉ phép thành công.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    RJMessageBox.Show("Gửi đơn nghỉ phép thất bại.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
            }
            catch (Exception ex)
            {
                RJMessageBox.Show(ex.Message, "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void UpdateData()
        {
            try
            {
                //string sql = $"update tbl_NghiPhepNam set LoaiPhepNghi = '{cbo_loaiphep.SelectedValue.ToString()}', " +
                //            $"NgayNghi='{cbo_Nam.Text + cbo_Thang.Text.PadLeft(2, '0') + item.ToString().PadLeft(2, '0')}', " +
                //            $"GhiChu='{txt_noidung.Text}'," +
                //            $"SoNgay='{(nuangay != 0 ? "0.5" : "1")}', " +
                //            $"NgayCapNhat = GETDATE(),Nam = '{cbo_Nam.Text}'," +
                //            $"NguoiTao = '{SQLHelper.sIdUser}', " +
                //            $"NuaNgay = '{nuangay}'," +
                //            $"Chk_ToTruong = '{(chk_ToTruong.Checked == true ? 1 : 0)}', " +
                //            $"Chk_QuanLy = '{(chk_quanly.Checked == true ? 1 : 0)}', Chk_NhanSu = '{(chk_nhansu.Checked == true ? 1 : 0)}' " +
                //            $"where id = '{_id_nghi_phep_value}'";
                //SQLHelper.ExecuteSql(sql);

                string sql = string.Empty;
                sql = $@"Update tbl_NghiPhepNam set MaChamCong = {SQLHelper.rpI(_MaChamCong)},
                Nam = {SQLHelper.rpI(_Nam)}, LoaiPhepNghi = {SQLHelper.rpStr(_LoaiPhepNghi)}, NgayNghi = {SQLHelper.rpDT(_NgayNghi)},
                GhiChu = {SQLHelper.rpStr(_GhiChu)}, SoNgay = {SQLHelper.rpD(_SoNgay)}, NuaNgay = {SQLHelper.rpI(_NuaNgay)},
                NgayCapNhat = '{DateTime.Now}', NguoiCapNhat = {SQLHelper.rpStr(SQLHelper.sUser)}
                Where Id= {SQLHelper.rpI(_id_nghi_phep_value)} and Id_TrangThai = 197 and del_flg = 0";
                int res = SQLHelper.ExecuteSql(sql);
                if (res > 0)
                {
                    RJMessageBox.Show("Cập nhật nghỉ phép thành công.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    RJMessageBox.Show("Cập nhật nghỉ phép thất bại.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                RJMessageBox.Show(ex.Message, "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private bool CheckReportTo()
        {
            string sql = string.Empty;
            sql = $@"Select ReportTo from [TENTAC_HRM].[dbo].[tbl_NhanVien] where MaNhanVien = {SQLHelper.rpStr(cbo_NhanVien.SelectedValue.ToString())}";
            DataTable dt = new DataTable();
            dt = SQLHelper.ExecuteDt(sql);
            if (dt.Rows.Count > 0 && !string.IsNullOrEmpty(dt.Rows[0]["ReportTo"].ToString()))
            {
                return true;
            }
            return false;
        }
        private void btn_cancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        private void cbo_NhanVien_SelectedIndexChanged(object sender, EventArgs e)
        {
            _MaChamCong = cbo_NhanVien.SelectedIndex == 0 ? 0 : Convert.ToInt32(cbo_NhanVien.SelectedValue.ToString().Substring(2));
            string selectedEmployee = cbo_NhanVien.SelectedValue.ToString();
            if (!txt_NhanVien.Text.Contains(selectedEmployee))
            {
                if (!string.IsNullOrEmpty(txt_NhanVien.Text))
                {
                    txt_NhanVien.Text += ", ";
                }
                if (cbo_NhanVien.SelectedIndex != 0)
                    txt_NhanVien.Text += cbo_NhanVien.SelectedValue.ToString();
            }
            TotalLeaveDays();
        }
        private void cbo_Nam_SelectedIndexChanged(object sender, EventArgs e)
        {
            _Nam = int.Parse(cbo_Nam.Text);
            TotalLeaveDays();
        }
        private void LoadCheckList()
        {
            lv_Ngay.Items.Clear();
            int _year = int.Parse(cbo_Nam.Text);
            int tongNgay;
            switch (int.Parse(cbo_Thang.Text))
            {
                case 1:
                case 3:
                case 5:
                case 7:
                case 8:
                case 10:
                case 12:
                    tongNgay = 31;
                    break;
                case 4:
                case 6:
                case 9:
                case 11:
                    tongNgay = 30;
                    break;
                case 2:
                    tongNgay = ((_year % 400 != 0 && (_year % 4 != 0 || _year % 100 == 0)) ? 28 : 29);
                    break;
                default:
                    tongNgay = 0;
                    break;
            }
            for (int i = 1; i <= tongNgay; i++)
            {
                lv_Ngay.Items.Add(i.ToString());
            }
        }
        private void cbo_Thang_SelectionChangeCommitted(object sender, EventArgs e)
        {
            LoadCheckList();
        }
        private void cbo_Nam_SelectionChangeCommitted(object sender, EventArgs e)
        {
            LoadCheckList();
        }
        private void cbo_loaiphep_SelectionChangeCommitted(object sender, EventArgs e)
        {
            MultiColumnComboBox senderComboBox = (MultiColumnComboBox)sender;
            if (senderComboBox.SelectedValue.ToString() == "LP001" || senderComboBox.SelectedValue.ToString() == "LP002")
            {
                chk_BuoiSang.Enabled = true;
                chk_BuoiChieu.Enabled = true;
            }
            else
            {
                chk_BuoiSang.Enabled = false;
                chk_BuoiChieu.Enabled = false;
            }
        }
    }
}
