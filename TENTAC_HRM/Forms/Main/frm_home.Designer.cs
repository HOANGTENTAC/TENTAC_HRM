namespace TENTAC_HRM.Forms.Main
{
    partial class frm_home
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frm_home));
            this.tb_main = new System.Windows.Forms.TabControl();
            this.tb_dashboard = new System.Windows.Forms.TabPage();
            this.pl_dashboard = new System.Windows.Forms.Panel();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.tm_menu_left = new System.Windows.Forms.Timer(this.components);
            this.panel1 = new System.Windows.Forms.Panel();
            this.panel3 = new System.Windows.Forms.Panel();
            this.pl_menu_left = new System.Windows.Forms.Panel();
            this.pl_MenuLeft = new System.Windows.Forms.Panel();
            this.panel2 = new System.Windows.Forms.Panel();
            this.btn_show_menu_left = new System.Windows.Forms.Button();
            this.lbl_title_menu = new System.Windows.Forms.Label();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.toolStripStatusLabel1 = new System.Windows.Forms.ToolStripStatusLabel();
            this.ts_user = new System.Windows.Forms.ToolStripStatusLabel();
            this.ts_date = new System.Windows.Forms.ToolStripStatusLabel();
            this.pl_menu = new System.Windows.Forms.Panel();
            this.pl_menu_sub = new System.Windows.Forms.Panel();
            this.pl_nv_moi = new System.Windows.Forms.Panel();
            this.lv_nv_moi = new System.Windows.Forms.ListView();
            this.columnHeader7 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader8 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader9 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.panel4 = new System.Windows.Forms.Panel();
            this.lb_title_nv_moi = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.button3 = new System.Windows.Forms.Button();
            this.lb_nv_moi = new System.Windows.Forms.Label();
            this.pl_hopdong = new System.Windows.Forms.Panel();
            this.lv_hopdong_hethan = new System.Windows.Forms.ListView();
            this.columnHeader4 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader5 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader6 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.pl_menu_hopdong = new System.Windows.Forms.Panel();
            this.lb_title_hopdong = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.lb_hop_dong = new System.Windows.Forms.Label();
            this.pl_sn = new System.Windows.Forms.Panel();
            this.lv_sinhnhat = new System.Windows.Forms.ListView();
            this.columnHeader1 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader2 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader3 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.panel5 = new System.Windows.Forms.Panel();
            this.lb_title_notifi = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.button2 = new System.Windows.Forms.Button();
            this.lb_menu_sn = new System.Windows.Forms.Label();
            this.panel6 = new System.Windows.Forms.Panel();
            this.label1 = new System.Windows.Forms.Label();
            this.btn_close_notifi = new FontAwesome.Sharp.IconButton();
            this.tm_notifi = new System.Windows.Forms.Timer(this.components);
            this.menustrip_tabpage = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.btn_close_all = new System.Windows.Forms.ToolStripMenuItem();
            this.closeAllButThisToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.iconMenuItem1 = new FontAwesome.Sharp.IconMenuItem();
            this.hệThốngToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.trợGiúpToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.btn_exit = new FontAwesome.Sharp.IconMenuItem();
            this.btn_maxximize = new FontAwesome.Sharp.IconMenuItem();
            this.btn_minimize = new FontAwesome.Sharp.IconMenuItem();
            this.btn_notifi = new FontAwesome.Sharp.IconMenuItem();
            this.timer2 = new System.Windows.Forms.Timer(this.components);
            this.tb_main.SuspendLayout();
            this.tb_dashboard.SuspendLayout();
            this.panel1.SuspendLayout();
            this.panel3.SuspendLayout();
            this.pl_menu_left.SuspendLayout();
            this.panel2.SuspendLayout();
            this.statusStrip1.SuspendLayout();
            this.pl_menu.SuspendLayout();
            this.pl_menu_sub.SuspendLayout();
            this.pl_nv_moi.SuspendLayout();
            this.panel4.SuspendLayout();
            this.pl_hopdong.SuspendLayout();
            this.pl_menu_hopdong.SuspendLayout();
            this.pl_sn.SuspendLayout();
            this.panel5.SuspendLayout();
            this.panel6.SuspendLayout();
            this.menustrip_tabpage.SuspendLayout();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // tb_main
            // 
            this.tb_main.CausesValidation = false;
            this.tb_main.Controls.Add(this.tb_dashboard);
            this.tb_main.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tb_main.DrawMode = System.Windows.Forms.TabDrawMode.OwnerDrawFixed;
            this.tb_main.Location = new System.Drawing.Point(203, 0);
            this.tb_main.Margin = new System.Windows.Forms.Padding(3, 0, 3, 3);
            this.tb_main.Name = "tb_main";
            this.tb_main.SelectedIndex = 0;
            this.tb_main.ShowToolTips = true;
            this.tb_main.Size = new System.Drawing.Size(1037, 783);
            this.tb_main.TabIndex = 1;
            this.tb_main.DrawItem += new System.Windows.Forms.DrawItemEventHandler(this.tb_main_DrawItem);
            this.tb_main.MouseClick += new System.Windows.Forms.MouseEventHandler(this.tb_main_MouseClick);
            this.tb_main.MouseUp += new System.Windows.Forms.MouseEventHandler(this.tb_main_MouseUp);
            // 
            // tb_dashboard
            // 
            this.tb_dashboard.Controls.Add(this.pl_dashboard);
            this.tb_dashboard.Location = new System.Drawing.Point(4, 22);
            this.tb_dashboard.Name = "tb_dashboard";
            this.tb_dashboard.Padding = new System.Windows.Forms.Padding(3);
            this.tb_dashboard.Size = new System.Drawing.Size(1029, 757);
            this.tb_dashboard.TabIndex = 0;
            this.tb_dashboard.Text = "Bàn làm việc";
            this.tb_dashboard.UseVisualStyleBackColor = true;
            // 
            // pl_dashboard
            // 
            this.pl_dashboard.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pl_dashboard.Location = new System.Drawing.Point(3, 3);
            this.pl_dashboard.Name = "pl_dashboard";
            this.pl_dashboard.Size = new System.Drawing.Size(1023, 751);
            this.pl_dashboard.TabIndex = 0;
            // 
            // timer1
            // 
            this.timer1.Enabled = true;
            this.timer1.Interval = 1000;
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // tm_menu_left
            // 
            this.tm_menu_left.Interval = 5;
            this.tm_menu_left.Tick += new System.EventHandler(this.tm_menu_left_Tick);
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.panel3);
            this.panel1.Controls.Add(this.statusStrip1);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(0, 30);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1240, 805);
            this.panel1.TabIndex = 7;
            // 
            // panel3
            // 
            this.panel3.Controls.Add(this.tb_main);
            this.panel3.Controls.Add(this.pl_menu_left);
            this.panel3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel3.Location = new System.Drawing.Point(0, 0);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(1240, 783);
            this.panel3.TabIndex = 8;
            // 
            // pl_menu_left
            // 
            this.pl_menu_left.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(18)))), ((int)(((byte)(39)))), ((int)(((byte)(75)))));
            this.pl_menu_left.Controls.Add(this.pl_MenuLeft);
            this.pl_menu_left.Controls.Add(this.panel2);
            this.pl_menu_left.Dock = System.Windows.Forms.DockStyle.Left;
            this.pl_menu_left.Location = new System.Drawing.Point(0, 0);
            this.pl_menu_left.MaximumSize = new System.Drawing.Size(203, 0);
            this.pl_menu_left.MinimumSize = new System.Drawing.Size(63, 0);
            this.pl_menu_left.Name = "pl_menu_left";
            this.pl_menu_left.Padding = new System.Windows.Forms.Padding(1);
            this.pl_menu_left.Size = new System.Drawing.Size(203, 783);
            this.pl_menu_left.TabIndex = 6;
            // 
            // pl_MenuLeft
            // 
            this.pl_MenuLeft.AutoScroll = true;
            this.pl_MenuLeft.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(18)))), ((int)(((byte)(39)))), ((int)(((byte)(75)))));
            this.pl_MenuLeft.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pl_MenuLeft.Location = new System.Drawing.Point(1, 29);
            this.pl_MenuLeft.Name = "pl_MenuLeft";
            this.pl_MenuLeft.Size = new System.Drawing.Size(201, 753);
            this.pl_MenuLeft.TabIndex = 0;
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.SystemColors.MenuHighlight;
            this.panel2.Controls.Add(this.btn_show_menu_left);
            this.panel2.Controls.Add(this.lbl_title_menu);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel2.Location = new System.Drawing.Point(1, 1);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(201, 28);
            this.panel2.TabIndex = 0;
            // 
            // btn_show_menu_left
            // 
            this.btn_show_menu_left.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btn_show_menu_left.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(18)))), ((int)(((byte)(39)))), ((int)(((byte)(75)))));
            this.btn_show_menu_left.FlatAppearance.BorderSize = 0;
            this.btn_show_menu_left.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_show_menu_left.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold);
            this.btn_show_menu_left.ForeColor = System.Drawing.Color.WhiteSmoke;
            this.btn_show_menu_left.Location = new System.Drawing.Point(170, 0);
            this.btn_show_menu_left.Name = "btn_show_menu_left";
            this.btn_show_menu_left.Size = new System.Drawing.Size(31, 28);
            this.btn_show_menu_left.TabIndex = 0;
            this.btn_show_menu_left.Text = ">>";
            this.btn_show_menu_left.UseVisualStyleBackColor = false;
            this.btn_show_menu_left.Click += new System.EventHandler(this.btn_show_menu_left_Click);
            // 
            // lbl_title_menu
            // 
            this.lbl_title_menu.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(18)))), ((int)(((byte)(39)))), ((int)(((byte)(75)))));
            this.lbl_title_menu.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lbl_title_menu.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold);
            this.lbl_title_menu.ForeColor = System.Drawing.Color.WhiteSmoke;
            this.lbl_title_menu.Location = new System.Drawing.Point(0, 0);
            this.lbl_title_menu.MaximumSize = new System.Drawing.Size(175, 0);
            this.lbl_title_menu.MinimumSize = new System.Drawing.Size(0, 28);
            this.lbl_title_menu.Name = "lbl_title_menu";
            this.lbl_title_menu.Size = new System.Drawing.Size(175, 28);
            this.lbl_title_menu.TabIndex = 0;
            this.lbl_title_menu.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // statusStrip1
            // 
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripStatusLabel1,
            this.ts_user,
            this.ts_date});
            this.statusStrip1.Location = new System.Drawing.Point(0, 783);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(1240, 22);
            this.statusStrip1.TabIndex = 3;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // toolStripStatusLabel1
            // 
            this.toolStripStatusLabel1.Image = ((System.Drawing.Image)(resources.GetObject("toolStripStatusLabel1.Image")));
            this.toolStripStatusLabel1.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.toolStripStatusLabel1.Name = "toolStripStatusLabel1";
            this.toolStripStatusLabel1.Size = new System.Drawing.Size(90, 17);
            this.toolStripStatusLabel1.Text = "Người dùng:";
            // 
            // ts_user
            // 
            this.ts_user.Name = "ts_user";
            this.ts_user.Size = new System.Drawing.Size(41, 17);
            this.ts_user.Text = "admin";
            // 
            // ts_date
            // 
            this.ts_date.Image = ((System.Drawing.Image)(resources.GetObject("ts_date.Image")));
            this.ts_date.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.ts_date.Name = "ts_date";
            this.ts_date.Size = new System.Drawing.Size(1094, 17);
            this.ts_date.Spring = true;
            this.ts_date.Text = "2023/07/13";
            this.ts_date.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // pl_menu
            // 
            this.pl_menu.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.pl_menu.BackColor = System.Drawing.SystemColors.Highlight;
            this.pl_menu.Controls.Add(this.pl_menu_sub);
            this.pl_menu.Location = new System.Drawing.Point(808, 423);
            this.pl_menu.Margin = new System.Windows.Forms.Padding(0);
            this.pl_menu.Name = "pl_menu";
            this.pl_menu.Padding = new System.Windows.Forms.Padding(1);
            this.pl_menu.Size = new System.Drawing.Size(429, 385);
            this.pl_menu.TabIndex = 2;
            this.pl_menu.Visible = false;
            // 
            // pl_menu_sub
            // 
            this.pl_menu_sub.BackColor = System.Drawing.SystemColors.Window;
            this.pl_menu_sub.Controls.Add(this.pl_nv_moi);
            this.pl_menu_sub.Controls.Add(this.panel4);
            this.pl_menu_sub.Controls.Add(this.pl_hopdong);
            this.pl_menu_sub.Controls.Add(this.pl_menu_hopdong);
            this.pl_menu_sub.Controls.Add(this.pl_sn);
            this.pl_menu_sub.Controls.Add(this.panel5);
            this.pl_menu_sub.Controls.Add(this.panel6);
            this.pl_menu_sub.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pl_menu_sub.Location = new System.Drawing.Point(1, 1);
            this.pl_menu_sub.Name = "pl_menu_sub";
            this.pl_menu_sub.Size = new System.Drawing.Size(427, 383);
            this.pl_menu_sub.TabIndex = 2;
            // 
            // pl_nv_moi
            // 
            this.pl_nv_moi.Controls.Add(this.lv_nv_moi);
            this.pl_nv_moi.Dock = System.Windows.Forms.DockStyle.Top;
            this.pl_nv_moi.Location = new System.Drawing.Point(0, 177);
            this.pl_nv_moi.MaximumSize = new System.Drawing.Size(427, 150);
            this.pl_nv_moi.MinimumSize = new System.Drawing.Size(427, 0);
            this.pl_nv_moi.Name = "pl_nv_moi";
            this.pl_nv_moi.Size = new System.Drawing.Size(427, 23);
            this.pl_nv_moi.TabIndex = 10;
            // 
            // lv_nv_moi
            // 
            this.lv_nv_moi.AccessibleDescription = "btn_close_all_but_this";
            this.lv_nv_moi.Activation = System.Windows.Forms.ItemActivation.OneClick;
            this.lv_nv_moi.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.lv_nv_moi.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader7,
            this.columnHeader8,
            this.columnHeader9});
            this.lv_nv_moi.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lv_nv_moi.FullRowSelect = true;
            this.lv_nv_moi.GridLines = true;
            this.lv_nv_moi.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.None;
            this.lv_nv_moi.HideSelection = false;
            this.lv_nv_moi.HoverSelection = true;
            this.lv_nv_moi.Location = new System.Drawing.Point(0, 0);
            this.lv_nv_moi.Name = "lv_nv_moi";
            this.lv_nv_moi.Size = new System.Drawing.Size(427, 23);
            this.lv_nv_moi.TabIndex = 0;
            this.lv_nv_moi.UseCompatibleStateImageBehavior = false;
            this.lv_nv_moi.View = System.Windows.Forms.View.Details;
            // 
            // columnHeader7
            // 
            this.columnHeader7.Text = "Mã nhân viên";
            this.columnHeader7.Width = 118;
            // 
            // columnHeader8
            // 
            this.columnHeader8.Text = "Họ tên";
            this.columnHeader8.Width = 185;
            // 
            // columnHeader9
            // 
            this.columnHeader9.Text = "Ngày hết hợp đồng";
            this.columnHeader9.Width = 121;
            // 
            // panel4
            // 
            this.panel4.BackColor = System.Drawing.Color.SkyBlue;
            this.panel4.Controls.Add(this.lb_title_nv_moi);
            this.panel4.Controls.Add(this.label5);
            this.panel4.Controls.Add(this.button3);
            this.panel4.Controls.Add(this.lb_nv_moi);
            this.panel4.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel4.Location = new System.Drawing.Point(0, 145);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(427, 32);
            this.panel4.TabIndex = 9;
            // 
            // lb_title_nv_moi
            // 
            this.lb_title_nv_moi.Dock = System.Windows.Forms.DockStyle.Left;
            this.lb_title_nv_moi.Location = new System.Drawing.Point(34, 0);
            this.lb_title_nv_moi.Name = "lb_title_nv_moi";
            this.lb_title_nv_moi.Size = new System.Drawing.Size(323, 32);
            this.lb_title_nv_moi.TabIndex = 6;
            this.lb_title_nv_moi.Text = "Nhân viên mới";
            this.lb_title_nv_moi.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label5
            // 
            this.label5.Dock = System.Windows.Forms.DockStyle.Left;
            this.label5.Image = global::TENTAC_HRM.Properties.Resources.grammar;
            this.label5.Location = new System.Drawing.Point(0, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(34, 32);
            this.label5.TabIndex = 5;
            this.label5.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // button3
            // 
            this.button3.BackColor = System.Drawing.Color.SkyBlue;
            this.button3.Dock = System.Windows.Forms.DockStyle.Right;
            this.button3.FlatAppearance.BorderSize = 0;
            this.button3.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button3.Image = global::TENTAC_HRM.Properties.Resources.export_excel;
            this.button3.Location = new System.Drawing.Point(363, 0);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(32, 32);
            this.button3.TabIndex = 4;
            this.button3.UseVisualStyleBackColor = false;
            // 
            // lb_nv_moi
            // 
            this.lb_nv_moi.Dock = System.Windows.Forms.DockStyle.Right;
            this.lb_nv_moi.Image = global::TENTAC_HRM.Properties.Resources.dow_arrow;
            this.lb_nv_moi.Location = new System.Drawing.Point(395, 0);
            this.lb_nv_moi.Name = "lb_nv_moi";
            this.lb_nv_moi.Size = new System.Drawing.Size(32, 32);
            this.lb_nv_moi.TabIndex = 0;
            this.lb_nv_moi.Click += new System.EventHandler(this.lb_nv_moi_Click);
            // 
            // pl_hopdong
            // 
            this.pl_hopdong.Controls.Add(this.lv_hopdong_hethan);
            this.pl_hopdong.Dock = System.Windows.Forms.DockStyle.Top;
            this.pl_hopdong.Location = new System.Drawing.Point(0, 122);
            this.pl_hopdong.MaximumSize = new System.Drawing.Size(427, 150);
            this.pl_hopdong.MinimumSize = new System.Drawing.Size(427, 0);
            this.pl_hopdong.Name = "pl_hopdong";
            this.pl_hopdong.Size = new System.Drawing.Size(427, 23);
            this.pl_hopdong.TabIndex = 8;
            // 
            // lv_hopdong_hethan
            // 
            this.lv_hopdong_hethan.Activation = System.Windows.Forms.ItemActivation.OneClick;
            this.lv_hopdong_hethan.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.lv_hopdong_hethan.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader4,
            this.columnHeader5,
            this.columnHeader6});
            this.lv_hopdong_hethan.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lv_hopdong_hethan.FullRowSelect = true;
            this.lv_hopdong_hethan.GridLines = true;
            this.lv_hopdong_hethan.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.None;
            this.lv_hopdong_hethan.HideSelection = false;
            this.lv_hopdong_hethan.HoverSelection = true;
            this.lv_hopdong_hethan.Location = new System.Drawing.Point(0, 0);
            this.lv_hopdong_hethan.Name = "lv_hopdong_hethan";
            this.lv_hopdong_hethan.Size = new System.Drawing.Size(427, 23);
            this.lv_hopdong_hethan.TabIndex = 0;
            this.lv_hopdong_hethan.UseCompatibleStateImageBehavior = false;
            this.lv_hopdong_hethan.View = System.Windows.Forms.View.Details;
            // 
            // columnHeader4
            // 
            this.columnHeader4.Text = "Mã nhân viên";
            this.columnHeader4.Width = 118;
            // 
            // columnHeader5
            // 
            this.columnHeader5.Text = "Họ tên";
            this.columnHeader5.Width = 185;
            // 
            // columnHeader6
            // 
            this.columnHeader6.Text = "Ngày hết hợp đồng";
            this.columnHeader6.Width = 121;
            // 
            // pl_menu_hopdong
            // 
            this.pl_menu_hopdong.BackColor = System.Drawing.Color.SkyBlue;
            this.pl_menu_hopdong.Controls.Add(this.lb_title_hopdong);
            this.pl_menu_hopdong.Controls.Add(this.label4);
            this.pl_menu_hopdong.Controls.Add(this.button1);
            this.pl_menu_hopdong.Controls.Add(this.lb_hop_dong);
            this.pl_menu_hopdong.Dock = System.Windows.Forms.DockStyle.Top;
            this.pl_menu_hopdong.Location = new System.Drawing.Point(0, 90);
            this.pl_menu_hopdong.Name = "pl_menu_hopdong";
            this.pl_menu_hopdong.Size = new System.Drawing.Size(427, 32);
            this.pl_menu_hopdong.TabIndex = 7;
            // 
            // lb_title_hopdong
            // 
            this.lb_title_hopdong.Dock = System.Windows.Forms.DockStyle.Left;
            this.lb_title_hopdong.Location = new System.Drawing.Point(34, 0);
            this.lb_title_hopdong.Name = "lb_title_hopdong";
            this.lb_title_hopdong.Size = new System.Drawing.Size(323, 32);
            this.lb_title_hopdong.TabIndex = 6;
            this.lb_title_hopdong.Text = "Hợp đồng hết hạn";
            this.lb_title_hopdong.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label4
            // 
            this.label4.Dock = System.Windows.Forms.DockStyle.Left;
            this.label4.Image = global::TENTAC_HRM.Properties.Resources.grammar;
            this.label4.Location = new System.Drawing.Point(0, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(34, 32);
            this.label4.TabIndex = 5;
            this.label4.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // button1
            // 
            this.button1.BackColor = System.Drawing.Color.SkyBlue;
            this.button1.Dock = System.Windows.Forms.DockStyle.Right;
            this.button1.FlatAppearance.BorderSize = 0;
            this.button1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button1.Image = global::TENTAC_HRM.Properties.Resources.export_excel;
            this.button1.Location = new System.Drawing.Point(363, 0);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(32, 32);
            this.button1.TabIndex = 4;
            this.button1.UseVisualStyleBackColor = false;
            // 
            // lb_hop_dong
            // 
            this.lb_hop_dong.Dock = System.Windows.Forms.DockStyle.Right;
            this.lb_hop_dong.Image = global::TENTAC_HRM.Properties.Resources.dow_arrow;
            this.lb_hop_dong.Location = new System.Drawing.Point(395, 0);
            this.lb_hop_dong.Name = "lb_hop_dong";
            this.lb_hop_dong.Size = new System.Drawing.Size(32, 32);
            this.lb_hop_dong.TabIndex = 0;
            this.lb_hop_dong.Click += new System.EventHandler(this.lb_hop_dong_Click);
            // 
            // pl_sn
            // 
            this.pl_sn.Controls.Add(this.lv_sinhnhat);
            this.pl_sn.Dock = System.Windows.Forms.DockStyle.Top;
            this.pl_sn.Location = new System.Drawing.Point(0, 64);
            this.pl_sn.MaximumSize = new System.Drawing.Size(427, 150);
            this.pl_sn.MinimumSize = new System.Drawing.Size(427, 0);
            this.pl_sn.Name = "pl_sn";
            this.pl_sn.Size = new System.Drawing.Size(427, 26);
            this.pl_sn.TabIndex = 5;
            // 
            // lv_sinhnhat
            // 
            this.lv_sinhnhat.Activation = System.Windows.Forms.ItemActivation.OneClick;
            this.lv_sinhnhat.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.lv_sinhnhat.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader1,
            this.columnHeader2,
            this.columnHeader3});
            this.lv_sinhnhat.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lv_sinhnhat.FullRowSelect = true;
            this.lv_sinhnhat.GridLines = true;
            this.lv_sinhnhat.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.None;
            this.lv_sinhnhat.HideSelection = false;
            this.lv_sinhnhat.HoverSelection = true;
            this.lv_sinhnhat.Location = new System.Drawing.Point(0, 0);
            this.lv_sinhnhat.Name = "lv_sinhnhat";
            this.lv_sinhnhat.Size = new System.Drawing.Size(427, 26);
            this.lv_sinhnhat.TabIndex = 0;
            this.lv_sinhnhat.UseCompatibleStateImageBehavior = false;
            this.lv_sinhnhat.View = System.Windows.Forms.View.Details;
            // 
            // columnHeader1
            // 
            this.columnHeader1.Text = "Mã nhân viên";
            this.columnHeader1.Width = 118;
            // 
            // columnHeader2
            // 
            this.columnHeader2.Text = "Họ tên";
            this.columnHeader2.Width = 185;
            // 
            // columnHeader3
            // 
            this.columnHeader3.Text = "Ngày sinh";
            this.columnHeader3.Width = 121;
            // 
            // panel5
            // 
            this.panel5.BackColor = System.Drawing.Color.SkyBlue;
            this.panel5.Controls.Add(this.lb_title_notifi);
            this.panel5.Controls.Add(this.label3);
            this.panel5.Controls.Add(this.button2);
            this.panel5.Controls.Add(this.lb_menu_sn);
            this.panel5.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel5.Location = new System.Drawing.Point(0, 32);
            this.panel5.Name = "panel5";
            this.panel5.Size = new System.Drawing.Size(427, 32);
            this.panel5.TabIndex = 6;
            // 
            // lb_title_notifi
            // 
            this.lb_title_notifi.Dock = System.Windows.Forms.DockStyle.Left;
            this.lb_title_notifi.Location = new System.Drawing.Point(34, 0);
            this.lb_title_notifi.Name = "lb_title_notifi";
            this.lb_title_notifi.Size = new System.Drawing.Size(323, 32);
            this.lb_title_notifi.TabIndex = 6;
            this.lb_title_notifi.Text = "Sinh nhật";
            this.lb_title_notifi.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label3
            // 
            this.label3.Dock = System.Windows.Forms.DockStyle.Left;
            this.label3.Image = global::TENTAC_HRM.Properties.Resources.giftbox;
            this.label3.Location = new System.Drawing.Point(0, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(34, 32);
            this.label3.TabIndex = 5;
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // button2
            // 
            this.button2.BackColor = System.Drawing.Color.SkyBlue;
            this.button2.Dock = System.Windows.Forms.DockStyle.Right;
            this.button2.FlatAppearance.BorderSize = 0;
            this.button2.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button2.Image = global::TENTAC_HRM.Properties.Resources.export_excel;
            this.button2.Location = new System.Drawing.Point(363, 0);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(32, 32);
            this.button2.TabIndex = 4;
            this.button2.UseVisualStyleBackColor = false;
            // 
            // lb_menu_sn
            // 
            this.lb_menu_sn.Dock = System.Windows.Forms.DockStyle.Right;
            this.lb_menu_sn.Image = global::TENTAC_HRM.Properties.Resources.dow_arrow;
            this.lb_menu_sn.Location = new System.Drawing.Point(395, 0);
            this.lb_menu_sn.Name = "lb_menu_sn";
            this.lb_menu_sn.Size = new System.Drawing.Size(32, 32);
            this.lb_menu_sn.TabIndex = 0;
            this.lb_menu_sn.Click += new System.EventHandler(this.lb_menu_sn_Click);
            // 
            // panel6
            // 
            this.panel6.BackColor = System.Drawing.SystemColors.Highlight;
            this.panel6.Controls.Add(this.label1);
            this.panel6.Controls.Add(this.btn_close_notifi);
            this.panel6.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel6.Location = new System.Drawing.Point(0, 0);
            this.panel6.Name = "panel6";
            this.panel6.Size = new System.Drawing.Size(427, 32);
            this.panel6.TabIndex = 2;
            // 
            // label1
            // 
            this.label1.Dock = System.Windows.Forms.DockStyle.Left;
            this.label1.Location = new System.Drawing.Point(0, 0);
            this.label1.Name = "label1";
            this.label1.Padding = new System.Windows.Forms.Padding(10, 0, 0, 0);
            this.label1.Size = new System.Drawing.Size(115, 32);
            this.label1.TabIndex = 9;
            this.label1.Text = "Thông báo";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // btn_close_notifi
            // 
            this.btn_close_notifi.Dock = System.Windows.Forms.DockStyle.Right;
            this.btn_close_notifi.FlatAppearance.BorderSize = 0;
            this.btn_close_notifi.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_close_notifi.IconChar = FontAwesome.Sharp.IconChar.Xmark;
            this.btn_close_notifi.IconColor = System.Drawing.Color.Black;
            this.btn_close_notifi.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.btn_close_notifi.IconSize = 16;
            this.btn_close_notifi.Location = new System.Drawing.Point(395, 0);
            this.btn_close_notifi.Name = "btn_close_notifi";
            this.btn_close_notifi.Size = new System.Drawing.Size(32, 32);
            this.btn_close_notifi.TabIndex = 8;
            this.btn_close_notifi.UseVisualStyleBackColor = true;
            this.btn_close_notifi.Click += new System.EventHandler(this.btn_close_notifi_Click);
            // 
            // tm_notifi
            // 
            this.tm_notifi.Interval = 15;
            this.tm_notifi.Tick += new System.EventHandler(this.tm_notifi_Tick);
            // 
            // menustrip_tabpage
            // 
            this.menustrip_tabpage.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.btn_close_all,
            this.closeAllButThisToolStripMenuItem});
            this.menustrip_tabpage.Name = "menustrip_tabpage";
            this.menustrip_tabpage.Size = new System.Drawing.Size(166, 48);
            // 
            // btn_close_all
            // 
            this.btn_close_all.Name = "btn_close_all";
            this.btn_close_all.Size = new System.Drawing.Size(165, 22);
            this.btn_close_all.Text = "Close All";
            this.btn_close_all.Click += new System.EventHandler(this.btn_close_all_Click);
            // 
            // closeAllButThisToolStripMenuItem
            // 
            this.closeAllButThisToolStripMenuItem.AccessibleDescription = "btn_close_all_but_this";
            this.closeAllButThisToolStripMenuItem.Name = "closeAllButThisToolStripMenuItem";
            this.closeAllButThisToolStripMenuItem.Size = new System.Drawing.Size(165, 22);
            this.closeAllButThisToolStripMenuItem.Text = "Close All But This";
            this.closeAllButThisToolStripMenuItem.Click += new System.EventHandler(this.btn_close_all_but_this_Click);
            // 
            // menuStrip1
            // 
            this.menuStrip1.AutoSize = false;
            this.menuStrip1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(191)))), ((int)(((byte)(219)))), ((int)(((byte)(255)))));
            this.menuStrip1.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.iconMenuItem1,
            this.hệThốngToolStripMenuItem,
            this.trợGiúpToolStripMenuItem,
            this.btn_exit,
            this.btn_maxximize,
            this.btn_minimize,
            this.btn_notifi});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Padding = new System.Windows.Forms.Padding(6, 0, 0, 2);
            this.menuStrip1.Size = new System.Drawing.Size(1240, 30);
            this.menuStrip1.TabIndex = 3;
            this.menuStrip1.Text = "menuStrip1";
            this.menuStrip1.MouseDown += new System.Windows.Forms.MouseEventHandler(this.menuStrip1_MouseDown);
            // 
            // iconMenuItem1
            // 
            this.iconMenuItem1.AutoSize = false;
            this.iconMenuItem1.BackColor = System.Drawing.Color.Transparent;
            this.iconMenuItem1.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("iconMenuItem1.BackgroundImage")));
            this.iconMenuItem1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.iconMenuItem1.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.iconMenuItem1.Enabled = false;
            this.iconMenuItem1.IconChar = FontAwesome.Sharp.IconChar.None;
            this.iconMenuItem1.IconColor = System.Drawing.Color.Black;
            this.iconMenuItem1.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.iconMenuItem1.Name = "iconMenuItem1";
            this.iconMenuItem1.Size = new System.Drawing.Size(28, 26);
            // 
            // hệThốngToolStripMenuItem
            // 
            this.hệThốngToolStripMenuItem.BackColor = System.Drawing.Color.Transparent;
            this.hệThốngToolStripMenuItem.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.hệThốngToolStripMenuItem.Name = "hệThốngToolStripMenuItem";
            this.hệThốngToolStripMenuItem.Size = new System.Drawing.Size(71, 28);
            this.hệThốngToolStripMenuItem.Text = "Hệ Thống";
            // 
            // trợGiúpToolStripMenuItem
            // 
            this.trợGiúpToolStripMenuItem.BackColor = System.Drawing.Color.Transparent;
            this.trợGiúpToolStripMenuItem.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.trợGiúpToolStripMenuItem.Name = "trợGiúpToolStripMenuItem";
            this.trợGiúpToolStripMenuItem.Size = new System.Drawing.Size(62, 28);
            this.trợGiúpToolStripMenuItem.Text = "Trợ giúp";
            // 
            // btn_exit
            // 
            this.btn_exit.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.btn_exit.IconChar = FontAwesome.Sharp.IconChar.Xmark;
            this.btn_exit.IconColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.btn_exit.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.btn_exit.Name = "btn_exit";
            this.btn_exit.Size = new System.Drawing.Size(28, 28);
            this.btn_exit.Click += new System.EventHandler(this.btn_exit_Click);
            // 
            // btn_maxximize
            // 
            this.btn_maxximize.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.btn_maxximize.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.btn_maxximize.IconChar = FontAwesome.Sharp.IconChar.Clone;
            this.btn_maxximize.IconColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.btn_maxximize.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.btn_maxximize.Name = "btn_maxximize";
            this.btn_maxximize.Size = new System.Drawing.Size(28, 28);
            this.btn_maxximize.Click += new System.EventHandler(this.btn_maxximize_Click);
            // 
            // btn_minimize
            // 
            this.btn_minimize.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.btn_minimize.IconChar = FontAwesome.Sharp.IconChar.Minus;
            this.btn_minimize.IconColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.btn_minimize.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.btn_minimize.Name = "btn_minimize";
            this.btn_minimize.Size = new System.Drawing.Size(28, 28);
            this.btn_minimize.Click += new System.EventHandler(this.btn_minimize_Click);
            // 
            // btn_notifi
            // 
            this.btn_notifi.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.btn_notifi.BackColor = System.Drawing.Color.Transparent;
            this.btn_notifi.BackgroundImage = global::TENTAC_HRM.Properties.Resources.Background;
            this.btn_notifi.Font = new System.Drawing.Font("Segoe UI", 8F, System.Drawing.FontStyle.Bold);
            this.btn_notifi.ForeColor = System.Drawing.Color.Red;
            this.btn_notifi.IconChar = FontAwesome.Sharp.IconChar.Bell;
            this.btn_notifi.IconColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.btn_notifi.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.btn_notifi.Name = "btn_notifi";
            this.btn_notifi.Size = new System.Drawing.Size(41, 28);
            this.btn_notifi.Text = "0";
            this.btn_notifi.TextAlign = System.Drawing.ContentAlignment.TopRight;
            this.btn_notifi.Click += new System.EventHandler(this.btn_notifi_Click);
            // 
            // timer2
            // 
            this.timer2.Interval = 10;
            this.timer2.Tick += new System.EventHandler(this.timer2_Tick);
            // 
            // frm_home
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1240, 835);
            this.Controls.Add(this.pl_menu);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.menuStrip1);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.KeyPreview = true;
            this.Name = "frm_home";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "TENTAC HỒ CHÍ MINH";
            this.Load += new System.EventHandler(this.frm_home_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.frm_home_KeyDown);
            this.tb_main.ResumeLayout(false);
            this.tb_dashboard.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panel3.ResumeLayout(false);
            this.pl_menu_left.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            this.pl_menu.ResumeLayout(false);
            this.pl_menu_sub.ResumeLayout(false);
            this.pl_nv_moi.ResumeLayout(false);
            this.panel4.ResumeLayout(false);
            this.pl_hopdong.ResumeLayout(false);
            this.pl_menu_hopdong.ResumeLayout(false);
            this.pl_sn.ResumeLayout(false);
            this.panel5.ResumeLayout(false);
            this.panel6.ResumeLayout(false);
            this.menustrip_tabpage.ResumeLayout(false);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.TabControl tb_main;
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.TabPage tb_dashboard;
        private System.Windows.Forms.Panel pl_dashboard;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem hệThốngToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem trợGiúpToolStripMenuItem;
        private System.Windows.Forms.Timer tm_menu_left;
        private FontAwesome.Sharp.IconMenuItem iconMenuItem1;
        private FontAwesome.Sharp.IconMenuItem btn_exit;
        private FontAwesome.Sharp.IconMenuItem btn_maxximize;
        private FontAwesome.Sharp.IconMenuItem btn_minimize;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Panel pl_menu_left;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Button btn_show_menu_left;
        private System.Windows.Forms.Label lbl_title_menu;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel1;
        private System.Windows.Forms.ToolStripStatusLabel ts_user;
        private System.Windows.Forms.ToolStripStatusLabel ts_date;
        private FontAwesome.Sharp.IconMenuItem btn_notifi;
        private System.Windows.Forms.Panel pl_menu;
        private System.Windows.Forms.Panel pl_menu_sub;
        private System.Windows.Forms.Panel pl_nv_moi;
        private System.Windows.Forms.ListView lv_nv_moi;
        private System.Windows.Forms.ColumnHeader columnHeader7;
        private System.Windows.Forms.ColumnHeader columnHeader8;
        private System.Windows.Forms.ColumnHeader columnHeader9;
        private System.Windows.Forms.Panel panel4;
        private System.Windows.Forms.Label lb_title_nv_moi;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.Label lb_nv_moi;
        private System.Windows.Forms.Panel pl_hopdong;
        private System.Windows.Forms.ListView lv_hopdong_hethan;
        private System.Windows.Forms.ColumnHeader columnHeader4;
        private System.Windows.Forms.ColumnHeader columnHeader5;
        private System.Windows.Forms.ColumnHeader columnHeader6;
        private System.Windows.Forms.Panel pl_menu_hopdong;
        private System.Windows.Forms.Label lb_title_hopdong;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Label lb_hop_dong;
        private System.Windows.Forms.Panel pl_sn;
        private System.Windows.Forms.ListView lv_sinhnhat;
        private System.Windows.Forms.ColumnHeader columnHeader1;
        private System.Windows.Forms.ColumnHeader columnHeader2;
        private System.Windows.Forms.ColumnHeader columnHeader3;
        private System.Windows.Forms.Panel panel5;
        private System.Windows.Forms.Label lb_title_notifi;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Label lb_menu_sn;
        private System.Windows.Forms.Panel panel6;
        private System.Windows.Forms.Label label1;
        private FontAwesome.Sharp.IconButton btn_close_notifi;
        private System.Windows.Forms.Timer tm_notifi;
        private System.Windows.Forms.ContextMenuStrip menustrip_tabpage;
        private System.Windows.Forms.ToolStripMenuItem btn_close_all;
        private System.Windows.Forms.ToolStripMenuItem closeAllButThisToolStripMenuItem;
        private System.Windows.Forms.Panel pl_MenuLeft;
        private System.Windows.Forms.Timer timer2;
    }
}

