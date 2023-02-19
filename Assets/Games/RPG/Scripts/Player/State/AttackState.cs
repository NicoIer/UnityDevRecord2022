using Nico.Utils.Core.StateMachine;
using UnityEngine;

namespace RPG
{
    public class AttackState : IState<Player>
    {
        public Player owner { get; set; }
        public IStateMachine<Player> machine { get; set; }
        private readonly int animParam;

        public AttackState(Player owner, IStateMachine<Player> machine, string animParam)
        {
            this.owner = owner;
            this.machine = machine;
            this.animParam = Animator.StringToHash(animParam);
        }

        public void Update()
        {
            var stateInfo = owner.ac.GetCurrentAnimatorStateInfo(0);
            if(stateInfo.normalizedTime >= 1)
                machine.Change<IdleState>();
        }

        public void FixedUpdate()
        {
            
        }

        public void Exit()
        {
            owner.ac.SetBool(animParam, false);
        }

        public void Enter()
        {
            owner.ac.SetBool(animParam, true);
        }
    }
}