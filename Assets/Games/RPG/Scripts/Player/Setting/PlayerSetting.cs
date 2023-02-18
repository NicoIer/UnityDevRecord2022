using UnityEngine;

namespace RPG.Setting
{
    [CreateAssetMenu(fileName = "PlayerSetting", menuName = "RPG/PlayerSetting", order = 0)]
    public class PlayerSetting : ScriptableObject
    {
        public float x_speed;
        public float y_speed;
    }
}