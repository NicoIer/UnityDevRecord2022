using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using Random = UnityEngine.Random;

namespace Nico.Algorithm
{
    public static class PointFinder
    {
        public static HashSet<Vector2Int> FindEdgePoints(HashSet<Vector2Int> points, Vector2Int[] directions)
        {
            var wallPoints = new HashSet<Vector2Int>();
            foreach (var point in points)
            {
                foreach (var direction in directions)
                {
                    var neighbor = point + direction;
                    if (!points.Contains(neighbor))
                    {
                        wallPoints.Add(neighbor);
                    }
                }
            }

            return wallPoints;
        }


        public static List<Vector2Int> FindEndPoints(HashSet<Vector2Int> points)
        {
            var endPoints = new List<Vector2Int>();
            foreach (var point in points)
            {
                int count = 0;
                foreach (var direction in Direction2D.fourDirections)
                {
                    var neighbor = point + direction;
                    if (points.Contains(neighbor))
                    {
                        ++count;
                    }
                }

                if (count < 2)
                {
                    endPoints.Add(point);
                }
            }

            return endPoints;
        }


        public static Vector2Int FindClosestPoint(Vector2Int point, IEnumerable<Vector2Int> points)
        {
            float minDistance = float.MaxValue;
            Vector2Int closest = Vector2Int.zero;
            foreach (var curPoint in points)
            {
                if (curPoint == point)
                    continue;
                var distance = Vector2Int.Distance(point, curPoint);
                if (distance < minDistance)
                {
                    minDistance = distance;
                    closest = curPoint;
                }
            }

            return closest;
        }
        
        
    }
}