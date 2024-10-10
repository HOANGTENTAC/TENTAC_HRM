using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using TENTAC_HRM.Custom;

namespace TENTAC_HRM.Category
{
    public partial class frm_relatives : Form
    {
        string quanhe_value, hoten_value, ngaysinh_value, namsinh_value, nghenghiep_value, noicutru_value, ghichu_value,
            masothue_value, cccd_value, quoctich_value, ks_so_value, ks_quyen_value, ks_quocgia_value, ks_tinh_value,
            ks_quan_value, ks_phuong_value, tuthang_value, denthang_value, ngaytao_value, nguoitao_value,
            dien_thoai_value,di_dong_value,gioitinh_value;

        private void txt_dien_thoai_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!IsValidNumber(e.KeyChar))
            {
                e.Handled = true;
                return;
            }
        }

        private void frm_relatives_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
            {
                this.Close();
            }
        }

        private void txt_di_dong_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!IsValidNumber(e.KeyChar))
            {
                e.Handled = true;
                return;
            }
        }

        private void txt_ma_so_thue_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!IsValidNumber(e.KeyChar))
            {
                e.Handled = true;
                return;
            }
        }

        private void txt_cccd_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!IsValidNumber(e.KeyChar))
            {
                e.Handled = true;
                return;
            }
        }
        protected virtual bool IsValidNumber(char c)
        {
            return (c >= '0' && c <= '9') || (c == (char)Keys.Back) || (c == (char)Keys.Delete);
        }
        private void txt_ho_ten_Leave(object sender, EventArgs e)
        {
            txt_ho_ten.Text = provider.viet_hoa_chu_cai_dau(txt_ho_ten.Text);
        }

        int is_phuthuoc_value;
        public string _ma_nhan_vien { get; set; }
        public string id_nguoithan_value { get; set; }
        public bool edit { get; set; }
        DataProvider provider = new DataProvider();
        frm_personnel personnel;
        public frm_relatives(frm_personnel _personnel)
        {
            InitializeComponent();
            this.personnel = _personnel;
        }

        private void frm_relatives_Load(object sender, EventArgs e)
        {
            loai_quanhe();
            load_gender();
            load_nhanvien();
            if (edit == true)
            {
                btn_save_add.Text = "Cập nhật";
                btn_save_close.Text = "Cập nhật & Thoát";
                loai_data();
            }
        }
        private void load_nhanvien()
        {
            cbo_nhanvien.DataSource = provider.load_nhanvien();
            cbo_nhanvien.DisplayMember = "name";
            cbo_nhanvien.ValueMember = "value";
            cbo_nhanvien.SelectedValue = _ma_nhan_vien;
        }
        private void loai_data()
        {
            string sql = string.Format("select * from hrm_nhanvien_nguoithan where id_nguoi_than = {0}",id_nguoithan_value);
            DataTable dt = new DataTable();
            dt = SQLHelper.ExecuteDt(sql);
            if(dt.Rows.Count > 0)
            {
                cbo_loai_quan_he.SelectedValue = dt.Rows[0]["loai_quan_he"].ToString();
                txt_ho_ten.Text = dt.Rows[0]["ho_ten"].ToString();
                dtp_ngay_sinh.Text = dt.Rows[0]["ngaysinh"].ToString();
                txt_nghe_nghiep.Text = dt.Rows[0]["nghe_nghiep"].ToString();
                txt_noi_cu_tru.Text = dt.Rows[0]["noi_cu_tru"].ToString();
                txt_ghi_chu.Text = dt.Rows[0]["ghi_chu"].ToString();
                chk_is_phu_thuoc.Checked = bool.Parse(dt.Rows[0]["is_phu_thuoc"].ToString());
                txt_ma_so_thue.Text = dt.Rows[0]["ma_so_thue"].ToString();
                txt_cccd.Text = dt.Rows[0]["cccd"].ToString();
                txt_quoc_tich.Text = dt.Rows[0]["quoc_tich"].ToString();
                txt_so.Text = dt.Rows[0]["ks_so"].ToString();
                txt_quyen.Text = dt.Rows[0]["ks_quyen"].ToString();
                txt_quoc_gia.Text = dt.Rows[0]["ks_quoc_gia"].ToString();
                txt_tinh.Text = dt.Rows[0]["ks_tinh"].ToString();
                txt_quan.Text = dt.Rows[0]["ks_huyen"].ToString();
                txt_phuong.Text = dt.Rows[0]["ks_xa"].ToString();
                dtp_tu_thang.Text = dt.Rows[0]["tu_thang"].ToString();
                dtp_den_thang.Text = dt.Rows[0]["den_thang"].ToString();
                txt_dien_thoai.Text = dt.Rows[0]["dien_thoai"].ToString();
                txt_di_dong.Text = dt.Rows[0]["di_dong"].ToString();
                cbo_gioi_tinh.SelectedValue = (dt.Rows[0]["gioi_tinh"].ToString() == "True" ? 1 : 0);
            }
        }
        private void loai_quanhe()
        {
            cbo_loai_quan_he.DataSource = provider.load_all_type(80);
            cbo_loai_quan_he.DisplayMember = "name";
            cbo_loai_quan_he.ValueMember = "id";
        }
        private void load_gender()
        {
            cbo_gioi_tinh.DataSource = provider.load_gioitinh();
            cbo_gioi_tinh.DisplayMember = "name";
            cbo_gioi_tinh.ValueMember = "id";

        }
        private void btn_close_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btn_save_add_Click(object sender, EventArgs e)
        {
            if(edit == true)
            {
                update_data();
            }
            else
            {
                save_data();
            } 
        }
        private void update_data()
        {
            try
            {
                load_value_text();
                string sql = string.Format("update hrm_nhanvien_nguoithan " +
                "set loai_quan_he = {1},ho_ten = N'{2}',nam_sinh = '{3}',nghe_nghiep = N'{4}',noi_cu_tru = N'{5}'," +
                "is_phu_thuoc = {6},ngaysinh = '{7}', tu_thang = '{8}',den_thang = '{9}',ma_so_thue = '{10}',cccd = '{11}',quoc_tich = N'{12}'," +
                "ks_so = '{13}',ks_quyen = '{14}',ks_quoc_gia = N'{15}',ks_tinh = N'{16}',ks_huyen = N'{17}',ks_xa = N'{18}',ghi_chu = N'{19}'," +
                "dien_thoai = '{20}',di_dong = '{21}',gioi_tinh = '{22}',ngay_cap_nhat = GETDATE() " +
                "where id_nguoi_than = {0}", id_nguoithan_value, quanhe_value, hoten_value, namsinh_value, nghenghiep_value, noicutru_value,
                is_phuthuoc_value, ngaysinh_value, tuthang_value, denthang_value, masothue_value, cccd_value, quoctich_value,
                ks_so_value, ks_quyen_value, ks_quocgia_value, ks_tinh_value, ks_quan_value, ks_phuong_value, ghichu_value,dien_thoai_value,di_dong_value,gioitinh_value);
                if (SQLHelper.ExecuteSql(sql) == 1)
                {
                    RJMessageBox.Show("Thêm thành công", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    personnel.load_nguoithan();
                }
            }
            catch(Exception ex)
            {
                RJMessageBox.Show(ex.Message, "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void save_data()
        {
            try
            {
                load_value_text();
                string sql = string.Format("insert into hrm_nhanvien_nguoithan(manhanvien,loai_quan_he,hoten,nam_sinh,nghe_nghiep,noi_cu_tru,is_phu_thuoc,ngaysinh,tu_thang,den_thang, " +
                "ma_so_thue,cccd,quoc_tich,ks_so,ks_quyen,ks_quoc_gia,ks_tinh,ks_huyen,ks_xa,ghi_chu,ngay_tao,id_nguoi_tao,dien_thoai,di_dong,gioi_tinh) " +
                "values('{0}',{1},N'{2}','{3}',N'{4}',N'{5}',{6},'{7}','{8}','{9}'," +
                "'{10}','{11}',N'{12}',N'{13}','{14}',N'{15}',N'{16}',N'{17}',N'{18}'," +
                "N'{19}','{20}','{21}','{22}','{23}','{24}')",
                _ma_nhan_vien, quanhe_value, hoten_value, namsinh_value, nghenghiep_value, noicutru_value, is_phuthuoc_value, ngaysinh_value, tuthang_value, denthang_value,
                masothue_value, cccd_value, quoctich_value, ks_so_value, ks_quyen_value, ks_quocgia_value, ks_tinh_value,
                ks_quan_value, ks_phuong_value, ghichu_value, ngaytao_value, nguoitao_value,dien_thoai_value,di_dong_value,gioitinh_value);
                if (SQLHelper.ExecuteSql(sql) == 1)
                {
                    RJMessageBox.Show("Thêm thành công", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    personnel.load_nguoithan();
                }
            }
            catch (Exception ex)
            {
                RJMessageBox.Show(ex.Message, "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void load_value_text()
        {
            quanhe_value = cbo_loai_quan_he.SelectedValue.ToString();
            hoten_value = txt_ho_ten.Text;
            ngaysinh_value = dtp_ngay_sinh.Value.ToString("yyyy/MM/dd");
            namsinh_value = DateTime.Parse(dtp_ngay_sinh.Text.ToString()).ToString("yyyy");
            nghenghiep_value = txt_nghe_nghiep.Text.ToString();
            noicutru_value = txt_noi_cu_tru.Text.ToString();
            ghichu_value = txt_ghi_chu.Text.ToString();
            is_phuthuoc_value = (chk_is_phu_thuoc.Checked == true ? 1 : 0);
            masothue_value = txt_ma_so_thue.Text;
            cccd_value = txt_cccd.Text;
            quoctich_value = txt_quoc_gia.Text;
            ks_so_value = txt_so.Text;
            ks_quyen_value = txt_quyen.Text;
            ks_quocgia_value = txt_quoc_gia.Text;
            ks_tinh_value = txt_tinh.Text;
            ks_quan_value = txt_quan.Text;
            ks_phuong_value = txt_phuong.Text;
            tuthang_value = dtp_tu_thang.Value.ToString("yyyy/MM/dd");
            denthang_value = dtp_den_thang.Value.ToString("yyyy/MM/dd");
            ngaytao_value = DateTime.Now.ToString("yyyy/MM/dd");
            nguoitao_value = SQLHelper.sIdUser;
            dien_thoai_value = txt_dien_thoai.Text;
            di_dong_value = txt_di_dong.Text;
            gioitinh_value = cbo_gioi_tinh.SelectedValue.ToString();
        }
    }
}
