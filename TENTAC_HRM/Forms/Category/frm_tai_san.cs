using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Windows.Forms;

namespace TENTAC_HRM.Category
{
    public partial class frm_tai_san : Form
    {
        public List<taisan> list_taisan { get; set; }
        public frm_tai_san()
        {
            InitializeComponent();
        }

        private void frm_tai_san_Load(object sender, EventArgs e)
        {
            list_taisan = new List<taisan>();
            load_data();
        }
        private void load_data()
        {
            string sql = "select a.id_tai_san,'false' as chk_column,a.ma_tai_san,a.ten_tai_san,b.type_name as trang_thai,a.so_luong,a.don_gia,a.con_lai " +
                "from danhmuc_taisan a " +
                "join sys_all_type b on a.trang_thai = b.type_id " +
                "where del_flg = 0";
            DataTable dt = new DataTable();
            dt = SQLHelper.ExecuteDt(sql);
            dgv_taisan.DataSource = dt;
        }
        public class taisan
        {
            public int id_tai_san { get; set; }
            public string ma_tai_san { get; set; }
            public string ten_tai_san { get; set; }
        }

        private void dgv_taisan_CellMouseDoubleClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (bool.Parse(dgv_taisan.CurrentRow.Cells["chk_column"].Value.ToString()) == true)
            {
                dgv_taisan.CurrentRow.Cells["chk_column"].Value = false;
                var itemToRemove = list_taisan.Single(r => r.id_tai_san == int.Parse(dgv_taisan.CurrentRow.Cells["id_tai_san"].Value.ToString()));
                list_taisan.Remove(itemToRemove);
            }
            else
            {
                dgv_taisan.CurrentRow.Cells["chk_column"].Value = true;
                list_taisan.Add(new taisan
                {
                    id_tai_san = int.Parse(dgv_taisan.CurrentRow.Cells["id_tai_san"].Value.ToString()),
                    ma_tai_san = dgv_taisan.CurrentRow.Cells["ma_tai_san"].Value.ToString(),
                    ten_tai_san = dgv_taisan.CurrentRow.Cells["ten_tai_san"].Value.ToString()
                });
            }
        }

        private void frm_tai_san_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
            {
                this.Close();
            }
        }
    }
}
