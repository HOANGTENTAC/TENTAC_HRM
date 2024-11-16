using NPOI.SS.UserModel;
using System;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Windows.Forms;
using TENTAC_HRM.BusinessLogicLayer.QuanLyNhanVienBLL;
using TENTAC_HRM.Common;
using TENTAC_HRM.Custom;
using TENTAC_HRM.DataTransferObject.QuanLyNhanVienDTO;

namespace TENTAC_HRM.Forms.ChamCong
{
    public partial class frm_NuoiConNho : Form
    {
        private CongTyBLL _congTyBLL = new CongTyBLL();

        private CongTyDTO _congTyDTO = new CongTyDTO();

        private KhuVucBLL _khuVucBLL = new KhuVucBLL();

        private KhuVucDTO _khuVucDTO = new KhuVucDTO();

        private PhongBanBLL _phongBanBLL = new PhongBanBLL();

        private PhongBanDTO _phongBanDTO = new PhongBanDTO();

        private ChucVuBLL _chucVuBLL = new ChucVuBLL();
        private ChucVuDTO _chucVuDTO = new ChucVuDTO();
        private NhanVienBLL _nhanVienBLL = new NhanVienBLL();

        private NhanVienDTO _nhanVienDTO = new NhanVienDTO();

        private string sMaChamCong;

        private string _tenNode;

        private string sMaPhongBanTreeView;

        private string sMaCongTyTreeView;

        private string sMaKhuVucTreeView;

        private string sMaChucVuTreeView;
        CheckBox headerCheckBox = new CheckBox();
        private ISheet xlSheet = null;
        public frm_NuoiConNho()
        {
            InitializeComponent();
        }

