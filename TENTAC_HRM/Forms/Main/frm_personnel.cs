using System;
using System.ComponentModel;
using System.Data;
using System.Data.Entity.Core.Common.CommandTrees.ExpressionBuilder;
using System.Data.SqlClient;
using System.Drawing;
using System.Drawing.Imaging;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text.RegularExpressions;
using System.Windows.Forms;
using TENTAC_HRM.Category;
using TENTAC_HRM.Custom;
using TENTAC_HRM.Model;
using TENTAC_HRM.Properties;
using TENTAC_HRM.User_control;

namespace TENTAC_HRM
{
    public partial class frm_personnel : Form
    {
        DataProvider provider = new DataProvider();
        Nhanvien_model nhanvien = new Nhanvien_model();
        public string _ma_nhan_vien { get; set; }
        public bool status_frm { get; set; }
        public int _id_hop_dong = 0;
        uc_nhan_su nhan_su;
        public frm_personnel(uc_nhan_su ns)
        {
            InitializeComponent();
            nhan_su = ns;
        }

        private void frm_personnel1_Load(object sender, EventArgs e)
        {
            txt_ma_so.Focus();
            item_menustrip();
            load_cbo_nation();
            load_cbo_religion();
            load_gender();
            load_nationality();
            load_trang_thai();
            load_ngan_hang();
            load_nhom_mau();

            if (status_frm == true)
            {
                btn_que_quan.Enabled = true;
                btn_thuong_tru.Enabled = true;
                pl_don_vi.Enabled = true;
                pl_hop_dong.Enabled = true;
                pl_bao_hiem.Enabled = true;
                pl_luong.Enabled = true;
                pl_phu_cap.Enabled = true;
                pl_chuyen_mon.Enabled = true;
                pl_ngoai_ngu.Enabled = true;
                pl_tin_hoc.Enabled = true;
                pl_banthan.Enabled = true;
                pl_giadinh.Enabled = true;
                pl_taisan.Enabled = true;
                tc_qtlv.Enabled = true;

                string sql = string.Format("select * from hrm_nhan_vien where ma_nhan_vien = '{0}'", _ma_nhan_vien);
                DataTable dt = new DataTable();
                dt = SQLHelper.ExecuteDt(sql);
                txt_ma_so.Text = dt.Rows[0]["ma_nhan_vien"].ToString();
                txt_ho_lot.Text = dt.Rows[0]["ho_lot"].ToString();
                txt_ten.Text = dt.Rows[0]["ten"].ToString();
                dtp_ngay_sinh.Text = dt.Rows[0]["ngay_sinh"].ToString();
                cbo_gioi_tinh.SelectedValue = (dt.Rows[0]["gioi_tinh"].ToString() == "True" ? 1 : 0);
                if (dt.Rows[0]["hon_nhan"].ToString() == "0")
                {
                    rb_docthan.Checked = true;
                }
                else
                {
                    rb_dakethon.Checked = true;
                    btn_honnhan.Enabled = true;
                }
                cbo_trang_thai.SelectedValue = dt.Rows[0]["id_trang_thai"].ToString();
                cbo_dan_toc.SelectedValue = dt.Rows[0]["id_dan_toc"].ToString();
                cbo_ton_giao.SelectedValue = dt.Rows[0]["id_ton_giao"].ToString();
                txt_cccd.Text = dt.Rows[0]["so_cccd"].ToString();
                dtp_ngay_cap_cccd.Text = dt.Rows[0]["ngay_cap_cccd"].ToString();
                txt_noi_cap_cc.Text = dt.Rows[0]["noi_cap_cccd"].ToString();
                txt_ho_chieu.Text = dt.Rows[0]["so_ho_chieu"].ToString();
                if (dt.Rows[0]["ngay_het_han_ho_chieu"].ToString() != "")
                {
                    dtp_ngay_cap_hc.Text = dt.Rows[0]["ngay_cap_ho_chieu"].ToString();
                }
                else
                {
                    dtp_ngay_cap_hc.CustomFormat = " ";
                }
                txt_noi_cap_hc.Text = dt.Rows[0]["noi_cap_ho_chieu"].ToString();
                if (dt.Rows[0]["ngay_het_han_ho_chieu"].ToString() != "")
                {
                    dtp_het_han_hc.Text = dt.Rows[0]["ngay_het_han_ho_chieu"].ToString();
                }
                else
                {
                    dtp_het_han_hc.CustomFormat = " ";
                }
                cbo_quoc_tich.SelectedValue = dt.Rows[0]["id_quoc_tich"].ToString();
                txt_di_dong.Text = dt.Rows[0]["dien_thoai_dd"].ToString();
                txt_email.Text = dt.Rows[0]["email"].ToString();
                dtp_ngay_vao_lam.Text = dt.Rows[0]["ngay_vao_lam"].ToString();
                dtp_ngay_ket_thuc_lam.Text = dt.Rows[0]["ngay_ket_thuc"].ToString();
                dtp_ngay_thu_viec.Text = dt.Rows[0]["ngay_thu_viec"].ToString();
                dtp_ngay_ket_thuc_tv.Text = dt.Rows[0]["ngay_ket_thuc_thu_viec"].ToString();
                txt_ghi_chu.Text = dt.Rows[0]["ghi_chu"].ToString();
                txt_ma_so_thue.Text = dt.Rows[0]["ma_so_thue"].ToString();
                dtp_ngay_dk_thue.Text = dt.Rows[0]["ngay_dk_thue"].ToString();
                txt_noi_dk_thue.Text = dt.Rows[0]["noi_dk_thue"].ToString();
                txt_sotk.Text = dt.Rows[0]["so_tk"].ToString();
                txt_ngan_hang_nhan.Text = dt.Rows[0]["ngan_hang"].ToString();
                cbo_ngan_hang.SelectedValue = dt.Rows[0]["id_ngan_hang_ck"].ToString();
                txt_work_permit.Text = dt.Rows[0]["work_permit"].ToString();
                if (dt.Rows[0]["ngay_het_han_ho_chieu"].ToString() != "")
                {
                    dtp_ngay_cap_workpermit.Text = dt.Rows[0]["ngay_cap_wp"].ToString();
                }
                else
                {
                    dtp_ngay_cap_workpermit.CustomFormat = " ";
                }
                if (dt.Rows[0]["ngay_het_han_ho_chieu"].ToString() != "")
                {
                    dtp_ngay_het_workpermit.Text = dt.Rows[0]["ngay_het_han_wp"].ToString();
                }
                else
                {
                    dtp_ngay_het_workpermit.CustomFormat = " ";
                }
                chk_khong_cu_tru.Checked = dt.Rows[0]["ca_nhan_khong_cu_tru"].ToString() == "1" ? true : false;
                chk_khong_uy_quyen.Checked = dt.Rows[0]["khong_uy_quyen_qt"].ToString() == "1" ? true : false;
                chk_tien_mat.Checked = dt.Rows[0]["nhan_tien_mat"].ToString() == "1" ? true : false;
                txt_chieu_cao.Text = dt.Rows[0]["chieu_cao"].ToString();
                txt_can_nang.Text = dt.Rows[0]["can_nang"].ToString();
                cbo_nhom_mau.SelectedValue = dt.Rows[0]["nhom_mau"].ToString();
                txt_luu_y_sk.Text = dt.Rows[0]["Luu_y_sk"].ToString();
                chk_khuyet_tat.Checked = string.IsNullOrEmpty(dt.Rows[0]["khuyet_tat"].ToString()) ? false : bool.Parse(dt.Rows[0]["khuyet_tat"].ToString());
                if (!string.IsNullOrEmpty(dt.Rows[0]["hinh_anh"].ToString()))
                {
                    Byte[] byteanh_nv = new Byte[0];
                    byteanh_nv = (Byte[])(dt.Rows[0]["hinh_anh"]);
                    MemoryStream stmBLOBData = new MemoryStream(byteanh_nv);
                    pb_avata.Image = Image.FromStream(stmBLOBData);
                }
                load_diachi();
                load_phongban();
                load_hopdong();
                load_baohiem();
                load_chuyenmon();
                load_ngoaingu();
                load_tinhoc();
                load_tieusu();
                load_nguoithan();
                load_phucap();
                load_luong();
                Load_congtac();
                Load_khenthuong();
                Load_kyluat();
                load_tainan();
                load_taisan();
                load_thaisan();
                load_danhgia();
                load_nghiviec();
                load_daotao();
                load_reportto();
            }
        }
        #region load_data        
        private void load_reportto()
        {
            cbo_reportto.DataSource = provider.load_report_to();
            cbo_reportto.DisplayMember = "name";
            cbo_reportto.ValueMember = "id";
        }
        public void load_nghiviec()
        {
            string sql = string.Format("select id_qt_nghiviec,tu_ngay,den_ngay,ngay_quyet_dinh,so_quyet_dinh,noi_dung,type_name as loai_nghi_viec " +
                "from hrm_qt_nghiviec a join sys_all_type b on a.loai_nghi_viec = b.type_id where a.ma_nhan_vien = '{0}'", _ma_nhan_vien);
            dgv_qt_nghiviec.DataSource = SQLHelper.ExecuteDt(sql);
        }
        public void load_daotao()
        {
            string sql = string.Format("select id_qt_daotao,tu_ngay,den_ngay,so_quyet_dinh,noi_dung,hinh_thuc from hrm_qt_daotao where ma_nhan_vien = '{0}'", _ma_nhan_vien);
            dgv_qt_daotao.DataSource = SQLHelper.ExecuteDt(sql);
        }
        public void load_danhgia()
        {
            string sql = string.Format("select id_qt_danhgia,ngay_danh_gia,noi_dung,diem_danh_gia,xep_loai from hrm_qt_danhgia where ma_nhan_vien = '{0}'", _ma_nhan_vien);
            dgv_qt_danhgia.DataSource = SQLHelper.ExecuteDt(sql);
        }
        public void load_thaisan()
        {
            string sql = string.Format("select tu_ngay,den_ngay,ghi_chu from hrm_nhanvien_thaisan where ma_nhan_vien = '{0}'", _ma_nhan_vien);
            dgv_thaisai.DataSource = SQLHelper.ExecuteDt(sql);
        }
        public void load_taisan()
        {
            string sql = string.Format("select a.id_nhanvien_taisan,a.so_phieu,a.ngay_vao_so,a.dien_giai,a.tu_ngay as tu_ngay_ts,a.den_ngay as den_ngay_ts " +
                "from nhanvien_taisan a where ma_nhan_vien = '{0}' and del_flg = 0", _ma_nhan_vien);
            DataTable dt = new DataTable();
            dt = SQLHelper.ExecuteDt(sql);
            dgv_taisan.DataSource = dt;
        }
        public void load_tainan()
        {
            string sql = string.Format("select a.id_qt_tainan,b.type_name as ten_tai_nan,c.type_name as muc_do,ngay_dien_ra,noi_dien_ra,noi_dung " +
                "from hrm_qt_tainan a " +
                "join sys_all_type b on a.id_ten_tai_nan = b.type_id " +
                "join sys_all_type c on a.id_muc_do = c.type_id " +
                "where ma_nhan_vien = '{0}' and a.del_flg = 0", _ma_nhan_vien);
            DataTable dt = new DataTable();
            dt = SQLHelper.ExecuteDt(sql);
            dgv_tainan.DataSource = dt;
        }
        public void Load_kyluat()
        {
            string sql = string.Format("select id_qt_kyluat,ngay_ky_luat as ngay_ky_luat_kl,so_quyet_dinh as so_quyet_dinh_kl," +
                "noi_dung as noi_dung_kl,hinh_thuc as hinh_thuc_kl, so_tien as so_tien_kl,ly_do as ly_do_kl " +
                "from hrm_qt_kyluat " +
                "where ma_nhan_vien = '{0}' and del_flg = 0", _ma_nhan_vien);
            DataTable dt = new DataTable();
            dt = SQLHelper.ExecuteDt(sql);
            dgv_kyluat.DataSource = dt;
        }
        public void Load_congtac()
        {
            string sql = string.Format("select id_qt_congtac,tu_ngay,den_ngay,so_quyet_dinh," +
                "dia_diem,noi_dung from hrm_qt_congtac where ma_nhan_vien = '{0}' and del_flg = 0", _ma_nhan_vien);
            DataTable dt = new DataTable();
            dt = SQLHelper.ExecuteDt(sql);
            dgv_congtac.DataSource = dt;
        }
        public void Load_khenthuong()
        {
            string sql = string.Format("select id_qt_khenthuong,ngay_khen_thuong as ngay_khen_thuong_kt,so_quyet_dinh as so_quyet_dinh_kt," +
                "noi_dung as noi_dung_kt,hinh_thuc as hinh_thuc_kt, so_tien as so_tien_kt,ly_do as ly_do_kt " +
                "from hrm_qt_khenthuong " +
                "where ma_nhan_vien = '{0}' and del_flg = 0", _ma_nhan_vien);
            DataTable dt = new DataTable();
            dt = SQLHelper.ExecuteDt(sql);
            dgv_khenthuong.DataSource = dt;
        }
        public void load_luong()
        {
            string sql = string.Format("select * from hrm_nhavien_luong where ma_nhan_vien = '{0}' and del_flg = 0", _ma_nhan_vien);
            DataTable dt = new DataTable();
            dt = SQLHelper.ExecuteDt(sql);
            if (dt.Rows.Count > 0)
            {
                txt_tu_ngay_luong.Text = dt.Rows[0]["tu_ngay"].ToString();
                txt_den_ngay_luong.Text = dt.Rows[0]["den_ngay"].ToString();
                txt_muc_luong.Text = decimal.Parse(dt.Rows[0]["muc_luong"].ToString()).ToString("N0", CultureInfo.InvariantCulture);
                txt_muc_thue.Text = dt.Rows[0]["pt_thue_tncn"].ToString();
                chk_dong_bhxh.Checked = bool.Parse(dt.Rows[0]["is_dong_bhxh"].ToString());
                chk_dong_bhyt.Checked = bool.Parse(dt.Rows[0]["is_dong_bhyt"].ToString());
                chk_dong_bhtn.Checked = bool.Parse(dt.Rows[0]["is_dong_bhtn"].ToString());
                chk_phi_cd.Checked = bool.Parse(dt.Rows[0]["is_dong_kpcd"].ToString());
                chk_mien_dong_thue.Checked = bool.Parse(dt.Rows[0]["is_mien_thue"].ToString());
                chk_phan_tram_thue_thu_nhap.Checked = bool.Parse(dt.Rows[0]["is_thue_co_dinh"].ToString());
            }
        }
        public void load_phucap()
        {
            string sql = string.Format("select a.tu_ngay as tu_ngay_pc,a.den_ngay as den_ngay_pc,b.ten_loai_phu_cap as loai_phu_cap,a.muc_phu_cap " +
                "from hrm_nhanvien_phucap a " +
                "left join hrm_loai_phu_cap b on a.id_loai_phu_cap = b.id_loai_phu_cap " +
                "where a.ma_nhan_vien = '{0}' and is_active = 1 and a.del_flg = 0", _ma_nhan_vien);
            DataTable dt = new DataTable();
            dt = SQLHelper.ExecuteDt(sql);
            if (dt.Rows.Count > 0)
            {
                dgv_phucap.DataSource = dt;
            }
        }
        public void load_diachi()
        {
            string sql_dia_chi = string.Format("select dia_chi,loai_dia_chi from hrm_nhanvien_diachi where ma_nhan_vien = '{0}' and is_active = 1 and del_flg = 0", _ma_nhan_vien);
            DataTable dt_diachi = new DataTable();
            dt_diachi = SQLHelper.ExecuteDt(sql_dia_chi);
            DataRow quequan = dt_diachi.AsEnumerable().Where(x => x.Field<int>("loai_dia_chi") == 41).FirstOrDefault();
            DataRow thuongtru = dt_diachi.AsEnumerable().Where(x => x.Field<int>("loai_dia_chi") == 43).FirstOrDefault();
            txt_que_quan.Text = (quequan != null ? quequan.ItemArray[0].ToString() : "");
            txt_thuong_tru.Text = (thuongtru != null ? thuongtru.ItemArray[0].ToString() : "");
        }
        public void load_nguoithan()
        {
            string sql = string.Format("select id_nguoi_than,b.type_name as moi_quan_he,ho_ten,ngay_sinh,ma_so_thue,cccd,is_phu_thuoc " +
                "from hrm_nhanvien_nguoithan a " +
                "join sys_all_type b on a.loai_quan_he = b.type_id and type_type = 80 " +
                "where a.ma_nhan_vien = '{0}' and a.del_flg = 0", _ma_nhan_vien);
            DataTable dt = new DataTable();
            dt = SQLHelper.ExecuteDt(sql);
            dgv_nguoi_than.DataSource = dt;
        }
        public void load_tieusu()
        {
            string sql = string.Format("select id_tieu_su,tu_nam,den_nam,cong_viec,ten_dia_chi as quoc_gia " +
                "from hrm_nhanvien_tieusu a " +
                "join hrm_dia_chi b on a.id_quoc_gia = b.id_dia_chi and b.id_dia_chi_cha is null " +
                "where ma_nhan_vien = '{0}' and a.del_flg = 0", _ma_nhan_vien);
            DataTable dt = new DataTable();
            dt = SQLHelper.ExecuteDt(sql);
            dgv_tieusu.DataSource = dt;
        }
        public void load_phongban()
        {
            string sql = string.Format("select b.ten_phong_ban as don_vi,c.ten_phong_ban as phong_ban,d.ten_chuc_vu,a.tu_ngay,a.den_ngay " +
                "from nhanvien_phongban a " +
                "left join phong_ban b on a.ma_cong_ty = b.ma_phong_ban " +
                "left join phong_ban c on a.ma_phong_ban = c.ma_phong_ban " +
                "left join chuc_vu d on a.ma_chuc_vu = d.ma_chuc_vu " +
                "where a.is_active = 1 and ma_nhan_vien = '{0}' and a.del_flg = 0", _ma_nhan_vien);
            DataTable dt = new DataTable();
            dt = SQLHelper.ExecuteDt(sql);
            if (dt.Rows.Count > 0)
            {
                txt_donvi.Text = dt.Rows[0]["don_vi"].ToString();
                txt_phongban.Text = dt.Rows[0]["phong_ban"].ToString();
                txt_chucvu.Text = dt.Rows[0]["ten_chuc_vu"].ToString();
                txt_tungay_dv.Text = DateTime.Parse(dt.Rows[0]["tu_ngay"].ToString()).ToString("yyyy/MM/dd");
                txt_denngay_dv.Text = DateTime.Parse(dt.Rows[0]["den_ngay"].ToString()).ToString("yyyy/MM/dd");
            }
        }
        public void load_chuyenmon()
        {
            string sql = string.Format("select b.id_dao_tao,c.ten_bac_dao_tao,d.ten_he_dao_tao,e.ten_nganh_dao_tao,b.truong_dao_tao,tu_ngay,den_ngay,ngay_nhan_bang,xep_loai_bang " +
                "from hrm_nhanvien_daotao b " +
                "left join hrm_bac_dao_tao c on c.id_bac_dao_tao = b.id_bac_dao_tao " +
                "left join hrm_he_dao_tao d on d.id_he_dao_tao = b.id_he_dao_tao " +
                "left join hrm_nganh_dao_tao e on e.id_nganh_dao_tao = b.id_nganh_dao_tao " +
                "where b.loai_dao_tao = 70 and b.ma_nhan_vien = '{0}' and b.del_flg = 0", _ma_nhan_vien);
            DataTable dt = new DataTable();
            dt = SQLHelper.ExecuteDt(sql);
            if (dt.Rows.Count > 0)
            {
                dgv_daotao.DataSource = dt;
            }
        }
        public void load_ngoaingu()
        {
            string sql = string.Format("select id_ngoai_ngu,ngoai_ngu,truong_dao_tao,nam_nhan_bang,b.type_name as xep_loai " +
            "from ngoai_ngu a " +
            "join sys_all_type b on a.xep_loai = b.type_name_short " +
            "where ma_nhan_vien = '{0}' and del_flg = 0", _ma_nhan_vien);
            DataTable dt = new DataTable();
            dt = SQLHelper.ExecuteDt(sql);
            if (dt.Rows.Count > 0)
            {
                dgv_ngoaingu.DataSource = dt;
            }
        }
        public void load_tinhoc()
        {
            string sql = string.Format("select id_tin_hoc,tin_hoc,truong_dao_tao,nam_nhan_bang,b.type_name as xep_loai " +
                "from tin_hoc a " +
                "join sys_all_type b on a.xep_loai = b.type_name_short " +
                "where ma_nhan_vien = '{0}' and del_flg = 0", _ma_nhan_vien);
            DataTable dt = new DataTable();
            dt = SQLHelper.ExecuteDt(sql);
            if (dt.Rows.Count > 0)
            {
                dgv_tinhoc.DataSource = dt;
            }
        }
        public void load_hopdong()
        {
            string sql = string.Format("select b.id_hop_dong,c.ten_loai_hop_dong,b.so_hop_dong,b.tu_ngay,b.den_ngay " +
                "from hrm_nhanvien_hopdong b " +
                "left join hrm_loai_hop_dong c on c.id_loai_hop_dong = b.id_loai_hop_dong " +
                "where b.ma_nhan_vien = '{0}' and b.del_flg = 0", _ma_nhan_vien);
            DataTable dt = new DataTable();
            dt = SQLHelper.ExecuteDt(sql);
            if (dt.Rows.Count > 0)
            {
                _id_hop_dong = int.Parse(dt.Rows[0]["id_hop_dong"].ToString());
                txt_loai_hd.Text = dt.Rows[0]["ten_loai_hop_dong"].ToString();
                txt_so_hd.Text = dt.Rows[0]["so_hop_dong"].ToString();
                txt_tungay_hd.Text = DateTime.Parse(dt.Rows[0]["tu_ngay"].ToString()).ToString("yyyy/MM/dd");
                txt_dengay_hd.Text = DateTime.Parse(dt.Rows[0]["den_ngay"].ToString()).ToString("yyyy/MM/dd");
            }
        }

