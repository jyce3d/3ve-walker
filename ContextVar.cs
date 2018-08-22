using System;
using System.Collections.Generic;
using System.Text;

namespace Context
{
    public class ContextVar : CollectionItem
    {
        public const int CTVAR_FLOAT = 0;
        public const int CTVAR_TEXT = 1;
        public const int CTVAR_INVALID = -1;

        public string m_sName, m_sValue;
        public int m_iType;
        public bool m_bProtected;
        public static bool isValidVarName(string szVarName)
        {
            if (szVarName == "")
                return false; else
            if (szVarName.IndexOf("\"") != -1)
                return false;
            else
                if (szVarName.IndexOf("'") != -1)
                    return false;
                else
                    if (szVarName.IndexOf(")") != -1)
                        return false;
                    else
                        if (szVarName.IndexOf("+") != -1)
                            return false;
                        else
                            if (szVarName.IndexOf("-") != -1)
                                return false;
                            else
                                if (szVarName.IndexOf("/") != -1)
                                    return false;
                                else
                                    if (szVarName.IndexOf("*") != -1)
                                        return false;
                                    else
                                        if (szVarName.IndexOf("^") != -1)
                                            return false;
                                        else
                                            if (szVarName.IndexOf("=") != -1)
                                                return false;
                                            else
                                                if (szVarName.IndexOf("<") != -1)
                                                    return false;
                                                else
                                                    if (szVarName.IndexOf(">") != -1)
                                                        return false;
                                                    else
                                                        if (szVarName.IndexOf("#") != -1)
                                                            return false;
                                                        else
                                                            if (szVarName.IndexOf("!") != -1)
                                                                return false;
                                                            else
                                                                if (szVarName.IndexOf("&") != -1)
                                                                    return false;
                                                                else
                                                                    if (szVarName.IndexOf("|") != -1)
                                                                        return false;
                                                                    else 
                                                                        if (szVarName.IndexOf(" ")!=-1)
                                                                            return false;
                                                                        else
                                                                            return true;

        }
        public ContextVar(string sName, string sValue, int iType, bool bProtected, Collection Owner) : base(Owner)
        {
            m_sName = sName;
            m_sValue = sValue;
            m_bProtected = bProtected;
            m_iType = iType;

        }

    }
}
