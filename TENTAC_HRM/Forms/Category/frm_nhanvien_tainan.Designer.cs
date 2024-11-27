namespace TENTAC_HRM.Forms.Category
{
    partial class frm_nhanvien_tainan
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
            this.txt_NoiDung = new DevComponents.DotNetBar.Controls.TextBoxX();
            this.txt_NoiDienRa = new DevComponents.DotNetBar.Controls.TextBoxX();
            this.label5 = new DevComponents.DotNetBar.LabelX();
            this.btn_save = new System.Windows.Forms.Button();
            this.label3 = new DevComponents.DotNetBar.LabelX();
            this.label2 = new DevComponents.DotNetBar.LabelX();
            this.cbo_NhanVien = new DevComponents.DotNetBar.Controls.ComboBoxEx();
            this.label1 = new DevComponents.DotNetBar.LabelX();
            this.panel2 = new System.Windows.Forms.Panel();
            this.btn_close = new System.Windows.Forms.Button();
            this.labelX1 = new DevComponents.DotNetBar.LabelX();
            this.panel1 = new System.Windows.Forms.Panel();
            this.dtp_NgayDienRa = new DevComponents.Editors.DateTimeAdv.DateTimeInput();
            this.cbo_MucDo = new DevComponents.DotNetBar.Controls.ComboBoxEx();
            this.labelX3 = new DevComponents.DotNetBar.LabelX();
            this.cbo_LoaiTaiNan = new DevComponents.DotNetBar.Controls.ComboBoxEx();
            this.labelX2 = new DevComponents.DotNetBar.LabelX();
            this.panel2.SuspendLayout();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dtp_NgayDienRa)).BeginInit();
            this.SuspendLayout();
            // 
            // txt_NoiDung
            // 
            // 
            // 
            // 
            this.txt_NoiDung.Border.Class = "TextBoxBorder";
            this.txt_NoiDung.Location = new System.Drawing.Point(24, 370);
            this.txt_NoiDung.Multiline = true;
            this.txt_NoiDung.Name = "txt_NoiDung";
            this.txt_NoiDung.Size = new System.Drawing.Size(288, 148);
            this.txt_NoiDung.TabIndex = 6;
            // 
            // txt_NoiDienRa
            // 
            // 
            // 
            // 
            this.txt_NoiDienRa.Border.Class = "TextBoxBorder";
            this.txt_NoiDienRa.Location = new System.Drawing.Point(24, 264);
            this.txt_NoiDienRa.Name = "txt_NoiDienRa";
            this.txt_NoiDienRa.Size = new System.Drawing.Size(285, 23);
            this.txt_NoiDienRa.TabIndex = 4;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(24, 345);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(62, 19);
            this.label5.TabIndex = 138;
            this.label5.Text = "Nội dung";
            // 
            // btn_save
            // 
            this.btn_save.Image = global::TENTAC_HRM.Properties.Resources.diskette;
            this.btn_save.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btn_save.Location = new System.Drawing.Point(24, 14);
            this.btn_save.Margin = new System.Windows.Forms.Padding(4);
            this.btn_save.Name = "btn_save";
            this.btn_save.Size = new System.Drawing.Size(110, 28);
            this.btn_save.TabIndex = 6;
            this.btn_save.Text = "Lưu";
            this.btn_save.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btn_save.UseVisualStyleBackColor = true;
            this.btn_save.Click += new System.EventHandler(this.btn_save_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(24, 293);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(85, 19);
            this.label3.TabIndex = 140;
            this.label3.Text = "Ngày diễn ra";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(24, 239);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(73, 19);
            this.label2.TabIndex = 141;
            this.label2.Text = "Nơi diễn ra";
            // 
            // cbo_NhanVien
            // 
            this.cbo_NhanVien.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.cbo_NhanVien.Enabled = false;
            this.cbo_NhanVien.FormattingEnabled = true;
            this.cbo_NhanVien.ItemHeight = 17;
            this.cbo_NhanVien.Location = new System.Drawing.Point(24, 102);
            this.cbo_NhanVien.Name = "cbo_NhanVien";
            this.cbo_NhanVien.Size = new System.Drawing.Size(285, 23);
            this.cbo_NhanVien.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(24, 77);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(69, 19);
            this.label1.TabIndex = 133;
            this.label1.Text = "Nhân viên";
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(16)))), ((int)(((byte)(39)))), ((int)(((byte)(75)))));
            this.panel2.Controls.Add(this.btn_save);
            this.panel2.Controls.Add(this.btn_close);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel2.Location = new System.Drawing.Point(0, 547);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(337, 55);
            this.panel2.TabIndex = 131;
            // 
            // btn_close
            // 
            this.btn_close.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btn_close.Image = global::TENTAC_HRM.Properties.Resources.clear;
            this.btn_close.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btn_close.Location = new System.Drawing.Point(202, 14);
            this.btn_close.Margin = new System.Windows.Forms.Padding(4);
            this.btn_close.Name = "btn_close";
            this.btn_close.Size = new System.Drawing.Size(110, 28);
            this.btn_close.TabIndex = 7;
            this.btn_close.Text = "Đóng";
            this.btn_close.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btn_close.UseVisualStyleBackColor = true;
            this.btn_close.Click += new System.EventHandler(this.btn_close_Click);
            // 
            // labelX1
            // 
            this.labelX1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(16)))), ((int)(((byte)(39)))), ((int)(((byte)(75)))));
            this.labelX1.Dock = System.Windows.Forms.DockStyle.Top;
            this.labelX1.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelX1.ForeColor = System.Drawing.Color.WhiteSmoke;
            this.labelX1.Location = new System.Drawing.Point(0, 0);
            this.labelX1.Name = "labelX1";
            this.labelX1.Size = new System.Drawing.Size(337, 58);
            this.labelX1.TabIndex = 37;
            this.labelX1.Text = "Nhân viên - Tai nạn";
            this.labelX1.TextAlignment = System.Drawing.StringAlignment.Center;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.dtp_NgayDienRa);
            this.panel1.Controls.Add(this.cbo_MucDo);
            this.panel1.Controls.Add(this.labelX3);
            this.panel1.Controls.Add(this.cbo_LoaiTaiNan);
            this.panel1.Controls.Add(this.labelX2);
            this.panel1.Controls.Add(this.txt_NoiDung);
            this.panel1.Controls.Add(this.txt_NoiDienRa);
            this.panel1.Controls.Add(this.label5);
            this.panel1.Controls.Add(this.label3);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.cbo_NhanVien);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.panel2);
            this.panel1.Controls.Add(this.labelX1);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(337, 602);
            this.panel1.TabIndex = 1;
            // 
            // dtp_NgayDienRa
            // 
            // 
            // 
            // 
            this.dtp_NgayDienRa.BackgroundStyle.Class = "DateTimeInputBackground";
            this.dtp_NgayDienRa.ButtonDropDown.Visible = true;
            this.dtp_NgayDienRa.Location = new System.Drawing.Point(24, 318);
            // 
            // 
            // 
            this.dtp_NgayDienRa.MonthCalendar.AnnuallyMarkedDates = new System.DateTime[0];
            // 
            // 
            // 
            this.dtp_NgayDienRa.MonthCalendar.BackgroundStyle.BackColor = System.Drawing.SystemColors.Window;
            this.dtp_NgayDienRa.MonthCalendar.ClearButtonVisible = true;
            // 
            // 
            // 
            this.dtp_NgayDienRa.MonthCalendar.CommandsBackgroundStyle.BackColor2SchemePart = DevComponents.DotNetBar.eColorSchemePart.BarBackground2;
            this.dtp_NgayDienRa.MonthCalendar.CommandsBackgroundStyle.BackColorGradientAngle = 90;
            this.dtp_NgayDienRa.MonthCalendar.CommandsBackgroundStyle.BackColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.BarBackground;
            this.dtp_NgayDienRa.MonthCalendar.CommandsBackgroundStyle.BorderTop = DevComponents.DotNetBar.eStyleBorderType.Solid;
            this.dtp_NgayDienRa.MonthCalendar.CommandsBackgroundStyle.BorderTopColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.BarDockedBorder;
            this.dtp_NgayDienRa.MonthCalendar.CommandsBackgroundStyle.BorderTopWidth = 1;
            this.dtp_NgayDienRa.MonthCalendar.DisplayMonth = new System.DateTime(2024, 10, 1, 0, 0, 0, 0);
            this.dtp_NgayDienRa.MonthCalendar.MarkedDates = new System.DateTime[0];
            this.dtp_NgayDienRa.MonthCalendar.MonthlyMarkedDates = new System.DateTime[0];
            // 
            // 
            // 
            this.dtp_NgayDienRa.MonthCalendar.NavigationBackgroundStyle.BackColor2SchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground2;
            this.dtp_NgayDienRa.MonthCalendar.NavigationBackgroundStyle.BackColorGradientAngle = 90;
            this.dtp_NgayDienRa.MonthCalendar.NavigationBackgroundStyle.BackColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground;
            this.dtp_NgayDienRa.MonthCalendar.TodayButtonVisible = true;
            this.dtp_NgayDienRa.Name = "dtp_NgayDienRa";
            this.dtp_NgayDienRa.Size = new System.Drawing.Size(282, 23);
            this.dtp_NgayDienRa.TabIndex = 5;
            // 
            // cbo_MucDo
            // 
            this.cbo_MucDo.DisplayMember = "Text";
            this.cbo_MucDo.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.cbo_MucDo.FormattingEnabled = true;
            this.cbo_MucDo.ItemHeight = 17;
            this.cbo_MucDo.Location = new System.Drawing.Point(24, 210);
            this.cbo_MucDo.Name = "cbo_MucDo";
            this.cbo_MucDo.Size = new System.Drawing.Size(285, 23);
            this.cbo_MucDo.TabIndex = 3;
            // 
            // labelX3
            // 
            this.labelX3.AutoSize = true;
            this.labelX3.Location = new System.Drawing.Point(24, 185);
            this.labelX3.Name = "labelX3";
            this.labelX3.Size = new System.Drawing.Size(97, 19);
            this.labelX3.TabIndex = 146;
            this.labelX3.Text = "Mức độ tai nạn";
            // 
            // cbo_LoaiTaiNan
            // 
            this.cbo_LoaiTaiNan.DisplayMember = "Text";
            this.cbo_LoaiTaiNan.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.cbo_LoaiTaiNan.FormattingEnabled = true;
            this.cbo_LoaiTaiNan.ItemHeight = 17;
            this.cbo_LoaiTaiNan.Location = new System.Drawing.Point(24, 156);
            this.cbo_LoaiTaiNan.Name = "cbo_LoaiTaiNan";
            this.cbo_LoaiTaiNan.Size = new System.Drawing.Size(285, 23);
            this.cbo_LoaiTaiNan.TabIndex = 2;
            // 
            // labelX2
            // 
            this.labelX2.AutoSize = true;
            this.labelX2.Location = new System.Drawing.Point(24, 131);
            this.labelX2.Name = "labelX2";
            this.labelX2.Size = new System.Drawing.Size(122, 19);
            this.labelX2.TabIndex = 144;
            this.labelX2.Text = "Trường hợp tai nạn";
            // 
            // frm_nhanvien_tainan
            // 
            this.AcceptButton = this.btn_save;
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.btn_close;
            this.ClientSize = new System.Drawing.Size(337, 602);
            this.Controls.Add(this.panel1);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Margin = new System.Windows.Forms.Padding(4);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frm_nhanvien_tainan";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Load += new System.EventHandler(this.frm_nhanvien_tainan_Load);
            this.panel2.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dtp_NgayDienRa)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevComponents.DotNetBar.Controls.TextBoxX txt_NoiDung;
        private DevComponents.DotNetBar.Controls.TextBoxX txt_NoiDienRa;
        private DevComponents.DotNetBar.LabelX label5;
        public System.Windows.Forms.Button btn_save;
        private DevComponents.DotNetBar.LabelX label3;
        private DevComponents.DotNetBar.LabelX label2;
        private DevComponents.DotNetBar.Controls.ComboBoxEx cbo_NhanVien;
        private DevComponents.DotNetBar.LabelX label1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Button btn_close;
        private DevComponents.DotNetBar.LabelX labelX1;
        private System.Windows.Forms.Panel panel1;
        private DevComponents.DotNetBar.Controls.ComboBoxEx cbo_MucDo;
        private DevComponents.DotNetBar.LabelX labelX3;
        private DevComponents.DotNetBar.Controls.ComboBoxEx cbo_LoaiTaiNan;
        private DevComponents.DotNetBar.LabelX labelX2;
        private DevComponents.Editors.DateTimeAdv.DateTimeInput dtp_NgayDienRa;
    }
}