using Nico.Template;
using Nico.Utils.Core;
using UnityEngine;

namespace WeaponSys.State
{
    public class IdleState : TemplateState<Player>
    {

        private Vector2 move => owner.input.controls.Player.Move.ReadValue<Vector2>();
        private bool attack => owner.input.controls.Player.NormalAttack.WasPressedThisFrame();



        public override void Update()
        {
            if (attack)
            {
                machine.Change<AttackState>();
            }
            if (move != Vector2.zero)
            {
                machine.Change<MoveState>();
                return;
            }
        }

        public override void FixedUpdate()
        {
        }



        public IdleState(Player owner, IStateMachine<Player> machine, string animParam) : base(owner, machine, animParam)
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