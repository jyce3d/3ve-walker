using System;
using System.Collections.Generic;
using System.Text;

//(ok)TODO:Remove TrimLeftRight() : sert à rien. La ligne est déjà préblankée par le GenParser
//(ok)TODO:1:Handle the minus case : -1+2 : prendre l'opposé du premier terme avant l'opérateur (tenir compte des paranthèse)
//(to test)TODO:1:Process the following case : "3+2*3"#(i+1)=> Remove all IndexOf on a char (string must be analysed by taking the " into account)
//TODO:2:Check the lines ending with a double operator (overflow of the index):ExtractOpera()
//TODO:2:(not necessary but impredictble results in case of user error):For each eval type check the unsupported/Invalid operators
//(ok)TODO:1:Handle the Strings type : EvalText
//(ok)TODO:1:Handle the comparison operators boolean :EvalBool(main : &,| or &&,||) and ==,!=,<=>,...
//   (ok) géré par les paranthèses...  cas le plus chiant car doit tenir compte d'eval float et d'eval text et veiller à ce que les deux ne soient pas mélangés
//(ok)TODO:EvalParanthese must detect : EvalFloat, EvalText, EvalBool => Define isTextExpression, or isBoolExpression
//TODO:2:When adding a variable : check the reserved Words as Sin, cos, ... and also operators (+,-,==,!=,...)
//(optional)TODO:3: if it is needed implement text functions

//Musics
// Sade : Smooth Operator
// The Pointer Sisters : Dare Me ! (Aout 2007)
// 2 Brothers on the 4th Floor : Come Take My Hand.(Septembre 2007)

namespace Context
{
    public class NoVarException : Exception
    { 
    }
    public class MismatchException : Exception 
    { 
    }
    public class InvalidOperator : Exception
    { 
    }
    public class InvalidVariableName : Exception
    { 
    }

