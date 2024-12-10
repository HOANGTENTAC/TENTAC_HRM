namespace TENTAC_HRM.Forms.NghiPhep
{
    partial class frm_QuanLyXacNhan
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
            this.txt_TenNhanVien = new DevComponents.DotNetBar.Controls.TextBoxX();
            this.labelX1 = new DevComponents.DotNetBar.LabelX();
            this.labelX2 = new DevComponents.DotNetBar.LabelX();
            this.dtp_NgayNghi = new DevComponents.Editors.DateTimeAdv.DateTimeInput();
            this.labelX3 = new DevComponents.DotNetBar.LabelX();
            this.txt_GhiChu = new DevComponents.DotNetBar.Controls.TextBoxX();
            this.btn_XacNhan = new DevComponents.DotNetBar.ButtonX();
            this.btn_KhongXacNhan = new DevComponents.DotNetBar.ButtonX();
            ((System.ComponentModel.ISupportInitialize)(this.dtp_NgayNghi)).BeginInit();
            this.SuspendLayout();
            // 
            // txt_TenNhanVien
            // 
            // 
            // 
            // 
            this.txt_TenNhanVien.Border.Class = "TextBoxBorder";
            this.txt_TenNhanVien.Location = new System.Drawing.Point(93, 13);
            this.txt_TenNhanVien.Name = "txt_TenNhanVien";
            this.txt_TenNhanVien.ReadOnly = true;
            this.txt_TenNhanVien.Size = new System.Drawing.Size(208, 20);
            this.txt_TenNhanVien.TabIndex = 0;
            // 
            // labelX1
            // 
            this.labelX1.Location = new System.Drawing.Point(12, 12);
            this.labelX1.Name = "labelX1";
            this.labelX1.Size = new System.Drawing.Size(75, 23);
            this.labelX1.TabIndex = 1;
            this.labelX1.Text = "Nhân viên";
            // 
            // labelX2
            // 
            this.labelX2.Location = new System.Drawing.Point(12, 41);
            this.labelX2.Name = "labelX2";
            this.labelX2.Size = new System.Drawing.Size(75, 23);
            this.labelX2.TabIndex = 1;
            this.labelX2.Text = "Ngày nghỉ";
            // 
            // dtp_NgayNghi
            // 
            // 
            // 
            // 
            this.dtp_NgayNghi.BackgroundStyle.Class = "DateTimeInputBackground";
            this.dtp_NgayNghi.ButtonDropDown.Visible = true;
            this.dtp_NgayNghi.Enabled = false;
            this.dtp_NgayNghi.Location = new System.Drawing.Point(93, 42);
            // 
            // 
            // 
            this.dtp_NgayNghi.MonthCalendar.AnnuallyMarkedDates = new System.DateTime[0];
            // 
            // 
            // 
            this.dtp_NgayNghi.MonthCalendar.BackgroundStyle.BackColor = System.Drawing.SystemColors.Window;
            this.dtp_NgayNghi.MonthCalendar.ClearButtonVisible = true;
            // 
            // 
            // 
            this.dtp_NgayNghi.MonthCalendar.CommandsBackgroundStyle.BackColor2SchemePart = DevComponents.DotNetBar.eColorSchemePart.BarBackground2;
            this.dtp_NgayNghi.MonthCalendar.CommandsBackgroundStyle.BackColorGradientAngle = 90;
            this.dtp_NgayNghi.MonthCalendar.CommandsBackgroundStyle.BackColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.BarBackground;
            this.dtp_NgayNghi.MonthCalendar.CommandsBackgroundStyle.BorderTop = DevComponents.DotNetBar.eStyleBorderType.Solid;
            this.dtp_NgayNghi.MonthCalendar.CommandsBackgroundStyle.BorderTopColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.BarDockedBorder;
            this.dtp_NgayNghi.MonthCalendar.CommandsBackgroundStyle.BorderTopWidth = 1;
            this.dtp_NgayNghi.MonthCalendar.DisplayMonth = new System.DateTime(2024, 12, 1, 0, 0, 0, 0);
            this.dtp_NgayNghi.MonthCalendar.MarkedDates = new System.DateTime[0];
            this.dtp_NgayNghi.MonthCalendar.MonthlyMarkedDates = new System.DateTime[0];
            // 
            // 
            // 
            this.dtp_NgayNghi.MonthCalendar.NavigationBackgroundStyle.BackColor2SchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground2;
            this.dtp_NgayNghi.MonthCalendar.NavigationBackgroundStyle.BackColorGradientAngle = 90;
            this.dtp_NgayNghi.MonthCalendar.NavigationBackgroundStyle.BackColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground;
            this.dtp_NgayNghi.MonthCalendar.TodayButtonVisible = true;
            this.dtp_NgayNghi.Name = "dtp_NgayNghi";
            this.dtp_NgayNghi.Size = new System.Drawing.Size(207, 20);
            this.dtp_NgayNghi.TabIndex = 1;
            // 
            // labelX3
            // 
            this.labelX3.Location = new System.Drawing.Point(12, 70);
            this.labelX3.Name = "labelX3";
            this.labelX3.Size = new System.Drawing.Size(75, 23);
            this.labelX3.TabIndex = 1;
            this.labelX3.Text = "Lý do";
            // 
            // txt_GhiChu
            // 
            // 
            // 
            // 
            this.txt_GhiChu.Border.Class = "TextBoxBorder";
            this.txt_GhiChu.Location = new System.Drawing.Point(93, 71);
            this.txt_GhiChu.Multiline = true;
            this.txt_GhiChu.Name = "txt_GhiChu";
            this.txt_GhiChu.ReadOnly = true;
            this.txt_GhiChu.Size = new System.Drawing.Size(208, 100);
            this.txt_GhiChu.TabIndex = 2;
            // 
            // btn_XacNhan
            // 
            this.btn_XacNhan.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.btn_XacNhan.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            this.btn_XacNhan.Location = new System.Drawing.Point(217, 177);
            this.btn_XacNhan.Name = "btn_XacNhan";
            this.btn_XacNhan.Size = new System.Drawing.Size(83, 31);
            this.btn_XacNhan.TabIndex = 3;
            this.btn_XacNhan.Text = "Xác nhận";
            this.btn_XacNhan.Click += new System.EventHandler(this.btn_XacNhan_Click);
            // 
            // btn_KhongXacNhan
            // 
            this.btn_KhongXacNhan.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.btn_KhongXacNhan.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            this.btn_KhongXacNhan.ForeColor = System.Drawing.Color.Red;
            this.btn_KhongXacNhan.Location = new System.Drawing.Point(93, 177);
            this.btn_KhongXacNhan.Name = "btn_KhongXacNhan";
            this.btn_KhongXacNhan.Size = new System.Drawing.Size(118, 31);
            this.btn_KhongXacNhan.TabIndex = 4;
            this.btn_KhongXacNhan.Text = "Không xác nhận";
            this.btn_KhongXacNhan.Click += new System.EventHandler(this.btn_KhongXacNhan_Click);
            // 
            // frm_QuanLyXacNhan
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(312, 219);
            this.Controls.Add(this.btn_KhongXacNhan);
            this.Controls.Add(this.btn_XacNhan);
            this.Controls.Add(this.dtp_NgayNghi);
            this.Controls.Add(this.labelX3);
            this.Controls.Add(this.labelX2);
            this.Controls.Add(this.labelX1);
            this.Controls.Add(this.txt_GhiChu);
            this.Controls.Add(this.txt_TenNhanVien);
            this.Name = "frm_QuanLyXacNhan";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Xác nhận của quản lý";
            this.Load += new System.EventHandler(this.frm_QuanLyXacNhan_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dtp_NgayNghi)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevComponents.DotNetBar.Controls.TextBoxX txt_TenNhanVien;
        private DevComponents.DotNetBar.LabelX labelX1;
        private DevComponents.DotNetBar.LabelX labelX2;
        private DevComponents.Editors.DateTimeAdv.DateTimeInput dtp_NgayNghi;
        private DevComponents.DotNetBar.LabelX labelX3;
        private DevComponents.DotNetBar.Controls.TextBoxX txt_GhiChu;
        private DevComponents.DotNetBar.ButtonX btn_XacNhan;
        private DevComponents.DotNetBar.ButtonX btn_KhongXacNhan;
    }
}