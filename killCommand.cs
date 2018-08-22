using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using Context;

namespace Language.Commands
{
    class killCommand : GenCommand
    {
        public override void ExecuteCmd(string szContent, ref GenContext Context, ref ArrayList Output, ref Object Tag)
        {
            base.ExecuteCmd(szContent, ref Context, ref Output, ref Tag);
            int iPos = -1;
            string szPar;
            while ((szPar = GenContext.GetFirstParam(szContent, ref iPos, ',')) != "")
                Context.DeleteVariable(szPar);

        }
    }
}
