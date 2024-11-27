using System;
using System.Data;
using System.Linq;
using System.Windows.Forms;
using TENTAC_HRM.Custom;
using TENTAC_HRM.Forms.Main;

namespace TENTAC_HRM.Forms.Category
{
    public partial class frm_department : Form
    {
        private bool isCollapsed = true;
        int active_value;
        string cty_value;
        string khuvuc_value;
        string phongban_value;
        string chucvu_value;
        string tungay_value;
        string denngay_value;
        string soquyetdinh_value;
        string ghichu_value;
        string nguoitao_value;
        DataProvider provider = new DataProvider();
        frm_personnel personnel;
        public bool edit { get; set; } = false;
        public string _ma_nhan_vien { get; set; }
        public string id_congtac_value { get; set; }
        public frm_department(frm_personnel _personnel)
        {
            InitializeComponent();
            personnel = _personnel;
        }

        private void frm_department_Load(object sender, EventArgs e)
        {
            pl_information.Width = 0;
            load_nhanvien_phongban();
            load_chucvu();
            //load_phongban();
            load_donvi();
            load_nhanvien();
            //load_khuvuc();
            cbo_nhanvien.SelectedValue = _ma_nhan_vien;
        }
        private void load_nhanvien()
        {
            cbo_nhanvien.DataSource = provider.load_nhanvien();
            cbo_nhanvien.DisplayMember = "name";
            cbo_nhanvien.ValueMember = "value";
        }
        private void load_nhanvien_phongban()
        {
            string sql = string.Format("select a.id_cong_tac,b.ten_phong_ban as cong_ty,c.ten_phong_ban as khu_vuc,d.ten_phong_ban as phong_ban,e.ten_chuc_vu as chuc_vu,a.tu_ngay,a.den_ngay,case when a.is_active = 1 then 'true' else 'false' end as is_active " +
                        "from nhanvien_phongban a " +
                        "left join phong_ban b on a.ma_cong_ty = b.ma_phong_ban and id_loai_phong_ban = 1 " +
                        "left join phong_ban c on c.ma_phong_ban = a.ma_khu_vuc "+
                        "left join phong_ban d on d.ma_phong_ban = a.ma_phong_ban "+
                        "left join chuc_vu e on e.ma_chuc_vu = a.ma_chuc_vu " +
                        "where a.ma_nhan_vien = '{0}' and a.del_flg = 0", _ma_nhan_vien);
            DataTable dt = new DataTable();
            dt = SQLHelper.ExecuteDt(sql);
            dgv_nhanvien_phongban.DataSource = dt;
        }

        private void load_donvi()
        {
            cbo_donvi.DataSource = provider.load_treeview(1);
            cbo_donvi.DisplayMember = "name";
            cbo_donvi.ValueMember = "id";
        }

        private void load_chucvu()
        {
            string sql = string.Format("select ma_chuc_vu,ten_chuc_vu from chuc_vu");
            DataTable dt = SQLHelper.ExecuteDt(sql);
            cbo_chuc_vu.DataSource = dt;
            cbo_chuc_vu.DisplayMember = "ten_chuc_vu";
            cbo_chuc_vu.ValueMember = "ma_chuc_vu";
        }
        private void load_phongban(string id)
        {
            string sql = string.Format("select ma_phong_ban,ten_phong_ban from phong_ban where ma_phong_ban_root = '{0}' and del_flg = 0", id);
            DataTable dt = SQLHelper.ExecuteDt(sql);
            cbo_phongban.DataSource = dt;
            cbo_phongban.DisplayMember = "ten_phong_ban";
            cbo_phongban.ValueMember = "ma_phong_ban";
        }
        private void load_khuvuc()
        {
            DataTable dt = provider.load_treeview(2);
            cbo_khuvuc.DataSource = dt;
            cbo_khuvuc.DisplayMember = "name";
            cbo_khuvuc.ValueMember = "id";
        }
        private void btn_add_Click(object sender, EventArgs e)
        {
            isCollapsed = true;
            btn_luu.Text = "Lưu";
            timer1.Start();

            pl_donvi.Enabled = true;
            edit = false;
            btn_luu.Text = "Lưu";
            dtp_tu_ngay.CustomFormat = " ";
            dtp_den_ngay.CustomFormat = " ";
            txt_mo_ta.Text = "";
            chk_hieu_luc.Checked = false;
        }

