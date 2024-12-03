namespace TENTAC_HRM.Forms.Main
{
    partial class frm_login
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frm_login));
            this.panel2 = new System.Windows.Forms.Panel();
            this.btn_exit = new System.Windows.Forms.PictureBox();
            this.labelX3 = new DevComponents.DotNetBar.LabelX();
            this.labelX2 = new DevComponents.DotNetBar.LabelX();
            this.labelX1 = new DevComponents.DotNetBar.LabelX();
            this.linkLabel1 = new System.Windows.Forms.LinkLabel();
            this.btn_close = new FontAwesome.Sharp.IconButton();
            this.lb_error = new System.Windows.Forms.Label();
            this.btn_show_pass = new System.Windows.Forms.Button();
            this.txt_user = new RJTextBox.RJTextBox();
            this.chk_remember_me = new System.Windows.Forms.CheckBox();
            this.btn_login = new TENTAC_HRM.Custom.RJButton();
            this.txt_password = new TENTAC_HRM.Custom.RJTextBox();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.btn_exit)).BeginInit();
            this.SuspendLayout();
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.White;
            this.panel2.Controls.Add(this.btn_exit);
            this.panel2.Controls.Add(this.labelX3);
            this.panel2.Controls.Add(this.labelX2);
            this.panel2.Controls.Add(this.labelX1);
            this.panel2.Controls.Add(this.linkLabel1);
            this.panel2.Controls.Add(this.btn_close);
            this.panel2.Controls.Add(this.lb_error);
            this.panel2.Controls.Add(this.btn_show_pass);
            this.panel2.Controls.Add(this.txt_user);
            this.panel2.Controls.Add(this.btn_login);
            this.panel2.Controls.Add(this.chk_remember_me);
            this.panel2.Controls.Add(this.txt_password);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel2.Location = new System.Drawing.Point(0, 0);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(356, 290);
            this.panel2.TabIndex = 1;
            // 
            // btn_exit
            // 
            this.btn_exit.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(68)))), ((int)(((byte)(113)))), ((int)(((byte)(249)))));
            this.btn_exit.Image = global::TENTAC_HRM.Properties.Resources.closeForm;
            this.btn_exit.Location = new System.Drawing.Point(318, 4);
            this.btn_exit.Name = "btn_exit";
            this.btn_exit.Size = new System.Drawing.Size(35, 34);
            this.btn_exit.TabIndex = 59;
            this.btn_exit.TabStop = false;
            this.btn_exit.Click += new System.EventHandler(this.btn_exit_Click);
            // 
            // labelX3
            // 
            this.labelX3.ForeColor = System.Drawing.SystemColors.WindowFrame;
            this.labelX3.Location = new System.Drawing.Point(32, 130);
            this.labelX3.Name = "labelX3";
            this.labelX3.Size = new System.Drawing.Size(79, 23);
            this.labelX3.TabIndex = 58;
            this.labelX3.Text = "Mật khẩu";
            // 
            // labelX2
            // 
            this.labelX2.ForeColor = System.Drawing.SystemColors.WindowFrame;
            this.labelX2.Location = new System.Drawing.Point(32, 62);
            this.labelX2.Name = "labelX2";
            this.labelX2.Size = new System.Drawing.Size(99, 23);
            this.labelX2.TabIndex = 57;
            this.labelX2.Text = "Tên đăng nhập";
            // 
            // labelX1
            // 
            this.labelX1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(68)))), ((int)(((byte)(113)))), ((int)(((byte)(249)))));
            this.labelX1.Dock = System.Windows.Forms.DockStyle.Top;
            this.labelX1.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelX1.ForeColor = System.Drawing.Color.WhiteSmoke;
            this.labelX1.Location = new System.Drawing.Point(0, 0);
            this.labelX1.Name = "labelX1";
            this.labelX1.Size = new System.Drawing.Size(356, 44);
            this.labelX1.TabIndex = 56;
            this.labelX1.Text = "Tài Khoản";
            this.labelX1.TextAlignment = System.Drawing.StringAlignment.Center;
            // 
            // linkLabel1
            // 
            this.linkLabel1.LinkBehavior = System.Windows.Forms.LinkBehavior.HoverUnderline;
            this.linkLabel1.Location = new System.Drawing.Point(191, 191);
            this.linkLabel1.Name = "linkLabel1";
            this.linkLabel1.Size = new System.Drawing.Size(134, 25);
            this.linkLabel1.TabIndex = 10;
            this.linkLabel1.TabStop = true;
            this.linkLabel1.Text = "Quên mật khẩu?";
            this.linkLabel1.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // btn_close
            // 
            this.btn_close.FlatAppearance.BorderSize = 0;
            this.btn_close.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_close.IconChar = FontAwesome.Sharp.IconChar.Xmark;
            this.btn_close.IconColor = System.Drawing.Color.Black;
            this.btn_close.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.btn_close.IconSize = 20;
            this.btn_close.Location = new System.Drawing.Point(440, 0);
            this.btn_close.Name = "btn_close";
            this.btn_close.Size = new System.Drawing.Size(25, 23);
            this.btn_close.TabIndex = 9;
            this.btn_close.UseVisualStyleBackColor = true;
            this.btn_close.Click += new System.EventHandler(this.btn_close_Click);
            // 
            // lb_error
            // 
            this.lb_error.ForeColor = System.Drawing.Color.Red;
            this.lb_error.Location = new System.Drawing.Point(22, 266);
            this.lb_error.Name = "lb_error";
            this.lb_error.Size = new System.Drawing.Size(313, 21);
            this.lb_error.TabIndex = 8;
            this.lb_error.Text = "Tên đăng nhập hoặc mật khẩu không chính xác";
            this.lb_error.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lb_error.Visible = false;
            // 
            // btn_show_pass
            // 
            this.btn_show_pass.BackColor = System.Drawing.SystemColors.Window;
            this.btn_show_pass.FlatAppearance.BorderSize = 0;
            this.btn_show_pass.FlatAppearance.MouseDownBackColor = System.Drawing.Color.White;
            this.btn_show_pass.FlatAppearance.MouseOverBackColor = System.Drawing.Color.White;
            this.btn_show_pass.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_show_pass.Image = ((System.Drawing.Image)(resources.GetObject("btn_show_pass.Image")));
            this.btn_show_pass.Location = new System.Drawing.Point(289, 159);
            this.btn_show_pass.Name = "btn_show_pass";
            this.btn_show_pass.Size = new System.Drawing.Size(28, 25);
            this.btn_show_pass.TabIndex = 7;
            this.btn_show_pass.UseVisualStyleBackColor = false;
            this.btn_show_pass.Click += new System.EventHandler(this.btn_show_pass_Click);
            // 
            // txt_user
            // 
            this.txt_user.BackColor = System.Drawing.SystemColors.Window;
            this.txt_user.BorderColor = System.Drawing.Color.DeepSkyBlue;
            this.txt_user.BorderFocusColor = System.Drawing.Color.Blue;
            this.txt_user.BorderRadius = 10;
            this.txt_user.BorderSize = 1;
            this.txt_user.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txt_user.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.txt_user.Location = new System.Drawing.Point(32, 92);
            this.txt_user.Margin = new System.Windows.Forms.Padding(4);
            this.txt_user.Multiline = false;
            this.txt_user.Name = "txt_user";
            this.txt_user.Padding = new System.Windows.Forms.Padding(10, 7, 10, 7);
            this.txt_user.PasswordChar = false;
            this.txt_user.PlaceholderColor = System.Drawing.Color.DarkGray;
            this.txt_user.PlaceholderText = "";
            this.txt_user.Size = new System.Drawing.Size(294, 31);
            this.txt_user.TabIndex = 0;
            this.txt_user.Texts = "";
            this.txt_user.UnderlinedStyle = false;
            this.txt_user._TextChanged += new System.EventHandler(this.txtUser_TextChanged);
            this.txt_user.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txt_user_KeyPress);
            // 
            // chk_remember_me
            // 
            this.chk_remember_me.AutoSize = true;
            this.chk_remember_me.ForeColor = System.Drawing.SystemColors.WindowFrame;
            this.chk_remember_me.Location = new System.Drawing.Point(33, 195);
            this.chk_remember_me.Name = "chk_remember_me";
            this.chk_remember_me.Size = new System.Drawing.Size(115, 21);
            this.chk_remember_me.TabIndex = 2;
            this.chk_remember_me.Text = "Nhớ mật khẩu";
            this.chk_remember_me.UseVisualStyleBackColor = true;
            // 
            // btn_login
            // 
            this.btn_login.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(68)))), ((int)(((byte)(113)))), ((int)(((byte)(249)))));
            this.btn_login.BackGroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(68)))), ((int)(((byte)(113)))), ((int)(((byte)(249)))));
            this.btn_login.BorderColor = System.Drawing.Color.PaleVioletRed;
            this.btn_login.BorderRadius = 20;
            this.btn_login.BorderSize = 0;
            this.btn_login.FlatAppearance.BorderSize = 0;
            this.btn_login.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_login.ForeColor = System.Drawing.Color.White;
            this.btn_login.Location = new System.Drawing.Point(32, 219);
            this.btn_login.Name = "btn_login";
            this.btn_login.Size = new System.Drawing.Size(293, 44);
            this.btn_login.TabIndex = 4;
            this.btn_login.Text = "Đăng nhập";
            this.btn_login.TextColor = System.Drawing.Color.White;
            this.btn_login.UseVisualStyleBackColor = false;
            this.btn_login.Click += new System.EventHandler(this.btn_login_Click);
            // 
            // txt_password
            // 
            this.txt_password.BackColor = System.Drawing.SystemColors.Window;
            this.txt_password.BorderColor = System.Drawing.Color.DeepSkyBlue;
            this.txt_password.BorderFocusColor = System.Drawing.Color.Blue;
            this.txt_password.BorderRadius = 10;
            this.txt_password.BorderSize = 1;
            this.txt_password.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txt_password.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.txt_password.Location = new System.Drawing.Point(32, 157);
            this.txt_password.Margin = new System.Windows.Forms.Padding(4);
            this.txt_password.Multiline = false;
            this.txt_password.Name = "txt_password";
            this.txt_password.Padding = new System.Windows.Forms.Padding(10, 7, 10, 7);
            this.txt_password.PasswordChar = true;
            this.txt_password.PlaceholderColor = System.Drawing.Color.DarkGray;
            this.txt_password.PlaceholderText = "";
            this.txt_password.Size = new System.Drawing.Size(293, 31);
            this.txt_password.TabIndex = 1;
            this.txt_password.Texts = "";
            this.txt_password.UnderlinedStyle = false;
            this.txt_password.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txt_password_KeyPress);
            // 
            // frm_login
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(356, 290);
            this.Controls.Add(this.panel2);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Margin = new System.Windows.Forms.Padding(4);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frm_login";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.btn_exit)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.CheckBox chk_remember_me;
        private Custom.RJButton btn_login;
        private RJTextBox.RJTextBox txt_user;
        private System.Windows.Forms.Button btn_show_pass;
        private System.Windows.Forms.Label lb_error;
        private Custom.RJTextBox txt_password;
        private FontAwesome.Sharp.IconButton btn_close;
        private System.Windows.Forms.LinkLabel linkLabel1;
        private DevComponents.DotNetBar.LabelX labelX3;
        private DevComponents.DotNetBar.LabelX labelX2;
        private DevComponents.DotNetBar.LabelX labelX1;
        private System.Windows.Forms.PictureBox btn_exit;
    }
}