using System;
using System.Data;
using System.Linq;
using System.Windows.Forms;
using TENTAC_HRM.Custom;
using TENTAC_HRM.Forms.Main;

namespace TENTAC_HRM.Forms.Category
{
    public partial class frm_pecialize : Form
    {
        frm_personnel personnel;
        public int _id_daotao_value { get; set; }
        public string _ma_nhan_vien { get; set; }
        public bool edit { get; set; }
        DataProvider provider = new DataProvider();
        int Active_value, HeDaoTao_value;
        string LoaiDaoTao_value, BacDaoTao_value,NganhDaoTao_value, TruongDaoTao_value, XepLoai_value, GhiChu_value, NguoiTao_value = SQLHelper.sUser, NguoiCapNhat_value = SQLHelper.sUser;
        DateTime? TuNam_value, DenNam_value, NgayNhanBang_value;
        public frm_pecialize(frm_personnel _personnel)
        {
            InitializeComponent();
            personnel = _personnel;
        }

        private void frm_train_Load(object sender, EventArgs e)
        {
            //load_loaidaotao();
            load_nhanvien();
            load_bacdaotao();
            load_nganhdaotao();
            load_hedaotao();
            load_XepLoai();
            if (edit == true)
            {
                load_data();
            //    cbo_LoaiDaoTao.Enabled = false;
            }
        }
        private void LoadNull()
        {
            cbo_BacDaoTao.SelectedValue = string.Empty;
            cbo_HeDaoTao.SelectedValue = "0";
            cbo_NganhDaoTao.SelectedValue = string.Empty;
            txt_truongdaotao.Text = string.Empty;
            dtp_TuNam.Text = string.Empty;
            dtp_DenNam.Text = string.Empty;
            dtp_NamNhanBang.Text = string.Empty;
            chk_active.Checked = false;
            cbo_XepLoai.SelectedIndex = 0;
            txt_ghichu.Text = string.Empty;
        }
        private void load_data()
        {
            string sql = string.Format("select * from tbl_NhanVienDaoTao where Id = {0}", _id_daotao_value);
            DataTable dt = new DataTable();
            dt = SQLHelper.ExecuteDt(sql);
            if (dt.Rows.Count > 0)
            {
                //cbo_LoaiDaoTao.SelectedValue = dt.Rows[0]["LoaiDaoTao"];
                cbo_BacDaoTao.SelectedValue = dt.Rows[0]["MaBacDaoTao"].ToString();
                cbo_HeDaoTao.SelectedValue = dt.Rows[0]["Id_HeDaoTao"];
                cbo_NganhDaoTao.SelectedValue = dt.Rows[0]["MaNganhDaoTao"].ToString();
                dtp_TuNam.Text = dt.Rows[0]["TuNgay"].ToString();
                dtp_DenNam.Text = dt.Rows[0]["DenNgay"].ToString();
                dtp_NamNhanBang.Text = dt.Rows[0]["NgayNhanBang"].ToString();
                txt_truongdaotao.Text = dt.Rows[0]["TruongDaoTao"].ToString();
                cbo_XepLoai.SelectedValue = dt.Rows[0]["XepLoaiBang"];
                txt_ghichu.Text = dt.Rows[0]["GhiChu"].ToString();
                chk_active.Checked = bool.Parse(dt.Rows[0]["IsActive"].ToString());
            }
        }
        private void load_nhanvien()
        {
            cbo_NhanVien.DataSource = provider.load_nhanvien();
            cbo_NhanVien.DisplayMember = "name";
            cbo_NhanVien.ValueMember = "value";
            cbo_NhanVien.SelectedValue = _ma_nhan_vien;
        }
        private void load_hedaotao()
        {
            string sql = "select Id, TenHe from mst_HeDaoTao";
            DataTable dt = new DataTable();
            dt = SQLHelper.ExecuteDt(sql);
            dt.Rows.Add(0, "");
            cbo_HeDaoTao.DataSource = dt.Rows.Cast<DataRow>().OrderBy(x => x.Field<int>("Id")).CopyToDataTable();
            cbo_HeDaoTao.DisplayMember = "TenHe";
            cbo_HeDaoTao.ValueMember = "Id";
        }

        private void load_nganhdaotao()
        {
            string sql = "select MaChuyenNganh, TenChuyenNganh from mst_ChuyenNganh";
            DataTable dt = new DataTable();
            dt = SQLHelper.ExecuteDt(sql);
            dt.Rows.Add("", "");
            cbo_NganhDaoTao.DataSource = dt.Rows.Cast<DataRow>().OrderBy(x => x.Field<string>("MaChuyenNganh")).CopyToDataTable();
            cbo_NganhDaoTao.DisplayMember = "TenChuyenNganh";
            cbo_NganhDaoTao.ValueMember = "MaChuyenNganh";
        }

        private void load_bacdaotao()
        {
            string sql = "select MaBac,TenBac from mst_BacDaoTao";
            DataTable dt = new DataTable();
            dt = SQLHelper.ExecuteDt(sql);
            dt.Rows.Add("", "");
            cbo_BacDaoTao.DataSource = dt.Rows.Cast<DataRow>().OrderBy(x => x.Field<string>("MaBac")).CopyToDataTable();
            cbo_BacDaoTao.DisplayMember = "TenBac";
            cbo_BacDaoTao.ValueMember = "MaBac";
        }
        private void load_XepLoai()
        {
            cbo_XepLoai.DataSource = provider.load_xeploai();
            cbo_XepLoai.DisplayMember = "name";
            cbo_XepLoai.ValueMember = "id";
        }

