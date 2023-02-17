using System;
using System.Collections.Generic;
using Nico.Algorithm;
using UnityEngine;

namespace DungeonGame
{
    public enum WallType
    {
        None,
        Full,

        #region 上下左右

        SideTop,
        SideBottom,
        SideRight,
        SideLeft,

        #endregion

        #region 四个角落
        TopRight,
        TopLeft,
        BottomRight,
        BottomLeft,
        #endregion
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