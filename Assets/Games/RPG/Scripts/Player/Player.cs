using System;
using System.Collections.Generic;
using Nico.Utils.Core;
using RPG.Setting;
using Sirenix.OdinInspector;
using UnityEngine;

namespace RPG
{
    public class Player : MonoBehaviour
    {
        [field: SerializeField] public PlayerSetting setting { get; private set; }

        #region Components

        public Rigidbody2D rb { get; private set; }
        public Collider2D col { get; private set; }
        public Animator ac { get; private set; }

        #endregion


        public PlayerInput input { get; private set; }

        [field: SerializeField] public PlayerAttribute attribute { get; private set; }
        [field: SerializeField] public PlayerController controller { get; private set; }

        private readonly List<IController<Player>> components = new();

        #region Life Time

        private void Awake()
        {
            _get_components();
            _init_controller();
            
            input = new PlayerInput();
        }

        private void _get_components()
        {
            rb = GetComponent<Rigidbody2D>();
            col = GetComponent<Collider2D>();
            ac = GetComponent<Animator>();
        }

        private void _init_controller()
        {
            attribute = new PlayerAttribute(this);
            controller = new PlayerController(this);
            components.Add(attribute);
            components.Add(controller);
            
        }

        private void Start()
        {
            foreach (var component in components)
            {
                component.Start();
            }
        }

        private void Update()
        {
            foreach (var component in components)
            {
                component.Update();
            }
        }

        private void FixedUpdate()
        {
            foreach (var component in components)
            {
                component.FixedUpdate();
            }
        }

        private void OnEnable()
        {
            input.Enable();
            foreach (var component in components)
            {
                component.Enable();
            }
        }

        private void OnDisable()
        {
            input.Disable();
            foreach (var component in components)
            {
                component.Disable();
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