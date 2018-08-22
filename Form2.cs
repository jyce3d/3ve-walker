using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Microsoft.DirectX;
using Microsoft.DirectX.Direct3D;

namespace _ve_Walker
{
    public partial class frmWalker : Form
    {
        public const float SENSE_ROTATE=96;

        public Device m_device;
        public float m_Posx, m_Posy, m_Posz;
        public float m_Lookx, m_Looky, m_Lookz;
   //     public float m_Angle;
        public float m_Zeye;
   
        public frmWalker()
        {
            InitializeComponent();
            //m_Angle = 0;
            m_Posx = 0;
            m_Posy = (float)1.7f;
            m_Posz = (float)-5f;

            m_Lookx = 0;
            m_Looky = (float)1.7/2f;
            m_Lookz = 0;

            m_Zeye = (float)5.0f; // 5mètre, position du regard 

            //m_deltax = 0;
            //m_deltaz = 0;

        }
        private void InitializeGraphics()
        {
            m_device = null;
            PresentParameters presentParam = new PresentParameters();
            presentParam.Windowed = true;
            presentParam.SwapEffect = Microsoft.DirectX.Direct3D.SwapEffect.Discard;
            // Z-Buffer activation
            presentParam.EnableAutoDepthStencil = true;
            presentParam.AutoDepthStencilFormat = DepthFormat.D16;
            m_device = new Device(0, DeviceType.Hardware, panWalker, CreateFlags.SoftwareVertexProcessing, presentParam);
            //device.DeviceReset += new EventHandler(device_DeviceReset);
            ///m_Device.DeviceLost += new EventHandler(device_DeviceLost);
        }

        private void numericUpDown3_ValueChanged(object sender, EventArgs e)
        {

        }

        private void numericUpDown4_ValueChanged(object sender, EventArgs e)
        {

        }

        private void numericUpDown5_ValueChanged(object sender, EventArgs e)
        {

        }

        private void frmWalker_Load(object sender, EventArgs e)
        {
            InitializeGraphics();
        }
        public void RefreshWalker()
        {
            panWalker.Invalidate();
        }
        private void panWalker_Paint(object sender, PaintEventArgs e)
        {
            // Initialize Editor Surface Render
            m_device.RenderState.Lighting = false;
            m_device.RenderState.ZBufferEnable = false;
            //m_device.RenderState.Clipping = true;
            m_device.RenderState.FillMode = FillMode.Solid;
            m_device.Transform.Projection = Matrix.PerspectiveFovLH((float)Math.PI/4, panWalker.ClientRectangle.Width / panWalker.ClientRectangle.Height, 0.0f, 50.0f);
            // TODO: Set the Camera
            m_device.Transform.View = Matrix.LookAtLH(new Vector3(m_Posx, m_Posy, m_Posz),
      new Vector3(m_Lookx, m_Looky, m_Lookz),
      new Vector3(0.0f, 1.0f, 0.0f));

            // Start Drawing
            m_device.BeginScene();
            // Créeer les objets en dehors avant l'affichage
            m_device.Clear(ClearFlags.Target, System.Drawing.Color.SkyBlue, 1.0f, 0);
            frmMain mdi = (frmMain)MdiParent;
            mdi.m_SceneTree.DrawScenes(m_device);
            m_device.EndScene();
            // Display the viewer
            m_device.Present();

        }

        private void btnUp_Click(object sender, EventArgs e)
        {
 //           m_Posz -= (float)0.70f;
 //           if (m_Posz < 0)
 //               m_Posz = 0;
            //m_Posx += (float)Math.Cos(m_Angle);
 //           RefreshWalker();
            // Avancer la position
            float angle = (float)Math.Atan(m_Posx / m_Posy);
            float deltax = (float)Math.Sin(angle);
            float deltaz = (float)Math.Cos(angle);

            m_Posx += deltax;
            m_Posz += deltaz;

            // Avancer la caméra
            m_Lookx += deltax;
            m_Lookz += deltaz;

            RefreshWalker();
        }

        private void btnRotLeft_Click(object sender, EventArgs e)
        {
         //   m_Angle -= (float)Math.PI / SENSE_ROTATE;
            float deltax = (float)(m_Zeye * Math.Sin(Math.PI / SENSE_ROTATE));
            float deltaz = (float)((m_Zeye-m_Zeye * Math.Cos(Math.PI / SENSE_ROTATE)));

            m_Lookx -= deltax;
            m_Lookz += deltaz;

            RefreshWalker();
        }

        private void btnRotRight_Click(object sender, EventArgs e)
        {
            //m_Angle += (float)Math.PI / SENSE_ROTATE;
            float deltax = (float)(m_Zeye * Math.Sin(Math.PI / SENSE_ROTATE));
            float deltaz = (float)(m_Zeye - (m_Zeye * Math.Cos(Math.PI / SENSE_ROTATE)));

            m_Lookx += deltax;
            m_Lookz += deltaz;

            RefreshWalker();
        }

        private void btnBack_Click(object sender, EventArgs e)
        {
            // reculer la position
            float angle = (float)Math.Atan(m_Posx / m_Posy);
            float deltax = (float)Math.Sin(angle);
            float deltaz = (float)Math.Cos(angle);

            m_Posx += deltax;
            m_Posz -= deltaz;

            // reculer la caméra
            m_Lookx += deltax;
            m_Lookz -= deltaz;

            RefreshWalker();

        }
    }
}