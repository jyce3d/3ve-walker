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
    class extrudexCommand : GenCommand
    {
        public override void ExecuteCmd(string szContent, ref GenContext Context, ref ArrayList Output, ref Object Tag)
        {
            base.ExecuteCmd(szContent, ref Context, ref Output, ref Tag);
            if (!(Tag is SceneTree))
                throw new Exception("ExtrudeXCommand::ExecuteCmd:The last parameter must be a SceneTree instance");
            SceneTree sct = (SceneTree)Tag;

            int iPos = -1;

            string szPar1 = GenContext.GetFirstParam(szContent, ref iPos, ',');//SourceKeyname
            string szPar2 = GenContext.GetNextParam(szContent, ref iPos, ',');//x
            string szPar3 = GenContext.GetNextParam(szContent, ref iPos, ',');//nLat
            string szPar4 = GenContext.GetNextParam(szContent, ref iPos, ',');//Type abs/rel
            string szPar5 = GenContext.GetNextParam(szContent, ref iPos, ',');//TargetKeyname
            float x = (float)Convert.ToDouble(szPar2);
            if (Convert.ToInt32(szPar3) < 2)
                throw new Exception("ExtrudeXCommand:nLat must greater than 1 to create mayesurface");
            if (GenContext.GetNextParam(szContent, ref iPos, ',') != "")
                throw new Exception("ExtrudeXCommand:Invalid argument list.");

            int iCount = sct.m_Object3DList.Count + 1;
            if (szPar5 == "")
                szPar5 = "\"ExtrudeX" + iCount.ToString() + "\"";
            Object3D ob = sct.GetObject3D(Context.EvalText(szPar1));
            MayeArc arc = null;
            MayeSurface mayesurf = null;
            if (!(ob is MayeArc))
                throw new Exception("ExtrudeXCommand::ExecuteCmd:Only a MayeArc object can be extruded");
            //sct.DeleteObject3D(ref ob);
            Object3D tob = sct.GetObject3D(Context.EvalText(szPar5));
            if (tob != null)
                throw new Exception("ExtrudeXCommand:ExecuteCmd:Cannot extrude in a existing target object.");

            arc = (MayeArc)ob;
            mayesurf = new MayeSurface(Convert.ToInt32(szPar3), arc.m_nLong, ob.m_Color, Context.EvalText(szPar5), false);
            //            mayeLine = new Line3D(new Vector3(x1, y1, z1 ), new Vector3(x2, y2, z2), Convert.ToInt32(szPar7),             System.Drawing.Color.FromArgb(Int32.Parse(szPar8, System.Globalization.NumberStyles.HexNumber)), szPar10, false);
            arc.ExtrudeX(x, 0, ref mayesurf);
            Scene3D sc = (Scene3D)sct.m_MainSceneNode.m_Scene3DRef;
            sct.AddObject3D(sc.m_Keyname, mayesurf);
        }
    }
}
