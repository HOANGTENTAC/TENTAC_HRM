﻿using System;
using System.Windows.Forms;

namespace TENTAC_HRM.Tuy_Chon
{
    public partial class frm_tuychon : Form
    {
        DataProvider provider = new DataProvider();
        public frm_tuychon()
        {
            InitializeComponent();
        }

        private void frm_tuychon_Load(object sender, EventArgs e)
        {
            if (tc_congthuc_luong.SelectedTab.Name == "tp_congthuc_luong")
            {
                uc_dinhmuc_luong user = new uc_dinhmuc_luong();
                user = uc_dinhmuc_luong.Instance;
                pl_dinhmucluong.Dock = DockStyle.Fill;

                if (!pl_dinhmucluong.Controls.Contains(user))
                {
                    pl_dinhmucluong.Controls.Add(user);
                    user.Dock = DockStyle.Fill;
                    user.BringToFront();
                }
                else
                {
                    user.BringToFront();
                }
            }
        }

        private void tb_congthuc_luong_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (tc_congthuc_luong.SelectedTab.Name == "tp_congthuc_luong")
            {
                uc_dinhmuc_luong user = new uc_dinhmuc_luong();
                user = uc_dinhmuc_luong.Instance;
                pl_dinhmucluong.Dock = DockStyle.Fill;

                if (!pl_dinhmucluong.Controls.Contains(user))
                {
                    pl_dinhmucluong.Controls.Add(user);
                    user.Dock = DockStyle.Fill;
                    user.BringToFront();
                }
                else
                {
                    user.BringToFront();
                }
            }
        }
    }
}
