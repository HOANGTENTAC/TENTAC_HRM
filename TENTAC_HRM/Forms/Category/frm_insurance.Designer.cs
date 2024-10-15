namespace TENTAC_HRM.Forms.Category
{
    partial class frm_insurance
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
            this.pl_baohiem = new System.Windows.Forms.Panel();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.panel3 = new System.Windows.Forms.Panel();
            this.cbo_loaibh = new System.Windows.Forms.ComboBox();
            this.btn_luu = new System.Windows.Forms.Button();
            this.btn_huy = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.chk_active = new System.Windows.Forms.CheckBox();
            this.label3 = new System.Windows.Forms.Label();
            this.dtp_denngay = new System.Windows.Forms.DateTimePicker();
            this.label6 = new System.Windows.Forms.Label();
            this.dtp_tungay = new System.Windows.Forms.DateTimePicker();
            this.label7 = new System.Windows.Forms.Label();
            this.txt_ghichu = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.txt_noidangky = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.txt_sothe = new System.Windows.Forms.TextBox();
            this.cbo_tinh = new System.Windows.Forms.ComboBox();
            this.label5 = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.panel2 = new System.Windows.Forms.Panel();
            this.cbo_nhanvien = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.dgv_baohiem = new System.Windows.Forms.DataGridView();
            this.id_bao_hiem = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.edit_column = new System.Windows.Forms.DataGridViewImageColumn();
            this.type_name = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.so_the = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.tu_ngay = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.den_ngay = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ten_dia_chi = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.is_active = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.dataGridViewImageColumn1 = new System.Windows.Forms.DataGridViewImageColumn();
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.btn_add = new System.Windows.Forms.ToolStripButton();
            this.btn_delete = new System.Windows.Forms.ToolStripButton();
            this.btn_close = new System.Windows.Forms.ToolStripButton();
            this.pl_baohiem.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.panel3.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgv_baohiem)).BeginInit();
            this.toolStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // pl_baohiem
            // 
            this.pl_baohiem.Controls.Add(this.groupBox2);
            this.pl_baohiem.Controls.Add(this.groupBox1);
            this.pl_baohiem.Dock = System.Windows.Forms.DockStyle.Right;
            this.pl_baohiem.Enabled = false;
            this.pl_baohiem.Location = new System.Drawing.Point(738, 25);
            this.pl_baohiem.Margin = new System.Windows.Forms.Padding(4);
            this.pl_baohiem.Name = "pl_baohiem";
            this.pl_baohiem.Size = new System.Drawing.Size(344, 481);
            this.pl_baohiem.TabIndex = 1;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.panel3);
            this.groupBox2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox2.Location = new System.Drawing.Point(0, 62);
            this.groupBox2.Margin = new System.Windows.Forms.Padding(4);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Padding = new System.Windows.Forms.Padding(4);
            this.groupBox2.Size = new System.Drawing.Size(344, 419);
            this.groupBox2.TabIndex = 1;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Thông tin";
            // 
            // panel3
            // 
            this.panel3.Controls.Add(this.cbo_loaibh);
            this.panel3.Controls.Add(this.btn_luu);
            this.panel3.Controls.Add(this.btn_huy);
            this.panel3.Controls.Add(this.label2);
            this.panel3.Controls.Add(this.chk_active);
            this.panel3.Controls.Add(this.label3);
            this.panel3.Controls.Add(this.dtp_denngay);
            this.panel3.Controls.Add(this.label6);
            this.panel3.Controls.Add(this.dtp_tungay);
            this.panel3.Controls.Add(this.label7);
            this.panel3.Controls.Add(this.txt_ghichu);
            this.panel3.Controls.Add(this.label4);
            this.panel3.Controls.Add(this.txt_noidangky);
            this.panel3.Controls.Add(this.label8);
            this.panel3.Controls.Add(this.txt_sothe);
            this.panel3.Controls.Add(this.cbo_tinh);
            this.panel3.Controls.Add(this.label5);
            this.panel3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel3.Location = new System.Drawing.Point(4, 20);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(336, 395);
            this.panel3.TabIndex = 3;
            // 
            // cbo_loaibh
            // 
            this.cbo_loaibh.FormattingEnabled = true;
            this.cbo_loaibh.Location = new System.Drawing.Point(130, 7);
            this.cbo_loaibh.Name = "cbo_loaibh";
            this.cbo_loaibh.Size = new System.Drawing.Size(194, 24);
            this.cbo_loaibh.TabIndex = 1;
            // 
            // btn_luu
            // 
            this.btn_luu.Image = global::TENTAC_HRM.Properties.Resources.diskette;
            this.btn_luu.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btn_luu.Location = new System.Drawing.Point(130, 310);
            this.btn_luu.Name = "btn_luu";
            this.btn_luu.Size = new System.Drawing.Size(98, 27);
            this.btn_luu.TabIndex = 5;
            this.btn_luu.Text = "Lưu";
            this.btn_luu.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btn_luu.UseVisualStyleBackColor = true;
            this.btn_luu.Click += new System.EventHandler(this.btn_luu_Click);
            // 
            // btn_huy
            // 
            this.btn_huy.Image = global::TENTAC_HRM.Properties.Resources.cancel;
            this.btn_huy.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btn_huy.Location = new System.Drawing.Point(234, 310);
            this.btn_huy.Name = "btn_huy";
            this.btn_huy.Size = new System.Drawing.Size(90, 27);
            this.btn_huy.TabIndex = 5;
            this.btn_huy.Text = "Hủy";
            this.btn_huy.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btn_huy.UseVisualStyleBackColor = true;
            this.btn_huy.Click += new System.EventHandler(this.btn_huy_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(4, 10);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(97, 17);
            this.label2.TabIndex = 0;
            this.label2.Text = "Loại bảo hiểm";
            // 
            // chk_active
            // 
            this.chk_active.AutoSize = true;
            this.chk_active.Location = new System.Drawing.Point(130, 279);
            this.chk_active.Name = "chk_active";
            this.chk_active.Size = new System.Drawing.Size(114, 21);
            this.chk_active.TabIndex = 4;
            this.chk_active.Text = "Đang hiệu lực";
            this.chk_active.UseVisualStyleBackColor = true;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(4, 40);
            this.label3.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(49, 17);
            this.label3.TabIndex = 0;
            this.label3.Text = "Số thẻ";
            // 
            // dtp_denngay
            // 
            this.dtp_denngay.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtp_denngay.Location = new System.Drawing.Point(130, 95);
            this.dtp_denngay.Name = "dtp_denngay";
            this.dtp_denngay.Size = new System.Drawing.Size(194, 23);
            this.dtp_denngay.TabIndex = 3;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(4, 127);
            this.label6.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(117, 17);
            this.label6.TabIndex = 0;
            this.label6.Text = "Tình / Thành phố";
            // 
            // dtp_tungay
            // 
            this.dtp_tungay.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtp_tungay.Location = new System.Drawing.Point(130, 66);
            this.dtp_tungay.Name = "dtp_tungay";
            this.dtp_tungay.Size = new System.Drawing.Size(194, 23);
            this.dtp_tungay.TabIndex = 3;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(4, 157);
            this.label7.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(83, 17);
            this.label7.TabIndex = 0;
            this.label7.Text = "Nơi đăng ký";
            // 
            // txt_ghichu
            // 
            this.txt_ghichu.Location = new System.Drawing.Point(130, 183);
            this.txt_ghichu.Multiline = true;
            this.txt_ghichu.Name = "txt_ghichu";
            this.txt_ghichu.Size = new System.Drawing.Size(194, 90);
            this.txt_ghichu.TabIndex = 2;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(4, 71);
            this.label4.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(60, 17);
            this.label4.TabIndex = 0;
            this.label4.Text = "Từ ngày";
            // 
            // txt_noidangky
            // 
            this.txt_noidangky.Location = new System.Drawing.Point(130, 154);
            this.txt_noidangky.Name = "txt_noidangky";
            this.txt_noidangky.Size = new System.Drawing.Size(194, 23);
            this.txt_noidangky.TabIndex = 2;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(4, 186);
            this.label8.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(43, 17);
            this.label8.TabIndex = 0;
            this.label8.Text = "Mô tả";
            // 
            // txt_sothe
            // 
            this.txt_sothe.Location = new System.Drawing.Point(130, 37);
            this.txt_sothe.Name = "txt_sothe";
            this.txt_sothe.Size = new System.Drawing.Size(194, 23);
            this.txt_sothe.TabIndex = 2;
            // 
            // cbo_tinh
            // 
            this.cbo_tinh.FormattingEnabled = true;
            this.cbo_tinh.Location = new System.Drawing.Point(130, 124);
            this.cbo_tinh.Name = "cbo_tinh";
            this.cbo_tinh.Size = new System.Drawing.Size(194, 24);
            this.cbo_tinh.TabIndex = 1;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(4, 100);
            this.label5.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(69, 17);
            this.label5.TabIndex = 0;
            this.label5.Text = "Đến ngày";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.panel2);
            this.groupBox1.Dock = System.Windows.Forms.DockStyle.Top;
            this.groupBox1.Location = new System.Drawing.Point(0, 0);
            this.groupBox1.Margin = new System.Windows.Forms.Padding(4);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Padding = new System.Windows.Forms.Padding(4);
            this.groupBox1.Size = new System.Drawing.Size(344, 62);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Nhân viên";
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.cbo_nhanvien);
            this.panel2.Controls.Add(this.label1);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel2.Location = new System.Drawing.Point(4, 20);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(336, 38);
            this.panel2.TabIndex = 3;
            // 
            // cbo_nhanvien
            // 
            this.cbo_nhanvien.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Append;
            this.cbo_nhanvien.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.cbo_nhanvien.Enabled = false;
            this.cbo_nhanvien.FormattingEnabled = true;
            this.cbo_nhanvien.Location = new System.Drawing.Point(130, 8);
            this.cbo_nhanvien.Name = "cbo_nhanvien";
            this.cbo_nhanvien.Size = new System.Drawing.Size(194, 24);
            this.cbo_nhanvien.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(4, 11);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(72, 17);
            this.label1.TabIndex = 0;
            this.label1.Text = "Nhân viên";
            // 
            // dgv_baohiem
            // 
            this.dgv_baohiem.AllowUserToAddRows = false;
            this.dgv_baohiem.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgv_baohiem.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.id_bao_hiem,
            this.edit_column,
            this.type_name,
            this.so_the,
            this.tu_ngay,
            this.den_ngay,
            this.ten_dia_chi,
            this.is_active});
            this.dgv_baohiem.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgv_baohiem.Location = new System.Drawing.Point(0, 25);
            this.dgv_baohiem.Margin = new System.Windows.Forms.Padding(4);
            this.dgv_baohiem.Name = "dgv_baohiem";
            this.dgv_baohiem.ReadOnly = true;
            this.dgv_baohiem.Size = new System.Drawing.Size(738, 481);
            this.dgv_baohiem.TabIndex = 2;
            this.dgv_baohiem.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgv_baohiem_CellClick);
            // 
            // id_bao_hiem
            // 
            this.id_bao_hiem.DataPropertyName = "id_bao_hiem";
            this.id_bao_hiem.HeaderText = "id_bao_hiem";
            this.id_bao_hiem.Name = "id_bao_hiem";
            this.id_bao_hiem.ReadOnly = true;
            this.id_bao_hiem.Visible = false;
            // 
            // edit_column
            // 
            this.edit_column.FillWeight = 33.53718F;
            this.edit_column.HeaderText = "";
            this.edit_column.Image = global::TENTAC_HRM.Properties.Resources.pen;
            this.edit_column.Name = "edit_column";
            this.edit_column.ReadOnly = true;
            this.edit_column.Width = 33;
            // 
            // type_name
            // 
            this.type_name.DataPropertyName = "type_name";
            this.type_name.FillWeight = 125.8992F;
            this.type_name.HeaderText = "Loại bảo hiểm";
            this.type_name.Name = "type_name";
            this.type_name.ReadOnly = true;
            this.type_name.Width = 125;
            // 
            // so_the
            // 
            this.so_the.DataPropertyName = "so_the";
            this.so_the.FillWeight = 95.85754F;
            this.so_the.HeaderText = "Số thẻ";
            this.so_the.Name = "so_the";
            this.so_the.ReadOnly = true;
            this.so_the.Width = 95;
            // 
            // tu_ngay
            // 
            this.tu_ngay.DataPropertyName = "tu_ngay";
            this.tu_ngay.FillWeight = 94.70192F;
            this.tu_ngay.HeaderText = "Từ ngày";
            this.tu_ngay.Name = "tu_ngay";
            this.tu_ngay.ReadOnly = true;
            this.tu_ngay.Width = 94;
            // 
            // den_ngay
            // 
            this.den_ngay.DataPropertyName = "den_ngay";
            this.den_ngay.FillWeight = 97.76471F;
            this.den_ngay.HeaderText = "Đến ngày";
            this.den_ngay.Name = "den_ngay";
            this.den_ngay.ReadOnly = true;
            this.den_ngay.Width = 97;
            // 
            // ten_dia_chi
            // 
            this.ten_dia_chi.DataPropertyName = "ten_dia_chi";
            this.ten_dia_chi.FillWeight = 145.6212F;
            this.ten_dia_chi.HeaderText = "Tỉnh / Thành phố";
            this.ten_dia_chi.Name = "ten_dia_chi";
            this.ten_dia_chi.ReadOnly = true;
            this.ten_dia_chi.Width = 145;
            // 
            // is_active
            // 
            this.is_active.DataPropertyName = "is_active";
            this.is_active.FillWeight = 106.618F;
            this.is_active.HeaderText = "Hiệu lực";
            this.is_active.Name = "is_active";
            this.is_active.ReadOnly = true;
            this.is_active.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.is_active.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            this.is_active.Width = 106;
            // 
            // dataGridViewImageColumn1
            // 
            this.dataGridViewImageColumn1.FillWeight = 33.53718F;
            this.dataGridViewImageColumn1.HeaderText = "";
            this.dataGridViewImageColumn1.Image = global::TENTAC_HRM.Properties.Resources.pen;
            this.dataGridViewImageColumn1.Name = "dataGridViewImageColumn1";
            this.dataGridViewImageColumn1.Width = 33;
            // 
            // toolStrip1
            // 
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.btn_add,
            this.btn_delete,
            this.btn_close});
            this.toolStrip1.Location = new System.Drawing.Point(0, 0);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(1082, 25);
            this.toolStrip1.TabIndex = 3;
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
            // frm_insurance
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1082, 506);
            this.Controls.Add(this.dgv_baohiem);
            this.Controls.Add(this.pl_baohiem);
            this.Controls.Add(this.toolStrip1);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.KeyPreview = true;
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "frm_insurance";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Nhân viên - Bảo hiểm";
            this.Load += new System.EventHandler(this.frm_insurance_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.frm_insurance_KeyDown);
            this.pl_baohiem.ResumeLayout(false);
            this.groupBox2.ResumeLayout(false);
            this.panel3.ResumeLayout(false);
            this.panel3.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgv_baohiem)).EndInit();
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Panel pl_baohiem;
        private System.Windows.Forms.DataGridView dgv_baohiem;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox cbo_nhanvien;
        private System.Windows.Forms.CheckBox chk_active;
        private System.Windows.Forms.DateTimePicker dtp_denngay;
        private System.Windows.Forms.DateTimePicker dtp_tungay;
        private System.Windows.Forms.TextBox txt_ghichu;
        private System.Windows.Forms.TextBox txt_noidangky;
        private System.Windows.Forms.TextBox txt_sothe;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.ComboBox cbo_tinh;
        private System.Windows.Forms.ComboBox cbo_loaibh;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button btn_luu;
        private System.Windows.Forms.Button btn_huy;
        private System.Windows.Forms.DataGridViewImageColumn dataGridViewImageColumn1;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.DataGridViewTextBoxColumn id_bao_hiem;
        private System.Windows.Forms.DataGridViewImageColumn edit_column;
        private System.Windows.Forms.DataGridViewTextBoxColumn type_name;
        private System.Windows.Forms.DataGridViewTextBoxColumn so_the;
        private System.Windows.Forms.DataGridViewTextBoxColumn tu_ngay;
        private System.Windows.Forms.DataGridViewTextBoxColumn den_ngay;
        private System.Windows.Forms.DataGridViewTextBoxColumn ten_dia_chi;
        private System.Windows.Forms.DataGridViewCheckBoxColumn is_active;
        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripButton btn_add;
        private System.Windows.Forms.ToolStripButton btn_delete;
        private System.Windows.Forms.ToolStripButton btn_close;
    }
}