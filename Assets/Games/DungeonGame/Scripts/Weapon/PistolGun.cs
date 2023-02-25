using System;
using Cysharp.Threading.Tasks;
using DungeonGame.Controller;
using Nico.ECC.Template;
using Nico;
using UnityEngine;

namespace DungeonGame
{
    public class PistolGun : TemplateEntityMonoBehavior<PistolGun>
    {
        public Transform shootTransform;
        public Transform shellTransform;
        //粒子效果
        private TemplateInput<PistolGun> input;
        private Animator ac;
        private bool canShoot = true;
        public WeaponData data;

        protected override void _get_mono_components()
        {
            ac = GetComponent<Animator>();
        }

        protected override void _init_components()
        {
            input = new TemplateInput<PistolGun>(this);
            Add(input);
        }

        protected override void _init_controller()
        {
            var facingMouse = new FacingRightStick<PistolGun>(this);
            Add(facingMouse);
        }
        

        protected override void Update()
        {
            base.Update();
            if (input.rightAttack && canShoot)
            {
                var direction = input.rightStick.normalized;
                if (direction == Vector2.zero)
                {
                    direction = Vector2.right;
                }
                _start_cool_down(); //开始冷却
                ac.SetTrigger("attack"); //播放攻击动画
                //发射子弹
                _shoot_bullet(direction * data.bulletSpeed, shootTransform.position);
                //展示弹壳
                var shell = ObjectPoolManager.instance.GetObject("shell").GetComponent<BulletShell>();
                shell.Prop(shellTransform.position, shellTransform.rotation);
            }
        }

        #region 组件函数 将来会被分离
        

        private void _shoot_bullet(Vector2 velocity, Vector3 positon)
        {
            var bullet = ObjectPoolManager.instance.GetObject("bullet").GetComponent<Bullet>();
            bullet.Shoot(velocity, positon);
        }

        private void _start_cool_down()
        {
            canShoot = false;
            UniTask.Delay(TimeSpan.FromSeconds(data.attackInterval)).ContinueWith(() => { canShoot = true; }).Forget();
        }

        #endregion


        private void OnDrawGizmos()
        {
            Gizmos.color = Color.red;
            Gizmos.DrawWireSphere(shootTransform.position, 0.1f);
            Gizmos.DrawWireSphere(shellTransform.position, 0.1f);
        }
    }
}