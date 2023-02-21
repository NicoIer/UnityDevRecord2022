#define NICO_DEBUGD
using System;
using Nico.Algorithm;
using Nico.ECC;
using UnityEngine;

namespace WeaponSys
{
    public class HitBoxController : IController<Weapon>
    {
        public Weapon owner { get; }
        private int curAttackIndex => owner.baseAc.curAttackIndex;
        private HitBoxData data => owner.data.hitBoxData;

        private Vector2 offset;
        private Collider2D[] detectResult;
        public event Action<Collider2D[]> OnDetectHitBox;

        public HitBoxController(Weapon owner)
        {
            this.owner = owner;
        }

        public void OnEnable()
        {
            owner.animationEventHandler.OnAttack += _handle_attack_action;
        }

        public void OnDisable()
        {
            owner.animationEventHandler.OnAttack -= _handle_attack_action;
        }

        public void Start()
        {
        }

        public void Update()
        {
        }

        public void FixedUpdate()
        {
        }


        private void _handle_attack_action()
        {
            var position = owner.transform.position;
            var facing = 1;
            switch (owner.player.attribute.facingDirection)
            {
                case Direction2DEnum.Right:
                    facing = 1;
                    break;
                case Direction2DEnum.Left:
                    facing = -1;
                    break;
                case Direction2DEnum.Up:
                    break;
                case Direction2DEnum.Down:
                    break;
                default:
                    throw new ArgumentOutOfRangeException();
            }

            offset.Set(
                position.x + owner.data.hitBoxData.HitBox[curAttackIndex].center.x * facing,
                position.y + owner.data.hitBoxData.HitBox[curAttackIndex].center.y
            );
            detectResult = Physics2D.OverlapBoxAll(offset, data.HitBox[curAttackIndex].size, 0, data.detectLayer);
            if (detectResult.Length > 0)
            {
                OnDetectHitBox?.Invoke(detectResult);
            }
        }
    }
}