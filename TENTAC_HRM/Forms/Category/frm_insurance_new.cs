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
using TENTAC_HRM.Forms.Main;

namespace TENTAC_HRM.Forms.Category
{
    public partial class frm_insurance_new : Form
    {
        DataProvider provider = new DataProvider();
        public string _ma_nhan_vien { get; set; }
        public int id_baohiem_value { get; set; }
        public bool edit { get; set; } = false;
        frm_personnel personnel;
        int? _LoaiBaoHiem, _IsActive, _Id_Tinh;
        string _SoThe, _NoiThucHien, _GhiChu, _NguoiTao, _NguoiCapNhat;
        DateTime? _TuNgay, _DenNgay;
        public frm_insurance_new(frm_personnel _personnel)
        {
            InitializeComponent();
            personnel = _personnel;
        }
        private void load_loaibaohiem()
        {
            DataTable dt = new DataTable();
            dt = provider.load_all_type(50);
            cbo_LoaiBaoHiem.DataSource = dt;
            cbo_LoaiBaoHiem.DisplayMember = "name";
            cbo_LoaiBaoHiem.ValueMember = "id";
        }
        private void LoadData()
        {
            string sql = string.Format("select a.Id,b.TypeName as LoaiBaoHiem, a.SoThe, a.TuNgay, a.DenNgay, c.TenDiaChi as TinhThanh, a.IsActive, a.NoiThucHien " +
                "from tbl_NhanVienBaoHiem a " +
                "left join sys_AllType b on b.TypeId = a.LoaiBaoHiem " +
                "left join mst_DonViHanhChinh c on c.Id = a.Id_Tinh and LoaiDiaChi = 22 " +
                "where a.MaNhanVien = '{0}' and a.del_flg = 0", _ma_nhan_vien);
            DataTable dt = new DataTable();
            dt = SQLHelper.ExecuteDt(sql);
            dgv_BaoHiem.DataSource = dt;
        }

        private void LoadNhanVien()
        {
            cbo_NhanVien.DataSource = provider.load_nhanvien();
            cbo_NhanVien.DisplayMember = "name";
            cbo_NhanVien.ValueMember = "value";
            cbo_NhanVien.SelectedValue = _ma_nhan_vien;
        }

        private void load_tinh()
        {
            DataTable dt = new DataTable();
            dt = provider.load_tinh();
            dt.Rows.Add("0", "");
            cbo_TinhThanh.DataSource = dt.Rows.Cast<DataRow>().OrderBy(x => x.Field<int>("Id")).CopyToDataTable();
            cbo_TinhThanh.DisplayMember = "TenDiaChi";
            cbo_TinhThanh.ValueMember = "Id";
        }

        private void frm_insurance_new_Load(object sender, EventArgs e)
        {
            LoadData();
            LoadNhanVien();
            load_loaibaohiem();
            load_tinh();
        }

        private void LoadNull()
        {
            edit = false;
            cbo_LoaiBaoHiem.SelectedValue = "0";
            txt_SoThe.Text = string.Empty;
            chk_Active.Checked = false;
            dtp_TuNgay.Text = string.Empty;
            dtp_DenNgay.Text = string.Empty;
            txt_NoiDangKy.Text = string.Empty;
            cbo_TinhThanh.SelectedValue = "0";
            txt_GhiChu.Text = string.Empty;
            chk_Active.Checked = false;
        }
        private void btn_clear_Click(object sender, EventArgs e)
        {
            LoadNull();
        }

