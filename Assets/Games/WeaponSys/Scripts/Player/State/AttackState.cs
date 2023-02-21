using Nico.Utils.Core;
using UnityEngine;

namespace WeaponSys.State
{
    public class AttackState: IState<Player>
    {
        public Player owner { get; set; }
        public IStateMachine<Player> machine { get; set; }
        private readonly int animParam;
        public AttackState(Player owner, IStateMachine<Player> machine,string animParam)
        {
            this.owner = owner;
            this.machine = machine;
            this.animParam = Animator.StringToHash(animParam);
        }

        public void Update()
        {
            
        }

        public void FixedUpdate()
        {
            
        }

        public void Exit()
        {
            owner.ac.SetBool(animParam, false);
        }

        public void Enter()
        {
            owner.ac.SetBool(animParam, true);
        }
    }
}