namespace TENTAC_HRM.Forms.Category
{
    partial class frm_department
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
            this.dgv_nhanvien_phongban = new System.Windows.Forms.DataGridView();
            this.edit_column = new System.Windows.Forms.DataGridViewImageColumn();
            this.id_cong_tac = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cong_ty = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.khu_vuc = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.phong_ban = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.chuc_vu = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.tu_ngay = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.den_ngay = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.is_active = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.pl_donvi = new System.Windows.Forms.Panel();
            this.dtp_den_ngay = new System.Windows.Forms.DateTimePicker();
            this.dtp_tu_ngay = new System.Windows.Forms.DateTimePicker();
            this.cbo_chuc_vu = new System.Windows.Forms.ComboBox();
            this.cbo_phongban = new System.Windows.Forms.ComboBox();
            this.cbo_khuvuc = new System.Windows.Forms.ComboBox();
            this.cbo_donvi = new System.Windows.Forms.ComboBox();
            this.chk_hieu_luc = new System.Windows.Forms.CheckBox();
            this.txt_mo_ta = new System.Windows.Forms.TextBox();
            this.txt_so_quyet_dinh = new System.Windows.Forms.TextBox();
            this.btn_add_chuc_vu = new System.Windows.Forms.Button();
            this.btn_huy = new System.Windows.Forms.Button();
            this.btn_luu = new System.Windows.Forms.Button();
            this.label7 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.linkLabel2 = new System.Windows.Forms.LinkLabel();
            this.panel1 = new System.Windows.Forms.Panel();
            this.label1 = new System.Windows.Forms.Label();
            this.cbo_nhanvien = new System.Windows.Forms.ComboBox();
            this.linkLabel1 = new System.Windows.Forms.LinkLabel();
            this.pl_information = new System.Windows.Forms.Panel();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.btn_add = new System.Windows.Forms.ToolStripButton();
            this.btn_delete = new System.Windows.Forms.ToolStripButton();
            this.btn_close = new System.Windows.Forms.ToolStripButton();
            this.dataGridViewImageColumn1 = new System.Windows.Forms.DataGridViewImageColumn();
            ((System.ComponentModel.ISupportInitialize)(this.dgv_nhanvien_phongban)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.pl_donvi.SuspendLayout();
            this.panel1.SuspendLayout();
            this.pl_information.SuspendLayout();
            this.toolStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // dgv_nhanvien_phongban
            // 
            this.dgv_nhanvien_phongban.AllowUserToAddRows = false;
            this.dgv_nhanvien_phongban.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgv_nhanvien_phongban.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.edit_column,
            this.id_cong_tac,
            this.cong_ty,
            this.khu_vuc,
            this.phong_ban,
            this.chuc_vu,
            this.tu_ngay,
            this.den_ngay,
            this.is_active});
            this.dgv_nhanvien_phongban.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgv_nhanvien_phongban.Location = new System.Drawing.Point(0, 25);
            this.dgv_nhanvien_phongban.Margin = new System.Windows.Forms.Padding(4);
            this.dgv_nhanvien_phongban.Name = "dgv_nhanvien_phongban";
            this.dgv_nhanvien_phongban.Size = new System.Drawing.Size(754, 620);
            this.dgv_nhanvien_phongban.TabIndex = 1;
            this.dgv_nhanvien_phongban.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgv_nhanvien_phongban_CellClick);
            // 
            // edit_column
            // 
            this.edit_column.HeaderText = "";
            this.edit_column.Image = global::TENTAC_HRM.Properties.Resources.pen;
            this.edit_column.Name = "edit_column";
            this.edit_column.Width = 30;
            // 
            // id_cong_tac
            // 
            this.id_cong_tac.DataPropertyName = "id_cong_tac";
            this.id_cong_tac.HeaderText = "Column1";
            this.id_cong_tac.Name = "id_cong_tac";
            this.id_cong_tac.Visible = false;
            // 
            // cong_ty
            // 
            this.cong_ty.DataPropertyName = "cong_ty";
            this.cong_ty.HeaderText = "Công ty";
            this.cong_ty.Name = "cong_ty";
            // 
            // khu_vuc
            // 
            this.khu_vuc.DataPropertyName = "khu_vuc";
            this.khu_vuc.HeaderText = "Khu vực";
            this.khu_vuc.Name = "khu_vuc";
            // 
            // phong_ban
            // 
            this.phong_ban.DataPropertyName = "phong_ban";
            this.phong_ban.HeaderText = "Phòng ban";
            this.phong_ban.Name = "phong_ban";
            // 
            // chuc_vu
            // 
            this.chuc_vu.DataPropertyName = "chuc_vu";
            this.chuc_vu.HeaderText = "Chức vụ";
            this.chuc_vu.Name = "chuc_vu";
            // 
            // tu_ngay
            // 
            this.tu_ngay.DataPropertyName = "tu_ngay";
            this.tu_ngay.HeaderText = "Từ ngày";
            this.tu_ngay.Name = "tu_ngay";
            // 
            // den_ngay
            // 
            this.den_ngay.DataPropertyName = "den_ngay";
            this.den_ngay.HeaderText = "Đến ngày";
            this.den_ngay.Name = "den_ngay";
            // 
            // is_active
            // 
            this.is_active.DataPropertyName = "is_active";
            this.is_active.HeaderText = "Việc chính";
            this.is_active.Name = "is_active";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.pl_donvi);
            this.groupBox1.Controls.Add(this.linkLabel2);
            this.groupBox1.Controls.Add(this.panel1);
            this.groupBox1.Controls.Add(this.linkLabel1);
            this.groupBox1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox1.Location = new System.Drawing.Point(0, 0);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Padding = new System.Windows.Forms.Padding(4);
            this.groupBox1.Size = new System.Drawing.Size(464, 606);
            this.groupBox1.TabIndex = 2;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Đơn vị";
            // 
            // pl_donvi
            // 
            this.pl_donvi.Controls.Add(this.dtp_den_ngay);
            this.pl_donvi.Controls.Add(this.dtp_tu_ngay);
            this.pl_donvi.Controls.Add(this.cbo_chuc_vu);
            this.pl_donvi.Controls.Add(this.cbo_phongban);
            this.pl_donvi.Controls.Add(this.cbo_khuvuc);
            this.pl_donvi.Controls.Add(this.cbo_donvi);
            this.pl_donvi.Controls.Add(this.chk_hieu_luc);
            this.pl_donvi.Controls.Add(this.txt_mo_ta);
            this.pl_donvi.Controls.Add(this.txt_so_quyet_dinh);
            this.pl_donvi.Controls.Add(this.btn_add_chuc_vu);
            this.pl_donvi.Controls.Add(this.btn_huy);
            this.pl_donvi.Controls.Add(this.btn_luu);
            this.pl_donvi.Controls.Add(this.label7);
            this.pl_donvi.Controls.Add(this.label6);
            this.pl_donvi.Controls.Add(this.label5);
            this.pl_donvi.Controls.Add(this.label4);
            this.pl_donvi.Controls.Add(this.label9);
            this.pl_donvi.Controls.Add(this.label10);
            this.pl_donvi.Controls.Add(this.label3);
            this.pl_donvi.Controls.Add(this.label2);
            this.pl_donvi.Dock = System.Windows.Forms.DockStyle.Top;
            this.pl_donvi.Enabled = false;
            this.pl_donvi.Location = new System.Drawing.Point(4, 128);
            this.pl_donvi.Margin = new System.Windows.Forms.Padding(4);
            this.pl_donvi.Name = "pl_donvi";
            this.pl_donvi.Size = new System.Drawing.Size(456, 411);
            this.pl_donvi.TabIndex = 5;
            // 
            // dtp_den_ngay
            // 
            this.dtp_den_ngay.CustomFormat = " ";
            this.dtp_den_ngay.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.dtp_den_ngay.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtp_den_ngay.Location = new System.Drawing.Point(112, 180);
            this.dtp_den_ngay.Margin = new System.Windows.Forms.Padding(4);
            this.dtp_den_ngay.Name = "dtp_den_ngay";
            this.dtp_den_ngay.Size = new System.Drawing.Size(311, 23);
            this.dtp_den_ngay.TabIndex = 20;
            this.dtp_den_ngay.ValueChanged += new System.EventHandler(this.dtp_den_ngay_ValueChanged);
            this.dtp_den_ngay.KeyDown += new System.Windows.Forms.KeyEventHandler(this.dtp_den_ngay_KeyDown);
            // 
            // dtp_tu_ngay
            // 
            this.dtp_tu_ngay.CustomFormat = " ";
            this.dtp_tu_ngay.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.dtp_tu_ngay.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtp_tu_ngay.Location = new System.Drawing.Point(112, 144);
            this.dtp_tu_ngay.Margin = new System.Windows.Forms.Padding(4);
            this.dtp_tu_ngay.Name = "dtp_tu_ngay";
            this.dtp_tu_ngay.Size = new System.Drawing.Size(311, 23);
            this.dtp_tu_ngay.TabIndex = 20;
            this.dtp_tu_ngay.ValueChanged += new System.EventHandler(this.dtp_tu_ngay_ValueChanged);
            this.dtp_tu_ngay.KeyDown += new System.Windows.Forms.KeyEventHandler(this.dtp_tu_ngay_KeyDown);
            // 
            // cbo_chuc_vu
            // 
            this.cbo_chuc_vu.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Append;
            this.cbo_chuc_vu.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.cbo_chuc_vu.FormattingEnabled = true;
            this.cbo_chuc_vu.Location = new System.Drawing.Point(112, 111);
            this.cbo_chuc_vu.Margin = new System.Windows.Forms.Padding(4);
            this.cbo_chuc_vu.Name = "cbo_chuc_vu";
            this.cbo_chuc_vu.Size = new System.Drawing.Size(285, 24);
            this.cbo_chuc_vu.TabIndex = 4;
            // 
            // cbo_phongban
            // 
            this.cbo_phongban.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Append;
            this.cbo_phongban.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.cbo_phongban.FormattingEnabled = true;
            this.cbo_phongban.Location = new System.Drawing.Point(112, 78);
            this.cbo_phongban.Margin = new System.Windows.Forms.Padding(4);
            this.cbo_phongban.Name = "cbo_phongban";
            this.cbo_phongban.Size = new System.Drawing.Size(311, 24);
            this.cbo_phongban.TabIndex = 4;
            this.cbo_phongban.SelectedValueChanged += new System.EventHandler(this.cbo_phongban_SelectedValueChanged);
            // 
            // cbo_khuvuc
            // 
            this.cbo_khuvuc.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Append;
            this.cbo_khuvuc.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.cbo_khuvuc.FormattingEnabled = true;
            this.cbo_khuvuc.Location = new System.Drawing.Point(112, 46);
            this.cbo_khuvuc.Margin = new System.Windows.Forms.Padding(4);
            this.cbo_khuvuc.Name = "cbo_khuvuc";
            this.cbo_khuvuc.Size = new System.Drawing.Size(311, 24);
            this.cbo_khuvuc.TabIndex = 4;
            this.cbo_khuvuc.SelectedValueChanged += new System.EventHandler(this.cbo_khuvuc_SelectedValueChanged);
            // 
            // cbo_donvi
            // 
            this.cbo_donvi.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Append;
            this.cbo_donvi.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.cbo_donvi.FormattingEnabled = true;
            this.cbo_donvi.Location = new System.Drawing.Point(112, 14);
            this.cbo_donvi.Margin = new System.Windows.Forms.Padding(4);
            this.cbo_donvi.Name = "cbo_donvi";
            this.cbo_donvi.Size = new System.Drawing.Size(311, 24);
            this.cbo_donvi.TabIndex = 4;
            this.cbo_donvi.SelectedValueChanged += new System.EventHandler(this.cbo_donvi_SelectedValueChanged);
            // 
            // chk_hieu_luc
            // 
            this.chk_hieu_luc.AutoSize = true;
            this.chk_hieu_luc.Location = new System.Drawing.Point(112, 326);
            this.chk_hieu_luc.Margin = new System.Windows.Forms.Padding(4);
            this.chk_hieu_luc.Name = "chk_hieu_luc";
            this.chk_hieu_luc.Size = new System.Drawing.Size(114, 21);
            this.chk_hieu_luc.TabIndex = 3;
            this.chk_hieu_luc.Text = "Đang hiệu lục";
            this.chk_hieu_luc.UseVisualStyleBackColor = true;
            // 
            // txt_mo_ta
            // 
            this.txt_mo_ta.Location = new System.Drawing.Point(112, 248);
            this.txt_mo_ta.Margin = new System.Windows.Forms.Padding(4);
            this.txt_mo_ta.Multiline = true;
            this.txt_mo_ta.Name = "txt_mo_ta";
            this.txt_mo_ta.Size = new System.Drawing.Size(311, 70);
            this.txt_mo_ta.TabIndex = 2;
            // 
            // txt_so_quyet_dinh
            // 
            this.txt_so_quyet_dinh.Location = new System.Drawing.Point(112, 216);
            this.txt_so_quyet_dinh.Margin = new System.Windows.Forms.Padding(4);
            this.txt_so_quyet_dinh.Name = "txt_so_quyet_dinh";
            this.txt_so_quyet_dinh.Size = new System.Drawing.Size(311, 23);
            this.txt_so_quyet_dinh.TabIndex = 2;
            // 
            // btn_add_chuc_vu
            // 
            this.btn_add_chuc_vu.Enabled = false;
            this.btn_add_chuc_vu.Location = new System.Drawing.Point(397, 110);
            this.btn_add_chuc_vu.Margin = new System.Windows.Forms.Padding(4);
            this.btn_add_chuc_vu.Name = "btn_add_chuc_vu";
            this.btn_add_chuc_vu.Size = new System.Drawing.Size(26, 26);
            this.btn_add_chuc_vu.TabIndex = 0;
            this.btn_add_chuc_vu.Text = "+";
            this.btn_add_chuc_vu.UseVisualStyleBackColor = true;
            // 
            // btn_huy
            // 
            this.btn_huy.Image = global::TENTAC_HRM.Properties.Resources.cancel;
            this.btn_huy.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btn_huy.Location = new System.Drawing.Point(334, 353);
            this.btn_huy.Margin = new System.Windows.Forms.Padding(4);
            this.btn_huy.Name = "btn_huy";
            this.btn_huy.Size = new System.Drawing.Size(90, 28);
            this.btn_huy.TabIndex = 0;
            this.btn_huy.Text = "Hủy";
            this.btn_huy.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btn_huy.UseVisualStyleBackColor = true;
            this.btn_huy.Click += new System.EventHandler(this.btn_huy_Click);
            // 
            // btn_luu
            // 
            this.btn_luu.AutoSize = true;
            this.btn_luu.Image = global::TENTAC_HRM.Properties.Resources.diskette;
            this.btn_luu.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btn_luu.Location = new System.Drawing.Point(215, 353);
            this.btn_luu.Margin = new System.Windows.Forms.Padding(4);
            this.btn_luu.Name = "btn_luu";
            this.btn_luu.Size = new System.Drawing.Size(111, 28);
            this.btn_luu.TabIndex = 0;
            this.btn_luu.Text = "Lưu";
            this.btn_luu.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btn_luu.UseVisualStyleBackColor = true;
            this.btn_luu.Click += new System.EventHandler(this.btn_luu_Click);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(5, 251);
            this.label7.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(43, 17);
            this.label7.TabIndex = 1;
            this.label7.Text = "Mổ tả";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(5, 219);
            this.label6.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(95, 17);
            this.label6.TabIndex = 1;
            this.label6.Text = "Số quyết định";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(5, 189);
            this.label5.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(69, 17);
            this.label5.TabIndex = 1;
            this.label5.Text = "Đến ngày";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(5, 153);
            this.label4.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(60, 17);
            this.label4.TabIndex = 1;
            this.label4.Text = "Từ ngày";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(5, 83);
            this.label9.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(77, 17);
            this.label9.TabIndex = 1;
            this.label9.Text = "Phòng ban";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(5, 50);
            this.label10.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(59, 17);
            this.label10.TabIndex = 1;
            this.label10.Text = "Khu vục";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(5, 115);
            this.label3.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(59, 17);
            this.label3.TabIndex = 1;
            this.label3.Text = "Chức vụ";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(5, 18);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(56, 17);
            this.label2.TabIndex = 1;
            this.label2.Text = "Công ty";
            // 
            // linkLabel2
            // 
            this.linkLabel2.ActiveLinkColor = System.Drawing.Color.Black;
            this.linkLabel2.BackColor = System.Drawing.SystemColors.Menu;
            this.linkLabel2.Dock = System.Windows.Forms.DockStyle.Top;
            this.linkLabel2.LinkBehavior = System.Windows.Forms.LinkBehavior.NeverUnderline;
            this.linkLabel2.LinkColor = System.Drawing.Color.Black;
            this.linkLabel2.Location = new System.Drawing.Point(4, 101);
            this.linkLabel2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.linkLabel2.Name = "linkLabel2";
            this.linkLabel2.Size = new System.Drawing.Size(456, 27);
            this.linkLabel2.TabIndex = 4;
            this.linkLabel2.TabStop = true;
            this.linkLabel2.Text = "Thông tin";
            this.linkLabel2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.cbo_nhanvien);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Enabled = false;
            this.panel1.Location = new System.Drawing.Point(4, 47);
            this.panel1.Margin = new System.Windows.Forms.Padding(4);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(456, 54);
            this.panel1.TabIndex = 3;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(5, 18);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(72, 17);
            this.label1.TabIndex = 1;
            this.label1.Text = "Nhân viên";
            // 
            // cbo_nhanvien
            // 
            this.cbo_nhanvien.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Append;
            this.cbo_nhanvien.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.cbo_nhanvien.FormattingEnabled = true;
            this.cbo_nhanvien.Location = new System.Drawing.Point(112, 15);
            this.cbo_nhanvien.Margin = new System.Windows.Forms.Padding(4);
            this.cbo_nhanvien.Name = "cbo_nhanvien";
            this.cbo_nhanvien.Size = new System.Drawing.Size(311, 24);
            this.cbo_nhanvien.TabIndex = 4;
            // 
            // linkLabel1
            // 
            this.linkLabel1.ActiveLinkColor = System.Drawing.Color.Black;
            this.linkLabel1.BackColor = System.Drawing.SystemColors.Menu;
            this.linkLabel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.linkLabel1.LinkBehavior = System.Windows.Forms.LinkBehavior.NeverUnderline;
            this.linkLabel1.LinkColor = System.Drawing.Color.Black;
            this.linkLabel1.Location = new System.Drawing.Point(4, 20);
            this.linkLabel1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.linkLabel1.Name = "linkLabel1";
            this.linkLabel1.Size = new System.Drawing.Size(456, 27);
            this.linkLabel1.TabIndex = 0;
            this.linkLabel1.TabStop = true;
            this.linkLabel1.Text = "Nhân viên";
            this.linkLabel1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // pl_information
            // 
            this.pl_information.Controls.Add(this.groupBox1);
            this.pl_information.Dock = System.Windows.Forms.DockStyle.Right;
            this.pl_information.Location = new System.Drawing.Point(754, 25);
            this.pl_information.MaximumSize = new System.Drawing.Size(464, 606);
            this.pl_information.MinimumSize = new System.Drawing.Size(0, 606);
            this.pl_information.Name = "pl_information";
            this.pl_information.Size = new System.Drawing.Size(464, 606);
            this.pl_information.TabIndex = 4;
            // 
            // timer1
            // 
            this.timer1.Interval = 15;
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // toolStrip1
            // 
            this.toolStrip1.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.btn_add,
            this.btn_delete,
            this.btn_close});
            this.toolStrip1.Location = new System.Drawing.Point(0, 0);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(1218, 25);
            this.toolStrip1.TabIndex = 5;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // btn_add
            // 
            this.btn_add.Image = global::TENTAC_HRM.Properties.Resources.add_file;
            this.btn_add.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btn_add.Name = "btn_add";
            this.btn_add.Size = new System.Drawing.Size(57, 22);
            this.btn_add.Text = "Thêm";
            this.btn_add.Click += new System.EventHandler(this.btn_add_Click);
            // 
            // btn_delete
            // 
            this.btn_delete.Image = global::TENTAC_HRM.Properties.Resources.bin;
            this.btn_delete.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btn_delete.Name = "btn_delete";
            this.btn_delete.Size = new System.Drawing.Size(47, 22);
            this.btn_delete.Text = "Xóa";
            this.btn_delete.Click += new System.EventHandler(this.btn_delete_Click);
            // 
            // btn_close
            // 
            this.btn_close.Image = global::TENTAC_HRM.Properties.Resources.clear;
            this.btn_close.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btn_close.Name = "btn_close";
            this.btn_close.Size = new System.Drawing.Size(56, 22);
            this.btn_close.Text = "Đóng";
            this.btn_close.Click += new System.EventHandler(this.btn_close_Click);
            // 
            // dataGridViewImageColumn1
            // 
            this.dataGridViewImageColumn1.HeaderText = "";
            this.dataGridViewImageColumn1.Image = global::TENTAC_HRM.Properties.Resources.pen;
            this.dataGridViewImageColumn1.Name = "dataGridViewImageColumn1";
            this.dataGridViewImageColumn1.Width = 30;
            // 
            // frm_department
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.ClientSize = new System.Drawing.Size(1218, 645);
            this.Controls.Add(this.dgv_nhanvien_phongban);
            this.Controls.Add(this.pl_information);
            this.Controls.Add(this.toolStrip1);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.KeyPreview = true;
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "frm_department";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Nhận viên - đơn vị";
            this.Load += new System.EventHandler(this.frm_department_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.frm_department_KeyDown);
            ((System.ComponentModel.ISupportInitialize)(this.dgv_nhanvien_phongban)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.pl_donvi.ResumeLayout(false);
            this.pl_donvi.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.pl_information.ResumeLayout(false);
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.DataGridView dgv_nhanvien_phongban;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.LinkLabel linkLabel1;
        private System.Windows.Forms.Panel pl_donvi;
        private System.Windows.Forms.CheckBox chk_hieu_luc;
        private System.Windows.Forms.TextBox txt_mo_ta;
        private System.Windows.Forms.TextBox txt_so_quyet_dinh;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.LinkLabel linkLabel2;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btn_luu;
        private System.Windows.Forms.ComboBox cbo_chuc_vu;
        private System.Windows.Forms.ComboBox cbo_donvi;
        private System.Windows.Forms.Button btn_add_chuc_vu;
        private System.Windows.Forms.DateTimePicker dtp_den_ngay;
        private System.Windows.Forms.DateTimePicker dtp_tu_ngay;
        private System.Windows.Forms.ComboBox cbo_phongban;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Button btn_huy;
        private System.Windows.Forms.ComboBox cbo_nhanvien;
        private System.Windows.Forms.Panel pl_information;
        private System.Windows.Forms.ComboBox cbo_khuvuc;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.DataGridViewImageColumn edit_column;
        private System.Windows.Forms.DataGridViewTextBoxColumn id_cong_tac;
        private System.Windows.Forms.DataGridViewTextBoxColumn cong_ty;
        private System.Windows.Forms.DataGridViewTextBoxColumn khu_vuc;
        private System.Windows.Forms.DataGridViewTextBoxColumn phong_ban;
        private System.Windows.Forms.DataGridViewTextBoxColumn chuc_vu;
        private System.Windows.Forms.DataGridViewTextBoxColumn tu_ngay;
        private System.Windows.Forms.DataGridViewTextBoxColumn den_ngay;
        private System.Windows.Forms.DataGridViewCheckBoxColumn is_active;
        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripButton btn_add;
        private System.Windows.Forms.ToolStripButton btn_delete;
        private System.Windows.Forms.ToolStripButton btn_close;
        private System.Windows.Forms.DataGridViewImageColumn dataGridViewImageColumn1;
    }
}