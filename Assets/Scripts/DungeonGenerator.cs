using System.Collections.Generic;
using System.Linq;
using Nico.Algorithm;
using Nico.Interface;
using Sirenix.OdinInspector;
using UnityEngine;
using UnityEngine.UIElements;

namespace DefaultNamespace
{
    public class DungeonGenerator : MonoBehaviour, IGenerator
    {
        public Vector2Int start = Vector2Int.zero;
        public int iterations = 10;
        public int walkLength = 10;
        public bool startRadnomEachIteration = true;
        public TilemapDrawer drawer;

        [Range(0, 1)] public float roomProb = .8f;
        [LabelText("走廊长度")] public int corridorLength = 10;
        [LabelText("走廊生成次数")] public int corridorCount = 5;

        public int minRoomWidth = 4;
        public int minRoomHeight = 4;

        public int dungeonWidth = 20;
        public int dungeonHeight = 20;
        [Range(0, 100)] public int offset = 1;

        public bool randomWalkRooms = false;

        [Button("Generate2")]
        public void Generate2()
        {
            drawer.Clear();
            //划分空间
            var space = new BoundsInt((Vector3Int)start, new Vector3Int(dungeonWidth, dungeonHeight, 1));

            var rooms = SpaceSplit.RandomBinarySpacePartitioning(space, minRoomWidth, minRoomHeight);

            List<Vector2Int> roomCenters =
                rooms.Select(room => (Vector2Int)Vector3Int.RoundToInt(room.center)).ToList();
            HashSet<Vector2Int> corridors = PointCreator.ConnectPointsKruskal(roomCenters);
            //
            HashSet<Vector2Int> floor;
            if (randomWalkRooms)
            {
                floor = PointCreator.CreateRandomPoints(rooms, offset, walkLength, iterations,
                    startRadnomEachIteration);
            }
            else
            {
                floor = PointCreator.CreateSquarePoints(rooms, offset);
            }


            floor.UnionWith(corridors);
            drawer.PaintFloorTiles(floor);
            var walls = PointFinder.FindWallPoints(floor);
            drawer.PaintWallTiles(walls);
        }


        [Button("Generate")]
        public void Generate()
        {
            drawer.Clear();
            var (corridor, potentialRoomPoints) = RandomWalk.CreateCorridor(start, corridorLength, corridorCount);

            var targetRoomCenter = Container.RandomSelect(potentialRoomPoints, roomProb);
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