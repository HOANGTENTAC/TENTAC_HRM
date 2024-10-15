using System;
using System.Data;
using System.Linq;
using System.Windows.Forms;
using TENTAC_HRM.Custom;
using TENTAC_HRM.Forms.Main;

namespace TENTAC_HRM.Forms.Category
{
    public partial class frm_pecialize : Form
    {
        frm_personnel personnel;
        public string _id_daotao_value { get; set; }
        public string _ma_nhan_vien { get; set; }
        public bool edit { get; set; }
        DataProvider provider = new DataProvider();
        int active_value;
        string loaidaotao_value;
        string bacdaotao_value;
        string hedaotao_value;
        string nganhdaotao_value;
        string truongdaotao_value;
        string tunnam_value;
        string dennam_value;
        string ngaynhanbang_value;
        string xeploai_value;
        string ghichu_value;
        string nguoitao_value = SQLHelper.sIdUser;
        public frm_pecialize(frm_personnel _personnel)
        {
            InitializeComponent();
            personnel = _personnel;
        }

        private void frm_train_Load(object sender, EventArgs e)
        {
            load_loaidaotao();
            load_bacdaotao();
            load_nganhdaotao();
            load_hedaotao();
            if (edit == true)
            {
                load_data();
                cbo_loaidaotao.Enabled = false;
            }
        }
        private void load_data()
        {
            string sql = string.Format("select * from hrm_nhanvien_daotao where id_dao_tao = {0}", _id_daotao_value);
            DataTable dt = new DataTable();
            dt = SQLHelper.ExecuteDt(sql);
            if (dt.Rows.Count > 0)
            {
                cbo_loaidaotao.SelectedValue = dt.Rows[0]["loai_dao_tao"];
                cbo_bacdaotao.SelectedValue = dt.Rows[0]["id_bac_dao_tao"];
                cbo_hedaotao.SelectedValue = dt.Rows[0]["id_he_dao_tao"];
                cbo_nganhdaotao.SelectedValue = dt.Rows[0]["id_nganh_dao_tao"];
                dtp_tunam.Text = dt.Rows[0]["tu_ngay"].ToString();
                dtp_dennam.Text = dt.Rows[0]["den_ngay"].ToString();
                dtp_namnhanbang.Text = dt.Rows[0]["ngay_nhan_bang"].ToString();
                txt_truongdaotao.Text = dt.Rows[0]["truong_dao_tao"].ToString();
                txt_xeploai.Text = dt.Rows[0]["xep_loai_bang"].ToString();
                txt_ghichu.Text = dt.Rows[0]["ghi_chu"].ToString();
                chk_active.Checked = bool.Parse(dt.Rows[0]["is_active"].ToString());
            }
        }
        private void load_hedaotao()
        {
            string sql = "select id_he_dao_tao,ten_he_dao_tao from hrm_he_dao_tao";
            DataTable dt = new DataTable();
            dt = SQLHelper.ExecuteDt(sql);
            dt.Rows.Add("0", "");
            cbo_hedaotao.DataSource = dt.Rows.Cast<DataRow>().OrderBy(x => x.Field<int>("id_he_dao_tao")).CopyToDataTable();
            cbo_hedaotao.DisplayMember = "ten_he_dao_tao";
            cbo_hedaotao.ValueMember = "id_he_dao_tao";
        }

        private void load_nganhdaotao()
        {
            string sql = "select id_nganh_dao_tao,ten_nganh_dao_tao from hrm_nganh_dao_tao";
            DataTable dt = new DataTable();
            dt = SQLHelper.ExecuteDt(sql);
            dt.Rows.Add("0", "");
            cbo_nganhdaotao.DataSource = dt.Rows.Cast<DataRow>().OrderBy(x => x.Field<int>("id_nganh_dao_tao")).CopyToDataTable();
            cbo_nganhdaotao.DisplayMember = "ten_nganh_dao_tao";
            cbo_nganhdaotao.ValueMember = "id_nganh_dao_tao";
        }

        private void load_bacdaotao()
        {
            string sql = "select id_bac_dao_tao,ten_bac_dao_tao from hrm_bac_dao_tao";
            DataTable dt = new DataTable();
            dt = SQLHelper.ExecuteDt(sql);
            dt.Rows.Add("0", "");
            cbo_bacdaotao.DataSource = dt.Rows.Cast<DataRow>().OrderBy(x => x.Field<int>("id_bac_dao_tao")).CopyToDataTable();
            cbo_bacdaotao.DisplayMember = "ten_bac_dao_tao";
            cbo_bacdaotao.ValueMember = "id_bac_dao_tao";
        }

