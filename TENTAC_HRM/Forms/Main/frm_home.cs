﻿using FontAwesome.Sharp;
using System;
using System.Collections.Generic;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using TENTAC_HRM.Common;
using TENTAC_HRM.Consts;
using TENTAC_HRM.Forms.User_control;
using TENTAC_HRM.Properties;

namespace TENTAC_HRM.Forms.Main
{
    public partial class frm_home : Form
    {
        bool notifi_hide = false;
        Label lb_menu;
        Panel panel = new Panel();
        Panel panel_menu = new Panel();
        //Button btn_menu;
        private IconButton btn_menu;
        Point _imageLocation = new Point(20, 4);
        Point _imgHitArea = new Point(20, 4);
        private IconButton currentBtn;
        private List<string> tagList = new List<string>();
        private bool isCollapsed = false;
        private bool isCollapsedMenu = false;
        bool _btn_show_menu_left = false;
        bool isPresent = false;
        bool isMinisize = false;
        DataTable dt_MenuParent = new DataTable();
        public frm_home()
        {
            InitializeComponent();
            Load_menu();
            MaximizeWindow();
        }

        public IconChar GetUIFontAwesome(string strIcon)
        {
            if (Enum.TryParse(strIcon, out IconChar item))
                return item;
            else
                return IconChar.None;
        }
        private void Load_menu()
        {
            //splitContainer1.Panel2.Controls.Clear();
            string sql = string.Empty;
            if (LoginInfo.Group != "ADMIN")
            {
                sql = $@"SELECT 
                a.Id,a.MenuCode,a.MenuText,a.MenuName,a.ParentId,a.MenuImage, a.FromName,a.MenuNumber,b.FrmType, b.FrmText,
                (
                    SELECT STRING_AGG(ur_child.Id_Permision, ',')
                    FROM mst_UserRoles ur_child
                    WHERE ur_child.Id_Menu = a.Id 
                      AND ur_child.del_flg = 0 
                      AND ur_child.MaNhanVien = {SQLHelper.rpStr(LoginInfo.UserCd)}
                ) AS Id_Permision FROM mst_Menu a
	            LEFT JOIN mst_from b ON a.FromName = b.FrmName
		        WHERE 
			        a.ParentId = 0 
			        AND (
				        EXISTS (
					        SELECT * 
					        FROM mst_Menu c
					        INNER JOIN mst_UserRoles ur_child 
						        ON c.Id = ur_child.Id_Menu 
						        AND ur_child.del_flg = 0 
						        AND ur_child.MaNhanVien = {SQLHelper.rpStr(LoginInfo.UserCd)}
					        WHERE c.ParentId = a.Id
				        )
				        OR EXISTS (
					        SELECT * 
					        FROM mst_UserRoles ur_parent
					        WHERE ur_parent.Id_Menu = a.Id 
					          AND ur_parent.del_flg = 0 
					          AND ur_parent.MaNhanVien = {SQLHelper.rpStr(LoginInfo.UserCd)}
				        )
			        )
		        ORDER BY 
			        a.MenuNumber DESC;";
                dt_MenuParent = SQLHelper.ExecuteDt(sql);

                sql = $@"select a.Id, a.MenuCode, a.MenuText, a.MenuName, a.ParentId, a.MenuImage, a.FromName, a.MenuNumber ,
                b.FrmType,b.FrmText,  STRING_AGG(ur.Id_Permision, ',') AS Id_Permision,a.OpenSource 
                from mst_menu a
                left join mst_from b on a.FromName = b.FrmName 
                inner join mst_UserRoles ur on a.Id = ur.Id_Menu and ur.del_flg = 0
                where ParentId != 0 and ur.MaNhanVien = {SQLHelper.rpStr(LoginInfo.UserCd)} 
                group by a.Id, a.MenuCode, a.MenuText, a.MenuName, a.ParentId, a.MenuImage, a.FromName, a.MenuNumber, b.FrmType, b.FrmText,a.OpenSource 
                order by a.MenuNumber desc";
                dt_MenuChild = SQLHelper.ExecuteDt(sql);
            }
            else
            {
                sql = $@"SELECT a.Id,a.MenuCode,a.MenuText,a.MenuName,a.ParentId,a.MenuImage, a.FromName,a.MenuNumber,b.FrmType, b.FrmText FROM mst_Menu a
	            LEFT JOIN mst_from b ON a.FromName = b.FrmName
		        WHERE a.ParentId = 0 ORDER BY a.MenuNumber DESC";
                dt_MenuParent = SQLHelper.ExecuteDt(sql);

                sql = $@"select a.Id, a.MenuCode, a.MenuText, a.MenuName, a.ParentId, a.MenuImage, a.FromName, a.MenuNumber ,
                    b.FrmType,b.FrmText,a.OpenSource  
                    from mst_menu a
                    left join mst_from b on a.FromName = b.FrmName 
                    where ParentId != 0 
                    order by a.MenuNumber desc";
                dt_MenuChild = SQLHelper.ExecuteDt(sql);
            }

            foreach (DataRow item in dt_MenuParent.Rows)
            {
                int Height = 0;
                var chil = dt_MenuChild.Rows.Cast<DataRow>().Where(x => x["ParentId"].ToString() == item["ID"].ToString()).ToList();
                int children = 0;
                Panel panel = new Panel
                {
                    Dock = DockStyle.Top,
                    MinimumSize = new Size(248, 30)
                };

                foreach (var itemchil in chil)
                {
                    IconButton btn_chil = new IconButton()
                    {
                        IconColor = Colors.ColorRGB10,
                        IconSize = 25,
                        TextImageRelation = TextImageRelation.ImageBeforeText,
                        IconChar = GetUIFontAwesome(itemchil["MenuImage"].ToString()),
                        Padding = new Padding(10, 0, 0, 0),
                        Tag = itemchil["Id"].ToString(),
                        Name = itemchil["MenuName"].ToString(),
                        ForeColor = Colors.ColorRGB10,
                        ImageAlign = ContentAlignment.MiddleLeft,
                        Height = 30,
                        //Font = new Font(Font.FontFamily, emSize: 10f, FontStyle.Bold, unit: GraphicsUnit.Point),
                        Font = new Font("Arial", emSize: 9, FontStyle.Bold, unit: GraphicsUnit.Point),
                        Dock = DockStyle.Top,
                        FlatStyle = FlatStyle.Flat,
                        Text = itemchil["MenuText"].ToString(),
                        TextAlign = ContentAlignment.MiddleLeft,
                        UseVisualStyleBackColor = false,
                    };

                    btn_chil.MouseEnter += (s, e) => btn_chil.ForeColor = Colors.ColorRGB8;
                    btn_chil.MouseLeave += (s, e) => btn_chil.ForeColor = Colors.ColorRGB10;

                    btn_chil.FlatAppearance.BorderColor = Colors.ColorRGB9;
                    btn_chil.Click += BtnChil_Click;
                    panel.Controls.Add(btn_chil);
                    Height += 30;
                    children++;
                }

                IconButton btn = new IconButton()
                {
                    IconColor = Colors.ColorRGB8,
                    Tag = item["Id"].ToString(),
                    Name = item["MenuName"].ToString(),
                    ForeColor = Colors.ColorRGB8,
                    ImageAlign = ContentAlignment.MiddleRight,
                    Height = 30,
                    //Font = new Font(Font.FontFamily, emSize: 12f, FontStyle.Bold, unit: GraphicsUnit.Point),
                    Font = new Font("Arial", emSize: 12f, FontStyle.Bold, unit: GraphicsUnit.Point),
                    Dock = DockStyle.Top,
                    FlatStyle = FlatStyle.Flat,
                    Text = item["MenuText"].ToString(),
                    TextAlign = ContentAlignment.MiddleLeft,
                    UseVisualStyleBackColor = false,
                };
                tagList.Add(item["Id"].ToString());
                if (children > 0)
                {
                    // btn.Image = Properties.Resources.up_arrow;
                    btn.IconChar = IconChar.ChevronDown;
                    btn.IconSize = 12;
                    btn.IconColor = Colors.ColorRGB8;
                }

                btn.FlatAppearance.BorderColor = Colors.ColorRGB9;

                btn.Click += Btn_Click;
                panel.Controls.Add(btn);
                Height += 32;
                panel.Size = new Size(248, 30);
                panel.MaximumSize = new Size(248, Height);
                panel.MinimumSize = new Size(248, 30);
                pl_MenuLeft.Controls.Add(panel);

                //Custom.RJButton danhmuc = new Custom.RJButton
                //{
                //    Name = item["MenuName"].ToString(),
                //    Text = "",
                //    Tag = item["Id"].ToString(),
                //    BackGroundColor = Color.CornflowerBlue,
                //    BackColor = Color.CornflowerBlue,
                //    BorderColor = Color.LightSkyBlue,
                //    Dock = DockStyle.Top,
                //    FlatStyle = FlatStyle.Flat,
                //    Image = (Bitmap)Resources.ResourceManager.GetObject(item["MenuImage"].ToString()),
                //    ImageAlign = ContentAlignment.MiddleLeft,
                //    TextAlign = ContentAlignment.MiddleCenter,
                //    TextImageRelation = TextImageRelation.ImageBeforeText,
                //    BorderSize = 1,
                //    UseVisualStyleBackColor = false,
                //    BorderRadius = 0,
                //    Font = new Font(Font.FontFamily, emSize: 10f, FontStyle.Bold, unit: GraphicsUnit.Point),
                //    Height = 55,
                //};
                //danhmuc.Click += btn_Menu_Click;
                //splitContainer1.Panel2.Controls.Add(danhmuc);
            }
        }
        private void BtnChil_Click(object sender, EventArgs e)
        {
            Cursor.Current = Cursors.WaitCursor;
            btn_IdClick = ((IconButton)sender).Tag.ToString();
            var name_parent = dt_MenuChild.Rows.Cast<DataRow>().Where(x => x["Id"].ToString() == btn_IdClick).FirstOrDefault();

            if (name_parent["OpenSource"].ToString() == "True")
            {
                string userProfile = Environment.GetFolderPath(Environment.SpecialFolder.UserProfile);
                //var menuStartStrings = userProfile + @"\AppData\Roaming\Microsoft\Windows\Start Menu\Programs\TENTAC(HO CHI MINH)\勤怠管理.appref-ms";
                var menuStartStrings = @"I:\XoaDuLieuMayChamCong\XoaDuLieuMayChamCong\XoaDuLieuMayChamCong\bin\Debug\勤怠管理.exe";
                var startParam = $"-tangca {name_parent["FromName"]}";
                // 起動パラメータをDictionaryに変換し展開する
                Dictionary<string, string> argsDic = new Dictionary<string, string>();
                argsDic = ParamUtil.ConvertParamToDictionary(SplitUtil.SplitStringWithSeparator(startParam, ' '));
                string startParameter = "";
                string param;
                // Enclose startup parameters that include spaces in double quotes.
                foreach (KeyValuePair<string, string> item in argsDic)
                {
                    startParameter = startParameter + item.Key + " " + SetDoublequotation(item.Value, 0) + " ";
                }
                // ClickOnceでインストールされたアプリケーションを起動する場合はダブルクォーテーションで囲む
                param = startParameter;
                //param = "\"" + startParameter + " \"";
                Process.Start(menuStartStrings, param);
            }

            if (_btn_show_menu_left == true)
            {
                if (name_parent != null)
                    lbl_title_menu.Text = name_parent["MenuText"].ToString();
            }
            else
            {
                lbl_title_menu.Text = "";
            }
            if (!string.IsNullOrEmpty(name_parent["FromName"].ToString()) && name_parent["OpenSource"].ToString() != "True")
            {
                Open_From(sender, e, false);
            }
            ActivateButton(sender, Colors.ColorRGB1);
            Cursor.Current = Cursors.Default;
        }
        private string SetDoublequotation(string parm, int co_kubun)
        {
            if (parm.IndexOf(" ") >= 0 | parm.IndexOf("　") >= 0)
            {
                if (co_kubun == 0)
                {
                    return "\"\"" + parm + "\"\"";
                }
                else
                {
                    return "\"" + parm + "\"";
                }
            }
            else
            {
                return parm;
            }
        }
        //private struct RGBColors
        //{
        //    public static Color color1 = Color.FromArgb(172, 126, 241);
        //    public static Color color2 = Color.FromArgb(249, 118, 176);
        //    public static Color color3 = Color.FromArgb(253, 138, 114);
        //    public static Color color4 = Color.FromArgb(95, 77, 221);
        //    public static Color color5 = Color.FromArgb(249, 88, 155);
        //    public static Color color6 = Color.FromArgb(24, 161, 251);
        //}
        private void ActivateButton(object senderBtn, Color color)
        {
            if (senderBtn != null && isMinisize == false)
            {
                DisableButton();
                currentBtn = (IconButton)senderBtn;
                currentBtn.BackColor = Colors.ColorRGB12;
                currentBtn.ForeColor = Colors.ColorRGB0;
                currentBtn.TextAlign = ContentAlignment.MiddleCenter;
                currentBtn.IconColor = Colors.ColorRGB8;
                currentBtn.TextImageRelation = TextImageRelation.TextBeforeImage;
                currentBtn.ImageAlign = ContentAlignment.MiddleCenter;
            }
            else
            {
                DisableButton();
                currentBtn = (IconButton)senderBtn;
                currentBtn.BackColor = Colors.ColorRGB12;
                currentBtn.ForeColor = Colors.ColorRGB0;
                currentBtn.TextAlign = ContentAlignment.MiddleLeft;
                currentBtn.IconColor = Colors.ColorRGB8;
                currentBtn.TextImageRelation = TextImageRelation.ImageBeforeText;
                currentBtn.ImageAlign = ContentAlignment.MiddleLeft;
            }
        }
        private void DisableButton()
        {
            if (currentBtn != null)
            {
                currentBtn.BackColor = Colors.ColorRGB9;
                currentBtn.ForeColor = Colors.ColorRGB10;
                currentBtn.TextAlign = ContentAlignment.MiddleLeft;
                currentBtn.IconColor = Colors.ColorRGB10;
                currentBtn.TextImageRelation = TextImageRelation.ImageBeforeText;
                currentBtn.ImageAlign = ContentAlignment.MiddleLeft;
            }
        }
        private void Btn_Click(object sender, EventArgs e)
        {
            btn_IdClick = ((IconButton)sender).Tag.ToString();
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
                panel_menu = (Panel)((IconButton)sender).Parent;
                btn_menu = (IconButton)sender;
                start_timermenu();
            }
        }
        public void start_timermenu()
        {
            if (panel_menu.Size == panel_menu.MaximumSize)
            {
                isCollapsedMenu = false;
            }
            else if (panel_menu.Size == panel_menu.MinimumSize)
            {
                isCollapsedMenu = true;
            }
            timer2.Start();
        }

