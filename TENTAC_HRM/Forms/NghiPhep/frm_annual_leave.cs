using System;
using System.Collections.Generic;
using System.Data;
using System.Windows.Forms;
using TENTAC_HRM.Consts;
using TENTAC_HRM.Custom;

namespace TENTAC_HRM.Forms.NghiPhep
{
    public partial class frm_annual_leave : Form
    {
        public bool edit { get; set; }
        public string _ma_nhan_vien { get; set; }
        public string _id_nghi_phep_value { get; set; }
        DataProvider provider = new DataProvider();
        Frm_NghiPhep uc_nghiphep = new Frm_NghiPhep();
        public frm_annual_leave(Frm_NghiPhep _uc_nghiphep)
        {
            InitializeComponent();
            this.uc_nghiphep = _uc_nghiphep;
            if(LoginInfo.LoaiUser == "NhanVien")
            {
                chk_ToTruong.Checked = false;
                chk_quanly.Checked = false;
                chk_nhansu.Checked = false;
            }else if(LoginInfo.LoaiUser == "ToTruong")
            {
                chk_ToTruong.Checked = true;
                chk_quanly.Checked = false;
                chk_nhansu.Checked = false;
            }
            else if (LoginInfo.LoaiUser == "QuanLy")
            {
                chk_ToTruong.Checked = false;
                chk_quanly.Checked = true;
                chk_nhansu.Checked = false;
            }else if(LoginInfo.LoaiUser == "HR" || LoginInfo.LoaiUser.ToUpper() == "ADMIN")
            {
                chk_ToTruong.Checked = true;
                chk_quanly.Checked = true;
                chk_nhansu.Checked = true;
            }
        }

        private void frm_annual_leave_Load(object sender, EventArgs e)
        {
            load_nhanvien();
            load_loaiphep();
            LoadYear();
            LoadMonth();
            if (edit == true)
            {
                load_data();
                cbo_nhanvien.Enabled = false;
                cbo_nhanvien.SelectedValue = _ma_nhan_vien;
            }
            LoadCheckList();
        }
        private void LoadYear()
        {
            List<int> dtyear = new List<int>();
            for (int i = 2016; i <= DateTime.Now.Year + 2; i++)
            {
                dtyear.Add(i);
            }
            cbo_Nam.DataSource = dtyear;
            cbo_Nam.Text = DateTime.Now.Year.ToString();
        }
        private void LoadMonth()
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
            string sql = string.Format("select * from tbl_NghiPhepNam where id = {0}", _id_nghi_phep_value);
            DataTable dataTable = new DataTable();
            dataTable = SQLHelper.ExecuteDt(sql);
            if (dataTable.Rows.Count > 0)
            {
                cbo_loaiphep.SelectedValue = dataTable.Rows[0]["LoaiPhepNghi"].ToString();
                txt_noidung.Text = dataTable.Rows[0]["GhiChu"].ToString();
                chk_ToTruong.Checked = bool.Parse(dataTable.Rows[0]["Chk_ToTruong"].ToString());
                chk_quanly.Checked = bool.Parse(dataTable.Rows[0]["Chk_QuanLy"].ToString());
                chk_nhansu.Checked = bool.Parse(dataTable.Rows[0]["Chk_NhanSu"].ToString());
            }
        }
        private void load_nhanvien()
        {
            cbo_nhanvien.DataSource = provider.load_nhanvien(LoginInfo.MaChamCong);
            cbo_nhanvien.DisplayMember = "name";
            cbo_nhanvien.ValueMember = "value";
        }
        private void load_loaiphep()
        {
            cbo_loaiphep.DataSource = provider.load_loaiphep();
            cbo_loaiphep.DisplayMember = "name";
            cbo_loaiphep.ValueMember = "id";
        }

        private void btn_close_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        decimal songay = 0;
        private void btn_save_Click(object sender, EventArgs e)
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

