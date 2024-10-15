namespace TENTAC_HRM.Forms.Category
{
    partial class frm_nation
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
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.dgv_nation = new System.Windows.Forms.DataGridView();
            this.ma_dan_toc = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ten_dan_toc = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.thu_tu = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.mo_ta = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.txt_mo_ta = new System.Windows.Forms.TextBox();
            this.txt_thu_tu = new System.Windows.Forms.TextBox();
            this.txt_dan_toc = new System.Windows.Forms.TextBox();
            this.txt_ma_dan_toc = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.btn_close = new System.Windows.Forms.Button();
            this.btn_save_close = new System.Windows.Forms.Button();
            this.btn_save_add = new System.Windows.Forms.Button();
            this.tabControl1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgv_nation)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Dock = System.Windows.Forms.DockStyle.Top;
            this.tabControl1.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.tabControl1.Location = new System.Drawing.Point(0, 0);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(528, 315);
            this.tabControl1.TabIndex = 0;
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.dgv_nation);
            this.tabPage1.Controls.Add(this.txt_mo_ta);
            this.tabPage1.Controls.Add(this.txt_thu_tu);
            this.tabPage1.Controls.Add(this.txt_dan_toc);
            this.tabPage1.Controls.Add(this.txt_ma_dan_toc);
            this.tabPage1.Controls.Add(this.label5);
            this.tabPage1.Controls.Add(this.label3);
            this.tabPage1.Controls.Add(this.label4);
            this.tabPage1.Controls.Add(this.label2);
            this.tabPage1.Controls.Add(this.label1);
            this.tabPage1.Location = new System.Drawing.Point(4, 25);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Size = new System.Drawing.Size(520, 286);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "Thông tin";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // dgv_nation
            // 
            this.dgv_nation.AllowUserToAddRows = false;
            this.dgv_nation.BackgroundColor = System.Drawing.SystemColors.Window;
            this.dgv_nation.ColumnHeadersHeight = 25;
            this.dgv_nation.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.ma_dan_toc,
            this.ten_dan_toc,
            this.thu_tu,
            this.mo_ta});
            this.dgv_nation.Location = new System.Drawing.Point(99, 161);
            this.dgv_nation.Name = "dgv_nation";
            this.dgv_nation.Size = new System.Drawing.Size(401, 117);
            this.dgv_nation.TabIndex = 2;
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
            // 
            // txt_mo_ta
            // 
            this.txt_mo_ta.Location = new System.Drawing.Point(99, 99);
            this.txt_mo_ta.Multiline = true;
            this.txt_mo_ta.Name = "txt_mo_ta";
            this.txt_mo_ta.Size = new System.Drawing.Size(401, 56);
            this.txt_mo_ta.TabIndex = 1;
            // 
            // txt_thu_tu
            // 
            this.txt_thu_tu.Location = new System.Drawing.Point(99, 70);
            this.txt_thu_tu.Name = "txt_thu_tu";
            this.txt_thu_tu.Size = new System.Drawing.Size(401, 23);
            this.txt_thu_tu.TabIndex = 1;
            // 
            // txt_dan_toc
            // 
            this.txt_dan_toc.Location = new System.Drawing.Point(99, 41);
            this.txt_dan_toc.Name = "txt_dan_toc";
            this.txt_dan_toc.Size = new System.Drawing.Size(401, 23);
            this.txt_dan_toc.TabIndex = 1;
            // 
            // txt_ma_dan_toc
            // 
            this.txt_ma_dan_toc.Location = new System.Drawing.Point(99, 12);
            this.txt_ma_dan_toc.Name = "txt_ma_dan_toc";
            this.txt_ma_dan_toc.Size = new System.Drawing.Size(401, 23);
            this.txt_ma_dan_toc.TabIndex = 1;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(16, 70);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(49, 17);
            this.label5.TabIndex = 0;
            this.label5.Text = "Thứ tự";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(16, 158);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(76, 17);
            this.label3.TabIndex = 0;
            this.label3.Text = "Danh sách";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(16, 41);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(57, 17);
            this.label4.TabIndex = 0;
            this.label4.Text = "Dân tộc";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(16, 99);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(43, 17);
            this.label2.TabIndex = 0;
            this.label2.Text = "Mô tả";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(16, 12);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(78, 17);
            this.label1.TabIndex = 0;
            this.label1.Text = "Mã dăn tộc";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.btn_close);
            this.groupBox1.Controls.Add(this.btn_save_close);
            this.groupBox1.Controls.Add(this.btn_save_add);
            this.groupBox1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.groupBox1.Location = new System.Drawing.Point(0, 309);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(528, 47);
            this.groupBox1.TabIndex = 1;
            this.groupBox1.TabStop = false;
            // 
            // btn_close
            // 
            this.btn_close.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.btn_close.Image = global::TENTAC_HRM.Properties.Resources.clear;
            this.btn_close.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btn_close.Location = new System.Drawing.Point(408, 12);
            this.btn_close.Name = "btn_close";
            this.btn_close.Size = new System.Drawing.Size(96, 29);
            this.btn_close.TabIndex = 0;
            this.btn_close.Text = "Đóng";
            this.btn_close.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btn_close.UseVisualStyleBackColor = true;
            this.btn_close.Click += new System.EventHandler(this.btn_close_Click);
            // 
            // btn_save_close
            // 
            this.btn_save_close.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.btn_save_close.Image = global::TENTAC_HRM.Properties.Resources.diskette;
            this.btn_save_close.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btn_save_close.Location = new System.Drawing.Point(266, 12);
            this.btn_save_close.Name = "btn_save_close";
            this.btn_save_close.Size = new System.Drawing.Size(136, 29);
            this.btn_save_close.TabIndex = 0;
            this.btn_save_close.Text = "Lưu & thoát";
            this.btn_save_close.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btn_save_close.UseMnemonic = false;
            this.btn_save_close.UseVisualStyleBackColor = true;
            this.btn_save_close.Click += new System.EventHandler(this.btn_save_close_Click);
            // 
            // btn_save_add
            // 
            this.btn_save_add.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.btn_save_add.Image = global::TENTAC_HRM.Properties.Resources.diskette;
            this.btn_save_add.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btn_save_add.Location = new System.Drawing.Point(103, 12);
            this.btn_save_add.Name = "btn_save_add";
            this.btn_save_add.Size = new System.Drawing.Size(157, 29);
            this.btn_save_add.TabIndex = 0;
            this.btn_save_add.Text = "Lưu & thêm mới";
            this.btn_save_add.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btn_save_add.UseMnemonic = false;
            this.btn_save_add.UseVisualStyleBackColor = true;
            // 
            // frm_nation
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.ClientSize = new System.Drawing.Size(528, 356);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.tabControl1);
            this.KeyPreview = true;
            this.Name = "frm_nation";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Dân tộc";
            this.Load += new System.EventHandler(this.frm_nation_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.frm_nation_KeyDown);
            this.tabControl1.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.tabPage1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgv_nation)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button btn_close;
        private System.Windows.Forms.Button btn_save_close;
        private System.Windows.Forms.Button btn_save_add;
        private System.Windows.Forms.DataGridView dgv_nation;
        private System.Windows.Forms.TextBox txt_mo_ta;
        private System.Windows.Forms.TextBox txt_ma_dan_toc;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txt_thu_tu;
        private System.Windows.Forms.TextBox txt_dan_toc;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.DataGridViewTextBoxColumn ma_dan_toc;
        private System.Windows.Forms.DataGridViewTextBoxColumn ten_dan_toc;
        private System.Windows.Forms.DataGridViewTextBoxColumn thu_tu;
        private System.Windows.Forms.DataGridViewTextBoxColumn mo_ta;
    }
}