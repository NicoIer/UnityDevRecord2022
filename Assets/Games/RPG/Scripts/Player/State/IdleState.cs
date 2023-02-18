using Nico.Utils.Core.StateMachine;
using UnityEngine;

namespace RPG
{
    public class IdleState : IState<Player>
    {
        public Player owner { get; set; }
        public IStateMachine<Player> machine { get; set; }
        private readonly int animParam;
        public IdleState(Player owner,IStateMachine<Player> machine,string animParam)
        {
            this.owner = owner;
            this.machine = machine;
            this.animParam = Animator.StringToHash(animParam);
        }
        public void Update()
        {
            var move = owner.input.Move;
            if (move != Vector2.zero)
            {
                machine.Change<MoveState>();
            }
        }

        public void FixedUpdate()
        {
        }

        public void Exit()
        {
            owner.animator.SetBool(animParam,false);
        }

        public void Enter()
        {
            owner.animator.SetBool(animParam,true);
        }

        public void Enable()
        {
        }

        public void Disable()
        {
        }


    }
}