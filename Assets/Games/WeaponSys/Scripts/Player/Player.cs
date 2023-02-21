using Nico.Template;
using UnityEngine;
using WeaponSys.Component;

namespace WeaponSys
{
    public class Player : TemplateEntityMonoBehavior<Player>
    {
        [field: SerializeField] public Weapon primaryWeapon { get; private set; }
        [field: SerializeField] public Weapon secondaryWeapon { get; private set; }
        
        public Animator ac { get; private set; }
        public Rigidbody2D rb { get; private set; }
        public TemplateInput<Player> input { get; private set; }
        public PlayerStateMachine stateMachine { get; private set; }
        [field: SerializeField] public PlayerSetting setting { get; private set; }
        [field: SerializeField] public PlayerAttribute attribute { get; private set; }

        protected override void _get_mono_components()
        {
            primaryWeapon = transform.Find("primaryWeapon").GetComponent<Weapon>();
            secondaryWeapon = transform.Find("secondaryWeapon").GetComponent<Weapon>();
            ac = GetComponent<Animator>();
            rb = GetComponent<Rigidbody2D>();
        }

        protected override void _init_components()
        {
            input = new TemplateInput<Player>(this);
            components.Add(input);
            
            attribute = new PlayerAttribute(this);
            components.Add(attribute);
        }

        protected override void _init_controller()
        {
            stateMachine = new PlayerStateMachine(this);
            controllers.Add(stateMachine);
            var attributeController = new PlayerAttributeController(this);
            controllers.Add(attributeController);
        }
    }
}