using System.Collections.Generic;
using System.Linq;
using Nico.Algorithm;
using Nico.Interface;
using Sirenix.OdinInspector;
using UnityEngine;

namespace DefaultNamespace
{
    public class DungeonGenerator : MonoBehaviour, IGenerator
    {
        public Vector2Int start = Vector2Int.zero;
        public int iterations = 10;
        public int walkLength = 10;
        public bool startRadnomEachIteration = true;
        public TilemapDrawer drawer;

        [Range(0, 1)] public float roomPrecent = .8f;
        [LabelText("走廊长度")] public int corridorLength = 10;
        public int corridorCount = 5;

        
        [Button("Generate")]
        public void Generate()
        {
            drawer.Clear();
            var (corridor, potentialRoomPoints) = RandomWalk.CreateCorridor(start, corridorLength, corridorCount);

            var targetRoomCenter = PointSelector.RandomSelect(potentialRoomPoints, roomPrecent);
            var roomPoints = RandomWalk.CreateRooms(targetRoomCenter, walkLength, iterations, startRadnomEachIteration);

            var endPoints = PointFinder.FindEndPoints(corridor); //找到路的终点
            var endRoomPoints =
                RandomWalk.CreateEndRooms(endPoints, roomPoints, walkLength, iterations, startRadnomEachIteration);

            HashSet<Vector2Int> floor = new HashSet<Vector2Int>();

            floor.UnionWith(corridor);
            floor.UnionWith(roomPoints);
            floor.UnionWith(endRoomPoints);

            drawer.PaintFloorTiles(floor);
            var walls = PointFinder.FindWallPoints(floor);
            drawer.PaintWallTiles(walls);
        }

        [Button("Clear")]
        public void Clear()
        {
            drawer.Clear();
        }
    }
}