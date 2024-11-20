namespace TENTAC_HRM.Forms.ChamCong
{
    partial class uc_DangKyTangCa
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            this.groupPhongBan = new System.Windows.Forms.GroupBox();
            this.treeViewSoDoQuanLy = new System.Windows.Forms.TreeView();
            this.panel1 = new System.Windows.Forms.Panel();
            this.btn_search = new DevComponents.DotNetBar.ButtonX();
            this.txt_search = new DevComponents.DotNetBar.Controls.TextBoxX();
            this.panel2 = new System.Windows.Forms.Panel();
            this.gbNhanVien = new System.Windows.Forms.GroupBox();
            this.panel3 = new System.Windows.Forms.Panel();
            this.DGVNhanVien = new DevComponents.DotNetBar.Controls.DataGridViewX();
            this.MaNhanVien = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.TenNhanVien = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.MaChamCong = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.MaPhongBan = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.panel4 = new System.Windows.Forms.Panel();
            this.panel5 = new System.Windows.Forms.Panel();
            this.lb_TangCaToiThang = new System.Windows.Forms.Label();
            this.chk_month = new System.Windows.Forms.CheckBox();
            this.dtp_search = new System.Windows.Forms.DateTimePicker();
            this.dgv_dangkytangca = new DevComponents.DotNetBar.Controls.DataGridViewX();
            this.Id = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.chk_col = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.col_update = new System.Windows.Forms.DataGridViewImageColumn();
            this.col_delete = new System.Windows.Forms.DataGridViewImageColumn();
            this.MaChamCong_TC = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Ca = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.NgayTangCa = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.GioBatDau_DK = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.GioKetThuc_DK = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.LoaiTangCa = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.GioTangCa = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.LoaiTangCa_M = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.LuyKeThang = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.label4 = new System.Windows.Forms.Label();
            this.groupPhongBan.SuspendLayout();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.gbNhanVien.SuspendLayout();
            this.panel3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.DGVNhanVien)).BeginInit();
            this.panel4.SuspendLayout();
            this.panel5.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgv_dangkytangca)).BeginInit();
            this.SuspendLayout();
            // 
            // groupPhongBan
            // 
            this.groupPhongBan.Controls.Add(this.treeViewSoDoQuanLy);
            this.groupPhongBan.Dock = System.Windows.Forms.DockStyle.Left;
            this.groupPhongBan.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupPhongBan.Location = new System.Drawing.Point(0, 0);
            this.groupPhongBan.Name = "groupPhongBan";
            this.groupPhongBan.Padding = new System.Windows.Forms.Padding(5);
            this.groupPhongBan.Size = new System.Drawing.Size(268, 835);
            this.groupPhongBan.TabIndex = 23;
            this.groupPhongBan.TabStop = false;
            this.groupPhongBan.Text = "Phòng ban";
            // 
            // treeViewSoDoQuanLy
            // 
            this.treeViewSoDoQuanLy.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.treeViewSoDoQuanLy.Dock = System.Windows.Forms.DockStyle.Fill;
            this.treeViewSoDoQuanLy.Font = new System.Drawing.Font("Tahoma", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.treeViewSoDoQuanLy.ImageKey = "No.png";
            this.treeViewSoDoQuanLy.Location = new System.Drawing.Point(5, 20);
            this.treeViewSoDoQuanLy.Name = "treeViewSoDoQuanLy";
            this.treeViewSoDoQuanLy.Size = new System.Drawing.Size(258, 810);
            this.treeViewSoDoQuanLy.TabIndex = 10;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.gbNhanVien);
            this.panel1.Controls.Add(this.panel2);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Left;
            this.panel1.Location = new System.Drawing.Point(268, 0);
            this.panel1.Name = "panel1";
            this.panel1.Padding = new System.Windows.Forms.Padding(6);
            this.panel1.Size = new System.Drawing.Size(381, 835);
            this.panel1.TabIndex = 24;
            // 
            // btn_search
            // 
            this.btn_search.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.btn_search.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            this.btn_search.Location = new System.Drawing.Point(278, 3);
            this.btn_search.Name = "btn_search";
            this.btn_search.Size = new System.Drawing.Size(91, 23);
            this.btn_search.TabIndex = 34;
            this.btn_search.Text = "Tìm kiếm";
            // 
            // txt_search
            // 
            // 
            // 
            // 
            this.txt_search.Border.Class = "TextBoxBorder";
            this.txt_search.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txt_search.Location = new System.Drawing.Point(0, 3);
            this.txt_search.Name = "txt_search";
            this.txt_search.Size = new System.Drawing.Size(271, 22);
            this.txt_search.TabIndex = 33;
            this.txt_search.WatermarkText = "Nhập mã hoặc tên nhân viên";
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.txt_search);
            this.panel2.Controls.Add(this.btn_search);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel2.Location = new System.Drawing.Point(6, 6);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(369, 29);
            this.panel2.TabIndex = 35;
            // 
            // gbNhanVien
            // 
            this.gbNhanVien.Controls.Add(this.panel3);
            this.gbNhanVien.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gbNhanVien.Location = new System.Drawing.Point(6, 35);
            this.gbNhanVien.Name = "gbNhanVien";
            this.gbNhanVien.Size = new System.Drawing.Size(369, 794);
            this.gbNhanVien.TabIndex = 36;
            this.gbNhanVien.TabStop = false;
            this.gbNhanVien.Text = "Nhân viên :";
            // 
            // panel3
            // 
            this.panel3.Controls.Add(this.DGVNhanVien);
            this.panel3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel3.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.panel3.Location = new System.Drawing.Point(3, 16);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(363, 775);
            this.panel3.TabIndex = 6;
            // 
            // DGVNhanVien
            // 
            this.DGVNhanVien.AllowUserToAddRows = false;
            this.DGVNhanVien.BackgroundColor = System.Drawing.Color.GhostWhite;
            this.DGVNhanVien.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.DGVNhanVien.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.MaNhanVien,
            this.TenNhanVien,
            this.MaChamCong,
            this.MaPhongBan});
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.DGVNhanVien.DefaultCellStyle = dataGridViewCellStyle1;
            this.DGVNhanVien.Dock = System.Windows.Forms.DockStyle.Fill;
            this.DGVNhanVien.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(215)))), ((int)(((byte)(229)))));
            this.DGVNhanVien.Location = new System.Drawing.Point(0, 0);
            this.DGVNhanVien.Name = "DGVNhanVien";
            this.DGVNhanVien.RowHeadersWidth = 23;
            this.DGVNhanVien.Size = new System.Drawing.Size(363, 775);
            this.DGVNhanVien.TabIndex = 4;
            // 
            // MaNhanVien
            // 
            this.MaNhanVien.DataPropertyName = "MaNhanVien";
            this.MaNhanVien.HeaderText = "Mã Nhân viên";
            this.MaNhanVien.Name = "MaNhanVien";
            this.MaNhanVien.Width = 110;
            // 
            // TenNhanVien
            // 
            this.TenNhanVien.DataPropertyName = "TenNhanVien";
            this.TenNhanVien.FillWeight = 120F;
            this.TenNhanVien.HeaderText = "Tên Nhân Viên";
            this.TenNhanVien.Name = "TenNhanVien";
            this.TenNhanVien.Width = 230;
            // 
            // MaChamCong
            // 
            this.MaChamCong.DataPropertyName = "MaChamCong";
            this.MaChamCong.HeaderText = "Mã Chấm Công";
            this.MaChamCong.Name = "MaChamCong";
            this.MaChamCong.Visible = false;
            // 
            // MaPhongBan
            // 
            this.MaPhongBan.DataPropertyName = "MaPhongBan";
            this.MaPhongBan.HeaderText = "MaPhongBan";
            this.MaPhongBan.Name = "MaPhongBan";
            this.MaPhongBan.Visible = false;
            // 
            // panel4
            // 
            this.panel4.Controls.Add(this.label4);
            this.panel4.Controls.Add(this.dgv_dangkytangca);
            this.panel4.Controls.Add(this.panel5);
            this.panel4.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel4.Location = new System.Drawing.Point(649, 0);
            this.panel4.Name = "panel4";
            this.panel4.Padding = new System.Windows.Forms.Padding(0, 6, 6, 0);
            this.panel4.Size = new System.Drawing.Size(627, 835);
            this.panel4.TabIndex = 25;
            // 
            // panel5
            // 
            this.panel5.Controls.Add(this.lb_TangCaToiThang);
            this.panel5.Controls.Add(this.chk_month);
            this.panel5.Controls.Add(this.dtp_search);
            this.panel5.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel5.Location = new System.Drawing.Point(0, 6);
            this.panel5.Name = "panel5";
            this.panel5.Padding = new System.Windows.Forms.Padding(0, 6, 0, 0);
            this.panel5.Size = new System.Drawing.Size(621, 29);
            this.panel5.TabIndex = 0;
            // 
            // lb_TangCaToiThang
            // 
            this.lb_TangCaToiThang.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lb_TangCaToiThang.ForeColor = System.Drawing.Color.Coral;
            this.lb_TangCaToiThang.Location = new System.Drawing.Point(327, 3);
            this.lb_TangCaToiThang.Name = "lb_TangCaToiThang";
            this.lb_TangCaToiThang.Size = new System.Drawing.Size(265, 23);
            this.lb_TangCaToiThang.TabIndex = 40;
            this.lb_TangCaToiThang.Text = "label10";
            this.lb_TangCaToiThang.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // chk_month
            // 
            this.chk_month.AutoSize = true;
            this.chk_month.Location = new System.Drawing.Point(10, 6);
            this.chk_month.Name = "chk_month";
            this.chk_month.Size = new System.Drawing.Size(81, 17);
            this.chk_month.TabIndex = 39;
            this.chk_month.Text = "Theo tháng";
            this.chk_month.UseVisualStyleBackColor = true;
            // 
            // dtp_search
            // 
            this.dtp_search.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtp_search.Location = new System.Drawing.Point(97, 4);
            this.dtp_search.Name = "dtp_search";
            this.dtp_search.Size = new System.Drawing.Size(119, 20);
            this.dtp_search.TabIndex = 38;
            // 
            // dgv_dangkytangca
            // 
            this.dgv_dangkytangca.AllowUserToAddRows = false;
            this.dgv_dangkytangca.BackgroundColor = System.Drawing.Color.GhostWhite;
            this.dgv_dangkytangca.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgv_dangkytangca.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Id,
            this.chk_col,
            this.col_update,
            this.col_delete,
            this.MaChamCong_TC,
            this.Ca,
            this.NgayTangCa,
            this.GioBatDau_DK,
            this.GioKetThuc_DK,
            this.LoaiTangCa,
            this.GioTangCa,
            this.LoaiTangCa_M,
            this.LuyKeThang});
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgv_dangkytangca.DefaultCellStyle = dataGridViewCellStyle2;
            this.dgv_dangkytangca.Dock = System.Windows.Forms.DockStyle.Top;
            this.dgv_dangkytangca.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(215)))), ((int)(((byte)(229)))));
            this.dgv_dangkytangca.Location = new System.Drawing.Point(0, 35);
            this.dgv_dangkytangca.Name = "dgv_dangkytangca";
            this.dgv_dangkytangca.Size = new System.Drawing.Size(621, 303);
            this.dgv_dangkytangca.TabIndex = 28;
            // 
            // Id
            // 
            this.Id.DataPropertyName = "Id";
            this.Id.Frozen = true;
            this.Id.HeaderText = "Id";
            this.Id.Name = "Id";
            this.Id.Visible = false;
            // 
            // chk_col
            // 
            this.chk_col.Frozen = true;
            this.chk_col.HeaderText = "";
            this.chk_col.Name = "chk_col";
            this.chk_col.Width = 30;
            // 
            // col_update
            // 
            this.col_update.HeaderText = "Sửa";
            this.col_update.Name = "col_update";
            this.col_update.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.col_update.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            this.col_update.Width = 30;
            // 
            // col_delete
            // 
            this.col_delete.HeaderText = "Xóa";
            this.col_delete.Name = "col_delete";
            this.col_delete.Width = 30;
            // 
            // MaChamCong_TC
            // 
            this.MaChamCong_TC.DataPropertyName = "MaChamCong";
            this.MaChamCong_TC.HeaderText = "Mã CC";
            this.MaChamCong_TC.Name = "MaChamCong_TC";
            this.MaChamCong_TC.Width = 65;
            // 
            // Ca
            // 
            this.Ca.DataPropertyName = "Ca";
            this.Ca.HeaderText = "Ca";
            this.Ca.Name = "Ca";
            this.Ca.Width = 40;
            // 
            // NgayTangCa
            // 
            this.NgayTangCa.DataPropertyName = "NgayTangCa";
            this.NgayTangCa.HeaderText = "Ngày tăng ca";
            this.NgayTangCa.Name = "NgayTangCa";
            // 
            // GioBatDau_DK
            // 
            this.GioBatDau_DK.DataPropertyName = "GioBatDau";
            this.GioBatDau_DK.HeaderText = "Giờ bắt đầu";
            this.GioBatDau_DK.Name = "GioBatDau_DK";
            // 
            // GioKetThuc_DK
            // 
            this.GioKetThuc_DK.DataPropertyName = "GioKetThuc";
            this.GioKetThuc_DK.HeaderText = "Giờ kết thúc";
            this.GioKetThuc_DK.Name = "GioKetThuc_DK";
            // 
            // LoaiTangCa
            // 
            this.LoaiTangCa.DataPropertyName = "LoaiTangCa";
            this.LoaiTangCa.HeaderText = "Loại tăng ca";
            this.LoaiTangCa.Name = "LoaiTangCa";
            // 
            // GioTangCa
            // 
            this.GioTangCa.DataPropertyName = "GioTangCa";
            this.GioTangCa.HeaderText = "Giờ tăng ca";
            this.GioTangCa.Name = "GioTangCa";
            // 
            // LoaiTangCa_M
            // 
            this.LoaiTangCa_M.DataPropertyName = "LoaiTangCa_M";
            this.LoaiTangCa_M.HeaderText = "LoaiTangCa_M";
            this.LoaiTangCa_M.Name = "LoaiTangCa_M";
            this.LoaiTangCa_M.Visible = false;
            // 
            // LuyKeThang
            // 
            this.LuyKeThang.DataPropertyName = "LuyKeThang";
            this.LuyKeThang.HeaderText = "Lũy kế tháng";
            this.LuyKeThang.Name = "LuyKeThang";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(56, 365);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(80, 13);
            this.label4.TabIndex = 35;
            this.label4.Text = "Đăng ký sai giờ";
            // 
            // uc_DangKyTangCa
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.panel4);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.groupPhongBan);
            this.Name = "uc_DangKyTangCa";
            this.Size = new System.Drawing.Size(1276, 835);
            this.groupPhongBan.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            this.gbNhanVien.ResumeLayout(false);
            this.panel3.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.DGVNhanVien)).EndInit();
            this.panel4.ResumeLayout(false);
            this.panel4.PerformLayout();
            this.panel5.ResumeLayout(false);
            this.panel5.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgv_dangkytangca)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupPhongBan;
        private System.Windows.Forms.TreeView treeViewSoDoQuanLy;
        private System.Windows.Forms.Panel panel1;
        private DevComponents.DotNetBar.ButtonX btn_search;
        private DevComponents.DotNetBar.Controls.TextBoxX txt_search;
        private System.Windows.Forms.GroupBox gbNhanVien;
        private System.Windows.Forms.Panel panel3;
        private DevComponents.DotNetBar.Controls.DataGridViewX DGVNhanVien;
        private System.Windows.Forms.DataGridViewTextBoxColumn MaNhanVien;
        private System.Windows.Forms.DataGridViewTextBoxColumn TenNhanVien;
        private System.Windows.Forms.DataGridViewTextBoxColumn MaChamCong;
        private System.Windows.Forms.DataGridViewTextBoxColumn MaPhongBan;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Panel panel4;
        private System.Windows.Forms.Panel panel5;
        private System.Windows.Forms.Label lb_TangCaToiThang;
        private System.Windows.Forms.CheckBox chk_month;
        private System.Windows.Forms.DateTimePicker dtp_search;
        private System.Windows.Forms.Label label4;
        private DevComponents.DotNetBar.Controls.DataGridViewX dgv_dangkytangca;
        private System.Windows.Forms.DataGridViewTextBoxColumn Id;
        private System.Windows.Forms.DataGridViewCheckBoxColumn chk_col;
        private System.Windows.Forms.DataGridViewImageColumn col_update;
        private System.Windows.Forms.DataGridViewImageColumn col_delete;
        private System.Windows.Forms.DataGridViewTextBoxColumn MaChamCong_TC;
        private System.Windows.Forms.DataGridViewTextBoxColumn Ca;
        private System.Windows.Forms.DataGridViewTextBoxColumn NgayTangCa;
        private System.Windows.Forms.DataGridViewTextBoxColumn GioBatDau_DK;
        private System.Windows.Forms.DataGridViewTextBoxColumn GioKetThuc_DK;
        private System.Windows.Forms.DataGridViewTextBoxColumn LoaiTangCa;
        private System.Windows.Forms.DataGridViewTextBoxColumn GioTangCa;
        private System.Windows.Forms.DataGridViewTextBoxColumn LoaiTangCa_M;
        private System.Windows.Forms.DataGridViewTextBoxColumn LuyKeThang;
    }
}
