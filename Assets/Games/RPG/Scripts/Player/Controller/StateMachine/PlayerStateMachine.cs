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
            states.TryAdd(typeof(IdleState), new IdleState(owner,this,owner.setting.animIdle));
            states.TryAdd(typeof(WalkState), new WalkState(owner, this,owner.setting.animWalk));
            states.TryAdd(typeof(AttackState), new AttackState(owner, this,owner.setting.animAttack));
            // states.TryAdd(typeof(RunState), new RunState(owner, this,owner.setting.animRun));
            //ToDo 期望这里可以自动添加所有的状态
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


        public void OnEnable()
        {
        }

        public void OnDisable()
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