using System;
using System.Windows.Forms;
using TENTAC_HRM.Properties;

namespace TENTAC_HRM.Forms.Search
{
    public partial class frm_serach_nhanvien : Form
    {
        DataProvider provider = new DataProvider();
        Button btn_menu;
        Panel panel = new Panel();
        private bool isCollapsed = false;
        public string id_nhanvien { get; set; } = "";
        public string chuc_vu { get; set; } = "";
        public string ten_nhanvien { get; set; } = "";
        public frm_serach_nhanvien()
        {
            InitializeComponent();
        }

        private void frm_serach_nhanvien_Load(object sender, EventArgs e)
        {
            search_nhanvien();
            load_loaihopdong();
            load_chucvu();
            load_trangthai_congviec();
            load_quoctich();
            load_dantoc();
            load_gioitinh();
            load_honnhan();
        }
        private void load_honnhan()
        {
            cbo_hon_nhan.DataSource = provider.load_all_type(10);
            cbo_hon_nhan.DisplayMember = "name";
            cbo_hon_nhan.ValueMember = "id";
        }
        public void load_gioitinh()
        {
            cbo_gioi_tinh.DataSource = provider.load_gioitinh();
            cbo_gioi_tinh.DisplayMember = "name";
            cbo_gioi_tinh.ValueMember = "id";
        }
        public void load_dantoc()
        {
            cbo_dan_toc.DataSource = provider.load_dantoc();
            cbo_dan_toc.DisplayMember = "name";
            cbo_dan_toc.ValueMember = "id";
        }
        public void load_quoctich()
        {
            cbo_quoc_tich.DataSource = provider.load_diachi(20);
            cbo_quoc_tich.DisplayMember = "name";
            cbo_quoc_tich.ValueMember = "id";
        }
        public void load_trangthai_congviec()
        {
            cbo_trangthai.DataSource = provider.load_all_type(1);
            cbo_trangthai.DisplayMember = "name";
            cbo_trangthai.ValueMember = "id";
        }
        public void load_loaihopdong()
        {
            cbo_loaihopdong.DataSource = provider.load_loaihopdong();
            cbo_loaihopdong.DisplayMember = "name";
            cbo_loaihopdong.ValueMember = "id";
        }
        public void load_chucvu()
        {
            cbo_chucvu.DataSource = provider.LoadChucVu();
            cbo_chucvu.DisplayMember = "name";
            cbo_chucvu.ValueMember = "id";
        }
        private void search_nhanvien()
        {
            string sql = string.Format("select a.id_nhan_vien,a.ma_nhan_vien,a.ho_ten,a.ngay_sinh,case when a.gioi_tinh = 'false' then N'Nữ' else N'Nam' end as gioi_tinh,c.ten_chuc_vu,d.ten_phong_ban, " +
                "a.email,a.dien_thoai_dd as dien_thoai,so_cccd as cccd " +
                "from hrm_nhan_vien a " +
                "left join nhanvien_phongban b on a.ma_nhan_vien = b.ma_nhan_vien " +
                "left join chuc_vu c on b.ma_chuc_vu = c.ma_chuc_vu " +
                "left join phong_ban d on d.ma_phong_ban = b.ma_phong_ban " +
                "left join hrm_nhanvien_hopdong e on e.ma_nhan_vien = a.ma_nhan_vien " +
                "where a.del_flg = 0 ");
            if (!string.IsNullOrEmpty(txt_search.Text))
            {
                sql = sql + string.Format(" and a.ma_nhan_vien like N'%{0}%' or ho_ten like N'%{0}%' " +
                    "or c.ten_phong_ban like '%{0}%' or d.ten_phong_ban like '%{0}%' or a.dien_thoai_dd like '%{0}%' or a.so_cccd like '%{0}%' ", txt_search.Text);
            }
            if (cbo_loaihopdong.SelectedValue != null && cbo_loaihopdong.SelectedValue.ToString() != "0")
            {
                sql = sql + string.Format(" and id_loai_hop_dong = '{0}'", cbo_loaihopdong.SelectedValue.ToString());
            }
            if (cbo_chucvu.SelectedValue != null && cbo_chucvu.SelectedValue.ToString() != "0")
            {
                sql = sql + string.Format(" and b.ma_chuc_vu = '{0}'", cbo_chucvu.SelectedValue.ToString());
            }
            if (cbo_trangthai.SelectedValue != null && cbo_trangthai.SelectedValue.ToString() != "0")
            {
                sql = sql + string.Format(" and a.id_trang_thai = '{0}'", cbo_trangthai.SelectedValue.ToString());
            }
            if (cbo_quoc_tich.SelectedValue != null && cbo_quoc_tich.SelectedValue.ToString() != "0")
            {
                sql = sql + string.Format(" and a.id_quoc_tich = '{0}'", cbo_quoc_tich.SelectedValue.ToString());
            }
            if (cbo_dan_toc.SelectedValue != null && cbo_dan_toc.SelectedValue.ToString() != "0")
            {
                sql = sql + string.Format(" and a.id_dan_toc = '{0}'", cbo_dan_toc.SelectedValue.ToString());
            }
            if (cbo_gioi_tinh.SelectedValue != null && cbo_gioi_tinh.SelectedValue.ToString() != "")
            {
                sql = sql + string.Format(" and a.gioi_tinh = '{0}'", cbo_gioi_tinh.SelectedValue.ToString());
            }
            if (cbo_hon_nhan.SelectedValue != null && cbo_hon_nhan.SelectedValue.ToString() != "0")
            {
                sql = sql + string.Format(" and a.hon_nhan = '{0}'", cbo_hon_nhan.SelectedValue.ToString());
            }
            dgv_nhanvien.DataSource = SQLHelper.ExecuteDt(sql);
        }

