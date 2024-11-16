using System;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using TENTAC_HRM.Custom;

namespace TENTAC_HRM.Forms.ChamCong
{
    public partial class frm_ChinhVaoSomRaMuon : Form
    {
        CheckBox headerCheckBox = new CheckBox();
        public frm_ChinhVaoSomRaMuon()
        {
            InitializeComponent();
            LoadNam();
            LoadThang();
        }
        private void BindGrid()
        {
            //Find the Location of Header Cell.
            Point headerCellLocation = this.dgv_Data.GetCellDisplayRectangle(0, -1, true).Location;

            //Place the Header CheckBox in the Location of the Header Cell.
            headerCheckBox.Location = new Point(headerCellLocation.X + 50, headerCellLocation.Y + 2);
            headerCheckBox.BackColor = Color.Transparent;
            headerCheckBox.Size = new Size(18, 18);

            //Assign Click event to the Header CheckBox.
            headerCheckBox.Click += new EventHandler(HeaderCheckBox_Clicked);
            dgv_Data.Controls.Add(headerCheckBox);
        }
        private void HeaderCheckBox_Clicked(object sender, EventArgs e)
        {
            //Necessary to end the edit mode of the Cell.
            dgv_Data.EndEdit();

            //Loop and check and uncheck all row CheckBoxes based on Header Cell CheckBox.
            foreach (DataGridViewRow row in dgv_Data.Rows)
            {
                DataGridViewCheckBoxCell checkBox = (row.Cells["chk_col"] as DataGridViewCheckBoxCell);
                checkBox.Value = headerCheckBox.Checked;
            }
        }
        private void btn_Load_Click(object sender, EventArgs e)
        {
            LoadData();
        }

