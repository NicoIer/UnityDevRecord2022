using System.Collections.Generic;
using Nico.Data;
using Nico.ECC.Dependency;
using UnityEngine;

namespace ShootGame
{
    [CreateAssetMenu(fileName = "WeaponData", menuName = "ShootGame/WeaponData", order = 0)]
    public class WeaponData : DataContainer
    {
        //武器数据应该有其攻击动画通过id查找对应的动画数据 
        public int animStorageID;
        private AnimStorage storage;

        public AnimStorage animSprites=>DataTableManager.instance.animDataTable.GetByIdx(animStorageID);
        public Vector3 rightPostion;
        public Vector3 leftPostion;
    }
}