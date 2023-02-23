using System;
using System.Collections.Generic;
using UnityEngine;

namespace Games.DungeonGame.Scripts
{
    public class ObjectPoolManager : MonoBehaviour
    {
        public static ObjectPoolManager instance;

        [field: SerializeReference]
        private Dictionary<string, ObjectPool> poolDict = new Dictionary<string, ObjectPool>();

        private void Awake()
        {
            instance = this;
        }

        public void RegisterPool(string name, ObjectPool pool)
        {
            poolDict.Add(name, pool);
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