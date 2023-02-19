using Nico.Algorithm;
using Nico.Utils.Core;
using RPG.Setting;
using UnityEngine;

namespace RPG.Controller
{
    public class PlayerAttributeController : IController<Player>
    {
        public Player owner { get; set; }
        private readonly PlayerAttribute attribute;
        private Animator ac => owner.ac;
        private PlayerSetting setting => owner.setting;

        private int xCode => Animator.StringToHash(setting.xCode);
        private int yCode => Animator.StringToHash(setting.yCode);

        public PlayerAttributeController(Player owner, PlayerAttribute attribute)
        {
            this.owner = owner;
            this.attribute = attribute;
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
            attribute.velocity = new Vector2(owner.input.Move.x * setting.xSpeed, owner.input.Move.y * setting.ySpeed);
            attribute.state = owner.stateMachine.cur.GetType().Name;
            if (owner.stateMachine.cur.GetType() != typeof(AttackState))
            {
                //攻击的时候不能改变朝向
                UpdateFacing();
            }
        }

        public void UpdateFacing()
        {
            var move = owner.input.Move;
            if (move == Vector2.zero) return;
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