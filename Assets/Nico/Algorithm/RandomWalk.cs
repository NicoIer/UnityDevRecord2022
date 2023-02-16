using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;


namespace Algorithm
{
    public static class RandomWalk
    {
        public static HashSet<Vector2Int> Walk(Vector2Int startPoint, int length, int iteration,
            bool startRandomlyEachIteration)
        {
            HashSet<Vector2Int> path = new HashSet<Vector2Int>();
            var currentPoint = startPoint;
            for (int i = 0; i < length; i++)
            {
                path.UnionWith(Walk(currentPoint, length));
                if (startRandomlyEachIteration)
                {
                    currentPoint = path.ElementAt(Random.Range(0, path.Count));
                }
            }

            return path;
        }

        public static HashSet<Vector2Int> Walk(Vector2Int startPoint, int length)
        {
            HashSet<Vector2Int> path = new HashSet<Vector2Int>();
            var previousPoint = startPoint;
            for (int i = 0; i < length; i++)
            {
                var next = previousPoint + Direction2D.GetRadomDirection();
                path.Add(next);
                previousPoint = next;
            }

            return path;
        }
    }
}