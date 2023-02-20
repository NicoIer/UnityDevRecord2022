using System;
using System.Collections.Generic;
using System.Threading;
using Cysharp.Threading.Tasks;
using Nico.Utils.Core;
using RPG;
using Sirenix.OdinInspector;
using UnityEngine;
using WeaponSys.Components;

namespace WeaponSys
{
    public class Weapon : MonoBehaviour
    {

        public Animator ac { get; private set; }
        public WeaponData data;
        public NormalControls oper { get; private set; }

        public AnimationEventHandler animationEventHandler { get; private set; }

        [ShowInInspector] private readonly List<IComponent<Weapon>> components = new();

        public AnimController animController { get; private set; }
        [ShowInInspector] private readonly List<IController<Weapon>> controllers = new();

        GameObject baseObj;
        SpriteRenderer baseRenderer;
        GameObject weaponSpriteObj;
        SpriteRenderer weaponRenderer;

        private void Awake()
        {
            _init_mono_components();
            oper = new NormalControls();
            oper.Player.Enable();
            _init_controller();
        }

        private void _init_mono_components()
        {
            baseObj = transform.Find("Base").gameObject;
            baseRenderer = baseObj.GetComponent<SpriteRenderer>();
            ac = baseObj.GetComponent<Animator>();

            animationEventHandler = baseObj.GetComponent<AnimationEventHandler>();

            weaponSpriteObj = transform.Find("WeaponSprite").gameObject;
            weaponRenderer = weaponSpriteObj.GetComponent<SpriteRenderer>();
        }

        private void _init_controller()
        {
            animController = new AnimController(this);
            controllers.Add(animController);
            var weaponSprite = new WeaponSprite(this, baseRenderer, weaponRenderer);
            controllers.Add(weaponSprite);
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
                component.OnEnable();
            }

            foreach (var controller in controllers)
            {
                controller.OnEnable();
            }
        }

        private void OnDisable()
        {
            foreach (var component in components)
            {
                component.OnDisable();
            }
            
            foreach (var controller in controllers)
            {
                controller.OnDisable();
            }
        }
    }
}