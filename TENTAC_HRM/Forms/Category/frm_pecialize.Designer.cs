namespace TENTAC_HRM.Forms.Category
{
    partial class frm_pecialize
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
            this.panel1 = new System.Windows.Forms.Panel();
            this.panel2 = new System.Windows.Forms.Panel();
            this.btn_save_add = new System.Windows.Forms.Button();
            this.btn_save_close = new System.Windows.Forms.Button();
            this.btn_close = new System.Windows.Forms.Button();
            this.cbo_NhanVien = new DevComponents.DotNetBar.Controls.ComboBoxEx();
            this.labelX1 = new DevComponents.DotNetBar.LabelX();
            this.cbo_XepLoai = new DevComponents.DotNetBar.Controls.ComboBoxEx();
            this.cbo_NganhDaoTao = new DevComponents.DotNetBar.Controls.ComboBoxEx();
            this.cbo_HeDaoTao = new DevComponents.DotNetBar.Controls.ComboBoxEx();
            this.cbo_BacDaoTao = new DevComponents.DotNetBar.Controls.ComboBoxEx();
            this.lblGhiChu = new DevComponents.DotNetBar.LabelX();
            this.lblName = new DevComponents.DotNetBar.LabelX();
            this.button6 = new System.Windows.Forms.Button();
            this.button5 = new System.Windows.Forms.Button();
            this.button4 = new System.Windows.Forms.Button();
            this.chk_active = new DevComponents.DotNetBar.Controls.CheckBoxX();
            this.txt_ghichu = new DevComponents.DotNetBar.Controls.TextBoxX();
            this.txt_truongdaotao = new DevComponents.DotNetBar.Controls.TextBoxX();
            this.label8 = new DevComponents.DotNetBar.LabelX();
            this.label7 = new DevComponents.DotNetBar.LabelX();
            this.label10 = new DevComponents.DotNetBar.LabelX();
            this.label9 = new DevComponents.DotNetBar.LabelX();
            this.label6 = new DevComponents.DotNetBar.LabelX();
            this.lb = new DevComponents.DotNetBar.LabelX();
            this.label4 = new DevComponents.DotNetBar.LabelX();
            this.label3 = new DevComponents.DotNetBar.LabelX();
            this.label2 = new DevComponents.DotNetBar.LabelX();
            this.dtp_TuNam = new DevComponents.Editors.DateTimeAdv.DateTimeInput();
            this.dtp_DenNam = new DevComponents.Editors.DateTimeAdv.DateTimeInput();
            this.dtp_NamNhanBang = new DevComponents.Editors.DateTimeAdv.DateTimeInput();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dtp_TuNam)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtp_DenNam)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtp_NamNhanBang)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.dtp_NamNhanBang);
            this.panel1.Controls.Add(this.dtp_DenNam);
            this.panel1.Controls.Add(this.dtp_TuNam);
            this.panel1.Controls.Add(this.panel2);
            this.panel1.Controls.Add(this.cbo_NhanVien);
            this.panel1.Controls.Add(this.labelX1);
            this.panel1.Controls.Add(this.cbo_XepLoai);
            this.panel1.Controls.Add(this.cbo_NganhDaoTao);
            this.panel1.Controls.Add(this.cbo_HeDaoTao);
            this.panel1.Controls.Add(this.cbo_BacDaoTao);
            this.panel1.Controls.Add(this.lblGhiChu);
            this.panel1.Controls.Add(this.lblName);
            this.panel1.Controls.Add(this.button6);
            this.panel1.Controls.Add(this.button5);
            this.panel1.Controls.Add(this.button4);
            this.panel1.Controls.Add(this.chk_active);
            this.panel1.Controls.Add(this.txt_ghichu);
            this.panel1.Controls.Add(this.txt_truongdaotao);
            this.panel1.Controls.Add(this.label8);
            this.panel1.Controls.Add(this.label7);
            this.panel1.Controls.Add(this.label10);
            this.panel1.Controls.Add(this.label9);
            this.panel1.Controls.Add(this.label6);
            this.panel1.Controls.Add(this.lb);
            this.panel1.Controls.Add(this.label4);
            this.panel1.Controls.Add(this.label3);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(395, 668);
            this.panel1.TabIndex = 0;
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(16)))), ((int)(((byte)(39)))), ((int)(((byte)(75)))));
            this.panel2.Controls.Add(this.btn_save_add);
            this.panel2.Controls.Add(this.btn_save_close);
            this.panel2.Controls.Add(this.btn_close);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel2.Location = new System.Drawing.Point(0, 613);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(395, 55);
            this.panel2.TabIndex = 41;
            // 
            // btn_save_add
            // 
            this.btn_save_add.Image = global::TENTAC_HRM.Properties.Resources.diskette;
            this.btn_save_add.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btn_save_add.Location = new System.Drawing.Point(26, 13);
            this.btn_save_add.Name = "btn_save_add";
            this.btn_save_add.Size = new System.Drawing.Size(138, 30);
            this.btn_save_add.TabIndex = 12;
            this.btn_save_add.Text = "Lưu và Thêm";
            this.btn_save_add.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btn_save_add.UseVisualStyleBackColor = true;
            this.btn_save_add.Click += new System.EventHandler(this.btn_save_add_Click);
            // 
            // btn_save_close
            // 
            this.btn_save_close.Image = global::TENTAC_HRM.Properties.Resources.diskette;
            this.btn_save_close.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btn_save_close.Location = new System.Drawing.Point(170, 13);
            this.btn_save_close.Name = "btn_save_close";
            this.btn_save_close.Size = new System.Drawing.Size(112, 30);
            this.btn_save_close.TabIndex = 13;
            this.btn_save_close.Text = "Lưu và thoát";
            this.btn_save_close.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btn_save_close.UseVisualStyleBackColor = true;
            this.btn_save_close.Click += new System.EventHandler(this.btn_save_close_Click);
            // 
            // btn_close
            // 
            this.btn_close.Image = global::TENTAC_HRM.Properties.Resources.clear;
            this.btn_close.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btn_close.Location = new System.Drawing.Point(288, 13);
            this.btn_close.Name = "btn_close";
            this.btn_close.Size = new System.Drawing.Size(78, 30);
            this.btn_close.TabIndex = 14;
            this.btn_close.Text = "Đóng";
            this.btn_close.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btn_close.UseVisualStyleBackColor = true;
            this.btn_close.Click += new System.EventHandler(this.btn_close_Click);
            // 
            // cbo_NhanVien
            // 
            this.cbo_NhanVien.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.cbo_NhanVien.Enabled = false;
            this.cbo_NhanVien.FormattingEnabled = true;
            this.cbo_NhanVien.ItemHeight = 17;
            this.cbo_NhanVien.Location = new System.Drawing.Point(26, 99);
            this.cbo_NhanVien.Name = "cbo_NhanVien";
            this.cbo_NhanVien.Size = new System.Drawing.Size(338, 23);
            this.cbo_NhanVien.TabIndex = 40;
            // 
            // labelX1
            // 
            this.labelX1.Location = new System.Drawing.Point(26, 70);
            this.labelX1.Name = "labelX1";
            this.labelX1.Size = new System.Drawing.Size(75, 23);
            this.labelX1.TabIndex = 39;
            this.labelX1.Text = "Nhân viên";
            // 
            // cbo_XepLoai
            // 
            this.cbo_XepLoai.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.cbo_XepLoai.FormattingEnabled = true;
            this.cbo_XepLoai.ItemHeight = 17;
            this.cbo_XepLoai.Location = new System.Drawing.Point(26, 438);
            this.cbo_XepLoai.Name = "cbo_XepLoai";
            this.cbo_XepLoai.Size = new System.Drawing.Size(340, 23);
            this.cbo_XepLoai.TabIndex = 10;
            // 
            // cbo_NganhDaoTao
            // 
            this.cbo_NganhDaoTao.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.cbo_NganhDaoTao.FormattingEnabled = true;
            this.cbo_NganhDaoTao.ItemHeight = 17;
            this.cbo_NganhDaoTao.Location = new System.Drawing.Point(28, 246);
            this.cbo_NganhDaoTao.Name = "cbo_NganhDaoTao";
            this.cbo_NganhDaoTao.Size = new System.Drawing.Size(336, 23);
            this.cbo_NganhDaoTao.TabIndex = 4;
            // 
            // cbo_HeDaoTao
            // 
            this.cbo_HeDaoTao.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.cbo_HeDaoTao.FormattingEnabled = true;
            this.cbo_HeDaoTao.ItemHeight = 17;
            this.cbo_HeDaoTao.Location = new System.Drawing.Point(28, 197);
            this.cbo_HeDaoTao.Name = "cbo_HeDaoTao";
            this.cbo_HeDaoTao.Size = new System.Drawing.Size(336, 23);
            this.cbo_HeDaoTao.TabIndex = 3;
            // 
            // cbo_BacDaoTao
            // 
            this.cbo_BacDaoTao.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.cbo_BacDaoTao.FormattingEnabled = true;
            this.cbo_BacDaoTao.ItemHeight = 17;
            this.cbo_BacDaoTao.Location = new System.Drawing.Point(28, 148);
            this.cbo_BacDaoTao.Name = "cbo_BacDaoTao";
            this.cbo_BacDaoTao.Size = new System.Drawing.Size(336, 23);
            this.cbo_BacDaoTao.TabIndex = 2;
            // 
            // lblGhiChu
            // 
            this.lblGhiChu.Location = new System.Drawing.Point(26, 467);
            this.lblGhiChu.Name = "lblGhiChu";
            this.lblGhiChu.Size = new System.Drawing.Size(75, 23);
            this.lblGhiChu.TabIndex = 38;
            this.lblGhiChu.Text = "Ghi Chú";
            // 
            // lblName
            // 
            this.lblName.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(16)))), ((int)(((byte)(39)))), ((int)(((byte)(75)))));
            this.lblName.Dock = System.Windows.Forms.DockStyle.Top;
            this.lblName.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblName.ForeColor = System.Drawing.Color.WhiteSmoke;
            this.lblName.Location = new System.Drawing.Point(0, 0);
            this.lblName.Name = "lblName";
            this.lblName.Size = new System.Drawing.Size(395, 54);
            this.lblName.TabIndex = 37;
            this.lblName.Text = "Đào Tạo";
            this.lblName.TextAlignment = System.Drawing.StringAlignment.Center;
            // 
            // button6
            // 
            this.button6.Location = new System.Drawing.Point(427, 129);
            this.button6.Name = "button6";
            this.button6.Size = new System.Drawing.Size(26, 26);
            this.button6.TabIndex = 30;
            this.button6.Text = "+";
            this.button6.UseVisualStyleBackColor = true;
            // 
            // button5
            // 
            this.button5.Location = new System.Drawing.Point(427, 99);
            this.button5.Name = "button5";
            this.button5.Size = new System.Drawing.Size(26, 26);
            this.button5.TabIndex = 29;
            this.button5.Text = "+";
            this.button5.UseVisualStyleBackColor = true;
            // 
            // button4
            // 
            this.button4.Location = new System.Drawing.Point(427, 69);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(26, 26);
            this.button4.TabIndex = 28;
            this.button4.Text = "+";
            this.button4.UseVisualStyleBackColor = true;
            // 
            // chk_active
            // 
            this.chk_active.AutoSize = true;
            this.chk_active.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chk_active.Location = new System.Drawing.Point(205, 394);
            this.chk_active.Name = "chk_active";
            this.chk_active.Size = new System.Drawing.Size(109, 19);
            this.chk_active.TabIndex = 9;
            this.chk_active.Text = "Đang hiệu lực";
            // 
            // txt_ghichu
            // 
            // 
            // 
            // 
            this.txt_ghichu.Border.Class = "TextBoxBorder";
            this.txt_ghichu.Location = new System.Drawing.Point(26, 496);
            this.txt_ghichu.Multiline = true;
            this.txt_ghichu.Name = "txt_ghichu";
            this.txt_ghichu.Size = new System.Drawing.Size(340, 94);
            this.txt_ghichu.TabIndex = 11;
            // 
            // txt_truongdaotao
            // 
            // 
            // 
            // 
            this.txt_truongdaotao.Border.Class = "TextBoxBorder";
            this.txt_truongdaotao.Location = new System.Drawing.Point(28, 294);
            this.txt_truongdaotao.Name = "txt_truongdaotao";
            this.txt_truongdaotao.Size = new System.Drawing.Size(336, 23);
            this.txt_truongdaotao.TabIndex = 5;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(26, 370);
            this.label8.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(104, 19);
            this.label8.TabIndex = 10;
            this.label8.Text = "Năm nhận bằng";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(201, 320);
            this.label7.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(62, 19);
            this.label7.TabIndex = 18;
            this.label7.Text = "Đến năm";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(-78, 305);
            this.label10.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(41, 19);
            this.label10.TabIndex = 17;
            this.label10.Text = "Mô tả";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(30, 416);
            this.label9.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(91, 19);
            this.label9.TabIndex = 16;
            this.label9.Text = "Xếp loại bằng";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(28, 320);
            this.label6.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(53, 19);
            this.label6.TabIndex = 15;
            this.label6.Text = "Từ năm";
            // 
            // lb
            // 
            this.lb.AutoSize = true;
            this.lb.Location = new System.Drawing.Point(28, 272);
            this.lb.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lb.Name = "lb";
            this.lb.Size = new System.Drawing.Size(100, 19);
            this.lb.TabIndex = 14;
            this.lb.Text = "Trường đào tạo";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(28, 223);
            this.label4.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(97, 19);
            this.label4.TabIndex = 13;
            this.label4.Text = "Ngành đào tạo";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(28, 175);
            this.label3.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(74, 19);
            this.label3.TabIndex = 12;
            this.label3.Text = "Hệ đào tạo";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(28, 125);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(80, 19);
            this.label2.TabIndex = 11;
            this.label2.Text = "Bậc đào tạo";
            // 
            // dtp_TuNam
            // 
            // 
            // 
            // 
            this.dtp_TuNam.BackgroundStyle.Class = "DateTimeInputBackground";
            this.dtp_TuNam.ButtonDropDown.Visible = true;
            this.dtp_TuNam.Location = new System.Drawing.Point(28, 342);
            // 
            // 
            // 
            this.dtp_TuNam.MonthCalendar.AnnuallyMarkedDates = new System.DateTime[0];
            // 
            // 
            // 
            this.dtp_TuNam.MonthCalendar.BackgroundStyle.BackColor = System.Drawing.SystemColors.Window;
            this.dtp_TuNam.MonthCalendar.ClearButtonVisible = true;
            // 
            // 
            // 
            this.dtp_TuNam.MonthCalendar.CommandsBackgroundStyle.BackColor2SchemePart = DevComponents.DotNetBar.eColorSchemePart.BarBackground2;
            this.dtp_TuNam.MonthCalendar.CommandsBackgroundStyle.BackColorGradientAngle = 90;
            this.dtp_TuNam.MonthCalendar.CommandsBackgroundStyle.BackColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.BarBackground;
            this.dtp_TuNam.MonthCalendar.CommandsBackgroundStyle.BorderTop = DevComponents.DotNetBar.eStyleBorderType.Solid;
            this.dtp_TuNam.MonthCalendar.CommandsBackgroundStyle.BorderTopColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.BarDockedBorder;
            this.dtp_TuNam.MonthCalendar.CommandsBackgroundStyle.BorderTopWidth = 1;
            this.dtp_TuNam.MonthCalendar.DisplayMonth = new System.DateTime(2024, 10, 1, 0, 0, 0, 0);
            this.dtp_TuNam.MonthCalendar.MarkedDates = new System.DateTime[0];
            this.dtp_TuNam.MonthCalendar.MonthlyMarkedDates = new System.DateTime[0];
            // 
            // 
            // 
            this.dtp_TuNam.MonthCalendar.NavigationBackgroundStyle.BackColor2SchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground2;
            this.dtp_TuNam.MonthCalendar.NavigationBackgroundStyle.BackColorGradientAngle = 90;
            this.dtp_TuNam.MonthCalendar.NavigationBackgroundStyle.BackColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground;
            this.dtp_TuNam.MonthCalendar.TodayButtonVisible = true;
            this.dtp_TuNam.Name = "dtp_TuNam";
            this.dtp_TuNam.Size = new System.Drawing.Size(161, 23);
            this.dtp_TuNam.TabIndex = 45;
            // 
            // dtp_DenNam
            // 
            // 
            // 
            // 
            this.dtp_DenNam.BackgroundStyle.Class = "DateTimeInputBackground";
            this.dtp_DenNam.ButtonDropDown.Visible = true;
            this.dtp_DenNam.Location = new System.Drawing.Point(205, 342);
            // 
            // 
            // 
            this.dtp_DenNam.MonthCalendar.AnnuallyMarkedDates = new System.DateTime[0];
            // 
            // 
            // 
            this.dtp_DenNam.MonthCalendar.BackgroundStyle.BackColor = System.Drawing.SystemColors.Window;
            this.dtp_DenNam.MonthCalendar.ClearButtonVisible = true;
            // 
            // 
            // 
            this.dtp_DenNam.MonthCalendar.CommandsBackgroundStyle.BackColor2SchemePart = DevComponents.DotNetBar.eColorSchemePart.BarBackground2;
            this.dtp_DenNam.MonthCalendar.CommandsBackgroundStyle.BackColorGradientAngle = 90;
            this.dtp_DenNam.MonthCalendar.CommandsBackgroundStyle.BackColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.BarBackground;
            this.dtp_DenNam.MonthCalendar.CommandsBackgroundStyle.BorderTop = DevComponents.DotNetBar.eStyleBorderType.Solid;
            this.dtp_DenNam.MonthCalendar.CommandsBackgroundStyle.BorderTopColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.BarDockedBorder;
            this.dtp_DenNam.MonthCalendar.CommandsBackgroundStyle.BorderTopWidth = 1;
            this.dtp_DenNam.MonthCalendar.DisplayMonth = new System.DateTime(2024, 10, 1, 0, 0, 0, 0);
            this.dtp_DenNam.MonthCalendar.MarkedDates = new System.DateTime[0];
            this.dtp_DenNam.MonthCalendar.MonthlyMarkedDates = new System.DateTime[0];
            // 
            // 
            // 
            this.dtp_DenNam.MonthCalendar.NavigationBackgroundStyle.BackColor2SchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground2;
            this.dtp_DenNam.MonthCalendar.NavigationBackgroundStyle.BackColorGradientAngle = 90;
            this.dtp_DenNam.MonthCalendar.NavigationBackgroundStyle.BackColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground;
            this.dtp_DenNam.MonthCalendar.TodayButtonVisible = true;
            this.dtp_DenNam.Name = "dtp_DenNam";
            this.dtp_DenNam.Size = new System.Drawing.Size(161, 23);
            this.dtp_DenNam.TabIndex = 46;
            // 
            // dtp_NamNhanBang
            // 
            // 
            // 
            // 
            this.dtp_NamNhanBang.BackgroundStyle.Class = "DateTimeInputBackground";
            this.dtp_NamNhanBang.ButtonDropDown.Visible = true;
            this.dtp_NamNhanBang.Location = new System.Drawing.Point(26, 390);
            // 
            // 
            // 
            this.dtp_NamNhanBang.MonthCalendar.AnnuallyMarkedDates = new System.DateTime[0];
            // 
            // 
            // 
            this.dtp_NamNhanBang.MonthCalendar.BackgroundStyle.BackColor = System.Drawing.SystemColors.Window;
            this.dtp_NamNhanBang.MonthCalendar.ClearButtonVisible = true;
            // 
            // 
            // 
            this.dtp_NamNhanBang.MonthCalendar.CommandsBackgroundStyle.BackColor2SchemePart = DevComponents.DotNetBar.eColorSchemePart.BarBackground2;
            this.dtp_NamNhanBang.MonthCalendar.CommandsBackgroundStyle.BackColorGradientAngle = 90;
            this.dtp_NamNhanBang.MonthCalendar.CommandsBackgroundStyle.BackColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.BarBackground;
            this.dtp_NamNhanBang.MonthCalendar.CommandsBackgroundStyle.BorderTop = DevComponents.DotNetBar.eStyleBorderType.Solid;
            this.dtp_NamNhanBang.MonthCalendar.CommandsBackgroundStyle.BorderTopColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.BarDockedBorder;
            this.dtp_NamNhanBang.MonthCalendar.CommandsBackgroundStyle.BorderTopWidth = 1;
            this.dtp_NamNhanBang.MonthCalendar.DisplayMonth = new System.DateTime(2024, 10, 1, 0, 0, 0, 0);
            this.dtp_NamNhanBang.MonthCalendar.MarkedDates = new System.DateTime[0];
            this.dtp_NamNhanBang.MonthCalendar.MonthlyMarkedDates = new System.DateTime[0];
            // 
            // 
            // 
            this.dtp_NamNhanBang.MonthCalendar.NavigationBackgroundStyle.BackColor2SchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground2;
            this.dtp_NamNhanBang.MonthCalendar.NavigationBackgroundStyle.BackColorGradientAngle = 90;
            this.dtp_NamNhanBang.MonthCalendar.NavigationBackgroundStyle.BackColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground;
            this.dtp_NamNhanBang.MonthCalendar.TodayButtonVisible = true;
            this.dtp_NamNhanBang.Name = "dtp_NamNhanBang";
            this.dtp_NamNhanBang.Size = new System.Drawing.Size(161, 23);
            this.dtp_NamNhanBang.TabIndex = 47;
            // 
            // frm_pecialize
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.ClientSize = new System.Drawing.Size(395, 668);
            this.Controls.Add(this.panel1);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.KeyPreview = true;
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "frm_pecialize";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Đào tạo";
            this.Load += new System.EventHandler(this.frm_train_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.frm_pecialize_KeyDown);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dtp_TuNam)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtp_DenNam)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtp_NamNhanBang)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private DevComponents.DotNetBar.LabelX lblName;
        private System.Windows.Forms.Button button6;
        private System.Windows.Forms.Button button5;
        private System.Windows.Forms.Button button4;
        private System.Windows.Forms.Button btn_save_add;
        private System.Windows.Forms.Button btn_save_close;
        private System.Windows.Forms.Button btn_close;
        private DevComponents.DotNetBar.Controls.TextBoxX txt_ghichu;
        private DevComponents.DotNetBar.Controls.TextBoxX txt_truongdaotao;
        private DevComponents.DotNetBar.LabelX label8;
        private DevComponents.DotNetBar.LabelX label7;
        private DevComponents.DotNetBar.LabelX label10;
        private DevComponents.DotNetBar.LabelX label9;
        private DevComponents.DotNetBar.LabelX label6;
        private DevComponents.DotNetBar.LabelX lb;
        private DevComponents.DotNetBar.LabelX label4;
        private DevComponents.DotNetBar.LabelX label3;
        private DevComponents.DotNetBar.LabelX lblGhiChu;
        private DevComponents.DotNetBar.Controls.ComboBoxEx cbo_BacDaoTao;
        private DevComponents.DotNetBar.Controls.ComboBoxEx cbo_HeDaoTao;
        private DevComponents.DotNetBar.Controls.ComboBoxEx cbo_NganhDaoTao;
        private DevComponents.DotNetBar.Controls.CheckBoxX chk_active;
        private DevComponents.DotNetBar.Controls.ComboBoxEx cbo_XepLoai;
        private DevComponents.DotNetBar.LabelX label2;
        private DevComponents.DotNetBar.LabelX labelX1;
        private DevComponents.DotNetBar.Controls.ComboBoxEx cbo_NhanVien;
        private System.Windows.Forms.Panel panel2;
        private DevComponents.Editors.DateTimeAdv.DateTimeInput dtp_DenNam;
        private DevComponents.Editors.DateTimeAdv.DateTimeInput dtp_TuNam;
        private DevComponents.Editors.DateTimeAdv.DateTimeInput dtp_NamNhanBang;
    }
}