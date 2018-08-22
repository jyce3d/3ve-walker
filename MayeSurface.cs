using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.DirectX;
using Microsoft.DirectX.Direct3D;

namespace _ve_Walker
{
    class MayeSurface : Object3D
    {
        public int m_nLong;
        public int m_nLat;
        public int m_nFaceCount; // Must be filled
        public CustomVertex.PositionColored[] m_verts;
        public short[] m_indexes;

         public MayeSurface(int nLat, int nLong, System.Drawing.Color col, string Keyname, bool Hidden)
            : base(col, Keyname, Hidden)
        {
            m_nLong = nLong;
            m_nLat = nLat;
            m_nFaceCount = -1;
        }
        public override void Translate(float x, float y, float z)
        {
            base.Translate(x, y, z);
            for (int i = 0; i < m_verts.Length; i++)
            {
                m_verts[i].X += x;
                m_verts[i].Y += y;
                m_verts[i].Z += z;
            }

        }
        public override void DrawObject(Device device)
        {
            if (m_nFaceCount==-1)
              throw (new System.Exception("m_nFaceCount must be filled"));
  
            device.Transform.World = m_matWorld;
            Mesh mesh = new Mesh(m_nFaceCount, (int)m_verts.Length, MeshFlags.Managed, CustomVertex.PositionColored.Format, device);
            mesh.SetVertexBufferData(m_verts, LockFlags.None);
            mesh.SetIndexBufferData(m_indexes, LockFlags.None);
            mesh.DrawSubset(0);
        }


    }
}
