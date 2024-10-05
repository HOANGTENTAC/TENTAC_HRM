namespace TENTAC_HRM.Category
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
            this.label1 = new System.Windows.Forms.Label();
            this.txt_tu_nam = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.txt_den_nam = new System.Windows.Forms.TextBox();
            this.txt_cong_viec = new System.Windows.Forms.TextBox();
            this.cbo_quoc_gia = new System.Windows.Forms.ComboBox();
            this.btn_close = new System.Windows.Forms.Button();
            this.btn_save_close = new System.Windows.Forms.Button();
            this.btn_save_add = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(32, 15);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(56, 17);
            this.label1.TabIndex = 0;
            this.label1.Text = "Từ năm";
            // 
            // txt_tu_nam
            // 
            this.txt_tu_nam.Location = new System.Drawing.Point(147, 12);
            this.txt_tu_nam.MaxLength = 4;
            this.txt_tu_nam.Name = "txt_tu_nam";
            this.txt_tu_nam.Size = new System.Drawing.Size(288, 23);
            this.txt_tu_nam.TabIndex = 0;
            this.txt_tu_nam.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txt_tu_nam_KeyPress);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(32, 44);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(65, 17);
            this.label2.TabIndex = 0;
            this.label2.Text = "Đến năm";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(32, 73);
            this.label3.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(97, 17);
            this.label3.TabIndex = 0;
            this.label3.Text = "Làm gì, Ở đâu";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(32, 169);
            this.label4.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(65, 17);
            this.label4.TabIndex = 0;
            this.label4.Text = "Quốc gia";
            // 
            // txt_den_nam
            // 
            this.txt_den_nam.Location = new System.Drawing.Point(147, 41);
            this.txt_den_nam.MaxLength = 4;
            this.txt_den_nam.Name = "txt_den_nam";
            this.txt_den_nam.Size = new System.Drawing.Size(288, 23);
            this.txt_den_nam.TabIndex = 1;
            // 
            // txt_cong_viec
            // 
            this.txt_cong_viec.Location = new System.Drawing.Point(147, 70);
            this.txt_cong_viec.Multiline = true;
            this.txt_cong_viec.Name = "txt_cong_viec";
            this.txt_cong_viec.Size = new System.Drawing.Size(288, 90);
            this.txt_cong_viec.TabIndex = 2;
            // 
            // cbo_quoc_gia
            // 
            this.cbo_quoc_gia.FormattingEnabled = true;
            this.cbo_quoc_gia.Location = new System.Drawing.Point(147, 166);
            this.cbo_quoc_gia.Name = "cbo_quoc_gia";
            this.cbo_quoc_gia.Size = new System.Drawing.Size(263, 24);
            this.cbo_quoc_gia.TabIndex = 3;
            // 
            // btn_close
            // 
            this.btn_close.Image = global::TENTAC_HRM.Properties.Resources.clear;
            this.btn_close.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btn_close.Location = new System.Drawing.Point(327, 213);
            this.btn_close.Name = "btn_close";
            this.btn_close.Size = new System.Drawing.Size(108, 30);
            this.btn_close.TabIndex = 6;
            this.btn_close.Text = "Đóng";
            this.btn_close.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btn_close.UseVisualStyleBackColor = true;
            this.btn_close.Click += new System.EventHandler(this.btn_close_Click);
            // 
            // btn_save_close
            // 
            this.btn_save_close.Image = global::TENTAC_HRM.Properties.Resources.diskette;
            this.btn_save_close.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btn_save_close.Location = new System.Drawing.Point(178, 213);
            this.btn_save_close.Name = "btn_save_close";
            this.btn_save_close.Size = new System.Drawing.Size(143, 30);
            this.btn_save_close.TabIndex = 5;
            this.btn_save_close.Text = "Lưu & thoát";
            this.btn_save_close.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btn_save_close.UseMnemonic = false;
            this.btn_save_close.UseVisualStyleBackColor = true;
            // 
            // btn_save_add
            // 
            this.btn_save_add.Image = global::TENTAC_HRM.Properties.Resources.diskette;
            this.btn_save_add.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btn_save_add.Location = new System.Drawing.Point(35, 213);
            this.btn_save_add.Name = "btn_save_add";
            this.btn_save_add.Size = new System.Drawing.Size(137, 30);
            this.btn_save_add.TabIndex = 4;
            this.btn_save_add.Text = "Lưu & thêm";
            this.btn_save_add.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btn_save_add.UseMnemonic = false;
            this.btn_save_add.UseVisualStyleBackColor = true;
            this.btn_save_add.Click += new System.EventHandler(this.btn_save_add_Click);
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(410, 165);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(26, 26);
            this.button1.TabIndex = 3;
            this.button1.Text = "+";
            this.button1.UseVisualStyleBackColor = true;
            // 
            // frm_story
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(462, 252);
            this.Controls.Add(this.btn_save_add);
            this.Controls.Add(this.btn_save_close);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.btn_close);
            this.Controls.Add(this.cbo_quoc_gia);
            this.Controls.Add(this.txt_cong_viec);
            this.Controls.Add(this.txt_den_nam);
            this.Controls.Add(this.txt_tu_nam);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.KeyPreview = true;
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "frm_story";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "TIểu sử, Kinh nghiệm";
            this.Load += new System.EventHandler(this.frm_story_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.frm_story_KeyDown);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txt_tu_nam;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txt_den_nam;
        private System.Windows.Forms.TextBox txt_cong_viec;
        private System.Windows.Forms.ComboBox cbo_quoc_gia;
        private System.Windows.Forms.Button btn_close;
        private System.Windows.Forms.Button btn_save_close;
        private System.Windows.Forms.Button btn_save_add;
        private System.Windows.Forms.Button button1;
    }
}