            if (edit == true)
            {
                update_data();
            }
            else
            {
                save_data();
            }
            uc_nghiphep.load_data();
        }

        private void save_data()
        {
            try
            {
                foreach (var item in lv_Ngay.CheckedItems)
                {
                    try
                    {
                        int nuangay = 0;
                        if(chk_BuoiSang.Checked == true && chk_BuoiChieu.Checked == false)
                        {
                            nuangay = 1;
                        }else if(chk_BuoiSang.Checked == false && chk_BuoiChieu.Checked == true)
                        {
                            nuangay = 2;
                        }
                        string sql = "insert into tbl_NghiPhepNam(MaChamCong,Nam,LoaiPhepNghi,NgayNghi,GhiChu,SoNgay,NguoiTao,NuaNgay,Chk_QuanLy,Chk_NhanSu,Chk_ToTruong) " +
                                    $"values('{int.Parse(cbo_nhanvien.SelectedValue.ToString().Remove(0, 2))}'," +
                                    $"'{cbo_Nam.Text}'," +
                                    $"'{cbo_loaiphep.SelectedValue.ToString()}'," +
                                    $"'{cbo_Nam.Text + cbo_Thang.Text.PadLeft(2, '0') + item.ToString().PadLeft(2, '0')}'," +
                                    $"'{txt_noidung.Text}'," +
                                    $"'{(nuangay != 0 ? "0.5" : "1")}'," +
                                    $"'{SQLHelper.sIdUser}'," +
                                    $"'{nuangay}'," +
                                    $"'{(chk_ToTruong.Checked == true ? 1 : 0)}'," +
                                    $"'{(chk_quanly.Checked == true ? 1 : 0)}'," +
                                    $"'{(chk_nhansu.Checked == true ? 1 : 0)}')";
                        SQLHelper.ExecuteSql(sql);
                    }
                    catch (Exception ex)
                    {
                        throw new Exception(ex.Message);
                    }
                }
                RJMessageBox.Show("Thêm thành công", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                RJMessageBox.Show(ex.Message, "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void update_data()
        {
            try
            {
                foreach (var item in lv_Ngay.CheckedItems)
                {
                    try
                    {
                        int nuangay = 0;
                        if (chk_BuoiSang.Checked == true && chk_BuoiChieu.Checked == false)
                        {
                            nuangay = 1;
                        }
                        else if (chk_BuoiSang.Checked == false && chk_BuoiChieu.Checked == true)
                        {
                            nuangay = 2;
                        }
                        string sql = $"update tbl_NghiPhepNam set LoaiPhepNghi = '{cbo_loaiphep.SelectedValue.ToString()}', " +
                                    $"NgayNghi='{cbo_Nam.Text + cbo_Thang.Text.PadLeft(2, '0') + item.ToString().PadLeft(2, '0')}', " +
                                    $"GhiChu='{txt_noidung.Text}'," +
                                    $"SoNgay='{(nuangay != 0 ? "0.5" : "1")}', " +
                                    $"NgayCapNhat = GETDATE(),Nam = '{cbo_Nam.Text}'," +
                                    $"NguoiTao = '{SQLHelper.sIdUser}', " +
                                    $"NuaNgay = '{nuangay}'," +
                                    $"Chk_ToTruong = '{(chk_ToTruong.Checked == true ? 1 : 0)}', " +
                                    $"Chk_QuanLy = '{(chk_quanly.Checked == true ? 1 : 0)}', Chk_NhanSu = '{(chk_nhansu.Checked == true ? 1 : 0)}' " +
                                    $"where id = '{_id_nghi_phep_value}'";
                        SQLHelper.ExecuteSql(sql);
                    }
                    catch (Exception ex)
                    {
                        throw new Exception(ex.Message);
                    }
                }
                RJMessageBox.Show("Cập nhật thành công", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                RJMessageBox.Show(ex.Message, "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
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
            if(senderComboBox.SelectedValue.ToString() == "LP002" || senderComboBox.SelectedValue.ToString() == "LP001")
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
