using System.Collections.Generic;
using DugeonGame.Core;
using DungeonGame.Environment.Core;
using Nico.Algorithm;
using UnityEngine;

namespace DugeonGame.Generator
{
    public static class CorridorGenerator
    {
        public static List<Corridor> ConnectRooms(Dictionary<Room, Room> connectionInfo)
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