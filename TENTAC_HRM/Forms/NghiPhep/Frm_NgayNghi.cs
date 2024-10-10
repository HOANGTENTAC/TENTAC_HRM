using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using TENTAC_HRM.Common;
using TENTAC_HRM.Custom;

namespace TENTAC_HRM.Forms.NghiPhep
{
    public partial class Frm_NgayNghi : Form
    {
        public Frm_NgayNghi()
        {
            InitializeComponent();
        }
        private void Frm_NgayNghi_Load(object sender, EventArgs e)
        {
            List<int> dtyear = new List<int>();
            for (int i = 2016; i <= DateTime.Now.Year + 2; i++)
            {
                dtyear.Add(i);
            }
            cbo_year.DataSource = dtyear;
            cbo_year.Text = DateTime.Now.Year.ToString();

            Load_lichnghi();
        }
        private void cbo_year_SelectionChangeCommitted(object sender, EventArgs e)
        {
            Load_lichnghi();
        }
        private void Load_lichnghi()
        {
            DataTable dt = new DataTable();
            string sql = $"select Nam,Thang,D1,D2,D3,D4,D5,D6,D7,D8,D9,D10," +
                $"D11,D12,D13,D14,D15,D16,D17,D18,D19,D20," +
                $"D21,D22,D23,D24,D25,D26,D27,D28,D29,D30,D31 " +
                $"from tbl_NgayNghi where Nam = {cbo_year.SelectedValue.ToString()} ";
            DataTable dataTable = new DataTable();
            dataTable = SQLHelper.ExecuteDt(sql);

            dt.Columns.Add("Nam", typeof(int));
            dt.Columns.Add("Thang", typeof(int));
            dt.Columns.Add("D1", typeof(bool));
            dt.Columns.Add("D2", typeof(bool));
            dt.Columns.Add("D3", typeof(bool));
            dt.Columns.Add("D4", typeof(bool));
            dt.Columns.Add("D5", typeof(bool));
            dt.Columns.Add("D6", typeof(bool));
            dt.Columns.Add("D7", typeof(bool));
            dt.Columns.Add("D8", typeof(bool));
            dt.Columns.Add("D9", typeof(bool));
            dt.Columns.Add("D10", typeof(bool));
            dt.Columns.Add("D11", typeof(bool));
            dt.Columns.Add("D12", typeof(bool));
            dt.Columns.Add("D13", typeof(bool));
            dt.Columns.Add("D14", typeof(bool));
            dt.Columns.Add("D15", typeof(bool));
            dt.Columns.Add("D16", typeof(bool));
            dt.Columns.Add("D17", typeof(bool));
            dt.Columns.Add("D18", typeof(bool));
            dt.Columns.Add("D19", typeof(bool));
            dt.Columns.Add("D20", typeof(bool));
            dt.Columns.Add("D21", typeof(bool));
            dt.Columns.Add("D22", typeof(bool));
            dt.Columns.Add("D23", typeof(bool));
            dt.Columns.Add("D24", typeof(bool));
            dt.Columns.Add("D25", typeof(bool));
            dt.Columns.Add("D26", typeof(bool));
            dt.Columns.Add("D27", typeof(bool));
            dt.Columns.Add("D28", typeof(bool));
            dt.Columns.Add("D29", typeof(bool));
            dt.Columns.Add("D30", typeof(bool));
            dt.Columns.Add("D31", typeof(bool));
            for (int i = 1; i <= 12; i++)
            {
                var d = dataTable.Rows.Cast<DataRow>().Where(x => x.Field<int>("Thang") == i).ToList();
                if (d.Count == 0)
                {
                    dt.Rows.Add(int.Parse(cbo_year.SelectedValue.ToString()), i, false, false, false, false, false, false, false, false, false, false
                    , false, false, false, false, false, false, false, false, false, false
                    , false, false, false, false, false, false, false, false, false, false, false);
                }
            }
            DataTable dt_all = new DataTable();
            dt_all = dataTable.Copy();
            dt_all.Merge(dt);
            dgv_lichnghi.DataSource = dt_all.Rows.Cast<DataRow>().OrderBy(x => x.Field<int>("Thang")).CopyToDataTable();
        }

        private void dgv_lichnghi_RowPostPaint(object sender, DataGridViewRowPostPaintEventArgs e)
        {
            var grid = sender as DataGridView;
            var rowIdx = "Tháng " + (e.RowIndex + 1).ToString();
            var centerFormat = new StringFormat
            {
                Alignment = StringAlignment.Center,
                LineAlignment = StringAlignment.Center
            };
            var textSize = TextRenderer.MeasureText(rowIdx, Font);
            if (grid.RowHeadersWidth < textSize.Width + 20)
            {
                grid.RowHeadersWidth = textSize.Width + 20;
            }
            var headerBounds =
                new Rectangle(e.RowBounds.Left, e.RowBounds.Top, grid.RowHeadersWidth, e.RowBounds.Height);
            e.Graphics.DrawString(rowIdx, Font, SystemBrushes.ControlText, headerBounds, centerFormat);
        }

