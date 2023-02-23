using System;
using System.Collections.Generic;
using UnityEngine;

namespace DungeonGame.Scripts
{
    public class ObjectPool : MonoBehaviour
    {
        public GameObject prefab;
        private Queue<GameObject> pool = new Queue<GameObject>();

        private void Start()
        {
            ObjectPoolManager.instance.RegisterPool(name, this);
        }

        public GameObject Get()
        {
            if (pool.Count == 0)
            {
                GameObject go = Instantiate(prefab);
                go.SetActive(true);
                return go;
            }

            var obj =  pool.Dequeue();
            obj.SetActive(true);
            return obj;
        }

        public void Return(GameObject go)
        {
            go.transform.SetParent(transform);
            go.SetActive(false);
            pool.Enqueue(go);
        }
    }
}