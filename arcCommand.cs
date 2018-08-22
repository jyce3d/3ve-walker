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
    class arcCommand : GenCommand
    {
        public override void ExecuteCmd(string szContent, ref GenContext Context, ref ArrayList Output, ref Object Tag)
        {

            base.ExecuteCmd(szContent, ref Context, ref Output, ref Tag);
            if (!(Tag is SceneTree))
                throw new Exception("LineCommand::ExecuteCmd:The last parameter must be a SceneTree instance");
            SceneTree sct = (SceneTree)Tag;

            int iPos = -1;

            string szPar1 = GenContext.GetFirstParam(szContent, ref iPos, ',');//x1
            string szPar2 = GenContext.GetNextParam(szContent, ref iPos, ',');//y1
            string szPar3 = GenContext.GetNextParam(szContent, ref iPos, ',');//z1
            string szPar4 = GenContext.GetNextParam(szContent, ref iPos, ',');//a
            string szPar5 = GenContext.GetNextParam(szContent, ref iPos, ',');//b
            string szPar6 = GenContext.GetNextParam(szContent, ref iPos, ',');//phi0
            string szPar7 = GenContext.GetNextParam(szContent, ref iPos, ',');//phi1
            string szPar8 = GenContext.GetNextParam(szContent, ref iPos, ',');//nLong
            string szPar9 = GenContext.GetNextParam(szContent, ref iPos, ',');//color
            string szPar10 = GenContext.GetNextParam(szContent, ref iPos, ',');//type obsolete (for compatibility)
            string szPar11 = GenContext.GetNextParam(szContent, ref iPos, ',');//keyname

            if (GenContext.GetNextParam(szContent, ref iPos, ',') != "")
                throw new Exception("ArcCommand:Invalid argument list.");

            if (szPar8 == "")
                szPar8 = "6";
            if (((Convert.ToInt32(szPar8)) % 2) == 1)
                throw new Exception("The amount of segment must be an 'even' value");
            if (szPar9 == "")
                szPar9 = "ffffff";
            szPar10 = "0"; //type
            int iCount = sct.m_Object3DList.Count + 1;
            if (szPar11 == "")
                szPar11 = "\"Arc" + iCount.ToString() + "\"";
            Object3D ob = sct.GetObject3D(szPar11);
            Arc3D mayeArc = null;
            if (ob != null)
            {
                if (!(ob is Arc3D))
                    throw new Exception("ArcCommand::ExecuteCmd:A 3DObject is already called like this");
                sct.DeleteObject3D(ref ob);
            }
            float x1 = (float)Context.EvalFloat(szPar1);
            float y1 = (float)Context.EvalFloat(szPar2);
            float z1 = (float)Context.EvalFloat(szPar3);

            float rx = (float)Context.EvalFloat(szPar4);
            float rz = (float)Context.EvalFloat(szPar5);
            float phi0 = (float)Context.EvalFloat(szPar6);
            float phi1 = (float)Context.EvalFloat(szPar7);

            szPar11 = Context.EvalText(szPar11);

            int nLong=Convert.ToInt32(szPar8); // Multiply by 2 to get enough point for the primitives

            mayeArc = new Arc3D(new Vector3(x1, y1, z1), rx, rz, phi0, phi1, nLong , System.Drawing.Color.FromArgb(Int32.Parse(szPar9, System.Globalization.NumberStyles.HexNumber)), szPar11, false);
            Scene3D sc = (Scene3D)sct.m_MainSceneNode.m_Scene3DRef;
            sct.AddObject3D(sc.m_Keyname, mayeArc);

        }
    }
}
