using System.Collections.Generic;
using UnityEngine;

namespace DugeonGame.Core
{
    public enum RoomType
    {
        
    }
    public class Room
    {
        public RoomType roomType;
        public Vector2Int center;
        public BoundsInt bounds;
        public HashSet<Room> neighbors = new HashSet<Room>();
        public List<Wall> walls = new List<Wall>();
        public List<Floor> floors = new List<Floor>();
    }
}