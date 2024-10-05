namespace TENTAC_HRM.Chart_Management
{
    partial class uc_khu_vuc
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
            this.txt_ma_khu_vuc = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.txt_ten_khu_vuc = new System.Windows.Forms.TextBox();
            this.btn_add = new System.Windows.Forms.Button();
            this.btn_update = new System.Windows.Forms.Button();
            this.btn_delete = new System.Windows.Forms.Button();
            this.dgv_khu_vuc = new System.Windows.Forms.DataGridView();
            this.edit_column = new System.Windows.Forms.DataGridViewImageColumn();
            this.ma_phong_ban = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ten_phong_ban = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.dgv_khu_vuc)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(51, 6);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(80, 17);
            this.label1.TabIndex = 0;
            this.label1.Text = "Mã khu vực";
            // 
            // txt_ma_khu_vuc
            // 
            this.txt_ma_khu_vuc.Location = new System.Drawing.Point(185, 3);
            this.txt_ma_khu_vuc.Name = "txt_ma_khu_vuc";
            this.txt_ma_khu_vuc.Size = new System.Drawing.Size(348, 23);
            this.txt_ma_khu_vuc.TabIndex = 0;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(51, 35);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(86, 17);
            this.label2.TabIndex = 0;
            this.label2.Text = "Tên khu vực";
            // 
            // txt_ten_khu_vuc
            // 
            this.txt_ten_khu_vuc.Location = new System.Drawing.Point(185, 32);
            this.txt_ten_khu_vuc.Name = "txt_ten_khu_vuc";
            this.txt_ten_khu_vuc.Size = new System.Drawing.Size(348, 23);
            this.txt_ten_khu_vuc.TabIndex = 1;
            // 
            // btn_add
            // 
            this.btn_add.Image = global::TENTAC_HRM.Properties.Resources.add_file;
            this.btn_add.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btn_add.Location = new System.Drawing.Point(185, 61);
            this.btn_add.Name = "btn_add";
            this.btn_add.Size = new System.Drawing.Size(112, 29);
            this.btn_add.TabIndex = 2;
            this.btn_add.Text = "Thêm";
            this.btn_add.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btn_add.UseVisualStyleBackColor = true;
            this.btn_add.Click += new System.EventHandler(this.btn_add_Click);
            // 
            // btn_update
            // 
            this.btn_update.Image = global::TENTAC_HRM.Properties.Resources.update;
            this.btn_update.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btn_update.Location = new System.Drawing.Point(303, 61);
            this.btn_update.Name = "btn_update";
            this.btn_update.Size = new System.Drawing.Size(112, 29);
            this.btn_update.TabIndex = 3;
            this.btn_update.Text = "Cập nhật";
            this.btn_update.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btn_update.UseVisualStyleBackColor = true;
            this.btn_update.Click += new System.EventHandler(this.btn_update_Click);
            // 
            // btn_delete
            // 
            this.btn_delete.Image = global::TENTAC_HRM.Properties.Resources.bin;
            this.btn_delete.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btn_delete.Location = new System.Drawing.Point(421, 61);
            this.btn_delete.Name = "btn_delete";
            this.btn_delete.Size = new System.Drawing.Size(112, 29);
            this.btn_delete.TabIndex = 4;
            this.btn_delete.Text = "Xóa";
            this.btn_delete.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btn_delete.UseVisualStyleBackColor = true;
            this.btn_delete.Click += new System.EventHandler(this.btn_delete_Click);
            // 
            // dgv_khu_vuc
            // 
            this.dgv_khu_vuc.AllowUserToAddRows = false;
            this.dgv_khu_vuc.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgv_khu_vuc.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.edit_column,
            this.ma_phong_ban,
            this.ten_phong_ban});
            this.dgv_khu_vuc.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.dgv_khu_vuc.Location = new System.Drawing.Point(0, 96);
            this.dgv_khu_vuc.Name = "dgv_khu_vuc";
            this.dgv_khu_vuc.Size = new System.Drawing.Size(590, 404);
            this.dgv_khu_vuc.TabIndex = 3;
            this.dgv_khu_vuc.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgv_khu_vuc_CellClick);
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
            this.ma_phong_ban.HeaderText = "Mã khu vực";
            this.ma_phong_ban.Name = "ma_phong_ban";
            this.ma_phong_ban.Width = 120;
            // 
            // ten_phong_ban
            // 
            this.ten_phong_ban.DataPropertyName = "ten_phong_ban";
            this.ten_phong_ban.HeaderText = "Tên khu vực";
            this.ten_phong_ban.Name = "ten_phong_ban";
            this.ten_phong_ban.Width = 150;
            // 
            // uc_khu_vuc
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.dgv_khu_vuc);
            this.Controls.Add(this.btn_delete);
            this.Controls.Add(this.btn_update);
            this.Controls.Add(this.btn_add);
            this.Controls.Add(this.txt_ten_khu_vuc);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.txt_ma_khu_vuc);
            this.Controls.Add(this.label1);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "uc_khu_vuc";
            this.Size = new System.Drawing.Size(590, 500);
            this.Load += new System.EventHandler(this.uc_khu_vuc_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgv_khu_vuc)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txt_ma_khu_vuc;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txt_ten_khu_vuc;
        private System.Windows.Forms.Button btn_add;
        private System.Windows.Forms.Button btn_update;
        private System.Windows.Forms.Button btn_delete;
        private System.Windows.Forms.DataGridView dgv_khu_vuc;
        private System.Windows.Forms.DataGridViewImageColumn edit_column;
        private System.Windows.Forms.DataGridViewTextBoxColumn ma_phong_ban;
        private System.Windows.Forms.DataGridViewTextBoxColumn ten_phong_ban;
    }
}
