using System.Collections.Generic;
using UnityEngine;

namespace RPG.Setting
{
    [CreateAssetMenu(fileName = "PlayerSetting", menuName = "RPG/PlayerSetting", order = 0)]
    public class PlayerSetting : ScriptableObject
    {
        public float xSpeed;
        public float ySpeed;
        public string animIdle = "idle";
        public string animMove = "move";
    }
}