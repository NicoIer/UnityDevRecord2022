﻿using System;
using System.Threading;
using Cysharp.Threading.Tasks;
using Nico.Utils.Core;
using UnityEngine;

namespace WeaponSys
{
    /// <summary>
    /// 武器动画控制器
    /// </summary>
    public class AnimController : IController<Weapon>
    {
        public int curAttackCount;

        #region Events

        public event Action OnExit;
        public event Action onEnter;

        #endregion

        public Weapon owner { get; }
        private AnimationEventHandler animationEventHandler => owner.animationEventHandler;
        private CancellationTokenSource cancellationTokenSource = new();
        private Animator ac => owner.ac;
        public bool playing { get; private set; } = false;

        public AnimController(Weapon owner)
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
            if (owner.oper.Player.NormalAttack.WasPressedThisFrame() && !playing)
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
            Debug.Log("enter");
            playing = true;

            _cancel_cool_down();
            ++curAttackCount;
            curAttackCount %= owner.data.numOfAttack;
            //设置武器攻击动画
            ac.SetBool("activate", true);
            ac.SetInteger("count", curAttackCount);
            //更新武器攻击次数

            //
            onEnter?.Invoke();
        }

        //退出时新建计时器
        private void _anim_exit()
        {
            Debug.Log("exit");
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
                    curAttackCount = 0;
                    ac.SetInteger("count", curAttackCount);
                }).Forget();
        }

        #endregion
    }
}