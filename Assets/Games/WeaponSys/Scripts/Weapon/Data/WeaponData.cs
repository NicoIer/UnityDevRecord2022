using System;
using System.Collections.Generic;
using Nico.Data;
using Sirenix.OdinInspector;
using UnityEngine;

namespace WeaponSys
{
    /// <summary>
    /// 后续改成DataTable + Data->string->查找资源的形式
    /// </summary>
    [Serializable]
    public class WeaponData
    {
        public int ID;
        public Sprite icon;

        private SwordMetaData metaData => DataTableManager.instance.swordMetaDataTable.GetByID(ID);

        public string name => metaData.name;
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
    }
}