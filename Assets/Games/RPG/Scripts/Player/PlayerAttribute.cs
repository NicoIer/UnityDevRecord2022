using System;
using Nico.Utils.Core;
using UnityEngine;

namespace RPG
{
    [Serializable]
    public class PlayerAttribute
    {
        public Player owner { get; }
         
        public Vector2 velocity { get; private set; }

        public PlayerAttribute(Player owner)
        {
            this.owner = owner;
        }
    }
}