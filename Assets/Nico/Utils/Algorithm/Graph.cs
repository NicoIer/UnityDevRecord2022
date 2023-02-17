using System;
using System.Collections.Generic;
using Nico.Interface;
using UnityEngine;

namespace Nico.Algorithm
{
    public static class Graph
    {
        private static List<(Vector2Int, Vector2Int, float)> CreateEdges(List<Vector2Int> points)
        {
            List<(Vector2Int, Vector2Int, float)> edges = new List<(Vector2Int, Vector2Int, float)>();
            for (int i = 0; i < points.Count; i++)
            {
                for (int j = i + 1; j < points.Count; j++)
                {
                    float distance = Distance.Manhattan(points[i], points[j]);
                    edges.Add((points[i], points[j], distance));
                }
            }

            return edges;
        }

        public static List<(T, T, float)> CalEdges<T>(List<T> points, Func<T, T, float> distanceFunc)
        {
            List<(T, T, float)> edges = new List<(T, T, float)>();
            for (int i = 0; i < points.Count; i++)
            {
                for (int j = i + 1; j < points.Count; j++)
                {
                    float distance = distanceFunc(points[i], points[j]);
                    edges.Add((points[i], points[j], distance));
                }
            }

            return edges;
        }
        
        public static Dictionary<T, T> Kruskal<T>(List<T> points, Func<T, T, float> distanceFunc)
        {
            var edges = CalEdges(points, distanceFunc);
            edges.Sort((a, b) => a.Item3.CompareTo(b.Item3));
            Dictionary<T, T> parentDict = new Dictionary<T, T>();
            foreach (var point in points)
            {
                parentDict[point] = point;
            }

            Dictionary<T, T> result = new Dictionary<T, T>();
            foreach (var edge in edges)
            {
                T root1 = Find(edge.Item1, parentDict);
                T root2 = Find(edge.Item2, parentDict);
                if (!root1.Equals(root2))
                {
                    Union(root1, root2, parentDict);
                    result.Add(edge.Item1, edge.Item2);
                }
            }

            return result;
        }

        private static void Union<T>(T root1, T root2, Dictionary<T, T> parentDict)
        {
            parentDict[root2] = root1;
        }

        private static T Find<T>(T point, Dictionary<T, T> parentDict)
        {
            if (!parentDict[point].Equals(point))
            {
                parentDict[point] = Find(parentDict[point], parentDict);
            }

            return parentDict[point];
        }
    }
}