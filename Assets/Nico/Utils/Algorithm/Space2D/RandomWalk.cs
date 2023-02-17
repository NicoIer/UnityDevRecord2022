using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;


namespace Nico.Algorithm
{
    public static class RandomWalk
    {
        public static HashSet<Vector2Int> Walk(Vector2Int startPoint, int length, int iteration,
            bool startRandomlyEachIteration)
        {
            HashSet<Vector2Int> path = new HashSet<Vector2Int>();
            var currentPoint = startPoint;
            for (int i = 0; i < iteration; i++)
            {
                path.UnionWith(_random_walk(currentPoint, length));
                if (startRandomlyEachIteration)
                {
                    currentPoint = path.ElementAt(Random.Range(0, path.Count));
                }
            }

            return path;
        }

        private static HashSet<Vector2Int> _random_walk(Vector2Int startPoint, int length)
        {
            HashSet<Vector2Int> path = new HashSet<Vector2Int>();
            var previousPoint = startPoint;
            for (int i = 0; i < length; i++)
            {
                var next = previousPoint + Direction2D.GetRandomDirection();
                path.Add(next);
                previousPoint = next;
            }

            return path;
        }

        /// <summary>
        /// 创建走廊 并且 获取所有可能的房间点
        /// </summary>
        /// <param name="startPosition"></param>
        /// <param name="corridorLength"></param>
        /// <param name="corridorCount"></param>
        /// <returns></returns>
        public static (HashSet<Vector2Int>, HashSet<Vector2Int>) CreateCorridor(Vector2Int startPosition,
            int corridorLength,
            int corridorCount)
        {
            HashSet<Vector2Int> potentialRoomPoints = new HashSet<Vector2Int>();
            HashSet<Vector2Int> corridor = new HashSet<Vector2Int>();
            var currentPosition = startPosition;
            for (int i = 0; i < corridorCount; i++)
            {
                var path = _walk_corridor(currentPosition, corridorLength);
                currentPosition = path[path.Count - 1];

                potentialRoomPoints.Add(currentPosition);

                corridor.UnionWith(path);
            }

            return (corridor, potentialRoomPoints);
        }

        private static List<Vector2Int> _walk_corridor(Vector2Int startPosition, int corridorLength)
        {
            List<Vector2Int> corridor = new List<Vector2Int>() { startPosition };
            var direction = Direction2D.GetRandomDirection();
            var currentPoint = startPosition;
            for (int i = 0; i < corridorLength; i++)
            {
                currentPoint += direction;
                corridor.Add(currentPoint);
            }

            return corridor;
        }


        public static HashSet<Vector2Int> CreateRooms(IEnumerable<Vector2Int> roomPoints, int walkLength, int iteration,
            bool startRandomlyEachIteration)
        {
            HashSet<Vector2Int> rooms = new HashSet<Vector2Int>();
            foreach (var roomPoint in roomPoints)
            {
                rooms.UnionWith(Walk(roomPoint, walkLength, iteration, startRandomlyEachIteration));
            }

            return rooms;
        }

        public static HashSet<Vector2Int> CreateEndRooms(IEnumerable<Vector2Int> endPoints,
            HashSet<Vector2Int> roomFloors, int walkLength, int iteration,
            bool startRandomlyEachIteration)
        {
            HashSet<Vector2Int> rooms = new HashSet<Vector2Int>();
            foreach (var endPoint in endPoints)
            {
                if (!roomFloors.Contains(endPoint))
                {
                    var endRoom = Walk(endPoint, walkLength, iteration, startRandomlyEachIteration);
                    rooms.UnionWith(endRoom);
                }
            }

            return rooms;
        }
    }
}