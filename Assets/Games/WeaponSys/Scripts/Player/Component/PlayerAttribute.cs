using Nico.Algorithm;
using Nico.ECC;
using Sirenix.OdinInspector;
using UnityEngine;

namespace WeaponSys.Component
{
    public class PlayerAttribute : IComponent<Player>
    {
        [ShowInInspector, ReadOnly] public Vector2 velocity;

        [ShowInInspector, ReadOnly] public string state;

        [ShowInInspector, ReadOnly] public Direction2DEnum facingDirection;


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