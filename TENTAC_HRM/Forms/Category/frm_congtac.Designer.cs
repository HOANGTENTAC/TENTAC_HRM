namespace TENTAC_HRM.Forms.Category
{
    partial class frm_congtac
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
            this.dtp_denngay = new System.Windows.Forms.DateTimePicker();
            this.dtp_tungay = new System.Windows.Forms.DateTimePicker();
            this.txt_noidung = new System.Windows.Forms.TextBox();
            this.txt_dia_diem = new System.Windows.Forms.TextBox();
            this.txt_soquyetdinh = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.cbo_nhanvien = new System.Windows.Forms.ComboBox();
            this.btn_save = new System.Windows.Forms.Button();
            this.btn_close = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // dtp_denngay
            // 
            this.dtp_denngay.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtp_denngay.Location = new System.Drawing.Point(127, 152);
            this.dtp_denngay.Name = "dtp_denngay";
            this.dtp_denngay.Size = new System.Drawing.Size(227, 23);
            this.dtp_denngay.TabIndex = 17;
            // 
            // dtp_tungay
            // 
            this.dtp_tungay.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtp_tungay.Location = new System.Drawing.Point(127, 123);
            this.dtp_tungay.Name = "dtp_tungay";
            this.dtp_tungay.Size = new System.Drawing.Size(227, 23);
            this.dtp_tungay.TabIndex = 18;
            // 
            // txt_noidung
            // 
            this.txt_noidung.Location = new System.Drawing.Point(127, 181);
            this.txt_noidung.Multiline = true;
            this.txt_noidung.Name = "txt_noidung";
            this.txt_noidung.Size = new System.Drawing.Size(227, 148);
            this.txt_noidung.TabIndex = 14;
            // 
            // txt_dia_diem
            // 
            this.txt_dia_diem.Location = new System.Drawing.Point(127, 42);
            this.txt_dia_diem.Multiline = true;
            this.txt_dia_diem.Name = "txt_dia_diem";
            this.txt_dia_diem.Size = new System.Drawing.Size(227, 46);
            this.txt_dia_diem.TabIndex = 15;
            // 
            // txt_soquyetdinh
            // 
            this.txt_soquyetdinh.Location = new System.Drawing.Point(127, 94);
            this.txt_soquyetdinh.Name = "txt_soquyetdinh";
            this.txt_soquyetdinh.Size = new System.Drawing.Size(227, 23);
            this.txt_soquyetdinh.TabIndex = 16;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(13, 184);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(65, 17);
            this.label5.TabIndex = 8;
            this.label5.Text = "Nội dung";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(13, 157);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(69, 17);
            this.label4.TabIndex = 9;
            this.label4.Text = "Đến ngày";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(13, 45);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(63, 17);
            this.label6.TabIndex = 10;
            this.label6.Text = "Địa diểm";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(13, 128);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(60, 17);
            this.label3.TabIndex = 11;
            this.label3.Text = "Từ ngày";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(13, 97);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(95, 17);
            this.label2.TabIndex = 12;
            this.label2.Text = "Số quyết định";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(13, 15);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(72, 17);
            this.label1.TabIndex = 13;
            this.label1.Text = "Nhân viên";
            // 
            // cbo_nhanvien
            // 
            this.cbo_nhanvien.Enabled = false;
            this.cbo_nhanvien.FormattingEnabled = true;
            this.cbo_nhanvien.Location = new System.Drawing.Point(127, 12);
            this.cbo_nhanvien.Name = "cbo_nhanvien";
            this.cbo_nhanvien.Size = new System.Drawing.Size(227, 24);
            this.cbo_nhanvien.TabIndex = 7;
            // 
            // btn_save
            // 
            this.btn_save.Image = global::TENTAC_HRM.Properties.Resources.diskette;
            this.btn_save.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btn_save.Location = new System.Drawing.Point(127, 336);
            this.btn_save.Margin = new System.Windows.Forms.Padding(4);
            this.btn_save.Name = "btn_save";
            this.btn_save.Size = new System.Drawing.Size(119, 28);
            this.btn_save.TabIndex = 5;
            this.btn_save.Text = "Lưu";
            this.btn_save.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btn_save.UseVisualStyleBackColor = true;
            this.btn_save.Click += new System.EventHandler(this.btn_save_Click);
            // 
            // btn_close
            // 
            this.btn_close.Image = global::TENTAC_HRM.Properties.Resources.clear;
            this.btn_close.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btn_close.Location = new System.Drawing.Point(254, 336);
            this.btn_close.Margin = new System.Windows.Forms.Padding(4);
            this.btn_close.Name = "btn_close";
            this.btn_close.Size = new System.Drawing.Size(100, 28);
            this.btn_close.TabIndex = 6;
            this.btn_close.Text = "Đóng";
            this.btn_close.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btn_close.UseVisualStyleBackColor = true;
            this.btn_close.Click += new System.EventHandler(this.btn_close_Click);
            // 
            // frm_congtac
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(369, 388);
            this.Controls.Add(this.dtp_denngay);
            this.Controls.Add(this.dtp_tungay);
            this.Controls.Add(this.txt_noidung);
            this.Controls.Add(this.txt_dia_diem);
            this.Controls.Add(this.txt_soquyetdinh);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.cbo_nhanvien);
            this.Controls.Add(this.btn_save);
            this.Controls.Add(this.btn_close);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "frm_congtac";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Nhân viên - Công tác";
            this.Load += new System.EventHandler(this.frm_congtac_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DateTimePicker dtp_denngay;
        private System.Windows.Forms.DateTimePicker dtp_tungay;
        private System.Windows.Forms.TextBox txt_noidung;
        private System.Windows.Forms.TextBox txt_dia_diem;
        private System.Windows.Forms.TextBox txt_soquyetdinh;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox cbo_nhanvien;
        public System.Windows.Forms.Button btn_save;
        private System.Windows.Forms.Button btn_close;
    }
}