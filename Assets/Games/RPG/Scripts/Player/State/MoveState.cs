using System.Linq;
using Nico.Utils.Core.StateMachine;
using RPG.Setting;
using UnityEngine;

namespace RPG
{
    public class MoveState : IState<Player>
    {
        public Player owner { get; set; }
        private PlayerSetting setting => owner.setting;
        public IStateMachine<Player> machine { get; set; }
        private readonly int animParam;
        public MoveState(Player owner,IStateMachine<Player> machine,string animParam)
        {
            this.owner = owner;
            this.machine = machine;
            this.animParam = Animator.StringToHash(animParam);
        }
        public void Enable()
        {
        }

        public void Disable()
        {
        }


        public void Update()
        {
            if (owner.input.Move == Vector2.zero)
            {
                machine.Change<IdleState>();
            }
        }

        public void FixedUpdate()
        {
            var move = owner.input.Move;
            if (move != Vector2.zero)
            {
                // int count = owner.rb.Cast(move, owner.contactFilter, owner.raycastHit2Ds, owner.collisionOffsett);
                var speed = new Vector2(move.x * setting.xSpeed, move.y * setting.ySpeed);
                Debug.DrawRay(owner.rb.position, move);
                owner.rb.MovePosition(owner.rb.position + speed * Time.fixedDeltaTime);
            }
            else
            {
                machine.Change<IdleState>();
            }
        }

        public void Exit()
        {
            owner.rb.velocity = Vector2.zero;
            owner.animator.SetBool(animParam,false);
        }

        public void Enter()
        {
            owner.animator.SetBool(animParam,true);
        }
    }
}