        private void btn_luu_Click(object sender, EventArgs e)
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
                set_value_text();
                string sql = string.Empty;
                sql = $@"Update tbl_NhanVienBaoHiem Set IsActive = {SQLHelper.rpI(_IsActive)}, LoaiBaoHiem = {SQLHelper.rpI(_LoaiBaoHiem)},
                SoThe = {SQLHelper.rpStr(_SoThe)}, TuNgay = {SQLHelper.rpDT(_TuNgay)}, DenNgay = {SQLHelper.rpDT(_DenNgay)}, Id_Tinh = {SQLHelper.rpI(_Id_Tinh)},
                NoiThucHien = {SQLHelper.rpStr(_NoiThucHien)}, GhiChu = {SQLHelper.rpStr(_GhiChu)}, NgayCapNhat = '{DateTime.Now}', NguoiCapNhat = {SQLHelper.rpStr(_NguoiCapNhat)}
                Where Id = {id_baohiem_value}";
                if (SQLHelper.ExecuteSql(sql) == 1)
                {
                    if (chk_Active.Checked == true)
                    {
                        string sql_check = string.Format("select * from tbl_NhanVienBaoHiem where LoaiBaoHiem = {0} and Id <> {1}", _LoaiBaoHiem, id_baohiem_value);
                        DataTable dt = SQLHelper.ExecuteDt(sql_check);
                        if (dt.Rows.Count > 0)
                        {
                            string update_sql = string.Format("update tbl_NhanVienBaoHiem set IsActive = 0 where LoaiBaoHiem = {0} and Id <> {1}", _LoaiBaoHiem, id_baohiem_value);
                            SQLHelper.ExecuteSql(update_sql);
                        }
                    }
                    RJMessageBox.Show("Cập nhật thành công", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    LoadData();
                    personnel.load_baohiem();
                    LoadNull();
                }
            }
            catch (Exception ex)
            {
                RJMessageBox.Show(ex.Message, "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void insert_data()
        {
            try
            {
                set_value_text();
                string sql = string.Empty;
                sql = $@"Insert into tbl_NhanVienBaoHiem(MaNhanVien, IsActive, LoaiBaoHiem, SoThe, TuNgay, DenNgay, Id_Tinh, NoiThucHien, GhiChu, NgayTao, NguoiTao, del_flg)
                values({SQLHelper.rpStr(_ma_nhan_vien)}, {SQLHelper.rpI(_IsActive)}, {SQLHelper.rpI(_LoaiBaoHiem)}, {SQLHelper.rpStr(_SoThe)},
                {SQLHelper.rpDT(_TuNgay)}, {SQLHelper.rpDT(_DenNgay)}, {SQLHelper.rpI(_Id_Tinh)}, {SQLHelper.rpStr(_NoiThucHien)}, 
                {SQLHelper.rpStr(_GhiChu)}, '{DateTime.Now}', {SQLHelper.rpStr(_NguoiTao)}, 0)";
                int id = SQLHelper.ExecuteScalarSql(sql);
                if (chk_Active.Checked == true)
                {
                    string sql_check = string.Format("select * from tbl_NhanVienBaoHiem where LoaiBaoHiem = {0} and Id <> {1}", _LoaiBaoHiem, id);
                    DataTable dt = SQLHelper.ExecuteDt(sql_check);
                    if (dt.Rows.Count > 0)
                    {
                        string update_sql = string.Format("update tbl_NhanVienBaoHiem set IsActive = 0 where LoaiBaoHiem = {0} and Id <> {1}", _LoaiBaoHiem, id);
                        SQLHelper.ExecuteSql(update_sql);
                    }
                }
                RJMessageBox.Show("Thêm thành công", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                LoadData();
                personnel.load_baohiem();
                LoadNull();
            }
            catch (Exception ex)
            {
                RJMessageBox.Show(ex.Message, "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void set_value_text()
        {
            _IsActive = (chk_Active.Checked == true ? 1 : 0);
            _LoaiBaoHiem = Convert.ToInt32(cbo_LoaiBaoHiem.SelectedValue);
            _SoThe = txt_SoThe.Text.Trim();
            _TuNgay = string.IsNullOrEmpty(dtp_TuNgay.Text) ? (DateTime?)null : DateTime.Parse(dtp_TuNgay.Text);
            _DenNgay = string.IsNullOrEmpty(dtp_DenNgay.Text) ? (DateTime?)null : DateTime.Parse(dtp_DenNgay.Text);
            _Id_Tinh = Convert.ToInt32(cbo_TinhThanh.SelectedValue);
            _NoiThucHien = txt_NoiDangKy.Text.Trim();
            _GhiChu = txt_GhiChu.Text.Trim();
            _NguoiTao = SQLHelper.sUser;
            _NguoiCapNhat= SQLHelper.sUser;
        }

        private void btn_close_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void dgv_BaoHiem_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dgv_BaoHiem.CurrentCell.OwningColumn.Name == "edit_column")
            {
                id_baohiem_value = Convert.ToInt32(dgv_BaoHiem.CurrentRow.Cells["Id"].Value);
                edit = true;
                string sql = string.Empty;
                sql = $@"Select * from tbl_NhanVienBaoHiem where Id = {SQLHelper.rpI(id_baohiem_value)}";
                DataTable dt = new DataTable();
                dt = SQLHelper.ExecuteDt(sql);
                cbo_LoaiBaoHiem.SelectedValue = dt.Rows[0]["LoaiBaoHiem"].ToString();
                txt_SoThe.Text = dt.Rows[0]["SoThe"].ToString();
                dtp_TuNgay.Text = dt.Rows[0]["TuNgay"].ToString();
                dtp_DenNgay.Text = dt.Rows[0]["DenNgay"].ToString();
                cbo_TinhThanh.SelectedValue = dt.Rows[0]["Id_Tinh"].ToString();
                txt_NoiDangKy.Text = dt.Rows[0]["NoiThucHien"].ToString();
                txt_GhiChu.Text = dt.Rows[0]["GhiChu"].ToString();
                chk_Active.Checked = (dt.Rows[0]["IsActive"].ToString() == "False" ? false : true);
            }
            else if (e.RowIndex >= 0 && e.ColumnIndex == dgv_BaoHiem.Columns["delete_column"].Index)
            {
                try
                {
                    DialogResult result = RJMessageBox.Show("Bạn có chác muốn xóa?", "Thông báo", MessageBoxButtons.YesNo);
                    if (result == DialogResult.Yes)
                    {
                        string sql = string.Format("update tbl_NhanVienBaoHiem set del_flg = 1 where Id = '{0}'", dgv_BaoHiem.CurrentRow.Cells["Id"].Value);
                        if (SQLHelper.ExecuteSql(sql) == 1)
                        {
                            RJMessageBox.Show("Xóa thành công", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            LoadData();
                            personnel.load_baohiem();
                        }
                    }
                }
                catch (Exception ex)
                {
                    RJMessageBox.Show(ex.Message, "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void frm_insurance_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
            {
                this.Close();
            }
        }
    }
}
