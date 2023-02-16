using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace Nico.Algorithm
{
    public static class PointSelector
    {
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