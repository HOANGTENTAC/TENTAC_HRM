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
            this.txt_textbody = new DevComponents.DotNetBar.Controls.TextBoxX();
            this.txt_subject = new DevComponents.DotNetBar.Controls.TextBoxX();
            this.txt_pass = new DevComponents.DotNetBar.Controls.TextBoxX();
            this.txt_emailtest = new DevComponents.DotNetBar.Controls.TextBoxX();
            this.txt_email = new DevComponents.DotNetBar.Controls.TextBoxX();
            this.lbTextBody = new DevComponents.DotNetBar.LabelX();
            this.lbSubject = new DevComponents.DotNetBar.LabelX();
            this.labelX1 = new DevComponents.DotNetBar.LabelX();
            this.lbPassword = new DevComponents.DotNetBar.LabelX();
            this.lbEmail = new DevComponents.DotNetBar.LabelX();
            this.btn_ExcelOutputPath = new System.Windows.Forms.Button();
            this.txt_PathExcel = new DevComponents.DotNetBar.Controls.TextBoxX();
            this.lblPathLoadExcel = new DevComponents.DotNetBar.LabelX();
            this.SuspendLayout();
            // 
            // btnUpdate
            // 
            this.btnUpdate.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.btnUpdate.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            this.btnUpdate.Image = ((System.Drawing.Image)(resources.GetObject("btnUpdate.Image")));
            this.btnUpdate.Location = new System.Drawing.Point(290, 328);
            this.btnUpdate.Name = "btnUpdate";
            this.btnUpdate.Size = new System.Drawing.Size(101, 23);
            this.btnUpdate.TabIndex = 15;
            this.btnUpdate.Text = "Cập nhật";
            this.btnUpdate.Click += new System.EventHandler(this.btnUpdate_Click);
            // 
            // txt_textbody
            // 
            // 
            // 
            // 
            this.txt_textbody.Border.Class = "TextBoxBorder";
            this.txt_textbody.Location = new System.Drawing.Point(116, 120);
            this.txt_textbody.Multiline = true;
            this.txt_textbody.Name = "txt_textbody";
            this.txt_textbody.Size = new System.Drawing.Size(275, 173);
            this.txt_textbody.TabIndex = 14;
            // 
            // txt_subject
            // 
            // 
            // 
            // 
            this.txt_subject.Border.Class = "TextBoxBorder";
            this.txt_subject.Location = new System.Drawing.Point(116, 94);
            this.txt_subject.Name = "txt_subject";
            this.txt_subject.Size = new System.Drawing.Size(275, 20);
            this.txt_subject.TabIndex = 13;
            // 
            // txt_pass
            // 
            // 
            // 
            // 
            this.txt_pass.Border.Class = "TextBoxBorder";
            this.txt_pass.Location = new System.Drawing.Point(116, 68);
            this.txt_pass.Name = "txt_pass";
            this.txt_pass.PasswordChar = '*';
            this.txt_pass.Size = new System.Drawing.Size(275, 20);
            this.txt_pass.TabIndex = 12;
            // 
            // txt_emailtest
            // 
            // 
            // 
            // 
            this.txt_emailtest.Border.Class = "TextBoxBorder";
            this.txt_emailtest.Location = new System.Drawing.Point(116, 42);
            this.txt_emailtest.Name = "txt_emailtest";
            this.txt_emailtest.Size = new System.Drawing.Size(275, 20);
            this.txt_emailtest.TabIndex = 5;
            // 
            // txt_email
            // 
            // 
            // 
            // 
            this.txt_email.Border.Class = "TextBoxBorder";
            this.txt_email.Location = new System.Drawing.Point(116, 16);
            this.txt_email.Name = "txt_email";
            this.txt_email.Size = new System.Drawing.Size(275, 20);
            this.txt_email.TabIndex = 6;
            // 
            // lbTextBody
            // 
            this.lbTextBody.Location = new System.Drawing.Point(12, 122);
            this.lbTextBody.Name = "lbTextBody";
            this.lbTextBody.Size = new System.Drawing.Size(101, 23);
            this.lbTextBody.TabIndex = 7;
            this.lbTextBody.Text = "Nội Dung Mail:";
            // 
            // lbSubject
            // 
            this.lbSubject.Location = new System.Drawing.Point(12, 93);
            this.lbSubject.Name = "lbSubject";
            this.lbSubject.Size = new System.Drawing.Size(101, 23);
            this.lbSubject.TabIndex = 8;
            this.lbSubject.Text = "Subject :";
            // 
            // labelX1
            // 
            this.labelX1.Location = new System.Drawing.Point(12, 41);
            this.labelX1.Name = "labelX1";
            this.labelX1.Size = new System.Drawing.Size(101, 23);
            this.labelX1.TabIndex = 9;
            this.labelX1.Text = "Email Nhận Test :";
            // 
            // lbPassword
            // 
            this.lbPassword.Location = new System.Drawing.Point(12, 67);
            this.lbPassword.Name = "lbPassword";
            this.lbPassword.Size = new System.Drawing.Size(98, 23);
            this.lbPassword.TabIndex = 10;
            this.lbPassword.Text = "Mật Khẩu App :";
            // 
            // lbEmail
            // 
            this.lbEmail.Location = new System.Drawing.Point(12, 15);
            this.lbEmail.Name = "lbEmail";
            this.lbEmail.Size = new System.Drawing.Size(101, 23);
            this.lbEmail.TabIndex = 11;
            this.lbEmail.Text = "Email Gửi :";
            // 
            // btn_ExcelOutputPath
            // 
            this.btn_ExcelOutputPath.Location = new System.Drawing.Point(352, 299);
            this.btn_ExcelOutputPath.Name = "btn_ExcelOutputPath";
            this.btn_ExcelOutputPath.Size = new System.Drawing.Size(39, 23);
            this.btn_ExcelOutputPath.TabIndex = 18;
            this.btn_ExcelOutputPath.Text = "...";
            this.btn_ExcelOutputPath.UseVisualStyleBackColor = true;
            this.btn_ExcelOutputPath.Click += new System.EventHandler(this.btn_ExcelOutputPath_Click);
            // 
            // txt_PathExcel
            // 
            // 
            // 
            // 
            this.txt_PathExcel.Border.Class = "TextBoxBorder";
            this.txt_PathExcel.Location = new System.Drawing.Point(116, 299);
            this.txt_PathExcel.Multiline = true;
            this.txt_PathExcel.Name = "txt_PathExcel";
            this.txt_PathExcel.Size = new System.Drawing.Size(230, 23);
            this.txt_PathExcel.TabIndex = 17;
            // 
            // lblPathLoadExcel
            // 
            this.lblPathLoadExcel.Location = new System.Drawing.Point(8, 297);
            this.lblPathLoadExcel.Name = "lblPathLoadExcel";
            this.lblPathLoadExcel.Size = new System.Drawing.Size(105, 27);
            this.lblPathLoadExcel.TabIndex = 16;
            this.lblPathLoadExcel.Text = "Thư Mục Excel:";
            this.lblPathLoadExcel.WordWrap = true;
            // 
            // frm_Setting
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(403, 360);
            this.Controls.Add(this.btn_ExcelOutputPath);
            this.Controls.Add(this.txt_PathExcel);
            this.Controls.Add(this.lblPathLoadExcel);
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

        }

        #endregion

        private DevComponents.DotNetBar.ButtonX btnUpdate;
        private DevComponents.DotNetBar.Controls.TextBoxX txt_textbody;
        private DevComponents.DotNetBar.Controls.TextBoxX txt_subject;
        private DevComponents.DotNetBar.Controls.TextBoxX txt_pass;
        private DevComponents.DotNetBar.Controls.TextBoxX txt_emailtest;
        private DevComponents.DotNetBar.Controls.TextBoxX txt_email;
        private DevComponents.DotNetBar.LabelX lbTextBody;
        private DevComponents.DotNetBar.LabelX lbSubject;
        private DevComponents.DotNetBar.LabelX labelX1;
        private DevComponents.DotNetBar.LabelX lbPassword;
        private DevComponents.DotNetBar.LabelX lbEmail;
        private System.Windows.Forms.Button btn_ExcelOutputPath;
        private DevComponents.DotNetBar.Controls.TextBoxX txt_PathExcel;
        private DevComponents.DotNetBar.LabelX lblPathLoadExcel;
    }
}