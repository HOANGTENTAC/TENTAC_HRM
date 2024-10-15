namespace TENTAC_HRM.Forms.Luong
{
    partial class frm_Setting
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frm_Setting));
            this.btnUpdate = new DevComponents.DotNetBar.ButtonX();
            this.txt_textbody = new System.Windows.Forms.TextBox();
            this.txt_subject = new System.Windows.Forms.TextBox();
            this.txt_pass = new System.Windows.Forms.TextBox();
            this.txt_emailtest = new System.Windows.Forms.TextBox();
            this.txt_email = new System.Windows.Forms.TextBox();
            this.lbTextBody = new DevComponents.DotNetBar.LabelX();
            this.lbSubject = new DevComponents.DotNetBar.LabelX();
            this.labelX1 = new DevComponents.DotNetBar.LabelX();
            this.lbPassword = new DevComponents.DotNetBar.LabelX();
            this.lbEmail = new DevComponents.DotNetBar.LabelX();
            this.SuspendLayout();
            // 
            // btnUpdate
            // 
            this.btnUpdate.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.btnUpdate.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            this.btnUpdate.Image = ((System.Drawing.Image)(resources.GetObject("btnUpdate.Image")));
            this.btnUpdate.Location = new System.Drawing.Point(290, 299);
            this.btnUpdate.Name = "btnUpdate";
            this.btnUpdate.Size = new System.Drawing.Size(101, 23);
            this.btnUpdate.TabIndex = 15;
            this.btnUpdate.Text = "Cập nhật";
            this.btnUpdate.Click += new System.EventHandler(this.btnUpdate_Click);
            // 
            // txt_textbody
            // 
            this.txt_textbody.Location = new System.Drawing.Point(93, 120);
            this.txt_textbody.Multiline = true;
            this.txt_textbody.Name = "txt_textbody";
            this.txt_textbody.Size = new System.Drawing.Size(298, 173);
            this.txt_textbody.TabIndex = 14;
            // 
            // txt_subject
            // 
            this.txt_subject.Location = new System.Drawing.Point(93, 94);
            this.txt_subject.Name = "txt_subject";
            this.txt_subject.Size = new System.Drawing.Size(298, 20);
            this.txt_subject.TabIndex = 13;
            // 
            // txt_pass
            // 
            this.txt_pass.Location = new System.Drawing.Point(93, 68);
            this.txt_pass.Name = "txt_pass";
            this.txt_pass.PasswordChar = '*';
            this.txt_pass.Size = new System.Drawing.Size(298, 20);
            this.txt_pass.TabIndex = 12;
            // 
            // txt_emailtest
            // 
            this.txt_emailtest.Location = new System.Drawing.Point(93, 42);
            this.txt_emailtest.Name = "txt_emailtest";
            this.txt_emailtest.Size = new System.Drawing.Size(298, 20);
            this.txt_emailtest.TabIndex = 5;
            // 
            // txt_email
            // 
            this.txt_email.Location = new System.Drawing.Point(93, 16);
            this.txt_email.Name = "txt_email";
            this.txt_email.Size = new System.Drawing.Size(298, 20);
            this.txt_email.TabIndex = 6;
            // 
            // lbTextBody
            // 
            this.lbTextBody.Location = new System.Drawing.Point(12, 117);
            this.lbTextBody.Name = "lbTextBody";
            this.lbTextBody.Size = new System.Drawing.Size(75, 23);
            this.lbTextBody.TabIndex = 7;
            this.lbTextBody.Text = "Nội dung :";
            // 
            // lbSubject
            // 
            this.lbSubject.Location = new System.Drawing.Point(12, 91);
            this.lbSubject.Name = "lbSubject";
            this.lbSubject.Size = new System.Drawing.Size(75, 23);
            this.lbSubject.TabIndex = 8;
            this.lbSubject.Text = "Subject :";
            // 
            // labelX1
            // 
            this.labelX1.Location = new System.Drawing.Point(12, 39);
            this.labelX1.Name = "labelX1";
            this.labelX1.Size = new System.Drawing.Size(75, 23);
            this.labelX1.TabIndex = 9;
            this.labelX1.Text = "Email Test :";
            // 
            // lbPassword
            // 
            this.lbPassword.Location = new System.Drawing.Point(12, 65);
            this.lbPassword.Name = "lbPassword";
            this.lbPassword.Size = new System.Drawing.Size(75, 23);
            this.lbPassword.TabIndex = 10;
            this.lbPassword.Text = "Mật khẩu :";
            // 
            // lbEmail
            // 
            this.lbEmail.Location = new System.Drawing.Point(12, 13);
            this.lbEmail.Name = "lbEmail";
            this.lbEmail.Size = new System.Drawing.Size(75, 23);
            this.lbEmail.TabIndex = 11;
            this.lbEmail.Text = "Email :";
            // 
            // frm_Setting
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(403, 334);
            this.Controls.Add(this.btnUpdate);
            this.Controls.Add(this.txt_textbody);
            this.Controls.Add(this.txt_subject);
            this.Controls.Add(this.txt_pass);
            this.Controls.Add(this.txt_emailtest);
            this.Controls.Add(this.txt_email);
            this.Controls.Add(this.lbTextBody);
            this.Controls.Add(this.lbSubject);
            this.Controls.Add(this.labelX1);
            this.Controls.Add(this.lbPassword);
            this.Controls.Add(this.lbEmail);
            this.Name = "frm_Setting";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Cài đặt";
            this.Load += new System.EventHandler(this.frm_Setting_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private DevComponents.DotNetBar.ButtonX btnUpdate;
        private System.Windows.Forms.TextBox txt_textbody;
        private System.Windows.Forms.TextBox txt_subject;
        private System.Windows.Forms.TextBox txt_pass;
        private System.Windows.Forms.TextBox txt_emailtest;
        private System.Windows.Forms.TextBox txt_email;
        private DevComponents.DotNetBar.LabelX lbTextBody;
        private DevComponents.DotNetBar.LabelX lbSubject;
        private DevComponents.DotNetBar.LabelX labelX1;
        private DevComponents.DotNetBar.LabelX lbPassword;
        private DevComponents.DotNetBar.LabelX lbEmail;
    }
}