        private void load_loaidaotao()
        {
            cbo_loaidaotao.DataSource = provider.load_all_type(70);
            cbo_loaidaotao.DisplayMember = "name";
            cbo_loaidaotao.ValueMember = "id";
        }

        private void btn_save_add_Click(object sender, EventArgs e)
        {
            if (edit == true)
            {
                up_date();
            }
            else
            {
                save_data();
            }
        }

        private void up_date()
        {
            try
            {
                set_textvalue();
                string sql = string.Format("update hrm_nhanvien_daotao set id_bac_dao_tao = {1},id_he_dao_tao = {2}, id_nganh_dao_tao = {3}, truong_dao_tao = N'{4}'," +
                    "tu_ngay = '{5}',den_ngay = '{6}',ngay_nhan_bang = '{7}',xep_loai_bang = N'{8}',ghi_chu = N'{9}',ngay_cap_nhat = GETDATE() " +
                    "where id_dao_tao = {0}", _id_daotao_value,
                    bacdaotao_value, hedaotao_value, nganhdaotao_value, truongdaotao_value, tunnam_value, dennam_value, ngaynhanbang_value, xeploai_value, ghichu_value);
                if (SQLHelper.ExecuteSql(sql) == 1)
                {
                    RJMessageBox.Show("Cập nhật thành công", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    personnel.load_chuyenmon();
                }
            }
            catch (Exception ex)
            {
                RJMessageBox.Show(ex.Message, "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btn_save_close_Click(object sender, EventArgs e)
        {
            if (edit == true)
            {
                up_date();
            }
            else
            {
                save_data();
            }
            this.Close();
        }
        private void save_data()
        {
            try
            {
                set_textvalue();
                string sql = string.Format("insert into hrm_nhanvien_daotao(ma_nhan_vien,is_active,loai_dao_tao,id_bac_dao_tao,id_he_dao_tao," +
                    "id_nganh_dao_tao,truong_dao_tao,tu_ngay,den_ngay,ngay_nhan_bang,xep_loai_bang,ghi_chu,id_nguoi_tao) " +
                    "values('{0}',{1},{2},{3},{4},{5},N'{6}','{7}','{8}','{9}',N'{10}',N'{11}','{12}')",
                    _ma_nhan_vien, active_value, loaidaotao_value, bacdaotao_value, hedaotao_value,
                    nganhdaotao_value, truongdaotao_value, tunnam_value, dennam_value, ngaynhanbang_value, xeploai_value, ghichu_value, nguoitao_value);
                if (SQLHelper.ExecuteSql(sql) == 1)
                {
                    RJMessageBox.Show("Thêm thành công", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    cbo_loaidaotao.SelectedValue = 0;
                    cbo_bacdaotao.SelectedValue = 0;
                    cbo_hedaotao.SelectedValue = 0;
                    cbo_nganhdaotao.SelectedValue = 0;
                    txt_truongdaotao.Text = "";
                    txt_xeploai.Text = "";
                    txt_ghichu.Text = "";
                    chk_active.Checked = false;

                    personnel.load_chuyenmon();

                }
            }
            catch (Exception ex)
            {
                RJMessageBox.Show(ex.Message, "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btn_close_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        private void set_textvalue()
        {
            active_value = (chk_active.Checked == true ? 1 : 0);
            loaidaotao_value = cbo_loaidaotao.SelectedValue.ToString();
            bacdaotao_value = cbo_bacdaotao.SelectedValue.ToString();
            hedaotao_value = cbo_hedaotao.SelectedValue.ToString();
            nganhdaotao_value = cbo_nganhdaotao.SelectedValue.ToString();
            truongdaotao_value = txt_truongdaotao.Text;
            tunnam_value = dtp_tunam.Value.ToString("yyyy/MM/dd");
            dennam_value = dtp_dennam.Value.ToString("yyyy/MM/dd");
            ngaynhanbang_value = dtp_namnhanbang.Value.ToString("yyyy/MM/dd");
            xeploai_value = txt_xeploai.Text;
            ghichu_value = txt_ghichu.Text;
            nguoitao_value = SQLHelper.sIdUser;
        }

        private void frm_pecialize_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
            {
                this.Close();
            }
        }
    }
}
