using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace Nico.Algorithm
{
    public static class Container
    {
        public static IEnumerable<T> Shuffle<T>(IEnumerable<T> original)
        {
            var list = new List<T>(original);
            for (int i = 0; i < list.Count; i++)
            {
                int index = UnityEngine.Random.Range(i, list.Count);
                yield return list[index];
                list[index] = list[i];
            }
            
        }
        
        
        public static IEnumerable<T> RandomSelect<T>(IEnumerable<T> elements, float percent)
        {
            List<T> elementList = elements.ToList();
            int numElements = Mathf.RoundToInt(elementList.Count * percent);
            HashSet<int> selectedIndices = new HashSet<int>();
            while (selectedIndices.Count < numElements)
            {
                int index = UnityEngine.Random.Range(0, elementList.Count);
                if (!selectedIndices.Contains(index))
                {
                    selectedIndices.Add(index);
                    yield return elementList[index];
                }
            }
        }
    }
}