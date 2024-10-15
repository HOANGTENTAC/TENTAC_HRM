namespace TENTAC_HRM.Forms.Category
{
    partial class frm_danhgia
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
            this.label1 = new System.Windows.Forms.Label();
            this.cbo_nhanvien = new System.Windows.Forms.ComboBox();
            this.nr_diem_danhgia = new System.Windows.Forms.NumericUpDown();
            this.txt_xep_loai = new System.Windows.Forms.TextBox();
            this.dtp_ngay_danhgia = new System.Windows.Forms.DateTimePicker();
            this.txt_noi_dung = new System.Windows.Forms.TextBox();
            this.btn_close = new System.Windows.Forms.Button();
            this.btn_save = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.btn_save_exit = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.nr_diem_danhgia)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(24, 20);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(72, 17);
            this.label1.TabIndex = 0;
            this.label1.Text = "Nhân viên";
            // 
            // cbo_nhanvien
            // 
            this.cbo_nhanvien.Enabled = false;
            this.cbo_nhanvien.FormattingEnabled = true;
            this.cbo_nhanvien.Location = new System.Drawing.Point(134, 17);
            this.cbo_nhanvien.Name = "cbo_nhanvien";
            this.cbo_nhanvien.Size = new System.Drawing.Size(232, 24);
            this.cbo_nhanvien.TabIndex = 0;
            // 
            // nr_diem_danhgia
            // 
            this.nr_diem_danhgia.Location = new System.Drawing.Point(134, 76);
            this.nr_diem_danhgia.Name = "nr_diem_danhgia";
            this.nr_diem_danhgia.Size = new System.Drawing.Size(232, 23);
            this.nr_diem_danhgia.TabIndex = 2;
            // 
            // txt_xep_loai
            // 
            this.txt_xep_loai.Location = new System.Drawing.Point(134, 105);
            this.txt_xep_loai.Name = "txt_xep_loai";
            this.txt_xep_loai.Size = new System.Drawing.Size(232, 23);
            this.txt_xep_loai.TabIndex = 3;
            // 
            // dtp_ngay_danhgia
            // 
            this.dtp_ngay_danhgia.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtp_ngay_danhgia.Location = new System.Drawing.Point(134, 47);
            this.dtp_ngay_danhgia.Name = "dtp_ngay_danhgia";
            this.dtp_ngay_danhgia.Size = new System.Drawing.Size(232, 23);
            this.dtp_ngay_danhgia.TabIndex = 1;
            // 
            // txt_noi_dung
            // 
            this.txt_noi_dung.Location = new System.Drawing.Point(134, 134);
            this.txt_noi_dung.Multiline = true;
            this.txt_noi_dung.Name = "txt_noi_dung";
            this.txt_noi_dung.Size = new System.Drawing.Size(232, 72);
            this.txt_noi_dung.TabIndex = 4;
            // 
            // btn_close
            // 
            this.btn_close.Image = global::TENTAC_HRM.Properties.Resources.clear;
            this.btn_close.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btn_close.Location = new System.Drawing.Point(281, 212);
            this.btn_close.Name = "btn_close";
            this.btn_close.Size = new System.Drawing.Size(85, 32);
            this.btn_close.TabIndex = 6;
            this.btn_close.Text = "Đóng";
            this.btn_close.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btn_close.UseVisualStyleBackColor = true;
            this.btn_close.Click += new System.EventHandler(this.btn_close_Click);
            // 
            // btn_save
            // 
            this.btn_save.Image = global::TENTAC_HRM.Properties.Resources.diskette;
            this.btn_save.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btn_save.Location = new System.Drawing.Point(27, 212);
            this.btn_save.Name = "btn_save";
            this.btn_save.Size = new System.Drawing.Size(121, 32);
            this.btn_save.TabIndex = 5;
            this.btn_save.Text = "Lưu & Thêm";
            this.btn_save.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btn_save.UseMnemonic = false;
            this.btn_save.UseVisualStyleBackColor = true;
            this.btn_save.Click += new System.EventHandler(this.btn_save_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(24, 52);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(100, 17);
            this.label2.TabIndex = 0;
            this.label2.Text = "Ngày dánh giá";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(24, 78);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(99, 17);
            this.label3.TabIndex = 0;
            this.label3.Text = "Điểm đánh giá";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(24, 108);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(59, 17);
            this.label4.TabIndex = 0;
            this.label4.Text = "Xếp loại";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(24, 137);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(65, 17);
            this.label5.TabIndex = 0;
            this.label5.Text = "Nội dung";
            // 
            // btn_save_exit
            // 
            this.btn_save_exit.Image = global::TENTAC_HRM.Properties.Resources.diskette;
            this.btn_save_exit.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btn_save_exit.Location = new System.Drawing.Point(154, 212);
            this.btn_save_exit.Name = "btn_save_exit";
            this.btn_save_exit.Size = new System.Drawing.Size(121, 32);
            this.btn_save_exit.TabIndex = 5;
            this.btn_save_exit.Text = "Lưu & Thoát";
            this.btn_save_exit.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btn_save_exit.UseMnemonic = false;
            this.btn_save_exit.UseVisualStyleBackColor = true;
            this.btn_save_exit.Click += new System.EventHandler(this.btn_save_exit_Click);
            // 
            // frm_danhgia
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(391, 256);
            this.Controls.Add(this.btn_save_exit);
            this.Controls.Add(this.btn_save);
            this.Controls.Add(this.btn_close);
            this.Controls.Add(this.dtp_ngay_danhgia);
            this.Controls.Add(this.txt_noi_dung);
            this.Controls.Add(this.txt_xep_loai);
            this.Controls.Add(this.nr_diem_danhgia);
            this.Controls.Add(this.cbo_nhanvien);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "frm_danhgia";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Nhân viên - Đánh giá";
            this.Load += new System.EventHandler(this.frm_danhgia_Load);
            ((System.ComponentModel.ISupportInitialize)(this.nr_diem_danhgia)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox cbo_nhanvien;
        private System.Windows.Forms.NumericUpDown nr_diem_danhgia;
        private System.Windows.Forms.TextBox txt_xep_loai;
        private System.Windows.Forms.DateTimePicker dtp_ngay_danhgia;
        private System.Windows.Forms.TextBox txt_noi_dung;
        private System.Windows.Forms.Button btn_close;
        private System.Windows.Forms.Button btn_save;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Button btn_save_exit;
    }
}