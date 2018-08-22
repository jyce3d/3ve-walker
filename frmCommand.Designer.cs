namespace _ve_Walker
{
    partial class frmCommand
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
            this.splitCommand = new System.Windows.Forms.SplitContainer();
            this.txtOutput = new System.Windows.Forms.TextBox();
            this.txtScript = new System.Windows.Forms.TextBox();
            this.splitCommand.Panel1.SuspendLayout();
            this.splitCommand.Panel2.SuspendLayout();
            this.splitCommand.SuspendLayout();
            this.SuspendLayout();
            // 
            // splitCommand
            // 
            this.splitCommand.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitCommand.Location = new System.Drawing.Point(0, 0);
            this.splitCommand.Name = "splitCommand";
            this.splitCommand.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitCommand.Panel1
            // 
            this.splitCommand.Panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(0)))), ((int)(((byte)(64)))));
            this.splitCommand.Panel1.Controls.Add(this.txtOutput);
            // 
            // splitCommand.Panel2
            // 
            this.splitCommand.Panel2.BackColor = System.Drawing.Color.White;
            this.splitCommand.Panel2.Controls.Add(this.txtScript);
            this.splitCommand.Size = new System.Drawing.Size(292, 266);
            this.splitCommand.SplitterDistance = 123;
            this.splitCommand.TabIndex = 0;
            // 
            // txtOutput
            // 
            this.txtOutput.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.txtOutput.BackColor = System.Drawing.Color.Black;
            this.txtOutput.ForeColor = System.Drawing.Color.White;
            this.txtOutput.Location = new System.Drawing.Point(0, 3);
            this.txtOutput.Multiline = true;
            this.txtOutput.Name = "txtOutput";
            this.txtOutput.ReadOnly = true;
            this.txtOutput.Size = new System.Drawing.Size(289, 117);
            this.txtOutput.TabIndex = 0;
            this.txtOutput.TextChanged += new System.EventHandler(this.txtOutput_TextChanged);
            // 
            // txtScript
            // 
            this.txtScript.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.txtScript.Location = new System.Drawing.Point(0, 3);
            this.txtScript.Multiline = true;
            this.txtScript.Name = "txtScript";
            this.txtScript.Size = new System.Drawing.Size(292, 136);
            this.txtScript.TabIndex = 0;
            this.txtScript.Text = "Framebox(0,0,0,2,2,2,5,7)";
            this.txtScript.TextChanged += new System.EventHandler(this.txtScript_TextChanged);
            // 
            // frmCommand
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(292, 266);
            this.Controls.Add(this.splitCommand);
            this.Name = "frmCommand";
            this.Text = "Command Window";
            this.TopMost = true;
            this.Load += new System.EventHandler(this.frmCommand_Load);
            this.Paint += new System.Windows.Forms.PaintEventHandler(this.frmCommand_Paint);
            this.splitCommand.Panel1.ResumeLayout(false);
            this.splitCommand.Panel1.PerformLayout();
            this.splitCommand.Panel2.ResumeLayout(false);
            this.splitCommand.Panel2.PerformLayout();
            this.splitCommand.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.SplitContainer splitCommand;
        private System.Windows.Forms.TextBox txtScript;
        private System.Windows.Forms.TextBox txtOutput;
    }
}