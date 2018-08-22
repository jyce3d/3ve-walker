using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Collections;
using Microsoft.DirectX;
using Microsoft.DirectX.Direct3D;
using Context;

namespace _ve_Walker
{
    public partial class frmMain : Form
    {
   /*     public Device m_Device;
        public Device InitializeGraphics(System.Windows.Forms.Control ctrl)
        {
            PresentParameters presentParam = new PresentParameters();
            presentParam.Windowed = true;
            presentParam.SwapEffect = Microsoft.DirectX.Direct3D.SwapEffect.Discard;
            // Z-Buffer activation
            presentParam.EnableAutoDepthStencil = true;
            presentParam.AutoDepthStencilFormat = DepthFormat.D16;
            m_Device = new Device(0, DeviceType.Hardware, ctrl, CreateFlags.SoftwareVertexProcessing, presentParam);
            m_Device.DeviceReset +=new EventHandler(device_DeviceReset);
            return m_Device;
        }*/

        public frmCommand frmCmd;
        public frmEditor frmEdit;
        public frmWalker frmWalk;

        public GenContext m_Context;
        public SceneTree m_SceneTree;

        //public frmViewer frmView;
        public frmMain()
        {
            InitializeComponent();
         //   m_MayeArcList = new Collection();
         //   m_MayeSurfaceList = new Collection();
            m_Context = new GenContext();
            m_SceneTree = new SceneTree();

        }
        public int m_nStatus;
        private void frmMain_Load(object sender, EventArgs e)
        {

            this.Size = new Size(SystemInformation.WorkingArea.Width, SystemInformation.WorkingArea.Height);
            this.Top = 0;
            this.Left = 0;

            frmCmd = new frmCommand();
            frmCmd.MdiParent = this;
            frmCmd.Show();

            frmEdit = new frmEditor();
            frmEdit.MdiParent = this;
            frmEdit.Show();

            frmWalk = new frmWalker();
            frmWalk.MdiParent = this;
            frmWalk.Show();

        }

        private void toolStrip1_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {

        }

        private void menuStrip1_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {

        }

        private void runScriptToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ArrayList slOutput = new ArrayList();
            TextBox txtOutput = frmCmd.getOutput();
            TextBox txtScript = frmCmd.getScript();
            Object Tag=new Object(); // dummy Tag parameter
            eveParser oParser = new eveParser(ref m_SceneTree, m_Context, ref slOutput, ref Tag );
            oParser.Execute(txtScript.Lines);
            txtOutput.Clear();
            for (int i = 0; i < slOutput.Count; i++)
            {
                txtOutput.AppendText((string)slOutput[i]);
                txtOutput.AppendText("\r\n");
            }
            frmEdit.RefreshEditor();
            frmWalk.RefreshWalker();
        }

       
    }
}