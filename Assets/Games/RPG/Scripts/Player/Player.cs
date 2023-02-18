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

        public float collisionOffsett = 0.05f;
        public ContactFilter2D contactFilter;
        public List<RaycastHit2D> raycastHit2Ds = new List<RaycastHit2D>();

        #region Components

        public Rigidbody2D rb { get; private set; }
        public Collider2D collider { get; private set; }
        public Animator animator { get; private set; }

        #endregion


        public PlayerInput input { get; private set; }

        public PlayerAttribute attribute { get; private set; }
        private PlayerController controller { get; set; }

        private readonly List<IController<Player>> components = new();

        #region Life Time

        private void Awake()
        {
            _get_components();
            _init_controller();
            attribute = new PlayerAttribute(this);
            input = new PlayerInput();
        }

        private void _get_components()
        {
            rb = GetComponent<Rigidbody2D>();
            collider = GetComponent<Collider2D>();
            animator = GetComponent<Animator>();
        }

        private void _init_controller()
        {
            controller = new PlayerController(this);

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