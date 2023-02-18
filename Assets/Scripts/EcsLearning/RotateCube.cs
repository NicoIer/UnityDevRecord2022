using System;
using UnityEngine;

namespace EcsLearning
{
    public class RotateCube : MonoBehaviour
    {
        [Range(0, 360)] public float rotateSpeed = 360f;
        private void Update()
        {
            transform.Rotate(new Vector3(0,rotateSpeed * Time.deltaTime, 0));
        }
    }
}