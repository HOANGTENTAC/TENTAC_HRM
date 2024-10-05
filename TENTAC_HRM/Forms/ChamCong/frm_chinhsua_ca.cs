using System;
using System.Data;
using System.Windows.Forms;
using TENTAC_HRM.Custom;

namespace TENTAC_HRM.ChamCong
{
    public partial class frm_chinhsua_ca : Form
    {
        public bool edit { get; set; }
        public string _ma_ca { get; set; }
        public frm_chinhsua_ca()
        {
            InitializeComponent();
        }

        private void frm_chinhsua_ca_Load(object sender, EventArgs e)
        {
            if(edit)
            {
                txt_ma.Enabled = false;
                string sql = string.Format("select * from dic_calamviec where ma_ca = '{0}' and del_flg = 0",_ma_ca);
                DataTable dt = new DataTable();
                dt = SQLHelper.ExecuteDt(sql);
                if(dt.Rows.Count > 0)
                {
                    txt_ma.Text = dt.Rows[0]["ma_ca"].ToString();
                    txt_ten.Text = dt.Rows[0]["ten_ca"].ToString();
                    chk_cadem.Checked = bool.Parse(dt.Rows[0]["ca_dem"].ToString());
                    dtp_giovao.Text = dt.Rows[0]["thoigian_batdau"].ToString();
                    dtp_giora.Text = dt.Rows[0]["thoigian_ketthuc"].ToString();
                    dtp_giovao_tu.Text = dt.Rows[0]["thoigian_batdau1"].ToString();
                    dtp_giovao_den.Text = dt.Rows[0]["thoigian_ketthuc1"].ToString();
                    dtp_giora_tu.Text = dt.Rows[0]["thoigian_batdau2"].ToString();
                    dtp_giora_den.Text = dt.Rows[0]["thoigian_ketthuc2"].ToString();
                    nmr_di_tre.Value = int.Parse(dt.Rows[0]["dimuon_phut"].ToString());
                    nmr_ve_som.Value = int.Parse(dt.Rows[0]["vesom_phut"].ToString());
                    chk_nghi_giua_ca.Checked = bool.Parse(dt.Rows[0]["nghigiuaca"].ToString());
                    dtp_batdau_nghi.Text = dt.Rows[0]["nghigiuaca_batdau"].ToString();
                    dtp_ketthuc_nghi.Text = dt.Rows[0]["nghigiuaca_ketthuc"].ToString();
                    chk_tinhca.Checked = bool.Parse(dt.Rows[0]["tinh_ca"].ToString());
                    nmr_tangca_toithieu.Text = dt.Rows[0]["sophut_toithieu"].ToString();
                    nmr_tangca_toida.Text = dt.Rows[0]["sophut_toida"].ToString();
                    txt_ghi_chu.Text = dt.Rows[0]["ghichu"].ToString();
                }
            }
        }

