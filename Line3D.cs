using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.DirectX;
using Microsoft.DirectX.Direct3D;

namespace _ve_Walker
{
    class Line3D : MayeArc 
    {
        public Vector3 m_StartPt;
        public Vector3 m_EndPt;
 
        public Line3D(Vector3 StartPt, Vector3 EndPt, int nLong, System.Drawing.Color col, string Keyname, bool Hidden)
            : base(nLong, col, Keyname, Hidden)
        {
            int i = 0;
            m_StartPt = StartPt;
            m_EndPt = EndPt;
            // Line calculation on (0,0,0)
            float dx = (float)(EndPt.X - StartPt.X) / (m_nLong-1);
            float dy = (float)(EndPt.Y - StartPt.Y) / (m_nLong-1);
            float dz = (float)(EndPt.Z - StartPt.Z) / (m_nLong-1);

            float x = StartPt.X;
            float y = StartPt.Y;
            float z = StartPt.Z;

            while (i < m_nLong)
            {
                m_verts[i].Position = new Vector3(x, y, z);
                m_verts[i].Color = m_Color.ToArgb();
                i++;

                x += dx;
                y += dy;
                z += dz;

            }
  
        }
    }
}
