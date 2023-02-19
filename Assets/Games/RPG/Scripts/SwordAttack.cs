using System;
using Nico.Algorithm;
using RPG;
using UnityEngine;

namespace RPG
{
    public class SwordAttack : MonoBehaviour
    {
        public Collider2D collider2D;
        public Vector2 rightPosition;
        public Player player;

        private void Awake()
        {
            collider2D = GetComponent<Collider2D>();
        }

        private void Start()
        {
            rightPosition = transform.position;
        }

        private void Update()
        {
            if (player.stateMachine.cur.GetType() == typeof(AttackState))
            {
                print("进入战斗咯");
                Attack();
            }
            else
            {
                EndAttack();
            }
        }

        public void Attack()
        {
            Direction2DEnum direction2D = player.attribute.facingDirection;
            print(direction2D);
            collider2D.enabled = true;
            switch (direction2D)
            {
                case Direction2DEnum.Right:
                    transform.localScale = new Vector3(1, 1, 1);
                    break;
                case Direction2DEnum.Left:
                    transform.localScale = new Vector3(-1, 1, 1);
                    break;
                case Direction2DEnum.Up:
                    break;
                case Direction2DEnum.Down:
                    break;
                default:
                    throw new ArgumentOutOfRangeException(nameof(direction2D), direction2D, null);
            }
        }

        public void EndAttack()
        {
            collider2D.enabled = false;
        }
    }
}