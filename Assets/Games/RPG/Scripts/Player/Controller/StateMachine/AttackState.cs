using Nico.ECC.Template;
using Nico.ECC;
using UnityEngine;

namespace RPG
{
    public class AttackState : TemplateState<Player>
    {
        public AttackState(Player owner, IStateMachine<Player> machine, string animParam) : base(owner, machine,
            animParam)
        {
        }

        public override void Update()
        {
            var stateInfo = owner.ac.GetCurrentAnimatorStateInfo(0);
            if (stateInfo.normalizedTime >= 1)
                machine.Change<IdleState>();
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