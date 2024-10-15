namespace TENTAC_HRM.Forms.Mst_Add_Data
{
    partial class frmMstChuyenNganh
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
            this.txtTenChuyenNganh = new DevComponents.DotNetBar.Controls.TextBoxX();
            this.lblTenChuyenNganh = new DevComponents.DotNetBar.LabelX();
            this.lblMaChuyenNganh = new DevComponents.DotNetBar.LabelX();
            this.txtMaChuyenNganh = new DevComponents.DotNetBar.Controls.TextBoxX();
            this.btn_save = new System.Windows.Forms.Button();
            this.btn_cancel = new System.Windows.Forms.Button();
            this.txtMota = new DevComponents.DotNetBar.Controls.TextBoxX();
            this.SuspendLayout();
            // 
            // lblMoTa
            // 
            this.lblMoTa.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblMoTa.Location = new System.Drawing.Point(12, 100);
            this.lblMoTa.Name = "lblMoTa";
            this.lblMoTa.Size = new System.Drawing.Size(86, 23);
            this.lblMoTa.TabIndex = 30;
            this.lblMoTa.Text = "Mô Tả:";
            // 
            // txtTenChuyenNganh
            // 
            // 
            // 
            // 
            this.txtTenChuyenNganh.Border.Class = "TextBoxBorder";
            this.txtTenChuyenNganh.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtTenChuyenNganh.Location = new System.Drawing.Point(143, 62);
            this.txtTenChuyenNganh.Name = "txtTenChuyenNganh";
            this.txtTenChuyenNganh.Size = new System.Drawing.Size(318, 22);
            this.txtTenChuyenNganh.TabIndex = 29;
            // 
            // lblTenChuyenNganh
            // 
            this.lblTenChuyenNganh.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTenChuyenNganh.Location = new System.Drawing.Point(12, 61);
            this.lblTenChuyenNganh.Name = "lblTenChuyenNganh";
            this.lblTenChuyenNganh.Size = new System.Drawing.Size(125, 23);
            this.lblTenChuyenNganh.TabIndex = 28;
            this.lblTenChuyenNganh.Text = "Tên Chuyên Ngành:";
            // 
            // lblMaChuyenNganh
            // 
            this.lblMaChuyenNganh.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblMaChuyenNganh.Location = new System.Drawing.Point(12, 25);
            this.lblMaChuyenNganh.Name = "lblMaChuyenNganh";
            this.lblMaChuyenNganh.Size = new System.Drawing.Size(124, 23);
            this.lblMaChuyenNganh.TabIndex = 27;
            this.lblMaChuyenNganh.Text = "Mã Chuyên Ngành:";
            // 
            // txtMaChuyenNganh
            // 
            // 
            // 
            // 
            this.txtMaChuyenNganh.Border.Class = "TextBoxBorder";
            this.txtMaChuyenNganh.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtMaChuyenNganh.Location = new System.Drawing.Point(142, 25);
            this.txtMaChuyenNganh.Name = "txtMaChuyenNganh";
            this.txtMaChuyenNganh.ReadOnly = true;
            this.txtMaChuyenNganh.Size = new System.Drawing.Size(319, 22);
            this.txtMaChuyenNganh.TabIndex = 26;
            // 
            // btn_save
            // 
            this.btn_save.Image = global::TENTAC_HRM.Properties.Resources.diskette;
            this.btn_save.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btn_save.Location = new System.Drawing.Point(142, 222);
            this.btn_save.Name = "btn_save";
            this.btn_save.Size = new System.Drawing.Size(148, 30);
            this.btn_save.TabIndex = 24;
            this.btn_save.Text = "Lưu";
            this.btn_save.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btn_save.UseVisualStyleBackColor = true;
            this.btn_save.Click += new System.EventHandler(this.btn_save_Click);
            // 
            // btn_cancel
            // 
            this.btn_cancel.Image = global::TENTAC_HRM.Properties.Resources.cancel;
            this.btn_cancel.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btn_cancel.Location = new System.Drawing.Point(296, 222);
            this.btn_cancel.Name = "btn_cancel";
            this.btn_cancel.Size = new System.Drawing.Size(127, 30);
            this.btn_cancel.TabIndex = 25;
            this.btn_cancel.Text = "Hủy";
            this.btn_cancel.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btn_cancel.UseVisualStyleBackColor = true;
            this.btn_cancel.Click += new System.EventHandler(this.btn_cancel_Click);
            // 
            // txtMota
            // 
            this.txtMota.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtMota.Location = new System.Drawing.Point(142, 101);
            this.txtMota.Margin = new System.Windows.Forms.Padding(4);
            this.txtMota.Multiline = true;
            this.txtMota.Name = "txtMota";
            this.txtMota.Size = new System.Drawing.Size(319, 93);
            this.txtMota.TabIndex = 23;
            // 
            // FrmMstChuyenNganh
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(482, 276);
            this.Controls.Add(this.lblMoTa);
            this.Controls.Add(this.txtTenChuyenNganh);
            this.Controls.Add(this.lblTenChuyenNganh);
            this.Controls.Add(this.lblMaChuyenNganh);
            this.Controls.Add(this.txtMaChuyenNganh);
            this.Controls.Add(this.btn_save);
            this.Controls.Add(this.btn_cancel);
            this.Controls.Add(this.txtMota);
            this.Name = "FrmMstChuyenNganh";
            this.Text = "Chuyên Ngành";
            this.ResumeLayout(false);

        }

        #endregion

        private DevComponents.DotNetBar.LabelX lblMoTa;
        private DevComponents.DotNetBar.Controls.TextBoxX txtTenChuyenNganh;
        private DevComponents.DotNetBar.LabelX lblTenChuyenNganh;
        private DevComponents.DotNetBar.LabelX lblMaChuyenNganh;
        private DevComponents.DotNetBar.Controls.TextBoxX txtMaChuyenNganh;
        private System.Windows.Forms.Button btn_save;
        private System.Windows.Forms.Button btn_cancel;
        private DevComponents.DotNetBar.Controls.TextBoxX txtMota;
    }
}