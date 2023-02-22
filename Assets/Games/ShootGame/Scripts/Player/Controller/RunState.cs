using Nico.Algorithm;
using Nico.ECC;
using Nico.ECC.Template;
using UnityEngine;

namespace ShootGame
{
    public class RunState : TemplateState<Player>
    {
        private Vector2 velocity;
        private Vector2 move => owner.input.move;
        private readonly PlayerMoveData data;
        private PlayerAttribute attribute => owner.attribute;
        private Animator ac => owner.ac;
        public RunState(Player owner, IStateMachine<Player> machine, string animParam) : base(owner, machine, animParam)
        {
            data = owner.data.GetDataElement<PlayerMoveData>();
        }

        public override void Update()
        {
            if (move == Vector2.zero)
            {
                Change<IdleState>();
                return;
            }
        }

        public override void FixedUpdate()
        {
            velocity.x = move.x * data.xSpeed;
            velocity.y = move.y * data.ySpeed;
            var facing = attribute.facingDirection;
            if (move.x > 0 && facing == Direction2DEnum.Left)
            {
                attribute.facingDirection = Direction2DEnum.Right;
            }
            else if (move.x < 0 && facing == Direction2DEnum.Right)
            {
                attribute.facingDirection = Direction2DEnum.Left;
            }

            attribute.velocity = velocity;
            owner.rb.MovePosition(owner.rb.position + velocity * Time.fixedDeltaTime);
        }

        public override void Exit()
        { 
            // ac.ResetTrigger(animParam);
            ac.SetBool(animParam,false);
        }

        public override void Enter()
        {
            // ac.SetTrigger(animParam);
            ac.SetBool(animParam,true);
        }
    }
}