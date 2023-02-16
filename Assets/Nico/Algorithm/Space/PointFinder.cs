using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace Nico.Algorithm
{
    public static class PointFinder
    {
        public static HashSet<Vector2Int> FindEdgePoints(HashSet<Vector2Int> points)
        {
            HashSet<Vector2Int> edgePoints = new HashSet<Vector2Int>();
            var directions = Direction2D.directions;
            foreach (var point in points)
            {
                foreach (var direction in directions)
                {
                    //检测四个方向是否有点
                    if (!points.Contains(direction + point))
                    {
                        //如果有一个方向没有点，那么这个点就是边缘点
                        edgePoints.Add(point);
                        break;
                    }
                }
            }

            return edgePoints;
        }

        public static HashSet<Vector2Int> FindWallPoints(HashSet<Vector2Int> points)
        {
            HashSet<Vector2Int> wallPoints = new HashSet<Vector2Int>();
            var directions = Direction2D.directions;
            foreach (var point in points)
            {
                foreach (var direction in directions)
                {
                    //检测四个方向是否有点
                    if (!points.Contains(direction + point))
                    {
                        wallPoints.Add(direction + point);
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
                foreach (var direction in Direction2D.directions)
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
    }
}