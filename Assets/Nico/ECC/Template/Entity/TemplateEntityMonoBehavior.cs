using System;
using System.Collections.Generic;
using System.Linq;
using Sirenix.OdinInspector;
using UnityEngine;

namespace Nico.ECC.Template
{
    public abstract class TemplateEntityMonoBehavior<T> : MonoBehaviour,IEntity
    {
        [ShowInInspector] protected readonly List<IController<T>> controllers = new();
        [ShowInInspector] protected readonly List<IComponent<T>> components = new();


        public T1 GetIComponent<T1>() where T1 : IComponent<T>
        {
            return components.OfType<T1>().First();
        }


        public T1 GetIController<T1>() where T1 : IController<T>
        {
            return controllers.OfType<T1>().First();
        }


        public bool HasComponent(Type type)
        {
            return components.Any(component => component.GetType() == type);
        }
        
        public bool HasController(Type type)
        {
            return controllers.Any(controller => controller.GetType() == type);
        }
        
        public void AddComponent(IComponent<T> component)
        {
            components.Add(component);
        }

        public void AddController(IController<T> controller)
        {
            controllers.Add(controller);
        }
        
        
        #region Init

        private void Awake()
        {
            _get_mono_components();
            _init_components();
            _init_controller();
        }

        protected abstract void _get_mono_components();

        protected abstract void _init_components();

        protected abstract void _init_controller();

        #endregion


        protected virtual void Start()
        {
            foreach (var controller in controllers)
            {
                controller.Start();
            }
        }

        protected virtual void Update()
        {
            foreach (var controller in controllers)
            {
                controller.Update();
            }
        }

        protected virtual void FixedUpdate()
        {
            foreach (var component in controllers)
            {
                component.FixedUpdate();
            }
        }

        protected virtual void OnEnable()
        {
            foreach (var component in components)
            {
                component.OnEnable();
            }

            foreach (var component in controllers)
            {
                component.OnEnable();
            }
        }

        protected virtual void OnDisable()
        {
            foreach (var controller in controllers)
            {
                controller.OnDisable();
            }

            foreach (var component in components)
            {
                component.OnDisable();
            }
        }
    }
}