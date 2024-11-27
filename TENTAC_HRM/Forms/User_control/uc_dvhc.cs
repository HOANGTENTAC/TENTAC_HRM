using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Windows.Forms;

namespace TENTAC_HRM.Forms.User_control
{
    public partial class uc_dvhc : UserControl
    {
        public static uc_dvhc _instance;
        int? IdTinhThanh, IdQuanHuyen, IdPhuongXa = null;
        private List<CheckBox> checkBoxGroup;
        public static uc_dvhc Instance
        {
            get
            {
                if (_instance == null)
                    _instance = new uc_dvhc();
                return _instance;
            }
        }
        public uc_dvhc()
        {
            InitializeComponent();
            this.Load += new System.EventHandler(this.uc_dvhc_Load);
            this.Resize += new EventHandler(this.Form_Resize);
            checkBoxGroup = new List<CheckBox> { ckbTinhThanh, ckbQuanHuyen, ckbPhuongXa };
        }
        private void Form_Resize(object sender, EventArgs e)
        {
            listView.Height = this.ClientSize.Height * 4 / 5;
        }
        private void uc_dvhc_Load(object sender, EventArgs e)
        {
            LoadData();
            LoadVung();
            LoadNull();
        }
        private void LoadNull()
        {
            txtPhuongXa.Text = string.Empty;
            txtTinhThanh.Text = string.Empty;
            txtQuanHuyen.Text = string.Empty;
            cboVung.SelectedIndex = 0;
        }
        private void LoadVung()
        {
            string sql = @"Select Id, Vung from tbl_MucLuongToiThieu where del_flg = 0";
            DataTable DT = SQLHelper.ExecuteDt(sql);
            DataRow row = DT.NewRow();
            row["Vung"] = "---Chọn Vùng---";
            DT.Rows.InsertAt(row, 0);
            cboVung.DataSource = DT;
            cboVung.DisplayMember = "Vung";
            cboVung.ValueMember = "Id";
        }
        private void LoadData()
        {
            listView.View = View.Details;
            listView.FullRowSelect = true;

            string SQL = $@"Select * from mst_DonViHanhChinh WHERE del_flg = 0";
            DataTable DT = SQLHelper.ExecuteDt(SQL);

            var filteredRowsTinhThanh = DT.AsEnumerable().Where(row => row.Field<int?>("CapBac") == 1);
            DataTable dtTinhThanh = filteredRowsTinhThanh.Any() ? filteredRowsTinhThanh.CopyToDataTable() : DT.Clone();

            foreach (DataRow rowTinhThanh in dtTinhThanh.Rows)
            {
                string tinhThanh = rowTinhThanh["TenDiaChi"].ToString();
                int tinhThanhId = Convert.ToInt32(rowTinhThanh["Id"]);
                TreeNode nodeTinhThanh = new TreeNode(tinhThanh);
                nodeTinhThanh.Tag = tinhThanhId;

                // Lấy danh sách huyện
                var filteredRowsHuyen = DT.AsEnumerable().Where(row => row.Field<int?>("CapBac") == 2 && row.Field<int>("ParentId") == tinhThanhId);
                DataTable dtHuyen = filteredRowsHuyen.Any() ? filteredRowsHuyen.CopyToDataTable() : DT.Clone();

                foreach (DataRow rowHuyen in dtHuyen.Rows)
                {
                    string huyen = rowHuyen["TenDiaChi"].ToString();
                    int huyenId = Convert.ToInt32(rowHuyen["Id"]);
                    TreeNode nodeHuyen = new TreeNode(huyen);
                    nodeHuyen.Tag = huyenId;
                    nodeTinhThanh.Nodes.Add(nodeHuyen);

                    // Lấy danh sách xã
                    var filteredRowsXa = DT.AsEnumerable().Where(row => row.Field<int?>("CapBac") == 3 && row.Field<int>("ParentId") == huyenId);
                    DataTable dtXa = filteredRowsXa.Any() ? filteredRowsXa.CopyToDataTable() : DT.Clone();

                    foreach (DataRow rowXa in dtXa.Rows)
                    {
                        string xa = rowXa["TenDiaChi"].ToString();
                        int xaId = Convert.ToInt32(rowXa["Id"]);
                        TreeNode nodeXa = new TreeNode(xa);
                        nodeXa.Tag = xaId;
                        nodeHuyen.Nodes.Add(nodeXa);
                    }
                }

                treeView.Nodes.Add(nodeTinhThanh);
            }

            treeView.AfterSelect += (sender, e) =>
            {
                listView.Items.Clear();
                TreeNode selectedNode = e.Node;
                string selectedText = selectedNode.Text;
                int selectedId = Convert.ToInt32(selectedNode.Tag);

                // Kiểm tra Level để điền vào TextBox tương ứng
                switch (selectedNode.Level)
                {
                    case 0:
                        txtTinhThanh.Text = selectedText;
                        txtQuanHuyen.Clear();
                        txtPhuongXa.Clear();
                        break;
                    case 1:
                        txtQuanHuyen.Text = selectedText;
                        txtPhuongXa.Clear();
                        break;
                    case 2:
                        txtPhuongXa.Text = selectedText;
                        break;
                    default:
                        txtTinhThanh.Clear();
                        txtQuanHuyen.Clear();
                        txtPhuongXa.Clear();
                        break;
                };
                IdTinhThanh = DT.AsEnumerable()
                   .Where(row => row.Field<string>("TenDiaChi") == txtTinhThanh.Text.ToString())
                   .Select(row => row.Field<int>("Id"))
                   .FirstOrDefault();
                IdQuanHuyen = DT.AsEnumerable()
                   .Where(row => row.Field<string>("TenDiaChi") == txtQuanHuyen.Text.ToString())
                   .Select(row => row.Field<int>("Id"))
                   .FirstOrDefault();
                IdPhuongXa = DT.AsEnumerable()
                   .Where(row => row.Field<string>("TenDiaChi") == txtPhuongXa.Text.ToString())
                   .Select(row => row.Field<int>("Id"))
                   .FirstOrDefault();
                if (selectedNode.Parent != null)
                {
                    if (selectedNode.Parent.Level == 0 || selectedNode.Parent.Level == 1)
                    {
                        string sqlDetail = $@"SELECT DVHC.Id, TenDiaChi, Vung, LuongToiThieuTheoThang, LuongToiThieuTheoGio
                                  FROM mst_DonViHanhChinh DVHC
                                  LEFT JOIN tbl_MucLuongToiThieu V ON DVHC.MaKhuVuc = V.Id
                                  WHERE DVHC.Id = {selectedId} and DVHC.del_flg = 0";
                        DataTable dtDetail = SQLHelper.ExecuteDt(sqlDetail);

                        foreach (DataRow rowDetail in dtDetail.Rows)
                        {
                            string tenDiaChi = rowDetail["TenDiaChi"].ToString();
                            string vung = rowDetail["Vung"].ToString();
                            string mucLuongThang = rowDetail["LuongToiThieuTheoThang"] != DBNull.Value ? string.Concat(Convert.ToDouble(rowDetail["LuongToiThieuTheoThang"]).ToString("N1"), "00") : "";
                            string mucLuongGio = rowDetail["LuongToiThieuTheoGio"] != DBNull.Value ? string.Concat(Convert.ToDouble(rowDetail["LuongToiThieuTheoGio"]).ToString("N1"), "00") : "";

                            ListViewItem listItem = new ListViewItem(tenDiaChi);
                            listItem.SubItems.Add(vung);
                            listItem.SubItems.Add(mucLuongThang);
                            listItem.SubItems.Add(mucLuongGio);
                            listView.Items.Add(listItem);
                            if (!string.IsNullOrEmpty(vung))
                            {
                                cboVung.Text = vung;
                            }
                            else
                            {
                                cboVung.SelectedIndex = 0;
                            }
                        }
                    }
                }
            };
        }
        private void checkBoxGroup_CheckedChanged(object sender, EventArgs e)
        {
            CheckBox selectedCheckBox = sender as CheckBox;
            if (selectedCheckBox.Checked)
            {
                foreach (CheckBox checkBox in checkBoxGroup)
                {
                    if (checkBox != selectedCheckBox)
                    {
                        checkBox.Checked = false;
                    }
                }
            }
        }
        private void btn_add_Click(object sender, EventArgs e)
        {
            string sql = string.Empty;
            string TenDiaChi = string.Empty;

            if (ckbTinhThanh.Checked == true)
            {
                if (!string.IsNullOrEmpty(txtTinhThanh.Text))
                {
                    TenDiaChi = txtTinhThanh.Text.Trim();
                    sql = @"INSERT INTO mst_DonViHanhChinh (TenDiaChi, CapBac, ParentId, MaKhuVuc, NgayTao, NguoiTao, NgayCapNhat, NguoiCapNhat)
                    SELECT @TenDiaChi, @CapBac, @ParentId, NULL, @NgayTao, @NguoiTao, @NgayCapNhat, @NguoiCapNhat
                    WHERE NOT EXISTS (SELECT 1 FROM mst_DonViHanhChinh WHERE TenDiaChi = @TenDiaChi AND CapBac = 1 and del_flg = 0)";

                    var parameters = new List<SqlParameter>
                    {
                        new SqlParameter("@TenDiaChi", TenDiaChi),
                        new SqlParameter("@CapBac", 1),
                        new SqlParameter("@ParentId", 1),
                        new SqlParameter("@NgayTao", DateTime.Now),
                        new SqlParameter("@NguoiTao", ""),
                        new SqlParameter("@NgayCapNhat", DateTime.Now),
                        new SqlParameter("@NguoiCapNhat", "")
                    };
                    SQLHelper.ExecuteSql(sql, parameters.ToArray());
                }
                else
                {
                    MessageBox.Show("Bạn chưa nhập tên Tỉnh/Thành");
                    return;
                }
            }
            else if (ckbQuanHuyen.Checked == true)
            {
                if (!string.IsNullOrEmpty(txtQuanHuyen.Text) && !string.IsNullOrEmpty(txtTinhThanh.Text))
                {
                    object Vung = DBNull.Value;
                    int? parentId = GetParentId(txtTinhThanh.Text.ToString(), 1);
                    TenDiaChi = txtQuanHuyen.Text.ToString().Trim();
                    if (cboVung.SelectedIndex != 0)
                    {
                        Vung = Convert.ToInt32(cboVung.SelectedValue);
                    }
                    sql = @"INSERT INTO mst_DonViHanhChinh (TenDiaChi, CapBac, ParentId, MaKhuVuc, NgayTao, NguoiTao, NgayCapNhat, NguoiCapNhat)
                    SELECT @TenDiaChi, @CapBac, @ParentId, @MaKhuVuc, @NgayTao, @NguoiTao, @NgayCapNhat, @NguoiCapNhat
                    WHERE NOT EXISTS (SELECT 1 FROM mst_DonViHanhChinh WHERE TenDiaChi = @TenDiaChi AND CapBac = @CapBac and del_flg = 0)";

                    var parameters = new List<SqlParameter>
                    {
                        new SqlParameter("@TenDiaChi", TenDiaChi),
                        new SqlParameter("@CapBac", 2),
                        new SqlParameter("@ParentId", parentId.Value),
                        new SqlParameter("@MaKhuVuc", Vung),
                        new SqlParameter("@NgayTao", DateTime.Now),
                        new SqlParameter("@NguoiTao", ""),
                        new SqlParameter("@NgayCapNhat", DateTime.Now),
                        new SqlParameter("@NguoiCapNhat", "")
                    };
                    SQLHelper.ExecuteSql(sql, parameters.ToArray());
                }
                else
                {
                    MessageBox.Show("Bạn chưa nhập tên Tỉnh/Thành và Quận/Huyện");
                    return;
                }
            }
            else if (ckbPhuongXa.Checked == true)
            {
                if (!string.IsNullOrEmpty(txtPhuongXa.Text) && !string.IsNullOrEmpty(txtQuanHuyen.Text))
                {
                    int? parentId = GetParentId(txtQuanHuyen.Text.Trim(), 2);
                    if (parentId.HasValue)
                    {
                        TenDiaChi = txtPhuongXa.Text.Trim();
                        sql = @"INSERT INTO mst_DonViHanhChinh (TenDiaChi, CapBac, ParentId, NgayTao, NguoiTao, NgayCapNhat, NguoiCapNhat)
                        SELECT @TenDiaChi, @CapBac, @ParentId, @NgayTao, @NguoiTao, @NgayCapNhat, @NguoiCapNhat
                        WHERE NOT EXISTS (SELECT 1 FROM mst_DonViHanhChinh WHERE TenDiaChi = @TenDiaChi AND CapBac = @CapBac and del_flg = 0)";

                        var parameters = new List<SqlParameter>
                        {
                            new SqlParameter("@TenDiaChi", TenDiaChi),
                            new SqlParameter("@CapBac", 3),
                            new SqlParameter("@ParentId", parentId.Value),
                            new SqlParameter("@NgayTao", DateTime.Now),
                            new SqlParameter("@NguoiTao", ""),
                            new SqlParameter("@NgayCapNhat", DateTime.Now),
                            new SqlParameter("@NguoiCapNhat", ""),
                        };
                        SQLHelper.ExecuteSql(sql, parameters.ToArray());
                    }
                }
                else
                {
                    MessageBox.Show("Bạn chưa nhập tên Quận/Huyện và Phường/Xã");
                    return;
                }
            }
            else
            {
                if (!string.IsNullOrEmpty(txtTinhThanh.Text))
                {
                    TenDiaChi = txtTinhThanh.Text.Trim();
                    sql = $@"UPDATE mst_DonViHanhChinh 
                    SET TenDiaChi = @TenDiaChi, NgayCapNhat = @NgayCapNhat, NguoiCapNhat = @NguoiCapNhat
                    WHERE Id = {IdTinhThanh} and del_flg = 0";

                    var parameters = new List<SqlParameter>
                    {
                        new SqlParameter("@TenDiaChi", TenDiaChi),
                        new SqlParameter("@NgayCapNhat", DateTime.Now),
                        new SqlParameter("@NguoiCapNhat", "")
                    };
                    SQLHelper.ExecuteSql(sql, parameters.ToArray());
                }
                if (!string.IsNullOrEmpty(txtQuanHuyen.Text))
                {
                    object Vung = DBNull.Value;
                    TenDiaChi = txtQuanHuyen.Text.Trim();
                    sql = $@"UPDATE mst_DonViHanhChinh 
                        SET TenDiaChi = @TenDiaChi, MaKhuVuc = @MaKhuVuc ,NgayCapNhat = @NgayCapNhat, NguoiCapNhat = @NguoiCapNhat
                        WHERE Id = {IdQuanHuyen} and del_flg = 0";

                    if (cboVung.SelectedIndex != 0)
                    {
                        Vung = Convert.ToInt32(cboVung.SelectedValue);
                    }
                    var parameters = new List<SqlParameter>
                    {
                        new SqlParameter("@TenDiaChi", TenDiaChi),
                        new SqlParameter("@MaKhuVuc", Vung),
                        new SqlParameter("@NgayCapNhat", DateTime.Now),
                        new SqlParameter("@NguoiCapNhat", "")
                    };
                    SQLHelper.ExecuteSql(sql, parameters.ToArray());
                }
                if (!string.IsNullOrEmpty(txtPhuongXa.Text))
                {
                    TenDiaChi = txtPhuongXa.Text.Trim();
                    sql = $@"UPDATE mst_DonViHanhChinh 
                        SET TenDiaChi = @TenDiaChi, NgayCapNhat = @NgayCapNhat, NguoiCapNhat = @NguoiCapNhat
                        WHERE Id = {IdPhuongXa} and del_flg = 0";
                    var parameters = new List<SqlParameter>
                    {
                        new SqlParameter("@TenDiaChi", TenDiaChi),
                        new SqlParameter("@NgayCapNhat", DateTime.Now),
                        new SqlParameter("@NguoiCapNhat", "")
                    };
                    SQLHelper.ExecuteSql(sql, parameters.ToArray());
                }
            }
            LoadData();
            LoadVung();
        }
        private int? GetParentId(string tenDiaChi, int capBac)
        {
            string sql = $@"SELECT Id FROM mst_DonViHanhChinh WHERE TenDiaChi = @TenDiaChi AND CapBac = @CapBac and del_flg = 0";
            var parameters = new List<SqlParameter>
            {
                new SqlParameter("@TenDiaChi", tenDiaChi),
                new SqlParameter("@CapBac", capBac)
            };
            object result = SQLHelper.ExecuteScalarSql(sql, parameters.ToArray());
            return result != null ? (int?)Convert.ToInt32(result) : null;
        }
        private void btn_delete_Click(object sender, EventArgs e)
        {
            if (ckbTinhThanh.Checked)
            {
                UpdateDelFlag(Convert.ToInt32(IdTinhThanh));
            }
            else if (ckbQuanHuyen.Checked)
            {
                UpdateDelFlag(Convert.ToInt32(IdQuanHuyen));
            }
            else if (ckbPhuongXa.Checked)
            {
                UpdateDelFlag(Convert.ToInt32(IdPhuongXa));
            }
            LoadData();
            LoadVung();
        }

        private void UpdateDelFlag(int id)
        {
            string sql = $@"WITH RecursiveDel AS (
                SELECT Id FROM mst_DonViHanhChinh WHERE Id = @Id
                UNION ALL
                SELECT child.Id FROM mst_DonViHanhChinh child
                INNER JOIN RecursiveDel parent ON child.ParentId = parent.Id
            )
            UPDATE mst_DonViHanhChinh 
            SET del_flg = 1, NgayCapNhat = @NgayCapNhat, NguoiCapNhat = @NguoiCapNhat
            WHERE Id IN (SELECT Id FROM RecursiveDel)";

            var parameters = new List<SqlParameter>
            {
                new SqlParameter("@Id", id),
                new SqlParameter("@NgayCapNhat", DateTime.Now),
                new SqlParameter("@NguoiCapNhat", "")
            };
            SQLHelper.ExecuteSql(sql, parameters.ToArray());
            LoadData();
            LoadNull();
        }
    }
}