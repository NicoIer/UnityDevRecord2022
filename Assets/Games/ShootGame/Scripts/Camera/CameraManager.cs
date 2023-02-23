using System;
using UnityEngine;

namespace ShootGame
{
    public class CameraManager : MonoBehaviour
    {
        public static CameraManager instance;
        public UnityEngine.Camera mainCamera;

        private void Awake()
        {
            instance = this;
            mainCamera = UnityEngine.Camera.main;
        }
    }
}