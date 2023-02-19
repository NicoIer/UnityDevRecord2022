using System;
using UnityEngine;

namespace WeaponSys
{
    public class AnimationEventHandler : MonoBehaviour
    {
        public event Action OnExit;
        public event Action OnEnter;
        
        public void AnimationExitTrigger()
        {
            OnExit?.Invoke();
        }

        public void AnimationEnterTrigger()
        {
            OnEnter?.Invoke();
        }
    }
}