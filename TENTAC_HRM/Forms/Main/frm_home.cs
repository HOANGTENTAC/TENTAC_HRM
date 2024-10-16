using System;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using TENTAC_HRM.Properties;
using TENTAC_HRM.Forms.User_control;

namespace TENTAC_HRM.Forms.Main
{
    public partial class frm_home : Form
    {
        bool notifi_hide = false;
        Label lb_menu;
        Panel panel = new Panel();
        Point _imageLocation = new Point(20, 4);
        Point _imgHitArea = new Point(20, 4);

        private bool isCollapsed = false;
        bool _btn_nhansu = false;
        bool _btn_maychamcong = false;
        bool _btn_luong = false;
        bool _btn_quatrinh = false;
        bool _btn_chamcong = false;
        bool _btn_bangxepca = false;
        bool _btn_sodo_chucnang = false;
        bool _btn_setting = false;
        bool _btn_show_menu_left = false;
        bool _btn_category = false;
        bool isPresent = false;
        DataTable dt_MenuParent = new DataTable();
        public frm_home()
        {
            InitializeComponent();
            MaximizeWindow();
            load_menu();
        }
        private void load_menu()
        {
            splitContainer1.Panel2.Controls.Clear();
            string sql = "select a.*,b.FrmType,b.FrmText " +
                         "from mst_Menu a " +
                         "left join mst_from b on a.FromName = b.FrmName " +
                         "where a.ParentId = 0 order by a.MenuNumber desc";
            dt_MenuParent = SQLHelper.ExecuteDt(sql);
            foreach (DataRow item in dt_MenuParent.Rows)
            {
                Custom.RJButton danhmuc = new Custom.RJButton
                {
                    Name = item["MenuName"].ToString(),
                    Text = "",
                    Tag = item["Id"].ToString(),
                    BackGroundColor = Color.CornflowerBlue,
                    BackColor = Color.CornflowerBlue,
                    BorderColor = Color.LightSkyBlue,
                    Dock = DockStyle.Top,
                    FlatStyle = FlatStyle.Flat,
                    Image = (Bitmap)Resources.ResourceManager.GetObject(item["MenuImage"].ToString()),
                    ImageAlign = ContentAlignment.MiddleLeft,
                    TextAlign = ContentAlignment.MiddleCenter,
                    TextImageRelation = TextImageRelation.ImageBeforeText,
                    BorderSize = 1,
                    UseVisualStyleBackColor = false,
                    BorderRadius = 0,
                    Font = new Font(Font.FontFamily, emSize: 10f, FontStyle.Bold, unit: GraphicsUnit.Point),
                    Height = 55,
                };
                danhmuc.Click += btn_Menu_Click;
                splitContainer1.Panel2.Controls.Add(danhmuc);
            }
        }
        DataTable dt_Menu_child = new DataTable();
        string btn_IdClick;
        private void btn_Menu_Click(object sender, EventArgs e)
        {
            btn_IdClick = ((Custom.RJButton)sender).Tag.ToString();
            var name_parent = dt_MenuParent.Rows.Cast<DataRow>().Where(x => x["Id"].ToString() == btn_IdClick).FirstOrDefault();

            if (_btn_show_menu_left == true)
            {
                if (name_parent != null)
                    lbl_title_menu.Text = name_parent["MenuText"].ToString();
            }
            else
            {
                lbl_title_menu.Text = "";
            }
            if (!string.IsNullOrEmpty(name_parent["FromName"].ToString()))
            {
                Open_From(sender, e, true);
            }
            else
            {
                splitContainer1.Panel1.Controls.Clear();
                string sql = $"select a.*,b.FrmType,b.FrmText " +
                             $"from mst_menu a " +
                             "left join mst_from b on a.FromName = b.FrmName " +
                             $"where ParentId = '{((Custom.RJButton)sender).Tag}' order by a.MenuNumber desc";
                dt_Menu_child = SQLHelper.ExecuteDt(sql);
                foreach (DataRow item in dt_Menu_child.Rows)
                {
                    Custom.RJButton bt = new Custom.RJButton
                    {
                        BorderColor = Color.LightSkyBlue,
                        BorderRadius = 0,
                        BorderSize = 1,
                        UseVisualStyleBackColor = false,
                        BackColor = SystemColors.Window,
                        TextColor = Color.Black,
                        FlatStyle = FlatStyle.Flat,
                        TextAlign = ContentAlignment.MiddleLeft,
                        Dock = DockStyle.Top,
                        Size = new Size(201, 45),
                        Name = item["MenuName"].ToString(),
                        Text = _btn_show_menu_left == true ? item["MenuText"].ToString() : "",
                        Tag = item["Id"].ToString(),
                        //dantoc.Click += btn_dantoc_Click;
                        Image = (Bitmap)Resources.ResourceManager.GetObject(item["MenuImage"].ToString()),
                        ImageAlign = ContentAlignment.MiddleLeft,
                        TextImageRelation = TextImageRelation.ImageBeforeText,

                    };
                    bt.Click += Bt_Click;
                    ToolTip ToolTip1 = new ToolTip();
                    ToolTip1.SetToolTip(bt, item["MenuText"].ToString());
                    splitContainer1.Panel1.Controls.Add(bt);
                }
            }

        }

