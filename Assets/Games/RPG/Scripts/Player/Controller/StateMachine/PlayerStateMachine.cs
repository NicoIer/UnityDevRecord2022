using Nico.Template;

namespace RPG
{
    public class PlayerStateMachine : TemplateEntityStateMachine<Player>
    {
        
        public PlayerStateMachine(Player owner) : base(owner)
        {
        }
        
        #region IStateMachine

        public override void Start()
        {
            states.TryAdd(typeof(IdleState), new IdleState(owner,this,owner.setting.animIdle));
            states.TryAdd(typeof(WalkState), new WalkState(owner, this,owner.setting.animWalk));
            states.TryAdd(typeof(AttackState), new AttackState(owner, this,owner.setting.animAttack));
            // states.TryAdd(typeof(RunState), new RunState(owner, this,owner.setting.animRun));
            //ToDo 期望这里可以自动添加所有的状态
            curState = states[typeof(IdleState)];
        }

        
        public override void OnEnable()
        {
        }

        public override void OnDisable()
        {
        }
        
        #endregion
    }
}