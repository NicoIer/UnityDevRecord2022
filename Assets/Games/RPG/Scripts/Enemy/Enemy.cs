using System;
using UnityEngine;

namespace RPG.Enemy
{
    public class Enemy: MonoBehaviour
    {
        private float _health;



        public void TakeDamage(float damge)
        {
            _health -= damge;
            if (_health <= 0)
            {
                Die();
            }
        }

        public void Die()
        {
            print("die");
            gameObject.SetActive(false);
        }

        private void OnTriggerStay2D(Collider2D other)
        {
            
        }
    }
}