namespace TENTAC_HRM.Chart_Management
{
    partial class uc_phong_ban
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
            this.label1 = new System.Windows.Forms.Label();
            this.txt_ma_phong_ban = new System.Windows.Forms.TextBox();
            this.txt_ten_phong_ban = new System.Windows.Forms.TextBox();
            this.cbo_khu_vuc = new System.Windows.Forms.ComboBox();
            this.btn_delete = new System.Windows.Forms.Button();
            this.btn_update = new System.Windows.Forms.Button();
            this.btn_add = new System.Windows.Forms.Button();
            this.dgv_phong_ban = new System.Windows.Forms.DataGridView();
            this.ma_phong_ban_root = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.edit_column = new System.Windows.Forms.DataGridViewImageColumn();
            this.ma_phong_ban = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ten_phong_ban = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dien_thoai = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.txt_dien_thoai = new System.Windows.Forms.TextBox();
            ((System.ComponentModel.ISupportInitialize)(this.dgv_phong_ban)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(55, 6);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(99, 17);
            this.label1.TabIndex = 0;
            this.label1.Text = "Mả phòng ban";
            // 
            // txt_ma_phong_ban
            // 
            this.txt_ma_phong_ban.Location = new System.Drawing.Point(196, 3);
            this.txt_ma_phong_ban.Name = "txt_ma_phong_ban";
            this.txt_ma_phong_ban.Size = new System.Drawing.Size(327, 23);
            this.txt_ma_phong_ban.TabIndex = 0;
            // 
            // txt_ten_phong_ban
            // 
            this.txt_ten_phong_ban.Location = new System.Drawing.Point(196, 32);
            this.txt_ten_phong_ban.Name = "txt_ten_phong_ban";
            this.txt_ten_phong_ban.Size = new System.Drawing.Size(327, 23);
            this.txt_ten_phong_ban.TabIndex = 1;
            // 
            // cbo_khu_vuc
            // 
            this.cbo_khu_vuc.FormattingEnabled = true;
            this.cbo_khu_vuc.Location = new System.Drawing.Point(196, 61);
            this.cbo_khu_vuc.Name = "cbo_khu_vuc";
            this.cbo_khu_vuc.Size = new System.Drawing.Size(327, 24);
            this.cbo_khu_vuc.TabIndex = 2;
            // 
            // btn_delete
            // 
            this.btn_delete.Image = global::TENTAC_HRM.Properties.Resources.bin;
            this.btn_delete.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btn_delete.Location = new System.Drawing.Point(418, 120);
            this.btn_delete.Name = "btn_delete";
            this.btn_delete.Size = new System.Drawing.Size(105, 29);
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
            this.btn_update.Location = new System.Drawing.Point(307, 120);
            this.btn_update.Name = "btn_update";
            this.btn_update.Size = new System.Drawing.Size(105, 29);
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
            this.btn_add.Location = new System.Drawing.Point(196, 120);
            this.btn_add.Name = "btn_add";
            this.btn_add.Size = new System.Drawing.Size(105, 29);
            this.btn_add.TabIndex = 4;
            this.btn_add.Text = "Thêm";
            this.btn_add.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btn_add.UseVisualStyleBackColor = true;
            this.btn_add.Click += new System.EventHandler(this.btn_add_Click);
            // 
            // dgv_phong_ban
            // 
            this.dgv_phong_ban.AllowUserToAddRows = false;
            this.dgv_phong_ban.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgv_phong_ban.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.ma_phong_ban_root,
            this.edit_column,
            this.ma_phong_ban,
            this.ten_phong_ban,
            this.dien_thoai});
            this.dgv_phong_ban.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.dgv_phong_ban.Location = new System.Drawing.Point(0, 155);
            this.dgv_phong_ban.Name = "dgv_phong_ban";
            this.dgv_phong_ban.Size = new System.Drawing.Size(590, 345);
            this.dgv_phong_ban.TabIndex = 6;
            this.dgv_phong_ban.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgv_phong_ban_CellClick);
            // 
            // ma_phong_ban_root
            // 
            this.ma_phong_ban_root.DataPropertyName = "ma_phong_ban_root";
            this.ma_phong_ban_root.HeaderText = "ma_phong_ban_root";
            this.ma_phong_ban_root.Name = "ma_phong_ban_root";
            this.ma_phong_ban_root.Visible = false;
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
            this.ma_phong_ban.HeaderText = "Mã phòng ban";
            this.ma_phong_ban.Name = "ma_phong_ban";
            this.ma_phong_ban.Width = 130;
            // 
            // ten_phong_ban
            // 
            this.ten_phong_ban.DataPropertyName = "ten_phong_ban";
            this.ten_phong_ban.HeaderText = "Tên phòng ban";
            this.ten_phong_ban.Name = "ten_phong_ban";
            this.ten_phong_ban.Width = 200;
            // 
            // dien_thoai
            // 
            this.dien_thoai.DataPropertyName = "dien_thoai";
            this.dien_thoai.HeaderText = "Điện thoại";
            this.dien_thoai.Name = "dien_thoai";
            this.dien_thoai.Width = 120;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(55, 35);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(105, 17);
            this.label2.TabIndex = 0;
            this.label2.Text = "Tên phòng ban";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(55, 64);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(59, 17);
            this.label3.TabIndex = 0;
            this.label3.Text = "Khu vực";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(55, 94);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(72, 17);
            this.label4.TabIndex = 0;
            this.label4.Text = "Điện thoại";
            // 
            // txt_dien_thoai
            // 
            this.txt_dien_thoai.Location = new System.Drawing.Point(196, 91);
            this.txt_dien_thoai.Name = "txt_dien_thoai";
            this.txt_dien_thoai.Size = new System.Drawing.Size(327, 23);
            this.txt_dien_thoai.TabIndex = 3;
            // 
            // uc_phong_ban
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.dgv_phong_ban);
            this.Controls.Add(this.btn_delete);
            this.Controls.Add(this.btn_update);
            this.Controls.Add(this.btn_add);
            this.Controls.Add(this.cbo_khu_vuc);
            this.Controls.Add(this.txt_dien_thoai);
            this.Controls.Add(this.txt_ten_phong_ban);
            this.Controls.Add(this.txt_ma_phong_ban);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "uc_phong_ban";
            this.Size = new System.Drawing.Size(590, 500);
            this.Load += new System.EventHandler(this.uc_phong_ban_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgv_phong_ban)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txt_ma_phong_ban;
        private System.Windows.Forms.TextBox txt_ten_phong_ban;
        private System.Windows.Forms.ComboBox cbo_khu_vuc;
        private System.Windows.Forms.Button btn_delete;
        private System.Windows.Forms.Button btn_update;
        private System.Windows.Forms.Button btn_add;
        private System.Windows.Forms.DataGridView dgv_phong_ban;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txt_dien_thoai;
        private System.Windows.Forms.DataGridViewTextBoxColumn ma_phong_ban_root;
        private System.Windows.Forms.DataGridViewImageColumn edit_column;
        private System.Windows.Forms.DataGridViewTextBoxColumn ma_phong_ban;
        private System.Windows.Forms.DataGridViewTextBoxColumn ten_phong_ban;
        private System.Windows.Forms.DataGridViewTextBoxColumn dien_thoai;
    }
}
