using System;
using System.Threading;
using Cysharp.Threading.Tasks;
using Nico;
using UnityEngine;
using Random = UnityEngine.Random;

namespace DungeonGame
{
    public class Bullet : MonoBehaviour
    {
        private Rigidbody2D rb;
        public float deadTime = 5;
        public float speed = 5;

        private void Awake()
        {
            rb = GetComponent<Rigidbody2D>();
            GetComponent<Collider2D>();
        }

        private CancellationTokenSource cancellationTokenSource;

        /// <summary>
        /// 子弹被射出时的行为
        /// </summary>
        /// <param name="velocity"></param>
        /// <param name="positon"></param>
        public void Shoot(Vector2 velocity, Vector3 positon)
        {
            transform.position = positon;
            Vector2 direction = velocity.normalized;
            transform.right = direction;
            //设置刚体速度
            var angel = Random.Range(-5, 5);

            rb.velocity = Quaternion.AngleAxis(angel, Vector3.forward) * velocity * speed;
            cancellationTokenSource = new CancellationTokenSource();
            UniTask.Delay(TimeSpan.FromSeconds(deadTime), cancellationToken: cancellationTokenSource.Token)
                .ContinueWith(() => { ObjectPoolManager.instance.ReturnObject("bullet", gameObject); }).Forget();
        }

        private void OnTriggerEnter2D(Collider2D col)
        {
            if (col.CompareTag("Bullet"))
            {
                return;
            }

            if (cancellationTokenSource != null)
                cancellationTokenSource.Cancel();
            var effect = ObjectPoolManager.instance.GetObject("effect");
            var transform1 = transform;
            effect.transform.position = transform1.position;
            effect.transform.rotation = transform1.rotation;
            ObjectPoolManager.instance.ReturnObject("bullet", gameObject);
        }
    }
}