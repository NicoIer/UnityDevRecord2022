using UnityEngine;

namespace Nico.ECC.Template
{
    public abstract class TemplateState<T> : IState<T>
    {
        public T owner { get; set; }
        public IStateMachine<T> machine { get; set; }
        protected readonly int animParam;

        protected TemplateState(T owner, IStateMachine<T> machine, string animParam)
        {
            this.owner = owner;
            this.machine = machine;
            this.animParam = Animator.StringToHash(animParam);
        }

        public abstract void Update();

        public abstract void FixedUpdate();

        public abstract void Exit();
        // {
        //     owner.ac.SetBool(animParam, false);
        // }

        public abstract void Enter();
        // {
        //     owner.ac.SetBool(animParam, true);
        // }
    }
}