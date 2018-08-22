using System;
using System.Collections.Generic;
using System.Text;
using Context;

namespace _ve_Walker
{
    public class SceneNode
    {
        public Object m_Scene3DRef;
        public SceneTree m_ParentTree;
        public Collection m_SceneNodeChilds;
        public SceneNode m_ParentNode;
        public SceneNode(SceneTree parent, SceneNode parentNode)
        {
            m_ParentTree = parent;
            m_SceneNodeChilds=new Collection();
            m_ParentNode = parentNode;
        
        }
        public void AddScene3DRef(Object sc)
        {
            m_Scene3DRef = sc;
        }


    }
}
