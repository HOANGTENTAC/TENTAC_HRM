using System;
using System.Data;
using System.Windows.Forms;
using TENTAC_HRM.Custom;

namespace TENTAC_HRM.Forms.Main
{
    public partial class frm_staff_transfer : Form
    {
        DataProvider provider = new DataProvider();
        public string _ma_nhan_vien { get; set; }
        public frm_staff_transfer()
        {
            InitializeComponent();
        }

        private void frm_staff_transfer_Load(object sender, EventArgs e)
        {
            load_phongban();
            load_nhanvien();
            load_truong_bophan();
        }
        private void load_nhanvien()
        {
            cbo_nhanvien.DataSource = provider.load_nhanvien();
            cbo_nhanvien.DisplayMember = "name";
            cbo_nhanvien.ValueMember = "value";
            cbo_nhanvien.SelectedValue = _ma_nhan_vien;
        }
        private void load_chucvu(string machucvu)
        {
            string sql = string.Format("select ma_phong_ban as id,ten_phong_ban as name from phong_ban where ma_phong_ban_root = '{0}'", machucvu);
            DataTable dt = SQLHelper.ExecuteDt(sql);

            cbo_chucvu.DataSource = dt;
            cbo_chucvu.DisplayMember = "name";
            cbo_chucvu.ValueMember = "id";
        }
        private void load_chucvu_moi(string machucvu)
        {
            string sql = string.Format("select ma_phong_ban as id,ten_phong_ban as name from phong_ban where ma_phong_ban_root = '{0}'", machucvu);
            DataTable dt = SQLHelper.ExecuteDt(sql);

            cbo_chucvu_moi.DataSource = dt;
            cbo_chucvu_moi.DisplayMember = "name";
            cbo_chucvu_moi.ValueMember = "id";
        }
        private void load_phongban()
        {
            cbo_bophan.DataSource = provider.load_treeview(3);
            cbo_bophan.DisplayMember = "name";
            cbo_bophan.ValueMember = "id";

            cbo_bophan_moi.DataSource = provider.load_treeview(3);
            cbo_bophan_moi.DisplayMember = "name";
            cbo_bophan_moi.ValueMember = "id";
        }
        private void load_truong_bophan()
        {
            cbo_truong_bophan.DataSource = provider.load_nhanvien();
            cbo_truong_bophan.DisplayMember = "name";
            cbo_truong_bophan.ValueMember = "value";

            cbo_truong_bophan_moi.DataSource = provider.load_nhanvien();
            cbo_truong_bophan_moi.DisplayMember = "name";
            cbo_truong_bophan_moi.ValueMember = "value";
        }
        private void cbo_nhanvien_SelectedValueChanged(object sender, EventArgs e)
        {
            if (cbo_nhanvien.SelectedIndex != 0)
            {
                string sql = string.Format("select ma_cong_ty,ma_khu_vuc,ma_phong_ban,ma_chuc_vu " +
                    "from nhanvien_phongban where ma_nhan_vien = '{0}' and del_flg = 0 and is_active = 1", cbo_nhanvien.SelectedValue.ToString());
                DataTable dt = new DataTable();
                dt = SQLHelper.ExecuteDt(sql);
                if (dt.Rows.Count > 0)
                {
                    cbo_chucvu.SelectedValue = dt.Rows[0]["ma_chuc_vu"].ToString();
                    cbo_chucvu_moi.SelectedValue = dt.Rows[0]["ma_chuc_vu"].ToString();
                    cbo_bophan.SelectedValue = dt.Rows[0]["ma_phong_ban"].ToString();
                }
            }
        }

        private void btn_close_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void frm_staff_transfer_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
            {
                this.Close();
            }
        }

        private void btn_save_Click(object sender, EventArgs e)
        {
            try
            {
                string sql = string.Format("insert into nhanvien_dieuchuyen(solenh_dieuchuyen,ma_nhan_vien," +
                "ngay_di_chuyen,ma_bophan_hientai,truongbophan_hientai," +
                "ma_bophan_chuyenden,truongbophan_chuyenden," +
                "loaicongviec_hientai,chucvu_hientai," +
                "loaicongviec_moi,chucvu_moi,ly_do,ghi_chu) " +
                "values('{0}','{1}','{2}','{3}','{4}','{5}','{6}','{7}','{8}','{9}','{10}',N'{11}',N'{12}')",
                txt_madieuchuyen.Text, cbo_nhanvien.SelectedValue.ToString(), dtp_ngay_dieuchuyen.Value.ToString("yyyy/MM/dd"),
                cbo_bophan.SelectedValue.ToString(), cbo_truong_bophan.SelectedValue.ToString(),
                cbo_bophan_moi.SelectedValue.ToString(), cbo_truong_bophan_moi.SelectedValue.ToString(),
                cbo_loai_congviec.SelectedValue.ToString(), cbo_chucvu.SelectedValue.ToString(),
                cbo_loai_congviec_moi.SelectedValue.ToString(), cbo_chucvu_moi.SelectedValue.ToString(),
                txt_lydo.Texts, txt_ghichu.Texts);
                if (SQLHelper.ExecuteSql(sql) == 1)
                {
                    RJMessageBox.Show("Thêm thành công", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch(Exception ex)
            {
                RJMessageBox.Show(ex.Message, "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void cbo_bophan_moi_SelectedValueChanged(object sender, EventArgs e)
        {
            DataRowView vrow = (DataRowView)cbo_bophan_moi.SelectedItem;
            string row = vrow.Row.ItemArray[0].ToString();
            if (row != "")
            {
                load_chucvu_moi(row);
            }
        }

        private void cbo_bophan_SelectedValueChanged(object sender, EventArgs e)
        {
            DataRowView vrow = (DataRowView)cbo_bophan.SelectedItem;
            string row = vrow.Row.ItemArray[0].ToString();
            if (row != "")
            {
                load_chucvu(row);
            }
        }
    }
}
