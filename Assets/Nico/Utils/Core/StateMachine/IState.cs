using UnityEngine.PlayerLoop;

namespace Nico.Utils.Core.StateMachine
{
    public interface IState<T>: ICoreComponent
    {
        public T owner { get; set; }
        public IStateMachine<T> machine { get; set; }
        public void Update();
        public void FixedUpdate();
        public void Exit();
        public void Enter();
    }
}