﻿namespace TENTAC_HRM.Forms.Category
{
    partial class frm_certificate
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
            this.dtp_NgayNhanBang = new DevComponents.Editors.DateTimeAdv.DateTimeInput();
            this.panel2 = new System.Windows.Forms.Panel();
            this.btn_close = new System.Windows.Forms.Button();
            this.btn_save = new System.Windows.Forms.Button();
            this.cbo_NhanVien = new DevComponents.DotNetBar.Controls.ComboBoxEx();
            this.labelX2 = new DevComponents.DotNetBar.LabelX();
            this.txtGhiChu = new DevComponents.DotNetBar.Controls.TextBoxX();
            this.lblGhiChu = new DevComponents.DotNetBar.LabelX();
            this.cbo_ChungChi = new DevComponents.DotNetBar.Controls.ComboBoxEx();
            this.cbo_XepLoai = new DevComponents.DotNetBar.Controls.ComboBoxEx();
            this.labelX1 = new DevComponents.DotNetBar.LabelX();
            this.txt_Truong = new DevComponents.DotNetBar.Controls.TextBoxX();
            this.label5 = new DevComponents.DotNetBar.LabelX();
            this.label4 = new DevComponents.DotNetBar.LabelX();
            this.label3 = new DevComponents.DotNetBar.LabelX();
            this.label2 = new DevComponents.DotNetBar.LabelX();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dtp_NgayNhanBang)).BeginInit();
            this.panel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.dtp_NgayNhanBang);
            this.panel1.Controls.Add(this.panel2);
            this.panel1.Controls.Add(this.cbo_NhanVien);
            this.panel1.Controls.Add(this.labelX2);
            this.panel1.Controls.Add(this.txtGhiChu);
            this.panel1.Controls.Add(this.lblGhiChu);
            this.panel1.Controls.Add(this.cbo_ChungChi);
            this.panel1.Controls.Add(this.cbo_XepLoai);
            this.panel1.Controls.Add(this.labelX1);
            this.panel1.Controls.Add(this.txt_Truong);
            this.panel1.Controls.Add(this.label5);
            this.panel1.Controls.Add(this.label4);
            this.panel1.Controls.Add(this.label3);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(312, 534);
            this.panel1.TabIndex = 1;
            // 
            // dtp_NgayNhanBang
            // 
            // 
            // 
            // 
            this.dtp_NgayNhanBang.BackgroundStyle.Class = "DateTimeInputBackground";
            this.dtp_NgayNhanBang.ButtonDropDown.Visible = true;
            this.dtp_NgayNhanBang.Location = new System.Drawing.Point(27, 253);
            // 
            // 
            // 
            this.dtp_NgayNhanBang.MonthCalendar.AnnuallyMarkedDates = new System.DateTime[0];
            // 
            // 
            // 
            this.dtp_NgayNhanBang.MonthCalendar.BackgroundStyle.BackColor = System.Drawing.SystemColors.Window;
            this.dtp_NgayNhanBang.MonthCalendar.ClearButtonVisible = true;
            // 
            // 
            // 
            this.dtp_NgayNhanBang.MonthCalendar.CommandsBackgroundStyle.BackColor2SchemePart = DevComponents.DotNetBar.eColorSchemePart.BarBackground2;
            this.dtp_NgayNhanBang.MonthCalendar.CommandsBackgroundStyle.BackColorGradientAngle = 90;
            this.dtp_NgayNhanBang.MonthCalendar.CommandsBackgroundStyle.BackColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.BarBackground;
            this.dtp_NgayNhanBang.MonthCalendar.CommandsBackgroundStyle.BorderTop = DevComponents.DotNetBar.eStyleBorderType.Solid;
            this.dtp_NgayNhanBang.MonthCalendar.CommandsBackgroundStyle.BorderTopColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.BarDockedBorder;
            this.dtp_NgayNhanBang.MonthCalendar.CommandsBackgroundStyle.BorderTopWidth = 1;
            this.dtp_NgayNhanBang.MonthCalendar.DisplayMonth = new System.DateTime(2024, 10, 1, 0, 0, 0, 0);
            this.dtp_NgayNhanBang.MonthCalendar.MarkedDates = new System.DateTime[0];
            this.dtp_NgayNhanBang.MonthCalendar.MonthlyMarkedDates = new System.DateTime[0];
            // 
            // 
            // 
            this.dtp_NgayNhanBang.MonthCalendar.NavigationBackgroundStyle.BackColor2SchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground2;
            this.dtp_NgayNhanBang.MonthCalendar.NavigationBackgroundStyle.BackColorGradientAngle = 90;
            this.dtp_NgayNhanBang.MonthCalendar.NavigationBackgroundStyle.BackColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground;
            this.dtp_NgayNhanBang.MonthCalendar.TodayButtonVisible = true;
            this.dtp_NgayNhanBang.Name = "dtp_NgayNhanBang";
            this.dtp_NgayNhanBang.Size = new System.Drawing.Size(254, 23);
            this.dtp_NgayNhanBang.TabIndex = 4;
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(16)))), ((int)(((byte)(39)))), ((int)(((byte)(75)))));
            this.panel2.Controls.Add(this.btn_close);
            this.panel2.Controls.Add(this.btn_save);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel2.Location = new System.Drawing.Point(0, 479);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(312, 55);
            this.panel2.TabIndex = 43;
            // 
            // btn_close
            // 
            this.btn_close.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btn_close.Image = global::TENTAC_HRM.Properties.Resources.cancel;
            this.btn_close.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btn_close.Location = new System.Drawing.Point(171, 14);
            this.btn_close.Name = "btn_close";
            this.btn_close.Size = new System.Drawing.Size(110, 27);
            this.btn_close.TabIndex = 8;
            this.btn_close.Text = "Đóng";
            this.btn_close.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btn_close.UseVisualStyleBackColor = true;
            this.btn_close.Click += new System.EventHandler(this.btn_close_Click);
            // 
            // btn_save
            // 
            this.btn_save.Image = global::TENTAC_HRM.Properties.Resources.diskette;
            this.btn_save.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btn_save.Location = new System.Drawing.Point(27, 14);
            this.btn_save.Name = "btn_save";
            this.btn_save.Size = new System.Drawing.Size(110, 27);
            this.btn_save.TabIndex = 7;
            this.btn_save.Text = "Lưu";
            this.btn_save.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btn_save.UseVisualStyleBackColor = true;
            this.btn_save.Click += new System.EventHandler(this.btn_save_Click);
            // 
            // cbo_NhanVien
            // 
            this.cbo_NhanVien.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.cbo_NhanVien.Enabled = false;
            this.cbo_NhanVien.FormattingEnabled = true;
            this.cbo_NhanVien.ItemHeight = 17;
            this.cbo_NhanVien.Location = new System.Drawing.Point(27, 96);
            this.cbo_NhanVien.Name = "cbo_NhanVien";
            this.cbo_NhanVien.Size = new System.Drawing.Size(254, 23);
            this.cbo_NhanVien.TabIndex = 1;
            // 
            // labelX2
            // 
            this.labelX2.Location = new System.Drawing.Point(27, 67);
            this.labelX2.Name = "labelX2";
            this.labelX2.Size = new System.Drawing.Size(75, 23);
            this.labelX2.TabIndex = 41;
            this.labelX2.Text = "Nhân viên";
            // 
            // txtGhiChu
            // 
            // 
            // 
            // 
            this.txtGhiChu.Border.Class = "TextBoxBorder";
            this.txtGhiChu.Location = new System.Drawing.Point(27, 363);
            this.txtGhiChu.Multiline = true;
            this.txtGhiChu.Name = "txtGhiChu";
            this.txtGhiChu.Size = new System.Drawing.Size(254, 87);
            this.txtGhiChu.TabIndex = 6;
            // 
            // lblGhiChu
            // 
            this.lblGhiChu.Location = new System.Drawing.Point(27, 333);
            this.lblGhiChu.Name = "lblGhiChu";
            this.lblGhiChu.Size = new System.Drawing.Size(75, 23);
            this.lblGhiChu.TabIndex = 27;
            this.lblGhiChu.Text = "Ghi Chú";
            // 
            // cbo_ChungChi
            // 
            this.cbo_ChungChi.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.cbo_ChungChi.FormattingEnabled = true;
            this.cbo_ChungChi.ItemHeight = 17;
            this.cbo_ChungChi.Location = new System.Drawing.Point(27, 142);
            this.cbo_ChungChi.Name = "cbo_ChungChi";
            this.cbo_ChungChi.Size = new System.Drawing.Size(254, 23);
            this.cbo_ChungChi.TabIndex = 2;
            // 
            // cbo_XepLoai
            // 
            this.cbo_XepLoai.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.cbo_XepLoai.FormattingEnabled = true;
            this.cbo_XepLoai.ItemHeight = 17;
            this.cbo_XepLoai.Location = new System.Drawing.Point(27, 304);
            this.cbo_XepLoai.Name = "cbo_XepLoai";
            this.cbo_XepLoai.Size = new System.Drawing.Size(254, 23);
            this.cbo_XepLoai.TabIndex = 5;
            // 
            // labelX1
            // 
            this.labelX1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(16)))), ((int)(((byte)(39)))), ((int)(((byte)(75)))));
            this.labelX1.Dock = System.Windows.Forms.DockStyle.Top;
            this.labelX1.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelX1.ForeColor = System.Drawing.Color.WhiteSmoke;
            this.labelX1.Location = new System.Drawing.Point(0, 0);
            this.labelX1.Name = "labelX1";
            this.labelX1.Size = new System.Drawing.Size(312, 54);
            this.labelX1.TabIndex = 22;
            this.labelX1.Text = "Chứng Chỉ";
            this.labelX1.TextAlignment = System.Drawing.StringAlignment.Center;
            // 
            // txt_Truong
            // 
            // 
            // 
            // 
            this.txt_Truong.Border.Class = "TextBoxBorder";
            this.txt_Truong.Location = new System.Drawing.Point(27, 196);
            this.txt_Truong.Name = "txt_Truong";
            this.txt_Truong.Size = new System.Drawing.Size(254, 23);
            this.txt_Truong.TabIndex = 3;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(27, 279);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(57, 19);
            this.label5.TabIndex = 16;
            this.label5.Text = "Xếp loại";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(27, 225);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(107, 19);
            this.label4.TabIndex = 18;
            this.label4.Text = "Ngày nhận bằng";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(27, 171);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(100, 19);
            this.label3.TabIndex = 19;
            this.label3.Text = "Trường đào tạo";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(27, 121);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(69, 19);
            this.label2.TabIndex = 20;
            this.label2.Text = "Chứng chỉ";
            // 
            // frm_certificate
            // 
            this.AcceptButton = this.btn_save;
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.btn_close;
            this.ClientSize = new System.Drawing.Size(312, 534);
            this.Controls.Add(this.panel1);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Margin = new System.Windows.Forms.Padding(4);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frm_certificate";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Load += new System.EventHandler(this.frm_certificate_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dtp_NgayNhanBang)).EndInit();
            this.panel2.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private DevComponents.DotNetBar.Controls.ComboBoxEx cbo_NhanVien;
        private DevComponents.DotNetBar.LabelX labelX2;
        private DevComponents.DotNetBar.Controls.TextBoxX txtGhiChu;
        private DevComponents.DotNetBar.LabelX lblGhiChu;
        private DevComponents.DotNetBar.Controls.ComboBoxEx cbo_ChungChi;
        private DevComponents.DotNetBar.Controls.ComboBoxEx cbo_XepLoai;
        private DevComponents.DotNetBar.LabelX labelX1;
        private System.Windows.Forms.Button btn_save;
        private System.Windows.Forms.Button btn_close;
        private DevComponents.DotNetBar.Controls.TextBoxX txt_Truong;
        private DevComponents.DotNetBar.LabelX label5;
        private DevComponents.DotNetBar.LabelX label4;
        private DevComponents.DotNetBar.LabelX label3;
        private DevComponents.DotNetBar.LabelX label2;
        private System.Windows.Forms.Panel panel2;
        private DevComponents.Editors.DateTimeAdv.DateTimeInput dtp_NgayNhanBang;
    }
}