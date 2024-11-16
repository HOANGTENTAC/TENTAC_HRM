using System;
using System.Data;
using System.Linq;
using System.Windows.Forms;
using TENTAC_HRM.Custom;
using TENTAC_HRM.Forms.Main;
using TENTAC_HRM.Forms.User_control;

namespace TENTAC_HRM.Forms.Category
{
    public partial class frm_contract : Form
    {
        string _SoHopDong, _GhiChu, _NguoiTao, _NguoiCapNhat;
        DateTime? _TuNgay, _DenNgay, _NgayKyHD;
        int _IsActive, _LoaiHopDong;
        public bool edit { get; set; } = false;
        DataProvider provider = new DataProvider();
        public string _ma_nhan_vien { get; set; } = "0";
        public int _id_hopdong { get; set; }
        frm_personnel personnel;
        uc_nhansu_hopdong uc_nhansu_hopdong;
        public frm_contract(Form form, UserControl userControl)
        {
            InitializeComponent();
            personnel = (frm_personnel)form;
            uc_nhansu_hopdong = (uc_nhansu_hopdong)userControl;
        }

        private void btn_close_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btn_add_Click(object sender, EventArgs e)
        {
            edit = false;
            txt_SoHopDong.Text = "";
            //txt_nguoiky.Text = "";
            txt_GhiChu.Text = "";
            chk_Active.Checked = false;
        }

        private void frm_contract_Load(object sender, EventArgs e)
        {
            LoadNhanVien();
            LoadLoaiHopDong();
            LoadData();
            //if (edit == true)
            //{
            //    string sql = string.Format("select * from tbl_NhanVienHopDong where MaNhanVien = '{0}' and del_flg = 0", _ma_nhan_vien);
            //    DataTable dt = new DataTable();
            //    dt = SQLHelper.ExecuteDt(sql);
            //    if (dt.Rows.Count > 0)
            //    {
            //        cbo_LoaiHopDong.SelectedValue = dt.Rows[0]["Id_LoaiHopDong"].ToString();
            //        txt_SoHopDong.Text = dt.Rows[0]["SoHopDong"].ToString();
            //        dtp_TuNgay.Text = dt.Rows[0]["TuNgay"].ToString();
            //        dtp_DenNgay.Text = dt.Rows[0]["DenNgay"].ToString();
            //        dtp_NgayKy.Text = dt.Rows[0]["NgayKy"].ToString();
            //        //txt_nguoiky.Text = dt.Rows[0]["NguoiKy"].ToString();
            //        txt_GhiChu.Text = dt.Rows[0]["GhiChu"].ToString();
            //        chk_Active.Checked = bool.Parse(dt.Rows[0]["IsActive"].ToString());
            //    }
            //}
        }
        private void LoadData()
        {
            string sql = string.Empty;
            sql = $@"Select a.Id, b.TenLoai as LoaiHopDong, SoHopDong, NgayKy, TuNgay, DenNgay, IsActive from tbl_NhanVienHopDong a
            Inner join mst_LoaiHopDong b on a.Id_LoaiHopDong = b.Id and b.del_flg = 0
            Where a.MaNhanVien = {SQLHelper.rpStr(_ma_nhan_vien)} and a.del_flg = 0";
            DataTable dt = new DataTable();
            dt = SQLHelper.ExecuteDt(sql);
            dgv_HopDong.DataSource = dt;
        }

        private void LoadLoaiHopDong()
        {
            string sql = "select Id,TenLoai from mst_LoaiHopDong where del_flg = 0";
            DataTable dt = new DataTable();
            dt = SQLHelper.ExecuteDt(sql);
            dt.Rows.Add("0", "");
            cbo_LoaiHopDong.DataSource = dt.Rows.Cast<DataRow>().OrderBy(x => x.Field<int>("Id")).CopyToDataTable();
            cbo_LoaiHopDong.DisplayMember = "TenLoai";
            cbo_LoaiHopDong.ValueMember = "Id";
        }

        private void LoadNhanVien()
        {
            DataTable dt = new DataTable();
            dt = provider.load_nhanvien();
            cbo_NhanVien.DataSource = dt;
            cbo_NhanVien.DisplayMember = "name";
            cbo_NhanVien.ValueMember = "value";
            cbo_NhanVien.SelectedValue = _ma_nhan_vien;
        }

        private void LoadNull()
        {
            edit = false;
            cbo_LoaiHopDong.SelectedValue = "0";
            txt_SoHopDong.Text = string.Empty;
            dtp_TuNgay.Text = string.Empty;
            dtp_DenNgay.Text = string.Empty;
            dtp_NgayKy.Text = string.Empty;
            txt_GhiChu.Text = string.Empty;
        }
        private void btn_clear_Click(object sender, EventArgs e)
        {
            LoadNull();
        }

