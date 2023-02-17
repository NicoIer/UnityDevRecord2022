using System.Collections.Generic;
using Nico.Algorithm;
using UnityEngine;

namespace DefaultNamespace
{
    public static class WallFinder
    {
        public static Dictionary<Vector2Int, WallType> FourDirectionWall(HashSet<Vector2Int> floorPoints)
        {
            var fourDirectionWall = PointFinder.FindEdgePoints(floorPoints, Direction2D.fourDirections);
            Dictionary<Vector2Int, WallType> types = new Dictionary<Vector2Int, WallType>();
            foreach (var wall in fourDirectionWall)
            {
                types.Add(wall, WallByteType.GetWallType(wall, floorPoints));
            }

            return types;
        }
    }
}