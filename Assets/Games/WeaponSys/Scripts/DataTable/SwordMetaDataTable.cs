using System;
using System.Collections.Generic;
using UnityEngine;

namespace Nico.Data
{
    [Serializable]
    public class SwordMetaData : MetaData
    {
        public int id;
        public string name;
        public int numOfAttack;
        public float maxInterval;
        public string description;
        public int[] animIDs;
    }

    public class SwordMetaDataTable : DataTable
    {
        public List<SwordMetaData> dataList = new();
        public int Count => dataList.Count;

        public SwordMetaData GetByID(int idx)
        {
            return (SwordMetaData)dataList[idx];
        }

        public override void Add(MetaData data)
        {
            dataList.Add((SwordMetaData)data);
        }
    }
    
}