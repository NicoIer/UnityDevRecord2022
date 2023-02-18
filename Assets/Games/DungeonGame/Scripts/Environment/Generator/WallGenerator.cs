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
                WallType wallType = WallType.None;
                //ToDo 此处判断wall的类型
                var right = point + Vector2Int.right;
                var left = point + Vector2Int.left;
                var up = point + Vector2Int.up;
                var down = point + Vector2Int.down;
                var upRight = point + new Vector2Int(1, 1);
                var upLeft = point + Direction2D.upLeft;
                var downRight = point + Direction2D.downRight;
                var downLeft = point + Direction2D.downLeft;

                var ir = floorPoints.Contains(right);
                var il = floorPoints.Contains(left);
                var iu = floorPoints.Contains(up);
                var id = floorPoints.Contains(down);
                var iur = floorPoints.Contains(upRight);
                var iul = floorPoints.Contains(upLeft);
                var idr = floorPoints.Contains(downRight);
                var idl = floorPoints.Contains(downLeft);
                if (!ir && !il && !iu && !id && !iur && !iul && !idr && !idl)
                {
                    wallType = WallType.None;
                }
                else if (ir && !il && !iu && !id && !iur && !iul && !idr && !idl)
                {
                    wallType = WallType.SideLeft;
                }
                else if (!ir && il && !iu && !id && !iur && !iul && !idr && !idl)
                {
                    wallType = WallType.SideRight;
                }
//ToDo 完成其他的判断

                walls.Add(new Wall(wallType, point));
            }

            return walls;
        }
    }
}