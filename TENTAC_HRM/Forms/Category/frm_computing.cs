using System;
using System.Data;
using System.Windows.Forms;
using TENTAC_HRM.Custom;

namespace TENTAC_HRM.Category
{
    public partial class frm_computing : Form
    {
        DataProvider provider = new DataProvider();
        public string _ma_nhanvien { get; set; } = "0";
        public int _id_tinhoc { get; set; }
        public bool edit { get; set; }
        frm_personnel _Personnel;
        public frm_computing(Form frm)
        {
            InitializeComponent();
            _Personnel = (frm_personnel)frm;
        }
        private void frm_computing_Load(object sender, EventArgs e)
        {
            load_nhanvien();
            load_xeploai();
            if(edit == true)
            {
                load_data();
            }
        }

        private void load_data()
        {
            string sql = string.Format("select * from tin_hoc where id_tin_hoc = '{0}'",_id_tinhoc);
            DataTable dt = SQLHelper.ExecuteDt(sql);
            if(dt.Rows.Count > 0)
            {
                txt_tinhoc.Text = dt.Rows[0]["tin_hoc"].ToString();
                txt_truong.Text = dt.Rows[0]["truong_dao_tao"].ToString();
                dtp_nam.Text = dt.Rows[0]["nam_nhan_bang"].ToString();
                cbo_xeploai.SelectedValue = dt.Rows[0]["xep_loai"].ToString();
            }
        }

        private void load_xeploai()
        {
            cbo_xeploai.DataSource = provider.load_xeploai();
            cbo_xeploai.DisplayMember = "name";
            cbo_xeploai.ValueMember = "id";
        }
        private void load_nhanvien()
        {
            cbo_nhanvien.DataSource = provider.load_nhanvien();
            cbo_nhanvien.DisplayMember = "name";
            cbo_nhanvien.ValueMember = "value";
            cbo_nhanvien.SelectedValue = _ma_nhanvien;
        }
        private void btn_close_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btn_save_Click(object sender, EventArgs e)
        {
            if(edit == true)
            {
                update_data();
            }
            else
            {
                insert_data();
            }
            //_Personnel.load_tinhoc();
        }
        private void insert_data()
        {
            try
            {
                string sql = string.Format("insert into tin_hoc(ma_nhan_vien,tin_hoc,truong_dao_tao,nam_nhan_bang,xep_loai,id_nguoi_tao) " +
                    "values('{0}',N'{1}',N'{2}','{3}',N'{4}','{5}')",
                    cbo_nhanvien.SelectedValue.ToString(), txt_tinhoc.Text, txt_truong.Text, DateTime.Parse(dtp_nam.Text).ToString("yyyy/MM/dd"), cbo_xeploai.SelectedValue.ToString(), SQLHelper.sIdUser);
                if (SQLHelper.ExecuteSql(sql) == 1)
                {
                    RJMessageBox.Show("Thêm thành công", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch(Exception ex)
            {
                RJMessageBox.Show(ex.Message, "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void update_data()
        {
            try
            {
                string sql = string.Format("update tin_hoc set tin_hoc = N'{1}', truong_dao_tao = N'{2}',nam_nhan_bang='{3}',xep_loai= N'{4}',ngay_cap_nhat = GETDATE(),id_nguoi_tao = '{5}' " +
                    "where id_tin_hoc = '{0}'",_id_tinhoc,
                    txt_tinhoc.Text,txt_truong.Text,DateTime.Parse(dtp_nam.Text).ToString("yyyy/MM/dd"),cbo_xeploai.SelectedValue.ToString(), SQLHelper.sIdUser);
                if(SQLHelper.ExecuteSql(sql) ==1 )
                {
                    RJMessageBox.Show("Cập nhật thành công", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (Exception ex)
            {
                RJMessageBox.Show(ex.Message, "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

    }
}