        private void Bt_Click(object sender, EventArgs e)
        {
            Open_From(sender, e, false);
        }

        private void Open_From(object sender, EventArgs e, bool parent)
        {
            btn_IdClick = ((Custom.RJButton)sender).Tag.ToString();
            var name_parent = dt_MenuParent.Rows.Cast<DataRow>().Where(x => x["Id"].ToString() == btn_IdClick).FirstOrDefault();
            if (parent == false)
            {
                name_parent = dt_Menu_child.Rows.Cast<DataRow>().Where(x => x["Id"].ToString() == btn_IdClick).FirstOrDefault();
            }
            if (name_parent != null)
            {
                if (name_parent["FrmType"].ToString() == "uc")
                {
                    isPresent = false;
                    string text_tab = name_parent["FrmText"].ToString();
                    UserControl user = new UserControl();
                    //user = uc_nhan_su.Instance;

                    user = Activator.CreateInstance(Type.GetType("TENTAC_HRM.Forms." + name_parent["MenuCode"].ToString() + name_parent["FromName"].ToString())) as UserControl;

                    for (int i = 0; i < tb_main.TabPages.Count; i++)
                    {
                        if (tb_main.TabPages[i].Name == "tp_" + name_parent["FromName"])
                        {
                            isPresent = true;
                            tb_main.SelectedTab = tb_main.TabPages["tp_" + name_parent["FromName"]];
                            break;
                        }
                    }

                    if (isPresent == false)
                    {
                        TabPage tp = new TabPage(text_tab);
                        tp.Name = "tp_" + name_parent["FromName"];
                        Panel tb = new Panel();
                        tb.Dock = DockStyle.Fill;
                        tb.Name = "pl_" + name_parent["FromName"];

                        tb_main.TabPages.Add(tp);
                        tb_main.SelectedTab = tp;
                        tp.Controls.Add(tb);

                        if (!tb.Controls.Contains(user))
                        {
                            tb.Controls.Add(user);
                            user.Dock = DockStyle.Fill;
                            user.BringToFront();
                        }
                        else
                        {
                            user.BringToFront();
                        }
                    }
                }
                else
                {
                    var form = Activator.CreateInstance(Type.GetType("TENTAC_HRM.Forms." + name_parent["MenuCode"].ToString() + name_parent["FromName"].ToString())) as Form;
                    form.ShowDialog();
                }
            }
        }
        bool maximized = false;
        private void MaximizeWindow()
        {
            maximized = true;
            var rectangle = Screen.FromControl(this).Bounds;
            Size = new Size(rectangle.Width, rectangle.Height);
            Location = new Point(0, 0);
            Rectangle workingRectangle = Screen.PrimaryScreen.WorkingArea;
            this.Size = new Size(workingRectangle.Width, workingRectangle.Height);
            //splitContainer1.Panel1MinSize = splitContainer1.Size.Height - 755;
            //splitContainer1.Panel2MinSize = splitContainer1.Size.Height - (splitContainer1.Size.Height - 740);
        }
        private void ResizableWindow()
        {
            this.ControlBox = false;
            this.FormBorderStyle = FormBorderStyle.SizableToolWindow;
        }

        public void remove_tabpage()
        {
            tb_main.TabPages.RemoveByKey("tp_nhansu");
        }

