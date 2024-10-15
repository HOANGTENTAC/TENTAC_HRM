namespace TENTAC_HRM.Forms.Category
{
    partial class frm_staff_allowance
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
            this.panel2 = new System.Windows.Forms.Panel();
            this.gb_thongtin = new System.Windows.Forms.GroupBox();
            this.panel4 = new System.Windows.Forms.Panel();
            this.btn_save = new System.Windows.Forms.Button();
            this.btn_close = new System.Windows.Forms.Button();
            this.dtp_denngay = new System.Windows.Forms.DateTimePicker();
            this.dtp_tungay = new System.Windows.Forms.DateTimePicker();
            this.chk_active = new System.Windows.Forms.CheckBox();
            this.txt_ghichu = new System.Windows.Forms.TextBox();
            this.txt_mucphucap = new System.Windows.Forms.TextBox();
            this.cbo_loaiphucap = new System.Windows.Forms.ComboBox();
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.gb_nhanvien = new System.Windows.Forms.GroupBox();
            this.panel3 = new System.Windows.Forms.Panel();
            this.cbo_nhanvien = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.panel2.SuspendLayout();
            this.gb_thongtin.SuspendLayout();
            this.panel4.SuspendLayout();
            this.gb_nhanvien.SuspendLayout();
            this.panel3.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.gb_thongtin);
            this.panel2.Controls.Add(this.gb_nhanvien);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel2.Location = new System.Drawing.Point(0, 0);
            this.panel2.Margin = new System.Windows.Forms.Padding(4);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(408, 423);
            this.panel2.TabIndex = 1;
            // 
            // gb_thongtin
            // 
            this.gb_thongtin.Controls.Add(this.panel4);
            this.gb_thongtin.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gb_thongtin.Location = new System.Drawing.Point(0, 69);
            this.gb_thongtin.Margin = new System.Windows.Forms.Padding(4);
            this.gb_thongtin.Name = "gb_thongtin";
            this.gb_thongtin.Padding = new System.Windows.Forms.Padding(4);
            this.gb_thongtin.Size = new System.Drawing.Size(408, 354);
            this.gb_thongtin.TabIndex = 1;
            this.gb_thongtin.TabStop = false;
            this.gb_thongtin.Text = "Thông tin";
            // 
            // panel4
            // 
            this.panel4.Controls.Add(this.btn_save);
            this.panel4.Controls.Add(this.btn_close);
            this.panel4.Controls.Add(this.dtp_denngay);
            this.panel4.Controls.Add(this.dtp_tungay);
            this.panel4.Controls.Add(this.chk_active);
            this.panel4.Controls.Add(this.txt_ghichu);
            this.panel4.Controls.Add(this.txt_mucphucap);
            this.panel4.Controls.Add(this.cbo_loaiphucap);
            this.panel4.Controls.Add(this.label6);
            this.panel4.Controls.Add(this.label5);
            this.panel4.Controls.Add(this.label4);
            this.panel4.Controls.Add(this.label3);
            this.panel4.Controls.Add(this.label2);
            this.panel4.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel4.Location = new System.Drawing.Point(4, 20);
            this.panel4.Margin = new System.Windows.Forms.Padding(4);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(400, 330);
            this.panel4.TabIndex = 1;
            // 
            // btn_save
            // 
            this.btn_save.Image = global::TENTAC_HRM.Properties.Resources.diskette;
            this.btn_save.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btn_save.Location = new System.Drawing.Point(116, 286);
            this.btn_save.Margin = new System.Windows.Forms.Padding(4);
            this.btn_save.Name = "btn_save";
            this.btn_save.Size = new System.Drawing.Size(138, 31);
            this.btn_save.TabIndex = 6;
            this.btn_save.Text = "Lưu";
            this.btn_save.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btn_save.UseVisualStyleBackColor = true;
            this.btn_save.Click += new System.EventHandler(this.btn_save_Click);
            // 
            // btn_close
            // 
            this.btn_close.Image = global::TENTAC_HRM.Properties.Resources.clear;
            this.btn_close.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btn_close.Location = new System.Drawing.Point(262, 286);
            this.btn_close.Margin = new System.Windows.Forms.Padding(4);
            this.btn_close.Name = "btn_close";
            this.btn_close.Size = new System.Drawing.Size(114, 31);
            this.btn_close.TabIndex = 7;
            this.btn_close.Text = "Đóng";
            this.btn_close.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btn_close.UseVisualStyleBackColor = true;
            this.btn_close.Click += new System.EventHandler(this.btn_close_Click);
            // 
            // dtp_denngay
            // 
            this.dtp_denngay.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtp_denngay.Location = new System.Drawing.Point(116, 106);
            this.dtp_denngay.Name = "dtp_denngay";
            this.dtp_denngay.Size = new System.Drawing.Size(260, 23);
            this.dtp_denngay.TabIndex = 5;
            // 
            // dtp_tungay
            // 
            this.dtp_tungay.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtp_tungay.Location = new System.Drawing.Point(116, 77);
            this.dtp_tungay.Name = "dtp_tungay";
            this.dtp_tungay.Size = new System.Drawing.Size(260, 23);
            this.dtp_tungay.TabIndex = 5;
            // 
            // chk_active
            // 
            this.chk_active.AutoSize = true;
            this.chk_active.Location = new System.Drawing.Point(116, 258);
            this.chk_active.Name = "chk_active";
            this.chk_active.Size = new System.Drawing.Size(114, 21);
            this.chk_active.TabIndex = 3;
            this.chk_active.Text = "Đang hiệu lực";
            this.chk_active.UseVisualStyleBackColor = true;
            // 
            // txt_ghichu
            // 
            this.txt_ghichu.Location = new System.Drawing.Point(116, 135);
            this.txt_ghichu.Multiline = true;
            this.txt_ghichu.Name = "txt_ghichu";
            this.txt_ghichu.Size = new System.Drawing.Size(260, 115);
            this.txt_ghichu.TabIndex = 2;
            // 
            // txt_mucphucap
            // 
            this.txt_mucphucap.Location = new System.Drawing.Point(116, 48);
            this.txt_mucphucap.Name = "txt_mucphucap";
            this.txt_mucphucap.Size = new System.Drawing.Size(260, 23);
            this.txt_mucphucap.TabIndex = 2;
            // 
            // cbo_loaiphucap
            // 
            this.cbo_loaiphucap.FormattingEnabled = true;
            this.cbo_loaiphucap.Location = new System.Drawing.Point(116, 18);
            this.cbo_loaiphucap.Name = "cbo_loaiphucap";
            this.cbo_loaiphucap.Size = new System.Drawing.Size(260, 24);
            this.cbo_loaiphucap.TabIndex = 1;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(7, 140);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(43, 17);
            this.label6.TabIndex = 0;
            this.label6.Text = "Mô tả";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(7, 110);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(69, 17);
            this.label5.TabIndex = 0;
            this.label5.Text = "Đến ngày";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(7, 80);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(60, 17);
            this.label4.TabIndex = 0;
            this.label4.Text = "Từ ngày";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(7, 51);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(89, 17);
            this.label3.TabIndex = 0;
            this.label3.Text = "Mức phụ cấp";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(7, 21);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(90, 17);
            this.label2.TabIndex = 0;
            this.label2.Text = "Loại phụ cấp";
            // 
            // gb_nhanvien
            // 
            this.gb_nhanvien.Controls.Add(this.panel3);
            this.gb_nhanvien.Dock = System.Windows.Forms.DockStyle.Top;
            this.gb_nhanvien.Location = new System.Drawing.Point(0, 0);
            this.gb_nhanvien.Margin = new System.Windows.Forms.Padding(4);
            this.gb_nhanvien.Name = "gb_nhanvien";
            this.gb_nhanvien.Padding = new System.Windows.Forms.Padding(4);
            this.gb_nhanvien.Size = new System.Drawing.Size(408, 69);
            this.gb_nhanvien.TabIndex = 0;
            this.gb_nhanvien.TabStop = false;
            this.gb_nhanvien.Text = "Nhân viên";
            // 
            // panel3
            // 
            this.panel3.Controls.Add(this.cbo_nhanvien);
            this.panel3.Controls.Add(this.label1);
            this.panel3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel3.Location = new System.Drawing.Point(4, 20);
            this.panel3.Margin = new System.Windows.Forms.Padding(4);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(400, 45);
            this.panel3.TabIndex = 0;
            // 
            // cbo_nhanvien
            // 
            this.cbo_nhanvien.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Append;
            this.cbo_nhanvien.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.cbo_nhanvien.Enabled = false;
            this.cbo_nhanvien.FormattingEnabled = true;
            this.cbo_nhanvien.Location = new System.Drawing.Point(116, 10);
            this.cbo_nhanvien.Name = "cbo_nhanvien";
            this.cbo_nhanvien.Size = new System.Drawing.Size(260, 24);
            this.cbo_nhanvien.TabIndex = 3;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(7, 13);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(72, 17);
            this.label1.TabIndex = 2;
            this.label1.Text = "Nhân viên";
            // 
            // frm_staff_allowance
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(408, 423);
            this.Controls.Add(this.panel2);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.KeyPreview = true;
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "frm_staff_allowance";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Phụ cấp";
            this.Load += new System.EventHandler(this.frm_allowance_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.frm_allowance_KeyDown);
            this.panel2.ResumeLayout(false);
            this.gb_thongtin.ResumeLayout(false);
            this.panel4.ResumeLayout(false);
            this.panel4.PerformLayout();
            this.gb_nhanvien.ResumeLayout(false);
            this.panel3.ResumeLayout(false);
            this.panel3.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.GroupBox gb_thongtin;
        private System.Windows.Forms.Panel panel4;
        private System.Windows.Forms.GroupBox gb_nhanvien;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.ComboBox cbo_nhanvien;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.CheckBox chk_active;
        private System.Windows.Forms.TextBox txt_ghichu;
        private System.Windows.Forms.TextBox txt_mucphucap;
        private System.Windows.Forms.ComboBox cbo_loaiphucap;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.DateTimePicker dtp_denngay;
        private System.Windows.Forms.DateTimePicker dtp_tungay;
        public System.Windows.Forms.Button btn_save;
        private System.Windows.Forms.Button btn_close;
    }
}