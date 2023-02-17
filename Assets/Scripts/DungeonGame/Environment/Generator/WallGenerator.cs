using System.Collections.Generic;
using System.Linq;
using DungeonGame.Core;
using DungeonGame.Environment.Core;
using Nico.Algorithm;
using UnityEngine;

namespace DungeonGame.Generator
{
    public class WallGenerator
    {
        public static List<Wall> GenerateWall(List<Room> rooms, List<Corridor> corridors)
        {
            var floorPoints = new HashSet<Vector2Int>();
            foreach (var room in rooms)
            {
                floorPoints.UnionWith(room.floorPoints);
            }

            foreach (var corridor in corridors)
            {
                floorPoints.UnionWith(corridor.path);
            }

            var walls = new List<Wall>();
            var surroundPoints = PointFinder.FindEdgePoints(floorPoints, Direction2D.eightDirections);

            foreach (var point in surroundPoints)
            {
                WallType wallType = WallType.Single;
                //ToDo 此处判断wall的类型
                
                walls.Add(new Wall(wallType, point));
            }

            return walls;
        }
    }
}