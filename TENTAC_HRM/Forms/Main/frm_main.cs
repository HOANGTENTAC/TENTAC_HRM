using System;
using System.Runtime.InteropServices;
using System.Windows.Forms;
using TENTAC_HRM.Forms.Nhan_Su;

namespace TENTAC_HRM.Main
{
    public partial class frm_main : Form
    {
        [DllImport("Gdi32.dll", EntryPoint = "CreateRoundRectRgn")]
        private static extern IntPtr CreateRoundRectRgn
        (
            int nLeftRect,
            int nTopRect,
            int nRightRect,
            int nBottomRect,
            int nWidthEllipse,
            int nHeightEllipse
        );
        public frm_main()
        {
            InitializeComponent();
            this.FormBorderStyle = FormBorderStyle.None;
            Region = System.Drawing.Region.FromHrgn(CreateRoundRectRgn(0, 0, Width, Height, 50, 50));
        }
        private void btn_close_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btn_personnel_Click(object sender, EventArgs e)
        {
            frm_nhansu frm = new frm_nhansu();
            frm.ShowDialog();
        }
    }
}
