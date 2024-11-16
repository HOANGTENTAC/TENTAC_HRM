namespace TENTAC_HRM.Forms.Mst_Add_Data
{
    partial class frmMstLoaiPhep
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
            this.panel2 = new System.Windows.Forms.Panel();
            this.btn_save = new System.Windows.Forms.Button();
            this.btn_cancel = new System.Windows.Forms.Button();
            this.chkTinhCong = new DevComponents.DotNetBar.Controls.CheckBoxX();
            this.lblTinhCong = new DevComponents.DotNetBar.LabelX();
            this.txtSoCong = new DevComponents.DotNetBar.Controls.TextBoxX();
            this.lblSoCong = new DevComponents.DotNetBar.LabelX();
            this.txtKyHieu = new DevComponents.DotNetBar.Controls.TextBoxX();
            this.lblKyHieu = new DevComponents.DotNetBar.LabelX();
            this.txtTenLoaiPhep = new DevComponents.DotNetBar.Controls.TextBoxX();
            this.lblTenLoaiPhep = new DevComponents.DotNetBar.LabelX();
            this.lblMaLoaiPhep = new DevComponents.DotNetBar.LabelX();
            this.txtMaLoaiPhep = new DevComponents.DotNetBar.Controls.TextBoxX();
            this.labelX1 = new DevComponents.DotNetBar.LabelX();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.panel2);
            this.panel1.Controls.Add(this.chkTinhCong);
            this.panel1.Controls.Add(this.lblTinhCong);
            this.panel1.Controls.Add(this.txtSoCong);
            this.panel1.Controls.Add(this.lblSoCong);
            this.panel1.Controls.Add(this.txtKyHieu);
            this.panel1.Controls.Add(this.lblKyHieu);
            this.panel1.Controls.Add(this.txtTenLoaiPhep);
            this.panel1.Controls.Add(this.lblTenLoaiPhep);
            this.panel1.Controls.Add(this.lblMaLoaiPhep);
            this.panel1.Controls.Add(this.txtMaLoaiPhep);
            this.panel1.Controls.Add(this.labelX1);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(359, 400);
            this.panel1.TabIndex = 1;
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(16)))), ((int)(((byte)(39)))), ((int)(((byte)(75)))));
            this.panel2.Controls.Add(this.btn_save);
            this.panel2.Controls.Add(this.btn_cancel);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel2.Location = new System.Drawing.Point(0, 343);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(359, 57);
            this.panel2.TabIndex = 55;
            // 
            // btn_save
            // 
            this.btn_save.Image = global::TENTAC_HRM.Properties.Resources.diskette;
            this.btn_save.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btn_save.Location = new System.Drawing.Point(29, 15);
            this.btn_save.Name = "btn_save";
            this.btn_save.Size = new System.Drawing.Size(127, 30);
            this.btn_save.TabIndex = 6;
            this.btn_save.Text = "Lưu";
            this.btn_save.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btn_save.UseVisualStyleBackColor = true;
            this.btn_save.Click += new System.EventHandler(this.btn_save_Click);
            // 
            // btn_cancel
            // 
            this.btn_cancel.Image = global::TENTAC_HRM.Properties.Resources.cancel;
            this.btn_cancel.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btn_cancel.Location = new System.Drawing.Point(197, 15);
            this.btn_cancel.Name = "btn_cancel";
            this.btn_cancel.Size = new System.Drawing.Size(127, 30);
            this.btn_cancel.TabIndex = 7;
            this.btn_cancel.Text = "Đóng";
            this.btn_cancel.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btn_cancel.UseVisualStyleBackColor = true;
            this.btn_cancel.Click += new System.EventHandler(this.btn_cancel_Click);
            // 
            // chkTinhCong
            // 
            this.chkTinhCong.Location = new System.Drawing.Point(290, 295);
            this.chkTinhCong.Name = "chkTinhCong";
            this.chkTinhCong.Size = new System.Drawing.Size(29, 23);
            this.chkTinhCong.TabIndex = 5;
            this.chkTinhCong.CheckedChanged += new System.EventHandler(this.chkTinhCong_CheckedChanged);
            // 
            // lblTinhCong
            // 
            this.lblTinhCong.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTinhCong.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.lblTinhCong.Location = new System.Drawing.Point(208, 294);
            this.lblTinhCong.Name = "lblTinhCong";
            this.lblTinhCong.Size = new System.Drawing.Size(76, 23);
            this.lblTinhCong.TabIndex = 54;
            this.lblTinhCong.Text = "Tính Công:";
            // 
            // txtSoCong
            // 
            this.txtSoCong.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(228)))), ((int)(((byte)(247)))), ((int)(((byte)(254)))));
            // 
            // 
            // 
            this.txtSoCong.Border.Class = "TextBoxBorder";
            this.txtSoCong.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtSoCong.Location = new System.Drawing.Point(29, 295);
            this.txtSoCong.Multiline = true;
            this.txtSoCong.Name = "txtSoCong";
            this.txtSoCong.Size = new System.Drawing.Size(162, 25);
            this.txtSoCong.TabIndex = 4;
            this.txtSoCong.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.textBox_KeyPress);
            // 
            // lblSoCong
            // 
            this.lblSoCong.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblSoCong.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.lblSoCong.Location = new System.Drawing.Point(29, 266);
            this.lblSoCong.Name = "lblSoCong";
            this.lblSoCong.Size = new System.Drawing.Size(98, 23);
            this.lblSoCong.TabIndex = 52;
            this.lblSoCong.Text = "Số Ngày Công:";
            // 
            // txtKyHieu
            // 
            this.txtKyHieu.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(228)))), ((int)(((byte)(247)))), ((int)(((byte)(254)))));
            // 
            // 
            // 
            this.txtKyHieu.Border.Class = "TextBoxBorder";
            this.txtKyHieu.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtKyHieu.Location = new System.Drawing.Point(29, 235);
            this.txtKyHieu.Multiline = true;
            this.txtKyHieu.Name = "txtKyHieu";
            this.txtKyHieu.Size = new System.Drawing.Size(295, 25);
            this.txtKyHieu.TabIndex = 3;
            // 
            // lblKyHieu
            // 
            this.lblKyHieu.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblKyHieu.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.lblKyHieu.Location = new System.Drawing.Point(29, 206);
            this.lblKyHieu.Name = "lblKyHieu";
            this.lblKyHieu.Size = new System.Drawing.Size(98, 23);
            this.lblKyHieu.TabIndex = 50;
            this.lblKyHieu.Text = "Ký Hiệu:";
            // 
            // txtTenLoaiPhep
            // 
            this.txtTenLoaiPhep.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(228)))), ((int)(((byte)(247)))), ((int)(((byte)(254)))));
            // 
            // 
            // 
            this.txtTenLoaiPhep.Border.Class = "TextBoxBorder";
            this.txtTenLoaiPhep.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtTenLoaiPhep.Location = new System.Drawing.Point(29, 175);
            this.txtTenLoaiPhep.Multiline = true;
            this.txtTenLoaiPhep.Name = "txtTenLoaiPhep";
            this.txtTenLoaiPhep.Size = new System.Drawing.Size(295, 25);
            this.txtTenLoaiPhep.TabIndex = 2;
            // 
            // lblTenLoaiPhep
            // 
            this.lblTenLoaiPhep.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTenLoaiPhep.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.lblTenLoaiPhep.Location = new System.Drawing.Point(29, 146);
            this.lblTenLoaiPhep.Name = "lblTenLoaiPhep";
            this.lblTenLoaiPhep.Size = new System.Drawing.Size(113, 23);
            this.lblTenLoaiPhep.TabIndex = 48;
            this.lblTenLoaiPhep.Text = "Tên Loại Phép:";
            // 
            // lblMaLoaiPhep
            // 
            this.lblMaLoaiPhep.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblMaLoaiPhep.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.lblMaLoaiPhep.Location = new System.Drawing.Point(29, 86);
            this.lblMaLoaiPhep.Name = "lblMaLoaiPhep";
            this.lblMaLoaiPhep.Size = new System.Drawing.Size(98, 23);
            this.lblMaLoaiPhep.TabIndex = 47;
            this.lblMaLoaiPhep.Text = "Mã Loại Phép:";
            // 
            // txtMaLoaiPhep
            // 
            this.txtMaLoaiPhep.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(248)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            // 
            // 
            // 
            this.txtMaLoaiPhep.Border.Class = "TextBoxBorder";
            this.txtMaLoaiPhep.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtMaLoaiPhep.Location = new System.Drawing.Point(29, 115);
            this.txtMaLoaiPhep.Multiline = true;
            this.txtMaLoaiPhep.Name = "txtMaLoaiPhep";
            this.txtMaLoaiPhep.ReadOnly = true;
            this.txtMaLoaiPhep.Size = new System.Drawing.Size(295, 25);
            this.txtMaLoaiPhep.TabIndex = 1;
            // 
            // labelX1
            // 
            this.labelX1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(16)))), ((int)(((byte)(39)))), ((int)(((byte)(75)))));
            this.labelX1.Dock = System.Windows.Forms.DockStyle.Top;
            this.labelX1.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelX1.ForeColor = System.Drawing.Color.WhiteSmoke;
            this.labelX1.Location = new System.Drawing.Point(0, 0);
            this.labelX1.Name = "labelX1";
            this.labelX1.Size = new System.Drawing.Size(359, 62);
            this.labelX1.TabIndex = 0;
            this.labelX1.Text = "Thêm Thông Tin Loại Phép";
            this.labelX1.TextAlignment = System.Drawing.StringAlignment.Center;
            // 
            // frmMstLoaiPhep
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(359, 400);
            this.Controls.Add(this.panel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "frmMstLoaiPhep";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Loại Phép";
            this.panel1.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private DevComponents.DotNetBar.Controls.CheckBoxX chkTinhCong;
        private DevComponents.DotNetBar.LabelX lblTinhCong;
        private DevComponents.DotNetBar.Controls.TextBoxX txtSoCong;
        private DevComponents.DotNetBar.LabelX lblSoCong;
        private DevComponents.DotNetBar.Controls.TextBoxX txtKyHieu;
        private DevComponents.DotNetBar.LabelX lblKyHieu;
        private DevComponents.DotNetBar.Controls.TextBoxX txtTenLoaiPhep;
        private DevComponents.DotNetBar.LabelX lblTenLoaiPhep;
        private DevComponents.DotNetBar.LabelX lblMaLoaiPhep;
        private DevComponents.DotNetBar.Controls.TextBoxX txtMaLoaiPhep;
        private System.Windows.Forms.Button btn_save;
        private System.Windows.Forms.Button btn_cancel;
        private DevComponents.DotNetBar.LabelX labelX1;
        private System.Windows.Forms.Panel panel2;
    }
}