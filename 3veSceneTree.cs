using System;
using System.Collections.Generic;
using System.Text;
using Context;
using Microsoft.DirectX;
using Microsoft.DirectX.Direct3D;

namespace _ve_Walker
{
    public class SceneTree
    {
        public Collection m_Object3DList;
        public SceneNode m_MainSceneNode;
        public SceneTree()
        {
         
            m_Object3DList = new Collection();
            // Create the main scene
            //m_MainSceneNode = new SceneNode(this, null);
            Scene3D sc = new Scene3D("MainScene", false);
            m_MainSceneNode=AddScene3DRef(null,sc);
            //m_MainSceneNode.AddScene3DRef(obRef);

        }
        public bool CheckName(string key)
        {
            int i;
            for (i = 0; i < m_Object3DList.Count; i++)
            {
                Object3D ob=(Object3D)m_Object3DList[i];
               
                if (ob.m_Keyname.ToLower() == key.ToLower())
                    return true;
            }
            return false;
        }
        public Scene3D GetScene3D(string scName)
        {
            int i;
            Scene3D sc;
            for (i = 0; i < m_Object3DList.Count; i++)
            {
                if (m_Object3DList[i] is Scene3D)
                {
                    sc=(Scene3D)m_Object3DList[i];
                    if (sc.m_Keyname.ToLower() == scName.ToLower())
                        return sc;
                }
            }
            return null;
        }

        public void AddObject3D(string SceneKeyName, Object3D obj3D)
        {
          
            if (CheckName(obj3D.m_Keyname))
                throw new Exception("SceneTree::AddScene3D:the " + SceneKeyName + " identifier is already used.");
            Scene3D sc = GetScene3D(SceneKeyName);
            if (sc == null)
                throw new Exception("SceneTree::AddObject3D:This scene " + SceneKeyName + " does not exist");
            else
            {
                int iPos=m_Object3DList.Add(obj3D);
                // add the reference
                sc.AddObject3DRef(m_Object3DList[iPos]);
            }
        }
        protected SceneNode RecurGetSceneNode(SceneNode cur, Scene3D sc)
        {
            if (cur.m_Scene3DRef == sc)
                return cur;

            SceneNode node = null;
            for (int i = 0; i < cur.m_SceneNodeChilds.Count; i++)
            {
                node = RecurGetSceneNode((SceneNode)cur.m_SceneNodeChilds[i], sc);
                if (node!=null) break;
            }
            return node; // if no scenenode found

        }
        public SceneNode GetSceneNode(Scene3D sc)
        {
          
               return  RecurGetSceneNode(m_MainSceneNode, sc);
        }

        public SceneNode AddScene3DRef(SceneNode parentNode, Scene3D sc)
        {
            SceneNode curNode=null,newNode=null;
            if (CheckName(sc.m_Keyname))
                throw new Exception("SceneTree::AddScene3D:the " + sc.m_Keyname + " identifier is already used.");
            int iPos= m_Object3DList.Add(sc);
            Object scRef = m_Object3DList[iPos];
            if (parentNode == null)
            {
                // take the main scene
                curNode = m_MainSceneNode;
            }
            else
            {
                curNode = GetSceneNode((Scene3D)parentNode.m_Scene3DRef);
                if (curNode == null)
                    throw new Exception("SceneTree::AddScene3D:Scene does not exists");
               
            }
            // 
            newNode = new SceneNode(this, curNode);
            newNode.m_ParentNode = curNode;
            newNode.AddScene3DRef(scRef);
            if (curNode!=null)
             curNode.m_SceneNodeChilds.Add(newNode);
            return newNode;   
        }
        public void RecurDrawScene(SceneNode curNode, Device device)
        {
            Scene3D sc = (Scene3D)curNode.m_Scene3DRef;
            sc.DrawObject(device);
            for (int i = 0; i < curNode.m_SceneNodeChilds.Count; i++)
                RecurDrawScene((SceneNode)curNode.m_SceneNodeChilds[i], device);
        }
        public void DrawScenes(Device device)
        {
            RecurDrawScene(m_MainSceneNode, device);
        }
        public void RecurScaleScene(SceneNode curNode, float fScale)
        {
            Scene3D sc = (Scene3D)curNode.m_Scene3DRef;
            sc.Scale(fScale);
            for (int i = 0; i < curNode.m_SceneNodeChilds.Count; i++)
                RecurScaleScene((SceneNode)curNode.m_SceneNodeChilds[i], fScale);
        }

        public void ScaleScenes(float fScale)
        {
            RecurScaleScene(m_MainSceneNode, fScale);
        }
        public Scene3D GetScene3D(Object3D ob)
        {
            for (int i = 0; i < m_Object3DList.Count; i++)
            {
                if (m_Object3DList[i] is Scene3D)
                {
                    Scene3D sc=(Scene3D)m_Object3DList[i];
                    for (int j = 0; j < sc.m_Object3DRefList.Count; j++)
                    {
                        if (sc.m_Object3DRefList[i] == ob)
                            return sc;
                    }
                }
            }
            return null;
        }
        public void DeleteObject3D(ref Object3D ob)
        {
            Scene3D sc = GetScene3D(ob);
            if (sc == null)
                throw new Exception("SceneTree::DeleteObject3D:This Object is not a part of a scene");
            SceneNode sn = GetSceneNode(sc);
            if (sn == null)
                throw new Exception("SceneTree::DeleteObject3D:This SceneNode is not existing");
            // Remove the objectRef from the scene3D
            Object obRef = m_Object3DList[m_Object3DList.IndexOf(ob)];
            sc.m_Object3DRefList.Remove(obRef);
            // Remove the Object from the main list
            m_Object3DList.Remove(ob);
            // Destroy the object
            ob = null;
        }
        public Object3D GetObject3D(string szName)
        {
            for (int i=0;i<m_Object3DList.Count;i++)
            {
                Object3D ob=(Object3D)m_Object3DList[i];
                if (ob.m_Keyname.ToLower() == szName.ToLower())
                    return ob;
            }
            return null;
        }

    }
}
