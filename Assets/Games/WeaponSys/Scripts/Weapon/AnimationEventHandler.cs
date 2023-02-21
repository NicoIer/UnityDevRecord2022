using System;
using UnityEngine;

namespace WeaponSys
{
    public class AnimationEventHandler : MonoBehaviour
    {
        public event Action OnExit;
        public event Action OnEnter;
        public event Action OnStartMove;
        public event Action OnStopMove;

        public event Action OnAttack;
        public void AnimationExitTrigger()
        {
            OnExit?.Invoke();
        }

        public void AnimationEnterTrigger()
        {
            OnEnter?.Invoke();
        }

        public void AnimationStartMoveTrigger()
        {
            OnStartMove?.Invoke();
        }

        public void AnimatonStopMoveTrigger()
        {
            OnStopMove?.Invoke();
        }
        
        public void AnimationAttackTrigger()
        {
            OnAttack?.Invoke();
        }
    }
}