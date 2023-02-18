using System.Collections.Generic;
using Nico.Utils.Core;
using RPG.Setting;
using Sirenix.OdinInspector;
using UnityEngine;

namespace RPG
{
    public class Player : MonoBehaviour
    {
        public Rigidbody2D rb { get; private set; }
        public PlayerInput input { get; private set; }
        [ShowInInspector] public PlayerSetting setting { get; private set; }
        public PlayerAttribute attribute { get; private set; }
        private PlayerController controller { get; set; }

        private readonly List<IController<Player>> components = new();

        #region Life Time

        private void Awake()
        {
            _get_components();
            _init_cotroller();
            attribute = new PlayerAttribute(this);
            input = new PlayerInput();
        }

        private void _get_components()
        {
            rb = GetComponent<Rigidbody2D>();
        }

        private void _init_cotroller()
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
    }
}