    public class GenContext
    {
        protected string[] m_opera;
        public Collection m_Variables;
        protected string ReverseString(string szValue)
        {
            char[] arr = szValue.ToCharArray();
            int i = 0;
            string szRes="";
            for (i = arr.Length-1; i >= 0; i--)
                szRes +=  arr[i];
            return szRes;

        }
        protected string GetFunctionName(string sValue, ref int iPos)
        {
         string szRes="";
         if (iPos < 0)
             return szRes;
         char[] arrChar = sValue.ToCharArray();
         while(true)
         {
             if (iPos<0)
                 break;

             if (IsOperator(sValue.Substring(iPos, 2)))
                 break;
             if (IsOperator(sValue.Substring(iPos, 1)))
                 break;
             if (arrChar[iPos] == '(')
                 break;
             szRes=szRes+arrChar[iPos];
             iPos--;
         }
         return ReverseString(szRes);
        }
        protected string EvalFunctionAsString(string szFuncName, string szValue)
        {
            if (isTextExpression(szValue))
            {
                return EvalFunctionText(szFuncName, EvalText(szValue));
            }
            else
                return EvalFunctionFloat(szFuncName, EvalFloat(szValue)).ToString();
        }
        protected string EvalFunctionText(string szFuncName, string szValue)
        {
            string s2 = szFuncName;
            s2.ToLower();
// Implement the text function that returns text
            return "";
        }
        protected double EvalFunctionFloat(string szFuncName, double fValue)
        {
            string s2 = szFuncName;
            s2.ToLower();


            if (s2 == "sin")
                return Math.Sin(fValue);
            else
                if (s2 == "cos")
                    return Math.Cos(fValue);
                else
                    if (s2 == "tan")
                        return Math.Tan(fValue);
                    else
                        if (s2 == "asin")
                            return Math.Asin(fValue);
                        else
                            if (s2 == "acos")
                                return Math.Acos(fValue);
                            else
                                if (s2 == "atan")
                                    return Math.Atan(fValue);
                                else
                                    if (s2 == "exp")
                                        return Math.Exp(fValue);
                                    else
                                        if (s2 == "log")
                                            return Math.Log(fValue);
                                        else
                                            throw new Exception("EvalFunction::Unknown function"+s2);
        }
        public void AddFloatVariable(string sName, string sValue, bool bProtected)
        {
            if (m_Variables == null)
                throw new Exception("AddFloatVariable:The FloatVariable list must be initialized");
            m_Variables.AddItem(new ContextVar(sName,sValue ,ContextVar.CTVAR_FLOAT,bProtected , m_Variables));
 
        }
        public void AddTextVariable(string szName, string szValue, bool bProtected)
        {
            if (m_Variables == null)
                throw new Exception("AddTextVariable:The TextVariable list must be initialized");
            m_Variables.AddItem(new ContextVar(szName, szValue, ContextVar.CTVAR_TEXT, bProtected, m_Variables));

        }
        public void AddVariable(string szName, string szValue, int iType, bool bProtected)
        {
            if (iType == ContextVar.CTVAR_FLOAT)
                AddFloatVariable(szName, szValue, bProtected);
            else
                if (iType == ContextVar.CTVAR_TEXT)
                    AddTextVariable(szName, szValue, bProtected);
        }
        public bool isExistVariable(string szName)
        {
            ContextVar cv;
            int i;
            for (i = 0; i < m_Variables.Count; i++)
            {
                cv = (ContextVar)m_Variables[i];
                if (cv.m_sName.ToLower() == szName.ToLower())
                    return true;
            }
            return false;
        }
        public void DeleteVariable(string szVarName)
        {
            if (!isExistVariable(szVarName))
             throw new Exception("GenContext::DeleteVariable:"+szVarName+" does not exist");
            int iPos=-1;
            int i;
            for (i=0;i<m_Variables.Count;i++)
            {
             if (((ContextVar)m_Variables[i]).m_sName.ToLower() == szVarName.ToLower())
             {
                 iPos=i;
                 break;
             }
            }
            if ( !((ContextVar)m_Variables[i]).m_bProtected)
            {
                for (i = iPos + 1; i < m_Variables.Count; i++)
                    m_Variables[i - 1] = m_Variables[i];
                m_Variables.RemoveAt(m_Variables.Count);
            }

        }
        public ContextVar GetVariable(string szVarName_)
        {
            ContextVar cv;
            // Trim Left Right
            //string szVarName = TrimLeftRight(szVarName_);
            string szVarName = szVarName_;
            if (!ContextVar.isValidVarName(szVarName))
                throw new InvalidVariableName();

            for (int i = 0; i < m_Variables.Count; i++)
            {
                cv = (ContextVar)m_Variables[i];
                if (cv.m_sName == szVarName)
                    return cv;
            }
            return null;

        }
/*        protected double GetFloatVariableValue(string var)
        {
            ContextVar cv;
            for (int i = 0; i < m_Variables.Count; i++)
            {
                cv = (ContextVar)m_Variables[i];
                if (cv.m_iType == ContextVar.CTVAR_FLOAT)
                {
                    if (cv.m_sName == var)
                    {
                        if (cv.m_sValue == "")
                            return 0;
                        else
                            return Convert.ToDouble(cv.m_sValue);
                    }
                }
            }
            throw new NoVarException();
        }*/

