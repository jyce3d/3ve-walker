using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace _ve_Walker
{
    public partial class frmCommand : Form
    {
        public frmCommand()
        {
            InitializeComponent();
        }

        private void frmCommand_Load(object sender, EventArgs e)
        {
            this.splitCommand.Top = 0;
            this.splitCommand.Left = 0;
                     
        }

        private void frmCommand_Paint(object sender, PaintEventArgs e)
        {
           // txtScript.Width = this.ClientRectangle.Width;
           // txtScript.Height = this.ClientRectangle.Height;
        }
        public TextBox getOutput()
        {
            return txtOutput;
        }
        public TextBox getScript()
        {
            return txtScript;
        }

        private void txtScript_TextChanged(object sender, EventArgs e)
        {
           
        }

        private void txtOutput_TextChanged(object sender, EventArgs e)
        {

        }
    }
}