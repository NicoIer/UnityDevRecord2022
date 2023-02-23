using Cysharp.Threading.Tasks;
using Nico.ECC.Template;
using Nico.Utils;
using UnityEngine;

namespace DungeonGame
{
    public class LazyGun : TemplateEntityMonoBehavior<LazyGun>
    {
        public Transform shootTransform;
        private LineRenderer lazyLine;
        
        //粒子效果
        private ParticleSystem _particleSystem;
        public LayerMask targetMask;

        private AnimationEvenetHandler animationEvenetHandler;

        private TemplateInput<LazyGun> input;
        private Animator ac;
        private bool isShooting;

        protected override void _get_mono_components()
        {
            ac = GetComponent<Animator>();
            animationEvenetHandler = GetComponent<AnimationEvenetHandler>();
            lazyLine = GetComponentInChildren<LineRenderer>();
            _particleSystem = GetComponentInChildren<ParticleSystem>();
            _particleSystem.gameObject.SetActive(false);
            animationEvenetHandler.attack += () => { _start_shoot().Forget(); };
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
            var direction = Facing.Self2MouseDirection(transform, Camera.main);
            Facing.Facing2DDirection(transform, direction);
            //在攻击时松开右键 则停止攻击
            if (input.releaseRightAttack && isShooting)
            {
                isShooting = false;
                ac.SetBool("attack", false);
                return;
            }

            //按下右键并且没有在攻击时 则开始攻击
            if (input.performRightAttack && !isShooting)
            {
                isShooting = true;
                ac.SetBool("attack", true);
            }
        }


        private async UniTask _start_shoot()
        {
            lazyLine.enabled = true;
            _particleSystem.gameObject.SetActive(true);
            _particleSystem.Play();
            while (isShooting)
            {
                var direction = Facing.Self2MouseDirection(transform, Camera.main);
                var hit = Physics2D.Raycast(shootTransform.position, direction, 100, targetMask);
                lazyLine.SetPosition(0, shootTransform.position);
                lazyLine.SetPosition(1, hit.point);
                //在终点播放粒子效果
                _particleSystem.transform.position = hit.point;

                await UniTask.WaitForFixedUpdate();
            }
            _particleSystem.Stop();
            _particleSystem.gameObject.SetActive(false);
            lazyLine.enabled = false;
        }
    }
}