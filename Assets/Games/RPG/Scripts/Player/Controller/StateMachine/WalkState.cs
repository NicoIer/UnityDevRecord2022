using System.Linq;
using Nico.Algorithm;
using Nico.Utils.Core;
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
        private bool run => owner.input.Run;
        private bool attack => owner.input.Attack;

        public WalkState(Player owner, IStateMachine<Player> machine, string animParam)
        {
            this.owner = owner;
            this.machine = machine;
            this.animParam = Animator.StringToHash(animParam);
        }


        public void Update()
        {
            if (move == Vector2.zero)
            {
                machine.Change<IdleState>();
                return;
            }

            if (attack)
            {
                machine.Change<AttackState>();
                return;
            }

            // if (run)
            // {//按下跑步键
            //     return;
            // }
        }

        public void FixedUpdate()
        {
            _apply_velocity();
        }

        public void Exit()
        {
            owner.rb.velocity = Vector2.zero;
            owner.ac.SetBool(animParam, false);
        }

        public void Enter()
        {
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