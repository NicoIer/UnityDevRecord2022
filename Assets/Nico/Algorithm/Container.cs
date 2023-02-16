using System;
using System.Collections.Generic;

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
    }
}