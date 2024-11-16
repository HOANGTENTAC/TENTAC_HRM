namespace TENTAC_HRM.Forms.Category
{
    partial class frm_story
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
            this.panel2 = new System.Windows.Forms.Panel();
            this.btn_close = new System.Windows.Forms.Button();
            this.btn_save_close = new System.Windows.Forms.Button();
            this.btn_save_add = new System.Windows.Forms.Button();
            this.cbo_QuocGia = new DevComponents.DotNetBar.Controls.ComboBoxEx();
            this.cbo_DenNam = new DevComponents.DotNetBar.Controls.ComboBoxEx();
            this.cbo_TuNam = new DevComponents.DotNetBar.Controls.ComboBoxEx();
            this.labelX1 = new DevComponents.DotNetBar.LabelX();
            this.txt_cong_viec = new DevComponents.DotNetBar.Controls.TextBoxX();
            this.label4 = new DevComponents.DotNetBar.LabelX();
            this.label3 = new DevComponents.DotNetBar.LabelX();
            this.label2 = new DevComponents.DotNetBar.LabelX();
            this.label1 = new DevComponents.DotNetBar.LabelX();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.panel2);
            this.panel1.Controls.Add(this.cbo_QuocGia);
            this.panel1.Controls.Add(this.cbo_DenNam);
            this.panel1.Controls.Add(this.cbo_TuNam);
            this.panel1.Controls.Add(this.labelX1);
            this.panel1.Controls.Add(this.txt_cong_viec);
            this.panel1.Controls.Add(this.label4);
            this.panel1.Controls.Add(this.label3);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(342, 382);
            this.panel1.TabIndex = 0;
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(16)))), ((int)(((byte)(39)))), ((int)(((byte)(75)))));
            this.panel2.Controls.Add(this.btn_close);
            this.panel2.Controls.Add(this.btn_save_close);
            this.panel2.Controls.Add(this.btn_save_add);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel2.Location = new System.Drawing.Point(0, 327);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(342, 55);
            this.panel2.TabIndex = 23;
            // 
            // btn_close
            // 
            this.btn_close.Image = global::TENTAC_HRM.Properties.Resources.clear;
            this.btn_close.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btn_close.Location = new System.Drawing.Point(245, 11);
            this.btn_close.Name = "btn_close";
            this.btn_close.Size = new System.Drawing.Size(71, 30);
            this.btn_close.TabIndex = 7;
            this.btn_close.Text = "Đóng";
            this.btn_close.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btn_close.UseVisualStyleBackColor = true;
            this.btn_close.Click += new System.EventHandler(this.btn_close_Click);
            // 
            // btn_save_close
            // 
            this.btn_save_close.Image = global::TENTAC_HRM.Properties.Resources.diskette;
            this.btn_save_close.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btn_save_close.Location = new System.Drawing.Point(136, 11);
            this.btn_save_close.Name = "btn_save_close";
            this.btn_save_close.Size = new System.Drawing.Size(105, 30);
            this.btn_save_close.TabIndex = 6;
            this.btn_save_close.Text = "Lưu & thoát";
            this.btn_save_close.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btn_save_close.UseMnemonic = false;
            this.btn_save_close.UseVisualStyleBackColor = true;
            this.btn_save_close.Click += new System.EventHandler(this.btn_save_close_Click);
            // 
            // btn_save_add
            // 
            this.btn_save_add.Image = global::TENTAC_HRM.Properties.Resources.diskette;
            this.btn_save_add.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btn_save_add.Location = new System.Drawing.Point(25, 11);
            this.btn_save_add.Name = "btn_save_add";
            this.btn_save_add.Size = new System.Drawing.Size(105, 30);
            this.btn_save_add.TabIndex = 5;
            this.btn_save_add.Text = "Lưu & thêm";
            this.btn_save_add.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btn_save_add.UseMnemonic = false;
            this.btn_save_add.UseVisualStyleBackColor = true;
            this.btn_save_add.Click += new System.EventHandler(this.btn_save_add_Click);
            // 
            // cbo_QuocGia
            // 
            this.cbo_QuocGia.DisplayMember = "Text";
            this.cbo_QuocGia.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.cbo_QuocGia.FormattingEnabled = true;
            this.cbo_QuocGia.ItemHeight = 17;
            this.cbo_QuocGia.Location = new System.Drawing.Point(28, 280);
            this.cbo_QuocGia.Name = "cbo_QuocGia";
            this.cbo_QuocGia.Size = new System.Drawing.Size(288, 23);
            this.cbo_QuocGia.TabIndex = 4;
            // 
            // cbo_DenNam
            // 
            this.cbo_DenNam.DisplayMember = "Text";
            this.cbo_DenNam.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.cbo_DenNam.FormattingEnabled = true;
            this.cbo_DenNam.ItemHeight = 17;
            this.cbo_DenNam.Location = new System.Drawing.Point(182, 99);
            this.cbo_DenNam.Name = "cbo_DenNam";
            this.cbo_DenNam.Size = new System.Drawing.Size(134, 23);
            this.cbo_DenNam.TabIndex = 2;
            // 
            // cbo_TuNam
            // 
            this.cbo_TuNam.DisplayMember = "Text";
            this.cbo_TuNam.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.cbo_TuNam.FormattingEnabled = true;
            this.cbo_TuNam.ItemHeight = 17;
            this.cbo_TuNam.Location = new System.Drawing.Point(28, 99);
            this.cbo_TuNam.Name = "cbo_TuNam";
            this.cbo_TuNam.Size = new System.Drawing.Size(134, 23);
            this.cbo_TuNam.TabIndex = 1;
            // 
            // labelX1
            // 
            this.labelX1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(16)))), ((int)(((byte)(39)))), ((int)(((byte)(75)))));
            this.labelX1.Dock = System.Windows.Forms.DockStyle.Top;
            this.labelX1.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelX1.ForeColor = System.Drawing.Color.WhiteSmoke;
            this.labelX1.Location = new System.Drawing.Point(0, 0);
            this.labelX1.Name = "labelX1";
            this.labelX1.Size = new System.Drawing.Size(342, 58);
            this.labelX1.TabIndex = 19;
            this.labelX1.Text = "Tiểu sử, Kinh nghiệm";
            this.labelX1.TextAlignment = System.Drawing.StringAlignment.Center;
            // 
            // txt_cong_viec
            // 
            // 
            // 
            // 
            this.txt_cong_viec.Border.Class = "TextBoxBorder";
            this.txt_cong_viec.Location = new System.Drawing.Point(28, 155);
            this.txt_cong_viec.Multiline = true;
            this.txt_cong_viec.Name = "txt_cong_viec";
            this.txt_cong_viec.Size = new System.Drawing.Size(288, 90);
            this.txt_cong_viec.TabIndex = 3;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(25, 258);
            this.label4.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(62, 19);
            this.label4.TabIndex = 8;
            this.label4.Text = "Quốc gia";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(25, 133);
            this.label3.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(93, 19);
            this.label3.TabIndex = 9;
            this.label3.Text = "Làm gì, Ở đâu";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(182, 77);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(62, 19);
            this.label2.TabIndex = 10;
            this.label2.Text = "Đến năm";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(28, 77);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(53, 19);
            this.label1.TabIndex = 11;
            this.label1.Text = "Từ năm";
            // 
            // frm_story
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(342, 382);
            this.Controls.Add(this.panel1);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.KeyPreview = true;
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "frm_story";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "TIểu sử, Kinh nghiệm";
            this.Load += new System.EventHandler(this.frm_story_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.frm_story_KeyDown);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private DevComponents.DotNetBar.LabelX labelX1;
        private System.Windows.Forms.Button btn_save_add;
        private System.Windows.Forms.Button btn_save_close;
        private System.Windows.Forms.Button btn_close;
        private DevComponents.DotNetBar.Controls.TextBoxX txt_cong_viec;
        private DevComponents.DotNetBar.LabelX label4;
        private DevComponents.DotNetBar.LabelX label3;
        private DevComponents.DotNetBar.LabelX label2;
        private DevComponents.DotNetBar.LabelX label1;
        private DevComponents.DotNetBar.Controls.ComboBoxEx cbo_TuNam;
        private DevComponents.DotNetBar.Controls.ComboBoxEx cbo_DenNam;
        private DevComponents.DotNetBar.Controls.ComboBoxEx cbo_QuocGia;
        private System.Windows.Forms.Panel panel2;
    }
}