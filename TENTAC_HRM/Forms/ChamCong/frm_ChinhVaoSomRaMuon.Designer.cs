namespace TENTAC_HRM.Forms.ChamCong
{
    partial class frm_ChinhVaoSomRaMuon
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle6 = new System.Windows.Forms.DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frm_ChinhVaoSomRaMuon));
            this.TenPhongBan = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.TenMay = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.GioCham = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.NgayCham = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.TenNhanVien = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.MaChamCong = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.chk_col = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.Id = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dgv_Data = new DevComponents.DotNetBar.Controls.DataGridViewX();
            this.Ca = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.panel2 = new System.Windows.Forms.Panel();
            this.labelX2 = new DevComponents.DotNetBar.LabelX();
            this.labelX1 = new DevComponents.DotNetBar.LabelX();
            this.cbo_Nam = new DevComponents.DotNetBar.Controls.ComboBoxEx();
            this.cbo_Thang = new DevComponents.DotNetBar.Controls.ComboBoxEx();
            this.panel1 = new System.Windows.Forms.Panel();
            this.btn_Save = new DevComponents.DotNetBar.ButtonX();
            this.btn_Load = new DevComponents.DotNetBar.ButtonX();
            ((System.ComponentModel.ISupportInitialize)(this.dgv_Data)).BeginInit();
            this.panel2.SuspendLayout();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // TenPhongBan
            // 
            this.TenPhongBan.DataPropertyName = "TenPhongBan";
            this.TenPhongBan.HeaderText = "Phòng Ban";
            this.TenPhongBan.Name = "TenPhongBan";
            // 
            // TenMay
            // 
            this.TenMay.DataPropertyName = "TenMay";
            this.TenMay.HeaderText = "Tên Máy";
            this.TenMay.Name = "TenMay";
            // 
            // GioCham
            // 
            this.GioCham.DataPropertyName = "GioCham";
            this.GioCham.HeaderText = "Giờ Chấm";
            this.GioCham.Name = "GioCham";
            // 
            // NgayCham
            // 
            this.NgayCham.DataPropertyName = "NgayCham";
            this.NgayCham.HeaderText = "Ngày Chấm";
            this.NgayCham.Name = "NgayCham";
            // 
            // TenNhanVien
            // 
            this.TenNhanVien.DataPropertyName = "TenNhanVien";
            this.TenNhanVien.HeaderText = "Tên Nhân Viên";
            this.TenNhanVien.Name = "TenNhanVien";
            this.TenNhanVien.Width = 150;
            // 
            // MaChamCong
            // 
            this.MaChamCong.DataPropertyName = "MaChamCong";
            this.MaChamCong.HeaderText = "Máy CC";
            this.MaChamCong.Name = "MaChamCong";
            // 
            // chk_col
            // 
            this.chk_col.HeaderText = "";
            this.chk_col.Name = "chk_col";
            this.chk_col.Width = 30;
            // 
            // Id
            // 
            this.Id.DataPropertyName = "Id";
            this.Id.HeaderText = "Id";
            this.Id.Name = "Id";
            this.Id.Visible = false;
            // 
            // dgv_Data
            // 
            this.dgv_Data.AllowUserToAddRows = false;
            this.dgv_Data.BackgroundColor = System.Drawing.Color.GhostWhite;
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle4.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle4.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            dataGridViewCellStyle4.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle4.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle4.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle4.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgv_Data.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle4;
            this.dgv_Data.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgv_Data.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Id,
            this.chk_col,
            this.MaChamCong,
            this.TenNhanVien,
            this.NgayCham,
            this.GioCham,
            this.TenMay,
            this.Ca,
            this.TenPhongBan});
            dataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle5.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle5.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            dataGridViewCellStyle5.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle5.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle5.SelectionForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle5.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgv_Data.DefaultCellStyle = dataGridViewCellStyle5;
            this.dgv_Data.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgv_Data.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(215)))), ((int)(((byte)(229)))));
            this.dgv_Data.Location = new System.Drawing.Point(0, 0);
            this.dgv_Data.Name = "dgv_Data";
            dataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle6.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle6.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            dataGridViewCellStyle6.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle6.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle6.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle6.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgv_Data.RowHeadersDefaultCellStyle = dataGridViewCellStyle6;
            this.dgv_Data.Size = new System.Drawing.Size(805, 458);
            this.dgv_Data.TabIndex = 0;
            this.dgv_Data.RowPostPaint += new System.Windows.Forms.DataGridViewRowPostPaintEventHandler(this.dgv_Data_RowPostPaint);
            // 
            // Ca
            // 
            this.Ca.DataPropertyName = "Ca";
            this.Ca.HeaderText = "Ca";
            this.Ca.Name = "Ca";
            this.Ca.Width = 60;
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.dgv_Data);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel2.Location = new System.Drawing.Point(0, 38);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(805, 458);
            this.panel2.TabIndex = 3;
            // 
            // labelX2
            // 
            this.labelX2.Location = new System.Drawing.Point(157, 9);
            this.labelX2.Name = "labelX2";
            this.labelX2.Size = new System.Drawing.Size(33, 23);
            this.labelX2.TabIndex = 2;
            this.labelX2.Text = "Năm";
            // 
            // labelX1
            // 
            this.labelX1.Location = new System.Drawing.Point(12, 9);
            this.labelX1.Name = "labelX1";
            this.labelX1.Size = new System.Drawing.Size(38, 23);
            this.labelX1.TabIndex = 2;
            this.labelX1.Text = "Tháng";
            // 
            // cbo_Nam
            // 
            this.cbo_Nam.DisplayMember = "Text";
            this.cbo_Nam.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.cbo_Nam.FormattingEnabled = true;
            this.cbo_Nam.ItemHeight = 14;
            this.cbo_Nam.Location = new System.Drawing.Point(196, 10);
            this.cbo_Nam.Name = "cbo_Nam";
            this.cbo_Nam.Size = new System.Drawing.Size(87, 20);
            this.cbo_Nam.TabIndex = 1;
            // 
            // cbo_Thang
            // 
            this.cbo_Thang.DisplayMember = "Text";
            this.cbo_Thang.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.cbo_Thang.FormattingEnabled = true;
            this.cbo_Thang.ItemHeight = 14;
            this.cbo_Thang.Location = new System.Drawing.Point(56, 10);
            this.cbo_Thang.Name = "cbo_Thang";
            this.cbo_Thang.Size = new System.Drawing.Size(79, 20);
            this.cbo_Thang.TabIndex = 1;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.labelX2);
            this.panel1.Controls.Add(this.labelX1);
            this.panel1.Controls.Add(this.cbo_Nam);
            this.panel1.Controls.Add(this.cbo_Thang);
            this.panel1.Controls.Add(this.btn_Save);
            this.panel1.Controls.Add(this.btn_Load);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(805, 38);
            this.panel1.TabIndex = 2;
            // 
            // btn_Save
            // 
            this.btn_Save.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.btn_Save.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btn_Save.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            this.btn_Save.Image = ((System.Drawing.Image)(resources.GetObject("btn_Save.Image")));
            this.btn_Save.Location = new System.Drawing.Point(567, 9);
            this.btn_Save.Name = "btn_Save";
            this.btn_Save.Size = new System.Drawing.Size(110, 23);
            this.btn_Save.TabIndex = 0;
            this.btn_Save.Text = "Cập Nhật";
            this.btn_Save.Click += new System.EventHandler(this.btn_Save_Click);
            // 
            // btn_Load
            // 
            this.btn_Load.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.btn_Load.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btn_Load.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            this.btn_Load.Image = ((System.Drawing.Image)(resources.GetObject("btn_Load.Image")));
            this.btn_Load.Location = new System.Drawing.Point(683, 9);
            this.btn_Load.Name = "btn_Load";
            this.btn_Load.Size = new System.Drawing.Size(110, 23);
            this.btn_Load.TabIndex = 0;
            this.btn_Load.Text = "Load Data";
            this.btn_Load.Click += new System.EventHandler(this.btn_Load_Click);
            // 
            // frm_ChinhVaoSomRaMuon
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(805, 496);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.Name = "frm_ChinhVaoSomRaMuon";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Chỉnh vào muộn ra sớm";
            this.Load += new System.EventHandler(this.frm_ChinhVaoSomRaMuon_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgv_Data)).EndInit();
            this.panel2.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridViewTextBoxColumn TenPhongBan;
        private System.Windows.Forms.DataGridViewTextBoxColumn TenMay;
        private System.Windows.Forms.DataGridViewTextBoxColumn GioCham;
        private System.Windows.Forms.DataGridViewTextBoxColumn NgayCham;
        private System.Windows.Forms.DataGridViewTextBoxColumn TenNhanVien;
        private System.Windows.Forms.DataGridViewTextBoxColumn MaChamCong;
        private System.Windows.Forms.DataGridViewCheckBoxColumn chk_col;
        private System.Windows.Forms.DataGridViewTextBoxColumn Id;
        private DevComponents.DotNetBar.Controls.DataGridViewX dgv_Data;
        private System.Windows.Forms.DataGridViewTextBoxColumn Ca;
        private System.Windows.Forms.Panel panel2;
        private DevComponents.DotNetBar.LabelX labelX2;
        private DevComponents.DotNetBar.LabelX labelX1;
        private DevComponents.DotNetBar.Controls.ComboBoxEx cbo_Nam;
        private DevComponents.DotNetBar.Controls.ComboBoxEx cbo_Thang;
        private DevComponents.DotNetBar.ButtonX btn_Save;
        private DevComponents.DotNetBar.ButtonX btn_Load;
        private System.Windows.Forms.Panel panel1;
    }
}