using System;
using Nico.Algorithm;
using Nico.ECC;
using UnityEngine;

namespace ShootGame
{
    public class PlayerAttribute: IComponent<Player>
    {
        private Direction2DEnum _facingDirection;

        public Direction2DEnum facingDirection
        {
            get => _facingDirection;
            set
            {
                if (_facingDirection == value)
                {
                    return;
                }

                switch (value)
                {
                    case Direction2DEnum.Right:
                        owner.ac.SetTrigger(FacingRight);
                        break;
                    case Direction2DEnum.Left:
                        owner.ac.ResetTrigger(FacingRight);
                        break;
                    case Direction2DEnum.Up:
                        break;
                    case Direction2DEnum.Down:
                        break;
                    default:
                        throw new ArgumentOutOfRangeException(nameof(value), value, null);
                }
                _facingDirection = value;
            }
        }
        
        public Vector2 velocity;
        private static readonly int FacingRight = Animator.StringToHash("facingRight");
        public Player owner { get; set; }

        public PlayerAttribute(Player owner)
        {
            this.owner = owner;
        }
        public void OnEnable()
        {
            
        }

        public void OnDisable()
        {

        }
    }
}