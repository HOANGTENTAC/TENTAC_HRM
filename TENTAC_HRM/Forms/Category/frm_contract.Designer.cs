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
            this.pl_hopdong = new System.Windows.Forms.Panel();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.panel3 = new System.Windows.Forms.Panel();
            this.chk_active = new System.Windows.Forms.CheckBox();
            this.btn_save = new System.Windows.Forms.Button();
            this.cbo_loaihopdong = new System.Windows.Forms.ComboBox();
            this.btn_close = new System.Windows.Forms.Button();
            this.txt_nguoiky = new System.Windows.Forms.TextBox();
            this.txt_ghichu = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.dtp_ngayky = new System.Windows.Forms.DateTimePicker();
            this.txt_sohopdong = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.dtp_tungay = new System.Windows.Forms.DateTimePicker();
            this.dtp_denngay = new System.Windows.Forms.DateTimePicker();
            this.label7 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.panel2 = new System.Windows.Forms.Panel();
            this.cbo_nhanvien = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.pl_hopdong.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.panel3.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // pl_hopdong
            // 
            this.pl_hopdong.Controls.Add(this.groupBox2);
            this.pl_hopdong.Controls.Add(this.groupBox1);
            this.pl_hopdong.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pl_hopdong.Location = new System.Drawing.Point(0, 0);
            this.pl_hopdong.Margin = new System.Windows.Forms.Padding(4);
            this.pl_hopdong.Name = "pl_hopdong";
            this.pl_hopdong.Size = new System.Drawing.Size(383, 489);
            this.pl_hopdong.TabIndex = 7;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.panel3);
            this.groupBox2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox2.Location = new System.Drawing.Point(0, 68);
            this.groupBox2.Margin = new System.Windows.Forms.Padding(4);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Padding = new System.Windows.Forms.Padding(4);
            this.groupBox2.Size = new System.Drawing.Size(383, 421);
            this.groupBox2.TabIndex = 6;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Thông tin";
            // 
            // panel3
            // 
            this.panel3.Controls.Add(this.chk_active);
            this.panel3.Controls.Add(this.btn_save);
            this.panel3.Controls.Add(this.cbo_loaihopdong);
            this.panel3.Controls.Add(this.btn_close);
            this.panel3.Controls.Add(this.txt_nguoiky);
            this.panel3.Controls.Add(this.txt_ghichu);
            this.panel3.Controls.Add(this.label8);
            this.panel3.Controls.Add(this.dtp_ngayky);
            this.panel3.Controls.Add(this.txt_sohopdong);
            this.panel3.Controls.Add(this.label4);
            this.panel3.Controls.Add(this.dtp_tungay);
            this.panel3.Controls.Add(this.dtp_denngay);
            this.panel3.Controls.Add(this.label7);
            this.panel3.Controls.Add(this.label5);
            this.panel3.Controls.Add(this.label9);
            this.panel3.Controls.Add(this.label10);
            this.panel3.Controls.Add(this.label6);
            this.panel3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel3.Location = new System.Drawing.Point(4, 20);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(375, 397);
            this.panel3.TabIndex = 9;
            // 
            // chk_active
            // 
            this.chk_active.AutoSize = true;
            this.chk_active.Location = new System.Drawing.Point(130, 329);
            this.chk_active.Margin = new System.Windows.Forms.Padding(4);
            this.chk_active.Name = "chk_active";
            this.chk_active.Size = new System.Drawing.Size(78, 21);
            this.chk_active.TabIndex = 7;
            this.chk_active.Text = "Hiệu lực";
            this.chk_active.UseVisualStyleBackColor = true;
            // 
            // btn_save
            // 
            this.btn_save.Image = global::TENTAC_HRM.Properties.Resources.diskette;
            this.btn_save.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btn_save.Location = new System.Drawing.Point(130, 358);
            this.btn_save.Margin = new System.Windows.Forms.Padding(4);
            this.btn_save.Name = "btn_save";
            this.btn_save.Size = new System.Drawing.Size(122, 28);
            this.btn_save.TabIndex = 8;
            this.btn_save.Text = "Lưu & Đóng";
            this.btn_save.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btn_save.UseMnemonic = false;
            this.btn_save.UseVisualStyleBackColor = true;
            this.btn_save.Click += new System.EventHandler(this.btn_save_Click);
            // 
            // cbo_loaihopdong
            // 
            this.cbo_loaihopdong.FormattingEnabled = true;
            this.cbo_loaihopdong.Location = new System.Drawing.Point(130, 10);
            this.cbo_loaihopdong.Margin = new System.Windows.Forms.Padding(4);
            this.cbo_loaihopdong.Name = "cbo_loaihopdong";
            this.cbo_loaihopdong.Size = new System.Drawing.Size(224, 24);
            this.cbo_loaihopdong.TabIndex = 0;
            // 
            // btn_close
            // 
            this.btn_close.Image = global::TENTAC_HRM.Properties.Resources.clear;
            this.btn_close.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btn_close.Location = new System.Drawing.Point(260, 358);
            this.btn_close.Margin = new System.Windows.Forms.Padding(4);
            this.btn_close.Name = "btn_close";
            this.btn_close.Size = new System.Drawing.Size(94, 28);
            this.btn_close.TabIndex = 9;
            this.btn_close.Text = "Đóng";
            this.btn_close.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btn_close.UseVisualStyleBackColor = true;
            this.btn_close.Click += new System.EventHandler(this.btn_close_Click_1);
            // 
            // txt_nguoiky
            // 
            this.txt_nguoiky.Location = new System.Drawing.Point(130, 190);
            this.txt_nguoiky.Margin = new System.Windows.Forms.Padding(4);
            this.txt_nguoiky.Name = "txt_nguoiky";
            this.txt_nguoiky.Size = new System.Drawing.Size(224, 23);
            this.txt_nguoiky.TabIndex = 5;
            // 
            // txt_ghichu
            // 
            this.txt_ghichu.Location = new System.Drawing.Point(130, 221);
            this.txt_ghichu.Margin = new System.Windows.Forms.Padding(4);
            this.txt_ghichu.Multiline = true;
            this.txt_ghichu.Name = "txt_ghichu";
            this.txt_ghichu.Size = new System.Drawing.Size(224, 100);
            this.txt_ghichu.TabIndex = 6;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(23, 160);
            this.label8.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(59, 17);
            this.label8.TabIndex = 0;
            this.label8.Text = "Ngày ký";
            // 
            // dtp_ngayky
            // 
            this.dtp_ngayky.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtp_ngayky.Location = new System.Drawing.Point(130, 154);
            this.dtp_ngayky.Margin = new System.Windows.Forms.Padding(4);
            this.dtp_ngayky.Name = "dtp_ngayky";
            this.dtp_ngayky.Size = new System.Drawing.Size(224, 23);
            this.dtp_ngayky.TabIndex = 4;
            // 
            // txt_sohopdong
            // 
            this.txt_sohopdong.Location = new System.Drawing.Point(130, 47);
            this.txt_sohopdong.Margin = new System.Windows.Forms.Padding(4);
            this.txt_sohopdong.Name = "txt_sohopdong";
            this.txt_sohopdong.Size = new System.Drawing.Size(224, 23);
            this.txt_sohopdong.TabIndex = 1;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(23, 13);
            this.label4.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(99, 17);
            this.label4.TabIndex = 0;
            this.label4.Text = "Loại hợp đồng";
            // 
            // dtp_tungay
            // 
            this.dtp_tungay.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtp_tungay.Location = new System.Drawing.Point(130, 83);
            this.dtp_tungay.Margin = new System.Windows.Forms.Padding(4);
            this.dtp_tungay.Name = "dtp_tungay";
            this.dtp_tungay.Size = new System.Drawing.Size(224, 23);
            this.dtp_tungay.TabIndex = 2;
            // 
            // dtp_denngay
            // 
            this.dtp_denngay.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtp_denngay.Location = new System.Drawing.Point(130, 119);
            this.dtp_denngay.Margin = new System.Windows.Forms.Padding(4);
            this.dtp_denngay.Name = "dtp_denngay";
            this.dtp_denngay.Size = new System.Drawing.Size(224, 23);
            this.dtp_denngay.TabIndex = 3;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(23, 124);
            this.label7.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(69, 17);
            this.label7.TabIndex = 0;
            this.label7.Text = "Đến ngày";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(23, 50);
            this.label5.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(89, 17);
            this.label5.TabIndex = 0;
            this.label5.Text = "Số hợp đồng";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(23, 193);
            this.label9.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(63, 17);
            this.label9.TabIndex = 0;
            this.label9.Text = "Người ký";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(23, 224);
            this.label10.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(43, 17);
            this.label10.TabIndex = 0;
            this.label10.Text = "Mô tả";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(23, 88);
            this.label6.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(60, 17);
            this.label6.TabIndex = 0;
            this.label6.Text = "Từ ngày";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.panel2);
            this.groupBox1.Dock = System.Windows.Forms.DockStyle.Top;
            this.groupBox1.Location = new System.Drawing.Point(0, 0);
            this.groupBox1.Margin = new System.Windows.Forms.Padding(4);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Padding = new System.Windows.Forms.Padding(4);
            this.groupBox1.Size = new System.Drawing.Size(383, 68);
            this.groupBox1.TabIndex = 5;
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
            this.panel2.Size = new System.Drawing.Size(375, 44);
            this.panel2.TabIndex = 2;
            // 
            // cbo_nhanvien
            // 
            this.cbo_nhanvien.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Append;
            this.cbo_nhanvien.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.CustomSource;
            this.cbo_nhanvien.Enabled = false;
            this.cbo_nhanvien.FormattingEnabled = true;
            this.cbo_nhanvien.Location = new System.Drawing.Point(130, 11);
            this.cbo_nhanvien.Margin = new System.Windows.Forms.Padding(4);
            this.cbo_nhanvien.Name = "cbo_nhanvien";
            this.cbo_nhanvien.Size = new System.Drawing.Size(224, 24);
            this.cbo_nhanvien.TabIndex = 0;
            this.cbo_nhanvien.TextUpdate += new System.EventHandler(this.cbo_nhanvien_TextUpdate);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(23, 14);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(72, 17);
            this.label1.TabIndex = 0;
            this.label1.Text = "Nhân viên";
            // 
            // frm_contract
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.ClientSize = new System.Drawing.Size(383, 489);
            this.Controls.Add(this.pl_hopdong);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.KeyPreview = true;
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "frm_contract";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Hợp đồng";
            this.Load += new System.EventHandler(this.frm_contract_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.frm_contract_KeyDown);
            this.pl_hopdong.ResumeLayout(false);
            this.groupBox2.ResumeLayout(false);
            this.panel3.ResumeLayout(false);
            this.panel3.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Panel pl_hopdong;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.CheckBox chk_active;
        private System.Windows.Forms.ComboBox cbo_loaihopdong;
        private System.Windows.Forms.DateTimePicker dtp_ngayky;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.DateTimePicker dtp_denngay;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.DateTimePicker dtp_tungay;
        private System.Windows.Forms.TextBox txt_sohopdong;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.TextBox txt_ghichu;
        private System.Windows.Forms.TextBox txt_nguoiky;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.ComboBox cbo_nhanvien;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btn_save;
        private System.Windows.Forms.Button btn_close;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Panel panel2;
    }
}