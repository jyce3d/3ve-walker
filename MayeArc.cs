using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.DirectX;
using Microsoft.DirectX.Direct3D;

namespace _ve_Walker
{
    class MayeArc : Object3D
    {
        public CustomVertex.PositionColored[] m_verts;
        public int m_nLong;
        protected VertexBuffer m_vBuffer;
        public MayeArc(int nLong, System.Drawing.Color col, string Keyname, bool Hidden)
            : base(col, Keyname, Hidden)
        {
  
            m_nLong = nLong;
            m_verts = new CustomVertex.PositionColored[m_nLong];
        }
        public void ExtrudeZ(float z, int iType, ref MayeSurface ms)
        {
            uint nVertCount = (uint)(m_nLong * (ms.m_nLat));
            ms.m_verts = new CustomVertex.PositionColored[nVertCount];
            // short[6*nSlices*(nSegments-1)]
            uint nIndexCount = (uint)((6 * (m_nLong - 1) * (ms.m_nLat - 1)));
            //        uint nSphere_index =(uint)(((nSlices) * 3) );
            ms.m_indexes = new short[nIndexCount];
            // Copier les vertex buffer existants dans la mayeSurface
            int ms_i = 0;
            float curz;
            float deltaz;
            for (int i = 0; i < m_nLong; i++)
            {
                deltaz = (z - m_verts[i].Z) / (ms.m_nLat - 1);
                if (deltaz < 0)
                {
                    curz = m_verts[i].Z;
                    deltaz = -deltaz;

                }
                else
                    curz = z;


                for (int j = 0; j < ms.m_nLat; j++)
                {

                    ms.m_verts[ms_i++] = new CustomVertex.PositionColored(new Vector3(m_verts[i].X, m_verts[i].Y, curz), m_verts[i].Color);

                    curz -= deltaz;
                }
            }
            // calculer les index_buffer
            ms_i = 0;
            for (int j = 0; j < ms.m_nLat - 1; j++)
            {
                for (int i = 0; i < ms.m_nLong - 1; i++)
                {
                    // upper
                    ms.m_indexes[ms_i++] = (short)(i + j * ms.m_nLong);
                    ms.m_indexes[ms_i++] = (short)((i + 1) + (j + 1) * ms.m_nLong);
                    ms.m_indexes[ms_i++] = (short)(i + (j + 1) * ms.m_nLong);

                    //lower
                    ms.m_indexes[ms_i++] = (short)(i + j * ms.m_nLong);
                    ms.m_indexes[ms_i++] = (short)((i + 1) + j * ms.m_nLong);
                    ms.m_indexes[ms_i++] = (short)((i + 1) + (j + 1) * ms.m_nLong);

                }
            }
            ms.m_nFaceCount = 2 * (m_nLong - 1) * (ms.m_nLat - 1);

        }
        public void ExtrudeX(float x, int iType, ref MayeSurface ms)
        {
            uint nVertCount = (uint)(m_nLong * (ms.m_nLat));
            ms.m_verts = new CustomVertex.PositionColored[nVertCount];
            // short[6*nSlices*(nSegments-1)]
            uint nIndexCount = (uint)((6 * (m_nLong - 1) * (ms.m_nLat - 1)));
            //        uint nSphere_index =(uint)(((nSlices) * 3) );
            ms.m_indexes = new short[nIndexCount];
            // Copier les vertex buffer existants dans la mayeSurface
            int ms_i = 0;
            int i = 0;
            int j = 0;
            float curx;
            float deltax;
            float deltaz = m_verts[m_nLong - 1].Z - m_verts[0].Z;

            for ( i = 0; i < m_nLong; i++)
            {
                deltax = (x - m_verts[i].X) / (ms.m_nLat - 1);
                if (deltax < 0)
                {
                    curx = m_verts[i].X;
                    deltax = -deltax;

                }
                else
                    curx = x;


                for (j = 0; j < ms.m_nLat; j++)
                {

                    ms.m_verts[ms_i].Position=new Vector3(curx, m_verts[i].Y, m_verts[i].Z);
                    ms.m_verts[ms_i++].Color=m_verts[i].Color;
                    curx -= deltax;
                }
            }
            // calculer les index_buffer
            ms_i = 0;
            i = 0; j = 1;
            
            ms.m_nFaceCount = 2 * (m_nLong - 1) * (ms.m_nLat - 1);

//            for (int i = 0; i < ms.m_nLong - 1; j++)
            while  (ms_i<3*ms.m_nFaceCount)
            {
//                for (int j = 0; j < ms.m_nLat - 1; i++)
 //               {
                    // upper
                   // ms.m_indexes[ms_i++] = (short)(i + j * ms.m_nLong); //1
                  //  ms.m_indexes[ms_i++] = (short)((i + 1) + (j + 1) * ms.m_nLong);//2
                   //ms.m_indexes[ms_i++] = (short)(i + (j + 1) * ms.m_nLong);//3

                    //lower
                    //ms.m_indexes[ms_i++] = (short)(i + j * ms.m_nLong);//1
                    //ms.m_indexes[ms_i++] = (short)((i + 1)+j * ms.m_nLong);//2
                    //ms.m_indexes[ms_i++] = (short)((i + 1) + (j + 1) * ms.m_nLong);//3
                if (deltaz < 0)
                {
                    ms.m_indexes[ms_i++] = (short)i;                //1
                    ms.m_indexes[ms_i++] = (short)(i + ms.m_nLat);  //3
                    ms.m_indexes[ms_i++] = (short)(i + 1);            //2

                    ms.m_indexes[ms_i++] = (short)(i + 1);            //1
                    ms.m_indexes[ms_i++] = (short)(i + ms.m_nLat);    //3
                    ms.m_indexes[ms_i++] = (short)(i + ms.m_nLat + 1);  //2
                }
                else
                {
                    ms.m_indexes[ms_i++] = (short)i;                //1
                    ms.m_indexes[ms_i++] = (short)(i + 1);            //2
                    ms.m_indexes[ms_i++] = (short)(i + ms.m_nLat);  //3

                    ms.m_indexes[ms_i++] = (short)(i + 1);            //1
                    ms.m_indexes[ms_i++] = (short)(i + ms.m_nLat + 1);  //2
                    ms.m_indexes[ms_i++] = (short)(i + ms.m_nLat);    //3

                }
                    i++;
                    if (i == (j * ms.m_nLat)-1)
                    {
                        i++;
                        j++;
                    }
                    
   //             }
            }

        }
        public void ExtrudeY(float y, int iType, ref MayeSurface ms)
        {
            uint nVertCount = (uint)(m_nLong * (ms.m_nLat));
            ms.m_verts = new CustomVertex.PositionColored[nVertCount];
            // short[6*nSlices*(nSegments-1)]
            uint nIndexCount = (uint)((6 * (m_nLong - 1) * (ms.m_nLat - 1)));
            //        uint nSphere_index =(uint)(((nSlices) * 3) );
            ms.m_indexes = new short[nIndexCount];
            // Copier les vertex buffer existants dans la mayeSurface
            int ms_i = 0;
            float cury;
            float deltay;
            for (int i = 0; i < m_nLong; i++)
            {
                deltay = (y - m_verts[i].Y) / (ms.m_nLat - 1);
                if (deltay < 0)
                {
                    cury = m_verts[i].Y;
                    deltay = -deltay;

                }
                else
                    cury = y;


                for (int j = 0; j < ms.m_nLat; j++)
                {

                    ms.m_verts[ms_i++] = new CustomVertex.PositionColored(new Vector3(m_verts[i].X, cury, m_verts[i].Z), m_verts[i].Color);

                    cury -= deltay;
                }
            }
            // calculer les index_buffer
            ms_i = 0;
            for (int j = 0; j < ms.m_nLat - 1; j++)
            {
                for (int i = 0; i < ms.m_nLong - 1; i++)
                {
                    // upper
                    ms.m_indexes[ms_i++] = (short)(i + j * ms.m_nLong);
                    ms.m_indexes[ms_i++] = (short)((i + 1) + (j + 1) * ms.m_nLong);
                    ms.m_indexes[ms_i++] = (short)(i + (j + 1) * ms.m_nLong);

                    //lower
                    ms.m_indexes[ms_i++] = (short)(i + j * ms.m_nLong);
                    ms.m_indexes[ms_i++] = (short)((i + 1) + j * ms.m_nLong);
                    ms.m_indexes[ms_i++] = (short)((i + 1) + (j + 1) * ms.m_nLong);

                }
            }
            ms.m_nFaceCount = 2 * (m_nLong - 1) * (ms.m_nLat - 1);

        }