        public int IndexOfChar(char c, string szSourceStr)
        {
            char[] arrChar=szSourceStr.ToCharArray();
            int i;
            int iPos=-1;
            for (i=0;i<arrChar.Length;i++)
            {
                if (arrChar[i] == c)
                {
                    iPos = i;
                    break;
                }
            }
            return iPos;

        }
        public static bool CompareCharAtPos(char c, int iPos, string szSourceStr)
        {
            char[] arrChar = szSourceStr.ToCharArray();
            if (iPos > arrChar.Length)
                throw new Exception("GenContext::CompareChatAtPos:Index out of bound");     
            if (arrChar[iPos]==c)
                    return true; 
                 else 
                    return false;
        }
        public static char GetCharAtPos(int iPos, string szSourceStr)
        {
            char[] arrChar = szSourceStr.ToCharArray();
            if (iPos > arrChar.Length)
                throw new Exception("GenContext::CompareChatAtPos:Index out of bound");
            return arrChar[iPos];
        }
        public int GetVarType(string szStr)
        {
            if (szStr.ToLower() == "float")
                return ContextVar.CTVAR_FLOAT;
            else
                if (szStr.ToLower() == "text")
                    return ContextVar.CTVAR_TEXT;
                else
                    return ContextVar.CTVAR_INVALID;

        }
        protected bool IsOperator(string szValue)
        {
            int i;
            bool bOpera=false;
            for (i = 0; i < m_opera.Length; i++)
            {
                    if (m_opera[i].IndexOf(szValue) != -1)
                    {
                        bOpera = true;
                        break;
                    }
            }
            return bOpera;
        }
        protected bool IsOperator(char cValue)
        {
            string s;
            s = Convert.ToString(cValue);
            return IsOperator(s);
        }
        public static bool IsParanthese(string sValue)
        {
/*            int i;
            for (i = 0; i < sValue.Length; i++)
            {
                if (IsOperator(GetCharAtPos(i,sValue)))
                    return false;
                else
                    if ((CompareCharAtPos('(', i, sValue)) || (CompareCharAtPos(')', i, sValue)))
                        return true;
            }
            return false;*/
            //return ((sValue.IndexOf("(")!=-1) || (sValue.IndexOf(")")!=-1));
            return ((GetValidStringPos("(", sValue) != -1) || (GetValidStringPos(")", sValue) != -1));
        }

