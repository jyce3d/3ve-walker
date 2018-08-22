using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using System.Reflection;
using Context;
using Language.Commands;
using System.Windows.Forms;//Temporary


namespace Language.Parser
{
    // GenParser : allow to implement any kin.d of scripting language by derivating the CustomCommand class
    //                Basic Conditional and variable handling are defined in this base class
    //                Command such let(),set(), kill() and list_var()
    //                Handle the script parsing : instruction tree building
    //                Handle the scirpt execution
    // Author : Jyce Aug-2007
    public class GenParser
    {
        public const int PARSE_OK=0;
        public const int PARSE_NOK=1;

        protected string[] m_ScriptLines; //using System.Collections;
        protected GenContext m_Context;
        protected Object m_Tag;
        protected ArrayList m_Output; // Some commands give an output (for e.g list_var() )
        protected int m_iCurLine; // Current Parsed Line in the script
        protected void IncScriptLine(ref bool bContinue)
        {
            m_iCurLine++;
            if (m_iCurLine == m_ScriptLines.Length)
                bContinue = false;
        }
        protected void GetElseEndifLine(ref int iElseLine, ref int iEndifLine, ref bool bContinue)
        { 
          int level=0;
         // PUSH Context
          bool oldbContinue=bContinue;
          int oldiLine=m_iCurLine;
          bool bNotEndifFound=true;
          string szCommand="", szContent="";
          string szStr;
          while ((bContinue) && (bNotEndifFound))
          {
           szStr=(string)m_ScriptLines[m_iCurLine];
           ParseLine(szStr,ref szCommand,ref szContent);
           if (szCommand.ToLower()=="if")
            level++; else
           if ((szCommand.ToLower()=="else") && (level==0))
            iElseLine=m_iCurLine; else
            if ((szCommand.ToLower()=="endif") && (level>0)) 
              level--; else
             if ((szCommand.ToLower()=="endif") && (level==0))
             {
              iEndifLine=m_iCurLine;
              bNotEndifFound=false;
             }
           IncScriptLine(ref bContinue);
          }
          //POP Context
          bContinue=oldbContinue;
          m_iCurLine=oldiLine;
        }
        protected void ExecuteIf(ref bool bContinue, string szCondition)
        {
          int iElseLine=-1, iEndIfLine=-1;
        //  IncScriptLine(ref bContinue);
          GetElseEndifLine(ref iElseLine,ref iEndIfLine,ref bContinue);
          if (iEndIfLine==-1) 
              throw new Exception("GenParser::ExecuteIf:There is no 'endif' statement for that 'if' statement");
          if (!m_Context.EvalBoolean(szCondition))
          {  // Test s'il y a un else
              if (iElseLine != -1)
              {
                  m_iCurLine = iElseLine + 1;
                  while (m_iCurLine <= iEndIfLine)
                    ExecuteNeutral(ref bContinue);
              }
          }
          else
          {          
              while (m_iCurLine <= iEndIfLine)
                ExecuteNeutral(ref bContinue);
          }
          m_iCurLine = iEndIfLine;
        }
        protected void GetWendLine(ref int iWendLine, ref bool bContinue)
        {
              int level=0;
        // PUSH Context
              bool oldbContinue=bContinue;
              int oldiLine=m_iCurLine;
              bool bNotWendFound=true;
              string szCommand="", szContent="";
              while ((bContinue) && (bNotWendFound))
              {
               string szStr=(string)m_ScriptLines[m_iCurLine];
               ParseLine(szStr,ref szCommand,ref szContent);
               if (szCommand.ToLower()=="while") 
                level++; else
                if ((szCommand.ToLower()=="wend") && (level>0))
                    level--; else
                 if ((szCommand.ToLower()=="wend") && (level==0))
                 {
                  iWendLine=m_iCurLine;
                  bNotWendFound=false;
                 }
        
               IncScriptLine(ref bContinue);
              }
    // POP Context
              bContinue=oldbContinue;
              m_iCurLine=oldiLine;

        }
        protected void ExecuteWhile(ref bool bContinue, string sCondition)
        {
          //IncScriptLine(ref bContinue);
          int iWendLine=-1;
          GetWendLine(ref iWendLine, ref bContinue);
          if (iWendLine==-1) 
           throw new Exception("GenParser::ExecuteWhile:There is no 'wend' statement for that 'while' statement");
          int iFirstWhileLine=m_iCurLine;

          while (m_Context.EvalBoolean(sCondition))
          {
             ExecuteNeutral(ref bContinue);
             if (m_iCurLine==iWendLine)
              m_iCurLine=iFirstWhileLine;
          }
          m_iCurLine=iWendLine;
        }

