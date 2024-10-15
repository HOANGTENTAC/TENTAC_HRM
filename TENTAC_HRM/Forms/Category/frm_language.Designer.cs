namespace TENTAC_HRM.Forms.Category
{
    partial class frm_language
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
            this.btn_save = new System.Windows.Forms.Button();
            this.btn_close = new System.Windows.Forms.Button();
            this.dtp_nam = new System.Windows.Forms.DateTimePicker();
            this.txt_truong = new System.Windows.Forms.TextBox();
            this.txt_tinhoc = new System.Windows.Forms.TextBox();
            this.cbo_xeploai = new System.Windows.Forms.ComboBox();
            this.cbo_nhanvien = new System.Windows.Forms.ComboBox();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // btn_save
            // 
            this.btn_save.Image = global::TENTAC_HRM.Properties.Resources.diskette;
            this.btn_save.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btn_save.Location = new System.Drawing.Point(137, 159);
            this.btn_save.Name = "btn_save";
            this.btn_save.Size = new System.Drawing.Size(103, 27);
            this.btn_save.TabIndex = 5;
            this.btn_save.Text = "Lưu";
            this.btn_save.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btn_save.UseVisualStyleBackColor = true;
            this.btn_save.Click += new System.EventHandler(this.btn_save_Click);
            // 
            // btn_close
            // 
            this.btn_close.Image = global::TENTAC_HRM.Properties.Resources.cancel;
            this.btn_close.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btn_close.Location = new System.Drawing.Point(246, 159);
            this.btn_close.Name = "btn_close";
            this.btn_close.Size = new System.Drawing.Size(90, 27);
            this.btn_close.TabIndex = 6;
            this.btn_close.Text = "Đóng";
            this.btn_close.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btn_close.UseVisualStyleBackColor = true;
            this.btn_close.Click += new System.EventHandler(this.btn_close_Click);
            // 
            // dtp_nam
            // 
            this.dtp_nam.CustomFormat = "yyyy/MM/dd";
            this.dtp_nam.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtp_nam.Location = new System.Drawing.Point(137, 100);
            this.dtp_nam.Name = "dtp_nam";
            this.dtp_nam.Size = new System.Drawing.Size(199, 23);
            this.dtp_nam.TabIndex = 3;
            // 
            // txt_truong
            // 
            this.txt_truong.Location = new System.Drawing.Point(137, 71);
            this.txt_truong.Name = "txt_truong";
            this.txt_truong.Size = new System.Drawing.Size(199, 23);
            this.txt_truong.TabIndex = 2;
            // 
            // txt_tinhoc
            // 
            this.txt_tinhoc.Location = new System.Drawing.Point(137, 42);
            this.txt_tinhoc.Name = "txt_tinhoc";
            this.txt_tinhoc.Size = new System.Drawing.Size(199, 23);
            this.txt_tinhoc.TabIndex = 1;
            // 
            // cbo_xeploai
            // 
            this.cbo_xeploai.FormattingEnabled = true;
            this.cbo_xeploai.Location = new System.Drawing.Point(137, 129);
            this.cbo_xeploai.Name = "cbo_xeploai";
            this.cbo_xeploai.Size = new System.Drawing.Size(199, 24);
            this.cbo_xeploai.TabIndex = 4;
            // 
            // cbo_nhanvien
            // 
            this.cbo_nhanvien.Enabled = false;
            this.cbo_nhanvien.FormattingEnabled = true;
            this.cbo_nhanvien.Location = new System.Drawing.Point(137, 12);
            this.cbo_nhanvien.Name = "cbo_nhanvien";
            this.cbo_nhanvien.Size = new System.Drawing.Size(199, 24);
            this.cbo_nhanvien.TabIndex = 0;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(22, 132);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(59, 17);
            this.label5.TabIndex = 5;
            this.label5.Text = "Xếp loại";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(22, 105);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(109, 17);
            this.label4.TabIndex = 6;
            this.label4.Text = "Năm nhận bằng";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(22, 74);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(106, 17);
            this.label3.TabIndex = 7;
            this.label3.Text = "Trường đào tạo";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(22, 45);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(73, 17);
            this.label2.TabIndex = 8;
            this.label2.Text = "Ngoại ngữ";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(22, 15);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(72, 17);
            this.label1.TabIndex = 9;
            this.label1.Text = "Nhân viên";
            // 
            // frm_language
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(356, 204);
            this.Controls.Add(this.btn_save);
            this.Controls.Add(this.btn_close);
            this.Controls.Add(this.dtp_nam);
            this.Controls.Add(this.txt_truong);
            this.Controls.Add(this.txt_tinhoc);
            this.Controls.Add(this.cbo_xeploai);
            this.Controls.Add(this.cbo_nhanvien);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.Name = "frm_language";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Ngoại ngữ";
            this.Load += new System.EventHandler(this.frm_language_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btn_save;
        private System.Windows.Forms.Button btn_close;
        private System.Windows.Forms.DateTimePicker dtp_nam;
        private System.Windows.Forms.TextBox txt_truong;
        private System.Windows.Forms.TextBox txt_tinhoc;
        private System.Windows.Forms.ComboBox cbo_xeploai;
        private System.Windows.Forms.ComboBox cbo_nhanvien;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
    }
}