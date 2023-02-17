using System;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

namespace Nico.Algorithm
{
    public static class PointCreator
    {
        public static HashSet<Vector2Int> CreateSquare(BoundsInt bound, int offset)
        {
            HashSet<Vector2Int> points = new HashSet<Vector2Int>();
            for (int x = offset; x < bound.size.x - offset; x++)
            {
                for (int y = offset; y < bound.size.y - offset; y++)
                {
                    Vector2Int point = (Vector2Int)bound.min + new Vector2Int(x, y);
                    points.Add(point);
                }
            }

            return points;
        }
        

        public static HashSet<Vector2Int> CreateSquarePoints(List<BoundsInt> spaces, int offset)
        {
            HashSet<Vector2Int> points = new HashSet<Vector2Int>();
            foreach (var space in spaces)
            {
                points.UnionWith(CreateSquare(space, offset));
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
    }
}