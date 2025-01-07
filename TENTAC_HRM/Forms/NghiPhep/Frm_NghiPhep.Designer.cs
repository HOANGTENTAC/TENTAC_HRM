namespace TENTAC_HRM.Forms.NghiPhep
{
    partial class Frm_NghiPhep
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            this.panel3 = new System.Windows.Forms.Panel();
            this.dgv_annual_leave = new DevComponents.DotNetBar.Controls.DataGridViewX();
            this.id = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.IDTrangThaiP = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ReportToReportTo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.edit_column = new System.Windows.Forms.DataGridViewImageColumn();
            this.MaNhanVien = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.TenNhanVien = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.TenKhuVuc = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.TenChucVu = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.TrangThai = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.NgayNghi = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.NuaNgay = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.SoNgay = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.LoaiPhep = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.GhiChu = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.MaChucVu = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.NguoiXacNhan = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.TrangThaiPhieu = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.panel2 = new System.Windows.Forms.Panel();
            this.panel4 = new System.Windows.Forms.Panel();
            this.miniToolStrip = new System.Windows.Forms.ToolStrip();
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.toolStripLabel3 = new System.Windows.Forms.ToolStripLabel();
            this.cbo_Thang = new System.Windows.Forms.ToolStripComboBox();
            this.toolStripLabel1 = new System.Windows.Forms.ToolStripLabel();
            this.cbo_year = new System.Windows.Forms.ToolStripComboBox();
            this.toolStripLabel2 = new System.Windows.Forms.ToolStripLabel();
            this.cbo_trangthai = new System.Windows.Forms.ToolStripComboBox();
            this.btn_add = new System.Windows.Forms.ToolStripButton();
            this.btn_delete = new System.Windows.Forms.ToolStripButton();
            this.btn_Search = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.btn_Excel = new System.Windows.Forms.ToolStripButton();
            this.btn_close = new System.Windows.Forms.ToolStripButton();
            this.txt_search = new DevComponents.DotNetBar.Controls.TextBoxX();
            this.chk_TheoNam = new DevComponents.DotNetBar.Controls.CheckBoxX();
            ((System.ComponentModel.ISupportInitialize)(this.dgv_annual_leave)).BeginInit();
            this.panel2.SuspendLayout();
            this.toolStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel3
            // 
            this.panel3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel3.Location = new System.Drawing.Point(0, 0);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(1169, 36);
            this.panel3.TabIndex = 0;
            // 
            // dgv_annual_leave
            // 
            this.dgv_annual_leave.AllowUserToAddRows = false;
            this.dgv_annual_leave.BackgroundColor = System.Drawing.SystemColors.Control;
            this.dgv_annual_leave.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgv_annual_leave.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.id,
            this.IDTrangThaiP,
            this.ReportToReportTo,
            this.edit_column,
            this.MaNhanVien,
            this.TenNhanVien,
            this.TenKhuVuc,
            this.TenChucVu,
            this.TrangThai,
            this.NgayNghi,
            this.NuaNgay,
            this.SoNgay,
            this.LoaiPhep,
            this.GhiChu,
            this.MaChucVu,
            this.NguoiXacNhan,
            this.TrangThaiPhieu});
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            dataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgv_annual_leave.DefaultCellStyle = dataGridViewCellStyle3;
            this.dgv_annual_leave.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgv_annual_leave.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(215)))), ((int)(((byte)(229)))));
            this.dgv_annual_leave.Location = new System.Drawing.Point(0, 38);
            this.dgv_annual_leave.Name = "dgv_annual_leave";
            this.dgv_annual_leave.Size = new System.Drawing.Size(1279, 464);
            this.dgv_annual_leave.TabIndex = 4;
            this.dgv_annual_leave.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgv_annual_leave_CellClick);
            // 
            // id
            // 
            this.id.DataPropertyName = "id";
            this.id.HeaderText = "Column1";
            this.id.Name = "id";
            this.id.Visible = false;
            this.id.Width = 88;
            // 
            // IDTrangThaiP
            // 
            this.IDTrangThaiP.DataPropertyName = "IDTrangThai";
            this.IDTrangThaiP.HeaderText = "IDTrangThaiP";
            this.IDTrangThaiP.Name = "IDTrangThaiP";
            this.IDTrangThaiP.Visible = false;
            // 
            // ReportToReportTo
            // 
            this.ReportToReportTo.DataPropertyName = "ReportToReportTo";
            this.ReportToReportTo.HeaderText = "ReportToReportTo";
            this.ReportToReportTo.Name = "ReportToReportTo";
            this.ReportToReportTo.Visible = false;
            // 
            // edit_column
            // 
            this.edit_column.HeaderText = "";
            this.edit_column.Image = global::TENTAC_HRM.Properties.Resources.pen;
            this.edit_column.Name = "edit_column";
            this.edit_column.Width = 35;
            // 
            // MaNhanVien
            // 
            this.MaNhanVien.DataPropertyName = "MaNhanVien";
            this.MaNhanVien.HeaderText = "Mã nhân viên";
            this.MaNhanVien.Name = "MaNhanVien";
            this.MaNhanVien.Width = 118;
            // 
            // TenNhanVien
            // 
            this.TenNhanVien.DataPropertyName = "TenNhanVien";
            this.TenNhanVien.HeaderText = "Họ tên";
            this.TenNhanVien.Name = "TenNhanVien";
            this.TenNhanVien.Width = 200;
            // 
            // TenKhuVuc
            // 
            this.TenKhuVuc.DataPropertyName = "TenKhuVuc";
            this.TenKhuVuc.HeaderText = "Đơn vị";
            this.TenKhuVuc.Name = "TenKhuVuc";
            this.TenKhuVuc.Width = 73;
            // 
            // TenChucVu
            // 
            this.TenChucVu.DataPropertyName = "TenChucVu";
            this.TenChucVu.HeaderText = "Chức vụ";
            this.TenChucVu.Name = "TenChucVu";
            this.TenChucVu.Width = 84;
            // 
            // TrangThai
            // 
            this.TrangThai.DataPropertyName = "TrangThai";
            this.TrangThai.HeaderText = "Trạng thái";
            this.TrangThai.Name = "TrangThai";
            this.TrangThai.Visible = false;
            this.TrangThai.Width = 98;
            // 
            // NgayNghi
            // 
            this.NgayNghi.DataPropertyName = "NgayNghi";
            this.NgayNghi.HeaderText = "Ngày nghỉ";
            this.NgayNghi.Name = "NgayNghi";
            this.NgayNghi.Width = 97;
            // 
            // NuaNgay
            // 
            this.NuaNgay.DataPropertyName = "NuaNgay";
            this.NuaNgay.HeaderText = "Nghỉ nửa ngày";
            this.NuaNgay.Name = "NuaNgay";
            this.NuaNgay.Width = 125;
            // 
            // SoNgay
            // 
            this.SoNgay.DataPropertyName = "SoNgay";
            this.SoNgay.HeaderText = "Số ngày";
            this.SoNgay.Name = "SoNgay";
            this.SoNgay.Width = 85;
            // 
            // LoaiPhep
            // 
            this.LoaiPhep.DataPropertyName = "KyHieu";
            this.LoaiPhep.HeaderText = "Loại phép";
            this.LoaiPhep.Name = "LoaiPhep";
            this.LoaiPhep.Width = 96;
            // 
            // GhiChu
            // 
            this.GhiChu.DataPropertyName = "GhiChu";
            this.GhiChu.HeaderText = "Nội dung";
            this.GhiChu.Name = "GhiChu";
            this.GhiChu.Width = 90;
            // 
            // MaChucVu
            // 
            this.MaChucVu.DataPropertyName = "MaChucVu";
            this.MaChucVu.HeaderText = "Mã chức vụ";
            this.MaChucVu.Name = "MaChucVu";
            this.MaChucVu.Visible = false;
            this.MaChucVu.Width = 105;
            // 
            // NguoiXacNhan
            // 
            this.NguoiXacNhan.DataPropertyName = "NguoiXacNhan";
            this.NguoiXacNhan.HeaderText = "Người xác nhận";
            this.NguoiXacNhan.Name = "NguoiXacNhan";
            this.NguoiXacNhan.Width = 130;
            // 
            // TrangThaiPhieu
            // 
            this.TrangThaiPhieu.DataPropertyName = "TrangThaiPhieu";
            this.TrangThaiPhieu.HeaderText = "Trạng thái phiếu";
            this.TrangThaiPhieu.Name = "TrangThaiPhieu";
            this.TrangThaiPhieu.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.TrangThaiPhieu.Width = 150;
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.panel3);
            this.panel2.Controls.Add(this.panel4);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel2.Location = new System.Drawing.Point(0, 502);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(1279, 36);
            this.panel2.TabIndex = 5;
            // 
            // panel4
            // 
            this.panel4.Dock = System.Windows.Forms.DockStyle.Right;
            this.panel4.Location = new System.Drawing.Point(1169, 0);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(110, 36);
            this.panel4.TabIndex = 1;
            // 
            // miniToolStrip
            // 
            this.miniToolStrip.AccessibleName = "New item selection";
            this.miniToolStrip.AccessibleRole = System.Windows.Forms.AccessibleRole.ButtonDropDown;
            this.miniToolStrip.AutoSize = false;
            this.miniToolStrip.CanOverflow = false;
            this.miniToolStrip.Dock = System.Windows.Forms.DockStyle.None;
            this.miniToolStrip.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden;
            this.miniToolStrip.Location = new System.Drawing.Point(507, 3);
            this.miniToolStrip.Name = "miniToolStrip";
            this.miniToolStrip.Size = new System.Drawing.Size(1042, 25);
            this.miniToolStrip.TabIndex = 9;
            // 
            // toolStrip1
            // 
            this.toolStrip1.AutoSize = false;
            this.toolStrip1.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripLabel3,
            this.cbo_Thang,
            this.toolStripLabel1,
            this.cbo_year,
            this.toolStripLabel2,
            this.cbo_trangthai,
            this.btn_add,
            this.btn_delete,
            this.btn_Search,
            this.toolStripSeparator1,
            this.btn_Excel,
            this.btn_close});
            this.toolStrip1.Location = new System.Drawing.Point(0, 0);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(1279, 38);
            this.toolStrip1.TabIndex = 10;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // toolStripLabel3
            // 
            this.toolStripLabel3.Name = "toolStripLabel3";
            this.toolStripLabel3.Size = new System.Drawing.Size(40, 35);
            this.toolStripLabel3.Text = "Tháng";
            // 
            // cbo_Thang
            // 
            this.cbo_Thang.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbo_Thang.Name = "cbo_Thang";
            this.cbo_Thang.Size = new System.Drawing.Size(75, 38);
            // 
            // toolStripLabel1
            // 
            this.toolStripLabel1.Name = "toolStripLabel1";
            this.toolStripLabel1.Size = new System.Drawing.Size(33, 35);
            this.toolStripLabel1.Text = "Năm";
            // 
            // cbo_year
            // 
            this.cbo_year.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbo_year.Name = "cbo_year";
            this.cbo_year.Size = new System.Drawing.Size(75, 38);
            // 
            // toolStripLabel2
            // 
            this.toolStripLabel2.Name = "toolStripLabel2";
            this.toolStripLabel2.Size = new System.Drawing.Size(59, 35);
            this.toolStripLabel2.Text = "Trạng thái";
            // 
            // cbo_trangthai
            // 
            this.cbo_trangthai.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbo_trangthai.Name = "cbo_trangthai";
            this.cbo_trangthai.Size = new System.Drawing.Size(121, 38);
            this.cbo_trangthai.SelectedIndexChanged += new System.EventHandler(this.cbo_trangthai_SelectedIndexChanged);
            // 
            // btn_add
            // 
            this.btn_add.Image = global::TENTAC_HRM.Properties.Resources.add_file;
            this.btn_add.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btn_add.Name = "btn_add";
            this.btn_add.Size = new System.Drawing.Size(57, 35);
            this.btn_add.Text = "Thêm";
            this.btn_add.Click += new System.EventHandler(this.btn_add_Click);
            // 
            // btn_delete
            // 
            this.btn_delete.Image = global::TENTAC_HRM.Properties.Resources.bin;
            this.btn_delete.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btn_delete.Name = "btn_delete";
            this.btn_delete.Size = new System.Drawing.Size(47, 35);
            this.btn_delete.Text = "Xóa";
            this.btn_delete.Click += new System.EventHandler(this.btn_delete_Click);
            // 
            // btn_Search
            // 
            this.btn_Search.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.btn_Search.Image = global::TENTAC_HRM.Properties.Resources.btnTim;
            this.btn_Search.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btn_Search.Name = "btn_Search";
            this.btn_Search.Size = new System.Drawing.Size(76, 35);
            this.btn_Search.Text = "Tìm kiếm";
            this.btn_Search.Click += new System.EventHandler(this.btn_Search_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(6, 38);
            // 
            // btn_Excel
            // 
            this.btn_Excel.Image = global::TENTAC_HRM.Properties.Resources.export_excel;
            this.btn_Excel.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btn_Excel.Name = "btn_Excel";
            this.btn_Excel.Size = new System.Drawing.Size(81, 35);
            this.btn_Excel.Text = "Xuất Excel";
            this.btn_Excel.Click += new System.EventHandler(this.btn_Excel_Click);
            // 
            // btn_close
            // 
            this.btn_close.Image = global::TENTAC_HRM.Properties.Resources.clear;
            this.btn_close.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btn_close.Name = "btn_close";
            this.btn_close.Size = new System.Drawing.Size(56, 35);
            this.btn_close.Text = "Đóng";
            this.btn_close.Click += new System.EventHandler(this.btn_close_Click);
            // 
            // txt_search
            // 
            this.txt_search.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            // 
            // 
            // 
            this.txt_search.Border.Class = "TextBoxBorder";
            this.txt_search.Location = new System.Drawing.Point(987, 7);
            this.txt_search.Name = "txt_search";
            this.txt_search.Size = new System.Drawing.Size(211, 23);
            this.txt_search.TabIndex = 11;
            this.txt_search.WatermarkText = "Từ khóa tìm kiếm";
            // 
            // chk_TheoNam
            // 
            this.chk_TheoNam.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.chk_TheoNam.BackColor = System.Drawing.Color.Transparent;
            this.chk_TheoNam.Location = new System.Drawing.Point(864, 7);
            this.chk_TheoNam.Name = "chk_TheoNam";
            this.chk_TheoNam.Size = new System.Drawing.Size(117, 23);
            this.chk_TheoNam.TabIndex = 12;
            this.chk_TheoNam.Text = "Xem theo nam";
            // 
            // Frm_NghiPhep
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1279, 538);
            this.Controls.Add(this.chk_TheoNam);
            this.Controls.Add(this.txt_search);
            this.Controls.Add(this.dgv_annual_leave);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.toolStrip1);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "Frm_NghiPhep";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Đăng ký nghỉ phép";
            this.Load += new System.EventHandler(this.uc_nghiphep_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgv_annual_leave)).EndInit();
            this.panel2.ResumeLayout(false);
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Panel panel3;
        private DevComponents.DotNetBar.Controls.DataGridViewX dgv_annual_leave;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Panel panel4;
        private System.Windows.Forms.ToolStrip miniToolStrip;
        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripLabel toolStripLabel1;
        private System.Windows.Forms.ToolStripComboBox cbo_year;
        private System.Windows.Forms.ToolStripLabel toolStripLabel2;
        private System.Windows.Forms.ToolStripComboBox cbo_trangthai;
        private System.Windows.Forms.ToolStripButton btn_add;
        private System.Windows.Forms.ToolStripButton btn_delete;
        private System.Windows.Forms.ToolStripButton btn_close;
        private System.Windows.Forms.ToolStripButton btn_Search;
        private DevComponents.DotNetBar.Controls.TextBoxX txt_search;
        private System.Windows.Forms.ToolStripLabel toolStripLabel3;
        private System.Windows.Forms.ToolStripComboBox cbo_Thang;
        private DevComponents.DotNetBar.Controls.CheckBoxX chk_TheoNam;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripButton btn_Excel;
        private System.Windows.Forms.DataGridViewTextBoxColumn id;
        private System.Windows.Forms.DataGridViewTextBoxColumn IDTrangThaiP;
        private System.Windows.Forms.DataGridViewTextBoxColumn ReportToReportTo;
        private System.Windows.Forms.DataGridViewImageColumn edit_column;
        private System.Windows.Forms.DataGridViewTextBoxColumn MaNhanVien;
        private System.Windows.Forms.DataGridViewTextBoxColumn TenNhanVien;
        private System.Windows.Forms.DataGridViewTextBoxColumn TenKhuVuc;
        private System.Windows.Forms.DataGridViewTextBoxColumn TenChucVu;
        private System.Windows.Forms.DataGridViewTextBoxColumn TrangThai;
        private System.Windows.Forms.DataGridViewTextBoxColumn NgayNghi;
        private System.Windows.Forms.DataGridViewTextBoxColumn NuaNgay;
        private System.Windows.Forms.DataGridViewTextBoxColumn SoNgay;
        private System.Windows.Forms.DataGridViewTextBoxColumn LoaiPhep;
        private System.Windows.Forms.DataGridViewTextBoxColumn GhiChu;
        private System.Windows.Forms.DataGridViewTextBoxColumn MaChucVu;
        private System.Windows.Forms.DataGridViewTextBoxColumn NguoiXacNhan;
        private System.Windows.Forms.DataGridViewTextBoxColumn TrangThaiPhieu;
    }
}
