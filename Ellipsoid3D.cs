using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.DirectX;
using Microsoft.DirectX.Direct3D;

namespace _ve_Walker
{
    class Ellipsoid3D : MayeSurface
    {
        public Ellipsoid3D(Vector3 Center, float radx, float rady, float radz, int nLat, int nLong, System.Drawing.Color col, string Keyname, bool Hidden)
            : base(nLat, nLong, col, Keyname, Hidden)
        {
            uint nVertCount = (uint)(2 + (m_nLat - 1) * m_nLong);
            m_verts = new CustomVertex.PositionColored[nVertCount];
            // short[6*nSlices*(nSegments-1)]
            uint nIndexCount = (uint)(2 * (m_nLong * 3) + 6 * (m_nLat - 2) * m_nLong);
            //        uint nSphere_index =(uint)(((nSlices) * 3) );
            m_indexes= new short[nIndexCount];
            float teta = 0;//(float)Math.PI/2.0f;
            float dteta = (float)(Math.PI / (float)(m_nLat-1));
            float phi = 0;
            float dphi = (float)((2.0f * Math.PI) / (float)(m_nLong-1));
            //radius = 1.0f;
            int i;
            int j;
            int idv = 1; //Index vertex
            int idx = 0;
            // Pole Nord
            m_verts[0].Position = new Vector3(-(float)(radx * Math.Sin(teta) * Math.Cos(phi)),
    (float)(rady * Math.Sin(teta) * Math.Sin(phi)), (float)(radz * Math.Cos(teta)));
            m_verts[0].Color = m_Color.ToArgb();
            teta += dteta;
            for (i = 1; i <= m_nLong; i++)
            {
                m_verts[idv].Position = new Vector3(-(float)(radx * Math.Sin(teta) * Math.Cos(phi)),
        (float)(rady * Math.Sin(teta) * Math.Sin(phi)), (float)(radz * Math.Cos(teta)));
                phi += dphi;
                m_verts[idv++].Color = m_Color.ToArgb();
            }

            for (i = 0; i < m_nLong - 1; i++)
            {
                m_indexes[idx++] = 0;
                //idx++;
                m_indexes[idx++] = (short)(i + 1);
                //idx++;
                m_indexes[idx++] = (short)(i + 2);
                //idx++;
            }
            // last slices
            m_indexes[idx++] = 0;
            m_indexes[idx++] = (short)nLong;
            m_indexes[idx++] = 1;

            // Segments intermédiaires
            // Début de la boucle sur les segments (nSegments -2)
            for (j = 1; j < m_nLat - 1; j++)
            {
                teta += dteta;
                phi = 0;
                for (i = 1; i <= m_nLong; i++)
                {
                    m_verts[idv].Position = new Vector3(-(float)(radx * Math.Sin(teta) * Math.Cos(phi)),
                  (float)(rady * Math.Sin(teta) * Math.Sin(phi)), (float)(radz * Math.Cos(teta)));
                    phi += dphi;
                    m_verts[idv++].Color = m_Color.ToArgb();
                    //sphere_verts[idv++].Color = Color.DarkGreen.ToArgb();
                }
                for (i = 0; i < m_nLong - 1; i++)
                {
                    m_indexes[idx++] = (short)((j - 1) * m_nLong + i + 1);
                    m_indexes[idx++] = (short)((j * m_nLong) + (i + 1));
                    m_indexes[idx++] = (short)((j * m_nLong) + (i + 2));

                    m_indexes[idx++] = (short)(((j - 1) * m_nLong) + (i + 1));
                    m_indexes[idx++] = (short)((j * m_nLong) + (i + 2));
                    m_indexes[idx++] = (short)(((j - 1) * m_nLong) + (i + 2));

                }
                // last slice
                m_indexes[idx++] = (short)((j - 1) * m_nLong + i + 1);
                m_indexes[idx++] = (short)((j * m_nLong) + (i + 1));
                m_indexes[idx++] = (short)((j * m_nLong) + 1);

                m_indexes[idx++] = (short)(((j - 1) * m_nLong) + (i + 1));
                m_indexes[idx++] = (short)((j * m_nLong) + 1);
                m_indexes[idx++] = (short)(((j - 1) * m_nLong) + 1);
                // Fin de la boucle
            }
            // last pole
            phi = 0;
            teta = (float)Math.PI;
            m_verts[m_verts.Length - 1].Position = new Vector3(-(float)(radx * Math.Sin(teta) * Math.Cos(phi)),
(float)(rady * Math.Sin(teta) * Math.Sin(phi)), (float)(radz * Math.Cos(teta)));
            m_verts[m_verts.Length - 1].Color = m_Color.ToArgb();
            teta -= dteta;

            for (i = 0; i < m_nLong - 1; i++)
            {
                m_indexes[idx++] = (short)(nVertCount - 1);
                m_indexes[idx++] = (short)((m_nLat - 2) * m_nLong + i + 1);
                //idx++;
                //idx++;
                m_indexes[idx++] = (short)((m_nLat - 2) * m_nLong + i + 2);
                //idx++;
            }
            // last slices
            m_indexes[idx++] = (short)(nVertCount - 1);
            m_indexes[idx++] = (short)((m_nLat - 2) * m_nLong + m_nLong);
            m_indexes[idx++] = (short)((m_nLat - 2) * m_nLong + 1);

            // Set the number of faces
            m_nFaceCount = 2 * m_nLong + 2 * m_nLong * (m_nLat - 2);

        }
    }
}
