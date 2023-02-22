using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace Nico.Data
{
    public class DataTableManager : MonoBehaviour
    {
        [field: SerializeField]private List<DataTable> dataTables = new List<DataTable>();
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
        
        
        public T GetDataTable<T>() where T : DataTable
        {
            return dataTables.OfType<T>().First();
        }
    }
}