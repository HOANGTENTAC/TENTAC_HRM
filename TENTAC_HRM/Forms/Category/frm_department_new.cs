using ComponentFactory.Krypton.Toolkit;
using System;
using System.Data;
using System.Linq;
using System.Windows.Forms;
using TENTAC_HRM.Custom;
using TENTAC_HRM.Forms.NhanSu;

namespace TENTAC_HRM.Forms.Category
{
    public partial class frm_department_new : KryptonForm
    {
        DataProvider provider = new DataProvider();
        frm_personnel personnel;
        public bool edit { get; set; } = false;
        public string _MaNhanVien { get; set; }
        public int _IdNhanVienPhongBan { get; set; }

        string _MaCongTy, _MaKhuVuc, _MaPhongBan, _MaChucVu, _SoQuyetDinh, _GhiChu, _NguoiTao, _NguoiCapNhat;
        DateTime? _TuNgay, _DenNgay;
        int _IsActive;
        public frm_department_new(frm_personnel _personnel)
        {
            InitializeComponent();
            personnel = _personnel;
        }
        private void frm_department_new_Load(object sender, EventArgs e)
        {
            LoadNhanVien();
            LoadChucVu();
            LoadCongTy();
            LoadPhongBan();
            if (edit == true)
            {
                LoadData();
            }
        }
        private void LoadNhanVien()
        {
            cbo_NhanVien.DataSource = provider.load_nhanvien();
            cbo_NhanVien.DisplayMember = "name";
            cbo_NhanVien.ValueMember = "value";
            cbo_NhanVien.SelectedValue = _MaNhanVien;
        }
        private void LoadData()
        {
            string sql = string.Format("select a.Id, b.TenCongTy as TenCongTy, c.TenKhuVuc as TenKhuVuc, d.TenPhongBan as TenPhongBan, " +
                "e.TenChucVu as TenChucVu, a.TuNgay, a.DenNgay, a.IsActive from tbl_NhanVienPhongBan a " +
                "left join mst_CongTy b on a.MaCongTy = b.MaCongTy " +
                "left join mst_KhuVuc c on c.MaKhuVuc = a.MaKhuVuc " +
                "left join mst_PhongBan d on d.MaPhongBan = a.MaPhongBan " +
                "left join mst_ChucVu e on e.MaChucVu = a.MaChucVu " +
                "where a.MaNhanVien = '{0}' and a.del_flg = 0", _MaNhanVien);
            DataTable dt = new DataTable();
            dt = SQLHelper.ExecuteDt(sql);
            dgv_NhanVienPhongBan.DataSource = dt;
        }
        private void LoadCongTy()
        {
            DataTable dtCongTy = SQLHelper.ExecuteDt("select MaCongTy, TenCongTy from  dbo.[mst_CONGTY]");
            dtCongTy.Rows.Add("", "");
            cbo_CongTy.DataSource = dtCongTy.Rows.Cast<DataRow>().OrderBy(x => x.Field<string>("MaCongTy")).CopyToDataTable();
            cbo_CongTy.DisplayMember = "TenCongTy";
            cbo_CongTy.ValueMember = "MaCongTy";
        }
        private void cbo_CongTy_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cbo_CongTy.SelectedIndex != 0)
            {
                string MaCongTy = cbo_CongTy.SelectedValue.ToString();
                LoadKhuVuc(MaCongTy);
            }
        }
        private void btn_close_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        private void LoadNull()
        {
            edit = false;
            cbo_CongTy.SelectedValue = "";
            cbo_KhuVuc.SelectedValue = "";
            cbo_PhongBan.SelectedValue = "";
            cbo_ChucVu.SelectedValue = "";
            dtp_TuNgay.Text = string.Empty;
            dtp_DenNgay.Text = string.Empty;
            txt_SoQuyetDinh.Text = string.Empty;
            txt_GhiChu.Text = string.Empty;
            chk_Active.Checked = false;
        }
        private void btn_clear_Click(object sender, EventArgs e)
        {
            LoadNull();
        }
        private void LoadKhuVuc(string MaCongTy)
        {
            DataTable dtPhongBan = SQLHelper.ExecuteDt($"select MaKhuVuc, TenKhuVuc from  dbo.[mst_KhuVuc] where MaCongTy = {SQLHelper.rpStr(MaCongTy)}");
            dtPhongBan.Rows.Add("", "");
            cbo_KhuVuc.DataSource = dtPhongBan.Rows.Cast<DataRow>().OrderBy(x => x.Field<string>("MaKhuVuc")).CopyToDataTable();
            cbo_KhuVuc.DisplayMember = "TenKhuVuc";
            cbo_KhuVuc.ValueMember = "MaKhuVuc";
        }
        private void LoadChucVu()
        {
            string sql = string.Format("select MaChucVu,TenChucVu from mst_ChucVu");
            DataTable dtChucVu = SQLHelper.ExecuteDt(sql);
            dtChucVu.Rows.Add("", "");
            cbo_ChucVu.DataSource = dtChucVu.Rows.Cast<DataRow>().OrderBy(x => x.Field<string>("MaChucVu")).CopyToDataTable(); ;
            cbo_ChucVu.DisplayMember = "TenChucVu";
            cbo_ChucVu.ValueMember = "MaChucVu";
        }
        private void LoadPhongBan()
        {
            string sql = string.Format("select MaPhongBan, TenPhongBan from mst_PhongBan where DelFlg = 0");
            DataTable dtPhongBan = SQLHelper.ExecuteDt(sql);
            dtPhongBan.Rows.Add("0", "");
            cbo_PhongBan.DataSource = dtPhongBan.Rows.Cast<DataRow>().OrderBy(x => x.Field<string>("MaPhongBan")).CopyToDataTable();
            cbo_PhongBan.DisplayMember = "TenPhongBan";
            cbo_PhongBan.ValueMember = "MaPhongBan";
        }
        private void btn_SaveClick(object sender, EventArgs e)
        {
            SetValues();
            if (edit == true)
            {
                UpdateData();
            }
            else
            {
                InsertData();
            }

            if (personnel != null)
            {
                personnel.LoadNhanVienPhongBan();
            }
        }
        private void UpdateData()
        {
            try
            {
                string sql = string.Empty;
                sql = $@"Update tbl_NhanVienPhongBan Set IsActive = {SQLHelper.rpI(_IsActive)}, MaCongTy = {SQLHelper.rpStr(_MaCongTy)},
                MaKhuVuc = {SQLHelper.rpStr(_MaKhuVuc)}, MaPhongBan = {SQLHelper.rpStr(_MaPhongBan)}, MaChucVu = {SQLHelper.rpStr(_MaChucVu)}, 
                TuNgay = {SQLHelper.rpDT(_TuNgay)}, DenNgay = {SQLHelper.rpDT(_DenNgay)}, SoQuyetDinh = {SQLHelper.rpStr(_SoQuyetDinh)},
                GhiChu = {SQLHelper.rpStr(_GhiChu)}, NgayCapNhat = '{DateTime.Now}', NguoiCapNhat = {SQLHelper.rpStr(_NguoiCapNhat)}
                Where Id = {SQLHelper.rpI(_IdNhanVienPhongBan)}";

                if (SQLHelper.ExecuteSql(sql) == 1)
                {
                    if (chk_Active.Checked == true)
                    {
                        string sql_check = string.Format("select * from tbl_NhanVienPhongBan where MaCongTy = {0} and Id <> {1}", SQLHelper.rpStr(_MaCongTy), _IdNhanVienPhongBan);
                        DataTable dt = SQLHelper.ExecuteDt(sql_check);
                        if (dt.Rows.Count > 0)
                        {
                            string update_sql = string.Format("update tbl_NhanVienPhongBan set IsActive = 0 where MaCongTy = {0} and Id <> {1}", SQLHelper.rpStr(_MaCongTy), _IdNhanVienPhongBan);
                            SQLHelper.ExecuteSql(update_sql);
                        }
                    }
                    RJMessageBox.Show("Cập nhật thành công", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    LoadData();
                    personnel.LoadPhongBanNew();
                    LoadNull();
                }
            }
            catch (Exception ex)
            {
                RJMessageBox.Show(ex.Message, "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void InsertData()
        {
            try
            {
                string sql = string.Empty;
                sql = $@"Insert into tbl_NhanVienPhongBan(MaNhanVien, IsActive, MaCongTy, MaKhuVuc, MaPhongBan, MaChucVu, TuNgay, DenNgay,
                    SoQuyetDinh, GhiChu, NgayTao, NguoiTao, del_flg)
                    Values({SQLHelper.rpStr(_MaNhanVien)}, {SQLHelper.rpI(_IsActive)}, {SQLHelper.rpStr(_MaCongTy)}, {SQLHelper.rpStr(_MaKhuVuc)},
                    {SQLHelper.rpStr(_MaPhongBan)}, {SQLHelper.rpStr(_MaChucVu)}, {SQLHelper.rpDT(_TuNgay)}, {SQLHelper.rpDT(_DenNgay)},
                    {SQLHelper.rpStr(_SoQuyetDinh)}, {SQLHelper.rpStr(_GhiChu)}, '{DateTime.Now}', {SQLHelper.rpStr(_NguoiTao)}, 0)";
                int id = SQLHelper.ExecuteScalarSql(sql);
                if (chk_Active.Checked == true)
                {
                    string sql_check = string.Format("select * from tbl_NhanVienPhongBan where MaCongTy = {0} and Id <> {1}", SQLHelper.rpStr(_MaCongTy), id);
                    DataTable dt = SQLHelper.ExecuteDt(sql_check);
                    if (dt.Rows.Count > 0)
                    {
                        string update_sql = string.Format("update tbl_NhanVienPhongBan set IsActive = 0 where MaCongTy = {0} and Id <> {1}", SQLHelper.rpStr(_MaCongTy), id);
                        SQLHelper.ExecuteSql(update_sql);
                    }
                }
                RJMessageBox.Show("Thêm thành công", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                LoadData();
                personnel.LoadPhongBanNew();
                LoadNull();
            }
            catch (Exception ex)
            {
                RJMessageBox.Show(ex.Message, "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void SetValues()
        {
            _IsActive = chk_Active.Checked ? 1 : 0;
            _MaCongTy = cbo_CongTy.SelectedValue.ToString();
            _MaPhongBan = cbo_PhongBan.SelectedValue.ToString();
            _MaChucVu = cbo_ChucVu.SelectedValue.ToString();
            _MaKhuVuc = cbo_KhuVuc.SelectedValue.ToString();
            _TuNgay = string.IsNullOrEmpty(dtp_TuNgay.Text) ? (DateTime?)null : DateTime.Parse(dtp_TuNgay.Text);
            _DenNgay = string.IsNullOrEmpty(dtp_DenNgay.Text) ? (DateTime?)null : DateTime.Parse(dtp_DenNgay.Text);
            _SoQuyetDinh = txt_SoQuyetDinh.Text.Trim().ToString();
            _GhiChu = txt_GhiChu.Text.Trim().ToString();
            _NguoiTao = SQLHelper.sUser;
            _NguoiCapNhat = SQLHelper.sUser;
        }
        private void dgv_NhanVienPhongBan_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dgv_NhanVienPhongBan.CurrentCell.OwningColumn.Name == "edit_column")
            {
                edit = true;
                cbo_CongTy.Enabled = true;
                string sql = string.Format("select * from tbl_NhanVienPhongBan where Id = {0}", dgv_NhanVienPhongBan.CurrentRow.Cells["Id"].Value.ToString());
                DataTable dt = new DataTable();
                dt = SQLHelper.ExecuteDt(sql);
                if (dt.Rows.Count > 0)
                {
                    _IdNhanVienPhongBan = Convert.ToInt32(dt.Rows[0]["Id"]);
                    cbo_CongTy.SelectedValue = dt.Rows[0]["MaCongTy"].ToString();
                    cbo_KhuVuc.SelectedValue = dt.Rows[0]["MaKhuVuc"].ToString();
                    cbo_PhongBan.SelectedValue = dt.Rows[0]["MaPhongBan"].ToString();
                    cbo_ChucVu.SelectedValue = dt.Rows[0]["MaChucVu"].ToString();
                    dtp_TuNgay.Text = dt.Rows[0]["TuNgay"].ToString();
                    dtp_DenNgay.Text = dt.Rows[0]["DenNgay"].ToString();
                    txt_SoQuyetDinh.Text = dt.Rows[0]["SoQuyetDinh"].ToString();
                    txt_GhiChu.Text = dt.Rows[0]["GhiChu"].ToString();
                    chk_Active.Checked = dt.Rows[0]["IsActive"].ToString() == "True" ? true : false;
                }
            }
            else if (dgv_NhanVienPhongBan.CurrentCell.OwningColumn.Name == "delete_column")
            {
                try
                {
                    DialogResult result = RJMessageBox.Show("Bạn có chác muốn xóa?", "Thông báo", MessageBoxButtons.YesNo);
                    if (result == DialogResult.Yes)
                    {
                        string sql = string.Format("update tbl_NhanVienPhongBan set del_flg = 1 where Id = '{0}'", dgv_NhanVienPhongBan.CurrentRow.Cells["Id"].Value);
                        if (SQLHelper.ExecuteSql(sql) == 1)
                        {
                            RJMessageBox.Show("Xóa thành công", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            LoadData();
                            personnel.LoadNhanVienPhongBan();
                        }
                    }
                }
                catch (Exception ex)
                {
                    RJMessageBox.Show(ex.Message, "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }
    }
}