namespace TENTAC_HRM.Forms.Category
{
    partial class frm_tai_san
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
            this.dgv_taisan = new System.Windows.Forms.DataGridView();
            this.id_tai_san = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.chk_column = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.ma_tai_san = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ten_tai_san = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.trang_thai = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.barcode = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.so_luong = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.don_gia = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.con_lai = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.dgv_taisan)).BeginInit();
            this.SuspendLayout();
            // 
            // dgv_taisan
            // 
            this.dgv_taisan.AllowUserToAddRows = false;
            this.dgv_taisan.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
            this.dgv_taisan.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgv_taisan.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.id_tai_san,
            this.chk_column,
            this.ma_tai_san,
            this.ten_tai_san,
            this.trang_thai,
            this.barcode,
            this.so_luong,
            this.don_gia,
            this.con_lai});
            this.dgv_taisan.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgv_taisan.Location = new System.Drawing.Point(0, 0);
            this.dgv_taisan.Margin = new System.Windows.Forms.Padding(4);
            this.dgv_taisan.Name = "dgv_taisan";
            this.dgv_taisan.Size = new System.Drawing.Size(896, 554);
            this.dgv_taisan.TabIndex = 1;
            this.dgv_taisan.CellMouseDoubleClick += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.dgv_taisan_CellMouseDoubleClick);
            // 
            // id_tai_san
            // 
            this.id_tai_san.DataPropertyName = "id_tai_san";
            this.id_tai_san.HeaderText = "Column1";
            this.id_tai_san.Name = "id_tai_san";
            this.id_tai_san.Visible = false;
            this.id_tai_san.Width = 88;
            // 
            // chk_column
            // 
            this.chk_column.DataPropertyName = "chk_column";
            this.chk_column.HeaderText = "";
            this.chk_column.Name = "chk_column";
            this.chk_column.ReadOnly = true;
            this.chk_column.Width = 5;
            // 
            // ma_tai_san
            // 
            this.ma_tai_san.DataPropertyName = "ma_tai_san";
            this.ma_tai_san.HeaderText = "Mã tài sản";
            this.ma_tai_san.Name = "ma_tai_san";
            this.ma_tai_san.Width = 98;
            // 
            // ten_tai_san
            // 
            this.ten_tai_san.DataPropertyName = "ten_tai_san";
            this.ten_tai_san.HeaderText = "Tên tài sản";
            this.ten_tai_san.Name = "ten_tai_san";
            this.ten_tai_san.Width = 104;
            // 
            // trang_thai
            // 
            this.trang_thai.DataPropertyName = "trang_thai";
            this.trang_thai.HeaderText = "Trạng thái";
            this.trang_thai.Name = "trang_thai";
            this.trang_thai.Width = 98;
            // 
            // barcode
            // 
            this.barcode.DataPropertyName = "barcode";
            this.barcode.HeaderText = "Baecode";
            this.barcode.Name = "barcode";
            this.barcode.Width = 89;
            // 
            // so_luong
            // 
            this.so_luong.DataPropertyName = "so_luong";
            this.so_luong.HeaderText = "Số lượng";
            this.so_luong.Name = "so_luong";
            this.so_luong.Width = 89;
            // 
            // don_gia
            // 
            this.don_gia.DataPropertyName = "don_gia";
            this.don_gia.HeaderText = "Đơn giá";
            this.don_gia.Name = "don_gia";
            this.don_gia.Width = 82;
            // 
            // con_lai
            // 
            this.con_lai.DataPropertyName = "con_lai";
            this.con_lai.HeaderText = "Còn lại";
            this.con_lai.Name = "con_lai";
            this.con_lai.Width = 76;
            // 
            // frm_tai_san
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(896, 554);
            this.Controls.Add(this.dgv_taisan);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.KeyPreview = true;
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "frm_tai_san";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "frm_tai_san";
            this.Load += new System.EventHandler(this.frm_tai_san_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.frm_tai_san_KeyDown);
            ((System.ComponentModel.ISupportInitialize)(this.dgv_taisan)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.DataGridView dgv_taisan;
        private System.Windows.Forms.DataGridViewTextBoxColumn id_tai_san;
        private System.Windows.Forms.DataGridViewCheckBoxColumn chk_column;
        private System.Windows.Forms.DataGridViewTextBoxColumn ma_tai_san;
        private System.Windows.Forms.DataGridViewTextBoxColumn ten_tai_san;
        private System.Windows.Forms.DataGridViewTextBoxColumn trang_thai;
        private System.Windows.Forms.DataGridViewTextBoxColumn barcode;
        private System.Windows.Forms.DataGridViewTextBoxColumn so_luong;
        private System.Windows.Forms.DataGridViewTextBoxColumn don_gia;
        private System.Windows.Forms.DataGridViewTextBoxColumn con_lai;
    }
}