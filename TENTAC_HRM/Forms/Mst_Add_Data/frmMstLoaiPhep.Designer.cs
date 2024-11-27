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
            this.txtMoTa = new DevComponents.DotNetBar.Controls.TextBoxX();
            this.labelX6 = new DevComponents.DotNetBar.LabelX();
            this.txtSoNgayCong = new DevComponents.DotNetBar.Controls.TextBoxX();
            this.txtKyHieu = new DevComponents.DotNetBar.Controls.TextBoxX();
            this.labelX3 = new DevComponents.DotNetBar.LabelX();
            this.labelX5 = new DevComponents.DotNetBar.LabelX();
            this.txtTenLoaiPhep = new DevComponents.DotNetBar.Controls.TextBoxX();
            this.labelX4 = new DevComponents.DotNetBar.LabelX();
            this.txtMaLoaiPhep = new DevComponents.DotNetBar.Controls.TextBoxX();
            this.labelX2 = new DevComponents.DotNetBar.LabelX();
            this.panel2 = new System.Windows.Forms.Panel();
            this.btn_save = new System.Windows.Forms.Button();
            this.btn_cancel = new System.Windows.Forms.Button();
            this.labelX1 = new DevComponents.DotNetBar.LabelX();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.txtMoTa);
            this.panel1.Controls.Add(this.labelX6);
            this.panel1.Controls.Add(this.txtSoNgayCong);
            this.panel1.Controls.Add(this.txtKyHieu);
            this.panel1.Controls.Add(this.labelX3);
            this.panel1.Controls.Add(this.labelX5);
            this.panel1.Controls.Add(this.txtTenLoaiPhep);
            this.panel1.Controls.Add(this.labelX4);
            this.panel1.Controls.Add(this.txtMaLoaiPhep);
            this.panel1.Controls.Add(this.labelX2);
            this.panel1.Controls.Add(this.panel2);
            this.panel1.Controls.Add(this.labelX1);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(356, 453);
            this.panel1.TabIndex = 1;
            // 
            // txtMoTa
            // 
            // 
            // 
            // 
            this.txtMoTa.Border.Class = "TextBoxBorder";
            this.txtMoTa.Location = new System.Drawing.Point(27, 280);
            this.txtMoTa.Multiline = true;
            this.txtMoTa.Name = "txtMoTa";
            this.txtMoTa.Size = new System.Drawing.Size(293, 81);
            this.txtMoTa.TabIndex = 5;
            // 
            // labelX6
            // 
            this.labelX6.Location = new System.Drawing.Point(29, 251);
            this.labelX6.Name = "labelX6";
            this.labelX6.Size = new System.Drawing.Size(60, 23);
            this.labelX6.TabIndex = 66;
            this.labelX6.Text = "Mô Tả";
            // 
            // txtSoNgayCong
            // 
            // 
            // 
            // 
            this.txtSoNgayCong.Border.Class = "TextBoxBorder";
            this.txtSoNgayCong.Location = new System.Drawing.Point(29, 223);
            this.txtSoNgayCong.Name = "txtSoNgayCong";
            this.txtSoNgayCong.Size = new System.Drawing.Size(133, 22);
            this.txtSoNgayCong.TabIndex = 3;
            this.txtSoNgayCong.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.textBox_KeyPress);
            // 
            // txtKyHieu
            // 
            // 
            // 
            // 
            this.txtKyHieu.Border.Class = "TextBoxBorder";
            this.txtKyHieu.Location = new System.Drawing.Point(187, 223);
            this.txtKyHieu.Name = "txtKyHieu";
            this.txtKyHieu.Size = new System.Drawing.Size(133, 22);
            this.txtKyHieu.TabIndex = 4;
            // 
            // labelX3
            // 
            this.labelX3.Location = new System.Drawing.Point(187, 194);
            this.labelX3.Name = "labelX3";
            this.labelX3.Size = new System.Drawing.Size(72, 23);
            this.labelX3.TabIndex = 63;
            this.labelX3.Text = "Ký Hiệu";
            // 
            // labelX5
            // 
            this.labelX5.Location = new System.Drawing.Point(29, 194);
            this.labelX5.Name = "labelX5";
            this.labelX5.Size = new System.Drawing.Size(98, 23);
            this.labelX5.TabIndex = 62;
            this.labelX5.Text = "Số Ngày Công";
            // 
            // txtTenLoaiPhep
            // 
            // 
            // 
            // 
            this.txtTenLoaiPhep.Border.Class = "TextBoxBorder";
            this.txtTenLoaiPhep.Location = new System.Drawing.Point(29, 166);
            this.txtTenLoaiPhep.Name = "txtTenLoaiPhep";
            this.txtTenLoaiPhep.Size = new System.Drawing.Size(295, 22);
            this.txtTenLoaiPhep.TabIndex = 2;
            // 
            // labelX4
            // 
            this.labelX4.Location = new System.Drawing.Point(29, 136);
            this.labelX4.Name = "labelX4";
            this.labelX4.Size = new System.Drawing.Size(98, 23);
            this.labelX4.TabIndex = 60;
            this.labelX4.Text = "Tên Loại Phép";
            // 
            // txtMaLoaiPhep
            // 
            // 
            // 
            // 
            this.txtMaLoaiPhep.Border.Class = "TextBoxBorder";
            this.txtMaLoaiPhep.Location = new System.Drawing.Point(29, 108);
            this.txtMaLoaiPhep.Name = "txtMaLoaiPhep";
            this.txtMaLoaiPhep.ReadOnly = true;
            this.txtMaLoaiPhep.Size = new System.Drawing.Size(290, 22);
            this.txtMaLoaiPhep.TabIndex = 1;
            // 
            // labelX2
            // 
            this.labelX2.Location = new System.Drawing.Point(29, 78);
            this.labelX2.Name = "labelX2";
            this.labelX2.Size = new System.Drawing.Size(127, 23);
            this.labelX2.TabIndex = 56;
            this.labelX2.Text = "Mã Loại Phép Năm";
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(16)))), ((int)(((byte)(39)))), ((int)(((byte)(75)))));
            this.panel2.Controls.Add(this.btn_save);
            this.panel2.Controls.Add(this.btn_cancel);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel2.Location = new System.Drawing.Point(0, 396);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(356, 57);
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
            this.btn_cancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
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
            // labelX1
            // 
            this.labelX1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(16)))), ((int)(((byte)(39)))), ((int)(((byte)(75)))));
            this.labelX1.Dock = System.Windows.Forms.DockStyle.Top;
            this.labelX1.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelX1.ForeColor = System.Drawing.Color.WhiteSmoke;
            this.labelX1.Location = new System.Drawing.Point(0, 0);
            this.labelX1.Name = "labelX1";
            this.labelX1.Size = new System.Drawing.Size(356, 62);
            this.labelX1.TabIndex = 0;
            this.labelX1.Text = "Thêm Thông Tin Loại Phép";
            this.labelX1.TextAlignment = System.Drawing.StringAlignment.Center;
            // 
            // frmMstLoaiPhep
            // 
            this.AcceptButton = this.btn_save;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.btn_cancel;
            this.ClientSize = new System.Drawing.Size(356, 453);
            this.Controls.Add(this.panel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmMstLoaiPhep";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Load += new System.EventHandler(this.frmMstLoaiPhep_Load);
            this.panel1.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button btn_save;
        private System.Windows.Forms.Button btn_cancel;
        private DevComponents.DotNetBar.LabelX labelX1;
        private System.Windows.Forms.Panel panel2;
        private DevComponents.DotNetBar.LabelX labelX2;
        private DevComponents.DotNetBar.Controls.TextBoxX txtMaLoaiPhep;
        private DevComponents.DotNetBar.LabelX labelX5;
        private DevComponents.DotNetBar.Controls.TextBoxX txtTenLoaiPhep;
        private DevComponents.DotNetBar.LabelX labelX4;
        private DevComponents.DotNetBar.Controls.TextBoxX txtMoTa;
        private DevComponents.DotNetBar.LabelX labelX6;
        private DevComponents.DotNetBar.Controls.TextBoxX txtSoNgayCong;
        private DevComponents.DotNetBar.Controls.TextBoxX txtKyHieu;
        private DevComponents.DotNetBar.LabelX labelX3;
    }
}