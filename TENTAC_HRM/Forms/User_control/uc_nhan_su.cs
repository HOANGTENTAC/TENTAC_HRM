using System;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Windows.Forms;
using System.Windows.Media;
using TENTAC_HRM.Custom;

namespace TENTAC_HRM.User_control
{
    public partial class uc_nhan_su : UserControl
    {
        int _id_nhan_vien;
        string _ma_nhan_vien;
        string treeview_select = "";
        int PageSize = 50;
        int pageCount = 0;
        DataProvider provider = new DataProvider();
        public static uc_nhan_su _instance;
        public static uc_nhan_su Instance
        {
            get
            {
                //if (_instance == null)
                _instance = new uc_nhan_su();
                return _instance;
            }
        }
        public uc_nhan_su()
        {
            InitializeComponent();
            cbo_trang_thai.ComboBox.SelectionChangeCommitted += cbo_trang_thai_SelectionChangeCommitted;
            cbo_pagenumber.ComboBox.SelectionChangeCommitted += cbo_pagenumber_SelectionChangeCommitted;
        }

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
        private void uc_nhan_su_Load(object sender, EventArgs e)
        {
            load_gioitinh();
            load_trang_thai1();
            load_trang_thai();

            datagrid_click();
            load_treeview();
            load_bophan();
            load_phongban();
            load_chucvu();

            DataTable datatable = new DataTable();
            datatable.Columns.Add("id");
            datatable.Columns.Add("name");
            datatable.Rows.Add("10", "10");
            datatable.Rows.Add("50", "50");
            datatable.Rows.Add("100", "100");
            datatable.Rows.Add("500", "500");
            datatable.Rows.Add("1000", "1000");
            cbo_pagenumber.ComboBox.DataSource = datatable;
            cbo_pagenumber.ComboBox.DisplayMember = "name";
            cbo_pagenumber.ComboBox.ValueMember = "id";
            trv_sodoquanly.SelectedNode = trv_sodoquanly.Nodes[0];
            treeview_select = trv_sodoquanly.SelectedNode.Tag.ToString();
            load_data(1);
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
        private void load_bophan()
        {
            string sql = "select ma_phong_ban,ten_phong_ban from phong_ban where id_loai_phong_ban = 2 and del_flg = 0";
            DataTable dt = new DataTable();
            dt = SQLHelper.ExecuteDt(sql);
            dt.Rows.Add("0", "");
            cbo_bophan.DataSource = dt.Rows.Cast<DataRow>().OrderBy(x => x.Field<string>("ma_phong_ban")).CopyToDataTable();
            cbo_bophan.DisplayMember = "ten_phong_ban";
            cbo_bophan.ValueMember = "ma_phong_ban";
        }
        private void load_phongban()
        {
            string sql = string.Format("select ma_phong_ban,ten_phong_ban from phong_ban where id_loai_phong_ban = 3 and del_flg = 0 and ma_phong_ban_root = '{0}'", cbo_bophan.SelectedValue);
            DataTable dt = new DataTable();
            dt = SQLHelper.ExecuteDt(sql);
            dt.Rows.Add("0", "");
            cbo_phongban.DataSource = dt.Rows.Cast<DataRow>().OrderBy(x => x.Field<string>("ma_phong_ban")).CopyToDataTable();
            cbo_phongban.DisplayMember = "ten_phong_ban";
            cbo_phongban.ValueMember = "ma_phong_ban";
        }
        private void load_chucvu()
        {
            string sql = string.Format("select ma_chuc_vu,ten_chuc_vu from chuc_vu where del_flg = 0");
            DataTable dt = new DataTable();
            dt = SQLHelper.ExecuteDt(sql);
            dt.Rows.Add("0", "");
            cbo_chucvu.DataSource = dt.Rows.Cast<DataRow>().OrderBy(x => x.Field<string>("ma_chuc_vu")).CopyToDataTable();
            cbo_chucvu.DisplayMember = "ten_chuc_vu";
            cbo_chucvu.ValueMember = "ma_chuc_vu";
        }
        private void load_trang_thai1()
        {
            string sql = "select type_id,type_name from sys_all_type where type_type = 1";
            DataTable dt = new DataTable();
            dt = SQLHelper.ExecuteDt(sql);
            dt.Rows.Add("0", "");
            cbo_trangthai.DataSource = dt.Rows.Cast<DataRow>().OrderBy(x => x.Field<int>("type_id")).CopyToDataTable();
            cbo_trangthai.DisplayMember = "type_name";
            cbo_trangthai.ValueMember = "type_id";
        }
        private void load_gioitinh()
        {
            cbo_gioitinh.DataSource = provider.load_gioitinh();
            cbo_gioitinh.DisplayMember = "name";
            cbo_gioitinh.ValueMember = "id";
        }
        public void load_data(int pageIndex)
        {
            string sql = "select * into ##tblTemp from view_hoso_nhansu where 1=1";
            if (!string.IsNullOrEmpty(txt_search_ten.Text))
            {
                sql = sql + string.Format(" and ho_ten like N''%{0}%''", txt_search_ten.Text);
            }

            if (cbo_trang_thai.ComboBox.SelectedValue.ToString() != "0")
            {
                sql = sql + string.Format(" and id_trang_thai = {0}", cbo_trang_thai.ComboBox.SelectedValue.ToString());
            }

            if (treeview_select != "")
            {
                if (treeview_select == "nv_nv")
                {
                    sql = sql + " and id_trang_thai = 5";
                }
                else if (treeview_select == "nv_moi")
                {
                    sql = sql + " and ma_phong_ban is null";
                }
                else if (treeview_select.Contains("ma_cty"))
                {
                    sql = sql + string.Format(" and ma_cong_ty = ''{0}''", treeview_select.Remove(0, 7));
                }
                else if (treeview_select.Contains("ma_khuvuc"))
                {
                    sql = sql + string.Format(" and ma_khu_vuc = ''{0}''", treeview_select.Remove(0, 10));
                }
                else
                {
                    sql = sql + string.Format(" and ma_phong_ban = ''{0}''", treeview_select);
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
            frm_personnel frm = new frm_personnel(this);
            frm.status_frm = false;
            frm.ShowDialog();
        }

        private void btn_edit_Click(object sender, EventArgs e)
        {
            if(dgv_nhan_su.Rows.Count > 0)
            {
                datagrid_click();
                frm_personnel frm = new frm_personnel(this);
                frm._ma_nhan_vien = dgv_nhan_su.CurrentRow.Cells["ma_nhan_vien"].Value.ToString();
                frm.status_frm = true;
                frm.ShowDialog();
            }
        }

        private void btn_exit_Click(object sender, EventArgs e)
        {
            Control x = this.Parent;
            TabControl tab = (TabControl)x.Parent.Parent;
            tab.TabPages.Remove(tab.SelectedTab);
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
                frm_personnel frm = new frm_personnel(this);
                frm._ma_nhan_vien = dgv_nhan_su.CurrentRow.Cells["ma_nhan_vien"].Value.ToString();
                frm.status_frm = true;
                frm.ShowDialog();
            }
        }
        private void datagrid_click()
        {
            if (dgv_nhan_su.Rows.Count > 0)
            {
                if (dgv_nhan_su.CurrentRow.Cells["ma_nhan_vien"].Value != null)
                {
                    string ma_nhan_su_value = dgv_nhan_su.CurrentRow.Cells["ma_nhan_vien"].Value.ToString();
                    string sql = string.Format("select a.id_nhan_vien,a.ma_nhan_vien,a.hinh_anh,a.so_cccd,ho_ten,ngay_sinh," +
                        "gioi_tinh,a.email,a.dien_thoai_dd,a.dien_thoai_nha,c.ten_phong_ban,d.ten_chuc_vu as ten_chuc_vu,a.ghi_chu," +
                        "e.ten_phong_ban as khu_vuc,f.dia_chi_full,g.type_name as trangthai,f.dia_chi_full as noi_o," +
                        "id_trang_thai,d.ma_chuc_vu,c.ma_phong_ban,e.ma_phong_ban as ma_khu_vuc,ma_cham_cong " +
                        "from hrm_nhan_vien a " +
                        "left join nhanvien_phongban b on a.ma_nhan_vien = b.ma_nhan_vien and b.is_active = 1 " +
                        "left join phong_ban c on c.ma_phong_ban = b.ma_phong_ban " +
                        "left join chuc_vu d on d.ma_chuc_vu = b.ma_chuc_vu " +
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
                        txt_machancong.Text = dataTable.Rows[0]["ma_cham_cong"].ToString();
                        dtp_ngaysinh.Text = DateTime.Parse(dataTable.Rows[0]["ngay_sinh"].ToString()).ToString("yyyy/MM/dd");
                        txt_email.Text = dataTable.Rows[0]["email"].ToString();
                        txt_cccd.Text = dataTable.Rows[0]["so_cccd"].ToString();
                        txt_dienthoai.Text = dataTable.Rows[0]["dien_thoai_dd"].ToString();
                        txt_ghichu.Text = dataTable.Rows[0]["ghi_chu"].ToString();
                        cbo_gioitinh.SelectedValue = (dataTable.Rows[0]["gioi_tinh"].ToString() == "False" ? 0 : 1);
                        cbo_bophan.SelectedValue = dataTable.Rows[0]["ma_khu_vuc"].ToString();
                        cbo_phongban.SelectedValue = dataTable.Rows[0]["ma_phong_ban"].ToString();
                        cbo_chucvu.SelectedValue = dataTable.Rows[0]["ma_chuc_vu"].ToString();
                        cbo_trangthai.SelectedValue = dataTable.Rows[0]["id_trang_thai"].ToString();
                        _id_nhan_vien = int.Parse(dataTable.Rows[0]["id_nhan_vien"].ToString());
                        _ma_nhan_vien = dataTable.Rows[0]["ma_nhan_vien"].ToString();
                        load_diachi();
                    }
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

        private void cbo_bophan_SelectedValueChanged(object sender, EventArgs e)
        {
            DataRowView vrow = (DataRowView)cbo_bophan.SelectedItem;
            if (vrow != null)
            {
                string row = vrow.Row.ItemArray[0].ToString();
                if (row != "")
                {
                    string sql = string.Format("select ma_phong_ban,ten_phong_ban from phong_ban where id_loai_phong_ban = 3 and del_flg = 0 and ma_phong_ban_root = '{0}'", row);
                    DataTable dt = new DataTable();
                    dt = SQLHelper.ExecuteDt(sql);
                    dt.Rows.Add("0", "");
                    cbo_phongban.DataSource = dt.Rows.Cast<DataRow>().OrderBy(x => x.Field<string>("ma_phong_ban")).CopyToDataTable();
                    cbo_phongban.DisplayMember = "ten_phong_ban";
                    cbo_phongban.ValueMember = "ma_phong_ban";
                }
            }
        }

        private void cbo_phongban_SelectedValueChanged(object sender, EventArgs e)
        {
            DataRowView vrow = (DataRowView)cbo_phongban.SelectedItem;
            if (vrow != null)
            {
                string row = vrow.Row.ItemArray[0].ToString();
                if (row != "")
                {
                    string sql = string.Format("select ma_phong_ban,ten_phong_ban from phong_ban where id_loai_phong_ban = 4 and del_flg = 0 and ma_phong_ban_root = '{0}'", row);
                    DataTable dt = new DataTable();
                    dt = SQLHelper.ExecuteDt(sql);
                    dt.Rows.Add("0", "");
                    cbo_chucvu.DataSource = dt.Rows.Cast<DataRow>().OrderBy(x => x.Field<string>("ma_phong_ban")).CopyToDataTable();
                    cbo_chucvu.DisplayMember = "ten_phong_ban";
                    cbo_chucvu.ValueMember = "ma_phong_ban";
                }
            }
        }

        byte[] _Picbyte;
        private void btn_update_Click(object sender, EventArgs e)
        {
            try
            {
                if (pb_avata.Image != null)
                {
                    MemoryStream ms;
                    ms = new MemoryStream();
                    pb_avata.Image.Save(ms, ImageFormat.Png);
                    _Picbyte = new byte[ms.Length];
                    ms.Position = 0;
                    ms.Read(_Picbyte, 0, _Picbyte.Length);
                }

                string sql = "update hrm_nhan_vien set ma_cham_cong = @ma_cham_cong, ngay_sinh = @ngay_sinh," +
                    "so_cccd = @so_cccd,gioi_tinh = @gioi_tinh,email = @email,dien_thoai_dd = @dien_thoai_dd," +
                    "id_trang_thai = @id_trang_thai,ghi_chu = @ghi_chu,hinh_anh = @hinh_anh " +
                    "where id_nhan_vien = @id_nhan_vien";
                SqlParameter[] param = new SqlParameter[]
                {
                    new SqlParameter("@id_nhan_vien", SqlDbType.Int) {Value = _id_nhan_vien},
                    new SqlParameter("@ma_cham_cong", SqlDbType.Int) {Value = txt_machancong},
                    new SqlParameter("@ngay_sinh", SqlDbType.Date) {Value = dtp_ngaysinh.Value},
                    new SqlParameter("@so_cccd", SqlDbType.VarChar) {Value = txt_cccd.Text},
                    new SqlParameter("@gioi_tinh", SqlDbType.Bit) {Value = int.Parse(cbo_gioitinh.SelectedValue.ToString())},
                    new SqlParameter("@email", SqlDbType.VarChar) {Value = txt_email.Text},
                    new SqlParameter("@dien_thoai_dd", SqlDbType.VarChar) {Value = txt_dienthoai.Text},
                    new SqlParameter("@id_trang_thai", SqlDbType.Int) {Value = int.Parse(cbo_trangthai.SelectedValue.ToString())},
                    new SqlParameter("@ghi_chu", SqlDbType.NVarChar) {Value = txt_ghichu.Text},
                    new SqlParameter("@hinh_anh", SqlDbType.Image) {Value = _Picbyte == null ? (object)DBNull.Value : _Picbyte}
                };

                if (SQLHelper.ExecuteSql(sql,param) == 1)
                {
                    RJMessageBox.Show("cập nhật thành công", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (Exception ex)
            {
                RJMessageBox.Show(ex.Message, "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        Byte[] b = null;
        FileStream Fs = default(FileStream);
        OpenFileDialog open = new OpenFileDialog();
        private void btn_update_image_Click(object sender, EventArgs e)
        {
            open.Filter = "Image Files(*.jpg; *.jpeg; *.gif; *.bmp; *.png)|*.jpg; *.jpeg; *.gif; *.bmp; *.png" +
                                "|All Files (*.*)|*.*";
            if (open.ShowDialog() == DialogResult.OK)
            {
                Fs = File.Open(open.FileName, FileMode.OpenOrCreate);
                b = new Byte[Fs.Length];
                Fs.Read(b, 0, b.Length);
                Fs.Close();
                pb_avata.Image = Image.FromFile(open.FileName);
            }
        }

        private void btn_que_quan_Click(object sender, EventArgs e)
        {
            if(dgv_nhan_su.Rows.Count > 0)
            {
                frm_main_uc frm = new frm_main_uc(null, this);
                frm._ma_nhan_vien = _ma_nhan_vien;
                frm.title_frm = "Nhân viên - Địa chỉ";
                frm.type = "address";
                frm.ShowDialog();
            }
        }

        private void btn_thuong_tru_Click(object sender, EventArgs e)
        {
            if (dgv_nhan_su.Rows.Count > 0)
            {
                frm_main_uc frm = new frm_main_uc(null,this);
                frm._ma_nhan_vien = _ma_nhan_vien;
                frm.title_frm = "Nhân viên - Địa chỉ";
                frm.type = "address";
                frm.ShowDialog();
            }
        }
        public void load_diachi()
        {
            string sql_dia_chi = string.Format("select dia_chi,loai_dia_chi from hrm_nhanvien_diachi where ma_nhan_vien = '{0}' and is_active = 1 and del_flg = 0", _ma_nhan_vien);
            DataTable dt_diachi = new DataTable();
            dt_diachi = SQLHelper.ExecuteDt(sql_dia_chi);
            DataRow quequan = dt_diachi.AsEnumerable().Where(x => x.Field<int>("loai_dia_chi") == 41).FirstOrDefault();
            DataRow thuongtru = dt_diachi.AsEnumerable().Where(x => x.Field<int>("loai_dia_chi") == 43).FirstOrDefault();
            txt_quequan.Text = (quequan != null ? quequan.ItemArray[0].ToString() : "");
            txt_noio.Text = (thuongtru != null ? thuongtru.ItemArray[0].ToString() : "");
        }
    }
}
