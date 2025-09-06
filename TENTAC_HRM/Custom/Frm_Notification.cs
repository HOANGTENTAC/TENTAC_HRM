using Microsoft.AspNet.SignalR.Client;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net.Http;
using System.Windows.Forms;
using TENTAC_HRM.Consts;
using TENTAC_HRM.Forms.Main;
using TENTAC_HRM.Forms.NghiPhep;

namespace TENTAC_HRM.Custom
{
    public partial class Frm_Notification : Form
    {
        List<DangKyNghiPhep> lsData = new List<DangKyNghiPhep>();
        private IHubProxy HubProxy { get; set; }
        const string ServerURI = "http://localhost:8080/signalr";
        private HubConnection Connection { get; set; }

        int toastX, toastY;
        public Frm_Notification()
        {
            LoginInfo.UserCd = "OF1028";
            InitializeComponent();
            frm_login frm = new frm_login();
            frm.Show();
        }
        private async void ConnectAsync()
        {
            Connection = new HubConnection(ServerURI);
            Connection.Closed += Connection_Closed;
            HubProxy = Connection.CreateHubProxy("MyHub");
            HubProxy.On<string>("DisplayData", (json) =>
                this.Invoke((Action)(() =>
                    SetDataGridView(json)
                ))
            );
            try
            {
                await Connection.Start();
            }
            catch (HttpRequestException)
            {
                //StatusText.Text = "Unable to connect to server: Start server before connecting clients.";
                return;
            }
        }
        public void SetDataGridView(string json)
        {
            var ls = JsonConvert.DeserializeObject<List<DangKyNghiPhep>>(json)
                    .Where(x => x.ReportTo == LoginInfo.UserCd).ToList();
            if (ls.Count != lsData.Count)
            {

            }
            //this.myDataGridView.DataSource = ls;
        }
        private void Connection_Closed()
        {
            //Deactivate chat UI; show login UI. 
            //this.Invoke((Action)(() => ButtonSave.Enabled = false));
            //this.Invoke((Action)(() => StatusText.Text = "You have been disconnected."));
        }
        private void dataGridViewX1_RowPostPaint(object sender, DataGridViewRowPostPaintEventArgs e)
        {
            DataProvider.NumberRowDataGridView(sender, e);
        }

        private void buttonX1_Click(object sender, System.EventArgs e)
        {
            this.Close();
        }

        private void Frm_Notification_Load(object sender, System.EventArgs e)
        {
            Position();
            //StatusText.Visible = true;
            //StatusText.Text = "Connecting to server...";
            ConnectAsync();
        }
        private void LoadData()
        {
            string sql = $@"select a.Id,b.MaNhanVien,b.TenNhanVien, a.NgayNghi, b.GhiChu, c.TenPhongBan,a.Id_TrangThai,d.ReportTo
                            from tbl_NghiPhepNam a 
                            join MITACOSQL.dbo.NHANVIEN b on a.MaNhanVien = b.MaNhanVien
                            left join MITACOSQL.dbo.PHONGBAN c on b.MaPhongBan = c.MaPhongBan
                            join tbl_NhanVien d on d.MaNhanVien = b.MaNhanVien
                            where Month(a.NgayNghi) = {DateTime.Now.ToString("MM")} and YEAR(NgayNghi) = {DateTime.Now.ToString("yyyy")} and d.ReportTo = '{LoginInfo.UserCd}'";
            DataTable dt = SQLHelper.ExecuteDt(sql);
            lsData = dt.AsEnumerable().Select(row => new DangKyNghiPhep
            {
                Id = row.Field<int>("Id"),
                MaNhanVien = row.Field<string>("MaNhanVien"),
                TenNhanVien = row.Field<string>("TenNhanVien"),
                NgayNghi = row.Field<DateTime>("NgayNghi"),
                LyDo = row.Field<string>("GhiChu"),
                TenPhongBan = row.Field<string>("TenPhongBan"),
                Id_TrangThai = row.Field<int>("Id_TrangThai"),
                ReportTo = row.Field<string>("ReportTo")
            }).ToList();
            dgv_Data.DataSource = lsData;
        }
        private void dgv_Data_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dgv_Data.CurrentCell.OwningColumn.Name == "Show")
            {
                using (frm_QuanLyXacNhan frm = new frm_QuanLyXacNhan())
                {
                    frm._id = int.Parse(dgv_Data.CurrentRow.Cells["Id"].Value.ToString());
                    frm._year = DateTime.Parse(dgv_Data.CurrentRow.Cells["NgayNghi"].Value.ToString()).ToString("yyyy");
                    frm.ShowDialog();
                }
            }
        }

        private void btn_ShoAll_Click(object sender, EventArgs e)
        {
            Frm_NghiPhep frm = new Frm_NghiPhep
            {
                Year = DateTime.Now.ToString("yyyy"),
                Month = DateTime.Now.ToString("MM"),
            };
            frm.Show();
            //Frm_NghiPhep user = new Frm_NghiPhep
            //{
            //    Manhanvien = dgv_Data.CurrentRow.Cells["MaNhanVien"].Value.ToString(),
            //    Year = DateTime.Parse(dgv_Data.CurrentRow.Cells["NgayNghi"].Value.ToString()).ToString("yyyy"),
            //    Month = DateTime.Parse(dgv_Data.CurrentRow.Cells["NgayNghi"].Value.ToString()).ToString("MM"),
            //    Trangthai = dgv_Data.CurrentRow.Cells["Id_TrangThai"].Value.ToString()
            //};
            //user.ShowDialog();
        }

        private void Position()
        {
            int screenWidth = Screen.PrimaryScreen.WorkingArea.Width;
            int screenHeight = Screen.PrimaryScreen.WorkingArea.Height;

            toastX = screenWidth - this.Width;
            toastY = screenHeight - this.Height;
            this.Location = new Point(toastX, toastY);
        }
    }
    public class DangKyNghiPhep
    {
        public int Id { get; set; }
        public string MaNhanVien { get; set; }
        public string TenNhanVien { get; set; }
        public DateTime NgayNghi { get; set; }
        public string LyDo { get; set; }
        public string TenPhongBan { get; set; }
        public int Id_TrangThai { get; set; }
        public string ReportTo { get; set; }
    }
}
