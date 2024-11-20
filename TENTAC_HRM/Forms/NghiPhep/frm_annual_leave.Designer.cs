namespace TENTAC_HRM.Forms.NghiPhep
{
    partial class frm_annual_leave
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
            this.dtp_tungay = new System.Windows.Forms.DateTimePicker();
            this.dtp_denngay = new System.Windows.Forms.DateTimePicker();
            this.txt_noidung = new System.Windows.Forms.TextBox();
            this.btn_close = new System.Windows.Forms.Button();
            this.btn_save = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.cbo_loaiphep = new TENTAC_HRM.Custom.MultiColumnComboBox();
            this.chk_nhansu = new System.Windows.Forms.CheckBox();
            this.chk_quanly = new System.Windows.Forms.CheckBox();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(21, 23);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(72, 17);
            this.label1.TabIndex = 0;
            this.label1.Text = "Nhân viên";
            // 
            // cbo_nhanvien
            // 
            this.cbo_nhanvien.FormattingEnabled = true;
            this.cbo_nhanvien.Location = new System.Drawing.Point(108, 20);
            this.cbo_nhanvien.Name = "cbo_nhanvien";
            this.cbo_nhanvien.Size = new System.Drawing.Size(381, 24);
            this.cbo_nhanvien.TabIndex = 0;
            // 
            // dtp_tungay
            // 
            this.dtp_tungay.CustomFormat = "dd/MM/yyyy HH:mm";
            this.dtp_tungay.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtp_tungay.Location = new System.Drawing.Point(108, 80);
            this.dtp_tungay.Name = "dtp_tungay";
            this.dtp_tungay.Size = new System.Drawing.Size(147, 23);
            this.dtp_tungay.TabIndex = 2;
            // 
            // dtp_denngay
            // 
            this.dtp_denngay.CustomFormat = "dd/MM/yyyy HH:mm";
            this.dtp_denngay.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtp_denngay.Location = new System.Drawing.Point(342, 80);
            this.dtp_denngay.Name = "dtp_denngay";
            this.dtp_denngay.Size = new System.Drawing.Size(147, 23);
            this.dtp_denngay.TabIndex = 3;
            // 
            // txt_noidung
            // 
            this.txt_noidung.Location = new System.Drawing.Point(108, 109);
            this.txt_noidung.Multiline = true;
            this.txt_noidung.Name = "txt_noidung";
            this.txt_noidung.Size = new System.Drawing.Size(381, 87);
            this.txt_noidung.TabIndex = 4;
            // 
            // btn_close
            // 
            this.btn_close.Image = global::TENTAC_HRM.Properties.Resources.clear;
            this.btn_close.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btn_close.Location = new System.Drawing.Point(403, 268);
            this.btn_close.Name = "btn_close";
            this.btn_close.Size = new System.Drawing.Size(86, 32);
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
            this.btn_save.Location = new System.Drawing.Point(311, 268);
            this.btn_save.Name = "btn_save";
            this.btn_save.Size = new System.Drawing.Size(86, 32);
            this.btn_save.TabIndex = 5;
            this.btn_save.Text = "Lưu";
            this.btn_save.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btn_save.UseVisualStyleBackColor = true;
            this.btn_save.Click += new System.EventHandler(this.btn_save_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(21, 53);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(71, 17);
            this.label2.TabIndex = 0;
            this.label2.Text = "Loại phép";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(21, 85);
            this.label3.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(60, 17);
            this.label3.TabIndex = 0;
            this.label3.Text = "Từ ngày";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(264, 85);
            this.label4.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(69, 17);
            this.label4.TabIndex = 0;
            this.label4.Text = "Đến ngày";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(21, 112);
            this.label5.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(65, 17);
            this.label5.TabIndex = 0;
            this.label5.Text = "Nội dung";
            // 
            // cbo_loaiphep
            // 
            this.cbo_loaiphep.AutoComplete = false;
            this.cbo_loaiphep.AutoDropdown = false;
            this.cbo_loaiphep.BackColorEven = System.Drawing.Color.White;
            this.cbo_loaiphep.BackColorOdd = System.Drawing.Color.White;
            this.cbo_loaiphep.ColumnNames = "";
            this.cbo_loaiphep.ColumnWidthDefault = 100;
            this.cbo_loaiphep.ColumnWidths = "";
            this.cbo_loaiphep.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawVariable;
            this.cbo_loaiphep.FormattingEnabled = true;
            this.cbo_loaiphep.LinkedColumnIndex = 0;
            this.cbo_loaiphep.LinkedTextBox = null;
            this.cbo_loaiphep.Location = new System.Drawing.Point(108, 50);
            this.cbo_loaiphep.Name = "cbo_loaiphep";
            this.cbo_loaiphep.Size = new System.Drawing.Size(381, 24);
            this.cbo_loaiphep.TabIndex = 1;
            // 
            // chk_nhansu
            // 
            this.chk_nhansu.AutoSize = true;
            this.chk_nhansu.Location = new System.Drawing.Point(108, 229);
            this.chk_nhansu.Name = "chk_nhansu";
            this.chk_nhansu.Size = new System.Drawing.Size(169, 21);
            this.chk_nhansu.TabIndex = 7;
            this.chk_nhansu.Text = "Xác nhận của nhân sự";
            this.chk_nhansu.UseVisualStyleBackColor = true;
            // 
            // chk_quanly
            // 
            this.chk_quanly.AutoSize = true;
            this.chk_quanly.Location = new System.Drawing.Point(108, 202);
            this.chk_quanly.Name = "chk_quanly";
            this.chk_quanly.Size = new System.Drawing.Size(164, 21);
            this.chk_quanly.TabIndex = 7;
            this.chk_quanly.Text = "Xác nhận của quản lý";
            this.chk_quanly.UseVisualStyleBackColor = true;
            // 
            // frm_annual_leave
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(506, 312);
            this.Controls.Add(this.chk_quanly);
            this.Controls.Add(this.chk_nhansu);
            this.Controls.Add(this.cbo_loaiphep);
            this.Controls.Add(this.btn_save);
            this.Controls.Add(this.btn_close);
            this.Controls.Add(this.txt_noidung);
            this.Controls.Add(this.dtp_denngay);
            this.Controls.Add(this.dtp_tungay);
            this.Controls.Add(this.cbo_nhanvien);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "frm_annual_leave";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Nghỉ phép";
            this.Load += new System.EventHandler(this.frm_annual_leave_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox cbo_nhanvien;
        private System.Windows.Forms.DateTimePicker dtp_denngay;
        private System.Windows.Forms.TextBox txt_noidung;
        private System.Windows.Forms.Button btn_close;
        private System.Windows.Forms.Button btn_save;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private Custom.MultiColumnComboBox cbo_loaiphep;
        private System.Windows.Forms.DateTimePicker dtp_tungay;
        private System.Windows.Forms.CheckBox chk_nhansu;
        private System.Windows.Forms.CheckBox chk_quanly;
    }
}