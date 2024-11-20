namespace TENTAC_HRM.Forms.ChamCong
{
    partial class frm_SuaGioTangCa
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
            this.lb_nhanvien = new System.Windows.Forms.Label();
            this.btn_update = new DevComponents.DotNetBar.ButtonX();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.dtp_giobatdau = new System.Windows.Forms.DateTimePicker();
            this.dtp_gioketthuc = new System.Windows.Forms.DateTimePicker();
            this.dtp_ngaytangca = new System.Windows.Forms.DateTimePicker();
            this.SuspendLayout();
            // 
            // lb_nhanvien
            // 
            this.lb_nhanvien.Dock = System.Windows.Forms.DockStyle.Top;
            this.lb_nhanvien.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.lb_nhanvien.ForeColor = System.Drawing.Color.Teal;
            this.lb_nhanvien.Location = new System.Drawing.Point(0, 0);
            this.lb_nhanvien.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lb_nhanvien.Name = "lb_nhanvien";
            this.lb_nhanvien.Size = new System.Drawing.Size(312, 32);
            this.lb_nhanvien.TabIndex = 44;
            this.lb_nhanvien.Text = "label4";
            this.lb_nhanvien.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // btn_update
            // 
            this.btn_update.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.btn_update.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            this.btn_update.Location = new System.Drawing.Point(31, 146);
            this.btn_update.Margin = new System.Windows.Forms.Padding(4);
            this.btn_update.Name = "btn_update";
            this.btn_update.Size = new System.Drawing.Size(251, 28);
            this.btn_update.TabIndex = 43;
            this.btn_update.Text = "Cập Nhật";
            this.btn_update.Click += new System.EventHandler(this.btn_update_Click);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(28, 120);
            this.label4.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(65, 13);
            this.label4.TabIndex = 40;
            this.label4.Text = "Giờ kết thúc";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(28, 88);
            this.label5.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(63, 13);
            this.label5.TabIndex = 41;
            this.label5.Text = "Giờ bắt đầu";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(28, 57);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(71, 13);
            this.label1.TabIndex = 42;
            this.label1.Text = "Ngày tăng ca";
            // 
            // dtp_giobatdau
            // 
            this.dtp_giobatdau.CustomFormat = "HH:mm:ss";
            this.dtp_giobatdau.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtp_giobatdau.Location = new System.Drawing.Point(130, 85);
            this.dtp_giobatdau.Margin = new System.Windows.Forms.Padding(4);
            this.dtp_giobatdau.Name = "dtp_giobatdau";
            this.dtp_giobatdau.ShowUpDown = true;
            this.dtp_giobatdau.Size = new System.Drawing.Size(152, 20);
            this.dtp_giobatdau.TabIndex = 37;
            // 
            // dtp_gioketthuc
            // 
            this.dtp_gioketthuc.CustomFormat = "HH:mm:ss";
            this.dtp_gioketthuc.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtp_gioketthuc.Location = new System.Drawing.Point(130, 115);
            this.dtp_gioketthuc.Margin = new System.Windows.Forms.Padding(4);
            this.dtp_gioketthuc.Name = "dtp_gioketthuc";
            this.dtp_gioketthuc.ShowUpDown = true;
            this.dtp_gioketthuc.Size = new System.Drawing.Size(152, 20);
            this.dtp_gioketthuc.TabIndex = 38;
            // 
            // dtp_ngaytangca
            // 
            this.dtp_ngaytangca.CustomFormat = "yyyy/MM/dd";
            this.dtp_ngaytangca.Enabled = false;
            this.dtp_ngaytangca.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtp_ngaytangca.Location = new System.Drawing.Point(130, 54);
            this.dtp_ngaytangca.Margin = new System.Windows.Forms.Padding(4);
            this.dtp_ngaytangca.Name = "dtp_ngaytangca";
            this.dtp_ngaytangca.Size = new System.Drawing.Size(152, 20);
            this.dtp_ngaytangca.TabIndex = 39;
            // 
            // frm_SuaGioTangCa
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(312, 181);
            this.Controls.Add(this.lb_nhanvien);
            this.Controls.Add(this.btn_update);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.dtp_giobatdau);
            this.Controls.Add(this.dtp_gioketthuc);
            this.Controls.Add(this.dtp_ngaytangca);
            this.Name = "frm_SuaGioTangCa";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "frm_SuaGioTangCa";
            this.Load += new System.EventHandler(this.frm_SuaGioTangCa_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lb_nhanvien;
        private DevComponents.DotNetBar.ButtonX btn_update;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DateTimePicker dtp_giobatdau;
        private System.Windows.Forms.DateTimePicker dtp_gioketthuc;
        private System.Windows.Forms.DateTimePicker dtp_ngaytangca;
    }
}