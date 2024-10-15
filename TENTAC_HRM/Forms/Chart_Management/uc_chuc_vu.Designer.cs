namespace TENTAC_HRM.Forms.Chart_Management
{
    partial class uc_chuc_vu
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
            this.dgv_chucvu = new System.Windows.Forms.DataGridView();
            this.khu_vuc = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.phong_ban = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.edit_column = new System.Windows.Forms.DataGridViewImageColumn();
            this.ma_phong_ban = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ten_phong_ban = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cbo_khu_vuc = new System.Windows.Forms.ComboBox();
            this.txt_ten_chuc_vu = new System.Windows.Forms.TextBox();
            this.txt_ma_chuc_vu = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.cbo_phong_ban = new System.Windows.Forms.ComboBox();
            this.btn_delete = new System.Windows.Forms.Button();
            this.btn_update = new System.Windows.Forms.Button();
            this.btn_add = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dgv_chucvu)).BeginInit();
            this.SuspendLayout();
            // 
            // dgv_chucvu
            // 
            this.dgv_chucvu.AllowUserToAddRows = false;
            this.dgv_chucvu.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgv_chucvu.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.khu_vuc,
            this.phong_ban,
            this.edit_column,
            this.ma_phong_ban,
            this.ten_phong_ban});
            this.dgv_chucvu.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.dgv_chucvu.Location = new System.Drawing.Point(0, 156);
            this.dgv_chucvu.Name = "dgv_chucvu";
            this.dgv_chucvu.Size = new System.Drawing.Size(590, 344);
            this.dgv_chucvu.TabIndex = 18;
            this.dgv_chucvu.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgv_chucvu_CellClick);
            // 
            // khu_vuc
            // 
            this.khu_vuc.DataPropertyName = "khu_vuc";
            this.khu_vuc.HeaderText = "khu_vu";
            this.khu_vuc.Name = "khu_vuc";
            this.khu_vuc.Visible = false;
            // 
            // phong_ban
            // 
            this.phong_ban.DataPropertyName = "phong_ban";
            this.phong_ban.HeaderText = "phong_ban";
            this.phong_ban.Name = "phong_ban";
            this.phong_ban.Visible = false;
            // 
            // edit_column
            // 
            this.edit_column.HeaderText = "";
            this.edit_column.Image = global::TENTAC_HRM.Properties.Resources.pen;
            this.edit_column.Name = "edit_column";
            this.edit_column.Width = 30;
            // 
            // ma_phong_ban
            // 
            this.ma_phong_ban.DataPropertyName = "ma_phong_ban";
            this.ma_phong_ban.HeaderText = "Mã chức vụ";
            this.ma_phong_ban.Name = "ma_phong_ban";
            // 
            // ten_phong_ban
            // 
            this.ten_phong_ban.DataPropertyName = "ten_phong_ban";
            this.ten_phong_ban.HeaderText = "Tên chức vụ";
            this.ten_phong_ban.Name = "ten_phong_ban";
            // 
            // cbo_khu_vuc
            // 
            this.cbo_khu_vuc.FormattingEnabled = true;
            this.cbo_khu_vuc.Location = new System.Drawing.Point(189, 61);
            this.cbo_khu_vuc.Name = "cbo_khu_vuc";
            this.cbo_khu_vuc.Size = new System.Drawing.Size(333, 24);
            this.cbo_khu_vuc.TabIndex = 2;
            this.cbo_khu_vuc.SelectedValueChanged += new System.EventHandler(this.cbo_khu_vuc_SelectedValueChanged);
            // 
            // txt_ten_chuc_vu
            // 
            this.txt_ten_chuc_vu.Location = new System.Drawing.Point(189, 32);
            this.txt_ten_chuc_vu.Name = "txt_ten_chuc_vu";
            this.txt_ten_chuc_vu.Size = new System.Drawing.Size(333, 23);
            this.txt_ten_chuc_vu.TabIndex = 1;
            // 
            // txt_ma_chuc_vu
            // 
            this.txt_ma_chuc_vu.Location = new System.Drawing.Point(189, 3);
            this.txt_ma_chuc_vu.Name = "txt_ma_chuc_vu";
            this.txt_ma_chuc_vu.Size = new System.Drawing.Size(333, 23);
            this.txt_ma_chuc_vu.TabIndex = 0;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(48, 94);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(77, 17);
            this.label4.TabIndex = 7;
            this.label4.Text = "Phòng ban";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(48, 64);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(59, 17);
            this.label3.TabIndex = 8;
            this.label3.Text = "Khu vực";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(48, 35);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(86, 17);
            this.label2.TabIndex = 9;
            this.label2.Text = "Tên chức vụ";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(48, 6);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(80, 17);
            this.label1.TabIndex = 10;
            this.label1.Text = "Mã chức vụ";
            // 
            // cbo_phong_ban
            // 
            this.cbo_phong_ban.FormattingEnabled = true;
            this.cbo_phong_ban.Location = new System.Drawing.Point(189, 91);
            this.cbo_phong_ban.Name = "cbo_phong_ban";
            this.cbo_phong_ban.Size = new System.Drawing.Size(333, 24);
            this.cbo_phong_ban.TabIndex = 3;
            this.cbo_phong_ban.SelectedValueChanged += new System.EventHandler(this.cbo_phong_ban_SelectedValueChanged);
            // 
            // btn_delete
            // 
            this.btn_delete.Image = global::TENTAC_HRM.Properties.Resources.bin;
            this.btn_delete.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btn_delete.Location = new System.Drawing.Point(415, 121);
            this.btn_delete.Name = "btn_delete";
            this.btn_delete.Size = new System.Drawing.Size(107, 29);
            this.btn_delete.TabIndex = 6;
            this.btn_delete.Text = "Xóa";
            this.btn_delete.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btn_delete.UseVisualStyleBackColor = true;
            this.btn_delete.Click += new System.EventHandler(this.btn_delete_Click);
            // 
            // btn_update
            // 
            this.btn_update.Image = global::TENTAC_HRM.Properties.Resources.update;
            this.btn_update.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btn_update.Location = new System.Drawing.Point(302, 121);
            this.btn_update.Name = "btn_update";
            this.btn_update.Size = new System.Drawing.Size(107, 29);
            this.btn_update.TabIndex = 5;
            this.btn_update.Text = "Cập nhật";
            this.btn_update.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btn_update.UseVisualStyleBackColor = true;
            this.btn_update.Click += new System.EventHandler(this.btn_update_Click);
            // 
            // btn_add
            // 
            this.btn_add.Image = global::TENTAC_HRM.Properties.Resources.add_file;
            this.btn_add.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btn_add.Location = new System.Drawing.Point(189, 121);
            this.btn_add.Name = "btn_add";
            this.btn_add.Size = new System.Drawing.Size(107, 29);
            this.btn_add.TabIndex = 4;
            this.btn_add.Text = "Thêm";
            this.btn_add.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btn_add.UseVisualStyleBackColor = true;
            this.btn_add.Click += new System.EventHandler(this.btn_add_Click);
            // 
            // uc_chuc_vu
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.dgv_chucvu);
            this.Controls.Add(this.btn_delete);
            this.Controls.Add(this.btn_update);
            this.Controls.Add(this.btn_add);
            this.Controls.Add(this.cbo_phong_ban);
            this.Controls.Add(this.cbo_khu_vuc);
            this.Controls.Add(this.txt_ten_chuc_vu);
            this.Controls.Add(this.txt_ma_chuc_vu);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "uc_chuc_vu";
            this.Size = new System.Drawing.Size(590, 500);
            this.Load += new System.EventHandler(this.uc_chuc_vu_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgv_chucvu)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dgv_chucvu;
        private System.Windows.Forms.Button btn_delete;
        private System.Windows.Forms.Button btn_update;
        private System.Windows.Forms.Button btn_add;
        private System.Windows.Forms.ComboBox cbo_khu_vuc;
        private System.Windows.Forms.TextBox txt_ten_chuc_vu;
        private System.Windows.Forms.TextBox txt_ma_chuc_vu;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox cbo_phong_ban;
        private System.Windows.Forms.DataGridViewTextBoxColumn khu_vuc;
        private System.Windows.Forms.DataGridViewTextBoxColumn phong_ban;
        private System.Windows.Forms.DataGridViewImageColumn edit_column;
        private System.Windows.Forms.DataGridViewTextBoxColumn ma_phong_ban;
        private System.Windows.Forms.DataGridViewTextBoxColumn ten_phong_ban;
    }
}
