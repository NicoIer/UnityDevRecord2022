using System;
using UnityEngine;

namespace Nico.Data
{
    [Serializable]
    public abstract class DataTable : ScriptableObject
    {
        public abstract void Add(MetaData data);
    }
}