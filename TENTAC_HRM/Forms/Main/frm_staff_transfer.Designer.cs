namespace TENTAC_HRM
{
    partial class frm_staff_transfer
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
            this.dtp_ngay_dieuchuyen = new System.Windows.Forms.DateTimePicker();
            this.cbo_bophan = new System.Windows.Forms.ComboBox();
            this.cbo_truong_bophan = new System.Windows.Forms.ComboBox();
            this.cbo_loai_congviec = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.cbo_chucvu = new System.Windows.Forms.ComboBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.cbo_chucvu_moi = new System.Windows.Forms.ComboBox();
            this.label8 = new System.Windows.Forms.Label();
            this.cbo_loai_congviec_moi = new System.Windows.Forms.ComboBox();
            this.label9 = new System.Windows.Forms.Label();
            this.cbo_truong_bophan_moi = new System.Windows.Forms.ComboBox();
            this.label10 = new System.Windows.Forms.Label();
            this.cbo_bophan_moi = new System.Windows.Forms.ComboBox();
            this.label11 = new System.Windows.Forms.Label();
            this.iconButton1 = new FontAwesome.Sharp.IconButton();
            this.label7 = new System.Windows.Forms.Label();
            this.label12 = new System.Windows.Forms.Label();
            this.label13 = new System.Windows.Forms.Label();
            this.txt_madieuchuyen = new System.Windows.Forms.TextBox();
            this.btn_save = new System.Windows.Forms.Button();
            this.btn_close = new System.Windows.Forms.Button();
            this.txt_lydo = new RJTextBox.RJTextBox();
            this.txt_ghichu = new RJTextBox.RJTextBox();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(20, 19);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(72, 17);
            this.label1.TabIndex = 1;
            this.label1.Text = "Nhân viên";
            // 
            // cbo_nhanvien
            // 
            this.cbo_nhanvien.Enabled = false;
            this.cbo_nhanvien.FormattingEnabled = true;
            this.cbo_nhanvien.Location = new System.Drawing.Point(149, 16);
            this.cbo_nhanvien.Name = "cbo_nhanvien";
            this.cbo_nhanvien.Size = new System.Drawing.Size(588, 24);
            this.cbo_nhanvien.TabIndex = 0;
            this.cbo_nhanvien.SelectedValueChanged += new System.EventHandler(this.cbo_nhanvien_SelectedValueChanged);
            // 
            // dtp_ngay_dieuchuyen
            // 
            this.dtp_ngay_dieuchuyen.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtp_ngay_dieuchuyen.Location = new System.Drawing.Point(149, 48);
            this.dtp_ngay_dieuchuyen.Name = "dtp_ngay_dieuchuyen";
            this.dtp_ngay_dieuchuyen.Size = new System.Drawing.Size(169, 23);
            this.dtp_ngay_dieuchuyen.TabIndex = 1;
            // 
            // cbo_bophan
            // 
            this.cbo_bophan.Enabled = false;
            this.cbo_bophan.FormattingEnabled = true;
            this.cbo_bophan.Location = new System.Drawing.Point(163, 24);
            this.cbo_bophan.Name = "cbo_bophan";
            this.cbo_bophan.Size = new System.Drawing.Size(158, 24);
            this.cbo_bophan.TabIndex = 0;
            this.cbo_bophan.SelectedValueChanged += new System.EventHandler(this.cbo_bophan_SelectedValueChanged);
            // 
            // cbo_truong_bophan
            // 
            this.cbo_truong_bophan.Enabled = false;
            this.cbo_truong_bophan.FormattingEnabled = true;
            this.cbo_truong_bophan.Location = new System.Drawing.Point(163, 54);
            this.cbo_truong_bophan.Name = "cbo_truong_bophan";
            this.cbo_truong_bophan.Size = new System.Drawing.Size(158, 24);
            this.cbo_truong_bophan.TabIndex = 1;
            // 
            // cbo_loai_congviec
            // 
            this.cbo_loai_congviec.Enabled = false;
            this.cbo_loai_congviec.FormattingEnabled = true;
            this.cbo_loai_congviec.Location = new System.Drawing.Point(163, 84);
            this.cbo_loai_congviec.Name = "cbo_loai_congviec";
            this.cbo_loai_congviec.Size = new System.Drawing.Size(158, 24);
            this.cbo_loai_congviec.TabIndex = 2;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(20, 51);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(122, 17);
            this.label2.TabIndex = 1;
            this.label2.Text = "Ngày điều chuyển";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(23, 27);
            this.label3.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(111, 17);
            this.label3.TabIndex = 1;
            this.label3.Text = "Bộ phận hiện tại";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(23, 57);
            this.label4.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(110, 17);
            this.label4.TabIndex = 1;
            this.label4.Text = "Trưởng bộ phận";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(23, 87);
            this.label5.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(99, 17);
            this.label5.TabIndex = 1;
            this.label5.Text = "Loại công việc";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(23, 117);
            this.label6.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(59, 17);
            this.label6.TabIndex = 1;
            this.label6.Text = "Chức vụ";
            // 
            // cbo_chucvu
            // 
            this.cbo_chucvu.Enabled = false;
            this.cbo_chucvu.FormattingEnabled = true;
            this.cbo_chucvu.Location = new System.Drawing.Point(163, 114);
            this.cbo_chucvu.Name = "cbo_chucvu";
            this.cbo_chucvu.Size = new System.Drawing.Size(158, 24);
            this.cbo_chucvu.TabIndex = 3;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.cbo_chucvu);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.cbo_loai_congviec);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.cbo_truong_bophan);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this.cbo_bophan);
            this.groupBox1.Controls.Add(this.label6);
            this.groupBox1.Location = new System.Drawing.Point(27, 81);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(341, 156);
            this.groupBox1.TabIndex = 4;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Bộ phận hiện tại";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.cbo_chucvu_moi);
            this.groupBox2.Controls.Add(this.label8);
            this.groupBox2.Controls.Add(this.cbo_loai_congviec_moi);
            this.groupBox2.Controls.Add(this.label9);
            this.groupBox2.Controls.Add(this.cbo_truong_bophan_moi);
            this.groupBox2.Controls.Add(this.label10);
            this.groupBox2.Controls.Add(this.cbo_bophan_moi);
            this.groupBox2.Controls.Add(this.label11);
            this.groupBox2.Location = new System.Drawing.Point(399, 81);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(341, 156);
            this.groupBox2.TabIndex = 5;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Bộ phận chuyển";
            // 
            // cbo_chucvu_moi
            // 
            this.cbo_chucvu_moi.FormattingEnabled = true;
            this.cbo_chucvu_moi.Location = new System.Drawing.Point(164, 114);
            this.cbo_chucvu_moi.Name = "cbo_chucvu_moi";
            this.cbo_chucvu_moi.Size = new System.Drawing.Size(158, 24);
            this.cbo_chucvu_moi.TabIndex = 3;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(24, 27);
            this.label8.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(131, 17);
            this.label8.TabIndex = 1;
            this.label8.Text = "Chuyển tới bộ phận";
            // 
            // cbo_loai_congviec_moi
            // 
            this.cbo_loai_congviec_moi.FormattingEnabled = true;
            this.cbo_loai_congviec_moi.Location = new System.Drawing.Point(164, 84);
            this.cbo_loai_congviec_moi.Name = "cbo_loai_congviec_moi";
            this.cbo_loai_congviec_moi.Size = new System.Drawing.Size(158, 24);
            this.cbo_loai_congviec_moi.TabIndex = 2;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(24, 57);
            this.label9.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(110, 17);
            this.label9.TabIndex = 1;
            this.label9.Text = "Trưởng bộ phận";
            // 
            // cbo_truong_bophan_moi
            // 
            this.cbo_truong_bophan_moi.FormattingEnabled = true;
            this.cbo_truong_bophan_moi.Location = new System.Drawing.Point(164, 54);
            this.cbo_truong_bophan_moi.Name = "cbo_truong_bophan_moi";
            this.cbo_truong_bophan_moi.Size = new System.Drawing.Size(158, 24);
            this.cbo_truong_bophan_moi.TabIndex = 1;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(24, 87);
            this.label10.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(99, 17);
            this.label10.TabIndex = 1;
            this.label10.Text = "Loại công việc";
            // 
            // cbo_bophan_moi
            // 
            this.cbo_bophan_moi.FormattingEnabled = true;
            this.cbo_bophan_moi.Location = new System.Drawing.Point(164, 24);
            this.cbo_bophan_moi.Name = "cbo_bophan_moi";
            this.cbo_bophan_moi.Size = new System.Drawing.Size(158, 24);
            this.cbo_bophan_moi.TabIndex = 0;
            this.cbo_bophan_moi.SelectedValueChanged += new System.EventHandler(this.cbo_bophan_moi_SelectedValueChanged);
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(24, 117);
            this.label11.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(59, 17);
            this.label11.TabIndex = 1;
            this.label11.Text = "Chức vụ";
            // 
            // iconButton1
            // 
            this.iconButton1.Enabled = false;
            this.iconButton1.FlatAppearance.BorderSize = 0;
            this.iconButton1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.iconButton1.IconChar = FontAwesome.Sharp.IconChar.RightToBracket;
            this.iconButton1.IconColor = System.Drawing.Color.Black;
            this.iconButton1.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.iconButton1.IconSize = 20;
            this.iconButton1.Location = new System.Drawing.Point(370, 149);
            this.iconButton1.Name = "iconButton1";
            this.iconButton1.Size = new System.Drawing.Size(27, 24);
            this.iconButton1.TabIndex = 4;
            this.iconButton1.UseVisualStyleBackColor = true;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(20, 255);
            this.label7.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(43, 17);
            this.label7.TabIndex = 1;
            this.label7.Text = "Lý do";
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(20, 315);
            this.label12.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(57, 17);
            this.label12.TabIndex = 1;
            this.label12.Text = "Ghi chú";
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Location = new System.Drawing.Point(396, 51);
            this.label13.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(108, 17);
            this.label13.TabIndex = 1;
            this.label13.Text = "Mã điều chuyển";
            // 
            // txt_madieuchuyen
            // 
            this.txt_madieuchuyen.Location = new System.Drawing.Point(563, 48);
            this.txt_madieuchuyen.Name = "txt_madieuchuyen";
            this.txt_madieuchuyen.Size = new System.Drawing.Size(174, 23);
            this.txt_madieuchuyen.TabIndex = 2;
            // 
            // btn_save
            // 
            this.btn_save.Image = global::TENTAC_HRM.Properties.Resources.add_file;
            this.btn_save.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btn_save.Location = new System.Drawing.Point(248, 370);
            this.btn_save.Name = "btn_save";
            this.btn_save.Size = new System.Drawing.Size(120, 35);
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
            this.btn_close.Location = new System.Drawing.Point(399, 370);
            this.btn_close.Name = "btn_close";
            this.btn_close.Size = new System.Drawing.Size(120, 35);
            this.btn_close.TabIndex = 8;
            this.btn_close.Text = "Đóng";
            this.btn_close.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btn_close.UseVisualStyleBackColor = true;
            this.btn_close.Click += new System.EventHandler(this.btn_close_Click);
            // 
            // txt_lydo
            // 
            this.txt_lydo.BackColor = System.Drawing.SystemColors.Window;
            this.txt_lydo.BorderColor = System.Drawing.Color.Gray;
            this.txt_lydo.BorderFocusColor = System.Drawing.Color.RoyalBlue;
            this.txt_lydo.BorderRadius = 0;
            this.txt_lydo.BorderSize = 1;
            this.txt_lydo.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txt_lydo.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.txt_lydo.Location = new System.Drawing.Point(149, 250);
            this.txt_lydo.Margin = new System.Windows.Forms.Padding(4);
            this.txt_lydo.Multiline = true;
            this.txt_lydo.Name = "txt_lydo";
            this.txt_lydo.Padding = new System.Windows.Forms.Padding(10, 7, 10, 7);
            this.txt_lydo.PasswordChar = false;
            this.txt_lydo.PlaceholderColor = System.Drawing.Color.DarkGray;
            this.txt_lydo.PlaceholderText = "Ghi rõ lý do điều chuyển";
            this.txt_lydo.Size = new System.Drawing.Size(588, 49);
            this.txt_lydo.TabIndex = 3;
            this.txt_lydo.Texts = "";
            this.txt_lydo.UnderlinedStyle = false;
            // 
            // txt_ghichu
            // 
            this.txt_ghichu.BackColor = System.Drawing.SystemColors.Window;
            this.txt_ghichu.BorderColor = System.Drawing.Color.Gray;
            this.txt_ghichu.BorderFocusColor = System.Drawing.Color.RoyalBlue;
            this.txt_ghichu.BorderRadius = 0;
            this.txt_ghichu.BorderSize = 1;
            this.txt_ghichu.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txt_ghichu.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.txt_ghichu.Location = new System.Drawing.Point(149, 307);
            this.txt_ghichu.Margin = new System.Windows.Forms.Padding(4);
            this.txt_ghichu.Multiline = true;
            this.txt_ghichu.Name = "txt_ghichu";
            this.txt_ghichu.Padding = new System.Windows.Forms.Padding(10, 7, 10, 7);
            this.txt_ghichu.PasswordChar = false;
            this.txt_ghichu.PlaceholderColor = System.Drawing.Color.DarkGray;
            this.txt_ghichu.PlaceholderText = "Nội dung";
            this.txt_ghichu.Size = new System.Drawing.Size(588, 49);
            this.txt_ghichu.TabIndex = 4;
            this.txt_ghichu.Texts = "";
            this.txt_ghichu.UnderlinedStyle = false;
            // 
            // frm_staff_transfer
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.ClientSize = new System.Drawing.Size(757, 417);
            this.Controls.Add(this.txt_ghichu);
            this.Controls.Add(this.txt_lydo);
            this.Controls.Add(this.btn_close);
            this.Controls.Add(this.btn_save);
            this.Controls.Add(this.txt_madieuchuyen);
            this.Controls.Add(this.dtp_ngay_dieuchuyen);
            this.Controls.Add(this.label13);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.iconButton1);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.label12);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.cbo_nhanvien);
            this.Controls.Add(this.label1);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.KeyPreview = true;
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "frm_staff_transfer";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Nhân viên - Điêu chuyển";
            this.Load += new System.EventHandler(this.frm_staff_transfer_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.frm_staff_transfer_KeyDown);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox cbo_nhanvien;
        private System.Windows.Forms.DateTimePicker dtp_ngay_dieuchuyen;
        private System.Windows.Forms.ComboBox cbo_bophan;
        private System.Windows.Forms.ComboBox cbo_truong_bophan;
        private System.Windows.Forms.ComboBox cbo_loai_congviec;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.ComboBox cbo_chucvu;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.ComboBox cbo_chucvu_moi;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.ComboBox cbo_loai_congviec_moi;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.ComboBox cbo_truong_bophan_moi;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.ComboBox cbo_bophan_moi;
        private System.Windows.Forms.Label label11;
        private FontAwesome.Sharp.IconButton iconButton1;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.TextBox txt_madieuchuyen;
        private System.Windows.Forms.Button btn_save;
        private System.Windows.Forms.Button btn_close;
        private RJTextBox.RJTextBox txt_lydo;
        private RJTextBox.RJTextBox txt_ghichu;
    }
}