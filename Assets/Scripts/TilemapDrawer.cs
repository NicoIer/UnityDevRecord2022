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

        public void Clear()
        {
            floorTilemap.ClearAllTiles();
            wallTilemap.ClearAllTiles();
        }

        public void PaintFloorTiles(IEnumerable<Vector2Int> points)
        {
            PaintTiles(points,floorTilemap, floorTile);
        }

        public void PaintWallTiles(IEnumerable<Vector2Int> points)
        {
            PaintTiles(points,wallTilemap, wallTile);
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
    }
}