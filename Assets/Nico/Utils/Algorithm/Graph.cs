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

        public static List<(T, T, float)> CalEdges<T>(List<T> points) where T : IDistance
        {
            List<(T, T, float)> edges = new List<(T, T, float)>();
            for (int i = 0; i < points.Count; i++)
            {
                for (int j = i + 1; j < points.Count; j++)
                {
                    float distance = Distance.Cal(points[i], points[j]);
                    edges.Add((points[i], points[j], distance));
                }
            }

            return edges;
        }

        public static Dictionary<T, T> Kruskal<T>(List<T> points) where T : IDistance
        {
            var edges = CalEdges(points);
            edges.Sort((a, b) => a.Item3.CompareTo(b.Item3));
            Dictionary<T, T> parentDict = new Dictionary<T, T>();
            foreach (var point in points)
            {
                parentDict[point] = point;
            }
            // foreach (var edge in edges)
            // {
            //     Vector2Int root1 = Find(edge.Item1, parentDict);
            //     Vector2Int root2 = Find(edge.Item2, parentDict);
            //     if (root1 != root2)
            //     {
            //         Union(root1, root2, parentDict);
            //         result.Add(edge.Item1, edge.Item2);
            //     }
            // }
            //
            // return result;
            throw new NotImplementedException();
        }

        /// <summary>
        /// 最小生成树算法
        /// </summary>
        /// <param name="points"></param>
        /// <returns>哪个点和哪个点之间进行连接</returns>
        public static Dictionary<Vector2Int, Vector2Int> Kruskal(List<Vector2Int> points)
        {
            var edges = Graph.CreateEdges(points);
            edges.Sort((a, b) => a.Item3.CompareTo(b.Item3));
            Dictionary<Vector2Int, Vector2Int> parentDict = new Dictionary<Vector2Int, Vector2Int>();
            foreach (var point in points)
            {
                parentDict[point] = point;
            }

            Dictionary<Vector2Int, Vector2Int> result = new Dictionary<Vector2Int, Vector2Int>();
            foreach (var edge in edges)
            {
                Vector2Int root1 = Find(edge.Item1, parentDict);
                Vector2Int root2 = Find(edge.Item2, parentDict);
                if (root1 != root2)
                {
                    Union(root1, root2, parentDict);
                    result.Add(edge.Item1, edge.Item2);
                }
            }

            return result;
        }

        private static void Union(Vector2Int root1, Vector2Int root2, Dictionary<Vector2Int, Vector2Int> parentDict)
        {
            parentDict[root2] = root1;
        }

        private static Vector2Int Find(Vector2Int point, Dictionary<Vector2Int, Vector2Int> parentDict)
        {
            if (parentDict[point] != point)
            {
                parentDict[point] = Find(parentDict[point], parentDict);
            }

            return parentDict[point];
        }
    }
}