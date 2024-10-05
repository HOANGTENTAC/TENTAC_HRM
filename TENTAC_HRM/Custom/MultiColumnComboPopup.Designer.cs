namespace TENTAC_HRM.Custom
{
    partial class MultiColumnComboPopup
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
            this.lstvMyView = new System.Windows.Forms.ListView();
            this.SuspendLayout();
            // 
            // lstvMyView
            // 
            this.lstvMyView.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lstvMyView.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lstvMyView.FullRowSelect = true;
            this.lstvMyView.GridLines = true;
            this.lstvMyView.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.Nonclickable;
            this.lstvMyView.MultiSelect = false;
            this.lstvMyView.Name = "lstvMyView";
            this.lstvMyView.Size = new System.Drawing.Size(292, 88);
            this.lstvMyView.TabIndex = 0;
            this.lstvMyView.View = System.Windows.Forms.View.Details;
            this.lstvMyView.KeyDown += new System.Windows.Forms.KeyEventHandler(this.lstvMyView_KeyDown);
            this.lstvMyView.DoubleClick += new System.EventHandler(this.lstvMyView_DoubleClick);
            // 
            // MultiColumnComboPopup
            // 
            this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
            this.ClientSize = new System.Drawing.Size(292, 88);
            this.ControlBox = false;
            this.Controls.AddRange(new System.Windows.Forms.Control[] {
                                                                          this.lstvMyView});
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.KeyPreview = true;
            this.Name = "MultiColumnComboPopup";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.Manual;
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.MultiColumnComboPopup_KeyDown);
            this.Leave += new System.EventHandler(this.MultiColumnComboPopup_Leave);
            this.Deactivate += new System.EventHandler(this.MultiColumnComboPopup_Deactivate);
            this.ResumeLayout(false);
        }

        #endregion
    }
}