        public void load_baohiem()
        {
            string sql = string.Format("select so_the,tu_ngay,den_ngay,noi_thuc_hien,ten_dia_chi,loai_bao_hiem " +
                "from hrm_nhanvien_baohiem a " +
                "join sys_all_type b on a.loai_bao_hiem = b.type_id " +
                " left join hrm_dia_chi c on c.id_dia_chi = a.id_tinh and c.loai_dia_chi = 22 " +
                "where a.is_active = 1 and a.ma_nhan_vien = '{0}' and a.del_flg = 0", _ma_nhan_vien);
            DataTable dt = new DataTable(sql);
            dt = SQLHelper.ExecuteDt(sql);
            if (dt.Rows.Count > 0)
            {
                DataRow data_bhxh = dt.AsEnumerable().Where(x => x.Field<int>("loai_bao_hiem") == 50).FirstOrDefault();
                if (data_bhxh != null)
                {
                    txt_so_bhxh.Text = data_bhxh.ItemArray[0].ToString().ToString();
                    txt_ngay_dk_bhxh.Text = DateTime.Parse(data_bhxh.ItemArray[1].ToString()).ToString("yyyy/MM/dd");
                    txt_diem_dk.Text = data_bhxh.ItemArray[3].ToString().ToString();
                    txt_tinh_bhxh.Text = data_bhxh.ItemArray[4].ToString().ToString();
                }

                DataRow data_bhyt = dt.AsEnumerable().Where(x => x.Field<int>("loai_bao_hiem") == 51).FirstOrDefault();
                if (data_bhyt != null)
                {
                    txt_so_bhyt.Text = data_bhyt.ItemArray[0].ToString().ToString();
                    txt_tu_ngay_bhyt.Text = DateTime.Parse(data_bhyt.ItemArray[1].ToString()).ToString("yyyy/MM/dd");
                    txt_den_ngay_bhyt.Text = DateTime.Parse(data_bhyt.ItemArray[2].ToString()).ToString("yyyy/MM/dd");
                    txt_diem_dk_bhyt.Text = data_bhyt.ItemArray[3].ToString().ToString();
                    txt_tinh_bhyt.Text = data_bhyt.ItemArray[4].ToString().ToString();
                }
            }
        }

