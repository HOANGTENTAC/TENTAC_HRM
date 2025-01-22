namespace TENTAC_HRM.Forms.Category
{
    partial class frm_KyHieuChamCong
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
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.btn_add = new System.Windows.Forms.ToolStripButton();
            this.btn_edit = new System.Windows.Forms.ToolStripButton();
            this.btn_delete = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.btn_refresh = new System.Windows.Forms.ToolStripButton();
            this.btn_print = new System.Windows.Forms.ToolStripButton();
            this.btn_export = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.btn_close = new System.Windows.Forms.ToolStripButton();
            this.dgv_kyhieu = new System.Windows.Forms.DataGridView();
            this.dataGridViewImageColumn1 = new System.Windows.Forms.DataGridViewImageColumn();
            this.edit_column = new System.Windows.Forms.DataGridViewImageColumn();
            this.MaKyHieu = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.TenKyHieu = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.PhanTramLuong = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.toolStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgv_kyhieu)).BeginInit();
            this.SuspendLayout();
            // 
            // toolStrip1
            // 
            this.toolStrip1.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.toolStrip1.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden;
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.btn_add,
            this.btn_edit,
            this.btn_delete,
            this.toolStripSeparator1,
            this.btn_refresh,
            this.btn_print,
            this.btn_export,
            this.toolStripSeparator2,
            this.btn_close});
            this.toolStrip1.Location = new System.Drawing.Point(0, 0);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(1067, 38);
            this.toolStrip1.TabIndex = 0;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // btn_add
            // 
            this.btn_add.Image = global::TENTAC_HRM.Properties.Resources.add_file;
            this.btn_add.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btn_add.Name = "btn_add";
            this.btn_add.Size = new System.Drawing.Size(41, 35);
            this.btn_add.Text = "Thêm";
            this.btn_add.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.btn_add.Click += new System.EventHandler(this.btn_add_Click);
            // 
            // btn_edit
            // 
            this.btn_edit.Image = global::TENTAC_HRM.Properties.Resources.pen;
            this.btn_edit.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btn_edit.Name = "btn_edit";
            this.btn_edit.Size = new System.Drawing.Size(30, 35);
            this.btn_edit.Text = "Sửa";
            this.btn_edit.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.btn_edit.Click += new System.EventHandler(this.btn_edit_Click);
            // 
            // btn_delete
            // 
            this.btn_delete.Image = global::TENTAC_HRM.Properties.Resources.bin;
            this.btn_delete.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btn_delete.Name = "btn_delete";
            this.btn_delete.Size = new System.Drawing.Size(31, 35);
            this.btn_delete.Text = "Xóa";
            this.btn_delete.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.btn_delete.Click += new System.EventHandler(this.btn_delete_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(6, 38);
            // 
            // btn_refresh
            // 
            this.btn_refresh.Image = global::TENTAC_HRM.Properties.Resources.refresh;
            this.btn_refresh.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btn_refresh.Name = "btn_refresh";
            this.btn_refresh.Size = new System.Drawing.Size(51, 35);
            this.btn_refresh.Text = "Nạp Lại";
            this.btn_refresh.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.btn_refresh.Click += new System.EventHandler(this.btn_refresh_Click);
            // 
            // btn_print
            // 
            this.btn_print.Image = global::TENTAC_HRM.Properties.Resources.printer;
            this.btn_print.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btn_print.Name = "btn_print";
            this.btn_print.Size = new System.Drawing.Size(23, 35);
            this.btn_print.Text = "In";
            this.btn_print.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.btn_print.Click += new System.EventHandler(this.btn_print_Click);
            // 
            // btn_export
            // 
            this.btn_export.Image = global::TENTAC_HRM.Properties.Resources.export_excel;
            this.btn_export.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btn_export.Name = "btn_export";
            this.btn_export.Size = new System.Drawing.Size(35, 35);
            this.btn_export.Text = "Xuất";
            this.btn_export.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.btn_export.Click += new System.EventHandler(this.btn_export_Click);
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(6, 38);
            // 
            // btn_close
            // 
            this.btn_close.Image = global::TENTAC_HRM.Properties.Resources.clear;
            this.btn_close.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btn_close.Name = "btn_close";
            this.btn_close.Size = new System.Drawing.Size(40, 35);
            this.btn_close.Text = "Đóng";
            this.btn_close.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.btn_close.Click += new System.EventHandler(this.btn_close_Click);
            // 
            // dgv_kyhieu
            // 
            this.dgv_kyhieu.AllowUserToAddRows = false;
            this.dgv_kyhieu.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgv_kyhieu.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.edit_column,
            this.MaKyHieu,
            this.TenKyHieu,
            this.PhanTramLuong});
            this.dgv_kyhieu.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgv_kyhieu.Location = new System.Drawing.Point(0, 38);
            this.dgv_kyhieu.Margin = new System.Windows.Forms.Padding(4);
            this.dgv_kyhieu.Name = "dgv_kyhieu";
            this.dgv_kyhieu.Size = new System.Drawing.Size(1067, 516);
            this.dgv_kyhieu.TabIndex = 1;
            this.dgv_kyhieu.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgv_kyhieu_CellClick);
            this.dgv_kyhieu.CellMouseDoubleClick += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.dgv_kyhieu_CellMouseDoubleClick);
            // 
            // dataGridViewImageColumn1
            // 
            this.dataGridViewImageColumn1.HeaderText = "";
            this.dataGridViewImageColumn1.Image = global::TENTAC_HRM.Properties.Resources.pen;
            this.dataGridViewImageColumn1.Name = "dataGridViewImageColumn1";
            this.dataGridViewImageColumn1.Width = 40;
            // 
            // edit_column
            // 
            this.edit_column.HeaderText = "";
            this.edit_column.Image = global::TENTAC_HRM.Properties.Resources.pen;
            this.edit_column.Name = "edit_column";
            this.edit_column.Width = 40;
            // 
            // MaKyHieu
            // 
            this.MaKyHieu.DataPropertyName = "MaKyHieu";
            this.MaKyHieu.HeaderText = "Mã";
            this.MaKyHieu.Name = "MaKyHieu";
            // 
            // TenKyHieu
            // 
            this.TenKyHieu.DataPropertyName = "TenKyHieu";
            this.TenKyHieu.HeaderText = "Tên";
            this.TenKyHieu.Name = "TenKyHieu";
            // 
            // PhanTramLuong
            // 
            this.PhanTramLuong.DataPropertyName = "PhanTramLuong";
            this.PhanTramLuong.HeaderText = "Tiền trừ (% lương cơ bản)";
            this.PhanTramLuong.Name = "PhanTramLuong";
            // 
            // frm_KyHieuChamCong
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1067, 554);
            this.Controls.Add(this.dgv_kyhieu);
            this.Controls.Add(this.toolStrip1);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "frm_KyHieuChamCong";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Ký hiệu chấm công";
            this.Load += new System.EventHandler(this.frm_kyhieu_chamcong_Load);
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgv_kyhieu)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripButton btn_add;
        private System.Windows.Forms.ToolStripButton btn_edit;
        private System.Windows.Forms.ToolStripButton btn_delete;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripButton btn_refresh;
        private System.Windows.Forms.ToolStripButton btn_print;
        private System.Windows.Forms.ToolStripButton btn_export;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private System.Windows.Forms.ToolStripButton btn_close;
        private System.Windows.Forms.DataGridView dgv_kyhieu;
        private System.Windows.Forms.DataGridViewImageColumn dataGridViewImageColumn1;
        private System.Windows.Forms.DataGridViewImageColumn edit_column;
        private System.Windows.Forms.DataGridViewTextBoxColumn MaKyHieu;
        private System.Windows.Forms.DataGridViewTextBoxColumn TenKyHieu;
        private System.Windows.Forms.DataGridViewTextBoxColumn PhanTramLuong;
    }
}