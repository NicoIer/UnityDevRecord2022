using System;
using System.Collections.Generic;
using Nico.Utils.Core;
using RPG.Controller;
using RPG.Setting;
using Sirenix.OdinInspector;
using UnityEngine;

namespace RPG
{
    public class Player : MonoBehaviour
    {
        [field: SerializeField] public PlayerSetting setting { get; private set; }

        #region Mono Components

        public Rigidbody2D rb { get; private set; }
        public Collider2D col { get; private set; }
        public Animator ac { get; private set; }

        #endregion


        #region Controller

        [field: SerializeField] public PlayerStateMachine stateMachine { get; private set; }
        [field: SerializeField] public PlayerAttributeController attributeController { get; private set; }
        private readonly List<IController<Player>> controllers = new();

        #endregion

        #region Components

        [field: SerializeField] public PlayerAttribute attribute { get; private set; }
        public PlayerInput input { get; private set; }
        private readonly List<IComponent<Player>> components = new();

        #endregion


        #region Life Time

        private void Awake()
        {
            _get_mono_components();
            _init_components();
            _init_controller();
        }

        private void _get_mono_components()
        {
            rb = GetComponent<Rigidbody2D>();
            col = GetComponent<Collider2D>();
            ac = GetComponent<Animator>();
        }

        private void _init_components()
        {
            input = new PlayerInput(this);
            components.Add(input);
        }

        private void _init_controller()
        {
            attributeController = new PlayerAttributeController(this, attribute);
            stateMachine = new PlayerStateMachine(this);
            controllers.Add(attributeController);
            controllers.Add(stateMachine);
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
            foreach (var component in controllers)
            {
                component.Update();
            }
        }

        private void FixedUpdate()
        {
            foreach (var component in controllers)
            {
                component.FixedUpdate();
            }
        }

        private void OnEnable()
        {
            foreach (var component in components)
            {
                component.Enable();
            }

            foreach (var component in controllers)
            {
                component.OnEnable();
            }
        }

        private void OnDisable()
        {
            foreach (var component in components)
            {
                component.Disable();
            }

            foreach (var component in controllers)
            {
                component.OnDisable();
            }
        }

        #endregion

        #region Event

        #region Collision2D

        public Action<Collision2D> collisionEnter2D;
        public Action<Collision2D> collisionExit2D;
        public Action<Collision2D> collisionStay2D;

        public Action<Collider2D> triggerEnter2D;
        public Action<Collider2D> triggerExit2D;


        private void OnCollisionEnter2D(Collision2D col)
        {
            collisionEnter2D?.Invoke(col);
        }

        private void OnCollisionExit2D(Collision2D other)
        {
            collisionExit2D?.Invoke(other);
        }

        private void OnCollisionStay2D(Collision2D collision)
        {
            collisionStay2D?.Invoke(collision);
        }

        private void OnTriggerEnter2D(Collider2D other)
        {
            triggerEnter2D?.Invoke(other);
        }

        private void OnTriggerExit2D(Collider2D other)
        {
            triggerExit2D?.Invoke(other);
        }

        #endregion

        #endregion
    }
}