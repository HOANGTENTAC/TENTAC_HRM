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
            this.txtGhiChu = new DevComponents.DotNetBar.Controls.TextBoxX();
            this.labelX6 = new DevComponents.DotNetBar.LabelX();
            this.labelX5 = new DevComponents.DotNetBar.LabelX();
            this.cbo_NamHienHanh = new DevComponents.DotNetBar.Controls.ComboBoxEx();
            this.labelX4 = new DevComponents.DotNetBar.LabelX();
            this.labelX3 = new DevComponents.DotNetBar.LabelX();
            this.labelX2 = new DevComponents.DotNetBar.LabelX();
            this.panel2 = new System.Windows.Forms.Panel();
            this.btn_save = new System.Windows.Forms.Button();
            this.btn_cancel = new System.Windows.Forms.Button();
            this.labelX1 = new DevComponents.DotNetBar.LabelX();
            this.txtTenVung = new DevComponents.DotNetBar.Controls.TextBoxX();
            this.txtLuongToiThieuTheoGio = new DevComponents.DotNetBar.Controls.TextBoxX();
            this.txtLuongToiThieuTheoThang = new DevComponents.DotNetBar.Controls.TextBoxX();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.txtGhiChu);
            this.panel1.Controls.Add(this.labelX6);
            this.panel1.Controls.Add(this.labelX5);
            this.panel1.Controls.Add(this.cbo_NamHienHanh);
            this.panel1.Controls.Add(this.labelX4);
            this.panel1.Controls.Add(this.labelX3);
            this.panel1.Controls.Add(this.labelX2);
            this.panel1.Controls.Add(this.panel2);
            this.panel1.Controls.Add(this.labelX1);
            this.panel1.Controls.Add(this.txtTenVung);
            this.panel1.Controls.Add(this.txtLuongToiThieuTheoGio);
            this.panel1.Controls.Add(this.txtLuongToiThieuTheoThang);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(344, 449);
            this.panel1.TabIndex = 1;
            // 
            // txtGhiChu
            // 
            // 
            // 
            // 
            this.txtGhiChu.Border.Class = "TextBoxBorder";
            this.txtGhiChu.Location = new System.Drawing.Point(18, 282);
            this.txtGhiChu.Multiline = true;
            this.txtGhiChu.Name = "txtGhiChu";
            this.txtGhiChu.Size = new System.Drawing.Size(297, 82);
            this.txtGhiChu.TabIndex = 5;
            // 
            // labelX6
            // 
            this.labelX6.Location = new System.Drawing.Point(20, 253);
            this.labelX6.Name = "labelX6";
            this.labelX6.Size = new System.Drawing.Size(59, 23);
            this.labelX6.TabIndex = 62;
            this.labelX6.Text = "Ghi chú";
            // 
            // labelX5
            // 
            this.labelX5.Location = new System.Drawing.Point(20, 196);
            this.labelX5.Name = "labelX5";
            this.labelX5.Size = new System.Drawing.Size(176, 23);
            this.labelX5.TabIndex = 61;
            this.labelX5.Text = "Lương tối thiểu theo giờ";
            // 
            // cbo_NamHienHanh
            // 
            this.cbo_NamHienHanh.DisplayMember = "Text";
            this.cbo_NamHienHanh.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.cbo_NamHienHanh.FormattingEnabled = true;
            this.cbo_NamHienHanh.ItemHeight = 16;
            this.cbo_NamHienHanh.Location = new System.Drawing.Point(220, 108);
            this.cbo_NamHienHanh.Name = "cbo_NamHienHanh";
            this.cbo_NamHienHanh.Size = new System.Drawing.Size(95, 22);
            this.cbo_NamHienHanh.TabIndex = 2;
            // 
            // labelX4
            // 
            this.labelX4.Location = new System.Drawing.Point(20, 139);
            this.labelX4.Name = "labelX4";
            this.labelX4.Size = new System.Drawing.Size(176, 23);
            this.labelX4.TabIndex = 59;
            this.labelX4.Text = "Lương tối thiểu theo tháng";
            // 
            // labelX3
            // 
            this.labelX3.Location = new System.Drawing.Point(220, 79);
            this.labelX3.Name = "labelX3";
            this.labelX3.Size = new System.Drawing.Size(95, 23);
            this.labelX3.TabIndex = 58;
            this.labelX3.Text = "Năm hiện hành";
            // 
            // labelX2
            // 
            this.labelX2.Location = new System.Drawing.Point(20, 79);
            this.labelX2.Name = "labelX2";
            this.labelX2.Size = new System.Drawing.Size(75, 23);
            this.labelX2.TabIndex = 57;
            this.labelX2.Text = "Tên vùng";
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(16)))), ((int)(((byte)(39)))), ((int)(((byte)(75)))));
            this.panel2.Controls.Add(this.btn_save);
            this.panel2.Controls.Add(this.btn_cancel);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel2.Location = new System.Drawing.Point(0, 392);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(344, 57);
            this.panel2.TabIndex = 56;
            // 
            // btn_save
            // 
            this.btn_save.Image = global::TENTAC_HRM.Properties.Resources.diskette;
            this.btn_save.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btn_save.Location = new System.Drawing.Point(20, 15);
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
            this.btn_cancel.Location = new System.Drawing.Point(188, 15);
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
            this.labelX1.Size = new System.Drawing.Size(344, 62);
            this.labelX1.TabIndex = 55;
            this.labelX1.Text = "Thêm Thông Tin Vùng";
            this.labelX1.TextAlignment = System.Drawing.StringAlignment.Center;
            // 
            // txtTenVung
            // 
            this.txtTenVung.BackColor = System.Drawing.SystemColors.Window;
            // 
            // 
            // 
            this.txtTenVung.Border.Class = "TextBoxBorder";
            this.txtTenVung.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtTenVung.Location = new System.Drawing.Point(18, 108);
            this.txtTenVung.Name = "txtTenVung";
            this.txtTenVung.Size = new System.Drawing.Size(185, 22);
            this.txtTenVung.TabIndex = 1;
            // 
            // txtLuongToiThieuTheoGio
            // 
            this.txtLuongToiThieuTheoGio.BackColor = System.Drawing.SystemColors.Window;
            // 
            // 
            // 
            this.txtLuongToiThieuTheoGio.Border.Class = "TextBoxBorder";
            this.txtLuongToiThieuTheoGio.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtLuongToiThieuTheoGio.Location = new System.Drawing.Point(20, 225);
            this.txtLuongToiThieuTheoGio.Name = "txtLuongToiThieuTheoGio";
            this.txtLuongToiThieuTheoGio.Size = new System.Drawing.Size(295, 22);
            this.txtLuongToiThieuTheoGio.TabIndex = 4;
            this.txtLuongToiThieuTheoGio.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.textBox_KeyPress);
            this.txtLuongToiThieuTheoGio.Leave += new System.EventHandler(this.txt_mucluong_Leave);
            // 
            // txtLuongToiThieuTheoThang
            // 
            this.txtLuongToiThieuTheoThang.BackColor = System.Drawing.SystemColors.Window;
            // 
            // 
            // 
            this.txtLuongToiThieuTheoThang.Border.Class = "TextBoxBorder";
            this.txtLuongToiThieuTheoThang.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtLuongToiThieuTheoThang.Location = new System.Drawing.Point(20, 168);
            this.txtLuongToiThieuTheoThang.Name = "txtLuongToiThieuTheoThang";
            this.txtLuongToiThieuTheoThang.Size = new System.Drawing.Size(295, 22);
            this.txtLuongToiThieuTheoThang.TabIndex = 3;
            this.txtLuongToiThieuTheoThang.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.textBox_KeyPress);
            this.txtLuongToiThieuTheoThang.Leave += new System.EventHandler(this.txt_mucluong_Leave);
            // 
            // frmLuongToiThieu
            // 
            this.AcceptButton = this.btn_save;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.btn_cancel;
            this.ClientSize = new System.Drawing.Size(344, 449);
            this.Controls.Add(this.panel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmLuongToiThieu";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Load += new System.EventHandler(this.frmLuongToiThieu_Load);
            this.panel1.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private DevComponents.DotNetBar.Controls.TextBoxX txtTenVung;
        private DevComponents.DotNetBar.Controls.TextBoxX txtLuongToiThieuTheoGio;
        private DevComponents.DotNetBar.Controls.TextBoxX txtLuongToiThieuTheoThang;
        private System.Windows.Forms.Button btn_save;
        private System.Windows.Forms.Button btn_cancel;
        private DevComponents.DotNetBar.LabelX labelX1;
        private System.Windows.Forms.Panel panel2;
        private DevComponents.DotNetBar.LabelX labelX4;
        private DevComponents.DotNetBar.LabelX labelX3;
        private DevComponents.DotNetBar.LabelX labelX2;
        private DevComponents.DotNetBar.Controls.TextBoxX txtGhiChu;
        private DevComponents.DotNetBar.LabelX labelX6;
        private DevComponents.DotNetBar.LabelX labelX5;
        private DevComponents.DotNetBar.Controls.ComboBoxEx cbo_NamHienHanh;
    }
}