        private void frm_NuoiConNho_Load(object sender, EventArgs e)
        {
            dtp_TuNgaySearch.Value = DateTime.Now;
            dtp_DenNgaySearch.Value = DateTime.Now;
            dtp_TuNgay.Value = DateTime.Now;
            dtp_DenNgay.Value = DateTime.Now;
            BindGrid();
            loadTreeView();
            treeViewSoDoQuanLy.Nodes[0].ExpandAll();
            treeViewSoDoQuanLy.SelectedNode = treeViewSoDoQuanLy.Nodes[0].Nodes[1];
        }
        private void BindGrid()
        {
            //Find the Location of Header Cell.
            Point headerCellLocation = this.DGVNhanVien.GetCellDisplayRectangle(0, -1, true).Location;

            //Place the Header CheckBox in the Location of the Header Cell.
            headerCheckBox.Location = new Point(headerCellLocation.X + 8, headerCellLocation.Y + 2);
            headerCheckBox.BackColor = Color.Transparent;
            headerCheckBox.Size = new Size(18, 18);

            //Assign Click event to the Header CheckBox.
            headerCheckBox.Click += new EventHandler(HeaderCheckBox_Clicked);
            DGVNhanVien.Controls.Add(headerCheckBox);
        }
        private void HeaderCheckBox_Clicked(object sender, EventArgs e)
        {
            //Necessary to end the edit mode of the Cell.
            DGVNhanVien.EndEdit();

            //Loop and check and uncheck all row CheckBoxes based on Header Cell CheckBox.
            foreach (DataGridViewRow row in DGVNhanVien.Rows)
            {
                DataGridViewCheckBoxCell checkBox = (row.Cells["chk_col"] as DataGridViewCheckBoxCell);
                checkBox.Value = headerCheckBox.Checked;
            }
        }
        private void loadTreeView()
        {
            DataTable dtCongTy = _congTyBLL.showThongTinCongTy(_congTyDTO);
            for (int i = 0; i < dtCongTy.Rows.Count; i++)
            {
                TreeNode treeCongTy = new TreeNode();
                treeCongTy.Text = dtCongTy.Rows[i][1].ToString();
                treeCongTy.Tag = dtCongTy.Rows[i][0].ToString();
                treeViewSoDoQuanLy.Nodes.Add(treeCongTy);
                _khuVucDTO.MaCongTy = dtCongTy.Rows[i]["MaCongTy"].ToString();
                DataTable dtKhuVuc = _khuVucBLL.GETKHUVUCTREEVIEW(_khuVucDTO);
                for (int j = 0; j < dtKhuVuc.Rows.Count; j++)
                {
                    TreeNode treeKhuVuc = new TreeNode();
                    treeKhuVuc.Text = dtKhuVuc.Rows[j][2].ToString();
                    treeKhuVuc.Tag = dtKhuVuc.Rows[j][0].ToString();
                    treeViewSoDoQuanLy.Nodes[i + 0].Nodes.Add(treeKhuVuc);
                    _phongBanDTO.MaKhuVuc = dtKhuVuc.Rows[j]["MaKhuVuc"].ToString();
                    DataTable dtPhongBan = _phongBanBLL.GETPHONGBANTREEVIEW(_phongBanDTO);

                    for (int z = 0; z < dtPhongBan.Rows.Count; z++)
                    {
                        TreeNode treePhongBan = new TreeNode();
                        treePhongBan.Text = dtPhongBan.Rows[z][3].ToString();
                        treePhongBan.Tag = dtPhongBan.Rows[z][0].ToString();
                        treeViewSoDoQuanLy.Nodes[i + 0].Nodes[j].Nodes.Add(treePhongBan);
                        _chucVuDTO.MaPhongBan = dtPhongBan.Rows[z]["MaPhongBan"].ToString();
                        DataTable dtChucVu = _chucVuBLL.GETCHUCVUTREEVIEW(_chucVuDTO);
                        for (int v = 0; v < dtChucVu.Rows.Count; v++)
                        {
                            TreeNode treeChucVu = new TreeNode();
                            treeChucVu.Text = dtChucVu.Rows[v][4].ToString();
                            treeChucVu.Tag = dtChucVu.Rows[v][0].ToString();
                            treeViewSoDoQuanLy.Nodes[i + 0].Nodes[j].Nodes[z].Nodes.Add(treeChucVu);
                            _chucVuDTO.MaChucVu = dtChucVu.Rows[v]["MaChucVu"].ToString();
                        }
                    }
                }
            }
        }
        private void btn_Search_Click(object sender, EventArgs e)
        {
            LoadData();
        }
        private void LoadData()
        {
            var checkedRows = (from DataGridViewRow r in DGVNhanVien.Rows
                               where Convert.ToBoolean(r.Cells[0].Value) == true
                               select r.Cells[3].Value.ToString()).ToList();

            string sql = "select a.Id,b.MaNhanVien,b.TenNhanVien,a.NgayBatDau,a.NgayKetThuc,c.TenPhongBan " +
                         "from DanhSachNuoiConNho a " +
                         "join NhanVien b on a.MaChamCong = b.MaChamCong " +
                         "join PhongBan c on b.MaPhongBan = c.MaPhongBan " +
                         $"where a.NgayBatDau >= '{dtp_TuNgaySearch.Text}' and a.NgayBatDau <= '{dtp_DenNgaySearch.Text}'";
            if (checkedRows.Count > 0)
            {
                sql += $" and a.MaChamCong in ('{string.Join("','", checkedRows)}')";
            }
            DataTable dt = new DataTable();
            dt = SQLHelper.ExecuteDt(sql);
            dgv_Data.DataSource = dt;
        }
        private void treeViewSoDoQuanLy_AfterSelect(object sender, TreeViewEventArgs e)
        {
            sMaCongTyTreeView = "";
            sMaKhuVucTreeView = "";
            sMaPhongBanTreeView = "";
            sMaChucVuTreeView = "";
            DGVNhanVien.Rows.Clear();
            DataTable dtNhanVien = new DataTable();
            if (treeViewSoDoQuanLy.SelectedNode.Tag.ToString() == "CT00001")
            {
                sMaCongTyTreeView = "CT00001";
            }
            _tenNode = treeViewSoDoQuanLy.SelectedNode.Text;
            DataTable dtTreeviewPhongBan = new DataTable();
            _phongBanDTO.TenPhongBan = _tenNode;
            dtTreeviewPhongBan = _phongBanBLL.PhongBanGetTreeView(_phongBanDTO);
            for (int iTreeviewPhongBan = 0; iTreeviewPhongBan < dtTreeviewPhongBan.Rows.Count; iTreeviewPhongBan++)
            {
                sMaPhongBanTreeView = dtTreeviewPhongBan.Rows[iTreeviewPhongBan]["MaPhongBan"].ToString();
            }
            DataTable dtTreeViewCongTy = new DataTable();
            _congTyDTO.TenCongTy = _tenNode;
            dtTreeViewCongTy = _congTyBLL.CongTygetTreeView(_congTyDTO);
            DataTable dtTreeViewKhuVuc = new DataTable();
            _khuVucDTO.TenKhuVuc = _tenNode;
            dtTreeViewKhuVuc = _khuVucBLL.KhuVucgetTreeView(_khuVucDTO);
            for (int iTreeviewKhuVuc = 0; iTreeviewKhuVuc < dtTreeViewKhuVuc.Rows.Count; iTreeviewKhuVuc++)
            {
                sMaKhuVucTreeView = dtTreeViewKhuVuc.Rows[iTreeviewKhuVuc]["MaKhuVuc"].ToString();
            }
            DataTable dtTreeViewChucVu = new DataTable();
            _chucVuDTO.TenChucVu = _tenNode;
            dtTreeViewChucVu = _chucVuBLL.ChucVugetTreeView(_chucVuDTO);
            for (int iTreeviewChucVu = 0; iTreeviewChucVu < dtTreeViewChucVu.Rows.Count; iTreeviewChucVu++)
            {
                sMaChucVuTreeView = dtTreeViewChucVu.Rows[iTreeviewChucVu]["MaChucVu"].ToString();
            }
            _nhanVienDTO.MaCongTy = sMaCongTyTreeView;
            _nhanVienDTO.MaKhuVuc = sMaKhuVucTreeView;
            _nhanVienDTO.MaPhongBan = sMaPhongBanTreeView;
            _nhanVienDTO.MaChucVu = sMaChucVuTreeView;
            dtNhanVien = _nhanVienBLL.NhanViengetFromTreeview(_nhanVienDTO);

            for (int iNhanVien = 0; iNhanVien < dtNhanVien.Rows.Count; iNhanVien++)
            {
                int addNhanVien = DGVNhanVien.Rows.Add();
                DGVNhanVien.Rows[addNhanVien].Cells[1].Value = dtNhanVien.Rows[iNhanVien]["MaNhanVien"].ToString();
                DGVNhanVien.Rows[addNhanVien].Cells[2].Value = dtNhanVien.Rows[iNhanVien]["TenNhanVien"].ToString();
                DGVNhanVien.Rows[addNhanVien].Cells[3].Value = dtNhanVien.Rows[iNhanVien]["MaChamCong"].ToString();
                DGVNhanVien.Rows[addNhanVien].Cells[4].Value = dtNhanVien.Rows[iNhanVien]["MaPhongBan"].ToString();
            }
            gbNhanVien.Text = "Nhân viên : " + dtNhanVien.Rows.Count;
        }

