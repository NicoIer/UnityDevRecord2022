using System;
using Nico.ECC;
using UnityEngine;

namespace WeaponSys.State
{
    public class AttackState : IState<Player>
    {
        public Player owner { get; set; }
        public IStateMachine<Player> machine { get; set; }
        private readonly int animParam;

        public AttackState(Player owner, IStateMachine<Player> machine, string animParam)
        {
            this.owner = owner;
            this.machine = machine;
            this.animParam = Animator.StringToHash(animParam);
            
        }

        private void _weapon_anim_exit()
        {
            machine.Change<IdleState>();
        }

        public void Update()
        {
        }

        public void FixedUpdate()
        {
        }

        public void Exit()
        {
            owner.primaryWeapon.baseAc.OnExit -= _weapon_anim_exit;
            owner.ac.SetBool(animParam, false);
        }

        public void Enter()
        {
            owner.primaryWeapon.baseAc.OnExit += _weapon_anim_exit;
            owner.ac.SetBool(animParam, true);
        }
    }
}