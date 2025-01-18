using DevComponents.DotNetBar.Controls;
using DevComponents.DotNetBar;
using System;
using System.Windows.Forms;
namespace TENTAC_HRM.Forms.Common
{
    partial class frm_LoadTinhCong
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
            this.lbTenNhanVien = new global::DevComponents.DotNetBar.LabelX();
            this.lbDangTinh = new global::DevComponents.DotNetBar.LabelX();
            this.panel1 = new global::System.Windows.Forms.Panel();
            this.panel2 = new global::System.Windows.Forms.Panel();
            this.panel3 = new global::System.Windows.Forms.Panel();
            this.panel4 = new global::System.Windows.Forms.Panel();
            this.progressBarX1 = new global::DevComponents.DotNetBar.Controls.ProgressBarX();
            base.SuspendLayout();
            this.lbTenNhanVien.AutoSize = true;
            this.lbTenNhanVien.BackColor = global::System.Drawing.Color.Transparent;
            this.lbTenNhanVien.Font = new global::System.Drawing.Font("Tahoma", 12f, global::System.Drawing.FontStyle.Regular, global::System.Drawing.GraphicsUnit.Point, 0);
            this.lbTenNhanVien.Location = new global::System.Drawing.Point(14, 47);
            this.lbTenNhanVien.Name = "lbTenNhanVien";
            this.lbTenNhanVien.Size = new global::System.Drawing.Size(53, 22);
            this.lbTenNhanVien.TabIndex = 0;
            this.lbTenNhanVien.Text = "labelX1";
            this.lbDangTinh.AutoSize = true;
            this.lbDangTinh.BackColor = global::System.Drawing.Color.Transparent;
            this.lbDangTinh.Font = new global::System.Drawing.Font("Tahoma", 12f, global::System.Drawing.FontStyle.Regular, global::System.Drawing.GraphicsUnit.Point, 0);
            this.lbDangTinh.Location = new global::System.Drawing.Point(15, 12);
            this.lbDangTinh.Name = "lbDangTinh";
            this.lbDangTinh.Size = new global::System.Drawing.Size(53, 22);
            this.lbDangTinh.TabIndex = 0;
            this.lbDangTinh.Text = "labelX1";
            this.panel1.BorderStyle = global::System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel1.Dock = global::System.Windows.Forms.DockStyle.Left;
            this.panel1.Location = new global::System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new global::System.Drawing.Size(1, 116);
            this.panel1.TabIndex = 3;
            this.panel2.BorderStyle = global::System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel2.Dock = global::System.Windows.Forms.DockStyle.Top;
            this.panel2.Location = new global::System.Drawing.Point(1, 0);
            this.panel2.Name = "panel2";
            this.panel2.Size = new global::System.Drawing.Size(421, 1);
            this.panel2.TabIndex = 4;
            this.panel3.BorderStyle = global::System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel3.Dock = global::System.Windows.Forms.DockStyle.Right;
            this.panel3.Location = new global::System.Drawing.Point(421, 1);
            this.panel3.Name = "panel3";
            this.panel3.Size = new global::System.Drawing.Size(1, 115);
            this.panel3.TabIndex = 5;
            this.panel4.BorderStyle = global::System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel4.Dock = global::System.Windows.Forms.DockStyle.Bottom;
            this.panel4.Location = new global::System.Drawing.Point(1, 115);
            this.panel4.Name = "panel4";
            this.panel4.Size = new global::System.Drawing.Size(420, 1);
            this.panel4.TabIndex = 6;
            this.progressBarX1.FocusCuesEnabled = false;
            this.progressBarX1.Location = new global::System.Drawing.Point(12, 84);
            this.progressBarX1.Name = "progressBarX1";
            this.progressBarX1.Size = new global::System.Drawing.Size(398, 23);
            this.progressBarX1.TabIndex = 7;
            this.progressBarX1.TextVisible = true;
            base.AutoScaleDimensions = new global::System.Drawing.SizeF(7f, 14f);
            base.AutoScaleMode = global::System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = global::System.Drawing.Color.White;
            this.BackgroundImageLayout = global::System.Windows.Forms.ImageLayout.Stretch;
            base.ClientSize = new global::System.Drawing.Size(422, 116);
            base.Controls.Add(this.progressBarX1);
            base.Controls.Add(this.panel4);
            base.Controls.Add(this.panel3);
            base.Controls.Add(this.panel2);
            base.Controls.Add(this.panel1);
            base.Controls.Add(this.lbDangTinh);
            base.Controls.Add(this.lbTenNhanVien);
            this.DoubleBuffered = true;
            this.Font = new global::System.Drawing.Font("Tahoma", 9f, global::System.Drawing.FontStyle.Regular, global::System.Drawing.GraphicsUnit.Point, 0);
            base.FormBorderStyle = global::System.Windows.Forms.FormBorderStyle.None;
            base.Name = "frmLoadTinhCong";
            base.ShowInTaskbar = false;
            base.StartPosition = global::System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "frmLoadTinhCong";
            base.Load += new global::System.EventHandler(frm_LoadTinhCong_Load);
            base.ResumeLayout(false);
            base.PerformLayout();

        }
        public LabelX lbDangTinh;

        public LabelX lbTenNhanVien;

        private Panel panel1;

        private Panel panel2;

        private Panel panel3;

        private Panel panel4;

        public ProgressBarX progressBarX1;
        #endregion
    }
}