        private void btn_add_story_Click(object sender, EventArgs e)
        {
            frm_story frm = new frm_story(this);
            frm._ma_nhan_vien = _ma_nhan_vien;
            frm.ShowDialog();
        }

        #endregion
        #region combobox
        private void load_nhom_mau()
        {
            DataTable datatable = new DataTable();
            datatable.Columns.Add("id");
            datatable.Columns.Add("name");
            datatable.Rows.Add("A", "A");
            datatable.Rows.Add("B", "B");
            datatable.Rows.Add("AB", "AB");
            datatable.Rows.Add("O", "O");
            cbo_nhom_mau.DataSource = datatable;
            cbo_nhom_mau.DisplayMember = "name";
            cbo_nhom_mau.ValueMember = "id";
        }
        private void load_cbo_nation()
        {
            string sql = "select * from hrm_DAN_TOC";
            DataTable dt = new DataTable();
            dt = SQLHelper.ExecuteDt(sql);
            cbo_dan_toc.DataSource = dt.Rows.Cast<DataRow>().OrderBy(x => x.Field<int>("ID_DAN_TOC")).CopyToDataTable(); ;
            cbo_dan_toc.DisplayMember = "TEN_DAN_TOC";
            cbo_dan_toc.ValueMember = "ID_DAN_TOC";
        }
        private void load_cbo_religion()
        {
            string sql = "select * from hrm_TON_GIAO";
            DataTable dt = new DataTable();
            dt = SQLHelper.ExecuteDt(sql);
            cbo_ton_giao.DataSource = dt.Rows.Cast<DataRow>().OrderBy(x => x.Field<int>("ID_TON_GIAO")).CopyToDataTable(); ;
            cbo_ton_giao.DisplayMember = "TEN_TON_GIAO";
            cbo_ton_giao.ValueMember = "ID_TON_GIAO";
        }

        private void load_gender()
        {
            cbo_gioi_tinh.DataSource = provider.load_gioitinh();
            cbo_gioi_tinh.DisplayMember = "name";
            cbo_gioi_tinh.ValueMember = "id";
        }

        private void load_nationality()
        {
            cbo_quoc_tich.DataSource = provider.load_diachi(20);
            cbo_quoc_tich.DisplayMember = "name";
            cbo_quoc_tich.ValueMember = "id";

        }
        private void load_trang_thai()
        {
            cbo_trang_thai.DataSource = provider.load_all_type(1);
            cbo_trang_thai.DisplayMember = "name";
            cbo_trang_thai.ValueMember = "id";
        }
        private void load_ngan_hang()
        {
            string sql = "select id_ngan_hang,ten_ngan_hang from hrm_ngan_hang";
            DataTable dt = new DataTable();
            dt = SQLHelper.ExecuteDt(sql);
            cbo_ngan_hang.DataSource = dt;
            cbo_ngan_hang.DisplayMember = "ten_ngan_hang";
            cbo_ngan_hang.ValueMember = "id_ngan_hang";
        }
        private void cbo_quoc_tich_SelectedValueChanged(object sender, EventArgs e)
        {
            ComboBox combo = (ComboBox)sender;
            DataRowView vrow = (DataRowView)combo.SelectedItem;
            string row = vrow.Row.ItemArray[1].ToString();
            if (row.Contains("Việt Nam"))
            {
                txt_ho_chieu.Enabled = false;
                dtp_ngay_cap_hc.Enabled = false;
                txt_noi_cap_hc.Enabled = false;
                dtp_het_han_hc.Enabled = false;
                txt_work_permit.Enabled = false;
                dtp_ngay_cap_workpermit.Enabled = false;
                dtp_ngay_het_workpermit.Enabled = false;

                txt_cccd.Enabled = true;
                dtp_ngay_cap_cccd.Enabled = true;
                txt_noi_cap_cc.Enabled = true;
                cbo_dan_toc.Enabled = true;
                cbo_ton_giao.Enabled = true;
            }
            else
            {
                txt_ho_chieu.Enabled = true;
                dtp_ngay_cap_hc.Enabled = true;
                txt_noi_cap_hc.Enabled = true;
                dtp_het_han_hc.Enabled = true;
                txt_work_permit.Enabled = true;
                dtp_ngay_cap_workpermit.Enabled = true;
                dtp_ngay_het_workpermit.Enabled = true;

                txt_cccd.Enabled = false;
                dtp_ngay_cap_cccd.Enabled = false;
                txt_noi_cap_cc.Enabled = false;
                cbo_dan_toc.Enabled = false;
                cbo_ton_giao.Enabled = false;
            }
        }

