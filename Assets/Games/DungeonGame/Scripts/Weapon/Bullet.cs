using System;
using Cysharp.Threading.Tasks;
using UnityEngine;
using Random = UnityEngine.Random;

namespace Games.DungeonGame.Scripts.Weapon
{
    public class Bullet : MonoBehaviour
    {
        private Rigidbody2D rb;
        private Collider2D collider;
        public float deadTime = 5;

        private void Awake()
        {
            rb = GetComponent<Rigidbody2D>();
            collider = GetComponent<Collider2D>();
        }

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

            rb.velocity = Quaternion.AngleAxis(angel, Vector3.forward) * velocity;

            UniTask.Delay(TimeSpan.FromSeconds(deadTime)).ContinueWith(() =>
            {
                ObjectPoolManager.instance.ReturnObject("bullet", gameObject);
            }).Forget();
        }
    }
}