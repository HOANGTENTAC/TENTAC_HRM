namespace TENTAC_HRM.Forms.User_control
{
    partial class uc_staff_address
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
            this.pl_address = new System.Windows.Forms.Panel();
            this.gb_diachi = new System.Windows.Forms.GroupBox();
            this.panel4 = new System.Windows.Forms.Panel();
            this.button7 = new System.Windows.Forms.Button();
            this.cbo_nhanvien = new System.Windows.Forms.ComboBox();
            this.cbo_loai_dia_chi = new System.Windows.Forms.ComboBox();
            this.btn_cancel = new System.Windows.Forms.Button();
            this.btn_save = new System.Windows.Forms.Button();
            this.label5 = new System.Windows.Forms.Label();
            this.cbo_quan = new System.Windows.Forms.ComboBox();
            this.button6 = new System.Windows.Forms.Button();
            this.label7 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.button5 = new System.Windows.Forms.Button();
            this.cbo_phuong = new System.Windows.Forms.ComboBox();
            this.cbo_tinh = new System.Windows.Forms.ComboBox();
            this.button4 = new System.Windows.Forms.Button();
            this.txt_so_nha = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.cbo_quoc_gia = new System.Windows.Forms.ComboBox();
            this.chk_dang_hieu_luc = new System.Windows.Forms.CheckBox();
            this.dgv_nhanvien_diachi = new System.Windows.Forms.DataGridView();
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.btn_add = new System.Windows.Forms.ToolStripButton();
            this.btn_delete = new System.Windows.Forms.ToolStripButton();
            this.dataGridViewImageColumn1 = new System.Windows.Forms.DataGridViewImageColumn();
            this.id = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.edit_column = new System.Windows.Forms.DataGridViewImageColumn();
            this.ma_nhan_vien = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.TenNhanVien = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.typename = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.diachi = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.isactive = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.pl_address.SuspendLayout();
            this.gb_diachi.SuspendLayout();
            this.panel4.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgv_nhanvien_diachi)).BeginInit();
            this.toolStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // pl_address
            // 
            this.pl_address.Controls.Add(this.gb_diachi);
            this.pl_address.Dock = System.Windows.Forms.DockStyle.Right;
            this.pl_address.Enabled = false;
            this.pl_address.Location = new System.Drawing.Point(794, 25);
            this.pl_address.Margin = new System.Windows.Forms.Padding(4);
            this.pl_address.MaximumSize = new System.Drawing.Size(381, 0);
            this.pl_address.MinimumSize = new System.Drawing.Size(0, 587);
            this.pl_address.Name = "pl_address";
            this.pl_address.Size = new System.Drawing.Size(381, 611);
            this.pl_address.TabIndex = 1;
            // 
            // gb_diachi
            // 
            this.gb_diachi.Controls.Add(this.panel4);
            this.gb_diachi.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gb_diachi.Location = new System.Drawing.Point(0, 0);
            this.gb_diachi.Margin = new System.Windows.Forms.Padding(4);
            this.gb_diachi.Name = "gb_diachi";
            this.gb_diachi.Padding = new System.Windows.Forms.Padding(4);
            this.gb_diachi.Size = new System.Drawing.Size(381, 611);
            this.gb_diachi.TabIndex = 25;
            this.gb_diachi.TabStop = false;
            this.gb_diachi.Text = "Địa chỉ";
            // 
            // panel4
            // 
            this.panel4.Controls.Add(this.button7);
            this.panel4.Controls.Add(this.cbo_nhanvien);
            this.panel4.Controls.Add(this.cbo_loai_dia_chi);
            this.panel4.Controls.Add(this.btn_cancel);
            this.panel4.Controls.Add(this.btn_save);
            this.panel4.Controls.Add(this.label5);
            this.panel4.Controls.Add(this.cbo_quan);
            this.panel4.Controls.Add(this.button6);
            this.panel4.Controls.Add(this.label7);
            this.panel4.Controls.Add(this.label6);
            this.panel4.Controls.Add(this.label1);
            this.panel4.Controls.Add(this.label4);
            this.panel4.Controls.Add(this.button5);
            this.panel4.Controls.Add(this.cbo_phuong);
            this.panel4.Controls.Add(this.cbo_tinh);
            this.panel4.Controls.Add(this.button4);
            this.panel4.Controls.Add(this.txt_so_nha);
            this.panel4.Controls.Add(this.label2);
            this.panel4.Controls.Add(this.label3);
            this.panel4.Controls.Add(this.cbo_quoc_gia);
            this.panel4.Controls.Add(this.chk_dang_hieu_luc);
            this.panel4.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel4.Location = new System.Drawing.Point(4, 20);
            this.panel4.Margin = new System.Windows.Forms.Padding(4);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(373, 587);
            this.panel4.TabIndex = 3;
            // 
            // button7
            // 
            this.button7.Location = new System.Drawing.Point(335, 199);
            this.button7.Margin = new System.Windows.Forms.Padding(5);
            this.button7.Name = "button7";
            this.button7.Size = new System.Drawing.Size(26, 26);
            this.button7.TabIndex = 22;
            this.button7.Text = "+";
            this.button7.UseVisualStyleBackColor = true;
            // 
            // cbo_nhanvien
            // 
            this.cbo_nhanvien.Enabled = false;
            this.cbo_nhanvien.FormattingEnabled = true;
            this.cbo_nhanvien.Location = new System.Drawing.Point(141, 20);
            this.cbo_nhanvien.Margin = new System.Windows.Forms.Padding(7, 6, 7, 6);
            this.cbo_nhanvien.Name = "cbo_nhanvien";
            this.cbo_nhanvien.Size = new System.Drawing.Size(219, 24);
            this.cbo_nhanvien.TabIndex = 15;
            this.cbo_nhanvien.SelectedValueChanged += new System.EventHandler(this.cbo_nhanvien_SelectedValueChanged);
            // 
            // cbo_loai_dia_chi
            // 
            this.cbo_loai_dia_chi.FormattingEnabled = true;
            this.cbo_loai_dia_chi.Location = new System.Drawing.Point(141, 56);
            this.cbo_loai_dia_chi.Margin = new System.Windows.Forms.Padding(7, 6, 7, 6);
            this.cbo_loai_dia_chi.Name = "cbo_loai_dia_chi";
            this.cbo_loai_dia_chi.Size = new System.Drawing.Size(219, 24);
            this.cbo_loai_dia_chi.TabIndex = 15;
            // 
            // btn_cancel
            // 
            this.btn_cancel.Image = global::TENTAC_HRM.Properties.Resources.cancel;
            this.btn_cancel.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btn_cancel.Location = new System.Drawing.Point(271, 301);
            this.btn_cancel.Margin = new System.Windows.Forms.Padding(5);
            this.btn_cancel.Name = "btn_cancel";
            this.btn_cancel.Size = new System.Drawing.Size(90, 32);
            this.btn_cancel.TabIndex = 18;
            this.btn_cancel.Text = "Hủy";
            this.btn_cancel.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btn_cancel.UseVisualStyleBackColor = true;
            this.btn_cancel.Click += new System.EventHandler(this.btn_cancel_Click);
            // 
            // btn_save
            // 
            this.btn_save.Image = global::TENTAC_HRM.Properties.Resources.diskette;
            this.btn_save.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btn_save.Location = new System.Drawing.Point(141, 301);
            this.btn_save.Margin = new System.Windows.Forms.Padding(5);
            this.btn_save.Name = "btn_save";
            this.btn_save.Size = new System.Drawing.Size(123, 32);
            this.btn_save.TabIndex = 18;
            this.btn_save.Text = "Lưu";
            this.btn_save.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btn_save.UseVisualStyleBackColor = true;
            this.btn_save.Click += new System.EventHandler(this.btn_save_Click);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(17, 204);
            this.label5.Margin = new System.Windows.Forms.Padding(7, 0, 7, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(78, 17);
            this.label5.TabIndex = 9;
            this.label5.Text = "Phường/Xã";
            // 
            // cbo_quan
            // 
            this.cbo_quan.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Append;
            this.cbo_quan.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.cbo_quan.FormattingEnabled = true;
            this.cbo_quan.Location = new System.Drawing.Point(141, 164);
            this.cbo_quan.Margin = new System.Windows.Forms.Padding(7, 6, 7, 6);
            this.cbo_quan.Name = "cbo_quan";
            this.cbo_quan.Size = new System.Drawing.Size(194, 24);
            this.cbo_quan.TabIndex = 13;
            this.cbo_quan.SelectedValueChanged += new System.EventHandler(this.cbo_quan_SelectedValueChanged);
            // 
            // button6
            // 
            this.button6.Location = new System.Drawing.Point(335, 163);
            this.button6.Margin = new System.Windows.Forms.Padding(5);
            this.button6.Name = "button6";
            this.button6.Size = new System.Drawing.Size(26, 26);
            this.button6.TabIndex = 21;
            this.button6.Text = "+";
            this.button6.UseVisualStyleBackColor = true;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(17, 23);
            this.label7.Margin = new System.Windows.Forms.Padding(7, 0, 7, 0);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(72, 17);
            this.label7.TabIndex = 5;
            this.label7.Text = "Nhân viên";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(17, 239);
            this.label6.Margin = new System.Windows.Forms.Padding(7, 0, 7, 0);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(113, 17);
            this.label6.TabIndex = 10;
            this.label6.Text = "Thôn/Tổ/Số/Nhà";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(17, 59);
            this.label1.Margin = new System.Windows.Forms.Padding(7, 0, 7, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(80, 17);
            this.label1.TabIndex = 5;
            this.label1.Text = "Loại địa chỉ";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(17, 168);
            this.label4.Margin = new System.Windows.Forms.Padding(7, 0, 7, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(88, 17);
            this.label4.TabIndex = 8;
            this.label4.Text = "Quận/Huyện";
            // 
            // button5
            // 
            this.button5.Location = new System.Drawing.Point(335, 127);
            this.button5.Margin = new System.Windows.Forms.Padding(5);
            this.button5.Name = "button5";
            this.button5.Size = new System.Drawing.Size(26, 26);
            this.button5.TabIndex = 20;
            this.button5.Text = "+";
            this.button5.UseVisualStyleBackColor = true;
            // 
            // cbo_phuong
            // 
            this.cbo_phuong.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Append;
            this.cbo_phuong.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.cbo_phuong.FormattingEnabled = true;
            this.cbo_phuong.Location = new System.Drawing.Point(141, 200);
            this.cbo_phuong.Margin = new System.Windows.Forms.Padding(7, 6, 7, 6);
            this.cbo_phuong.Name = "cbo_phuong";
            this.cbo_phuong.Size = new System.Drawing.Size(194, 24);
            this.cbo_phuong.TabIndex = 14;
            // 
            // cbo_tinh
            // 
            this.cbo_tinh.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Append;
            this.cbo_tinh.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.cbo_tinh.FormattingEnabled = true;
            this.cbo_tinh.Location = new System.Drawing.Point(141, 128);
            this.cbo_tinh.Margin = new System.Windows.Forms.Padding(7, 6, 7, 6);
            this.cbo_tinh.Name = "cbo_tinh";
            this.cbo_tinh.Size = new System.Drawing.Size(194, 24);
            this.cbo_tinh.TabIndex = 12;
            this.cbo_tinh.SelectedValueChanged += new System.EventHandler(this.cbo_tinh_SelectedValueChanged);
            // 
            // button4
            // 
            this.button4.Location = new System.Drawing.Point(335, 91);
            this.button4.Margin = new System.Windows.Forms.Padding(5);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(26, 26);
            this.button4.TabIndex = 19;
            this.button4.Text = "+";
            this.button4.UseVisualStyleBackColor = true;
            // 
            // txt_so_nha
            // 
            this.txt_so_nha.Location = new System.Drawing.Point(141, 236);
            this.txt_so_nha.Margin = new System.Windows.Forms.Padding(7, 6, 7, 6);
            this.txt_so_nha.Name = "txt_so_nha";
            this.txt_so_nha.Size = new System.Drawing.Size(219, 23);
            this.txt_so_nha.TabIndex = 16;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(17, 95);
            this.label2.Margin = new System.Windows.Forms.Padding(7, 0, 7, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(65, 17);
            this.label2.TabIndex = 6;
            this.label2.Text = "Quốc gia";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(17, 132);
            this.label3.Margin = new System.Windows.Forms.Padding(7, 0, 7, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(109, 17);
            this.label3.TabIndex = 7;
            this.label3.Text = "Tỉnh/Thành phố";
            // 
            // cbo_quoc_gia
            // 
            this.cbo_quoc_gia.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Append;
            this.cbo_quoc_gia.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.cbo_quoc_gia.FormattingEnabled = true;
            this.cbo_quoc_gia.Location = new System.Drawing.Point(141, 92);
            this.cbo_quoc_gia.Margin = new System.Windows.Forms.Padding(7, 6, 7, 6);
            this.cbo_quoc_gia.Name = "cbo_quoc_gia";
            this.cbo_quoc_gia.Size = new System.Drawing.Size(194, 24);
            this.cbo_quoc_gia.TabIndex = 11;
            this.cbo_quoc_gia.SelectedValueChanged += new System.EventHandler(this.cbo_quoc_gia_SelectedValueChanged);
            // 
            // chk_dang_hieu_luc
            // 
            this.chk_dang_hieu_luc.AutoSize = true;
            this.chk_dang_hieu_luc.Location = new System.Drawing.Point(141, 270);
            this.chk_dang_hieu_luc.Margin = new System.Windows.Forms.Padding(5);
            this.chk_dang_hieu_luc.Name = "chk_dang_hieu_luc";
            this.chk_dang_hieu_luc.Size = new System.Drawing.Size(114, 21);
            this.chk_dang_hieu_luc.TabIndex = 17;
            this.chk_dang_hieu_luc.Text = "Đang hiệu lực";
            this.chk_dang_hieu_luc.UseVisualStyleBackColor = true;
            // 
            // dgv_nhanvien_diachi
            // 
            this.dgv_nhanvien_diachi.AllowUserToAddRows = false;
            this.dgv_nhanvien_diachi.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgv_nhanvien_diachi.BackgroundColor = System.Drawing.SystemColors.Control;
            this.dgv_nhanvien_diachi.ColumnHeadersHeight = 25;
            this.dgv_nhanvien_diachi.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.id,
            this.edit_column,
            this.ma_nhan_vien,
            this.TenNhanVien,
            this.typename,
            this.diachi,
            this.isactive});
            this.dgv_nhanvien_diachi.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgv_nhanvien_diachi.Location = new System.Drawing.Point(0, 25);
            this.dgv_nhanvien_diachi.Margin = new System.Windows.Forms.Padding(5);
            this.dgv_nhanvien_diachi.Name = "dgv_nhanvien_diachi";
            this.dgv_nhanvien_diachi.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.AutoSizeToAllHeaders;
            this.dgv_nhanvien_diachi.Size = new System.Drawing.Size(794, 611);
            this.dgv_nhanvien_diachi.TabIndex = 4;
            this.dgv_nhanvien_diachi.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgv_nhanvien_diachi_CellClick);
            // 
            // toolStrip1
            // 
            this.toolStrip1.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.btn_add,
            this.btn_delete});
            this.toolStrip1.Location = new System.Drawing.Point(0, 0);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(1175, 25);
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
            // 
            // dataGridViewImageColumn1
            // 
            this.dataGridViewImageColumn1.FillWeight = 40.60913F;
            this.dataGridViewImageColumn1.HeaderText = "";
            this.dataGridViewImageColumn1.Image = global::TENTAC_HRM.Properties.Resources.pen;
            this.dataGridViewImageColumn1.Name = "dataGridViewImageColumn1";
            this.dataGridViewImageColumn1.Width = 74;
            // 
            // id
            // 
            this.id.DataPropertyName = "id";
            this.id.HeaderText = "id_dia_chi";
            this.id.Name = "id";
            this.id.Visible = false;
            // 
            // edit_column
            // 
            this.edit_column.FillWeight = 20.30457F;
            this.edit_column.HeaderText = "";
            this.edit_column.Image = global::TENTAC_HRM.Properties.Resources.pen;
            this.edit_column.Name = "edit_column";
            // 
            // ma_nhan_vien
            // 
            this.ma_nhan_vien.DataPropertyName = "manhanvien";
            this.ma_nhan_vien.HeaderText = "Mã nhân viên";
            this.ma_nhan_vien.Name = "ma_nhan_vien";
            // 
            // TenNhanVien
            // 
            this.TenNhanVien.DataPropertyName = "TenNhanVien";
            this.TenNhanVien.HeaderText = "Tên nhân viên";
            this.TenNhanVien.Name = "TenNhanVien";
            // 
            // typename
            // 
            this.typename.DataPropertyName = "typename";
            this.typename.FillWeight = 82.33871F;
            this.typename.HeaderText = "Loại địa chỉ";
            this.typename.Name = "typename";
            // 
            // diachi
            // 
            this.diachi.DataPropertyName = "diachi";
            this.diachi.FillWeight = 230.8431F;
            this.diachi.HeaderText = "Địa chỉ";
            this.diachi.Name = "diachi";
            // 
            // isactive
            // 
            this.isactive.DataPropertyName = "isactive";
            this.isactive.FillWeight = 66.5135F;
            this.isactive.HeaderText = "Hiệu lực";
            this.isactive.Name = "isactive";
            this.isactive.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.isactive.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            // 
            // uc_staff_address
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.dgv_nhanvien_diachi);
            this.Controls.Add(this.pl_address);
            this.Controls.Add(this.toolStrip1);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "uc_staff_address";
            this.Size = new System.Drawing.Size(1175, 636);
            this.Load += new System.EventHandler(this.uc_staff_address_Load);
            this.pl_address.ResumeLayout(false);
            this.gb_diachi.ResumeLayout(false);
            this.panel4.ResumeLayout(false);
            this.panel4.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgv_nhanvien_diachi)).EndInit();
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Panel pl_address;
        private System.Windows.Forms.DataGridView dgv_nhanvien_diachi;
        private System.Windows.Forms.GroupBox gb_diachi;
        private System.Windows.Forms.Panel panel4;
        private System.Windows.Forms.Button button7;
        private System.Windows.Forms.ComboBox cbo_loai_dia_chi;
        private System.Windows.Forms.Button btn_cancel;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.ComboBox cbo_quan;
        private System.Windows.Forms.Button button6;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button button5;
        private System.Windows.Forms.ComboBox cbo_phuong;
        private System.Windows.Forms.ComboBox cbo_tinh;
        private System.Windows.Forms.Button button4;
        private System.Windows.Forms.TextBox txt_so_nha;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ComboBox cbo_quoc_gia;
        private System.Windows.Forms.CheckBox chk_dang_hieu_luc;
        private System.Windows.Forms.DataGridViewImageColumn dataGridViewImageColumn1;
        public System.Windows.Forms.Button btn_save;
        private System.Windows.Forms.ComboBox cbo_nhanvien;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripButton btn_add;
        private System.Windows.Forms.ToolStripButton btn_delete;
        private System.Windows.Forms.DataGridViewTextBoxColumn id;
        private System.Windows.Forms.DataGridViewImageColumn edit_column;
        private System.Windows.Forms.DataGridViewTextBoxColumn ma_nhan_vien;
        private System.Windows.Forms.DataGridViewTextBoxColumn TenNhanVien;
        private System.Windows.Forms.DataGridViewTextBoxColumn typename;
        private System.Windows.Forms.DataGridViewTextBoxColumn diachi;
        private System.Windows.Forms.DataGridViewCheckBoxColumn isactive;
    }
}
