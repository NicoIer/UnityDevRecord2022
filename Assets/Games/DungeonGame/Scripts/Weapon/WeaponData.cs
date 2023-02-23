using Nico.ECC.Dependency;
using UnityEngine;

namespace DungeonGame
{
    [CreateAssetMenu(fileName = "WeaponData", menuName = "ShootGame/WeaponData", order = 0)]
    public class WeaponData: DataContainer
    {
        //武器的射击间隔
        public float attackInterval;
        public float bulletSpeed = 5;
    }
}