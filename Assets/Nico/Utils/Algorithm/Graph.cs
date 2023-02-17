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


        public static List<(T, T)> MinimumSpanningTree<T>(List<T> nodes, Func<T, T, float> distanceFunc)
        {
            var edges = CalEdges(nodes, distanceFunc);

            // 对边集按权值排序
            edges.Sort((a, b) => a.Item3.CompareTo(b.Item3));

            // 初始化parentDict
            Dictionary<T, T> parentDict = new Dictionary<T, T>();
            foreach (var node in nodes)
            {
                parentDict[node] = node;
            }

            // Kruskal算法构造最小生成树
            List<(T, T)> result = new List<(T, T)>();
            foreach (var edge in edges)
            {
                T root1 = Find(edge.Item1, parentDict);
                T root2 = Find(edge.Item2, parentDict);
                if (!root1.Equals(root2))
                {
                    Union(root1, root2, parentDict);
                    result.Add((edge.Item1, edge.Item2));
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