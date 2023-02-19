using System;
using System.Collections.Generic;
using System.Threading;
using Cysharp.Threading.Tasks;
using Nico.Utils.Core;
using RPG;
using UnityEngine;

namespace WeaponSys
{
    public class Weapon : MonoBehaviour
    {
        public int curAttackCount;
        public int numberOfAttack = 3;
        public float intervalTime = 1.5f;

        public Animator ac { get; private set; }
        public WeaponData data;
        public NormalControls oper { get; private set; }

        public AnimationEventHandler animationEventHandler { get; private set; }

        private readonly List<IComponent<Weapon>> components = new();
        private readonly List<IController<Weapon>> controllers = new();


        private void Awake()
        {
            var baseObj = transform.Find("Base").gameObject;
            animationEventHandler = baseObj.GetComponent<AnimationEventHandler>();
            ac = baseObj.GetComponent<Animator>();

            oper = new NormalControls();
            oper.Player.Enable();

            var animController = new AnimController(this);
            controllers.Add(animController);
        }

        private void Start()
        {
            foreach (var controller in controllers)
            {
                controller.Start();
            }
        }

        private void Update()
        {
            foreach (var controller in controllers)
            {
                controller.Update();
            }
        }

        private void FixedUpdate()
        {
            foreach (var controller in controllers)
            {
                controller.FixedUpdate();
            }
        }

        private void OnEnable()
        {
            foreach (var component in components)
            {
                component.Enable();
            }
        }

        private void OnDisable()
        {
            foreach (var component in components)
            {
                component.Disable();
            }
        }
    }
}