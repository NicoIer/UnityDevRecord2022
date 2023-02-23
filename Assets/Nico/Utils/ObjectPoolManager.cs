using System;
using System.Collections.Generic;
using UnityEngine;

namespace Nico
{
    public class ObjectPoolManager : MonoBehaviour
    {
        public static ObjectPoolManager instance;
        [field: SerializeReference] public List<GameObject> prefabs = new List<GameObject>();

        [field: SerializeReference]
        private Dictionary<string, ObjectPool> poolDict = new Dictionary<string, ObjectPool>();

        private void Awake()
        {
            instance = this;
            foreach (var prefab in prefabs)
            {
                var pool = new GameObject(prefab.name + "Pool").AddComponent<ObjectPool>();
                pool.prefab = prefab;
                pool.transform.SetParent(transform);
                poolDict.TryAdd(prefab.name, pool);
            }
        }

        public void RegisterPool(string name, ObjectPool pool)
        {
            poolDict.TryAdd(name, pool);
        }

        public GameObject GetObject(string name)
        {
            return poolDict[name].Get();
        }

        public void ReturnObject(string name, GameObject go)
        {
            poolDict[name].Return(go);
        }
    }
}