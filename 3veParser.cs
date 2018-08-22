using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using Context;
using Language.Parser;

namespace _ve_Walker
{
    public class eveParser : GenParser
    {
        protected SceneTree m_SceneTree;
        protected SceneNode m_CurNode;
        public eveParser(ref SceneTree SceneTree,GenContext Context, ref ArrayList Output,ref Object Tag )
            : base(Context, ref Output, ref Tag)            
        {
       
                m_SceneTree = (SceneTree)SceneTree;
                m_CurNode = m_SceneTree.m_MainSceneNode;
                m_Tag = m_SceneTree;// due to the daft declaration of c#
       
        }
        protected void ExecuteBlock(ref bool bContinue, string szContent)
        { 
            // Create a new Scene
            Scene3D sc = new Scene3D(szContent, true);
            // add it in the SceneTree and update the m_CurNode
            m_CurNode=m_SceneTree.AddScene3DRef(m_CurNode, sc);

        }

        protected override void OnExecuteNeutral(ref bool bContinue, string szCommand, string szContent)
        {
            if (szCommand.ToLower() == "block")
                ExecuteBlock(ref bContinue, szContent);
            else
             base.OnExecuteNeutral(ref bContinue,  szCommand,  szContent);
            //Parse(szCommand, szContent);
        }
        protected override bool OnEndBlockCommand(string szCommand)
        {
            if (szCommand.ToLower() == "blend")
            {
                if (m_CurNode.m_ParentNode != null)
                    m_CurNode = m_CurNode.m_ParentNode; // Go up one level
                return true;
            }
            else
                return base.OnEndBlockCommand(szCommand);
        }
    }
}
