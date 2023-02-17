using System;
using System.Collections.Generic;
using System.Linq;
using DungeonGame.Core;
using DungeonGame.Generator;
using Nico.Algorithm;
using Nico.Interface;
using Sirenix.OdinInspector;
using UnityEngine;
using UnityEngine.UIElements;
using Random = UnityEngine.Random;

namespace DungeonGame
{
    public class DungeonGenerator : MonoBehaviour
    {
        public Vector2Int start = Vector2Int.zero;
        public DungeonDrawer drawer;

        public int minRoomWidth = 4;
        public int minRoomHeight = 4;

        public int dungeonWidth = 20;
        public int dungeonHeight = 20;
        public RoomConfig config;

        [Button("Generate3")]
        public void Generate3()
        {
            drawer.Clear();
            //首先对空间划分区域 随机选取其中几个生成房间
            var space = new BoundsInt((Vector3Int)start, new Vector3Int(dungeonWidth, dungeonHeight, 1));
            var roomBounds = SpaceSplit.RandomBinarySpacePartitioning(space, minRoomWidth, minRoomHeight);
            //生成房间
            var rooms = RoomGenerator.BoundsGenerate(roomBounds, config);
            print(rooms.Count);
            //生成中心点->房间索引
            var roomCenters = rooms.Select(_ => _.center).ToList();
            //然后使用最小生成树获取房间中心点之间的最优连接信息
            var centerConnectInfos = Graph.MinimumSpanningTree(roomCenters);
            print(centerConnectInfos.Count);
            //通过房间中心点->房间索引,获取房间连接信息
            List<(Room, Room)> roomConnectionInfo = new List<(Room, Room)>();
            foreach (var (c1, c2) in centerConnectInfos)
            {
                var r1 = rooms.Find(_ => _.center == c1);
                var r2 = rooms.Find(_ => _.center == c2);
                roomConnectionInfo.Add((r1, r2));
            }

            print(roomConnectionInfo.Count);
            //最后根据房间连接信息,生成走廊
            var corridors = CorridorGenerator.GenerateCorridor(roomConnectionInfo);
            print(corridors.Count);
            //绘制房间
            foreach (var room in rooms)
            {
                drawer.DrawRoom(room);
            }

            //绘制走廊
            foreach (var corridor in corridors)
            {
                drawer.DrawCorridor(corridor);
            }
        }

        [Button("Clear")]
        public void Clear()
        {
            drawer.Clear();
        }
    }
}