        DataTable dt_MenuChild = new DataTable();
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
                //splitContainer1.Panel1.Controls.Clear();
                string sql = $@"select a.*,b.FrmType,b.FrmText
                             from mst_menu a
                             left join mst_from b on a.FromName = b.FrmName
                             where ParentId = '{((Custom.RJButton)sender).Tag}' order by a.MenuNumber desc";
                dt_MenuChild = SQLHelper.ExecuteDt(sql);
                foreach (DataRow item in dt_MenuChild.Rows)
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
                        Text = item["MenuText"].ToString(),
                        Tag = item["Id"].ToString(),
                        //dantoc.Click += btn_dantoc_Click;
                        Image = (Bitmap)Resources.ResourceManager.GetObject(item["MenuImage"].ToString()),
                        ImageAlign = ContentAlignment.MiddleLeft,
                        TextImageRelation = TextImageRelation.ImageBeforeText,
                    };
                    bt.Click += Bt_Click;
                    ToolTip ToolTip1 = new ToolTip();
                    ToolTip1.SetToolTip(bt, item["MenuText"].ToString());
                    //splitContainer1.Panel1.Controls.Add(bt);
                }
            }
        }

        private void Bt_Click(object sender, EventArgs e)
        {
            Open_From(sender, e, false);
        }

        private void Open_From(object sender, EventArgs e, bool parent)
        {
            btn_IdClick = ((IconButton)sender).Tag.ToString();
            var name_parent = dt_MenuParent.Rows.Cast<DataRow>().Where(x => x["Id"].ToString() == btn_IdClick).FirstOrDefault();
            if (parent == false)
            {
                name_parent = dt_MenuChild.Rows.Cast<DataRow>().Where(x => x["Id"].ToString() == btn_IdClick).FirstOrDefault();
            }
            if (name_parent != null)
            {
                int[] idPermision = new int[0];
                if (LoginInfo.Group != "ADMIN")
                {
                    string idPermisionStr = name_parent["Id_Permision"].ToString();
                    idPermision = idPermisionStr.Split(',').Select(int.Parse).ToArray();
                }
                if (name_parent["FrmType"].ToString() == "uc")
                {
                    isPresent = false;
                    string text_tab = name_parent["FrmText"].ToString();
                    UserControl user = new UserControl();
                    //user = uc_nhan_su.Instance;
                    var type = Type.GetType("TENTAC_HRM.Forms." + name_parent["MenuCode"]?.ToString() + name_parent["FromName"]?.ToString());
                    if (type != null)
                    {
                        var constructor = type.GetConstructor(new[] { typeof(int[]) });
                        if (constructor != null)
                        {
                            user = Activator.CreateInstance(type, idPermision) as UserControl;
                        }
                        else
                        {
                            user = Activator.CreateInstance(type) as UserControl;
                        }
                    }
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
                        TabPage tp = new TabPage(text_tab)
                        {
                            Name = "tp_" + name_parent["FromName"]
                        };
                        Panel tb = new Panel
                        {
                            Dock = DockStyle.Fill,
                            Name = "pl_" + name_parent["FromName"]
                        };

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
                    //var form = Activator.CreateInstance(Type.GetType("TENTAC_HRM.Forms." + name_parent["MenuCode"].ToString() + name_parent["FromName"].ToString())) as Form;
                    //form.ShowDialog();
                    var formType = Type.GetType("TENTAC_HRM.Forms." + name_parent["MenuCode"].ToString() + name_parent["FromName"].ToString());
                    if (formType != null)
                    {
                        var form = Activator.CreateInstance(formType, idPermision) as Form;
                        form.ShowDialog();
                    }
                }
            }
        }
        bool maximized = false;

        private void MaximizeWindow()
        {
            maximized = true;
            //var rectangle = Screen.FromControl(this).Bounds;
            //Size = new Size(rectangle.Width, rectangle.Height);
            Location = new Point(0, 0);
            Rectangle workingRectangle = Screen.PrimaryScreen.WorkingArea;
            this.Size = new Size(workingRectangle.Width, workingRectangle.Height);

            pl_menu_left.MaximumSize = new Size(248, this.Height - 30);
            pl_menu_left.MinimumSize = new Size(63, this.Height - 30);
            //splitContainer1.Panel1MinSize = splitContainer1.Size.Height - 755;
            //splitContainer1.Panel2MinSize = splitContainer1.Size.Height - (splitContainer1.Size.Height - 740);
        }
        //private void ResizableWindow()
        //{
        //    this.ControlBox = false;
        //    this.FormBorderStyle = FormBorderStyle.SizableToolWindow;
        //}

        //public void Remove_tabpage()
        //{
        //    tb_main.TabPages.RemoveByKey("tp_nhansu");
        //}

        private void frm_home_Load(object sender, EventArgs e)
        {
            ts_user.Text = LoginInfo.UserCd + "-" + LoginInfo.TenNhanVien;
            pl_sn.Height = 0;
            pl_nv_moi.Height = 0;
            pl_hopdong.Height = 0;
            Load_sinhnhat();
            Load_ngayhet_hopdong();
            Load_nv_moi();

            tb_main.Padding = new Point(20, 4);

            pl_menu_left.MaximumSize = new Size(248, this.Height - 30);
            pl_menu_left.MinimumSize = new Size(63, this.Height - 30);
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
        private void Load_nv_moi()
        {
            string sql = "select manhanvien,TenNhanVien,ngayvaolamviec from MITACOSQL.dbo.NHANVIEN where datediff(day,ngayvaolamviec,GETDATE()) <= 10";
            DataTable dt = SQLHelper.ExecuteDt(sql);
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

        private void Load_sinhnhat()
        {
            string sql = "select MaNhanVien,TenNhanVien,NgaySinh from MITACOSQL.dbo.NHANVIEN where MONTH(NgaySinh) = MONTH(GETDATE()) and MaCongTy is not null";
            DataTable dt = SQLHelper.ExecuteDt(sql);
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
        private void Load_ngayhet_hopdong()
        {
            string sql = @"select nhanvien.MaNhanVien,nhanvien.TenNhanVien,a.denngay as ngay_het_han from MITACOSQL.dbo.NHANVIEN nhanvien
                left join [tbl_NhanVienHopDong] a on a.manhanvien = nhanvien.MaNhanVien
                join mst_LoaiHopDong b on a.id_loaihopdong = b.id and b.id in (2,3)
                where datediff(day,GETDATE(),a.denngay) <= 10";
            DataTable dt = SQLHelper.ExecuteDt(sql);
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
                //foreach (Control item in splitContainer1.Panel2.Controls)
                //{
                //    item.Text = "";
                //}
                //foreach (Control item in splitContainer1.Panel1.Controls)
                //{
                //    item.Text = "";
                //}
                foreach (Control item in pl_MenuLeft.Controls)
                {
                    if (item.HasChildren)
                    {
                        foreach (Control childControl in item.Controls)
                        {
                            if (childControl is IconButton btn)
                            {
                                btn.Size = new Size(30, 30);
                                btn.ImageAlign = ContentAlignment.MiddleLeft;
                                btn.Text = "";
                                var parentId = btn.Tag?.ToString();
                                var parent = dt_MenuParent.Rows.Cast<DataRow>()
                                    .FirstOrDefault(x => x["Id"].ToString() == parentId);
                                if (parent != null)
                                {
                                    btn.IconChar = GetUIFontAwesome(parent["MenuImage"].ToString());
                                    btn.IconSize = 32;
                                }
                            }
                        }
                    }
                }
                isMinisize = true;
                isCollapsed = false;
                _btn_show_menu_left = false;
            }
            else if (pl_menu_left.Size == pl_menu_left.MinimumSize)
            {
                //foreach (Control item in splitContainer1.Panel1.Controls)
                //{
                //    var names = dt_Menu_child.Rows.Cast<DataRow>().Where(x => x["Id"].ToString() == item.Tag.ToString()).FirstOrDefault();
                //    item.Text = "  " + names["MenuText"].ToString();
                //}

                isMinisize = false;
                isCollapsed = true;
                _btn_show_menu_left = true;

                var name_parent = dt_MenuParent.Rows.Cast<DataRow>().Where(x => x["Id"].ToString() == btn_IdClick).FirstOrDefault();
                if (name_parent != null)
                    lbl_title_menu.Text = name_parent["MenuText"].ToString();

                foreach (Control item in pl_MenuLeft.Controls)
                {
                    if (item.HasChildren)
                    {
                        int countChil = 0;
                        foreach (Control childControl in item.Controls)
                        {
                            if (childControl is IconButton btn)
                            {
                                if (btn.Name == "LogOut")
                                {
                                    btn.Size = new Size(30, 30);
                                    var Id = btn.Tag?.ToString();
                                    btn.ImageAlign = ContentAlignment.MiddleLeft;

                                    btn.Text = "LogOut";
                                    btn.IconChar = IconChar.RightFromBracket;
                                    btn.IconSize = 25;
                                    btn.IconColor = Colors.ColorRGB8;
                                    btn.ImageAlign = ContentAlignment.MiddleRight;
                                }
                                else
                                {
                                    btn.Size = new Size(30, 30);
                                    var Id = btn.Tag?.ToString();
                                    btn.ImageAlign = ContentAlignment.MiddleLeft;

                                    var chil = dt_MenuChild.Rows.Cast<DataRow>().FirstOrDefault(x => x["Id"].ToString() == Id);
                                    btn.Text = chil?["MenuText"].ToString() ?? "";
                                    if (chil != null) countChil++;

                                    var parent = dt_MenuParent.Rows.Cast<DataRow>().FirstOrDefault(x => x["Id"].ToString() == Id);
                                    if (parent != null)
                                    {
                                        btn.Text = parent["MenuText"].ToString();
                                        btn.IconChar = countChil >= 1 ? IconChar.ChevronDown : IconChar.None;
                                        btn.IconSize = 12;
                                        btn.IconColor = Colors.ColorRGB8;
                                        btn.ImageAlign = ContentAlignment.MiddleRight;
                                    }
                                }
                            }
                        }
                    }
                }
                //foreach (Control item in splitContainer1.Panel2.Controls)
                //{
                //    var names = dt_MenuParent.Rows.Cast<DataRow>().Where(x => x["Id"].ToString() == item.Tag.ToString()).FirstOrDefault();
                //    item.Text = "  " + names["MenuText"].ToString();
                //}
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
            Application.Exit();
        }

        private void btn_minimize_Click(object sender, EventArgs e)
        {
            WindowState = FormWindowState.Minimized;
        }

        private void btn_maxximize_Click(object sender, EventArgs e)
        {
            //pl_MenuLeft.Dock = DockStyle.Fill;
            //pl_menu_left.Dock = DockStyle.Left;
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

                pl_menu_left.MaximumSize = new Size(248, this.Height - 30);
                pl_menu_left.MinimumSize = new Size(63, this.Height - 30);
                //splitContainer1.Panel1MinSize = splitContainer1.Size.Height - 755;
                //splitContainer1.Panel2MinSize = splitContainer1.Size.Height - (splitContainer1.Size.Height - 740);
                //splitContainer1.Panel2MinSize = splitContainer1.Size.Height - splitContainer1.Panel1MinSize - 5;
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
                btn_close_notifi.IconChar = IconChar.UpRightFromSquare;
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
                btn_close_notifi.IconChar = IconChar.UpRightFromSquare;
                pl_menu.Location = new Point(this.Width - 429, this.Height - 56);
                pl_menu.Width = 429;
                pl_menu.Height = 32;
                pl_menu.Visible = false;
            }
            else
            {
                notifi_hide = true;
                btn_close_notifi.IconChar = IconChar.Xmark;
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

        private void timer2_Tick(object sender, EventArgs e)
        {
            if (isCollapsedMenu)
            {
                if (isMinisize == false)
                {
                    btn_menu.IconChar = IconChar.ChevronUp;
                    btn_menu.IconSize = 12;
                }
                //btn_menu.Image = Resources.up_arrow;

                panel_menu.Height += 10;
                if (panel_menu.Size == panel_menu.MaximumSize)
                {
                    timer2.Stop();
                    isCollapsedMenu = false;
                }
            }
            else
            {
                //btn_menu.Image = Resources.dow_arrow;
                if (isMinisize == false)
                {
                    btn_menu.IconChar = IconChar.ChevronDown;
                    btn_menu.IconSize = 12;
                }
                panel_menu.Height -= 10;
                if (panel_menu.Size == panel_menu.MinimumSize)
                {
                    timer2.Stop();
                    isCollapsedMenu = true;
                }
            }
        }

        private void btn_SignOut_Click(object sender, EventArgs e)
        {
            this.Hide();
            frm_login frm = new frm_login();
            frm.Show();
        }
    }
}