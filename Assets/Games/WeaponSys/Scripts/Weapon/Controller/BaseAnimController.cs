using System;
using System.Threading;
using Cysharp.Threading.Tasks;
using Nico.Algorithm;
using Nico.ECC;
using UnityEngine;
using WeaponSys.State;

namespace WeaponSys
{
    /// <summary>
    /// 武器动画控制器
    /// </summary>
    public class BaseAnimController : IController<Weapon>
    {
        public int curAttackIndex;

        #region Events

        public event Action OnExit;
        public event Action onEnter;

        #endregion

        public Weapon owner { get; }
        private AnimationEventHandler animationEventHandler => owner.animationEventHandler;
        private CancellationTokenSource cancellationTokenSource = new();
        private Animator ac => owner.ac;

        private SpriteRenderer renderer=>owner.baseRenderer;
        public bool playing { get; private set; } = false;

        public BaseAnimController(Weapon owner)
        {
            this.owner = owner;
        }

        public void OnEnable()
        {
            animationEventHandler.OnExit += _anim_exit;
        }

        public void OnDisable()
        {
            animationEventHandler.OnExit -= _anim_exit;
        }

        public void Start()
        {
        }

        public void Update()
        {

            if (owner.player.stateMachine.curState is AttackState && !playing)
            {
                _player_anim();
                return;
            }
        }

        public void FixedUpdate()
        {
        }

        private void _player_anim()
        {
            playing = true;

            _cancel_cool_down();
            ++curAttackIndex;
            curAttackIndex %= owner.data.numOfAttack;
            if (owner.player.attribute.facingDirection == Direction2DEnum.Left)
            {
                renderer.flipX = true;
            }
            else
            {
                renderer.flipX = false;
            }
            //设置武器攻击动画
            ac.SetBool("activate", true);
            ac.SetInteger("count", curAttackIndex);
            //更新武器攻击次数

            //
            onEnter?.Invoke();
        }

        //退出时新建计时器
        private void _anim_exit()
        {
            playing = false;
            ac.SetBool("activate", false);
            _start_cool_down();
            OnExit?.Invoke();
        }

        #region 连击计时

        private void _cancel_cool_down()
        {
            cancellationTokenSource.Cancel(); //取消上一次的定时器
            cancellationTokenSource = new CancellationTokenSource();
        }

        private void _start_cool_down()
        {
            UniTask.Delay(TimeSpan.FromSeconds(owner.data.attackInterval),
                    cancellationToken: cancellationTokenSource.Token)
                .ContinueWith(() =>
                {
                    curAttackIndex = 0;
                    ac.SetInteger("count", curAttackIndex);
                }).Forget();
        }

        #endregion
    }
}