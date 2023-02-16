using System.Collections.Generic;
using Sirenix.OdinInspector;
using UnityEngine;
using UnityEngine.Tilemaps;

namespace DefaultNamespace
{
    public class TilemapDrawer: MonoBehaviour
    {

        public Tilemap tilemap;
        public TileBase floorTile;

        public void Clear()
        {
            tilemap.ClearAllTiles();
        }
        
        public void PaintFloorTiles(IEnumerable<Vector2Int> points)
        {
            foreach (var point in points)
            {
                _paint_single_tile(tilemap,floorTile,point);
            }
        }

        private static void _paint_single_tile(Tilemap tilemap,TileBase tileBase,Vector2Int position)
        {
            var tilePosition = tilemap.WorldToCell((Vector3Int)position);
            tilemap.SetTile(tilePosition,tileBase);
        }
    }
}























