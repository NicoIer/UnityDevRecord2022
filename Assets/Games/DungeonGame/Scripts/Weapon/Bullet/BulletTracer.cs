using System;
using Cysharp.Threading.Tasks;
using DungeonGame.Scripts;
using UnityEngine;

namespace DungeonGame
{
    public class BulletTracer: MonoBehaviour
    {
        public float fadeSpeed;
        private LineRenderer lineRenderer;
        private float alpha;

        private void Awake()
        {
            lineRenderer = GetComponent<LineRenderer>();
            alpha =  lineRenderer.endColor.a;
        }

        private void OnEnable()
        {
            var endColor = lineRenderer.endColor;
            endColor = new Color(endColor.r, endColor.g, endColor.b, alpha);
            lineRenderer.endColor = endColor;
            Fade().Forget();
        }

        private async UniTask Fade()
        {
            while (lineRenderer.endColor.a>0)
            {
                var endColor = lineRenderer.endColor;
                endColor = new Color(endColor.r, endColor.g, endColor.b, endColor.a - fadeSpeed);
                lineRenderer.endColor = endColor;
                await UniTask.WaitForFixedUpdate();
            }
            ObjectPoolManager.instance.ReturnObject("bulletTracer",gameObject);
        }
    }
}