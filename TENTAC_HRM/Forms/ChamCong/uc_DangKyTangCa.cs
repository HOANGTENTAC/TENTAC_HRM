using NPOI.HSSF.Util;
using NPOI.SS.UserModel;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Windows.Forms;
using TENTAC_HRM.BusinessLogicLayer.QuanLyNhanVienBLL;
using TENTAC_HRM.Common;
using TENTAC_HRM.Custom;
using TENTAC_HRM.DataTransferObject.QuanLyNhanVienDTO;
using excel = Microsoft.Office.Interop.Excel;
using HorizontalAlignment = NPOI.SS.UserModel.HorizontalAlignment;

namespace TENTAC_HRM.Forms.ChamCong
{
    public partial class uc_DangKyTangCa : UserControl
    {
        private KhuVucDTO _khuVucDTO = new KhuVucDTO();
        private CongTyDTO _congTyDTO = new CongTyDTO();
        private CongTyBLL _congTyBLL = new CongTyBLL();
        private KhuVucBLL _khuVucBLL = new KhuVucBLL();
        private PhongBanBLL _phongBanBLL = new PhongBanBLL();
        private ChucVuBLL _chucVuBLL = new ChucVuBLL();
        private ChucVuDTO _chucVuDTO = new ChucVuDTO();
        private NhanVienBLL _nhanVienBLL = new NhanVienBLL();
        private NhanVienDTO _nhanVienDTO = new NhanVienDTO();
        private PhongBanDTO _phongBanDTO = new PhongBanDTO();

