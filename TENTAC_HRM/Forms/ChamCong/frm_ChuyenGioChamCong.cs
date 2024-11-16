using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using TENTAC_HRM.Custom;

namespace TENTAC_HRM.Forms.ChamCong
{
    public partial class frm_ChuyenGioChamCong : Form
    {
        CheckBox headerCheckBox = new CheckBox();
        public frm_ChuyenGioChamCong()
        {
            InitializeComponent();
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
        private void btn_DeleteAll_Click(object sender, EventArgs e)
        {
            var diag = RJMessageBox.Show($"Bạn có chắc muốn xóa giờ chấm công của các nhân viên đang chọn không?", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
            if (diag == DialogResult.Yes)
            {
                try
                {
                    var checkedRows = from DataGridViewRow r in dgv_Data.Rows
                                      where Convert.ToBoolean(r.Cells[0].Value) == true
                                      select r;
                    if (checkedRows.Count() > 0)
                    {
                        foreach (DataGridViewRow item in checkedRows)
                        {
                            string sql = $"delete [MITACOSQL].[dbo].[ChuyenGioChamCong] where ID = '{item.Cells["ID"].Value}' ";
                            SQLHelper.ExecuteSql(sql);
                        }
                    }
                    else
                    {
                        RJMessageBox.Show("Chưa có giờ chấm công nào được chọn", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
                }
                catch (Exception)
                {

                    throw;
                }
            }
        }

        private void btn_Search_Click(object sender, EventArgs e)
        {
            LoadData();
        }
        public void LoadData()
        {
            string sql = "SELECT a.Id,b.MaNhanVien,b.TenNhanVien,a.NgayCham,a.GioCham,c.TenPhongBan " +
                         "FROM [MITACOSQL].[dbo].[ChuyenGioChamCong] a " +
                         "join [MITACOSQL].[dbo].NHANVIEN b on a.MaChamCong = b.MaChamCong " +
                         "join [MITACOSQL].[dbo].PHONGBAN c on b.MaPhongBan = c.MaPhongBan " +
                         $"where YEAR(a.NgayCham) = {cbo_Nam.SelectedValue} and MONTH(a.NgayCham) = {cbo_Thang.Text}";
            if (!string.IsNullOrEmpty(txt_Search.Text))
            {
                sql += $" And (b.MaNhanVien like '%{txt_Search.Text}%' or b.TenNhanVien like '%{txt_Search.Text}%')";
            }
            DataTable dt = new DataTable();
            dt = SQLHelper.ExecuteDt(sql);
            dgv_Data.DataSource = dt;
        }
        private void frm_ChuyenGioChamCong_Load(object sender, EventArgs e)
        {
            List<int> dtyear = new List<int>();
            for (int i = 2016; i <= DateTime.Now.Year + 2; i++)
            {
                dtyear.Add(i);
            }
            cbo_Nam.DataSource = dtyear;
            cbo_Nam.Text = DateTime.Now.Year.ToString();
            cbo_Thang.Text = DateTime.Now.Month.ToString();

            BindGrid();
        }

        private void txt_Search_TextChanged(object sender, EventArgs e)
        {
            LoadData();
        }

        private void dgv_Data_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dgv_Data.CurrentCell.OwningColumn.Name == "delete_col")
            {
                try
                {
                    string sql = $"delete [MITACOSQL].[dbo].[ChuyenGioChamCong] where id = '{dgv_Data.CurrentRow.Cells["Id"].Value.ToString()}'";
                    SQLHelper.ExecuteSql(sql);
                    RJMessageBox.Show("Xóa thành công");
                }
                catch (Exception ex)
                {
                    RJMessageBox.Show(ex.Message, "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }
    }
}
