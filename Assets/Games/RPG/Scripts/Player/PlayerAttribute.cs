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
        private int FacingCode => Animator.StringToHash(setting.facing);
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
            velocity = owner.rb.velocity;
            state = owner.controller.stateMachine.cur.GetType().Name;
        }

        public void FixedUpdate()
        {
        }

        public void UpdateFacing()
        {
            var move = owner.input.Move;
            if (move == Vector2.zero) return;
            if (move.x > 0)
            {
                facing = Direction2DEnum.Right;
                ac.SetInteger(FacingCode, 0);
            }
            else if (move.x < 0)
            {
                facing = Direction2DEnum.Left;
                ac.SetInteger(FacingCode, 1);
            }
            else if (move.y > 0)
            {
                facing = Direction2DEnum.Up;
                ac.SetInteger(FacingCode, 2);
            }
            else if (move.y < 0)
            {
                facing = Direction2DEnum.Down;
                ac.SetInteger(FacingCode, 3);
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