        public override void Translate(float x, float y, float z)
        {
            base.Translate(x, y, z);
            for (int i = 0; i < m_nLong; i++)
            {
                m_verts[i].X += x;
                m_verts[i].Y += y;
                m_verts[i].Z += z;
            }
        }
        public override void DrawObject(Device device)
        {
            //Ne pas pas être utilisé plus d'une fois, une fois utilisé, il est mort...
            m_vBuffer = new VertexBuffer(typeof(CustomVertex.PositionColored), m_verts.Length, device, 0,
CustomVertex.PositionColored.Format, Pool.Default);
            m_vBuffer.SetData(m_verts, 0, LockFlags.None);

            if (m_vBuffer == null)
                throw new Exception("MayeArc::DrawObject:The m_vBuffer Vertex Buffer cannot be empty");
            


            device.Transform.World = m_matWorld;
           // device.Transform.World = Matrix.Translation(0.0f, 0.0f, 0.0f);
            device.SetStreamSource(0, m_vBuffer, 0);
            device.VertexFormat = CustomVertex.PositionColored.Format;
           try
            {
                device.DrawPrimitives(PrimitiveType.LineStrip, 0, m_nLong-1 );
           }
            catch
            {
                //throw new Exception("nombre de segment" + m_nLong.ToString());
            }//TODO: Avoid to choke the exception due to m_nLong too long...

        }
    }
}
