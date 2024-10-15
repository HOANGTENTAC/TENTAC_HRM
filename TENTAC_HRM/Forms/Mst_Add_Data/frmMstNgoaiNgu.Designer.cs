namespace TENTAC_HRM.Forms.Mst_Add_Data
{
    partial class frmMstNgoaiNgu
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
            this.lblMoTa = new DevComponents.DotNetBar.LabelX();
            this.txtTenNgoaiNgu = new DevComponents.DotNetBar.Controls.TextBoxX();
            this.lblTenNgoaiNgu = new DevComponents.DotNetBar.LabelX();
            this.lblMaNgoaiNgu = new DevComponents.DotNetBar.LabelX();
            this.txtMaNgoaiNgu = new DevComponents.DotNetBar.Controls.TextBoxX();
            this.txtMota = new DevComponents.DotNetBar.Controls.TextBoxX();
            this.btn_save = new System.Windows.Forms.Button();
            this.btn_cancel = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // lblMoTa
            // 
            this.lblMoTa.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblMoTa.Location = new System.Drawing.Point(24, 105);
            this.lblMoTa.Name = "lblMoTa";
            this.lblMoTa.Size = new System.Drawing.Size(86, 23);
            this.lblMoTa.TabIndex = 22;
            this.lblMoTa.Text = "Mô Tả:";
            // 
            // txtTenNgoaiNgu
            // 
            // 
            // 
            // 
            this.txtTenNgoaiNgu.Border.Class = "TextBoxBorder";
            this.txtTenNgoaiNgu.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtTenNgoaiNgu.Location = new System.Drawing.Point(133, 66);
            this.txtTenNgoaiNgu.Name = "txtTenNgoaiNgu";
            this.txtTenNgoaiNgu.Size = new System.Drawing.Size(318, 22);
            this.txtTenNgoaiNgu.TabIndex = 21;
            // 
            // lblTenNgoaiNgu
            // 
            this.lblTenNgoaiNgu.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTenNgoaiNgu.Location = new System.Drawing.Point(24, 66);
            this.lblTenNgoaiNgu.Name = "lblTenNgoaiNgu";
            this.lblTenNgoaiNgu.Size = new System.Drawing.Size(105, 23);
            this.lblTenNgoaiNgu.TabIndex = 20;
            this.lblTenNgoaiNgu.Text = "Tên Ngoại Ngữ :";
            // 
            // lblMaNgoaiNgu
            // 
            this.lblMaNgoaiNgu.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblMaNgoaiNgu.Location = new System.Drawing.Point(24, 29);
            this.lblMaNgoaiNgu.Name = "lblMaNgoaiNgu";
            this.lblMaNgoaiNgu.Size = new System.Drawing.Size(105, 23);
            this.lblMaNgoaiNgu.TabIndex = 19;
            this.lblMaNgoaiNgu.Text = "Mã Ngoại Ngữ:";
            // 
            // txtMaNgoaiNgu
            // 
            // 
            // 
            // 
            this.txtMaNgoaiNgu.Border.Class = "TextBoxBorder";
            this.txtMaNgoaiNgu.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtMaNgoaiNgu.Location = new System.Drawing.Point(133, 29);
            this.txtMaNgoaiNgu.Name = "txtMaNgoaiNgu";
            this.txtMaNgoaiNgu.ReadOnly = true;
            this.txtMaNgoaiNgu.Size = new System.Drawing.Size(319, 22);
            this.txtMaNgoaiNgu.TabIndex = 18;
            // 
            // txtMota
            // 
            this.txtMota.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtMota.Location = new System.Drawing.Point(133, 105);
            this.txtMota.Margin = new System.Windows.Forms.Padding(4);
            this.txtMota.Multiline = true;
            this.txtMota.Name = "txtMota";
            this.txtMota.Size = new System.Drawing.Size(319, 93);
            this.txtMota.TabIndex = 15;
            // 
            // btn_save
            // 
            this.btn_save.Image = global::TENTAC_HRM.Properties.Resources.diskette;
            this.btn_save.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btn_save.Location = new System.Drawing.Point(130, 223);
            this.btn_save.Name = "btn_save";
            this.btn_save.Size = new System.Drawing.Size(148, 30);
            this.btn_save.TabIndex = 16;
            this.btn_save.Text = "Lưu";
            this.btn_save.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btn_save.UseVisualStyleBackColor = true;
            this.btn_save.Click += new System.EventHandler(this.btn_save_Click);
            // 
            // btn_cancel
            // 
            this.btn_cancel.Image = global::TENTAC_HRM.Properties.Resources.cancel;
            this.btn_cancel.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btn_cancel.Location = new System.Drawing.Point(284, 223);
            this.btn_cancel.Name = "btn_cancel";
            this.btn_cancel.Size = new System.Drawing.Size(127, 30);
            this.btn_cancel.TabIndex = 17;
            this.btn_cancel.Text = "Hủy";
            this.btn_cancel.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btn_cancel.UseVisualStyleBackColor = true;
            this.btn_cancel.Click += new System.EventHandler(this.btn_cancel_Click);
            // 
            // frmMstNgoaiNgu
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(482, 276);
            this.Controls.Add(this.lblMoTa);
            this.Controls.Add(this.txtTenNgoaiNgu);
            this.Controls.Add(this.lblTenNgoaiNgu);
            this.Controls.Add(this.lblMaNgoaiNgu);
            this.Controls.Add(this.txtMaNgoaiNgu);
            this.Controls.Add(this.btn_save);
            this.Controls.Add(this.btn_cancel);
            this.Controls.Add(this.txtMota);
            this.Name = "frmMstNgoaiNgu";
            this.Text = "Ngoại Ngữ";
            this.ResumeLayout(false);

        }

        #endregion

        private DevComponents.DotNetBar.LabelX lblMoTa;
        private DevComponents.DotNetBar.Controls.TextBoxX txtTenNgoaiNgu;
        private DevComponents.DotNetBar.LabelX lblTenNgoaiNgu;
        private DevComponents.DotNetBar.LabelX lblMaNgoaiNgu;
        private DevComponents.DotNetBar.Controls.TextBoxX txtMaNgoaiNgu;
        private System.Windows.Forms.Button btn_save;
        private System.Windows.Forms.Button btn_cancel;
        private DevComponents.DotNetBar.Controls.TextBoxX txtMota;
    }
}