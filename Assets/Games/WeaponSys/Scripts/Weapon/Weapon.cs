using Nico.Template;
using UnityEngine;
using WeaponSys.Components;

namespace WeaponSys
{
    public class Weapon : TemplateEntityMonoBehavior<Weapon>
    {
        public WeaponData data;
        public NormalControls input { get; private set; }

        #region Component

        public AnimationEventHandler animationEventHandler { get; private set; }

        #endregion

        #region Controller

        public AnimController animController { get; private set; }

        #endregion

        #region Mono Components

        public Animator ac { get; private set; }
        public Rigidbody2D rb { get; private set; }
        GameObject baseObj;
        SpriteRenderer baseRenderer;
        GameObject weaponSpriteObj;
        SpriteRenderer weaponRenderer;

        #endregion

        #region Init

        protected override void _get_mono_components()
        {
            baseObj = transform.Find("Base").gameObject;
            baseRenderer = baseObj.GetComponent<SpriteRenderer>();
            ac = baseObj.GetComponent<Animator>();

            animationEventHandler = baseObj.GetComponent<AnimationEventHandler>();

            weaponSpriteObj = transform.Find("WeaponSprite").gameObject;
            weaponRenderer = weaponSpriteObj.GetComponent<SpriteRenderer>();

            rb = GetComponent<Rigidbody2D>();


            input = new NormalControls();
            input.Player.Enable();
        }

        protected override void _init_components()
        {
        }
        
        protected override void _init_controller()
        {
            animController = new AnimController(this);
            controllers.Add(animController);

            var weaponSprite = new SpriteController(this, baseRenderer, weaponRenderer);
            controllers.Add(weaponSprite);

            var weaponMove = new MoveController(this, rb);
            controllers.Add(weaponMove);
        }

        #endregion
    }
}