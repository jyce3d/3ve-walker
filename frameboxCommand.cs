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
    class frameboxCommand : GenCommand
    {
        public override void ExecuteCmd(string szContent, ref GenContext Context, ref ArrayList Output, ref Object Tag)
        {
            base.ExecuteCmd(szContent, ref Context, ref Output, ref Tag);
            if (!(Tag is SceneTree))
                throw new Exception("LineCommand::ExecuteCmd:The last parameter must be a SceneTree instance");
            SceneTree sct = (SceneTree)Tag;

            int iPos = -1;

            string szPar1 = GenContext.GetFirstParam(szContent, ref iPos, ',');//x0
            string szPar2 = GenContext.GetNextParam(szContent, ref iPos, ',');//y0
            string szPar3 = GenContext.GetNextParam(szContent, ref iPos, ',');//z0
            string szPar4 = GenContext.GetNextParam(szContent, ref iPos, ',');//x1
            string szPar5 = GenContext.GetNextParam(szContent, ref iPos, ',');//y1
            string szPar6 = GenContext.GetNextParam(szContent, ref iPos, ',');//z1
            string szPar7 = GenContext.GetNextParam(szContent, ref iPos, ',');//nLong
            string szPar8 = GenContext.GetNextParam(szContent, ref iPos, ',');//nLat
            string szPar9 = GenContext.GetNextParam(szContent, ref iPos, ',');//color
            string szPar10 = GenContext.GetNextParam(szContent, ref iPos, ',');//type obsolete (for compatibility)
            string szPar11 = GenContext.GetNextParam(szContent, ref iPos, ',');//keyname

            //TODO:Change the nLong and nLat
            if (GenContext.GetNextParam(szContent, ref iPos, ',') != "")
                throw new Exception("FrameboxCommand:Invalid argument list.");
            if (szPar7 == "")
                szPar7 = "2";
            if (szPar8 == "")
                szPar8 = "2";
            if (szPar9 == "")
                szPar9 = "ffffff";
            int iCount = sct.m_Object3DList.Count + 1;
            if (szPar11 == "")
                szPar11 = "\"FrameBox" + iCount.ToString() + "\"";
            Object3D ob = sct.GetObject3D(szPar11);
            FrameBox3D mayeFramebox = null;
            if (ob != null)
            {
                if (!(ob is Ellipsoid3D))
                    throw new Exception("Framebox::ExecuteCmd:A 3DObject is already called like this");
                sct.DeleteObject3D(ref ob);
            }

            float x0 = (float)Context.EvalFloat(szPar1);
            float y0 = (float)Context.EvalFloat(szPar2);
            float z0 = (float)Context.EvalFloat(szPar3);

            float x1 = (float)Context.EvalFloat(szPar4);
            float y1 = (float)Context.EvalFloat(szPar5);
            float z1 = (float)Context.EvalFloat(szPar6);

            szPar11 = Context.EvalText(szPar11);


            mayeFramebox = new FrameBox3D(x0,y0,z0, x1, y1, z1, Convert.ToInt32(szPar7), Convert.ToInt32(szPar8), System.Drawing.Color.FromArgb(Int32.Parse(szPar9, System.Globalization.NumberStyles.HexNumber)), szPar11, false);
 
            Scene3D sc = (Scene3D)sct.m_MainSceneNode.m_Scene3DRef;
            sct.AddObject3D(sc.m_Keyname, mayeFramebox);


        }

    }
}
