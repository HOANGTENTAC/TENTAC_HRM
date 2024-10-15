using System;
using System.Windows.Forms;

namespace TENTAC_HRM.Forms.Chart_Management
{
    public partial class uc_cau_truc_cty : UserControl
    {
        public static uc_cau_truc_cty _instance;
        public static uc_cau_truc_cty Instance
        {
            get
            {
                if (_instance == null)
                    _instance = new uc_cau_truc_cty();
                return _instance;
            }
        }
        public uc_cau_truc_cty()
        {
            InitializeComponent();
        }

        private void uc_cau_truc_cty_Load(object sender, EventArgs e)
        {

        }
    }
}
