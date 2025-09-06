using System;
using System.Data;
using System.Windows.Forms;

namespace TENTAC_HRM.Forms.Tuy_Chon
{
    public partial class uc_dinhmuc_luong : UserControl
    {
        DataProvider provider = new DataProvider();
        public static uc_dinhmuc_luong _instance;
        public static uc_dinhmuc_luong Instance
        {
            get
            {
                _instance = new uc_dinhmuc_luong();
                return _instance;
            }
        }
        public uc_dinhmuc_luong()
        {
            InitializeComponent();
        }

        private void uc_dinhmuc_luong_Load(object sender, EventArgs e)
        {
            load_item_cbo_phicongdoan();
            load_item_cbo_giamtru_tc();
            load_item_cbo_cachtinh_luonggio();
            load_data();
            load_thuesuat();
        }

        private void load_thuesuat()
        {
            string sql = "select ThuNhapTu,ThuNhapDen,ThueLuyTien,ThueSuat from mst_ThueSuat order by BuocThue";
            dgv_mucthue.DataSource = SQLHelper.ExecuteDt(sql);
        }

        private void load_data()
        {
            string sql = "select * from mst_CongThucLuong";
            DataTable dataTable = new DataTable();
            dataTable = SQLHelper.ExecuteDt(sql);
            if (dataTable.Rows.Count > 0)
            {
                txt_bhxh_nguoilaodong.Text = dataTable.Rows[0]["BHXH"].ToString();
                txt_bhyt_nguoilaodong.Text = dataTable.Rows[0]["BHYT"].ToString();
                txt_bhtn_nguoilaodong.Text = dataTable.Rows[0]["BHTN"].ToString();
                txt_bhxh_congty.Text = dataTable.Rows[0]["BHXH1"].ToString();
                txt_bhyt_congty.Text = dataTable.Rows[0]["BHYT1"].ToString();
                txt_bhtn_congty.Text = dataTable.Rows[0]["BHTN1"].ToString();
                txt_dinhmuc_toida.Text = dataTable.Rows[0]["BHXHToiDa"].ToString();
                cbo_phicongdoan_nguoilaodong.SelectedValue = dataTable.Rows[0]["LoaiCongdoan"].ToString();
                txt_phicongdoan_nguoilaodong.Text = dataTable.Rows[0]["GiaTriCongDoan"].ToString();
                cbo_phicongdoan_congty.SelectedValue = dataTable.Rows[0]["LoaiCongdoan1"].ToString();
                txt_phicongdoan_congty.Text = dataTable.Rows[0]["GiaTriCongDoan1"].ToString();
                txt_dinhmuc_congdoan_toida.Text = dataTable.Rows[0]["CongDoanToiDa"].ToString();
                txt_thu_tncn.Text = dataTable.Rows[0]["ThueThuNhap"].ToString();
                txt_giamtrugiacanh.Text = dataTable.Rows[0]["GiamTruThue"].ToString();
                cbo_giamtru_tc_ngaythuong.SelectedValue = dataTable.Rows[0]["LoaiGiamTruThue_NT"].ToString();
                txt_giamtru_tc_ngaythuong.Text = dataTable.Rows[0]["GiaTriGiamTruThue_NT"].ToString();
                cbo_giamtru_tc_ngaychunhat.SelectedValue = dataTable.Rows[0]["LoaiGiamTruThue_CN"].ToString();
                txt_giamtru_tc_ngaythuong.Text = dataTable.Rows[0]["GiaTriGiamTruThue_CN"].ToString();
                cbo_giamtru_tc_ngayle.SelectedValue = dataTable.Rows[0]["LoaiGiamTruThue_NL"].ToString();
                txt_giamtru_tc_ngayle.Text = dataTable.Rows[0]["GiaTriGiamTruThue_NL"].ToString();
                cbo_giamtru_tcd_ngaythuong.SelectedValue = dataTable.Rows[0]["LoaiGiamTruThue_DemNT"].ToString();
                txt_giamtru_tcd_ngaythuong.Text = dataTable.Rows[0]["GiaTriGiamTruThue_DemNT"].ToString();
                cbo_giamtru_tcd_ngaychunhat.SelectedValue = dataTable.Rows[0]["LoaiGiamTruThue_DemCN"].ToString();
                txt_giamtru_tcd_ngaythuong.Text = dataTable.Rows[0]["GiaTriGiamTruThue_DemCN"].ToString();
                cbo_giamtru_tcd_ngayle.SelectedValue = dataTable.Rows[0]["LoaiGiamTruThue_DemNL"].ToString();
                txt_giamtru_tcd_ngayle.Text = dataTable.Rows[0]["GiaTriGiamTruThue_DemNL"].ToString();
                txt_heso_tc_ngaythuong.Text = dataTable.Rows[0]["HeSoLamThemNT"].ToString();
                txt_heso_tc_ngaychunhat.Text = dataTable.Rows[0]["HeSoLamThemNgayCN"].ToString();
                txt_heso_tc_ngayle.Text = dataTable.Rows[0]["HeSoLamThemNL"].ToString();
                txt_heso_tcd_ngaythuong.Text = dataTable.Rows[0]["HeSoLamThem_DemNT"].ToString();
                txt_heso_tcd_chunhat.Text = dataTable.Rows[0]["HeSoLamThem_DemCN"].ToString();
                txt_heso_tcd_ngayle.Text = dataTable.Rows[0]["HeSoLamThem_DemNl"].ToString();
                chk_trutien_ditre_vesom.Checked = bool.Parse(dataTable.Rows[0]["TruTienDiTre_VeSom"].ToString());
                txt_sophut.Text = dataTable.Rows[0]["SoPhutMuon"].ToString();
                cbo_cachtinh_luonggio.SelectedValue = dataTable.Rows[0]["LoaiLuongGio"].ToString();
                txt_lamtron.Text = dataTable.Rows[0]["LamTronLuong"].ToString();
            }
        }
        private void load_item_cbo_phicongdoan()
        {
            cbo_phicongdoan_nguoilaodong.DataSource = item_cbo_phicongdoan();
            cbo_phicongdoan_nguoilaodong.DisplayMember = "name";
            cbo_phicongdoan_nguoilaodong.ValueMember = "id";
            cbo_phicongdoan_congty.DataSource = item_cbo_phicongdoan();
            cbo_phicongdoan_congty.DisplayMember = "name";
            cbo_phicongdoan_congty.ValueMember = "id";
        }
        private void load_item_cbo_giamtru_tc()
        {
            cbo_giamtru_tc_ngaythuong.DataSource = item_cbo_giamtru_tc();
            cbo_giamtru_tc_ngaythuong.DisplayMember = "name";
            cbo_giamtru_tc_ngaythuong.ValueMember = "id";
            cbo_giamtru_tc_ngaychunhat.DataSource = item_cbo_giamtru_tc();
            cbo_giamtru_tc_ngaychunhat.DisplayMember = "name";
            cbo_giamtru_tc_ngaychunhat.ValueMember = "id";
            cbo_giamtru_tc_ngayle.DataSource = item_cbo_giamtru_tc();
            cbo_giamtru_tc_ngayle.DisplayMember = "name";
            cbo_giamtru_tc_ngayle.ValueMember = "id";
            cbo_giamtru_tcd_ngaythuong.DataSource = item_cbo_giamtru_tc();
            cbo_giamtru_tcd_ngaythuong.DisplayMember = "name";
            cbo_giamtru_tcd_ngaythuong.ValueMember = "id";
            cbo_giamtru_tcd_ngaychunhat.DataSource = item_cbo_giamtru_tc();
            cbo_giamtru_tcd_ngaychunhat.DisplayMember = "name";
            cbo_giamtru_tcd_ngaychunhat.ValueMember = "id";
            cbo_giamtru_tcd_ngayle.DataSource = item_cbo_giamtru_tc();
            cbo_giamtru_tcd_ngayle.DisplayMember = "name";
            cbo_giamtru_tcd_ngayle.ValueMember = "id";

        }
        private void load_item_cbo_cachtinh_luonggio()
        {
            DataTable dataTable = new DataTable();
            dataTable.Columns.Add("id");
            dataTable.Columns.Add("name");
            dataTable.Rows.Add("0", "Tính theo lương căn bản");
            dataTable.Rows.Add("1", "Tính theo tổng lương (lương văn bản + phụ cấp)");
            cbo_cachtinh_luonggio.DataSource = dataTable;
            cbo_cachtinh_luonggio.DisplayMember = "name";
            cbo_cachtinh_luonggio.ValueMember = "id";
        }
        private DataTable item_cbo_giamtru_tc()
        {
            DataTable dataTable = new DataTable();
            dataTable.Columns.Add("id");
            dataTable.Columns.Add("name");
            dataTable.Rows.Add("0", "Theo tỷ lệ %");
            dataTable.Rows.Add("1", "Theo tỷ lệ phân số");
            return dataTable;
        }
        private DataTable item_cbo_phicongdoan()
        {
            DataTable dataTable = new DataTable();
            dataTable.Columns.Add("id");
            dataTable.Columns.Add("name");
            dataTable.Rows.Add("0", "Theo tỷ lệ %");
            dataTable.Rows.Add("1", "Theo số tiền");
            return dataTable;
        }

