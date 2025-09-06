namespace TENTAC_HRM.Forms.Main
{
    partial class frm_ChangePassWord
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frm_ChangePassWord));
            this.txt_TenDangNhap = new DevComponents.DotNetBar.Controls.TextBoxX();
            this.labelX1 = new DevComponents.DotNetBar.LabelX();
            this.txt_TenNguoiDung = new DevComponents.DotNetBar.Controls.TextBoxX();
            this.labelX2 = new DevComponents.DotNetBar.LabelX();
            this.txt_MatKhauMoi = new DevComponents.DotNetBar.Controls.TextBoxX();
            this.labelX3 = new DevComponents.DotNetBar.LabelX();
            this.txt_XacNhanMatKhau = new DevComponents.DotNetBar.Controls.TextBoxX();
            this.labelX4 = new DevComponents.DotNetBar.LabelX();
            this.btn_ShowPass = new System.Windows.Forms.Button();
            this.btn_ShowPass1 = new System.Windows.Forms.Button();
            this.labelX5 = new DevComponents.DotNetBar.LabelX();
            this.lb_Notifi = new DevComponents.DotNetBar.LabelX();
            this.btn_Save = new DevComponents.DotNetBar.ButtonX();
            this.kryptonPalette1 = new ComponentFactory.Krypton.Toolkit.KryptonPalette(this.components);
            this.SuspendLayout();
            // 
            // txt_TenDangNhap
            // 
            // 
            // 
            // 
            this.txt_TenDangNhap.Border.Class = "TextBoxBorder";
            this.txt_TenDangNhap.Enabled = false;
            this.txt_TenDangNhap.Location = new System.Drawing.Point(126, 13);
            this.txt_TenDangNhap.Name = "txt_TenDangNhap";
            this.txt_TenDangNhap.Size = new System.Drawing.Size(147, 20);
            this.txt_TenDangNhap.TabIndex = 0;
            // 
            // labelX1
            // 
            this.labelX1.Location = new System.Drawing.Point(12, 12);
            this.labelX1.Name = "labelX1";
            this.labelX1.Size = new System.Drawing.Size(108, 23);
            this.labelX1.TabIndex = 1;
            this.labelX1.Text = "Tên đăng nhập";
            // 
            // txt_TenNguoiDung
            // 
            // 
            // 
            // 
            this.txt_TenNguoiDung.Border.Class = "TextBoxBorder";
            this.txt_TenNguoiDung.Enabled = false;
            this.txt_TenNguoiDung.Location = new System.Drawing.Point(126, 42);
            this.txt_TenNguoiDung.Name = "txt_TenNguoiDung";
            this.txt_TenNguoiDung.Size = new System.Drawing.Size(147, 20);
            this.txt_TenNguoiDung.TabIndex = 1;
            // 
            // labelX2
            // 
            this.labelX2.Location = new System.Drawing.Point(12, 41);
            this.labelX2.Name = "labelX2";
            this.labelX2.Size = new System.Drawing.Size(108, 23);
            this.labelX2.TabIndex = 1;
            this.labelX2.Text = "Tên người dùng";
            // 
            // txt_MatKhauMoi
            // 
            // 
            // 
            // 
            this.txt_MatKhauMoi.Border.Class = "TextBoxBorder";
            this.txt_MatKhauMoi.Location = new System.Drawing.Point(126, 71);
            this.txt_MatKhauMoi.Name = "txt_MatKhauMoi";
            this.txt_MatKhauMoi.Size = new System.Drawing.Size(147, 20);
            this.txt_MatKhauMoi.TabIndex = 2;
            this.txt_MatKhauMoi.UseSystemPasswordChar = true;
            // 
            // labelX3
            // 
            this.labelX3.Location = new System.Drawing.Point(12, 70);
            this.labelX3.Name = "labelX3";
            this.labelX3.Size = new System.Drawing.Size(108, 23);
            this.labelX3.TabIndex = 1;
            this.labelX3.Text = "Mật khẩu mới";
            // 
            // txt_XacNhanMatKhau
            // 
            // 
            // 
            // 
            this.txt_XacNhanMatKhau.Border.Class = "TextBoxBorder";
            this.txt_XacNhanMatKhau.Location = new System.Drawing.Point(126, 100);
            this.txt_XacNhanMatKhau.Name = "txt_XacNhanMatKhau";
            this.txt_XacNhanMatKhau.Size = new System.Drawing.Size(147, 20);
            this.txt_XacNhanMatKhau.TabIndex = 3;
            this.txt_XacNhanMatKhau.UseSystemPasswordChar = true;
            // 
            // labelX4
            // 
            this.labelX4.Location = new System.Drawing.Point(12, 99);
            this.labelX4.Name = "labelX4";
            this.labelX4.Size = new System.Drawing.Size(108, 23);
            this.labelX4.TabIndex = 1;
            this.labelX4.Text = "Xác nhận mật khẩu";
            // 
            // btn_ShowPass
            // 
            this.btn_ShowPass.BackColor = System.Drawing.SystemColors.Window;
            this.btn_ShowPass.FlatAppearance.BorderSize = 0;
            this.btn_ShowPass.FlatAppearance.MouseDownBackColor = System.Drawing.Color.White;
            this.btn_ShowPass.FlatAppearance.MouseOverBackColor = System.Drawing.Color.White;
            this.btn_ShowPass.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_ShowPass.Image = ((System.Drawing.Image)(resources.GetObject("btn_ShowPass.Image")));
            this.btn_ShowPass.Location = new System.Drawing.Point(243, 72);
            this.btn_ShowPass.Name = "btn_ShowPass";
            this.btn_ShowPass.Size = new System.Drawing.Size(28, 16);
            this.btn_ShowPass.TabIndex = 8;
            this.btn_ShowPass.UseVisualStyleBackColor = false;
            this.btn_ShowPass.Click += new System.EventHandler(this.btn_ShowPass_Click);
            // 
            // btn_ShowPass1
            // 
            this.btn_ShowPass1.BackColor = System.Drawing.SystemColors.Window;
            this.btn_ShowPass1.FlatAppearance.BorderSize = 0;
            this.btn_ShowPass1.FlatAppearance.MouseDownBackColor = System.Drawing.Color.White;
            this.btn_ShowPass1.FlatAppearance.MouseOverBackColor = System.Drawing.Color.White;
            this.btn_ShowPass1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_ShowPass1.Image = ((System.Drawing.Image)(resources.GetObject("btn_ShowPass1.Image")));
            this.btn_ShowPass1.Location = new System.Drawing.Point(243, 101);
            this.btn_ShowPass1.Name = "btn_ShowPass1";
            this.btn_ShowPass1.Size = new System.Drawing.Size(28, 16);
            this.btn_ShowPass1.TabIndex = 9;
            this.btn_ShowPass1.UseVisualStyleBackColor = false;
            this.btn_ShowPass1.Click += new System.EventHandler(this.btn_ShowPass_Click);
            // 
            // labelX5
            // 
            this.labelX5.ForeColor = System.Drawing.Color.DimGray;
            this.labelX5.Location = new System.Drawing.Point(12, 155);
            this.labelX5.Name = "labelX5";
            this.labelX5.Size = new System.Drawing.Size(261, 43);
            this.labelX5.TabIndex = 10;
            this.labelX5.Text = "Mật khẩu phải ít nhất 8 ký tự bao gồm chữ In Hoa + ký tự đăng biệt và số -- > VD " +
    ": Nhg12345*";
            this.labelX5.TextAlignment = System.Drawing.StringAlignment.Center;
            this.labelX5.WordWrap = true;
            // 
            // lb_Notifi
            // 
            this.lb_Notifi.ForeColor = System.Drawing.Color.Red;
            this.lb_Notifi.Location = new System.Drawing.Point(12, 126);
            this.lb_Notifi.Name = "lb_Notifi";
            this.lb_Notifi.Size = new System.Drawing.Size(180, 23);
            this.lb_Notifi.TabIndex = 11;
            this.lb_Notifi.Text = "labelX6";
            this.lb_Notifi.TextAlignment = System.Drawing.StringAlignment.Center;
            this.lb_Notifi.TextLineAlignment = System.Drawing.StringAlignment.Near;
            this.lb_Notifi.Visible = false;
            // 
            // btn_Save
            // 
            this.btn_Save.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.btn_Save.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            this.btn_Save.Image = ((System.Drawing.Image)(resources.GetObject("btn_Save.Image")));
            this.btn_Save.Location = new System.Drawing.Point(198, 123);
            this.btn_Save.Name = "btn_Save";
            this.btn_Save.Size = new System.Drawing.Size(75, 23);
            this.btn_Save.TabIndex = 12;
            this.btn_Save.Text = "Lưu";
            this.btn_Save.Click += new System.EventHandler(this.btn_Save_Click);
            // 
            // frm_ChangePassWord
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(285, 204);
            this.Controls.Add(this.btn_Save);
            this.Controls.Add(this.lb_Notifi);
            this.Controls.Add(this.labelX5);
            this.Controls.Add(this.btn_ShowPass1);
            this.Controls.Add(this.btn_ShowPass);
            this.Controls.Add(this.labelX4);
            this.Controls.Add(this.txt_XacNhanMatKhau);
            this.Controls.Add(this.labelX3);
            this.Controls.Add(this.txt_MatKhauMoi);
            this.Controls.Add(this.labelX2);
            this.Controls.Add(this.txt_TenNguoiDung);
            this.Controls.Add(this.labelX1);
            this.Controls.Add(this.txt_TenDangNhap);
            this.Name = "frm_ChangePassWord";
            this.Palette = this.kryptonPalette1;
            this.PaletteMode = ComponentFactory.Krypton.Toolkit.PaletteMode.Custom;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Thay đổi mật khẩu";
            this.Load += new System.EventHandler(this.frm_ChangePassWord_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private DevComponents.DotNetBar.Controls.TextBoxX txt_TenDangNhap;
        private DevComponents.DotNetBar.LabelX labelX1;
        private DevComponents.DotNetBar.Controls.TextBoxX txt_TenNguoiDung;
        private DevComponents.DotNetBar.LabelX labelX2;
        private DevComponents.DotNetBar.Controls.TextBoxX txt_MatKhauMoi;
        private DevComponents.DotNetBar.LabelX labelX3;
        private DevComponents.DotNetBar.Controls.TextBoxX txt_XacNhanMatKhau;
        private DevComponents.DotNetBar.LabelX labelX4;
        private System.Windows.Forms.Button btn_ShowPass;
        private System.Windows.Forms.Button btn_ShowPass1;
        private DevComponents.DotNetBar.LabelX labelX5;
        private DevComponents.DotNetBar.LabelX lb_Notifi;
        private DevComponents.DotNetBar.ButtonX btn_Save;
        private ComponentFactory.Krypton.Toolkit.KryptonPalette kryptonPalette1;
    }
}