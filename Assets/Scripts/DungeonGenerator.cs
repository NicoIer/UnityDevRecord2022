using System.Collections.Generic;
using System.Linq;
using Sirenix.OdinInspector;
using UnityEngine;

namespace DefaultNamespace
{
    public class DungeonGenerator : MonoBehaviour
    {
        public Vector2Int startPostion = Vector2Int.zero;
        public int iteraions = 10;
        public int walkLength = 10;
        public bool startRadomLyEachIteration = true;
        public TilemapDrawer drawer;

        [Button("Generate")]
        public void Generate()
        {
            drawer.Clear();
            var points = Algorithm.RandomWalk.Walk(startPostion, walkLength, iteraions, startRadomLyEachIteration);
            drawer.PaintFloorTiles(points);
        }
        [Button("Clear")]
        
        public void Clear()
        {
            drawer.Clear();
        }
        
    }
}