        private void btn_Add_Click(object sender, EventArgs e)
        {
            try
            {
                var checkedRows = (from DataGridViewRow r in DGVNhanVien.Rows
                                   where Convert.ToBoolean(r.Cells[0].Value) == true
                                   select r.Cells["MaChamCong"].Value.ToString()).ToList();
                if (checkedRows.Count() > 0)
                {
                    foreach (string item in checkedRows)
                    {
                        string sql = "insert into DanhSachNuoiConNho(MaChamCong,NgayBatDau,NgayKetThuc) " +
                                     $"values('{item}','{dtp_TuNgay.Text}','{dtp_DenNgay.Text}')";
                        SQLHelper.ExecuteSql(sql);
                    }
                    RJMessageBox.Show("Thêm thành công");
                    LoadData();
                }
                else
                {
                    RJMessageBox.Show("Chưa có nhân viên nào được chọn");
                }
            }
            catch (Exception ex)
            {
                RJMessageBox.Show(ex.Message, "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btn_Delete_Click(object sender, EventArgs e)
        {
            try
            {
                var checkedRows = (from DataGridViewRow r in dgv_Data.Rows
                                   where Convert.ToBoolean(r.Cells[0].Value) == true
                                   select r.Cells["Id"].Value.ToString()).ToList();
                if (checkedRows.Count > 0)
                {
                    foreach (string item in checkedRows)
                    {
                        string sql = $"delete DanhSachNuoiConNho where id = '{item}'";
                        SQLHelper.ExecuteSql(sql);
                    }
                    RJMessageBox.Show("Xóa thành công");
                    LoadData();
                }
                else
                {
                    RJMessageBox.Show("Chưa có nhân viên nào được chọn");
                }
            }
            catch (Exception ex)
            {
                RJMessageBox.Show(ex.Message, "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void dgv_Data_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dgv_Data.CurrentCell.OwningColumn.Name == "delete_col")
            {
                try
                {
                    string sql = $"delete DanhSachNuoiConNho where id = '{dgv_Data.CurrentRow.Cells["Id"].Value.ToString()}'";
                    SQLHelper.ExecuteSql(sql);
                    RJMessageBox.Show("Xóa thành công");
                    LoadData();
                }
                catch (Exception ex)
                {
                    RJMessageBox.Show(ex.Message, "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }
        private string Range(string zahyo)
        {
            return XlsCommon.GetCellValue(zahyo, xlSheet);
        }

        private void btn_ImportExcel_Click(object sender, EventArgs e)
        {
            SqlConnection cn = new SqlConnection(SQLHelper.GetSqlConnection());
            cn.Open();
            SqlTransaction tr = cn.BeginTransaction();
            try
            {
                OpenFileDialog file = new OpenFileDialog();
                if (file.ShowDialog() == DialogResult.OK)
                {
                    string fileExt = Path.GetExtension(file.FileName); //get the file extension
                    if (fileExt.CompareTo(".xls") == 0 || fileExt.CompareTo(".xlsx") == 0)
                    {
                        Cursor.Current = Cursors.WaitCursor;
                        IWorkbook xlBook = null;
                        try
                        {
                            using (FileStream inputStream = new FileStream(file.FileName, FileMode.Open, FileAccess.Read))
                            {
                                xlBook = WorkbookFactory.Create(inputStream);
                            }
                        }
                        catch (Exception ex)
                        {
                            throw new Exception("File " + file.FileName + " đang mở vui lòng đóng file vào thao tác lại!", ex);
                        }
                        bool inser_sheet = false;
                        for (int i = 0; i < xlBook.NumberOfSheets; i++)
                        {
                            var index_select = xlBook.ActiveSheetIndex;
                            if (chk_new.Checked == true && inser_sheet == false)
                            {
                                inser_sheet = true;
                                i = index_select;
                            }
                            else if (chk_new.Checked == true && inser_sheet == true)
                            {
                                break;
                            }

                            this.xlSheet = xlBook.GetSheetAt(i);
                            if (xlBook.IsSheetHidden(i))
                            {
                                continue;
                            }
                            inser_sheet = true;

                            int row = 4;
                            for (int j = 4; j <= row + 1000; j++)
                            {
                                string ma_nhanvien = Range("B" + j);
                                string NgayBatDau = Range("M" + j);
                                var NgayBatDauNew = NgayBatDau.Split('/', '.');
                                string NgayKetThuc = Range("N" + j);
                                var NgayKetThucNew = NgayKetThuc.Split('/', '.');
                                if (string.IsNullOrEmpty(NgayBatDau) || string.IsNullOrEmpty(NgayKetThuc) || string.IsNullOrEmpty(ma_nhanvien))
                                {
                                    break;
                                }
                                if (xlSheet.GetRow(j - 1).Hidden == true)
                                {
                                    continue;
                                }

                                //string TuNgay = NgayBatDauNew[2] + "/" + NgayBatDauNew[1].ToString().PadLeft(2,'0') + "/" + NgayBatDauNew[0].ToString().PadLeft(2, '0');
                                string TuNgay = "";
                                if (NgayBatDauNew[0].Length == 4)
                                {
                                    TuNgay = NgayBatDauNew[0] + "/" + NgayBatDauNew[1].PadLeft(2, '0') + "/" + NgayBatDauNew[2].PadLeft(2, '0');
                                }
                                else
                                {
                                    TuNgay = NgayBatDauNew[2] + "/" + NgayBatDauNew[1].PadLeft(2, '0') + "/" + NgayBatDauNew[0].PadLeft(2, '0');
                                }
                                //string DenNgay = NgayKetThucNew[2] + "/" + NgayKetThucNew[1].ToString().PadLeft(2, '0') + "/" + NgayKetThucNew[0].ToString().PadLeft(2, '0'); ;
                                string DenNgay = "";
                                if (NgayKetThucNew[0].Length == 4)
                                {
                                    DenNgay = NgayKetThucNew[0] + "/" + NgayKetThucNew[1].PadLeft(2, '0') + "/" + NgayKetThucNew[2].PadLeft(2, '0');
                                }
                                else
                                {
                                    DenNgay = NgayKetThucNew[2] + "/" + NgayKetThucNew[1].PadLeft(2, '0') + "/" + NgayKetThucNew[0].PadLeft(2, '0');
                                }
                                string MaChamCong = ma_nhanvien.Substring(2, ma_nhanvien.Length - 2);
                                string sql = $"delete DanhSachNuoiConNho where MaChamCong = '{int.Parse(MaChamCong)}' and NgayBatDau = '{TuNgay}' \r\n" +
                                             "Insert into DanhSachNuoiConNho(MaChamCong,NgayBatDau,NgayKetThuc)" +
                                             $" Values({int.Parse(MaChamCong)},'{TuNgay}','{DenNgay}')";
                                SqlCommand sqlCommand = new SqlCommand()
                                {
                                    Transaction = tr,
                                    Connection = cn,
                                    CommandText = sql
                                };
                                sqlCommand.ExecuteNonQuery();
                            }
                            tr.Commit();
                        }
                        RJMessageBox.Show("Thêm thành công");
                    }
                }
            }
            catch (Exception ex)
            {
                tr.Rollback();
                RJMessageBox.Show(ex.Message, "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            LoadData();
        }
    }
}
