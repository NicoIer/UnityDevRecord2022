using System.Collections.Generic;
using UnityEngine;

namespace Nico.Algorithm
{
    public static class SpaceSplit
    {
        public static List<BoundsInt> BinarySpacePartitioning(BoundsInt space, int minWidth, int minHeight)
        {
            Queue<BoundsInt> roomsQueue = new Queue<BoundsInt>();
            List<BoundsInt> rooms = new List<BoundsInt>();
            roomsQueue.Enqueue(space);

            while (roomsQueue.Count > 0)
            {
                var room = roomsQueue.Dequeue();
                if (room.size.x < minWidth || room.size.y < minHeight)
                {
                    rooms.Add(room);
                    continue;
                }

                var split = Random.Range(0, 2);//随机选择一个方向进行分割
                if (split == 0)
                {
                    var (left, right) = _vertically_split(room, minWidth);
                    roomsQueue.Enqueue(left);
                    roomsQueue.Enqueue(right);
                }
                else
                {
                    var (top, bottom) = _horizontally_split(room, minHeight);   
                    roomsQueue.Enqueue(top);
                    roomsQueue.Enqueue(bottom);
                }
            }

            return rooms;
        }

        private static (BoundsInt, BoundsInt) _vertically_split(BoundsInt space, int minWidth)
        {
            var xSplitPoint = Random.Range(space.xMin + minWidth, space.xMax - minWidth); //X方向上随机取点
            var left = new BoundsInt(space.xMin, space.yMin, space.zMin, xSplitPoint - space.xMin, space.size.y, space.size.z);
            var right = new BoundsInt(xSplitPoint, space.yMin, space.zMin, space.xMax - xSplitPoint, space.size.y, space.size.z);
            return (left, right);
        }

        private static (BoundsInt, BoundsInt) _horizontally_split(BoundsInt space, int minHeight)
        {
            var ySplitPoint = Random.Range(space.yMin + minHeight, space.yMax - minHeight);
            var top = new BoundsInt(space.xMin, space.yMin, space.zMin, space.size.x, ySplitPoint - space.yMin, space.size.z);
            var bottom = new BoundsInt(space.xMin, ySplitPoint, space.zMin, space.size.x, space.yMax - ySplitPoint, space.size.z);
            return (top, bottom);
        }
    }
}