        #endregion
        #region datetime
        private void dtp_ngay_sinh_ValueChanged(object sender, EventArgs e)
        {
            dtp_ngay_sinh.CustomFormat = "yyyy/MM/dd";

            int now = int.Parse(DateTime.Now.ToString("yyyyMMdd"));
            int dob = int.Parse(dtp_ngay_sinh.Value.ToString("yyyyMMdd"));
            int age = (now - dob) / 10000;
            if (age < 18)
                lb_validate_tuoi.Visible = true;
            else
                lb_validate_tuoi.Visible = false;
            lb_tuoi.Text = age.ToString() + " tuổi";
        }
        private void dtp_ngay_cap_cccd_ValueChanged(object sender, EventArgs e)
        {
            dtp_ngay_cap_cccd.CustomFormat = "yyyy/MM/dd";

            int now = int.Parse(DateTime.Now.ToString("yyyyMMdd"));
            int dob = int.Parse(dtp_ngay_cap_cccd.Value.ToString("yyyyMMdd"));
            int ngay_het_cc = (now - dob) / 10000;
            if (ngay_het_cc >= 10)
            {
                RJMessageBox.Show("Căn cước hết hạn", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }
        private void dtp_ngay_cap_workpermit_ValueChanged(object sender, EventArgs e)
        {
            dtp_ngay_cap_workpermit.CustomFormat = "yyyy/MM/dd";
        }
        private void dtp_ngay_het_workpermit_ValueChanged(object sender, EventArgs e)
        {
            dtp_ngay_het_workpermit.CustomFormat = "yyyy/MM/dd";
        }
        private void dtp_ngay_cap_hc_ValueChanged(object sender, EventArgs e)
        {
            dtp_ngay_cap_hc.CustomFormat = "yyyy/MM/dd";
        }
        private void dtp_het_han_hc_ValueChanged(object sender, EventArgs e)
        {
            dtp_het_han_hc.CustomFormat = "yyyy/MM/dd";
        }
        private void dtp_ngay_vao_lam_ValueChanged(object sender, EventArgs e)
        {
            dtp_ngay_vao_lam.CustomFormat = "yyyy/MM/dd";
        }
        private void dtp_ngay_thu_viec_ValueChanged(object sender, EventArgs e)
        {
            dtp_ngay_thu_viec.CustomFormat = "yyyy/MM/dd";
        }
        private void dtp_ngay_ket_thuc_lam_ValueChanged(object sender, EventArgs e)
        {
            dtp_ngay_ket_thuc_lam.CustomFormat = "yyyy/MM/dd";
        }
        private void dtp_ngay_ket_thuc_tv_ValueChanged(object sender, EventArgs e)
        {
            dtp_ngay_ket_thuc_tv.CustomFormat = "yyyy/MM/dd";
        }

        private void dtp_ngay_dk_thue_ValueChanged(object sender, EventArgs e)
        {
            dtp_ngay_dk_thue.CustomFormat = "yyyy/MM/dd";
        }
        private void dtp_ngay_cap_cccd_KeyDown(object sender, KeyEventArgs e)
        {
            if ((e.KeyCode == Keys.Back) || e.KeyCode == Keys.Delete)
            {
                dtp_ngay_cap_cccd.CustomFormat = " ";
            }
        }
        private void dtp_ngay_sinh_KeyDown(object sender, KeyEventArgs e)
        {
            if ((e.KeyCode == Keys.Back) || e.KeyCode == Keys.Delete)
            {
                dtp_ngay_sinh.CustomFormat = " ";
            }
        }
        private void dtp_ngay_cap_hc_KeyDown(object sender, KeyEventArgs e)
        {
            if ((e.KeyCode == Keys.Back) || e.KeyCode == Keys.Delete)
            {
                dtp_ngay_cap_hc.CustomFormat = " ";
            }
        }
        private void dtp_het_han_hc_KeyDown(object sender, KeyEventArgs e)
        {
            if ((e.KeyCode == Keys.Back) || e.KeyCode == Keys.Delete)
            {
                dtp_het_han_hc.CustomFormat = " ";
            }
        }
        private void dtp_ngay_cap_workpermit_KeyDown(object sender, KeyEventArgs e)
        {
            if ((e.KeyCode == Keys.Back) || e.KeyCode == Keys.Delete)
            {
                dtp_ngay_cap_workpermit.CustomFormat = " ";
            }
        }
        private void dtp_ngay_het_workpermit_KeyDown(object sender, KeyEventArgs e)
        {
            if ((e.KeyCode == Keys.Back) || e.KeyCode == Keys.Delete)
            {
                dtp_ngay_het_workpermit.CustomFormat = " ";
            }
        }

        #endregion
        #region textbox
        private void txt_ho_lot_Leave(object sender, EventArgs e)
        {
            txt_ho_lot.Text = viet_hoa_chu_cai_dau(txt_ho_lot.Text);
        }
        private string viet_hoa_chu_cai_dau(string ky_tu)
        {
            char[] charArray = ky_tu.ToCharArray();
            bool foundSpace = true;
            for (int i = 0; i < charArray.Length; i++)
            {
                //sử dụng phương thức IsLetter() để kiểm tra từng phần tử có phải là một chữ cái
                if (Char.IsLetter(charArray[i]))
                {
                    if (foundSpace)
                    {
                        //nếu phải thì sử dụng phương thức ToUpper() để in hoa ký tự đầu
                        charArray[i] = Char.ToUpper(charArray[i]);
                        foundSpace = false;
                    }
                    else
                    {
                        charArray[i] = Char.ToLower(charArray[i]);
                    }
                }
                else
                {
                    foundSpace = true;
                }
            }
            return new string(charArray);
        }
        private void txt_ma_so_Leave(object sender, EventArgs e)
        {
            txt_ma_so.Text = txt_ma_so.Text.ToUpper();
        }

        private void txt_ten_Leave(object sender, EventArgs e)
        {
            txt_ten.Text = viet_hoa_chu_cai_dau(txt_ten.Text);
        }
        private void txt_cccd_TextChanged(object sender, EventArgs e)
        {
            if (txt_cccd.Text.Length == 3)
            {
                string sql = string.Format("SELECT ma_dia_chi,ten_dia_chi FROM [TENTAC_HRM].[dbo].[hrm_dia_chi] where id_dia_chi_cha = 1 and ma_dia_chi = {0}", txt_cccd.Text);
                DataTable dt = new DataTable();
                dt = SQLHelper.ExecuteDt(sql);
                if (dt.Rows.Count == 0)
                {
                    RJMessageBox.Show("Địa chỉ này không tồn tại", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else if (txt_cccd.Text.Length == 4)
            {
                int resual_gioi_tinh = 0;
                int ma_gioi_tinh = int.Parse(cbo_gioi_tinh.SelectedValue.ToString());
                string the_ky = dtp_ngay_sinh.Value.ToString("yyyy");
                if (int.Parse(the_ky) >= 1990 && int.Parse(the_ky) <= 1999)
                {
                    if (ma_gioi_tinh == 0)
                    {
                        resual_gioi_tinh = 0;
                    }
                    else
                    {
                        resual_gioi_tinh = 1;
                    }
                }
                else if (int.Parse(the_ky) >= 2000 && int.Parse(the_ky) <= 2099)
                {
                    if (ma_gioi_tinh == 0)
                    {
                        resual_gioi_tinh = 2;
                    }
                    else
                    {
                        resual_gioi_tinh = 3;
                    }
                }
                else if (int.Parse(the_ky) >= 2100 && int.Parse(the_ky) <= 2199)
                {
                    if (ma_gioi_tinh == 0)
                    {
                        resual_gioi_tinh = 4;
                    }
                    else
                    {
                        resual_gioi_tinh = 5;
                    }
                }
                if (resual_gioi_tinh != int.Parse(txt_cccd.Text[3].ToString()))
                {
                    RJMessageBox.Show("Mã giới tính không hợp lệ", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else if (txt_cccd.Text.Length == 6)
            {
                string nam_sinh = dtp_ngay_sinh.Value.ToString("yy");
                if (txt_cccd.Text.Substring(4, 2).ToString() != nam_sinh)
                {
                    RJMessageBox.Show("Mã năm sinh không hợp lệ", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void txt_cccd_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!provider.IsValidNumber(e.KeyChar))
            {
                e.Handled = true;
                return;
            }
        }
        private void txt_ma_cham_cong_KeyPress(object sender, KeyPressEventArgs e)
        {
            TextBox textBox = (TextBox)sender;
            string text = textBox.Text + e.KeyChar;
            if (!provider.IsValidChar(e.KeyChar) || (text.Length == 1 && e.KeyChar.ToString() == "0"))
            {
                e.Handled = true;
                return;
            }
        }
        private void txt_ma_cham_cong_TextChanged(object sender, EventArgs e)
        {
            string text = ((TextBox)sender).Text;
            string resual = "";
            for (int i = 0; i < text.Length; i++)
            {
                if (text[i].ToString() == "0" && i == 0)
                {
                    resual = "";
                }
                else
                {
                    resual = resual + text[i];
                }
            }
            txt_ma_cham_cong.Text = resual;
        }
        private void txt_ma_so_Validating(object sender, CancelEventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txt_ma_so.Text))
            {
                e.Cancel = true;
                txt_ma_so.Focus();
                errorProvider1.SetError(txt_ma_so, "Name should not be left blank!");
            }
            else
            {
                e.Cancel = false;
                errorProvider1.SetError(txt_ma_so, "");
            }
        }
        private void txt_chieu_cao_KeyPress(object sender, KeyPressEventArgs e)
        {
            event_keypress(e);
        }
        private void txt_email_Leave(object sender, EventArgs e)
        {
            Regex mRegxExpression;
            if (txt_email.Text.Trim() != string.Empty)
            {
                mRegxExpression = new Regex(@"^([a-zA-Z0-9_\-])([a-zA-Z0-9_\-\.]*)@(\[((25[0-5]|2[0-4][0-9]|1[0-9][0-9]|[1-9][0-9]|[0-9])\.){3}|((([a-zA-Z0-9\-]+)\.)+))([a-zA-Z]{2,}|(25[0-5]|2[0-4][0-9]|1[0-9][0-9]|[1-9][0-9]|[0-9])\])$");

                if (!mRegxExpression.IsMatch(txt_email.Text.Trim()))
                {
                    errorProvider1.SetError(this.txt_email, "E-mail address format is not correct.");
                    txt_email.Focus();
                }
                else
                {
                    errorProvider1.Clear();
                }
            }
        }

        private void txt_ma_so_TextChanged(object sender, EventArgs e)
        {
            if (txt_ma_so.Text.Length == 2)
            {
                string sql = string.Format("select * from sys_all_type where type_type = 143 and type_name = '{0}'", txt_ma_so.Text);
                DataTable dt = new DataTable();
                dt = SQLHelper.ExecuteDt(sql);
                if (dt.Rows.Count == 0)
                {
                    RJMessageBox.Show("Mã thẻ không hợp lệ", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    txt_ma_so.Focus();
                }
                else
                {
                    string sql1 = "select type_value from sys_all_type where type_id = 143";
                    DataTable dt1 = new DataTable();
                    dt1 = SQLHelper.ExecuteDt(sql1);
                    txt_ma_so.Text = txt_ma_so.Text + (int.Parse(dt1.Rows[0][0].ToString()) + 1);
                }
            }
        }

        private void btn_quoc_tich_Click(object sender, EventArgs e)
        {
            frm_main_uc frm = new frm_main_uc(this);
            frm.title_frm = "Địa chỉ";
            frm.type = "nationality";
            frm.ShowDialog();
        }

        private async void txt_ma_so_thue_Leave(object sender, EventArgs e)
        {
            //var info = await new MSTHelper().GetTaxInfomation(txt_ma_so_thue.Text.Trim(), txt_ho_lot.Text + " " + txt_ten.Text);
            //if (info.susscess)
            //{
            //    dtp_ngay_dk_thue.Text = info.date_actived;
            //    txt_noi_dk_thue.Text = info.by_manager;
            //}
        }

        private void btn_honnhan_Click(object sender, EventArgs e)
        {
            frm_honnhan frm = new frm_honnhan();
            frm._ma_nhan_vien = _ma_nhan_vien;
            frm.ShowDialog();
        }

        private void btn_add_congtac_Click(object sender, EventArgs e)
        {
            frm_congtac frm = new frm_congtac(this, null);
            frm._ma_nhan_vien = _ma_nhan_vien;
            frm.edit = false;
            frm.ShowDialog();
        }
        #endregion
        #region button
        private void btn_bao_hiem_Click(object sender, EventArgs e)
        {
            frm_insurance frm = new frm_insurance(this);
            frm._ma_nhan_vien = _ma_nhan_vien;
            frm.edit = false;
            frm.ShowDialog();
        }
        private void btn_luong_Click(object sender, EventArgs e)
        {
            frm_wage frm = new frm_wage(this);
            frm._ma_nhan_vien = _ma_nhan_vien;
            frm.ShowDialog();
        }

        private void btn_phu_cap_Click(object sender, EventArgs e)
        {
            frm_staff_allowance frm = new frm_staff_allowance(this);
            frm._ma_nhan_vien = _ma_nhan_vien;
            frm.edit = false;
            frm.ShowDialog();
        }

        private void btn_que_quan_Click(object sender, EventArgs e)
        {
            frm_main_uc frm = new frm_main_uc(this);
            frm._ma_nhan_vien = _ma_nhan_vien;
            frm.title_frm = "Nhân viên - Địa chỉ";
            frm.type = "address";
            frm.ShowDialog();
        }
        private void btn_thuong_tru_Click(object sender, EventArgs e)
        {
            frm_main_uc frm = new frm_main_uc(this);
            frm._ma_nhan_vien = _ma_nhan_vien;
            frm.title_frm = "Nhân viên - Địa chỉ";
            frm.type = "address";
            frm.ShowDialog();
        }
        private void btn_close_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        private void btn_phong_ban_Click(object sender, EventArgs e)
        {
            frm_department frm = new frm_department(this);
            frm.edit = false;
            frm._ma_nhan_vien = _ma_nhan_vien;
            frm.ShowDialog();
        }
        private void btn_save_Click(object sender, EventArgs e)
        {
            try
            {
                if (check_validate() == true)
                {
                    if (status_frm == true)
                    {
                        update_ho_so();
                    }
                    else
                    {
                        insert_ho_so();
                    }
                }
            }
            catch (Exception ex)
            {
                RJMessageBox.Show(ex.Message, "Thông báo");
            }
        }
        private void btn_add_nation_Click(object sender, EventArgs e)
        {
            frm_main_uc frm = new frm_main_uc(this);
            frm.title_frm = "Dân tộc";
            frm.type = "nation";
            frm.ShowDialog();
        }

        private void btn_religion_Click(object sender, EventArgs e)
        {
            frm_main_uc frm = new frm_main_uc(this);
            frm.title_frm = "Tôn giáo";
            frm.type = "religion";
            frm.ShowDialog();
        }

        private void btn_hop_dong_Click(object sender, EventArgs e)
        {
            frm_contract frm = new frm_contract(this, null);
            frm._id_hopdong = _id_hop_dong;
            frm.edit = _id_hop_dong == 0 ? false : true;
            frm._ma_nhan_vien = _ma_nhan_vien;
            frm.ShowDialog();
        }
        private void btn_add_dt_Click(object sender, EventArgs e)
        {
            frm_pecialize frm = new frm_pecialize(this);
            frm.edit = false;
            frm._ma_nhan_vien = _ma_nhan_vien;
            frm.ShowDialog();
        }
        private void btn_them_ngoai_ngu_Click(object sender, EventArgs e)
        {
            frm_language frm = new frm_language(this);
            frm.edit = false;
            frm._ma_nhanvien = _ma_nhan_vien;
            frm.ShowDialog();
        }

        private void btn_them_tin_hoc_Click(object sender, EventArgs e)
        {
            frm_computing frm = new frm_computing(this);
            frm.edit = false;
            frm._ma_nhanvien = _ma_nhan_vien;
            frm.ShowDialog();
        }
        private void btn_gia_dinh_Click(object sender, EventArgs e)
        {
            frm_relatives frm = new frm_relatives(this);
            frm.edit = false;
            frm._ma_nhan_vien = _ma_nhan_vien;
            frm.ShowDialog();
        }
        private void btn_delete_Click(object sender, EventArgs e)
        {
            try
            {
                DialogResult result = RJMessageBox.Show("Bạn có chác muốn xóa?", "Thông báo", MessageBoxButtons.YesNo);
                if (result == DialogResult.Yes)
                {
                    string sql = string.Format("update hrm_nhan_vien set del_flg = 1 where ma_nhan_vien = '{0}'", _ma_nhan_vien);
                    if (SQLHelper.ExecuteSql(sql) == 1)
                    {
                        RJMessageBox.Show("Xóa thành công", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
            }
            catch (Exception ex)
            {
                RJMessageBox.Show(ex.Message, "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void btn_xoa_tin_hoc_Click(object sender, EventArgs e)
        {
            try
            {
                DialogResult result = RJMessageBox.Show("Bạn có chác muốn xóa?", "Thông báo", MessageBoxButtons.YesNo);
                if (result == DialogResult.Yes)
                {
                    string sql = string.Format("update tin_hoc set del_flg = 1 where id_tin_hoc = '{0}'", dgv_tinhoc.CurrentRow.Cells["id_tin_hoc"].Value);
                    if (SQLHelper.ExecuteSql(sql) == 1)
                    {
                        RJMessageBox.Show("Xóa thành công", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
            }
            catch (Exception ex)
            {
                RJMessageBox.Show(ex.Message, "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void btn_xoa_ngoai_ngu_Click(object sender, EventArgs e)
        {
            try
            {
                DialogResult result = RJMessageBox.Show("Bạn có chác muốn xóa?", "Thông báo", MessageBoxButtons.YesNo);
                if (result == DialogResult.Yes)
                {
                    string sql = string.Format("update ngoai_ngu set del_flg = 1 where id_ngoai_ngu = '{0}'", dgv_ngoaingu.CurrentRow.Cells["id_ngoai_ngu"].Value);
                    if (SQLHelper.ExecuteSql(sql) == 1)
                    {
                        RJMessageBox.Show("Xóa thành công", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
            }
            catch (Exception ex)
            {
                RJMessageBox.Show(ex.Message, "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void btn_xoa_dao_tao_Click(object sender, EventArgs e)
        {
            try
            {
                DialogResult result = RJMessageBox.Show("Bạn có chác muốn xóa?", "Thông báo", MessageBoxButtons.YesNo);
                if (result == DialogResult.Yes)
                {
                    string sql = string.Format("update hrm_nhanvien_daotao set del_flg = 1 where id_dao_tao = '{0}'", dgv_daotao.CurrentRow.Cells["id_dao_tao"].Value);
                    if (SQLHelper.ExecuteSql(sql) == 1)
                    {
                        RJMessageBox.Show("Xóa thành công", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
            }
            catch (Exception ex)
            {
                RJMessageBox.Show(ex.Message, "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void btn_add_khenthuong_Click(object sender, EventArgs e)
        {
            frm_khenthuong frm = new frm_khenthuong(this, null);
            frm._ma_nhan_vien = _ma_nhan_vien;
            frm.edit = false;
            frm.ShowDialog();
        }
        private void btn_add_kyluat_Click(object sender, EventArgs e)
        {
            frm_nhanvien_kyluat frm = new frm_nhanvien_kyluat(this, null);
            frm._ma_nhan_vien = _ma_nhan_vien;
            frm.edit = false;
            frm.ShowDialog();
        }
        private void btn_tainan_Click(object sender, EventArgs e)
        {
            frm_nhanvien_tainan frm = new frm_nhanvien_tainan(this, null);
            frm._ma_nhan_vien = _ma_nhan_vien;
            frm.edit = false;
            frm.ShowDialog();
        }
        private void btn_taisan_Click(object sender, EventArgs e)
        {
            frm_nhanvien_taisan frm = new frm_nhanvien_taisan(this, null);
            frm._ma_nhan_vien = _ma_nhan_vien;
            frm.edit = false;
            frm.ShowDialog();
        }
        private void btn_thaisan_Click(object sender, EventArgs e)
        {
            frm_thaisan frm = new frm_thaisan(this, null);
            frm._ma_nhan_vien = _ma_nhan_vien;
            frm.edit = false;
            frm.ShowDialog();
        }
        private void btn_danhgia_Click(object sender, EventArgs e)
        {
            frm_danhgia frm = new frm_danhgia(this, null);
            frm._edit = false;
            frm._ma_nhan_vien = _ma_nhan_vien;
            frm.ShowDialog();
        }
        private void btn_daotao_Click(object sender, EventArgs e)
        {
            frm_daotao frm = new frm_daotao(this, null);
            frm._edit = false;
            frm._ma_nhan_vien = _ma_nhan_vien;
            frm.ShowDialog();
        }
        private void btn_nghiviec_Click(object sender, EventArgs e)
        {
            frm_nghiviec frm = new frm_nghiviec(this, null);
            frm._ma_nhan_vien = _ma_nhan_vien;
            frm._edit = false;
            frm.ShowDialog();
        }
        #endregion
        #region datagridview
        private void dgv_tinhoc_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dgv_tinhoc.CurrentCell.OwningColumn.Name == "edit_column_th")
            {
                frm_computing frm = new frm_computing(this);
                frm._ma_nhanvien = _ma_nhan_vien;
                frm._id_tinhoc = int.Parse(dgv_tinhoc.CurrentRow.Cells["id_tin_hoc"].Value.ToString());
                frm.edit = true;
                frm.ShowDialog();
            }
        }

        private void dgv_ngoaingu_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dgv_ngoaingu.CurrentCell.OwningColumn.Name == "edit_column_nn")
            {
                frm_language frm = new frm_language(this);
                frm._ma_nhanvien = _ma_nhan_vien;
                frm._id_ngoaingu = int.Parse(dgv_ngoaingu.CurrentRow.Cells["id_ngoai_ngu"].Value.ToString());
                frm.edit = true;
                frm.ShowDialog();
            }
        }
        private void dgv_tieusu_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dgv_tieusu.CurrentCell.OwningColumn.Name == "edit_column")
            {
                frm_story frm = new frm_story(this);
                frm._ma_nhan_vien = _ma_nhan_vien;
                frm._id_tieusu_value = dgv_tieusu.CurrentRow.Cells["id_tieu_su"].Value.ToString();
                frm.edit = true;
                frm.ShowDialog();
            }
        }

        private void dgv_nguoi_than_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dgv_nguoi_than.CurrentCell.OwningColumn.Name == "edit_column_gd")
            {
                frm_relatives frm = new frm_relatives(this);
                frm._ma_nhan_vien = _ma_nhan_vien;
                frm.id_nguoithan_value = dgv_nguoi_than.CurrentRow.Cells["id_nguoi_than"].Value.ToString();
                frm.edit = true;
                frm.ShowDialog();
            }
        }
        private void dgv_daotao_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dgv_daotao.CurrentCell.OwningColumn.Name == "edit_column_dt")
            {
                frm_pecialize frm = new frm_pecialize(this);
                frm._id_daotao_value = dgv_daotao.CurrentRow.Cells["id_dao_tao"].Value.ToString();
                frm.edit = true;
                frm.ShowDialog();
            }
        }
        private void dgv_congtac_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dgv_congtac.CurrentCell.OwningColumn.Name == "edit_column_ct")
            {
                frm_congtac frm = new frm_congtac(this, null);
                frm._id_congtac = int.Parse(dgv_congtac.CurrentRow.Cells["id_qt_congtac"].Value.ToString());
                frm._ma_nhan_vien = _ma_nhan_vien;
                frm.edit = true;
                frm.ShowDialog();
            }
        }
        private void dgv_khenthuong_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dgv_khenthuong.CurrentCell.OwningColumn.Name == "edit_column_kt")
            {
                frm_khenthuong frm = new frm_khenthuong(this, null);
                frm._id_khenthuong = int.Parse(dgv_khenthuong.CurrentRow.Cells["id_qt_khenthuong"].Value.ToString());
                frm._ma_nhan_vien = _ma_nhan_vien;
                frm.edit = true;
                frm.ShowDialog();
            }
        }
        private void dgv_kyluat_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dgv_kyluat.CurrentCell.OwningColumn.Name == "edit_column_kl")
            {
                frm_nhanvien_kyluat frm = new frm_nhanvien_kyluat(this, null);
                frm._id_qt_kyluat = int.Parse(dgv_kyluat.CurrentRow.Cells["id_qt_kyluat"].Value.ToString());
                frm._ma_nhan_vien = _ma_nhan_vien;
                frm.edit = true;
                frm.ShowDialog();
            }
        }
        private void dgv_qt_nghiviec_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dgv_qt_nghiviec.CurrentCell.OwningColumn.Name == "edit_column_nghiviec")
            {
                frm_nghiviec frm = new frm_nghiviec(this, null);
                frm._edit = true;
                frm._id_nghi_viec = int.Parse(dgv_qt_nghiviec.CurrentRow.Cells["id_qt_nghiviec"].Value.ToString());
                frm.ShowDialog();
            }
        }
        private void dgv_phucap_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dgv_phucap.CurrentCell.OwningColumn.Name == "edit_column_phucap")
            {
                frm_staff_allowance frm = new frm_staff_allowance(this);
                frm._ma_nhan_vien = _ma_nhan_vien;
                frm._id_phucap = dgv_phucap.CurrentRow.Cells["id_phu_cap"].Value.ToString();
                frm.edit = true;
                frm.ShowDialog();
            }
        }

        private void dgv_tainan_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dgv_tainan.CurrentCell.OwningColumn.Name == "edit_column_tn")
            {
                frm_nhanvien_tainan frm = new frm_nhanvien_tainan(this, null);
                frm._ma_nhan_vien = _ma_nhan_vien;
                frm._id_qt_tainan = int.Parse(dgv_tainan.CurrentRow.Cells["id_qt_tainan"].Value.ToString());
                frm.edit = true;
                frm.ShowDialog();
            }
        }
        private void dgv_thaisai_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dgv_thaisai.CurrentCell.OwningColumn.Name == "edit_column_ts")
            {
                frm_thaisan frm = new frm_thaisan(this, null);
                frm._ma_nhan_vien = _ma_nhan_vien;
                frm._id_thai_san = int.Parse(dgv_thaisai.CurrentRow.Cells["id_thai_san"].Value.ToString());
                frm.edit = true;
                frm.ShowDialog();
            }
        }
        private void dgv_taisan_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dgv_taisan.CurrentCell.OwningColumn.Name == "edit_column_taisan")
            {
                frm_nhanvien_taisan frm = new frm_nhanvien_taisan(this, null);
                frm._ma_nhan_vien = _ma_nhan_vien;
                frm._id_nhanvien_taisan = int.Parse(dgv_taisan.CurrentRow.Cells["id_nhanvien_taisan"].Value.ToString());
                frm.edit = true;
                frm.ShowDialog();
            }
        }
        private void dgv_qt_danhgia_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dgv_qt_danhgia.CurrentCell.OwningColumn.Name == "edit_column_danhgia")
            {
                frm_danhgia frm = new frm_danhgia(this, null);
                frm._edit = true;
                frm._id_danh_gia = int.Parse(dgv_qt_danhgia.CurrentRow.Cells["id_qt_danhgia"].Value.ToString());
                frm.ShowDialog();
            }
        }
        private void dgv_qt_daotao_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dgv_qt_daotao.CurrentCell.OwningColumn.Name == "edit_column_daotao")
            {
                frm_daotao frm = new frm_daotao(this, null);
                frm._edit = true;
                frm._ma_nhan_vien = _ma_nhan_vien;
                frm._id_dao_tao = int.Parse(dgv_qt_daotao.CurrentRow.Cells["id_qt_daotao"].Value.ToString());
                frm.ShowDialog();
            }
        }
        #endregion
        private void item_menustrip()
        {
            ContextMenuStrip cm = new ContextMenuStrip();
            cm.Items.Add("Delete");
            cm.Items.Add("Load");

            cm.Items[0].Image = Resources.delete_file;
            cm.Items[1].Image = Resources.open_folder;
            pb_avata.ContextMenuStrip = cm;

            cm.ItemClicked += new ToolStripItemClickedEventHandler(contextmenu_Click);
        }

        Byte[] b = null;
        FileStream Fs = default(FileStream);
        OpenFileDialog open = new OpenFileDialog();
        private void contextmenu_Click(object sender, ToolStripItemClickedEventArgs e)
        {
            switch (e.ClickedItem.Text)
            {
                case "Delete":
                    pb_avata.Image = null;
                    break;
                case "Load":
                    //OpenFileDialog open = new OpenFileDialog();
                    open.Filter = "Image Files(*.jpg; *.jpeg; *.gif; *.bmp; *.png)|*.jpg; *.jpeg; *.gif; *.bmp; *.png" +
                                "|All Files (*.*)|*.*";
                    if (open.ShowDialog() == DialogResult.OK)
                    {
                        Fs = File.Open(open.FileName, FileMode.OpenOrCreate);
                        b = new Byte[Fs.Length];
                        Fs.Read(b, 0, b.Length);
                        Fs.Close();
                        pb_avata.Image = Image.FromFile(open.FileName);
                    }
                    break;
            }
        }
        private void event_keypress(KeyPressEventArgs e)
        {
            if (!provider.IsValidChar(e.KeyChar))
            {
                e.Handled = true;
                return;
            }
            base.OnKeyPress(e);
        }
        private bool check_validate()
        {
            if (string.IsNullOrEmpty(txt_ma_so.Text))
            {
                RJMessageBox.Show("Mã nhân viên không được trống", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txt_ma_so.Focus();
                return false;
            }
            return true;
        }
        private void update_ho_so()
        {
            set_txt_value();
            string sql = "update hrm_nhan_vien " +
                "set id_trang_thai = @trang_thai, ma_nhan_vien = @ma_so,ten = @ten,ho_lot = @ho_lot,ho_ten = @ho_ten, ngay_sinh = @ngay_sinh," +
                "gioi_tinh = @gioi_tinh, hon_nhan = @hon_nhan,id_ton_giao = @ton_giao,id_dan_toc = @dan_toc, id_quoc_tich = @quoc_tich," +
                "so_cccd = @cccd, ngay_cap_cccd = @ngay_cap_cc,noi_cap_cccd = @noi_cap_cc, so_ho_chieu = @so_ho_chieu,ngay_cap_ho_chieu = @ngay_cap_hc," +
                "noi_cap_ho_chieu = @noi_cap_hc,ngay_het_han_ho_chieu = @ngay_het_han_hc," +
                "dien_thoai_dd = @sdt, email = @email," +
                "hinh_anh = @hinh_anh, ghi_chu = @ghi_chu,Ngay_thu_viec = @ngay_thu_viec, thoi_gian_thu_viec = @tg_thu_viec," +
                "ngay_ket_thuc_thu_viec = @ngay_kt_thu_viec, ngay_vao_lam = @ngay_vao_lam, ngay_ket_thuc = @ngay_ket_thuc," +
                "ma_so_thue = @ma_so_thue, ngay_dk_thue = @ngay_dk_thue,noi_dk_thue = @noi_dk_thue," +
                "so_tk = @so_tk, ngan_hang = @ngan_hang,nhan_tien_mat = @tien_mat,ca_nhan_khong_cu_tru = @khong_cu_tru,khong_uy_quyen_qt= @khong_uy_quyen," +
                "id_ngan_hang_ck = @ngan_hang_ck, work_permit = @work_permit, ngay_cap_wp = @ngay_cap_wp,ngay_het_han_wp = @ngay_het_han_wp," +
                "chieu_cao = @chieu_cao, can_nang = @can_nang, nhom_mau = @nhom_mau, suc_khoe = @suc_khoe,luu_y_sk = @luu_y_sk,khuyet_tat = @khuyet_tat," +
                "ngay_cap_nhat = GETDATE(),ma_cham_cong = @ma_cham_cong,ten_cham_cong = @ten_cham_cong, ma_the = @ma_the,id_nguoi_tao = @id_nguoi_tao " +
                "where ma_nhan_vien = @ma_nhan_vien";
            SqlParameter[] param = new SqlParameter[]
            {
                new SqlParameter("@ma_nhan_vien", SqlDbType.VarChar) {Value = _ma_nhan_vien},
                new SqlParameter("@trang_thai", SqlDbType.Int) {Value = nhanvien.Trang_thai_value},
                new SqlParameter("@ma_so", SqlDbType.VarChar) {Value = nhanvien.Ma_so_value},
                new SqlParameter("@ten", SqlDbType.NVarChar) {Value = nhanvien.Ten_value},
                new SqlParameter("@ho_lot", SqlDbType.NVarChar) {Value = nhanvien.Ho_lot_value},
                new SqlParameter("@ho_ten", SqlDbType.NVarChar) {Value = nhanvien.Ho_ten_value},
                new SqlParameter("@ngay_sinh", SqlDbType.Date) {Value = nhanvien.Ngay_sinh_value},
                new SqlParameter("@gioi_tinh", SqlDbType.Bit) {Value = nhanvien.Gioi_tinh_value},
                new SqlParameter("@hon_nhan", SqlDbType.Int) {Value = nhanvien.Hon_nhan_value},
                new SqlParameter("@ton_giao", SqlDbType.Int) {Value = nhanvien.Ton_giao_value},
                new SqlParameter("@dan_toc", SqlDbType.Int) {Value = nhanvien.Dan_toc_value},
                new SqlParameter("@quoc_tich", SqlDbType.Int) {Value = nhanvien.Quoc_tich_value},
                new SqlParameter("@cccd", SqlDbType.VarChar) {Value = nhanvien.Cccd_value},
                new SqlParameter("@ngay_cap_cc", SqlDbType.Date) {Value = nhanvien.Ngay_cap_cccd_value == null ? (object)DBNull.Value : DateTime.Parse(nhanvien.Ngay_cap_cccd_value.Value.ToString("yyyy/MM/dd")),IsNullable = true},
                new SqlParameter("@noi_cap_cc", SqlDbType.NVarChar) {Value = nhanvien.Noi_cap_cccd_value},
                new SqlParameter("@so_ho_chieu", SqlDbType.NVarChar) {Value = nhanvien.So_hc_value},
                new SqlParameter("@ngay_cap_hc", SqlDbType.Date) {Value = nhanvien.Ngay_cap_hc_value == null ? (object)DBNull.Value : DateTime.Parse(nhanvien.Ngay_cap_hc_value.Value.ToString("yyyy/MM/dd")),IsNullable = true},
                new SqlParameter("@noi_cap_hc", SqlDbType.NVarChar) {Value = nhanvien.Noi_cap_hc_value},
                new SqlParameter("@ngay_het_han_hc", SqlDbType.Date) {Value = nhanvien.Ngay_het_han_hc_value == null ? (object)DBNull.Value : DateTime.Parse(nhanvien.Ngay_het_han_hc_value.Value.ToString("yyyy/MM/dd")), IsNullable = true},
                new SqlParameter("@sdt", SqlDbType.VarChar) {Value = nhanvien.Sdt_value},
                new SqlParameter("@email", SqlDbType.VarChar) {Value = nhanvien.Email_value},
                new SqlParameter("@ghi_chu", SqlDbType.NVarChar) {Value = nhanvien.Ghi_chu_value},
                new SqlParameter("@ngay_thu_viec", SqlDbType.Date) {Value = nhanvien.Ngay_tv_value == null ? (object)DBNull.Value : DateTime.Parse(nhanvien.Ngay_tv_value.Value.ToString("yyyy/MM/dd")), IsNullable = true},
                new SqlParameter("@tg_thu_viec", SqlDbType.Int) {Value = nhanvien.Thoi_gan_tv_value},
                new SqlParameter("@ngay_kt_thu_viec", SqlDbType.Date) {Value = nhanvien.Ngay_ket_thuc_tv_value == null ? (object) DBNull.Value : DateTime.Parse(nhanvien.Ngay_ket_thuc_tv_value.Value.ToString("yyyy/MM/dd")), IsNullable = true},
                new SqlParameter("@ngay_vao_lam", SqlDbType.Date) {Value = nhanvien.Ngay_vao_lam_value == null ?(object) DBNull.Value : DateTime.Parse(nhanvien.Ngay_vao_lam_value.Value.ToString("yyyy/MM/dd")), IsNullable = true},
                new SqlParameter("@ngay_ket_thuc", SqlDbType.Date) {Value = nhanvien.Ngay_ket_thuc_value == null ?(object) DBNull.Value : DateTime.Parse(nhanvien.Ngay_ket_thuc_value.Value.ToString("yyyy/MM/dd")), IsNullable = true},
                new SqlParameter("@ma_so_thue", SqlDbType.NVarChar) {Value = nhanvien.Ma_so_thue_value},
                new SqlParameter("@ngay_dk_thue", SqlDbType.Date) {Value = nhanvien.Ngay_dk_thue_value == null ?(object) DBNull.Value : DateTime.Parse(nhanvien.Ngay_dk_thue_value.Value.ToString("yyyy/MM/dd")), IsNullable = true},
                new SqlParameter("@noi_dk_thue", SqlDbType.NVarChar) {Value = nhanvien.Noi_dk_thue_value},
                new SqlParameter("@so_tk", SqlDbType.VarChar) {Value = nhanvien.So_tk_value},
                new SqlParameter("@ngan_hang", SqlDbType.NVarChar) {Value = nhanvien.Ngan_hang_value},
                new SqlParameter("@tien_mat", SqlDbType.Bit) {Value = nhanvien.Nhan_tien_mat_value},
                new SqlParameter("@khong_cu_tru", SqlDbType.Bit) {Value = nhanvien.Ca_nhan_khong_cu_tru_value},
                new SqlParameter("@khong_uy_quyen", SqlDbType.Bit) {Value = nhanvien.Khong_uy_quyen_value},
                new SqlParameter("@ngan_hang_ck", SqlDbType.Int) {Value = nhanvien.Ngan_hang_ck_value},
                new SqlParameter("@work_permit", SqlDbType.NVarChar) {Value = nhanvien.Work_permit_value},
                new SqlParameter("@ngay_cap_wp", SqlDbType.Date) {Value = nhanvien.Ngay_cap_work_permit_value == null ?(object) DBNull.Value : DateTime.Parse(nhanvien.Ngay_cap_work_permit_value.Value.ToString("yyyy/MM/dd")), IsNullable = true},
                new SqlParameter("@ngay_het_han_wp", SqlDbType.Date) {Value = nhanvien.Ngay_het_han_work_permit_value == null ?(object) DBNull.Value : DateTime.Parse(nhanvien.Ngay_het_han_work_permit_value.Value.ToString("yyyy/MM/dd")), IsNullable = true},
                new SqlParameter("@hinh_anh", SqlDbType.Image) {Value = nhanvien.Picbyte == null ? (object)DBNull.Value : nhanvien.Picbyte},
                new SqlParameter("@chieu_cao", SqlDbType.Int) {Value = nhanvien.Chieu_cao_value},
                new SqlParameter("@can_nang", SqlDbType.VarChar) {Value = nhanvien.Can_nang_value},
                new SqlParameter("@nhom_mau", SqlDbType.VarChar) {Value = nhanvien.Nhom_mau_value},
                new SqlParameter("@suc_khoe", SqlDbType.NVarChar) {Value = nhanvien.Suc_khoe_value},
                new SqlParameter("@luu_y_sk", SqlDbType.NVarChar) {Value = nhanvien.Luu_y_sk_value},
                new SqlParameter("@khuyet_tat", SqlDbType.NVarChar) {Value = nhanvien.Khuyet_tat_value},
                new SqlParameter("@ma_cham_cong", SqlDbType.NVarChar) {Value = nhanvien.Ma_Cham_Cong},
                new SqlParameter("@ten_cham_cong", SqlDbType.NVarChar) {Value = nhanvien.Ten_Cham_Cong},
                new SqlParameter("@ma_the", SqlDbType.NVarChar) {Value = nhanvien.Ma_The},
                new SqlParameter("@id_nguoi_tao", SqlDbType.VarChar) {Value = SQLHelper.sIdUser},
            };
            if (SQLHelper.ExecuteSql(sql, param) == 1)
            {
                nhan_su.load_data(1);
                RJMessageBox.Show("Sửa thành công", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }
        private void insert_ho_so()
        {
            set_txt_value();
            string sql = "insert into hrm_nhan_vien(id_trang_thai,ma_nhan_vien,ho_ten,ten,ho_lot,ngay_sinh,gioi_tinh,hon_nhan,id_ton_giao,id_dan_toc,id_quoc_tich," +
                         "so_cccd,ngay_cap_cccd,noi_cap_cccd,so_ho_chieu,ngay_cap_ho_chieu,noi_cap_ho_chieu,ngay_het_han_ho_chieu," +
                         "dien_thoai_dd,email,ghi_chu,ngay_thu_viec,thoi_gian_thu_viec,ngay_ket_thuc_thu_viec," +
                         "ngay_vao_lam,ngay_ket_thuc,ma_so_thue,ngay_dk_thue,noi_dk_thue,so_tk,ngan_hang,nhan_tien_mat,ca_nhan_khong_cu_tru," +
                         "khong_uy_quyen_qt,id_ngan_hang_ck,work_permit,ngay_cap_wp,ngay_het_han_wp,hinh_anh,chieu_cao,can_nang,nhom_mau,suc_khoe,luu_y_sk,khuyet_tat," +
                         "ma_cham_cong,ten_cham_cong,ma_the,id_nguoi_tao) " +
                         "values(@trang_thai,@ma_so,@ho_ten,@ten,@ho_lot,@ngay_sinh,@gioi_tinh,@hon_nhan,@ton_giao,@dan_toc,@quoc_tich," +
                         "@cccd,@ngay_cap_cc,@noi_cap_cc,@so_ho_chieu,@ngay_cap_hc,@noi_cap_hc,@ngay_het_han_hc," +
                         "@sdt,@email,@ghi_chu,@ngay_thu_viec,@tg_thu_viec,@ngay_kt_thu_viec," +
                         "@ngay_vao_lam,@ngay_ket_thuc,@ma_so_thue,@ngay_dk_thue,@noi_dk_thue,@so_tk,@ngan_hang,@tien_mat,@ca_nhan_khong_cu_tru," +
                         "@khong_uy_quyen,@ngan_hang_ck,@work_permit,@ngay_cap_work_permit,@ngay_het_han_work_permit,@hinh_anh,@chieu_cao,@can_nang,@nhom_mau,@suc_khoe,@luu_y_sk,@khuyet_tat," +
                         "@ma_cham_cong,@ten_cham_cong,@ma_the,@id_nguoi_tao)";
            SqlParameter[] param = new SqlParameter[]
            {
                new SqlParameter("@trang_thai", SqlDbType.Int) {Value = nhanvien.Trang_thai_value},
                new SqlParameter("@ma_so", SqlDbType.VarChar) {Value = nhanvien.Ma_so_value},
                new SqlParameter("@ho_ten", SqlDbType.NVarChar) {Value = nhanvien.Ho_ten_value},
                new SqlParameter("@ten", SqlDbType.NVarChar) {Value = nhanvien.Ten_value},
                new SqlParameter("@ho_lot", SqlDbType.NVarChar) {Value = nhanvien.Ho_lot_value},
                new SqlParameter("@ngay_sinh", SqlDbType.Date) {Value = nhanvien.Ngay_sinh_value,IsNullable = true},
                new SqlParameter("@gioi_tinh", SqlDbType.Bit) {Value = nhanvien.Gioi_tinh_value},
                new SqlParameter("@hon_nhan", SqlDbType.Int) {Value = nhanvien.Hon_nhan_value},
                new SqlParameter("@ton_giao", SqlDbType.Int) {Value = nhanvien.Ton_giao_value},
                new SqlParameter("@dan_toc", SqlDbType.Int) {Value = nhanvien.Dan_toc_value},
                new SqlParameter("@quoc_tich", SqlDbType.Int) {Value = nhanvien.Quoc_tich_value},
                new SqlParameter("@cccd", SqlDbType.VarChar) {Value = nhanvien.Cccd_value},
                new SqlParameter("@ngay_cap_cc", SqlDbType.Date) {Value = nhanvien.Ngay_cap_cccd_value == null ?(object) DBNull.Value : DateTime.Parse(nhanvien.Ngay_cap_cccd_value.Value.ToString("yyyy/MM/dd")),IsNullable = true},
                new SqlParameter("@noi_cap_cc", SqlDbType.NVarChar) {Value = nhanvien.Noi_cap_cccd_value},
                new SqlParameter("@so_ho_chieu", SqlDbType.NVarChar) {Value = nhanvien.So_hc_value},
                new SqlParameter("@ngay_cap_hc", SqlDbType.Date) {Value =(nhanvien.Ngay_cap_hc_value == null ?(object) DBNull.Value : DateTime.Parse(nhanvien.Ngay_cap_hc_value.Value.ToString("yyyy/MM/dd"))), IsNullable = true},
                new SqlParameter("@noi_cap_hc", SqlDbType.NVarChar) {Value = nhanvien.Noi_cap_hc_value},
                new SqlParameter("@ngay_het_han_hc", SqlDbType.Date) {Value =(nhanvien.Ngay_het_han_hc_value == null ?(object) DBNull.Value : DateTime.Parse(nhanvien.Ngay_het_han_hc_value.Value.ToString("yyyy/MM/dd"))), IsNullable = true},
                new SqlParameter("@sdt", SqlDbType.VarChar) {Value = nhanvien.Sdt_value},
                new SqlParameter("@email", SqlDbType.VarChar) {Value = nhanvien.Email_value},
                new SqlParameter("@ghi_chu", SqlDbType.NVarChar) {Value = nhanvien.Ghi_chu_value},
                new SqlParameter("@ngay_thu_viec", SqlDbType.Date) {Value =nhanvien.Ngay_tv_value == null ?(object) DBNull.Value : DateTime.Parse(nhanvien.Ngay_tv_value.Value.ToString("yyyy/MM/dd")), IsNullable = true},
                new SqlParameter("@tg_thu_viec", SqlDbType.Int) {Value = nhanvien.Thoi_gan_tv_value},
                new SqlParameter("@ngay_kt_thu_viec", SqlDbType.Date) {Value =nhanvien.Ngay_ket_thuc_tv_value == null ?(object) DBNull.Value : DateTime.Parse(nhanvien.Ngay_ket_thuc_tv_value.Value.ToString("yyyy/MM/dd")), IsNullable = true},
                new SqlParameter("@ngay_vao_lam", SqlDbType.Date) {Value =nhanvien.Ngay_vao_lam_value == null ?(object) DBNull.Value : DateTime.Parse(nhanvien.Ngay_vao_lam_value.Value.ToString("yyyy/MM/dd")), IsNullable = true},
                new SqlParameter("@ngay_ket_thuc", SqlDbType.Date) {Value =nhanvien.Ngay_ket_thuc_value == null ?(object) DBNull.Value : DateTime.Parse(nhanvien.Ngay_ket_thuc_value.Value.ToString("yyyy/MM/dd")), IsNullable = true},
                new SqlParameter("@ma_so_thue", SqlDbType.NVarChar) {Value = nhanvien.Ma_so_thue_value},
                new SqlParameter("@ngay_dk_thue", SqlDbType.Date) {Value =nhanvien.Ngay_dk_thue_value == null ?(object) DBNull.Value : DateTime.Parse(nhanvien.Ngay_dk_thue_value.Value.ToString("yyyy/MM/dd")), IsNullable = true},
                new SqlParameter("@noi_dk_thue", SqlDbType.NVarChar) {Value = nhanvien.Noi_dk_thue_value},
                new SqlParameter("@so_tk", SqlDbType.VarChar) {Value = nhanvien.So_tk_value},
                new SqlParameter("@ngan_hang", SqlDbType.NVarChar) {Value = nhanvien.Ngan_hang_value},
                new SqlParameter("@tien_mat", SqlDbType.Bit) {Value = nhanvien.Nhan_tien_mat_value},
                new SqlParameter("@ca_nhan_khong_cu_tru", SqlDbType.Bit) {Value = nhanvien.Ca_nhan_khong_cu_tru_value},
                new SqlParameter("@khong_uy_quyen", SqlDbType.Bit) {Value = nhanvien.Khong_uy_quyen_value},
                new SqlParameter("@ngan_hang_ck", SqlDbType.Int) {Value = nhanvien.Ngan_hang_ck_value},
                new SqlParameter("@work_permit", SqlDbType.NVarChar) {Value = nhanvien.Work_permit_value},
                new SqlParameter("@ngay_cap_work_permit", SqlDbType.Date) {Value =nhanvien.Ngay_cap_work_permit_value == null ?(object) DBNull.Value : DateTime.Parse(nhanvien.Ngay_cap_work_permit_value.Value.ToString("yyyy/MM/dd")), IsNullable = true},
                new SqlParameter("@ngay_het_han_work_permit", SqlDbType.Date) {Value =nhanvien.Ngay_het_han_work_permit_value == null ?(object) DBNull.Value : DateTime.Parse(nhanvien.Ngay_het_han_work_permit_value.Value.ToString("yyyy/MM/dd")), IsNullable = true},
                new SqlParameter("@hinh_anh", SqlDbType.Image) {Value = nhanvien.Picbyte == null ? (object)DBNull.Value : nhanvien.Picbyte},
                new SqlParameter("@chieu_cao", SqlDbType.Int) {Value = nhanvien.Chieu_cao_value},
                new SqlParameter("@can_nang", SqlDbType.VarChar) {Value = nhanvien.Can_nang_value},
                new SqlParameter("@nhom_mau", SqlDbType.VarChar) {Value = nhanvien.Nhom_mau_value},
                new SqlParameter("@suc_khoe", SqlDbType.NVarChar) {Value = nhanvien.Suc_khoe_value},
                new SqlParameter("@luu_y_sk", SqlDbType.NVarChar) {Value = nhanvien.Luu_y_sk_value},
                new SqlParameter("@khuyet_tat", SqlDbType.NVarChar) {Value = nhanvien.Khuyet_tat_value},
                new SqlParameter("@ma_cham_cong", SqlDbType.NVarChar) {Value = nhanvien.Ma_Cham_Cong},
                new SqlParameter("@ten_cham_cong", SqlDbType.NVarChar) {Value = nhanvien.Ten_Cham_Cong},
                new SqlParameter("@ma_the", SqlDbType.NVarChar) {Value = nhanvien.Ma_The},
                new SqlParameter("@id_nguoi_tao", SqlDbType.VarChar) {Value = SQLHelper.sIdUser},
            };
            SQLHelper.ExecuteSql(sql, param);
            _ma_nhan_vien = txt_ma_so.Text;
            pl_don_vi.Enabled = true;
            pl_hop_dong.Enabled = true;
            pl_bao_hiem.Enabled = true;
            pl_luong.Enabled = true;
            pl_phu_cap.Enabled = true;
            pl_chuyen_mon.Enabled = true;
            pl_ngoai_ngu.Enabled = true;
            pl_tin_hoc.Enabled = true;
            btn_thuong_tru.Enabled = true;
            btn_que_quan.Enabled = true;
            pl_tin_hoc.Enabled = true;
            pl_banthan.Enabled = true;
            pl_giadinh.Enabled = true;
            pl_taisan.Enabled = true;
            tc_qtlv.Enabled = true;
            nhan_su.load_data(1);
            RJMessageBox.Show("Thêm thành công", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
        private void set_txt_value()
        {
            nhanvien.Trang_thai_value = int.Parse(cbo_trang_thai.SelectedValue.ToString());
            nhanvien.Ma_so_value = txt_ma_so.Text;
            nhanvien.Ho_ten_value = txt_ho_lot.Text + " " + txt_ten.Text;
            nhanvien.Ten_value = txt_ten.Text;
            nhanvien.Ho_lot_value = txt_ho_lot.Text;
            nhanvien.Ngay_sinh_value = dtp_ngay_sinh.Value;
            nhanvien.Gioi_tinh_value = int.Parse(cbo_gioi_tinh.SelectedValue.ToString());
            nhanvien.Hon_nhan_value = rb_dakethon.Checked == true ? 1 : 0;
            nhanvien.Ton_giao_value = int.Parse(cbo_ton_giao.SelectedValue.ToString());
            nhanvien.Dan_toc_value = int.Parse(cbo_dan_toc.SelectedValue.ToString());
            nhanvien.Quoc_tich_value = int.Parse(cbo_quoc_tich.SelectedValue.ToString());
            nhanvien.Cccd_value = txt_cccd.Text;
            nhanvien.Ngay_cap_cccd_value = string.IsNullOrWhiteSpace(dtp_ngay_cap_cccd.Text.ToString()) ? (DateTime?)null : DateTime.Parse(dtp_ngay_cap_cccd.Text.ToString());
            nhanvien.Noi_cap_cccd_value = txt_noi_cap_cc.Text;
            nhanvien.So_hc_value = txt_ho_chieu.Text;
            nhanvien.Ngay_cap_hc_value = string.IsNullOrWhiteSpace(dtp_ngay_cap_hc.Text.ToString()) ? (DateTime?)null : DateTime.Parse(dtp_ngay_cap_hc.Text.ToString());
            nhanvien.Noi_cap_hc_value = txt_noi_cap_hc.Text;
            nhanvien.Ngay_het_han_hc_value = string.IsNullOrWhiteSpace(dtp_het_han_hc.Text.ToString()) ? (DateTime?)null : DateTime.Parse(dtp_het_han_hc.Text.ToString());
            nhanvien.Sdt_value = txt_di_dong.Text;
            nhanvien.Email_value = txt_email.Text;
            nhanvien.Suc_khoe_value = txt_suc_khoe.Text;
            nhanvien.Chieu_cao_value = (string.IsNullOrEmpty(txt_chieu_cao.Text) ? 0 : int.Parse(txt_chieu_cao.Text));
            nhanvien.Can_nang_value = txt_can_nang.Text;
            nhanvien.Luu_y_sk_value = txt_luu_y_sk.Text;
            nhanvien.Nhom_mau_value = cbo_nhom_mau.SelectedValue.ToString();
            nhanvien.Khuyet_tat_value = chk_khuyet_tat.Checked == true ? 1 : 0;
            nhanvien.Ghi_chu_value = txt_ghi_chu.Text;
            nhanvien.Ngay_tv_value = DateTime.Parse(dtp_ngay_thu_viec.Value.ToString());
            nhanvien.Thoi_gan_tv_value = (int)(dtp_ngay_ket_thuc_tv.Value - dtp_ngay_thu_viec.Value).TotalDays;
            nhanvien.Ngay_ket_thuc_tv_value = DateTime.Parse(dtp_ngay_thu_viec.Value.ToString());
            nhanvien.Ngay_vao_lam_value = string.IsNullOrWhiteSpace(dtp_ngay_vao_lam.Text.ToString()) ? (DateTime?)null : DateTime.Parse(dtp_ngay_vao_lam.Text.ToString());
            nhanvien.Ngay_ket_thuc_value = string.IsNullOrWhiteSpace(dtp_ngay_ket_thuc_lam.Text.ToString()) ? (DateTime?)null : DateTime.Parse(dtp_ngay_ket_thuc_lam.Text.ToString());
            nhanvien.Ma_so_thue_value = txt_ma_so_thue.Text;
            nhanvien.Ngay_dk_thue_value = string.IsNullOrWhiteSpace(dtp_ngay_dk_thue.Text.ToString()) ? (DateTime?)null : DateTime.Parse(dtp_ngay_dk_thue.Text.ToString());
            nhanvien.Noi_dk_thue_value = txt_noi_dk_thue.Text;
            nhanvien.So_tk_value = txt_sotk.Text;
            nhanvien.Ngan_hang_value = txt_ngan_hang_nhan.Text;
            nhanvien.Nhan_tien_mat_value = chk_tien_mat.Checked == true ? 1 : 0;
            nhanvien.Ca_nhan_khong_cu_tru_value = chk_khong_cu_tru.Checked == true ? 1 : 0;
            nhanvien.Khong_uy_quyen_value = chk_khong_uy_quyen.Checked == true ? 1 : 0;
            nhanvien.Ngan_hang_ck_value = int.Parse(cbo_ngan_hang.SelectedValue.ToString());
            nhanvien.Work_permit_value = txt_work_permit.Text;
            nhanvien.Ngay_cap_work_permit_value = string.IsNullOrWhiteSpace(dtp_ngay_cap_workpermit.Text.ToString()) ? (DateTime?)null : DateTime.Parse(dtp_ngay_cap_workpermit.Text.ToString());
            nhanvien.Ngay_het_han_work_permit_value = string.IsNullOrWhiteSpace(dtp_ngay_het_workpermit.Text.ToString()) ? (DateTime?)null : DateTime.Parse(dtp_ngay_het_workpermit.Text.ToString());
            nhanvien.Chieu_cao_value = int.Parse(txt_chieu_cao.Text);
            nhanvien.Picbyte = null;
            nhanvien.Ma_Cham_Cong = txt_ma_cham_cong.Text;
            nhanvien.Ten_Cham_Cong = txt_ten_cham_cong.Text;
            nhanvien.Ma_The = txt_ma_the.Text;
            if (pb_avata.Image != null)
            {
                MemoryStream ms;
                ms = new MemoryStream();
                pb_avata.Image.Save(ms, ImageFormat.Png);
                nhanvien.Picbyte = new byte[ms.Length];
                ms.Position = 0;
                ms.Read(nhanvien.Picbyte, 0, nhanvien.Picbyte.Length);
            }
        }

        private void radioButton2_CheckedChanged(object sender, EventArgs e)
        {
            if (rb_dakethon.Checked == true)
            {
                btn_honnhan.Enabled = true;
            }
            else
            {
                btn_honnhan.Enabled = false;
            }
        }
    }
}
