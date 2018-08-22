using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using Context;

namespace Language.Commands
{
    class setCommand : GenCommand 
    {
        public override void ExecuteCmd(string szContent, ref GenContext Context, ref ArrayList Output, ref Object Tag)
        {
            base.ExecuteCmd(szContent, ref Context, ref Output, ref Tag);
            int iPos = -1;
            string szPar1 = GenContext.GetFirstParam(szContent, ref iPos, ',');
            string szPar2 = GenContext.GetNextParam(szContent, ref iPos, ',');
            if (GenContext.GetNextParam(szContent, ref iPos, ',') != "")
                throw new Exception("Language.Commands::SetCommand:Invalid argument list.");
            if (Context.isExistVariable(szPar1))
                throw new Exception("Language.Commands::SetCommand:The variable " + szPar1 + " already exists");
            int iVarType = Context.GetVarType(szPar2);
            if (iVarType == ContextVar.CTVAR_INVALID)
                throw new Exception("Language.Commands::SetCommand:" + szPar2 + " is not a valid variable type");
            // Check the variablename
            if (!ContextVar.isValidVarName(szPar1))
                throw new Exception("Language.Commands::SetCommand:" + szPar1 + " is not a valid variable name");
            Context.AddVariable(szPar1, "", iVarType, false);


        }
    }
}
