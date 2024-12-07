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
        int PageSize = 10;
        int recordCount = 0;
        public uc_authorization()
        {
            InitializeComponent();
            recordCount = GetTotalRecordCount();
            cbo_pagenumber.ComboBox.SelectionChangeCommitted += cbo_pagenumber_SelectionChangeCommitted;
            cbo_BoPhan.ComboBox.SelectionChangeCommitted += cbo_BoPhan_SelectionChangeCommitted;
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
                    // Tạo node cho menu cha
                    TreeNode treeMenu = new TreeNode()
                    {
                        Text = dtMenu.Rows[i]["MenuText"].ToString(),
                        Tag = dtMenu.Rows[i]["Id"].ToString()
                    };
                    treeview_PhanQuyen.Nodes.Add(treeMenu);

                    int IdMenu = int.Parse(dtMenu.Rows[i]["Id"].ToString());
                    // Lấy các menu con của menu cha
                    sql = $@"Select Id, MenuText from mst_Menu where ParentId = {SQLHelper.rpI(IdMenu)}";
                    DataTable dtMenuChill = SQLHelper.ExecuteDt(sql);

                    if (dtMenuChill.Rows.Count == 0)  // Nếu không có menu con
                    {
                        sql = $@"Select Id_Per, Name_Per FROM mst_Permision Where Id_Menu = {SQLHelper.rpI(IdMenu)}";
                        DataTable dtPermision = SQLHelper.ExecuteDt(sql);

                        for (int k = 0; k < dtPermision.Rows.Count; k++)
                        {
                            TreeNode treePermision = new TreeNode()
                            {
                                Text = dtPermision.Rows[k]["Name_Per"].ToString(),
                                Tag = dtPermision.Rows[k]["Id_Per"].ToString()
                            };
                            treeMenu.Nodes.Add(treePermision);
                        }
                    }
                    else
                    {
                        // Nếu có menu con, tiếp tục thêm các menu con vào
                        for (int j = 0; j < dtMenuChill.Rows.Count; j++)
                        {
                            TreeNode treeMenuChil = new TreeNode()
                            {
                                Text = dtMenuChill.Rows[j]["MenuText"].ToString(),
                                Tag = dtMenuChill.Rows[j]["Id"].ToString()
                            };

                            treeMenu.Nodes.Add(treeMenuChil);

                            sql = $@"Select Id_Per, Name_Per FROM mst_Permision Where Id_Menu = {SQLHelper.rpI(Convert.ToInt32(treeMenuChil.Tag))}";
                            DataTable dtPermision = SQLHelper.ExecuteDt(sql);

                            for (int k = 0; k < dtPermision.Rows.Count; k++)
                            {
                                TreeNode treePermision = new TreeNode()
                                {
                                    Text = dtPermision.Rows[k]["Name_Per"].ToString(),
                                    Tag = dtPermision.Rows[k]["Id_Per"].ToString()
                                };
                                treeMenuChil.Nodes.Add(treePermision);
                            }
                        }
                    }
                }
            }
            else
            {
                sql = $@"SELECT Id_Menu, Id_Permision FROM mst_UserRoles WHERE MaNhanVien = {SQLHelper.rpStr(_MaNhanVien)} AND del_flg = 0";
                DataTable dtUserRoles = SQLHelper.ExecuteDt(sql);

                List<int> checkedMenuIds = dtUserRoles.AsEnumerable()
                    .Select(row => row.Field<int>("Id_Menu"))
                    .ToList();

                for (int i = 0; i < dtMenu.Rows.Count; i++)
                {
                    // Tạo TreeNode cho Menu cha
                    TreeNode treeMenu = new TreeNode()
                    {
                        Text = dtMenu.Rows[i]["MenuText"].ToString(),
                        Tag = dtMenu.Rows[i]["Id"].ToString(),
                        ImageIndex = checkedMenuIds.Contains(int.Parse(dtMenu.Rows[i]["Id"].ToString())) ? 1 : 0,
                        SelectedImageIndex = checkedMenuIds.Contains(int.Parse(dtMenu.Rows[i]["Id"].ToString())) ? 1 : 0
                    };
                    treeview_PhanQuyen.Nodes.Add(treeMenu);

                    int IdMenu = int.Parse(dtMenu.Rows[i]["Id"].ToString());

                    // Lấy danh sách menu con
                    sql = $@"SELECT Id, MenuText FROM mst_Menu WHERE ParentId = {SQLHelper.rpI(IdMenu)}";
                    DataTable dtMenuChill = SQLHelper.ExecuteDt(sql);

                    if (dtMenuChill.Rows.Count == 0)  // Nếu không có menu con
                    {
                        sql = $@"SELECT Id_Menu, Id_Per, Name_Per FROM mst_Permision WHERE Id_Menu = {SQLHelper.rpI(IdMenu)}";
                        DataTable dtPermision = SQLHelper.ExecuteDt(sql);

                        for (int k = 0; k < dtPermision.Rows.Count; k++)
                        {
                            int idPermision = Convert.ToInt32(dtPermision.Rows[k]["Id_Per"]);
                            int idMenuPermision = Convert.ToInt32(dtPermision.Rows[k]["Id_Menu"]);

                            List<int> checkPermisionIds = dtUserRoles.AsEnumerable()
                                .Where(row => row.Field<int>("Id_Menu") == idMenuPermision &&
                                              row["Id_Permision"] != DBNull.Value)
                                .Select(row => row.Field<int>("Id_Permision"))
                                .ToList();

                            TreeNode treePermision = new TreeNode()
                            {
                                Text = dtPermision.Rows[k]["Name_Per"].ToString(),
                                Tag = dtPermision.Rows[k]["Id_Per"].ToString(),
                                ImageIndex = checkPermisionIds.Contains(idPermision) ? 1 : 0,
                                SelectedImageIndex = checkPermisionIds.Contains(idPermision) ? 1 : 0
                            };

                            treeMenu.Nodes.Add(treePermision);
                        }
                    }
                    else
                    {
                        // Nếu có menu con, tiếp tục thêm các menu con vào
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

                            sql = $@"SELECT Id_Menu, Id_Per, Name_Per FROM mst_Permision WHERE Id_Menu = {SQLHelper.rpI(Convert.ToInt32(treeMenuChil.Tag))}";
                            DataTable dtPermision = SQLHelper.ExecuteDt(sql);

                            for (int k = 0; k < dtPermision.Rows.Count; k++)
                            {
                                int idPermision = Convert.ToInt32(dtPermision.Rows[k]["Id_Per"]);
                                int idMenuPermision = Convert.ToInt32(dtPermision.Rows[k]["Id_Menu"]);

                                List<int> checkPermisionIds = dtUserRoles.AsEnumerable()
                                    .Where(row => row.Field<int>("Id_Menu") == idMenuPermision &&
                                                  row["Id_Permision"] != DBNull.Value)
                                    .Select(row => row.Field<int>("Id_Permision"))
                                    .ToList();

                                TreeNode treePermision = new TreeNode()
                                {
                                    Text = dtPermision.Rows[k]["Name_Per"].ToString(),
                                    Tag = dtPermision.Rows[k]["Id_Per"].ToString(),
                                    ImageIndex = checkPermisionIds.Contains(idPermision) ? 1 : 0,
                                    SelectedImageIndex = checkPermisionIds.Contains(idPermision) ? 1 : 0
                                };

                                treeMenuChil.Nodes.Add(treePermision);
                            }
                        }
                    }
                }
            }
        }
        private void uc_authorization_Resize(object sender, EventArgs e)
        {
            if (this.ParentForm.Width == 1240 && this.ParentForm.Height == 835)
            {
                treeview_PhanQuyen.Size = new System.Drawing.Size(287, 575);
            }
            else
            {
                treeview_PhanQuyen.Size = new System.Drawing.Size(287, 775);
            }
        }
        private int GetNodeMaxLevel(TreeNode node)
        {
            //cấp cao nhất của các node con
            return node.Nodes.Cast<TreeNode>()
                             .Select(GetNodeMaxLevel)
                             .DefaultIfEmpty(node.Level)
                             .Max();
        }
        private void Treeview_PhanQuyen_NodeMouseClick(object sender, TreeNodeMouseClickEventArgs e)
        {
            TreeViewHitTestInfo hitTestInfo = treeview_PhanQuyen.HitTest(e.Location);

            if (hitTestInfo.Location == TreeViewHitTestLocations.Image)
            {
                ToggleNodeSelection(e.Node);

                switch (e.Node.Level)
                {
                    case 0:
                        HandleLevel0Node(e.Node);
                        break;
                    case 1:
                        HandleLevel1Node(e.Node);
                        break;
                    case 2:
                        HandleLevel2Node(e.Node);
                        break;
                }
            }
        }
        private void HandleLevel0Node(TreeNode node)
        {
            int maxLevel = GetNodeMaxLevel(node);
            if (maxLevel == 1)
            {
                if (node.ImageIndex == 0)
                {
                    DeselectAllChildNodes(node);
                }
                else
                {
                    // Chọn node con đầu tiên hoặc node "Read Only" nếu có
                    SelectFirstChildNode(node);
                }
            }
            else
            {
                if (node.ImageIndex == 1)
                {
                    SelectAllChildNodes(node);
                }
                else
                {
                    DeselectAllChildNodes(node);
                }
            }

            UpdateParentNodes(node);
        }
        private void HandleLevel1Node(TreeNode node)
        {
            UpdateParentNodes(node);
            DeselectChildNodes(node);
            CheckAndUpdateParentNode(node);

            if (node.ImageIndex == 0)
            {
                DeselectAllChildNodes(node);
            }
            else
            {
                // Chọn node con đầu tiên hoặc node "Read Only" nếu có
                SelectFirstChildNode(node);
            }
        }
        private void HandleLevel2Node(TreeNode node)
        {
            if (node.ImageIndex == 1)
            {
                UpdateNodeState(node, 1);
                selectedNodeIds.Add(ParseNodeId(node));
                UpdateParentNodeSelection(node.Parent);
            }
            else
            {
                UpdateNodeState(node, 0);
                selectedNodeIds.Remove(ParseNodeId(node));
                UpdateParentNodeSelection(node.Parent);
            }
        }
        private void UpdateParentNodeSelection(TreeNode parentNode)
        {
            bool anyChildSelected = parentNode.Nodes.Cast<TreeNode>()
                .Where(n => n.Level == 2)
                .Any(n => n.ImageIndex == 1); // Kiểm tra trạng thái của node cấp 2 (được chọn hay không)

            if (anyChildSelected)
            {
                UpdateNodeState(parentNode, 1);
                selectedNodeIds.Add(ParseNodeId(parentNode));
            }
            else
            {
                UpdateNodeState(parentNode, 0);
                selectedNodeIds.Remove(ParseNodeId(parentNode));
            }
        }
        private void DeselectChildNodes(TreeNode node)
        {
            foreach (TreeNode childNode in node.Nodes)
            {
                childNode.ImageIndex = 0;
                childNode.SelectedImageIndex = 0;
                int childNodeId = int.Parse(childNode.Tag.ToString());
                selectedNodeIds.Remove(childNodeId);
            }
        }
        private void DeselectAllChildNodes(TreeNode node)
        {
            foreach (TreeNode childNode in node.Nodes)
            {
                DeselectNode(childNode);
                if (childNode.Nodes.Count > 0)
                {
                    DeselectAllChildNodes(childNode);
                }
            }
        }
        private void ToggleNodeSelection(TreeNode node)
        {
            int newState = node.ImageIndex == 1 ? 0 : 1;
            UpdateNodeState(node, newState);

            if (newState == 0)
                selectedNodeIds.Remove(ParseNodeId(node));
            else if (!selectedNodeIds.Contains(ParseNodeId(node)))
                selectedNodeIds.Add(ParseNodeId(node));
        }

        private void UpdateNodeState(TreeNode node, int state)
        {
            node.ImageIndex = state;
            node.SelectedImageIndex = state;
        }
        private int ParseNodeId(TreeNode node)
        {
            return int.Parse(node.Tag.ToString());
        }
        private void SelectAllChildNodes(TreeNode node)
        {
            foreach (TreeNode childNode in node.Nodes)
            {
                if (childNode.Level == 1)
                {
                    // Chọn tất cả node ở Level 1
                    UpdateNodeState(childNode, 1);
                    selectedNodeIds.Add(ParseNodeId(childNode));

                    // Kiểm tra và chọn một node Level 2 (nếu có)
                    SelectFirstChildNode(childNode);
                }
                else if (childNode.Level > 1)
                {
                    continue;
                }
            }
        }
        private void SelectFirstChildNode(TreeNode node)
        {
            // Kiểm tra xem có node nào tên là "Read Only" không
            TreeNode readOnlyNode = node.Nodes.Cast<TreeNode>()
                                             .FirstOrDefault(child => child.Text.Equals("Read Only", StringComparison.OrdinalIgnoreCase));

            if (readOnlyNode != null)
            {
                UpdateNodeState(readOnlyNode, 1);
                selectedNodeIds.Add(ParseNodeId(readOnlyNode));
            }
            else
            {
                TreeNode firstChild = node.Nodes.Cast<TreeNode>().FirstOrDefault();
                if (firstChild != null)
                {
                    UpdateNodeState(firstChild, 1);
                    selectedNodeIds.Add(ParseNodeId(firstChild));
                }
            }
        }
        private void UpdateParentNodes(TreeNode node)
        {
            if (node.Parent == null) return;

            bool allChildrenSelected = node.Parent.Nodes.Cast<TreeNode>().All(n => n.ImageIndex == 1);
            UpdateNodeState(node.Parent, allChildrenSelected ? 1 : 0);

            UpdateParentNodes(node.Parent);
        }
        private void DeselectNode(TreeNode node)
        {
            if (node == null) return;

            UpdateNodeState(node, 0);
            selectedNodeIds.Remove(ParseNodeId(node));
        }
        private void CheckAndUpdateParentNode(TreeNode node)
        {
            TreeNode parentNode = node.Parent;
            bool anyChildSelected = parentNode.Nodes.Cast<TreeNode>().Any(n => n.ImageIndex == 1);

            UpdateNodeState(parentNode, anyChildSelected ? 1 : 0);
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
            _PhongBan = cbo_BoPhan.ComboBox.SelectedValue.ToString();
            LoadComboboxNhanVien(true);
            LoadData(1);
        }
        private int GetSelectedPermisionIds(TreeNode node)
        {
            if (node.Level == 2 && node.ImageIndex == 1 && node.Parent != null && node.Parent.Level == 1 && node.Parent.ImageIndex == 1)
            {
                return int.Parse(node.Tag.ToString());
            }
            foreach (TreeNode childNode in node.Nodes)
            {
                int result = GetSelectedPermisionIds(childNode);
                if (result != 0)
                {
                    return result;
                }
            }

            return 0;
        }
        //private void GetSelectedMenuIds(TreeNode node, List<int> selectedMenuIds)
        //{
        //    if (node.Level == 1 && node.ImageIndex == 1)
        //    {
        //        selectedMenuIds.Add(int.Parse(node.Tag.ToString()));
        //    }

        //    foreach (TreeNode childNode in node.Nodes)
        //    {
        //        GetSelectedMenuIds(childNode, selectedMenuIds);
        //    }
        //}
        private void dgv_MenuPhanQuyen_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                txt_TenDangNhap.Text = _MaNhanVien = dgv_MenuPhanQuyen.CurrentRow.Cells["MaNhanVien"].Value.ToString();
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
                                INSERT INTO mst_Users(MaNhanVien, MatKhau, Is_Admin, NgayTao, NguoiTao, del_flg)
                                VALUES({SQLHelper.rpStr(_MaNhanVien)}, {SQLHelper.rpStr(_MatKhau)}, 0, '{DateTime.Now}', {SQLHelper.rpStr(_NguoiTao)}, 0);
                            END ";
                    res = SQLHelper.ExecuteSql(sql);
                }

                if (res >= 0)
                {
                    List<int> selectedMenuIds = new List<int>();
                    List<int> selectedMenuChillIds = new List<int>();
                    List<int> selectedPermisionIds = new List<int>();

                    foreach (TreeNode rootNode in treeview_PhanQuyen.Nodes)
                    {
                        GetSelectedMenuIds(rootNode, selectedMenuIds, selectedMenuChillIds, selectedPermisionIds);
                    }

                    UpdateUserRolesForSelectedMenus(selectedMenuIds, selectedMenuChillIds, selectedPermisionIds);
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
        private List<(int menuId, int? permisionId)> GetSelectedPermisionIdsForMenu(int menuId)
        {
            List<(int menuId, int? permisionId)> permissionIds = new List<(int menuId, int? permisionId)>();  // Danh sách lưu cặp MenuId và PermisionId đã chọn

            foreach (TreeNode nodeLv0 in treeview_PhanQuyen.Nodes)
            {
                if (nodeLv0.ImageIndex == 1) // Kiểm tra nếu nodeLv0 được chọn
                {
                    foreach (TreeNode nodeLv1 in nodeLv0.Nodes)
                    {
                        if (nodeLv1.Level == 1 && int.Parse(nodeLv1.Tag.ToString()) == menuId)
                        {
                            if (nodeLv1.ImageIndex == 1)
                            {
                                // Kiểm tra xem nodeLv1 có node cấp 2 hay không
                                bool hasChildNodes = nodeLv1.Nodes.Count > 0;

                                if (!hasChildNodes)
                                {
                                    // Lưu cặp (menuId, nodeLv1) vào danh sách permissionIds
                                    permissionIds.Add((int.Parse(nodeLv0.Tag.ToString()), int.Parse(nodeLv1.Tag.ToString())));
                                }
                                else 
                                {
                                    bool nodeLv2Selected = false;

                                    foreach (TreeNode nodeLv2 in nodeLv1.Nodes)
                                    {
                                        if (nodeLv2.Level == 2 && nodeLv2.ImageIndex == 1)
                                        {
                                            // Lưu cặp (menuId, permisionId) cho nodeLv2
                                            permissionIds.Add((int.Parse(nodeLv1.Tag.ToString()), int.Parse(nodeLv2.Tag.ToString())));

                                            nodeLv2Selected = true;
                                        }
                                    }

                                    // Nếu có nodeLv2 được chọn, lưu nodeLv0 với permisionId là null
                                    if (nodeLv2Selected)
                                    {
                                        permissionIds.Add((int.Parse(nodeLv0.Tag.ToString()), null));
                                    }
                                }
                            }
                        }
                    }
                }
            }

            return permissionIds;
        }
        private void UpdateUserRolesForSelectedMenus(List<int> selectedMenuIds, List<int> selectedMenuChillIds, List<int> selectedPermisionIds)
        {
            List<int> allSelectedMenuIds = selectedMenuIds.Concat(selectedMenuChillIds).Concat(selectedPermisionIds).ToList();

            // Xóa những menu không được chọn
            string sqlDelete = $@"UPDATE mst_UserRoles
               SET Id_Permision = 0, del_flg = 1, NgayCapNhat = '{DateTime.Now}', NguoiCapNhat = {SQLHelper.rpStr(_NguoiCapNhat)}
               WHERE MaNhanVien = {SQLHelper.rpStr(_MaNhanVien)} 
               AND del_flg = 0 
               AND Id_Menu NOT IN ({string.Join(",", allSelectedMenuIds)})";
            SQLHelper.ExecuteSql(sqlDelete);

            // Cập nhật hoặc thêm mới các menu đã chọn
            List<string> sqlUpdateCommands = new List<string>();
            foreach (int menuId in allSelectedMenuIds)
            {
                List<(int menuId, int? permisionId)> permissionPairs = GetSelectedPermisionIdsForMenu(menuId); // Nhận danh sách cặp MenuId và PermisionId

                foreach (var pair in permissionPairs)
                {
                    // Nếu permisionId là null, lưu với Id_Permision là NULL
                    string sqlCommand = $@"
                    IF EXISTS(SELECT 1 FROM mst_UserRoles WHERE MaNhanVien = {SQLHelper.rpStr(_MaNhanVien)} AND Id_Menu = {SQLHelper.rpI(pair.menuId)} AND Id_Permision {(pair.permisionId.HasValue ? "= " + SQLHelper.rpI(pair.permisionId.Value) : "IS NULL")})
                    BEGIN
                        UPDATE mst_UserRoles
                        SET NgayCapNhat = '{DateTime.Now}', NguoiCapNhat = {SQLHelper.rpStr(_NguoiCapNhat)}, del_flg = 0
                        WHERE MaNhanVien = {SQLHelper.rpStr(_MaNhanVien)} AND Id_Menu = {SQLHelper.rpI(pair.menuId)} AND Id_Permision {(pair.permisionId.HasValue ? "= " + SQLHelper.rpI(pair.permisionId.Value) : "IS NULL")};
                    END
                    ELSE
                    BEGIN
                        INSERT INTO mst_UserRoles(MaNhanVien, Id_Menu, Id_Permision, NgayTao, NguoiTao, del_flg)
                        VALUES({SQLHelper.rpStr(_MaNhanVien)}, {SQLHelper.rpI(pair.menuId)}, {(pair.permisionId.HasValue ? SQLHelper.rpI(pair.permisionId.Value) : "NULL")}, '{DateTime.Now}', {SQLHelper.rpStr(_NguoiTao)}, 0);
                    END";
                            sqlUpdateCommands.Add(sqlCommand);
                        }
            }
            string allSqlCommands = string.Join(" ", sqlUpdateCommands);
            SQLHelper.ExecuteSql(allSqlCommands);
        }
        private void LoadData(int pageIndex)
        {
            try
            {
                if (cbo_pagenumber.ComboBox.SelectedValue != null)
                {
                    PageSize = int.Parse(cbo_pagenumber.ComboBox.SelectedValue.ToString());
                }
                string sql = string.Empty;
                sql = $@"
                        SELECT us.MaNhanVien, nv.TenNhanVien, pb.TenPhongBan, cv.TenChucVu 
                        FROM mst_Users us
                        INNER JOIN [MITACOSQL].[dbo].[NHANVIEN] nv ON us.MaNhanVien = nv.MaNhanVien
                        INNER JOIN [MITACOSQL].[dbo].[PHONGBAN] pb ON nv.MaPhongBan = pb.MaPhongBan
                        LEFT JOIN mst_ChucVu cv ON nv.MaChucVu = cv.MaChucVu
                        WHERE us.del_flg = 0
                        AND ({(string.IsNullOrEmpty(_PhongBan) ? "1=1" : $"pb.MaPhongBan = {SQLHelper.rpStr(_PhongBan)}")})
                        ORDER BY MaNhanVien
                        OFFSET ({SQLHelper.rpI(pageIndex)} - 1) * {SQLHelper.rpI(PageSize)} ROWS
                        FETCH NEXT {SQLHelper.rpI(PageSize)} ROWS ONLY;";

                DataTable dt = SQLHelper.ExecuteDt(sql);
                this.HienThiThanhDieuHuong(recordCount, pageIndex);
                dgv_MenuPhanQuyen.DataSource = dt;

                //SqlParameter[] param = new SqlParameter[]
                //{
                //    new SqlParameter("@PageNumber", SqlDbType.Int) {Value = pageIndex},
                //    new SqlParameter("@PageSize", SqlDbType.Int) {Value = PageSize},
                //    new SqlParameter("@MaPhongBan", SqlDbType.NVarChar) {Value = _PhongBan}
                //};
                //DataTable dt = SQLHelper.DataTableByProcedure("GetMenuByEmployee", param);
                //dgv_MenuPhanQuyen.DataSource = dt;

                //List<DataGridViewColumn> columnsToModify = new List<DataGridViewColumn>();

                //foreach (DataGridViewColumn column in dgv_MenuPhanQuyen.Columns)
                //{
                //    List<string> columnHeadersToExclude = new List<string>
                //    {
                //        "TenNhanVien",
                //        "Tên nhân viên",
                //        "MaNhanVien",
                //        "Mã nhân viên",
                //        "TenPhongBan",
                //        "Tên phòng ban",
                //        "TenChucVu",
                //        "Tên chức vụ"
                //    };
                //    if (!columnHeadersToExclude.Contains(column.HeaderText.ToString()))
                //    {
                //        columnsToModify.Add(column);
                //    }
                //    else
                //    {
                //        switch (column.HeaderText)
                //        {
                //            case "TenNhanVien":
                //                column.HeaderText = "Tên nhân viên";
                //                break;
                //            case "MaNhanVien":
                //                column.HeaderText = "Mã nhân viên";
                //                break;
                //            case "TenPhongBan":
                //                column.HeaderText = "Tên phòng ban";
                //                break;
                //            case "TenChucVu":
                //                column.HeaderText = "Tên chức vụ";
                //                break;
                //            default:
                //                break;
                //        }
                //    }
                //}

                //foreach (DataGridViewColumn column in columnsToModify)
                //{
                //    if (!(column is DataGridViewCheckBoxColumn))
                //    {
                //        DataGridViewCheckBoxColumn checkBoxColumn = new DataGridViewCheckBoxColumn();
                //        checkBoxColumn.HeaderText = column.HeaderText;
                //        checkBoxColumn.Name = column.Name;
                //        checkBoxColumn.DataPropertyName = column.DataPropertyName;
                //        checkBoxColumn.ReadOnly = true;

                //        // Thay thế cột hiện tại bằng cột Checkbox
                //        dgv_MenuPhanQuyen.Columns.Remove(column);
                //        dgv_MenuPhanQuyen.Columns.Add(checkBoxColumn);
                //    }
                //}

                //foreach (DataGridViewColumn column in dgv_MenuPhanQuyen.Columns)
                //{
                //    column.AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
                //}
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
        private void cbo_BoPhan_SelectionChangeCommitted(object sender, EventArgs e)
        {
            _PhongBan = cbo_BoPhan.ComboBox.SelectedValue.ToString();
            LoadComboboxNhanVien(true);
            LoadData(1);
        }
        private void GetSelectedMenuIds(TreeNode node, List<int> selectedMenuIds, List<int> selectedMenuChillIds, List<int> selectedPermisionIds)
        {
            if (node.ImageIndex == 1)
            {
                if (node.Level == 0)
                {
                    selectedMenuIds.Add(int.Parse(node.Tag.ToString()));
                }
                else if (node.Level == 1)
                {
                    selectedMenuChillIds.Add(int.Parse(node.Tag.ToString()));
                }
                else if (node.Level == 2)
                {
                    selectedPermisionIds.Add(int.Parse(node.Tag.ToString()));
                }
            }

            foreach (TreeNode childNode in node.Nodes)
            {
                GetSelectedMenuIds(childNode, selectedMenuIds, selectedMenuChillIds, selectedPermisionIds);
            }
        }
    }
}