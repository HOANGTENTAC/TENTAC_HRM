namespace TENTAC_HRM.Forms.Luong
{
    partial class frm_GuiBangLuongEmail
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frm_GuiBangLuongEmail));
            this.DGV_NhanVien = new DevComponents.DotNetBar.Controls.DataGridViewX();
            this.col_check = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.MaNhanVien = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.TenNhanVien = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.PhongBan = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Email = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.show_col = new System.Windows.Forms.DataGridViewImageColumn();
            this.send_col = new System.Windows.Forms.DataGridViewImageColumn();
            this.panel1 = new System.Windows.Forms.Panel();
            this.txt_noti = new System.Windows.Forms.TextBox();
            this.Lbl_Count = new System.Windows.Forms.Label();
            this.Btn_ImportExcel = new DevComponents.DotNetBar.ButtonX();
            this.btn_TestMail = new DevComponents.DotNetBar.ButtonX();
            this.Btn_Setting = new DevComponents.DotNetBar.ButtonX();
            this.Btn_SendMail = new DevComponents.DotNetBar.ButtonX();
            this.panel2 = new System.Windows.Forms.Panel();
            ((System.ComponentModel.ISupportInitialize)(this.DGV_NhanVien)).BeginInit();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // DGV_NhanVien
            // 
            this.DGV_NhanVien.AllowUserToAddRows = false;
            this.DGV_NhanVien.AllowUserToDeleteRows = false;
            this.DGV_NhanVien.BackgroundColor = System.Drawing.Color.GhostWhite;
            this.DGV_NhanVien.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.DGV_NhanVien.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.col_check,
            this.MaNhanVien,
            this.TenNhanVien,
            this.PhongBan,
            this.Email,
            this.show_col,
            this.send_col});
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.DGV_NhanVien.DefaultCellStyle = dataGridViewCellStyle1;
            this.DGV_NhanVien.Dock = System.Windows.Forms.DockStyle.Fill;
            this.DGV_NhanVien.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(215)))), ((int)(((byte)(229)))));
            this.DGV_NhanVien.Location = new System.Drawing.Point(0, 0);
            this.DGV_NhanVien.Name = "DGV_NhanVien";
            this.DGV_NhanVien.Size = new System.Drawing.Size(727, 581);
            this.DGV_NhanVien.TabIndex = 1;
            this.DGV_NhanVien.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.DGV_NhanVien_CellClick);
            // 
            // col_check
            // 
            this.col_check.DataPropertyName = "col_check";
            this.col_check.HeaderText = "";
            this.col_check.Name = "col_check";
            this.col_check.Width = 30;
            // 
            // MaNhanVien
            // 
            this.MaNhanVien.DataPropertyName = "MaNhanVien";
            this.MaNhanVien.HeaderText = "Mã Nhân Viên";
            this.MaNhanVien.Name = "MaNhanVien";
            // 
            // TenNhanVien
            // 
            this.TenNhanVien.DataPropertyName = "TenNhanVien";
            this.TenNhanVien.HeaderText = "Tên Nhân Viên";
            this.TenNhanVien.Name = "TenNhanVien";
            this.TenNhanVien.Width = 150;
            // 
            // PhongBan
            // 
            this.PhongBan.DataPropertyName = "PhongBan";
            this.PhongBan.HeaderText = "Phòng Ban";
            this.PhongBan.Name = "PhongBan";
            this.PhongBan.Width = 150;
            // 
            // Email
            // 
            this.Email.DataPropertyName = "Email";
            this.Email.HeaderText = "Email";
            this.Email.Name = "Email";
            this.Email.Width = 150;
            // 
            // show_col
            // 
            this.show_col.HeaderText = "";
            this.show_col.Name = "show_col";
            this.show_col.Width = 24;
            // 
            // send_col
            // 
            this.send_col.HeaderText = "";
            this.send_col.Name = "send_col";
            this.send_col.Width = 24;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.txt_noti);
            this.panel1.Controls.Add(this.Lbl_Count);
            this.panel1.Controls.Add(this.Btn_ImportExcel);
            this.panel1.Controls.Add(this.btn_TestMail);
            this.panel1.Controls.Add(this.Btn_Setting);
            this.panel1.Controls.Add(this.Btn_SendMail);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel1.Location = new System.Drawing.Point(0, 507);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(727, 74);
            this.panel1.TabIndex = 3;
            // 
            // txt_noti
            // 
            this.txt_noti.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txt_noti.Location = new System.Drawing.Point(0, 0);
            this.txt_noti.Multiline = true;
            this.txt_noti.Name = "txt_noti";
            this.txt_noti.Size = new System.Drawing.Size(538, 69);
            this.txt_noti.TabIndex = 3;
            // 
            // Lbl_Count
            // 
            this.Lbl_Count.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.Lbl_Count.BackColor = System.Drawing.Color.Transparent;
            this.Lbl_Count.Location = new System.Drawing.Point(544, 2);
            this.Lbl_Count.Name = "Lbl_Count";
            this.Lbl_Count.Size = new System.Drawing.Size(183, 13);
            this.Lbl_Count.TabIndex = 2;
            this.Lbl_Count.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // Btn_ImportExcel
            // 
            this.Btn_ImportExcel.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.Btn_ImportExcel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.Btn_ImportExcel.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            this.Btn_ImportExcel.Image = ((System.Drawing.Image)(resources.GetObject("Btn_ImportExcel.Image")));
            this.Btn_ImportExcel.Location = new System.Drawing.Point(637, 17);
            this.Btn_ImportExcel.Name = "Btn_ImportExcel";
            this.Btn_ImportExcel.Size = new System.Drawing.Size(87, 23);
            this.Btn_ImportExcel.TabIndex = 1;
            this.Btn_ImportExcel.Text = "Load Excel";
            this.Btn_ImportExcel.Click += new System.EventHandler(this.Btn_ImportExcel_Click);
            // 
            // btn_TestMail
            // 
            this.btn_TestMail.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.btn_TestMail.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btn_TestMail.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            this.btn_TestMail.Image = ((System.Drawing.Image)(resources.GetObject("btn_TestMail.Image")));
            this.btn_TestMail.Location = new System.Drawing.Point(637, 46);
            this.btn_TestMail.Name = "btn_TestMail";
            this.btn_TestMail.Size = new System.Drawing.Size(87, 23);
            this.btn_TestMail.TabIndex = 1;
            this.btn_TestMail.Text = "Thử Mail";
            this.btn_TestMail.Click += new System.EventHandler(this.btn_TestMail_Click);
            // 
            // Btn_Setting
            // 
            this.Btn_Setting.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.Btn_Setting.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.Btn_Setting.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            this.Btn_Setting.Image = ((System.Drawing.Image)(resources.GetObject("Btn_Setting.Image")));
            this.Btn_Setting.Location = new System.Drawing.Point(544, 17);
            this.Btn_Setting.Name = "Btn_Setting";
            this.Btn_Setting.Size = new System.Drawing.Size(87, 23);
            this.Btn_Setting.TabIndex = 1;
            this.Btn_Setting.Text = "Cài đặt";
            this.Btn_Setting.Click += new System.EventHandler(this.Btn_Setting_Click);
            // 
            // Btn_SendMail
            // 
            this.Btn_SendMail.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.Btn_SendMail.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.Btn_SendMail.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            this.Btn_SendMail.Image = ((System.Drawing.Image)(resources.GetObject("Btn_SendMail.Image")));
            this.Btn_SendMail.Location = new System.Drawing.Point(544, 46);
            this.Btn_SendMail.Name = "Btn_SendMail";
            this.Btn_SendMail.Size = new System.Drawing.Size(87, 23);
            this.Btn_SendMail.TabIndex = 1;
            this.Btn_SendMail.Text = "Gửi mail";
            this.Btn_SendMail.Click += new System.EventHandler(this.Btn_SendMail_Click);
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.DGV_NhanVien);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel2.Location = new System.Drawing.Point(0, 0);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(727, 581);
            this.panel2.TabIndex = 4;
            // 
            // frm_GuiBangLuongEmail
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(727, 581);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.panel2);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "frm_GuiBangLuongEmail";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Kyuyo Meisai- 給与明細書";
            this.Load += new System.EventHandler(this.frm_GuiBangLuongEmail_Load);
            ((System.ComponentModel.ISupportInitialize)(this.DGV_NhanVien)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private DevComponents.DotNetBar.Controls.DataGridViewX DGV_NhanVien;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.TextBox txt_noti;
        private System.Windows.Forms.Label Lbl_Count;
        private DevComponents.DotNetBar.ButtonX Btn_ImportExcel;
        private DevComponents.DotNetBar.ButtonX btn_TestMail;
        private DevComponents.DotNetBar.ButtonX Btn_Setting;
        private DevComponents.DotNetBar.ButtonX Btn_SendMail;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.DataGridViewCheckBoxColumn col_check;
        private System.Windows.Forms.DataGridViewTextBoxColumn MaNhanVien;
        private System.Windows.Forms.DataGridViewTextBoxColumn TenNhanVien;
        private System.Windows.Forms.DataGridViewTextBoxColumn PhongBan;
        private System.Windows.Forms.DataGridViewTextBoxColumn Email;
        private System.Windows.Forms.DataGridViewImageColumn show_col;
        private System.Windows.Forms.DataGridViewImageColumn send_col;
    }
}