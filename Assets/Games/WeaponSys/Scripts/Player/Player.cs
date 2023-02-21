using Nico.Template;
using UnityEngine;

namespace WeaponSys
{
    public class Player : TemplateEntityMonoBehavior<Player>
    {
        [field: SerializeField] public Weapon primaryWeapon { get; private set; }
        [field: SerializeField] public Weapon secondaryWeapon { get; private set; }
        public Animator ac { get; private set; }

        public TemplateInput<Player> input { get; private set; }
        public PlayerStateMachine stateMachine { get; private set; }

        protected override void _get_mono_components()
        {
            primaryWeapon = transform.Find("primaryWeapon").GetComponent<Weapon>();
            secondaryWeapon = transform.Find("secondaryWeapon").GetComponent<Weapon>();
            ac = GetComponent<Animator>();
        }

        protected override void _init_components()
        {
            input = new TemplateInput<Player>(this);
            components.Add(input);
        }

        protected override void _init_controller()
        {
            stateMachine = new PlayerStateMachine(this);
            controllers.Add(stateMachine);
        }
    }
}