        private string sMaPhongBanTreeView;
        private string sMaCongTyTreeView;
        private string sMaKhuVucTreeView;
        private string _tenNode;
        private string sMaChucVuTreeView;
        public uc_DangKyTangCa()
        {
            InitializeComponent();
            this.Click += (sender, e) =>
            {
                if (!cbo_phongban.Bounds.Contains(PointToClient(Cursor.Position)))
                {
                    cbo_phongban.HideItemsPanel();
                }
            };
        }
        CheckBox headerCheckBox = new CheckBox();
        CheckBox headerCheckBox_DK = new CheckBox();
        private void btn_update_Click(object sender, EventArgs e)
        {
            string sql_ca = "SELECT * FROM [MITACOSQL].[dbo].BangXepCa " +
                $"where Nam = '{dtp_ngaytangca.Value.Year}' and Thang = '{dtp_ngaytangca.Value.Month}'";
            DataTable dt_ca = new DataTable();
            dt_ca = SQLHelper.ExecuteDt(sql_ca);

            string sql_ngaynghi = $"select * from [MITACOSQL].[dbo].NgayNghi where Nam = '{dtp_ngaytangca.Value.Year}' and Thang = '{dtp_ngaytangca.Value.Month}'";
            DataTable dt_lichnghi = SQLHelper.ExecuteDt(sql_ngaynghi);

            string sql_calamviec = "SELECT MaCaLamViec,GioVaoLamViec,GioKetThucLamViec FROM [MITACOSQL].[dbo].[CaLamViecNew]";
            DataTable dt_calamviec = SQLHelper.ExecuteDt(sql_calamviec);

            SqlConnection cn = new SqlConnection(SQLHelper.GetSqlConnection());
            cn.Open();
            SqlTransaction tr = cn.BeginTransaction();
            int count = 0;
            try
            {
                foreach (DataGridViewRow item in DGVNhanVien.Rows)
                {
                    if (Convert.ToBoolean(item.Cells[0].Value) == true)
                    {
                        count++;
                        DateTime giotangca = DateTime.Parse(dtp_ngaytangca.Value.ToString("yyyy/MM/dd") + " 00:00:00");
                        string sql = "";
                        string thoigian_batdau = DateTime.Parse(dtp_giobatdau.Text).ToString("HH:mm:00");
                        string thoigian_ketthuc = DateTime.Parse(dtp_gioketthuc.Text).ToString("HH:mm:00");

                        var ca_dk = dt_ca.Rows.Cast<DataRow>()
                            .Where(x => x["MaChamCong"].ToString() == item.Cells["MaChamCong"].Value.ToString())
                            .Select(x => x["D" + dtp_ngaytangca.Value.Day.ToString()].ToString()).FirstOrDefault();
                        var dt_ngaynghi = dt_lichnghi.Rows.Cast<DataRow>()
                            .Select(x => bool.Parse(x["D" + dtp_ngaytangca.Value.Day].ToString())).FirstOrDefault();

                        var ca = dt_calamviec.Rows.Cast<DataRow>().Where(x => x["MaCaLamViec"].ToString() == (ca_dk == "" ? "HC" : ca_dk)).FirstOrDefault();

                        if (dt_ngaynghi == true)
                        {
                            sql = $"insert into [MITACOSQL].[dbo].DangKyTangCa(MaChamCong,NgayTangCa,GioTangCa,LoaiTangCa,GioBatDau,GioKetThuc,LuyKeThang) " +
                                $"Values('{item.Cells["MaChamCong"].Value}','{dtp_ngaytangca.Text}','{dtp_ngaytangca.Value.ToString("yyyy/MM/dd") + " 00:00:00"}','2','{thoigian_batdau}','{thoigian_ketthuc}',0)";
                        }
                        else
                        {
                            int loaitangca = 1;
                            if (ca[0].ToString() == "CA3" || ca[0].ToString() == "CA2")
                            {
                                giotangca = DateTime.Parse(dtp_ngaytangca.Value.ToString("yyyy/MM/dd") + " " + dtp_giobatdau.Value.ToString("HH:mm:00"));
                                loaitangca = 0;
                            }
                            else if (ca[0].ToString() == "CA1")
                            {
                                giotangca = DateTime.Parse(dtp_ngaytangca.Value.ToString("yyyy/MM/dd") + " " + dtp_gioketthuc.Value.ToString("HH:mm:00"));
                                loaitangca = 1;
                            }
                            else
                            {
                                if (TimeSpan.Parse(thoigian_batdau) < TimeSpan.Parse(DateTime.Parse(ca[1].ToString()).ToString("HH:mm:ss")) &&
                                    TimeSpan.Parse(thoigian_ketthuc) == TimeSpan.Parse(DateTime.Parse(ca[1].ToString()).ToString("HH:mm:ss")))
                                {
                                    giotangca = DateTime.Parse(dtp_ngaytangca.Value.ToString("yyyy/MM/dd") + " " + dtp_giobatdau.Value.ToString("HH:mm:00"));
                                    loaitangca = 0;
                                }
                                else
                                {
                                    giotangca = DateTime.Parse(dtp_ngaytangca.Value.ToString("yyyy/MM/dd") + " " + dtp_gioketthuc.Value.ToString("HH:mm:00"));
                                    loaitangca = 1;
                                }
                            }
                            sql = $"insert into [MITACOSQL].[dbo].DangKyTangCa(MaChamCong,NgayTangCa,GioTangCa,LoaiTangCa,GioBatDau,GioKetThuc,LuyKeThang) " +
                                $"Values('{item.Cells["MaChamCong"].Value}','{dtp_ngaytangca.Text}','{giotangca.ToString("yyyy/MM/dd HH:mm:00")}','{loaitangca}','{thoigian_batdau}','{thoigian_ketthuc}',0)";
                        }

                        SqlCommand sqlCommand = new SqlCommand()
                        {
                            Transaction = tr,
                            Connection = cn,
                            CommandText = sql
                        };
                        sqlCommand.ExecuteNonQuery();
                    }
                }
                tr.Commit();
                cn.Close();
                if (count == 0)
                {
                    RJMessageBox.Show($"Chưa có nhân viên nào được chọn!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
                else
                {
                    btn_search_Click(sender, e);
                    RJMessageBox.Show($"Đã lưu dữ liệu thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (Exception ex)
            {
                tr.Rollback();
                cn.Close();
                RJMessageBox.Show(ex.Message, "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void uc_DangKyTangCa_Load(object sender, EventArgs e)
        {
            LoadTreeView();
            BindGrid();
            BindGrid_DK();
            Load_phongban();
            Load_ngaymoinhat();
        }
        private void Load_ngaymoinhat()
        {
            string sql = $"SELECT MAX(NgayTangCa) as NgayTangCa FROM [MITACOSQL].[dbo].[DangKyTangCa] where YEAR(NgayTangCa) = {DateTime.Parse(dtp_search.Text).Year} and MONTH(NgayTangCa) = {DateTime.Parse(dtp_search.Text).Month}";
            DataTable dt = SQLHelper.ExecuteDt(sql);
            lb_TangCaToiThang.Text = "Đăng ký tăng ca tới ngày : " + dt.Rows[0]["NgayTangCa"].ToString();
        }
        private void Load_phongban()
        {
            string sql = "SELECT [MaPhongBan],[TenPhongBan] FROM [MITACOSQL].[dbo].[PHONGBAN]";
            DataTable dt = new DataTable();
            dt = SQLHelper.ExecuteDt(sql);
            dt.Rows.Add("NV", "Nghỉ việc");
            dt.Rows.Add("TV", "Thời vụ");
            dt = dt.Rows.Cast<DataRow>().OrderBy(x => x.Field<string>("MaPhongBan")).CopyToDataTable();

            cbo_phongban.DisplayMember = "TenPhongBan";
            cbo_phongban.ValueMember = "MaPhongBan";
            cbo_phongban.DataSource = dt;
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

            //Add a CheckBox Column to the DataGridView at the first position.
            DataGridViewCheckBoxColumn checkBoxColumn = new DataGridViewCheckBoxColumn()
            {
                HeaderText = "",
                Width = 30,
                Name = "checkBoxColumn",
                Frozen = true
            };
            DGVNhanVien.Columns.Insert(0, checkBoxColumn);
        }
        private void BindGrid_DK()
        {
            //Find the Location of Header Cell.
            Point headerCellLocation = this.dgv_dangkytangca.GetCellDisplayRectangle(1, -1, true).Location;

            //Place the Header CheckBox in the Location of the Header Cell.
            headerCheckBox_DK.Location = new Point(headerCellLocation.X + 8, headerCellLocation.Y + 2);
            headerCheckBox_DK.BackColor = Color.Transparent;
            headerCheckBox_DK.Size = new Size(18, 18);

            //Assign Click event to the Header CheckBox.
            headerCheckBox_DK.Click += new EventHandler(HeaderCheckBox_DK_Clicked);
            dgv_dangkytangca.Controls.Add(headerCheckBox_DK);
        }
        private void HeaderCheckBox_DK_Clicked(object sender, EventArgs e)
        {
            //Necessary to end the edit mode of the Cell.
            dgv_dangkytangca.EndEdit();

            //Loop and check and uncheck all row CheckBoxes based on Header Cell CheckBox.
            foreach (DataGridViewRow row in dgv_dangkytangca.Rows)
            {
                DataGridViewCheckBoxCell checkBox = (row.Cells["chk_col"] as DataGridViewCheckBoxCell);
                checkBox.Value = headerCheckBox_DK.Checked;
            }
        }
        private void HeaderCheckBox_Clicked(object sender, EventArgs e)
        {
            //Necessary to end the edit mode of the Cell.
            DGVNhanVien.EndEdit();

            //Loop and check and uncheck all row CheckBoxes based on Header Cell CheckBox.
            foreach (DataGridViewRow row in DGVNhanVien.Rows)
            {
                DataGridViewCheckBoxCell checkBox = (row.Cells["checkBoxColumn"] as DataGridViewCheckBoxCell);
                checkBox.Value = headerCheckBox.Checked;
            }
        }
        private void LoadTreeView()
        {
            DataTable dtCongTy = _congTyBLL.showThongTinCongTy(_congTyDTO);
            for (int i = 0; i < dtCongTy.Rows.Count; i++)
            {
                TreeNode treeCongTy = new TreeNode()
                {
                    Text = dtCongTy.Rows[i][1].ToString(),
                    Tag = dtCongTy.Rows[i][0].ToString()
                };
                treeViewSoDoQuanLy.Nodes.Add(treeCongTy);
                _khuVucDTO.MaCongTy = dtCongTy.Rows[i]["MaCongTy"].ToString();
                DataTable dtKhuVuc = _khuVucBLL.GETKHUVUCTREEVIEW(_khuVucDTO);
                for (int j = 0; j < dtKhuVuc.Rows.Count; j++)
                {
                    TreeNode treeKhuVuc = new TreeNode()
                    {
                        Text = dtKhuVuc.Rows[j][2].ToString(),
                        Tag = dtKhuVuc.Rows[j][0].ToString()
                    };
                    treeViewSoDoQuanLy.Nodes[i + 0].Nodes.Add(treeKhuVuc);
                    _phongBanDTO.MaKhuVuc = dtKhuVuc.Rows[j]["MaKhuVuc"].ToString();
                    DataTable dtPhongBan = _phongBanBLL.GETPHONGBANTREEVIEW(_phongBanDTO);

                    for (int z = 0; z < dtPhongBan.Rows.Count; z++)
                    {
                        TreeNode treePhongBan = new TreeNode()
                        {
                            Text = dtPhongBan.Rows[z][3].ToString(),
                            Tag = dtPhongBan.Rows[z][0].ToString()
                        };

                        treeViewSoDoQuanLy.Nodes[i + 0].Nodes[j].Nodes.Add(treePhongBan);
                        _chucVuDTO.MaPhongBan = dtPhongBan.Rows[z]["MaPhongBan"].ToString();
                        DataTable dtChucVu = _chucVuBLL.GETCHUCVUTREEVIEW(_chucVuDTO);
                        for (int v = 0; v < dtChucVu.Rows.Count; v++)
                        {
                            TreeNode treeChucVu = new TreeNode()
                            {
                                Text = dtChucVu.Rows[v][4].ToString(),
                                Tag = dtChucVu.Rows[v][0].ToString()
                            };

                            treeViewSoDoQuanLy.Nodes[i + 0].Nodes[j].Nodes[z].Nodes.Add(treeChucVu);
                            _chucVuDTO.MaChucVu = dtChucVu.Rows[v]["MaChucVu"].ToString();
                        }
                    }
                }
            }
        }

        private void treeViewSoDoQuanLy_AfterSelect(object sender, TreeViewEventArgs e)
        {
            sMaCongTyTreeView = "";
            sMaKhuVucTreeView = "";
            sMaPhongBanTreeView = "";
            sMaChucVuTreeView = "";
            DGVNhanVien.Rows.Clear();
            if (treeViewSoDoQuanLy.SelectedNode.Tag.ToString() == "CT00001")
            {
                sMaCongTyTreeView = "CT00001";
            }
            _tenNode = treeViewSoDoQuanLy.SelectedNode.Text;
            _phongBanDTO.TenPhongBan = _tenNode;
            DataTable dtTreeviewPhongBan = _phongBanBLL.PhongBanGetTreeView(_phongBanDTO);
            for (int iTreeviewPhongBan = 0; iTreeviewPhongBan < dtTreeviewPhongBan.Rows.Count; iTreeviewPhongBan++)
            {
                sMaPhongBanTreeView = dtTreeviewPhongBan.Rows[iTreeviewPhongBan]["MaPhongBan"].ToString();
            }
            _congTyDTO.TenCongTy = _tenNode;
            _khuVucDTO.TenKhuVuc = _tenNode;
            DataTable dtTreeViewKhuVuc = _khuVucBLL.KhuVucgetTreeView(_khuVucDTO);
            for (int iTreeviewKhuVuc = 0; iTreeviewKhuVuc < dtTreeViewKhuVuc.Rows.Count; iTreeviewKhuVuc++)
            {
                sMaKhuVucTreeView = dtTreeViewKhuVuc.Rows[iTreeviewKhuVuc]["MaKhuVuc"].ToString();
            }
            _chucVuDTO.TenChucVu = _tenNode;
            DataTable dtTreeViewChucVu = _chucVuBLL.ChucVugetTreeView(_chucVuDTO);
            for (int iTreeviewChucVu = 0; iTreeviewChucVu < dtTreeViewChucVu.Rows.Count; iTreeviewChucVu++)
            {
                sMaChucVuTreeView = dtTreeViewChucVu.Rows[iTreeviewChucVu]["MaChucVu"].ToString();
            }
            _nhanVienDTO.MaCongTy = sMaCongTyTreeView;
            _nhanVienDTO.MaKhuVuc = sMaKhuVucTreeView;
            _nhanVienDTO.MaPhongBan = sMaPhongBanTreeView;
            _nhanVienDTO.MaChucVu = sMaChucVuTreeView;
            DataTable dtNhanVien = _nhanVienBLL.NhanViengetFromTreeview(_nhanVienDTO);
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

        private void DGVNhanVien_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0 && e.ColumnIndex == 0)
            {
                //Loop to verify whether all row CheckBoxes are checked or not.
                bool isChecked = true;
                foreach (DataGridViewRow row in DGVNhanVien.Rows)
                {
                    if (Convert.ToBoolean(row.Cells["checkBoxColumn"].EditedFormattedValue) == false)
                    {
                        isChecked = false;
                        break;
                    }
                }
                headerCheckBox.Checked = isChecked;
            }
        }

        private void dgv_dangkytangca_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0 && e.ColumnIndex == 0)
            {
                //Loop to verify whether all row CheckBoxes are checked or not.
                bool isChecked = true;
                foreach (DataGridViewRow row in dgv_dangkytangca.Rows)
                {
                    if (Convert.ToBoolean(row.Cells["chk_col"].EditedFormattedValue) == false)
                    {
                        isChecked = false;
                        break;
                    }
                }
                headerCheckBox_DK.Checked = isChecked;
            }
            else
            {
                try
                {
                    if (dgv_dangkytangca.CurrentCell.OwningColumn.Name == "col_update")
                    {
                        frm_SuaGioTangCa frm = new frm_SuaGioTangCa(this)
                        {
                            id_giotangca = dgv_dangkytangca.CurrentRow.Cells["Id"].Value.ToString()
                        };
                        frm.ShowDialog();
                    }
                    else if (dgv_dangkytangca.CurrentCell.OwningColumn.Name == "col_delete")
                    {
                        var mess = RJMessageBox.Show("Bạn có chắc muốn xóa giờ tăng ca ngày không?", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                        if (mess == DialogResult.Yes)
                        {
                            string sql = $"Delete from [MITACOSQL].[dbo].DangKyTangCa Where id = '{dgv_dangkytangca.CurrentRow.Cells["Id"].Value}'";
                            if (SQLHelper.ExecuteSql(sql) == 1)
                            {
                                RJMessageBox.Show("Xóa thành công", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            }
                            btn_search_Click(sender, e);
                        }
                    }
                }
                catch (Exception ex)
                {
                    RJMessageBox.Show(ex.Message, "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void btn_delete_all_Click(object sender, EventArgs e)
        {
            var mess = RJMessageBox.Show("Bạn có chắc muốn xóa giờ tăng ca ngày không?", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (mess == DialogResult.Yes)
            {

                SqlConnection cn = new SqlConnection(SQLHelper.GetSqlConnection());
                cn.Open();
                SqlTransaction tr = cn.BeginTransaction();
                int count = 0;
                foreach (DataGridViewRow item in dgv_dangkytangca.Rows)
                {
                    if (Convert.ToBoolean(item.Cells[0].Value) == true)
                    {
                        count++;
                        string sql = $"Delete from [MITACOSQL].[dbo].DangKyTangCa Where id = '{item.Cells["Id"].Value}'";
                        SqlCommand sqlCommand = new SqlCommand()
                        {
                            Transaction = tr,
                            Connection = cn,
                            CommandText = sql
                        };
                        sqlCommand.ExecuteNonQuery();
                    }
                }
                tr.Commit();
                if (count == 0)
                {
                    RJMessageBox.Show($"Chưa có giờ tăng ca nào được chọn!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
                else
                {
                    btn_search_Click(sender, e);
                    RJMessageBox.Show($"Đã xóa dữ liệu thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
        }

        private void txt_search_TextChanged(object sender, EventArgs e)
        {
            Search_tangca();
        }

        private void dtp_search_ValueChanged(object sender, EventArgs e)
        {
            dtp_tungay.Text = dtp_search.Value.ToString("yyyy/MM/01");
            DateTime dtResult = dtp_search.Value;
            dtResult = dtResult.AddMonths(1);
            dtResult = dtResult.AddDays(-(dtResult.Day));
            dtp_denngay.Text = dtResult.ToString("yyyy/MM/dd");
        }
        private void Search_tangca()
        {
            DGVNhanVien.Rows.Clear();
            _nhanVienDTO.TenNhanVien = txt_search.Text;
            _nhanVienDTO.MaNhanVien = txt_search.Text;
            DataTable dtSearchNhanVien = _nhanVienBLL.NhanVienSearch(_nhanVienDTO);
            for (int iSearchNhanVien = 0; iSearchNhanVien < dtSearchNhanVien.Rows.Count; iSearchNhanVien++)
            {
                int addSearchNhanVien = DGVNhanVien.Rows.Add();
                DGVNhanVien.Rows[addSearchNhanVien].Cells[1].Value = dtSearchNhanVien.Rows[iSearchNhanVien]["MaNhanVien"].ToString();
                DGVNhanVien.Rows[addSearchNhanVien].Cells[2].Value = dtSearchNhanVien.Rows[iSearchNhanVien]["TenNhanVien"].ToString();
                DGVNhanVien.Rows[addSearchNhanVien].Cells[3].Value = dtSearchNhanVien.Rows[iSearchNhanVien]["MaChamCong"].ToString();
                DGVNhanVien.Rows[addSearchNhanVien].Cells[4].Value = dtSearchNhanVien.Rows[iSearchNhanVien]["MaPhongBan"].ToString();
            }
            gbNhanVien.Text = "Nhân viên : " + dtSearchNhanVien.Rows.Count;
        }
        private ISheet xlSheet = null;

        private void btn_import_ex_Click(object sender, EventArgs e)
        {
            DataTable dt_sai = new DataTable();
            dt_sai.Columns.Add("MaChamCong_S");
            dt_sai.Columns.Add("NgayDangKy");
            dt_sai.Columns.Add("GioBatDau");
            dt_sai.Columns.Add("GioKetThuc");
            SqlConnection cn = new SqlConnection(SQLHelper.GetSqlConnection());
            cn.Open();
            SqlTransaction tr = cn.BeginTransaction();
            try
            {
                OpenFileDialog file = new OpenFileDialog()
                {
                    InitialDirectory = @"\\192.168.40.254\ShareAll\scan\1.2 QUAN_LY_TANG_CA"
                };
                //open dialog to choose file
                if (file.ShowDialog() == DialogResult.OK) //if there is a file chosen by the user
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
                            string sql = "select MaCaLamViec,GioVaoLamViec,GioKetThucLamViec from [MITACOSQL].[dbo].CaLamViecNew";
                            DataTable dt = new DataTable();
                            dt = SQLHelper.ExecuteDt(sql);

                            string ngay = Range("D5", "string").TrimEnd();
                            int kytungat = ngay.IndexOf(":");
                            var ngay_new = ngay.Substring(kytungat + 1, ngay.Length - kytungat - 1).Trim().Split('/', '.');

                            string ngay_yc = "";
                            if (ngay_new[0].Length == 4)
                            {
                                ngay_yc = ngay_new[0] + "/" + ngay_new[1].PadLeft(2, '0') + "/" + ngay_new[2].PadLeft(2, '0');
                            }
                            else
                            {
                                ngay_yc = ngay_new[2] + "/" + ngay_new[1].PadLeft(2, '0') + "/" + ngay_new[0].PadLeft(2, '0');
                            }

                            DataTable dt_check = new DataTable();
                            string sql_check = $"Select * from [MITACOSQL].[dbo].BangXepCa where nam = '{DateTime.Parse(ngay_yc).Year}' and thang = '{DateTime.Parse(ngay_yc).Month}'";
                            dt_check = SQLHelper.ExecuteDt(sql_check);

                            DataTable dt_ngaynghi = new DataTable();
                            string sql_ngaynghi = $"select * from [MITACOSQL].[dbo].NgayNghi where Nam = '{DateTime.Parse(ngay_yc).Year}' and thang = '{DateTime.Parse(ngay_yc).Month}'";
                            dt_ngaynghi = SQLHelper.ExecuteDt(sql_ngaynghi);

                            int row = 12;
                            for (int j = 12; j <= row + 1000; j++)
                            {
                                string ma_nhanvien = Range("B" + j, "string");
                                if (string.IsNullOrEmpty(ma_nhanvien))
                                {
                                    break;
                                }
                                if (xlSheet.GetRow(j - 1).Hidden == true)
                                {
                                    continue;
                                }
                                if (Range1("K" + j).ToUpper() == "X")
                                {
                                    string sql_delete = "delete [MITACOSQL].[dbo].DangKyTangCa " +
                                                        $"where MaChamCong = '{int.Parse(ma_nhanvien.Remove(0, 2))}' and " +
                                                        $"NgayTangCa = '{ngay_yc}'";
                                    Execute(tr, cn, sql_delete);
                                    continue;
                                }
                                int loaitangca = 0;
                                string ca = dt_check.Rows.Cast<DataRow>().Where(x => x.Field<int>("MaChamCong") == int.Parse(ma_nhanvien.Remove(0, 2))).Select(y => y.Field<string>("D" + DateTime.Parse(ngay_yc).Day)).FirstOrDefault();
                                bool ngaynghi = dt_ngaynghi.Rows.Cast<DataRow>().Select(y => y.Field<bool>("D" + DateTime.Parse(ngay_yc).Day)).FirstOrDefault();
                                if (ca == null)
                                {
                                    RJMessageBox.Show($"Nhân viên {ma_nhanvien} chưa có trong bảng xếp ca", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                                    continue;
                                }
                                TimeSpan thoigian_batdau_dukien = Range(("D" + j), "time") == "" ? TimeSpan.Parse(DateTime.Parse(Range("F" + j, "time")).ToString("HH:mm")) : TimeSpan.Parse(DateTime.Parse(Range("D" + j, "time")).ToString("HH:mm"));
                                TimeSpan thoigian_ketthuc_dukien = Range(("E" + j), "time") == "" ? TimeSpan.Parse(DateTime.Parse(Range("G" + j, "time")).ToString("HH:mm")) : TimeSpan.Parse(DateTime.Parse(Range("E" + j, "time")).ToString("HH:mm"));

                                TimeSpan thoigian_batdau = thoigian_batdau_dukien;
                                TimeSpan thoigian_ketthuc = thoigian_ketthuc_dukien;

                                bool suagio_hc = false;

                                if (!string.IsNullOrEmpty(Range("F" + j, "time"))
                                    && ca != "HC")
                                {
                                    thoigian_batdau = TimeSpan.Parse(DateTime.Parse(Range("F" + j, "time")).ToString("HH:mm"));
                                    thoigian_ketthuc = TimeSpan.Parse(DateTime.Parse(Range("G" + j, "time")).ToString("HH:mm"));
                                }

                                //if (string.IsNullOrEmpty(ca) && ngaynghi)
                                if (ngaynghi)
                                {
                                    loaitangca = 2;
                                    string sql_delete = "delete [MITACOSQL].[dbo].DangKyTangCa " +
                                                        $"where MaChamCong = '{int.Parse(ma_nhanvien.Remove(0, 2))}' and " +
                                                        $"NgayTangCa = '{ngay_yc}'";
                                    Execute(tr, cn, sql_delete);

                                    string sql_insert = "insert into [MITACOSQL].[dbo].DangKyTangCa(MaChamCong,NgayTangCa,GioTangCa,LoaiTangCa,GioBatDau,GioKetThuc) " +
                                    $"values('{int.Parse(ma_nhanvien.Remove(0, 2))}','{ngay_yc}','{ngay_yc + " 00:00:00"} ',{loaitangca},'{thoigian_batdau}','{thoigian_ketthuc}')";
                                    Execute(tr, cn, sql_insert);
                                    dgv_saigio.DataSource = dt_sai;
                                }
                                else
                                {
                                    var tangca_saugio = dt.Rows.Cast<DataRow>()
                                                        .Where(x => x.Field<string>("MaCaLamViec") == ca)
                                                        .FirstOrDefault();

                                    string giotangca = "";

                                    if (ca == "CA1")
                                    {
                                        giotangca = ngay_yc + " " + thoigian_ketthuc;
                                        loaitangca = 1;
                                    }
                                    else if (ca == "CA2" || ca == "CA3")
                                    {
                                        giotangca = ngay_yc + " " + thoigian_batdau;
                                        loaitangca = 0;
                                    }
                                    else
                                    {
                                        if (thoigian_batdau >= TimeSpan.Parse(DateTime.Parse(tangca_saugio[2].ToString()).ToString("HH:mm:ss")))
                                        {
                                            giotangca = ngay_yc + " " + thoigian_ketthuc;
                                            loaitangca = 1;
                                        }
                                        else if (thoigian_ketthuc <= TimeSpan.Parse(DateTime.Parse(tangca_saugio[1].ToString()).ToString("HH:mm:ss")))
                                        {
                                            giotangca = ngay_yc + " " + thoigian_batdau;
                                            loaitangca = 0;
                                        }

                                        if (Range("F" + j, "time") != "")
                                        {
                                            string giotangca2 = "";
                                            int loaitangca2 = 0;
                                            var thoigian_batdau_thuc = TimeSpan.Parse(DateTime.Parse(Range("F" + j, "time")).ToString("HH:mm"));
                                            var thoigian_ketthuc_thuc = TimeSpan.Parse(DateTime.Parse(Range("G" + j, "time")).ToString("HH:mm"));
                                            if (thoigian_batdau_thuc >= TimeSpan.Parse(DateTime.Parse(tangca_saugio[2].ToString()).ToString("HH:mm:ss")))
                                            {
                                                giotangca2 = ngay_yc + " " + TimeSpan.Parse(DateTime.Parse(Range("G" + j, "time")).ToString("HH:mm"));
                                                loaitangca2 = 1;
                                            }
                                            else if (thoigian_ketthuc_thuc <= TimeSpan.Parse(DateTime.Parse(tangca_saugio[1].ToString()).ToString("HH:mm:ss")))
                                            {
                                                giotangca2 = ngay_yc + " " + TimeSpan.Parse(DateTime.Parse(Range("F" + j, "time")).ToString("HH:mm"));
                                                loaitangca2 = 0;
                                            }

                                            if (loaitangca == loaitangca2)
                                            {
                                                suagio_hc = true;
                                                thoigian_batdau = TimeSpan.Parse(DateTime.Parse(Range("F" + j, "time")).ToString("HH:mm"));
                                                thoigian_ketthuc = TimeSpan.Parse(DateTime.Parse(Range("G" + j, "time")).ToString("HH:mm"));
                                                giotangca = giotangca2;
                                            }
                                        }
                                    }

                                    string sql_delete = "delete [MITACOSQL].[dbo].DangKyTangCa " +
                                                        $"where MaChamCong = '{int.Parse(ma_nhanvien.Remove(0, 2))}' and " +
                                                        $"NgayTangCa = '{ngay_yc}'";
                                    Execute(tr, cn, sql_delete);
                                    if (tangca_saugio[0].ToString() == "HC" && suagio_hc == false)
                                    {
                                        if (Range("F" + j, "time") != "")
                                        {
                                            TimeSpan thoigian_batdau_HC = TimeSpan.Parse(DateTime.Parse(Range("F" + j, "time")).ToString("HH:mm"));
                                            TimeSpan thoigian_ketthuc_HC = TimeSpan.Parse(DateTime.Parse(Range("G" + j, "time")).ToString("HH:mm"));

                                            string sql_insert_HC = "insert into [MITACOSQL].[dbo].DangKyTangCa(MaChamCong,NgayTangCa,GioTangCa,LoaiTangCa,GioBatDau,GioKetThuc) " +
                                            $"values('{int.Parse(ma_nhanvien.Remove(0, 2))}','{ngay_yc}','{ngay_yc + " " + thoigian_ketthuc_HC}',{1},'{thoigian_batdau_HC}','{thoigian_ketthuc_HC}')";
                                            Execute(tr, cn, sql_insert_HC);
                                        }
                                    }

                                    string sql_insert = "insert into [MITACOSQL].[dbo].DangKyTangCa(MaChamCong,NgayTangCa,GioTangCa,LoaiTangCa,GioBatDau,GioKetThuc) " +
                                        $"values('{int.Parse(ma_nhanvien.Remove(0, 2))}','{ngay_yc}','{giotangca}',{loaitangca},'{thoigian_batdau}','{thoigian_ketthuc}')";
                                    Execute(tr, cn, sql_insert);
                                    dgv_saigio.DataSource = dt_sai;
                                }

                            }
                        }
                        tr.Commit();
                        //btn_luyke_Click(sender, e);

                        btn_search_Click(sender, e);
                        RJMessageBox.Show("Thêm thành công", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information); //custom messageBox to show error
                        Cursor.Current = Cursors.Default;
                    }
                    else
                    {
                        RJMessageBox.Show("Chọn file .xls or .xlsx", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning); //custom messageBox to show error
                    }
                }
            }
            catch (Exception ex)
            {
                tr.Rollback();
                RJMessageBox.Show(ex.Message, "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                cn.Close();
            }
            Load_ngaymoinhat();
        }
        private string Range(string zahyo, string type)
        {
            return XlsCommon.GetCellValue(zahyo, xlSheet, type);
        }
        private string Range1(string zahyo)
        {
            return XlsCommon.GetCellValue(zahyo, xlSheet);
        }
        public void Execute(SqlTransaction tr, SqlConnection cn, string sql)
        {
            SqlCommand sqlCommand = new SqlCommand()
            {
                Transaction = tr,
                Connection = cn,
                CommandText = sql
            };
            sqlCommand.ExecuteNonQuery();
        }
        DataTable dt_nhanvien_check_merge;

        public void btn_search_Click(object sender, EventArgs e)
        {
            dt_nhanvien_check_merge = new DataTable();
            DataTable dt_nhanvien_check = new DataTable();
            List<string> list = new List<string>();
            foreach (DataGridViewRow row in DGVNhanVien.Rows)
            {
                DataGridViewCheckBoxCell chk = row.Cells[0] as DataGridViewCheckBoxCell;
                if (Convert.ToBoolean(chk.Value) == true)
                    if (row.Cells.Count >= 2 && row.Cells["MaChamCong"].Value != null)
                    {
                        list.Add(row.Cells["MaChamCong"].Value.ToString());
                    }
            }

            foreach (var _MCC in list)
            {
                dt_nhanvien_check = Get_nhanvien_by_check(_MCC);
                dt_nhanvien_check_merge.Merge(dt_nhanvien_check);
            }
            string sql_bangxepca = $"select * from [MITACOSQL].[dbo].BangXepCa where Nam = '{dtp_search.Value.Year}' and Thang = '{dtp_search.Value.Month}'";
            DataTable dt_bangxepca = SQLHelper.ExecuteDt(sql_bangxepca);
            var list_new = (from a in dt_nhanvien_check_merge.Rows.Cast<DataRow>()
                            select new
                            {
                                Id = a["Id"],
                                Ca = dt_bangxepca.Rows.Cast<DataRow>().Where(x => x["MaChamCong"].ToString() == a["MaChamCong"].ToString()).Select(x => x["D" + DateTime.Parse(a["NgayTangCa"].ToString()).Day].ToString()).FirstOrDefault(),
                                NgayTangCa = a["NgayTangCa"],
                                GioTangCa = a["GioTangCa"],
                                LoaiTangCa = a["LoaiTangCa"],
                                MaChamCong = a["MaChamCong"],
                                GioBatDau = a["GioBatDau"],
                                GioKetThuc = a["GioKetThuc"],
                                LoaiTangCa_M = a["LoaiTangCa_M"],
                                LuyKeTHang = a["LuyKeTHang"]
                            }).ToList();
            dgv_dangkytangca.DataSource = list_new;
            Load_saigio();
            GetNgaySaiGio();
        }
        private void Load_saigio()
        {
            string sql = $"Select * From [MITACOSQL].[dbo].BangXepCa " +
                            $"Where Thang = {DateTime.Parse(dtp_search.Text).Month} and " +
                            $"Nam = {DateTime.Parse(dtp_search.Text).Year}";
            DataTable dt = new DataTable();
            dt = SQLHelper.ExecuteDt(sql);

            string sql_calamviec = "Select MaCaLamViec,CONVERT(VARCHAR, GioVaoLamViec, 21) as GioVaoLamViec,CONVERT(VARCHAR, GioKetThucLamViec, 21) GioKetThucLamViec From [MITACOSQL].[dbo].CaLamViecNew";
            DataTable dt_calamviec = new DataTable();
            dt_calamviec = SQLHelper.ExecuteDt(sql_calamviec);

            DataTable dt_g = new DataTable();
            dt_g.Columns.Add("MaChamCong");
            dt_g.Columns.Add("NgayDangKy");
            dt_g.Columns.Add("GioBatDau");
            dt_g.Columns.Add("GioKetThuc");
            dt_g.Columns.Add("CaDangKy");
            foreach (DataGridViewRow item in dgv_dangkytangca.Rows)
            {
                string ca = dt.Rows.Cast<DataRow>()
                    .Where(x => x.Field<int>("MaChamCong") == int.Parse(item.Cells["MaChamCong_TC"].Value.ToString()))
                    .Select(x => x.Field<string>("D" + DateTime.Parse(item.Cells["NgayTangCa"].Value.ToString()).Day)).FirstOrDefault();
                DataRow fd = dt_calamviec.Rows.Cast<DataRow>().Where(x => x.Field<string>("MaCaLamViec") == (ca == "" ? "HC" : ca)).FirstOrDefault();
                if (item.Cells["LoaiTangCa_M"].Value.ToString() != "2")
                {
                    if (item.Cells["GioBatDau_DK"].Value.ToString() != "")
                    {
                        if ((item.Cells["GioBatDau_DK"].Value.ToString() != DateTime.Parse(fd[1].ToString()).ToString("HH:mm:00") &&
                            item.Cells["GioBatDau_DK"].Value.ToString() != DateTime.Parse(fd[2].ToString()).ToString("HH:mm:00")) &&
                            (item.Cells["GioKetThuc_DK"].Value.ToString() != DateTime.Parse(fd[1].ToString()).ToString("HH:mm:00") &&
                            item.Cells["GioKetThuc_DK"].Value.ToString() != DateTime.Parse(fd[2].ToString()).ToString("HH:mm:00")))
                        {
                            dt_g.Rows.Add(item.Cells["MaChamCong_TC"].Value, item.Cells["NgayTangCa"].Value.ToString(), item.Cells["GioBatDau_DK"].Value, item.Cells["GioKetThuc_DK"].Value, (ca == "" ? "HC" : ca));
                        }
                    }
                }
                else
                {
                    if (ca == "HC" || ca == "")
                    {
                        if (TimeSpan.Parse(item.Cells["GioBatDau_DK"].Value.ToString()) > TimeSpan.Parse("14:00:00"))
                        {
                            dt_g.Rows.Add(item.Cells["MaChamCong_TC"].Value, item.Cells["NgayTangCa"].Value.ToString(), item.Cells["GioBatDau_DK"].Value, item.Cells["GioKetThuc_DK"].Value, (ca == "" ? "HC" : ca));
                        }
                    }
                }
            }
            dgv_saigio.DataSource = dt_g;
        }
        private DataTable Get_nhanvien_by_check(string _MCC)
        {
            string sql = $"select Id,NgayTangCa,convert(time,GioTangCa) GioTangCa," +
                        $"case when LoaiTangCa = 0 then N'Tăng ca trước giờ' else case when LoaiTangCa = 1 then N'Tăng ca sau giờ' else N'Tăng ca ngày nghỉ' end end LoaiTangCa,MaChamCong,GioBatDau,GioKetThuc,LoaiTangCa LoaiTangCa_M,LuyKeTHang " +
                        $"from [MITACOSQL].[dbo].DangKyTangCa where MaChamCong = '{_MCC}'";
            if (chk_month.Checked == false)
            {
                sql += $" and NgayTangCa = '{DateTime.Parse(dtp_search.Text).ToString("yyyy/MM/dd")}'";
            }
            else
            {
                sql += $" and Month(NgayTangCa) = '{DateTime.Parse(dtp_search.Text).ToString("MM")}' and Year(NgayTangCa) = '{DateTime.Parse(dtp_search.Text).ToString("yyyy")}' ";
            }
            DataTable dt = SQLHelper.ExecuteDt(sql);
            return dt;
        }

        private void btn_export_excel_Click(object sender, EventArgs e)
        {
            Cursor.Current = Cursors.WaitCursor;
            exportExcelTong();
            Cursor.Current = Cursors.Default;
        }
        private void exportExcelTong()
        {
            try
            {
                var chk_thoivu = cbo_phongban.SelectIds.ToString().Split(',').ToList();
                string sql_danhsachca = $"select * from [MITACOSQL].[dbo].BangXepCa where Nam = '{dtp_tungay.Value.Year}' and Thang = '{dtp_tungay.Value.Month}'";
                DataTable dt_danhsachca = new DataTable();
                dt_danhsachca = SQLHelper.ExecuteDt(sql_danhsachca);

                string sql = "select nv.MaNhanVien,nv.TenNhanVien,nv.MaChamCong," +
                    "case when nv.MaKhuVuc = 'KV00003' then 'TS' else case when nv.MaKhuVuc is null then 'NV' else nv.MaPhongBan end end as MaPhongBan," +
                    "case when nv.MaKhuVuc = 'KV00003' then N'Thai Sản' else case when nv.MaKhuVuc is null then N'Nghỉ việc' else pb.TenPhongBan end end as TenPhongBan," +
                    "nv.MaChamCong " +
                    "from [MITACOSQL].[dbo].NhanVien nv " +
                    "left join [MITACOSQL].[dbo].PHONGBAN pb on pb.MaPhongBan = nv.MaPhongBan ";

                DataTable dt_nhanvien = new DataTable();
                dt_nhanvien = SQLHelper.ExecuteDt(sql);

                string sql_quagio = $"select * " +
                    $"from [MITACOSQL].[dbo].QuaGioTangCa where Nam = {DateTime.Parse(dtp_tungay.Text).Year} and Thang = {DateTime.Parse(dtp_tungay.Text).Month}";
                DataTable dt_quagio = new DataTable();
                dt_quagio = SQLHelper.ExecuteDt(sql_quagio);
                var dt_tungay = new DataTable();
                string sql_giotangca = "select Id,NgayTangCa,convert(time,GioTangCa) GioTangCa," +
                    "case when LoaiTangCa = 0 then N'Tăng ca trước giờ' else case when LoaiTangCa = 1 then N'Tăng ca sau giờ' else N'Tăng ca ngày nghỉ' end end LoaiTangCa,tc.MaChamCong,GioBatDau,GioKetThuc,LoaiTangCa LoaiTangCa_M, LuyKeThang " +
                    $"from [MITACOSQL].[dbo].DangKyTangCa tc " +
                    "join (select MaChamCong,MaNhanVien,TenNhanVien,case when MaKhuVuc is null then 'NV' else MaPhongBan end as MaPhongBan from [MITACOSQL].[dbo].NHANVIEN) nv on nv.MaChamCong = tc.MaChamCong " +
                    "left join [MITACOSQL].[dbo].PHONGBAN pb on nv.MaPhongBan = pb.MaPhongBan " +
                    $"where Month(NgayTangCa) = '{dtp_tungay.Value.Month}' and Year(NgayTangCa) = '{dtp_tungay.Value.Year}'";

                if (cbo_phongban.SelectIds.ToString() != "")
                {
                    if (chk_thoivu[0] != "TV")
                        sql_giotangca += $" and nv.MaPhongBan in ('{string.Join("','", cbo_phongban.SelectIds.Split(',').ToList())}')";
                }
                if (!string.IsNullOrEmpty(txt_search.Text))
                {
                    sql_giotangca += $" and (nv.MaNhanVien like '%{txt_search.Text}%' or nv.TenNhanVien like '%{txt_search.Text}%')";
                }
                DataTable dt1 = SQLHelper.ExecuteDt(sql_giotangca);
                dt_tungay = dt1;

                string sql_chamcong = $"select distinct MaChamCong,NgayCham from [MITACOSQL].[dbo].CheckInOut where NgayCham >= '{dtp_tungay.Value.ToString("yyyy/MM/01 00:00:00")}' and NgayCham <= '{dtp_denngay.Value.ToString("yyyy/MM/dd 00:00:00")}'";
                DataTable dt_chamcong = SQLHelper.ExecuteDt(sql_chamcong);
                string sql_chamcong_check = $"select MaChamCong,NgayCham,GioCham from [MITACOSQL].[dbo].CheckInOut where NgayCham >= '{dtp_tungay.Value.ToString("yyyy/MM/01 00:00:00")}' and NgayCham <= '{dtp_denngay.Value.AddDays(1).ToString("yyyy/MM/dd 00:00:00")}'";
                DataTable dt_chamcong_check = SQLHelper.ExecuteDt(sql_chamcong_check);
                var dt = (from nv in dt_nhanvien.AsEnumerable()
                          join tc in dt_tungay.AsEnumerable() on nv["MaChamCong"].ToString() equals tc["MaChamCong"].ToString()
                          select new DK_tangca
                          {
                              MaChamCong = nv["MaChamCong"].ToString(),
                              MaNhanVien = nv["MaNhanVien"].ToString(),
                              TenNhanVien = nv["TenNhanVien"].ToString(),
                              MaPhongBan = nv["MaPhongBan"].ToString(),
                              TenPhongBan = nv["TenPhongBan"].ToString(),
                              LoaiTangCa = tc["LoaiTangCa_M"].ToString(),
                              NgayTangCa = tc["NgayTangCa"].ToString(),
                              GioBatDau = tc["GioBatDau"].ToString(),
                              GioKetThuc = tc["GioKetThuc"].ToString(),
                              TongThoiGianTangCa = TimeSpan.Parse(tc["GioKetThuc"].ToString()) - TimeSpan.Parse(tc["GioBatDau"].ToString()),
                              Ca = dt_danhsachca.Rows.Cast<DataRow>()
                            .Where(x => x.Field<int>("MaChamCong").ToString() == nv["MaChamCong"].ToString())
                            .Select(x => x.Field<string>("D" + DateTime.Parse(tc["NgayTangCa"].ToString().ToString()).Day.ToString())).FirstOrDefault(),
                              LuyKeThang = decimal.Parse(tc["LuyKeTHang"].ToString()),
                              GioVao = "",
                              GioRa = "",
                              TangCa = true
                          }).ToList();

                bool thoivu = true;
                if (chk_thoivu.Count == 1 && chk_thoivu.Contains("TV") && cbo_phongban.SelectIds.ToString() != "")
                {
                    dt = dt.Where(x => x.MaNhanVien.Contains("KC")).ToList();
                }
                else if (!chk_thoivu.Contains("TV") && cbo_phongban.SelectIds.ToString() != "")
                {
                    thoivu = false;
                    dt = dt.Where(x => !x.MaNhanVien.Contains("KC")).ToList();
                }

                foreach (var item in dt)
                {
                    if (item.Ca != "CA3")
                    {
                        var thoigianchamcong = dt_chamcong_check.Rows.Cast<DataRow>()
                                        .Where(x => x["MaChamCong"].ToString() == item.MaChamCong.ToString() && x["NgayCham"].ToString() == item.NgayTangCa).ToList();
                        if (thoigianchamcong.Count > 0)
                        {
                            item.GioVao = thoigianchamcong.Min(x => DateTime.Parse(x["GioCham"].ToString()).ToString("yyyy/MM/dd HH:mm:ss"));
                            item.GioRa = thoigianchamcong.Max(x => DateTime.Parse(x["GioCham"].ToString()).ToString("yyyy/MM/dd HH:mm:ss"));
                            if (item.Ca == "CA1")
                            {

                                if ((TimeSpan.Parse(DateTime.Parse(item.GioRa.ToString()).ToString("HH:mm:ss")) > TimeSpan.Parse("14:00:00")
                                    && TimeSpan.Parse(DateTime.Parse(item.GioRa.ToString()).ToString("HH:mm:00")) < TimeSpan.Parse("14:30:00"))
                                    && item.LoaiTangCa != "2"
                                    && TimeSpan.Parse(DateTime.Parse(item.GioRa.ToString()).ToString("HH:mm:00")) - TimeSpan.Parse(DateTime.Parse(item.GioBatDau.ToString()).ToString("HH:mm:00")) < TimeSpan.Parse("00:20:00"))
                                {
                                    item.TangCa = false;
                                }
                                if (TimeSpan.Parse(DateTime.Parse(item.GioRa.ToString()).ToString("HH:mm:ss")) > TimeSpan.Parse("14:00:00")
                                    && TimeSpan.Parse(item.GioKetThuc) > TimeSpan.Parse(DateTime.Parse(item.GioRa.ToString()).ToString("HH:mm:00")))
                                {
                                    item.GioKetThuc = DateTime.Parse(item.GioRa.ToString()).ToString("HH:mm:ss");
                                }
                            }
                            else if (item.Ca == "CA2")
                            {
                                if ((TimeSpan.Parse(DateTime.Parse(item.GioVao.ToString()).ToString("HH:mm:00")) > TimeSpan.Parse("13:35:00")
                                    && TimeSpan.Parse(DateTime.Parse(item.GioVao.ToString()).ToString("HH:mm:00")) < TimeSpan.Parse("14:00:00"))
                                    && item.LoaiTangCa != "2"
                                    && TimeSpan.Parse(DateTime.Parse(item.GioKetThuc.ToString()).ToString("HH:mm:00")) - TimeSpan.Parse(DateTime.Parse(item.GioVao.ToString()).ToString("HH:mm:ss")) < TimeSpan.Parse("00:20:00"))
                                {
                                    item.TangCa = false;
                                }
                                if (TimeSpan.Parse(DateTime.Parse(item.GioVao.ToString()).ToString("HH:mm:00")) < TimeSpan.Parse("14:00:00")
                                    && TimeSpan.Parse(item.GioBatDau).Add(TimeSpan.Parse("00:01:59")) < TimeSpan.Parse(DateTime.Parse(item.GioVao.ToString()).ToString("HH:mm:00")))
                                {
                                    item.GioBatDau = DateTime.Parse(item.GioVao.ToString()).ToString("HH:mm:ss");
                                }
                            }
                            else
                            {
                                if (item.LoaiTangCa == "0")
                                {
                                    if ((TimeSpan.Parse(DateTime.Parse(item.GioVao.ToString()).ToString("HH:mm:00")) > TimeSpan.Parse("07:25:00")
                                        && TimeSpan.Parse(DateTime.Parse(item.GioVao.ToString()).ToString("HH:mm:00")) < TimeSpan.Parse("07:50:00"))
                                        && TimeSpan.Parse(DateTime.Parse(item.GioKetThuc.ToString()).ToString("HH:mm:00")) - TimeSpan.Parse(DateTime.Parse(item.GioVao.ToString()).ToString("HH:mm:00")) < TimeSpan.Parse("00:20:00"))
                                    {
                                        item.TangCa = false;
                                    }
                                    if (TimeSpan.Parse(DateTime.Parse(item.GioVao.ToString()).ToString("HH:mm:ss")) < TimeSpan.Parse("07:50:00")
                                        && TimeSpan.Parse(item.GioBatDau).Add(TimeSpan.Parse("00:01:59")) < TimeSpan.Parse(DateTime.Parse(item.GioVao.ToString()).ToString("HH:mm:ss")))
                                    {
                                        item.GioBatDau = DateTime.Parse(item.GioVao.ToString()).ToString("HH:mm:ss");
                                    }
                                }
                                else if (item.LoaiTangCa == "1")
                                {
                                    if ((TimeSpan.Parse(DateTime.Parse(item.GioRa.ToString()).ToString("HH:mm:ss")) > TimeSpan.Parse("16:30:00")
                                        && TimeSpan.Parse(DateTime.Parse(item.GioRa.ToString()).ToString("HH:mm:00")) < TimeSpan.Parse("17:00:00"))
                                        && TimeSpan.Parse(DateTime.Parse(item.GioRa.ToString()).ToString("HH:mm:00")) - TimeSpan.Parse(DateTime.Parse(item.GioBatDau.ToString()).ToString("HH:mm:ss")) < TimeSpan.Parse("00:20:00"))
                                    {
                                        item.TangCa = false;
                                    }
                                    if (TimeSpan.Parse(DateTime.Parse(item.GioRa.ToString()).ToString("HH:mm:00")) > TimeSpan.Parse("16:30:00")
                                        && TimeSpan.Parse(item.GioKetThuc) > TimeSpan.Parse(DateTime.Parse(item.GioRa.ToString()).ToString("HH:mm:00")))
                                    {
                                        item.GioKetThuc = DateTime.Parse(item.GioRa.ToString()).ToString("HH:mm:ss");
                                    }
                                }
                            }
                        }
                    }
                    else
                    {
                        var ngaytangca = DateTime.Parse(item.NgayTangCa).ToString("yyyy/MM/dd");
                        var thoigianchamcong = dt_chamcong_check.Rows.Cast<DataRow>()
                                        .Where(x => x["MaChamCong"].ToString() == item.MaChamCong.ToString()
                                        && (DateTime.Parse(x["GioCham"].ToString()) >= DateTime.Parse(ngaytangca + " 17:00:00")
                                        && (DateTime.Parse(x["GioCham"].ToString()) <= DateTime.Parse(ngaytangca + " 08:00:00").AddDays(1)))).ToList();

                        if (thoigianchamcong.Count > 0)
                        {
                            item.GioVao = thoigianchamcong.Min(x => DateTime.Parse(x["GioCham"].ToString())).ToString("yyyy/MM/dd HH:mm:ss");
                            item.GioRa = thoigianchamcong.Max(x => DateTime.Parse(x["GioCham"].ToString())).ToString("yyyy/MM/dd HH:mm:ss");

                            if ((TimeSpan.Parse(DateTime.Parse(item.GioVao.ToString()).ToString("HH:mm:00")) > TimeSpan.Parse("21:35:00")
                                && TimeSpan.Parse(DateTime.Parse(item.GioVao.ToString()).ToString("HH:mm:00")) < TimeSpan.Parse("22:00:00"))
                                && item.LoaiTangCa != "2"
                                && TimeSpan.Parse(DateTime.Parse(item.GioKetThuc.ToString()).ToString("HH:mm:00")) - TimeSpan.Parse(DateTime.Parse(item.GioVao.ToString()).ToString("HH:mm:00")) < TimeSpan.Parse("00:20:00"))
                            {
                                item.TangCa = false;
                            }
                            if (TimeSpan.Parse(DateTime.Parse(item.GioVao.ToString()).ToString("HH:mm:00")) < TimeSpan.Parse("22:00:00")
                                && TimeSpan.Parse(item.GioBatDau).Add(TimeSpan.Parse("00:01:59")) < TimeSpan.Parse(DateTime.Parse(item.GioVao.ToString()).ToString("HH:mm:00")))
                            {
                                item.GioBatDau = DateTime.Parse(item.GioVao.ToString()).ToString("HH:mm:ss");
                            }
                        }

                    }
                }

                DataTable dt_cattangca = new DataTable();
                DataTable dt_dachinh = new DataTable();
                DataTable dt_dachinh_quagio = new DataTable();
                DataTable dt_thoivu = new DataTable();

                dt_cattangca.Columns.Add("MaChamCong");
                dt_cattangca.Columns.Add("MaNhanVien");
                dt_cattangca.Columns.Add("TenNhanVien");
                dt_cattangca.Columns.Add("MaPhongBan");
                dt_cattangca.Columns.Add("TenPhongBan");
                dt_cattangca.Columns.Add("LoaiTangCa");
                dt_cattangca.Columns.Add("NgayTangCa");
                dt_cattangca.Columns.Add("GioBatDau");
                dt_cattangca.Columns.Add("GioKetThuc");
                dt_cattangca.Columns.Add("TongThoiGianTangCa");
                dt_cattangca.Columns.Add("Ca");
                dt_cattangca.Columns.Add("LuyKeThang");
                var dt_copy = dt.Where(x => x.TangCa == true).ToList();
                dt_dachinh = dt_cattangca.Copy();
                dt_dachinh_quagio = dt_cattangca.Copy();
                dt_thoivu = dt_cattangca.Copy();
                if (dt_quagio.Rows.Count > 0)
                {
                    foreach (var item in dt.Where(x => x.TangCa == true).ToList())
                    {
                        for (int j = 0; j < dt_quagio.Rows.Count; j++)
                        {
                            if (item.MaNhanVien.ToString() == dt_quagio.Rows[j]["MaNhanVien"].ToString())
                            {
                                int co = 0;
                                for (int i = 3; i < dt_quagio.Columns.Count; i++)
                                {
                                    co++;
                                    if (int.Parse(DateTime.Parse(item.NgayTangCa).ToString("dd")) == (co) && decimal.Parse(dt_quagio.Rows[j][i].ToString()) > 0)
                                    {
                                        dt_copy.Remove(item);
                                        dt_cattangca.Rows.Add(item.MaChamCong, item.MaNhanVien, item.TenNhanVien, item.MaPhongBan, item.TenPhongBan, item.LoaiTangCa, item.NgayTangCa, item.GioBatDau, item.GioKetThuc, item.TongThoiGianTangCa, item.Ca);
                                    }
                                }
                            }
                        }
                    }
                }
                if (dt.Where(x => x.TangCa == true).ToList().Count == 0)
                {
                    RJMessageBox.Show("Không có dữ liệu tăng ca");
                    return;
                }
                bool file_quagio = false;
                bool file_hoanchinh = false;
                bool file_thoivu = false;
                // tính lũy kế tháng qua gio
                if (dt_cattangca.Rows.Count > 0)
                {
                    double luyke = 0;
                    string manhanvien = "";
                    foreach (var item in dt_cattangca.Rows.Cast<DataRow>().OrderBy(x => x["MaNhanVien"]).ThenBy(x => x["NgayTangCa"]).ToList())
                    {
                        TimeSpan thoigiantangca = new TimeSpan();
                        var ngaytangca = DateTime.Parse(item["NgayTangCa"].ToString()).ToString("yyyy/MM/dd");
                        var Gioketthuc = DateTime.Parse(ngaytangca + " " + item["GioKetThuc"].ToString()).ToString("yyyy/MM/dd HH:mm:00");
                        var Giobatdau = DateTime.Parse(ngaytangca + " " + item["GioBatDau"].ToString()).ToString("yyyy/MM/dd HH:mm:00");

                        if (TimeSpan.Parse(DateTime.Parse(Gioketthuc).ToString("HH:mm:00")) < TimeSpan.Parse(DateTime.Parse(Giobatdau).ToString("HH:mm:00")))
                        {
                            Gioketthuc = DateTime.Parse(Gioketthuc.ToString()).AddDays(1).ToString("yyyy/MM/dd HH:mm:00");
                        }
                        if ((item["Ca"].ToString() == "" || item["Ca"].ToString() == "HC") && item["LoaiTangCa"].ToString() == "2")
                        {
                            if (TimeSpan.Parse(DateTime.Parse(Giobatdau).ToString("HH:mm:00")) <= TimeSpan.Parse("11:50:00") && TimeSpan.Parse(DateTime.Parse(Gioketthuc).ToString("HH:mm:00")) >= TimeSpan.Parse("12:40:00"))
                            {
                                thoigiantangca = DateTime.Parse(Gioketthuc.ToString()).Subtract(DateTime.Parse(Giobatdau.ToString())) - TimeSpan.Parse("00:40:00");
                            }
                            else
                            {
                                thoigiantangca = DateTime.Parse(Gioketthuc.ToString()).Subtract(DateTime.Parse(Giobatdau.ToString()));
                            }
                        }
                        else if (item["Ca"].ToString() == "CA3" && item["LoaiTangCa"].ToString() == "2")
                        {
                            thoigiantangca = DateTime.Parse(Gioketthuc.ToString()).Subtract(DateTime.Parse(Giobatdau.ToString()));
                        }
                        else
                        {
                            thoigiantangca = TimeSpan.Parse(item["GioKetThuc"].ToString()) - TimeSpan.Parse(item["GioBatDau"].ToString());
                        }
                        decimal fsdf = (decimal.Parse(thoigiantangca.TotalHours.ToString()) - (int)thoigiantangca.TotalHours) * 60;
                        double ds = 0;
                        // 15
                        if (fsdf >= 15 && fsdf < 30)
                        {
                            ds = (0.25);
                        }
                        // 30
                        else if (fsdf >= 30 && fsdf < 45)
                        {
                            ds = 0.5;
                        }
                        // 45
                        else if (fsdf >= 45 && fsdf < 60)
                        {
                            ds = 0.75;
                        }
                        double tonggio_le = (int)thoigiantangca.TotalHours + (double)ds;

                        if (manhanvien != item["MaNhanVien"].ToString())
                        {
                            manhanvien = item["MaNhanVien"].ToString();
                            luyke = tonggio_le;
                        }
                        else
                        {
                            luyke += tonggio_le;
                        }

                        dt_dachinh_quagio.Rows.Add(item["MaChamCong"], item["MaNhanVien"].ToString(), item["TenNhanVien"], item["MaPhongBan"], item["TenPhongBan"], item["LoaiTangCa"].ToString(), item["NgayTangCa"], item["GioBatDau"].ToString(), item["GioKetThuc"].ToString(), tonggio_le, item["Ca"].ToString(), luyke);
                    }
                }
                if (dt_dachinh_quagio.Rows.Count > 0)
                {
                    lbl_progress.Text = "1/3";
                    progressBar1.Value = 0;
                    var dt_ = dt_dachinh_quagio.Rows.Cast<DataRow>().Where(x => DateTime.Parse(x["NgayTangCa"].ToString()) >= DateTime.Parse(dtp_tungay.Value.ToString("yyyy/MM/dd 00:00:00")) && DateTime.Parse(x["NgayTangCa"].ToString()) <= DateTime.Parse(dtp_denngay.Value.ToString("yyyy/MM/dd 00:00:00")));
                    var dt_new = dt_.Count() > 0 ? dt_.CopyToDataTable() : null;
                    if (dt_new != null && dt_new.Rows.Count > 0)
                    {
                        if (cbo_phongban.SelectIds.ToString() != "")
                        {
                            if (chk_thoivu[0] != "TV")
                            {
                                dt_new = dt_new.Rows.Cast<DataRow>().Where(x => chk_thoivu.Where(z => z != "TV").Contains(x["MaPhongBan"].ToString())).CopyToDataTable();
                            }
                        }
                        var phongban = dt_new.Rows.Cast<DataRow>().Select(x => new { MaPhongBan = x["MaPhongBan"], TenPhongBan = x["TenPhongBan"] }).Distinct().ToList();

                        var sql_lydotangca = "select * from [MITACOSQL].[dbo].LyDoOT";
                        DataTable data_lydotangca = SQLHelper.ExecuteDt(sql_lydotangca);
                        excel.Application xlApp = new excel.Application();
                        string targetPath = $@"{Environment.GetFolderPath(Environment.SpecialFolder.Desktop)}";
                        string destFile = System.IO.Path.Combine(targetPath, $"TangCaThang_" + dtp_tungay.Value.Month + "_QuaGio.xlsx");
                        if (File.Exists(destFile))
                        {
                            File.Delete(destFile);
                        }
                        var asm = Assembly.GetEntryAssembly();
                        var templatePath = $@"{Path.GetDirectoryName(asm.Location)}\Resources\TangCa_QuaGio_template.xlsx";
                        File.Copy(templatePath, destFile, true);
                        object misValue = System.Reflection.Missing.Value;
                        excel.Workbook xlWorkBook = xlApp.Workbooks.Open(destFile, 0, false, 5, "", "", true, excel.XlPlatform.xlWindows, "\t", false, false, 0, true, 1, 0);
                        try
                        {
                            excel.Worksheet xlWorkSheet = (excel.Worksheet)xlWorkBook.Sheets[1];
                            xlWorkSheet.Name = phongban[0].TenPhongBan.ToString().Replace("/", ".");
                            excel.Range xlRange = xlWorkSheet.UsedRange;
                            for (int i = 1; i < phongban.Count(); i++)
                            {
                                xlWorkSheet.Copy(Type.Missing, xlWorkBook.Sheets[xlWorkBook.Sheets.Count]);
                                xlWorkBook.Sheets[xlWorkBook.Sheets.Count].Name = phongban[i].TenPhongBan.ToString().Replace("/", ".");
                            }
                            int count_progress = 0;
                            for (int i = 0; i < phongban.Count(); i++)
                            {
                                xlWorkSheet = (excel.Worksheet)xlWorkBook.Sheets[i + 1];
                                xlWorkSheet.Activate();
                                string lydo = data_lydotangca.Rows.Cast<DataRow>().Where(x => x.Field<string>("PhongBan") == phongban[i].MaPhongBan.ToString()).Select(y => y.Field<string>("LyDoOT")).FirstOrDefault();
                                var dulieutheongay = dt_new.Rows.Cast<DataRow>().Where(x => x["MaPhongBan"].ToString() == phongban[i].MaPhongBan.ToString()).OrderBy(x => x["MaNhanVien"]).ThenBy(x => x["NgayTangCa"]).ThenBy(x => x.Field<string>("GioBatDau")).ToList().ToList();
                                xlWorkSheet.Range["A5"].Value = "Ngày viết đơn: " + DateTime.Parse(dtp_denngay.Text.ToString()).ToString("yyyy/MM/dd");
                                xlWorkSheet.Range["D5"].Value = "Ngày y/c làm thêm: ";
                                xlWorkSheet.Range["H5"].Value = "Bộ phận: " + phongban[i].TenPhongBan;
                                xlWorkSheet.Range["A8"].Value = "Lý do tăng ca/\r\n残業理由： " + lydo;
                                int row = 12;
                                int index = 1;
                                //string manhanvien = "";
                                //double luyke = 0;
                                string ngay = "";
                                double tonggio = 0;
                                string manhanvien_check = "";

                                foreach (var item in dulieutheongay)
                                {
                                    count_progress++;
                                    progressBar1.Value = (int)(((float)count_progress / (float)dt_new.Rows.Count) * (float)100);
                                    if (manhanvien_check == item.Field<string>("MaNhanVien").ToString() && ngay == DateTime.Parse(item.Field<string>("NgayTangCa").ToString()).ToString("yyyy/MM/dd"))
                                    {
                                        xlWorkSheet.Range["F" + (row - 1)].Value = item.Field<string>("GioBatDau").ToString().ToString();
                                        xlWorkSheet.Range["F" + (row - 1)].NumberFormat = "HH:mm";
                                        xlWorkSheet.Range["G" + (row - 1)].Value = item.Field<string>("GioKetThuc").ToString().ToString();
                                        xlWorkSheet.Range["G" + (row - 1)].NumberFormat = "HH:mm";
                                        xlWorkSheet.Range["H" + (row - 1)].Value = tonggio + double.Parse(item["TongThoiGianTangCa"].ToString());
                                        xlWorkSheet.Range["I" + (row - 1)].Value = double.Parse(item["LuyKeTHang"].ToString());
                                    }
                                    else
                                    {
                                        tonggio = 0;
                                        xlWorkSheet.Rows[row].RowHeight = 20;
                                        xlWorkSheet.Range["A" + row].Value = index;
                                        xlWorkSheet.Range["B" + row].Value = item["MaNhanVien"].ToString();
                                        xlWorkSheet.Range["C" + row].Value = item["TenNhanVien"].ToString();
                                        xlWorkSheet.Range["D" + row].Value = item["GioBatDau"].ToString();
                                        xlWorkSheet.Range["D" + row].NumberFormat = "HH:mm";
                                        xlWorkSheet.Range["E" + row].Value = item["GioKetThuc"].ToString();
                                        xlWorkSheet.Range["E" + row].NumberFormat = "HH:mm";
                                        xlWorkSheet.Range["H" + row].Value = item["TongThoiGianTangCa"].ToString();
                                        xlWorkSheet.Range["I" + row].Value = double.Parse(item["LuyKeTHang"].ToString());
                                        xlWorkSheet.Range["K" + row].Value = DateTime.Parse(item["NgayTangCa"].ToString()).ToString("yyyy/MM/dd");
                                        row++;
                                        index++;
                                        xlWorkSheet.Range["A" + (row + 1) + ":K" + (row + 1)].Insert(excel.XlInsertShiftDirection.xlShiftDown);
                                    }
                                    ngay = DateTime.Parse(item.Field<string>("NgayTangCa").ToString()).ToString("yyyy/MM/dd");
                                    tonggio += double.Parse(item["TongThoiGianTangCa"].ToString());
                                    manhanvien_check = item["MaNhanVien"].ToString();

                                }
                                xlWorkSheet.get_Range("A12", "K" + row).Borders.LineStyle = excel.XlLineStyle.xlContinuous;
                                xlWorkSheet.Rows[row + 9].RowHeight = 20;
                                xlWorkSheet.Rows[row + 10].RowHeight = 20;
                            }
                            xlWorkBook.Save();
                            xlWorkBook.Close(true, misValue, misValue);
                            xlApp.Quit();
                            file_quagio = true;
                        }
                        catch (Exception ex)
                        {
                            xlWorkBook.Close();
                            xlApp.Quit();
                            throw new Exception(ex.Message, ex);
                        }
                    }
                }
                // tinh luy ke thang hoan chinh
                if (dt_copy.Count > 0)
                {
                    double luyke = 0;
                    string manhanvien = "";
                    foreach (var item in dt_copy.OrderBy(x => x.MaNhanVien).ThenBy(x => x.NgayTangCa).ToList())
                    {
                        TimeSpan thoigiantangca = new TimeSpan();
                        var ngaytangca = DateTime.Parse(item.NgayTangCa).ToString("yyyy/MM/dd");
                        var Gioketthuc = DateTime.Parse(ngaytangca + " " + item.GioKetThuc.ToString()).ToString("yyyy/MM/dd HH:mm:00");
                        var Giobatdau = DateTime.Parse(ngaytangca + " " + item.GioBatDau.ToString()).ToString("yyyy/MM/dd HH:mm:00");

                        if (TimeSpan.Parse(DateTime.Parse(Gioketthuc).ToString("HH:mm:00")) < TimeSpan.Parse(DateTime.Parse(Giobatdau).ToString("HH:mm:00")))
                        {
                            Gioketthuc = DateTime.Parse(Gioketthuc.ToString()).AddDays(1).ToString("yyyy/MM/dd HH:mm:00");
                        }
                        if ((item.Ca == "" || item.Ca == "HC") && item.LoaiTangCa.ToString() == "2")
                        {
                            if (TimeSpan.Parse(DateTime.Parse(Giobatdau).ToString("HH:mm:00")) <= TimeSpan.Parse("11:50:00") && TimeSpan.Parse(DateTime.Parse(Gioketthuc).ToString("HH:mm:00")) >= TimeSpan.Parse("12:40:00"))
                            {
                                if (thoivu == true)
                                {
                                    thoigiantangca = DateTime.Parse(Gioketthuc.ToString()).Subtract(DateTime.Parse(Giobatdau.ToString())) - TimeSpan.Parse("00:40:00") - TimeSpan.Parse("08:00:00");
                                }
                                else
                                {
                                    thoigiantangca = DateTime.Parse(Gioketthuc.ToString()).Subtract(DateTime.Parse(Giobatdau.ToString())) - TimeSpan.Parse("00:40:00");
                                }
                            }
                            else
                            {
                                thoigiantangca = DateTime.Parse(Gioketthuc.ToString()).Subtract(DateTime.Parse(Giobatdau.ToString()));
                            }
                        }
                        else if (item.Ca == "CA3" && item.LoaiTangCa.ToString() == "2")
                        {
                            if (thoivu == true)
                            {
                                thoigiantangca = DateTime.Parse(Gioketthuc.ToString()).Subtract(DateTime.Parse(Giobatdau.ToString())) - TimeSpan.Parse("08:00:00");
                            }
                            else
                            {
                                thoigiantangca = DateTime.Parse(Gioketthuc.ToString()).Subtract(DateTime.Parse(Giobatdau.ToString()));
                            }

                        }
                        else
                        {
                            thoigiantangca = TimeSpan.Parse(item.GioKetThuc.ToString()) - TimeSpan.Parse(item.GioBatDau.ToString());
                        }
                        decimal fsdf = (decimal.Parse(thoigiantangca.TotalHours.ToString()) - (int)thoigiantangca.TotalHours) * 60;
                        double ds = 0;
                        // 15
                        if (fsdf >= 15 && fsdf < 30)
                        {
                            ds = (0.25);
                        }
                        // 30
                        else if (fsdf >= 30 && fsdf < 45)
                        {
                            ds = 0.5;
                        }
                        // 45
                        else if (fsdf >= 45 && fsdf < 60)
                        {
                            ds = 0.75;
                        }
                        double tonggio_le = (int)thoigiantangca.TotalHours + (double)ds;

                        if (manhanvien != item.MaNhanVien.ToString())
                        {
                            manhanvien = item.MaNhanVien.ToString();
                            luyke = tonggio_le;
                        }
                        else
                        {
                            luyke += tonggio_le;
                        }
                        if (item.MaNhanVien.Contains("KC"))
                        {
                            dt_thoivu.Rows.Add(item.MaChamCong, item.MaNhanVien, item.TenNhanVien, item.MaPhongBan, item.TenPhongBan, item.LoaiTangCa, item.NgayTangCa, item.GioBatDau, item.GioKetThuc, tonggio_le, item.Ca, luyke);
                        }
                        else
                        {
                            dt_dachinh.Rows.Add(item.MaChamCong, item.MaNhanVien, item.TenNhanVien, item.MaPhongBan, item.TenPhongBan, item.LoaiTangCa, item.NgayTangCa, item.GioBatDau, item.GioKetThuc, tonggio_le, item.Ca, luyke);
                        }
                    }
                }
                if (dt_dachinh.Rows.Count > 0)
                {
                    lbl_progress.Text = "2/3";
                    progressBar1.Value = 0;
                    var dt_ = dt_dachinh.Rows.Cast<DataRow>().Where(x => DateTime.Parse(x["NgayTangCa"].ToString()) >= DateTime.Parse(dtp_tungay.Value.ToString("yyyy/MM/dd 00:00:00")) && DateTime.Parse(x["NgayTangCa"].ToString()) <= DateTime.Parse(dtp_denngay.Value.ToString("yyyy/MM/dd 00:00:00")));
                    var dt_new = dt_.Count() > 0 ? dt_.CopyToDataTable() : null;
                    if (dt_new != null && dt_new.Rows.Count > 0)
                    {
                        if (cbo_phongban.SelectIds.ToString() != "")
                        {
                            if (chk_thoivu[0] != "TV")
                            {
                                //dt_new = dt_new.Rows.Cast<DataRow>().Where(x => x["MaPhongBan"].ToString() == cbo_phongban.SelectedValue.ToString()).CopyToDataTable();
                                dt_new = dt_new.Rows.Cast<DataRow>().Where(x => cbo_phongban.SelectIds.Split(',').ToList().Contains(x["MaPhongBan"].ToString())).CopyToDataTable();
                            }
                        }
                        var phongban = dt_new.Rows.Cast<DataRow>().Select(x => new { MaPhongBan = x["MaPhongBan"], TenPhongBan = x["TenPhongBan"] }).Distinct().ToList();
                        //var workPath = $@"{Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData)}\template_work_excel_" + DateTime.Now.ToString("yyyyMMdd_HHmmss") + ".xlsx";

                        var sql_lydotangca = "select * from [MITACOSQL].[dbo].LyDoOT";
                        DataTable data_lydotangca = SQLHelper.ExecuteDt(sql_lydotangca);

                        excel.Application xlApp = new excel.Application();
                        string targetPath = $@"{Environment.GetFolderPath(Environment.SpecialFolder.Desktop)}";
                        string destFile = System.IO.Path.Combine(targetPath, $"TangCaThang_" + dtp_tungay.Value.Month + "_HoanChinh.xlsx");
                        if (File.Exists(destFile))
                        {
                            File.Delete(destFile);
                        }
                        var asm = Assembly.GetEntryAssembly();
                        var templatePath = $@"{Path.GetDirectoryName(asm.Location)}\Resources\TangCa_HoanChinh_template.xlsx";
                        File.Copy(templatePath, destFile, true);
                        object misValue = System.Reflection.Missing.Value;
                        excel.Workbook xlWorkBook = xlApp.Workbooks.Open(destFile, 0, false, 5, "", "", true, excel.XlPlatform.xlWindows, "\t", false, false, 0, true, 1, 0);

                        try
                        {
                            excel.Worksheet xlWorkSheet = (excel.Worksheet)xlWorkBook.Sheets[1];
                            xlWorkSheet.Name = phongban[0].TenPhongBan.ToString().Replace("/", ".");
                            excel.Range xlRange = xlWorkSheet.UsedRange;
                            for (int i = 1; i < phongban.Count(); i++)
                            {
                                xlWorkSheet.Copy(Type.Missing, xlWorkBook.Sheets[xlWorkBook.Sheets.Count]);
                                xlWorkBook.Sheets[xlWorkBook.Sheets.Count].Name = phongban[i].TenPhongBan.ToString().Replace("/", ".");
                            }
                            int count_progress = 0;
                            for (int i = 0; i < phongban.Count(); i++)
                            {
                                xlWorkSheet = (excel.Worksheet)xlWorkBook.Sheets[i + 1];
                                xlWorkSheet.Activate();
                                string lydo = data_lydotangca.Rows.Cast<DataRow>().Where(x => x.Field<string>("PhongBan") == phongban[i].MaPhongBan.ToString()).Select(y => y.Field<string>("LyDoOT")).FirstOrDefault();
                                var dulieutheongay = dt_new.Rows.Cast<DataRow>().Where(x => x["MaPhongBan"].ToString() == phongban[i].MaPhongBan.ToString()).OrderBy(x => x["MaNhanVien"]).ThenBy(x => x["NgayTangCa"]).ThenBy(x => x.Field<string>("GioBatDau")).ToList().ToList();
                                xlWorkSheet.Range["A5"].Value = "Ngày viết đơn: " + DateTime.Parse(dtp_denngay.Text.ToString()).ToString("yyyy/MM/dd");
                                xlWorkSheet.Range["D5"].Value = "Ngày y/c làm thêm: ";
                                xlWorkSheet.Range["H5"].Value = "Bộ phận: " + phongban[i].TenPhongBan;
                                xlWorkSheet.Range["A8"].Value = "Lý do tăng ca/\r\n残業理由： " + lydo;
                                int row = 12;
                                int index = 1;
                                //string manhanvien = "";
                                //double luyke = 0;
                                string ngay = "";
                                double tonggio = 0;
                                string manhanvien_check = "";

                                foreach (var item in dulieutheongay)
                                {
                                    count_progress++;
                                    progressBar1.Value = (int)(((float)count_progress / (float)dt_new.Rows.Count) * (float)100);
                                    if (manhanvien_check == item.Field<string>("MaNhanVien").ToString() && ngay == DateTime.Parse(item.Field<string>("NgayTangCa").ToString()).ToString("yyyy/MM/dd"))
                                    {
                                        xlWorkSheet.Range["F" + (row - 1)].Value = item.Field<string>("GioBatDau").ToString().ToString();
                                        xlWorkSheet.Range["F" + (row - 1)].NumberFormat = "HH:mm";
                                        xlWorkSheet.Range["G" + (row - 1)].Value = item.Field<string>("GioKetThuc").ToString().ToString();
                                        xlWorkSheet.Range["G" + (row - 1)].NumberFormat = "HH:mm";
                                        xlWorkSheet.Range["H" + (row - 1)].Value = tonggio + double.Parse(item["TongThoiGianTangCa"].ToString());
                                        xlWorkSheet.Range["I" + (row - 1)].Value = double.Parse(item["LuyKeTHang"].ToString());
                                    }
                                    else
                                    {
                                        tonggio = 0;
                                        xlWorkSheet.Rows[row].RowHeight = 20;
                                        xlWorkSheet.Range["A" + row].Value = index;
                                        xlWorkSheet.Range["B" + row].Value = item["MaNhanVien"].ToString();
                                        xlWorkSheet.Range["C" + row].Value = item["TenNhanVien"].ToString();
                                        xlWorkSheet.Range["D" + row].Value = item["GioBatDau"].ToString();
                                        xlWorkSheet.Range["D" + row].NumberFormat = "HH:mm";
                                        xlWorkSheet.Range["E" + row].Value = item["GioKetThuc"].ToString();
                                        xlWorkSheet.Range["E" + row].NumberFormat = "HH:mm";
                                        xlWorkSheet.Range["H" + row].Value = item["TongThoiGianTangCa"].ToString();
                                        xlWorkSheet.Range["I" + row].Value = double.Parse(item["LuyKeTHang"].ToString());
                                        xlWorkSheet.Range["K" + row].Value = DateTime.Parse(item["NgayTangCa"].ToString()).ToString("yyyy/MM/dd");
                                        row++;
                                        index++;
                                        xlWorkSheet.Range["A" + (row + 1) + ":K" + (row + 1)].Insert(excel.XlInsertShiftDirection.xlShiftDown);
                                    }
                                    ngay = DateTime.Parse(item.Field<string>("NgayTangCa").ToString()).ToString("yyyy/MM/dd");
                                    tonggio += double.Parse(item["TongThoiGianTangCa"].ToString());
                                    manhanvien_check = item["MaNhanVien"].ToString();

                                }
                                xlWorkSheet.get_Range("A12", "K" + row).Borders.LineStyle = excel.XlLineStyle.xlContinuous;
                                xlWorkSheet.Rows[row + 9].RowHeight = 20;
                                xlWorkSheet.Rows[row + 10].RowHeight = 20;
                            }
                            xlWorkBook.Save();
                            xlWorkBook.Close(true, misValue, misValue);
                            xlApp.Quit();
                            file_hoanchinh = true;
                            #region NPOI
                            //var workPath = $@"{Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData)}\TangCaThang_" + dtp_tungay.Value.Month + "_HoanChinh.xlsx";
                            //CreateWorkFile(workPath, "TangCa_HoanChinh_template_Tam");
                            //var xlsBook = new XlsWorkBook(workPath, copy_page: phongban.Count() - 1);
                            //var style = xlsBook.GetCellStyle(border: true, alignment: NPOI.SS.UserModel.HorizontalAlignment.Center, fontHeight: 11, verticalAlignment: VerticalAlignment.Center);
                            //var style_format = xlsBook.GetCellStyle(formats: "HH:mm", border: true, alignment: NPOI.SS.UserModel.HorizontalAlignment.Center, fontHeight: 11, verticalAlignment: VerticalAlignment.Center);
                            //var style_border = xlsBook.GetCellStyle(border: true, fontHeight: 11);
                            //int count_progress = 0;
                            //for (int i = 0; i < phongban.Count(); i++)
                            //{
                            //    string lydo = data_lydotangca.Rows.Cast<DataRow>().Where(x => x.Field<string>("PhongBan") == phongban[i].MaPhongBan.ToString()).Select(y => y.Field<string>("LyDoOT")).FirstOrDefault();
                            //    var dulieutheongay = dt_new.Rows.Cast<DataRow>().Where(x => x["MaPhongBan"].ToString() == phongban[i].MaPhongBan.ToString()).OrderBy(x => x["MaNhanVien"]).ThenBy(x => x["NgayTangCa"]).ThenBy(x => x.Field<string>("GioBatDau")).ToList().ToList();
                            //    var xlsSheet = xlsBook.Sheet(i);
                            //    xlsSheet.Cell(4, 0).SetValue("Ngày viết đơn: " + DateTime.Parse(dtp_denngay.Text.ToString()).ToString("yyyy/MM/dd"));
                            //    xlsSheet.Cell(4, 3).SetValue("Ngày y/c làm thêm: ");
                            //    xlsSheet.Cell(4, 7).SetValue("Bộ phận: " + phongban[i].TenPhongBan);
                            //    xlsSheet.Cell(7, 0).SetValue("Lý do tăng ca/\r\n残業理由： " + lydo);
                            //    int row = 11;
                            //    int index = 1;
                            //    string ngay = "";
                            //    double tonggio = 0;
                            //    string manhanvien_check = "";
                            //    foreach (var item in dulieutheongay)
                            //    {
                            //        count_progress++;
                            //        progressBar1.Value = (int)(((float)count_progress / (float)dt_new.Rows.Count) * (float)100);
                            //        if (manhanvien_check == item.Field<string>("MaNhanVien").ToString() && ngay == DateTime.Parse(item.Field<string>("NgayTangCa").ToString()).ToString("yyyy/MM/dd"))
                            //        {
                            //            xlsSheet.Cell(row - 1, 11).SetValue(item["GioKetThuc"].ToString() != "" ? item["GioBatDau"].ToString().Remove(5, 3) : "");
                            //            xlsSheet.Cell(row - 1, 11).SetStyle(style);
                            //            xlsSheet.Cell(row - 1, 13).SetValue(item["GioKetThuc"].ToString() != "" ? item["GioKetThuc"].ToString().Remove(5, 3) : "");
                            //            xlsSheet.Cell(row - 1, 13).SetStyle(style);
                            //            xlsSheet.Cell(row - 1, 14).SetValue(tonggio + double.Parse(item["TongThoiGianTangCa"].ToString()));
                            //            xlsSheet.Cell(row - 1, 15).SetValue(double.Parse(item["LuyKeTHang"].ToString()));
                            //        }
                            //        else
                            //        {
                            //            xlsSheet.ShiftRow(row);
                            //            tonggio = 0;
                            //            xlsSheet.Cell(row, 0).SetValue(index);
                            //            xlsSheet.Cell(row, 0).SetStyle(style);
                            //            xlsSheet.Cell(row, 2).SetValue(item["MaNhanVien"].ToString());
                            //            xlsSheet.Cell(row, 2).SetStyle(style);
                            //            xlsSheet.Cell(row, 3).SetValue(item["TenNhanVien"].ToString());
                            //            xlsSheet.Cell(row, 3).SetStyle(style_border);
                            //            xlsSheet.Cell(row, 6).SetStyle(style_format);
                            //            xlsSheet.Cell(row, 6).SetValue(item["GioBatDau"].ToString() != "" ? item["GioBatDau"].ToString().Remove(5, 3) : "");
                            //            xlsSheet.Cell(row, 10).SetStyle(style_format);
                            //            xlsSheet.Cell(row, 10).SetValue(item["GioKetThuc"].ToString() != "" ? item["GioKetThuc"].ToString().Remove(5, 3) : "");
                            //            xlsSheet.Cell(row, 11).SetStyle(style_border);
                            //            xlsSheet.Cell(row, 13).SetStyle(style_border);
                            //            xlsSheet.Cell(row, 14).SetValue(double.Parse(item["TongThoiGianTangCa"].ToString()));
                            //            xlsSheet.Cell(row, 14).SetStyle(style);
                            //            xlsSheet.Cell(row, 15).SetValue(double.Parse(item["LuyKeTHang"].ToString()));
                            //            xlsSheet.Cell(row, 15).SetStyle(style);
                            //            xlsSheet.Cell(row, 18).SetStyle(style_border);
                            //            xlsSheet.Cell(row, 19).SetValue(DateTime.Parse(item["NgayTangCa"].ToString()).ToString("yyyy/MM/dd"));
                            //            xlsSheet.Cell(row, 19).SetStyle(style);
                            //            row++;
                            //            index++;

                            //        }
                            //        ngay = DateTime.Parse(item.Field<string>("NgayTangCa").ToString()).ToString("yyyy/MM/dd");
                            //        tonggio = tonggio + double.Parse(item["TongThoiGianTangCa"].ToString());
                            //        manhanvien_check = item["MaNhanVien"].ToString();
                            //    }
                            //    file_hoanchinh = true;
                            //    xlsSheet.HeightRow(xlsSheet.GetLastRowNum() - 9, 50);
                            //    xlsSheet.HeightRow(xlsSheet.GetLastRowNum() - 6, 50);
                            //    xlsSheet.HeightRow(xlsSheet.GetLastRowNum(), 450);
                            //    //xlsSheet.SetPrintScale(80);
                            //    xlsSheet.SetPrintSetup();
                            //    //xlsBook
                            //    xlsBook.SetSheetName(i, phongban[i].TenPhongBan.ToString().Replace("/", "."));

                            //}
                            //if (!Directory.Exists(Environment.GetFolderPath(Environment.SpecialFolder.Desktop))) Directory.CreateDirectory(Environment.GetFolderPath(Environment.SpecialFolder.Desktop));

                            //// 保存
                            //xlsBook.Save($@"{Environment.GetFolderPath(Environment.SpecialFolder.Desktop)}\TangCaThang_" + dtp_tungay.Value.Month + "_HoanChinh.xlsx");

                            //// ワークファイル削除
                            //File.Delete(workPath);
                            #endregion
                        }
                        catch (Exception ex)
                        {
                            throw new Exception(ex.Message, ex);
                        }
                    }
                }
                // xuất excel thời vụ
                if (dt_thoivu.Rows.Count > 0)
                {
                    lbl_progress.Text = "3/3";
                    progressBar1.Value = 0;
                    var dt_ = dt_thoivu.Rows.Cast<DataRow>().Where(x => DateTime.Parse(x["NgayTangCa"].ToString()) >= DateTime.Parse(dtp_tungay.Value.ToString("yyyy/MM/dd 00:00:00")) && DateTime.Parse(x["NgayTangCa"].ToString()) <= DateTime.Parse(dtp_denngay.Value.ToString("yyyy/MM/dd 00:00:00")));
                    var dt_new = dt_.Count() > 0 ? dt_.CopyToDataTable() : null;
                    if (dt_new != null && dt_new.Rows.Count > 0)
                    {
                        if (cbo_phongban.SelectIds.ToString() != "")
                        {
                            if (chk_thoivu[0] != "TV")
                            {
                                dt_new = dt_new.Rows.Cast<DataRow>().Where(x => chk_thoivu.Where(z => z != "TV").Contains(x["MaPhongBan"].ToString())).CopyToDataTable();
                            }
                        }
                        var phongban = dt_new.Rows.Cast<DataRow>().Select(x => new { MaPhongBan = x["MaPhongBan"], TenPhongBan = x["TenPhongBan"] }).Distinct().ToList();

                        var sql_lydotangca = "select * from [MITACOSQL].[dbo].LyDoOT";
                        DataTable data_lydotangca = SQLHelper.ExecuteDt(sql_lydotangca);

                        excel.Application xlApp = new excel.Application();
                        string targetPath = $@"{Environment.GetFolderPath(Environment.SpecialFolder.Desktop)}";
                        string destFile = System.IO.Path.Combine(targetPath, $"TangCaThang_" + dtp_tungay.Value.Month + "_ThoiVu.xlsx");
                        if (File.Exists(destFile))
                        {
                            File.Delete(destFile);
                        }
                        var asm = Assembly.GetEntryAssembly();
                        var templatePath = $@"{Path.GetDirectoryName(asm.Location)}\Resources\TangCa_HoanChinh_template.xlsx";
                        File.Copy(templatePath, destFile, true);
                        object misValue = System.Reflection.Missing.Value;
                        excel.Workbook xlWorkBook = xlApp.Workbooks.Open(destFile, 0, false, 5, "", "", true, excel.XlPlatform.xlWindows, "\t", false, false, 0, true, 1, 0);

                        try
                        {
                            excel.Worksheet xlWorkSheet = (excel.Worksheet)xlWorkBook.Sheets[1];
                            xlWorkSheet.Name = phongban[0].TenPhongBan.ToString().Replace("/", ".");
                            excel.Range xlRange = xlWorkSheet.UsedRange;
                            for (int i = 1; i < phongban.Count(); i++)
                            {
                                xlWorkSheet.Copy(Type.Missing, xlWorkBook.Sheets[xlWorkBook.Sheets.Count]);
                                xlWorkBook.Sheets[xlWorkBook.Sheets.Count].Name = phongban[i].TenPhongBan.ToString().Replace("/", ".");
                            }
                            int count_progress = 0;
                            for (int i = 0; i < phongban.Count(); i++)
                            {
                                xlWorkSheet = (excel.Worksheet)xlWorkBook.Sheets[i + 1];
                                xlWorkSheet.Activate();
                                string lydo = data_lydotangca.Rows.Cast<DataRow>().Where(x => x.Field<string>("PhongBan") == phongban[i].MaPhongBan.ToString()).Select(y => y.Field<string>("LyDoOT")).FirstOrDefault();
                                var dulieutheongay = dt_new.Rows.Cast<DataRow>().Where(x => x["MaPhongBan"].ToString() == phongban[i].MaPhongBan.ToString()).OrderBy(x => x["MaNhanVien"]).ThenBy(x => x["NgayTangCa"]).ThenBy(x => x.Field<string>("GioBatDau")).ToList().ToList();
                                xlWorkSheet.Range["A5"].Value = "Ngày viết đơn: " + DateTime.Parse(dtp_denngay.Text.ToString()).ToString("yyyy/MM/dd");
                                xlWorkSheet.Range["D5"].Value = "Ngày y/c làm thêm: ";
                                xlWorkSheet.Range["H5"].Value = "Bộ phận: " + phongban[i].TenPhongBan;
                                xlWorkSheet.Range["A8"].Value = "Lý do tăng ca/\r\n残業理由： " + lydo;
                                int row = 12;
                                int index = 1;
                                string ngay = "";
                                double tonggio = 0;
                                string manhanvien_check = "";

                                foreach (var item in dulieutheongay)
                                {
                                    count_progress++;
                                    progressBar1.Value = (int)(((float)count_progress / (float)dt_new.Rows.Count) * (float)100);
                                    if (manhanvien_check == item.Field<string>("MaNhanVien").ToString() && ngay == DateTime.Parse(item.Field<string>("NgayTangCa").ToString()).ToString("yyyy/MM/dd"))
                                    {
                                        xlWorkSheet.Range["F" + (row - 1)].Value = item.Field<string>("GioBatDau").ToString().ToString();
                                        xlWorkSheet.Range["F" + (row - 1)].NumberFormat = "HH:mm";
                                        xlWorkSheet.Range["G" + (row - 1)].Value = item.Field<string>("GioKetThuc").ToString().ToString();
                                        xlWorkSheet.Range["G" + (row - 1)].NumberFormat = "HH:mm";
                                        xlWorkSheet.Range["H" + (row - 1)].Value = tonggio + double.Parse(item["TongThoiGianTangCa"].ToString());
                                        xlWorkSheet.Range["I" + (row - 1)].Value = double.Parse(item["LuyKeTHang"].ToString());
                                    }
                                    else
                                    {
                                        tonggio = 0;
                                        xlWorkSheet.Rows[row].RowHeight = 20;
                                        xlWorkSheet.Range["A" + row].Value = index;
                                        xlWorkSheet.Range["B" + row].Value = item["MaNhanVien"].ToString();
                                        xlWorkSheet.Range["C" + row].Value = item["TenNhanVien"].ToString();
                                        xlWorkSheet.Range["D" + row].Value = item["GioBatDau"].ToString();
                                        xlWorkSheet.Range["D" + row].NumberFormat = "HH:mm";
                                        xlWorkSheet.Range["E" + row].Value = item["GioKetThuc"].ToString();
                                        xlWorkSheet.Range["E" + row].NumberFormat = "HH:mm";
                                        xlWorkSheet.Range["H" + row].Value = item["TongThoiGianTangCa"].ToString();
                                        xlWorkSheet.Range["I" + row].Value = double.Parse(item["LuyKeTHang"].ToString());
                                        xlWorkSheet.Range["K" + row].Value = DateTime.Parse(item["NgayTangCa"].ToString()).ToString("yyyy/MM/dd");
                                        row++;
                                        index++;
                                        xlWorkSheet.Range["A" + (row + 1) + ":K" + (row + 1)].Insert(excel.XlInsertShiftDirection.xlShiftDown);
                                    }
                                    ngay = DateTime.Parse(item.Field<string>("NgayTangCa").ToString()).ToString("yyyy/MM/dd");
                                    tonggio += double.Parse(item["TongThoiGianTangCa"].ToString());
                                    manhanvien_check = item["MaNhanVien"].ToString();

                                }
                                xlWorkSheet.get_Range("A12", "K" + row).Borders.LineStyle = excel.XlLineStyle.xlContinuous;
                                xlWorkSheet.Rows[row + 9].RowHeight = 20;
                                xlWorkSheet.Rows[row + 10].RowHeight = 20;
                            }
                            file_thoivu = true;
                        }
                        catch (Exception ex)
                        {
                            throw new Exception(ex.Message, ex);
                        }
                        finally
                        {
                            xlWorkBook.Save();
                            xlWorkBook.Close(true, misValue, misValue);
                            xlApp.Quit();
                        }
                    }
                }
                progressBar1.Value = 0;
                string duongdan = "";
                if (file_hoanchinh == true)
                {
                    duongdan += $@"{Environment.GetFolderPath(Environment.SpecialFolder.Desktop)}\TangCaThang_" + dtp_tungay.Value.Month + "_HoanChinh.xlsx" + Environment.NewLine;
                }
                if (file_quagio == true)
                {
                    duongdan += $@"{Environment.GetFolderPath(Environment.SpecialFolder.Desktop)}\TangCaThang_" + dtp_tungay.Value.Month + "_QuaGio.xlsx" + Environment.NewLine;
                }
                if (file_thoivu == true)
                {
                    duongdan += $@"{Environment.GetFolderPath(Environment.SpecialFolder.Desktop)}\TangCaThang_" + dtp_tungay.Value.Month + "_ThoiVu.xlsx" + Environment.NewLine;
                }
                RJMessageBox.Show("Xuất excel thành công \n" + duongdan, "Thông báo");
            }
            catch (Exception ex)
            {
                RJMessageBox.Show(ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void exportExcelThoiVu()
        {
            try
            {
                string sql_danhsachca = $"select * from [MITACOSQL].[dbo].BangXepCa where Nam = '{dtp_tungay.Value.Year}' and Thang = '{dtp_tungay.Value.Month}'";
                DataTable dt_danhsachca = new DataTable();
                dt_danhsachca = SQLHelper.ExecuteDt(sql_danhsachca);

                string sql = "select nv.MaNhanVien,nv.TenNhanVien,nv.MaChamCong," +
                    "case when nv.MaKhuVuc = 'KV00003' then 'TS' else case when nv.MaKhuVuc is null then 'NV' else nv.MaPhongBan end end as MaPhongBan," +
                    "case when nv.MaKhuVuc = 'KV00003' then N'Thai Sản' else case when nv.MaKhuVuc is null then N'Nghỉ việc' else pb.TenPhongBan end end as TenPhongBan," +
                    "nv.MaChamCong " +
                    "from [MITACOSQL].[dbo].NhanVien nv " +
                    "left join [MITACOSQL].[dbo].PHONGBAN pb on pb.MaPhongBan = nv.MaPhongBan " +
                    "where nv.MaNhanVien like 'KC%'";
                //"where nv.maphongban is not null";
                DataTable dt_nhanvien = new DataTable();
                dt_nhanvien = SQLHelper.ExecuteDt(sql);

                var dt_tungay = new DataTable();
                string sql_giotangca = "select Id,NgayTangCa,convert(time,GioTangCa) GioTangCa," +
                    "case when LoaiTangCa = 0 then N'Tăng ca trước giờ' else case when LoaiTangCa = 1 then N'Tăng ca sau giờ' else N'Tăng ca ngày nghỉ' end end LoaiTangCa,tc.MaChamCong,GioBatDau,GioKetThuc,LoaiTangCa LoaiTangCa_M, LuyKeThang " +
                    $"from [MITACOSQL].[dbo].DangKyTangCa tc " +
                    "join (select MaChamCong,MaNhanVien,TenNhanVien,case when MaKhuVuc is null then 'NV' else MaPhongBan end as MaPhongBan " +
                    "       from [MITACOSQL].[dbo].NHANVIEN" +
                    "       where MaNhanVien like 'KC%' ) nv on nv.MaChamCong = tc.MaChamCong " +
                    "left join [MITACOSQL].[dbo].PHONGBAN pb on nv.MaPhongBan = pb.MaPhongBan " +
                    $"where Month(NgayTangCa) = '{dtp_tungay.Value.Month}' " +
                    $"and Year(NgayTangCa) = '{dtp_tungay.Value.Year}' " +
                    $"and nv.MaNhanVien like 'KC%' ";

                DataTable dt1 = SQLHelper.ExecuteDt(sql_giotangca);
                dt_tungay = dt1;

                string sql_chamcong = $"select distinct MaChamCong,NgayCham " +
                    $"from [MITACOSQL].[dbo].CheckInOut where NgayCham >= '{dtp_tungay.Value.ToString("yyyy/MM/01 00:00:00")}' " +
                    $"and NgayCham <= '{dtp_denngay.Value.ToString("yyyy/MM/dd 00:00:00")}'";
                DataTable dt_chamcong = SQLHelper.ExecuteDt(sql_chamcong);
                string sql_chamcong_check = $"select MaChamCong,NgayCham,GioCham " +
                    $"from [MITACOSQL].[dbo].CheckInOut where NgayCham >= '{dtp_tungay.Value.ToString("yyyy/MM/01 00:00:00")}' " +
                    $"and NgayCham <= '{dtp_denngay.Value.AddDays(1).ToString("yyyy/MM/dd 00:00:00")}'";
                DataTable dt_chamcong_check = SQLHelper.ExecuteDt(sql_chamcong_check);
                var dt = (from nv in dt_nhanvien.AsEnumerable()
                          join tc in dt_tungay.AsEnumerable() on nv["MaChamCong"].ToString() equals tc["MaChamCong"].ToString()
                          join cc in dt_chamcong.AsEnumerable() on tc["MaChamCong"].ToString() equals cc["MaChamCong"].ToString()
                          where tc["NgayTangCa"].ToString() == cc["NgayCham"].ToString() && (nv["MaNhanVien"].ToString().Contains("KC"))
                          select new DK_tangca
                          {
                              MaChamCong = nv["MaChamCong"].ToString(),
                              MaNhanVien = nv["MaNhanVien"].ToString(),
                              TenNhanVien = nv["TenNhanVien"].ToString(),
                              MaPhongBan = nv["MaPhongBan"].ToString(),
                              TenPhongBan = nv["TenPhongBan"].ToString(),
                              LoaiTangCa = tc["LoaiTangCa_M"].ToString(),
                              NgayTangCa = tc["NgayTangCa"].ToString(),
                              GioBatDau = tc["GioBatDau"].ToString(),
                              GioKetThuc = tc["GioKetThuc"].ToString(),
                              TongThoiGianTangCa = TimeSpan.Parse(tc["GioKetThuc"].ToString()) - TimeSpan.Parse(tc["GioBatDau"].ToString()),
                              Ca = dt_danhsachca.Rows.Cast<DataRow>()
                            .Where(x => x.Field<int>("MaChamCong").ToString() == nv["MaChamCong"].ToString())
                            .Select(x => x.Field<string>("D" + DateTime.Parse(tc["NgayTangCa"].ToString().ToString()).Day.ToString())).FirstOrDefault(),
                              LuyKeThang = decimal.Parse(tc["LuyKeTHang"].ToString()),
                              GioVao = "",
                              GioRa = "",
                              TangCa = true
                          }).ToList();

                foreach (var item in dt)
                {
                    var thoigianchamcong = dt_chamcong_check.Rows.Cast<DataRow>()
                                            .Where(x => x["MaChamCong"].ToString() == item.MaChamCong.ToString() && x["NgayCham"].ToString() == item.NgayTangCa).ToList();

                    if (thoigianchamcong.Count > 0)
                    {
                        if (item.Ca != "CA3")
                        {
                            item.GioVao = thoigianchamcong.Min(x => DateTime.Parse(x["GioCham"].ToString()).ToString("yyyy/MM/dd HH:mm:ss"));
                            item.GioRa = thoigianchamcong.Max(x => DateTime.Parse(x["GioCham"].ToString()).ToString("yyyy/MM/dd HH:mm:ss"));
                            if (item.Ca == "CA1")
                            {

                                if ((TimeSpan.Parse(DateTime.Parse(item.GioRa.ToString()).ToString("HH:mm:ss")) > TimeSpan.Parse("14:00:00")
                                    && TimeSpan.Parse(DateTime.Parse(item.GioRa.ToString()).ToString("HH:mm:00")) < TimeSpan.Parse("14:30:00"))
                                    && item.LoaiTangCa != "2"
                                    && TimeSpan.Parse(DateTime.Parse(item.GioRa.ToString()).ToString("HH:mm:00")) - TimeSpan.Parse(DateTime.Parse(item.GioBatDau.ToString()).ToString("HH:mm:00")) < TimeSpan.Parse("00:20:00"))
                                {
                                    item.TangCa = false;
                                }
                                if (TimeSpan.Parse(DateTime.Parse(item.GioRa.ToString()).ToString("HH:mm:ss")) > TimeSpan.Parse("14:00:00")
                                    && TimeSpan.Parse(item.GioKetThuc) > TimeSpan.Parse(DateTime.Parse(item.GioRa.ToString()).ToString("HH:mm:00")))
                                {
                                    item.GioKetThuc = DateTime.Parse(item.GioRa.ToString()).ToString("HH:mm:ss");
                                }
                            }
                            else if (item.Ca == "CA2")
                            {
                                if ((TimeSpan.Parse(DateTime.Parse(item.GioVao.ToString()).ToString("HH:mm:00")) > TimeSpan.Parse("13:35:00")
                                    && TimeSpan.Parse(DateTime.Parse(item.GioVao.ToString()).ToString("HH:mm:00")) < TimeSpan.Parse("14:00:00"))
                                    && item.LoaiTangCa != "2"
                                    && TimeSpan.Parse(DateTime.Parse(item.GioKetThuc.ToString()).ToString("HH:mm:00")) - TimeSpan.Parse(DateTime.Parse(item.GioVao.ToString()).ToString("HH:mm:ss")) < TimeSpan.Parse("00:20:00"))
                                {
                                    item.TangCa = false;
                                }
                                if (TimeSpan.Parse(DateTime.Parse(item.GioVao.ToString()).ToString("HH:mm:00")) < TimeSpan.Parse("14:00:00")
                                    && TimeSpan.Parse(item.GioBatDau).Add(TimeSpan.Parse("00:01:59")) < TimeSpan.Parse(DateTime.Parse(item.GioVao.ToString()).ToString("HH:mm:00")))
                                {
                                    item.GioBatDau = DateTime.Parse(item.GioVao.ToString()).ToString("HH:mm:ss");
                                }
                            }
                            else
                            {
                                if (item.LoaiTangCa == "0")
                                {
                                    if ((TimeSpan.Parse(DateTime.Parse(item.GioVao.ToString()).ToString("HH:mm:00")) > TimeSpan.Parse("07:25:00")
                                        && TimeSpan.Parse(DateTime.Parse(item.GioVao.ToString()).ToString("HH:mm:00")) < TimeSpan.Parse("07:50:00"))
                                        && TimeSpan.Parse(DateTime.Parse(item.GioKetThuc.ToString()).ToString("HH:mm:00")) - TimeSpan.Parse(DateTime.Parse(item.GioVao.ToString()).ToString("HH:mm:00")) < TimeSpan.Parse("00:20:00"))
                                    {
                                        item.TangCa = false;
                                    }
                                    if (TimeSpan.Parse(DateTime.Parse(item.GioVao.ToString()).ToString("HH:mm:ss")) < TimeSpan.Parse("07:50:00")
                                        && TimeSpan.Parse(item.GioBatDau).Add(TimeSpan.Parse("00:01:59")) < TimeSpan.Parse(DateTime.Parse(item.GioVao.ToString()).ToString("HH:mm:ss")))
                                    {
                                        item.GioBatDau = DateTime.Parse(item.GioVao.ToString()).ToString("HH:mm:ss");
                                    }
                                }
                                else if (item.LoaiTangCa == "1")
                                {
                                    if ((TimeSpan.Parse(DateTime.Parse(item.GioRa.ToString()).ToString("HH:mm:ss")) > TimeSpan.Parse("16:30:00")
                                        && TimeSpan.Parse(DateTime.Parse(item.GioRa.ToString()).ToString("HH:mm:00")) < TimeSpan.Parse("17:00:00"))
                                        && TimeSpan.Parse(DateTime.Parse(item.GioRa.ToString()).ToString("HH:mm:00")) - TimeSpan.Parse(DateTime.Parse(item.GioBatDau.ToString()).ToString("HH:mm:ss")) < TimeSpan.Parse("00:20:00"))
                                    {
                                        item.TangCa = false;
                                    }
                                    if (TimeSpan.Parse(DateTime.Parse(item.GioRa.ToString()).ToString("HH:mm:00")) > TimeSpan.Parse("16:30:00")
                                        && TimeSpan.Parse(item.GioKetThuc) > TimeSpan.Parse(DateTime.Parse(item.GioRa.ToString()).ToString("HH:mm:00")))
                                    {
                                        item.GioKetThuc = DateTime.Parse(item.GioRa.ToString()).ToString("HH:mm:ss");
                                    }
                                }
                            }
                        }
                        else
                        {
                            item.GioVao = thoigianchamcong.Max(x => x["GioCham"].ToString());
                            item.GioRa = dt_chamcong_check.Rows.Cast<DataRow>()
                                            .Where(x => x["MaChamCong"].ToString() == item.MaChamCong.ToString() && x["NgayCham"].ToString() == DateTime.Parse(item.NgayTangCa).AddDays(1).ToString())
                                            .Min(x => x["GioCham"].ToString());

                            if ((TimeSpan.Parse(DateTime.Parse(item.GioVao.ToString()).ToString("HH:mm:00")) > TimeSpan.Parse("21:35:00")
                                && TimeSpan.Parse(DateTime.Parse(item.GioVao.ToString()).ToString("HH:mm:00")) < TimeSpan.Parse("22:00:00"))
                                && item.LoaiTangCa != "2"
                                && TimeSpan.Parse(DateTime.Parse(item.GioKetThuc.ToString()).ToString("HH:mm:00")) - TimeSpan.Parse(DateTime.Parse(item.GioVao.ToString()).ToString("HH:mm:00")) < TimeSpan.Parse("00:20:00"))
                            {
                                item.TangCa = false;
                            }
                            if (TimeSpan.Parse(DateTime.Parse(item.GioVao.ToString()).ToString("HH:mm:00")) < TimeSpan.Parse("22:00:00")
                                && TimeSpan.Parse(item.GioBatDau).Add(TimeSpan.Parse("00:01:59")) < TimeSpan.Parse(DateTime.Parse(item.GioVao.ToString()).ToString("HH:mm:00")))
                            {
                                item.GioBatDau = DateTime.Parse(item.GioVao.ToString()).ToString("HH:mm:ss");
                            }
                        }
                    }
                }

                DataTable dt_cattangca = new DataTable();
                DataTable dt_dachinh = new DataTable();
                dt_cattangca.Columns.Add("MaChamCong");
                dt_cattangca.Columns.Add("MaNhanVien");
                dt_cattangca.Columns.Add("TenNhanVien");
                dt_cattangca.Columns.Add("MaPhongBan");
                dt_cattangca.Columns.Add("TenPhongBan");
                dt_cattangca.Columns.Add("LoaiTangCa");
                dt_cattangca.Columns.Add("NgayTangCa");
                dt_cattangca.Columns.Add("GioBatDau");
                dt_cattangca.Columns.Add("GioKetThuc");
                dt_cattangca.Columns.Add("TongThoiGianTangCa");
                dt_cattangca.Columns.Add("Ca");
                dt_cattangca.Columns.Add("LuyKeThang");
                var dt_copy = dt.Where(x => x.TangCa == true).ToList();
                dt_dachinh = dt_cattangca.Copy();

                if (dt.Where(x => x.TangCa == true).ToList().Count == 0)
                {
                    RJMessageBox.Show("Không có dữ liệu tăng ca");
                    return;
                }

                // tinh luy ke thang hoan chinh
                if (dt_copy.Count > 0)
                {
                    double luyke = 0;
                    string manhanvien = "";
                    foreach (var item in dt_copy.OrderBy(x => x.MaNhanVien).ThenBy(x => x.NgayTangCa).ToList())
                    {
                        TimeSpan thoigiantangca = new TimeSpan();
                        var ngaytangca = DateTime.Parse(item.NgayTangCa).ToString("yyyy/MM/dd");
                        var Gioketthuc = DateTime.Parse(ngaytangca + " " + item.GioKetThuc.ToString()).ToString("yyyy/MM/dd HH:mm:00");
                        var Giobatdau = DateTime.Parse(ngaytangca + " " + item.GioBatDau.ToString()).ToString("yyyy/MM/dd HH:mm:00");

                        if (TimeSpan.Parse(DateTime.Parse(Gioketthuc).ToString("HH:mm:00")) < TimeSpan.Parse(DateTime.Parse(Giobatdau).ToString("HH:mm:00")))
                        {
                            Gioketthuc = DateTime.Parse(Gioketthuc.ToString()).AddDays(1).ToString("yyyy/MM/dd HH:mm:00");
                        }
                        if ((item.Ca == "" || item.Ca == "HC") && item.LoaiTangCa.ToString() == "2")
                        {
                            if (TimeSpan.Parse(DateTime.Parse(Giobatdau).ToString("HH:mm:00")) <= TimeSpan.Parse("11:50:00") && TimeSpan.Parse(DateTime.Parse(Gioketthuc).ToString("HH:mm:00")) >= TimeSpan.Parse("12:40:00"))
                            {
                                thoigiantangca = DateTime.Parse(Gioketthuc.ToString()).Subtract(DateTime.Parse(Giobatdau.ToString())) - TimeSpan.Parse("00:40:00") - TimeSpan.Parse("08:00:00");
                            }
                            else
                            {
                                thoigiantangca = DateTime.Parse(Gioketthuc.ToString()).Subtract(DateTime.Parse(Giobatdau.ToString()));
                            }
                        }
                        else if (item.Ca == "CA3" && item.LoaiTangCa.ToString() == "2")
                        {
                            thoigiantangca = DateTime.Parse(Gioketthuc.ToString()).Subtract(DateTime.Parse(Giobatdau.ToString())) - TimeSpan.Parse("08:00:00");
                        }
                        else
                        {
                            thoigiantangca = TimeSpan.Parse(item.GioKetThuc.ToString()) - TimeSpan.Parse(item.GioBatDau.ToString());
                        }
                        decimal fsdf = (decimal.Parse(thoigiantangca.TotalHours.ToString()) - (int)thoigiantangca.TotalHours) * 60;
                        double ds = 0;
                        // 15
                        if (fsdf >= 15 && fsdf < 30)
                        {
                            ds = (0.25);
                        }
                        // 30
                        else if (fsdf >= 30 && fsdf < 45)
                        {
                            ds = 0.5;
                        }
                        // 45
                        else if (fsdf >= 45 && fsdf < 60)
                        {
                            ds = 0.75;
                        }
                        double tonggio_le = (int)thoigiantangca.TotalHours + (double)ds;

                        if (manhanvien != item.MaNhanVien.ToString())
                        {
                            manhanvien = item.MaNhanVien.ToString();
                            luyke = tonggio_le;
                        }
                        else
                        {
                            luyke += tonggio_le;
                        }

                        dt_dachinh.Rows.Add(item.MaChamCong, item.MaNhanVien, item.TenNhanVien, item.MaPhongBan, item.TenPhongBan, item.LoaiTangCa, item.NgayTangCa, item.GioBatDau, item.GioKetThuc, tonggio_le, item.Ca, luyke);
                    }
                }
                if (dt_dachinh.Rows.Count > 0)
                {
                    lbl_progress.Text = "1/1";
                    progressBar1.Value = 0;
                    var dt_ = dt_dachinh.Rows.Cast<DataRow>().Where(x => DateTime.Parse(x["NgayTangCa"].ToString()) >= DateTime.Parse(dtp_tungay.Value.ToString("yyyy/MM/dd 00:00:00")) && DateTime.Parse(x["NgayTangCa"].ToString()) <= DateTime.Parse(dtp_denngay.Value.ToString("yyyy/MM/dd 00:00:00")));
                    var dt_new = dt_.Count() > 0 ? dt_.CopyToDataTable() : null;
                    if (dt_new != null && dt_new.Rows.Count > 0)
                    {
                        var phongban = dt_new.Rows.Cast<DataRow>().Select(x => new { MaPhongBan = x["MaPhongBan"], TenPhongBan = x["TenPhongBan"] }).Distinct().ToList();

                        var sql_lydotangca = "select * from [MITACOSQL].[dbo].LyDoOT";
                        DataTable data_lydotangca = SQLHelper.ExecuteDt(sql_lydotangca);

                        excel.Application xlApp = new excel.Application();
                        string targetPath = $@"{Environment.GetFolderPath(Environment.SpecialFolder.Desktop)}";
                        string destFile = System.IO.Path.Combine(targetPath, $"TangCaThang_" + dtp_tungay.Value.Month + "_ThoiVu.xlsx");
                        if (File.Exists(destFile))
                        {
                            File.Delete(destFile);
                        }
                        var asm = Assembly.GetEntryAssembly();
                        var templatePath = $@"{Path.GetDirectoryName(asm.Location)}\Resources\TangCa_HoanChinh_template.xlsx";
                        File.Copy(templatePath, destFile, true);
                        object misValue = System.Reflection.Missing.Value;
                        excel.Workbook xlWorkBook = xlApp.Workbooks.Open(destFile, 0, false, 5, "", "", true, excel.XlPlatform.xlWindows, "\t", false, false, 0, true, 1, 0);

                        try
                        {
                            excel.Worksheet xlWorkSheet = (excel.Worksheet)xlWorkBook.Sheets[1];
                            xlWorkSheet.Name = phongban[0].TenPhongBan.ToString().Replace("/", ".");
                            excel.Range xlRange = xlWorkSheet.UsedRange;
                            for (int i = 1; i < phongban.Count(); i++)
                            {
                                xlWorkSheet.Copy(Type.Missing, xlWorkBook.Sheets[xlWorkBook.Sheets.Count]);
                                xlWorkBook.Sheets[xlWorkBook.Sheets.Count].Name = phongban[i].TenPhongBan.ToString().Replace("/", ".");
                            }
                            int count_progress = 0;
                            for (int i = 0; i < phongban.Count(); i++)
                            {
                                xlWorkSheet = (excel.Worksheet)xlWorkBook.Sheets[i + 1];
                                xlWorkSheet.Activate();
                                string lydo = data_lydotangca.Rows.Cast<DataRow>().Where(x => x.Field<string>("PhongBan") == phongban[i].MaPhongBan.ToString()).Select(y => y.Field<string>("LyDoOT")).FirstOrDefault();
                                var dulieutheongay = dt_new.Rows.Cast<DataRow>().Where(x => x["MaPhongBan"].ToString() == phongban[i].MaPhongBan.ToString()).OrderBy(x => x["MaNhanVien"]).ThenBy(x => x["NgayTangCa"]).ThenBy(x => x.Field<string>("GioBatDau")).ToList().ToList();
                                xlWorkSheet.Range["A5"].Value = "Ngày viết đơn: " + DateTime.Parse(dtp_denngay.Text.ToString()).ToString("yyyy/MM/dd");
                                xlWorkSheet.Range["D5"].Value = "Ngày y/c làm thêm: ";
                                xlWorkSheet.Range["H5"].Value = "Bộ phận: " + phongban[i].TenPhongBan;
                                xlWorkSheet.Range["A8"].Value = "Lý do tăng ca/\r\n残業理由： " + lydo;
                                int row = 12;
                                int index = 1;
                                //string manhanvien = "";
                                //double luyke = 0;
                                string ngay = "";
                                double tonggio = 0;
                                string manhanvien_check = "";

                                foreach (var item in dulieutheongay)
                                {
                                    count_progress++;
                                    progressBar1.Value = (int)(((float)count_progress / (float)dt_new.Rows.Count) * (float)100);
                                    if (manhanvien_check == item.Field<string>("MaNhanVien").ToString() && ngay == DateTime.Parse(item.Field<string>("NgayTangCa").ToString()).ToString("yyyy/MM/dd"))
                                    {
                                        xlWorkSheet.Range["F" + (row - 1)].Value = item.Field<string>("GioBatDau").ToString().ToString();
                                        xlWorkSheet.Range["F" + (row - 1)].NumberFormat = "HH:mm";
                                        xlWorkSheet.Range["G" + (row - 1)].Value = item.Field<string>("GioKetThuc").ToString().ToString();
                                        xlWorkSheet.Range["G" + (row - 1)].NumberFormat = "HH:mm";
                                        xlWorkSheet.Range["H" + (row - 1)].Value = tonggio + double.Parse(item["TongThoiGianTangCa"].ToString());
                                        xlWorkSheet.Range["I" + (row - 1)].Value = double.Parse(item["LuyKeTHang"].ToString());
                                    }
                                    else
                                    {
                                        tonggio = 0;
                                        xlWorkSheet.Rows[row].RowHeight = 20;
                                        xlWorkSheet.Range["A" + row].Value = index;
                                        xlWorkSheet.Range["B" + row].Value = item["MaNhanVien"].ToString();
                                        xlWorkSheet.Range["C" + row].Value = item["TenNhanVien"].ToString();
                                        xlWorkSheet.Range["D" + row].Value = item["GioBatDau"].ToString();
                                        xlWorkSheet.Range["D" + row].NumberFormat = "HH:mm";
                                        xlWorkSheet.Range["E" + row].Value = item["GioKetThuc"].ToString();
                                        xlWorkSheet.Range["E" + row].NumberFormat = "HH:mm";
                                        xlWorkSheet.Range["H" + row].Value = item["TongThoiGianTangCa"].ToString();
                                        xlWorkSheet.Range["I" + row].Value = double.Parse(item["LuyKeTHang"].ToString());
                                        xlWorkSheet.Range["K" + row].Value = DateTime.Parse(item["NgayTangCa"].ToString()).ToString("yyyy/MM/dd");
                                        row++;
                                        index++;
                                        xlWorkSheet.Range["A" + (row + 1) + ":K" + (row + 1)].Insert(excel.XlInsertShiftDirection.xlShiftDown);
                                    }
                                    ngay = DateTime.Parse(item.Field<string>("NgayTangCa").ToString()).ToString("yyyy/MM/dd");
                                    tonggio += double.Parse(item["TongThoiGianTangCa"].ToString());
                                    manhanvien_check = item["MaNhanVien"].ToString();

                                }
                                xlWorkSheet.get_Range("A12", "K" + row).Borders.LineStyle = excel.XlLineStyle.xlContinuous;
                                xlWorkSheet.Rows[row + 9].RowHeight = 20;
                                xlWorkSheet.Rows[row + 10].RowHeight = 20;
                            }
                            xlWorkBook.Save();
                            xlWorkBook.Close(true, misValue, misValue);
                            xlApp.Quit();
                        }
                        catch (Exception ex)
                        {
                            //xlWorkBook.Close();
                            //xlApp.Quit();
                            throw new Exception(ex.Message, ex);
                        }
                    }
                }
                progressBar1.Value = 0;
                string duongdan = "";
                duongdan += $@"{Environment.GetFolderPath(Environment.SpecialFolder.Desktop)}\TangCaThang_" + dtp_tungay.Value.Month + "_ThoiVu.xlsx" + Environment.NewLine;
                RJMessageBox.Show("Xuất excel thời vụ thành công \n" + duongdan, "Thông báo");
            }
            catch (Exception ex)
            {
                RJMessageBox.Show(ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void CreateWorkFile(string workPath, string Tenfile)
        {
            // 既存のワークファイルを削除する
            if (File.Exists(workPath))
            {
                File.Delete(workPath);
            }

            // 実行ファイル配下のResourcesフォル内のテンプレートをコピー
            var asm = Assembly.GetEntryAssembly();
            var templatePath = $@"{Path.GetDirectoryName(asm.Location)}\Resources\{Tenfile}.xlsx";
            File.Copy(templatePath, workPath);
        }

        private void btn_export_luyke_Click(object sender, EventArgs e)
        {
            Cursor.Current = Cursors.WaitCursor;
            try
            {
                var chk_thoivu = cbo_phongban.SelectIds.ToString().Split(',').ToList();
                bool thoivu = true;
                string sql_danhsachca = $"select * from [MITACOSQL].[dbo].BangXepCa where Nam = '{dtp_tungay.Value.Year}' and Thang = '{dtp_tungay.Value.Month}'";
                DataTable dt_danhsachca = new DataTable();
                dt_danhsachca = SQLHelper.ExecuteDt(sql_danhsachca);

                string sql_quagio = $"select * " +
                    $"from [MITACOSQL].[dbo].QuaGioTangCa where Nam = {DateTime.Parse(dtp_tungay.Text).Year} and Thang = {DateTime.Parse(dtp_tungay.Text).Month}";
                DataTable dt_quagio = new DataTable();
                dt_quagio = SQLHelper.ExecuteDt(sql_quagio);
                var dt_tungay = new DataTable();
                string sql_giotangca = "select tc.*,nv.MaNhanVien,nv.TenNhanVien,nv.MaPhongBan,nv.TenPhongBan " +
                    "from [MITACOSQL].[dbo].DangKyTangCa tc " +
                    "join " +
                    "(select n.MaChamCong,n.MaNhanVien,n.TenNhanVien," +
                    " case when n.MaKhuVuc is null then 'NV' else case when n.MaKhuVuc = 'KV00003' then 'TS' else p.MaPhongBan end end as MaPhongBan," +
                    " case when n.MaKhuVuc is null then N'Nghỉ việc' else case when n.MaKhuVuc = 'KV00003' then 'Thai sản' else p.TenPhongBan end end as TenPhongBan" +
                    " from [MITACOSQL].[dbo].NHANVIEN n" +
                    " left join [MITACOSQL].[dbo].PHONGBAN p on p.MaPhongBan = n.MaPhongBan) nv on tc.MaChamCong = nv.MaChamCong " +
                    $"where tc.NgayTangCa >= '{dtp_tungay.Value.ToString("yyyy/MM/01")}' and tc.NgayTangCa <= '{dtp_denngay.Value.ToString("yyyy/MM/dd")}'";
                if (cbo_phongban.SelectIds.ToString() != "")
                {
                    if (chk_thoivu[0] != "TV")
                    {
                        //sql_giotangca = sql_giotangca + $" and pb.MaPhongBan = '{cbo_phongban.SelectedValue}'";
                        sql_giotangca += $" and nv.MaPhongBan in ('{string.Join("','", chk_thoivu.ToList().Where(x => x != "TV"))}')";
                    }
                }
                if (!string.IsNullOrEmpty(txt_search.Text))
                {
                    sql_giotangca += $" and (nv.MaNhanVien like '%{txt_search.Text}%' or nv.TenNhanVien like '%{txt_search.Text}%')";
                }
                DataTable dt1 = SQLHelper.ExecuteDt(sql_giotangca);
                dt_tungay = dt1;

                string sql_chamcong = $"select distinct MaChamCong,NgayCham from [MITACOSQL].[dbo].CheckInOut where NgayCham >= '{dtp_tungay.Value.ToString("yyyy/MM/01 00:00:00")}' and NgayCham <= '{dtp_denngay.Value.AddDays(1).ToString("yyyy/MM/dd 00:00:00")}'";
                DataTable dt_chamcong = SQLHelper.ExecuteDt(sql_chamcong);

                string sql_chamcong_check = $"select MaChamCong,NgayCham,GioCham from [MITACOSQL].[dbo].CheckInOut where NgayCham >= '{dtp_tungay.Value.ToString("yyyy/MM/01 00:00:00")}' and NgayCham <= '{dtp_denngay.Value.AddDays(1).ToString("yyyy/MM/dd 00:00:00")}'";
                DataTable dt_chamcong_check = SQLHelper.ExecuteDt(sql_chamcong_check);

                var dt = (from tc in dt_tungay.AsEnumerable()
                          select new DK_tangca
                          {
                              MaChamCong = tc["MaChamCong"].ToString(),
                              MaNhanVien = tc["MaNhanVien"].ToString(),
                              TenNhanVien = tc["TenNhanVien"].ToString(),
                              MaPhongBan = tc["MaPhongBan"].ToString(),
                              TenPhongBan = tc["TenPhongBan"].ToString(),
                              LoaiTangCa = tc["LoaiTangCa"].ToString(),
                              NgayTangCa = tc["NgayTangCa"].ToString(),
                              GioBatDau = tc["GioBatDau"].ToString(),
                              GioKetThuc = tc["GioKetThuc"].ToString(),
                              TongThoiGianTangCa = TimeSpan.Parse(tc["GioKetThuc"].ToString()) - TimeSpan.Parse(tc["GioBatDau"].ToString()),
                              Ca = dt_danhsachca.Rows.Cast<DataRow>()
                            .Where(x => x.Field<int>("MaChamCong").ToString() == tc["MaChamCong"].ToString())
                            .Select(x => x.Field<string>("D" + DateTime.Parse(tc["NgayTangCa"].ToString().ToString()).Day.ToString())).FirstOrDefault(),
                              LuyKeThang = decimal.Parse(tc["LuyKeTHang"].ToString()),
                              GioVao = "",
                              GioRa = "",
                              TangCa = true
                          }).ToList();

                if (chk_thoivu.Count == 1 && chk_thoivu.Contains("TV") && cbo_phongban.SelectIds.ToString() != "")
                {
                    dt = dt.Where(x => x.MaNhanVien.Contains("KC")).ToList();
                }
                else if (!chk_thoivu.Contains("TV") && cbo_phongban.SelectIds.ToString() != "")
                {
                    thoivu = false;
                    dt = dt.Where(x => !x.MaNhanVien.Contains("KC")).ToList();
                }

                foreach (var item in dt)
                {
                    if (item.Ca != "CA3")
                    {
                        var thoigianchamcong = dt_chamcong_check.Rows.Cast<DataRow>()
                                        .Where(x => x["MaChamCong"].ToString() == item.MaChamCong.ToString() && x["NgayCham"].ToString() == item.NgayTangCa).ToList();
                        if (thoigianchamcong.Count > 0)
                        {
                            item.GioVao = thoigianchamcong.Min(x => DateTime.Parse(x["GioCham"].ToString()).ToString("yyyy/MM/dd HH:mm:ss"));
                            item.GioRa = thoigianchamcong.Max(x => DateTime.Parse(x["GioCham"].ToString()).ToString("yyyy/MM/dd HH:mm:ss"));
                            if (item.Ca == "CA1")
                            {

                                if ((TimeSpan.Parse(DateTime.Parse(item.GioRa.ToString()).ToString("HH:mm:ss")) > TimeSpan.Parse("14:00:00")
                                    && TimeSpan.Parse(DateTime.Parse(item.GioRa.ToString()).ToString("HH:mm:00")) < TimeSpan.Parse("14:30:00"))
                                    && item.LoaiTangCa != "2"
                                    && TimeSpan.Parse(DateTime.Parse(item.GioRa.ToString()).ToString("HH:mm:00")) - TimeSpan.Parse(DateTime.Parse(item.GioBatDau.ToString()).ToString("HH:mm:00")) < TimeSpan.Parse("00:20:00"))
                                {
                                    item.TangCa = false;
                                }
                                if (TimeSpan.Parse(DateTime.Parse(item.GioRa.ToString()).ToString("HH:mm:ss")) > TimeSpan.Parse("14:00:00")
                                    && TimeSpan.Parse(item.GioKetThuc) > TimeSpan.Parse(DateTime.Parse(item.GioRa.ToString()).ToString("HH:mm:00")))
                                {
                                    item.GioKetThuc = DateTime.Parse(item.GioRa.ToString()).ToString("HH:mm:ss");
                                }
                            }
                            else if (item.Ca == "CA2")
                            {
                                if ((TimeSpan.Parse(DateTime.Parse(item.GioVao.ToString()).ToString("HH:mm:00")) > TimeSpan.Parse("13:35:00")
                                    && TimeSpan.Parse(DateTime.Parse(item.GioVao.ToString()).ToString("HH:mm:00")) < TimeSpan.Parse("14:00:00"))
                                    && item.LoaiTangCa != "2"
                                    && TimeSpan.Parse(DateTime.Parse(item.GioKetThuc.ToString()).ToString("HH:mm:00")) - TimeSpan.Parse(DateTime.Parse(item.GioVao.ToString()).ToString("HH:mm:ss")) < TimeSpan.Parse("00:20:00"))
                                {
                                    item.TangCa = false;
                                }
                                if (TimeSpan.Parse(DateTime.Parse(item.GioVao.ToString()).ToString("HH:mm:00")) < TimeSpan.Parse("14:00:00")
                                    && TimeSpan.Parse(item.GioBatDau).Add(TimeSpan.Parse("00:01:59")) < TimeSpan.Parse(DateTime.Parse(item.GioVao.ToString()).ToString("HH:mm:00")))
                                {
                                    item.GioBatDau = DateTime.Parse(item.GioVao.ToString()).ToString("HH:mm:ss");
                                }
                            }
                            else
                            {
                                if (item.LoaiTangCa == "0")
                                {
                                    if ((TimeSpan.Parse(DateTime.Parse(item.GioVao.ToString()).ToString("HH:mm:00")) > TimeSpan.Parse("07:25:00")
                                        && TimeSpan.Parse(DateTime.Parse(item.GioVao.ToString()).ToString("HH:mm:00")) < TimeSpan.Parse("07:50:00"))
                                        && TimeSpan.Parse(DateTime.Parse(item.GioKetThuc.ToString()).ToString("HH:mm:00")) - TimeSpan.Parse(DateTime.Parse(item.GioVao.ToString()).ToString("HH:mm:00")) < TimeSpan.Parse("00:20:00"))
                                    {
                                        item.TangCa = false;
                                    }
                                    if (TimeSpan.Parse(DateTime.Parse(item.GioVao.ToString()).ToString("HH:mm:ss")) < TimeSpan.Parse("07:50:00")
                                        && TimeSpan.Parse(item.GioBatDau).Add(TimeSpan.Parse("00:01:59")) < TimeSpan.Parse(DateTime.Parse(item.GioVao.ToString()).ToString("HH:mm:ss")))
                                    {
                                        item.GioBatDau = DateTime.Parse(item.GioVao.ToString()).ToString("HH:mm:ss");
                                    }
                                }
                                else if (item.LoaiTangCa == "1")
                                {
                                    if ((TimeSpan.Parse(DateTime.Parse(item.GioRa.ToString()).ToString("HH:mm:ss")) > TimeSpan.Parse("16:30:00")
                                        && TimeSpan.Parse(DateTime.Parse(item.GioRa.ToString()).ToString("HH:mm:00")) < TimeSpan.Parse("17:00:00"))
                                        && TimeSpan.Parse(DateTime.Parse(item.GioRa.ToString()).ToString("HH:mm:00")) - TimeSpan.Parse(DateTime.Parse(item.GioBatDau.ToString()).ToString("HH:mm:ss")) < TimeSpan.Parse("00:20:00"))
                                    {
                                        item.TangCa = false;
                                    }
                                    if (TimeSpan.Parse(DateTime.Parse(item.GioRa.ToString()).ToString("HH:mm:00")) > TimeSpan.Parse("16:30:00")
                                        && TimeSpan.Parse(item.GioKetThuc) > TimeSpan.Parse(DateTime.Parse(item.GioRa.ToString()).ToString("HH:mm:00")))
                                    {
                                        item.GioKetThuc = DateTime.Parse(item.GioRa.ToString()).ToString("HH:mm:ss");
                                    }
                                }
                            }
                        }
                    }
                    else
                    {
                        var ngaytangca = DateTime.Parse(item.NgayTangCa).ToString("yyyy/MM/dd");
                        var thoigianchamcong = dt_chamcong_check.Rows.Cast<DataRow>()
                                        .Where(x => x["MaChamCong"].ToString() == item.MaChamCong.ToString()
                                        && (DateTime.Parse(x["GioCham"].ToString()) >= DateTime.Parse(ngaytangca + " 17:00:00")
                                        && (DateTime.Parse(x["GioCham"].ToString()) <= DateTime.Parse(ngaytangca + " 08:00:00").AddDays(1)))).ToList();
                        if (thoigianchamcong.Count > 0)
                        {
                            item.GioVao = thoigianchamcong.Min(x => DateTime.Parse(x["GioCham"].ToString())).ToString("yyyy/MM/dd HH:mm:ss");
                            item.GioRa = thoigianchamcong.Max(x => DateTime.Parse(x["GioCham"].ToString())).ToString("yyyy/MM/dd HH:mm:ss");
                            if ((TimeSpan.Parse(DateTime.Parse(item.GioVao.ToString()).ToString("HH:mm:00")) > TimeSpan.Parse("21:35:00")
                                && TimeSpan.Parse(DateTime.Parse(item.GioVao.ToString()).ToString("HH:mm:00")) < TimeSpan.Parse("22:00:00"))
                                && item.LoaiTangCa != "2"
                                && TimeSpan.Parse(DateTime.Parse(item.GioKetThuc.ToString()).ToString("HH:mm:00")) - TimeSpan.Parse(DateTime.Parse(item.GioVao.ToString()).ToString("HH:mm:00")) < TimeSpan.Parse("00:20:00"))
                            {
                                item.TangCa = false;
                            }
                            if (TimeSpan.Parse(DateTime.Parse(item.GioVao.ToString()).ToString("HH:mm:00")) < TimeSpan.Parse("22:00:00")
                                && TimeSpan.Parse(item.GioBatDau).Add(TimeSpan.Parse("00:01:59")) < TimeSpan.Parse(DateTime.Parse(item.GioVao.ToString()).ToString("HH:mm:00")))
                            {
                                item.GioBatDau = DateTime.Parse(item.GioVao.ToString()).ToString("HH:mm:ss");
                            }
                        }
                    }
                    //}
                }

                DataTable dt_cattangca = new DataTable();
                DataTable dt_dachinh = new DataTable();
                DataTable dt_dachinh_quagio = new DataTable();
                DataTable dt_dachinh_tong = new DataTable();
                DataTable dt_thoivu = new DataTable();
                dt_cattangca.Columns.Add("MaChamCong");
                dt_cattangca.Columns.Add("MaNhanVien");
                dt_cattangca.Columns.Add("TenNhanVien");
                dt_cattangca.Columns.Add("MaPhongBan");
                dt_cattangca.Columns.Add("TenPhongBan");
                dt_cattangca.Columns.Add("LoaiTangCa");
                dt_cattangca.Columns.Add("NgayTangCa");
                dt_cattangca.Columns.Add("GioBatDau");
                dt_cattangca.Columns.Add("GioKetThuc");
                dt_cattangca.Columns.Add("TongThoiGianTangCa");
                dt_cattangca.Columns.Add("Ca");
                dt_cattangca.Columns.Add("LuyKeThang");
                var dt_copy = dt.Where(x => x.TangCa == true).ToList();
                dt_dachinh = dt_cattangca.Copy();
                dt_dachinh_quagio = dt_cattangca.Copy();
                dt_dachinh_tong = dt_cattangca.Copy();
                dt_thoivu = dt_cattangca.Copy();
                if (dt_quagio.Rows.Count > 0)
                {
                    foreach (var item in dt.Where(x => x.TangCa == true).ToList())
                    {
                        for (int j = 0; j < dt_quagio.Rows.Count; j++)
                        {
                            if (item.MaNhanVien.ToString() == dt_quagio.Rows[j]["MaNhanVien"].ToString())
                            {
                                int co = 0;
                                for (int i = 3; i < dt_quagio.Columns.Count; i++)
                                {
                                    co++;
                                    if (int.Parse(DateTime.Parse(item.NgayTangCa).ToString("dd")) == (co) && decimal.Parse(dt_quagio.Rows[j][i].ToString()) > 0)
                                    {
                                        dt_copy.Remove(item);
                                        dt_cattangca.Rows.Add(item.MaChamCong, item.MaNhanVien, item.TenNhanVien, item.MaPhongBan, item.TenPhongBan, item.LoaiTangCa, item.NgayTangCa, item.GioBatDau, item.GioKetThuc, item.TongThoiGianTangCa, item.Ca);
                                    }
                                }
                            }
                        }
                    }
                }
                var list_tong = dt.Where(x => x.TangCa == true).ToList();
                // tính lũy kế tổng
                if (list_tong.Count > 0)
                {
                    double luyke = 0;
                    string manhanvien = "";
                    foreach (var item in list_tong.OrderBy(x => x.MaNhanVien).ThenBy(x => x.NgayTangCa).ToList())
                    {
                        TimeSpan thoigiantangca = new TimeSpan();
                        var ngaytangca = DateTime.Parse(item.NgayTangCa.ToString()).ToString("yyyy/MM/dd");
                        var Gioketthuc = DateTime.Parse(ngaytangca + " " + item.GioKetThuc.ToString()).ToString("yyyy/MM/dd HH:mm:00");
                        var Giobatdau = DateTime.Parse(ngaytangca + " " + item.GioBatDau.ToString()).ToString("yyyy/MM/dd HH:mm:00");

                        if (TimeSpan.Parse(DateTime.Parse(Gioketthuc).ToString("HH:mm:00")) < TimeSpan.Parse(DateTime.Parse(Giobatdau).ToString("HH:mm:00")))
                        {
                            Gioketthuc = DateTime.Parse(Gioketthuc.ToString()).AddDays(1).ToString("yyyy/MM/dd HH:mm:00");
                        }
                        if ((item.Ca.ToString() == "" || item.Ca.ToString() == "HC") && item.LoaiTangCa.ToString() == "2")
                        {
                            if (TimeSpan.Parse(DateTime.Parse(Giobatdau).ToString("HH:mm:00")) <= TimeSpan.Parse("11:50:00") && TimeSpan.Parse(DateTime.Parse(Gioketthuc).ToString("HH:mm:00")) >= TimeSpan.Parse("12:40:00"))
                            {
                                thoigiantangca = DateTime.Parse(Gioketthuc.ToString()).Subtract(DateTime.Parse(Giobatdau.ToString())) - TimeSpan.Parse("00:40:00");
                                if (item.MaNhanVien.Contains("KC"))
                                {
                                    thoigiantangca = thoigiantangca - TimeSpan.Parse("08:00:00");
                                }
                            }
                            else
                            {
                                thoigiantangca = DateTime.Parse(Gioketthuc.ToString()).Subtract(DateTime.Parse(Giobatdau.ToString()));

                            }
                        }
                        else if (item.Ca.ToString() == "CA3" && item.LoaiTangCa.ToString() == "2")
                        {
                            thoigiantangca = DateTime.Parse(Gioketthuc.ToString()).Subtract(DateTime.Parse(Giobatdau.ToString()));
                            if (item.MaNhanVien.Contains("KC"))
                            {
                                thoigiantangca = thoigiantangca - TimeSpan.Parse("08:00:00");
                            }
                        }
                        else
                        {
                            thoigiantangca = TimeSpan.Parse(item.GioKetThuc.ToString()) - TimeSpan.Parse(item.GioBatDau.ToString());
                        }
                        decimal fsdf = (decimal.Parse(thoigiantangca.TotalHours.ToString()) - (int)thoigiantangca.TotalHours) * 60;
                        double ds = 0;
                        // 15
                        if (fsdf >= 15 && fsdf < 30)
                        {
                            ds = (0.25);
                        }
                        // 30
                        else if (fsdf >= 30 && fsdf < 45)
                        {
                            ds = 0.5;
                        }
                        // 45
                        else if (fsdf >= 45 && fsdf < 60)
                        {
                            ds = 0.75;
                        }
                        double tonggio_le = (int)thoigiantangca.TotalHours + (double)ds;

                        if (manhanvien != item.MaNhanVien.ToString())
                        {
                            manhanvien = item.MaNhanVien.ToString();
                            luyke = tonggio_le;
                        }
                        else
                        {
                            luyke += tonggio_le;
                        }
                        if (item.MaNhanVien.Contains("KC"))
                        {
                            dt_thoivu.Rows.Add(item.MaChamCong, item.MaNhanVien.ToString(), item.TenNhanVien, item.MaPhongBan, item.TenPhongBan, item.LoaiTangCa.ToString(), item.NgayTangCa, item.GioBatDau.ToString(), item.GioKetThuc.ToString(), tonggio_le, item.Ca.ToString(), luyke);
                        }
                        else
                        {
                            dt_dachinh_tong.Rows.Add(item.MaChamCong, item.MaNhanVien.ToString(), item.TenNhanVien, item.MaPhongBan, item.TenPhongBan, item.LoaiTangCa.ToString(), item.NgayTangCa, item.GioBatDau.ToString(), item.GioKetThuc.ToString(), tonggio_le, item.Ca.ToString(), luyke);
                        }
                    }
                }
                // tính lũy kế tháng qua gio
                if (dt_cattangca.Rows.Count > 0)
                {
                    double luyke = 0;
                    string manhanvien = "";
                    foreach (var item in dt_cattangca.Rows.Cast<DataRow>().OrderBy(x => x["MaNhanVien"]).ThenBy(x => x["NgayTangCa"]).ToList())
                    {
                        TimeSpan thoigiantangca = new TimeSpan();
                        var ngaytangca = DateTime.Parse(item["NgayTangCa"].ToString()).ToString("yyyy/MM/dd");
                        var Gioketthuc = DateTime.Parse(ngaytangca + " " + item["GioKetThuc"].ToString()).ToString("yyyy/MM/dd HH:mm:00");
                        var Giobatdau = DateTime.Parse(ngaytangca + " " + item["GioBatDau"].ToString()).ToString("yyyy/MM/dd HH:mm:00");

                        if (TimeSpan.Parse(DateTime.Parse(Gioketthuc).ToString("HH:mm:00")) < TimeSpan.Parse(DateTime.Parse(Giobatdau).ToString("HH:mm:00")))
                        {
                            Gioketthuc = DateTime.Parse(Gioketthuc.ToString()).AddDays(1).ToString("yyyy/MM/dd HH:mm:00");
                        }
                        if ((item["Ca"].ToString() == "" || item["Ca"].ToString() == "HC") && item["LoaiTangCa"].ToString() == "2")
                        {
                            if (TimeSpan.Parse(DateTime.Parse(Giobatdau).ToString("HH:mm:00")) <= TimeSpan.Parse("11:50:00") && TimeSpan.Parse(DateTime.Parse(Gioketthuc).ToString("HH:mm:00")) >= TimeSpan.Parse("12:40:00"))
                            {
                                thoigiantangca = DateTime.Parse(Gioketthuc.ToString()).Subtract(DateTime.Parse(Giobatdau.ToString())) - TimeSpan.Parse("00:40:00");
                            }
                            else
                            {
                                thoigiantangca = DateTime.Parse(Gioketthuc.ToString()).Subtract(DateTime.Parse(Giobatdau.ToString()));
                            }
                        }
                        else if (item["Ca"].ToString() == "CA3" && item["LoaiTangCa"].ToString() == "2")
                        {
                            thoigiantangca = DateTime.Parse(Gioketthuc.ToString()).Subtract(DateTime.Parse(Giobatdau.ToString()));
                        }
                        else
                        {
                            thoigiantangca = TimeSpan.Parse(item["GioKetThuc"].ToString()) - TimeSpan.Parse(item["GioBatDau"].ToString());
                        }
                        decimal fsdf = (decimal.Parse(thoigiantangca.TotalHours.ToString()) - (int)thoigiantangca.TotalHours) * 60;
                        double ds = 0;
                        // 15
                        if (fsdf >= 15 && fsdf < 30)
                        {
                            ds = (0.25);
                        }
                        // 30
                        else if (fsdf >= 30 && fsdf < 45)
                        {
                            ds = 0.5;
                        }
                        // 45
                        else if (fsdf >= 45 && fsdf < 60)
                        {
                            ds = 0.75;
                        }
                        double tonggio_le = (int)thoigiantangca.TotalHours + (double)ds;

                        if (manhanvien != item["MaNhanVien"].ToString())
                        {
                            manhanvien = item["MaNhanVien"].ToString();
                            luyke = tonggio_le;
                        }
                        else
                        {
                            luyke += tonggio_le;
                        }

                        dt_dachinh_quagio.Rows.Add(item["MaChamCong"], item["MaNhanVien"].ToString(), item["TenNhanVien"], item["MaPhongBan"], item["TenPhongBan"], item["LoaiTangCa"].ToString(), item["NgayTangCa"], item["GioBatDau"].ToString(), item["GioKetThuc"].ToString(), tonggio_le, item["Ca"].ToString(), luyke);
                    }
                }
                // tinh luy ke thang hoan chinh
                if (dt_copy.Count > 0)
                {
                    double luyke = 0;
                    string manhanvien = "";
                    foreach (var item in dt_copy.OrderBy(x => x.MaNhanVien).ThenBy(x => x.NgayTangCa).ToList())
                    {
                        if (item.MaNhanVien.Contains("KC"))
                        {
                            continue;
                        }
                        TimeSpan thoigiantangca = new TimeSpan();
                        var ngaytangca = DateTime.Parse(item.NgayTangCa).ToString("yyyy/MM/dd");
                        var Gioketthuc = DateTime.Parse(ngaytangca + " " + item.GioKetThuc.ToString()).ToString("yyyy/MM/dd HH:mm:00");
                        var Giobatdau = DateTime.Parse(ngaytangca + " " + item.GioBatDau.ToString()).ToString("yyyy/MM/dd HH:mm:00");

                        if (TimeSpan.Parse(DateTime.Parse(Gioketthuc).ToString("HH:mm:00")) < TimeSpan.Parse(DateTime.Parse(Giobatdau).ToString("HH:mm:00")))
                        {
                            Gioketthuc = DateTime.Parse(Gioketthuc.ToString()).AddDays(1).ToString("yyyy/MM/dd HH:mm:00");
                        }
                        if ((item.Ca == "" || item.Ca == "HC") && item.LoaiTangCa.ToString() == "2")
                        {
                            if (TimeSpan.Parse(DateTime.Parse(Giobatdau).ToString("HH:mm:00")) <= TimeSpan.Parse("11:50:00") && TimeSpan.Parse(DateTime.Parse(Gioketthuc).ToString("HH:mm:00")) >= TimeSpan.Parse("12:40:00"))
                            {
                                thoigiantangca = DateTime.Parse(Gioketthuc.ToString()).Subtract(DateTime.Parse(Giobatdau.ToString())) - TimeSpan.Parse("00:40:00");
                            }
                            else
                            {
                                thoigiantangca = DateTime.Parse(Gioketthuc.ToString()).Subtract(DateTime.Parse(Giobatdau.ToString()));
                            }
                        }
                        else if (item.Ca == "CA3" && item.LoaiTangCa.ToString() == "2")
                        {
                            thoigiantangca = DateTime.Parse(Gioketthuc.ToString()).Subtract(DateTime.Parse(Giobatdau.ToString()));
                        }
                        else
                        {
                            thoigiantangca = TimeSpan.Parse(item.GioKetThuc.ToString()) - TimeSpan.Parse(item.GioBatDau.ToString());
                        }
                        decimal fsdf = (decimal.Parse(thoigiantangca.TotalHours.ToString()) - (int)thoigiantangca.TotalHours) * 60;
                        double ds = 0;
                        // 15
                        if (fsdf >= 15 && fsdf < 30)
                        {
                            ds = (0.25);
                        }
                        // 30
                        else if (fsdf >= 30 && fsdf < 45)
                        {
                            ds = 0.5;
                        }
                        // 45
                        else if (fsdf >= 45 && fsdf < 60)
                        {
                            ds = 0.75;
                        }
                        double tonggio_le = (int)thoigiantangca.TotalHours + (double)ds;

                        if (manhanvien != item.MaNhanVien.ToString())
                        {
                            manhanvien = item.MaNhanVien.ToString();
                            luyke = tonggio_le;
                        }
                        else
                        {
                            luyke += tonggio_le;
                        }

                        dt_dachinh.Rows.Add(item.MaChamCong, item.MaNhanVien, item.TenNhanVien, item.MaPhongBan, item.TenPhongBan, item.LoaiTangCa, item.NgayTangCa, item.GioBatDau, item.GioKetThuc, tonggio_le, item.Ca, luyke);
                    }
                }

                var workPath = $@"{Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData)}\template_luyke_quagio.xlsx";
                if (File.Exists(workPath))
                {
                    File.Delete(workPath);
                }

                int count_sheet = 4;

                if (chk_thoivu.Count == 1 && chk_thoivu.Contains("TV") && cbo_phongban.SelectIds.ToString() != "")
                {
                    count_sheet = 1;
                }
                else if (!chk_thoivu.Contains("TV") && cbo_phongban.SelectIds.ToString() != "")
                {
                    count_sheet = 3;
                }

                var xlsBook = new XlsWorkBook(workPath, count_sheet);
                // sheet tong
                if (dt_dachinh_tong.Rows.Count > 0)
                {
                    var dt_tong = dt_dachinh_tong.Rows.Cast<DataRow>().Where(x => DateTime.Parse(x["NgayTangCa"].ToString()) <= DateTime.Parse(dtp_denngay.Value.ToString("yyyy/MM/dd 00:00:00")));
                    var count_luyke = (from a in dt_tong.AsEnumerable()
                                       group new { a } by new
                                       {
                                           MaChamCong = a["MaChamCong"],
                                           MaNhanVien = a["MaNhanVien"],
                                           TenNhanVien = a["TenNhanVien"],
                                           TenPhongBan = a["TenPhongBan"],
                                           MaPhongBan = a["MaPhongBan"]
                                       } into g
                                       select new
                                       {
                                           g.Key.MaChamCong,
                                           g.Key.MaNhanVien,
                                           g.Key.TenNhanVien,
                                           g.Key.TenPhongBan,
                                           g.Key.MaPhongBan,
                                           LuyKe = g.Max(i => double.Parse(i.a["LuyKeThang"].ToString()))
                                       }).ToList();

                    if (count_luyke != null && count_luyke.Count > 0)
                    {
                        if (cbo_phongban.SelectIds.ToString() != "")
                        {
                            count_luyke = count_luyke.Where(x => cbo_phongban.SelectIds.Split(',').ToList().Contains(x.MaPhongBan.ToString())).ToList();
                        }

                        xlsBook.SetSheetName(0, "Tổng");
                        var xlsSheet = xlsBook.Sheet(0);
                        var style = xlsBook.GetCellStyle(border: true, color: HSSFColor.BlueGrey.Index, alignment: HorizontalAlignment.Center, text_control: 0, fontHeight: 12);
                        var style_detail = xlsBook.GeCellStyleAlignment(HorizontalAlignment.Center);
                        xlsSheet.SetColumnWidth(0, 1200);
                        xlsSheet.SetColumnWidth(1, 2200);
                        xlsSheet.SetColumnWidth(2, 6500);
                        xlsSheet.SetColumnWidth(3, 4000);

                        xlsSheet.Cell(2, 0).SetValue("Stt");
                        xlsSheet.Cell(2, 0).SetStyle(style);
                        xlsSheet.Cell(2, 1).SetValue("Mã VN");
                        xlsSheet.Cell(2, 1).SetStyle(style);
                        xlsSheet.Cell(2, 2).SetValue("Tên nhân viên");
                        xlsSheet.Cell(2, 2).SetStyle(style);
                        xlsSheet.Cell(2, 3).SetValue("Phòng ban");
                        xlsSheet.Cell(2, 3).SetStyle(style);
                        xlsSheet.Cell(2, 4).SetValue("Lũy kế");
                        xlsSheet.Cell(2, 4).SetStyle(style);

                        var dulieutheongay = count_luyke.OrderBy(x => x.MaNhanVien).ToList();
                        int index = 1;
                        int rowIndex = 3;
                        foreach (var item_nv in dulieutheongay)
                        {
                            xlsSheet.Cell(rowIndex, 0).SetValue(index);
                            xlsSheet.Cell(rowIndex, 0).SetStyle(style_detail);
                            xlsSheet.Cell(rowIndex, 1).SetValue(item_nv.MaNhanVien.ToString());
                            xlsSheet.Cell(rowIndex, 1).SetStyle(style_detail);
                            xlsSheet.Cell(rowIndex, 2).SetValue(item_nv.TenNhanVien.ToString());
                            xlsSheet.Cell(rowIndex, 2).SetStyle(style_detail);
                            xlsSheet.Cell(rowIndex, 3).SetValue(item_nv.TenPhongBan.ToString());
                            xlsSheet.Cell(rowIndex, 3).SetStyle(style_detail);
                            xlsSheet.Cell(rowIndex, 4).SetValue(item_nv.LuyKe);
                            xlsSheet.Cell(rowIndex, 4).SetStyle(style_detail);
                            index++;
                            rowIndex++;
                        }
                    }
                }
                // sheet hoan chinh
                if (dt_dachinh.Rows.Count > 0)
                {
                    var dt_hoanchinh = dt_dachinh.Rows.Cast<DataRow>().Where(x => DateTime.Parse(x["NgayTangCa"].ToString()) <= DateTime.Parse(dtp_denngay.Value.ToString("yyyy/MM/dd 00:00:00")));
                    var count_luyke = (from a in dt_hoanchinh.AsEnumerable()
                                       group new { a } by new
                                       {
                                           MaChamCong = a["MaChamCong"],
                                           MaNhanVien = a["MaNhanVien"],
                                           TenNhanVien = a["TenNhanVien"],
                                           TenPhongBan = a["TenPhongBan"],
                                           MaPhongBan = a["MaPhongBan"]
                                       } into g
                                       select new
                                       {
                                           g.Key.MaChamCong,
                                           g.Key.MaNhanVien,
                                           g.Key.TenNhanVien,
                                           g.Key.TenPhongBan,
                                           g.Key.MaPhongBan,
                                           LuyKe = g.Max(i => double.Parse(i.a["LuyKeThang"].ToString()))
                                       }).ToList();

                    if (count_luyke != null && count_luyke.Count > 0)
                    {
                        if (cbo_phongban.SelectIds.ToString() != "")
                        {
                            count_luyke = count_luyke.Where(x => cbo_phongban.SelectIds.Split(',').ToList().Contains(x.MaPhongBan.ToString())).ToList();
                        }

                        xlsBook.SetSheetName(1, "Hoàn chỉnh");
                        var xlsSheet = xlsBook.Sheet(1);
                        var style = xlsBook.GetCellStyle(border: true, color: HSSFColor.BlueGrey.Index, alignment: HorizontalAlignment.Center, text_control: 0, fontHeight: 12);
                        var style_detail = xlsBook.GeCellStyleAlignment(HorizontalAlignment.Center);
                        xlsSheet.SetColumnWidth(0, 1200);
                        xlsSheet.SetColumnWidth(1, 2200);
                        xlsSheet.SetColumnWidth(2, 6500);
                        xlsSheet.SetColumnWidth(3, 4000);

                        xlsSheet.Cell(2, 0).SetValue("Stt");
                        xlsSheet.Cell(2, 0).SetStyle(style);
                        xlsSheet.Cell(2, 1).SetValue("Mã VN");
                        xlsSheet.Cell(2, 1).SetStyle(style);
                        xlsSheet.Cell(2, 2).SetValue("Tên nhân viên");
                        xlsSheet.Cell(2, 2).SetStyle(style);
                        xlsSheet.Cell(2, 3).SetValue("Phòng ban");
                        xlsSheet.Cell(2, 3).SetStyle(style);
                        xlsSheet.Cell(2, 4).SetValue("Lũy kế");
                        xlsSheet.Cell(2, 4).SetStyle(style);

                        var dulieutheongay = count_luyke.OrderBy(x => x.MaNhanVien).ToList();
                        int index = 1;
                        int rowIndex = 3;
                        foreach (var item_nv in dulieutheongay)
                        {
                            xlsSheet.Cell(rowIndex, 0).SetValue(index);
                            xlsSheet.Cell(rowIndex, 0).SetStyle(style_detail);
                            xlsSheet.Cell(rowIndex, 1).SetValue(item_nv.MaNhanVien.ToString());
                            xlsSheet.Cell(rowIndex, 1).SetStyle(style_detail);
                            xlsSheet.Cell(rowIndex, 2).SetValue(item_nv.TenNhanVien.ToString());
                            xlsSheet.Cell(rowIndex, 2).SetStyle(style_detail);
                            xlsSheet.Cell(rowIndex, 3).SetValue(item_nv.TenPhongBan.ToString());
                            xlsSheet.Cell(rowIndex, 3).SetStyle(style_detail);
                            xlsSheet.Cell(rowIndex, 4).SetValue(item_nv.LuyKe);
                            xlsSheet.Cell(rowIndex, 4).SetStyle(style_detail);
                            index++;
                            rowIndex++;
                        }
                    }
                }
                // sheet qua gio
                if (dt_dachinh_quagio.Rows.Count > 0)
                {
                    var dt_ = dt_dachinh_quagio.Rows.Cast<DataRow>().Where(x => DateTime.Parse(x["NgayTangCa"].ToString()) <= DateTime.Parse(dtp_denngay.Value.ToString("yyyy/MM/dd 00:00:00"))).ToList();
                    var count_luyke_quagio = (from a in dt_.AsEnumerable()
                                              group new { a } by new
                                              {
                                                  MaChamCong = a["MaChamCong"],
                                                  MaNhanVien = a["MaNhanVien"],
                                                  TenNhanVien = a["TenNhanVien"],
                                                  TenPhongBan = a["TenPhongBan"],
                                                  MaPhongBan = a["MaPhongBan"]
                                              } into g
                                              select new
                                              {
                                                  g.Key.MaChamCong,
                                                  g.Key.MaNhanVien,
                                                  g.Key.TenNhanVien,
                                                  g.Key.TenPhongBan,
                                                  g.Key.MaPhongBan,
                                                  LuyKe = g.Max(i => double.Parse(i.a["LuyKeThang"].ToString()))
                                              }).ToList();

                    if (count_luyke_quagio != null && count_luyke_quagio.Count > 0)
                    {
                        if (cbo_phongban.SelectIds.ToString() != "")
                        {
                            count_luyke_quagio = count_luyke_quagio.Where(x => cbo_phongban.SelectIds.Split(',').ToList().Contains(x.MaPhongBan.ToString())).ToList();
                        }
                        xlsBook.SetSheetName(2, "Quá giờ");
                        var xlsSheet = xlsBook.Sheet(2);
                        var style = xlsBook.GetCellStyle(border: true, color: HSSFColor.BlueGrey.Index, alignment: HorizontalAlignment.Center, text_control: 0, fontHeight: 12);
                        var style_detail = xlsBook.GeCellStyleAlignment(HorizontalAlignment.Center);
                        xlsSheet.SetColumnWidth(0, 1200);
                        xlsSheet.SetColumnWidth(1, 2200);
                        xlsSheet.SetColumnWidth(2, 6500);
                        xlsSheet.SetColumnWidth(3, 4000);

                        xlsSheet.Cell(2, 0).SetValue("Stt");
                        xlsSheet.Cell(2, 0).SetStyle(style);
                        xlsSheet.Cell(2, 1).SetValue("Mã VN");
                        xlsSheet.Cell(2, 1).SetStyle(style);
                        xlsSheet.Cell(2, 2).SetValue("Tên nhân viên");
                        xlsSheet.Cell(2, 2).SetStyle(style);
                        xlsSheet.Cell(2, 3).SetValue("Phòng ban");
                        xlsSheet.Cell(2, 3).SetStyle(style);
                        xlsSheet.Cell(2, 4).SetValue("Lũy kế");
                        xlsSheet.Cell(2, 4).SetStyle(style);

                        var dulieutheongay = count_luyke_quagio.OrderBy(x => x.MaNhanVien).ToList();
                        int index = 1;
                        int rowIndex = 3;
                        foreach (var item_nv in dulieutheongay)
                        {
                            xlsSheet.Cell(rowIndex, 0).SetValue(index);
                            xlsSheet.Cell(rowIndex, 0).SetStyle(style_detail);
                            xlsSheet.Cell(rowIndex, 1).SetValue(item_nv.MaNhanVien.ToString());
                            xlsSheet.Cell(rowIndex, 1).SetStyle(style_detail);
                            xlsSheet.Cell(rowIndex, 2).SetValue(item_nv.TenNhanVien.ToString());
                            xlsSheet.Cell(rowIndex, 2).SetStyle(style_detail);
                            xlsSheet.Cell(rowIndex, 3).SetValue(item_nv.TenPhongBan.ToString());
                            xlsSheet.Cell(rowIndex, 3).SetStyle(style_detail);
                            xlsSheet.Cell(rowIndex, 4).SetValue(item_nv.LuyKe);
                            xlsSheet.Cell(rowIndex, 4).SetStyle(style_detail);
                            index++;
                            rowIndex++;
                        }
                    }
                }
                // sheet thoi vu
                if (dt_thoivu.Rows.Count > 0)
                {
                    var dt_ = dt_thoivu.Rows.Cast<DataRow>().Where(x => DateTime.Parse(x["NgayTangCa"].ToString()) <= DateTime.Parse(dtp_denngay.Value.ToString("yyyy/MM/dd 00:00:00"))).ToList();
                    var count_luyke_thoivu = (from a in dt_.AsEnumerable()
                                              group new { a } by new
                                              {
                                                  MaChamCong = a["MaChamCong"],
                                                  MaNhanVien = a["MaNhanVien"],
                                                  TenNhanVien = a["TenNhanVien"],
                                                  TenPhongBan = a["TenPhongBan"],
                                                  MaPhongBan = a["MaPhongBan"]
                                              } into g
                                              select new
                                              {
                                                  g.Key.MaChamCong,
                                                  g.Key.MaNhanVien,
                                                  g.Key.TenNhanVien,
                                                  g.Key.TenPhongBan,
                                                  g.Key.MaPhongBan,
                                                  LuyKe = g.Max(i => double.Parse(i.a["LuyKeThang"].ToString()))
                                              }).ToList();

                    if (count_luyke_thoivu != null && count_luyke_thoivu.Count > 0)
                    {
                        if (cbo_phongban.SelectIds.ToString() != "")
                        {
                            //count_luyke_quagio = count_luyke_quagio.Where(x => x.MaPhongBan.ToString() == cbo_phongban.SelectedValue.ToString()).ToList();
                            if (chk_thoivu[0] != "TV")
                            {
                                count_luyke_thoivu = count_luyke_thoivu.Where(x => chk_thoivu.ToList().Contains(x.MaPhongBan.ToString())).ToList();
                            }
                        }
                        xlsBook.SetSheetName(count_sheet - 1, "Thời vụ");
                        var xlsSheet = xlsBook.Sheet(count_sheet - 1);
                        var style = xlsBook.GetCellStyle(border: true, color: HSSFColor.BlueGrey.Index, alignment: HorizontalAlignment.Center, text_control: 0, fontHeight: 12);
                        var style_detail = xlsBook.GeCellStyleAlignment(HorizontalAlignment.Center);
                        xlsSheet.SetColumnWidth(0, 1200);
                        xlsSheet.SetColumnWidth(1, 2200);
                        xlsSheet.SetColumnWidth(2, 6500);
                        xlsSheet.SetColumnWidth(3, 4000);

                        xlsSheet.Cell(2, 0).SetValue("Stt");
                        xlsSheet.Cell(2, 0).SetStyle(style);
                        xlsSheet.Cell(2, 1).SetValue("Mã VN");
                        xlsSheet.Cell(2, 1).SetStyle(style);
                        xlsSheet.Cell(2, 2).SetValue("Tên nhân viên");
                        xlsSheet.Cell(2, 2).SetStyle(style);
                        xlsSheet.Cell(2, 3).SetValue("Phòng ban");
                        xlsSheet.Cell(2, 3).SetStyle(style);
                        xlsSheet.Cell(2, 4).SetValue("Lũy kế");
                        xlsSheet.Cell(2, 4).SetStyle(style);

                        var dulieutheongay = count_luyke_thoivu.OrderBy(x => x.MaNhanVien).ToList();
                        int index = 1;
                        int rowIndex = 3;
                        foreach (var item_nv in dulieutheongay)
                        {
                            xlsSheet.Cell(rowIndex, 0).SetValue(index);
                            xlsSheet.Cell(rowIndex, 0).SetStyle(style_detail);
                            xlsSheet.Cell(rowIndex, 1).SetValue(item_nv.MaNhanVien.ToString());
                            xlsSheet.Cell(rowIndex, 1).SetStyle(style_detail);
                            xlsSheet.Cell(rowIndex, 2).SetValue(item_nv.TenNhanVien.ToString());
                            xlsSheet.Cell(rowIndex, 2).SetStyle(style_detail);
                            xlsSheet.Cell(rowIndex, 3).SetValue(item_nv.TenPhongBan.ToString());
                            xlsSheet.Cell(rowIndex, 3).SetStyle(style_detail);
                            xlsSheet.Cell(rowIndex, 4).SetValue(item_nv.LuyKe);
                            xlsSheet.Cell(rowIndex, 4).SetStyle(style_detail);
                            index++;
                            rowIndex++;
                        }
                    }
                }
                if (!Directory.Exists(Environment.GetFolderPath(Environment.SpecialFolder.Desktop))) Directory.CreateDirectory(Environment.GetFolderPath(Environment.SpecialFolder.Desktop));

                // 保存
                xlsBook.Save($@"{Environment.GetFolderPath(Environment.SpecialFolder.Desktop)}\LuyKeThang_" + dtp_tungay.Value.Month + "_DenNgay" + dtp_denngay.Value.Day + ".xlsx");

                // ワークファイル削除
                File.Delete(workPath);
                RJMessageBox.Show("Xuất excel thành công", "Thông báo");
            }
            catch (Exception ex)
            {
                RJMessageBox.Show(ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            Cursor.Current = Cursors.Default;
        }
        private void GetNgaySaiGio()
        {
            string sql = "SELECT [MaCaLamViec],[GioVaoLamViec],[GioKetThucLamViec] FROM [MITACOSQL].[dbo].[CaLamViecNew]";
            DataTable ca_lanviec = new DataTable();
            ca_lanviec = SQLHelper.ExecuteDt(sql);

            DataTable dt_dacbiet = new DataTable();
            dt_dacbiet.Columns.Add("MaChamCong");
            dt_dacbiet.Columns.Add("TenNhanVien");
            dt_dacbiet.Columns.Add("Ngay");
            dt_dacbiet.Columns.Add("LyDo");

            DataTable dt_ngaynghi = new DataTable();
            string sql_ngaynghi = $"select * from [MITACOSQL].[dbo].NgayNghi where nam = '{dtp_search.Value.Year}' and thang = '{dtp_search.Value.Month}'";
            dt_ngaynghi = SQLHelper.ExecuteDt(sql_ngaynghi);

            string sql_ca = $"select * from [MITACOSQL].[dbo].BangXepCa where Nam = '{dtp_search.Value.Year}' and Thang = '{dtp_search.Value.Month}'";
            DataTable ds_ca = new DataTable();
            ds_ca = SQLHelper.ExecuteDt(sql_ca);

            string sql_database = "select * " +
                                        "from( select a.MaChamCong,NgayCham,GioCham,b.TenNhanVien,b.MaNhanVien,pb.TenPhongBan " +
                                                "from [MITACOSQL].[dbo].CheckInOut a " +
                                                "join [MITACOSQL].[dbo].NHANVIEN b on a.MaChamCong = b.MaChamCong " +
                                                "join [MITACOSQL].[dbo].PHONGBAN pb on b.MaPhongBan = pb.MaPhongBan" +
                                                $") a where MaNhanVien not like 'JP%' And a.MaNhanVien like '%{txt_search.Text}%' ";
            string where_dk_tangca = "";
            if (chk_month.Checked == true)
            {
                where_dk_tangca += $" and Month(NgayTangCa) = {dtp_search.Value.Month} ";
                sql_database = sql_database + $" and Month(a.NgayCham) = {dtp_search.Value.Month} and Year(NgayCham) = {dtp_search.Value.Year}" + " order by a.MaChamCong desc,a.NgayCham";
            }
            else
            {
                where_dk_tangca += $" and NgayTangCa = '{dtp_search.Value.ToString("yyyy/MM/dd")}' ";
                sql_database = sql_database + $" and a.NgayCham = '{dtp_search.Value.ToString("yyyy/MM/dd")}' " + " order by a.MaChamCong desc,a.NgayCham";
            }

            string sql_dktangca = "select * from [MITACOSQL].[dbo].DangKyTangCa where 1 = 1 " + where_dk_tangca;
            DataTable dt_dktangca = SQLHelper.ExecuteDt(sql_dktangca);
            DataTable dt_sql_selectall = new DataTable();
            dt_sql_selectall = SQLHelper.ExecuteDt(sql_database);

            var checkedRows = DGVNhanVien
                                .Rows
                                .Cast<DataGridViewRow>()
                                .Where(x => x.Cells[0].Value != null && x.Cells[0].Value.ToString() == "True")
                                .Select(x => new { MaChamCong = x.Cells["MaChamCong"], TenNhanVien = x.Cells["TenNhanVien"], MaNhanVien = x.Cells["MaNhanVien"] }).ToList();
            foreach (var item in checkedRows)
            {
                var ca_dk = ds_ca.Rows.Cast<DataRow>().Where(x => x["MaChamCong"].ToString() == item.MaChamCong.Value.ToString()).FirstOrDefault();
                var check_inout = dt_sql_selectall.Rows.Cast<DataRow>().Where(x => x["MaChamCong"].ToString() == item.MaChamCong.Value.ToString()).ToList();
                var dt_dktangca_nv = dt_dktangca.Rows.Cast<DataRow>().Where(x => x["MaChamCong"].ToString() == item.MaChamCong.Value.ToString()).OrderBy(x => x["NgayTangCa"].ToString()).ToList();

                foreach (var a in dt_dktangca_nv)
                {
                    //var ca_ngaynghi = dt_ngaynghi.Rows.Cast<DataRow>().Select(x=> bool.Parse(x["D" + DateTime.Parse(a["NgayTangCa"].ToString()).Day].ToString())).FirstOrDefault(); 
                    var checkinout_ngay = check_inout.Where(x => x["NgayCham"].ToString() == a["NgayTangCa"].ToString()).ToList();
                    var ca_d = ca_dk["D" + DateTime.Parse(a["NgayTangCa"].ToString()).Day].ToString();

                    var ca = ca_lanviec.Rows.Cast<DataRow>().Where(x => x["MaCaLamViec"].ToString() == (ca_d == "" ? "HC" : ca_d)).FirstOrDefault();

                    var giovao = checkinout_ngay.Min(x => DateTime.Parse(x["GioCham"].ToString()).ToString("yyyy/MM/dd HH:mm:ss"));
                    var giora = checkinout_ngay.Max(x => DateTime.Parse(x["GioCham"].ToString()).ToString("yyyy/MM/dd HH:mm:ss"));
                    if (string.IsNullOrEmpty(giovao) || string.IsNullOrEmpty(giora))
                    {
                        dt_dacbiet.Rows.Add(item.MaChamCong.Value.ToString(), item.TenNhanVien.Value.ToString(), DateTime.Parse(a["NgayTangCa"].ToString()).ToString(), "Không có giờ chấm công");
                        continue;
                    }
                    if (ca["MaCaLamViec"].ToString() == "CA3")
                    {

                        giovao = checkinout_ngay.Max(x => DateTime.Parse(x["GioCham"].ToString()).ToString("yyyy/MM/dd HH:mm:ss"));
                        giora = check_inout.Where(x => x["NgayCham"].ToString() == DateTime.Parse(a["NgayTangCa"].ToString()).AddDays(1).ToString()).Min(x => DateTime.Parse(x["GioCham"].ToString()).ToString("yyyy/MM/dd HH:mm:ss"));
                    }

                    if (DateTime.Parse(giovao) > DateTime.Parse(DateTime.Parse(a["NgayTangCa"].ToString()).ToString("yyyy/MM/dd") + " " + DateTime.Parse(ca["GioVaoLamViec"].ToString()).ToString("HH:mm:ss")) &&
                       DateTime.Parse(giora) < DateTime.Parse(DateTime.Parse(a["NgayTangCa"].ToString()).ToString("yyyy/MM/dd") + " " + DateTime.Parse(ca["GioKetThucLamViec"].ToString()).ToString("HH:mm:ss")))
                    {
                        dt_dacbiet.Rows.Add(item.MaChamCong.Value.ToString(), item.TenNhanVien.Value.ToString(), giovao, "Thiếu giờ vào hoặc giờ ra");
                    }
                }
            }
            dgv_dacbiet.DataSource = dt_dacbiet;
        }

    }
    public class DK_tangca
    {
        public string MaChamCong { get; set; }
        public string MaNhanVien { get; set; }
        public string TenNhanVien { get; set; }
        public string MaPhongBan { get; set; }
        public string TenPhongBan { get; set; }
        public string LoaiTangCa { get; set; }
        public string NgayTangCa { get; set; }
        public string GioBatDau { get; set; }
        public string GioKetThuc { get; set; }
        public TimeSpan TongThoiGianTangCa { get; set; }
        public string Ca { get; set; }
        public decimal LuyKeThang { get; set; }
        public string GioVao { get; set; }
        public string GioRa { get; set; }
        public bool TangCa { get; set; }
    }
}
