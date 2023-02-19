using System;
using Nico.Algorithm;
using Nico.Utils.Core;
using RPG.Setting;
using Sirenix.OdinInspector;
using UnityEngine;

namespace RPG
{
    /// <summary>
    /// 这里是角色的属性 但是用Controller不是很好 ToDo 准备重构 
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


        public void Enable()
        {
        }

        public void Disable()
        {
        }
    }
}