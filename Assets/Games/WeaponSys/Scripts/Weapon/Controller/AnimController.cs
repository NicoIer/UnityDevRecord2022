using System;
using System.Threading;
using Cysharp.Threading.Tasks;
using Nico.Utils.Core;
using UnityEngine;

namespace WeaponSys
{
    public class AnimController : IController<Weapon>
    {
        public event Action OnExit;
        public Weapon owner { get; }
        private AnimationEventHandler animationEventHandler => owner.animationEventHandler;
        private CancellationTokenSource cancellationTokenSource = new();
        private Animator ac => owner.ac;
        private bool _attackOver = true;

        public AnimController(Weapon owner)
        {
            this.owner = owner;
            
        }

        public void OnEnable()
        {
            animationEventHandler.OnExit += Exit;
        }

        public void OnDisable()
        {
            animationEventHandler.OnExit -= Exit;
        }

        public void Start()
        {
            animationEventHandler.OnExit += Exit;
        }

        public void Update()
        {
            if (owner.oper.Player.NormalAttack.WasPressedThisFrame() && _attackOver)
            {
                Enter();
                return;
            }
        }

        public void FixedUpdate()
        {
        }

        public void Enter()
        {
            Debug.Log("Enter");
            _attackOver = false;

            _cancel_cool_down();

            //设置武器攻击动画
            ac.SetBool("activate", true);
            ac.SetInteger("count", owner.curAttackCount);
            //更新武器攻击次数
            ++owner.curAttackCount;
            owner.curAttackCount %= owner.numberOfAttack;
            //
        }

        //退出时新建计时器
        private void Exit()
        {
            Debug.Log("Exit");
            _attackOver = true;
            ac.SetBool("activate", false);
            _start_cool_down();
            OnExit?.Invoke();
        }

        private void _cancel_cool_down()
        {
            cancellationTokenSource.Cancel(); //取消上一次的定时器
            cancellationTokenSource = new CancellationTokenSource();
        }

        private void _start_cool_down()
        {
            UniTask.Delay(TimeSpan.FromSeconds(owner.intervalTime), cancellationToken: cancellationTokenSource.Token)
                .ContinueWith(() =>
                {
                    owner.curAttackCount = 0;
                    ac.SetInteger("count", owner.curAttackCount);
                }).Forget();
        }
    }
}