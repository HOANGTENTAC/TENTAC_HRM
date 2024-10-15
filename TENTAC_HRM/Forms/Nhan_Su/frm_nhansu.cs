using System;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Windows.Forms;
using TENTAC_HRM.Forms.Main;

namespace TENTAC_HRM.Forms.Nhan_Su
{
    public partial class frm_nhansu : Form
    {
        public frm_nhansu()
        {
            InitializeComponent();
            cbo_trang_thai.ComboBox.SelectionChangeCommitted += cbo_trang_thai_SelectionChangeCommitted;
            cbo_pagenumber.ComboBox.SelectionChangeCommitted += cbo_pagenumber_SelectionChangeCommitted;
        }
        string treeview_select = "";
        int PageSize = 50;
        int pageCount = 0;
        DataProvider provider = new DataProvider();

        private void cbo_trang_thai_SelectionChangeCommitted(object sender, EventArgs e)
        {
            load_data(1);
        }

        private void HienThiThanhDieuHuong(int recordCount, int currentPage)
        {
            pageCount = provider.HienThiThanhDieuHuong(recordCount, currentPage, PageSize, pnlDieuHuong, Page_Click);
            lb_totalsize.Text = "1/" + pageCount;
        }
        //Viết sự kiện khi kích trên nút phân trang
        private void Page_Click(object sender, EventArgs e)
        {
            Button btnPager = (sender as Button);
            this.load_data(int.Parse(btnPager.Name));
            lb_totalsize.Text = int.Parse(btnPager.Name) + "/" + pageCount.ToString();
        }
        private void load_treeview()
        {
            string sql_nv_nghiviec_dv = "select ma_phong_ban,ten_phong_ban from phong_ban where id_loai_phong_ban = 2";
            DataTable dt_nv_nghiviec_dv = new DataTable();
            dt_nv_nghiviec_dv = SQLHelper.ExecuteDt(sql_nv_nghiviec_dv);
            for (int i = 0; i < dt_nv_nghiviec_dv.Rows.Count; i++)
            {
                TreeNode treenv_nghiviec_dv = new TreeNode();
                treenv_nghiviec_dv.Text = dt_nv_nghiviec_dv.Rows[i][1].ToString();
                treenv_nghiviec_dv.Tag = dt_nv_nghiviec_dv.Rows[i][0].ToString();
                trv_sodoquanly.Nodes[1].Nodes.Add(treenv_nghiviec_dv);

                string sql_phongban_nghiviec = string.Format("select ma_phong_ban,ten_phong_ban from phong_ban where ma_phong_ban_root = '{0}'", dt_nv_nghiviec_dv.Rows[i]["ma_phong_ban"].ToString());
                DataTable dt_phongban_nghiviec = new DataTable();
                dt_phongban_nghiviec = SQLHelper.ExecuteDt(sql_phongban_nghiviec);
                for (int j = 0; j < dt_phongban_nghiviec.Rows.Count; j++)
                {
                    TreeNode treephongban_nghiviec = new TreeNode();
                    treephongban_nghiviec.Text = dt_phongban_nghiviec.Rows[j][1].ToString();
                    treephongban_nghiviec.Tag = dt_phongban_nghiviec.Rows[j][0].ToString();
                    trv_sodoquanly.Nodes[1].Nodes[i].Nodes.Add(treephongban_nghiviec);
                }
            }
            string sql = "select ma_phong_ban,ten_phong_ban from phong_ban where id_loai_phong_ban = 1";
            DataTable dt_cty = new DataTable();
            dt_cty = SQLHelper.ExecuteDt(sql);
            for (int i = 0; i < dt_cty.Rows.Count; i++)
            {
                TreeNode treeCongTy = new TreeNode();
                treeCongTy.Text = dt_cty.Rows[i][1].ToString();
                treeCongTy.Tag = "ma_cty_" + dt_cty.Rows[i][0].ToString();
                trv_sodoquanly.Nodes.Add(treeCongTy);
                string sql_khuvuc = string.Format("select ma_phong_ban,ten_phong_ban from phong_ban where ma_phong_ban_root = '{0}'", dt_cty.Rows[i]["ma_phong_ban"].ToString());
                DataTable dt_khuvuc = new DataTable();
                dt_khuvuc = SQLHelper.ExecuteDt(sql_khuvuc);
                for (int j = 0; j < dt_khuvuc.Rows.Count; j++)
                {
                    TreeNode treekhuvuc = new TreeNode();
                    treekhuvuc.Text = dt_khuvuc.Rows[j][1].ToString();
                    treekhuvuc.Tag = "ma_khuvuc_" + dt_khuvuc.Rows[j][0].ToString();
                    trv_sodoquanly.Nodes[i + 2].Nodes.Add(treekhuvuc);

                    string sql_phongban = string.Format("select ma_phong_ban,ten_phong_ban from phong_ban where ma_phong_ban_root = '{0}'", dt_khuvuc.Rows[j]["ma_phong_ban"].ToString());
                    DataTable dt_phongban = new DataTable();
                    dt_phongban = SQLHelper.ExecuteDt(sql_phongban);
                    for (int z = 0; z < dt_phongban.Rows.Count; z++)
                    {
                        TreeNode treephongban = new TreeNode();
                        treephongban.Text = dt_phongban.Rows[z][1].ToString();
                        treephongban.Tag = dt_phongban.Rows[z][0].ToString();
                        trv_sodoquanly.Nodes[i + 2].Nodes[j].Nodes.Add(treephongban);
                    }
                }
            }
        }
        private void load_trang_thai()
        {
            string sql = "select type_id,type_name from sys_all_type where type_type = 1";
            DataTable dt = new DataTable();
            dt = SQLHelper.ExecuteDt(sql);
            dt.Rows.Add("0", "");
            cbo_trang_thai.ComboBox.DataSource = dt.Rows.Cast<DataRow>().OrderBy(x => x.Field<int>("type_id")).CopyToDataTable();
            cbo_trang_thai.ComboBox.DisplayMember = "type_name";
            cbo_trang_thai.ComboBox.ValueMember = "type_id";
        }
        public void load_data(int pageIndex)
        {
            string sql = "select * into ##tblTemp from view_hoso_nhansu where 1=1";
            if (!string.IsNullOrEmpty(txt_search_ten.Text))
            {
                sql = sql + string.Format(" and hoten like N''%{0}%''", txt_search_ten.Text);
            }

            if (cbo_trang_thai.ComboBox.SelectedValue.ToString() != "0")
            {
                sql = sql + string.Format(" and id_trangthai = {0}", cbo_trang_thai.ComboBox.SelectedValue.ToString());
            }

            if (treeview_select != "")
            {
                if (treeview_select == "nv_nv")
                {

                }
                else if (treeview_select == "nv_moi")
                {
                    sql = sql + " and maphongban is null";
                }
                else if (treeview_select.Contains("id_cty"))
                {
                    sql = sql + string.Format(" and macongty = ''{0}''", treeview_select.Remove(0, 7));
                }
                else if (treeview_select.Contains("id_khuvuc"))
                {
                    sql = sql + string.Format(" and makhuvuc = ''{0}''", treeview_select.Remove(0, 10));
                }
                else
                {
                    sql = sql + string.Format(" and maphongban = ''{0}''", treeview_select);
                }
            }
            DataSet dt = new DataSet();
            dt = SQLHelper.ExecuteDs("getnhanvienpaging " + pageIndex + "," + PageSize + ",N'" + sql + "'");
            dgv_nhan_su.DataSource = dt.Tables[1];
            int recordCount = Convert.ToInt32(dt.Tables[0].Rows[0][0].ToString());
            this.HienThiThanhDieuHuong(recordCount, pageIndex);
        }

