namespace TENTAC_HRM.Forms.Mst_Add_Data
{
    partial class frmMstTonGiao
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
            this.txtTenTonGiao = new DevComponents.DotNetBar.Controls.TextBoxX();
            this.lblTenDanToc = new DevComponents.DotNetBar.LabelX();
            this.lblMaTonGiao = new DevComponents.DotNetBar.LabelX();
            this.txtMaTonGiao = new DevComponents.DotNetBar.Controls.TextBoxX();
            this.txtMota = new DevComponents.DotNetBar.Controls.TextBoxX();
            this.btn_save = new System.Windows.Forms.Button();
            this.btn_cancel = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // lblMoTa
            // 
            this.lblMoTa.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblMoTa.Location = new System.Drawing.Point(21, 100);
            this.lblMoTa.Name = "lblMoTa";
            this.lblMoTa.Size = new System.Drawing.Size(86, 23);
            this.lblMoTa.TabIndex = 22;
            this.lblMoTa.Text = "Mô Tả";
            // 
            // txtTenTonGiao
            // 
            // 
            // 
            // 
            this.txtTenTonGiao.Border.Class = "TextBoxBorder";
            this.txtTenTonGiao.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtTenTonGiao.Location = new System.Drawing.Point(129, 61);
            this.txtTenTonGiao.Name = "txtTenTonGiao";
            this.txtTenTonGiao.Size = new System.Drawing.Size(318, 22);
            this.txtTenTonGiao.TabIndex = 21;
            // 
            // lblTenDanToc
            // 
            this.lblTenDanToc.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTenDanToc.Location = new System.Drawing.Point(21, 61);
            this.lblTenDanToc.Name = "lblTenDanToc";
            this.lblTenDanToc.Size = new System.Drawing.Size(86, 23);
            this.lblTenDanToc.TabIndex = 20;
            this.lblTenDanToc.Text = "Tên Tôn Giáo";
            // 
            // lblMaTonGiao
            // 
            this.lblMaTonGiao.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblMaTonGiao.Location = new System.Drawing.Point(21, 24);
            this.lblMaTonGiao.Name = "lblMaTonGiao";
            this.lblMaTonGiao.Size = new System.Drawing.Size(86, 23);
            this.lblMaTonGiao.TabIndex = 19;
            this.lblMaTonGiao.Text = "Mã Tôn Giáo";
            // 
            // txtMaTonGiao
            // 
            // 
            // 
            // 
            this.txtMaTonGiao.Border.Class = "TextBoxBorder";
            this.txtMaTonGiao.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtMaTonGiao.Location = new System.Drawing.Point(128, 24);
            this.txtMaTonGiao.Name = "txtMaTonGiao";
            this.txtMaTonGiao.ReadOnly = true;
            this.txtMaTonGiao.Size = new System.Drawing.Size(319, 22);
            this.txtMaTonGiao.TabIndex = 18;
            // 
            // txtMota
            // 
            this.txtMota.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtMota.Location = new System.Drawing.Point(128, 100);
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
            this.btn_save.Location = new System.Drawing.Point(128, 221);
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
            this.btn_cancel.Location = new System.Drawing.Point(282, 221);
            this.btn_cancel.Name = "btn_cancel";
            this.btn_cancel.Size = new System.Drawing.Size(127, 30);
            this.btn_cancel.TabIndex = 17;
            this.btn_cancel.Text = "Hủy";
            this.btn_cancel.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btn_cancel.UseVisualStyleBackColor = true;
            this.btn_cancel.Click += new System.EventHandler(this.btn_cancel_Click);
            // 
            // frmMstTonGiao
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(482, 276);
            this.Controls.Add(this.lblMoTa);
            this.Controls.Add(this.txtTenTonGiao);
            this.Controls.Add(this.lblTenDanToc);
            this.Controls.Add(this.lblMaTonGiao);
            this.Controls.Add(this.txtMaTonGiao);
            this.Controls.Add(this.btn_save);
            this.Controls.Add(this.btn_cancel);
            this.Controls.Add(this.txtMota);
            this.Name = "frmMstTonGiao";
            this.Text = "Tôn Giáo";
            this.ResumeLayout(false);

        }

        #endregion

        private DevComponents.DotNetBar.LabelX lblMoTa;
        private DevComponents.DotNetBar.Controls.TextBoxX txtTenTonGiao;
        private DevComponents.DotNetBar.LabelX lblTenDanToc;
        private DevComponents.DotNetBar.LabelX lblMaTonGiao;
        private DevComponents.DotNetBar.Controls.TextBoxX txtMaTonGiao;
        private System.Windows.Forms.Button btn_save;
        private System.Windows.Forms.Button btn_cancel;
        private DevComponents.DotNetBar.Controls.TextBoxX txtMota;
    }
}