        protected string RemoveComments(string szStr)
        {
            int iPos = szStr.IndexOf("//");
            if (iPos == -1)
                return szStr;
            else
                return szStr.Substring(0,  iPos );
        }
        protected void ExtractCommand(string szStr, ref string szCommand, ref string szContent)
        {
            //TODO: test the particular x=something
            bool bProcessed = false;
            string szLeft="", szRight = "";
            if ( (szStr.IndexOf("==") == -1) && (szStr.IndexOf("<=")==-1) && (szStr.IndexOf(">=")==-1) & (szStr.IndexOf("!=")==-1))
            {
                if (szStr.IndexOf("=") != -1)
                {
                    m_Context.ExtractOpera("=", szStr, ref szLeft, ref szRight);
                    szCommand = "let";
                    szContent = szLeft + "," + szRight;

                    bProcessed = true;
                }
            }
            if (!bProcessed)
            {
                if (GenContext.GetCharAtPos(szStr.Length-1, szStr) != ')')
                    throw new Exception("GenParser::Invalid Command format");
                else
                {
                    int i = 0;
                    char c;
                    while (((c = GenContext.GetCharAtPos(i, szStr)) != '(') && (i <= szStr.Length))
                    {
                        szCommand += c.ToString();
                        i++;
                    }
                    if (c == '(')
                        szContent = szStr.Substring(i + 1, szStr.Length - i-2 );

                }
            }
        }
        protected void ParseLine(string szLine, ref string szCommand, ref string szContent)
        {
            string szStr_ = GenContext.RemoveBlank(szLine);
            string szStr = RemoveComments(szStr_);
            if (szStr != "")
                if (GenContext.IsParanthese(szStr))
                    ExtractCommand(szStr, ref szCommand, ref szContent);
                else
                {
                    if ((szStr.IndexOf("==") == -1) && (szStr.IndexOf("<=") == -1) && (szStr.IndexOf(">=") == -1) && (szStr.IndexOf("!=")==-1))
                    {
                        if (szStr.IndexOf("=") != -1)
                        {
                            ExtractCommand(szStr, ref szCommand, ref szContent);
                        }
                        else
                        {
                            szCommand = szStr;
                            szContent = "";
                        }
                    }
                    else
                        throw new Exception("GenParser.cs::ParseLine:Conditional operator unappropriate");
                }
        }
        //TODO:MUST BE OVERRIDEN in the child class
        protected virtual void OnExecuteNeutral(ref bool bContinue, string szCommand, string szContent)
        {
            Parse(szCommand, szContent);
        }
        // Must be overriden by the child class if new block command are added
        protected virtual bool OnEndBlockCommand(string szCommand)
        {
            if (szCommand.ToLower() == "endif")
                return true;
            else
                if (szCommand.ToLower() == "wend")
                    return true;
                else
                    return false;
        }
        //
        protected void ExecuteNeutral(ref bool bContinue)
        {
            string szCommand="", szContent="";
            if (bContinue)
            {
                ParseLine((string)m_ScriptLines[m_iCurLine], ref szCommand, ref szContent);
                IncScriptLine(ref bContinue);
                if (szCommand != "")
                {  
                     if (szCommand.ToLower() == "if")
                          ExecuteIf(ref bContinue, szContent);
                     else
                         if (szCommand.ToLower() == "while")
                              ExecuteWhile(ref bContinue, szContent);
                         else
                             OnExecuteNeutral(ref bContinue, szCommand, szContent);
                }
            }

        }
        protected int Parse(string szCommand, string szContent)
        {
            // A game designed by reflection comme dxit the designer republic (wipeout)
            try
            {
                if (!OnEndBlockCommand(szCommand))
                {
                    Type cmdClass = Type.GetType("Language.Commands." + szCommand.ToLower() + "Command");
                    GenCommand obj = (GenCommand)Activator.CreateInstance(cmdClass);
                    obj.ExecuteCmd(szContent, ref m_Context, ref m_Output, ref m_Tag);
                }
            }
            catch 
            {
                throw new Exception("Syntax error or Command " + szCommand + " is not supported by the interpreter");
            }
            return 0;

        }
        public GenParser(GenContext Context, ref ArrayList Output, ref  Object Tag)
        {
            m_Context = Context;
            m_Output = Output;
            m_Tag = Tag;
        }
        public void Execute(string[] Script)
        {
            bool bExecuteCondition = true;
            m_iCurLine = 0;
            m_ScriptLines = Script;

            while (bExecuteCondition)
            {
                try
                {
                    ExecuteNeutral(ref bExecuteCondition);
                }
                catch (Exception e)
                {
                    throw new Exception(e.Message + " at line " + m_iCurLine);
                }

            }


        }


    }
}
