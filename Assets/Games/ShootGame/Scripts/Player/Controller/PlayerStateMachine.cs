using Nico.ECC.Template;

namespace ShootGame
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
            Add(new IdleState(owner, this, "idle"));
            Add(new RunState(owner, this, "run"));

            Change<IdleState>();
        }

        public override void Change<T1>()
        {
            base.Change<T1>();
            owner.attribute.state = curState.GetType().Name;
        }
    }
}