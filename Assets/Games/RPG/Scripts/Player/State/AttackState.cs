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
            throw new System.NotImplementedException();
        }

        public void FixedUpdate()
        {
            throw new System.NotImplementedException();
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