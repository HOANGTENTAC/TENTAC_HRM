using System;
using System.Windows.Forms;
using TENTAC_HRM.Forms.Chart_Management;

namespace TENTAC_HRM.Forms.Chart_Management
{
    public partial class frm_chart_management : Form
    {
        public frm_chart_management()
        {
            InitializeComponent();
        }

        private void btn_cong_ty_Click(object sender, EventArgs e)
        {
            btn_cong_ty.FlatStyle = FlatStyle.Flat;
            btn_khu_vuc.FlatStyle = FlatStyle.Standard;
            btn_phong_ban.FlatStyle = FlatStyle.Standard;
            btn_chuc_vu.FlatStyle = FlatStyle.Standard;
            btn_cau_truc.FlatStyle = FlatStyle.Standard;
            if (!pl_main.Controls.Contains(uc_cong_ty.Instance))
            {
                pl_main.Controls.Add(uc_cong_ty.Instance);
                uc_cong_ty.Instance.Dock = DockStyle.Fill;
                uc_cong_ty.Instance.BringToFront();
            }
            else
            {
                uc_cong_ty.Instance.BringToFront();
            }
        }

        private void btn_khu_vuc_Click(object sender, EventArgs e)
        {
            btn_cong_ty.FlatStyle = FlatStyle.Standard;
            btn_khu_vuc.FlatStyle = FlatStyle.Flat;
            btn_phong_ban.FlatStyle = FlatStyle.Standard;
            btn_chuc_vu.FlatStyle = FlatStyle.Standard;
            btn_cau_truc.FlatStyle = FlatStyle.Standard;
            if (!pl_main.Controls.Contains(uc_khu_vuc.Instance))
            {
                pl_main.Controls.Add(uc_khu_vuc.Instance);
                uc_khu_vuc.Instance.Dock = DockStyle.Fill;
                uc_khu_vuc.Instance.BringToFront();
            }
            else
            {
                uc_khu_vuc.Instance.BringToFront();
            }
        }

        private void btn_phong_ban_Click(object sender, EventArgs e)
        {
            btn_cong_ty.FlatStyle = FlatStyle.Standard;
            btn_khu_vuc.FlatStyle = FlatStyle.Standard;
            btn_phong_ban.FlatStyle = FlatStyle.Flat;
            btn_chuc_vu.FlatStyle = FlatStyle.Standard;
            btn_cau_truc.FlatStyle = FlatStyle.Standard;
            if (!pl_main.Controls.Contains(uc_phong_ban.Instance))
            {
                pl_main.Controls.Add(uc_phong_ban.Instance);
                uc_phong_ban.Instance.Dock = DockStyle.Fill;
                uc_phong_ban.Instance.BringToFront();
            }
            else
            {
                uc_phong_ban.Instance.BringToFront();
            }
        }

        private void btn_chuc_vu_Click(object sender, EventArgs e)
        {
            btn_cong_ty.FlatStyle = FlatStyle.Standard;
            btn_khu_vuc.FlatStyle = FlatStyle.Standard;
            btn_phong_ban.FlatStyle = FlatStyle.Standard;
            btn_chuc_vu.FlatStyle = FlatStyle.Flat;
            btn_cau_truc.FlatStyle = FlatStyle.Standard;
            if (!pl_main.Controls.Contains(uc_chuc_vu.Instance))
            {
                pl_main.Controls.Add(uc_chuc_vu.Instance);
                uc_chuc_vu.Instance.Dock = DockStyle.Fill;
                uc_chuc_vu.Instance.BringToFront();
            }
            else
            {
                uc_chuc_vu.Instance.BringToFront();
            }
        }

        private void btn_cau_truc_Click(object sender, EventArgs e)
        {
            btn_cong_ty.FlatStyle = FlatStyle.Standard;
            btn_khu_vuc.FlatStyle = FlatStyle.Standard;
            btn_phong_ban.FlatStyle = FlatStyle.Standard;
            btn_chuc_vu.FlatStyle = FlatStyle.Standard;
            btn_cau_truc.FlatStyle = FlatStyle.Flat;
            if (!pl_main.Controls.Contains(uc_cau_truc_cty.Instance))
            {
                pl_main.Controls.Add(uc_cau_truc_cty.Instance);
                uc_cau_truc_cty.Instance.Dock = DockStyle.Fill;
                uc_cau_truc_cty.Instance.BringToFront();
            }
            else
            {
                uc_cau_truc_cty.Instance.BringToFront();
            }
        }

        private void frm_chart_management_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
            {
                this.Close();
            }
        }

        private void frm_chart_management_Load(object sender, EventArgs e)
        {
            btn_cong_ty.PerformClick();
        }
    }
}
