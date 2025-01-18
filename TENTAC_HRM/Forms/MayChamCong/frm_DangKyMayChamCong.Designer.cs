namespace TENTAC_HRM.Forms.MayChamCong
{
    partial class frm_DangKyMayChamCong
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frm_DangKyMayChamCong));
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.btnKetNoi = new System.Windows.Forms.ToolStripButton();
            this.btnDangKy = new System.Windows.Forms.ToolStripButton();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.label9 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.lbKetNoiTuXaThongTin = new System.Windows.Forms.Label();
            this.lbDiaChiWebThongTin = new System.Windows.Forms.Label();
            this.lbTocDoTruyenThongTin = new System.Windows.Forms.Label();
            this.lbCongCOMThongTin = new System.Windows.Forms.Label();
            this.lbPortThongTin = new System.Windows.Forms.Label();
            this.lbDiaChiIPThongTin = new System.Windows.Forms.Label();
            this.lbKieuKetNoiThongTin = new System.Windows.Forms.Label();
            this.lbIDMayThongTin = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.comboBoxMayChamcong = new System.Windows.Forms.ComboBox();
            this.txtSerial = new System.Windows.Forms.TextBox();
            this.txtDangKy = new System.Windows.Forms.TextBox();
            this.label10 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.toolStrip1.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // toolStrip1
            // 
            this.toolStrip1.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden;
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.btnKetNoi,
            this.btnDangKy});
            this.toolStrip1.Location = new System.Drawing.Point(0, 0);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(471, 25);
            this.toolStrip1.TabIndex = 0;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // btnKetNoi
            // 
            this.btnKetNoi.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.btnKetNoi.Image = ((System.Drawing.Image)(resources.GetObject("btnKetNoi.Image")));
            this.btnKetNoi.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnKetNoi.Name = "btnKetNoi";
            this.btnKetNoi.Size = new System.Drawing.Size(54, 22);
            this.btnKetNoi.Text = "Đăng ký";
            this.btnKetNoi.Click += new System.EventHandler(this.btnDangKy_Click);
            // 
            // btnDangKy
            // 
            this.btnDangKy.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.btnDangKy.Image = ((System.Drawing.Image)(resources.GetObject("btnDangKy.Image")));
            this.btnDangKy.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnDangKy.Name = "btnDangKy";
            this.btnDangKy.Size = new System.Drawing.Size(48, 22);
            this.btnDangKy.Text = "Kết nối";
            this.btnDangKy.Click += new System.EventHandler(this.btnKetNoi_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.label9);
            this.groupBox1.Controls.Add(this.label8);
            this.groupBox1.Controls.Add(this.label7);
            this.groupBox1.Controls.Add(this.label6);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.lbKetNoiTuXaThongTin);
            this.groupBox1.Controls.Add(this.lbDiaChiWebThongTin);
            this.groupBox1.Controls.Add(this.lbTocDoTruyenThongTin);
            this.groupBox1.Controls.Add(this.lbCongCOMThongTin);
            this.groupBox1.Controls.Add(this.lbPortThongTin);
            this.groupBox1.Controls.Add(this.lbDiaChiIPThongTin);
            this.groupBox1.Controls.Add(this.lbKieuKetNoiThongTin);
            this.groupBox1.Controls.Add(this.lbIDMayThongTin);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.comboBoxMayChamcong);
            this.groupBox1.Location = new System.Drawing.Point(12, 28);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(444, 298);
            this.groupBox1.TabIndex = 1;
            this.groupBox1.TabStop = false;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(22, 255);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(90, 17);
            this.label9.TabIndex = 1;
            this.label9.Text = "Kết nối từ xa:";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(22, 227);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(84, 17);
            this.label8.TabIndex = 1;
            this.label8.Text = "Địa chỉ web:";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(22, 201);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(100, 17);
            this.label7.TabIndex = 1;
            this.label7.Text = "Tốc độ truyền:";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(22, 173);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(80, 17);
            this.label6.TabIndex = 1;
            this.label6.Text = "Cổng COM:";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(22, 147);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(38, 17);
            this.label5.TabIndex = 1;
            this.label5.Text = "Port:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(22, 119);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(71, 17);
            this.label4.TabIndex = 1;
            this.label4.Text = "Địa chỉ IP:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(22, 88);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(86, 17);
            this.label3.TabIndex = 1;
            this.label3.Text = "Kiểu kết nối:";
            // 
            // lbKetNoiTuXaThongTin
            // 
            this.lbKetNoiTuXaThongTin.Location = new System.Drawing.Point(154, 255);
            this.lbKetNoiTuXaThongTin.Name = "lbKetNoiTuXaThongTin";
            this.lbKetNoiTuXaThongTin.Size = new System.Drawing.Size(269, 17);
            this.lbKetNoiTuXaThongTin.TabIndex = 1;
            // 
            // lbDiaChiWebThongTin
            // 
            this.lbDiaChiWebThongTin.Location = new System.Drawing.Point(154, 227);
            this.lbDiaChiWebThongTin.Name = "lbDiaChiWebThongTin";
            this.lbDiaChiWebThongTin.Size = new System.Drawing.Size(269, 17);
            this.lbDiaChiWebThongTin.TabIndex = 1;
            // 
            // lbTocDoTruyenThongTin
            // 
            this.lbTocDoTruyenThongTin.Location = new System.Drawing.Point(154, 201);
            this.lbTocDoTruyenThongTin.Name = "lbTocDoTruyenThongTin";
            this.lbTocDoTruyenThongTin.Size = new System.Drawing.Size(269, 17);
            this.lbTocDoTruyenThongTin.TabIndex = 1;
            // 
            // lbCongCOMThongTin
            // 
            this.lbCongCOMThongTin.Location = new System.Drawing.Point(154, 173);
            this.lbCongCOMThongTin.Name = "lbCongCOMThongTin";
            this.lbCongCOMThongTin.Size = new System.Drawing.Size(269, 17);
            this.lbCongCOMThongTin.TabIndex = 1;
            // 
            // lbPortThongTin
            // 
            this.lbPortThongTin.Location = new System.Drawing.Point(154, 147);
            this.lbPortThongTin.Name = "lbPortThongTin";
            this.lbPortThongTin.Size = new System.Drawing.Size(269, 17);
            this.lbPortThongTin.TabIndex = 1;
            // 
            // lbDiaChiIPThongTin
            // 
            this.lbDiaChiIPThongTin.Location = new System.Drawing.Point(154, 119);
            this.lbDiaChiIPThongTin.Name = "lbDiaChiIPThongTin";
            this.lbDiaChiIPThongTin.Size = new System.Drawing.Size(269, 17);
            this.lbDiaChiIPThongTin.TabIndex = 1;
            // 
            // lbKieuKetNoiThongTin
            // 
            this.lbKieuKetNoiThongTin.Location = new System.Drawing.Point(154, 88);
            this.lbKieuKetNoiThongTin.Name = "lbKieuKetNoiThongTin";
            this.lbKieuKetNoiThongTin.Size = new System.Drawing.Size(269, 17);
            this.lbKieuKetNoiThongTin.TabIndex = 1;
            // 
            // lbIDMayThongTin
            // 
            this.lbIDMayThongTin.Location = new System.Drawing.Point(154, 60);
            this.lbIDMayThongTin.Name = "lbIDMayThongTin";
            this.lbIDMayThongTin.Size = new System.Drawing.Size(269, 17);
            this.lbIDMayThongTin.TabIndex = 1;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(22, 60);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(55, 17);
            this.label2.TabIndex = 1;
            this.label2.Text = "ID máy:";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(22, 25);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(107, 17);
            this.label1.TabIndex = 1;
            this.label1.Text = "Máy chấm công";
            // 
            // comboBoxMayChamcong
            // 
            this.comboBoxMayChamcong.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxMayChamcong.FormattingEnabled = true;
            this.comboBoxMayChamcong.Location = new System.Drawing.Point(157, 22);
            this.comboBoxMayChamcong.Name = "comboBoxMayChamcong";
            this.comboBoxMayChamcong.Size = new System.Drawing.Size(266, 24);
            this.comboBoxMayChamcong.TabIndex = 0;
            this.comboBoxMayChamcong.SelectedIndexChanged += new System.EventHandler(this.comboBoxMayChamcong_SelectedIndexChanged);
            // 
            // txtSerial
            // 
            this.txtSerial.Location = new System.Drawing.Point(169, 341);
            this.txtSerial.Name = "txtSerial";
            this.txtSerial.Size = new System.Drawing.Size(266, 23);
            this.txtSerial.TabIndex = 2;
            // 
            // txtDangKy
            // 
            this.txtDangKy.Location = new System.Drawing.Point(169, 370);
            this.txtDangKy.Name = "txtDangKy";
            this.txtDangKy.Size = new System.Drawing.Size(266, 23);
            this.txtDangKy.TabIndex = 2;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(34, 344);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(63, 17);
            this.label10.TabIndex = 1;
            this.label10.Text = "Số serial";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(34, 373);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(79, 17);
            this.label11.TabIndex = 1;
            this.label11.Text = "Số đăng ký";
            // 
            // frmDangKyMayChamCong
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(471, 418);
            this.Controls.Add(this.label11);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.txtDangKy);
            this.Controls.Add(this.txtSerial);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.toolStrip1);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "frmDangKyMayChamCong";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Đăng ký máy chấm công";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.frmDangKyMayChamCong_FormClosing);
            this.Load += new System.EventHandler(this.frmDangKyMayChamCong_Load);
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripButton btnKetNoi;
        private System.Windows.Forms.ToolStripButton btnDangKy;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox comboBoxMayChamcong;
        private System.Windows.Forms.TextBox txtSerial;
        private System.Windows.Forms.TextBox txtDangKy;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label lbKetNoiTuXaThongTin;
        private System.Windows.Forms.Label lbDiaChiWebThongTin;
        private System.Windows.Forms.Label lbTocDoTruyenThongTin;
        private System.Windows.Forms.Label lbCongCOMThongTin;
        private System.Windows.Forms.Label lbPortThongTin;
        private System.Windows.Forms.Label lbDiaChiIPThongTin;
        private System.Windows.Forms.Label lbKieuKetNoiThongTin;
        private System.Windows.Forms.Label lbIDMayThongTin;
    }
}