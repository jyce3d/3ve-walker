namespace _ve_Walker
{
    partial class frmWalker
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
            this.panWalker = new System.Windows.Forms.Panel();
            this.label1 = new System.Windows.Forms.Label();
            this.numPosX = new System.Windows.Forms.NumericUpDown();
            this.numPosY = new System.Windows.Forms.NumericUpDown();
            this.label2 = new System.Windows.Forms.Label();
            this.numPosZ = new System.Windows.Forms.NumericUpDown();
            this.label3 = new System.Windows.Forms.Label();
            this.numLookatX = new System.Windows.Forms.NumericUpDown();
            this.label4 = new System.Windows.Forms.Label();
            this.numLookatY = new System.Windows.Forms.NumericUpDown();
            this.label5 = new System.Windows.Forms.Label();
            this.numLookatZ = new System.Windows.Forms.NumericUpDown();
            this.label6 = new System.Windows.Forms.Label();
            this.btnUp = new System.Windows.Forms.Button();
            this.btnRotLeft = new System.Windows.Forms.Button();
            this.btnRotRight = new System.Windows.Forms.Button();
            this.btnBack = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.numPosX)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numPosY)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numPosZ)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numLookatX)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numLookatY)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numLookatZ)).BeginInit();
            this.SuspendLayout();
            // 
            // panWalker
            // 
            this.panWalker.Location = new System.Drawing.Point(1, 1);
            this.panWalker.Name = "panWalker";
            this.panWalker.Size = new System.Drawing.Size(550, 444);
            this.panWalker.TabIndex = 0;
            this.panWalker.Paint += new System.Windows.Forms.PaintEventHandler(this.panWalker_Paint);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(558, 17);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(32, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "PosX";
            // 
            // numPosX
            // 
            this.numPosX.Location = new System.Drawing.Point(602, 15);
            this.numPosX.Name = "numPosX";
            this.numPosX.Size = new System.Drawing.Size(91, 20);
            this.numPosX.TabIndex = 2;
            // 
            // numPosY
            // 
            this.numPosY.Location = new System.Drawing.Point(602, 41);
            this.numPosY.Name = "numPosY";
            this.numPosY.Size = new System.Drawing.Size(91, 20);
            this.numPosY.TabIndex = 4;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(558, 43);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(32, 13);
            this.label2.TabIndex = 3;
            this.label2.Text = "PosY";
            // 
            // numPosZ
            // 
            this.numPosZ.Location = new System.Drawing.Point(602, 67);
            this.numPosZ.Name = "numPosZ";
            this.numPosZ.Size = new System.Drawing.Size(91, 20);
            this.numPosZ.TabIndex = 6;
            this.numPosZ.ValueChanged += new System.EventHandler(this.numericUpDown3_ValueChanged);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(558, 69);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(32, 13);
            this.label3.TabIndex = 5;
            this.label3.Text = "PosZ";
            // 
            // numLookatX
            // 
            this.numLookatX.Location = new System.Drawing.Point(602, 108);
            this.numLookatX.Name = "numLookatX";
            this.numLookatX.Size = new System.Drawing.Size(91, 20);
            this.numLookatX.TabIndex = 8;
            this.numLookatX.ValueChanged += new System.EventHandler(this.numericUpDown4_ValueChanged);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(558, 110);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(38, 13);
            this.label4.TabIndex = 7;
            this.label4.Text = "LookX";
            // 
            // numLookatY
            // 
            this.numLookatY.Location = new System.Drawing.Point(602, 134);
            this.numLookatY.Name = "numLookatY";
            this.numLookatY.Size = new System.Drawing.Size(91, 20);
            this.numLookatY.TabIndex = 10;
            this.numLookatY.ValueChanged += new System.EventHandler(this.numericUpDown5_ValueChanged);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(558, 136);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(38, 13);
            this.label5.TabIndex = 9;
            this.label5.Text = "LookY";
            // 
            // numLookatZ
            // 
            this.numLookatZ.Location = new System.Drawing.Point(602, 160);
            this.numLookatZ.Name = "numLookatZ";
            this.numLookatZ.Size = new System.Drawing.Size(91, 20);
            this.numLookatZ.TabIndex = 12;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(558, 162);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(38, 13);
            this.label6.TabIndex = 11;
            this.label6.Text = "LookZ";
            // 
            // btnUp
            // 
            this.btnUp.Location = new System.Drawing.Point(615, 332);
            this.btnUp.Name = "btnUp";
            this.btnUp.Size = new System.Drawing.Size(31, 23);
            this.btnUp.TabIndex = 13;
            this.btnUp.Text = "Up";
            this.btnUp.UseVisualStyleBackColor = true;
            this.btnUp.Click += new System.EventHandler(this.btnUp_Click);
            // 
            // btnRotLeft
            // 
            this.btnRotLeft.Location = new System.Drawing.Point(596, 361);
            this.btnRotLeft.Name = "btnRotLeft";
            this.btnRotLeft.Size = new System.Drawing.Size(31, 23);
            this.btnRotLeft.TabIndex = 14;
            this.btnRotLeft.Text = "Rl";
            this.btnRotLeft.UseVisualStyleBackColor = true;
            this.btnRotLeft.Click += new System.EventHandler(this.btnRotLeft_Click);
            // 
            // btnRotRight
            // 
            this.btnRotRight.Location = new System.Drawing.Point(633, 361);
            this.btnRotRight.Name = "btnRotRight";
            this.btnRotRight.Size = new System.Drawing.Size(31, 23);
            this.btnRotRight.TabIndex = 15;
            this.btnRotRight.Text = "Rr";
            this.btnRotRight.UseVisualStyleBackColor = true;
            this.btnRotRight.Click += new System.EventHandler(this.btnRotRight_Click);
            // 
            // btnBack
            // 
            this.btnBack.Location = new System.Drawing.Point(615, 412);
            this.btnBack.Name = "btnBack";
            this.btnBack.Size = new System.Drawing.Size(31, 23);
            this.btnBack.TabIndex = 16;
            this.btnBack.Text = "Bk";
            this.btnBack.UseVisualStyleBackColor = true;
            this.btnBack.Click += new System.EventHandler(this.btnBack_Click);
            // 
            // frmWalker
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(705, 446);
            this.Controls.Add(this.btnBack);
            this.Controls.Add(this.btnRotRight);
            this.Controls.Add(this.btnRotLeft);
            this.Controls.Add(this.btnUp);
            this.Controls.Add(this.numLookatZ);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.numLookatY);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.numLookatX);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.numPosZ);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.numPosY);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.numPosX);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.panWalker);
            this.Name = "frmWalker";
            this.Text = "3ve Walker";
            this.Load += new System.EventHandler(this.frmWalker_Load);
            ((System.ComponentModel.ISupportInitialize)(this.numPosX)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numPosY)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numPosZ)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numLookatX)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numLookatY)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numLookatZ)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel panWalker;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.NumericUpDown numPosX;
        private System.Windows.Forms.NumericUpDown numPosY;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.NumericUpDown numPosZ;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.NumericUpDown numLookatX;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.NumericUpDown numLookatY;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.NumericUpDown numLookatZ;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Button btnUp;
        private System.Windows.Forms.Button btnRotLeft;
        private System.Windows.Forms.Button btnRotRight;
        private System.Windows.Forms.Button btnBack;
    }
}