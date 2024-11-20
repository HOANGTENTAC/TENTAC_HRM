namespace TENTAC_HRM.Forms.ChamCong
{
    partial class frm_XoaGioTangCa
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frm_XoaGioTangCa));
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.cbo_month = new System.Windows.Forms.ComboBox();
            this.cbo_year = new System.Windows.Forms.ComboBox();
            this.dgv_data = new System.Windows.Forms.DataGridView();
            this.btn_save = new DevComponents.DotNetBar.ButtonX();
            this.btn_import = new DevComponents.DotNetBar.ButtonX();
            ((System.ComponentModel.ISupportInitialize)(this.dgv_data)).BeginInit();
            this.SuspendLayout();
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.ForeColor = System.Drawing.Color.Red;
            this.label2.Location = new System.Drawing.Point(135, 16);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(38, 13);
            this.label2.TabIndex = 9;
            this.label2.Text = "Tháng";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.ForeColor = System.Drawing.Color.Red;
            this.label1.Location = new System.Drawing.Point(16, 16);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(29, 13);
            this.label1.TabIndex = 10;
            this.label1.Text = "Năm";
            // 
            // cbo_month
            // 
            this.cbo_month.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbo_month.FormattingEnabled = true;
            this.cbo_month.Location = new System.Drawing.Point(176, 12);
            this.cbo_month.Name = "cbo_month";
            this.cbo_month.Size = new System.Drawing.Size(62, 21);
            this.cbo_month.TabIndex = 7;
            // 
            // cbo_year
            // 
            this.cbo_year.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbo_year.FormattingEnabled = true;
            this.cbo_year.Location = new System.Drawing.Point(57, 12);
            this.cbo_year.Name = "cbo_year";
            this.cbo_year.Size = new System.Drawing.Size(68, 21);
            this.cbo_year.TabIndex = 8;
            // 
            // dgv_data
            // 
            this.dgv_data.AllowUserToAddRows = false;
            this.dgv_data.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgv_data.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgv_data.Location = new System.Drawing.Point(12, 41);
            this.dgv_data.Name = "dgv_data";
            this.dgv_data.Size = new System.Drawing.Size(1022, 533);
            this.dgv_data.TabIndex = 6;
            this.dgv_data.RowPostPaint += new System.Windows.Forms.DataGridViewRowPostPaintEventHandler(this.dgv_data_RowPostPaint);
            // 
            // btn_save
            // 
            this.btn_save.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.btn_save.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btn_save.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            this.btn_save.Image = ((System.Drawing.Image)(resources.GetObject("btn_save.Image")));
            this.btn_save.Location = new System.Drawing.Point(815, 12);
            this.btn_save.Name = "btn_save";
            this.btn_save.Size = new System.Drawing.Size(107, 23);
            this.btn_save.TabIndex = 4;
            this.btn_save.Text = "Xóa giờ tăng ca";
            this.btn_save.Click += new System.EventHandler(this.btn_save_Click);
            // 
            // btn_import
            // 
            this.btn_import.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.btn_import.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btn_import.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            this.btn_import.Image = ((System.Drawing.Image)(resources.GetObject("btn_import.Image")));
            this.btn_import.Location = new System.Drawing.Point(928, 12);
            this.btn_import.Name = "btn_import";
            this.btn_import.Size = new System.Drawing.Size(106, 23);
            this.btn_import.TabIndex = 5;
            this.btn_import.Text = "Thêm Excel";
            this.btn_import.Click += new System.EventHandler(this.btn_import_Click);
            // 
            // frm_XoaGioTangCa
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1046, 586);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.cbo_month);
            this.Controls.Add(this.cbo_year);
            this.Controls.Add(this.dgv_data);
            this.Controls.Add(this.btn_save);
            this.Controls.Add(this.btn_import);
            this.Name = "frm_XoaGioTangCa";
            this.Text = "Sửa giờ chấm công quá giờ";
            this.Load += new System.EventHandler(this.frm_XoaGioTangCa_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgv_data)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox cbo_month;
        private System.Windows.Forms.ComboBox cbo_year;
        private System.Windows.Forms.DataGridView dgv_data;
        private DevComponents.DotNetBar.ButtonX btn_save;
        private DevComponents.DotNetBar.ButtonX btn_import;
    }
}