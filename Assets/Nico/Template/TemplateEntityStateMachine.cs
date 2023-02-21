using System;
using System.Collections.Generic;
using Nico.Utils.Core;
using RPG;
using UnityEngine;

namespace Nico.Template
{
    public abstract class TemplateEntityStateMachine<T> : IStateMachine<T>
    {
        public T owner { get; private set; }
        public IState<T> cur { get; protected set; }
        protected Dictionary<Type, IState<T>> states = new();

        public TemplateEntityStateMachine(T owner)
        {
            this.owner = owner;
        }

        #region IStateMachine

        public abstract void Start();

        public void Update()
        {
            cur.Update();
        }

        public void FixedUpdate()
        {
            cur.FixedUpdate();
        }


        public abstract void OnEnable();

        public abstract void OnDisable();

        public void Change<T1>() where T1 : IState<T>
        {
            cur?.Exit();
            cur = states[typeof(T1)];
            cur?.Enter();
        }

        #endregion
    }
}