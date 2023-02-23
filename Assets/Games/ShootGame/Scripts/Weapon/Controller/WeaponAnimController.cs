﻿using Nico.Algorithm;
using Nico.Data;
using Nico.ECC.Template;
using UnityEngine;
using UnityEngine.Events;

namespace ShootGame
{
    public class WeaponAnimController : TemplateController<Weapon>
    {
        private bool attackOver = true;
        private bool canAttack = true;
        
        private static readonly int Attack = Animator.StringToHash("attack");
        private AnimationEventHandler eventHandler => owner.acEventHandler;
        private Player player => owner.player;
        private SpriteRenderer baseRe => owner.baseRe;
        private SpriteRenderer gunRe => owner.gunRe;
        private int curSpriteIndex = 0;
        private AnimStorage animStorage => owner.data.animSprites;

        public WeaponAnimController(Weapon owner) : base(owner)
        {
        }

        public override void OnEnable()
        {
            eventHandler.OnStopAttack += _on_stop_attack;
            eventHandler.OnStartAnim += _on_anim_enter;
            eventHandler.OnStopAnim += _on_stop_anim;
            baseRe.RegisterSpriteChangeCallback(_on_spite_change);
        }

        public override void OnDisable()
        {
            eventHandler.OnStopAttack -= _on_stop_attack;
            eventHandler.OnStartAnim -= _on_anim_enter;
            eventHandler.OnStopAnim -= _on_stop_anim;
            baseRe.UnregisterSpriteChangeCallback(_on_spite_change);
        }

        private void _on_spite_change(SpriteRenderer re)
        {
            if (curSpriteIndex >= animStorage.sprites.Count)
            {
                Debug.Log("索引越界");
                gunRe.sprite = null;
                return;
            }

            var sprite = animStorage.sprites[curSpriteIndex];
            gunRe.sprite = sprite;
            curSpriteIndex++;
        }
        private void _on_stop_anim()
        {
            gunRe.sprite = null;
        }
        private void _on_stop_attack()
        {
            Debug.Log("Attack Over");
            attackOver = true;
        }


        private void _on_anim_enter()
        {
            Debug.Log("anim enter!!!");
            curSpriteIndex = 0;
        }

        public override void Start()
        {
        }

        public override void Update()
        {
            if (player.attribute.facingDirection == Direction2DEnum.Left)
            {
                gunRe.flipX = true;
            }
            else
            {
                gunRe.flipX = false;
            }
            //ToDo 小问题: 攻击结束 != 动画结束  此处应该设置要可以进行攻击才能攻击 而非 attackOver 应该使用计时器 当attackOver时开始计时 计时完毕后才能开始下一次攻击
            if (player.input.rightAttack && attackOver)
            {
                attackOver = false;
                owner.animator.SetTrigger(Attack);
                Debug.Log("Attack Start");
                return;
            }
        }

        public override void FixedUpdate()
        {
        }
    }
}