        private void btn_add_Click(object sender, EventArgs e)
        {
            //frm_personnel frm = new frm_personnel(this);
            //frm.status_frm = false;
            //frm.ShowDialog();
        }

        private void btn_edit_Click(object sender, EventArgs e)
        {
            datagrid_click();
            //frm_personnel frm = new frm_personnel(this);
            //frm._ma_nhan_vien = dgv_nhan_su.CurrentRow.Cells["ma_nhan_vien"].Value.ToString();
            //frm.status_frm = true;
            //frm.ShowDialog();
        }

        private void btn_exit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void txt_search_ten_TextChanged(object sender, EventArgs e)
        {
            load_data(1);
        }

        private void dgv_nhan_su_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            datagrid_click();
            if (dgv_nhan_su.CurrentCell.OwningColumn.Name == "edit_column")
            {
                //frm_personnel frm = new frm_personnel(this);
                //frm._ma_nhan_vien = dgv_nhan_su.CurrentRow.Cells["ma_nhan_vien"].Value.ToString();
                //frm.status_frm = true;
                //frm.ShowDialog();
            }
        }
        private void datagrid_click()
        {
            if (dgv_nhan_su.CurrentRow.Cells["ma_nhan_vien"].Value != null)
            {
                string ma_nhan_su_value = dgv_nhan_su.CurrentRow.Cells["ma_nhan_vien"].Value.ToString();
                string sql = string.Format("select a.id_nhan_vien,a.ma_nhan_vien,a.hinh_anh,a.so_cccd,ho_ten,ngaysinh," +
                    "gioi_tinh,a.email,a.dien_thoai_dd,a.dien_thoai_nha,c.ten_phong_ban,d.ten_phong_ban as ten_chuc_vu,a.ghi_chu," +
                    "e.ten_phong_ban as khu_vuc,f.dia_chi_full,g.type_name as trangthai,f.dia_chi_full as noi_o " +
                    "from hrm_nhan_vien a " +
                    "left join nhanvien_phongban b on a.ma_nhan_vien = b.ma_nhan_vien and b.is_active = 1 " +
                    "left join phong_ban c on c.ma_phong_ban = b.ma_phong_ban " +
                    "left join phong_ban d on d.ma_phong_ban = b.ma_chuc_vu " +
                    "left join phong_ban e on e.ma_phong_ban = b.ma_khu_vuc " +
                    "left join hrm_nhanvien_diachi f on f.ma_nhan_vien = a.ma_nhan_vien and f.loai_dia_chi = 41 and f.is_active = 1 " +
                    "left join sys_all_type g on a.id_trang_thai = g.type_id " +
                    "left join hrm_nhanvien_diachi h on h.ma_nhan_vien = a.ma_nhan_vien and h.loai_dia_chi = 43 and h.is_active = 1 " +
                    "where a.ma_nhan_vien = '{0}'", ma_nhan_su_value);
                DataTable dataTable = new DataTable();
                dataTable = SQLHelper.ExecuteDt(sql);
                if (dataTable.Rows.Count > 0)
                {
                    if (!string.IsNullOrEmpty(dataTable.Rows[0]["hinh_anh"].ToString()))
                    {
                        Byte[] byteanh_nv = new Byte[0];
                        byteanh_nv = (Byte[])(dataTable.Rows[0]["hinh_anh"]);
                        MemoryStream stmBLOBData = new MemoryStream(byteanh_nv);
                        pb_avata.Image = Image.FromStream(stmBLOBData);
                    }
                    else
                    {
                        pb_avata.Image = null;
                    }
                    lb_nhan_vien.Text = dataTable.Rows[0]["ho_ten"].ToString() + " | " + dataTable.Rows[0]["ma_nhan_vien"].ToString();
                    lb_ma_the.Text = dataTable.Rows[0]["ma_nhan_vien"].ToString() + " | " + "Số hồ sơ:";
                    lb_ngay_sinh.Text = DateTime.Parse(dataTable.Rows[0]["ngaysinh"].ToString()).ToString("yyyy/MM/dd");
                    lb_email.Text = dataTable.Rows[0]["email"].ToString();
                    lb_cccd.Text = dataTable.Rows[0]["so_cccd"].ToString();
                    lb_dt.Text = dataTable.Rows[0]["dien_thoai_dd"].ToString();
                    lb_ghi_chu.Text = dataTable.Rows[0]["ghi_chu"].ToString();
                    lb_gioi_tinh.Text = (dataTable.Rows[0]["gioi_tinh"].ToString() == "False" ? "Nữ" : "Nam");
                    lb_phong_ban.Text = dataTable.Rows[0]["ten_phong_ban"].ToString();
                    lb_chuc_vu.Text = dataTable.Rows[0]["ten_chuc_vu"].ToString();
                    lb_que_quan.Text = dataTable.Rows[0]["dia_chi_full"].ToString();
                    lb_trang_thai.Text = dataTable.Rows[0]["trangthai"].ToString();
                    lb_noi_o.Text = dataTable.Rows[0]["noi_o"].ToString();
                }
            }
        }

