namespace TENTAC_HRM.Forms.Main
{
    partial class uc_dashboard
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.dgv_SinhNhat = new DevComponents.DotNetBar.Controls.DataGridViewX();
            this.MaNhanVien = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.TenNhanVien = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.TenPhongBan = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.NgaySinh = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.panel7 = new System.Windows.Forms.Panel();
            this.groupPanel2 = new DevComponents.DotNetBar.Controls.GroupPanel();
            this.dataGridViewX1 = new DevComponents.DotNetBar.Controls.DataGridViewX();
            this.panel8 = new System.Windows.Forms.Panel();
            this.buttonX2 = new DevComponents.DotNetBar.ButtonX();
            this.panel1 = new System.Windows.Forms.Panel();
            this.grb_SinhNhat = new DevComponents.DotNetBar.Controls.GroupPanel();
            this.panel5 = new System.Windows.Forms.Panel();
            this.btn_ExportSinhNhat = new DevComponents.DotNetBar.ButtonX();
            this.panel2 = new System.Windows.Forms.Panel();
            this.groupPanel1 = new DevComponents.DotNetBar.Controls.GroupPanel();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.panel6 = new System.Windows.Forms.Panel();
            this.panel3 = new System.Windows.Forms.Panel();
            this.grb_NhanVienMoi = new DevComponents.DotNetBar.Controls.GroupPanel();
            this.dgv_NhanVienMoi = new DevComponents.DotNetBar.Controls.DataGridViewX();
            this.MaNhanVien_N = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.TenNhanVien_N = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.NgayVaoLamViec_N = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.panel4 = new System.Windows.Forms.Panel();
            this.buttonX1 = new DevComponents.DotNetBar.ButtonX();
            ((System.ComponentModel.ISupportInitialize)(this.dgv_SinhNhat)).BeginInit();
            this.tableLayoutPanel1.SuspendLayout();
            this.panel7.SuspendLayout();
            this.groupPanel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewX1)).BeginInit();
            this.panel8.SuspendLayout();
            this.panel1.SuspendLayout();
            this.grb_SinhNhat.SuspendLayout();
            this.panel5.SuspendLayout();
            this.panel2.SuspendLayout();
            this.groupPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.panel3.SuspendLayout();
            this.grb_NhanVienMoi.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgv_NhanVienMoi)).BeginInit();
            this.panel4.SuspendLayout();
            this.SuspendLayout();
            // 
            // timer1
            // 
            this.timer1.Interval = 15;
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // dgv_SinhNhat
            // 
            this.dgv_SinhNhat.AllowUserToAddRows = false;
            this.dgv_SinhNhat.BackgroundColor = System.Drawing.SystemColors.Control;
            this.dgv_SinhNhat.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dgv_SinhNhat.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgv_SinhNhat.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.MaNhanVien,
            this.TenNhanVien,
            this.TenPhongBan,
            this.NgaySinh});
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgv_SinhNhat.DefaultCellStyle = dataGridViewCellStyle1;
            this.dgv_SinhNhat.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgv_SinhNhat.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(215)))), ((int)(((byte)(229)))));
            this.dgv_SinhNhat.Location = new System.Drawing.Point(0, 0);
            this.dgv_SinhNhat.Name = "dgv_SinhNhat";
            this.dgv_SinhNhat.Size = new System.Drawing.Size(677, 284);
            this.dgv_SinhNhat.TabIndex = 0;
            this.dgv_SinhNhat.RowPostPaint += new System.Windows.Forms.DataGridViewRowPostPaintEventHandler(this.dgv_SinhNhat_RowPostPaint);
            // 
            // MaNhanVien
            // 
            this.MaNhanVien.DataPropertyName = "MaNhanVien";
            this.MaNhanVien.HeaderText = "Mã nhân viên";
            this.MaNhanVien.Name = "MaNhanVien";
            this.MaNhanVien.Width = 125;
            // 
            // TenNhanVien
            // 
            this.TenNhanVien.DataPropertyName = "TenNhanVien";
            this.TenNhanVien.HeaderText = "Tên nhân viên";
            this.TenNhanVien.Name = "TenNhanVien";
            this.TenNhanVien.Width = 200;
            // 
            // TenPhongBan
            // 
            this.TenPhongBan.DataPropertyName = "TenPhongBan";
            this.TenPhongBan.HeaderText = "Phòng ban";
            this.TenPhongBan.Name = "TenPhongBan";
            this.TenPhongBan.Width = 150;
            // 
            // NgaySinh
            // 
            this.NgaySinh.DataPropertyName = "NgaySinh";
            this.NgaySinh.HeaderText = "Ngày sinh";
            this.NgaySinh.Name = "NgaySinh";
            this.NgaySinh.Width = 150;
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.tableLayoutPanel1.ColumnCount = 2;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.Controls.Add(this.panel7, 1, 1);
            this.tableLayoutPanel1.Controls.Add(this.panel1, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.panel2, 1, 0);
            this.tableLayoutPanel1.Controls.Add(this.panel3, 0, 1);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 2;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(1378, 689);
            this.tableLayoutPanel1.TabIndex = 2;
            // 
            // panel7
            // 
            this.panel7.Controls.Add(this.groupPanel2);
            this.panel7.Controls.Add(this.panel8);
            this.panel7.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel7.Location = new System.Drawing.Point(692, 347);
            this.panel7.Name = "panel7";
            this.panel7.Size = new System.Drawing.Size(683, 339);
            this.panel7.TabIndex = 6;
            // 
            // groupPanel2
            // 
            this.groupPanel2.CanvasColor = System.Drawing.SystemColors.Control;
            this.groupPanel2.ColorSchemeStyle = DevComponents.DotNetBar.eDotNetBarStyle.Office2007;
            this.groupPanel2.Controls.Add(this.dataGridViewX1);
            this.groupPanel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupPanel2.Location = new System.Drawing.Point(0, 0);
            this.groupPanel2.Name = "groupPanel2";
            this.groupPanel2.Size = new System.Drawing.Size(683, 309);
            // 
            // 
            // 
            this.groupPanel2.Style.BackColor2SchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground2;
            this.groupPanel2.Style.BackColorGradientAngle = 90;
            this.groupPanel2.Style.BackColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground;
            this.groupPanel2.Style.BorderBottom = DevComponents.DotNetBar.eStyleBorderType.Solid;
            this.groupPanel2.Style.BorderBottomWidth = 1;
            this.groupPanel2.Style.BorderColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBorder;
            this.groupPanel2.Style.BorderLeft = DevComponents.DotNetBar.eStyleBorderType.Solid;
            this.groupPanel2.Style.BorderLeftWidth = 1;
            this.groupPanel2.Style.BorderRight = DevComponents.DotNetBar.eStyleBorderType.Solid;
            this.groupPanel2.Style.BorderRightWidth = 1;
            this.groupPanel2.Style.BorderTop = DevComponents.DotNetBar.eStyleBorderType.Solid;
            this.groupPanel2.Style.BorderTopWidth = 1;
            this.groupPanel2.Style.CornerDiameter = 4;
            this.groupPanel2.Style.CornerType = DevComponents.DotNetBar.eCornerType.Rounded;
            this.groupPanel2.Style.TextAlignment = DevComponents.DotNetBar.eStyleTextAlignment.Center;
            this.groupPanel2.Style.TextColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelText;
            this.groupPanel2.Style.TextLineAlignment = DevComponents.DotNetBar.eStyleTextAlignment.Near;
            this.groupPanel2.TabIndex = 0;
            this.groupPanel2.Text = "Test";
            // 
            // dataGridViewX1
            // 
            this.dataGridViewX1.AllowUserToAddRows = false;
            this.dataGridViewX1.BackgroundColor = System.Drawing.SystemColors.Control;
            this.dataGridViewX1.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dataGridViewX1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dataGridViewX1.DefaultCellStyle = dataGridViewCellStyle2;
            this.dataGridViewX1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataGridViewX1.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(215)))), ((int)(((byte)(229)))));
            this.dataGridViewX1.Location = new System.Drawing.Point(0, 0);
            this.dataGridViewX1.Name = "dataGridViewX1";
            this.dataGridViewX1.Size = new System.Drawing.Size(677, 284);
            this.dataGridViewX1.TabIndex = 0;
            // 
            // panel8
            // 
            this.panel8.Controls.Add(this.buttonX2);
            this.panel8.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel8.Location = new System.Drawing.Point(0, 309);
            this.panel8.Name = "panel8";
            this.panel8.Size = new System.Drawing.Size(683, 30);
            this.panel8.TabIndex = 1;
            // 
            // buttonX2
            // 
            this.buttonX2.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.buttonX2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonX2.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            this.buttonX2.Location = new System.Drawing.Point(578, 4);
            this.buttonX2.Name = "buttonX2";
            this.buttonX2.Size = new System.Drawing.Size(102, 23);
            this.buttonX2.TabIndex = 0;
            this.buttonX2.Text = "buttonX2";
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.grb_SinhNhat);
            this.panel1.Controls.Add(this.panel5);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(3, 3);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(683, 338);
            this.panel1.TabIndex = 3;
            // 
            // grb_SinhNhat
            // 
            this.grb_SinhNhat.CanvasColor = System.Drawing.SystemColors.Control;
            this.grb_SinhNhat.ColorSchemeStyle = DevComponents.DotNetBar.eDotNetBarStyle.Office2007;
            this.grb_SinhNhat.Controls.Add(this.dgv_SinhNhat);
            this.grb_SinhNhat.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grb_SinhNhat.Location = new System.Drawing.Point(0, 0);
            this.grb_SinhNhat.Name = "grb_SinhNhat";
            this.grb_SinhNhat.Size = new System.Drawing.Size(683, 309);
            // 
            // 
            // 
            this.grb_SinhNhat.Style.BackColor2SchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground2;
            this.grb_SinhNhat.Style.BackColorGradientAngle = 90;
            this.grb_SinhNhat.Style.BackColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground;
            this.grb_SinhNhat.Style.BorderBottom = DevComponents.DotNetBar.eStyleBorderType.Solid;
            this.grb_SinhNhat.Style.BorderBottomWidth = 1;
            this.grb_SinhNhat.Style.BorderColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBorder;
            this.grb_SinhNhat.Style.BorderLeft = DevComponents.DotNetBar.eStyleBorderType.Solid;
            this.grb_SinhNhat.Style.BorderLeftWidth = 1;
            this.grb_SinhNhat.Style.BorderRight = DevComponents.DotNetBar.eStyleBorderType.Solid;
            this.grb_SinhNhat.Style.BorderRightWidth = 1;
            this.grb_SinhNhat.Style.BorderTop = DevComponents.DotNetBar.eStyleBorderType.Solid;
            this.grb_SinhNhat.Style.BorderTopWidth = 1;
            this.grb_SinhNhat.Style.CornerDiameter = 4;
            this.grb_SinhNhat.Style.CornerType = DevComponents.DotNetBar.eCornerType.Rounded;
            this.grb_SinhNhat.Style.TextAlignment = DevComponents.DotNetBar.eStyleTextAlignment.Center;
            this.grb_SinhNhat.Style.TextColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelText;
            this.grb_SinhNhat.Style.TextLineAlignment = DevComponents.DotNetBar.eStyleTextAlignment.Near;
            this.grb_SinhNhat.TabIndex = 0;
            this.grb_SinhNhat.Text = "Nhân viên có sinh nhật trong tháng";
            // 
            // panel5
            // 
            this.panel5.Controls.Add(this.btn_ExportSinhNhat);
            this.panel5.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel5.Location = new System.Drawing.Point(0, 309);
            this.panel5.Name = "panel5";
            this.panel5.Size = new System.Drawing.Size(683, 29);
            this.panel5.TabIndex = 3;
            // 
            // btn_ExportSinhNhat
            // 
            this.btn_ExportSinhNhat.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.btn_ExportSinhNhat.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btn_ExportSinhNhat.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            this.btn_ExportSinhNhat.Image = global::TENTAC_HRM.Properties.Resources.export_excel;
            this.btn_ExportSinhNhat.Location = new System.Drawing.Point(578, 3);
            this.btn_ExportSinhNhat.Name = "btn_ExportSinhNhat";
            this.btn_ExportSinhNhat.Size = new System.Drawing.Size(102, 23);
            this.btn_ExportSinhNhat.TabIndex = 2;
            this.btn_ExportSinhNhat.Text = "Xuất Excel";
            this.btn_ExportSinhNhat.Click += new System.EventHandler(this.btn_ExportSinhNhat_Click);
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.groupPanel1);
            this.panel2.Controls.Add(this.panel6);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel2.Location = new System.Drawing.Point(692, 3);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(683, 338);
            this.panel2.TabIndex = 4;
            // 
            // groupPanel1
            // 
            this.groupPanel1.CanvasColor = System.Drawing.SystemColors.Control;
            this.groupPanel1.ColorSchemeStyle = DevComponents.DotNetBar.eDotNetBarStyle.Office2007;
            this.groupPanel1.Controls.Add(this.dataGridView1);
            this.groupPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupPanel1.Location = new System.Drawing.Point(0, 0);
            this.groupPanel1.Name = "groupPanel1";
            this.groupPanel1.Size = new System.Drawing.Size(683, 309);
            // 
            // 
            // 
            this.groupPanel1.Style.BackColor2SchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground2;
            this.groupPanel1.Style.BackColorGradientAngle = 90;
            this.groupPanel1.Style.BackColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground;
            this.groupPanel1.Style.BorderBottom = DevComponents.DotNetBar.eStyleBorderType.Solid;
            this.groupPanel1.Style.BorderBottomWidth = 1;
            this.groupPanel1.Style.BorderColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBorder;
            this.groupPanel1.Style.BorderLeft = DevComponents.DotNetBar.eStyleBorderType.Solid;
            this.groupPanel1.Style.BorderLeftWidth = 1;
            this.groupPanel1.Style.BorderRight = DevComponents.DotNetBar.eStyleBorderType.Solid;
            this.groupPanel1.Style.BorderRightWidth = 1;
            this.groupPanel1.Style.BorderTop = DevComponents.DotNetBar.eStyleBorderType.Solid;
            this.groupPanel1.Style.BorderTopWidth = 1;
            this.groupPanel1.Style.CornerDiameter = 4;
            this.groupPanel1.Style.CornerType = DevComponents.DotNetBar.eCornerType.Rounded;
            this.groupPanel1.Style.TextAlignment = DevComponents.DotNetBar.eStyleTextAlignment.Center;
            this.groupPanel1.Style.TextColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelText;
            this.groupPanel1.Style.TextLineAlignment = DevComponents.DotNetBar.eStyleTextAlignment.Near;
            this.groupPanel1.TabIndex = 0;
            this.groupPanel1.Text = "Hợp đồng sắp hết hạn";
            // 
            // dataGridView1
            // 
            this.dataGridView1.BackgroundColor = System.Drawing.SystemColors.Control;
            this.dataGridView1.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataGridView1.Location = new System.Drawing.Point(0, 0);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.Size = new System.Drawing.Size(677, 284);
            this.dataGridView1.TabIndex = 0;
            // 
            // panel6
            // 
            this.panel6.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel6.Location = new System.Drawing.Point(0, 309);
            this.panel6.Name = "panel6";
            this.panel6.Size = new System.Drawing.Size(683, 29);
            this.panel6.TabIndex = 4;
            // 
            // panel3
            // 
            this.panel3.Controls.Add(this.grb_NhanVienMoi);
            this.panel3.Controls.Add(this.panel4);
            this.panel3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel3.Location = new System.Drawing.Point(3, 347);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(683, 339);
            this.panel3.TabIndex = 5;
            // 
            // grb_NhanVienMoi
            // 
            this.grb_NhanVienMoi.CanvasColor = System.Drawing.SystemColors.Control;
            this.grb_NhanVienMoi.ColorSchemeStyle = DevComponents.DotNetBar.eDotNetBarStyle.Office2007;
            this.grb_NhanVienMoi.Controls.Add(this.dgv_NhanVienMoi);
            this.grb_NhanVienMoi.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grb_NhanVienMoi.Location = new System.Drawing.Point(0, 0);
            this.grb_NhanVienMoi.Name = "grb_NhanVienMoi";
            this.grb_NhanVienMoi.Size = new System.Drawing.Size(683, 309);
            // 
            // 
            // 
            this.grb_NhanVienMoi.Style.BackColor2SchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground2;
            this.grb_NhanVienMoi.Style.BackColorGradientAngle = 90;
            this.grb_NhanVienMoi.Style.BackColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground;
            this.grb_NhanVienMoi.Style.BorderBottom = DevComponents.DotNetBar.eStyleBorderType.Solid;
            this.grb_NhanVienMoi.Style.BorderBottomWidth = 1;
            this.grb_NhanVienMoi.Style.BorderColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBorder;
            this.grb_NhanVienMoi.Style.BorderLeft = DevComponents.DotNetBar.eStyleBorderType.Solid;
            this.grb_NhanVienMoi.Style.BorderLeftWidth = 1;
            this.grb_NhanVienMoi.Style.BorderRight = DevComponents.DotNetBar.eStyleBorderType.Solid;
            this.grb_NhanVienMoi.Style.BorderRightWidth = 1;
            this.grb_NhanVienMoi.Style.BorderTop = DevComponents.DotNetBar.eStyleBorderType.Solid;
            this.grb_NhanVienMoi.Style.BorderTopWidth = 1;
            this.grb_NhanVienMoi.Style.CornerDiameter = 4;
            this.grb_NhanVienMoi.Style.CornerType = DevComponents.DotNetBar.eCornerType.Rounded;
            this.grb_NhanVienMoi.Style.TextAlignment = DevComponents.DotNetBar.eStyleTextAlignment.Center;
            this.grb_NhanVienMoi.Style.TextColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelText;
            this.grb_NhanVienMoi.Style.TextLineAlignment = DevComponents.DotNetBar.eStyleTextAlignment.Near;
            this.grb_NhanVienMoi.TabIndex = 0;
            this.grb_NhanVienMoi.Text = "Nhân viên mới";
            // 
            // dgv_NhanVienMoi
            // 
            this.dgv_NhanVienMoi.AllowUserToAddRows = false;
            this.dgv_NhanVienMoi.BackgroundColor = System.Drawing.SystemColors.Control;
            this.dgv_NhanVienMoi.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dgv_NhanVienMoi.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgv_NhanVienMoi.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.MaNhanVien_N,
            this.TenNhanVien_N,
            this.NgayVaoLamViec_N});
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            dataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgv_NhanVienMoi.DefaultCellStyle = dataGridViewCellStyle3;
            this.dgv_NhanVienMoi.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgv_NhanVienMoi.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(215)))), ((int)(((byte)(229)))));
            this.dgv_NhanVienMoi.Location = new System.Drawing.Point(0, 0);
            this.dgv_NhanVienMoi.Name = "dgv_NhanVienMoi";
            this.dgv_NhanVienMoi.Size = new System.Drawing.Size(677, 284);
            this.dgv_NhanVienMoi.TabIndex = 0;
            // 
            // MaNhanVien_N
            // 
            this.MaNhanVien_N.DataPropertyName = "MaNhanVien";
            this.MaNhanVien_N.HeaderText = "Mã nhân viên";
            this.MaNhanVien_N.Name = "MaNhanVien_N";
            this.MaNhanVien_N.Width = 120;
            // 
            // TenNhanVien_N
            // 
            this.TenNhanVien_N.DataPropertyName = "TenNhanVien";
            this.TenNhanVien_N.HeaderText = "Tên nhân viên";
            this.TenNhanVien_N.Name = "TenNhanVien_N";
            this.TenNhanVien_N.Width = 150;
            // 
            // NgayVaoLamViec_N
            // 
            this.NgayVaoLamViec_N.DataPropertyName = "NgayVaoLamViec";
            this.NgayVaoLamViec_N.HeaderText = "Ngày vào làm việc";
            this.NgayVaoLamViec_N.Name = "NgayVaoLamViec_N";
            this.NgayVaoLamViec_N.Width = 150;
            // 
            // panel4
            // 
            this.panel4.Controls.Add(this.buttonX1);
            this.panel4.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel4.Location = new System.Drawing.Point(0, 309);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(683, 30);
            this.panel4.TabIndex = 1;
            // 
            // buttonX1
            // 
            this.buttonX1.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.buttonX1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonX1.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            this.buttonX1.Location = new System.Drawing.Point(578, 4);
            this.buttonX1.Name = "buttonX1";
            this.buttonX1.Size = new System.Drawing.Size(102, 23);
            this.buttonX1.TabIndex = 0;
            this.buttonX1.Text = "buttonX1";
            // 
            // uc_dashboard
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.tableLayoutPanel1);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "uc_dashboard";
            this.Size = new System.Drawing.Size(1378, 689);
            this.Load += new System.EventHandler(this.uc_dashboard_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgv_SinhNhat)).EndInit();
            this.tableLayoutPanel1.ResumeLayout(false);
            this.panel7.ResumeLayout(false);
            this.groupPanel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewX1)).EndInit();
            this.panel8.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.grb_SinhNhat.ResumeLayout(false);
            this.panel5.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            this.groupPanel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.panel3.ResumeLayout(false);
            this.grb_NhanVienMoi.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgv_NhanVienMoi)).EndInit();
            this.panel4.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Timer timer1;
        private DevComponents.DotNetBar.Controls.DataGridViewX dgv_SinhNhat;
        private System.Windows.Forms.DataGridViewTextBoxColumn MaNhanVien;
        private System.Windows.Forms.DataGridViewTextBoxColumn TenNhanVien;
        private System.Windows.Forms.DataGridViewTextBoxColumn TenPhongBan;
        private System.Windows.Forms.DataGridViewTextBoxColumn NgaySinh;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.Panel panel1;
        private DevComponents.DotNetBar.ButtonX btn_ExportSinhNhat;
        private System.Windows.Forms.Panel panel2;
        private DevComponents.DotNetBar.Controls.GroupPanel groupPanel1;
        private System.Windows.Forms.DataGridView dataGridView1;
        private DevComponents.DotNetBar.Controls.GroupPanel grb_SinhNhat;
        private System.Windows.Forms.Panel panel3;
        private DevComponents.DotNetBar.Controls.GroupPanel grb_NhanVienMoi;
        private DevComponents.DotNetBar.Controls.DataGridViewX dgv_NhanVienMoi;
        private System.Windows.Forms.Panel panel4;
        private DevComponents.DotNetBar.ButtonX buttonX1;
        private System.Windows.Forms.Panel panel5;
        private System.Windows.Forms.Panel panel6;
        private System.Windows.Forms.DataGridViewTextBoxColumn MaNhanVien_N;
        private System.Windows.Forms.DataGridViewTextBoxColumn TenNhanVien_N;
        private System.Windows.Forms.DataGridViewTextBoxColumn NgayVaoLamViec_N;
        private System.Windows.Forms.Panel panel7;
        private DevComponents.DotNetBar.Controls.GroupPanel groupPanel2;
        private DevComponents.DotNetBar.Controls.DataGridViewX dataGridViewX1;
        private System.Windows.Forms.Panel panel8;
        private DevComponents.DotNetBar.ButtonX buttonX2;
    }
}