        private void txt_search_TextChanged(object sender, EventArgs e)
        {
            search_nhanvien();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            if (isCollapsed)
            {
                btn_menu.Image = Resources.up_arrow;
                panel.Height += 10;
                if (panel.Size == panel.MaximumSize)
                {
                    timer1.Stop();
                    isCollapsed = false;
                }
            }
            else
            {
                btn_menu.Image = Resources.dow_arrow;
                panel.Height -= 10;
                if (panel.Size == panel.MinimumSize)
                {
                    timer1.Stop();
                    isCollapsed = true;
                }
            }
        }

        private void btn_coban_Click(object sender, EventArgs e)
        {
            panel = pl_coban;
            btn_menu = btn_coban;
            start_timer();
        }
        public void start_timer()
        {
            if (panel.Size == panel.MaximumSize)
            {
                isCollapsed = false;
            }
            else if (panel.Size == panel.MinimumSize)
            {
                isCollapsed = true;
            }
            timer1.Start();
        }

        private void btn_chitiet_Click(object sender, EventArgs e)
        {
            panel = pl_chitiet;
            btn_menu = btn_chitiet;
            start_timer();
        }


        private void cbo_loaihopdong_SelectionChangeCommitted(object sender, EventArgs e)
        {
            search_nhanvien();
        }

        private void cbo_chucvu_SelectionChangeCommitted(object sender, EventArgs e)
        {
            search_nhanvien();
        }

        private void cbo_trangthai_SelectionChangeCommitted(object sender, EventArgs e)
        {
            search_nhanvien();
        }

        private void btn_close_Click(object sender, EventArgs e)
        {
            id_nhanvien = "";
            ten_nhanvien = "";
            chuc_vu = "";
            this.Close();
        }

        private void cbo_quoc_tich_SelectionChangeCommitted(object sender, EventArgs e)
        {
            search_nhanvien();
        }

        private void cbo_dan_toc_SelectionChangeCommitted(object sender, EventArgs e)
        {
            search_nhanvien();
        }

        private void cbo_gioi_tinh_SelectionChangeCommitted(object sender, EventArgs e)
        {
            search_nhanvien();
        }

        private void cbo_hon_nhan_SelectionChangeCommitted(object sender, EventArgs e)
        {
            search_nhanvien();
        }

        private void btn_chon_Click(object sender, EventArgs e)
        {
            id_nhanvien = dgv_nhanvien.CurrentRow.Cells["ma_nhan_vien"].Value.ToString();
            ten_nhanvien = dgv_nhanvien.CurrentRow.Cells["ho_ten"].Value.ToString();
            chuc_vu = dgv_nhanvien.CurrentRow.Cells["ten_chuc_vu"].Value.ToString();
            this.Close();
        }

        private void dgv_nhanvien_CellMouseDoubleClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            id_nhanvien = dgv_nhanvien.CurrentRow.Cells["ma_nhan_vien"].Value.ToString();
            ten_nhanvien = dgv_nhanvien.CurrentRow.Cells["ho_ten"].Value.ToString();
            chuc_vu = dgv_nhanvien.CurrentRow.Cells["ten_chuc_vu"].Value.ToString();
            this.Close();
        }
    }
}
