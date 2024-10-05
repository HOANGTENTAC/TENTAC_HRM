using System;
using System.Data;
using System.Drawing;
using System.ServiceModel;
using System.Windows.Forms;
using TENTAC_HRM.Cham_Cong;
using TENTAC_HRM.ChamCong;
using TENTAC_HRM.Luong;
using TENTAC_HRM.Main;
using TENTAC_HRM.May_Cham_Cong;
using TENTAC_HRM.Properties;
using TENTAC_HRM.Tuy_Chon;
using TENTAC_HRM.User_control;
namespace TENTAC_HRM
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

        public frm_home()
        {
            InitializeComponent();
            MaximizeWindow();
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
        }
        private void ResizableWindow()
        {
            this.ControlBox = false;
            this.FormBorderStyle = FormBorderStyle.SizableToolWindow;
        }
        public void btn_personnel_Click(object sender, EventArgs e)
        {
            add_tabcontrol("personnel");
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
            string sql = "select ma_nhan_vien,ho_ten,ngay_vao_lam from hrm_nhan_vien where datediff(day,ngay_vao_lam,GETDATE()) <= 10";
            DataTable dt = new DataTable();
            dt = SQLHelper.ExecuteDt(sql);
            if (dt.Rows.Count > 0)
            {
                pl_nv_moi.Visible = true;
                foreach (DataRow item in dt.Rows)
                {
                    ListViewItem item2 = new ListViewItem(item["ma_nhan_vien"].ToString());
                    item2.SubItems.Add(item["ho_ten"].ToString());
                    item2.SubItems.Add(DateTime.Parse(item["ngay_vao_lam"].ToString()).ToString("yyyy/MM/dd"));

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
            string sql = "select ma_nhan_vien,ho_ten,ngay_sinh from hrm_nhan_vien where MONTH(ngay_sinh) = MONTH(GETDATE())";
            DataTable dt = new DataTable();
            dt = SQLHelper.ExecuteDt(sql);
            if (dt.Rows.Count > 0)
            {
                pl_sn.Visible = true;
                foreach (DataRow item in dt.Rows)
                {
                    ListViewItem item2 = new ListViewItem(item["ma_nhan_vien"].ToString());
                    item2.SubItems.Add(item["ho_ten"].ToString());
                    item2.SubItems.Add(DateTime.Parse(item["ngay_sinh"].ToString()).ToString("yyyy/MM/dd"));

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
            string sql = "select nhanvien.ma_nhan_vien,nhanvien.ho_ten,a.den_ngay as ngay_het_han from hrm_nhan_vien nhanvien " +
                "left join [hrm_nhanvien_hopdong] a on a.ma_nhan_vien = nhanvien.ma_nhan_vien " +
                "join hrm_loai_hop_dong b on a.id_loai_hop_dong = b.id_loai_hop_dong and b.id_loai_hop_dong in (2,3) " +
                "where datediff(day,GETDATE(),a.den_ngay) <= 10";
            DataTable dt = new DataTable();
            dt = SQLHelper.ExecuteDt(sql);
            if (dt.Rows.Count > 0)
            {
                pl_hopdong.Visible = true;
                foreach (DataRow item in dt.Rows)
                {
                    ListViewItem item2 = new ListViewItem(item["ma_nhan_vien"].ToString());
                    item2.SubItems.Add(item["ho_ten"].ToString());
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

        private void btn_category_Click(object sender, EventArgs e)
        {
            if (_btn_show_menu_left == true)
            {
                lbl_title_menu.Text = "Danh mục";
            }
            else
            {
                lbl_title_menu.Text = "";
            }

            if (_btn_category == false)
            {
                splitContainer1.Panel1.Controls.Clear();

                Button dantoc = new Button();
                dantoc.FlatStyle = FlatStyle.Flat;
                dantoc.TextAlign = ContentAlignment.MiddleLeft;
                dantoc.FlatAppearance.BorderColor = Color.CornflowerBlue;
                dantoc.Dock = DockStyle.Top;
                dantoc.Size = new Size(201, 45);
                dantoc.Name = "dantoc";
                dantoc.Text = _btn_show_menu_left == true ? "Dân tộc" : "";
                dantoc.Click += btn_dantoc_Click;
                dantoc.Image = Resources.united_nations;
                dantoc.ImageAlign = ContentAlignment.MiddleLeft;
                dantoc.TextAlign = ContentAlignment.MiddleLeft;
                dantoc.TextImageRelation = TextImageRelation.ImageBeforeText;
                ToolTip ToolTip1 = new ToolTip();
                ToolTip1.SetToolTip(dantoc, "Dân tộc");
                splitContainer1.Panel1.Controls.Add(dantoc);

                Button tongiao = new Button();
                tongiao.FlatStyle = FlatStyle.Flat;
                tongiao.TextAlign = ContentAlignment.MiddleLeft;
                tongiao.FlatAppearance.BorderColor = Color.CornflowerBlue;
                tongiao.Dock = DockStyle.Top;
                tongiao.Size = new Size(201, 45);
                tongiao.Name = "tongiao";
                tongiao.Text = _btn_show_menu_left == true ? "Tôn giáo" : "";
                tongiao.Click += btn_tongiao_Click;
                tongiao.Image = Resources.religion;
                tongiao.ImageAlign = ContentAlignment.MiddleLeft;
                tongiao.TextAlign = ContentAlignment.MiddleLeft;
                tongiao.TextImageRelation = TextImageRelation.ImageBeforeText;
                ToolTip ToolTip_hop_dong = new ToolTip();
                ToolTip_hop_dong.SetToolTip(tongiao, "Tôn giáo");
                splitContainer1.Panel1.Controls.Add(tongiao);

                Button diachi = new Button();
                diachi.FlatStyle = FlatStyle.Flat;
                diachi.TextAlign = ContentAlignment.MiddleLeft;
                diachi.FlatAppearance.BorderColor = Color.CornflowerBlue;
                diachi.Dock = DockStyle.Top;
                diachi.Size = new Size(201, 45);
                diachi.Name = "diachi";
                diachi.Text = _btn_show_menu_left == true ? "Địa chỉ" : "";
                diachi.Click += btn_diachi_Click;
                diachi.Image = Resources.local;
                diachi.ImageAlign = ContentAlignment.MiddleLeft;
                diachi.TextAlign = ContentAlignment.MiddleLeft;
                diachi.TextImageRelation = TextImageRelation.ImageBeforeText;
                ToolTip ToolTip_hoso_nhansu = new ToolTip();
                ToolTip_hop_dong.SetToolTip(diachi, "Địa chỉ");
                splitContainer1.Panel1.Controls.Add(diachi);

            }
            _btn_nhansu = false;
            _btn_maychamcong = false;
            _btn_luong = false;
            _btn_category = true;
            _btn_quatrinh = false;
            _btn_chamcong = false;
            _btn_bangxepca = false;
            _btn_sodo_chucnang = false;
            _btn_setting = false;
        }

        private void add_tabcontrol(string name_tab)
        {
            isPresent = false;
            string text_tab = "";
            UserControl user = new UserControl();
            switch (name_tab)
            {
                case "personnel":
                    text_tab = "Nhân sự";
                    user = uc_nhan_su.Instance;
                    break;
                case "annual_leave":
                    text_tab = "Phép năm";
                    user = uc_annual_leave.Instance;
                    break;
                case "nghiphep":
                    text_tab = "Nghỉ phép";
                    user = uc_nghiphep.Instance;
                    break;
                case "hopdong":
                    text_tab = "Hợp đồng";
                    user = uc_nhansu_hopdong.Instance;
                    break;
                case "quatrinh":
                    text_tab = "Quá trình làm việc";
                    user = uc_quatrinh_lamviec.Instance;
                    break;
                case "timekeeper":
                    text_tab = "Bảng chấm công";
                    user = uc_timekeeper.Instance;
                    break;
                case "KhaiBaoMayChamCong":
                    text_tab = "Quản lý máy chấm công";
                    user = uc_quanly_maychamcongnew.Instance;
                    break;
                case "taidulieumaychamcong":
                    text_tab = "Tải dữ liệu máy chấm công";
                    user = uc_taitudong.Instance;
                    break;
                case "tainhanvienvemaytinh":
                    text_tab = "Tải nhân viên về máy tính";
                    user = uc_tainhanvien.Instance;
                    break;
                case "tainhanvienlenmaychamcong":
                    text_tab = "Tải nhân viên lên máy chấm công";
                    user = uc_TaiNhanVienLenMayChamCong2.Instance;
                    break;
                case "luongthang":
                    text_tab = "Bảng tính lương tháng";
                    user = uc_luongthang.Instance;
                    break;
                case "bangxepca":
                    text_tab = "Bảng xếp ca";
                    user = uc_bangxepca.Instance;
                    break;
                case "sodochucnang":
                    text_tab = "Sơ đồ chức năng";
                    user = uc_sodo_chucnang.Instance;
                    break;
                case "dantoc":
                    text_tab = "Dân tộc";
                    user = uc_nation.Instance;
                    break;
                case "tongiao":
                    text_tab = "Tôn giáo";
                    user = uc_staff_religion.Instance;
                    break;
                case "diachi":
                    text_tab = "Địa chỉ";
                    user = uc_staff_address.Instance;
                    uc_staff_address.Instance.uc_controll = false;
                    break;
            }
            for (int i = 0; i < tb_main.TabPages.Count; i++)
            {
                if (tb_main.TabPages[i].Name == "tp_" + name_tab)
                {
                    isPresent = true;
                    tb_main.SelectedTab = tb_main.TabPages["tp_" + name_tab];
                    break;
                }
            }

            if (isPresent == false)
            {
                TabPage tp = new TabPage(text_tab);
                tp.Name = "tp_" + name_tab;
                Panel tb = new Panel();
                tb.Dock = DockStyle.Fill;
                tb.Name = "pl_" + name_tab;

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
        private void frm_home_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
            {
                this.Close();
            }
        }

        private void btn_phepnam_Click(object sender, EventArgs e)
        {
            add_tabcontrol("annual_leave");
        }
        private void btn_nghiphep_Click(object sender, EventArgs e)
        {
            add_tabcontrol("nghiphep");
        }
        private void btn_hopdong_Click(object sender, EventArgs e)
        {
            add_tabcontrol("hopdong");
        }
        private void btn_quatrinh_Click(object sender, EventArgs e)
        {
            splitContainer1.Panel1.Controls.Clear();
            if (_btn_show_menu_left == true)
            {
                lbl_title_menu.Text = "Quá trình làm việc";
            }
            else
            {
                lbl_title_menu.Text = "";
            }

            add_tabcontrol("quatrinh");
            _btn_nhansu = false;
            _btn_maychamcong = false;
            _btn_luong = false;
            _btn_category = false;
            _btn_quatrinh = true;
            _btn_chamcong = false;
            _btn_bangxepca = false;
            _btn_sodo_chucnang = false;
            _btn_setting = false;
        }
        private void btn_timekeeper_Click(object sender, EventArgs e)
        {
            splitContainer1.Panel1.Controls.Clear();
            if (_btn_show_menu_left == true)
            {
                lbl_title_menu.Text = "Chấm công";
            }
            else
            {
                lbl_title_menu.Text = "";
            }
            add_tabcontrol("timekeeper");
            _btn_nhansu = false;
            _btn_maychamcong = false;
            _btn_luong = false;
            _btn_category = false;
            _btn_quatrinh = false;
            _btn_chamcong = true;
            _btn_bangxepca = false;
            _btn_sodo_chucnang = false;
            _btn_setting = false;
        }
        private void btn_KhaiBaoMayChamCong_Click(object sender, EventArgs e)
        {
            add_tabcontrol("KhaiBaoMayChamCong");
        }
        private void btn_close_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
        private void btn_taidulieu_chamcong_Click(object sender, EventArgs e)
        {
            add_tabcontrol("taidulieumaychamcong");
        }
        private void btn_tainhanvien_vemaytinh_Click(object sender, EventArgs e)
        {
            add_tabcontrol("tainhanvienvemaytinh");
        }
        private void btn_tainhanvienlenmaychamcong_Click(object sender, EventArgs e)
        {
            add_tabcontrol("tainhanvienlenmaychamcong");
        }
        private void btn_bangtinh_luongthang_Click(object sender, EventArgs e)
        {
            add_tabcontrol("luongthang");
        }
        private void btn_diachi_Click(object sender, EventArgs e)
        {
            add_tabcontrol("diachi");
        }
        private void btn_tongiao_Click(object sender, EventArgs e)
        {
            add_tabcontrol("tongiao");
        }
        private void btn_dantoc_Click(object sender, EventArgs e)
        {
            add_tabcontrol("dantoc");
        }
        private void btn_bangxepca_Click(object sender, EventArgs e)
        {
            splitContainer1.Panel1.Controls.Clear();
            if (_btn_show_menu_left == true)
            {
                lbl_title_menu.Text = "Bảng xếp ca";
            }
            else
            {
                lbl_title_menu.Text = "";
            }
            add_tabcontrol("bangxepca");

            _btn_nhansu = false;
            _btn_maychamcong = false;
            _btn_luong = false;
            _btn_category = false;
            _btn_quatrinh = false;
            _btn_chamcong = false;
            _btn_bangxepca = true;
            _btn_sodo_chucnang = false;
            _btn_setting = false;
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
                btn_category.Text = "";
                btn_nhansu.Text = "";
                btn_quatrinh.Text = "";
                btn_timekeeper.Text = "";
                btn_maychamcong.Text = "";
                btn_luong.Text = "";
                btn_bangxepca.Text = "";
                btn_sodo_chucnang.Text = "";
                btn_setting.Text = "";
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
                    switch (item.Name)
                    {
                        case "nghiphep":
                            item.Text = "Nghỉ phép";
                            break;
                        case "phepnam":
                            item.Text = "Phép năm";
                            break;
                        case "hopdong_nhansu":
                            item.Text = "Hợp đồng nhân sự";
                            break;
                        case "hoso_nhansu":
                            item.Text = "Hồ sơ nhân sự";
                            break;
                        case "tainhanvien_mcc":
                            item.Text = "Tải nhân viên lên máy chấm công";
                            break;
                        case "taidulieu_chamcong":
                            item.Text = "Tải dữ liệu chấm công";
                            break;
                        case "tainhanvien_maytinh":
                            item.Text = "Tải nhân viên về máy tính";
                            break;
                        case "khaibao_mcc":
                            item.Text = "Khai báo máy chấm công";
                            break;
                        case "tamung_luong":
                            item.Text = "Tạm ứng lương";
                            break;
                        case "phucap_luong":
                            item.Text = "Phụ cấp lương";
                            break;
                        case "luong_tangca":
                            item.Text = "Bảng tính lương tăng ca";
                            break;
                        case "luong_thang":
                            item.Text = "Bảng tính lương tháng";
                            break;
                        case "tongiao":
                            item.Text = "Tôn giáo";
                            break;
                        case "diachi":
                            item.Text = "Địa chỉ";
                            break;
                        case "dantoc":
                            item.Text = "Dân tộc";
                            break;
                    }
                }
                btn_category.Text = " Danh mục";
                btn_nhansu.Text = " Nhân sự";
                btn_quatrinh.Text = " Quá trình làm việc";
                btn_timekeeper.Text = "   Chấm công";
                btn_maychamcong.Text = "  Máy chấm công";
                btn_luong.Text = "  Lương";
                btn_bangxepca.Text = "  Bảng xếp ca";
                btn_sodo_chucnang.Text = "  Sơ đồ chức năng";
                btn_setting.Text = "  Tùy chọn";
                isCollapsed = true;
                _btn_show_menu_left = true;

                if (_btn_nhansu == true)
                {
                    lbl_title_menu.Text = "Nhân sự";
                }
                else if (_btn_maychamcong == true)
                {
                    lbl_title_menu.Text = "Máy chấm công";
                }
                else if (_btn_luong == true)
                {
                    lbl_title_menu.Text = "Lương";
                }
                else if (_btn_category == true)
                {
                    lbl_title_menu.Text = "Danh mục nhân sự";
                }
                else if (_btn_quatrinh == true)
                {
                    lbl_title_menu.Text = "Quá trình làm việc";
                }
                else if (_btn_chamcong == true)
                {
                    lbl_title_menu.Text = "Chấm công";
                }
                else if (_btn_bangxepca == true)
                {
                    lbl_title_menu.Text = "Bảng xếp ca";
                }
                else
                {
                    lbl_title_menu.Text = "";
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

        private void btn_nhansu_Click(object sender, EventArgs e)
        {
            if (_btn_show_menu_left == true)
            {
                lbl_title_menu.Text = "Nhân sự";
            }
            else
            {
                lbl_title_menu.Text = "";
            }
            if (_btn_nhansu == false)
            {
                splitContainer1.Panel1.Controls.Clear();

                Button nghiphep = new Button();
                nghiphep.FlatStyle = FlatStyle.Flat;
                nghiphep.TextAlign = ContentAlignment.MiddleLeft;
                nghiphep.FlatAppearance.BorderColor = Color.CornflowerBlue;
                nghiphep.Dock = DockStyle.Top;
                nghiphep.Size = new Size(201, 45);
                nghiphep.Name = "nghiphep";
                nghiphep.Text = _btn_show_menu_left == true ? "Nghỉ phép" : "";
                nghiphep.Click += btn_nghiphep_Click;
                nghiphep.Image = Resources.contract1_32X32;
                nghiphep.ImageAlign = ContentAlignment.MiddleLeft;
                nghiphep.TextAlign = ContentAlignment.MiddleLeft;
                nghiphep.TextImageRelation = TextImageRelation.ImageBeforeText;
                ToolTip ToolTip_nghiphep = new ToolTip();
                ToolTip_nghiphep.SetToolTip(nghiphep, "Nghỉ phép");
                splitContainer1.Panel1.Controls.Add(nghiphep);

                Button phepnam = new Button();
                phepnam.FlatStyle = FlatStyle.Flat;
                phepnam.TextAlign = ContentAlignment.MiddleLeft;
                phepnam.FlatAppearance.BorderColor = Color.CornflowerBlue;
                phepnam.Dock = DockStyle.Top;
                phepnam.Size = new Size(201, 45);
                phepnam.Name = "phepnam";
                phepnam.Text = _btn_show_menu_left == true ? "Phép năm" : "";
                phepnam.Click += btn_phepnam_Click;
                phepnam.Image = Resources.timetable32X32;
                phepnam.ImageAlign = ContentAlignment.MiddleLeft;
                phepnam.TextAlign = ContentAlignment.MiddleLeft;
                phepnam.TextImageRelation = TextImageRelation.ImageBeforeText;
                ToolTip ToolTip_phepnam = new ToolTip();
                ToolTip_phepnam.SetToolTip(phepnam, "Phép năm");
                splitContainer1.Panel1.Controls.Add(phepnam);

                Button hop_dong = new Button();
                hop_dong.FlatStyle = FlatStyle.Flat;
                hop_dong.TextAlign = ContentAlignment.MiddleLeft;
                hop_dong.FlatAppearance.BorderColor = Color.CornflowerBlue;
                hop_dong.Dock = DockStyle.Top;
                hop_dong.Size = new Size(201, 45);
                hop_dong.Name = "hopdong_nhansu";
                hop_dong.Text = _btn_show_menu_left == true ? "Hợp đồng nhân sự" : "";
                hop_dong.Click += btn_hopdong_Click;
                hop_dong.Image = Resources.contract32X32;
                hop_dong.ImageAlign = ContentAlignment.MiddleLeft;
                hop_dong.TextAlign = ContentAlignment.MiddleLeft;
                hop_dong.TextImageRelation = TextImageRelation.ImageBeforeText;
                ToolTip ToolTip_hop_dong = new ToolTip();
                ToolTip_hop_dong.SetToolTip(hop_dong, "Hợp đồng nhân sự");
                splitContainer1.Panel1.Controls.Add(hop_dong);

                Button hoso_nhansu = new Button();
                hoso_nhansu.FlatStyle = FlatStyle.Flat;
                hoso_nhansu.TextAlign = ContentAlignment.MiddleLeft;
                hoso_nhansu.FlatAppearance.BorderColor = Color.CornflowerBlue;
                hoso_nhansu.Dock = DockStyle.Top;
                hoso_nhansu.Size = new Size(201, 45);
                hoso_nhansu.Name = "hoso_nhansu";
                hoso_nhansu.Text = _btn_show_menu_left == true ? "  Hồ sơ nhân sự" : "";
                hoso_nhansu.Click += btn_personnel_Click;
                hoso_nhansu.Image = Resources.book_stack_32X32;
                hoso_nhansu.ImageAlign = ContentAlignment.MiddleLeft;
                hoso_nhansu.TextAlign = ContentAlignment.MiddleLeft;
                hoso_nhansu.TextImageRelation = TextImageRelation.ImageBeforeText;
                ToolTip ToolTip_hoso_nhansu = new ToolTip();
                ToolTip_hop_dong.SetToolTip(hoso_nhansu, "Hồ sơ nhân sự");
                splitContainer1.Panel1.Controls.Add(hoso_nhansu);

                _btn_nhansu = true;
                _btn_maychamcong = false;
                _btn_luong = false;
                _btn_category = false;
                _btn_quatrinh = false;
                _btn_chamcong = false;
                _btn_bangxepca = false;
                _btn_sodo_chucnang = false;
                _btn_setting = false;
            }
        }

        private void btn_maychamcong_Click(object sender, EventArgs e)
        {
            if (_btn_show_menu_left == true)
            {
                lbl_title_menu.Text = "Máy chấm công";
            }
            else
            {
                lbl_title_menu.Text = "";
            }

            if (_btn_maychamcong == false)
            {
                splitContainer1.Panel1.Controls.Clear();

                Button tainhanvienlenmaychamcong = new Button();
                tainhanvienlenmaychamcong.FlatStyle = FlatStyle.Flat;
                tainhanvienlenmaychamcong.TextAlign = ContentAlignment.MiddleLeft;
                tainhanvienlenmaychamcong.FlatAppearance.BorderColor = Color.CornflowerBlue;
                tainhanvienlenmaychamcong.Dock = DockStyle.Top;
                tainhanvienlenmaychamcong.Size = new Size(201, 45);
                tainhanvienlenmaychamcong.Name = "tainhanvien_mcc";
                tainhanvienlenmaychamcong.Text = _btn_show_menu_left == true ? "Tải nhân viên lên máy chấm công" : "";
                tainhanvienlenmaychamcong.Click += btn_tainhanvienlenmaychamcong_Click;
                tainhanvienlenmaychamcong.Image = Resources.cloud_upload_32X32;
                tainhanvienlenmaychamcong.ImageAlign = ContentAlignment.MiddleLeft;
                tainhanvienlenmaychamcong.TextAlign = ContentAlignment.MiddleLeft;
                tainhanvienlenmaychamcong.TextImageRelation = TextImageRelation.ImageBeforeText;
                ToolTip ToolTip_tainhanvienlenmaychamcong = new ToolTip();
                ToolTip_tainhanvienlenmaychamcong.SetToolTip(tainhanvienlenmaychamcong, "Tải nhân viên lên máy chấm công");
                splitContainer1.Panel1.Controls.Add(tainhanvienlenmaychamcong);

                Button taidulieu_chamcong = new Button();
                taidulieu_chamcong.FlatStyle = FlatStyle.Flat;
                taidulieu_chamcong.TextAlign = ContentAlignment.MiddleLeft;
                taidulieu_chamcong.FlatAppearance.BorderColor = Color.CornflowerBlue;
                taidulieu_chamcong.Dock = DockStyle.Top;
                taidulieu_chamcong.Size = new Size(201, 45);
                taidulieu_chamcong.Name = "taidulieu_chamcong";
                taidulieu_chamcong.Text = _btn_show_menu_left == true ? "Tải dữ liệu chấm công" : "";
                taidulieu_chamcong.Click += btn_taidulieu_chamcong_Click;
                taidulieu_chamcong.Image = Resources.cloud_32X32;
                taidulieu_chamcong.ImageAlign = ContentAlignment.MiddleLeft;
                taidulieu_chamcong.TextAlign = ContentAlignment.MiddleLeft;
                taidulieu_chamcong.TextImageRelation = TextImageRelation.ImageBeforeText;
                ToolTip ToolTip_taidulieu_chamcong = new ToolTip();
                ToolTip_taidulieu_chamcong.SetToolTip(taidulieu_chamcong, "Tải dữ liệu chấm công");
                splitContainer1.Panel1.Controls.Add(taidulieu_chamcong);

                Button tai_nhanvien = new Button();
                tai_nhanvien.FlatStyle = FlatStyle.Flat;
                tai_nhanvien.TextAlign = ContentAlignment.MiddleLeft;
                tai_nhanvien.FlatAppearance.BorderColor = Color.CornflowerBlue;
                tai_nhanvien.Dock = DockStyle.Top;
                tai_nhanvien.Size = new Size(201, 45);
                tai_nhanvien.Name = "tainhanvien_maytinh";
                tai_nhanvien.Text = _btn_show_menu_left == true ? "Tải nhân viên về máy tính" : "";
                tai_nhanvien.Click += btn_tainhanvien_vemaytinh_Click;
                tai_nhanvien.Image = Resources.direct_download_32X32;
                tai_nhanvien.ImageAlign = ContentAlignment.MiddleLeft;
                tai_nhanvien.TextAlign = ContentAlignment.MiddleLeft;
                tai_nhanvien.TextImageRelation = TextImageRelation.ImageBeforeText;
                ToolTip ToolTip_tai_nhanvien = new ToolTip();
                ToolTip_tai_nhanvien.SetToolTip(tai_nhanvien, "Tải nhân viên về máy tính");
                splitContainer1.Panel1.Controls.Add(tai_nhanvien);

                Button khaibao_maychamcong = new Button();
                khaibao_maychamcong.FlatStyle = FlatStyle.Flat;
                khaibao_maychamcong.TextAlign = ContentAlignment.MiddleLeft;
                khaibao_maychamcong.FlatAppearance.BorderColor = Color.CornflowerBlue;
                khaibao_maychamcong.Dock = DockStyle.Top;
                khaibao_maychamcong.Size = new Size(201, 45);
                khaibao_maychamcong.Text = _btn_show_menu_left == true ? "Khai báo máy chấm công" : "";
                khaibao_maychamcong.Name = "khaibao_mcc";
                khaibao_maychamcong.Click += btn_KhaiBaoMayChamCong_Click;
                khaibao_maychamcong.Image = Resources.KhaiBaoMayChamCongMenu_Image;
                khaibao_maychamcong.ImageAlign = ContentAlignment.MiddleLeft;
                khaibao_maychamcong.TextAlign = ContentAlignment.MiddleLeft;
                khaibao_maychamcong.TextImageRelation = TextImageRelation.ImageBeforeText;
                ToolTip ToolTip_khaibao_maychamcong = new ToolTip();
                ToolTip_khaibao_maychamcong.SetToolTip(khaibao_maychamcong, "Khai báo máy chấm công");
                splitContainer1.Panel1.Controls.Add(khaibao_maychamcong);

                _btn_nhansu = false;
                _btn_maychamcong = true;
                _btn_luong = false;
                _btn_category = false;
                _btn_quatrinh = false;
                _btn_chamcong = false;
                _btn_bangxepca = false;
                _btn_sodo_chucnang = false;
                _btn_setting = false;
            }
        }

        private void btn_luong_Click(object sender, EventArgs e)
        {
            if (_btn_show_menu_left == true)
            {
                lbl_title_menu.Text = "Lương";
            }
            else
            {
                lbl_title_menu.Text = "";
            }

            if (_btn_luong == false)
            {
                splitContainer1.Panel1.Controls.Clear();

                Button tamung_luong = new Button();
                tamung_luong.FlatStyle = FlatStyle.Flat;
                tamung_luong.TextAlign = ContentAlignment.MiddleLeft;
                tamung_luong.FlatAppearance.BorderColor = Color.CornflowerBlue;
                tamung_luong.Dock = DockStyle.Top;
                tamung_luong.Size = new Size(201, 45);
                tamung_luong.Text = _btn_show_menu_left == true ? "Tạm ứng lương" : "";
                tamung_luong.Name = "tamung_luong";
                //tamung_luong.Click += btn_tamung_luong_Click;
                tamung_luong.Image = Resources.hand_32X32;
                tamung_luong.ImageAlign = ContentAlignment.MiddleLeft;
                tamung_luong.TextAlign = ContentAlignment.MiddleLeft;
                tamung_luong.TextImageRelation = TextImageRelation.ImageBeforeText;
                ToolTip ToolTip_tamung_luong = new ToolTip();
                ToolTip_tamung_luong.SetToolTip(tamung_luong, "Tạm ứng lương");
                splitContainer1.Panel1.Controls.Add(tamung_luong);

                Button phucap_luong = new Button();
                phucap_luong.FlatStyle = FlatStyle.Flat;
                phucap_luong.TextAlign = ContentAlignment.MiddleLeft;
                phucap_luong.FlatAppearance.BorderColor = Color.CornflowerBlue;
                phucap_luong.Dock = DockStyle.Top;
                phucap_luong.Size = new Size(201, 45);
                phucap_luong.Text = _btn_show_menu_left == true ? "Phụ cấp lương" : "";
                phucap_luong.Name = "phucap_luong";
                //phucap_luong.Click += btn_phucap_luong_Click;
                phucap_luong.Image = Resources.pay_32X32;
                phucap_luong.ImageAlign = ContentAlignment.MiddleLeft;
                phucap_luong.TextAlign = ContentAlignment.MiddleLeft;
                phucap_luong.TextImageRelation = TextImageRelation.ImageBeforeText;
                ToolTip ToolTip_phucap_luong = new ToolTip();
                ToolTip_phucap_luong.SetToolTip(phucap_luong, "Phụ cấp lương");
                splitContainer1.Panel1.Controls.Add(phucap_luong);

                Button bangtinhluong_tangca = new Button();
                bangtinhluong_tangca.FlatStyle = FlatStyle.Flat;
                bangtinhluong_tangca.TextAlign = ContentAlignment.MiddleLeft;
                bangtinhluong_tangca.FlatAppearance.BorderColor = Color.CornflowerBlue;
                bangtinhluong_tangca.Dock = DockStyle.Top;
                bangtinhluong_tangca.Size = new Size(201, 45);
                bangtinhluong_tangca.Text = _btn_show_menu_left == true ? "Bảng tính lương tăng ca" : "";
                bangtinhluong_tangca.Name = "luong_tangca";
                //bangtinhluong_tangca.Click += btn_bangluong_tangca_Click;
                bangtinhluong_tangca.Image = Resources.days_32X32;
                bangtinhluong_tangca.ImageAlign = ContentAlignment.MiddleLeft;
                bangtinhluong_tangca.TextAlign = ContentAlignment.MiddleLeft;
                bangtinhluong_tangca.TextImageRelation = TextImageRelation.ImageBeforeText;
                ToolTip ToolTip_bangtinhluong_tangca = new ToolTip();
                ToolTip_bangtinhluong_tangca.SetToolTip(bangtinhluong_tangca, "Bảng tính lương tăng ca");
                splitContainer1.Panel1.Controls.Add(bangtinhluong_tangca);

                Button bangtinhluong_thang = new Button();
                bangtinhluong_thang.FlatStyle = FlatStyle.Flat;
                bangtinhluong_thang.TextAlign = ContentAlignment.MiddleLeft;
                bangtinhluong_thang.FlatAppearance.BorderColor = Color.CornflowerBlue;
                bangtinhluong_thang.Dock = DockStyle.Top;
                bangtinhluong_thang.Size = new Size(201, 45);
                bangtinhluong_thang.Text = _btn_show_menu_left == true ? "Bảng tính lương tháng" : "";
                bangtinhluong_thang.Name = "luong_thang";
                bangtinhluong_thang.Click += btn_bangtinh_luongthang_Click;
                bangtinhluong_thang.Image = Resources.timetable32X32;
                bangtinhluong_thang.ImageAlign = ContentAlignment.MiddleLeft;
                bangtinhluong_thang.TextAlign = ContentAlignment.MiddleLeft;
                bangtinhluong_thang.TextImageRelation = TextImageRelation.ImageBeforeText;
                ToolTip ToolTip_bangtinhluong_thang = new ToolTip();
                ToolTip_bangtinhluong_thang.SetToolTip(bangtinhluong_thang, "Bảng tính lương tháng");
                splitContainer1.Panel1.Controls.Add(bangtinhluong_thang);

                _btn_nhansu = false;
                _btn_maychamcong = false;
                _btn_luong = true;
                _btn_category = false;
                _btn_quatrinh = false;
                _btn_chamcong = false;
                _btn_bangxepca = false;
                _btn_sodo_chucnang = false;
                _btn_setting = false;
            }
        }

        private void btn_category_MouseHover(object sender, EventArgs e)
        {
            ToolTip ToolTip1 = new ToolTip();
            ToolTip1.SetToolTip(btn_category, text_button("btn_category"));
        }

        private void btn_nhansu_MouseHover(object sender, EventArgs e)
        {
            ToolTip ToolTip1 = new ToolTip();
            ToolTip1.SetToolTip(btn_nhansu, text_button("btn_nhansu"));
        }

        private void btn_quatrinh_MouseHover(object sender, EventArgs e)
        {
            ToolTip ToolTip1 = new ToolTip();
            ToolTip1.SetToolTip(btn_quatrinh, text_button("btn_quatrinh"));
        }

        private void btn_timekeeper_MouseHover(object sender, EventArgs e)
        {
            ToolTip ToolTip1 = new ToolTip();
            ToolTip1.SetToolTip(btn_timekeeper, text_button("btn_timekeeper"));
        }
        private void btn_maychamcong_MouseHover(object sender, EventArgs e)
        {
            ToolTip ToolTip1 = new ToolTip();
            ToolTip1.SetToolTip(btn_maychamcong, text_button("btn_maychamcong"));
        }

        private void btn_luong_MouseHover(object sender, EventArgs e)
        {
            ToolTip ToolTip1 = new ToolTip();
            ToolTip1.SetToolTip(btn_luong, text_button("btn_luong"));
        }

        private void btn_bangxepca_MouseHover(object sender, EventArgs e)
        {
            ToolTip ToolTip1 = new ToolTip();
            ToolTip1.SetToolTip(btn_bangxepca, text_button("btn_bangxepca"));
        }

        private string text_button(string key)
        {
            string resual = "";
            switch (key)
            {
                case "btn_category":
                    resual = "Danh mục";
                    break;
                case "btn_nhansu":
                    resual = "Nhân sự";
                    break;
                case "btn_quatrinh":
                    resual = "Quá trình làm việc";
                    break;
                case "btn_timekeeper":
                    resual = "Chấm công";
                    break;
                case "btn_maychamcong":
                    resual = "Máy chấm công";
                    break;
                case "btn_luong":
                    resual = "Lương";
                    break;
                case "btn_bangxepca":
                    resual = "Bảng xếp ca";
                    break;
            }
            return resual;
        }

        private void btn_setting_Click(object sender, EventArgs e)
        {
            frm_tuychon frm = new frm_tuychon();
            frm.ShowDialog();

            _btn_nhansu = false;
            _btn_maychamcong = false;
            _btn_luong = false;
            _btn_category = false;
            _btn_quatrinh = false;
            _btn_chamcong = false;
            _btn_bangxepca = false;
            _btn_sodo_chucnang = false;
            _btn_setting = true;
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

        private void btn_sodo_chucnang_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < tb_main.TabPages.Count; i++)
            {
                if (tb_main.TabPages[i].Name == "tp_" + "sodo_chucnang")
                {
                    isPresent = true;
                    tb_main.SelectedTab = tb_main.TabPages["tp_" + "sodo_chucnang"];
                    break;
                }
            }
            if (isPresent == false)
            {
                uc_sodo_chucnang user = new uc_sodo_chucnang();
                user = uc_sodo_chucnang.Instance;
                user.btn_nhanvien.Click += btn_personnel_Click;
                TabPage tp = new TabPage("Sơ đồ chức năng");
                tp.Name = "tp_" + "sodo_chucnang";
                Panel tb = new Panel();
                tb.Dock = DockStyle.Fill;
                tb.Name = "pl_" + "sodo_chucnang";

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

            _btn_nhansu = false;
            _btn_maychamcong = false;
            _btn_luong = false;
            _btn_category = false;
            _btn_quatrinh = false;
            _btn_chamcong = false;
            _btn_bangxepca = false;
            _btn_sodo_chucnang = true;
            _btn_setting = false;
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