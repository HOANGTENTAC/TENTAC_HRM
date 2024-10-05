namespace TENTAC_HRM.User_control
{
    partial class uc_nationality
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
            this.pl_thong_tin = new System.Windows.Forms.Panel();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.btn_save = new System.Windows.Forms.Button();
            this.btn_cancel = new System.Windows.Forms.Button();
            this.txt_tendiachi = new System.Windows.Forms.TextBox();
            this.txt_madiachi = new System.Windows.Forms.TextBox();
            this.cbo_loaidichi = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.dgv_nationality = new System.Windows.Forms.DataGridView();
            this.id_dia_chi = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.edit_column = new System.Windows.Forms.DataGridViewImageColumn();
            this.ma_dia_chi = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ten_dia_chi = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.btn_add = new System.Windows.Forms.ToolStripButton();
            this.btn_delete = new System.Windows.Forms.ToolStripButton();
            this.pl_info = new System.Windows.Forms.Panel();
            this.pl_thong_tin.SuspendLayout();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgv_nationality)).BeginInit();
            this.toolStrip1.SuspendLayout();
            this.pl_info.SuspendLayout();
            this.SuspendLayout();
            // 
            // pl_thong_tin
            // 
            this.pl_thong_tin.Controls.Add(this.groupBox1);
            this.pl_thong_tin.Dock = System.Windows.Forms.DockStyle.Right;
            this.pl_thong_tin.Location = new System.Drawing.Point(466, 25);
            this.pl_thong_tin.Margin = new System.Windows.Forms.Padding(4);
            this.pl_thong_tin.MaximumSize = new System.Drawing.Size(327, 0);
            this.pl_thong_tin.MinimumSize = new System.Drawing.Size(0, 560);
            this.pl_thong_tin.Name = "pl_thong_tin";
            this.pl_thong_tin.Size = new System.Drawing.Size(327, 560);
            this.pl_thong_tin.TabIndex = 1;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.pl_info);
            this.groupBox1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox1.Location = new System.Drawing.Point(0, 0);
            this.groupBox1.Margin = new System.Windows.Forms.Padding(4);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Padding = new System.Windows.Forms.Padding(4);
            this.groupBox1.Size = new System.Drawing.Size(327, 560);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Thông tin";
            // 
            // btn_save
            // 
            this.btn_save.Image = global::TENTAC_HRM.Properties.Resources.diskette;
            this.btn_save.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btn_save.Location = new System.Drawing.Point(113, 107);
            this.btn_save.Name = "btn_save";
            this.btn_save.Size = new System.Drawing.Size(97, 30);
            this.btn_save.TabIndex = 3;
            this.btn_save.Text = "Lưu";
            this.btn_save.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btn_save.UseVisualStyleBackColor = true;
            this.btn_save.Click += new System.EventHandler(this.btn_save_Click);
            // 
            // btn_cancel
            // 
            this.btn_cancel.Image = global::TENTAC_HRM.Properties.Resources.cancel;
            this.btn_cancel.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btn_cancel.Location = new System.Drawing.Point(216, 107);
            this.btn_cancel.Name = "btn_cancel";
            this.btn_cancel.Size = new System.Drawing.Size(95, 30);
            this.btn_cancel.TabIndex = 3;
            this.btn_cancel.Text = "Hủy";
            this.btn_cancel.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btn_cancel.UseVisualStyleBackColor = true;
            this.btn_cancel.Click += new System.EventHandler(this.btn_cancel_Click);
            // 
            // txt_tendiachi
            // 
            this.txt_tendiachi.Location = new System.Drawing.Point(113, 78);
            this.txt_tendiachi.Name = "txt_tendiachi";
            this.txt_tendiachi.Size = new System.Drawing.Size(198, 23);
            this.txt_tendiachi.TabIndex = 2;
            // 
            // txt_madiachi
            // 
            this.txt_madiachi.Location = new System.Drawing.Point(113, 44);
            this.txt_madiachi.Name = "txt_madiachi";
            this.txt_madiachi.Size = new System.Drawing.Size(198, 23);
            this.txt_madiachi.TabIndex = 2;
            // 
            // cbo_loaidichi
            // 
            this.cbo_loaidichi.FormattingEnabled = true;
            this.cbo_loaidichi.Location = new System.Drawing.Point(113, 9);
            this.cbo_loaidichi.Name = "cbo_loaidichi";
            this.cbo_loaidichi.Size = new System.Drawing.Size(198, 24);
            this.cbo_loaidichi.TabIndex = 1;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(10, 81);
            this.label3.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(78, 17);
            this.label3.TabIndex = 0;
            this.label3.Text = "Tên địa chỉ";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(10, 47);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(72, 17);
            this.label2.TabIndex = 0;
            this.label2.Text = "Mã địa chỉ";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(10, 12);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(80, 17);
            this.label1.TabIndex = 0;
            this.label1.Text = "Loại địa chỉ";
            // 
            // dgv_nationality
            // 
            this.dgv_nationality.AllowUserToAddRows = false;
            this.dgv_nationality.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgv_nationality.BackgroundColor = System.Drawing.SystemColors.Control;
            this.dgv_nationality.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgv_nationality.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.id_dia_chi,
            this.edit_column,
            this.ma_dia_chi,
            this.ten_dia_chi});
            this.dgv_nationality.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgv_nationality.Location = new System.Drawing.Point(0, 25);
            this.dgv_nationality.Margin = new System.Windows.Forms.Padding(4);
            this.dgv_nationality.Name = "dgv_nationality";
            this.dgv_nationality.Size = new System.Drawing.Size(466, 560);
            this.dgv_nationality.TabIndex = 2;
            this.dgv_nationality.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgv_nationality_CellClick);
            // 
            // id_dia_chi
            // 
            this.id_dia_chi.DataPropertyName = "id_dia_chi";
            this.id_dia_chi.HeaderText = "id_quoc_tich";
            this.id_dia_chi.Name = "id_dia_chi";
            this.id_dia_chi.Visible = false;
            // 
            // edit_column
            // 
            this.edit_column.FillWeight = 22.84264F;
            this.edit_column.HeaderText = "";
            this.edit_column.Image = global::TENTAC_HRM.Properties.Resources.pen;
            this.edit_column.Name = "edit_column";
            // 
            // ma_dia_chi
            // 
            this.ma_dia_chi.DataPropertyName = "ma_dia_chi";
            this.ma_dia_chi.FillWeight = 138.5787F;
            this.ma_dia_chi.HeaderText = "Mã quốc tịch";
            this.ma_dia_chi.Name = "ma_dia_chi";
            // 
            // ten_dia_chi
            // 
            this.ten_dia_chi.DataPropertyName = "ten_dia_chi";
            this.ten_dia_chi.FillWeight = 138.5787F;
            this.ten_dia_chi.HeaderText = "Tên quốc tịch";
            this.ten_dia_chi.Name = "ten_dia_chi";
            // 
            // toolStrip1
            // 
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.btn_add,
            this.btn_delete});
            this.toolStrip1.Location = new System.Drawing.Point(0, 0);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(793, 25);
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
            // pl_info
            // 
            this.pl_info.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pl_info.Controls.Add(this.btn_cancel);
            this.pl_info.Controls.Add(this.btn_save);
            this.pl_info.Controls.Add(this.label1);
            this.pl_info.Controls.Add(this.label2);
            this.pl_info.Controls.Add(this.txt_tendiachi);
            this.pl_info.Controls.Add(this.label3);
            this.pl_info.Controls.Add(this.txt_madiachi);
            this.pl_info.Controls.Add(this.cbo_loaidichi);
            this.pl_info.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pl_info.Enabled = false;
            this.pl_info.Location = new System.Drawing.Point(4, 20);
            this.pl_info.Name = "pl_info";
            this.pl_info.Size = new System.Drawing.Size(319, 536);
            this.pl_info.TabIndex = 4;
            // 
            // uc_nationality
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.dgv_nationality);
            this.Controls.Add(this.pl_thong_tin);
            this.Controls.Add(this.toolStrip1);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "uc_nationality";
            this.Size = new System.Drawing.Size(793, 585);
            this.Load += new System.EventHandler(this.uc_nationality_Load);
            this.pl_thong_tin.ResumeLayout(false);
            this.groupBox1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgv_nationality)).EndInit();
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            this.pl_info.ResumeLayout(false);
            this.pl_info.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Panel pl_thong_tin;
        private System.Windows.Forms.DataGridView dgv_nationality;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txt_tendiachi;
        private System.Windows.Forms.TextBox txt_madiachi;
        private System.Windows.Forms.ComboBox cbo_loaidichi;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button btn_cancel;
        private System.Windows.Forms.DataGridViewTextBoxColumn id_dia_chi;
        private System.Windows.Forms.DataGridViewImageColumn edit_column;
        private System.Windows.Forms.DataGridViewTextBoxColumn ma_dia_chi;
        private System.Windows.Forms.DataGridViewTextBoxColumn ten_dia_chi;
        public System.Windows.Forms.Button btn_save;
        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripButton btn_add;
        private System.Windows.Forms.ToolStripButton btn_delete;
        private System.Windows.Forms.Panel pl_info;
    }
}
