namespace TENTAC_HRM
{
    partial class frm_chart_management
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
            this.pl_main = new System.Windows.Forms.Panel();
            this.btn_cau_truc = new System.Windows.Forms.Button();
            this.btn_chuc_vu = new System.Windows.Forms.Button();
            this.btn_phong_ban = new System.Windows.Forms.Button();
            this.btn_khu_vuc = new System.Windows.Forms.Button();
            this.btn_cong_ty = new System.Windows.Forms.Button();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.btn_cau_truc);
            this.panel1.Controls.Add(this.btn_chuc_vu);
            this.panel1.Controls.Add(this.btn_phong_ban);
            this.panel1.Controls.Add(this.btn_khu_vuc);
            this.panel1.Controls.Add(this.btn_cong_ty);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Left;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Margin = new System.Windows.Forms.Padding(4);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(142, 500);
            this.panel1.TabIndex = 0;
            // 
            // pl_main
            // 
            this.pl_main.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pl_main.Location = new System.Drawing.Point(142, 0);
            this.pl_main.Margin = new System.Windows.Forms.Padding(4);
            this.pl_main.Name = "pl_main";
            this.pl_main.Size = new System.Drawing.Size(590, 500);
            this.pl_main.TabIndex = 1;
            // 
            // btn_cau_truc
            // 
            this.btn_cau_truc.Dock = System.Windows.Forms.DockStyle.Top;
            this.btn_cau_truc.FlatAppearance.BorderSize = 0;
            this.btn_cau_truc.Image = global::TENTAC_HRM.Properties.Resources.hierarchical;
            this.btn_cau_truc.ImageAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btn_cau_truc.Location = new System.Drawing.Point(0, 400);
            this.btn_cau_truc.Margin = new System.Windows.Forms.Padding(4);
            this.btn_cau_truc.Name = "btn_cau_truc";
            this.btn_cau_truc.Size = new System.Drawing.Size(142, 100);
            this.btn_cau_truc.TabIndex = 4;
            this.btn_cau_truc.Text = "Cấu trúc công ty";
            this.btn_cau_truc.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.btn_cau_truc.UseVisualStyleBackColor = true;
            this.btn_cau_truc.Click += new System.EventHandler(this.btn_cau_truc_Click);
            // 
            // btn_chuc_vu
            // 
            this.btn_chuc_vu.Dock = System.Windows.Forms.DockStyle.Top;
            this.btn_chuc_vu.FlatAppearance.BorderSize = 0;
            this.btn_chuc_vu.Image = global::TENTAC_HRM.Properties.Resources.growth;
            this.btn_chuc_vu.ImageAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btn_chuc_vu.Location = new System.Drawing.Point(0, 300);
            this.btn_chuc_vu.Margin = new System.Windows.Forms.Padding(4);
            this.btn_chuc_vu.Name = "btn_chuc_vu";
            this.btn_chuc_vu.Size = new System.Drawing.Size(142, 100);
            this.btn_chuc_vu.TabIndex = 3;
            this.btn_chuc_vu.Text = "Chức vụ";
            this.btn_chuc_vu.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.btn_chuc_vu.UseVisualStyleBackColor = true;
            this.btn_chuc_vu.Click += new System.EventHandler(this.btn_chuc_vu_Click);
            // 
            // btn_phong_ban
            // 
            this.btn_phong_ban.Dock = System.Windows.Forms.DockStyle.Top;
            this.btn_phong_ban.FlatAppearance.BorderSize = 0;
            this.btn_phong_ban.Image = global::TENTAC_HRM.Properties.Resources.department;
            this.btn_phong_ban.ImageAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btn_phong_ban.Location = new System.Drawing.Point(0, 200);
            this.btn_phong_ban.Margin = new System.Windows.Forms.Padding(4);
            this.btn_phong_ban.Name = "btn_phong_ban";
            this.btn_phong_ban.Size = new System.Drawing.Size(142, 100);
            this.btn_phong_ban.TabIndex = 2;
            this.btn_phong_ban.Text = "Phòng ban";
            this.btn_phong_ban.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.btn_phong_ban.UseVisualStyleBackColor = true;
            this.btn_phong_ban.Click += new System.EventHandler(this.btn_phong_ban_Click);
            // 
            // btn_khu_vuc
            // 
            this.btn_khu_vuc.Dock = System.Windows.Forms.DockStyle.Top;
            this.btn_khu_vuc.FlatAppearance.BorderSize = 0;
            this.btn_khu_vuc.Image = global::TENTAC_HRM.Properties.Resources.local;
            this.btn_khu_vuc.ImageAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btn_khu_vuc.Location = new System.Drawing.Point(0, 100);
            this.btn_khu_vuc.Margin = new System.Windows.Forms.Padding(4);
            this.btn_khu_vuc.Name = "btn_khu_vuc";
            this.btn_khu_vuc.Size = new System.Drawing.Size(142, 100);
            this.btn_khu_vuc.TabIndex = 1;
            this.btn_khu_vuc.Text = "Khu vực";
            this.btn_khu_vuc.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.btn_khu_vuc.UseVisualStyleBackColor = true;
            this.btn_khu_vuc.Click += new System.EventHandler(this.btn_khu_vuc_Click);
            // 
            // btn_cong_ty
            // 
            this.btn_cong_ty.Dock = System.Windows.Forms.DockStyle.Top;
            this.btn_cong_ty.FlatAppearance.BorderSize = 0;
            this.btn_cong_ty.Image = global::TENTAC_HRM.Properties.Resources.company;
            this.btn_cong_ty.ImageAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btn_cong_ty.Location = new System.Drawing.Point(0, 0);
            this.btn_cong_ty.Margin = new System.Windows.Forms.Padding(4);
            this.btn_cong_ty.Name = "btn_cong_ty";
            this.btn_cong_ty.Size = new System.Drawing.Size(142, 100);
            this.btn_cong_ty.TabIndex = 0;
            this.btn_cong_ty.Text = "Công ty";
            this.btn_cong_ty.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.btn_cong_ty.UseVisualStyleBackColor = true;
            this.btn_cong_ty.Click += new System.EventHandler(this.btn_cong_ty_Click);
            // 
            // frm_chart_management
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(732, 500);
            this.Controls.Add(this.pl_main);
            this.Controls.Add(this.panel1);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.KeyPreview = true;
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "frm_chart_management";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Sơ đồ quản lý";
            this.Load += new System.EventHandler(this.frm_chart_management_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.frm_chart_management_KeyDown);
            this.panel1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button btn_cau_truc;
        private System.Windows.Forms.Button btn_chuc_vu;
        private System.Windows.Forms.Button btn_phong_ban;
        private System.Windows.Forms.Button btn_khu_vuc;
        private System.Windows.Forms.Button btn_cong_ty;
        private System.Windows.Forms.Panel pl_main;
    }
}