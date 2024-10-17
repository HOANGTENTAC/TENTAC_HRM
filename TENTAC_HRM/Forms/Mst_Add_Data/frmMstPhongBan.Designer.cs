
namespace TENTAC_HRM.Forms.Mst_Add_Data
{
    partial class frmMstPhongBan
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
            this.lblMaCongTy = new DevComponents.DotNetBar.LabelX();
            this.lblMaPhongBan = new DevComponents.DotNetBar.LabelX();
            this.txtMaPhongBan = new DevComponents.DotNetBar.Controls.TextBoxX();
            this.btn_save = new System.Windows.Forms.Button();
            this.btn_cancel = new System.Windows.Forms.Button();
            this.cbMaCongTy = new DevComponents.DotNetBar.Controls.ComboBoxEx();
            this.cbMaKhuVuc = new DevComponents.DotNetBar.Controls.ComboBoxEx();
            this.lblMaKhuVuc = new DevComponents.DotNetBar.LabelX();
            this.lblTenPhongBan = new DevComponents.DotNetBar.LabelX();
            this.txtTenPhongBan = new DevComponents.DotNetBar.Controls.TextBoxX();
            this.SuspendLayout();
            // 
            // lblMaCongTy
            // 
            this.lblMaCongTy.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblMaCongTy.Location = new System.Drawing.Point(29, 61);
            this.lblMaCongTy.Name = "lblMaCongTy";
            this.lblMaCongTy.Size = new System.Drawing.Size(101, 23);
            this.lblMaCongTy.TabIndex = 36;
            this.lblMaCongTy.Text = "Công Ty:";
            // 
            // lblMaPhongBan
            // 
            this.lblMaPhongBan.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblMaPhongBan.Location = new System.Drawing.Point(29, 25);
            this.lblMaPhongBan.Name = "lblMaPhongBan";
            this.lblMaPhongBan.Size = new System.Drawing.Size(101, 23);
            this.lblMaPhongBan.TabIndex = 35;
            this.lblMaPhongBan.Text = "Mã Phòng Ban:";
            // 
            // txtMaPhongBan
            // 
            // 
            // 
            // 
            this.txtMaPhongBan.Border.Class = "TextBoxBorder";
            this.txtMaPhongBan.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtMaPhongBan.Location = new System.Drawing.Point(135, 25);
            this.txtMaPhongBan.Name = "txtMaPhongBan";
            this.txtMaPhongBan.ReadOnly = true;
            this.txtMaPhongBan.Size = new System.Drawing.Size(319, 22);
            this.txtMaPhongBan.TabIndex = 34;
            // 
            // btn_save
            // 
            this.btn_save.Image = global::TENTAC_HRM.Properties.Resources.diskette;
            this.btn_save.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btn_save.Location = new System.Drawing.Point(135, 195);
            this.btn_save.Name = "btn_save";
            this.btn_save.Size = new System.Drawing.Size(148, 30);
            this.btn_save.TabIndex = 32;
            this.btn_save.Text = "Lưu";
            this.btn_save.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btn_save.UseVisualStyleBackColor = true;
            this.btn_save.Click += new System.EventHandler(this.btn_save_Click);
            // 
            // btn_cancel
            // 
            this.btn_cancel.Image = global::TENTAC_HRM.Properties.Resources.cancel;
            this.btn_cancel.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btn_cancel.Location = new System.Drawing.Point(289, 195);
            this.btn_cancel.Name = "btn_cancel";
            this.btn_cancel.Size = new System.Drawing.Size(127, 30);
            this.btn_cancel.TabIndex = 33;
            this.btn_cancel.Text = "Hủy";
            this.btn_cancel.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btn_cancel.UseVisualStyleBackColor = true;
            this.btn_cancel.Click += new System.EventHandler(this.btn_cancel_Click);
            // 
            // cbMaCongTy
            // 
            this.cbMaCongTy.DisplayMember = "Text";
            this.cbMaCongTy.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.cbMaCongTy.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbMaCongTy.FormattingEnabled = true;
            this.cbMaCongTy.ItemHeight = 16;
            this.cbMaCongTy.Location = new System.Drawing.Point(135, 61);
            this.cbMaCongTy.Name = "cbMaCongTy";
            this.cbMaCongTy.Size = new System.Drawing.Size(319, 22);
            this.cbMaCongTy.TabIndex = 37;
            this.cbMaCongTy.SelectedIndexChanged += new System.EventHandler(this.cbMaCongTy_SelectedIndexChanged);
            // 
            // cbMaKhuVuc
            // 
            this.cbMaKhuVuc.DisplayMember = "Text";
            this.cbMaKhuVuc.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.cbMaKhuVuc.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbMaKhuVuc.FormattingEnabled = true;
            this.cbMaKhuVuc.ItemHeight = 16;
            this.cbMaKhuVuc.Location = new System.Drawing.Point(135, 98);
            this.cbMaKhuVuc.Name = "cbMaKhuVuc";
            this.cbMaKhuVuc.Size = new System.Drawing.Size(319, 22);
            this.cbMaKhuVuc.TabIndex = 39;
            // 
            // lblMaKhuVuc
            // 
            this.lblMaKhuVuc.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblMaKhuVuc.Location = new System.Drawing.Point(29, 98);
            this.lblMaKhuVuc.Name = "lblMaKhuVuc";
            this.lblMaKhuVuc.Size = new System.Drawing.Size(101, 23);
            this.lblMaKhuVuc.TabIndex = 38;
            this.lblMaKhuVuc.Text = "Khu Vực:";
            // 
            // lblTenPhongBan
            // 
            this.lblTenPhongBan.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTenPhongBan.Location = new System.Drawing.Point(29, 136);
            this.lblTenPhongBan.Name = "lblTenPhongBan";
            this.lblTenPhongBan.Size = new System.Drawing.Size(101, 23);
            this.lblTenPhongBan.TabIndex = 40;
            this.lblTenPhongBan.Text = "Tên Phòng Ban:";
            // 
            // txtTenPhongBan
            // 
            // 
            // 
            // 
            this.txtTenPhongBan.Border.Class = "TextBoxBorder";
            this.txtTenPhongBan.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtTenPhongBan.Location = new System.Drawing.Point(137, 136);
            this.txtTenPhongBan.Name = "txtTenPhongBan";
            this.txtTenPhongBan.Size = new System.Drawing.Size(317, 22);
            this.txtTenPhongBan.TabIndex = 41;
            // 
            // frmMstPhongBan
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(482, 253);
            this.Controls.Add(this.txtTenPhongBan);
            this.Controls.Add(this.lblTenPhongBan);
            this.Controls.Add(this.cbMaKhuVuc);
            this.Controls.Add(this.lblMaKhuVuc);
            this.Controls.Add(this.cbMaCongTy);
            this.Controls.Add(this.lblMaCongTy);
            this.Controls.Add(this.lblMaPhongBan);
            this.Controls.Add(this.txtMaPhongBan);
            this.Controls.Add(this.btn_save);
            this.Controls.Add(this.btn_cancel);
            this.Name = "frmMstPhongBan";
            this.Text = "Phòng Ban";
            this.ResumeLayout(false);

        }

        #endregion
        private DevComponents.DotNetBar.LabelX lblMaCongTy;
        private DevComponents.DotNetBar.LabelX lblMaPhongBan;
        private DevComponents.DotNetBar.Controls.TextBoxX txtMaPhongBan;
        private System.Windows.Forms.Button btn_save;
        private System.Windows.Forms.Button btn_cancel;
        private DevComponents.DotNetBar.Controls.ComboBoxEx cbMaCongTy;
        private DevComponents.DotNetBar.Controls.ComboBoxEx cbMaKhuVuc;
        private DevComponents.DotNetBar.LabelX lblMaKhuVuc;
        private DevComponents.DotNetBar.LabelX lblTenPhongBan;
        private DevComponents.DotNetBar.Controls.TextBoxX txtTenPhongBan;
    }
}