        private void txt_bhxh_nguoilaodong_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!provider.IsValidNumber(e.KeyChar))
            {
                e.Handled = true;
                return;
            }
        }

        private void txt_bhxh_congty_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!provider.IsValidNumber(e.KeyChar))
            {
                e.Handled = true;
                return;
            }
        }

        private void txt_bhyt_nguoilaodong_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!provider.IsValidNumber(e.KeyChar))
            {
                e.Handled = true;
                return;
            }
        }

        private void txt_bhtn_nguoilaodong_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!provider.IsValidNumber(e.KeyChar))
            {
                e.Handled = true;
                return;
            }
        }

        private void txt_bhyt_congty_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!provider.IsValidNumber(e.KeyChar))
            {
                e.Handled = true;
                return;
            }
        }

        private void txt_bhtn_congty_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!provider.IsValidNumber(e.KeyChar))
            {
                e.Handled = true;
                return;
            }
        }

        private void txt_dinhmuc_toida_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!provider.IsValidNumber(e.KeyChar))
            {
                e.Handled = true;
                return;
            }
        }

        private void txt_phicongdoan_nguoilaodong_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!provider.IsValidNumber(e.KeyChar))
            {
                e.Handled = true;
                return;
            }
        }

        private void txt_phicongdoan_congty_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!provider.IsValidNumber(e.KeyChar))
            {
                e.Handled = true;
                return;
            }
        }

        private void txt_dinhmuc_congdoan_toida_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!provider.IsValidNumber(e.KeyChar))
            {
                e.Handled = true;
                return;
            }
        }

        private void txt_thu_tncn_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!provider.IsValidNumber(e.KeyChar))
            {
                e.Handled = true;
                return;
            }
        }

        private void txt_giamtrugiacanh_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!provider.IsValidNumber(e.KeyChar))
            {
                e.Handled = true;
                return;
            }
        }

        private void txt_giamtru_tc_ngaythuong_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!provider.IsValidNumber(e.KeyChar))
            {
                e.Handled = true;
                return;
            }
        }

        private void txt_giamtru_tc_ngaychunhat_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!provider.IsValidNumber(e.KeyChar))
            {
                e.Handled = true;
                return;
            }
        }

        private void txt_giamtru_tc_ngayle_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!provider.IsValidNumber(e.KeyChar))
            {
                e.Handled = true;
                return;
            }
        }

        private void txt_giamtru_tcd_ngaythuong_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!provider.IsValidNumber(e.KeyChar))
            {
                e.Handled = true;
                return;
            }
        }

        private void txt_giamtru_tcd_ngaychunhat_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!provider.IsValidNumber(e.KeyChar))
            {
                e.Handled = true;
                return;
            }
        }

        private void txt_giamtru_tcd_ngayle_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!provider.IsValidNumber(e.KeyChar))
            {
                e.Handled = true;
                return;
            }
        }

        private void txt_heso_tc_ngaythuong_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!provider.IsValidNumber(e.KeyChar))
            {
                e.Handled = true;
                return;
            }
        }

        private void txt_heso_tc_ngaychunhat_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!provider.IsValidNumber(e.KeyChar))
            {
                e.Handled = true;
                return;
            }
        }

        private void txt_heso_tc_ngayle_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!provider.IsValidNumber(e.KeyChar))
            {
                e.Handled = true;
                return;
            }
        }

        private void txt_heso_tcd_ngaythuong_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!provider.IsValidNumber(e.KeyChar))
            {
                e.Handled = true;
                return;
            }
        }

        private void txt_heso_tcd_chunhat_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!provider.IsValidNumber(e.KeyChar))
            {
                e.Handled = true;
                return;
            }
        }

        private void txt_heso_tcd_ngayle_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!provider.IsValidNumber(e.KeyChar))
            {
                e.Handled = true;
                return;
            }
        }

        private void txt_sophut_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!provider.IsValidNumber(e.KeyChar))
            {
                e.Handled = true;
                return;
            }
        }

        private void txt_lamtron_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!provider.IsValidNumber(e.KeyChar))
            {
                e.Handled = true;
                return;
            }
        }

        private void btn_luu_Click(object sender, EventArgs e)
        {

        }
    }
}
