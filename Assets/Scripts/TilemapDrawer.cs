using System;
using System.Collections.Generic;
using Sirenix.OdinInspector;
using UnityEngine;
using UnityEngine.Tilemaps;

namespace DefaultNamespace
{
    public class TilemapDrawer : MonoBehaviour
    {
        public Tilemap floorTilemap;
        public Tilemap wallTilemap;
        public TileBase floorTile, wallTile;
        public TileBase wallTop, wallBottom, wallLeft, wallRight;

        public void Clear()
        {
            floorTilemap.ClearAllTiles();
            wallTilemap.ClearAllTiles();
        }

        public void PaintFloorTiles(IEnumerable<Vector2Int> points)
        {
            PaintTiles(points, floorTilemap, floorTile);
        }

        public void PaintWallTiles(IEnumerable<Vector2Int> points)
        {
            PaintTiles(points, wallTilemap, wallTile);
        }

        public static void PaintTiles(IEnumerable<Vector2Int> points, Tilemap tilemap, TileBase tileBase)
        {
            foreach (var point in points)
            {
                _paint_single_tile(tilemap, tileBase, point);
            }
        }

        private static void _paint_single_tile(Tilemap tilemap, TileBase tileBase, Vector2Int position)
        {
            var tilePosition = tilemap.WorldToCell((Vector3Int)position);
            tilemap.SetTile(tilePosition, tileBase);
        }

        public void PaintWallTiles(Dictionary<Vector2Int, WallType> walls)
        {
            foreach (var (position,type) in walls)
            {
                _paint_wall_tile(position, type);
            }
        }
        private void _paint_wall_tile(Vector2Int point, WallType wallType)
        {
            TileBase tileBase = null;
            switch (wallType)
            {
                case WallType.Single:
                    tileBase = wallTile;
                    break;
                case WallType.Top:
                    tileBase = wallTop;
                    break;
                case WallType.SideRight:
                    tileBase = wallRight;
                    break;
                case WallType.SideLeft:
                    tileBase = wallLeft;
                    break;
                case WallType.Bottom:
                    tileBase = wallBottom;
                    break;
                case WallType.Full:
                    break;
                case WallType.None:
                    break;
                default:
                    throw new ArgumentOutOfRangeException(nameof(wallType), wallType, null);
            }

            if (tileBase != null)
                _paint_single_tile(wallTilemap, tileBase, point);
        }
    }
}