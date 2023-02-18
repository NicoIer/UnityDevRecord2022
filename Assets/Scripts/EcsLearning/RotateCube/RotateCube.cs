using System;
using Unity.Entities;
using Unity.Mathematics;
using UnityEngine;

namespace EcsLearning
{
    struct RotateSpeed: IComponentData
    {
        public float speed;
    }
    public class RotateCube : MonoBehaviour
    {
        public float speed = 360f;
        public class Baker: Baker<RotateCube>
        {
            public override void Bake(RotateCube authoring)
            {
                var data = new RotateSpeed
                {
                    speed = math.radians(authoring.speed)
                };
                AddComponent(data);
            }
        }

    }
}