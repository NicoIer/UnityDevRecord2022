using System;
using Nico.Algorithm;
using Nico.Utils.Core;
using UnityEngine;

namespace WeaponSys
{
    public class MoveController : IController<Weapon>
    {
        public Weapon owner { get; }
        
        private Direction2DEnum facingDirection => owner.player.attribute.facingDirection;

        //ToDo 这样的方式不好,应该使用一个IComponet来存储数据,然后实现一个对应的Controller来通过Component来控制RB的速度
        private readonly Rigidbody2D rb;
        private Vector2 velocity;
        private SwordAttackData curAttackData;
        private AnimationEventHandler animationEventHandler => owner.animationEventHandler;

        private bool stopMove = true;

        public MoveController(Weapon owner, Rigidbody2D rb)
        {
            this.owner = owner;
            this.rb = rb;
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
            int facing = 1;
            switch (facingDirection)
            {
                case Direction2DEnum.Right:
                    facing = 1;
                    break;
                case Direction2DEnum.Left:
                    facing = -1;
                    break;
            }
            
            curAttackData = owner.data.swordAttackData;
            var curAttackIndex = owner.baseAc.curAttackIndex;
            try
            {
                var offset = curAttackData.offsets[curAttackIndex].normalized;
                var speed = curAttackData.speeds[curAttackIndex];
                velocity = facing * offset * speed;
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