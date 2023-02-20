﻿using Nico.Utils.Core;
using UnityEngine;

namespace WeaponSys.Components
{
    /// <summary>
    /// 武器精灵控制器
    /// </summary>
    public class WeaponSprite : IController<Weapon>
    {
        public Weapon owner { get; }
        private SpriteRenderer baseRenderer;
        private SpriteRenderer weaponRenderer;
        private int currentSpriteIndex = 0;

        public WeaponSprite(Weapon owner, SpriteRenderer baseRenderer, SpriteRenderer weaponRenderer)
        {
            this.owner = owner;
            this.baseRenderer = baseRenderer;
            this.weaponRenderer = weaponRenderer;
        }


        public void Start()
        {
        }

        public void Update()
        {
        }

        public void FixedUpdate()
        {
        }


        public void OnEnable()
        {
            baseRenderer.RegisterSpriteChangeCallback(_on_sprite_change);

            owner.animController.onEnter += _on_anim_enter;
        }

        public void OnDisable()
        {
            baseRenderer.UnregisterSpriteChangeCallback(_on_sprite_change);
            owner.animController.onEnter -= _on_anim_enter;
        }

        /// <summary>
        /// 当baseRenderer的sprite发生变化时，更新武器的sprite
        /// 原理如下: 当播放动画时 每帧的sprite都会发生变化，所以我们可以通过监听这个变化来重新指定武器的sprite
        /// 从而达到播放不同武器动画的效果
        /// </summary>
        /// <param name="rerer"></param>
        private void _on_sprite_change(SpriteRenderer rerer)
        {
            if (!owner.animController.playing)
            {
                weaponRenderer.sprite = null;
                return;
            }

            var curSprites = owner.data.sprites[owner.animController.curAttackCount].sprites;
            if (currentSpriteIndex >= curSprites.Length)
            {
                Debug.Log($"{owner.name} weapon sprite index out of range {currentSpriteIndex}");
                return;
            }
            
            weaponRenderer.sprite = curSprites[currentSpriteIndex];
            ++currentSpriteIndex;
        }

        private void _on_anim_enter()
        {
            currentSpriteIndex = 0;
        }
    }
}