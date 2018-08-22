namespace _ve_Walker
{
    partial class frmEditor
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
            this.tabEditor = new System.Windows.Forms.TabControl();
            this.tabXY = new System.Windows.Forms.TabPage();
            this.tabYpi = new System.Windows.Forms.TabPage();
            this.tabEditor.SuspendLayout();
            this.SuspendLayout();
            // 
            // tabEditor
            // 
            this.tabEditor.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.tabEditor.Controls.Add(this.tabXY);
            this.tabEditor.Controls.Add(this.tabYpi);
            this.tabEditor.Location = new System.Drawing.Point(3, 0);
            this.tabEditor.Name = "tabEditor";
            this.tabEditor.SelectedIndex = 0;
            this.tabEditor.Size = new System.Drawing.Size(583, 575);
            this.tabEditor.TabIndex = 0;
            // 
            // tabXY
            // 
            this.tabXY.Location = new System.Drawing.Point(4, 22);
            this.tabXY.Name = "tabXY";
            this.tabXY.Padding = new System.Windows.Forms.Padding(3);
            this.tabXY.Size = new System.Drawing.Size(575, 549);
            this.tabXY.TabIndex = 0;
            this.tabXY.Text = "ZX";
            this.tabXY.UseVisualStyleBackColor = true;
            this.tabXY.Click += new System.EventHandler(this.tabXY_Click);
            this.tabXY.Paint += new System.Windows.Forms.PaintEventHandler(this.tabXY_Paint);
            // 
            // tabYpi
            // 
            this.tabYpi.Location = new System.Drawing.Point(4, 22);
            this.tabYpi.Name = "tabYpi";
            this.tabYpi.Padding = new System.Windows.Forms.Padding(3);
            this.tabYpi.Size = new System.Drawing.Size(575, 549);
            this.tabYpi.TabIndex = 1;
            this.tabYpi.Text = "Ypi";
            this.tabYpi.UseVisualStyleBackColor = true;
            this.tabYpi.Click += new System.EventHandler(this.tabYpi_Click);
            this.tabYpi.Paint += new System.Windows.Forms.PaintEventHandler(this.tabYpi_Paint);
            // 
            // frmEditor
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(585, 577);
            this.ControlBox = false;
            this.Controls.Add(this.tabEditor);
            this.MinimizeBox = false;
            this.Name = "frmEditor";
            this.Text = "3ve Walker - Edit Window";
            this.Paint += new System.Windows.Forms.PaintEventHandler(this.frmEditor_Paint);
            this.Load += new System.EventHandler(this.frmEditor_Load);
            this.tabEditor.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TabControl tabEditor;
        private System.Windows.Forms.TabPage tabXY;
        private System.Windows.Forms.TabPage tabYpi;
    }
}