        private void trv_sodoquanly_NodeMouseClick(object sender, TreeNodeMouseClickEventArgs e)
        {
            treeview_select = e.Node.Tag.ToString();
            load_data(1);
        }

        private void btn_transfer_Click(object sender, EventArgs e)
        {
            frm_staff_transfer frm = new frm_staff_transfer();
            frm._ma_nhan_vien = dgv_nhan_su.CurrentRow.Cells["ma_nhan_vien"].Value.ToString();
            frm.ShowDialog();
        }

        private void cbo_pagenumber_SelectionChangeCommitted(object sender, EventArgs e)
        {
            PageSize = int.Parse(cbo_pagenumber.ComboBox.SelectedValue.ToString());
            load_data(1);
        }

        private void dgv_nhan_su_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            DataGridViewCell cell = this.dgv_nhan_su.Rows[e.RowIndex].Cells["edit_column"];
            cell.ToolTipText = "Sửa";
        }

        private void frm_nhansu_Load(object sender, EventArgs e)
        {
            load_trang_thai();
            load_data(1);
            datagrid_click();
            load_treeview();

            DataTable datatable = new DataTable();
            datatable.Columns.Add("id");
            datatable.Columns.Add("name");
            datatable.Rows.Add("50", "50");
            datatable.Rows.Add("100", "100");
            datatable.Rows.Add("500", "500");
            datatable.Rows.Add("1000", "1000");
            cbo_pagenumber.ComboBox.DataSource = datatable;
            cbo_pagenumber.ComboBox.DisplayMember = "name";
            cbo_pagenumber.ComboBox.ValueMember = "id";
        }
    }
}
