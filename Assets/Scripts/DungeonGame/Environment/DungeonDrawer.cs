using UnityEngine;
using UnityEngine.Tilemaps;

namespace DugeonGame
{
    public class DungeonDrawer: MonoBehaviour
    {
        public Tilemap floorTilemap;
        public Tilemap wallTilemap;
        public TileBase floorTile;
        public TileBase wallTile;
    }
}