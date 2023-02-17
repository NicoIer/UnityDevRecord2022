using System;
using System.Collections.Generic;
using Nico.Algorithm;
using UnityEngine;

namespace DungeonGame
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

    public class Wall
    {
        public WallType type;
        public Vector2Int position;
        
        public Wall(WallType type, Vector2Int position)
        {
            this.type = type;
            this.position = position;
        }
    }

}