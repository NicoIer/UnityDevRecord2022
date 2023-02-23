using System;
using UnityEngine;

namespace DungeonGame
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