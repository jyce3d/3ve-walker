using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.DirectX;
using Microsoft.DirectX.Direct3D;


namespace _ve_Walker
{
    class Arc3D : MayeArc
    {
        public Arc3D(Vector3 CenterPt, float rx, float rz, float phi0, float phi1, int nLong, System.Drawing.Color col, string Keyname, bool Hidden)
            : base(nLong, col, Keyname, Hidden)
        {
            int i = 0;
            float deltaphi = (phi1 - phi0) / (nLong-1);
            float x=0, y=0, z=0;
            float phi = phi0;

            while (i < m_nLong)
            {
                MathFunc3D.CalcEllipse(rx, rz, phi, ref x, ref z);
                m_verts[i].Position = new Vector3(x+CenterPt.X, y+CenterPt.Y, z+CenterPt.Z);
                m_verts[i].Color = m_Color.ToArgb();
                i++;
                phi += deltaphi;

            }
            //Translate(CenterPt.X, CenterPt.Y, CenterPt.Z);
        }
    }
}
