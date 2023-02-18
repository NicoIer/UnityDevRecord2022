using Nico.Utils.Core.StateMachine;
using UnityEngine;

namespace RPG
{
    public class IdleState : IState<Player>
    {
        public Player owner { get; set; }
        public IStateMachine<Player> machine { get; set; }

        public IdleState(Player owner,IStateMachine<Player> machine)
        {
            this.owner = owner;
            this.machine = machine;
        }
        public void Update()
        {
            if (owner.input.Move != Vector2.zero)
            {
                machine.Change<MoveState>();
            }
        }

        public void FixedUpdate()
        {
        }

        public void Exit()
        {
        }

        public void Enter()
        {
        }

        public void Enable()
        {
        }

        public void Disable()
        {
        }
    }
}