using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Microsoft.DirectX;
using Microsoft.DirectX.Direct3D;
/*
 * Note vaguement utile
 * Dans le cadre d'une projection ortho, la notion de profondeur (z ou y) n'a aucun sens
 * pour obtenir un grossissement, il faut faire un scale des objets (le mieux est de modifier la world matrix)
 * attention toutefois que ces matrices conservent le scale tout le temps, il faut donc ne pas oublier de revenir
 * en arrière en appliquant une matrice scale inverse pour ne pas obtenir un grossissement exponentiel des objets
 * ou conserver le scale dans une projection en perspective ce qui n'est pas génial.
 */
namespace _ve_Walker
{
    public partial class frmEditor : Form
    {
        private Device m_ZXDevice;
        private Device m_YpiDevice;

        public frmEditor()
        {
            InitializeComponent();
    
        }
        private Device InitializeGraphics(ref TabPage tab)
        {
                Device device = null;
                 PresentParameters presentParam = new PresentParameters();
                presentParam.Windowed = true;
                presentParam.SwapEffect = Microsoft.DirectX.Direct3D.SwapEffect.Discard;
                // Z-Buffer activation
                presentParam.EnableAutoDepthStencil = true;
                presentParam.AutoDepthStencilFormat = DepthFormat.D16;
                device = new Device(0, DeviceType.Hardware, tab, CreateFlags.SoftwareVertexProcessing, presentParam);
                //device.DeviceReset += new EventHandler(device_DeviceReset);
                ///m_Device.DeviceLost += new EventHandler(device_DeviceLost);
                return device;
        }
        private void InitializeRender(ref Device device)
        {
            // Initialize Editor Surface Render
            device.RenderState.Lighting = false;
            device.RenderState.ZBufferEnable = false;
            //  m_device.RenderState.Clipping = true;
            device.RenderState.FillMode = FillMode.WireFrame;

        }
        private void DoRender(Device device)
        {

            // Start Drawing
            float scale=50;
            device.BeginScene();
            // Créeer les objets en dehors avant l'affichage
            device.Clear(ClearFlags.Target, System.Drawing.Color.Black, 1.0f, 0);
            frmMain mdi = (frmMain)MdiParent;
            mdi.m_SceneTree.ScaleScenes(scale);
            mdi.m_SceneTree.DrawScenes(device);
            mdi.m_SceneTree.ScaleScenes(1 / scale);

            device.EndScene();
            // Display the editor
            device.Present();


        }

        private void frmEditor_Load(object sender, EventArgs e)
        {
            frmMain mdiParent = (frmMain)MdiParent;
           
            m_ZXDevice=InitializeGraphics(ref tabXY);
            m_YpiDevice = InitializeGraphics(ref tabYpi);

        }
        public void device_DeviceReset(object Sender, EventArgs e)
        {
           
        //        InitializeGraphics();
        }
        public void device_DeviceLost(object Sender, EventArgs e)
        {

         //          InitializeGraphics();
        }
        public void RefreshEditor()
        {
            tabXY.Invalidate();
            tabYpi.Invalidate();
        }
        private void frmEditor_Paint(object sender, PaintEventArgs e)
        {
        }

        private void tabXY_Paint(object sender, PaintEventArgs e)
        {
            InitializeRender(ref m_ZXDevice);
            // Set the projection
            
           // m_ZXDevice.Transform.Projection = Matrix.PerspectiveFovLH((float)Math.PI/2 , this.ClientRectangle.Width / this.ClientRectangle.Height, 0.0f, 500.0f);
            m_ZXDevice.Transform.Projection = Matrix.OrthoLH(this.ClientRectangle.Width, this.ClientRectangle.Height, 0.0f, 500.0f);
            // TODO: Set the Camera
            m_ZXDevice.Transform.View = Matrix.LookAtLH(new Vector3(0.0f, 5.0f, 0.0f),
      new Vector3(0.0f, 0.0f, 0.0f),
      new Vector3(1.0f, 0.0f, 0.0f)
  ); 
       /*         Line3D liney = new Line3D(new Vector3(0.0f, 0.0f, 0.0f),
                new Vector3(0.0f, 1.0f, 0.0f), 2, Color.Green, "axe_y", false);
            liney.DrawObject(m_device);

            Line3D linex = new Line3D(new Vector3(0.0f, 0.0f, 0.0f),
                new Vector3(-1.0f, 0.0f, 0.0f), 2, Color.Red, "axe_x", false);
            linex.DrawObject(m_device);

            Ellipsoid3D sphere = new Ellipsoid3D(new Vector3(0.0f, 0.0f, 0.0f), 0.5f, 0.5f, 0.5f, 50, 50, System.Drawing.Color.Cyan, "sphere1", false);
            sphere.DrawObject(m_device);*/
            //TODO:UnComment this
            DoRender(m_ZXDevice);

        }

        private void tabXY_Click(object sender, EventArgs e)
        {

        }

        private void tabYpi_Click(object sender, EventArgs e)
        {

        }

        private void tabYpi_Paint(object sender, PaintEventArgs e)
        {
            InitializeRender(ref m_YpiDevice);
            // Set the projection

//            m_YpiDevice.Transform.Projection = Matrix.PerspectiveFovLH((float)Math.PI / 2, this.ClientRectangle.Width / this.ClientRectangle.Height, 0.0f, 50.0f);
            m_YpiDevice.Transform.Projection = Matrix.OrthoLH(this.ClientRectangle.Width, this.ClientRectangle.Height, 0.0f, 500.0f);

            // TODO: Set the Camera
            m_YpiDevice.Transform.View = Matrix.LookAtLH(new Vector3(0.0f, 0.0f, 5.0f),
      new Vector3(0.0f, 0.0f, 0.0f),
      new Vector3(0.0f, 1.0f, 0.0f)
  );
            DoRender(m_YpiDevice);
        }
    }
}