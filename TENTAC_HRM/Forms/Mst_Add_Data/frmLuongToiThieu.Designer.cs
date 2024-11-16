namespace TENTAC_HRM.Forms.Mst_Add_Data
{
    partial class frmLuongToiThieu
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
            this.txtTenVung = new DevComponents.DotNetBar.Controls.TextBoxX();
            this.txtLuongToiThieuTheoGio = new DevComponents.DotNetBar.Controls.TextBoxX();
            this.lblLuongToiThieuTheoGio = new DevComponents.DotNetBar.LabelX();
            this.txtLuongToiThieuTheoThang = new DevComponents.DotNetBar.Controls.TextBoxX();
            this.lblLuongToiThieuTheoThang = new DevComponents.DotNetBar.LabelX();
            this.lblVung = new DevComponents.DotNetBar.LabelX();
            this.btn_save = new System.Windows.Forms.Button();
            this.btn_cancel = new System.Windows.Forms.Button();
            this.panel2 = new System.Windows.Forms.Panel();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.panel2);
            this.panel1.Controls.Add(this.labelX1);
            this.panel1.Controls.Add(this.txtTenVung);
            this.panel1.Controls.Add(this.txtLuongToiThieuTheoGio);
            this.panel1.Controls.Add(this.lblLuongToiThieuTheoGio);
            this.panel1.Controls.Add(this.txtLuongToiThieuTheoThang);
            this.panel1.Controls.Add(this.lblLuongToiThieuTheoThang);
            this.panel1.Controls.Add(this.lblVung);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(344, 342);
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
            this.labelX1.Size = new System.Drawing.Size(344, 62);
            this.labelX1.TabIndex = 55;
            this.labelX1.Text = "Thêm Thông Tin Vùng";
            this.labelX1.TextAlignment = System.Drawing.StringAlignment.Center;
            // 
            // txtTenVung
            // 
            this.txtTenVung.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(228)))), ((int)(((byte)(247)))), ((int)(((byte)(254)))));
            // 
            // 
            // 
            this.txtTenVung.Border.Class = "TextBoxBorder";
            this.txtTenVung.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtTenVung.Location = new System.Drawing.Point(20, 108);
            this.txtTenVung.Multiline = true;
            this.txtTenVung.Name = "txtTenVung";
            this.txtTenVung.Size = new System.Drawing.Size(295, 25);
            this.txtTenVung.TabIndex = 1;
            // 
            // txtLuongToiThieuTheoGio
            // 
            this.txtLuongToiThieuTheoGio.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(228)))), ((int)(((byte)(247)))), ((int)(((byte)(254)))));
            // 
            // 
            // 
            this.txtLuongToiThieuTheoGio.Border.Class = "TextBoxBorder";
            this.txtLuongToiThieuTheoGio.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtLuongToiThieuTheoGio.Location = new System.Drawing.Point(20, 228);
            this.txtLuongToiThieuTheoGio.Multiline = true;
            this.txtLuongToiThieuTheoGio.Name = "txtLuongToiThieuTheoGio";
            this.txtLuongToiThieuTheoGio.Size = new System.Drawing.Size(295, 25);
            this.txtLuongToiThieuTheoGio.TabIndex = 3;
            this.txtLuongToiThieuTheoGio.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.textBox_KeyPress);
            // 
            // lblLuongToiThieuTheoGio
            // 
            this.lblLuongToiThieuTheoGio.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblLuongToiThieuTheoGio.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.lblLuongToiThieuTheoGio.Location = new System.Drawing.Point(20, 199);
            this.lblLuongToiThieuTheoGio.Name = "lblLuongToiThieuTheoGio";
            this.lblLuongToiThieuTheoGio.Size = new System.Drawing.Size(185, 23);
            this.lblLuongToiThieuTheoGio.TabIndex = 54;
            this.lblLuongToiThieuTheoGio.Text = "Lương Tối Thiểu Theo Giờ:";
            // 
            // txtLuongToiThieuTheoThang
            // 
            this.txtLuongToiThieuTheoThang.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(228)))), ((int)(((byte)(247)))), ((int)(((byte)(254)))));
            // 
            // 
            // 
            this.txtLuongToiThieuTheoThang.Border.Class = "TextBoxBorder";
            this.txtLuongToiThieuTheoThang.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtLuongToiThieuTheoThang.Location = new System.Drawing.Point(20, 168);
            this.txtLuongToiThieuTheoThang.Multiline = true;
            this.txtLuongToiThieuTheoThang.Name = "txtLuongToiThieuTheoThang";
            this.txtLuongToiThieuTheoThang.Size = new System.Drawing.Size(295, 25);
            this.txtLuongToiThieuTheoThang.TabIndex = 2;
            this.txtLuongToiThieuTheoThang.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.textBox_KeyPress);
            // 
            // lblLuongToiThieuTheoThang
            // 
            this.lblLuongToiThieuTheoThang.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblLuongToiThieuTheoThang.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.lblLuongToiThieuTheoThang.Location = new System.Drawing.Point(20, 139);
            this.lblLuongToiThieuTheoThang.Name = "lblLuongToiThieuTheoThang";
            this.lblLuongToiThieuTheoThang.Size = new System.Drawing.Size(204, 23);
            this.lblLuongToiThieuTheoThang.TabIndex = 52;
            this.lblLuongToiThieuTheoThang.Text = "Lương Tối Thiểu Theo Tháng:";
            // 
            // lblVung
            // 
            this.lblVung.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblVung.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.lblVung.Location = new System.Drawing.Point(20, 79);
            this.lblVung.Name = "lblVung";
            this.lblVung.Size = new System.Drawing.Size(101, 23);
            this.lblVung.TabIndex = 51;
            this.lblVung.Text = "Tên Vùng:";
            // 
            // btn_save
            // 
            this.btn_save.Image = global::TENTAC_HRM.Properties.Resources.diskette;
            this.btn_save.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btn_save.Location = new System.Drawing.Point(20, 15);
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
            this.btn_cancel.Location = new System.Drawing.Point(188, 15);
            this.btn_cancel.Name = "btn_cancel";
            this.btn_cancel.Size = new System.Drawing.Size(127, 30);
            this.btn_cancel.TabIndex = 5;
            this.btn_cancel.Text = "Đóng";
            this.btn_cancel.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btn_cancel.UseVisualStyleBackColor = true;
            this.btn_cancel.Click += new System.EventHandler(this.btn_cancel_Click);
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(16)))), ((int)(((byte)(39)))), ((int)(((byte)(75)))));
            this.panel2.Controls.Add(this.btn_save);
            this.panel2.Controls.Add(this.btn_cancel);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel2.Location = new System.Drawing.Point(0, 285);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(344, 57);
            this.panel2.TabIndex = 56;
            // 
            // frmLuongToiThieu
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(344, 342);
            this.Controls.Add(this.panel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "frmLuongToiThieu";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Lương Tối Thiểu";
            this.panel1.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private DevComponents.DotNetBar.Controls.TextBoxX txtTenVung;
        private DevComponents.DotNetBar.Controls.TextBoxX txtLuongToiThieuTheoGio;
        private DevComponents.DotNetBar.LabelX lblLuongToiThieuTheoGio;
        private DevComponents.DotNetBar.Controls.TextBoxX txtLuongToiThieuTheoThang;
        private DevComponents.DotNetBar.LabelX lblLuongToiThieuTheoThang;
        private DevComponents.DotNetBar.LabelX lblVung;
        private System.Windows.Forms.Button btn_save;
        private System.Windows.Forms.Button btn_cancel;
        private DevComponents.DotNetBar.LabelX labelX1;
        private System.Windows.Forms.Panel panel2;
    }
}