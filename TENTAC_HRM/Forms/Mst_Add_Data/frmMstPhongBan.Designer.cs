
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
            this.panel1 = new System.Windows.Forms.Panel();
            this.txtTenPhongBan = new DevComponents.DotNetBar.Controls.TextBoxX();
            this.lblTenPhongBan = new DevComponents.DotNetBar.LabelX();
            this.cbMaKhuVuc = new DevComponents.DotNetBar.Controls.ComboBoxEx();
            this.lblMaKhuVuc = new DevComponents.DotNetBar.LabelX();
            this.cbMaCongTy = new DevComponents.DotNetBar.Controls.ComboBoxEx();
            this.lblMaCongTy = new DevComponents.DotNetBar.LabelX();
            this.lblMaPhongBan = new DevComponents.DotNetBar.LabelX();
            this.txtMaPhongBan = new DevComponents.DotNetBar.Controls.TextBoxX();
            this.btn_save = new System.Windows.Forms.Button();
            this.btn_cancel = new System.Windows.Forms.Button();
            this.labelX1 = new DevComponents.DotNetBar.LabelX();
            this.panel2 = new System.Windows.Forms.Panel();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.panel2);
            this.panel1.Controls.Add(this.txtTenPhongBan);
            this.panel1.Controls.Add(this.lblTenPhongBan);
            this.panel1.Controls.Add(this.cbMaKhuVuc);
            this.panel1.Controls.Add(this.lblMaKhuVuc);
            this.panel1.Controls.Add(this.cbMaCongTy);
            this.panel1.Controls.Add(this.lblMaCongTy);
            this.panel1.Controls.Add(this.lblMaPhongBan);
            this.panel1.Controls.Add(this.txtMaPhongBan);
            this.panel1.Controls.Add(this.labelX1);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(367, 403);
            this.panel1.TabIndex = 1;
            // 
            // txtTenPhongBan
            // 
            this.txtTenPhongBan.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(228)))), ((int)(((byte)(247)))), ((int)(((byte)(254)))));
            // 
            // 
            // 
            this.txtTenPhongBan.Border.Class = "TextBoxBorder";
            this.txtTenPhongBan.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtTenPhongBan.Location = new System.Drawing.Point(33, 291);
            this.txtTenPhongBan.Multiline = true;
            this.txtTenPhongBan.Name = "txtTenPhongBan";
            this.txtTenPhongBan.Size = new System.Drawing.Size(295, 25);
            this.txtTenPhongBan.TabIndex = 4;
            // 
            // lblTenPhongBan
            // 
            this.lblTenPhongBan.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTenPhongBan.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.lblTenPhongBan.Location = new System.Drawing.Point(31, 262);
            this.lblTenPhongBan.Name = "lblTenPhongBan";
            this.lblTenPhongBan.Size = new System.Drawing.Size(122, 23);
            this.lblTenPhongBan.TabIndex = 50;
            this.lblTenPhongBan.Text = "Tên Phòng Ban:";
            // 
            // cbMaKhuVuc
            // 
            this.cbMaKhuVuc.DisplayMember = "Text";
            this.cbMaKhuVuc.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.cbMaKhuVuc.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbMaKhuVuc.FormattingEnabled = true;
            this.cbMaKhuVuc.ItemHeight = 16;
            this.cbMaKhuVuc.Location = new System.Drawing.Point(33, 234);
            this.cbMaKhuVuc.Name = "cbMaKhuVuc";
            this.cbMaKhuVuc.Size = new System.Drawing.Size(295, 22);
            this.cbMaKhuVuc.TabIndex = 3;
            // 
            // lblMaKhuVuc
            // 
            this.lblMaKhuVuc.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblMaKhuVuc.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.lblMaKhuVuc.Location = new System.Drawing.Point(33, 205);
            this.lblMaKhuVuc.Name = "lblMaKhuVuc";
            this.lblMaKhuVuc.Size = new System.Drawing.Size(101, 23);
            this.lblMaKhuVuc.TabIndex = 48;
            this.lblMaKhuVuc.Text = "Khu Vực:";
            // 
            // cbMaCongTy
            // 
            this.cbMaCongTy.DisplayMember = "Text";
            this.cbMaCongTy.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.cbMaCongTy.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbMaCongTy.FormattingEnabled = true;
            this.cbMaCongTy.ItemHeight = 16;
            this.cbMaCongTy.Location = new System.Drawing.Point(31, 177);
            this.cbMaCongTy.Name = "cbMaCongTy";
            this.cbMaCongTy.Size = new System.Drawing.Size(295, 22);
            this.cbMaCongTy.TabIndex = 2;
            this.cbMaCongTy.SelectedIndexChanged += new System.EventHandler(this.cbMaCongTy_SelectedIndexChanged);
            // 
            // lblMaCongTy
            // 
            this.lblMaCongTy.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblMaCongTy.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.lblMaCongTy.Location = new System.Drawing.Point(33, 148);
            this.lblMaCongTy.Name = "lblMaCongTy";
            this.lblMaCongTy.Size = new System.Drawing.Size(101, 23);
            this.lblMaCongTy.TabIndex = 46;
            this.lblMaCongTy.Text = "Công Ty:";
            // 
            // lblMaPhongBan
            // 
            this.lblMaPhongBan.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblMaPhongBan.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.lblMaPhongBan.Location = new System.Drawing.Point(33, 88);
            this.lblMaPhongBan.Name = "lblMaPhongBan";
            this.lblMaPhongBan.Size = new System.Drawing.Size(101, 23);
            this.lblMaPhongBan.TabIndex = 45;
            this.lblMaPhongBan.Text = "Mã Phòng Ban:";
            // 
            // txtMaPhongBan
            // 
            this.txtMaPhongBan.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(248)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            // 
            // 
            // 
            this.txtMaPhongBan.Border.Class = "TextBoxBorder";
            this.txtMaPhongBan.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtMaPhongBan.Location = new System.Drawing.Point(33, 117);
            this.txtMaPhongBan.Multiline = true;
            this.txtMaPhongBan.Name = "txtMaPhongBan";
            this.txtMaPhongBan.ReadOnly = true;
            this.txtMaPhongBan.Size = new System.Drawing.Size(295, 25);
            this.txtMaPhongBan.TabIndex = 1;
            // 
            // btn_save
            // 
            this.btn_save.Image = global::TENTAC_HRM.Properties.Resources.diskette;
            this.btn_save.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btn_save.Location = new System.Drawing.Point(33, 15);
            this.btn_save.Name = "btn_save";
            this.btn_save.Size = new System.Drawing.Size(127, 30);
            this.btn_save.TabIndex = 5;
            this.btn_save.Text = "Lưu";
            this.btn_save.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btn_save.UseVisualStyleBackColor = true;
            this.btn_save.Click += new System.EventHandler(this.btn_save_Click);
            // 
            // btn_cancel
            // 
            this.btn_cancel.Image = global::TENTAC_HRM.Properties.Resources.cancel;
            this.btn_cancel.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btn_cancel.Location = new System.Drawing.Point(201, 15);
            this.btn_cancel.Name = "btn_cancel";
            this.btn_cancel.Size = new System.Drawing.Size(127, 30);
            this.btn_cancel.TabIndex = 6;
            this.btn_cancel.Text = "Đóng";
            this.btn_cancel.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btn_cancel.UseVisualStyleBackColor = true;
            this.btn_cancel.Click += new System.EventHandler(this.btn_cancel_Click);
            // 
            // labelX1
            // 
            this.labelX1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(16)))), ((int)(((byte)(39)))), ((int)(((byte)(75)))));
            this.labelX1.Dock = System.Windows.Forms.DockStyle.Top;
            this.labelX1.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelX1.ForeColor = System.Drawing.Color.WhiteSmoke;
            this.labelX1.Location = new System.Drawing.Point(0, 0);
            this.labelX1.Name = "labelX1";
            this.labelX1.Size = new System.Drawing.Size(367, 62);
            this.labelX1.TabIndex = 0;
            this.labelX1.Text = "Thêm Thông Tin Phòng Ban";
            this.labelX1.TextAlignment = System.Drawing.StringAlignment.Center;
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(16)))), ((int)(((byte)(39)))), ((int)(((byte)(75)))));
            this.panel2.Controls.Add(this.btn_save);
            this.panel2.Controls.Add(this.btn_cancel);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel2.Location = new System.Drawing.Point(0, 346);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(367, 57);
            this.panel2.TabIndex = 51;
            // 
            // frmMstPhongBan
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(367, 403);
            this.Controls.Add(this.panel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "frmMstPhongBan";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Phòng Ban";
            this.panel1.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private DevComponents.DotNetBar.Controls.TextBoxX txtTenPhongBan;
        private DevComponents.DotNetBar.LabelX lblTenPhongBan;
        private DevComponents.DotNetBar.Controls.ComboBoxEx cbMaKhuVuc;
        private DevComponents.DotNetBar.LabelX lblMaKhuVuc;
        private DevComponents.DotNetBar.Controls.ComboBoxEx cbMaCongTy;
        private DevComponents.DotNetBar.LabelX lblMaCongTy;
        private DevComponents.DotNetBar.LabelX lblMaPhongBan;
        private DevComponents.DotNetBar.Controls.TextBoxX txtMaPhongBan;
        private System.Windows.Forms.Button btn_save;
        private System.Windows.Forms.Button btn_cancel;
        private DevComponents.DotNetBar.LabelX labelX1;
        private System.Windows.Forms.Panel panel2;
    }
}