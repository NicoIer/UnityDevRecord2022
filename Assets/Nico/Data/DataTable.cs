using System;
using System.Collections.Generic;
using Sirenix.OdinInspector;
using UnityEngine;

namespace Nico.Data
{
    [Serializable]
    public abstract class DataTable : ScriptableObject
    {
        public abstract void Add(MetaData data);
    }
}