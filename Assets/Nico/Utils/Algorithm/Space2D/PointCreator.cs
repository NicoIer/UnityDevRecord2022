using System;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

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
            var connectionInfo = Graph.Kruskal(points);

            // 依次选择每条边，如果两个点未连通则将它们连通
            HashSet<Vector2Int> connectedPoints = new HashSet<Vector2Int>();
            foreach (var (a, b) in connectionInfo)
            {
                connectedPoints.UnionWith(CreateCorridor(a, b));
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