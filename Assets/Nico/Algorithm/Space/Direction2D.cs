using System.Collections.Generic;
using UnityEngine;

namespace Nico.Algorithm
{
    public static class Direction2D
    {
        private static Vector2Int[] _directions = new Vector2Int[4]
        {
            Vector2Int.up, Vector2Int.down, Vector2Int.left, Vector2Int.right
        };

        public static Vector2Int[] directions => _directions;

        public static Vector2Int GetRadonmDirection()
        {
            var direction = Random.Range(0, 4);
            return direction switch
            {
                0 => Vector2Int.up,
                1 => Vector2Int.right,
                2 => Vector2Int.down,
                3 => Vector2Int.left,
                _ => Vector2Int.zero
            };
        }
        
    }
}