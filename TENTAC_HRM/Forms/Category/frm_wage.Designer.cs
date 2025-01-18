namespace TENTAC_HRM.Forms.Category
{
    partial class frm_wage
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            this.labelX1 = new DevComponents.DotNetBar.LabelX();
            this.panel3 = new System.Windows.Forms.Panel();
            this.btn_clear = new System.Windows.Forms.Button();
            this.btn_close = new System.Windows.Forms.Button();
            this.btn_save = new System.Windows.Forms.Button();
            this.cbo_NhanVien = new DevComponents.DotNetBar.Controls.ComboBoxEx();
            this.labelX2 = new DevComponents.DotNetBar.LabelX();
            this.labelX3 = new DevComponents.DotNetBar.LabelX();
            this.txt_MucLuong = new DevComponents.DotNetBar.Controls.TextBoxX();
            this.chk_HieuLuc = new DevComponents.DotNetBar.Controls.CheckBoxX();
            this.chk_BHXH = new DevComponents.DotNetBar.Controls.CheckBoxX();
            this.chk_BHYT = new DevComponents.DotNetBar.Controls.CheckBoxX();
            this.chk_BHTN = new DevComponents.DotNetBar.Controls.CheckBoxX();
            this.chk_PhiCD = new DevComponents.DotNetBar.Controls.CheckBoxX();
            this.chk_MienThue = new DevComponents.DotNetBar.Controls.CheckBoxX();
            this.chk_ThueTheoThuNhapCD = new DevComponents.DotNetBar.Controls.CheckBoxX();
            this.labelX4 = new DevComponents.DotNetBar.LabelX();
            this.txt_PhiThuNhapCaNhan = new DevComponents.DotNetBar.Controls.TextBoxX();
            this.labelX5 = new DevComponents.DotNetBar.LabelX();
            this.labelX6 = new DevComponents.DotNetBar.LabelX();
            this.dtp_TuNgay = new DevComponents.Editors.DateTimeAdv.DateTimeInput();
            this.dtp_DenNgay = new DevComponents.Editors.DateTimeAdv.DateTimeInput();
            this.labelX7 = new DevComponents.DotNetBar.LabelX();
            this.txt_GhiChu = new DevComponents.DotNetBar.Controls.TextBoxX();
            this.panel1 = new System.Windows.Forms.Panel();
            this.dgv_Luong = new DevComponents.DotNetBar.Controls.DataGridViewX();
            this.ID = new ComponentFactory.Krypton.Toolkit.KryptonDataGridViewTextBoxColumn();
            this.delete_column = new System.Windows.Forms.DataGridViewImageColumn();
            this.edit_column = new System.Windows.Forms.DataGridViewImageColumn();
            this.TuNgay = new ComponentFactory.Krypton.Toolkit.KryptonDataGridViewTextBoxColumn();
            this.DenNgay = new ComponentFactory.Krypton.Toolkit.KryptonDataGridViewTextBoxColumn();
            this.MucLuong = new ComponentFactory.Krypton.Toolkit.KryptonDataGridViewTextBoxColumn();
            this.PT_ThueTNCN = new ComponentFactory.Krypton.Toolkit.KryptonDataGridViewTextBoxColumn();
            this.IsActive = new ComponentFactory.Krypton.Toolkit.KryptonDataGridViewCheckBoxColumn();
            this.label1 = new System.Windows.Forms.Label();
            this.panel3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dtp_TuNgay)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtp_DenNgay)).BeginInit();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgv_Luong)).BeginInit();
            this.SuspendLayout();
            // 
            // labelX1
            // 
            this.labelX1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(16)))), ((int)(((byte)(39)))), ((int)(((byte)(75)))));
            this.labelX1.Dock = System.Windows.Forms.DockStyle.Top;
            this.labelX1.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelX1.ForeColor = System.Drawing.Color.WhiteSmoke;
            this.labelX1.Location = new System.Drawing.Point(0, 0);
            this.labelX1.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.labelX1.Name = "labelX1";
            this.labelX1.Size = new System.Drawing.Size(1129, 54);
            this.labelX1.TabIndex = 144;
            this.labelX1.Text = "Nhân viên - Lương";
            this.labelX1.TextAlignment = System.Drawing.StringAlignment.Center;
            // 
            // panel3
            // 
            this.panel3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(16)))), ((int)(((byte)(39)))), ((int)(((byte)(75)))));
            this.panel3.Controls.Add(this.btn_clear);
            this.panel3.Controls.Add(this.btn_close);
            this.panel3.Controls.Add(this.btn_save);
            this.panel3.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel3.Location = new System.Drawing.Point(0, 499);
            this.panel3.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(1129, 55);
            this.panel3.TabIndex = 145;
            // 
            // btn_clear
            // 
            this.btn_clear.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_clear.Image = global::TENTAC_HRM.Properties.Resources.ClearContent;
            this.btn_clear.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btn_clear.Location = new System.Drawing.Point(899, 17);
            this.btn_clear.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btn_clear.Name = "btn_clear";
            this.btn_clear.Size = new System.Drawing.Size(91, 27);
            this.btn_clear.TabIndex = 15;
            this.btn_clear.Text = "Đặt lại";
            this.btn_clear.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btn_clear.UseVisualStyleBackColor = true;
            this.btn_clear.Click += new System.EventHandler(this.btn_clear_Click);
            // 
            // btn_close
            // 
            this.btn_close.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_close.Image = global::TENTAC_HRM.Properties.Resources.cancel;
            this.btn_close.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btn_close.Location = new System.Drawing.Point(1019, 17);
            this.btn_close.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btn_close.Name = "btn_close";
            this.btn_close.Size = new System.Drawing.Size(91, 27);
            this.btn_close.TabIndex = 16;
            this.btn_close.Text = "Đóng";
            this.btn_close.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btn_close.UseVisualStyleBackColor = true;
            this.btn_close.Click += new System.EventHandler(this.btn_close_Click);
            // 
            // btn_save
            // 
            this.btn_save.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_save.Image = global::TENTAC_HRM.Properties.Resources.diskette;
            this.btn_save.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btn_save.Location = new System.Drawing.Point(783, 17);
            this.btn_save.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btn_save.Name = "btn_save";
            this.btn_save.Size = new System.Drawing.Size(91, 27);
            this.btn_save.TabIndex = 14;
            this.btn_save.Text = "Lưu";
            this.btn_save.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btn_save.UseVisualStyleBackColor = true;
            this.btn_save.Click += new System.EventHandler(this.btn_save_Click);
            // 
            // cbo_NhanVien
            // 
            this.cbo_NhanVien.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.cbo_NhanVien.Enabled = false;
            this.cbo_NhanVien.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbo_NhanVien.FormattingEnabled = true;
            this.cbo_NhanVien.ItemHeight = 16;
            this.cbo_NhanVien.Location = new System.Drawing.Point(783, 99);
            this.cbo_NhanVien.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.cbo_NhanVien.Name = "cbo_NhanVien";
            this.cbo_NhanVien.Size = new System.Drawing.Size(321, 22);
            this.cbo_NhanVien.TabIndex = 1;
            // 
            // labelX2
            // 
            this.labelX2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelX2.Location = new System.Drawing.Point(783, 72);
            this.labelX2.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.labelX2.Name = "labelX2";
            this.labelX2.Size = new System.Drawing.Size(75, 23);
            this.labelX2.TabIndex = 147;
            this.labelX2.Text = "Nhân viên";
            // 
            // labelX3
            // 
            this.labelX3.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelX3.Location = new System.Drawing.Point(783, 125);
            this.labelX3.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.labelX3.Name = "labelX3";
            this.labelX3.Size = new System.Drawing.Size(75, 23);
            this.labelX3.TabIndex = 149;
            this.labelX3.Text = "Mức lương";
            // 
            // txt_MucLuong
            // 
            // 
            // 
            // 
            this.txt_MucLuong.Border.Class = "TextBoxBorder";
            this.txt_MucLuong.Location = new System.Drawing.Point(783, 153);
            this.txt_MucLuong.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.txt_MucLuong.Name = "txt_MucLuong";
            this.txt_MucLuong.Size = new System.Drawing.Size(205, 23);
            this.txt_MucLuong.TabIndex = 2;
            this.txt_MucLuong.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.Textbox_KeyPress);
            this.txt_MucLuong.Leave += new System.EventHandler(this.txt_mucluong_Leave);
            // 
            // chk_HieuLuc
            // 
            this.chk_HieuLuc.Location = new System.Drawing.Point(995, 153);
            this.chk_HieuLuc.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.chk_HieuLuc.Name = "chk_HieuLuc";
            this.chk_HieuLuc.Size = new System.Drawing.Size(115, 23);
            this.chk_HieuLuc.TabIndex = 3;
            this.chk_HieuLuc.Text = "Đang hiệu lực";
            // 
            // chk_BHXH
            // 
            this.chk_BHXH.Location = new System.Drawing.Point(783, 181);
            this.chk_BHXH.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.chk_BHXH.Name = "chk_BHXH";
            this.chk_BHXH.Size = new System.Drawing.Size(115, 23);
            this.chk_BHXH.TabIndex = 4;
            this.chk_BHXH.Text = "Đóng BHXH";
            // 
            // chk_BHYT
            // 
            this.chk_BHYT.Location = new System.Drawing.Point(783, 211);
            this.chk_BHYT.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.chk_BHYT.Name = "chk_BHYT";
            this.chk_BHYT.Size = new System.Drawing.Size(115, 23);
            this.chk_BHYT.TabIndex = 5;
            this.chk_BHYT.Text = "Đóng BHYT";
            // 
            // chk_BHTN
            // 
            this.chk_BHTN.Location = new System.Drawing.Point(783, 240);
            this.chk_BHTN.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.chk_BHTN.Name = "chk_BHTN";
            this.chk_BHTN.Size = new System.Drawing.Size(115, 23);
            this.chk_BHTN.TabIndex = 6;
            this.chk_BHTN.Text = "Đóng BHTN";
            // 
            // chk_PhiCD
            // 
            this.chk_PhiCD.Location = new System.Drawing.Point(783, 269);
            this.chk_PhiCD.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.chk_PhiCD.Name = "chk_PhiCD";
            this.chk_PhiCD.Size = new System.Drawing.Size(115, 23);
            this.chk_PhiCD.TabIndex = 7;
            this.chk_PhiCD.Text = "Đóng Phí CĐ";
            // 
            // chk_MienThue
            // 
            this.chk_MienThue.Location = new System.Drawing.Point(909, 181);
            this.chk_MienThue.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.chk_MienThue.Name = "chk_MienThue";
            this.chk_MienThue.Size = new System.Drawing.Size(191, 23);
            this.chk_MienThue.TabIndex = 8;
            this.chk_MienThue.Text = "Miễn đóng thuế thu nhập";
            // 
            // chk_ThueTheoThuNhapCD
            // 
            this.chk_ThueTheoThuNhapCD.Location = new System.Drawing.Point(909, 211);
            this.chk_ThueTheoThuNhapCD.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.chk_ThueTheoThuNhapCD.Name = "chk_ThueTheoThuNhapCD";
            this.chk_ThueTheoThuNhapCD.Size = new System.Drawing.Size(211, 23);
            this.chk_ThueTheoThuNhapCD.TabIndex = 9;
            this.chk_ThueTheoThuNhapCD.Text = "Tính thuế theo thu nhập % CĐ";
            // 
            // labelX4
            // 
            this.labelX4.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelX4.Location = new System.Drawing.Point(913, 239);
            this.labelX4.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.labelX4.Name = "labelX4";
            this.labelX4.Size = new System.Drawing.Size(99, 23);
            this.labelX4.TabIndex = 158;
            this.labelX4.Text = "Mức đóng thuế";
            // 
            // txt_PhiThuNhapCaNhan
            // 
            // 
            // 
            // 
            this.txt_PhiThuNhapCaNhan.Border.Class = "TextBoxBorder";
            this.txt_PhiThuNhapCaNhan.Location = new System.Drawing.Point(913, 268);
            this.txt_PhiThuNhapCaNhan.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.txt_PhiThuNhapCaNhan.Name = "txt_PhiThuNhapCaNhan";
            this.txt_PhiThuNhapCaNhan.Size = new System.Drawing.Size(165, 23);
            this.txt_PhiThuNhapCaNhan.TabIndex = 10;
            this.txt_PhiThuNhapCaNhan.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.Textbox_KeyPress);
            // 
            // labelX5
            // 
            this.labelX5.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelX5.Location = new System.Drawing.Point(783, 297);
            this.labelX5.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.labelX5.Name = "labelX5";
            this.labelX5.Size = new System.Drawing.Size(75, 23);
            this.labelX5.TabIndex = 160;
            this.labelX5.Text = "Từ ngày";
            // 
            // labelX6
            // 
            this.labelX6.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelX6.Location = new System.Drawing.Point(955, 297);
            this.labelX6.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.labelX6.Name = "labelX6";
            this.labelX6.Size = new System.Drawing.Size(75, 23);
            this.labelX6.TabIndex = 161;
            this.labelX6.Text = "Đến ngày";
            // 
            // dtp_TuNgay
            // 
            // 
            // 
            // 
            this.dtp_TuNgay.BackgroundStyle.Class = "DateTimeInputBackground";
            this.dtp_TuNgay.ButtonDropDown.Visible = true;
            this.dtp_TuNgay.Location = new System.Drawing.Point(783, 325);
            this.dtp_TuNgay.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            // 
            // 
            // 
            this.dtp_TuNgay.MonthCalendar.AnnuallyMarkedDates = new System.DateTime[0];
            // 
            // 
            // 
            this.dtp_TuNgay.MonthCalendar.BackgroundStyle.BackColor = System.Drawing.SystemColors.Window;
            this.dtp_TuNgay.MonthCalendar.ClearButtonVisible = true;
            // 
            // 
            // 
            this.dtp_TuNgay.MonthCalendar.CommandsBackgroundStyle.BackColor2SchemePart = DevComponents.DotNetBar.eColorSchemePart.BarBackground2;
            this.dtp_TuNgay.MonthCalendar.CommandsBackgroundStyle.BackColorGradientAngle = 90;
            this.dtp_TuNgay.MonthCalendar.CommandsBackgroundStyle.BackColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.BarBackground;
            this.dtp_TuNgay.MonthCalendar.CommandsBackgroundStyle.BorderTop = DevComponents.DotNetBar.eStyleBorderType.Solid;
            this.dtp_TuNgay.MonthCalendar.CommandsBackgroundStyle.BorderTopColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.BarDockedBorder;
            this.dtp_TuNgay.MonthCalendar.CommandsBackgroundStyle.BorderTopWidth = 1;
            this.dtp_TuNgay.MonthCalendar.DisplayMonth = new System.DateTime(2024, 11, 1, 0, 0, 0, 0);
            this.dtp_TuNgay.MonthCalendar.MarkedDates = new System.DateTime[0];
            this.dtp_TuNgay.MonthCalendar.MonthlyMarkedDates = new System.DateTime[0];
            // 
            // 
            // 
            this.dtp_TuNgay.MonthCalendar.NavigationBackgroundStyle.BackColor2SchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground2;
            this.dtp_TuNgay.MonthCalendar.NavigationBackgroundStyle.BackColorGradientAngle = 90;
            this.dtp_TuNgay.MonthCalendar.NavigationBackgroundStyle.BackColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground;
            this.dtp_TuNgay.MonthCalendar.TodayButtonVisible = true;
            this.dtp_TuNgay.Name = "dtp_TuNgay";
            this.dtp_TuNgay.Size = new System.Drawing.Size(157, 23);
            this.dtp_TuNgay.TabIndex = 11;
            // 
            // dtp_DenNgay
            // 
            // 
            // 
            // 
            this.dtp_DenNgay.BackgroundStyle.Class = "DateTimeInputBackground";
            this.dtp_DenNgay.ButtonDropDown.Visible = true;
            this.dtp_DenNgay.Location = new System.Drawing.Point(955, 325);
            this.dtp_DenNgay.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            // 
            // 
            // 
            this.dtp_DenNgay.MonthCalendar.AnnuallyMarkedDates = new System.DateTime[0];
            // 
            // 
            // 
            this.dtp_DenNgay.MonthCalendar.BackgroundStyle.BackColor = System.Drawing.SystemColors.Window;
            this.dtp_DenNgay.MonthCalendar.ClearButtonVisible = true;
            // 
            // 
            // 
            this.dtp_DenNgay.MonthCalendar.CommandsBackgroundStyle.BackColor2SchemePart = DevComponents.DotNetBar.eColorSchemePart.BarBackground2;
            this.dtp_DenNgay.MonthCalendar.CommandsBackgroundStyle.BackColorGradientAngle = 90;
            this.dtp_DenNgay.MonthCalendar.CommandsBackgroundStyle.BackColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.BarBackground;
            this.dtp_DenNgay.MonthCalendar.CommandsBackgroundStyle.BorderTop = DevComponents.DotNetBar.eStyleBorderType.Solid;
            this.dtp_DenNgay.MonthCalendar.CommandsBackgroundStyle.BorderTopColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.BarDockedBorder;
            this.dtp_DenNgay.MonthCalendar.CommandsBackgroundStyle.BorderTopWidth = 1;
            this.dtp_DenNgay.MonthCalendar.DisplayMonth = new System.DateTime(2024, 11, 1, 0, 0, 0, 0);
            this.dtp_DenNgay.MonthCalendar.MarkedDates = new System.DateTime[0];
            this.dtp_DenNgay.MonthCalendar.MonthlyMarkedDates = new System.DateTime[0];
            // 
            // 
            // 
            this.dtp_DenNgay.MonthCalendar.NavigationBackgroundStyle.BackColor2SchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground2;
            this.dtp_DenNgay.MonthCalendar.NavigationBackgroundStyle.BackColorGradientAngle = 90;
            this.dtp_DenNgay.MonthCalendar.NavigationBackgroundStyle.BackColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground;
            this.dtp_DenNgay.MonthCalendar.TodayButtonVisible = true;
            this.dtp_DenNgay.Name = "dtp_DenNgay";
            this.dtp_DenNgay.Size = new System.Drawing.Size(157, 23);
            this.dtp_DenNgay.TabIndex = 12;
            // 
            // labelX7
            // 
            this.labelX7.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelX7.Location = new System.Drawing.Point(783, 352);
            this.labelX7.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.labelX7.Name = "labelX7";
            this.labelX7.Size = new System.Drawing.Size(75, 23);
            this.labelX7.TabIndex = 164;
            this.labelX7.Text = "Ghi chú";
            // 
            // txt_GhiChu
            // 
            // 
            // 
            // 
            this.txt_GhiChu.Border.Class = "TextBoxBorder";
            this.txt_GhiChu.Location = new System.Drawing.Point(783, 382);
            this.txt_GhiChu.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.txt_GhiChu.Multiline = true;
            this.txt_GhiChu.Name = "txt_GhiChu";
            this.txt_GhiChu.Size = new System.Drawing.Size(329, 89);
            this.txt_GhiChu.TabIndex = 13;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.dgv_Luong);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Left;
            this.panel1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.panel1.Location = new System.Drawing.Point(0, 54);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(761, 445);
            this.panel1.TabIndex = 166;
            // 
            // dgv_Luong
            // 
            this.dgv_Luong.AllowUserToAddRows = false;
            this.dgv_Luong.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgv_Luong.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.ID,
            this.delete_column,
            this.edit_column,
            this.TuNgay,
            this.DenNgay,
            this.MucLuong,
            this.PT_ThueTNCN,
            this.IsActive});
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgv_Luong.DefaultCellStyle = dataGridViewCellStyle2;
            this.dgv_Luong.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgv_Luong.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(215)))), ((int)(((byte)(229)))));
            this.dgv_Luong.Location = new System.Drawing.Point(0, 0);
            this.dgv_Luong.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.dgv_Luong.Name = "dgv_Luong";
            this.dgv_Luong.Size = new System.Drawing.Size(761, 445);
            this.dgv_Luong.TabIndex = 147;
            this.dgv_Luong.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgv_luong_CellClick);
            // 
            // ID
            // 
            this.ID.DataPropertyName = "ID";
            this.ID.HeaderText = "ID";
            this.ID.Name = "ID";
            this.ID.Visible = false;
            this.ID.Width = 100;
            // 
            // delete_column
            // 
            this.delete_column.HeaderText = "";
            this.delete_column.Image = global::TENTAC_HRM.Properties.Resources.bin;
            this.delete_column.Name = "delete_column";
            this.delete_column.Width = 50;
            // 
            // edit_column
            // 
            this.edit_column.HeaderText = "";
            this.edit_column.Image = global::TENTAC_HRM.Properties.Resources.pen;
            this.edit_column.Name = "edit_column";
            this.edit_column.Width = 50;
            // 
            // TuNgay
            // 
            this.TuNgay.DataPropertyName = "TuNgay";
            this.TuNgay.HeaderText = "Từ ngày";
            this.TuNgay.Name = "TuNgay";
            this.TuNgay.Width = 100;
            // 
            // DenNgay
            // 
            this.DenNgay.DataPropertyName = "DenNgay";
            this.DenNgay.HeaderText = "Đến ngày";
            this.DenNgay.Name = "DenNgay";
            this.DenNgay.Width = 100;
            // 
            // MucLuong
            // 
            this.MucLuong.DataPropertyName = "MucLuong";
            this.MucLuong.HeaderText = "Mức lương";
            this.MucLuong.Name = "MucLuong";
            this.MucLuong.Width = 100;
            // 
            // PT_ThueTNCN
            // 
            this.PT_ThueTNCN.DataPropertyName = "PT_ThueTNCN";
            this.PT_ThueTNCN.HeaderText = "Thuế TNCN (%)";
            this.PT_ThueTNCN.Name = "PT_ThueTNCN";
            this.PT_ThueTNCN.Width = 110;
            // 
            // IsActive
            // 
            this.IsActive.DataPropertyName = "IsActive";
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle1.NullValue = false;
            this.IsActive.DefaultCellStyle = dataGridViewCellStyle1;
            this.IsActive.FalseValue = null;
            this.IsActive.HeaderText = "Hiệu lực";
            this.IsActive.IndeterminateValue = null;
            this.IsActive.Name = "IsActive";
            this.IsActive.TrueValue = null;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.ForeColor = System.Drawing.Color.Red;
            this.label1.Location = new System.Drawing.Point(1080, 270);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(20, 17);
            this.label1.TabIndex = 167;
            this.label1.Text = "%";
            // 
            // frm_wage
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.ClientSize = new System.Drawing.Size(1129, 554);
            this.ControlBox = false;
            this.Controls.Add(this.label1);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.txt_GhiChu);
            this.Controls.Add(this.labelX7);
            this.Controls.Add(this.dtp_DenNgay);
            this.Controls.Add(this.dtp_TuNgay);
            this.Controls.Add(this.labelX6);
            this.Controls.Add(this.labelX5);
            this.Controls.Add(this.txt_PhiThuNhapCaNhan);
            this.Controls.Add(this.labelX4);
            this.Controls.Add(this.chk_ThueTheoThuNhapCD);
            this.Controls.Add(this.chk_MienThue);
            this.Controls.Add(this.chk_PhiCD);
            this.Controls.Add(this.chk_BHTN);
            this.Controls.Add(this.chk_BHYT);
            this.Controls.Add(this.chk_BHXH);
            this.Controls.Add(this.chk_HieuLuc);
            this.Controls.Add(this.txt_MucLuong);
            this.Controls.Add(this.labelX3);
            this.Controls.Add(this.cbo_NhanVien);
            this.Controls.Add(this.labelX2);
            this.Controls.Add(this.panel3);
            this.Controls.Add(this.labelX1);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.KeyPreview = true;
            this.Margin = new System.Windows.Forms.Padding(4);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frm_wage";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Load += new System.EventHandler(this.frm_wage_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.frm_wage_KeyDown);
            this.panel3.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dtp_TuNgay)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtp_DenNgay)).EndInit();
            this.panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgv_Luong)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private DevComponents.DotNetBar.LabelX labelX1;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Button btn_clear;
        private System.Windows.Forms.Button btn_close;
        private System.Windows.Forms.Button btn_save;
        private DevComponents.DotNetBar.Controls.ComboBoxEx cbo_NhanVien;
        private DevComponents.DotNetBar.LabelX labelX2;
        private DevComponents.DotNetBar.LabelX labelX3;
        private DevComponents.DotNetBar.Controls.TextBoxX txt_MucLuong;
        private DevComponents.DotNetBar.Controls.CheckBoxX chk_HieuLuc;
        private DevComponents.DotNetBar.Controls.CheckBoxX chk_BHXH;
        private DevComponents.DotNetBar.Controls.CheckBoxX chk_BHYT;
        private DevComponents.DotNetBar.Controls.CheckBoxX chk_BHTN;
        private DevComponents.DotNetBar.Controls.CheckBoxX chk_PhiCD;
        private DevComponents.DotNetBar.Controls.CheckBoxX chk_ThueTheoThuNhapCD;
        private DevComponents.DotNetBar.Controls.CheckBoxX chk_MienThue;
        private DevComponents.DotNetBar.LabelX labelX4;
        private DevComponents.DotNetBar.Controls.TextBoxX txt_PhiThuNhapCaNhan;
        private DevComponents.DotNetBar.LabelX labelX5;
        private DevComponents.DotNetBar.LabelX labelX6;
        private DevComponents.Editors.DateTimeAdv.DateTimeInput dtp_TuNgay;
        private DevComponents.Editors.DateTimeAdv.DateTimeInput dtp_DenNgay;
        private DevComponents.DotNetBar.LabelX labelX7;
        private DevComponents.DotNetBar.Controls.TextBoxX txt_GhiChu;
        private System.Windows.Forms.Panel panel1;
        private DevComponents.DotNetBar.Controls.DataGridViewX dgv_Luong;
        private System.Windows.Forms.Label label1;
        private ComponentFactory.Krypton.Toolkit.KryptonDataGridViewTextBoxColumn ID;
        private System.Windows.Forms.DataGridViewImageColumn delete_column;
        private System.Windows.Forms.DataGridViewImageColumn edit_column;
        private ComponentFactory.Krypton.Toolkit.KryptonDataGridViewTextBoxColumn TuNgay;
        private ComponentFactory.Krypton.Toolkit.KryptonDataGridViewTextBoxColumn DenNgay;
        private ComponentFactory.Krypton.Toolkit.KryptonDataGridViewTextBoxColumn MucLuong;
        private ComponentFactory.Krypton.Toolkit.KryptonDataGridViewTextBoxColumn PT_ThueTNCN;
        private ComponentFactory.Krypton.Toolkit.KryptonDataGridViewCheckBoxColumn IsActive;
    }
}