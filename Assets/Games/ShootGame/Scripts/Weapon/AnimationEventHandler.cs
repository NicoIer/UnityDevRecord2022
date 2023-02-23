using System;
using Mirror;
using UnityEngine;

namespace ShootGame
{
    public class AnimationEventHandler : MonoBehaviour
    {
        public event Action OnStartAnim;
        public event Action OnStartAttack;
        public event Action OnStopAttack;
        public event Action OnStopAnim;


        public void StartAnim()
        {
            OnStartAnim?.Invoke();
        }

        public void StartAttack()
        {
            OnStartAttack?.Invoke();
        }

        public void StopAttack()
        {
            OnStopAttack?.Invoke();
        }

        public void StopAnim()
        {
            OnStopAnim?.Invoke();
        }
    }
}