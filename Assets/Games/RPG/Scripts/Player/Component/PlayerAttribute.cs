using System;
using Nico.Algorithm;
using Nico.Utils.Core;
using RPG.Setting;
using Sirenix.OdinInspector;
using UnityEngine;

namespace RPG
{
    /// <summary>
    /// 这里是角色的属性
    /// </summary>
    [Serializable]
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