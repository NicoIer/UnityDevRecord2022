using Nico.Template;
using Nico.Utils.Core;
using UnityEngine;

namespace WeaponSys.State
{
    public class IdleState : TemplateState<Player>
    {
        private Vector2 move => owner.input.move;
        private bool rightAttack => owner.input.rightAttack;


        public override void Update()
        {
            if (rightAttack)
            {
                machine.Change<AttackState>();
            }

            if (move.x != 0)
            {
                machine.Change<MoveState>();
                return;
            }
        }

        public override void FixedUpdate()
        {
        }


        public IdleState(Player owner, IStateMachine<Player> machine, string animParam) : base(owner, machine,
            animParam)
        {
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