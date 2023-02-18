using System;
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
        public TileBase fullWallTile;

        #region 四个方向

        public TileBase topWallTile;
        public TileBase bottomWallTile;
        public TileBase sideRightWallTile;
        public TileBase sideLeftWallTile;

        #endregion

        #region 四个角角

        public TileBase topLeftWallTile;
        public TileBase topRightWallTile;
        public TileBase bottomLeftWallTile;
        public TileBase bottomRightWallTile;

        #endregion


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

        public void DrawWalls(List<Wall> walls)
        {
            foreach (Wall wall in walls)
            {
                TileBase tile = null;
                switch (wall.type)
                {
                    case WallType.SideRight:
                        tile = sideRightWallTile;
                        break;
                    case WallType.SideLeft:
                        tile = sideLeftWallTile;
                        break;
                    case WallType.Full:
                        tile = fullWallTile;
                        break;
                    case WallType.SideTop:
                        tile = topWallTile;
                        break;
                    case WallType.SideBottom:
                        tile = bottomWallTile;
                        break;
                    case WallType.TopRight:
                        tile = topRightWallTile;
                        break;
                    case WallType.TopLeft:
                        tile = topLeftWallTile;
                        break;
                    case WallType.BottomRight:
                        tile = bottomRightWallTile;
                        break;
                    case WallType.BottomLeft:
                        tile = bottomLeftWallTile;
                        break;
                    case WallType.None:
                        break;
                }

                if (tile != null)
                {
                    _paint_single_tile(wallTilemap, tile, wall.position);
                }
                else
                {
                    _paint_single_tile(wallTilemap, fullWallTile, wall.position);
                }
            }
        }

        private static void _paint_single_tile(Tilemap tilemap, TileBase tileBase, Vector2Int position)
        {
            var tilePosition = tilemap.WorldToCell((Vector3Int)position);
            tilemap.SetTile(tilePosition, tileBase);
        }
    }
}