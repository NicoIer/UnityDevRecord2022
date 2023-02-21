using Nico.Template;
using Nico.Utils.Core;
using UnityEngine;

namespace WeaponSys.State
{
    public class MoveState : TemplateState<Player>
    {
        public MoveState(Player owner, IStateMachine<Player> machine, string animParam) : base(owner, machine, animParam)
        {
        }

        public override void Update()
        {
            
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