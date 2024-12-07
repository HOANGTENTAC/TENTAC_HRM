
namespace TENTAC_HRM.Forms.User_control
{
    partial class uc_authorization
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(uc_authorization));
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            this.panel1 = new System.Windows.Forms.Panel();
            this.btn_save = new System.Windows.Forms.Button();
            this.txt_MatKhau = new DevComponents.DotNetBar.Controls.TextBoxX();
            this.txt_TenDangNhap = new DevComponents.DotNetBar.Controls.TextBoxX();
            this.treeview_PhanQuyen = new System.Windows.Forms.TreeView();
            this.imageList1 = new System.Windows.Forms.ImageList(this.components);
            this.txt_XacNhanMatKhau = new DevComponents.DotNetBar.Controls.TextBoxX();
            this.labelX3 = new DevComponents.DotNetBar.LabelX();
            this.labelX2 = new DevComponents.DotNetBar.LabelX();
            this.labelX1 = new DevComponents.DotNetBar.LabelX();
            this.toolStripLabel2 = new System.Windows.Forms.ToolStripLabel();
            this.cbo_BoPhan = new System.Windows.Forms.ToolStripComboBox();
            this.toolStripLabel1 = new System.Windows.Forms.ToolStripLabel();
            this.cbo_NhanVien = new System.Windows.Forms.ToolStripComboBox();
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.toolStripSeparator17 = new System.Windows.Forms.ToolStripSeparator();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.toolStripLabel4 = new System.Windows.Forms.ToolStripLabel();
            this.cbo_pagenumber = new System.Windows.Forms.ToolStripComboBox();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.dgv_MenuPhanQuyen = new DevComponents.DotNetBar.Controls.DataGridViewX();
            this.pnlDieuHuong = new System.Windows.Forms.Panel();
            this.MaNhanVien = new ComponentFactory.Krypton.Toolkit.KryptonDataGridViewTextBoxColumn();
            this.TenNhanVien = new ComponentFactory.Krypton.Toolkit.KryptonDataGridViewTextBoxColumn();
            this.TenPhongBan = new ComponentFactory.Krypton.Toolkit.KryptonDataGridViewTextBoxColumn();
            this.TenChucVu = new ComponentFactory.Krypton.Toolkit.KryptonDataGridViewTextBoxColumn();
            this.Is_active = new ComponentFactory.Krypton.Toolkit.KryptonDataGridViewCheckBoxColumn();
            this.SoLanDangNhap = new ComponentFactory.Krypton.Toolkit.KryptonDataGridViewTextBoxColumn();
            this.panel1.SuspendLayout();
            this.toolStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgv_MenuPhanQuyen)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.SystemColors.InactiveBorder;
            this.panel1.Controls.Add(this.btn_save);
            this.panel1.Controls.Add(this.txt_MatKhau);
            this.panel1.Controls.Add(this.txt_TenDangNhap);
            this.panel1.Controls.Add(this.treeview_PhanQuyen);
            this.panel1.Controls.Add(this.txt_XacNhanMatKhau);
            this.panel1.Controls.Add(this.labelX3);
            this.panel1.Controls.Add(this.labelX2);
            this.panel1.Controls.Add(this.labelX1);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Left;
            this.panel1.Location = new System.Drawing.Point(0, 27);
            this.panel1.Margin = new System.Windows.Forms.Padding(4);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(349, 587);
            this.panel1.TabIndex = 2;
            // 
            // btn_save
            // 
            this.btn_save.Image = global::TENTAC_HRM.Properties.Resources.diskette;
            this.btn_save.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btn_save.Location = new System.Drawing.Point(257, 103);
            this.btn_save.Margin = new System.Windows.Forms.Padding(4);
            this.btn_save.Name = "btn_save";
            this.btn_save.Size = new System.Drawing.Size(85, 34);
            this.btn_save.TabIndex = 9;
            this.btn_save.Text = "Lưu";
            this.btn_save.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btn_save.UseVisualStyleBackColor = true;
            this.btn_save.Click += new System.EventHandler(this.btn_save_Click);
            // 
            // txt_MatKhau
            // 
            // 
            // 
            // 
            this.txt_MatKhau.Border.Class = "TextBoxBorder";
            this.txt_MatKhau.Location = new System.Drawing.Point(137, 37);
            this.txt_MatKhau.Margin = new System.Windows.Forms.Padding(4);
            this.txt_MatKhau.Name = "txt_MatKhau";
            this.txt_MatKhau.PasswordChar = '*';
            this.txt_MatKhau.Size = new System.Drawing.Size(205, 22);
            this.txt_MatKhau.TabIndex = 8;
            this.txt_MatKhau.UseSystemPasswordChar = true;
            // 
            // txt_TenDangNhap
            // 
            // 
            // 
            // 
            this.txt_TenDangNhap.Border.Class = "TextBoxBorder";
            this.txt_TenDangNhap.Location = new System.Drawing.Point(137, 5);
            this.txt_TenDangNhap.Margin = new System.Windows.Forms.Padding(4);
            this.txt_TenDangNhap.Name = "txt_TenDangNhap";
            this.txt_TenDangNhap.ReadOnly = true;
            this.txt_TenDangNhap.Size = new System.Drawing.Size(205, 22);
            this.txt_TenDangNhap.TabIndex = 7;
            // 
            // treeview_PhanQuyen
            // 
            this.treeview_PhanQuyen.BackColor = System.Drawing.SystemColors.InactiveBorder;
            this.treeview_PhanQuyen.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.treeview_PhanQuyen.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.treeview_PhanQuyen.ImageIndex = 0;
            this.treeview_PhanQuyen.ImageList = this.imageList1;
            this.treeview_PhanQuyen.Location = new System.Drawing.Point(0, 145);
            this.treeview_PhanQuyen.Margin = new System.Windows.Forms.Padding(4);
            this.treeview_PhanQuyen.Name = "treeview_PhanQuyen";
            this.treeview_PhanQuyen.SelectedImageIndex = 1;
            this.treeview_PhanQuyen.Size = new System.Drawing.Size(349, 442);
            this.treeview_PhanQuyen.TabIndex = 6;
            this.treeview_PhanQuyen.NodeMouseClick += new System.Windows.Forms.TreeNodeMouseClickEventHandler(this.Treeview_PhanQuyen_NodeMouseClick);
            // 
            // imageList1
            // 
            this.imageList1.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imageList1.ImageStream")));
            this.imageList1.TransparentColor = System.Drawing.Color.Transparent;
            this.imageList1.Images.SetKeyName(0, "No.png");
            this.imageList1.Images.SetKeyName(1, "Yes.png");
            // 
            // txt_XacNhanMatKhau
            // 
            // 
            // 
            // 
            this.txt_XacNhanMatKhau.Border.Class = "TextBoxBorder";
            this.txt_XacNhanMatKhau.Location = new System.Drawing.Point(137, 73);
            this.txt_XacNhanMatKhau.Margin = new System.Windows.Forms.Padding(4);
            this.txt_XacNhanMatKhau.Name = "txt_XacNhanMatKhau";
            this.txt_XacNhanMatKhau.PasswordChar = '*';
            this.txt_XacNhanMatKhau.Size = new System.Drawing.Size(205, 22);
            this.txt_XacNhanMatKhau.TabIndex = 5;
            this.txt_XacNhanMatKhau.UseSystemPasswordChar = true;
            // 
            // labelX3
            // 
            this.labelX3.Location = new System.Drawing.Point(8, 69);
            this.labelX3.Margin = new System.Windows.Forms.Padding(4);
            this.labelX3.Name = "labelX3";
            this.labelX3.Size = new System.Drawing.Size(149, 28);
            this.labelX3.TabIndex = 4;
            this.labelX3.Text = "Xác nhận mật khẩu:";
            // 
            // labelX2
            // 
            this.labelX2.Location = new System.Drawing.Point(5, 37);
            this.labelX2.Margin = new System.Windows.Forms.Padding(4);
            this.labelX2.Name = "labelX2";
            this.labelX2.Size = new System.Drawing.Size(100, 28);
            this.labelX2.TabIndex = 1;
            this.labelX2.Text = "Mật khẩu:";
            // 
            // labelX1
            // 
            this.labelX1.Location = new System.Drawing.Point(5, 5);
            this.labelX1.Margin = new System.Windows.Forms.Padding(4);
            this.labelX1.Name = "labelX1";
            this.labelX1.Size = new System.Drawing.Size(115, 28);
            this.labelX1.TabIndex = 0;
            this.labelX1.Text = "Tên đăng nhập:";
            // 
            // toolStripLabel2
            // 
            this.toolStripLabel2.ForeColor = System.Drawing.SystemColors.WindowText;
            this.toolStripLabel2.Name = "toolStripLabel2";
            this.toolStripLabel2.Size = new System.Drawing.Size(111, 24);
            this.toolStripLabel2.Text = "Lọc theo bộ phận";
            // 
            // cbo_BoPhan
            // 
            this.cbo_BoPhan.BackColor = System.Drawing.SystemColors.MenuBar;
            this.cbo_BoPhan.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.cbo_BoPhan.Name = "cbo_BoPhan";
            this.cbo_BoPhan.Size = new System.Drawing.Size(160, 27);
            // 
            // toolStripLabel1
            // 
            this.toolStripLabel1.ForeColor = System.Drawing.SystemColors.WindowText;
            this.toolStripLabel1.Name = "toolStripLabel1";
            this.toolStripLabel1.Size = new System.Drawing.Size(120, 24);
            this.toolStripLabel1.Text = "Lọc theo nhân viên:";
            // 
            // cbo_NhanVien
            // 
            this.cbo_NhanVien.BackColor = System.Drawing.SystemColors.MenuBar;
            this.cbo_NhanVien.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.cbo_NhanVien.Name = "cbo_NhanVien";
            this.cbo_NhanVien.Size = new System.Drawing.Size(239, 27);
            this.cbo_NhanVien.SelectedIndexChanged += new System.EventHandler(this.cbo_NhanVien_SelectedIndexChanged);
            // 
            // toolStrip1
            // 
            this.toolStrip1.BackColor = System.Drawing.SystemColors.InactiveBorder;
            this.toolStrip1.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripLabel2,
            this.cbo_BoPhan,
            this.toolStripSeparator17,
            this.toolStripLabel1,
            this.cbo_NhanVien,
            this.toolStripSeparator1,
            this.toolStripLabel4,
            this.cbo_pagenumber});
            this.toolStrip1.Location = new System.Drawing.Point(0, 0);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.RenderMode = System.Windows.Forms.ToolStripRenderMode.System;
            this.toolStrip1.Size = new System.Drawing.Size(1129, 27);
            this.toolStrip1.TabIndex = 1;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // toolStripSeparator17
            // 
            this.toolStripSeparator17.Name = "toolStripSeparator17";
            this.toolStripSeparator17.Size = new System.Drawing.Size(6, 27);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(6, 27);
            // 
            // toolStripLabel4
            // 
            this.toolStripLabel4.Name = "toolStripLabel4";
            this.toolStripLabel4.Size = new System.Drawing.Size(107, 24);
            this.toolStripLabel4.Text = "Số lượng hiển thị";
            // 
            // cbo_pagenumber
            // 
            this.cbo_pagenumber.Name = "cbo_pagenumber";
            this.cbo_pagenumber.Size = new System.Drawing.Size(75, 27);
            // 
            // splitContainer1
            // 
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.FixedPanel = System.Windows.Forms.FixedPanel.Panel2;
            this.splitContainer1.Location = new System.Drawing.Point(349, 27);
            this.splitContainer1.Name = "splitContainer1";
            this.splitContainer1.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.dgv_MenuPhanQuyen);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.pnlDieuHuong);
            this.splitContainer1.Size = new System.Drawing.Size(780, 587);
            this.splitContainer1.SplitterDistance = 558;
            this.splitContainer1.TabIndex = 3;
            // 
            // dgv_MenuPhanQuyen
            // 
            this.dgv_MenuPhanQuyen.AllowUserToAddRows = false;
            this.dgv_MenuPhanQuyen.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgv_MenuPhanQuyen.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.MaNhanVien,
            this.TenNhanVien,
            this.TenPhongBan,
            this.TenChucVu,
            this.Is_active,
            this.SoLanDangNhap});
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgv_MenuPhanQuyen.DefaultCellStyle = dataGridViewCellStyle2;
            this.dgv_MenuPhanQuyen.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgv_MenuPhanQuyen.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(215)))), ((int)(((byte)(229)))));
            this.dgv_MenuPhanQuyen.Location = new System.Drawing.Point(0, 0);
            this.dgv_MenuPhanQuyen.Name = "dgv_MenuPhanQuyen";
            this.dgv_MenuPhanQuyen.Size = new System.Drawing.Size(780, 558);
            this.dgv_MenuPhanQuyen.TabIndex = 11;
            this.dgv_MenuPhanQuyen.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgv_MenuPhanQuyen_CellClick);
            // 
            // pnlDieuHuong
            // 
            this.pnlDieuHuong.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlDieuHuong.Location = new System.Drawing.Point(0, 0);
            this.pnlDieuHuong.Name = "pnlDieuHuong";
            this.pnlDieuHuong.Size = new System.Drawing.Size(780, 25);
            this.pnlDieuHuong.TabIndex = 12;
            // 
            // MaNhanVien
            // 
            this.MaNhanVien.DataPropertyName = "MaNhanVien";
            this.MaNhanVien.HeaderText = "Mã nhân viên";
            this.MaNhanVien.Name = "MaNhanVien";
            this.MaNhanVien.Width = 120;
            // 
            // TenNhanVien
            // 
            this.TenNhanVien.DataPropertyName = "TenNhanVien";
            this.TenNhanVien.HeaderText = "Tên nhân viên";
            this.TenNhanVien.Name = "TenNhanVien";
            this.TenNhanVien.Width = 250;
            // 
            // TenPhongBan
            // 
            this.TenPhongBan.DataPropertyName = "TenPhongBan";
            this.TenPhongBan.HeaderText = "Tên phòng ban";
            this.TenPhongBan.Name = "TenPhongBan";
            this.TenPhongBan.Width = 150;
            // 
            // TenChucVu
            // 
            this.TenChucVu.DataPropertyName = "TenChucVu";
            this.TenChucVu.HeaderText = "Tên chức vụ";
            this.TenChucVu.Name = "TenChucVu";
            this.TenChucVu.Width = 150;
            // 
            // Is_active
            // 
            this.Is_active.DataPropertyName = "Is_active";
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle1.NullValue = false;
            this.Is_active.DefaultCellStyle = dataGridViewCellStyle1;
            this.Is_active.FalseValue = null;
            this.Is_active.HeaderText = "Hiệu lực";
            this.Is_active.IndeterminateValue = null;
            this.Is_active.Name = "Is_active";
            this.Is_active.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.Is_active.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            this.Is_active.TrueValue = null;
            this.Is_active.Width = 80;
            // 
            // SoLanDangNhap
            // 
            this.SoLanDangNhap.DataPropertyName = "SoLanDangNhap";
            this.SoLanDangNhap.HeaderText = "Số lần đăng nhập";
            this.SoLanDangNhap.Name = "SoLanDangNhap";
            this.SoLanDangNhap.Width = 140;
            // 
            // uc_authorization
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.splitContainer1);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.toolStrip1);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "uc_authorization";
            this.Size = new System.Drawing.Size(1129, 614);
            this.Load += new System.EventHandler(this.uc_authorization_Load);
            this.Resize += new System.EventHandler(this.uc_authorization_Resize);
            this.panel1.ResumeLayout(false);
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgv_MenuPhanQuyen)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Panel panel1;
        private DevComponents.DotNetBar.LabelX labelX2;
        private DevComponents.DotNetBar.LabelX labelX1;
        private DevComponents.DotNetBar.Controls.TextBoxX txt_XacNhanMatKhau;
        private DevComponents.DotNetBar.LabelX labelX3;
        private System.Windows.Forms.ImageList imageList1;
        private DevComponents.DotNetBar.Controls.TextBoxX txt_TenDangNhap;
        private DevComponents.DotNetBar.Controls.TextBoxX txt_MatKhau;
        private System.Windows.Forms.TreeView treeview_PhanQuyen;
        private System.Windows.Forms.Button btn_save;
        private System.Windows.Forms.ToolStripLabel toolStripLabel2;
        private System.Windows.Forms.ToolStripComboBox cbo_BoPhan;
        private System.Windows.Forms.ToolStripLabel toolStripLabel1;
        private System.Windows.Forms.ToolStripComboBox cbo_NhanVien;
        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator17;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripLabel toolStripLabel4;
        private System.Windows.Forms.ToolStripComboBox cbo_pagenumber;
        private System.Windows.Forms.SplitContainer splitContainer1;
        private DevComponents.DotNetBar.Controls.DataGridViewX dgv_MenuPhanQuyen;
        private System.Windows.Forms.Panel pnlDieuHuong;
        private ComponentFactory.Krypton.Toolkit.KryptonDataGridViewTextBoxColumn MaNhanVien;
        private ComponentFactory.Krypton.Toolkit.KryptonDataGridViewTextBoxColumn TenNhanVien;
        private ComponentFactory.Krypton.Toolkit.KryptonDataGridViewTextBoxColumn TenPhongBan;
        private ComponentFactory.Krypton.Toolkit.KryptonDataGridViewTextBoxColumn TenChucVu;
        private ComponentFactory.Krypton.Toolkit.KryptonDataGridViewCheckBoxColumn Is_active;
        private ComponentFactory.Krypton.Toolkit.KryptonDataGridViewTextBoxColumn SoLanDangNhap;
    }
}
