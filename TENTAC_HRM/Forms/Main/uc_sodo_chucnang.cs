using System;
using System.Windows.Forms;

namespace TENTAC_HRM.Forms.Main
{
    public partial class uc_sodo_chucnang : UserControl
    {
        public static uc_sodo_chucnang _instance;
        public static uc_sodo_chucnang Instance
        {
            get
            {
                //if (_instance == null)
                _instance = new uc_sodo_chucnang();
                return _instance;
            }
        }
        public uc_sodo_chucnang()
        {
            InitializeComponent();
        }

        private void btn_nhanvien_Click(object sender, EventArgs e)
        {

        }

    }
}
