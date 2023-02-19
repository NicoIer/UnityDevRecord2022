using System.Linq;
using Nico.Algorithm;
using Nico.Utils.Core.StateMachine;
using RPG.Setting;
using UnityEngine;

namespace RPG
{
    public class WalkState : IState<Player>
    {
        public Player owner { get; set; }
        private PlayerSetting setting => owner.setting;
        public IStateMachine<Player> machine { get; set; }
        private readonly int animParam;

        private Vector2 move => owner.input.Move;

        public WalkState(Player owner, IStateMachine<Player> machine, string animParam)
        {
            this.owner = owner;
            this.machine = machine;
            this.animParam = Animator.StringToHash(animParam);
        }

        public void Enable()
        {
        }

        public void Disable()
        {
        }


        public void Update()
        {
        }

        public void FixedUpdate()
        {
            if (move != Vector2.zero)
            {
                // owner.attribute.UpdateFacing();
                _apply_velocity();
            }
            else
            {
                machine.Change<IdleState>();
            }
        }

        public void Exit()
        {
            owner.rb.velocity = Vector2.zero;
            owner.ac.SetBool(animParam, false);
        }

        public void Enter()
        {
            // owner.attribute.UpdateFacing();
            owner.ac.SetBool(animParam, true);
        }

        private void _apply_velocity()
        {
            Debug.DrawRay(owner.rb.position, move);
            var speed = new Vector2(move.x * setting.xSpeed, move.y * setting.ySpeed);
            owner.rb.MovePosition(owner.rb.position + speed * Time.fixedDeltaTime);
        }
    }
}