        private void btn_save_Click(object sender, EventArgs e)
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
                personnel.load_hopdong();
            }
            else
            {
                uc_nhansu_hopdong.load_data(1);
            }
        }

        private void UpdateData()
        {
            try
            {
                string sql = string.Empty;
                sql = $@"Update tbl_NhanVienHopDong Set Id_LoaiHopDong = {SQLHelper.rpI(_LoaiHopDong)}, 
                    SoHopDong = {SQLHelper.rpStr(_SoHopDong)}, NgayKy = {SQLHelper.rpDT(_NgayKyHD)}, TuNgay = {SQLHelper.rpDT(_TuNgay)}, 
                    DenNgay = {SQLHelper.rpDT(_DenNgay)}, GhiChu = {SQLHelper.rpStr(_GhiChu)}, NgayCapNhat = '{DateTime.Now}', 
                    NguoiCapNhat = {SQLHelper.rpStr(_NguoiCapNhat)}, IsActive = {SQLHelper.rpI(_IsActive)}
                    Where Id = {SQLHelper.rpI(_id_hopdong)}";
                if (SQLHelper.ExecuteSql(sql) == 1)
                {
                    if (chk_Active.Checked == true)
                    {
                        string sql_check = string.Format("select * from tbl_NhanVienHopDong where Id_LoaiHopDong = {0} and Id <> {1}", _LoaiHopDong, _id_hopdong);
                        DataTable dt = SQLHelper.ExecuteDt(sql_check);
                        if (dt.Rows.Count > 0)
                        {
                            string update_sql = string.Format("update tbl_NhanVienHopDong set IsActive = 0 where Id_LoaiHopDong = {0} and Id <> {1}", _LoaiHopDong, _id_hopdong);
                            SQLHelper.ExecuteSql(update_sql);
                        }
                    }
                    RJMessageBox.Show("Cập nhật thành công", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    LoadData();
                    personnel.load_hopdong();
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
                sql = $@"Insert into tbl_NhanVienHopDong(MaNhanVien, Id_LoaiHopDong, SoHopDong, NgayKy, TuNgay, DenNgay, GhiChu, NgayTao, NguoiTao, IsActive, del_flg)
                    Values({SQLHelper.rpStr(_ma_nhan_vien)}, {SQLHelper.rpI(_LoaiHopDong)}, {SQLHelper.rpStr(_SoHopDong)}, 
                    {SQLHelper.rpDT(_NgayKyHD)}, {SQLHelper.rpDT(_TuNgay)}, {SQLHelper.rpDT(_DenNgay)}, {SQLHelper.rpStr(_GhiChu)},
                    '{DateTime.Now}', {SQLHelper.rpStr(_NguoiTao)}, {SQLHelper.rpI(_IsActive)}, 0)";

                int id = SQLHelper.ExecuteScalarSql(sql);

                if (chk_Active.Checked == true)
                {
                    string sql_check = string.Format("select * from tbl_NhanVienHopDong where Id_LoaiHopDong = {0} and Id <> {1}", _LoaiHopDong, id);
                    DataTable dt = SQLHelper.ExecuteDt(sql_check);
                    if (dt.Rows.Count > 0)
                    {
                        string update_sql = string.Format("update tbl_NhanVienHopDong set IsActive = 0 where Id_LoaiHopDong = {0} and Id <> {1}", _LoaiHopDong, id);
                        SQLHelper.ExecuteSql(update_sql);
                    }
                }
                LoadData();
                personnel.load_hopdong();
                RJMessageBox.Show("Thêm thành công", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                LoadNull();

            }
            catch (Exception ex)
            {
                RJMessageBox.Show(ex.Message, "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void SetValues()
        {
            _IsActive = (chk_Active.Checked == true ? 1 : 0);
            _LoaiHopDong = Convert.ToInt32(cbo_LoaiHopDong.SelectedValue);
            _SoHopDong = txt_SoHopDong.Text.Trim();
            _NgayKyHD = string.IsNullOrEmpty(dtp_NgayKy.Text) ? (DateTime?)null : DateTime.Parse(dtp_NgayKy.Text);
            _TuNgay = string.IsNullOrEmpty(dtp_TuNgay.Text) ? (DateTime?)null : DateTime.Parse(dtp_TuNgay.Text);
            _DenNgay = string.IsNullOrEmpty(dtp_DenNgay.Text) ? (DateTime?)null : DateTime.Parse(dtp_DenNgay.Text);
            _GhiChu = txt_GhiChu.Text.Trim();
            _NguoiTao = SQLHelper.sUser;
            _NguoiCapNhat = SQLHelper.sUser;
        }

        private void frm_contract_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
            {
                this.Close();
            }
        }
        private void dgv_HopDong_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dgv_HopDong.CurrentCell.OwningColumn.Name == "edit_column")
            {
                _id_hopdong = Convert.ToInt32(dgv_HopDong.CurrentRow.Cells["Id"].Value);
                edit = true;
                string sql = string.Empty;
                sql = $@"Select * from tbl_NhanVienHopDong where Id = {SQLHelper.rpI(_id_hopdong)}";
                DataTable dt = new DataTable();
                dt = SQLHelper.ExecuteDt(sql);
                cbo_LoaiHopDong.SelectedValue = dt.Rows[0]["Id_LoaiHopDong"].ToString();
                txt_SoHopDong.Text = dt.Rows[0]["SoHopDong"].ToString();
                dtp_NgayKy.Text = dt.Rows[0]["NgayKy"].ToString();
                dtp_TuNgay.Text = dt.Rows[0]["TuNgay"].ToString();
                dtp_DenNgay.Text = dt.Rows[0]["DenNgay"].ToString();
                txt_GhiChu.Text = dt.Rows[0]["GhiChu"].ToString();
                chk_Active.Checked = (dt.Rows[0]["IsActive"].ToString() == "False" ? false : true);
            }
            else if (e.RowIndex >= 0 && e.ColumnIndex == dgv_HopDong.Columns["delete_column"].Index)
            {
                try
                {
                    DialogResult result = RJMessageBox.Show("Bạn có chác muốn xóa?", "Thông báo", MessageBoxButtons.YesNo);
                    if (result == DialogResult.Yes)
                    {
                        string sql = string.Format("update tbl_NhanVienHopDong set del_flg = 1 where Id = '{0}'", dgv_HopDong.CurrentRow.Cells["Id"].Value);
                        if (SQLHelper.ExecuteSql(sql) == 1)
                        {
                            RJMessageBox.Show("Xóa thành công", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            LoadData();
                            personnel.load_hopdong();
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
