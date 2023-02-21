using UnityEngine.PlayerLoop;

namespace Nico.ECC
{
    public interface IState<T>
    {
        public T owner { get; set; }
        public IStateMachine<T> machine { get; set; }
        public void Update();
        public void FixedUpdate();
        public void Exit();
        public void Enter();
    }
}