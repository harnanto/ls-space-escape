using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace SpaceEscape
{
    [System.Serializable]
    public class PooledGameObjectEntry
    {
        public string name;
        public GameObject pooledGameObject;
        public int pooledAmount = 20;
        public bool willGrow = false;

        public List<GameObject> m_PooledGameObjects = new List<GameObject>();

        public void PoolGameObjects()
        {
            for (int i = 0; i < pooledAmount; ++i)
            {
                GameObject obj = (GameObject) GameObject.Instantiate(pooledGameObject);
                obj.SetActive(false);
                m_PooledGameObjects.Add(obj);
            }
        }

        public void ClearGameObjects()
        {
            m_PooledGameObjects.Clear();
        }

        public GameObject GetPooledGameObject()
        {
            for (int i = 0; i < m_PooledGameObjects.Count; ++i)
            {
                if (!m_PooledGameObjects[i].activeInHierarchy)
                {
                    return m_PooledGameObjects[i];
                }
            }

            if (willGrow)
            {
                GameObject obj = (GameObject) GameObject.Instantiate(pooledGameObject);
                m_PooledGameObjects.Add(obj);
                return obj;
            }

            return null;
        }
    }

    public class GenericObjectPoolerMultiType : MonoBehaviour
    {
        public List<PooledGameObjectEntry> m_PooledGameObjectEntries;

        public void PoolGameObjects()
        {
            foreach(PooledGameObjectEntry pgoe in m_PooledGameObjectEntries)
            {
                pgoe.PoolGameObjects();
            }
        }

        public void ClearGameObjects()
        {
            foreach (PooledGameObjectEntry pgoe in m_PooledGameObjectEntries)
            {
                pgoe.ClearGameObjects();
            }
        }

        public GameObject GetPooledGameObject(string name)
        {
            foreach (PooledGameObjectEntry pgoe in m_PooledGameObjectEntries)
            {
                if(pgoe.name == name)
                {
                    return pgoe.GetPooledGameObject();
                }
            }
            return null;
        }

    }
}
