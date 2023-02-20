using System;
using System.Collections.Generic;
using UnityEngine;

namespace Nico.Data
{
    public class DataTableManager : MonoBehaviour
    {
        public static DataTableManager instance;
        public AnimDataTable animDataTable;
        public SwordMetaDataTable swordMetaDataTable;

        public void Awake()
        {
            if (instance == null)
            {
                instance = this;
            }
            else
            {
                Destroy(gameObject);
            }
        }
        
        
        public static T GetDataTable<T>() where T : DataTable
        {
            throw new NotImplementedException();
        }
    }
}