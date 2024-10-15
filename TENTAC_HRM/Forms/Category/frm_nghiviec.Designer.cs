namespace TENTAC_HRM.Forms.Category
{
    partial class frm_nghiviec
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
            this.cbo_nhanvien = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.cbo_loai_nghiviec = new System.Windows.Forms.ComboBox();
            this.txt_so_qd = new System.Windows.Forms.TextBox();
            this.dtp_ngay_qt = new System.Windows.Forms.DateTimePicker();
            this.dtp_tungay = new System.Windows.Forms.DateTimePicker();
            this.dtp_denngay = new System.Windows.Forms.DateTimePicker();
            this.txt_noidung = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.cbo_trangthai = new System.Windows.Forms.ComboBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.btn_save = new System.Windows.Forms.Button();
            this.btn_close = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // cbo_nhanvien
            // 
            this.cbo_nhanvien.Enabled = false;
            this.cbo_nhanvien.FormattingEnabled = true;
            this.cbo_nhanvien.Location = new System.Drawing.Point(167, 12);
            this.cbo_nhanvien.Name = "cbo_nhanvien";
            this.cbo_nhanvien.Size = new System.Drawing.Size(232, 24);
            this.cbo_nhanvien.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(22, 15);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(72, 17);
            this.label1.TabIndex = 4;
            this.label1.Text = "Nhân viên";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(22, 45);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(95, 17);
            this.label2.TabIndex = 4;
            this.label2.Text = "Loại nghỉ việc";
            // 
            // cbo_loai_nghiviec
            // 
            this.cbo_loai_nghiviec.FormattingEnabled = true;
            this.cbo_loai_nghiviec.Location = new System.Drawing.Point(167, 42);
            this.cbo_loai_nghiviec.Name = "cbo_loai_nghiviec";
            this.cbo_loai_nghiviec.Size = new System.Drawing.Size(232, 24);
            this.cbo_loai_nghiviec.TabIndex = 1;
            // 
            // txt_so_qd
            // 
            this.txt_so_qd.Location = new System.Drawing.Point(167, 72);
            this.txt_so_qd.Name = "txt_so_qd";
            this.txt_so_qd.Size = new System.Drawing.Size(232, 23);
            this.txt_so_qd.TabIndex = 2;
            // 
            // dtp_ngay_qt
            // 
            this.dtp_ngay_qt.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtp_ngay_qt.Location = new System.Drawing.Point(167, 101);
            this.dtp_ngay_qt.Name = "dtp_ngay_qt";
            this.dtp_ngay_qt.Size = new System.Drawing.Size(232, 23);
            this.dtp_ngay_qt.TabIndex = 3;
            // 
            // dtp_tungay
            // 
            this.dtp_tungay.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtp_tungay.Location = new System.Drawing.Point(167, 130);
            this.dtp_tungay.Name = "dtp_tungay";
            this.dtp_tungay.Size = new System.Drawing.Size(232, 23);
            this.dtp_tungay.TabIndex = 4;
            // 
            // dtp_denngay
            // 
            this.dtp_denngay.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtp_denngay.Location = new System.Drawing.Point(167, 159);
            this.dtp_denngay.Name = "dtp_denngay";
            this.dtp_denngay.Size = new System.Drawing.Size(232, 23);
            this.dtp_denngay.TabIndex = 5;
            // 
            // txt_noidung
            // 
            this.txt_noidung.Location = new System.Drawing.Point(167, 188);
            this.txt_noidung.Multiline = true;
            this.txt_noidung.Name = "txt_noidung";
            this.txt_noidung.Size = new System.Drawing.Size(232, 66);
            this.txt_noidung.TabIndex = 6;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(22, 263);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(139, 17);
            this.label3.TabIndex = 4;
            this.label3.Text = "Trạng thái nhân viên";
            // 
            // cbo_trangthai
            // 
            this.cbo_trangthai.Enabled = false;
            this.cbo_trangthai.FormattingEnabled = true;
            this.cbo_trangthai.Location = new System.Drawing.Point(167, 260);
            this.cbo_trangthai.Name = "cbo_trangthai";
            this.cbo_trangthai.Size = new System.Drawing.Size(232, 24);
            this.cbo_trangthai.TabIndex = 7;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(22, 75);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(95, 17);
            this.label4.TabIndex = 4;
            this.label4.Text = "Số quyết định";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(22, 106);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(111, 17);
            this.label5.TabIndex = 4;
            this.label5.Text = "Ngày quyết định";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(22, 135);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(60, 17);
            this.label6.TabIndex = 4;
            this.label6.Text = "Từ ngày";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(22, 164);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(69, 17);
            this.label7.TabIndex = 4;
            this.label7.Text = "Đến ngày";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(22, 191);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(65, 17);
            this.label8.TabIndex = 4;
            this.label8.Text = "Nội dung";
            // 
            // btn_save
            // 
            this.btn_save.Image = global::TENTAC_HRM.Properties.Resources.diskette;
            this.btn_save.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btn_save.Location = new System.Drawing.Point(220, 290);
            this.btn_save.Name = "btn_save";
            this.btn_save.Size = new System.Drawing.Size(87, 28);
            this.btn_save.TabIndex = 8;
            this.btn_save.Text = "Lưu";
            this.btn_save.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btn_save.UseVisualStyleBackColor = true;
            this.btn_save.Click += new System.EventHandler(this.btn_save_Click);
            // 
            // btn_close
            // 
            this.btn_close.Image = global::TENTAC_HRM.Properties.Resources.clear;
            this.btn_close.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btn_close.Location = new System.Drawing.Point(313, 290);
            this.btn_close.Name = "btn_close";
            this.btn_close.Size = new System.Drawing.Size(86, 28);
            this.btn_close.TabIndex = 9;
            this.btn_close.Text = "Đóng";
            this.btn_close.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btn_close.UseVisualStyleBackColor = true;
            this.btn_close.Click += new System.EventHandler(this.btn_close_Click);
            // 
            // frm_nghiviec
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(421, 332);
            this.Controls.Add(this.btn_save);
            this.Controls.Add(this.btn_close);
            this.Controls.Add(this.dtp_denngay);
            this.Controls.Add(this.dtp_tungay);
            this.Controls.Add(this.dtp_ngay_qt);
            this.Controls.Add(this.txt_noidung);
            this.Controls.Add(this.txt_so_qd);
            this.Controls.Add(this.cbo_trangthai);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.cbo_loai_nghiviec);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.cbo_nhanvien);
            this.Controls.Add(this.label1);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "frm_nghiviec";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Nhân viên - Nghỉ việc";
            this.Load += new System.EventHandler(this.frm_nghiviec_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ComboBox cbo_nhanvien;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox cbo_loai_nghiviec;
        private System.Windows.Forms.TextBox txt_so_qd;
        private System.Windows.Forms.DateTimePicker dtp_ngay_qt;
        private System.Windows.Forms.DateTimePicker dtp_tungay;
        private System.Windows.Forms.DateTimePicker dtp_denngay;
        private System.Windows.Forms.TextBox txt_noidung;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ComboBox cbo_trangthai;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Button btn_close;
        private System.Windows.Forms.Button btn_save;
    }
}