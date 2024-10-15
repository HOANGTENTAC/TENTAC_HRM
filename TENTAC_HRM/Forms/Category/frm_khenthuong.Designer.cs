namespace TENTAC_HRM.Forms.Category
{
    partial class frm_khenthuong
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
            this.pl_khenthuong = new System.Windows.Forms.Panel();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.btn_save = new System.Windows.Forms.Button();
            this.btn_cancel = new System.Windows.Forms.Button();
            this.dtp_ngaykhenthuong = new System.Windows.Forms.DateTimePicker();
            this.cbo_nguoiky = new System.Windows.Forms.ComboBox();
            this.cbo_cap = new System.Windows.Forms.ComboBox();
            this.label6 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.txt_sotien = new System.Windows.Forms.TextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.txt_noidung = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.txt_lydo = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.txt_hinhthuc = new System.Windows.Forms.TextBox();
            this.txt_soquyetdinh = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.cbo_nhanvien = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.pl_khenthuong.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // pl_khenthuong
            // 
            this.pl_khenthuong.Controls.Add(this.groupBox2);
            this.pl_khenthuong.Controls.Add(this.groupBox1);
            this.pl_khenthuong.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pl_khenthuong.Location = new System.Drawing.Point(0, 0);
            this.pl_khenthuong.Name = "pl_khenthuong";
            this.pl_khenthuong.Size = new System.Drawing.Size(396, 508);
            this.pl_khenthuong.TabIndex = 2;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.btn_save);
            this.groupBox2.Controls.Add(this.btn_cancel);
            this.groupBox2.Controls.Add(this.dtp_ngaykhenthuong);
            this.groupBox2.Controls.Add(this.cbo_nguoiky);
            this.groupBox2.Controls.Add(this.cbo_cap);
            this.groupBox2.Controls.Add(this.label6);
            this.groupBox2.Controls.Add(this.label4);
            this.groupBox2.Controls.Add(this.label5);
            this.groupBox2.Controls.Add(this.txt_sotien);
            this.groupBox2.Controls.Add(this.label9);
            this.groupBox2.Controls.Add(this.label8);
            this.groupBox2.Controls.Add(this.txt_noidung);
            this.groupBox2.Controls.Add(this.label2);
            this.groupBox2.Controls.Add(this.txt_lydo);
            this.groupBox2.Controls.Add(this.label7);
            this.groupBox2.Controls.Add(this.txt_hinhthuc);
            this.groupBox2.Controls.Add(this.txt_soquyetdinh);
            this.groupBox2.Controls.Add(this.label3);
            this.groupBox2.Dock = System.Windows.Forms.DockStyle.Top;
            this.groupBox2.Location = new System.Drawing.Point(0, 59);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(396, 449);
            this.groupBox2.TabIndex = 1;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Thông tin";
            // 
            // btn_save
            // 
            this.btn_save.Image = global::TENTAC_HRM.Properties.Resources.diskette;
            this.btn_save.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btn_save.Location = new System.Drawing.Point(148, 400);
            this.btn_save.Name = "btn_save";
            this.btn_save.Size = new System.Drawing.Size(122, 33);
            this.btn_save.TabIndex = 4;
            this.btn_save.Text = "Lưu";
            this.btn_save.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btn_save.UseVisualStyleBackColor = true;
            this.btn_save.Click += new System.EventHandler(this.btn_save_Click);
            // 
            // btn_cancel
            // 
            this.btn_cancel.Image = global::TENTAC_HRM.Properties.Resources.clear;
            this.btn_cancel.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btn_cancel.Location = new System.Drawing.Point(276, 400);
            this.btn_cancel.Name = "btn_cancel";
            this.btn_cancel.Size = new System.Drawing.Size(99, 33);
            this.btn_cancel.TabIndex = 4;
            this.btn_cancel.Text = "Đóng";
            this.btn_cancel.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btn_cancel.UseVisualStyleBackColor = true;
            this.btn_cancel.Click += new System.EventHandler(this.btn_cancel_Click);
            // 
            // dtp_ngaykhenthuong
            // 
            this.dtp_ngaykhenthuong.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtp_ngaykhenthuong.Location = new System.Drawing.Point(148, 51);
            this.dtp_ngaykhenthuong.Name = "dtp_ngaykhenthuong";
            this.dtp_ngaykhenthuong.Size = new System.Drawing.Size(227, 23);
            this.dtp_ngaykhenthuong.TabIndex = 3;
            // 
            // cbo_nguoiky
            // 
            this.cbo_nguoiky.FormattingEnabled = true;
            this.cbo_nguoiky.Location = new System.Drawing.Point(148, 232);
            this.cbo_nguoiky.Name = "cbo_nguoiky";
            this.cbo_nguoiky.Size = new System.Drawing.Size(227, 24);
            this.cbo_nguoiky.TabIndex = 1;
            // 
            // cbo_cap
            // 
            this.cbo_cap.FormattingEnabled = true;
            this.cbo_cap.Location = new System.Drawing.Point(148, 110);
            this.cbo_cap.Name = "cbo_cap";
            this.cbo_cap.Size = new System.Drawing.Size(227, 24);
            this.cbo_cap.TabIndex = 1;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(18, 113);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(33, 17);
            this.label6.TabIndex = 0;
            this.label6.Text = "Cấp";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(18, 54);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(124, 17);
            this.label4.TabIndex = 0;
            this.label4.Text = "Ngày khen thưởng";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(18, 83);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(68, 17);
            this.label5.TabIndex = 0;
            this.label5.Text = "Hình thức";
            // 
            // txt_sotien
            // 
            this.txt_sotien.Location = new System.Drawing.Point(148, 203);
            this.txt_sotien.Name = "txt_sotien";
            this.txt_sotien.Size = new System.Drawing.Size(227, 23);
            this.txt_sotien.TabIndex = 2;
            this.txt_sotien.Text = "0";
            this.txt_sotien.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txt_sotien_KeyPress);
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(18, 235);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(63, 17);
            this.label9.TabIndex = 0;
            this.label9.Text = "Người ký";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(18, 206);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(52, 17);
            this.label8.TabIndex = 0;
            this.label8.Text = "Số tiền";
            // 
            // txt_noidung
            // 
            this.txt_noidung.Location = new System.Drawing.Point(148, 262);
            this.txt_noidung.Multiline = true;
            this.txt_noidung.Name = "txt_noidung";
            this.txt_noidung.Size = new System.Drawing.Size(227, 132);
            this.txt_noidung.TabIndex = 2;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(18, 265);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(65, 17);
            this.label2.TabIndex = 0;
            this.label2.Text = "Nội dung";
            // 
            // txt_lydo
            // 
            this.txt_lydo.Location = new System.Drawing.Point(148, 140);
            this.txt_lydo.Multiline = true;
            this.txt_lydo.Name = "txt_lydo";
            this.txt_lydo.Size = new System.Drawing.Size(227, 57);
            this.txt_lydo.TabIndex = 2;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(18, 143);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(43, 17);
            this.label7.TabIndex = 0;
            this.label7.Text = "Lý do";
            // 
            // txt_hinhthuc
            // 
            this.txt_hinhthuc.Location = new System.Drawing.Point(148, 80);
            this.txt_hinhthuc.Name = "txt_hinhthuc";
            this.txt_hinhthuc.Size = new System.Drawing.Size(227, 23);
            this.txt_hinhthuc.TabIndex = 2;
            // 
            // txt_soquyetdinh
            // 
            this.txt_soquyetdinh.Location = new System.Drawing.Point(148, 22);
            this.txt_soquyetdinh.Name = "txt_soquyetdinh";
            this.txt_soquyetdinh.Size = new System.Drawing.Size(227, 23);
            this.txt_soquyetdinh.TabIndex = 2;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(18, 25);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(95, 17);
            this.label3.TabIndex = 0;
            this.label3.Text = "Số quyết định";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.cbo_nhanvien);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Dock = System.Windows.Forms.DockStyle.Top;
            this.groupBox1.Location = new System.Drawing.Point(0, 0);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(396, 59);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Nhân viên";
            // 
            // cbo_nhanvien
            // 
            this.cbo_nhanvien.Enabled = false;
            this.cbo_nhanvien.FormattingEnabled = true;
            this.cbo_nhanvien.Location = new System.Drawing.Point(148, 22);
            this.cbo_nhanvien.Name = "cbo_nhanvien";
            this.cbo_nhanvien.Size = new System.Drawing.Size(227, 24);
            this.cbo_nhanvien.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(18, 25);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(72, 17);
            this.label1.TabIndex = 0;
            this.label1.Text = "Nhân viên";
            // 
            // frm_khenthuong
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(396, 508);
            this.Controls.Add(this.pl_khenthuong);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "frm_khenthuong";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Nhân viên - Khen thưởng";
            this.Load += new System.EventHandler(this.frm_khenthuong_Load);
            this.pl_khenthuong.ResumeLayout(false);
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel pl_khenthuong;
        private System.Windows.Forms.GroupBox groupBox2;
        public System.Windows.Forms.Button btn_save;
        private System.Windows.Forms.Button btn_cancel;
        private System.Windows.Forms.DateTimePicker dtp_ngaykhenthuong;
        private System.Windows.Forms.ComboBox cbo_nguoiky;
        private System.Windows.Forms.ComboBox cbo_cap;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox txt_sotien;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.TextBox txt_noidung;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txt_lydo;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox txt_hinhthuc;
        private System.Windows.Forms.TextBox txt_soquyetdinh;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.ComboBox cbo_nhanvien;
        private System.Windows.Forms.Label label1;
    }
}