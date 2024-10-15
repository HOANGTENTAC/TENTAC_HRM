namespace TENTAC_HRM.Forms.Category
{
    partial class frm_daotao
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
            this.txt_so_qd = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.dtp_tu_ngay = new System.Windows.Forms.DateTimePicker();
            this.dtp_den_ngay = new System.Windows.Forms.DateTimePicker();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.txt_hinh_thuc = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.txt_noi_dung = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.btn_close = new System.Windows.Forms.Button();
            this.btn_save = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // cbo_nhanvien
            // 
            this.cbo_nhanvien.Enabled = false;
            this.cbo_nhanvien.FormattingEnabled = true;
            this.cbo_nhanvien.Location = new System.Drawing.Point(123, 12);
            this.cbo_nhanvien.Name = "cbo_nhanvien";
            this.cbo_nhanvien.Size = new System.Drawing.Size(232, 24);
            this.cbo_nhanvien.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(13, 15);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(72, 17);
            this.label1.TabIndex = 2;
            this.label1.Text = "Nhân viên";
            // 
            // txt_so_qd
            // 
            this.txt_so_qd.Location = new System.Drawing.Point(123, 42);
            this.txt_so_qd.Name = "txt_so_qd";
            this.txt_so_qd.Size = new System.Drawing.Size(232, 23);
            this.txt_so_qd.TabIndex = 1;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(13, 45);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(95, 17);
            this.label2.TabIndex = 2;
            this.label2.Text = "Số quyết định";
            // 
            // dtp_tu_ngay
            // 
            this.dtp_tu_ngay.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtp_tu_ngay.Location = new System.Drawing.Point(123, 71);
            this.dtp_tu_ngay.Name = "dtp_tu_ngay";
            this.dtp_tu_ngay.Size = new System.Drawing.Size(232, 23);
            this.dtp_tu_ngay.TabIndex = 2;
            // 
            // dtp_den_ngay
            // 
            this.dtp_den_ngay.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtp_den_ngay.Location = new System.Drawing.Point(123, 100);
            this.dtp_den_ngay.Name = "dtp_den_ngay";
            this.dtp_den_ngay.Size = new System.Drawing.Size(232, 23);
            this.dtp_den_ngay.TabIndex = 3;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(13, 76);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(60, 17);
            this.label3.TabIndex = 2;
            this.label3.Text = "Từ ngày";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(13, 105);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(69, 17);
            this.label4.TabIndex = 2;
            this.label4.Text = "Đến ngày";
            // 
            // txt_hinh_thuc
            // 
            this.txt_hinh_thuc.Location = new System.Drawing.Point(123, 129);
            this.txt_hinh_thuc.Name = "txt_hinh_thuc";
            this.txt_hinh_thuc.Size = new System.Drawing.Size(232, 23);
            this.txt_hinh_thuc.TabIndex = 4;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(13, 132);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(68, 17);
            this.label5.TabIndex = 2;
            this.label5.Text = "Hình thức";
            // 
            // txt_noi_dung
            // 
            this.txt_noi_dung.Location = new System.Drawing.Point(123, 158);
            this.txt_noi_dung.Multiline = true;
            this.txt_noi_dung.Name = "txt_noi_dung";
            this.txt_noi_dung.Size = new System.Drawing.Size(232, 69);
            this.txt_noi_dung.TabIndex = 5;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(13, 161);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(65, 17);
            this.label6.TabIndex = 2;
            this.label6.Text = "Nội dung";
            // 
            // btn_close
            // 
            this.btn_close.Image = global::TENTAC_HRM.Properties.Resources.clear;
            this.btn_close.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btn_close.Location = new System.Drawing.Point(262, 233);
            this.btn_close.Name = "btn_close";
            this.btn_close.Size = new System.Drawing.Size(93, 36);
            this.btn_close.TabIndex = 7;
            this.btn_close.Text = "Đóng";
            this.btn_close.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btn_close.UseVisualStyleBackColor = true;
            this.btn_close.Click += new System.EventHandler(this.btn_close_Click);
            // 
            // btn_save
            // 
            this.btn_save.Image = global::TENTAC_HRM.Properties.Resources.diskette;
            this.btn_save.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btn_save.Location = new System.Drawing.Point(164, 233);
            this.btn_save.Name = "btn_save";
            this.btn_save.Size = new System.Drawing.Size(92, 36);
            this.btn_save.TabIndex = 6;
            this.btn_save.Text = "Lưu";
            this.btn_save.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btn_save.UseVisualStyleBackColor = true;
            this.btn_save.Click += new System.EventHandler(this.btn_save_Click);
            // 
            // frm_daotao
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(376, 281);
            this.Controls.Add(this.btn_save);
            this.Controls.Add(this.btn_close);
            this.Controls.Add(this.txt_noi_dung);
            this.Controls.Add(this.txt_hinh_thuc);
            this.Controls.Add(this.dtp_den_ngay);
            this.Controls.Add(this.dtp_tu_ngay);
            this.Controls.Add(this.txt_so_qd);
            this.Controls.Add(this.cbo_nhanvien);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "frm_daotao";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Nhân viên - Đào tạo";
            this.Load += new System.EventHandler(this.frm_daotao_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ComboBox cbo_nhanvien;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txt_so_qd;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.DateTimePicker dtp_tu_ngay;
        private System.Windows.Forms.DateTimePicker dtp_den_ngay;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txt_hinh_thuc;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox txt_noi_dung;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Button btn_close;
        private System.Windows.Forms.Button btn_save;
    }
}