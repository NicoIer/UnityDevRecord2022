using UnityEngine;

namespace WeaponSys
{
    [CreateAssetMenu(fileName = "PlayerSetting", menuName = "WeaponSys/PlayerSetting", order = 0)]
    public class PlayerSetting : ScriptableObject
    {
        public float xSpeed;
        public float ySpeed;
        public string animIdle = "idle";
        public string animWalk = "walk";
        public string xCode = "xCode";
        public string yCode = "yCode";
        public string animAttack = "attack";
    }
}