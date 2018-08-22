using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using Context;

namespace Language.Commands
{
    class letCommand : GenCommand
    {
        public override void ExecuteCmd(string szContent, ref GenContext Context, ref ArrayList Output, ref Object Tag)
        {
            base.ExecuteCmd(szContent, ref Context, ref Output, ref Tag);
            int iPos = -1;
            string szPar1 = GenContext.GetFirstParam(szContent, ref iPos, ',');
            string szPar2 = GenContext.GetNextParam(szContent, ref iPos, ',');
            if (GenContext.GetNextParam(szContent, ref iPos, ',') != "")
                throw new Exception("Language.Commands::letCommand:Invalid argument list.");
            ContextVar cv = Context.GetVariable(szPar1);
            if (cv == null)
                throw new Exception("Language.Commands::letCommand:Variable " + szPar1 + " does not exist");
            if (cv.m_iType == ContextVar.CTVAR_FLOAT)
                cv.m_sValue = Context.EvalFloat(szPar2).ToString();
            else
                if (cv.m_iType == ContextVar.CTVAR_TEXT)
                    cv.m_sValue = Context.EvalText(szPar2);
        }
 
    }
}
