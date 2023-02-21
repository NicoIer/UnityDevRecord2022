using Nico.Template;
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
            states.Add(typeof(IdleState), new IdleState(owner, this, "idle"));
            states.Add(typeof(AttackState), new AttackState(owner, this, "attack"));
            states.Add(typeof(MoveState), new MoveState(owner, this, "move"));
            Change<IdleState>();
        }
    }
}