namespace TENTAC_HRM.Forms.ChamCong
{
    partial class frm_NuoiConNho
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frm_NuoiConNho));
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            this.dtp_TuNgaySearch = new DevComponents.Editors.DateTimeAdv.DateTimeInput();
            this.DenNgay = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.PhongBan = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.MaChamCong = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.panel3 = new System.Windows.Forms.Panel();
            this.chk_new = new System.Windows.Forms.CheckBox();
            this.btn_Delete = new DevComponents.DotNetBar.ButtonX();
            this.btn_ImportExcel = new DevComponents.DotNetBar.ButtonX();
            this.btn_Add = new DevComponents.DotNetBar.ButtonX();
            this.labelX4 = new DevComponents.DotNetBar.LabelX();
            this.labelX3 = new DevComponents.DotNetBar.LabelX();
            this.dtp_DenNgay = new DevComponents.Editors.DateTimeAdv.DateTimeInput();
            this.dtp_TuNgay = new DevComponents.Editors.DateTimeAdv.DateTimeInput();
            this.TuNgay = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.panel2 = new System.Windows.Forms.Panel();
            this.btn_Search = new DevComponents.DotNetBar.ButtonX();
            this.dtp_DenNgaySearch = new DevComponents.Editors.DateTimeAdv.DateTimeInput();
            this.labelX2 = new DevComponents.DotNetBar.LabelX();
            this.labelX1 = new DevComponents.DotNetBar.LabelX();
            this.TenNhanVien = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dgv_Data = new DevComponents.DotNetBar.Controls.DataGridViewX();
            this.check_col = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.Id = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.edit_col = new System.Windows.Forms.DataGridViewImageColumn();
            this.delete_col = new System.Windows.Forms.DataGridViewImageColumn();
            this.MaNhanVien = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.panel5 = new System.Windows.Forms.Panel();
            this.gbNhanVien = new System.Windows.Forms.GroupBox();
            this.DGVNhanVien = new DevComponents.DotNetBar.Controls.DataGridViewX();
            this.chk_col = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.Column1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column4 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.txt_search_nhanvien = new DevComponents.DotNetBar.Controls.TextBoxX();
            this.groupPhongBan = new System.Windows.Forms.GroupBox();
            this.treeViewSoDoQuanLy = new System.Windows.Forms.TreeView();
            this.imageList1 = new System.Windows.Forms.ImageList(this.components);
            this.panel1 = new System.Windows.Forms.Panel();
            ((System.ComponentModel.ISupportInitialize)(this.dtp_TuNgaySearch)).BeginInit();
            this.panel3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dtp_DenNgay)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtp_TuNgay)).BeginInit();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dtp_DenNgaySearch)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgv_Data)).BeginInit();
            this.panel5.SuspendLayout();
            this.gbNhanVien.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.DGVNhanVien)).BeginInit();
            this.groupPhongBan.SuspendLayout();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // dtp_TuNgaySearch
            // 
            this.dtp_TuNgaySearch.ButtonDropDown.Visible = true;
            this.dtp_TuNgaySearch.Location = new System.Drawing.Point(73, 12);
            // 
            // 
            // 
            this.dtp_TuNgaySearch.MonthCalendar.AnnuallyMarkedDates = new System.DateTime[0];
            this.dtp_TuNgaySearch.MonthCalendar.DisplayMonth = new System.DateTime(2024, 11, 1, 0, 0, 0, 0);
            this.dtp_TuNgaySearch.MonthCalendar.MarkedDates = new System.DateTime[0];
            this.dtp_TuNgaySearch.MonthCalendar.MonthlyMarkedDates = new System.DateTime[0];
            this.dtp_TuNgaySearch.Name = "dtp_TuNgaySearch";
            this.dtp_TuNgaySearch.Size = new System.Drawing.Size(98, 20);
            this.dtp_TuNgaySearch.TabIndex = 0;
            // 
            // DenNgay
            // 
            this.DenNgay.DataPropertyName = "DenNgay";
            this.DenNgay.HeaderText = "Đến ngày";
            this.DenNgay.Name = "DenNgay";
            // 
            // PhongBan
            // 
            this.PhongBan.DataPropertyName = "PhongBan";
            this.PhongBan.HeaderText = "Phòng ban";
            this.PhongBan.Name = "PhongBan";
            // 
            // MaChamCong
            // 
            this.MaChamCong.DataPropertyName = "MaChamCong";
            this.MaChamCong.HeaderText = "Mã chấm công";
            this.MaChamCong.Name = "MaChamCong";
            this.MaChamCong.Visible = false;
            // 
            // panel3
            // 
            this.panel3.Controls.Add(this.chk_new);
            this.panel3.Controls.Add(this.btn_Delete);
            this.panel3.Controls.Add(this.btn_ImportExcel);
            this.panel3.Controls.Add(this.btn_Add);
            this.panel3.Controls.Add(this.labelX4);
            this.panel3.Controls.Add(this.labelX3);
            this.panel3.Controls.Add(this.dtp_DenNgay);
            this.panel3.Controls.Add(this.dtp_TuNgay);
            this.panel3.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel3.Location = new System.Drawing.Point(0, 523);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(594, 72);
            this.panel3.TabIndex = 5;
            // 
            // chk_new
            // 
            this.chk_new.AutoSize = true;
            this.chk_new.ForeColor = System.Drawing.Color.Red;
            this.chk_new.Location = new System.Drawing.Point(366, 36);
            this.chk_new.Name = "chk_new";
            this.chk_new.Size = new System.Drawing.Size(109, 17);
            this.chk_new.TabIndex = 8;
            this.chk_new.Text = "Sheet đang chọn";
            this.chk_new.UseVisualStyleBackColor = true;
            // 
            // btn_Delete
            // 
            this.btn_Delete.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.btn_Delete.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            this.btn_Delete.Location = new System.Drawing.Point(216, 37);
            this.btn_Delete.Name = "btn_Delete";
            this.btn_Delete.Size = new System.Drawing.Size(131, 23);
            this.btn_Delete.TabIndex = 5;
            this.btn_Delete.Text = "Xóa";
            this.btn_Delete.Click += new System.EventHandler(this.btn_Delete_Click);
            // 
            // btn_ImportExcel
            // 
            this.btn_ImportExcel.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.btn_ImportExcel.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            this.btn_ImportExcel.Image = ((System.Drawing.Image)(resources.GetObject("btn_ImportExcel.Image")));
            this.btn_ImportExcel.Location = new System.Drawing.Point(366, 8);
            this.btn_ImportExcel.Name = "btn_ImportExcel";
            this.btn_ImportExcel.Size = new System.Drawing.Size(131, 23);
            this.btn_ImportExcel.TabIndex = 6;
            this.btn_ImportExcel.Text = "Thêm từ excel";
            this.btn_ImportExcel.Click += new System.EventHandler(this.btn_ImportExcel_Click);
            // 
            // btn_Add
            // 
            this.btn_Add.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.btn_Add.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            this.btn_Add.Image = ((System.Drawing.Image)(resources.GetObject("btn_Add.Image")));
            this.btn_Add.Location = new System.Drawing.Point(216, 8);
            this.btn_Add.Name = "btn_Add";
            this.btn_Add.Size = new System.Drawing.Size(131, 23);
            this.btn_Add.TabIndex = 7;
            this.btn_Add.Text = "Thêm";
            this.btn_Add.Click += new System.EventHandler(this.btn_Add_Click);
            // 
            // labelX4
            // 
            this.labelX4.Location = new System.Drawing.Point(12, 34);
            this.labelX4.Name = "labelX4";
            this.labelX4.Size = new System.Drawing.Size(55, 23);
            this.labelX4.TabIndex = 1;
            this.labelX4.Text = "Đến ngày";
            // 
            // labelX3
            // 
            this.labelX3.Location = new System.Drawing.Point(12, 8);
            this.labelX3.Name = "labelX3";
            this.labelX3.Size = new System.Drawing.Size(55, 23);
            this.labelX3.TabIndex = 1;
            this.labelX3.Text = "Từ ngày";
            // 
            // dtp_DenNgay
            // 
            // 
            // 
            // 
            this.dtp_DenNgay.BackgroundStyle.Class = "DateTimeInputBackground";
            this.dtp_DenNgay.ButtonDropDown.Visible = true;
            this.dtp_DenNgay.Location = new System.Drawing.Point(78, 35);
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
            this.dtp_DenNgay.Size = new System.Drawing.Size(121, 20);
            this.dtp_DenNgay.TabIndex = 0;
            // 
            // dtp_TuNgay
            // 
            // 
            // 
            // 
            this.dtp_TuNgay.BackgroundStyle.Class = "DateTimeInputBackground";
            this.dtp_TuNgay.ButtonDropDown.Visible = true;
            this.dtp_TuNgay.Location = new System.Drawing.Point(78, 9);
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
            this.dtp_TuNgay.Size = new System.Drawing.Size(121, 20);
            this.dtp_TuNgay.TabIndex = 0;
            // 
            // TuNgay
            // 
            this.TuNgay.DataPropertyName = "TuNgay";
            this.TuNgay.HeaderText = "Từ ngày";
            this.TuNgay.Name = "TuNgay";
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.btn_Search);
            this.panel2.Controls.Add(this.dtp_DenNgaySearch);
            this.panel2.Controls.Add(this.labelX2);
            this.panel2.Controls.Add(this.dtp_TuNgaySearch);
            this.panel2.Controls.Add(this.labelX1);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel2.Location = new System.Drawing.Point(0, 0);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(594, 42);
            this.panel2.TabIndex = 3;
            // 
            // btn_Search
            // 
            this.btn_Search.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.btn_Search.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.btn_Search.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            this.btn_Search.Location = new System.Drawing.Point(470, 11);
            this.btn_Search.Name = "btn_Search";
            this.btn_Search.Size = new System.Drawing.Size(112, 23);
            this.btn_Search.TabIndex = 3;
            this.btn_Search.Text = "Tìm kiếm";
            this.btn_Search.Click += new System.EventHandler(this.btn_Search_Click);
            // 
            // dtp_DenNgaySearch
            // 
            this.dtp_DenNgaySearch.ButtonDropDown.Visible = true;
            this.dtp_DenNgaySearch.Location = new System.Drawing.Point(249, 12);
            // 
            // 
            // 
            this.dtp_DenNgaySearch.MonthCalendar.AnnuallyMarkedDates = new System.DateTime[0];
            this.dtp_DenNgaySearch.MonthCalendar.DisplayMonth = new System.DateTime(2024, 11, 1, 0, 0, 0, 0);
            this.dtp_DenNgaySearch.MonthCalendar.MarkedDates = new System.DateTime[0];
            this.dtp_DenNgaySearch.MonthCalendar.MonthlyMarkedDates = new System.DateTime[0];
            this.dtp_DenNgaySearch.Name = "dtp_DenNgaySearch";
            this.dtp_DenNgaySearch.Size = new System.Drawing.Size(98, 20);
            this.dtp_DenNgaySearch.TabIndex = 1;
            // 
            // labelX2
            // 
            this.labelX2.Location = new System.Drawing.Point(188, 12);
            this.labelX2.Name = "labelX2";
            this.labelX2.Size = new System.Drawing.Size(55, 20);
            this.labelX2.TabIndex = 0;
            this.labelX2.Text = "Đến ngày";
            // 
            // labelX1
            // 
            this.labelX1.Location = new System.Drawing.Point(12, 12);
            this.labelX1.Name = "labelX1";
            this.labelX1.Size = new System.Drawing.Size(55, 20);
            this.labelX1.TabIndex = 0;
            this.labelX1.Text = "Từ ngày";
            // 
            // TenNhanVien
            // 
            this.TenNhanVien.DataPropertyName = "TenNhanVien";
            this.TenNhanVien.HeaderText = "Tên nhân viên";
            this.TenNhanVien.Name = "TenNhanVien";
            this.TenNhanVien.Width = 150;
            // 
            // dgv_Data
            // 
            this.dgv_Data.AllowUserToAddRows = false;
            this.dgv_Data.BackgroundColor = System.Drawing.Color.GhostWhite;
            this.dgv_Data.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgv_Data.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.check_col,
            this.Id,
            this.edit_col,
            this.delete_col,
            this.MaNhanVien,
            this.TenNhanVien,
            this.TuNgay,
            this.DenNgay,
            this.PhongBan,
            this.MaChamCong});
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgv_Data.DefaultCellStyle = dataGridViewCellStyle1;
            this.dgv_Data.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgv_Data.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(215)))), ((int)(((byte)(229)))));
            this.dgv_Data.Location = new System.Drawing.Point(0, 42);
            this.dgv_Data.Name = "dgv_Data";
            this.dgv_Data.Size = new System.Drawing.Size(594, 481);
            this.dgv_Data.TabIndex = 4;
            this.dgv_Data.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgv_Data_CellClick);
            // 
            // check_col
            // 
            this.check_col.HeaderText = "";
            this.check_col.Name = "check_col";
            this.check_col.Width = 30;
            // 
            // Id
            // 
            this.Id.DataPropertyName = "id";
            this.Id.HeaderText = "id";
            this.Id.Name = "Id";
            this.Id.Visible = false;
            // 
            // edit_col
            // 
            this.edit_col.HeaderText = "";
            this.edit_col.Image = ((System.Drawing.Image)(resources.GetObject("edit_col.Image")));
            this.edit_col.Name = "edit_col";
            this.edit_col.Width = 30;
            // 
            // delete_col
            // 
            this.delete_col.HeaderText = "";
            this.delete_col.Name = "delete_col";
            this.delete_col.Width = 30;
            // 
            // MaNhanVien
            // 
            this.MaNhanVien.DataPropertyName = "MaNhanVien";
            this.MaNhanVien.HeaderText = "Mã nhân viên";
            this.MaNhanVien.Name = "MaNhanVien";
            // 
            // panel5
            // 
            this.panel5.Controls.Add(this.gbNhanVien);
            this.panel5.Controls.Add(this.txt_search_nhanvien);
            this.panel5.Dock = System.Windows.Forms.DockStyle.Left;
            this.panel5.Location = new System.Drawing.Point(277, 0);
            this.panel5.Name = "panel5";
            this.panel5.Padding = new System.Windows.Forms.Padding(5);
            this.panel5.Size = new System.Drawing.Size(319, 595);
            this.panel5.TabIndex = 14;
            // 
            // gbNhanVien
            // 
            this.gbNhanVien.Controls.Add(this.DGVNhanVien);
            this.gbNhanVien.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gbNhanVien.Location = new System.Drawing.Point(5, 25);
            this.gbNhanVien.Name = "gbNhanVien";
            this.gbNhanVien.Size = new System.Drawing.Size(309, 565);
            this.gbNhanVien.TabIndex = 31;
            this.gbNhanVien.TabStop = false;
            this.gbNhanVien.Text = "Nhân viên :";
            // 
            // DGVNhanVien
            // 
            this.DGVNhanVien.AllowUserToAddRows = false;
            this.DGVNhanVien.BackgroundColor = System.Drawing.Color.GhostWhite;
            this.DGVNhanVien.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.DGVNhanVien.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.chk_col,
            this.Column1,
            this.Column2,
            this.dataGridViewTextBoxColumn1,
            this.Column4});
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.DGVNhanVien.DefaultCellStyle = dataGridViewCellStyle2;
            this.DGVNhanVien.Dock = System.Windows.Forms.DockStyle.Fill;
            this.DGVNhanVien.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(215)))), ((int)(((byte)(229)))));
            this.DGVNhanVien.Location = new System.Drawing.Point(3, 16);
            this.DGVNhanVien.Name = "DGVNhanVien";
            this.DGVNhanVien.RowHeadersWidth = 23;
            this.DGVNhanVien.Size = new System.Drawing.Size(303, 546);
            this.DGVNhanVien.TabIndex = 30;
            // 
            // chk_col
            // 
            this.chk_col.HeaderText = "";
            this.chk_col.Name = "chk_col";
            this.chk_col.Width = 30;
            // 
            // Column1
            // 
            this.Column1.DataPropertyName = "MaNhanVien";
            this.Column1.HeaderText = "Mã Nhân viên";
            this.Column1.Name = "Column1";
            this.Column1.Width = 110;
            // 
            // Column2
            // 
            this.Column2.DataPropertyName = "TenNhanVien";
            this.Column2.FillWeight = 120F;
            this.Column2.HeaderText = "Tên Nhân Viên";
            this.Column2.Name = "Column2";
            this.Column2.Width = 230;
            // 
            // dataGridViewTextBoxColumn1
            // 
            this.dataGridViewTextBoxColumn1.DataPropertyName = "MaChamCong";
            this.dataGridViewTextBoxColumn1.HeaderText = "Mã Chấm Công";
            this.dataGridViewTextBoxColumn1.Name = "dataGridViewTextBoxColumn1";
            this.dataGridViewTextBoxColumn1.Visible = false;
            // 
            // Column4
            // 
            this.Column4.DataPropertyName = "MaPhongBan";
            this.Column4.HeaderText = "MaPhongBan";
            this.Column4.Name = "Column4";
            this.Column4.Visible = false;
            // 
            // txt_search_nhanvien
            // 
            // 
            // 
            // 
            this.txt_search_nhanvien.Border.Class = "TextBoxBorder";
            this.txt_search_nhanvien.Dock = System.Windows.Forms.DockStyle.Top;
            this.txt_search_nhanvien.Location = new System.Drawing.Point(5, 5);
            this.txt_search_nhanvien.Name = "txt_search_nhanvien";
            this.txt_search_nhanvien.Size = new System.Drawing.Size(309, 20);
            this.txt_search_nhanvien.TabIndex = 29;
            this.txt_search_nhanvien.WatermarkText = "Nhập mã hoặc tên nhân viên";
            // 
            // groupPhongBan
            // 
            this.groupPhongBan.Controls.Add(this.treeViewSoDoQuanLy);
            this.groupPhongBan.Dock = System.Windows.Forms.DockStyle.Left;
            this.groupPhongBan.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupPhongBan.Location = new System.Drawing.Point(0, 0);
            this.groupPhongBan.Name = "groupPhongBan";
            this.groupPhongBan.Padding = new System.Windows.Forms.Padding(5);
            this.groupPhongBan.Size = new System.Drawing.Size(277, 595);
            this.groupPhongBan.TabIndex = 13;
            this.groupPhongBan.TabStop = false;
            this.groupPhongBan.Text = "Phòng ban";
            // 
            // treeViewSoDoQuanLy
            // 
            this.treeViewSoDoQuanLy.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.treeViewSoDoQuanLy.Dock = System.Windows.Forms.DockStyle.Fill;
            this.treeViewSoDoQuanLy.Font = new System.Drawing.Font("Tahoma", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.treeViewSoDoQuanLy.ImageKey = "No.png";
            this.treeViewSoDoQuanLy.ImageList = this.imageList1;
            this.treeViewSoDoQuanLy.Location = new System.Drawing.Point(5, 20);
            this.treeViewSoDoQuanLy.Name = "treeViewSoDoQuanLy";
            this.treeViewSoDoQuanLy.SelectedImageIndex = 1;
            this.treeViewSoDoQuanLy.Size = new System.Drawing.Size(267, 570);
            this.treeViewSoDoQuanLy.StateImageList = this.imageList1;
            this.treeViewSoDoQuanLy.TabIndex = 10;
            this.treeViewSoDoQuanLy.AfterSelect += new System.Windows.Forms.TreeViewEventHandler(this.treeViewSoDoQuanLy_AfterSelect);
            // 
            // imageList1
            // 
            this.imageList1.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imageList1.ImageStream")));
            this.imageList1.TransparentColor = System.Drawing.Color.Transparent;
            this.imageList1.Images.SetKeyName(0, "No.png");
            this.imageList1.Images.SetKeyName(1, "Yes.png");
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.dgv_Data);
            this.panel1.Controls.Add(this.panel3);
            this.panel1.Controls.Add(this.panel2);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(596, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(594, 595);
            this.panel1.TabIndex = 15;
            // 
            // frm_NuoiConNho
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1190, 595);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.panel5);
            this.Controls.Add(this.groupPhongBan);
            this.Name = "frm_NuoiConNho";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Danh sách nuôi con nhỏ";
            this.Load += new System.EventHandler(this.frm_NuoiConNho_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dtp_TuNgaySearch)).EndInit();
            this.panel3.ResumeLayout(false);
            this.panel3.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dtp_DenNgay)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtp_TuNgay)).EndInit();
            this.panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dtp_DenNgaySearch)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgv_Data)).EndInit();
            this.panel5.ResumeLayout(false);
            this.gbNhanVien.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.DGVNhanVien)).EndInit();
            this.groupPhongBan.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private DevComponents.Editors.DateTimeAdv.DateTimeInput dtp_TuNgaySearch;
        private System.Windows.Forms.DataGridViewTextBoxColumn DenNgay;
        private System.Windows.Forms.DataGridViewTextBoxColumn PhongBan;
        private System.Windows.Forms.DataGridViewTextBoxColumn MaChamCong;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.CheckBox chk_new;
        private DevComponents.DotNetBar.ButtonX btn_Delete;
        private DevComponents.DotNetBar.ButtonX btn_ImportExcel;
        private DevComponents.DotNetBar.ButtonX btn_Add;
        private DevComponents.DotNetBar.LabelX labelX4;
        private DevComponents.DotNetBar.LabelX labelX3;
        private DevComponents.Editors.DateTimeAdv.DateTimeInput dtp_DenNgay;
        private DevComponents.Editors.DateTimeAdv.DateTimeInput dtp_TuNgay;
        private System.Windows.Forms.DataGridViewTextBoxColumn TuNgay;
        private System.Windows.Forms.Panel panel2;
        private DevComponents.DotNetBar.ButtonX btn_Search;
        private DevComponents.Editors.DateTimeAdv.DateTimeInput dtp_DenNgaySearch;
        private DevComponents.DotNetBar.LabelX labelX2;
        private DevComponents.DotNetBar.LabelX labelX1;
        private System.Windows.Forms.DataGridViewTextBoxColumn TenNhanVien;
        private DevComponents.DotNetBar.Controls.DataGridViewX dgv_Data;
        private System.Windows.Forms.DataGridViewCheckBoxColumn check_col;
        private System.Windows.Forms.DataGridViewTextBoxColumn Id;
        private System.Windows.Forms.DataGridViewImageColumn edit_col;
        private System.Windows.Forms.DataGridViewImageColumn delete_col;
        private System.Windows.Forms.DataGridViewTextBoxColumn MaNhanVien;
        private System.Windows.Forms.Panel panel5;
        private System.Windows.Forms.GroupBox gbNhanVien;
        private DevComponents.DotNetBar.Controls.DataGridViewX DGVNhanVien;
        private System.Windows.Forms.DataGridViewCheckBoxColumn chk_col;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column1;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column2;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn1;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column4;
        private DevComponents.DotNetBar.Controls.TextBoxX txt_search_nhanvien;
        private System.Windows.Forms.GroupBox groupPhongBan;
        private System.Windows.Forms.TreeView treeViewSoDoQuanLy;
        private System.Windows.Forms.ImageList imageList1;
        private System.Windows.Forms.Panel panel1;
    }
}