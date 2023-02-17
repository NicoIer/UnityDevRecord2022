using System.Collections.Generic;
using UnityEngine;

namespace Nico.Algorithm
{
    public static class Direction2D
    {
        public static readonly Vector2Int[] fourDirections =
        {
            Vector2Int.up, Vector2Int.down, Vector2Int.left, Vector2Int.right
        };


        public static Vector2Int GetRandomDirection()
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


        public static readonly Vector2Int[] diagonalDirections =
        {
            new Vector2Int(1, 1), //right up
            new Vector2Int(1, -1), //right down
            new Vector2Int(-1, -1), //left down
            new Vector2Int(-1, 1), //left up
        };

        public static readonly Vector2Int[] eightDirections =
        {
            Vector2Int.up,
            Vector2Int.down,
            Vector2Int.left,
            Vector2Int.right,
            new Vector2Int(-1, 1), //left up
            new Vector2Int(1, 1), //right up
            new Vector2Int(-1, -1), //left down
            new Vector2Int(1, -1), //right down
            
        };
    }
}