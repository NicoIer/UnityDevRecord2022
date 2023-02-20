using System;
using System.Collections.Generic;
using Sirenix.OdinInspector;
using UnityEngine;

namespace WeaponSys
{
    /// <summary>
    /// 后续改成DataTable + Data->string->查找资源的形式
    /// </summary>
    [CreateAssetMenu(fileName = "WeaponData", menuName = "WeaponSys/WeaponData", order = 0)]
    public class WeaponData : ScriptableObject
    {
        public int ID;
        public string name;
        public string description;
        public Sprite icon;
        public int numOfAttack = 3;
        public float attackInterval = 1.5f;
        public List<WeaponAttackAnim> attackAnim = new List<WeaponAttackAnim>();
    }

    [Serializable]
    public class WeaponAttackAnim
    {
        public List<Sprite> sprites;
    }
}