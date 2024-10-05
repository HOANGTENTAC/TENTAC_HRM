namespace TENTAC_HRM.User_control
{
    partial class uc_nation
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
            this.pl_nation = new System.Windows.Forms.Panel();
            this.btn_save = new System.Windows.Forms.Button();
            this.btn_cancel = new System.Windows.Forms.Button();
            this.txt_mo_ta = new System.Windows.Forms.TextBox();
            this.txt_thu_tu = new System.Windows.Forms.TextBox();
            this.txt_dan_toc = new System.Windows.Forms.TextBox();
            this.txt_ma_dan_toc = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.dgv_nation = new System.Windows.Forms.DataGridView();
            this.id_dan_toc = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.edit_column = new System.Windows.Forms.DataGridViewImageColumn();
            this.ma_dan_toc = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ten_dan_toc = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.thu_tu = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.mo_ta = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.btn_add = new System.Windows.Forms.ToolStripButton();
            this.btn_delete = new System.Windows.Forms.ToolStripButton();
            this.pl_nation.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgv_nation)).BeginInit();
            this.toolStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // pl_nation
            // 
            this.pl_nation.Controls.Add(this.btn_save);
            this.pl_nation.Controls.Add(this.btn_cancel);
            this.pl_nation.Controls.Add(this.txt_mo_ta);
            this.pl_nation.Controls.Add(this.txt_thu_tu);
            this.pl_nation.Controls.Add(this.txt_dan_toc);
            this.pl_nation.Controls.Add(this.txt_ma_dan_toc);
            this.pl_nation.Controls.Add(this.label5);
            this.pl_nation.Controls.Add(this.label4);
            this.pl_nation.Controls.Add(this.label2);
            this.pl_nation.Controls.Add(this.label1);
            this.pl_nation.Dock = System.Windows.Forms.DockStyle.Right;
            this.pl_nation.Enabled = false;
            this.pl_nation.Location = new System.Drawing.Point(747, 25);
            this.pl_nation.Margin = new System.Windows.Forms.Padding(4);
            this.pl_nation.MaximumSize = new System.Drawing.Size(428, 0);
            this.pl_nation.MinimumSize = new System.Drawing.Size(0, 611);
            this.pl_nation.Name = "pl_nation";
            this.pl_nation.Size = new System.Drawing.Size(428, 611);
            this.pl_nation.TabIndex = 0;
            // 
            // btn_save
            // 
            this.btn_save.Image = global::TENTAC_HRM.Properties.Resources.diskette;
            this.btn_save.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btn_save.Location = new System.Drawing.Point(133, 197);
            this.btn_save.Name = "btn_save";
            this.btn_save.Size = new System.Drawing.Size(148, 32);
            this.btn_save.TabIndex = 4;
            this.btn_save.Text = "Lưu";
            this.btn_save.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btn_save.UseVisualStyleBackColor = true;
            this.btn_save.Click += new System.EventHandler(this.btn_save_Click);
            // 
            // btn_cancel
            // 
            this.btn_cancel.Image = global::TENTAC_HRM.Properties.Resources.cancel;
            this.btn_cancel.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btn_cancel.Location = new System.Drawing.Point(287, 197);
            this.btn_cancel.Name = "btn_cancel";
            this.btn_cancel.Size = new System.Drawing.Size(127, 32);
            this.btn_cancel.TabIndex = 5;
            this.btn_cancel.Text = "Hủy";
            this.btn_cancel.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btn_cancel.UseVisualStyleBackColor = true;
            this.btn_cancel.Click += new System.EventHandler(this.btn_cancel_Click);
            // 
            // txt_mo_ta
            // 
            this.txt_mo_ta.Location = new System.Drawing.Point(133, 122);
            this.txt_mo_ta.Margin = new System.Windows.Forms.Padding(4);
            this.txt_mo_ta.Multiline = true;
            this.txt_mo_ta.Name = "txt_mo_ta";
            this.txt_mo_ta.Size = new System.Drawing.Size(281, 68);
            this.txt_mo_ta.TabIndex = 3;
            // 
            // txt_thu_tu
            // 
            this.txt_thu_tu.Location = new System.Drawing.Point(133, 86);
            this.txt_thu_tu.Margin = new System.Windows.Forms.Padding(4);
            this.txt_thu_tu.Name = "txt_thu_tu";
            this.txt_thu_tu.Size = new System.Drawing.Size(281, 23);
            this.txt_thu_tu.TabIndex = 2;
            // 
            // txt_dan_toc
            // 
            this.txt_dan_toc.Location = new System.Drawing.Point(133, 50);
            this.txt_dan_toc.Margin = new System.Windows.Forms.Padding(4);
            this.txt_dan_toc.Name = "txt_dan_toc";
            this.txt_dan_toc.Size = new System.Drawing.Size(281, 23);
            this.txt_dan_toc.TabIndex = 1;
            // 
            // txt_ma_dan_toc
            // 
            this.txt_ma_dan_toc.Location = new System.Drawing.Point(133, 15);
            this.txt_ma_dan_toc.Margin = new System.Windows.Forms.Padding(4);
            this.txt_ma_dan_toc.Name = "txt_ma_dan_toc";
            this.txt_ma_dan_toc.Size = new System.Drawing.Size(281, 23);
            this.txt_ma_dan_toc.TabIndex = 0;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(27, 90);
            this.label5.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(49, 17);
            this.label5.TabIndex = 2;
            this.label5.Text = "Thứ tự";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(27, 54);
            this.label4.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(57, 17);
            this.label4.TabIndex = 3;
            this.label4.Text = "Dân tộc";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(27, 126);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(43, 17);
            this.label2.TabIndex = 4;
            this.label2.Text = "Mô tả";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(27, 18);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(78, 17);
            this.label1.TabIndex = 5;
            this.label1.Text = "Mã dân tộc";
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
            this.dgv_nation.Location = new System.Drawing.Point(0, 25);
            this.dgv_nation.Margin = new System.Windows.Forms.Padding(4);
            this.dgv_nation.Name = "dgv_nation";
            this.dgv_nation.Size = new System.Drawing.Size(747, 611);
            this.dgv_nation.TabIndex = 3;
            this.dgv_nation.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgv_nation_CellClick);
            // 
            // id_dan_toc
            // 
            this.id_dan_toc.DataPropertyName = "id_dan_toc";
            this.id_dan_toc.HeaderText = "Column1";
            this.id_dan_toc.Name = "id_dan_toc";
            this.id_dan_toc.Visible = false;
            // 
            // edit_column
            // 
            this.edit_column.HeaderText = "";
            this.edit_column.Image = global::TENTAC_HRM.Properties.Resources.pen;
            this.edit_column.Name = "edit_column";
            this.edit_column.Width = 30;
            // 
            // ma_dan_toc
            // 
            this.ma_dan_toc.DataPropertyName = "ma_dan_toc";
            this.ma_dan_toc.HeaderText = "Mã dân tộc";
            this.ma_dan_toc.Name = "ma_dan_toc";
            // 
            // ten_dan_toc
            // 
            this.ten_dan_toc.DataPropertyName = "ten_dan_toc";
            this.ten_dan_toc.HeaderText = "Tên dân tộc";
            this.ten_dan_toc.Name = "ten_dan_toc";
            this.ten_dan_toc.Width = 150;
            // 
            // thu_tu
            // 
            this.thu_tu.DataPropertyName = "thu_tu";
            this.thu_tu.HeaderText = "Thứ tự";
            this.thu_tu.Name = "thu_tu";
            // 
            // mo_ta
            // 
            this.mo_ta.DataPropertyName = "mo_ta";
            this.mo_ta.HeaderText = "Mô tả";
            this.mo_ta.Name = "mo_ta";
            this.mo_ta.Width = 150;
            // 
            // toolStrip1
            // 
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.btn_add,
            this.btn_delete});
            this.toolStrip1.Location = new System.Drawing.Point(0, 0);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(1175, 25);
            this.toolStrip1.TabIndex = 4;
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
            // uc_nation
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.dgv_nation);
            this.Controls.Add(this.pl_nation);
            this.Controls.Add(this.toolStrip1);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "uc_nation";
            this.Size = new System.Drawing.Size(1175, 636);
            this.Load += new System.EventHandler(this.uc_nation_Load);
            this.pl_nation.ResumeLayout(false);
            this.pl_nation.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgv_nation)).EndInit();
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Panel pl_nation;
        private System.Windows.Forms.DataGridView dgv_nation;
        private System.Windows.Forms.TextBox txt_mo_ta;
        private System.Windows.Forms.TextBox txt_thu_tu;
        private System.Windows.Forms.TextBox txt_dan_toc;
        private System.Windows.Forms.TextBox txt_ma_dan_toc;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btn_save;
        private System.Windows.Forms.Button btn_cancel;
        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripButton btn_add;
        private System.Windows.Forms.ToolStripButton btn_delete;
        private System.Windows.Forms.DataGridViewTextBoxColumn id_dan_toc;
        private System.Windows.Forms.DataGridViewImageColumn edit_column;
        private System.Windows.Forms.DataGridViewTextBoxColumn ma_dan_toc;
        private System.Windows.Forms.DataGridViewTextBoxColumn ten_dan_toc;
        private System.Windows.Forms.DataGridViewTextBoxColumn thu_tu;
        private System.Windows.Forms.DataGridViewTextBoxColumn mo_ta;
    }
}
