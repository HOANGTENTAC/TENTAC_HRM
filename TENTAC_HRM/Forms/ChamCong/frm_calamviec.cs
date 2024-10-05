using System;
using System.Windows.Forms;
using TENTAC_HRM.Custom;

namespace TENTAC_HRM.ChamCong
{
    public partial class frm_calamviec : Form
    {
        public frm_calamviec()
        {
            InitializeComponent();
        }

        private void btn_close_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btn_export_Click(object sender, EventArgs e)
        {

        }

        private void btn_print_Click(object sender, EventArgs e)
        {

        }

        private void btn_refresh_Click(object sender, EventArgs e)
        {
            load_data();
        }

        private void btn_delete_Click(object sender, EventArgs e)
        {
            try
            {
                DialogResult d = RJMessageBox.Show("Bạn có chắc muốn xóa", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Information);
                if (d == DialogResult.Yes)
                {
                    string sql = string.Format("update dic_calamviec set del_flg = 1 where ma_ca = '{0}'", dgv_calamviec.CurrentRow.Cells["ma_ca"].Value);
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

        private void btn_update_Click(object sender, EventArgs e)
        {
            frm_chinhsua_ca frm = new frm_chinhsua_ca();
            frm._ma_ca = dgv_calamviec.CurrentRow.Cells["ma_ca"].Value.ToString();
            frm.edit = true;
            frm.ShowDialog();
        }

        private void btn_add_Click(object sender, EventArgs e)
        {
            frm_chinhsua_ca frm = new frm_chinhsua_ca();
            frm.edit = false;
            frm.ShowDialog();
        }

        private void frm_calamviec_Load(object sender, EventArgs e)
        {
            load_data();
        }
        private void load_data()
        {
            string sql = "select ma_ca,ten_ca,thoigian_batdau,thoigian_ketthuc,ghichu from dic_calamviec";
            dgv_calamviec.DataSource = SQLHelper.ExecuteDt(sql);
        }
        private void dgv_calamviec_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dgv_calamviec.CurrentCell.OwningColumn.Name == "edit_column")
            {
                frm_chinhsua_ca frm = new frm_chinhsua_ca();
                frm._ma_ca = dgv_calamviec.CurrentRow.Cells["ma_ca"].Value.ToString();
                frm.edit = true;
                frm.ShowDialog();
            }
        }

        private void dgv_calamviec_CellMouseDoubleClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            frm_chinhsua_ca frm = new frm_chinhsua_ca();
            frm._ma_ca = dgv_calamviec.CurrentRow.Cells["ma_ca"].Value.ToString();
            frm.edit = true;
            frm.ShowDialog();
        }
    }
}