        private void frm_home_Load(object sender, EventArgs e)
        {
            ts_user.Text = SQLHelper.sUser;
            pl_sn.Height = 0;
            pl_nv_moi.Height = 0;
            pl_hopdong.Height = 0;
            load_sinhnhat();
            load_ngayhet_hopdong();
            load_nv_moi();

            tb_main.Padding = new Point(20, 4);

            pl_menu_left.MaximumSize = new Size(203, this.Height);
            pl_menu_left.MinimumSize = new Size(63, this.Height);
            if (!tb_dashboard.Controls.Contains(uc_dashboard.Instance))
            {
                tb_dashboard.Controls.Add(uc_dashboard.Instance);
                uc_dashboard.Instance.Dock = DockStyle.Fill;
                uc_dashboard.Instance.BringToFront();
            }
            else
            {
                uc_dashboard.Instance.BringToFront();
            }
        }
        private void load_nv_moi()
        {
            string sql = "select manhanvien,TenNhanVien,ngayvaolamviec from MITACOSQL.dbo.NHANVIEN where datediff(day,ngayvaolamviec,GETDATE()) <= 10";
            DataTable dt = new DataTable();
            dt = SQLHelper.ExecuteDt(sql);
            if (dt.Rows.Count > 0)
            {
                pl_nv_moi.Visible = true;
                foreach (DataRow item in dt.Rows)
                {
                    ListViewItem item2 = new ListViewItem(item["manhanvien"].ToString());
                    item2.SubItems.Add(item["TenNhanVien"].ToString());
                    item2.SubItems.Add(DateTime.Parse(item["ngayvaolamviec"].ToString()).ToString("yyyy/MM/dd"));

                    lv_nv_moi.Items.Add(item2);
                }
            }
            else
            {
                pl_nv_moi.Visible = false;
            }

            lb_title_nv_moi.Text = "Có (" + dt.Rows.Count + ") nhân viên mới";
        }

        private void load_sinhnhat()
        {
            string sql = "select MaNhanVien,TenNhanVien,NgaySinh from MITACOSQL.dbo.NHANVIEN where MONTH(NgaySinh) = MONTH(GETDATE())";
            DataTable dt = new DataTable();
            dt = SQLHelper.ExecuteDt(sql);
            if (dt.Rows.Count > 0)
            {
                pl_sn.Visible = true;
                foreach (DataRow item in dt.Rows)
                {
                    ListViewItem item2 = new ListViewItem(item["MaNhanVien"].ToString());
                    item2.SubItems.Add(item["TenNhanVien"].ToString());
                    item2.SubItems.Add(DateTime.Parse(item["NgaySinh"].ToString()).ToString("yyyy/MM/dd"));

                    lv_sinhnhat.Items.Add(item2);
                }
            }
            else
            {
                pl_sn.Visible = false;
            }

            lb_title_notifi.Text = "Có (" + dt.Rows.Count + ") nhân viên có sinh nhật trong tháng";
        }
        private void load_ngayhet_hopdong()
        {
            string sql = "select nhanvien.MaNhanVien,nhanvien.TenNhanVien,a.denngay as ngay_het_han from MITACOSQL.dbo.NHANVIEN nhanvien " +
                "left join [tbl_NhanVienHopDong] a on a.manhanvien = nhanvien.MaNhanVien " +
                "join mst_LoaiHopDong b on a.id_loaihopdong = b.id and b.id in (2,3) " +
                "where datediff(day,GETDATE(),a.denngay) <= 10";
            DataTable dt = new DataTable();
            dt = SQLHelper.ExecuteDt(sql);
            if (dt.Rows.Count > 0)
            {
                pl_hopdong.Visible = true;
                foreach (DataRow item in dt.Rows)
                {
                    ListViewItem item2 = new ListViewItem(item["MaNhanVien"].ToString());
                    item2.SubItems.Add(item["TenNhanVien"].ToString());
                    item2.SubItems.Add(DateTime.Parse(item["ngay_het_han"].ToString()).ToString("yyyy/MM/dd"));

                    lv_hopdong_hethan.Items.Add(item2);
                }
            }
            else
            {
                pl_hopdong.Visible = false;
            }

            lb_title_hopdong.Text = "Có (" + dt.Rows.Count + ") hợp đồng sắp hết hạn";
        }
        private void timer1_Tick(object sender, EventArgs e)
        {
            ts_date.Text = DateTime.Now.ToString("yyyy/MM/dd HH:mm:ss");
        }

        private void frm_home_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
            {
                this.Close();
            }
        }

