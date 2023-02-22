using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace Nico.ECC.Dependency
{
    public abstract class DataContainer: ScriptableObject
    {
        [field: SerializeReference] public List<DataElement> dataElements = new List<DataElement>();

        public T GetDataElement<T>() where T : DataElement
        {
            return dataElements.OfType<T>().First();
        }
    }
}