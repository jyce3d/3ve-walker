using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.DirectX;
using Microsoft.DirectX.Direct3D;

namespace _ve_Walker
{
     class FrameBox3D : MayeSurface
    {
         public FrameBox3D(float x0, float y0, float z0, float x1, float y1, float z1, int nLat, int nLong, System.Drawing.Color col, string Keyname, bool Hidden)
             : base(nLat, nLong, col, Keyname, Hidden)
         {
             uint nVertCount = (uint)(2 * m_nLat * m_nLong);
             m_verts = new CustomVertex.PositionColored[nVertCount];
             // short[6*nSlices*(nSegments-1)]
             // (m_nLong-1)* (m_nLat-1)= nbre de carrés => six indexbuffer par carré (3 par triangle *2 triangle)
             // Nombre de faces = (nombre de carré par face * 2) *6
             uint nIndexCount = 6*2*3;//36;//(uint)(2 * (m_nLong * 3) + 6 * (m_nLat - 2) * m_nLong);
             //        uint nSphere_index =(uint)(((nSlices) * 3) );
             m_indexes = new short[nIndexCount];

             m_nFaceCount = (uint)(m_nLong - 1) * (m_nLat - 1) * 2 * 6;
             // Calculate the points
             m_verts[0].Position = new Vector3(x0, y0, z0);m_verts[0].Color = m_Color.ToArgb();
             m_verts[1].Position = new Vector3(x1, y0, z0);m_verts[1].Color = m_Color.ToArgb();
             m_verts[2].Position = new Vector3(x0, y1, z0); m_verts[2].Color = m_Color.ToArgb();
             m_verts[3].Position = new Vector3(x1, y1, z0); m_verts[3].Color = m_Color.ToArgb();
             m_verts[4].Position = new Vector3(x0, y0, z1); m_verts[4].Color = m_Color.ToArgb();
             m_verts[5].Position = new Vector3(x1, y0, z1); m_verts[5].Color = m_Color.ToArgb();
             m_verts[6].Position = new Vector3(x0, y1, z1); m_verts[6].Color = m_Color.ToArgb();
             m_verts[7].Position = new Vector3(x1, y1, z1); m_verts[7].Color = m_Color.ToArgb();

             // Calculate the wires
             int idx = 0;
             //Apparamment ce serait le sens anti-horlogique, ceci-dit tout dépend de la caméra
             //face avant
             m_indexes[idx++] = 0; m_indexes[idx++] = 1; m_indexes[idx++] = 2;
             m_indexes[idx++] = 2; m_indexes[idx++] = 1; m_indexes[idx++] = 3;
             // face à droite
             m_indexes[idx++] = 1; m_indexes[idx++] = 5; m_indexes[idx++] = 7;
             m_indexes[idx++] = 1; m_indexes[idx++] = 7; m_indexes[idx++] = 3;

             //face arrière
             m_indexes[idx++] = 5; m_indexes[idx++] = 6; m_indexes[idx++] = 7;
             m_indexes[idx++] = 5; m_indexes[idx++] = 4; m_indexes[idx++] = 6;

             // face gauche
             m_indexes[idx++] = 0; m_indexes[idx++] = 6; m_indexes[idx++] = 4;
             m_indexes[idx++] = 0; m_indexes[idx++] = 2; m_indexes[idx++] = 6;

             // face dessus
             m_indexes[idx++] = 2; m_indexes[idx++] = 3; m_indexes[idx++] = 7;
             m_indexes[idx++] = 2; m_indexes[idx++] = 7; m_indexes[idx++] = 6;

             m_indexes[idx++] = 0; m_indexes[idx++] = 5; m_indexes[idx++] = 1;
             m_indexes[idx++] = 0; m_indexes[idx++] = 4; m_indexes[idx++] = 5;

             //Valeur
             /*             m_indexes[idx++] = 1; m_indexes[idx++] = 5; m_indexes[idx++] = 7;
                          m_indexes[idx++] = 1; m_indexes[idx++] = 7; m_indexes[idx++] = 3;

                          m_indexes[idx++] = 5; m_indexes[idx++] = 4; m_indexes[idx++] = 6;
                          m_indexes[idx++] = 5; m_indexes[idx++] = 6; m_indexes[idx++] = 7;

                          m_indexes[idx++] = 0; m_indexes[idx++] = 4; m_indexes[idx++] = 6;
                          m_indexes[idx++] = 0; m_indexes[idx++] = 6; m_indexes[idx++] = 2;

                          m_indexes[idx++] = 7; m_indexes[idx++] = 6; m_indexes[idx++] = 2;
                          m_indexes[idx++] = 7; m_indexes[idx++] = 2; m_indexes[idx++] = 3;
 
                           m_indexes[idx++] = 5; m_indexes[idx++] = 0; m_indexes[idx++] = 1;
                          m_indexes[idx++] = 5; m_indexes[idx++] = 4; m_indexes[idx++] = 0;           

             */
         }
 
    }
}
