namespace TENTAC_HRM.Forms.User_control
{
    partial class uc_address
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.btn_add = new System.Windows.Forms.ToolStripButton();
            this.btn_delete = new System.Windows.Forms.ToolStripButton();
            this.btn_export = new System.Windows.Forms.ToolStripButton();
            this.btn_import = new System.Windows.Forms.ToolStripButton();
            this.dgv_address = new DevComponents.DotNetBar.Controls.DataGridViewX();
            this.QuocGia = new ComponentFactory.Krypton.Toolkit.KryptonDataGridViewTextBoxColumn();
            this.TinhThanh = new ComponentFactory.Krypton.Toolkit.KryptonDataGridViewTextBoxColumn();
            this.QuanHuyen = new ComponentFactory.Krypton.Toolkit.KryptonDataGridViewTextBoxColumn();
            this.PhuongXa = new ComponentFactory.Krypton.Toolkit.KryptonDataGridViewTextBoxColumn();
            this.toolStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgv_address)).BeginInit();
            this.SuspendLayout();
            // 
            // toolStrip1
            // 
            this.toolStrip1.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.btn_add,
            this.btn_delete,
            this.btn_export,
            this.btn_import});
            this.toolStrip1.Location = new System.Drawing.Point(0, 0);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(909, 25);
            this.toolStrip1.TabIndex = 7;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // btn_add
            // 
            this.btn_add.Image = global::TENTAC_HRM.Properties.Resources.plus;
            this.btn_add.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btn_add.Name = "btn_add";
            this.btn_add.Size = new System.Drawing.Size(57, 22);
            this.btn_add.Text = "Thêm";
            // 
            // btn_delete
            // 
            this.btn_delete.Image = global::TENTAC_HRM.Properties.Resources.bin;
            this.btn_delete.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btn_delete.Name = "btn_delete";
            this.btn_delete.Size = new System.Drawing.Size(47, 22);
            this.btn_delete.Text = "Xóa";
            // 
            // btn_export
            // 
            this.btn_export.Image = global::TENTAC_HRM.Properties.Resources.export_excel;
            this.btn_export.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btn_export.Name = "btn_export";
            this.btn_export.Size = new System.Drawing.Size(61, 22);
            this.btn_export.Text = "Export";
            // 
            // btn_import
            // 
            this.btn_import.Image = global::TENTAC_HRM.Properties.Resources.importExcel;
            this.btn_import.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btn_import.Name = "btn_import";
            this.btn_import.Size = new System.Drawing.Size(63, 22);
            this.btn_import.Text = "Import";
            // 
            // dgv_address
            // 
            this.dgv_address.AllowUserToAddRows = false;
            this.dgv_address.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgv_address.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.QuocGia,
            this.TinhThanh,
            this.QuanHuyen,
            this.PhuongXa});
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgv_address.DefaultCellStyle = dataGridViewCellStyle2;
            this.dgv_address.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgv_address.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(215)))), ((int)(((byte)(229)))));
            this.dgv_address.Location = new System.Drawing.Point(0, 25);
            this.dgv_address.Name = "dgv_address";
            this.dgv_address.Size = new System.Drawing.Size(909, 553);
            this.dgv_address.TabIndex = 8;
            // 
            // QuocGia
            // 
            this.QuocGia.DataPropertyName = "QuocGia";
            this.QuocGia.HeaderText = "Quốc Gia";
            this.QuocGia.Name = "QuocGia";
            this.QuocGia.Width = 100;
            // 
            // TinhThanh
            // 
            this.TinhThanh.DataPropertyName = "TinhThanh";
            this.TinhThanh.HeaderText = "Tỉnh Thành";
            this.TinhThanh.Name = "TinhThanh";
            this.TinhThanh.Width = 100;
            // 
            // QuanHuyen
            // 
            this.QuanHuyen.DataPropertyName = "QuanHuyen";
            this.QuanHuyen.HeaderText = "Quận Huyện";
            this.QuanHuyen.Name = "QuanHuyen";
            this.QuanHuyen.Width = 100;
            // 
            // PhuongXa
            // 
            this.PhuongXa.DataPropertyName = "PhuongXa";
            this.PhuongXa.HeaderText = "Phường Xã";
            this.PhuongXa.Name = "PhuongXa";
            this.PhuongXa.Width = 100;
            // 
            // uc_address
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.dgv_address);
            this.Controls.Add(this.toolStrip1);
            this.Name = "uc_address";
            this.Size = new System.Drawing.Size(909, 578);
            this.Load += new System.EventHandler(this.uc_address_Load);
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgv_address)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripButton btn_add;
        private System.Windows.Forms.ToolStripButton btn_delete;
        private System.Windows.Forms.ToolStripButton btn_export;
        private System.Windows.Forms.ToolStripButton btn_import;
        private DevComponents.DotNetBar.Controls.DataGridViewX dgv_address;
        private ComponentFactory.Krypton.Toolkit.KryptonDataGridViewTextBoxColumn QuocGia;
        private ComponentFactory.Krypton.Toolkit.KryptonDataGridViewTextBoxColumn TinhThanh;
        private ComponentFactory.Krypton.Toolkit.KryptonDataGridViewTextBoxColumn QuanHuyen;
        private ComponentFactory.Krypton.Toolkit.KryptonDataGridViewTextBoxColumn PhuongXa;
    }
}
