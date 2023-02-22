using System;
using System.Collections.Generic;
using Nico.ECC.Dependency;
using Sirenix.OdinInspector;
using UnityEngine;
using UnityEngine.Rendering;

namespace WeaponSys
{
    [Serializable]
    public class SwordAttackMoveData: DataElement
    {
        public List<Vector2> offsets;
        public List<float> speeds;
    }
}