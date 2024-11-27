using System;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Text.RegularExpressions;
using System.Windows.Forms;
using System.Windows.Media;
using TENTAC_HRM.Custom;
using TENTAC_HRM.Forms.Category;
using TENTAC_HRM.Forms.Main;

namespace TENTAC_HRM.Forms.User_control
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
            LoadData(1);
        }

        private void cbo_trang_thai_SelectionChangeCommitted(object sender, EventArgs e)
        {
            LoadData(1);
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
            this.LoadData(int.Parse(btnPager.Name));
            lb_totalsize.Text = int.Parse(btnPager.Name) + "/" + pageCount.ToString();
        }
        private void uc_nhan_su_Load(object sender, EventArgs e)
        {
            LoadGioiTinh();
            LoadTrangThai();

            DatagridClick();
            LoadTreeView();
            trv_sodoquanly.Nodes[0].ExpandAll();
            trv_sodoquanly.SelectedNode = trv_sodoquanly.Nodes[2].Nodes[1];
            LoadBoPhan();
            LoadPhongBan();
            LoadChucVu();
            LoadPhongBan(true);
            LoadLoaiNhanVien();
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
            //trv_sodoquanly.SelectedNode = trv_sodoquanly.Nodes[0];
            treeview_select = trv_sodoquanly.SelectedNode.Tag.ToString();
            LoadData(1);

        }
        private void LoadLoaiNhanVien()
        {
            string sql = "select MaPhanLoai,TenPhanLoai from mst_phanloaiNhanvien";
            DataTable dt = new DataTable();
            dt = SQLHelper.ExecuteDt(sql);
            cbo_LoaiNhanVien.DataSource = dt.Rows.Cast<DataRow>().OrderBy(x => x.Field<string>("MaPhanLoai")).CopyToDataTable();
            cbo_LoaiNhanVien.DisplayMember = "TenPhanLoai";
            cbo_LoaiNhanVien.ValueMember = "MaPhanLoai";
        }
        private void LoadTreeView()
        {
            DataTable dtCongTy = SQLHelper.ExecuteDt("select * from [MITACOSQL].[dbo].[CONGTY]");
            for (int i = 0; i < dtCongTy.Rows.Count; i++)
            {
                TreeNode treeCongTy = new TreeNode()
                {
                    Text = dtCongTy.Rows[i][1].ToString(),
                    Tag = dtCongTy.Rows[i][0].ToString()
                };
                trv_sodoquanly.Nodes.Add(treeCongTy);
                string MaCongTy = dtCongTy.Rows[i]["MaCongTy"].ToString();
                DataTable dtKhuVuc = SQLHelper.ExecuteDt($"select * from [MITACOSQL].[dbo].[KHUVUC] where MaCongTy= '{MaCongTy}'");
                for (int j = 0; j < dtKhuVuc.Rows.Count; j++)
                {
                    TreeNode treeKhuVuc = new TreeNode()
                    {
                        Text = dtKhuVuc.Rows[j][2].ToString(),
                        Tag = dtKhuVuc.Rows[j][0].ToString()
                    };
                    trv_sodoquanly.Nodes[i + 2].Nodes.Add(treeKhuVuc);
                    string MaKhuVuc = dtKhuVuc.Rows[j]["MaKhuVuc"].ToString();
                    DataTable dtPhongBan = SQLHelper.ExecuteDt($"select * from [MITACOSQL].[dbo].[PHONGBAN] where MaKhuVuc='{MaKhuVuc}'");

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
        private void LoadTrangThai()
        {
            string sql = "select typeid,typename from sys_alltype where typetype = 1";
            DataTable dt = new DataTable();
            dt = SQLHelper.ExecuteDt(sql);
            dt.Rows.Add("0", "");
            cbo_trang_thai.ComboBox.DataSource = dt.Rows.Cast<DataRow>().OrderBy(x => x.Field<int>("typeid")).CopyToDataTable();
            cbo_trang_thai.ComboBox.DisplayMember = "typename";
            cbo_trang_thai.ComboBox.ValueMember = "typeid";
        }
        private void LoadBoPhan()
        {
            string sql = "select MaKhuVuc,TenKhuVuc from [MITACOSQL].[dbo].[KHUVUC]";
            DataTable dt = new DataTable();
            dt = SQLHelper.ExecuteDt(sql);
            dt.Rows.Add("0", "");
            cbo_bophan.DataSource = dt.Rows.Cast<DataRow>().OrderBy(x => x.Field<string>("MaKhuVuc")).CopyToDataTable();
            cbo_bophan.DisplayMember = "TenKhuVuc";
            cbo_bophan.ValueMember = "MaKhuVuc";
        }
        private void LoadPhongBan(bool search = false)
        {
            string sql = "";
            if (search == true)
            {
                sql = "select MaPhongBan, TenPhongBan from [MITACOSQL].[dbo].[PHONGBAN]";
                DataTable dt = new DataTable();
                dt = SQLHelper.ExecuteDt(sql);
                dt.Rows.Add("0", "");
                cbo_phongban_search.ComboBox.DataSource = dt.Rows.Cast<DataRow>().OrderBy(x => x.Field<string>("maphongban")).CopyToDataTable();
                cbo_phongban_search.ComboBox.DisplayMember = "TenPhongBan";
                cbo_phongban_search.ComboBox.ValueMember = "MaPhongBan";
            }
            else
            {
                sql = string.Format("select MaPhongBan,TenPhongBan from [MITACOSQL].[dbo].[PHONGBAN] where MaKhuVuc = '{0}'", cbo_bophan.SelectedValue);
                DataTable dt = new DataTable();
                dt = SQLHelper.ExecuteDt(sql);
                dt.Rows.Add("0", "");
                cbo_phongban.DataSource = dt.Rows.Cast<DataRow>().OrderBy(x => x.Field<string>("maphongban")).CopyToDataTable();
                cbo_phongban.DisplayMember = "TenPhongBan";
                cbo_phongban.ValueMember = "MaPhongBan";
            }
            //sql = string.Format("select maphongban,tenphongban from mst_PhongBan where del_flg = 0 and MaKhuVuc = '{0}'", cbo_bophan.SelectedValue);
        }
        private void LoadChucVu()
        {
            string sql = string.Format("select machucvu,tenchucvu from mst_ChucVu where del_flg = 0");
            DataTable dt = new DataTable();
            dt = SQLHelper.ExecuteDt(sql);
            dt.Rows.Add("0", "");
            cbo_chucvu.DataSource = dt.Rows.Cast<DataRow>().OrderBy(x => x.Field<string>("machucvu")).CopyToDataTable();
            cbo_chucvu.DisplayMember = "tenchucvu";
            cbo_chucvu.ValueMember = "machucvu";
        }
        private void LoadGioiTinh()
        {
            cbo_gioitinh.DataSource = provider.load_gioitinh();
            cbo_gioitinh.DisplayMember = "name";
            cbo_gioitinh.ValueMember = "id";
        }
        public void LoadData(int pageIndex)
        {
            string sql = "select ROW_NUMBER() OVER(ORDER BY MaNhanVien ASC)AS rownumber," +
                "MaNhanVien, TenNhanVien, Ten, NgaySinh, GioiTinh, HonNhan, SoCCCD, SoHoChieu, DienThoaiDD," +
                "Email, NgayVaoLamViec, SoTK, Workpermit, TenTonGiao, TenDanToc, TenNgoaiNgu, TenChungChi, TenBac, DiaChiFull," +
                "TenPhongBan, TenChucVu, QuocTich, GhiChu " +
                "into ##tblTemp from view_hoso_nhansu where 1=1 ";
            if (!string.IsNullOrEmpty(txt_search_ten.Text))
            {
                sql = sql + string.Format(" and TenNhanVien like N''%{0}%'' or MaNhanVien like ''%{0}%''", txt_search_ten.Text);
            }

            if (cbo_trang_thai.ComboBox.SelectedValue != null && cbo_trang_thai.ComboBox.SelectedValue.ToString() != "0")
            {
                sql = sql + string.Format(" and Id_TrangThai = {0}", cbo_trang_thai.ComboBox.SelectedValue.ToString());
            }

            if (cbo_phongban_search.ComboBox.SelectedValue.ToString() != "0")
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
            if (dgv_nhan_su.Rows.Count > 0)
            {
                DatagridClick();
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
            LoadData(1);
        }

        private void dgv_nhan_su_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            DatagridClick();
            if (dgv_nhan_su.CurrentCell.OwningColumn.Name == "edit_column")
            {
                frm_personnel frm = new frm_personnel(this);
                frm._ma_nhan_vien = dgv_nhan_su.CurrentRow.Cells["manhanvien"].Value.ToString();
                frm.status_frm = true;
                frm.ShowDialog();
            }
        }
        private void DatagridClick()
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
                        "left join [MITACOSQL].[dbo].[PHONGBAN] c on c.MaPhongBan = b.MaPhongBan " +
                        "left join [MITACOSQL].[dbo].[CHUCVU] d on d.MaChucVu = b.MaChucVu " +
                        "left join [MITACOSQL].[dbo].[KHUVUC] e on e.MaKhuVuc = b.MaKhuVuc " +
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
                        LoadDiaChiByNhanVien(_ma_nhan_vien);
                    }
                }
            }
        }
        private void trv_sodoquanly_NodeMouseClick(object sender, TreeNodeMouseClickEventArgs e)
        {
            treeview_select = e.Node.Tag.ToString();
            LoadData(1);
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
            LoadData(1);
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
                    string sql = string.Format("select MaPhongBan, TenPhongBan from [MITACOSQL].[dbo].[PHONGBAN] where MaKhuVuc = '{0}'", row);
                    DataTable dt = new DataTable();
                    dt = SQLHelper.ExecuteDt(sql);
                    dt.Rows.Add("0", "");
                    cbo_phongban.DataSource = dt.Rows.Cast<DataRow>().OrderBy(x => x.Field<string>("MaPhongBan")).CopyToDataTable();
                    cbo_phongban.DisplayMember = "TenPhongBan";
                    cbo_phongban.ValueMember = "MaPhongBan";
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
                if (ValidateCCCD() == true)
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
                    string sql_new = $@"update tbl_NhanVien set SoCCCD = {SQLHelper.rpStr(txt_cccd.Text)}, DienThoaiDD = {SQLHelper.rpStr(txt_dienthoai.Text)}, " +
                        $"Id_TrangThai = {SQLHelper.rpI(int.Parse(cbo_trangthai.SelectedValue.ToString()))} " +
                        $"where MaNhanVien = {SQLHelper.rpStr(_ma_nhan_vien)}";
                    SQLHelper.ExecuteSql(sql_new);

                    string sql = "update MITACOSQL.dbo.NHANVIEN set machamcong = @ma_cham_cong, ngaysinh = @ngay_sinh, " +
                        "gioitinh = @gioi_tinh, email = @email,ghichu = @ghi_chu, hinhanh = @hinh_anh, " +
                        "MaKhuVuc = @makhuvuc, MaPhongBan = @maphongban, MaChucVu = @machucvu " +
                        "where MaNhanVien = @manhanvien";
                    SqlParameter[] param = new SqlParameter[]
                    {
                    new SqlParameter("@manhanvien", SqlDbType.VarChar) {Value = _ma_nhan_vien},
                    new SqlParameter("@ma_cham_cong", SqlDbType.Int) {Value = int.Parse(txt_machancong.Text)},
                    new SqlParameter("@ngay_sinh", SqlDbType.Date) {Value = dtp_ngaysinh.Value},
                    new SqlParameter("@gioi_tinh", SqlDbType.Bit) {Value = int.Parse(cbo_gioitinh.SelectedValue.ToString())},
                    new SqlParameter("@email", SqlDbType.VarChar) {Value = txt_email.Text},
                    new SqlParameter("@ghi_chu", SqlDbType.NVarChar) {Value = txt_ghichu.Text},
                    new SqlParameter("@hinh_anh", SqlDbType.Image) {Value = _Picbyte == null ? (object)DBNull.Value : _Picbyte},
                    new SqlParameter("@makhuvuc", SqlDbType.VarChar) {Value = cbo_bophan.SelectedValue},
                    new SqlParameter("@maphongban", SqlDbType.VarChar) {Value = cbo_phongban.SelectedValue},
                    new SqlParameter("@machucvu", SqlDbType.VarChar) {Value = cbo_chucvu.SelectedValue}
                    };

                    if (SQLHelper.ExecuteSql(sql, param) > 0)
                    {
                        RJMessageBox.Show("Cập nhật thông tin thành công", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    else
                    {
                        RJMessageBox.Show("Cập nhật thông tin thất bại", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }
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
            if (dgv_nhan_su.Rows.Count > 0)
            {
                //frm_main_uc frm = new frm_main_uc(null, this);
                //frm._ma_nhan_vien = _ma_nhan_vien;
                //frm.title_frm = "Nhân viên - Địa chỉ";
                //frm.type = "address";
                //frm.ShowDialog();
                frm_address frm = new frm_address(this.FindForm());
                frm._ma_nhanvien = _ma_nhan_vien;
                frm._loai_diachi = 41;
                frm._NameForm = "Địa chỉ nguyên quán";
                frm.ShowDialog();
            }
        }

        private void btn_thuong_tru_Click(object sender, EventArgs e)
        {
            if (dgv_nhan_su.Rows.Count > 0)
            {
                //frm_main_uc frm = new frm_main_uc(null,this);
                //frm._ma_nhan_vien = _ma_nhan_vien;
                //frm.title_frm = "Nhân viên - Địa chỉ";
                //frm.type = "address";
                //frm.ShowDialog();

                frm_address frm = new frm_address(this.FindForm());
                frm._ma_nhanvien = _ma_nhan_vien;
                frm._loai_diachi = 43;
                frm._NameForm = "Địa chỉ thường trú";
                frm.ShowDialog();
            }
        }
        public void LoadDiaChiByNhanVien(string MaNhanVien)
        {
            //string sql_dia_chi = string.Format("select diachi,loaidiachi from tbl_nhanviendiachi where manhanvien = '{0}' and isactive = 1 and del_flg = 0", _ma_nhan_vien);
            string sql_dia_chi = string.Format("select diachi,loaidiachi from tbl_nhanviendiachi where MaNhanVien = '{0}' and del_flg = 0", MaNhanVien);
            DataTable dt_diachi = new DataTable();
            dt_diachi = SQLHelper.ExecuteDt(sql_dia_chi);
            DataRow quequan = dt_diachi.AsEnumerable().Where(x => x.Field<int>("loaidiachi") == 41).FirstOrDefault();
            DataRow thuongtru = dt_diachi.AsEnumerable().Where(x => x.Field<int>("loaidiachi") == 43).FirstOrDefault();
            DataRow tamtru = dt_diachi.AsEnumerable().Where((x) => x.Field<int>("loaidiachi") == 44).FirstOrDefault();
            txt_quequan.Text = (quequan != null ? quequan.ItemArray[0].ToString() : "");
            txt_thuongtru.Text = (thuongtru != null ? thuongtru.ItemArray[0].ToString() : "");
            txt_tamtru.Text = (tamtru != null ? tamtru.ItemArray[0].ToString() : "");
        }
        private string MaTinhThanh()
        {
            string sql = string.Empty;
            sql = $@"Select MaNhanVien, Id_Tinh, del_flg, b.MaDiaChi FROM tbl_NhanVienDiaChi a
                Inner join [TENTAC_HRM].[dbo].[mst_DonViHanhChinh] b on a.Id_Tinh = b.Id and b.del_flg = 0
                Where a.MaNhanVien = {SQLHelper.rpStr(_ma_nhan_vien)} and a.del_flg = 0 and a.LoaiDiaChi = 43";
            DataTable dt = SQLHelper.ExecuteDt(sql);
            string MaTinhValue = dt.Rows[0]["MaDiaChi"].ToString();
            return MaTinhValue;
        }
        private bool IsValidCCCD(string cccd)
        {
            string pattern = @"^\d{12}$";
            return Regex.IsMatch(cccd, pattern);
        }
        private bool ValidateCCCD()
        {
            string cccd = txt_cccd.Text.Trim();
            if (!string.IsNullOrEmpty(cccd))
            {
                if (!IsValidCCCD(cccd))
                {
                    RJMessageBox.Show("CCCD không hợp lệ. Vui lòng nhập số gồm 12 chữ số.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return false;
                }
                string _MaTinhThanh = MaTinhThanh();
                string maTinh = cccd.Substring(0, 3);
                if (!_MaTinhThanh.Contains(maTinh))
                {
                    RJMessageBox.Show("Mã tỉnh thành không hợp lệ. Vui lòng kiểm tra lại CCCD.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return false;
                }
                if (string.IsNullOrEmpty(dtp_ngaysinh.Text))
                {
                    RJMessageBox.Show("Vui lòng chọn ngày tháng năm sinh.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return false;
                }
                int gioiTinhTheKy = int.Parse(cccd.Substring(3, 1));
                int theKy;
                string gioiTinhCCCD = string.Empty;

                if (gioiTinhTheKy == 0 || gioiTinhTheKy == 1)
                {
                    theKy = 20;
                    gioiTinhCCCD = gioiTinhTheKy == 0 ? "Nam" : "Nu";
                }
                else if (gioiTinhTheKy == 2 || gioiTinhTheKy == 3)
                {
                    theKy = 21;
                    gioiTinhCCCD = gioiTinhTheKy == 2 ? "Nam" : "Nu";
                }
                else if (gioiTinhTheKy == 4 || gioiTinhTheKy == 5)
                {
                    theKy = 22;
                    gioiTinhCCCD = gioiTinhTheKy == 4 ? "Nam" : "Nu";
                }
                else
                {
                    RJMessageBox.Show("Ký tự xác định thế kỷ và giới tính không hợp lệ.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return false;
                }
                int namSinh = dtp_ngaysinh.Value.Year;
                if (namSinh < (theKy - 1) * 100 || namSinh >= theKy * 100)
                {
                    RJMessageBox.Show($"Năm sinh {namSinh} không thuộc thế kỷ {theKy}.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return false;
                }

                int gioiTinhValue = int.Parse(cbo_gioitinh.SelectedValue.ToString());
                string gioiTinhSelected = gioiTinhValue == 0 ? "Nu" : "Nam";

                if (gioiTinhCCCD != gioiTinhSelected)
                {
                    RJMessageBox.Show("Giới tính không khớp với thông tin CCCD.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return false;
                }
                string NamSinhCCCD = cccd.Substring(4, 2);
                if (!Convert.ToString(namSinh).Substring(2, 2).Contains(NamSinhCCCD))
                {
                    RJMessageBox.Show("Năm sinh không khớp với thông tin CCCD.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return false;
                }
            }
            return true;
        }
        private void dgv_nhan_su_RowPostPaint(object sender, DataGridViewRowPostPaintEventArgs e)
        {
            var grid = sender as DataGridView;
            var rowIdx = (e.RowIndex + 1).ToString();
            var centerFormat = new StringFormat
            {
                Alignment = StringAlignment.Center,
                LineAlignment = StringAlignment.Center
            };
            var textSize = TextRenderer.MeasureText(rowIdx, Font);
            //if (grid.RowHeadersWidth < textSize.Width + 10)
            //{
            //    grid.RowHeadersWidth = textSize.Width + 10;
            //}
            var headerBounds =
                new Rectangle(e.RowBounds.Left, e.RowBounds.Top, grid.RowHeadersWidth, e.RowBounds.Height);
            e.Graphics.DrawString(rowIdx, Font, SystemBrushes.ControlText, headerBounds, centerFormat);
        }
        private void btn_tamtru_Click(object sender, EventArgs e)
        {
            if (dgv_nhan_su.Rows.Count > 0)
            {
                frm_address frm = new frm_address(this.FindForm());
                frm._ma_nhanvien = _ma_nhan_vien;
                frm._loai_diachi = 44;
                frm._NameForm = "Địa chỉ tạm trú";
                frm.ShowDialog();
            }
        }
        private void event_keypress(KeyPressEventArgs e)
        {
            if (!provider.IsValidChar(e.KeyChar))
            {
                e.Handled = true;
                return;
            }
            base.OnKeyPress(e);
        }
        private void txt_dienthoai_KeyPress(object sender, KeyPressEventArgs e)
        {
            event_keypress(e);
        }
    }
}