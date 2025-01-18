
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
            this.panel1 = new System.Windows.Forms.Panel();
            this.treeview_PhanQuyen = new System.Windows.Forms.TreeView();
            this.imageList1 = new System.Windows.Forms.ImageList(this.components);
            this.panel2 = new System.Windows.Forms.Panel();
            this.cbo_Group = new DevComponents.DotNetBar.Controls.ComboBoxEx();
            this.txt_TenDangNhap = new DevComponents.DotNetBar.Controls.TextBoxX();
            this.btn_save = new DevComponents.DotNetBar.ButtonX();
            this.labelX1 = new DevComponents.DotNetBar.LabelX();
            this.txt_MatKhau = new DevComponents.DotNetBar.Controls.TextBoxX();
            this.labelX2 = new DevComponents.DotNetBar.LabelX();
            this.labelX3 = new DevComponents.DotNetBar.LabelX();
            this.labelX4 = new DevComponents.DotNetBar.LabelX();
            this.txt_XacNhanMatKhau = new DevComponents.DotNetBar.Controls.TextBoxX();
            this.toolStripLabel2 = new System.Windows.Forms.ToolStripLabel();
            this.cbo_BoPhan = new System.Windows.Forms.ToolStripComboBox();
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.cbo_pagenumber = new System.Windows.Forms.ToolStripComboBox();
            this.toolStripLabel4 = new System.Windows.Forms.ToolStripLabel();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.dgv_MenuPhanQuyen = new DevComponents.DotNetBar.Controls.DataGridViewX();
            this.MaNhanVien = new ComponentFactory.Krypton.Toolkit.KryptonDataGridViewTextBoxColumn();
            this.TenNhanVien = new ComponentFactory.Krypton.Toolkit.KryptonDataGridViewTextBoxColumn();
            this.TenPhongBan = new ComponentFactory.Krypton.Toolkit.KryptonDataGridViewTextBoxColumn();
            this.TenChucVu = new ComponentFactory.Krypton.Toolkit.KryptonDataGridViewTextBoxColumn();
            this.SoLanDangNhap = new ComponentFactory.Krypton.Toolkit.KryptonDataGridViewTextBoxColumn();
            this.rownumber = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.pnlDieuHuong = new System.Windows.Forms.Panel();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
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
            this.panel1.Controls.Add(this.treeview_PhanQuyen);
            this.panel1.Controls.Add(this.panel2);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Left;
            this.panel1.Location = new System.Drawing.Point(0, 27);
            this.panel1.Margin = new System.Windows.Forms.Padding(4);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(349, 587);
            this.panel1.TabIndex = 2;
            // 
            // treeview_PhanQuyen
            // 
            this.treeview_PhanQuyen.BackColor = System.Drawing.SystemColors.InactiveBorder;
            this.treeview_PhanQuyen.Dock = System.Windows.Forms.DockStyle.Fill;
            this.treeview_PhanQuyen.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.treeview_PhanQuyen.ImageIndex = 0;
            this.treeview_PhanQuyen.ImageList = this.imageList1;
            this.treeview_PhanQuyen.Location = new System.Drawing.Point(0, 180);
            this.treeview_PhanQuyen.Margin = new System.Windows.Forms.Padding(4);
            this.treeview_PhanQuyen.Name = "treeview_PhanQuyen";
            this.treeview_PhanQuyen.SelectedImageIndex = 1;
            this.treeview_PhanQuyen.Size = new System.Drawing.Size(349, 407);
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
            // panel2
            // 
            this.panel2.Controls.Add(this.cbo_Group);
            this.panel2.Controls.Add(this.txt_TenDangNhap);
            this.panel2.Controls.Add(this.btn_save);
            this.panel2.Controls.Add(this.labelX1);
            this.panel2.Controls.Add(this.txt_MatKhau);
            this.panel2.Controls.Add(this.labelX2);
            this.panel2.Controls.Add(this.labelX3);
            this.panel2.Controls.Add(this.labelX4);
            this.panel2.Controls.Add(this.txt_XacNhanMatKhau);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel2.Location = new System.Drawing.Point(0, 0);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(349, 180);
            this.panel2.TabIndex = 12;
            // 
            // cbo_Group
            // 
            this.cbo_Group.DisplayMember = "Text";
            this.cbo_Group.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.cbo_Group.FormattingEnabled = true;
            this.cbo_Group.ItemHeight = 16;
            this.cbo_Group.Location = new System.Drawing.Point(139, 113);
            this.cbo_Group.Name = "cbo_Group";
            this.cbo_Group.Size = new System.Drawing.Size(205, 22);
            this.cbo_Group.TabIndex = 10;
            // 
            // txt_TenDangNhap
            // 
            // 
            // 
            // 
            this.txt_TenDangNhap.Border.Class = "TextBoxBorder";
            this.txt_TenDangNhap.Location = new System.Drawing.Point(139, 17);
            this.txt_TenDangNhap.Margin = new System.Windows.Forms.Padding(4);
            this.txt_TenDangNhap.Name = "txt_TenDangNhap";
            this.txt_TenDangNhap.ReadOnly = true;
            this.txt_TenDangNhap.Size = new System.Drawing.Size(205, 22);
            this.txt_TenDangNhap.TabIndex = 7;
            // 
            // btn_save
            // 
            this.btn_save.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.btn_save.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btn_save.Image = global::TENTAC_HRM.Properties.Resources.diskette;
            this.btn_save.Location = new System.Drawing.Point(250, 142);
            this.btn_save.Margin = new System.Windows.Forms.Padding(4);
            this.btn_save.Name = "btn_save";
            this.btn_save.Size = new System.Drawing.Size(94, 33);
            this.btn_save.TabIndex = 9;
            this.btn_save.Text = "Lưu";
            this.btn_save.Click += new System.EventHandler(this.btn_save_Click);
            // 
            // labelX1
            // 
            this.labelX1.Location = new System.Drawing.Point(3, 14);
            this.labelX1.Margin = new System.Windows.Forms.Padding(4);
            this.labelX1.Name = "labelX1";
            this.labelX1.Size = new System.Drawing.Size(115, 28);
            this.labelX1.TabIndex = 0;
            this.labelX1.Text = "Tên đăng nhập :";
            // 
            // txt_MatKhau
            // 
            // 
            // 
            // 
            this.txt_MatKhau.Border.Class = "TextBoxBorder";
            this.txt_MatKhau.Location = new System.Drawing.Point(139, 49);
            this.txt_MatKhau.Margin = new System.Windows.Forms.Padding(4);
            this.txt_MatKhau.Name = "txt_MatKhau";
            this.txt_MatKhau.PasswordChar = '*';
            this.txt_MatKhau.Size = new System.Drawing.Size(205, 22);
            this.txt_MatKhau.TabIndex = 8;
            this.txt_MatKhau.UseSystemPasswordChar = true;
            // 
            // labelX2
            // 
            this.labelX2.Location = new System.Drawing.Point(3, 46);
            this.labelX2.Margin = new System.Windows.Forms.Padding(4);
            this.labelX2.Name = "labelX2";
            this.labelX2.Size = new System.Drawing.Size(100, 28);
            this.labelX2.TabIndex = 1;
            this.labelX2.Text = "Mật khẩu :";
            // 
            // labelX3
            // 
            this.labelX3.Location = new System.Drawing.Point(6, 78);
            this.labelX3.Margin = new System.Windows.Forms.Padding(4);
            this.labelX3.Name = "labelX3";
            this.labelX3.Size = new System.Drawing.Size(133, 28);
            this.labelX3.TabIndex = 4;
            this.labelX3.Text = "Xác nhận mật khẩu :";
            // 
            // labelX4
            // 
            this.labelX4.Location = new System.Drawing.Point(6, 110);
            this.labelX4.Margin = new System.Windows.Forms.Padding(4);
            this.labelX4.Name = "labelX4";
            this.labelX4.Size = new System.Drawing.Size(133, 28);
            this.labelX4.TabIndex = 4;
            this.labelX4.Text = "Nhóm tài khoản :";
            // 
            // txt_XacNhanMatKhau
            // 
            // 
            // 
            // 
            this.txt_XacNhanMatKhau.Border.Class = "TextBoxBorder";
            this.txt_XacNhanMatKhau.Location = new System.Drawing.Point(139, 81);
            this.txt_XacNhanMatKhau.Margin = new System.Windows.Forms.Padding(4);
            this.txt_XacNhanMatKhau.Name = "txt_XacNhanMatKhau";
            this.txt_XacNhanMatKhau.PasswordChar = '*';
            this.txt_XacNhanMatKhau.Size = new System.Drawing.Size(205, 22);
            this.txt_XacNhanMatKhau.TabIndex = 5;
            this.txt_XacNhanMatKhau.UseSystemPasswordChar = true;
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
            // toolStrip1
            // 
            this.toolStrip1.BackColor = System.Drawing.SystemColors.InactiveBorder;
            this.toolStrip1.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.toolStrip1.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden;
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripLabel2,
            this.cbo_BoPhan,
            this.cbo_pagenumber,
            this.toolStripLabel4});
            this.toolStrip1.Location = new System.Drawing.Point(0, 0);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.RenderMode = System.Windows.Forms.ToolStripRenderMode.System;
            this.toolStrip1.Size = new System.Drawing.Size(1129, 27);
            this.toolStrip1.TabIndex = 1;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // cbo_pagenumber
            // 
            this.cbo_pagenumber.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.cbo_pagenumber.Name = "cbo_pagenumber";
            this.cbo_pagenumber.Size = new System.Drawing.Size(75, 27);
            // 
            // toolStripLabel4
            // 
            this.toolStripLabel4.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.toolStripLabel4.Name = "toolStripLabel4";
            this.toolStripLabel4.Size = new System.Drawing.Size(107, 24);
            this.toolStripLabel4.Text = "Số lượng hiển thị";
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
            this.dgv_MenuPhanQuyen.BackgroundColor = System.Drawing.SystemColors.Control;
            this.dgv_MenuPhanQuyen.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgv_MenuPhanQuyen.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.MaNhanVien,
            this.TenNhanVien,
            this.TenPhongBan,
            this.TenChucVu,
            this.SoLanDangNhap,
            this.rownumber});
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
            this.dgv_MenuPhanQuyen.RowPostPaint += new System.Windows.Forms.DataGridViewRowPostPaintEventHandler(this.dgv_MenuPhanQuyen_RowPostPaint);
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
            // SoLanDangNhap
            // 
            this.SoLanDangNhap.DataPropertyName = "SoLanDangNhap";
            this.SoLanDangNhap.HeaderText = "Số lần đăng nhập";
            this.SoLanDangNhap.Name = "SoLanDangNhap";
            this.SoLanDangNhap.Width = 140;
            // 
            // rownumber
            // 
            this.rownumber.DataPropertyName = "rownumber";
            this.rownumber.HeaderText = "rownumber";
            this.rownumber.Name = "rownumber";
            this.rownumber.Visible = false;
            // 
            // pnlDieuHuong
            // 
            this.pnlDieuHuong.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlDieuHuong.Location = new System.Drawing.Point(0, 0);
            this.pnlDieuHuong.Name = "pnlDieuHuong";
            this.pnlDieuHuong.Size = new System.Drawing.Size(780, 25);
            this.pnlDieuHuong.TabIndex = 12;
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
            this.panel2.ResumeLayout(false);
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
        private DevComponents.DotNetBar.ButtonX btn_save;
        private System.Windows.Forms.ToolStripLabel toolStripLabel2;
        private System.Windows.Forms.ToolStripComboBox cbo_BoPhan;
        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripLabel toolStripLabel4;
        private System.Windows.Forms.ToolStripComboBox cbo_pagenumber;
        private System.Windows.Forms.SplitContainer splitContainer1;
        private DevComponents.DotNetBar.Controls.DataGridViewX dgv_MenuPhanQuyen;
        private System.Windows.Forms.Panel pnlDieuHuong;
        private ComponentFactory.Krypton.Toolkit.KryptonDataGridViewTextBoxColumn MaNhanVien;
        private ComponentFactory.Krypton.Toolkit.KryptonDataGridViewTextBoxColumn TenNhanVien;
        private ComponentFactory.Krypton.Toolkit.KryptonDataGridViewTextBoxColumn TenPhongBan;
        private ComponentFactory.Krypton.Toolkit.KryptonDataGridViewTextBoxColumn TenChucVu;
        private ComponentFactory.Krypton.Toolkit.KryptonDataGridViewTextBoxColumn SoLanDangNhap;
        private System.Windows.Forms.DataGridViewTextBoxColumn rownumber;
        private DevComponents.DotNetBar.Controls.ComboBoxEx cbo_Group;
        private DevComponents.DotNetBar.LabelX labelX4;
        private System.Windows.Forms.Panel panel2;
    }
}
