using System;
using System.Data;
using System.Linq;
using System.Windows.Forms;
using TENTAC_HRM.Custom;

namespace TENTAC_HRM.Category
{
    public partial class frm_story : Form
    {
        public string _ma_nhan_vien { get; set; }
        public string _id_tieusu_value { get; set; }
        string tunam_value, dennam_value, congviec_value, quocgia_value, ngaytao_value, nguoitao_value;
        frm_personnel personnel;
        public bool edit { get; set; }
        public frm_story(frm_personnel _personnel)
        {
            InitializeComponent();
            personnel = _personnel;
        }

        private void frm_story_Load(object sender, EventArgs e)
        {
            load_quocgia();
            if (edit == true)
            {
                load_data();
            }
        }
        protected virtual bool IsValidChar(char c)
        {
            return (c >= '0' && c <= '9') || (c == (char)Keys.Back) || (c == (char)Keys.Delete);
        }
        private void event_keypress(KeyPressEventArgs e)
        {
            if (!IsValidChar(e.KeyChar))
            {
                e.Handled = true;
                return;
            }
            base.OnKeyPress(e);
        }
        private void txt_tu_nam_KeyPress(object sender, KeyPressEventArgs e)
        {
            event_keypress(e);
        }

        private void frm_story_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
            {
                this.Close();
            }
        }

        private void load_data()
        {
            string sql = string.Format("select * from hrm_nhanvien_tieusu where id_tieu_su = {0}", _id_tieusu_value);
            DataTable dt = new DataTable();
            dt = SQLHelper.ExecuteDt(sql);
            if (dt.Rows.Count > 0)
            {
                txt_tu_nam.Text = dt.Rows[0]["tu_nam"].ToString();
                txt_den_nam.Text = dt.Rows[0]["den_nam"].ToString();
                txt_cong_viec.Text = dt.Rows[0]["cong_viec"].ToString();
                cbo_quoc_gia.SelectedValue = dt.Rows[0]["id_quoc_gia"].ToString();
            }
        }
        private void load_quocgia()
        {
            string sql = "select id_dia_chi,ten_dia_chi from hrm_dia_chi where id_dia_chi_cha is null";
            DataTable dt = new DataTable();
            dt = SQLHelper.ExecuteDt(sql);
            cbo_quoc_gia.DataSource = dt;
            cbo_quoc_gia.DisplayMember = "ten_dia_chi";
            cbo_quoc_gia.ValueMember = "id_dia_chi";
        }
        private void btn_close_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btn_save_add_Click(object sender, EventArgs e)
        {
            try
            {
                get_value_text();
                string sql = string.Format("insert into hrm_nhanvien_tieusu(ma_nhan_vien,tu_nam,den_nam,cong_viec,id_quoc_gia,ngay_tao,id_nguoi_tao) " +
                    "values('{0}','{1}','{2}',N'{3}',{4},'{5}','{6}')",
                    _ma_nhan_vien, tunam_value, dennam_value, congviec_value, quocgia_value, ngaytao_value, nguoitao_value);
                if (SQLHelper.ExecuteSql(sql) == 1)
                {
                    RJMessageBox.Show("Thêm thành công", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    personnel.load_tieusu();
                }
            }
            catch (Exception ex)
            {
                RJMessageBox.Show(ex.Message, "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void get_value_text()
        {
            tunam_value = txt_tu_nam.Text;
            dennam_value = txt_den_nam.Text;
            congviec_value = txt_cong_viec.Text;
            quocgia_value = cbo_quoc_gia.SelectedValue.ToString();
            ngaytao_value = DateTime.Now.ToString("yyyy/MM/dd");
            nguoitao_value = SQLHelper.sIdUser;
        }
    }
}
