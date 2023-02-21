using Nico.Algorithm;
using Nico.Utils.Core;
using UnityEngine;
using WeaponSys.Component;

namespace WeaponSys
{
    public class PlayerAttributeController : IController<Player>
    {
        private static readonly int XCode = Animator.StringToHash("xCode");
        private static readonly int YCode = Animator.StringToHash("yCode");
        public Player owner { get; }
        private Animator ac => owner.ac;
        private Vector2 move => owner.input.move;
        private PlayerAttribute attribute => owner.attribute;
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
            // var speed = new Vector2(move.x * setting.xSpeed, move.y * setting.ySpeed);
            if (move.x > 0)
            {
                attribute.facingDirection = Direction2DEnum.Right;
                ac.SetFloat(XCode, 1);
            }
            else if (move.x < 0)
            {
                attribute.facingDirection = Direction2DEnum.Left;
                ac.SetFloat(XCode, -1);
            }

            attribute.state = owner.stateMachine.curState.GetType().Name;
        }

        public void FixedUpdate()
        {
        }
    }
}