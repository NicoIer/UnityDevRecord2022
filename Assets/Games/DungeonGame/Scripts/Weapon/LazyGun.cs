using Cysharp.Threading.Tasks;
using Nico.ECC.Template;
using Nico.Utils;
using UnityEngine;

namespace Games.DungeonGame.Scripts.Weapon
{
    public class LazyGun: TemplateEntityMonoBehavior<LazyGun>
    {
        public Transform shootTransform;
        public LineRenderer lazyer;
        public LayerMask targetMask;
        //粒子效果
        private TemplateInput<LazyGun> input;
        private Animator ac;
        private bool isShooting = true;
        protected override void _get_mono_components()
        {
            ac = GetComponent<Animator>();
            lazyer = GetComponentInChildren<LineRenderer>();
        }

        protected override void _init_components()
        {
            input = new TemplateInput<LazyGun>(this);
            Add(input);
        }

        protected override void _init_controller()
        {
            
        }

        protected override void Update()
        {
            base.Update();
            var direction = Facing.Self2MouseDirection(transform,Camera.main);
            Facing.Facing2DDirection(transform, direction);
            //在攻击时松开右键 则停止攻击
            if (input.releaseRightAttack&&isShooting)
            {
                isShooting = false;
                ac.SetBool("attack",false);
                return;
            }
            //按下右键并且没有在攻击时 则开始攻击
            if (input.performRightAttack&&!isShooting)
            {
                isShooting = true;
                ac.SetBool("attack",true);
                StartShoot().Forget();
            }
            
        }
        private async UniTask StartShoot()
        {
            lazyer.enabled = true;
            while (isShooting)
            {
                var direction = Facing.Self2MouseDirection(transform,Camera.main);
                var hit = Physics2D.Raycast(shootTransform.position, direction, 100, targetMask);
                lazyer.SetPosition(0,shootTransform.position);
                lazyer.SetPosition(1,hit.point);
                await UniTask.WaitForFixedUpdate();
            }
            lazyer.enabled = false;
        }
    }
}