        private void btn_close_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btn_save_Click(object sender, EventArgs e)
        {
            if(edit)
            {
                update_data();
            }
            else
            {
                string sql = string.Format("select * from dic_calamviec where ma_ca = '{0}'",txt_ma.Text);
                if(SQLHelper.ExecuteDt(sql).Rows.Count > 0)
                {
                    RJMessageBox.Show("Ca " + txt_ma.Text + " đã có trong hệ thống", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    txt_ma.Focus();
                }
                else
                {
                    insert_data();
                }
            }
        }
        private void insert_data()
        {
            try {
                string sql = string.Format("insert into dic_calamviec(ma_ca,ten_ca,thoigian_batdau,thoigian_ketthuc,ca_dem," +
                    "thoigian_batdau1,thoigian_batdau2,thoigian_ketthuc1,thoigian_ketthuc2,dimuon_phut,vesom_phut," +
                    "nghigiuaca_batdau,nghigiuaca_ketthuc,tong_phut,tong_gio,sophut_toithieu,sophut_toida," +
                    "ghichu,nghigiuaca,tinh_ca,id_nguoi_tao) " +
                    "values('{0}',N'{1}','{2}','{3}','{4}'," +
                    "'{5}','{6}','{7}','{8}','{9}','{10}'," +
                    "'{11}','{12}','{13}','{14}','{15}','{16}'," +
                    "N'{17}','{18}','{19}','{20}')",
                    txt_ma.Text,txt_ten.Text,dtp_giovao.Value.ToString("yyyy/MM/dd HH:mm:ss"),dtp_giora.Value.ToString("yyyy/MM/dd HH:mm:ss"), chk_cadem.Checked,
                    dtp_giovao_tu.Value.ToString("yyyy/MM/dd HH:mm:ss"), dtp_giovao_den.Value.ToString("yyyy/MM/dd HH:mm:ss"), dtp_giora_tu.Value.ToString("yyyy/MM/dd HH:mm:ss"), dtp_giora_den.Value.ToString("yyyy/MM/dd HH:mm:ss"), nmr_di_tre.Value,nmr_ve_som.Value,
                    dtp_batdau_nghi.Value.ToString("yyyy/MM/dd HH:mm:ss"), dtp_ketthuc_nghi.Value.ToString("yyyy/MM/dd HH:mm:ss"), txt_tongso_phut.Text,txt_tongso_gio.Text,nmr_tangca_toithieu.Value,nmr_tangca_toida.Value,
                    txt_ghi_chu.Text,chk_nghi_giua_ca.Checked,chk_tinhca.Checked,SQLHelper.sIdUser);
                if(SQLHelper.ExecuteSql(sql) == 1)
                {
                    RJMessageBox.Show("Thêm thành công", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch(Exception ex) {
                RJMessageBox.Show(ex.Message,"Thông báo",MessageBoxButtons.OK,MessageBoxIcon.Error);
            }
        }
        private void update_data()
        {
            try
            {
                string sql = string.Format("update dic_calamviec set ten_ca = '{1}',thoigian_batdau = '{2}',thoigian_ketthuc = '{3}',ca_dem = '{4}'," +
                    "thoigian_batdau1 = '{5}',thoigian_batdau2 = '{6}', thoigian_ketthuc1 = '{7}',thoigian_ketthuc2 = '{8}',dimuon_phut = '{9}', vesom_phut = '{10}'," +
                    "nghigiuaca_batdau = '{11}',nghigiuaca_ketthuc = '{12}',tong_phut = '{13}',tong_gio = '{14}',sophut_toithieu = '{15}',sophut_toida = '{16}'," +
                    "ghichu = N'{17}',nghigiuaca = '{18}',tinh_ca = '{19}',ngay_cap_nhat = getdate() " +
                    "where ma_ca = '{0}'",
                    txt_ma.Text, txt_ten.Text, dtp_giovao.Value.ToString("yyyy/MM/dd HH:mm:ss"), dtp_giora.Value.ToString("yyyy/MM/dd HH:mm:ss"), chk_cadem.Checked,
                    dtp_giovao_tu.Value.ToString("yyyy/MM/dd HH:mm:ss"), dtp_giovao_den.Value.ToString("yyyy/MM/dd HH:mm:ss"), dtp_giora_tu.Value.ToString("yyyy/MM/dd HH:mm:ss"), dtp_giora_den.Value.ToString("yyyy/MM/dd HH:mm:ss"), nmr_di_tre.Value, nmr_ve_som.Value,
                    dtp_batdau_nghi.Value.ToString("yyyy/MM/dd HH:mm:ss"), dtp_ketthuc_nghi.Value.ToString("yyyy/MM/dd HH:mm:ss"), txt_tongso_phut.Text, txt_tongso_gio.Text, nmr_tangca_toithieu.Value, nmr_tangca_toida.Value,
                    txt_ghi_chu.Text, chk_nghi_giua_ca.Checked, chk_tinhca.Checked);
                if (SQLHelper.ExecuteSql(sql) == 1)
                {
                    RJMessageBox.Show("Cập nhật thành công", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (Exception ex)
            {
                RJMessageBox.Show(ex.Message, "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void dtp_giovao_ValueChanged(object sender, EventArgs e)
        {
            tinh_gio_phut();
        }

        private void dtp_giora_ValueChanged(object sender, EventArgs e)
        {
            tinh_gio_phut();
        }
        private void tinh_gio_phut()
        {
            DateTime giovao;
            DateTime giora;
            DateTime gio_batdau_nghitrua;
            DateTime gio_ketthuc_nghitrua;
            decimal so_gio;
            decimal so_phut;

            giovao = dtp_giovao.Value;
            giora = dtp_giora.Value;
            gio_batdau_nghitrua = dtp_batdau_nghi.Value;
            gio_ketthuc_nghitrua = dtp_ketthuc_nghi.Value;

            TimeSpan giolam = giora.Subtract(giovao);
            TimeSpan nghitrua = gio_ketthuc_nghitrua.Subtract(gio_batdau_nghitrua);
            so_gio = (decimal)((giolam.TotalHours > 0 ? giolam.TotalHours : 0) - (nghitrua.TotalHours > 0 ? nghitrua.TotalHours : 0));
            so_phut = (decimal)((giolam.TotalMinutes> 0 ? giolam.TotalMinutes : 0) - (nghitrua.TotalMinutes > 0 ? nghitrua.TotalMinutes : 0));
            txt_tongso_gio.Text = so_gio > 0 ? so_gio.ToString("0.#") : "0";
            txt_tongso_phut.Text = so_phut > 0 ? so_phut.ToString("0.#") : "0";
        }

        private void chk_tinhca_CheckedChanged(object sender, EventArgs e)
        {
            if(chk_tinhca.Checked)
            {
                nmr_tangca_toithieu.Enabled = true;
                nmr_tangca_toida.Enabled = true;
            }
            else
            {
                nmr_tangca_toithieu.Enabled = false;
                nmr_tangca_toida.Enabled = false;
            }
        }

        private void dtp_batdau_nghi_ValueChanged(object sender, EventArgs e)
        {
            tinh_gio_phut();
        }

        private void dtp_ketthuc_nghi_ValueChanged(object sender, EventArgs e)
        {
            tinh_gio_phut();
        }

        private void chk_nghi_giua_ca_CheckedChanged(object sender, EventArgs e)
        {
            if(chk_nghi_giua_ca.Checked)
            {
                dtp_batdau_nghi.Enabled = true;
                dtp_ketthuc_nghi.Enabled = true;
            }
            else
            {
                dtp_batdau_nghi.Enabled = false;
                dtp_ketthuc_nghi.Enabled = false;
            }
        }
    }
}
