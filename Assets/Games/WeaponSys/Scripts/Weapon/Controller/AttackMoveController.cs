using System;
using Nico.Algorithm;
using Nico.ECC;
using UnityEngine;

namespace WeaponSys
{
    public class AttackMoveController : IController<Weapon>
    {
        public Weapon owner { get; }

        private Direction2DEnum facingDirection => owner.player.attribute.facingDirection;

        private Rigidbody2D rb=>owner.rb;
        private Vector2 velocity;
        private SwordAttackMoveData curAttackMoveData=>owner.data.GetDataElement<SwordAttackMoveData>();
        private AnimationEventHandler animationEventHandler => owner.animationEventHandler;
        private bool stopMove = true;

        public AttackMoveController(Weapon owner)
        {
            this.owner = owner;
        }

        public void OnEnable()
        {
            animationEventHandler.OnStartMove += _handle_start_move;
            animationEventHandler.OnStopMove += _handle_stop_move;
        }

        public void OnDisable()
        {
            animationEventHandler.OnStartMove -= _handle_start_move;
            animationEventHandler.OnStopMove -= _handle_stop_move;
        }

        private void _handle_start_move()
        {
            stopMove = false;

            
            var curAttackIndex = owner.baseAc.curAttackIndex;
            //这里会根据玩家的此帧的输入朝向朝向来决定攻击的方向

            try
            {
                var offset = curAttackMoveData.offsets[curAttackIndex].normalized;
                var speed = curAttackMoveData.speeds[curAttackIndex];
                velocity = offset * speed;
                var move = owner.player.input.move;
                int facing = 1;
                if (move.x == 0)
                {
                    switch (facingDirection)
                    {
                        case Direction2DEnum.Right:
                            facing = 1;
                            break;
                        case Direction2DEnum.Left:
                            facing = -1;
                            break;
                    }
                }
                else
                {
                    facing = move.x > 0 ? 1 : -1;
                }


                velocity.x *= facing;
            }
            catch (ArgumentOutOfRangeException)
            {
                velocity = Vector2.zero;
            }
            catch (Exception e)
            {
                Debug.LogError(e);
                velocity = Vector2.zero;
            }
        }

        private void _handle_stop_move()
        {
            stopMove = true;
            velocity = Vector2.zero;
        }

        public void Start()
        {
        }

        public void Update()
        {
        }

        public void FixedUpdate()
        {
            if (!stopMove)
            {
                rb.velocity = velocity;
            }
        }
    }
}