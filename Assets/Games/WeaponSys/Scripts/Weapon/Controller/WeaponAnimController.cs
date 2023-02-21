using Nico.Utils.Core;
using UnityEngine;

namespace WeaponSys
{
namespace WeaponSys
{
    /// <summary>
    /// 武器精灵控制器
    /// </summary>
    public class WeaponAnimController : IController<Weapon>
    {
        public Weapon owner { get; }
        private readonly SpriteRenderer baseRenderer;
        private readonly SpriteRenderer weaponRenderer;
        private int currentSpriteIndex;

        public WeaponAnimController(Weapon owner, SpriteRenderer baseRenderer, SpriteRenderer weaponRenderer)
        {
            this.owner = owner;
            this.baseRenderer = baseRenderer;
            this.weaponRenderer = weaponRenderer;
            currentSpriteIndex = 0;
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

            owner.baseAc.onEnter += _on_anim_enter;
            owner.baseAc.OnExit += _on_anim_exit;
        }

        public void OnDisable()
        {
            baseRenderer.UnregisterSpriteChangeCallback(_on_sprite_change);
            owner.baseAc.onEnter -= _on_anim_enter;
            owner.baseAc.OnExit += _on_anim_exit;
        }

        private void _on_anim_exit()
        {
            weaponRenderer.sprite = null;
        }

        /// <summary>
        /// 当baseRenderer的sprite发生变化时，更新武器的sprite
        /// 原理如下: 当播放动画时 每帧的sprite都会发生变化，所以我们可以通过监听这个变化来重新指定武器的sprite
        /// 从而达到播放不同武器动画的效果
        /// </summary>
        /// <param name="rerer"></param>
        private void _on_sprite_change(SpriteRenderer rerer)
        {
            if (!owner.baseAc.playing)
            {
                weaponRenderer.sprite = null;
                return;
            }

            var curAnim = owner.data.attackAnim[owner.baseAc.curAttackIndex].sprites;
            if (currentSpriteIndex >= curAnim.Count)
            {
                Debug.Log($"{owner.name} weapon sprite index out of range {currentSpriteIndex}");
                return;
            }

            weaponRenderer.sprite = curAnim[currentSpriteIndex];
            ++currentSpriteIndex;
        }

        private void _on_anim_enter()
        {
            currentSpriteIndex = 0;
        }
    }
}
}