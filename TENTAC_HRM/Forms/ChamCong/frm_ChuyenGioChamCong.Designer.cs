namespace TENTAC_HRM.Forms.ChamCong
{
    partial class frm_ChuyenGioChamCong
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frm_ChuyenGioChamCong));
            this.TenPhongBan = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.NgayCham = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cbo_Nam = new System.Windows.Forms.ComboBox();
            this.lbNam = new DevComponents.DotNetBar.LabelX();
            this.btn_Search = new DevComponents.DotNetBar.ButtonX();
            this.lbThang = new DevComponents.DotNetBar.LabelX();
            this.cbo_Thang = new System.Windows.Forms.ComboBox();
            this.TenNhanVien = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.MaNhanVien = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.lbTimMa = new DevComponents.DotNetBar.LabelX();
            this.Id = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.txt_Search = new DevComponents.DotNetBar.Controls.TextBoxX();
            this.GioCham = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.panel1 = new System.Windows.Forms.Panel();
            this.chk_col = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.dgv_Data = new DevComponents.DotNetBar.Controls.DataGridViewX();
            this.dataGridViewImageColumn1 = new System.Windows.Forms.DataGridViewImageColumn();
            this.btn_DeleteAll = new DevComponents.DotNetBar.ButtonX();
            this.delete_col = new System.Windows.Forms.DataGridViewImageColumn();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgv_Data)).BeginInit();
            this.SuspendLayout();
            // 
            // TenPhongBan
            // 
            this.TenPhongBan.DataPropertyName = "TenPhongBan";
            this.TenPhongBan.HeaderText = "Tên phòng ban";
            this.TenPhongBan.Name = "TenPhongBan";
            this.TenPhongBan.Width = 120;
            // 
            // NgayCham
            // 
            this.NgayCham.DataPropertyName = "NgayCham";
            this.NgayCham.HeaderText = "Ngày chấm";
            this.NgayCham.Name = "NgayCham";
            this.NgayCham.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.NgayCham.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.NgayCham.Width = 110;
            // 
            // cbo_Nam
            // 
            this.cbo_Nam.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbo_Nam.Font = new System.Drawing.Font("Arial", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbo_Nam.FormattingEnabled = true;
            this.cbo_Nam.Items.AddRange(new object[] {
            "2010",
            "2011",
            "2012",
            "2013",
            "2014",
            "2015",
            "2016",
            "2017",
            "2018",
            "2019",
            "2020",
            "2021",
            "2022",
            "2023",
            "2024"});
            this.cbo_Nam.Location = new System.Drawing.Point(53, 8);
            this.cbo_Nam.Name = "cbo_Nam";
            this.cbo_Nam.Size = new System.Drawing.Size(65, 24);
            this.cbo_Nam.TabIndex = 19;
            // 
            // lbNam
            // 
            this.lbNam.Font = new System.Drawing.Font("Arial", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbNam.Location = new System.Drawing.Point(7, 9);
            this.lbNam.Name = "lbNam";
            this.lbNam.Size = new System.Drawing.Size(56, 23);
            this.lbNam.TabIndex = 17;
            this.lbNam.Text = "Năm";
            // 
            // btn_Search
            // 
            this.btn_Search.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.btn_Search.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            this.btn_Search.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_Search.Location = new System.Drawing.Point(682, 10);
            this.btn_Search.Name = "btn_Search";
            this.btn_Search.Size = new System.Drawing.Size(106, 21);
            this.btn_Search.TabIndex = 15;
            this.btn_Search.Text = "Tìm kiếm";
            this.btn_Search.Click += new System.EventHandler(this.btn_Search_Click);
            // 
            // lbThang
            // 
            this.lbThang.Font = new System.Drawing.Font("Arial", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbThang.Location = new System.Drawing.Point(126, 9);
            this.lbThang.Name = "lbThang";
            this.lbThang.Size = new System.Drawing.Size(56, 23);
            this.lbThang.TabIndex = 16;
            this.lbThang.Text = "Tháng";
            // 
            // cbo_Thang
            // 
            this.cbo_Thang.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbo_Thang.Font = new System.Drawing.Font("Arial", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbo_Thang.FormattingEnabled = true;
            this.cbo_Thang.Items.AddRange(new object[] {
            "1",
            "2",
            "3",
            "4",
            "5",
            "6",
            "7",
            "8",
            "9",
            "10",
            "11",
            "12"});
            this.cbo_Thang.Location = new System.Drawing.Point(183, 8);
            this.cbo_Thang.Name = "cbo_Thang";
            this.cbo_Thang.Size = new System.Drawing.Size(54, 24);
            this.cbo_Thang.TabIndex = 18;
            // 
            // TenNhanVien
            // 
            this.TenNhanVien.DataPropertyName = "TenNhanVien";
            this.TenNhanVien.HeaderText = "Tên nhân viên";
            this.TenNhanVien.Name = "TenNhanVien";
            this.TenNhanVien.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.TenNhanVien.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.TenNhanVien.Width = 200;
            // 
            // MaNhanVien
            // 
            this.MaNhanVien.DataPropertyName = "MaNhanVien";
            this.MaNhanVien.HeaderText = "Mã nhân viên";
            this.MaNhanVien.Name = "MaNhanVien";
            this.MaNhanVien.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.MaNhanVien.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.MaNhanVien.Width = 95;
            // 
            // lbTimMa
            // 
            this.lbTimMa.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbTimMa.Location = new System.Drawing.Point(261, 9);
            this.lbTimMa.Name = "lbTimMa";
            this.lbTimMa.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.lbTimMa.Size = new System.Drawing.Size(64, 22);
            this.lbTimMa.TabIndex = 3;
            this.lbTimMa.Text = "Tìm kiếm";
            this.lbTimMa.TextAlignment = System.Drawing.StringAlignment.Far;
            // 
            // Id
            // 
            this.Id.DataPropertyName = "Id";
            this.Id.HeaderText = "Column1";
            this.Id.Name = "Id";
            this.Id.Visible = false;
            // 
            // txt_Search
            // 
            // 
            // 
            // 
            this.txt_Search.Border.Class = "TextBoxBorder";
            this.txt_Search.Location = new System.Drawing.Point(331, 10);
            this.txt_Search.Name = "txt_Search";
            this.txt_Search.Size = new System.Drawing.Size(210, 20);
            this.txt_Search.TabIndex = 1;
            this.txt_Search.WatermarkText = "Nhập mã hoặc tên nhân viên";
            this.txt_Search.TextChanged += new System.EventHandler(this.txt_Search_TextChanged);
            // 
            // GioCham
            // 
            this.GioCham.DataPropertyName = "GioCham";
            this.GioCham.HeaderText = "Giờ chấm";
            this.GioCham.Name = "GioCham";
            this.GioCham.Width = 120;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.cbo_Nam);
            this.panel1.Controls.Add(this.btn_DeleteAll);
            this.panel1.Controls.Add(this.lbNam);
            this.panel1.Controls.Add(this.btn_Search);
            this.panel1.Controls.Add(this.lbThang);
            this.panel1.Controls.Add(this.cbo_Thang);
            this.panel1.Controls.Add(this.lbTimMa);
            this.panel1.Controls.Add(this.txt_Search);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(800, 39);
            this.panel1.TabIndex = 2;
            // 
            // chk_col
            // 
            this.chk_col.HeaderText = "";
            this.chk_col.Name = "chk_col";
            this.chk_col.Width = 30;
            // 
            // dgv_Data
            // 
            this.dgv_Data.AllowUserToAddRows = false;
            this.dgv_Data.BackgroundColor = System.Drawing.Color.GhostWhite;
            this.dgv_Data.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgv_Data.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Id,
            this.chk_col,
            this.delete_col,
            this.MaNhanVien,
            this.TenNhanVien,
            this.NgayCham,
            this.GioCham,
            this.TenPhongBan});
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgv_Data.DefaultCellStyle = dataGridViewCellStyle2;
            this.dgv_Data.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgv_Data.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(215)))), ((int)(((byte)(229)))));
            this.dgv_Data.Location = new System.Drawing.Point(0, 39);
            this.dgv_Data.Name = "dgv_Data";
            this.dgv_Data.Size = new System.Drawing.Size(800, 411);
            this.dgv_Data.TabIndex = 3;
            this.dgv_Data.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgv_Data_CellClick);
            // 
            // dataGridViewImageColumn1
            // 
            this.dataGridViewImageColumn1.HeaderText = "Xóa";
            this.dataGridViewImageColumn1.Image = ((System.Drawing.Image)(resources.GetObject("dataGridViewImageColumn1.Image")));
            this.dataGridViewImageColumn1.Name = "dataGridViewImageColumn1";
            this.dataGridViewImageColumn1.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.dataGridViewImageColumn1.Width = 30;
            // 
            // btn_DeleteAll
            // 
            this.btn_DeleteAll.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.btn_DeleteAll.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            this.btn_DeleteAll.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_DeleteAll.Image = ((System.Drawing.Image)(resources.GetObject("btn_DeleteAll.Image")));
            this.btn_DeleteAll.Location = new System.Drawing.Point(570, 10);
            this.btn_DeleteAll.Name = "btn_DeleteAll";
            this.btn_DeleteAll.Size = new System.Drawing.Size(106, 21);
            this.btn_DeleteAll.TabIndex = 15;
            this.btn_DeleteAll.Text = "Xóa nhiều";
            this.btn_DeleteAll.Click += new System.EventHandler(this.btn_DeleteAll_Click);
            // 
            // delete_col
            // 
            this.delete_col.HeaderText = "Xóa";
            this.delete_col.Image = ((System.Drawing.Image)(resources.GetObject("delete_col.Image")));
            this.delete_col.Name = "delete_col";
            this.delete_col.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.delete_col.Width = 30;
            // 
            // frm_ChuyenGioChamCong
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.dgv_Data);
            this.Controls.Add(this.panel1);
            this.Name = "frm_ChuyenGioChamCong";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "frm_ChuyenGioChamCong";
            this.Load += new System.EventHandler(this.frm_ChuyenGioChamCong_Load);
            this.panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgv_Data)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridViewTextBoxColumn TenPhongBan;
        private System.Windows.Forms.DataGridViewTextBoxColumn NgayCham;
        private System.Windows.Forms.ComboBox cbo_Nam;
        private DevComponents.DotNetBar.ButtonX btn_DeleteAll;
        private DevComponents.DotNetBar.LabelX lbNam;
        private DevComponents.DotNetBar.ButtonX btn_Search;
        private DevComponents.DotNetBar.LabelX lbThang;
        private System.Windows.Forms.ComboBox cbo_Thang;
        private System.Windows.Forms.DataGridViewTextBoxColumn TenNhanVien;
        private System.Windows.Forms.DataGridViewTextBoxColumn MaNhanVien;
        private System.Windows.Forms.DataGridViewImageColumn delete_col;
        private DevComponents.DotNetBar.LabelX lbTimMa;
        private System.Windows.Forms.DataGridViewTextBoxColumn Id;
        private DevComponents.DotNetBar.Controls.TextBoxX txt_Search;
        private System.Windows.Forms.DataGridViewTextBoxColumn GioCham;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.DataGridViewCheckBoxColumn chk_col;
        private DevComponents.DotNetBar.Controls.DataGridViewX dgv_Data;
        private System.Windows.Forms.DataGridViewImageColumn dataGridViewImageColumn1;
    }
}