namespace TENTAC_HRM.Forms.Cham_Cong
{
    partial class uc_nghiphep
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
            this.panel3 = new System.Windows.Forms.Panel();
            this.dgv_annual_leave = new System.Windows.Forms.DataGridView();
            this.id_nghi_phep = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.edit_column = new System.Windows.Forms.DataGridViewImageColumn();
            this.ma_nhan_vien = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ho_ten = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.don_vi = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.chuc_vu = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.trang_thai = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ngay_nghi = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.den_ngay = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.loai_phep = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.noi_dung = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.panel2 = new System.Windows.Forms.Panel();
            this.panel4 = new System.Windows.Forms.Panel();
            this.miniToolStrip = new System.Windows.Forms.ToolStrip();
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.toolStripLabel1 = new System.Windows.Forms.ToolStripLabel();
            this.cbo_year = new System.Windows.Forms.ToolStripComboBox();
            this.toolStripLabel2 = new System.Windows.Forms.ToolStripLabel();
            this.cbo_trangthai = new System.Windows.Forms.ToolStripComboBox();
            this.btn_add = new System.Windows.Forms.ToolStripButton();
            this.btn_delete = new System.Windows.Forms.ToolStripButton();
            this.btn_close = new System.Windows.Forms.ToolStripButton();
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
            this.panel3.Size = new System.Drawing.Size(932, 36);
            this.panel3.TabIndex = 0;
            // 
            // dgv_annual_leave
            // 
            this.dgv_annual_leave.AllowUserToAddRows = false;
            this.dgv_annual_leave.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
            this.dgv_annual_leave.BackgroundColor = System.Drawing.SystemColors.Control;
            this.dgv_annual_leave.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgv_annual_leave.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.id_nghi_phep,
            this.edit_column,
            this.ma_nhan_vien,
            this.ho_ten,
            this.don_vi,
            this.chuc_vu,
            this.trang_thai,
            this.ngay_nghi,
            this.den_ngay,
            this.loai_phep,
            this.noi_dung});
            this.dgv_annual_leave.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgv_annual_leave.Location = new System.Drawing.Point(0, 38);
            this.dgv_annual_leave.Name = "dgv_annual_leave";
            this.dgv_annual_leave.Size = new System.Drawing.Size(1042, 503);
            this.dgv_annual_leave.TabIndex = 4;
            this.dgv_annual_leave.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgv_annual_leave_CellClick);
            // 
            // id_nghi_phep
            // 
            this.id_nghi_phep.DataPropertyName = "id_nghi_phep";
            this.id_nghi_phep.HeaderText = "Column1";
            this.id_nghi_phep.Name = "id_nghi_phep";
            this.id_nghi_phep.Visible = false;
            this.id_nghi_phep.Width = 88;
            // 
            // edit_column
            // 
            this.edit_column.HeaderText = "";
            this.edit_column.Image = global::TENTAC_HRM.Properties.Resources.pen;
            this.edit_column.Name = "edit_column";
            this.edit_column.Width = 5;
            // 
            // ma_nhan_vien
            // 
            this.ma_nhan_vien.DataPropertyName = "ma_nhan_vien";
            this.ma_nhan_vien.HeaderText = "Mã nhân viên";
            this.ma_nhan_vien.Name = "ma_nhan_vien";
            this.ma_nhan_vien.Width = 118;
            // 
            // ho_ten
            // 
            this.ho_ten.DataPropertyName = "ho_ten";
            this.ho_ten.HeaderText = "Họ tên";
            this.ho_ten.Name = "ho_ten";
            this.ho_ten.Width = 75;
            // 
            // don_vi
            // 
            this.don_vi.DataPropertyName = "don_vi";
            this.don_vi.HeaderText = "Đơn vị";
            this.don_vi.Name = "don_vi";
            this.don_vi.Width = 73;
            // 
            // chuc_vu
            // 
            this.chuc_vu.DataPropertyName = "chuc_vu";
            this.chuc_vu.HeaderText = "Chức vụ";
            this.chuc_vu.Name = "chuc_vu";
            this.chuc_vu.Width = 84;
            // 
            // trang_thai
            // 
            this.trang_thai.DataPropertyName = "trang_thai";
            this.trang_thai.HeaderText = "Trạng thái";
            this.trang_thai.Name = "trang_thai";
            this.trang_thai.Width = 98;
            // 
            // ngay_nghi
            // 
            this.ngay_nghi.DataPropertyName = "ngay_nghi";
            this.ngay_nghi.HeaderText = "Nghỉ từ ngày";
            this.ngay_nghi.Name = "ngay_nghi";
            this.ngay_nghi.Width = 113;
            // 
            // den_ngay
            // 
            this.den_ngay.DataPropertyName = "den_ngay";
            this.den_ngay.HeaderText = "Nghỉ đến ngày";
            this.den_ngay.Name = "den_ngay";
            this.den_ngay.Width = 125;
            // 
            // loai_phep
            // 
            this.loai_phep.DataPropertyName = "loai_phep";
            this.loai_phep.HeaderText = "Loại phép";
            this.loai_phep.Name = "loai_phep";
            this.loai_phep.Width = 96;
            // 
            // noi_dung
            // 
            this.noi_dung.DataPropertyName = "noi_dung";
            this.noi_dung.HeaderText = "Nội dung";
            this.noi_dung.Name = "noi_dung";
            this.noi_dung.Width = 90;
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.panel3);
            this.panel2.Controls.Add(this.panel4);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel2.Location = new System.Drawing.Point(0, 541);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(1042, 36);
            this.panel2.TabIndex = 5;
            // 
            // panel4
            // 
            this.panel4.Dock = System.Windows.Forms.DockStyle.Right;
            this.panel4.Location = new System.Drawing.Point(932, 0);
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
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripLabel1,
            this.cbo_year,
            this.toolStripLabel2,
            this.cbo_trangthai,
            this.btn_add,
            this.btn_delete,
            this.btn_close});
            this.toolStrip1.Location = new System.Drawing.Point(0, 0);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(1042, 38);
            this.toolStrip1.TabIndex = 10;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // toolStripLabel1
            // 
            this.toolStripLabel1.Name = "toolStripLabel1";
            this.toolStripLabel1.Size = new System.Drawing.Size(33, 35);
            this.toolStripLabel1.Text = "Năm";
            // 
            // cbo_year
            // 
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
            this.cbo_trangthai.Name = "cbo_trangthai";
            this.cbo_trangthai.Size = new System.Drawing.Size(121, 38);
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
            // btn_close
            // 
            this.btn_close.Image = global::TENTAC_HRM.Properties.Resources.clear;
            this.btn_close.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btn_close.Name = "btn_close";
            this.btn_close.Size = new System.Drawing.Size(56, 35);
            this.btn_close.Text = "Đóng";
            this.btn_close.Click += new System.EventHandler(this.btn_close_Click);
            // 
            // uc_nghiphep
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.dgv_annual_leave);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.toolStrip1);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "uc_nghiphep";
            this.Size = new System.Drawing.Size(1042, 577);
            this.Load += new System.EventHandler(this.uc_nghiphep_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgv_annual_leave)).EndInit();
            this.panel2.ResumeLayout(false);
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.DataGridView dgv_annual_leave;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Panel panel4;
        private System.Windows.Forms.DataGridViewTextBoxColumn id_nghi_phep;
        private System.Windows.Forms.DataGridViewImageColumn edit_column;
        private System.Windows.Forms.DataGridViewTextBoxColumn ma_nhan_vien;
        private System.Windows.Forms.DataGridViewTextBoxColumn ho_ten;
        private System.Windows.Forms.DataGridViewTextBoxColumn don_vi;
        private System.Windows.Forms.DataGridViewTextBoxColumn chuc_vu;
        private System.Windows.Forms.DataGridViewTextBoxColumn trang_thai;
        private System.Windows.Forms.DataGridViewTextBoxColumn ngay_nghi;
        private System.Windows.Forms.DataGridViewTextBoxColumn den_ngay;
        private System.Windows.Forms.DataGridViewTextBoxColumn loai_phep;
        private System.Windows.Forms.DataGridViewTextBoxColumn noi_dung;
        private System.Windows.Forms.ToolStrip miniToolStrip;
        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripLabel toolStripLabel1;
        private System.Windows.Forms.ToolStripComboBox cbo_year;
        private System.Windows.Forms.ToolStripLabel toolStripLabel2;
        private System.Windows.Forms.ToolStripComboBox cbo_trangthai;
        private System.Windows.Forms.ToolStripButton btn_add;
        private System.Windows.Forms.ToolStripButton btn_delete;
        private System.Windows.Forms.ToolStripButton btn_close;
    }
}
