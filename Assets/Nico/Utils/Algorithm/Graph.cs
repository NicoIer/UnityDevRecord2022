using System;
using System.Collections;
using System.Collections.Generic;
using Nico.Interface;
using UnityEngine;

namespace Nico.Algorithm
{
    public static class Graph
    {
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


        public static List<(Vector2Int, Vector2Int)> MinimumSpanningTree(List<Vector2Int> nodes)
        {
            var edges = CalEdges(nodes, Distance.Manhattan);

            // 对边集按权值排序
            edges.Sort((a, b) => a.Item3.CompareTo(b.Item3));

            // 初始化parentDict
            Dictionary<Vector2Int, Vector2Int> parentDict = new Dictionary<Vector2Int, Vector2Int>();
            foreach (var node in nodes)
            {
                parentDict[node] = node;
            }

            // Kruskal算法构造最小生成树
            List<(Vector2Int, Vector2Int)> result = new List<(Vector2Int, Vector2Int)>();
            foreach (var edge in edges)
            {
                Vector2Int root1 = Find(edge.Item1, parentDict);
                Vector2Int root2 = Find(edge.Item2, parentDict);
                if (!root1.Equals(root2))
                {
                    Union(root1, root2, parentDict);
                    result.Add((edge.Item1, edge.Item2));
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
            if (!parentDict[point].Equals(point))
            {
                parentDict[point] = Find(parentDict[point], parentDict);
            }

            return parentDict[point];
        }
    }
}