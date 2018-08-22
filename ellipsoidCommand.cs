using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using Context;
using Microsoft.DirectX;
using Microsoft.DirectX.Direct3D;
using _ve_Walker;

namespace Language.Commands
{
    class ellipsoidCommand : GenCommand
    {
        public override void ExecuteCmd(string szContent, ref GenContext Context, ref ArrayList Output, ref Object Tag)
        {
            base.ExecuteCmd(szContent, ref Context, ref Output, ref Tag);
            if (!(Tag is SceneTree))
                throw new Exception("LineCommand::ExecuteCmd:The last parameter must be a SceneTree instance");
            SceneTree sct = (SceneTree)Tag;

            int iPos = -1;

            string szPar1 = GenContext.GetFirstParam(szContent, ref iPos, ',');//x
            string szPar2 = GenContext.GetNextParam(szContent, ref iPos, ',');//y
            string szPar3 = GenContext.GetNextParam(szContent, ref iPos, ',');//z
            string szPar4 = GenContext.GetNextParam(szContent, ref iPos, ',');//rx
            string szPar5 = GenContext.GetNextParam(szContent, ref iPos, ',');//ry
            string szPar6 = GenContext.GetNextParam(szContent, ref iPos, ',');//rz
            string szPar7 = GenContext.GetNextParam(szContent, ref iPos, ',');//nLong
            string szPar8 = GenContext.GetNextParam(szContent, ref iPos, ',');//nLat
            string szPar9 = GenContext.GetNextParam(szContent, ref iPos, ',');//color
            string szPar10 = GenContext.GetNextParam(szContent, ref iPos, ',');//type obsolete (for compatibility)
            string szPar11 = GenContext.GetNextParam(szContent, ref iPos, ',');//keyname

            if (GenContext.GetNextParam(szContent, ref iPos, ',') != "")
                throw new Exception("EllipsoidCommand:Invalid argument list.");
            if (szPar7 == "")
                szPar7 = "20";
            if (szPar8 == "")
                szPar8 = "20";
            if (szPar9 == "")
                szPar9 = "ffffff";
            int iCount = sct.m_Object3DList.Count + 1;
            if (szPar11 == "")
                szPar11 = "\"Ellipsoid" + iCount.ToString() + "\"";
            Object3D ob = sct.GetObject3D(szPar11);
            Ellipsoid3D mayeEllipsoid = null;
            if (ob != null)
            {
                if (!(ob is Ellipsoid3D))
                    throw new Exception("EllipsoidCommand::ExecuteCmd:A 3DObject is already called like this");
                sct.DeleteObject3D(ref ob);
            }

            float x = (float)Context.EvalFloat(szPar1);
            float y = (float)Context.EvalFloat(szPar2);
            float z = (float)Context.EvalFloat(szPar3);

            float rx = (float)Context.EvalFloat(szPar4);
            float ry = (float)Context.EvalFloat(szPar5);
            float rz = (float)Context.EvalFloat(szPar6);

            szPar11 = Context.EvalText(szPar11);


            mayeEllipsoid = new Ellipsoid3D(new Vector3(0, 0, 0), rx, ry, rz, Convert.ToInt32(szPar7), Convert.ToInt32(szPar8), System.Drawing.Color.FromArgb(Int32.Parse(szPar9, System.Globalization.NumberStyles.HexNumber)), szPar11, false); 
                //Line3D(new Vector3(x1, y1, z1), new Vector3(x2, y2, z2), Convert.ToInt32(szPar7), System.Drawing.Color.FromArgb(Int32.Parse(szPar8, System.Globalization.NumberStyles.HexNumber)), szPar10, false);
            mayeEllipsoid.Translate(x, y, z);

            Scene3D sc = (Scene3D)sct.m_MainSceneNode.m_Scene3DRef;
            sct.AddObject3D(sc.m_Keyname, mayeEllipsoid);
        }
    }
}