        private void btn_Save_Click(object sender, EventArgs e)
        {
            Cursor.Current = Cursors.WaitCursor;
            try
            {
                var listCheckInOut = (from DataGridViewRow r in dgv_Data.Rows
                                      where Convert.ToBoolean(r.Cells[0].Value) == true
                                      select r).ToList();
                foreach (DataGridViewRow r in listCheckInOut)
                {
                    try
                    {
                        string sql = "";
                        switch (r.Cells["Ca"].Value.ToString())
                        {
                            case "HC":
                                if (TimeSpan.Parse(r.Cells["GioCham"].Value.ToString()) < TimeSpan.Parse("07:35:00"))
                                {
                                    Random TenBienRanDom = new Random();
                                    var sophut = TenBienRanDom.Next(35, 49);
                                    var sogiay = TenBienRanDom.Next(1, 59);
                                    string ngaycham = DateTime.Parse(r.Cells["NgayCham"].Value.ToString()).ToString("yyyy/MM/dd") + " 07:" + sophut + ":" + sogiay.ToString().PadLeft(2, '0');
                                    sql = $"Update MITACOSQL.dbo.CheckInOut set GioCham = '{ngaycham}' " +
                                        $"Where ID = '{r.Cells["Id"].Value.ToString()}'";
                                }
                                else if (TimeSpan.Parse(r.Cells["GioCham"].Value.ToString()) > TimeSpan.Parse("16:45:00"))
                                {
                                    Random TenBienRanDom = new Random();
                                    var sophut = TenBienRanDom.Next(30, 44);
                                    var sogiay = TenBienRanDom.Next(1, 59);
                                    string ngaycham = DateTime.Parse(r.Cells["NgayCham"].Value.ToString()).ToString("yyyy/MM/dd") + " 16:" + sophut + ":" + sogiay.ToString().PadLeft(2, '0');
                                    sql = $"Update MITACOSQL.dbo.CheckInOut set GioCham = '{ngaycham}' " +
                                        $"Where ID = '{r.Cells["Id"].Value.ToString()}'";
                                }
                                break;
                            case "CA1":
                                if (TimeSpan.Parse(r.Cells["GioCham"].Value.ToString()) < TimeSpan.Parse("05:45:00"))
                                {
                                    Random TenBienRanDom1 = new Random();
                                    var sophut1 = TenBienRanDom1.Next(46, 59);
                                    var sogiay1 = TenBienRanDom1.Next(1, 59);
                                    string ngaycham = DateTime.Parse(r.Cells["NgayCham"].Value.ToString()).ToString("yyyy/MM/dd") + " 05:" + sophut1 + ":" + sogiay1.ToString().PadLeft(2, '0');
                                    sql = $"UpdateMITACOSQL.dbo. CheckInOut set GioCham = '{ngaycham}' " +
                                        $"Where ID = '{r.Cells["Id"].Value.ToString()}'";
                                }
                                else if (TimeSpan.Parse(r.Cells["GioCham"].Value.ToString()) > TimeSpan.Parse("14:15:00"))
                                {
                                    Random TenBienRanDom1 = new Random();
                                    var sophut1 = TenBienRanDom1.Next(1, 14);
                                    var sogiay1 = TenBienRanDom1.Next(1, 59);
                                    string ngaycham = DateTime.Parse(r.Cells["NgayCham"].Value.ToString()).ToString("yyyy/MM/dd") + " 14:" + sophut1 + ":" + sogiay1.ToString().PadLeft(2, '0');
                                    sql = $"Update MITACOSQL.dbo.CheckInOut set GioCham = '{ngaycham}' " +
                                        $"Where ID = '{r.Cells["Id"].Value.ToString()}'";
                                }
                                break;
                            case "CA2":
                                if (TimeSpan.Parse(r.Cells["GioCham"].Value.ToString()) < TimeSpan.Parse("13:45:00"))
                                {
                                    Random TenBienRanDom2 = new Random();
                                    var sophut2 = TenBienRanDom2.Next(45, 59);
                                    var sogiay2 = TenBienRanDom2.Next(1, 59);
                                    string ngaycham = DateTime.Parse(r.Cells["NgayCham"].Value.ToString()).ToString("yyyy/MM/dd") + " 13:" + sophut2 + ":" + sogiay2.ToString().PadLeft(2, '0');
                                    sql = $"Update MITACOSQL.dbo.CheckInOut set GioCham = '{ngaycham}' " +
                                        $"Where ID = '{r.Cells["Id"].Value.ToString()}'";
                                }
                                else if (TimeSpan.Parse(r.Cells["GioCham"].Value.ToString()) > TimeSpan.Parse("22:15:00"))
                                {
                                    Random TenBienRanDom2 = new Random();
                                    var sophut2 = TenBienRanDom2.Next(1, 15);
                                    var sogiay2 = TenBienRanDom2.Next(1, 59);
                                    string ngaycham = DateTime.Parse(r.Cells["NgayCham"].Value.ToString()).ToString("yyyy/MM/dd") + " 22:" + sophut2 + ":" + sogiay2.ToString().PadLeft(2, '0');
                                    sql = $"Update MITACOSQL.dbo.CheckInOut set GioCham = '{ngaycham}' " +
                                        $"Where ID = '{r.Cells["Id"].Value.ToString()}'";
                                }
                                break;
                            case "CA3":
                                if (TimeSpan.Parse(r.Cells["GioCham"].Value.ToString()) < TimeSpan.Parse("21:45:00") &&
                                    TimeSpan.Parse(r.Cells["GioCham"].Value.ToString()) > TimeSpan.Parse("20:45:00"))
                                {
                                    Random TenBienRanDom3 = new Random();
                                    var sophut3 = TenBienRanDom3.Next(45, 59);
                                    var sogiay3 = TenBienRanDom3.Next(1, 59);
                                    string ngaycham = DateTime.Parse(r.Cells["NgayCham"].Value.ToString()).ToString("yyyy/MM/dd") + " 21:" + sophut3 + ":" + sogiay3.ToString().PadLeft(2, '0');
                                    sql = $"Update MITACOSQL.dbo.CheckInOut set GioCham = '{ngaycham}' " +
                                        $"Where ID = '{r.Cells["Id"].Value.ToString()}'";
                                }
                                else if (TimeSpan.Parse(r.Cells["GioCham"].Value.ToString()) > TimeSpan.Parse("06:15:00") &&
                                         TimeSpan.Parse(r.Cells["GioCham"].Value.ToString()) < TimeSpan.Parse("08:00:00"))
                                {
                                    Random TenBienRanDom3 = new Random();
                                    var sophut3 = TenBienRanDom3.Next(1, 15);
                                    var sogiay3 = TenBienRanDom3.Next(1, 59);
                                    string ngaycham = DateTime.Parse(r.Cells["NgayCham"].Value.ToString()).ToString("yyyy/MM/dd") + " 06:" + sophut3 + ":" + sogiay3.ToString().PadLeft(2, '0');
                                    sql = $"Update MITACOSQL.dbo.CheckInOut set GioCham = '{ngaycham}' " +
                                        $"Where ID = '{r.Cells["Id"].Value.ToString()}'";
                                }
                                break;
                            default:
                                break;
                        }

                        bool check = DataProvider.add_CheckInOut_Backup(int.Parse(r.Cells["MaChamCong"].Value.ToString()), r.Cells["NgayCham"].Value.ToString());
                        if (check == true)
                        {
                            SQLHelper.ExecuteSql(sql);
                        }
                        else
                        {
                            RJMessageBox.Show("Sao lưu dữ liệu thất bại " + Environment.NewLine + " vui lòng liên hệ IT", "Thông báo");
                            break;
                        }
                    }
                    catch (Exception ex)
                    {
                        throw new Exception(ex.Message);
                    }
                }
                RJMessageBox.Show("Cập nhật thành công");
            }
            catch (Exception ex)
            {
                RJMessageBox.Show(ex.Message, "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            Cursor.Current = Cursors.WaitCursor;
        }
        private void LoadData()
        {
            string sql = $"DB_MITACOSQL.dbo.proc_DanhSachDiSom {cbo_Nam.SelectedValue}, {cbo_Thang.SelectedValue}";
            DataTable data = SQLHelper.ExecuteDt(sql);
            dgv_Data.DataSource = data;
        }
        private void frm_ChinhVaoSomRaMuon_Load(object sender, EventArgs e)
        {
            BindGrid();
        }
        private void LoadThang()
        {
            DataTable dt = new DataTable();
            dt.Columns.Add("Id");
            dt.Columns.Add("Name");
            for (int i = 1; i <= 12; i++)
            {
                dt.Rows.Add(i, i);
            }
            cbo_Thang.DataSource = dt;
            cbo_Thang.DisplayMember = "Name";
            cbo_Thang.ValueMember = "Id";
            cbo_Thang.SelectedValue = DateTime.Now.Month;
        }

        private void LoadNam()
        {
            DataTable dt = new DataTable();
            dt.Columns.Add("Id");
            dt.Columns.Add("Name");
            for (int i = DateTime.Now.Year - 4; i <= DateTime.Now.Year + 4; i++)
            {
                dt.Rows.Add(i, i);
            }
            cbo_Nam.DataSource = dt;
            cbo_Nam.DisplayMember = "Name";
            cbo_Nam.ValueMember = "Id";
            cbo_Nam.SelectedValue = DateTime.Now.Year;
        }

        private void dgv_Data_RowPostPaint(object sender, DataGridViewRowPostPaintEventArgs e)
        {
            var grid = sender as DataGridView;
            var rowIdx = (e.RowIndex + 1).ToString();
            var centerFormat = new StringFormat
            {
                Alignment = StringAlignment.Center,
                LineAlignment = StringAlignment.Center
            };
            var textSize = TextRenderer.MeasureText(rowIdx, Font);
            if (grid.RowHeadersWidth < textSize.Width + 10)
            {
                grid.RowHeadersWidth = textSize.Width + 10;
            }
            var headerBounds =
                new Rectangle(e.RowBounds.Left, e.RowBounds.Top, grid.RowHeadersWidth, e.RowBounds.Height);
            e.Graphics.DrawString(rowIdx, Font, SystemBrushes.ControlText, headerBounds, centerFormat);
        }
    }
}
