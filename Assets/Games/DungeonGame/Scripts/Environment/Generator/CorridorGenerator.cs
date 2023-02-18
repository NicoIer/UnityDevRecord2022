using System.Collections.Generic;
using DungeonGame.Core;
using DungeonGame.Environment.Core;
using Nico.Algorithm;

namespace DungeonGame.Generator
{
    public static class CorridorGenerator
    {
        public static List<Corridor> GenerateCorridor(List<(Room, Room)> connectionInfo)
        {
            List<Corridor> corridors = new List<Corridor>();

            foreach (var (ra, rb)in connectionInfo)
            {
                var (start, end) = (ra.center, rb.center);
                var path = PointCreator.CreateCorridor(start, end);
                var corridor = new Corridor(ra, rb, path);
                corridors.Add(corridor);
            }

            return corridors;
        }
    }
}