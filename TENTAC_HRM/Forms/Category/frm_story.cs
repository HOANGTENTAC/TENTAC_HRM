using System;
using System.Data;
using System.Linq;
using System.Windows.Forms;
using TENTAC_HRM.Custom;
using TENTAC_HRM.Forms.Main;

namespace TENTAC_HRM.Forms.Category
{
    public partial class frm_story : Form
    {
        public string _ma_nhan_vien { get; set; }
        public string _id_tieusu_value { get; set; }
        string tunam_value, dennam_value, congviec_value, nguoitao_value, nguoicapnhat_value;
        int quocgia_value;
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
            load_comboBoxYear();
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
        private void LoadNull()
        {
            txt_cong_viec.Text = string.Empty;
            cbo_QuocGia.SelectedIndex = 0;
        }
        private void load_data()
        {
            string sql = string.Format("select * from tbl_NhanVienTieuSu where Id = {0}", _id_tieusu_value);
            DataTable dt = new DataTable();
            dt = SQLHelper.ExecuteDt(sql);
            if (dt.Rows.Count > 0)
            {
                cbo_TuNam.Text = dt.Rows[0]["TuNam"].ToString();
                cbo_DenNam.Text = dt.Rows[0]["DenNam"].ToString();
                txt_cong_viec.Text = dt.Rows[0]["CongViec"].ToString();
                cbo_QuocGia.SelectedValue = dt.Rows[0]["Id_QuocGia"].ToString();
            }
        }
        private void load_comboBoxYear()
        {
            for (int year = 1990; year <= DateTime.Now.Year; year++)
            {
                cbo_TuNam.Items.Add(year);
                cbo_DenNam.Items.Add(year);
            }
        }

        private void btn_save_close_Click(object sender, EventArgs e)
        {
            if (edit == true)
            {
                UpdateData();
            }
            else
            {
                InsertData();
            }
            this.Close();
        }

        private void load_quocgia()
        {
            string sql = "select Id, TenDiaChi from mst_DonViHanhChinh where ParentId is null";
            DataTable dt = new DataTable();
            dt = SQLHelper.ExecuteDt(sql);
            cbo_QuocGia.DataSource = dt;
            cbo_QuocGia.DisplayMember = "TenDiaChi";
            cbo_QuocGia.ValueMember = "Id";
        }
        private void btn_close_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btn_save_add_Click(object sender, EventArgs e)
        {
            if (edit == true)
            {
                UpdateData();
            }
            else
            {
                InsertData();
            }
        }
        private void InsertData()
        {
            try
            {
                get_value_text();
                string sql = string.Empty;
                sql = $@"Insert into tbl_NhanVienTieuSu(MaNhanVien, TuNam, DenNam, CongViec, Id_QuocGia, NgayTao, NguoiTao, del_flg)
                    Values({SQLHelper.rpStr(_ma_nhan_vien)}, {SQLHelper.rpStr(tunam_value)}, {SQLHelper.rpStr(dennam_value)},
                    {SQLHelper.rpStr(congviec_value)}, {SQLHelper.rpI(quocgia_value)}, '{DateTime.Now}', {SQLHelper.rpStr(nguoitao_value)}, 0)";

                if (SQLHelper.ExecuteSql(sql) == 1)
                {
                    RJMessageBox.Show("Thêm thành công", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    personnel.load_tieusu();
                    LoadNull();
                }
            }
            catch (Exception ex)
            {
                RJMessageBox.Show(ex.Message, "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void UpdateData()
        {
            try
            {
                get_value_text();
                string sql = string.Empty;
                sql = $@"Update tbl_NhanVienTieuSu set TuNam = {SQLHelper.rpStr(tunam_value)}, 
                        DenNam = {SQLHelper.rpStr(dennam_value)}, CongViec = {SQLHelper.rpStr(congviec_value)},
                        Id_QuocGia = {SQLHelper.rpI(quocgia_value)}, NgayCapNhat = '{DateTime.Now}', 
                        NguoiCapNhat = {SQLHelper.rpStr(nguoicapnhat_value)}
                        Where Id = '{_id_tieusu_value}'";
                if (SQLHelper.ExecuteSql(sql) == 1)
                {
                    RJMessageBox.Show("Cập nhật thành công", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    personnel.load_tieusu();
                    LoadNull();
                }
            }
            catch (Exception ex)
            {
                RJMessageBox.Show(ex.Message, "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void get_value_text()
        {
            tunam_value = cbo_TuNam.Text;
            dennam_value = cbo_DenNam.Text;
            congviec_value = txt_cong_viec.Text;
            quocgia_value = Convert.ToInt32(cbo_QuocGia.SelectedValue);
            nguoitao_value = SQLHelper.sUser;
            nguoicapnhat_value = SQLHelper.sUser;
        }
    }
}
