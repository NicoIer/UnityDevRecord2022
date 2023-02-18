using System;
using Unity.Collections;
using Unity.Mathematics;
using Unity.Profiling;
using UnityEngine;
using UnityEngine.Jobs;

namespace EcsLearning
{
    struct WaveCubeJob : IJobParallelForTransform
    {
        [ReadOnly] public float elas;

        public void Execute(int index, TransformAccess transform)
        {
            var distance = Vector3.Distance(transform.position, Vector3.zero);
            transform.localPosition += Vector3.up * math.sin(elas * 3f + distance * 0.2f);
        }
    }

    public class WaveCubes : MonoBehaviour
    {
        private static readonly ProfilerMarker<int> _profilerMarker =
            new ProfilerMarker<int>("WaveCubesWithJobs UpdateTransform", "Objects Count");

        public GameObject cubeAchetype = null;
        [Range(10, 100)] public int xHalfCount = 40;
        [Range(10, 100)] public int zHalfCount = 40;
        private TransformAccessArray transformAccessArray;

        private void Start()
        {
            transformAccessArray = new TransformAccessArray(4 * xHalfCount * zHalfCount);

            for (int x = -xHalfCount; x < xHalfCount; x++)
            {
                for (int z = -zHalfCount; z < zHalfCount; z++)
                {
                    var cube = GameObject.Instantiate(cubeAchetype);
                    cube.transform.position = new Vector3(x * 1.1f, 0, z * 1.1f);
                    transformAccessArray.Add(cube.transform);
                }
            }
        }

        private void Update()
        {
            using (_profilerMarker.Auto(transformAccessArray.length))
            {
                var waveCubeJob = new WaveCubeJob()
                {
                    elas = Time.time
                };
                waveCubeJob.Schedule(transformAccessArray).Complete();
            }
        }

        private void OnDestroy()
        {
            transformAccessArray.Dispose();
        }
    }
}