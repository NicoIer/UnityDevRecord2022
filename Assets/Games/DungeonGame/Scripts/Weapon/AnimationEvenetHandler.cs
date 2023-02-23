using System;
using UnityEngine;

namespace Games.DungeonGame.Scripts.Weapon
{
    public class AnimationEvenetHandler : MonoBehaviour
    {
        public event Action enter;
        public event Action attack;
        public event Action exit;
        
        public void AnimationEnterTrigger()
        {
            enter?.Invoke();
        }
        
        public void AnimationAttackTrigger()
        {
            attack?.Invoke();
        }
        
        public void AnimationExitTrigger()
        {
            exit?.Invoke();
        }
    }
}