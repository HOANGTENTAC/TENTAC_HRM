namespace TENTAC_HRM.Forms.Mst_Add_Data
{
    partial class frmMstDanToc
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
            this.txtMaDanToc = new DevComponents.DotNetBar.Controls.TextBoxX();
            this.lblMaDanToc = new DevComponents.DotNetBar.LabelX();
            this.lblTenDanToc = new DevComponents.DotNetBar.LabelX();
            this.txtTenDanToc = new DevComponents.DotNetBar.Controls.TextBoxX();
            this.lblMoTa = new DevComponents.DotNetBar.LabelX();
            this.txtMota = new DevComponents.DotNetBar.Controls.TextBoxX();
            this.btn_save = new System.Windows.Forms.Button();
            this.btn_cancel = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // txtMaDanToc
            // 
            // 
            // 
            // 
            this.txtMaDanToc.Border.Class = "TextBoxBorder";
            this.txtMaDanToc.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtMaDanToc.Location = new System.Drawing.Point(122, 26);
            this.txtMaDanToc.Name = "txtMaDanToc";
            this.txtMaDanToc.ReadOnly = true;
            this.txtMaDanToc.Size = new System.Drawing.Size(319, 22);
            this.txtMaDanToc.TabIndex = 10;
            // 
            // lblMaDanToc
            // 
            this.lblMaDanToc.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblMaDanToc.Location = new System.Drawing.Point(30, 26);
            this.lblMaDanToc.Name = "lblMaDanToc";
            this.lblMaDanToc.Size = new System.Drawing.Size(86, 23);
            this.lblMaDanToc.TabIndex = 11;
            this.lblMaDanToc.Text = "Mã Dân Tộc:";
            // 
            // lblTenDanToc
            // 
            this.lblTenDanToc.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTenDanToc.Location = new System.Drawing.Point(30, 63);
            this.lblTenDanToc.Name = "lblTenDanToc";
            this.lblTenDanToc.Size = new System.Drawing.Size(86, 23);
            this.lblTenDanToc.TabIndex = 12;
            this.lblTenDanToc.Text = "Tên Dân Tộc:";
            // 
            // txtTenDanToc
            // 
            // 
            // 
            // 
            this.txtTenDanToc.Border.Class = "TextBoxBorder";
            this.txtTenDanToc.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtTenDanToc.Location = new System.Drawing.Point(123, 63);
            this.txtTenDanToc.Name = "txtTenDanToc";
            this.txtTenDanToc.Size = new System.Drawing.Size(318, 22);
            this.txtTenDanToc.TabIndex = 13;
            // 
            // lblMoTa
            // 
            this.lblMoTa.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblMoTa.Location = new System.Drawing.Point(30, 102);
            this.lblMoTa.Name = "lblMoTa";
            this.lblMoTa.Size = new System.Drawing.Size(86, 23);
            this.lblMoTa.TabIndex = 14;
            this.lblMoTa.Text = "Mô Tả:";
            // 
            // txtMota
            // 
            this.txtMota.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtMota.Location = new System.Drawing.Point(122, 102);
            this.txtMota.Margin = new System.Windows.Forms.Padding(4);
            this.txtMota.Multiline = true;
            this.txtMota.Name = "txtMota";
            this.txtMota.Size = new System.Drawing.Size(319, 93);
            this.txtMota.TabIndex = 6;
            // 
            // btn_save
            // 
            this.btn_save.Image = global::TENTAC_HRM.Properties.Resources.diskette;
            this.btn_save.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btn_save.Location = new System.Drawing.Point(122, 223);
            this.btn_save.Name = "btn_save";
            this.btn_save.Size = new System.Drawing.Size(148, 30);
            this.btn_save.TabIndex = 7;
            this.btn_save.Text = "Lưu";
            this.btn_save.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btn_save.UseVisualStyleBackColor = true;
            this.btn_save.Click += new System.EventHandler(this.btn_save_Click);
            // 
            // btn_cancel
            // 
            this.btn_cancel.Image = global::TENTAC_HRM.Properties.Resources.cancel;
            this.btn_cancel.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btn_cancel.Location = new System.Drawing.Point(276, 223);
            this.btn_cancel.Name = "btn_cancel";
            this.btn_cancel.Size = new System.Drawing.Size(127, 30);
            this.btn_cancel.TabIndex = 9;
            this.btn_cancel.Text = "Hủy";
            this.btn_cancel.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btn_cancel.UseVisualStyleBackColor = true;
            this.btn_cancel.Click += new System.EventHandler(this.btn_cancel_Click);
            // 
            // frmMstDanToc
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(482, 276);
            this.Controls.Add(this.lblMoTa);
            this.Controls.Add(this.txtTenDanToc);
            this.Controls.Add(this.lblTenDanToc);
            this.Controls.Add(this.lblMaDanToc);
            this.Controls.Add(this.txtMaDanToc);
            this.Controls.Add(this.btn_save);
            this.Controls.Add(this.btn_cancel);
            this.Controls.Add(this.txtMota);
            this.Name = "frmMstDanToc";
            this.Text = "Dân Tộc";
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Button btn_save;
        private System.Windows.Forms.Button btn_cancel;
        private DevComponents.DotNetBar.Controls.TextBoxX txtMaDanToc;
        private DevComponents.DotNetBar.LabelX lblMaDanToc;
        private DevComponents.DotNetBar.LabelX lblTenDanToc;
        private DevComponents.DotNetBar.Controls.TextBoxX txtTenDanToc;
        private DevComponents.DotNetBar.LabelX lblMoTa;
        private DevComponents.DotNetBar.Controls.TextBoxX txtMota;
    }
}