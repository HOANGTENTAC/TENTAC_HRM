namespace TENTAC_HRM.Forms.User_control
{
    partial class uc_leave_type
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            this.dgv_leave_type = new DevComponents.DotNetBar.Controls.DataGridViewX();
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.btn_add = new System.Windows.Forms.ToolStripButton();
            this.btn_delete = new System.Windows.Forms.ToolStripButton();
            this.dataGridViewImageColumn1 = new System.Windows.Forms.DataGridViewImageColumn();
            this.Id = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.check = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.MaLoaiPhep = new ComponentFactory.Krypton.Toolkit.KryptonDataGridViewTextBoxColumn();
            this.TenLoaiPhep = new ComponentFactory.Krypton.Toolkit.KryptonDataGridViewTextBoxColumn();
            this.KyHieu = new ComponentFactory.Krypton.Toolkit.KryptonDataGridViewTextBoxColumn();
            this.SoCong = new ComponentFactory.Krypton.Toolkit.KryptonDataGridViewTextBoxColumn();
            this.NgayCapNhat = new ComponentFactory.Krypton.Toolkit.KryptonDataGridViewTextBoxColumn();
            this.NguoiCapNhat = new ComponentFactory.Krypton.Toolkit.KryptonDataGridViewTextBoxColumn();
            this.TinhCong = new ComponentFactory.Krypton.Toolkit.KryptonDataGridViewCheckBoxColumn();
            this.edit_column = new System.Windows.Forms.DataGridViewImageColumn();
            ((System.ComponentModel.ISupportInitialize)(this.dgv_leave_type)).BeginInit();
            this.toolStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // dgv_leave_type
            // 
            this.dgv_leave_type.AllowUserToAddRows = false;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.LemonChiffon;
            this.dgv_leave_type.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            this.dgv_leave_type.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgv_leave_type.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Id,
            this.check,
            this.MaLoaiPhep,
            this.TenLoaiPhep,
            this.KyHieu,
            this.SoCong,
            this.NgayCapNhat,
            this.NguoiCapNhat,
            this.TinhCong,
            this.edit_column});
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            dataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgv_leave_type.DefaultCellStyle = dataGridViewCellStyle3;
            this.dgv_leave_type.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgv_leave_type.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(215)))), ((int)(((byte)(229)))));
            this.dgv_leave_type.Location = new System.Drawing.Point(0, 25);
            this.dgv_leave_type.Name = "dgv_leave_type";
            this.dgv_leave_type.Size = new System.Drawing.Size(1175, 605);
            this.dgv_leave_type.TabIndex = 9;
            this.dgv_leave_type.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgv_leave_type_CellClick);
            // 
            // toolStrip1
            // 
            this.toolStrip1.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.btn_add,
            this.btn_delete});
            this.toolStrip1.Location = new System.Drawing.Point(0, 0);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(1175, 25);
            this.toolStrip1.TabIndex = 8;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // btn_add
            // 
            this.btn_add.Image = global::TENTAC_HRM.Properties.Resources.add_file;
            this.btn_add.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btn_add.Name = "btn_add";
            this.btn_add.Size = new System.Drawing.Size(57, 22);
            this.btn_add.Text = "Thêm";
            this.btn_add.Click += new System.EventHandler(this.btn_add_Click);
            // 
            // btn_delete
            // 
            this.btn_delete.Image = global::TENTAC_HRM.Properties.Resources.bin;
            this.btn_delete.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btn_delete.Name = "btn_delete";
            this.btn_delete.Size = new System.Drawing.Size(47, 22);
            this.btn_delete.Text = "Xóa";
            this.btn_delete.Click += new System.EventHandler(this.btn_delete_Click);
            // 
            // dataGridViewImageColumn1
            // 
            this.dataGridViewImageColumn1.HeaderText = "";
            this.dataGridViewImageColumn1.Image = global::TENTAC_HRM.Properties.Resources.pen;
            this.dataGridViewImageColumn1.Name = "dataGridViewImageColumn1";
            this.dataGridViewImageColumn1.Width = 30;
            // 
            // Id
            // 
            this.Id.DataPropertyName = "Id";
            this.Id.HeaderText = "Id";
            this.Id.Name = "Id";
            this.Id.Visible = false;
            // 
            // check
            // 
            this.check.HeaderText = "";
            this.check.Name = "check";
            this.check.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.check.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            this.check.Width = 50;
            // 
            // MaLoaiPhep
            // 
            this.MaLoaiPhep.DataPropertyName = "MaLoaiPhep";
            this.MaLoaiPhep.HeaderText = "Mã Loại Phép";
            this.MaLoaiPhep.Name = "MaLoaiPhep";
            this.MaLoaiPhep.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.MaLoaiPhep.Width = 120;
            // 
            // TenLoaiPhep
            // 
            this.TenLoaiPhep.DataPropertyName = "TenLoaiPhep";
            this.TenLoaiPhep.HeaderText = "Tên Loại Phép";
            this.TenLoaiPhep.Name = "TenLoaiPhep";
            this.TenLoaiPhep.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.TenLoaiPhep.Width = 150;
            // 
            // KyHieu
            // 
            this.KyHieu.DataPropertyName = "KyHieu";
            this.KyHieu.HeaderText = "Ký Hiệu";
            this.KyHieu.Name = "KyHieu";
            this.KyHieu.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.KyHieu.Width = 80;
            // 
            // SoCong
            // 
            this.SoCong.DataPropertyName = "SoCong";
            this.SoCong.HeaderText = "Số Công";
            this.SoCong.Name = "SoCong";
            this.SoCong.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.SoCong.Width = 80;
            // 
            // NgayCapNhat
            // 
            this.NgayCapNhat.DataPropertyName = "NgayCapNhat";
            this.NgayCapNhat.HeaderText = "Ngày Cập Nhật";
            this.NgayCapNhat.Name = "NgayCapNhat";
            this.NgayCapNhat.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.NgayCapNhat.Width = 150;
            // 
            // NguoiCapNhat
            // 
            this.NguoiCapNhat.DataPropertyName = "NguoiCapNhat";
            this.NguoiCapNhat.HeaderText = "Người Cập Nhật";
            this.NguoiCapNhat.Name = "NguoiCapNhat";
            this.NguoiCapNhat.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.NguoiCapNhat.Width = 150;
            // 
            // TinhCong
            // 
            this.TinhCong.DataPropertyName = "TinhCong";
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle2.NullValue = false;
            this.TinhCong.DefaultCellStyle = dataGridViewCellStyle2;
            this.TinhCong.FalseValue = null;
            this.TinhCong.HeaderText = "Tính Công";
            this.TinhCong.IndeterminateValue = null;
            this.TinhCong.Name = "TinhCong";
            this.TinhCong.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.TinhCong.TrueValue = null;
            // 
            // edit_column
            // 
            this.edit_column.HeaderText = "";
            this.edit_column.Image = global::TENTAC_HRM.Properties.Resources.pen;
            this.edit_column.Name = "edit_column";
            this.edit_column.Width = 50;
            // 
            // uc_leave_type
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.dgv_leave_type);
            this.Controls.Add(this.toolStrip1);
            this.Name = "uc_leave_type";
            this.Size = new System.Drawing.Size(1175, 630);
            ((System.ComponentModel.ISupportInitialize)(this.dgv_leave_type)).EndInit();
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private DevComponents.DotNetBar.Controls.DataGridViewX dgv_leave_type;
        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripButton btn_add;
        private System.Windows.Forms.ToolStripButton btn_delete;
        private System.Windows.Forms.DataGridViewImageColumn dataGridViewImageColumn1;
        private System.Windows.Forms.DataGridViewTextBoxColumn Id;
        private System.Windows.Forms.DataGridViewCheckBoxColumn check;
        private ComponentFactory.Krypton.Toolkit.KryptonDataGridViewTextBoxColumn MaLoaiPhep;
        private ComponentFactory.Krypton.Toolkit.KryptonDataGridViewTextBoxColumn TenLoaiPhep;
        private ComponentFactory.Krypton.Toolkit.KryptonDataGridViewTextBoxColumn KyHieu;
        private ComponentFactory.Krypton.Toolkit.KryptonDataGridViewTextBoxColumn SoCong;
        private ComponentFactory.Krypton.Toolkit.KryptonDataGridViewTextBoxColumn NgayCapNhat;
        private ComponentFactory.Krypton.Toolkit.KryptonDataGridViewTextBoxColumn NguoiCapNhat;
        private ComponentFactory.Krypton.Toolkit.KryptonDataGridViewCheckBoxColumn TinhCong;
        private System.Windows.Forms.DataGridViewImageColumn edit_column;
    }
}
