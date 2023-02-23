using DungeonGame.Controller;
using Nico.ECC.Template;
using Nico;
using UnityEngine;

namespace DungeonGame
{
    /// <summary>
    /// 步枪的射击速度很快
    /// </summary>
    public class RifleGun : TemplateEntityMonoBehavior<RifleGun>
    {
        public Animator ac;
        public Transform shootTransform;
        public Transform shellTransform;
        public LayerMask targetMask;
        private TemplateInput<RifleGun> input;
        private bool canShoot = true;

        protected override void _get_mono_components()
        {
            ac = GetComponent<Animator>();
        }

        protected override void _init_components()
        {
            input = new TemplateInput<RifleGun>(this);
            Add(input);
        }

        protected override void _init_controller()
        {
            var facingMouse = new FacingRightStick<RifleGun>(this);
            Add(facingMouse);
        }

        protected override void Update()
        {
            base.Update();
            if (input.rightAttack && canShoot)
            {
                // var direction = Facing.Self2MouseDirection(transform, Camera.main);
                var direction = input.rightStick;
                if (direction == Vector2.zero)
                {
                    direction = Vector2.right;
                }
                ac.SetTrigger("attack");
                //弹出弹夹

                //绘制弹道曲线
                RaycastHit2D hit = Physics2D.Raycast(shootTransform.position, direction, 100, targetMask);
                var line = ObjectPoolManager.instance.GetObject("bulletTracer").GetComponent<LineRenderer>();

                line.SetPosition(0, shootTransform.position);
                line.SetPosition(1, hit.point);
                var shell = ObjectPoolManager.instance.GetObject("shell").GetComponent<BulletShell>();
                shell.Prop(shellTransform.position, shellTransform.rotation);
            }
        }
    }
}