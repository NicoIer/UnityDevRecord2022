using System;
using System.Collections.Generic;
using Nico.ECC.Dependency;
using UnityEngine;

namespace WeaponSys
{
    [Serializable]
    public class AttackDamageData: DataElement
    {
        [field: SerializeField] public List<float> anmount { get; private set; }
        public float this[int idx] => anmount[idx];
    }
}