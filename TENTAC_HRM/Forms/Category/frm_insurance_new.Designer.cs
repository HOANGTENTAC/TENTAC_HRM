namespace TENTAC_HRM.Forms.Category
{
    partial class frm_insurance_new
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
            this.chk_Active = new DevComponents.DotNetBar.Controls.CheckBoxX();
            this.txt_GhiChu = new DevComponents.DotNetBar.Controls.TextBoxX();
            this.labelX7 = new DevComponents.DotNetBar.LabelX();
            this.cbo_TinhThanh = new DevComponents.DotNetBar.Controls.ComboBoxEx();
            this.labelX6 = new DevComponents.DotNetBar.LabelX();
            this.txt_NoiDangKy = new DevComponents.DotNetBar.Controls.TextBoxX();
            this.labelX5 = new DevComponents.DotNetBar.LabelX();
            this.dtp_DenNgay = new DevComponents.Editors.DateTimeAdv.DateTimeInput();
            this.dtp_TuNgay = new DevComponents.Editors.DateTimeAdv.DateTimeInput();
            this.label4 = new DevComponents.DotNetBar.LabelX();
            this.label3 = new DevComponents.DotNetBar.LabelX();
            this.txt_SoThe = new DevComponents.DotNetBar.Controls.TextBoxX();
            this.labelX4 = new DevComponents.DotNetBar.LabelX();
            this.cbo_LoaiBaoHiem = new DevComponents.DotNetBar.Controls.ComboBoxEx();
            this.labelX3 = new DevComponents.DotNetBar.LabelX();
            this.cbo_NhanVien = new DevComponents.DotNetBar.Controls.ComboBoxEx();
            this.labelX2 = new DevComponents.DotNetBar.LabelX();
            this.panel2 = new System.Windows.Forms.Panel();
            this.dgv_BaoHiem = new DevComponents.DotNetBar.Controls.DataGridViewX();
            this.Id = new ComponentFactory.Krypton.Toolkit.KryptonDataGridViewTextBoxColumn();
            this.delete_column = new System.Windows.Forms.DataGridViewImageColumn();
            this.edit_column = new System.Windows.Forms.DataGridViewImageColumn();
            this.LoaiBaoHiem = new ComponentFactory.Krypton.Toolkit.KryptonDataGridViewTextBoxColumn();
            this.SoThe = new ComponentFactory.Krypton.Toolkit.KryptonDataGridViewTextBoxColumn();
            this.TuNgay = new ComponentFactory.Krypton.Toolkit.KryptonDataGridViewTextBoxColumn();
            this.DenNgay = new ComponentFactory.Krypton.Toolkit.KryptonDataGridViewTextBoxColumn();
            this.TinhThanh = new ComponentFactory.Krypton.Toolkit.KryptonDataGridViewTextBoxColumn();
            this.NoiThucHien = new ComponentFactory.Krypton.Toolkit.KryptonDataGridViewTextBoxColumn();
            this.IsActive = new ComponentFactory.Krypton.Toolkit.KryptonDataGridViewCheckBoxColumn();
            this.panel3 = new System.Windows.Forms.Panel();
            this.btn_clear = new System.Windows.Forms.Button();
            this.btn_close = new System.Windows.Forms.Button();
            this.btn_save = new System.Windows.Forms.Button();
            this.labelX1 = new DevComponents.DotNetBar.LabelX();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dtp_DenNgay)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtp_TuNgay)).BeginInit();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgv_BaoHiem)).BeginInit();
            this.panel3.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel1.Controls.Add(this.chk_Active);
            this.panel1.Controls.Add(this.txt_GhiChu);
            this.panel1.Controls.Add(this.labelX7);
            this.panel1.Controls.Add(this.cbo_TinhThanh);
            this.panel1.Controls.Add(this.labelX6);
            this.panel1.Controls.Add(this.txt_NoiDangKy);
            this.panel1.Controls.Add(this.labelX5);
            this.panel1.Controls.Add(this.dtp_DenNgay);
            this.panel1.Controls.Add(this.dtp_TuNgay);
            this.panel1.Controls.Add(this.label4);
            this.panel1.Controls.Add(this.label3);
            this.panel1.Controls.Add(this.txt_SoThe);
            this.panel1.Controls.Add(this.labelX4);
            this.panel1.Controls.Add(this.cbo_LoaiBaoHiem);
            this.panel1.Controls.Add(this.labelX3);
            this.panel1.Controls.Add(this.cbo_NhanVien);
            this.panel1.Controls.Add(this.labelX2);
            this.panel1.Controls.Add(this.panel2);
            this.panel1.Controls.Add(this.panel3);
            this.panel1.Controls.Add(this.labelX1);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1168, 608);
            this.panel1.TabIndex = 0;
            // 
            // chk_Active
            // 
            this.chk_Active.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chk_Active.Location = new System.Drawing.Point(1068, 192);
            this.chk_Active.Name = "chk_Active";
            this.chk_Active.Size = new System.Drawing.Size(72, 23);
            this.chk_Active.TabIndex = 165;
            this.chk_Active.Text = "Hiệu lực";
            // 
            // txt_GhiChu
            // 
            // 
            // 
            // 
            this.txt_GhiChu.Border.Class = "TextBoxBorder";
            this.txt_GhiChu.Location = new System.Drawing.Point(837, 437);
            this.txt_GhiChu.Multiline = true;
            this.txt_GhiChu.Name = "txt_GhiChu";
            this.txt_GhiChu.Size = new System.Drawing.Size(303, 83);
            this.txt_GhiChu.TabIndex = 8;
            // 
            // labelX7
            // 
            this.labelX7.AutoSize = true;
            this.labelX7.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelX7.Location = new System.Drawing.Point(837, 412);
            this.labelX7.Name = "labelX7";
            this.labelX7.Size = new System.Drawing.Size(56, 19);
            this.labelX7.TabIndex = 178;
            this.labelX7.Text = "Ghi Chú";
            // 
            // cbo_TinhThanh
            // 
            this.cbo_TinhThanh.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.cbo_TinhThanh.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbo_TinhThanh.FormattingEnabled = true;
            this.cbo_TinhThanh.ItemHeight = 16;
            this.cbo_TinhThanh.Location = new System.Drawing.Point(837, 384);
            this.cbo_TinhThanh.Name = "cbo_TinhThanh";
            this.cbo_TinhThanh.Size = new System.Drawing.Size(303, 22);
            this.cbo_TinhThanh.TabIndex = 7;
            // 
            // labelX6
            // 
            this.labelX6.AutoSize = true;
            this.labelX6.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelX6.Location = new System.Drawing.Point(839, 359);
            this.labelX6.Name = "labelX6";
            this.labelX6.Size = new System.Drawing.Size(82, 19);
            this.labelX6.TabIndex = 177;
            this.labelX6.Text = "Tỉnh / Thành";
            // 
            // txt_NoiDangKy
            // 
            // 
            // 
            // 
            this.txt_NoiDangKy.Border.Class = "TextBoxBorder";
            this.txt_NoiDangKy.Location = new System.Drawing.Point(837, 294);
            this.txt_NoiDangKy.Multiline = true;
            this.txt_NoiDangKy.Name = "txt_NoiDangKy";
            this.txt_NoiDangKy.Size = new System.Drawing.Size(303, 58);
            this.txt_NoiDangKy.TabIndex = 6;
            // 
            // labelX5
            // 
            this.labelX5.AutoSize = true;
            this.labelX5.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelX5.Location = new System.Drawing.Point(837, 271);
            this.labelX5.Name = "labelX5";
            this.labelX5.Size = new System.Drawing.Size(77, 19);
            this.labelX5.TabIndex = 176;
            this.labelX5.Text = "Nơi đăng ký";
            // 
            // dtp_DenNgay
            // 
            // 
            // 
            // 
            this.dtp_DenNgay.BackgroundStyle.Class = "DateTimeInputBackground";
            this.dtp_DenNgay.ButtonDropDown.Visible = true;
            this.dtp_DenNgay.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dtp_DenNgay.Location = new System.Drawing.Point(1005, 242);
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
            this.dtp_DenNgay.Size = new System.Drawing.Size(135, 22);
            this.dtp_DenNgay.TabIndex = 5;
            // 
            // dtp_TuNgay
            // 
            // 
            // 
            // 
            this.dtp_TuNgay.BackgroundStyle.Class = "DateTimeInputBackground";
            this.dtp_TuNgay.ButtonDropDown.Visible = true;
            this.dtp_TuNgay.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dtp_TuNgay.Location = new System.Drawing.Point(837, 243);
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
            this.dtp_TuNgay.Size = new System.Drawing.Size(135, 22);
            this.dtp_TuNgay.TabIndex = 4;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(1005, 220);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(55, 16);
            this.label4.TabIndex = 174;
            this.label4.Text = "Đến ngày";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(837, 220);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(47, 16);
            this.label3.TabIndex = 175;
            this.label3.Text = "Từ ngày";
            // 
            // txt_SoThe
            // 
            // 
            // 
            // 
            this.txt_SoThe.Border.Class = "TextBoxBorder";
            this.txt_SoThe.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txt_SoThe.Location = new System.Drawing.Point(837, 192);
            this.txt_SoThe.Name = "txt_SoThe";
            this.txt_SoThe.Size = new System.Drawing.Size(225, 22);
            this.txt_SoThe.TabIndex = 3;
            // 
            // labelX4
            // 
            this.labelX4.AutoSize = true;
            this.labelX4.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelX4.Location = new System.Drawing.Point(837, 166);
            this.labelX4.Name = "labelX4";
            this.labelX4.Size = new System.Drawing.Size(45, 19);
            this.labelX4.TabIndex = 173;
            this.labelX4.Text = "Số thẻ";
            // 
            // cbo_LoaiBaoHiem
            // 
            this.cbo_LoaiBaoHiem.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.cbo_LoaiBaoHiem.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbo_LoaiBaoHiem.FormattingEnabled = true;
            this.cbo_LoaiBaoHiem.ItemHeight = 16;
            this.cbo_LoaiBaoHiem.Location = new System.Drawing.Point(837, 138);
            this.cbo_LoaiBaoHiem.Name = "cbo_LoaiBaoHiem";
            this.cbo_LoaiBaoHiem.Size = new System.Drawing.Size(303, 22);
            this.cbo_LoaiBaoHiem.TabIndex = 2;
            // 
            // labelX3
            // 
            this.labelX3.AutoSize = true;
            this.labelX3.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelX3.Location = new System.Drawing.Point(837, 113);
            this.labelX3.Name = "labelX3";
            this.labelX3.Size = new System.Drawing.Size(91, 19);
            this.labelX3.TabIndex = 172;
            this.labelX3.Text = "Loại bảo hiểm";
            // 
            // cbo_NhanVien
            // 
            this.cbo_NhanVien.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.cbo_NhanVien.Enabled = false;
            this.cbo_NhanVien.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbo_NhanVien.FormattingEnabled = true;
            this.cbo_NhanVien.ItemHeight = 16;
            this.cbo_NhanVien.Location = new System.Drawing.Point(837, 85);
            this.cbo_NhanVien.Name = "cbo_NhanVien";
            this.cbo_NhanVien.Size = new System.Drawing.Size(303, 22);
            this.cbo_NhanVien.TabIndex = 1;
            // 
            // labelX2
            // 
            this.labelX2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelX2.Location = new System.Drawing.Point(837, 60);
            this.labelX2.Name = "labelX2";
            this.labelX2.Size = new System.Drawing.Size(75, 23);
            this.labelX2.TabIndex = 171;
            this.labelX2.Text = "Nhân viên";
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.dgv_BaoHiem);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Left;
            this.panel2.Location = new System.Drawing.Point(0, 54);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(814, 497);
            this.panel2.TabIndex = 161;
            // 
            // dgv_BaoHiem
            // 
            this.dgv_BaoHiem.AllowUserToAddRows = false;
            this.dgv_BaoHiem.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgv_BaoHiem.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Id,
            this.delete_column,
            this.edit_column,
            this.LoaiBaoHiem,
            this.SoThe,
            this.TuNgay,
            this.DenNgay,
            this.TinhThanh,
            this.NoiThucHien,
            this.IsActive});
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgv_BaoHiem.DefaultCellStyle = dataGridViewCellStyle2;
            this.dgv_BaoHiem.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgv_BaoHiem.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(215)))), ((int)(((byte)(229)))));
            this.dgv_BaoHiem.Location = new System.Drawing.Point(0, 0);
            this.dgv_BaoHiem.Name = "dgv_BaoHiem";
            this.dgv_BaoHiem.Size = new System.Drawing.Size(814, 497);
            this.dgv_BaoHiem.TabIndex = 0;
            this.dgv_BaoHiem.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgv_BaoHiem_CellClick);
            // 
            // Id
            // 
            this.Id.DataPropertyName = "Id";
            this.Id.HeaderText = "Id";
            this.Id.Name = "Id";
            this.Id.Visible = false;
            this.Id.Width = 100;
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
            // LoaiBaoHiem
            // 
            this.LoaiBaoHiem.DataPropertyName = "LoaiBaoHiem";
            this.LoaiBaoHiem.HeaderText = "Loại bảo hiểm";
            this.LoaiBaoHiem.Name = "LoaiBaoHiem";
            this.LoaiBaoHiem.Width = 100;
            // 
            // SoThe
            // 
            this.SoThe.DataPropertyName = "SoThe";
            this.SoThe.HeaderText = "Số thẻ";
            this.SoThe.Name = "SoThe";
            this.SoThe.Width = 100;
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
            // TinhThanh
            // 
            this.TinhThanh.DataPropertyName = "TinhThanh";
            this.TinhThanh.HeaderText = "Tỉnh/Thành";
            this.TinhThanh.Name = "TinhThanh";
            this.TinhThanh.Width = 100;
            // 
            // NoiThucHien
            // 
            this.NoiThucHien.DataPropertyName = "NoiThucHien";
            this.NoiThucHien.HeaderText = "Nơi đăng ký";
            this.NoiThucHien.Name = "NoiThucHien";
            this.NoiThucHien.Width = 100;
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
            this.IsActive.Width = 70;
            // 
            // panel3
            // 
            this.panel3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(16)))), ((int)(((byte)(39)))), ((int)(((byte)(75)))));
            this.panel3.Controls.Add(this.btn_clear);
            this.panel3.Controls.Add(this.btn_close);
            this.panel3.Controls.Add(this.btn_save);
            this.panel3.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel3.Location = new System.Drawing.Point(0, 551);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(1166, 55);
            this.panel3.TabIndex = 160;
            // 
            // btn_clear
            // 
            this.btn_clear.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_clear.Image = global::TENTAC_HRM.Properties.Resources.ClearContent;
            this.btn_clear.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btn_clear.Location = new System.Drawing.Point(944, 17);
            this.btn_clear.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btn_clear.Name = "btn_clear";
            this.btn_clear.Size = new System.Drawing.Size(90, 27);
            this.btn_clear.TabIndex = 10;
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
            this.btn_close.Location = new System.Drawing.Point(1050, 17);
            this.btn_close.Name = "btn_close";
            this.btn_close.Size = new System.Drawing.Size(90, 27);
            this.btn_close.TabIndex = 11;
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
            this.btn_save.Location = new System.Drawing.Point(837, 17);
            this.btn_save.Name = "btn_save";
            this.btn_save.Size = new System.Drawing.Size(90, 27);
            this.btn_save.TabIndex = 9;
            this.btn_save.Text = "Lưu";
            this.btn_save.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btn_save.UseVisualStyleBackColor = true;
            this.btn_save.Click += new System.EventHandler(this.btn_luu_Click);
            // 
            // labelX1
            // 
            this.labelX1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(16)))), ((int)(((byte)(39)))), ((int)(((byte)(75)))));
            this.labelX1.Dock = System.Windows.Forms.DockStyle.Top;
            this.labelX1.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelX1.ForeColor = System.Drawing.Color.WhiteSmoke;
            this.labelX1.Location = new System.Drawing.Point(0, 0);
            this.labelX1.Name = "labelX1";
            this.labelX1.Size = new System.Drawing.Size(1166, 54);
            this.labelX1.TabIndex = 159;
            this.labelX1.Text = "Nhân viên - Bảo hiểm";
            this.labelX1.TextAlignment = System.Drawing.StringAlignment.Center;
            // 
            // frm_insurance_new
            // 
            this.AcceptButton = this.btn_save;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.btn_close;
            this.ClientSize = new System.Drawing.Size(1168, 608);
            this.Controls.Add(this.panel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frm_insurance_new";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Load += new System.EventHandler(this.frm_insurance_new_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dtp_DenNgay)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtp_TuNgay)).EndInit();
            this.panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgv_BaoHiem)).EndInit();
            this.panel3.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private DevComponents.DotNetBar.Controls.CheckBoxX chk_Active;
        private DevComponents.DotNetBar.Controls.TextBoxX txt_GhiChu;
        private DevComponents.DotNetBar.LabelX labelX7;
        private DevComponents.DotNetBar.Controls.ComboBoxEx cbo_TinhThanh;
        private DevComponents.DotNetBar.LabelX labelX6;
        private DevComponents.DotNetBar.Controls.TextBoxX txt_NoiDangKy;
        private DevComponents.DotNetBar.LabelX labelX5;
        private DevComponents.Editors.DateTimeAdv.DateTimeInput dtp_DenNgay;
        private DevComponents.Editors.DateTimeAdv.DateTimeInput dtp_TuNgay;
        private DevComponents.DotNetBar.LabelX label4;
        private DevComponents.DotNetBar.LabelX label3;
        private DevComponents.DotNetBar.Controls.TextBoxX txt_SoThe;
        private DevComponents.DotNetBar.LabelX labelX4;
        private DevComponents.DotNetBar.Controls.ComboBoxEx cbo_LoaiBaoHiem;
        private DevComponents.DotNetBar.LabelX labelX3;
        private DevComponents.DotNetBar.Controls.ComboBoxEx cbo_NhanVien;
        private DevComponents.DotNetBar.LabelX labelX2;
        private System.Windows.Forms.Panel panel2;
        private DevComponents.DotNetBar.Controls.DataGridViewX dgv_BaoHiem;
        private ComponentFactory.Krypton.Toolkit.KryptonDataGridViewTextBoxColumn Id;
        private System.Windows.Forms.DataGridViewImageColumn delete_column;
        private System.Windows.Forms.DataGridViewImageColumn edit_column;
        private ComponentFactory.Krypton.Toolkit.KryptonDataGridViewTextBoxColumn LoaiBaoHiem;
        private ComponentFactory.Krypton.Toolkit.KryptonDataGridViewTextBoxColumn SoThe;
        private ComponentFactory.Krypton.Toolkit.KryptonDataGridViewTextBoxColumn TuNgay;
        private ComponentFactory.Krypton.Toolkit.KryptonDataGridViewTextBoxColumn DenNgay;
        private ComponentFactory.Krypton.Toolkit.KryptonDataGridViewTextBoxColumn TinhThanh;
        private ComponentFactory.Krypton.Toolkit.KryptonDataGridViewTextBoxColumn NoiThucHien;
        private ComponentFactory.Krypton.Toolkit.KryptonDataGridViewCheckBoxColumn IsActive;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Button btn_close;
        private System.Windows.Forms.Button btn_save;
        private DevComponents.DotNetBar.LabelX labelX1;
        private System.Windows.Forms.Button btn_clear;
    }
}