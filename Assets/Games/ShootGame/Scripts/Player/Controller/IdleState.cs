using Mirror;
using Nico.ECC;
using Nico.ECC.Template;
using UnityEngine;

namespace ShootGame
{
    public class IdleState : TemplateState<Player>
    {
        // private NetworkAnimator ac => owner.ac;
        private Animator ac => owner.ac;
        public override void Update()
        {
            if (owner.input.move != Vector2.zero)
            {
                machine.Change<RunState>();
            }
        }

        public override void FixedUpdate()
        {
        }

        public override void Exit()
        {
            ac.SetBool(animParam,false);
        }

        public override void Enter()
        {
            ac.SetBool(animParam,true);
            
        }

        public IdleState(Player owner, IStateMachine<Player> machine, string animParam) : base(owner, machine,
            animParam)
        {
        }
    }
}