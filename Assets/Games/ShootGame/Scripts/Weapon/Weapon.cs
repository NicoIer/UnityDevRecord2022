using Nico.ECC.Template;
using UnityEngine;

namespace ShootGame
{
    public class Weapon : TemplateEntityMonoBehavior<Weapon>
    {
        public Player player { get; private set; }
        public Animator animator { get; private set; }
        public AnimationEventHandler acEventHandler { get; private set; }
        public WeaponAnimController acController { get; private set; }
        public SpriteRenderer baseRe { get; private set; }
        public SpriteRenderer gunRe { get; private set; }
        public WeaponData data;

        public Vector3 worldPosition => transform.position;
        protected override void _get_mono_components()
        {
            player = GetComponentInParent<Player>();
            animator = GetComponentInChildren<Animator>();
            acEventHandler = GetComponentInChildren<AnimationEventHandler>();
            baseRe = transform.Find("base").GetComponent<SpriteRenderer>();
            gunRe = transform.Find("gun").GetComponent<SpriteRenderer>();
        }

        protected override void _init_components()
        {
        }

        protected override void _init_controller()
        {
            acController = new WeaponAnimController(this);
            AddController(acController);
            var positionController = new PositionController(this);
            AddController(positionController);
            var shootController = new ShootController(this);
            AddController(shootController);
        }

        public void SetActive(bool active)
        {
            gameObject.SetActive(active);
        }
    }
}