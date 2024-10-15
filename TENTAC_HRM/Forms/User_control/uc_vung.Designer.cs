namespace TENTAC_HRM.Forms.User_control
{
    partial class uc_vung
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
            this.dataGridViewImageColumn1 = new System.Windows.Forms.DataGridViewImageColumn();
            this.dataGridViewImageColumn2 = new System.Windows.Forms.DataGridViewImageColumn();
            this.btn_add = new System.Windows.Forms.ToolStripButton();
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.btn_delete = new System.Windows.Forms.ToolStripButton();
            this.mo_ta = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.thu_tu = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ten_dan_toc = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.edit_column = new System.Windows.Forms.DataGridViewImageColumn();
            this.id_dan_toc = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dgv_nation = new System.Windows.Forms.DataGridView();
            this.ma_dan_toc = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.Id = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.LuongToiThieuTheoGio = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.toolStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgv_nation)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // dataGridViewImageColumn1
            // 
            this.dataGridViewImageColumn1.HeaderText = "";
            this.dataGridViewImageColumn1.Image = global::TENTAC_HRM.Properties.Resources.pen;
            this.dataGridViewImageColumn1.Name = "dataGridViewImageColumn1";
            this.dataGridViewImageColumn1.Width = 30;
            // 
            // dataGridViewImageColumn2
            // 
            this.dataGridViewImageColumn2.HeaderText = "";
            this.dataGridViewImageColumn2.Image = global::TENTAC_HRM.Properties.Resources.pen;
            this.dataGridViewImageColumn2.Name = "dataGridViewImageColumn2";
            this.dataGridViewImageColumn2.Width = 30;
            // 
            // btn_add
            // 
            this.btn_add.Image = global::TENTAC_HRM.Properties.Resources.add_file;
            this.btn_add.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btn_add.Name = "btn_add";
            this.btn_add.Size = new System.Drawing.Size(57, 22);
            this.btn_add.Text = "Thêm";
            // 
            // toolStrip1
            // 
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.btn_add,
            this.btn_delete});
            this.toolStrip1.Location = new System.Drawing.Point(0, 0);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(1101, 25);
            this.toolStrip1.TabIndex = 7;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // btn_delete
            // 
            this.btn_delete.Image = global::TENTAC_HRM.Properties.Resources.bin;
            this.btn_delete.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btn_delete.Name = "btn_delete";
            this.btn_delete.Size = new System.Drawing.Size(47, 22);
            this.btn_delete.Text = "Xóa";
            // 
            // mo_ta
            // 
            this.mo_ta.DataPropertyName = "mo_ta";
            this.mo_ta.HeaderText = "Mô tả";
            this.mo_ta.Name = "mo_ta";
            this.mo_ta.Width = 150;
            // 
            // thu_tu
            // 
            this.thu_tu.DataPropertyName = "thu_tu";
            this.thu_tu.HeaderText = "Thứ tự";
            this.thu_tu.Name = "thu_tu";
            // 
            // ten_dan_toc
            // 
            this.ten_dan_toc.DataPropertyName = "ten_dan_toc";
            this.ten_dan_toc.HeaderText = "Tên dân tộc";
            this.ten_dan_toc.Name = "ten_dan_toc";
            this.ten_dan_toc.Width = 150;
            // 
            // edit_column
            // 
            this.edit_column.HeaderText = "";
            this.edit_column.Image = global::TENTAC_HRM.Properties.Resources.pen;
            this.edit_column.Name = "edit_column";
            this.edit_column.Width = 30;
            // 
            // id_dan_toc
            // 
            this.id_dan_toc.DataPropertyName = "id_dan_toc";
            this.id_dan_toc.HeaderText = "Column1";
            this.id_dan_toc.Name = "id_dan_toc";
            this.id_dan_toc.Visible = false;
            // 
            // dgv_nation
            // 
            this.dgv_nation.AllowUserToAddRows = false;
            this.dgv_nation.BackgroundColor = System.Drawing.SystemColors.Window;
            this.dgv_nation.ColumnHeadersHeight = 25;
            this.dgv_nation.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.id_dan_toc,
            this.edit_column,
            this.ma_dan_toc,
            this.ten_dan_toc,
            this.thu_tu,
            this.mo_ta});
            this.dgv_nation.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgv_nation.Location = new System.Drawing.Point(0, 0);
            this.dgv_nation.Margin = new System.Windows.Forms.Padding(4);
            this.dgv_nation.Name = "dgv_nation";
            this.dgv_nation.Size = new System.Drawing.Size(1101, 614);
            this.dgv_nation.TabIndex = 6;
            // 
            // ma_dan_toc
            // 
            this.ma_dan_toc.DataPropertyName = "ma_dan_toc";
            this.ma_dan_toc.HeaderText = "Mã dân tộc";
            this.ma_dan_toc.Name = "ma_dan_toc";
            // 
            // dataGridView1
            // 
            this.dataGridView1.AllowUserToAddRows = false;
            this.dataGridView1.BackgroundColor = System.Drawing.SystemColors.Window;
            this.dataGridView1.ColumnHeadersHeight = 25;
            this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Id,
            this.dataGridViewTextBoxColumn2,
            this.dataGridViewTextBoxColumn3,
            this.LuongToiThieuTheoGio});
            this.dataGridView1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataGridView1.Location = new System.Drawing.Point(0, 25);
            this.dataGridView1.Margin = new System.Windows.Forms.Padding(4);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.Size = new System.Drawing.Size(1101, 589);
            this.dataGridView1.TabIndex = 8;
            // 
            // Id
            // 
            this.Id.HeaderText = "Id";
            this.Id.Name = "Id";
            this.Id.Visible = false;
            // 
            // dataGridViewTextBoxColumn2
            // 
            this.dataGridViewTextBoxColumn2.DataPropertyName = "Vung";
            this.dataGridViewTextBoxColumn2.HeaderText = "Tên Vùng";
            this.dataGridViewTextBoxColumn2.Name = "dataGridViewTextBoxColumn2";
            // 
            // dataGridViewTextBoxColumn3
            // 
            this.dataGridViewTextBoxColumn3.DataPropertyName = "LuongToiThieuTheoThang";
            this.dataGridViewTextBoxColumn3.HeaderText = "Mức lương tối thiểu tháng (đồng/tháng)";
            this.dataGridViewTextBoxColumn3.Name = "dataGridViewTextBoxColumn3";
            this.dataGridViewTextBoxColumn3.Width = 250;
            // 
            // LuongToiThieuTheoGio
            // 
            this.LuongToiThieuTheoGio.HeaderText = "Mức lương tối thiểu giờ";
            this.LuongToiThieuTheoGio.Name = "LuongToiThieuTheoGio";
            this.LuongToiThieuTheoGio.Width = 250;
            // 
            // uc_vung
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.toolStrip1);
            this.Controls.Add(this.dgv_nation);
            this.Name = "uc_vung";
            this.Size = new System.Drawing.Size(1101, 614);
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgv_nation)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridViewImageColumn dataGridViewImageColumn1;
        private System.Windows.Forms.DataGridViewImageColumn dataGridViewImageColumn2;
        private System.Windows.Forms.ToolStripButton btn_add;
        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripButton btn_delete;
        private System.Windows.Forms.DataGridViewTextBoxColumn mo_ta;
        private System.Windows.Forms.DataGridViewTextBoxColumn thu_tu;
        private System.Windows.Forms.DataGridViewTextBoxColumn ten_dan_toc;
        private System.Windows.Forms.DataGridViewImageColumn edit_column;
        private System.Windows.Forms.DataGridViewTextBoxColumn id_dan_toc;
        private System.Windows.Forms.DataGridView dgv_nation;
        private System.Windows.Forms.DataGridViewTextBoxColumn ma_dan_toc;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.DataGridViewTextBoxColumn Id;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn2;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn3;
        private System.Windows.Forms.DataGridViewTextBoxColumn LuongToiThieuTheoGio;
    }
}