        private void btn_show_menu_left_Click(object sender, EventArgs e)
        {
            start_timer();
        }
        public void start_timer()
        {
            if (pl_menu_left.Size == pl_menu_left.MaximumSize)
            {
                lbl_title_menu.Text = "";
                foreach (Control item in splitContainer1.Panel2.Controls)
                {
                    item.Text = "";
                }
                foreach (Control item in splitContainer1.Panel1.Controls)
                {
                    item.Text = "";
                }
                isCollapsed = false;
                _btn_show_menu_left = false;
            }
            else if (pl_menu_left.Size == pl_menu_left.MinimumSize)
            {
                foreach (Control item in splitContainer1.Panel1.Controls)
                {
                    var names = dt_Menu_child.Rows.Cast<DataRow>().Where(x => x["Id"].ToString() == item.Tag.ToString()).FirstOrDefault();
                    item.Text = "  " + names["MenuText"].ToString();
                }
                isCollapsed = true;
                _btn_show_menu_left = true;

                var name_parent = dt_MenuParent.Rows.Cast<DataRow>().Where(x => x["Id"].ToString() == btn_IdClick).FirstOrDefault();
                if (name_parent != null)
                    lbl_title_menu.Text = name_parent["MenuText"].ToString();
                foreach (Control item in splitContainer1.Panel2.Controls)
                {
                    var names = dt_MenuParent.Rows.Cast<DataRow>().Where(x => x["Id"].ToString() == item.Tag.ToString()).FirstOrDefault();
                    item.Text = "  " + names["MenuText"].ToString();
                }
            }
            tm_menu_left.Start();
        }
        private void tm_menu_left_Tick(object sender, EventArgs e)
        {
            if (isCollapsed)
            {
                pl_menu_left.Width += 200;
                if (pl_menu_left.Size == pl_menu_left.MaximumSize)
                {
                    tm_menu_left.Stop();
                    isCollapsed = false;
                    btn_show_menu_left.Text = "<<";
                }
            }
            else
            {
                pl_menu_left.Width -= 200;
                if (pl_menu_left.Size == pl_menu_left.MinimumSize)
                {
                    tm_menu_left.Stop();
                    isCollapsed = true;
                    btn_show_menu_left.Text = ">>";
                }
            }
        }

        private void btn_exit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btn_minimize_Click(object sender, EventArgs e)
        {
            WindowState = FormWindowState.Minimized;
        }

        private void btn_maxximize_Click(object sender, EventArgs e)
        {
            if (maximized == false)
            {
                MaximizeWindow();
            }
            else
            {
                maximized = false;
                this.Size = new Size(1240, 835);
                this.StartPosition = FormStartPosition.CenterScreen;
                this.Location = new Point((Screen.PrimaryScreen.WorkingArea.Width - this.Width) / 2, (Screen.PrimaryScreen.WorkingArea.Height - this.Height) / 2);
                //splitContainer1.Panel1MinSize = splitContainer1.Size.Height - 755;
                //splitContainer1.Panel2MinSize = splitContainer1.Size.Height - (splitContainer1.Size.Height - 740);
                splitContainer1.Panel2MinSize = splitContainer1.Size.Height - splitContainer1.Panel1MinSize - 5;
            }
            //if (WindowState == FormWindowState.Normal)
            //{
            //    MaximizeWindow();
            //}
            //else
            //{
            //    WindowState = FormWindowState.Minimized;
            //}
        }

        private void tb_main_DrawItem(object sender, DrawItemEventArgs e)
        {
            Image img = new Bitmap(Resources.clear, new Size(10, 10));
            Rectangle r = e.Bounds;
            r = this.tb_main.GetTabRect(e.Index);
            r.Offset(2, 2);
            Brush TitleBrush = new SolidBrush(Color.Black);
            Font f = this.Font;
            string title = this.tb_main.TabPages[e.Index].Text;
            e.Graphics.DrawString(title, f, TitleBrush, new PointF(r.X, r.Y));
            e.Graphics.DrawImage(img, new Point(r.X + (this.tb_main.GetTabRect(e.Index).Width - _imageLocation.X), _imageLocation.Y + 2));
        }

        private void tb_main_MouseClick(object sender, MouseEventArgs e)
        {
            TabControl tabControl = (TabControl)sender;
            Point p = e.Location;
            int _tabWidth = 0;
            _tabWidth = this.tb_main.GetTabRect(tabControl.SelectedIndex).Width - (_imgHitArea.X);
            Rectangle r = this.tb_main.GetTabRect(tabControl.SelectedIndex);
            r.Offset(_tabWidth, _imgHitArea.Y);
            r.Width = 16;
            r.Height = 16;
            //if (tb_main.SelectedIndex >= 1)
            //{
            if (r.Contains(p))
            {
                TabPage tabPage = (TabPage)tabControl.TabPages[tabControl.SelectedIndex];
                tabControl.TabPages.Remove(tabPage);
            }
            //}
        }

