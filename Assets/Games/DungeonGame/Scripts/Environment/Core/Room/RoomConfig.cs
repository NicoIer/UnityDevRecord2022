using System;

namespace DungeonGame.Core
{
    [Serializable]
    public class RoomConfig
    {
        public int offset;
        public int walkLength;
        public int iterations;
        public bool random = false;
    }
}