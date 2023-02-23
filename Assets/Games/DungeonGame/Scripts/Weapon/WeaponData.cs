using Nico.ECC.Dependency;
using UnityEngine;

namespace Games.DungeonGame.Scripts.Weapon
{
    [CreateAssetMenu(fileName = "WeaponData", menuName = "ShootGame/WeaponData", order = 0)]
    public class WeaponData: DataContainer
    {
        //武器使用的弹药预制体
        public GameObject bulletPrefab;
        //武器的弹壳预制体
        public GameObject shellPrefab;
        //武器的射击间隔
        public float fireInterval;
    }
}