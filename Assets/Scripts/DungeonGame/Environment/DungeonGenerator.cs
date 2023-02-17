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
            //最小生成树获取房间中心点之间的最优连接信息
            var connectRooms = Graph.MinimumSpanningTree(rooms, Room.Distance);
            //创建房间之间的连接信息
            RoomGenerator.ConnectRooms(connectRooms);
            //最后根据房间连接信息,生成走廊
            var corridors = CorridorGenerator.GenerateCorridor(connectRooms);
            //根据房间和走廊信息 生成墙壁
            var walls = WallGenerator.GenerateWall(rooms, corridors);
            //绘制走廊
            drawer.DrawCorridors(corridors);
            //绘制房间
            drawer.DrawRooms(rooms);
            //绘制墙壁
            drawer.DrawWalls(walls);
            
        }

        [Button("Clear")]
        public void Clear()
        {
            drawer.Clear();
        }
    }
}