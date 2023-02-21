using System;
using System.Collections.Generic;
using UnityEngine;

namespace WeaponSys
{
    [Serializable]
    public class AttackDamageData
    {
        [field: SerializeField] public List<float> anmount { get; private set; }
        public float this[int idx] => anmount[idx];
    }
}