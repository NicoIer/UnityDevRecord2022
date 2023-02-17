using System.Collections.Generic;
using DungeonGame.Core;
using DungeonGame.Environment.Core;
using UnityEngine;
using UnityEngine.Tilemaps;

namespace DungeonGame
{
    public class DungeonDrawer : MonoBehaviour
    {
        public Tilemap floorTilemap;
        public Tilemap wallTilemap;
        public TileBase floorTile;
        public TileBase corridorTile;
        public TileBase wallTile;

        public void Clear()
        {
            floorTilemap.ClearAllTiles();
            wallTilemap.ClearAllTiles();
        }

        public void DrawRooms(IEnumerable<Room> rooms)
        {
            foreach (var room in rooms)
            {
                DrawRoom(room);
            }
        }
        public void DrawRoom(Room room)
        {
            foreach (var point in room.floorPoints)
            {
                _paint_single_tile(floorTilemap, floorTile, point);
            }
        }

        public void DrawCorridors(IEnumerable<Corridor> corridors)
        {
            foreach (var corridor in corridors)
            {
                DrawCorridor(corridor);
            }
        }
        public void DrawCorridor(Corridor corridor)
        {
            foreach (var point in corridor.path)
            {
                _paint_single_tile(floorTilemap, corridorTile, point);
            }
        }


        private static void _paint_single_tile(Tilemap tilemap, TileBase tileBase, Vector2Int position)
        {
            var tilePosition = tilemap.WorldToCell((Vector3Int)position);
            tilemap.SetTile(tilePosition, tileBase);
        }
    }
}