﻿namespace TENTAC_HRM.Forms.User_control
{
    partial class uc_certificate
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
            this.dgv_certificate = new DevComponents.DotNetBar.Controls.DataGridViewX();
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.btn_add = new System.Windows.Forms.ToolStripButton();
            this.btn_delete = new System.Windows.Forms.ToolStripButton();
            this.btn_export = new System.Windows.Forms.ToolStripButton();
            this.btn_import = new System.Windows.Forms.ToolStripButton();
            this.dataGridViewImageColumn1 = new System.Windows.Forms.DataGridViewImageColumn();
            this.Id = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.check = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.MaChungChi = new ComponentFactory.Krypton.Toolkit.KryptonDataGridViewTextBoxColumn();
            this.TenChungChi = new ComponentFactory.Krypton.Toolkit.KryptonDataGridViewTextBoxColumn();
            this.MoTa = new ComponentFactory.Krypton.Toolkit.KryptonDataGridViewTextBoxColumn();
            this.NgayCapNhat = new ComponentFactory.Krypton.Toolkit.KryptonDataGridViewTextBoxColumn();
            this.NguoiCapNhat = new ComponentFactory.Krypton.Toolkit.KryptonDataGridViewTextBoxColumn();
            this.edit_column = new System.Windows.Forms.DataGridViewImageColumn();
            ((System.ComponentModel.ISupportInitialize)(this.dgv_certificate)).BeginInit();
            this.toolStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // dgv_certificate
            // 
            this.dgv_certificate.AllowUserToAddRows = false;
            this.dgv_certificate.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgv_certificate.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Id,
            this.check,
            this.MaChungChi,
            this.TenChungChi,
            this.MoTa,
            this.NgayCapNhat,
            this.NguoiCapNhat,
            this.edit_column});
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgv_certificate.DefaultCellStyle = dataGridViewCellStyle1;
            this.dgv_certificate.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgv_certificate.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(215)))), ((int)(((byte)(229)))));
            this.dgv_certificate.Location = new System.Drawing.Point(0, 25);
            this.dgv_certificate.Name = "dgv_certificate";
            this.dgv_certificate.Size = new System.Drawing.Size(1175, 615);
            this.dgv_certificate.TabIndex = 7;
            this.dgv_certificate.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgv_certificate_CellClick);
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
            this.toolStrip1.Size = new System.Drawing.Size(1175, 25);
            this.toolStrip1.TabIndex = 6;
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
            // btn_export
            // 
            this.btn_export.Image = global::TENTAC_HRM.Properties.Resources.export_excel;
            this.btn_export.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btn_export.Name = "btn_export";
            this.btn_export.Size = new System.Drawing.Size(61, 22);
            this.btn_export.Text = "Export";
            this.btn_export.Click += new System.EventHandler(this.btn_export_Click);
            // 
            // btn_import
            // 
            this.btn_import.Image = global::TENTAC_HRM.Properties.Resources.update;
            this.btn_import.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btn_import.Name = "btn_import";
            this.btn_import.Size = new System.Drawing.Size(63, 22);
            this.btn_import.Text = "Import";
            this.btn_import.Click += new System.EventHandler(this.btn_import_Click);
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
            // MaChungChi
            // 
            this.MaChungChi.DataPropertyName = "MaChungChi";
            this.MaChungChi.HeaderText = "Mã Chứng Chỉ";
            this.MaChungChi.Name = "MaChungChi";
            this.MaChungChi.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.MaChungChi.Width = 150;
            // 
            // TenChungChi
            // 
            this.TenChungChi.DataPropertyName = "TenChungChi";
            this.TenChungChi.HeaderText = "Tên Chứng Chỉ";
            this.TenChungChi.Name = "TenChungChi";
            this.TenChungChi.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.TenChungChi.Width = 200;
            // 
            // MoTa
            // 
            this.MoTa.DataPropertyName = "MoTa";
            this.MoTa.HeaderText = "Mô Tả";
            this.MoTa.Name = "MoTa";
            this.MoTa.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.MoTa.Width = 300;
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
            // edit_column
            // 
            this.edit_column.HeaderText = "";
            this.edit_column.Image = global::TENTAC_HRM.Properties.Resources.pen;
            this.edit_column.Name = "edit_column";
            this.edit_column.Width = 50;
            // 
            // uc_certificate
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.dgv_certificate);
            this.Controls.Add(this.toolStrip1);
            this.Name = "uc_certificate";
            this.Size = new System.Drawing.Size(1175, 640);
            ((System.ComponentModel.ISupportInitialize)(this.dgv_certificate)).EndInit();
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private DevComponents.DotNetBar.Controls.DataGridViewX dgv_certificate;
        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripButton btn_add;
        private System.Windows.Forms.ToolStripButton btn_delete;
        private System.Windows.Forms.ToolStripButton btn_export;
        private System.Windows.Forms.ToolStripButton btn_import;
        private System.Windows.Forms.DataGridViewImageColumn dataGridViewImageColumn1;
        private System.Windows.Forms.DataGridViewTextBoxColumn Id;
        private System.Windows.Forms.DataGridViewCheckBoxColumn check;
        private ComponentFactory.Krypton.Toolkit.KryptonDataGridViewTextBoxColumn MaChungChi;
        private ComponentFactory.Krypton.Toolkit.KryptonDataGridViewTextBoxColumn TenChungChi;
        private ComponentFactory.Krypton.Toolkit.KryptonDataGridViewTextBoxColumn MoTa;
        private ComponentFactory.Krypton.Toolkit.KryptonDataGridViewTextBoxColumn NgayCapNhat;
        private ComponentFactory.Krypton.Toolkit.KryptonDataGridViewTextBoxColumn NguoiCapNhat;
        private System.Windows.Forms.DataGridViewImageColumn edit_column;
    }
}
