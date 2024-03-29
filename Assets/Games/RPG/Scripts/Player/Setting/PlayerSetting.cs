﻿using System.Collections.Generic;
using UnityEngine;

namespace RPG.Setting
{
    [CreateAssetMenu(fileName = "PlayerSetting", menuName = "RPG/PlayerSetting", order = 0)]
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