        // Evaluate the content of a string expression
        // whatever the expected type (float, bool or text)
        // the returned type is always a string.
        // ENTRY: The expression without parantheses
        // RETURN : The string value of the expression
        protected string EvalExpressionAsString(string szValue)
        {
            if (isBooleanExpression(szValue))
                return (EvalBoolean(szValue) ? "1" : "0");
            else
                if (isTextExpression(szValue))
                    return EvalText(szValue);
                else
                    return EvalFloat(szValue).ToString();

        
        }
        protected string  EvalParanthese(string sValue)
        {
            int i;
            int iStartPos=-1;
            int iEndPos=-1;
            bool bValid = true;
            for (i = 0; i < sValue.Length; i++)
            {
                if (CompareCharAtPos('\"', i, sValue))
                    bValid = !bValid;

                if (bValid)
                {
                    if (CompareCharAtPos('(', i, sValue))
                        iStartPos = i;
                    if (CompareCharAtPos(')', i, sValue))
                    {
                        iEndPos = i;
                        break;
                    }
                }
            }
            // Check the problematic cases
            if ((iStartPos==-1) && (iEndPos!=-1))
             throw new Exception("End paranthese without start paranthese");
            if ((iStartPos!=-1) && (iEndPos==-1))
              throw new Exception("Start paranthese without end paranthese");
            if ((iStartPos > iEndPos))
              throw new Exception("Paranthese mismatch");
            // right cases
          string s;
          s = sValue.Substring(iStartPos + 1, iEndPos - iStartPos-1);
          int iCurPos = iStartPos - 1;
          string sFunc = GetFunctionName(sValue, ref iCurPos);
          string s1;
          if (sFunc == "")
                 s1 = EvalExpressionAsString(s);
          else
          {
              s1 = EvalFunctionAsString(sFunc, EvalExpressionAsString(s));
              iStartPos=iCurPos+1;
          }
          string sBefore = sValue.Substring(0, iStartPos);
          string sAfter = sValue.Substring(iEndPos+1, sValue.Length - iEndPos-1 );
        
          return sBefore+s1+sAfter;
 
        }
        public bool ExtractOpera(string szOpera, string szStr, ref string szLeft, ref string szRight)
        {
            int i;
            char c1,c2;
            bool bValid = true;
            if (!IsOperator(szOpera))
                throw new Exception(szOpera+" is not a valid operator.");
            // Check the length of operator
            if (szOpera.Length==1)
            {
                c1=GetCharAtPos(0,szOpera);
                for (i = 0; i < szStr.Length; i++)
                {
                    if (GetCharAtPos(i, szStr) == '\"')
                        bValid = !bValid;
                    if (bValid)
                    {
                        if (GetCharAtPos(i, szStr) == c1)
                        {
                            if (i > 0)
                                szLeft = szStr.Substring(0, i);
                            else
                                szLeft = "0";
                            szRight = szStr.Substring(i + 1, szStr.Length - i - 1);
                            return true;
                        }
                    }
                }
                return false;
           }
           else 
           {
               c1 = GetCharAtPos(0, szOpera);
               c2 = GetCharAtPos(1, szOpera);
               for (i = 0; i < szStr.Length; i++)
               {
                   if (GetCharAtPos(i, szStr) == '\"')
                       bValid = !bValid;
                   if (bValid)
                   {
                       if ((GetCharAtPos(i, szStr) == c1) && (GetCharAtPos(i + 1, szStr) == c2))
                       {
                           if (i > 0)
                               szLeft = szStr.Substring(0, i);
                           else
                               szLeft = "";
                           szRight = szStr.Substring(i + 2, szStr.Length - i - 2);
                           return true;
                       }
                   }
               }
               return false;
           }
        }
        protected double RecurEvalFloat(string sValue)
        {
            string szLeft="", szRight="";
            if (ExtractOpera ("+", sValue, ref szLeft, ref szRight))
            {
                       return RecurEvalFloat(szLeft) + RecurEvalFloat(szRight);
            }
            else
                if (ExtractOpera("-", sValue, ref szLeft, ref szRight))
                    {
                        
                        // Is the left member null : Yes return - ( first term)
                        if (szLeft == "")
                            return -RecurEvalFloat(szRight);
                        else
                        {
                                return RecurEvalFloat(szLeft) - RecurEvalFloat(szRight);
                        }
                    }
                    else
                        if (ExtractOpera("*", sValue, ref szLeft, ref szRight))
                        {
                                return RecurEvalFloat(szLeft) * RecurEvalFloat(szRight);
                        }
                        else
                            if (ExtractOpera("/", sValue, ref szLeft, ref szRight))
                            {
                                    return RecurEvalFloat(szLeft) / RecurEvalFloat(szRight);
                            }
                            else
                                if (ExtractOpera("^", sValue, ref szLeft, ref szRight))
                                {
                                        return Math.Pow(RecurEvalFloat(szLeft), RecurEvalFloat(szRight));
                                }

            
            if (sValue.IndexOf('\"') != -1) // Si la valeur contient un text
                throw new MismatchException();
            try
            {
                return Convert.ToDouble(sValue);
            }
            catch (Exception e)
            {
                if (e is System.FormatException)
                {
                    ContextVar cv;
                    cv = GetVariable(sValue);
                    if (cv == null)
                        throw new Exception("GenContext::RecurEvalFloat:The variable " + sValue + " does not exist.");
                    else
                        if (cv.m_iType != ContextVar.CTVAR_FLOAT)
                            throw new Exception("GenContext::RecurEvalFloat:The variable " + sValue + " is not a float.");
                        else
                            return Convert.ToDouble(cv.m_sValue);
                }
                else
                    throw e;
            }
        }

