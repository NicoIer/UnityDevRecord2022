using System;
using Nico.Algorithm;
using Nico.Utils.Core;
using RPG.Setting;
using Sirenix.OdinInspector;
using UnityEngine;

namespace RPG
{
    [Serializable]
    public class PlayerAttribute : IController<Player>
    {
        [ShowInInspector, ReadOnly] public Vector2 velocity { get; private set; }

        [ShowInInspector, ReadOnly] public string state { get; private set; }

        [ShowInInspector, ReadOnly] public Direction2DEnum facing { get; private set; }
        private Animator ac => owner.ac;
        private PlayerSetting setting => owner.setting;
        private int xCode => Animator.StringToHash(setting.xCode);
        private int yCode => Animator.StringToHash(setting.yCode);

        public Player owner { get; }

        public PlayerAttribute(Player owner)
        {
            this.owner = owner;
        }

        public void Start()
        {
        }

        public void Update()
        {
            velocity = new Vector2(owner.input.Move.x * setting.xSpeed, owner.input.Move.y * setting.ySpeed);
            state = owner.stateMachine.cur.GetType().Name;
        }

        public void FixedUpdate()
        {
            UpdateFacing();
        }

        public void UpdateFacing()
        {
            var move = owner.input.Move;
            if (move == Vector2.zero) return;
            else
            {
                if (move.x > 0)
                    facing = Direction2DEnum.Right;
                else if (move.x < 0)
                    facing = Direction2DEnum.Left;
                else if (move.y > 0)
                    facing = Direction2DEnum.Up;
                else if (move.y < 0)
                    facing = Direction2DEnum.Down;
                
                ac.SetFloat(xCode, move.x);
                ac.SetFloat(yCode, move.y);
            }
        }

        public void Enable()
        {
        }

        public void Disable()
        {
        }
    }
}