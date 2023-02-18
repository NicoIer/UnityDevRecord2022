using System;
using System.Collections.Generic;
using Nico.Utils.Core.StateMachine;
using UnityEngine;

namespace RPG
{
    public class PlayerStateMachine : IStateMachine<Player>
    {
        public Player owner { get; private set; }
        public IState<Player> cur { get; private set; }
        private Dictionary<Type, IState<Player>> states = new();

        public PlayerStateMachine(Player owner)
        {
            this.owner = owner;
        }

        #region IStateMachine

        public void Start()
        {
            states.TryAdd(typeof(IdleState), new IdleState(owner, this));
            states.TryAdd(typeof(MoveState), new MoveState(owner, this));
            
            cur = states[typeof(IdleState)];
        }

        public void Update()
        {
            cur.Update();
        }

        public void FixedUpdate()
        {
            cur.FixedUpdate();
        }


        public void Enable()
        {
        }

        public void Disable()
        {
        }

        public void Change<T1>() where T1 : IState<Player>
        {
            Debug.Log($"from{cur.GetType()}to{typeof(T1)}");
            cur?.Exit();
            cur = states[typeof(T1)];
            cur?.Enter();
        }

        #endregion
    }
}