namespace TENTAC_HRM.User_control
{
    partial class uc_staff_religion
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
            this.components = new System.ComponentModel.Container();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            this.pl_religion = new System.Windows.Forms.Panel();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.panel2 = new System.Windows.Forms.Panel();
            this.btn_save = new System.Windows.Forms.Button();
            this.btn_cancel = new System.Windows.Forms.Button();
            this.txt_ten = new System.Windows.Forms.TextBox();
            this.txt_ma = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.txt_mota = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.txt_thu_tu = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.dgv_religion = new System.Windows.Forms.DataGridView();
            this.id_ton_giao = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.edit_column = new System.Windows.Forms.DataGridViewImageColumn();
            this.ma_ton_giao = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ten_ton_giao = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.thu_tu = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.mo_ta = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.errorProvider1 = new System.Windows.Forms.ErrorProvider(this.components);
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.btn_add = new System.Windows.Forms.ToolStripButton();
            this.btn_delete = new System.Windows.Forms.ToolStripButton();
            this.pl_religion.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgv_religion)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).BeginInit();
            this.toolStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // pl_religion
            // 
            this.pl_religion.Controls.Add(this.groupBox1);
            this.pl_religion.Dock = System.Windows.Forms.DockStyle.Right;
            this.pl_religion.Location = new System.Drawing.Point(584, 25);
            this.pl_religion.Margin = new System.Windows.Forms.Padding(4);
            this.pl_religion.MaximumSize = new System.Drawing.Size(419, 0);
            this.pl_religion.MinimumSize = new System.Drawing.Size(0, 532);
            this.pl_religion.Name = "pl_religion";
            this.pl_religion.Size = new System.Drawing.Size(419, 532);
            this.pl_religion.TabIndex = 1;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.panel2);
            this.groupBox1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox1.Location = new System.Drawing.Point(0, 0);
            this.groupBox1.Margin = new System.Windows.Forms.Padding(4);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Padding = new System.Windows.Forms.Padding(4);
            this.groupBox1.Size = new System.Drawing.Size(419, 532);
            this.groupBox1.TabIndex = 10;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Thông tin";
            // 
            // panel2
            // 
            this.panel2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel2.Controls.Add(this.btn_save);
            this.panel2.Controls.Add(this.btn_cancel);
            this.panel2.Controls.Add(this.txt_ten);
            this.panel2.Controls.Add(this.txt_ma);
            this.panel2.Controls.Add(this.label4);
            this.panel2.Controls.Add(this.txt_mota);
            this.panel2.Controls.Add(this.label5);
            this.panel2.Controls.Add(this.label1);
            this.panel2.Controls.Add(this.txt_thu_tu);
            this.panel2.Controls.Add(this.label2);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel2.Enabled = false;
            this.panel2.Location = new System.Drawing.Point(4, 20);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(411, 508);
            this.panel2.TabIndex = 10;
            // 
            // btn_save
            // 
            this.btn_save.Image = global::TENTAC_HRM.Properties.Resources.diskette;
            this.btn_save.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btn_save.Location = new System.Drawing.Point(132, 227);
            this.btn_save.Name = "btn_save";
            this.btn_save.Size = new System.Drawing.Size(144, 29);
            this.btn_save.TabIndex = 10;
            this.btn_save.Text = "Save";
            this.btn_save.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btn_save.UseVisualStyleBackColor = true;
            this.btn_save.Click += new System.EventHandler(this.btn_save_Click);
            // 
            // btn_cancel
            // 
            this.btn_cancel.Image = global::TENTAC_HRM.Properties.Resources.cancel;
            this.btn_cancel.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btn_cancel.Location = new System.Drawing.Point(282, 227);
            this.btn_cancel.Name = "btn_cancel";
            this.btn_cancel.Size = new System.Drawing.Size(114, 29);
            this.btn_cancel.TabIndex = 10;
            this.btn_cancel.Text = "Hủy";
            this.btn_cancel.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btn_cancel.UseVisualStyleBackColor = true;
            this.btn_cancel.Click += new System.EventHandler(this.btn_cancel_Click);
            // 
            // txt_ten
            // 
            this.txt_ten.Location = new System.Drawing.Point(132, 45);
            this.txt_ten.Margin = new System.Windows.Forms.Padding(4);
            this.txt_ten.Name = "txt_ten";
            this.txt_ten.Size = new System.Drawing.Size(264, 23);
            this.txt_ten.TabIndex = 9;
            this.txt_ten.Validating += new System.ComponentModel.CancelEventHandler(this.txt_ten_Validating);
            // 
            // txt_ma
            // 
            this.txt_ma.Location = new System.Drawing.Point(132, 9);
            this.txt_ma.Margin = new System.Windows.Forms.Padding(4);
            this.txt_ma.Name = "txt_ma";
            this.txt_ma.Size = new System.Drawing.Size(264, 23);
            this.txt_ma.TabIndex = 7;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(14, 13);
            this.label4.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(82, 17);
            this.label4.TabIndex = 2;
            this.label4.Text = "Mã tôn giáo";
            // 
            // txt_mota
            // 
            this.txt_mota.Location = new System.Drawing.Point(132, 116);
            this.txt_mota.Margin = new System.Windows.Forms.Padding(4);
            this.txt_mota.Multiline = true;
            this.txt_mota.Name = "txt_mota";
            this.txt_mota.Size = new System.Drawing.Size(264, 104);
            this.txt_mota.TabIndex = 6;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(14, 84);
            this.label5.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(49, 17);
            this.label5.TabIndex = 3;
            this.label5.Text = "Thứ tự";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(14, 49);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(64, 17);
            this.label1.TabIndex = 5;
            this.label1.Text = "Tôn giáo";
            // 
            // txt_thu_tu
            // 
            this.txt_thu_tu.Location = new System.Drawing.Point(132, 81);
            this.txt_thu_tu.Margin = new System.Windows.Forms.Padding(4);
            this.txt_thu_tu.Name = "txt_thu_tu";
            this.txt_thu_tu.Size = new System.Drawing.Size(264, 23);
            this.txt_thu_tu.TabIndex = 8;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(14, 116);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(43, 17);
            this.label2.TabIndex = 4;
            this.label2.Text = "Mô tả";
            // 
            // dgv_religion
            // 
            this.dgv_religion.AllowUserToAddRows = false;
            this.dgv_religion.BackgroundColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgv_religion.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dgv_religion.ColumnHeadersHeight = 25;
            this.dgv_religion.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.id_ton_giao,
            this.edit_column,
            this.ma_ton_giao,
            this.ten_ton_giao,
            this.thu_tu,
            this.mo_ta});
            this.dgv_religion.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgv_religion.Location = new System.Drawing.Point(0, 25);
            this.dgv_religion.Margin = new System.Windows.Forms.Padding(4);
            this.dgv_religion.Name = "dgv_religion";
            this.dgv_religion.Size = new System.Drawing.Size(584, 532);
            this.dgv_religion.TabIndex = 3;
            this.dgv_religion.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgv_religion_CellClick);
            // 
            // id_ton_giao
            // 
            this.id_ton_giao.DataPropertyName = "id_ton_giao";
            this.id_ton_giao.HeaderText = "id_ton_giao";
            this.id_ton_giao.Name = "id_ton_giao";
            this.id_ton_giao.Visible = false;
            // 
            // edit_column
            // 
            this.edit_column.FillWeight = 76.14211F;
            this.edit_column.HeaderText = "";
            this.edit_column.Image = global::TENTAC_HRM.Properties.Resources.pen;
            this.edit_column.Name = "edit_column";
            this.edit_column.Width = 30;
            // 
            // ma_ton_giao
            // 
            this.ma_ton_giao.DataPropertyName = "ma_ton_giao";
            this.ma_ton_giao.FillWeight = 105.9644F;
            this.ma_ton_giao.HeaderText = "Mã tôn giáo";
            this.ma_ton_giao.Name = "ma_ton_giao";
            this.ma_ton_giao.Width = 108;
            // 
            // ten_ton_giao
            // 
            this.ten_ton_giao.DataPropertyName = "ten_ton_giao";
            this.ten_ton_giao.FillWeight = 105.9644F;
            this.ten_ton_giao.HeaderText = "Tên tôn giáo";
            this.ten_ton_giao.Name = "ten_ton_giao";
            this.ten_ton_giao.Width = 107;
            // 
            // thu_tu
            // 
            this.thu_tu.DataPropertyName = "thu_tu";
            this.thu_tu.FillWeight = 105.9644F;
            this.thu_tu.HeaderText = "Thứ tự";
            this.thu_tu.Name = "thu_tu";
            this.thu_tu.Width = 108;
            // 
            // mo_ta
            // 
            this.mo_ta.DataPropertyName = "mo_ta";
            this.mo_ta.FillWeight = 105.9644F;
            this.mo_ta.HeaderText = "Mô tả";
            this.mo_ta.Name = "mo_ta";
            this.mo_ta.Width = 107;
            // 
            // errorProvider1
            // 
            this.errorProvider1.ContainerControl = this;
            // 
            // toolStrip1
            // 
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.btn_add,
            this.btn_delete});
            this.toolStrip1.Location = new System.Drawing.Point(0, 0);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(1003, 25);
            this.toolStrip1.TabIndex = 5;
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
            // 
            // uc_staff_religion
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.dgv_religion);
            this.Controls.Add(this.pl_religion);
            this.Controls.Add(this.toolStrip1);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "uc_staff_religion";
            this.Size = new System.Drawing.Size(1003, 557);
            this.Load += new System.EventHandler(this.uc_staff_religion_Load);
            this.pl_religion.ResumeLayout(false);
            this.groupBox1.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgv_religion)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).EndInit();
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Panel pl_religion;
        private System.Windows.Forms.DataGridView dgv_religion;
        private System.Windows.Forms.TextBox txt_mota;
        private System.Windows.Forms.TextBox txt_ma;
        private System.Windows.Forms.TextBox txt_thu_tu;
        private System.Windows.Forms.TextBox txt_ten;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Button btn_cancel;
        public System.Windows.Forms.Button btn_save;
        private System.Windows.Forms.ErrorProvider errorProvider1;
        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripButton btn_add;
        private System.Windows.Forms.ToolStripButton btn_delete;
        private System.Windows.Forms.DataGridViewTextBoxColumn id_ton_giao;
        private System.Windows.Forms.DataGridViewImageColumn edit_column;
        private System.Windows.Forms.DataGridViewTextBoxColumn ma_ton_giao;
        private System.Windows.Forms.DataGridViewTextBoxColumn ten_ton_giao;
        private System.Windows.Forms.DataGridViewTextBoxColumn thu_tu;
        private System.Windows.Forms.DataGridViewTextBoxColumn mo_ta;
    }
}