        private void dtp_tu_ngay_ValueChanged(object sender, EventArgs e)
        {
            dtp_tu_ngay.CustomFormat = "yyyy/MM/dd";
        }

        private void dtp_den_ngay_ValueChanged(object sender, EventArgs e)
        {
            dtp_den_ngay.CustomFormat = "yyyy/MM/dd";
        }

        private void btn_huy_Click(object sender, EventArgs e)
        {
            isCollapsed = false;
            timer1.Start();
            pl_donvi.Enabled = false;
        }

        private void btn_luu_Click(object sender, EventArgs e)
        {
            if (edit == true)
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
                set_value_text();
                string sql = string.Format("UPDATE nhanvien_phongban set is_active = {1},ma_cong_ty = '{2}',ma_phong_ban = '{3}',ma_chuc_vu = '{4}'," +
                    "tu_ngay = '{5}',den_ngay = '{6}',so_quyet_dinh = N'{7}',ghi_chu = '{8}',ma_khu_vuc = '{9}',ngay_cap_nhat = GETDATE() " +
                    "where id_cong_tac = {0}", id_congtac_value,
                    active_value, cty_value, phongban_value, chucvu_value,
                    tungay_value, denngay_value, soquyetdinh_value, ghichu_value, khuvuc_value);
                if (SQLHelper.ExecuteSql(sql) == 1)
                {
                    RJMessageBox.Show("Thêm thành công", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    load_nhanvien_phongban();
                    personnel.LoadNhanVienPhongBan();
                }
            }
            catch (Exception ex)
            {
                RJMessageBox.Show(ex.Message, "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void save_data()
        {
            try
            {
                set_value_text();
                string sql = string.Format("insert into nhanvien_phongban(ma_nhan_vien,is_active,ma_cong_ty,ma_phong_ban,ma_chuc_vu,tu_ngay,den_ngay," +
                    "so_quyet_dinh,ghi_chu,id_nguoi_tao,ma_khu_vuc) " +
                    "values('{0}',{1},'{2}','{3}','{4}','{5}','{6}','{7}',N'{8}','{9}','{10}')",
                    _ma_nhan_vien, active_value, cty_value, phongban_value, chucvu_value, tungay_value, denngay_value,
                    soquyetdinh_value, ghichu_value, nguoitao_value, khuvuc_value);
                if (SQLHelper.ExecuteSql(sql) == 1)
                {
                    RJMessageBox.Show("Thêm thành công", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    load_nhanvien_phongban();
                    personnel.LoadNhanVienPhongBan();
                }
            }
            catch (Exception ex)
            {
                RJMessageBox.Show(ex.Message, "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void set_value_text()
        {
            _ma_nhan_vien = cbo_nhanvien.SelectedValue.ToString();
            active_value = chk_hieu_luc.Checked ? 1 : 0;
            cty_value = cbo_donvi.SelectedValue.ToString();
            phongban_value = cbo_phongban.SelectedValue.ToString();
            chucvu_value = cbo_chuc_vu.SelectedValue.ToString();
            tungay_value = DateTime.Parse(dtp_tu_ngay.Text).ToString("yyyy/MM/dd");
            denngay_value = DateTime.Parse(dtp_den_ngay.Text).ToString("yyyy/MM/dd");
            soquyetdinh_value = txt_so_quyet_dinh.Text.ToString();
            ghichu_value = txt_mo_ta.Text.ToString();
            nguoitao_value = SQLHelper.sIdUser;
            khuvuc_value = cbo_khuvuc.SelectedValue.ToString();
        }

        private void dgv_nhanvien_phongban_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dgv_nhanvien_phongban.CurrentCell.OwningColumn.Name == "edit_column")
            {
                isCollapsed = true;
                timer1.Start();
                edit = true;
                pl_donvi.Enabled = true;
                string sql = string.Format("select * from nhanvien_phongban where id_cong_tac = {0}", dgv_nhanvien_phongban.CurrentRow.Cells["id_cong_tac"].Value.ToString());
                DataTable dt = new DataTable();
                dt = SQLHelper.ExecuteDt(sql);
                if (dt.Rows.Count > 0)
                {
                    id_congtac_value = dt.Rows[0]["id_cong_tac"].ToString();
                    cbo_donvi.SelectedValue = dt.Rows[0]["ma_cong_ty"].ToString();
                    cbo_phongban.SelectedValue = dt.Rows[0]["ma_phong_ban"].ToString();
                    cbo_chuc_vu.SelectedValue = dt.Rows[0]["ma_chuc_vu"].ToString();
                    dtp_tu_ngay.Text = dt.Rows[0]["tu_ngay"].ToString();
                    dtp_den_ngay.Text = dt.Rows[0]["den_ngay"].ToString();
                    txt_so_quyet_dinh.Text = dt.Rows[0]["so_quyet_dinh"].ToString();
                    txt_mo_ta.Text = dt.Rows[0]["ghi_chu"].ToString();
                    chk_hieu_luc.Checked = dt.Rows[0]["is_active"].ToString() == "1" ? true : false;
                }
                btn_luu.Text = "cập nhật";
            }
        }

        private void dtp_tu_ngay_KeyDown(object sender, KeyEventArgs e)
        {
            if ((e.KeyCode == Keys.Back) || e.KeyCode == Keys.Delete)
            {
                dtp_tu_ngay.CustomFormat = " ";
            }
        }

        private void dtp_den_ngay_KeyDown(object sender, KeyEventArgs e)
        {
            if ((e.KeyCode == Keys.Back) || e.KeyCode == Keys.Delete)
            {
                dtp_den_ngay.CustomFormat = " ";
            }
        }

        private void btn_close_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void cbo_donvi_SelectedValueChanged(object sender, EventArgs e)
        {
            DataRowView vrow = (DataRowView)cbo_donvi.SelectedItem;
            string row = vrow.Row.ItemArray[0].ToString();
            if (!string.IsNullOrEmpty(row))
            {
                load_khuvuc();
            }
        }

        private void cbo_khuvuc_SelectedValueChanged(object sender, EventArgs e)
        {
            DataRowView vrow = (DataRowView)cbo_khuvuc.SelectedItem;
            string row = vrow.Row.ItemArray[0].ToString();
            if (!string.IsNullOrEmpty(row))
            {
                load_phongban(row);
            }
        }

        private void cbo_phongban_SelectedValueChanged(object sender, EventArgs e)
        {
            //DataRowView vrow = (DataRowView)cbo_phongban.SelectedItem;
            //string row = vrow.Row.ItemArray[0].ToString();
            //if (!string.IsNullOrEmpty(row))
            //{
            //    load_chucvu();
            //}
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            if (isCollapsed)
            {
                pl_information.Width += 10;
                if (pl_information.Size == pl_information.MaximumSize)
                {
                    timer1.Stop();
                    isCollapsed = false;
                }
            }
            else
            {
                pl_information.Width -= 10;
                if (pl_information.Size == pl_information.MinimumSize)
                {
                    timer1.Stop();
                    isCollapsed = true;
                }
            }
        }

        private void frm_department_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
            {
                this.Close();
            }
        }

        private void btn_delete_Click(object sender, EventArgs e)
        {
            try
            {
                DialogResult result = RJMessageBox.Show("Bạn có chác muốn xóa?", "Thông báo", MessageBoxButtons.YesNo);
                if (result == DialogResult.Yes)
                {
                    string sql = string.Format("update nhanvien_phongban set del_flg = 1 where id_cong_tac = '{0}'", dgv_nhanvien_phongban.CurrentRow.Cells["id_cong_tac"].Value);
                    if (SQLHelper.ExecuteSql(sql) == 1)
                    {
                        RJMessageBox.Show("Xóa thành công", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
            }
            catch (Exception ex)
            {

                RJMessageBox.Show(ex.Message,"Thông báo",MessageBoxButtons.OK,MessageBoxIcon.Error);
            }
        }
    }
}