        private void dgv_lichnghi_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            int days = DateTime.DaysInMonth(int.Parse(cbo_year.SelectedValue.ToString()), e.RowIndex + 1);
            if (e.ColumnIndex - 1 <= days)
            {
                DateTime date = new DateTime(int.Parse(cbo_year.SelectedValue.ToString()), e.RowIndex + 1, e.ColumnIndex - 1);
                if (date.DayOfWeek == DayOfWeek.Sunday && e.ColumnIndex - 1 <= days)
                {
                    e.CellStyle.BackColor = Color.SandyBrown;
                }
            }
            else
            {
                dgv_lichnghi.Rows[e.RowIndex].Cells[e.ColumnIndex].ReadOnly = true;
                e.CellStyle.BackColor = Color.Silver;
            }
        }

        private void btn_update_Click(object sender, EventArgs e)
        {
            SqlConnection cn = new SqlConnection(SQLHelper.GetSqlConnection());
            cn.Open();
            SqlTransaction tr = cn.BeginTransaction();
            try
            {
                string sql = $"Delete from tbl_NgayNghi where nam = '{cbo_year.SelectedValue}' ";
                SqlCommand sqlCommand = new SqlCommand()
                {
                    Transaction = tr,
                    Connection = cn,
                    CommandText = sql
                };
                sqlCommand.ExecuteNonQuery();

                foreach (DataGridViewRow item in dgv_lichnghi.Rows)
                {
                    string sql_insert = $"insert into tbl_NgayNghi " +
                                        $"values('{cbo_year.SelectedValue}','{item.Cells["Thang"].Value}'," +
                                        $"'{item.Cells["D1"].Value}','{item.Cells["D2"].Value}','{item.Cells["D3"].Value}','{item.Cells["D4"].Value}','{item.Cells["D5"].Value}'" +
                                        $",'{item.Cells["D6"].Value}','{item.Cells["D7"].Value}','{item.Cells["D8"].Value}','{item.Cells["D9"].Value}','{item.Cells["D10"].Value}'" +
                                        $",'{item.Cells["D11"].Value}','{item.Cells["D12"].Value}','{item.Cells["D13"].Value}','{item.Cells["D14"].Value}','{item.Cells["D15"].Value}'" +
                                        $",'{item.Cells["D16"].Value}','{item.Cells["D17"].Value}','{item.Cells["D18"].Value}','{item.Cells["D19"].Value}','{item.Cells["D20"].Value}'" +
                                        $",'{item.Cells["D21"].Value}','{item.Cells["D22"].Value}','{item.Cells["D23"].Value}','{item.Cells["D24"].Value}','{item.Cells["D25"].Value}'" +
                                        $",'{item.Cells["D26"].Value}','{item.Cells["D27"].Value}','{item.Cells["D28"].Value}','{item.Cells["D29"].Value}','{item.Cells["D30"].Value}'" +
                                        $",'{item.Cells["D31"].Value}') ";

                    sqlCommand.CommandText = sql_insert;
                    sqlCommand.ExecuteNonQuery();

                    string sql_bangxepca = $"Select * from tbl_BangXepCa Where Thang = '{item.Cells["Thang"].Value}' and Nam = '{cbo_year.SelectedValue}'";
                    DataTable dt_bangsepca = new DataTable();
                    dt_bangsepca = SQLHelper.ExecuteDt_tr(sql_bangxepca, tr, cn);
                    if (dt_bangsepca.Rows.Count > 0)
                    {
                        foreach (DataRow row in dt_bangsepca.Rows)
                        {
                            string sql_update = $"Update tbl_BangXepCa set ";
                            for (int i = 1; i <= 31; i++)
                            {
                                if (i == 31)
                                {
                                    sql_update += $"D31" + $" = '{(item.Cells["D31"].Value.ToString() == "True" ? (row["D31"].ToString() != "HC" ? row["D31"].ToString() : "") : (!string.IsNullOrEmpty(row["D31"].ToString()) ? row["D31"].ToString() : "HC"))}'";
                                }
                                else
                                {
                                    sql_update += $"D" + i + $" = '{(item.Cells["D" + i].Value.ToString() == "True" ? (row["D" + i].ToString() != "HC" ? row["D" + i].ToString() : "") : (!string.IsNullOrEmpty(row["D" + i].ToString()) ? row["D" + i].ToString() : "HC"))}',";
                                }
                            }
                            sql_update += $" where id = {row["id"].ToString()}";
                            sqlCommand.CommandText = sql_update;
                            sqlCommand.ExecuteNonQuery();
                        }
                    }
                }
                RJMessageBox.Show($"Đã lưu dữ liệu thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                tr.Commit();
                //Provider.WriteToFile(System.Environment.MachineName + ",Delete," + DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"));
            }
            catch (Exception ex)
            {
                tr.Rollback();
                RJMessageBox.Show(ex.Message, "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
