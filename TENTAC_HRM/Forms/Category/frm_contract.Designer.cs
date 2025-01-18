namespace TENTAC_HRM.Forms.Category
{
    partial class frm_contract
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
            this.panel1 = new System.Windows.Forms.Panel();
            this.panel2 = new System.Windows.Forms.Panel();
            this.dgv_HopDong = new DevComponents.DotNetBar.Controls.DataGridViewX();
            this.edit_column = new System.Windows.Forms.DataGridViewImageColumn();
            this.delete_column = new System.Windows.Forms.DataGridViewImageColumn();
            this.LoaiHopDong = new ComponentFactory.Krypton.Toolkit.KryptonDataGridViewTextBoxColumn();
            this.Id = new ComponentFactory.Krypton.Toolkit.KryptonDataGridViewTextBoxColumn();
            this.SoHopDong = new ComponentFactory.Krypton.Toolkit.KryptonDataGridViewTextBoxColumn();
            this.NgayKy = new ComponentFactory.Krypton.Toolkit.KryptonDataGridViewTextBoxColumn();
            this.TuNgay = new ComponentFactory.Krypton.Toolkit.KryptonDataGridViewTextBoxColumn();
            this.DenNgay = new ComponentFactory.Krypton.Toolkit.KryptonDataGridViewTextBoxColumn();
            this.IsActive = new ComponentFactory.Krypton.Toolkit.KryptonDataGridViewCheckBoxColumn();
            this.panel3 = new System.Windows.Forms.Panel();
            this.btn_clear = new System.Windows.Forms.Button();
            this.btn_close = new System.Windows.Forms.Button();
            this.btn_save = new System.Windows.Forms.Button();
            this.txt_GhiChu = new DevComponents.DotNetBar.Controls.TextBoxX();
            this.chk_Active = new DevComponents.DotNetBar.Controls.CheckBoxX();
            this.labelX8 = new DevComponents.DotNetBar.LabelX();
            this.dtp_NgayKy = new DevComponents.Editors.DateTimeAdv.DateTimeInput();
            this.labelX7 = new DevComponents.DotNetBar.LabelX();
            this.dtp_DenNgay = new DevComponents.Editors.DateTimeAdv.DateTimeInput();
            this.labelX6 = new DevComponents.DotNetBar.LabelX();
            this.dtp_TuNgay = new DevComponents.Editors.DateTimeAdv.DateTimeInput();
            this.labelX5 = new DevComponents.DotNetBar.LabelX();
            this.txt_SoHopDong = new DevComponents.DotNetBar.Controls.TextBoxX();
            this.labelX4 = new DevComponents.DotNetBar.LabelX();
            this.cbo_LoaiHopDong = new DevComponents.DotNetBar.Controls.ComboBoxEx();
            this.labelX3 = new DevComponents.DotNetBar.LabelX();
            this.cbo_NhanVien = new DevComponents.DotNetBar.Controls.ComboBoxEx();
            this.labelX2 = new DevComponents.DotNetBar.LabelX();
            this.labelX1 = new DevComponents.DotNetBar.LabelX();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgv_HopDong)).BeginInit();
            this.panel3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dtp_NgayKy)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtp_DenNgay)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtp_TuNgay)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.panel2);
            this.panel1.Controls.Add(this.panel3);
            this.panel1.Controls.Add(this.txt_GhiChu);
            this.panel1.Controls.Add(this.chk_Active);
            this.panel1.Controls.Add(this.labelX8);
            this.panel1.Controls.Add(this.dtp_NgayKy);
            this.panel1.Controls.Add(this.labelX7);
            this.panel1.Controls.Add(this.dtp_DenNgay);
            this.panel1.Controls.Add(this.labelX6);
            this.panel1.Controls.Add(this.dtp_TuNgay);
            this.panel1.Controls.Add(this.labelX5);
            this.panel1.Controls.Add(this.txt_SoHopDong);
            this.panel1.Controls.Add(this.labelX4);
            this.panel1.Controls.Add(this.cbo_LoaiHopDong);
            this.panel1.Controls.Add(this.labelX3);
            this.panel1.Controls.Add(this.cbo_NhanVien);
            this.panel1.Controls.Add(this.labelX2);
            this.panel1.Controls.Add(this.labelX1);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1168, 544);
            this.panel1.TabIndex = 0;
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.dgv_HopDong);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Left;
            this.panel2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.panel2.Location = new System.Drawing.Point(0, 54);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(818, 435);
            this.panel2.TabIndex = 86;
            // 
            // dgv_HopDong
            // 
            this.dgv_HopDong.AllowUserToAddRows = false;
            this.dgv_HopDong.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgv_HopDong.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.edit_column,
            this.delete_column,
            this.LoaiHopDong,
            this.Id,
            this.SoHopDong,
            this.NgayKy,
            this.TuNgay,
            this.DenNgay,
            this.IsActive});
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgv_HopDong.DefaultCellStyle = dataGridViewCellStyle2;
            this.dgv_HopDong.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgv_HopDong.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(215)))), ((int)(((byte)(229)))));
            this.dgv_HopDong.Location = new System.Drawing.Point(0, 0);
            this.dgv_HopDong.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.dgv_HopDong.Name = "dgv_HopDong";
            this.dgv_HopDong.Size = new System.Drawing.Size(818, 435);
            this.dgv_HopDong.TabIndex = 69;
            this.dgv_HopDong.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgv_HopDong_CellClick);
            // 
            // edit_column
            // 
            this.edit_column.HeaderText = "";
            this.edit_column.Image = global::TENTAC_HRM.Properties.Resources.pen;
            this.edit_column.Name = "edit_column";
            this.edit_column.Width = 50;
            // 
            // delete_column
            // 
            this.delete_column.HeaderText = "";
            this.delete_column.Image = global::TENTAC_HRM.Properties.Resources.bin;
            this.delete_column.Name = "delete_column";
            this.delete_column.Width = 50;
            // 
            // LoaiHopDong
            // 
            this.LoaiHopDong.DataPropertyName = "LoaiHopDong";
            this.LoaiHopDong.HeaderText = "Loại hợp đồng";
            this.LoaiHopDong.Name = "LoaiHopDong";
            this.LoaiHopDong.Width = 150;
            // 
            // Id
            // 
            this.Id.DataPropertyName = "Id";
            this.Id.HeaderText = "Id";
            this.Id.Name = "Id";
            this.Id.Visible = false;
            this.Id.Width = 100;
            // 
            // SoHopDong
            // 
            this.SoHopDong.DataPropertyName = "SoHopDong";
            this.SoHopDong.HeaderText = "Số hợp đồng";
            this.SoHopDong.Name = "SoHopDong";
            this.SoHopDong.Width = 150;
            // 
            // NgayKy
            // 
            this.NgayKy.DataPropertyName = "NgayKy";
            this.NgayKy.HeaderText = "Ngày ký";
            this.NgayKy.Name = "NgayKy";
            this.NgayKy.Width = 100;
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
            this.IsActive.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.IsActive.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            this.IsActive.TrueValue = null;
            this.IsActive.Width = 70;
            // 
            // panel3
            // 
            this.panel3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(16)))), ((int)(((byte)(39)))), ((int)(((byte)(75)))));
            this.panel3.Controls.Add(this.btn_clear);
            this.panel3.Controls.Add(this.btn_close);
            this.panel3.Controls.Add(this.btn_save);
            this.panel3.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel3.Location = new System.Drawing.Point(0, 489);
            this.panel3.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(1168, 55);
            this.panel3.TabIndex = 85;
            this.panel3.Click += new System.EventHandler(this.btn_close_Click);
            // 
            // btn_clear
            // 
            this.btn_clear.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_clear.Image = global::TENTAC_HRM.Properties.Resources.ClearContent;
            this.btn_clear.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btn_clear.Location = new System.Drawing.Point(942, 18);
            this.btn_clear.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btn_clear.Name = "btn_clear";
            this.btn_clear.Size = new System.Drawing.Size(90, 27);
            this.btn_clear.TabIndex = 21;
            this.btn_clear.Text = "Đặt lại";
            this.btn_clear.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btn_clear.UseVisualStyleBackColor = true;
            this.btn_clear.Click += new System.EventHandler(this.btn_clear_Click);
            // 
            // btn_close
            // 
            this.btn_close.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btn_close.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_close.Image = global::TENTAC_HRM.Properties.Resources.cancel;
            this.btn_close.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btn_close.Location = new System.Drawing.Point(1047, 18);
            this.btn_close.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btn_close.Name = "btn_close";
            this.btn_close.Size = new System.Drawing.Size(90, 27);
            this.btn_close.TabIndex = 20;
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
            this.btn_save.Location = new System.Drawing.Point(836, 18);
            this.btn_save.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btn_save.Name = "btn_save";
            this.btn_save.Size = new System.Drawing.Size(90, 27);
            this.btn_save.TabIndex = 19;
            this.btn_save.Text = "Lưu";
            this.btn_save.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btn_save.UseVisualStyleBackColor = true;
            this.btn_save.Click += new System.EventHandler(this.btn_save_Click);
            // 
            // txt_GhiChu
            // 
            // 
            // 
            // 
            this.txt_GhiChu.Border.Class = "TextBoxBorder";
            this.txt_GhiChu.Location = new System.Drawing.Point(837, 364);
            this.txt_GhiChu.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.txt_GhiChu.Multiline = true;
            this.txt_GhiChu.Name = "txt_GhiChu";
            this.txt_GhiChu.Size = new System.Drawing.Size(300, 103);
            this.txt_GhiChu.TabIndex = 84;
            // 
            // chk_Active
            // 
            this.chk_Active.Location = new System.Drawing.Point(1000, 310);
            this.chk_Active.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.chk_Active.Name = "chk_Active";
            this.chk_Active.Size = new System.Drawing.Size(137, 23);
            this.chk_Active.TabIndex = 83;
            this.chk_Active.Text = "Hiệu lực hợp đồng";
            // 
            // labelX8
            // 
            this.labelX8.AutoSize = true;
            this.labelX8.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelX8.Location = new System.Drawing.Point(836, 338);
            this.labelX8.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.labelX8.Name = "labelX8";
            this.labelX8.Size = new System.Drawing.Size(56, 19);
            this.labelX8.TabIndex = 82;
            this.labelX8.Text = "Ghi Chú";
            // 
            // dtp_NgayKy
            // 
            // 
            // 
            // 
            this.dtp_NgayKy.BackgroundStyle.Class = "DateTimeInputBackground";
            this.dtp_NgayKy.ButtonDropDown.Visible = true;
            this.dtp_NgayKy.Location = new System.Drawing.Point(837, 310);
            this.dtp_NgayKy.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            // 
            // 
            // 
            this.dtp_NgayKy.MonthCalendar.AnnuallyMarkedDates = new System.DateTime[0];
            // 
            // 
            // 
            this.dtp_NgayKy.MonthCalendar.BackgroundStyle.BackColor = System.Drawing.SystemColors.Window;
            this.dtp_NgayKy.MonthCalendar.ClearButtonVisible = true;
            // 
            // 
            // 
            this.dtp_NgayKy.MonthCalendar.CommandsBackgroundStyle.BackColor2SchemePart = DevComponents.DotNetBar.eColorSchemePart.BarBackground2;
            this.dtp_NgayKy.MonthCalendar.CommandsBackgroundStyle.BackColorGradientAngle = 90;
            this.dtp_NgayKy.MonthCalendar.CommandsBackgroundStyle.BackColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.BarBackground;
            this.dtp_NgayKy.MonthCalendar.CommandsBackgroundStyle.BorderTop = DevComponents.DotNetBar.eStyleBorderType.Solid;
            this.dtp_NgayKy.MonthCalendar.CommandsBackgroundStyle.BorderTopColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.BarDockedBorder;
            this.dtp_NgayKy.MonthCalendar.CommandsBackgroundStyle.BorderTopWidth = 1;
            this.dtp_NgayKy.MonthCalendar.DisplayMonth = new System.DateTime(2024, 10, 1, 0, 0, 0, 0);
            this.dtp_NgayKy.MonthCalendar.MarkedDates = new System.DateTime[0];
            this.dtp_NgayKy.MonthCalendar.MonthlyMarkedDates = new System.DateTime[0];
            // 
            // 
            // 
            this.dtp_NgayKy.MonthCalendar.NavigationBackgroundStyle.BackColor2SchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground2;
            this.dtp_NgayKy.MonthCalendar.NavigationBackgroundStyle.BackColorGradientAngle = 90;
            this.dtp_NgayKy.MonthCalendar.NavigationBackgroundStyle.BackColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground;
            this.dtp_NgayKy.MonthCalendar.TodayButtonVisible = true;
            this.dtp_NgayKy.Name = "dtp_NgayKy";
            this.dtp_NgayKy.Size = new System.Drawing.Size(137, 23);
            this.dtp_NgayKy.TabIndex = 81;
            // 
            // labelX7
            // 
            this.labelX7.AutoSize = true;
            this.labelX7.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelX7.Location = new System.Drawing.Point(837, 286);
            this.labelX7.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.labelX7.Name = "labelX7";
            this.labelX7.Size = new System.Drawing.Size(114, 19);
            this.labelX7.TabIndex = 80;
            this.labelX7.Text = "Ngày ký hợp dồng";
            // 
            // dtp_DenNgay
            // 
            // 
            // 
            // 
            this.dtp_DenNgay.BackgroundStyle.Class = "DateTimeInputBackground";
            this.dtp_DenNgay.ButtonDropDown.Visible = true;
            this.dtp_DenNgay.Location = new System.Drawing.Point(1000, 256);
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
            this.dtp_DenNgay.MonthCalendar.DisplayMonth = new System.DateTime(2024, 10, 1, 0, 0, 0, 0);
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
            this.dtp_DenNgay.Size = new System.Drawing.Size(137, 23);
            this.dtp_DenNgay.TabIndex = 79;
            // 
            // labelX6
            // 
            this.labelX6.AutoSize = true;
            this.labelX6.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelX6.Location = new System.Drawing.Point(1000, 230);
            this.labelX6.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.labelX6.Name = "labelX6";
            this.labelX6.Size = new System.Drawing.Size(64, 19);
            this.labelX6.TabIndex = 78;
            this.labelX6.Text = "Đến ngày";
            // 
            // dtp_TuNgay
            // 
            // 
            // 
            // 
            this.dtp_TuNgay.BackgroundStyle.Class = "DateTimeInputBackground";
            this.dtp_TuNgay.ButtonDropDown.Visible = true;
            this.dtp_TuNgay.Location = new System.Drawing.Point(837, 256);
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
            this.dtp_TuNgay.MonthCalendar.DisplayMonth = new System.DateTime(2024, 10, 1, 0, 0, 0, 0);
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
            this.dtp_TuNgay.Size = new System.Drawing.Size(137, 23);
            this.dtp_TuNgay.TabIndex = 77;
            // 
            // labelX5
            // 
            this.labelX5.AutoSize = true;
            this.labelX5.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelX5.Location = new System.Drawing.Point(837, 230);
            this.labelX5.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.labelX5.Name = "labelX5";
            this.labelX5.Size = new System.Drawing.Size(55, 19);
            this.labelX5.TabIndex = 76;
            this.labelX5.Text = "Từ ngày";
            // 
            // txt_SoHopDong
            // 
            // 
            // 
            // 
            this.txt_SoHopDong.Border.Class = "TextBoxBorder";
            this.txt_SoHopDong.Location = new System.Drawing.Point(837, 201);
            this.txt_SoHopDong.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.txt_SoHopDong.Name = "txt_SoHopDong";
            this.txt_SoHopDong.Size = new System.Drawing.Size(300, 23);
            this.txt_SoHopDong.TabIndex = 75;
            // 
            // labelX4
            // 
            this.labelX4.AutoSize = true;
            this.labelX4.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelX4.Location = new System.Drawing.Point(837, 175);
            this.labelX4.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.labelX4.Name = "labelX4";
            this.labelX4.Size = new System.Drawing.Size(82, 19);
            this.labelX4.TabIndex = 74;
            this.labelX4.Text = "Số hợp đồng";
            // 
            // cbo_LoaiHopDong
            // 
            this.cbo_LoaiHopDong.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.cbo_LoaiHopDong.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbo_LoaiHopDong.FormattingEnabled = true;
            this.cbo_LoaiHopDong.ItemHeight = 16;
            this.cbo_LoaiHopDong.Location = new System.Drawing.Point(837, 146);
            this.cbo_LoaiHopDong.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.cbo_LoaiHopDong.Name = "cbo_LoaiHopDong";
            this.cbo_LoaiHopDong.Size = new System.Drawing.Size(300, 22);
            this.cbo_LoaiHopDong.TabIndex = 73;
            // 
            // labelX3
            // 
            this.labelX3.AutoSize = true;
            this.labelX3.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelX3.Location = new System.Drawing.Point(837, 122);
            this.labelX3.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.labelX3.Name = "labelX3";
            this.labelX3.Size = new System.Drawing.Size(91, 19);
            this.labelX3.TabIndex = 72;
            this.labelX3.Text = "Loại hợp đồng";
            // 
            // cbo_NhanVien
            // 
            this.cbo_NhanVien.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.cbo_NhanVien.Enabled = false;
            this.cbo_NhanVien.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbo_NhanVien.FormattingEnabled = true;
            this.cbo_NhanVien.ItemHeight = 16;
            this.cbo_NhanVien.Location = new System.Drawing.Point(837, 94);
            this.cbo_NhanVien.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.cbo_NhanVien.Name = "cbo_NhanVien";
            this.cbo_NhanVien.Size = new System.Drawing.Size(300, 22);
            this.cbo_NhanVien.TabIndex = 71;
            // 
            // labelX2
            // 
            this.labelX2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelX2.Location = new System.Drawing.Point(837, 69);
            this.labelX2.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.labelX2.Name = "labelX2";
            this.labelX2.Size = new System.Drawing.Size(75, 23);
            this.labelX2.TabIndex = 70;
            this.labelX2.Text = "Nhân viên";
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
            this.labelX1.Size = new System.Drawing.Size(1168, 54);
            this.labelX1.TabIndex = 69;
            this.labelX1.Text = "Nhân viên - Hợp đồng";
            this.labelX1.TextAlignment = System.Drawing.StringAlignment.Center;
            // 
            // frm_contract
            // 
            this.AcceptButton = this.btn_save;
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.CancelButton = this.btn_close;
            this.ClientSize = new System.Drawing.Size(1168, 544);
            this.ControlBox = false;
            this.Controls.Add(this.panel1);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.KeyPreview = true;
            this.Margin = new System.Windows.Forms.Padding(4);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frm_contract";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Load += new System.EventHandler(this.frm_contract_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.frm_contract_KeyDown);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgv_HopDong)).EndInit();
            this.panel3.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dtp_NgayKy)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtp_DenNgay)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtp_TuNgay)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel2;
        private DevComponents.DotNetBar.Controls.DataGridViewX dgv_HopDong;
        private System.Windows.Forms.DataGridViewImageColumn edit_column;
        private System.Windows.Forms.DataGridViewImageColumn delete_column;
        private ComponentFactory.Krypton.Toolkit.KryptonDataGridViewTextBoxColumn LoaiHopDong;
        private ComponentFactory.Krypton.Toolkit.KryptonDataGridViewTextBoxColumn Id;
        private ComponentFactory.Krypton.Toolkit.KryptonDataGridViewTextBoxColumn SoHopDong;
        private ComponentFactory.Krypton.Toolkit.KryptonDataGridViewTextBoxColumn NgayKy;
        private ComponentFactory.Krypton.Toolkit.KryptonDataGridViewTextBoxColumn TuNgay;
        private ComponentFactory.Krypton.Toolkit.KryptonDataGridViewTextBoxColumn DenNgay;
        private ComponentFactory.Krypton.Toolkit.KryptonDataGridViewCheckBoxColumn IsActive;
        private System.Windows.Forms.Panel panel3;
        private DevComponents.DotNetBar.Controls.TextBoxX txt_GhiChu;
        private DevComponents.DotNetBar.Controls.CheckBoxX chk_Active;
        private DevComponents.DotNetBar.LabelX labelX8;
        private DevComponents.Editors.DateTimeAdv.DateTimeInput dtp_NgayKy;
        private DevComponents.DotNetBar.LabelX labelX7;
        private DevComponents.Editors.DateTimeAdv.DateTimeInput dtp_DenNgay;
        private DevComponents.DotNetBar.LabelX labelX6;
        private DevComponents.Editors.DateTimeAdv.DateTimeInput dtp_TuNgay;
        private DevComponents.DotNetBar.LabelX labelX5;
        private DevComponents.DotNetBar.Controls.TextBoxX txt_SoHopDong;
        private DevComponents.DotNetBar.LabelX labelX4;
        private DevComponents.DotNetBar.Controls.ComboBoxEx cbo_LoaiHopDong;
        private DevComponents.DotNetBar.LabelX labelX3;
        private DevComponents.DotNetBar.Controls.ComboBoxEx cbo_NhanVien;
        private DevComponents.DotNetBar.LabelX labelX2;
        private DevComponents.DotNetBar.LabelX labelX1;
        private System.Windows.Forms.Button btn_clear;
        private System.Windows.Forms.Button btn_close;
        private System.Windows.Forms.Button btn_save;
    }
}