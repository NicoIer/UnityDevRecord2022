using System.Collections.Generic;
using DungeonGame.Core;
using UnityEngine;

namespace DungeonGame.Environment.Core
{
    public class Corridor
    {
        public Room roomA;
        public Room roomB;

        public HashSet<Vector2Int> path;
        
        public Corridor(Room roomA, Room roomB, HashSet<Vector2Int> path)
        {
            this.roomA = roomA;
            this.roomB = roomB;

            this.path = path;
        }
    }
}