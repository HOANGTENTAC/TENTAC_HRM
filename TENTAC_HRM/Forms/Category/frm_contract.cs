using System;
using System.Data;
using System.Linq;
using System.Windows.Forms;
using TENTAC_HRM.Custom;
using TENTAC_HRM.Forms.Main;
using TENTAC_HRM.Forms.User_control;

namespace TENTAC_HRM.Forms.Category
{
    public partial class frm_contract : Form
    {
        string id_ma_nhan_vien;
        int is_active_value;
        string loaihopdong_value;
        string sohopdong_value;
        string ngayky_value;
        string tungay_value;
        string denngay_value;
        string nguoiky_value;
        string ghichu_value;
        string nguoitao_value;
        public bool edit { get; set; } = false;
        DataProvider provider = new DataProvider();
        public string _ma_nhan_vien { get; set; } = "0";
        public int _id_hopdong { get; set; }
        frm_personnel personnel;
        uc_nhansu_hopdong uc_nhansu_hopdong;
        public frm_contract(Form form, UserControl userControl)
        {
            InitializeComponent();
            personnel = (frm_personnel)form;
            uc_nhansu_hopdong = (uc_nhansu_hopdong)userControl;
        }

        private void btn_close_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btn_huy_Click(object sender, EventArgs e)
        {
            pl_hopdong.Enabled = false;
        }

        private void btn_add_Click(object sender, EventArgs e)
        {
            btn_save.Text = "Lưu";
            edit = false;
            pl_hopdong.Enabled = true;
            txt_sohopdong.Text = "";
            txt_nguoiky.Text = "";
            txt_ghichu.Text = "";
            chk_active.Checked = false;
        }

        private void frm_contract_Load(object sender, EventArgs e)
        {
            load_nhanvien();
            load_loaihopdong();
            cbo_nhanvien.SelectedValue = _ma_nhan_vien;
            if (edit == true)
            {
                string sql = string.Format("select * from hrm_nhanvien_hopdong where ma_nhan_vien = '{0}' and is_active = 1", _ma_nhan_vien);
                DataTable dt = new DataTable();
                dt = SQLHelper.ExecuteDt(sql);
                if (dt.Rows.Count > 0)
                {
                    cbo_loaihopdong.SelectedValue = dt.Rows[0]["id_loai_hop_dong"].ToString();
                    txt_sohopdong.Text = dt.Rows[0]["so_hop_dong"].ToString();
                    dtp_tungay.Text = dt.Rows[0]["tu_ngay"].ToString();
                    dtp_denngay.Text = dt.Rows[0]["den_ngay"].ToString();
                    dtp_ngayky.Text = dt.Rows[0]["ngay_ky"].ToString();
                    txt_nguoiky.Text = dt.Rows[0]["nguoi_ky"].ToString();
                    txt_ghichu.Text = dt.Rows[0]["ghi_chu"].ToString();
                    chk_active.Checked = bool.Parse(dt.Rows[0]["is_active"].ToString());
                }
            }
            else
            {
                cbo_nhanvien.Enabled = true;
            }
        }

        private void load_loaihopdong()
        {
            string sql = "select id_loai_hop_dong,ten_loai_hop_dong from hrm_loai_hop_dong";
            DataTable dt = new DataTable();
            dt = SQLHelper.ExecuteDt(sql);
            dt.Rows.Add("0", "");
            cbo_loaihopdong.DataSource = dt.Rows.Cast<DataRow>().OrderBy(x => x.Field<int>("id_loai_hop_dong")).CopyToDataTable();
            cbo_loaihopdong.DisplayMember = "ten_loai_hop_dong";
            cbo_loaihopdong.ValueMember = "id_loai_hop_dong";
        }

        private void load_nhanvien()
        {
            DataTable dt = new DataTable();
            dt = provider.load_nhanvien();
            cbo_nhanvien.DataSource = dt;
            cbo_nhanvien.DisplayMember = "name";
            cbo_nhanvien.ValueMember = "value";
            cbo_nhanvien.AutoCompleteCustomSource.AddRange(dt.AsEnumerable().Select(x => x.Field<string>("value")).ToArray());
        }

        private void btn_save_Click(object sender, EventArgs e)
        {
            if (edit == true)
            {
                update_dada();
            }
            else
            {
                save_dada();
            }

            if (personnel != null)
            {
                personnel.load_hopdong();
            }
            else
            {
                uc_nhansu_hopdong.load_data(1);
            }
        }

        private void update_dada()
        {
            try
            {
                set_value_text();
                string sql = string.Format("UPDATE hrm_nhanvien_hopdong set is_active= {1},id_loai_hop_dong = {2},so_hop_dong = N'{3}',ngay_ky = '{4}'," +
                    "tu_ngay = '{5}', den_ngay = '{6}',nguoi_ky = N'{7}',ghi_chu = N'{8}',ngay_cap_nhat = GETDATE() " +
                    "where id_hop_dong = {0}", _id_hopdong,
                    is_active_value, loaihopdong_value, sohopdong_value, ngayky_value,
                    tungay_value, denngay_value, nguoiky_value, ghichu_value);
                if (SQLHelper.ExecuteSql(sql) == 1)
                {
                    RJMessageBox.Show("Cập nhật thành công", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    this.Close();
                }
            }
            catch (Exception ex)
            {
                RJMessageBox.Show(ex.Message, "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void save_dada()
        {
            try
            {
                set_value_text();
                string sql = string.Format("insert into hrm_nhanvien_hopdong(ma_nhan_vien,is_active,id_loai_hop_dong,so_hop_dong," +
                    "ngay_ky,tu_ngay,den_ngay,nguoi_ky,ghi_chu,id_nguoi_tao) " +
                    "values('{0}',{1},{2},N'{3}','{4}','{5}','{6}','{7}','{8}','{9}')",
                    id_ma_nhan_vien, is_active_value, loaihopdong_value,
                    sohopdong_value, ngayky_value, tungay_value, denngay_value, nguoiky_value, ghichu_value, nguoitao_value);
                if (SQLHelper.ExecuteSql(sql) == 1)
                {
                    RJMessageBox.Show("Thêm thành công", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    this.Close();
                }
            }
            catch (Exception ex)
            {
                RJMessageBox.Show(ex.Message, "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void set_value_text()
        {
            id_ma_nhan_vien = cbo_nhanvien.SelectedValue.ToString();
            is_active_value = (chk_active.Checked == true ? 1 : 0);
            loaihopdong_value = cbo_loaihopdong.SelectedValue.ToString();
            sohopdong_value = txt_sohopdong.Text;
            ngayky_value = DateTime.Parse(dtp_ngayky.Text.ToString()).ToString("yyyy/MM/dd");
            tungay_value = DateTime.Parse(dtp_tungay.Text.ToString()).ToString("yyyy/MM/dd");
            denngay_value = DateTime.Parse(dtp_denngay.Text.ToString()).ToString("yyyy/MM/dd");
            nguoiky_value = txt_nguoiky.Text.ToString();
            ghichu_value = txt_ghichu.Text.ToString();
            nguoitao_value = SQLHelper.sIdUser;
        }

        private void frm_contract_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
            {
                this.Close();
            }
        }

        private void btn_close_Click_1(object sender, EventArgs e)
        {
            this.Close();
        }
        private void cbo_nhanvien_TextUpdate(object sender, EventArgs e)
        {
        }
    }
}
