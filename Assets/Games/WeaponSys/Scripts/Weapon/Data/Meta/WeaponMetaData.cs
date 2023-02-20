using System.Collections.Generic;

namespace WeaponSys
{
    public struct WeaponMetaData
    {
        public int ID;
        public string name;
        public string description;
        public string iconPath;
        public int numOfAttack;
        public float attackInterval;
        public int[] animMetaIDs;
    }
}