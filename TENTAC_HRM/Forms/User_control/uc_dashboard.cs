using System;
using System.Windows.Forms;
using TENTAC_HRM.Properties;

namespace TENTAC_HRM.Forms.User_control
{
    public partial class uc_dashboard : UserControl
    {
        Label lb_menu;
        Panel panel = new Panel();
        private bool isCollapsed = false;
        DataProvider provider = new DataProvider();
        public static uc_dashboard _instance;
        public static uc_dashboard Instance
        {
            get
            {
                if (_instance == null)
                    _instance = new uc_dashboard();
                return _instance;
            }
        }
        public uc_dashboard()
        {
            InitializeComponent();
        }

        private void uc_dashboard_Load(object sender, EventArgs e)
        {
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            if (isCollapsed)
            {
                lb_menu.Image = Resources.up_arrow;
                panel.Height += 10;
                if (panel.Size == panel.MaximumSize)
                {
                    timer1.Stop();
                    isCollapsed = false;
                }
            }
            else
            {
                lb_menu.Image = Resources.dow_arrow;
                panel.Height -= 10;
                if (panel.Size == panel.MinimumSize)
                {
                    timer1.Stop();
                    isCollapsed = true;
                }
            }
        }
    }
}
