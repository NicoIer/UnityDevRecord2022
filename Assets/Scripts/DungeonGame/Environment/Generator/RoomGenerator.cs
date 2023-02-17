using System.Collections.Generic;
using DungeonGame.Core;
using Nico.Algorithm;
using UnityEngine;

namespace DungeonGame.Generator
{
    public static class RoomGenerator
    {
        public static Room BoundGenerate(BoundsInt bound, RoomConfig config)
        {
            //房间中心
            var center = new Vector2Int(Mathf.RoundToInt(bound.center.x), Mathf.RoundToInt(bound.center.y));
            //房间地板点
            HashSet<Vector2Int> floorPoints;
            if (config.random)
            {
                floorPoints = RandomWalk.Walk(center, config.walkLength, config.iterations, config.random);
            }
            else
            {
                floorPoints = PointCreator.CreateSquare(bound, config.offset);
            }

            var room = new Room(center, bound, floorPoints);
            return room;
        }

        public static List<Room> BoundsGenerate(List<BoundsInt> roomBounds, RoomConfig config)
        {
            List<Room> rooms = new List<Room>();
            foreach (var bound in roomBounds)
            {
                rooms.Add(BoundGenerate(bound, config));
            }

            return rooms;
        }
    }
}