        //private void load_loaidaotao()
        //{
        //    cbo_LoaiDaoTao.DataSource = provider.load_all_type(70);
        //    cbo_LoaiDaoTao.DisplayMember = "name";
        //    cbo_LoaiDaoTao.ValueMember = "id";
        //}

        private void btn_save_add_Click(object sender, EventArgs e)
        {
            if (edit == true)
            {
                update_data();
            }
            else
            {
                insert_data();
            }
        }

        private void update_data()
        {
            try
            {
                set_textvalue();
                string sql = string.Empty;
                sql = $@"Update tbl_NhanVienDaoTao 
                    set MaBacDaoTao = {SQLHelper.rpStr(BacDaoTao_value)}, Id_HeDaoTao = {SQLHelper.rpI(HeDaoTao_value)}, 
                    MaNganhDaoTao = {SQLHelper.rpStr(NganhDaoTao_value)}, TruongDaoTao = {SQLHelper.rpStr(TruongDaoTao_value)},
                    TuNgay = {SQLHelper.rpDT(TuNam_value)}, DenNgay = {SQLHelper.rpDT(DenNam_value)}, NgayNhanBang = {SQLHelper.rpDT(NgayNhanBang_value)}, 
                    XepLoaiBang = {SQLHelper.rpStr(XepLoai_value)}, GhiChu = {SQLHelper.rpStr(GhiChu_value)},
                    NgayCapNhat = '{DateTime.Now}', NguoiCapNhat = {SQLHelper.rpStr(NguoiCapNhat_value)}
                    where Id = {SQLHelper.rpI(_id_daotao_value)}";
                if (SQLHelper.ExecuteSql(sql) == 1)
                {
                    RJMessageBox.Show("Cập nhật thành công", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    personnel.load_chuyenmon();
                    LoadNull();
                }
            }
            catch (Exception ex)
            {
                RJMessageBox.Show(ex.Message, "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btn_save_close_Click(object sender, EventArgs e)
        {
            if (edit == true)
            {
                update_data();
            }
            else
            {
                insert_data();
            }
            this.Close();
        }
        private void insert_data()
        {
            try
            {
                set_textvalue();
                string sql = string.Empty;
                sql = $@"insert into tbl_NhanVienDaoTao(MaNhanVien, IsActive, MaBacDaoTao, Id_HeDaoTao, 
                    MaNganhDaoTao, TruongDaoTao, TuNgay, DenNgay, NgayNhanBang, XepLoaiBang, GhiChu, NgayTao, NguoiTao) 
                    values ({SQLHelper.rpStr(_ma_nhan_vien)}, {SQLHelper.rpI(Active_value)}, {SQLHelper.rpStr(BacDaoTao_value)},
                    {SQLHelper.rpI(HeDaoTao_value)}, {SQLHelper.rpStr(NganhDaoTao_value)}, {SQLHelper.rpStr(TruongDaoTao_value)}, 
                    {SQLHelper.rpDT(TuNam_value)}, {SQLHelper.rpDT(DenNam_value)},{SQLHelper.rpDT(NgayNhanBang_value)}, 
                    {SQLHelper.rpStr(XepLoai_value)}, {SQLHelper.rpStr(GhiChu_value)}, '{DateTime.Now}', {SQLHelper.rpStr(NguoiTao_value)})";
                if (SQLHelper.ExecuteSql(sql) == 1)
                {
                    RJMessageBox.Show("Thêm thành công", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    LoadNull();

                    personnel.load_chuyenmon();

                }
            }
            catch (Exception ex)
            {
                RJMessageBox.Show(ex.Message, "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btn_close_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        private void set_textvalue()
        {
            Active_value = (chk_active.Checked == true ? 1 : 0);
            //LoaiDaoTao_value = cbo_LoaiDaoTao.SelectedValue.ToString();
            BacDaoTao_value = cbo_BacDaoTao.SelectedValue.ToString();
            HeDaoTao_value = Convert.ToInt32(cbo_HeDaoTao.SelectedValue);
            NganhDaoTao_value = cbo_NganhDaoTao.SelectedValue?.ToString() ?? "";
            TruongDaoTao_value = txt_truongdaotao.Text;
            TuNam_value = string.IsNullOrEmpty(dtp_TuNam.Text) ? (DateTime?)null : DateTime.Parse(dtp_TuNam.Text);
            DenNam_value = string.IsNullOrEmpty(dtp_DenNam.Text) ? (DateTime?)null : DateTime.Parse(dtp_DenNam.Text);
            NgayNhanBang_value = string.IsNullOrEmpty(dtp_NamNhanBang.Text) ? (DateTime?)null : DateTime.Parse(dtp_NamNhanBang.Text);
            XepLoai_value = cbo_XepLoai.SelectedValue.ToString();
            GhiChu_value = txt_ghichu.Text;
            NguoiTao_value = SQLHelper.sUser;
            NguoiCapNhat_value = SQLHelper.sUser;
        }

        private void frm_pecialize_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
            {
                this.Close();
            }
        }
    }
}
