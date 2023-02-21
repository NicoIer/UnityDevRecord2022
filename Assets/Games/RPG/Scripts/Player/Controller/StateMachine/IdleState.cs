using Nico.Utils.Core;
using UnityEngine;

namespace RPG
{
    public class IdleState : IState<Player>
    {
        public Player owner { get; set; }
        public IStateMachine<Player> machine { get; set; }
        private readonly int animParam;
        private Vector2 move => owner.input.Move;
        private bool run => owner.input.Run;
        private bool attack => owner.input.Attack;
        public IdleState(Player owner,IStateMachine<Player> machine,string animParam)
        {
            this.owner = owner;
            this.machine = machine;
            this.animParam = Animator.StringToHash(animParam);
        }
        public void Update()
        {
            if (attack)
            {
                machine.Change<AttackState>();
                return;
            }
            
            if (move != Vector2.zero)
            {
                machine.Change<WalkState>();
                return;
            }
        }

        public void FixedUpdate()
        {
        }

        public void Exit()
        {
            owner.ac.SetBool(animParam,false);
        }

        public void Enter()
        {
            owner.ac.SetBool(animParam,true);
        }
        


    }
}