using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.DirectX;
using Microsoft.DirectX.Direct3D;

namespace _ve_Walker
{
    public class Object3D
    {
        public System.Drawing.Color m_Color;
        public bool m_Hidden;
        public string m_Keyname;
        public Matrix m_matWorld=Matrix.Translation(0.0f, 0.0f, 0.0f);

        public Object3D(System.Drawing.Color col, string Keyname, bool Hidden)
        {
            m_Color = col;
            m_Hidden = Hidden;
            m_Keyname = Keyname;
        }

        public virtual void DrawObject(Device device)
        {

        }
        public virtual void Translate(float x, float y, float z)
        {
        //    m_matWorld = m_matWorld * Matrix.Translation(x, y, z);
        }
        public virtual void RotateX(float phi)
        {
          //  m_matWorld = m_matWorld * Matrix.RotationX(phi);
        }
        public virtual void RotateY(float phi)
        {
            //m_matWorld = m_matWorld * Matrix.RotationY(phi);
        }
        public virtual void RotateZ(float phi)
        {
        //    m_matWorld = m_matWorld * Matrix.RotationZ(phi);
        }
        public virtual void Scale(float fScale)
        {
            m_matWorld = m_matWorld * Matrix.Scaling( new Vector3(fScale,fScale,fScale));
        }


    }
}
