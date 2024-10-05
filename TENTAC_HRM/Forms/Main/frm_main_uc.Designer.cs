namespace TENTAC_HRM
{
    partial class frm_main_uc
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
            this.pl_main = new System.Windows.Forms.Panel();
            this.SuspendLayout();
            // 
            // pl_main
            // 
            this.pl_main.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pl_main.Location = new System.Drawing.Point(0, 0);
            this.pl_main.Name = "pl_main";
            this.pl_main.Size = new System.Drawing.Size(1159, 597);
            this.pl_main.TabIndex = 0;
            // 
            // frm_main_uc
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.ClientSize = new System.Drawing.Size(1159, 597);
            this.Controls.Add(this.pl_main);
            this.KeyPreview = true;
            this.Name = "frm_main_uc";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "frm_main_uc";
            this.Load += new System.EventHandler(this.frm_main_uc_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.frm_main_uc_KeyDown);
            this.Resize += new System.EventHandler(this.frm_main_uc_Resize);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel pl_main;
    }
}