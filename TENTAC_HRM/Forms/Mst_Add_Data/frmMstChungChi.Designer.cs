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
            this.panel1 = new System.Windows.Forms.Panel();
            this.labelX1 = new DevComponents.DotNetBar.LabelX();
            this.lblMoTa = new DevComponents.DotNetBar.LabelX();
            this.txtTenChungChi = new DevComponents.DotNetBar.Controls.TextBoxX();
            this.lblTenChungChi = new DevComponents.DotNetBar.LabelX();
            this.lblMaChungChi = new DevComponents.DotNetBar.LabelX();
            this.txtMaChungChi = new DevComponents.DotNetBar.Controls.TextBoxX();
            this.btn_save = new System.Windows.Forms.Button();
            this.btn_cancel = new System.Windows.Forms.Button();
            this.txtMota = new DevComponents.DotNetBar.Controls.TextBoxX();
            this.panel2 = new System.Windows.Forms.Panel();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.panel2);
            this.panel1.Controls.Add(this.labelX1);
            this.panel1.Controls.Add(this.lblMoTa);
            this.panel1.Controls.Add(this.txtTenChungChi);
            this.panel1.Controls.Add(this.lblTenChungChi);
            this.panel1.Controls.Add(this.lblMaChungChi);
            this.panel1.Controls.Add(this.txtMaChungChi);
            this.panel1.Controls.Add(this.txtMota);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(357, 422);
            this.panel1.TabIndex = 1;
            // 
            // labelX1
            // 
            this.labelX1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(16)))), ((int)(((byte)(39)))), ((int)(((byte)(75)))));
            this.labelX1.Dock = System.Windows.Forms.DockStyle.Top;
            this.labelX1.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelX1.ForeColor = System.Drawing.Color.WhiteSmoke;
            this.labelX1.Location = new System.Drawing.Point(0, 0);
            this.labelX1.Name = "labelX1";
            this.labelX1.Size = new System.Drawing.Size(357, 62);
            this.labelX1.TabIndex = 31;
            this.labelX1.Text = "Thêm Thông Tin Chứng Chỉ";
            this.labelX1.TextAlignment = System.Drawing.StringAlignment.Center;
            // 
            // lblMoTa
            // 
            this.lblMoTa.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblMoTa.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.lblMoTa.Location = new System.Drawing.Point(31, 214);
            this.lblMoTa.Name = "lblMoTa";
            this.lblMoTa.Size = new System.Drawing.Size(86, 23);
            this.lblMoTa.TabIndex = 30;
            this.lblMoTa.Text = "Mô Tả:";
            // 
            // txtTenChungChi
            // 
            this.txtTenChungChi.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(228)))), ((int)(((byte)(247)))), ((int)(((byte)(254)))));
            // 
            // 
            // 
            this.txtTenChungChi.Border.Class = "TextBoxBorder";
            this.txtTenChungChi.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtTenChungChi.Location = new System.Drawing.Point(31, 183);
            this.txtTenChungChi.Multiline = true;
            this.txtTenChungChi.Name = "txtTenChungChi";
            this.txtTenChungChi.Size = new System.Drawing.Size(295, 25);
            this.txtTenChungChi.TabIndex = 2;
            // 
            // lblTenChungChi
            // 
            this.lblTenChungChi.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTenChungChi.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.lblTenChungChi.Location = new System.Drawing.Point(31, 148);
            this.lblTenChungChi.Name = "lblTenChungChi";
            this.lblTenChungChi.Size = new System.Drawing.Size(114, 23);
            this.lblTenChungChi.TabIndex = 28;
            this.lblTenChungChi.Text = "Tên Chứng Chỉ:";
            // 
            // lblMaChungChi
            // 
            this.lblMaChungChi.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblMaChungChi.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.lblMaChungChi.Location = new System.Drawing.Point(31, 88);
            this.lblMaChungChi.Name = "lblMaChungChi";
            this.lblMaChungChi.Size = new System.Drawing.Size(101, 23);
            this.lblMaChungChi.TabIndex = 27;
            this.lblMaChungChi.Text = "Mã Chứng Chỉ:";
            // 
            // txtMaChungChi
            // 
            this.txtMaChungChi.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(248)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            // 
            // 
            // 
            this.txtMaChungChi.Border.Class = "TextBoxBorder";
            this.txtMaChungChi.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtMaChungChi.Location = new System.Drawing.Point(31, 117);
            this.txtMaChungChi.Multiline = true;
            this.txtMaChungChi.Name = "txtMaChungChi";
            this.txtMaChungChi.ReadOnly = true;
            this.txtMaChungChi.Size = new System.Drawing.Size(295, 25);
            this.txtMaChungChi.TabIndex = 1;
            // 
            // btn_save
            // 
            this.btn_save.Image = global::TENTAC_HRM.Properties.Resources.diskette;
            this.btn_save.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btn_save.Location = new System.Drawing.Point(31, 15);
            this.btn_save.Name = "btn_save";
            this.btn_save.Size = new System.Drawing.Size(127, 30);
            this.btn_save.TabIndex = 4;
            this.btn_save.Text = "Lưu";
            this.btn_save.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btn_save.UseVisualStyleBackColor = true;
            this.btn_save.Click += new System.EventHandler(this.btn_save_Click);
            // 
            // btn_cancel
            // 
            this.btn_cancel.Image = global::TENTAC_HRM.Properties.Resources.cancel;
            this.btn_cancel.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btn_cancel.Location = new System.Drawing.Point(199, 15);
            this.btn_cancel.Name = "btn_cancel";
            this.btn_cancel.Size = new System.Drawing.Size(127, 30);
            this.btn_cancel.TabIndex = 5;
            this.btn_cancel.Text = "Đóng";
            this.btn_cancel.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btn_cancel.UseVisualStyleBackColor = true;
            this.btn_cancel.Click += new System.EventHandler(this.btn_cancel_Click);
            // 
            // txtMota
            // 
            this.txtMota.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(228)))), ((int)(((byte)(247)))), ((int)(((byte)(254)))));
            // 
            // 
            // 
            this.txtMota.Border.Class = "TextBoxBorder";
            this.txtMota.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtMota.Location = new System.Drawing.Point(31, 244);
            this.txtMota.Margin = new System.Windows.Forms.Padding(4);
            this.txtMota.Multiline = true;
            this.txtMota.Name = "txtMota";
            this.txtMota.Size = new System.Drawing.Size(295, 93);
            this.txtMota.TabIndex = 3;
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(16)))), ((int)(((byte)(39)))), ((int)(((byte)(75)))));
            this.panel2.Controls.Add(this.btn_save);
            this.panel2.Controls.Add(this.btn_cancel);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel2.Location = new System.Drawing.Point(0, 365);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(357, 57);
            this.panel2.TabIndex = 32;
            // 
            // frmMstChungChi
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(357, 422);
            this.Controls.Add(this.panel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "frmMstChungChi";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Chứng Chỉ";
            this.panel1.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Panel panel1;
        private DevComponents.DotNetBar.LabelX lblMoTa;
        private DevComponents.DotNetBar.Controls.TextBoxX txtTenChungChi;
        private DevComponents.DotNetBar.LabelX lblTenChungChi;
        private DevComponents.DotNetBar.LabelX lblMaChungChi;
        private DevComponents.DotNetBar.Controls.TextBoxX txtMaChungChi;
        private System.Windows.Forms.Button btn_save;
        private System.Windows.Forms.Button btn_cancel;
        private DevComponents.DotNetBar.Controls.TextBoxX txtMota;
        private DevComponents.DotNetBar.LabelX labelX1;
        private System.Windows.Forms.Panel panel2;
    }
}