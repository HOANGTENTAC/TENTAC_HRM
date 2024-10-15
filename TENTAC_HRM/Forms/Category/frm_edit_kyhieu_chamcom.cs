using System;
using System.Data;
using System.Windows.Forms;
using TENTAC_HRM.Custom;

namespace TENTAC_HRM.Forms.Category
{
    public partial class frm_edit_kyhieu_chamcom : Form
    {
        public bool edit { get; set; }
        public string ma_kyhieu { get; set; }
        frm_kyhieu_chamcong _frm;
        public frm_edit_kyhieu_chamcom(frm_kyhieu_chamcong frm1)
        {
            InitializeComponent();
            _frm = frm1;
        }

        private void frm_edit_kyhieu_chamcom_Load(object sender, EventArgs e)
        {
            if(edit)
            {
                this.Text = "Cập nhật ký hiệu chấm công";
                txt_ma.Enabled = false;
                txt_ten.Enabled = false;
                string sql = string.Format("select * from dic_kyhieu where ma_kyhieu = '{0}'", ma_kyhieu);
                DataTable dt = new DataTable();
                dt = SQLHelper.ExecuteDt(sql);
                if(dt.Rows.Count > 0)
                {
                    txt_ma.Text = dt.Rows[0]["ma_kyhieu"].ToString();
                    txt_ten.Text = dt.Rows[0]["ten_kyhieu"].ToString();
                    nbr_phantram.Text = dt.Rows[0]["phantram_luong"].ToString();
                }
            }
        }

        private void btn_close_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btn_save_add_Click(object sender, EventArgs e)
        {
            if (edit)
            {
                if(update_data())
                {
                    txt_ma.Text = "";
                    txt_ten.Text = "";
                    nbr_phantram.Value = 0;
                    txt_ma.Enabled = true;
                    txt_ten.Enabled = true;
                }
            }
            else
            {
                if (string.IsNullOrEmpty(txt_ma.Text))
                {
                    RJMessageBox.Show("Mã ký hiệu không được để trống", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
                string check_ma = string.Format("select * from dic_kyhieu where ma_kyhieu = '{0}'", txt_ma.Text);
                if (SQLHelper.ExecuteDt(check_ma).Rows.Count > 0)
                {
                    RJMessageBox.Show("Mã ký hiệu đã tồn tại", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
                if (insert_data())
                {
                    txt_ma.Text = "";
                    txt_ten.Text = "";
                    nbr_phantram.Value = 0;
                }
            }
        }
        private bool insert_data()
        {
            try
            {
                string sql = string.Format("insert into dic_kyhieu(ma_kyhieu,ten_kyhieu,phantram_luong,id_nguoi_tao) " +
                                            "values('{0}',N'{1}','{2}','{3}')", txt_ma.Text, txt_ten.Text, nbr_phantram.Value.ToString(),SQLHelper.sIdUser);
                if (SQLHelper.ExecuteSql(sql) == 1)
                {
                    RJMessageBox.Show("Thêm thành công", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    _frm.load_data();
                    return true;
                }
                return false;
            }
            catch (Exception ex)
            {
                RJMessageBox.Show(ex.Message, "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
        }
        private bool update_data()
        {
            try
            {
                string sql = string.Format("update dic_kyhieu set phantram_luong = '{1}' where ma_kyhieu='{0}'", txt_ma.Text, nbr_phantram.Value.ToString());
                if (SQLHelper.ExecuteSql(sql) == 1)
                {
                    RJMessageBox.Show("Cập nhật thành công", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    _frm.load_data();
                    return true;
                }
                return false;
            }
            catch (Exception ex)
            {
                RJMessageBox.Show(ex.Message, "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
        }

        private void btn_save_close_Click(object sender, EventArgs e)
        {
            if (edit)
            {
                if (update_data())
                {
                    this.Close();
                }
            }
            else
            {
                if (insert_data())
                {
                    this.Close();
                }
            }
        }
    }
}
