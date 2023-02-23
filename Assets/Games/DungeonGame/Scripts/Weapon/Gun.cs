using System;
using Cysharp.Threading.Tasks;
using Nico.ECC.Template;
using UnityEngine;

namespace Games.DungeonGame.Scripts.Weapon
{
    public class Gun : MonoBehaviour
    {
        public Transform shootTransform;

        public Transform shellTransform;

        //粒子效果
        public GameObject shellPrefab;
        private TemplateInput<Gun> input;
        private Animator ac;
        public float bulletSpeed = 10;
        private bool canShoot = true;
        public float attackInterval = 1;

        private void Awake()
        {
            ac = GetComponent<Animator>();
        }

        private void OnEnable()
        {
            input = new TemplateInput<Gun>(this);
            input.OnEnable();
        }

        private void Update()
        {
            var direction = _get_self2mouse_direction();
            _facing_(direction);

            if (input.rightAttack && canShoot)
            {
                _start_cool_down(); //开始冷却
                ac.SetTrigger("attack"); //播放攻击动画
                //发射子弹
                _shoot_bullet(direction * bulletSpeed, transform.position + shootTransform.position);
                //展示粒子效果
                Instantiate(shellPrefab, shellTransform.position, shellTransform.rotation);
            }
        }

        #region 组件函数 将来会被分离

        private void _facing_(Vector2 direction)
        {
            if (direction.x < 0)
            {
                transform.localScale = new Vector3(1, -1, 1);
            }
            else if (direction.x > 0)
            {
                transform.localScale = new Vector3(1, 1, 1);
            }

            transform.right = direction;
        }

        private Vector2 _get_self2mouse_direction()
        {
            var mousePosition = Camera.main.ScreenToWorldPoint(input.mousePostion);

            var direction = mousePosition - transform.position;
            direction.z = 0;
            direction = direction.normalized;
            return direction;
        }

        private void _shoot_bullet(Vector2 velocity, Vector3 positon)
        {
            var bullet = ObjectPoolManager.instance.GetObject("bullet").GetComponent<Bullet>();
            bullet.Shoot(velocity, positon);
        }

        private void _start_cool_down()
        {
            canShoot = false;
            UniTask.Delay(TimeSpan.FromSeconds(attackInterval)).ContinueWith(() => { canShoot = true; }).Forget();
        }

        #endregion


        private void OnDrawGizmos()
        {
            Gizmos.color = Color.red;
            var postion = transform.position;
            Gizmos.DrawWireSphere(postion + shootTransform.position, 0.1f);
            Gizmos.DrawWireSphere(postion + shellTransform.position, 0.1f);
        }
    }
}