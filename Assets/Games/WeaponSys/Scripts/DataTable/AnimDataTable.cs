using System;
using System.Collections.Generic;
using UnityEngine;
using WeaponSys;

namespace Nico.Data
{
    [CreateAssetMenu(fileName = "AnimDataTable", menuName = "WeaponSys/AnimDataTable", order = 0)]
    public class AnimDataTable : DataTable
    {
        public List<AnimStorage> dataList = new();
        public int Count => dataList.Count;

        public override void Add(MetaData data)
        {
            dataList.Add(data as AnimStorage);
        }

        public AnimStorage GetByIdx(int idx)
        {
            return dataList[idx];
        }
    }

    [Serializable]
    public class AnimStorage : MetaData
    {
        public List<Sprite> sprites;
    }
}