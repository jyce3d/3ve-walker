using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using Context;

namespace Language.Commands
{
    class list_varCommand : GenCommand
    {
/*        public list_varCommand(string szContent, ref GenContext Context, string[] Output)
            : base(Context){}
        */
        public override void ExecuteCmd(string szContent, ref GenContext Context, ref ArrayList Output, ref Object Tag)
        {
            base.ExecuteCmd(szContent, ref Context, ref Output, ref Tag);
            int iPos = -1;
            string szPar = GenContext.GetFirstParam(szContent, ref iPos, ',');
            if (szPar != "")
                throw new Exception("Language::Commands:list_var() does not take parameters");
            int i;
            string szStatus = "", szType = "", szLine = "";
            for (i = 0; i < Context.m_Variables.Count; i++)
            {
                ContextVar cv = (ContextVar)Context.m_Variables[i];
                if (cv.m_iType == ContextVar.CTVAR_FLOAT)
                    szType = "FLOAT";
                else
                    if (cv.m_iType == ContextVar.CTVAR_TEXT)
                        szType = "TEXT";
                if (cv.m_bProtected)
                    szStatus = "protected";
                szLine = cv.m_sName + "\t" + szType + "\t" + cv.m_sValue + "\t" + szStatus;
                Output.Add(szLine);
            }

        }

    }
}
