namespace TENTAC_HRM.Forms.Chart_Management
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
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.edit_column = new System.Windows.Forms.DataGridViewImageColumn();
            this.MaPhongBan = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.TenPhongBan = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.label4 = new System.Windows.Forms.Label();
            this.cbo_CongTy = new System.Windows.Forms.ComboBox();
            ((System.ComponentModel.ISupportInitialize)(this.dgv_phong_ban)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(55, 71);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(99, 17);
            this.label1.TabIndex = 0;
            this.label1.Text = "Mả phòng ban";
            // 
            // txt_ma_phong_ban
            // 
            this.txt_ma_phong_ban.Location = new System.Drawing.Point(196, 68);
            this.txt_ma_phong_ban.Name = "txt_ma_phong_ban";
            this.txt_ma_phong_ban.Size = new System.Drawing.Size(327, 23);
            this.txt_ma_phong_ban.TabIndex = 0;
            // 
            // txt_ten_phong_ban
            // 
            this.txt_ten_phong_ban.Location = new System.Drawing.Point(196, 97);
            this.txt_ten_phong_ban.Name = "txt_ten_phong_ban";
            this.txt_ten_phong_ban.Size = new System.Drawing.Size(327, 23);
            this.txt_ten_phong_ban.TabIndex = 1;
            // 
            // cbo_khu_vuc
            // 
            this.cbo_khu_vuc.FormattingEnabled = true;
            this.cbo_khu_vuc.Location = new System.Drawing.Point(196, 38);
            this.cbo_khu_vuc.Name = "cbo_khu_vuc";
            this.cbo_khu_vuc.Size = new System.Drawing.Size(327, 24);
            this.cbo_khu_vuc.TabIndex = 2;
            // 
            // btn_delete
            // 
            this.btn_delete.Image = global::TENTAC_HRM.Properties.Resources.bin;
            this.btn_delete.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btn_delete.Location = new System.Drawing.Point(418, 155);
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
            this.btn_update.Location = new System.Drawing.Point(307, 155);
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
            this.btn_add.Location = new System.Drawing.Point(196, 155);
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
            this.edit_column,
            this.MaPhongBan,
            this.TenPhongBan});
            this.dgv_phong_ban.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.dgv_phong_ban.Location = new System.Drawing.Point(0, 248);
            this.dgv_phong_ban.Name = "dgv_phong_ban";
            this.dgv_phong_ban.Size = new System.Drawing.Size(590, 252);
            this.dgv_phong_ban.TabIndex = 6;
            this.dgv_phong_ban.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgv_phong_ban_CellClick);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(55, 100);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(105, 17);
            this.label2.TabIndex = 0;
            this.label2.Text = "Tên phòng ban";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(55, 41);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(59, 17);
            this.label3.TabIndex = 0;
            this.label3.Text = "Khu vực";
            // 
            // edit_column
            // 
            this.edit_column.HeaderText = "";
            this.edit_column.Image = global::TENTAC_HRM.Properties.Resources.pen;
            this.edit_column.Name = "edit_column";
            this.edit_column.Width = 30;
            // 
            // MaPhongBan
            // 
            this.MaPhongBan.DataPropertyName = "MaPhongBan";
            this.MaPhongBan.HeaderText = "Mã phòng ban";
            this.MaPhongBan.Name = "MaPhongBan";
            this.MaPhongBan.Width = 130;
            // 
            // TenPhongBan
            // 
            this.TenPhongBan.DataPropertyName = "TenPhongBan";
            this.TenPhongBan.HeaderText = "Tên phòng ban";
            this.TenPhongBan.Name = "TenPhongBan";
            this.TenPhongBan.Width = 200;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(55, 12);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(56, 17);
            this.label4.TabIndex = 0;
            this.label4.Text = "Công ty";
            // 
            // cbo_CongTy
            // 
            this.cbo_CongTy.FormattingEnabled = true;
            this.cbo_CongTy.Location = new System.Drawing.Point(196, 9);
            this.cbo_CongTy.Name = "cbo_CongTy";
            this.cbo_CongTy.Size = new System.Drawing.Size(327, 24);
            this.cbo_CongTy.TabIndex = 2;
            // 
            // uc_phong_ban
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.dgv_phong_ban);
            this.Controls.Add(this.btn_delete);
            this.Controls.Add(this.btn_update);
            this.Controls.Add(this.btn_add);
            this.Controls.Add(this.cbo_CongTy);
            this.Controls.Add(this.cbo_khu_vuc);
            this.Controls.Add(this.txt_ten_phong_ban);
            this.Controls.Add(this.txt_ma_phong_ban);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label4);
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
        private System.Windows.Forms.DataGridViewImageColumn edit_column;
        private System.Windows.Forms.DataGridViewTextBoxColumn MaPhongBan;
        private System.Windows.Forms.DataGridViewTextBoxColumn TenPhongBan;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.ComboBox cbo_CongTy;
    }
}
