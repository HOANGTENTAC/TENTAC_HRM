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
            this.txt_noidung = new System.Windows.Forms.TextBox();
            this.btn_close = new System.Windows.Forms.Button();
            this.btn_save = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.chk_nhansu = new System.Windows.Forms.CheckBox();
            this.chk_quanly = new System.Windows.Forms.CheckBox();
            this.chk_ToTruong = new System.Windows.Forms.CheckBox();
            this.cbo_Thang = new DevComponents.DotNetBar.Controls.ComboBoxEx();
            this.cbo_Nam = new DevComponents.DotNetBar.Controls.ComboBoxEx();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.chk_BuoiSang = new DevComponents.DotNetBar.Controls.CheckBoxX();
            this.chk_BuoiChieu = new DevComponents.DotNetBar.Controls.CheckBoxX();
            this.lv_Ngay = new System.Windows.Forms.CheckedListBox();
            this.cbo_loaiphep = new TENTAC_HRM.Custom.MultiColumnComboBox();
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
            this.cbo_nhanvien.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbo_nhanvien.FormattingEnabled = true;
            this.cbo_nhanvien.Location = new System.Drawing.Point(108, 20);
            this.cbo_nhanvien.Name = "cbo_nhanvien";
            this.cbo_nhanvien.Size = new System.Drawing.Size(381, 24);
            this.cbo_nhanvien.TabIndex = 0;
            // 
            // txt_noidung
            // 
            this.txt_noidung.Location = new System.Drawing.Point(108, 238);
            this.txt_noidung.Multiline = true;
            this.txt_noidung.Name = "txt_noidung";
            this.txt_noidung.Size = new System.Drawing.Size(381, 87);
            this.txt_noidung.TabIndex = 4;
            // 
            // btn_close
            // 
            this.btn_close.Image = global::TENTAC_HRM.Properties.Resources.clear;
            this.btn_close.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btn_close.Location = new System.Drawing.Point(403, 404);
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
            this.btn_save.Location = new System.Drawing.Point(311, 404);
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
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(21, 241);
            this.label5.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(65, 17);
            this.label5.TabIndex = 0;
            this.label5.Text = "Nội dung";
            // 
            // chk_nhansu
            // 
            this.chk_nhansu.AutoSize = true;
            this.chk_nhansu.Location = new System.Drawing.Point(108, 380);
            this.chk_nhansu.Name = "chk_nhansu";
            this.chk_nhansu.Size = new System.Drawing.Size(169, 21);
            this.chk_nhansu.TabIndex = 7;
            this.chk_nhansu.Text = "Xác nhận của nhân sự";
            this.chk_nhansu.UseVisualStyleBackColor = true;
            // 
            // chk_quanly
            // 
            this.chk_quanly.AutoSize = true;
            this.chk_quanly.Location = new System.Drawing.Point(108, 354);
            this.chk_quanly.Name = "chk_quanly";
            this.chk_quanly.Size = new System.Drawing.Size(164, 21);
            this.chk_quanly.TabIndex = 7;
            this.chk_quanly.Text = "Xác nhận của quản lý";
            this.chk_quanly.UseVisualStyleBackColor = true;
            // 
            // chk_ToTruong
            // 
            this.chk_ToTruong.AutoSize = true;
            this.chk_ToTruong.Location = new System.Drawing.Point(108, 328);
            this.chk_ToTruong.Name = "chk_ToTruong";
            this.chk_ToTruong.Size = new System.Drawing.Size(175, 21);
            this.chk_ToTruong.TabIndex = 7;
            this.chk_ToTruong.Text = "Xác nhận của tổ trưởng";
            this.chk_ToTruong.UseVisualStyleBackColor = true;
            // 
            // cbo_Thang
            // 
            this.cbo_Thang.DisplayMember = "Text";
            this.cbo_Thang.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.cbo_Thang.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbo_Thang.FormattingEnabled = true;
            this.cbo_Thang.ItemHeight = 17;
            this.cbo_Thang.Location = new System.Drawing.Point(166, 80);
            this.cbo_Thang.Name = "cbo_Thang";
            this.cbo_Thang.Size = new System.Drawing.Size(86, 23);
            this.cbo_Thang.TabIndex = 8;
            this.cbo_Thang.SelectionChangeCommitted += new System.EventHandler(this.cbo_Thang_SelectionChangeCommitted);
            // 
            // cbo_Nam
            // 
            this.cbo_Nam.DisplayMember = "Text";
            this.cbo_Nam.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.cbo_Nam.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbo_Nam.FormattingEnabled = true;
            this.cbo_Nam.ItemHeight = 17;
            this.cbo_Nam.Location = new System.Drawing.Point(311, 80);
            this.cbo_Nam.Name = "cbo_Nam";
            this.cbo_Nam.Size = new System.Drawing.Size(86, 23);
            this.cbo_Nam.TabIndex = 8;
            this.cbo_Nam.SelectionChangeCommitted += new System.EventHandler(this.cbo_Nam_SelectionChangeCommitted);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(110, 84);
            this.label3.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(49, 17);
            this.label3.TabIndex = 0;
            this.label3.Text = "Tháng";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(262, 84);
            this.label4.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(37, 17);
            this.label4.TabIndex = 0;
            this.label4.Text = "Năm";
            // 
            // chk_BuoiSang
            // 
            this.chk_BuoiSang.Enabled = false;
            this.chk_BuoiSang.Location = new System.Drawing.Point(108, 209);
            this.chk_BuoiSang.Name = "chk_BuoiSang";
            this.chk_BuoiSang.Size = new System.Drawing.Size(115, 23);
            this.chk_BuoiSang.TabIndex = 10;
            this.chk_BuoiSang.Text = "Nghỉ buổi sáng";
            // 
            // chk_BuoiChieu
            // 
            this.chk_BuoiChieu.Enabled = false;
            this.chk_BuoiChieu.Location = new System.Drawing.Point(229, 209);
            this.chk_BuoiChieu.Name = "chk_BuoiChieu";
            this.chk_BuoiChieu.Size = new System.Drawing.Size(123, 23);
            this.chk_BuoiChieu.TabIndex = 10;
            this.chk_BuoiChieu.Text = "Nghỉ buổi chiều";
            // 
            // lv_Ngay
            // 
            this.lv_Ngay.CheckOnClick = true;
            this.lv_Ngay.ColumnWidth = 50;
            this.lv_Ngay.ForeColor = System.Drawing.Color.Blue;
            this.lv_Ngay.FormattingEnabled = true;
            this.lv_Ngay.Location = new System.Drawing.Point(108, 109);
            this.lv_Ngay.MultiColumn = true;
            this.lv_Ngay.Name = "lv_Ngay";
            this.lv_Ngay.Size = new System.Drawing.Size(381, 94);
            this.lv_Ngay.TabIndex = 11;
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
            this.cbo_loaiphep.SelectionChangeCommitted += new System.EventHandler(this.cbo_loaiphep_SelectionChangeCommitted);
            // 
            // frm_annual_leave
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(506, 441);
            this.Controls.Add(this.lv_Ngay);
            this.Controls.Add(this.chk_BuoiChieu);
            this.Controls.Add(this.chk_BuoiSang);
            this.Controls.Add(this.cbo_Nam);
            this.Controls.Add(this.cbo_Thang);
            this.Controls.Add(this.chk_ToTruong);
            this.Controls.Add(this.chk_quanly);
            this.Controls.Add(this.chk_nhansu);
            this.Controls.Add(this.cbo_loaiphep);
            this.Controls.Add(this.btn_save);
            this.Controls.Add(this.btn_close);
            this.Controls.Add(this.txt_noidung);
            this.Controls.Add(this.cbo_nhanvien);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
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
        private System.Windows.Forms.TextBox txt_noidung;
        private System.Windows.Forms.Button btn_close;
        private System.Windows.Forms.Button btn_save;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label5;
        private Custom.MultiColumnComboBox cbo_loaiphep;
        private System.Windows.Forms.CheckBox chk_nhansu;
        private System.Windows.Forms.CheckBox chk_quanly;
        private System.Windows.Forms.CheckBox chk_ToTruong;
        private DevComponents.DotNetBar.Controls.ComboBoxEx cbo_Thang;
        private DevComponents.DotNetBar.Controls.ComboBoxEx cbo_Nam;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private DevComponents.DotNetBar.Controls.CheckBoxX chk_BuoiSang;
        private DevComponents.DotNetBar.Controls.CheckBoxX chk_BuoiChieu;
        private System.Windows.Forms.CheckedListBox lv_Ngay;
    }
}