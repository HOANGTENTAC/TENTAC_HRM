namespace TENTAC_HRM.Category
{
    partial class frm_honnhan
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
            this.txt_sogiay_chungnhan = new System.Windows.Forms.TextBox();
            this.dtp_ngaydk = new System.Windows.Forms.DateTimePicker();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.txt_noidk = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.btn_luu = new System.Windows.Forms.Button();
            this.btn_close = new System.Windows.Forms.Button();
            this.label7 = new System.Windows.Forms.Label();
            this.cbo_nhanvien = new System.Windows.Forms.ComboBox();
            this.pb_matsau = new System.Windows.Forms.PictureBox();
            this.pb_mattruoc = new System.Windows.Forms.PictureBox();
            this.btn_delete = new System.Windows.Forms.Button();
            this.btn_delete_pt1 = new RJButton.RJButton();
            this.btn_delete_pt2 = new RJButton.RJButton();
            ((System.ComponentModel.ISupportInitialize)(this.pb_matsau)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pb_mattruoc)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(24, 43);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(134, 17);
            this.label1.TabIndex = 0;
            this.label1.Text = "Số giấy chứng nhận";
            // 
            // txt_sogiay_chungnhan
            // 
            this.txt_sogiay_chungnhan.Location = new System.Drawing.Point(165, 43);
            this.txt_sogiay_chungnhan.Name = "txt_sogiay_chungnhan";
            this.txt_sogiay_chungnhan.Size = new System.Drawing.Size(260, 23);
            this.txt_sogiay_chungnhan.TabIndex = 1;
            // 
            // dtp_ngaydk
            // 
            this.dtp_ngaydk.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtp_ngaydk.Location = new System.Drawing.Point(165, 82);
            this.dtp_ngaydk.Name = "dtp_ngaydk";
            this.dtp_ngaydk.Size = new System.Drawing.Size(260, 23);
            this.dtp_ngaydk.TabIndex = 2;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(20, 60);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(82, 17);
            this.label2.TabIndex = 0;
            this.label2.Text = " ĐK kết hôn";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(24, 87);
            this.label3.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(95, 17);
            this.label3.TabIndex = 0;
            this.label3.Text = "Ngày đăng ký";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(24, 122);
            this.label4.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(83, 17);
            this.label4.TabIndex = 0;
            this.label4.Text = "Nơi đăng ký";
            // 
            // txt_noidk
            // 
            this.txt_noidk.Location = new System.Drawing.Point(165, 119);
            this.txt_noidk.Name = "txt_noidk";
            this.txt_noidk.Size = new System.Drawing.Size(260, 23);
            this.txt_noidk.TabIndex = 3;
            // 
            // label5
            // 
            this.label5.Location = new System.Drawing.Point(50, 392);
            this.label5.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(173, 17);
            this.label5.TabIndex = 0;
            this.label5.Text = "Mặt trước";
            this.label5.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label6
            // 
            this.label6.Location = new System.Drawing.Point(253, 392);
            this.label6.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(172, 17);
            this.label6.TabIndex = 0;
            this.label6.Text = "Mặt sau";
            this.label6.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // btn_luu
            // 
            this.btn_luu.Image = global::TENTAC_HRM.Properties.Resources.diskette;
            this.btn_luu.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btn_luu.Location = new System.Drawing.Point(229, 428);
            this.btn_luu.Name = "btn_luu";
            this.btn_luu.Size = new System.Drawing.Size(106, 27);
            this.btn_luu.TabIndex = 4;
            this.btn_luu.Text = "Lưu";
            this.btn_luu.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btn_luu.UseVisualStyleBackColor = true;
            this.btn_luu.Click += new System.EventHandler(this.btn_luu_Click);
            // 
            // btn_close
            // 
            this.btn_close.Image = global::TENTAC_HRM.Properties.Resources.clear;
            this.btn_close.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btn_close.Location = new System.Drawing.Point(341, 428);
            this.btn_close.Name = "btn_close";
            this.btn_close.Size = new System.Drawing.Size(84, 27);
            this.btn_close.TabIndex = 5;
            this.btn_close.Text = "Đóng";
            this.btn_close.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btn_close.UseVisualStyleBackColor = true;
            this.btn_close.Click += new System.EventHandler(this.btn_close_Click);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(24, 12);
            this.label7.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(72, 17);
            this.label7.TabIndex = 0;
            this.label7.Text = "Nhân viên";
            // 
            // cbo_nhanvien
            // 
            this.cbo_nhanvien.Enabled = false;
            this.cbo_nhanvien.FormattingEnabled = true;
            this.cbo_nhanvien.Location = new System.Drawing.Point(165, 9);
            this.cbo_nhanvien.Name = "cbo_nhanvien";
            this.cbo_nhanvien.Size = new System.Drawing.Size(260, 24);
            this.cbo_nhanvien.TabIndex = 0;
            // 
            // pb_matsau
            // 
            this.pb_matsau.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pb_matsau.Location = new System.Drawing.Point(229, 161);
            this.pb_matsau.Name = "pb_matsau";
            this.pb_matsau.Size = new System.Drawing.Size(196, 228);
            this.pb_matsau.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pb_matsau.TabIndex = 3;
            this.pb_matsau.TabStop = false;
            this.pb_matsau.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.pb_matsau_MouseDoubleClick);
            // 
            // pb_mattruoc
            // 
            this.pb_mattruoc.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pb_mattruoc.Location = new System.Drawing.Point(27, 161);
            this.pb_mattruoc.Name = "pb_mattruoc";
            this.pb_mattruoc.Size = new System.Drawing.Size(196, 228);
            this.pb_mattruoc.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pb_mattruoc.TabIndex = 3;
            this.pb_mattruoc.TabStop = false;
            this.pb_mattruoc.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.pb_mattruoc_MouseDoubleClick);
            // 
            // btn_delete
            // 
            this.btn_delete.Image = global::TENTAC_HRM.Properties.Resources.bin;
            this.btn_delete.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btn_delete.Location = new System.Drawing.Point(124, 428);
            this.btn_delete.Name = "btn_delete";
            this.btn_delete.Size = new System.Drawing.Size(99, 27);
            this.btn_delete.TabIndex = 4;
            this.btn_delete.Text = "Xóa";
            this.btn_delete.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btn_delete.UseVisualStyleBackColor = true;
            this.btn_delete.Visible = false;
            this.btn_delete.Click += new System.EventHandler(this.btn_delete_Click);
            // 
            // btn_delete_pt1
            // 
            this.btn_delete_pt1.BackColor = System.Drawing.SystemColors.Control;
            this.btn_delete_pt1.BackGroundColor = System.Drawing.SystemColors.Control;
            this.btn_delete_pt1.BorderColor = System.Drawing.Color.PaleVioletRed;
            this.btn_delete_pt1.BorderRadius = 24;
            this.btn_delete_pt1.BorderSize = 0;
            this.btn_delete_pt1.FlatAppearance.BorderSize = 0;
            this.btn_delete_pt1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_delete_pt1.ForeColor = System.Drawing.Color.White;
            this.btn_delete_pt1.Image = global::TENTAC_HRM.Properties.Resources.bin;
            this.btn_delete_pt1.Location = new System.Drawing.Point(75, 389);
            this.btn_delete_pt1.Name = "btn_delete_pt1";
            this.btn_delete_pt1.Size = new System.Drawing.Size(26, 24);
            this.btn_delete_pt1.TabIndex = 6;
            this.btn_delete_pt1.TextColor = System.Drawing.Color.White;
            this.btn_delete_pt1.UseVisualStyleBackColor = false;
            this.btn_delete_pt1.Click += new System.EventHandler(this.btn_delete_pt1_Click);
            // 
            // btn_delete_pt2
            // 
            this.btn_delete_pt2.BackColor = System.Drawing.SystemColors.Control;
            this.btn_delete_pt2.BackGroundColor = System.Drawing.SystemColors.Control;
            this.btn_delete_pt2.BorderColor = System.Drawing.Color.PaleVioletRed;
            this.btn_delete_pt2.BorderRadius = 24;
            this.btn_delete_pt2.BorderSize = 0;
            this.btn_delete_pt2.FlatAppearance.BorderSize = 0;
            this.btn_delete_pt2.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_delete_pt2.ForeColor = System.Drawing.Color.White;
            this.btn_delete_pt2.Image = global::TENTAC_HRM.Properties.Resources.bin;
            this.btn_delete_pt2.Location = new System.Drawing.Point(280, 389);
            this.btn_delete_pt2.Name = "btn_delete_pt2";
            this.btn_delete_pt2.Size = new System.Drawing.Size(26, 24);
            this.btn_delete_pt2.TabIndex = 7;
            this.btn_delete_pt2.TextColor = System.Drawing.Color.White;
            this.btn_delete_pt2.UseVisualStyleBackColor = false;
            this.btn_delete_pt2.Click += new System.EventHandler(this.btn_delete_pt2_Click);
            // 
            // frm_honnhan
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(450, 464);
            this.Controls.Add(this.btn_delete_pt2);
            this.Controls.Add(this.btn_delete_pt1);
            this.Controls.Add(this.cbo_nhanvien);
            this.Controls.Add(this.btn_close);
            this.Controls.Add(this.btn_delete);
            this.Controls.Add(this.btn_luu);
            this.Controls.Add(this.pb_matsau);
            this.Controls.Add(this.pb_mattruoc);
            this.Controls.Add(this.dtp_ngaydk);
            this.Controls.Add(this.txt_noidk);
            this.Controls.Add(this.txt_sogiay_chungnhan);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.KeyPreview = true;
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "frm_honnhan";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Nhân viên - Hôn nhân";
            this.Load += new System.EventHandler(this.frm_honnhan_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.frm_honnhan_KeyDown);
            ((System.ComponentModel.ISupportInitialize)(this.pb_matsau)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pb_mattruoc)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txt_sogiay_chungnhan;
        private System.Windows.Forms.DateTimePicker dtp_ngaydk;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txt_noidk;
        private System.Windows.Forms.PictureBox pb_mattruoc;
        private System.Windows.Forms.PictureBox pb_matsau;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Button btn_luu;
        private System.Windows.Forms.Button btn_close;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.ComboBox cbo_nhanvien;
        private System.Windows.Forms.Button btn_delete;
        private RJButton.RJButton btn_delete_pt1;
        private RJButton.RJButton btn_delete_pt2;
    }
}