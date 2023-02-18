using Nico.Utils.Core.StateMachine;
using RPG.Setting;
using UnityEngine;

namespace RPG
{
    public class MoveState : IState<Player>
    {
        public Player owner { get; set; }
        public PlayerSetting setting => owner.setting;
        public IStateMachine<Player> machine { get; set; }

        public MoveState(Player owner, IStateMachine<Player> machine)
        {
            this.owner = owner;
            this.machine = machine;
        }

        public void Enable()
        {
        }

        public void Disable()
        {
        }


        public void Update()
        {
            if (owner.input.Move == Vector2.zero)
            {
                machine.Change<IdleState>();
            }
        }

        public void FixedUpdate()
        {
            var input = owner.input.Move;
            owner.rb.velocity = new Vector2(input.x * setting.x_speed, input.y * setting.y_speed);
        }

        public void Exit()
        {
            owner.rb.velocity = Vector2.zero;
        }

        public void Enter()
        {
            owner.rb.velocity = owner.input.Move;
        }
    }
}