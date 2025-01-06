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
            this.panel1 = new System.Windows.Forms.Panel();
            this.cbo_LoaiPhep = new DevComponents.DotNetBar.Controls.ComboBoxEx();
            this.txt_SoPhepNamTon = new DevComponents.DotNetBar.Controls.TextBoxX();
            this.labelX6 = new DevComponents.DotNetBar.LabelX();
            this.btn_cancel = new System.Windows.Forms.Button();
            this.txt_NoiDung = new DevComponents.DotNetBar.Controls.TextBoxX();
            this.cbo_NhanVien = new DevComponents.DotNetBar.Controls.ComboBoxEx();
            this.labelX5 = new DevComponents.DotNetBar.LabelX();
            this.labelX4 = new DevComponents.DotNetBar.LabelX();
            this.labelX3 = new DevComponents.DotNetBar.LabelX();
            this.labelX2 = new DevComponents.DotNetBar.LabelX();
            this.labelX1 = new DevComponents.DotNetBar.LabelX();
            this.btn_send = new System.Windows.Forms.Button();
            this.lv_Ngay = new System.Windows.Forms.CheckedListBox();
            this.chk_BuoiChieu = new DevComponents.DotNetBar.Controls.CheckBoxX();
            this.chk_BuoiSang = new DevComponents.DotNetBar.Controls.CheckBoxX();
            this.cbo_Nam = new DevComponents.DotNetBar.Controls.ComboBoxEx();
            this.cbo_Thang = new DevComponents.DotNetBar.Controls.ComboBoxEx();
            this.txt_NhanVien = new DevComponents.DotNetBar.Controls.TextBoxX();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.txt_NhanVien);
            this.panel1.Controls.Add(this.cbo_LoaiPhep);
            this.panel1.Controls.Add(this.txt_SoPhepNamTon);
            this.panel1.Controls.Add(this.labelX6);
            this.panel1.Controls.Add(this.btn_cancel);
            this.panel1.Controls.Add(this.txt_NoiDung);
            this.panel1.Controls.Add(this.cbo_NhanVien);
            this.panel1.Controls.Add(this.labelX5);
            this.panel1.Controls.Add(this.labelX4);
            this.panel1.Controls.Add(this.labelX3);
            this.panel1.Controls.Add(this.labelX2);
            this.panel1.Controls.Add(this.labelX1);
            this.panel1.Controls.Add(this.btn_send);
            this.panel1.Controls.Add(this.lv_Ngay);
            this.panel1.Controls.Add(this.chk_BuoiChieu);
            this.panel1.Controls.Add(this.chk_BuoiSang);
            this.panel1.Controls.Add(this.cbo_Nam);
            this.panel1.Controls.Add(this.cbo_Thang);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(478, 443);
            this.panel1.TabIndex = 1;
            // 
            // cbo_LoaiPhep
            // 
            this.cbo_LoaiPhep.DisplayMember = "Text";
            this.cbo_LoaiPhep.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.cbo_LoaiPhep.FormattingEnabled = true;
            this.cbo_LoaiPhep.ItemHeight = 17;
            this.cbo_LoaiPhep.Location = new System.Drawing.Point(104, 118);
            this.cbo_LoaiPhep.Name = "cbo_LoaiPhep";
            this.cbo_LoaiPhep.Size = new System.Drawing.Size(359, 23);
            this.cbo_LoaiPhep.TabIndex = 53;
            // 
            // txt_SoPhepNamTon
            // 
            // 
            // 
            // 
            this.txt_SoPhepNamTon.Border.Class = "TextBoxBorder";
            this.txt_SoPhepNamTon.Location = new System.Drawing.Point(428, 146);
            this.txt_SoPhepNamTon.Name = "txt_SoPhepNamTon";
            this.txt_SoPhepNamTon.ReadOnly = true;
            this.txt_SoPhepNamTon.Size = new System.Drawing.Size(35, 23);
            this.txt_SoPhepNamTon.TabIndex = 52;
            // 
            // labelX6
            // 
            this.labelX6.Location = new System.Drawing.Point(323, 146);
            this.labelX6.Name = "labelX6";
            this.labelX6.Size = new System.Drawing.Size(113, 23);
            this.labelX6.TabIndex = 51;
            this.labelX6.Text = "Số phép năm tồn";
            // 
            // btn_cancel
            // 
            this.btn_cancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btn_cancel.Image = global::TENTAC_HRM.Properties.Resources.cancel;
            this.btn_cancel.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btn_cancel.Location = new System.Drawing.Point(387, 399);
            this.btn_cancel.Name = "btn_cancel";
            this.btn_cancel.Size = new System.Drawing.Size(76, 30);
            this.btn_cancel.TabIndex = 50;
            this.btn_cancel.Text = "Đóng";
            this.btn_cancel.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btn_cancel.UseVisualStyleBackColor = true;
            this.btn_cancel.Click += new System.EventHandler(this.btn_cancel_Click);
            // 
            // txt_NoiDung
            // 
            // 
            // 
            // 
            this.txt_NoiDung.Border.Class = "TextBoxBorder";
            this.txt_NoiDung.Location = new System.Drawing.Point(104, 308);
            this.txt_NoiDung.Multiline = true;
            this.txt_NoiDung.Name = "txt_NoiDung";
            this.txt_NoiDung.Size = new System.Drawing.Size(359, 85);
            this.txt_NoiDung.TabIndex = 7;
            // 
            // cbo_NhanVien
            // 
            this.cbo_NhanVien.DisplayMember = "Text";
            this.cbo_NhanVien.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.cbo_NhanVien.FormattingEnabled = true;
            this.cbo_NhanVien.ItemHeight = 17;
            this.cbo_NhanVien.Location = new System.Drawing.Point(104, 12);
            this.cbo_NhanVien.Name = "cbo_NhanVien";
            this.cbo_NhanVien.Size = new System.Drawing.Size(359, 23);
            this.cbo_NhanVien.TabIndex = 1;
            this.cbo_NhanVien.SelectedIndexChanged += new System.EventHandler(this.cbo_NhanVien_SelectedIndexChanged);
            // 
            // labelX5
            // 
            this.labelX5.Location = new System.Drawing.Point(213, 148);
            this.labelX5.Name = "labelX5";
            this.labelX5.Size = new System.Drawing.Size(38, 23);
            this.labelX5.TabIndex = 48;
            this.labelX5.Text = "Năm";
            // 
            // labelX4
            // 
            this.labelX4.Location = new System.Drawing.Point(104, 147);
            this.labelX4.Name = "labelX4";
            this.labelX4.Size = new System.Drawing.Size(52, 23);
            this.labelX4.TabIndex = 47;
            this.labelX4.Text = "Tháng";
            // 
            // labelX3
            // 
            this.labelX3.Location = new System.Drawing.Point(20, 307);
            this.labelX3.Name = "labelX3";
            this.labelX3.Size = new System.Drawing.Size(75, 23);
            this.labelX3.TabIndex = 46;
            this.labelX3.Text = "Nội dung";
            // 
            // labelX2
            // 
            this.labelX2.Location = new System.Drawing.Point(16, 118);
            this.labelX2.Name = "labelX2";
            this.labelX2.Size = new System.Drawing.Size(75, 23);
            this.labelX2.TabIndex = 45;
            this.labelX2.Text = "Loại phép";
            // 
            // labelX1
            // 
            this.labelX1.Location = new System.Drawing.Point(16, 12);
            this.labelX1.Name = "labelX1";
            this.labelX1.Size = new System.Drawing.Size(75, 23);
            this.labelX1.TabIndex = 44;
            this.labelX1.Text = "Nhân viên";
            // 
            // btn_send
            // 
            this.btn_send.Image = global::TENTAC_HRM.Properties.Resources.btn_send;
            this.btn_send.Location = new System.Drawing.Point(311, 399);
            this.btn_send.Name = "btn_send";
            this.btn_send.Size = new System.Drawing.Size(70, 30);
            this.btn_send.TabIndex = 8;
            this.btn_send.Text = "Lưu";
            this.btn_send.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btn_send.UseVisualStyleBackColor = true;
            this.btn_send.Click += new System.EventHandler(this.btn_send_Click);
            // 
            // lv_Ngay
            // 
            this.lv_Ngay.CheckOnClick = true;
            this.lv_Ngay.ColumnWidth = 50;
            this.lv_Ngay.ForeColor = System.Drawing.Color.Blue;
            this.lv_Ngay.FormattingEnabled = true;
            this.lv_Ngay.Location = new System.Drawing.Point(104, 177);
            this.lv_Ngay.MultiColumn = true;
            this.lv_Ngay.Name = "lv_Ngay";
            this.lv_Ngay.Size = new System.Drawing.Size(359, 94);
            this.lv_Ngay.TabIndex = 41;
            // 
            // chk_BuoiChieu
            // 
            this.chk_BuoiChieu.Location = new System.Drawing.Point(225, 277);
            this.chk_BuoiChieu.Name = "chk_BuoiChieu";
            this.chk_BuoiChieu.Size = new System.Drawing.Size(123, 23);
            this.chk_BuoiChieu.TabIndex = 6;
            this.chk_BuoiChieu.Text = "Nghỉ buổi chiều";
            // 
            // chk_BuoiSang
            // 
            this.chk_BuoiSang.Location = new System.Drawing.Point(104, 277);
            this.chk_BuoiSang.Name = "chk_BuoiSang";
            this.chk_BuoiSang.Size = new System.Drawing.Size(115, 23);
            this.chk_BuoiSang.TabIndex = 5;
            this.chk_BuoiSang.Text = "Nghỉ buổi sáng";
            // 
            // cbo_Nam
            // 
            this.cbo_Nam.DisplayMember = "Text";
            this.cbo_Nam.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.cbo_Nam.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbo_Nam.FormattingEnabled = true;
            this.cbo_Nam.ItemHeight = 17;
            this.cbo_Nam.Location = new System.Drawing.Point(247, 146);
            this.cbo_Nam.Name = "cbo_Nam";
            this.cbo_Nam.Size = new System.Drawing.Size(73, 23);
            this.cbo_Nam.TabIndex = 4;
            this.cbo_Nam.SelectedIndexChanged += new System.EventHandler(this.cbo_Nam_SelectedIndexChanged);
            // 
            // cbo_Thang
            // 
            this.cbo_Thang.DisplayMember = "Text";
            this.cbo_Thang.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.cbo_Thang.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbo_Thang.FormattingEnabled = true;
            this.cbo_Thang.ItemHeight = 17;
            this.cbo_Thang.Location = new System.Drawing.Point(151, 147);
            this.cbo_Thang.Name = "cbo_Thang";
            this.cbo_Thang.Size = new System.Drawing.Size(55, 23);
            this.cbo_Thang.TabIndex = 3;
            // 
            // txt_NhanVien
            // 
            // 
            // 
            // 
            this.txt_NhanVien.Border.Class = "TextBoxBorder";
            this.txt_NhanVien.Location = new System.Drawing.Point(104, 42);
            this.txt_NhanVien.Multiline = true;
            this.txt_NhanVien.Name = "txt_NhanVien";
            this.txt_NhanVien.Size = new System.Drawing.Size(359, 70);
            this.txt_NhanVien.TabIndex = 54;
            // 
            // frm_annual_leave
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(478, 443);
            this.Controls.Add(this.panel1);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "frm_annual_leave";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Nghỉ phép";
            this.Load += new System.EventHandler(this.frm_annual_leave_Load);
            this.panel1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button btn_send;
        private System.Windows.Forms.CheckedListBox lv_Ngay;
        private DevComponents.DotNetBar.Controls.CheckBoxX chk_BuoiChieu;
        private DevComponents.DotNetBar.Controls.CheckBoxX chk_BuoiSang;
        private DevComponents.DotNetBar.Controls.ComboBoxEx cbo_Nam;
        private DevComponents.DotNetBar.Controls.ComboBoxEx cbo_Thang;
        private DevComponents.DotNetBar.LabelX labelX4;
        private DevComponents.DotNetBar.LabelX labelX3;
        private DevComponents.DotNetBar.LabelX labelX2;
        private DevComponents.DotNetBar.LabelX labelX1;
        private DevComponents.DotNetBar.LabelX labelX5;
        private DevComponents.DotNetBar.Controls.ComboBoxEx cbo_NhanVien;
        private DevComponents.DotNetBar.Controls.TextBoxX txt_NoiDung;
        private System.Windows.Forms.Button btn_cancel;
        private DevComponents.DotNetBar.Controls.TextBoxX txt_SoPhepNamTon;
        private DevComponents.DotNetBar.LabelX labelX6;
        private DevComponents.DotNetBar.Controls.ComboBoxEx cbo_LoaiPhep;
        private DevComponents.DotNetBar.Controls.TextBoxX txt_NhanVien;
    }
}