using Nico.ECC.Template;
using WeaponSys.State;

namespace WeaponSys
{
    public class PlayerStateMachine : TemplateEntityStateMachine<Player>
    {
        public PlayerStateMachine(Player owner) : base(owner)
        {
        }

        public override void OnEnable()
        {
        }

        public override void OnDisable()
        {
        }

        public override void Start()
        {
            states.Add(typeof(IdleState), new IdleState(owner, this, owner.setting.animIdle));
            states.Add(typeof(AttackState), new AttackState(owner, this, owner.setting.animAttack));
            states.Add(typeof(MoveState), new MoveState(owner, this, owner.setting.animWalk));
            Change<IdleState>();
        }
    }
}