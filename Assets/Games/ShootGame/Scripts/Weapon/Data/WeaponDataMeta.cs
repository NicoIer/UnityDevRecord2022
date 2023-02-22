using System;
using Nico.Data;

namespace ShootGame
{
    [Serializable]
    public struct WeaponDataMeta
    {
        public int id;
        public string name;
        public int animStorageID;
        public float attackInterval;
    }
}