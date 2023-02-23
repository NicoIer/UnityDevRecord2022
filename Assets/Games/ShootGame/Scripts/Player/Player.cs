using Mirror;
using Nico.ECC.Template;
using UnityEngine;

namespace ShootGame
{
    public class Player : TemplateNetworkEntityMonoBehavior<Player>
    {
        // public NetworkAnimator nac { get; private set; }
        public Animator ac { get; private set; }
        public Rigidbody2D rb { get; private set; }
        public PlayerInput input { get; private set; }
        public PlayerStateMachine machine { get; private set; }
        [field: SerializeField] public PlayerAttribute attribute { get; private set; }
        public Weapon primaryWeapon;
        public Weapon secondaryWeapon;
        [field: SerializeField] public PlayerData data { get; private set; }

        protected override void _get_mono_components()
        {
            ac = GetComponent<Animator>();
            // nac = GetComponent<NetworkAnimator>();
            rb = GetComponent<Rigidbody2D>();

            primaryWeapon = transform.Find("primaryWeapon").GetComponent<Weapon>();
            secondaryWeapon = transform.Find("secondaryWeapon").GetComponent<Weapon>();
        }

        protected override void _init_components()
        {
            attribute = new PlayerAttribute(this);
            AddComponent(attribute);
            input = new PlayerInput(this);
            AddComponent(input);
        }

        protected override void _init_controller()
        {
            machine = new PlayerStateMachine(this);
            AddController(machine);
            var weaponSwitchController = new WeaponSwitchController(this);
            AddController(weaponSwitchController);
        }
    }
}