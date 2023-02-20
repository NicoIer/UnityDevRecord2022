using System;
using System.Collections.Generic;
using Sirenix.OdinInspector;
using UnityEngine;

namespace WeaponSys
{
    [Serializable]
    public class WeaponData
    {
        public List<WeaponSprites> sprites = new List<WeaponSprites>();
        public int numOfAttack = 3;
        public float attackInterval = 1.5f;
    }

    [Serializable]
    public class WeaponSprites
    {
        public Sprite[] sprites;
    }
}