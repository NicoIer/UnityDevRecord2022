using System.Linq;
using Nico.Algorithm;
using Nico.ECC.Template;
using Nico.ECC;
using RPG.Setting;
using UnityEngine;

namespace RPG
{
    public class WalkState : TemplateState<Player>
    {
        private PlayerSetting setting => owner.setting;


        private Vector2 move => owner.input.move;
        private bool run => owner.input.Run;
        private bool rightAttack => owner.input.rightAttack;


        public WalkState(Player owner, IStateMachine<Player> machine, string animParam) : base(owner, machine,
            animParam)
        {
        }

        public override void Update()
        {
            if (move == Vector2.zero)
            {
                machine.Change<IdleState>();
                return;
            }

            if (rightAttack)
            {
                machine.Change<AttackState>();
                return;
            }

            // if (run)
            // {//按下跑步键
            //     return;
            // }
        }

        public override void FixedUpdate()
        {
            _apply_velocity();
        }

        public override void Exit()
        {
            owner.rb.velocity = Vector2.zero;
            owner.ac.SetBool(animParam, false);
        }

        public override void Enter()
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