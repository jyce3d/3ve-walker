using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using Context;

namespace Language.Commands
{
    class GenCommand
    {
      //  public GenContext m_Context;

       /* public GenCommand(GenContext Context)
        {
            m_Context = Context;
        }*/
        public virtual void ExecuteCmd(string szContent, ref GenContext Context, ref ArrayList Output, ref Object Tag)
        { 

        }
    }
}
