using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.DirectX;
using Microsoft.DirectX.Direct3D;
using Context;

namespace _ve_Walker
{
    public class Scene3D : Object3D
    {
        public Collection m_Object3DRefList;
        public Scene3D(string Keyname, bool Hidden) : base(System.Drawing.Color.White, Keyname, Hidden)
        {
            m_Object3DRefList = new Collection();
        }
        public void AddObject3DRef(Object objRef)
        {
            m_Object3DRefList.Add(objRef);
        }
        public override void DrawObject(Device device)
        {
            int i=0;
            if (!m_Hidden)
            {
                for (i = 0; i < m_Object3DRefList.Count; i++)
                {
                    Object3D ob = (Object3D)m_Object3DRefList[i];
                    ob.DrawObject(device);
                }
            }

        }
        public override void Scale(float fScale)
        {
            int i=0;
            for (i=0;i<m_Object3DRefList.Count;i++)
            {
                Object3D ob= (Object3D)m_Object3DRefList[i];
                ob.m_matWorld = ob.m_matWorld * Matrix.Scaling( new Vector3(fScale,fScale,fScale));

            }
        }

        public override void Translate(float x, float y, float z)
        {
            int i = 0;
            for (i = 0; i < m_Object3DRefList.Count; i++)
            {
                Object3D ob = (Object3D)m_Object3DRefList[i];
                ob.Translate(x, y, z);
            }
        }
        public override void RotateX(float phi)
        {
            int i = 0;
            for (i = 0; i < m_Object3DRefList.Count; i++)
            {
                Object3D ob = (Object3D)m_Object3DRefList[i];
                ob.RotateX(phi);
            }
        }
        public override void RotateY(float phi)
        {
            int i = 0;
            for (i = 0; i < m_Object3DRefList.Count; i++)
            {
                Object3D ob = (Object3D)m_Object3DRefList[i];
                ob.RotateY(phi);
            }
        }
        public override void RotateZ(float phi)
        {
            int i = 0;
            for (i = 0; i < m_Object3DRefList.Count; i++)
            {
                Object3D ob = (Object3D)m_Object3DRefList[i];
                ob.RotateZ(phi);
            }
        }

    }
}
