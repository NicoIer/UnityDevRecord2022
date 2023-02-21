using Nico.Algorithm;
using Nico.ECC.Template;
using Nico.ECC;
using UnityEngine;

namespace WeaponSys.State
{
    public class MoveState : TemplateState<Player>
    {
        private Vector2 move => owner.input.move;
        private bool rightAttack => owner.input.rightAttack;
        private bool leftAttack => owner.input.leftAttack;
        private Rigidbody2D rb => owner.rb;
        private PlayerSetting setting => owner.setting;

        public MoveState(Player owner, IStateMachine<Player> machine, string animParam) : base(owner, machine,
            animParam)
        {
        }

        public override void Update()
        {
            if (move.x == 0)
            {
                machine.Change<IdleState>();
                return;
            }

            if (rightAttack)
            {
                machine.Change<AttackState>();
                return;
            }
        }

        public override void FixedUpdate()
        {
            _apply_velocity();
        }

        private void _apply_velocity()
        {
            Debug.DrawRay(rb.position, move, Color.red);
            var speed = new Vector2(move.x * setting.xSpeed, rb.velocity.y);
            rb.MovePosition(rb.position + speed * Time.fixedDeltaTime);
        }

        public override void Exit()
        {
            owner.ac.SetBool(animParam, false);
        }

        public override void Enter()
        {
            owner.ac.SetBool(animParam, true);
        }
    }
}