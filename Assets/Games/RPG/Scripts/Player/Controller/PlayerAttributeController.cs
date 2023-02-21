using Nico.Algorithm;
using Nico.ECC;
using RPG.Setting;
using UnityEngine;

namespace RPG.Controller
{
    public class PlayerAttributeController : IController<Player>
    {
        public Player owner { get; set; }
        private PlayerAttribute attribute=>owner.attribute;
        private Animator ac => owner.ac;
        private PlayerSetting setting => owner.setting;

        private int xCode => Animator.StringToHash(setting.xCode);
        private int yCode => Animator.StringToHash(setting.yCode);

        public PlayerAttributeController(Player owner)
        {
            this.owner = owner;
        }

        public void OnEnable()
        {
        }

        public void OnDisable()
        {
        }

        public void Start()
        {
        }

        public void Update()
        {
            var move = owner.input.move;
            attribute.velocity = new Vector2(move.x * setting.xSpeed, move.y * setting.ySpeed);
            attribute.state = owner.stateMachine.curState.GetType().Name;
            if (owner.stateMachine.curState.GetType() != typeof(AttackState))
            {
                //攻击的时候不能改变朝向
                UpdateFacing();
            }
        }

        public void UpdateFacing()
        {
            var move = owner.input.move;
            if (move == Vector2.zero)
            {
                return;
            }
            else
            {
                if (move.x > 0)
                    attribute.facingDirection = Direction2DEnum.Right;
                else if (move.x < 0)
                    attribute.facingDirection = Direction2DEnum.Left;
                else if (move.y > 0)
                    attribute.facingDirection = Direction2DEnum.Up;
                else if (move.y < 0)
                    attribute.facingDirection = Direction2DEnum.Down;
                ac.SetFloat(xCode, move.x);
                ac.SetFloat(yCode, move.y);
            }
        }

        public void FixedUpdate()
        {
        }
    }
}