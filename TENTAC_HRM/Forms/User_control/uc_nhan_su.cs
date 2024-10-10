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
            cbo_phongban_search.ComboBox.SelectionChangeCommitted += cbo_phongban_search_SelectionChangeCommitted;
        }

        private void cbo_phongban_search_SelectionChangeCommitted(object sender, EventArgs e)
        {
            load_data(1);
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
            DevComponents.DotNetBar.ButtonX btnPager = (sender as DevComponents.DotNetBar.ButtonX);
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
            load_phongban(true);
            Load_LoaiNhanVien();
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
            cbo_pagenumber.ComboBox.SelectedIndex = 1;
            trv_sodoquanly.SelectedNode = trv_sodoquanly.Nodes[0];
            treeview_select = trv_sodoquanly.SelectedNode.Tag.ToString();
            load_data(1);

        }

        private void Load_LoaiNhanVien()
        {
            string sql = "select MaPhanLoai,TenPhanLoai from mst_phanloaiNhanvien";
            DataTable dt = new DataTable();
            dt = SQLHelper.ExecuteDt(sql);
            cbo_LoaiNhanVien.DataSource = dt.Rows.Cast<DataRow>().OrderBy(x => x.Field<string>("MaPhanLoai")).CopyToDataTable();
            cbo_LoaiNhanVien.DisplayMember = "TenPhanLoai";
            cbo_LoaiNhanVien.ValueMember = "MaPhanLoai";
        }

        private void load_treeview()
        {
            DataTable dtCongTy = SQLHelper.ExecuteDt("select * from  dbo.[mst_CONGTY]");
            for (int i = 0; i < dtCongTy.Rows.Count; i++)
            {
                TreeNode treeCongTy = new TreeNode()
                {
                    Text = dtCongTy.Rows[i][1].ToString(),
                    Tag = dtCongTy.Rows[i][0].ToString()
                };
                trv_sodoquanly.Nodes.Add(treeCongTy);
                string MaCongTy = dtCongTy.Rows[i]["MaCongTy"].ToString();
                DataTable dtKhuVuc = SQLHelper.ExecuteDt($"select * from  dbo.[mst_KHUVUC] where MaCongTy= '{MaCongTy}'");
                for (int j = 0; j < dtKhuVuc.Rows.Count; j++)
                {
                    TreeNode treeKhuVuc = new TreeNode()
                    {
                        Text = dtKhuVuc.Rows[j][2].ToString(),
                        Tag = dtKhuVuc.Rows[j][0].ToString()
                    };
                    trv_sodoquanly.Nodes[i + 2].Nodes.Add(treeKhuVuc);
                    string MaKhuVuc = dtKhuVuc.Rows[j]["MaKhuVuc"].ToString();
                    DataTable dtPhongBan = SQLHelper.ExecuteDt($"select * from  dbo.[mst_PHONGBAN] where MaKhuVuc='{MaKhuVuc}'");

                    for (int z = 0; z < dtPhongBan.Rows.Count; z++)
                    {
                        TreeNode treePhongBan = new TreeNode()
                        {
                            Text = dtPhongBan.Rows[z]["TenPhongBan"].ToString(),
                            Tag = dtPhongBan.Rows[z]["MaPhongBan"].ToString()
                        };

                        trv_sodoquanly.Nodes[i + 2].Nodes[j].Nodes.Add(treePhongBan);
                    }
                }
            }
        }
        private void load_trang_thai()
        {
            string sql = "select typeid,typename from sys_alltype where typetype = 1";
            DataTable dt = new DataTable();
            dt = SQLHelper.ExecuteDt(sql);
            dt.Rows.Add("0", "");
            cbo_trang_thai.ComboBox.DataSource = dt.Rows.Cast<DataRow>().OrderBy(x => x.Field<int>("typeid")).CopyToDataTable();
            cbo_trang_thai.ComboBox.DisplayMember = "typename";
            cbo_trang_thai.ComboBox.ValueMember = "typeid";
        }
        private void load_bophan()
        {
            string sql = "select MaKhuVuc,TenKhuVuc from mst_KhuVuc";
            DataTable dt = new DataTable();
            dt = SQLHelper.ExecuteDt(sql);
            dt.Rows.Add("0", "");
            cbo_bophan.DataSource = dt.Rows.Cast<DataRow>().OrderBy(x => x.Field<string>("MaKhuVuc")).CopyToDataTable();
            cbo_bophan.DisplayMember = "TenKhuVuc";
            cbo_bophan.ValueMember = "MaKhuVuc";
        }
        private void load_phongban(bool search = false)
        {
            string sql = "";
            if(search == true)
            {
                sql = "select maphongban,tenphongban from mst_PhongBan where del_flg = 0";
                DataTable dt = new DataTable();
                dt = SQLHelper.ExecuteDt(sql);
                dt.Rows.Add("0", "");
                cbo_phongban_search.ComboBox.DataSource = dt.Rows.Cast<DataRow>().OrderBy(x => x.Field<string>("maphongban")).CopyToDataTable();
                cbo_phongban_search.ComboBox.DisplayMember = "tenphongban";
                cbo_phongban_search.ComboBox.ValueMember = "maphongban";
            }
            else
            {
                sql = string.Format("select maphongban,tenphongban from mst_PhongBan where del_flg = 0 and MaKhuVuc = '{0}'", cbo_bophan.SelectedValue);
                DataTable dt = new DataTable();
                dt = SQLHelper.ExecuteDt(sql);
                dt.Rows.Add("0", "");
                cbo_phongban.DataSource = dt.Rows.Cast<DataRow>().OrderBy(x => x.Field<string>("maphongban")).CopyToDataTable();
                cbo_phongban.DisplayMember = "tenphongban";
                cbo_phongban.ValueMember = "maphongban";
            }
            //sql = string.Format("select maphongban,tenphongban from mst_PhongBan where del_flg = 0 and MaKhuVuc = '{0}'", cbo_bophan.SelectedValue);


        }
        private void load_chucvu()
        {
            string sql = string.Format("select machucvu,tenchucvu from mst_ChucVu where del_flg = 0");
            DataTable dt = new DataTable();
            dt = SQLHelper.ExecuteDt(sql);
            dt.Rows.Add("0", "");
            cbo_chucvu.DataSource = dt.Rows.Cast<DataRow>().OrderBy(x => x.Field<string>("machucvu")).CopyToDataTable();
            cbo_chucvu.DisplayMember = "tenchucvu";
            cbo_chucvu.ValueMember = "machucvu";
        }
        private void load_trang_thai1()
        {
            string sql = "select typeid,typename from sys_AllType where TypeType = 1";
            DataTable dt = new DataTable();
            dt = SQLHelper.ExecuteDt(sql);
            dt.Rows.Add("0", "");
            cbo_trangthai.DataSource = dt.Rows.Cast<DataRow>().OrderBy(x => x.Field<int>("typeid")).CopyToDataTable();
            cbo_trangthai.DisplayMember = "typename";
            cbo_trangthai.ValueMember = "typeid";
        }
        private void load_gioitinh()
        {
            cbo_gioitinh.DataSource = provider.load_gioitinh();
            cbo_gioitinh.DisplayMember = "name";
            cbo_gioitinh.ValueMember = "id";
        }
        public void load_data(int pageIndex)
        {
            string sql = "select ROW_NUMBER() OVER(ORDER BY MaNhanVien ASC)AS rownumber, * into ##tblTemp from view_hoso_nhansu where 1=1";
            if (!string.IsNullOrEmpty(txt_search_ten.Text))
            {
                sql = sql + string.Format(" and TenNhanVien like N''%{0}%''", txt_search_ten.Text);
            }

            if (cbo_trang_thai.ComboBox.SelectedValue != null && cbo_trang_thai.ComboBox.SelectedValue.ToString() != "0")
            {
                sql = sql + string.Format(" and Id_TrangThai = {0}", cbo_trang_thai.ComboBox.SelectedValue.ToString());
            }

            if(cbo_phongban_search.ComboBox.SelectedValue.ToString() != "0")
            {
                sql = sql + string.Format(" and MaPhongBan = ''{0}'' ", cbo_phongban_search.ComboBox.SelectedValue.ToString());
            }

            if (treeview_select != "")
            {
                if (treeview_select == "nv_nv")
                {
                    sql = sql + " and Id_TrangThai = 5";
                }
                else if (treeview_select == "nv_moi")
                {
                    sql = sql + " and NhanVienMoi = 1";
                }
                else
                {
                    sql = sql + $" and (macongty = ''{treeview_select}''" +
                                $" or makhuvuc = ''{treeview_select}''" +
                                $" or maphongban = ''{treeview_select}''" +
                                $" or machucvu = ''{treeview_select}'')";
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
                frm._ma_nhan_vien = dgv_nhan_su.CurrentRow.Cells["manhanvien"].Value.ToString();
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
                frm._ma_nhan_vien = dgv_nhan_su.CurrentRow.Cells["manhanvien"].Value.ToString();
                frm.status_frm = true;
                frm.ShowDialog();
            }
        }
        private void datagrid_click()
        {
            if (dgv_nhan_su.Rows.Count > 0)
            {
                if (dgv_nhan_su.CurrentRow.Cells["manhanvien"].Value != null)
                {
                    string ma_nhan_su_value = dgv_nhan_su.CurrentRow.Cells["manhanvien"].Value.ToString();
                    string sql = string.Format("select a.id,a.manhanvien,b.hinhanh,a.socccd,b.TenNhanVien,b.ngaysinh," +
                        "b.gioitinh,b.email,a.dienthoaidd,a.dienthoainha,c.tenphongban,d.TenChucVu,b.ghichu," +
                        "e.TenKhuVuc,f.diachifull,g.typename as trangthai,f.diachifull as noi_o," +
                        "id_trangthai,d.machucvu,c.maphongban,e.MaKhuVuc,machamcong,a.LoaiNhanVien " +
                        "from tbl_NhanVien a " +
                        "left join MITACOSQL.dbo.NHANVIEN b on a.MaNhanVien = b.MaNhanVien " +
                        "left join mst_PhongBan c on c.MaPhongBan = b.MaPhongBan " +
                        "left join mst_ChucVu d on d.MaChucVu = b.MaChucVu " +
                        "left join mst_khuVuc e on e.MaKhuVuc = b.MaKhuVuc " +
                        "left join tbl_NhanvienDiachi f on f.manhanvien = a.manhanvien and f.loaidiachi = 41 and f.isactive = 1 " +
                        "left join sys_alltype g on a.id_trangthai = g.typeid " +
                        "left join tbl_NhanvienDiachi h on h.manhanvien = a.manhanvien and h.loaidiachi = 43 and h.isactive = 1 " +
                        "where a.manhanvien = '{0}'", ma_nhan_su_value);
                    DataTable dataTable = new DataTable();
                    dataTable = SQLHelper.ExecuteDt(sql);
                    if (dataTable.Rows.Count > 0)
                    {
                        if (!string.IsNullOrEmpty(dataTable.Rows[0]["hinhanh"].ToString()))
                        {
                            Byte[] byteanh_nv = new Byte[0];
                            byteanh_nv = (Byte[])(dataTable.Rows[0]["hinhanh"]);
                            MemoryStream stmBLOBData = new MemoryStream(byteanh_nv);
                            pb_avata.Image = Image.FromStream(stmBLOBData);
                        }
                        else
                        {
                            pb_avata.Image = null;
                        }
                        lb_nhan_vien.Text = dataTable.Rows[0]["TenNhanVien"].ToString() + " | " + dataTable.Rows[0]["manhanvien"].ToString();
                        txt_machancong.Text = dataTable.Rows[0]["machamcong"].ToString();
                        dtp_ngaysinh.Text = DateTime.Parse(dataTable.Rows[0]["ngaysinh"].ToString()).ToString("yyyy/MM/dd");
                        txt_email.Text = dataTable.Rows[0]["email"].ToString();
                        txt_cccd.Text = dataTable.Rows[0]["socccd"].ToString();
                        txt_dienthoai.Text = dataTable.Rows[0]["dienthoaidd"].ToString();
                        txt_ghichu.Text = dataTable.Rows[0]["ghichu"].ToString();
                        cbo_gioitinh.SelectedValue = (dataTable.Rows[0]["gioitinh"].ToString() == "False" ? 0 : 1);
                        cbo_bophan.SelectedValue = dataTable.Rows[0]["makhuvuc"].ToString();
                        cbo_phongban.SelectedValue = dataTable.Rows[0]["maphongban"].ToString();
                        cbo_chucvu.SelectedValue = dataTable.Rows[0]["machucvu"].ToString();
                        cbo_trangthai.SelectedValue = dataTable.Rows[0]["id_trangthai"].ToString();
                        cbo_LoaiNhanVien.SelectedValue = dataTable.Rows[0]["LoaiNhanVien"].ToString();
                        _id_nhan_vien = int.Parse(dataTable.Rows[0]["id"].ToString());
                        _ma_nhan_vien = dataTable.Rows[0]["manhanvien"].ToString();
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
            frm._ma_nhan_vien = dgv_nhan_su.CurrentRow.Cells["manhanvien"].Value.ToString();
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
                    string sql = string.Format("select maphongban,tenphongban from mst_phongban where del_flg = 0 and MaKhuVuc = '{0}'",row);
                    DataTable dt = new DataTable();
                    dt = SQLHelper.ExecuteDt(sql);
                    dt.Rows.Add("0", "");
                    cbo_phongban.DataSource = dt.Rows.Cast<DataRow>().OrderBy(x => x.Field<string>("maphongban")).CopyToDataTable();
                    cbo_phongban.DisplayMember = "tenphongban";
                    cbo_phongban.ValueMember = "maphongban";
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
                    string sql = string.Format("select MaChucVu,TenChucVu from mst_ChucVu where del_flg = 0 ");
                    DataTable dt = new DataTable();
                    dt = SQLHelper.ExecuteDt(sql);
                    dt.Rows.Add("0", "");
                    cbo_chucvu.DataSource = dt.Rows.Cast<DataRow>().OrderBy(x => x.Field<string>("MaChucVu")).CopyToDataTable();
                    cbo_chucvu.DisplayMember = "TenChucVu";
                    cbo_chucvu.ValueMember = "MaChucVu";
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

                string sql = "update tbl_NhanVien set machamcong = @ma_cham_cong, ngaysinh = @ngay_sinh," +
                    "socccd = @so_cccd,gioitinh = @gioi_tinh,email = @email,dienthoaidd = @dien_thoai_dd," +
                    "id_trangthai = @id_trang_thai,ghichu = @ghi_chu,hinhanh = @hinh_anh " +
                    "where id = @id_nhan_vien";
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
            string sql_dia_chi = string.Format("select diachi,loaidiachi from tbl_nhanviendiachi where manhanvien = '{0}' and isactive = 1 and del_flg = 0", _ma_nhan_vien);
            DataTable dt_diachi = new DataTable();
            dt_diachi = SQLHelper.ExecuteDt(sql_dia_chi);
            DataRow quequan = dt_diachi.AsEnumerable().Where(x => x.Field<int>("loaidiachi") == 41).FirstOrDefault();
            DataRow thuongtru = dt_diachi.AsEnumerable().Where(x => x.Field<int>("loaidiachi") == 43).FirstOrDefault();
            txt_quequan.Text = (quequan != null ? quequan.ItemArray[0].ToString() : "");
            txt_noio.Text = (thuongtru != null ? thuongtru.ItemArray[0].ToString() : "");
        }
    }
}
