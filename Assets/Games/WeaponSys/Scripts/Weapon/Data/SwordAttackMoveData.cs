using System;
using System.Collections.Generic;
using Sirenix.OdinInspector;
using UnityEngine;
using UnityEngine.Rendering;

namespace WeaponSys
{
    [Serializable]
    public class SwordAttackMoveData
    {
        public List<Vector2> offsets;
        public List<float> speeds;
    }
}