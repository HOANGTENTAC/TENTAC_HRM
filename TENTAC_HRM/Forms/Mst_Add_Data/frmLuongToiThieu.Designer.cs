namespace TENTAC_HRM.Forms.Mst_Add_Data
{
    partial class frmLuongToiThieu
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
            this.txtLuongToiThieuTheoThang = new DevComponents.DotNetBar.Controls.TextBoxX();
            this.lblLuongToiThieuTheoThang = new DevComponents.DotNetBar.LabelX();
            this.lblVung = new DevComponents.DotNetBar.LabelX();
            this.txtLuongToiThieuTheoGio = new DevComponents.DotNetBar.Controls.TextBoxX();
            this.lblLuongToiThieuTheoGio = new DevComponents.DotNetBar.LabelX();
            this.btn_save = new System.Windows.Forms.Button();
            this.btn_cancel = new System.Windows.Forms.Button();
            this.txtTenVung = new DevComponents.DotNetBar.Controls.TextBoxX();
            this.SuspendLayout();
            // 
            // txtLuongToiThieuTheoThang
            // 
            this.txtLuongToiThieuTheoThang.BackColor = System.Drawing.SystemColors.Window;
            // 
            // 
            // 
            this.txtLuongToiThieuTheoThang.Border.Class = "TextBoxBorder";
            this.txtLuongToiThieuTheoThang.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtLuongToiThieuTheoThang.Location = new System.Drawing.Point(206, 58);
            this.txtLuongToiThieuTheoThang.Name = "txtLuongToiThieuTheoThang";
            this.txtLuongToiThieuTheoThang.Size = new System.Drawing.Size(246, 22);
            this.txtLuongToiThieuTheoThang.TabIndex = 29;
            this.txtLuongToiThieuTheoThang.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.textBox_KeyPress);
            // 
            // lblLuongToiThieuTheoThang
            // 
            this.lblLuongToiThieuTheoThang.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblLuongToiThieuTheoThang.ForeColor = System.Drawing.SystemColors.ControlText;
            this.lblLuongToiThieuTheoThang.Location = new System.Drawing.Point(27, 57);
            this.lblLuongToiThieuTheoThang.Name = "lblLuongToiThieuTheoThang";
            this.lblLuongToiThieuTheoThang.Size = new System.Drawing.Size(185, 23);
            this.lblLuongToiThieuTheoThang.TabIndex = 28;
            this.lblLuongToiThieuTheoThang.Text = "Lương Tối Thiểu Theo Tháng:";
            // 
            // lblVung
            // 
            this.lblVung.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblVung.ForeColor = System.Drawing.SystemColors.ControlText;
            this.lblVung.Location = new System.Drawing.Point(27, 21);
            this.lblVung.Name = "lblVung";
            this.lblVung.Size = new System.Drawing.Size(101, 23);
            this.lblVung.TabIndex = 27;
            this.lblVung.Text = "Tên Vùng:";
            // 
            // txtLuongToiThieuTheoGio
            // 
            this.txtLuongToiThieuTheoGio.BackColor = System.Drawing.SystemColors.Window;
            // 
            // 
            // 
            this.txtLuongToiThieuTheoGio.Border.Class = "TextBoxBorder";
            this.txtLuongToiThieuTheoGio.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtLuongToiThieuTheoGio.Location = new System.Drawing.Point(206, 97);
            this.txtLuongToiThieuTheoGio.Name = "txtLuongToiThieuTheoGio";
            this.txtLuongToiThieuTheoGio.Size = new System.Drawing.Size(246, 22);
            this.txtLuongToiThieuTheoGio.TabIndex = 31;
            this.txtLuongToiThieuTheoGio.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.textBox_KeyPress);
            // 
            // lblLuongToiThieuTheoGio
            // 
            this.lblLuongToiThieuTheoGio.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblLuongToiThieuTheoGio.ForeColor = System.Drawing.SystemColors.ControlText;
            this.lblLuongToiThieuTheoGio.Location = new System.Drawing.Point(27, 96);
            this.lblLuongToiThieuTheoGio.Name = "lblLuongToiThieuTheoGio";
            this.lblLuongToiThieuTheoGio.Size = new System.Drawing.Size(185, 23);
            this.lblLuongToiThieuTheoGio.TabIndex = 30;
            this.lblLuongToiThieuTheoGio.Text = "Lương Tối Thiểu Theo Tháng:";
            // 
            // btn_save
            // 
            this.btn_save.Image = global::TENTAC_HRM.Properties.Resources.diskette;
            this.btn_save.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btn_save.Location = new System.Drawing.Point(133, 153);
            this.btn_save.Name = "btn_save";
            this.btn_save.Size = new System.Drawing.Size(148, 30);
            this.btn_save.TabIndex = 24;
            this.btn_save.Text = "Lưu";
            this.btn_save.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btn_save.UseVisualStyleBackColor = true;
            this.btn_save.Click += new System.EventHandler(this.btn_save_Click);
            // 
            // btn_cancel
            // 
            this.btn_cancel.Image = global::TENTAC_HRM.Properties.Resources.cancel;
            this.btn_cancel.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btn_cancel.Location = new System.Drawing.Point(287, 153);
            this.btn_cancel.Name = "btn_cancel";
            this.btn_cancel.Size = new System.Drawing.Size(127, 30);
            this.btn_cancel.TabIndex = 25;
            this.btn_cancel.Text = "Hủy";
            this.btn_cancel.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btn_cancel.UseVisualStyleBackColor = true;
            this.btn_cancel.Click += new System.EventHandler(this.btn_cancel_Click);
            // 
            // txtTenVung
            // 
            this.txtTenVung.BackColor = System.Drawing.SystemColors.Window;
            // 
            // 
            // 
            this.txtTenVung.Border.Class = "TextBoxBorder";
            this.txtTenVung.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtTenVung.Location = new System.Drawing.Point(206, 21);
            this.txtTenVung.Name = "txtTenVung";
            this.txtTenVung.Size = new System.Drawing.Size(246, 22);
            this.txtTenVung.TabIndex = 32;
            // 
            // frmLuongToiThieu
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(482, 219);
            this.Controls.Add(this.txtTenVung);
            this.Controls.Add(this.txtLuongToiThieuTheoGio);
            this.Controls.Add(this.lblLuongToiThieuTheoGio);
            this.Controls.Add(this.txtLuongToiThieuTheoThang);
            this.Controls.Add(this.lblLuongToiThieuTheoThang);
            this.Controls.Add(this.lblVung);
            this.Controls.Add(this.btn_save);
            this.Controls.Add(this.btn_cancel);
            this.Name = "frmLuongToiThieu";
            this.Text = "Lương Tối Thiểu";
            this.ResumeLayout(false);

        }

        #endregion
        private DevComponents.DotNetBar.Controls.TextBoxX txtLuongToiThieuTheoThang;
        private DevComponents.DotNetBar.LabelX lblLuongToiThieuTheoThang;
        private DevComponents.DotNetBar.LabelX lblVung;
        private System.Windows.Forms.Button btn_save;
        private System.Windows.Forms.Button btn_cancel;
        private DevComponents.DotNetBar.Controls.TextBoxX txtLuongToiThieuTheoGio;
        private DevComponents.DotNetBar.LabelX lblLuongToiThieuTheoGio;
        private DevComponents.DotNetBar.Controls.TextBoxX txtTenVung;
    }
}