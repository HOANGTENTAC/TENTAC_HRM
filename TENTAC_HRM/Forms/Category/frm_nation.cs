using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TENTAC_HRM.Forms.Category
{
    public partial class frm_nation : Form
    {
        public frm_nation()
        {
            InitializeComponent();
        }

        private void btn_close_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void frm_nation_Load(object sender, EventArgs e)
        {
            load_data();
        }
        private void load_data()
        {
            string sql = "select id_dan_toc,ma_dan_toc,ten_dan_toc,thu_tu,mo_ta from hrm_dan_toc";
            DataTable dt = new DataTable();
            dt = SQLHelper.ExecuteDt(sql);
            dgv_nation.DataSource = dt;
        }

        private void btn_save_close_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void frm_nation_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
            {
                this.Close();
            }
        }
    }
}
