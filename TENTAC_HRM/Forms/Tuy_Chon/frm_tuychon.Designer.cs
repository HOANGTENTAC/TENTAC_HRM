namespace TENTAC_HRM.Forms.Tuy_Chon
{
    partial class frm_tuychon
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frm_tuychon));
            this.imageList1 = new System.Windows.Forms.ImageList(this.components);
            this.tc_congthuc_luong = new TENTAC_HRM.Custom.CustomTabControl();
            this.tp_congthuc_luong = new System.Windows.Forms.TabPage();
            this.pl_dinhmucluong = new System.Windows.Forms.Panel();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.tc_congthuc_luong.SuspendLayout();
            this.tp_congthuc_luong.SuspendLayout();
            this.SuspendLayout();
            // 
            // imageList1
            // 
            this.imageList1.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imageList1.ImageStream")));
            this.imageList1.TransparentColor = System.Drawing.Color.Transparent;
            this.imageList1.Images.SetKeyName(0, "7-days_32X32.png");
            this.imageList1.Images.SetKeyName(1, "btnBook.png");
            // 
            // tc_congthuc_luong
            // 
            this.tc_congthuc_luong.Alignment = System.Windows.Forms.TabAlignment.Left;
            this.tc_congthuc_luong.Controls.Add(this.tp_congthuc_luong);
            this.tc_congthuc_luong.Controls.Add(this.tabPage2);
            this.tc_congthuc_luong.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tc_congthuc_luong.ImageList = this.imageList1;
            this.tc_congthuc_luong.ItemSize = new System.Drawing.Size(44, 180);
            this.tc_congthuc_luong.Location = new System.Drawing.Point(0, 0);
            this.tc_congthuc_luong.Multiline = true;
            this.tc_congthuc_luong.Name = "tc_congthuc_luong";
            this.tc_congthuc_luong.SelectedIndex = 0;
            this.tc_congthuc_luong.Size = new System.Drawing.Size(819, 606);
            this.tc_congthuc_luong.SizeMode = System.Windows.Forms.TabSizeMode.Fixed;
            this.tc_congthuc_luong.TabIndex = 0;
            this.tc_congthuc_luong.SelectedIndexChanged += new System.EventHandler(this.tb_congthuc_luong_SelectedIndexChanged);
            // 
            // tp_congthuc_luong
            // 
            this.tp_congthuc_luong.Controls.Add(this.pl_dinhmucluong);
            this.tp_congthuc_luong.ImageIndex = 0;
            this.tp_congthuc_luong.Location = new System.Drawing.Point(184, 4);
            this.tp_congthuc_luong.Name = "tp_congthuc_luong";
            this.tp_congthuc_luong.Padding = new System.Windows.Forms.Padding(3);
            this.tp_congthuc_luong.Size = new System.Drawing.Size(631, 598);
            this.tp_congthuc_luong.TabIndex = 0;
            this.tp_congthuc_luong.Text = "            Định mức lương";
            this.tp_congthuc_luong.UseVisualStyleBackColor = true;
            // 
            // pl_dinhmucluong
            // 
            this.pl_dinhmucluong.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pl_dinhmucluong.Location = new System.Drawing.Point(3, 3);
            this.pl_dinhmucluong.Name = "pl_dinhmucluong";
            this.pl_dinhmucluong.Size = new System.Drawing.Size(625, 592);
            this.pl_dinhmucluong.TabIndex = 0;
            // 
            // tabPage2
            // 
            this.tabPage2.ImageIndex = 1;
            this.tabPage2.Location = new System.Drawing.Point(184, 4);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(631, 598);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "            tabPage2";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // frm_tuychon
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(819, 606);
            this.Controls.Add(this.tc_congthuc_luong);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "frm_tuychon";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Tùy chọn";
            this.Load += new System.EventHandler(this.frm_tuychon_Load);
            this.tc_congthuc_luong.ResumeLayout(false);
            this.tp_congthuc_luong.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.ImageList imageList1;
        private Custom.CustomTabControl tc_congthuc_luong;
        private System.Windows.Forms.TabPage tp_congthuc_luong;
        private System.Windows.Forms.Panel pl_dinhmucluong;
        private System.Windows.Forms.TabPage tabPage2;
    }
}