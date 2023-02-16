using System.Collections.Generic;
using UnityEngine;

namespace Nico.Algorithm
{
    public static class PointCreator
    {
        public static HashSet<Vector2Int> CreateSquarePoints(List<BoundsInt> spaces, int offset)
        {
            HashSet<Vector2Int> points = new HashSet<Vector2Int>();
            foreach (var space in spaces)
            {
                for (int x = offset; x < space.size.x - offset; x++)
                {
                    for (int y = offset; y < space.size.y - offset; y++)
                    {
                        Vector2Int point = (Vector2Int)space.min + new Vector2Int(x, y);
                        points.Add(point);
                    }
                }
            }

            return points;
        }

        public static HashSet<Vector2Int> CreateCorridor(Vector2Int start, Vector2Int end)
        {
            HashSet<Vector2Int> corridor = new HashSet<Vector2Int>();
            var position = start;
            corridor.Add(position);

            while (position.y != end.y)
            {
                if (end.y > position.y)
                {
                    position += Vector2Int.up;
                }
                else if (end.y < position.y)
                {
                    position += Vector2Int.down;
                }

                corridor.Add(position);
            }

            while (position.x != end.x)
            {
                if (end.x > position.x)
                {
                    position += Vector2Int.right;
                }
                else if (end.x < position.x)
                {
                    position += Vector2Int.left;
                }

                corridor.Add(position);
            }

            return corridor;
        }

        public static HashSet<Vector2Int> ConnectPointsKruskal(List<Vector2Int> points)
        {
            // 创建一个数组来保存边信息
            List<(Vector2Int, Vector2Int, float)> edges = new List<(Vector2Int, Vector2Int, float)>();
            for (int i = 0; i < points.Count; i++)
            {
                for (int j = i + 1; j < points.Count; j++)
                {
                    float distance = Vector2Int.Distance(points[i], points[j]);
                    edges.Add((points[i], points[j], distance));
                }
            }

            // 对边按照距离从小到大排序
            edges.Sort((a, b) => a.Item3.CompareTo(b.Item3));

            // 使用并查集来判断两个点是否已经连通
            Dictionary<Vector2Int, Vector2Int> parentDict = new Dictionary<Vector2Int, Vector2Int>();
            foreach (var point in points)
            {
                parentDict[point] = point;
            }

            Vector2Int Find(Vector2Int point)
            {
                if (parentDict[point] != point)
                {
                    parentDict[point] = Find(parentDict[point]);
                }

                return parentDict[point];
            }

            bool Union(Vector2Int a, Vector2Int b)
            {
                Vector2Int parentA = Find(a);
                Vector2Int parentB = Find(b);
                if (parentA == parentB)
                {
                    return false;
                }

                parentDict[parentA] = parentB;
                return true;
            }

            // 依次选择每条边，如果两个点未连通则将它们连通
            HashSet<Vector2Int> connectedPoints = new HashSet<Vector2Int>();
            foreach (var edge in edges)
            {
                if (Union(edge.Item1, edge.Item2))
                {
                    connectedPoints.Add(edge.Item1);
                    connectedPoints.Add(edge.Item2);
                    connectedPoints.UnionWith(CreateCorridor(edge.Item1, edge.Item2));
                }
            }

            return connectedPoints;
        }

        public static HashSet<Vector2Int> ConnectPoints(List<Vector2Int> points)
        {
            HashSet<Vector2Int> corridors = new HashSet<Vector2Int>();
            var randomIdx = Random.Range(0, points.Count);
            var startPoint = points[randomIdx];
            points.Remove(startPoint);
            while (points.Count > 0)
            {
                Vector2Int closest = PointFinder.FindClosestPoint(startPoint, points);
                points.Remove(closest);
                HashSet<Vector2Int> corridor = PointCreator.CreateCorridor(startPoint, closest);
                corridors.UnionWith(corridor);
            }

            return corridors;
        }

        public static HashSet<Vector2Int> CreateRandomPoints(List<BoundsInt> rooms, int offset, int walkLength,
            int iterations, bool startForEachIteration)
        {
            HashSet<Vector2Int> points = new HashSet<Vector2Int>();
            foreach (var room in rooms)
            {
                var center = new Vector2Int(Mathf.RoundToInt(room.center.x), Mathf.RoundToInt(room.center.y));
                var roomFloor = RandomWalk.Walk(center, walkLength, iterations, startForEachIteration);

                foreach (var point in roomFloor)
                {
                    if (point.x >= room.xMin + offset && point.x <= room.xMax - offset &&
                        point.y >= room.yMin + offset && point.y <= room.yMax - offset)
                    {
                        points.Add(point);
                    }
                }
            }

            return points;
        }
    }
}