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
            this.panel3 = new System.Windows.Forms.Panel();
            this.gb_thongtin = new System.Windows.Forms.GroupBox();
            this.panel4 = new System.Windows.Forms.Panel();
            this.label7 = new System.Windows.Forms.Label();
            this.btn_save = new System.Windows.Forms.Button();
            this.dtp_denngay = new System.Windows.Forms.DateTimePicker();
            this.dtp_tungay = new System.Windows.Forms.DateTimePicker();
            this.chk_active = new System.Windows.Forms.CheckBox();
            this.chk_cd = new System.Windows.Forms.CheckBox();
            this.chk_bhtn = new System.Windows.Forms.CheckBox();
            this.chk_tinhthuetheo_pt_codinh = new System.Windows.Forms.CheckBox();
            this.chk_bhyt = new System.Windows.Forms.CheckBox();
            this.chk_miendongthue = new System.Windows.Forms.CheckBox();
            this.chk_bhxh = new System.Windows.Forms.CheckBox();
            this.txt_ghichu = new System.Windows.Forms.TextBox();
            this.txt_thue = new System.Windows.Forms.TextBox();
            this.txt_mucluong = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.gb_nhanvien = new System.Windows.Forms.GroupBox();
            this.panel2 = new System.Windows.Forms.Panel();
            this.cbo_nhanvien = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.dgv_luong = new System.Windows.Forms.DataGridView();
            this.id_luong = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.edit_column = new System.Windows.Forms.DataGridViewImageColumn();
            this.tu_ngay = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.den_ngay = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.muc_luong = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.is_active = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.btn_add = new System.Windows.Forms.ToolStripButton();
            this.btn_delete = new System.Windows.Forms.ToolStripButton();
            this.btn_close = new System.Windows.Forms.ToolStripButton();
            this.panel3.SuspendLayout();
            this.gb_thongtin.SuspendLayout();
            this.panel4.SuspendLayout();
            this.gb_nhanvien.SuspendLayout();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgv_luong)).BeginInit();
            this.toolStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel3
            // 
            this.panel3.Controls.Add(this.gb_thongtin);
            this.panel3.Controls.Add(this.gb_nhanvien);
            this.panel3.Dock = System.Windows.Forms.DockStyle.Right;
            this.panel3.Location = new System.Drawing.Point(578, 25);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(556, 529);
            this.panel3.TabIndex = 2;
            // 
            // gb_thongtin
            // 
            this.gb_thongtin.Controls.Add(this.panel4);
            this.gb_thongtin.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gb_thongtin.Enabled = false;
            this.gb_thongtin.Location = new System.Drawing.Point(0, 66);
            this.gb_thongtin.Name = "gb_thongtin";
            this.gb_thongtin.Size = new System.Drawing.Size(556, 463);
            this.gb_thongtin.TabIndex = 1;
            this.gb_thongtin.TabStop = false;
            this.gb_thongtin.Text = "Thông tin";
            // 
            // panel4
            // 
            this.panel4.Controls.Add(this.label7);
            this.panel4.Controls.Add(this.btn_save);
            this.panel4.Controls.Add(this.dtp_denngay);
            this.panel4.Controls.Add(this.dtp_tungay);
            this.panel4.Controls.Add(this.chk_active);
            this.panel4.Controls.Add(this.chk_cd);
            this.panel4.Controls.Add(this.chk_bhtn);
            this.panel4.Controls.Add(this.chk_tinhthuetheo_pt_codinh);
            this.panel4.Controls.Add(this.chk_bhyt);
            this.panel4.Controls.Add(this.chk_miendongthue);
            this.panel4.Controls.Add(this.chk_bhxh);
            this.panel4.Controls.Add(this.txt_ghichu);
            this.panel4.Controls.Add(this.txt_thue);
            this.panel4.Controls.Add(this.txt_mucluong);
            this.panel4.Controls.Add(this.label3);
            this.panel4.Controls.Add(this.label5);
            this.panel4.Controls.Add(this.label6);
            this.panel4.Controls.Add(this.label4);
            this.panel4.Controls.Add(this.label2);
            this.panel4.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel4.Location = new System.Drawing.Point(3, 19);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(550, 441);
            this.panel4.TabIndex = 1;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.BackColor = System.Drawing.SystemColors.Window;
            this.label7.Location = new System.Drawing.Point(516, 92);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(20, 17);
            this.label7.TabIndex = 0;
            this.label7.Text = "%";
            // 
            // btn_save
            // 
            this.btn_save.Image = global::TENTAC_HRM.Properties.Resources.diskette;
            this.btn_save.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btn_save.Location = new System.Drawing.Point(432, 313);
            this.btn_save.Name = "btn_save";
            this.btn_save.Size = new System.Drawing.Size(104, 33);
            this.btn_save.TabIndex = 4;
            this.btn_save.Text = "Lưu";
            this.btn_save.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btn_save.UseVisualStyleBackColor = true;
            this.btn_save.Click += new System.EventHandler(this.btn_save_Click);
            // 
            // dtp_denngay
            // 
            this.dtp_denngay.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtp_denngay.Location = new System.Drawing.Point(403, 155);
            this.dtp_denngay.Name = "dtp_denngay";
            this.dtp_denngay.Size = new System.Drawing.Size(134, 23);
            this.dtp_denngay.TabIndex = 3;
            // 
            // dtp_tungay
            // 
            this.dtp_tungay.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtp_tungay.Location = new System.Drawing.Point(94, 156);
            this.dtp_tungay.Name = "dtp_tungay";
            this.dtp_tungay.Size = new System.Drawing.Size(155, 23);
            this.dtp_tungay.TabIndex = 3;
            // 
            // chk_active
            // 
            this.chk_active.AutoSize = true;
            this.chk_active.Location = new System.Drawing.Point(94, 282);
            this.chk_active.Name = "chk_active";
            this.chk_active.Size = new System.Drawing.Size(114, 21);
            this.chk_active.TabIndex = 2;
            this.chk_active.Text = "Đang hiệu lực";
            this.chk_active.UseVisualStyleBackColor = true;
            // 
            // chk_cd
            // 
            this.chk_cd.AutoSize = true;
            this.chk_cd.Location = new System.Drawing.Point(94, 118);
            this.chk_cd.Name = "chk_cd";
            this.chk_cd.Size = new System.Drawing.Size(107, 21);
            this.chk_cd.TabIndex = 2;
            this.chk_cd.Text = "Đống phí CĐ";
            this.chk_cd.UseVisualStyleBackColor = true;
            // 
            // chk_bhtn
            // 
            this.chk_bhtn.AutoSize = true;
            this.chk_bhtn.Location = new System.Drawing.Point(94, 91);
            this.chk_bhtn.Name = "chk_bhtn";
            this.chk_bhtn.Size = new System.Drawing.Size(103, 21);
            this.chk_bhtn.TabIndex = 2;
            this.chk_bhtn.Text = "Đóng BHTN";
            this.chk_bhtn.UseVisualStyleBackColor = true;
            // 
            // chk_tinhthuetheo_pt_codinh
            // 
            this.chk_tinhthuetheo_pt_codinh.AutoSize = true;
            this.chk_tinhthuetheo_pt_codinh.Location = new System.Drawing.Point(270, 64);
            this.chk_tinhthuetheo_pt_codinh.Name = "chk_tinhthuetheo_pt_codinh";
            this.chk_tinhthuetheo_pt_codinh.Size = new System.Drawing.Size(249, 21);
            this.chk_tinhthuetheo_pt_codinh.TabIndex = 2;
            this.chk_tinhthuetheo_pt_codinh.Text = "Tính thuế  thu nhập theo % cố định";
            this.chk_tinhthuetheo_pt_codinh.UseVisualStyleBackColor = true;
            // 
            // chk_bhyt
            // 
            this.chk_bhyt.AutoSize = true;
            this.chk_bhyt.Location = new System.Drawing.Point(94, 64);
            this.chk_bhyt.Name = "chk_bhyt";
            this.chk_bhyt.Size = new System.Drawing.Size(102, 21);
            this.chk_bhyt.TabIndex = 2;
            this.chk_bhyt.Text = "Đống BHYT";
            this.chk_bhyt.UseVisualStyleBackColor = true;
            // 
            // chk_miendongthue
            // 
            this.chk_miendongthue.AutoSize = true;
            this.chk_miendongthue.Location = new System.Drawing.Point(270, 37);
            this.chk_miendongthue.Name = "chk_miendongthue";
            this.chk_miendongthue.Size = new System.Drawing.Size(185, 21);
            this.chk_miendongthue.TabIndex = 2;
            this.chk_miendongthue.Text = "Miến đống thuế thu nhập";
            this.chk_miendongthue.UseVisualStyleBackColor = true;
            // 
            // chk_bhxh
            // 
            this.chk_bhxh.AutoSize = true;
            this.chk_bhxh.Location = new System.Drawing.Point(94, 37);
            this.chk_bhxh.Name = "chk_bhxh";
            this.chk_bhxh.Size = new System.Drawing.Size(103, 21);
            this.chk_bhxh.TabIndex = 2;
            this.chk_bhxh.Text = "Đống BHXH";
            this.chk_bhxh.UseVisualStyleBackColor = true;
            // 
            // txt_ghichu
            // 
            this.txt_ghichu.Location = new System.Drawing.Point(94, 188);
            this.txt_ghichu.Multiline = true;
            this.txt_ghichu.Name = "txt_ghichu";
            this.txt_ghichu.Size = new System.Drawing.Size(443, 88);
            this.txt_ghichu.TabIndex = 1;
            // 
            // txt_thue
            // 
            this.txt_thue.Location = new System.Drawing.Point(403, 89);
            this.txt_thue.Name = "txt_thue";
            this.txt_thue.Size = new System.Drawing.Size(134, 23);
            this.txt_thue.TabIndex = 1;
            // 
            // txt_mucluong
            // 
            this.txt_mucluong.Location = new System.Drawing.Point(94, 8);
            this.txt_mucluong.Name = "txt_mucluong";
            this.txt_mucluong.Size = new System.Drawing.Size(231, 23);
            this.txt_mucluong.TabIndex = 1;
            this.txt_mucluong.Leave += new System.EventHandler(this.txt_mucluong_Leave);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(289, 92);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(102, 17);
            this.label3.TabIndex = 0;
            this.label3.Text = "Mức đóng thuế";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(15, 191);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(43, 17);
            this.label5.TabIndex = 0;
            this.label5.Text = "Mô tả";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(289, 160);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(69, 17);
            this.label6.TabIndex = 0;
            this.label6.Text = "Đến ngày";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(15, 160);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(60, 17);
            this.label4.TabIndex = 0;
            this.label4.Text = "Từ ngày";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(15, 11);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(73, 17);
            this.label2.TabIndex = 0;
            this.label2.Text = "Mức lương";
            // 
            // gb_nhanvien
            // 
            this.gb_nhanvien.Controls.Add(this.panel2);
            this.gb_nhanvien.Dock = System.Windows.Forms.DockStyle.Top;
            this.gb_nhanvien.Enabled = false;
            this.gb_nhanvien.Location = new System.Drawing.Point(0, 0);
            this.gb_nhanvien.Name = "gb_nhanvien";
            this.gb_nhanvien.Size = new System.Drawing.Size(556, 66);
            this.gb_nhanvien.TabIndex = 0;
            this.gb_nhanvien.TabStop = false;
            this.gb_nhanvien.Text = "Nhân viên";
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.cbo_nhanvien);
            this.panel2.Controls.Add(this.label1);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel2.Location = new System.Drawing.Point(3, 19);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(550, 44);
            this.panel2.TabIndex = 1;
            // 
            // cbo_nhanvien
            // 
            this.cbo_nhanvien.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Append;
            this.cbo_nhanvien.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.cbo_nhanvien.Enabled = false;
            this.cbo_nhanvien.FormattingEnabled = true;
            this.cbo_nhanvien.Location = new System.Drawing.Point(94, 8);
            this.cbo_nhanvien.Name = "cbo_nhanvien";
            this.cbo_nhanvien.Size = new System.Drawing.Size(443, 24);
            this.cbo_nhanvien.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 11);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(72, 17);
            this.label1.TabIndex = 0;
            this.label1.Text = "Nhân viên";
            // 
            // dgv_luong
            // 
            this.dgv_luong.AllowUserToAddRows = false;
            this.dgv_luong.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgv_luong.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.id_luong,
            this.edit_column,
            this.tu_ngay,
            this.den_ngay,
            this.muc_luong,
            this.is_active});
            this.dgv_luong.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgv_luong.Location = new System.Drawing.Point(0, 25);
            this.dgv_luong.Name = "dgv_luong";
            this.dgv_luong.Size = new System.Drawing.Size(578, 529);
            this.dgv_luong.TabIndex = 3;
            this.dgv_luong.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgv_luong_CellClick);
            // 
            // id_luong
            // 
            this.id_luong.DataPropertyName = "id_luong";
            this.id_luong.HeaderText = "Column4";
            this.id_luong.Name = "id_luong";
            this.id_luong.Visible = false;
            // 
            // edit_column
            // 
            this.edit_column.HeaderText = "";
            this.edit_column.Image = global::TENTAC_HRM.Properties.Resources.pen;
            this.edit_column.Name = "edit_column";
            this.edit_column.ToolTipText = "Sửa";
            this.edit_column.Width = 30;
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
            // muc_luong
            // 
            this.muc_luong.DataPropertyName = "muc_luong";
            this.muc_luong.HeaderText = "Mức lương";
            this.muc_luong.Name = "muc_luong";
            // 
            // is_active
            // 
            this.is_active.DataPropertyName = "is_active";
            this.is_active.HeaderText = "Hiệu lực";
            this.is_active.Name = "is_active";
            this.is_active.ReadOnly = true;
            this.is_active.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.is_active.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            // 
            // toolStrip1
            // 
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.btn_add,
            this.btn_delete,
            this.btn_close});
            this.toolStrip1.Location = new System.Drawing.Point(0, 0);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(1134, 25);
            this.toolStrip1.TabIndex = 4;
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
            // frm_wage
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.ClientSize = new System.Drawing.Size(1134, 554);
            this.Controls.Add(this.dgv_luong);
            this.Controls.Add(this.panel3);
            this.Controls.Add(this.toolStrip1);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.KeyPreview = true;
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "frm_wage";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Lương";
            this.Load += new System.EventHandler(this.frm_wage_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.frm_wage_KeyDown);
            this.panel3.ResumeLayout(false);
            this.gb_thongtin.ResumeLayout(false);
            this.panel4.ResumeLayout(false);
            this.panel4.PerformLayout();
            this.gb_nhanvien.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgv_luong)).EndInit();
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.DataGridView dgv_luong;
        private System.Windows.Forms.GroupBox gb_nhanvien;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.ComboBox cbo_nhanvien;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.GroupBox gb_thongtin;
        private System.Windows.Forms.Panel panel4;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txt_mucluong;
        private System.Windows.Forms.CheckBox chk_active;
        private System.Windows.Forms.CheckBox chk_cd;
        private System.Windows.Forms.CheckBox chk_bhtn;
        private System.Windows.Forms.CheckBox chk_tinhthuetheo_pt_codinh;
        private System.Windows.Forms.CheckBox chk_bhyt;
        private System.Windows.Forms.CheckBox chk_miendongthue;
        private System.Windows.Forms.CheckBox chk_bhxh;
        private System.Windows.Forms.TextBox txt_ghichu;
        private System.Windows.Forms.TextBox txt_thue;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.DateTimePicker dtp_denngay;
        private System.Windows.Forms.DateTimePicker dtp_tungay;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Button btn_save;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripButton btn_add;
        private System.Windows.Forms.ToolStripButton btn_delete;
        private System.Windows.Forms.ToolStripButton btn_close;
        private System.Windows.Forms.DataGridViewTextBoxColumn id_luong;
        private System.Windows.Forms.DataGridViewImageColumn edit_column;
        private System.Windows.Forms.DataGridViewTextBoxColumn tu_ngay;
        private System.Windows.Forms.DataGridViewTextBoxColumn den_ngay;
        private System.Windows.Forms.DataGridViewTextBoxColumn muc_luong;
        private System.Windows.Forms.DataGridViewCheckBoxColumn is_active;
    }
}