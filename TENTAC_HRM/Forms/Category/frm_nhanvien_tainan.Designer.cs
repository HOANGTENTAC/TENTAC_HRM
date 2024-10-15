namespace TENTAC_HRM.Forms.Category
{
    partial class frm_nhanvien_tainan
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
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.dtp_ngaydienra = new System.Windows.Forms.DateTimePicker();
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.txt_noidung = new System.Windows.Forms.TextBox();
            this.btn_save = new System.Windows.Forms.Button();
            this.btn_close = new System.Windows.Forms.Button();
            this.txt_noidienra = new System.Windows.Forms.TextBox();
            this.cbo_mucdo = new System.Windows.Forms.ComboBox();
            this.cbo_tentainan = new System.Windows.Forms.ComboBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.cbo_nhanvien = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.groupBox2.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.dtp_ngaydienra);
            this.groupBox2.Controls.Add(this.label6);
            this.groupBox2.Controls.Add(this.label5);
            this.groupBox2.Controls.Add(this.label4);
            this.groupBox2.Controls.Add(this.label3);
            this.groupBox2.Controls.Add(this.label2);
            this.groupBox2.Controls.Add(this.txt_noidung);
            this.groupBox2.Controls.Add(this.btn_save);
            this.groupBox2.Controls.Add(this.btn_close);
            this.groupBox2.Controls.Add(this.txt_noidienra);
            this.groupBox2.Controls.Add(this.cbo_mucdo);
            this.groupBox2.Controls.Add(this.cbo_tentainan);
            this.groupBox2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox2.Location = new System.Drawing.Point(0, 59);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(404, 287);
            this.groupBox2.TabIndex = 6;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Thông tin";
            // 
            // dtp_ngaydienra
            // 
            this.dtp_ngaydienra.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtp_ngaydienra.Location = new System.Drawing.Point(148, 82);
            this.dtp_ngaydienra.Name = "dtp_ngaydienra";
            this.dtp_ngaydienra.Size = new System.Drawing.Size(227, 23);
            this.dtp_ngaydienra.TabIndex = 2;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(18, 143);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(65, 17);
            this.label6.TabIndex = 0;
            this.label6.Text = "Nội dung";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(18, 114);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(77, 17);
            this.label5.TabIndex = 0;
            this.label5.Text = "Nơi diễn ra";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(18, 87);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(89, 17);
            this.label4.TabIndex = 0;
            this.label4.Text = "Ngày diễn ra";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(18, 55);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(54, 17);
            this.label3.TabIndex = 0;
            this.label3.Text = "Mức dộ";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(18, 25);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(80, 17);
            this.label2.TabIndex = 0;
            this.label2.Text = "Tên tai nạn";
            // 
            // txt_noidung
            // 
            this.txt_noidung.Location = new System.Drawing.Point(148, 140);
            this.txt_noidung.Multiline = true;
            this.txt_noidung.Name = "txt_noidung";
            this.txt_noidung.Size = new System.Drawing.Size(227, 99);
            this.txt_noidung.TabIndex = 1;
            // 
            // btn_save
            // 
            this.btn_save.Image = global::TENTAC_HRM.Properties.Resources.diskette;
            this.btn_save.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btn_save.Location = new System.Drawing.Point(148, 245);
            this.btn_save.Name = "btn_save";
            this.btn_save.Size = new System.Drawing.Size(115, 31);
            this.btn_save.TabIndex = 0;
            this.btn_save.Text = "Lưu";
            this.btn_save.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btn_save.UseVisualStyleBackColor = true;
            this.btn_save.Click += new System.EventHandler(this.btn_save_Click);
            // 
            // btn_close
            // 
            this.btn_close.Image = global::TENTAC_HRM.Properties.Resources.clear;
            this.btn_close.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btn_close.Location = new System.Drawing.Point(269, 245);
            this.btn_close.Name = "btn_close";
            this.btn_close.Size = new System.Drawing.Size(106, 31);
            this.btn_close.TabIndex = 0;
            this.btn_close.Text = "Đóng";
            this.btn_close.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btn_close.UseVisualStyleBackColor = true;
            this.btn_close.Click += new System.EventHandler(this.btn_close_Click);
            // 
            // txt_noidienra
            // 
            this.txt_noidienra.Location = new System.Drawing.Point(148, 111);
            this.txt_noidienra.Name = "txt_noidienra";
            this.txt_noidienra.Size = new System.Drawing.Size(227, 23);
            this.txt_noidienra.TabIndex = 1;
            // 
            // cbo_mucdo
            // 
            this.cbo_mucdo.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Append;
            this.cbo_mucdo.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.cbo_mucdo.FormattingEnabled = true;
            this.cbo_mucdo.Location = new System.Drawing.Point(148, 52);
            this.cbo_mucdo.Name = "cbo_mucdo";
            this.cbo_mucdo.Size = new System.Drawing.Size(227, 24);
            this.cbo_mucdo.TabIndex = 0;
            // 
            // cbo_tentainan
            // 
            this.cbo_tentainan.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Append;
            this.cbo_tentainan.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.cbo_tentainan.FormattingEnabled = true;
            this.cbo_tentainan.Location = new System.Drawing.Point(148, 22);
            this.cbo_tentainan.Name = "cbo_tentainan";
            this.cbo_tentainan.Size = new System.Drawing.Size(227, 24);
            this.cbo_tentainan.TabIndex = 0;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.cbo_nhanvien);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Dock = System.Windows.Forms.DockStyle.Top;
            this.groupBox1.Location = new System.Drawing.Point(0, 0);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(404, 59);
            this.groupBox1.TabIndex = 5;
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
            // frm_nhanvien_tainan
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(404, 346);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.Name = "frm_nhanvien_tainan";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Nhân viên - Tai nạn";
            this.Load += new System.EventHandler(this.frm_nhanvien_tainan_Load);
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.DateTimePicker dtp_ngaydienra;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txt_noidung;
        public System.Windows.Forms.Button btn_save;
        private System.Windows.Forms.Button btn_close;
        private System.Windows.Forms.TextBox txt_noidienra;
        private System.Windows.Forms.ComboBox cbo_mucdo;
        private System.Windows.Forms.ComboBox cbo_tentainan;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.ComboBox cbo_nhanvien;
        private System.Windows.Forms.Label label1;
    }
}