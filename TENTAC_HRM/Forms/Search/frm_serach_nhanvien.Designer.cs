namespace TENTAC_HRM.Forms.Search
{
    partial class frm_serach_nhanvien
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
            this.panel1 = new System.Windows.Forms.Panel();
            this.pl_chitiet = new System.Windows.Forms.Panel();
            this.btn_chitiet = new System.Windows.Forms.Button();
            this.label8 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.label12 = new System.Windows.Forms.Label();
            this.cbo_quoc_tich = new System.Windows.Forms.ComboBox();
            this.cbo_dan_toc = new System.Windows.Forms.ComboBox();
            this.cbo_hon_nhan = new System.Windows.Forms.ComboBox();
            this.label14 = new System.Windows.Forms.Label();
            this.cbo_gioi_tinh = new System.Windows.Forms.ComboBox();
            this.pl_coban = new System.Windows.Forms.Panel();
            this.label1 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.btn_coban = new System.Windows.Forms.Button();
            this.cbo_loaihopdong = new System.Windows.Forms.ComboBox();
            this.txt_search = new System.Windows.Forms.TextBox();
            this.cbo_chucvu = new System.Windows.Forms.ComboBox();
            this.cbo_trangthai = new System.Windows.Forms.ComboBox();
            this.dgv_nhanvien = new System.Windows.Forms.DataGridView();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.panel2 = new System.Windows.Forms.Panel();
            this.btn_close = new System.Windows.Forms.Button();
            this.btn_chon = new System.Windows.Forms.Button();
            this.id_nhan_vien = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ma_nhan_vien = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ho_ten = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ngay_sinh = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.gioi_tinh = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ten_chuc_vu = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ten_phong_ban = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.email = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dien_thoai = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cccd = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.panel1.SuspendLayout();
            this.pl_chitiet.SuspendLayout();
            this.pl_coban.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgv_nhanvien)).BeginInit();
            this.panel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.pl_chitiet);
            this.panel1.Controls.Add(this.pl_coban);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Left;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Margin = new System.Windows.Forms.Padding(4);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(268, 635);
            this.panel1.TabIndex = 0;
            // 
            // pl_chitiet
            // 
            this.pl_chitiet.Controls.Add(this.btn_chitiet);
            this.pl_chitiet.Controls.Add(this.label8);
            this.pl_chitiet.Controls.Add(this.label10);
            this.pl_chitiet.Controls.Add(this.label12);
            this.pl_chitiet.Controls.Add(this.cbo_quoc_tich);
            this.pl_chitiet.Controls.Add(this.cbo_dan_toc);
            this.pl_chitiet.Controls.Add(this.cbo_hon_nhan);
            this.pl_chitiet.Controls.Add(this.label14);
            this.pl_chitiet.Controls.Add(this.cbo_gioi_tinh);
            this.pl_chitiet.Dock = System.Windows.Forms.DockStyle.Top;
            this.pl_chitiet.Location = new System.Drawing.Point(0, 242);
            this.pl_chitiet.MaximumSize = new System.Drawing.Size(268, 249);
            this.pl_chitiet.MinimumSize = new System.Drawing.Size(268, 30);
            this.pl_chitiet.Name = "pl_chitiet";
            this.pl_chitiet.Size = new System.Drawing.Size(268, 30);
            this.pl_chitiet.TabIndex = 5;
            // 
            // btn_chitiet
            // 
            this.btn_chitiet.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(192)))), ((int)(((byte)(192)))));
            this.btn_chitiet.Dock = System.Windows.Forms.DockStyle.Top;
            this.btn_chitiet.FlatAppearance.BorderColor = System.Drawing.SystemColors.Window;
            this.btn_chitiet.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_chitiet.Image = global::TENTAC_HRM.Properties.Resources.up_arrow;
            this.btn_chitiet.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btn_chitiet.Location = new System.Drawing.Point(0, 0);
            this.btn_chitiet.Name = "btn_chitiet";
            this.btn_chitiet.Size = new System.Drawing.Size(268, 30);
            this.btn_chitiet.TabIndex = 0;
            this.btn_chitiet.Text = "Chi tiết";
            this.btn_chitiet.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btn_chitiet.UseVisualStyleBackColor = false;
            this.btn_chitiet.Click += new System.EventHandler(this.btn_chitiet_Click);
            // 
            // label8
            // 
            this.label8.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(16, -69);
            this.label8.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(68, 17);
            this.label8.TabIndex = 0;
            this.label8.Text = "Quốc tịch";
            // 
            // label10
            // 
            this.label10.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(16, -23);
            this.label10.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(57, 17);
            this.label10.TabIndex = 0;
            this.label10.Text = "Dân tộc";
            // 
            // label12
            // 
            this.label12.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(16, 25);
            this.label12.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(60, 17);
            this.label12.TabIndex = 0;
            this.label12.Text = "Giới tính";
            // 
            // cbo_quoc_tich
            // 
            this.cbo_quoc_tich.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.cbo_quoc_tich.FormattingEnabled = true;
            this.cbo_quoc_tich.Location = new System.Drawing.Point(19, -50);
            this.cbo_quoc_tich.Name = "cbo_quoc_tich";
            this.cbo_quoc_tich.Size = new System.Drawing.Size(232, 24);
            this.cbo_quoc_tich.TabIndex = 2;
            this.cbo_quoc_tich.SelectionChangeCommitted += new System.EventHandler(this.cbo_quoc_tich_SelectionChangeCommitted);
            // 
            // cbo_dan_toc
            // 
            this.cbo_dan_toc.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.cbo_dan_toc.FormattingEnabled = true;
            this.cbo_dan_toc.Location = new System.Drawing.Point(19, -3);
            this.cbo_dan_toc.Name = "cbo_dan_toc";
            this.cbo_dan_toc.Size = new System.Drawing.Size(232, 24);
            this.cbo_dan_toc.TabIndex = 2;
            this.cbo_dan_toc.SelectionChangeCommitted += new System.EventHandler(this.cbo_dan_toc_SelectionChangeCommitted);
            // 
            // cbo_hon_nhan
            // 
            this.cbo_hon_nhan.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.cbo_hon_nhan.FormattingEnabled = true;
            this.cbo_hon_nhan.Location = new System.Drawing.Point(19, 95);
            this.cbo_hon_nhan.Name = "cbo_hon_nhan";
            this.cbo_hon_nhan.Size = new System.Drawing.Size(232, 24);
            this.cbo_hon_nhan.TabIndex = 2;
            this.cbo_hon_nhan.SelectionChangeCommitted += new System.EventHandler(this.cbo_hon_nhan_SelectionChangeCommitted);
            // 
            // label14
            // 
            this.label14.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.label14.AutoSize = true;
            this.label14.Location = new System.Drawing.Point(16, 75);
            this.label14.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(70, 17);
            this.label14.TabIndex = 0;
            this.label14.Text = "Hôn nhân";
            // 
            // cbo_gioi_tinh
            // 
            this.cbo_gioi_tinh.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.cbo_gioi_tinh.FormattingEnabled = true;
            this.cbo_gioi_tinh.Location = new System.Drawing.Point(19, 45);
            this.cbo_gioi_tinh.Name = "cbo_gioi_tinh";
            this.cbo_gioi_tinh.Size = new System.Drawing.Size(232, 24);
            this.cbo_gioi_tinh.TabIndex = 2;
            this.cbo_gioi_tinh.SelectionChangeCommitted += new System.EventHandler(this.cbo_gioi_tinh_SelectionChangeCommitted);
            // 
            // pl_coban
            // 
            this.pl_coban.Controls.Add(this.label1);
            this.pl_coban.Controls.Add(this.label7);
            this.pl_coban.Controls.Add(this.label3);
            this.pl_coban.Controls.Add(this.label5);
            this.pl_coban.Controls.Add(this.btn_coban);
            this.pl_coban.Controls.Add(this.cbo_loaihopdong);
            this.pl_coban.Controls.Add(this.txt_search);
            this.pl_coban.Controls.Add(this.cbo_chucvu);
            this.pl_coban.Controls.Add(this.cbo_trangthai);
            this.pl_coban.Dock = System.Windows.Forms.DockStyle.Top;
            this.pl_coban.Location = new System.Drawing.Point(0, 0);
            this.pl_coban.MaximumSize = new System.Drawing.Size(268, 242);
            this.pl_coban.MinimumSize = new System.Drawing.Size(268, 30);
            this.pl_coban.Name = "pl_coban";
            this.pl_coban.Size = new System.Drawing.Size(268, 242);
            this.pl_coban.TabIndex = 3;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(16, 40);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(60, 17);
            this.label1.TabIndex = 3;
            this.label1.Text = "Từ khóa";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(16, 186);
            this.label7.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(99, 17);
            this.label7.TabIndex = 4;
            this.label7.Text = "Loại hợp đồng";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(16, 89);
            this.label3.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(73, 17);
            this.label3.TabIndex = 6;
            this.label3.Text = "Trạng thái";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(16, 137);
            this.label5.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(59, 17);
            this.label5.TabIndex = 7;
            this.label5.Text = "Chức vụ";
            // 
            // btn_coban
            // 
            this.btn_coban.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(192)))), ((int)(((byte)(192)))));
            this.btn_coban.Dock = System.Windows.Forms.DockStyle.Top;
            this.btn_coban.FlatAppearance.BorderColor = System.Drawing.SystemColors.Window;
            this.btn_coban.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_coban.Image = global::TENTAC_HRM.Properties.Resources.up_arrow;
            this.btn_coban.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btn_coban.Location = new System.Drawing.Point(0, 0);
            this.btn_coban.Name = "btn_coban";
            this.btn_coban.Size = new System.Drawing.Size(268, 30);
            this.btn_coban.TabIndex = 0;
            this.btn_coban.Text = "Cơ bản";
            this.btn_coban.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btn_coban.UseVisualStyleBackColor = false;
            this.btn_coban.Click += new System.EventHandler(this.btn_coban_Click);
            // 
            // cbo_loaihopdong
            // 
            this.cbo_loaihopdong.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.cbo_loaihopdong.FormattingEnabled = true;
            this.cbo_loaihopdong.Location = new System.Drawing.Point(19, 206);
            this.cbo_loaihopdong.Name = "cbo_loaihopdong";
            this.cbo_loaihopdong.Size = new System.Drawing.Size(232, 24);
            this.cbo_loaihopdong.TabIndex = 10;
            this.cbo_loaihopdong.SelectionChangeCommitted += new System.EventHandler(this.cbo_loaihopdong_SelectionChangeCommitted);
            // 
            // txt_search
            // 
            this.txt_search.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txt_search.Location = new System.Drawing.Point(19, 60);
            this.txt_search.Name = "txt_search";
            this.txt_search.Size = new System.Drawing.Size(232, 23);
            this.txt_search.TabIndex = 9;
            this.txt_search.TextChanged += new System.EventHandler(this.txt_search_TextChanged);
            // 
            // cbo_chucvu
            // 
            this.cbo_chucvu.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.cbo_chucvu.FormattingEnabled = true;
            this.cbo_chucvu.Location = new System.Drawing.Point(19, 157);
            this.cbo_chucvu.Name = "cbo_chucvu";
            this.cbo_chucvu.Size = new System.Drawing.Size(232, 24);
            this.cbo_chucvu.TabIndex = 11;
            this.cbo_chucvu.SelectionChangeCommitted += new System.EventHandler(this.cbo_chucvu_SelectionChangeCommitted);
            // 
            // cbo_trangthai
            // 
            this.cbo_trangthai.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.cbo_trangthai.FormattingEnabled = true;
            this.cbo_trangthai.Location = new System.Drawing.Point(19, 109);
            this.cbo_trangthai.Name = "cbo_trangthai";
            this.cbo_trangthai.Size = new System.Drawing.Size(232, 24);
            this.cbo_trangthai.TabIndex = 14;
            this.cbo_trangthai.SelectionChangeCommitted += new System.EventHandler(this.cbo_trangthai_SelectionChangeCommitted);
            // 
            // dgv_nhanvien
            // 
            this.dgv_nhanvien.AllowUserToAddRows = false;
            this.dgv_nhanvien.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
            this.dgv_nhanvien.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgv_nhanvien.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.id_nhan_vien,
            this.ma_nhan_vien,
            this.ho_ten,
            this.ngay_sinh,
            this.gioi_tinh,
            this.ten_chuc_vu,
            this.ten_phong_ban,
            this.email,
            this.dien_thoai,
            this.cccd});
            this.dgv_nhanvien.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgv_nhanvien.Location = new System.Drawing.Point(268, 0);
            this.dgv_nhanvien.Margin = new System.Windows.Forms.Padding(4);
            this.dgv_nhanvien.Name = "dgv_nhanvien";
            this.dgv_nhanvien.Size = new System.Drawing.Size(904, 600);
            this.dgv_nhanvien.TabIndex = 1;
            this.dgv_nhanvien.CellMouseDoubleClick += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.dgv_nhanvien_CellMouseDoubleClick);
            // 
            // timer1
            // 
            this.timer1.Interval = 15;
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.btn_close);
            this.panel2.Controls.Add(this.btn_chon);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel2.Location = new System.Drawing.Point(268, 600);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(904, 35);
            this.panel2.TabIndex = 2;
            // 
            // btn_close
            // 
            this.btn_close.Dock = System.Windows.Forms.DockStyle.Left;
            this.btn_close.Image = global::TENTAC_HRM.Properties.Resources.on_off_button;
            this.btn_close.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btn_close.Location = new System.Drawing.Point(87, 0);
            this.btn_close.Name = "btn_close";
            this.btn_close.Size = new System.Drawing.Size(87, 35);
            this.btn_close.TabIndex = 1;
            this.btn_close.Text = "Đóng";
            this.btn_close.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btn_close.UseVisualStyleBackColor = true;
            this.btn_close.Click += new System.EventHandler(this.btn_close_Click);
            // 
            // btn_chon
            // 
            this.btn_chon.Dock = System.Windows.Forms.DockStyle.Left;
            this.btn_chon.Image = global::TENTAC_HRM.Properties.Resources.check;
            this.btn_chon.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btn_chon.Location = new System.Drawing.Point(0, 0);
            this.btn_chon.Name = "btn_chon";
            this.btn_chon.Size = new System.Drawing.Size(87, 35);
            this.btn_chon.TabIndex = 0;
            this.btn_chon.Text = "Chọn";
            this.btn_chon.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btn_chon.UseVisualStyleBackColor = true;
            this.btn_chon.Click += new System.EventHandler(this.btn_chon_Click);
            // 
            // id_nhan_vien
            // 
            this.id_nhan_vien.DataPropertyName = "id_nhan_vien";
            this.id_nhan_vien.Frozen = true;
            this.id_nhan_vien.HeaderText = "id_nhan_vien";
            this.id_nhan_vien.Name = "id_nhan_vien";
            this.id_nhan_vien.Visible = false;
            this.id_nhan_vien.Width = 118;
            // 
            // ma_nhan_vien
            // 
            this.ma_nhan_vien.DataPropertyName = "ma_nhan_vien";
            this.ma_nhan_vien.Frozen = true;
            this.ma_nhan_vien.HeaderText = "Mã nhân viên";
            this.ma_nhan_vien.Name = "ma_nhan_vien";
            this.ma_nhan_vien.Width = 118;
            // 
            // ho_ten
            // 
            this.ho_ten.DataPropertyName = "ho_ten";
            this.ho_ten.Frozen = true;
            this.ho_ten.HeaderText = "Họ tên";
            this.ho_ten.Name = "ho_ten";
            this.ho_ten.Width = 75;
            // 
            // ngay_sinh
            // 
            this.ngay_sinh.DataPropertyName = "ngay_sinh";
            this.ngay_sinh.HeaderText = "Ngày sinh";
            this.ngay_sinh.Name = "ngay_sinh";
            this.ngay_sinh.Width = 96;
            // 
            // gioi_tinh
            // 
            this.gioi_tinh.DataPropertyName = "gioi_tinh";
            this.gioi_tinh.HeaderText = "Giới tính";
            this.gioi_tinh.Name = "gioi_tinh";
            this.gioi_tinh.Width = 85;
            // 
            // ten_chuc_vu
            // 
            this.ten_chuc_vu.DataPropertyName = "ten_chuc_vu";
            this.ten_chuc_vu.HeaderText = "Chức vụ";
            this.ten_chuc_vu.Name = "ten_chuc_vu";
            this.ten_chuc_vu.Width = 84;
            // 
            // ten_phong_ban
            // 
            this.ten_phong_ban.DataPropertyName = "ten_phong_ban";
            this.ten_phong_ban.HeaderText = "Phòng ban";
            this.ten_phong_ban.Name = "ten_phong_ban";
            this.ten_phong_ban.Width = 102;
            // 
            // email
            // 
            this.email.DataPropertyName = "email";
            this.email.HeaderText = "Email";
            this.email.Name = "email";
            this.email.Width = 67;
            // 
            // dien_thoai
            // 
            this.dien_thoai.DataPropertyName = "dien_thoai";
            this.dien_thoai.HeaderText = "Điện thoại";
            this.dien_thoai.Name = "dien_thoai";
            this.dien_thoai.Width = 97;
            // 
            // cccd
            // 
            this.cccd.DataPropertyName = "cccd";
            this.cccd.HeaderText = "CCCD";
            this.cccd.Name = "cccd";
            this.cccd.Width = 70;
            // 
            // frm_serach_nhanvien
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1172, 635);
            this.Controls.Add(this.dgv_nhanvien);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.Margin = new System.Windows.Forms.Padding(4);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frm_serach_nhanvien";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Tìm kiếm";
            this.Load += new System.EventHandler(this.frm_serach_nhanvien_Load);
            this.panel1.ResumeLayout(false);
            this.pl_chitiet.ResumeLayout(false);
            this.pl_chitiet.PerformLayout();
            this.pl_coban.ResumeLayout(false);
            this.pl_coban.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgv_nhanvien)).EndInit();
            this.panel2.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.DataGridView dgv_nhanvien;
        private System.Windows.Forms.Panel pl_coban;
        private System.Windows.Forms.Button btn_coban;
        private System.Windows.Forms.Panel pl_chitiet;
        private System.Windows.Forms.Button btn_chitiet;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.ComboBox cbo_dan_toc;
        private System.Windows.Forms.ComboBox cbo_hon_nhan;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.ComboBox cbo_gioi_tinh;
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.ComboBox cbo_loaihopdong;
        private System.Windows.Forms.TextBox txt_search;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.ComboBox cbo_chucvu;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.ComboBox cbo_trangthai;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Button btn_close;
        private System.Windows.Forms.Button btn_chon;
        private System.Windows.Forms.ComboBox cbo_quoc_tich;
        private System.Windows.Forms.DataGridViewTextBoxColumn id_nhan_vien;
        private System.Windows.Forms.DataGridViewTextBoxColumn ma_nhan_vien;
        private System.Windows.Forms.DataGridViewTextBoxColumn ho_ten;
        private System.Windows.Forms.DataGridViewTextBoxColumn ngay_sinh;
        private System.Windows.Forms.DataGridViewTextBoxColumn gioi_tinh;
        private System.Windows.Forms.DataGridViewTextBoxColumn ten_chuc_vu;
        private System.Windows.Forms.DataGridViewTextBoxColumn ten_phong_ban;
        private System.Windows.Forms.DataGridViewTextBoxColumn email;
        private System.Windows.Forms.DataGridViewTextBoxColumn dien_thoai;
        private System.Windows.Forms.DataGridViewTextBoxColumn cccd;
    }
}