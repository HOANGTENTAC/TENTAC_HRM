﻿using System;
using System.Windows.Forms;
using TENTAC_HRM.Custom;

namespace TENTAC_HRM.Forms.Category
{
    public partial class frm_KyHieuChamCong : Form
    {
        public frm_KyHieuChamCong()
        {
            InitializeComponent();
        }

        private void frm_kyhieu_chamcong_Load(object sender, EventArgs e)
        {
            load_data();
        }
        public void load_data()
        {
            string sql = "select * from mst_KyHieu where DelFlg = 0";
            dgv_kyhieu.DataSource = SQLHelper.ExecuteDt(sql);
        }

        private void btn_close_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btn_add_Click(object sender, EventArgs e)
        {
            frm_edit_kyhieu_chamcom frm = new frm_edit_kyhieu_chamcom(this);
            frm.edit = false;
            frm.ShowDialog();
        }

        private void btn_edit_Click(object sender, EventArgs e)
        {
            frm_edit_kyhieu_chamcom frm = new frm_edit_kyhieu_chamcom(this);
            frm.ma_kyhieu = dgv_kyhieu.CurrentRow.Cells["MaKyHieu"].Value.ToString();
            frm.edit = true;
            frm.ShowDialog();
        }

        private void btn_delete_Click(object sender, EventArgs e)
        {
            try
            {
                DialogResult result = RJMessageBox.Show("Bạn có chác muốn xóa?", "Thông báo", MessageBoxButtons.YesNo);
                if (result == DialogResult.Yes)
                {
                    string sql = string.Format("update mst_KyHieu set DelFlg = 1 where MaKyhieu = '{0}'", dgv_kyhieu.CurrentRow.Cells["MaKyhieu"].Value);
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

        private void btn_refresh_Click(object sender, EventArgs e)
        {
            load_data();
        }

        private void btn_print_Click(object sender, EventArgs e)
        {

        }

        private void btn_export_Click(object sender, EventArgs e)
        {

        }

        private void dgv_kyhieu_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dgv_kyhieu.CurrentCell.OwningColumn.Name == "edit_column")
            {
                frm_edit_kyhieu_chamcom frm = new frm_edit_kyhieu_chamcom(this);
                frm.ma_kyhieu = dgv_kyhieu.CurrentRow.Cells["MaKyhieu"].Value.ToString();
                frm.edit = true;
                frm.ShowDialog();
            }
        }

        private void dgv_kyhieu_CellMouseDoubleClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            frm_edit_kyhieu_chamcom frm = new frm_edit_kyhieu_chamcom(this);
            frm.ma_kyhieu = dgv_kyhieu.CurrentRow.Cells["MaKyhieu"].Value.ToString();
            frm.edit = true;
            frm.ShowDialog();
        }
    }
}
