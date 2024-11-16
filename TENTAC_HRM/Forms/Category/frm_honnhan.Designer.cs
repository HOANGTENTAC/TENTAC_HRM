namespace TENTAC_HRM.Forms.Category
{
    partial class frm_honnhan
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
            this.labelX7 = new DevComponents.DotNetBar.LabelX();
            this.labelX6 = new DevComponents.DotNetBar.LabelX();
            this.panel2 = new System.Windows.Forms.Panel();
            this.btn_luu = new System.Windows.Forms.Button();
            this.btn_close = new System.Windows.Forms.Button();
            this.btn_delete = new System.Windows.Forms.Button();
            this.btn_update_pt2 = new FontAwesome.Sharp.IconButton();
            this.btn_update_pt1 = new FontAwesome.Sharp.IconButton();
            this.txt_NoiDK = new DevComponents.DotNetBar.Controls.TextBoxX();
            this.labelX5 = new DevComponents.DotNetBar.LabelX();
            this.dtp_NgayDK = new DevComponents.Editors.DateTimeAdv.DateTimeInput();
            this.labelX4 = new DevComponents.DotNetBar.LabelX();
            this.txt_SoGiayChungNhan = new DevComponents.DotNetBar.Controls.TextBoxX();
            this.labelX3 = new DevComponents.DotNetBar.LabelX();
            this.cbo_NhanVien = new DevComponents.DotNetBar.Controls.ComboBoxEx();
            this.labelX2 = new DevComponents.DotNetBar.LabelX();
            this.labelX1 = new DevComponents.DotNetBar.LabelX();
            this.btn_delete_pt2 = new RJButton.RJButton();
            this.btn_delete_pt1 = new RJButton.RJButton();
            this.pb_MatSau = new System.Windows.Forms.PictureBox();
            this.pb_MatTruoc = new System.Windows.Forms.PictureBox();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dtp_NgayDK)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pb_MatSau)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pb_MatTruoc)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel1.Controls.Add(this.labelX7);
            this.panel1.Controls.Add(this.labelX6);
            this.panel1.Controls.Add(this.panel2);
            this.panel1.Controls.Add(this.btn_update_pt2);
            this.panel1.Controls.Add(this.btn_update_pt1);
            this.panel1.Controls.Add(this.txt_NoiDK);
            this.panel1.Controls.Add(this.labelX5);
            this.panel1.Controls.Add(this.dtp_NgayDK);
            this.panel1.Controls.Add(this.labelX4);
            this.panel1.Controls.Add(this.txt_SoGiayChungNhan);
            this.panel1.Controls.Add(this.labelX3);
            this.panel1.Controls.Add(this.cbo_NhanVien);
            this.panel1.Controls.Add(this.labelX2);
            this.panel1.Controls.Add(this.labelX1);
            this.panel1.Controls.Add(this.btn_delete_pt2);
            this.panel1.Controls.Add(this.btn_delete_pt1);
            this.panel1.Controls.Add(this.pb_MatSau);
            this.panel1.Controls.Add(this.pb_MatTruoc);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.ForeColor = System.Drawing.SystemColors.ControlText;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(450, 598);
            this.panel1.TabIndex = 0;
            // 
            // labelX7
            // 
            this.labelX7.Location = new System.Drawing.Point(291, 239);
            this.labelX7.Name = "labelX7";
            this.labelX7.Size = new System.Drawing.Size(75, 23);
            this.labelX7.TabIndex = 62;
            this.labelX7.Text = "Mặt sau";
            // 
            // labelX6
            // 
            this.labelX6.Location = new System.Drawing.Point(95, 239);
            this.labelX6.Name = "labelX6";
            this.labelX6.Size = new System.Drawing.Size(75, 23);
            this.labelX6.TabIndex = 61;
            this.labelX6.Text = "Mặt trước";
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(16)))), ((int)(((byte)(39)))), ((int)(((byte)(75)))));
            this.panel2.Controls.Add(this.btn_luu);
            this.panel2.Controls.Add(this.btn_close);
            this.panel2.Controls.Add(this.btn_delete);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel2.Location = new System.Drawing.Point(0, 541);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(448, 55);
            this.panel2.TabIndex = 60;
            // 
            // btn_luu
            // 
            this.btn_luu.Image = global::TENTAC_HRM.Properties.Resources.diskette;
            this.btn_luu.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btn_luu.Location = new System.Drawing.Point(175, 16);
            this.btn_luu.Name = "btn_luu";
            this.btn_luu.Size = new System.Drawing.Size(106, 27);
            this.btn_luu.TabIndex = 21;
            this.btn_luu.Text = "Lưu";
            this.btn_luu.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btn_luu.UseVisualStyleBackColor = true;
            this.btn_luu.Click += new System.EventHandler(this.btn_luu_Click);
            // 
            // btn_close
            // 
            this.btn_close.Image = global::TENTAC_HRM.Properties.Resources.clear;
            this.btn_close.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btn_close.Location = new System.Drawing.Point(344, 16);
            this.btn_close.Name = "btn_close";
            this.btn_close.Size = new System.Drawing.Size(84, 27);
            this.btn_close.TabIndex = 23;
            this.btn_close.Text = "Đóng";
            this.btn_close.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btn_close.UseVisualStyleBackColor = true;
            this.btn_close.Click += new System.EventHandler(this.btn_close_Click);
            // 
            // btn_delete
            // 
            this.btn_delete.Image = global::TENTAC_HRM.Properties.Resources.bin;
            this.btn_delete.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btn_delete.Location = new System.Drawing.Point(30, 16);
            this.btn_delete.Name = "btn_delete";
            this.btn_delete.Size = new System.Drawing.Size(99, 27);
            this.btn_delete.TabIndex = 22;
            this.btn_delete.Text = "Xóa";
            this.btn_delete.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btn_delete.UseVisualStyleBackColor = true;
            this.btn_delete.Visible = false;
            this.btn_delete.Click += new System.EventHandler(this.btn_delete_Click);
            // 
            // btn_update_pt2
            // 
            this.btn_update_pt2.FlatAppearance.BorderSize = 0;
            this.btn_update_pt2.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_update_pt2.IconChar = FontAwesome.Sharp.IconChar.Upload;
            this.btn_update_pt2.IconColor = System.Drawing.Color.Black;
            this.btn_update_pt2.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.btn_update_pt2.IconSize = 20;
            this.btn_update_pt2.Location = new System.Drawing.Point(283, 498);
            this.btn_update_pt2.Name = "btn_update_pt2";
            this.btn_update_pt2.Size = new System.Drawing.Size(41, 30);
            this.btn_update_pt2.TabIndex = 59;
            this.btn_update_pt2.UseVisualStyleBackColor = true;
            this.btn_update_pt2.Click += new System.EventHandler(this.btn_update_pt2_Click);
            // 
            // btn_update_pt1
            // 
            this.btn_update_pt1.FlatAppearance.BorderSize = 0;
            this.btn_update_pt1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_update_pt1.IconChar = FontAwesome.Sharp.IconChar.Upload;
            this.btn_update_pt1.IconColor = System.Drawing.Color.Black;
            this.btn_update_pt1.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.btn_update_pt1.IconSize = 20;
            this.btn_update_pt1.Location = new System.Drawing.Point(86, 498);
            this.btn_update_pt1.Name = "btn_update_pt1";
            this.btn_update_pt1.Size = new System.Drawing.Size(41, 30);
            this.btn_update_pt1.TabIndex = 58;
            this.btn_update_pt1.UseVisualStyleBackColor = true;
            this.btn_update_pt1.Click += new System.EventHandler(this.btn_update_pt1_Click);
            // 
            // txt_NoiDK
            // 
            // 
            // 
            // 
            this.txt_NoiDK.Border.Class = "TextBoxBorder";
            this.txt_NoiDK.Location = new System.Drawing.Point(26, 210);
            this.txt_NoiDK.Name = "txt_NoiDK";
            this.txt_NoiDK.Size = new System.Drawing.Size(398, 23);
            this.txt_NoiDK.TabIndex = 57;
            // 
            // labelX5
            // 
            this.labelX5.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelX5.Location = new System.Drawing.Point(26, 181);
            this.labelX5.Name = "labelX5";
            this.labelX5.Size = new System.Drawing.Size(101, 23);
            this.labelX5.TabIndex = 56;
            this.labelX5.Text = "Nơi đăng ký";
            // 
            // dtp_NgayDK
            // 
            // 
            // 
            // 
            this.dtp_NgayDK.BackgroundStyle.Class = "DateTimeInputBackground";
            this.dtp_NgayDK.ButtonDropDown.Visible = true;
            this.dtp_NgayDK.Location = new System.Drawing.Point(283, 151);
            // 
            // 
            // 
            this.dtp_NgayDK.MonthCalendar.AnnuallyMarkedDates = new System.DateTime[0];
            // 
            // 
            // 
            this.dtp_NgayDK.MonthCalendar.BackgroundStyle.BackColor = System.Drawing.SystemColors.Window;
            this.dtp_NgayDK.MonthCalendar.ClearButtonVisible = true;
            // 
            // 
            // 
            this.dtp_NgayDK.MonthCalendar.CommandsBackgroundStyle.BackColor2SchemePart = DevComponents.DotNetBar.eColorSchemePart.BarBackground2;
            this.dtp_NgayDK.MonthCalendar.CommandsBackgroundStyle.BackColorGradientAngle = 90;
            this.dtp_NgayDK.MonthCalendar.CommandsBackgroundStyle.BackColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.BarBackground;
            this.dtp_NgayDK.MonthCalendar.CommandsBackgroundStyle.BorderTop = DevComponents.DotNetBar.eStyleBorderType.Solid;
            this.dtp_NgayDK.MonthCalendar.CommandsBackgroundStyle.BorderTopColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.BarDockedBorder;
            this.dtp_NgayDK.MonthCalendar.CommandsBackgroundStyle.BorderTopWidth = 1;
            this.dtp_NgayDK.MonthCalendar.DisplayMonth = new System.DateTime(2024, 10, 1, 0, 0, 0, 0);
            this.dtp_NgayDK.MonthCalendar.MarkedDates = new System.DateTime[0];
            this.dtp_NgayDK.MonthCalendar.MonthlyMarkedDates = new System.DateTime[0];
            // 
            // 
            // 
            this.dtp_NgayDK.MonthCalendar.NavigationBackgroundStyle.BackColor2SchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground2;
            this.dtp_NgayDK.MonthCalendar.NavigationBackgroundStyle.BackColorGradientAngle = 90;
            this.dtp_NgayDK.MonthCalendar.NavigationBackgroundStyle.BackColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground;
            this.dtp_NgayDK.MonthCalendar.TodayButtonVisible = true;
            this.dtp_NgayDK.Name = "dtp_NgayDK";
            this.dtp_NgayDK.Size = new System.Drawing.Size(141, 23);
            this.dtp_NgayDK.TabIndex = 55;
            // 
            // labelX4
            // 
            this.labelX4.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelX4.Location = new System.Drawing.Point(283, 122);
            this.labelX4.Name = "labelX4";
            this.labelX4.Size = new System.Drawing.Size(101, 23);
            this.labelX4.TabIndex = 54;
            this.labelX4.Text = "Ngày đăng ký";
            // 
            // txt_SoGiayChungNhan
            // 
            // 
            // 
            // 
            this.txt_SoGiayChungNhan.Border.Class = "TextBoxBorder";
            this.txt_SoGiayChungNhan.Location = new System.Drawing.Point(26, 152);
            this.txt_SoGiayChungNhan.Name = "txt_SoGiayChungNhan";
            this.txt_SoGiayChungNhan.Size = new System.Drawing.Size(251, 23);
            this.txt_SoGiayChungNhan.TabIndex = 53;
            // 
            // labelX3
            // 
            this.labelX3.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelX3.Location = new System.Drawing.Point(26, 122);
            this.labelX3.Name = "labelX3";
            this.labelX3.Size = new System.Drawing.Size(232, 23);
            this.labelX3.TabIndex = 52;
            this.labelX3.Text = "Số giấy chứng nhận đăng ký kết hôn";
            // 
            // cbo_NhanVien
            // 
            this.cbo_NhanVien.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.cbo_NhanVien.Enabled = false;
            this.cbo_NhanVien.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbo_NhanVien.FormattingEnabled = true;
            this.cbo_NhanVien.ItemHeight = 16;
            this.cbo_NhanVien.Location = new System.Drawing.Point(26, 94);
            this.cbo_NhanVien.Name = "cbo_NhanVien";
            this.cbo_NhanVien.Size = new System.Drawing.Size(398, 22);
            this.cbo_NhanVien.TabIndex = 51;
            // 
            // labelX2
            // 
            this.labelX2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelX2.Location = new System.Drawing.Point(26, 69);
            this.labelX2.Name = "labelX2";
            this.labelX2.Size = new System.Drawing.Size(75, 23);
            this.labelX2.TabIndex = 50;
            this.labelX2.Text = "Nhân viên";
            // 
            // labelX1
            // 
            this.labelX1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(16)))), ((int)(((byte)(39)))), ((int)(((byte)(75)))));
            this.labelX1.Dock = System.Windows.Forms.DockStyle.Top;
            this.labelX1.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelX1.ForeColor = System.Drawing.Color.WhiteSmoke;
            this.labelX1.Location = new System.Drawing.Point(0, 0);
            this.labelX1.Name = "labelX1";
            this.labelX1.Size = new System.Drawing.Size(448, 54);
            this.labelX1.TabIndex = 26;
            this.labelX1.Text = "Nhân viên - Hôn nhân";
            this.labelX1.TextAlignment = System.Drawing.StringAlignment.Center;
            // 
            // btn_delete_pt2
            // 
            this.btn_delete_pt2.BackColor = System.Drawing.SystemColors.Control;
            this.btn_delete_pt2.BackGroundColor = System.Drawing.SystemColors.Control;
            this.btn_delete_pt2.BorderColor = System.Drawing.Color.PaleVioletRed;
            this.btn_delete_pt2.BorderRadius = 24;
            this.btn_delete_pt2.BorderSize = 0;
            this.btn_delete_pt2.FlatAppearance.BorderSize = 0;
            this.btn_delete_pt2.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_delete_pt2.ForeColor = System.Drawing.Color.White;
            this.btn_delete_pt2.Image = global::TENTAC_HRM.Properties.Resources.bin;
            this.btn_delete_pt2.Location = new System.Drawing.Point(340, 498);
            this.btn_delete_pt2.Name = "btn_delete_pt2";
            this.btn_delete_pt2.Size = new System.Drawing.Size(26, 24);
            this.btn_delete_pt2.TabIndex = 25;
            this.btn_delete_pt2.TextColor = System.Drawing.Color.White;
            this.btn_delete_pt2.UseVisualStyleBackColor = false;
            this.btn_delete_pt2.Click += new System.EventHandler(this.btn_delete_pt2_Click);
            // 
            // btn_delete_pt1
            // 
            this.btn_delete_pt1.BackColor = System.Drawing.SystemColors.Control;
            this.btn_delete_pt1.BackGroundColor = System.Drawing.SystemColors.Control;
            this.btn_delete_pt1.BorderColor = System.Drawing.Color.PaleVioletRed;
            this.btn_delete_pt1.BorderRadius = 24;
            this.btn_delete_pt1.BorderSize = 0;
            this.btn_delete_pt1.FlatAppearance.BorderSize = 0;
            this.btn_delete_pt1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_delete_pt1.ForeColor = System.Drawing.Color.White;
            this.btn_delete_pt1.Image = global::TENTAC_HRM.Properties.Resources.bin;
            this.btn_delete_pt1.Location = new System.Drawing.Point(144, 498);
            this.btn_delete_pt1.Name = "btn_delete_pt1";
            this.btn_delete_pt1.Size = new System.Drawing.Size(26, 24);
            this.btn_delete_pt1.TabIndex = 24;
            this.btn_delete_pt1.TextColor = System.Drawing.Color.White;
            this.btn_delete_pt1.UseVisualStyleBackColor = false;
            this.btn_delete_pt1.Click += new System.EventHandler(this.btn_delete_pt1_Click);
            // 
            // pb_MatSau
            // 
            this.pb_MatSau.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pb_MatSau.Location = new System.Drawing.Point(228, 267);
            this.pb_MatSau.Name = "pb_MatSau";
            this.pb_MatSau.Size = new System.Drawing.Size(196, 228);
            this.pb_MatSau.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pb_MatSau.TabIndex = 19;
            this.pb_MatSau.TabStop = false;
            // 
            // pb_MatTruoc
            // 
            this.pb_MatTruoc.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pb_MatTruoc.Location = new System.Drawing.Point(26, 267);
            this.pb_MatTruoc.Name = "pb_MatTruoc";
            this.pb_MatTruoc.Size = new System.Drawing.Size(196, 228);
            this.pb_MatTruoc.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pb_MatTruoc.TabIndex = 18;
            this.pb_MatTruoc.TabStop = false;
            // 
            // frm_honnhan
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(450, 598);
            this.Controls.Add(this.panel1);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.KeyPreview = true;
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "frm_honnhan";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Nhân viên - Hôn nhân";
            this.Load += new System.EventHandler(this.frm_honnhan_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.frm_honnhan_KeyDown);
            this.panel1.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dtp_NgayDK)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pb_MatSau)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pb_MatTruoc)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private RJButton.RJButton btn_delete_pt2;
        private RJButton.RJButton btn_delete_pt1;
        private System.Windows.Forms.Button btn_close;
        private System.Windows.Forms.Button btn_delete;
        private System.Windows.Forms.Button btn_luu;
        private System.Windows.Forms.PictureBox pb_MatSau;
        private System.Windows.Forms.PictureBox pb_MatTruoc;
        private DevComponents.DotNetBar.LabelX labelX1;
        private DevComponents.DotNetBar.LabelX labelX3;
        private DevComponents.DotNetBar.Controls.ComboBoxEx cbo_NhanVien;
        private DevComponents.DotNetBar.LabelX labelX2;
        private DevComponents.DotNetBar.LabelX labelX5;
        private DevComponents.Editors.DateTimeAdv.DateTimeInput dtp_NgayDK;
        private DevComponents.DotNetBar.LabelX labelX4;
        private DevComponents.DotNetBar.Controls.TextBoxX txt_SoGiayChungNhan;
        private DevComponents.DotNetBar.Controls.TextBoxX txt_NoiDK;
        private FontAwesome.Sharp.IconButton btn_update_pt2;
        private FontAwesome.Sharp.IconButton btn_update_pt1;
        private System.Windows.Forms.Panel panel2;
        private DevComponents.DotNetBar.LabelX labelX6;
        private DevComponents.DotNetBar.LabelX labelX7;
    }
}