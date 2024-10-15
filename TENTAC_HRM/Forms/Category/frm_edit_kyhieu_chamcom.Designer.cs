namespace TENTAC_HRM.Forms.Category
{
    partial class frm_edit_kyhieu_chamcom
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
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.txt_ma = new System.Windows.Forms.TextBox();
            this.txt_ten = new System.Windows.Forms.TextBox();
            this.nbr_phantram = new System.Windows.Forms.NumericUpDown();
            this.label4 = new System.Windows.Forms.Label();
            this.btn_close = new System.Windows.Forms.Button();
            this.btn_save_add = new System.Windows.Forms.Button();
            this.btn_save_close = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.nbr_phantram)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(15, 16);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(31, 17);
            this.label1.TabIndex = 0;
            this.label1.Text = "Mã:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(15, 45);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(86, 17);
            this.label2.TabIndex = 0;
            this.label2.Text = "Tên ký hiệu:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(15, 73);
            this.label3.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(73, 17);
            this.label3.TabIndex = 0;
            this.label3.Text = "Trừ lương:";
            // 
            // txt_ma
            // 
            this.txt_ma.Location = new System.Drawing.Point(121, 13);
            this.txt_ma.Name = "txt_ma";
            this.txt_ma.Size = new System.Drawing.Size(221, 23);
            this.txt_ma.TabIndex = 0;
            // 
            // txt_ten
            // 
            this.txt_ten.Location = new System.Drawing.Point(121, 42);
            this.txt_ten.Name = "txt_ten";
            this.txt_ten.Size = new System.Drawing.Size(221, 23);
            this.txt_ten.TabIndex = 1;
            // 
            // nbr_phantram
            // 
            this.nbr_phantram.Location = new System.Drawing.Point(121, 71);
            this.nbr_phantram.Name = "nbr_phantram";
            this.nbr_phantram.Size = new System.Drawing.Size(82, 23);
            this.nbr_phantram.TabIndex = 2;
            this.nbr_phantram.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(210, 73);
            this.label4.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(124, 17);
            this.label4.TabIndex = 0;
            this.label4.Text = "% x lương căn bản";
            // 
            // btn_close
            // 
            this.btn_close.Image = global::TENTAC_HRM.Properties.Resources.cancel;
            this.btn_close.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btn_close.Location = new System.Drawing.Point(252, 100);
            this.btn_close.Name = "btn_close";
            this.btn_close.Size = new System.Drawing.Size(90, 31);
            this.btn_close.TabIndex = 5;
            this.btn_close.Text = "Đóng";
            this.btn_close.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btn_close.UseVisualStyleBackColor = true;
            this.btn_close.Click += new System.EventHandler(this.btn_close_Click);
            // 
            // btn_save_add
            // 
            this.btn_save_add.Image = global::TENTAC_HRM.Properties.Resources.diskette;
            this.btn_save_add.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btn_save_add.Location = new System.Drawing.Point(131, 100);
            this.btn_save_add.Name = "btn_save_add";
            this.btn_save_add.Size = new System.Drawing.Size(115, 31);
            this.btn_save_add.TabIndex = 4;
            this.btn_save_add.Text = "Lưu & Thêm";
            this.btn_save_add.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btn_save_add.UseMnemonic = false;
            this.btn_save_add.UseVisualStyleBackColor = true;
            this.btn_save_add.Click += new System.EventHandler(this.btn_save_add_Click);
            // 
            // btn_save_close
            // 
            this.btn_save_close.Image = global::TENTAC_HRM.Properties.Resources.diskette;
            this.btn_save_close.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btn_save_close.Location = new System.Drawing.Point(18, 100);
            this.btn_save_close.Name = "btn_save_close";
            this.btn_save_close.Size = new System.Drawing.Size(107, 31);
            this.btn_save_close.TabIndex = 3;
            this.btn_save_close.Text = "Lưu & Đóng";
            this.btn_save_close.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btn_save_close.UseMnemonic = false;
            this.btn_save_close.UseVisualStyleBackColor = true;
            this.btn_save_close.Click += new System.EventHandler(this.btn_save_close_Click);
            // 
            // frm_edit_kyhieu_chamcom
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(357, 148);
            this.Controls.Add(this.btn_save_close);
            this.Controls.Add(this.btn_save_add);
            this.Controls.Add(this.btn_close);
            this.Controls.Add(this.nbr_phantram);
            this.Controls.Add(this.txt_ten);
            this.Controls.Add(this.txt_ma);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.Name = "frm_edit_kyhieu_chamcom";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Thêm ký hiệu chấm công";
            this.Load += new System.EventHandler(this.frm_edit_kyhieu_chamcom_Load);
            ((System.ComponentModel.ISupportInitialize)(this.nbr_phantram)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txt_ma;
        private System.Windows.Forms.TextBox txt_ten;
        private System.Windows.Forms.NumericUpDown nbr_phantram;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button btn_close;
        private System.Windows.Forms.Button btn_save_add;
        private System.Windows.Forms.Button btn_save_close;
    }
}