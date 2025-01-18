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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle6 = new System.Windows.Forms.DataGridViewCellStyle();
            this.panel1 = new System.Windows.Forms.Panel();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.cbo_LoaiPhep = new DevComponents.DotNetBar.Controls.ComboBoxEx();
            this.cbo_Thang = new DevComponents.DotNetBar.Controls.ComboBoxEx();
            this.cbo_Nam = new DevComponents.DotNetBar.Controls.ComboBoxEx();
            this.chk_BuoiSang = new DevComponents.DotNetBar.Controls.CheckBoxX();
            this.chk_BuoiChieu = new DevComponents.DotNetBar.Controls.CheckBoxX();
            this.lv_Ngay = new System.Windows.Forms.CheckedListBox();
            this.btn_cancel = new System.Windows.Forms.Button();
            this.btn_send = new System.Windows.Forms.Button();
            this.txt_NoiDung = new DevComponents.DotNetBar.Controls.TextBoxX();
            this.labelX2 = new DevComponents.DotNetBar.LabelX();
            this.labelX3 = new DevComponents.DotNetBar.LabelX();
            this.labelX5 = new DevComponents.DotNetBar.LabelX();
            this.labelX4 = new DevComponents.DotNetBar.LabelX();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.dgv_NhanVien = new DevComponents.DotNetBar.Controls.DataGridViewX();
            this.chk_col = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.MaNhanVien = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.TenNhanVien = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.TenPhongBan = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.TongNgayNghi = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.PhepTon = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.panel1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgv_NhanVien)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.groupBox2);
            this.panel1.Controls.Add(this.groupBox1);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1051, 555);
            this.panel1.TabIndex = 1;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.cbo_LoaiPhep);
            this.groupBox2.Controls.Add(this.cbo_Thang);
            this.groupBox2.Controls.Add(this.cbo_Nam);
            this.groupBox2.Controls.Add(this.chk_BuoiSang);
            this.groupBox2.Controls.Add(this.chk_BuoiChieu);
            this.groupBox2.Controls.Add(this.lv_Ngay);
            this.groupBox2.Controls.Add(this.btn_cancel);
            this.groupBox2.Controls.Add(this.btn_send);
            this.groupBox2.Controls.Add(this.txt_NoiDung);
            this.groupBox2.Controls.Add(this.labelX2);
            this.groupBox2.Controls.Add(this.labelX3);
            this.groupBox2.Controls.Add(this.labelX5);
            this.groupBox2.Controls.Add(this.labelX4);
            this.groupBox2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox2.Location = new System.Drawing.Point(637, 0);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(414, 555);
            this.groupBox2.TabIndex = 56;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Đăng ký nghỉ phép";
            // 
            // cbo_LoaiPhep
            // 
            this.cbo_LoaiPhep.DisplayMember = "Text";
            this.cbo_LoaiPhep.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.cbo_LoaiPhep.FormattingEnabled = true;
            this.cbo_LoaiPhep.ItemHeight = 17;
            this.cbo_LoaiPhep.Location = new System.Drawing.Point(98, 25);
            this.cbo_LoaiPhep.Name = "cbo_LoaiPhep";
            this.cbo_LoaiPhep.Size = new System.Drawing.Size(308, 23);
            this.cbo_LoaiPhep.TabIndex = 53;
            // 
            // cbo_Thang
            // 
            this.cbo_Thang.DisplayMember = "Text";
            this.cbo_Thang.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.cbo_Thang.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbo_Thang.FormattingEnabled = true;
            this.cbo_Thang.ItemHeight = 17;
            this.cbo_Thang.Location = new System.Drawing.Point(145, 54);
            this.cbo_Thang.Name = "cbo_Thang";
            this.cbo_Thang.Size = new System.Drawing.Size(55, 23);
            this.cbo_Thang.TabIndex = 3;
            this.cbo_Thang.SelectionChangeCommitted += new System.EventHandler(this.cbo_Thang_SelectionChangeCommitted);
            // 
            // cbo_Nam
            // 
            this.cbo_Nam.DisplayMember = "Text";
            this.cbo_Nam.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.cbo_Nam.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbo_Nam.FormattingEnabled = true;
            this.cbo_Nam.ItemHeight = 17;
            this.cbo_Nam.Location = new System.Drawing.Point(241, 53);
            this.cbo_Nam.Name = "cbo_Nam";
            this.cbo_Nam.Size = new System.Drawing.Size(73, 23);
            this.cbo_Nam.TabIndex = 4;
            this.cbo_Nam.SelectedIndexChanged += new System.EventHandler(this.cbo_Nam_SelectedIndexChanged);
            this.cbo_Nam.SelectionChangeCommitted += new System.EventHandler(this.cbo_Nam_SelectionChangeCommitted);
            // 
            // chk_BuoiSang
            // 
            this.chk_BuoiSang.Location = new System.Drawing.Point(98, 199);
            this.chk_BuoiSang.Name = "chk_BuoiSang";
            this.chk_BuoiSang.Size = new System.Drawing.Size(115, 23);
            this.chk_BuoiSang.TabIndex = 5;
            this.chk_BuoiSang.Text = "Nghỉ buổi sáng";
            this.chk_BuoiSang.CheckedChanged += new System.EventHandler(this.chk_BuoiSang_CheckedChanged);
            // 
            // chk_BuoiChieu
            // 
            this.chk_BuoiChieu.Location = new System.Drawing.Point(219, 199);
            this.chk_BuoiChieu.Name = "chk_BuoiChieu";
            this.chk_BuoiChieu.Size = new System.Drawing.Size(123, 23);
            this.chk_BuoiChieu.TabIndex = 6;
            this.chk_BuoiChieu.Text = "Nghỉ buổi chiều";
            this.chk_BuoiChieu.CheckedChanged += new System.EventHandler(this.chk_BuoiChieu_CheckedChanged);
            // 
            // lv_Ngay
            // 
            this.lv_Ngay.CheckOnClick = true;
            this.lv_Ngay.ColumnWidth = 50;
            this.lv_Ngay.ForeColor = System.Drawing.Color.Blue;
            this.lv_Ngay.FormattingEnabled = true;
            this.lv_Ngay.Location = new System.Drawing.Point(98, 81);
            this.lv_Ngay.MultiColumn = true;
            this.lv_Ngay.Name = "lv_Ngay";
            this.lv_Ngay.Size = new System.Drawing.Size(308, 112);
            this.lv_Ngay.TabIndex = 41;
            // 
            // btn_cancel
            // 
            this.btn_cancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btn_cancel.Image = global::TENTAC_HRM.Properties.Resources.cancel;
            this.btn_cancel.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btn_cancel.Location = new System.Drawing.Point(329, 319);
            this.btn_cancel.Name = "btn_cancel";
            this.btn_cancel.Size = new System.Drawing.Size(76, 30);
            this.btn_cancel.TabIndex = 50;
            this.btn_cancel.Text = "Đóng";
            this.btn_cancel.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btn_cancel.UseVisualStyleBackColor = true;
            this.btn_cancel.Click += new System.EventHandler(this.btn_cancel_Click);
            // 
            // btn_send
            // 
            this.btn_send.Image = global::TENTAC_HRM.Properties.Resources.btn_send;
            this.btn_send.Location = new System.Drawing.Point(253, 319);
            this.btn_send.Name = "btn_send";
            this.btn_send.Size = new System.Drawing.Size(70, 30);
            this.btn_send.TabIndex = 8;
            this.btn_send.Text = "Lưu";
            this.btn_send.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btn_send.UseVisualStyleBackColor = true;
            this.btn_send.Click += new System.EventHandler(this.btn_send_Click);
            // 
            // txt_NoiDung
            // 
            // 
            // 
            // 
            this.txt_NoiDung.Border.Class = "TextBoxBorder";
            this.txt_NoiDung.Location = new System.Drawing.Point(98, 228);
            this.txt_NoiDung.Multiline = true;
            this.txt_NoiDung.Name = "txt_NoiDung";
            this.txt_NoiDung.Size = new System.Drawing.Size(308, 85);
            this.txt_NoiDung.TabIndex = 7;
            // 
            // labelX2
            // 
            this.labelX2.Location = new System.Drawing.Point(10, 25);
            this.labelX2.Name = "labelX2";
            this.labelX2.Size = new System.Drawing.Size(75, 23);
            this.labelX2.TabIndex = 45;
            this.labelX2.Text = "Loại phép";
            // 
            // labelX3
            // 
            this.labelX3.Location = new System.Drawing.Point(14, 227);
            this.labelX3.Name = "labelX3";
            this.labelX3.Size = new System.Drawing.Size(75, 23);
            this.labelX3.TabIndex = 46;
            this.labelX3.Text = "Nội dung";
            // 
            // labelX5
            // 
            this.labelX5.Location = new System.Drawing.Point(207, 55);
            this.labelX5.Name = "labelX5";
            this.labelX5.Size = new System.Drawing.Size(38, 23);
            this.labelX5.TabIndex = 48;
            this.labelX5.Text = "Năm";
            // 
            // labelX4
            // 
            this.labelX4.Location = new System.Drawing.Point(98, 54);
            this.labelX4.Name = "labelX4";
            this.labelX4.Size = new System.Drawing.Size(52, 23);
            this.labelX4.TabIndex = 47;
            this.labelX4.Text = "Tháng";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.dgv_NhanVien);
            this.groupBox1.Dock = System.Windows.Forms.DockStyle.Left;
            this.groupBox1.Location = new System.Drawing.Point(0, 0);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(637, 555);
            this.groupBox1.TabIndex = 55;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Thông tin nhân viên";
            // 
            // dgv_NhanVien
            // 
            this.dgv_NhanVien.AllowUserToAddRows = false;
            this.dgv_NhanVien.BackgroundColor = System.Drawing.SystemColors.Control;
            this.dgv_NhanVien.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgv_NhanVien.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.chk_col,
            this.MaNhanVien,
            this.TenNhanVien,
            this.TenPhongBan,
            this.TongNgayNghi,
            this.PhepTon});
            dataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle6.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle6.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            dataGridViewCellStyle6.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle6.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle6.SelectionForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle6.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgv_NhanVien.DefaultCellStyle = dataGridViewCellStyle6;
            this.dgv_NhanVien.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgv_NhanVien.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(215)))), ((int)(((byte)(229)))));
            this.dgv_NhanVien.Location = new System.Drawing.Point(3, 19);
            this.dgv_NhanVien.Name = "dgv_NhanVien";
            this.dgv_NhanVien.Size = new System.Drawing.Size(631, 533);
            this.dgv_NhanVien.TabIndex = 0;
            // 
            // chk_col
            // 
            this.chk_col.Frozen = true;
            this.chk_col.HeaderText = "";
            this.chk_col.Name = "chk_col";
            this.chk_col.Width = 30;
            // 
            // MaNhanVien
            // 
            this.MaNhanVien.DataPropertyName = "MaNhanVien";
            this.MaNhanVien.Frozen = true;
            this.MaNhanVien.HeaderText = "Mã nhân viên";
            this.MaNhanVien.Name = "MaNhanVien";
            this.MaNhanVien.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.MaNhanVien.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.MaNhanVien.Width = 80;
            // 
            // TenNhanVien
            // 
            this.TenNhanVien.DataPropertyName = "TenNhanVien";
            this.TenNhanVien.HeaderText = "Tên nhân viên";
            this.TenNhanVien.Name = "TenNhanVien";
            this.TenNhanVien.Width = 200;
            // 
            // TenPhongBan
            // 
            this.TenPhongBan.DataPropertyName = "TenPhongBan";
            this.TenPhongBan.HeaderText = "Phòng ban";
            this.TenPhongBan.Name = "TenPhongBan";
            this.TenPhongBan.Width = 80;
            // 
            // TongNgayNghi
            // 
            this.TongNgayNghi.DataPropertyName = "TongNgayNghi";
            this.TongNgayNghi.HeaderText = "Tổng ngày nghỉ";
            this.TongNgayNghi.Name = "TongNgayNghi";
            // 
            // PhepTon
            // 
            this.PhepTon.DataPropertyName = "PhepTon";
            this.PhepTon.HeaderText = "Phép tồn";
            this.PhepTon.Name = "PhepTon";
            // 
            // frm_annual_leave
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1051, 555);
            this.Controls.Add(this.panel1);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "frm_annual_leave";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Nghỉ phép";
            this.Load += new System.EventHandler(this.frm_annual_leave_Load);
            this.panel1.ResumeLayout(false);
            this.groupBox2.ResumeLayout(false);
            this.groupBox1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgv_NhanVien)).EndInit();
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
        private DevComponents.DotNetBar.LabelX labelX5;
        private DevComponents.DotNetBar.Controls.TextBoxX txt_NoiDung;
        private System.Windows.Forms.Button btn_cancel;
        private DevComponents.DotNetBar.Controls.ComboBoxEx cbo_LoaiPhep;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.GroupBox groupBox1;
        private DevComponents.DotNetBar.Controls.DataGridViewX dgv_NhanVien;
        private System.Windows.Forms.DataGridViewCheckBoxColumn chk_col;
        private System.Windows.Forms.DataGridViewTextBoxColumn MaNhanVien;
        private System.Windows.Forms.DataGridViewTextBoxColumn TenNhanVien;
        private System.Windows.Forms.DataGridViewTextBoxColumn TenPhongBan;
        private System.Windows.Forms.DataGridViewTextBoxColumn TongNgayNghi;
        private System.Windows.Forms.DataGridViewTextBoxColumn PhepTon;
    }
}