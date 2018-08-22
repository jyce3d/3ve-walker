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
    class translateCommand : GenCommand
    {
        public override void ExecuteCmd(string szContent, ref GenContext Context, ref ArrayList Output, ref Object Tag)
        {
            base.ExecuteCmd(szContent, ref Context, ref Output, ref Tag);
            if (!(Tag is SceneTree))
                throw new Exception("Translate::ExecuteCmd:The last parameter must be a SceneTree instance");
            SceneTree sct = (SceneTree)Tag;

            int iPos = -1;

            string szPar1 = GenContext.GetFirstParam(szContent, ref iPos, ',');//x
            string szPar2 = GenContext.GetNextParam(szContent, ref iPos, ',');//y
            string szPar3 = GenContext.GetNextParam(szContent, ref iPos, ',');//z
            string szPar4 = GenContext.GetNextParam(szContent, ref iPos, ',');//keyname
            if (GenContext.GetNextParam(szContent, ref iPos, ',') != "")
                throw new Exception("Translate:Invalid argument list.");
       
            Object3D ob = sct.GetObject3D(Context.EvalText(szPar4));
            if (ob == null)
                throw new Exception("Translate:Object " + szPar4 + " does not exist!");
            float x = (float)Context.EvalFloat(szPar1);
            float y = (float)Context.EvalFloat(szPar2);
            float z = (float)Context.EvalFloat(szPar3);

            ob.Translate(x, y, z);
        }
    }
}
