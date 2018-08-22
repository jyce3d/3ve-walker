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
    class lineCommand : GenCommand
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
            string szPar4 = GenContext.GetNextParam(szContent, ref iPos, ',');//x2
            string szPar5 = GenContext.GetNextParam(szContent, ref iPos, ',');//y2
            string szPar6 = GenContext.GetNextParam(szContent, ref iPos, ',');//z2
            string szPar7 = GenContext.GetNextParam(szContent, ref iPos, ',');//nLong
            string szPar8 = GenContext.GetNextParam(szContent, ref iPos, ',');//color
            string szPar9 = GenContext.GetNextParam(szContent, ref iPos, ',');//type obsolete (for compatibility)
            string szPar10 = GenContext.GetNextParam(szContent, ref iPos, ',');//keyname

            if (GenContext.GetNextParam(szContent, ref iPos, ',') != "")
                throw new Exception("LineCommand:Invalid argument list.");

            if (szPar7 == "")
                szPar7 = "6";
            if (( (Convert.ToInt32(szPar7)))<=1)
                throw new Exception("The amount of point must be at least 2");
            if (szPar8 == "")
                szPar8 = "ffffff";
            szPar9 = "0";
            int iCount = sct.m_Object3DList.Count + 1;
            if (szPar10 == "")
                szPar10 = "\"Line" + iCount.ToString()+"\"";
            Object3D ob = sct.GetObject3D(szPar10);
            Line3D mayeLine=null;
            if (ob != null)
            {
                if (!(ob is Line3D))
                    throw new Exception("LineCommand::ExecuteCmd:A 3DObject is already called like this");
                sct.DeleteObject3D(ref ob);
            }
            float x1 = (float)Context.EvalFloat(szPar1);
            float y1 = (float)Context.EvalFloat(szPar2);
            float z1 = (float)Context.EvalFloat(szPar3);

            float x2 = (float)Context.EvalFloat(szPar4);
            float y2 = (float)Context.EvalFloat(szPar5);
            float z2 = (float)Context.EvalFloat(szPar6);

            szPar10 = Context.EvalText(szPar10);
            

            mayeLine = new Line3D(new Vector3(x1, y1, z1 ), new Vector3(x2, y2, z2), Convert.ToInt32(szPar7),             System.Drawing.Color.FromArgb(Int32.Parse(szPar8, System.Globalization.NumberStyles.HexNumber)), szPar10, false);
            Scene3D sc = (Scene3D)sct.m_MainSceneNode.m_Scene3DRef;
            sct.AddObject3D(sc.m_Keyname, mayeLine);
        }
     
    }
}
