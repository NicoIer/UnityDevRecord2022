using System;
using System.Collections.Generic;
using Nico.Data;
using Nico.ECC.Data;
using UnityEngine;

namespace WeaponSys
{
    /// <summary>
    /// 后续改成DataTable + Data->string->查找资源的形式
    /// </summary>
    [CreateAssetMenu(fileName = "WeaponData", menuName = "WeaponSys/WeaponData", order = 0)]
    public class WeaponData: DataContainer<Weapon>
    {
        public int ID;
        public Sprite icon;
        //ToDo 获取可以做一个WeaponMetaData的抽象类
        private SwordMetaData metaData => DataTableManager.instance.swordMetaDataTable.GetByID(ID);

        public string meataName => metaData.name;
        public string description => metaData.description;
        public int numOfAttack => metaData.numOfAttack;
        public float attackInterval => metaData.maxInterval;

        private List<AnimStorage> _attackAnim;

        public List<AnimStorage> attackAnim
        {
            get
            {
                if (_attackAnim == null)
                {
                    _attackAnim = new List<AnimStorage>();
                    var animIDs = metaData.animIDs;
                    var animTable = DataTableManager.instance.animDataTable;

                    foreach (var animID in animIDs)
                    {
                        _attackAnim.Add(animTable.GetByIdx(animID));
                    }
                }

                return _attackAnim;
            }
        }

        //ToDo 暂时用这个 之后改成DataTable读取 整合到SwordMetaData中 
        public SwordAttackMoveData swordAttackMoveData;

        public HitBoxData hitBoxData;

        public AttackDamageData damageData;


    }
}