using System;
using System.Collections.Generic;
using System.Text;

namespace _ve_Walker
{
    class MathFunc3D
    {
        // Calculate versus XZ plane 
        // y is always zero, it is obtained by translation
        public static void CalcEllipse(float rx, float rz, float phi, ref float px, ref float pz)
        {
            px = rx * (float)Math.Cos(phi);
            pz = rz * (float)Math.Sin(phi);
        }
        public static void Rotate3DX(float phi, ref float xr, ref float yr, ref float zr)
        {
            float y, z;
            y = yr;
            z = zr;
            yr=(float)Math.Cos(phi)*y-(float)Math.Sin(phi)*z;
            zr=(float)Math.Sin(phi)*y+(float)Math.Cos(phi)*z; 
        }
        public static void Rotate3DY(float phi, ref float xr, ref float yr, ref float zr)
        {
            float x, z;
            x = xr;
            z = zr;
            xr = (float)Math.Cos(phi) * x + (float)Math.Sin(phi) * z;
            zr = -(float)Math.Sin(phi) * x + (float)Math.Cos(phi) * z;
        }
        public static void Rotate3DZ(float phi, ref float xr, ref float yr, ref float zr)
        {
            float x, y;
            x = xr;
            y = yr;
            xr = (float)Math.Cos(phi) * x - (float)Math.Sin(phi) * y;
            zr = (float)Math.Sin(phi) * x + (float)Math.Cos(phi) * y;
        }

    }
}
