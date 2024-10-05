namespace TENTAC_HRM.User_control
{
    partial class uc_nhansu_hopdong
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(uc_nhansu_hopdong));
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.toolStripLabel1 = new System.Windows.Forms.ToolStripLabel();
            this.cbo_loai_hopdong = new System.Windows.Forms.ToolStripComboBox();
            this.btn_saerch = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.btn_add = new System.Windows.Forms.ToolStripButton();
            this.btn_edit = new System.Windows.Forms.ToolStripButton();
            this.btn_delete = new System.Windows.Forms.ToolStripButton();
            this.btn_refresh = new System.Windows.Forms.ToolStripButton();
            this.btn_close = new System.Windows.Forms.ToolStripButton();
            this.panel1 = new System.Windows.Forms.Panel();
            this.pnlDieuHuong = new System.Windows.Forms.Panel();
            this.panel3 = new System.Windows.Forms.Panel();
            this.lb_totalsize = new System.Windows.Forms.Label();
            this.dgv_nhanvien_hopdong = new System.Windows.Forms.DataGridView();
            this.id_hop_dong = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.id_nhan_vien = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.edit_column = new System.Windows.Forms.DataGridViewImageColumn();
            this.rownumber = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ma_nhan_vien = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.so_hop_dong = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ho_lot = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ten = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.loai_hop_dong = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.thoi_gian = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ngay_ky = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.tu_ngay = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.den_ngay = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.nguoi_ky = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ghi_chu = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.id_loai_hop_dong = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.toolStrip1.SuspendLayout();
            this.panel1.SuspendLayout();
            this.panel3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgv_nhanvien_hopdong)).BeginInit();
            this.SuspendLayout();
            // 
            // toolStrip1
            // 
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripLabel1,
            this.cbo_loai_hopdong,
            this.btn_saerch,
            this.toolStripSeparator1,
            this.btn_add,
            this.btn_edit,
            this.btn_delete,
            this.btn_refresh,
            this.btn_close});
            this.toolStrip1.Location = new System.Drawing.Point(0, 0);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(997, 25);
            this.toolStrip1.TabIndex = 1;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // toolStripLabel1
            // 
            this.toolStripLabel1.Name = "toolStripLabel1";
            this.toolStripLabel1.Size = new System.Drawing.Size(95, 22);
            this.toolStripLabel1.Text = "Lọc dữ liệu theo:";
            // 
            // cbo_loai_hopdong
            // 
            this.cbo_loai_hopdong.Name = "cbo_loai_hopdong";
            this.cbo_loai_hopdong.Size = new System.Drawing.Size(240, 25);
            // 
            // btn_saerch
            // 
            this.btn_saerch.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.btn_saerch.Image = global::TENTAC_HRM.Properties.Resources.binoculars;
            this.btn_saerch.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btn_saerch.Name = "btn_saerch";
            this.btn_saerch.Size = new System.Drawing.Size(23, 22);
            this.btn_saerch.Text = "toolStripButton1";
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(6, 25);
            // 
            // btn_add
            // 
            this.btn_add.Image = global::TENTAC_HRM.Properties.Resources.plus;
            this.btn_add.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btn_add.Name = "btn_add";
            this.btn_add.Size = new System.Drawing.Size(57, 22);
            this.btn_add.Text = "Thêm";
            this.btn_add.Click += new System.EventHandler(this.btn_add_Click);
            // 
            // btn_edit
            // 
            this.btn_edit.Image = global::TENTAC_HRM.Properties.Resources.pen;
            this.btn_edit.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btn_edit.Name = "btn_edit";
            this.btn_edit.Size = new System.Drawing.Size(46, 22);
            this.btn_edit.Text = "Sửa";
            this.btn_edit.Click += new System.EventHandler(this.btn_edit_Click);
            // 
            // btn_delete
            // 
            this.btn_delete.Image = global::TENTAC_HRM.Properties.Resources.bin;
            this.btn_delete.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btn_delete.Name = "btn_delete";
            this.btn_delete.Size = new System.Drawing.Size(47, 22);
            this.btn_delete.Text = "Xóa";
            // 
            // btn_refresh
            // 
            this.btn_refresh.Image = global::TENTAC_HRM.Properties.Resources.refresh;
            this.btn_refresh.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btn_refresh.Name = "btn_refresh";
            this.btn_refresh.Size = new System.Drawing.Size(64, 22);
            this.btn_refresh.Text = "Nạp lại";
            this.btn_refresh.Click += new System.EventHandler(this.btn_refresh_Click);
            // 
            // btn_close
            // 
            this.btn_close.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.btn_close.Image = ((System.Drawing.Image)(resources.GetObject("btn_close.Image")));
            this.btn_close.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btn_close.Name = "btn_close";
            this.btn_close.Size = new System.Drawing.Size(23, 22);
            this.btn_close.Click += new System.EventHandler(this.btn_close_Click);
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.pnlDieuHuong);
            this.panel1.Controls.Add(this.panel3);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel1.Location = new System.Drawing.Point(0, 536);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(997, 25);
            this.panel1.TabIndex = 3;
            // 
            // pnlDieuHuong
            // 
            this.pnlDieuHuong.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlDieuHuong.Location = new System.Drawing.Point(0, 0);
            this.pnlDieuHuong.Name = "pnlDieuHuong";
            this.pnlDieuHuong.Size = new System.Drawing.Size(876, 25);
            this.pnlDieuHuong.TabIndex = 0;
            // 
            // panel3
            // 
            this.panel3.Controls.Add(this.lb_totalsize);
            this.panel3.Dock = System.Windows.Forms.DockStyle.Right;
            this.panel3.Location = new System.Drawing.Point(876, 0);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(121, 25);
            this.panel3.TabIndex = 1;
            // 
            // lb_totalsize
            // 
            this.lb_totalsize.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lb_totalsize.Location = new System.Drawing.Point(0, 0);
            this.lb_totalsize.Name = "lb_totalsize";
            this.lb_totalsize.Size = new System.Drawing.Size(121, 25);
            this.lb_totalsize.TabIndex = 0;
            this.lb_totalsize.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // dgv_nhanvien_hopdong
            // 
            this.dgv_nhanvien_hopdong.AllowUserToAddRows = false;
            this.dgv_nhanvien_hopdong.BackgroundColor = System.Drawing.SystemColors.Control;
            this.dgv_nhanvien_hopdong.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgv_nhanvien_hopdong.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.id_hop_dong,
            this.id_nhan_vien,
            this.edit_column,
            this.rownumber,
            this.ma_nhan_vien,
            this.so_hop_dong,
            this.ho_lot,
            this.ten,
            this.loai_hop_dong,
            this.thoi_gian,
            this.ngay_ky,
            this.tu_ngay,
            this.den_ngay,
            this.nguoi_ky,
            this.ghi_chu,
            this.id_loai_hop_dong});
            this.dgv_nhanvien_hopdong.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgv_nhanvien_hopdong.Location = new System.Drawing.Point(0, 25);
            this.dgv_nhanvien_hopdong.Name = "dgv_nhanvien_hopdong";
            this.dgv_nhanvien_hopdong.Size = new System.Drawing.Size(997, 511);
            this.dgv_nhanvien_hopdong.TabIndex = 4;
            this.dgv_nhanvien_hopdong.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgv_nhanvien_hopdong_CellClick);
            this.dgv_nhanvien_hopdong.CellFormatting += new System.Windows.Forms.DataGridViewCellFormattingEventHandler(this.dgv_nhanvien_hopdong_CellFormatting);
            // 
            // id_hop_dong
            // 
            this.id_hop_dong.DataPropertyName = "id_hop_dong";
            this.id_hop_dong.Frozen = true;
            this.id_hop_dong.HeaderText = "Column1";
            this.id_hop_dong.Name = "id_hop_dong";
            this.id_hop_dong.Visible = false;
            // 
            // id_nhan_vien
            // 
            this.id_nhan_vien.DataPropertyName = "id_nhan_vien";
            this.id_nhan_vien.Frozen = true;
            this.id_nhan_vien.HeaderText = "id_nhan_vien";
            this.id_nhan_vien.Name = "id_nhan_vien";
            this.id_nhan_vien.Visible = false;
            // 
            // edit_column
            // 
            this.edit_column.Frozen = true;
            this.edit_column.HeaderText = "";
            this.edit_column.Image = global::TENTAC_HRM.Properties.Resources.pen;
            this.edit_column.Name = "edit_column";
            this.edit_column.Width = 30;
            // 
            // rownumber
            // 
            this.rownumber.DataPropertyName = "rownumber";
            this.rownumber.Frozen = true;
            this.rownumber.HeaderText = "STT";
            this.rownumber.Name = "rownumber";
            this.rownumber.Width = 50;
            // 
            // ma_nhan_vien
            // 
            this.ma_nhan_vien.DataPropertyName = "ma_nhan_vien";
            dataGridViewCellStyle1.ForeColor = System.Drawing.Color.Green;
            this.ma_nhan_vien.DefaultCellStyle = dataGridViewCellStyle1;
            this.ma_nhan_vien.Frozen = true;
            this.ma_nhan_vien.HeaderText = "Mã nhân viên";
            this.ma_nhan_vien.Name = "ma_nhan_vien";
            this.ma_nhan_vien.Width = 120;
            // 
            // so_hop_dong
            // 
            this.so_hop_dong.DataPropertyName = "so_hop_dong";
            this.so_hop_dong.Frozen = true;
            this.so_hop_dong.HeaderText = "Số hợp đồng";
            this.so_hop_dong.Name = "so_hop_dong";
            this.so_hop_dong.Width = 120;
            // 
            // ho_lot
            // 
            this.ho_lot.DataPropertyName = "ho_lot";
            this.ho_lot.Frozen = true;
            this.ho_lot.HeaderText = "Họ lót";
            this.ho_lot.Name = "ho_lot";
            this.ho_lot.Width = 80;
            // 
            // ten
            // 
            this.ten.DataPropertyName = "ten";
            this.ten.Frozen = true;
            this.ten.HeaderText = "Tên";
            this.ten.Name = "ten";
            this.ten.Width = 79;
            // 
            // loai_hop_dong
            // 
            this.loai_hop_dong.DataPropertyName = "loai_hop_dong";
            this.loai_hop_dong.HeaderText = "Loại hợp đồng";
            this.loai_hop_dong.Name = "loai_hop_dong";
            this.loai_hop_dong.Width = 150;
            // 
            // thoi_gian
            // 
            this.thoi_gian.DataPropertyName = "thoi_gian";
            this.thoi_gian.HeaderText = "Thời gian";
            this.thoi_gian.Name = "thoi_gian";
            // 
            // ngay_ky
            // 
            this.ngay_ky.DataPropertyName = "ngay_ky";
            this.ngay_ky.HeaderText = "Ngày ký";
            this.ngay_ky.Name = "ngay_ky";
            // 
            // tu_ngay
            // 
            this.tu_ngay.DataPropertyName = "tu_ngay";
            this.tu_ngay.HeaderText = "Từ ngày";
            this.tu_ngay.Name = "tu_ngay";
            // 
            // den_ngay
            // 
            this.den_ngay.DataPropertyName = "den_ngay";
            this.den_ngay.HeaderText = "Đến ngày";
            this.den_ngay.Name = "den_ngay";
            // 
            // nguoi_ky
            // 
            this.nguoi_ky.DataPropertyName = "nguoi_ky";
            this.nguoi_ky.HeaderText = "Người ký";
            this.nguoi_ky.Name = "nguoi_ky";
            // 
            // ghi_chu
            // 
            this.ghi_chu.DataPropertyName = "ghi_chu";
            this.ghi_chu.HeaderText = "Ghi chú";
            this.ghi_chu.Name = "ghi_chu";
            // 
            // id_loai_hop_dong
            // 
            this.id_loai_hop_dong.DataPropertyName = "id_loai_hop_dong";
            this.id_loai_hop_dong.HeaderText = "id_loai_hop_dong";
            this.id_loai_hop_dong.Name = "id_loai_hop_dong";
            this.id_loai_hop_dong.Visible = false;
            // 
            // uc_nhansu_hopdong
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.dgv_nhanvien_hopdong);
            this.Controls.Add(this.toolStrip1);
            this.Controls.Add(this.panel1);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "uc_nhansu_hopdong";
            this.Size = new System.Drawing.Size(997, 561);
            this.Load += new System.EventHandler(this.uc_nhansu_hopdong_Load);
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.panel3.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgv_nhanvien_hopdong)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripLabel toolStripLabel1;
        private System.Windows.Forms.ToolStripComboBox cbo_loai_hopdong;
        private System.Windows.Forms.ToolStripButton btn_saerch;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripButton btn_add;
        private System.Windows.Forms.ToolStripButton btn_edit;
        private System.Windows.Forms.ToolStripButton btn_delete;
        private System.Windows.Forms.ToolStripButton btn_refresh;
        private System.Windows.Forms.ToolStripButton btn_close;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel pnlDieuHuong;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Label lb_totalsize;
        private System.Windows.Forms.DataGridView dgv_nhanvien_hopdong;
        private System.Windows.Forms.DataGridViewTextBoxColumn id_hop_dong;
        private System.Windows.Forms.DataGridViewTextBoxColumn id_nhan_vien;
        private System.Windows.Forms.DataGridViewImageColumn edit_column;
        private System.Windows.Forms.DataGridViewTextBoxColumn rownumber;
        private System.Windows.Forms.DataGridViewTextBoxColumn ma_nhan_vien;
        private System.Windows.Forms.DataGridViewTextBoxColumn so_hop_dong;
        private System.Windows.Forms.DataGridViewTextBoxColumn ho_lot;
        private System.Windows.Forms.DataGridViewTextBoxColumn ten;
        private System.Windows.Forms.DataGridViewTextBoxColumn loai_hop_dong;
        private System.Windows.Forms.DataGridViewTextBoxColumn thoi_gian;
        private System.Windows.Forms.DataGridViewTextBoxColumn ngay_ky;
        private System.Windows.Forms.DataGridViewTextBoxColumn tu_ngay;
        private System.Windows.Forms.DataGridViewTextBoxColumn den_ngay;
        private System.Windows.Forms.DataGridViewTextBoxColumn nguoi_ky;
        private System.Windows.Forms.DataGridViewTextBoxColumn ghi_chu;
        private System.Windows.Forms.DataGridViewTextBoxColumn id_loai_hop_dong;
    }
}
