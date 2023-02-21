using Nico.ECC.Template;
using Nico.ECC;
using UnityEngine;

namespace RPG
{
    public class IdleState : TemplateState<Player>
    {
        private Vector2 move => owner.input.move;
        private bool run => owner.input.Run;
        private bool rightAttack => owner.input.rightAttack;


        public IdleState(Player owner, IStateMachine<Player> machine, string animParam) : base(owner, machine,
            animParam)
        {
        }

        public override void Update()
        {
            if (rightAttack)
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

        public override void FixedUpdate()
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