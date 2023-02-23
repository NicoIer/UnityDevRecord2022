using Nico.ECC.Dependency;
using UnityEngine;

namespace Games.DungeonGame.Scripts.Weapon
{
    [CreateAssetMenu(fileName = "WeaponData", menuName = "ShootGame/WeaponData", order = 0)]
    public class WeaponData: DataContainer
    {
        //武器的射击间隔
        public float attackInterval;
    }
}