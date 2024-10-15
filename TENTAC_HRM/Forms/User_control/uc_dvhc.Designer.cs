namespace TENTAC_HRM.Forms.User_control
{
    partial class uc_dvhc
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
            this.dataGridViewImageColumn1 = new System.Windows.Forms.DataGridViewImageColumn();
            this.dataGridViewImageColumn2 = new System.Windows.Forms.DataGridViewImageColumn();
            this.btn_add = new System.Windows.Forms.ToolStripButton();
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.btn_delete = new System.Windows.Forms.ToolStripButton();
            this.mo_ta = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.thu_tu = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ten_dan_toc = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.edit_column = new System.Windows.Forms.DataGridViewImageColumn();
            this.id_dan_toc = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dgv_dvhc = new System.Windows.Forms.DataGridView();
            this.ma_dan_toc = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.treeView = new System.Windows.Forms.TreeView();
            this.TenDiaChi = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.MaVung = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.LuongToiThieuTheoThang = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.LuongToiThieuTheoGio = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.listView = new System.Windows.Forms.ListView();
            this.lblTinhThanh = new System.Windows.Forms.Label();
            this.txtTinhThanh = new System.Windows.Forms.TextBox();
            this.lblQuanHuyen = new System.Windows.Forms.Label();
            this.txtQuanHuyen = new System.Windows.Forms.TextBox();
            this.lblPhuongXa = new System.Windows.Forms.Label();
            this.txtPhuongXa = new System.Windows.Forms.TextBox();
            this.lblVung = new System.Windows.Forms.Label();
            this.cboVung = new System.Windows.Forms.ComboBox();
            this.ckbTinhThanh = new System.Windows.Forms.CheckBox();
            this.ckbPhuongXa = new System.Windows.Forms.CheckBox();
            this.ckbQuanHuyen = new System.Windows.Forms.CheckBox();
            this.toolStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgv_dvhc)).BeginInit();
            this.SuspendLayout();
            // 
            // dataGridViewImageColumn1
            // 
            this.dataGridViewImageColumn1.HeaderText = "";
            this.dataGridViewImageColumn1.Image = global::TENTAC_HRM.Properties.Resources.pen;
            this.dataGridViewImageColumn1.Name = "dataGridViewImageColumn1";
            this.dataGridViewImageColumn1.Width = 30;
            // 
            // dataGridViewImageColumn2
            // 
            this.dataGridViewImageColumn2.HeaderText = "";
            this.dataGridViewImageColumn2.Image = global::TENTAC_HRM.Properties.Resources.pen;
            this.dataGridViewImageColumn2.Name = "dataGridViewImageColumn2";
            this.dataGridViewImageColumn2.Width = 30;
            // 
            // btn_add
            // 
            this.btn_add.Image = global::TENTAC_HRM.Properties.Resources.add_file;
            this.btn_add.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btn_add.Name = "btn_add";
            this.btn_add.Size = new System.Drawing.Size(57, 22);
            this.btn_add.Text = "Thêm";
            this.btn_add.Click += new System.EventHandler(this.btn_add_Click);
            // 
            // toolStrip1
            // 
            this.toolStrip1.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.btn_add,
            this.btn_delete});
            this.toolStrip1.Location = new System.Drawing.Point(0, 0);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(1065, 25);
            this.toolStrip1.TabIndex = 7;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // btn_delete
            // 
            this.btn_delete.Image = global::TENTAC_HRM.Properties.Resources.bin;
            this.btn_delete.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btn_delete.Name = "btn_delete";
            this.btn_delete.Size = new System.Drawing.Size(47, 22);
            this.btn_delete.Text = "Xóa";
            this.btn_delete.Click += new System.EventHandler(this.btn_delete_Click);
            // 
            // mo_ta
            // 
            this.mo_ta.DataPropertyName = "mo_ta";
            this.mo_ta.HeaderText = "Mô tả";
            this.mo_ta.Name = "mo_ta";
            this.mo_ta.Width = 150;
            // 
            // thu_tu
            // 
            this.thu_tu.DataPropertyName = "thu_tu";
            this.thu_tu.HeaderText = "Thứ tự";
            this.thu_tu.Name = "thu_tu";
            // 
            // ten_dan_toc
            // 
            this.ten_dan_toc.DataPropertyName = "ten_dan_toc";
            this.ten_dan_toc.HeaderText = "Tên dân tộc";
            this.ten_dan_toc.Name = "ten_dan_toc";
            this.ten_dan_toc.Width = 150;
            // 
            // edit_column
            // 
            this.edit_column.HeaderText = "";
            this.edit_column.Image = global::TENTAC_HRM.Properties.Resources.pen;
            this.edit_column.Name = "edit_column";
            this.edit_column.Width = 30;
            // 
            // id_dan_toc
            // 
            this.id_dan_toc.DataPropertyName = "id_dan_toc";
            this.id_dan_toc.HeaderText = "Column1";
            this.id_dan_toc.Name = "id_dan_toc";
            this.id_dan_toc.Visible = false;
            // 
            // dgv_dvhc
            // 
            this.dgv_dvhc.AllowUserToAddRows = false;
            this.dgv_dvhc.BackgroundColor = System.Drawing.SystemColors.Window;
            this.dgv_dvhc.ColumnHeadersHeight = 25;
            this.dgv_dvhc.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.id_dan_toc,
            this.edit_column,
            this.ma_dan_toc,
            this.ten_dan_toc,
            this.thu_tu,
            this.mo_ta});
            this.dgv_dvhc.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgv_dvhc.Location = new System.Drawing.Point(0, 0);
            this.dgv_dvhc.Margin = new System.Windows.Forms.Padding(4);
            this.dgv_dvhc.Name = "dgv_dvhc";
            this.dgv_dvhc.Size = new System.Drawing.Size(1065, 623);
            this.dgv_dvhc.TabIndex = 6;
            // 
            // ma_dan_toc
            // 
            this.ma_dan_toc.DataPropertyName = "ma_dan_toc";
            this.ma_dan_toc.HeaderText = "Mã dân tộc";
            this.ma_dan_toc.Name = "ma_dan_toc";
            // 
            // treeView
            // 
            this.treeView.Dock = System.Windows.Forms.DockStyle.Left;
            this.treeView.Location = new System.Drawing.Point(0, 25);
            this.treeView.Name = "treeView";
            this.treeView.Size = new System.Drawing.Size(221, 598);
            this.treeView.TabIndex = 8;
            // 
            // TenDiaChi
            // 
            this.TenDiaChi.Text = "Tên Địa Chỉ";
            this.TenDiaChi.Width = 250;
            // 
            // MaVung
            // 
            this.MaVung.Text = "Vùng";
            this.MaVung.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.MaVung.Width = 100;
            // 
            // LuongToiThieuTheoThang
            // 
            this.LuongToiThieuTheoThang.Text = "Mức lương tối thiểu tháng (đồng/tháng)";
            this.LuongToiThieuTheoThang.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.LuongToiThieuTheoThang.Width = 250;
            // 
            // LuongToiThieuTheoGio
            // 
            this.LuongToiThieuTheoGio.Text = "Mức lương tối thiểu giờ (đồng/giờ)";
            this.LuongToiThieuTheoGio.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.LuongToiThieuTheoGio.Width = 250;
            // 
            // listView
            // 
            this.listView.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.TenDiaChi,
            this.MaVung,
            this.LuongToiThieuTheoThang,
            this.LuongToiThieuTheoGio});
            this.listView.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.listView.HideSelection = false;
            this.listView.Location = new System.Drawing.Point(221, 150);
            this.listView.Name = "listView";
            this.listView.Size = new System.Drawing.Size(844, 473);
            this.listView.TabIndex = 9;
            this.listView.UseCompatibleStateImageBehavior = false;
            this.listView.View = System.Windows.Forms.View.Details;
            // 
            // lblTinhThanh
            // 
            this.lblTinhThanh.AutoSize = true;
            this.lblTinhThanh.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTinhThanh.Location = new System.Drawing.Point(227, 45);
            this.lblTinhThanh.Name = "lblTinhThanh";
            this.lblTinhThanh.Size = new System.Drawing.Size(78, 16);
            this.lblTinhThanh.TabIndex = 12;
            this.lblTinhThanh.Text = "Tỉnh/Thành:";
            // 
            // txtTinhThanh
            // 
            this.txtTinhThanh.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtTinhThanh.Location = new System.Drawing.Point(311, 42);
            this.txtTinhThanh.Name = "txtTinhThanh";
            this.txtTinhThanh.Size = new System.Drawing.Size(240, 22);
            this.txtTinhThanh.TabIndex = 13;
            // 
            // lblQuanHuyen
            // 
            this.lblQuanHuyen.AutoSize = true;
            this.lblQuanHuyen.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblQuanHuyen.Location = new System.Drawing.Point(641, 45);
            this.lblQuanHuyen.Name = "lblQuanHuyen";
            this.lblQuanHuyen.Size = new System.Drawing.Size(85, 16);
            this.lblQuanHuyen.TabIndex = 14;
            this.lblQuanHuyen.Text = "Quận/Huyện:";
            // 
            // txtQuanHuyen
            // 
            this.txtQuanHuyen.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtQuanHuyen.Location = new System.Drawing.Point(743, 42);
            this.txtQuanHuyen.Name = "txtQuanHuyen";
            this.txtQuanHuyen.Size = new System.Drawing.Size(240, 22);
            this.txtQuanHuyen.TabIndex = 15;
            // 
            // lblPhuongXa
            // 
            this.lblPhuongXa.AutoSize = true;
            this.lblPhuongXa.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblPhuongXa.Location = new System.Drawing.Point(227, 91);
            this.lblPhuongXa.Name = "lblPhuongXa";
            this.lblPhuongXa.Size = new System.Drawing.Size(76, 16);
            this.lblPhuongXa.TabIndex = 16;
            this.lblPhuongXa.Text = "Phường/Xã:";
            // 
            // txtPhuongXa
            // 
            this.txtPhuongXa.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtPhuongXa.Location = new System.Drawing.Point(311, 88);
            this.txtPhuongXa.Name = "txtPhuongXa";
            this.txtPhuongXa.Size = new System.Drawing.Size(240, 22);
            this.txtPhuongXa.TabIndex = 17;
            // 
            // lblVung
            // 
            this.lblVung.AutoSize = true;
            this.lblVung.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblVung.Location = new System.Drawing.Point(641, 94);
            this.lblVung.Name = "lblVung";
            this.lblVung.Size = new System.Drawing.Size(41, 16);
            this.lblVung.TabIndex = 18;
            this.lblVung.Text = "Vùng:";
            // 
            // cboVung
            // 
            this.cboVung.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cboVung.FormattingEnabled = true;
            this.cboVung.Location = new System.Drawing.Point(743, 91);
            this.cboVung.Name = "cboVung";
            this.cboVung.Size = new System.Drawing.Size(240, 24);
            this.cboVung.TabIndex = 19;
            // 
            // ckbTinhThanh
            // 
            this.ckbTinhThanh.AutoSize = true;
            this.ckbTinhThanh.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ckbTinhThanh.Location = new System.Drawing.Point(557, 47);
            this.ckbTinhThanh.Name = "ckbTinhThanh";
            this.ckbTinhThanh.Size = new System.Drawing.Size(15, 14);
            this.ckbTinhThanh.TabIndex = 20;
            this.ckbTinhThanh.UseVisualStyleBackColor = true;
            this.ckbTinhThanh.CheckedChanged += new System.EventHandler(this.checkBoxGroup_CheckedChanged);
            // 
            // ckbPhuongXa
            // 
            this.ckbPhuongXa.AutoSize = true;
            this.ckbPhuongXa.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ckbPhuongXa.Location = new System.Drawing.Point(557, 93);
            this.ckbPhuongXa.Name = "ckbPhuongXa";
            this.ckbPhuongXa.Size = new System.Drawing.Size(15, 14);
            this.ckbPhuongXa.TabIndex = 21;
            this.ckbPhuongXa.UseVisualStyleBackColor = true;
            this.ckbPhuongXa.CheckedChanged += new System.EventHandler(this.checkBoxGroup_CheckedChanged);
            // 
            // ckbQuanHuyen
            // 
            this.ckbQuanHuyen.AutoSize = true;
            this.ckbQuanHuyen.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ckbQuanHuyen.Location = new System.Drawing.Point(989, 47);
            this.ckbQuanHuyen.Name = "ckbQuanHuyen";
            this.ckbQuanHuyen.Size = new System.Drawing.Size(15, 14);
            this.ckbQuanHuyen.TabIndex = 22;
            this.ckbQuanHuyen.UseVisualStyleBackColor = true;
            this.ckbQuanHuyen.CheckedChanged += new System.EventHandler(this.checkBoxGroup_CheckedChanged);
            // 
            // uc_dvhc
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.ckbQuanHuyen);
            this.Controls.Add(this.ckbPhuongXa);
            this.Controls.Add(this.ckbTinhThanh);
            this.Controls.Add(this.cboVung);
            this.Controls.Add(this.lblVung);
            this.Controls.Add(this.txtPhuongXa);
            this.Controls.Add(this.lblPhuongXa);
            this.Controls.Add(this.txtQuanHuyen);
            this.Controls.Add(this.lblQuanHuyen);
            this.Controls.Add(this.txtTinhThanh);
            this.Controls.Add(this.lblTinhThanh);
            this.Controls.Add(this.listView);
            this.Controls.Add(this.treeView);
            this.Controls.Add(this.toolStrip1);
            this.Controls.Add(this.dgv_dvhc);
            this.Name = "uc_dvhc";
            this.Size = new System.Drawing.Size(1065, 623);
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgv_dvhc)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridViewImageColumn dataGridViewImageColumn1;
        private System.Windows.Forms.DataGridViewImageColumn dataGridViewImageColumn2;
        private System.Windows.Forms.ToolStripButton btn_add;
        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripButton btn_delete;
        private System.Windows.Forms.DataGridViewTextBoxColumn mo_ta;
        private System.Windows.Forms.DataGridViewTextBoxColumn thu_tu;
        private System.Windows.Forms.DataGridViewTextBoxColumn ten_dan_toc;
        private System.Windows.Forms.DataGridViewImageColumn edit_column;
        private System.Windows.Forms.DataGridViewTextBoxColumn id_dan_toc;
        private System.Windows.Forms.DataGridView dgv_dvhc;
        private System.Windows.Forms.DataGridViewTextBoxColumn ma_dan_toc;
        private System.Windows.Forms.TreeView treeView;
        private System.Windows.Forms.ColumnHeader TenDiaChi;
        private System.Windows.Forms.ColumnHeader MaVung;
        private System.Windows.Forms.ColumnHeader LuongToiThieuTheoThang;
        private System.Windows.Forms.ColumnHeader LuongToiThieuTheoGio;
        private System.Windows.Forms.ListView listView;
        private System.Windows.Forms.Label lblTinhThanh;
        private System.Windows.Forms.TextBox txtTinhThanh;
        private System.Windows.Forms.Label lblQuanHuyen;
        private System.Windows.Forms.TextBox txtQuanHuyen;
        private System.Windows.Forms.Label lblPhuongXa;
        private System.Windows.Forms.TextBox txtPhuongXa;
        private System.Windows.Forms.Label lblVung;
        private System.Windows.Forms.ComboBox cboVung;
        private System.Windows.Forms.CheckBox ckbTinhThanh;
        private System.Windows.Forms.CheckBox ckbPhuongXa;
        private System.Windows.Forms.CheckBox ckbQuanHuyen;
    }
}
