using System;
using DungeonGame.Scripts;
using UnityEngine;

namespace DungeonGame
{
    public class Effect: MonoBehaviour
    {
        private Animator ac;

        private void Awake()
        {
            ac = GetComponent<Animator>();
        }

        private void OnEnable()
        {
            ac.SetTrigger("active");
        }

        private void Update()
        {
            //动画播放完毕时 销毁物体
            if (ac.GetCurrentAnimatorStateInfo(0).normalizedTime >= 1)
            {
                ObjectPoolManager.instance.ReturnObject("effect", gameObject);
            }
        }
    }
}