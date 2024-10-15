namespace TENTAC_HRM.Forms.Mst_Add_Data
{
    partial class frmMstChungChi
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
            this.txtTenChungChi = new DevComponents.DotNetBar.Controls.TextBoxX();
            this.lblTenChungChi = new DevComponents.DotNetBar.LabelX();
            this.lblMaChungChi = new DevComponents.DotNetBar.LabelX();
            this.txtMaChungChi = new DevComponents.DotNetBar.Controls.TextBoxX();
            this.btn_save = new System.Windows.Forms.Button();
            this.btn_cancel = new System.Windows.Forms.Button();
            this.txtMota = new DevComponents.DotNetBar.Controls.TextBoxX();
            this.SuspendLayout();
            // 
            // lblMoTa
            // 
            this.lblMoTa.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblMoTa.Location = new System.Drawing.Point(22, 100);
            this.lblMoTa.Name = "lblMoTa";
            this.lblMoTa.Size = new System.Drawing.Size(86, 23);
            this.lblMoTa.TabIndex = 22;
            this.lblMoTa.Text = "Mô Tả:";
            // 
            // txtTenChungChi
            // 
            // 
            // 
            // 
            this.txtTenChungChi.Border.Class = "TextBoxBorder";
            this.txtTenChungChi.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtTenChungChi.Location = new System.Drawing.Point(129, 62);
            this.txtTenChungChi.Name = "txtTenChungChi";
            this.txtTenChungChi.Size = new System.Drawing.Size(318, 22);
            this.txtTenChungChi.TabIndex = 21;
            // 
            // lblTenChungChi
            // 
            this.lblTenChungChi.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTenChungChi.Location = new System.Drawing.Point(22, 61);
            this.lblTenChungChi.Name = "lblTenChungChi";
            this.lblTenChungChi.Size = new System.Drawing.Size(101, 23);
            this.lblTenChungChi.TabIndex = 20;
            this.lblTenChungChi.Text = "Tên Chứng Chỉ:";
            // 
            // lblMaChungChi
            // 
            this.lblMaChungChi.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblMaChungChi.Location = new System.Drawing.Point(22, 25);
            this.lblMaChungChi.Name = "lblMaChungChi";
            this.lblMaChungChi.Size = new System.Drawing.Size(101, 23);
            this.lblMaChungChi.TabIndex = 19;
            this.lblMaChungChi.Text = "Mã Chứng Chỉ:";
            // 
            // txtMaChungChi
            // 
            // 
            // 
            // 
            this.txtMaChungChi.Border.Class = "TextBoxBorder";
            this.txtMaChungChi.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtMaChungChi.Location = new System.Drawing.Point(128, 25);
            this.txtMaChungChi.Name = "txtMaChungChi";
            this.txtMaChungChi.ReadOnly = true;
            this.txtMaChungChi.Size = new System.Drawing.Size(319, 22);
            this.txtMaChungChi.TabIndex = 18;
            // 
            // btn_save
            // 
            this.btn_save.Image = global::TENTAC_HRM.Properties.Resources.diskette;
            this.btn_save.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btn_save.Location = new System.Drawing.Point(128, 222);
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
            this.btn_cancel.Location = new System.Drawing.Point(282, 222);
            this.btn_cancel.Name = "btn_cancel";
            this.btn_cancel.Size = new System.Drawing.Size(127, 30);
            this.btn_cancel.TabIndex = 17;
            this.btn_cancel.Text = "Hủy";
            this.btn_cancel.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btn_cancel.UseVisualStyleBackColor = true;
            this.btn_cancel.Click += new System.EventHandler(this.btn_cancel_Click);
            // 
            // txtMota
            // 
            this.txtMota.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtMota.Location = new System.Drawing.Point(128, 101);
            this.txtMota.Margin = new System.Windows.Forms.Padding(4);
            this.txtMota.Multiline = true;
            this.txtMota.Name = "txtMota";
            this.txtMota.Size = new System.Drawing.Size(319, 93);
            this.txtMota.TabIndex = 15;
            // 
            // frmMstChungChi
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(482, 276);
            this.Controls.Add(this.lblMoTa);
            this.Controls.Add(this.txtTenChungChi);
            this.Controls.Add(this.lblTenChungChi);
            this.Controls.Add(this.lblMaChungChi);
            this.Controls.Add(this.txtMaChungChi);
            this.Controls.Add(this.btn_save);
            this.Controls.Add(this.btn_cancel);
            this.Controls.Add(this.txtMota);
            this.Name = "frmMstChungChi";
            this.Text = "Chứng Chỉ";
            this.ResumeLayout(false);

        }

        #endregion

        private DevComponents.DotNetBar.LabelX lblMoTa;
        private DevComponents.DotNetBar.Controls.TextBoxX txtTenChungChi;
        private DevComponents.DotNetBar.LabelX lblTenChungChi;
        private DevComponents.DotNetBar.LabelX lblMaChungChi;
        private DevComponents.DotNetBar.Controls.TextBoxX txtMaChungChi;
        private System.Windows.Forms.Button btn_save;
        private System.Windows.Forms.Button btn_cancel;
        private DevComponents.DotNetBar.Controls.TextBoxX txtMota;
    }
}