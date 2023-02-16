using UnityEngine;

namespace Algorithm
{
    public static class Direction2D
    {
        public static Vector2Int GetRadomDirection()
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