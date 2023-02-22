using System;
using System.Collections.Generic;
using Nico.ECC.Dependency;
using UnityEngine;

namespace WeaponSys
{
    [Serializable]
    public class HitBoxData: DataElement
    {
        [field: SerializeField] public List<Rect> HitBox { get; private set; }
        [field: SerializeField] public LayerMask detectLayer { get; private set; }
    }
}