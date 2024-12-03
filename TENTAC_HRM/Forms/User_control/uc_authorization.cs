using iTextSharp.text;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Windows.Forms;
using TENTAC_HRM.Custom;
using DataTable = System.Data.DataTable;

namespace TENTAC_HRM.Forms.User_control
{
    public partial class uc_authorization : UserControl
    {
        DataProvider provider = new DataProvider();
        public static uc_authorization _instance;
        private string _PhongBan, _MaNhanVien, _MatKhau, _NguoiTao, _NguoiCapNhat;
        private List<int> selectedNodeIds = new List<int>();
        int PageSize = 0;
        int recordCount = 0;
        public uc_authorization()
        {
            InitializeComponent();
            recordCount = GetTotalRecordCount();
            cbo_pagenumber.ComboBox.SelectionChangeCommitted += cbo_pagenumber_SelectionChangeCommitted;
        }
        private void uc_authorization_Load(object sender, EventArgs e)
        {
            LoadTreeView(false);
            LoadComboboxBoPhan();
            LoadComboboxNhanVien(false);
            DataTable datatable = new DataTable();
            datatable.Columns.Add("id");
            datatable.Columns.Add("name");
            datatable.Rows.Add("10", "10");
            datatable.Rows.Add("20", "20");
            datatable.Rows.Add("50", "50");
            datatable.Rows.Add("100", "100");
            cbo_pagenumber.ComboBox.DataSource = datatable;
            cbo_pagenumber.ComboBox.DisplayMember = "name";
            cbo_pagenumber.ComboBox.ValueMember = "id";
            cbo_pagenumber.ComboBox.SelectedIndex = 0;
            LoadData(1);
        }
        private void LoadTreeView(bool edit)
        {
            treeview_PhanQuyen.Nodes.Clear();

            string sql = string.Empty;

            sql = $@"Select Id, MenuText from mst_Menu where ParentId = 0";
            DataTable dtMenu = SQLHelper.ExecuteDt(sql);

            if (edit == false)
            {
                for (int i = 0; i < dtMenu.Rows.Count; i++)
                {
                    TreeNode treeMenu = new TreeNode()
                    {
                        Text = dtMenu.Rows[i]["MenuText"].ToString(),
                        Tag = dtMenu.Rows[i]["Id"].ToString()
                    };
                    treeview_PhanQuyen.Nodes.Add(treeMenu);

                    int IdMenu = int.Parse(dtMenu.Rows[i]["Id"].ToString());
                    sql = $@"Select Id, MenuText from mst_Menu where ParentId = {SQLHelper.rpI(IdMenu)}";
                    DataTable dtMenuChill = SQLHelper.ExecuteDt(sql);

                    for (int j = 0; j < dtMenuChill.Rows.Count; j++)
                    {
                        TreeNode treeMenuChil = new TreeNode()
                        {
                            Text = dtMenuChill.Rows[j]["MenuText"].ToString(),
                            Tag = dtMenuChill.Rows[j]["Id"].ToString()
                        };

                        treeMenu.Nodes.Add(treeMenuChil);
                    }
                }
            }
            else
            {
                sql = $@"SELECT Id_Menu FROM mst_UserRoles WHERE MaNhanVien = {SQLHelper.rpStr(_MaNhanVien)} AND del_flg = 0";
                DataTable dtUserRoles = SQLHelper.ExecuteDt(sql);
                List<int> checkedMenuIds = dtUserRoles.AsEnumerable().Select(row => row.Field<int>("Id_Menu")).ToList();

                for (int i = 0; i < dtMenu.Rows.Count; i++)
                {
                    TreeNode treeMenu = new TreeNode()
                    {
                        Text = dtMenu.Rows[i]["MenuText"].ToString(),
                        Tag = dtMenu.Rows[i]["Id"].ToString(),
                        ImageIndex = checkedMenuIds.Contains(int.Parse(dtMenu.Rows[i]["Id"].ToString())) ? 1 : 0,
                        SelectedImageIndex = checkedMenuIds.Contains(int.Parse(dtMenu.Rows[i]["Id"].ToString())) ? 1 : 0
                    };

                    treeview_PhanQuyen.Nodes.Add(treeMenu);

                    int IdMenu = int.Parse(dtMenu.Rows[i]["Id"].ToString());
                    sql = $@"Select Id, MenuText from mst_Menu where ParentId = {SQLHelper.rpI(IdMenu)}";
                    DataTable dtMenuChill = SQLHelper.ExecuteDt(sql);

                    for (int j = 0; j < dtMenuChill.Rows.Count; j++)
                    {
                        TreeNode treeMenuChil = new TreeNode()
                        {
                            Text = dtMenuChill.Rows[j]["MenuText"].ToString(),
                            Tag = dtMenuChill.Rows[j]["Id"].ToString(),
                            ImageIndex = checkedMenuIds.Contains(int.Parse(dtMenuChill.Rows[j]["Id"].ToString())) ? 1 : 0,
                            SelectedImageIndex = checkedMenuIds.Contains(int.Parse(dtMenuChill.Rows[j]["Id"].ToString())) ? 1 : 0
                        };

                        treeMenu.Nodes.Add(treeMenuChil);
                    }
                }
            }
        }
        private void uc_authorization_Resize(object sender, EventArgs e)
        {
            if (this.ParentForm.Width == 1240 && this.ParentForm.Height == 835)
            {
                treeview_PhanQuyen.Size = new System.Drawing.Size(287, 623);
            }
            else
            {
                treeview_PhanQuyen.Size = new System.Drawing.Size(287, 785);
            }
        }
        private void Treeview_PhanQuyen_NodeMouseClick(object sender, TreeNodeMouseClickEventArgs e)
        {
            TreeViewHitTestInfo hitTestInfo = treeview_PhanQuyen.HitTest(e.Location);

            if (hitTestInfo.Location == TreeViewHitTestLocations.Image)
            {
                if (e.Node.ImageIndex == 1)
                {
                    e.Node.ImageIndex = 0;
                    e.Node.SelectedImageIndex = 0;

                    int nodeId = int.Parse(e.Node.Tag.ToString());
                    selectedNodeIds.Remove(nodeId);
                }
                else
                {
                    e.Node.ImageIndex = 1;
                    e.Node.SelectedImageIndex = 1;

                    int nodeId = int.Parse(e.Node.Tag.ToString());
                    if (!selectedNodeIds.Contains(nodeId))
                    {
                        selectedNodeIds.Add(nodeId);
                    }
                }

                // Cập nhật các node con và node cha nếu cần
                UpdateChildNodes(e.Node, e.Node.ImageIndex);
                UpdateParentNodes(e.Node);
            }
        }
        private void UpdateParentNodes(TreeNode node)
        {
            if (node.Parent != null)
            {
                bool allChildrenSelected = true;

                foreach (TreeNode childNode in node.Parent.Nodes)
                {
                    if (childNode.ImageIndex != 1) // Kiểm tra nếu có node con không được chọn
                    {
                        allChildrenSelected = false;
                        break;
                    }
                }

                node.Parent.ImageIndex = allChildrenSelected ? 1 : 0;
                node.Parent.SelectedImageIndex = allChildrenSelected ? 1 : 0;

                UpdateParentNodes(node.Parent);
            }
        }
        private void UpdateChildNodes(TreeNode node, int imageIndex)
        {
            foreach (TreeNode childNode in node.Nodes)
            {
                childNode.ImageIndex = imageIndex;
                childNode.SelectedImageIndex = imageIndex;

                UpdateChildNodes(childNode, imageIndex);
            }
        }
        private void LoadComboboxBoPhan()
        {
            string sql = string.Empty;
            sql = "select MaPhongBan, TenPhongBan from [MITACOSQL].[dbo].[PHONGBAN]";
            DataTable dt = new DataTable();
            dt = SQLHelper.ExecuteDt(sql);
            dt.Rows.Add("", "");
            cbo_BoPhan.ComboBox.DataSource = dt.Rows.Cast<DataRow>().OrderBy(x => x.Field<string>("MaPhongBan")).CopyToDataTable();
            cbo_BoPhan.ComboBox.DisplayMember = "TenPhongBan";
            cbo_BoPhan.ComboBox.ValueMember = "MaPhongBan";
        }
        private void LoadComboboxNhanVien(bool Select)
        {
            if (Select == true)
            {
                cbo_NhanVien.ComboBox.DataSource = provider.load_nhanvien_by_phongban(_PhongBan);
                cbo_NhanVien.ComboBox.DisplayMember = "name";
                cbo_NhanVien.ComboBox.ValueMember = "value";
            }
            else
            {
                cbo_NhanVien.ComboBox.DataSource = provider.load_nhanvien();
                cbo_NhanVien.ComboBox.DisplayMember = "name";
                cbo_NhanVien.ComboBox.ValueMember = "value";
            }
        }
        private void cbo_NhanVien_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cbo_NhanVien.SelectedIndex != 0)
            {
                txt_TenDangNhap.Text = _MaNhanVien = cbo_NhanVien.ComboBox.SelectedValue.ToString();
                LoadTreeView(true);
                LoadDataTaiKhoan();
            }
        }
        private void cbo_BoPhan_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cbo_BoPhan.SelectedIndex != 0)
            {
                _PhongBan = cbo_BoPhan.ComboBox.SelectedValue?.ToString();
                LoadComboboxNhanVien(true);
                LoadData(1);
            }
        }
        private List<int> GetSelectedNodeIdsFromTreeView()
        {
            List<int> selectedNodeIds = new List<int>();

            foreach (TreeNode node in treeview_PhanQuyen.Nodes)
            {
                GetSelectedNodeIds(node, selectedNodeIds);
            }

            return selectedNodeIds;
        }

        private void GetSelectedNodeIds(TreeNode node, List<int> selectedNodeIds)
        {
            if (node.ImageIndex == 1)
            {
                selectedNodeIds.Add(int.Parse(node.Tag.ToString()));
            }

            foreach (TreeNode childNode in node.Nodes)
            {
                GetSelectedNodeIds(childNode, selectedNodeIds);
            }
        }
        private void dgv_MenuPhanQuyen_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                txt_TenDangNhap.Text = _MaNhanVien = dgv_MenuPhanQuyen.CurrentRow.Cells["Mã Nhân Viên"].Value.ToString();
                LoadTreeView(true);
                LoadDataTaiKhoan();
            }
        }
        private void btn_save_Click(object sender, EventArgs e)
        {
            try
            {
                SetValues();
                string sql = string.Empty;
                int res = 0;
                sql = $@"Select MaNhanVien, MatKhau from mst_Users 
                        where MaNhanVien = {SQLHelper.rpStr(_MaNhanVien)} and 
                        MatKhau = {SQLHelper.rpStr(txt_MatKhau.Text.Trim().ToString())} and 
                        del_flg = 0";
                DataTable dt = SQLHelper.ExecuteDt(sql);
                if (dt.Rows.Count > 0)
                {
                    res = 1;
                }
                else
                {
                    sql = $@"
                            IF EXISTS(
                                SELECT 1 
                                FROM mst_Users 
                                WHERE MaNhanVien = {SQLHelper.rpStr(_MaNhanVien)} 
                                  AND del_flg = 0
                            )
                            BEGIN
                                UPDATE mst_Users
                                SET MatKhau = {SQLHelper.rpStr(_MatKhau)},
                                    NgayCapNhat = '{DateTime.Now}',
                                    NguoiCapNhat = {SQLHelper.rpStr(_NguoiCapNhat)}
                                WHERE MaNhanVien = {SQLHelper.rpStr(_MaNhanVien)} 
                                  AND del_flg = 0;
                            END
                            ELSE
                            BEGIN
                                INSERT INTO mst_Users(MaNhanVien, MatKhau, NgayTao, NguoiTao, del_flg)
                                VALUES({SQLHelper.rpStr(_MaNhanVien)}, {SQLHelper.rpStr(_MatKhau)}, '{DateTime.Now}', {SQLHelper.rpStr(_NguoiTao)}, 0);
                            END ";
                    res = SQLHelper.ExecuteSql(sql);
                }

                if (res >= 0)
                {
                    List<int> selectedNodeIds = GetSelectedNodeIdsFromTreeView();
                    UpdateUserRolesForSelectedMenus(selectedNodeIds);
                    RJMessageBox.Show("Cập nhật thành công", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    LoadData(1);
                    LoadNull();
                }
                else
                {
                    RJMessageBox.Show("Cập nhật thất bại", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                RJMessageBox.Show(ex.Message, "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void SetValues()
        {
            if (!txt_MatKhau.Text.Trim().Equals(txt_XacNhanMatKhau.Text.Trim()))
            {
                RJMessageBox.Show("Mật khẩu và mật khẩu xác nhận không giống nhau.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            _MaNhanVien = txt_TenDangNhap.Text.Trim().ToString();
            _MatKhau = provider.Hash_sha(txt_MatKhau.Text.Trim());
            _NguoiTao = SQLHelper.sUser;
            _NguoiCapNhat = SQLHelper.sUser;
        }
        private void UpdateUserRolesForSelectedMenus(List<int> selectedNodeIds)
        {
            // Cập nhật những IdMenu không được chọn (del_flg = 1)
            string sqlDelete = $@"UPDATE mst_UserRoles
            SET del_flg = 1, NgayCapNhat = '{DateTime.Now}', NguoiCapNhat = {SQLHelper.rpStr(_NguoiCapNhat)}
            WHERE MaNhanVien = {SQLHelper.rpStr(_MaNhanVien)} AND del_flg = 0 AND Id_Menu NOT IN ({string.Join(",", selectedNodeIds)})";
            SQLHelper.ExecuteSql(sqlDelete);

            // Cập nhật những IdMenu được chọn (del_flg = 0)
            foreach (int nodeId in selectedNodeIds)
            {
                string sqlUpdate = $@"
                IF EXISTS(SELECT 1 FROM mst_UserRoles WHERE MaNhanVien = {SQLHelper.rpStr(_MaNhanVien)} AND Id_Menu = {SQLHelper.rpI(nodeId)})
                BEGIN
                    UPDATE mst_UserRoles
                    SET NgayCapNhat = '{DateTime.Now}', NguoiCapNhat = {SQLHelper.rpStr(_NguoiCapNhat)}, del_flg = 0
                    WHERE MaNhanVien = {SQLHelper.rpStr(_MaNhanVien)} AND Id_Menu = {SQLHelper.rpI(nodeId)};
                END
                ELSE
                BEGIN
                    INSERT INTO mst_UserRoles(MaNhanVien, Id_Menu, NgayTao, NguoiTao, del_flg)
                    VALUES({SQLHelper.rpStr(_MaNhanVien)}, {SQLHelper.rpI(nodeId)}, '{DateTime.Now}', {SQLHelper.rpStr(_NguoiTao)}, 0);
                END";

                SQLHelper.ExecuteSql(sqlUpdate);
            }
        }
        private void LoadData(int pageIndex)
        {
            try
            {
                if (cbo_pagenumber.ComboBox.SelectedValue != null)
                {
                    PageSize = int.Parse(cbo_pagenumber.ComboBox.SelectedValue.ToString());
                }
                SqlParameter[] param = new SqlParameter[]
                {
                    new SqlParameter("@PageNumber", SqlDbType.Int) {Value = pageIndex},
                    new SqlParameter("@PageSize", SqlDbType.Int) {Value = PageSize},
                    new SqlParameter("@MaPhongBan", SqlDbType.NVarChar) {Value = cbo_BoPhan.ComboBox.SelectedValue.ToString()}
                };
                DataTable dt = SQLHelper.DataTableByProcedure("GetMenuByEmployee", param);
                dgv_MenuPhanQuyen.DataSource = dt;


                this.HienThiThanhDieuHuong(recordCount, pageIndex);

                List<DataGridViewColumn> columnsToModify = new List<DataGridViewColumn>();

                foreach (DataGridViewColumn column in dgv_MenuPhanQuyen.Columns)
                {
                    if (column.HeaderText != "Tên Nhân Viên" && column.HeaderText != "Mã Nhân Viên")
                    {
                        columnsToModify.Add(column);
                    }
                }

                foreach (DataGridViewColumn column in columnsToModify)
                {
                    if (!(column is DataGridViewCheckBoxColumn))
                    {
                        DataGridViewCheckBoxColumn checkBoxColumn = new DataGridViewCheckBoxColumn();
                        checkBoxColumn.HeaderText = column.HeaderText;
                        checkBoxColumn.Name = column.Name;
                        checkBoxColumn.DataPropertyName = column.DataPropertyName;
                        checkBoxColumn.ReadOnly = true;

                        // Thay thế cột hiện tại bằng cột Checkbox
                        dgv_MenuPhanQuyen.Columns.Remove(column);
                        dgv_MenuPhanQuyen.Columns.Add(checkBoxColumn);
                    }
                }

                foreach (DataGridViewColumn column in dgv_MenuPhanQuyen.Columns)
                {
                    column.AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
                }
            }
            catch (Exception ex)
            {
                RJMessageBox.Show(ex.Message, "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void LoadDataTaiKhoan()
        {
            string sql = $@"SELECT * FROM mst_Users WHERE MaNhanVien = {SQLHelper.rpStr(_MaNhanVien)} AND del_flg = 0";
            DataTable dt = SQLHelper.ExecuteDt(sql);
            if (dt.Rows.Count > 0)
            {
                txt_MatKhau.Text = dt.Rows[0]["MatKhau"].ToString();
                txt_XacNhanMatKhau.Text = dt.Rows[0]["MatKhau"].ToString();
            }
            else
            {
                txt_MatKhau.Text = string.Empty;
                txt_XacNhanMatKhau.Text = string.Empty;
            }
        }
        private void LoadNull()
        {
            txt_TenDangNhap.Text = string.Empty;
            txt_MatKhau.Text = string.Empty;
            txt_XacNhanMatKhau.Text = string.Empty;
            cbo_BoPhan.Text = string.Empty;
            cbo_NhanVien.Text = string.Empty;
            LoadTreeView(false);
        }
        private void HienThiThanhDieuHuong(int recordCount, int currentPage)
        {
            int pageCount = provider.HienThiThanhDieuHuong(recordCount, currentPage, PageSize, pnlDieuHuong, Page_Click);
        }
        //Viết sự kiện khi kích trên nút phân trang
        private void Page_Click(object sender, EventArgs e)
        {
            DevComponents.DotNetBar.ButtonX btnPager = (sender as DevComponents.DotNetBar.ButtonX);
            this.LoadData(int.Parse(btnPager.Name));
        }
        private int GetTotalRecordCount()
        {
            SqlParameter[] param = new SqlParameter[]
            {
                new SqlParameter("@PageNumber", SqlDbType.Int) {Value = 1},
                new SqlParameter("@PageSize", SqlDbType.Int) {Value = 1000000},
            };

            DataTable dt = SQLHelper.DataTableByProcedure("GetMenuByEmployee", param);

            return Convert.ToInt32(dt.Rows.Count);
        }
        private void cbo_pagenumber_SelectionChangeCommitted(object sender, EventArgs e)
        {
            LoadData(1);
        }
    }
}