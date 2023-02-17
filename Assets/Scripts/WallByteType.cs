using System;
using System.Collections.Generic;
using Nico.Algorithm;
using UnityEngine;

namespace DefaultNamespace
{
    public enum WallType
    {
        Top,
        SideRight,
        SideLeft,
        Bottom,
        Full,
        Single,
        None,
    }

    public static class WallByteType
    {
        public static WallType GetWallType(Vector2Int wallPoint, HashSet<Vector2Int> floors)
        {

            string type = "";
            foreach (var direction in Direction2D.eightDirections)
            {
                var neighbor = wallPoint + direction;
                if (floors.Contains(neighbor))
                {
                    type += "1";
                }
                else
                {
                    type+= "0";
                }
            }
            //ToDo 这里没有做完
            return WallType.Single;
        }
    }
}