        private void tm_notifi_Tick(object sender, EventArgs e)
        {
            if (isCollapsed)
            {
                lb_menu.Image = Resources.up_arrow;
                panel.Height += 10;
                if (panel.Size == panel.MaximumSize)
                {
                    tm_notifi.Stop();
                    isCollapsed = false;
                }
            }
            else
            {
                lb_menu.Image = Resources.dow_arrow;
                panel.Height -= 10;
                if (panel.Size == panel.MinimumSize)
                {
                    tm_notifi.Stop();
                    isCollapsed = true;
                }
            }
        }
        public void start_timer_notifi()
        {
            if (panel.Size == panel.MaximumSize)
            {
                isCollapsed = false;
            }
            else if (panel.Size == panel.MinimumSize)
            {
                isCollapsed = true;
            }
            tm_notifi.Start();
        }
        private void btn_close_notifi_Click(object sender, EventArgs e)
        {
            if (notifi_hide == true)
            {
                notifi_hide = false;
                btn_close_notifi.IconChar = FontAwesome.Sharp.IconChar.UpRightFromSquare;
                pl_menu.Location = new Point(this.Right - 429, this.Bottom - 56);
                pl_menu.Width = 429;
                pl_menu.Height = 32;
                pl_menu.Visible = false;
            }
            //else
            //{
            //    notifi_hide = true;
            //    btn_close_notifi.IconChar = FontAwesome.Sharp.IconChar.Xmark;
            //    pl_menu.Location = new Point(this.Right - 432, this.Bottom - 410);
            //    pl_menu.Width = 429;
            //    pl_menu.Height = 385;
            //}
        }

        private void lb_menu_sn_Click(object sender, EventArgs e)
        {
            panel = pl_sn;
            lb_menu = lb_menu_sn;
            start_timer_notifi();
        }

        private void lb_hop_dong_Click(object sender, EventArgs e)
        {
            panel = pl_hopdong;
            lb_menu = lb_hop_dong;
            start_timer_notifi();
        }

        private void lb_nv_moi_Click(object sender, EventArgs e)
        {
            panel = pl_nv_moi;
            lb_menu = lb_nv_moi;
            start_timer_notifi();
        }

        private void btn_notifi_Click(object sender, EventArgs e)
        {
            if (notifi_hide == true)
            {
                notifi_hide = false;
                btn_close_notifi.IconChar = FontAwesome.Sharp.IconChar.UpRightFromSquare;
                pl_menu.Location = new Point(this.Width - 429, this.Height - 56);
                pl_menu.Width = 429;
                pl_menu.Height = 32;
                pl_menu.Visible = false;
            }
            else
            {
                notifi_hide = true;
                btn_close_notifi.IconChar = FontAwesome.Sharp.IconChar.Xmark;
                //pl_menu.Location = new Point(this.Right - 432, this.Bottom - 410);
                pl_menu.Location = new Point(this.Width - 432, this.Height - 410);
                pl_menu.Width = 429;
                pl_menu.Height = 385;
                pl_menu.Visible = true;
            }
        }

        private void btn_close_all_Click(object sender, EventArgs e)
        {
            tb_main.TabPages.Clear();
        }

        private void btn_close_all_but_this_Click(object sender, EventArgs e)
        {
            string this_tab = ((TabPage)tb_main.TabPages[tb_main.SelectedIndex]).Name;
            foreach (TabPage item in tb_main.TabPages)
            {
                if (item.Name != this_tab)
                {
                    tb_main.TabPages.Remove(item);
                }
            }
        }

        private void tb_main_MouseUp(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                menustrip_tabpage.Show(tb_main, e.X, e.Y);
            }
        }
        private const int WM_NCLBUTTONDOW = 0xA1;
        private const int HT_CAPTION = 0x2;
        [System.Runtime.InteropServices.DllImport("user32.dll")]
        private static extern int SendMessage(IntPtr hWnd, int Msg, int mPagram, int lParam);
        [System.Runtime.InteropServices.DllImport("user32.dll")]
        private static extern bool ReleaseCapture();
        private void menuStrip1_MouseDown(object sender, MouseEventArgs e)
        {
            if (maximized == false)
            {
                if (e.Button == MouseButtons.Left)
                {
                    if (e.Clicks == 1 && e.Y <= this.Height && e.Y >= 0)
                    {
                        ReleaseCapture();
                        SendMessage(this.Handle, WM_NCLBUTTONDOW, HT_CAPTION, 0);
                    }
                }
            }
        }
    }
}