        public double EvalFloat(string sValue)
        {
            if (sValue.Length == 0)
                throw new Exception("Context::EvalFloat:Cannot eval an empty expression.");
            try
            {
                while (IsParanthese(sValue))
                    sValue=EvalParanthese(sValue);
                return RecurEvalFloat(sValue);
            }
            catch (Exception e)
            {
                throw e;
            }
        }
        public string EvalText(string sValue)
        {
            if (sValue.Length == 0)
                throw new Exception("Context::EvalFloat:Cannot eval an empty expression.");
            try
            {
                while (IsParanthese(sValue))
                    sValue = EvalParanthese(sValue);
                return RecurEvalText(sValue);
            }
            catch (Exception e)
            {
                throw e;
            }
        }
        public bool EvalBoolean(string sValue)
        {
            if (sValue.Length == 0)
                throw new Exception("Context::EvalBoolean:Cannot eval an empty expression.");
            try
            {
                while (IsParanthese(sValue))
                    sValue = EvalParanthese(sValue);
                return RecurEvalBoolean(sValue);
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        public GenContext()
        {
            m_Variables = new Collection();
            AddFloatVariable("pi", Convert.ToString((double)(4*Math.Atan(1))), true);

            m_opera = new string[15] {"+","-","*","/","^","#","!","&","|","<",">","==","!=","<=",">="};


        }
        public bool isBooleanExpression(string szValue)
        {
            if (GetValidStringPos("<",szValue) != -1)
                return true;
            else
                if (GetValidStringPos(">",szValue) != -1) return true;
                else
                    if (GetValidStringPos("==",szValue) != -1) return true;
                    else
                        if (GetValidStringPos("!=",szValue) != -1) return true;
                        else
                            if (GetValidStringPos("<=",szValue) != -1) return true;
                            else
                                if (GetValidStringPos(">=",szValue) != -1) return true;
                                else
                                    if (GetValidStringPos("!",szValue) != -1) return true;
                                    else
                                        if (GetValidStringPos("&",szValue) != -1) return true;
                                        else
                                            if (GetValidStringPos("|",szValue) != -1) return true;

                                    // Cas où il n'y a pas d'opérateur mais juste une valeur ou une variable
                                    // Non supporté par les booleans=> d'office si c'est le cas c'est que c'est pas un boolean
                                    return false;
        }
        public bool isRecurTextExpression(string szValue)
        {
            ContextVar cv;
            string szLeft="", szRight="";
            if (GetValidStringPos("+",szValue) == -1)
            {// Must remain a variable, check if the variable is Text Type
                cv=GetVariable(szValue);
                if (cv == null)
                    return false;
                else
                    if (cv.m_iType == ContextVar.CTVAR_TEXT)
                        return true;
                    else
                        return false;
            }
                else
                {
                     ExtractOpera("+", szValue, ref szLeft, ref szRight);
                     return isRecurTextExpression(szLeft) & isRecurTextExpression(szRight);
                    
                }
                 

        }
        public bool isTextExpression(string szValue)
        {
            if (isBooleanExpression(szValue))
                return false;
            else
                if (GetValidStringPos("\"",szValue) != -1)
                    return true;
                else
                    if (GetValidStringPos("#",szValue) != -1)
                        return true;
                    else
                        if (GetValidStringPos("-",szValue) != -1)
                            return false;
                        else
                            if (GetValidStringPos("*",szValue) != -1)
                                return false;
                            else
                                if (GetValidStringPos("/",szValue) != -1)
                                    return false;
                                else
                                    if (GetValidStringPos("^",szValue) != -1)
                                        return false;
                                    else
                                        return isRecurTextExpression(szValue);


        }
        // Return -1 : if the character is found outside a quoted string;
       /* protected bool GetValidStringPosIsEqual(int iPos, string szSub, string szMain)
        {
            int i = 0, j = 0;
            for (i = iPos; i < szMain.Length; i++)
            {
                for (j = 0; j < szSub.Length; j++)
                {
                    if (GetCharAtPos(i, szMain) != GetCharAtPos(j, szSub))
                        return false;
                }
            }
            return true;
        }*/
        public static bool CompareSubstringAtPos(int iPos, string szSubs, string szMain)
        {
            int i,j;
            if (szSubs.Length+iPos>szMain.Length)
                return false;
            for (i=iPos;i<(iPos+szSubs.Length);i++)
            {
                for (j = 0; j < szSubs.Length; j++)
                {
                    if (GetCharAtPos(i, szMain) != GetCharAtPos(j, szSubs))
                        return false;
                }
            }
            return true;

        }
        public static int GetValidStringPos(string szSearch, string szStr)
        {
            bool bValid = true;
            if (szSearch == "")
                return -1;
            for (int i = 0; i < szStr.Length; i++)
            {
                if (CompareCharAtPos('\"', i, szStr))
                    bValid = !bValid;
                if (bValid)
                {// Test si le premier caractère correspond
                    //if (CompareCharAtPos(GetCharAtPos(0, szSearch), i, szStr))
                     //   if (GetValidStringPosIsEqual(i, szSearch, szStr))
                    if (CompareSubstringAtPos(i,szSearch, szStr))
                            return i;
                }
            }
            return -1;
        }
        protected string RecurEvalText(string szValue)
        {
            string szLeft="", szRight="";
            if (ExtractOpera("+", szValue, ref szLeft, ref szRight))
            {
                return RecurEvalText(szLeft) + RecurEvalText(szRight);
            }
            else
                if (ExtractOpera("#", szValue, ref szLeft, ref szRight))
                {
                    return RecurEvalText(szLeft) + RecurEvalFloat(szRight).ToString();
                }

// Si pas d'opérateurs
            if (szValue.IndexOf('\"') != -1) // Si la valeur contient un text on renvoit le texte
                return ExtractQuotes(szValue);
            else
            {
                ContextVar cv;
                cv = GetVariable(szValue);
                if (cv == null)
                    throw new Exception("GenContext::RecurEvalText:The variable " + szValue + " does not exist.");
                else
                    if (cv.m_iType != ContextVar.CTVAR_TEXT)
                        throw new Exception("GenContext::RecurEvalText:The variable " + szValue + " is not a Text.");
                    else
                        return cv.m_sValue;

            }
 
        }
        protected string ExtractQuotes(string szValue)
        {
            int i;
            string szRet="";
           // string szValue2 = TrimLeftRight(szValue);
            string szValue2 = szValue;
            if (szValue2 == "")
                return szValue2;
            if ((GetCharAtPos(0, szValue2) != '\"') && (GetCharAtPos(szValue2.Length, szValue2) != '\"'))
                throw new Exception("GenContext::ExtractQuotes:Not a valid string");
            for (i = 1; i < szValue2.Length-1; i++)
            {
                if (GetCharAtPos(i, szValue2) == '\"')
                    throw new Exception("GenContext::ExtractQuotes:Improper usage of \" in a text");
                szRet += GetCharAtPos(i, szValue2).ToString();
            }
            return szRet;
        }
        public static string TrimLeftRight(string szVarName)
        {
            int sPos = -1, ePos = -1;
            for (int i = 0; i < szVarName.Length; i++)
            {
                if (GetCharAtPos(i, szVarName) != ' ')
                {
                    sPos = i;
                    break;
                }
            }
            for (int i = szVarName.Length - 1; i >= 0; i--)
            {
                if (GetCharAtPos(i, szVarName) != ' ')
                {
                    ePos = i;
                    break;
                }
            }
            if ((ePos == -1) || (sPos == -1))
                szVarName = "";
            else
                szVarName = szVarName.Substring(sPos, szVarName.Length - ePos +1);
            return szVarName;

        }
        protected bool RecurEvalBoolean(string szValue)
        {
            string szLeft = "", szRight = "";
            if (ExtractOpera("|", szValue, ref szLeft, ref szRight))
            {
                return RecurEvalBoolean(szLeft) | RecurEvalBoolean(szRight);
            }
            else
                if (ExtractOpera("&", szValue, ref szLeft, ref szRight))
                {
                    return RecurEvalBoolean(szLeft) & RecurEvalBoolean(szRight);
                }
                else
                    if (ExtractOpera("==", szValue, ref szLeft, ref szRight))
                    {
                        if (isBooleanExpression(szLeft))
                            throw new Exception("== operator does not work with boolean");
                        else
                            if (isTextExpression(szLeft))
                                return ((RecurEvalText(szLeft)) == (RecurEvalText(szRight)));
                            else
                                return (RecurEvalFloat(szLeft) == RecurEvalFloat(szRight));
                    }
                    else
                    if (ExtractOpera("!=", szValue, ref szLeft, ref szRight))
                    {
                        if (isBooleanExpression(szLeft))
                            throw new Exception("!= operator does not work with boolean");
                        else
                         if (isTextExpression(szLeft))
                             return ((RecurEvalText(szLeft)) != (RecurEvalText(szRight)));
                         else
                          return (RecurEvalFloat(szLeft) != RecurEvalFloat(szRight));
                    }
                    else
                        if (ExtractOpera("!", szValue, ref szLeft, ref szRight))
                        {
                            return !RecurEvalBoolean(szRight);
                        }
                        else
                            if (ExtractOpera("<=", szValue, ref szLeft, ref szRight))
                            {
                                if (isBooleanExpression(szLeft))
                                    throw new Exception("<= operator does not work with boolean");
                                else
                                    if (isTextExpression(szLeft))
                                        throw new Exception("<= is not a text operator");
                                    else
                                        return (RecurEvalFloat(szLeft) <= RecurEvalFloat(szRight));
                            }
                            else
                                if (ExtractOpera(">=", szValue, ref szLeft, ref szRight))
                                {
                                    if (isBooleanExpression(szLeft))
                                        throw new Exception(">= operator does not work with boolean");
                                    else
                                        if (isTextExpression(szLeft))
                                            throw new Exception(">= is not a text operator");
                                        else
                                            return (RecurEvalFloat(szLeft) >= RecurEvalFloat(szRight));
                                }
                                else
                                    if (ExtractOpera("<", szValue, ref szLeft, ref szRight))
                                    {
                                        if (isBooleanExpression(szLeft))
                                            throw new Exception("< operator does not work with boolean");
                                        else
                                            if (isTextExpression(szLeft))
                                                throw new Exception("< is not a text operator");
                                            else
                                                return (RecurEvalFloat(szLeft) < RecurEvalFloat(szRight));
                                    }
                                    else
                                        if (ExtractOpera(">", szValue, ref szLeft, ref szRight))
                                        {
                                            if (isBooleanExpression(szLeft))
                                                throw new Exception("> operator does not work with boolean");
                                            else
                                                if (isTextExpression(szLeft))
                                                    throw new Exception("> is not a text operator");
                                                else
                                                    return (RecurEvalFloat(szLeft) > RecurEvalFloat(szRight));
                                        }
                                        else
                                            throw new InvalidOperator();


        }
        public static string RemoveBlank(string szStr)
        {
            string szRet = "";
            bool bErase = true;
            char c;
            for (int i = 0; i < szStr.Length; i++)
            {
                if (GetCharAtPos(i, szStr) == '\"')
                    bErase = !bErase;
                if ((c = GetCharAtPos(i, szStr)) != ' ')
                    {
                        szRet += c.ToString();
                    }
                    else
                        if (!bErase)
                            szRet += " ";
            }
            return szRet;

        }
        public static string GetFirstParam(string szStr, ref int iPos, char cOpera)
        {
            int i = 0;
            char c;
            string sz2="";
            for (i = 0; i < szStr.Length; i++)
            {
                c = GetCharAtPos(i, szStr);
                if  (!(c==cOpera))
                     sz2 += c.ToString();
                if ( (c == cOpera))
                {
                    iPos = i+1;
                    return sz2;
                }
            }
            iPos = szStr.Length;
            return szStr;
        }
        public static string GetNextParam(string szStr, ref int iPos, char cOpera)
        {
            int i;
            string sz2="";
            char c;
            if (iPos==-1)
                return "";
            else
            if (iPos > szStr.Length)
                return "";
            else
            {
                for (i = iPos; i < szStr.Length; i++)
                {

                    c = GetCharAtPos(i, szStr);
                    if (!(c==cOpera))  sz2 += c.ToString();
                            
                    
                    if ( (c == cOpera))
                    {
                        iPos = i + 1;
                        return sz2;
                    }
                }
                iPos = szStr.Length;
                return sz2;

            }
        }
    }
}
