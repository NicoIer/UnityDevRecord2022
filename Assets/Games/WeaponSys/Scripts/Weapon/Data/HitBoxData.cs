using System;
using System.Collections.Generic;
using UnityEngine;

namespace WeaponSys
{
    [Serializable]
    public class HitBoxData
    {
        [field: SerializeField] public List<Rect> HitBox { get; private set; }
        [field: SerializeField] public LayerMask detectLayer { get; private set; }
    }
}