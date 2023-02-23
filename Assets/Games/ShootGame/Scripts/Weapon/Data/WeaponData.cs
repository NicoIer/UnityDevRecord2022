using System.Collections.Generic;
using Nico.Data;
using Nico.ECC.Dependency;
using UnityEngine;

namespace ShootGame
{
    [CreateAssetMenu(fileName = "WeaponData", menuName = "ShootGame/WeaponData", order = 0)]
    public class WeaponData : DataContainer
    {
        //通过metaID查询枪械数据
        public int metaID;
        public WeaponDataMeta meta;
        //通过ID查询其动画帧图像数据
        public AnimStorage animSprites=>DataTableManager.instance.animDataTable.GetByIdx(meta.animStorageID);
        public GameObject bulletPrefab;
        public GameObject shellPrefab;
        public Vector2 fireAngel;//发射角度
        public Vector3 firePostion;//子弹发射位置
        public Vector3 clipPostion;//弹夹位置
        
        public Vector3 rightPostion;//武器面朝右边的位置
        public Vector3 leftPostion;//武器面朝左边的位置
    }
}