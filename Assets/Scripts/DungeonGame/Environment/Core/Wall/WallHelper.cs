using System.Collections.Generic;
using Nico.Algorithm;
using UnityEngine;

namespace DungeonGame
{
    public static class WallHelper
    {
        public static WallType GetWallType(Vector2Int wallPoint, HashSet<Vector2Int> floors)
        {

            string type = "";
            foreach (var direction in Direction2D.eightDirections)
            {
                var neighbor = wallPoint + direction;
                if (floors.Contains(neighbor))
                {
                    type += "1";
                }
                else
                {
                    type+= "0";
                }
            }
            //ToDo 这里没有做完
            return WallType.Single;
        }
        
        public static Dictionary<Vector2Int, WallType> FourDirectionWall(HashSet<Vector2Int> floorPoints)
        {
            var fourDirectionWall = PointFinder.FindEdgePoints(floorPoints, Direction2D.fourDirections);
            Dictionary<Vector2Int, WallType> types = new Dictionary<Vector2Int, WallType>();
            foreach (var wall in fourDirectionWall)
            {
                types.Add(wall, GetWallType(wall, floorPoints));
            }

            return types;
        }
    }
}