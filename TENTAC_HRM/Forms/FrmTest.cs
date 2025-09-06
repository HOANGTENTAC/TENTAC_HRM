using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Security;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using TENTAC_HRM.Forms.BaoBieu;

namespace TENTAC_HRM.Forms
{
    public partial class FrmTest : Form
    {
        public FrmTest()
        {
            InitializeComponent();
        }

        private void FrmTest_Load(object sender, EventArgs e)
        {
            uc_InBaoBieu user = new uc_InBaoBieu();
            TabPage tp = new TabPage("InbaoBieu")
            {
                Name = "tp_InbaoBieu"
            };
            Panel tb = new Panel
            {
                Dock = DockStyle.Fill,
                Name = "pl_InbaoBieu"
            };
            tb_main.TabPages.Add(tp);
            tb_main.SelectedTab = tp;
            tp.Controls.Add(tb);

            tb.Controls.Add(user);
            user.Dock = DockStyle.Fill;
            user.BringToFront();
        }
    }
}
