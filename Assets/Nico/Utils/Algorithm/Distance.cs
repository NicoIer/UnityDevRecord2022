using Nico.Interface;
using UnityEngine;

namespace Nico.Algorithm
{
    public static class Distance
    {
        //计算两个点的曼哈顿距离
        public static int Manhattan(Vector2Int a, Vector2Int b)
        {
            return Mathf.Abs(a.x - b.x) + Mathf.Abs(a.y - b.y);
        }

        public static float Cal(IDistance a, IDistance b)
        {
            return a.Distance(b);
        }
    }
}